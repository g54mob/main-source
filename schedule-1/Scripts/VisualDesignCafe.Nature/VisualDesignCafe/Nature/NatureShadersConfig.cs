namespace VisualDesignCafe.Nature
{
	internal static class NatureShadersConfig
	{
		public const string LogPrefix = "[Nature Shaders] ";

		public const string LogSupportNotice = "Please contact support if this error keeps appearing. (Help > Nature Shaders > Contact Us)";

		public static readonly bool Debug;

		public static readonly bool Verbose;

		private static Logger _logger;

		public static Logger Log => null;
	}
}
