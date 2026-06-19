using System.Text.RegularExpressions;

namespace Sentry.Internal
{
	internal static class PiiExtensions
	{
		internal const string RedactedText = "[Filtered]";

		private static readonly Regex AuthRegex = new Regex("(?i)\\b(https?://.*@.*)\\b", RegexOptions.Compiled);

		private static readonly Regex UserInfoMatcher = new Regex("^(?i)(https?://)(.*@)(.*)$", RegexOptions.Compiled);

		public static string RedactUrl(this string data)
		{
			if (string.IsNullOrWhiteSpace(data))
			{
				return data;
			}
			return AuthRegex.Replace(data, (Match match) => RedactAuth(match.Groups[1].Value));
		}

		private static string RedactAuth(string data)
		{
			Match match = UserInfoMatcher.Match(data);
			if (match != null && match.Success)
			{
				GroupCollection groups = match.Groups;
				if (groups != null && groups.Count == 4)
				{
					string text = (match.Groups[2].Value.Contains(":") ? "[Filtered]:[Filtered]@" : "[Filtered]@");
					return match.Groups[1].Value + text + match.Groups[3].Value;
				}
			}
			return data;
		}
	}
}
