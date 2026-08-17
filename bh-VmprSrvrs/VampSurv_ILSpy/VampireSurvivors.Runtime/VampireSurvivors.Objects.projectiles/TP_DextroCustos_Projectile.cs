using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_DextroCustos_Projectile : TP_Custos_Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__3_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInitProjectile_003Eb__3_0(Equipment x)
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

	private TP_DextroCustos_Weapon _baseWeapon;

	private Timer _timer;

	protected override void Awake()
	{
		_startFrame = 1;
		((Projectile)this).Awake();
		InitAnimation(_startFrame);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00c1: Expected I, but got O
		//IL_00cf: Expected I, but got O
		//IL_00df: Expected O, but got I
		//IL_015f: Expected O, but got I4
		//IL_011b: Expected O, but got I
		//IL_02a5: Expected O, but got I4
		//IL_016c: Expected I4, but got O
		//IL_0151: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		InitFireTrails();
		Weapon weapon2 = _weapon;
		int num = ((Equipment)weapon2)._003COwner_003Ek__BackingField.depth;
		int num2 = num + 2;
		ArcadeSprite arcadeSprite = setDepth(num2);
		Weapon weapon3 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__3_0;
		if (_003C_003Ec._003C_003E9__3_0 == null)
		{
			match = (_003C_003Ec._003C_003E9__3_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj4 = x._equipmentType - 1437;
				return obj4 == null;
			});
		}
		Equipment equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		bool flag;
		if ((object)equipment == null)
		{
			flag = false;
			goto IL_029b;
		}
		nint num3 = (nint)equipment;
		nint num4 = (nint)typeof(TP_DextroCustos_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_DextroCustos_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_DextroCustos_Weapon>)+130]");
		object obj3;
		if (num5 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v43+FFFFFFF8+v352 @ rax_v38*8]");
			if (0 == (nint)typeof(TP_DextroCustos_Weapon))
			{
				obj3 = 1;
				goto IL_02aa;
			}
		}
		obj3 = 0;
		goto IL_02aa;
		IL_029b:
		_baseWeapon = (TP_DextroCustos_Weapon)flag;
		TP_DextroCustos_Weapon baseWeapon = _baseWeapon;
		if ((object)_baseWeapon != null && ((UnityEngine.Object)baseWeapon).m_CachedPtr != (IntPtr)0)
		{
			if (_timer != null)
			{
				_timer.Cancel();
			}
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.2f, null, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_timer = timer;
		}
		return;
		IL_02aa:
		bool flag2 = obj3 == null;
		flag = false;
		if (!flag2)
		{
			flag = (byte)(int)equipment != 0;
		}
		goto IL_029b;
	}

	public override void InternalUpdate()
	{
		UpdatePosition();
	}

	private void UpdatePosition()
	{
		//IL_00a3: Expected I, but got O
		//IL_00b9: Invalid comparison between I4 and F4
		TP_DextroCustos_Weapon baseWeapon = _baseWeapon;
		if ((object)_baseWeapon != null && ((UnityEngine.Object)baseWeapon).m_CachedPtr != (IntPtr)0)
		{
			Weapon weapon = _weapon;
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			float timeElapsed = _timer.GetTimeElapsed();
			Weapon weapon2 = _weapon;
			float2 float6 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
			TP_DextroCustos_Weapon baseWeapon2 = _baseWeapon;
			nint num = (nint)baseWeapon2;
			float num2 = baseWeapon2.PArea();
			if (!(0f > timeElapsed))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			}
			float2 float7 = default(float2);
			base.position = float7;
		}
	}

	public override void Bite()
	{
		float2 explosionPoint = base.ExplosionPoint;
		Vector2 pos = default(Vector2);
		Projectile projectile = _custosWeapon.AddFireExplosionAt(pos);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4377]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base._anim.SetAnimation("bite");
		int biteCounter = base._biteCounter + 1;
		base._biteCounter = biteCounter;
	}

	public override void Despawn()
	{
		if (_timer != null)
		{
			_timer.Cancel();
		}
		base.Despawn();
	}
}
