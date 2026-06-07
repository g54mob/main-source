using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class VoiceOverHelper : SingletonMonoBehaviour<VoiceOverHelper>
	{
		[SerializeField]
		private VoiceOverPart[] _database;

		private Dictionary<string, VoiceOverPart> _dict;

		private const string _VoScriptFolder = "Voice Over";

		internal const char _endOfSentenceMarker = '\u200b';

		internal const string _escapedDot = "GH_ESCAPED_DOT";

		private const string _commentPrefix = "_";

		private const string _talkStartTag = "[talk]";

		private const string _talkEndTag = "[/talk]";

		public const string DEFAULT_VOICE_LANG = "en";

		public new static VoiceOverHelper Instance => null;

		private void Start()
		{
		}

		private void EnsureDictionary()
		{
		}

		public VoiceOverPart GetVoPart(string key)
		{
			return null;
		}

		public bool IsAiFallbackHash(string key)
		{
			return false;
		}

		public static string RemoveLanguageSuffix(string key)
		{
			return null;
		}

		public void ParseVoDatabase()
		{
		}

		private void SaveVoDatabase()
		{
		}

		public (string, bool) GetIdForVoContent(string content, string type, string languageCode)
		{
			return default((string, bool));
		}

		public (string, bool) GetVoiceOverId(VoiceOverPart vop, string languageCode)
		{
			return default((string, bool));
		}

		public static string RemoveSceneInstructions(string content)
		{
			return null;
		}

		public static string GetVoHash(string text, string type, string languageCode)
		{
			return null;
		}

		public static (string, string[], string, bool) ProcessIfTextAndInsertEndOfSentenceMarkers(string referenceContent, string type, string displayText = null, bool lookUpAliases = false)
		{
			return default((string, string[], string, bool));
		}

		public static string PrepareVoText(string text)
		{
			return null;
		}

		public static string UnPrepareVoText(string text)
		{
			return null;
		}

		public string ConvertTextToAiSpeechContent(string content)
		{
			return null;
		}

		public void CreateMarkerHelperCsvFile()
		{
		}

		public void InitForVOGeneration(string language)
		{
		}
	}
}
