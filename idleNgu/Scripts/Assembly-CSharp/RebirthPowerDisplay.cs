using System;
using UnityEngine;
using UnityEngine.UI;

public class RebirthPowerDisplay : MonoBehaviour
{
	public Character character;

	public NumberFormat format;

	public Text currentAttackPower;

	public Text nextAttackPower;

	public Image attackChange;

	public Text RebirthInfoText;

	public Text rebirthInfoValues;

	public Text rebirthChange;

	public Button challengeButton;

	private float display;

	private string message;

	private string message2;

	private string message3;

	private void Start()
	{
	}

	private void Update()
	{
		if (character.menuID != 23)
		{
			return;
		}
		if (character.challenges.blindChallenge.inChallenge)
		{
			currentAttackPower.text = "";
			nextAttackPower.text = "";
		}
		else
		{
			currentAttackPower.text = format.suffixFormat(character.attackMulti);
			nextAttackPower.text = format.suffixFormat(character.nextAttackMulti);
		}
		if (character.challenges.blindChallenge.inChallenge && character.allChallenges.blindChallenge.completions() >= 8)
		{
			attackChange.enabled = false;
		}
		else
		{
			attackChange.enabled = true;
			if (character.attackMulti <= character.nextAttackMulti)
			{
				attackChange.sprite = Resources.Load<Sprite>("Images/PowerUp");
			}
			else
			{
				attackChange.sprite = Resources.Load<Sprite>("Images/PowerDown");
			}
		}
		string text = "0.00";
		if (character.timeMulti < 1.0)
		{
			text = "0.00000000000";
		}
		string text2 = "0.00";
		if (character.oldTimeMulti < 1.0)
		{
			text2 = "0.00000000000";
		}
		message = "Boss Power Bonus: \nBoss Power Bonus (Last Rebirth):\nRebirth Time Factor: \nRebirth Time Factor (Last Rebirth): \nTraining level Factor: ";
		message2 = difficultyFactor() + " ^ " + character.bossID + " = " + character.format.suffixFormat(character.bossMulti) + "\n" + difficultyFactor() + " ^ " + Math.Log(character.oldBossMulti, difficultyFactor()).ToString("###,###") + " = " + format.suffixFormat(character.oldBossMulti) + "\n" + character.timeMulti.ToString(text) + "\n" + character.oldTimeMulti.ToString(text2) + "\n" + character.display(character.training.totalAttackLevels / 10000 + 1);
		message3 = "";
		if (character.nextAttackMulti / character.attackMulti > 1.0)
		{
			double num = Math.Round(Math.Log10(character.nextAttackMulti / character.attackMulti));
			message3 = "Your NUMBER will be " + NumberOutput.suffixFormat(character.nextAttackMulti / character.attackMulti, character.settings.numberDisplay) + " x larger if you rebirth!";
			if (num > 3.0)
			{
				message3 = message3 + " (Or ~" + num + " more bosses!)";
			}
		}
		else if (character.attackMulti / character.nextAttackMulti > 1.0)
		{
			double num2 = Math.Round(Math.Log10(character.attackMulti / character.nextAttackMulti));
			message3 = "Your NUMBER will be " + NumberOutput.suffixFormat(character.attackMulti / character.nextAttackMulti, character.settings.numberDisplay) + " x smaller if you rebirth!";
			if (num2 > 3.0)
			{
				message3 = message3 + " (Or ~" + num2 + " fewer bosses!)";
			}
		}
		if (character.bossID > 36)
		{
			message += "\nBlood Magic Bonus: ";
			message += "\nBlood Magic Bonus (Last Rebirth): ";
			message2 = message2 + "\n" + format.suffixFormat(character.bloodMagic.rebirthPower);
			message2 = message2 + "\n" + format.suffixFormat(character.stats.lastBloodMagic);
		}
		if (character.NGUController.numberBonus(noTimeMulti: false) > 1.0)
		{
			message += "\nNGU NUMBER Bonus: ";
			if (character.NGUController.numberBonus() <= 10.0)
			{
				message2 = message2 + "\n" + character.NGUController.numberBonus().ToString("##0.##");
			}
			else
			{
				message2 = message2 + "\n" + format.suffixFormat(character.NGUController.numberBonus());
			}
		}
		if (character.allBeards.numberBonus() > 1f && character.allBeards.numberBonus() <= 100f)
		{
			message += "\nBeard NUMBER Bonus: ";
			message2 = message2 + "\n" + character.allBeards.numberBonus().ToString("##0.##");
		}
		else if (character.allBeards.numberBonus() >= 100f)
		{
			message += "\nBeard NUMBER Bonus: ";
			message2 = message2 + "\n" + character.display(character.allBeards.numberBonus());
		}
		if (character.yggdrasilController.permNumberBonus() > 1.0)
		{
			message += "\nYggdrasil NUMBER Bonus: ";
			message2 = message2 + "\n" + character.display(character.yggdrasilController.permNumberBonus());
		}
		if (character.inventory.macguffinBonuses[17] > 1f && character.inventory.macguffinBonuses[17] < 100f)
		{
			message += "\nMacGuffin NUMBER Bonus: ";
			message2 = message2 + "\n" + character.inventory.macguffinBonuses[17].ToString("##0.##");
		}
		else if (character.inventory.macguffinBonuses[17] >= 100f)
		{
			message += "\nMacGuffin NUMBER Bonus: ";
			message2 = message2 + "\n" + character.display(character.inventory.macguffinBonuses[17]);
		}
		if (character.hacksController.totalNumberBonus() > 1f && character.hacksController.totalNumberBonus() < 100f)
		{
			message += "\nHack NUMBER Bonus: ";
			message2 = message2 + "\n" + character.hacksController.totalNumberBonus().ToString("##0.##");
		}
		else if (character.hacksController.totalNumberBonus() >= 100f)
		{
			message += "\nHack NUMBER Bonus: ";
			message2 = message2 + "\n" + character.display(character.hacksController.totalNumberBonus());
		}
		if (character.challenges.blindChallenge.inChallenge && character.allChallenges.blindChallenge.completions() >= 4)
		{
			RebirthInfoText.text = "";
			rebirthInfoValues.text = "";
			rebirthChange.text = "";
		}
		else
		{
			RebirthInfoText.text = message;
			rebirthInfoValues.text = message2;
			if (character.bossID >= 17)
			{
				rebirthChange.text = message3;
			}
			else
			{
				rebirthChange.text = "";
			}
		}
		if (character.pit.pitTime.totalseconds >= 3600.0 && !character.pit.tossedGold)
		{
			message += "<color=red>PIT NOT USED</color>";
		}
		if (character.highestBoss > 57)
		{
			challengeButton.gameObject.SetActive(value: true);
		}
		else
		{
			challengeButton.gameObject.SetActive(value: false);
		}
	}

	public float difficultyFactor()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return 2f;
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return 1.5f;
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			return character.bossController.sadisticBossMultiplier();
		}
		return 1.2f;
	}
}
