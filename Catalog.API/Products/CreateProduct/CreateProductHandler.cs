using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        string Description,
        decimal Price,
        string ImageFile,
        List<string> Category
    ) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product(
                Guid.NewGuid(),
                command.Name,
                command.Description,
                command.Price,
                command.ImageFile,
                command.Category
            );

            return Task.FromResult(new CreateProductResult(product.Id));
        }
    }
}
