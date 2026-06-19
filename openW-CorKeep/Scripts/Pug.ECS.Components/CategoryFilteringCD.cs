using Unity.Entities;

public struct CategoryFilteringCD : IComponentData, IQueryTypeParameter
{
	public ObjectCategoryTag filterCategory;
}
