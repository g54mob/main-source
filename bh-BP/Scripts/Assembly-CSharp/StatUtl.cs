public static class StatUtl
{
	public const float kBurnCycleLen = 1f;

	public const float kPoisonCycleLen = 1f;

	private static readonly int[] kBossBlueprintGotThresholds;

	private static readonly int[] kBossBlueprintMultipliers;

	private static readonly int[] kFuserBlueprintGotThresholds;

	private static readonly int[] kFuserBlueprintMultipliers;

	public static int GetHeroDamageMin(int lvl = 0)
	{
		return 0;
	}

	public static int GetHeroDamageMax(int lvl = 0)
	{
		return 0;
	}

	public static int GetFollowerDamageMin()
	{
		return 0;
	}

	public static int GetFollowerDamageMax()
	{
		return 0;
	}

	public static int GetBattleTgtXP(int lvl)
	{
		return 0;
	}

	public static bool IsBomb(this PickupType pt)
	{
		return false;
	}

	public static PropertyType GetRangePropMax(this PropertyType pt)
	{
		return default(PropertyType);
	}

	public static bool IsRangePropMin(this PropertyType pt)
	{
		return false;
	}

	public static bool IsRangePropMax(this PropertyType pt)
	{
		return false;
	}

	public static bool IsHeroDamageProp(this PropertyType pt)
	{
		return false;
	}

	public static bool IsDefenseProp(this PropertyType pt)
	{
		return false;
	}

	public static bool IsAOEDamageProp(this PropertyType pt)
	{
		return false;
	}

	public static bool IsStatusEffectDamageProp(this PropertyType pt)
	{
		return false;
	}

	public static bool IsMosquitoDamageProp(this PropertyType pt)
	{
		return false;
	}

	public static bool IsStatusEffectLenProp(this PropertyType pt)
	{
		return false;
	}

	public static bool IsPassivePowerProp(this PropertyType pt, PassiveType passive)
	{
		return false;
	}

	public static HeroInfo GetInfo(this HeroType ht)
	{
		return null;
	}

	public static PassiveInfo GetInfo(this PassiveType pt)
	{
		return null;
	}

	public static DamageType GetDmgType(this StatusEffectType ef)
	{
		return default(DamageType);
	}

	public static bool IsFreezeEffect(this StatusEffectType ef)
	{
		return false;
	}

	public static string GetPropertyStr(PropertyType pt, int val)
	{
		return null;
	}

	public static string FormatPct(string number)
	{
		return null;
	}

	public static bool IsBirther(this HeroType ht)
	{
		return false;
	}

	public static int GetPassiveComboModifierPct(this PassiveType t)
	{
		return 0;
	}

	public static float GetPassiveComboModifier(this PassiveType t)
	{
		return 0f;
	}

	public static float GetScalingMult(this StatScaling sc)
	{
		return 0f;
	}

	public static string GetScalingStr(this StatScaling sc)
	{
		return null;
	}

	public static StatType GetScalingStat(this StatPropType sp)
	{
		return default(StatType);
	}

	public static int GetNumRelatedProps(this StatType t, CharType cType)
	{
		return 0;
	}

	public static bool IsBoss(this GridPieceType p)
	{
		return false;
	}

	public static bool IsRider(this GridPieceType p)
	{
		return false;
	}

	public static bool IsDynamite(this GridPieceType p)
	{
		return false;
	}

	public static GridPieceType GetRiderType(this GridPieceType p)
	{
		return default(GridPieceType);
	}

	public static bool CanBeStacked(this GridPieceType p)
	{
		return false;
	}

	public static bool IsPassivePiece(this GridPieceType p)
	{
		return false;
	}

	public static bool IsGhostly(this GridPieceType p)
	{
		return false;
	}

	public static bool IsFriendlyEnemy(this GridPieceType p)
	{
		return false;
	}

	public static bool IsAlly(this GridPieceType p)
	{
		return false;
	}

	public static bool IsStoneAlly(this GridPieceType p)
	{
		return false;
	}

	public static bool IsEndBoss(this GridPieceType p)
	{
		return false;
	}

	public static bool ShouldNotHit(this GridPieceType p)
	{
		return false;
	}

	public static PassiveType GetPassiveSource(this GridPieceType p)
	{
		return default(PassiveType);
	}

	public static GridPieceType GetPassivePiece(this PassiveType p)
	{
		return default(GridPieceType);
	}

	public static int GetMaxHeroes()
	{
		return 0;
	}

	public static int GetMaxPassives()
	{
		return 0;
	}

	public static int GetTgtBossesForNumBlueprints(int numBlueprintsGot)
	{
		return 0;
	}

	public static int GetTgtLvlsCompleteForNumBlueprints(int numBlueprintsGot, InfoDB db)
	{
		return 0;
	}

	public static int GetTgtLvlsCompleteForNumBlueprints(int numBlueprintsGot)
	{
		return 0;
	}

	public static int GetTgtFusersForNumBlueprints(int numBlueprintsGot)
	{
		return 0;
	}

	public static bool IsGold(this PickupType pt)
	{
		return false;
	}

	public static bool IsXP(this PickupType pt)
	{
		return false;
	}

	public static bool IsResource(this PickupType pt)
	{
		return false;
	}

	public static string GetNGPlusStr(int lvl)
	{
		return null;
	}

	public static LevelType GetNextLevel(this LevelType t)
	{
		return default(LevelType);
	}

	public static LevelType GetPrevLevel(this LevelType t)
	{
		return default(LevelType);
	}

	public static bool IsHidden(this StatPropType pt)
	{
		return false;
	}

	public static bool HasFloatingInd(this StatusEffectType t)
	{
		return false;
	}

	public static TimeMode GetTimeMode(this CharType t)
	{
		return default(TimeMode);
	}
}
