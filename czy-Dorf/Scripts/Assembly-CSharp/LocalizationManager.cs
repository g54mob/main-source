using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using Dorfromantik;
using RTLTMPro;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class LocalizationManager : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<Language, string> _003C_003E9__43_0;

		internal string _003CSetup_003Eb__43_0(Language language)
		{
			return LanguageNameByLanguage[language];
		}
	}

	private sealed class _003CLoadJsonTextOnAndroid_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LocalizationManager _003C_003E4__this;

		public string fileName;

		private UnityWebRequest _003Cwww_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CLoadJsonTextOnAndroid_003Ed__51(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			LocalizationManager localizationManager = _003C_003E4__this;
			string json;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				localizationManager.localizedText = new Dictionary<string, string>();
				string text = Path.Combine(Application.streamingAssetsPath, fileName);
				if (Application.platform == RuntimePlatform.Android)
				{
					_003Cwww_003E5__2 = UnityWebRequest.Get(text);
					_003C_003E2__current = _003Cwww_003E5__2.SendWebRequest();
					_003C_003E1__state = 1;
					return true;
				}
				json = File.ReadAllText(text);
				break;
			}
			case 1:
				_003C_003E1__state = -1;
				json = _003Cwww_003E5__2.downloadHandler.text;
				_003Cwww_003E5__2 = null;
				break;
			}
			LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(json);
			localizationManager.SetupLoadedLanguageData(loadedData);
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	public static LocalizationManager Instance;

	private Language _003CLanguage_003Ek__BackingField;

	private float _003CFontSizeModifier_003Ek__BackingField;

	private int fontIndex;

	[SerializeField]
	private bool onlyUppercase;

	[SerializeField]
	[FormerlySerializedAs("primaryFonts")]
	private TMP_FontAsset[] semiBoldFonts;

	[SerializeField]
	private TMP_FontAsset[] boldFonts;

	[FormerlySerializedAs("highlightFonts")]
	[SerializeField]
	private TMP_FontAsset[] extraBoldFonts;

	[SerializeField]
	[FormerlySerializedAs("headerFonts")]
	private TMP_FontAsset[] header1Fonts;

	[SerializeField]
	private TMP_FontAsset[] header2Fonts;

	private Dictionary<string, string> localizedText;

	private Dictionary<string, string> fallbackText;

	private bool isInitialized;

	private string missingTextString = "";

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private LocalizationData debugLocalizationData;

	private List<Language> _003CAvailableLanguages_003Ek__BackingField;

	private Dictionary<Language, SpecificLanguageReplacer> specificLanguageReplacers = new Dictionary<Language, SpecificLanguageReplacer>();

	private SpecificLanguageReplacer genericSingularPluralReplacer;

	public static readonly Dictionary<Language, string> LanguageNameByLanguage = new Dictionary<Language, string>
	{
		{
			Language.ChineseSimplified,
			"简体中文"
		},
		{
			Language.ChineseTraditional,
			"繁體中文"
		},
		{
			Language.Czech,
			"čeština"
		},
		{
			Language.Dutch,
			"Nederlands"
		},
		{
			Language.English,
			"American English"
		},
		{
			Language.BritishEnglish,
			"British English"
		},
		{
			Language.CanadianFrench,
			"Français Canadien"
		},
		{
			Language.Estonian,
			"Eesti"
		},
		{
			Language.French,
			"Français"
		},
		{
			Language.German,
			"Deutsch"
		},
		{
			Language.Hungarian,
			"Magyar"
		},
		{
			Language.Italian,
			"Italiano"
		},
		{
			Language.Japanese,
			"日本語"
		},
		{
			Language.Korean,
			"한국어"
		},
		{
			Language.Lithuanian,
			"Lietuvių kalba"
		},
		{
			Language.Norwegian,
			"Norsk"
		},
		{
			Language.Polish,
			"Polski"
		},
		{
			Language.Portuguese,
			"Português"
		},
		{
			Language.BrazilianPortuguese,
			"Português-Brasil"
		},
		{
			Language.Russian,
			"Русский"
		},
		{
			Language.Spanish,
			"Español"
		},
		{
			Language.SpanishLatinoamerica,
			"Español-Latinoamérica"
		},
		{
			Language.Swedish,
			"Svenska"
		},
		{
			Language.Turkish,
			"Türkçe"
		},
		{
			Language.Ukrainian,
			"Українська"
		}
	};

	public readonly Dictionary<Language, string> cultureInfoByLanguage = new Dictionary<Language, string>
	{
		{
			Language.ChineseSimplified,
			"zh-CN"
		},
		{
			Language.ChineseTraditional,
			"zh-TW"
		},
		{
			Language.Czech,
			"cs-CZ"
		},
		{
			Language.Dutch,
			"nl-NL"
		},
		{
			Language.English,
			"en-US"
		},
		{
			Language.BritishEnglish,
			"en-GB"
		},
		{
			Language.CanadianFrench,
			"fr-CA"
		},
		{
			Language.Estonian,
			"et-EE"
		},
		{
			Language.French,
			"fr-FR"
		},
		{
			Language.German,
			"de-DE"
		},
		{
			Language.Hungarian,
			"hu-HU"
		},
		{
			Language.Italian,
			"it-IT"
		},
		{
			Language.Japanese,
			"ja-JP"
		},
		{
			Language.Korean,
			"ko-KR"
		},
		{
			Language.Lithuanian,
			"lt-LT"
		},
		{
			Language.Norwegian,
			"nn-NO"
		},
		{
			Language.Polish,
			"pl-PL"
		},
		{
			Language.Portuguese,
			"pt-PT"
		},
		{
			Language.BrazilianPortuguese,
			"pt-BR"
		},
		{
			Language.Russian,
			"ru-RU"
		},
		{
			Language.Spanish,
			"es-ES"
		},
		{
			Language.SpanishLatinoamerica,
			"es-AR"
		},
		{
			Language.Swedish,
			"sv-SE"
		},
		{
			Language.Turkish,
			"tr-TR"
		},
		{
			Language.Ukrainian,
			"uk-UA"
		},
		{
			Language.Arabic,
			"ar-SA"
		}
	};

	public Language Language
	{
		get
		{
			return _003CLanguage_003Ek__BackingField;
		}
		private set
		{
			_003CLanguage_003Ek__BackingField = value;
		}
	}

	public float FontSizeModifier
	{
		get
		{
			return _003CFontSizeModifier_003Ek__BackingField;
		}
		private set
		{
			_003CFontSizeModifier_003Ek__BackingField = value;
		}
	}

	public bool UseRomanNumerals
	{
		get
		{
			if (fontIndex != 1)
			{
				return fontIndex != 3;
			}
			return false;
		}
	}

	public List<Language> AvailableLanguages
	{
		get
		{
			return _003CAvailableLanguages_003Ek__BackingField;
		}
		private set
		{
			_003CAvailableLanguages_003Ek__BackingField = value;
		}
	}

	public bool Initialized => isInitialized;

	public bool IsCurrentLanguageRightToLeft => Language == Language.Arabic;

	public CultureInfo CultureInfo => new CultureInfo(cultureInfoByLanguage[Language]);

	public event Action OnLanguageChanged;

	public TMP_FontAsset GetFont(LocalizedFontStyle style)
	{
		return style switch
		{
			LocalizedFontStyle.SemiBold => semiBoldFonts[fontIndex], 
			LocalizedFontStyle.Bold => boldFonts[fontIndex], 
			LocalizedFontStyle.ExtraBold => extraBoldFonts[fontIndex], 
			LocalizedFontStyle.H1 => header1Fonts[fontIndex], 
			LocalizedFontStyle.H2 => header2Fonts[fontIndex], 
			_ => semiBoldFonts[fontIndex], 
		};
	}

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			Setup();
		}
		else if (Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Setup()
	{
		Debug.Log("Setup Localization Manager");
		FastStringBuilder fastStringBuilder = new FastStringBuilder(2048);
		RTLSupport.FixRTL("ا\u064eل\u0652ع\u064eر\u064eب\u0650ي\u064e\u0651ة", fastStringBuilder, farsi: false, fixTextTags: true, preserveNumbers: true);
		LanguageNameByLanguage.Add(Language.Arabic, string.Format("<font=\"{0}\">{1}", "NotoSansArabic-ExtraBold SDF", fastStringBuilder));
		settingsRouter.OnLanguageChanged += ChangeLanguage;
		AvailableLanguages = new List<Language>();
		foreach (Language value in Enum.GetValues(typeof(Language)))
		{
			if (File.Exists(GetLocalizationFilePath(value)))
			{
				AvailableLanguages.Add(value);
				if (!LanguageNameByLanguage.ContainsKey(value))
				{
					Debug.LogError($"no language name defined for {value}");
				}
			}
		}
		AvailableLanguages = Enumerable.ToList(Enumerable.OrderBy(AvailableLanguages, (Language key) => LanguageNameByLanguage[key]));
		Language = (Language)PlayerPrefsAccessor.GetInt("Language", 0);
		if (!AvailableLanguages.Contains(Language))
		{
			Language = settingsRouter.defaultSettings.defaultLanguage;
		}
		fallbackText = LoadLocalizedText(Language.English);
		localizedText = LoadLocalizedText(Language);
		this.OnLanguageChanged?.Invoke();
		specificLanguageReplacers.Add(Language.Russian, base.gameObject.AddComponent<SpecificReplacer_Russian>());
		specificLanguageReplacers.Add(Language.Polish, base.gameObject.AddComponent<SpecificReplacer_Polish>());
		genericSingularPluralReplacer = base.gameObject.AddComponent<GenericSingularPluralReplacer>();
		Debug.Log($"Finished setting up localization Manager with {AvailableLanguages.Count} languages");
	}

	private string GetLocalizationFilePath(Language language)
	{
		return Path.Combine(Application.streamingAssetsPath, GetLocalizationFileName(language));
	}

	private string GetLocalizationFileName(Language language)
	{
		return $"localizedText_{language}.json";
	}

	public void ChangeLanguage(Language newLanguage)
	{
		Language = newLanguage;
		PlayerPrefsAccessor.SetInt("Language", (int)Language);
		localizedText = LoadLocalizedText(newLanguage);
		this.OnLanguageChanged?.Invoke();
	}

	public string GetLocalizedValue(string key, bool useFallbackText = false)
	{
		string text = missingTextString;
		if (string.IsNullOrWhiteSpace(key))
		{
			return "";
		}
		if (localizedText.ContainsKey(key))
		{
			text = localizedText[key];
		}
		else
		{
			Debug.LogWarning("no entry for " + key + " in " + Language);
		}
		if (useFallbackText && string.IsNullOrWhiteSpace(text) && fallbackText.ContainsKey(key))
		{
			text = fallbackText[key];
		}
		return text;
	}

	private Dictionary<string, string> LoadLocalizedText(Language languageToLoad)
	{
		LocalizationData loadedData = JsonLoader.LoadJsonFromDataLocation<LocalizationData>(GetLocalizationFileName(languageToLoad), DataLocation.StreamingAssetsPath);
		return SetupLoadedLanguageData(loadedData);
	}

	private Dictionary<string, string> SetupLoadedLanguageData(LocalizationData loadedData)
	{
		debugLocalizationData = loadedData;
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (loadedData == null)
		{
			return dictionary;
		}
		LocalizationItem[] items = loadedData.items;
		foreach (LocalizationItem localizationItem in items)
		{
			LocalizationItem localizationItem2 = localizationItem;
			if (localizationItem2.key.StartsWith("element") || localizationItem2.key.StartsWith("group") || localizationItem2.key.StartsWith("countable"))
			{
				string[] array = localizationItem2.value.Split('/');
				string key = localizationItem2.key;
				string key2 = localizationItem2.key.Replace("_", "s_");
				AddLocalizedTextEntry(dictionary, key, array[0].TrimEnd());
				if (array.Length > 1)
				{
					AddLocalizedTextEntry(dictionary, key2, array[1].TrimStart().TrimEnd());
				}
				else
				{
					AddLocalizedTextEntry(dictionary, key2, array[0].TrimEnd());
				}
			}
			else
			{
				AddLocalizedTextEntry(dictionary, localizationItem.key, localizationItem.value);
			}
		}
		Debug.Log($"language {Language} loaded");
		fontIndex = loadedData.font_index;
		FontSizeModifier = loadedData.font_size_modifier;
		isInitialized = true;
		return dictionary;
	}

	private void AddLocalizedTextEntry(Dictionary<string, string> newLocalizedText, string key, string value)
	{
		if (IsCurrentLanguageRightToLeft)
		{
			FastStringBuilder fastStringBuilder = new FastStringBuilder(2048);
			RTLSupport.FixRTL(value, fastStringBuilder, farsi: false, fixTextTags: true, preserveNumbers: true);
			newLocalizedText.Add(key, fastStringBuilder.ToString());
		}
		else
		{
			newLocalizedText.Add(key, value);
		}
	}

	private IEnumerator LoadJsonTextOnAndroid(string fileName)
	{
		return new _003CLoadJsonTextOnAndroid_003Ed__51(0)
		{
			_003C_003E4__this = this,
			fileName = fileName
		};
	}

	public string ApplySpecificLanguageNumberingGrammar(string inputString, int number)
	{
		if (specificLanguageReplacers.ContainsKey(Language))
		{
			return specificLanguageReplacers[Language].ApplySpecificNumberingGrammar(inputString, number);
		}
		return genericSingularPluralReplacer.ApplySpecificNumberingGrammar(inputString, number);
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
		settingsRouter.OnLanguageChanged -= ChangeLanguage;
	}

	public void UpdateTextMesh(TMP_Text textMesh, LocalizedFontStyle style, string targetText, HorizontalAlignmentOptions originalHorizontalAlignment = HorizontalAlignmentOptions.Center, float originalFontSize = -1f)
	{
		textMesh.font = GetFont(style);
		textMesh.isRightToLeftText = IsCurrentLanguageRightToLeft;
		if (originalFontSize > 0f)
		{
			textMesh.fontSize = originalFontSize * FontSizeModifier;
		}
		if (originalHorizontalAlignment == HorizontalAlignmentOptions.Left)
		{
			textMesh.horizontalAlignment = (IsCurrentLanguageRightToLeft ? HorizontalAlignmentOptions.Right : originalHorizontalAlignment);
		}
		if (targetText != null)
		{
			if (IsCurrentLanguageRightToLeft)
			{
				targetText = StringUtility.Reverse(targetText);
			}
			textMesh.text = targetText;
		}
	}
}
