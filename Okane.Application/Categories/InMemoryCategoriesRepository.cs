using Okane.Domain;

namespace Okane.Application.Categories;

public class InMemoryCategoriesRepository : ICategoriesRepository
{
    private readonly IList<Category> _categories;
    private int _nextId = 1;

    public InMemoryCategoriesRepository() => 
        _categories = new List<Category>();

    public Category ByName(string categoryName) => 
        _categories.First(c => c.Name == categoryName);

    public Category Add(Category category)
    {
        category.Id = _nextId++;
        _categories.Add(category);
        return category;
    }
}