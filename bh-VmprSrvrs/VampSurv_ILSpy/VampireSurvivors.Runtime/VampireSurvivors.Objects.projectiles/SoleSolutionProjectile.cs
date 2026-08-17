using System;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class SoleSolutionProjectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	private MultiTargetTween _scaleTween2;

	protected override void Awake()
	{
		base.Awake();
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_renderer, 1f);
		_renderer.enabled = false;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_041d: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_0154: Expected O, but got I4
		//IL_00f4: Expected O, but got I
		//IL_00fd: Expected O, but got I4
		//IL_0193: Expected I, but got O
		//IL_0205: Expected O, but got I4
		//IL_027f: Expected I, but got O
		//IL_02ff: Expected O, but got I4
		//IL_031a: Expected I, but got O
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite3 = setAlpha(0f);
		float num = (float)CameraExtensions.OrthographicBounds(_mainCamera).m_Extents * 2f;
		Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rax_v18 (UnityEngine.Bounds)+10]");
		float num2 = 0f * 2f;
		float num3 = num2 * 1.6f;
		if (num3 > num)
		{
			Bounds bounds2 = CameraExtensions.OrthographicBounds(_mainCamera);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rax_v83 (UnityEngine.Bounds)+10]");
			Vector3 vector = (Vector3)0;
			object obj = 0;
		}
		else
		{
			Vector3 vector = CameraExtensions.OrthographicBounds(_mainCamera).m_Center;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rax_v80 (UnityEngine.Bounds)+10]");
			float num4 = 0f * 2f;
			num3 = num4 * 1.6f;
			object obj = 0;
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num5 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 1000f;
			tweenConfig.ease = Ease.InOutSine;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			if (_scaleTween2 != null)
			{
				_scaleTween2.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			nint num6 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				tweenConfig2.duration = 1000f;
				tweenConfig2.ease = Ease.InOutSine;
				tweenConfig2.delay = 9000f;
				tweenConfig2.scale = (float?)(object)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v767 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SoleSolutionProjectile>)+370]");
				TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
				nint num7 = (nint)this;
				tweenConfig2.onComplete = onComplete;
				MultiTargetTween scaleTween2 = Tweens.Add(tweenConfig2);
				_scaleTween2 = scaleTween2;
				if (_hitboxTimer != null)
				{
					_hitboxTimer.Cancel();
				}
				float hitBoxDelay = weapon.HitBoxDelay;
				Action onComplete2 = delegate
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
				};
				float duration = hitBoxDelay * 0.001f;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer hitboxTimer = Timers.Register(duration, onComplete2, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_hitboxTimer = hitboxTimer;
				return;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	protected override void OnUpdate()
	{
		//IL_0011: Invalid comparison between F4 and I4
		//IL_0023: Expected F4, but got I4
		CheckIfVisibleOnScreen();
		bool flag = !(base._pauseWallChecksTimer > 0f);
		float num = 0f;
		if (!flag)
		{
			num = PauseSystem.DeltaTime;
			float pauseWallChecksTimer = base._pauseWallChecksTimer - num;
			base._pauseWallChecksTimer = pauseWallChecksTimer;
		}
		Transform transform = base.transform;
		if ((object)_mainCamera != null)
		{
			Transform transform2 = _mainCamera.transform;
			if ((object)transform2 != null)
			{
				bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
				bool flag3 = (object)transform == null;
				bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void _003CInitProjectile_003Eb__5_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
