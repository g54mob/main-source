using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyBeelzebub : EnemyController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__55_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CDoDeathAnimation_003Eb__55_0()
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 500f, 20, 0f, volume, rate, detune, loop, 1f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass55_0
	{
		public EnemyBeelzebub _003C_003E4__this;

		public ParticleSystem pfxEmitter;

		public EmitZone emitZone;

		public ParticleEmitterManager particleManager;

		internal unsafe void _003CDoDeathAnimation_003Eb__1()
		{
			//IL_0008: Expected O, but got Ref
			//IL_08d7: Expected O, but got Ref
			//IL_08fa: Expected native int or pointer, but got O
			//IL_0914: Expected O, but got I
			//IL_0934: Expected O, but got Ref
			//IL_094e: Expected native int or pointer, but got O
			//IL_0968: Expected O, but got I
			//IL_0988: Expected O, but got Ref
			//IL_09a2: Expected native int or pointer, but got O
			//IL_09bc: Expected O, but got I
			//IL_09dc: Expected O, but got Ref
			//IL_09f6: Expected native int or pointer, but got O
			//IL_0d26: Expected O, but got I4
			//IL_0a1b: Expected O, but got Ref
			//IL_0a42: Expected O, but got I
			//IL_0a5c: Expected native int or pointer, but got O
			//IL_0d60: Expected O, but got I
			//IL_0a9a: Expected O, but got Ref
			//IL_0abb: Expected O, but got I
			//IL_0ad5: Expected native int or pointer, but got O
			//IL_0d9a: Expected O, but got I
			//IL_0cb0: Expected I, but got O
			//IL_0c4c: Expected O, but got I
			//IL_0e31->IL0ce8: Incompatible stack heights: 1 vs 2
			object obj2 = default(object);
			object obj = (object)(&obj2);
			_003C_003Ec__DisplayClass55_1 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass55_1();
			if ((object)_003C_003E4__this != null)
			{
				ArcadeSprite arcadeSprite = _003C_003E4__this.setVisible(visible: false);
				if ((object)this.pfxEmitter != null)
				{
					this.pfxEmitter.Stop();
					Circle circle = new Circle();
					circle._x = 0f;
					circle._radius = 16f;
					EmitZone emitZone = new EmitZone();
					emitZone._type = EmitZoneType.Random;
					emitZone._source = circle;
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
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire19");
							}
							else
							{
								int size = list._size + 1;
								list._size = size;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							int version2 = list._version + 1;
							list._version = version2;
							string[] items2 = list._items;
							if (list._items != null)
							{
								if (list._size >= items2.Length)
								{
									((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire20");
								}
								else
								{
									int size2 = list._size + 1;
									list._size = size2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								int version3 = list._version + 1;
								list._version = version3;
								string[] items3 = list._items;
								if (list._items != null)
								{
									if (list._size >= items3.Length)
									{
										((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire21");
									}
									else
									{
										int size3 = list._size + 1;
										list._size = size3;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									}
									int version4 = list._version + 1;
									list._version = version4;
									string[] items4 = list._items;
									if (list._items != null)
									{
										if (list._size >= items4.Length)
										{
											((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire22");
										}
										else
										{
											int size4 = list._size + 1;
											list._size = size4;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										int version5 = list._version + 1;
										list._version = version5;
										string[] items5 = list._items;
										if (list._items != null)
										{
											if (list._size >= items5.Length)
											{
												((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire23");
											}
											else
											{
												int size5 = list._size + 1;
												list._size = size5;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											}
											int version6 = list._version + 1;
											list._version = version6;
											string[] items6 = list._items;
											if (list._items != null)
											{
												if (list._size >= items6.Length)
												{
													((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire24");
												}
												else
												{
													int size6 = list._size + 1;
													list._size = size6;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												}
												int version7 = list._version + 1;
												list._version = version7;
												string[] items7 = list._items;
												if (list._items != null)
												{
													if (list._size >= items7.Length)
													{
														((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire25");
													}
													else
													{
														int size7 = list._size + 1;
														list._size = size7;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													}
													int version8 = list._version + 1;
													list._version = version8;
													string[] items8 = list._items;
													if (list._items != null)
													{
														if (list._size >= items8.Length)
														{
															((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire26");
														}
														else
														{
															int size8 = list._size + 1;
															list._size = size8;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														}
														int version9 = list._version + 1;
														list._version = version9;
														string[] items9 = list._items;
														if (list._items != null)
														{
															if (list._size >= items9.Length)
															{
																((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire27");
															}
															else
															{
																int size9 = list._size + 1;
																list._size = size9;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															int version10 = list._version + 1;
															list._version = version10;
															string[] items10 = list._items;
															if (list._items != null)
															{
																if (list._size >= items10.Length)
																{
																	((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire28");
																}
																else
																{
																	int size10 = list._size + 1;
																	list._size = size10;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																}
																int version11 = list._version + 1;
																list._version = version11;
																string[] items11 = list._items;
																if (list._items != null)
																{
																	if (list._size >= items11.Length)
																	{
																		((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire29");
																	}
																	else
																	{
																		int size11 = list._size + 1;
																		list._size = size11;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	}
																	if (particleSystemConfig != null)
																	{
																		particleSystemConfig._frame = list;
																		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
																		particleSystemConfig._fps = 16;
																		_ = 0;
																		_ = 0;
																		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(500f));
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
																		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
																		_ = 0;
																		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
																		_ = 0;
																		_ = 0;
																		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
																		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
																		_ = 0;
																		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
																		_ = 0;
																		_ = 0;
																		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(-80f, -100f));
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
																		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
																		_ = 0;
																		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
																		_ = 0;
																		_ = 0;
																		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(200f, 400f));
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
																		_ = 0;
																		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
																		_ = 0;
																		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
																		_ = 0;
																		_ = 5;
																		_ = 1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
																		particleSystemConfig._quantity = (int?)(object)0;
																		_ = 0;
																		_ = 0;
																		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 1f));
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
																		_ = 0;
																		_ = 1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
																		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
																		_ = 0;
																		_ = 0;
																		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
																		_ = 1065353216;
																		_ = 1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
																		particleSystemConfig._frequency = (float?)(object)0;
																		_ = 0;
																		_ = 0;
																		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+98]");
																		_ = 0;
																		_ = 1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
																		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
																		_ = 0;
																		particleSystemConfig._emitZone = this.emitZone;
																		particleSystemConfig._on = true;
																		ParticleSystem pfxEmitter = particleManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter2");
																		CS_0024_003C_003E8__locals4.pfxEmitter2 = pfxEmitter;
																		Transform transform = CS_0024_003C_003E8__locals4.pfxEmitter2.transform;
																		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
																		Vector3 value = default(Vector3);
																		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
																		RenderingExtensions.Start(CS_0024_003C_003E8__locals4.pfxEmitter2);
																		Action onComplete = delegate
																		{
																			CS_0024_003C_003E8__locals4.pfxEmitter2.Stop();
																		};
																		bool useRealTime = default(bool);
																		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																		int repeat = default(int);
																		TimerType type = default(TimerType);
																		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																		EnemyBeelzebub enemyBeelzebub = _003C_003E4__this;
																		CoherenceSync coherenceSync = enemyBeelzebub._coherenceSync;
																		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
																		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
																		{
																			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rcx_v75 (Coherence.Toolkit.ObservableAuthorityType)+10]");
																			bool flag2 = false;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rcx_v75 (Coherence.Toolkit.ObservableAuthorityType)+10]");
																			if ((nint)0 != 1)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rcx_v75 (Coherence.Toolkit.ObservableAuthorityType)+10]");
																				object obj3 = -3;
																				bool flag3 = obj3 == null;
																				flag2 = flag3;
																			}
																			if (!flag2)
																			{
																				return;
																			}
																		}
																		object obj4 = _003C_003E4__this;
																		EnemyBeelzebub enemyBeelzebub2 = _003C_003E4__this;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ r8_v48 (Il2CppClass<System.Object>)+3A0]");
																		Action onComplete2 = new Action(enemyBeelzebub2, (IntPtr)0);
																		bool flag4 = (object)_003C_003E4__this == null;
																		nint num = (nint)obj4;
																		Timer timer2 = Timers.Register(2f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
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
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass55_1
	{
		public ParticleSystem pfxEmitter2;

		internal void _003CDoDeathAnimation_003Eb__2()
		{
			pfxEmitter2.Stop();
		}
	}

	private List<EnemyBeelzebubSection> _sections;

	private EnemyBeelzebubSection _head;

	private EnemyBeelzebubSection _leftArm;

	private EnemyBeelzebubSection _leftHand;

	private EnemyBeelzebubSection _rightArm;

	private EnemyBeelzebubSection _rightHand;

	private EnemyBeelzebubSection _leftThigh;

	private EnemyBeelzebubSection _leftLeg;

	private EnemyBeelzebubSection _rightThigh;

	private EnemyBeelzebubSection _rightLeg;

	private EnemyBeelzebubSection _belly;

	private List<EnemyBeelzebubBee> _beeList;

	private float _beeTimer;

	private PhaserSprite[] _torsoChains;

	private bool _isRunningDeathAnimation;

	public List<EnemyBeelzebubSection> Sections => _sections;

	public GameObject Head
	{
		get
		{
			EnemyBeelzebubSection head = _head;
			if ((object)_head != null && ((UnityEngine.Object)head).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_head != null)
				{
					return _head.gameObject;
				}
				return (GameObject)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyBeelzebubSection component = value.GetComponent<EnemyBeelzebubSection>();
				_head = component;
			}
			else
			{
				_head = null;
			}
		}
	}

	public GameObject LeftArm
	{
		get
		{
			EnemyBeelzebubSection leftArm = _leftArm;
			if ((object)_leftArm != null && ((UnityEngine.Object)leftArm).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_leftArm != null)
				{
					return _leftArm.gameObject;
				}
				return (GameObject)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyBeelzebubSection component = value.GetComponent<EnemyBeelzebubSection>();
				_leftArm = component;
			}
			else
			{
				_leftArm = null;
			}
		}
	}

	public GameObject LeftHand
	{
		get
		{
			EnemyBeelzebubSection leftHand = _leftHand;
			if ((object)_leftHand != null && ((UnityEngine.Object)leftHand).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_leftHand != null)
				{
					return _leftHand.gameObject;
				}
				return (GameObject)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyBeelzebubSection component = value.GetComponent<EnemyBeelzebubSection>();
				_leftHand = component;
			}
			else
			{
				_leftHand = null;
			}
		}
	}

	public GameObject RightArm
	{
		get
		{
			EnemyBeelzebubSection rightArm = _rightArm;
			if ((object)_rightArm != null && ((UnityEngine.Object)rightArm).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_rightArm != null)
				{
					return _rightArm.gameObject;
				}
				return (GameObject)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyBeelzebubSection component = value.GetComponent<EnemyBeelzebubSection>();
				_rightArm = component;
			}
			else
			{
				_rightArm = null;
			}
		}
	}

	public GameObject RightHand
	{
		get
		{
			EnemyBeelzebubSection rightHand = _rightHand;
			if ((object)_rightHand != null && ((UnityEngine.Object)rightHand).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_rightHand != null)
				{
					return _rightHand.gameObject;
				}
				return (GameObject)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyBeelzebubSection component = value.GetComponent<EnemyBeelzebubSection>();
				_rightHand = component;
			}
			else
			{
				_rightHand = null;
			}
		}
	}

	public GameObject LeftThigh
	{
		get
		{
			EnemyBeelzebubSection leftThigh = _leftThigh;
			if ((object)_leftThigh != null && ((UnityEngine.Object)leftThigh).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_leftThigh != null)
				{
					return _leftThigh.gameObject;
				}
				return (GameObject)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyBeelzebubSection component = value.GetComponent<EnemyBeelzebubSection>();
				_leftThigh = component;
			}
			else
			{
				_leftThigh = null;
			}
		}
	}

	public GameObject LeftLeg
	{
		get
		{
			EnemyBeelzebubSection leftLeg = _leftLeg;
			if ((object)_leftLeg != null && ((UnityEngine.Object)leftLeg).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_leftLeg != null)
				{
					return _leftLeg.gameObject;
				}
				return (GameObject)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyBeelzebubSection component = value.GetComponent<EnemyBeelzebubSection>();
				_leftLeg = component;
			}
			else
			{
				_leftLeg = null;
			}
		}
	}

	public GameObject RightThigh
	{
		get
		{
			EnemyBeelzebubSection rightThigh = _rightThigh;
			if ((object)_rightThigh != null && ((UnityEngine.Object)rightThigh).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_rightThigh != null)
				{
					return _rightThigh.gameObject;
				}
				return (GameObject)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyBeelzebubSection component = value.GetComponent<EnemyBeelzebubSection>();
				_rightThigh = component;
			}
			else
			{
				_rightThigh = null;
			}
		}
	}

	public GameObject RightLeg
	{
		get
		{
			EnemyBeelzebubSection rightLeg = _rightLeg;
			if ((object)_rightLeg != null && ((UnityEngine.Object)rightLeg).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_rightLeg != null)
				{
					return _rightLeg.gameObject;
				}
				return (GameObject)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyBeelzebubSection component = value.GetComponent<EnemyBeelzebubSection>();
				_rightLeg = component;
			}
			else
			{
				_rightLeg = null;
			}
		}
	}

	public GameObject Belly
	{
		get
		{
			EnemyBeelzebubSection belly = _belly;
			if ((object)_belly != null && ((UnityEngine.Object)belly).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_belly != null)
				{
					return _belly.gameObject;
				}
				return (GameObject)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				EnemyBeelzebubSection component = value.GetComponent<EnemyBeelzebubSection>();
				_belly = component;
			}
			else
			{
				_belly = null;
			}
		}
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_015f: Expected O, but got I4
		//IL_01ae: Expected O, but got I4
		//IL_01ae: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		if ((object)stage._tilingTileset != null && ((UnityEngine.Object)tilingTileset).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			List<Vector2> specialLocations = stage2._tilingTileset.GetSpecialLocations("BeelzebubSpawn");
			if (specialLocations != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
					float2 float5 = default(float2);
					base.position = float5;
				}
			}
		}
		base.InitEnemy(enemyType, asRemote);
		List<EnemyBeelzebubBee> beeList = new List<EnemyBeelzebubBee>();
		_beeList = beeList;
		List<EnemyBeelzebubSection> sections = new List<EnemyBeelzebubSection>();
		_sections = sections;
		base._003CIsCullable_003Ek__BackingField = false;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
		ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
		Sprite sprite = SpriteManager.GetSprite("Beelzebub_Torso", "Beelzebub");
		ArcadeSprite arcadeSprite2 = setFrame(sprite);
		BaseBody baseBody = body.setCircle(28f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._immovable = true;
		BaseBody baseBody3 = body;
		baseBody3._pushable = false;
		SpawnBodyParts();
		_beeTimer = 0f;
		_isRunningDeathAnimation = false;
		ArcadeSprite arcadeSprite3 = setVisible(visible: true);
	}

	private void SpawnBodyParts()
	{
		//IL_006c: Expected I, but got O
		//IL_0109: Expected I, but got O
		//IL_01b3: Expected O, but got I
		PhaserSprite[] torsoChains = new PhaserSprite[2];
		_torsoChains = torsoChains;
		PhaserSprite[] torsoChains2 = _torsoChains;
		PhaserWorld instance = PhaserWorld.Instance;
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "Beelzebub", "Beelzebub_Chain");
		if ((object)phaserSprite != null)
		{
			nint num = (nint)torsoChains2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		PhaserSprite[] torsoChains3 = _torsoChains;
		PhaserWorld instance2 = PhaserWorld.Instance;
		float2 float6 = base.position;
		PhaserSprite phaserSprite2 = instance2.AddPhaserSprite(pos, "Beelzebub", "Beelzebub_Chain");
		if ((object)phaserSprite2 != null)
		{
			nint num2 = (nint)torsoChains3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rcx_v162 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rcx_v162 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rcx_v162 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj3 = -3;
				bool flag2 = obj3 == null;
				flag = flag2;
			}
			if (!flag)
			{
				goto IL_0a51;
			}
		}
		GameManager core = GM.Core;
		float2 float7 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		EnemyBeelzebubSection head = default(EnemyBeelzebubSection);
		_head = head;
		GameManager core2 = GM.Core;
		bool isOnlineMultiplayer = core2._multiplayer.IsOnlineMultiplayer;
		EnemyBeelzebubSection head2 = _head;
		bool flag3 = default(bool);
		object param = default(object);
		bool param2 = default(bool);
		if (!isOnlineMultiplayer)
		{
			head2.SetupBeelzebubSection(this, hasChains: true, "Beelzebub_Head1", flag3);
		}
		else
		{
			Action<CoherenceSync, bool, string, bool> action = new Action<object, bool, object, bool>(_head.OnlineSetupSection);
			bool flag4 = ((EnemyController)head2)._coherenceSync.SendCommand((Action<object, bool, object, bool>)action, MessageTarget.All, _coherenceSync, flag3, param, param2);
		}
		GameManager core3 = GM.Core;
		float2 float8 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		EnemyBeelzebubSection leftArm = default(EnemyBeelzebubSection);
		_leftArm = leftArm;
		GameManager core4 = GM.Core;
		bool isOnlineMultiplayer2 = core4._multiplayer.IsOnlineMultiplayer;
		EnemyBeelzebubSection leftArm2 = _leftArm;
		if (!isOnlineMultiplayer2)
		{
			leftArm2.SetupBeelzebubSection(this, hasChains: true, "Beelzebub_LeftArm", flag3);
		}
		else
		{
			Action<CoherenceSync, bool, string, bool> action2 = new Action<object, bool, object, bool>(_leftArm.OnlineSetupSection);
			bool flag5 = ((EnemyController)leftArm2)._coherenceSync.SendCommand((Action<object, bool, object, bool>)action2, MessageTarget.All, _coherenceSync, flag3, param, param2);
		}
		GameManager core5 = GM.Core;
		float2 float9 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		EnemyBeelzebubSection leftHand = default(EnemyBeelzebubSection);
		_leftHand = leftHand;
		GameManager core6 = GM.Core;
		bool isOnlineMultiplayer3 = core6._multiplayer.IsOnlineMultiplayer;
		EnemyBeelzebubSection leftHand2 = _leftHand;
		if (!isOnlineMultiplayer3)
		{
			leftHand2.SetupBeelzebubSection(this, hasChains: false, "Beelzebub_LeftArm", flag3);
		}
		else
		{
			Action<CoherenceSync, bool, string, bool> action3 = new Action<object, bool, object, bool>(_leftHand.OnlineSetupSection);
			bool flag6 = ((EnemyController)leftHand2)._coherenceSync.SendCommand((Action<object, bool, object, bool>)action3, MessageTarget.All, _coherenceSync, flag3, param, param2);
		}
		GameManager core7 = GM.Core;
		float2 float10 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		EnemyBeelzebubSection rightArm = default(EnemyBeelzebubSection);
		_rightArm = rightArm;
		GameManager core8 = GM.Core;
		bool isOnlineMultiplayer4 = core8._multiplayer.IsOnlineMultiplayer;
		EnemyBeelzebubSection rightArm2 = _rightArm;
		if (!isOnlineMultiplayer4)
		{
			rightArm2.SetupBeelzebubSection(this, hasChains: false, "Beelzebub_RightArm", flag3);
		}
		else
		{
			Action<CoherenceSync, bool, string, bool> action4 = new Action<object, bool, object, bool>(_rightArm.OnlineSetupSection);
			bool flag7 = ((EnemyController)rightArm2)._coherenceSync.SendCommand((Action<object, bool, object, bool>)action4, MessageTarget.All, _coherenceSync, flag3, param, param2);
		}
		GameManager core9 = GM.Core;
		float2 float11 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		EnemyBeelzebubSection rightHand = default(EnemyBeelzebubSection);
		_rightHand = rightHand;
		GameManager core10 = GM.Core;
		bool isOnlineMultiplayer5 = core10._multiplayer.IsOnlineMultiplayer;
		EnemyBeelzebubSection rightHand2 = _rightHand;
		if (!isOnlineMultiplayer5)
		{
			rightHand2.SetupBeelzebubSection(this, hasChains: false, "Beelzebub_RightHand", flag3);
		}
		else
		{
			Action<CoherenceSync, bool, string, bool> action5 = new Action<object, bool, object, bool>(_rightHand.OnlineSetupSection);
			bool flag8 = ((EnemyController)rightHand2)._coherenceSync.SendCommand((Action<object, bool, object, bool>)action5, MessageTarget.All, _coherenceSync, flag3, param, param2);
		}
		GameManager core11 = GM.Core;
		float2 float12 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		EnemyBeelzebubSection leftThigh = default(EnemyBeelzebubSection);
		_leftThigh = leftThigh;
		GameManager core12 = GM.Core;
		bool isOnlineMultiplayer6 = core12._multiplayer.IsOnlineMultiplayer;
		EnemyBeelzebubSection leftThigh2 = _leftThigh;
		if (!isOnlineMultiplayer6)
		{
			leftThigh2.SetupBeelzebubSection(this, hasChains: true, "Beelzebub_LeftThigh", flag3);
		}
		else
		{
			Action<CoherenceSync, bool, string, bool> action6 = new Action<object, bool, object, bool>(_leftThigh.OnlineSetupSection);
			bool flag9 = ((EnemyController)leftThigh2)._coherenceSync.SendCommand((Action<object, bool, object, bool>)action6, MessageTarget.All, _coherenceSync, flag3, param, param2);
		}
		GameManager core13 = GM.Core;
		float2 float13 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		EnemyBeelzebubSection leftLeg = default(EnemyBeelzebubSection);
		_leftLeg = leftLeg;
		GameManager core14 = GM.Core;
		bool isOnlineMultiplayer7 = core14._multiplayer.IsOnlineMultiplayer;
		EnemyBeelzebubSection leftLeg2 = _leftLeg;
		if (!isOnlineMultiplayer7)
		{
			leftLeg2.SetupBeelzebubSection(this, hasChains: false, "Beelzebub_LeftLeg", flag3);
		}
		else
		{
			Action<CoherenceSync, bool, string, bool> action7 = new Action<object, bool, object, bool>(_leftLeg.OnlineSetupSection);
			bool flag10 = ((EnemyController)leftLeg2)._coherenceSync.SendCommand((Action<object, bool, object, bool>)action7, MessageTarget.All, _coherenceSync, flag3, param, param2);
		}
		GameManager core15 = GM.Core;
		float2 float14 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		EnemyBeelzebubSection rightThigh = default(EnemyBeelzebubSection);
		_rightThigh = rightThigh;
		GameManager core16 = GM.Core;
		bool isOnlineMultiplayer8 = core16._multiplayer.IsOnlineMultiplayer;
		EnemyBeelzebubSection rightThigh2 = _rightThigh;
		if (!isOnlineMultiplayer8)
		{
			rightThigh2.SetupBeelzebubSection(this, hasChains: true, "Beelzebub_RightThigh", flag3);
		}
		else
		{
			Action<CoherenceSync, bool, string, bool> action8 = new Action<object, bool, object, bool>(_rightThigh.OnlineSetupSection);
			bool flag11 = ((EnemyController)rightThigh2)._coherenceSync.SendCommand((Action<object, bool, object, bool>)action8, MessageTarget.All, _coherenceSync, flag3, param, param2);
		}
		GameManager core17 = GM.Core;
		float2 float15 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		EnemyBeelzebubSection rightLeg = default(EnemyBeelzebubSection);
		_rightLeg = rightLeg;
		GameManager core18 = GM.Core;
		bool isOnlineMultiplayer9 = core18._multiplayer.IsOnlineMultiplayer;
		EnemyBeelzebubSection rightLeg2 = _rightLeg;
		if (!isOnlineMultiplayer9)
		{
			rightLeg2.SetupBeelzebubSection(this, hasChains: false, "Beelzebub_RightLeg", flag3);
		}
		else
		{
			Action<CoherenceSync, bool, string, bool> action9 = new Action<object, bool, object, bool>(_rightLeg.OnlineSetupSection);
			bool flag12 = ((EnemyController)rightLeg2)._coherenceSync.SendCommand((Action<object, bool, object, bool>)action9, MessageTarget.All, _coherenceSync, flag3, param, param2);
		}
		GameManager core19 = GM.Core;
		float2 float16 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		EnemyBeelzebubSection belly = default(EnemyBeelzebubSection);
		_belly = belly;
		GameManager core20 = GM.Core;
		bool isOnlineMultiplayer10 = core20._multiplayer.IsOnlineMultiplayer;
		EnemyBeelzebubSection belly2 = _belly;
		if (!isOnlineMultiplayer10)
		{
			belly2.SetupBeelzebubSection(this, hasChains: true, "Beelzebub_Belly", flag3);
		}
		else
		{
			Action<CoherenceSync, bool, string, bool> action10 = new Action<object, bool, object, bool>(_belly.OnlineSetupSection);
			bool flag13 = ((EnemyController)belly2)._coherenceSync.SendCommand((Action<object, bool, object, bool>)action10, MessageTarget.All, _coherenceSync, flag3, param, param2);
		}
		goto IL_0a51;
		IL_0a51:
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2274 Invalid \"Jump target not found in method: 0x187694A20\"");
		throw new NullReferenceException();
	}

	private unsafe void UpdateBodyParts()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0036: Expected O, but got I
		//IL_0036: Expected O, but got I
		//IL_017f: Expected O, but got I4
		//IL_04b9: Expected O, but got I4
		//IL_1aca: Expected O, but got I
		//IL_0a45: Expected O, but got I4
		//IL_1b67: Expected O, but got I
		//IL_107e: Expected O, but got I4
		//IL_16a9: Expected O, but got I4
		//IL_1c80: Expected I, but got O
		//IL_1c9f: Expected O, but got I
		//IL_2e43: Expected O, but got I
		//IL_3168: Expected O, but got I
		//IL_21ef: Expected O, but got I4
		//IL_3a52: Expected O, but got I
		//IL_28ad: Expected O, but got I4
		//IL_1d6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d72: Expected O, but got Unknown
		//IL_1d10: Expected F4, but got I4
		//IL_35bd: Expected O, but got I
		//IL_2ec4: Expected F4, but got I4
		//IL_3aef: Expected O, but got I
		//IL_365a: Expected O, but got I
		//IL_325f: Expected O, but got I
		//IL_332d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3332: Expected O, but got Unknown
		//IL_32d0: Expected F4, but got I4
		//IL_3c08: Expected I, but got O
		//IL_3c27: Expected O, but got I
		//IL_3773: Expected I, but got O
		//IL_3792: Expected O, but got I
		//IL_3e54->IL3daf: Incompatible stack heights: 1 vs 0
		//IL_0252->IL3daf: Incompatible stack heights: 1 vs 0
		//IL_0274->IL3daf: Incompatible stack heights: 1 vs 0
		//IL_02af->IL3daf: Incompatible stack heights: 1 vs 0
		//IL_02d6->IL3daf: Incompatible stack heights: 1 vs 0
		//IL_0317->IL3daf: Incompatible stack heights: 1 vs 0
		//IL_0365->IL3daf: Incompatible stack heights: 1 vs 0
		//IL_0398->IL3daf: Incompatible stack heights: 1 vs 0
		//IL_03c9->IL3daf: Incompatible stack heights: 1 vs 0
		//IL_040f->IL3daf: Incompatible stack heights: 1 vs 0
		//IL_0439->IL3daf: Incompatible stack heights: 1 vs 0
		//IL_0470->IL3daf: Incompatible stack heights: 1 vs 0
		//IL_0497->IL3daf: Incompatible stack heights: 1 vs 0
		//IL_04e1->IL3daf: Incompatible stack heights: 1 vs 0
		//IL_051a->IL3daf: Incompatible stack heights: 1 vs 0
		//IL_0549->IL3daf: Incompatible stack heights: 1 vs 0
		//IL_3eae->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_058c->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_05ae->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_05e9->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0610->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0651->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_069f->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_06d2->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0760->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0d89->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_07ca->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0836->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_13c2->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0df3->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_086e->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_08b4->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0e6f->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1efa->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_08e7->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_19ed->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_142c->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0ea7->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_25b4->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0916->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0eed->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_149a->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_094c->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1f64->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0f20->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1a57->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_14d2->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0992->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_261e->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0f4f->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1fe0->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1aa9->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1518->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_09cd->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0f85->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2c99->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_269a->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2018->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1ae8->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_154b->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_09fc->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0fcb->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_26d2->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_205e->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1b1b->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_157a->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0a23->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1006->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_271c->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2091->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_15b0->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0a6d->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2d03->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1b81->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1035->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_303f->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_274f->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_20c0->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_15f6->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0a9c->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1bb9->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_105c->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2d61->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_277e->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_20f6->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1631->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0ad5->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1bff->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_10a6->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3957->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2d99->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_27b4->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_213c->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1660->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0af7->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_34c2->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_30a9->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1c32->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_10d5->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2de7->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_27fa->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2177->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1687->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0b33->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_30e9->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1c73->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_110e->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_39b2->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2e22->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2835->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_21a6->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_16d1->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0b62->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_351d->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_311c->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1130->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_39e0->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2864->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_21cd->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1700->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0b9b->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_354b->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1d2f->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_116c->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3a32->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3182->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2ee3->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_288b->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2217->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1d02->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1739->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0bbd->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_359d->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2eb6->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_119b->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3a70->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_31ba->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_28d5->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2246->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_175b->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0bf8->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_35db->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3f72->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_11d4->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3aa3->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3204->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3fd8->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2904->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_227f->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1797->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0c27->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_360e->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_11f6->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_323f->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_293d->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_22a1->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_17c6->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0c4e->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3b09->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1231->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3674->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_295f->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_22dd->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_17ff->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0c8f->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3b41->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1e57->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1260->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_36ac->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_32ef->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_299b->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_230c->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1e98->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1821->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0cbe->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3b87->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_32c2->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1287->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_36f2->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_29ca->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2345->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_185c->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_0d11->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3bba->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_12c8->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3725->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_4048->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2a03->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2367->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_188b->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3bfb->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_12f7->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3766->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2a25->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_23a2->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_18b2->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3c45->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_134a->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_37b0->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2a60->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_23d1->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_18f3->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3c74->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_37df->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3417->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2a8f->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_23f8->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1922->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3458->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2ab6->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2439->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_1975->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2af7->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2468->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3d59->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_3d9a->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_38b4->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2b26->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_24bb->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_38f5->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2b45->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2b98->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2511->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2552->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2bee->IL3daf: Incompatible stack heights: 2 vs 0
		//IL_2c2f->IL3daf: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 1096810496;
		_ = 1;
		_ = 1096810496;
		_ = 1;
		Vector2 vector = default(Vector2);
		if (body != null)
		{
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+77]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
			BaseBody baseBody2 = baseBody.setCircle(32f, (float?)(object)num, (float?)(object)0);
			PhaserSprite[] torsoChains = _torsoChains;
			if (_torsoChains != null)
			{
				int num2 = base.depth;
				if ((object)torsoChains[0] != null)
				{
					int num3 = num2 + 1;
					PhaserSprite phaserSprite = torsoChains[0].setDepth(num3);
					if ((object)phaserSprite != null)
					{
						GameObject gameObject = phaserSprite.gameObject;
						if ((object)gameObject != null)
						{
							((UnityEngine.Object)gameObject).SetName("Chain");
							PhaserSprite[] torsoChains2 = _torsoChains;
							if (_torsoChains != null && (object)torsoChains2[0] != null)
							{
								PhaserSprite phaserSprite2 = torsoChains2[0].setScale(2f, (float?)(object)0);
								PhaserSprite[] torsoChains3 = _torsoChains;
								if (_torsoChains != null)
								{
									PhaserSprite phaserSprite3 = torsoChains3[0];
									if ((object)torsoChains3[0] != null)
									{
										object spriteRenderer = phaserSprite3._spriteRenderer;
										if ((object)phaserSprite3._spriteRenderer != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rsi_v10 (System.Object)+10]");
											bool flag = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rsi_v10 (System.Object)+10]");
											SpriteRenderer.set_drawMode_Injected((IntPtr)0, SpriteDrawMode.Tiled);
											PhaserSprite[] torsoChains4 = _torsoChains;
											if (_torsoChains != null)
											{
												PhaserSprite phaserSprite4 = torsoChains4[0];
												if ((object)torsoChains4[0] != null && (object)phaserSprite4._spriteRenderer != null)
												{
													phaserSprite4._spriteRenderer.size = vector;
													PhaserSprite[] torsoChains5 = _torsoChains;
													if (_torsoChains != null && (object)torsoChains5[0] != null)
													{
														torsoChains5[0].angle = -10.204f;
														PhaserSprite[] torsoChains6 = _torsoChains;
														if (_torsoChains != null)
														{
															float2 float5 = base.position;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
															float num4 = 0f + 3.4f;
															if ((object)torsoChains6[0] != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
																PhaserSprite[] torsoChains7 = _torsoChains;
																if (_torsoChains != null)
																{
																	int num5 = base.depth;
																	if ((object)torsoChains7[1] != null)
																	{
																		int num6 = num5 + 1;
																		PhaserSprite phaserSprite5 = torsoChains7[1].setDepth(num6);
																		if ((object)phaserSprite5 != null)
																		{
																			GameObject gameObject2 = phaserSprite5.gameObject;
																			if ((object)gameObject2 != null)
																			{
																				((UnityEngine.Object)gameObject2).SetName("Chain");
																				PhaserSprite[] torsoChains8 = _torsoChains;
																				if (_torsoChains != null && (object)torsoChains8[1] != null)
																				{
																					PhaserSprite phaserSprite6 = torsoChains8[1].setScale(2f, (float?)(object)0);
																					PhaserSprite[] torsoChains9 = _torsoChains;
																					if (_torsoChains != null)
																					{
																						PhaserSprite phaserSprite7 = torsoChains9[1];
																						if ((object)torsoChains9[1] != null)
																						{
																							PhaserSprite spriteRenderer2 = (PhaserSprite)(object)phaserSprite7._spriteRenderer;
																							if ((object)phaserSprite7._spriteRenderer != null)
																							{
																								bool flag2 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
																								SpriteRenderer.set_drawMode_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, SpriteDrawMode.Tiled);
																								PhaserSprite[] torsoChains10 = _torsoChains;
																								if (_torsoChains != null)
																								{
																									PhaserSprite phaserSprite8 = torsoChains10[1];
																									if ((object)torsoChains10[1] != null && (object)phaserSprite8._spriteRenderer != null)
																									{
																										phaserSprite8._spriteRenderer.size = vector;
																										PhaserSprite[] torsoChains11 = _torsoChains;
																										if (_torsoChains != null && (object)torsoChains11[1] != null)
																										{
																											torsoChains11[1].angle = 20.204f;
																											PhaserSprite[] torsoChains12 = _torsoChains;
																											if (_torsoChains != null)
																											{
																												float2 float6 = base.position;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
																												float num7 = 0f + 3.58f;
																												if ((object)torsoChains12[1] != null)
																												{
																													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
																													List<EnemyBeelzebubSection> sections = _sections;
																													if (_sections != null)
																													{
																														if (sections._size != 10)
																														{
																															return;
																														}
																														PhaserSprite head = (PhaserSprite)(object)_head;
																														if ((object)_head == null || ((UnityEngine.Object)head).m_CachedPtr == (IntPtr)0)
																														{
																															goto IL_0d25;
																														}
																														ArcadeSprite head2 = _head;
																														if ((object)_head != null)
																														{
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ rax_v382 (ArcadeSprite)+260]");
																															if ((nint)0 != 0)
																															{
																																goto IL_0d25;
																															}
																															ArcadeSprite arcadeSprite = _head.setVisible(visible: true);
																															int num8 = base.depth;
																															if ((object)_head != null)
																															{
																																int num9 = num8 - 1;
																																ArcadeSprite arcadeSprite2 = _head.setDepth(num9);
																																float2 float7 = base.position;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
																																float num10 = 0f + 0.5f;
																																if ((object)_head != null)
																																{
																																	_head.position = vector;
																																	EnemyBeelzebubSection head3 = _head;
																																	if ((object)_head != null)
																																	{
																																		_ = 0;
																																		_ = 0;
																																		_ = 1082130432;
																																		_ = 1;
																																		_ = 1098907648;
																																		_ = 1;
																																		if (head3.body != null)
																																		{
																																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A974F0");
																																			EnemyBeelzebubSection head4 = _head;
																																			if ((object)_head != null)
																																			{
																																				PhaserSprite[] chains = head4._chains;
																																				if (head4._chains != null)
																																				{
																																					int num11 = _head.depth;
																																					if ((object)chains[0] != null)
																																					{
																																						int num12 = num11 + 1;
																																						PhaserSprite phaserSprite9 = chains[0].setDepth(num12);
																																						if ((object)phaserSprite9 != null)
																																						{
																																							PhaserSprite phaserSprite10 = phaserSprite9.setName("Chain");
																																							EnemyBeelzebubSection head5 = _head;
																																							if ((object)_head != null)
																																							{
																																								PhaserSprite[] chains2 = head5._chains;
																																								if (head5._chains != null && (object)chains2[0] != null)
																																								{
																																									PhaserSprite phaserSprite11 = chains2[0].setScale(2f, (float?)(object)0);
																																									EnemyBeelzebubSection head6 = _head;
																																									if ((object)_head != null)
																																									{
																																										PhaserSprite[] chains3 = head6._chains;
																																										if (head6._chains != null)
																																										{
																																											PhaserSprite phaserSprite12 = chains3[0];
																																											if ((object)chains3[0] != null && (object)phaserSprite12._spriteRenderer != null)
																																											{
																																												phaserSprite12._spriteRenderer.drawMode = SpriteDrawMode.Tiled;
																																												EnemyBeelzebubSection head7 = _head;
																																												if ((object)_head != null)
																																												{
																																													PhaserSprite[] chains4 = head7._chains;
																																													if (head7._chains != null)
																																													{
																																														PhaserSprite phaserSprite13 = chains4[0];
																																														if ((object)chains4[0] != null && (object)phaserSprite13._spriteRenderer != null)
																																														{
																																															phaserSprite13._spriteRenderer.size = vector;
																																															EnemyBeelzebubSection head8 = _head;
																																															if ((object)_head != null)
																																															{
																																																PhaserSprite[] chains5 = head8._chains;
																																																if (head8._chains != null && (object)chains5[0] != null)
																																																{
																																																	chains5[0].angle = 28.204f;
																																																	EnemyBeelzebubSection head9 = _head;
																																																	if ((object)_head != null)
																																																	{
																																																		PhaserSprite[] chains6 = head9._chains;
																																																		if (head9._chains != null)
																																																		{
																																																			float2 float8 = _head.position;
																																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
																																																			float num13 = 0f + 3.48f;
																																																			if ((object)chains6[0] != null)
																																																			{
																																																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
																																																				goto IL_0d25;
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
		goto IL_3daf;
		IL_3fdd:
		PhaserSprite rightHand = (PhaserSprite)(object)_rightHand;
		float num17;
		if ((object)_rightHand != null && ((UnityEngine.Object)rightHand).m_CachedPtr != (IntPtr)0)
		{
			ArcadeSprite rightHand2 = _rightHand;
			if ((object)_rightHand != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v910 @ rax_v151 (ArcadeSprite)+260]");
				if ((nint)0 != 0)
				{
					goto IL_4010;
				}
				ArcadeSprite arcadeSprite3 = _rightHand.setVisible(visible: true);
				int num14 = base.depth;
				if ((object)_rightHand != null)
				{
					int num15 = num14 + 1;
					ArcadeSprite arcadeSprite4 = _rightHand.setDepth(num15);
					if ((object)_rightArm != null)
					{
						float2 float9 = _rightArm.position;
						if ((object)_rightArm != null)
						{
							float angleDegrees = _rightArm.angle;
							float2 float10 = MathUtils.RotateFloat2(vector, angleDegrees);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
							nint num16 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7B]");
							object obj3 = num16 + 0;
							if ((object)_rightHand != null)
							{
								_rightHand.position = vector;
								EnemyBeelzebubSection rightHand3 = _rightHand;
								if ((object)_rightHand != null)
								{
									_ = 0;
									_ = 0;
									_ = 3246391296L;
									_ = 1;
									_ = 1090519040;
									_ = 1;
									if (rightHand3.body != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A974F0");
										_ = 0;
										_ = 0;
										_ = 1;
										if ((object)_rightHand != null)
										{
											EnemyBeelzebubSection rightHand4 = _rightHand;
											float oX = num17;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
											ArcadeSprite arcadeSprite5 = rightHand4.setOrigin(oX, (float?)(object)0);
											float time = PauseSystem.Time;
											float num18 = time * 0.14f;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
											float num19;
											if (!(num18 > 1f))
											{
												if ((object)_rightHand == null)
												{
													goto IL_3daf;
												}
												num19 = 0f;
											}
											else
											{
												if ((object)_rightHand == null)
												{
													goto IL_3daf;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
												float num20 = num18 * (float)Math.PI;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
												object obj4 = num20 & 0;
												num19 = (float)obj4 * -20f;
											}
											_rightHand.angle = num19;
											if ((object)_rightHand != null)
											{
												float num21 = _rightHand.angle;
												float time2 = PauseSystem.Time;
												float num22 = time2 * 0.1f;
												float num23 = num22 * (float)Math.PI;
												float num24 = num23 + num23;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
												float num25 = num24 * -5f;
												float num26 = num25 + num21;
												_rightHand.angle = num26;
												if (_rightArm != null)
												{
													EnemyBeelzebubSection rightArm = _rightArm;
													if ((object)_rightArm == null)
													{
														goto IL_3daf;
													}
													if (!((EnemyController)rightArm)._003CIsDead_003Ek__BackingField)
													{
														goto IL_4010;
													}
												}
												if ((object)_rightHand != null)
												{
													_rightHand.Disappear();
													goto IL_4010;
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
			goto IL_3daf;
		}
		goto IL_4010;
		IL_1989:
		PhaserSprite leftHand = (PhaserSprite)(object)_leftHand;
		if ((object)_leftHand != null && ((UnityEngine.Object)leftHand).m_CachedPtr != (IntPtr)0)
		{
			ArcadeSprite leftHand2 = _leftHand;
			if ((object)_leftHand != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v849 @ rax_v280 (ArcadeSprite)+260]");
				if ((nint)0 != 0)
				{
					goto IL_1ead;
				}
				ArcadeSprite arcadeSprite6 = _leftHand.setVisible(visible: true);
				int num27 = base.depth;
				if ((object)_leftHand != null)
				{
					int num28 = num27 + 1;
					ArcadeSprite arcadeSprite7 = _leftHand.setDepth(num28);
					_ = 0;
					_ = 0;
					_ = 1;
					if ((object)_leftHand != null)
					{
						EnemyBeelzebubSection leftHand3 = _leftHand;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
						ArcadeSprite arcadeSprite8 = leftHand3.setOrigin(0.5f, (float?)(object)0);
						if ((object)_leftArm != null)
						{
							float2 float11 = _leftArm.position;
							if ((object)_leftArm != null)
							{
								float angleDegrees2 = _leftArm.angle;
								float2 float12 = MathUtils.RotateFloat2(vector, angleDegrees2);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
								nint num29 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7B]");
								object obj5 = num29 + 0;
								if ((object)_leftHand != null)
								{
									_leftHand.position = vector;
									EnemyBeelzebubSection leftHand4 = _leftHand;
									if ((object)_leftHand != null)
									{
										_ = 0;
										_ = 0;
										_ = 1098907648;
										_ = 1;
										_ = 1115684864;
										_ = 1;
										if (leftHand4.body != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6820");
											EnemyBeelzebubSection leftHand5 = _leftHand;
											if ((object)_leftHand != null)
											{
												BaseBody baseBody3 = leftHand5.body;
												_ = 0;
												_ = 1086324736;
												_ = 1;
												if (leftHand5.body != null)
												{
													nint num30 = (nint)baseBody3;
													BaseBody baseBody4 = leftHand5.body;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
													BaseBody baseBody5 = baseBody4.setOffset(8f, (float?)(object)0);
													float time3 = PauseSystem.Time;
													float num31 = time3 * 0.125f;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
													float num32;
													if (!(num31 > 1f))
													{
														if ((object)_leftHand == null)
														{
															goto IL_3daf;
														}
														num32 = 0f;
													}
													else
													{
														if ((object)_leftHand == null)
														{
															goto IL_3daf;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
														float num33 = num31 * (float)Math.PI;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
														object obj6 = num33 & 0;
														num32 = (float)obj6 * 20f;
													}
													_leftHand.angle = num32;
													if ((object)_leftHand != null)
													{
														float num34 = _leftHand.angle;
														float time4 = PauseSystem.Time;
														float num35 = time4 * 0.15f;
														float num36 = num35 * (float)Math.PI;
														float num37 = num36 + num36;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
														float num38 = num37 * 5f;
														float num39 = num38 + num34;
														_leftHand.angle = num39;
														if (_leftArm != null)
														{
															EnemyBeelzebubSection leftArm = _leftArm;
															if ((object)_leftArm == null)
															{
																goto IL_3daf;
															}
															if (!((EnemyController)leftArm)._003CIsDead_003Ek__BackingField)
															{
																goto IL_1ead;
															}
														}
														if ((object)_leftHand != null)
														{
															_leftHand.Disappear();
															goto IL_1ead;
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
			goto IL_3daf;
		}
		goto IL_1ead;
		IL_3f7c:
		PhaserSprite rightArm2 = (PhaserSprite)(object)_rightArm;
		if ((object)_rightArm == null || ((UnityEngine.Object)rightArm2).m_CachedPtr == (IntPtr)0)
		{
			goto IL_2fdc;
		}
		ArcadeSprite rightArm3 = _rightArm;
		if ((object)_rightArm != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v903 @ rax_v182 (ArcadeSprite)+260]");
			if ((nint)0 != 0)
			{
				goto IL_2fdc;
			}
			ArcadeSprite arcadeSprite9 = _rightArm.setVisible(visible: true);
			int num40 = base.depth;
			if ((object)_rightArm != null)
			{
				ArcadeSprite arcadeSprite10 = _rightArm.setDepth(num40);
				float2 float13 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
				float num41 = 0f + 0.8f;
				if ((object)_rightArm != null)
				{
					_rightArm.position = vector;
					EnemyBeelzebubSection rightArm4 = _rightArm;
					if ((object)_rightArm != null)
					{
						_ = 0;
						_ = 0;
						_ = 3242196992L;
						_ = 1;
						_ = 3221225472L;
						_ = 1;
						if (rightArm4.body != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A974F0");
							_ = 0;
							_ = 0;
							_ = 1;
							if ((object)_rightArm != null)
							{
								EnemyBeelzebubSection rightArm5 = _rightArm;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
								ArcadeSprite arcadeSprite11 = rightArm5.setOrigin(0.5f, (float?)(object)0);
								float time5 = PauseSystem.Time;
								float num42 = time5 * 0.27f;
								float num43 = num42 + 0.2f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
								float num44;
								if (!(num43 > 1f))
								{
									if ((object)_rightArm == null)
									{
										goto IL_3daf;
									}
									num44 = 0f;
								}
								else
								{
									if ((object)_rightArm == null)
									{
										goto IL_3daf;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
									float num45 = num43 * (float)Math.PI;
									float num46 = num45 + num45;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
									num44 = num46 * 10f;
								}
								_rightArm.angle = num44;
								if ((object)_rightArm != null)
								{
									float num47 = _rightArm.angle;
									float time6 = PauseSystem.Time;
									float num48 = time6 * 0.1f;
									float num49 = num48 + 0.2f;
									float num50 = num49 * (float)Math.PI;
									float num51 = num50 + num50;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
									float num52 = num51 * -10f;
									float num53 = num52 + num47;
									_rightArm.angle = num53;
									num17 = 0.5f;
									goto IL_3fdd;
								}
							}
						}
					}
				}
			}
		}
		goto IL_3daf;
		IL_4010:
		PhaserSprite leftLeg = (PhaserSprite)(object)_leftLeg;
		if ((object)_leftLeg != null && ((UnityEngine.Object)leftLeg).m_CachedPtr != (IntPtr)0)
		{
			ArcadeSprite leftLeg2 = _leftLeg;
			if ((object)_leftLeg != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v921 @ rax_v124 (ArcadeSprite)+260]");
				if ((nint)0 != 0)
				{
					goto IL_390a;
				}
				ArcadeSprite arcadeSprite12 = _leftLeg.setVisible(visible: true);
				if ((object)_leftThigh != null)
				{
					int num54 = _leftThigh.depth;
					if ((object)_leftLeg != null)
					{
						int num55 = num54 + 1;
						ArcadeSprite arcadeSprite13 = _leftLeg.setDepth(num55);
						_ = 0;
						_ = 0;
						_ = 1;
						if ((object)_leftLeg != null)
						{
							EnemyBeelzebubSection leftLeg3 = _leftLeg;
							float oX2 = num17;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
							ArcadeSprite arcadeSprite14 = leftLeg3.setOrigin(oX2, (float?)(object)0);
							if ((object)_leftThigh != null)
							{
								float2 float14 = _leftThigh.position;
								if ((object)_leftThigh != null)
								{
									float angleDegrees3 = _leftThigh.angle;
									float2 float15 = MathUtils.RotateFloat2(vector, angleDegrees3);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
									nint num56 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7B]");
									object obj7 = num56 + 0;
									if ((object)_leftLeg != null)
									{
										_leftLeg.position = vector;
										EnemyBeelzebubSection leftLeg4 = _leftLeg;
										if ((object)_leftLeg != null)
										{
											_ = 0;
											_ = 0;
											_ = 1107296256;
											_ = 1;
											_ = 1121714176;
											_ = 1;
											if (leftLeg4.body != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6820");
												EnemyBeelzebubSection leftLeg5 = _leftLeg;
												if ((object)_leftLeg != null)
												{
													BaseBody baseBody6 = leftLeg5.body;
													_ = 0;
													_ = 1086324736;
													_ = 1;
													if (leftLeg5.body != null)
													{
														nint num57 = (nint)baseBody6;
														BaseBody baseBody7 = leftLeg5.body;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
														BaseBody baseBody8 = baseBody7.setOffset(0f, (float?)(object)0);
														if ((object)_leftLeg != null)
														{
															_leftLeg.angle = -10f;
															if ((object)_leftLeg != null)
															{
																float num58 = _leftLeg.angle;
																float time7 = PauseSystem.Time;
																float num59 = time7 * 0.07f;
																float num60 = num59 * (float)Math.PI;
																float num61 = num60 + num60;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																float num62 = num61 * -5f;
																float num63 = num62 + num58;
																_leftLeg.angle = num63;
																if (_leftThigh != null)
																{
																	EnemyBeelzebubSection leftThigh = _leftThigh;
																	if ((object)_leftThigh == null)
																	{
																		goto IL_3daf;
																	}
																	if (!((EnemyController)leftThigh)._003CIsDead_003Ek__BackingField)
																	{
																		goto IL_390a;
																	}
																}
																if ((object)_leftLeg != null)
																{
																	_leftLeg.Disappear();
																	goto IL_390a;
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
			goto IL_3daf;
		}
		goto IL_390a;
		IL_390a:
		if (!(_rightLeg != null))
		{
			return;
		}
		ArcadeSprite rightLeg = _rightLeg;
		if ((object)_rightLeg != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v934 @ rax_v101 (ArcadeSprite)+260]");
			if ((nint)0 != 0)
			{
				return;
			}
			ArcadeSprite arcadeSprite15 = _rightLeg.setVisible(visible: true);
			if ((object)_rightThigh != null)
			{
				int num64 = _rightThigh.depth;
				if ((object)_rightLeg != null)
				{
					int num65 = num64 + 1;
					ArcadeSprite arcadeSprite16 = _rightLeg.setDepth(num65);
					_ = 0;
					_ = 0;
					_ = 1;
					if ((object)_rightLeg != null)
					{
						EnemyBeelzebubSection rightLeg2 = _rightLeg;
						float oX3 = num17;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
						ArcadeSprite arcadeSprite17 = rightLeg2.setOrigin(oX3, (float?)(object)0);
						if ((object)_rightThigh != null)
						{
							float2 float16 = _rightThigh.position;
							if ((object)_rightThigh != null)
							{
								float angleDegrees4 = _rightThigh.angle;
								float2 float17 = MathUtils.RotateFloat2(vector, angleDegrees4);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
								nint num66 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7B]");
								object obj8 = num66 + 0;
								if ((object)_rightLeg != null)
								{
									_rightLeg.position = vector;
									EnemyBeelzebubSection rightLeg3 = _rightLeg;
									if ((object)_rightLeg != null)
									{
										_ = 0;
										_ = 0;
										_ = 1107296256;
										_ = 1;
										_ = 1120927744;
										_ = 1;
										if (rightLeg3.body != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6820");
											EnemyBeelzebubSection rightLeg4 = _rightLeg;
											if ((object)_rightLeg != null)
											{
												BaseBody baseBody9 = rightLeg4.body;
												_ = 0;
												_ = 1086324736;
												_ = 1;
												if (rightLeg4.body != null)
												{
													nint num67 = (nint)baseBody9;
													BaseBody baseBody10 = rightLeg4.body;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
													BaseBody baseBody11 = baseBody10.setOffset(0f, (float?)(object)0);
													if ((object)_rightLeg != null)
													{
														_rightLeg.angle = 0f;
														if ((object)_rightLeg != null)
														{
															float num68 = _rightLeg.angle;
															float time8 = PauseSystem.Time;
															float num69 = time8 * 0.04f;
															float num70 = num69 * (float)Math.PI;
															float num71 = num70 + num70;
															float num72 = num71 + 2f;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
															float num73 = num72 * -5f;
															float num74 = num73 + num68;
															_rightLeg.angle = num74;
															if (_rightThigh != null)
															{
																EnemyBeelzebubSection rightThigh = _rightThigh;
																if ((object)_rightThigh == null)
																{
																	goto IL_3daf;
																}
																if (!((EnemyController)rightThigh)._003CIsDead_003Ek__BackingField)
																{
																	return;
																}
															}
															if ((object)_rightLeg != null)
															{
																_rightLeg.Disappear();
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
		goto IL_3daf;
		IL_2567:
		if (_rightThigh != null)
		{
			ArcadeSprite rightThigh2 = _rightThigh;
			if ((object)_rightThigh != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v882 @ rax_v204 (ArcadeSprite)+260]");
				if ((nint)0 != 0)
				{
					goto IL_3f7c;
				}
				ArcadeSprite arcadeSprite18 = _rightThigh.setVisible(visible: true);
				int num75 = base.depth;
				if ((object)_rightThigh != null)
				{
					int num76 = num75 + 1;
					ArcadeSprite arcadeSprite19 = _rightThigh.setDepth(num76);
					float2 float18 = base.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
					float num77 = 0f + 0.5f;
					float num78 = num77 - 1.75f;
					if ((object)_rightThigh != null)
					{
						_rightThigh.position = vector;
						EnemyBeelzebubSection rightThigh3 = _rightThigh;
						if ((object)_rightThigh != null)
						{
							_ = 0;
							_ = 0;
							_ = 3238002688L;
							_ = 1;
							_ = 1098907648;
							_ = 1;
							if (rightThigh3.body != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A974F0");
								EnemyBeelzebubSection rightThigh4 = _rightThigh;
								if ((object)_rightThigh != null)
								{
									PhaserSprite[] chains7 = rightThigh4._chains;
									if (rightThigh4._chains != null)
									{
										int num79 = _rightThigh.depth;
										if ((object)chains7[0] != null)
										{
											int num80 = num79 + 1;
											PhaserSprite phaserSprite14 = chains7[0].setDepth(num80);
											if ((object)phaserSprite14 != null)
											{
												PhaserSprite phaserSprite15 = phaserSprite14.setName("Chain");
												EnemyBeelzebubSection rightThigh5 = _rightThigh;
												if ((object)_rightThigh != null)
												{
													PhaserSprite[] chains8 = rightThigh5._chains;
													if (rightThigh5._chains != null && (object)chains8[0] != null)
													{
														PhaserSprite phaserSprite16 = chains8[0].setScale(2f, (float?)(object)0);
														EnemyBeelzebubSection rightThigh6 = _rightThigh;
														if ((object)_rightThigh != null)
														{
															PhaserSprite[] chains9 = rightThigh6._chains;
															if (rightThigh6._chains != null)
															{
																PhaserSprite phaserSprite17 = chains9[0];
																if ((object)chains9[0] != null && (object)phaserSprite17._spriteRenderer != null)
																{
																	phaserSprite17._spriteRenderer.drawMode = SpriteDrawMode.Tiled;
																	EnemyBeelzebubSection rightThigh7 = _rightThigh;
																	if ((object)_rightThigh != null)
																	{
																		PhaserSprite[] chains10 = rightThigh7._chains;
																		if (rightThigh7._chains != null)
																		{
																			PhaserSprite phaserSprite18 = chains10[0];
																			if ((object)chains10[0] != null && (object)phaserSprite18._spriteRenderer != null)
																			{
																				phaserSprite18._spriteRenderer.size = vector;
																				EnemyBeelzebubSection rightThigh8 = _rightThigh;
																				if ((object)_rightThigh != null)
																				{
																					PhaserSprite[] chains11 = rightThigh8._chains;
																					if (rightThigh8._chains != null && (object)chains11[0] != null)
																					{
																						chains11[0].angle = -50.204f;
																						EnemyBeelzebubSection rightThigh9 = _rightThigh;
																						if ((object)_rightThigh != null)
																						{
																							PhaserSprite[] chains12 = rightThigh9._chains;
																							if (rightThigh9._chains != null && (object)_rightThigh != null)
																							{
																								float2 float19 = _rightThigh.position;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
																								float num81 = 0f + 3.8179998f;
																								if ((object)chains12[0] != null)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
																									if (_belly != null)
																									{
																										EnemyBeelzebubSection belly = _belly;
																										if ((object)_belly == null)
																										{
																											goto IL_3daf;
																										}
																										if (!((EnemyController)belly)._003CIsDead_003Ek__BackingField)
																										{
																											goto IL_3f7c;
																										}
																									}
																									if ((object)_rightThigh != null)
																									{
																										_rightThigh.Disappear();
																										goto IL_3f7c;
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
			goto IL_3daf;
		}
		goto IL_3f7c;
		IL_2fdc:
		num17 = 0.5f;
		goto IL_3fdd;
		IL_1ead:
		if (_leftThigh != null)
		{
			ArcadeSprite leftThigh2 = _leftThigh;
			if ((object)_leftThigh != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v861 @ rax_v242 (ArcadeSprite)+260]");
				if ((nint)0 != 0)
				{
					goto IL_2567;
				}
				ArcadeSprite arcadeSprite20 = _leftThigh.setVisible(visible: true);
				int num82 = base.depth;
				if ((object)_leftThigh != null)
				{
					int num83 = num82 + 1;
					ArcadeSprite arcadeSprite21 = _leftThigh.setDepth(num83);
					float2 float20 = base.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
					float num84 = 0f + 0.5f;
					float num85 = num84 - 1.5f;
					if ((object)_leftThigh != null)
					{
						_leftThigh.position = vector;
						EnemyBeelzebubSection leftThigh3 = _leftThigh;
						if ((object)_leftThigh != null)
						{
							_ = 0;
							_ = 0;
							_ = 1103101952;
							_ = 1;
							_ = 1098907648;
							_ = 1;
							if (leftThigh3.body != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A974F0");
								EnemyBeelzebubSection leftThigh4 = _leftThigh;
								if ((object)_leftThigh != null)
								{
									PhaserSprite[] chains13 = leftThigh4._chains;
									if (leftThigh4._chains != null)
									{
										int num86 = _leftThigh.depth;
										if ((object)chains13[0] != null)
										{
											int num87 = num86 + 1;
											PhaserSprite phaserSprite19 = chains13[0].setDepth(num87);
											if ((object)phaserSprite19 != null)
											{
												PhaserSprite phaserSprite20 = phaserSprite19.setName("Chain");
												EnemyBeelzebubSection leftThigh5 = _leftThigh;
												if ((object)_leftThigh != null)
												{
													PhaserSprite[] chains14 = leftThigh5._chains;
													if (leftThigh5._chains != null && (object)chains14[0] != null)
													{
														PhaserSprite phaserSprite21 = chains14[0].setScale(2f, (float?)(object)0);
														EnemyBeelzebubSection leftThigh6 = _leftThigh;
														if ((object)_leftThigh != null)
														{
															PhaserSprite[] chains15 = leftThigh6._chains;
															if (leftThigh6._chains != null)
															{
																PhaserSprite phaserSprite22 = chains15[0];
																if ((object)chains15[0] != null && (object)phaserSprite22._spriteRenderer != null)
																{
																	phaserSprite22._spriteRenderer.drawMode = SpriteDrawMode.Tiled;
																	EnemyBeelzebubSection leftThigh7 = _leftThigh;
																	if ((object)_leftThigh != null)
																	{
																		PhaserSprite[] chains16 = leftThigh7._chains;
																		if (leftThigh7._chains != null)
																		{
																			PhaserSprite phaserSprite23 = chains16[0];
																			if ((object)chains16[0] != null && (object)phaserSprite23._spriteRenderer != null)
																			{
																				phaserSprite23._spriteRenderer.size = vector;
																				EnemyBeelzebubSection leftThigh8 = _leftThigh;
																				if ((object)_leftThigh != null)
																				{
																					PhaserSprite[] chains17 = leftThigh8._chains;
																					if (leftThigh8._chains != null && (object)chains17[0] != null)
																					{
																						chains17[0].angle = 40.204f;
																						EnemyBeelzebubSection leftThigh9 = _leftThigh;
																						if ((object)_leftThigh != null)
																						{
																							PhaserSprite[] chains18 = leftThigh9._chains;
																							if (leftThigh9._chains != null)
																							{
																								float2 float21 = _leftThigh.position;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
																								float num88 = 0f + 3.5f;
																								if ((object)chains18[0] != null)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
																									if (_belly != null)
																									{
																										EnemyBeelzebubSection belly2 = _belly;
																										if ((object)_belly == null)
																										{
																											goto IL_3daf;
																										}
																										if (!((EnemyController)belly2)._003CIsDead_003Ek__BackingField)
																										{
																											goto IL_2567;
																										}
																									}
																									if ((object)_leftThigh != null)
																									{
																										_leftThigh.Disappear();
																										goto IL_2567;
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
			goto IL_3daf;
		}
		goto IL_2567;
		IL_135e:
		PhaserSprite leftArm2 = (PhaserSprite)(object)_leftArm;
		if ((object)_leftArm == null || ((UnityEngine.Object)leftArm2).m_CachedPtr == (IntPtr)0)
		{
			goto IL_1989;
		}
		ArcadeSprite leftArm3 = _leftArm;
		if ((object)_leftArm != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ rax_v312 (ArcadeSprite)+260]");
			if ((nint)0 != 0)
			{
				goto IL_1989;
			}
			ArcadeSprite arcadeSprite22 = _leftArm.setVisible(visible: true);
			int num89 = base.depth;
			if ((object)_leftArm != null)
			{
				ArcadeSprite arcadeSprite23 = _leftArm.setDepth(num89);
				float2 float22 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
				float num90 = 0f + 0.5f;
				float num91 = num90 + 0.4f;
				if ((object)_leftArm != null)
				{
					_leftArm.position = vector;
					EnemyBeelzebubSection leftArm4 = _leftArm;
					if ((object)_leftArm != null)
					{
						_ = 0;
						_ = 0;
						_ = 1098907648;
						_ = 1;
						_ = 1082130432;
						_ = 1;
						if (leftArm4.body != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A974F0");
							EnemyBeelzebubSection leftArm5 = _leftArm;
							if ((object)_leftArm != null)
							{
								PhaserSprite[] chains19 = leftArm5._chains;
								if (leftArm5._chains != null)
								{
									int num92 = _leftArm.depth;
									if ((object)chains19[0] != null)
									{
										int num93 = num92 + 1;
										PhaserSprite phaserSprite24 = chains19[0].setDepth(num93);
										if ((object)phaserSprite24 != null)
										{
											PhaserSprite phaserSprite25 = phaserSprite24.setName("Chain");
											EnemyBeelzebubSection leftArm6 = _leftArm;
											if ((object)_leftArm != null)
											{
												PhaserSprite[] chains20 = leftArm6._chains;
												if (leftArm6._chains != null && (object)chains20[0] != null)
												{
													PhaserSprite phaserSprite26 = chains20[0].setScale(2f, (float?)(object)0);
													EnemyBeelzebubSection leftArm7 = _leftArm;
													if ((object)_leftArm != null)
													{
														PhaserSprite[] chains21 = leftArm7._chains;
														if (leftArm7._chains != null)
														{
															PhaserSprite phaserSprite27 = chains21[0];
															if ((object)chains21[0] != null && (object)phaserSprite27._spriteRenderer != null)
															{
																phaserSprite27._spriteRenderer.drawMode = SpriteDrawMode.Tiled;
																EnemyBeelzebubSection leftArm8 = _leftArm;
																if ((object)_leftArm != null)
																{
																	PhaserSprite[] chains22 = leftArm8._chains;
																	if (leftArm8._chains != null)
																	{
																		PhaserSprite phaserSprite28 = chains22[0];
																		if ((object)chains22[0] != null && (object)phaserSprite28._spriteRenderer != null)
																		{
																			phaserSprite28._spriteRenderer.size = vector;
																			EnemyBeelzebubSection leftArm9 = _leftArm;
																			if ((object)_leftArm != null)
																			{
																				PhaserSprite[] chains23 = leftArm9._chains;
																				if (leftArm9._chains != null && (object)chains23[0] != null)
																				{
																					chains23[0].angle = 40.204f;
																					EnemyBeelzebubSection leftArm10 = _leftArm;
																					if ((object)_leftArm != null)
																					{
																						PhaserSprite[] chains24 = leftArm10._chains;
																						if (leftArm10._chains != null)
																						{
																							float2 float23 = _leftArm.position;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
																							float num94 = 0f + 3.1800003f;
																							if ((object)chains24[0] != null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
																								goto IL_1989;
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
		goto IL_3daf;
		IL_0d25:
		PhaserSprite belly3 = (PhaserSprite)(object)_belly;
		if ((object)_belly == null || ((UnityEngine.Object)belly3).m_CachedPtr == (IntPtr)0)
		{
			goto IL_135e;
		}
		ArcadeSprite belly4 = _belly;
		if ((object)_belly != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v811 @ rax_v347 (ArcadeSprite)+260]");
			if ((nint)0 != 0)
			{
				goto IL_135e;
			}
			ArcadeSprite arcadeSprite24 = _belly.setVisible(visible: true);
			int num95 = base.depth;
			if ((object)_belly != null)
			{
				int num96 = num95 + 2;
				ArcadeSprite arcadeSprite25 = _belly.setDepth(num96);
				float2 float24 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
				float num97 = 0f + 0.5f;
				float num98 = num97 - 0.55f;
				if ((object)_belly != null)
				{
					_belly.position = vector;
					EnemyBeelzebubSection belly5 = _belly;
					if ((object)_belly != null)
					{
						_ = 0;
						_ = 0;
						_ = 1101004800;
						_ = 1;
						_ = 1090519040;
						_ = 1;
						if (belly5.body != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A974F0");
							EnemyBeelzebubSection belly6 = _belly;
							if ((object)_belly != null)
							{
								PhaserSprite[] chains25 = belly6._chains;
								if (belly6._chains != null)
								{
									int num99 = _belly.depth;
									if ((object)chains25[0] != null)
									{
										int num100 = num99 - 2;
										PhaserSprite phaserSprite29 = chains25[0].setDepth(num100);
										if ((object)phaserSprite29 != null)
										{
											PhaserSprite phaserSprite30 = phaserSprite29.setName("Chain");
											EnemyBeelzebubSection belly7 = _belly;
											if ((object)_belly != null)
											{
												PhaserSprite[] chains26 = belly7._chains;
												if (belly7._chains != null && (object)chains26[0] != null)
												{
													PhaserSprite phaserSprite31 = chains26[0].setScale(2f, (float?)(object)0);
													EnemyBeelzebubSection belly8 = _belly;
													if ((object)_belly != null)
													{
														PhaserSprite[] chains27 = belly8._chains;
														if (belly8._chains != null)
														{
															PhaserSprite phaserSprite32 = chains27[0];
															if ((object)chains27[0] != null && (object)phaserSprite32._spriteRenderer != null)
															{
																phaserSprite32._spriteRenderer.drawMode = SpriteDrawMode.Tiled;
																EnemyBeelzebubSection belly9 = _belly;
																if ((object)_belly != null)
																{
																	PhaserSprite[] chains28 = belly9._chains;
																	if (belly9._chains != null)
																	{
																		PhaserSprite phaserSprite33 = chains28[0];
																		if ((object)chains28[0] != null && (object)phaserSprite33._spriteRenderer != null)
																		{
																			phaserSprite33._spriteRenderer.size = vector;
																			EnemyBeelzebubSection belly10 = _belly;
																			if ((object)_belly != null)
																			{
																				PhaserSprite[] chains29 = belly10._chains;
																				if (belly10._chains != null && (object)chains29[0] != null)
																				{
																					chains29[0].angle = 48.204f;
																					EnemyBeelzebubSection belly11 = _belly;
																					if ((object)_belly != null)
																					{
																						PhaserSprite[] chains30 = belly11._chains;
																						if (belly11._chains != null)
																						{
																							float2 float25 = _belly.position;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
																							float num101 = 0f + 2.88f;
																							if ((object)chains30[0] != null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
																								goto IL_135e;
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
		goto IL_3daf;
		IL_3daf:
		throw new NullReferenceException();
	}

	public override void Disappear()
	{
		base._003CIsDead_003Ek__BackingField = true;
	}

	protected override void Die()
	{
		base._003CIsDead_003Ek__BackingField = true;
	}

	public unsafe override void Despawn()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_00b4->IL0263: Incompatible stack heights: 1 vs 0
		//IL_00c9->IL02b1: Incompatible stack heights: 1 vs 0
		DropReward();
		PhaserSprite[] torsoChains = _torsoChains;
		bool flag = _torsoChains == null;
		PhaserSprite[] array = null;
		PhaserSprite[] array2 = null;
		if (!flag)
		{
			while (true)
			{
				if ((nint)array2 < torsoChains.Length)
				{
					PhaserSprite[] torsoChains2 = _torsoChains;
					if (_torsoChains == null)
					{
						break;
					}
					GameObject gameObject = (GameObject)(object)torsoChains2[(object)array];
					if ((object)torsoChains2[(object)array] == null)
					{
						break;
					}
					bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					GameObject obj = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
					UnityEngine.Object.Destroy(obj, 0f);
					torsoChains = _torsoChains;
					array = (PhaserSprite[])(array + 1);
					if (_torsoChains == null)
					{
						break;
					}
					array2 = array;
					continue;
				}
				_torsoChains = null;
				if (((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
				{
					IntPtr gcHandlePtr2 = Component.get_gameObject_Injected(((UnityEngine.Object)this).m_CachedPtr);
					GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
					if ((object)gameObject2 == null)
					{
						break;
					}
					ParticleEmitterManager component = gameObject2.GetComponent<ParticleEmitterManager>();
					if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
					{
						UnityEngine.Object.Destroy(component, 0f);
					}
					if (((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
					{
						IntPtr gcHandlePtr3 = Component.get_gameObject_Injected(((UnityEngine.Object)this).m_CachedPtr);
						GameObject gameObject3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
						if ((object)gameObject3 == null)
						{
							break;
						}
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v888 @ rbx_v9 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>((nint)__ldftn(GameObject.GetComponentsInChildren<ParticleSystem>));
						}
						ParticleSystem[] componentsInChildren = gameObject3.GetComponentsInChildren<ParticleSystem>(includeInactive: false);
						bool flag3 = componentsInChildren == null;
						PhaserSprite[] array3 = null;
						if (!flag3)
						{
							while ((nint)array3 < componentsInChildren.Length)
							{
								UnityEngine.Object.Destroy(componentsInChildren[(object)array3], 0f);
								array3 = (PhaserSprite[])(array3 + 1);
							}
						}
						base.Despawn();
						return;
					}
				}
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(this);
				break;
			}
		}
		throw new NullReferenceException();
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_0155: Expected O, but got I4
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		List<EnemyBeelzebubSection> sections = _sections;
		int num = 0;
		object obj = 0;
		int num2 = 0;
		WeaponType damageType2 = default(WeaponType);
		bool hasKb2 = default(bool);
		while (true)
		{
			if (num2 < sections._size)
			{
				List<EnemyBeelzebubSection> sections2 = _sections;
				if (num >= sections2._size)
				{
					break;
				}
				EnemyBeelzebubSection[] items = sections2._items;
				EnemyBeelzebubSection enemyBeelzebubSection = items[num];
				if ((object)items[num] != null && ((UnityEngine.Object)enemyBeelzebubSection).m_CachedPtr != (IntPtr)0)
				{
					EnemyBeelzebubSection enemyBeelzebubSection2 = _sections.get_Item(num);
					if (!((EnemyController)enemyBeelzebubSection2)._003CIsDead_003Ek__BackingField)
					{
						obj++;
					}
				}
				sections = _sections;
				num++;
				num2 = num;
				continue;
			}
			bool flag = (nint)obj <= 1;
			float value2 = value;
			if (!flag)
			{
				object obj2 = obj * obj;
				value2 = value / (float)obj2;
			}
			base.GetDamaged(value2, showHitVfx, damageKb, damageType2, hasKb2);
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0548: Expected O, but got F4
		//IL_010e: Expected O, but got I4
		//IL_0273: Expected O, but got I4
		//IL_0145: Invalid comparison between O and F4
		//IL_0173: Expected O, but got I4
		//IL_0180: Expected I, but got O
		//IL_032c: Expected O, but got I
		//IL_0600: Expected O, but got I4
		//IL_0396: Expected O, but got I8
		//IL_039b->IL05cf: Incompatible stack heights: 2 vs 1
		//IL_045c->IL05de: Incompatible stack heights: 1 vs 0
		//IL_0461->IL05ec: Incompatible stack heights: 1 vs 0
		if (!base._003CIsDead_003Ek__BackingField)
		{
			UpdateBodyParts();
			if (!_coherenceSync.HasStateAuthority)
			{
				return;
			}
			List<EnemyBeelzebubBee> beeList = _beeList;
			bool flag = (nint)_beeList < 0;
			int num = beeList._size - 1;
			float num5 = default(float);
			if (!flag)
			{
				nint num3 = default(nint);
				nint num2 = num3;
				nint num4 = default(nint);
				ArcadeSprite arcadeSprite = default(ArcadeSprite);
				object obj = default(object);
				object obj2 = default(object);
				object obj3 = default(object);
				object obj4;
				do
				{
					List<EnemyBeelzebubBee> beeList2 = _beeList;
					if (num < beeList2._size)
					{
						EnemyBeelzebubBee[] items = beeList2._items;
						EnemyBeelzebubBee enemyBeelzebubBee = items[num];
						bool flag2 = ((EnemyController)enemyBeelzebubBee)._003CIsDead_003Ek__BackingField;
						num4 = num2;
						if (!flag2)
						{
							_beeList.Add((EnemyBeelzebubBee)num);
							float2 float5 = arcadeSprite.position;
							float2 item = base.position;
							((List<EnemyBeelzebubBee>)float5).Add((EnemyBeelzebubBee)item);
							bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)20f);
							num4 = num2;
							if (!flag3)
							{
								_beeList.Add((EnemyBeelzebubBee)num);
								num4 = (nint)obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v769 @ r8_v19 (Il2CppMethodInfo)+388] (should have been resolved before IL gen)");
							}
						}
						_beeList.RemoveAt(num);
					}
					else
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
					bool flag4;
					if (obj3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v77+10]");
						if ((nint)0 != 0)
						{
							_beeList.RemoveAt(num);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v86+28]");
							flag4 = (nint)0 < (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v86+28]");
							if ((nint)0 != 0)
							{
								goto IL_025a;
							}
						}
					}
					flag4 = (nint)_beeList < 0;
					_beeList.RemoveAt(num);
					num4 = 0;
					goto IL_025a;
					IL_025a:
					num--;
					obj4 = !flag4;
					num3 = num4;
					num5 = num5;
					num2 = num4;
				}
				while (obj4 != null);
			}
			if (!PauseSystem._paused)
			{
				object obj5 = Time.deltaTime;
			}
			if (!((_beeTimer = 0f + _beeTimer) > 6f))
			{
				return;
			}
			_beeTimer = 0f;
			int num6 = UnityEngine.Random.RandomRangeInt(3, 6);
			if (num6 <= 0)
			{
				return;
			}
			int num7 = 0;
			EnemyBeelzebubBee enemyBeelzebubBee2 = default(EnemyBeelzebubBee);
			EnemyBeelzebub parentBoss = default(EnemyBeelzebub);
			bool flag8;
			do
			{
				GameManager core = GM.Core;
				Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
				bool flag5 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
				float2 ret;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
				if (body != null)
				{
					BaseBody baseBody = body;
					ArcadeTransform arcadeTransform = baseBody._transform;
					arcadeTransform.position = ret;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				bool flag6 = (nint)0 != 0;
				Stage stage = core._stage;
				if (!flag6)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					bool flag7 = obj6 == null;
					stage = (Stage)6573110936L;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1470 @ rax_v46 (should have been resolved before IL gen)");
				object obj7 = UnityEngine.Random.RandomRangeInt(2000, 4000);
				GameManager core2 = GM.Core;
				if (!core2._multiplayer.IsOnlineMultiplayer)
				{
					enemyBeelzebubBee2.Init(num7, num6, -(float)Math.PI / 2f, num5, parentBoss);
					int num8 = 0;
				}
				else
				{
					Action<int, int, float, float, CoherenceSync> action = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2CA0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F676D0");
					int num8 = num7;
				}
				((List<object>)(object)_beeList).Add((object)enemyBeelzebubBee2);
				num7++;
				flag8 = num7 < num6;
				float num9 = -(float)Math.PI / 2f;
				nint num3 = 0;
			}
			while (flag8);
		}
		else if (!_isRunningDeathAnimation)
		{
			DoDeathAnimation();
		}
	}

	private unsafe void DoDeathAnimation()
	{
		//IL_0899: Expected I, but got O
		//IL_00a2: Expected O, but got I4
		//IL_019a: Expected I, but got O
		//IL_01fa: Expected O, but got I4
		//IL_0227: Expected O, but got I4
		//IL_0925: Expected O, but got I4
		//IL_0a7f: Expected O, but got I4
		//IL_0a9d: Expected O, but got I4
		//IL_094d: Expected O, but got I4
		//IL_0ac1: Expected O, but got I4
		//IL_0965: Expected O, but got I4
		//IL_0ae5: Expected O, but got I4
		//IL_07c7: Expected I, but got O
		//IL_07dd: Expected O, but got I
		//IL_07e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07eb: Expected O, but got Unknown
		//IL_0861: Expected I, but got O
		//IL_0a19: Expected O, but got I4
		//IL_0a30: Expected I, but got I8
		//IL_083d: Expected I, but got I8
		//IL_0a67->IL0866: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass55_0 obj = new _003C_003Ec__DisplayClass55_0();
		bool flag = obj == null;
		nint num = (nint)typeof(_003C_003Ec__DisplayClass55_0);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Action action;
		if (!flag)
		{
			obj._003C_003E4__this = this;
			if (_isRunningDeathAnimation)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
			BgmType bgmType = default(BgmType);
			SoundManager.StopMusic(bgmType);
			base._003CIsDead_003Ek__BackingField = true;
			_isRunningDeathAnimation = true;
			List<EnemyBeelzebubSection> sections = _sections;
			if (_sections != null)
			{
				List<EnemyBeelzebubSection>.Enumerator enumerator = default(List<EnemyBeelzebubSection>.Enumerator);
				while (enumerator.MoveNext())
				{
					object obj2 = 0;
				}
				List<EnemyBeelzebubSection> sections2 = _sections;
				int version = sections2._version + 1;
				sections2._version = version;
				sections2._size = 0;
				if (sections2._size > 0)
				{
					Array.Clear(sections2._items, 0, sections2._size);
					sections = null;
				}
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig.targets = array;
					float2 float5 = base.position;
					tweenConfig.x = (float?)(object)1;
					float2 float6 = base.position;
					object obj4 = default(object);
					float num3 = (float)obj4 - 5f;
					tweenConfig.y = (float?)(object)1;
					tweenConfig.duration = 3000f;
					MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
					GameObject gameObject = base.gameObject;
					ParticleEmitterManager particleManager = ((!gameObject.TryGetComponent<ParticleEmitterManager>(out var component)) ? gameObject.AddComponent<ParticleEmitterManager>() : component);
					obj.particleManager = particleManager;
					Circle circle = new Circle();
					circle._x = 0f;
					circle._radius = 32f;
					EmitZone emitZone = new EmitZone();
					emitZone._type = EmitZoneType.Random;
					emitZone._source = circle;
					obj.emitZone = emitZone;
					ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("ThosePeople");
					List<string> list = new List<string>();
					int version2 = list._version + 1;
					list._version = version2;
					string[] items = list._items;
					if (list._size >= items.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire19");
					}
					else
					{
						int num4 = list._size + 1;
						list._size = num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version3 = list._version + 1;
					list._version = version3;
					string[] items2 = list._items;
					if (list._size >= items2.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire20");
					}
					else
					{
						int num5 = list._size + 1;
						list._size = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					list.Add("TP_VFX_Fire21");
					list.Add("TP_VFX_Fire22");
					list.Add("TP_VFX_Fire23");
					list.Add("TP_VFX_Fire24");
					list.Add("TP_VFX_Fire25");
					list.Add("TP_VFX_Fire26");
					int version4 = list._version + 1;
					list._version = version4;
					string[] items3 = list._items;
					if (list._size >= items3.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire27");
					}
					else
					{
						int num6 = list._size + 1;
						list._size = num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version5 = list._version + 1;
					list._version = version5;
					string[] items4 = list._items;
					if (list._size >= items4.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire28");
					}
					else
					{
						int num7 = list._size + 1;
						list._size = num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version6 = list._version + 1;
					list._version = version6;
					string[] items5 = list._items;
					if (list._size >= items5.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire29");
					}
					else
					{
						int num8 = list._size + 1;
						list._size = num8;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					particleSystemConfig._frame = list;
					particleSystemConfig._fps = 16;
					ParticleSystem.MinMaxCurve lifespan = new ParticleSystem.MinMaxCurve(500f);
					particleSystemConfig._lifespan = lifespan;
					_ = 0;
					particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)3;
					_ = 0;
					particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)3;
					_ = 0;
					particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
					_ = 0;
					_ = 400f;
					particleSystemConfig._quantity = (int?)(object)1;
					particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
					_ = 0;
					_ = 2f;
					particleSystemConfig._frequency = (float?)(object)1;
					particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
					_ = 0;
					_ = 1f;
					particleSystemConfig._emitZone = obj.emitZone;
					particleSystemConfig._on = true;
					ParticleSystem pfxEmitter = obj.particleManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
					obj.pfxEmitter = pfxEmitter;
					Transform transform = obj.pfxEmitter.transform;
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					List<EnemyBeelzebubSection>.Enumerator value = default(List<EnemyBeelzebubSection>.Enumerator);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
					RenderingExtensions.Start(obj.pfxEmitter);
					Action onComplete = _003C_003Ec._003C_003E9__55_0;
					if (_003C_003Ec._003C_003E9__55_0 == null)
					{
						onComplete = (_003C_003Ec._003C_003E9__55_0 = delegate
						{
							//IL_0033: Expected F4, but got I4
							float? volume = default(float?);
							float rate = default(float);
							float detune = default(float);
							bool loop = default(bool);
							PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 500f, 20, 0f, volume, rate, detune, loop, 1f);
						});
					}
					Timer timer = Timers.Register(0.125f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					action = null;
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ r10_v8 (Il2CppMethodInfo)+8]");
					((Delegate)action).method_ptr = (IntPtr)0;
					((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass55_0._003CDoDeathAnimation_003Eb__1);
					((Delegate)action).m_target = obj;
					((Delegate)action).method_code = (IntPtr)action;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ r10_v8 (Il2CppMethodInfo)+4C]");
					object obj5 = (nint)0 >> 4;
					object obj6 = obj5 & 1;
					nint num10;
					if (obj6 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ r10_v8 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num10 = unchecked((nint)6447293664L);
							goto IL_0a10;
						}
					}
					num10 = ((Delegate)action).method_ptr;
					((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
					goto IL_0a10;
				}
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		throw new NullReferenceException();
		IL_0a10:
		object obj7 = 24;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		Timer timer2 = Timers.Register(5f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void DropReward()
	{
		//IL_02fc: Expected F4, but got I4
		//IL_0333: Expected I4, but got F4
		//IL_0333: Expected I4, but got F4
		//IL_0333: Expected F4, but got O
		//IL_00ad: Expected O, but got I
		//IL_0110: Expected O, but got I
		//IL_03dc: Expected O, but got I
		//IL_0183: Expected O, but got I
		//IL_039e: Expected O, but got I4
		//IL_039e: Expected O, but got I4
		//IL_0404: Expected O, but got I
		//IL_01f7: Expected O, but got I
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		Vector2 pos = default(Vector2);
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				Treasure treasure = new Treasure();
				List<float> list2 = new List<float>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v36 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v36 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v36 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v14+18]");
				float item = default(float);
				if (num >= 0)
				{
					list2.AddWithResize(3f);
					item = 3f;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v36 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj3 = (nint)0 + (nint)1;
					_ = 1077936128;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v36 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v36 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v36 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdx_v15+18]");
				if (num2 >= 0)
				{
					list2.AddWithResize(10f);
					item = 10f;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v36 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj5 = (nint)0 + (nint)1;
					_ = 1092616192;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v36 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v36 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v36 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v16+18]");
				if (num3 >= 0)
				{
					list2.AddWithResize(50f);
					item = 50f;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v36 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj7 = (nint)0 + (nint)1;
					_ = 1112014848;
				}
				treasure._003Cchances_003Ek__BackingField = list2;
				treasure._003Clevel_003Ek__BackingField = 3;
				List<PrizeType?> list3 = new List<PrizeType?>();
				((List<float>)(object)list3).Add(item);
				((List<float>)(object)list3).Add(item);
				((List<float>)(object)list3).Add(item);
				((List<float>)(object)list3).Add(item);
				((List<float>)(object)list3).Add(item);
				treasure._003CprizeTypes_003Ek__BackingField = list3;
				float2 float5 = base.position;
				TreasureChest treasureChest = GM.Core.MakeTreasure(pos, treasure);
				return;
			}
		}
		float? num4 = default(float?);
		float num5 = default(float);
		float num6 = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_PickupRelic, 0f, 10, 0f, num4, num5, num6, loop, 1f);
		float2 float6 = base.position;
		Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.RELIC, WeaponType.VOID, (float)num4, (ItemType)num5, (byte)(int)num6 != 0);
		if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
		{
			pickup._003CAutoSafeXY_003Ek__BackingField = true;
			BaseBody baseBody = pickup.body.setCircle(24f, (float?)(object)1, (float?)(object)1);
		}
	}
}
