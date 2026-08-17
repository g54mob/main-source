using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class BocceProjectile : Projectile
{
	private Timer _expireTimer;

	public int _Radius = 16;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Rings3", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0012: Expected I4, but got O
		//IL_0099: Expected O, but got I4
		//IL_0099: Expected O, but got I4
		//IL_0099: Expected F4, but got I4
		//IL_00e5: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		object cachedTransform = _cachedTransform;
		if ((object)weapon != null)
		{
			int num = (int)((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdi_v8 (System.Int32)+B8]");
				int num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdi_v8 (System.Int32)+B8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdi_v9 (System.Int32)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdi_v9 (System.Int32)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
					bool flag2 = (object)_cachedTransform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbp_v2 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbp_v2 (System.Object)+10]");
					Vector3 value = default(Vector3);
					Transform.set_position_Injected((IntPtr)0, ref value);
					bool flag4 = body == null;
					BaseBody baseBody = body.setCircle(_Radius, (float?)(object)0, (float?)(object)0);
					bool flag5 = (object)_weapon == null;
					float num3 = _weapon.PArea();
					float num4 = (float)ret + (float)ret;
					ArcadeSprite arcadeSprite = setScale(num4, (float?)(object)0);
					ArcadeSprite arcadeSprite2 = setVisible(visible: false);
					if (_expireTimer != null)
					{
						_expireTimer.Cancel();
					}
					float num5 = weapon.PInterval();
					Action onComplete = delegate
					{
						base.Despawn();
					};
					float duration = num4 * 0.001f;
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_expireTimer = expireTimer;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_00d2: Expected O, but got I4
		Weapon weapon = _weapon;
		Transform cachedTransform = _cachedTransform;
		if ((object)_weapon != null)
		{
			Weapon weapon2 = (Weapon)(object)((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				Weapon firingAnimEvent = (Weapon)(object)weapon2._firingAnimEvent;
				if (weapon2._firingAnimEvent != null)
				{
					bool flag = ((UnityEngine.Object)firingAnimEvent).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)firingAnimEvent).m_CachedPtr, out Vector3 ret);
					bool flag2 = (object)_cachedTransform == null;
					bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
					bool flag4 = (object)_weapon == null;
					float num = _weapon.PArea();
					float xScale = (float)ret + (float)ret;
					ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CInitProjectile_003Eb__3_0()
	{
		base.Despawn();
	}
}
