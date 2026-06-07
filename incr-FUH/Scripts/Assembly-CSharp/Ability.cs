using System.Collections.Generic;

public class Ability
{
	public enum AbilityTypeEnum
	{
		Bulldozer = 0,
		ClonePeon = 1,
		FullHapiness = 2,
		PowerCompress = 3,
		CompressAll = 4,
		ProcessAll = 5,
		DoubleAll = 6,
		Airplane = 7,
		Reset = 8,
		LowerDurability = 9
	}

	private AbilityTypeEnum _abilityType;

	private float _delay;

	public int UseCount;

	public Ability(AbilityTypeEnum type)
	{
		_abilityType = type;
		_delay = 0f;
	}

	public static int GetMaxDelay(AbilityTypeEnum type)
	{
		return type switch
		{
			AbilityTypeEnum.Bulldozer => 600, 
			AbilityTypeEnum.ClonePeon => 300, 
			AbilityTypeEnum.FullHapiness => 300, 
			AbilityTypeEnum.PowerCompress => 120, 
			AbilityTypeEnum.CompressAll => 300, 
			AbilityTypeEnum.ProcessAll => 120, 
			AbilityTypeEnum.DoubleAll => 900, 
			AbilityTypeEnum.Airplane => 300, 
			AbilityTypeEnum.Reset => 1200, 
			AbilityTypeEnum.LowerDurability => 300, 
			_ => 999, 
		};
	}

	public int GetMaxDelay()
	{
		return GetMaxDelay(_abilityType);
	}

	public void ReduceDelay(float time)
	{
		_delay -= time;
		if (_delay < 0f)
		{
			_delay = 0f;
		}
	}

	public void ResetDelay()
	{
		if (_abilityType != AbilityTypeEnum.Reset)
		{
			_delay = 0f;
		}
	}

	public static bool CanRunAbility(List<Ability> abilities, AbilityTypeEnum type)
	{
		foreach (Ability ability in abilities)
		{
			if (ability._abilityType == type && ability._delay <= 0f)
			{
				return true;
			}
		}
		return false;
	}

	public static void ResetDelay(List<Ability> abilities, AbilityTypeEnum type)
	{
		foreach (Ability ability in abilities)
		{
			if (ability._abilityType == type)
			{
				ability._delay = ability.GetMaxDelay();
			}
		}
	}

	public static void IncreaseUseCount(List<Ability> abilities, AbilityTypeEnum type)
	{
		foreach (Ability ability in abilities)
		{
			if (ability._abilityType == type)
			{
				ability.UseCount++;
			}
		}
	}

	public static float GetDelay(List<Ability> abilities, AbilityTypeEnum type)
	{
		foreach (Ability ability in abilities)
		{
			if (ability._abilityType == type)
			{
				return ability._delay;
			}
		}
		return 0f;
	}

	public static void SetDelay(List<Ability> abilities, AbilityTypeEnum type, float delay)
	{
		foreach (Ability ability in abilities)
		{
			if (ability._abilityType == type)
			{
				ability._delay = delay;
			}
		}
	}
}
