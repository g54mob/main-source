namespace Gh.Tk
{
	public static class I18nExtensionMethods
	{
		public const string KeyPreFix = "<l[";

		public const string KeyPostFix = "]l>";

		private const string _replacementPreFix = "<r[";

		private const string _replacementPostFix = "]r>";

		private const string _replacementSeparator = "§$§";

		private const string _storyIdPreFix = "<s[";

		private const string _storyIdPostFix = "]s>";

		public static string ToLocalizedKeyInternal(this string content)
		{
			return null;
		}

		public static string ToLocalizedKeyWithComment(this string content, string comment, params string[] payload)
		{
			return null;
		}

		public static string ToLocalizedKey(this string content, params string[] payload)
		{
			return null;
		}

		public static string ToLocalizedKeyWithContentOverrideForHash(this string content, string contentOverrideForHash, params string[] payload)
		{
			return null;
		}

		public static string ToLocalizedKeyWithStoryId(this string content, int storyId, params string[] payLoad)
		{
			return null;
		}

		private static string ToLocalizedKeyWithStoryId(this string content, string contentOverrideForHash, int storyId, params string[] payLoad)
		{
			return null;
		}

		private static string AddPayLoad(string content, params string[] payLoad)
		{
			return null;
		}

		public static string ToDisplayText(this string localizedKey, bool useFallbackLanguage = false, string gender = "male", bool useAudioLanguage = false)
		{
			return null;
		}

		public static string AddReplacementInstruction(this string descriptionKey, string var, string contentKey)
		{
			return null;
		}

		public static string AddStoryId(this string descriptionKey, int storyId)
		{
			return null;
		}
	}
}
