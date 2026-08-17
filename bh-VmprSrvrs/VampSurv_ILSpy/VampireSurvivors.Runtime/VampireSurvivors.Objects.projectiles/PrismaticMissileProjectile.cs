using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class PrismaticMissileProjectile : Projectile
{
	private TrailRenderer _trail;

	private Timer _expireTimer;

	private MultiTargetTween _fadeInTween;

	private MultiTargetTween _fadeOutTween;

	private Timer _despawnTimer;

	private MultiTargetTween _despawnTween;

	private float _defaultFallDuration = 1500f;

	private float _fallDuration = 1500f;

	private PrismaticMissileWeapon _trueWeapon;

	private MultiTargetTween _scaleTween;

	private Timer _explodeTimer;

	private string _frameNameBeam = "Gradient3_4px";

	private float _startingAlpha = 0.5f;

	private float _startingAngle;

	private float _startingX;

	private float _angleIncrement;

	private bool _showTrailOnSecondUpdate;

	private float _updateTicks;

	private PhaserSprite _groundFx;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfxEmitter;

	private GravityWell _well;

	private Circle _explosionCircle;

	private float _exploRadius = 16f;

	private MultiTargetTween _groundFxTween;

	private float _angleUnit = 0.8975979f;

	private float2 _pfxLocation;

	private uint[] _colors = new uint[7] { 16711680u, 16753920u, 16776960u, 32768u, 255u, 4915330u, 15631086u };

	[NonSerialized]
	public float Radius = 0.64f;

	[NonSerialized]
	public float _startingY;

	private bool isHoming;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_027a: Expected O, but got I
		//IL_04d2: Expected F4, but got I
		//IL_04e5: Expected O, but got I4
		//IL_0514: Expected F4, but got I
		//IL_0527: Expected O, but got I4
		//IL_054e: Expected O, but got I4
		//IL_0567: Expected O, but got Ref
		//IL_0581: Expected native int or pointer, but got O
		//IL_059b: Expected O, but got I
		//IL_05bb: Expected O, but got Ref
		//IL_05d5: Expected native int or pointer, but got O
		//IL_05ef: Expected O, but got I
		//IL_060f: Expected O, but got Ref
		//IL_0637: Expected native int or pointer, but got O
		//IL_0a5d: Expected O, but got I4
		//IL_064f: Expected O, but got Ref
		//IL_0676: Expected O, but got I
		//IL_0690: Expected native int or pointer, but got O
		//IL_0a7a: Expected O, but got I4
		//IL_06c2: Expected O, but got Ref
		//IL_06dc: Expected native int or pointer, but got O
		//IL_0ab4: Expected O, but got I
		//IL_0733: Expected O, but got I
		//IL_0754: Expected O, but got I
		//IL_0897: Expected O, but got I
		//IL_090e: Expected O, but got I
		//IL_0b20: Expected I, but got O
		//IL_0b3a->IL09e5: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		_speed = 0f;
		ArcadeSprite arcadeSprite2 = setAlpha(_startingAlpha);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, null, "UnityCircle");
				if ((object)phaserSprite != null)
				{
					PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0.1f);
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite phaserSprite3 = phaserSprite2.setVisible(visible: false);
						if ((object)phaserSprite3 != null)
						{
							PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Add);
							if ((object)phaserSprite4 != null)
							{
								PhaserSprite phaserSprite5 = phaserSprite4.setTint(255u);
								PhaserScene s_scene2 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null)
								{
									PhaserScene.Renderer renderer = s_scene2._renderer;
									if (s_scene2._renderer != null && (object)phaserSprite5 != null)
									{
										int num = -renderer.pixelHeight;
										PhaserSprite groundFx = phaserSprite5.setDepth(num);
										_groundFx = groundFx;
										GameObject gameObject = new GameObject();
										GameObject.Internal_CreateGameObject(gameObject, (string)null);
										nint num2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rbx_v7 (Il2CppMethodInfo)+38]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
										}
										_ = 0;
										ParticleEmitterManager pfxManager;
										if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192))))
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
											pfxManager = (ParticleEmitterManager)0;
										}
										else
										{
											pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
										}
										_pfxManager = pfxManager;
										Circle circle = new Circle();
										circle._radius = _exploRadius;
										circle._x = 0f;
										_explosionCircle = circle;
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
													((List<object>)(object)list).AddWithResize((object)"HitSmokeA");
												}
												else
												{
													int num3 = list._size + 1;
													list._size = num3;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												}
												int version2 = list._version + 1;
												list._version = version2;
												string[] items2 = list._items;
												if (list._items != null)
												{
													if (list._size >= items2.Length)
													{
														((List<object>)(object)list).AddWithResize((object)"HitSmokeA2");
													}
													else
													{
														int num4 = list._size + 1;
														list._size = num4;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													}
													if (particleSystemConfig != null)
													{
														particleSystemConfig._frame = list;
														float2 float5 = base.position;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
														ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
														particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
														_ = 0;
														float2 float6 = base.position;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C4]");
														minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
														particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
														_ = 0;
														minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
														particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
														_ = 0;
														ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
														_ = 0;
														_ = 0;
														System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
														particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
														_ = 0;
														ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
														_ = 0;
														_ = 0;
														System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
														particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
														_ = 0;
														ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
														particleSystemConfig._angleSteps = 16;
														_ = 0;
														_ = 0;
														System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(50f, 80f));
														particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
														ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
														_ = 0;
														_ = 1;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
														particleSystemConfig._quantity = (int?)(object)0;
														_ = 0;
														_ = 0;
														System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
														_ = 0;
														particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
														_ = 0;
														ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
														_ = 0;
														_ = 0;
														System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.25f, 0f));
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
														_ = 0;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
														particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
														_ = 0;
														_ = 0;
														_ = 1065353216;
														_ = 1;
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
														particleSystemConfig._frequency = (float?)(object)0;
														_ = 1;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
														particleSystemConfig._blendMode = (BlendMode?)(object)0;
														EmitZone emitZone = new EmitZone();
														emitZone._type = EmitZoneType.Random;
														emitZone._source = _explosionCircle;
														particleSystemConfig._emitZone = emitZone;
														particleSystemConfig._on = false;
														if ((object)_pfxManager != null)
														{
															ParticleSystem pfxEmitter = _pfxManager.CreateEmitter(particleSystemConfig);
															_pfxEmitter = pfxEmitter;
															if ((object)_pfxEmitter != null)
															{
																ParticleSystemRenderer component = _pfxEmitter.GetComponent<ParticleSystemRenderer>();
																if ((object)component != null)
																{
																	component.maxParticleSize = 100f;
																	GravityWellConfig gravityWellConfig = new GravityWellConfig();
																	float2 float7 = base.position;
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
																	_ = 0;
																	_ = 1;
																	if (gravityWellConfig != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
																		gravityWellConfig._x = (float?)(object)0;
																		float2 float8 = base.position;
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D4]");
																		float num5 = 0f - 0.19999999f;
																		_ = 1;
																		gravityWellConfig._power = 2f;
																		gravityWellConfig._epsilon = 50f;
																		gravityWellConfig._gravity = 20f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
																		gravityWellConfig._y = (float?)(object)0;
																		if ((object)_pfxManager != null)
																		{
																			GravityWell well = _pfxManager.CreateGravityWell(gravityWellConfig);
																			_well = well;
																			Sprite sprite2 = SpriteManager.GetSprite(_frameNameBeam, "vfx");
																			RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_trail, sprite2, true);
																			Factory trail = (Factory)(object)_trail;
																			if ((object)_trail != null)
																			{
																				bool flag = trail._world == null;
																				Renderer.set_sortingOrder_Injected((IntPtr)trail._world, 1);
																				if ((object)_trail != null)
																				{
																					_trail.emitting = false;
																					TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_trail);
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
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void MakeTrail()
	{
		Sprite sprite = SpriteManager.GetSprite(_frameNameBeam, "vfx");
		RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_trail, sprite, true);
		object trail = _trail;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdi_v3 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdi_v3 (System.Object)+10]");
		Renderer.set_sortingOrder_Injected((IntPtr)0, 1);
		_trail.emitting = false;
		TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_trail);
	}

	private void SetTrailTextureFromIndex()
	{
		//IL_0012: Expected O, but got I8
		//IL_002c: Expected O, but got I8
		int indexInWeapon = _indexInWeapon;
		if (_indexInWeapon <= 6)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rdx_v6+7034CE8+v34 @ rax_v2 (System.Int32)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ rcx_v15 (should have been resolved before IL gen)");
		}
		Sprite sprite = SpriteManager.GetSprite("", "vfx");
		RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_trail, sprite, true);
		uint[] colors = _colors;
		int indexInWeapon2 = _indexInWeapon;
		PhaserSprite phaserSprite = _groundFx.setTint(colors[indexInWeapon2]);
		PhaserSprite phaserSprite2 = _groundFx.setAlpha(1f);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0029: Expected I, but got O
		//IL_0031: Expected I, but got O
		//IL_0041: Expected O, but got I
		//IL_00c1: Expected O, but got I4
		//IL_0016: Expected O, but got I4
		//IL_1023: Expected O, but got I4
		//IL_007d: Expected O, but got I
		//IL_00b3: Expected O, but got I4
		//IL_011d: Expected O, but got I4
		//IL_0195: Expected O, but got I
		//IL_0195: Expected O, but got I
		//IL_020c: Expected I, but got O
		//IL_02e0: Invalid comparison between F4 and I4
		//IL_03a0: Expected F4, but got I
		//IL_10e2: Expected I4, but got O
		//IL_1147: Expected O, but got Ref
		//IL_058c: Expected F4, but got I
		//IL_059a: Expected O, but got Ref
		//IL_079e: Expected O, but got I4
		//IL_07c3: Expected O, but got I
		//IL_09ad: Expected O, but got I
		//IL_0a0f: Expected O, but got I
		//IL_0a39: Expected I, but got O
		//IL_0b96: Expected O, but got I
		//IL_0e51: Expected F4, but got I4
		//IL_0cd8: Expected O, but got I
		//IL_0db6: Expected I4, but got F4
		//IL_126b: Expected O, but got Ref
		//IL_128e: Expected O, but got Ref
		//IL_0f3a: Expected O, but got Ref
		//IL_1179->IL1031: Incompatible stack heights: 1 vs 0
		//IL_11a4->IL10c3: Incompatible stack heights: 1 vs 0
		//IL_0611->IL10c3: Incompatible stack heights: 1 vs 0
		//IL_064c->IL1031: Incompatible stack heights: 1 vs 0
		//IL_067d->IL10c3: Incompatible stack heights: 1 vs 0
		//IL_096f->IL1031: Incompatible stack heights: 1 vs 0
		//IL_09c7->IL1031: Incompatible stack heights: 1 vs 0
		//IL_0ae3->IL1031: Incompatible stack heights: 1 vs 0
		//IL_0b15->IL1031: Incompatible stack heights: 1 vs 0
		//IL_0b37->IL1031: Incompatible stack heights: 1 vs 0
		//IL_0b66->IL1031: Incompatible stack heights: 1 vs 0
		//IL_0def->IL1031: Incompatible stack heights: 1 vs 0
		//IL_0bd9->IL1031: Incompatible stack heights: 1 vs 0
		//IL_0e6e->IL1031: Incompatible stack heights: 1 vs 0
		//IL_0c4f->IL1031: Incompatible stack heights: 1 vs 0
		//IL_0c2d->IL0c2d: Incompatible stack heights: 2 vs 1
		//IL_0ec0->IL1031: Incompatible stack heights: 2 vs 0
		//IL_0c80->IL1031: Incompatible stack heights: 1 vs 0
		//IL_0f02->IL1031: Incompatible stack heights: 2 vs 0
		//IL_12bd->IL1031: Incompatible stack heights: 3 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0ffc;
		}
		nint num = (nint)typeof(PrismaticMissileWeapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v125 (Il2CppClass<VampireSurvivors.Objects.Weapons.PrismaticMissileWeapon>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r9_v26 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v125 (Il2CppClass<VampireSurvivors.Objects.Weapons.PrismaticMissileWeapon>)+130]");
		object obj5;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r9_v26 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v243+FFFFFFF8+v76 @ rax_v238*8]");
			if (0 == (nint)typeof(PrismaticMissileWeapon))
			{
				obj5 = 1;
				goto IL_100b;
			}
		}
		obj5 = 0;
		goto IL_100b;
		IL_0dd5:
		float num5;
		if ((object)_weapon != null)
		{
			float num4 = _weapon.PArea();
			float num7;
			if (num5 > 1f)
			{
				float num6 = num5 - 1f;
				num7 = num6 * 0.16f;
			}
			else
			{
				num7 = 0f;
			}
			float num8 = num7 + 0.64f;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				object obj6 = array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj7 = default(object);
				bool flag = obj7 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					float? targetTransform = (float?)_targetTransform;
					if ((object)_targetTransform != null)
					{
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rbx_v12 (System.Nullable`1<System.Single>)+10]");
						bool flag2 = (nint)0 == 0;
						object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rbx_v12 (System.Nullable`1<System.Single>)+10]");
						Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj8);
						object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-5D]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						if (dictionary != null)
						{
							object value = default(object);
							bool flag3 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_startingY", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							object value2 = default(object);
							bool flag4 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"Radius", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							_ = _fallDuration;
							TweenCallback tweenCallback = delegate
							{
								//IL_008b: Expected I, but got O
								//IL_00ef: Expected O, but got I4
								BaseBody baseBody4 = body;
								baseBody4._enable = true;
								if (_fadeOutTween != null)
								{
									_fadeOutTween.Kill();
								}
								TweenConfig tweenConfig4 = new TweenConfig();
								object[] array4 = new object[1];
								if ((object)_trail != null)
								{
									nint num26 = (nint)array4;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj14 = default(object);
									if (obj14 == null)
									{
										ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
										throw ex;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								tweenConfig4.targets = array4;
								tweenConfig4.duration = 100f;
								tweenConfig4.alpha = (float?)(object)1;
								MultiTargetTween fadeOutTween = Tweens.Add(tweenConfig4);
								_fadeOutTween = fadeOutTween;
								GameManager core4 = GM.Core;
								PlayerOptionsData config3 = core4._playerOptions.Config;
								if (!config3._003CFlashingVFXEnabled_003Ek__BackingField)
								{
									ArcadeSprite arcadeSprite3 = setVisible(visible: false);
								}
							};
							MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
							return;
						}
					}
				}
			}
		}
		goto IL_1031;
		IL_10c3:
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		SetTrailTextureFromIndex();
		int num9 = (int)_trail;
		_updateTicks = 0f;
		if ((object)_trail != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rdi_v12 (System.Int32)+10]");
			if ((nint)0 == 0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_trail);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rdi_v12 (System.Int32)+10]");
				TrailRenderer.Clear_Injected((IntPtr)0);
				if ((object)_trail != null)
				{
					_trail.emitting = false;
					GameManager core = GM.Core;
					if ((object)GM.Core != null && core._playerOptions != null)
					{
						PlayerOptionsData config = core._playerOptions.Config;
						if (config != null)
						{
							TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(alpha: (!config._003CFlashingVFXEnabled_003Ek__BackingField) ? 0.2f : 1f, trail: _trail);
							SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
							_ = 0;
							_ = 1041865114;
							_ = 1;
							soundConfig.Rate = 1f;
							object obj11 = _indexInWeapon - 5;
							float num10 = (float)obj11 * 100f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+5F]");
							soundConfig.Volume = (float?)(object)0;
							soundConfig.Detune = num10;
							float num11 = default(float);
							PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Magic3, soundConfig, 300f, 7, num11);
							if (_fadeInTween != null)
							{
								_fadeInTween.Kill();
							}
							if (_fadeOutTween != null)
							{
								_fadeOutTween.Kill();
							}
							Radius = 0f;
							PhaserSprite phaserSprite = RenderingExtensions.SetScale(_groundFx, 0f);
							if ((object)_pfxEmitter != null)
							{
								Transform component = _pfxEmitter.transform;
								Transform transform = RenderingExtensions.SetScale(component, 1f);
								if (_scaleTween != null)
								{
									_scaleTween.Kill();
								}
								TweenConfig tweenConfig2 = new TweenConfig();
								object[] array2 = new object[1];
								if (array2 != null)
								{
									Transform transform2 = RenderingExtensions.SetScale((Transform)(object)this, 1f);
									bool flag5 = (object)transform2 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig2 != null)
									{
										tweenConfig2.targets = array2;
										_ = 0;
										_ = 0;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+5F]");
										tweenConfig2.alpha = (float?)(object)0;
										if ((object)_weapon != null)
										{
											_ = 0;
											float num12 = _weapon.PArea();
											tweenConfig2.duration = 120f;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+5F]");
											tweenConfig2.scale = (float?)(object)0;
											tweenConfig2.delay = _fallDuration;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2112 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Projectiles.PrismaticMissileProjectile>)+370]");
											TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
											nint num13 = (nint)this;
											tweenConfig2.onComplete = onComplete;
											TweenCallback onUpdate = delegate
											{
												if ((object)_pfxEmitter != null)
												{
													Transform transform4 = _pfxEmitter.transform;
													PrismaticMissileProjectile cachedTransform = (PrismaticMissileProjectile)(object)_cachedTransform;
													if ((object)_cachedTransform != null)
													{
														bool flag15 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
														Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
														bool flag16 = (object)transform4 == null;
														bool flag17 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
														Vector3 value4 = default(Vector3);
														Transform.set_localScale_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value4);
														return;
													}
												}
												throw new NullReferenceException();
											};
											tweenConfig2.onUpdate = onUpdate;
											MultiTargetTween scaleTween = Tweens.Add(tweenConfig2);
											_scaleTween = scaleTween;
											if (_groundFxTween != null)
											{
												_groundFxTween.Kill();
											}
											if ((object)_pfxEmitter != null)
											{
												_pfxEmitter.Stop();
												GameManager core2 = GM.Core;
												if ((object)GM.Core != null && core2._playerOptions != null)
												{
													PlayerOptionsData config2 = core2._playerOptions.Config;
													if (config2 != null)
													{
														bool flag6 = !config2._003CFlashingVFXEnabled_003Ek__BackingField;
														num5 = num10;
														bool flag7 = false;
														Action<float> action = (Action<float>)0;
														if (flag6)
														{
															goto IL_0dd5;
														}
														TweenConfig tweenConfig3 = new TweenConfig();
														object[] array3 = new object[1];
														if (array3 != null)
														{
															if ((object)_groundFx != null)
															{
																int value3 = ((int*)(&array3))->m_value;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj12 = default(object);
																bool flag8 = obj12 == null;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if (tweenConfig3 != null)
															{
																tweenConfig3.targets = array3;
																if ((object)_weapon != null)
																{
																	_ = 0;
																	float num14 = _weapon.PArea();
																	float num15 = num10 * 32f;
																	tweenConfig3.duration = 120f;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+5F]");
																	tweenConfig3.scale = (float?)(object)0;
																	tweenConfig3.delay = _fallDuration;
																	tweenConfig3.yoyo = true;
																	TweenCallback onComplete2 = delegate
																	{
																		PhaserSprite phaserSprite2 = _groundFx.setVisible(visible: false);
																		_pfxEmitter.Stop();
																	};
																	tweenConfig3.onComplete = onComplete2;
																	TweenCallback onStop = delegate
																	{
																		PhaserSprite phaserSprite2 = _groundFx.setVisible(visible: false);
																		_pfxEmitter.Stop();
																	};
																	tweenConfig3.onStop = onStop;
																	MultiTargetTween groundFxTween = Tweens.Add(tweenConfig3);
																	_groundFxTween = groundFxTween;
																	Action onComplete3 = delegate
																	{
																		float2 float9 = base.position;
																		float2 float10 = base.position;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
																		float2 pfxLocation = base.position;
																		_pfxLocation = pfxLocation;
																		Transform transform4 = _pfxEmitter.transform;
																		bool flag15 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
																		Vector3 value4 = default(Vector3);
																		Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value4);
																		RenderingExtensions.Start(_pfxEmitter);
																	};
																	float num16 = _fallDuration * 0.001f;
																	MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																	int repeat = default(int);
																	TimerType type = default(TimerType);
																	Timer timer = Timers.Register(num16, onComplete3, null, isLooped: false, (byte)(int)num11 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																	num5 = num16;
																	flag7 = false;
																	action = null;
																	goto IL_0dd5;
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
		}
		goto IL_1031;
		IL_0ffc:
		_trueWeapon = (PrismaticMissileWeapon)trueWeapon;
		PrismaticMissileWeapon trueWeapon2 = _trueWeapon;
		if ((object)_trueWeapon != null)
		{
			isHoming = trueWeapon2.IsHoming;
			ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
			_ = 0;
			_ = 0;
			_ = 3246391296L;
			_ = 1;
			_ = 3246391296L;
			_ = 1;
			if (body != null)
			{
				BaseBody baseBody = body;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+67]");
				nint num17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+5F]");
				BaseBody baseBody2 = baseBody.setCircle(16f, (float?)(object)num17, (float?)(object)0);
				BaseBody baseBody3 = body;
				if (body != null)
				{
					baseBody3._enable = false;
					Weapon weapon3 = _weapon;
					_isCullable = false;
					if ((object)_weapon != null)
					{
						nint num18 = (nint)weapon3;
						float num19 = _weapon.PSpeed();
						float num20 = default(float);
						bool flag9 = !(1f > num20);
						float num21 = num20;
						if (!flag9)
						{
							num21 = 1f;
						}
						float num22 = _defaultFallDuration / num21;
						bool flag10 = 500f > num22;
						float fallDuration = 500f;
						if (!flag10)
						{
							fallDuration = num22;
						}
						PrismaticMissileWeapon trueWeapon3 = _trueWeapon;
						_fallDuration = fallDuration;
						if ((object)_trueWeapon != null)
						{
							float num23 = trueWeapon3.FiredTimes * 0.5f;
							float num24 = num23 + (float)_indexInWeapon;
							float startingAngle = num24 * _angleUnit;
							_startingAngle = startingAngle;
							if ((object)_trueWeapon != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018703513Ah\"");
								float angleIncrement = ((trueWeapon3.FiredTimes != 0f) ? (-0.25f) : 0.25f);
								_angleIncrement = angleIncrement;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
								float2 float5 = base.position;
								float2 float6 = default(float2);
								base.position = float6;
								Weapon weapon4 = _weapon;
								if ((object)_weapon != null && (object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null)
								{
									float2 float7 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.position;
									Weapon weapon5 = _weapon;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+5F]");
									_startingX = 0f;
									if ((object)_weapon != null && (object)((Equipment)weapon5)._003COwner_003Ek__BackingField != null)
									{
										float2 float8 = ((Equipment)weapon5)._003COwner_003Ek__BackingField.position;
										PhaserScene s_scene = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null)
										{
											PhaserScene.Renderer renderer = s_scene._renderer;
											if (s_scene._renderer != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+63]");
												float startingY = 0f + renderer.height;
												Weapon weapon6 = _weapon;
												_startingY = startingY;
												if ((object)_weapon != null && (object)((Equipment)weapon6)._003COwner_003Ek__BackingField != null)
												{
													Transform targetTransform2 = ((Equipment)weapon6)._003COwner_003Ek__BackingField.transform;
													_targetTransform = targetTransform2;
													if (!isHoming)
													{
														goto IL_10c3;
													}
													GameManager core3 = GM.Core;
													if ((object)GM.Core != null && (object)weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
													{
														Transform transform3 = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
														if ((object)transform3 != null)
														{
															_ = 0;
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v205 (UnityEngine.Transform)+10]");
															bool flag11 = (nint)0 == 0;
															object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v205 (UnityEngine.Transform)+10]");
															Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj13);
															if ((object)core3._stage != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-61]");
																startingY = 0f;
																Vector3 queryPos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-61]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-59]");
																_ = 0;
																EnemyController enemyController = core3._stage.FindClosestEnemy(queryPos);
																bool flag12 = (object)enemyController == null;
																float num25 = 3.4028235E+38f;
																if (!flag12)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1846 @ rax_v212 (VampireSurvivors.Objects.Characters.EnemyController)+10]");
																	bool flag13 = (nint)0 == 0;
																	num25 = 3.4028235E+38f;
																	if (!flag13)
																	{
																		Transform targetTransform3 = enemyController.transform;
																		_targetTransform = targetTransform3;
																		if ((object)_targetTransform == null)
																		{
																			goto IL_1031;
																		}
																		_startingX = _targetTransform.position.x;
																		num25 = 3.4028235E+38f;
																	}
																}
																goto IL_10c3;
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
		goto IL_1031;
		IL_1031:
		throw new NullReferenceException();
		IL_100b:
		bool flag14 = obj5 == null;
		trueWeapon = (float?)(object)0;
		if (!flag14)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0ffc;
	}

	public void BeforeDespawn()
	{
		//IL_00bb: Expected O, but got I4
		//IL_00ee: Expected I, but got O
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float2 float5 = base.position;
			float2 float6 = base.position;
			float2 pos = default(float2);
			Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
		_trail.emitting = false;
		TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(_trail, 0f);
		BaseBody baseBody = body;
		baseBody._enable = false;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.PrismaticMissileProjectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public override void Despawn()
	{
		PrismaticMissileWeapon trueWeapon = _trueWeapon;
		if (trueWeapon.FirstArcana == ArcanaType.T02_TWILIGHT && trueWeapon._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile = trueWeapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
		base.Despawn();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0266->IL01da: Incompatible stack heights: 1 vs 0
		bool flag = ++_updateTicks < 2f;
		IntPtr intPtr = default(IntPtr);
		bool flag2 = (byte)(nint)intPtr != 0;
		TrailRenderer trailRenderer = (TrailRenderer)(object)this;
		if (!flag)
		{
			ArcadeSprite arcadeSprite = setAlpha(1f);
			trailRenderer = _trail;
			if ((object)_trail == null)
			{
				goto IL_018d;
			}
			_trail.emitting = true;
			flag2 = true;
		}
		float startingAngle = _angleIncrement + _startingAngle;
		_startingAngle = startingAngle;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		if (isHoming)
		{
			Transform targetTransform = _targetTransform;
			if ((object)_targetTransform != null && ((UnityEngine.Object)targetTransform).m_CachedPtr != (IntPtr)0)
			{
				Transform targetTransform2 = _targetTransform;
				if ((object)_targetTransform == null)
				{
					goto IL_018d;
				}
				bool flag3 = ((UnityEngine.Object)targetTransform2).m_CachedPtr == (IntPtr)0;
				float ret;
				Transform.get_position_Injected(((UnityEngine.Object)targetTransform2).m_CachedPtr, out *(Vector3*)(&ret));
				_startingX = ret;
			}
		}
		float2 float5 = default(float2);
		base.position = float5;
		if ((object)_pfxEmitter != null)
		{
			Transform transform = _pfxEmitter.transform;
			bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			float2 value = default(float2);
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
			Transform transform2 = _well.transform;
			float2 float6 = base.position;
			float2 float7 = base.position;
			bool flag5 = (object)transform2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v718 @ rax_v33 (UnityEngine.Transform)+10]");
			bool flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v718 @ rax_v33 (UnityEngine.Transform)+10]");
			float2 value2 = default(float2);
			Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value2));
			return;
		}
		goto IL_018d;
		IL_018d:
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		PrismaticMissileWeapon trueWeapon = _trueWeapon;
		if (trueWeapon.FirstArcana != ArcanaType.T19_FIRE)
		{
			if (trueWeapon.FirstArcana == ArcanaType.T14_JEWELS)
			{
				bool flag = TryFreeze(target);
			}
		}
		else
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}

	private void _003CInitProjectile_003Eb__34_1()
	{
		if ((object)_pfxEmitter != null)
		{
			Transform transform = _pfxEmitter.transform;
			PrismaticMissileProjectile cachedTransform = (PrismaticMissileProjectile)(object)_cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void _003CInitProjectile_003Eb__34_2()
	{
		PhaserSprite phaserSprite = _groundFx.setVisible(visible: false);
		_pfxEmitter.Stop();
	}

	private void _003CInitProjectile_003Eb__34_3()
	{
		PhaserSprite phaserSprite = _groundFx.setVisible(visible: false);
		_pfxEmitter.Stop();
	}

	private void _003CInitProjectile_003Eb__34_0()
	{
		float2 float5 = base.position;
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 pfxLocation = base.position;
		_pfxLocation = pfxLocation;
		Transform transform = _pfxEmitter.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		RenderingExtensions.Start(_pfxEmitter);
	}

	private void _003CInitProjectile_003Eb__34_4()
	{
		//IL_008b: Expected I, but got O
		//IL_00ef: Expected O, but got I4
		BaseBody baseBody = body;
		baseBody._enable = true;
		if (_fadeOutTween != null)
		{
			_fadeOutTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_trail != null)
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
		MultiTargetTween fadeOutTween = Tweens.Add(tweenConfig);
		_fadeOutTween = fadeOutTween;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			ArcadeSprite arcadeSprite = setVisible(visible: false);
		}
	}
}
