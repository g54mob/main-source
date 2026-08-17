using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using I2.Loc;
using UnityEngine;

namespace VampireSurvivors.Data.Enemies;

[Serializable]
public class EnemyData
{
	private int _003Clevel_003Ek__BackingField;

	private float _003CmaxHp_003Ek__BackingField;

	private float _003Cspeed_003Ek__BackingField;

	private float _003CmaxSpeed_003Ek__BackingField = -1f;

	private float _003Cpower_003Ek__BackingField;

	private List<EnemySkillType> _003Cskills_003Ek__BackingField;

	private int? _003CminimumHpScalingLevel_003Ek__BackingField;

	private int? _003CmaximumHpScalingLevel_003Ek__BackingField;

	private float _003CshieldDuration_003Ek__BackingField;

	private float _003Cknockback_003Ek__BackingField;

	private float _003CmaxKnockback_003Ek__BackingField;

	private float _003CdeathKB_003Ek__BackingField;

	private uint? _003Ctint_003Ek__BackingField;

	private float _003Cxp_003Ek__BackingField;

	private int _003CmoreX_003Ek__BackingField;

	private int _003CmoreY_003Ek__BackingField;

	private float _003Calpha_003Ek__BackingField;

	private float? _003Cscale_003Ek__BackingField;

	private float? _003Cres_Freeze_003Ek__BackingField;

	private float? _003Cres_Rosary_003Ek__BackingField;

	private float? _003Cres_Debuffs_003Ek__BackingField;

	private float? _003Cres_Knockback_003Ek__BackingField;

	private float? _003Cres_Corridor_003Ek__BackingField;

	private float? _003Cres_Defang_003Ek__BackingField;

	private bool _003CpassThroughWalls_003Ek__BackingField;

	private bool _003CCannotBeFollower_003Ek__BackingField;

	private ColliderOverride _003CcolliderOverride_003Ek__BackingField;

	private float? _003Cweak_Fire_003Ek__BackingField;

	private bool _003CskipCredits_003Ek__BackingField;

	private int _003CidleFrameCount_003Ek__BackingField;

	private float _003CkilledAmount_003Ek__BackingField;

	private string _003CtextureName_003Ek__BackingField;

	private int _003Cend_003Ek__BackingField;

	private List<string> _003CframeNames_003Ek__BackingField;

	private float _003CpatrolDuration_003Ek__BackingField;

	private float? _003CfireDelay_003Ek__BackingField;

	private float? _003CfireDelayRandomness_003Ek__BackingField;

	private float? _003CfiringRangeMin_003Ek__BackingField;

	private float? _003CfiringRangeMax_003Ek__BackingField;

	private EnemyType? _003CbulletType_003Ek__BackingField;

	private int? _003Clives_003Ek__BackingField;

	private string _003CflagName_003Ek__BackingField;

	private EnemyData _003Calias_003Ek__BackingField;

	private float _003CfeverValue_003Ek__BackingField;

	private string _003CbName_003Ek__BackingField;

	private string _003CbDesc_003Ek__BackingField;

	private List<StageType> _003CbPlaces_003Ek__BackingField;

	private bool _003CbInclude_003Ek__BackingField;

	private bool _003CbIgnore_003Ek__BackingField;

	private bool _003CbHighlight_003Ek__BackingField;

	private List<EnemyType> _003CbVariants_003Ek__BackingField;

	private bool _003CbIncludeColorVariants_003Ek__BackingField;

	private MaterialType _003CmaterialType_003Ek__BackingField;

	public List<string> Internal_FrameNamesAnim;

	public List<List<string>> Internal_IdleAnimFrameNames;

	public List<List<string>> Internal_DeathAnimFrameNames;

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

