using System.Collections.Generic;
using UnityEngine;

public class AetherTalismanGoals : LostItemGoals
{
	public UniqueFoesGoalUI uniqueFoesGoalPrefab;

	private UniqueFoesGoalUI uniqueFoesGoalUI;

	private float armorGained;

	public List<string> uniqueFoeIDs { get; set; }

	public List<string> uniqueFoeNames { get; set; }

	public static AetherTalismanGoals singleton { get; private set; }

	public override List<string> GetTexts()
	{
		List<string> texts = base.GetTexts();
		texts.Add(Te.xt("tid_info_transporeltive_1").Trim());
		texts.Add(Te.xt("tid_info_transporeltive_2").Trim());
		texts.Add(Te.xt("tid_info_transporeltive_3").Trim());
		texts.Add(Te.xt("tid_info_transporeltive_4").Trim());
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
			Character.OnCharacterDied -= HandleCharacterDied_Part3;
			break;
		default:
			_ = 4;
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
			Character.OnCharacterDied += HandleCharacterDied_Part3;
			break;
		default:
			_ = 4;
			break;
		}
	}

	private void HandleDamagePrevented(Character c, Damage dmg, int amountPrevented)
	{
		Hero hero = GameStates.Singleton.hero;
		if (c == hero && dmg.GetElement() == ItemData.Element.Fire && hero.IsEquipped("aether_talisman"))
		{
			ImproveProgress(amountPrevented);
		}
	}

	private void HandleSummonSummoned(Summon summon)
	{
		if (summon.id == "voidweaver")
		{
			ImproveProgress();
		}
	}

	private void HandleCharacterDied_Part3(Character character, Character.DeathReason reason, Damage damage)
	{
		if (damage == null || !(damage.Owner.id == "voidweaver") || !damage.tags.Contains("aether_talisman") || reason != Character.DeathReason.Unmake)
		{
			return;
		}
		if (uniqueFoeIDs == null)
		{
			uniqueFoeIDs = new List<string>();
			uniqueFoeNames = new List<string>();
		}
		if (uniqueFoeIDs.Contains(character.id))
		{
			int value = base.progress.GetValue();
			if (uniqueFoeIDs.Count > value)
			{
				ImproveProgress(uniqueFoeIDs.Count - value);
			}
		}
		else
		{
			uniqueFoeIDs.Add(character.id);
			uniqueFoeNames.Add(character.displayName);
			uniqueFoeNames.Sort();
			ImproveProgress();
		}
	}

	public void ReportEnemyKilledUnstable(float armorToGain)
	{
		if (base.goal.GetValue() == 4)
		{
			armorGained += armorToGain;
			if (Mathf.FloorToInt(armorGained) > base.progress.GetValue())
			{
				ImproveProgress(Mathf.FloorToInt(armorGained) - base.progress.GetValue());
			}
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
		if (uniqueFoeIDs != null && base.goal.GetValue() == 3)
		{
			SlimJson.AddProperty("uniqueFoeIDs", uniqueFoeIDs.ToArray());
			SlimJson.AddProperty("uniqueFoeNames", uniqueFoeNames.ToArray());
		}
	}

	public override void ParseMore(string sjson)
	{
		base.ParseMore(sjson);
		if (armorGained == 0f)
		{
			armorGained = base.progress.GetValue();
		}
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
