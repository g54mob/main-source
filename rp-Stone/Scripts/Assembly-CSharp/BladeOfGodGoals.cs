using System.Collections.Generic;
using UnityEngine;

public class BladeOfGodGoals : LostItemGoals
{
	public UniqueFoesGoalUI uniqueFoesGoalPrefab;

	private UniqueFoesGoalUI uniqueFoesGoalUI;

	private int part2EnemiesKilledCount;

	private float realtimeAbilityActivatedWithStonescript;

	public List<string> uniqueFoeIDs { get; set; }

	public List<string> uniqueFoeNames { get; set; }

	public static BladeOfGodGoals singleton { get; private set; }

	public override List<string> GetTexts()
	{
		List<string> texts = base.GetTexts();
		texts.Add(Te.xt("tid_info_titanic_1").Trim());
		texts.Add(Te.xt("tid_info_titanic_2").Trim());
		texts.Add(Te.xt("tid_info_titanic_3").Trim());
		texts.Add(Te.xt("tid_info_titanic_4").Trim());
		FormatProgressThresholds(texts);
		return texts;
	}

	public override AsciiObject GetSupportingUIElement(int goalNumber)
	{
		switch (goalNumber)
		{
		case 2:
		{
			if (uniqueFoesGoalUI == null)
			{
				uniqueFoesGoalUI = Object.Instantiate(uniqueFoesGoalPrefab);
				uniqueFoesGoalUI.sourcePrefab = uniqueFoesGoalPrefab;
			}
			int totalFoeCount = progressThresholds[goalNumber];
			uniqueFoesGoalUI.Setup(uniqueFoeNames, totalFoeCount);
			return uniqueFoesGoalUI;
		}
		case 3:
			return BaseGoals.MakeHyperlinkUIElement("Learn More", "https://steamcommunity.com/app/603390/discussions/0/3122676324260194659/");
		default:
			return base.GetSupportingUIElement(goalNumber);
		}
	}

	public override void SetGoal(int newGoal)
	{
		switch (base.goal.GetValue())
		{
		case 1:
			Character.OnCharacterDied -= ReportEnemyKilled;
			break;
		case 3:
			GameStates.Singleton.abilityActivationHUD.OnActivated -= ReportAbilityActivated;
			break;
		default:
			_ = 4;
			break;
		case 2:
			break;
		}
		base.SetGoal(newGoal);
		switch (newGoal)
		{
		case 1:
			Character.OnCharacterDied += ReportEnemyKilled;
			break;
		case 3:
			GameStates.Singleton.abilityActivationHUD.OnActivated += ReportAbilityActivated;
			break;
		default:
			_ = 4;
			break;
		case 2:
			break;
		}
	}

	public void ReportEnemyKilled(Character c, Character.DeathReason reason, Damage dmg)
	{
		if (!(c == null) && c.id != null && c.id.StartsWith("spider_boss") && dmg != null && dmg.bullet != null && dmg.bullet.weapon != null && dmg.bullet.weapon.id == "blade_of_god")
		{
			ImproveProgress();
		}
	}

	public void ReportEnemyKilledWithBladeSuperAttack(Character c)
	{
		if (base.goal.GetValue() != 2)
		{
			return;
		}
		if (uniqueFoeIDs == null)
		{
			uniqueFoeIDs = new List<string>();
			uniqueFoeNames = new List<string>();
		}
		if (uniqueFoeIDs.Contains(c.id))
		{
			int value = base.progress.GetValue();
			if (uniqueFoeIDs.Count > value)
			{
				ImproveProgress(uniqueFoeIDs.Count - value);
			}
		}
		else
		{
			uniqueFoeIDs.Add(c.id);
			uniqueFoeNames.Add(c.displayName);
			uniqueFoeNames.Sort();
			part2EnemiesKilledCount++;
		}
	}

	public void ReportAbilityActivated(IAbilityActivationProvider provider, SuperAbilityActivationState activationState, bool withStonescript)
	{
		if (withStonescript && provider.GetId() == "blade")
		{
			realtimeAbilityActivatedWithStonescript = Time.realtimeSinceStartup;
		}
	}

	public void ReportSmiteGained(int count)
	{
		int value = base.goal.GetValue();
		if (value == 2 && part2EnemiesKilledCount > 0)
		{
			ImproveProgress(part2EnemiesKilledCount);
			part2EnemiesKilledCount = 0;
		}
		if (value == 3 && count > 0 && !(Time.realtimeSinceStartup - realtimeAbilityActivatedWithStonescript > 4f))
		{
			ImproveProgress(count);
		}
	}

	public void ReportSmiteDamage(int damageAmount, Damage dmg, int foeHealthBeforeSmite, Character c)
	{
		if (base.goal.GetValue() == 4 && dmg.startHitpoints > 0)
		{
			int num = dmg.amount;
			if (dmg.endHitpoints < 0)
			{
				num += dmg.endHitpoints;
			}
			ImproveProgress(num);
		}
	}

	private void Awake()
	{
		singleton = this;
	}

	public override void ClearProgress()
	{
		base.ClearProgress();
		uniqueFoeIDs = null;
		uniqueFoeNames = null;
	}

	public override void SerializeMore()
	{
		base.SerializeMore();
		if (uniqueFoeIDs != null && base.goal.GetValue() == 2)
		{
			SlimJson.AddProperty("uniqueFoeIDs", uniqueFoeIDs.ToArray());
			SlimJson.AddProperty("uniqueFoeNames", uniqueFoeNames.ToArray());
		}
	}

	public override void ParseMore(string sjson)
	{
		base.ParseMore(sjson);
		if (SlimJson.HasKey(sjson, "uniqueFoeIDs"))
		{
			string[] collection = SlimJson.ParseArray(sjson, "uniqueFoeIDs");
			string[] collection2 = SlimJson.ParseArray(sjson, "uniqueFoeNames");
			uniqueFoeIDs = new List<string>(collection);
			uniqueFoeNames = new List<string>(collection2);
		}
		else
		{
			uniqueFoeIDs = null;
			uniqueFoeNames = null;
		}
	}
}
