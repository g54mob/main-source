using System;

[Serializable]
public class Adventure
{
	public float attack;

	public float defense;

	public float regen;

	public float curHP;

	public float maxHP;

	public float respawnRate;

	public float attackSpeed;

	public int zone;

	public bool autoattacking;

	public PlayerTime boss1Spawn = new PlayerTime();

	public bool boss1Defeated;

	public int titan1Kills;

	public PlayerTime boss2Spawn = new PlayerTime();

	public bool boss2Defeated;

	public int titan2Kills;

	public PlayerTime boss3Spawn = new PlayerTime();

	public bool boss3Defeated;

	public int titan3Kills;

	public PlayerTime boss4Spawn = new PlayerTime();

	public bool boss4Defeated;

	public int titan4Kills;

	public PlayerTime boss5Spawn = new PlayerTime();

	public bool boss5Defeated;

	public int waldoDefeats;

	public int waldoFinds;

	public int boss5Kills;

	public int titan5Kills;

	public PlayerTime boss6Spawn = new PlayerTime();

	public bool boss6Defeated;

	public int titan6Kills;

	public bool clue1Complete;

	public bool clue2Complete;

	public bool clue3Complete;

	public bool clue4Complete;

	public bool titan6Unlocked;

	public int titan6Version;

	public int boss6Kills;

	public int titan6V1Kills;

	public int titan6V2Kills;

	public int titan6V3Kills;

	public int titan6V4Kills;

	public PlayerTime boss7Spawn = new PlayerTime();

	public bool boss7Defeated;

	public bool titan7questStarted;

	public int titan7QuestSequence;

	public bool titan7questComplete;

	public int titan7Kills;

	public bool titan7Unlocked;

	public int titan7Version;

	public int boss7Kills;

	public int titan7V1Kills;

	public int titan7V2Kills;

	public int titan7V3Kills;

	public int titan7V4Kills;

	public PlayerTime boss8Spawn = new PlayerTime();

	public bool boss8Defeated;

	public bool titan8questStarted;

	public int titan8QuestSequence;

	public bool titan8questComplete;

	public int titan8Kills;

	public bool titan8Unlocked;

	public int titan8Version;

	public int boss8Kills;

	public int titan8V1Kills;

	public int titan8V2Kills;

	public int titan8V3Kills;

	public int titan8V4Kills;

	public bool skeletonWhacked;

	public bool icarusWhacked;

	public bool emptyNameWhacked;

	public bool kingCircleWhacked;

	public bool robBossWhacked;

	public PlayerTime boss9Spawn = new PlayerTime();

	public bool boss9Defeated;

	public bool titan9questStarted;

	public bool titan9questComplete;

	public bool titan9SpecialReward;

	public int titan9Kills;

	public bool titan9Unlocked;

	public int titan9Version;

	public int boss9Kills;

	public int titan9V1Kills;

	public int titan9V2Kills;

	public int titan9V3Kills;

	public int titan9V4Kills;

	public PlayerTime boss10Spawn = new PlayerTime();

	public bool boss10Defeated;

	public bool titan10questStarted;

	public bool titan10SpecialReward;

	public int titan10Kills;

	public bool titan10Unlocked = true;

	public int titan10Version;

	public int boss10Kills;

	public int titan10V1Kills;

	public int titan10V2Kills;

	public int titan10V3Kills;

	public int titan10V4Kills;

	public PlayerTime boss11Spawn = new PlayerTime();

	public bool boss11Defeated;

	public int titan11Kills;

	public bool titan11Unlocked = true;

	public int titan11Version;

	public int boss11Kills;

	public int titan11V1Kills;

	public int titan11V2Kills;

	public int titan11V3Kills;

	public int titan11V4Kills;

	public PlayerTime boss12Spawn = new PlayerTime();

	public bool boss12Defeated;

	public int titan12Kills;

	public bool titan12Unlocked = true;

	public int titan12Version;

	public int boss12Kills;

	public int titan12V1Kills;

	public int titan12V2Kills;

	public int titan12V3Kills;

	public int titan12V4Kills;

	public bool ratTitanDefeated;

	public PlayerTime boss13Spawn = new PlayerTime();