	public float maxSpeed
	{
		get
		{
			return _003CmaxSpeed_003Ek__BackingField;
		}
		set
		{
			_003CmaxSpeed_003Ek__BackingField = value;
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

	public List<EnemySkillType> skills
	{
		get
		{
			return _003Cskills_003Ek__BackingField;
		}
		set
		{
			_003Cskills_003Ek__BackingField = value;
		}
	}

	public int? minimumHpScalingLevel
	{
		get
		{
			return _003CminimumHpScalingLevel_003Ek__BackingField;
		}
		set
		{
			_003CminimumHpScalingLevel_003Ek__BackingField = value;
		}
	}

	public int? maximumHpScalingLevel
	{
		get
		{
			return _003CmaximumHpScalingLevel_003Ek__BackingField;
		}
		set
		{
			_003CmaximumHpScalingLevel_003Ek__BackingField = value;
		}
	}

	public float shieldDuration
	{
		get
		{
			return _003CshieldDuration_003Ek__BackingField;
		}
		set
		{
			_003CshieldDuration_003Ek__BackingField = value;
		}
	}

	public float knockback
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

	public float maxKnockback
	{
		get
		{
			return _003CmaxKnockback_003Ek__BackingField;
		}
		set
		{
			_003CmaxKnockback_003Ek__BackingField = value;
		}
	}

	public float deathKB
	{
		get
		{
			return _003CdeathKB_003Ek__BackingField;
		}
		set
		{
			_003CdeathKB_003Ek__BackingField = value;
		}
	}

	public uint? tint
	{
		get
		{
			return _003Ctint_003Ek__BackingField;
		}
		set
		{
			_003Ctint_003Ek__BackingField = value;
		}
	}

	public float xp
	{
		get
		{
			return _003Cxp_003Ek__BackingField;
		}
		set
		{
			_003Cxp_003Ek__BackingField = value;
		}
	}

	public int moreX
	{
		get
		{
			return _003CmoreX_003Ek__BackingField;
		}
		set
		{
			_003CmoreX_003Ek__BackingField = value;
		}
	}

	public int moreY
	{
		get
		{
			return _003CmoreY_003Ek__BackingField;
		}
		set
		{
			_003CmoreY_003Ek__BackingField = value;
		}
	}

	public float alpha
	{
		get
		{
			return _003Calpha_003Ek__BackingField;
		}
		set
		{
			_003Calpha_003Ek__BackingField = value;
		}
	}

	public float? scale
	{
		get
		{
			return _003Cscale_003Ek__BackingField;
		}
		set
		{
			_003Cscale_003Ek__BackingField = value;
		}
	}

	public float? res_Freeze
	{
		get
		{
			return _003Cres_Freeze_003Ek__BackingField;
		}
		set
		{
			_003Cres_Freeze_003Ek__BackingField = value;
		}
	}

	public float? res_Rosary
	{
		get
		{
			return _003Cres_Rosary_003Ek__BackingField;
		}
		set
		{
			_003Cres_Rosary_003Ek__BackingField = value;
		}
	}

	public float? res_Debuffs
	{
		get
		{
			return _003Cres_Debuffs_003Ek__BackingField;
		}
		set
		{
			_003Cres_Debuffs_003Ek__BackingField = value;
		}
	}

	public float? res_Knockback
	{
		get
		{
			return _003Cres_Knockback_003Ek__BackingField;
		}
		set
		{
			_003Cres_Knockback_003Ek__BackingField = value;
		}
	}

	public float? res_Corridor
	{
		get
		{
			return _003Cres_Corridor_003Ek__BackingField;
		}
		set
		{
			_003Cres_Corridor_003Ek__BackingField = value;
		}
	}

	public float? res_Defang
	{
		get
		{
			return _003Cres_Defang_003Ek__BackingField;
		}
		set
		{
			_003Cres_Defang_003Ek__BackingField = value;
		}
	}

	public bool passThroughWalls
	{
		get
		{
			return _003CpassThroughWalls_003Ek__BackingField;
		}
		set
		{
			_003CpassThroughWalls_003Ek__BackingField = value;
		}
	}

	public bool CannotBeFollower
	{
		get
		{
			return _003CCannotBeFollower_003Ek__BackingField;
		}
		set
		{
			_003CCannotBeFollower_003Ek__BackingField = value;
		}
	}

	public ColliderOverride colliderOverride
	{
		get
		{
			return _003CcolliderOverride_003Ek__BackingField;
		}
		set
		{
			_003CcolliderOverride_003Ek__BackingField = value;
		}
	}

	public float? weak_Fire
	{
		get
		{
			return _003Cweak_Fire_003Ek__BackingField;
		}
		set
		{
			_003Cweak_Fire_003Ek__BackingField = value;
		}
	}

	public bool skipCredits
	{
		get
		{
			return _003CskipCredits_003Ek__BackingField;
		}
		set
		{
			_003CskipCredits_003Ek__BackingField = value;
		}
	}

	public int idleFrameCount
	{
		get
		{
			return _003CidleFrameCount_003Ek__BackingField;
		}
		set
		{
			_003CidleFrameCount_003Ek__BackingField = value;
		}
	}

	public float killedAmount
	{
		get
		{
			return _003CkilledAmount_003Ek__BackingField;
		}
		set
		{
			_003CkilledAmount_003Ek__BackingField = value;
		}
	}

	public string textureName
	{
		get
		{
			return _003CtextureName_003Ek__BackingField;
		}
		set
		{
			_003CtextureName_003Ek__BackingField = value;
		}
	}

	public int end
	{
		get
		{
			return _003Cend_003Ek__BackingField;
		}
		set
		{
			_003Cend_003Ek__BackingField = value;
		}
	}

	public List<string> frameNames
	{
		get
		{
			return _003CframeNames_003Ek__BackingField;
		}
		set
		{
			_003CframeNames_003Ek__BackingField = value;
		}
	}

	public float patrolDuration
	{
		get
		{
			return _003CpatrolDuration_003Ek__BackingField;
		}
		set
		{
			_003CpatrolDuration_003Ek__BackingField = value;
		}
	}

	public float? fireDelay
	{
		get
		{
			return _003CfireDelay_003Ek__BackingField;
		}
		set
		{
			_003CfireDelay_003Ek__BackingField = value;
		}
	}

	public float? fireDelayRandomness
	{
		get
		{
			return _003CfireDelayRandomness_003Ek__BackingField;
		}
		set
		{
			_003CfireDelayRandomness_003Ek__BackingField = value;
		}
	}

	public float? firingRangeMin
	{
		get
		{
			return _003CfiringRangeMin_003Ek__BackingField;
		}
		set
		{
			_003CfiringRangeMin_003Ek__BackingField = value;
		}
	}

	public float? firingRangeMax
	{
		get
		{
			return _003CfiringRangeMax_003Ek__BackingField;
		}
		set
		{
			_003CfiringRangeMax_003Ek__BackingField = value;
		}
	}

	public EnemyType? bulletType
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

	public int? lives
	{
		get
		{
			return _003Clives_003Ek__BackingField;
		}
		set
		{
			_003Clives_003Ek__BackingField = value;
		}
	}

	public string flagName
	{
		get
		{
			return _003CflagName_003Ek__BackingField;
		}
		set
		{
			_003CflagName_003Ek__BackingField = value;
		}
	}

	public EnemyData alias
	{
		get
		{
			return _003Calias_003Ek__BackingField;
		}
		set
		{
			_003Calias_003Ek__BackingField = value;
		}
	}

	public float feverValue
	{
		get
		{
			return _003CfeverValue_003Ek__BackingField;
		}
		set
		{
			_003CfeverValue_003Ek__BackingField = value;
		}
	}

	public string bName
	{
		get
		{
			return _003CbName_003Ek__BackingField;
		}
		set
		{
			_003CbName_003Ek__BackingField = value;
		}
	}

	public string bDesc
	{
		get
		{
			return _003CbDesc_003Ek__BackingField;
		}
		set
		{
			_003CbDesc_003Ek__BackingField = value;
		}
	}

	public List<StageType> bPlaces
	{
		get
		{
			return _003CbPlaces_003Ek__BackingField;
		}
		set
		{
			_003CbPlaces_003Ek__BackingField = value;
		}
	}

	public bool bInclude
	{
		get
		{
			return _003CbInclude_003Ek__BackingField;
		}
		set
		{
			_003CbInclude_003Ek__BackingField = value;
		}
	}

	public bool bIgnore
	{
		get
		{
			return _003CbIgnore_003Ek__BackingField;
		}
		set
		{
			_003CbIgnore_003Ek__BackingField = value;
		}
	}

	public bool bHighlight
	{
		get
		{
			return _003CbHighlight_003Ek__BackingField;
		}
		set
		{
			_003CbHighlight_003Ek__BackingField = value;
		}
	}

	public List<EnemyType> bVariants
	{
		get
		{
			return _003CbVariants_003Ek__BackingField;
		}
		set
		{
			_003CbVariants_003Ek__BackingField = value;
		}
	}

	public bool bIncludeColorVariants
	{
		get
		{
			return _003CbIncludeColorVariants_003Ek__BackingField;
		}
		set
		{
			_003CbIncludeColorVariants_003Ek__BackingField = value;
		}
	}

	public MaterialType materialType
	{
		get
		{
			return _003CmaterialType_003Ek__BackingField;
		}
		set
		{
			_003CmaterialType_003Ek__BackingField = value;
		}
	}

	public string GetLocalizedDescription(EnemyType type)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C84]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string localPrefix = GetLocalPrefix(type);
		string term = localPrefix + "description";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		if (translation != null)
		{
			return translation.Replace("\\n", "<br>");
		}
		return (string)(object)new NullReferenceException();
	}

