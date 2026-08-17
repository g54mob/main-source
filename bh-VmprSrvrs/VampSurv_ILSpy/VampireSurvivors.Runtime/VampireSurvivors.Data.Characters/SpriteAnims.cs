using System;

namespace VampireSurvivors.Data.Characters;

[Serializable]
public class SpriteAnims
{
	private MeleeAttack _003CmeleeAttack_003Ek__BackingField;

	private MeleeAttack _003CmeleeAttack2_003Ek__BackingField;

	private MeleeAttack _003CrangedAttack_003Ek__BackingField;

	private MeleeAttack _003CmagicAttack_003Ek__BackingField;

	private MeleeAttack _003CspecialAnimation_003Ek__BackingField;

	private MeleeAttack _003CidleAnimation_003Ek__BackingField;

	public MeleeAttack meleeAttack
	{
		get
		{
			return _003CmeleeAttack_003Ek__BackingField;
		}
		set
		{
			_003CmeleeAttack_003Ek__BackingField = value;
		}
	}

	public MeleeAttack meleeAttack2
	{
		get
		{
			return _003CmeleeAttack2_003Ek__BackingField;
		}
		set
		{
			_003CmeleeAttack2_003Ek__BackingField = value;
		}
	}

	public MeleeAttack rangedAttack
	{
		get
		{
			return _003CrangedAttack_003Ek__BackingField;
		}
		set
		{
			_003CrangedAttack_003Ek__BackingField = value;
		}
	}

	public MeleeAttack magicAttack
	{
		get
		{
			return _003CmagicAttack_003Ek__BackingField;
		}
		set
		{
			_003CmagicAttack_003Ek__BackingField = value;
		}
	}

	public MeleeAttack specialAnimation
	{
		get
		{
			return _003CspecialAnimation_003Ek__BackingField;
		}
		set
		{
			_003CspecialAnimation_003Ek__BackingField = value;
		}
	}

	public MeleeAttack idleAnimation
	{
		get
		{
			return _003CidleAnimation_003Ek__BackingField;
		}
		set
		{
			_003CidleAnimation_003Ek__BackingField = value;
		}
	}
}
