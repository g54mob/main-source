namespace Brewery.Employee.AI
{
	public struct RecipeInput
	{
		public string itemId;

		public int quantity;

		public int slotIndex;

		public BarrelRequirement barrelRequirement;

		public RecipeInput(string itemId, int quantity, int slotIndex, BarrelRequirement barrelReq = BarrelRequirement.None)
		{
			this.itemId = null;
			this.quantity = 0;
			this.slotIndex = 0;
			barrelRequirement = default(BarrelRequirement);
		}
	}
}
