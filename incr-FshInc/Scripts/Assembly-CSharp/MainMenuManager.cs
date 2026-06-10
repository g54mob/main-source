using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
	[Header("Buttons")]
	public Button continueButton;

	public TextMeshProUGUI continueButtonText;

	public Color inactiveTextColour;

	public Button newGameButton;

	public Button exitButton;

	[Header("Scene To Load")]
	public string gameSceneName = "GameScene";

	private const string SaveKey = "HasSavedGame";

	[Header("Confirmation Pop-up")]
	[Tooltip("The parent GameObject for the confirmation pop-up.")]
	public GameObject confirmationPopup;

	[Tooltip("The background overlay CanvasGroup (fades in). If null, the whole popup just scales.")]
	public CanvasGroup popupOverlay;

	[Tooltip("The main content RectTransform (scales up). If null, the whole popup just scales.")]
	public RectTransform popupContent;

	public float popupAnimDuration = 0.3f;

	public Ease popupEaseType = Ease.OutBack;

	private Vector3 _popupOriginalScale;

	private const string PlayTimeKey = "TotalPlayTime";

	private const string TotalFishKey = "TotalGlobalFishCaught";

	private const string TotalSkillsKey = "TotalSkillsPurchased";

	private const string TotalMoneyKey = "TotalMoney";

	public TextMeshProUGUI timePlayedText;

	public TextMeshProUGUI fishCaughtText;

	public TextMeshProUGUI skillsText;

	public TextMeshProUGUI goldText;

	public SettingsMenu settingsPanel;

	[Header("Credits")]
	public GameObject creditsPanel;

	public CanvasGroup creditsOverlay;

	public CanvasGroup creditsContent;

	public float creditsAnimDuration = 0.4f;

	private LocalizedString _timePlayedLoc;

	private LocalizedString _fishCaughtLoc;

	private LocalizedString _skillsBoughtLoc;

	private LocalizedString _moneyLoc;

	private LocalizedString _goldUnitLoc;

	private LocalizedString _hoursFormatLoc;

	private void Start()
	{
		_timePlayedLoc = new LocalizedString("Skills", "#ui.hud.timeplayed.text");
		_fishCaughtLoc = new LocalizedString("Skills", "#ui.receipt.fish.caught.title");
		_skillsBoughtLoc = new LocalizedString("Skills", "#ui.endofdemo.skills.text");
		_moneyLoc = new LocalizedString("Skills", "#ui.hud.money.text");
		_goldUnitLoc = new LocalizedString("Skills", "#ui.unit.gold");
		_hoursFormatLoc = new LocalizedString("Skills", "#ui.endofdemo.timeformat.hours");
		_popupOriginalScale = confirmationPopup.transform.localScale;
		confirmationPopup.SetActive(value: false);
		if (GameManager.IsSaveOutdated())
		{
			Debug.Log("[MainMenu] Outdated save detected (demo or old version). Wiping save data.");
			WipeOutdatedSave();
		}
		if (PlayerPrefs.HasKey("HasSavedGame"))
		{
			continueButton.interactable = true;
		}
		else
		{
			continueButton.interactable = false;
			continueButtonText.color = inactiveTextColour;
		}
		if (exitButton != null)
		{
			exitButton.onClick.AddListener(OnExitButtonClicked);
		}
	}

	public void OnExitButtonClicked()
	{
		SoundManager.PlaySound("WoodUI_Change");
		Debug.Log("Exiting Game...");
		Application.Quit();
	}

	public void OnContinueClicked()
	{
		if (SoundManager.Instance != null)
		{
			SoundManager.PlaySound("WoodUI_Change");
		}
		if (SceneTransitionManager.Instance != null)
		{
			SceneTransitionManager.Instance.TransitionToScene(gameSceneName);
		}
		else
		{
			SceneManager.LoadScene(gameSceneName);
		}
	}

	public void OnClickNewGame()
	{
		if (PlayerPrefs.HasKey("HasSavedGame"))
		{
			float totalSeconds = PlayerPrefs.GetFloat("TotalPlayTime", 0f);
			int num = PlayerPrefs.GetInt("TotalGlobalFishCaught", 0);
			int num2 = PlayerPrefs.GetInt("TotalSkillsPurchased", 0);
			double result = 0.0;
			if (PlayerPrefs.HasKey("TotalMoneyDouble"))
			{
				double.TryParse(PlayerPrefs.GetString("TotalMoneyDouble", "0"), out result);
			}
			else
			{
				result = PlayerPrefs.GetInt("TotalMoney", 0);
			}
			if (timePlayedText != null)
			{
				timePlayedText.text = _timePlayedLoc.GetLocalizedString() + " <color=yellow>" + FormatTime(totalSeconds) + "</color>";
			}
			if (fishCaughtText != null)
			{
				fishCaughtText.text = $"{_fishCaughtLoc.GetLocalizedString()} <color=yellow>{num:N0}</color>";
			}
			if (skillsText != null)
			{
				skillsText.text = $"{_skillsBoughtLoc.GetLocalizedString()} <color=yellow>{num2}</color>";
			}
			if (goldText != null)
			{
				goldText.text = _moneyLoc.GetLocalizedString() + " <color=yellow>" + CurrencyFormatter.FormatMoneyPrecise(result) + " " + _goldUnitLoc.GetLocalizedString() + "</color>";
			}
			ShowConfirmationPopup();
		}
		else
		{
			StartNewGameConfirmed();
		}
	}

	private string FormatTime(float totalSeconds)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(totalSeconds);
		return _hoursFormatLoc.GetLocalizedString(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
	}

	private void ShowConfirmationPopup()
	{
		confirmationPopup.SetActive(value: true);
		if (popupOverlay != null && popupContent != null)
		{
			popupOverlay.alpha = 0f;
			popupOverlay.DOKill();
			popupOverlay.DOFade(1f, popupAnimDuration * 0.5f).SetEase(Ease.Linear).SetUpdate(isIndependentUpdate: true);
			popupContent.localScale = Vector3.zero;
			popupContent.DOKill();
			popupContent.DOScale(Vector3.one, popupAnimDuration).SetEase(popupEaseType).SetUpdate(isIndependentUpdate: true);
		}
		else
		{
			confirmationPopup.transform.localScale = Vector3.zero;
			confirmationPopup.transform.DOScale(_popupOriginalScale, popupAnimDuration).SetEase(popupEaseType).SetUpdate(isIndependentUpdate: true);
		}
	}

	public void CancelNewGame()
	{
		if (popupOverlay != null && popupContent != null)
		{
			popupOverlay.DOKill();
			popupContent.DOKill();
			popupOverlay.DOFade(0f, popupAnimDuration * 0.5f).SetEase(Ease.Linear).SetUpdate(isIndependentUpdate: true);
			popupContent.DOScale(Vector3.zero, popupAnimDuration).SetEase(Ease.InBack).SetUpdate(isIndependentUpdate: true)
				.OnComplete(delegate
				{
					confirmationPopup.SetActive(value: false);
				});
		}
		else
		{
			confirmationPopup.transform.DOScale(Vector3.zero, popupAnimDuration).SetEase(Ease.InBack).SetUpdate(isIndependentUpdate: true)
				.OnComplete(delegate
				{
					confirmationPopup.SetActive(value: false);
				});
		}
	}

	public void StartNewGameConfirmed()
	{
		int value = PlayerPrefs.GetInt("Setting_FPS_Index", 2);
		int value2 = PlayerPrefs.GetInt("Setting_Shake", 1);
		int value3 = PlayerPrefs.GetInt("Setting_VFX", 1);
		int value4 = PlayerPrefs.GetInt("Setting_Zoom", 1);
		int value5 = PlayerPrefs.GetInt("Setting_AutoReel", 0);
		int num = PlayerPrefs.GetInt("Setting_Res_Index", -1);
		int value6 = PlayerPrefs.GetInt("Setting_Display", 0);
		Locale selectedLocale = LocalizationSettings.SelectedLocale;
		float num2 = 1f;
		float num3 = 1f;
		float num4 = 1f;
		if (SoundManager.Instance != null)
		{
			num2 = SoundManager.Instance.globalMusicVolume;
			num3 = SoundManager.Instance.globalAmbianceVolume;
			num4 = SoundManager.Instance.globalSfxVolume;
		}
		else
		{
			num2 = PlayerPrefs.GetFloat("MusicVolume", 1f);
			num3 = PlayerPrefs.GetFloat("AmbienceVolume", 1f);
			num4 = PlayerPrefs.GetFloat("SFXVolume", 1f);
		}
		if (GameManager.Instance != null)
		{
			GameManager.Instance.totalPlayTime = 0f;
		}
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt("Setting_FPS_Index", value);
		PlayerPrefs.SetInt("Setting_Shake", value2);
		PlayerPrefs.SetInt("Setting_VFX", value3);
		PlayerPrefs.SetInt("Setting_Zoom", value4);
		PlayerPrefs.SetInt("Setting_AutoReel", value5);
		if (num >= 0)
		{
			PlayerPrefs.SetInt("Setting_Res_Index", num);
		}
		PlayerPrefs.SetInt("Setting_Display", value6);
		if (selectedLocale != null)
		{
			LocalizationSettings.SelectedLocale = selectedLocale;
		}
		if (SoundManager.Instance != null)
		{
			SoundManager.Instance.globalMusicVolume = num2;
			SoundManager.Instance.globalAmbianceVolume = num3;
			SoundManager.Instance.globalSfxVolume = num4;
			SoundManager.Instance.SaveSettings();
		}
		if (FishLogManager.Instance != null)
		{
			FishLogManager.Instance.ResetLog();
		}
		if (SkillManager.Instance != null)
		{
			SkillManager.Instance.ResetSkillTree();
		}
		if (AchievementManager.Instance != null)
		{
			AchievementManager.Instance.ResetAchievementData();
		}
		if (SteamAchievementManager.Instance != null)
		{
			SteamAchievementManager.Instance.ResetProgress();
		}
		if (GameManager.Instance != null)
		{
			GameManager.Instance.ResetData();
			GameManager.Instance.SaveGameData();
		}
		SceneTransitionManager.Instance.TransitionToScene(gameSceneName);
	}

	private void WipeOutdatedSave()
	{
		int value = PlayerPrefs.GetInt("Setting_FPS_Index", 2);
		int value2 = PlayerPrefs.GetInt("Setting_Shake", 1);
		int value3 = PlayerPrefs.GetInt("Setting_VFX", 1);
		int value4 = PlayerPrefs.GetInt("Setting_Zoom", 1);
		int value5 = PlayerPrefs.GetInt("Setting_AutoReel", 0);
		int num = PlayerPrefs.GetInt("Setting_Res_Index", -1);
		int value6 = PlayerPrefs.GetInt("Setting_Display", 0);
		float value7 = PlayerPrefs.GetFloat("MusicVolume", 1f);
		float value8 = PlayerPrefs.GetFloat("AmbienceVolume", 1f);
		float value9 = PlayerPrefs.GetFloat("SFXVolume", 1f);
		Locale selectedLocale = LocalizationSettings.SelectedLocale;
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt("Setting_FPS_Index", value);
		PlayerPrefs.SetInt("Setting_Shake", value2);
		PlayerPrefs.SetInt("Setting_VFX", value3);
		PlayerPrefs.SetInt("Setting_Zoom", value4);
		PlayerPrefs.SetInt("Setting_AutoReel", value5);
		if (num >= 0)
		{
			PlayerPrefs.SetInt("Setting_Res_Index", num);
		}
		PlayerPrefs.SetInt("Setting_Display", value6);
		PlayerPrefs.SetFloat("MusicVolume", value7);
		PlayerPrefs.SetFloat("AmbienceVolume", value8);
		PlayerPrefs.SetFloat("SFXVolume", value9);
		if (selectedLocale != null)
		{
			LocalizationSettings.SelectedLocale = selectedLocale;
		}
		if (FishLogManager.Instance != null)
		{
			FishLogManager.Instance.ResetLog();
		}
		if (SkillManager.Instance != null)
		{
			SkillManager.Instance.ResetSkillTree();
		}
		if (AchievementManager.Instance != null)
		{
			AchievementManager.Instance.ResetAchievementData();
		}
		if (SteamAchievementManager.Instance != null)
		{
			SteamAchievementManager.Instance.ResetProgress();
			SteamAchievementManager.Instance.ResetSteamSideProgress();
		}
		if (GameManager.Instance != null)
		{
			GameManager.Instance.totalPlayTime = 0f;
			GameManager.Instance.ResetData();
		}
		PlayerPrefs.DeleteKey("HasSavedGame");
		PlayerPrefs.Save();
	}

	public void OnCreditsButtonClicked()
	{
		SoundManager.PlaySound("WoodUI_Change");
		ShowCreditsPanel();
	}

	private void ShowCreditsPanel()
	{
		creditsPanel.SetActive(value: true);
		creditsOverlay.alpha = 0f;
		creditsOverlay.DOKill();
		creditsOverlay.DOFade(1f, creditsAnimDuration * 0.5f).SetEase(Ease.Linear).SetUpdate(isIndependentUpdate: true);
		creditsContent.alpha = 0f;
		creditsContent.DOKill();
		creditsContent.DOFade(1f, creditsAnimDuration).SetEase(Ease.OutQuad).SetUpdate(isIndependentUpdate: true);
	}

	public void CloseCreditsPanel()
	{
		SoundManager.PlaySound("WoodUI_Change");
		creditsOverlay.DOKill();
		creditsContent.DOKill();
		creditsContent.DOFade(0f, creditsAnimDuration * 0.6f).SetEase(Ease.InQuad).SetUpdate(isIndependentUpdate: true);
		creditsOverlay.DOFade(0f, creditsAnimDuration * 0.5f).SetEase(Ease.Linear).SetUpdate(isIndependentUpdate: true)
			.OnComplete(delegate
			{
				creditsPanel.SetActive(value: false);
			});
	}

	public void OnSettingsButtonClicked()
	{
		settingsPanel.ShowPanel();
	}

	private void ShowPanel(CanvasGroup panel)
	{
		if (panel != null)
		{
			panel.alpha = 1f;
			panel.interactable = true;
			panel.blocksRaycasts = true;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (creditsPanel != null && creditsPanel.activeSelf)
			{
				CloseCreditsPanel();
			}
			else if (settingsPanel != null && settingsPanel.IsVisible)
			{
				settingsPanel.CloseSettings();
			}
		}
	}
}
