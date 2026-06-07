namespace CompassNavigatorPro
{
	public static class CompassStyleExtensions
	{
		public static bool HasDegreesOrTicks(this CompassStyle style)
		{
			if (style >= CompassStyle.CleanWithIntegratedDegrees)
			{
				return style <= CompassStyle.CleanWithIntegratedDegreesAndTicks4;
			}
			return false;
		}
	}
}
