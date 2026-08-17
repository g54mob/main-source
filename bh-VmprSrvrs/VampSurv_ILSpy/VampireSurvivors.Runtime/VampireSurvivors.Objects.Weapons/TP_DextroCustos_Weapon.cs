using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_DextroCustos_Weapon : TP_Custos_Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__5_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInternalUpdate_003Eb__5_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1438;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private const float YOffset = 0.25f;

	private bool _custos2Equipped;

	public float YOffsetFinal
	{
		get
		{
			//IL_0005: Expected I, but got O
			nint num = (nint)this;
			float num2 = PArea();
			object obj = default(object);
			if (0 <= (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
				return (float)obj * 0.25f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			return (float)obj * 0.25f;
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		BulletPool fireExplosionPool = InitBulletPool(WeaponType.TP_DCUSTOS_EXPLOSION);
		_fireExplosionPool = fireExplosionPool;
		BulletPool fireTrailPool = InitSecondaryBulletPool(WeaponType.TP_DCUSTOS_FIRE);
		_fireTrailPool = fireTrailPool;
		_custos2Equipped = false;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		if (_custos2Equipped)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__5_0;
		if (_003C_003Ec._003C_003E9__5_0 == null)
		{
			match = (_003C_003Ec._003C_003E9__5_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj = x._equipmentType - 1438;
				return obj == null;
			});
		}
		Equipment equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		if ((object)equipment != null && ((UnityEngine.Object)equipment).m_CachedPtr != (IntPtr)0)
		{
			_custos2Equipped = true;
			base.ResetFiringTimer();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0019: Expected I, but got O
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00c1: Invalid comparison between O and F4
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		nint num = (nint)this;
		float num2 = PArea();
		object obj = default(object);
		if (0 <= (nint)obj)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		float num3 = (float)obj * 0.25f;
		Vector2 pos = default(Vector2);
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform);
		float num4 = base.PInterval();
		float num5 = _lastFiringInterval - num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = num5 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num6 = base.PInterval();
			_lastFiringInterval = num3;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}
}
