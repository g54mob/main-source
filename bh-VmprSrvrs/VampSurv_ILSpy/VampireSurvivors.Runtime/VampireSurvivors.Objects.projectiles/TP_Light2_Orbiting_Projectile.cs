using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Light2_Orbiting_Projectile : Projectile
{
	protected TrailRenderer _LightTrail;

	private float _orbitRadius;

	private float _bodyRadius = 16f;

	private MultiTargetTween _scaleTween;

	protected MultiTargetTween _fadeInTrailTween;

	private bool _isLight;

	private float _waveAngle1;

	private float _waveAngle2;

	protected Sprite _cachedLightSprite;

	protected PhaserSprite _animatedSprite;

	protected PhaserSprite _glowSprite;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		MakeTrailAndSprites();
	}

	public virtual void MakeTrailAndSprites()
	{
		//IL_01f1: Expected O, but got I4
		//IL_01f1: Expected I4, but got O
		//IL_02b6: Expected O, but got I4
		//IL_0330->IL02bb: Incompatible stack heights: 1 vs 0
		//IL_019e->IL02bb: Incompatible stack heights: 2 vs 0
		//IL_01c0->IL02bb: Incompatible stack heights: 2 vs 0
		//IL_0215->IL02bb: Incompatible stack heights: 2 vs 0
		//IL_0237->IL02bb: Incompatible stack heights: 2 vs 0
		//IL_0269->IL02bb: Incompatible stack heights: 2 vs 0
		//IL_029c->IL02bb: Incompatible stack heights: 2 vs 0
		Sprite sprite = SpriteManager.GetSprite("Ribbon3", "vfx");
		_cachedLightSprite = sprite;
		RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_LightTrail, _cachedLightSprite, false);
		if ((object)_LightTrail != null)
		{
			_LightTrail.emitting = false;
			if ((object)_LightTrail != null)
			{
				Material material = ((Renderer)_LightTrail).GetMaterial();
				RenderingExtensions.SetAlpha(material, 0f);
				if ((object)_LightTrail != null)
				{
					_LightTrail.time = 0.1f;
					Renderer lightTrail = _LightTrail;
					if ((object)_LightTrail != null)
					{
						bool flag = ((UnityEngine.Object)lightTrail).m_CachedPtr == (IntPtr)0;
						Renderer.set_sortingOrder_Injected(((UnityEngine.Object)lightTrail).m_CachedPtr, 999);
						TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_LightTrail);
						Renderer lightTrail2 = _LightTrail;
						if ((object)_LightTrail != null)
						{
							bool flag2 = ((UnityEngine.Object)lightTrail2).m_CachedPtr == (IntPtr)0;
							TrailRenderer.Clear_Injected(((UnityEngine.Object)lightTrail2).m_CachedPtr);
							GameObject gameObject = base.gameObject;
							Vector2 vector = default(Vector2);
							PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Lumos01");
							_animatedSprite = animatedSprite;
							string text = default(string);
							int num = default(int);
							bool flag3 = default(bool);
							List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Lumos", 1, 12, vector, text, num, flag3);
							PhaserSprite animatedSprite2 = _animatedSprite;
							if ((object)_animatedSprite != null && (object)animatedSprite2._spriteAnimation != null)
							{
								bool autoSetAnimation = default(bool);
								animatedSprite2._spriteAnimation.AddAnimation("loop", animationFrames, 30, (byte)(int)text != 0, (byte)num != 0, (Action)flag3, autoSetAnimation);
								PhaserSprite animatedSprite3 = _animatedSprite;
								if ((object)_animatedSprite != null && (object)animatedSprite3._spriteAnimation != null)
								{
									animatedSprite3._spriteAnimation.SetAnimation("loop");
									if ((object)_animatedSprite != null)
									{
										PhaserSprite phaserSprite = _animatedSprite.setAlpha(0.65f);
										if ((object)_animatedSprite != null)
										{
											PhaserSprite phaserSprite2 = _animatedSprite.setScale(0.5f, (float?)(object)0);
											return;
										}
									}
								}
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
		//IL_0065: Expected O, but got I4
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_00a2: Expected O, but got I4
		//IL_00a2: Expected O, but got I4
		//IL_00b6: Expected O, but got I4
		//IL_0395: Expected O, but got F4
		//IL_03cc: Expected O, but got F4
		//IL_00d2: Expected I, but got O
		//IL_00e8: Invalid comparison between I4 and F4
		//IL_0151: Expected I, but got O
		//IL_0159: Expected I, but got O
		//IL_0169: Expected O, but got I
		//IL_01a5: Expected O, but got I
		//IL_01e2: Expected O, but got I
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_0220: Expected O, but got I4
		//IL_02e2: Expected I, but got O
		//IL_0342: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		float2 float5 = default(float2);
		PhaserSprite phaserSprite = _animatedSprite.setLocalPosition(float5);
		PhaserSprite phaserSprite2 = _animatedSprite.setVisible(visible: true);
		float num = _weapon.PArea();
		float multiplier = (float)float5 * 0.25f;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		float bodyRadius = _bodyRadius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj = bodyRadius ^ 0;
		BaseBody baseBody = body.setCircle(_bodyRadius, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setScale(0.1f, (float?)(object)0);
		_isCullable = false;
		object obj2 = UnityEngine.Random.value;
		float num2 = (float)obj * (float)Math.PI;
		float num3 = (_waveAngle1 = num2 + num2);
		object obj3 = UnityEngine.Random.value;
		float num4 = num3 * (float)Math.PI;
		Weapon weapon2 = _weapon;
		float num5 = (_waveAngle2 = num4 + num4);
		nint num6 = (nint)weapon2;
		float num7 = weapon2.PArea();
		if (!(0f > num5))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		float orbitRadius = num5 * 0.12f;
		Weapon weapon3 = _weapon;
		_orbitRadius = orbitRadius;
		nint num8 = (nint)typeof(TP_Light1_Weapon);
		nint num9 = (nint)weapon3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Light1_Weapon>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Light1_Weapon>)+130]");
		if (num10 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v34+FFFFFFF8+v168 @ rax_v33*8]");
			if (0 == (nint)typeof(TP_Light1_Weapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Light1_Weapon>)+130]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v34+FFFFFFF8+v590 @ rcx_v23*8]");
				object obj7 = 0 - typeof(TP_Light1_Weapon);
				bool flag = obj7 == null;
				bool flag2 = !flag;
				float? num11 = (float?)(object)0;
				if (!flag2)
				{
					num11 = (float?)weapon3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdx_v19 (System.Nullable`1<System.Single>)+16C]");
				float alpha = 0f * 0.5f;
				PhaserSprite phaserSprite3 = _animatedSprite.setAlpha(alpha);
				int num12 = ~_indexInWeapon;
				int isLight = num12 & 1;
				_isLight = (byte)isLight != 0;
				if (_scaleTween != null)
				{
					_scaleTween.Kill();
				}
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				nint num13 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj8 = default(object);
				bool flag3 = obj8 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig.targets = array;
				tweenConfig.duration = 200f;
				tweenConfig.scale = (float?)(object)1;
				MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
				_scaleTween = scaleTween;
				InitLightTrail(multiplier);
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected virtual void InitLightTrail(float multiplier)
	{
		//IL_0160: Expected I, but got O
		//IL_01c4: Expected O, but got I4
		float startWidth = multiplier * 0.14f;
		_LightTrail.startWidth = startWidth;
		float endWidth = multiplier * 0.07f;
		_LightTrail.endWidth = endWidth;
		float num = multiplier * 0.2f;
		bool flag = num > 0.2f;
		float time = 0.2f;
		if (!flag)
		{
			time = num;
		}
		_LightTrail.time = time;
		Material material = ((Renderer)_LightTrail).GetMaterial();
		RenderingExtensions.SetAlpha(material, 0f);
		_LightTrail.emitting = true;
		if (_fadeInTrailTween != null)
		{
			_fadeInTrailTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Material material2 = ((Renderer)_LightTrail).GetMaterial();
		if ((object)material2 != null)
		{
			nint num2 = (nint)array;
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
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween fadeInTrailTween = Tweens.Add(tweenConfig);
		_fadeInTrailTween = fadeInTrailTween;
	}

	private void StartDespawn()
	{
		//IL_003f: Expected I, but got O
		//IL_00a3: Expected O, but got I4
		//IL_00be: Expected I, but got O
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Light2_Orbiting_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void InternalUpdate()
	{
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 10f;
		float waveAngle = num + _waveAngle1;
		_waveAngle1 = waveAngle;
		float deltaTime2 = PauseSystem.DeltaTime;
		float num2 = deltaTime2 * 10.5f;
		float waveAngle2 = num2 + _waveAngle2;
		_waveAngle2 = waveAngle2;
		if (!_isLight)
		{
		}
		Transform transform = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public override void Despawn()
	{
		TrailRenderer lightTrail = _LightTrail;
		bool flag = ((UnityEngine.Object)lightTrail).m_CachedPtr == (IntPtr)0;
		TrailRenderer.Clear_Injected(((UnityEngine.Object)lightTrail).m_CachedPtr);
		_LightTrail.emitting = false;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_fadeInTrailTween != null)
		{
			_fadeInTrailTween.Kill();
		}
		base.Despawn();
	}
}
