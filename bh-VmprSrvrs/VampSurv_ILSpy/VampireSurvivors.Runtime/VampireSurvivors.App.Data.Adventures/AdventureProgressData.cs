using System;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.Data.Adventures;

[Serializable]
public class AdventureProgressData
{
	private AdventureAchievementType _003CType_003Ek__BackingField;

	private string _003CIconSpriteName_003Ek__BackingField;

	private string _003CIconTextureName_003Ek__BackingField;

	private int? _003CRequiredLevel_003Ek__BackingField;

	private int? _003CRequiredMinute_003Ek__BackingField;

	private CharacterType? _003CRequiredCharacter_003Ek__BackingField;

	private StageType? _003CRequiredStage_003Ek__BackingField;

	private EnemyType? _003CRequiredEnemyKillType_003Ek__BackingField;

	private int? _003CRequiredEnemyKillCount_003Ek__BackingField;

	private WeaponType? _003CRequiredFoundWeaponType_003Ek__BackingField;

	private CharacterType? _003CRequiredFoundCoffinType_003Ek__BackingField;

	public AdventureAchievementType Type
	{
		get
		{
			return _003CType_003Ek__BackingField;
		}
		set
		{
			_003CType_003Ek__BackingField = value;
		}
	}

	public string IconSpriteName
	{
		get
		{
			return _003CIconSpriteName_003Ek__BackingField;
		}
		set
		{
			_003CIconSpriteName_003Ek__BackingField = value;
		}
	}

	public string IconTextureName
	{
		get
		{
			return _003CIconTextureName_003Ek__BackingField;
		}
		set
		{
			_003CIconTextureName_003Ek__BackingField = value;
		}
	}

	public int? RequiredLevel
	{
		get
		{
			return _003CRequiredLevel_003Ek__BackingField;
		}
		set
		{
			_003CRequiredLevel_003Ek__BackingField = value;
		}
	}

	public int? RequiredMinute
	{
		get
		{
			return _003CRequiredMinute_003Ek__BackingField;
		}
		set
		{
			_003CRequiredMinute_003Ek__BackingField = value;
		}
	}

	public CharacterType? RequiredCharacter
	{
		get
		{
			return _003CRequiredCharacter_003Ek__BackingField;
		}
		set
		{
			_003CRequiredCharacter_003Ek__BackingField = value;
		}
	}

	public StageType? RequiredStage
	{
		get
		{
			return _003CRequiredStage_003Ek__BackingField;
		}
		set
		{
			_003CRequiredStage_003Ek__BackingField = value;
		}
	}

	public EnemyType? RequiredEnemyKillType
	{
		get
		{
			return _003CRequiredEnemyKillType_003Ek__BackingField;
		}
		set
		{
			_003CRequiredEnemyKillType_003Ek__BackingField = value;
		}
	}

	public int? RequiredEnemyKillCount
	{
		get
		{
			return _003CRequiredEnemyKillCount_003Ek__BackingField;
		}
		set
		{
			_003CRequiredEnemyKillCount_003Ek__BackingField = value;
		}
	}

	public WeaponType? RequiredFoundWeaponType
	{
		get
		{
			return _003CRequiredFoundWeaponType_003Ek__BackingField;
		}
		set
		{
			_003CRequiredFoundWeaponType_003Ek__BackingField = value;
		}
	}

	public CharacterType? RequiredFoundCoffinType
	{
		get
		{
			return _003CRequiredFoundCoffinType_003Ek__BackingField;
		}
		set
		{
			_003CRequiredFoundCoffinType_003Ek__BackingField = value;
		}
	}
}
