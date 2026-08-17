using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Spite1_Projectile : Projectile
{
	private TrailRenderer _LightTrail;

	private float _bodyRadius = 16f;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _fadeInTrailTween;

	private bool _isLight;

	private float _waveAngle;

	private float _waveIncrement = 0.003f;

	private Sprite _cachedLightSprite;

	private Sprite _cachedDarkSprite;

	private float _pathModifier = 1f;

	private bool _isUpwards;

	protected override void Awake()
	{
		//IL_0244->IL01c9: Incompatible stack heights: 1 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				Sprite sprite2 = SpriteManager.GetSprite("Ribbon2", "vfx");
				_cachedLightSprite = sprite2;
				Sprite sprite3 = SpriteManager.GetSprite("Ribbon3", "vfx");
				_cachedDarkSprite = sprite3;
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
							_LightTrail.time = 0.2f;
							SpriteRenderer lightTrail = (SpriteRenderer)(object)_LightTrail;
							if ((object)_LightTrail != null)
							{
								bool flag = ((UnityEngine.Object)lightTrail).m_CachedPtr == (IntPtr)0;
								Renderer.set_sortingOrder_Injected(((UnityEngine.Object)lightTrail).m_CachedPtr, 999);
								TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_LightTrail);
								TP_Spite1_Projectile lightTrail2 = (TP_Spite1_Projectile)(object)_LightTrail;
								if ((object)_LightTrail != null)
								{
									bool flag2 = ((UnityEngine.Object)lightTrail2).m_CachedPtr == (IntPtr)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 328 ConditionalJump @-1, v519 @ ZF_v22 (System.Boolean) --- -1 Nop");
									Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 401 ConditionalJump @-1, v443 @ ZF_v27 (System.Boolean) --- -1 Nop");
									/*Error: End of method reached without returning.*/;
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
		//IL_0024: Expected O, but got I4
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0060: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_00c5: Expected I4, but got I8
		//IL_0138: Expected I4, but got I8
		//IL_00f5: Expected O, but got I4
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected I4, but got Unknown
		//IL_058a: Expected O, but got I4
		//IL_0166: Expected O, but got I4
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected I4, but got Unknown
		//IL_01c1: Expected I, but got O
		//IL_0225: Expected O, but got I4
		//IL_03e8: Expected I, but got O
		//IL_044c: Expected O, but got I4
		//IL_04d7: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		float num = _weapon.PArea();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		float bodyRadius = _bodyRadius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj = bodyRadius ^ 0;
		BaseBody baseBody = body.setCircle(_bodyRadius, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setScale(0.1f, (float?)(object)0);
		int num2 = ~_indexInWeapon;
		_isCullable = false;
		int isLight = num2 & 1;
		_waveAngle = 0f;
		_isLight = (byte)isLight != 0;
		int num3 = (int)(_indexInWeapon & 0x80000003L);
		if ((nint)body < 0)
		{
			object obj2 = num3 - 1;
			object obj3 = obj2 | -4;
			num3 = obj3 + 1;
		}
		bool isUpwards;
		if (num3 == 0)
		{
			isUpwards = true;
		}
		else
		{
			int num4 = (int)(_indexInWeapon & 0x80000003L);
			if (num3 < 0)
			{
				object obj4 = num4 - 1;
				object obj5 = obj4 | -4;
				num4 = obj5 + 1;
			}
			object obj6 = num4 - 3;
			bool flag = obj6 == null;
			isUpwards = flag;
		}
		_isUpwards = isUpwards;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num5 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj7 = default(object);
		if (obj7 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			RenderingExtensions.SetMaterialToPackedSpriteInternal(sprite: (!_isLight) ? _cachedDarkSprite : _cachedLightSprite, trailRenderer: (Renderer)_LightTrail, additive: false);
			object obj8 = default(object);
			float startWidth = (float)obj8 * 0.14f;
			_LightTrail.startWidth = startWidth;
			_LightTrail.endWidth = 0f;
			float num6 = (float)obj8 * 0.2f;
			bool flag2 = num6 > 0.2f;
			float time = 0.2f;
			if (!flag2)
			{
				time = num6;
			}
			_LightTrail.time = time;
			Material material = ((Renderer)_LightTrail).GetMaterial();
			RenderingExtensions.SetAlpha(material, 0f);
			_LightTrail.emitting = true;
			if (_fadeInTrailTween != null)
			{
				_fadeInTrailTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			Material material2 = ((Renderer)_LightTrail).GetMaterial();
			if ((object)material2 != null)
			{
				nint num7 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj9 = default(object);
				if (obj9 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 200f;
			tweenConfig2.alpha = (float?)(object)1;
			MultiTargetTween fadeInTrailTween = Tweens.Add(tweenConfig2);
			_fadeInTrailTween = fadeInTrailTween;
			float num8 = (float)_indexInWeapon * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
			float pathModifier = num8 + 1f;
			_pathModifier = pathModifier;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 0.8f;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)_indexInWeapon * -50f;
			soundConfig.Detune = detune;
			float time2 = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_MagicShot, soundConfig, 200f, 10, time2);
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+370]");
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
		float num = deltaTime * _waveIncrement;
		float num2 = num * 3000f;
		float num3 = num2 * _pathModifier;
		float num4 = num3 * 0.5f;
		float waveAngle = num4 + _waveAngle;
		_waveAngle = waveAngle;
		Transform transform = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		if (!_isLight)
		{
		}
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
		_scaleTween = null;
		if (_fadeInTrailTween != null)
		{
			_fadeInTrailTween.Kill();
		}
		base.Despawn();
	}
}
