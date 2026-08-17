using System;
using System.Collections.Generic;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Scripts.Data;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.Data.Adventures;

[Serializable]
public class AdventureData
{
	private int _003CIndex_003Ek__BackingField;

	private string _003CProgressKey_003Ek__BackingField;

	private CoreAdventureData _003CCoreAdventureData_003Ek__BackingField;

	private List<CharacterType> _003CCharacterTypes_003Ek__BackingField;

	private StageSetType _003CStageSetType_003Ek__BackingField;

	private List<WeaponType> _003CWeaponTypes_003Ek__BackingField;

	private List<AchievementData> _003CProgressData_003Ek__BackingField;

	private List<EnemyType> _003CExtraBestiaryTypes_003Ek__BackingField;

	public int Index
	{
		get
		{
			return _003CIndex_003Ek__BackingField;
		}
		set
		{
			_003CIndex_003Ek__BackingField = value;
		}
	}

	public string ProgressKey
	{
		get
		{
			return _003CProgressKey_003Ek__BackingField;
		}
		set
		{
			_003CProgressKey_003Ek__BackingField = value;
		}
	}

	public CoreAdventureData CoreAdventureData
	{
		get
		{
			return _003CCoreAdventureData_003Ek__BackingField;
		}
		set
		{
			_003CCoreAdventureData_003Ek__BackingField = value;
		}
	}

	public List<CharacterType> CharacterTypes
	{
		get
		{
			return _003CCharacterTypes_003Ek__BackingField;
		}
		set
		{
			_003CCharacterTypes_003Ek__BackingField = value;
		}
	}

	public StageSetType StageSetType
	{
		get
		{
			return _003CStageSetType_003Ek__BackingField;
		}
		set
		{
			_003CStageSetType_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> WeaponTypes
	{
		get
		{
			return _003CWeaponTypes_003Ek__BackingField;
		}
		set
		{
			_003CWeaponTypes_003Ek__BackingField = value;
		}
	}

	public List<AchievementData> ProgressData
	{
		get
		{
			return _003CProgressData_003Ek__BackingField;
		}
		set
		{
			_003CProgressData_003Ek__BackingField = value;
		}
	}

	public List<EnemyType> ExtraBestiaryTypes
	{
		get
		{
			return _003CExtraBestiaryTypes_003Ek__BackingField;
		}
		set
		{
			_003CExtraBestiaryTypes_003Ek__BackingField = value;
		}
	}
}
