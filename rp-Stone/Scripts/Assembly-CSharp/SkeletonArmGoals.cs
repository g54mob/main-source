using System.Collections.Generic;
using UnityEngine;

public class SkeletonArmGoals : LostItemGoals
{
	private AllRunesGoalUI allRunesGoalUI;

	private int runestoneProgress;

	private float realtimeAbilityActivatedWithStonescript;

	public static SkeletonArmGoals singleton { get; private set; }

	public override List<string> GetTexts()
	{
		List<string> texts = base.GetTexts();
		texts.Add(Te.xt("tid_info_wild_ride_1").Trim());
		texts.Add(Te.xt("tid_info_wild_ride_2").Trim());
		texts.Add(Te.xt("tid_info_wild_ride_3").Trim());
		texts.Add(Te.xt("tid_info_wild_ride_4").Trim());
		FormatProgressThresholds(texts);
		return texts;
	}

	public override AsciiObject GetSupportingUIElement(int goalNumber)
	{
		switch (goalNumber)
		{
		case 3:
			if (allRunesGoalUI == null)
			{
				allRunesGoalUI = base.gameObject.AddComponent<AllRunesGoalUI>();
				allRunesGoalUI.PositionX = 8;
			}
			allRunesGoalUI.mask = runestoneProgress;
			return allRunesGoalUI;
		case 4:
			return BaseGoals.MakeHyperlinkUIElement("Learn More", "https://steamcommunity.com/app/603390/discussions/0/2961670721743547882/");
		default:
			return base.GetSupportingUIElement(goalNumber);
		}
	}

	public override void SetGoal(int newGoal)
	{
		switch (base.goal.GetValue())
		{
		case 2:
			Character.OnCharacterEvaded -= ReportEvaded;
			break;
		case 3:
			runestoneProgress = 0;
			break;
		case 4:
			GameStates.Singleton.abilityActivationHUD.OnActivated -= ReportAbilityActivated;
			Character.OnCharacterDied -= ReportEnemyKilled;
			break;
		}
		base.SetGoal(newGoal);
		switch (newGoal)
		{
		case 2:
			Character.OnCharacterEvaded += ReportEvaded;
			break;
		case 4:
			GameStates.Singleton.abilityActivationHUD.OnActivated += ReportAbilityActivated;
			Character.OnCharacterDied += ReportEnemyKilled;
			break;
		}
	}

	public void ReportPickPocketGained()
	{
		if (base.goal.GetValue() == 1)
		{
			ImproveProgress();
		}
	}

	public void ReportEvaded(Character c, Bullet b)
	{
		if (c != GameStates.Singleton.hero || c.statModController == null || c.statModController.debuffs == null || b.Owner == null || !b.Owner.tags.Contains("boss"))
		{
			return;
		}
		bool flag = false;
		List<List<StatModifier>> debuffs = c.statModController.debuffs;
		for (int i = 0; i < debuffs.Count; i++)
		{
			List<StatModifier> list = debuffs[i];
			if (list.Count > 0 && list[0].id == "pick_pocket")
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			ImproveProgress();
		}
	}

	public void ReportItemStolen(Item item)
	{
		if (base.goal.GetValue() == 3 && !(item.id != "runestone"))
		{
			int num = 0;
			if (item.element == ItemData.Element.Vigor)
			{
				num = 1;
			}
			else if (item.element == ItemData.Element.AEther)
			{
				num = 2;
			}
			else if (item.element == ItemData.Element.Fire)
			{
				num = 3;
			}
			else if (item.element == ItemData.Element.Ice)
			{
				num = 4;
			}
			int num2 = 1 << num;
			if ((runestoneProgress & num2) == 0)
			{
				runestoneProgress |= num2;
				ImproveProgress();
			}
		}
	}

	private void ReportAbilityActivated(IAbilityActivationProvider provider, SuperAbilityActivationState activationState, bool withStonescript)
	{
		if (withStonescript && provider.GetId() == "skeleton_arm")
		{
			realtimeAbilityActivatedWithStonescript = Time.realtimeSinceStartup;
		}
	}

	public void ReportEnemyKilled(Character c, Character.DeathReason reason, Damage dmg)
	{
		if (!(Time.realtimeSinceStartup - realtimeAbilityActivatedWithStonescript > 4f) && dmg != null && dmg.bullet != null && dmg.bullet.tags.Contains("pick_pocket") && dmg.bullet.tags.Contains("activated_ability"))
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
		runestoneProgress = 0;
	}

	public override void SerializeMore()
	{
		if (runestoneProgress != 0)
		{
			SlimJson.AddProperty("runestones", runestoneProgress);
		}
	}

	public override void ParseMore(string sjson)
	{
		runestoneProgress = SlimJson.ParseInt(sjson, "runestones");
	}
}
