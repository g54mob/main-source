using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class UpgradeMgr : SerializedMonoBehaviour
{
	public static UpgradeMgr I;

	[Header("Loc")]
	[NamedArray(typeof(PropertyType))]
	public string[] PropertySlugs;

	[NamedArray(typeof(PropertyType))]
	public string[] PropertyLabels;

	[NamedArray(typeof(StatType))]
	public string[] StatSlugs;

	[NamedArray(typeof(StatType))]
	public string[] StatLabels;

	[NamedArray(typeof(StatPropType))]
	public string[] StatPropertyLabels;

	[NamedArray(typeof(StatType))]
	public string[] StatEffectLabels;

	[Header("Crv")]
	[NamedArray(typeof(StatCrvType))]
	public AnimationCurve[] CrvStatWeight;

	[NamedArray(typeof(StatCrvType))]
	public float[][] StatLvlWeight;

	[Header("Runtime")]
	public float DefenseMult;

	public float HeroDamageMult;

	public float AOEDamageMult;

	public float StatusEffectDamageMult;

	public float StatusEffectLengthMult;

	public float PassivePowerMult;

	public float BackCritChance;

	public float RightCritChance;

	public float LeftCritChance;

	public float FrontCritChance;

	public CharInfo CurChar;

	public List<CharInfo> ComboChars;

	public int MaxHealth;

	public int BonusHeroDamage;

	public int NumFollowers;

	public int BaseNumFollowers;

	public int NumMultiHeroes;

	public int FollowerDamageMin;

	public int FollowerDamageMax;

	public int BonusFollowerDamageMin;

	public int BonusFollowerDamageMax;

	public float MoveSpeed;

	public float MoveSpeedWhileShooting;

	public float BaseSpeed;

	public float PeakSpeed;

	public float Acceleration;

	public float CritChance;

	public float CritMultiplier;

	public float FireRate;

	public float ReloadTime;

	public float BallReturnSpeed;

	public float BounceBonusDamagePct;

	public float EachBabyBallBonusDmgPct;

	public float PickupRange;

	public float BonusCatchRange;

	public float BonusXPDropped;

	public float BonusGoldDropped;

	public float BonusCharXP;

	public float DamageReduction;

	public int ThornsAmt;

	public float DodgeChance;

	public float ProjSpeedMult;

	public int SelfDamagePerShot;

	public int HealthPerKill;

	public float AimScatter;

	public float BounceScatter;

	public float GemBabyChance;

	public int GemWindBallLvl;

	public float OverhealEfficiency;

	public float WallBonusDamagePct;

	public float NonWallBonusDamagePct;

	public float NonBackBonusDamagePct;

	public bool IsEthereal;

	public int MinCatchBabies;

	public int MaxCatchBabies;

	public float ShootKnockbackAmt;

	public float MaxDecayingDamagePct;

	public float DamageDecayPerBounce;

	public float MinDecayingDamagePct;

	public float AllyHealthMult;

	public float ColumnSlowPct;

	public float PoisonZombieChance;

	public int MinHealBabies;

	public int MaxHealBabies;

	public int MinFrozenSpikeDamage;

	public int MaxFrozenSpikeDamage;

	public int MinBonusFireBallDamage;

	public int MaxBonusFireBallDamage;

	public bool PierceAllies;

	public int AllyPierceHeal;

	public float AllyPierceHealChance;

	public int AllyHitSelfHeal;

	public int ProjHealAmt;

	public float ProjHealChance;

	public float ProjReflectChance;

	public int ProjArrowReflectMin;

	public int ProjArrowReflectMax;

	public float OnionRange;

	public int OnionMinDamage;

	public int OnionMaxDamage;

	[NonSerialized]
	public PassiveInst BabyRattlePassive;

	[NonSerialized]
	public PassiveInst UpturnedHatchetPassive;

	public float BallDamageMult;

	public float EachEnemyBonusDmgPct;

	public float CurseKillChance;

	public float CharmKillChance;

	public float BlindCritChance;

	public float ColCritChance;

	public float DetectKillChance;

	public float TouchKillChance;

	public float ShieldCooldownLength;

	public bool IsSideGhost;

	public int CritBonusDamageMin;

	public int CritBonusDamageMax;

	public int CorpseExplodeDamageMin;

	public int CorpseExplodeDamageMax;

	public int CorpseBombLvl;

	public float EtherealDamagePct;

	public float GhostDamagePct;

	public float SideGhostDamagePct;

	public int MinCornucopiaBabies;

	public int MaxCornucopiaBabies;

	public float CritKillChance;

	public bool AvoidObstacles;

	public float BounceRandomDamage;

	[NonSerialized]
	public PassiveInst SpikedCollarPassive;

	public int TgtXP;

	public DelegateUtl.NoArgsEvent OnHeroesChanged;

	public DelegateUtl.NoArgsEvent OnPassivesChanged;

	public const int kEnduranceHealthFactor = 10;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void CalculateStats()
	{
	}

	public int GetCurStat(StatType st)
	{
		return 0;
	}

	public float GetStatWeight(StatCrvType st, int lvl)
	{
		return 0f;
	}

	public float GetCurStatWeight(StatType st, StatCrvType crv)
	{
		return 0f;
	}

	public void CalculateTgtXP()
	{
	}

	public void ApplyUpgrade(UpgradeChoice c)
	{
	}

	public bool HasUncombinedUpgrade(UpgradeInfo inf)
	{
		return false;
	}

	public void RemoveUpgrade(UpgradeInfo inf, int parentId)
	{
	}

	public void RemoveMergeComponents(UpgradeInfo inf, int evoIdx, int parentId)
	{
	}

	public void CombineHeroes(HeroCombo combo)
	{
	}

	public void AddHero(HeroType ht, int evoIdx = 0)
	{
	}

	public HeroInst GetHero(HeroType ht)
	{
		return null;
	}

	private void RefreshFollowerOrder()
	{
	}

	public int GetSoloHeroIdx(HeroType ht)
	{
		return 0;
	}

	public HeroInst GetUpgradableHero(HeroType ht)
	{
		return null;
	}

	public PassiveInst GetPassive(PassiveType pt)
	{
		return null;
	}

	public void LogPassiveBonusDamage(PassiveType pt, int dmg)
	{
	}

	public bool HasPassive(PassiveType pt)
	{
		return false;
	}

	public bool HasHitEffect(StatusEffectType hf)
	{
		return false;
	}

	public bool HasSpecial(BallSpecialType st, BallSpecialType st2 = BallSpecialType.kNum)
	{
		return false;
	}

	public void SelectChar(CharInfo inf)
	{
	}

	public void SelectCharFusion(CharInfo inf)
	{
	}

	public StatPropDisplayType GetDisplayType(StatPropType pt)
	{
		return default(StatPropDisplayType);
	}

	public int GetStatPropInt(StatPropType pt)
	{
		return 0;
	}

	public int CalculateStatPropInt(StatPropType pt)
	{
		return 0;
	}

	public int CalculateStatPropInt(StatPropType pt, int statVal, StatScaling sc)
	{
		return 0;
	}

	public int CalculateStatPropIntMin(StatPropType pt)
	{
		return 0;
	}

	public int CalculateStatPropIntMin(StatPropType pt, int statVal, StatScaling sc)
	{
		return 0;
	}

	public int GetStatPropIntMax(StatPropType pt)
	{
		return 0;
	}

	public int CalculateStatPropIntMax(StatPropType pt)
	{
		return 0;
	}

	public int CalculateStatPropIntMax(StatPropType pt, int statVal, StatScaling sc)
	{
		return 0;
	}

	public float GetStatPropFloat(StatPropType pt)
	{
		return 0f;
	}

	public float CalculateStatPropFloat(StatPropType pt)
	{
		return 0f;
	}

	public float CalculateStatPropFloat(StatPropType pt, int statVal, StatScaling sc)
	{
		return 0f;
	}

	public string CalculateStatPropStr(StatPropType pt, int statVal, StatScaling sc)
	{
		return null;
	}

	public string GetPropertyLabelSlug(PropertyType pt)
	{
		return null;
	}

	public string GetStatLabelSlug(StatType st)
	{
		return null;
	}

	public string GetStatEffectsSlug(StatType st)
	{
		return null;
	}

	public string GetStatPropLabelSlug(StatPropType spt)
	{
		return null;
	}
}
