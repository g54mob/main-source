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

public class GarlicProjectile : Projectile
{
	private Timer _expireTimer;

	private const float Radius = 16f;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_002d: Expected O, but got I4
		//IL_002d: Expected O, but got I4
		//IL_009f: Expected I, but got O
		base.InitProjectile(pool, weapon, index);
		SetScaleToArea(2f);
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body.setCircle(16f, (float?)(object)0, (float?)(object)0);
		_renderer.enabled = false;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num = _weapon.PInterval();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.GarlicProjectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num2 = (nint)this;
		object obj = default(object);
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
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
				SetScaleToArea(2f);
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
