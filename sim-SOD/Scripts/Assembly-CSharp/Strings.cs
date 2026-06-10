using System.Collections.Generic;
using System.IO;
using NaughtyAttributes;
using UnityEngine;

public class Strings : MonoBehaviour
{
	public class DisplayString
	{
		public string displayStr;

		public string alternateStr;
	}

	public class RandomDisplayString
	{
		public string displayStr;

		public string alternateStr;

		public bool needsSuffixForShortName;
	}

	public enum Casing
	{
		asIs = 0,
		firstLetterCaptial = 1,
		pascalCase = 2,
		upperCase = 3,
		lowerCase = 4
	}

	public enum LinkSetting
	{
		automatic = 0,
		forceLinks = 1,
		forceNoLinks = 2
	}

	public class LinkData
	{
		public int id;

		public static int assignID;

		public Evidence evidence;

		public List<Evidence.DataKey> dataKeys;

		public List<int> inputCode;

		public string helpPage;

		public LinkData(Evidence newEvidence, List<Evidence.DataKey> overrideKeys)
		{
		}

		public LinkData(Telephone newTelephone = null)
		{
		}

		public LinkData(List<int> newInputCode = null)
		{
		}

		public LinkData(string newHelpPage)
		{
		}

		public void OnLink()
		{
		}
	}

	[Header("Setup")]
	public GameObject languageLoaderPrefab;

	public static bool textFilesLoaded;

	public static bool backupENGLoaded;

	public static LanguageConfigLoader.LocInput loadedLanguage;

	public static Dictionary<string, Dictionary<string, DisplayString>> stringTable;

	public static Dictionary<string, string> dictionaryPathnames;

	public static Dictionary<string, Dictionary<string, DisplayString>> stringTableENG;

	private static FileInfo templateFile;

	public static Dictionary<string, List<RandomDisplayString>> randomEntryLists;

	public static Dictionary<string, List<RandomDisplayString>> randomEntryListsENG;

	[Header("Localisation Output")]
	public List<string> localisationIgnoreFileList;

	public List<string> localisationIgnoreDirectoryList;

	[Tooltip("If the below string is present in the notes section then skip the line")]
	public bool useIgnoreFlagInNotes;

	[EnableIf("useIgnoreFlagInNotes")]
	public string ignoreFlag;

	[Range(0f, 5f)]
	[Tooltip("Add this many extra line breaks between entries in the output")]
	public int extraLineBreaks;

	[Tooltip("If two or more identical content strings are detected in english, write them to a single entry for output")]
	[Space(7f)]
	public bool condenseIdenticalEnglishContentIntoOneKey;

	[Tooltip("If true: Only output changes since this the below date...")]
	[Space(7f)]
	public bool onlyOuputChangesSince;

	[EnableIf("onlyOuputChangesSince")]
	public string outputSinceDate;

	[Tooltip("When adding entries that have been modified since a certain date, also check the content to confirm that it's been changed...")]
	[EnableIf("onlyOuputChangesSince")]
	public bool outputSinceContentConfirmation;

	[EnableIf("outputSinceContentConfirmation")]
	public List<string> oldFileComparisonPaths;

	[Tooltip("Be sure to output regardless of above if this is missing within an existing language")]
	public bool missingKeyCheck;

	[Header("Localisation Input")]
	public string localisationInputFile;

	public string inputDate;

	public string templateInputFile;

	[Tooltip("The last column should be ignored when checking for content")]
	public bool inputFeaturesLastColumnLineNumbers;

	[Tooltip("Write this if the localized text is missing. If detected, this will revert to the ENG string if english string")]
	public static string missingString;

	[Tooltip("These will be added to the character output")]
	public string customUsedCharacters;

	[Tooltip("ASCII characters will be added to the character output")]
	public bool includeDefaultAsciiCharacters;

	[Header("Localisation Corrections")]
	public string localisationCorrectionsInputFile;

	public string correctionsInputDate;

	public string correctionsLanguage;

	[Tooltip("If enabled, check the date on corrections before overwriting")]
	public bool checkCorrectionsDateBeforeOverwrite;

	[Tooltip("If true this will detect lines immediately below keys as gender variants of the keys with the following format: Main = M, 1 = Female, 2 = NB")]
	public bool useGenderVariationFormatting;

	[Tooltip("The column index in which the correct new translation is found")]
	public int columnContent;

	[Tooltip("If the corrections file features a file that doesn't exist in the existing text, create it")]
	public bool createMissingFiles;

	[Tooltip("If the corrections file features a key that doesn't exist in the existing text, create it")]
	public bool createMissingKey;

	[Header("Debug")]
	public string findBlock;

	private Dictionary<object, LinkData> linkDictionary;

	private Dictionary<Evidence, List<LinkData>> evidenceLinkDictionary;

	public Dictionary<int, LinkData> linkIDReference;

	private static Strings _instance;

	public static Strings Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void LoadTextFiles()
	{
	}

	public static void LoadLanguageFileToGame(string fileName, string path, bool loadAsENGBackup = false, bool overwriteEntries = false)
	{
	}

	public static void ParseLine(string input, out string key, out string notes, out string display, out string alt, out int frequency, out bool suffix, out string misc, bool useFieldQuotations = true)
	{
		key = null;
		notes = null;
		display = null;
		alt = null;
		frequency = default(int);
		suffix = default(bool);
		misc = null;
	}

