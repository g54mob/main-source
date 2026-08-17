using System;
using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using I2.Loc;
using UnityEngine;
using VampireSurvivors.Objects.Algorithm;

namespace VampireSurvivors.Data.Weapons;

[Serializable]
public class WeaponData
{
	private bool _003Chidden_003Ek__BackingField;

	private bool _003CalwaysHidden_003Ek__BackingField;

	private int _003Clevel_003Ek__BackingField;

	private WeaponType _003CbulletType_003Ek__BackingField;

	private string _003Cname_003Ek__BackingField;

	private string _003Cdescription_003Ek__BackingField;

	private string _003Ctips_003Ek__BackingField;

	private string _003Ctexture_003Ek__BackingField;

	private string _003CframeName_003Ek__BackingField;

	private string _003CcollectionFrame_003Ek__BackingField;

	private string _003CevoInto_003Ek__BackingField;

	private WeaponType[] _003CevoSynergy_003Ek__BackingField;

	private bool _003CisEvolution_003Ek__BackingField;

	private bool _003CisSpecialOnly_003Ek__BackingField;

	private List<WeaponType> _003CevolvesFrom_003Ek__BackingField;

	private List<WeaponType> _003Crequires_003Ek__BackingField;

	private List<WeaponType> _003CrequiresMax_003Ek__BackingField;

	private List<WeaponType> _003CevolutionLine_003Ek__BackingField;

	private bool _003CisUnlocked_003Ek__BackingField;

	private float? _003Cvolume_003Ek__BackingField;

	private int? _003CpoolLimit_003Ek__BackingField;

	private int _003Crarity_003Ek__BackingField;

	private float _003Cinterval_003Ek__BackingField;

	private float? _003Cduration_003Ek__BackingField;

	private float _003CrepeatInterval_003Ek__BackingField;

	private float _003Cpower_003Ek__BackingField;

	private float _003CsecondaryPower_003Ek__BackingField = 1f;

	private float? _003Cknockback_003Ek__BackingField;

	private float? _003ChitBoxDelay_003Ek__BackingField;

	private float _003Carea_003Ek__BackingField;

	private float _003Cspeed_003Ek__BackingField;

	private int _003Camount_003Ek__BackingField;

	private float _003CcritChance_003Ek__BackingField;

	private bool _003ChitsWalls_003Ek__BackingField = true;

	private float _003CcritMul_003Ek__BackingField;

	private bool _003Cseen_003Ek__BackingField;

	private WeaponType? _003CaddEvolvedWeapon_003Ek__BackingField;

	private WeaponType? _003CaddNormalWeapon_003Ek__BackingField;

	private WeaponType? _003CexcludeWeapon_003Ek__BackingField;

	private int _003Ccharges_003Ek__BackingField;

	private bool _003CintervalDependsOnDuration_003Ek__BackingField;

	private bool _003CisPowerUp_003Ek__BackingField;

	private int _003Cpenetrating_003Ek__BackingField;

	private HitVfxType _003ChitVFX_003Ek__BackingField = HitVfxType.Default;

	private List<WeaponType> _003CforcedSynergyWeapons_003Ek__BackingField;

	private bool _003CskipRemovingBaseWeapon_003Ek__BackingField;

	private bool _003ChasUniqueRequirements_003Ek__BackingField;

	private float _003Ccooldown_003Ek__BackingField;

	private float _003CmaxHp_003Ek__BackingField;

	private float _003CmoveSpeed_003Ek__BackingField;

	private float _003Cgrowth_003Ek__BackingField;

	private float _003Cmagnet_003Ek__BackingField;

	private float _003Cluck_003Ek__BackingField;

	private float _003Carmor_003Ek__BackingField;

	private float _003Cgreed_003Ek__BackingField;

	private float _003Cregen_003Ek__BackingField;

	private float _003Crevivals_003Ek__BackingField;

	private float _003Crerolls_003Ek__BackingField;

	private float _003Cskips_003Ek__BackingField;

	private float _003Cchance_003Ek__BackingField;

	private string _003Cbgm_003Ek__BackingField;

	private float? _003CshieldInvulTime_003Ek__BackingField;

	private float _003Ccurse_003Ek__BackingField;

	private string _003Cdesc_003Ek__BackingField;

	private float _003Ccharm_003Ek__BackingField;

	private float _003Cfever_003Ek__BackingField;

	private float _003CinvulTimeBonus_003Ek__BackingField;

	private float? _003CcustomDesc_003Ek__BackingField;

	public string customDescValue;

	private bool _003CunexcludeSelf_003Ek__BackingField;

	private bool _003CdropRateAffectedByLuck_003Ek__BackingField;

	private bool _003Csealable_003Ek__BackingField;

	private float? _003Cprice_003Ek__BackingField;

	private bool _003CappliesOnlyToOwner_003Ek__BackingField;

	private bool _003CallowDuplicates_003Ek__BackingField;

	private bool _003CdespawnOnUnavailable_003Ek__BackingField;

	private ContentGroupType _003CcontentGroup_003Ek__BackingField;

	private CharacterType _003CfollowerType_003Ek__BackingField;

