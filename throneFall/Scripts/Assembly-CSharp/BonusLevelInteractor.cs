using I2.Loc;
using TMPro;
using UnityEngine;

public class BonusLevelInteractor : InteractorBase
{
	public static BonusLevelInteractor lastSelected;

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
	private TMP_Text questsComplete;

	[SerializeField]
	private TextMeshProUGUI challengeName;

	public LevelInfo[] levelsToPick;

	[Header("Level Info")]
	public LevelInfo baseLevelInfo;

	public LevelInfo levelToBeatToUnlock;

	[Header("Colors")]
	[SerializeField]
	private Color allQuestComplete;

	[SerializeField]
	private Color notAllQuestComplete;

	public bool CanBePlayed
	{
		get
		{
			if (levelToBeatToUnlock != null && !levelToBeatToUnlock.Beaten)
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
			if ((bool)levelToBeatToUnlock && !levelToBeatToUnlock.Beaten)
			{
				return TextTranslator.TranslateAndInsertMapName("Menu/Beat Map to Unlock Cue", levelToBeatToUnlock.displayName.ToString(), highlighted: true);
			}
			return "";
		}
	}

	public void UpdateVisualsOnStart()
	{
		if (myLevelData == null)
		{
			levelProgressManager = LevelProgressManager.instance;
			myLevelData = levelProgressManager.GetLevelDataForScene(baseLevelInfo.sceneName);
		}
		lockedLevelVisuals.SetActive(value: false);
		unlockedLevelVisuals.SetActive(value: false);
		beatenLevelVisuals.SetActive(value: false);
		questsComplete.transform.parent.gameObject.SetActive(value: false);
		int num = 0;
		int num2 = 0;
		LevelInfo[] array = levelsToPick;
		foreach (LevelInfo levelInfo in array)
		{
			num += levelInfo.QuestsTotal();
			num2 += levelInfo.QuestsComplete();
		}
		questsComplete.text = num2 + "/" + num;
		questsComplete.color = ((num2 >= num) ? allQuestComplete : notAllQuestComplete);
		if (challengeName != null)
		{
			challengeName.text = LocalizationManager.GetTermTranslation("Menu/Bonus Modes");
		}
		if (!CanBePlayed)
		{
			lockedLevelVisuals.SetActive(value: true);
			return;
		}
		if (num2 >= num)
		{
			beatenLevelVisuals.SetActive(value: true);
		}
		else
		{
			unlockedLevelVisuals.SetActive(value: true);
		}
		questsComplete.transform.parent.gameObject.SetActive(value: true);
	}

	private void Start()
	{
		levelSelectManager = GetComponentInParent<LevelSelectManager>();
		levelProgressManager = LevelProgressManager.instance;
		myLevelData = levelProgressManager.GetLevelDataForScene(baseLevelInfo.sceneName);
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
		return baseLevelInfo.LocalizedDisplayName;
	}

	public override void InteractionBegin(PlayerInteraction _player)
	{
		if (CanBePlayed)
		{
			lastSelected = this;
			lastActiveLevelInfo = baseLevelInfo;
			if (!InGamePopUpHelper.instance || !InGamePopUpHelper.instance.PopMiniModes())
			{
				UIFrameManager.TryOpenBonusLevelSelect();
			}
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
				challengeName.text = LocalizationManager.GetTermTranslation("Menu/Bonus Modes");
			}
			return;
		}
		cantBePlayedCue.text = GenerateCueText();
		cantBePlayedPanel.SetActive(value: true);
		focusPanel.SetActive(value: false);
		if (challengeName != null)
		{
			challengeName.text = LocalizationManager.GetTermTranslation("Menu/Bonus Modes");
		}
	}

	public override void Unfocus(PlayerInteraction _player)
	{
		focusPanel.SetActive(value: false);
		cantBePlayedPanel.SetActive(value: false);
	}
}
