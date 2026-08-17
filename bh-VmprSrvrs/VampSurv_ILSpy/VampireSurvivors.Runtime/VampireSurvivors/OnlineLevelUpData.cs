using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors;

public struct OnlineLevelUpData
{
	private List<WeaponType> _003CChosenLevelUpWeapons_003Ek__BackingField;

	private List<ItemType> _003CChosenLevelUpItems_003Ek__BackingField;

	private List<CharacterController> _003CChosenAmuletTargets_003Ek__BackingField;

	private List<WeightedLimitBreak> _003CChosenLimitBreaks_003Ek__BackingField;

	private bool _003CShouldSwapToLevelUpUi_003Ek__BackingField;

	private CharacterController _003CTargetCharacter_003Ek__BackingField;

	private bool _003CAdjustXpFactors_003Ek__BackingField;

	public List<WeaponType> ChosenLevelUpWeapons
	{
		get
		{
			return _003CChosenLevelUpWeapons_003Ek__BackingField;
		}
		set
		{
			_003CChosenLevelUpWeapons_003Ek__BackingField = value;
		}
	}

	public List<ItemType> ChosenLevelUpItems
	{
		get
		{
			return _003CChosenLevelUpItems_003Ek__BackingField;
		}
		set
		{
			_003CChosenLevelUpItems_003Ek__BackingField = value;
		}
	}

	public List<CharacterController> ChosenAmuletTargets
	{
		get
		{
			return _003CChosenAmuletTargets_003Ek__BackingField;
		}
		set
		{
			_003CChosenAmuletTargets_003Ek__BackingField = value;
		}
	}

	public List<WeightedLimitBreak> ChosenLimitBreaks
	{
		get
		{
			return _003CChosenLimitBreaks_003Ek__BackingField;
		}
		set
		{
			_003CChosenLimitBreaks_003Ek__BackingField = value;
		}
	}

	public bool ShouldSwapToLevelUpUi
	{
		get
		{
			return _003CShouldSwapToLevelUpUi_003Ek__BackingField;
		}
		set
		{
			_003CShouldSwapToLevelUpUi_003Ek__BackingField = value;
		}
	}

	public CharacterController TargetCharacter
	{
		get
		{
			return _003CTargetCharacter_003Ek__BackingField;
		}
		set
		{
			_003CTargetCharacter_003Ek__BackingField = value;
		}
	}

	public bool AdjustXpFactors
	{
		get
		{
			return _003CAdjustXpFactors_003Ek__BackingField;
		}
		set
		{
			_003CAdjustXpFactors_003Ek__BackingField = value;
		}
	}
}
