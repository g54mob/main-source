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

public class TP_SinistroCustos_Weapon : TP_Custos_Weapon
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
				object obj = x._equipmentType - 1437;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private const float YOffset = 0.25f;

	private bool _custos1Equipped;

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
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			}
			bool flag = !_custos1Equipped;
			float result = (float)obj * 0.25f;
			if (!flag)
			{
				float num3 = (float)obj * 0.35f;
				return 0.25f - num3;
			}
			return result;
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		BulletPool iceExplosionPool = InitBulletPool(WeaponType.TP_SCUSTOS_EXPLOSION);
		_iceExplosionPool = iceExplosionPool;
		BulletPool iceTrailPool = InitSecondaryBulletPool(WeaponType.TP_DCUSTOS_FIRE);
		_iceTrailPool = iceTrailPool;
		_custos1Equipped = false;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		if (_custos1Equipped)
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
				object obj = x._equipmentType - 1437;
				return obj == null;
			});
		}
		Equipment equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		if ((object)equipment != null && ((UnityEngine.Object)equipment).m_CachedPtr != (IntPtr)0)
		{
			_custos1Equipped = true;
			base.ResetFiringTimer();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0019: Expected I, but got O
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00ed: Invalid comparison between O and F4
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
		if (!_custos1Equipped)
		{
			Vector2 pos = default(Vector2);
			Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform);
			float num3 = base.PInterval();
			float lastFiringInterval = _lastFiringInterval;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj2 = lastFiringInterval & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
			{
				goto IL_0105;
			}
		}
		float num4 = base.PInterval();
		_lastFiringInterval = 0f;
		base.ResetFiringTimer();
		goto IL_0105;
		IL_0105:
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	private float GetYOffsetFinal()
	{
		//IL_0005: Expected I, but got O
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
		bool flag = !_custos1Equipped;
		float result = (float)obj * 0.25f;
		if (!flag)
		{
			float num3 = (float)obj * 0.35f;
			return 0.25f - num3;
		}
		return result;
	}
}
