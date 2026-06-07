using System;

namespace Gh.Tk
{
	[Serializable]
	public class I18nMainDbEntry
	{
		public string contentHash;

		public string content;

		public string comments;

		public bool ignoreForTranslation;

		public string translationType;

		public bool isUsed;

		public string context;

		public int reviewCount;

		public int globalOrder;

		public string translationComment;

		public bool wasUsedInPrevReleases;

		public string lastSeen;

		public bool alwaysIncludeForTranslation;

		public bool ignoreInDemo;

		public string alias;

		public I18nMainDbEntry()
		{
		}

		public I18nMainDbEntry(string contentHash, string content, string comments, bool ignoreForTranslation, string translationType, bool isUsed, string context, int reviewCount, int globalOrder, string translationComment, bool wasUsedInPrevReleases = false, string lastSeen = null, bool alwaysIncludeForTranslation = false, bool ignoreInDemo = false, string alias = null)
		{
		}
	}
}
