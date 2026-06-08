namespace KitchenData
{
	public static class DisplayedPatienceFactorExtensions
	{
		public static bool HasFlagFast(this DisplayedPatienceFactor value, DisplayedPatienceFactor flag)
		{
			return (value & flag) != 0;
		}
	}
}
