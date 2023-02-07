using AutoMapper;
using MediatR;
using ProductApp.Application.Features.Commands.CreateProduct;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Handlers.CreateProductHandle
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Domain.Entities.Product>(request);
            await _productRepository.AddEntityAsync(product);
            return new ServiceResponse<Guid>(product.Id);
        }
    }
}
