using System.Collections;
using System.Linq;
using MLCN_Localization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelProgressionSummaryScreen : MonoBehaviour
{
	[SerializeField]
	private GraphicRaycaster graphicRaycaster;

	[SerializeField]
	private GameObject content;

	[SerializeField]
	private ProgressionStatComponent[] statComponents;

	[SerializeField]
	private ProgressionStatComponent levelProgressionStat;

	[SerializeField]
	private TMP_Text labelProgressbarLevelUp;

	[SerializeField]
	private UnlockContentItemComponent[] unlockedContentItems;

	[SerializeField]
	private UIContentAnimator animatorLevelUpProgressbar;

	[SerializeField]
	private UIContentAnimator animatorLevelUpLabel;

	[SerializeField]
	private UIContentAnimator animator;

	[SerializeField]
	private GameObject contentBankruptcy;

	[SerializeField]
	private UIContentAnimator animatorBankruptcyScreen;

	[SerializeField]
	private TMP_Text labelBCTitle;

	[SerializeField]
	private TMP_Text labelBCDay;

	[SerializeField]
	private TMP_Text labelBCBalance;

	[SerializeField]
	private TMP_Text labelBCBalanceValue;

	private static LevelProgressionSummaryScreen instance;

	private bool hasEvaluated;

	private bool isFillingLevelUpBar;

	private int rounds;

	private int lvlBefore;

	private int lvlUps;

	private int leftOver;

	private float fillAlpha;

	private int unlockCounter;

	private int lastUnlocked;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
	}

	private void Start()
	{
		animator.BeginWithNormalState();
		animatorBankruptcyScreen.BeginWithNormalState();
		ProgressionManager.OnLevelUpProgress.AddListener(delegate(int lvlUps, int leftOver)
		{
			isFillingLevelUpBar = true;
			this.lvlUps = lvlUps;
			this.leftOver = leftOver;
		});
		ProgressionManager.ListenOnLevelUp(delegate
		{
			labelProgressbarLevelUp.text = LocalizationManager.GetLocalizedString("ui_menu_dailysummary_stats_label_level", LocalizationDataTable.Tables.UI) + ProgressionManager.GetCurrentLevel();
		});
		UnityAction call = delegate
		{
			CafeShopManager.ApplyUpkeep();
			WorldTime.TriggerNextDay();
			content.SetActive(value: false);
		};
		animator.OnFinishedReverse.AddListener(call);
		content.SetActive(value: false);
		contentBankruptcy.SetActive(value: false);
	}

	public static void ShowSummaryScreen()
	{
		instance.content.SetActive(value: true);
		instance.HideStats();
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.MenuOpen);
		MouseCursorInteraction.UpdateCursorState();
		instance.animator.OnPlay();
		instance.graphicRaycaster.enabled = true;
	}

	public static void ShowBankruptcyScreen()
	{
		instance.graphicRaycaster.enabled = true;
		instance.contentBankruptcy.SetActive(value: true);
		instance.labelBCDay.text = WorldTime.GetCurrentDate().day.ToString();
		instance.labelBCBalanceValue.text = WalletSystem.GetPlayerWallet().GetFormattedBudget();
		instance.HideStats();
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.MenuOpen);
		instance.animatorBankruptcyScreen.OnPlay();
	}

	public static void HideSummaryScreen()
	{
		NextDay();
	}

	public static void NextDay()
	{
		TransitionManager.TriggerState("NextDayState");
	}

	public static void HideSummary()
	{
		instance.graphicRaycaster.enabled = false;
		instance.animator.OnReverse();
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.DisableInput);
		if (!instance.hasEvaluated)
		{
			ProgressionManager.EvaluateLevelUP();
		}
	}

	public void Summarize()
	{
		instance.labelProgressbarLevelUp.text = LocalizationManager.GetLocalizedString("ui_menu_dailysummary_stats_label_level", LocalizationDataTable.Tables.UI) + ProgressionManager.GetCurrentLevel();
		instance.levelProgressionStat.GetComponent<ProgressBarComponent>().UpdateBar(ProgressionManager.GetProgressionAmount());
		instance.StartCoroutine(instance.ShowStatDelay());
	}

	private IEnumerator ShowStatDelay()
	{
		int index = 0;
		yield return new WaitForSeconds(0.5f);
		for (; index != statComponents.Length; index++)
		{
			statComponents[index].Show(ProgressionManager.GetStatValue(index));
			yield return new WaitForSeconds(0.5f);
		}
		lvlBefore = ProgressionManager.GetCurrentLevel();
		animatorLevelUpProgressbar.OnPlay();
		ProgressionManager.EvaluateLevelUP();
		isFillingLevelUpBar = true;
		leftOver = ProgressionManager.GetCurrentXP();
		hasEvaluated = true;
		levelProgressionStat.Show(ProgressionManager.GetStockedXP());
		StopAllCoroutines();
	}

	private void HideStats()
	{
		ProgressionStatComponent[] array = statComponents;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].HideAndReset();
		}
		animatorLevelUpProgressbar.BeginWithNormalState();
		animatorLevelUpLabel.BeginWithNormalState();
		HideUnlocks();
		levelProgressionStat.HideAndReset();
		isFillingLevelUpBar = false;
		rounds = 0;
		lvlBefore = 0;
		lvlUps = 0;
		leftOver = 0;
		hasEvaluated = false;
	}

	private void Update()
	{
		if (!isFillingLevelUpBar)
		{
			return;
		}
		float num = Mathf.InverseLerp(0f, ProgressionManager.GetRequiredXP(), leftOver);
		float num2 = 0f;
		if (lvlUps > 0)
		{
			if (rounds < lvlUps)
			{
				if (fillAlpha < 1f)
				{
					fillAlpha += Time.deltaTime;
				}
				else if (fillAlpha >= 1f)
				{
					fillAlpha = 0f;
					rounds++;
					ShowLevelUp(lvlBefore + rounds);
				}
				num2 = fillAlpha;
			}
			else if (fillAlpha < num)
			{
				fillAlpha += Time.deltaTime;
				float time = Mathf.InverseLerp(0f, num, fillAlpha);
				num2 = Mathf.Lerp(0f, num, levelProgressionStat.GetAnimationCurve().Evaluate(time));
			}
			else
			{
				fillAlpha = num;
				num2 = fillAlpha;
				isFillingLevelUpBar = false;
			}
		}
		else if (num > 0f)
		{
			if (fillAlpha < num)
			{
				fillAlpha += Time.deltaTime;
				float time2 = Mathf.InverseLerp(0f, num, fillAlpha);
				num2 = Mathf.Lerp(0f, num, levelProgressionStat.GetAnimationCurve().Evaluate(time2));
			}
			else
			{
				fillAlpha = num;
				num2 = fillAlpha;
				isFillingLevelUpBar = false;
			}
		}
		else
		{
			num2 = fillAlpha;
		}
		if (ProgressionManager.ReachedDemoLevel() && lvlBefore >= ProgressionManager.GetDemoMax())
		{
			labelProgressbarLevelUp.text = "Demo Max Level";
		}
		else if (lvlBefore + rounds >= ProgressionManager.GetDemoMax())
		{
			labelProgressbarLevelUp.text = "Demo Max Level";
		}
		else
		{
			labelProgressbarLevelUp.text = "Level " + (lvlBefore + rounds);
		}
		levelProgressionStat.GetComponent<ProgressBarComponent>().UpdateBar(num2);
	}

	private void ShowLevelUp(int currentLevel)
	{
		animatorLevelUpLabel.OnPlay();
		StartCoroutine(LoadUnlocks(currentLevel));
	}

	private IEnumerator LoadUnlocks(int currentLevel)
	{
		yield return new WaitForSeconds(0.25f);
		UnlockOption[] unlocks = ProgressionManager.GetUnlocks();
		UnlockOption[] array = unlocks.ToList().FindAll((UnlockOption x) => x.IsUnlocked() && x.GetUnlockLevel() == currentLevel).ToArray();
		if (array.Length != 0)
		{
			Vector3 vector = new Vector3(unlockedContentItems[0].GetComponent<RectTransform>().sizeDelta.x * 0.5f + 20f, 0f, 0f);
			for (int num = 0; num < unlocks.Length; num++)
			{
				if (unlocks[num].IsUnlocked() && currentLevel == unlocks[num].GetUnlockLevel())
				{
					unlockCounter++;
					unlockedContentItems[num].AddOffset(vector * (unlockCounter - 1));
					unlockedContentItems[num].Show();
					lastUnlocked = num;
				}
			}
			bool flag = true;
			for (int num2 = 0; num2 < unlocks.Length; num2++)
			{
				if (unlocks[num2].IsUnlocked() && currentLevel >= unlocks[num2].GetUnlockLevel() && lastUnlocked != num2)
				{
					int num3 = array.Length;
					if (num3 > 1 && !array.Contains(unlocks[num2]))
					{
						unlockedContentItems[num2].AddOffset(vector * -num3);
					}
					else
					{
						unlockedContentItems[num2].AddOffset(vector * -1f);
					}
					if (num3 > 2 && array.Contains(unlocks[num2]) && flag)
					{
						unlockedContentItems[num2].AddOffset(vector * -1f);
						flag = false;
					}
					unlockedContentItems[num2].Show();
				}
			}
		}
		StopCoroutine(LoadUnlocks(currentLevel));
	}

	private void HideUnlocks()
	{
		for (int i = 0; i < unlockedContentItems.Length; i++)
		{
			unlockedContentItems[i].Hide();
			unlockedContentItems[i].ResetPosition();
		}
		ProgressionManager.ResetUnlocks();
	}
}
