using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
	public string playerName;

	public bool firstTimePlaying;

	public int version;

	public int lastTime;

	public difficulty nextRebirthDifficulty;

	public double maxHP;

	public double curHP;

	public double hpRegen;

	public double attack;

	public double defense;

	public float gold;

	public double realGold;

	public double attackMulti;

	public double defenseMulti;

	public double nextAttackMulti;

	public double nextDefenseMulti;

	public double oldBossMulti;

	public double timeMulti;

	public double oldTimeMulti;

	public int exp;

	public long realExp;

	public float attackBoost;

	public float defenseBoost;

	public float energySpeed;

	public long capEnergy;

	public long curEnergy;

	public long idleEnergy;

	public long energyGained;

	public int energyPerBar;

	public long energyBars;

	public float energyPower;

	public float energyBarProgress;

	public Training training;

	public int bossID;

	public double bossAttack;

	public double bossDefense;

	public double bossRegen;

	public double bossCurHP;

	public double bossMaxHP;

	public double bossMulti;

	public int highestBoss;

	public int highestHardBoss;

	public int highestSadisticBoss;

	public bool firstBossEver;

	public int currentHighestBoss;

	public Adventure adventure;

	public Inventory inventory;

	public AdvancedTraining advancedTraining;

	public Augmentation augments;

	public Magic magic;

	public TimeMachine machine;

	public BloodMagic bloodMagic;

	public PlayerTime rebirthTime;

	public PlayerTime totalPlaytime;

	public UnityEngine.Random.State lootState;

	public UnityEngine.Random.State boostState;

	public Purchases purchases;

	public Stats stats;

	public Perks perks;

	public PlayerSettings settings;

	public Challenges challenges;

	public Pit pit;

	public LootBoxes lootBoxes;

	public Wandoos98 wandoos98;

	public Yggdrasil yggdrasil;

	public NUMBERSSGOUP NGU;

	public Arbitrary arbitrary;

	public AchievementList achievements;

	public DailyReward daily;

	public Beards beards;

	public GoldDiggers diggers;

	public BeastQuest beastQuest;

	public Resource3 res3;

	public Hacks hacks;

	public Wishes wishes;

	public PlayerPortraits portraits;

	public Bestiary bestiary;

	public Cards cards;

	public Cooking cooking;
}
