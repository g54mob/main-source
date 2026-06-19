using QFSW.QC.Utilities;

namespace QFSW.QC
{
	public static class SuggestorUtilities
	{
		private const int MAX_EDIT_DISTANCE = 196608;

		public static bool IsCompatible(string prompt, string suggestion, SuggestorOptions options)
		{
			if (prompt.Length > suggestion.Length)
			{
				return false;
			}
			if (options.Fuzzy)
			{
				if (!options.CaseSensitive)
				{
					return suggestion.ContainsCaseInsensitive(prompt);
				}
				return suggestion.Contains(prompt);
			}
			return suggestion.StartsWith(prompt, !options.CaseSensitive, null);
		}

		public static bool IsCompatible(string prompt, string suggestion, OptimalStringAlignmentMultiQueryMatcher matcher, SuggestorOptions options)
		{
			if (options.AllowEmptyPromptParameterSuggestions && string.IsNullOrEmpty(prompt))
			{
				return true;
			}
			if (!options.Fuzzy)
			{
				return suggestion.StartsWith(prompt, !options.CaseSensitive, null);
			}
			return matcher.Match(suggestion, prompt, options.CaseSensitive) <= 196608;
		}
	}
}
