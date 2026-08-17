using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using UnityEngine;

namespace Assets.Scripts.Player.Movement;

public class PlayerMovementValues
{
	private const float defaultMoveSpeed = 2700f;

	private const float defaultSwimSpeed = 10f;

	public const float defaultMaxSpeed = 10f;

	private const float defaultSlideForce = 200f;

	private const float defaultAirDeceleration = 0.003f;

	private const float defaultExtraGravity = 11f;

	private float _003CmoveSpeed_003Ek__BackingField;

	private float _003CmaxRunSpeed_003Ek__BackingField;

	private float _003CairDeceleration_003Ek__BackingField;

	private float _003CslideForce_003Ek__BackingField = 200f;

	private float _003CextraGravity_003Ek__BackingField = 11f;

	private float _003CswimSpeed_003Ek__BackingField = 10f;

	private bool inited;

	private ECharacter currentCharacter;

	private float counterMovement;

	public float moveSpeed
	{
		get
		{
			return _003CmoveSpeed_003Ek__BackingField;
		}
		private set
		{
			_003CmoveSpeed_003Ek__BackingField = value;
		}
	}

	public float maxRunSpeed
	{
		get
		{
			return _003CmaxRunSpeed_003Ek__BackingField;
		}
		private set
		{
			_003CmaxRunSpeed_003Ek__BackingField = value;
		}
	}

	public float airDeceleration
	{
		get
		{
			return _003CairDeceleration_003Ek__BackingField;
		}
		private set
		{
			_003CairDeceleration_003Ek__BackingField = value;
		}
	}

	public float slideForce
	{
		get
		{
			return _003CslideForce_003Ek__BackingField;
		}
		private set
		{
			_003CslideForce_003Ek__BackingField = value;
		}
	}

	public float extraGravity
	{
		get
		{
			return _003CextraGravity_003Ek__BackingField;
		}
		private set
		{
			_003CextraGravity_003Ek__BackingField = value;
		}
	}

	public float swimSpeed
	{
		get
		{
			return _003CswimSpeed_003Ek__BackingField;
		}
		private set
		{
			_003CswimSpeed_003Ek__BackingField = value;
		}
	}

	private void Init(Rigidbody rb)
	{
		float mass = rb.mass;
		float num = mass * _003CslideForce_003Ek__BackingField;
		inited = true;
		_003CslideForce_003Ek__BackingField = num;
	}

	public void CreateMovement(Rigidbody rb, ECharacter character)
	{
		if (inited)
		{
			if (character == currentCharacter)
			{
				return;
			}
			currentCharacter = character;
		}
		else
		{
			float mass = rb.mass;
			float num = mass * _003CslideForce_003Ek__BackingField;
			inited = true;
			currentCharacter = character;
			_003CslideForce_003Ek__BackingField = num;
		}
		float mass2 = rb.mass;
		float num2 = mass2 * 2700f;
		_003CmoveSpeed_003Ek__BackingField = num2;
		float mass3 = rb.mass;
		float num3 = mass3 * 200f;
		_003CmaxRunSpeed_003Ek__BackingField = 10f;
		_003CairDeceleration_003Ek__BackingField = 0.003f;
		_003CslideForce_003Ek__BackingField = num3;
		counterMovement = character switch
		{
			ECharacter.Calcium => 0.2f, 
			ECharacter.TonyMcZoom => 0.15f, 
			_ => 1f, 
		};
		float mass4 = rb.mass;
		float num4 = mass4 * 10f;
		_003CswimSpeed_003Ek__BackingField = num4;
		switch (character)
		{
		default:
		{
			float mass6 = rb.mass;
			float num7 = mass6 * 11f;
			_003CextraGravity_003Ek__BackingField = num7;
			break;
		}
		case ECharacter.Vlad:
			_003CextraGravity_003Ek__BackingField = 0f;
			break;
		case ECharacter.Spaceman:
		{
			float mass5 = rb.mass;
			float num5 = mass5 * -11f;
			float num6 = num5 * 0.75f;
			_003CextraGravity_003Ek__BackingField = num6;
			break;
		}
		}
	}

	private static float GetCounterMovementMultiplier(ECharacter character)
	{
		return character switch
		{
			ECharacter.Calcium => 0.2f, 
			ECharacter.TonyMcZoom => 0.15f, 
			_ => 1f, 
		};
	}

	private static float GetMoveSpeedMultiplier(ECharacter character)
	{
		return 1f;
	}

	public float GetCounterMovementMultiplier(FrictionModifier.EFrictionSurface surface)
	{
		float num = counterMovement;
		if (surface != FrictionModifier.EFrictionSurface.Normal && surface == FrictionModifier.EFrictionSurface.Ice)
		{
			num *= 0.75f;
		}
		return num;
	}

	public static float GetSlowdownMultiplier(FrictionModifier.EFrictionSurface surface, ECharacter character)
	{
		//IL_0095: Expected F4, but got I4
		switch (character)
		{
		case ECharacter.Calcium:
			return 0.06f;
		default:
			if (surface == FrictionModifier.EFrictionSurface.Normal || surface != FrictionModifier.EFrictionSurface.Ice)
			{
				return 1f;
			}
			return 0.4f;
		case ECharacter.TonyMcZoom:
			return 0f;
		}
	}

	public float GetMoveSpeed(FrictionModifier.EFrictionSurface surface, bool grounded)
	{
		float stat = PlayerStats.GetStat(EStat.MoveSpeedMultiplier);
		float num = stat - 1.5f;
		float num2 = num * 0.25f;
		float num3 = num2 + 1f;
		bool flag = 1f > num3;
		float num4 = 1f;
		if (!flag)
		{
			bool flag2 = !(num3 > 4f);
			num4 = 4f;
			if (flag2)
			{
				goto IL_00af;
			}
		}
		num3 = num4;
		goto IL_00af;
		IL_00af:
		float num5 = _003CmoveSpeed_003Ek__BackingField;
		if (surface == FrictionModifier.EFrictionSurface.Ice)
		{
			num5 *= 0.4f;
		}
		return num5 * num3;
	}

	public float GetGravity(Rigidbody rb, ECharacter character)
	{
		//IL_0062: Expected F4, but got I4
		switch (character)
		{
		default:
		{
			float mass2 = rb.mass;
			return mass2 * 11f;
		}
		case ECharacter.Vlad:
			return 0f;
		case ECharacter.Spaceman:
		{
			float mass = rb.mass;
			float num = mass * -11f;
			return num * 0.75f;
		}
		}
	}

	public float GetMaxSpeed()
	{
		float stat = PlayerStats.GetStat(EStat.MoveSpeedMultiplier);
		return stat * _003CmaxRunSpeed_003Ek__BackingField;
	}

	public float GetMaxSpeedNoMultiplier()
	{
		return _003CmaxRunSpeed_003Ek__BackingField;
	}
}
