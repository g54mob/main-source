using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects;

public class DamageZoneFlexible : PoolablePhaserSprite
{
	public enum ZoneAlignment
	{
		Center,
		Left,
		Right,
		Top,
		Bottom
	}

	private Transform _cachedTransform;

	private Timer _hitboxTimer;

	private Timer _despawnTimer;

	private Timer _particleDespawnTimer;

	private MultiTargetTween _activateDamageZoneTween;

	private MultiTargetTween _enableDamageTween;

	private MultiTargetTween _warningTween;

	private float _damage;

	private float _activatonDelay;

	private float _durationMillis;

	private float _hitDelayMillis;

	private bool _haveWarningMark;

	private float _warningTimeMillis;

	private PhaserSprite _exclamationMark;

	protected bool _isCircle;

	protected Circle _circleCollider;

	protected bool _activateDamage;

	protected bool _hasHit;

	private bool _follow;

	private float _followSpeed;

	private bool _lockX;

	private bool _lockY;

	private Transform _targetTransform;

	private bool _visibleWarningZone;

	protected PhaserSprite _groundFx;

	private float2 _offsetPosition;

	private PhaserSprite _damageSprite;

	private bool _usingParticles;

	private ParticleEmitterManager _particlesManager;

	private ZoneAlignment _zoneAlignment;

	private ParticleSystem _currentEmitter;

	private ParticleSystem _pfxEmitter;

	private GravityWell _well;

	protected override void Awake()
	{
		EnsureSpriteRenderer();
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
	}

