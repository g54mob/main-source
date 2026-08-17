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
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class BoraProjectile : Projectile
{
	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _pfxEmitter1;

	private ParticleSystem _pfxEmitter2;

	private MultiTargetTween _angleTween;

	private MultiTargetTween _positionTween;

	private PhaserSprite _GroundFx;

	private ParticleEmitterManager _pfxEmitterExplosionManager;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	private Timer _despawnTimer;

	private float _radius = 16f;

	private float _exploRadius;

	private bool _isBroken;

	private float _groundFxAlpha;

	private Vector2 _currentDirection;

	private Circle _explosionCircle;

	private MultiTargetTween _fadeOutTween;

	private MultiTargetTween _scaleGroundTween;

	private MultiTargetTween _growTween;

	private Timer _chooseTimer;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00e3: Expected O, but got I4
		//IL_033b: Expected O, but got Ref
		//IL_0355: Expected native int or pointer, but got O
		//IL_036d: Expected O, but got Ref
		//IL_03a6: Expected native int or pointer, but got O
		//IL_03f7: Expected O, but got Ref
		//IL_0411: Expected native int or pointer, but got O
		//IL_0443: Expected O, but got Ref
		//IL_045d: Expected native int or pointer, but got O
		//IL_06d8: Expected O, but got Ref
		//IL_06f2: Expected native int or pointer, but got O
		//IL_0730: Expected O, but got Ref
		//IL_0763: Expected native int or pointer, but got O
		//IL_07b4: Expected O, but got Ref
		//IL_07ce: Expected native int or pointer, but got O
		//IL_0806: Expected O, but got Ref
		//IL_0820: Expected native int or pointer, but got O
		//IL_099e: Expected O, but got Ref
		//IL_09d7: Expected native int or pointer, but got O
		//IL_0a28: Expected O, but got Ref
		//IL_0a42: Expected native int or pointer, but got O
		//IL_0aac: Expected O, but got Ref
		//IL_0ac6: Expected native int or pointer, but got O
		//IL_0bdb: Expected O, but got Ref
		//IL_0c0e: Expected native int or pointer, but got O
		//IL_0c5f: Expected O, but got Ref
		//IL_0c79: Expected native int or pointer, but got O
		//IL_0ce3: Expected O, but got Ref
		//IL_0cfd: Expected native int or pointer, but got O
		//IL_0e36: Expected I, but got O
		//IL_0f2f->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_00cb->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_00ff->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_013d->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_0199->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_01e8->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_029c->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_031e->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_04d2->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_0536->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_0585->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_0639->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_06bb->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_08b4->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_08ff->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_095b->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_0986->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_0b3d->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_0b92->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_0bbd->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_0d79->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_0dcd->IL0e92: Incompatible stack heights: 1 vs 0
		//IL_0e24->IL0e92: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		_speed = 2f;
		Circle circle = new Circle();
		circle._radius = _exploRadius;
		circle._x = 0f;
		_explosionCircle = circle;
		if ((object)_GroundFx != null)
		{
			Transform transform = _GroundFx.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v688 @ rcx_v15 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
				if ((object)_GroundFx != null)
				{
					PhaserSprite phaserSprite = _GroundFx.setVisible(visible: false);
					if ((object)phaserSprite != null)
					{
						PhaserSprite phaserSprite2 = phaserSprite.setScale(0f, (float?)(object)0);
						if ((object)phaserSprite2 != null)
						{
							PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0f);
							GameObject gameObject = base.gameObject;
							if ((object)gameObject != null)
							{
								ParticleEmitterManager pfxEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
								_pfxEmitterManager = pfxEmitterManager;
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
											((List<object>)(object)list).AddWithResize((object)"ProjectileFlameHoly2");
										}
										else
										{
											int num2 = list._size + 1;
											list._size = num2;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										int version2 = list._version + 1;
										list._version = version2;
										string[] items2 = list._items;
										if (list._items != null)
										{
											if (list._size >= items2.Length)
											{
												((List<object>)(object)list).AddWithResize((object)"ProjectileFlameBlue2");
											}
											else
											{
												int num3 = list._size + 1;
												list._size = num3;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											}
											if (particleSystemConfig != null)
											{
												ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(1f, 1f));
												_ = 1;
												ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
												_ = 0;
												_ = 1;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+300]");
												_ = 0;
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(90f, 90f));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+110]");
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(600f);
												_ = 0;
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+120]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+130]");
												_ = 0;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.25f, 1f));
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+140]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+150]");
												_ = 0;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
												_ = 0;
												EmitZone emitZone = new EmitZone
												{
													_type = EmitZoneType.Random,
													_source = _explosionCircle
												};
												_ = 0;
												if ((object)_pfxEmitterManager != null)
												{
													ParticleSystem pfxEmitter = _pfxEmitterManager.CreateEmitter(particleSystemConfig);
													_pfxEmitter1 = pfxEmitter;
													ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
													List<string> list2 = new List<string>();
													if (list2 != null)
													{
														int version3 = list2._version + 1;
														list2._version = version3;
														string[] items3 = list2._items;
														if (list2._items != null)
														{
															if (list2._size >= items3.Length)
															{
																((List<object>)(object)list2).AddWithResize((object)"ProjectileFlameHoly2");
															}
															else
															{
																int num4 = list2._size + 1;
																list2._size = num4;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															int version4 = list2._version + 1;
															list2._version = version4;
															string[] items4 = list2._items;
															if (list2._items != null)
															{
																if (list2._size >= items4.Length)
																{
																	((List<object>)(object)list2).AddWithResize((object)"ProjectileFlameBlue2");
																}
																else
																{
																	int num5 = list2._size + 1;
																	list2._size = num5;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																}
																if (particleSystemConfig2 != null)
																{
																	ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
																	_ = 0;
																	_ = 0;
																	System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 1f));
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+160]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+170]");
																	_ = 0;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
																	_ = 0;
																	_ = 0;
																	ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 384));
																	_ = 1;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+300]");
																	_ = 0;
																	_ = 0;
																	_ = 0;
																	System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(90f, 90f));
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+180]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+190]");
																	_ = 0;
																	minMaxCurve3 = new ParticleSystem.MinMaxCurve(600f);
																	_ = 0;
																	_ = 0;
																	ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 416));
																	_ = 0;
																	_ = 0;
																	System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0.2f, 0f));
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1A0]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1B0]");
																	_ = 0;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-10]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
																	_ = 0;
																	ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 448));
																	_ = 0;
																	_ = 0;
																	System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0.25f, 0.5f));
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1C0]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1D0]");
																	_ = 0;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
																	_ = 0;
																	_ = 0;
																	_ = 1;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+300]");
																	_ = 0;
																	EmitZone emitZone2 = new EmitZone
																	{
																		_type = EmitZoneType.Random,
																		_source = _explosionCircle
																	};
																	_ = 0;
																	if ((object)_pfxEmitterManager != null)
																	{
																		ParticleSystem pfxEmitter2 = _pfxEmitterManager.CreateEmitter(particleSystemConfig2);
																		_pfxEmitter2 = pfxEmitter2;
																		GameObject gameObject2 = base.gameObject;
																		if ((object)gameObject2 != null)
																		{
																			ParticleEmitterManager pfxEmitterExplosionManager = gameObject2.AddComponent<ParticleEmitterManager>();
																			_pfxEmitterExplosionManager = pfxEmitterExplosionManager;
																			ParticleSystemConfig particleSystemConfig3 = new ParticleSystemConfig("vfx");
																			List<string> list3 = new List<string>();
																			if (list3 != null)
																			{
																				list3.Add("HitCloud2");
																				if (particleSystemConfig3 != null)
																				{
																					ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 480));
																					_ = 0;
																					_ = 1;
																					_ = 1;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+300]");
																					_ = 0;
																					_ = 0;
																					_ = 0;
																					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(0f, 360f));
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1E0]");
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1F0]");
																					_ = 0;
																					minMaxCurve3 = new ParticleSystem.MinMaxCurve(150f);
																					_ = 0;
																					_ = 0;
																					ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 512));
																					_ = 0;
																					_ = 0;
																					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(1f, 0.5f));
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+200]");
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+210]");
																					_ = 0;
																					_ = 1;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+50]");
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
																					_ = 0;
																					ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 544));
																					_ = 0;
																					_ = 0;
																					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(0.25f, 2f));
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+220]");
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+230]");
																					_ = 0;
																					_ = 1;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+68]");
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+78]");
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+88]");
																					_ = 0;
																					_ = 0;
																					if ((object)_pfxEmitterExplosionManager != null)
																					{
																						ParticleSystem particleSystem = _pfxEmitterExplosionManager.CreateEmitter(particleSystemConfig3);
																						ParticleSystemConfig particleSystemConfig4 = new ParticleSystemConfig("vfx");
																						List<string> list4 = new List<string>();
																						if (list4 != null)
																						{
																							list4.Add("HitCloud1");
																							if (particleSystemConfig4 != null)
																							{
																								_ = 0;
																								ParticleSystem.MinMaxCurve minMaxCurve13 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 576));
																								_ = 3;
																								_ = 1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+300]");
																								_ = 0;
																								_ = 0;
																								_ = 0;
																								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve13, new ParticleSystem.MinMaxCurve(0f, 360f));
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+240]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+250]");
																								_ = 0;
																								minMaxCurve3 = new ParticleSystem.MinMaxCurve(150f);
																								_ = 0;
																								_ = 0;
																								ParticleSystem.MinMaxCurve minMaxCurve14 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 608));
																								_ = 0;
																								_ = 0;
																								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve14, new ParticleSystem.MinMaxCurve(1f, 0.5f));
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+260]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+270]");
																								_ = 0;
																								_ = 1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+90]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
																								_ = 0;
																								ParticleSystem.MinMaxCurve minMaxCurve15 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 640));
																								_ = 0;
																								_ = 0;
																								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve15, new ParticleSystem.MinMaxCurve(0.25f, 1f));
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+280]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+290]");
																								_ = 0;
																								_ = 1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B8]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C8]");
																								_ = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D8]");
																								_ = 0;
																								_ = 0;
																								if ((object)_pfxEmitterExplosionManager != null)
																								{
																									ParticleSystem particleSystem2 = _pfxEmitterExplosionManager.CreateEmitter(particleSystemConfig4);
																									TweenConfig tweenConfig = new TweenConfig();
																									object[] array = new object[1];
																									if (array != null)
																									{
																										void* value = ((IntPtr*)(&array))->m_value;
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																										object obj3 = default(object);
																										bool flag2 = obj3 == null;
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																										if (tweenConfig != null)
																										{
																											((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
																											_ = 0;
																											_ = 1142292480;
																											_ = 1;
																											_ = 4294967295L;
																											_ = 1135869952;
																											_ = 1;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+300]");
																											_ = 0;
																											MultiTargetTween angleTween = Tweens.Add(tweenConfig);
																											_angleTween = angleTween;
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
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0064: Expected O, but got I4
		//IL_01b9: Expected O, but got I4
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected I4, but got Unknown
		//IL_0a1f: Expected O, but got F4
		//IL_0432: Expected I4, but got O
		//IL_043d: Expected I4, but got O
		//IL_0459: Expected I, but got O
		//IL_0476: Expected O, but got I
		//IL_04b2: Expected O, but got I
		//IL_04ef: Expected O, but got I
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Expected O, but got Unknown
		//IL_0bbb: Expected O, but got I
		//IL_0bfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c02: Expected O, but got Unknown
		//IL_0c1f: Expected O, but got I
		//IL_0545: Expected I4, but got O
		//IL_057d: Expected O, but got I
		//IL_0ae0: Expected O, but got F4
		//IL_059d->IL0981: Incompatible stack heights: 1 vs 0
		//IL_05e9->IL0981: Incompatible stack heights: 2 vs 0
		//IL_068b->IL0981: Incompatible stack heights: 2 vs 0
		//IL_06a9->IL0981: Incompatible stack heights: 2 vs 0
		//IL_0a74->IL0981: Incompatible stack heights: 2 vs 0
		//IL_07c7->IL0981: Incompatible stack heights: 2 vs 0
		//IL_0b79->IL0981: Incompatible stack heights: 2 vs 0
		//IL_080d->IL0981: Incompatible stack heights: 2 vs 0
		//IL_0724->IL0981: Incompatible stack heights: 2 vs 0
		//IL_08c6->IL0981: Incompatible stack heights: 2 vs 0
		//IL_0ad7->IL0a50: Incompatible stack heights: 3 vs 2
		//IL_0918->IL0981: Incompatible stack heights: 3 vs 0
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		float num = _radius * -0.5f;
		float num2 = _radius * -0.5f;
		_speed = 2f;
		float num3;
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(_radius, (float?)(object)1, (float?)(object)1);
			if (_growTween != null)
			{
				_growTween.Kill();
			}
			ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
			ArcadeSprite arcadeSprite3 = setVisible(visible: true);
			BaseBody baseBody2 = body;
			_isBroken = false;
			if (body != null)
			{
				baseBody2._enable = false;
				_isCullable = false;
				if (_hitboxTimer != null)
				{
					_hitboxTimer.Cancel();
				}
				if (_expireTimer != null)
				{
					_expireTimer.Cancel();
				}
				if (_despawnTimer != null)
				{
					_despawnTimer.Cancel();
				}
				if ((object)_GroundFx != null)
				{
					PhaserSprite phaserSprite = _GroundFx.setVisible(visible: false);
					if ((object)phaserSprite != null)
					{
						PhaserSprite phaserSprite2 = phaserSprite.setScale(0f, (float?)(object)0);
						if ((object)phaserSprite2 != null)
						{
							PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0f);
							Weapon weapon2 = _weapon;
							if ((object)_weapon != null)
							{
								num3 = (float)((Equipment)weapon2)._003CLevel_003Ek__BackingField / 3f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
								object obj = default(object);
								int num4 = obj + 1;
								bool flag = num4 >= 10;
								int quantity = 10;
								if (!flag)
								{
									quantity = num4;
								}
								if ((object)_weapon != null)
								{
									float num5 = _weapon.PArea();
									Circle circle = new Circle();
									float num6 = num3 * _exploRadius;
									circle._x = 0f;
									float radius = num6 * 3f;
									circle._radius = radius;
									_explosionCircle = circle;
									EmitZone emitZone = new EmitZone();
									emitZone._type = EmitZoneType.Random;
									emitZone._source = _explosionCircle;
									RenderingExtensions.SetEmitZone(_pfxEmitter1, emitZone);
									RenderingExtensions.SetQuantity(_pfxEmitter1, quantity);
									EmitZone emitZone2 = new EmitZone();
									emitZone2._type = EmitZoneType.Random;
									emitZone2._source = _explosionCircle;
									RenderingExtensions.SetEmitZone(_pfxEmitter2, emitZone2);
									RenderingExtensions.SetQuantity(_pfxEmitter2, quantity);
									if ((object)weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
									{
										float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
										object obj2 = UnityEngine.Random.value;
										PhaserScene s_scene = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
										{
											PhaserScene s_scene2 = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
											{
												float2 float6 = default(float2);
												base.position = float6;
												bool flag2 = (byte)(int)_weapon != 0;
												if ((int)(~_weapon) == 0)
												{
													nint num7 = (nint)typeof(BoraWeapon);
													bool value = ((bool*)(flag2 ? 1 : 0))->m_value;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rdx_v34 (Il2CppClass<VampireSurvivors.Objects.Weapons.BoraWeapon>)+130]");
													object obj3 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ r8_v25 (System.Boolean)+130]");
													nint num8 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rdx_v34 (Il2CppClass<VampireSurvivors.Objects.Weapons.BoraWeapon>)+130]");
													if (num8 >= 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ r8_v25 (System.Boolean)+C8]");
														object obj4 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v64+FFFFFFF8+v245 @ rax_v63*8]");
														if (0 == (nint)typeof(BoraWeapon))
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rdx_v34 (Il2CppClass<VampireSurvivors.Objects.Weapons.BoraWeapon>)+130]");
															object obj5 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v64+FFFFFFF8+v1459 @ rcx_v52*8]");
															object obj6 = 0 - typeof(BoraWeapon);
															bool flag3 = obj6 == null;
															bool flag4 = !flag3;
															int num9 = 0;
															if (!flag4)
															{
																num9 = (int)_weapon;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdi_v13 (System.Int32)+168]");
															object obj7 = (nint)0 + (nint)1;
															Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
															object obj8 = (object)typeof(BoraWeapon) >> 1;
															object obj9 = obj8 >> 31;
															object obj10 = obj8 + obj9;
															object obj11 = obj10 * 2;
															object obj12 = obj10 + obj11;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdi_v13 (System.Int32)+160]");
															object obj13 = 0;
															object obj14 = obj12 << 2;
															object obj15 = obj7 - obj14;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdi_v13 (System.Int32)+160]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v37+18]");
																bool flag5 = (nint)obj15 >= 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v37+10]");
																object obj16 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v37+10]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rdx_v38+18]");
																	bool flag6 = (nint)obj15 >= 0;
																	Weapon weapon3 = _weapon;
																	if ((object)_weapon != null)
																	{
																		if (!weapon3.IsHoming)
																		{
																			float num10 = _weapon.PAmount();
																			if (!(4f > num3) || _indexInWeapon != 0)
																			{
																				goto IL_0a50;
																			}
																		}
																		Weapon weapon4 = _weapon;
																		if ((object)_weapon != null && (object)GM.Core != null)
																		{
																			Transform transform = GM.Core.FindClosestEnemyToPlayer(((Equipment)weapon4)._003COwner_003Ek__BackingField);
																			if ((object)transform != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1627 @ rax_v128 (UnityEngine.Transform)+10]");
																				if ((nint)0 != 0)
																				{
																					Transform transform2 = transform.transform;
																					if ((object)transform2 == null)
																					{
																						goto IL_0981;
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rax_v134 (UnityEngine.Transform)+10]");
																					bool flag7 = (nint)0 == 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rax_v134 (UnityEngine.Transform)+10]");
																					Transform.get_position_Injected((IntPtr)0, out Vector3 _);
																				}
																			}
																			goto IL_0a50;
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
		goto IL_0981;
		IL_0a50:
		Weapon weapon5 = _weapon;
		if ((object)_weapon != null)
		{
			if (weapon5.IsHoming)
			{
				if (_chooseTimer != null)
				{
					_chooseTimer.Cancel();
				}
				object obj17 = UnityEngine.Random.value;
				Action onComplete = GoTowardsNearestEnemyToOwner;
				float num11 = num3 * 250f;
				float num12 = num11 + 1000f;
				float num13 = num12 * 0.001f;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer chooseTimer = Timers.Register(num13, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_chooseTimer = chooseTimer;
				bool flag2 = true;
				num3 = num13;
			}
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				float2 float7 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer = s_scene3._renderer;
					if (s_scene3._renderer != null)
					{
						float2 float8 = base.position;
						float num14 = num2 + renderer.height;
						float num15 = num14 - num;
						float num16 = num15 * 100f;
						ArcadeSprite arcadeSprite4 = setDepth(num16);
						if (_positionTween != null)
						{
							_positionTween.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if (array != null)
						{
							object obj18 = array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj19 = default(object);
							bool flag8 = obj19 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								_ = 1;
								_ = 1133903872;
								_ = 1;
								_ = 1;
								TweenCallback tweenCallback = delegate
								{
									Break();
								};
								MultiTargetTween positionTween = Tweens.Add(tweenConfig);
								_positionTween = positionTween;
								return;
							}
						}
					}
				}
			}
		}
		goto IL_0981;
		IL_0981:
		throw new NullReferenceException();
	}

	public unsafe void GoTowardsNearestEnemyToOwner()
	{
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Expected O, but got Unknown
		//IL_0115: Expected O, but got F4
		while (true)
		{
			Transform nearestEnemyTransform = base.GetNearestEnemyTransform();
			if ((object)nearestEnemyTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v3 (UnityEngine.Transform)+10]");
				if ((nint)0 == 0)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v3 (UnityEngine.Transform)+10]");
				if ((nint)0 != 0)
				{
					break;
				}
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(nearestEnemyTransform);
				continue;
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v3 (UnityEngine.Transform)+10]");
		Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
		float2 float5 = base.position;
		Vector2 vector = (Vector2)(this + 304);
		Vector2 currentDirection = (Vector2)((object)ret - (object)float5);
		object obj = default(object);
		object obj2 = default(object);
		float num = (float)obj - (float)obj2;
		_currentDirection = currentDirection;
		((Vector2*)vector)->Normalize();
		Weapon weapon = _weapon;
		float num2 = ((Equipment)weapon)._003COwner_003Ek__BackingField.PMoveSpeed();
		bool flag = !(num > 1f);
		float num3 = 1f;
		if (!flag)
		{
			Weapon weapon2 = _weapon;
			float num4 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.PMoveSpeed();
			num3 = num;
		}
		float num5 = (float)_currentDirection * 15f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.BoraProjectile)+134]");
		float num6 = 0f * 15f;
		float num7 = num5 * num3;
		float num8 = num6 * num3;
		float num9 = _weapon.PSpeed();
		float num10 = num7 * num;
		float num11 = num8 * num;
		float num12 = num10 * 0.01f;
		float num13 = num11 * 0.01f;
		BaseBody baseBody = body;
		baseBody._velocity = (float2)num12;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_019d: Invalid comparison between O and F4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_02aa: Expected O, but got F4
		//IL_0222: Expected F4, but got O
		//IL_040a->IL0324: Incompatible stack heights: 3 vs 0
		if (!_isBroken)
		{
			return;
		}
		float2 float5 = base.position;
		if ((object)_pfxEmitterManager != null)
		{
			Vector2 vector = default(Vector2);
			_pfxEmitterManager.EmitParticleAt(vector);
			Weapon weapon = _weapon;
			if ((object)_weapon != null)
			{
				bool flag = weapon.IsHoming;
				Vector2 vector2 = vector;
				if (!flag)
				{
					if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField == null)
					{
						goto IL_031d;
					}
					float2 float6 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
					float2 float7 = base.position;
					Vector2 vector3 = (Vector2)(this + 304);
					Vector2 currentDirection = float6 - float7;
					Vector2 vector4 = default(Vector2);
					object obj = default(object);
					vector2 = (Vector2)((object)vector4 - obj);
					_currentDirection = currentDirection;
					((Vector2*)vector3)->Normalize();
				}
				Weapon weapon2 = _weapon;
				if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
				{
					float num = ((Equipment)weapon2)._003COwner_003Ek__BackingField.PMoveSpeed();
					bool flag2 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
					float num2 = 1f;
					if (!flag2)
					{
						Weapon weapon3 = _weapon;
						if ((object)_weapon == null || (object)((Equipment)weapon3)._003COwner_003Ek__BackingField == null)
						{
							goto IL_031d;
						}
						float num3 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.PMoveSpeed();
						num2 = (float)vector2;
					}
					float num4 = (float)_currentDirection * 15f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.BoraProjectile)+134]");
					float num5 = 0f * 15f;
					float num6 = num4 * num2;
					float num7 = num5 * num2;
					if ((object)_weapon != null)
					{
						float num8 = _weapon.PSpeed();
						float num9 = num6 * (float)vector2;
						float num10 = num7 * (float)vector2;
						float num11 = num9 * 0.01f;
						float num12 = num10 * 0.01f;
						BaseBody baseBody = body;
						if (body != null)
						{
							baseBody._velocity = (float2)num11;
							if ((object)_GroundFx != null)
							{
								Transform transform = _GroundFx.transform;
								Transform transform2 = base.transform;
								if ((object)transform2 != null)
								{
									bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
									bool flag4 = (object)transform == null;
									bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Vector3 value = default(Vector3);
									Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_031d;
		IL_031d:
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		_isCullable = true;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		if (_positionTween != null)
		{
			_positionTween.Kill();
		}
		if (_scaleGroundTween != null)
		{
			_scaleGroundTween.Kill();
		}
		if (_growTween != null)
		{
			_growTween.Kill();
		}
		BaseBody baseBody = body;
		baseBody._enable = false;
		base.Despawn();
	}

	private unsafe void Break()
	{
		//IL_0038: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		//IL_01e3: Expected I, but got O
		//IL_0289: Expected O, but got I4
		//IL_030f: Expected O, but got I4
		//IL_043c: Expected I, but got O
		//IL_04a6: Expected O, but got I4
		//IL_062e: Expected O, but got F4
		//IL_0687: Expected O, but got I4
		//IL_0699: Unsupported input type for neg.
		//IL_0699: Unknown result type (might be due to invalid IL or missing references)
		//IL_069e: Expected O, but got Unknown
		//IL_0738: Expected O, but got I4
		//IL_0764: Expected O, but got I4
		//IL_0792: Expected F4, but got I4
		//IL_018d->IL079b: Incompatible stack heights: 1 vs 0
		//IL_01b9->IL079b: Incompatible stack heights: 1 vs 0
		//IL_0228->IL079b: Incompatible stack heights: 1 vs 0
		//IL_0206->IL0206: Incompatible stack heights: 2 vs 1
		//IL_0259->IL079b: Incompatible stack heights: 1 vs 0
		//IL_02ec->IL079b: Incompatible stack heights: 1 vs 0
		//IL_032d->IL079b: Incompatible stack heights: 1 vs 0
		//IL_0410->IL079b: Incompatible stack heights: 1 vs 0
		//IL_0481->IL079b: Incompatible stack heights: 1 vs 0
		//IL_045f->IL045f: Incompatible stack heights: 2 vs 1
		//IL_04c0->IL079b: Incompatible stack heights: 1 vs 0
		//IL_050b->IL079b: Incompatible stack heights: 1 vs 0
		//IL_0577->IL079b: Incompatible stack heights: 1 vs 0
		//IL_0615->IL079b: Incompatible stack heights: 1 vs 0
		//IL_0844->IL079b: Incompatible stack heights: 1 vs 0
		//IL_065d->IL079b: Incompatible stack heights: 1 vs 0
		//IL_06c2->IL079b: Incompatible stack heights: 1 vs 0
		//IL_06f4->IL079b: Incompatible stack heights: 1 vs 0
		//IL_079b->IL0849: Incompatible stack heights: 1 vs 0
		if (_isBroken)
		{
			return;
		}
		_isBroken = true;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		BaseBody baseBody = body;
		if (body != null)
		{
			_ = 0;
			baseBody._velocity = (float2)0;
			if (_objectsHit != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
				BaseBody baseBody2 = body;
				if (body != null)
				{
					baseBody2._enable = true;
					if ((object)_GroundFx != null)
					{
						Transform transform = _GroundFx.transform;
						float2 float5 = base.position;
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						float value = default(float);
						Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
						PhaserSprite phaserSprite = _GroundFx.setVisible(visible: true);
						PhaserSprite phaserSprite2 = phaserSprite.setScale(0f, (float?)(object)0);
						PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(_groundFxAlpha);
						if (_scaleGroundTween != null)
						{
							_scaleGroundTween.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if ((object)_GroundFx != null)
						{
							Transform transform2 = _GroundFx.transform;
							if (array != null)
							{
								if ((object)transform2 != null)
								{
									nint num = (nint)array;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj = default(object);
									bool flag2 = obj == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig != null)
								{
									tweenConfig.targets = array;
									if ((object)_weapon != null)
									{
										float num2 = _weapon.PArea();
										tweenConfig.duration = 200f;
										tweenConfig.scale = (float?)(object)1;
										TweenCallback onComplete = delegate
										{
											//IL_0101: Expected I, but got O
											//IL_016b: Expected I, but got O
											//IL_01c1: Expected O, but got I4
											Weapon weapon = _weapon;
											float num14 = ((Equipment)weapon)._003COwner_003Ek__BackingField.PMoveSpeed();
											float num15 = default(float);
											bool flag5 = !(num15 > 1f);
											float num16 = 1f;
											if (!flag5)
											{
												Weapon weapon2 = _weapon;
												float num17 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.PMoveSpeed();
												num16 = num15;
											}
											float num18 = _weapon.PArea();
											float num19 = _weapon.PSpeed();
											float num20 = num15 * num16;
											float num21 = num15 * num20;
											if (!(num21 > 12f) || _growTween != null)
											{
												_growTween.Kill();
											}
											TweenConfig tweenConfig3 = new TweenConfig();
											object[] array3 = new object[2];
											nint num22 = (nint)array3;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj7 = default(object);
											if (obj7 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												Transform transform3 = _GroundFx.transform;
												if ((object)transform3 != null)
												{
													nint num23 = (nint)array3;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													object obj8 = default(object);
													if (obj8 == null)
													{
														ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
														throw ex;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												tweenConfig3.targets = array3;
												tweenConfig3.scale = (float?)(object)1;
												float num24 = _weapon.PDuration();
												float duration2 = num21 - 200f;
												tweenConfig3.duration = duration2;
												MultiTargetTween growTween = Tweens.Add(tweenConfig3);
												_growTween = growTween;
												return;
											}
											ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
											throw ex2;
										};
										tweenConfig.onComplete = onComplete;
										MultiTargetTween scaleGroundTween = Tweens.Add(tweenConfig);
										_scaleGroundTween = scaleGroundTween;
										if ((object)_weapon != null)
										{
											float num3 = _weapon.PArea();
											float num4 = default(float);
											ArcadeSprite arcadeSprite2 = setScale(num4, (float?)(object)0);
											if ((object)_weapon != null)
											{
												float hitBoxDelay = _weapon.HitBoxDelay;
												Action onComplete2 = delegate
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
												};
												float num5 = hitBoxDelay * 0.001f;
												bool flag3 = default(bool);
												MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
												int repeat = default(int);
												TimerType type = default(TimerType);
												Timer hitboxTimer = Timers.Register(num5, onComplete2, null, isLooped: true, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
												_hitboxTimer = hitboxTimer;
												if (_fadeOutTween != null)
												{
													_fadeOutTween.Kill();
												}
												TweenConfig tweenConfig2 = new TweenConfig();
												object[] array2 = new object[1];
												if (array2 != null)
												{
													if ((object)_GroundFx != null)
													{
														nint num6 = (nint)array2;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj2 = default(object);
														bool flag4 = obj2 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig2 != null)
													{
														tweenConfig2.targets = array2;
														tweenConfig2.alpha = (float?)(object)1;
														if ((object)_weapon != null)
														{
															float num7 = _weapon.PDuration();
															float num8 = (tweenConfig2.delay = num5 * 0.8f);
															if ((object)_weapon != null)
															{
																float num9 = _weapon.PDuration();
																float num10 = (tweenConfig2.duration = num8 * 0.2f);
																MultiTargetTween fadeOutTween = Tweens.Add(tweenConfig2);
																_fadeOutTween = fadeOutTween;
																if ((object)_weapon != null)
																{
																	float num11 = _weapon.PDuration();
																	Action onComplete3 = delegate
																	{
																		PhaserSprite phaserSprite5 = _GroundFx.setVisible(visible: false);
																		if (_hitboxTimer != null)
																		{
																			_hitboxTimer.Cancel();
																		}
																		if (_expireTimer != null)
																		{
																			_expireTimer.Cancel();
																		}
																		StartDespawn();
																	};
																	float duration = num10 * 0.001f;
																	Timer expireTimer = Timers.Register(duration, onComplete3, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																	_expireTimer = expireTimer;
																	float2 float6 = base.position;
																	if ((object)_pfxEmitterExplosionManager != null)
																	{
																		_pfxEmitterExplosionManager.EmitParticleAt((Vector2)num4);
																		PhaserScene s_scene = ArcadePhysics.s_scene;
																		if (ArcadePhysics.s_scene != null)
																		{
																			PhaserScene.Renderer renderer = s_scene._renderer;
																			if (s_scene._renderer != null)
																			{
																				int num12 = renderer.pixelHeight >> 31;
																				object obj3 = renderer.pixelHeight - num12;
																				object obj4 = obj3 >> 1;
																				object obj5 = 0 - obj4;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
																				if ((object)_pfxEmitterManager != null)
																				{
																					int num13 = default(int);
																					ParticleEmitterManager particleEmitterManager = _pfxEmitterManager.SetDepth(num13);
																					if ((object)_GroundFx != null)
																					{
																						PhaserSprite phaserSprite4 = _GroundFx.setDepth(num13);
																						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
																						soundConfig.Rate = 1f;
																						object obj6 = _indexInWeapon - 4;
																						soundConfig.Rate = 2f;
																						float detune = (float)obj6 * 50f;
																						soundConfig.Volume = (float?)(object)1;
																						soundConfig.Detune = detune;
																						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Holywater, soundConfig, 200f, 12, flag3 ? 1 : 0);
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
		}
		throw new NullReferenceException();
	}

	private void StartDespawn()
	{
		//IL_0015: Expected I, but got O
		//IL_0049: Expected I, but got O
		//IL_0088: Expected I, but got O
		//IL_00bc: Expected I, but got O
		//IL_00f0: Expected I, but got O
		//IL_0124: Expected I, but got O
		//IL_0175: Expected I, but got O
		//IL_0231: Expected O, but got I
		//IL_029a: Expected I, but got O
		_isCullable = true;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
			nint num = unchecked((nint)null);
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
			nint num = unchecked((nint)null);
		}
		_isBroken = false;
		if (_angleTween != null)
		{
			_angleTween.Kill();
			nint num = unchecked((nint)null);
		}
		if (_positionTween != null)
		{
			_positionTween.Kill();
			nint num = unchecked((nint)null);
		}
		if (_scaleGroundTween != null)
		{
			_scaleGroundTween.Kill();
			nint num = unchecked((nint)null);
		}
		if (_growTween != null)
		{
			_growTween.Kill();
			nint num = unchecked((nint)null);
		}
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
			nint num = unchecked((nint)null);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9E0]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9E0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v301 @ rax_v18 (should have been resolved before IL gen)");
		ParticleSystem.MinMaxCurveBlittable minMaxCurveBlittable = default(ParticleSystem.MinMaxCurveBlittable);
		ParticleSystem.MinMaxCurve minMaxCurve = ParticleSystem.MinMaxCurveBlittable.ToMinMaxCurve(ref minMaxCurveBlittable);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BoraProjectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num2 = (nint)this;
		float duration = default(float);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_despawnTimer = despawnTimer;
	}

	private void KillTweens()
	{
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		if (_positionTween != null)
		{
			_positionTween.Kill();
		}
		if (_scaleGroundTween != null)
		{
			_scaleGroundTween.Kill();
		}
		if (_growTween != null)
		{
			_growTween.Kill();
		}
	}

	public BoraProjectile()
	{
		_ = 0;
		_exploRadius = 8f;
		_groundFxAlpha = 0.2f;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__21_0()
	{
		Break();
	}

	private void _003CBreak_003Eb__25_2()
	{
		//IL_0101: Expected I, but got O
		//IL_016b: Expected I, but got O
		//IL_01c1: Expected O, but got I4
		Weapon weapon = _weapon;
		float num = ((Equipment)weapon)._003COwner_003Ek__BackingField.PMoveSpeed();
		float num2 = default(float);
		bool flag = !(num2 > 1f);
		float num3 = 1f;
		if (!flag)
		{
			Weapon weapon2 = _weapon;
			float num4 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.PMoveSpeed();
			num3 = num2;
		}
		float num5 = _weapon.PArea();
		float num6 = _weapon.PSpeed();
		float num7 = num2 * num3;
		float num8 = num2 * num7;
		if (!(num8 > 12f) || _growTween != null)
		{
			_growTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		nint num9 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Transform transform = _GroundFx.transform;
			if ((object)transform != null)
			{
				nint num10 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.scale = (float?)(object)1;
			float num11 = _weapon.PDuration();
			float duration = num8 - 200f;
			tweenConfig.duration = duration;
			MultiTargetTween growTween = Tweens.Add(tweenConfig);
			_growTween = growTween;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private void _003CBreak_003Eb__25_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CBreak_003Eb__25_1()
	{
		PhaserSprite phaserSprite = _GroundFx.setVisible(visible: false);
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		StartDespawn();
	}
}
