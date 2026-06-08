using System.Collections.Generic;
using UnityEngine;

public class CultMaskGoals : LostItemGoals
{
	private UniqueFoesGoalUI uniqueDebuffsGoalUI;

	private float realtimeAbilityActivatedWithStonescript;

	public List<string> uniqueDebuffIDs { get; set; }

	public static CultMaskGoals singleton { get; private set; }

	public override List<string> GetTexts()
	{
		List<string> texts = base.GetTexts();
		texts.Add(Te.xt("tid_info_mask_1").Trim());
		texts.Add(Te.xt("tid_info_mask_2").Trim());
		texts.Add(Te.xt("tid_info_mask_3").Trim());
		texts.Add(Te.xt("tid_info_mask_4").Trim());
		texts.Add(Te.xt("tid_info_mask_5").Trim());
		FormatProgressThresholds(texts);
		return texts;
	}

	public override AsciiObject GetSupportingUIElement(int goalNumber)
	{
		switch (goalNumber)
		{
		case 2:
		{
			if (uniqueDebuffsGoalUI == null)
			{
				uniqueDebuffsGoalUI = base.gameObject.AddComponent<UniqueFoesGoalUI>();
			}
			int totalFoeCount = progressThresholds[goalNumber];
			uniqueDebuffsGoalUI.Setup(uniqueDebuffIDs, totalFoeCount);
			return uniqueDebuffsGoalUI;
		}
		case 3:
			return BaseGoals.MakeHyperlinkUIElement("Learn More", "https://steamcommunity.com/app/603390/discussions/0/3194747223937190668/");
		default:
			return base.GetSupportingUIElement(goalNumber);
		}
	}

	public override void SetGoal(int newGoal)
	{
		if (EventController.singleton.IsEventActiveAndStarted("the_initiate"))
		{
			TheInitiateEventController.singleton.part = newGoal;
			if (newGoal > base.goalCount)
			{
				TheInitiateEventController.singleton.MarkRewardCompleted();
			}
		}
		switch (base.goal.GetValue())
		{
		case 1:
			GameStates.Singleton.abilityActivationHUD.OnActivated -= ReportAbilityActivated1;
			break;
		case 2:
			StatModController.OnDebuffAdded -= HandleDebuffAdded;
			break;
		case 3:
			GameStates.Singleton.abilityActivationHUD.OnActivated -= ReportAbilityActivated3;
			Character.OnCharacterTookDamage -= ReportEnemyTookDamage;
			break;
		case 4:
			Character.OnCharacterTookDamage -= ReportPlayerTookDamage;
			break;
		default:
			_ = 5;
			break;
		}
		base.SetGoal(newGoal);
		switch (newGoal)
		{
		case 1:
			GameStates.Singleton.abilityActivationHUD.OnActivated += ReportAbilityActivated1;
			break;
		case 2:
			StatModController.OnDebuffAdded += HandleDebuffAdded;
			break;
		case 3:
			GameStates.Singleton.abilityActivationHUD.OnActivated += ReportAbilityActivated3;
			Character.OnCharacterTookDamage += ReportEnemyTookDamage;
			break;
		case 4:
			Character.OnCharacterTookDamage += ReportPlayerTookDamage;
			break;
		default:
			_ = 5;
			break;
		}
	}

	private void ReportAbilityActivated1(IAbilityActivationProvider provider, SuperAbilityActivationState activationState, bool withStonescript)
	{
		if (provider.GetId() == "mask")
		{
			ImproveProgress();
		}
	}

	private void HandleDebuffAdded(Character c, DebuffStatMod debuff)
	{
		Hero hero = GameStates.Singleton.hero;
		if (!(c != hero) || !(c != null) || !(debuff != null) || debuff.isPositiveBuff)
		{
			return;
		}
		if (uniqueDebuffIDs == null)
		{
			uniqueDebuffIDs = new List<string>();
		}
		if (!(hero.RightHand != null) || !(hero.RightHand.id == "cult_mask"))
		{
			return;
		}
		if (!uniqueDebuffIDs.Contains(debuff.id))
		{
			uniqueDebuffIDs.Add(debuff.id);
			ImproveProgress();
			return;
		}
		int value = base.progress.GetValue();
		if (uniqueDebuffIDs.Count > value)
		{
			ImproveProgress(uniqueDebuffIDs.Count - value);
		}
	}

	private void ReportAbilityActivated3(IAbilityActivationProvider provider, SuperAbilityActivationState activationState, bool withStonescript)
	{
		if (withStonescript && provider.GetId() == "mask")
		{
			realtimeAbilityActivatedWithStonescript = Time.realtimeSinceStartup;
		}
	}

	private void ReportEnemyTookDamage(Character c, Damage dmg)
	{
		if (!(Time.realtimeSinceStartup - realtimeAbilityActivatedWithStonescript > 4f) && c != GameStates.Singleton.hero && dmg.tags != null && dmg.tags.Contains("nagaraja"))
		{
			int num = dmg.amount;
			if (c.Hitpoints < 0)
			{
				num += c.Hitpoints;
			}
			if (num > 0)
			{
				ImproveProgress(num);
			}
		}
	}

	private void ReportPlayerTookDamage(Character c, Damage dmg)
	{
		if (!(c == GameStates.Singleton.hero) || !(dmg.Owner != null) || !(dmg.Owner.statModController != null) || dmg.Owner.statModController.debuffs == null)
		{
			return;
		}
		for (int i = 0; i < dmg.Owner.statModController.debuffs.Count; i++)
		{
			List<StatModifier> list = dmg.Owner.statModController.debuffs[i];
			if (list[0].id == "debuff_feeble")
			{
				int pointsGained = list.Count * 2;
				ImproveProgress(pointsGained);
				break;
			}
		}
	}

	public void ReportBuffExtended()
	{
		if (base.goal.GetValue() == 5)
		{
			ImproveProgress();
		}
	}

	private void Awake()
	{
		singleton = this;
	}

	public override void ClearProgress()
	{
		base.ClearProgress();
		uniqueDebuffIDs = null;
	}

	public override void SerializeMore()
	{
		base.SerializeMore();
		if (uniqueDebuffIDs != null && base.goal.GetValue() == 2)
		{
			SlimJson.AddProperty("uniqueDebuffIDs", uniqueDebuffIDs.ToArray());
		}
	}

	public override void ParseMore(string sjson)
	{
		base.ParseMore(sjson);
		if (SlimJson.HasKey(sjson, "uniqueDebuffIDs"))
		{
			string[] collection = SlimJson.ParseArray(sjson, "uniqueDebuffIDs");
			uniqueDebuffIDs = new List<string>(collection);
		}
		else
		{
			uniqueDebuffIDs = null;
		}
	}
}
