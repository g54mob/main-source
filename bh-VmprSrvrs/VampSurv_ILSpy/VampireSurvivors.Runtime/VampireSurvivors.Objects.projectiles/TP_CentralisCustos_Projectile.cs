using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_CentralisCustos_Projectile : Projectile
{
	private Timer _expireTimer;

	private const float Radius = 32f;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_002d: Expected O, but got I4
		//IL_002d: Expected O, but got I4
		//IL_009f: Expected I, but got O
		base.InitProjectile(pool, weapon, index);
		UpdatePosition();
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body.setCircle(32f, (float?)(object)1, (float?)(object)1);
		_renderer.enabled = false;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num = _weapon.PInterval();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_CentralisCustos_Projectile>)+370]");
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
		UpdatePosition();
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	private void UpdatePosition()
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
}