	private AIType _003CfollowerAI_003Ek__BackingField;

	public bool hidden
	{
		get
		{
			return _003Chidden_003Ek__BackingField;
		}
		set
		{
			_003Chidden_003Ek__BackingField = value;
		}
	}

	public bool alwaysHidden
	{
		get
		{
			return _003CalwaysHidden_003Ek__BackingField;
		}
		set
		{
			_003CalwaysHidden_003Ek__BackingField = value;
		}
	}

	public int level
	{
		get
		{
			return _003Clevel_003Ek__BackingField;
		}
		set
		{
			_003Clevel_003Ek__BackingField = value;
		}
	}

	public WeaponType bulletType
	{
		get
		{
			return _003CbulletType_003Ek__BackingField;
		}
		set
		{
			_003CbulletType_003Ek__BackingField = value;
		}
	}

	public string name
	{
		get
		{
			return _003Cname_003Ek__BackingField;
		}
		set
		{
			_003Cname_003Ek__BackingField = value;
		}
	}

	public string description
	{
		get
		{
			return _003Cdescription_003Ek__BackingField;
		}
		set
		{
			_003Cdescription_003Ek__BackingField = value;
		}
	}

	public string tips
	{
		get
		{
			return _003Ctips_003Ek__BackingField;
		}
		set
		{
			_003Ctips_003Ek__BackingField = value;
		}
	}

	public string texture
	{
		get
		{
			return _003Ctexture_003Ek__BackingField;
		}
		set
		{
			_003Ctexture_003Ek__BackingField = value;
		}
	}

	public string frameName
	{
		get
		{
			return _003CframeName_003Ek__BackingField;
		}
		set
		{
			_003CframeName_003Ek__BackingField = value;
		}
	}

	public string collectionFrame
	{
		get
		{
			return _003CcollectionFrame_003Ek__BackingField;
		}
		set
		{
			_003CcollectionFrame_003Ek__BackingField = value;
		}
	}

	public string evoInto
	{
		get
		{
			return _003CevoInto_003Ek__BackingField;
		}
		set
		{
			_003CevoInto_003Ek__BackingField = value;
		}
	}

	public WeaponType[] evoSynergy
	{
		get
		{
			return _003CevoSynergy_003Ek__BackingField;
		}
		set
		{
			_003CevoSynergy_003Ek__BackingField = value;
		}
	}

	public bool isEvolution
	{
		get
		{
			return _003CisEvolution_003Ek__BackingField;
		}
		set
		{
			_003CisEvolution_003Ek__BackingField = value;
		}
	}

