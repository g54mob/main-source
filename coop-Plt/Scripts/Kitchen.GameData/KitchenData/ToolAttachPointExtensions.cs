namespace KitchenData
{
	public static class ToolAttachPointExtensions
	{
		public static bool HasFreeHand(this ToolAttachPoint tap)
		{
			if (tap != ToolAttachPoint.Hand)
			{
				return tap == ToolAttachPoint.HandFlat;
			}
			return true;
		}
	}
}
