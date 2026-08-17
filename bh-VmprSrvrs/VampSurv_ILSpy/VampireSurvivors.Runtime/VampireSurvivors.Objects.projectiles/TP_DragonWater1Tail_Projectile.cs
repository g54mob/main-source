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
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_DragonWater1Tail_Projectile : Projectile
{
	private float _radius = 16f;

	private TP_DragonWater1Head_Projectile _headProjectile;

	private int _frameCounter;

	private bool _lateInit;

	private PhaserSprite _animatedSprite;

	private const int AnimFPS = 30;

	private Tween _radiusTween;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

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
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_WaterDragon01");
		GameObject gameObject2 = phaserSprite.gameObject;
		((UnityEngine.Object)gameObject2).SetName("TP_DragonWater1Tail_Sprite");
		_animatedSprite = phaserSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_WaterDragon", 1, 6, vector, text, num, flag);
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
		((TP_DragonWater1Tail_Projectile)(object)dOSetter)._003CInitProjectile_003Eb__10_1(1f);
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
		//IL_01af: Invalid comparison between F4 and I4
		//IL_00e1: Expected I, but got O
		//IL_017c: Expected O, but got I4
		//IL_026e->IL030a: Incompatible stack heights: 1 vs 0
		//IL_02a9->IL030a: Incompatible stack heights: 1 vs 0
		//IL_02f4->IL030a: Incompatible stack heights: 2 vs 0
		//IL_039b->IL0347: Incompatible stack heights: 3 vs 0
		if (_lateInit)
		{
			goto IL_019d;
		}
		TP_DragonWater1Head_Projectile headProjectile = _headProjectile;
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
						goto IL_019d;
					}
				}
			}
		}
		goto IL_030a;
		IL_019d:
		float deltaTime = PauseSystem.DeltaTime;
		if (!(deltaTime > 0f))
		{
			return;
		}
		Transform transform = base.transform;
		TP_DragonWater1Head_Projectile headProjectile2 = _headProjectile;
		if ((object)_headProjectile != null)
		{
			List<Vector3> positions = headProjectile2._positions;
			if (headProjectile2._positions != null)
			{
				int frameCounter = _frameCounter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				bool flag = (nint)frameCounter >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
				if ((nint)0 != 0)
				{
					TP_DragonWater1Head_Projectile headProjectile3 = _headProjectile;
					List<Quaternion> rotations = headProjectile3._rotations;
					if (headProjectile3._rotations != null)
					{
						int frameCounter2 = _frameCounter;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v14 (System.Collections.Generic.List`1<UnityEngine.Quaternion>)+18]");
						bool flag2 = (nint)frameCounter2 >= (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v14 (System.Collections.Generic.List`1<UnityEngine.Quaternion>)+10]");
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
		goto IL_030a;
		IL_030a:
		throw new NullReferenceException();
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_DragonWater1Tail_Projectile>)+370]");
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

	public void SetHead(TP_DragonWater1Head_Projectile head)
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
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
		{
			bool flag = TryFreeze(other);
		}
	}

	private float _003CInitProjectile_003Eb__10_0()
	{
		BaseBody baseBody = body;
		return baseBody._radius;
	}

	private void _003CInitProjectile_003Eb__10_1(float r)
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		BaseBody baseBody = body.setCircle(r, (float?)(object)1, (float?)(object)1);
	}
}
