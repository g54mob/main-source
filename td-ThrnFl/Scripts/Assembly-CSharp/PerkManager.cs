using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PerkManager : MonoBehaviour
{
	public const int MaxLevel = 1000000;

	public static PerkManager instance;

	[Header("Equippables: ")]
	[SerializeField]
	private List<Equippable> currentlyEquipped;

	public List<Equippable> allEquippables = new List<Equippable>();

	public List<Equippable> countQuestsAsIncompleteWith = new List<Equippable>();

	public Dictionary<Equippable, int> metaLevelByPerk = new Dictionary<Equippable, int>();

	[Header("Leveling system: ")]
	public int xp;

	public int level = 1;

	[SerializeField]
	private List<MetaLevel> metaLevels;

	public int xpNeededToProgressToNextLevelPastMaxMeta = 4000;

	public Equippable trophyPerkForPastMaxMeta;

	public Equippable royalMint;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public int royalMint_startGoldBonus = 1;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float heavyArmor_HpMultiplyer;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float heavyArmor_SpeedMultiplyer;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float heavyArmor_SelfHealMultiplyer;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float godsLotion_RegenRateMultiplyer;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float godsLotion_RegenDelayMultiplyer;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float racingHorse_SpeedMultiplyer;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float gladiatorSchool_TrainingSpeedMultiplyer;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float elliteWarriors_TrainingSpeedMultiplyer;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float tauntTheTiger_damageMultiplyer;

	public Equippable tigerGodPerk;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float tauntTheTurtle_hpMultiplyer;

	public Equippable turtleGodPerk;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float tauntTheFalcon_speedMultiplyer;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float tauntTheFalcon_chasePlayerTimeMultiplyer;

	public Equippable falconGodPerk;

	public Equippable ratGodPerk;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float ratGod_GoldModifyer = 0.5f;

	public Equippable warriorMode;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float warriorModeAllyDmgMulti = 0.5f;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float warriorModeSelfDmgMultiMax = 2f;

	public Equippable commanderMode;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float commanderModeAllyDmgMulti = 1.5f;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float commanderModeSelfDmgMulti = 0.5f;

	public Equippable glassCanon;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float glassCanon_dmgMulti = 1.5f;

	public Equippable healintSpirits;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float healingSpirits_healMulti = 1.5f;

	public Equippable archerySkills;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float archerySkills_projectileSpeedMulti = 1.8f;

	public Equippable iceMagic;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float iceMagic_AdditionalsSlowMutli = 0.75f;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float iceMagic_SlowDurationMulti = 2f;

	public Equippable rangedResistence;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float rangedResistence_AmountMulti = 1.3f;

	public Equippable meleeResistence;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float meleeResistence_AmountMulti = 1.3f;

	[BalancingParameter(BalancingParameter.EType.Percentage)]
	public float powerTower_attackSpeedBonus = 2f;

	public Equippable treasureHunter;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public int treasureHunterGoldAmountWave1 = 10;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public int treasureHunterGoldAmountWave2 = 20;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public int treasureHunterGoldAmountWave3 = 30;

	public Equippable cheeseGod;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float cheeseGod_firstWavesSpawnSpeed = 1.25f;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float cheeseGod_spawnAmountMulti = 2f;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public int cheeseGod_affectedNights = 3;

	public Equippable godOfDeath;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float godOfDeath_playerRespawnMultiplyer = 2f;

	public Equippable destructionGod;

	[BalancingParameter(BalancingParameter.EType.Percentage)]
	public float destructionGodHealthRegen = 0.33f;

	public Equippable tauntThePhoenixGod;

	[BalancingParameter(BalancingParameter.EType.Percentage)]
	public float phoenixGod_HealingPercentagePerSec = 0.2f;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public float phoenixGod_MaxHealingPerSec = 40f;

	public Equippable healthPotions;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public float healthPotion_HealingPerSec = 4f;

	public Equippable antiAirTelescope;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float antiAir_helathMultiplyer = 0.75f;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float antiAir_damageMultiplyer = 0.75f;

	public Equippable strongerHerosActive;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float strongerHeros_healthMutli = 1.4f;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float strongerHeros_damageMulti = 1.4f;

	public Equippable meleeDamage;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float meleeDamage_multi = 1.25f;

	public Equippable rangedDamage;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float rangedDamage_multi = 1.25f;

	public Equippable prayToWarGods;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float prayWarGods_hpMulti = 0.8f;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float prayWarGods_dmgMulti = 0.8f;

	public Equippable spellScroll;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float spellScrollActiveCooldownMulti = 0.65f;

	public Equippable lightMaterials;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float lightMaterialsCooldownMulti = 0.75f;

	public Equippable loan;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public int loanBonusMoney;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public int loanInterestMoney;

	public Equippable riskTaker;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float riskTakerMaxBonusDamageMultiplyer;

	public Equippable eliteTowers;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float eliteTowerDamageMultiplyer;

	public Equippable eliteGod;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public int eliteGodSpawnInterval;

	public Equippable growthGod;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float growthGodMaxDamageMulti;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float growthGodMaxHpMulti;

	public Equippable rangeGod;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float rangeGodRangeMultiplyer;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float rangeGodMoveSpeedMultiplyer;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float rangeGodHealthMultiplyer;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float rangeGodDamageMultiplyer;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float rangeGodAttackCooldownMultiplyer;

	public Equippable godOfChaos;

	public Equippable experienceGain;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float experienceGainPercentage;

	public Equippable outpost;

	public Equippable healingGold;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public float healingGoldHealAmount;

	public Equippable royalProtection;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float royalProtectionDamageTakenMultiplyer;

	public Equippable lastStand;

	[BalancingParameter(BalancingParameter.EType.Percentage)]
	public float lastStandHealthThreshhold;

	public Equippable godOfAfterlife;

	public GameObject godOfAfterlifeEnemy;

	public Equippable godOfChoice;

	public Equippable pacifistPact;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float pacifistAutoAttackMulti = 2f;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float pacifistManualAttackMulti = 2f;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float pacifistHpMulti = 2f;

	public List<Equippable> CurrentlyEquipped => currentlyEquipped;

	public List<MetaLevel> MetaLevels => metaLevels;

	public MetaLevel NextMetaLevel
	{
		get
		{
			if (level - 1 >= metaLevels.Count || level >= 1000000)
			{
				return new MetaLevel(xpNeededToProgressToNextLevelPastMaxMeta, trophyPerkForPastMaxMeta);
			}
			return metaLevels[level - 1];
		}
	}

	public bool RoyalMintActive => IsEquipped(royalMint);

	public bool RatGodActive => IsEquipped(ratGodPerk);

	public bool WarriorModeActive => IsEquipped(warriorMode);

	public bool CommanderModeActive => IsEquipped(commanderMode);

	public bool GlassCanonActive => IsEquipped(glassCanon);

	public bool HealingSpiritsActive => IsEquipped(healintSpirits);

	public bool ArcherySkillsActive => IsEquipped(archerySkills);

	public bool IceMagicActive => IsEquipped(iceMagic);

	public bool RangedResistenceActive => IsEquipped(rangedResistence);

	public bool MeleeResistenceActive => IsEquipped(meleeResistence);

	public bool TreasureHunterActive => IsEquipped(treasureHunter);

	public bool CheeseGodActive => IsEquipped(cheeseGod);

	public bool GodOfDeathActive => IsEquipped(godOfDeath);

	public bool DestructionGodActive => IsEquipped(destructionGod);

	public bool TauntThePhoenixGodActive => IsEquipped(tauntThePhoenixGod);

	public bool HealthPotionsActive => IsEquipped(healthPotions);

	public bool AntiAirTelescope => IsEquipped(antiAirTelescope);

	public bool StrongerHeros => IsEquipped(strongerHerosActive);

	public bool MeleeDamageActive => IsEquipped(meleeDamage);

	public bool RangedDamageActive => IsEquipped(rangedDamage);

	public bool PrayToWarGodsActive => IsEquipped(prayToWarGods);

	public bool SpellScrollActive => IsEquipped(spellScroll);

	public bool LightMaterialsEquipped => IsEquipped(lightMaterials);

	public bool LoanEquipped => IsEquipped(loan);

	public bool RiskTakerEquipped => IsEquipped(riskTaker);

	public bool EliteTowersEquipped => IsEquipped(eliteTowers);

	public bool EliteGodEquipped => IsEquipped(eliteGod);

	public bool GrowthGodEquipped => IsEquipped(growthGod);

	public bool RangeGodEquipped => IsEquipped(rangeGod);

	public bool GodOfChaosEquipped => IsEquipped(godOfChaos);

	public bool ExperienceGainEquipped => IsEquipped(experienceGain);

	public bool OutpostEquipped => IsEquipped(outpost);

	public bool HealingGoldEquipped => IsEquipped(healingGold);

	public bool RoyalProtectionEquipped => IsEquipped(royalProtection);

	public bool LastStandEquipped => IsEquipped(lastStand);

	public bool GodOfAfterlifeEquipped => IsEquipped(godOfAfterlife);

	public bool GodOfChoiceEquipped => IsEquipped(godOfChoice);

	public bool PacifistPactEquipped => IsEquipped(pacifistPact);

	private void Awake()
	{
		if ((bool)instance)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		instance = this;
		Object.DontDestroyOnLoad(base.transform.root.gameObject);
		metaLevelByPerk.Clear();
		for (int i = 0; i < metaLevels.Count; i++)
		{
			if (!metaLevelByPerk.ContainsKey(metaLevels[i].reward))
			{
				metaLevelByPerk.Add(metaLevels[i].reward, i + 1);
			}
		}
		allEquippables = allEquippables.OrderBy((Equippable o) => o.sortingValue).ToList();
	}

	public static bool IsEquipped(Equippable _perk)
	{
		if (!instance)
		{
			return false;
		}
		if (_perk == null)
		{
			return false;
		}
		return instance.currentlyEquipped.Contains(_perk);
	}

	public static void SetEquipped(Equippable _perk, bool _equipped)
	{
		if (!instance)
		{
			return;
		}
		if (_equipped)
		{
			if (!instance.currentlyEquipped.Contains(_perk))
			{
				instance.currentlyEquipped.Add(_perk);
			}
		}
		else if (instance.currentlyEquipped.Contains(_perk))
		{
			instance.currentlyEquipped.Remove(_perk);
		}
	}

	public static void ClearAllEquipped()
	{
		if ((bool)instance)
		{
			instance.currentlyEquipped.Clear();
		}
	}
}
