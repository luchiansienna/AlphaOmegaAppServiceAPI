using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AlphaOmegaAppServiceAPI.Models;
using AlphaOmegaAppServiceAPI.Services;

namespace AlphaOmegaAppServiceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {

        private readonly IEventService _productService;

        public EventsController(IEventService products)
        {
            _productService = products;
        }

        [HttpGet]
        public async Task<IEnumerable<Event>> Get(int n = 20)
        {
            // return "LUCHIAN";
            return await _productService.GetNAsync(n);
        }

        [HttpGet("{Id}", Name = "GetEvent")]
        public async Task<ActionResult<Event>> GetById(string Id)
        {
            var product =  await _productService.GetByIdAsync(Id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Event>> Create(Event item)
        {
            await _productService.CreateAsync(item);

            return CreatedAtRoute("GetProduct", new { Id = item.Id }, item);
        }

        [HttpPut]
        public async Task<ActionResult<Event>> Update(Event update)
        {
            var eventObject = await _productService.UpdateAsync(update);

            return CreatedAtRoute("GetEvent", new { Id = eventObject.Id }, eventObject);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            await _productService.DeleteAsync(Id);

            return Ok();
        }
    }
}
