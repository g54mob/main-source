using System;
using System.Collections.Generic;
using LitJson;

namespace Gh.Tk
{
	[Serializable]
	public class VoiceOverPart
	{
		public static int NextGlobalOrder;

		public string type;

		public string language;

		public string origDirectorsComment;

		public string i18nHash;

		public string translationComment;

		public string voContentHash;

		public string alias;

		public string aiFallbackHash;

		public string prefix;

		public string text;

		public string previousChoice;

		public bool inUse;

		public bool hasAudioFile;

		public bool hasMarkersSetup;

		public float audioFileDurationInSeconds;

		public int globalOrder;

		[JsonIgnore]
		public string[] nextChoices;

		public List<string> supportedAILanguages;

		public VoiceOverPart()
		{
		}

		public VoiceOverPart(string text, VoiceOverType type, string language, string translationComment = null)
		{
		}

		public static string RemoveTrailingLineBreaks(string s)
		{
			return null;
		}

		public string GetLocalisedAudioId(string languageCode)
		{
			return null;
		}

		public string GetLocalisedAIFallbackHash(string languageCode)
		{
			return null;
		}
	}
}
