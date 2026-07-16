using System.Collections;
using MLCN_Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextDayTransitionState : TransitionState
{
	[Header("Animators")]
	[SerializeField]
	private UIContentAnimator transitionDayCounter;

	[SerializeField]
	private UIContentAnimator transitionBudget;

	[SerializeField]
	private UIContentAnimator transitionBudgetUpkeepRemoval;

	[Header("Day Properties")]
	[SerializeField]
	private float transitionDurationDayCounter = 4f;

	[SerializeField]
	private TMP_Text labelDayCounter;

	[SerializeField]
	private Color colorChangedDay;

	[SerializeField]
	private string soundOnDayChange;

	[Header("Labels")]
	[SerializeField]
	private TMP_Text labelBudget;

	[SerializeField]
	private TMP_Text labelUpkeep;

	[SerializeField]
	private TMP_Text labelTurnover;

	[SerializeField]
	private TMP_Text labelTips;

	[Header("Game Save Message Properties")]
	[SerializeField]
	private UIContentAnimator transitionGameSavedMessage;

	[SerializeField]
	private TMP_Text labelGameSaved;

	[SerializeField]
	private Image iconSaving;

	[SerializeField]
	private Sprite[] spritesSavingProgress;

	[SerializeField]
	private string isSaving;

	[SerializeField]
	private string hasSaved;

	[SerializeField]
	private Color colorIsSaving;

	[SerializeField]
	private Color colorSaved;

	[SerializeField]
	private string soundSaved;

	private bool finishedDaySwitch;

	private bool finishedGameSave;

	public override void OnStart()
	{
		transitionDayCounter.SetFadeTime(transitionDurationDayCounter);
		transitionGameSavedMessage.BeginWithNormalState();
		DataPersistenceManager.OnGameSaveFinished.AddListener(UpdateGameSavedLabel);
	}

	public override void OnEnter()
	{
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.DisableInput);
		MouseCursorInteraction.UpdateCursorState();
		finishedGameSave = false;
		finishedDaySwitch = false;
		transitionDayCounter.OnPlay();
		UpdateDayLabels();
	}

	public override void OnExit()
	{
		TransitionManager.TriggerTransitionExit(2f);
	}

	public override void OnUpdate()
	{
	}

	public override bool ExitCondition()
	{
		if (GameModeManager.GetCurrentGameMode() > 0 && DarkRoomManager.CheckDarkRoomEvent())
		{
			targetState = manager.GetStateByName("DarkRoom");
		}
		else
		{
			targetState = manager.fallbackState;
		}
		if (finishedDaySwitch)
		{
			return finishedGameSave;
		}
		return false;
	}

	public void UpdateDay()
	{
		StartCoroutine(TransitionDay());
	}

	private IEnumerator TransitionDay()
	{
		labelUpkeep.text = " -" + Wallet.FormatBudget(CafeShopManager.GetDailyUpkeep());
		ShowGameSavedLabel();
		yield return new WaitForSeconds(transitionDurationDayCounter / 2f);
		UpdateDayLabels();
		SoundManager.PlaySoundOnce(soundOnDayChange);
		StopCoroutine(TransitionDay());
		WorldTime.instance.OnFinishedLoadNewDay.Invoke();
		yield return new WaitForSeconds(1f);
		transitionBudget.SetFadeTime(1f);
		transitionBudget.OnReverse();
		transitionBudgetUpkeepRemoval.SetFadeTime(1f);
		transitionBudgetUpkeepRemoval.OnReverse();
		yield return new WaitForSeconds(1f);
		CafeShopManager.ResetFinanceStats();
		transitionDayCounter.OnReverse();
		finishedDaySwitch = true;
	}

	private void UpdateDayLabels()
	{
		string text = ColorUtility.ToHtmlStringRGB(colorChangedDay);
		labelDayCounter.text = LocalizationManager.GetLocalizedString("ui_menu_common_label_day", LocalizationDataTable.Tables.UI) + " <color=#" + text + ">" + WorldTime.GetCurrentDate().day + "</color>";
		labelBudget.text = WalletSystem.GetPlayerWallet().GetFormattedBudget();
		labelTurnover.text = CafeShopManager.GetTurnOverNoTip();
		labelTips.text = CafeShopManager.GetTips();
	}

	public void ShowGameSavedLabel()
	{
		transitionGameSavedMessage.OnPlay();
		labelGameSaved.text = LocalizationManager.GetLocalizedString(isSaving, LocalizationDataTable.Tables.UI);
		iconSaving.GetComponent<Animator>().enabled = true;
		iconSaving.sprite = spritesSavingProgress[0];
		iconSaving.color = colorIsSaving;
		labelGameSaved.color = colorIsSaving;
	}

	public void UpdateGameSavedLabel()
	{
		labelGameSaved.text = LocalizationManager.GetLocalizedString(hasSaved, LocalizationDataTable.Tables.UI);
		iconSaving.GetComponent<Animator>().enabled = false;
		iconSaving.sprite = spritesSavingProgress[1];
		iconSaving.transform.rotation = Quaternion.identity;
		iconSaving.color = colorSaved;
		labelGameSaved.color = colorSaved;
		SoundManager.PlaySoundOnce(soundSaved);
		TweenerManager.TweenTimeAction("delayHideGameSavedMessage", 1f, HideGameSavedLabel);
	}

	public void HideGameSavedLabel()
	{
		transitionGameSavedMessage.OnReverse();
		finishedGameSave = true;
	}
}
