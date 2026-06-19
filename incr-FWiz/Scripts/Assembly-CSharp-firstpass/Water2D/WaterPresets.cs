namespace Water2D
{
	public static class WaterPresets
	{
		public enum WaterPresetShaders
		{
			gradientFoam = 0,
			vonroiFoam = 1
		}

		public const string gradientFoamShaderPath = "Materials/gradientFoamWater";

		public const string vonroiFoamShaderPath = "Materials/vonroiFoamWater";

		public static string GetPath(WaterPresetShaders preset)
		{
			return null;
		}
	}
}