	public bool finalTitanDefeated;

	public PlayerTime boss14Spawn = new PlayerTime();

	public int itopodStart;

	public int itopodEnd;

	public int highestItopodLevel;

	public ITOPOD itopod;

	public bool beastModeOn;

	public bool didAdvAdvance;

	public bool move69Unlocked;

	public int move69Used;

	[NonSerialized]
	public float idleAttackMulti;

	[NonSerialized]
	public float regAttackMulti;

	[NonSerialized]
	public float strongAttackMulti;

	[NonSerialized]
	public float pierceAttackMulti;

	[NonSerialized]
	public float ultimateAttackMulti;

	[NonSerialized]
	public float offenseBuffMulti;

	[NonSerialized]
	public float defenseBuffMulti;

	[NonSerialized]
	public float ultimateBuffMulti;

	[NonSerialized]
	public float chargeMulti;

	[NonSerialized]
	public float blockMulti;

	[NonSerialized]
	public float parryMulti;

	[NonSerialized]
	public float healMulti;

	[NonSerialized]
	public float focusMulti;

	[NonSerialized]
	public float paralyzeMulti;

	[NonSerialized]
	public float idleAttackCooldown;

	[NonSerialized]
	public float regAttackCooldown;

	[NonSerialized]
	public float strongAttackCooldown;

	[NonSerialized]
	public float pierceAttackCooldown;

	[NonSerialized]
	public float ultimateAttackCooldown;

	[NonSerialized]
	public float offenseBuffCooldown;

	[NonSerialized]
	public float defenseBuffCooldown;

	[NonSerialized]
	public float ultimateBuffCooldown;

	[NonSerialized]
	public float chargeCooldown;

	[NonSerialized]
	public float blockCooldown;

	[NonSerialized]
	public float parryCooldown;

	[NonSerialized]
	public float healCooldown;

	[NonSerialized]
	public float focusCooldown;

	[NonSerialized]
	public float paralyzeCooldown;

	[NonSerialized]
	public float hyperRegenCooldown;

	[NonSerialized]
	public float blockDuration;

	[NonSerialized]
	public float offenseBuffDuration;

	[NonSerialized]
	public float defenseBuffDuration;

	[NonSerialized]
	public float ultimateBuffDuration;

	[NonSerialized]
	public float hyperRegenDuration;

	public Adventure()
	{
		zone = -1;
		autoattacking = false;
		attack = 10f;
		defense = 10f;
		regen = 1f;
		curHP = 10f;
		maxHP = 50f;
		respawnRate = 5f;
		attackSpeed = 1f;
		boss5Defeated = false;
		waldoDefeats = 0;
		waldoFinds = 0;
		boss5Kills = 0;
		titan1Kills = 0;
		titan2Kills = 0;
		titan3Kills = 0;
		titan4Kills = 0;
		titan5Kills = 0;
		titan6Kills = 0;
		idleAttackMulti = 1.2f;
		regAttackMulti = 1.5f;
		strongAttackMulti = 3f;
		pierceAttackMulti = 1f;
		ultimateAttackMulti = 1f;
		offenseBuffMulti = 1.2f;
		defenseBuffMulti = 1.2f;
		ultimateBuffMulti = 1.3f;
		chargeMulti = 2f;
		blockMulti = 2f;
		parryMulti = 2f;
		healMulti = 0.15f;
		focusMulti = 0.15f;
		paralyzeMulti = 3f;
		regAttackCooldown = 1f;
		strongAttackCooldown = 4f;
		pierceAttackCooldown = 8f;
		ultimateAttackCooldown = 15f;
		offenseBuffCooldown = 45f;
		defenseBuffCooldown = 45f;
		ultimateBuffCooldown = 45f;
		chargeCooldown = 30f;
		blockCooldown = 10f;
		parryCooldown = 15f;
		healCooldown = 15f;
		focusCooldown = 15f;
		paralyzeCooldown = 25f;
		blockDuration = 3f;
		offenseBuffDuration = 15f;
		defenseBuffDuration = 15f;
		ultimateBuffDuration = 15f;
		itopod = new ITOPOD();
		itopodStart = 0;
		itopodEnd = 20;
		highestItopodLevel = 0;
		titan6Version = 0;
		beastModeOn = false;
		didAdvAdvance = false;
		titan10Unlocked = true;
		titan11Unlocked = true;
		titan12Unlocked = true;
		move69Unlocked = false;
		move69Used = 0;
	}

