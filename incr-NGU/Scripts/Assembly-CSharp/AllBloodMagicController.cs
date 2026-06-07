using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllBloodMagicController : MonoBehaviour
{
	public BloodMagicController[] bloodMagics = new BloodMagicController[8];

	public RebirthPowerSpell spells;

	public Character character;

	public Text bloodText;

	public List<float> normalSpeedDividers;

	public List<float> evilSpeedDividers;

	public List<float> sadisticSpeedDividers;

	public int ritualsUnlocked()
	{
		int num = 7;
		if (character.allChallenges.trollChallenge.completions() >= 6)
		{
			num++;
		}
		return num;
	}

	public void Update()
	{
		if (character.menuID == 6)
		{
			updateBloodDisplay();
		}
	}

	public void reset()
	{
		for (int i = 0; i < bloodMagics.Length; i++)
		{
			bloodMagics[i].reset();
		}
		character.bloodMagic.bloodPoints = 0.0;
		character.bloodMagic.rebirthPower = 1.0;
		character.bloodMagic.goldSpellBlood = 0.0;
		character.bloodMagic.lootSpellBlood = 0.0;
	}

	public void updateMenu()
	{
		if (character.menuID == 6)
		{
			for (int i = 0; i < bloodMagics.Length; i++)
			{
				bloodMagics[i].refresh();
			}
		}
		if (character.menuID == 7)
		{
			spells.updateMenu();
		}
	}

	public void capAllRituals()
	{
		removeAllMagic();
		for (int num = ritualsUnlocked() - 1; num >= 0; num--)
		{
			bloodMagics[num].cap();
			bloodMagics[num].refresh();
		}
	}

	public void updateBloodDisplay()
	{
		bloodText.text = "<b>Blood</b>: " + character.display(character.bloodMagic.bloodPoints);
	}

	public void removeAllMagic()
	{
		for (int i = 0; i < bloodMagics.Length; i++)
		{
			bloodMagics[i].removeAllMagic();
		}
	}

	public float lootBonus()
	{
		if (character.bloodMagic.lootSpellBlood < character.bloodMagicController.spells.minLootBlood())
		{
			return 1f;
		}
		return 1f + (float)(Math.Floor(Math.Log(character.bloodMagic.lootSpellBlood / character.bloodMagicController.spells.minLootBlood(), 2.0) + 1.0) * 0.009999999776482582);
	}

	public float goldBonus()
	{
		if (character.bloodMagic.goldSpellBlood < character.bloodMagicController.spells.minGoldBlood())
		{
			return 1f;
		}
		return 1f + (float)(Math.Floor(Math.Pow(Math.Log(character.bloodMagic.goldSpellBlood / character.bloodMagicController.spells.minGoldBlood(), 2.0) + 1.0, 2.0)) * 0.009999999776482582);
	}

	public double bloodAdded(int id)
	{
		return (float)bloodMagics[id].baseBoost * character.allDiggers.totalBloodBonus() * character.hacksController.totalBloodGainBonus() * character.beastQuestPerkController.totalBloodGainBonus() * character.inventory.macguffinBonuses[18];
	}

	public void loseBlood()
	{
		character.bloodMagic.bloodPoints = 0.0;
	}

	public double totalBloodGainedPerSecond()
	{
		double num = 0.0;
		for (int i = 0; i < character.bloodMagic.ritual.Count; i++)
		{
			num += bloodMagics[i].bloodGainedPerSecond();
		}
		if (num < 0.0)
		{
			num = 0.0;
		}
		return num;
	}
}
