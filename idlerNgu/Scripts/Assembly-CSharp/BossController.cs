using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
	public bool isFighting;

	public NumberFormat numberFormat;

	public Character character;

	public Button stopButton;

	public Boss boss;

	public Slider bossHPBar;

	public Scrollbar bossScrollbar;

	public Text bossHPText;

	public Text bossInfo;

	public Text bossName;

	public Text playerName;

	public Text fightButtonText;

	public Text bossDesc;

	public HoverTooltip tooltip;

	public TutorialPanel tutorial;

	public InventoryController inventoryController;

	public ButtonShower buttons;

	public Image playerPortrait;

	public Image bossPortrait;

	public Scrollbar bossTextScrollbar;

	public List<Sprite> bossPortraitSprites = new List<Sprite>();

	public List<Sprite> playerPortraitSprites = new List<Sprite>();

	public List<BossNameStory> bossProperties = new List<BossNameStory>();

	public Sprite unknownSprite;

	public bool nukeBoss;

	private void Start()
	{
		InvokeRepeating("fight", 0f, 0.02f);
		playerName.text = character.name;
	}

	public void Update()
	{
		if (character.settings.autoNukeOn && character.arbitrary.boughtAutoNuke && !nukeBoss && !isFighting && character.arbitrary.nukeTimer.totalseconds < (double)autoNukeThreshold())
		{
			character.arbitrary.nukeTimer.advanceTime(Time.deltaTime);
		}
		if (character.arbitrary.nukeTimer.totalseconds >= (double)autoNukeThreshold() && !nukeBoss && !isFighting)
		{
			startNuke();
			character.arbitrary.nukeTimer.reset();
		}
	}

	public int autoNukeThreshold()
	{
		return 60;
	}

	private void fight()
	{
		updateBars();
		updateText();
		character.bossCurHP += character.bossRegen;
		if (character.bossCurHP > character.bossMaxHP)
		{
			character.bossCurHP = character.bossMaxHP;
		}
		if (!isFighting)
		{
			return;
		}
		if (nukeBoss)
		{
			nukeBosses();
		}
		else
		{
			if (character.bossID > 300)
			{
				return;
			}
			double num = character.bossAttack * 0.02 - character.defense * 0.02;
			if (num <= 0.0)
			{
				num = 0.0;
			}
			character.curHP -= num;
			if (character.curHP <= 0.0)
			{
				isFighting = false;
				fightButtonText.text = "FIGHT";
				stopButton.gameObject.SetActive(value: false);
				character.curHP = 0.0;
				return;
			}
			num = character.attack * 0.02 - character.bossDefense * 0.02;
			if (num <= 0.0)
			{
				num = 0.0;
			}
			character.bossCurHP -= num;
			if (character.bossCurHP <= 0.0)
			{
				character.bossCurHP = 0.0;
				advanceBoss();
				isFighting = false;
				fightButtonText.text = "FIGHT";
				stopButton.gameObject.SetActive(value: false);
			}
		}
	}

	private void nukeBosses()
	{
		if (character.bossID > 300 || (character.bossID >= character.highestBoss && character.bossID < 124))
		{
			nukeBoss = false;
			isFighting = false;
			updateBossPortrait();
		}
		else if (character.attack / 5.0 > character.bossDefense && character.defense / 5.0 > character.bossAttack)
		{
			advanceBoss();
		}
		else
		{
			nukeBoss = false;
			isFighting = false;
			updateBossPortrait();
		}
	}

	public float sadisticBossMultiplier()
	{
		return 1.2f + character.adventureController.itopod.sadisticBossMultiplierBonus() + character.beastQuestPerkController.sadisticBossMultiplierBonus() + character.wishesController.sadisticBossMultiplierBonus();
	}

	public void startNuke()
	{
		if (!isFighting)
		{
			nukeBoss = true;
			isFighting = true;
		}
	}

	private void advanceBoss()
	{
		character.buttons.updateButtons();
		rewardExp();
		character.bossID++;
		bossTextScrollbar.value = 1f;
		if (character.bossID == 30)
		{
			character.timeMachineController.setBankedLevels();
		}
		inventoryController.updateBonuses();
		character.augmentsController.updateMenu();
		character.stats.bossesDefeated++;
		character.adventureController.constructDropdown();
		if (character.bossID > character.highestBoss && character.settings.rebirthDifficulty == difficulty.normal)
		{
			character.highestBoss = character.bossID;
			character.stats.highestBoss = character.bossID;
		}
		if (character.bossID > character.highestHardBoss && character.settings.rebirthDifficulty == difficulty.evil)
		{
			character.highestHardBoss = character.bossID;
		}
		if (character.bossID > character.highestSadisticBoss && character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			character.highestSadisticBoss = character.bossID;
		}
		if (character.bossID > character.currentHighestBoss)
		{
			character.currentHighestBoss = character.bossID;
		}
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			character.bossMulti *= 2.0;
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			character.bossMulti *= 1.5;
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			character.bossMulti *= sadisticBossMultiplier();
		}
		if (character.bossID >= 4)
		{
			character.settings.inventoryOn = true;
		}
		if (character.bossID == 37)
		{
			character.magic.unlockMagic();
		}
		if (character.bossID == 58)
		{
			character.challenges.unlocked = true;
		}
		if (character.bossID > 300)
		{
			bossName.text = "NONE (YOU KILLED THEM ALL)";
			bossDesc.text = "You've defeated every single boss! Rebirth to bring them back, or try a higher difficulty rebirth!";
			character.bossAttack = 69.0;
			character.bossDefense = 69.0;
			character.bossRegen = 420.0;
			character.bossCurHP = 420.0;
			character.bossMaxHP = 420.0;
			character.buttons.updateButtons();
			updateMenu();
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				if (character.itemInfo.findIndexWithID(487) == -1)
				{
					character.itemInfo.makeLevelledLoot(487, 100);
				}
				character.tooltip.showTooltip("THE END NEARS.");
			}
		}
		else
		{
			character.bossAttack = boss.bossAttack[character.bossID];
			character.bossDefense = boss.bossDefense[character.bossID];
			character.bossRegen = boss.bossRegen[character.bossID];
			character.bossCurHP = boss.bossCurHP[character.bossID];
			character.bossMaxHP = boss.bossMaxHP[character.bossID];
			updateMenu();
			bossTextScrollbar.value = 1f;
			character.buttons.updateButtons();
		}
	}

	public void rewardExp()
	{
		float num = 0f;
		if (character.bossID == 0)
		{
			if (character.firstBossEver)
			{
				num = 2f;
				character.addExp(num);
				tooltip.startFirstBoss();
			}
			return;
		}
		string text = "You defeated " + getBossName(character.bossID) + "! ";
		if (character.bossID == 1)
		{
			if (character.firstBossEver)
			{
				num = 3f;
				character.addExp(num);
				text = text + "You also gained " + num + " EXP!";
				tooltip.showTooltip(text, 3f);
			}
			return;
		}
		if (character.bossID == 2)
		{
			if (character.firstBossEver)
			{
				num = 4f;
				character.addExp(num);
				text = text + "You also gained " + num + " EXP!";
				tooltip.showTooltip(text, 3f);
			}
			return;
		}
		if (character.bossID == 3 && character.firstBossEver)
		{
			character.firstBossEver = false;
			num = 10f;
			character.addExp(num);
			tooltip.startAdventure();
			return;
		}
		if (character.currentHighestBoss < 20 && character.bossID >= character.currentHighestBoss)
		{
			character.currentHighestBoss = character.bossID;
			num = 3f;
			num = character.addExp(num);
			text = text + "You also gained a one time bonus of " + character.display(num) + " EXP!";
			tooltip.showTooltip(text, 2f);
			return;
		}
		if (character.bossID < 23 && character.bossID >= 4)
		{
			num = 1f;
			if (character.bossID <= 5)
			{
				num = 0f;
			}
			if (num >= 1f)
			{
				text = text + "You also gained " + character.display(character.addExp(num)) + " EXP!";
			}
			tooltip.showTooltip(text, 2f);
			return;
		}
		int num2 = 0;
		if (character.allChallenges.hour24Challenge.completions() >= 1)
		{
			num2++;
		}
		num = (Mathf.Max(((float)character.bossID - 13f) / 10f, 1f) + (float)num2) * (1f + (float)character.allChallenges.hour24Challenge.completions() * 0.02f);
		num *= character.adventureController.itopod.totalBossExp();
		if (num <= 0f)
		{
			num = 0f;
		}
		if (num > 0f)
		{
			text = text + "You've also gained " + character.display(character.addExp(num)) + " EXP!";
		}
		if (!character.challenges.blindChallenge.inChallenge || character.allChallenges.blindChallenge.completions() < 4)
		{
			tooltip.showTooltip(text, 1f);
		}
	}

	public void beginFight()
	{
		character.API.submitScores();
		if (character.bossID > 300)
		{
			isFighting = false;
		}
		else
		{
			isFighting = !isFighting;
		}
	}

	public void updateMenu()
	{
		if (character.menuID == 15)
		{
			updatePortraits();
			updateText();
			updateBars();
		}
	}

	public void updatePortraits()
	{
		updateBossPortrait();
		updatePlayerPortrait();
	}

	public void updateBossPortrait()
	{
		if (character.menuID != 15 || nukeBoss)
		{
			return;
		}
		if (character.challenges.blindChallenge.inChallenge)
		{
			if (bossPortrait.sprite != unknownSprite)
			{
				bossPortrait.sprite = unknownSprite;
			}
		}
		else if (character.bossID < 150 && character.bossID >= 0 && character.settings.rebirthDifficulty >= difficulty.normal)
		{
			if (bossPortrait.sprite != bossPortraitSprites[character.bossID])
			{
				bossPortrait.sprite = bossPortraitSprites[character.bossID];
			}
		}
		else if (character.bossID >= 150 && character.bossID < 200 && character.settings.rebirthDifficulty >= difficulty.evil)
		{
			if (bossPortrait.sprite != bossPortraitSprites[character.bossID])
			{
				bossPortrait.sprite = bossPortraitSprites[character.bossID];
			}
		}
		else if (character.bossID >= 200 && character.bossID < 301 && character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			if (bossPortrait.sprite != bossPortraitSprites[character.bossID])
			{
				bossPortrait.sprite = bossPortraitSprites[character.bossID];
			}
		}
		else if (bossPortrait.sprite != unknownSprite)
		{
			bossPortrait.sprite = unknownSprite;
		}
	}

	public void updatePlayerPortrait()
	{
		if (character.portraits.curPortrait < 0 || character.portraits.curPortrait >= character.portraits.portraitUnlocked.Count)
		{
			playerPortrait.sprite = playerPortraitSprites[0];
		}
		else if (!character.portraits.portraitUnlocked[character.portraits.curPortrait])
		{
			playerPortrait.sprite = playerPortraitSprites[0];
		}
		else
		{
			playerPortrait.sprite = playerPortraitSprites[character.portraits.curPortrait];
		}
	}

	public string getBossName(int bossID)
	{
		if (bossID < 0 || bossID > 300)
		{
			return " ";
		}
		if (bossID > 149 && character.settings.rebirthDifficulty < difficulty.evil)
		{
			return "Ultimate Boss " + (bossID + 1);
		}
		if (bossID > 200 && character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return "Ultimate Boss " + (bossID + 1);
		}
		if (bossID >= 268)
		{
			return "Ultimate Boss " + (bossID + 1);
		}
		return bossProperties[bossID].bossName;
	}

	public void updateText()
	{
		if (character.menuID != 15)
		{
			return;
		}
		if (character.bossID < 301)
		{
			if (character.challenges.blindChallenge.inChallenge)
			{
				playerName.text = "";
				bossName.text = "";
				bossDesc.text = "";
				bossHPText.text = "";
				bossInfo.text = "";
				Text text = bossInfo;
				text.text = text.text ?? "";
				Text text2 = bossInfo;
				text2.text = text2.text ?? "";
				Text text3 = bossInfo;
				text3.text = text3.text ?? "";
				return;
			}
			playerName.text = character.playerName;
			if ((character.bossID >= 150 && character.settings.rebirthDifficulty < difficulty.evil) || (character.bossID >= 200 && character.settings.rebirthDifficulty < difficulty.sadistic))
			{
				bossName.text = "Ultimate Boss " + (character.bossID + 1);
				bossDesc.text = "\nYeah yeah, I'll give all these bosses a full name and story later. Sue me. This is boss " + (character.bossID + 1) + ".";
			}
			else
			{
				bossName.text = bossProperties[character.bossID].bossName;
				bossDesc.text = bossProperties[character.bossID].bossStory.text;
			}
			updateBars();
			bossInfo.text = "Boss " + (character.bossID + 1);
			Text text4 = bossInfo;
			text4.text = text4.text + "\nAttack: " + NumberOutput.suffixFormat(boss.bossAttack[character.bossID], character.settings.numberDisplay);
			Text text5 = bossInfo;
			text5.text = text5.text + "\nDefense: " + NumberOutput.suffixFormat(boss.bossDefense[character.bossID], character.settings.numberDisplay);
			Text text6 = bossInfo;
			text6.text = text6.text + "\nMax HP: " + NumberOutput.suffixFormat(boss.bossMaxHP[character.bossID], character.settings.numberDisplay);
			bossHPText.text = numberFormat.suffixFormat(character.bossCurHP) + " HP";
		}
		else
		{
			playerName.text = character.playerName;
			bossName.text = "NO MORE BOSSES!";
			bossDesc.text = "YOU BEAT THEM ALL!";
			bossHPText.text = "69/420 HP";
			bossInfo.text = "NO MORE BOSSES!";
		}
	}

	public void updateBars()
	{
		if (character.bossID < 301)
		{
			if (character.challenges.blindChallenge.inChallenge)
			{
				bossHPBar.value = (float)(character.bossCurHP / character.bossMaxHP);
			}
			else
			{
				bossHPBar.value = (float)(character.bossCurHP / character.bossMaxHP);
			}
		}
		else
		{
			bossHPBar.value = 1f;
		}
	}

	public void claimBadge2Part3()
	{
		if (character.bossID == 8 && !character.settings.badge2Part3Complete && (character.platform == platform.Kong || character.platform == platform.Kartridge))
		{
			character.settings.badge2Part3Complete = true;
			character.tooltip.showOverrideTooltip("Congrats, you just finished an objective for the Medium Badge! You can click the Info 'N Stuff menu button in the bottom left to see what else you need to do to unlock your shiny badge! :D", 15f);
			character.InfonStuffController.updateBadgeProgressText();
		}
	}

	public void advancePortrait()
	{
		for (int i = 0; i < character.portraits.portraitUnlocked.Count; i++)
		{
			character.portraits.curPortrait++;
			if (character.portraits.curPortrait >= character.portraits.portraitUnlocked.Count)
			{
				character.portraits.curPortrait = 0;
			}
			if (character.portraits.portraitUnlocked[character.portraits.curPortrait])
			{
				updatePlayerPortrait();
				return;
			}
		}
		character.portraits.curPortrait = 0;
		updatePlayerPortrait();
	}

	public void backPortrait()
	{
		_ = character.portraits.curPortrait;
		for (int i = 0; i < character.portraits.portraitUnlocked.Count; i++)
		{
			character.portraits.curPortrait--;
			if (character.portraits.curPortrait < 0)
			{
				character.portraits.curPortrait = character.portraits.portraitUnlocked.Count - 1;
			}
			if (character.portraits.portraitUnlocked[character.portraits.curPortrait])
			{
				updatePlayerPortrait();
				return;
			}
		}
		character.portraits.curPortrait = 0;
		updatePlayerPortrait();
	}

	public void showPortraitTip()
	{
		if (character.platform == platform.Steam && !character.settings.claimedSteamPromo)
		{
			tooltip.showTooltip("<b>Click the 'Info n Stuff' button and you can unlock 2 free portraits right away! Many more Portraits are unlocked through gameplay, too!</b>");
		}
		else if (character.platform == platform.Steam && character.settings.claimedSteamPromo && character.settings.inventoryOn)
		{
			tooltip.showTooltip("<b>You can unlock many more Portraits by completing Item Sets - check out the Item List in the Inventory Menu for more details! There's even a portrait pack in the Sellout Shop if you're into that.</b>");
		}
	}
}
