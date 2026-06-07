namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public static class Diagnostics
	{
		public static readonly Error kFeatureNotSupported;

		public const string kCreateNativeObjectError = "Failed to create native object.";

		public static VBException PluginNotConfiguredException(string name = "Native")
		{
			return null;
		}

		public static void LogNotSupportedInEditor(string featureName = "This")
		{
		}

		public static void LogNotSupported(string featureName = "This")
		{
		}
	}
}
