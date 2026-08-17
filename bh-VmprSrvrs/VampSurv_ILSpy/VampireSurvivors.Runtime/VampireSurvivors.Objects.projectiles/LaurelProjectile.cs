using System;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class LaurelProjectile : Projectile
{
	private Timer _expireTimer;

	private const float Radius = 16f;

	private MultiTargetTween _imageTween2;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00a2: Expected I, but got O
		//IL_0114: Expected I4, but got I8
		//IL_013e: Expected O, but got I4
		//IL_0199: Expected O, but got I4
		//IL_0199: Expected O, but got I4
		//IL_01ad: Expected O, but got I4
		//IL_038d: Expected I, but got O
		//IL_03d8: Expected I, but got O
		//IL_02aa: Expected I, but got O
		//IL_027b->IL0311: Incompatible stack heights: 3 vs 0
		base.InitProjectile(pool, weapon, index);
		if (_imageTween2 != null)
		{
			_imageTween2.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_renderer != null)
		{
			Transform transform = _renderer.transform;
			if (array != null)
			{
				if ((object)transform != null)
				{
					nint num = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj = default(object);
					if (obj == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					tweenConfig.repeat = -1;
					tweenConfig.duration = 800f;
					tweenConfig.ease = Ease.Linear;
					tweenConfig.angle = (float?)(object)1;
					MultiTargetTween imageTween = Tweens.Add(tweenConfig);
					_imageTween2 = imageTween;
					if (body != null)
					{
						BaseBody baseBody = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
						ArcadeSprite arcadeSprite = setScale(1.35f, (float?)(object)0);
						ArcadeSprite arcadeSprite2 = setVisible(visible: true);
						BulletPool cachedTransform = (BulletPool)(object)_cachedTransform;
						if ((object)weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
						{
							Transform transform2 = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
							if ((object)transform2 != null)
							{
								bool flag = ((TweenConfig)(object)transform2).targets == null;
								Transform.get_position_Injected((IntPtr)((TweenConfig)(object)transform2).targets, out Vector3 ret);
								bool flag2 = (object)_cachedTransform == null;
								bool flag3 = ((EventEmitter)cachedTransform).callbacks == null;
								Vector3 value = default(Vector3);
								Transform.set_position_Injected((IntPtr)((EventEmitter)cachedTransform).callbacks, ref value);
								if (_expireTimer != null)
								{
									_expireTimer.Cancel();
								}
								if ((object)_weapon != null)
								{
									float num2 = _weapon.PInterval();
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v888 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LaurelProjectile>)+370]");
									Action onComplete = new Action(this, (IntPtr)0);
									nint num3 = (nint)this;
									float num4 = (float)ret + 500f;
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
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_00ef: Expected O, but got I4
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected I4, but got Unknown
		Transform transform = base.transform;
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Transform transform2 = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
			if ((object)transform2 != null)
			{
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				Weapon weapon2 = _weapon;
				bool flag4 = (object)_weapon == null;
				bool flag5 = (object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null;
				int num = ((Equipment)weapon2)._003COwner_003Ek__BackingField.Depth;
				PhaserScene s_scene = ArcadePhysics.s_scene;
				bool flag6 = ArcadePhysics.s_scene == null;
				PhaserScene.Renderer renderer = s_scene._renderer;
				bool flag7 = s_scene._renderer == null;
				int num2 = renderer.pixelHeight >> 31;
				object obj = renderer.pixelHeight - num2;
				object obj2 = obj >> 1;
				object obj3 = num - obj2;
				bool flag8 = (object)_renderer == null;
				int sortingOrder = obj3 + 10;
				_renderer.sortingOrder = sortingOrder;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_imageTween2 != null)
		{
			_imageTween2.Kill();
		}
		base.Despawn();
	}
}
