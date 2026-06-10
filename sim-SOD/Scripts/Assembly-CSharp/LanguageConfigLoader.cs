using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LanguageConfigLoader : MonoBehaviour
{
	[Serializable]
	public class LocInput
	{
		public string languageCode;

		public string displayName;

		public int documentColumn;

		public SystemLanguage systemLanguage;

		[Tooltip("Display 'Mr' etc after the name")]
		public bool swapCitizenTitleOrder;

		public bool staticKillerMoniker;

		public string startText;

		[NonSerialized]
		public string path;

		[NonSerialized]
		public Dictionary<string, FileInfo> modOverrideFiles;

		public List<string> debugOverrideFiles;

		public bool useShortenedDays;

		public int shortenedDaysLength;
	}

	public bool loadedLanguageConfig;

	public List<LocInput> fileInputConfig;

	private static LanguageConfigLoader _instance;

	public static LanguageConfigLoader Instance => null;

	private void Awake()
	{
	}

	public void LoadLanguageConfig()
	{
	}
}
