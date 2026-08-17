using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class VortexWeapon : Weapon
{
	private SpriteRenderer _Renderer;

	private MultiTargetTween _imageTween;

	private float _recoveredHP;

	private float _recoveredCalculated;

	private SpriteRenderer _imageBG;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private GravityWell _well;

	private float _imageScale = 9f / 64f;

	private Circle _shape1;

	private EmitZone _emitZone;

	private float _innerScale;

	private float _innerDuration;

	private float _vfxTime;

	private float _mul = 166.66667f;

	private bool _cooldownAffectedByMovement;

	public float RecoveredHP => _recoveredHP;

	public override float PAmount()
	{
		return 1f;
	}

	public override float PArea()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		float num2 = TP_Frog2_Weapon.PAreaMax * 3f;
		object obj = default(object);
		float num3 = (float)obj * currentWeaponData._003Carea_003Ek__BackingField;
		if (num2 > num3)
		{
			num2 = num3;
		}
		return num2;
	}

	public override float PPower()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PPower();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj2 = default(object);
		object obj = obj2 * currentWeaponData._003Cpower_003Ek__BackingField;
		return (float)obj + _recoveredCalculated;
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_03a8: Invalid comparison between F4 and I4
		//IL_03c5: Expected O, but got F4
		//IL_0390: Expected F4, but got I4
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Expected Ref, but got Unknown
		//IL_0478: Expected O, but got I
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0690: Expected O, but got Unknown
		//IL_06aa: Expected native int or pointer, but got O
		//IL_0727: Unknown result type (might be due to invalid IL or missing references)
		//IL_072c: Expected O, but got Unknown
		//IL_0765: Expected native int or pointer, but got O
		//IL_0831: Expected O, but got I
		//IL_0846: Expected O, but got I
		//IL_027e->IL027e: Incompatible stack heights: 6 vs 5
		//IL_0395->IL03b8: Incompatible stack heights: 7 vs 8
		//IL_07a3->IL08d5: Incompatible stack heights: 12 vs 0
		//IL_0805->IL08d5: Incompatible stack heights: 12 vs 0
		//IL_088a->IL08d5: Incompatible stack heights: 12 vs 0
		object obj2 = default(object);
		object obj = obj2 - 120;
		base.InitWeapon(characterController, weaponType);
		if ((object)this != null)
		{
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			SpriteRenderer imageBG = RenderingExtensions.AddSprite(gameObject, pos, "vfx", "circle");
			_imageBG = imageBG;
			Material material = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
			if ((object)_imageBG != null)
			{
				((Renderer)_imageBG).SetMaterial(material);
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_imageBG, 0.6f);
				SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(_imageBG, 0u);
				if ((object)_imageBG != null)
				{
					Transform transform = _imageBG.transform;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						Transform transform2 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
						if ((object)transform2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v40 (UnityEngine.Transform)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v40 (UnityEngine.Transform)+10]");
							Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
							bool flag2 = (object)transform == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rax_v39 (UnityEngine.Transform)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rax_v39 (UnityEngine.Transform)+10]");
							Vector3 value = default(Vector3);
							Transform.set_position_Injected((IntPtr)0, ref value);
							float num = PArea();
							object obj3 = ret + ret;
							float num2 = (float)obj3 * _imageScale;
							SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(_imageBG, num2);
							Material material2 = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
							bool flag4 = (object)_Renderer == null;
							((Renderer)_Renderer).SetMaterial(material2);
							SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha(_Renderer, 0.1f);
							SpriteRenderer spriteRenderer5 = RenderingExtensions.SetTint(_Renderer, 0u);
							float num3 = PArea();
							float num4 = num2 + num2;
							float scale = num4 * _imageScale;
							SpriteRenderer spriteRenderer6 = RenderingExtensions.SetScale(_Renderer, scale);
							TweenConfig tweenConfig = new TweenConfig();
							object[] array = new object[1];
							bool flag5 = array == null;
							if ((object)_Renderer != null)
							{
								SpriteRenderer spriteRenderer7 = RenderingExtensions.SetScale(_Renderer, scale);
								bool flag6 = (object)spriteRenderer7 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							bool flag7 = tweenConfig == null;
							_ = 0;
							_ = 1;
							_ = 1120403456;
							_ = 1148846080;
							_ = 1;
							_ = 4294967295L;
							_ = 1058642330;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
							_ = 0;
							MultiTargetTween imageTween = Tweens.Add(tweenConfig);
							_imageTween = imageTween;
							VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
							_recoveredHP = 0f;
							bool flag8 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
							Action<float, float> b = null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
							Delegate obj4 = Delegate.Combine(characterController2._onHpRecoveryCallback, b);
							float num5 = default(float);
							if ((object)obj4 == null)
							{
								num5 = 0f;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								bool flag9 = num5 == 0f;
							}
							characterController2._onHpRecoveryCallback = (Action<float, float>)num5;
							GameObject gameObject2 = base.gameObject;
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rbx_v21 (Il2CppMethodInfo)+38]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
							}
							_ = 0;
							bool flag10 = (object)gameObject2 == null;
							ParticleEmitterManager particlesManager;
							if (gameObject2.TryGetComponent<ParticleEmitterManager>(out *(ParticleEmitterManager*)(obj + 128)))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
								particlesManager = (ParticleEmitterManager)0;
							}
							else
							{
								particlesManager = gameObject2.AddComponent<ParticleEmitterManager>();
							}
							_particlesManager = particlesManager;
							_shape1 = new Circle
							{
								_x = 0f,
								_radius = 60f
							};
							_emitZone = new EmitZone
							{
								_type = EmitZoneType.Random,
								_source = _shape1
							};
							ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
							List<string> list = new List<string>();
							bool flag11 = list == null;
							int version = list._version + 1;
							list._version = version;
							string[] items = list._items;
							bool flag12 = list._items == null;
							if (list._size >= items.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"PfxColor2");
							}
							else
							{
								int size = list._size + 1;
								list._size = size;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							bool flag13 = particleSystemConfig == null;
							ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
							_ = 0;
							_ = 0;
							minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
							_ = 0;
							_ = 0;
							minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
							_ = 0;
							_ = 0;
							minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)(obj - 24);
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
							_ = 0;
							_ = 0;
							_ = 1;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
							_ = 0;
							_ = 0;
							minMaxCurve = new ParticleSystem.MinMaxCurve(0.2f);
							_ = 0;
							_ = 0;
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)(obj + 8);
							_ = 0;
							_ = 1;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
							_ = 0;
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
							_ = 0;
							_ = _emitZone;
							if ((object)_particlesManager != null)
							{
								ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig);
								_pfxEmitter = pfxEmitter;
								GravityWellConfig gravityWellConfig = new GravityWellConfig();
								_ = 0;
								_ = 0;
								_ = 1;
								if (gravityWellConfig != null)
								{
									_ = 0;
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
									gravityWellConfig._y = (float?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
									gravityWellConfig._x = (float?)(object)0;
									gravityWellConfig._power = 0.51f;
									gravityWellConfig._epsilon = 20f;
									gravityWellConfig._gravity = 50f;
									if ((object)_particlesManager != null)
									{
										GravityWell well = _particlesManager.CreateGravityWell(gravityWellConfig);
										_well = well;
										base._003CTotalTime_003Ek__BackingField = 0f;
										_innerScale = 0f;
										_innerDuration = 6000f;
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

	public override void Fire(bool skipTriggers = false)
	{
		float num = _recoveredHP / 600f;
		bool flag = !(6f > num);
		float recoveredCalculated = 6f;
		if (!flag)
		{
			recoveredCalculated = num;
		}
		_recoveredCalculated = recoveredCalculated;
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		if (arcanaManager._hasAstronomia)
		{
			GameManager core2 = GM.Core;
			core2._arcanaManager.TriggerAstronomia(this);
		}
		base.Fire(skipTriggers);
	}

	protected void VortexUpdate(float deltaTime)
	{
		//IL_008b: Expected O, but got I4
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected I4, but got Unknown
		//IL_0349: Expected I4, but got I8
		//IL_0363->IL0273: Incompatible stack heights: 2 vs 0
		//IL_01e7->IL0273: Incompatible stack heights: 4 vs 0
		//IL_0248->IL0273: Incompatible stack heights: 4 vs 0
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			int depth = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer = s_scene._renderer;
					if (s_scene._renderer != null)
					{
						int num = renderer.pixelHeight >> 31;
						object obj = renderer.pixelHeight - num;
						object obj2 = obj >> 1;
						int sortingOrder = depth - obj2;
						if ((object)_Renderer != null)
						{
							_Renderer.sortingOrder = sortingOrder;
							if ((object)_imageBG != null)
							{
								_imageBG.sortingOrder = sortingOrder;
								if ((object)_pfxEmitter != null)
								{
									Transform transform = _pfxEmitter.transform;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rax_v35 (UnityEngine.Transform)+10]");
									bool flag = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rax_v35 (UnityEngine.Transform)+10]");
									Vector3 value = default(Vector3);
									Transform.set_localPosition_Injected((IntPtr)0, ref value);
									Transform transform2 = _Renderer.transform;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v43 (UnityEngine.Transform)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v43 (UnityEngine.Transform)+10]");
									Transform.get_position_Injected((IntPtr)0, out Vector3 _);
									Vector2 pos = default(Vector2);
									RenderingExtensions.EmitParticleAt(_pfxEmitter, pos, -1);
									if ((object)_well != null)
									{
										Transform transform3 = _well.transform;
										bool flag3 = (object)transform3 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v869 @ rax_v50 (UnityEngine.Transform)+10]");
										bool flag4 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v869 @ rax_v50 (UnityEngine.Transform)+10]");
										Transform.set_localPosition_Injected((IntPtr)0, ref value);
										float num2 = PArea();
										object obj3 = Vector3.zeroVector + Vector3.zeroVector;
										float num3 = (float)obj3 * _imageScale;
										SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_imageBG, num3);
										if ((_vfxTime = deltaTime + _vfxTime) > _innerDuration)
										{
											_vfxTime = 0f;
										}
										float num4 = PArea();
										float num5 = _innerDuration - _vfxTime;
										float num6 = num5 / _innerDuration;
										float num7 = (_innerScale = num6 * num3);
										float num8 = num7 + num7;
										SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(scale: num8 * _imageScale, component: _Renderer);
										float num9 = PArea();
										if (_shape1 != null)
										{
											float num10 = num3 * 16f;
											float num11 = num10 + num10;
											float num12 = num11 + num11;
											EmitZone emitZone = _emitZone;
											if (_emitZone != null)
											{
												emitZone._source = _shape1;
												RenderingExtensions.SetEmitZone(_pfxEmitter, _emitZone);
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
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float num = PauseSystem.DeltaTime;
		float num2 = num * 1000f;
		float num3 = num2 + base._003CTotalTime_003Ek__BackingField;
		base._003CTotalTime_003Ek__BackingField = num3;
		VortexUpdate(num2);
		if (_cooldownAffectedByMovement)
		{
			float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
			float num4 = num2 / _mul;
			num = frameWalk * 100f;
			float num5 = num4 * num;
			float num6 = num5 + base._003CTotalTime_003Ek__BackingField;
			base._003CTotalTime_003Ek__BackingField = num6;
		}
		float num7 = base.PInterval();
		if (!(base._003CTotalTime_003Ek__BackingField < num))
		{
			float num8 = base.PInterval();
			float num9 = base._003CTotalTime_003Ek__BackingField - num;
			base._003CTotalTime_003Ek__BackingField = num9;
			base.Fire();
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Cleanup()
	{
		base.Cleanup();
		SpriteRenderer renderer = _Renderer;
		if ((object)_Renderer != null && ((UnityEngine.Object)renderer).m_CachedPtr != (IntPtr)0)
		{
			_Renderer.enabled = false;
			GameObject gameObject = _Renderer.gameObject;
			if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject2 = _Renderer.gameObject;
				gameObject2.SetActive(value: false);
			}
		}
		if (_imageTween != null)
		{
			_imageTween.Kill();
		}
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0356: Expected I4, but got O
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_0110: Expected I, but got O
		//IL_0118: Expected I, but got O
		//IL_0128: Expected O, but got I
		//IL_0164: Expected O, but got I
		//IL_01a1: Expected O, but got I
		//IL_01e5: Expected O, but got I4
		//IL_01d7: Expected O, but got I4
		//IL_03cf: Expected I, but got O
		if (first == null)
		{
			goto IL_0348;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v2 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v2 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rax_v50+FFFFFFF8+v61 @ rax_v4*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj3 = 1;
				goto IL_0373;
			}
		}
		obj3 = 0;
		goto IL_0373;
		IL_0395:
		return false;
		IL_0348:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0373:
		bool flag = obj3 == null;
		ArcadeColliderType arcadeColliderType = null;
		if (!flag)
		{
			arcadeColliderType = first;
		}
		if (arcadeColliderType != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbx_v3 (ArcadeColliderType)+260]");
			if ((nint)0 != 0)
			{
				goto IL_0395;
			}
			if (second != null)
			{
				nint num4 = (nint)typeof(Projectile);
				nint num5 = (nint)second;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v9+FFFFFFF8+v132 @ rax_v8*8]");
					if (0 == (nint)typeof(Projectile))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v9+FFFFFFF8+v425 @ rcx_v6*8]");
						object obj7 = ((0 != (nint)typeof(Projectile)) ? ((object)0) : ((object)1));
						bool flag2 = obj7 == null;
						ArcadeColliderType arcadeColliderType2 = null;
						if (!flag2)
						{
							arcadeColliderType2 = second;
						}
						if (!((Projectile)arcadeColliderType2).HasAlreadyHitObject((IDamageable)arcadeColliderType))
						{
							float num7 = PPower();
							WeaponData currentWeaponData = _currentWeaponData;
							if (_currentWeaponData != null)
							{
								HitVfxType hitVfxType = currentWeaponData._003ChitVFX_003Ek__BackingField;
							}
							else
							{
								HitVfxType hitVfxType = HitVfxType.Default;
							}
							float knockback = base.Knockback;
							nint num8 = (nint)arcadeColliderType;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v473 @ rdx_v9 (Il2CppClass<ArcadeColliderType>)+3E8] (should have been resolved before IL gen)");
							float num9 = PPower();
							float num10 = knockback + base._003CStatsInflictedDamage_003Ek__BackingField;
							base._003CStatsInflictedDamage_003Ek__BackingField = num10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbx_v3 (ArcadeColliderType)+260]");
							if ((nint)0 != 0)
							{
								float value = UnityEngine.Random.value;
								float num11 = PPower();
								float2 position = ((ArcadeSprite)arcadeColliderType).position;
								float num12 = value / 7f;
								float num13 = num12 * 0.15f;
								if (num13 > value)
								{
									if ((object)GM.Core != null && (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.LITTLEHEART)))
									{
										Vector2 pos = default(Vector2);
										Pickup pickup = PickupManager.CreatePickup(pos, ItemType.LITTLEHEART);
										if ((object)pickup != null)
										{
											pickup.GoToLowestHealthPlayer();
											pickup.Time = 1f;
											goto IL_0395;
										}
									}
									goto IL_0348;
								}
							}
						}
						goto IL_0395;
					}
				}
			}
		}
		goto IL_0348;
	}

	public override void CheckArcanas()
	{
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj > -1)
		{
			_cooldownAffectedByMovement = true;
		}
		CheckBeginningArcana();
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		if ((object)_Renderer != null)
		{
			_Renderer.enabled = visible;
		}
		if ((object)_imageBG != null)
		{
			_imageBG.enabled = visible;
		}
	}

	private void _003CInitWeapon_003Eb__21_0(float amount, float rawAmount)
	{
		float recoveredHP = amount + _recoveredHP;
		_recoveredHP = recoveredHP;
	}
}
