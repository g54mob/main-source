using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class ImportExport : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	private MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

	public void loadSaveData(SaveData data)
	{
	}

	public PlayerData gameStateToData()
	{
		return new PlayerData
		{
			playerName = character.playerName,
			firstTimePlaying = character.firstTimePlaying,
			version = character.getVersion(),
			nextRebirthDifficulty = character.nextRebirthDifficulty,
			curHP = character.curHP,
			maxHP = character.maxHP,
			hpRegen = character.hpRegen,
			attack = character.attack,
			defense = character.defense,
			gold = character.gold,
			realGold = character.realGold,
			attackMulti = character.attackMulti,
			defenseMulti = character.defenseMulti,
			oldBossMulti = character.oldBossMulti,
			timeMulti = character.timeMulti,
			oldTimeMulti = character.oldTimeMulti,
			exp = character.exp,
			realExp = character.realExp,
			attackBoost = character.attackBoost,
			defenseBoost = character.defenseBoost,
			energySpeed = character.energySpeed,
			curEnergy = character.curEnergy,
			idleEnergy = character.idleEnergy,
			capEnergy = character.capEnergy,
			energyGained = character.energyGained,
			energyPerBar = character.energyPerBar,
			energyBars = character.energyBars,
			energyPower = character.energyPower,
			energyBarProgress = character.energyBarProgress,
			training = character.training,
			bossID = character.bossID,
			bossAttack = character.bossAttack,
			bossDefense = character.bossDefense,
			bossRegen = character.bossRegen,
			bossCurHP = character.bossCurHP,
			bossMaxHP = character.bossMaxHP,
			bossMulti = character.bossMulti,
			highestBoss = character.highestBoss,
			highestHardBoss = character.highestHardBoss,
			highestSadisticBoss = character.highestSadisticBoss,
			firstBossEver = character.firstBossEver,
			currentHighestBoss = character.currentHighestBoss,
			adventure = character.adventure,
			inventory = character.inventory,
			advancedTraining = character.advancedTraining,
			augments = character.augments,
			machine = character.machine,
			magic = character.magic,
			bloodMagic = character.bloodMagic,
			rebirthTime = character.rebirthTime,
			totalPlaytime = character.totalPlaytime,
			lootState = character.lootState,
			boostState = character.boostState,
			purchases = character.purchases,
			stats = character.stats,
			perks = character.perks,
			settings = character.settings,
			challenges = character.challenges,
			pit = character.pit,
			lootBoxes = character.lootBoxes,
			wandoos98 = character.wandoos98,
			lastTime = character.lastTime,
			yggdrasil = character.yggdrasil,
			NGU = character.NGU,
			arbitrary = character.arbitrary,
			achievements = character.achievements,
			daily = character.daily,
			beards = character.beards,
			diggers = character.diggers,
			beastQuest = character.beastQuest,
			res3 = character.res3,
			hacks = character.hacks,
			wishes = character.wishes,
			portraits = character.portraits,
			bestiary = character.bestiary,
			cards = character.cards,
			cooking = character.cooking
		};
	}

	public void loadData(SaveData saveData)
	{
		character.ignoreOfflineProgress = false;
		if (saveData == null)
		{
			return;
		}
		BinaryFormatter formatter = new BinaryFormatter();
		string playerData = saveData.playerData;
		if (getMD5Hash(playerData) != saveData.checksum)
		{
			tooltip.showOverrideTooltip("Error loading save. Did you mess with the save file text or somethin'?", 2f);
			return;
		}
		PlayerData playerData2 = BinaryFormatterExtensions.DeserializePlayerDataFromString(formatter, saveData.playerData);
		if (playerData2.version > character.getVersion())
		{
			tooltip.showOverrideTooltip("You're trying to load a save from build " + playerData2.version + "into build " + character.getVersion() + ".This would create a time paradox so I can't allow that to happen. Sorry!", 2f);
			return;
		}
		if (playerData2.stats == null)
		{
			playerData2.achievements = new AchievementList();
		}
		playerData2.stats.validateStats();
		if (playerData2.achievements == null)
		{
			playerData2.achievements = new AchievementList();
		}
		playerData2.achievements.validate();
		playerData2.yggdrasil.checkYggdrasil();
		if (playerData2.bestiary == null)
		{
			playerData2.bestiary = new Bestiary();
		}
		if (playerData2.cards == null)
		{
			playerData2.cards = new Cards();
		}
		if (playerData2.cooking == null)
		{
			playerData2.cooking = new Cooking();
		}
		if (playerData2.version < 251)
		{
			playerData2.lastTime = Epoch.Current();
		}
		if (playerData2.version < 265)
		{
			playerData2.yggdrasil.statFruit.maxTier = 0L;
			playerData2.yggdrasil.adventureFruit.maxTier = 0L;
		}
		_ = playerData2.version;
		_ = 268;
		if (playerData2.version < 270)
		{
			playerData2.yggdrasil.pomegranate = new Fruit();
			playerData2.yggdrasil.pomegranate.maxTier = 0L;
		}
		if (playerData2.version < 275)
		{
			playerData2.challenges.hour24Challenge.bestTime = 0;
		}
		if (playerData2.version < 290)
		{
			playerData2.challenges.levelChallenge10k = new Challenge();
			playerData2.challenges.hour24Challenge.bestTime = 0;
			playerData2.challenges.noAugsChallenge.bestTime = int.MaxValue;
			playerData2.challenges.basicChallenge.bestTime = int.MaxValue;
			playerData2.challenges.levelChallenge10k.bestTime = int.MaxValue;
		}
		if (playerData2.version < 291)
		{
			playerData2.inventory.boostCombineState = default(UnityEngine.Random.State);
			UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
			playerData2.inventory.boostCombineState = UnityEngine.Random.state;
			playerData2.lastTime = Epoch.Current();
		}
		if (playerData2.version < 300)
		{
			playerData2.challenges.hour24Challenge.curCompletions = 0;
			playerData2.challenges.hour24Challenge.maxCompletions = 0;
			playerData2.perks.respec();
		}
		if (playerData2.version < 302 && playerData2.bossID > 3)
		{
			playerData2.settings.inventoryOn = true;
		}
		if (playerData2.version < 320)
		{
			playerData2.bloodMagic.adventureSpellTime = new PlayerTime();
			playerData2.bloodMagic.adventureSpellTime.reset();
			playerData2.bloodMagic.goldSpellBlood = 0.0;
			playerData2.bloodMagic.lootSpellBlood = 0.0;
			if (playerData2.bloodMagic.rebirthPower < 1.0)
			{
				playerData2.bloodMagic.rebirthPower = 1.0;
			}
		}
		if (playerData2.version < 339)
		{
			playerData2.settings.tutorialState = -1;
			playerData2.inventory.itemList.checkItemList();
		}
		if (playerData2.version < 345)
		{
			playerData2.settings.dailySaveRewardTime = new PlayerTime();
			playerData2.settings.dailySaveRewardTime.advanceTime(84600);
		}
		if (playerData2.version < 346)
		{
			playerData2.settings.submitHighscores = true;
			if (playerData2.settings.gotSpeedrunSecret)
			{
				playerData2.exp += 100;
				playerData2.stats.totalExp += 100L;
				playerData2.energyPower += 1f;
			}
			if (playerData2.inventory.itemList.forestComplete)
			{
				playerData2.arbitrary.energyPotion1Count++;
				playerData2.arbitrary.energyPotion2Count++;
				playerData2.arbitrary.energyBarBar1Count++;
			}
		}
		if (playerData2.version < 350)
		{
			playerData2.inventory.mergeTime = new PlayerTime();
			playerData2.inventory.mergeTime.reset();
			playerData2.settings.autoMergeOn = false;
			playerData2.purchases.hasAutoMerge = false;
		}
		if (playerData2.version < 351)
		{
			playerData2.purchases.hasAutoMerge = false;
			playerData2.purchases.hasFilter = true;
		}
		if (playerData2.version < 352)
		{
			playerData2.settings.timedTooltipsOn = true;
		}
		if (playerData2.version < 353)
		{
			playerData2.settings.inputAmount = 1000L;
		}
		if (playerData2.version < 354)
		{
			playerData2.realExp = playerData2.exp;
			playerData2.realGold = playerData2.gold;
			playerData2.arbitrary.curArbitraryPoints = playerData2.arbitrary.arbitraryPoints;
			playerData2.arbitrary.curLifetimePoints = playerData2.arbitrary.lifetimePoints;
		}
		if (playerData2.version < 356)
		{
			playerData2.challenges.noEquipmentChallenge = new Challenge();
			playerData2.adventure.boss3Spawn = new PlayerTime();
		}
		if (playerData2.version < 357)
		{
			if (playerData2.adventure.boss1Spawn.totalseconds > 3600.0)
			{
				playerData2.adventure.boss1Spawn.setTime(3600f);
			}
			if (playerData2.adventure.boss2Spawn.totalseconds > 3600.0)
			{
				playerData2.adventure.boss2Spawn.setTime(3600f);
			}
			if (playerData2.adventure.boss3Spawn.totalseconds > 7200.0)
			{
				playerData2.adventure.boss3Spawn.setTime(3600f);
			}
			playerData2.augments.resetLast5Augs();
		}
		if (playerData2.version < 359)
		{
			playerData2.settings.autoKillTitans = false;
		}
		if (playerData2.version < 361)
		{
			playerData2.inventory.boostTime = new PlayerTime();
		}
		if (playerData2.version < 365)
		{
			playerData2.arbitrary.curArbitraryPoints += 1750L;
			playerData2.arbitrary.curLifetimePoints += 1750L;
		}
		if (playerData2.version < 366)
		{
			if (playerData2.purchases.boostCombineLevel > 50)
			{
				playerData2.purchases.boostCombineLevel = 1;
			}
			int num = (int)(1.6666666f * ((float)playerData2.purchases.boostCombineLevel - 1f) * (float)playerData2.purchases.boostCombineLevel * (2f * (float)playerData2.purchases.boostCombineLevel - 1f));
			if (num < 0)
			{
				num = 0;
			}
			playerData2.realExp += num;
			playerData2.purchases.boostCombineLevel = 0;
			if (num > 0)
			{
				tooltip.showOverrideTooltip(num + " EXP has been refunded from the boost combine stuff.", 6f);
			}
		}
		if (playerData2.version < 367)
		{
			Equipment[] array = new Equipment[180];
			playerData2.inventory.items.CopyTo(array, 0);
			playerData2.inventory.items = array;
			for (int i = 0; i < playerData2.inventory.items.Length; i++)
			{
				if (playerData2.inventory.items[i] == null)
				{
					playerData2.inventory.items[i] = new Equipment();
				}
			}
			Equipment[] accessories = new Equipment[6];
			playerData2.inventory.accessories = accessories;
			for (int j = 0; j < playerData2.inventory.accessories.Length; j++)
			{
				if (playerData2.inventory.accessories[j] == null)
				{
					playerData2.inventory.accessories[j] = new Equipment();
				}
			}
			playerData2.inventory.accessories[0] = playerData2.inventory.acc1;
			playerData2.inventory.accessories[1] = playerData2.inventory.acc2;
			playerData2.inventory.accessories[2] = playerData2.inventory.acc3;
			playerData2.inventory.acc1 = new Equipment();
			playerData2.inventory.acc2 = new Equipment();
			playerData2.inventory.acc3 = new Equipment();
			playerData2.achievements = new AchievementList();
		}
		if (playerData2.version < 369)
		{
			int num2 = 0;
			int num3 = Mathf.Min(playerData2.challenges.basicChallenge.curCompletions, 25) * 500;
			num2 += num3;
			num3 = Mathf.Min(playerData2.challenges.noAugsChallenge.curCompletions, 20) * 5000;
			num2 += num3;
			num3 = Mathf.Min(playerData2.challenges.levelChallenge10k.curCompletions, 20) * 1500;
			num2 += num3;
			num3 = Mathf.Min(playerData2.challenges.noEquipmentChallenge.curCompletions, 20) * 3000;
			num2 += num3;
			num3 = Mathf.Min(playerData2.challenges.hour24Challenge.curCompletions, 80) * (Mathf.Min(playerData2.challenges.hour24Challenge.curCompletions, 80) + 1) * 200;
			if (num3 > 900000)
			{
				num3 = 900000;
			}
			num2 += num3;
			if (num2 < 0)
			{
				num2 = 0;
			}
			playerData2.arbitrary.curArbitraryPoints += num2;
			playerData2.arbitrary.lifetimePoints += num2;
		}
		if (playerData2.version < 372)
		{
			playerData2.challenges.noRebirthChallenge = new Challenge(highLow: false);
		}
		if (playerData2.version < 374)
		{
			playerData2.pit.tossCount = 0;
		}
		if (playerData2.version < 375)
		{
			playerData2.adventure.boss4Spawn = new PlayerTime();
			playerData2.adventure.boss4Defeated = false;
		}
		if (playerData2.version < 377)
		{
			playerData2.wandoos98.os = OSType.wandoos98;
		}
		if (playerData2.version < 378)
		{
			playerData2.daily = new DailyReward();
			playerData2.daily.dailyRewardState = UnityEngine.Random.state;
			playerData2.daily.spinTime.setTime(82800f);
			int num4 = (int)(playerData2.totalPlaytime.totalseconds / 86400.0 / 1.5);
			if (num4 < 0)
			{
				num4 = 0;
			}
			if (num4 > 120)
			{
				num4 = 120;
			}
			playerData2.daily.totalSpins = num4;
		}
		if (playerData2.version < 379)
		{
			playerData2.NGU.checkNGU();
		}
		if (playerData2.version < 380)
		{
			playerData2.inventory.loadouts = new List<Loadout>();
			while (playerData2.inventory.loadouts.Count < 10)
			{
				playerData2.inventory.loadouts.Add(new Loadout());
			}
			for (int k = 0; k < playerData2.inventory.loadouts.Count; k++)
			{
				playerData2.inventory.loadouts[k].loadoutName = "Loadout " + (k + 1);
			}
			int num5 = 0;
			int num6 = 0;
			num6 = Mathf.Min(playerData2.challenges.basicChallenge.curCompletions, 25) * 250;
			if (num6 < 0 || num6 > 6250)
			{
				num6 = 0;
			}
			num5 += num6;
			playerData2.realExp += num6;
			num6 = Mathf.Min(playerData2.challenges.noAugsChallenge.curCompletions, 20) * 800;
			if (num6 < 0 || num6 > 16000)
			{
				num6 = 0;
			}
			num5 += num6;
			playerData2.realExp += num6;
			num6 = Mathf.Min(playerData2.challenges.noEquipmentChallenge.curCompletions, 20) * 750;
			if (num6 < 0 || num6 > 15000)
			{
				num6 = 0;
			}
			num5 += num6;
			playerData2.realExp += num6;
			num6 = Mathf.Min(playerData2.challenges.levelChallenge10k.curCompletions, 20) * 400;
			if (num6 < 0 || num6 > 8000)
			{
				num6 = 0;
			}
			num5 += num6;
			playerData2.realExp += num6;
			tooltip.showOverrideTooltip(num5 + " EXP has been added for the challenge buffs.");
			playerData2.settings.shakeySales = true;
		}
		if (playerData2.version < 382)
		{
			playerData2.beards = new Beards();
			playerData2.settings.beardsOn = false;
			playerData2.arbitrary.energyPotion3Count = 0;
			playerData2.arbitrary.magicPotion3Count = 0;
		}
		if (playerData2.version < 383)
		{
			playerData2.inventory.cubePower = 0f;
			playerData2.inventory.cubeToughness = 0f;
			playerData2.arbitrary.hasCubeFilter = false;
		}
		if (playerData2.version < 384)
		{
			playerData2.settings.checkForUpdates = true;
		}
		if (playerData2.version < 385)
		{
			playerData2.settings.fancyYggBars = true;
			playerData2.advancedTraining.levelTarget = new long[10];
			playerData2.advancedTraining.level = new long[10];
			for (int l = 0; l < 10; l++)
			{
				playerData2.advancedTraining.level[l] = playerData2.advancedTraining.training[l];
			}
		}
		if (playerData2.version < 388)
		{
			playerData2.challenges.trollChallenge = new Challenge(highLow: true);
			playerData2.inventory.inventory = new List<Equipment>();
			int num7 = playerData2.inventory.spaces + playerData2.arbitrary.inventorySpaces + Math.Min(playerData2.challenges.noEquipmentChallenge.curCompletions * 2, 40);
			if (playerData2.challenges.noEquipmentChallenge.curCompletions >= 20)
			{
				num7 += 10;
			}
			for (int m = 0; m < num7; m++)
			{
				playerData2.inventory.inventory.Add(playerData2.inventory.items[m]);
			}
			num7 = 2;
			if (playerData2.purchases.hasAcc3)
			{
				num7++;
			}
			if (playerData2.arbitrary.hasAcc4)
			{
				num7++;
			}
			if (playerData2.purchases.hasAcc5)
			{
				num7++;
			}
			playerData2.inventory.accs = new List<Equipment>();
			for (int n = 0; n < num7; n++)
			{
				playerData2.inventory.accs.Add(playerData2.inventory.accessories[n]);
			}
			playerData2.inventory.items = new Equipment[1];
			playerData2.inventory.items[0] = new Equipment();
			playerData2.inventory.accessories = new Equipment[1];
			playerData2.inventory.accessories[0] = new Equipment();
			playerData2.bloodMagic.ritual = new List<Ritual>();
			for (int num8 = 0; num8 < playerData2.bloodMagic.rituals.Length; num8++)
			{
				playerData2.bloodMagic.ritual.Add(playerData2.bloodMagic.rituals[num8]);
			}
			playerData2.bloodMagic.rituals = new Ritual[1];
			playerData2.bloodMagic.rituals[0] = new Ritual();
			playerData2.bloodMagic.ritual.Add(new Ritual());
		}
		if (playerData2.version < 389)
		{
			playerData2.adventure.boss5Defeated = false;
			playerData2.adventure.boss5Spawn = new PlayerTime();
			playerData2.adventure.waldoDefeats = 0;
			playerData2.adventure.waldoFinds = 0;
			playerData2.adventure.boss5Spawn.reset();
			playerData2.adventure.boss5Kills = 0;
			playerData2.arbitrary.lootCharm2Count = 0;
		}
		if (playerData2.version < 390)
		{
			playerData2.challenges.laserSwordChallenge = new Challenge();
			playerData2.inventory.daycare = new List<Equipment>();
			playerData2.inventory.daycareTimers = new List<PlayerTime>();
		}
		if (playerData2.version < 391)
		{
			playerData2.challenges.blindChallenge = new Challenge();
			if (playerData2.wandoos98.OSlevel > 100)
			{
				playerData2.wandoos98.pitOSLevels = playerData2.wandoos98.OSlevel - 100;
				playerData2.wandoos98.OSlevel -= playerData2.wandoos98.OSlevel - 100;
			}
			playerData2.challenges.blindChallengeUnlocked = false;
			playerData2.arbitrary.hasDaycareSpeed = false;
		}
		if (playerData2.version < 393)
		{
			playerData2.settings.simpleInvShortcuts = false;
			playerData2.settings.poopOnlyMaxTier = false;
		}
		if (playerData2.version < 394)
		{
			playerData2.inventory.selectedGraphic = 0;
		}
		if (playerData2.version < 395)
		{
			playerData2.adventure.itopodStart = 0;
			playerData2.adventure.itopodEnd = 20;
			playerData2.adventure.highestItopodLevel = 0;
			playerData2.adventure.itopod = new ITOPOD();
		}
		if (playerData2.version < 396)
		{
			playerData2.settings.itopodConfirmation = true;
		}
		if (playerData2.version < 398)
		{
			playerData2.training.evilAttackCaps = new int[6] { 250000, 1500000, 3000000, 5000000, 7000000, 10000000 };
			playerData2.training.evilDefenseCaps = new int[6] { 250000, 1500000, 3000000, 5000000, 7000000, 10000000 };
			long num9 = playerData2.adventure.itopod.perkLevel[12];
			if (num9 > 0)
			{
				playerData2.adventure.itopod.perkPoints += num9 * 2;
				playerData2.adventure.itopod.perkLevel[12] = 0L;
				tooltip.showOverrideTooltip(num9 * 2 + " PP has been refunded to you.");
			}
		}
		if (playerData2.version < 399)
		{
			playerData2.adventure.titan1Kills = 0;
			playerData2.adventure.titan2Kills = 0;
			playerData2.adventure.titan3Kills = 0;
			playerData2.adventure.titan4Kills = 0;
			playerData2.adventure.titan5Kills = 0;
			playerData2.settings.customAttackInput = 100L;
			playerData2.settings.customDefenseInput = 100L;
			playerData2.settings.customCapAmount = 10000L;
			playerData2.settings.customBarAmount = 1;
			playerData2.settings.customPowerAmount = 1;
			playerData2.settings.customMagicCapAmount = 10000L;
			playerData2.settings.customMagicBarAmount = 1;
			playerData2.settings.customMagicPowerAmount = 1;
		}
		if (playerData2.version < 401)
		{
			playerData2.adventure.boss6Spawn = new PlayerTime();
			playerData2.adventure.titan6Kills = 0;
			playerData2.adventure.titan6V1Kills = 0;
			playerData2.adventure.titan6V2Kills = 0;
			playerData2.adventure.titan6V3Kills = 0;
			playerData2.adventure.titan6V4Kills = 0;
			playerData2.adventure.clue1Complete = false;
			playerData2.adventure.clue2Complete = false;
			playerData2.adventure.clue3Complete = false;
			playerData2.adventure.clue4Complete = false;
			playerData2.adventure.titan6Unlocked = false;
			playerData2.arbitrary.boughtLazyITOPOD = false;
			playerData2.arbitrary.lazyITOPODOn = true;
		}
		if (playerData2.version < 402)
		{
			playerData2.NGU.checkNGU();
			playerData2.advancedTraining.bankedLevel = new long[10];
			for (int num10 = 0; num10 < playerData2.advancedTraining.level.Length; num10++)
			{
				playerData2.advancedTraining.bankedLevel[num10] = 0L;
			}
			playerData2.advancedTraining.transferredBankedLevels = true;
			playerData2.machine.goldMultiBankLevels = 0L;
			playerData2.machine.speedBankLevels = 0L;
			playerData2.machine.transferredBankLevels = true;
			for (int num11 = 0; num11 < playerData2.beards.beards.Count; num11++)
			{
				playerData2.beards.beards[num11].bankedLevel = 0L;
			}
			playerData2.beards.transferredBankedLevels = true;
			for (int num12 = 0; num12 < playerData2.yggdrasil.fruits.Count; num12++)
			{
				playerData2.yggdrasil.fruits[num12].harvests = 0;
			}
		}
		if (playerData2.version < 403)
		{
			playerData2.energyBars = playerData2.energyPerBar;
			playerData2.purchases.hasDiggerSlot1 = false;
			playerData2.purchases.hasDiggerSlot2 = false;
			playerData2.arbitrary.diggerSlots = 0;
		}
		if (playerData2.version < 404)
		{
			playerData2.challenges.nguChallenge = new Challenge();
			playerData2.challenges.timeMachineChallenge = new Challenge();
		}
		if (playerData2.version < 406)
		{
			playerData2.settings.nguLevelTrack = difficulty.normal;
			playerData2.settings.rebirthDifficulty = difficulty.normal;
			for (int num13 = 0; num13 < playerData2.NGU.skills.Count; num13++)
			{
				playerData2.NGU.skills[num13].evilLevel = 0L;
				playerData2.NGU.skills[num13].evilProgress = 0f;
				playerData2.NGU.skills[num13].sadisticLevel = 0L;
				playerData2.NGU.skills[num13].sadisticProgress = 0f;
			}
			for (int num14 = 0; num14 < playerData2.NGU.magicSkills.Count; num14++)
			{
				playerData2.NGU.magicSkills[num14].evilLevel = 0L;
				playerData2.NGU.magicSkills[num14].evilProgress = 0f;
				playerData2.NGU.magicSkills[num14].evilTarget = 0L;
				playerData2.NGU.magicSkills[num14].sadisticLevel = 0L;
				playerData2.NGU.magicSkills[num14].sadisticProgress = 0f;
				playerData2.NGU.magicSkills[num14].sadisticTarget = 0L;
				playerData2.nextRebirthDifficulty = difficulty.normal;
			}
			playerData2.inventory.macguffins = new List<Equipment>();
			playerData2.inventory.macguffinBonuses = new List<float>();
			while (playerData2.inventory.macguffinBonuses.Count < 24)
			{
				playerData2.inventory.macguffinBonuses.Add(1f);
			}
		}
		if (playerData2.version < 407)
		{
			playerData2.settings.nguLevelTrack = difficulty.normal;
			playerData2.settings.rebirthDifficulty = difficulty.normal;
			for (int num15 = 0; num15 < playerData2.NGU.skills.Count; num15++)
			{
				playerData2.NGU.skills[num15].evilLevel = 0L;
				playerData2.NGU.skills[num15].evilProgress = 0f;
				playerData2.NGU.skills[num15].sadisticLevel = 0L;
				playerData2.NGU.skills[num15].sadisticProgress = 0f;
			}
			for (int num16 = 0; num16 < playerData2.NGU.magicSkills.Count; num16++)
			{
				playerData2.NGU.magicSkills[num16].evilLevel = 0L;
				playerData2.NGU.magicSkills[num16].evilProgress = 0f;
				playerData2.NGU.magicSkills[num16].evilTarget = 0L;
				playerData2.NGU.magicSkills[num16].sadisticLevel = 0L;
				playerData2.NGU.magicSkills[num16].sadisticProgress = 0f;
				playerData2.NGU.magicSkills[num16].sadisticTarget = 0L;
				playerData2.nextRebirthDifficulty = difficulty.normal;
			}
			playerData2.inventory.macguffins = new List<Equipment>();
			playerData2.inventory.macguffinBonuses = new List<float>();
			while (playerData2.inventory.macguffinBonuses.Count < 24)
			{
				playerData2.inventory.macguffinBonuses.Add(1f);
			}
			playerData2.challenges.basicChallenge.initializeEvilStuff();
			playerData2.challenges.noAugsChallenge.initializeEvilStuff();
			playerData2.challenges.noEquipmentChallenge.initializeEvilStuff();
			playerData2.challenges.hour24Challenge.initializeEvilStuff();
			playerData2.challenges.levelChallenge10k.initializeEvilStuff();
			playerData2.challenges.noRebirthChallenge.initializeEvilStuff();
			playerData2.challenges.timeMachineChallenge.initializeEvilStuff();
			playerData2.challenges.nguChallenge.initializeEvilStuff();
			playerData2.challenges.laserSwordChallenge.initializeEvilStuff();
			playerData2.challenges.trollChallenge.initializeEvilStuff();
			playerData2.challenges.blindChallenge.initializeEvilStuff();
			playerData2.arbitrary.macGuffinBooster1Count = 0;
			playerData2.arbitrary.macGuffinBooster1Time = new PlayerTime();
			playerData2.arbitrary.macGuffinBooster1InUse = false;
			playerData2.purchases.choseKitty = false;
			playerData2.purchases.hasSpecialPrize1 = false;
			playerData2.inventory.itemList.edgyComplete = false;
			playerData2.inventory.itemList.edgyBootsComplete = false;
		}
		if (playerData2.version < 408)
		{
			playerData2.inventory.itemList.chocoComplete = false;
			playerData2.inventory.macguffinBonuses[13] = 1f;
		}
		if (playerData2.version < 409)
		{
			playerData2.bloodMagic.macguffin1Time = new PlayerTime();
			playerData2.bloodMagic.macguffin2Time = new PlayerTime();
			playerData2.settings.themeID = 0;
			playerData2.arbitrary.boughtAscendedNewbiePack = false;
		}
		if (playerData2.version < 410)
		{
			if (playerData2.inventory.itemList == null)
			{
				playerData2.inventory.itemList = new ItemList();
			}
			playerData2.adventure.itopod.updateItopod();
			playerData2.adventure.titan7Kills = 0;
			playerData2.adventure.titan7questComplete = false;
			playerData2.adventure.titan7questStarted = false;
			playerData2.adventure.titan7QuestSequence = 0;
			playerData2.adventure.titan7V1Kills = 0;
			playerData2.adventure.titan7V2Kills = 0;
			playerData2.adventure.titan7V3Kills = 0;
			playerData2.adventure.titan7V4Kills = 0;
			playerData2.adventure.boss7Defeated = false;
			playerData2.adventure.boss7Spawn = new PlayerTime();
			long num17 = 0L;
			long num18 = playerData2.adventure.itopod.perkLevel[5] - 1000;
			if (num18 > 0)
			{
				playerData2.adventure.itopod.perkPoints += num18;
				num17 += num18;
				playerData2.adventure.itopod.perkLevel[5] = 1000L;
			}
			long num19 = playerData2.adventure.itopod.perkLevel[54] - 1000;
			if (num19 > 0)
			{
				playerData2.adventure.itopod.perkPoints += num19 * 100;
				num17 += num19;
				playerData2.adventure.itopod.perkLevel[54] = 1000L;
			}
			long num20 = playerData2.adventure.itopod.perkLevel[55] - 1000;
			if (num20 > 0)
			{
				playerData2.adventure.itopod.perkPoints += num20 * 100;
				num17 += num20;
				playerData2.adventure.itopod.perkLevel[55] = 1000L;
			}
			if (num17 > 0)
			{
				tooltip.showOverrideTooltip(num17 + "PP was refunded to you, due to changes to perks in build .410.", 5f);
			}
			playerData2.inventory.itemList.prettyComplete = false;
			playerData2.inventory.itemList.nerdComplete = false;
		}
		if (playerData2.version < 411)
		{
			playerData2.inventory.unlockedKittyArt = new List<bool>();
			playerData2.inventory.kittyArt = 0;
			playerData2.settings.customPowerInput = 10000L;
			playerData2.settings.customToughnessInput = 10000L;
			playerData2.settings.customHPInput = 100000L;
			playerData2.settings.customRegenInput = 10000L;
			playerData2.purchases.holidayspins = 0;
		}
		if (playerData2.version < 412)
		{
			if (playerData2.inventory.spaces < 24)
			{
				playerData2.inventory.spaces = 24;
			}
			playerData2.settings.pitUnlocked = true;
			playerData2.arbitrary.nameSlotsBought = 0;
		}
		if (playerData2.version < 413)
		{
			playerData2.adventure.boss8Spawn = new PlayerTime();
			playerData2.adventure.boss8Defeated = false;
			playerData2.adventure.titan8questStarted = false;
			playerData2.adventure.titan8QuestSequence = 0;
			playerData2.adventure.titan8questComplete = false;
			playerData2.adventure.titan8Kills = 0;
			playerData2.adventure.titan8Unlocked = false;
			playerData2.adventure.titan8Version = 0;
			playerData2.adventure.boss8Kills = 0;
			playerData2.adventure.titan8V1Kills = 0;
			playerData2.adventure.titan8V2Kills = 0;
			playerData2.adventure.titan8V3Kills = 0;
			playerData2.adventure.titan8V4Kills = 0;
			playerData2.adventure.skeletonWhacked = false;
			playerData2.adventure.icarusWhacked = false;
			playerData2.adventure.emptyNameWhacked = false;
			playerData2.adventure.robBossWhacked = false;
			playerData2.adventure.kingCircleWhacked = false;
			playerData2.beastQuest = new BeastQuest();
			UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
			playerData2.beastQuest.questState = UnityEngine.Random.state;
			playerData2.beastQuest.questsUnlocked = false;
			playerData2.beastQuest.maxBankedQuests = 10;
			playerData2.beastQuest.curBankedQuests = 3;
			playerData2.beastQuest.inQuest = false;
			playerData2.beastQuest.idleProgress = 0f;
			playerData2.beastQuest.allActive = true;
			playerData2.arbitrary.hasQuestLight = false;
			playerData2.arbitrary.hasFasterQuests = false;
			playerData2.arbitrary.hasExtendedQuestBank = false;
			playerData2.arbitrary.hasAcc6 = false;
			playerData2.daily.freeSpins = 0L;
			playerData2.daily.freeSpins += 7L;
			playerData2.yggdrasil.totalPermStatBonus2 = 0L;
			playerData2.purchases.hasMacguffinSlot2 = false;
			playerData2.arbitrary.nukeTimer = new PlayerTime();
			playerData2.arbitrary.boughtDaycareArt = false;
		}
		if (playerData2.version < 414)
		{
			playerData2.settings.useMajorQuests = true;
		}
		if (playerData2.version < 415)
		{
			playerData2.settings.nguCapModifier = 1f;
			playerData2.arbitrary.hasNGUCapModifier = false;
		}
		if (playerData2.version < 416)
		{
			playerData2.res3 = new Resource3();
			playerData2.hacks = new Hacks();
			playerData2.settings.customRes3BarAmount = 1;
			playerData2.settings.customRes3CapAmount = 10000L;
			playerData2.settings.customRes3PowerAmount = 1;
			playerData2.settings.customIdleRes3Percent1 = 1f;
			playerData2.settings.customIdleRes3Percent2 = 1f;
			playerData2.settings.customRes3Percent1 = 1f;
			playerData2.settings.customRes3Percent2 = 1f;
			playerData2.settings.idleQuestAutocycle = true;
			playerData2.arbitrary.res3Potion1Count = 0;
			playerData2.arbitrary.res3Potion1Time = new PlayerTime();
			playerData2.arbitrary.res3Potion2Count = 0;
			playerData2.arbitrary.res3Potion2InUse = false;
			playerData2.arbitrary.res3Potion3Count = 0;
			playerData2.arbitrary.hasAcc7 = false;
			playerData2.inventory.itemList.evidenceComplete = false;
			playerData2.inventory.itemList.greyHeartComplete = false;
			playerData2.arbitrary.boughtRes3Pack = false;
			playerData2.inventory.macguffinBonuses[20] = 1f;
			playerData2.inventory.macguffinBonuses[21] = 1f;
			playerData2.inventory.macguffinBonuses[22] = 1f;
		}
		_ = playerData2.version;
		_ = 420;
		_ = playerData2.version;
		_ = 421;
		if (playerData2.version < 422)
		{
			playerData2.adventure.boss9Spawn = new PlayerTime();
			playerData2.adventure.boss9Defeated = false;
			playerData2.adventure.titan9questStarted = false;
			playerData2.adventure.titan9questComplete = false;
			playerData2.adventure.titan9Kills = 0;
			playerData2.adventure.titan9Unlocked = false;
			playerData2.adventure.titan9Version = 0;
			playerData2.adventure.boss9Kills = 0;
			playerData2.adventure.titan9V1Kills = 0;
			playerData2.adventure.titan9V2Kills = 0;
			playerData2.adventure.titan9V3Kills = 0;
			playerData2.adventure.titan9V4Kills = 0;
			playerData2.beastQuest.questState = UnityEngine.Random.state;
			if (playerData2.beastQuest.quirkLevel[13] >= 1 && playerData2.beastQuest.quirkLevel[13] <= 3)
			{
				playerData2.beastQuest.quirkPoints += playerData2.beastQuest.quirkLevel[13] * 2000;
			}
			playerData2.arbitrary.res3NameGeneratorBought = false;
			playerData2.arbitrary.boughtAscendedNewbiePack3 = false;
			playerData2.settings.res3NameGeneratorOn = false;
			playerData2.settings.claimedKartPromo = false;
			playerData2.settings.assholeSetting = true;
			playerData2.arbitrary.wishSpeedBoster = false;
			if (playerData2.res3.res3BarSpeed >= 49.91f && playerData2.res3.res3BarSpeed < 50f)
			{
				playerData2.res3.res3BarSpeed = 50f;
			}
		}
		if (playerData2.version < 423)
		{
			playerData2.settings.badge1Complete = false;
			playerData2.settings.badge2Part1Complete = false;
			playerData2.settings.badge2Part2Complete = false;
			playerData2.settings.badge2Part3Complete = false;
			playerData2.settings.badge2Part4Complete = false;
			playerData2.settings.badge2Started = false;
		}
		if (playerData2.version < 425)
		{
			if (playerData2.portraits == null)
			{
				playerData2.portraits = new PlayerPortraits();
			}
			playerData2.portraits.updatePortraits();
			if (playerData2.inventory.itemList.trainingComplete)
			{
				playerData2.portraits.portraitUnlocked[11] = true;
			}
			if (playerData2.inventory.itemList.sewersComplete)
			{
				playerData2.portraits.portraitUnlocked[12] = true;
			}
			if (playerData2.inventory.itemList.forestComplete)
			{
				playerData2.portraits.portraitUnlocked[13] = true;
			}
			if (playerData2.inventory.itemList.forestComplete)
			{
				playerData2.portraits.portraitUnlocked[14] = true;
			}
			if (playerData2.inventory.itemList.forestComplete)
			{
				playerData2.portraits.portraitUnlocked[15] = true;
			}
			if (playerData2.inventory.itemList.caveComplete)
			{
				playerData2.portraits.portraitUnlocked[16] = true;
			}
			if (playerData2.inventory.itemList.HSBComplete)
			{
				playerData2.portraits.portraitUnlocked[17] = true;
			}
			if (playerData2.inventory.itemList.GRBComplete)
			{
				playerData2.portraits.portraitUnlocked[18] = true;
			}
			if (playerData2.inventory.itemList.clockComplete)
			{
				playerData2.portraits.portraitUnlocked[19] = true;
			}
			if (playerData2.inventory.itemList.twoDComplete)
			{
				playerData2.portraits.portraitUnlocked[20] = true;
			}
			if (playerData2.inventory.itemList.ghostComplete)
			{
				playerData2.portraits.portraitUnlocked[21] = true;
			}
			if (playerData2.inventory.itemList.jakeComplete)
			{
				playerData2.portraits.portraitUnlocked[22] = true;
			}
			if (playerData2.inventory.itemList.gaudyComplete)
			{
				playerData2.portraits.portraitUnlocked[23] = true;
			}
			if (playerData2.inventory.itemList.megaComplete)
			{
				playerData2.portraits.portraitUnlocked[24] = true;
			}
			if (playerData2.inventory.itemList.beardverseComplete)
			{
				playerData2.portraits.portraitUnlocked[25] = true;
			}
			if (playerData2.inventory.itemList.waldoComplete)
			{
				playerData2.portraits.portraitUnlocked[26] = true;
			}
			if (playerData2.inventory.itemList.antiWaldoComplete)
			{
				playerData2.portraits.portraitUnlocked[27] = true;
			}
			if (playerData2.inventory.itemList.badlyDrawnComplete)
			{
				playerData2.portraits.portraitUnlocked[28] = true;
			}
			if (playerData2.inventory.itemList.stealthComplete)
			{
				playerData2.portraits.portraitUnlocked[29] = true;
			}
			if (playerData2.inventory.itemList.beast1complete)
			{
				playerData2.portraits.portraitUnlocked[30] = true;
			}
			if (playerData2.inventory.itemList.chocoComplete)
			{
				playerData2.portraits.portraitUnlocked[31] = true;
			}
			if (playerData2.inventory.itemList.edgyComplete)
			{
				playerData2.portraits.portraitUnlocked[32] = true;
			}
			if (playerData2.inventory.itemList.prettyComplete)
			{
				playerData2.portraits.portraitUnlocked[33] = true;
			}
			if (playerData2.inventory.itemList.nerdComplete)
			{
				playerData2.portraits.portraitUnlocked[34] = true;
			}
			if (playerData2.inventory.itemList.metaComplete)
			{
				playerData2.portraits.portraitUnlocked[35] = true;
			}
			if (playerData2.inventory.itemList.partyComplete)
			{
				playerData2.portraits.portraitUnlocked[36] = true;
			}
			if (playerData2.inventory.itemList.godmotherComplete)
			{
				playerData2.portraits.portraitUnlocked[37] = true;
			}
			if (playerData2.inventory.itemList.typoComplete)
			{
				playerData2.portraits.portraitUnlocked[38] = true;
			}
			if (playerData2.inventory.itemList.fadComplete)
			{
				playerData2.portraits.portraitUnlocked[39] = true;
			}
			if (playerData2.inventory.itemList.jrpgComplete)
			{
				playerData2.portraits.portraitUnlocked[40] = true;
			}
			if (playerData2.inventory.itemList.exileComplete)
			{
				playerData2.portraits.portraitUnlocked[41] = true;
			}
			playerData2.inventory.weapon2 = new Equipment();
			for (int num21 = 0; num21 < playerData2.inventory.loadouts.Count; num21++)
			{
				playerData2.inventory.loadouts[num21].weapon2 = -1000;
			}
			playerData2.purchases.hasInvMerge = false;
			playerData2.arbitrary.boughtFashionPack1 = false;
			playerData2.inventory.itemList.pinkHeartComplete = false;
			playerData2.settings.invAutoBoostOn = true;
			playerData2.settings.invAutoMergeOn = true;
		}
		if (playerData2.version < 427)
		{
			if (playerData2.diggers == null)
			{
				playerData2.diggers = new GoldDiggers();
			}
			playerData2.diggers.loadoutDiggers = new List<int>();
		}
		if (playerData2.version < 1000)
		{
			playerData2.settings.exilev4Defeated = false;
			playerData2.adventure.boss10Spawn = new PlayerTime();
			playerData2.adventure.titan10questStarted = false;
			playerData2.adventure.titan10Unlocked = true;
			playerData2.adventure.titan10Kills = 0;
			playerData2.adventure.titan10Version = 0;
			playerData2.adventure.boss10Kills = 0;
			playerData2.adventure.titan10V1Kills = 0;
			playerData2.adventure.titan10V2Kills = 0;
			playerData2.adventure.titan10V3Kills = 0;
			playerData2.adventure.titan10V4Kills = 0;
			playerData2.machine.realBaseGold = playerData2.machine.baseGold;
			if (playerData2.settings.themeID == 4)
			{
				playerData2.settings.themeID = 0;
			}
			playerData2.arbitrary.advLightBought = false;
			playerData2.settings.claimedSteamPromo = false;
			if (playerData2.settings.rebirthDifficulty == difficulty.evil && playerData2.bossID >= 300)
			{
				playerData2.highestHardBoss = 300;
			}
			playerData2.arbitrary.hasAcc8 = false;
		}
		if (playerData2.version < 1001)
		{
			playerData2.adventure.itopod.filterDiff = false;
			playerData2.adventure.itopod.filterAfford = false;
			playerData2.adventure.itopod.filterMaxxed = false;
			playerData2.adventure.itopod.orderType = orderPerks.Default;
			if (playerData2.beastQuest == null)
			{
				playerData2.beastQuest = new BeastQuest();
			}
			playerData2.beastQuest.filterDiff = false;
			playerData2.beastQuest.filterAfford = false;
			playerData2.beastQuest.filterMaxxed = false;
			playerData2.beastQuest.orderType = orderQuirks.Default;
			if (playerData2.wishes == null)
			{
				playerData2.wishes = new Wishes();
			}
			playerData2.wishes.filterDiff = false;
			playerData2.wishes.filterAfford = false;
			playerData2.wishes.filterMaxxed = false;
			playerData2.wishes.orderType = orderWish.Default;
		}
		if (playerData2.version < 1002)
		{
			if (playerData2.purchases.choseKitty)
			{
				playerData2.arbitrary.curArbitraryPoints += 50000L;
			}
			if (playerData2.bestiary == null)
			{
				playerData2.bestiary = new Bestiary();
			}
			if (playerData2.adventure.boss5Kills > 0)
			{
				playerData2.bestiary.enemies[306].kills = 1;
				playerData2.bestiary.enemies[307].kills = 1;
				playerData2.bestiary.enemies[308].kills = 1;
				playerData2.bestiary.enemies[309].kills = 1;
			}
			if (playerData2.adventure.boss6Kills > 0)
			{
				playerData2.bestiary.enemies[311].kills = 1;
			}
			if (playerData2.adventure.boss7Kills > 0)
			{
				playerData2.bestiary.enemies[333].kills = 1;
			}
			if (playerData2.adventure.boss8Kills > 0)
			{
				playerData2.bestiary.enemies[338].kills = 1;
			}
			if (playerData2.adventure.boss9Kills > 0)
			{
				playerData2.bestiary.enemies[343].kills = 1;
			}
			if (playerData2.adventure.boss10Kills > 0)
			{
				playerData2.bestiary.enemies[364].kills = 1;
			}
		}
		if (playerData2.version < 1003)
		{
			if (playerData2.wishes == null)
			{
				playerData2.wishes = new Wishes();
			}
			if (playerData2.wishes.wishes[4].level > 0 && character.wandoos98.pitOSLevels < 100)
			{
				character.wandoos98.pitOSLevels = 100L;
			}
			playerData2.settings.prizePicked = 0;
			int num22 = 0;
			num22 = playerData2.challenges.basicChallenge.curCompletions;
			playerData2.challenges.basicChallenge.curCompletions /= 5;
			if (playerData2.challenges.basicChallenge.curCompletions == 0 && num22 > 0)
			{
				playerData2.challenges.basicChallenge.curCompletions = 1;
			}
			num22 = playerData2.challenges.basicChallenge.curEvilCompletions;
			playerData2.challenges.basicChallenge.curEvilCompletions /= 5;
			if (playerData2.challenges.basicChallenge.curEvilCompletions == 0 && num22 > 0)
			{
				playerData2.challenges.basicChallenge.curEvilCompletions = 1;
			}
			num22 = playerData2.challenges.basicChallenge.curSadisticCompletions;
			playerData2.challenges.basicChallenge.curSadisticCompletions /= 5;
			if (playerData2.challenges.basicChallenge.curSadisticCompletions == 0 && num22 > 0)
			{
				playerData2.challenges.basicChallenge.curSadisticCompletions = 1;
			}
			num22 = playerData2.challenges.hour24Challenge.curCompletions;
			playerData2.challenges.hour24Challenge.curCompletions /= 8;
			if (playerData2.challenges.hour24Challenge.curCompletions == 0 && num22 > 0)
			{
				playerData2.challenges.hour24Challenge.curCompletions = 1;
			}
			num22 = playerData2.challenges.hour24Challenge.curEvilCompletions;
			playerData2.challenges.hour24Challenge.curEvilCompletions /= 8;
			if (playerData2.challenges.hour24Challenge.curEvilCompletions == 0 && num22 > 0)
			{
				playerData2.challenges.hour24Challenge.curEvilCompletions = 1;
			}
			num22 = playerData2.challenges.hour24Challenge.curSadisticCompletions;
			playerData2.challenges.hour24Challenge.curSadisticCompletions /= 8;
			if (playerData2.challenges.hour24Challenge.curSadisticCompletions == 0 && num22 > 0)
			{
				playerData2.challenges.hour24Challenge.curSadisticCompletions = 1;
			}
			num22 = playerData2.challenges.levelChallenge10k.curCompletions;
			playerData2.challenges.levelChallenge10k.curCompletions /= 4;
			if (playerData2.challenges.levelChallenge10k.curCompletions == 0 && num22 > 0)
			{
				playerData2.challenges.levelChallenge10k.curCompletions = 1;
			}
			num22 = playerData2.challenges.levelChallenge10k.curEvilCompletions;
			playerData2.challenges.levelChallenge10k.curEvilCompletions /= 4;
			if (playerData2.challenges.levelChallenge10k.curEvilCompletions == 0 && num22 > 0)
			{
				playerData2.challenges.levelChallenge10k.curEvilCompletions = 1;
			}
			num22 = playerData2.challenges.levelChallenge10k.curSadisticCompletions;
			playerData2.challenges.levelChallenge10k.curSadisticCompletions /= 4;
			if (playerData2.challenges.levelChallenge10k.curSadisticCompletions == 0 && num22 > 0)
			{
				playerData2.challenges.levelChallenge10k.curSadisticCompletions = 1;
			}
			num22 = playerData2.challenges.noEquipmentChallenge.curCompletions;
			playerData2.challenges.noEquipmentChallenge.curCompletions = (playerData2.challenges.noEquipmentChallenge.curCompletions + 3) / 4;
			if (num22 == 0)
			{
				playerData2.challenges.noEquipmentChallenge.curCompletions = 0;
			}
			if (playerData2.challenges.noEquipmentChallenge.curCompletions > 5)
			{
				playerData2.challenges.noEquipmentChallenge.curCompletions = 5;
			}
			num22 = playerData2.challenges.noEquipmentChallenge.curEvilCompletions;
			playerData2.challenges.noEquipmentChallenge.curEvilCompletions = (playerData2.challenges.noEquipmentChallenge.curEvilCompletions + 3) / 4;
			if (num22 == 0)
			{
				playerData2.challenges.noEquipmentChallenge.curEvilCompletions = 0;
			}
			if (playerData2.challenges.noEquipmentChallenge.curEvilCompletions > 5)
			{
				playerData2.challenges.noEquipmentChallenge.curEvilCompletions = 5;
			}
			num22 = playerData2.challenges.noEquipmentChallenge.curSadisticCompletions;
			playerData2.challenges.noEquipmentChallenge.curSadisticCompletions = (playerData2.challenges.noEquipmentChallenge.curSadisticCompletions + 3) / 4;
			if (num22 == 0)
			{
				playerData2.challenges.noEquipmentChallenge.curSadisticCompletions = 0;
			}
			if (playerData2.challenges.noEquipmentChallenge.curSadisticCompletions > 5)
			{
				playerData2.challenges.noEquipmentChallenge.curSadisticCompletions = 5;
			}
			num22 = playerData2.challenges.noRebirthChallenge.curCompletions;
			playerData2.challenges.noRebirthChallenge.curCompletions /= 5;
			if (playerData2.challenges.noRebirthChallenge.curCompletions == 0 && num22 > 0)
			{
				playerData2.challenges.noRebirthChallenge.curCompletions = 1;
			}
			num22 = playerData2.challenges.noRebirthChallenge.curEvilCompletions;
			playerData2.challenges.noRebirthChallenge.curEvilCompletions /= 5;
			if (playerData2.challenges.noRebirthChallenge.curEvilCompletions == 0 && num22 > 0)
			{
				playerData2.challenges.noRebirthChallenge.curEvilCompletions = 1;
			}
			num22 = playerData2.challenges.noRebirthChallenge.curSadisticCompletions;
			playerData2.challenges.noRebirthChallenge.curSadisticCompletions /= 5;
			if (playerData2.challenges.noRebirthChallenge.curSadisticCompletions == 0 && num22 > 0)
			{
				playerData2.challenges.noRebirthChallenge.curSadisticCompletions = 1;
			}
			num22 = playerData2.challenges.noAugsChallenge.curCompletions;
			playerData2.challenges.noAugsChallenge.curCompletions /= 5;
			if (playerData2.challenges.noAugsChallenge.curCompletions == 0 && num22 > 0)
			{
				playerData2.challenges.noAugsChallenge.curCompletions = 1;
			}
			num22 = playerData2.challenges.noAugsChallenge.curEvilCompletions;
			playerData2.challenges.noAugsChallenge.curEvilCompletions /= 5;
			if (playerData2.challenges.noAugsChallenge.curEvilCompletions == 0 && num22 > 0)
			{
				playerData2.challenges.noAugsChallenge.curEvilCompletions = 1;
			}
			num22 = playerData2.challenges.noAugsChallenge.curSadisticCompletions;
			playerData2.challenges.noAugsChallenge.curSadisticCompletions /= 5;
			if (playerData2.challenges.noAugsChallenge.curSadisticCompletions == 0 && num22 > 0)
			{
				playerData2.challenges.noAugsChallenge.curSadisticCompletions = 1;
			}
		}
		if (playerData2.version < 1100)
		{
			playerData2.yggdrasil.checkYggdrasil();
			playerData2.arbitrary.mayoSpeedPotCount = 0;
			playerData2.arbitrary.mayoSpeedPotTime = new PlayerTime();
			playerData2.arbitrary.cardTierUpperCount = 0;
			playerData2.arbitrary.deckSpaceBought = 0;
			playerData2.arbitrary.mayoGenSlots = 0;
			playerData2.arbitrary.gotTagslot1 = false;
			UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
			playerData2.cards.cardState = UnityEngine.Random.state;
			playerData2.cards.chonkerState = UnityEngine.Random.state;
			if (playerData2.settings.prizePicked == 5)
			{
				playerData2.cards.manas[0].amount = 25;
				playerData2.cards.manas[1].amount = 25;
				playerData2.cards.manas[2].amount = 25;
				playerData2.cards.manas[3].amount = 25;
				playerData2.cards.manas[4].amount = 25;
				playerData2.cards.manas[5].amount = 25;
			}
			if (playerData2.settings.themeID == 4 && playerData2.settings.prizePicked != 6)
			{
				playerData2.settings.themeID = 0;
			}
			if (playerData2.wishes.wishes[4].level > 0 && playerData2.wandoos98.pitOSLevels < 100)
			{
				playerData2.wandoos98.pitOSLevels = 100L;
			}
		}
		if (playerData2.version < 1101)
		{
			playerData2.inventory.itemList.beatingHeartComplete = false;
		}
		if (playerData2.version < 1110)
		{
			playerData2.adventure.boss11Spawn = new PlayerTime();
			playerData2.adventure.titan11Unlocked = true;
			playerData2.adventure.titan11Kills = 0;
			playerData2.adventure.titan11Version = 0;
			playerData2.adventure.boss11Kills = 0;
			playerData2.adventure.titan11V1Kills = 0;
			playerData2.adventure.titan11V2Kills = 0;
			playerData2.adventure.titan11V3Kills = 0;
			playerData2.adventure.titan11V4Kills = 0;
			playerData2.inventory.itemList.breadverseComplete = false;
			playerData2.inventory.itemList.that70sComplete = false;
			playerData2.inventory.itemList.halloweeniesComplete = false;
			playerData2.inventory.itemList.rockLobsterComplete = false;
		}
		if (playerData2.version < 1120)
		{
			playerData2.arbitrary.hasAcc9 = false;
			playerData2.inventory.itemList.normalBonusAccComplete = false;
			playerData2.inventory.itemList.evilBonusAccComplete = false;
		}
		if (playerData2.version < 1130)
		{
			if (playerData2.adventure.boss5Kills > 0)
			{
				playerData2.bestiary.enemies[306].kills = 1;
				playerData2.bestiary.enemies[307].kills = 1;
				playerData2.bestiary.enemies[308].kills = 1;
				playerData2.bestiary.enemies[309].kills = 1;
			}
			if (playerData2.adventure.boss6Kills > 0)
			{
				playerData2.bestiary.enemies[311].kills = 1;
			}
			if (playerData2.adventure.boss7Kills > 0)
			{
				playerData2.bestiary.enemies[333].kills = 1;
			}
			if (playerData2.adventure.boss8Kills > 0)
			{
				playerData2.bestiary.enemies[338].kills = 1;
			}
			if (playerData2.adventure.boss9Kills > 0)
			{
				playerData2.bestiary.enemies[343].kills = 1;
			}
			if (playerData2.adventure.boss10Kills > 0)
			{
				playerData2.bestiary.enemies[364].kills = 1;
			}
		}
		if (playerData2.version < 1200)
		{
			playerData2.adventure.boss12Spawn = new PlayerTime();
			playerData2.adventure.titan12Unlocked = true;
			playerData2.adventure.titan12Kills = 0;
			playerData2.adventure.titan12Version = 0;
			playerData2.adventure.boss12Kills = 0;
			playerData2.adventure.titan12V1Kills = 0;
			playerData2.adventure.titan12V2Kills = 0;
			playerData2.adventure.titan12V3Kills = 0;
			playerData2.adventure.titan12V4Kills = 0;
		}
		if (playerData2.version < 1210)
		{
			playerData2.adventure.move69Unlocked = false;
			playerData2.adventure.move69Used = 0;
			playerData2.hacks.updateHackSize();
			playerData2.hacks.hacks[15].progress = 0f;
		}
		if (playerData2.version < 1220)
		{
			playerData2.settings.isNaughty = false;
			playerData2.settings.picked2ndPrize = false;
			playerData2.adventure.titan12Unlocked = true;
		}
		if (playerData2.version < 1250)
		{
			playerData2.adventure.boss13Spawn = new PlayerTime();
			playerData2.adventure.boss14Spawn = new PlayerTime();
			playerData2.adventure.ratTitanDefeated = false;
			playerData2.adventure.finalTitanDefeated = false;
		}
		_ = playerData2.version;
		_ = 1260;
		if (playerData2.res3 != null && playerData2.res3.res3BarSpeed >= 49.91f && playerData2.res3.res3BarSpeed < 50f)
		{
			playerData2.res3.res3BarSpeed = 50f;
		}
		if (playerData2.arbitrary.res3Potion1Time == null)
		{
			playerData2.arbitrary.res3Potion1Time = new PlayerTime();
		}
		if (playerData2.arbitrary.macGuffinBooster1Time == null)
		{
			playerData2.arbitrary.macGuffinBooster1Time = new PlayerTime();
		}
		if (playerData2.inventory.itemList == null)
		{
			playerData2.inventory.itemList = new ItemList();
		}
		playerData2.beards.checkBeards();
		if (playerData2.diggers == null)
		{
			playerData2.diggers = new GoldDiggers();
		}
		if (playerData2.challenges.nguChallenge == null)
		{
			playerData2.challenges.nguChallenge = new Challenge();
		}
		if (playerData2.challenges.timeMachineChallenge == null)
		{
			playerData2.challenges.timeMachineChallenge = new Challenge();
		}
		if (playerData2.bloodMagic.macguffin1Time == null)
		{
			playerData2.bloodMagic.macguffin1Time = new PlayerTime();
		}
		if (playerData2.bloodMagic.macguffin2Time == null)
		{
			playerData2.bloodMagic.macguffin2Time = new PlayerTime();
		}
		playerData2.diggers.validateDiggers();
		playerData2.wandoos98.validateWandoos();
		playerData2.adventure.itopod.updateItopod();
		playerData2.hacks.updateHackSize();
		if (playerData2.wishes == null)
		{
			playerData2.wishes = new Wishes();
		}
		playerData2.wishes.updateWishes();
		if (playerData2.portraits == null)
		{
			playerData2.portraits = new PlayerPortraits();
		}
		playerData2.portraits.updatePortraits();
		playerData2.res3.updateRes3();
		if (playerData2.beastQuest == null)
		{
			playerData2.beastQuest = new BeastQuest();
		}
		playerData2.beastQuest.updateBeastQuest();
		if (playerData2.wandoos98.bootupTime == null)
		{
			playerData2.wandoos98.bootupTime = new PlayerTime();
		}
		character.playerName = playerData2.playerName;
		character.firstTimePlaying = playerData2.firstTimePlaying;
		character.version = playerData2.version;
		character.lastTime = playerData2.lastTime;
		character.nextRebirthDifficulty = playerData2.nextRebirthDifficulty;
		character.curHP = playerData2.curHP;
		character.maxHP = playerData2.maxHP;
		character.hpRegen = playerData2.hpRegen;
		character.attack = playerData2.attack;
		character.defense = playerData2.defense;
		character.gold = playerData2.gold;
		character.realGold = playerData2.realGold;
		character.attackMulti = playerData2.attackMulti;
		character.defenseMulti = playerData2.defenseMulti;
		character.nextAttackMulti = playerData2.nextAttackMulti;
		character.nextDefenseMulti = playerData2.nextDefenseMulti;
		character.oldBossMulti = playerData2.oldBossMulti;
		character.timeMulti = playerData2.timeMulti;
		character.oldTimeMulti = playerData2.oldTimeMulti;
		character.exp = playerData2.exp;
		character.realExp = playerData2.realExp;
		character.attackBoost = playerData2.attackBoost;
		character.defenseBoost = playerData2.defenseBoost;
		character.energySpeed = playerData2.energySpeed;
		character.curEnergy = playerData2.curEnergy;
		character.idleEnergy = playerData2.idleEnergy;
		character.capEnergy = playerData2.capEnergy;
		character.energyGained = playerData2.energyGained;
		character.energyPerBar = playerData2.energyPerBar;
		character.energyBars = playerData2.energyBars;
		character.energyPower = playerData2.energyPower;
		character.energyBarProgress = playerData2.energyBarProgress;
		character.training = playerData2.training;
		character.bossID = playerData2.bossID;
		character.bossAttack = playerData2.bossAttack;
		character.bossDefense = playerData2.bossDefense;
		character.bossRegen = playerData2.bossRegen;
		character.bossCurHP = playerData2.bossCurHP;
		character.bossMaxHP = playerData2.bossMaxHP;
		character.bossMulti = playerData2.bossMulti;
		character.highestBoss = playerData2.highestBoss;
		character.highestHardBoss = playerData2.highestHardBoss;
		character.highestSadisticBoss = playerData2.highestSadisticBoss;
		character.firstBossEver = playerData2.firstBossEver;
		character.currentHighestBoss = playerData2.currentHighestBoss;
		if (playerData2.adventure != null)
		{
			character.adventure = playerData2.adventure;
		}
		if (playerData2.inventory != null)
		{
			character.inventory = playerData2.inventory;
		}
		if (playerData2.advancedTraining != null)
		{
			character.advancedTraining = playerData2.advancedTraining;
		}
		if (playerData2.augments != null)
		{
			character.augments = playerData2.augments;
		}
		if (playerData2.magic != null)
		{
			character.magic = playerData2.magic;
		}
		if (playerData2.machine != null)
		{
			character.machine = playerData2.machine;
		}
		if (playerData2.bloodMagic != null)
		{
			character.bloodMagic = playerData2.bloodMagic;
		}
		if (playerData2.rebirthTime != null)
		{
			character.rebirthTime = playerData2.rebirthTime;
		}
		if (playerData2.totalPlaytime != null)
		{
			character.totalPlaytime = playerData2.totalPlaytime;
		}
		character.lootState = playerData2.lootState;
		character.boostState = playerData2.boostState;
		if (playerData2.purchases != null)
		{
			character.purchases = playerData2.purchases;
		}
		if (playerData2.stats != null)
		{
			character.stats = playerData2.stats;
		}
		if (playerData2.perks != null)
		{
			character.perks = playerData2.perks;
		}
		if (playerData2.settings != null)
		{
			character.settings = playerData2.settings;
		}
		if (playerData2.challenges != null)
		{
			character.challenges = playerData2.challenges;
		}
		if (playerData2.pit != null)
		{
			character.pit = playerData2.pit;
		}
		if (playerData2.lootBoxes != null)
		{
			character.lootBoxes = playerData2.lootBoxes;
		}
		if (playerData2.wandoos98 != null)
		{
			character.wandoos98 = playerData2.wandoos98;
		}
		character.lastTime = playerData2.lastTime;
		if (playerData2.yggdrasil != null)
		{
			character.yggdrasil = playerData2.yggdrasil;
		}
		if (playerData2.NGU != null)
		{
			character.NGU = playerData2.NGU;
		}
		if (playerData2.arbitrary != null)
		{
			character.arbitrary = playerData2.arbitrary;
		}
		if (playerData2.arbitrary != null)
		{
			character.achievements = playerData2.achievements;
		}
		if (playerData2.daily != null)
		{
			character.daily = playerData2.daily;
		}
		if (playerData2.beards != null)
		{
			character.beards = playerData2.beards;
		}
		if (playerData2.diggers != null)
		{
			character.diggers = playerData2.diggers;
		}
		if (playerData2.beastQuest != null)
		{
			character.beastQuest = playerData2.beastQuest;
		}
		if (playerData2.res3 != null)
		{
			character.res3 = playerData2.res3;
		}
		if (playerData2.hacks != null)
		{
			character.hacks = playerData2.hacks;
		}
		if (playerData2.wishes != null)
		{
			character.wishes = playerData2.wishes;
		}
		if (playerData2.portraits != null)
		{
			character.portraits = playerData2.portraits;
		}
		if (playerData2.bestiary != null)
		{
			character.bestiary = playerData2.bestiary;
		}
		if (playerData2.cards != null)
		{
			character.cards = playerData2.cards;
		}
		if (playerData2.cooking != null)
		{
			character.cooking = playerData2.cooking;
		}
		if (playerData2.version < 1260)
		{
			character.cookingController.assignNewDish();
		}
		character.inventory.itemList.checkItemList();
		character.allAchievements.calculateBP();
		character.inventoryController.updateAccCount();
		character.inventoryController.updateMacguffinCount();
		character.inventoryController.updateInvCount();
		character.hacks.updateHackSize();
		character.bestiary.updateBestiary();
		character.cards.updateCards();
		character.inventoryController.updateDaycareCount();
		character.inventoryController.updateKittyArtCount();
		character.adventureController.itopodKillCount = 0;
		character.wandoos98Controller.updateWandoosUI();
		character.uiThemes.changeTheme(character.settings.themeID);
		finalTriggers();
	}

	public void finalTriggers()
	{
		character.portraits.portraitUnlocked[51] = true;
	}

	public string getBase64Data()
	{
		PlayerData value = gameStateToData();
		BinaryFormatter formatter = new BinaryFormatter();
		string text = BinaryFormatterExtensions.SerializeToString(formatter, value);
		string mD5Hash = getMD5Hash(text);
		SaveData value2 = new SaveData(text, mD5Hash);
		return BinaryFormatterExtensions.SerializeToString(formatter, value2);
	}

	public void loadBase64ToData(string base64Data)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		try
		{
			SaveData saveData = BinaryFormatterExtensions.DeserializeFromString(formatter, base64Data);
			loadData(saveData);
		}
		catch (Exception ex)
		{
			Debug.Log(ex.Message);
			tooltip.showTooltip("Failed to Load: " + ex.Message + "\nDid you mess with the file?");
		}
	}

	public PlayerData getDataFromString(string base64Data)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		try
		{
			SaveData saveData = BinaryFormatterExtensions.DeserializeFromString(formatter, base64Data);
			string playerData = saveData.playerData;
			if (getMD5Hash(playerData) != saveData.checksum)
			{
				tooltip.showTooltip("Error loading save. Did you mess with the save file text or somethin'?", 2f);
				return null;
			}
			return BinaryFormatterExtensions.DeserializePlayerDataFromString(formatter, saveData.playerData);
		}
		catch (Exception message)
		{
			Debug.Log(message);
			return null;
		}
	}

	public string getMD5Hash(string base64String)
	{
		return Convert.ToBase64String(md5.ComputeHash(Convert.FromBase64String(base64String)));
	}

	public string CalculateSha256Hash(string rawData)
	{
		using (SHA256 sHA = SHA256.Create())
		{
			byte[] array = sHA.ComputeHash(Encoding.UTF8.GetBytes(rawData));
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("x2"));
			}
			return stringBuilder.ToString();
		}
	}

	public SaveData getSaveDataFromString(string base64Data)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		try
		{
			SaveData saveData = BinaryFormatterExtensions.DeserializeFromString(formatter, base64Data);
			string playerData = saveData.playerData;
			if (getMD5Hash(playerData) != saveData.checksum)
			{
				tooltip.showTooltip("Error loading save. Did you mess with the save file text or somethin'?", 2f);
				return null;
			}
			return saveData;
		}
		catch (Exception message)
		{
			Debug.Log(message);
			return null;
		}
	}
}
