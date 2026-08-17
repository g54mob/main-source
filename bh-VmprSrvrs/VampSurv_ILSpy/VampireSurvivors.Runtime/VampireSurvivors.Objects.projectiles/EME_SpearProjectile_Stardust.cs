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
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_SpearProjectile_Stardust : Projectile
{
	protected SpriteRenderer _SpearSprite;

	private TrailRenderer _LineTrail;

	private TrailRenderer _vfxTrail;

	private const float Radius = 90f;

	private const float ScaleMultiplier = 0.15f;

	private string _spearSpriteName;

	private float _area;

	private MultiTargetTween _fadeTween;

	private Timer _expireTimer;

	private PhaserSprite _portalSprite;

	private MultiTargetTween _portalTween;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0062: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_009e: Expected O, but got Ref
		//IL_01ed: Expected O, but got I4
		//IL_0191: Expected I4, but got F4
		base.InitProjectile(pool, weapon, index);
		SetupSpearSprite();
		GenerateParticleSystem();
		_speed = 4f;
		_isCullable = false;
		float num = _weapon.PArea();
		object obj = default(object);
		ArcadeSprite arcadeSprite = setScale(_area = (float)obj * 0.15f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(90f, (float?)(object)1, (float?)(object)1);
		object obj2 = default(object);
		ApplyPlayerFacingVelocity((Vector3)(&obj2));
		DoSpearFadeIn();
		DoPortalVfx();
		SetupTrail();
		if ((object)_vfxTrail != null)
		{
			_vfxTrail.Clear();
		}
		_vfxTrail.emitting = true;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * 10f;
		soundConfig.Detune = detune;
		float num2 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_stardust, soundConfig, 200f, 2, num2);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Action onComplete = StartDespawn;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(0.75000006f, onComplete, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	public override void InternalUpdate()
	{
		//IL_0152->IL00cd: Incompatible stack heights: 1 vs 0
		//IL_00cd->IL0107: Incompatible stack heights: 1 vs 0
		ParticleSystem pfx = _pfx;
		if ((object)_pfx == null || ((UnityEngine.Object)pfx).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		BaseBody baseBody = body;
		if (body != null)
		{
			if (!baseBody._enable)
			{
				return;
			}
			EME_SpearProjectile_Stardust cachedTransform = (EME_SpearProjectile_Stardust)(object)_cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
				if ((object)_pfxManager != null)
				{
					Vector2 pos = default(Vector2);
					_pfxManager.EmitParticleAt(pos);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void UpdateParticles()
	{
		//IL_0152->IL00cd: Incompatible stack heights: 1 vs 0
		//IL_00cd->IL0107: Incompatible stack heights: 1 vs 0
		ParticleSystem pfx = _pfx;
		if ((object)_pfx == null || ((UnityEngine.Object)pfx).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		BaseBody baseBody = body;
		if (body != null)
		{
			if (!baseBody._enable)
			{
				return;
			}
			EME_SpearProjectile_Stardust cachedTransform = (EME_SpearProjectile_Stardust)(object)_cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
				if ((object)_pfxManager != null)
				{
					Vector2 pos = default(Vector2);
					_pfxManager.EmitParticleAt(pos);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SetupTrail()
	{
		TrailRenderer lineTrail = _LineTrail;
		if ((object)_LineTrail != null && ((UnityEngine.Object)lineTrail).m_CachedPtr != (IntPtr)0)
		{
			float saturationMax = default(float);
			float valueMin = default(float);
			float valueMax = default(float);
			float alphaMin = default(float);
			Color color = UnityEngine.Random.ColorHSV(0.5f, 1f, 1f, saturationMax, valueMin, valueMax, alphaMin, 1f);
			Color color2 = UnityEngine.Random.ColorHSV(0.5f, 1f, 1f, saturationMax, valueMin, valueMax, alphaMin, 1f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
			float num = _area * 0.3f;
			_LineTrail.time = 0.5f;
			_LineTrail.startWidth = num;
			float endWidth = num * 0.5f;
			_LineTrail.endWidth = endWidth;
			Sprite sprite = default(Sprite);
			RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_LineTrail, sprite, true);
			Material material = ((Renderer)_LineTrail).GetMaterial();
			RenderingExtensions.SetAlpha(material, 1f);
			_LineTrail.Clear();
			_LineTrail.emitting = true;
			Gradient gradient = new Gradient();
			IntPtr ptr = Gradient.Init();
			gradient.m_Ptr = ptr;
			gradient.m_RequiresNativeCleanup = true;
			GradientColorKey[] colorKeys = new GradientColorKey[2];
			_ = color.r;
			_ = 0;
			_ = color2.r;
			_ = 1f;
			GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
			_ = 1061997773;
			_ = 0;
			_ = 1065353216;
			gradient.SetKeys(colorKeys, alphaKeys);
			_LineTrail.colorGradient = gradient;
			TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_LineTrail);
		}
	}

	private void SetupSpearSprite()
	{
		SpriteRenderer spearSprite = _SpearSprite;
		if ((object)_SpearSprite != null && ((UnityEngine.Object)spearSprite).m_CachedPtr != (IntPtr)0)
		{
			Weapon weapon = _weapon;
			string spearSpriteName = GetSpearSpriteName(((Equipment)weapon)._equipmentType);
			_spearSpriteName = spearSpriteName;
			Sprite sprite = SpriteManager.GetSprite(_spearSpriteName, "Emeralds_VFX");
			_SpearSprite.sprite = sprite;
		}
	}

	protected virtual string GetSpearSpriteName(WeaponType weapon = WeaponType.VOID)
	{
		//IL_008c: Expected O, but got I4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4A7F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = weapon - 398;
		bool flag = weapon == WeaponType.EME_SPEAR1;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (flag || (nint)obj2 != 1)
			{
				return "EME_Spear_Feather2";
			}
			return "EME_Spear_Lohengrin2";
		}
		return "EME_Spear_Glaive2";
	}

	private void DoSpearFadeIn()
	{
		//IL_00c7: Expected I, but got O
		//IL_012b: Expected O, but got I4
		SpriteRenderer spearSprite = _SpearSprite;
		if ((object)_SpearSprite == null || ((UnityEngine.Object)spearSprite).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_SpearSprite, 0f);
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_SpearSprite != null)
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
		tweenConfig.duration = 100f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween fadeTween = Tweens.Add(tweenConfig);
		_fadeTween = fadeTween;
	}

	private void DoPortalVfx()
	{
		//IL_0089: Expected O, but got I4
		//IL_0365: Expected F4, but got O
		//IL_01d6: Expected I, but got O
		//IL_0258: Expected O, but got I4
		//IL_02fb->IL027a: Incompatible stack heights: 1 vs 0
		//IL_0042->IL027a: Incompatible stack heights: 1 vs 0
		//IL_0071->IL027a: Incompatible stack heights: 1 vs 0
		//IL_00a5->IL027a: Incompatible stack heights: 1 vs 0
		//IL_00cf->IL027a: Incompatible stack heights: 1 vs 0
		//IL_0115->IL027a: Incompatible stack heights: 1 vs 0
		//IL_0144->IL027a: Incompatible stack heights: 1 vs 0
		//IL_0163->IL027a: Incompatible stack heights: 1 vs 0
		//IL_01f9->IL01f9: Incompatible stack heights: 5 vs 4
		PhaserWorld instance = PhaserWorld.Instance;
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
			if ((object)instance != null)
			{
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "Emeralds_VFX", "EME_DivineLancer");
				if ((object)phaserSprite != null)
				{
					PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite phaserSprite3 = phaserSprite2.setScale(0.75f, (float?)(object)0);
						if ((object)phaserSprite3 != null)
						{
							GameObject gameObject = phaserSprite3.gameObject;
							if ((object)gameObject != null)
							{
								((UnityEngine.Object)gameObject).SetName("EME_Spear_PortalSprite");
								_portalSprite = phaserSprite3;
								Weapon weapon = _weapon;
								if ((object)_weapon != null)
								{
									VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
									if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null && (object)_portalSprite != null)
									{
										Transform transform = _portalSprite.transform;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
										Quaternion.AngleAxis_Injected((float)_portalSprite, ref ret, out Quaternion _);
										bool flag2 = (object)transform == null;
										bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
										Quaternion value = default(Quaternion);
										Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
										TweenConfig tweenConfig = new TweenConfig();
										object[] array = new object[1];
										bool flag4 = array == null;
										if ((object)_portalSprite != null)
										{
											nint num = (nint)array;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj = default(object);
											bool flag5 = obj == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										bool flag6 = tweenConfig == null;
										tweenConfig.targets = array;
										tweenConfig.duration = 250f;
										tweenConfig.yoyo = true;
										tweenConfig.alpha = (float?)(object)1;
										MultiTargetTween portalTween = Tweens.Add(tweenConfig);
										_portalTween = portalTween;
										return;
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

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0267: Expected O, but got Ref
		//IL_0281: Expected native int or pointer, but got O
		//IL_0484: Expected O, but got I4
		//IL_0299: Expected O, but got Ref
		//IL_02c0: Expected O, but got I
		//IL_02d5: Expected native int or pointer, but got O
		//IL_02ef: Expected O, but got I
		//IL_030f: Expected O, but got Ref
		//IL_0329: Expected native int or pointer, but got O
		//IL_04a1: Expected O, but got I4
		//IL_034e: Expected O, but got Ref
		//IL_0368: Expected native int or pointer, but got O
		//IL_04d3: Expected O, but got I
		//IL_0527->IL0475: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem pfx = _pfx;
		if ((object)_pfx != null && ((UnityEngine.Object)pfx).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			ParticleEmitterManager pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
			_pfxManager = pfxManager;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			if (list != null)
			{
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				if (list._items != null)
				{
					if (list._size >= items.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"blurredSharpStar.png");
					}
					else
					{
						int num = list._size + 1;
						list._size = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					if (particleSystemConfig != null)
					{
						particleSystemConfig._frame = list;
						uint[] array = new uint[5];
						if (array != null)
						{
							array[0] = 16776960u;
							array[1] = 16711935u;
							array[2] = 65535u;
							array[3] = 16776960u;
							array[4] = 16776960u;
							particleSystemConfig._tintRandom = array;
							ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 72));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(20f, 40f));
							particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
							ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
							_ = 0;
							_ = 100;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
							particleSystemConfig._quantity = (int?)(object)0;
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1000f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
							particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0.7f, 0f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
							_ = 0;
							particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0.2f, 0.4f));
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
							particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
							_ = 0;
							particleSystemConfig._scaleEase = Easing.InCubic;
							particleSystemConfig._on = false;
							Transform parent = base.transform;
							if ((object)_pfxManager != null)
							{
								ParticleSystem pfx2 = _pfxManager.CreateEmitter(particleSystemConfig, parent);
								_pfx = pfx2;
								if ((object)_pfx != null)
								{
									Transform transform = _pfx.transform;
									bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Vector3 value = default(Vector3);
									Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
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

	private void PlaySfx()
	{
		//IL_004b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * 10f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_stardust, soundConfig, 200f, 2, time);
	}

	public void PlaySfxLong()
	{
		//IL_0039: Expected O, but got I4
		SoundManager.StopSound(SfxType.Sfx_eme_stardust);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -5f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_stardust_long, soundConfig, 50f, 1, time);
	}

	private void StartDespawn()
	{
		//IL_008b: Expected I, but got O
		//IL_00ef: Expected O, but got I4
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_SpearSprite != null)
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
		TweenCallback onComplete = WaitBeforeDespawn;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween fadeTween = Tweens.Add(tweenConfig);
		_fadeTween = fadeTween;
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
	}

	private void WaitBeforeDespawn()
	{
		//IL_0030: Expected I, but got O
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_SpearProjectile_Stardust>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(0.75000006f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	public override void Despawn()
	{
		if ((object)_vfxTrail != null)
		{
			_vfxTrail.Clear();
		}
		_vfxTrail.emitting = false;
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_portalTween != null)
		{
			_portalTween.Kill();
		}
		GameObject gameObject = _portalSprite.gameObject;
		gameObject.SetActive(value: false);
		base.Despawn();
	}
}
