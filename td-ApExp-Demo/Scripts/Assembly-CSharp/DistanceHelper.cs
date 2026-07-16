public static class DistanceHelper
{
	public static string UnitsToMetricString(float units)
	{
		float num = units * 10f;
		string text = null;
		if (num >= 1000f)
		{
			return ((float)(int)num / 1000f).ToString("N1") + "km";
		}
		return num.ToString("N0") + "m";
	}
}
