public struct BuildDescriptor
{
	public enum BuildType
	{
		Construction = 0,
		Furniture = 1,
		Roads = 2,
		Environment = 3
	}

	public enum CategoryType
	{
		Room = 0,
		Function = 1
	}

	public readonly BuildType Type;

	public readonly string[] Category;

	public readonly string FunctionalCategory;

	public readonly string SearchString;

	public readonly Furniture Furniture;

	public BuildDescriptor(BuildType type, string funCat, string search, Furniture furn, params string[] cat)
	{
		Type = type;
		Category = cat;
		FunctionalCategory = funCat;
		SearchString = search.ToLower();
		Furniture = furn;
	}
}
