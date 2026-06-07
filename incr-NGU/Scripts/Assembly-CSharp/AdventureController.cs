using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureController : MonoBehaviour
{
	public Character character;

	public NumberFormat format;

	public HoverTooltip tooltip;

	public Slider playerHPBar;

	public Slider enemyHPBar;

	public Text zoneTitle;

	public Text zoneSubtitle;

	public Text playerHPText;

	public Text enemyHPText;

	public Text playerStats;

	public Text enemyStats;

	public Text TitanText;

	public Image bossIcon;

	public PlayerLog log;

	public Enemy currentEnemy;

	public EnemyAI enemyAI;

	public List<List<Enemy>> enemyList = new List<List<Enemy>>();

	public PlayerController playerController;

	public ItopodPerkController itopod;

	public LootDrop lootDrop;

	public ZoneSelector zoneSelector;

	public Dropdown zoneDropdown;

	public ZoneForwardClick zoneForward;

	public ZoneBackwardsClick zoneBackwards;

	public Image enemyBarBackground;

	public Image enemyBarFill;

	public Sprite checkSprite;

	public Sprite emptySprite;

	public List<Sprite> enemySprites;

	public List<Sprite> itopodSprites;

	public Image enemyPortrait;

	public Button[] titanDifficultyButtons;

	public Button enterItopodButton;

	public Button itopodPerksButton;

	public Button advAdvancerSetter;

	public InputField itopodStartInput;

	public InputField itopodEndInput;

	public Image pillUsed;

	public Text pillText;

	public Image shifterUsed;

	public Text shifterText;

	public Button shifterToggle;

	public List<Enemy> itopodEnemyList = new List<Enemy>();

	public IdleAttack idleAttackMove;

	public RegularAttack regularAttackMove;

	public StrongAttack strongAttackMove;

	public Parry parryMove;

	public PiercingAttack pierceMove;

	public UltimateAttack ultimateAttackMove;

	public Block blockMove;

	public DefenseBuff defenseBuffMove;

	public Heal healMove;

	public OffenseBuff offenseBuffMove;

	public Charge chargeMove;

	public UltimateBuff ultimateBuffMove;

	public Paralyze paralyzeMove;

	public HyperRegen hyperRegenMove;

	public BeastMode beastModeMove;

	public MegaBuff megaBuffMove;

	public OhShit ohShitMove;

	private int _zone = -1;

	private float _respawnTimer;

	private float _idleAttackTimer;

	private bool _fightInProgress;

	private float baseRespawn = 4f;

	public float idleAttackMulti;

	public float regAttackMulti;

	public float strongAttackMulti;

	public float pierceAttackMulti;

	public float ultimateAttackMulti;

	public float offenseBuffMulti;

	public float defenseBuffMulti;

	public float ultimateBuffMulti;

	public float chargeMulti;

	public float blockMulti;

	public float parryMulti;

	public float healMulti;

	public float focusMulti;

	public float paralyzeMulti;

	public float idleAttackCooldown;

	public float regAttackCooldown;

	public float strongAttackCooldown;

	public float pierceAttackCooldown;

	public float ultimateAttackCooldown;

	public float offenseBuffCooldown;

	public float defenseBuffCooldown;

	public float ultimateBuffCooldown;

	public float chargeCooldown;

	public float blockCooldown;

	public float parryCooldown;

	public float healCooldown;

	public float focusCooldown;

	public float paralyzeCooldown;

	public float hyperRegenCooldown;

	public float blockDuration;

	public float offenseBuffDuration;

	public float defenseBuffDuration;

	public float ultimateBuffDuration;

	public float hyperRegenDuration;

	private string message;

	public int itopodLevel;

	public int itopodKillCount;

	public long globalKillCounter;

	public bool clue4Eligible;

	public int zone
	{
		get
		{
			return _zone;
		}
		set
		{
			_zone = value;
		}
	}

	public float respawnTimer
	{
		get
		{
			return _respawnTimer;
		}
		set
		{
			_respawnTimer = value;
		}
	}

	public float idleAttackTimer
	{
		get
		{
			return _idleAttackTimer;
		}
		set
		{
			_idleAttackTimer = value;
		}
	}

	public bool fightInProgress
	{
		get
		{
			return _fightInProgress;
		}
		set
		{
			_fightInProgress = value;
		}
	}

	public float boss1SpawnTime()
	{
		return 3600f;
	}

	public float boss2SpawnTime()
	{
		return 3600f;
	}

	public float boss3SpawnTime()
	{
		float num = 7200f;
		num -= Mathf.Min((float)character.allChallenges.noRebirthChallenge.completions() * 900f, 3600f);
		if (num < 3600f)
		{
			num = 3600f;
		}
		return num;
	}

	public float boss4SpawnTime()
	{
		float num = 7200f;
		num -= Mathf.Min((float)character.allChallenges.noRebirthChallenge.completions() * 900f, 3600f);
		if (num < 3600f)
		{
			num = 3600f;
		}
		return num;
	}

	public float boss5SpawnTime()
	{
		float num = 10800f;
		num -= Mathf.Min((float)character.allChallenges.noRebirthChallenge.completions() * 900f, 7200f);
		if (num < 3600f)
		{
			num = 3600f;
		}
		return num;
	}

	public float boss6SpawnTime()
	{
		float num = 12600f;
		num -= Mathf.Min((float)character.allChallenges.noRebirthChallenge.completions() * 900f, 9000f);
		if (num < 3600f)
		{
			num = 3600f;
		}
		return num;
	}

	public float boss7SpawnTime()
	{
		float num = 16200f;
		num -= Mathf.Min((float)(character.allChallenges.noRebirthChallenge.completions() + character.allChallenges.noRebirthChallenge.evilCompletions()) * 900f, 12600f);
		if (num < 3600f)
		{
			num = 3600f;
		}
		return num;
	}

	public float boss8SpawnTime()
	{
		float num = 18000f;
		num -= Mathf.Min((float)(character.allChallenges.noRebirthChallenge.completions() + character.allChallenges.noRebirthChallenge.evilCompletions()) * 900f, 14400f);
		if (num < 3600f)
		{
			num = 3600f;
		}
		return num;
	}

	public float boss9SpawnTime()
	{
		float num = 19800f;
		num -= Mathf.Min((float)(character.allChallenges.noRebirthChallenge.completions() + character.allChallenges.noRebirthChallenge.evilCompletions()) * 900f, 16200f);
		if (num < 3600f)
		{
			num = 3600f;
		}
		return num;
	}

	public float boss10SpawnTime()
	{
		float num = 23400f;
		num -= Mathf.Min((float)(character.allChallenges.noRebirthChallenge.completions() + character.allChallenges.noRebirthChallenge.evilCompletions() + character.allChallenges.noRebirthChallenge.sadisticCompletions()) * 900f, 19800f);
		if (num < 3600f)
		{
			num = 3600f;
		}
		return num;
	}

	public float boss11SpawnTime()
	{
		float num = 25200f;
		num -= Mathf.Min((float)(character.allChallenges.noRebirthChallenge.completions() + character.allChallenges.noRebirthChallenge.evilCompletions() + character.allChallenges.noRebirthChallenge.sadisticCompletions()) * 900f, 21600f);
		if (num < 3600f)
		{
			num = 3600f;
		}
		return num;
	}

	public float boss12SpawnTime()
	{
		float num = 27000f;
		num -= Mathf.Min((float)(character.allChallenges.noRebirthChallenge.completions() + character.allChallenges.noRebirthChallenge.evilCompletions() + character.allChallenges.noRebirthChallenge.sadisticCompletions()) * 900f, 23400f);
		if (num < 3600f)
		{
			num = 3600f;
		}
		return num;
	}

	public float boss13SpawnTime()
	{
		float num = 27000f;
		num -= Mathf.Min((float)(character.allChallenges.noRebirthChallenge.completions() + character.allChallenges.noRebirthChallenge.evilCompletions() + character.allChallenges.noRebirthChallenge.sadisticCompletions()) * 900f, 23400f);
		if (num < 3600f)
		{
			num = 3600f;
		}
		return num;
	}

	public float boss14SpawnTime()
	{
		float num = 27000f;
		num -= Mathf.Min((float)(character.allChallenges.noRebirthChallenge.completions() + character.allChallenges.noRebirthChallenge.evilCompletions() + character.allChallenges.noRebirthChallenge.sadisticCompletions()) * 900f, 23400f);
		if (num < 3600f)
		{
			num = 3600f;
		}
		return num;
	}

	public long boss1Exp()
	{
		return Convert.ToInt64(35f * character.allChallenges.expFactor());
	}

	public long boss2Exp()
	{
		return Convert.ToInt64(60f * character.allChallenges.expFactor());
	}

	public long boss3Exp()
	{
		return Convert.ToInt64(200f * character.allChallenges.expFactor());
	}

	public long boss4Exp()
	{
		return Convert.ToInt64(300f * character.allChallenges.expFactor());
	}

	public long boss5Exp()
	{
		return Convert.ToInt64(500f * character.allChallenges.expFactor());
	}

	public long boss6Exp()
	{
		return Convert.ToInt64(750f * character.allChallenges.expFactor());
	}

	public long boss7Exp()
	{
		return Convert.ToInt64(1100f * character.allChallenges.expFactor());
	}

	public long boss8Exp()
	{
		return Convert.ToInt64(1500f * character.allChallenges.expFactor());
	}

	public long boss9Exp()
	{
		return Convert.ToInt64(2500f * character.allChallenges.expFactor());
	}

	public long boss10Exp()
	{
		return Convert.ToInt64(4000f * character.allChallenges.expFactor());
	}

	public long boss11Exp()
	{
		return Convert.ToInt64(6000f * character.allChallenges.expFactor());
	}

	public long boss12Exp()
	{
		return Convert.ToInt64(8000f * character.allChallenges.expFactor());
	}

	public long boss1AP()
	{
		return 10L;
	}

	public long boss2AP()
	{
		return 15L;
	}

	public long boss3AP()
	{
		return 50L;
	}

	public long boss4AP()
	{
		return 60L;
	}

	public long boss5AP()
	{
		return 70L;
	}

	public long boss6PP()
	{
		return (long)(250000f * character.adventureController.itopod.totalPPBonus(usePills: false));
	}

	public long boss7PP()
	{
		return (long)(250000f * character.adventureController.itopod.totalPPBonus(usePills: false));
	}

	public long boss8PP()
	{
		return (long)(300000f * character.adventureController.itopod.totalPPBonus(usePills: false));
	}

	public long boss9PP()
	{
		return (long)(400000f * character.adventureController.itopod.totalPPBonus(usePills: false));
	}

	public long boss10PP()
	{
		return (long)(500000f * character.adventureController.itopod.totalPPBonus(usePills: false));
	}

	public long boss11PP()
	{
		return (long)(700000f * character.adventureController.itopod.totalPPBonus(usePills: false));
	}

	public long boss12PP()
	{
		return (long)(1000000f * character.adventureController.itopod.totalPPBonus(usePills: false));
	}

	public long boss6QP()
	{
		return (long)(1f * character.beastQuestController.questRewardFactor());
	}

	public long boss7QP()
	{
		return (long)(1f * character.beastQuestController.questRewardFactor());
	}

	public long boss8QP()
	{
		float num = character.beastQuestController.questRewardFactor();
		if (character.beastQuest.usedButter)
		{
			num /= character.allArbitrary.butterModifier();
		}
		if (num < 1f)
		{
			num = 1f;
		}
		return (long)(2f * num);
	}

	public long boss9QP()
	{
		float num = character.beastQuestController.questRewardFactor();
		if (character.beastQuest.usedButter)
		{
			num /= character.allArbitrary.butterModifier();
		}
		if (num < 1f)
		{
			num = 1f;
		}
		return (long)(3f * num);
	}

	public long boss10QP()
	{
		float num = character.beastQuestController.questRewardFactor();
		if (character.beastQuest.usedButter)
		{
			num /= character.allArbitrary.butterModifier();
		}
		if (num < 1f)
		{
			num = 1f;
		}
		return (long)(4f * num);
	}

	public long boss11QP()
	{
		float num = character.beastQuestController.questRewardFactor();
		if (character.beastQuest.usedButter)
		{
			num /= character.allArbitrary.butterModifier();
		}
		if (num < 1f)
		{
			num = 1f;
		}
		return (long)(5f * num);
	}

	public long boss12QP()
	{
		float num = character.beastQuestController.questRewardFactor();
		if (character.beastQuest.usedButter)
		{
			num /= character.allArbitrary.butterModifier();
		}
		if (num < 1f)
		{
			num = 1f;
		}
		return (long)(6f * num);
	}

	public bool shouldLightButton()
	{
		if (!character.arbitrary.advLightBought)
		{
			return false;
		}
		if (!character.adventure.autoattacking && character.menuID != 3)
		{
			return true;
		}
		if (character.menuID != 3 && zone == -1)
		{
			return true;
		}
		if (character.menuID != 3 && zone == 6 && character.adventure.boss1Spawn.totalseconds < (double)boss1SpawnTime())
		{
			return true;
		}
		if (character.menuID != 3 && zone == 8 && character.adventure.boss2Spawn.totalseconds < (double)boss2SpawnTime())
		{
			return true;
		}
		if (character.menuID != 3 && zone == 11 && character.adventure.boss3Spawn.totalseconds < (double)boss3SpawnTime())
		{
			return true;
		}
		if (character.menuID != 3 && zone == 14 && character.adventure.boss4Spawn.totalseconds < (double)boss4SpawnTime())
		{
			return true;
		}
		if (character.menuID != 3 && zone == 16 && character.adventure.boss5Spawn.totalseconds < (double)boss5SpawnTime())
		{
			return true;
		}
		if (character.menuID != 3 && zone == 19 && character.adventure.boss6Spawn.totalseconds < (double)boss6SpawnTime())
		{
			return true;
		}
		if (character.menuID != 3 && zone == 23 && character.adventure.boss7Spawn.totalseconds < (double)boss7SpawnTime())
		{
			return true;
		}
		if (character.menuID != 3 && zone == 26 && character.adventure.boss8Spawn.totalseconds < (double)boss8SpawnTime())
		{
			return true;
		}
		if (character.menuID != 3 && zone == 30 && character.adventure.boss9Spawn.totalseconds < (double)boss9SpawnTime())
		{
			return true;
		}
		if (character.menuID != 3 && zone == 34 && character.adventure.boss10Spawn.totalseconds < (double)boss10SpawnTime())
		{
			return true;
		}
		if (character.menuID != 3 && zone == 38 && character.adventure.boss11Spawn.totalseconds < (double)boss11SpawnTime())
		{
			return true;
		}
		if (character.menuID != 3 && zone == 42 && character.adventure.boss12Spawn.totalseconds < (double)boss12SpawnTime())
		{
			return true;
		}
		if (character.menuID != 3 && zone == 44 && character.adventure.boss13Spawn.totalseconds < (double)boss14SpawnTime())
		{
			return true;
		}
		if (character.menuID != 3 && zone == 45 && character.adventure.boss14Spawn.totalseconds < (double)boss14SpawnTime())
		{
			return true;
		}
		return false;
	}

	public int maxItopodLevel()
	{
		return 1600;
	}

	private void Start()
	{
		character.adventure.updateBaseStats();
		if (character.adventure.boss1Spawn == null)
		{
			character.adventure.boss1Spawn = new PlayerTime();
		}
		if (character.adventure.boss2Spawn == null)
		{
			character.adventure.boss2Spawn = new PlayerTime();
		}
		if (character.adventure.boss3Spawn == null)
		{
			character.adventure.boss3Spawn = new PlayerTime();
		}
		zoneTitle.text = "SAFE ZONE: AWAKENING SITE";
		bossIcon.sprite = Resources.Load<Sprite>("BossIcon");
		bossIcon.enabled = false;
		createEnemyTable();
		InvokeRepeating("updateAdventureStats", 0f, 0.5f);
		InvokeRepeating("displayEnemyStats", 0f, 0.5f);
	}

	private void Update()
	{
		if (character.adventure.boss1Spawn.totalseconds < (double)boss1SpawnTime())
		{
			character.adventure.boss1Spawn.advanceTime(Time.deltaTime);
		}
		if (character.adventure.boss2Spawn.totalseconds < (double)boss2SpawnTime())
		{
			character.adventure.boss2Spawn.advanceTime(Time.deltaTime);
		}
		if (character.adventure.boss3Spawn.totalseconds < (double)boss3SpawnTime())
		{
			character.adventure.boss3Spawn.advanceTime(Time.deltaTime);
		}
		if (character.adventure.boss4Spawn.totalseconds < (double)boss4SpawnTime())
		{
			character.adventure.boss4Spawn.advanceTime(Time.deltaTime);
		}
		if (character.adventure.boss5Spawn.totalseconds < (double)boss5SpawnTime() && (character.adventure.waldoDefeats <= character.adventure.waldoFinds || character.adventure.waldoFinds >= 4))
		{
			character.adventure.boss5Spawn.advanceTime(Time.deltaTime);
		}
		if (character.adventure.boss6Spawn.totalseconds < (double)boss6SpawnTime())
		{
			character.adventure.boss6Spawn.advanceTime(Time.deltaTime);
		}
		if (character.adventure.boss7Spawn.totalseconds < (double)boss7SpawnTime())
		{
			character.adventure.boss7Spawn.advanceTime(Time.deltaTime);
		}
		if (character.adventure.boss8Spawn.totalseconds < (double)boss8SpawnTime())
		{
			character.adventure.boss8Spawn.advanceTime(Time.deltaTime);
		}
		if (character.adventure.boss9Spawn.totalseconds < (double)boss9SpawnTime())
		{
			character.adventure.boss9Spawn.advanceTime(Time.deltaTime);
		}
		if (character.adventure.boss10Spawn.totalseconds < (double)boss10SpawnTime())
		{
			character.adventure.boss10Spawn.advanceTime(Time.deltaTime);
		}
		if (character.adventure.boss11Spawn.totalseconds < (double)boss11SpawnTime())
		{
			character.adventure.boss11Spawn.advanceTime(Time.deltaTime);
		}
		if (character.adventure.boss12Spawn.totalseconds < (double)boss12SpawnTime())
		{
			character.adventure.boss12Spawn.advanceTime(Time.deltaTime);
		}
		if (character.adventure.boss13Spawn.totalseconds < (double)boss13SpawnTime())
		{
			character.adventure.boss13Spawn.advanceTime(Time.deltaTime);
		}
		if (character.adventure.boss14Spawn.totalseconds < (double)boss14SpawnTime())
		{
			character.adventure.boss14Spawn.advanceTime(Time.deltaTime);
		}
		if (character.rebirthTime.totalseconds >= 20.0 && character.rebirthTime.totalseconds <= 30.0 && character.arbitrary.advAdvancerBought && !character.adventure.didAdvAdvance)
		{
			zoneForward.goToMaxZone(character.arbitrary.advAdvancerZone);
			character.adventure.didAdvAdvance = true;
		}
		manageFight();
		updateEnemy();
		updatePlayer();
		updateTimer();
	}

	public float maxHP()
	{
		return character.totalAdvHP();
	}

	public float attack()
	{
		return character.totalAdvAttack();
	}

	public float defense()
	{
		return character.totalAdvDefense();
	}

	public float getBaseRespawnTime()
	{
		return baseRespawn;
	}

	public float respawnTime()
	{
		float num = baseRespawn * character.NGUController.respawnBonus();
		float num2 = 1f - character.inventoryController.bonuses[specType.Respawn];
		if ((double)num2 < 0.2)
		{
			num2 = 0.2f;
		}
		num *= num2;
		if (character.inventory.itemList.clockComplete)
		{
			num *= 0.95f;
		}
		if (character.adventure.itopod.perkLevel[93] >= 1)
		{
			num *= character.adventureController.itopod.totalRespawnBonus();
		}
		return num * character.wishesController.totalRespawnBonus();
	}

	public float respawnBonus()
	{
		float num = 1f * character.NGUController.respawnBonus();
		float num2 = 1f - character.inventoryController.bonuses[specType.Respawn];
		if ((double)num2 < 0.2)
		{
			num2 = 0.2f;
		}
		num *= num2;
		if (character.inventory.itemList.clockComplete)
		{
			num *= 0.95f;
		}
		if (character.adventure.itopod.perkLevel[93] >= 1)
		{
			num *= character.adventureController.itopod.totalRespawnBonus();
		}
		return num * character.wishesController.totalRespawnBonus();
	}

	private void manageFight()
	{
		if (character.bossID < 1)
		{
			return;
		}
		if (character.effectiveBossID() >= 58 && character.adventure.boss1Spawn.totalseconds >= (double)boss1SpawnTime() && character.totalAdvAttack() > 3000f && character.totalAdvDefense() > 2500f && character.settings.autoKillTitans)
		{
			if (zone == 6 && currentEnemy != null)
			{
				wipeEnemy();
			}
			character.bestiaryController.addKills(302, 1);
			character.adventure.boss1Spawn.reset();
			lootDrop.zone6Drop(enemyList[6][0]);
			return;
		}
		if (character.effectiveBossID() >= 66 && character.adventure.boss2Spawn.totalseconds >= (double)boss2SpawnTime() && character.totalAdvAttack() > 9000f && character.totalAdvDefense() > 7000f && character.settings.autoKillTitans)
		{
			if (zone == 8 && currentEnemy != null)
			{
				wipeEnemy();
			}
			character.bestiaryController.addKills(303, 1);
			character.adventure.boss2Spawn.reset();
			lootDrop.zone8Drop(enemyList[8][0]);
			return;
		}
		if (character.effectiveBossID() >= 82 && character.adventure.boss3Spawn.totalseconds >= (double)boss3SpawnTime() && character.totalAdvAttack() > 25000f && character.totalAdvDefense() > 15000f && character.settings.autoKillTitans)
		{
			if (zone == 11 && currentEnemy != null)
			{
				wipeEnemy();
			}
			character.bestiaryController.addKills(304, 1);
			character.adventure.boss3Spawn.reset();
			lootDrop.zone11Drop(enemyList[11][0]);
			character.challenges.noRebirthChallenge.unlocked = true;
			return;
		}
		if (character.effectiveBossID() >= 100 && character.adventure.boss4Spawn.totalseconds >= (double)boss4SpawnTime() && character.totalAdvAttack() >= 800000f && character.totalAdvDefense() >= 400000f && character.totalAdvHPRegen() >= 14000f && character.inventory.itemList.itemMaxxed[135] && character.settings.autoKillTitans)
		{
			if (zone == 14 && currentEnemy != null)
			{
				wipeEnemy();
			}
			character.bestiaryController.addKills(305, 1);
			character.adventure.boss4Spawn.reset();
			lootDrop.zone14Drop(enemyList[14][0]);
			return;
		}
		if (character.effectiveBossID() >= 116 && character.adventure.boss5Spawn.totalseconds >= (double)boss5SpawnTime() && character.totalAdvAttack() >= 13000000f && character.totalAdvDefense() >= 7000000f && character.totalAdvHPRegen() >= 150000f && character.adventure.boss5Kills >= 3 && character.settings.autoKillTitans)
		{
			if (zone == 16 && currentEnemy != null)
			{
				wipeEnemy();
			}
			character.bestiaryController.addKills(310, 1);
			character.adventure.boss5Spawn.reset();
			lootDrop.zone16Drop(enemyList[16][4]);
			character.allAchievements.markAchievementAsComplete(145);
			return;
		}
		if (character.effectiveBossID() >= 132 && character.adventure.boss6Spawn.totalseconds >= (double)boss6SpawnTime() && character.adventure.titan6Unlocked)
		{
			if (character.adventure.titan6Version == 3 && autokillTitan6V4Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 19 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(315, 1);
					character.bestiaryController.forceUnlock(314);
					character.bestiaryController.forceUnlock(313);
					character.bestiaryController.forceUnlock(312);
					character.adventure.boss6Spawn.reset();
					lootDrop.zone19Drop(enemyList[19][4]);
					character.allAchievements.markAchievementAsComplete(151);
					return;
				}
			}
			else if (character.adventure.titan6Version == 2 && autokillTitan6V3Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 19 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(314, 1);
					character.bestiaryController.forceUnlock(313);
					character.bestiaryController.forceUnlock(312);
					character.adventure.boss6Spawn.reset();
					lootDrop.zone19Drop(enemyList[19][3]);
					character.allAchievements.markAchievementAsComplete(150);
					return;
				}
			}
			else if (character.adventure.titan6Version == 1 && autokillTitan6V2Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 19 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(313, 1);
					character.bestiaryController.forceUnlock(312);
					character.adventure.boss6Spawn.reset();
					lootDrop.zone19Drop(enemyList[19][2]);
					character.allAchievements.markAchievementAsComplete(149);
					return;
				}
			}
			else if (character.adventure.titan6Version == 0 && autokillTitan6V1Achieved() && character.settings.autoKillTitans)
			{
				if (zone == 19 && currentEnemy != null)
				{
					wipeEnemy();
				}
				character.bestiaryController.addKills(312, 1);
				character.adventure.boss6Spawn.reset();
				lootDrop.zone19Drop(enemyList[19][1]);
				character.allAchievements.markAchievementAsComplete(148);
				return;
			}
		}
		if (character.effectiveBossID() >= 426 && character.adventure.boss7Spawn.totalseconds >= (double)boss7SpawnTime() && character.adventure.titan7Unlocked)
		{
			if (character.adventure.titan7Version == 3 && autokillTitan7V4Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 23 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(337, 1);
					character.bestiaryController.forceUnlock(336);
					character.bestiaryController.forceUnlock(335);
					character.bestiaryController.forceUnlock(334);
					character.adventure.boss7Spawn.reset();
					lootDrop.zone23Drop(enemyList[23][4]);
					return;
				}
			}
			else if (character.adventure.titan7Version == 2 && autokillTitan7V3Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 23 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(336, 1);
					character.bestiaryController.forceUnlock(335);
					character.bestiaryController.forceUnlock(334);
					character.adventure.boss7Spawn.reset();
					lootDrop.zone23Drop(enemyList[23][3]);
					return;
				}
			}
			else if (character.adventure.titan7Version == 1 && autokillTitan7V2Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 23 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(335, 1);
					character.bestiaryController.forceUnlock(334);
					character.adventure.boss7Spawn.reset();
					lootDrop.zone23Drop(enemyList[23][2]);
					return;
				}
			}
			else if (character.adventure.titan7Version == 0 && autokillTitan7V1Achieved() && character.settings.autoKillTitans)
			{
				if (zone == 23 && currentEnemy != null)
				{
					wipeEnemy();
				}
				character.bestiaryController.addKills(334, 1);
				character.adventure.boss7Spawn.reset();
				lootDrop.zone23Drop(enemyList[23][1]);
				return;
			}
		}
		if (character.effectiveBossID() >= 467 && character.adventure.boss8Spawn.totalseconds >= (double)boss8SpawnTime() && character.adventure.titan8Unlocked)
		{
			if (character.adventure.titan8Version == 3 && autokillTitan8V4Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 26 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(342, 1);
					character.bestiaryController.forceUnlock(341);
					character.bestiaryController.forceUnlock(340);
					character.bestiaryController.forceUnlock(339);
					character.adventure.boss8Spawn.reset();
					lootDrop.zone26Drop(enemyList[26][4]);
					return;
				}
			}
			else if (character.adventure.titan8Version == 2 && autokillTitan8V3Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 26 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(341, 1);
					character.bestiaryController.forceUnlock(340);
					character.bestiaryController.forceUnlock(339);
					character.adventure.boss8Spawn.reset();
					lootDrop.zone26Drop(enemyList[26][3]);
					return;
				}
			}
			else if (character.adventure.titan8Version == 1 && autokillTitan8V2Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 26 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(340, 1);
					character.bestiaryController.forceUnlock(339);
					character.adventure.boss8Spawn.reset();
					lootDrop.zone26Drop(enemyList[26][2]);
					return;
				}
			}
			else if (character.adventure.titan8Version == 0 && autokillTitan8V1Achieved() && character.settings.autoKillTitans)
			{
				if (zone == 26 && currentEnemy != null)
				{
					wipeEnemy();
				}
				character.bestiaryController.addKills(339, 1);
				character.adventure.boss8Spawn.reset();
				lootDrop.zone26Drop(enemyList[26][1]);
				return;
			}
		}
		if (character.effectiveBossID() >= 491 && character.adventure.boss9Spawn.totalseconds >= (double)boss9SpawnTime() && character.adventure.titan9Unlocked)
		{
			if (character.adventure.titan9Version == 3 && autokillTitan9V4Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 30 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(347, 1);
					character.bestiaryController.forceUnlock(346);
					character.bestiaryController.forceUnlock(345);
					character.bestiaryController.forceUnlock(344);
					character.adventure.boss9Spawn.reset();
					lootDrop.zone30Drop(enemyList[30][4]);
					return;
				}
			}
			else if (character.adventure.titan9Version == 2 && autokillTitan9V3Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 30 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(346, 1);
					character.bestiaryController.forceUnlock(345);
					character.bestiaryController.forceUnlock(344);
					character.adventure.boss9Spawn.reset();
					lootDrop.zone30Drop(enemyList[30][3]);
					return;
				}
			}
			else if (character.adventure.titan9Version == 1 && autokillTitan9V2Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 30 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(345, 1);
					character.bestiaryController.forceUnlock(344);
					character.adventure.boss9Spawn.reset();
					lootDrop.zone30Drop(enemyList[30][2]);
					return;
				}
			}
			else if (character.adventure.titan9Version == 0 && autokillTitan9V1Achieved() && character.settings.autoKillTitans)
			{
				if (zone == 30 && currentEnemy != null)
				{
					wipeEnemy();
				}
				character.bestiaryController.addKills(344, 1);
				character.adventure.boss9Spawn.reset();
				lootDrop.zone30Drop(enemyList[30][1]);
				return;
			}
		}
		if (character.effectiveBossID() >= 777 && character.adventure.boss10Spawn.totalseconds >= (double)boss10SpawnTime() && character.adventure.titan10Unlocked)
		{
			if (character.adventure.titan10Version == 3 && autokillTitan10V4Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 34 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(368, 1);
					character.bestiaryController.forceUnlock(367);
					character.bestiaryController.forceUnlock(366);
					character.bestiaryController.forceUnlock(365);
					character.adventure.boss10Spawn.reset();
					lootDrop.zone34Drop(enemyList[34][4]);
					return;
				}
			}
			else if (character.adventure.titan10Version == 2 && autokillTitan10V3Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 34 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(367, 1);
					character.bestiaryController.forceUnlock(366);
					character.bestiaryController.forceUnlock(365);
					character.adventure.boss10Spawn.reset();
					lootDrop.zone34Drop(enemyList[34][3]);
					return;
				}
			}
			else if (character.adventure.titan10Version == 1 && autokillTitan10V2Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 34 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(366, 1);
					character.bestiaryController.forceUnlock(365);
					character.adventure.boss10Spawn.reset();
					lootDrop.zone34Drop(enemyList[34][2]);
					return;
				}
			}
			else if (character.adventure.titan10Version == 0 && autokillTitan10V1Achieved() && character.settings.autoKillTitans)
			{
				if (zone == 34 && currentEnemy != null)
				{
					wipeEnemy();
				}
				character.bestiaryController.addKills(365, 1);
				character.adventure.boss10Spawn.reset();
				lootDrop.zone34Drop(enemyList[34][1]);
				return;
			}
		}
		if (character.effectiveBossID() >= 826 && character.adventure.boss11Spawn.totalseconds >= (double)boss11SpawnTime() && character.adventure.titan11Unlocked)
		{
			if (character.adventure.titan11Version == 3 && autokillTitan11V4Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 38 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(372, 1);
					character.bestiaryController.forceUnlock(371);
					character.bestiaryController.forceUnlock(370);
					character.bestiaryController.forceUnlock(369);
					character.adventure.boss11Spawn.reset();
					lootDrop.zone38Drop(enemyList[38][3]);
					return;
				}
			}
			else if (character.adventure.titan11Version == 2 && autokillTitan11V3Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 38 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(371, 1);
					character.bestiaryController.forceUnlock(370);
					character.bestiaryController.forceUnlock(369);
					character.adventure.boss11Spawn.reset();
					lootDrop.zone38Drop(enemyList[38][2]);
					return;
				}
			}
			else if (character.adventure.titan11Version == 1 && autokillTitan11V2Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 38 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(370, 1);
					character.bestiaryController.forceUnlock(369);
					character.adventure.boss11Spawn.reset();
					lootDrop.zone38Drop(enemyList[38][1]);
					return;
				}
			}
			else if (character.adventure.titan11Version == 0 && autokillTitan11V1Achieved() && character.settings.autoKillTitans)
			{
				if (zone == 38 && currentEnemy != null)
				{
					wipeEnemy();
				}
				character.bestiaryController.addKills(369, 1);
				character.adventure.boss11Spawn.reset();
				lootDrop.zone38Drop(enemyList[38][0]);
				return;
			}
		}
		if (character.effectiveBossID() >= 850 && character.adventure.boss12Spawn.totalseconds >= (double)boss12SpawnTime() && character.adventure.titan12Unlocked)
		{
			if (character.adventure.titan12Version == 3 && autokillTitan12V4Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 42 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(376, 1);
					character.bestiaryController.forceUnlock(375);
					character.bestiaryController.forceUnlock(374);
					character.bestiaryController.forceUnlock(373);
					character.adventure.boss12Spawn.reset();
					lootDrop.zone42Drop(enemyList[42][3]);
					return;
				}
			}
			else if (character.adventure.titan12Version == 2 && autokillTitan12V3Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 42 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(375, 1);
					character.bestiaryController.forceUnlock(374);
					character.bestiaryController.forceUnlock(373);
					character.adventure.boss12Spawn.reset();
					lootDrop.zone42Drop(enemyList[42][2]);
					return;
				}
			}
			else if (character.adventure.titan12Version == 1 && autokillTitan12V2Achieved())
			{
				if (character.settings.autoKillTitans)
				{
					if (zone == 42 && currentEnemy != null)
					{
						wipeEnemy();
					}
					character.bestiaryController.addKills(374, 1);
					character.bestiaryController.forceUnlock(373);
					character.adventure.boss12Spawn.reset();
					lootDrop.zone42Drop(enemyList[42][1]);
					return;
				}
			}
			else if (character.adventure.titan12Version == 0 && autokillTitan12V1Achieved() && character.settings.autoKillTitans)
			{
				if (zone == 42 && currentEnemy != null)
				{
					wipeEnemy();
				}
				character.bestiaryController.addKills(373, 1);
				character.adventure.boss12Spawn.reset();
				lootDrop.zone42Drop(enemyList[42][0]);
				return;
			}
		}
		float num = character.totalAdvHPRegen() * Time.deltaTime - enemyAI.bleedDamage * Time.deltaTime;
		if (playerController.hyperRegenTime >= 0f)
		{
			num *= 5f;
		}
		if (zone == -1)
		{
			num *= 5f;
			if (character.inventory.itemList.GRBComplete)
			{
				num *= 2f;
			}
		}
		if (character.adventure.autoattacking)
		{
			num *= 1.2f;
		}
		if (enemyAI.auraID == 6)
		{
			num = 0f - (character.totalAdvHPRegen() * Time.deltaTime - enemyAI.bleedDamage * Time.deltaTime);
		}
		character.adventure.curHP += num;
		if (character.adventure.curHP >= character.totalAdvHP())
		{
			character.adventure.curHP = character.totalAdvHP();
		}
		if (currentEnemy != null)
		{
			float num2 = currentEnemy.regen * Time.deltaTime;
			if (enemyAI.auraID == 1)
			{
				num2 *= 5f;
			}
			currentEnemy.curHP += num2;
			if (currentEnemy.curHP >= currentEnemy.maxHP)
			{
				currentEnemy.curHP = currentEnemy.maxHP;
			}
		}
		if (zone == -1)
		{
			return;
		}
		if (!fightInProgress)
		{
			if (character.adventure.curHP < 0f)
			{
				character.adventure.curHP = 0f;
			}
			respawnTimer += Time.deltaTime;
			if (respawnTimer >= respawnTime())
			{
				if (!character.testMode() && zone == 6 && character.adventure.boss1Spawn.totalseconds < (double)boss1SpawnTime())
				{
					respawnTimer = 0f;
					return;
				}
				if (!character.testMode() && zone == 8 && character.adventure.boss2Spawn.totalseconds < (double)boss2SpawnTime())
				{
					respawnTimer = 0f;
					return;
				}
				if (!character.testMode() && zone == 11 && character.adventure.boss3Spawn.totalseconds < (double)boss3SpawnTime())
				{
					respawnTimer = 0f;
					return;
				}
				if (!character.testMode() && zone == 14 && character.adventure.boss4Spawn.totalseconds < (double)boss4SpawnTime())
				{
					respawnTimer = 0f;
					return;
				}
				if (!character.testMode() && zone == 16 && character.adventure.boss5Spawn.totalseconds < (double)boss5SpawnTime())
				{
					respawnTimer = 0f;
					return;
				}
				if (!character.testMode() && zone == 19 && character.adventure.boss6Spawn.totalseconds < (double)boss6SpawnTime())
				{
					respawnTimer = 0f;
					return;
				}
				if (!character.testMode() && zone == 23 && character.adventure.boss7Spawn.totalseconds < (double)boss7SpawnTime())
				{
					respawnTimer = 0f;
					return;
				}
				if (!character.testMode() && zone == 26 && character.adventure.boss8Spawn.totalseconds < (double)boss8SpawnTime())
				{
					respawnTimer = 0f;
					return;
				}
				if (!character.testMode() && zone == 30 && character.adventure.boss9Spawn.totalseconds < (double)boss9SpawnTime())
				{
					respawnTimer = 0f;
					return;
				}
				if (!character.testMode() && zone == 34 && character.adventure.boss10Spawn.totalseconds < (double)boss10SpawnTime())
				{
					respawnTimer = 0f;
					return;
				}
				if (!character.testMode() && zone == 38 && character.adventure.boss11Spawn.totalseconds < (double)boss11SpawnTime())
				{
					respawnTimer = 0f;
					return;
				}
				if (!character.testMode() && zone == 42 && character.adventure.boss12Spawn.totalseconds < (double)boss12SpawnTime())
				{
					respawnTimer = 0f;
					return;
				}
				if (!character.testMode() && zone == 44 && character.adventure.boss13Spawn.totalseconds < (double)boss13SpawnTime())
				{
					respawnTimer = 0f;
					return;
				}
				if (!character.testMode() && zone == 45 && character.adventure.boss14Spawn.totalseconds < (double)boss14SpawnTime())
				{
					respawnTimer = 0f;
					return;
				}
				currentEnemy = spawnEnemy(character.adventure.zone);
				updateEnemyPortrait();
				displayEnemyStats();
				respawnTimer = 0f;
				idleAttackTimer = 0f;
				fightInProgress = !fightInProgress;
			}
			return;
		}
		if (character.adventure.curHP <= 0f)
		{
			playerDeath();
			return;
		}
		if (currentEnemy.curHP <= 0f)
		{
			enemyDeath();
			return;
		}
		if (character.adventure.autoattacking && playerController.moveCheck())
		{
			if (enemyAI.auraID == 4)
			{
				idleAttackTimer += Time.deltaTime / 2f;
			}
			else
			{
				idleAttackTimer += Time.deltaTime;
			}
		}
		if (idleAttackTimer >= character.adventure.attackSpeed)
		{
			idleAttackTimer = 0f;
			playerController.idleAttack();
		}
		if (character.adventure.curHP <= 0f)
		{
			playerDeath();
		}
		else if (currentEnemy.curHP <= 0f)
		{
			enemyDeath();
		}
	}

	public void updateEnemy()
	{
		if (character.menuID != 3)
		{
			return;
		}
		if (currentEnemy != null)
		{
			if (currentEnemy.enemyType != enemyType.normal && currentEnemy.enemyType != enemyType.boss && currentEnemy.enemyType != enemyType.itopod && character.settings.specialAdvHpBars)
			{
				fiveBarDisplay();
				return;
			}
			regularBarDisplay();
			enemyHPText.text = format.suffixFormat(currentEnemy.curHP) + " HP";
		}
		else
		{
			enemyHPBar.value = 0f;
			enemyHPText.text = "No Enemy";
		}
	}

	public void updatePlayer()
	{
		if (character.menuID == 3)
		{
			playerHPBar.value = character.adventure.curHP / maxHP();
			playerHPText.text = format.suffixFormat(character.adventure.curHP) + " HP";
		}
	}

	public void updateTimer()
	{
		if (character.menuID != 3)
		{
			return;
		}
		TitanText.text = "";
		if (zone == 6)
		{
			if (character.adventure.boss1Spawn.totalseconds >= (double)boss1SpawnTime())
			{
				TitanText.text = "TITAN AVAILABLE!";
				TitanText.fontSize = 20;
			}
			else
			{
				TitanText.text = character.adventure.boss1Spawn.inverseDisplayColon(boss1SpawnTime());
				TitanText.fontSize = 20;
			}
		}
		else if (zone == 8)
		{
			if (character.adventure.boss2Spawn.totalseconds >= (double)boss2SpawnTime())
			{
				TitanText.text = "TITAN AVAILABLE!";
				TitanText.fontSize = 20;
			}
			else
			{
				TitanText.text = character.adventure.boss2Spawn.inverseDisplayColon(boss2SpawnTime());
				TitanText.fontSize = 20;
			}
		}
		else if (zone == 11)
		{
			if (character.adventure.boss3Spawn.totalseconds >= (double)boss3SpawnTime())
			{
				TitanText.text = "TITAN AVAILABLE!";
				TitanText.fontSize = 20;
			}
			else
			{
				TitanText.text = character.adventure.boss3Spawn.inverseDisplayColon(boss3SpawnTime());
				TitanText.fontSize = 20;
			}
		}
		else if (zone == 14)
		{
			if (character.adventure.boss4Spawn.totalseconds >= (double)boss4SpawnTime())
			{
				TitanText.text = "TITAN AVAILABLE!";
				TitanText.fontSize = 20;
			}
			else
			{
				TitanText.text = character.adventure.boss4Spawn.inverseDisplayColon(boss4SpawnTime());
				TitanText.fontSize = 20;
			}
		}
		else if (zone == 16)
		{
			if (character.adventure.waldoDefeats > character.adventure.waldoFinds)
			{
				TitanText.text = "WALDERP IS HIDING IN THE MENUS! FIND HIM!";
				TitanText.fontSize = 16;
			}
			else if (character.adventure.boss5Spawn.totalseconds >= (double)boss5SpawnTime())
			{
				TitanText.text = "TITAN AVAILABLE!";
				TitanText.fontSize = 20;
			}
			else
			{
				TitanText.text = character.adventure.boss5Spawn.inverseDisplayColon(boss5SpawnTime());
				TitanText.fontSize = 20;
			}
		}
		else if (zone == 19)
		{
			if (character.adventure.boss6Spawn.totalseconds >= (double)boss6SpawnTime())
			{
				TitanText.text = "TITAN AVAILABLE!";
				TitanText.fontSize = 20;
			}
			else
			{
				TitanText.text = character.adventure.boss6Spawn.inverseDisplayColon(boss6SpawnTime());
				TitanText.fontSize = 20;
			}
		}
		else if (zone == 23)
		{
			if (character.adventure.titan7questStarted && !character.adventure.titan7questComplete)
			{
				TitanText.text = "Type the code in the story!";
				TitanText.fontSize = 16;
			}
			else if (character.adventure.boss7Spawn.totalseconds >= (double)boss7SpawnTime())
			{
				TitanText.text = "TITAN AVAILABLE!";
				TitanText.fontSize = 20;
			}
			else
			{
				TitanText.text = character.adventure.boss7Spawn.inverseDisplayColon(boss7SpawnTime());
				TitanText.fontSize = 20;
			}
		}
		else if (zone == 26)
		{
			if (character.adventure.titan8questStarted && !character.adventure.titan8Unlocked && character.adventure.skeletonWhacked && character.adventure.icarusWhacked && character.adventure.kingCircleWhacked && character.adventure.emptyNameWhacked && character.adventure.robBossWhacked)
			{
				TitanText.text = character.adventure.boss8Spawn.inverseDisplayColon(boss8SpawnTime());
				TitanText.fontSize = 20;
			}
			else if (character.adventure.titan8questStarted && !character.adventure.titan8Unlocked)
			{
				TitanText.text = "Look at the Death Note!";
				TitanText.fontSize = 16;
			}
			else if (character.adventure.boss8Spawn.totalseconds >= (double)boss8SpawnTime())
			{
				TitanText.text = "TITAN AVAILABLE!";
				TitanText.fontSize = 20;
			}
			else
			{
				TitanText.text = character.adventure.boss8Spawn.inverseDisplayColon(boss8SpawnTime());
				TitanText.fontSize = 20;
			}
		}
		else if (zone == 30)
		{
			if (character.adventure.titan9questStarted && !character.adventure.titan9Unlocked)
			{
				TitanText.text = "Assemble the Exile";
				TitanText.fontSize = 16;
			}
			else if (character.adventure.boss9Spawn.totalseconds >= (double)boss9SpawnTime())
			{
				TitanText.text = "TITAN AVAILABLE!";
				TitanText.fontSize = 20;
			}
			else
			{
				TitanText.text = character.adventure.boss9Spawn.inverseDisplayColon(boss9SpawnTime());
				TitanText.fontSize = 20;
			}
		}
		else if (zone == 34)
		{
			if (character.adventure.boss10Spawn.totalseconds >= (double)boss10SpawnTime())
			{
				TitanText.text = "TITAN AVAILABLE!";
				TitanText.fontSize = 20;
			}
			else
			{
				TitanText.text = character.adventure.boss10Spawn.inverseDisplayColon(boss10SpawnTime());
				TitanText.fontSize = 20;
			}
		}
		else if (zone == 38)
		{
			if (character.adventure.boss11Spawn.totalseconds >= (double)boss11SpawnTime())
			{
				TitanText.text = "TITAN AVAILABLE!";
				TitanText.fontSize = 20;
			}
			else
			{
				TitanText.text = character.adventure.boss11Spawn.inverseDisplayColon(boss11SpawnTime());
				TitanText.fontSize = 20;
			}
		}
		else if (zone == 42)
		{
			if (character.adventure.boss12Spawn.totalseconds >= (double)boss12SpawnTime())
			{
				TitanText.text = "TITAN AVAILABLE!";
				TitanText.fontSize = 20;
			}
			else
			{
				TitanText.text = character.adventure.boss12Spawn.inverseDisplayColon(boss12SpawnTime());
				TitanText.fontSize = 20;
			}
		}
		else if (zone == 44)
		{
			if (character.adventure.boss13Spawn.totalseconds >= (double)boss13SpawnTime())
			{
				TitanText.text = "TITAN AVAILABLE!";
				TitanText.fontSize = 20;
			}
			else
			{
				TitanText.text = character.adventure.boss13Spawn.inverseDisplayColon(boss13SpawnTime());
				TitanText.fontSize = 20;
			}
		}
		else if (zone == 45)
		{
			if (character.adventure.boss14Spawn.totalseconds >= (double)boss14SpawnTime())
			{
				TitanText.text = "TITAN AVAILABLE!";
				TitanText.fontSize = 20;
			}
			else
			{
				TitanText.text = character.adventure.boss14Spawn.inverseDisplayColon(boss14SpawnTime());
				TitanText.fontSize = 20;
			}
		}
		else if (zone == 1000)
		{
			TitanText.text = "FLOOR " + itopodLevel + "\nKILLS: " + itopodKillCount;
			TitanText.fontSize = 20;
		}
	}

	public void updateAdventureStats()
	{
		if (character.menuID == 3)
		{
			playerStats.text = "<b>" + character.playerName.ToUpper() + "</b>\n\n";
			Text text = playerStats;
			text.text = text.text + "<b>Power:</b> " + format.suffixFormat(character.totalAdvAttack()) + "\n";
			Text text2 = playerStats;
			text2.text = text2.text + "<b>Toughness:</b> " + format.suffixFormat(character.totalAdvDefense()) + "\n";
			Text text3 = playerStats;
			text3.text = text3.text + "<b>Max HP:</b> " + format.suffixFormat(character.totalAdvHP()) + "\n";
			Text text4 = playerStats;
			text4.text = text4.text + "<b>HP Regen:</b> " + format.suffixFormat(character.totalAdvHPRegen()) + "/s\n";
		}
	}

	public void updateZone()
	{
		zoneTitle.text = zoneName(zone);
		zoneSubtitle.text = subtitleName(zone);
	}

	public string zoneName(int zoneID)
	{
		switch (zoneID)
		{
		case -1:
			return "Safe Zone: Awakening Site";
		case 0:
			return "Tutorial Zone";
		case 1:
			return "Sewers";
		case 2:
			return "Forest";
		case 3:
			return "Cave of Many Things";
		case 4:
			return "The Sky";
		case 5:
			return "High Security Base";
		case 6:
			return "Gordon Ramsay Bolton";
		case 7:
			return "Clock Dimension";
		case 8:
			return "Grand Corrupted Tree";
		case 9:
			return "The 2D Universe";
		case 10:
			return "Ancient Battlefield";
		case 11:
			return "Jake From Accounting";
		case 12:
			return "A Very Strange Place";
		case 13:
			return "Mega Lands";
		case 14:
			return "UUG THE UNMENTIONABLE";
		case 15:
			return "The Beardverse";
		case 16:
			return "WALDERP";
		case 17:
			return "Badly Drawn World";
		case 18:
			return "Boring-Ass Earth";
		case 19:
			return "THE BEAST";
		case 20:
			return "Chocolate World";
		case 21:
			return "The Evilverse";
		case 22:
			return "Pretty Pink Princess Land";
		case 23:
			return "GREASY NERD";
		case 24:
			return "Meta Land";
		case 25:
			return "Interdimensional Party";
		case 26:
			return "THE GODMOTHER";
		case 27:
			return "Typo Zonw";
		case 28:
			return "The Fad-Lands";
		case 29:
			return "JRPGVille";
		case 30:
			return "THE EXILE";
		case 31:
			return "The Rad-lands";
		case 32:
			return "Back To School";
		case 33:
			return "The West World";
		case 34:
			return "IT HUNGERS";
		case 35:
			return "The Breadverse";
		case 36:
			return "That 70's Zone";
		case 37:
			return "The Halloweenies";
		case 38:
			return "ROCK LOBSTER";
		case 39:
			return "Construction Zone";
		case 40:
			return "DUCK DUCK ZONE";
		case 41:
			return "The Nether Regions";
		case 42:
			return "AMALGAMATE";
		case 43:
			return "The Aethereal Sea";
		case 44:
			return "TIPPI THE TUTORIAL MOUSE";
		case 45:
			return "THE TRAITOR";
		case 1000:
			return "THE I.T.O.P.O.D";
		default:
			return "The 4G Broke the Game Zone";
		}
	}

	public string subtitleName(int zoneID)
	{
		switch (zoneID)
		{
		case -1:
			return "(How did you get here?)";
		case 0:
			return "(Learn the basics of kicking ass! Also, Hover over me for info!)";
		case 1:
			return "(The 2nd-most poo filled place in the universe.)";
		case 2:
			return "(Every idle game is contractually obligated to have such a generic zone.)";
		case 3:
			return "(There's a lot of weird crap in here.)";
		case 4:
			return "(Who knew so many things flew?)";
		case 5:
			return "(Is it that high-security if you managed to break in so easily?)";
		case 6:
			return "(Ah, Fresh meat!)";
		case 7:
			return "(Tick, tock, tick, tock.)";
		case 8:
			return "(It's big, it's heavy, it's wood!)";
		case 9:
			return "(Because a 3D Universe is boring tbh.)";
		case 10:
			return "(What happened here?)";
		case 11:
			return "(Not to be confused with Mark from Sales)";
		case 12:
			return "(Where the heck ARE you??)";
		case 13:
			return "(Honestly not the worst set of robot masters you've seen.)";
		case 14:
			return "(Shit. I just mentioned him.)";
		case 15:
			return "(You feel really inadequate right now.)";
		case 16:
			if (character.adventure.waldoDefeats > character.adventure.waldoFinds)
			{
				return "(Where did he go?)";
			}
			return "(This guy loves to hide.)";
		case 17:
			return "(Now you've got an actual mission!)";
		case 18:
			return "(What kind of lamewads live here?)";
		case 19:
			return "(This thing is really, REALLY hungry.)";
		case 20:
			return "(OM NOM NOM NOM NOM)";
		case 21:
			return "(So many mustaches!)";
		case 22:
			return "(I feel pretty, oh so pretty!)";
		case 23:
			return "(You can smell the B.O already.)";
		case 24:
			return "(Just next door to the Meat Lands!)";
		case 25:
			return "(Why didn't you grab it the first time you were here?)";
		case 26:
			return "(Bibbidy-Bobbidi-BOOM.)";
		case 27:
			return "(Where 4G's many, MANY typos live.)";
		case 28:
			return "(A Millenial's wet dream.)";
		case 29:
			return "(FIGHT ITEM MAGIC RUN)";
		case 30:
			return "(The not-forbidden-but-you-really-ought-not-associate-with One)";
		case 31:
			return "(Are you a rad enough dude to enter?)";
		case 32:
			return "(You need to get schooled about Sadistic Difficulty.)";
		case 33:
			return "(Surprisingly located in the East.)";
		case 34:
			return "(Eater of worlds, but picky when it comes to food.)";
		case 35:
			return "(It's amazing what worlds exist through the power of typos.)";
		case 36:
			return "(Do you remembah?)";
		case 37:
			return "(This place is giving you the creeps!)";
		case 38:
			return "(It wasn't a rock.)";
		case 39:
			return "(EYYY, I'M CONSTUCTIONING HERE!)";
		case 40:
			return "(QUACK QUACK QUACK)";
		case 41:
			return "(This place has a cool echo!)";
		case 42:
			return "(4 friends team up to fight the ultimate asshole: You!)";
		case 43:
			return "(All is lost... or is it?)";
		case 44:
			return "(That's one pissed off rat)";
		case 45:
			return "The final showdown.";
		case 1000:
			return "(How high can you climb?)";
		default:
			return "The 4G Broke the Game Zone";
		}
	}

	private void createEnemyTable()
	{
		List<Enemy> list = new List<Enemy>();
		list.Add(new Enemy("A Small Piece of Fluff", 1f, 7f, 6f, 1f, 40f, enemyType.normal, AI.normal, 1));
		list.Add(new Enemy("Floating Sewage", 1.2f, 7f, 6f, 1.5f, 45f, enemyType.normal, AI.normal, 2));
		list.Add(new Enemy("A Stick?", 1.5f, 8f, 7f, 0.5f, 55f, enemyType.normal, AI.normal, 3));
		list.Add(new Enemy("A SMALL MOUSE (BOSS)", 1f, 9f, 9f, 1f, 100f, enemyType.boss, AI.normal, 4));
		enemyList.Add(list);
		List<Enemy> list2 = new List<Enemy>();
		list2.Add(new Enemy("Small Mouse", 1f, 9f, 9f, 1f, 40f, enemyType.normal, AI.normal, 4));
		list2.Add(new Enemy("Slightly Bigger Mouse", 1.2f, 10f, 10f, 1.5f, 50f, enemyType.normal, AI.normal, 5));
		list2.Add(new Enemy("Big Rat", 1.5f, 11f, 11f, 0.5f, 70f, enemyType.normal, AI.normal, 6));
		list2.Add(new Enemy("BROWN SLIME (BOSS)", 1f, 13f, 13f, 1f, 150f, enemyType.boss, AI.poison, 7));
		enemyList.Add(list2);
		List<Enemy> list3 = new List<Enemy>();
		list3.Add(new Enemy("Skeleton", 1.1f, 26f, 29f, 3f, 400f, enemyType.normal, AI.normal, 8));
		list3.Add(new Enemy("Goblin", 0.9f, 30f, 29f, 1f, 420f, enemyType.normal, AI.rapid, 9));
		list3.Add(new Enemy("Giant", 1.3f, 30f, 35f, 1f, 500f, enemyType.normal, AI.charger, 14));
		list3.Add(new Enemy("Ent", 1.2f, 28f, 34f, 4f, 515f, enemyType.normal, AI.normal, 13));
		list3.Add(new Enemy("Zombie", 1.5f, 30f, 17f, 8f, 900f, enemyType.normal, AI.normal, 11));
		list3.Add(new Enemy("Orc", 1.2f, 31f, 31f, 2f, 450f, enemyType.normal, AI.normal, 10));
		list3.Add(new Enemy("R.O.U.S (BOSS)", 1.5f, 32f, 32f, 3f, 500f, enemyType.boss, AI.normal, 15));
		list3.Add(new Enemy("Fairy", 5f, 33f, 31f, 2f, 200f, enemyType.normal, AI.exploder, 16));
		list3.Add(new Enemy("GORGON (BOSS)", 1.25f, 33f, 33f, 2.5f, 600f, enemyType.boss, AI.paralyze, 17));
		enemyList.Add(list3);
		List<Enemy> list4 = new List<Enemy>();
		list4.Add(new Enemy("Gorgonzola", 1.3f, 114f, 113f, 8f, 1900f, enemyType.normal, AI.normal, 18));
		list4.Add(new Enemy("Brie", 1.3f, 110f, 117f, 10f, 1900f, enemyType.normal, AI.normal, 19));
		list4.Add(new Enemy("Gouda", 1.5f, 107f, 120f, 12f, 1940f, enemyType.normal, AI.normal, 20));
		list4.Add(new Enemy("Blue Cheese", 1.5f, 114f, 110f, 8f, 2050f, enemyType.normal, AI.poison, 21));
		list4.Add(new Enemy("Parmesan", 1.2f, 117f, 112f, 13f, 1900f, enemyType.normal, AI.normal, 22));
		list4.Add(new Enemy("Robot", 1f, 114f, 111f, 8f, 2080f, enemyType.normal, AI.charger, 25));
		list4.Add(new Enemy("Fluffy Chair", 1f, 115f, 110f, 10f, 2100f, enemyType.normal, AI.normal, 26));
		list4.Add(new Enemy("Couch", 1.5f, 119f, 114f, 12f, 1900f, enemyType.normal, AI.normal, 27));
		list4.Add(new Enemy("Floppy Mattress", 1.5f, 111f, 110f, 8f, 1810f, enemyType.normal, AI.poison, 28));
		list4.Add(new Enemy("Evil Fridge", 1.2f, 115f, 112f, 13f, 2000f, enemyType.normal, AI.normal, 29));
		list4.Add(new Enemy("T-800", 1.2f, 113f, 111f, 13f, 2130f, enemyType.normal, AI.rapid, 30));
		list4.Add(new Enemy("Wide Screen T.V", 1.2f, 112f, 110f, 13f, 1900f, enemyType.normal, AI.normal, 31));
		list4.Add(new Enemy("Kitchen Sink", 1.2f, 113f, 110f, 13f, 1900f, enemyType.normal, AI.rapid, 32));
		list4.Add(new Enemy("LIMBURGER (BOSS)", 1.2f, 110f, 110f, 15f, 2800f, enemyType.boss, AI.charger, 23));
		list4.Add(new Enemy("MEGA RAT (BOSS)", 1.2f, 120f, 119f, 16f, 2900f, enemyType.boss, AI.normal, 24));
		list4.Add(new Enemy("CHAD (BOSS)", 1.2f, 120f, 122f, 17f, 3000f, enemyType.boss, AI.charger, 37));
		enemyList.Add(list4);
		List<Enemy> list5 = new List<Enemy>();
		list5.Add(new Enemy("Kid On a Cloud", 1.3f, 300f, 323f, 20f, 4600f, enemyType.normal, AI.grower, 38));
		list5.Add(new Enemy("747", 1.3f, 350f, 310f, 20f, 4500f, enemyType.normal, AI.normal, 39));
		list5.Add(new Enemy("Oriental Dragon", 1f, 322f, 322f, 22f, 4440f, enemyType.normal, AI.charger, 40));
		list5.Add(new Enemy("Lester", 1.3f, 350f, 350f, 18f, 4550f, enemyType.normal, AI.poison, 41));
		list5.Add(new Enemy("Ninja Samurai", 1.3f, 350f, 342f, 13f, 4800f, enemyType.normal, AI.rapid, 42));
		list5.Add(new Enemy("Icarus Proudbottom", 9f, 340f, 320f, 10f, 4900f, enemyType.normal, AI.exploder, 43));
		list5.Add(new Enemy("Gigantic Flock of Seagulls", 1.3f, 340f, 317f, 20f, 5200f, enemyType.normal, AI.poison, 44));
		list5.Add(new Enemy("G.F.O.C.G (BOSS)", 1.3f, 365f, 360f, 23f, 8700f, enemyType.boss, AI.poison, 45));
		list5.Add(new Enemy("Two Headed Guy", 1.3f, 330f, 310f, 19f, 3500f, enemyType.normal, AI.normal, 46));
		list5.Add(new Enemy("BIRD PERSON (BOSS)", 1.3f, 340f, 340f, 25f, 9000f, enemyType.boss, AI.rapid, 47));
		enemyList.Add(list5);
		List<Enemy> list6 = new List<Enemy>();
		list6.Add(new Enemy("Hooloovoo", 1.3f, 400f, 403f, 40f, 6333f, enemyType.normal, AI.rapid, 49));
		list6.Add(new Enemy("Gross Green Alien", 1.3f, 400f, 410f, 30f, 6500f, enemyType.normal, AI.normal, 50));
		list6.Add(new Enemy("The Rat God", 1f, 412f, 422f, 32f, 6440f, enemyType.normal, AI.charger, 51));
		list6.Add(new Enemy("Massive Plant Monster", 1.3f, 390f, 451f, 28f, 6500f, enemyType.normal, AI.poison, 52));
		list6.Add(new Enemy("High Security Insect Guard 1", 1.3f, 420f, 402f, 23f, 6140f, enemyType.normal, AI.normal, 53));
		list6.Add(new Enemy("High Security Insect Guard 2", 1.2f, 426f, 404f, 20f, 6600f, enemyType.normal, AI.normal, 54));
		list6.Add(new Enemy("The Experiment", 1.1f, 416f, 410f, 20f, 6200f, enemyType.normal, AI.grower, 55));
		list6.Add(new Enemy("Whole Lotta Guards", 1.3f, 410f, 427f, 30f, 6300f, enemyType.normal, AI.normal, 56));
		list6.Add(new Enemy("MEGA GUARD (BOSS)", 1.3f, 435f, 440f, 33f, 11200f, enemyType.boss, AI.charger, 57));
		list6.Add(new Enemy("SPIKY HAIRED GUY (BOSS)", 1.3f, 440f, 440f, 35f, 12000f, enemyType.boss, AI.rapid, 58));
		enemyList.Add(list6);
		List<Enemy> list7 = new List<Enemy>();
		list7.Add(new Enemy("GORDON RAMSAY BOLTON", 2f, 666f, 666f, 66f, 300000f, enemyType.bigBoss1, AI.normal, 302));
		enemyList.Add(list7);
		List<Enemy> list8 = new List<Enemy>();
		list8.Add(new Enemy("Monday", 1.3f, 1641f, 1571f, 147f, 50000f, enemyType.normal, AI.charger, 59));
		list8.Add(new Enemy("Tuesday", 1.3f, 1641f, 1591f, 149f, 52000f, enemyType.normal, AI.normal, 60));
		list8.Add(new Enemy("Wednesday", 1.3f, 1611f, 1611f, 141f, 54000f, enemyType.normal, AI.normal, 61));
		list8.Add(new Enemy("Thursday", 1.3f, 1631f, 1631f, 143f, 56000f, enemyType.normal, AI.normal, 62));
		list8.Add(new Enemy("Friday", 1.3f, 1651f, 1651f, 145f, 58000f, enemyType.normal, AI.normal, 63));
		list8.Add(new Enemy("Saturday", 1.3f, 1671f, 1671f, 147f, 60000f, enemyType.normal, AI.normal, 64));
		list8.Add(new Enemy("Sunday", 1.3f, 1691f, 1691f, 149f, 62000f, enemyType.normal, AI.normal, 65));
		list8.Add(new Enemy("SUNDAE (BOSS)", 1.3f, 1700f, 1720f, 200f, 85000f, enemyType.boss, AI.normal, 66));
		list8.Add(new Enemy("SUNDAE (BOSS)", 1.3f, 1700f, 1720f, 200f, 85000f, enemyType.boss, AI.normal, 66));
		enemyList.Add(list8);
		List<Enemy> list9 = new List<Enemy>();
		list9.Add(new Enemy("GRAND CORRUPTED TREE", 2f, 2000f, 2000f, 200f, 750000f, enemyType.bigBoss2, AI.normal, 303));
		enemyList.Add(list9);
		List<Enemy> list10 = new List<Enemy>();
		list10.Add(new Enemy("A Flat Mouse", 1f, 3076f, 3071f, 307f, 100000f, enemyType.normal, AI.charger, 67));
		list10.Add(new Enemy("A Tiny Triangle", 1.1f, 3001f, 3091f, 309f, 101000f, enemyType.normal, AI.normal, 68));
		list10.Add(new Enemy("A Square Bear", 1.1f, 3065f, 3011f, 301f, 100000f, enemyType.normal, AI.normal, 69));
		list10.Add(new Enemy("The Pentagon", 1.2f, 3022f, 3031f, 303f, 105000f, enemyType.normal, AI.rapid, 70));
		list10.Add(new Enemy("The First Stop Sign", 1.2f, 3086f, 3071f, 307f, 108000f, enemyType.normal, AI.normal, 72));
		list10.Add(new Enemy("The Second Stop Sign", 1.2f, 3159f, 3091f, 309f, 100000f, enemyType.normal, AI.normal, 73));
		list10.Add(new Enemy("KING CIRCLE (BOSS)", 1.2f, 3041f, 3050f, 300f, 100000f, enemyType.boss, AI.normal, 74));
		list10.Add(new Enemy("SUPER HEXAGON (BOSS)", 1.2f, 3133f, 3133f, 303f, 133333f, enemyType.boss, AI.normal, 71));
		enemyList.Add(list10);
		List<Enemy> list11 = new List<Enemy>();
		list11.Add(new Enemy("Ghost Mice", 1f, 6300f, 7100f, 720f, 256000f, enemyType.normal, AI.charger, 75));
		list11.Add(new Enemy("Crasper, The Pissed Off Ghost", 1.1f, 6200f, 7100f, 719f, 250000f, enemyType.normal, AI.paralyze, 76));
		list11.Add(new Enemy("Living Armor", 1.1f, 6665f, 7200f, 721f, 250000f, enemyType.normal, AI.normal, 78));
		list11.Add(new Enemy("Living Armour", 1.2f, 6480f, 7400f, 723f, 255000f, enemyType.normal, AI.normal, 79));
		list11.Add(new Enemy("", 1.2f, 6500f, 7500f, 726f, 248000f, enemyType.normal, AI.poison, 80));
		list11.Add(new Enemy("The Pantheon of Fallen Gods", 1.2f, 6550f, 7550f, 729f, 260000f, enemyType.normal, AI.rapid, 81));
		list11.Add(new Enemy("GHOST DAD (BOSS)", 1.2f, 6600f, 7600f, 730f, 335000f, enemyType.boss, AI.normal, 77));
		list11.Add(new Enemy("MYSTERIOUS FIGURE (BOSS)", 1.2f, 6600f, 7600f, 782f, 332000f, enemyType.boss, AI.charger, 82));
		enemyList.Add(list11);
		List<Enemy> list12 = new List<Enemy>();
		list12.Add(new Enemy("JAKE FROM ACCOUNTING", 2f, 8000f, 8000f, 1000f, 3000000f, enemyType.bigBoss3, AI.normal, 304));
		enemyList.Add(list12);
		List<Enemy> list13 = new List<Enemy>();
		list13.Add(new Enemy("The Entire Alphabet Up a Coconut Tree", 1f, 16100f, 18100f, 1620f, 756000f, enemyType.normal, AI.rapid, 83));
		list13.Add(new Enemy("The Lummox", 1.1f, 16100f, 18100f, 1619f, 750000f, enemyType.normal, AI.paralyze, 84));
		list13.Add(new Enemy("A Metal Slime", 1.1f, 16000f, 18000f, 1621f, 750000f, enemyType.normal, AI.normal, 85));
		list13.Add(new Enemy("A Ginormous Sword", 1.2f, 16000f, 18100f, 1623f, 755000f, enemyType.normal, AI.charger, 86));
		list13.Add(new Enemy("An Ordinary Chicken", 1.2f, 16100f, 18100f, 1626f, 748000f, enemyType.normal, AI.normal, 89));
		list13.Add(new Enemy("743 Chickens", 1.2f, 16200f, 18100f, 1629f, 760000f, enemyType.normal, AI.rapid, 90));
		list13.Add(new Enemy("KENNY (BOSS)", 1.2f, 16300f, 18300f, 1660f, 950000f, enemyType.boss, AI.rapid, 87));
		list13.Add(new Enemy("VIC (BOSS)", 1.2f, 16300f, 18300f, 1682f, 1000000f, enemyType.boss, AI.charger, 88));
		enemyList.Add(list13);
		List<Enemy> list14 = new List<Enemy>();
		list14.Add(new Enemy("Broken VCR Man", 1f, 63500f, 63000f, 7620f, 3600000f, enemyType.normal, AI.rapid, 91));
		list14.Add(new Enemy("Kitten In a Mech Woman", 12f, 63500f, 63500f, 7619f, 3600000f, enemyType.normal, AI.exploder, 92));
		list14.Add(new Enemy("Mr Plow", 1.1f, 63700f, 63700f, 7621f, 3650000f, enemyType.normal, AI.normal, 93));
		list14.Add(new Enemy("ROBUTT (NOT A BOSS)", 1.2f, 63700f, 63100f, 7623f, 3700000f, enemyType.normal, AI.poison, 94));
		list14.Add(new Enemy("Former Canadian PM Stephen Harper", 1.2f, 63100f, 63100f, 7626f, 3750000f, enemyType.normal, AI.rapid, 95));
		list14.Add(new Enemy("A Cyberdemon", 1.2f, 63200f, 63100f, 7629f, 3800000f, enemyType.normal, AI.charger, 96));
		list14.Add(new Enemy("Robo Rat 9000", 1.2f, 63200f, 63100f, 7629f, 3850000f, enemyType.normal, AI.paralyze, 97));
		list14.Add(new Enemy("Butter-Passing Robot", 1.2f, 64200f, 63100f, 7629f, 3950000f, enemyType.normal, AI.normal, 98));
		list14.Add(new Enemy("DOCTOR WAHWEE (BOSS)", 1.2f, 64300f, 63300f, 7660f, 4200000f, enemyType.boss, AI.rapid, 100));
		list14.Add(new Enemy("DOCTOR WAHWEE (BOSS)", 1.2f, 64300f, 63300f, 7660f, 4200000f, enemyType.boss, AI.rapid, 100));
		enemyList.Add(list14);
		List<Enemy> list15 = new List<Enemy>();
		list15.Add(new Enemy("UUG THE UNMENTIONABLE", 2f, 200000f, 200000f, 30000f, 100000000f, enemyType.bigBoss4, AI.normal, 305));
		enemyList.Add(list15);
		List<Enemy> list16 = new List<Enemy>();
		list16.Add(new Enemy("A Bearded Lady", 1f, 740000f, 740000f, 74000f, 50000000f, enemyType.normal, AI.rapid, 101));
		list16.Add(new Enemy("A Bearded Man", 1f, 740000f, 740000f, 74000f, 50000000f, enemyType.normal, AI.charger, 102));
		list16.Add(new Enemy("Cousin Itt", 1.1f, 742000f, 742000f, 74200f, 51000000f, enemyType.normal, AI.normal, 103));
		list16.Add(new Enemy("A Naked Molerat", 1.2f, 744000f, 744000f, 74400f, 52000000f, enemyType.normal, AI.rapid, 104));
		list16.Add(new Enemy("Rob Boss", 12f, 746000f, 746000f, 74600f, 40000000f, enemyType.normal, AI.exploder, 105));
		list16.Add(new Enemy("Gossamer", 1.2f, 748000f, 748000f, 74800f, 53000000f, enemyType.normal, AI.paralyze, 107));
		list16.Add(new Enemy("ORANGE TOUPEE WITH FISTS (BOSS)", 1.2f, 750000f, 750000f, 75000f, 54000000f, enemyType.boss, AI.charger, 106));
		list16.Add(new Enemy("A CLOGGED SHOWER DRAIN (BOSS)", 1.2f, 750000f, 750000f, 75000f, 55000000f, enemyType.boss, AI.poison, 108));
		enemyList.Add(list16);
		List<Enemy> list17 = new List<Enemy>();
		list17.Add(new Enemy("WALDERP", 3.2f, 500000f, 300000f, 45000f, 150000000f, enemyType.waldo1, AI.normal, 306));
		list17.Add(new Enemy("WALDERP", 3.15f, 900000f, 600000f, 90000f, 300000000f, enemyType.waldo2, AI.normal, 307));
		list17.Add(new Enemy("WALDERP", 3.1f, 1500000f, 1000000f, 150000f, 600000000f, enemyType.waldo3, AI.normal, 308));
		list17.Add(new Enemy("WALDERP", 3.05f, 2200000f, 1500000f, 230000f, 800000000f, enemyType.waldo4, AI.normal, 309));
		list17.Add(new Enemy("WALDERP", 3f, 3000000f, 2000000f, 300000f, 1E+09f, enemyType.bigBoss5, AI.normal, 310));
		enemyList.Add(list17);
		List<Enemy> list18 = new List<Enemy>();
		list18.Add(new Enemy("Badly Drawn Dragon", 1f, 11000000f, 11000000f, 1100000f, 1E+09f, enemyType.normal, AI.normal, 109));
		list18.Add(new Enemy("Really Bad Sonic Fanart", 1f, 11200000f, 11200000f, 1102000f, 1E+09f, enemyType.normal, AI.charger, 110));
		list18.Add(new Enemy("Badly Drawn Schoolgirl", 1.1f, 11400000f, 11400000f, 1140000f, 1.01E+09f, enemyType.normal, AI.poison, 111));
		list18.Add(new Enemy("No Enemy(?)", 1.2f, 11600000f, 11600000f, 1160000f, 1.02E+09f, enemyType.normal, AI.rapid, 112));
		list18.Add(new Enemy("Really Bad MLP Fanart", 1.1f, 11800000f, 11800000f, 1180000f, 1.03E+09f, enemyType.normal, AI.grower, 113));
		list18.Add(new Enemy("Loss.png", 1.2f, 11000000f, 11000000f, 1100000f, 1.04E+09f, enemyType.normal, AI.paralyze, 114));
		list18.Add(new Enemy("EVIL SPIKY HAIRED GUY", 1.2f, 11200000f, 11200000f, 1120000f, 1.05E+09f, enemyType.boss, AI.rapid, 115));
		list18.Add(new Enemy("EVIL BADLY DRAWN KITTY", 1.2f, 11500000f, 11500000f, 1150000f, 1.06E+09f, enemyType.boss, AI.paralyze, 116));
		enemyList.Add(list18);
		List<Enemy> list19 = new List<Enemy>();
		list19.Add(new Enemy("The Eiffel Tower", 1f, 89000000f, 89000000f, 8900000f, 8.5E+09f, enemyType.normal, AI.normal, 117));
		list19.Add(new Enemy("A Mummy", 1f, 89000000f, 89000000f, 8900000f, 8.5E+09f, enemyType.normal, AI.charger, 118));
		list19.Add(new Enemy("A Daddy", 1.1f, 89200000f, 89200000f, 8920000f, 8.52E+09f, enemyType.normal, AI.poison, 119));
		list19.Add(new Enemy("Two Bananas In Pyjamas", 1.2f, 89400000f, 89400000f, 8940000f, 8.54E+09f, enemyType.normal, AI.rapid, 120));
		list19.Add(new Enemy("Giant Raisins From California", 1.1f, 89600000f, 89600000f, 8960000f, 8.56E+09f, enemyType.normal, AI.grower, 121));
		list19.Add(new Enemy("An Annoying Penguin", 1.2f, 89800000f, 89800000f, 8980000f, 8.58E+09f, enemyType.normal, AI.paralyze, 122));
		list19.Add(new Enemy("An Army of Annoying Penguins", 1.2f, 90000000f, 90000000f, 9000000f, 8.6E+09f, enemyType.normal, AI.rapid, 123));
		list19.Add(new Enemy("THE ELUSIVE C.S (BOSS)", 1.2f, 90000000f, 90000000f, 9000000f, 8.6E+09f, enemyType.boss, AI.poison, 124));
		list19.Add(new Enemy("THE ELUSIVE C.S (BOSS)", 1.2f, 90000000f, 90000000f, 9000000f, 8.6E+09f, enemyType.boss, AI.paralyze, 124));
		enemyList.Add(list19);
		List<Enemy> list20 = new List<Enemy>();
		list20.Add(new Enemy("SKELETON GUARDIAN", 3f, 30000000f, 30000000f, 3000000f, 3E+09f, enemyType.guardian, AI.normal, 311));
		list20.Add(new Enemy("THE BEAST V1", 2.1f, 500000000f, 500000000f, 50000000f, 5E+10f, enemyType.bigBoss6V1, AI.normal, 312));
		list20.Add(new Enemy("THE BEAST V2", 2f, 5E+09f, 5E+09f, 500000000f, 5E+11f, enemyType.bigBoss6V2, AI.normal, 313));
		list20.Add(new Enemy("THE BEAST V3", 1.9f, 5E+10f, 5E+10f, 5E+09f, 5E+12f, enemyType.bigBoss6V3, AI.normal, 314));
		list20.Add(new Enemy("THE BEAST V4", 1.8f, 5E+11f, 5E+11f, 5E+10f, 5E+13f, enemyType.bigBoss6V4, AI.normal, 315));
		enemyList.Add(list20);
		List<Enemy> list21 = new List<Enemy>();
		list21.Add(new Enemy("Chocolate Mouse", 1f, 3E+10f, 3E+10f, 3E+09f, 3E+12f, enemyType.normal, AI.normal, 125));
		list21.Add(new Enemy("Chocolate Mimic", 1f, 3.01E+10f, 3.01E+10f, 3.01E+09f, 3.05E+12f, enemyType.normal, AI.rapid, 126));
		list21.Add(new Enemy("Chocolate Crowbar", 1.1f, 3.01E+10f, 3.01E+10f, 3.01E+09f, 3.05E+12f, enemyType.normal, AI.poison, 127));
		list21.Add(new Enemy("Choco-Freeman", 1.2f, 3.02E+10f, 3.02E+10f, 3.02E+09f, 3.1E+12f, enemyType.normal, AI.rapid, 128));
		list21.Add(new Enemy("Chocolate Fondue", 12f, 3.02E+10f, 3.02E+10f, 3.02E+09f, 3.1E+12f, enemyType.normal, AI.exploder, 129));
		list21.Add(new Enemy("Chocolate Slime", 1.2f, 3.03E+10f, 3.03E+10f, 3.03E+09f, 3.15E+12f, enemyType.normal, AI.poison, 130));
		list21.Add(new Enemy("Dark Chocolate", 1.2f, 3.03E+10f, 3.03E+10f, 3.03E+09f, 3.15E+12f, enemyType.normal, AI.rapid, 131));
		list21.Add(new Enemy("Chocolate Salty Balls", 1.2f, 3.03E+10f, 3.03E+10f, 3.03E+09f, 3.15E+12f, enemyType.normal, AI.rapid, 132));
		list21.Add(new Enemy("Screaming Chocolate Fish", 1.2f, 3.03E+10f, 3.03E+10f, 3.03E+09f, 3.15E+12f, enemyType.normal, AI.rapid, 133));
		list21.Add(new Enemy("A Mighty Lump of Poo", 1.2f, 3.03E+10f, 3.03E+10f, 3.03E+09f, 3.15E+12f, enemyType.normal, AI.rapid, 134));
		list21.Add(new Enemy("MELTED CHOCOLATE BLOB (BOSS)", 1.2f, 3.05E+10f, 3.05E+10f, 3.05E+09f, 3.25E+12f, enemyType.boss, AI.grower, 135));
		list21.Add(new Enemy("CHOCO GIANT (BOSS)", 1.2f, 3.05E+10f, 3.05E+10f, 3.05E+09f, 3.25E+12f, enemyType.boss, AI.rapid, 136));
		list21.Add(new Enemy("TYPE 2 DIABETES (BOSS)", 1.2f, 3.05E+10f, 3.05E+10f, 3.05E+09f, 3.25E+12f, enemyType.boss, AI.charger, 137));
		enemyList.Add(list21);
		List<Enemy> list22 = new List<Enemy>();
		list22.Add(new Enemy("Evil Mouse", 1f, 5E+12f, 5E+12f, 5E+11f, 5E+14f, enemyType.normal, AI.normal, 316));
		list22.Add(new Enemy("Evil Goblin", 1f, 5.01E+12f, 5.01E+12f, 5.01E+11f, 5.05E+14f, enemyType.normal, AI.rapid, 317));
		list22.Add(new Enemy("Evil Gorgon", 1.1f, 5.01E+12f, 5.01E+12f, 5.01E+11f, 5.05E+14f, enemyType.normal, AI.poison, 318));
		list22.Add(new Enemy("Evil Mole", 1.2f, 5.02E+12f, 5.02E+12f, 5.02E+11f, 5.1E+14f, enemyType.normal, AI.rapid, 319));
		list22.Add(new Enemy("Evil Icarus Proudbottom", 12f, 5.02E+12f, 5.02E+12f, 5.02E+11f, 5.1E+14f, enemyType.normal, AI.exploder, 320));
		list22.Add(new Enemy("Evil Brown Slime", 1.2f, 5.03E+12f, 5.03E+12f, 5.03E+11f, 5.15E+14f, enemyType.normal, AI.poison, 321));
		list22.Add(new Enemy("Flock of Canada Geese", 1.2f, 5.03E+12f, 5.03E+12f, 5.03E+11f, 5.15E+14f, enemyType.normal, AI.rapid, 322));
		list22.Add(new Enemy("EVIL SPIKY HAIRED GUY (BOSS)", 1.2f, 5.05E+12f, 5.05E+12f, 5.05E+11f, 5.25E+14f, enemyType.boss, AI.rapid, 323));
		list22.Add(new Enemy("EVIL CHAD(BOSS)", 1.2f, 5.05E+12f, 5.05E+12f, 5.05E+11f, 5.25E+14f, enemyType.boss, AI.charger, 324));
		enemyList.Add(list22);
		List<Enemy> list23 = new List<Enemy>();
		list23.Add(new Enemy("The Humkeycorn", 1f, 2.5E+13f, 2.5E+13f, 2.5E+12f, 2.5E+15f, enemyType.normal, AI.normal, 325));
		list23.Add(new Enemy("Pooky The Bunny", 1f, 2.51E+13f, 2.51E+13f, 2.51E+12f, 2.55E+15f, enemyType.normal, AI.rapid, 326));
		list23.Add(new Enemy("'The More You Know' Star", 1.1f, 2.51E+13f, 2.51E+13f, 2.51E+12f, 2.55E+15f, enemyType.normal, AI.charger, 327));
		list23.Add(new Enemy("A Fabulous Leprechaun", 1.2f, 2.52E+13f, 2.52E+13f, 2.52E+12f, 2.6E+15f, enemyType.normal, AI.grower, 328));
		list23.Add(new Enemy("An Ordinary Possum", 1.2f, 2.52E+13f, 2.52E+13f, 2.52E+12f, 2.6E+15f, enemyType.normal, AI.poison, 329));
		list23.Add(new Enemy("Barry, the Beer Fairy", 12f, 2.53E+13f, 2.53E+13f, 2.53E+12f, 2.65E+15f, enemyType.normal, AI.exploder, 330));
		list23.Add(new Enemy("AN ASSHOLE SWAN (BOSS)", 1.2f, 2.53E+13f, 2.53E+13f, 2.53E+12f, 2.65E+15f, enemyType.boss, AI.rapid, 331));
		list23.Add(new Enemy("TINKLES (BOSS)", 1.2f, 2.55E+13f, 2.55E+13f, 2.55E+12f, 2.7E+15f, enemyType.boss, AI.charger, 332));
		enemyList.Add(list23);
		List<Enemy> list24 = new List<Enemy>();
		list24.Add(new Enemy("GREASY NERD'S MOM", 3f, 6E+13f, 6E+13f, 6E+12f, 6E+15f, enemyType.boss7Guardian, AI.normal, 333));
		list24.Add(new Enemy("GREASY NERD V1", 2.1f, 1E+14f, 1E+14f, 1E+13f, 1E+16f, enemyType.bigBoss7V1, AI.normal, 334));
		list24.Add(new Enemy("GREASY NERD V2", 2f, 2E+15f, 2E+15f, 2E+14f, 2E+17f, enemyType.bigBoss7V2, AI.normal, 335));
		list24.Add(new Enemy("GREASY NERD V3", 1.9f, 4E+16f, 4E+16f, 4E+15f, 4E+18f, enemyType.bigBoss7V3, AI.normal, 336));
		list24.Add(new Enemy("GREASY NERD V4", 1.8f, 1E+18f, 1E+18f, 1E+17f, 1E+20f, enemyType.bigBoss7V4, AI.normal, 337));
		enemyList.Add(list24);
		List<Enemy> list25 = new List<Enemy>();
		list25.Add(new Enemy("A Half-eaten Cookie", 1f, 1E+16f, 1E+16f, 1E+15f, 1E+18f, enemyType.normal, AI.normal, 151));
		list25.Add(new Enemy("A Rusty Crank", 1f, 1.02E+16f, 1.02E+16f, 1.02E+15f, 1.05E+18f, enemyType.normal, AI.poison, 152));
		list25.Add(new Enemy("Ahh!! A Shark!!", 1.1f, 1.04E+16f, 1.04E+16f, 1.04E+15f, 1.1E+18f, enemyType.normal, AI.charger, 153));
		list25.Add(new Enemy("The number 1.8 x 10^308", 1.2f, 1.06E+16f, 1.06E+16f, 1.06E+15f, 1.15E+18f, enemyType.normal, AI.normal, 154));
		list25.Add(new Enemy("A Weird Goblin-Demon-Thing", 1.2f, 1.08E+16f, 1.08E+16f, 1.08E+15f, 1.2E+18f, enemyType.normal, AI.rapid, 155));
		list25.Add(new Enemy("A Cute Kitten", 12f, 1.1E+16f, 1.1E+16f, 1.1E+15f, 1.2E+18f, enemyType.normal, AI.exploder, 156));
		list25.Add(new Enemy("THE DRAGON OF WISDOM (BOSS)", 1.2f, 1.12E+16f, 1.12E+16f, 1.12E+15f, 1.25E+18f, enemyType.boss, AI.grower, 157));
		list25.Add(new Enemy("THE DRAGON OF DILDO (BOSS)", 1.2f, 1.15E+16f, 1.15E+16f, 1.15E+15f, 1.25E+18f, enemyType.boss, AI.grower, 158));
		enemyList.Add(list25);
		List<Enemy> list26 = new List<Enemy>();
		list26.Add(new Enemy("The Bouncer, Part 2", 1f, 1E+17f, 1E+17f, 1E+16f, 1.1E+19f, enemyType.normal, AI.normal, 159));
		list26.Add(new Enemy("Jambi", 1f, 1.02E+17f, 1.02E+17f, 1.02E+16f, 1.1E+19f, enemyType.normal, AI.rapid, 160));
		list26.Add(new Enemy("God of Thunder", 1.1f, 1.04E+17f, 1.04E+17f, 1.04E+16f, 1.15E+19f, enemyType.normal, AI.charger, 161));
		list26.Add(new Enemy("The Entire State of South Dakota", 1.2f, 1.06E+17f, 1.06E+17f, 1.06E+16f, 1.15E+19f, enemyType.normal, AI.normal, 162));
		list26.Add(new Enemy("A Huge Stack of Pogs", 1.2f, 1.08E+17f, 1.08E+17f, 1.08E+16f, 1.2E+19f, enemyType.normal, AI.poison, 163));
		list26.Add(new Enemy("Three Guys Shouting out 'Ed'", 12f, 1.1E+17f, 1.1E+17f, 1.1E+16f, 1.2E+19f, enemyType.normal, AI.exploder, 164));
		list26.Add(new Enemy("'MR CHOW' (BOSS)", 1.2f, 1.12E+17f, 1.12E+17f, 1.12E+16f, 1.25E+19f, enemyType.boss, AI.normal, 165));
		list26.Add(new Enemy("THE LIFE OF THE PARTY (BOSS)", 1.2f, 1.15E+17f, 1.15E+17f, 1.15E+16f, 1.25E+19f, enemyType.boss, AI.grower, 166));
		enemyList.Add(list26);
		List<Enemy> list27 = new List<Enemy>();
		list27.Add(new Enemy("The Consigliere", 2f, 6E+17f, 6E+17f, 6E+16f, 6E+19f, enemyType.boss8Guardian, AI.normal, 338));
		list27.Add(new Enemy("The Godmother V1", 2.1f, 1E+18f, 1E+18f, 1E+17f, 1E+20f, enemyType.bigBoss8V1, AI.normal, 339));
		list27.Add(new Enemy("The Godmother V2", 2f, 2E+19f, 2E+19f, 2E+18f, 2E+21f, enemyType.bigBoss8V2, AI.normal, 340));
		list27.Add(new Enemy("The Godmother V3", 1.9f, 4E+20f, 4E+20f, 4E+19f, 4E+22f, enemyType.bigBoss8V3, AI.normal, 341));
		list27.Add(new Enemy("The Godmother V4", 1.8f, 1E+22f, 1E+22f, 1E+21f, 1E+24f, enemyType.bigBoss8V4, AI.normal, 342));
		enemyList.Add(list27);
		List<Enemy> list28 = new List<Enemy>();
		list28.Add(new Enemy("Permanenet", 1f, 8E+19f, 8E+19f, 8E+18f, 8.1E+21f, enemyType.normal, AI.normal, 167));
		list28.Add(new Enemy("Coudl", 1f, 8.02E+19f, 8.02E+19f, 8.02E+18f, 8.1E+21f, enemyType.normal, AI.rapid, 168));
		list28.Add(new Enemy("Liek", 1.1f, 8.04E+19f, 8.04E+19f, 8.04E+18f, 8.15E+21f, enemyType.normal, AI.charger, 169));
		list28.Add(new Enemy("Blodo", 1.2f, 8.08E+19f, 8.08E+19f, 8.08E+18f, 8.2E+21f, enemyType.normal, AI.poison, 170));
		list28.Add(new Enemy("Brian", 1.2f, 8.06E+19f, 8.06E+19f, 8.06E+18f, 8.15E+21f, enemyType.normal, AI.normal, 171));
		list28.Add(new Enemy("Odign", 0.8f, 8.1E+19f, 8.1E+19f, 8.1E+18f, 8.2E+21f, enemyType.normal, AI.rapid, 172));
		list28.Add(new Enemy("HORUS (BOSS)", 1.2f, 8.12E+19f, 8.12E+19f, 8.12E+18f, 8.25E+21f, enemyType.boss, AI.normal, 173));
		list28.Add(new Enemy("ELDER TYPO GOD, ELXU (BOSS)", 1.2f, 8.15E+19f, 8.15E+19f, 8.15E+18f, 8.25E+21f, enemyType.boss, AI.grower, 174));
		enemyList.Add(list28);
		List<Enemy> list29 = new List<Enemy>();
		list29.Add(new Enemy("A Very Sad Slinky :c", 1f, 4E+20f, 4E+20f, 4E+19f, 4.1E+22f, enemyType.normal, AI.normal, 175));
		list29.Add(new Enemy("Giant Metal Spinning Top", 1f, 4.02E+20f, 4.02E+20f, 4.02E+19f, 4.1E+22f, enemyType.normal, AI.rapid, 176));
		list29.Add(new Enemy("A Stack of Krazy Bonez", 1.1f, 4.04E+20f, 4.04E+20f, 4.04E+19f, 4.15E+22f, enemyType.normal, AI.charger, 177));
		list29.Add(new Enemy("Rare Foil Pokeyman Card", 1.2f, 4.06E+20f, 4.06E+20f, 4.06E+19f, 4.15E+22f, enemyType.normal, AI.normal, 178));
		list29.Add(new Enemy("A Busted Gameboy", 1.2f, 4.08E+20f, 4.08E+20f, 4.08E+19f, 4.2E+22f, enemyType.normal, AI.poison, 179));
		list29.Add(new Enemy("A Worthless Bean-y Baby", 0.8f, 4.1E+20f, 4.1E+20f, 4.1E+19f, 4.2E+22f, enemyType.normal, AI.rapid, 180));
		list29.Add(new Enemy("THE SLAMMER (BOSS)", 1.2f, 4.12E+20f, 4.12E+20f, 4.12E+19f, 4.25E+22f, enemyType.boss, AI.charger, 181));
		list29.Add(new Enemy("DEMONIC FLURBIE (BOSS)", 1.2f, 4.15E+20f, 4.15E+20f, 4.15E+19f, 4.25E+22f, enemyType.boss, AI.grower, 182));
		enemyList.Add(list29);
		List<Enemy> list30 = new List<Enemy>();
		list30.Add(new Enemy("Sentient Pile of Belts", 1f, 2E+21f, 2E+21f, 2E+20f, 2.1E+23f, enemyType.normal, AI.normal, 183));
		list30.Add(new Enemy("Mimic 'Mimic Chest' Chest", 1f, 2.02E+21f, 2.02E+21f, 2.02E+20f, 2.1E+23f, enemyType.normal, AI.paralyze, 184));
		list30.Add(new Enemy("A Suplexing Train", 1.1f, 2.04E+21f, 2.04E+21f, 2.04E+20f, 2.15E+23f, enemyType.normal, AI.charger, 185));
		list30.Add(new Enemy("The Annoying Fan", 1.2f, 2.06E+21f, 2.06E+21f, 2.06E+20f, 2.15E+23f, enemyType.normal, AI.normal, 186));
		list30.Add(new Enemy("The Infinity+1 Sword", 1.2f, 2.08E+21f, 2.08E+21f, 2.08E+20f, 2.2E+23f, enemyType.normal, AI.poison, 187));
		list30.Add(new Enemy("The Damage Cap", 1.1f, 2.1E+21f, 2.1E+21f, 2.1E+20f, 2.2E+23f, enemyType.normal, AI.grower, 188));
		list30.Add(new Enemy("FINAL (BOSS)", 1.2f, 2.12E+21f, 2.12E+21f, 2.12E+20f, 2.25E+23f, enemyType.boss, AI.normal, 189));
		list30.Add(new Enemy("TRUE FINAL (BOSS)", 1.2f, 2.15E+21f, 2.15E+21f, 2.15E+20f, 2.25E+23f, enemyType.boss, AI.grower, 190));
		enemyList.Add(list30);
		List<Enemy> list31 = new List<Enemy>();
		list31.Add(new Enemy("PRIEST OF EXILE", 2f, 6E+21f, 6E+21f, 6E+20f, 6E+23f, enemyType.boss9Guardian, AI.normal, 343));
		list31.Add(new Enemy("EXILE V1", 2.1f, 2E+22f, 2E+22f, 2E+21f, 2E+24f, enemyType.bigBoss9V1, AI.normal, 344));
		list31.Add(new Enemy("EXILE V2", 2f, 4E+23f, 4E+23f, 2E+22f, 2E+25f, enemyType.bigBoss9V2, AI.normal, 345));
		list31.Add(new Enemy("EXILE V3", 1.9f, 8E+24f, 8E+24f, 4E+23f, 4E+26f, enemyType.bigBoss9V3, AI.normal, 346));
		list31.Add(new Enemy("EXILE V4", 1.8f, 1.5E+26f, 1.5E+26f, 1.5E+25f, 1.5E+28f, enemyType.bigBoss9V4, AI.normal, 347));
		enemyList.Add(list31);
		List<Enemy> list32 = new List<Enemy>();
		list32.Add(new Enemy("Small Bart", 1f, 2E+24f, 2E+24f, 2E+23f, 2.1E+26f, enemyType.normal, AI.normal, 191));
		list32.Add(new Enemy("Pair of Shades Wearing Shades", 1f, 2.02E+24f, 2.02E+24f, 2.02E+23f, 2.1E+26f, enemyType.normal, AI.paralyze, 197));
		list32.Add(new Enemy("A.C SKATER (BOSS)", 1f, 2E+24f, 2E+24f, 2E+23f, 2.1E+26f, enemyType.boss, AI.normal, 193));
		list32.Add(new Enemy("Lame Security Guard", 1f, 2E+24f, 2E+24f, 2E+23f, 2.1E+26f, enemyType.normal, AI.normal, 194));
		list32.Add(new Enemy("A Giant Vat of Plutonium-238", 1.1f, 2.04E+24f, 2.04E+24f, 2.04E+23f, 2.15E+26f, enemyType.normal, AI.charger, 195));
		list32.Add(new Enemy("Mutant Zombie Marie Curie", 1.2f, 2.06E+24f, 2.06E+24f, 2.06E+23f, 2.15E+26f, enemyType.normal, AI.normal, 196));
		list32.Add(new Enemy("Nuclear Power Pants", 1.2f, 2.08E+24f, 2.08E+24f, 2.08E+23f, 2.2E+26f, enemyType.normal, AI.poison, 192));
		list32.Add(new Enemy("A Wandering Gamma Ray", 1f, 2.1E+24f, 2.1E+24f, 2.1E+23f, 2.2E+26f, enemyType.normal, AI.grower, 198));
		list32.Add(new Enemy("A Massive Sealed Vault", 1.2f, 2.12E+24f, 2.12E+24f, 2.12E+23f, 2.25E+26f, enemyType.normal, AI.normal, 199));
		list32.Add(new Enemy("RADIOACTIVE MACGUFFIN (BOSS)", 1.2f, 2.15E+24f, 2.15E+24f, 2.15E+23f, 2.25E+26f, enemyType.boss, AI.grower, 200));
		enemyList.Add(list32);
		List<Enemy> list33 = new List<Enemy>();
		list33.Add(new Enemy("A Different Greasy Nerd", 1f, 3E+26f, 3E+26f, 3E+25f, 3.1E+28f, enemyType.normal, AI.normal, 348));
		list33.Add(new Enemy("Sentient Jock Strap", 1f, 3.02E+26f, 3.02E+26f, 3.02E+25f, 3.1E+28f, enemyType.normal, AI.paralyze, 349));
		list33.Add(new Enemy("The Flying Spinelli Monster", 1.1f, 3.04E+26f, 3.04E+26f, 3.04E+25f, 3.15E+28f, enemyType.normal, AI.charger, 350));
		list33.Add(new Enemy("A Really Strict Nun", 1.2f, 3.06E+26f, 3.06E+26f, 3.06E+25f, 3.15E+28f, enemyType.normal, AI.normal, 351));
		list33.Add(new Enemy("The Nun's Ruler", 1.2f, 3.08E+26f, 3.08E+26f, 3.08E+25f, 3.2E+28f, enemyType.normal, AI.poison, 352));
		list33.Add(new Enemy("The Mystery Meat", 1.1f, 3.1E+26f, 3.1E+26f, 3.1E+25f, 3.2E+28f, enemyType.normal, AI.grower, 353));
		list33.Add(new Enemy("WILLY (BOSS)", 1.2f, 3.12E+26f, 3.12E+26f, 3.12E+25f, 3.25E+28f, enemyType.boss, AI.normal, 354));
		list33.Add(new Enemy("BELDING (BOSS)", 1.2f, 3.15E+26f, 3.15E+26f, 3.15E+25f, 3.25E+28f, enemyType.boss, AI.grower, 355));
		enemyList.Add(list33);
		List<Enemy> list34 = new List<Enemy>();
		list34.Add(new Enemy("A Stickman Cowboy", 1f, 1.5E+27f, 1.5E+27f, 1.5E+26f, 1.5E+29f, enemyType.normal, AI.normal, 356));
		list34.Add(new Enemy("A Giant Cannon", 1f, 1.52E+27f, 1.52E+27f, 1.52E+26f, 1.5E+29f, enemyType.normal, AI.paralyze, 357));
		list34.Add(new Enemy("The Entire Bar", 1.1f, 1.54E+27f, 1.54E+27f, 1.54E+26f, 1.55E+29f, enemyType.normal, AI.rapid, 358));
		list34.Add(new Enemy("A Pathetic Tumbleweed", 1.2f, 1.56E+27f, 1.56E+27f, 1.56E+26f, 1.55E+29f, enemyType.normal, AI.poison, 359));
		list34.Add(new Enemy("A Single Cow", 1.2f, 1.58E+27f, 1.58E+27f, 1.58E+26f, 1.6E+29f, enemyType.normal, AI.charger, 360));
		list34.Add(new Enemy("Herd of Pissed Off Cows", 1.1f, 1.6E+27f, 1.6E+27f, 1.6E+26f, 1.6E+29f, enemyType.normal, AI.grower, 361));
		list34.Add(new Enemy("THE OUTLAW (BOSS)", 1.2f, 1.62E+27f, 1.62E+27f, 1.62E+26f, 1.65E+29f, enemyType.boss, AI.normal, 362));
		list34.Add(new Enemy("THE SHERIFF (BOSS)", 1.2f, 1.65E+27f, 1.65E+27f, 1.65E+26f, 1.65E+29f, enemyType.boss, AI.grower, 363));
		enemyList.Add(list34);
		List<Enemy> list35 = new List<Enemy>();
		list35.Add(new Enemy("Small Piece of Fluff", 2.1f, 1E+28f, 2E+28f, 2E+27f, 5E+29f, enemyType.boss10Guardian, AI.normal, 364));
		list35.Add(new Enemy("IT HUNGERS V1", 2.1f, 1E+28f, 2E+28f, 2E+27f, 5E+29f, enemyType.bigBoss10V1, AI.normal, 365));
		list35.Add(new Enemy("IT HUNGERS V2", 1.9f, 8E+28f, 1.6E+29f, 1.6E+28f, 4E+30f, enemyType.bigBoss10V2, AI.normal, 366));
		list35.Add(new Enemy("IT HUNGERS V3", 1.7f, 5E+29f, 1E+30f, 1E+29f, 2.5E+31f, enemyType.bigBoss10V3, AI.normal, 367));
		list35.Add(new Enemy("IT HUNGERS V4", 1.5f, 2.5E+30f, 5E+30f, 5E+29f, 1.25E+32f, enemyType.bigBoss10V4, AI.normal, 368));
		enemyList.Add(list35);
		List<Enemy> list36 = new List<Enemy>();
		list36.Add(new Enemy("Grandma's 'Brownies'", 1f, 1E+29f, 1.2E+29f, 1.2E+28f, 5.5E+30f, enemyType.normal, AI.normal, 201));
		list36.Add(new Enemy("Angry Raw Cookie Dough", 1f, 1.02E+29f, 1.22E+29f, 1.22E+28f, 5.4E+30f, enemyType.normal, AI.paralyze, 202));
		list36.Add(new Enemy("A Bearded Breaded Braid", 1f, 1E+29f, 1.2E+29f, 1.2E+28f, 5.6E+30f, enemyType.normal, AI.normal, 203));
		list36.Add(new Enemy("Butcher & Candlestick Maker", 1f, 1E+29f, 1.2E+29f, 1.2E+28f, 5.7E+30f, enemyType.normal, AI.normal, 204));
		list36.Add(new Enemy("The Ex-Greatest Thing", 1.1f, 1.04E+29f, 1.24E+29f, 1.24E+28f, 5.8E+30f, enemyType.normal, AI.charger, 205));
		list36.Add(new Enemy("Moldy Slice Of Bread", 1.2f, 1.06E+29f, 1.26E+29f, 1.26E+28f, 5.9E+30f, enemyType.normal, AI.normal, 206));
		list36.Add(new Enemy("THE YEAST BEAST (BOSS)", 1.2f, 1.08E+29f, 1.28E+29f, 1.28E+28f, 6E+30f, enemyType.boss, AI.poison, 207));
		list36.Add(new Enemy("A DAY-OLD BAGUETTE (BOSS)", 1.2f, 1.1E+29f, 1.3E+29f, 1.35E+28f, 6E+30f, enemyType.boss, AI.grower, 208));
		enemyList.Add(list36);
		List<Enemy> list37 = new List<Enemy>();
		list37.Add(new Enemy("A Groovy Saxophone", 1f, 3E+29f, 4E+29f, 4E+28f, 2.02E+31f, enemyType.normal, AI.normal, 209));
		list37.Add(new Enemy("A Giant Pair Of Roller Skates", 1f, 3.02E+29f, 4.02E+29f, 4.02E+28f, 2.02E+31f, enemyType.normal, AI.paralyze, 210));
		list37.Add(new Enemy("A 70's Porn Mustasche", 1f, 3E+29f, 4E+29f, 4E+28f, 2.03E+31f, enemyType.normal, AI.normal, 211));
		list37.Add(new Enemy("A Disgusting Bong", 1f, 3E+29f, 4E+29f, 4E+28f, 2.03E+31f, enemyType.normal, AI.normal, 212));
		list37.Add(new Enemy("A Hippie with a Hip", 1.1f, 3.04E+29f, 4.04E+29f, 4.04E+28f, 2.04E+31f, enemyType.normal, AI.charger, 213));
		list37.Add(new Enemy("Holy Crap It's Another Shark", 1.2f, 3.06E+29f, 4.06E+29f, 4.06E+28f, 2.04E+31f, enemyType.normal, AI.rapid, 214));
		list37.Add(new Enemy("THE WORST VINYL RECORD", 1.2f, 3.08E+29f, 4.08E+29f, 4.08E+28f, 2.05E+31f, enemyType.boss, AI.poison, 215));
		list37.Add(new Enemy("THE 'FRO (BOSS)", 1.2f, 3.15E+29f, 4.1E+29f, 4.15E+28f, 2.06E+31f, enemyType.boss, AI.grower, 216));
		enemyList.Add(list37);
		List<Enemy> list38 = new List<Enemy>();
		list38.Add(new Enemy("Ultra Instinct Stoner", 1f, 1E+30f, 1.2E+30f, 1.2E+29f, 6E+31f, enemyType.normal, AI.normal, 217));
		list38.Add(new Enemy("A Skeleton Inside a Body", 1f, 1E+30f, 1.22E+30f, 1.22E+29f, 6E+31f, enemyType.normal, AI.paralyze, 218));
		list38.Add(new Enemy("A Badly Made Sexy Florida Costume", 1f, 1E+30f, 1.2E+30f, 1.2E+29f, 6E+31f, enemyType.normal, AI.normal, 219));
		list38.Add(new Enemy("An Unnecessary Sequel", 1f, 1E+30f, 1.2E+30f, 1.2E+29f, 6E+31f, enemyType.normal, AI.normal, 220));
		list38.Add(new Enemy("An Elevator Full of Blood", 1.1f, 1.04E+30f, 1.24E+30f, 1.24E+29f, 6.5E+31f, enemyType.normal, AI.charger, 221));
		list38.Add(new Enemy("Candy Corn", 1.2f, 1.06E+30f, 1.26E+30f, 1.26E+29f, 6.5E+31f, enemyType.normal, AI.normal, 222));
		list38.Add(new Enemy("TEXAS CHAINSAW MASCARA (BOSS)", 1.2f, 1.08E+30f, 1.28E+30f, 1.28E+29f, 6E+31f, enemyType.boss, AI.normal, 223));
		list38.Add(new Enemy("JIGSAW (BOSS)", 1.2f, 1.12E+30f, 1.3E+30f, 1.25E+29f, 6.5E+31f, enemyType.boss, AI.charger, 224));
		enemyList.Add(list38);
		List<Enemy> list39 = new List<Enemy>();
		list39.Add(new Enemy("ROCK LOBSTER V1", 2f, 4E+30f, 1.2E+31f, 3E+30f, 1E+33f, enemyType.bigBoss11V1, AI.normal, 369));
		list39.Add(new Enemy("ROCK LOBSTER V2", 1.9f, 2E+31f, 6E+31f, 1.5E+31f, 5E+33f, enemyType.bigBoss11V2, AI.normal, 370));
		list39.Add(new Enemy("ROCK LOBSTER V3", 1.8f, 8E+31f, 2.5E+32f, 6E+31f, 2E+34f, enemyType.bigBoss11V3, AI.normal, 371));
		list39.Add(new Enemy("ROCK LOBSTER V4", 1.7f, 2.5E+32f, 7.5E+32f, 1.2E+32f, 6E+34f, enemyType.bigBoss11V4, AI.normal, 372));
		enemyList.Add(list39);
		List<Enemy> list40 = new List<Enemy>();
		list40.Add(new Enemy("A Construction Slob", 1f, 4E+31f, 4.2E+31f, 4.2E+30f, 2.05E+33f, enemyType.normal, AI.poison, 225));
		list40.Add(new Enemy("Quicksand Cement", 1f, 4.02E+31f, 4.22E+31f, 4.22E+30f, 2.04E+33f, enemyType.normal, AI.rapid, 226));
		list40.Add(new Enemy("A Cement Truck", 1f, 4E+31f, 4.2E+31f, 4.2E+30f, 2.06E+33f, enemyType.normal, AI.normal, 227));
		list40.Add(new Enemy("A Bulldozer", 1f, 4E+31f, 4.2E+31f, 4.2E+30f, 2.07E+33f, enemyType.normal, AI.normal, 228));
		list40.Add(new Enemy("3 Guys Carrying a Beam", 1.1f, 4.04E+31f, 4.24E+31f, 4.24E+30f, 2.08E+33f, enemyType.normal, AI.normal, 229));
		list40.Add(new Enemy("A Piano-Safe", 14f, 4.06E+31f, 4.26E+31f, 4.26E+30f, 2.09E+33f, enemyType.normal, AI.exploder, 230));
		list40.Add(new Enemy("7 GUYS TAKING A BREAK (BOSS)", 1.2f, 4.08E+31f, 4.28E+31f, 4.28E+30f, 2.1E+33f, enemyType.boss, AI.normal, 231));
		list40.Add(new Enemy("THE CRANE (BOSS)", 1.2f, 4.1E+31f, 4.3E+31f, 4.35E+30f, 2.1E+33f, enemyType.boss, AI.charger, 232));
		enemyList.Add(list40);
		List<Enemy> list41 = new List<Enemy>();
		list41.Add(new Enemy("A Duck", 1f, 1E+32f, 1E+32f, 1E+30f, 5.02E+33f, enemyType.normal, AI.normal, 233));
		list41.Add(new Enemy("Another Duck", 1f, 1.02E+32f, 1.02E+32f, 1.02E+30f, 5.02E+33f, enemyType.normal, AI.normal, 234));
		list41.Add(new Enemy("...Goose!", 1f, 1E+32f, 1E+32f, 1E+30f, 5.03E+33f, enemyType.normal, AI.normal, 235));
		list41.Add(new Enemy("Scientifically Accurate Duck", 1f, 1E+32f, 1E+32f, 1E+30f, 5.03E+33f, enemyType.normal, AI.paralyze, 236));
		list41.Add(new Enemy("A MotherDucker", 1.1f, 1.04E+32f, 1.04E+32f, 1.04E+30f, 5.04E+33f, enemyType.normal, AI.charger, 237));
		list41.Add(new Enemy("Totally a Duck", 1.2f, 1.06E+32f, 1.06E+32f, 1.06E+30f, 5.04E+33f, enemyType.normal, AI.rapid, 238));
		list41.Add(new Enemy("THE DOG (BOSS)", 1.2f, 1.08E+32f, 1.08E+32f, 1.08E+30f, 5.05E+33f, enemyType.boss, AI.grower, 239));
		list41.Add(new Enemy("A SINGLE GRAPE (BOSS)", 1.2f, 1E+32f, 1.1E+32f, 1E+30f, 5.06E+33f, enemyType.boss, AI.poison, 240));
		enemyList.Add(list41);
		List<Enemy> list42 = new List<Enemy>();
		list42.Add(new Enemy("A Patch of Tulips", 1f, 2.5E+32f, 2.5E+32f, 2.5E+30f, 1.2E+34f, enemyType.normal, AI.normal, 241));
		list42.Add(new Enemy("A Random Lady", 1f, 2.5E+32f, 2.5E+32f, 2.52E+30f, 1.2E+34f, enemyType.normal, AI.paralyze, 242));
		list42.Add(new Enemy("A Lost Canadian Moose :c", 1f, 2.5E+32f, 2.5E+32f, 2.5E+30f, 1.2E+34f, enemyType.normal, AI.normal, 243));
		list42.Add(new Enemy("A 5 Bladed Windmill", 1.1f, 2.54E+32f, 2.54E+32f, 2.54E+30f, 1.25E+34f, enemyType.normal, AI.charger, 244));
		list42.Add(new Enemy("A Jerk Cyclist", 1.2f, 2.56E+32f, 2.56E+32f, 2.56E+30f, 1.25E+34f, enemyType.normal, AI.normal, 245));
		list42.Add(new Enemy("A Dutch Oven", 1f, 2.5E+32f, 2.5E+32f, 2.5E+30f, 1.2E+34f, enemyType.normal, AI.normal, 246));
		list42.Add(new Enemy("THE GRAND DUTCH DUCHY ", 1.2f, 2.58E+32f, 2.68E+32f, 2.58E+30f, 1.3E+34f, enemyType.boss, AI.normal, 247));
		list42.Add(new Enemy("DAAN VAN DER VAN JAANSEN (BOSS)", 1.2f, 2.6E+32f, 2.6E+32f, 2.55E+30f, 1.3E+34f, enemyType.boss, AI.charger, 248));
		enemyList.Add(list42);
		List<Enemy> list43 = new List<Enemy>();
		list43.Add(new Enemy("AMALGAMATE V1", 2f, 5E+32f, 1.5E+33f, 4E+32f, 1.25E+35f, enemyType.bigBoss12V1, AI.normal, 373));
		list43.Add(new Enemy("AMALGAMATE V2", 1.9f, 2E+33f, 6E+33f, 1.6E+33f, 5E+35f, enemyType.bigBoss12V2, AI.normal, 374));
		list43.Add(new Enemy("AMALGAMATE V3", 1.8f, 6E+33f, 1.8E+34f, 4.8E+33f, 1.5E+36f, enemyType.bigBoss12V3, AI.normal, 375));
		list43.Add(new Enemy("AMALGAMATE V4", 1.7f, 1.2E+34f, 3.6E+34f, 9.6E+33f, 3E+36f, enemyType.bigBoss12V4, AI.normal, 376));
		enemyList.Add(list43);
		List<Enemy> list44 = new List<Enemy>();
		list44.Add(new Enemy("A Seagull", 1f, 1.3E+34f, 1.3E+34f, 1.3E+32f, 8.2E+35f, enemyType.normal, AI.normal, 249));
		list44.Add(new Enemy("Cosmic Jellyfish", 1f, 1.3E+34f, 1.3E+34f, 1.32E+32f, 8.2E+35f, enemyType.normal, AI.paralyze, 250));
		list44.Add(new Enemy("Aether Eel", 1f, 1.3E+34f, 1.3E+34f, 1.3E+32f, 8.2E+35f, enemyType.normal, AI.normal, 251));
		list44.Add(new Enemy("You.", 1.1f, 1.34E+34f, 1.34E+34f, 1.34E+32f, 8.25E+35f, enemyType.normal, AI.charger, 252));
		list44.Add(new Enemy("A Pi-rat", 1.2f, 1.36E+34f, 1.36E+34f, 1.36E+32f, 8.25E+35f, enemyType.normal, AI.rapid, 253));
		list44.Add(new Enemy("A Bunch of Old Newspapers", 1f, 1.3E+34f, 1.3E+34f, 1.3E+32f, 8.2E+35f, enemyType.normal, AI.normal, 254));
		list44.Add(new Enemy("THE BUCKET (BOSS)", 1.2f, 1.38E+34f, 1.38E+34f, 1.38E+32f, 8.34E+35f, enemyType.boss, AI.normal, 255));
		list44.Add(new Enemy("A TAR BLOB MONSTER (BOSS)", 1f, 1.3E+34f, 1.3E+34f, 1.3E+32f, 8.34E+35f, enemyType.boss, AI.poison, 256));
		list44.Add(new Enemy("Another You.", 1f, 1.3E+34f, 1.3E+34f, 1.32E+32f, 8.25E+35f, enemyType.normal, AI.paralyze, 257));
		list44.Add(new Enemy("A Paddlefish", 1f, 1.3E+34f, 1.3E+34f, 1.3E+32f, 8.26E+35f, enemyType.normal, AI.normal, 258));
		list44.Add(new Enemy("An Anglerfish", 1f, 1.3E+34f, 1.3E+34f, 1.3E+32f, 8.27E+35f, enemyType.normal, AI.rapid, 259));
		list44.Add(new Enemy("A Bunch of Cannons", 1f, 1.3E+34f, 1.3E+34f, 1.3E+32f, 8.28E+35f, enemyType.normal, AI.normal, 260));
		list44.Add(new Enemy("A Pile of Ropes", 1f, 1.3E+34f, 1.3E+34f, 1.3E+32f, 8.2E+35f, enemyType.normal, AI.normal, 261));
		list44.Add(new Enemy("Ladders!", 1f, 1.3E+34f, 1.3E+34f, 1.3E+32f, 8.2E+35f, enemyType.normal, AI.normal, 262));
		list44.Add(new Enemy("And Snakes!!!", 1f, 1.3E+34f, 1.3E+34f, 1.3E+32f, 8.2E+35f, enemyType.normal, AI.poison, 263));
		list44.Add(new Enemy("RAMSHACKLE SEA INN (BOSS)", 1.1f, 1.34E+34f, 1.34E+34f, 1.34E+32f, 8.35E+35f, enemyType.boss, AI.charger, 264));
		list44.Add(new Enemy("The First Pirate", 1.2f, 1.36E+34f, 1.36E+34f, 1.36E+32f, 8.25E+35f, enemyType.normal, AI.normal, 265));
		list44.Add(new Enemy("The Second Pirate", 1f, 1.3E+34f, 1.3E+34f, 1.3E+32f, 8.2E+35f, enemyType.normal, AI.normal, 266));
		list44.Add(new Enemy("The Third Pirate", 1f, 1.3E+34f, 1.3E+34f, 1.3E+32f, 8.2E+35f, enemyType.normal, AI.normal, 267));
		list44.Add(new Enemy("The Fourth Pirate ", 1f, 1.3E+34f, 1.3E+34f, 1.32E+32f, 8.2E+35f, enemyType.normal, AI.paralyze, 268));
		list44.Add(new Enemy("THE CAPTAIN (BOSS)", 1.2f, 1.3E+34f, 1.3E+34f, 1.35E+32f, 8.35E+35f, enemyType.boss, AI.charger, 269));
		enemyList.Add(list44);
		List<Enemy> list45 = new List<Enemy>();
		list45.Add(new Enemy("TIPPI THE TUTORIAL MOUSE", 2f, 2E+34f, 4E+34f, 1E+32f, 2E+36f, enemyType.finalBoss, AI.normal, 377));
		enemyList.Add(list45);
		List<Enemy> list46 = new List<Enemy>();
		list46.Add(new Enemy("THE TRAITOR", 1.8f, 5E+34f, 1E+35f, 1E+33f, 2E+37f, enemyType.finalfinalboss, AI.normal, 378));
		enemyList.Add(list46);
		itopodEnemyList.Add(new Enemy("Pissed off Dude", 1.2f, 10f, 10f, 1f, 600f, enemyType.itopod, AI.normal, 0));
		itopodEnemyList.Add(new Enemy("Angry Dude", 1.2f, 10f, 10f, 1f, 600f, enemyType.itopod, AI.charger, 0));
		itopodEnemyList.Add(new Enemy("Ticked Off Dude", 1.2f, 10f, 10f, 1f, 600f, enemyType.itopod, AI.poison, 0));
		itopodEnemyList.Add(new Enemy("Furious Dude", 1.2f, 10f, 10f, 1f, 600f, enemyType.itopod, AI.rapid, 0));
		itopodEnemyList.Add(new Enemy("Disgruntled Dude", 1.2f, 10f, 10f, 1f, 600f, enemyType.itopod, AI.grower, 0));
		itopodEnemyList.Add(new Enemy("Mad Dude", 1.2f, 10f, 10f, 1f, 600f, enemyType.itopod, AI.paralyze, 0));
		itopodEnemyList.Add(new Enemy("A N G E R Y Dude", 1.2f, 10f, 10f, 1f, 600f, enemyType.itopod, AI.charger, 0));
		itopodEnemyList.Add(new Enemy("Vexed Dude", 1.2f, 10f, 10f, 1f, 600f, enemyType.itopod, AI.normal, 0));
		itopodEnemyList.Add(new Enemy("Jimmy-Rustled Dude", 1.2f, 10f, 10f, 1f, 600f, enemyType.itopod, AI.normal, 0));
		itopodEnemyList.Add(new Enemy("Frustrated Dude", 1.2f, 10f, 10f, 1f, 600f, enemyType.itopod, AI.poison, 0));
		itopodEnemyList.Add(new Enemy("Frenzied Dude", 1.2f, 10f, 10f, 1f, 600f, enemyType.itopod, AI.rapid, 0));
		itopodEnemyList.Add(new Enemy("Livid Dude", 1.2f, 10f, 10f, 1f, 600f, enemyType.itopod, AI.grower, 0));
		itopodEnemyList.Add(new Enemy("Rabid Dude", 1.2f, 10f, 10f, 1f, 600f, enemyType.itopod, AI.poison, 0));
		itopodEnemyList.Add(new Enemy("Overzealous Dude", 1.2f, 10f, 10f, 1f, 600f, enemyType.itopod, AI.normal, 0));
		itopodEnemyList.Add(new Enemy("Corybantic (wtf?) Dude", 1.2f, 10f, 10f, 1f, 600f, enemyType.itopod, AI.charger, 0));
		itopodEnemyList.Add(new Enemy("Raging Dude", 1.2f, 10f, 10f, 1f, 600f, enemyType.itopod, AI.paralyze, 0));
	}

	private Enemy spawnEnemy(int zone)
	{
		if (zone >= 0 && zone < 1000)
		{
			int num = 0;
			if (zone == 16)
			{
				return enemyList[16][character.adventure.waldoDefeats];
			}
			num = UnityEngine.Random.Range(0, enemyList[zone].Count);
			if (zone == 19 && !character.adventure.titan6Unlocked)
			{
				return enemyList[19][0];
			}
			if (zone == 19 && character.adventure.titan6Unlocked)
			{
				return enemyList[19][character.adventure.titan6Version + 1];
			}
			if (zone == 23 && !character.adventure.titan7Unlocked)
			{
				return enemyList[23][0];
			}
			if (zone == 23 && character.adventure.titan7Unlocked)
			{
				return enemyList[23][character.adventure.titan7Version + 1];
			}
			if (zone == 26 && !character.adventure.titan8Unlocked)
			{
				return enemyList[26][0];
			}
			if (zone == 26 && character.adventure.titan8Unlocked)
			{
				return enemyList[26][character.adventure.titan8Version + 1];
			}
			if (zone == 30 && !character.adventure.titan9Unlocked)
			{
				return enemyList[30][0];
			}
			if (zone == 30 && character.adventure.titan9Unlocked)
			{
				return enemyList[30][character.adventure.titan9Version + 1];
			}
			switch (zone)
			{
			case 34:
				return enemyList[34][character.adventure.titan10Version + 1];
			case 38:
				return titan11AddToughnessHP(enemyList[38][character.adventure.titan11Version]);
			case 42:
				return enemyList[42][character.adventure.titan12Version];
			case 44:
				return enemyList[44][0];
			case 45:
				return enemyList[45][0];
			default:
				return enemyList[zone][num];
			}
		}
		if (zone == 1000)
		{
			int index = UnityEngine.Random.Range(0, itopodEnemyList.Count);
			return giveName(powerUp(itopodEnemyList[index], itopodLevel));
		}
		return enemyList[0][0];
	}

	public Enemy powerUp(Enemy oldEnemy, int level)
	{
		Enemy enemy = new Enemy(oldEnemy);
		if (level < 0)
		{
			level = 0;
		}
		if (level > maxItopodLevel())
		{
			level = maxItopodLevel();
		}
		enemy.attack *= Mathf.Pow(1.05f, level);
		enemy.defense *= Mathf.Pow(1.05f, level);
		enemy.maxHP *= Mathf.Pow(1.05f, level);
		enemy.regen *= Mathf.Pow(1.05f, level);
		enemy.attack *= UnityEngine.Random.Range(0.98f, 1.02f);
		enemy.defense *= UnityEngine.Random.Range(0.98f, 1.02f);
		enemy.maxHP *= UnityEngine.Random.Range(0.98f, 1.02f);
		enemy.regen *= UnityEngine.Random.Range(0.98f, 1.02f);
		enemy.curHP = enemy.maxHP;
		enemy.spriteID = UnityEngine.Random.Range(0, itopodSprites.Count);
		return enemy;
	}

	public Enemy giveName(Enemy oldEnemy)
	{
		Enemy enemy = new Enemy(oldEnemy);
		if (character.itopodNames.listLoaded)
		{
			string text = character.itopodNames.genRandomName();
			enemy.name = text;
		}
		return enemy;
	}

	public Enemy titan11AddToughnessHP(Enemy oldEnemy)
	{
		Enemy enemy = new Enemy(oldEnemy);
		int num = 0;
		int num2 = 3;
		if (character.itemInfo.itemName[character.inventory.weapon.id].Contains("Paper"))
		{
			num++;
		}
		if (character.itemInfo.itemName[character.inventory.chest.id].Contains("Paper"))
		{
			num++;
		}
		for (int i = 0; i < character.inventory.accs.Count; i++)
		{
			if (character.itemInfo.itemName[character.inventory.accs[i].id].Contains("Paper") || character.itemInfo.itemDesc[character.inventory.accs[i].id].Contains("Paper"))
			{
				num++;
			}
		}
		if (num < 0)
		{
			num = 0;
		}
		int num3 = num2 - num;
		if (num3 < 0)
		{
			num3 = 0;
		}
		if (num3 > 3)
		{
			num3 = 3;
		}
		if (num3 > 0)
		{
			enemy.defense *= Mathf.Pow(3f, num3);
			enemy.maxHP *= Mathf.Pow(3f, num3);
			enemy.curHP = enemy.maxHP;
			if (num3 == 3)
			{
				log.AddEvent("Using the powers of ROCK, the Lobster hardens its shell!");
				log.AddEvent("Lobster Max HP and Defense massively increased!");
				log.AddEvent("If only you equipped something that counters ROCK...");
			}
			else
			{
				log.AddEvent("You partially resist but the Lobster's ROCK power still overwhelms you!");
				log.AddEvent("Lobster Max HP and Defense greatly increased!");
				log.AddEvent("You need *more* equipment that counters ROCK...");
			}
		}
		else
		{
			log.AddEvent("Using the power of PAPER you nullify the Rock Lobster's stupid gimmick!");
			log.AddEvent("Lobster Max HP and Defense reduced - well done!");
		}
		return enemy;
	}

	private void dropLoot()
	{
		switch (character.adventure.zone)
		{
		case 0:
			lootDrop.zone0Drop(currentEnemy);
			break;
		case 1:
			lootDrop.zone1Drop(currentEnemy);
			break;
		case 2:
			lootDrop.zone2Drop(currentEnemy);
			break;
		case 3:
			lootDrop.zone3Drop(currentEnemy);
			break;
		case 4:
			lootDrop.zone4Drop(currentEnemy);
			break;
		case 5:
			lootDrop.zone5Drop(currentEnemy);
			break;
		case 6:
			lootDrop.zone6Drop(currentEnemy);
			break;
		case 7:
			lootDrop.zone7Drop(currentEnemy);
			break;
		case 8:
			lootDrop.zone8Drop(currentEnemy);
			break;
		case 9:
			lootDrop.zone9Drop(currentEnemy);
			break;
		case 10:
			lootDrop.zone10Drop(currentEnemy);
			break;
		case 11:
			lootDrop.zone11Drop(currentEnemy);
			break;
		case 12:
			lootDrop.zone12Drop(currentEnemy);
			break;
		case 13:
			lootDrop.zone13Drop(currentEnemy);
			break;
		case 14:
			lootDrop.zone14Drop(currentEnemy);
			break;
		case 15:
			lootDrop.zone15Drop(currentEnemy);
			break;
		case 16:
			lootDrop.zone16Drop(currentEnemy);
			break;
		case 17:
			lootDrop.zone17Drop(currentEnemy);
			break;
		case 18:
			lootDrop.zone18Drop(currentEnemy);
			break;
		case 19:
			lootDrop.zone19Drop(currentEnemy);
			break;
		case 20:
			lootDrop.zone20Drop(currentEnemy);
			break;
		case 21:
			lootDrop.zone21Drop(currentEnemy);
			break;
		case 22:
			lootDrop.zone22Drop(currentEnemy);
			break;
		case 23:
			lootDrop.zone23Drop(currentEnemy);
			break;
		case 24:
			lootDrop.zone24Drop(currentEnemy);
			break;
		case 25:
			lootDrop.zone25Drop(currentEnemy);
			break;
		case 26:
			lootDrop.zone26Drop(currentEnemy);
			break;
		case 27:
			lootDrop.zone27Drop(currentEnemy);
			break;
		case 28:
			lootDrop.zone28Drop(currentEnemy);
			break;
		case 29:
			lootDrop.zone29Drop(currentEnemy);
			break;
		case 30:
			lootDrop.zone30Drop(currentEnemy);
			break;
		case 31:
			lootDrop.zone31Drop(currentEnemy);
			break;
		case 32:
			lootDrop.zone32Drop(currentEnemy);
			break;
		case 33:
			lootDrop.zone33Drop(currentEnemy);
			break;
		case 34:
			lootDrop.zone34Drop(currentEnemy);
			break;
		case 35:
			lootDrop.zone35Drop(currentEnemy);
			break;
		case 36:
			lootDrop.zone36Drop(currentEnemy);
			break;
		case 37:
			lootDrop.zone37Drop(currentEnemy);
			break;
		case 38:
			lootDrop.zone38Drop(currentEnemy);
			break;
		case 39:
			lootDrop.zone39Drop(currentEnemy);
			break;
		case 40:
			lootDrop.zone40Drop(currentEnemy);
			break;
		case 41:
			lootDrop.zone41Drop(currentEnemy);
			break;
		case 42:
			lootDrop.zone42Drop(currentEnemy);
			break;
		case 43:
			lootDrop.zone43Drop(currentEnemy);
			break;
		case 44:
			lootDrop.zone44Drop(currentEnemy);
			break;
		case 45:
			lootDrop.zone45Drop(currentEnemy);
			break;
		case 1000:
			lootDrop.itopodDrop(currentEnemy, itopodLevel);
			break;
		}
	}

	public void playerDeath()
	{
		log.AddEvent(currentEnemy.name + " has defeated you!");
		character.adventure.curHP = 0f;
		if (zone == 1000)
		{
			itopodLevel = character.adventure.itopodStart;
			fightInProgress = false;
			respawnTimer = 0f;
			idleAttackTimer = 0f;
			currentEnemy.curHP = currentEnemy.maxHP;
			currentEnemy = null;
			updateEnemyPortrait();
			enemyAI.resetAI();
			enemyHPBar.value = 0f;
			enemyHPText.text = "0 HP";
			enemyStats.text = "No Enemy";
			bossIcon.enabled = false;
			resetBar();
			playerController.reset();
			playerController.clearDisableFlags();
			if (character.arbitrary.boughtLazyITOPOD && character.arbitrary.lazyITOPODOn)
			{
				activateLazyItopod();
			}
			return;
		}
		if (zone == 34)
		{
			lootDrop.postDeathDrops(currentEnemy);
		}
		zone = -1;
		zoneTitle.text = "Safe Zone: Awakening Site";
		fightInProgress = false;
		respawnTimer = 0f;
		idleAttackTimer = 0f;
		currentEnemy.curHP = currentEnemy.maxHP;
		currentEnemy = null;
		updateEnemyPortrait();
		enemyAI.resetAI();
		enemyHPBar.value = 0f;
		enemyHPText.text = "0 HP";
		enemyStats.text = "No Enemy";
		bossIcon.enabled = false;
		resetBar();
		playerController.reset();
		playerController.clearDisableFlags();
		zoneSelector.selectZone(0);
	}

	public void enemyDeath()
	{
		log.AddEvent("You have defeated " + currentEnemy.name + "!");
		globalKillCounter++;
		if (currentEnemy.enemyType != enemyType.itopod)
		{
			character.bestiaryController.confirmedKill(currentEnemy.spriteID);
		}
		if (zone == 6)
		{
			character.stats.titansDefeated++;
			character.adventure.titan1Kills++;
			character.adventure.boss1Spawn.reset();
			if (enemyAI.growCount <= 1)
			{
				character.allAchievements.markAchievementAsComplete(131);
			}
		}
		if (zone == 8)
		{
			character.stats.titansDefeated++;
			character.adventure.titan2Kills++;
			character.adventure.boss2Spawn.reset();
			character.challenges.trollUnlocked = true;
			if (enemyAI.growCount <= 1)
			{
				character.allAchievements.markAchievementAsComplete(132);
			}
		}
		if (zone == 11)
		{
			character.stats.titansDefeated++;
			character.adventure.titan3Kills++;
			character.challenges.noRebirthChallenge.unlocked = true;
			character.adventure.boss3Spawn.reset();
			if (enemyAI.growCount <= 1)
			{
				character.allAchievements.markAchievementAsComplete(133);
			}
		}
		if (zone == 14)
		{
			character.stats.titansDefeated++;
			character.adventure.titan4Kills++;
			character.adventure.boss4Spawn.reset();
			if (enemyAI.growCount <= 1)
			{
				character.allAchievements.markAchievementAsComplete(134);
			}
		}
		if (zone == 16)
		{
			character.adventure.boss5Spawn.reset();
			if (character.adventure.waldoDefeats >= 4)
			{
				character.stats.titansDefeated++;
				character.adventure.titan5Kills++;
				character.allAchievements.markAchievementAsComplete(145);
				if (enemyAI.growCount <= 1)
				{
					character.allAchievements.markAchievementAsComplete(146);
				}
			}
		}
		if (zone == 19)
		{
			character.adventure.boss6Spawn.reset();
			if (character.adventure.titan6Unlocked)
			{
				character.stats.titansDefeated++;
				character.adventure.titan6Kills++;
				if (currentEnemy.enemyType == enemyType.bigBoss6V1)
				{
					character.allAchievements.markAchievementAsComplete(148);
				}
				else if (currentEnemy.enemyType == enemyType.bigBoss6V2)
				{
					character.allAchievements.markAchievementAsComplete(149);
				}
				else if (currentEnemy.enemyType == enemyType.bigBoss6V3)
				{
					character.allAchievements.markAchievementAsComplete(150);
				}
				else if (currentEnemy.enemyType == enemyType.bigBoss6V4)
				{
					character.allAchievements.markAchievementAsComplete(151);
				}
			}
		}
		if (zone == 23)
		{
			character.adventure.boss7Spawn.reset();
			if (character.adventure.titan7Unlocked)
			{
				character.stats.titansDefeated++;
				character.adventure.titan7Kills++;
				if (currentEnemy.enemyType != enemyType.bigBoss7V1 && currentEnemy.enemyType != enemyType.bigBoss7V2 && currentEnemy.enemyType != enemyType.bigBoss7V3)
				{
					_ = currentEnemy.enemyType;
					_ = 21;
				}
			}
		}
		if (zone == 26)
		{
			character.adventure.boss8Spawn.reset();
			if (character.adventure.titan8Unlocked)
			{
				character.stats.titansDefeated++;
				character.adventure.titan8Kills++;
				if (currentEnemy.enemyType != enemyType.bigBoss8V1 && currentEnemy.enemyType != enemyType.bigBoss8V2 && currentEnemy.enemyType != enemyType.bigBoss8V3)
				{
					_ = currentEnemy.enemyType;
					_ = 26;
				}
			}
		}
		if (zone == 30)
		{
			character.adventure.boss9Spawn.reset();
			if (character.adventure.titan9Unlocked)
			{
				character.stats.titansDefeated++;
				character.adventure.titan9Kills++;
				if (currentEnemy.enemyType != enemyType.bigBoss9V1 && currentEnemy.enemyType != enemyType.bigBoss9V2 && currentEnemy.enemyType != enemyType.bigBoss9V3)
				{
					_ = currentEnemy.enemyType;
					_ = 31;
				}
			}
		}
		if (zone == 34)
		{
			character.adventure.boss10Spawn.reset();
			if (character.adventure.titan10Unlocked)
			{
				character.stats.titansDefeated++;
				character.adventure.titan10Kills++;
				if (currentEnemy.enemyType != enemyType.bigBoss10V1 && currentEnemy.enemyType != enemyType.bigBoss10V2 && currentEnemy.enemyType != enemyType.bigBoss10V3)
				{
					_ = currentEnemy.enemyType;
					_ = 36;
				}
			}
		}
		if (zone == 38)
		{
			character.adventure.boss11Spawn.reset();
			if (character.adventure.titan11Unlocked)
			{
				character.stats.titansDefeated++;
				character.adventure.titan11Kills++;
				if (currentEnemy.enemyType != enemyType.bigBoss11V1 && currentEnemy.enemyType != enemyType.bigBoss11V2 && currentEnemy.enemyType != enemyType.bigBoss11V3)
				{
					_ = currentEnemy.enemyType;
					_ = 40;
				}
			}
		}
		if (zone == 42)
		{
			character.adventure.boss12Spawn.reset();
			if (character.adventure.titan12Unlocked)
			{
				character.stats.titansDefeated++;
				character.adventure.titan12Kills++;
				if (currentEnemy.enemyType != enemyType.bigBoss12V1 && currentEnemy.enemyType != enemyType.bigBoss12V2 && currentEnemy.enemyType != enemyType.bigBoss12V3)
				{
					_ = currentEnemy.enemyType;
					_ = 45;
				}
			}
		}
		if (zone == 44)
		{
			character.adventure.boss13Spawn.reset();
		}
		if (zone == 45)
		{
			character.adventure.boss14Spawn.reset();
		}
		if (zone == 1000)
		{
			itopodKillCount++;
			if (character.adventure.itopod.perkLevel[30] >= 1)
			{
				character.adventureController.itopod.addPoopProgress(1L);
			}
			long amount = itopod.progressGained(itopodLevel);
			if (character.adventure.itopod.buffedKills > 0 && character.settings.buffedKillsOn)
			{
				character.adventure.itopod.buffedKills--;
				updatePillUI();
			}
			itopod.addProgress(amount);
			if (itopodKillCount >= 10)
			{
				itopodKillCount = 0;
				itopodLevel++;
				if (itopodLevel > character.adventure.itopodEnd)
				{
					itopodLevel = character.adventure.itopodStart;
				}
			}
			if (itopodLevel > character.adventure.highestItopodLevel)
			{
				itopod.awardHighestLevelPP(itopodLevel);
				character.adventure.highestItopodLevel = itopodLevel;
			}
		}
		if (currentEnemy.enemyType == enemyType.boss)
		{
			character.stats.advBossesKilled++;
			if (character.stats.advBossesKilled % 10 == 0L)
			{
				character.addAP(1);
			}
		}
		currentEnemy.curHP = currentEnemy.maxHP;
		dropLoot();
		currentEnemy = null;
		fightInProgress = false;
		respawnTimer = 0f;
		idleAttackTimer = 0f;
		enemyAI.resetAI();
		playerController.clearDisableFlags();
		enemyHPBar.value = 0f;
		enemyHPText.text = "0 HP";
		enemyStats.text = "No Enemy";
		bossIcon.enabled = false;
		resetBar();
		if (character.arbitrary.boughtLazyITOPOD && character.arbitrary.lazyITOPODOn && zone == 1000)
		{
			activateLazyItopod();
		}
	}

	public void wipeEnemy()
	{
		currentEnemy.curHP = currentEnemy.maxHP;
		currentEnemy = null;
		updateEnemyPortrait();
		fightInProgress = false;
		respawnTimer = 0f;
		idleAttackTimer = 0f;
		enemyAI.resetAI();
		playerController.clearDisableFlags();
		enemyHPBar.value = 0f;
		enemyHPText.text = "0 HP";
		enemyStats.text = "No Enemy";
		bossIcon.enabled = false;
		resetBar();
	}

	public void displayEnemyStats()
	{
		if (character.menuID != 3)
		{
			return;
		}
		if (currentEnemy == null)
		{
			enemyStats.text = "No Enemy";
			return;
		}
		if (currentEnemy.enemyType == enemyType.boss)
		{
			enemyStats.text = "<b>\t\t" + currentEnemy.name + "</b>\n\n";
			bossIcon.enabled = true;
		}
		else
		{
			enemyStats.text = "<b>" + currentEnemy.name + "</b>\n\n";
			bossIcon.enabled = false;
		}
		Text text = enemyStats;
		text.text = text.text + "<b>Power:</b> " + format.suffixFormat(currentEnemy.attack) + "\n";
		Text text2 = enemyStats;
		text2.text = text2.text + "<b>Toughness:</b> " + format.suffixFormat(currentEnemy.defense) + "\n";
		Text text3 = enemyStats;
		text3.text = text3.text + "<b>Max HP:</b> " + format.suffixFormat(currentEnemy.maxHP) + "\n";
		if (currentEnemy.regen > 1000f)
		{
			Text text4 = enemyStats;
			text4.text = text4.text + "<b>HP Regen:</b> " + format.suffixFormat(currentEnemy.regen) + "\n";
		}
		else
		{
			Text text5 = enemyStats;
			text5.text = text5.text + "<b>HP Regen:</b> " + currentEnemy.regen.ToString("##0.##") + "\n";
		}
		Text text6 = enemyStats;
		text6.text = text6.text + "<b>Type:</b> " + currentEnemy.AI;
	}

	public void reset()
	{
		character.adventure.zone = -1;
		playerController.clearDisableFlags();
		zoneSelector.changeZone(character.adventure.zone);
		fightInProgress = false;
		respawnTimer = 0f;
		idleAttackTimer = 0f;
		itopodLevel = 0;
		if (currentEnemy != null)
		{
			currentEnemy.curHP = currentEnemy.maxHP;
		}
		currentEnemy = null;
		enemyAI.resetAI();
		updateEnemy();
		updatePlayer();
		updateZone();
		character.adventure.resetAdventure();
		bossIcon.enabled = false;
		resetBar();
	}

	public void resetBar()
	{
		enemyBarFill.color = new Color(0.925f, 0.204f, 0.204f);
		enemyBarBackground.color = Color.white;
	}

	private void showIcon()
	{
		bossIcon.sprite = Resources.Load<Sprite>("BossIcon");
	}

	private void hideIcon()
	{
		bossIcon.enabled = false;
	}

	public void updateEnemyPortrait()
	{
		if (currentEnemy == null)
		{
			enemyPortrait.sprite = enemySprites[0];
		}
		else if (currentEnemy.enemyType == enemyType.itopod)
		{
			if (currentEnemy.spriteID < 0 || currentEnemy.spriteID >= itopodSprites.Count)
			{
				enemyPortrait.sprite = enemySprites[0];
			}
			else
			{
				enemyPortrait.sprite = itopodSprites[currentEnemy.spriteID];
			}
		}
		else if (currentEnemy.spriteID < 0 || currentEnemy.spriteID >= enemySprites.Count)
		{
			enemyPortrait.sprite = enemySprites[0];
		}
		else
		{
			enemyPortrait.sprite = enemySprites[currentEnemy.spriteID];
		}
	}

	private void fiveBarDisplay()
	{
		float num = currentEnemy.curHP / currentEnemy.maxHP * 5f;
		float value = currentEnemy.curHP / currentEnemy.maxHP * 5f % 1f;
		if (num >= 5f)
		{
			enemyBarFill.color = Color.grey;
			enemyBarBackground.color = Color.magenta;
		}
		else if (num > 4f)
		{
			enemyBarFill.color = Color.magenta;
			enemyBarBackground.color = Color.cyan;
		}
		else if (num > 3f)
		{
			enemyBarFill.color = Color.cyan;
			enemyBarBackground.color = Color.green;
		}
		else if (num > 2f)
		{
			enemyBarFill.color = Color.green;
			enemyBarBackground.color = Color.yellow;
		}
		else if (num > 1f)
		{
			enemyBarFill.color = Color.yellow;
			enemyBarBackground.color = new Color(0.925f, 0.204f, 0.204f);
		}
		else if (num >= 0f)
		{
			enemyBarFill.color = new Color(0.925f, 0.204f, 0.204f);
			enemyBarBackground.color = Color.white;
		}
		enemyHPBar.value = value;
		if (currentEnemy.curHP < 1f)
		{
			enemyHPText.text = currentEnemy.curHP.ToString("#") + " HP";
		}
		else
		{
			enemyHPText.text = format.suffixFormat(currentEnemy.curHP) + " HP";
		}
	}

	private void regularBarDisplay()
	{
		enemyBarFill.color = new Color(0.925f, 0.204f, 0.204f);
		enemyBarBackground.color = Color.white;
		enemyHPBar.value = currentEnemy.curHP / currentEnemy.maxHP;
	}

	public void zoneDescriptions()
	{
		switch (zone)
		{
		case -1:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Recommended Stats: </b> None. This is a safe zone, dummy. Fun Fact: you have 5x your normal hp regen while in this zone!";
			break;
		case 0:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Recommended Stats: </b> 10 Power/Toughness. It's basically the Tutorial. Reminder: Boss enemies have a chance to drop EXP! They're the ones with a crown icon.\n\n<b>Equipment Dropped by Boss: </b> Whole set, you bet!";
			break;
		case 1:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Recommended Stats: </b> 12 Power/Toughness. Still pretty easy. Try unlocking some extra moves by training if you're stuck!\n\n<b>Equipment Dropped by Boss: </b>  Whole set, you bet!";
			break;
		case 2:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Recommended Stats: </b> 35 Power/Toughness. Beware the paralyzing gaze of the Gorgon!\n<b>Equipment Dropped by Boss: </b> Whole set, you bet!";
			break;
		case 3:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Recommended Stats: </b> 150 Power/Toughness. Better have most of your moves unlocked.\n\n<b>Equipment Dropped by Boss: </b>  Whole set, you bet!";
			break;
		case 4:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Recommended Stats: </b> 400 Power/Toughness. A very generic zone.\n\n<b>Equipment Dropped by Boss: </b>No new set D: But, you can expect some extra boost drops and even drop special items from the bosses...";
			break;
		case 5:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Recommended Stats: </b> 500 Power/Toughness. You might want to try advanced training, if you've unlocked it!\n\n<b>Equipment Dropped by Boss: </b>Whole set, you bet!";
			break;
		case 6:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Recommended Stats: </b> 1300 Power/Toughness. The ultimate fusion of murderous psychopath and chef.\n\n<b>Equipment Dropped by Boss: </b>Whole set, you bet! Also, be on the lookout for a very special drop.\n\nAutokill triggered at 3K Power & 2.5K Toughness";
			break;
		case 7:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Recommended Stats: </b> 3250 Power/Toughness. It's basically the Tutorial. Except that's a complete lie.\n\n<b>Equipment Dropped by Boss: </b>Whole set, you bet!";
			break;
		case 8:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Recommended Stats: </b> 5000 Power/Toughness. It's big, gnarly, and purple. Luckily it doesn't move. \n\n<b>Equipment Dropped by Boss: </b>Huge boosts and a few special drops.\n\nAutokill triggered at 9K Power & 7K Toughness";
			break;
		case 9:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Recommended Stats: </b> 4500 Power/Toughness. Watch out for the triangles.\n\n<b>Equipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance:" + character.lootChanceDisplay(0.07f, 15f) + "</b>";
			break;
		case 10:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Recommended Stats: </b> 12000 Power/Toughness. This is like, 3spoopy5me.\n\n<b>Equipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplay(0.06f, 20f) + "</b>";
			break;
		case 11:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Recommended Stats: </b> 15000+ Power/Toughness. Hates people with a large NUMBER. Loves insects. \n\n<b>Equipment Dropped by Boss: </b>Whole set, you bet!\n<b>Normal Loot Drop Chance: " + character.lootChanceDisplay(0.1f) + "</b>\n<b>Rare Loot Drop Chance: " + character.lootChanceDisplay(0.02f) + "</b>\n\nAutokill triggered at 25K Power & 15K Toughness";
			break;
		case 12:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Recommended Stats: </b> At this point you're better off experimenting on your own. Also, where the heck are you?\n\n<b>Equipment Dropped by Boss: </b>Whole set, with a bonus accessory!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplay(0.03f, 25f) + "</b>";
			break;
		case 13:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Try to avoid any air men while you're here.\nEquipment Dropped by Boss: </b>Whole set, and a bonus accessory!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplay(0.011f, 15f) + "</b>";
			break;
		case 14:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>This guy smells so bad that you noticed his stench back in the Forest..\nEquipment Dropped by Boss: </b>RINGS! ALL THE RINGS!\n<b>Normal Loot Drop Chance: " + character.lootChanceDisplay(0.02f) + "</b>\n<b>Rare Loot Drop Chance: " + character.lootChanceDisplay(0.001f) + "</b>\n\nAutokill triggered at 800K Power/400K Toughness/14K Regen/Item 135 marked as maxxed";
			break;
		case 15:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Better use your fancy beards for this!\nEquipment Dropped by Boss: </b>Whole set, you bet! Plus 1 ultra rare accessory.\n\n<b>Boost Drop Chance: " + character.lootChanceDisplay(0.0035f, 25f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplay(0.01f) + " </b>";
			break;
		case 16:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Keep your eyes on the Battle Log!\nEquipment Dropped by Boss: </b>TWO sets, you bet! Plus 1 ultra rare weapon. Plus... maybe more?\n\n<b>One 100% Drop</b>\n<b>Normal Loot Drop Chance: </b>" + character.lootChanceDisplay(0.005f) + "\n<b>Rare Loot Drop Chance: </b>" + character.lootChanceDisplay(0.0001f) + "\n\nAutokill triggered at 13M Power, 7M Toughness, 150K Regen, and 3 kills on Walderp's final form";
			break;
		case 17:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Infinity MacGuffin kinda rhymes with Egg McMuffin. Just wanted to say that somewhere.\nEquipment Dropped by Boss: </b>Whole set, you bet! Plus some old looty friends make a comeback!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplay(0.001f, 20f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplay(6E-05f, 5f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplay(0.00018f, 15f) + "</b>";
			break;
		case 18:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Where in the world are you heading off to next?.\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplay(0.00012f, 20f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplay(3E-05f, 4f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplay(9E-05f, 10f) + "</b>";
			break;
		case 19:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>THE BEAST will devour all in its path!\nEquipment Dropped by Boss: </b>V1: Whole set you bet!\nV2-4: Shiny accessories!\n\n" + beastLootRates() + "\n\nAutokill triggered at " + beastAutokillRequirements();
			break;
		case 20:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Mmmm, Chocolate.\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(0.00055f, 10f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(0.00018f, 8f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(0.00055f, 12f) + "</b>";
			break;
		case 21:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>It's like the same, but Evil-er.\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(0.00012f, 10f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(7E-05f, 8f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(0.00021f, 12f) + "</b>";
			break;
		case 22:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>So lovely and PINK!\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(0.0001f, 8f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(3E-05f, 8f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(0.0001f, 12f) + "</b>";
			break;
		case 23:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>In his mom's basement, naturally.\nEquipment Dropped by Boss: </b>V1: Whole set you bet!\nV2-4: Shiny accessories!\n\n" + nerdLootRates() + "\n\nAutokill triggered at " + nerdAutokillRequirements();
			break;
		case 24:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>You could Idle here all day.\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(5E-05f, 7f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(1.5E-05f, 4f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(5E-05f, 12f) + "</b>";
			break;
		case 25:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>You see the Macguffin in the punchbowl!\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(3E-05f, 8f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(1.1E-05f, 4f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(3.5E-05f, 12f) + "</b>";
			break;
		case 26:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>You seek an audience with the Godmother? You'll have to get by the Consigliere first.\nEquipment Dropped by Boss: </b>V1: Whole set you bet!\nV2-4: Shiny accessories!\n\n" + godmotherLootRates() + "\n\nAutokill triggered at " + godmotherAutokillRequirements();
			break;
		case 27:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>I shoudl leran to tpye betetr.\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(2.2E-05f, 8f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(9E-06f, 4f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(2.5E-05f, 12f) + "</b>";
			break;
		case 28:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Relive your childhood!\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(1.8E-05f, 8f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(7E-06f, 4f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(2.1E-05f, 12f) + "</b>";
			break;
		case 29:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Where Ancient Evils come to be killed by 16 year olds.\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(1.5E-06f, 8f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(5.5E-06f, 4f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(1.8E-05f, 12f) + "</b>";
			break;
		case 30:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>The Exile has been sealed away here.\nEquipment Dropped by Boss: </b>V1: Whole set you bet!\nV2-4: Shiny accessories!\n\n" + exileLootRates() + "\n\nAutokill triggered at " + exileAutokillRequirements() + " OR 24 manual kills";
			break;
		case 31:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>This zone is kickin' rad, bros.\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(6E-07f, 15f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(2E-07f, 5f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(6E-07f, 15f) + "</b>";
			break;
		case 32:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>You need some schooling before you take on SADISTIC difficulty!\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(4E-07f, 10f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(1.5E-07f, 5f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(4.5E-07f, 15f) + "</b>";
			break;
		case 33:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Howdy Pardner!\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(2.5E-07f, 15f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(1E-07f, 5f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(3E-07f, 15f) + "</b>";
			break;
		case 34:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>This thing might actually be hungrier than THE BEAST, and you've seen that guy eat the Large Hadron Collider.\nEquipment Dropped by Boss: </b>V1: Whole set you bet!\nV2-4: Shiny accessories!\n\n" + itHungersLootRates() + "\n\nAutokill triggered at " + itHungersAutokillRequirements() + " OR 5 manual kills. ;)";
			break;
		case 35:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>It's like beards, but completely different.\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(1E-07f, 15f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(4E-08f, 4f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(1.2E-07f, 15f) + "</b>";
			break;
		case 36:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Groovy, Baby!\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(6E-08f, 15f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(2.5E-08f, 4f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(8E-08f, 15f) + "</b>";
			break;
		case 37:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>BLEH!!\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(4E-08f, 15f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(1.6E-08f, 4f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(5E-08f, 15f) + "</b>";
			break;
		case 38:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Dooo, doooo, doooo, doooo, dooo, dodododoooooo!!!!\nEquipment Dropped by Boss: </b>V1: Whole set you bet!\nV2-4: Shiny accessories!\n\n" + rockLobsterLootRates() + "\n\nAutokill triggered at " + rockLobsterAutokillRequirements() + " OR 5 manual kills. ;D";
			break;
		case 39:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Watch your head!\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(2.5E-08f, 16f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(1E-08f, 4f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(3E-08f, 15f) + "</b>";
			break;
		case 40:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>QUACK QUACK QUACK!\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(2E-08f, 17f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(8E-09f, 5f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(2.4E-08f, 15f) + "</b>";
			break;
		case 41:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Equal parts beautiful anmd horrifying.\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(1.6E-08f, 17f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(6E-09f, 5f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(1.8E-08f, 15f) + "</b>";
			break;
		case 42:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>They're baaaaack!\nEquipment Dropped by Boss: </b>V1: Whole set you bet!\nV2-4: Shiny accessories!\n\n" + amalgamateLootRates() + "\n\nAutokill triggered at " + amalgamateAutokillRequirements() + " OR 5 manual kills. ;3";
			break;
		case 43:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Imprisoned in a vast nothing-ness... you have to find your way back!\nEquipment Dropped by Boss: </b>Whole set, you bet!\n\n<b>Boost Drop Chance: " + character.lootChanceDisplayRooted(1E-08f, 17f) + "</b>\n\n<b>Normal Mob Drop Chance: " + character.lootChanceDisplayRooted(4E-09f, 5f) + "</b>\n<b>Boss Drop Chance: " + character.lootChanceDisplayRooted(1.2E-08f, 15f) + "</b>";
			break;
		case 44:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>Maybe killing all those rats was a bad idea...!</b>";
			break;
		case 45:
			message = "<b>" + zoneName(zone) + "</b>:\n<b>The Final Confrontation. I got nothing funny to say.</b>";
			break;
		case 1000:
			message = "<b>" + zoneName(zone) + "</b>";
			message = message + "\n\nProgress to your next Perk Point:\n<b>" + character.adventure.itopod.pointProgress.ToString("###,###") + " / " + character.adventureController.itopod.pointThreshold().ToString("###,##0") + " (" + ((float)character.adventure.itopod.pointProgress / (float)character.adventureController.itopod.pointThreshold() * 100f).ToString("##0.##") + "%)</b>";
			if (character.adventureController.lootDrop.itopodTier(itopodLevel) < 4)
			{
				message = message + "\nYou will receive your next AP reward in <b>" + lootDrop.killsUntilAP(itopodLevel) + "</b> kills.";
			}
			else
			{
				message = message + "\nYou will receive your next AP and EXP rewards in <b>" + lootDrop.killsUntilAP(itopodLevel) + "</b> kills.";
			}
			if (character.achievements.achievementComplete[145] && character.adventure.itopod.perkLevel[68] >= 1)
			{
				message = message + "\nYou will receive your next MacGuffin drop in <b>" + character.display(lootDrop.killsUntilMacguffin()) + "</b> kills.";
			}
			message = message + "\nHighest floor reached on the I.T.O.P.O.D: <b>" + character.adventure.highestItopodLevel + "</b>";
			break;
		default:
			message = "4G has goofed. Go alert him!";
			break;
		}
		message = message + "\n<b>Zone Kill Counter:</b> " + character.display(globalKillCounter);
		tooltip.showTooltip(message);
	}

	public void repeatShowTooltip()
	{
		InvokeRepeating("zoneDescriptions", 0f, 1f);
	}

	public void tooltipHide()
	{
		tooltip.hideTooltip();
		CancelInvoke("zoneDescriptions");
	}

	public void constructDropdown()
	{
		List<string> list = new List<string>();
		zoneDropdown.ClearOptions();
		list.Add("Safe Zone: Awakening Site");
		list.Add("Tutorial Zone");
		if (character.effectiveBossID() >= 7)
		{
			list.Add("Sewers");
		}
		if (character.effectiveBossID() >= 17)
		{
			list.Add("Forest");
		}
		if (character.effectiveBossID() >= 37)
		{
			list.Add("Cave of Many Things");
		}
		if (character.effectiveBossID() >= 48)
		{
			list.Add("The Sky");
		}
		if (character.effectiveBossID() >= 58)
		{
			list.Add("High Security Base");
		}
		if (character.effectiveBossID() >= 58)
		{
			list.Add("GORDON RAMSAY BOLTON");
		}
		if (character.effectiveBossID() >= 66)
		{
			list.Add("Clockwork Dimension");
		}
		if (character.effectiveBossID() >= 66)
		{
			list.Add("GRAND CORRUPTED TREE");
		}
		if (character.effectiveBossID() >= 74)
		{
			list.Add("2D Universe");
		}
		if (character.effectiveBossID() >= 82)
		{
			list.Add("Ancient Battlefield");
		}
		if (character.effectiveBossID() >= 82)
		{
			list.Add("JAKE FROM ACCOUNTING");
		}
		if (character.effectiveBossID() >= 90)
		{
			list.Add("A Very Strange Place");
		}
		if (character.effectiveBossID() >= 100)
		{
			list.Add("Mega Lands");
		}
		if (character.effectiveBossID() >= 100)
		{
			list.Add("UUG THE UNMENTIONABLE");
		}
		if (character.effectiveBossID() >= 108)
		{
			list.Add("The Beardverse");
		}
		if (character.effectiveBossID() >= 116)
		{
			list.Add("WALDERP");
		}
		if (character.effectiveBossID() >= 116)
		{
			list.Add("Badly Drawn World");
		}
		if (character.effectiveBossID() >= 124)
		{
			list.Add("Boring-Ass Earth");
		}
		if (character.effectiveBossID() >= 132)
		{
			list.Add("THE BEAST");
		}
		if (character.effectiveBossID() >= 137)
		{
			list.Add("Chocolate World");
		}
		if (character.effectiveBossID() >= 359)
		{
			list.Add("The Evilverse");
		}
		if (character.effectiveBossID() >= 401)
		{
			list.Add("Pretty Pink Princess Land");
		}
		if (character.effectiveBossID() >= 426)
		{
			list.Add("GREASY NERD");
		}
		if (character.effectiveBossID() >= 459)
		{
			list.Add("Meta Land");
		}
		if (character.effectiveBossID() >= 467)
		{
			list.Add("Interdimensional Party");
		}
		if (character.effectiveBossID() >= 467)
		{
			list.Add("THE GODMOTHER");
		}
		if (character.effectiveBossID() >= 475)
		{
			list.Add("Typo Zonw");
		}
		if (character.effectiveBossID() >= 483)
		{
			list.Add("Land of Eternal 90's");
		}
		if (character.effectiveBossID() >= 491)
		{
			list.Add("Jayarpegee");
		}
		if (character.effectiveBossID() >= 491)
		{
			list.Add("The EXILE");
		}
		if (character.effectiveBossID() >= 501)
		{
			list.Add("The Rad Lands");
		}
		if (character.effectiveBossID() >= 727)
		{
			list.Add("Bach To School");
		}
		if (character.effectiveBossID() >= 752)
		{
			list.Add("The West World");
		}
		if (character.effectiveBossID() >= 777)
		{
			list.Add("IT HUNGERS");
		}
		if (character.effectiveBossID() >= 810)
		{
			list.Add("Breadverse");
		}
		if (character.effectiveBossID() >= 818)
		{
			list.Add("That 70's Zone");
		}
		if (character.effectiveBossID() >= 826)
		{
			list.Add("Halloweenies");
		}
		if (character.effectiveBossID() >= 826)
		{
			list.Add("ROCK LOBSTER");
		}
		if (character.effectiveBossID() >= 834)
		{
			list.Add("Constrion Zone");
		}
		if (character.effectiveBossID() >= 842)
		{
			list.Add("DUCKS");
		}
		if (character.effectiveBossID() >= 850)
		{
			list.Add("The Nether Region");
		}
		if (character.effectiveBossID() >= 850)
		{
			list.Add("AMALGAMATE");
		}
		if (character.effectiveBossID() >= 871)
		{
			list.Add("The 7 Aethereal Seas");
		}
		if (character.effectiveBossID() >= 897)
		{
			list.Add("TIPPI THE TUTORIAL MOUSE");
		}
		if (character.effectiveBossID() >= 902 && character.adventure.ratTitanDefeated)
		{
			list.Add("THE TRAITOR");
		}
		zoneDropdown.AddOptions(list);
		zoneDropdown.captionText.text = "<b>" + zoneName(zone) + "</b>";
		for (int i = 0; i < zoneDropdown.options.Count; i++)
		{
			string text = zoneName(i - 1);
			if (i == zone + 1)
			{
				text = "<b>" + text + "</b>";
				zoneDropdown.options[i].image = checkSprite;
			}
			else
			{
				zoneDropdown.options[i].image = emptySprite;
			}
			zoneDropdown.options[i].text = text;
		}
	}

	public void updateMenu()
	{
		if (character.menuID == 3)
		{
			zoneTitle.text = zoneName(character.adventure.zone);
			zoneDropdown.captionText.text = zoneName(character.adventure.zone);
			constructDropdown();
			idleAttackMove.checkIdleAttackState();
			updateEnemyPortrait();
			updateItopodInputText();
			updatePillUI();
			updateShifterUI();
			updateTitanDifficultyUI();
			if (character.settings.itopodOn)
			{
				enterItopodButton.gameObject.SetActive(value: true);
				itopodPerksButton.gameObject.SetActive(value: true);
			}
			else
			{
				enterItopodButton.gameObject.SetActive(value: false);
				itopodPerksButton.gameObject.SetActive(value: false);
			}
		}
	}

	public void verifyItopodInputs()
	{
		int num = int.Parse(itopodStartInput.text);
		if (num > character.adventure.highestItopodLevel - 1)
		{
			num = character.adventure.highestItopodLevel - 1;
		}
		if (num < 0)
		{
			num = 0;
		}
		if (num > maxItopodLevel())
		{
			num = maxItopodLevel();
		}
		character.adventure.itopodStart = num;
		int num2 = int.Parse(itopodEndInput.text);
		if (num2 <= character.adventure.itopodStart)
		{
			num2 = character.adventure.itopodStart;
		}
		if (num2 < 1)
		{
			num2 = 1;
		}
		if (num2 > maxItopodLevel())
		{
			num2 = maxItopodLevel();
		}
		character.adventure.itopodEnd = num2;
		updateItopodInputText();
	}

	public void updateItopodInputText()
	{
		itopodStartInput.text = character.adventure.itopodStart.ToString();
		itopodEndInput.text = character.adventure.itopodEnd.ToString();
	}

	public void hideDropdown()
	{
		zoneDropdown.Hide();
	}

	public void togglePill()
	{
		character.settings.buffedKillsOn = !character.settings.buffedKillsOn;
		updatePillUI();
	}

	public void toggleShifter()
	{
		character.arbitrary.lazyITOPODOn = !character.arbitrary.lazyITOPODOn;
		updateShifterUI();
	}

	public void updatePillUI()
	{
		if (character.settings.buffedKillsOn)
		{
			pillUsed.color = Color.white;
		}
		else
		{
			pillUsed.color = Color.clear;
		}
		pillText.text = "Enable Little Blue Pill\n(" + character.adventure.itopod.buffedKills.ToString("###,##0") + " kills left)";
	}

	public void updateShifterUI()
	{
		if (!character.arbitrary.boughtLazyITOPOD)
		{
			shifterToggle.gameObject.SetActive(value: false);
			return;
		}
		shifterToggle.gameObject.SetActive(value: true);
		if (character.arbitrary.lazyITOPODOn)
		{
			shifterUsed.color = Color.white;
		}
		else
		{
			shifterUsed.color = Color.clear;
		}
		if (UnityEngine.Random.Range(1, 101) == 1)
		{
			shifterText.text = "Use Lazy ITOPOD Shitter";
		}
		else
		{
			shifterText.text = "Use Lazy ITOPOD Shifter";
		}
	}

	public void setOptimalFloor()
	{
		int num = character.calculateBestItopodLevel();
		if (num > character.adventure.highestItopodLevel - 1)
		{
			num = character.adventure.highestItopodLevel - 1;
		}
		itopodStartInput.text = num.ToString();
		itopodEndInput.text = num.ToString();
		verifyItopodInputs();
	}

	public void setMaxFloor()
	{
		int num = character.adventure.highestItopodLevel - 1;
		if (num < 0)
		{
			num = 0;
		}
		itopodStartInput.text = num.ToString();
		verifyItopodInputs();
	}

	public void updateTitanDifficultyUI()
	{
		if (character.menuID != 3)
		{
			return;
		}
		for (int i = 0; i < titanDifficultyButtons.Length; i++)
		{
			titanDifficultyButtons[i].gameObject.SetActive(value: false);
		}
		if (character.arbitrary.advAdvancerBought && character.adventure.zone != 1000 && character.adventure.zone != 6 && character.adventure.zone != 8 && character.adventure.zone != 11 && character.adventure.zone != 14 && character.adventure.zone != 16)
		{
			advAdvancerSetter.gameObject.SetActive(value: true);
		}
		else
		{
			advAdvancerSetter.gameObject.SetActive(value: false);
		}
		if (zone == 19)
		{
			advAdvancerSetter.gameObject.SetActive(value: false);
			for (int j = 0; j < titanDifficultyButtons.Length; j++)
			{
				titanDifficultyButtons[j].gameObject.SetActive(value: true);
			}
			for (int k = 0; k < titanDifficultyButtons.Length; k++)
			{
				if (character.adventure.titan6Version == k)
				{
					titanDifficultyButtons[k].interactable = false;
				}
				else
				{
					titanDifficultyButtons[k].interactable = true;
				}
			}
		}
		if (zone == 23)
		{
			advAdvancerSetter.gameObject.SetActive(value: false);
			for (int l = 0; l < titanDifficultyButtons.Length; l++)
			{
				titanDifficultyButtons[l].gameObject.SetActive(value: true);
			}
			for (int m = 0; m < titanDifficultyButtons.Length; m++)
			{
				if (character.adventure.titan7Version == m)
				{
					titanDifficultyButtons[m].interactable = false;
				}
				else
				{
					titanDifficultyButtons[m].interactable = true;
				}
			}
		}
		if (zone == 26)
		{
			advAdvancerSetter.gameObject.SetActive(value: false);
			for (int n = 0; n < titanDifficultyButtons.Length; n++)
			{
				titanDifficultyButtons[n].gameObject.SetActive(value: true);
			}
			for (int num = 0; num < titanDifficultyButtons.Length; num++)
			{
				if (character.adventure.titan8Version == num)
				{
					titanDifficultyButtons[num].interactable = false;
				}
				else
				{
					titanDifficultyButtons[num].interactable = true;
				}
			}
		}
		if (zone == 30)
		{
			advAdvancerSetter.gameObject.SetActive(value: false);
			for (int num2 = 0; num2 < titanDifficultyButtons.Length; num2++)
			{
				titanDifficultyButtons[num2].gameObject.SetActive(value: true);
			}
			for (int num3 = 0; num3 < titanDifficultyButtons.Length; num3++)
			{
				if (character.adventure.titan9Version == num3)
				{
					titanDifficultyButtons[num3].interactable = false;
				}
				else
				{
					titanDifficultyButtons[num3].interactable = true;
				}
			}
		}
		if (zone == 34)
		{
			advAdvancerSetter.gameObject.SetActive(value: false);
			for (int num4 = 0; num4 < titanDifficultyButtons.Length; num4++)
			{
				titanDifficultyButtons[num4].gameObject.SetActive(value: true);
			}
			for (int num5 = 0; num5 < titanDifficultyButtons.Length; num5++)
			{
				if (character.adventure.titan10Version == num5)
				{
					titanDifficultyButtons[num5].interactable = false;
				}
				else
				{
					titanDifficultyButtons[num5].interactable = true;
				}
			}
		}
		if (zone == 38)
		{
			advAdvancerSetter.gameObject.SetActive(value: false);
			for (int num6 = 0; num6 < titanDifficultyButtons.Length; num6++)
			{
				titanDifficultyButtons[num6].gameObject.SetActive(value: true);
			}
			for (int num7 = 0; num7 < titanDifficultyButtons.Length; num7++)
			{
				if (character.adventure.titan11Version == num7)
				{
					titanDifficultyButtons[num7].interactable = false;
				}
				else
				{
					titanDifficultyButtons[num7].interactable = true;
				}
			}
		}
		if (zone != 42)
		{
			return;
		}
		advAdvancerSetter.gameObject.SetActive(value: false);
		for (int num8 = 0; num8 < titanDifficultyButtons.Length; num8++)
		{
			titanDifficultyButtons[num8].gameObject.SetActive(value: true);
		}
		for (int num9 = 0; num9 < titanDifficultyButtons.Length; num9++)
		{
			if (character.adventure.titan12Version == num9)
			{
				titanDifficultyButtons[num9].interactable = false;
			}
			else
			{
				titanDifficultyButtons[num9].interactable = true;
			}
		}
	}

	public void changeTitanDifficulty(int newID)
	{
		if (newID >= 0 && newID <= 3)
		{
			if (zone == 19)
			{
				character.adventure.titan6Version = newID;
				updateTitanDifficultyUI();
			}
			if (zone == 23)
			{
				character.adventure.titan7Version = newID;
				updateTitanDifficultyUI();
			}
			if (zone == 26)
			{
				character.adventure.titan8Version = newID;
				updateTitanDifficultyUI();
			}
			if (zone == 30)
			{
				character.adventure.titan9Version = newID;
				updateTitanDifficultyUI();
			}
			if (zone == 34)
			{
				character.adventure.titan10Version = newID;
				updateTitanDifficultyUI();
			}
			if (zone == 38)
			{
				character.adventure.titan11Version = newID;
				updateTitanDifficultyUI();
			}
			if (zone == 42)
			{
				character.adventure.titan12Version = newID;
				updateTitanDifficultyUI();
			}
		}
	}

	public bool autokillTitan6V1Achieved()
	{
		if (character.totalAdvAttack() >= 2.5E+09f && character.totalAdvDefense() >= 1.6E+09f && character.totalAdvHPRegen() >= 25000000f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan6V2Achieved()
	{
		if (character.totalAdvAttack() >= 2.5E+10f && character.totalAdvDefense() >= 1.6E+10f && character.totalAdvHPRegen() >= 250000000f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan6V3Achieved()
	{
		if (character.totalAdvAttack() >= 2.5E+11f && character.totalAdvDefense() >= 1.6E+11f && character.totalAdvHPRegen() >= 2.5E+09f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan6V4Achieved()
	{
		if (character.totalAdvAttack() >= 2.5E+12f && character.totalAdvDefense() >= 1.6E+12f && character.totalAdvHPRegen() >= 2.5E+10f)
		{
			return true;
		}
		return false;
	}

	public string beastAutokillRequirements()
	{
		switch (character.adventure.titan6Version)
		{
		case 0:
			return character.display(2500000000.0) + " Power, " + character.display(1600000000.0) + " Toughness, " + character.display(25000000.0) + "Health Regen.";
		case 1:
			return character.display(25000000000.0) + " Power, " + character.display(16000000000.0) + " Toughness, " + character.display(250000000.0) + " Health Regen.";
		case 2:
			return character.display(250000000000.0) + " Power, " + character.display(160000000000.0) + " Toughness, " + character.display(2500000000.0) + " Health Regen.";
		case 3:
			return character.display(2500000000000.0) + " Power, " + character.display(1599999967232.0) + " Toughness, " + character.display(24999999488.0) + " Health Regen.";
		default:
			return " Well this sure is a bug. Go and fetch 4G again.";
		}
	}

	public string nerdAutokillRequirements()
	{
		switch (character.adventure.titan7Version)
		{
		case 0:
			return character.display(500000000000000.0) + " Power, " + character.display(249999996747776.0) + " Toughness, " + character.display(4999999913984.0) + " Health Regen.";
		case 1:
			return character.display(10000000000000000.0) + " Power, " + character.display(5000000136282112.0) + " Toughness, " + character.display(100000000376832.0) + " Health Regen.";
		case 2:
			return character.display(2E+17) + " Power, " + character.display(1E+17) + " Toughness, " + character.display(1999999973982208.0) + " Health Regen.";
		case 3:
			return character.display(5E+18) + " Power, " + character.display(2.499999995126612E+18) + " Toughness, " + character.display(49999999215337470.0) + " Health Regen.";
		default:
			return " Well this sure is a bug. Go and fetch 4G again.";
		}
	}

	public string godmotherAutokillRequirements()
	{
		switch (character.adventure.titan8Version)
		{
		case 0:
			return character.display(5E+18) + " Power, " + character.display(2.499999995126612E+18) + " Toughness, " + character.display(49999999215337470.0) + " Health Regen.";
		case 1:
			return character.display(1E+20) + " Power, " + character.display(5.000000100204387E+19) + " Toughness, " + character.display(9.999999843067494E+17) + " Health Regen.";
		case 2:
			return character.display(2E+21) + " Power, " + character.display(1E+21) + " Toughness, " + character.display(1.9999999961012896E+19) + " Health Regen.";
		case 3:
			return character.display(5E+22) + " Power, " + character.display(2.499999944549077E+22) + " Toughness, " + character.display(5.000000100204387E+20) + " Health Regen.";
		default:
			return " Well this sure is a bug. Go and fetch 4G again.";
		}
	}

	public string exileAutokillRequirements()
	{
		switch (character.adventure.titan9Version)
		{
		case 0:
			return character.display(1E+23) + " Power, " + character.display(4.999999889098154E+22) + " Toughness, " + character.display(1.0000000200408773E+21) + " Health Regen.";
		case 1:
			return character.display(2E+24) + " Power, " + character.display(1.0000000138484279E+24) + " Toughness, " + character.display(1.9999999556392617E+22) + " Health Regen.";
		case 2:
			return character.display(4E+25) + " Power, " + character.display(2E+25) + " Toughness, " + character.display(3.9999999112785233E+23) + " Health Regen.";
		case 3:
			return character.display(7.5E+26) + " Power, " + character.display(3.69999996477007E+26) + " Toughness, " + character.display(7.499999959748021E+24) + " Health Regen.";
		default:
			return " Well this sure is a bug. Go and fetch 4G again.";
		}
	}

	public string itHungersAutokillRequirements()
	{
		switch (character.adventure.titan10Version)
		{
		case 0:
			return character.display(4E+28) + " Power, " + character.display(1.999999888423938E+28) + " Toughness, " + character.display(4.0000001015105716E+26) + " Health Regen.";
		case 1:
			return character.display(3.2E+29) + " Power, " + character.display(1.5999999107391504E+29) + " Toughness, " + character.display(1.6000000406042286E+27) + " Health Regen.";
		case 2:
			return character.display(2E+30) + " Power, " + character.display(1E+30) + " Toughness, " + character.display(9.99999944211969E+27) + " Health Regen.";
		case 3:
			return character.display(1E+31) + " Power, " + character.display(4.9999999241216036E+30) + " Toughness, " + character.display(5.000000075237331E+28) + " Health Regen.";
		default:
			return " Well this sure is a bug. Go and fetch 4G again.";
		}
	}

	public string rockLobsterAutokillRequirements()
	{
		switch (character.adventure.titan11Version)
		{
		case 0:
			return character.display(1.7999999968622937E+31) + " Power, " + character.display(5.999999788053342E+30) + " Toughness, " + character.display(1.1999999802780276E+29) + " Health Regen.";
		case 1:
			return character.display(9.00000010520405E+31) + " Power, " + character.display(2.999999954472962E+31) + " Toughness, " + character.display(6.000000090284797E+29) + " Health Regen.";
		case 2:
			return character.display(3.60000004208162E+32) + " Power, " + character.display(1.1999999817891849E+32) + " Toughness, " + character.display(2.4999999620608018E+30) + " Health Regen.";
		case 3:
			return character.display(1.1000000171566758E+33) + " Power, " + character.display(3.60000004208162E+32) + " Toughness, " + character.display(7.499999886182405E+30) + " Health Regen.";
		default:
			return " Well this sure is a bug. Go and fetch 4G again.";
		}
	}

	public string amalgamateAutokillRequirements()
	{
		switch (character.adventure.titan12Version)
		{
		case 0:
			return character.display(3.0000000608584343E+33) + " Power, " + character.display(9.999999944957273E+32) + " Toughness, " + character.display(1.9999999696486415E+31) + " Health Regen.";
		case 1:
			return character.display(1.2000000243433737E+34) + " Power, " + character.display(3.999999977982909E+33) + " Toughness, " + character.display(7.999999878594566E+31) + " Health Regen.";
		case 2:
			return character.display(3.5999999492361172E+34) + " Power, " + character.display(1.2000000243433737E+34) + " Toughness, " + character.display(2.3999999635783698E+32) + " Health Regen.";
		case 3:
			return character.display(7.1999998984722345E+34) + " Power, " + character.display(2.4000000486867475E+34) + " Toughness, " + character.display(4.7999999271567395E+32) + " Health Regen.";
		default:
			return " Well this sure is a bug. Go and fetch 4G again.";
		}
	}

	public string beastLootRates()
	{
		return "<b>Main Set Drop Chance: </b>" + character.lootChanceDisplay(0.0005f);
	}

	public string nerdLootRates()
	{
		return "<b>Main Set Drop Chance: </b>" + character.lootChanceDisplayRooted(0.00035f, 25f) + "\n<b>V2 Drops: </b>" + character.lootChanceDisplayRooted(0.00027f, 25f) + "\n<b>V3 Drops: </b>" + character.lootChanceDisplayRooted(0.00022f, 25f) + "\n<b>V4 Drops: </b>" + character.lootChanceDisplayRooted(0.00017f, 25f);
	}

	public string godmotherLootRates()
	{
		return "<b>Main Set Drop Chance: </b>" + character.lootChanceDisplayRooted(0.0001f, 25f) + "\n<b>V2 Drops: </b>" + character.lootChanceDisplayRooted(7.5E-05f, 25f) + "\n<b>V3 Drops: </b>" + character.lootChanceDisplayRooted(6E-05f, 25f) + "\n<b>V4 Drops: </b>" + character.lootChanceDisplayRooted(4.5E-05f, 25f);
	}

	public string exileLootRates()
	{
		return "<b>Main Set Drop Chance: </b>" + character.lootChanceDisplayRooted(2E-05f, 25f) + "\n<b>V2 Drops: </b>" + character.lootChanceDisplayRooted(1E-05f, 25f) + "\n<b>V3 Drops: </b>" + character.lootChanceDisplayRooted(6E-06f, 25f) + "\n<b>V4 Drops: </b>" + character.lootChanceDisplayRooted(4E-06f, 25f);
	}

	public string itHungersLootRates()
	{
		return "<b>Main Set Drop Chance: </b>" + character.lootChanceDisplayRooted(1E-06f, 25f) + "\n<b>V2 Drops: </b>" + character.lootChanceDisplayRooted(6E-07f, 25f) + "\n<b>V3 Drops: </b>" + character.lootChanceDisplayRooted(4E-07f, 25f) + "\n<b>V4 Drops: </b>" + character.lootChanceDisplayRooted(3E-07f, 25f);
	}

	public string rockLobsterLootRates()
	{
		return "<b>Main Set Drop Chance: </b>" + character.lootChanceDisplayRooted(1E-07f, 25f) + "\n<b>V2 Drops: </b>" + character.lootChanceDisplayRooted(6.5E-08f, 25f) + "\n<b>V3 Drops: </b>" + character.lootChanceDisplayRooted(4E-08f, 25f) + "\n<b>V4 Drops: </b>" + character.lootChanceDisplayRooted(3E-08f, 25f);
	}

	public string amalgamateLootRates()
	{
		return "<b>Main Set Drop Chance: </b>" + character.lootChanceDisplayRooted(1.4E-08f, 25f) + "\n<b>V2 Drops: </b>" + character.lootChanceDisplayRooted(1E-08f, 25f) + "\n<b>V3 Drops: </b>" + character.lootChanceDisplayRooted(8E-09f, 25f) + "\n<b>V4 Drops: </b>" + character.lootChanceDisplayRooted(6E-09f, 25f);
	}

	public float beastModeBonus()
	{
		float num = 1f;
		if (character.adventure.beastModeOn)
		{
			num = ((!character.inventory.itemList.purpleLiquidComplete) ? (num * 1.4f) : (num * 1.5f));
		}
		return num;
	}

	public bool hasBeastMode()
	{
		return character.settings.beastModeUnlocked;
	}

	public void activateLazyItopod()
	{
		int num = itopodLevel;
		setOptimalFloor();
		zoneSelector.changeZone(1000);
		int num2 = itopodLevel;
		if (num != num2)
		{
			log.AddEvent("The ITOPOD Floor Shifter changed your current floor from " + num + " to " + num2 + ".");
		}
	}

	public bool autokillTitan7V1Achieved()
	{
		if (character.totalAdvAttack() >= 5E+14f && character.totalAdvDefense() >= 2.5E+14f && character.totalAdvHPRegen() >= 5E+12f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan7V2Achieved()
	{
		if (character.totalAdvAttack() >= 1E+16f && character.totalAdvDefense() >= 5E+15f && character.totalAdvHPRegen() >= 1E+14f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan7V3Achieved()
	{
		if (character.totalAdvAttack() >= 2E+17f && character.totalAdvDefense() >= 1E+17f && character.totalAdvHPRegen() >= 2E+15f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan7V4Achieved()
	{
		if (character.totalAdvAttack() >= 5E+18f && character.totalAdvDefense() >= 2.5E+18f && character.totalAdvHPRegen() >= 5E+16f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan8V1Achieved()
	{
		if (character.totalAdvAttack() >= 5E+18f && character.totalAdvDefense() >= 2.5E+18f && character.totalAdvHPRegen() >= 5E+16f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan8V2Achieved()
	{
		if (character.totalAdvAttack() >= 1E+20f && character.totalAdvDefense() >= 5E+19f && character.totalAdvHPRegen() >= 1E+18f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan8V3Achieved()
	{
		if (character.totalAdvAttack() >= 2E+21f && character.totalAdvDefense() >= 1E+21f && character.totalAdvHPRegen() >= 2E+19f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan8V4Achieved()
	{
		if (character.totalAdvAttack() >= 5E+22f && character.totalAdvDefense() >= 2.5E+22f && character.totalAdvHPRegen() >= 5E+20f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan9V1Achieved()
	{
		if (character.bestiary.enemies[344].kills >= 24)
		{
			return true;
		}
		if (character.totalAdvAttack() >= 1E+23f && character.totalAdvDefense() >= 5E+22f && character.totalAdvHPRegen() >= 1E+21f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan9V2Achieved()
	{
		if (character.bestiary.enemies[345].kills >= 24)
		{
			return true;
		}
		if (character.totalAdvAttack() >= 2E+24f && character.totalAdvDefense() >= 1E+24f && character.totalAdvHPRegen() >= 2E+22f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan9V3Achieved()
	{
		if (character.bestiary.enemies[346].kills >= 24)
		{
			return true;
		}
		if (character.totalAdvAttack() >= 4E+25f && character.totalAdvDefense() >= 2E+25f && character.totalAdvHPRegen() >= 4E+23f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan9V4Achieved()
	{
		if (character.bestiary.enemies[347].kills >= 24)
		{
			return true;
		}
		if (character.totalAdvAttack() >= 7.5E+26f && character.totalAdvDefense() >= 3.7E+26f && character.totalAdvHPRegen() >= 7.5E+24f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan10V1Achieved()
	{
		if (character.bestiary.enemies[365].kills > 4)
		{
			return true;
		}
		if (character.totalAdvAttack() >= 4E+28f && character.totalAdvDefense() >= 2E+28f && character.totalAdvHPRegen() >= 4E+26f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan10V2Achieved()
	{
		if (character.bestiary.enemies[366].kills > 4)
		{
			return true;
		}
		if (character.totalAdvAttack() >= 3.2E+29f && character.totalAdvDefense() >= 1.6E+29f && character.totalAdvHPRegen() >= 1.6E+27f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan10V3Achieved()
	{
		if (character.bestiary.enemies[367].kills > 4)
		{
			return true;
		}
		if (character.totalAdvAttack() >= 2E+30f && character.totalAdvDefense() >= 1E+30f && character.totalAdvHPRegen() >= 1E+28f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan10V4Achieved()
	{
		if (character.bestiary.enemies[368].kills > 4)
		{
			return true;
		}
		if (character.totalAdvAttack() >= 1E+31f && character.totalAdvDefense() >= 5E+30f && character.totalAdvHPRegen() >= 5E+28f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan11V1Achieved()
	{
		if (character.bestiary.enemies[369].kills > 4)
		{
			return true;
		}
		if (character.totalAdvAttack() >= 1.8E+31f && character.totalAdvDefense() >= 6E+30f && character.totalAdvHPRegen() >= 1.2E+29f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan11V2Achieved()
	{
		if (character.bestiary.enemies[370].kills > 4)
		{
			return true;
		}
		if (character.totalAdvAttack() >= 9E+31f && character.totalAdvDefense() >= 3E+31f && character.totalAdvHPRegen() >= 6E+29f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan11V3Achieved()
	{
		if (character.bestiary.enemies[371].kills > 4)
		{
			return true;
		}
		if (character.totalAdvAttack() >= 3.6E+32f && character.totalAdvDefense() >= 1.2E+32f && character.totalAdvHPRegen() >= 2.5E+30f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan11V4Achieved()
	{
		if (character.bestiary.enemies[372].kills > 4)
		{
			return true;
		}
		if (character.totalAdvAttack() >= 1.1E+33f && character.totalAdvDefense() >= 3.6E+32f && character.totalAdvHPRegen() >= 7.5E+30f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan12V1Achieved()
	{
		if (character.bestiary.enemies[373].kills > 4)
		{
			return true;
		}
		if (character.totalAdvAttack() >= 3E+33f && character.totalAdvDefense() >= 1E+33f && character.totalAdvHPRegen() >= 2E+31f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan12V2Achieved()
	{
		if (character.bestiary.enemies[374].kills > 4)
		{
			return true;
		}
		if (character.totalAdvAttack() >= 1.2E+34f && character.totalAdvDefense() >= 4E+33f && character.totalAdvHPRegen() >= 8E+31f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan12V3Achieved()
	{
		if (character.bestiary.enemies[375].kills > 4)
		{
			return true;
		}
		if (character.totalAdvAttack() >= 3.6E+34f && character.totalAdvDefense() >= 1.2E+34f && character.totalAdvHPRegen() >= 2.4E+32f)
		{
			return true;
		}
		return false;
	}

	public bool autokillTitan12V4Achieved()
	{
		if (character.bestiary.enemies[376].kills > 4)
		{
			return true;
		}
		if (character.totalAdvAttack() >= 7.2E+34f && character.totalAdvDefense() >= 2.4E+34f && character.totalAdvHPRegen() >= 4.8E+32f)
		{
			return true;
		}
		return false;
	}

	public string fetchEnemyNamebySpriteID(int spriteID)
	{
		foreach (List<Enemy> enemy in enemyList)
		{
			foreach (Enemy item in enemy)
			{
				if (item.spriteID == spriteID)
				{
					return item.name;
				}
			}
		}
		return "";
	}

	public void setNewMaxZone()
	{
		if (character.arbitrary.advAdvancerBought && character.adventure.zone != 1000 && character.adventure.zone >= 0)
		{
			tooltip.showTooltip("You have set your Adventure Autoadvancer max zone to this zone!", 2f);
			character.arbitrary.advAdvancerZone = character.adventure.zone;
		}
		else
		{
			tooltip.showOverrideTooltip("You can't set the Adventure autoadvancer to this zone!", 4f);
		}
	}
}