	public string GetLocalizedTips(EnemyType type)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C88]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string localPrefix = GetLocalPrefix(type);
		string term = localPrefix + "tips";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		if (translation != null)
		{
			return translation.Replace("\\n", "<br>");
		}
		return (string)(object)new NullReferenceException();
	}

	public string GetLocalizedDescriptionTerm(EnemyType type)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C84]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string localPrefix = GetLocalPrefix(type);
		return localPrefix + "description";
	}

	public string GetLocalizedNameTerm(EnemyType type)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C85]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string localPrefix = GetLocalPrefix(type);
		return localPrefix + "name";
	}

	public string GetLocalizedBestiaryNameTerm(EnemyType type)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C86]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string localPrefix = GetLocalPrefix(type);
		return localPrefix + "bName";
	}

	public string GetLocalizedBestiaryDescription(EnemyType type)
	{
		string localPrefix = GetLocalPrefix(type);
		string term = localPrefix + "bDesc";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		return LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
	}

	public string GetLocalizedTipsTerm(EnemyType type)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C88]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string localPrefix = GetLocalPrefix(type);
		return localPrefix + "tips";
	}

	public unsafe string GetLocalPrefix(EnemyType t)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		return "enemiesLang/{" + text + "}";
	}

	public EnemyData()
	{
		List<EnemySkillType> list = new List<EnemySkillType>();
		_003Cskills_003Ek__BackingField = list;
		_003Calpha_003Ek__BackingField = -1f;
		List<string> list2 = new List<string>();
		_003CframeNames_003Ek__BackingField = list2;
		List<StageType> list3 = new List<StageType>();
		_003CbPlaces_003Ek__BackingField = list3;
		List<EnemyType> list4 = new List<EnemyType>();
		_003CbVariants_003Ek__BackingField = list4;
		_003CmaterialType_003Ek__BackingField = MaterialType.DefaultSprite;
		List<string> internal_FrameNamesAnim = new List<string>();
		Internal_FrameNamesAnim = internal_FrameNamesAnim;
		List<List<string>> internal_IdleAnimFrameNames = new List<List<string>>();
		Internal_IdleAnimFrameNames = internal_IdleAnimFrameNames;
		List<List<string>> internal_DeathAnimFrameNames = new List<List<string>>();
		Internal_DeathAnimFrameNames = internal_DeathAnimFrameNames;
	}
}
