namespace Factory.FieldData
{
	public static class FactoryPrefs
	{
		public static readonly string FactoryPrefsKeyMap;

		public static readonly string FactoryPrefsKeyContext;

		public static readonly string FactoryPrefsKeyFactoryContextFc;

		private static readonly bool DebugMode;

		private static bool isProhibitFactorySave;

		public static bool IsProhibitFactorySave
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool IsHasFactoryResumeData => false;

		public static bool SaveFactory(bool withSave = true, bool withLocal = false)
		{
			return false;
		}

		public static string LoadMapDataJson()
		{
			return null;
		}

		public static string LoadMapContextJson()
		{
			return null;
		}

		public static string LoadFcJson()
		{
			return null;
		}
	}
}
