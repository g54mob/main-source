namespace VRTK
{
	public static class SDK_WindowsMRDefines
	{
		public const string ScriptingDefineSymbol = "VRTK_DEFINE_SDK_WINDOWSMR";

		private const string BuildTargetGroupName = "WSA";

		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_SDK_WINDOWSMR", "WSA")]
		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_WINDOWSMR_CONTROLLER_VISUALIZATION", "WSA")]
		private static bool HasControllerVisualization()
		{
			return VRTK_SharedMethods.GetTypeUnknownAssembly("VRTK.WindowsMixedReality.MotionControllerVisualizer") != null;
		}

		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_SDK_WINDOWSMR", "WSA")]
		private static bool IsXRSettingsEnabled()
		{
			return true;
		}
	}
}
