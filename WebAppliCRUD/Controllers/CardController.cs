using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppliCRUD.Data;
using WebAppliCRUD.Models;

namespace WebAppliCRUD.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CardController : Controller
    {
        private readonly CardDBContext cardDBContext;
        public CardController(CardDBContext cardDBContext)
        {
            this.cardDBContext = cardDBContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = await cardDBContext.Cards.ToListAsync();
            return Ok(cards);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCards")]
        public async Task<IActionResult> GetCards([FromRoute]Guid id)
        {
            var cards = await cardDBContext.Cards.FirstOrDefaultAsync(x=>x.id==id);
            if(cards!=null)
            {
                return Ok(cards);
            }
            return NotFound(" Card not found");
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        
        public async Task<IActionResult> AddCards([FromBody] Card card)
        {
            card.id = Guid.NewGuid();
            await cardDBContext.Cards.AddAsync(card);
            await cardDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCards),new {id=card.id},card);
            
        }

        //update card
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCards([FromRoute] Guid id,[FromBody] Card card)
        {
            var existingCard = await cardDBContext.Cards.FirstOrDefaultAsync(x => x.id == id);
            if(existingCard!=null)
            {
                existingCard.CardidHolder = card.CardidHolder;
                existingCard.CardNumber = card.CardNumber;
                existingCard.ExpireMonth = card.ExpireMonth;
                existingCard.ExpireYear= card.ExpireYear;
                existingCard.CVC = card.CVC;
                await cardDBContext.SaveChangesAsync();
                return Ok(existingCard);
            }
            return NotFound("Card not found");
           
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCards([FromRoute] Guid id)
        {
            var existingCard = await cardDBContext.Cards.FirstOrDefaultAsync(x => x.id == id);
            if (existingCard != null)
            {
                cardDBContext.Remove(existingCard);
                await cardDBContext.SaveChangesAsync();
                return Ok(existingCard);
            }
            return NotFound("Card not found");

        }
    }
}
//card.id = Guid.NewGuid();
//await cardDBContext.Cards.AddAsync(card);
//await cardDBContext.SaveChangesAsync();
//return CreatedAtAction(nameof(GetCards), card.id, card);