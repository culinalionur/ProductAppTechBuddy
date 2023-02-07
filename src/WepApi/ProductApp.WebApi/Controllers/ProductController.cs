using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Features.Commands.CreateProduct;
using ProductApp.Application.Features.Queries.GetAllProducts;
using ProductApp.Application.Interfaces.Repository;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

       

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allList = await _mediator.Send(new GetAllProductsQuery());
            return Ok(allList);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
