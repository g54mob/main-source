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
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Vento2ExploProjectile : Projectile
{
	private MultiTargetTween _tween;

	private uint[] _colorss = new uint[3] { 16711935u, 6684774u, 16711680u };

	private SpriteAnimation _anims;

	private PhaserSprite _ghost1;

	private PhaserSprite _ghost2;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _emitter1;

	private ParticleSystem _emitter2;

	private int _repeatCount;

	private int _colorCount;

	private static float[] s_detunes = new float[4] { 0f, 400f, 800f, 1200f };

	private static int s_detunesIndex = 0;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0e44: Expected I4, but got O
		//IL_0ef5: Expected F4, but got I
		//IL_0f08: Expected O, but got I4
		//IL_0f23: Expected F4, but got I
		//IL_1604: Expected O, but got I
		//IL_1604: Expected O, but got I
		//IL_0f36: Expected O, but got I4
		//IL_0f5d: Expected O, but got I4
		//IL_0f71: Expected O, but got Ref
		//IL_0f8b: Expected native int or pointer, but got O
		//IL_1679: Unknown result type (might be due to invalid IL or missing references)
		//IL_167e: Expected O, but got Unknown
		//IL_1695: Unknown result type (might be due to invalid IL or missing references)
		//IL_169a: Expected O, but got Unknown
		//IL_0faa: Expected O, but got I
		//IL_0fd3: Expected O, but got Ref
		//IL_0fed: Expected native int or pointer, but got O
		//IL_100c: Expected O, but got I
		//IL_1027: Expected O, but got Ref
		//IL_1041: Expected native int or pointer, but got O
		//IL_1086: Expected O, but got I
		//IL_10b3: Expected O, but got Ref
		//IL_10db: Expected native int or pointer, but got O
		//IL_1120: Expected O, but got I
		//IL_1161: Expected O, but got I
		//IL_1702: Expected O, but got F4
		//IL_11d4: Expected O, but got I
		//IL_125b: Expected F4, but got I
		//IL_126e: Expected O, but got I4
		//IL_1289: Expected F4, but got I
		//IL_129c: Expected O, but got I4
		//IL_12c3: Expected O, but got I4
		//IL_12d7: Expected O, but got Ref
		//IL_12f1: Expected native int or pointer, but got O
		//IL_1310: Expected O, but got I
		//IL_1339: Expected O, but got Ref
		//IL_1353: Expected native int or pointer, but got O
		//IL_1372: Expected O, but got I
		//IL_138d: Expected O, but got Ref
		//IL_13a7: Expected native int or pointer, but got O
		//IL_13c7: Expected O, but got I
		//IL_13ef: Expected O, but got I
		//IL_141c: Expected O, but got Ref
		//IL_1444: Expected native int or pointer, but got O
		//IL_1489: Expected O, but got I
		//IL_14ca: Expected O, but got I
		//IL_1d97: Expected I, but got O
		//IL_153d: Expected O, but got I
		//IL_1e31: Expected I, but got O
		//IL_185c: Expected O, but got F4
		//IL_1899: Expected I, but got O
		//IL_1e49: Expected I4, but got I8
		//IL_18ac: Expected O, but got I4
		//IL_18b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ba: Expected O, but got Unknown
		//IL_18c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c8: Expected I4, but got Unknown
		//IL_18e6: Expected O, but got I4
		//IL_1a2e: Expected O, but got F4
		//IL_1ad7: Expected O, but got I4
		//IL_1b22: Expected I, but got O
		//IL_1e98->IL1ca5: Incompatible stack heights: 11 vs 0
		//IL_1a85->IL1ca5: Incompatible stack heights: 11 vs 0
		//IL_1b15->IL1ca5: Incompatible stack heights: 11 vs 0
		//IL_1b67->IL1ca5: Incompatible stack heights: 12 vs 0
		//IL_1ebf->IL1ca5: Incompatible stack heights: 12 vs 0
		//IL_1ba5->IL1ca5: Incompatible stack heights: 12 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
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
					((List<object>)(object)list).AddWithResize((object)"leaf0000");
				}
				else
				{
					int num = list._size + 1;
					list._size = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version2 = list._version + 1;
				list._version = version2;
				string[] items2 = list._items;
				if (list._items != null)
				{
					if (list._size >= items2.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"leaf0001");
					}
					else
					{
						int num2 = list._size + 1;
						list._size = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version3 = list._version + 1;
					list._version = version3;
					string[] items3 = list._items;
					if (list._items != null)
					{
						if (list._size >= items3.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"leaf0002");
						}
						else
						{
							int num3 = list._size + 1;
							list._size = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version4 = list._version + 1;
						list._version = version4;
						string[] items4 = list._items;
						if (list._items != null)
						{
							if (list._size >= items4.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"leaf0003");
							}
							else
							{
								int num4 = list._size + 1;
								list._size = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							int version5 = list._version + 1;
							list._version = version5;
							string[] items5 = list._items;
							if (list._items != null)
							{
								if (list._size >= items5.Length)
								{
									((List<object>)(object)list).AddWithResize((object)"leaf0004");
								}
								else
								{
									int num5 = list._size + 1;
									list._size = num5;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								int version6 = list._version + 1;
								list._version = version6;
								string[] items6 = list._items;
								if (list._items != null)
								{
									if (list._size >= items6.Length)
									{
										((List<object>)(object)list).AddWithResize((object)"leaf0005");
									}
									else
									{
										int num6 = list._size + 1;
										list._size = num6;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									}
									int version7 = list._version + 1;
									list._version = version7;
									string[] items7 = list._items;
									if (list._items != null)
									{
										if (list._size >= items7.Length)
										{
											((List<object>)(object)list).AddWithResize((object)"leaf0006");
										}
										else
										{
											int num7 = list._size + 1;
											list._size = num7;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										int version8 = list._version + 1;
										list._version = version8;
										string[] items8 = list._items;
										if (list._items != null)
										{
											if (list._size >= items8.Length)
											{
												((List<object>)(object)list).AddWithResize((object)"leaf0007");
											}
											else
											{
												int num8 = list._size + 1;
												list._size = num8;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											}
											int version9 = list._version + 1;
											list._version = version9;
											string[] items9 = list._items;
											if (list._items != null)
											{
												if (list._size >= items9.Length)
												{
													((List<object>)(object)list).AddWithResize((object)"leaf0008");
												}
												else
												{
													int num9 = list._size + 1;
													list._size = num9;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												}
												int version10 = list._version + 1;
												list._version = version10;
												string[] items10 = list._items;
												if (list._items != null)
												{
													if (list._size >= items10.Length)
													{
														((List<object>)(object)list).AddWithResize((object)"leaf0009");
													}
													else
													{
														int num10 = list._size + 1;
														list._size = num10;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													}
													int version11 = list._version + 1;
													list._version = version11;
													string[] items11 = list._items;
													if (list._items != null)
													{
														if (list._size >= items11.Length)
														{
															((List<object>)(object)list).AddWithResize((object)"leaf0010");
														}
														else
														{
															int num11 = list._size + 1;
															list._size = num11;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														}
														int version12 = list._version + 1;
														list._version = version12;
														string[] items12 = list._items;
														if (list._items != null)
														{
															if (list._size >= items12.Length)
															{
																((List<object>)(object)list).AddWithResize((object)"leaf0011");
															}
															else
															{
																int num12 = list._size + 1;
																list._size = num12;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															int version13 = list._version + 1;
															list._version = version13;
															string[] items13 = list._items;
															if (list._items != null)
															{
																if (list._size >= items13.Length)
																{
																	((List<object>)(object)list).AddWithResize((object)"leaf0012");
																}
																else
																{
																	int num13 = list._size + 1;
																	list._size = num13;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																}
																int version14 = list._version + 1;
																list._version = version14;
																string[] items14 = list._items;
																if (list._items != null)
																{
																	if (list._size >= items14.Length)
																	{
																		((List<object>)(object)list).AddWithResize((object)"leaf0013");
																	}
																	else
																	{
																		int num14 = list._size + 1;
																		list._size = num14;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	}
																	int version15 = list._version + 1;
																	list._version = version15;
																	string[] items15 = list._items;
																	if (list._items != null)
																	{
																		if (list._size >= items15.Length)
																		{
																			((List<object>)(object)list).AddWithResize((object)"leaf0014");
																		}
																		else
																		{
																			int num15 = list._size + 1;
																			list._size = num15;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		}
																		int version16 = list._version + 1;
																		list._version = version16;
																		string[] items16 = list._items;
																		if (list._items != null)
																		{
																			if (list._size >= items16.Length)
																			{
																				((List<object>)(object)list).AddWithResize((object)"leaf0015");
																			}
																			else
																			{
																				int num16 = list._size + 1;
																				list._size = num16;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																			}
																			int version17 = list._version + 1;
																			list._version = version17;
																			string[] items17 = list._items;
																			if (list._items != null)
																			{
																				if (list._size >= items17.Length)
																				{
																					((List<object>)(object)list).AddWithResize((object)"leaf0016");
																				}
																				else
																				{
																					int num17 = list._size + 1;
																					list._size = num17;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																				}
																				int version18 = list._version + 1;
																				list._version = version18;
																				string[] items18 = list._items;
																				if (list._items != null)
																				{
																					if (list._size >= items18.Length)
																					{
																						((List<object>)(object)list).AddWithResize((object)"leaf0017");
																					}
																					else
																					{
																						int num18 = list._size + 1;
																						list._size = num18;
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																					}
																					int version19 = list._version + 1;
																					list._version = version19;
																					string[] items19 = list._items;
																					if (list._items != null)
																					{
																						if (list._size >= items19.Length)
																						{
																							((List<object>)(object)list).AddWithResize((object)"leaf0018");
																						}
																						else
																						{
																							int num19 = list._size + 1;
																							list._size = num19;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																						}
																						int version20 = list._version + 1;
																						list._version = version20;
																						string[] items20 = list._items;
																						if (list._items != null)
																						{
																							if (list._size >= items20.Length)
																							{
																								((List<object>)(object)list).AddWithResize((object)"leaf0019");
																							}
																							else
																							{
																								int num20 = list._size + 1;
																								list._size = num20;
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																							}
																							int num21 = (int)_pfxManager;
																							if ((object)_pfxManager != null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1890 @ rdi_v16 (System.Int32)+10]");
																								if ((nint)0 != 0)
																								{
																									goto IL_158e;
																								}
																							}
																							GameObject gameObject = base.gameObject;
																							ParticleEmitterManager pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
																							_pfxManager = pfxManager;
																							float2 float5 = base.position;
																							ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
																							particleSystemConfig._frame = list;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+208]");
																							ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
																							particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+20C]");
																							minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
																							particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
																							_ = 0;
																							minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
																							particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+70]");
																							particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+80]");
																							_ = 0;
																							particleSystemConfig._angleSteps = 30;
																							ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+90]");
																							particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+A0]");
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+B0]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+C0]");
																							_ = 0;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-80]");
																							particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-70]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208));
																							particleSystemConfig._alphaEase = Easing.OutExpo;
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(350f, 450f));
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+D0]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+E0]");
																							_ = 0;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-58]");
																							particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-48]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-38]");
																							_ = 0;
																							_ = 0;
																							_ = 2;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+208]");
																							particleSystemConfig._quantity = (int?)(object)0;
																							particleSystemConfig._tintRandom = new uint[3] { 2228258u, 6684774u, 15597568u };
																							minMaxCurve = new ParticleSystem.MinMaxCurve(4f);
																							_ = 0;
																							_ = 0;
																							_ = 0;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-30]");
																							particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-20]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-10]");
																							_ = 0;
																							particleSystemConfig._on = false;
																							ParticleSystem emitter = _pfxManager.CreateEmitter(particleSystemConfig);
																							_emitter1 = emitter;
																							ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
																							particleSystemConfig2._frame = list;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+208]");
																							minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
																							particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+20C]");
																							minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
																							particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
																							_ = 0;
																							minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
																							particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 240));
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(90f, 450f));
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+F0]");
																							particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+100]");
																							_ = 0;
																							particleSystemConfig2._angleSteps = 30;
																							ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 272));
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+110]");
																							particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+120]");
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 304));
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+130]");
																							obj = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+140]");
																							_ = 0;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-8]");
																							particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+8]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+18]");
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 336));
																							particleSystemConfig2._alphaEase = Easing.OutExpo;
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(150f, 250f));
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+150]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+160]");
																							_ = 0;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+20]");
																							particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+30]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+40]");
																							_ = 0;
																							_ = 0;
																							_ = 2;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+208]");
																							particleSystemConfig2._quantity = (int?)(object)0;
																							particleSystemConfig2._tintRandom = new uint[3] { 2228258u, 6684774u, 15597568u };
																							minMaxCurve = new ParticleSystem.MinMaxCurve(4f);
																							_ = 0;
																							_ = 0;
																							_ = 0;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+48]");
																							particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+58]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+68]");
																							_ = 0;
																							particleSystemConfig2._on = false;
																							ParticleSystem emitter2 = _pfxManager.CreateEmitter(particleSystemConfig2);
																							_emitter2 = emitter2;
																							goto IL_158e;
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
		goto IL_1ca5;
		IL_158e:
		BaseBody baseBody = body;
		_ = 0;
		_ = 0;
		_ = 1082130432;
		_ = 1;
		_ = 1082130432;
		_ = 1;
		if (body != null)
		{
			BaseBody baseBody2 = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+210]");
			nint num22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+208]");
			BaseBody baseBody3 = baseBody2.setCircle(28f, (float?)(object)num22, (float?)(object)0);
			uint[] colorss = _colorss;
			int colorCount = _colorCount + 1;
			_colorCount = colorCount;
			if (_colorss != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
				object obj3 = (object)baseBody >> 31;
				object obj4 = (object)baseBody + obj3;
				object obj5 = obj4 * 2;
				object obj6 = obj4 + obj5;
				object obj7 = _colorCount - obj6;
				ArcadeSprite arcadeSprite = setTint(colorss[obj7]);
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer = s_scene._renderer;
					if (s_scene._renderer != null)
					{
						object obj8 = renderer.height ^ -0f;
						float num23 = (float)obj8 * 100f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
						if ((object)_renderer != null)
						{
							int sortingOrder = default(int);
							_renderer.sortingOrder = sortingOrder;
							if ((object)_emitter1 != null)
							{
								Transform transform = _emitter1.transform;
								Transform transform2 = base.transform;
								if ((object)transform2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rax_v80 (UnityEngine.Transform)+10]");
									bool flag = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rax_v80 (UnityEngine.Transform)+10]");
									Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
									bool flag2 = (object)transform == null;
									bool flag3 = ((List<string>)(object)transform)._items == null;
									Vector3 value = default(Vector3);
									Transform.set_position_Injected((IntPtr)((List<string>)(object)transform)._items, ref value);
									bool flag4 = (object)_emitter2 == null;
									Transform transform3 = _emitter2.transform;
									Transform transform4 = base.transform;
									bool flag5 = (object)transform4 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1575 @ rax_v92 (UnityEngine.Transform)+10]");
									bool flag6 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1575 @ rax_v92 (UnityEngine.Transform)+10]");
									Transform.get_position_Injected((IntPtr)0, out ret);
									bool flag7 = (object)transform3 == null;
									bool flag8 = ((List<string>)(object)transform3)._items == null;
									Vector3 value2 = default(Vector3);
									Transform.set_position_Injected((IntPtr)((List<string>)(object)transform3)._items, ref value2);
									PhaserScene s_scene2 = ArcadePhysics.s_scene;
									bool flag9 = ArcadePhysics.s_scene == null;
									PhaserScene.Renderer renderer2 = s_scene2._renderer;
									bool flag10 = s_scene2._renderer == null;
									bool flag11 = (object)_pfxManager == null;
									object obj9 = renderer2.height ^ -0f;
									float num24 = (float)obj9 + 1f;
									_pfxManager.SetDepthMultiplied(num24);
									_repeatCount = 0;
									nint num25 = (nint)typeof(Vento2ExploProjectile);
									int num26 = (int)(s_detunesIndex & 0x80000003L);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2741 @ rdx_v80 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Vento2ExploProjectile>)+E4]");
									if ((nint)0 < (nint)0)
									{
										object obj10 = num26 - 1;
										object obj11 = obj10 | -4;
										num26 = obj11 + 1;
									}
									int num27 = s_detunesIndex + 1;
									s_detunesIndex = num27;
									bool flag12 = num26 == 0;
									float num28;
									if (!flag12)
									{
										if (!flag12)
										{
											object obj12 = !flag12;
											num28 = 1f;
											if (obj12 == null)
											{
												num28 = 0.8f;
											}
										}
										else
										{
											num28 = 0.6f;
										}
									}
									else
									{
										num28 = 0.4f;
									}
									float max = num28 * 450f;
									float min = num28 * 350f;
									RenderingExtensions.SetSpeed(_emitter1, min, max);
									float max2 = num28 * 250f;
									float min2 = num28 * 150f;
									RenderingExtensions.SetSpeed(_emitter2, min2, max2);
									float num29 = num28 * 4f;
									ParticleSystem particleSystem = RenderingExtensions.SetScale(_emitter1, num29);
									float num30 = num28 * 4f;
									ParticleSystem particleSystem2 = RenderingExtensions.SetScale(_emitter2, num30);
									SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
									{
										Rate = 1f
									};
									float[] array = s_detunes;
									if (s_detunes != null)
									{
										_ = 0;
										_ = 1065353216;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+208]");
										_ = 0;
										((List<string>)(object)soundConfig)._syncRoot = array[num26];
										((List<string>)(object)soundConfig)._version = 1065353216;
										float time = default(float);
										PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Rose, soundConfig, 0f, 10, time);
										BaseBody baseBody4 = body;
										if (body != null)
										{
											baseBody4._enable = false;
											if (_tween != null)
											{
												_tween.Kill();
											}
											ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
											TweenConfig tweenConfig = new TweenConfig();
											object[] array2 = new object[1];
											if (array2 != null)
											{
												nint num31 = (nint)array2;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj13 = default(object);
												bool flag13 = obj13 == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												if (tweenConfig != null)
												{
													PhaserScene s_scene3 = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene != null)
													{
														PhaserScene.Renderer renderer3 = s_scene3._renderer;
														if (s_scene3._renderer != null)
														{
															_ = 0;
															float num32 = renderer3.height * 100f;
															_ = 1;
															_ = 1135542272;
															_ = 1;
															float num33 = num32 * (1f / 64f);
															_ = 3;
															float num34 = num33 * num28;
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+208]");
															_ = 0;
															_ = 0;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+208]");
															_ = 0;
															TweenCallback tweenCallback = delegate
															{
																//IL_006a: Expected O, but got I
																//IL_0072: Unknown result type (might be due to invalid IL or missing references)
																//IL_0077: Expected O, but got Unknown
																//IL_0080: Unknown result type (might be due to invalid IL or missing references)
																//IL_0085: Expected O, but got Unknown
																//IL_009c: Unknown result type (might be due to invalid IL or missing references)
																//IL_00a1: Expected O, but got Unknown
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
																int repeatCount = _repeatCount + 1;
																_repeatCount = repeatCount;
																uint[] colorss2 = _colorss;
																int colorCount2 = _colorCount + 1;
																_colorCount = colorCount2;
																Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
																nint num35 = default(nint);
																object obj14 = num35 >> 31;
																object obj15 = num35 + obj14;
																object obj16 = obj15 * 2;
																object obj17 = obj15 + obj16;
																object obj18 = _colorCount - obj17;
																ArcadeSprite arcadeSprite3 = setTint(colorss2[obj18]);
																if (_repeatCount > 1)
																{
																	_emitter1.Stop();
																	_emitter2.Stop();
																}
															};
															TweenCallback tweenCallback2 = delegate
															{
																//IL_005d: Expected O, but got I4
																ArcadeSprite arcadeSprite3 = setAlpha(1f);
																ArcadeSprite arcadeSprite4 = setScale(0f, (float?)(object)0);
																RenderingExtensions.Start(_emitter1);
																RenderingExtensions.Start(_emitter2);
																BaseBody baseBody5 = body;
																baseBody5._enable = true;
															};
															TweenCallback tweenCallback3 = delegate
															{
																_emitter1.Stop();
																_emitter2.Stop();
																base.Despawn();
																BaseBody baseBody5 = body;
																baseBody5._enable = false;
															};
															MultiTargetTween tween = Tweens.Add(tweenConfig);
															_tween = tween;
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
		goto IL_1ca5;
		IL_1ca5:
		throw new NullReferenceException();
	}

	private void _003CInitProjectile_003Eb__12_0()
	{
		//IL_006a: Expected O, but got I
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		int repeatCount = _repeatCount + 1;
		_repeatCount = repeatCount;
		uint[] colorss = _colorss;
		int colorCount = _colorCount + 1;
		_colorCount = colorCount;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
		nint num = default(nint);
		object obj = num >> 31;
		object obj2 = num + obj;
		object obj3 = obj2 * 2;
		object obj4 = obj2 + obj3;
		object obj5 = _colorCount - obj4;
		ArcadeSprite arcadeSprite = setTint(colorss[obj5]);
		if (_repeatCount > 1)
		{
			_emitter1.Stop();
			_emitter2.Stop();
		}
	}

	private void _003CInitProjectile_003Eb__12_1()
	{
		//IL_005d: Expected O, but got I4
		ArcadeSprite arcadeSprite = setAlpha(1f);
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		RenderingExtensions.Start(_emitter1);
		RenderingExtensions.Start(_emitter2);
		BaseBody baseBody = body;
		baseBody._enable = true;
	}

	private void _003CInitProjectile_003Eb__12_2()
	{
		_emitter1.Stop();
		_emitter2.Stop();
		base.Despawn();
		BaseBody baseBody = body;
		baseBody._enable = false;
	}
}
