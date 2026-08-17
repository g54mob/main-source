using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Frog2_Projectile : Projectile
{
	private TP_Frog2_Weapon _trueWeapon;

	private Timer _expireTimer;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_0237: Expected O, but got I4
		//IL_00c8: Expected I4, but got O
		//IL_00ab: Expected O, but got I4
		//IL_0129: Expected O, but got I4
		//IL_0129: Expected O, but got I4
		//IL_0191: Expected I, but got O
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		bool flag;
		if ((object)_weapon == null)
		{
			flag = false;
			goto IL_022d;
		}
		nint num = (nint)typeof(TP_Frog2_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Frog2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Frog2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v33+FFFFFFF8+v69 @ rax_v28*8]");
			if (0 == (nint)typeof(TP_Frog2_Weapon))
			{
				obj3 = 1;
				goto IL_023c;
			}
		}
		obj3 = 0;
		goto IL_023c;
		IL_023c:
		bool flag2 = obj3 == null;
		flag = false;
		if (!flag2)
		{
			flag = (byte)(int)_weapon != 0;
		}
		goto IL_022d;
		IL_022d:
		_trueWeapon = (TP_Frog2_Weapon)flag;
		_renderer.enabled = false;
		if ((object)_trueWeapon != null)
		{
			ArcadeSprite sprite = _sprite;
			BaseBody baseBody = sprite.body.setCircle(96f, (float?)(object)1, (float?)(object)1);
			SetScaleToArea();
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			float num4 = _weapon.PInterval();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog2_Projectile>)+370]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num5 = (nint)this;
			object obj4 = default(object);
			float duration = (float)obj4 * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
			return;
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		Transform transform = base.transform;
		if ((object)_weapon != null)
		{
			Transform transform2 = _weapon.transform;
			if ((object)transform2 != null)
			{
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				SetScaleToArea();
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_00ef: Invalid comparison between O and F4
		//IL_01c7: Expected O, but got I4
		//IL_01b8: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		if (obj2 == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v6+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		EnemyController component = gameObject.GetComponent<EnemyController>();
		object obj3 = default(object);
		if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0 || ((object)component._003CResDebuffs_003Ek__BackingField != null && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f)))
		{
			return;
		}
		EnemyData currentEnemyData = component._currentEnemyData;
		if (currentEnemyData._003CmaxKnockback_003Ek__BackingField > component._003CKnockBack_003Ek__BackingField)
		{
			float num = component._003CKnockBack_003Ek__BackingField + 0.3f;
			component._003CKnockBack_003Ek__BackingField = num;
		}
		if ((object)component._003CResFreeze_003Ek__BackingField != null && (nint)obj3 > 0)
		{
			if ((object)component._003CResFreeze_003Ek__BackingField != null)
			{
				component._003CResFreeze_003Ek__BackingField = (float?)(object)1;
			}
			else
			{
				component._003CResFreeze_003Ek__BackingField = (float?)(object)0;
			}
		}
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}
}
