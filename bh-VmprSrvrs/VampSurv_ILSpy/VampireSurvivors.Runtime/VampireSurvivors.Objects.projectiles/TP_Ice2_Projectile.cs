using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Ice2_Projectile : Projectile
{
	private ParticleSystem _rainEmitter1;

	private ParticleSystem _rainEmitter2;

	private Timer rainStopTimer;

	protected override void Awake()
	{
		base.Awake();
		MakeEmitters();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0082: Expected O, but got I4
		//IL_0082: Expected O, but got I4
		//IL_0273: Expected F4, but got I4
		//IL_0322: Expected O, but got I
		//IL_0352: Expected F4, but got I4
		//IL_03e7: Expected O, but got I4
		//IL_02da: Expected O, but got I
		//IL_02fb: Expected F4, but got I4
		//IL_04e6->IL045d: Incompatible stack heights: 1 vs 0
		//IL_037a->IL037a: Incompatible stack heights: 2 vs 0
		//IL_0308->IL04d7: Incompatible stack heights: 2 vs 1
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite sprite = _sprite;
		float time;
		Rectangle source;
		if ((object)_sprite != null && (object)_weapon != null)
		{
			float num = _weapon.PArea();
			if (sprite.body != null)
			{
				object obj = default(object);
				float num2 = (float)obj * 10f;
				BaseBody baseBody = sprite.body.setCircle(num2, (float?)(object)0, (float?)(object)0);
				ArcadeSprite arcadeSprite = setVisible(visible: false);
				BaseBody baseBody2 = body;
				_isCullable = false;
				if (body != null)
				{
					baseBody2._enable = false;
					RenderingExtensions.Start(_rainEmitter1);
					RenderingExtensions.Start(_rainEmitter2);
					if (rainStopTimer != null)
					{
						rainStopTimer.Cancel();
					}
					if ((object)weapon != null)
					{
						float hitBoxDelay = weapon.HitBoxDelay;
						Action onComplete = delegate
						{
							if (rainStopTimer != null)
							{
								rainStopTimer.Cancel();
							}
							_rainEmitter1.Stop();
							_rainEmitter2.Stop();
							Action onComplete2 = delegate
							{
								Despawn();
							};
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
							int repeat2 = default(int);
							TimerType type2 = default(TimerType);
							Timer timer2 = Timers.Register(1f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
							rainStopTimer = timer2;
						};
						float num3 = hitBoxDelay * 0.001f;
						bool flag = default(bool);
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						Timer timer = Timers.Register(num3, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						rainStopTimer = timer;
						if ((object)_weapon != null)
						{
							float num4 = _weapon.PArea();
							float num5 = num3 * 0.96f;
							Rectangle rectangle = new Rectangle();
							rectangle._y = num5;
							rectangle._height = num5;
							rectangle._x = 0f;
							rectangle._width = 0.08f;
							Vector3 euler = default(Vector3);
							Quaternion ret;
							if (_indexInWeapon != 0)
							{
								bool flag2 = _indexInWeapon != 1;
								time = (flag ? 1 : 0);
								source = rectangle;
								if (flag2)
								{
									goto IL_045d;
								}
								Rectangle rectangle2 = new Rectangle();
								rectangle2._height = num5;
								rectangle2._x = 0f;
								rectangle2._width = 0.08f;
								Transform transform = base.transform;
								Quaternion.Internal_FromEulerRad_Injected(ref euler, out ret);
								bool flag3 = (object)transform == null;
								IntPtr cachedPtr = ((UnityEngine.Object)transform).m_CachedPtr;
								bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								object obj2 = 0;
								object obj3 = ret;
								float num6 = (float)Math.PI;
								object obj4 = ret;
								time = (flag ? 1 : 0);
								source = rectangle2;
							}
							else
							{
								Transform transform2 = base.transform;
								Quaternion.Internal_FromEulerRad_Injected(ref euler, out ret);
								IntPtr cachedPtr = ((UnityEngine.Object)transform2).m_CachedPtr;
								bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								object obj2 = 0;
								bool flag6 = (nint)0 != 0;
								object obj3 = ret;
								float num6 = num2;
								object obj4 = ret;
								time = (flag ? 1 : 0);
								source = rectangle;
								if (!flag6)
								{
									bool flag7 = (nint)0 == 0;
									goto IL_037f;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1202 @ rax_v43 (should have been resolved before IL gen)");
							goto IL_045d;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_045d:
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = source;
		goto IL_037f;
		IL_037f:
		RenderingExtensions.SetEmitZone(_rainEmitter1, emitZone);
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Random;
		emitZone2._source = source;
		RenderingExtensions.SetEmitZone(_rainEmitter2, emitZone2);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Cocytus, soundConfig, 1000f, 1, time);
	}

	private void StartDespawn()
	{
		if (rainStopTimer != null)
		{
			rainStopTimer.Cancel();
		}
		_rainEmitter1.Stop();
		_rainEmitter2.Stop();
		Action onComplete = delegate
		{
			Despawn();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		rainStopTimer = timer;
	}

	public override void Despawn()
	{
		if (rainStopTimer != null)
		{
			rainStopTimer.Cancel();
		}
		_rainEmitter1.Stop();
		_rainEmitter2.Stop();
		base.Despawn();
	}

	private unsafe void MakeEmitters()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected F4, but got Unknown
		//IL_046c: Expected O, but got I4
		//IL_0493: Expected O, but got I4
		//IL_04ac: Expected O, but got Ref
		//IL_04c6: Expected native int or pointer, but got O
		//IL_0d62: Expected O, but got I
		//IL_04fe: Expected O, but got Ref
		//IL_0518: Expected native int or pointer, but got O
		//IL_0532: Expected O, but got I
		//IL_0552: Expected O, but got Ref
		//IL_056c: Expected native int or pointer, but got O
		//IL_0586: Expected O, but got I
		//IL_05a6: Expected O, but got Ref
		//IL_05c7: Expected O, but got I
		//IL_05e1: Expected native int or pointer, but got O
		//IL_05fb: Expected O, but got I
		//IL_061b: Expected O, but got Ref
		//IL_0642: Expected O, but got I
		//IL_065c: Expected native int or pointer, but got O
		//IL_0d9c: Expected O, but got I
		//IL_0694: Expected O, but got Ref
		//IL_06ae: Expected native int or pointer, but got O
		//IL_0dd6: Expected O, but got I
		//IL_0736: Expected O, but got I
		//IL_0929: Expected O, but got I4
		//IL_0950: Expected O, but got I4
		//IL_0969: Expected O, but got Ref
		//IL_0983: Expected native int or pointer, but got O
		//IL_099e: Expected O, but got I
		//IL_0e22: Expected O, but got I
		//IL_09be: Expected O, but got Ref
		//IL_09df: Expected O, but got I
		//IL_09f9: Expected native int or pointer, but got O
		//IL_0a13: Expected O, but got I
		//IL_0a33: Expected O, but got Ref
		//IL_0a5a: Expected O, but got I
		//IL_0a74: Expected native int or pointer, but got O
		//IL_0e5c: Expected O, but got I
		//IL_0aac: Expected O, but got Ref
		//IL_0ac6: Expected native int or pointer, but got O
		//IL_0e96: Expected O, but got I
		//IL_0afe: Expected O, but got Ref
		//IL_0b18: Expected native int or pointer, but got O
		//IL_0ed0: Expected O, but got I
		//IL_0b92: Expected O, but got I
		//IL_0c0b: Expected I4, but got I8
		//IL_0f7a: Expected I4, but got I8
		//IL_0f96: Expected O, but got I
		//IL_100b: Expected O, but got Ref
		//IL_0fd5: Expected O, but got I
		//IL_1042: Expected O, but got Ref
		//IL_102f->IL0cd4: Incompatible stack heights: 2 vs 0
		//IL_0c9b->IL0ffd: Incompatible stack heights: 3 vs 2
		//IL_0cd4->IL1034: Incompatible stack heights: 3 vs 2
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null && (object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer2 = s_scene2._renderer;
						if (s_scene2._renderer != null)
						{
							Rectangle rectangle = new Rectangle();
							float num = renderer2.screenWidth * 0.5f;
							float width = renderer.screenWidth * 1.5f;
							rectangle._y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
							float x = num ^ 0;
							rectangle._x = x;
							rectangle._width = width;
							rectangle._height = 0.64f;
							ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("ThosePeople");
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
										((List<object>)(object)list).AddWithResize((object)"TP_VFX_Ice27");
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
											((List<object>)(object)list).AddWithResize((object)"TP_VFX_Ice28");
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
												((List<object>)(object)list).AddWithResize((object)"TP_VFX_Ice29");
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
													((List<object>)(object)list).AddWithResize((object)"TP_VFX_Ice30");
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
													ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
													particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
													_ = 0;
													minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
													particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(200f, 800f));
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+98]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A8]");
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
													particleSystemConfig._speedX = (ParticleSystem.MinMaxCurve?)(object)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B8]");
													particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C8]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f, 360f));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D8]");
													particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E8]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 248));
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+280]");
													particleSystemConfig._blendMode = (BlendMode?)(object)0;
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(400f, 1000f));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F8]");
													particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+108]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
													_ = 0;
													_ = 20;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+280]");
													particleSystemConfig._quantity = (int?)(object)0;
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 1f));
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+118]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+128]");
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
													particleSystemConfig._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 312));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(2f, 0f));
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+138]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+148]");
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
													particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-10]");
													_ = 0;
													EmitZone emitZone = new EmitZone();
													emitZone._type = EmitZoneType.Random;
													emitZone._source = rectangle;
													particleSystemConfig._emitZone = emitZone;
													_ = 0;
													particleSystemConfig._on = true;
													_ = 1120403456;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+280]");
													particleSystemConfig._frequency = (float?)(object)0;
													ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("ThosePeople");
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
																((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Ice25");
															}
															else
															{
																int num6 = list2._size + 1;
																list2._size = num6;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															int version6 = list2._version + 1;
															list2._version = version6;
															string[] items6 = list2._items;
															if (list2._items != null)
															{
																if (list2._size >= items6.Length)
																{
																	((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Ice26");
																}
																else
																{
																	int num7 = list2._size + 1;
																	list2._size = num7;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																}
																if (particleSystemConfig2 != null)
																{
																	particleSystemConfig2._frame = list2;
																	minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
																	particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
																	_ = 0;
																	minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
																	particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
																	_ = 0;
																	ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 344));
																	_ = 0;
																	_ = 0;
																	System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(400f, 800f));
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+158]");
																	obj = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+168]");
																	_ = 0;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
																	particleSystemConfig2._speedX = (ParticleSystem.MinMaxCurve?)(object)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
																	_ = 0;
																	ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 376));
																	_ = 0;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+280]");
																	particleSystemConfig2._blendMode = (BlendMode?)(object)0;
																	_ = 0;
																	_ = 0;
																	System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(400f, 600f));
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+178]");
																	particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+188]");
																	_ = 0;
																	ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 408));
																	_ = 0;
																	_ = 10;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+280]");
																	particleSystemConfig2._quantity = (int?)(object)0;
																	_ = 0;
																	_ = 0;
																	System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(1f, 4f));
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+198]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1A8]");
																	_ = 0;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+20]");
																	particleSystemConfig2._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+30]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+40]");
																	_ = 0;
																	ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 440));
																	_ = 0;
																	_ = 0;
																	System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(1f, 1f));
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1B8]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1C8]");
																	_ = 0;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
																	particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
																	_ = 0;
																	ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 472));
																	_ = 0;
																	_ = 0;
																	System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(0.15f, 0.35f));
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1D8]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1E8]");
																	_ = 0;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+70]");
																	particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
																	_ = 0;
																	EmitZone emitZone2 = new EmitZone();
																	emitZone2._type = EmitZoneType.Random;
																	emitZone2._source = rectangle;
																	particleSystemConfig2._emitZone = emitZone2;
																	_ = 0;
																	_ = 1120403456;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+280]");
																	particleSystemConfig2._frequency = (float?)(object)0;
																	particleSystemConfig2._on = true;
																	Transform parent = base.transform;
																	ParticleSystem rainEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent, "_glitchEmitterIce");
																	_rainEmitter1 = rainEmitter;
																	Transform transform = _rainEmitter1.transform;
																	bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
																	Vector3 value = default(Vector3);
																	Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
																	RenderingExtensions.SetDepth(_rainEmitter1, -1992);
																	Transform parent2 = base.transform;
																	ParticleSystem rainEmitter2 = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig2, parent2, "_glitchEmitterIce");
																	_rainEmitter2 = rainEmitter2;
																	Transform transform2 = _rainEmitter2.transform;
																	bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																	Vector3 value2 = default(Vector3);
																	Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
																	RenderingExtensions.SetDepth(_rainEmitter2, -1993);
																	_ = _rainEmitter1;
																	_ = _rainEmitter1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																	object obj3 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																	if ((nint)0 == 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																		bool flag3 = obj3 == null;
																	}
																	object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 648));
																	Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3420 @ rax_v127 (should have been resolved before IL gen)");
																	if ((object)_rainEmitter2 != null)
																	{
																		_ = _rainEmitter2;
																		_ = _rainEmitter2;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																		object obj5 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																		if ((nint)0 == 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																			bool flag4 = obj5 == null;
																		}
																		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 648));
																		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3507 @ rax_v132 (should have been resolved before IL gen)");
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
		throw new NullReferenceException();
	}

	private void _003CInitProjectile_003Eb__4_0()
	{
		if (rainStopTimer != null)
		{
			rainStopTimer.Cancel();
		}
		_rainEmitter1.Stop();
		_rainEmitter2.Stop();
		Action onComplete = delegate
		{
			Despawn();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		rainStopTimer = timer;
	}

	private void _003CStartDespawn_003Eb__5_0()
	{
		Despawn();
	}
}