	public bool isSpecialOnly
	{
		get
		{
			return _003CisSpecialOnly_003Ek__BackingField;
		}
		set
		{
			_003CisSpecialOnly_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> evolvesFrom
	{
		get
		{
			return _003CevolvesFrom_003Ek__BackingField;
		}
		set
		{
			_003CevolvesFrom_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> requires
	{
		get
		{
			return _003Crequires_003Ek__BackingField;
		}
		set
		{
			_003Crequires_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> requiresMax
	{
		get
		{
			return _003CrequiresMax_003Ek__BackingField;
		}
		set
		{
			_003CrequiresMax_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> evolutionLine
	{
		get
		{
			return _003CevolutionLine_003Ek__BackingField;
		}
		set
		{
			_003CevolutionLine_003Ek__BackingField = value;
		}
	}

	public bool isUnlocked
	{
		get
		{
			return _003CisUnlocked_003Ek__BackingField;
		}
		set
		{
			_003CisUnlocked_003Ek__BackingField = value;
		}
	}

	public float? volume
	{
		get
		{
			return _003Cvolume_003Ek__BackingField;
		}
		set
		{
			_003Cvolume_003Ek__BackingField = value;
		}
	}

	public int? poolLimit
	{
		get
		{
			return _003CpoolLimit_003Ek__BackingField;
		}
		set
		{
			_003CpoolLimit_003Ek__BackingField = value;
		}
	}

	public int rarity
	{
		get
		{
			return _003Crarity_003Ek__BackingField;
		}
		set
		{
			_003Crarity_003Ek__BackingField = value;
		}
	}

	public float interval
	{
		get
		{
			return _003Cinterval_003Ek__BackingField;
		}
		set
		{
			_003Cinterval_003Ek__BackingField = value;
		}
	}

	public float? duration
	{
		get
		{
			return _003Cduration_003Ek__BackingField;
		}
		set
		{
			_003Cduration_003Ek__BackingField = value;
		}
	}

	public float repeatInterval
	{
		get
		{
			return _003CrepeatInterval_003Ek__BackingField;
		}
		set
		{
			_003CrepeatInterval_003Ek__BackingField = value;
		}
	}

	public float power
	{
		get
		{
			return _003Cpower_003Ek__BackingField;
		}
		set
		{
			_003Cpower_003Ek__BackingField = value;
		}
	}

	public float secondaryPower
	{
		get
		{
			return _003CsecondaryPower_003Ek__BackingField;
		}
		set
		{
			_003CsecondaryPower_003Ek__BackingField = value;
		}
	}

	public float? knockback
	{
		get
		{
			return _003Cknockback_003Ek__BackingField;
		}
		set
		{
			_003Cknockback_003Ek__BackingField = value;
		}
	}

	public float? hitBoxDelay
	{
		get
		{
			return _003ChitBoxDelay_003Ek__BackingField;
		}
		set
		{
			_003ChitBoxDelay_003Ek__BackingField = value;
		}
	}

	public float area
	{
		get
		{
			return _003Carea_003Ek__BackingField;
		}
		set
		{
			_003Carea_003Ek__BackingField = value;
		}
	}

	public float speed
	{
		get
		{
			return _003Cspeed_003Ek__BackingField;
		}
		set
		{
			_003Cspeed_003Ek__BackingField = value;
		}
	}

	public int amount
	{
		get
		{
			return _003Camount_003Ek__BackingField;
		}
		set
		{
			_003Camount_003Ek__BackingField = value;
		}
	}

	public float critChance
	{
		get
		{
			return _003CcritChance_003Ek__BackingField;
		}
		set
		{
			_003CcritChance_003Ek__BackingField = value;
		}
	}

	public bool hitsWalls
	{
		get
		{
			return _003ChitsWalls_003Ek__BackingField;
		}
		set
		{
			_003ChitsWalls_003Ek__BackingField = value;
		}
	}

	public float critMul
	{
		get
		{
			return _003CcritMul_003Ek__BackingField;
		}
		set
		{
			_003CcritMul_003Ek__BackingField = value;
		}
	}

	public bool seen
	{
		get
		{
			return _003Cseen_003Ek__BackingField;
		}
		set
		{
			_003Cseen_003Ek__BackingField = value;
		}
	}

	public WeaponType? addEvolvedWeapon
	{
		get
		{
			return _003CaddEvolvedWeapon_003Ek__BackingField;
		}
		set
		{
			_003CaddEvolvedWeapon_003Ek__BackingField = value;
		}
	}

	public WeaponType? addNormalWeapon
	{
		get
		{
			return _003CaddNormalWeapon_003Ek__BackingField;
		}
		set
		{
			_003CaddNormalWeapon_003Ek__BackingField = value;
		}
	}

	public WeaponType? excludeWeapon
	{
		get
		{
			return _003CexcludeWeapon_003Ek__BackingField;
		}
		set
		{
			_003CexcludeWeapon_003Ek__BackingField = value;
		}
	}

	public int charges
	{
		get
		{
			return _003Ccharges_003Ek__BackingField;
		}
		set
		{
			_003Ccharges_003Ek__BackingField = value;
		}
	}

	public bool intervalDependsOnDuration
	{
		get
		{
			return _003CintervalDependsOnDuration_003Ek__BackingField;
		}
		set
		{
			_003CintervalDependsOnDuration_003Ek__BackingField = value;
		}
	}

	public bool isPowerUp
	{
		get
		{
			return _003CisPowerUp_003Ek__BackingField;
		}
		set
		{
			_003CisPowerUp_003Ek__BackingField = value;
		}
	}

	public int penetrating
	{
		get
		{
			return _003Cpenetrating_003Ek__BackingField;
		}
		set
		{
			_003Cpenetrating_003Ek__BackingField = value;
		}
	}

	public HitVfxType hitVFX
	{
		get
		{
			return _003ChitVFX_003Ek__BackingField;
		}
		set
		{
			_003ChitVFX_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> forcedSynergyWeapons
	{
		get
		{
			return _003CforcedSynergyWeapons_003Ek__BackingField;
		}
		set
		{
			_003CforcedSynergyWeapons_003Ek__BackingField = value;
		}
	}

	public bool skipRemovingBaseWeapon
	{
		get
		{
			return _003CskipRemovingBaseWeapon_003Ek__BackingField;
		}
		set
		{
			_003CskipRemovingBaseWeapon_003Ek__BackingField = value;
		}
	}

	public bool hasUniqueRequirements
	{
		get
		{
			return _003ChasUniqueRequirements_003Ek__BackingField;
		}
		set
		{
			_003ChasUniqueRequirements_003Ek__BackingField = value;
		}
	}

	public float cooldown
	{
		get
		{
			return _003Ccooldown_003Ek__BackingField;
		}
		set
		{
			_003Ccooldown_003Ek__BackingField = value;
		}
	}

	public float maxHp
	{
		get
		{
			return _003CmaxHp_003Ek__BackingField;
		}
		set
		{
			_003CmaxHp_003Ek__BackingField = value;
		}
	}

	public float moveSpeed
	{
		get
		{
			return _003CmoveSpeed_003Ek__BackingField;
		}
		set
		{
			_003CmoveSpeed_003Ek__BackingField = value;
		}
	}

	public float growth
	{
		get
		{
			return _003Cgrowth_003Ek__BackingField;
		}
		set
		{
			_003Cgrowth_003Ek__BackingField = value;
		}
	}

	public float magnet
	{
		get
		{
			return _003Cmagnet_003Ek__BackingField;
		}
		set
		{
			_003Cmagnet_003Ek__BackingField = value;
		}
	}

	public float luck
	{
		get
		{
			return _003Cluck_003Ek__BackingField;
		}
		set
		{
			_003Cluck_003Ek__BackingField = value;
		}
	}

	public float armor
	{
		get
		{
			return _003Carmor_003Ek__BackingField;
		}
		set
		{
			_003Carmor_003Ek__BackingField = value;
		}
	}

	public float greed
	{
		get
		{
			return _003Cgreed_003Ek__BackingField;
		}
		set
		{
			_003Cgreed_003Ek__BackingField = value;
		}
	}

	public float regen
	{
		get
		{
			return _003Cregen_003Ek__BackingField;
		}
		set
		{
			_003Cregen_003Ek__BackingField = value;
		}
	}

	public float revivals
	{
		get
		{
			return _003Crevivals_003Ek__BackingField;
		}
		set
		{
			_003Crevivals_003Ek__BackingField = value;
		}
	}

	public float rerolls
	{
		get
		{
			return _003Crerolls_003Ek__BackingField;
		}
		set
		{
			_003Crerolls_003Ek__BackingField = value;
		}
	}

	public float skips
	{
		get
		{
			return _003Cskips_003Ek__BackingField;
		}
		set
		{
			_003Cskips_003Ek__BackingField = value;
		}
	}

	public float chance
	{
		get
		{
			return _003Cchance_003Ek__BackingField;
		}
		set
		{
			_003Cchance_003Ek__BackingField = value;
		}
	}

	public string bgm
	{
		get
		{
			return _003Cbgm_003Ek__BackingField;
		}
		set
		{
			_003Cbgm_003Ek__BackingField = value;
		}
	}

	public float? shieldInvulTime
	{
		get
		{
			return _003CshieldInvulTime_003Ek__BackingField;
		}
		set
		{
			_003CshieldInvulTime_003Ek__BackingField = value;
		}
	}

	public float curse
	{
		get
		{
			return _003Ccurse_003Ek__BackingField;
		}
		set
		{
			_003Ccurse_003Ek__BackingField = value;
		}
	}

	public string desc
	{
		get
		{
			return _003Cdesc_003Ek__BackingField;
		}
		set
		{
			_003Cdesc_003Ek__BackingField = value;
		}
	}

	public float charm
	{
		get
		{
			return _003Ccharm_003Ek__BackingField;
		}
		set
		{
			_003Ccharm_003Ek__BackingField = value;
		}
	}

	public float fever
	{
		get
		{
			return _003Cfever_003Ek__BackingField;
		}
		set
		{
			_003Cfever_003Ek__BackingField = value;
		}
	}

	public float invulTimeBonus
	{
		get
		{
			return _003CinvulTimeBonus_003Ek__BackingField;
		}
		set
		{
			_003CinvulTimeBonus_003Ek__BackingField = value;
		}
	}

	public float? customDesc
	{
		get
		{
			return _003CcustomDesc_003Ek__BackingField;
		}
		set
		{
			_003CcustomDesc_003Ek__BackingField = value;
		}
	}

	public bool unexcludeSelf
	{
		get
		{
			return _003CunexcludeSelf_003Ek__BackingField;
		}
		set
		{
			_003CunexcludeSelf_003Ek__BackingField = value;
		}
	}

	public bool dropRateAffectedByLuck
	{
		get
		{
			return _003CdropRateAffectedByLuck_003Ek__BackingField;
		}
		set
		{
			_003CdropRateAffectedByLuck_003Ek__BackingField = value;
		}
	}

	public bool sealable
	{
		get
		{
			return _003Csealable_003Ek__BackingField;
		}
		set
		{
			_003Csealable_003Ek__BackingField = value;
		}
	}

	public float? price
	{
		get
		{
			return _003Cprice_003Ek__BackingField;
		}
		set
		{
			_003Cprice_003Ek__BackingField = value;
		}
	}

	public bool appliesOnlyToOwner
	{
		get
		{
			return _003CappliesOnlyToOwner_003Ek__BackingField;
		}
		set
		{
			_003CappliesOnlyToOwner_003Ek__BackingField = value;
		}
	}

	public bool allowDuplicates
	{
		get
		{
			return _003CallowDuplicates_003Ek__BackingField;
		}
		set
		{
			_003CallowDuplicates_003Ek__BackingField = value;
		}
	}

	public bool despawnOnUnavailable
	{
		get
		{
			return _003CdespawnOnUnavailable_003Ek__BackingField;
		}
		set
		{
			_003CdespawnOnUnavailable_003Ek__BackingField = value;
		}
	}

	public ContentGroupType contentGroup
	{
		get
		{
			return _003CcontentGroup_003Ek__BackingField;
		}
		set
		{
			_003CcontentGroup_003Ek__BackingField = value;
		}
	}

	public CharacterType followerType
	{
		get
		{
			return _003CfollowerType_003Ek__BackingField;
		}
		set
		{
			_003CfollowerType_003Ek__BackingField = value;
		}
	}

	public AIType followerAI
	{
		get
		{
			return _003CfollowerAI_003Ek__BackingField;
		}
		set
		{
			_003CfollowerAI_003Ek__BackingField = value;
		}
	}

	public string GetLocalizedNameTerm(WeaponType wType)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C61]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string prefix = GetPrefix(wType);
		return prefix + "name";
	}

	public string GetLocalizedDescriptionTerm(WeaponType wType)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C62]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string prefix = GetPrefix(wType);
		return prefix + "description";
	}

	public string GetLocalizedTipsTerm(WeaponType wType)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C63]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string prefix = GetPrefix(wType);
		return prefix + "tips";
	}

	public unsafe string GetLocalizedDescriptionForLevel(WeaponData levelData, WeaponType weaponType)
	{
		//IL_0b64: Invalid comparison between F4 and I4
		//IL_10c2: Invalid comparison between F4 and I4
		//IL_0bfa: Invalid comparison between F4 and I4
		//IL_10ec: Expected F4, but got I4
		//IL_111c: Invalid comparison between I4 and F4
		//IL_1141: Invalid comparison between F4 and I4
		//IL_0c8e: Expected F4, but got I4
		//IL_0d35: Invalid comparison between I4 and F4
		//IL_1166: Invalid comparison between F4 and I4
		//IL_0d5a: Invalid comparison between I4 and F4
		//IL_118b: Invalid comparison between F4 and I4
		//IL_0dca: Invalid comparison between F4 and I4
		//IL_11b0: Invalid comparison between F4 and I4
		//IL_11d5: Invalid comparison between F4 and I4
		//IL_0e8d: Invalid comparison between F4 and I4
		//IL_122f: Invalid comparison between F4 and I4
		//IL_0ee2: Invalid comparison between F4 and I4
		//IL_11ff: Expected F4, but got I4
		//IL_1254: Invalid comparison between F4 and I4
		//IL_0f4d: Invalid comparison between F4 and I4
		//IL_1279: Invalid comparison between F4 and I4
		//IL_0f72: Invalid comparison between F4 and I4
		//IL_129e: Invalid comparison between F4 and I4
		//IL_0f97: Invalid comparison between F4 and I4
		//IL_12c3: Invalid comparison between F4 and I4
		//IL_0ffd: Invalid comparison between F4 and I4
		//IL_100c: Invalid comparison between F4 and I4
		//IL_1035: Expected O, but got I4
		//IL_12e8: Invalid comparison between F4 and I4
		//IL_0ab5: Invalid comparison between F4 and I4
		//IL_0895: Unknown result type (might be due to invalid IL or missing references)
		//IL_089a: Expected Ref, but got Unknown
		//IL_08b1: Expected I8, but got I4
		//IL_08bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c0: Expected Ref, but got Unknown
		bool flag = levelData._003Camount_003Ek__BackingField <= 0;
		string text = "";
		if (!flag)
		{
			bool flag2 = !_003CisPowerUp_003Ek__BackingField;
			string text2 = "";
			if (!flag2)
			{
				string levelUpAllPrefixTranslation = GetLevelUpAllPrefixTranslation();
				string text3 = "" + levelUpAllPrefixTranslation;
				text2 = text3;
			}
			bool flag3 = _003Camount_003Ek__BackingField <= 1;
			string term = "weaponLevelUp_projectile";
			if (!flag3)
			{
				term = "weaponLevelUp_projectiles";
			}
			string text4 = GetDescription(term, levelData._003Camount_003Ek__BackingField);
			string text5 = text2 + text4;
			text = text5;
		}
		if (levelData._003Carea_003Ek__BackingField > 0f)
		{
			if (_003CisPowerUp_003Ek__BackingField)
			{
				string levelUpAllPrefixTranslation2 = GetLevelUpAllPrefixTranslation();
				string text6 = text + levelUpAllPrefixTranslation2;
				text = text6;
			}
			float value = levelData._003Carea_003Ek__BackingField * 100f;
			string text7 = GetDescription("weaponLevelUp_area", value);
			string text8 = text + text7;
			text = text8;
		}
		if (levelData._003Carmor_003Ek__BackingField > 0f)
		{
			string text9 = GetDescription("weaponLevelUp_reduceDamage", levelData._003Carmor_003Ek__BackingField);
			string text10 = text + text9;
			text = text10;
		}
		if (levelData._003Cchance_003Ek__BackingField > 0f)
		{
			string term2;
			if (weaponType != WeaponType.PENTAGRAM)
			{
				if (weaponType != WeaponType.CHERRY)
				{
					if (weaponType != WeaponType.FLOWER)
					{
						goto IL_0c11;
					}
					term2 = "weaponLevelUp_desc_celestialdusting";
				}
				else
				{
					term2 = "weaponLevelUp_desc_cherrybomb";
				}
			}
			else
			{
				term2 = "weaponLevelUp_desc_pentagram";
			}
			float value2 = levelData._003Cchance_003Ek__BackingField * 100f;
			string descriptionPercent = GetDescriptionPercent(term2, value2);
			string text11 = text + descriptionPercent;
			text = text11;
		}
		goto IL_0c11;
		IL_0af9:
		string text12;
		text = text12;
		goto IL_10af;
		IL_0fae:
		float value3 = levelData._003Cfever_003Ek__BackingField * 100f;
		string text13 = GetDescription("weaponLevelUp_fever", value3);
		string text14 = text + text13;
		text = text14;
		goto IL_12b5;
		IL_0c11:
		if (levelData._003Ccharges_003Ek__BackingField > 0)
		{
			bool flag4 = _003Ccharges_003Ek__BackingField <= 1;
			string term3 = "weaponLevelUp_charge";
			if (!flag4)
			{
				term3 = "weaponLevelUp_charges";
			}
			string text15 = GetDescription(term3, levelData._003Ccharges_003Ek__BackingField);
			string text16 = text + text15;
			text = text16;
		}
		if (0f > levelData._003Ccooldown_003Ek__BackingField)
		{
			if (_003CisPowerUp_003Ek__BackingField)
			{
				string levelUpAllPrefixTranslation3 = GetLevelUpAllPrefixTranslation();
				string text17 = text + levelUpAllPrefixTranslation3;
				text = text17;
			}
			float value4 = levelData._003Ccooldown_003Ek__BackingField * -100f;
			string descriptionWithDecimalFormatting = GetDescriptionWithDecimalFormatting("weaponLevelUp_cooldownPerc", value4, 1);
			string text18 = text + descriptionWithDecimalFormatting;
			text = text18;
		}
		float num = default(float);
		string descriptionWithDecimalFormatting2;
		if ((object)levelData._003Cduration_003Ek__BackingField != null)
		{
			if (!_003CisPowerUp_003Ek__BackingField)
			{
				if ((object)levelData._003Cduration_003Ek__BackingField != null)
				{
					float value5 = num * 0.001f;
					descriptionWithDecimalFormatting2 = GetDescriptionWithDecimalFormatting("weaponLevelUp_effect", value5, 1);
					goto IL_02e2;
				}
			}
			else if ((object)levelData._003Cduration_003Ek__BackingField != null)
			{
				float value6 = num * 100f;
				descriptionWithDecimalFormatting2 = GetDescription("weaponLevelUp_effectPerc", value6);
				goto IL_02e2;
			}
			goto IL_0d1d;
		}
		goto IL_1133;
		IL_10af:
		return text;
		IL_02e2:
		string text19 = text + descriptionWithDecimalFormatting2;
		text = text19;
		goto IL_1133;
		IL_1133:
		if (levelData._003Cgreed_003Ek__BackingField > 0f)
		{
			float value7 = levelData._003Cgreed_003Ek__BackingField * 100f;
			string text20 = GetDescription("weaponLevelUp_value", value7);
			string text21 = text + text20;
			text = text21;
		}
		if (0f > levelData._003Cgrowth_003Ek__BackingField)
		{
			float value8 = levelData._003Cgrowth_003Ek__BackingField * 100f;
			string text22 = GetDescription("weaponLevelUp_xpDecreased", value8);
			string text23 = text + text22;
			text = text23;
		}
		if (levelData._003Cgrowth_003Ek__BackingField > 0f)
		{
			float value9 = levelData._003Cgrowth_003Ek__BackingField * 100f;
			string text24 = GetDescription("weaponLevelUp_xp", value9);
			string text25 = text + text24;
			text = text25;
		}
		if (0f > levelData._003Cinterval_003Ek__BackingField)
		{
			if (_003CisPowerUp_003Ek__BackingField)
			{
				string levelUpAllPrefixTranslation4 = GetLevelUpAllPrefixTranslation();
				string text26 = text + levelUpAllPrefixTranslation4;
				text = text26;
			}
			float value10 = levelData._003Cinterval_003Ek__BackingField * -0.001f;
			string descriptionWithDecimalFormatting3 = GetDescriptionWithDecimalFormatting("weaponLevelUp_cooldown", value10, 1);
			string text27 = text + descriptionWithDecimalFormatting3;
			text = text27;
		}
		if (levelData._003Cinterval_003Ek__BackingField > 0f)
		{
			if (_003CisPowerUp_003Ek__BackingField)
			{
				string levelUpAllPrefixTranslation5 = GetLevelUpAllPrefixTranslation();
				string text28 = text + levelUpAllPrefixTranslation5;
				text = text28;
			}
			float value11 = levelData._003Cinterval_003Ek__BackingField * 0.001f;
			string descriptionWithDecimalFormatting4 = GetDescriptionWithDecimalFormatting("weaponLevelUp_cooldownIncreased", value11, 1);
			string text29 = text + descriptionWithDecimalFormatting4;
			text = text29;
		}
		if (levelData._003Cluck_003Ek__BackingField > 0f)
		{
			float value12 = levelData._003Cluck_003Ek__BackingField * 100f;
			string text30 = GetDescription("weaponLevelUp_luck", value12);
			string text31 = text + text30;
			text = text31;
		}
		if (levelData._003Cmagnet_003Ek__BackingField > 0f)
		{
			float value13 = levelData._003Cmagnet_003Ek__BackingField * 100f;
			string text32 = GetDescription("weaponLevelUp_range", value13);
			string text33 = text + text32;
			text = text33;
		}
		if (levelData._003Cpenetrating_003Ek__BackingField > 0)
		{
			if (_003CisPowerUp_003Ek__BackingField)
			{
				string levelUpAllPrefixTranslation6 = GetLevelUpAllPrefixTranslation();
				string text34 = text + levelUpAllPrefixTranslation6;
				text = text34;
			}
			bool flag5 = levelData._003Cpenetrating_003Ek__BackingField <= 1;
			string term4 = "weaponLevelUp_enemy";
			if (!flag5)
			{
				term4 = "weaponLevelUp_enemies";
			}
			string text35 = GetDescription(term4, levelData._003Cpenetrating_003Ek__BackingField);
			string text36 = text + text35;
			text = text36;
		}
		if (levelData._003Cpower_003Ek__BackingField > 0f)
		{
			float value14;
			string term5;
			if (!_003CisPowerUp_003Ek__BackingField)
			{
				value14 = levelData._003Cpower_003Ek__BackingField * 10f;
				term5 = "weaponLevelUp_damage";
			}
			else
			{
				value14 = levelData._003Cpower_003Ek__BackingField * 100f;
				term5 = "weaponLevelUp_damageAll";
			}
			string text37 = GetDescription(term5, value14);
			string text38 = text + text37;
			text = text38;
		}
		if (levelData._003Cregen_003Ek__BackingField > 0f)
		{
			string descriptionWithDecimalFormatting5 = GetDescriptionWithDecimalFormatting("weaponLevelUp_recovery", levelData._003Cregen_003Ek__BackingField, 1);
			string text39 = text + descriptionWithDecimalFormatting5;
			text = text39;
		}
		if (levelData._003Crevivals_003Ek__BackingField > 0f)
		{
			string text40 = GetDescription("weaponLevelUp_revivals", levelData._003Crevivals_003Ek__BackingField);
			string text41 = text + text40;
			text = text41;
		}
		if (levelData._003Cspeed_003Ek__BackingField > 0f)
		{
			if (_003CisPowerUp_003Ek__BackingField)
			{
				string levelUpAllPrefixTranslation7 = GetLevelUpAllPrefixTranslation();
				string text42 = text + levelUpAllPrefixTranslation7;
				text = text42;
			}
			float value15 = levelData._003Cspeed_003Ek__BackingField * 100f;
			string text43 = GetDescription("weaponLevelUp_speed", value15);
			string text44 = text + text43;
			text = text44;
		}
		if (levelData._003CmaxHp_003Ek__BackingField > 0f)
		{
			float value16 = levelData._003CmaxHp_003Ek__BackingField * 100f;
			string text45 = GetDescription("weaponLevelUp_health", value16);
			string text46 = text + text45;
			text = text46;
		}
		if (levelData._003CmoveSpeed_003Ek__BackingField > 0f)
		{
			float value17 = levelData._003CmoveSpeed_003Ek__BackingField * 100f;
			string text47 = GetDescription("weaponLevelUp_movement", value17);
			string text48 = text + text47;
			text = text48;
		}
		if (levelData._003CcritMul_003Ek__BackingField > 0f)
		{
			float value18 = levelData._003CcritMul_003Ek__BackingField * 100f;
			string text49 = GetDescription("weaponLevelUp_critMul", value18);
			string text50 = text + text49;
			text = text50;
		}
		if (levelData._003CcritChance_003Ek__BackingField > 0f)
		{
			float value19 = levelData._003CcritChance_003Ek__BackingField * 100f;
			string text51 = GetDescription("weaponLevelUp_critChance", value19);
			string text52 = text + text51;
			text = text52;
		}
		if (levelData._003Ccharm_003Ek__BackingField > 0f)
		{
			string text53 = GetDescription("weaponLevelUp_charm", levelData._003Ccharm_003Ek__BackingField);
			string text54 = text + text53;
			text = text54;
		}
		if (levelData._003Cfever_003Ek__BackingField > 0f)
		{
			object obj = "";
			if ((object)text != "")
			{
				if (text != null && "" != null)
				{
					int stringLength = text._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1497 @ rdx_v47+10]");
					if ((nint)stringLength == 0)
					{
						ref byte first = ref *(byte*)(text + 20);
						ulong length = (ulong)(text._stringLength + text._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("" + 20), length))
						{
							goto IL_0fae;
						}
					}
				}
				string text55 = text + " ";
				text = text55;
			}
			goto IL_0fae;
		}
		goto IL_12b5;
		IL_0d1d:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		string result = default(string);
		return result;
		IL_12b5:
		if (levelData._003CinvulTimeBonus_003Ek__BackingField > 0f)
		{
			string text56 = GetDescription("weaponLevelUp_invulTimeBonus", levelData._003CinvulTimeBonus_003Ek__BackingField);
			string text57 = text + text56;
			text = text57;
		}
		bool flag6 = num < 0f;
		bool flag7 = num == 0f;
		bool flag8 = !flag6;
		bool flag9 = !flag7;
		object obj2 = flag9 & flag8;
		object obj3 = (object?)levelData._003CshieldInvulTime_003Ek__BackingField & obj2;
		if (obj3 != null)
		{
			if ((object)levelData._003CshieldInvulTime_003Ek__BackingField == null)
			{
				goto IL_0d1d;
			}
			float value20 = num * 0.001f;
			string descriptionWithDecimalFormatting6 = GetDescriptionWithDecimalFormatting("weaponLevelUp_shield", value20, 1);
			string text58 = text + descriptionWithDecimalFormatting6;
			text = text58;
		}
		if (levelData._003Ccurse_003Ek__BackingField > 0f)
		{
			float value21 = levelData._003Ccurse_003Ek__BackingField * 100f;
			string text59 = GetDescription("weaponLevelUp_curse", value21);
			string text60 = text + text59;
			text = text60;
		}
		string text61 = _003Cdesc_003Ek__BackingField;
		if (_003Cdesc_003Ek__BackingField != null && text61._stringLength > 0)
		{
			string text62 = text + _003Cdesc_003Ek__BackingField + "<br>";
			text = text62;
		}
		if ((object)levelData._003CcustomDesc_003Ek__BackingField != null)
		{
			if (weaponType != WeaponType.LEM_FIBONACCI1)
			{
				if ((object)levelData._003CcustomDesc_003Ek__BackingField != null)
				{
					string customDescription = GetCustomDescription(weaponType, num);
					text = customDescription;
					goto IL_12ff;
				}
			}
			else if ((object)levelData._003CcustomDesc_003Ek__BackingField != null)
			{
				string customDescription2 = GetCustomDescription(WeaponType.LEM_FIBONACCI1, num);
				text12 = text + customDescription2;
				goto IL_0af9;
			}
			goto IL_0d1d;
		}
		goto IL_12ff;
		IL_12ff:
		if (weaponType == WeaponType.PANDORA)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186BCD6CDh\"");
			if (levelData._003Ccurse_003Ek__BackingField == 0f)
			{
				float value22 = levelData._003Cpower_003Ek__BackingField * 100f;
				text12 = GetDescription("weaponLevelUp_override_torronasbox2", value22);
				goto IL_0af9;
			}
		}
		goto IL_10af;
	}

