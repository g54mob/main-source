using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class EndOfDemoPanel : MonoBehaviour
{
	public Button startNewDayButton;

	public PlayerManager playerManager;

	public bool triggerEndOfDemoScreen;

	[Header("UI References")]
	public TMP_Text timeTakenText;

	public TMP_Text totalFishText;

	public TMP_Text skillsBoughtText;

	private const string TotalSkillsKey = "TotalSkillsPurchased";

	private void Start()
	{
		startNewDayButton.onClick.AddListener(delegate
		{
			playerManager.ReturnToMenu();
		});
	}

	public void UpdateStats()
	{
		float totalSeconds = 0f;
		if (GameManager.Instance != null)
		{
			totalSeconds = GameManager.Instance.totalPlayTime;
		}
		timeTakenText.text = FormatTime(totalSeconds);
		int num = 0;
		if (FishLogManager.Instance != null)
		{
			num = FishLogManager.Instance.TotalGlobalFishCaught;
		}
		totalFishText.text = $"{num:N0}";
		int num2 = PlayerPrefs.GetInt("TotalSkillsPurchased", 0);
		skillsBoughtText.text = $"{num2}";
	}

	private void OnEnable()
	{
		UpdateStats();
	}

	private string FormatTime(float totalSeconds)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(totalSeconds);
		if (timeSpan.TotalHours >= 1.0)
		{
			return new LocalizedString("Skills", "#ui.endofdemo.timeformat.hours").GetLocalizedString(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
		}
		return new LocalizedString("Skills", "#ui.endofdemo.timeformat.short").GetLocalizedString(timeSpan.Minutes, timeSpan.Seconds);
	}

	public void ShowEndOfDemoPanel()
	{
		base.gameObject.SetActive(value: true);
	}

	public void OnWishlistClicked()
	{
		Application.OpenURL("https://store.steampowered.com/app/4126480/Fishing_Inc/?utm_source=ingame&utm_medium=demoEndScreen&utm_campaign=demo");
	}

	private void Update()
	{
		if (triggerEndOfDemoScreen)
		{
			ShowEndOfDemoPanel();
			triggerEndOfDemoScreen = false;
		}
	}
}
