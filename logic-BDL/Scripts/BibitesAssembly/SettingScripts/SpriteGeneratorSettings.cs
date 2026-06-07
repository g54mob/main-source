namespace SettingScripts
{
	public static class SpriteGeneratorSettings
	{
		public static IntSetting ImageRatio = new IntSetting
		{
			Name = "Output Pixel Ratio",
			HelperText = "The magnification ratio of the output image (target pixels per source pixels)",
			DefaultValue = 10,
			val = 10,
			minValue = 1,
			maxValue = 50,
			prefix = "",
			units = "x"
		};

		public static FloatSetting inflateRatio = new FloatSetting
		{
			Name = "Inflate Ratio",
			HelperText = "What the bibite would look like if it accumulated enough fat to fatten",
			DefaultValue = 0f,
			val = 0f,
			factor = 100f,
			units = "%",
			SI = false,
			precision = 0,
			minValue = 0f,
			maxValue = 1f,
			canGoOutOfBounds = false
		};
	}
}
