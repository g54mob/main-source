using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletedView : BaseGUIView
{
	public const string RetryButtonEvent = "LevelCompletedView.RetryButtonEvent";

	public const string MenuButtonEvent = "LevelCompletedView.MenuButtonEvent";

	public const string BuildButtonEvent = "LevelCompletedView.BuildButtonEvent";

	public const string ReplayButtonEvent = "LevelCompletedView.ReplayButtonEvent";

	public const string LeaderboardsButtonEvent = "LevelCompletedView.LeaderboardsButtonEvent";

	public const string NextButtonEvent = "LevelCompletedView.NextButtonEvent";

	public const string FinishButtonEvent = "LevelCompletedView.FinishButtonEvent";

	public const string EditorButtonEvent = "LevelCompletedView.EditorButtonEvent";

	private RectTransform windowRectTransform;

	private GameObject levelDonePanel;

	private GameObject levelFailedPanel;

	private GameObject brainBlockDestroyedPanel;

	private GameObject allBestTimesPanel;

	private TextMeshProUGUI groupNameText;

	private TextMeshProUGUI levelNameText;

	private TextMeshProUGUI completeGroupText;

	private TextMeshProUGUI groupNameUnlockedText;

	private TextMeshProUGUI cheatEnabledText;

	private TextMeshProUGUI contentModifiedText;

	private TextMeshProUGUI leaderboardsText;

	private TextMeshProUGUI currentTimeText;

	private TextMeshProUGUI bestTimeText;

	private TextMeshProUGUI allBestTimesText;

	private TextMeshProUGUI collectablesStarsText;

	private TextMeshProUGUI collectablesUnlockedText;

	private TextMeshProUGUI loadingIconA;

	private TextMeshProUGUI loadingIconB;

	private Button retryButton;

	private Button menuButton;

	private Button buildButton;

	private Button replayButton;

	private Button leaderboardsButton;

	private Button nextButton;

	private Button finishButton;

	private Button editorButton;

	private GameManager gameManager;

	public override void Initialize()
	{
		windowRectTransform = mainPanel.transform.FindComponent<RectTransform>("ContentPanel", isRecursively: true);
		levelDonePanel = mainPanel.transform.FindChildRecursively("LevelDonePanel").gameObject;
		levelFailedPanel = mainPanel.transform.FindChildRecursively("LevelFailedPanel").gameObject;
		brainBlockDestroyedPanel = mainPanel.transform.FindChildRecursively("BrainBlockDestroyedPanel").gameObject;
		allBestTimesPanel = levelDonePanel.transform.FindChildRecursively("AllBestTimesPanel").gameObject;
		groupNameText = levelDonePanel.transform.FindComponent<TextMeshProUGUI>("GroupNameText", isRecursively: true);
		levelNameText = levelDonePanel.transform.FindComponent<TextMeshProUGUI>("LevelNameText", isRecursively: true);
		completeGroupText = levelDonePanel.transform.FindComponent<TextMeshProUGUI>("CompleteGroupText", isRecursively: true);
		groupNameUnlockedText = levelDonePanel.transform.FindComponent<TextMeshProUGUI>("GroupNameUnlockedText", isRecursively: true);
		cheatEnabledText = levelDonePanel.transform.FindComponent<TextMeshProUGUI>("CheatEnabledText", isRecursively: true);
		contentModifiedText = levelDonePanel.transform.FindComponent<TextMeshProUGUI>("ContentModifiedText", isRecursively: true);
		leaderboardsText = levelDonePanel.transform.FindComponent<TextMeshProUGUI>("LeaderboardsText", isRecursively: true);
		currentTimeText = levelDonePanel.transform.FindComponent<TextMeshProUGUI>("CurrentTimeText", isRecursively: true);
		bestTimeText = levelDonePanel.transform.FindComponent<TextMeshProUGUI>("BestTimeText", isRecursively: true);
		allBestTimesText = levelDonePanel.transform.FindComponent<TextMeshProUGUI>("AllBestTimesText", isRecursively: true);
		collectablesStarsText = levelDonePanel.transform.FindComponent<TextMeshProUGUI>("CollectablesStarsText", isRecursively: true);
		collectablesUnlockedText = levelDonePanel.transform.FindComponent<TextMeshProUGUI>("CollectablesUnlockedText", isRecursively: true);
		loadingIconA = leaderboardsText.transform.FindComponent<TextMeshProUGUI>("LoadingIconA", isRecursively: true);
		loadingIconB = leaderboardsText.transform.FindComponent<TextMeshProUGUI>("LoadingIconB", isRecursively: true);
		retryButton = mainPanel.transform.FindComponent<Button>("RetryButton", isRecursively: true);
		menuButton = mainPanel.transform.FindComponent<Button>("MenuButton", isRecursively: true);
		buildButton = mainPanel.transform.FindComponent<Button>("BuildButton", isRecursively: true);
		replayButton = mainPanel.transform.FindComponent<Button>("ReplayButton", isRecursively: true);
		leaderboardsButton = mainPanel.transform.FindComponent<Button>("LeaderboardsButton", isRecursively: true);
		nextButton = mainPanel.transform.FindComponent<Button>("NextButton", isRecursively: true);
		finishButton = mainPanel.transform.FindComponent<Button>("FinishButton", isRecursively: true);
		editorButton = mainPanel.transform.FindComponent<Button>("EditorButton", isRecursively: true);
		retryButton.onClick.AddListener(delegate
		{
			NotifyChange("LevelCompletedView.RetryButtonEvent");
		});
		menuButton.onClick.AddListener(delegate
		{
			NotifyChange("LevelCompletedView.MenuButtonEvent");
		});
		buildButton.onClick.AddListener(delegate
		{
			NotifyChange("LevelCompletedView.BuildButtonEvent");
		});
		replayButton.onClick.AddListener(delegate
		{
			NotifyChange("LevelCompletedView.ReplayButtonEvent");
		});
		leaderboardsButton.onClick.AddListener(delegate
		{
			NotifyChange("LevelCompletedView.LeaderboardsButtonEvent");
		});
		nextButton.onClick.AddListener(delegate
		{
			NotifyChange("LevelCompletedView.NextButtonEvent");
		});
		finishButton.onClick.AddListener(delegate
		{
			NotifyChange("LevelCompletedView.FinishButtonEvent");
		});
		editorButton.onClick.AddListener(delegate
		{
			NotifyChange("LevelCompletedView.EditorButtonEvent");
		});
		loadingIconA.gameObject.SetActive(value: false);
		loadingIconB.gameObject.SetActive(value: false);
		gameManager = GameManager.Instance;
	}

	public void SetLevelInfos(string groupName, string levelName, int levelsCompletedCount = -1, string groupNameJustUnlocked = null)
	{
		groupNameText.SetText(groupName);
		levelNameText.SetText(levelName);
		completeGroupText.gameObject.SetActive(value: false);
		if (levelsCompletedCount < 0)
		{
			completeGroupText.gameObject.SetActive(value: false);
		}
		else if (levelsCompletedCount >= 5)
		{
			string text = LanguagesManager.Instance.GetText("label.text.levelend.groupcompleted", "The group \"*\" is completed!");
			text = text.Replace("*", groupName);
			completeGroupText.SetText(text);
		}
		else if (levelsCompletedCount == 4)
		{
			string text2 = LanguagesManager.Instance.GetText("label.text.levelend.groupone", "There is 1 level left to complete the group \"*\"!");
			text2 = text2.Replace("*", groupName);
			completeGroupText.SetText(text2);
		}
		else
		{
			string text3 = LanguagesManager.Instance.GetText("label.text.levelend.groupmore", "There are * levels left to complete the group \"*\"!");
			text3 = text3.ReplaceFirst("*", (5 - levelsCompletedCount).ToString());
			text3 = text3.ReplaceFirst("*", groupName);
			completeGroupText.SetText(text3);
		}
		if (!string.IsNullOrEmpty(groupNameJustUnlocked))
		{
			string text4 = LanguagesManager.Instance.GetText("label.text.levelend.groupunlocked", "The level group \"*\" was unlocked!");
			text4 = text4.Replace("*", groupNameJustUnlocked);
			groupNameUnlockedText.gameObject.SetActive(value: false);
			groupNameUnlockedText.SetText(text4);
		}
		else
		{
			groupNameUnlockedText.gameObject.SetActive(value: false);
		}
	}

	public void SetTimes(float currentTime, float bestTime, bool shouldShowBestTime)
	{
		string text = LanguagesManager.Instance.GetText("label.text.levelend.besttime", "Best Time");
		currentTimeText.text = Util.TimeParser(currentTime);
		if (shouldShowBestTime)
		{
			bestTimeText.text = text + ": " + Util.TimeParser(bestTime);
		}
		bestTimeText.gameObject.SetActive(shouldShowBestTime);
		allBestTimesPanel.SetActive(value: false);
	}

	public void SetTimes(float currentTime, LevelStatus.RecordsValues lowestTimeRecords, bool shouldShowBestTime)
	{
		currentTimeText.text = Util.TimeParser(currentTime);
		if (lowestTimeRecords != null && shouldShowBestTime)
		{
			string text = LanguagesManager.Instance.GetText("label.text.levelend.newrecord", "New Record!");
			string text2 = (lowestTimeRecords.IsBothStarValueNewRecord ? ("<color=#49D949>" + text + "</color>") : string.Empty);
			string text3 = (lowestTimeRecords.IsGoldStarValueNewRecord ? ("<color=#49D949>" + text + "</color>") : string.Empty);
			string text4 = (lowestTimeRecords.IsSilverStarValueNewRecord ? ("<color=#49D949>" + text + "</color>") : string.Empty);
			string text5 = (lowestTimeRecords.IsNoneStarValueNewRecord ? ("<color=#49D949>" + text + "</color>") : string.Empty);
			string text6 = "<color=#F7EC3D>\uf005</color><color=#787878>\uf005</color>   " + Util.TimeParser(lowestTimeRecords.BothStarValue) + "      " + text2;
			string text7 = "<color=#F7EC3D>\uf005</color><color=#7878784D>\uf006</color>   " + Util.TimeParser(lowestTimeRecords.GoldStarValue) + "      " + text3;
			string text8 = "<color=#F7EC3D4D>\uf006</color><color=#787878>\uf005</color>   " + Util.TimeParser(lowestTimeRecords.SilverStarValue) + "      " + text4;
			string text9 = "<color=#F7EC3D4D>\uf006</color><color=#7878784D>\uf006</color>   " + Util.TimeParser(lowestTimeRecords.NoneStarValue) + "      " + text5;
			allBestTimesText.SetText(text6 + "\n" + text7 + "\n" + text8 + "\n" + text9);
		}
		bestTimeText.gameObject.SetActive(value: false);
		allBestTimesPanel.SetActive(shouldShowBestTime);
	}

	public void SetCollectablesStars(bool isAllGoldCollected, bool isAllSilverCollected)
	{
		string text = (isAllGoldCollected ? "<#F7EC3D>\uf005" : "<#F7EC3D4D>\uf006");
		string text2 = (isAllSilverCollected ? "<#787878>\uf005" : "<#7878784D>\uf006");
		collectablesStarsText.SetText(text + " " + text2);
	}

	public void ShowLevelCompleted(bool showNextButton)
	{
		levelDonePanel.SetActive(value: true);
		levelFailedPanel.SetActive(value: false);
		brainBlockDestroyedPanel.SetActive(value: false);
		nextButton.gameObject.SetActive(value: true);
		nextButton.interactable = showNextButton;
		finishButton.gameObject.SetActive(value: false);
		editorButton.gameObject.SetActive(value: false);
		gameManager.UIAudioEffectsManager.PlayAudio(gameManager.GameStylesData.levelSuccessfulClip, gameManager.GameStylesData.volumeStylesData.levelCompletedVolume);
	}

	public void ShowLevelFailed(bool showNextButton)
	{
		levelDonePanel.SetActive(value: false);
		levelFailedPanel.SetActive(value: true);
		brainBlockDestroyedPanel.SetActive(value: false);
		nextButton.gameObject.SetActive(value: true);
		nextButton.interactable = showNextButton;
		finishButton.gameObject.SetActive(value: false);
		editorButton.gameObject.SetActive(value: false);
		gameManager.UIAudioEffectsManager.PlayAudio(gameManager.GameStylesData.levelFailedClip, gameManager.GameStylesData.volumeStylesData.levelCompletedVolume);
	}

	public void ShowBrainBlockDestroyed(bool showNextButton)
	{
		levelDonePanel.SetActive(value: false);
		levelFailedPanel.SetActive(value: false);
		brainBlockDestroyedPanel.SetActive(value: true);
		nextButton.gameObject.SetActive(value: true);
		nextButton.interactable = showNextButton;
		finishButton.gameObject.SetActive(value: false);
		editorButton.gameObject.SetActive(value: false);
		gameManager.UIAudioEffectsManager.PlayAudio(gameManager.GameStylesData.levelFailedClip, gameManager.GameStylesData.volumeStylesData.levelCompletedVolume);
	}

	public void ShowFinishButton()
	{
		nextButton.gameObject.SetActive(value: false);
		finishButton.gameObject.SetActive(value: true);
	}

	public void ShowEditorButton()
	{
		nextButton.gameObject.SetActive(value: false);
		editorButton.gameObject.SetActive(value: true);
	}

	public void SetReplayButtonInteractive(bool isInteractable)
	{
		replayButton.interactable = isInteractable;
	}

	public void SetLeaderboardsButtonVisibility(bool isVisible)
	{
		leaderboardsButton.gameObject.SetActive(isVisible);
	}

	public void SetLeaderboardsButtonInteractive(bool isInteractable)
	{
		leaderboardsButton.interactable = isInteractable;
	}

	public void SetCheatEnabledTextVisibility(bool isVisible)
	{
		cheatEnabledText.gameObject.SetActive(isVisible);
	}

	public void SetContentModifiedTextVisibility(bool isVisible)
	{
		contentModifiedText.gameObject.SetActive(isVisible);
	}

	public void SetLeaderboardsTextVisibility(bool isVisible)
	{
		leaderboardsText.gameObject.SetActive(isVisible);
	}

	public void SetLeaderboardsText(string text)
	{
		leaderboardsText.SetText(text);
	}

	public void SetLoadingIconsVisibility(bool isVisible)
	{
		loadingIconA.gameObject.SetActive(isVisible);
		loadingIconB.gameObject.SetActive(isVisible);
	}

	public void SetCollectablesStarsTextVisibility(bool isVisible)
	{
		collectablesStarsText.gameObject.SetActive(isVisible);
	}

	public void SetCollectablesUnlockedTextVisibility(bool isVisible)
	{
		collectablesUnlockedText.gameObject.SetActive(isVisible);
	}
}
