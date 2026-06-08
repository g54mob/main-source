using System.Collections.Generic;
using UnityEngine;

public class FireTalismanGoals : LostItemGoals
{
	public UniqueFoesGoalUI uniqueFoesGoalPrefab;

	private UniqueFoesGoalUI uniqueFoesGoalUI;

	public List<string> uniqueFoeIDs { get; set; }

	public List<string> uniqueFoeNames { get; set; }

	public override List<string> GetTexts()
	{
		List<string> texts = base.GetTexts();
		texts.Add(Te.xt("tid_info_blow_1").Trim());
		texts.Add(Te.xt("tid_info_blow_2").Trim());
		texts.Add(Te.xt("tid_info_blow_3").Trim());
		texts.Add(Te.xt("tid_info_blow_4").Trim());
		texts.Add(Te.xt("tid_info_blow_5").Trim());
		FormatProgressThresholds(texts);
		return texts;
	}

	public override AsciiObject GetSupportingUIElement(int goalNumber)
	{
		if (goalNumber == 3)
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
		return base.GetSupportingUIElement(goalNumber);
	}

	public override void SetGoal(int newGoal)
	{
		switch (base.goal.GetValue())
		{
		case 1:
			Character.OnCharacterDamagePrevented -= HandleDamagePrevented;
			break;
		case 2:
			Summon.OnSummonSummoned -= HandleSummonSummoned;
			break;
		case 3:
			StatModController.OnDebuffAdded -= HandleDebuffAdded;
			break;
		case 4:
			Character.OnCharacterTookDamage -= HandleCharacterTookDamage_Part4;
			break;
		case 5:
			Character.OnCharacterTookDamage -= HandleCharacterTookDamage_Part5;
			break;
		}
		base.SetGoal(newGoal);
		switch (newGoal)
		{
		case 1:
			Character.OnCharacterDamagePrevented += HandleDamagePrevented;
			break;
		case 2:
			Summon.OnSummonSummoned += HandleSummonSummoned;
			break;
		case 3:
			StatModController.OnDebuffAdded += HandleDebuffAdded;
			break;
		case 4:
			Character.OnCharacterTookDamage += HandleCharacterTookDamage_Part4;
			break;
		case 5:
			Character.OnCharacterTookDamage += HandleCharacterTookDamage_Part5;
			break;
		}
	}

	private void HandleDamagePrevented(Character c, Damage dmg, int amountPrevented)
	{
		Hero hero = GameStates.Singleton.hero;
		if (c == hero && dmg.GetElement() == ItemData.Element.Ice && hero.IsEquipped("fire_talisman"))
		{
			ImproveProgress(amountPrevented);
		}
	}

	private void HandleSummonSummoned(Summon summon)
	{
		if (summon.id == "cinderwisp")
		{
			ImproveProgress();
		}
	}

	private void HandleDebuffAdded(Character c, DebuffStatMod statMod)
	{
		if (statMod.id != "ignition")
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
			ImproveProgress();
		}
	}

	private void HandleCharacterTookDamage_Part4(Character c, Damage dmg)
	{
		if (dmg.type == Damage.Type.Dot && dmg.tags.Contains("Ignition"))
		{
			ImproveProgress(dmg.amount);
		}
	}

	private void HandleCharacterTookDamage_Part5(Character c, Damage dmg)
	{
		if (dmg.type == Damage.Type.Super && dmg.startHitpoints > 0 && dmg.tags.Contains("Devour") && dmg.tags.Contains("Fire"))
		{
			int num = dmg.amount;
			if (dmg.endHitpoints < 0)
			{
				num += dmg.endHitpoints;
			}
			ImproveProgress(num);
		}
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
		if (uniqueFoeIDs != null && base.goal.GetValue() == 3)
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
