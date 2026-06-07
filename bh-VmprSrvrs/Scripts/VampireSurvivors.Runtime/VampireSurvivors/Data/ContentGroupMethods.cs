namespace VampireSurvivors.Data
{
	public static class ContentGroupMethods
	{
		public static bool IsLoaded(this ContentGroupType content)
		{
			return false;
		}

		public static bool IsDlcLoadedForContentGroup(ContentGroupType contentGroupType)
		{
			return false;
		}

		public static string GetLocalizedName(this ContentGroupType content)
		{
			return null;
		}

		public static DlcType? GetDlcTypeContentGroup(ContentGroupType contentGroupType)
		{
			return null;
		}

		public static string GetLocKeyForDlcContentGroup(ContentGroupType contentGroupType)
		{
			return null;
		}
	}
}
