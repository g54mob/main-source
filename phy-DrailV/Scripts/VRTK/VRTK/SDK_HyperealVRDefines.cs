namespace VRTK
{
	public static class SDK_HyperealVRDefines
	{
		public const string ScriptingDefineSymbol = "VRTK_DEFINE_SDK_HYPEREALVR";

		private const string BuildTargetGroupName = "Standalone";

		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_SDK_HYPEREALVR", "Standalone")]
		private static bool IsHyperealVRAvailable()
		{
			return VRTK_SharedMethods.GetTypeUnknownAssembly("Hypereal.HyperealApi") != null;
		}
	}
}
