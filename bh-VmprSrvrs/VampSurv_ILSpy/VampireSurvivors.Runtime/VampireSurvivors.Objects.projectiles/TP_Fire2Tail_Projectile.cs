using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
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

public class TP_Fire2Tail_Projectile : Projectile
{
	private float _radius = 16f;

	private TP_Fire2_Projectile _headProjectile;

	private int _frameCounter;

	private bool _lateInit;

	private PhaserSprite _animatedSprite;

	private const int AnimFPS = 30;

	private Tween _radiusTween;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private Timer _hitboxTimer;

	protected override void Awake()
	{
		//IL_00fc: Expected O, but got I4
		//IL_00fc: Expected I4, but got O
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite = setFrame(sprite);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Salame01");
		GameObject gameObject2 = phaserSprite.gameObject;
		((UnityEngine.Object)gameObject2).SetName("TP_Fire2Tail_Sprite");
		_animatedSprite = phaserSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Salame", 1, 6, vector, text, num, flag);
		PhaserSprite animatedSprite = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite._spriteAnimation.AddAnimation("loop", animationFrames, 30, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0268: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_01d2: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		_frameCounter = 0;
		_lateInit = false;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		Tween radiusTween = _radiusTween;
		if (_radiusTween != null && radiusTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((TP_Fire2Tail_Projectile)(object)dOSetter)._003CInitProjectile_003Eb__11_1(1f);
		TweenerCore<float, float, FloatOptions> radiusTween2 = DOTween.To(getter, dOSetter, _radius, 0.25f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_radiusTween = radiusTween2;
		PhaserSprite animatedSprite = _animatedSprite;
		if ((object)_animatedSprite != null && ((UnityEngine.Object)animatedSprite).m_CachedPtr != (IntPtr)0)
		{
			float2 localPosition = default(float2);
			PhaserSprite phaserSprite = _animatedSprite.setLocalPosition(localPosition);
		}
		PhaserSprite phaserSprite2 = _animatedSprite.setAlpha(1f);
		PhaserSprite phaserSprite3 = _animatedSprite.setVisible(visible: true);
		PhaserSprite animatedSprite2 = _animatedSprite;
		animatedSprite2._spriteAnimation.SetAnimation("loop");
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float detune = (float)_indexInWeapon * 100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.FireExplosion, soundConfig, 200f, 5, time);
	}

	public override void InternalUpdate()
	{
		//IL_0249: Invalid comparison between F4 and I4
		//IL_00e1: Expected I, but got O
		//IL_017c: Expected O, but got I4
		//IL_0308->IL03a4: Incompatible stack heights: 1 vs 0
		//IL_0343->IL03a4: Incompatible stack heights: 1 vs 0
		//IL_038e->IL03a4: Incompatible stack heights: 2 vs 0
		//IL_0435->IL03e1: Incompatible stack heights: 3 vs 0
		if (_lateInit)
		{
			goto IL_0237;
		}
		TP_Fire2_Projectile headProjectile = _headProjectile;
		_lateInit = true;
		if ((object)_headProjectile != null && (object)_animatedSprite != null)
		{
			PhaserSprite phaserSprite = _animatedSprite.setAlpha(headProjectile._scaledAlpha);
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					if ((object)_headProjectile != null)
					{
						tweenConfig.duration = 250f;
						tweenConfig.scale = (float?)(object)1;
						MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
						_scaleTween = scaleTween;
						if (_hitboxTimer != null)
						{
							_hitboxTimer.Cancel();
						}
						Action onComplete = delegate
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
						};
						float duration = headProjectile._cachedWeaponHitBoxDelayOverSpeed * 0.001f;
						bool useRealTime = default(bool);
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_hitboxTimer = hitboxTimer;
						goto IL_0237;
					}
				}
			}
		}
		goto IL_03a4;
		IL_03a4:
		throw new NullReferenceException();
		IL_0237:
		float deltaTime = PauseSystem.DeltaTime;
		if (!(deltaTime > 0f))
		{
			return;
		}
		Transform transform = base.transform;
		TP_Fire2_Projectile headProjectile2 = _headProjectile;
		if ((object)_headProjectile != null)
		{
			List<Vector3> positions = headProjectile2._positions;
			if (headProjectile2._positions != null)
			{
				int frameCounter = _frameCounter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				bool flag = (nint)frameCounter >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
				if ((nint)0 != 0)
				{
					TP_Fire2_Projectile headProjectile3 = _headProjectile;
					List<Quaternion> rotations = headProjectile3._rotations;
					if (headProjectile3._rotations != null)
					{
						int frameCounter2 = _frameCounter;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdx_v14 (System.Collections.Generic.List`1<UnityEngine.Quaternion>)+18]");
						bool flag2 = (nint)frameCounter2 >= (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdx_v14 (System.Collections.Generic.List`1<UnityEngine.Quaternion>)+10]");
						if ((nint)0 != 0)
						{
							bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector3 vector = default(Vector3);
							Quaternion rotation = default(Quaternion);
							Transform.SetPositionAndRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref vector, ref rotation);
							int frameCounter3 = _frameCounter + 1;
							_frameCounter = frameCounter3;
							return;
						}
					}
				}
			}
		}
		goto IL_03a4;
	}

	public void StartDespawn()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		//IL_00dd: Expected I, but got O
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_animatedSprite != null)
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
		tweenConfig.targets = array;
		tweenConfig.duration = 250f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Fire2Tail_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	public override void Despawn()
	{
		_isCullable = true;
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	public void SetHead(TP_Fire2_Projectile head)
	{
		_headProjectile = head;
	}

	public void SetDepth(int depth)
	{
		PhaserSprite phaserSprite = _animatedSprite.setDepth(depth);
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

	private float _003CInitProjectile_003Eb__11_0()
	{
		BaseBody baseBody = body;
		return baseBody._radius;
	}

	private void _003CInitProjectile_003Eb__11_1(float r)
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		BaseBody baseBody = body.setCircle(r, (float?)(object)1, (float?)(object)1);
	}

	private void _003CInternalUpdate_003Eb__12_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
