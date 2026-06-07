using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelInteractor : InteractorBase
{
	public static LevelInfo lastActiveLevelInfo;

	private LevelSelectManager levelSelectManager;

	private LevelProgressManager levelProgressManager;

	private LevelData myLevelData;

	[Header("Setup")]
	[SerializeField]
	private string tooltipThisLevelMustBeBeaten = "Beat <lvlname> to unlock this level.";

	[SerializeField]
	private GameObject focusPanel;

	[SerializeField]
	private GameObject cantBePlayedPanel;

	[SerializeField]
	private TextMeshProUGUI cantBePlayedCue;

	[SerializeField]
	private GameObject lockedLevelVisuals;

	[SerializeField]
	private GameObject unlockedLevelVisuals;

	[SerializeField]
	private GameObject beatenLevelVisuals;

	[SerializeField]
	private Transform rewardBuildingsParent;

	[SerializeField]
	private TMP_Text questsComplete;

	[SerializeField]
	private TextMeshProUGUI challengeName;

	[Header("Colors")]
	[SerializeField]
	private Color allQuestComplete;

	[SerializeField]
	private Color notAllQuestComplete;

	[Header("Level Info")]
	public LevelInfo levelInfo;

	public Vector3 PlayerTeleportPosition => unlockedLevelVisuals.transform.position;

	public List<Quest> Quests => levelInfo.quests;

	public bool CanBePlayed
	{
		get
		{
			if (levelInfo.unlockRequirement != null && !levelInfo.unlockRequirement.Beaten)
			{
				return false;
			}
			return true;
		}
	}

	public string CanNotBePlayedReason
	{
		get
		{
			if ((bool)levelInfo.unlockRequirement && !levelInfo.unlockRequirement.Beaten)
			{
				return TextTranslator.TranslateAndInsertMapName("Menu/Beat Map to Unlock Cue", levelInfo.unlockRequirement.displayName.ToString(), highlighted: true);
			}
			return "";
		}
	}

	public void UpdateVisualsOnStart()
	{
		if (myLevelData == null)
		{
			levelProgressManager = LevelProgressManager.instance;
			myLevelData = levelProgressManager.GetLevelDataForScene(levelInfo.sceneName);
		}
		lockedLevelVisuals.SetActive(value: false);
		unlockedLevelVisuals.SetActive(value: false);
		beatenLevelVisuals.SetActive(value: false);
		questsComplete.transform.parent.gameObject.SetActive(value: false);
		questsComplete.text = QuestsBeatenString();
		int num = levelInfo.QuestsComplete();
		if (num == levelInfo.QuestsTotal())
		{
			AchievementManager.LevelAllQuestsComplete(levelInfo.sceneName);
		}
		if (myLevelData.beatenBest)
		{
			AchievementManager.LevelBeaten(levelInfo.sceneName);
		}
		questsComplete.color = ((num >= levelInfo.QuestsTotal()) ? allQuestComplete : notAllQuestComplete);
		float num2 = (float)num / (float)levelInfo.QuestsTotal();
		int a = Mathf.FloorToInt((float)rewardBuildingsParent.childCount * (float)myLevelData.questsCompleteWhenLastVisitingMap / (float)levelInfo.QuestsTotal());
		int num3 = Mathf.FloorToInt((float)rewardBuildingsParent.childCount * num2);
		a = Mathf.Min(a, num3);
		myLevelData.questsCompleteWhenLastVisitingMap = num3;
		StartCoroutine(EnableBuildingsCoroutine(a, num3, 0.75f, 0.5f));
		if (challengeName != null)
		{
			challengeName.text = levelInfo.displaySubtitle;
		}
		if (!CanBePlayed)
		{
			lockedLevelVisuals.SetActive(value: true);
			return;
		}
		questsComplete.transform.parent.gameObject.SetActive(value: true);
		if (!levelInfo.Beaten)
		{
			unlockedLevelVisuals.SetActive(value: true);
		}
		else
		{
			beatenLevelVisuals.SetActive(value: true);
		}
	}

	private IEnumerator EnableBuildingsCoroutine(int _enabledBuildings, int _enabledBuildingsUpTo, float _initialDelay, float _interval)
	{
		if (rewardBuildingsParent.childCount < _enabledBuildingsUpTo)
		{
			Debug.LogWarning("Not enough children in the rewardBuildingsParent to satisfy enabledBuildingsUpTo");
			yield break;
		}
		if (rewardBuildingsParent.childCount < _enabledBuildings)
		{
			Debug.LogWarning("Not enough children in the rewardBuildingsParent to satisfy enabledBuildings");
			yield break;
		}
		for (int i = 0; i < rewardBuildingsParent.childCount; i++)
		{
			rewardBuildingsParent.GetChild(i).gameObject.SetActive(value: false);
		}
		for (int j = 0; j < _enabledBuildings; j++)
		{
			rewardBuildingsParent.GetChild(j).gameObject.SetActive(value: true);
		}
		yield return new WaitForSeconds(_initialDelay);
		for (int k = _enabledBuildings; k < _enabledBuildingsUpTo; k++)
		{
			rewardBuildingsParent.GetChild(k).gameObject.SetActive(value: true);
			rewardBuildingsParent.GetChild(k).GetChild(0).gameObject.SetActive(value: true);
			yield return new WaitForSeconds(_interval);
		}
	}

	private void Start()
	{
		if (!LevelProgressManager.SceneExists(levelInfo.sceneName))
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		levelSelectManager = GetComponentInParent<LevelSelectManager>();
		levelProgressManager = LevelProgressManager.instance;
		myLevelData = levelProgressManager.GetLevelDataForScene(levelInfo.sceneName);
		focusPanel.SetActive(value: false);
		cantBePlayedPanel.SetActive(value: false);
		UpdateVisualsOnStart();
	}

	public override string ReturnTooltip()
	{
		if (CanBePlayed)
		{
			return TextTranslator.Translate("Menu/Level Interactor Cue");
		}
		return "";
	}

	private string GenerateCueText()
	{
		if (!CanBePlayed)
		{
			return CanNotBePlayedReason;
		}
		if (levelSelectManager.PreLevelMenuIsOpen)
		{
			return "";
		}
		return levelInfo.LocalizedDisplayName;
	}

	public override void InteractionBegin(PlayerInteraction _player)
	{
		if (CanBePlayed)
		{
			lastActiveLevelInfo = levelInfo;
			UIFrameManager.TryOpenLevelSelect();
		}
	}

	public override void Focus(PlayerInteraction _player)
	{
		if (CanBePlayed)
		{
			focusPanel.SetActive(value: true);
			cantBePlayedPanel.SetActive(value: false);
			if (challengeName != null)
			{
				challengeName.text = levelInfo.displaySubtitle;
			}
			return;
		}
		cantBePlayedCue.text = GenerateCueText();
		cantBePlayedPanel.SetActive(value: true);
		focusPanel.SetActive(value: false);
		if (challengeName != null)
		{
			challengeName.text = levelInfo.displaySubtitle;
		}
	}

	public override void Unfocus(PlayerInteraction _player)
	{
		focusPanel.SetActive(value: false);
		cantBePlayedPanel.SetActive(value: false);
	}

	public string QuestsBeatenString()
	{
		return levelInfo.QuestsComplete() + "/" + levelInfo.QuestsTotal();
	}
}
