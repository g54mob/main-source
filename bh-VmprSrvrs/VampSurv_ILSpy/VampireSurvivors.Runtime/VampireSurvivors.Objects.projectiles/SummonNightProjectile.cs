using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class SummonNightProjectile : Projectile
{
	private Timer _HitboxTimer;

	private Timer _ExpireTimer;

	private MultiTargetTween _ScaleTween;

	private PhaserSprite _fangSprite;

	private MultiTargetTween _fangTween;

	private ParticleEmitterManager _frontEmitterManager;

	private ParticleSystem _frontEmitter;

	private Rectangle _explosionRect;

	private ParticleEmitterManager _backEmitterManager;

	private ParticleSystem _backEmitter;

	private MultiTargetTween _fangTweenOut;

	private ParticleEmitterManager _fragmentsEmitterManager;

	private float _reach;

	private ParticleSystem _fragmentsEmitter;

	private EmitZone _emitZone;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_10be: Expected O, but got I
		//IL_0139: Expected O, but got I4
		//IL_050b: Expected O, but got Ref
		//IL_0525: Expected native int or pointer, but got O
		//IL_053f: Expected O, but got I
		//IL_056d: Expected O, but got I4
		//IL_0586: Expected O, but got Ref
		//IL_05a0: Expected native int or pointer, but got O
		//IL_10ed: Expected O, but got I4
		//IL_05b8: Expected O, but got Ref
		//IL_05d2: Expected native int or pointer, but got O
		//IL_05ec: Expected O, but got I
		//IL_060c: Expected O, but got Ref
		//IL_0633: Expected O, but got I
		//IL_064d: Expected native int or pointer, but got O
		//IL_0667: Expected O, but got I
		//IL_0687: Expected O, but got Ref
		//IL_06a1: Expected native int or pointer, but got O
		//IL_111f: Expected O, but got I
		//IL_06d9: Expected O, but got Ref
		//IL_06f3: Expected native int or pointer, but got O
		//IL_1159: Expected O, but got I
		//IL_09bd: Expected O, but got Ref
		//IL_09d7: Expected native int or pointer, but got O
		//IL_11a2: Expected O, but got I
		//IL_0a28: Expected O, but got I
		//IL_0a44: Expected O, but got I4
		//IL_0a5d: Expected O, but got Ref
		//IL_0a77: Expected native int or pointer, but got O
		//IL_0a85: Expected O, but got I4
		//IL_11ca: Expected O, but got I4
		//IL_0ab2: Expected O, but got Ref
		//IL_0acc: Expected native int or pointer, but got O
		//IL_1211: Expected O, but got I
		//IL_0c43: Expected O, but got Ref
		//IL_0c5d: Expected native int or pointer, but got O
		//IL_0ca2: Expected O, but got I
		//IL_0ce8: Expected O, but got I
		//IL_0d04: Expected O, but got I4
		//IL_0d1d: Expected O, but got Ref
		//IL_0d37: Expected native int or pointer, but got O
		//IL_0d7c: Expected O, but got I
		//IL_1057->IL0ffb: Incompatible stack heights: 1 vs 0
		//IL_00b0->IL0ffb: Incompatible stack heights: 1 vs 0
		//IL_00da->IL0ffb: Incompatible stack heights: 1 vs 0
		//IL_10da->IL0ffb: Incompatible stack heights: 2 vs 0
		//IL_0155->IL0ffb: Incompatible stack heights: 2 vs 0
		//IL_019d->IL0ffb: Incompatible stack heights: 2 vs 0
		//IL_01f9->IL0ffb: Incompatible stack heights: 2 vs 0
		//IL_0248->IL0ffb: Incompatible stack heights: 2 vs 0
		//IL_02fc->IL0ffb: Incompatible stack heights: 2 vs 0
		//IL_03b0->IL0ffb: Incompatible stack heights: 2 vs 0
		//IL_0464->IL0ffb: Incompatible stack heights: 2 vs 0
		//IL_04e6->IL0ffb: Incompatible stack heights: 2 vs 0
		//IL_0743->IL0ffb: Incompatible stack heights: 2 vs 0
		//IL_07b3->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_086b->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_08c7->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_0916->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_0998->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_0b51->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_0b9c->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_0bf8->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_0c23->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_0e00->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_1266->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_0e58->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_0e77->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_128d->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_0ed1->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_0ef0->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_12b4->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_0f4a->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_0f69->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_12db->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_0fb5->IL0ffb: Incompatible stack heights: 3 vs 0
		//IL_0fd4->IL0ffb: Incompatible stack heights: 3 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			if ((object)this != null)
			{
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "fangNight");
				if ((object)phaserSprite != null)
				{
					Transform transform2 = phaserSprite.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1210 @ rcx_v29 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
						}
						Transform.SetParent_Injected(((UnityEngine.Object)transform2).m_CachedPtr, (IntPtr)0, true);
						_ = 0;
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+260]");
						PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0.5f, (float?)(object)0);
						if ((object)phaserSprite2 != null)
						{
							PhaserSprite phaserSprite3 = phaserSprite2.setScale(0f, (float?)(object)0);
							if ((object)phaserSprite3 != null)
							{
								PhaserSprite fangSprite = phaserSprite3.setAlpha(0f);
								_fangSprite = fangSprite;
								GameObject gameObject2 = base.gameObject;
								if ((object)gameObject2 != null)
								{
									ParticleEmitterManager fragmentsEmitterManager = gameObject2.AddComponent<ParticleEmitterManager>();
									_fragmentsEmitterManager = fragmentsEmitterManager;
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
												((List<object>)(object)list).AddWithResize((object)"glass0000");
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
													((List<object>)(object)list).AddWithResize((object)"glass0001");
												}
												else
												{
													int num3 = list._size + 1;
													list._size = num3;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												}
												int version3 = list._version + 1;
												list._version = version3;
												string[] items3 = list._items;
												if (list._items != null)
												{
													if (list._size >= items3.Length)
													{
														((List<object>)(object)list).AddWithResize((object)"glass0002");
													}
													else
													{
														int num4 = list._size + 1;
														list._size = num4;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													}
													int version4 = list._version + 1;
													list._version = version4;
													string[] items4 = list._items;
													if (list._items != null)
													{
														if (list._size >= items4.Length)
														{
															((List<object>)(object)list).AddWithResize((object)"glass0003");
														}
														else
														{
															int num5 = list._size + 1;
															list._size = num5;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														}
														if (particleSystemConfig != null)
														{
															particleSystemConfig._frame = list;
															ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
															_ = 0;
															_ = 0;
															System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(30f, 150f));
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A0]");
															particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
															_ = 0;
															ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(400f);
															particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
															_ = 0;
															ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
															_ = 0;
															_ = 0;
															System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(100f, 300f));
															particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
															_ = 0;
															ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
															_ = 0;
															_ = 0;
															System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f, 360f));
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
															particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
															_ = 0;
															ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
															_ = 0;
															_ = 16;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+260]");
															particleSystemConfig._quantity = (int?)(object)0;
															_ = 0;
															_ = 0;
															System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(250f, 750f));
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
															particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
															_ = 0;
															ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
															_ = 0;
															_ = 0;
															System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.8f, 0.6f));
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+120]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
															_ = 0;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
															particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
															_ = 0;
															ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
															_ = 0;
															_ = 0;
															System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(4f, 0f));
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+140]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
															_ = 0;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
															particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
															_ = 0;
															uint[] array = new uint[3];
															if (array != null)
															{
																bool flag3 = array.Length <= 2;
																array[2] = 68u;
																particleSystemConfig._tintRandom = array;
																particleSystemConfig._on = false;
																if ((object)_fragmentsEmitterManager != null)
																{
																	ParticleSystem fragmentsEmitter = _fragmentsEmitterManager.CreateEmitter(particleSystemConfig);
																	_fragmentsEmitter = fragmentsEmitter;
																	_explosionRect = new Rectangle
																	{
																		_x = 0f,
																		_width = 0.16f,
																		_height = 0.16f
																	};
																	_emitZone = new EmitZone
																	{
																		_type = EmitZoneType.Random,
																		_source = _explosionRect
																	};
																	GameObject gameObject3 = base.gameObject;
																	if ((object)gameObject3 != null)
																	{
																		ParticleEmitterManager frontEmitterManager = gameObject3.AddComponent<ParticleEmitterManager>();
																		_frontEmitterManager = frontEmitterManager;
																		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
																		List<string> list2 = new List<string>();
																		if (list2 != null)
																		{
																			int version5 = list2._version + 1;
																			list2._version = version5;
																			string[] items5 = list2._items;
																			if (list2._items != null)
																			{
																				if (list2._size >= items5.Length)
																				{
																					((List<object>)(object)list2).AddWithResize((object)"bulletNightA");
																				}
																				else
																				{
																					int num6 = list2._size + 1;
																					list2._size = num6;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																				}
																				if (particleSystemConfig2 != null)
																				{
																					particleSystemConfig2._frame = list2;
																					ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
																					_ = 0;
																					_ = 0;
																					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+160]");
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+170]");
																					_ = 0;
																					_ = 1;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
																					particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
																					_ = 0;
																					_ = 0;
																					_ = 1;
																					_ = 1;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+260]");
																					particleSystemConfig2._quantity = (int?)(object)0;
																					minMaxCurve2 = new ParticleSystem.MinMaxCurve(300f);
																					particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
																					_ = 0;
																					ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 384));
																					_ = 0;
																					_ = 0;
																					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(1f, 0f));
																					obj = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+190]");
																					_ = 0;
																					obj = 1;
																					particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)obj;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+10]");
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+20]");
																					_ = 0;
																					ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 416));
																					_ = 0;
																					_ = 0;
																					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(1f, 1f));
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1A0]");
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
																					_ = 0;
																					_ = 1;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
																					particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
																					_ = 0;
																					particleSystemConfig2._tintRandom = new uint[3] { 16711680u, 16711935u, 255u };
																					particleSystemConfig2._emitZone = _emitZone;
																					particleSystemConfig2._on = false;
																					if ((object)_frontEmitterManager != null)
																					{
																						ParticleSystem frontEmitter = _frontEmitterManager.CreateEmitter(particleSystemConfig2);
																						_frontEmitter = frontEmitter;
																						GameObject gameObject4 = base.gameObject;
																						if ((object)gameObject4 != null)
																						{
																							ParticleEmitterManager backEmitterManager = gameObject4.AddComponent<ParticleEmitterManager>();
																							_backEmitterManager = backEmitterManager;
																							ParticleSystemConfig particleSystemConfig3 = new ParticleSystemConfig("vfx");
																							List<string> list3 = new List<string>();
																							if (list3 != null)
																							{
																								list3.Add("bulletNightB");
																								if (particleSystemConfig3 != null)
																								{
																									particleSystemConfig3._frame = list3;
																									ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 448));
																									_ = 0;
																									_ = 0;
																									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
																									_ = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1C0]");
																									_ = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
																									_ = 0;
																									_ = 1;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
																									particleSystemConfig3._speed = (ParticleSystem.MinMaxCurve?)(object)0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
																									_ = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
																									_ = 0;
																									_ = 0;
																									_ = 2;
																									_ = 1;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+260]");
																									particleSystemConfig3._quantity = (int?)(object)0;
																									minMaxCurve2 = new ParticleSystem.MinMaxCurve(300f);
																									particleSystemConfig3._lifespan = (ParticleSystem.MinMaxCurve)0;
																									_ = 0;
																									ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 480));
																									_ = 0;
																									_ = 0;
																									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(1f, 0f));
																									_ = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1E0]");
																									_ = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1F0]");
																									_ = 0;
																									_ = 1;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
																									particleSystemConfig3._scale = (ParticleSystem.MinMaxCurve?)(object)0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
																									_ = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+98]");
																									_ = 0;
																									particleSystemConfig3._tintRandom = new uint[3] { 16711680u, 16711935u, 255u };
																									particleSystemConfig3._emitZone = _emitZone;
																									particleSystemConfig3._on = false;
																									if ((object)_backEmitterManager != null)
																									{
																										ParticleSystem backEmitter = _backEmitterManager.CreateEmitter(particleSystemConfig3);
																										_backEmitter = backEmitter;
																										PhaserScene s_scene = ArcadePhysics.s_scene;
																										if (ArcadePhysics.s_scene != null)
																										{
																											PhaserScene.Renderer renderer = s_scene._renderer;
																											if (s_scene._renderer != null && (object)_fragmentsEmitterManager != null)
																											{
																												int num7 = renderer.pixelHeight + 2;
																												ParticleEmitterManager particleEmitterManager = _fragmentsEmitterManager.SetDepth(num7);
																												PhaserScene s_scene2 = ArcadePhysics.s_scene;
																												if (ArcadePhysics.s_scene != null)
																												{
																													PhaserScene.Renderer renderer2 = s_scene2._renderer;
																													if (s_scene2._renderer != null && (object)_frontEmitterManager != null)
																													{
																														int num8 = renderer2.pixelHeight + 1;
																														ParticleEmitterManager particleEmitterManager2 = _frontEmitterManager.SetDepth(num8);
																														PhaserScene s_scene3 = ArcadePhysics.s_scene;
																														if (ArcadePhysics.s_scene != null)
																														{
																															PhaserScene.Renderer renderer3 = s_scene3._renderer;
																															if (s_scene3._renderer != null && (object)_fangSprite != null)
																															{
																																PhaserSprite phaserSprite4 = _fangSprite.setDepth(renderer3.pixelHeight);
																																PhaserScene s_scene4 = ArcadePhysics.s_scene;
																																if (ArcadePhysics.s_scene != null)
																																{
																																	PhaserScene.Renderer renderer4 = s_scene4._renderer;
																																	if (s_scene4._renderer != null && (object)_backEmitterManager != null)
																																	{
																																		int num9 = -renderer4.pixelHeight;
																																		ParticleEmitterManager particleEmitterManager3 = _backEmitterManager.SetDepth(num9);
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
		//IL_08f0: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_00ef: Expected O, but got I4
		//IL_036c: Invalid comparison between F4 and I4
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Expected O, but got Unknown
		//IL_07fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0800: Expected F4, but got Unknown
		//IL_0949->IL08b8: Incompatible stack heights: 1 vs 0
		//IL_01f7->IL08b8: Incompatible stack heights: 1 vs 0
		//IL_0290->IL08b8: Incompatible stack heights: 1 vs 0
		//IL_0324->IL08b8: Incompatible stack heights: 1 vs 0
		//IL_09bb->IL08b8: Incompatible stack heights: 1 vs 0
		//IL_041a->IL08b8: Incompatible stack heights: 1 vs 0
		//IL_04b3->IL08b8: Incompatible stack heights: 1 vs 0
		//IL_0505->IL08b8: Incompatible stack heights: 2 vs 0
		//IL_0994->IL08b8: Incompatible stack heights: 2 vs 0
		//IL_0576->IL08b8: Incompatible stack heights: 2 vs 0
		//IL_0595->IL08b8: Incompatible stack heights: 2 vs 0
		//IL_0653->IL08b8: Incompatible stack heights: 2 vs 0
		//IL_06c4->IL08b8: Incompatible stack heights: 2 vs 0
		//IL_06a2->IL06a2: Incompatible stack heights: 3 vs 2
		//IL_06f4->IL08b8: Incompatible stack heights: 2 vs 0
		//IL_07d6->IL08b8: Incompatible stack heights: 2 vs 0
		//IL_0831->IL08b8: Incompatible stack heights: 2 vs 0
		//IL_0867->IL08b8: Incompatible stack heights: 2 vs 0
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		ArcadeSprite arcadeSprite2 = setOrigin(0.5f, (float?)(object)1);
		if ((object)_fangSprite != null)
		{
			PhaserSprite phaserSprite = _fangSprite.setOrigin(0.5f, (float?)(object)1);
			if ((object)_fangSprite != null)
			{
				PhaserSprite phaserSprite2 = _fangSprite.setFlipY(flipY: false);
				Rectangle explosionRect = _explosionRect;
				if (_explosionRect != null)
				{
					explosionRect._y = 0f;
					if ((object)_fangSprite != null)
					{
						PhaserSprite phaserSprite3 = _fangSprite.setFrame("fangNight", "vfx");
						ArcadeSprite arcadeSprite3 = setScale(0f, (float?)(object)0);
						BaseBody baseBody = body;
						if (body != null)
						{
							baseBody._enable = true;
							_isCullable = false;
							Transform transform = base.transform;
							if ((object)transform != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rax_v24 (UnityEngine.Transform)+10]");
								bool flag = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rax_v24 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out Vector3 _);
								if ((object)_fragmentsEmitterManager != null)
								{
									Vector2 pos = default(Vector2);
									_fragmentsEmitterManager.EmitParticleAt(pos, 16);
									if (_HitboxTimer != null)
									{
										_HitboxTimer.Cancel();
									}
									if (_ExpireTimer != null)
									{
										_ExpireTimer.Cancel();
									}
									if ((object)_weapon != null)
									{
										float hitBoxDelay = _weapon.HitBoxDelay;
										Action onComplete = delegate
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
										};
										float num = hitBoxDelay * 0.001f;
										bool useRealTime = default(bool);
										MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
										int repeat = default(int);
										TimerType type = default(TimerType);
										Timer hitboxTimer = Timers.Register(num, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
										_HitboxTimer = hitboxTimer;
										if ((object)_weapon != null)
										{
											float num2 = _weapon.PDuration();
											Action onComplete2 = delegate
											{
												Despawn();
											};
											float num3 = num * 0.001f;
											Timer expireTimer = Timers.Register(num3, onComplete2, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
											_ExpireTimer = expireTimer;
											if ((object)_weapon != null)
											{
												float num4 = _weapon.PArea();
												float num5 = num3 - 1.2f;
												_reach = 0.5f;
												float num6 = num3 * 16f;
												if (num5 > 0f)
												{
													float num7 = num3 - 1.2f;
													object obj = num7 & -2147483649L;
													if ((nint)obj > 2139095040 || num7 > 0.5f)
													{
														num7 = 0.5f;
													}
													float reach = num7 + 0.5f;
													_reach = reach;
												}
												PhaserScene s_scene = ArcadePhysics.s_scene;
												if (ArcadePhysics.s_scene != null)
												{
													PhaserScene.Renderer renderer = s_scene._renderer;
													if (s_scene._renderer != null)
													{
														float num8 = renderer.height * 100f;
														float reach2 = num8 * _reach;
														_reach = reach2;
														if (_ScaleTween != null)
														{
															_ScaleTween.Kill();
														}
														TweenConfig tweenConfig = new TweenConfig();
														object[] array = new object[1];
														if (array != null)
														{
															object obj2 = array;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj3 = default(object);
															bool flag2 = obj3 == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if (tweenConfig != null)
															{
																_ = 1;
																_ = 1140457472;
																_ = 1;
																MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
																_ScaleTween = scaleTween;
																PhaserScene s_scene2 = ArcadePhysics.s_scene;
																if (ArcadePhysics.s_scene != null)
																{
																	PhaserScene.Renderer renderer2 = s_scene2._renderer;
																	if (s_scene2._renderer != null && (object)_frontEmitterManager != null)
																	{
																		int num9 = renderer2.pixelHeight + 1;
																		ParticleEmitterManager particleEmitterManager = _frontEmitterManager.SetDepth(num9);
																		if (_fangTweenOut != null)
																		{
																			_fangTweenOut.Kill();
																		}
																		if (_fangTween != null)
																		{
																			_fangTween.Kill();
																		}
																		TweenConfig tweenConfig2 = new TweenConfig();
																		object[] array2 = new object[1];
																		if (array2 != null)
																		{
																			if ((object)_fangSprite != null)
																			{
																				object obj4 = array2;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																				object obj5 = default(object);
																				bool flag3 = obj5 == null;
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																			if (tweenConfig2 != null)
																			{
																				_ = 1;
																				if ((object)_weapon != null)
																				{
																					float num10 = _weapon.PArea();
																					_ = 1;
																					_ = 1;
																					float2 float5 = base.position;
																					_ = 1128792064;
																					_ = 4;
																					_ = 1;
																					TweenCallback tweenCallback = delegate
																					{
																						//IL_001a: Expected O, but got I4
																						//IL_003c: Expected F4, but got O
																						//IL_008e: Expected O, but got I4
																						PhaserSprite phaserSprite4 = _fangSprite.setOrigin(0.5f, (float?)(object)1);
																						float2 float6 = base.position;
																						_fangSprite.X = (float)float6;
																						float2 float7 = base.position;
																						_fangSprite.Y = 1.28f;
																						PhaserSprite phaserSprite5 = _fangSprite.setAlpha(0f);
																						PhaserSprite phaserSprite6 = _fangSprite.setScale(0f, (float?)(object)0);
																					};
																					TweenCallback tweenCallback2 = delegate
																					{
																						//IL_005e: Expected I, but got O
																						//IL_00c2: Expected O, but got I4
																						//IL_00ec: Expected O, but got I4
																						if (_fangTweenOut != null)
																						{
																							_fangTweenOut.Kill();
																						}
																						TweenConfig tweenConfig3 = new TweenConfig();
																						object[] array3 = new object[1];
																						if ((object)_fangSprite != null)
																						{
																							nint num14 = (nint)array3;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																							object obj6 = default(object);
																							if (obj6 == null)
																							{
																								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
																								throw ex;
																							}
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																						tweenConfig3.targets = array3;
																						tweenConfig3.delay = 200f;
																						tweenConfig3.scaleX = (float?)(object)1;
																						tweenConfig3.duration = 200f;
																						tweenConfig3.ease = Ease.InOutSine;
																						tweenConfig3.scaleY = (float?)(object)1;
																						TweenCallback onComplete3 = delegate
																						{
																							PhaserScene s_scene3 = ArcadePhysics.s_scene;
																							PhaserScene.Renderer renderer3 = s_scene3._renderer;
																							int num15 = 1 - renderer3.pixelHeight;
																							ParticleEmitterManager particleEmitterManager2 = _frontEmitterManager.SetDepth(num15);
																						};
																						tweenConfig3.onComplete = onComplete3;
																						MultiTargetTween fangTweenOut = Tweens.Add(tweenConfig3);
																						_fangTweenOut = fangTweenOut;
																					};
																					MultiTargetTween fangTween = Tweens.Add(tweenConfig2);
																					_fangTween = fangTween;
																					Rectangle explosionRect2 = _explosionRect;
																					float num11 = num6 * 0.5f;
																					float num12 = num11 * 0.01f;
																					if (_explosionRect != null)
																					{
																						float num13 = num12 * 0.5f;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
																						float x = num13 ^ 0;
																						explosionRect2._x = x;
																						Rectangle explosionRect3 = _explosionRect;
																						if (_explosionRect != null)
																						{
																							explosionRect3._width = num12;
																							Rectangle explosionRect4 = _explosionRect;
																							if (_explosionRect != null)
																							{
																								float height = _reach * 0.01f;
																								explosionRect4._height = height;
																								RenderingExtensions.SetEmitZone(_frontEmitter, _emitZone);
																								RenderingExtensions.SetEmitZone(_backEmitter, _emitZone);
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
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		if (baseBody._enable)
		{
			baseBody._enable = false;
			if (_HitboxTimer != null)
			{
				_HitboxTimer.Cancel();
			}
			if (_ExpireTimer != null)
			{
				_ExpireTimer.Cancel();
			}
			Action onComplete = delegate
			{
				_isCullable = true;
				base.Despawn();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.75000006f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	public override void InternalUpdate()
	{
		//IL_01aa->IL0130: Incompatible stack heights: 1 vs 0
		//IL_00cf->IL0130: Incompatible stack heights: 1 vs 0
		//IL_0111->IL0130: Incompatible stack heights: 1 vs 0
		//IL_012f->IL012f: Incompatible stack heights: 1 vs 0
		BaseBody baseBody = body;
		if (body != null)
		{
			if (!baseBody._enable)
			{
				return;
			}
			Rectangle explosionRect = _explosionRect;
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if (_explosionRect != null)
				{
					object obj = default(object);
					float height = (float)obj * 0.01f;
					explosionRect._height = height;
					RenderingExtensions.SetEmitZone(_frontEmitter, _emitZone);
					RenderingExtensions.SetEmitZone(_backEmitter, _emitZone);
					float2 float5 = base.position;
					if ((object)_frontEmitterManager != null)
					{
						Vector2 pos = default(Vector2);
						_frontEmitterManager.EmitParticleAt(pos);
						float2 float6 = base.position;
						if ((object)_backEmitterManager != null)
						{
							_backEmitterManager.EmitParticleAt(pos, 2);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CInitProjectile_003Eb__16_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CInitProjectile_003Eb__16_1()
	{
		Despawn();
	}

	private void _003CInitProjectile_003Eb__16_2()
	{
		//IL_001a: Expected O, but got I4
		//IL_003c: Expected F4, but got O
		//IL_008e: Expected O, but got I4
		PhaserSprite phaserSprite = _fangSprite.setOrigin(0.5f, (float?)(object)1);
		float2 float5 = base.position;
		_fangSprite.X = (float)float5;
		float2 float6 = base.position;
		_fangSprite.Y = 1.28f;
		PhaserSprite phaserSprite2 = _fangSprite.setAlpha(0f);
		PhaserSprite phaserSprite3 = _fangSprite.setScale(0f, (float?)(object)0);
	}

	private void _003CInitProjectile_003Eb__16_3()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		//IL_00ec: Expected O, but got I4
		if (_fangTweenOut != null)
		{
			_fangTweenOut.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_fangSprite != null)
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
		tweenConfig.delay = 200f;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.duration = 200f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.scaleY = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			int num2 = 1 - renderer.pixelHeight;
			ParticleEmitterManager particleEmitterManager = _frontEmitterManager.SetDepth(num2);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween fangTweenOut = Tweens.Add(tweenConfig);
		_fangTweenOut = fangTweenOut;
	}

	private void _003CInitProjectile_003Eb__16_4()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num = 1 - renderer.pixelHeight;
		ParticleEmitterManager particleEmitterManager = _frontEmitterManager.SetDepth(num);
	}

	private void _003CDespawn_003Eb__17_0()
	{
		_isCullable = true;
		base.Despawn();
	}
}
