namespace Catalog.API.Models
{
    public record Product(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        string ImageFile,
        List<string> Category
    );
}