	private static void LoadIntoDictionary(string fileName, int lineNo, string key, string display, string alternate, int frequency, bool suffix, bool overwrite = false)
	{
	}

	private static void LoadIntoDictionaryENG(string fileName, int lineNo, string key, string display, string alternate, int frequency, bool suffix, bool overwrite = false)
	{
	}

	public static string Get(string dictionary, string key, Casing casing = Casing.asIs, bool getAlternate = false, bool forceNoWrite = false, bool useGenderReference = false, Human genderReference = null)
	{
		return null;
	}

	public static string GetENG(string dictionary, string key, bool getAlternate = false)
	{
		return null;
	}

	public static string GetLineFromFile(string dictionary, int lineNumber)
	{
		return null;
	}

	public static string ApplyCasing(string input, Casing casing = Casing.asIs)
	{
		return null;
	}

	public static void WriteToDictionary(string dictionaryName, string key, string notes, string display, string alternate = "", int frequency = 0, bool requiresSuffix = false, string misc = "")
	{
	}

	public static string GetRandom(string dictionary, out bool needsSuffixForShortName, out string alternate, string useCustomSeed = "")
	{
		needsSuffixForShortName = default(bool);
		alternate = null;
		return null;
	}

	public static string GetRandom(string dictionary, string alliterationStr, int alliterationWeight, out bool needsSuffixForShortName, out string alternate, string useCustomSeed = "")
	{
		needsSuffixForShortName = default(bool);
		alternate = null;
		return null;
	}

	public static string[] CleanSplit(string input, char del, bool trimElements, bool removeEmpty = true)
	{
		return null;
	}

	public static string[] CleanSplit(string input, string[] del, bool trimElements)
	{
		return null;
	}

	public static string ConvertLineBreaksToSaveSafe(string input)
	{
		return null;
	}

	public static string ConvertLineBreaksToDisplay(string input)
	{
		return null;
	}

	public static string GetTextForComponent(string msgID, object obj, Human from = null, Human to = null, string lineBreaks = "\n", bool skipFirstBlock = false, object additionalObject = null, LinkSetting linkSetting = LinkSetting.automatic, List<Evidence.DataKey> dataKeys = null)
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void OutputTextForLoc()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ImportNonEnglish()
	{
	}

	public static Human GetVmailSender(StateSaveData.MessageThreadSave msgThread, int msgIndex, out string nameString)
	{
		nameString = null;
		return null;
	}

	public static bool GetSenderKnown(StateSaveData.MessageThreadSave msgThread, int msgIndex)
	{
		return false;
	}

	public static Human GetVmailReciever(StateSaveData.MessageThreadSave msgThread, int msgIndex, out string nameString)
	{
		nameString = null;
		return null;
	}

	public static string ComposeText(string input, object baseObject, LinkSetting linkSetting = LinkSetting.automatic, List<Evidence.DataKey> evidenceKeys = null, object additionalObject = null, bool forceKnownCitizenGender = false)
	{
		return null;
	}

	public static string ScopeParser(string input, DDSScope baseScope, object baseObject, LinkSetting linkSetting = LinkSetting.automatic, List<Evidence.DataKey> evidenceKeys = null, object additionalObject = null, bool knowCitizenGender = false)
	{
		return null;
	}

	public static DDSScope GetContainedScope(DDSScope baseScope, DDSScope currentScope, string newScope, object inputObject, out object outputObject, object additionalObject)
	{
		outputObject = null;
		return null;
	}

	public static object GetScopeObject(DDSScope baseScope, object inputObject, string withinScope, string newType, List<Evidence.DataKey> evidenceKeys = null, object additionalObject = null)
	{
		return null;
	}

	public static string GetContainedValue(object baseObject, string withinScope, string newValue, object inputObject, Evidence baseEvidence, LinkSetting linkSetting = LinkSetting.automatic, List<Evidence.DataKey> evidenceKeys = null, object additionalObject = null, bool knowCitizenGender = false)
	{
		return null;
	}

	public static MurderController.Murder GetPreviousMurder(float specificTime)
	{
		return null;
	}

	public static MurderController.Murder GetNextMurder(float specificTime)
	{
		return null;
	}

	public static Evidence GetEvidenceFromBaseScope(object baseObject)
	{
		return null;
	}

	public static LinkData AddOrGetLink(Evidence newEvidence, List<Evidence.DataKey> overrideKeys = null)
	{
		return null;
	}

	public static LinkData AddOrGetLink(Telephone newTelephone)
	{
		return null;
	}

	public static LinkData AddOrGetLink(List<int> newInputCode)
	{
		return null;
	}

	public static string GetMainTextFromInteractable(Interactable interactable, LinkSetting linkSetting = LinkSetting.automatic)
	{
		return null;
	}

	public static string FilterInputtedText(string input, bool useCensor = true, int maxCharacters = 100)
	{
		return null;
	}

	public static string RemoveCharacters(string input, bool removeSpecialCharacters, bool removeNumbers, bool removeDots, bool removeSpaces)
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void FindBlockInMessages()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void OutputAllCharacters()
	{
	}

	private bool CheckForNotLatin(char c)
	{
		return false;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ImportCorrections()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void OutputSerializedLanguageConfig()
	{
	}
}
