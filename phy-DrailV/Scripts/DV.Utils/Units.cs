public static class Units
{
	public const float Kmh2Ms = 5f / 18f;

	public const float Ms2Kmh = 3.6f;

	public const float M_TO_KM = 0.001f;

	public const float KM_TO_M = 1000f;

	public const float MIN_TO_SEC = 60f;

	public const float H_TO_SEC = 3600f;

	public const float KG_TO_T = 0.001f;

	public const float PROPORTION_TO_PERCENTAGE_NOTATION = 100f;

	public const float M_TO_FT = 3.28f;

	public const float FT_TO_IN = 12f;

	private static readonly string[] byteUnits = new string[6] { "B", "KB", "MB", "GB", "TB", "PB" };

	public static string FormatBytes(this long byteCount)
	{
		int num = 0;
		double num2 = byteCount;
		while (num2 >= 1000.0 && num < byteUnits.Length - 1)
		{
			num++;
			num2 /= 1000.0;
		}
		return $"{num2:#,0.##} {byteUnits[num]}";
	}
}
