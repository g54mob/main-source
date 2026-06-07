namespace I2.Loc
{
	public static class LocUtl
	{
		public const string kGenLoc = "Generated";

		public static void SetTerm(this LanguageSourceAsset asset, string key, string english, bool save = true)
		{
		}

		public static void SetTerm(this LanguageSourceAsset asset, string key, string str, int idx, bool save = true)
		{
		}

		public static void ClearTerm(this LanguageSourceAsset asset, string key, bool save = true)
		{
		}

		public static void SetParameterValue(this LocalizationParamsManager mgr, string key, int value)
		{
		}

		public static LocalizationParamsManager.ParamValue CreateParam(string name, string val)
		{
			return default(LocalizationParamsManager.ParamValue);
		}

		public static void CycleLanguage(int amt)
		{
		}
	}
}
