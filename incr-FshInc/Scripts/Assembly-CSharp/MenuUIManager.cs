using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
	public CanvasGroup zonesPanel;

	public CanvasGroup upgradesPanel;

	public CanvasGroup fishLogPanel;

	public CanvasGroup achievementsPanel;

	public SkillTreePanel skillTreePanel;

	public AchievementsPanel achievementsPanelScript;

	public FishLogPanel fishLogPanelScript;

	public TMP_Text moneyText;

	public TMP_Text moneyTextShadow;

	private List<CanvasGroup> allPanels;

	[Header("Notifications")]
	public GameObject newIndicator;

	[Tooltip("Notification indicator on the Achievements tab button. Shown when there are unclaimed achievements.")]
	public GameObject achievementNotificationIndicator;

	[Tooltip("Notification indicator on the Zones tab button. Shown when the player can afford to unlock a new zone.")]
	public GameObject zoneNotificationIndicator;

	[Header("Tab Buttons & Highlights")]
	public Button zonesButton;

	public Button upgradesButton;

	public Button fishLogButton;

	public Button achievementsButton;

	[Header("Tab Text (For Color fading)")]
	public TMP_Text zonesButtonText;

	public TMP_Text upgradesButtonText;

	public TMP_Text fishLogButtonText;

	public TMP_Text achievementsButtonText;

	[Header("Tab Highlights (For scaling)")]
	public GameObject zonesButtonHighlight;

	public GameObject upgradesButtonHighlight;

	public GameObject fishLogButtonHighlight;

	public GameObject achievementsButtonHighlight;

	private const string IntroTutorKey = "initIntroTutSeen";

	public DialogueSequenceSO introTutorial;

	private const string SkillTreeTutorKey = "SkillTreeTutorSeen";

	public DialogueSequenceSO skillTreeTutorial;

	private const string FishLogTutorKey = "FishLogTutorSeen";

	public DialogueSequenceSO fishLogTutorial;

	private const string AchievementsTutorKey = "AchievementsTutorSeen";

	public DialogueSequenceSO achievementsTutorial;

	private Button _currentSelectedTab;

	public static MenuUIManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
		if (zonesButtonHighlight != null)
		{
			zonesButtonHighlight.SetActive(value: false);
		}
		if (upgradesButtonHighlight != null)
		{
			upgradesButtonHighlight.SetActive(value: false);
		}
		if (fishLogButtonHighlight != null)
		{
			fishLogButtonHighlight.SetActive(value: false);
		}
		if (achievementsButtonHighlight != null)
		{
			achievementsButtonHighlight.SetActive(value: false);
		}
		if (zoneNotificationIndicator != null)
		{
			zoneNotificationIndicator.SetActive(value: false);
		}
		if (achievementNotificationIndicator != null)
		{
			achievementNotificationIndicator.SetActive(value: false);
		}
		if (newIndicator != null)
		{
			newIndicator.SetActive(value: false);
		}
	}

	private void Start()
	{
		if (GameManager.Instance.isNewGamePending)
		{
			GameManager.Instance.FinalizeNewGame();
		}
		GameManager instance = GameManager.Instance;
		instance.OnMoneyChanged = (Action<double>)Delegate.Combine(instance.OnMoneyChanged, new Action<double>(UpdateMoneyText));
		GameManager instance2 = GameManager.Instance;
		instance2.OnMoneyChanged = (Action<double>)Delegate.Combine(instance2.OnMoneyChanged, (Action<double>)delegate
		{
			UpdateZoneNotification();
		});
		UpdateMoneyText(GameManager.Instance.totalMoney);
		UpdateZoneNotification();
		allPanels = new List<CanvasGroup> { zonesPanel, upgradesPanel, fishLogPanel, achievementsPanel };
		if (GameManager.Instance.CurrentDay <= 1)
		{
			ShowPanel(zonesPanel);
			UpdateTabHighlights(zonesButton, zonesButtonHighlight);
			if (introTutorial != null)
			{
				StartCoroutine(ShowIntroAfterDelay());
			}
		}
		else
		{
			OpenUpgradesPanel();
		}
		if (FishLogManager.Instance != null)
		{
			FishLogManager.Instance.OnLogUpdated += UpdateNotifications;
			UpdateNotifications();
		}
		if (AchievementManager.Instance != null)
		{
			AchievementManager.Instance.OnAchievementCompleted += OnAchievementStateChanged;
			AchievementManager.Instance.OnAchievementClaimed += OnAchievementStateChanged;
			UpdateAchievementNotification();
		}
	}

	private IEnumerator ShowIntroAfterDelay()
	{
		yield return new WaitForSecondsRealtime(0.8f);
		DialogueManager.Instance.ShowTutorialOnce("IntroDialogueSeen", introTutorial);
	}

	private void UpdateNotifications()
	{
		if (newIndicator == null)
		{
			return;
		}
		if (FishLogManager.Instance.HasAnyNewFish())
		{
			newIndicator.transform.DOKill();
			newIndicator.SetActive(value: true);
			newIndicator.transform.localScale = Vector3.one;
		}
		else if (newIndicator.activeSelf)
		{
			newIndicator.transform.DOKill();
			newIndicator.transform.DOScale(0f, 0.3f).SetEase(Ease.InBack).OnComplete(delegate
			{
				newIndicator.SetActive(value: false);
				newIndicator.transform.localScale = Vector3.one;
			});
		}
		else
		{
			newIndicator.SetActive(value: false);
		}
	}

	private void OnAchievementStateChanged(Achievement ach)
	{
		UpdateAchievementNotification();
	}

	private void UpdateAchievementNotification()
	{
		if (achievementNotificationIndicator == null)
		{
			return;
		}
		if (AchievementManager.Instance != null && AchievementManager.Instance.HasUnclaimedAchievements())
		{
			achievementNotificationIndicator.transform.DOKill();
			achievementNotificationIndicator.SetActive(value: true);
			achievementNotificationIndicator.transform.localScale = Vector3.one;
		}
		else if (achievementNotificationIndicator.activeSelf)
		{
			achievementNotificationIndicator.transform.DOKill();
			achievementNotificationIndicator.transform.DOScale(0f, 0.3f).SetEase(Ease.InBack).OnComplete(delegate
			{
				achievementNotificationIndicator.SetActive(value: false);
				achievementNotificationIndicator.transform.localScale = Vector3.one;
			});
		}
		else
		{
			achievementNotificationIndicator.SetActive(value: false);
		}
	}

	private void UpdateZoneNotification()
	{
		if (zoneNotificationIndicator == null)
		{
			return;
		}
		if (CanAffordAnyLockedZone())
		{
			zoneNotificationIndicator.transform.DOKill();
			zoneNotificationIndicator.SetActive(value: true);
			zoneNotificationIndicator.transform.localScale = Vector3.one;
		}
		else if (zoneNotificationIndicator.activeSelf)
		{
			zoneNotificationIndicator.transform.DOKill();
			zoneNotificationIndicator.transform.DOScale(0f, 0.3f).SetEase(Ease.InBack).OnComplete(delegate
			{
				zoneNotificationIndicator.SetActive(value: false);
				zoneNotificationIndicator.transform.localScale = Vector3.one;
			});
		}
		else
		{
			zoneNotificationIndicator.SetActive(value: false);
		}
	}

	public static bool CanAffordAnyLockedZone()
	{
		if (GameManager.Instance == null)
		{
			return false;
		}
		double totalMoney = GameManager.Instance.totalMoney;
		foreach (ZoneData allZone in GameManager.Instance.allZones)
		{
			if (!allZone.isUnlocked)
			{
				double effectiveZoneUnlockCost = GameManager.Instance.GetEffectiveZoneUnlockCost(allZone);
				if (totalMoney >= effectiveZoneUnlockCost)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void UpdateMoneyText(double money)
	{
		moneyText.text = CurrencyFormatter.FormatMoneyPrecise(money) + " G";
		moneyTextShadow.text = CurrencyFormatter.FormatMoneyPrecise(money) + " G";
	}

	private void OnDestroy()
	{
		GameManager instance = GameManager.Instance;
		instance.OnMoneyChanged = (Action<double>)Delegate.Remove(instance.OnMoneyChanged, new Action<double>(UpdateMoneyText));
		if (FishLogManager.Instance != null)
		{
			FishLogManager.Instance.OnLogUpdated -= UpdateNotifications;
		}
		if (AchievementManager.Instance != null)
		{
			AchievementManager.Instance.OnAchievementCompleted -= OnAchievementStateChanged;
			AchievementManager.Instance.OnAchievementClaimed -= OnAchievementStateChanged;
		}
		if (newIndicator != null)
		{
			newIndicator.transform.DOKill();
		}
		if (achievementNotificationIndicator != null)
		{
			achievementNotificationIndicator.transform.DOKill();
		}
		if (zoneNotificationIndicator != null)
		{
			zoneNotificationIndicator.transform.DOKill();
		}
	}

	private void ShowPanel(CanvasGroup panelToShow)
	{
		foreach (CanvasGroup allPanel in allPanels)
		{
			if (allPanel != null)
			{
				allPanel.alpha = 0f;
				allPanel.interactable = false;
				allPanel.blocksRaycasts = false;
			}
		}
		if (panelToShow != null)
		{
			panelToShow.alpha = 1f;
			panelToShow.interactable = true;
			panelToShow.blocksRaycasts = true;
		}
	}

	private void UpdateTabHighlights(Button selectedButton, GameObject selectedHighlight)
	{
		if (!(_currentSelectedTab == selectedButton))
		{
			_currentSelectedTab = selectedButton;
			ResetTab(zonesButton, zonesButtonText, zonesButtonHighlight);
			ResetTab(upgradesButton, upgradesButtonText, upgradesButtonHighlight);
			ResetTab(fishLogButton, fishLogButtonText, fishLogButtonHighlight);
			ResetTab(achievementsButton, achievementsButtonText, achievementsButtonHighlight);
			TMP_Text txt = null;
			if (selectedButton == zonesButton)
			{
				txt = zonesButtonText;
			}
			else if (selectedButton == upgradesButton)
			{
				txt = upgradesButtonText;
			}
			else if (selectedButton == fishLogButton)
			{
				txt = fishLogButtonText;
			}
			else if (selectedButton == achievementsButton)
			{
				txt = achievementsButtonText;
			}
			SelectTab(selectedButton, txt, selectedHighlight);
		}
	}

	private void ResetTab(Button btn, TMP_Text txt, GameObject highlight)
	{
		if (btn != null)
		{
			btn.transform.DOKill();
			btn.transform.DOScale(1f, 0.2f).SetEase(Ease.OutQuad).SetUpdate(isIndependentUpdate: true);
		}
		if (txt != null)
		{
			txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 0.75f);
		}
		if (highlight != null)
		{
			highlight.transform.DOKill();
			highlight.transform.DOScale(0f, 0.2f).SetEase(Ease.InBack).SetUpdate(isIndependentUpdate: true)
				.OnComplete(delegate
				{
					highlight.SetActive(value: false);
				});
		}
	}

	private void SelectTab(Button btn, TMP_Text txt, GameObject highlight)
	{
		if (btn != null)
		{
			btn.transform.DOKill();
			btn.transform.DOScale(1.05f, 0.25f).SetEase(Ease.OutBack).SetUpdate(isIndependentUpdate: true);
		}
		if (txt != null)
		{
			txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 1f);
		}
		if (highlight != null)
		{
			highlight.SetActive(value: true);
			highlight.transform.DOKill();
			highlight.transform.localScale = Vector3.zero;
			highlight.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack).SetUpdate(isIndependentUpdate: true);
		}
	}

	public void OnZonesButtonClicked()
	{
		SoundManager.PlaySound("WoodUI_Change");
		ShowPanel(zonesPanel);
		UpdateTabHighlights(zonesButton, zonesButtonHighlight);
	}

	public void OnFishLogButtonClicked()
	{
		SoundManager.PlaySound("WoodUI_Change");
		ShowPanel(fishLogPanel);
		UpdateTabHighlights(fishLogButton, fishLogButtonHighlight);
		if (fishLogPanelScript != null)
		{
			fishLogPanelScript.ResetScrollToTop();
		}
		if (PlayerPrefs.GetInt("CurrentDay") > 0)
		{
			DialogueManager.Instance.ShowTutorialOnce("FishLogTutorSeen", fishLogTutorial);
		}
	}

	public void OpenUpgradesPanel()
	{
		SoundManager.PlaySound("WoodUI_Change");
		SoundManager.PlaySound("Enter_Store");
		skillTreePanel.UpdateTreeVisuals();
		ShowPanel(upgradesPanel);
		UpdateTabHighlights(upgradesButton, upgradesButtonHighlight);
		if (PlayerPrefs.GetInt("CurrentDay") > 0)
		{
			DialogueManager.Instance.ShowTutorialOnce("SkillTreeTutorSeen", skillTreeTutorial);
		}
	}

	public void OnAchievementsButtonClicked()
	{
		SoundManager.PlaySound("WoodUI_Change");
		achievementsPanelScript?.Refresh();
		ShowPanel(achievementsPanel);
		UpdateTabHighlights(achievementsButton, achievementsButtonHighlight);
		if (PlayerPrefs.GetInt("CurrentDay") > 1)
		{
			DialogueManager.Instance.ShowTutorialOnce("AchievementsTutorSeen", achievementsTutorial);
		}
	}

	public void OnUpgradesButtonClicked()
	{
		OpenUpgradesPanel();
	}
}
