using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
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
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using Zenject;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Confodere2_Projectile : Projectile
{
	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _emitter1;

	private ParticleSystem _emitter2;

	private VampireSurvivors.Framework.TimerSystem.Timer expireTimer;

	private bool _isDespawning;

	private PhaserSprite _lanceSprite;

	private Vector2 _collisionPos;

	private Vector2 _spritePos;

	private float _life;

	private Transform _cachedSpriteTransform;

	private MultiTargetTween _tween1;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween3;

	private Tween lifeTween;

	protected override void Awake()
	{
		//IL_0150: Expected O, but got I4
		//IL_01c7->IL0160: Incompatible stack heights: 1 vs 0
		//IL_0136->IL0160: Incompatible stack heights: 1 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite lanceSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Confodere02");
				_lanceSprite = lanceSprite;
				if ((object)_lanceSprite != null)
				{
					Transform transform = _lanceSprite.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
						if ((object)_lanceSprite != null)
						{
							PhaserSprite phaserSprite = _lanceSprite.setVisible(visible: false);
							if ((object)_lanceSprite != null)
							{
								PhaserSprite phaserSprite2 = _lanceSprite.setOrigin(1f, (float?)(object)1);
								MakeEmitters();
								return;
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
		//IL_0008: Expected O, but got Ref
		//IL_0af8: Expected O, but got Ref
		//IL_0b52: Expected O, but got Ref
		//IL_0bb7: Expected O, but got Ref
		//IL_0c11: Expected O, but got Ref
		//IL_016c: Expected O, but got I
		//IL_020a: Expected O, but got I
		//IL_020a: Expected O, but got I
		//IL_02a3: Expected O, but got I
		//IL_031a: Expected O, but got I4
		//IL_0325: Expected O, but got I4
		//IL_03a0: Expected O, but got I4
		//IL_046b: Expected I, but got O
		//IL_0650: Expected I, but got O
		//IL_066f: Expected O, but got I4
		//IL_07f6: Expected F4, but got I
		//IL_0807: Unknown result type (might be due to invalid IL or missing references)
		//IL_080c: Expected O, but got Unknown
		//IL_0884: Expected O, but got F4
		//IL_08e2: Expected O, but got Ref
		//IL_0927: Expected I4, but got I8
		//IL_0973: Expected O, but got F4
		//IL_0a0e: Expected I4, but got O
		//IL_0cad: Expected O, but got Ref
		//IL_0ce7: Expected O, but got F4
		//IL_0d39: Expected O, but got F4
		//IL_0dc2: Expected O, but got F4
		//IL_0415->IL0a85: Incompatible stack heights: 17 vs 0
		//IL_0441->IL0a85: Incompatible stack heights: 17 vs 0
		//IL_04b0->IL0a85: Incompatible stack heights: 17 vs 0
		//IL_048e->IL048e: Incompatible stack heights: 18 vs 17
		//IL_059e->IL0a85: Incompatible stack heights: 17 vs 0
		//IL_05ca->IL0a85: Incompatible stack heights: 17 vs 0
		//IL_063e->IL0a85: Incompatible stack heights: 17 vs 0
		//IL_061c->IL061c: Incompatible stack heights: 18 vs 17
		//IL_0c43->IL0a85: Incompatible stack heights: 17 vs 0
		//IL_07b2->IL0a85: Incompatible stack heights: 17 vs 0
		//IL_07e1->IL0a85: Incompatible stack heights: 17 vs 0
		//IL_089e->IL0a85: Incompatible stack heights: 17 vs 0
		//IL_08ca->IL0a85: Incompatible stack heights: 17 vs 0
		//IL_090e->IL0a85: Incompatible stack heights: 17 vs 0
		//IL_09cb->IL0a85: Incompatible stack heights: 17 vs 0
		//IL_09ed->IL0a85: Incompatible stack heights: 17 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		if ((object)_emitter1 != null)
		{
			Transform transform = _emitter1.transform;
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v52 (UnityEngine.Transform)+10]");
				bool flag = (nint)0 == 0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v52 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj3);
				bool flag2 = (object)transform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
				_ = 0;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj4);
				bool flag4 = (object)_emitter2 == null;
				Transform transform3 = _emitter2.transform;
				Transform transform4 = base.transform;
				bool flag5 = (object)transform4 == null;
				_ = 0;
				_ = 0;
				bool flag6 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
				Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj5);
				bool flag7 = (object)transform3 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v953 @ rax_v63 (UnityEngine.Transform)+10]");
				bool flag8 = (nint)0 == 0;
				object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v953 @ rax_v63 (UnityEngine.Transform)+10]");
				Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj6);
				RenderingExtensions.Start(_emitter1);
				RenderingExtensions.Start(_emitter2);
				ParticleSystem particleSystem = RenderingExtensions.SetScale(_emitter1, 1f);
				ParticleSystem particleSystem2 = RenderingExtensions.SetScale(_emitter2, 1f);
				_ = 0;
				_ = 1056964608;
				_ = 1;
				bool flag9 = (object)_lanceSprite == null;
				PhaserSprite lanceSprite = _lanceSprite;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
				PhaserSprite phaserSprite = lanceSprite.setOrigin(0f, (float?)(object)0);
				bool flag10 = (object)_weapon == null;
				float num = _weapon.PArea();
				_ = 0;
				_ = 0;
				_ = 3204448256L;
				_ = 1;
				_ = 3204448256L;
				_ = 1;
				bool flag11 = body == null;
				BaseBody baseBody = body;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
				BaseBody baseBody2 = baseBody.setCircle(1f, (float?)(object)num2, (float?)(object)0);
				_isDespawning = false;
				_isCullable = false;
				bool flag12 = (object)_lanceSprite == null;
				PhaserSprite phaserSprite2 = _lanceSprite.setVisible(visible: true);
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
				_ = 0;
				_ = 1;
				bool flag13 = (object)_lanceSprite == null;
				PhaserSprite lanceSprite2 = _lanceSprite;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
				PhaserSprite phaserSprite3 = lanceSprite2.setScale(0f, (float?)(object)0);
				bool flag14 = (object)_lanceSprite == null;
				PhaserSprite phaserSprite4 = _lanceSprite.setAlpha(1f);
				bool flag15 = (object)_lanceSprite == null;
				Transform cachedSpriteTransform = _lanceSprite.transform;
				_cachedSpriteTransform = cachedSpriteTransform;
				_collisionPos = (Vector2)0;
				_spritePos = (Vector2)0;
				bool flag16 = (object)_weapon == null;
				float num3 = _weapon.PArea();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
				float num4 = 0f * 20f;
				bool flag17 = (object)_weapon == null;
				float num5 = _weapon.PArea();
				ArcadeSprite arcadeSprite = setScale(num4, (float?)(object)0);
				_life = 0f;
				if (_tween2 != null)
				{
					_tween2.Kill();
				}
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				if ((object)_lanceSprite != null)
				{
					Transform transform5 = _lanceSprite.transform;
					if (array != null)
					{
						if ((object)transform5 != null)
						{
							nint num6 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj7 = default(object);
							bool flag18 = obj7 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
							_ = 0;
							_ = 1;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
							_ = 0;
							_ = 1120403456;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
							_ = 0;
							MultiTargetTween tween = Tweens.Add(tweenConfig);
							_tween2 = tween;
							if (_tween3 != null)
							{
								_tween3.Kill();
							}
							TweenConfig tweenConfig2 = new TweenConfig();
							object[] array2 = new object[1];
							if ((object)_lanceSprite != null)
							{
								Transform transform6 = _lanceSprite.transform;
								if (array2 != null)
								{
									if ((object)transform6 != null)
									{
										int value = ((int*)(&array2))->m_value;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj8 = default(object);
										bool flag19 = obj8 == null;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig2 != null)
									{
										((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
										_ = 0;
										_ = 1128792064;
										((MonoBehaviour)(object)tweenConfig2).m_CancellationTokenSource = (CancellationTokenSource)1120403456;
										_ = 0;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
										_ = 0;
										TweenCallback signalBus = delegate
										{
											RenderingExtensions.StopEmitting(_emitter1);
											RenderingExtensions.StopEmitting(_emitter2);
											StartDespawn();
										};
										((Equipment)(object)tweenConfig2)._signalBus = (SignalBus)(object)signalBus;
										MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
										_tween3 = tween2;
										if (lifeTween != null)
										{
											TweenExtensions.Kill(lifeTween);
										}
										DOGetter<float> getter = null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
										DOSetter<float> dOSetter = null;
										((TP_Confodere2_Projectile)(object)dOSetter)._003CInitProjectile_003Eb__15_1(num4);
										TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 1f, 0.2f);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
										if (tweenerCore != null)
										{
											lifeTween = tweenerCore;
											Weapon weapon2 = _weapon;
											if ((object)_weapon != null)
											{
												TP_Confodere2_Projectile tP_Confodere2_Projectile = (TP_Confodere2_Projectile)(object)((Equipment)weapon2)._003COwner_003Ek__BackingField;
												if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v113 (VampireSurvivors.Objects.Projectiles.TP_Confodere2_Projectile)+180]");
													float x = 0f;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v113 (VampireSurvivors.Objects.Projectiles.TP_Confodere2_Projectile)+184]");
													object obj9 = 0 ^ -0f;
													Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001870BB2FEh\"");
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v113 (VampireSurvivors.Objects.Projectiles.TP_Confodere2_Projectile)+180]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001870BB2FEh\"");
														if (obj9 == null)
														{
															x = 1f;
														}
													}
													((TP_Confodere2_Projectile)(object)((Equipment)weapon2)._003COwner_003Ek__BackingField)._003CInitProjectile_003Eb__15_1(x);
													float num7 = (float)obj9 * 57.29578f;
													object obj10 = num7 ^ -0f;
													if ((object)_lanceSprite != null)
													{
														Transform transform7 = _lanceSprite.transform;
														if ((object)transform7 != null)
														{
															Vector3 localEulerAngles = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
															transform7.localEulerAngles = localEulerAngles;
															if ((object)_lanceSprite != null)
															{
																PhaserSprite phaserSprite5 = _lanceSprite.setDepth(-1);
																float num8 = num4 * 0.01f;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
																float num9 = num8 * 6f;
																float num10 = (float)obj9 * num9;
																_collisionPos = (Vector2)num10;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																float num11 = num8 * -6f;
																float num12 = (float)obj9 * num11;
																Weapon weapon3 = _weapon;
																_ = 1047904911;
																if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
																{
																	float2 float5 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
																	int num13 = (int)_cachedSpriteTransform;
																	bool flag20 = (object)_cachedSpriteTransform == null;
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1506 @ rdi_v31 (System.Int32)+10]");
																	bool flag21 = (nint)0 == 0;
																	object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1506 @ rdi_v31 (System.Int32)+10]");
																	Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj11);
																	SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
																	{
																		Rate = 1.2f
																	};
																	object obj12 = UnityEngine.Random.value;
																	object obj13 = default(object);
																	float num14 = (float)obj13 - 0.5f;
																	_ = 0;
																	_ = 1045220557;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
																	_ = 0;
																	float num15 = num14 * 200f;
																	float time = default(float);
																	PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Victory2, soundConfig, 200f, 5, time);
																	SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig
																	{
																		Rate = 1.2f
																	};
																	object obj14 = UnityEngine.Random.value;
																	float num16 = num15 - 0.5f;
																	_ = 0;
																	_ = 1056964608;
																	_ = 1;
																	float num17 = num16 * 200f;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
																	_ = 0;
																	PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_Hasta, soundConfig2, 200f, 5, time);
																	SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig
																	{
																		Rate = 0.8f
																	};
																	object obj15 = UnityEngine.Random.value;
																	float num18 = num17 - 0.5f;
																	_ = 0;
																	_ = 1048576000;
																	_ = 1;
																	float num19 = num18 * 200f;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
																	_ = 0;
																	PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.TP_sfx_Shuriken2, soundConfig3, 200f, 5, time);
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

	public unsafe override void InternalUpdate()
	{
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = default(float2);
		base.position = float6;
		Transform cachedSpriteTransform = _cachedSpriteTransform;
		bool flag = ((UnityEngine.Object)cachedSpriteTransform).m_CachedPtr == (IntPtr)0;
		float2 value = default(float2);
		Transform.set_position_Injected(((UnityEngine.Object)cachedSpriteTransform).m_CachedPtr, ref *(Vector3*)(&value));
	}

	public void StartDespawn()
	{
		//IL_0088: Expected I, but got O
		//IL_00ec: Expected O, but got I4
		//IL_0157: Expected I, but got O
		if (_isDespawning)
		{
			return;
		}
		_isDespawning = true;
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_lanceSprite != null)
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
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween1 = tween;
		if (expireTimer != null)
		{
			expireTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Confodere2_Projectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num2 = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		expireTimer = timer;
	}

	public override void Despawn()
	{
		RenderingExtensions.StopEmitting(_emitter1);
		RenderingExtensions.StopEmitting(_emitter2);
		if (expireTimer != null)
		{
			expireTimer.Cancel();
		}
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		base.Despawn();
	}

	private unsafe void MakeEmitters()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0c89: Expected O, but got I4
		//IL_0cb0: Expected O, but got I4
		//IL_0cd7: Expected O, but got I4
		//IL_0cf0: Expected O, but got Ref
		//IL_0d0a: Expected native int or pointer, but got O
		//IL_0d24: Expected O, but got I
		//IL_0d44: Expected O, but got Ref
		//IL_0d6c: Expected native int or pointer, but got O
		//IL_0d86: Expected O, but got I
		//IL_0da6: Expected O, but got Ref
		//IL_0dc0: Expected native int or pointer, but got O
		//IL_12f5: Expected O, but got I4
		//IL_0dd8: Expected O, but got Ref
		//IL_0e00: Expected native int or pointer, but got O
		//IL_1312: Expected O, but got I4
		//IL_0e4b: Expected O, but got I
		//IL_135e: Expected O, but got I
		//IL_0f45: Expected O, but got I4
		//IL_0f6c: Expected O, but got I4
		//IL_0f93: Expected O, but got I4
		//IL_0fa7: Expected O, but got Ref
		//IL_0fc1: Expected native int or pointer, but got O
		//IL_0fe0: Expected O, but got I
		//IL_0ffb: Expected O, but got Ref
		//IL_1023: Expected native int or pointer, but got O
		//IL_1042: Expected O, but got I
		//IL_105d: Expected O, but got Ref
		//IL_1077: Expected native int or pointer, but got O
		//IL_10bc: Expected O, but got I
		//IL_10e9: Expected O, but got Ref
		//IL_1111: Expected native int or pointer, but got O
		//IL_1156: Expected O, but got I
		//IL_118f: Expected O, but got I
		//IL_1238: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 180f;
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
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
		ParticleEmitterManager pfxManager = _pfxManager;
		if ((object)_pfxManager == null || ((UnityEngine.Object)pfxManager).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager pfxManager2 = gameObject.AddComponent<ParticleEmitterManager>();
			_pfxManager = pfxManager2;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+50]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
			particleSystemConfig._angleSteps = 30;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+70]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
			particleSystemConfig._alphaEase = Easing.OutExpo;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(350f, 450f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
			_ = 0;
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
			_ = 0;
			_ = 0;
			_ = 2;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+190]");
			particleSystemConfig._quantity = (int?)(object)0;
			particleSystemConfig._tintRandom = new uint[3] { 16733268u, 16733316u, 15614787u };
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = circle;
			particleSystemConfig._emitZone = emitZone;
			minMaxCurve = new ParticleSystem.MinMaxCurve(1f);
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
			_ = 0;
			particleSystemConfig._on = true;
			ParticleSystem emitter = _pfxManager.CreateEmitter(particleSystemConfig);
			_emitter1 = emitter;
			ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
			particleSystemConfig2._frame = list;
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
			particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(90f, 450f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C0]");
			particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D0]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
			particleSystemConfig2._angleSteps = 30;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E0]");
			particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+110]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
			particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
			particleSystemConfig2._alphaEase = Easing.OutExpo;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(150f, 250f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+120]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+130]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-10]");
			particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
			_ = 0;
			_ = 0;
			_ = 2;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+190]");
			particleSystemConfig2._quantity = (int?)(object)0;
			particleSystemConfig2._tintRandom = new uint[3] { 16733268u, 16733316u, 15614787u };
			EmitZone emitZone2 = new EmitZone();
			emitZone2._type = EmitZoneType.Random;
			emitZone2._source = circle;
			particleSystemConfig2._emitZone = emitZone2;
			minMaxCurve = new ParticleSystem.MinMaxCurve(1f);
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
			particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
			_ = 0;
			particleSystemConfig2._on = true;
			ParticleSystem emitter2 = _pfxManager.CreateEmitter(particleSystemConfig2);
			_emitter2 = emitter2;
		}
	}

	private void _003CInitProjectile_003Eb__15_2()
	{
		RenderingExtensions.StopEmitting(_emitter1);
		RenderingExtensions.StopEmitting(_emitter2);
		StartDespawn();
	}

	private float _003CInitProjectile_003Eb__15_0()
	{
		return _life;
	}

	private void _003CInitProjectile_003Eb__15_1(float x)
	{
		_life = x;
	}
}
