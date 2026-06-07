using System;

namespace VRTK
{
	public static class VRTK_Defines
	{
		public static readonly Version CurrentVersion;

		public static readonly Version[] PreviousVersions;

		public const string VersionScriptingDefineSymbolPrefix = "VRTK_VERSION_";

		public const string VersionScriptingDefineSymbolSuffix = "_OR_NEWER";

		public static string CurrentExactVersionScriptingDefineSymbol { get; private set; }

		static VRTK_Defines()
		{
			CurrentVersion = new Version(3, 3, 0);
			PreviousVersions = new Version[3]
			{
				new Version(3, 1, 0),
				new Version(3, 2, 0),
				new Version(3, 2, 1)
			};
			CurrentExactVersionScriptingDefineSymbol = ExactVersionSymbol(CurrentVersion);
		}

		private static string ExactVersionSymbol(Version version)
		{
			return string.Format("{0}{1}", "VRTK_VERSION_", version.ToString().Replace(".", "_"));
		}

		private static string AtLeastVersionSymbol(Version version)
		{
			return string.Format("{0}{1}", ExactVersionSymbol(version), "_OR_NEWER");
		}
	}
}