	public void resetAdventure()
	{
		zone = -1;
		idleAttackMulti = 1.2f;
		regAttackMulti = 1.5f;
		strongAttackMulti = 2f;
		pierceAttackMulti = 0.8f;
		ultimateAttackMulti = 1f;
		offenseBuffMulti = 1.2f;
		defenseBuffMulti = 1.2f;
		ultimateBuffMulti = 1.3f;
		chargeMulti = 2f;
		blockMulti = 2f;
		parryMulti = 2f;
		healMulti = 0.15f;
		focusMulti = 0.15f;
		regAttackCooldown = 1f;
		strongAttackCooldown = 4f;
		pierceAttackCooldown = 8f;
		ultimateAttackCooldown = 15f;
		offenseBuffCooldown = 45f;
		defenseBuffCooldown = 45f;
		ultimateBuffCooldown = 45f;
		chargeCooldown = 30f;
		blockCooldown = 10f;
		parryCooldown = 15f;
		healCooldown = 15f;
		focusCooldown = 15f;
		hyperRegenCooldown = 35f;
		blockDuration = 3f;
		offenseBuffDuration = 15f;
		defenseBuffDuration = 15f;
		ultimateBuffDuration = 15f;
		hyperRegenDuration = 5f;
		boss1Spawn.reset();
		boss1Defeated = false;
		titan1Kills = 0;
		boss2Spawn.reset();
		boss2Defeated = false;
		titan2Kills = 0;
		boss3Spawn.reset();
		boss3Defeated = false;
		titan3Kills = 0;
		boss4Spawn.reset();
		boss4Defeated = false;
		titan4Kills = 0;
		boss5Spawn.reset();
		boss5Defeated = false;
		titan5Kills = 0;
		boss6Spawn.reset();
		boss6Defeated = false;
		titan6Kills = 0;
		boss7Spawn.reset();
		boss7Defeated = false;
		titan7Kills = 0;
		boss8Spawn.reset();
		boss8Defeated = false;
		titan8Kills = 0;
		boss9Spawn.reset();
		boss9Defeated = false;
		titan9Kills = 0;
		boss10Spawn.reset();
		boss10Defeated = false;
		titan10Kills = 0;
		boss11Spawn.reset();
		boss11Defeated = false;
		titan11Kills = 0;
		didAdvAdvance = false;
		boss12Spawn.reset();
		boss12Defeated = false;
		titan12Kills = 0;
		boss13Spawn.reset();
		boss14Spawn.reset();
	}

	public void updateBaseStats()
	{
		idleAttackMulti = 1.2f;
		regAttackMulti = 1.5f;
		strongAttackMulti = 2f;
		pierceAttackMulti = 0.8f;
		ultimateAttackMulti = 1f;
		offenseBuffMulti = 1.2f;
		defenseBuffMulti = 1.2f;
		ultimateBuffMulti = 1.3f;
		chargeMulti = 2f;
		blockMulti = 2f;
		parryMulti = 2f;
		healMulti = 0.15f;
		focusMulti = 0.15f;
		paralyzeMulti = 0f;
		regAttackCooldown = 1f;
		strongAttackCooldown = 4f;
		pierceAttackCooldown = 5f;
		ultimateAttackCooldown = 15f;
		offenseBuffCooldown = 45f;
		defenseBuffCooldown = 45f;
		ultimateBuffCooldown = 45f;
		chargeCooldown = 30f;
		blockCooldown = 10f;
		parryCooldown = 15f;
		healCooldown = 15f;
		focusCooldown = 15f;
		paralyzeCooldown = 25f;
		blockDuration = 3f;
		offenseBuffDuration = 15f;
		defenseBuffDuration = 15f;
		ultimateBuffDuration = 15f;
	}

	public void setFasterIdleAttack()
	{
		attackSpeed = 0.8f;
	}
}