	public unsafe static DamageZoneFlexible CreateZone(Camera targetCamera)
	{
		//IL_006c: Expected O, but got Ref
		//IL_006c: Expected O, but got Ref
		//IL_019f->IL0110: Incompatible stack heights: 1 vs 0
		//IL_0181->IL0110: Incompatible stack heights: 1 vs 0
		//IL_00a8->IL0110: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL0110: Incompatible stack heights: 1 vs 0
		//IL_00f4->IL0110: Incompatible stack heights: 1 vs 0
		if ((object)targetCamera != null)
		{
			Transform transform = targetCamera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if ((object)HeroVfxManager._factory != null)
				{
					ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.DamagingZonesFlexible);
					if ((object)pool != null)
					{
						object obj2 = default(object);
						GameObject obj = pool.GetObject((Vector3)(&obj2), (Quaternion)(&ret));
						Transform objectComponent = (Transform)(object)pool.GetObjectComponent<DamageZoneFlexible>(obj);
						GameManager core = GM.Core;
						if ((object)GM.Core != null && (object)objectComponent != null)
						{
							GameObject gameObject = objectComponent.gameObject;
							if (core._diContainer != null)
							{
								core._diContainer.InjectGameObject(gameObject);
								return (DamageZoneFlexible)(object)objectComponent;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static ParticleSystemConfig BaseConfig(Vector3 pos, List<string> frames, string textureName = "items")
	{
		//IL_0008: Expected O, but got Ref
		//IL_003f: Expected O, but got I4
		//IL_006a: Expected O, but got I4
		//IL_0091: Expected O, but got I4
		//IL_00aa: Expected O, but got Ref
		//IL_00c4: Expected native int or pointer, but got O
		//IL_00de: Expected O, but got I
		//IL_00fe: Expected O, but got Ref
		//IL_0118: Expected native int or pointer, but got O
		//IL_02cd: Expected O, but got I4
		//IL_0130: Expected O, but got Ref
		//IL_0157: Expected O, but got I
		//IL_0171: Expected native int or pointer, but got O
		//IL_02ea: Expected O, but got I4
		//IL_01af: Expected O, but got I
		//IL_031c: Expected O, but got I
		//IL_01ef: Expected O, but got I
		//IL_020a: Expected O, but got I
		//IL_0225: Expected O, but got I
		//IL_025c: Expected O, but got I
		//IL_026a: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig(textureName);
		if (particleSystemConfig != null)
		{
			particleSystemConfig._frame = frames;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(pos.x);
			particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(pos.y);
			particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(1500f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 72));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(70f, 110f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(400f, 600f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
			_ = 0;
			_ = 2;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(2f, 0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
			_ = 0;
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
			_ = 0;
			_ = 0;
			_ = 1065353216;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
			particleSystemConfig._frequency = (float?)(object)0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(0.9f);
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
			particleSystemConfig._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
			_ = 0;
			_ = 257;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
			particleSystemConfig._collideTop = (bool?)(object)0;
			_ = 257;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
			particleSystemConfig._collideBottom = (bool?)(object)0;
			_ = 257;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
			particleSystemConfig._collideLeft = (bool?)(object)0;
			particleSystemConfig._on = false;
			particleSystemConfig._circleCollision = false;
			_ = 257;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
			particleSystemConfig._collideRight = (bool?)(object)0;
			particleSystemConfig._bounds = (Rect?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A125C0]");
			_ = 0;
			return particleSystemConfig;
		}
		return (ParticleSystemConfig)(object)new NullReferenceException();
	}

	public void InitDamageZone(float damage, float durationMillis, float activationDelay, float hitDelayMillis, float2 spawnLocation)
	{
		//IL_00da->IL0077: Incompatible stack heights: 1 vs 0
		float hitDelayMillis2 = default(float);
		_hitDelayMillis = hitDelayMillis2;
		_damage = damage;
		_durationMillis = durationMillis;
		_activatonDelay = activationDelay;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			Transform cachedTransform = _cachedTransform;
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
				bool flag3 = (object)_cachedTransform == null;
				bool flag4 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Vector3 value2 = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value2);
				Transform cachedTransform2 = _cachedTransform;
				bool flag5 = (object)_cachedTransform == null;
				bool flag6 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
				Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void InitDamageZoneCircle(float radius, bool enableGroundVisuals = true)
	{
		//IL_0095: Expected O, but got Ref
		//IL_0130: Expected O, but got Ref
		_visibleWarningZone = enableGroundVisuals;
		_isCircle = true;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "UnityCircle", "UnityCircle");
		PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0.2f);
		PhaserSprite phaserSprite3 = phaserSprite2.setVisible(visible: false);
		PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Add);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		object obj = default(object);
		PhaserSprite phaserSprite5 = phaserSprite4.setTintFill(isEnabled: true, (Color?)(object)(&obj));
		GameObject gameObject = phaserSprite5.gameObject;
		((UnityEngine.Object)gameObject).SetName("GroundFx (DamagingZoneCircle)");
		_groundFx = phaserSprite5;
		PhaserSprite phaserSprite6 = setFrame("UnityCircle", "UnityCircle");
		PhaserSprite phaserSprite7 = phaserSprite6.setVisible(visible: false);
		PhaserSprite phaserSprite8 = phaserSprite7.setAlpha(0.2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		PhaserSprite phaserSprite9 = phaserSprite8.setTintFill(isEnabled: true, (Color?)(object)(&obj));
		GameObject gameObject2 = phaserSprite9.gameObject;
		((UnityEngine.Object)gameObject2).SetName("ParticleFx (DamagingZoneCircle)");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 384 Invalid \"Jump target not found in method: 0x186E09CB0\"");
		throw new NullReferenceException();
	}

	private unsafe void SetCircleDamageZone(float radius)
	{
		//IL_016d->IL00e9: Incompatible stack heights: 1 vs 0
		//IL_003d->IL00e9: Incompatible stack heights: 2 vs 0
		//IL_0241->IL00e9: Incompatible stack heights: 3 vs 0
		//IL_00a0->IL00e9: Incompatible stack heights: 3 vs 0
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			float ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)(&ret));
			object cachedTransform2 = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdi_v9 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdi_v9 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
				Circle circle = new Circle
				{
					_x = ret
				};
				float radius2 = radius * 0.01f;
				_circleCollider = circle;
				float y = default(float);
				circle._y = y;
				circle._radius = radius2;
				PhaserSprite cachedTransform3 = (PhaserSprite)(object)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag3 = ((UnityEngine.Object)cachedTransform3).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform3).m_CachedPtr, out *(Vector3*)(&ret));
					if ((object)_groundFx != null)
					{
						float2 float5 = default(float2);
						PhaserSprite phaserSprite = _groundFx.setPosition(float5);
						float num = radius + radius;
						PhaserSprite phaserSprite2 = RenderingExtensions.SetScale(_groundFx, num);
						if ((object)_groundFx != null)
						{
							PhaserSprite phaserSprite3 = _groundFx.setDepth(1994);
							Transform component = base.transform;
							float num2 = radius + radius;
							Transform transform = RenderingExtensions.SetScale(component, num2);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void InitDamageZoneRectangle(float width, float height, bool enableGroundVisuals = true)
	{
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Expected O, but got Unknown
		//IL_03d9->IL032b: Incompatible stack heights: 1 vs 0
		//IL_0042->IL032b: Incompatible stack heights: 1 vs 0
		//IL_0071->IL032b: Incompatible stack heights: 1 vs 0
		//IL_00a0->IL032b: Incompatible stack heights: 1 vs 0
		//IL_00ee->IL032b: Incompatible stack heights: 1 vs 0
		//IL_0153->IL032b: Incompatible stack heights: 1 vs 0
		//IL_017d->IL032b: Incompatible stack heights: 1 vs 0
		//IL_01cb->IL032b: Incompatible stack heights: 1 vs 0
		//IL_01fa->IL032b: Incompatible stack heights: 1 vs 0
		//IL_0248->IL032b: Incompatible stack heights: 1 vs 0
		//IL_0402->IL032b: Incompatible stack heights: 1 vs 0
		//IL_046b->IL032b: Incompatible stack heights: 2 vs 0
		//IL_02ed->IL032b: Incompatible stack heights: 2 vs 0
		_visibleWarningZone = enableGroundVisuals;
		_isCircle = false;
		PhaserWorld instance = PhaserWorld.Instance;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj2 = default(object);
			object obj = obj2 - 64;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj);
			if ((object)instance != null)
			{
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "WhiteDot");
				if ((object)phaserSprite != null)
				{
					PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite phaserSprite3 = phaserSprite2.setVisible(visible: false);
						if ((object)phaserSprite3 != null)
						{
							PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Add);
							_ = 0;
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
							_ = 0;
							if ((object)phaserSprite4 != null)
							{
								Color? tintColor = (Color?)(object)(obj2 - 64);
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-40]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
								_ = 0;
								PhaserSprite phaserSprite5 = phaserSprite4.setTintFill(isEnabled: true, tintColor);
								if ((object)phaserSprite5 != null)
								{
									GameObject gameObject = phaserSprite5.gameObject;
									if ((object)gameObject != null)
									{
										((UnityEngine.Object)gameObject).SetName("GroundFx (DamagingZoneRectangle)");
										_groundFx = phaserSprite5;
										PhaserSprite phaserSprite6 = setFrame("WhiteDot", "vfx");
										if ((object)phaserSprite6 != null)
										{
											PhaserSprite phaserSprite7 = phaserSprite6.setVisible(visible: false);
											if ((object)phaserSprite7 != null)
											{
												PhaserSprite phaserSprite8 = phaserSprite7.setAlpha(0.2f);
												_ = 0;
												_ = 0;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
												_ = 0;
												if ((object)phaserSprite8 != null)
												{
													Color? tintColor2 = (Color?)(object)(obj2 - 64);
													Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-40]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
													_ = 0;
													PhaserSprite phaserSprite9 = phaserSprite8.setTintFill(isEnabled: true, tintColor2);
													Transform cachedTransform = _cachedTransform;
													if ((object)_cachedTransform != null)
													{
														_ = 0;
														_ = 0;
														bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
														object obj3 = obj2 - 64;
														Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj3);
														if ((object)_groundFx != null)
														{
															PhaserSprite phaserSprite10 = _groundFx.setPosition(pos);
															PhaserSprite phaserSprite11 = RenderingExtensions.SetScale(_groundFx, width, height);
															if ((object)_groundFx != null)
															{
																PhaserSprite phaserSprite12 = _groundFx.setDepth(1994);
																Transform component = base.transform;
																Transform transform2 = RenderingExtensions.SetScale(component, width, height);
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
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SetRectangleDamageZone(float2 size)
	{
		//IL_003a: Expected F4, but got O
		//IL_0091: Expected F4, but got O
		//IL_0110->IL0096: Incompatible stack heights: 1 vs 0
		//IL_0058->IL0096: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			if ((object)_groundFx != null)
			{
				float2 float5 = default(float2);
				PhaserSprite phaserSprite = _groundFx.setPosition(float5);
				float yScale = default(float);
				PhaserSprite phaserSprite2 = RenderingExtensions.SetScale(_groundFx, (float)size, yScale);
				if ((object)_groundFx != null)
				{
					PhaserSprite phaserSprite3 = _groundFx.setDepth(1994);
					Transform component = base.transform;
					Transform transform = RenderingExtensions.SetScale(component, (float)size, yScale);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void InitWarningBehaviour(bool haveWarningMark, float warningTimeMillis = 600f)
	{
		_warningTimeMillis = warningTimeMillis;
		_haveWarningMark = haveWarningMark;
	}

	public void InitDamageZoneBehaviour(bool lockX, bool lockY, bool following, Transform targetTransform = null, float followSpeed = 1f)
	{
		float followSpeed2 = default(float);
		_followSpeed = followSpeed2;
		Transform targetTransform2 = default(Transform);
		_targetTransform = targetTransform2;
		_follow = following;
		_lockX = lockX;
		_lockY = lockY;
	}

	public unsafe void InitParticleVisuals(ParticleSystemConfig newConfig, ZoneAlignment newAlignment)
	{
		//IL_0081: Expected O, but got Ref
		_usingParticles = true;
		_zoneAlignment = newAlignment;
		MakeEmitterManager();
		MakeEmitters(newConfig, newConfig);
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		object obj = default(object);
		SetEmitterLocation((Vector3)(&obj));
	}

	public void InitSpriteVisuals(List<Sprite> newAnimFrames, int fps, float offsetX, float offsetY, float frameScale)
	{
		//IL_011c: Expected O, but got F4
		//IL_021c: Expected I, but got O
		//IL_018b: Expected O, but got I4
		//IL_0236->IL0190: Incompatible stack heights: 1 vs 0
		//IL_0172->IL0190: Incompatible stack heights: 1 vs 0
		_usingParticles = false;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "vfx", "WhiteDot");
				if ((object)phaserSprite != null)
				{
					PhaserSprite damageSprite = phaserSprite.setVisible(visible: false);
					_damageSprite = damageSprite;
					PhaserSprite damageSprite2 = _damageSprite;
					if ((object)_damageSprite != null && (object)damageSprite2._spriteAnimation != null)
					{
						bool shouldLoop = default(bool);
						bool startRandomFrame = default(bool);
						Action onComplete = default(Action);
						bool autoSetAnimation = default(bool);
						damageSprite2._spriteAnimation.AddAnimation("DamageZoneAnimationLoop", newAnimFrames, fps, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
						object obj = default(object);
						float num = (float)obj * 0.01f;
						Factory cachedTransform = (Factory)(object)_cachedTransform;
						float num2 = offsetX * 0.01f;
						_offsetPosition = (float2)num2;
						if ((object)_cachedTransform != null)
						{
							bool flag = cachedTransform._world == null;
							Transform.get_position_Injected((IntPtr)cachedTransform._world, out Vector3 _);
							if ((object)_damageSprite != null)
							{
								PhaserSprite phaserSprite2 = _damageSprite.setPosition(pos);
								if ((object)_damageSprite != null)
								{
									float xScale = default(float);
									PhaserSprite phaserSprite3 = _damageSprite.setScale(xScale, (float?)(object)0);
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

	public unsafe void EnableZone()
	{
		//IL_0116: Expected I, but got O
		//IL_01a0: Expected O, but got I4
		//IL_0284: Expected O, but got I4
		//IL_0672: Expected O, but got F4
		//IL_0695: Expected O, but got F4
		//IL_02b3: Expected F4, but got I4
		//IL_0442: Expected O, but got I4
		//IL_0488: Expected F4, but got I4
		//IL_04a2: Expected O, but got I4
		//IL_04ab: Expected O, but got I4
		//IL_0387: Expected O, but got I4
		//IL_0394: Expected F4, but got I4
		//IL_03ad: Expected O, but got I4
		//IL_03b6: Expected O, but got I4
		//IL_0599: Expected I, but got O
		//IL_05d5: Expected I, but got O
		//IL_05fd: Expected I, but got O
		//IL_0755->IL0624: Incompatible stack heights: 1 vs 0
		//IL_042a->IL0624: Incompatible stack heights: 1 vs 0
		//IL_045e->IL0624: Incompatible stack heights: 1 vs 0
		//IL_0708->IL0624: Incompatible stack heights: 1 vs 0
		//IL_036d->IL0624: Incompatible stack heights: 1 vs 0
		//IL_04e7->IL0624: Incompatible stack heights: 1 vs 0
		//IL_0513->IL0624: Incompatible stack heights: 1 vs 0
		//IL_0587->IL0624: Incompatible stack heights: 1 vs 0
		//IL_0565->IL0565: Incompatible stack heights: 2 vs 1
		//IL_0623->IL0623: Incompatible stack heights: 1 vs 0
		_activateDamage = false;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		Action onComplete = delegate
		{
			_hasHit = false;
		};
		float duration = _hitDelayMillis * 0.001f;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		if ((object)_groundFx != null)
		{
			PhaserSprite phaserSprite = _groundFx.setVisible(visible: false);
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				if ((object)_groundFx != null)
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
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					tweenConfig.yoyo = true;
					tweenConfig.repeat = 2;
					tweenConfig.alpha = (float?)(object)1;
					float num2 = (tweenConfig.duration = _warningTimeMillis * 0.5f);
					TweenCallback onStart = delegate
					{
						if (_visibleWarningZone)
						{
							PhaserSprite phaserSprite5 = _groundFx.setVisible(visible: true);
						}
					};
					tweenConfig.onStart = onStart;
					TweenCallback onComplete2 = ActivateDamage;
					tweenConfig.onComplete = onComplete2;
					MultiTargetTween activateDamageZoneTween = Tweens.Add(tweenConfig);
					_activateDamageZoneTween = activateDamageZoneTween;
					if (_despawnTimer != null)
					{
						_despawnTimer.Cancel();
					}
					_despawnTimer = null;
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					soundConfig.Volume = (float?)(object)1;
					soundConfig.Rate = 1f;
					object obj2 = UnityEngine.Random.value;
					float num3 = num2 * 500f;
					_ = 1065353216;
					((Delegate)(object)soundConfig).m_target = num3;
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Pizza, soundConfig, 150f, 2, flag ? 1 : 0);
					if (!_haveWarningMark)
					{
						return;
					}
					PhaserSprite exclamationMark = _exclamationMark;
					bool num4;
					Vector3 ret;
					Vector2 vector2 = default(Vector2);
					if ((object)_exclamationMark != null && ((UnityEngine.Object)exclamationMark).m_CachedPtr != (IntPtr)0)
					{
						Action cachedTransform = (Action)(object)_cachedTransform;
						if ((object)_cachedTransform != null)
						{
							bool flag2 = ((Delegate)cachedTransform).method_ptr == (IntPtr)0;
							num4 = flag2;
							Transform.get_position_Injected(((Delegate)cachedTransform).method_ptr, out ret);
							if ((object)_exclamationMark != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
								if ((object)_exclamationMark != null)
								{
									PhaserSprite phaserSprite2 = _exclamationMark.setScale(0f, (float?)(object)0);
									float num5 = 0f;
									float num7 = default(float);
									float num6 = num7;
									Vector2 vector = vector2;
									object obj3 = 0;
									float? num8 = (float?)(object)0;
									goto IL_04b0;
								}
							}
						}
					}
					else
					{
						PhaserWorld instance = PhaserWorld.Instance;
						Action cachedTransform2 = (Action)(object)_cachedTransform;
						if ((object)_cachedTransform != null)
						{
							bool flag3 = ((Delegate)cachedTransform2).method_ptr == (IntPtr)0;
							num4 = flag3;
							Transform.get_position_Injected(((Delegate)cachedTransform2).method_ptr, out ret);
							if ((object)instance != null)
							{
								PhaserSprite phaserSprite3 = instance.AddPhaserSprite(vector2, "UI", "ExclamationMark");
								if ((object)phaserSprite3 != null)
								{
									PhaserSprite phaserSprite4 = phaserSprite3.setScale(0f, (float?)(object)0);
									if ((object)phaserSprite4 != null)
									{
										PhaserSprite exclamationMark2 = phaserSprite4.setDepth(9000);
										_exclamationMark = exclamationMark2;
										float num5 = 0f;
										float num6 = 150f;
										Vector2 vector = vector2;
										object obj3 = 0;
										float? num8 = (float?)(object)0;
										goto IL_04b0;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0624;
		IL_0624:
		throw new NullReferenceException();
		IL_04b0:
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_exclamationMark != null)
		{
			Transform transform = _exclamationMark.transform;
			if (array2 != null)
			{
				if ((object)transform != null)
				{
					void* value = ((IntPtr*)(&array2))->m_value;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj4 = default(object);
					bool flag4 = obj4 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig2 != null)
				{
					((Delegate)(object)tweenConfig2).method_ptr = (IntPtr)array2;
					((Delegate)(object)tweenConfig2).invoke_impl = (IntPtr)1128792064;
					_ = 1;
					TweenCallback tweenCallback = delegate
					{
						PhaserSprite phaserSprite5 = _exclamationMark.setVisible(visible: true);
					};
					((Delegate)(object)tweenConfig2).delegate_trampoline = (IntPtr)tweenCallback;
					TweenCallback tweenCallback2 = delegate
					{
						//IL_003e: Expected I, but got O
						//IL_00b0: Expected O, but got I4
						TweenConfig tweenConfig3 = new TweenConfig();
						object[] array3 = new object[1];
						Transform transform2 = _exclamationMark.transform;
						if ((object)transform2 != null)
						{
							nint num9 = (nint)array3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj5 = default(object);
							if (obj5 == null)
							{
								ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
								throw ex2;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						tweenConfig3.targets = array3;
						tweenConfig3.duration = 200f;
						tweenConfig3.delay = 200f;
						tweenConfig3.scale = (float?)(object)1;
						TweenCallback onComplete3 = delegate
						{
							PhaserSprite phaserSprite5 = _exclamationMark.setVisible(visible: false);
						};
						tweenConfig3.onComplete = onComplete3;
						MultiTargetTween warningTween2 = Tweens.Add(tweenConfig3);
						_warningTween = warningTween2;
					};
					((Delegate)(object)tweenConfig2).extra_arg = (IntPtr)tweenCallback2;
					MultiTargetTween warningTween = Tweens.Add(tweenConfig2);
					_warningTween = warningTween;
					return;
				}
			}
		}
		goto IL_0624;
	}

	private unsafe void ActivateDamage()
	{
		//IL_0008: Expected O, but got Ref
		//IL_04ff: Expected O, but got I
		//IL_051b: Expected O, but got F4
		//IL_058d: Expected O, but got Ref
		//IL_05af: Expected O, but got I4
		//IL_017e: Expected I, but got O
		//IL_0208: Expected O, but got I
		//IL_0236: Expected O, but got I
		//IL_025d: Expected O, but got I
		//IL_0612: Expected O, but got Ref
		//IL_0632: Expected O, but got Ref
		//IL_03a7: Expected I4, but got F4
		//IL_06a7: Expected O, but got Ref
		//IL_06d7: Expected O, but got I
		//IL_0445: Expected I4, but got F4
		//IL_071c: Expected O, but got Ref
		//IL_00d0->IL04c8: Incompatible stack heights: 1 vs 0
		//IL_0145->IL04c8: Incompatible stack heights: 1 vs 0
		//IL_0121->IL0121: Incompatible stack heights: 2 vs 1
		//IL_01c3->IL04c8: Incompatible stack heights: 1 vs 0
		//IL_01a1->IL01a1: Incompatible stack heights: 2 vs 1
		//IL_03df->IL04c8: Incompatible stack heights: 1 vs 0
		//IL_02cf->IL04c8: Incompatible stack heights: 1 vs 0
		//IL_0302->IL04c8: Incompatible stack heights: 1 vs 0
		//IL_032e->IL04c8: Incompatible stack heights: 1 vs 0
		//IL_0670->IL04c8: Incompatible stack heights: 2 vs 0
		//IL_0365->IL04c8: Incompatible stack heights: 1 vs 0
		//IL_0424->IL04c8: Incompatible stack heights: 2 vs 0
		//IL_0387->IL04c8: Incompatible stack heights: 1 vs 0
		//IL_045f->IL045f: Incompatible stack heights: 5 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		_ = 0;
		_ = 1056964608;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		soundConfig.Volume = (float?)(object)0;
		soundConfig.Rate = 1f;
		object obj3 = UnityEngine.Random.value;
		object obj4 = default(object);
		float num = (float)obj4 - 0.5f;
		soundConfig.Rate = 1f;
		float detune = num * 500f;
		soundConfig.Detune = detune;
		float num2 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Explosion, soundConfig, 150f, 3, num2);
		bool useRealTime;
		if ((object)_groundFx != null)
		{
			Transform transform = _groundFx.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag = (byte)(~(((SoundManager.SoundConfig)(object)transform).Mute ? 1u : 0u)) != 0;
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Transform.get_localScale_Injected((IntPtr)(((SoundManager.SoundConfig)(object)transform).Mute ? 1 : 0), out *(Vector3*)obj5);
				PhaserSprite phaserSprite = setScale(1f, (float?)(object)0);
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(((PhaserSprite)this)._spriteRenderer, 0f);
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[2];
				if (array != null)
				{
					if ((object)((PhaserSprite)this)._spriteRenderer != null)
					{
						SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(((PhaserSprite)this)._spriteRenderer, 0f);
						bool flag2 = (object)spriteRenderer2 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if ((object)((PhaserSprite)this)._spriteRenderer != null)
					{
						Transform transform2 = ((PhaserSprite)this)._spriteRenderer.transform;
						if ((object)transform2 != null)
						{
							nint num3 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj6 = default(object);
							bool flag3 = obj6 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							tweenConfig.targets = array;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
							tweenConfig.scaleX = (float?)(object)0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-5]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
							tweenConfig.scaleY = (float?)(object)0;
							_ = 0;
							_ = 1036831949;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
							tweenConfig.alpha = (float?)(object)0;
							tweenConfig.duration = _activatonDelay;
							TweenCallback onStart = delegate
							{
								if (_visibleWarningZone)
								{
									PhaserSprite phaserSprite3 = setAlpha(0f);
									PhaserSprite phaserSprite4 = setVisible(visible: true);
									_activateDamage = true;
								}
								else
								{
									_activateDamage = true;
								}
							};
							tweenConfig.onStart = onStart;
							MultiTargetTween enableDamageTween = Tweens.Add(tweenConfig);
							_enableDamageTween = enableDamageTween;
							if (!_usingParticles)
							{
								if ((object)_damageSprite != null)
								{
									PhaserSprite phaserSprite2 = _damageSprite.setVisible(visible: true);
									if ((object)_damageSprite != null)
									{
										GameObject gameObject = _damageSprite.gameObject;
										if ((object)gameObject != null)
										{
											gameObject.SetActive(value: true);
											PhaserSprite damageSprite = _damageSprite;
											if ((object)_damageSprite != null && (object)damageSprite._spriteAnimation != null)
											{
												damageSprite._spriteAnimation.SetAnimation("DamageZoneAnimationLoop");
												useRealTime = (byte)(int)num2 != 0;
												goto IL_045f;
											}
										}
									}
								}
							}
							else
							{
								_currentEmitter = _pfxEmitter;
								Transform transform3 = base.transform;
								if ((object)transform3 != null)
								{
									_ = 0;
									_ = 0;
									bool flag4 = !((SoundManager.SoundConfig)(object)transform3).Mute;
									object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
									Transform.get_position_Injected((IntPtr)(((SoundManager.SoundConfig)(object)transform3).Mute ? 1 : 0), out *(Vector3*)obj7);
									Vector3 emitterLocation = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F]");
									_ = 0;
									SetEmitterLocation(emitterLocation);
									if ((object)_well != null)
									{
										Transform transform4 = _well.transform;
										Transform transform5 = base.transform;
										if ((object)transform5 != null)
										{
											_ = 0;
											_ = 0;
											bool flag5 = (byte)(~(((SoundManager.SoundConfig)(object)transform5).Mute ? 1u : 0u)) != 0;
											object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
											Transform.get_position_Injected((IntPtr)(((SoundManager.SoundConfig)(object)transform5).Mute ? 1 : 0), out *(Vector3*)obj8);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F]");
											nint num4 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1]");
											object obj9 = num4 + 0;
											bool flag6 = (object)transform4 == null;
											useRealTime = (byte)(int)num2 != 0;
											bool flag7 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
											object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
											Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)obj10);
											RenderingExtensions.Start(_pfxEmitter);
											goto IL_045f;
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
		IL_045f:
		Action onComplete = delegate
		{
			_activateDamage = false;
			TriggerDespawnDelayed();
		};
		float duration = _durationMillis * 0.001f;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_despawnTimer = despawnTimer;
	}

	protected unsafe override void OnUpdate()
	{
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_0307: Expected I, but got O
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Expected O, but got Unknown
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_00da: Expected F4, but got I
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Expected O, but got Unknown
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Expected O, but got Unknown
		//IL_051c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_0595: Unknown result type (might be due to invalid IL or missing references)
		//IL_059a: Expected O, but got Unknown
		//IL_0237: Expected O, but got I
		//IL_0076->IL0288: Incompatible stack heights: 3 vs 0
		//IL_055a->IL0288: Incompatible stack heights: 11 vs 0
		//IL_05c9->IL0288: Incompatible stack heights: 12 vs 0
		//IL_0281->IL0281: Incompatible stack heights: 12 vs 6
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			object obj2 = default(object);
			object obj = obj2 - 96;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj);
			nint num = (nint)this;
			Vector3 currentPosition = (Vector3)(obj2 - 80);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-60]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-58]");
			_ = 0;
			Vector3 vector = UpdatePosition(currentPosition);
			Transform cachedTransform2 = _cachedTransform;
			_ = vector.x;
			bool flag2 = (object)_cachedTransform == null;
			_ = vector.z;
			bool flag3 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
			object obj3 = obj2 - 80;
			Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref *(Vector3*)obj3);
			object exclamationMark = _exclamationMark;
			if ((object)_exclamationMark != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdi_v19 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					if ((object)_exclamationMark == null)
					{
						goto IL_0288;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				}
			}
			Circle circleCollider = _circleCollider;
			if (_circleCollider != null)
			{
				circleCollider._x = vector.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-3C]");
				circleCollider._y = 0f;
			}
			bool flag4 = (object)_groundFx == null;
			Transform transform = _groundFx.transform;
			bool flag5 = (object)transform == null;
			_ = vector.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ rax_v57 (UnityEngine.Transform)+10]");
			bool flag6 = (nint)0 == 0;
			object obj4 = obj2 - 80;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ rax_v57 (UnityEngine.Transform)+10]");
			Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj4);
			if (_usingParticles)
			{
				ParticleSystem currentEmitter = _currentEmitter;
				if ((object)_currentEmitter != null && ((UnityEngine.Object)currentEmitter).m_CachedPtr != (IntPtr)0)
				{
					_ = vector.z;
					Vector3 emitterLocation = (Vector3)(obj2 - 80);
					SetEmitterLocation(emitterLocation);
				}
				goto IL_0281;
			}
			bool flag7 = (object)_damageSprite == null;
			Transform transform2 = _damageSprite.transform;
			bool flag8 = (object)transform2 == null;
			_ = vector.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1133 @ rax_v65 (UnityEngine.Transform)+10]");
			bool flag9 = (nint)0 == 0;
			object obj5 = obj2 - 64;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1133 @ rax_v65 (UnityEngine.Transform)+10]");
			Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj5);
			Transform transform3 = base.transform;
			bool flag10 = (object)transform3 == null;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1152 @ rax_v70 (UnityEngine.Transform)+10]");
			bool flag11 = (nint)0 == 0;
			object obj6 = obj2 - 80;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1152 @ rax_v70 (UnityEngine.Transform)+10]");
			Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj6);
			object targetTransform = _targetTransform;
			if ((object)_targetTransform != null)
			{
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v25 (System.Object)+10]");
				bool flag12 = (nint)0 == 0;
				object obj7 = obj2 - 96;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v25 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj7);
				if ((object)_damageSprite != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-60]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-50]");
					bool flag13 = num2 < 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-60]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-50]");
					object obj8 = num3 - 0;
					bool flag14 = obj8 == null;
					bool flag15 = !flag13;
					bool flag16 = !flag14;
					bool flag17 = flag16 & flag15;
					PhaserSprite phaserSprite = _damageSprite.setFlipX(flag17);
					goto IL_0281;
				}
			}
		}
		goto IL_0288;
		IL_0288:
		throw new NullReferenceException();
		IL_0281:
		UpdatePlayerEffects();
	}

	protected unsafe virtual Vector3 UpdatePosition(Vector3 currentPosition)
	{
		//IL_000d: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		//IL_00ad: Expected native int or pointer, but got O
		//IL_0126: Expected O, but got F4
		//IL_0163: Expected F4, but got O
		//IL_015e: Expected native int or pointer, but got O
		//IL_0178: Expected F4, but got I
		//IL_0173: Expected native int or pointer, but got O
		//IL_00bf: Expected native int or pointer, but got O
		//IL_0197->IL00c9: Incompatible stack heights: 1 vs 0
		//IL_00c9->IL00c9: Incompatible stack heights: 1 vs 0
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = currentPosition.x;
		((Vector3*)(nint)vector)->z = currentPosition.z;
		if (_lockX || _lockY || _follow)
		{
			Transform targetTransform = _targetTransform;
			bool flag = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
			float ret;
			Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out *(Vector3*)(&ret));
			if (_follow)
			{
				object obj = Time.deltaTime;
				float num = _followSpeed * 0.01f;
				float num2 = currentPosition.x * num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2E70");
				object obj2 = default(object);
				((Vector3*)(nint)vector)->x = (float)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v23+8]");
				((Vector3*)(nint)vector)->z = 0f;
			}
			if (_lockX)
			{
				((Vector3*)(nint)vector)->x = ret;
			}
			if (_lockY)
			{
				float y = default(float);
				((Vector3*)(nint)vector)->y = y;
			}
		}
		return vector;
	}

	protected unsafe virtual void UpdatePlayerEffects()
	{
		//IL_00c6: Expected O, but got I4
		//IL_00cf: Expected O, but got I4
		//IL_0180: Expected O, but got I4
		//IL_01a0: Expected I, but got O
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_0216: Expected O, but got I4
		//IL_021e: Expected O, but got Ref
		//IL_01c5: Expected I, but got O
		//IL_024d->IL0252: Incompatible stack heights: 1 vs 0
		//IL_0252->IL01d4: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
		if (_hasHit || !_activateDamage || core._mainCharacters == null || mainCharacters._size == 0 || mainCharacters._size <= 0)
		{
			return;
		}
		Vector3 _unity_self = (Vector3)0;
		object obj = 0;
		Vector2 point = default(Vector2);
		Vector2 vector = default(Vector2);
		object obj3 = default(object);
		object obj5 = default(object);
		do
		{
			bool flag = (nint)obj >= mainCharacters._size;
			VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
			bool flag2;
			Vector2 vector3;
			if (!_isCircle)
			{
				Bounds bounds = _groundFx.Bounds;
				float2 float5 = items[obj].position;
				flag2 = Bounds.Contains_Injected(ref *(Bounds*)(&_unity_self), ref *(Vector3*)(&point));
				point = vector;
				object obj2 = obj3;
				Vector2 vector2 = vector;
				object obj4 = 0;
				vector3 = (Vector2)(&point);
			}
			else
			{
				float2 float6 = items[obj].position;
				flag2 = _circleCollider.Contains(vector);
				object obj2 = obj3;
				Vector2 vector2 = vector;
				object obj4 = 0;
				vector3 = vector;
			}
			bool flag3 = !flag2;
			nint num = (nint)vector3;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				num = (nint)obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v131 @ rdx_v7 (Il2CppMethodInfo)+5F8] (should have been resolved before IL gen)");
			}
			obj++;
		}
		while ((nint)obj < mainCharacters._size);
	}

	private void TriggerDespawnDelayed()
	{
		//IL_00f1: Expected I, but got O
		PhaserSprite phaserSprite = setVisible(visible: false);
		GameObject gameObject = _groundFx.gameObject;
		gameObject.SetActive(value: false);
		if (!_usingParticles)
		{
			PhaserSprite damageSprite = _damageSprite;
			SpriteAnimation spriteAnimation = damageSprite._spriteAnimation;
			((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
			GameObject gameObject2 = _damageSprite.gameObject;
			gameObject2.SetActive(value: false);
			Despawn();
			return;
		}
		if ((object)_pfxEmitter != null)
		{
			RenderingExtensions.StopEmitting(_pfxEmitter);
		}
		float remainingLifetime = RenderingExtensions.GetRemainingLifetime(_currentEmitter);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.DamageZoneFlexible>)+220]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer particleDespawnTimer = Timers.Register(remainingLifetime, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_particleDespawnTimer = particleDespawnTimer;
	}

	protected virtual void Despawn()
	{
		//IL_03b1->IL0394: Incompatible stack heights: 1 vs 0
		GameObject obj = base.gameObject;
		if ((object)base._ParentPool != null)
		{
			base._ParentPool.Release(obj);
			_activateDamage = false;
			if (_despawnTimer != null)
			{
				_despawnTimer.Cancel();
			}
			if (_hitboxTimer != null)
			{
				_hitboxTimer.Cancel();
			}
			if (_particleDespawnTimer != null)
			{
				_particleDespawnTimer.Cancel();
			}
			if (_activateDamageZoneTween != null)
			{
				_activateDamageZoneTween.Kill();
			}
			if (_enableDamageTween != null)
			{
				_enableDamageTween.Kill();
			}
			if (_warningTween != null)
			{
				_warningTween.Kill();
			}
			PhaserSprite phaserSprite = setVisible(visible: false);
			if (_usingParticles)
			{
				goto IL_02ac;
			}
			PhaserSprite damageSprite = _damageSprite;
			if ((object)_damageSprite != null)
			{
				SpriteAnimation spriteAnimation = damageSprite._spriteAnimation;
				if ((object)damageSprite._spriteAnimation != null)
				{
					((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
					if ((object)_damageSprite != null)
					{
						GameObject gameObject = _damageSprite.gameObject;
						if ((object)gameObject != null)
						{
							gameObject.SetActive(value: false);
							PhaserSprite damageSprite2 = _damageSprite;
							if ((object)_damageSprite != null && (object)damageSprite2._spriteAnimation != null)
							{
								damageSprite2._spriteAnimation.CleanAnimations();
								goto IL_02ac;
							}
						}
					}
				}
			}
		}
		goto IL_038d;
		IL_02ac:
		if ((object)_groundFx != null)
		{
			GameObject gameObject2 = _groundFx.gameObject;
			if ((object)gameObject2 != null)
			{
				gameObject2.SetActive(value: false);
				if (!_usingParticles)
				{
					return;
				}
				if ((object)_particlesManager != null)
				{
					Transform transform = _particlesManager.transform;
					if ((object)transform != null)
					{
						transform.SetParent(_cachedTransform, worldPositionStays: true);
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
						return;
					}
				}
			}
		}
		goto IL_038d;
		IL_038d:
		throw new NullReferenceException();
	}

	private unsafe Vector3 GetZoneAlignmentPosition(Vector3 pos)
	{
		//IL_0349: Expected native int or pointer, but got O
		//IL_035b: Expected native int or pointer, but got O
		//IL_002f: Expected O, but got I4
		//IL_0323: Expected native int or pointer, but got O
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_02c9: Expected native int or pointer, but got O
		//IL_0270: Expected native int or pointer, but got O
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_0216: Expected native int or pointer, but got O
		//IL_01bd: Expected native int or pointer, but got O
		//IL_0160: Expected native int or pointer, but got O
		//IL_0390: Expected native int or pointer, but got O
		bool flag = _zoneAlignment == ZoneAlignment.Center;
		if (!flag)
		{
			object obj = _zoneAlignment - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (!flag)
					{
						if ((nint)obj3 != 1)
						{
							ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
							throw ex;
						}
						float num;
						if (_isCircle)
						{
							Circle circleCollider = _circleCollider;
							num = circleCollider._radius;
						}
						else
						{
							Bounds bounds = _groundFx.Bounds;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rax_v19 (UnityEngine.Bounds)+10]");
							float num2 = 0f * 2f;
							num = num2 * 0.5f;
						}
						float y = pos.y - num;
						((Vector3*)(nint)pos)->y = y;
					}
					else if (_isCircle)
					{
						Circle circleCollider2 = _circleCollider;
						float y2 = circleCollider2._radius + pos.y;
						((Vector3*)(nint)pos)->y = y2;
					}
					else
					{
						Bounds bounds2 = _groundFx.Bounds;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v16 (UnityEngine.Bounds)+10]");
						float num3 = 0f * 2f;
						float num4 = num3 * 0.5f;
						float y3 = num4 + pos.y;
						((Vector3*)(nint)pos)->y = y3;
					}
				}
				else if (_isCircle)
				{
					Circle circleCollider3 = _circleCollider;
					float x = circleCollider3._radius + pos.x;
					((Vector3*)(nint)pos)->x = x;
				}
				else
				{
					float num5 = (float)_groundFx.Bounds.m_Extents * 2f;
					float num6 = num5 * 0.5f;
					float x2 = num6 + pos.x;
					((Vector3*)(nint)pos)->x = x2;
				}
			}
			else if (_isCircle)
			{
				Circle circleCollider4 = _circleCollider;
				float x3 = pos.x - circleCollider4._radius;
				((Vector3*)(nint)pos)->x = x3;
			}
			else
			{
				float num7 = (float)_groundFx.Bounds.m_Extents * 2f;
				float num8 = num7 * 0.5f;
				float x4 = pos.x - num8;
				((Vector3*)(nint)pos)->x = x4;
			}
		}
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = pos.x;
		((Vector3*)(nint)vector)->z = pos.z;
		return vector;
	}

	private unsafe void SetEmitterLocation(Vector3 newPos)
	{
		//IL_000a: Expected O, but got Ref
		//IL_007d->IL012e: Incompatible stack heights: 1 vs 0
		//IL_00a9->IL012e: Incompatible stack heights: 1 vs 0
		//IL_00c8->IL012e: Incompatible stack heights: 1 vs 0
		//IL_00f9->IL012e: Incompatible stack heights: 1 vs 0
		float value = default(float);
		Vector3 zoneAlignmentPosition = GetZoneAlignmentPosition((Vector3)(&value));
		if ((object)_currentEmitter != null)
		{
			Transform transform = _currentEmitter.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
				if (_isCircle)
				{
					return;
				}
				if ((object)_currentEmitter != null)
				{
					PfxData component = _currentEmitter.GetComponent<PfxData>();
					if ((object)component != null && (object)_groundFx != null)
					{
						Bounds bounds = _groundFx.Bounds;
						if (component._003CCurrentConfig_003Ek__BackingField != null)
						{
							_ = 1;
							_ = 0;
							RenderingExtensions.SetCollisionBoundsWorld(_currentEmitter, component._003CCurrentConfig_003Ek__BackingField);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SetEmitterBounds()
	{
		//IL_004d: Expected O, but got I4
		if (!_isCircle)
		{
			PfxData component = _currentEmitter.GetComponent<PfxData>();
			ParticleSystemConfig particleSystemConfig = component._003CCurrentConfig_003Ek__BackingField;
			Bounds bounds = _groundFx.Bounds;
			particleSystemConfig._boundsWorld = (Bounds?)(object)1;
			_ = 0;
			RenderingExtensions.SetCollisionBoundsWorld(_currentEmitter, component._003CCurrentConfig_003Ek__BackingField);
		}
	}

	private void MakeEmitterManager()
	{
		//IL_00cf: Expected O, but got I4
		//IL_01ee: Expected O, but got I4
		//IL_01ab->IL0128: Incompatible stack heights: 1 vs 0
		//IL_00f1->IL0128: Incompatible stack heights: 1 vs 0
		//IL_0232->IL0128: Incompatible stack heights: 2 vs 0
		//IL_0128->IL0162: Incompatible stack heights: 2 vs 0
		ParticleEmitterManager particlesManager = _particlesManager;
		if ((object)_particlesManager != null && ((UnityEngine.Object)particlesManager).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameObject gameObject = CreateEmitterGameObject("ParticlesManager");
		if ((object)gameObject != null)
		{
			ParticleEmitterManager particlesManager2 = gameObject.AddComponent<ParticleEmitterManager>();
			_particlesManager = particlesManager2;
			GravityWellConfig gravityWellConfig = new GravityWellConfig();
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if (gravityWellConfig != null)
				{
					gravityWellConfig._x = (float?)(object)1;
					Transform transform2 = base.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
						gravityWellConfig._y = (float?)(object)1;
						gravityWellConfig._power = 1f;
						gravityWellConfig._epsilon = 50f;
						gravityWellConfig._gravity = 20f;
						if ((object)_particlesManager != null)
						{
							GravityWell well = _particlesManager.CreateGravityWell(gravityWellConfig, null, "Well");
							_well = well;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void MakeEmitters(ParticleSystemConfig config1, ParticleSystemConfig config2)
	{
		//IL_00e8: Expected O, but got I
		//IL_0134: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3759]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ParticleSystemConfig config3 = default(ParticleSystemConfig);
		ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(config3, null, "PfxEmitter1");
		_pfxEmitter = pfxEmitter;
		_currentEmitter = _pfxEmitter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9D8]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9D8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v394 @ rax_v17 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9D8]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9D8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v525 @ rax_v22 (should have been resolved before IL gen)");
	}

	private GameObject CreateEmitterGameObject(string childName)
	{
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, childName);
		if ((object)gameObject != null)
		{
			Transform transform = gameObject.transform;
			Transform parent = base.transform;
			if ((object)transform != null)
			{
				transform.SetParent(parent, worldPositionStays: true);
				Transform transform2 = gameObject.transform;
				string cachedTransform = (string)(object)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag = cachedTransform._stringLength == 0;
					Transform.get_position_Injected((IntPtr)cachedTransform._stringLength, out Vector3 _);
					bool flag2 = (object)transform2 == null;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
					return gameObject;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void StopAllEmitters()
	{
		if ((object)_pfxEmitter != null)
		{
			RenderingExtensions.StopEmitting(_pfxEmitter);
		}
	}

	private void ToggleParentAllEmitters(bool shouldParent)
	{
		if ((object)_particlesManager != null)
		{
			Transform transform = _particlesManager.transform;
			Transform parent = ((!shouldParent) ? null : _cachedTransform);
			if ((object)transform != null)
			{
				transform.SetParent(parent, worldPositionStays: true);
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private static void SetParentAndScale(Transform trans, Transform parent)
	{
		trans.SetParent(parent, worldPositionStays: true);
		bool flag = ((UnityEngine.Object)trans).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)trans).m_CachedPtr, ref value);
	}

	public DamageZoneFlexible()
	{
		//IL_0057: Expected I, but got O
		_damage = 1f;
		_activatonDelay = 500f;
		_durationMillis = 250f;
		_hitDelayMillis = 500f;
		_visibleWarningZone = true;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CEnableZone_003Eb__46_0()
	{
		_hasHit = false;
	}

	private void _003CEnableZone_003Eb__46_1()
	{
		if (_visibleWarningZone)
		{
			PhaserSprite phaserSprite = _groundFx.setVisible(visible: true);
		}
	}

	private void _003CEnableZone_003Eb__46_2()
	{
		PhaserSprite phaserSprite = _exclamationMark.setVisible(visible: true);
	}

	private void _003CEnableZone_003Eb__46_3()
	{
		//IL_003e: Expected I, but got O
		//IL_00b0: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = _exclamationMark.transform;
		if ((object)transform != null)
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
		tweenConfig.duration = 200f;
		tweenConfig.delay = 200f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite = _exclamationMark.setVisible(visible: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween warningTween = Tweens.Add(tweenConfig);
		_warningTween = warningTween;
	}

	private void _003CEnableZone_003Eb__46_4()
	{
		PhaserSprite phaserSprite = _exclamationMark.setVisible(visible: false);
	}

	private void _003CActivateDamage_003Eb__47_1()
	{
		if (_visibleWarningZone)
		{
			PhaserSprite phaserSprite = setAlpha(0f);
			PhaserSprite phaserSprite2 = setVisible(visible: true);
			_activateDamage = true;
		}
		else
		{
			_activateDamage = true;
		}
	}

	private void _003CActivateDamage_003Eb__47_0()
	{
		_activateDamage = false;
		TriggerDespawnDelayed();
	}
}
