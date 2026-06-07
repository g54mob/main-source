using System.Collections.Generic;

namespace FractureField
{
	public static class ChangelogParser
	{
		public class ChangelogEntry
		{
			public string Version { get; set; }

			public string Date { get; set; }

			public string Content { get; set; }

			public bool IsMajor { get; set; }

			public bool IsMinor { get; set; }

			public bool IsPatch { get; set; }
		}

		public class FormattedChangelogEntry
		{
			public string Title { get; set; }

			public string Body { get; set; }
		}

		public static ChangelogEntry ParseChangelog(string markdown, bool skipHidden = false)
		{
			return null;
		}

		public static string FormatTitleForTMP(ChangelogEntry entry)
		{
			return null;
		}

		public static string FormatContentForTMP(ChangelogEntry entry)
		{
			return null;
		}

		private static string FormatChangelogLine(string line)
		{
			return null;
		}

		public static List<FormattedChangelogEntry> GetAllChangelogs(int limit = 0)
		{
			return null;
		}

		public static List<ChangelogEntry> ParseAllChangelogs(string markdown, int limit = 0, bool skipHidden = false)
		{
			return null;
		}
	}
}
