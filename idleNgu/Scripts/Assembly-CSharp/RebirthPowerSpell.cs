using System;
using UnityEngine;
using UnityEngine.UI;

public class RebirthPowerSpell : MonoBehaviour
{
	public Character character;

	public Text bloodDisplay;

	public Text rebirthDisplay;

	public Text adventureDisplay;

	public Text lootDisplay;

	public Text goldDisplay;

	public Text macguffin1Display;

	public Button macguffin1Button;

	public Text macguffin2Display;

	public Button macguffin2Button;

	public GameObject endSpell;

	public HoverTooltip tooltip;

	public Image rebirthToggle;

	public Image lootToggle;

	public Image goldToggle;

	public InputField bloodInput;

	public int adventureSpellCooldown;

	public int macguffin1Cooldown;

	public int macguffin2Cooldown;

	private string message;

	private float lastAdventureAmount;

	public string lastMacguffin1 = "";

	public string lastMacguffin2 = "";

	public void Start()
	{
		updateMenu();
		InvokeRepeating("autoSpell", 0f, 1f);
	}

	public void Update()
	{
		float deltaTime = Time.deltaTime;
		if (character.bloodMagic.adventureSpellTime.totalseconds < (double)adventureSpellCooldown)
		{
			character.bloodMagic.adventureSpellTime.advanceTime(deltaTime);
		}
		if (character.adventure.itopod.perkLevel[72] >= 1 && character.bloodMagic.macguffin1Time.totalseconds < (double)macguffin1Cooldown)
		{
			character.bloodMagic.macguffin1Time.advanceTime(deltaTime);
		}
		if (character.adventure.itopod.perkLevel[73] >= 1 && character.bloodMagic.macguffin2Time.totalseconds < (double)macguffin2Cooldown)
		{
			character.bloodMagic.macguffin2Time.advanceTime(deltaTime);
		}
		if (character.menuID == 7)
		{
			bloodDisplay.text = " You have " + NumberOutput.suffixFormat(character.bloodMagic.bloodPoints, character.settings.numberDisplay) + " Blood.";
		}
	}

