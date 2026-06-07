using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DevConsole;
using Steamworks;
using TinyJson;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LanguageWindow : MonoBehaviour
{
	public class LocalizorData
	{
		public int id;

		public int version;

		public string name;

		public string url;

		public string versionUrl;

		public float approved;

		public float suggested;

		public LocalizorData(int id, string name, string url, string versionUrl, int version, float approved, float translated)
		{
			this.id = id;
			this.name = name;
			this.url = url;
			this.approved = approved;
			suggested = translated;
			this.version = version;
			this.versionUrl = versionUrl;
		}
	}

	public const string TranslateSite = "https://translate.Coredumping.com";

	public static LanguageWindow Instance;

	public GUIWindow Window;

	public LocalizorButton LocalizorPrefab;

	public LanguageButton LanguagePrefab;

	public RectTransform LanguageList;

	public RectTransform LocalizorList;

	public GameObject LocalizorButton;

	public Scrollbar Scroll;

	public Text LoadingLabel;

	public Text MainMenuLabel;

	public Text DownloadHeader;

	public Toggle LocalizationFallback;

	public Image MainMenuFlag;

	public Text[] ImmediateEffect;

	private string[] _immediateLoc;

	private bool _first = true;

	[NonSerialized]
	public Dictionary<Localization.Translation, LanguageButton> Languages = new Dictionary<Localization.Translation, LanguageButton>();

	private void Awake()
	{
		Instance = this;
		_immediateLoc = new string[ImmediateEffect.Length];
		for (int i = 0; i < ImmediateEffect.Length; i++)
		{
			_immediateLoc[i] = ImmediateEffect[i].text;
		}
		DownloadHeader.text = "https://translate.Coredumping.com".Substring("https://translate.Coredumping.com".IndexOf("://") + 3);
		Refresh();
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void LocFallbackChange()
	{
		Options.LocalizationFallback = LocalizationFallback.isOn;
	}

	public void ShowLocalizor()
	{
		if (SteamManager.Initialized && SteamUtils.IsOverlayEnabled())
		{
			SteamFriends.ActivateGameOverlayToWebPage("https://translate.Coredumping.com");
		}
		else
		{
			Application.OpenURL("https://translate.Coredumping.com");
		}
	}

	public void Show()
	{
		Window.Show();
		LocalizationFallback.isOn = Options.LocalizationFallback;
		ShowLang(Localization.CurrentTranslation);
		if (_first)
		{
			_first = false;
			FetchLocalizor();
		}
	}

	public void ShowLang(Localization.Translation tr)
	{
		LanguageButton value;
		if (Languages.TryGetValue(tr, out value))
		{
			RectTransform component = value.GetComponent<RectTransform>();
			RectTransform component2 = component.parent.GetComponent<RectTransform>();
			LayoutRebuilder.ForceRebuildLayoutImmediate(component2);
			float num = 0f - component.anchoredPosition.y - component2.anchoredPosition.y;
			RectTransform component3 = component2.parent.GetComponent<RectTransform>();
			if (num < 0f || num > component3.rect.height)
			{
				Scroll.value = 1f + component.anchoredPosition.y / (component2.rect.height - component3.rect.height);
			}
		}
	}

	public void SelectLanguage(Localization.Translation language)
	{
		Localization.SetTranslation(language);
		Options.SaveToFile();
		foreach (KeyValuePair<Localization.Translation, LanguageButton> language2 in Languages)
		{
			language2.Value.Highlight(language2.Value.Translation == language);
		}
		ShowLang(language);
	}

	private IEnumerator FetchLocalizorData()
	{
		UnityWebRequest gameLangs = UnityWebRequest.Get("https://translate.Coredumping.com/api.php?method=languages");
		gameLangs.SetRequestHeader("User-Agent", "Swinc User Agent");
		yield return gameLangs.SendWebRequest();
		if (gameLangs.error == null)
		{
			List<Dictionary<string, string>> list = gameLangs.downloadHandler.text.FromJson<List<Dictionary<string, string>>>();
			Dictionary<int, LocalizorData> dictionary = new Dictionary<int, LocalizorData>();
			foreach (Dictionary<string, string> item in list)
			{
				int num = item["id"].ConvertToInt("id");
				dictionary[num] = new LocalizorData(num, item["name"], "https://translate.Coredumping.com/api.php?method=translation&id=" + num, "https://translate.Coredumping.com/api.php?method=version&id=" + num, item["version"].ConvertToIntDef(0), item["approved"].ConvertToFloatDef(0f), item["translated"].ConvertToFloatDef(0f));
			}
			if (dictionary.Count > 0)
			{
				LoadingLabel.gameObject.SetActive(false);
				{
					foreach (LocalizorData value in dictionary.Values)
					{
						LocalizorButton localizorButton = UnityEngine.Object.Instantiate(LocalizorPrefab);
						localizorButton.transform.SetParent(LocalizorList, false);
						localizorButton.Init(value.name, value.name, value.url, value.id, value.versionUrl, value.version, value.approved, value.suggested);
					}
					yield break;
				}
			}
			LoadingLabel.gameObject.SetActive(false);
		}
		else
		{
			LoadingLabel.text = "Error".Loc();
			DevConsole.Console.LogError("Failed downloading localizor data:\n" + gameLangs.error);
		}
	}

	public void FetchLocalizor()
	{
		LocalizorButton.SetActive(false);
		LoadingLabel.gameObject.SetActive(true);
		StartCoroutine(FetchLocalizorData());
	}

	public void RefreshMainMenu()
	{
		for (int i = 0; i < ImmediateEffect.Length; i++)
		{
			if (ImmediateEffect[i] != null)
			{
				TextLoc component = ImmediateEffect[i].GetComponent<TextLoc>();
				if (component != null)
				{
					component.enabled = false;
					UnityEngine.Object.Destroy(component);
				}
				ImmediateEffect[i].text = _immediateLoc[i].LocTry();
			}
		}
		Localization.Translation translation = Localization.CurrentTranslation ?? Localization.English;
		MainMenuLabel.text = translation.ItemTitle;
		MainMenuFlag.sprite = ObjectDatabase.Instance.TryGetFlag(translation.ItemTitle, translation.MetaData.GetCustomData("Flag"));
	}

	public void Refresh()
	{
		HashSet<Localization.Translation> hashSet = Languages.Keys.ToHashSet();
		foreach (Localization.Translation item in from x in Localization.GetLanguages()
			orderby x.ItemTitle
			select x)
		{
			if (!hashSet.Remove(item))
			{
				LanguageButton languageButton = UnityEngine.Object.Instantiate(LanguagePrefab);
				languageButton.transform.SetParent(LanguageList, false);
				languageButton.Init(item);
				Languages[item] = languageButton;
			}
		}
		foreach (Localization.Translation item2 in hashSet)
		{
			UnityEngine.Object.Destroy(Languages[item2].gameObject);
			Languages.Remove(item2);
		}
		RefreshMainMenu();
	}
}
