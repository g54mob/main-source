using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShower : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public Button basicTraining;

	public Button boss;

	public Button pit;

	public Button adventure;

	public Button inventory;

	public Button augmentation;

	public Button advancedTraining;

	public Button brokenTimeMachine;

	public Button bloodMagic;

	public Button spendExp;

	public Button rebirth;

	public Button wandoos;

	public Button yggdrasil;

	public Button diggers;

	public Button ngu;

	public Button beards;

	public Button beast;

	public Button hacks;

	public Button wishes;

	public Button cards;

	public Button cooking;

	private Text trainText;

	private Text bossText;

	private Text pitText;

	private Text adventureText;

	private Text inventoryText;

	private Text augmentationText;

	private Text advancedTrainingText;

	private Text brokenTimeMachineText;

	private Text bloodMagicText;

	private Text wandoosText;

	private Text yggdrasilText;

	private Text diggersText;

	private Text nguText;

	private Text beardText;

	private Text beastText;

	private Text hacksText;

	private Text wishesText;

	private Text cardsText;

	private Text cookingText;

	public List<GameObject> magicInputStuff;

	public List<GameObject> res3InputStuff;

	private string message;

	private void Start()
	{
		trainText = basicTraining.GetComponentInChildren<Text>();
		bossText = boss.GetComponentInChildren<Text>();
		adventureText = adventure.GetComponentInChildren<Text>();
		inventoryText = inventory.GetComponentInChildren<Text>();
		augmentationText = augmentation.GetComponentInChildren<Text>();
		advancedTrainingText = advancedTraining.GetComponentInChildren<Text>();
		brokenTimeMachineText = brokenTimeMachine.GetComponentInChildren<Text>();
		bloodMagicText = bloodMagic.GetComponentInChildren<Text>();
		pitText = pit.GetComponentInChildren<Text>();
		wandoosText = wandoos.GetComponentInChildren<Text>();
		yggdrasilText = yggdrasil.GetComponentInChildren<Text>();
		diggersText = diggers.GetComponentInChildren<Text>();
		nguText = ngu.GetComponentInChildren<Text>();
		beardText = beards.GetComponentInChildren<Text>();
		beastText = beast.GetComponentInChildren<Text>();
		hacksText = hacks.GetComponentInChildren<Text>();
		wishesText = wishes.GetComponentInChildren<Text>();
		cardsText = cards.GetComponentInChildren<Text>();
		cookingText = cooking.GetComponentInChildren<Text>();
		InvokeRepeating("updateButtons", 0f, 1f);
	}

	public void updateButtons()
	{
		basicTraining.interactable = true;
		trainText.text = "Basic Training";
		boss.interactable = true;
		bossText.text = "Fight Boss";
		adventure.interactable = true;
		adventureText.text = "Adventure";
		inventory.interactable = true;
		inventoryText.text = "Inventory";
		augmentation.interactable = true;
		augmentationText.text = "Augmentation";
		advancedTraining.interactable = true;
		advancedTrainingText.text = "Adv. Training";
		brokenTimeMachine.interactable = true;
		brokenTimeMachineText.text = "Time Machine";
		bloodMagic.interactable = true;
		bloodMagicText.text = "Blood Magic";
		wandoos.interactable = true;
		wandoosText.text = character.wandoos98Controller.wandoosTitle();
		wandoosText.fontSize = 14;
		spendExp.gameObject.SetActive(value: true);
		rebirth.gameObject.SetActive(value: true);
		yggdrasil.interactable = true;
		yggdrasilText.text = "Yggdrasil";
		if (character.firstBossEver)
		{
			rebirth.gameObject.SetActive(value: false);
		}
		if (character.bossID < 1 && character.firstBossEver)
		{
			spendExp.gameObject.SetActive(value: false);
		}
		if (character.bossID < 4)
		{
			adventure.interactable = false;
			adventureText.text = "Locked";
		}
		else
		{
			adventure.interactable = true;
			adventureText.text = "Adventure";
			if (character.adventureController.shouldLightButton())
			{
				adventure.image.color = Color.red;
			}
			else
			{
				adventure.image.color = Color.white;
			}
		}
		if (!character.settings.pitUnlocked)
		{
			pit.interactable = false;
			pitText.text = "NEED GOLD";
		}
		else
		{
			pit.interactable = true;
			pitText.text = "Money Pit";
		}
		if (character.pitController.canToss())
		{
			pit.image.color = new Color(0.5f, 0.827f, 0.235f);
		}
		else if (character.dailyController.canSpin())
		{
			pit.image.color = new Color(1f, 0.827f, 0.235f);
		}
		else
		{
			pit.image.color = Color.white;
		}
		if (!character.settings.inventoryOn)
		{
			inventory.interactable = false;
			inventoryText.text = "Also Locked";
		}
		if (character.bossID < 17 || character.challenges.noAugsChallenge.inChallenge)
		{
			augmentation.interactable = false;
			augmentationText.text = "Really Locked";
		}
		if (character.training.attackTraining[4] < 25000 || character.training.defenseTraining[4] < 25000)
		{
			advancedTraining.interactable = false;
			advancedTrainingText.text = "Totally Locked";
		}
		if (character.bossID < 30)
		{
			brokenTimeMachine.interactable = false;
			brokenTimeMachineText.text = "Unlocked";
		}
		if (character.magic.capMagic < 10000)
		{
			for (int i = 0; i < magicInputStuff.Count; i++)
			{
				magicInputStuff[i].SetActive(value: false);
			}
		}
		else
		{
			for (int j = 0; j < magicInputStuff.Count; j++)
			{
				magicInputStuff[j].SetActive(value: true);
			}
		}
		if (character.res3.res3On)
		{
			for (int k = 0; k < res3InputStuff.Count; k++)
			{
				res3InputStuff[k].SetActive(value: true);
			}
			res3InputStuff[0].GetComponent<Text>().text = character.res3.res3Name;
		}
		else
		{
			for (int l = 0; l < res3InputStuff.Count; l++)
			{
				res3InputStuff[l].SetActive(value: false);
			}
		}
		if (character.bossID < 37)
		{
			bloodMagic.interactable = false;
			bloodMagicText.text = "H*ckin' Locked";
		}
		else if (character.bloodMagic.adventureSpellTime.totalseconds >= (double)character.bloodMagicController.spells.adventureSpellCooldown || (character.bloodMagic.macguffin1Time.totalseconds >= (double)character.bloodMagicController.spells.macguffin1Cooldown && character.adventure.itopod.perkLevel[72] >= 1) || (character.bloodMagic.macguffin2Time.totalseconds >= (double)character.bloodMagicController.spells.macguffin2Cooldown && character.adventure.itopod.perkLevel[73] >= 1))
		{
			bloodMagic.image.color = new Color(0.73f, 0.077f, 0.655f);
		}
		else
		{
			bloodMagic.image.color = Color.white;
		}
		if (!character.settings.wandoos98On)
		{
			wandoos.interactable = false;
			wandoosText.text = "Not Locked,\nJust Broken";
			wandoosText.fontSize = 10;
		}
		if (!character.settings.yggdrasilOn)
		{
			yggdrasil.interactable = false;
			yggdrasilText.text = "Requires Seed ;)";
			yggdrasilText.fontSize = 12;
		}
		else
		{
			yggdrasilText.fontSize = 14;
			if (character.arbitrary.hasYggdrasilReminder)
			{
				if (character.yggdrasilController.anyFruitMaxxed())
				{
					yggdrasil.image.color = new Color(0.5f, 0.827f, 0.235f);
				}
				else
				{
					yggdrasil.image.color = Color.white;
				}
			}
			else
			{
				yggdrasil.image.color = Color.white;
			}
		}
		if (!character.settings.diggersOn)
		{
			diggers.interactable = false;
			diggersText.text = "Gone Diggin'";
		}
		else
		{
			diggers.interactable = true;
			diggersText.text = "Gold Diggers";
		}
		if (character.highestBoss >= 4)
		{
			ngu.gameObject.SetActive(value: true);
		}
		else
		{
			ngu.gameObject.SetActive(value: false);
		}
		if (character.highestBoss >= 17)
		{
			yggdrasil.gameObject.SetActive(value: true);
		}
		else
		{
			yggdrasil.gameObject.SetActive(value: false);
		}
		if (character.highestBoss >= 30)
		{
			diggers.gameObject.SetActive(value: true);
		}
		else
		{
			diggers.gameObject.SetActive(value: false);
		}
		if (character.highestBoss >= 37)
		{
			beards.gameObject.SetActive(value: true);
		}
		else
		{
			beards.gameObject.SetActive(value: false);
		}
		if (!character.settings.nguOn)
		{
			ngu.interactable = false;
			nguText.text = "On Vacation";
			beast.gameObject.SetActive(value: false);
			hacks.gameObject.SetActive(value: false);
			wishes.gameObject.SetActive(value: false);
			cards.gameObject.SetActive(value: false);
		}
		else
		{
			ngu.interactable = true;
			nguText.text = "NGU";
			beast.gameObject.SetActive(value: true);
			hacks.gameObject.SetActive(value: true);
			wishes.gameObject.SetActive(value: true);
			cards.gameObject.SetActive(value: true);
		}
		if (!character.settings.beardsOn)
		{
			beards.interactable = false;
			beardText.text = "Too Bald To Work";
		}
		else
		{
			beards.interactable = true;
			beardText.text = "Beards Of Power";
		}
		if (!character.settings.beastOn)
		{
			beast.interactable = false;
			beastText.text = "I HUNGER";
		}
		else
		{
			beast.interactable = true;
			beastText.text = "Questing";
			if (character.arbitrary.hasQuestLight && character.beastQuest.inQuest && character.beastQuest.curDrops >= character.beastQuest.targetDrops)
			{
				beast.image.color = new Color(0.5f, 0.827f, 0.235f);
			}
			else
			{
				beast.image.color = Color.white;
			}
		}
		if (!character.hacks.hacksOn)
		{
			hacks.interactable = false;
			hacksText.text = "REQUIRES GREASE";
			hacksText.fontSize = 10;
		}
		else
		{
			hacks.interactable = true;
			hacksText.text = "Hacks";
			hacksText.fontSize = 14;
		}
		if (!character.wishes.wishesOn)
		{
			wishes.interactable = false;
			wishesText.text = "YOUSE NOT ALLOWEDS";
			wishesText.fontSize = 10;
		}
		else
		{
			wishes.interactable = true;
			wishesText.text = "Wishes";
			wishesText.fontSize = 14;
		}
		if (!character.cards.cardsOn)
		{
			cards.interactable = false;
			cardsText.text = "Insufficient Gas";
			cardsText.fontSize = 12;
		}
		else
		{
			cards.interactable = true;
			cardsText.text = "Cards";
			cardsText.fontSize = 14;
		}
		if (!character.cooking.unlocked)
		{
			cooking.image.color = Color.white;
			cooking.interactable = false;
			cookingText.text = "NOT RIPE";
			return;
		}
		if (character.cooking.cookTimer >= character.cookingController.eatRate())
		{
			cooking.image.color = Color.red;
		}
		else
		{
			cooking.image.color = Color.white;
		}
		cooking.interactable = true;
		cookingText.text = "Cooking";
	}

	public void showPotionTimers()
	{
		InvokeRepeating("showPotionTimer", 0f, 1f);
	}

	public void showPotionTimer()
	{
		message = "";
		if (character.arbitrary.energyPotion2InUse)
		{
			message += "<b>Energy Potion β Active</b>\n";
		}
		if (character.arbitrary.energyPotion1Time.totalseconds > 0.0)
		{
			message = message + "<b>Energy Potion α/δ Time:</b> " + NumberOutput.timeOutput(character.arbitrary.energyPotion1Time.totalseconds) + "\n";
		}
		if (character.arbitrary.magicPotion2InUse)
		{
			message += "<b>Magic Potion β Active</b>\n";
		}
		if (character.arbitrary.magicPotion1Time.totalseconds > 0.0)
		{
			message = message + "<b>Magic Potion α/δ Time:</b> " + NumberOutput.timeOutput(character.arbitrary.magicPotion1Time.totalseconds) + "\n";
		}
		if (character.arbitrary.res3Potion2InUse)
		{
			message = message + "<b>" + character.res3.res3Name + " Potion β Active</b>\n";
		}
		if (character.arbitrary.res3Potion1Time.totalseconds > 0.0)
		{
			message = message + "<b>" + character.res3.res3Name + " Potion α/δ Time:</b> " + NumberOutput.timeOutput(character.arbitrary.res3Potion1Time.totalseconds) + "\n";
		}
		if (character.arbitrary.energyBarBar1Time.totalseconds > 0.0)
		{
			message = message + "<b>Energy Bar Bar Time:</b> " + NumberOutput.timeOutput(character.arbitrary.energyBarBar1Time.totalseconds) + "\n";
		}
		if (character.arbitrary.magicBarBar1Time.totalseconds > 0.0)
		{
			message = message + "<b>Magic Bar Bar Time:</b> " + NumberOutput.timeOutput(character.arbitrary.magicBarBar1Time.totalseconds) + "\n";
		}
		if (character.arbitrary.lootcharm1Time.totalseconds > 0.0)
		{
			message = message + "<b>Lucky Charm Time:</b> " + NumberOutput.timeOutput(character.arbitrary.lootcharm1Time.totalseconds) + "\n";
		}
		if (character.arbitrary.macGuffinBooster1InUse)
		{
			message += "<b>MacGuffin Muffin Active for the next rebirth.</b>\n";
		}
		else if (character.arbitrary.macGuffinBooster1Time.totalseconds > 0.0)
		{
			message = message + "<b>MacGuffin Muffin Time:</b> " + NumberOutput.timeOutput(character.arbitrary.macGuffinBooster1Time.totalseconds) + "\n";
		}
		if (character.arbitrary.mayoSpeedPotTime.totalseconds > 0.0)
		{
			message = message + "<b>Mayo Infuser Time:</b> " + NumberOutput.timeOutput(character.arbitrary.mayoSpeedPotTime.totalseconds) + "\n";
		}
		if (message == "")
		{
			message = message + "You have <b>" + character.display(character.arbitrary.curArbitraryPoints) + "</b> Arbitrary Points.";
		}
		else
		{
			message = message + "\nYou have <b>" + character.display(character.arbitrary.curArbitraryPoints) + "</b> Arbitrary Points.";
		}
		if (message != "")
		{
			tooltip.showTooltip(message);
		}
	}

	public void hideTooltip()
	{
		CancelInvoke("showPotionTimer");
		CancelInvoke("showTitanTimer");
		tooltip.hideTooltip();
	}

	public void showTitanTimers()
	{
		if (adventure.interactable)
		{
			InvokeRepeating("showTitanTimer", 0f, 1f);
		}
	}

	public void showTitanTimer()
	{
		message = "";
		if (!adventure.interactable)
		{
			return;
		}
		if (character.bossID >= 58 || character.achievements.achievementComplete[128])
		{
			if (character.adventure.boss1Spawn.totalseconds >= (double)character.adventureController.boss1SpawnTime())
			{
				message += "<b>GRB SPAWN READY</b>";
			}
			else
			{
				message = message + "<b>Time until GRB Spawn: </b>" + NumberOutput.timeOutput((double)character.adventureController.boss1SpawnTime() - character.adventure.boss1Spawn.totalseconds);
			}
		}
		if (character.bossID >= 66 || character.achievements.achievementComplete[129])
		{
			if (character.adventure.boss2Spawn.totalseconds >= (double)character.adventureController.boss2SpawnTime())
			{
				message += "\n<b>GCT SPAWN READY</b>";
			}
			else
			{
				message = message + "\n<b>Time until GCT Spawn: </b>" + NumberOutput.timeOutput((double)character.adventureController.boss2SpawnTime() - character.adventure.boss2Spawn.totalseconds);
			}
		}
		if (character.bossID >= 82 || character.bestiary.enemies[304].kills > 0)
		{
			if (character.adventure.boss3Spawn.totalseconds >= (double)character.adventureController.boss3SpawnTime())
			{
				message += "\n<b>JAKE SPAWN READY</b>";
			}
			else
			{
				message = message + "\n<b>Time until Jake Spawn: </b>" + NumberOutput.timeOutput((double)character.adventureController.boss3SpawnTime() - character.adventure.boss3Spawn.totalseconds);
			}
		}
		if (character.bossID >= 100 || character.achievements.achievementComplete[130])
		{
			if (character.adventure.boss4Spawn.totalseconds >= (double)character.adventureController.boss4SpawnTime())
			{
				message += "\n<b>UUG SPAWN READY</b>";
			}
			else
			{
				message = message + "\n<b>Time until Uug Spawn: </b>" + NumberOutput.timeOutput((double)character.adventureController.boss4SpawnTime() - character.adventure.boss4Spawn.totalseconds);
			}
		}
		if (character.bossID >= 116 || character.achievements.achievementComplete[145])
		{
			if (character.adventure.boss5Spawn.totalseconds >= (double)character.adventureController.boss5SpawnTime())
			{
				message += "\n<b>WALDERP SPAWN READY</b>";
			}
			else
			{
				message = message + "\n<b>Time until Walderp Spawn: </b>" + NumberOutput.timeOutput((double)character.adventureController.boss5SpawnTime() - character.adventure.boss5Spawn.totalseconds);
			}
		}
		if (character.bossID >= 132 || character.adventure.boss6Kills >= 1)
		{
			if (character.adventure.boss6Spawn.totalseconds >= (double)character.adventureController.boss6SpawnTime())
			{
				message += "\n<b>THE BEAST SPAWN READY</b>\n";
			}
			else
			{
				message = message + "\n<b>Time until Beast Spawn: </b>" + NumberOutput.timeOutput((double)character.adventureController.boss6SpawnTime() - character.adventure.boss6Spawn.totalseconds);
			}
		}
		if (character.effectiveBossID() >= 426 || character.adventure.boss7Kills >= 1)
		{
			if (character.adventure.boss7Spawn.totalseconds >= (double)character.adventureController.boss7SpawnTime())
			{
				message += "\n<b>GREASY NERD SPAWN READY</b>";
			}
			else
			{
				message = message + "\n<b>Time until Greasy Nerd Spawn: </b>" + NumberOutput.timeOutput((double)character.adventureController.boss7SpawnTime() - character.adventure.boss7Spawn.totalseconds);
			}
		}
		if (character.adventure.titan7questStarted && !character.adventure.titan7Unlocked)
		{
			message += "\n<b>GREASY NERD SECRET CODE PROGRESS:</b>";
			switch (character.adventure.titan7QuestSequence)
			{
			case 0:
				message += "\n_ _ _ _ _";
				break;
			case 1:
				message += "\nF _ _ _ _";
				break;
			case 2:
				message += "\nF A _ _ _";
				break;
			case 3:
				message += "\nF A R _ _";
				break;
			case 4:
				message += "\nF A R T _";
				break;
			default:
				message += "\n_ _ _ _ _";
				break;
			}
		}
		if (character.effectiveBossID() >= 467 || character.adventure.boss8Kills >= 1)
		{
			if (character.adventure.boss8Spawn.totalseconds >= (double)character.adventureController.boss8SpawnTime())
			{
				message += "\n<b>GODMOTHER SPAWN READY</b>";
			}
			else
			{
				message = message + "\n<b>Time until Godmother Spawn: </b>" + NumberOutput.timeOutput((double)character.adventureController.boss8SpawnTime() - character.adventure.boss8Spawn.totalseconds);
			}
		}
		if (character.effectiveBossID() >= 491 || character.adventure.boss9Kills >= 1)
		{
			if (character.adventure.boss9Spawn.totalseconds >= (double)character.adventureController.boss9SpawnTime())
			{
				message += "\n<b>EXILE SPAWN READY</b>";
			}
			else
			{
				message = message + "\n<b>Time until Exile Spawn: </b>" + NumberOutput.timeOutput((double)character.adventureController.boss9SpawnTime() - character.adventure.boss9Spawn.totalseconds);
			}
		}
		if (character.effectiveBossID() >= 727 || character.adventure.boss10Kills >= 1)
		{
			if (character.adventure.boss10Spawn.totalseconds >= (double)character.adventureController.boss10SpawnTime())
			{
				message += "\n<b>IT HUNGERS SPAWN READY</b>";
			}
			else
			{
				message = message + "\n<b>Time until IT HUNGERS Spawn: </b>" + NumberOutput.timeOutput((double)character.adventureController.boss10SpawnTime() - character.adventure.boss10Spawn.totalseconds);
			}
		}
		if (character.effectiveBossID() >= 826 || character.adventure.boss11Kills >= 1)
		{
			if (character.adventure.boss11Spawn.totalseconds >= (double)character.adventureController.boss11SpawnTime())
			{
				message += "\n<b>ROCK LOBSTER SPAWN READY</b>";
			}
			else
			{
				message = message + "\n<b>Time until ROCK LOBSTER Spawn: </b>" + NumberOutput.timeOutput((double)character.adventureController.boss11SpawnTime() - character.adventure.boss11Spawn.totalseconds);
			}
		}
		if (character.effectiveBossID() >= 848 || character.adventure.boss12Kills >= 1)
		{
			if (character.adventure.boss12Spawn.totalseconds >= (double)character.adventureController.boss12SpawnTime())
			{
				message += "\n<b>AMALGAMATE SPAWN READY</b>";
			}
			else
			{
				message = message + "\n<b>Time until AMALGAMATE Spawn: </b>" + NumberOutput.timeOutput((double)character.adventureController.boss12SpawnTime() - character.adventure.boss12Spawn.totalseconds);
			}
		}
		if (character.effectiveBossID() >= 897 || character.adventure.ratTitanDefeated)
		{
			if (character.adventure.boss13Spawn.totalseconds >= (double)character.adventureController.boss13SpawnTime())
			{
				message += "\n<b>TIPPI SPAWN READY</b>";
			}
			else
			{
				message = message + "\n<b>Time until TIPPI Spawn: </b>" + NumberOutput.timeOutput((double)character.adventureController.boss13SpawnTime() - character.adventure.boss13Spawn.totalseconds);
			}
		}
		if (character.effectiveBossID() >= 902 && character.adventure.ratTitanDefeated)
		{
			if (character.adventure.boss14Spawn.totalseconds >= (double)character.adventureController.boss14SpawnTime())
			{
				message += "\n<b>TRAITOR SPAWN READY</b>";
			}
			else
			{
				message = message + "\n<b>Time until TRAITOR Spawn: </b>" + NumberOutput.timeOutput((double)character.adventureController.boss14SpawnTime() - character.adventure.boss14Spawn.totalseconds);
			}
		}
		if (message != "")
		{
			tooltip.showTooltip(message);
		}
	}

	public void showWandoosLevels()
	{
		string text = "";
		if (wandoos.interactable)
		{
			if (character.settings.wandoos98On)
			{
				text = "<b>OS Level Breakdown</b>";
			}
			if (character.wandoos98.OSlevel > 0)
			{
				text = text + "\n\n<b>Wandoos 98 Levels: " + character.wandoos98.OSlevel + "/100</b>";
			}
			if (character.wandoos98.pitOSLevels > 0)
			{
				text = text + "\n<b>Money Pit Levels: " + character.wandoos98.pitOSLevels + "/100</b>";
			}
			if (character.wandoos98.XLLevels > 0)
			{
				text = text + "\n<b>Wandoos XL Levels: " + character.wandoos98.XLLevels + "/100</b>";
			}
			if (character.adventureController.itopod.totalOSLevelBonus() > 0)
			{
				text = text + "\n<b>I.T.O.P.O.D Levels: " + character.adventureController.itopod.totalOSLevelBonus() + "/100</b>";
			}
			if (text != "")
			{
				tooltip.showTooltip(text);
			}
		}
		else
		{
			text = "Find a special item to unlock this!";
			tooltip.showTooltip(text);
		}
	}

	public void showBloodMagicTooltip()
	{
		string text = "";
		if (!bloodMagic.interactable)
		{
			text = "Reach boss 37 to see what this becomes!";
			tooltip.showTooltip(text);
		}
	}

	public void startAutoNukeTooltip()
	{
		InvokeRepeating("showAutoNukeTimer", 0f, 0.1f);
	}

	public void showAutoNukeTimer()
	{
		string text = "";
		if (character.arbitrary.boughtAutoNuke && character.settings.autoNukeOn)
		{
			text = text + "<b>Time Until Auto Nuke: </b>" + NumberOutput.timeOutput((double)character.bossController.autoNukeThreshold() - character.arbitrary.nukeTimer.totalseconds);
		}
		if (text != "")
		{
			tooltip.showTooltip(text);
		}
	}

	public void endAutoNukeTooltip()
	{
		CancelInvoke("showAutoNukeTimer");
		tooltip.hideTooltip();
	}

	public void showQuestTooltip()
	{
		InvokeRepeating("showQuestStatus", 0f, 0.1f);
	}

	public void showQuestStatus()
	{
		string text = "";
		if (character.settings.beastOn && character.beastQuest.inQuest)
		{
			text = "<b>Current Quest Objective:</b>\nCollect <color=blue><b>[QUEST ITEM] </b></color> " + character.itemInfo.itemName[character.beastQuest.questID].Substring(40);
			text = text + "\n<b>Location: </b>" + character.beastQuestController.questItemLocation(character.beastQuest.questID);
			text = text + "\n<b>Progress:</b>" + character.beastQuest.curDrops + "/" + character.beastQuest.targetDrops;
			text = text + "\n<b>Major Quests Available: </b>" + character.beastQuest.curBankedQuests + "/" + character.beastQuestController.maxBankedQuests();
			text = text + "\n<b>Time until next Major Quest: </b>" + NumberOutput.timeOutput((double)character.beastQuestController.timerThreshold() - character.beastQuest.dailyQuestTimer.totalseconds);
			tooltip.showTooltip(text);
		}
		else if (character.settings.beastOn && !character.beastQuest.inQuest)
		{
			text = "<b>YOU AREN'T IN A QUEST, DUMBASS.</b>";
			tooltip.showTooltip(text);
		}
	}

	public void exitQuestTooltip()
	{
		CancelInvoke("showQuestStatus");
	}

	public void showCardTooltip()
	{
		InvokeRepeating("showCardStatus", 0f, 0.1f);
	}

	public void showCardStatus()
	{
		if (character.cards.cardsOn)
		{
			string text = "";
			text = text + "<b>Next Card Spawns in: " + character.cardsController.timeToCardSpawn() + "</b>";
			if (character.cardsController.unlockedChonkers())
			{
				text = text + "\n<b>Next CHONKER Spawns in: " + character.cardsController.timeToChonkerSpawn() + "</b>";
			}
			tooltip.showTooltip(text);
		}
	}

	public void exitCardTooltip()
	{
		CancelInvoke("showCardStatus");
	}
}
