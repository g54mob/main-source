using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Shield1_Blade_Projectile : Projectile
{
	private MultiTargetTween _posTween;

	private SpriteAnimation _anim;

	private Timer _durationTimer;

	private PhaserSprite _animatedSprite;

	private MultiTargetTween _scaleTween;

	private float radius = 8f;

	private float _accelMul;

	private float maxDist;

	private Vector2 initialVelocity;

	private Tween accelTween;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	private bool _isDespawning;

	protected override void Awake()
	{
		//IL_00d8: Expected O, but got I4
		//IL_00d8: Expected I4, but got O
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Shield01");
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Shield", 1, 4, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("loop", animationFrames, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float num2 = renderer.width;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene2._renderer;
				if (!(renderer2.height > renderer.width))
				{
					num2 = renderer2.height;
				}
				float num3 = num2 * 0.45f;
				radius = 2f;
				_speed = 1f;
				maxDist = num3;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0120: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0041: Invalid comparison between F4 and O
		//IL_006a: Invalid comparison between O and F4
		base.InitProjectile(pool, weapon, index);
		_isCullable = true;
		_isDespawning = false;
		ArcadeSprite arcadeSprite = setScale(0.5f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(12f, (float?)(object)1, (float?)(object)1);
		float num = _weapon.PArea();
		object obj = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		float alpha = 1f;
		if (!flag)
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)3f))
			{
				float num2 = (float)obj - 1f;
				float num3 = num2 * 0.3f;
				float num4 = num3 * 0.5f;
				alpha = 1f - num4;
			}
			else
			{
				alpha = 0.7f;
			}
		}
		PhaserSprite phaserSprite = _animatedSprite.setAlpha(alpha);
	}

	public void SetAngleVelocity(float angle)
	{
		//IL_038b: Expected I, but got O
		//IL_008e: Expected I, but got O
		//IL_0100: Expected O, but got I4
		//IL_01af: Expected F4, but got I
		nint num = (nint)this;
		base.ApplyAngleVelocity(angle, rotate: false);
		BaseBody baseBody = body;
		initialVelocity = baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (BaseBody)+74]");
		_ = 0;
		float num2 = _weapon.PArea();
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num3 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.ease = Ease.Linear;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			float num4 = (float)baseBody._velocity * radius;
			float num5 = maxDist;
			if (!(num4 > maxDist))
			{
				num5 = num4;
			}
			float projectileSpeed = base.ProjectileSpeed;
			_accelMul = 1f;
			float num6 = num5 / (float)baseBody._velocity;
			if (accelTween != null)
			{
				TweenExtensions.Kill(accelTween);
			}
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (BaseBody)+74]");
			((TP_Shield1_Blade_Projectile)(object)dOSetter)._003CSetAngleVelocity_003Eb__15_1(0f);
			TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, dOSetter, 0f, 0.1f);
			float delay = num6 * 0.9f;
			TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, delay);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			accelTween = tweenerCore;
			if (_hitboxTimer != null)
			{
				_hitboxTimer.Cancel();
			}
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			float hitBoxDelay = _weapon.HitBoxDelay;
			Action onComplete = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			};
			float num7 = hitBoxDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer hitboxTimer = Timers.Register(num7, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_hitboxTimer = hitboxTimer;
			float num8 = _weapon.PDuration();
			Action onComplete2 = StartDespawn;
			float duration = num7 * 0.001f;
			Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void StartDespawn()
	{
		//IL_0069: Expected I, but got O
		//IL_00db: Expected O, but got I4
		//IL_00f6: Expected I, but got O
		if (!_isDespawning)
		{
			_isDespawning = true;
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.ease = Ease.Linear;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Shield1_Blade_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
		}
	}

	private void LateUpdate()
	{
		//IL_0048: Expected O, but got F4
		float num = (float)initialVelocity * _accelMul;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Shield1_Blade_Projectile)+108]");
		float num2 = 0f * _accelMul;
		BaseBody baseBody = body;
		baseBody._velocity = (float2)num;
	}

	public override void Despawn()
	{
		if (_durationTimer != null)
		{
			_durationTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (accelTween != null)
		{
			TweenExtensions.Kill(accelTween);
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_posTween != null)
		{
			_posTween.Kill();
		}
		base.Despawn();
	}

	private float _003CSetAngleVelocity_003Eb__15_0()
	{
		return _accelMul;
	}

	private void _003CSetAngleVelocity_003Eb__15_1(float x)
	{
		_accelMul = x;
	}

	private void _003CSetAngleVelocity_003Eb__15_2()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
