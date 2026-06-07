namespace DV.UI.Inventory
{
	public struct HotbarSlotPointerData
	{
		public float standardSlotWidth;

		public float upperLimit;

		public HotbarSlotPointerData(float standardSlotWidth, float upperLimit)
		{
			this.standardSlotWidth = standardSlotWidth;
			this.upperLimit = upperLimit;
		}
	}
}
