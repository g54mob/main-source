using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Spite1_Projectile_Bak : Projectile
{
	private TrailRenderer _LightTrail;

	private TrailRenderer _DarkTrail;

	private Transform _Light;

	private Transform _Dark;

	private Vector2 _initialVel;

	private float _startingAngle;

	private float _bodyRadius = 24f;

	protected float[] _firingAngles = new float[8] { 0f, 0f, 5f, 5f, 10f, 10f, 15f, 15f };

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _fadeInTrailTween;

	protected float _trailAlpha = 1.2f;

	private bool _mirrored;

	private bool _flip;

	private Sequence _windSequence;

	private float _waveAngle;

	private float _waveIncrement = 0.003f;

	protected override void Awake()
	{
		base.Awake();
		SetupTrail();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 12 Invalid \"Jump target not found in method: 0x1871800A0\"");
	}

	public unsafe void SetFlip(bool __flip)
	{
		//IL_0024: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_005d: Expected O, but got I4
		//IL_0096: Expected I4, but got I8
		//IL_05ea: Expected O, but got I4
		//IL_00f6: Expected O, but got Ref
		//IL_00c6: Expected O, but got I4
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected I4, but got Unknown
		//IL_0146: Expected O, but got I4
		//IL_01e3: Expected I, but got O
		//IL_0247: Expected O, but got I4
		//IL_0486: Expected I, but got O
		//IL_04f0: Expected I, but got O
		//IL_0554: Expected O, but got I4
		//IL_05d7: Expected I4, but got F4
		float num = _weapon.PArea();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(_bodyRadius, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setScale(0.1f, (float?)(object)0);
		_speed = 2f;
		_isCullable = false;
		_waveAngle = 0f;
		int num2 = (int)(_indexInWeapon & 0x80000001L);
		if ((nint)body < 0)
		{
			object obj = num2 - 1;
			object obj2 = obj | -2;
			num2 = obj2 + 1;
		}
		object obj3 = num2 - 1;
		bool mirrored = obj3 == null;
		_flip = __flip;
		_mirrored = mirrored;
		object obj4 = default(object);
		ApplyPlayerFacingVelocity((Vector3)(&obj4));
		BaseBody baseBody2 = body;
		_initialVel = baseBody2._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v25 (BaseBody)+74]");
		_ = 0;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num3 = (soundConfig.Detune = (float)_indexInWeapon * -100f);
		float num4 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, num4);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num5 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj5 = default(object);
		if (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			object obj6 = default(object);
			float startWidth = (float)obj6 * 0.14f;
			_LightTrail.startWidth = startWidth;
			_LightTrail.endWidth = 0f;
			float num6 = (float)obj6 * 0.2f;
			if (num6 > 1f)
			{
				num6 = 1f;
			}
			_LightTrail.time = num6;
			Material material = ((Renderer)_LightTrail).GetMaterial();
			RenderingExtensions.SetAlpha(material, 0f);
			_LightTrail.emitting = true;
			_LightTrail.time = 0.65f;
			float startWidth2 = (float)obj6 * 0.14f;
			_DarkTrail.startWidth = startWidth2;
			_DarkTrail.endWidth = 0f;
			float num7 = (float)obj6 * 0.2f;
			bool flag = num7 > 1f;
			float time = 1f;
			if (!flag)
			{
				time = num7;
			}
			_DarkTrail.time = time;
			Material material2 = ((Renderer)_DarkTrail).GetMaterial();
			RenderingExtensions.SetAlpha(material2, 0f);
			_DarkTrail.emitting = true;
			if (_fadeInTrailTween != null)
			{
				_fadeInTrailTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[2];
			Material material3 = ((Renderer)_LightTrail).GetMaterial();
			if ((object)material3 != null)
			{
				nint num8 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj7 = default(object);
				if (obj7 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Material material4 = ((Renderer)_DarkTrail).GetMaterial();
			if ((object)material4 != null)
			{
				nint num9 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj8 = default(object);
				if (obj8 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 200f;
			tweenConfig2.alpha = (float?)(object)1;
			MultiTargetTween fadeInTrailTween = Tweens.Add(tweenConfig2);
			_fadeInTrailTween = fadeInTrailTween;
			float num10 = _weapon.PDuration();
			Action onComplete = StartDespawn;
			float duration = num3 * 0.001f;
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num4 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			return;
		}
		ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
		throw ex3;
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile_Bak>)+370]");
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
		//IL_00ed->IL0092: Incompatible stack heights: 1 vs 0
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * _waveIncrement;
		float num2 = num * 3000f;
		float waveAngle = num2 + _waveAngle;
		_waveAngle = waveAngle;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Transform light = _Light;
		if ((object)_Light != null)
		{
			bool flag = ((UnityEngine.Object)light).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)light).m_CachedPtr, ref value);
			Transform dark = _Dark;
			if ((object)_Dark != null)
			{
				bool flag2 = ((UnityEngine.Object)dark).m_CachedPtr == (IntPtr)0;
				Vector3 value2 = default(Vector3);
				Transform.set_localPosition_Injected(((UnityEngine.Object)dark).m_CachedPtr, ref value2);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		//IL_01a7->IL015a: Incompatible stack heights: 1 vs 0
		//IL_00ca->IL015a: Incompatible stack heights: 1 vs 0
		//IL_01f2->IL015a: Incompatible stack heights: 2 vs 0
		Tween windSequence = _windSequence;
		if (_windSequence != null && windSequence._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_windSequence);
		}
		TrailRenderer lightTrail = _LightTrail;
		if ((object)_LightTrail != null)
		{
			bool flag = ((UnityEngine.Object)lightTrail).m_CachedPtr == (IntPtr)0;
			TrailRenderer.Clear_Injected(((UnityEngine.Object)lightTrail).m_CachedPtr);
			if ((object)_LightTrail != null)
			{
				_LightTrail.emitting = false;
				TrailRenderer darkTrail = _DarkTrail;
				if ((object)_DarkTrail != null)
				{
					bool flag2 = ((UnityEngine.Object)darkTrail).m_CachedPtr == (IntPtr)0;
					TrailRenderer.Clear_Injected(((UnityEngine.Object)darkTrail).m_CachedPtr);
					if ((object)_DarkTrail != null)
					{
						_DarkTrail.emitting = false;
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
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SetupTrail()
	{
		//IL_020a->IL01a9: Incompatible stack heights: 1 vs 0
		//IL_0116->IL01a9: Incompatible stack heights: 2 vs 0
		//IL_0145->IL01a9: Incompatible stack heights: 2 vs 0
		//IL_0190->IL01a9: Incompatible stack heights: 2 vs 0
		//IL_02c1->IL01a9: Incompatible stack heights: 3 vs 0
		Sprite sprite = SpriteManager.GetSprite("Ribbon2", "vfx");
		RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_LightTrail, sprite, false);
		if ((object)_LightTrail != null)
		{
			_LightTrail.emitting = false;
			if ((object)_LightTrail != null)
			{
				Material material = ((Renderer)_LightTrail).GetMaterial();
				RenderingExtensions.SetAlpha(material, 0f);
				Sprite lightTrail = (Sprite)(object)_LightTrail;
				if ((object)_LightTrail != null)
				{
					bool flag = ((UnityEngine.Object)lightTrail).m_CachedPtr == (IntPtr)0;
					TrailRenderer.Clear_Injected(((UnityEngine.Object)lightTrail).m_CachedPtr);
					Sprite lightTrail2 = (Sprite)(object)_LightTrail;
					if ((object)_LightTrail != null)
					{
						bool flag2 = ((UnityEngine.Object)lightTrail2).m_CachedPtr == (IntPtr)0;
						Renderer.set_sortingOrder_Injected(((UnityEngine.Object)lightTrail2).m_CachedPtr, 31767);
						TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_LightTrail);
						RenderingExtensions.SetMaterialToPackedSpriteInternal(sprite: SpriteManager.GetSprite("Ribbon3", "vfx"), trailRenderer: (Renderer)_DarkTrail, additive: false);
						if ((object)_DarkTrail != null)
						{
							_DarkTrail.emitting = false;
							if ((object)_DarkTrail != null)
							{
								Material material2 = ((Renderer)_DarkTrail).GetMaterial();
								RenderingExtensions.SetAlpha(material2, 0f);
								Sprite darkTrail = (Sprite)(object)_DarkTrail;
								if ((object)_DarkTrail != null)
								{
									bool flag3 = ((UnityEngine.Object)darkTrail).m_CachedPtr == (IntPtr)0;
									TrailRenderer.Clear_Injected(((UnityEngine.Object)darkTrail).m_CachedPtr);
									Sprite darkTrail2 = (Sprite)(object)_DarkTrail;
									if ((object)_DarkTrail != null)
									{
										bool flag4 = ((UnityEngine.Object)darkTrail2).m_CachedPtr == (IntPtr)0;
										Renderer.set_sortingOrder_Injected(((UnityEngine.Object)darkTrail2).m_CachedPtr, 31767);
										TrailRendererPauseController trailRendererPauseController2 = RenderingExtensions.AddPauseController(_DarkTrail);
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
}
