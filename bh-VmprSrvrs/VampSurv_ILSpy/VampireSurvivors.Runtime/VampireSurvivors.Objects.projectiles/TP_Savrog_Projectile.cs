using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
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

public class TP_Savrog_Projectile : Projectile
{
	private MultiTargetTween _tween1;

	protected PhaserSprite _spikeSprite;

	private Timer _hitboxTimer;

	private bool _isFading;

	private Timer _expireTimer;

	private float _radius = 8f;

	protected override void Awake()
	{
		//IL_008b: Expected O, but got I4
		//IL_0237->IL01c2: Incompatible stack heights: 1 vs 0
		//IL_0073->IL01c2: Incompatible stack heights: 1 vs 0
		//IL_00b8->IL01c2: Incompatible stack heights: 1 vs 0
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			if ((object)this != null)
			{
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_FireValve02");
				if ((object)phaserSprite != null)
				{
					PhaserSprite spikeSprite = phaserSprite.setOrigin(0.5f, (float?)(object)1);
					_spikeSprite = spikeSprite;
					if ((object)_spikeSprite != null)
					{
						Transform transform2 = _spikeSprite.transform;
						bool flag2 = (object)transform2 == null;
						bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
						int num = default(int);
						List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_FireValve", 2, 5, "ThosePeople", num);
						PhaserSprite spikeSprite2 = _spikeSprite;
						bool flag4 = (object)_spikeSprite == null;
						bool flag5 = (object)spikeSprite2._spriteAnimation == null;
						bool startRandomFrame = default(bool);
						Action onComplete = default(Action);
						bool autoSetAnimation = default(bool);
						spikeSprite2._spriteAnimation.AddAnimation("idle", animationFrames, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
						PhaserSprite spikeSprite3 = _spikeSprite;
						bool flag6 = (object)_spikeSprite == null;
						bool flag7 = (object)spikeSprite3._spriteAnimation == null;
						spikeSprite3._spriteAnimation.SetAnimation("idle");
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0499: Expected O, but got I4
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04be: Expected O, but got Unknown
		//IL_0021: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_006c: Invalid comparison between F4 and O
		//IL_013d: Expected O, but got I4
		//IL_0095: Invalid comparison between O and F4
		//IL_0167: Expected O, but got Ref
		//IL_0190: Expected O, but got I4
		//IL_01f2: Expected I, but got O
		//IL_0256: Expected O, but got I4
		//IL_0411: Expected O, but got I4
		//IL_0451: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		_radius = 16f;
		_isCullable = false;
		_isFading = false;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body;
		float radius = _radius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj = radius ^ 0;
		BaseBody baseBody2 = body.setCircle(_radius, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody3 = body;
		baseBody3._enable = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		float num = weapon.PArea();
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		float alpha = 1f;
		if (!flag)
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)2.5f))
			{
				float num2 = (float)obj - 1f;
				float num3 = num2 * 0.35000002f;
				float num4 = num3 / 1.5f;
				alpha = 1f - num4;
			}
			else
			{
				alpha = 0.65f;
			}
		}
		PhaserSprite phaserSprite = _spikeSprite.setAlpha(alpha);
		float xScale = _radius / 46f;
		PhaserSprite phaserSprite2 = _spikeSprite.setScale(xScale, (float?)(object)0);
		Transform transform = _spikeSprite.transform;
		object obj2 = default(object);
		transform.localEulerAngles = (Vector3)(&obj2);
		PhaserSprite phaserSprite3 = _spikeSprite.setVisible(visible: true);
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num5 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj3 = default(object);
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 300f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				//IL_0010: Expected O, but got I4
				ArcadeSprite arcadeSprite3 = setScale(0f, (float?)(object)0);
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			_tween1 = tween;
			if (_hitboxTimer != null)
			{
				_hitboxTimer.Cancel();
			}
			float hitBoxDelay = _weapon.HitBoxDelay;
			Action onComplete = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			};
			float num6 = hitBoxDelay * 0.001f;
			bool flag2 = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer hitboxTimer = Timers.Register(num6, onComplete, null, isLooped: true, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_hitboxTimer = hitboxTimer;
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			float num7 = _weapon.PDuration();
			Action onComplete2 = FadeOut;
			float duration = num6 * 0.001f;
			Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: true, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 0.8f;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)_indexInWeapon * -50f;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Spinning, soundConfig, 200f, 5, flag2 ? 1 : 0);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void InternalUpdate()
	{
	}

	public override void Despawn()
	{
		//IL_00b1: Expected O, but got I4
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		PhaserSprite phaserSprite = _spikeSprite.setVisible(visible: false);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		BaseBody baseBody = body;
		baseBody._enable = false;
		base.Despawn();
	}

	protected void FadeOut()
	{
		//IL_003a: Expected I, but got O
		//IL_009e: Expected O, but got I4
		//IL_00b9: Expected I, but got O
		if (!_isFading)
		{
			_isFading = true;
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}

	private void _003CInitProjectile_003Eb__7_1()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
	}

	private void _003CInitProjectile_003Eb__7_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
