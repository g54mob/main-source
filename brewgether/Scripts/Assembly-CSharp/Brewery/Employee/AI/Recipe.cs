namespace Brewery.Employee.AI
{
	public struct Recipe
	{
		public StationRole stationRole;

		public RecipeInput[] inputs;

		public RecipeInput[] optionalInputs;

		public string outputItemId;

		public int outputQuantity;
	}
}
