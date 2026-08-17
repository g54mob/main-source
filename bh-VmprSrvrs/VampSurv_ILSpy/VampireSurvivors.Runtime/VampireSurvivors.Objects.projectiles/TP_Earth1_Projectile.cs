using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Earth1_Projectile : Projectile
{
	private float _radius;

	private PhaserSprite _animatedSprite;

	private Tween _radiusTween;

	private float _startingAngle;

	private bool _isDespawning;

	private List<uint> _tints;

	private MultiTargetTween _scaleTween;

	private Timer _expireTimer;

	protected unsafe override void Awake()
	{
		//IL_014d: Expected O, but got I4
		//IL_014d: Expected I4, but got O
		//IL_01f2: Expected O, but got F4
		//IL_018b: Expected O, but got Ref
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				GameObject gameObject = base.gameObject;
				Vector2 vector = default(Vector2);
				PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Rock01");
				_animatedSprite = animatedSprite;
				string text = default(string);
				int num = default(int);
				bool flag = default(bool);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Rock", 1, 4, vector, text, num, flag);
				PhaserSprite animatedSprite2 = _animatedSprite;
				if ((object)_animatedSprite != null && (object)animatedSprite2._spriteAnimation != null)
				{
					bool autoSetAnimation = default(bool);
					animatedSprite2._spriteAnimation.AddAnimation("explode", animationFrames, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
					object obj = UnityEngine.Random.value;
					if ((object)_animatedSprite != null)
					{
						Transform transform = _animatedSprite.transform;
						if ((object)transform != null)
						{
							Vector3 value = default(Vector3);
							transform.localEulerAngles = (Vector3)(&value);
							if ((object)_animatedSprite != null)
							{
								Transform transform2 = _animatedSprite.transform;
								bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
								Transform transform3 = base.transform;
								bool flag3 = (object)transform3 == null;
								bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								Vector3 value2 = default(Vector3);
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_036f: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0381: Expected O, but got F4
		//IL_0081: Expected O, but got I4
		//IL_0081: Expected O, but got I4
		//IL_0095: Expected O, but got I4
		//IL_00f3: Expected O, but got I4
		//IL_01c6: Expected I, but got O
		//IL_0226: Expected O, but got I4
		//IL_025e: Expected O, but got I4
		//IL_03ba: Expected O, but got F4
		//IL_0323: Expected I4, but got F4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		_isDespawning = false;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		Weapon weapon2 = _weapon;
		float num = weapon2.PArea();
		float num2 = default(float);
		float minInclusive = num2 * 0.75f;
		float num3 = UnityEngine.Random.Range(minInclusive, num2);
		object obj = UnityEngine.Random.value;
		float speed = num3 + 2f;
		float radius = num3 * _radius;
		_speed = speed;
		BaseBody baseBody2 = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setScale(0.1f, (float?)(object)0);
		float num4 = (_startingAngle = UnityEngine.Random.Range(265f, 275f)) * ((float)Math.PI / 180f);
		base.ApplyAngleVelocity(num4);
		PhaserSprite phaserSprite = _animatedSprite.setScale(num3, (float?)(object)0);
		PhaserSprite phaserSprite2 = _animatedSprite.setAlpha(0.75f);
		PhaserSprite phaserSprite3 = _animatedSprite.setVisible(visible: true);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A570");
		uint tint = default(uint);
		PhaserSprite phaserSprite4 = _animatedSprite.setTint(tint);
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("explode");
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num5 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		bool flag = obj2 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
		{
			Volume = (float?)(object)1,
			Rate = 1f
		};
		object obj3 = UnityEngine.Random.value;
		float num6 = num4 - 0.5f;
		float detune = num6 * 300f;
		soundConfig.Detune = detune;
		float num7 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_ImpactHeavy, soundConfig, 50f, 1, num7);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num8 = _weapon.PDuration();
		Action onComplete = StartDespawn;
		float duration = 0f * 0.001f;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num7 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	private void StartDespawn()
	{
		//IL_0098: Expected I, but got O
		//IL_00fc: Expected O, but got I4
		//IL_0117: Expected I, but got O
		if (!_isDespawning)
		{
			_isDespawning = true;
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
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
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Earth1_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
		}
	}

	public override void Despawn()
	{
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		if (_radiusTween != null)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		_expireTimer.Cancel();
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0056: Expected I, but got O
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected F4, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _bounces > 0)
		{
			nint num = (nint)this;
			int bounces = _bounces - 1;
			_bounces = bounces;
			float startingAngle = _startingAngle;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			float angleAim = startingAngle ^ 0;
			base.ApplyAngleVelocity(angleAim);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	public TP_Earth1_Projectile()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0288: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_02b0: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_02d8: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_0300: Expected O, but got I
		//IL_022a: Expected O, but got I
		_radius = 16f;
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(16777215u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 16777215;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(13421772u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 13421772;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(14540253u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 14540253;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(14548957u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 14548957;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(16777181u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 16777181;
		}
		_tints = list;
		base._002Ector();
	}
}
