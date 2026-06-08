using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SessionQuestMenuCard : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private Material hiddenMaterial;

	[SerializeField]
	private GameObject hiddenScreen;

	[SerializeField]
	private GameObject visibleScreen;

	[SerializeField]
	private TextMeshProUGUI titleLabel;

	[SerializeField]
	private TextMeshProUGUI descriptionLabel;

	[SerializeField]
	private TextMeshProUGUI levelLabel;

	[SerializeField]
	private SessionQuestRewardTileScreen rewardTileDisplay;

	[SerializeField]
	private Image progressBarFill;

	[SerializeField]
	private TextMeshProUGUI progressLabel;

	[SerializeField]
	private SessionQuestLevelMarkerBar levelMarkerBar;

	[SerializeField]
	private SessionQuestSelector sessionQuestSelector;

	[SerializeField]
	private GameObject shadow;

	[SerializeField]
	private SessionQuestManager sessionQuestManager;

	[SerializeField]
	private SettingsRouter settingsRouter;

	private SessionQuest _003CSessionQuest_003Ek__BackingField;

	private RewardTileViewer _003CTileViewer_003Ek__BackingField;

	private SessionQuestScreen _003CSessionQuestScreen_003Ek__BackingField;

	private int displayedLevel;

	public SessionQuest SessionQuest
	{
		get
		{
			return _003CSessionQuest_003Ek__BackingField;
		}
		private set
		{
			_003CSessionQuest_003Ek__BackingField = value;
		}
	}

	public RewardTileViewer TileViewer
	{
		get
		{
			return _003CTileViewer_003Ek__BackingField;
		}
		private set
		{
			_003CTileViewer_003Ek__BackingField = value;
		}
	}

	private SessionQuestScreen SessionQuestScreen
	{
		get
		{
			return _003CSessionQuestScreen_003Ek__BackingField;
		}
		set
		{
			_003CSessionQuestScreen_003Ek__BackingField = value;
		}
	}

	public RewardState QuestState => SessionQuest.CurrentState;

	public SessionQuestSelector Selector => sessionQuestSelector;

	public void Setup(SessionQuestScreen sessionQuestScreen, SessionQuest sessionQuest, RewardTileViewer tileViewer, bool hasShadow = false)
	{
		SessionQuest = sessionQuest;
		base.name = "SessionQuestDisplay_" + sessionQuest.GetTitle();
		TileViewer = tileViewer;
		SessionQuestScreen = sessionQuestScreen;
		shadow.SetActive(hasShadow);
		levelMarkerBar.Setup(this);
		rewardTileDisplay.Setup(this);
		sessionQuestSelector.Setup(this);
		displayedLevel = sessionQuest.CurrentLevelIndex;
		ShowLevel(displayedLevel);
		LocalizationManager.Instance.OnLanguageChanged += UpdateText;
		ShowPinnedState(sessionQuest.isPinned);
		sessionQuest.OnPinned += ShowPinnedState;
		sessionQuest.OnProgressChanged += UpdateProgressChangedBarFromEvent;
		sessionQuest.OnFulfillmentChanged += UpdateFulfillment;
		sessionQuest.OnUnlocked += Unlock;
		UpdateFulfillment(sessionQuest);
	}

	private void Unlock(SessionQuest unlockedChallenge)
	{
		UpdateFulfillment(null);
	}

	public void ShowLevel(int levelIndex)
	{
		ShowLevel(SessionQuest, levelIndex);
	}

	public void ShowLevel(SessionQuest sessionQuest, int levelIndex)
	{
		if (levelIndex == -1)
		{
			levelIndex = sessionQuest.CurrentLevelIndex;
		}
		sessionQuest.GetLevel(levelIndex);
		displayedLevel = levelIndex;
		levelMarkerBar.ShowLevel(levelIndex);
		UpdateText();
		UpdateProgressChangedBar();
		rewardTileDisplay.DisplayLevel(levelIndex);
	}

	public void ShowPinnedState(bool newPinned)
	{
		sessionQuestSelector.SetSelected(SessionQuest.isPinned);
		sessionQuestManager.UpdateOrder();
	}

	private void UpdateText()
	{
		LocalizationManager.Instance.UpdateTextMesh(titleLabel, LocalizedFontStyle.H1, SessionQuest.GetTitle(displayedLevel), HorizontalAlignmentOptions.Left);
		LocalizationManager.Instance.UpdateTextMesh(descriptionLabel, LocalizedFontStyle.H1, SessionQuest.GetDescription(displayedLevel), HorizontalAlignmentOptions.Left);
	}

	private void UpdateFulfillment(SessionQuest fulfilledQuest, int fulfilledLevel = -1)
	{
		if ((bool)this)
		{
			visibleScreen.SetActive(SessionQuest.CurrentState != RewardState.Hidden);
			hiddenScreen.SetActive(SessionQuest.CurrentState == RewardState.Hidden);
			UpdateProgressChangedBar();
			ShowLevel(-1);
			sessionQuestManager.UpdateOrder();
		}
	}

	private void UpdateProgressChangedBarFromEvent(int obj)
	{
		UpdateProgressChangedBar();
		ShowLevel(-1);
	}

	private void UpdateProgressChangedBar()
	{
		progressLabel.text = $"{SessionQuest.GetCurrentProgress(displayedLevel).ToString()} / {SessionQuest.TargetCount(displayedLevel)}";
		progressBarFill.fillAmount = (float)SessionQuest.GetCurrentProgress(displayedLevel) / (float)SessionQuest.TargetCount(displayedLevel);
	}

	private void OnDestroy()
	{
		SessionQuest.OnProgressChanged -= UpdateProgressChangedBarFromEvent;
		SessionQuest.OnFulfillmentChanged -= UpdateFulfillment;
		SessionQuest.OnPinned -= ShowPinnedState;
		if ((bool)LocalizationManager.Instance)
		{
			LocalizationManager.Instance.OnLanguageChanged -= UpdateText;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (SessionQuest.CurrentState != RewardState.Completed && settingsRouter.PinChallengesEnabled)
		{
			SessionQuest.Pin(!SessionQuest.isPinned);
			SessionQuest.OverwriteSaveState();
		}
	}
}
