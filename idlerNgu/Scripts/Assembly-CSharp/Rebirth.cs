using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Rebirth : MonoBehaviour
{
	public Character character;

	public Boss boss;

	public HoverTooltip tooltip;

	public ConfirmationBox box;

	private UnityAction yesAction;

	private UnityAction noAction;

	public bool normalRebirthFlag;

	public bool hardRebirthFlag;

	public bool sadisticRebirthFlag;

	public Button normalDifficultyButton;

	public Button evilDifficultyButton;

	public Button sadisticDifficultyButton;

	private void Awake()
	{
		noAction = cancel;
	}

	private void Update()
	{
		calculateTimeMulti();
		calculateNextMultis();
	}

	public void rebirth()
	{
		normalRebirthFlag = character.settings.rebirthDifficulty == difficulty.normal;
		hardRebirthFlag = character.settings.rebirthDifficulty == difficulty.evil;
		sadisticRebirthFlag = character.settings.rebirthDifficulty == difficulty.sadistic;
		if (character.nextRebirthDifficulty == character.settings.rebirthDifficulty && character.bossID <= 0)
		{
			tooltip.showTooltip("You must defeat the first Boss in order to rebirth!", 2f);
			return;
		}
		if (character.bossController.nukeBoss || character.bossController.isFighting)
		{
			tooltip.showOverrideTooltip("You're either in the middle of a boss nuke or fighting a boss - let that finish first!", 2f);
			return;
		}
		if (character.challenges.noRebirthChallenge.inChallenge)
		{
			tooltip.showTooltip("NO REBIRTHS ON THIS CHALLENGE. STAHP TOUCHING ME!", 2f);
			return;
		}
		if (character.rebirthTime.totalseconds < (double)minRebirthTime())
		{
			tooltip.showTooltip("Not so fast buddy! You got to wait at least " + minRebirthTime() + " seconds between rebirths!", 2f);
			return;
		}
		yesAction = engage;
		if (character.nextRebirthDifficulty != character.settings.rebirthDifficulty)
		{
			yesAction = rebirthDifficultySwitch;
		}
		box.displayBox("Are you sure you want to rebirth?", yesAction, noAction);
	}

	public void rebirthDifficultySwitch()
	{
		difficulty rebirthDifficulty = character.settings.rebirthDifficulty;
		if (character.nextRebirthDifficulty == difficulty.normal)
		{
			yesAction = startNormalRebirth;
			box.displayBox(string.Concat("Are you sure you want to change your rebirth difficulty from ", rebirthDifficulty, " to Normal difficulty? Your NUMBER will reset to 1. Normal difficulty removes all negative modifiers, but has lower rewards."), yesAction, noAction);
		}
		else if (character.nextRebirthDifficulty == difficulty.evil)
		{
			yesAction = startHardRebirth;
			box.displayBox(string.Concat("Are you sure you want to change your rebirth difficulty from ", rebirthDifficulty, " to Evil difficulty? Your NUMBER will reset to 1. Evil difficulty adds massive negative speed modifiers to just about everything, in exchange for unlocking amazing new features and incredible power! \n\n<b>You'll probably need at least:</b>\n10 Billion Energy and Magic\n10 Million Energy and Magic Power\n10 Million Energy and Magic Gained Per Bar"), yesAction, noAction);
		}
		else if (character.nextRebirthDifficulty == difficulty.sadistic)
		{
			yesAction = startSadisticRebirth;
			box.displayBox(string.Concat("Are you sure you want to change your rebirth difficulty from ", rebirthDifficulty, " to SADISTIC difficulty? Your NUMBER will reset to 1. SADISTIC difficulty is just goddamn impossible. Don't even try. YOU HAVE BEEN WARNED\n\n<b>You'll probably need at least:</b>\nTitan 9 v4 Defeated\nStat bonus from Rich Jerks, Rich Perks, and Wishes totalling ", character.display(100000000376832.0), "%"), yesAction, noAction);
		}
	}

	public void setNormalNextRebirth()
	{
		if (character.challenges.inChallenge)
		{
			tooltip.showOverrideTooltip("No changing the difficulty on a challenge!");
			return;
		}
		character.nextRebirthDifficulty = difficulty.normal;
		updateDifficultyButtons();
	}

	public void setEvilNextRebirth()
	{
		if (character.challenges.inChallenge)
		{
			tooltip.showOverrideTooltip("No changing the difficulty on a challenge!", 2f);
			return;
		}
		if (!character.achievements.achievementComplete[152])
		{
			if (character.highestBoss < 300)
			{
				tooltip.showOverrideTooltip("You need to have reached Boss 301 to even think about switching the difficulty!", 2f);
				return;
			}
			if (!character.achievements.achievementComplete[151])
			{
				tooltip.showOverrideTooltip("You need to slay the BEAST v4 at least once to even think about switching the difficulty!", 2f);
				return;
			}
			if ((double)character.attackBoost * character.adventureController.itopod.totalStatBonus() < 10000.0)
			{
				tooltip.showOverrideTooltip("You need at least a " + character.display(1000000.0) + "% bonus in total from the rich jerk perks and exp purchases to switch difficulties. Buy more of both of them! \n\n(Trust me, you're gonna need it.)", 3f);
				return;
			}
		}
		character.nextRebirthDifficulty = difficulty.evil;
		updateDifficultyButtons();
	}

	public void setSadisticNextRebirth()
	{
		if (character.challenges.inChallenge)
		{
			tooltip.showOverrideTooltip("No changing the difficulty on a challenge!");
			return;
		}
		if (character.highestHardBoss < 300)
		{
			tooltip.showOverrideTooltip("You need to have reached Boss 301 on Evil to even think about switching the difficulty!", 2f);
			return;
		}
		if (!character.settings.exilev4Defeated)
		{
			tooltip.showOverrideTooltip("You need to defeat The Exile v4 to even think about switching the difficulty!", 2f);
			return;
		}
		character.nextRebirthDifficulty = difficulty.sadistic;
		updateDifficultyButtons();
	}

	public void updateDifficultyButtons()
	{
		if (character.menuID == 23)
		{
			if (character.nextRebirthDifficulty == difficulty.normal)
			{
				normalDifficultyButton.interactable = false;
				evilDifficultyButton.interactable = true;
				sadisticDifficultyButton.interactable = true;
			}
			else if (character.nextRebirthDifficulty == difficulty.evil)
			{
				normalDifficultyButton.interactable = true;
				evilDifficultyButton.interactable = false;
				sadisticDifficultyButton.interactable = true;
			}
			else if (character.nextRebirthDifficulty == difficulty.sadistic)
			{
				normalDifficultyButton.interactable = true;
				evilDifficultyButton.interactable = true;
				sadisticDifficultyButton.interactable = false;
			}
		}
	}

	private void engage()
	{
		engage(hardReset: false);
	}

	private void engage(bool hardReset)
	{
		checkSpecial();
		awardAP();
		character.allBeards.convertBeardTrimmings();
		character.inventoryController.applyAllMacguffinBonuses();
		character.arbitrary.macGuffinBooster1InUse = false;
		checkSecrets();
		setNewMultis();
		resetEnergy();
		resetMagic();
		resetRes3();
		resetTraining();
		resetBoss();
		resetTime();
		character.resetAll();
		resetGold();
		resetStats();
		character.yggdrasil.reset();
		character.stats.rebirthNumber++;
		if (character.arbitrary.instaTrain)
		{
			instaTrain();
		}
		character.refreshMenus();
		character.buttons.updateButtons();
		if (hardReset)
		{
			hardResetMultis();
			character.advancedTrainingController.challengeReset();
			character.allBeards.challengeReset();
			character.timeMachineController.challengeReset();
		}
		if (!hardReset && character.settings.beardsOn)
		{
			character.allBeards.addBankedLevels();
		}
		character.nextRebirthDifficulty = character.settings.rebirthDifficulty;
		if (character.settings.res3NameGeneratorOn && character.arbitrary.res3NameGeneratorBought)
		{
			character.res3.res3Name = character.res3Display.randomStarterName();
		}
	}

	public void checkSpecial()
	{
		if (character.adventure.clue1Complete && character.adventure.clue2Complete && character.adventure.clue3Complete && character.adventure.clue4Complete && character.rebirthTime.totalseconds > 2585.0 && character.rebirthTime.totalseconds < 2615.0 && !character.adventure.titan6Unlocked)
		{
			character.adventure.titan6Unlocked = true;
			tooltip.showOverrideTooltip("YOU HAVE RELEASED THE POWER OF THE BEAST! TREMBLE IN FEAR AT YOUR OWN STUPIDITY!", 5f);
		}
	}

	public void instaTrain()
	{
		if (character.capEnergy >= 12)
		{
			character.curEnergy += 12L;
			character.training.attackEnergy[0] = 6L;
			character.training.defenseEnergy[0] = 6L;
		}
	}

	public void refreshMenus()
	{
	}

	public void awardAP()
	{
		long num = (long)character.rebirthTime.totalseconds - 3600;
		if (num < 0)
		{
			num = 0L;
		}
		long amount = num / 500;
		character.addAP(amount);
	}

	public void checkSecrets()
	{
		if (!character.settings.gotSpeedrunSecret)
		{
			checkSpeedrunSecret();
		}
	}

	public void checkSpeedrunSecret()
	{
		if (character.bossID >= 37 && character.rebirthTime.totalseconds <= 1800.0)
		{
			character.settings.speedrunCount++;
			if (character.settings.speedrunCount >= 3)
			{
				character.settings.speedrunCount = 3;
				if (!character.settings.gotSpeedrunSecret)
				{
					character.settings.gotSpeedrunSecret = true;
					character.addExp(200L);
					character.energyPower += 1f;
					tooltip.showTooltip("You completed the speedrun 'secret'! Here's 200 EXP and +1 Energy power for your troubles!", 5f);
				}
			}
		}
		else
		{
			character.settings.speedrunCount = 0;
		}
	}

	public int minRebirthTime()
	{
		int num = 180;
		num -= character.wishes.wishes[20].level * 10;
		if (num < 120)
		{
			num = 120;
		}
		if (num > 180)
		{
			num = 180;
		}
		return num;
	}

	public bool verifyChallengeStatus()
	{
		if (character.rebirthTime.totalseconds < (double)minRebirthTime())
		{
			tooltip.showTooltip("Not so fast buddy! You got to wait at least " + minRebirthTime() + " seconds after rebirth to start a challenge!", 2f);
			return false;
		}
		if (character.challenges.inChallenge)
		{
			tooltip.showTooltip("You're already in a challenge, dork! Cancel it first!", 4f);
			return false;
		}
		if (character.bossID <= 0)
		{
			tooltip.showTooltip("You must defeat the first Boss in order to start any Challenge!", 4f);
			return false;
		}
		return true;
	}

	public void startBasicChallenge()
	{
		if (verifyChallengeStatus())
		{
			yesAction = engageBasicChallenge;
			box.displayBox("Are you sure you want to start this Basic Challenge?", yesAction, noAction);
		}
	}

	private void engageBasicChallenge()
	{
		engage(hardReset: true);
		character.challenges.inChallenge = true;
		character.challenges.basicChallenge.inChallenge = true;
		character.challenges.basicChallenge.challengeTime.reset();
		character.challenges.curChallengeType = character.challenges.basicChallenge.challengeType;
		character.buttons.updateButtons();
	}

	public void startNoAugsChallenge()
	{
		if (verifyChallengeStatus())
		{
			yesAction = engageNoAugsChallenge;
			box.displayBox("Are you sure you want to start this No Augs Challenge?", yesAction, noAction);
		}
	}

	private void engageNoAugsChallenge()
	{
		engage(hardReset: true);
		character.challenges.inChallenge = true;
		character.challenges.noAugsChallenge.inChallenge = true;
		character.challenges.noAugsChallenge.challengeTime.reset();
		character.challenges.curChallengeType = character.challenges.noAugsChallenge.challengeType;
		character.buttons.updateButtons();
	}

	public void start24HourChallenge()
	{
		if (verifyChallengeStatus())
		{
			yesAction = engage24HourChallenge;
			box.displayBox("Are you sure you want to start this 24 Hour Challenge?", yesAction, noAction);
		}
	}

	private void engage24HourChallenge()
	{
		engage(hardReset: true);
		character.challenges.inChallenge = true;
		character.challenges.hour24Challenge.inChallenge = true;
		character.challenges.hour24Challenge.challengeTime.reset();
		character.challenges.curChallengeType = character.challenges.hour24Challenge.challengeType;
		character.buttons.updateButtons();
	}

	public void startlevel100Challenge()
	{
		if (verifyChallengeStatus())
		{
			yesAction = engagelevel100Challenge;
			box.displayBox("Are you sure you want to start this 100 level Challenge?", yesAction, noAction);
		}
	}

	private void engagelevel100Challenge()
	{
		engage(hardReset: true);
		character.challenges.inChallenge = true;
		character.challenges.levelChallenge10k.inChallenge = true;
		character.challenges.levelChallenge10k.challengeTime.reset();
		character.challenges.curChallengeType = character.challenges.levelChallenge10k.challengeType;
		character.buttons.updateButtons();
	}

	public void startNoEquipChallenge()
	{
		if (verifyChallengeStatus())
		{
			yesAction = engageNoEquipChallenge;
			box.displayBox("Are you sure you want to start this No Equipment Challenge?", yesAction, noAction);
		}
	}

	private void engageNoEquipChallenge()
	{
		engage(hardReset: true);
		character.challenges.inChallenge = true;
		character.challenges.noEquipmentChallenge.inChallenge = true;
		character.challenges.noEquipmentChallenge.challengeTime.reset();
		character.challenges.curChallengeType = character.challenges.noEquipmentChallenge.challengeType;
		character.inventoryController.updateBonuses();
		character.buttons.updateButtons();
	}

	public void startNoRebirthChallenge()
	{
		if (verifyChallengeStatus())
		{
			yesAction = engageNoRebirthChallenge;
			box.displayBox("Are you sure you want to start this No Rebirth Challenge?", yesAction, noAction);
		}
	}

	private void engageNoRebirthChallenge()
	{
		engage(hardReset: true);
		hardResetMultis();
		character.challenges.inChallenge = true;
		character.challenges.noRebirthChallenge.inChallenge = true;
		character.challenges.noRebirthChallenge.challengeTime.reset();
		character.challenges.curChallengeType = character.challenges.noRebirthChallenge.challengeType;
		character.buttons.updateButtons();
	}

	public void startTrollChallenge()
	{
		Debug.Log("here");
		if (verifyChallengeStatus())
		{
			yesAction = engageTrollChallenge;
			box.displayBox("Are you sure you want to start this Troll Challenge?", yesAction, noAction);
		}
	}

	private void engageTrollChallenge()
	{
		engage(hardReset: true);
		character.challenges.inChallenge = true;
		character.challenges.trollChallenge.inChallenge = true;
		character.challenges.trollChallenge.challengeTime.reset();
		character.allChallenges.trollChallenge.resetTrolls();
		character.challenges.trollCounter = 0;
		character.challenges.curChallengeType = character.challenges.trollChallenge.challengeType;
		character.buttons.updateButtons();
	}

	public void startLaserSwordChallenge()
	{
		if (verifyChallengeStatus())
		{
			yesAction = engageLaserSwordChallenge;
			box.displayBox("Are you sure you want to start this Laser Sword Challenge?", yesAction, noAction);
		}
	}

	private void engageLaserSwordChallenge()
	{
		engage();
		character.challenges.inChallenge = true;
		character.challenges.laserSwordChallenge.inChallenge = true;
		character.challenges.laserSwordChallenge.challengeTime.reset();
		character.challenges.curChallengeType = character.challenges.laserSwordChallenge.challengeType;
		character.buttons.updateButtons();
	}

	public void startBlindChallenge()
	{
		if (verifyChallengeStatus())
		{
			yesAction = engageBlindChallenge;
			box.displayBox("Are you sure you want to start this Blind Challenge?", yesAction, noAction);
		}
	}

	private void engageBlindChallenge()
	{
		engage(hardReset: true);
		character.challenges.inChallenge = true;
		character.challenges.blindChallenge.inChallenge = true;
		character.challenges.blindChallenge.challengeTime.reset();
		character.challenges.curChallengeType = character.challenges.blindChallenge.challengeType;
		character.buttons.updateButtons();
		character.refreshMenus();
	}

	public void startNGUChallenge()
	{
		if (verifyChallengeStatus())
		{
			yesAction = engageNGUChallenge;
			box.displayBox("Are you sure you want to start this No NGU Challenge?", yesAction, noAction);
		}
	}

	private void engageNGUChallenge()
	{
		engage(hardReset: true);
		character.challenges.inChallenge = true;
		character.challenges.nguChallenge.inChallenge = true;
		character.challenges.nguChallenge.challengeTime.reset();
		character.NGU.disabled = true;
		character.challenges.curChallengeType = character.challenges.nguChallenge.challengeType;
		character.buttons.updateButtons();
		character.refreshMenus();
	}

	public void startTimeMachineChallenge()
	{
		if (verifyChallengeStatus())
		{
			yesAction = engageTimeMachineChallenge;
			box.displayBox("Are you sure you want to start this No Time Machine Challenge?", yesAction, noAction);
		}
	}

	private void engageTimeMachineChallenge()
	{
		engage(hardReset: true);
		character.challenges.inChallenge = true;
		character.challenges.timeMachineChallenge.inChallenge = true;
		character.challenges.timeMachineChallenge.challengeTime.reset();
		character.challenges.curChallengeType = character.challenges.timeMachineChallenge.challengeType;
		character.buttons.updateButtons();
		character.refreshMenus();
	}

	private void hardResetMultis()
	{
		character.attackMulti = 1.0;
		character.defenseMulti = 1.0;
		character.nextAttackMulti = 1.0;
		character.nextDefenseMulti = 1.0;
		character.bossMulti = 1.0;
		character.timeMulti = 1.0;
		character.oldBossMulti = 1.0;
		character.oldTimeMulti = 1.0;
	}

	public void startNormalRebirth()
	{
		character.settings.rebirthDifficulty = difficulty.normal;
		character.nextRebirthDifficulty = difficulty.normal;
		if (character.settings.nguLevelTrack > difficulty.normal)
		{
			character.settings.nguLevelTrack = difficulty.normal;
		}
		engage(hardReset: true);
		hardResetMultis();
	}

	public void startHardRebirth()
	{
		character.settings.rebirthDifficulty = difficulty.evil;
		character.nextRebirthDifficulty = difficulty.evil;
		if (character.settings.nguLevelTrack > difficulty.evil)
		{
			character.settings.nguLevelTrack = difficulty.evil;
		}
		engage(hardReset: true);
		character.allAchievements.markAchievementAsComplete(152);
		hardResetMultis();
	}

	public void startSadisticRebirth()
	{
		character.settings.rebirthDifficulty = difficulty.sadistic;
		character.nextRebirthDifficulty = difficulty.sadistic;
		engage(hardReset: true);
		hardResetMultis();
	}

	private void cancel()
	{
	}

	private void setNewMultis()
	{
		character.attackMulti = character.nextAttackMulti;
		character.defenseMulti = character.nextDefenseMulti;
		character.oldBossMulti = character.bossMulti;
		character.oldTimeMulti = character.timeMulti;
		character.stats.lastBloodMagic = character.bloodMagic.rebirthPower;
	}

	private void resetEnergy()
	{
		if (character.capEnergy <= 100000)
		{
			character.capEnergy = (long)Math.Floor((decimal)(character.energyGained / 20 + 500));
			if (character.capEnergy > 100000)
			{
				character.capEnergy = 100000L;
			}
		}
		character.curEnergy = 0L;
		character.idleEnergy = 0L;
	}

	public string rebirthTime()
	{
		return NumberOutput.timeOutput(character.rebirthTime.totalseconds);
	}

	private void resetMagic()
	{
		character.magic.reset();
	}

	private void resetRes3()
	{
		character.res3.reset();
	}

	private void resetTraining()
	{
		for (int i = 0; i < character.training.getTrainingSize(); i++)
		{
			long num = 0L;
			long num2 = 0L;
			num = (long)(1f + Mathf.Pow((float)character.training.attackTraining[i] - 500f * (float)i, 1.2f) / 500f * ((float)character.training.attackCaps[i] / 1000f));
			if (num <= 1)
			{
				num = 1L;
			}
			num2 = character.training.attackCaps[i] / 10 + 1;
			if (num > num2)
			{
				num = num2;
			}
			if (character.training.attackCaps[i] - num <= 1)
			{
				character.training.attackCaps[i] = 1;
			}
			else
			{
				character.training.attackCaps[i] -= (int)num;
			}
			num = (long)(1f + Mathf.Pow((float)character.training.defenseTraining[i] - 500f * (float)i, 1.2f) / 500f * ((float)character.training.defenseCaps[i] / 1000f));
			if (num <= 1)
			{
				num = 1L;
			}
			num2 = character.training.defenseCaps[i] / 10 + 1;
			if (num > num2)
			{
				num = num2;
			}
			if (character.training.defenseCaps[i] - num <= 1)
			{
				character.training.defenseCaps[i] = 1;
			}
			else
			{
				character.training.defenseCaps[i] -= (int)num;
			}
			character.training.attackTraining[i] = 0L;
			character.training.defenseTraining[i] = 0L;
			character.training.attackEnergy[i] = 0L;
			character.training.defenseEnergy[i] = 0L;
			character.training.attackBarProgress[i] = 0f;
			character.training.defenseBarProgress[i] = 0f;
			character.training.totalAttackLevels = 0L;
			character.training.totalDefenseLevels = 0L;
		}
	}

	private void resetBoss()
	{
		character.bossID = 0;
		character.bossAttack = boss.bossAttack[character.bossID];
		character.bossDefense = boss.bossDefense[character.bossID];
		character.bossRegen = boss.bossRegen[character.bossID];
		character.bossCurHP = boss.bossCurHP[character.bossID];
		character.bossMaxHP = boss.bossMaxHP[character.bossID];
		character.bossMulti = 1.0;
		character.arbitrary.nukeTimer.setTime(50f);
	}

	private void resetTime()
	{
		character.rebirthTime.totalseconds = 0.0;
		character.rebirthTime.seconds = 0.0;
		character.rebirthTime.minutes = 0;
		character.rebirthTime.hours = 0;
		character.rebirthTime.days = 0;
	}

	private void resetGold()
	{
		character.gold = 0f;
		character.realGold = 0.0;
		character.pit.tossedGold = false;
		character.pit.tossCount = 0;
	}

	private void resetAdvancedTraining()
	{
		character.advancedTraining.reset();
	}

	private void resetAugments()
	{
		character.augments.resetAugs();
	}

	private void calculateTimeMulti()
	{
		if (character.rebirthTime.totalseconds < 60.0)
		{
			character.timeMulti = character.rebirthTime.totalseconds / 34359738368.0 / 3600.0;
		}
		else if (character.rebirthTime.totalseconds < 120.0)
		{
			character.timeMulti = character.rebirthTime.totalseconds / 33554432.0 / 3600.0;
		}
		else if (character.rebirthTime.totalseconds < 180.0)
		{
			character.timeMulti = character.rebirthTime.totalseconds / 518144.0 / 3600.0;
		}
		else if (character.rebirthTime.totalseconds < 240.0)
		{
			character.timeMulti = character.rebirthTime.totalseconds / 16192.0 / 3600.0;
		}
		else if (character.rebirthTime.totalseconds < 300.0)
		{
			character.timeMulti = character.rebirthTime.totalseconds / 2048.0 / 3600.0;
		}
		else if (character.rebirthTime.totalseconds < 420.0)
		{
			character.timeMulti = character.rebirthTime.totalseconds / 512.0 / 3600.0;
		}
		else if (character.rebirthTime.totalseconds < 600.0)
		{
			character.timeMulti = character.rebirthTime.totalseconds / 128.0 / 3600.0;
		}
		else if (character.rebirthTime.totalseconds < 720.0)
		{
			character.timeMulti = character.rebirthTime.totalseconds / 32.0 / 3600.0;
		}
		else if (character.rebirthTime.totalseconds < 900.0)
		{
			character.timeMulti = character.rebirthTime.totalseconds / 8.0 / 3600.0;
		}
		else if (character.rebirthTime.totalseconds < 1800.0)
		{
			character.timeMulti = character.rebirthTime.totalseconds / 4.0 / 3600.0;
		}
		else if (character.rebirthTime.totalseconds < 3600.0)
		{
			character.timeMulti = character.rebirthTime.totalseconds / 2.0 / 3600.0;
		}
		else if (character.rebirthTime.totalseconds >= 3600.0)
		{
			character.timeMulti = 1.0 + character.rebirthTime.totalseconds / 172800.0;
		}
	}

	private void calculateNextMultis()
	{
		character.nextAttackMulti = 1.0 + character.bossMulti * (character.oldBossMulti * character.oldTimeMulti * (double)(character.training.totalAttackLevels / 10000 + 1)) * (double)character.inventory.macguffinBonuses[17] * character.timeMulti * character.yggdrasilController.permNumberBonus() * character.bloodMagic.rebirthPower * (double)character.allBeards.numberBonus() * (character.NGUController.numberBonus() * (double)character.hacksController.totalNumberBonus());
		character.nextDefenseMulti = 1.0 + character.bossMulti * (character.oldBossMulti * character.oldTimeMulti * (double)(character.training.totalAttackLevels / 10000 + 1)) * (double)character.inventory.macguffinBonuses[17] * character.timeMulti * character.yggdrasilController.permNumberBonus() * character.bloodMagic.rebirthPower * (double)character.allBeards.numberBonus() * (character.NGUController.numberBonus() * (double)character.hacksController.totalNumberBonus());
	}

	private void resetStats()
	{
		character.attack = 100.0;
		character.defense = 100.0;
		character.settings.rebirthLevels = 0L;
	}

	public void tryHardReset()
	{
		yesAction = tryHardReset2;
		box.displayBox("Um, this is gonna erase ALL your data, forever and always. Are you SURE you wanna do this?", yesAction, noAction);
	}

	public void tryHardReset2()
	{
		yesAction = tryHardReset3;
		box.displayBox("This isn't a joke, I'll destroy your save if you go any further. Are you POSITIVE you wanna do this?", yesAction, noAction);
	}

	public void tryHardReset3()
	{
		yesAction = doHardReset;
		box.displayBox("One last chance and then I'll actually do it. Do you want to KILL this save file?", "Nah", "Yeah", noAction, yesAction);
	}

	public void doHardReset()
	{
		character.hardReset();
	}

	public void hardReset()
	{
		engage();
		hardResetMultis();
	}
}
