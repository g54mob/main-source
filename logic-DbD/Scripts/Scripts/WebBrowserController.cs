using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WebBrowserController : MonoBehaviour
{
	public const int PERMISSIONS_UNLOCKED_LEVEL = 5;

	public const string WELCOME_SITE = "welcome";

	public const string SCROLL_PATH = "Website/Websites UI/Scrollbar";

	public const string NO_PERMISSIONS_SITE = "denied";

	public const string MISSING_SITE = "missing";

	private const int TRANSPARENT_ICON_VALUE = 80;

	private HashSet<string> SPECIAL_SITES = new HashSet<string> { "welcome", "denied", "missing" };

	private HashSet<string> GENERATED_SITES = new HashSet<string> { "mmdb.com/profile/", "payup.com/pay/", "guildsofnewhampshire.net/guild/", "guildsofnewhampshire.net/forum/login/", "guildsofnewhampshire.net/forum/", "legendsofnewhampshire.com/player/", "lzairlines.com/checkin/" };

	[SerializeField]
	private TMP_InputField searchInput;

	[SerializeField]
	private Button searchButton;

	[SerializeField]
	private Transform websiteContainer;

	[SerializeField]
	private Button forwardButton;

	[SerializeField]
	private Button backButton;

	[SerializeField]
	private AudioClip searchAudio;

	[SerializeField]
	private AudioClip backAudio;

	[SerializeField]
	private AudioClip frontAudio;

	private PlayerInput panelInput;

	private GameObject currentSite;

	private WebHistory history;

	private AudioSource audioPlayer;

	private void Awake()
	{
		audioPlayer = GetComponent<AudioSource>();
		panelInput = GetComponent<PlayerInput>();
		panelInput.actions["Enter"].performed += delegate
		{
			if (searchInput.isFocused && searchInput.text.Trim().Length > 0)
			{
				Search();
			}
		};
		history = new WebHistory();
		forwardButton.onClick.AddListener(OnForward);
		backButton.onClick.AddListener(OnBack);
		if (LevelManager.GetCurrLevel() >= 5)
		{
			LaunchWebsite("welcome");
			SetInteractableBrowser(value: true);
		}
		else
		{
			LaunchWebsite("denied");
			SetInteractableBrowser(value: false);
		}
		SetInteractableHistory();
	}

	public void Search()
	{
		OnWebsiteSearch(searchInput.text.Trim());
	}

	public Scrollbar GetScrollbar()
	{
		return base.transform.Find("Website/Websites UI/Scrollbar").GetComponent<Scrollbar>();
	}

	public void PlaySearch()
	{
		audioPlayer.PlayOneShot(searchAudio);
	}

	public void SetSearchInteractable()
	{
		SetSearchButtonInteractable(searchInput.text.Trim().Length > 0);
	}

	public void OnWebsiteSearch(string url, bool playSound = true)
	{
		SetSearchButtonInteractable(value: false);
		if (playSound)
		{
			PlaySearch();
		}
		Debug.Log("Entering website search: " + searchInput.text);
		Debug.Log("Destroying current website: " + currentSite.name);
		float value = GetScrollbar().value;
		Object.Destroy(currentSite);
		LaunchWebsite(url);
		SetSearchInputText(url);
		history.AddSite(url, value);
		SetInteractableHistory();
	}

	public void OnBack()
	{
		if (!this.history.IsFirstSite())
		{
			this.history.SaveCurrentScrollPos(GetScrollbar().value);
			audioPlayer.PlayOneShot(backAudio);
			Object.Destroy(currentSite);
			WebHistory.History history = PermissionsRedirect();
			LaunchWebsite(history.site);
			SetSearchInputText(history.site);
			SetInteractableHistory();
			GetScrollbar().value = history.scrollPos;
		}
	}

	public void OnForward()
	{
		if (!this.history.IsLastSite())
		{
			this.history.SaveCurrentScrollPos(GetScrollbar().value);
			audioPlayer.PlayOneShot(frontAudio);
			Object.Destroy(currentSite);
			WebHistory.History history = this.history.Forward();
			LaunchWebsite(history.site);
			SetSearchInputText(history.site);
			SetInteractableHistory();
			GetScrollbar().value = history.scrollPos;
		}
	}

	public void OnEnable()
	{
		if (LevelManager.GetCurrLevel() >= 5 && currentSite.name == "denied" && history.IsFirstSite())
		{
			Object.Destroy(currentSite);
			SetInteractableBrowser(value: true);
			SetInteractableHistory();
			LaunchWebsite("welcome");
		}
		else if (currentSite.name != "denied")
		{
			searchInput.Select();
		}
	}

	public void ClearHistory()
	{
		history = new WebHistory();
		searchInput.text = "";
		LaunchWebsite("welcome");
		SetInteractableBrowser(value: true);
		SetInteractableHistory();
	}

	private void LaunchWebsite(string url)
	{
		if (url.Length > 0 && (url[url.Length - 1] == '/' || url[url.Length - 1] == '-'))
		{
			url = url.Substring(0, url.Length - 1);
		}
		bool flag = false;
		string url2 = url.Replace('/', '-');
		GameObject website = ResourcesManager.GetWebsite(url2);
		if (website == null)
		{
			(flag, url2) = SearchedGeneratedSite(url);
			if (flag)
			{
				url2 = url2.Replace('/', '-');
				website = ResourcesManager.GetWebsite(url2);
			}
			else
			{
				website = ResourcesManager.GetWebsite("missing");
			}
		}
		Website component = website.GetComponent<Website>();
		if (component != null && !component.LoadPage(url))
		{
			website = ResourcesManager.GetWebsite("missing");
		}
		currentSite = Object.Instantiate(website, websiteContainer.transform);
		websiteContainer.GetComponent<ScrollRect>().content = currentSite.GetComponent<RectTransform>();
		currentSite.name = url;
		SetHintState(url);
	}

	private void SetHintState(string url)
	{
		int currLevel = LevelManager.GetCurrLevel();
		switch (currLevel)
		{
		case 4:
			if (url == "pizzaslices.net")
			{
				HintManager.SetHintState(currLevel, 2);
			}
			break;
		case 5:
			if (url == "selectyourstar.com" && HintManager.GetHintState() == 3)
			{
				HintManager.SetHintState(currLevel, 4);
			}
			else if (HintManager.GetHintState() >= 4)
			{
				if (url == "jimsbirthday.net")
				{
					HintManager.IncrementHintState(10000);
				}
				else if (url == "smoothieworld.net")
				{
					HintManager.IncrementHintState(1000);
				}
				else if (url.StartsWith("mmdb.com/profile/ribbit78"))
				{
					HintManager.IncrementHintState(100000);
				}
			}
			break;
		case 6:
			if (url.StartsWith("newhampshire.wiki"))
			{
				HintManager.SetHintState(currLevel, 2);
			}
			break;
		case 7:
			if (url.StartsWith("youthtranslator.com"))
			{
				HintManager.SetHintState(currLevel, 8);
			}
			else if (url.StartsWith("teach3rz0n1y.com"))
			{
				HintManager.SetHintState(currLevel, 7);
			}
			else if (url.StartsWith("lzu.edu/classes/history") && HintManager.GetHintState() == 5)
			{
				HintManager.SetHintState(currLevel, 6);
			}
			else if (url.StartsWith("lzu.edu/classes/computers") && HintManager.GetHintState() == 4)
			{
				HintManager.SetHintState(currLevel, 5);
			}
			else if (url.StartsWith("lzu.edu"))
			{
				HintManager.SetHintState(currLevel, 2);
			}
			break;
		case 8:
			if (url.StartsWith("bigleeks.net"))
			{
				if (HintManager.GetHintState() == 2)
				{
					HintManager.SetHintState(currLevel, 4);
				}
				else if (HintManager.GetHintState() == 1)
				{
					HintManager.SetHintState(currLevel, 3, resetHintState: false);
				}
				if (HintManager.GetQueryState() == 0)
				{
					HintManager.SetQueryState(1);
				}
			}
			else if (url.StartsWith("lzppp.com"))
			{
				if (HintManager.GetHintState() == 3)
				{
					HintManager.SetHintState(currLevel, 4);
				}
				else if (HintManager.GetHintState() == 1)
				{
					HintManager.SetHintState(currLevel, 2, resetHintState: false);
				}
			}
			else if (url.StartsWith("sti.com"))
			{
				HintManager.SetHintState(currLevel, 5);
				if (HintManager.GetQueryState() != 2)
				{
					HintManager.SetQueryState(3);
				}
			}
			else if (url.StartsWith("ponziscam.com"))
			{
				HintManager.SetHintState(currLevel, 9);
			}
			break;
		}
	}

	private void SetSearchButtonInteractable(bool value)
	{
		searchButton.interactable = value;
		SetHistoryIconTransparency(searchButton);
		void SetHistoryIconTransparency(Button button)
		{
			button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = GetIconColor(button, hasColor: false);
		}
	}

	private void SetInteractableBrowser(bool value)
	{
		searchInput.interactable = value;
		if (!value)
		{
			SetSearchButtonInteractable(value);
		}
		else
		{
			searchInput.Select();
		}
	}

	private void SetInteractableHistory()
	{
		forwardButton.interactable = !history.IsLastSite();
		backButton.interactable = !history.IsFirstSite();
		SetHistoryIconTransparency(forwardButton);
		SetHistoryIconTransparency(backButton);
		void SetHistoryIconTransparency(Button button)
		{
			button.transform.GetChild(0).GetComponent<Image>().color = GetIconColor(button);
		}
	}

	private void SetSearchInputText(string url)
	{
		if (SPECIAL_SITES.Contains(url))
		{
			searchInput.text = "";
		}
		else
		{
			searchInput.text = url;
		}
	}

	private Color32 GetIconColor(Button button, bool hasColor = true)
	{
		Color32 result = new Color32(0, 0, 0, byte.MaxValue);
		if (!button.interactable)
		{
			result.a = 80;
		}
		if (hasColor)
		{
			result.r = byte.MaxValue;
			result.g = byte.MaxValue;
			result.b = byte.MaxValue;
		}
		return result;
	}

	private (bool, string) SearchedGeneratedSite(string searchedUrl)
	{
		foreach (string gENERATED_SITE in GENERATED_SITES)
		{
			if (searchedUrl.StartsWith(gENERATED_SITE))
			{
				return (true, gENERATED_SITE);
			}
		}
		return (false, "missing");
	}

	private WebHistory.History PermissionsRedirect()
	{
		WebHistory.History history = this.history.Back();
		while (ShouldRedirect(history.site))
		{
			history = this.history.Back();
		}
		return history;
	}

	private bool ShouldRedirect(string website)
	{
		if (website == "rateyourdictator.gov/admin" || website == "rateyourdictator.gov/admin/")
		{
			return !rateyourdictator_login.LOGGED_IN;
		}
		string text = "guildsofnewhampshire.net/forum/";
		if (website.StartsWith(text))
		{
			string guild = website.Substring(text.Length);
			if (guild_profile.IsValidGuild(guild))
			{
				return !guild_login.IsLoggedIn(guild);
			}
			return false;
		}
		return false;
	}
}