	public void updateMenu()
	{
		if (character.menuID != 7)
		{
			return;
		}
		rebirthDisplay.text = "Total Rebirth Bonus: <b>" + NumberOutput.suffixFormat(character.bloodMagic.rebirthPower, character.settings.numberDisplay) + "</b>";
		if (lastAdventureAmount > 0f)
		{
			adventureDisplay.fontSize = 14;
			adventureDisplay.text = "Last Spell granted +<b>" + lastAdventureAmount.ToString("###,##0") + "</b> to Adventure stats.";
		}
		else
		{
			adventureDisplay.fontSize = 12;
			adventureDisplay.text = "You haven't cast this spell yet since you loaded the game, so ummm... I don't know what to tell you.";
		}
		macguffin1Display.text = lastMacguffin1;
		macguffin2Display.text = lastMacguffin2;
		goldDisplay.text = "GPS Bonus: <b>" + ((character.bloodMagicController.goldBonus() - 1f) * 100f).ToString("###,##0") + "</b>%";
		lootDisplay.text = "Drop Chance Bonus: <b>" + ((character.bloodMagicController.lootBonus() - 1f) * 100f).ToString("###,##0") + "</b>%";
		if (character.adventure.itopod.perkLevel[72] < 1)
		{
			macguffin1Button.gameObject.SetActive(value: false);
			macguffin1Display.text = "";
		}
		else
		{
			macguffin1Button.gameObject.SetActive(value: true);
		}
		if (character.adventure.itopod.perkLevel[73] < 1)
		{
			macguffin2Button.gameObject.SetActive(value: false);
		}
		else
		{
			macguffin2Button.gameObject.SetActive(value: true);
		}
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			endSpell.SetActive(value: false);
		}
		else
		{
			endSpell.SetActive(value: true);
			Text[] componentsInChildren = endSpell.GetComponentsInChildren<Text>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].text = "<b>3%q6(;>_<,$H8e</b>";
			}
		}
		updateRebirthToggleState();
		updateLootToggleState();
		updateGoldToggleState();
	}

	public double minAdventureBlood()
	{
		return 100.0;
	}

	public double minLootBlood()
	{
		return 10000.0;
	}

	public double minGoldBlood()
	{
		return 1000000.0;
	}

	public double minMacguffin1Blood()
	{
		return 1000000000.0;
	}

	public double minMacguffin2Blood()
	{
		return 1000000.0;
	}

	public double endSpellBlood()
	{
		return 5E+22;
	}

	public void castRebirthSpell()
	{
		character.bloodMagic.rebirthPower += character.bloodMagic.bloodPoints;
		character.bloodMagic.bloodPoints = 0.0;
		updateMenu();
	}

	public void castRebirthSpell(double amount)
	{
		if (!(amount > character.bloodMagic.bloodPoints))
		{
			character.bloodMagic.rebirthPower += amount;
			character.bloodMagic.bloodPoints -= amount;
			updateMenu();
		}
	}

	public void rebirthSpellTooltip()
	{
		message = "<b>Blood NUMBER Boost</b>\n\nEveryone knows that bathing your NUMBER in Blood is the #1 way to make it go up. Duh. Dump all of your blood into this spell to gain a multiplier boost to your NUMBER!";
		tooltip.showTooltip(message);
	}

	public void toggleRebirthAutoSpell()
	{
		character.bloodMagic.rebirthAutoSpell = !character.bloodMagic.rebirthAutoSpell;
		updateRebirthToggleState();
	}

	public void updateRebirthToggleState()
	{
		if (!character.bloodMagic.rebirthAutoSpell)
		{
			rebirthToggle.color = Color.clear;
		}
		else
		{
			rebirthToggle.color = Color.white;
		}
	}

	public void castAdventurePowerupSpell()
	{
		if (character.bloodMagic.adventureSpellTime.totalseconds < (double)adventureSpellCooldown)
		{
			tooltip.showTooltip("This spell is still on cooldown!", 3f);
			return;
		}
		if (character.bloodMagic.bloodPoints < minAdventureBlood())
		{
			tooltip.showTooltip("You don't have enough Blood to cast this spell!", 3f);
			return;
		}
		float num = (float)Math.Floor(Math.Pow(character.bloodMagic.bloodPoints, 0.25));
		if (character.settings.rebirthDifficulty >= difficulty.evil)
		{
			num *= character.adventureController.itopod.ironPillBonus();
		}
		if (num >= 100000000f)
		{
			num = 100000000f;
		}
		if (num < 0f)
		{
			num = 0f;
		}
		character.adventure.attack += num;
		character.adventure.defense += num;
		character.adventure.maxHP += num * 3f;
		character.adventure.regen += num * 0.03f;
		lastAdventureAmount = num;
		character.bloodMagic.bloodPoints = 0.0;
		tooltip.showTooltip("You take the Blood Pill and gain <b>" + character.display(num) + "</b> To your Power and Toughness, with proportional bonuses to your Max Health and Health Regen!", 4f);
		character.bloodMagic.adventureSpellTime.reset();
		updateMenu();
	}

	public float givePartialAdventureSpell(float percentage, int tossFactor)
	{
		float num = (float)Math.Floor(Math.Pow(character.bloodMagicController.totalBloodGainedPerSecond() * 3600.0, 0.25));
		if (character.settings.rebirthDifficulty >= difficulty.evil)
		{
			num *= character.adventureController.itopod.ironPillBonus();
		}
		if (num >= 100000000f)
		{
			num = 100000000f;
		}
		if (num < 0f)
		{
			num = 0f;
		}
		num *= percentage;
		num *= (float)tossFactor;
		character.adventure.attack += num;
		character.adventure.defense += num;
		character.adventure.maxHP += num * 3f;
		character.adventure.regen += num * 0.03f;
		return num;
	}

	public void adventureSpellTooltip()
	{
		InvokeRepeating("spellTooltip", 0f, 1f);
	}

	public void spellTooltip()
	{
		float num = (float)Math.Floor(Math.Pow(character.bloodMagic.bloodPoints, 0.25));
		if (character.settings.rebirthDifficulty >= difficulty.evil)
		{
			num *= character.adventureController.itopod.ironPillBonus();
		}
		message = "<b>Iron Pill</b>\n\nGather up all of your Blood and, using your Tetris grandmaster skills, compact it into a tiny iron pill which somehow grants (blood)^0.25 to your Adventure stats! This means Power and Toughness, with proportional bonuses to Max Health and Health Regen.\n\n<b>Minimum Blood Required:</b> " + minAdventureBlood() + "\n\n<b>Current Spell Cooldown:</b> " + NumberOutput.timeOutput(Mathf.Max((float)((double)adventureSpellCooldown - character.bloodMagic.adventureSpellTime.totalseconds), 0f)) + "\n<b>Iron Pill will grant +" + character.display(num) + " to your Adventure stats if used now.</b>";
		tooltip.showTooltip(message);
	}

	public void castLootSpell()
	{
		if (character.bloodMagic.bloodPoints < minLootBlood())
		{
			tooltip.showTooltip("You don't have enough Blood to cast this spell!", 3f);
			return;
		}
		character.bloodMagic.lootSpellBlood += character.bloodMagic.bloodPoints;
		character.bloodMagic.bloodPoints = 0.0;
		tooltip.showTooltip("With the power of Blood Spaghetti, foes now have a <b>" + ((character.bloodMagicController.lootBonus() - 1f) * 100f).ToString("###,##0") + "</b>% greater chance to drop their loot!", 4f);
		updateMenu();
	}

	public void castLootSpell(double amount)
	{
		if (!(amount < minLootBlood()) && !(amount > character.bloodMagic.bloodPoints))
		{
			character.bloodMagic.lootSpellBlood += amount;
			character.bloodMagic.bloodPoints -= amount;
			updateMenu();
		}
	}

	public void lootSpellTooltip()
	{
		message = "<b>Blood Spaghetti</b>\n\nGather up all of your Blood and form it into something resembling spaghetti. You can slip spaghetti into a foe's pockets, causing it (and whatever loot they're holding onto) to fall out more often!\n\nFor you math nerds, it's log2(Blood/" + minLootBlood() + ") % better drop chance.\n\n<b>Minimum Blood Required: </b>" + minLootBlood() + "\n\n<b>Total Blood Invested: </b>" + NumberOutput.suffixFormat(character.bloodMagic.lootSpellBlood, character.settings.numberDisplay);
		tooltip.showTooltip(message);
	}

	public void toggleLootAutoSpell()
	{
		character.bloodMagic.lootAutoSpell = !character.bloodMagic.lootAutoSpell;
		updateLootToggleState();
	}

	public void updateLootToggleState()
	{
		if (!character.bloodMagic.lootAutoSpell)
		{
			lootToggle.color = Color.clear;
		}
		else
		{
			lootToggle.color = Color.white;
		}
	}

	public void castGoldSpell()
	{
		if (character.bloodMagic.bloodPoints < minGoldBlood())
		{
			tooltip.showTooltip("You don't have enough Blood to cast this spell!", 3f);
			return;
		}
		character.bloodMagic.goldSpellBlood += character.bloodMagic.bloodPoints;
		character.bloodMagic.bloodPoints = 0.0;
		tooltip.showTooltip("With the power of Blood, gold production has been increased by " + ((character.bloodMagicController.goldBonus() - 1f) * 100f).ToString("###,##0") + "% for this rebirth!", 4f);
		updateMenu();
	}

	public void castGoldSpell(double amount)
	{
		if (!(amount < minGoldBlood()) && !(amount > character.bloodMagic.bloodPoints))
		{
			character.bloodMagic.goldSpellBlood += amount;
			character.bloodMagic.bloodPoints -= amount;
			updateMenu();
		}
	}

	public void goldSpellTooltip()
	{
		message = "<b>Counterfeit Gold</b>\n\nUse the power of Blood to create some counterfeit gold, and slip it into the time machine's time bubble to increase gold production! Lasts until rebirth.\n\nWARNING: MATH. Your bonus GPS is equal to log2(Blood/" + minGoldBlood() + ")^2%.\n\n<b>Minimum Blood Required: </b>" + minGoldBlood() + "\n\n<b>Total Blood Invested: </b>" + NumberOutput.suffixFormat(character.bloodMagic.goldSpellBlood, character.settings.numberDisplay);
		tooltip.showTooltip(message);
	}

	public void castMacguffin1Spell()
	{
		if (character.adventure.itopod.perkLevel[72] < 1)
		{
			tooltip.showOverrideTooltip("You don't have this spell unlocked! You can unlock it via an ITOPOD perk!", 1.5f);
			return;
		}
		if (character.bloodMagic.bloodPoints < minMacguffin1Blood())
		{
			tooltip.showOverrideTooltip("You don't have enough Blood to cast this spell!", 1f);
			return;
		}
		if (character.bloodMagic.macguffin1Time.totalseconds < (double)macguffin1Cooldown)
		{
			tooltip.showTooltip("This spell is still on cooldown!", 3f);
			return;
		}
		double num = character.bloodMagic.bloodPoints / minMacguffin1Blood();
		if (!(num < 1.0))
		{
			int levelsToAdd = (int)((Math.Log(num, 10.0) + 1.0) * (double)character.wishesController.totalBloodGuffbonus());
			if (character.wishes.wishes[24].level > 0)
			{
				character.inventoryController.levelFirstMacguffin(levelsToAdd);
			}
			else
			{
				character.inventoryController.levelRandomMacguffin(levelsToAdd);
			}
			character.bloodMagic.bloodPoints = 0.0;
			character.bloodMagic.macguffin1Time.reset();
			updateMenu();
		}
	}

	public void castMacguffin2Spell()
	{
		if (character.adventure.itopod.perkLevel[73] < 1)
		{
			tooltip.showOverrideTooltip("You don't have this spell unlocked! You can unlock it via an ITOPOD perk!", 1.5f);
			return;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			tooltip.showOverrideTooltip("You can only cast this spell in Evil difficulty or greater!", 1f);
			return;
		}
		if (character.bloodMagic.bloodPoints < minMacguffin2Blood())
		{
			tooltip.showOverrideTooltip("You don't have enough Blood to cast this spell!", 1f);
			return;
		}
		if (character.bloodMagic.macguffin2Time.totalseconds < (double)macguffin2Cooldown)
		{
			tooltip.showOverrideTooltip("This spell is still on cooldown!", 3f);
			return;
		}
		double num = character.bloodMagic.bloodPoints / minMacguffin2Blood();
		if (!(num < 1.0))
		{
			int levelsToAdd = (int)(Math.Log(num, 20.0) + 1.0);
			character.inventoryController.levelAllMacguffins(levelsToAdd);
			character.bloodMagic.bloodPoints = 0.0;
			character.bloodMagic.macguffin2Time.reset();
			updateMenu();
		}
	}

	public void toggleGoldAutoSpell()
	{
		character.bloodMagic.goldAutoSpell = !character.bloodMagic.goldAutoSpell;
		updateGoldToggleState();
	}

	public void updateGoldToggleState()
	{
		if (!character.bloodMagic.goldAutoSpell)
		{
			goldToggle.color = Color.clear;
		}
		else
		{
			goldToggle.color = Color.white;
		}
	}

	public void hideTooltip()
	{
		tooltip.hideTooltip();
		CancelInvoke("spellTooltip");
		CancelInvoke("macguffin1SpellTooltip");
		CancelInvoke("macguffin2SpellTooltip");
	}

	public void macguffin1Tooltip()
	{
		InvokeRepeating("macguffin1SpellTooltip", 0f, 1f);
	}

	public void macguffin1SpellTooltip()
	{
		long num = 0L;
		if (character.bloodMagic.bloodPoints > minMacguffin1Blood())
		{
			num = (int)((Math.Log(character.bloodMagic.bloodPoints / minMacguffin1Blood(), 10.0) + 1.0) * (double)character.wishesController.totalBloodGuffbonus());
		}
		message = "<b>Blood MacGuffin α</b>\n\nSimply fill an Olympic-sized swimming pool with blood, chuck a random MacGuffin in, and watch that sucker soak up all the Blood and increase in level!\n\n<b>Minimum Blood Required:</b> " + character.display(minMacguffin1Blood()) + "\n\n<b>Current Spell Cooldown:</b> " + NumberOutput.timeOutput(Mathf.Max((float)((double)macguffin1Cooldown - character.bloodMagic.macguffin1Time.totalseconds), 0f)) + "\n<b>Blood MacGuffin α will grant + " + num + " level(s) to a random MacGuffin if used now.</b>";
		tooltip.showTooltip(message);
	}

	public void macguffin2Tooltip()
	{
		InvokeRepeating("macguffin2SpellTooltip", 0f, 1f);
	}

	public void macguffin2SpellTooltip()
	{
		long num = 0L;
		if (character.bloodMagic.bloodPoints >= minMacguffin2Blood() && character.settings.rebirthDifficulty >= difficulty.evil)
		{
			num = (int)(Math.Log(character.bloodMagic.bloodPoints / minMacguffin2Blood(), 20.0) + 1.0);
		}
		message = "<b>Blood MacGuffin β</b>\n\nYears of intense research has led you to the conclusion that you could have chucked ALL your MacGuffins in at once and it'd work exactly the same way.\n\n<b>Minimum Blood Required:</b> " + character.display(minMacguffin2Blood()) + "\n\n<b>Evil Difficulty Required</b> \n\n<b>Current Spell Cooldown:</b> " + NumberOutput.timeOutput(Mathf.Max((float)((double)macguffin2Cooldown - character.bloodMagic.macguffin2Time.totalseconds), 0f)) + "\n<b>Blood MacGuffin β will grant + " + num + " level(s) to all equipped macguffins if used now.</b>";
		tooltip.showTooltip(message);
	}

	public void castEndSpell()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			tooltip.showOverrideTooltip("THIS SHOULDNT HAPPEN.", 1f);
			return;
		}
		if (character.bloodMagic.bloodPoints < endSpellBlood())
		{
			tooltip.showOverrideTooltip("MORE BLOOD.", 1f);
			return;
		}
		character.itemInfo.makeLevelledLoot(494, 100);
		tooltip.showOverrideTooltip("THE END NEARS.", 2f);
		character.bloodMagic.bloodPoints = 0.0;
		updateMenu();
	}

	public void endSpellTooltip()
	{
		message = "<b>3%q6(;>_<,$H8e</b>\n\nBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOODBLOOD\n\n<b>Minimum Blood Required:</b> " + character.display(endSpellBlood());
		tooltip.showTooltip(message);
	}

	public void showAutoSpellTooltip()
	{
		tooltip.showTooltip("Check this box if you want to automatically dump your accumulated Blood into this spell every second. If multiple spells are checked, they will get equal shares. NOTE: Autospell is still bound by the minimum Blood requirement for spells!");
	}

	public void autoSpell()
	{
		if (character.bossID <= 36)
		{
			return;
		}
		int num = 0;
		if (character.bloodMagic.rebirthAutoSpell)
		{
			num++;
		}
		if (character.bloodMagic.lootAutoSpell)
		{
			num++;
		}
		if (character.bloodMagic.goldAutoSpell)
		{
			num++;
		}
		if (num != 0)
		{
			double amount = Math.Floor(character.bloodMagic.bloodPoints / (double)num);
			if (character.bloodMagic.rebirthAutoSpell)
			{
				castRebirthSpell(amount);
			}
			if (character.bloodMagic.lootAutoSpell)
			{
				castLootSpell(amount);
			}
			if (character.bloodMagic.goldAutoSpell)
			{
				castGoldSpell(amount);
			}
		}
	}

	public bool castingAutoSpells()
	{
		if (!character.bloodMagic.goldAutoSpell && !character.bloodMagic.goldAutoSpell)
		{
			return character.bloodMagic.rebirthAutoSpell;
		}
		return true;
	}

	public void checkTargetInput()
	{
		long num = long.Parse(bloodInput.text);
		if (num < 0)
		{
			num = 0L;
		}
		if (num > 2000000000)
		{
			num = 0L;
		}
		bloodInput.text = num.ToString();
	}
}