	private string GetLevelUpAllPrefixTranslation()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C65]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string term = "lang/" + "weaponLevelUp_all";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		return translation + " ";
	}

	private string GetTranslation(string term)
	{
		string term2 = "lang/" + term;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		return LocalizationManager.GetTranslation(term2, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
	}

	public unsafe string GetCustomDescription(WeaponType t, float value)
	{
		//IL_00cb: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string term = "weaponLang/{" + text + "}customDescValue";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string newValue = System.Number.FormatSingle(value, null, currentInfo);
		if (translation != null)
		{
			string text2 = translation.Replace("%0", newValue);
			if (text2 != null)
			{
				return text2.Replace("\\n", "<br>");
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public string GetDescription(string term, float value)
	{
		string term2 = "lang/" + term;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term2, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		NumberFormatInfo instance = NumberFormatInfo.GetInstance(CultureInfo.invariant_culture_info);
		string newValue = System.Number.FormatSingle(value, null, instance);
		if (translation != null)
		{
			string text = translation.Replace("%0", newValue);
			if (text != null)
			{
				return text.Replace("\\n", "<br>");
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public string GetDescriptionPercent(string term, float value)
	{
		string term2 = "lang/" + term;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term2, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		NumberFormatInfo instance = NumberFormatInfo.GetInstance(CultureInfo.invariant_culture_info);
		string text = System.Number.FormatSingle(value, null, instance);
		string newValue = text + "%";
		if (translation != null)
		{
			string text2 = translation.Replace("%0", newValue);
			if (text2 != null)
			{
				return text2.Replace("\\n", "<br>");
			}
		}
		return (string)(object)new NullReferenceException();
	}

	private unsafe string GetDescriptionWithDecimalFormatting(string term, float value, int decimalPlaces)
	{
		//IL_008b: Expected O, but got Ref
		//IL_00f0: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string format = string.FormatHelper((IFormatProvider)null, "F{0}", (System.ParamsArray)(&obj));
		NumberFormatInfo instance = NumberFormatInfo.GetInstance(CultureInfo.invariant_culture_info);
		string text = System.Number.FormatSingle(value, format, instance);
		bool flag = text == null;
		float value2 = value;
		if (!flag)
		{
			NumberFormatInfo instance2 = NumberFormatInfo.GetInstance(CultureInfo.invariant_culture_info);
			bool flag2 = float.TryParse((ReadOnlySpan<char>)(&paramsArray), NumberStyles.Float, instance2, out float result);
			bool flag3 = !flag2;
			value2 = value;
			if (!flag3)
			{
				value2 = result;
			}
		}
		if (this != null)
		{
			return GetDescription(term, value2);
		}
		return (string)(object)new NullReferenceException();
	}

	private unsafe string GetPrefix(WeaponType wType)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		return "weaponLang/{" + text + "}";
	}

	public WeaponData()
	{
		List<WeaponType> list = new List<WeaponType>();
		_003CforcedSynergyWeapons_003Ek__BackingField = list;
		_003CdespawnOnUnavailable_003Ek__BackingField = true;
	}
}
