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

public class TP_Shield2_Meteor_Projectile : Projectile
{
	private SpriteTrail spriteTrail;

	private MultiTargetTween _posTween;

	private SpriteAnimation _anim;

	private Timer _durationTimer;

	private PhaserSprite _animatedSprite;

	private PhaserSprite _animatedSprite2;

	private MultiTargetTween _scaleTween;

	private float radius = 8f;

	private float _accelMul;

	private float maxDist;

	private Vector2 initialVelocity;

	private Tween accelTween;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	private bool _isDespawning;

	private bool _increaseAngle;

	private float _intendedAngle;

	private MultiTargetTween _alphaTween;

	protected unsafe override void Awake()
	{
		//IL_00e4: Expected O, but got Ref
		//IL_01db: Expected I4, but got I8
		//IL_01f8: Expected I4, but got I8
		//IL_0215: Expected I4, but got I8
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_ShieldDark04");
		PhaserSprite animatedSprite = phaserSprite.setAlpha(0.85f);
		_animatedSprite = animatedSprite;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite phaserSprite2 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_ShieldDark04");
		PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		object obj = default(object);
		PhaserSprite animatedSprite2 = phaserSprite3.setTintFill(isEnabled: true, (Color?)(object)(&obj));
		_animatedSprite2 = animatedSprite2;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float num = renderer.width;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene2._renderer;
				if (!(renderer2.height > renderer.width))
				{
					num = renderer2.height;
				}
				float num2 = num * 0.45f;
				PhaserSprite animatedSprite3 = _animatedSprite;
				radius = 2f;
				_speed = 1f;
				maxDist = num2;
				SpriteTrail spriteTrail = this.spriteTrail;
				spriteTrail._MainSprite = animatedSprite3._spriteRenderer;
				ArcadeSprite arcadeSprite = setDepth(-1993);
				PhaserSprite phaserSprite4 = _animatedSprite.setDepth(-1993);
				PhaserSprite phaserSprite5 = _animatedSprite2.setDepth(-1993);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0157: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_00e6: Expected O, but got I4
		//IL_011a: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		_isDespawning = false;
		ArcadeSprite arcadeSprite = setScale(0.5f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
		_speed = 2f;
		base.angle = 0f;
		Transform transform = _animatedSprite.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform transform2 = _animatedSprite2.transform;
		bool flag2 = (object)transform2 == null;
		bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
		bool flag4 = (object)_animatedSprite == null;
		_animatedSprite.angle = 0f;
		bool flag5 = (object)_animatedSprite2 == null;
		_animatedSprite2.angle = 0f;
		bool flag6 = (object)_animatedSprite == null;
		PhaserSprite phaserSprite = _animatedSprite.setScale(0.5f, (float?)(object)0);
		bool flag7 = (object)_animatedSprite2 == null;
		PhaserSprite phaserSprite2 = _animatedSprite2.setScale(0.5f, (float?)(object)0);
	}

	protected override void OnUpdate()
	{
		//IL_0011: Invalid comparison between F4 and I4
		//IL_005e: Expected O, but got F4
		//IL_0084: Expected O, but got I8
		//IL_009b: Expected O, but got I4
		CheckIfVisibleOnScreen();
		if (base._pauseWallChecksTimer > 0f)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float pauseWallChecksTimer = base._pauseWallChecksTimer - deltaTime;
			base._pauseWallChecksTimer = pauseWallChecksTimer;
		}
		float num = (float)initialVelocity * _accelMul;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Shield2_Meteor_Projectile)+118]");
		float num2 = 0f * _accelMul;
		BaseBody baseBody = body;
		baseBody._velocity = (float2)num;
		bool flag = (nint)initialVelocity <= 0;
		object obj = 4294967295L;
		if (!flag)
		{
			obj = 1;
		}
		float num3;
		ArcadeSprite arcadeSprite;
		if (!_increaseAngle)
		{
			num3 = _intendedAngle;
			arcadeSprite = this;
		}
		else
		{
			Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
			Vector3 localEulerAngles = cachedTrans.localEulerAngles;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num4 = deltaTime2 * 1000f;
			float num5 = _weapon.PSpeed();
			float num6 = (float)obj * num4;
			float num7 = num6 * 0.1618f;
			float num8 = deltaTime2 * num7;
			num3 = num8 + localEulerAngles.z;
			arcadeSprite = this;
		}
		arcadeSprite.angle = num3;
	}

	public void SetAngleVelocity(float _angle)
	{
		//IL_06cb: Expected I, but got O
		//IL_0067: Invalid comparison between F4 and O
		//IL_008c: Invalid comparison between O and F4
		//IL_0153: Expected O, but got I
		//IL_01ac: Expected O, but got I
		//IL_0264: Expected I, but got O
		//IL_02d6: Expected O, but got I4
		//IL_0307: Expected O, but got I4
		//IL_0364: Expected I, but got O
		//IL_03d6: Expected O, but got I4
		nint num = (nint)this;
		base.ApplyAngleVelocity(_angle, rotate: false);
		BaseBody baseBody = body;
		float intendedAngle = _angle * 57.29578f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v4 (BaseBody)+74]");
		_ = 0;
		initialVelocity = baseBody._velocity;
		_intendedAngle = intendedAngle;
		base.angle = intendedAngle;
		float num2 = _weapon.PArea();
		float2 velocity = baseBody._velocity;
		float num6;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref velocity))
		{
			if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref baseBody._velocity) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)3f))
			{
				float num3 = (float)baseBody._velocity - 1f;
				float num4 = num3 * 0.7f;
				float num5 = num4 * 0.5f;
				num6 = 1f - num5;
			}
			else
			{
				num6 = 0.3f;
			}
		}
		else
		{
			num6 = 1f;
		}
		PhaserSprite phaserSprite = _animatedSprite.setAlpha(num6);
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v19 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v19 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v19 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rdx_v10+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(num6);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v19 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
		}
		SpriteTrail spriteTrail = this.spriteTrail.SetAlphas(list);
		PhaserSprite phaserSprite2 = _animatedSprite2.setAlpha(1f);
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_animatedSprite2 != null)
		{
			nint num8 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
		ArcadeSprite arcadeSprite = setScale(0.5f, (float?)(object)0);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		nint num9 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj4 = default(object);
		if (obj4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 200f;
			tweenConfig2.ease = Ease.Linear;
			tweenConfig2.scale = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig2);
			_scaleTween = scaleTween;
			float num10 = (float)baseBody._velocity * radius;
			float num11 = maxDist;
			if (!(num10 > maxDist))
			{
				num11 = num10;
			}
			float projectileSpeed = base.ProjectileSpeed;
			_accelMul = 1f;
			float num12 = num11 / (float)baseBody._velocity;
			if (accelTween != null)
			{
				TweenExtensions.Kill(accelTween);
			}
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			((TP_Shield2_Meteor_Projectile)(object)dOSetter)._003CSetAngleVelocity_003Eb__21_1(0.5f);
			TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, dOSetter, 0f, 0.1f);
			float delay = num12 * 0.9f;
			TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, delay);
			TweenCallback tweenCallback = Spinnn;
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1137 @ rax_v57 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
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
			float num13 = hitBoxDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer hitboxTimer = Timers.Register(num13, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_hitboxTimer = hitboxTimer;
			float num14 = _weapon.PDuration();
			Action onComplete2 = StartDespawn;
			float duration = num13 * 0.001f;
			Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private void Spinnn()
	{
		_increaseAngle = true;
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Shield2_Meteor_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
		}
	}

	public override void Despawn()
	{
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_durationTimer != null)
		{
			_durationTimer.Cancel();
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

	private float _003CSetAngleVelocity_003Eb__21_0()
	{
		return _accelMul;
	}

	private void _003CSetAngleVelocity_003Eb__21_1(float x)
	{
		_accelMul = x;
	}

	private void _003CSetAngleVelocity_003Eb__21_2()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
