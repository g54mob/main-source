using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class SantaJavelin2Projectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public SantaJavelin2Projectile _003C_003E4__this;

		public Vector3 targetPos;

		public Vector3 flyAwayPosition;

		public TweenCallback _003C_003E9__2;

		public TweenCallback _003C_003E9__3;

		internal void _003CInitProjectile_003Eb__0()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4CCF]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			SantaJavelin2Projectile santaJavelin2Projectile = _003C_003E4__this;
			santaJavelin2Projectile._AngelAnimation.SetAnimation("idle");
		}

		internal unsafe void _003CInitProjectile_003Eb__1()
		{
			//IL_0100: Expected I, but got O
			//IL_017c: Expected O, but got I4
			//IL_03d7: Expected O, but got Ref
			//IL_09ed: Expected I, but got O
			//IL_0a45: Expected I, but got O
			//IL_07c4: Expected O, but got Ref
			//IL_0910: Expected O, but got I
			//IL_06a7->IL0957: Incompatible stack heights: 6 vs 0
			//IL_06e2->IL0957: Incompatible stack heights: 6 vs 0
			//IL_0774->IL0957: Incompatible stack heights: 6 vs 0
			//IL_0796->IL0957: Incompatible stack heights: 6 vs 0
			//IL_08fb->IL0957: Incompatible stack heights: 6 vs 0
			//IL_0a8a->IL0957: Incompatible stack heights: 6 vs 0
			SantaJavelin2Projectile santaJavelin2Projectile = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				if (santaJavelin2Projectile._tween2 != null)
				{
					santaJavelin2Projectile._tween2.Kill();
				}
				SantaJavelin2Projectile santaJavelin2Projectile2 = _003C_003E4__this;
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				SantaJavelin2Projectile santaJavelin2Projectile3 = _003C_003E4__this;
				if ((object)_003C_003E4__this != null && (object)santaJavelin2Projectile3._GroundFx != null)
				{
					Transform transform = santaJavelin2Projectile3._GroundFx.transform;
					if (array != null)
					{
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
						if (tweenConfig != null)
						{
							tweenConfig.targets = array;
							tweenConfig.duration = 250f;
							tweenConfig.scale = (float?)(object)1;
							MultiTargetTween tween = Tweens.Add(tweenConfig);
							if ((object)_003C_003E4__this != null)
							{
								santaJavelin2Projectile2._tween2 = tween;
								SantaJavelin2Projectile santaJavelin2Projectile4 = _003C_003E4__this;
								if ((object)_003C_003E4__this != null)
								{
									GameManager core = GM.Core;
									if ((object)GM.Core != null && core._playerOptions != null)
									{
										PlayerOptionsData config = core._playerOptions.Config;
										if (config != null && (object)santaJavelin2Projectile4._Trail != null)
										{
											SpriteTrail spriteTrail = santaJavelin2Projectile4._Trail.setVisible(config._003CFlashingVFXEnabled_003Ek__BackingField);
											TweenConfig tweenConfig2 = (TweenConfig)(object)_003C_003E4__this;
											if ((object)_003C_003E4__this != null && tweenConfig2.staggerDelay != null)
											{
												((Renderer)(object)tweenConfig2.staggerDelay).enabled = true;
												SantaJavelin2Projectile santaJavelin2Projectile5 = _003C_003E4__this;
												if ((object)_003C_003E4__this != null)
												{
													Tween positionTween = santaJavelin2Projectile5._positionTween;
													if (santaJavelin2Projectile5._positionTween != null && positionTween._003Cactive_003Ek__BackingField)
													{
														DG.Tweening.TweenExtensions.Kill(santaJavelin2Projectile5._positionTween);
													}
													SantaJavelin2Projectile santaJavelin2Projectile6 = _003C_003E4__this;
													if ((object)_003C_003E4__this != null)
													{
														Vector3 value = default(Vector3);
														TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(santaJavelin2Projectile6._cachedTransform, (Vector3)(&value), 0.25f);
														if (tweenerCore != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1194 @ rax_v42 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
															if ((nint)0 != 0)
															{
																_ = 1;
																_ = 0;
															}
														}
														TweenCallback tweenCallback = _003C_003E4__this.Break;
														if (tweenerCore != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1194 @ rax_v42 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
															if ((nint)0 == 0)
															{
															}
														}
														santaJavelin2Projectile6._positionTween = tweenerCore;
														TweenConfig tweenConfig3 = (TweenConfig)(object)_003C_003E4__this;
														if ((object)_003C_003E4__this != null)
														{
															TweenConfig staggerScale = (TweenConfig)(object)tweenConfig3.staggerScale;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
															if ((nint)0 == 0)
															{
																_ = 1;
															}
															if (tweenConfig3.staggerScale != null)
															{
																staggerScale.onComplete = (TweenCallback)(object)"DefaultGameTweenId";
																SantaJavelin2Projectile santaJavelin2Projectile7 = _003C_003E4__this;
																if ((object)_003C_003E4__this != null && (object)santaJavelin2Projectile7._Trail != null)
																{
																	Transform transform2 = santaJavelin2Projectile7._Trail.transform;
																	bool flag = ((TweenConfig)(object)transform2).targets == null;
																	Transform.set_localScale_Injected((IntPtr)((TweenConfig)(object)transform2).targets, ref value);
																	SantaJavelin2Projectile santaJavelin2Projectile8 = _003C_003E4__this;
																	Transform transform3 = santaJavelin2Projectile8._JavelinSprite.transform;
																	bool flag2 = (object)transform3 == null;
																	bool flag3 = ((TweenConfig)(object)transform3).targets == null;
																	Vector3 value2 = default(Vector3);
																	Transform.set_localScale_Injected((IntPtr)((TweenConfig)(object)transform3).targets, ref value2);
																	SantaJavelin2Projectile santaJavelin2Projectile9 = _003C_003E4__this;
																	bool flag4 = (object)_003C_003E4__this == null;
																	bool flag5 = (object)santaJavelin2Projectile9._JavelinSprite == null;
																	Transform transform4 = santaJavelin2Projectile9._JavelinSprite.transform;
																	TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScaleX(transform4, 4f, 0.25f);
																	SantaJavelin2Projectile santaJavelin2Projectile10 = _003C_003E4__this;
																	bool flag6 = (object)_003C_003E4__this == null;
																	TweenCallback onUpdate = _003C_003E9__2;
																	Tween positionTween2 = santaJavelin2Projectile10._positionTween;
																	if (_003C_003E9__2 == null)
																	{
																		onUpdate = (_003C_003E9__2 = delegate
																		{
																			//IL_0008: Expected O, but got Ref
																			//IL_00bf: Expected O, but got I4
																			//IL_0249: Expected O, but got Ref
																			//IL_0102: Expected O, but got I
																			//IL_02b5: Expected I, but got O
																			//IL_030e: Expected O, but got Ref
																			object obj3 = default(object);
																			object obj2 = (object)(&obj3);
																			SantaJavelin2Projectile santaJavelin2Projectile13 = _003C_003E4__this;
																			if ((object)_003C_003E4__this != null)
																			{
																				Component explosionPfx = santaJavelin2Projectile13._explosionPfx1;
																				_ = 0;
																				if ((object)santaJavelin2Projectile13._explosionPfx1 != null)
																				{
																					Transform transform6 = santaJavelin2Projectile13._explosionPfx1.transform;
																					if ((object)transform6 != null)
																					{
																						bool flag7 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
																						Transform.get_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out Vector3 ret);
																						_ = 1;
																						_ = 1;
																						bool flag8 = (object)santaJavelin2Projectile13._explosionPfx1 == null;
																						_ = 0;
																						_ = 0;
																						_ = 0;
																						obj2 = 0;
																						_ = 0;
																						_ = 0;
																						_ = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
																						_ = 0;
																						bool flag9 = ((UnityEngine.Object)explosionPfx).m_CachedPtr == (IntPtr)0;
																						object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj3, 64));
																						ParticleSystem.Emit_Injected(((UnityEngine.Object)explosionPfx).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj4, 1);
																						Transform transform7 = (Transform)(object)_003C_003E4__this;
																						bool flag10 = (object)_003C_003E4__this == null;
																						SantaJavelin2Projectile santaJavelin2Projectile14 = _003C_003E4__this;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rdi_v14 (UnityEngine.Transform)+120]");
																						Transform transform8 = (Transform)0;
																						_ = 0;
																						bool flag11 = (object)_003C_003E4__this == null;
																						bool flag12 = (object)santaJavelin2Projectile14._explosionPfx2 == null;
																						Transform transform9 = santaJavelin2Projectile14._explosionPfx2.transform;
																						bool flag13 = (object)transform9 == null;
																						bool flag14 = (object)((_003C_003Ec__DisplayClass26_0)(object)transform9)._003C_003E4__this == null;
																						Transform.get_position_Injected((IntPtr)((_003C_003Ec__DisplayClass26_0)(object)transform9)._003C_003E4__this, out ret);
																						_ = 1;
																						_ = 1;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rdi_v14 (UnityEngine.Transform)+120]");
																						bool flag15 = (nint)0 == 0;
																						_ = 0;
																						_ = 0;
																						_ = 0;
																						_ = 0;
																						_ = 0;
																						_ = 0;
																						_ = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
																						_ = 0;
																						bool flag16 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
																						object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj3, 80));
																						ParticleSystem.Emit_Injected(((UnityEngine.Object)transform8).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj5, 1);
																						return;
																					}
																				}
																			}
																			throw new NullReferenceException();
																		});
																	}
																	if (santaJavelin2Projectile10._positionTween != null)
																	{
																		positionTween2.onUpdate = onUpdate;
																		SantaJavelin2Projectile santaJavelin2Projectile11 = _003C_003E4__this;
																		if ((object)_003C_003E4__this != null)
																		{
																			Tween positionTweenAngel = santaJavelin2Projectile11._positionTweenAngel;
																			if (santaJavelin2Projectile11._positionTweenAngel != null && positionTweenAngel._003Cactive_003Ek__BackingField)
																			{
																				DG.Tweening.TweenExtensions.Kill(santaJavelin2Projectile11._positionTweenAngel);
																			}
																			SantaJavelin2Projectile santaJavelin2Projectile12 = _003C_003E4__this;
																			if ((object)_003C_003E4__this != null && (object)santaJavelin2Projectile12._AngelSprite != null)
																			{
																				Transform transform5 = santaJavelin2Projectile12._AngelSprite.transform;
																				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOMove(transform5, (Vector3)(&value2), 0.25f);
																				if (tweenerCore3 != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1790 @ rax_v75 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																					if ((nint)0 != 0)
																					{
																						_ = 1;
																						_ = 0;
																					}
																				}
																				TweenCallback tweenCallback2 = _003C_003E9__3;
																				if (_003C_003E9__3 == null)
																				{
																					tweenCallback2 = (_003C_003E9__3 = delegate
																					{
																						SantaJavelin2Projectile santaJavelin2Projectile13 = _003C_003E4__this;
																						santaJavelin2Projectile13._AngelSprite.enabled = false;
																					});
																				}
																				if (tweenerCore3 != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1790 @ rax_v75 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																					if ((nint)0 == 0)
																					{
																					}
																				}
																				santaJavelin2Projectile12._positionTweenAngel = tweenerCore3;
																				TweenConfig tweenConfig4 = (TweenConfig)(object)_003C_003E4__this;
																				if ((object)_003C_003E4__this != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v21 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+160]");
																					TweenConfig tweenConfig5 = (TweenConfig)0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
																					if ((nint)0 == 0)
																					{
																						_ = 1;
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v21 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+160]");
																					if ((nint)0 != 0)
																					{
																						tweenConfig5.onComplete = (TweenCallback)(object)"DefaultGameTweenId";
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

		internal unsafe void _003CInitProjectile_003Eb__2()
		{
			//IL_0008: Expected O, but got Ref
			//IL_00bf: Expected O, but got I4
			//IL_0249: Expected O, but got Ref
			//IL_0102: Expected O, but got I
			//IL_02b5: Expected I, but got O
			//IL_030e: Expected O, but got Ref
			object obj2 = default(object);
			object obj = (object)(&obj2);
			SantaJavelin2Projectile santaJavelin2Projectile = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				Component explosionPfx = santaJavelin2Projectile._explosionPfx1;
				_ = 0;
				if ((object)santaJavelin2Projectile._explosionPfx1 != null)
				{
					Transform transform = santaJavelin2Projectile._explosionPfx1.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						_ = 1;
						_ = 1;
						bool flag2 = (object)santaJavelin2Projectile._explosionPfx1 == null;
						_ = 0;
						_ = 0;
						_ = 0;
						obj = 0;
						_ = 0;
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
						_ = 0;
						bool flag3 = ((UnityEngine.Object)explosionPfx).m_CachedPtr == (IntPtr)0;
						object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
						ParticleSystem.Emit_Injected(((UnityEngine.Object)explosionPfx).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj3, 1);
						Transform transform2 = (Transform)(object)_003C_003E4__this;
						bool flag4 = (object)_003C_003E4__this == null;
						SantaJavelin2Projectile santaJavelin2Projectile2 = _003C_003E4__this;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rdi_v14 (UnityEngine.Transform)+120]");
						Transform transform3 = (Transform)0;
						_ = 0;
						bool flag5 = (object)_003C_003E4__this == null;
						bool flag6 = (object)santaJavelin2Projectile2._explosionPfx2 == null;
						Transform transform4 = santaJavelin2Projectile2._explosionPfx2.transform;
						bool flag7 = (object)transform4 == null;
						bool flag8 = (object)((_003C_003Ec__DisplayClass26_0)(object)transform4)._003C_003E4__this == null;
						Transform.get_position_Injected((IntPtr)((_003C_003Ec__DisplayClass26_0)(object)transform4)._003C_003E4__this, out ret);
						_ = 1;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rdi_v14 (UnityEngine.Transform)+120]");
						bool flag9 = (nint)0 == 0;
						_ = 0;
						_ = 0;
						_ = 0;
						_ = 0;
						_ = 0;
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
						_ = 0;
						bool flag10 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
						ParticleSystem.Emit_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj4, 1);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CInitProjectile_003Eb__3()
		{
			SantaJavelin2Projectile santaJavelin2Projectile = _003C_003E4__this;
			santaJavelin2Projectile._AngelSprite.enabled = false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public SantaJavelin2Projectile _003C_003E4__this;

		public int despawnDelay;

		internal void _003CStartDespawn_003Eb__0()
		{
			//IL_0099: Expected I, but got O
			SantaJavelin2Projectile santaJavelin2Projectile = _003C_003E4__this;
			BaseBody body = santaJavelin2Projectile.body;
			body._enable = false;
			SantaJavelin2Projectile santaJavelin2Projectile2 = _003C_003E4__this;
			if (santaJavelin2Projectile2._expireTimer != null)
			{
				santaJavelin2Projectile2._expireTimer.Cancel();
			}
			object obj = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r8_v1 (Il2CppClass<System.Object>)+370]");
			Action onComplete = new Action(obj, (IntPtr)0);
			nint num = (nint)obj;
			float duration = (float)despawnDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	private SpriteAnimation _AngelAnimation;

	private SpriteRenderer _AngelSprite;

	private SpriteRenderer _JavelinSprite;

	private SpriteRenderer _GroundFx;

	private SpriteTrail _Trail;

	protected SantaJavelin2Weapon _trueWeapon;

	private Camera _camera;

	private Tween _positionTween;

	private Timer _expireTimer;

	private ParticleSystem _explosionPfx1;

	private ParticleSystem _explosionPfx2;

	private const float Radius = 32f;

	private const float ExploRadius = 8f;

	private bool _isBroken;

	private bool _isDespawning;

	private MultiTargetTween _tween1;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween3;

	private MultiTargetTween _tween4;

	private float fullSalvoDuration;

	private MultiTargetTween _angelAlphaTween;

	private TweenerCore<Vector3, Vector3, VectorOptions> _positionTweenAngel;

	private GravityWell _well;

	private ParticleEmitterManager _particlesManager;

	protected virtual bool MirrorMotion => false;

	protected override void Awake()
	{
		//IL_01f9->IL0177: Incompatible stack heights: 1 vs 0
		//IL_006a->IL0177: Incompatible stack heights: 1 vs 0
		//IL_009d->IL0177: Incompatible stack heights: 1 vs 0
		//IL_00c9->IL0177: Incompatible stack heights: 1 vs 0
		//IL_00f7->IL0177: Incompatible stack heights: 2 vs 0
		//IL_0126->IL0177: Incompatible stack heights: 2 vs 0
		//IL_0152->IL0177: Incompatible stack heights: 2 vs 0
		//IL_0289->IL0177: Incompatible stack heights: 3 vs 0
		base.Awake();
		GenerateParticleSystems();
		if ((object)_GroundFx != null)
		{
			Transform transform = _GroundFx.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
				if ((object)_GroundFx != null)
				{
					_GroundFx.enabled = false;
					if ((object)_Trail != null)
					{
						SpriteTrail spriteTrail = _Trail.setVisible(b: false);
						if ((object)_JavelinSprite != null)
						{
							Transform transform2 = _JavelinSprite.transform;
							if ((object)transform2 != null)
							{
								bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.SetParent_Injected(((UnityEngine.Object)transform2).m_CachedPtr, (IntPtr)0, true);
								if ((object)_JavelinSprite != null)
								{
									_JavelinSprite.enabled = false;
									if ((object)_AngelSprite != null)
									{
										Transform transform3 = _AngelSprite.transform;
										if ((object)transform3 != null)
										{
											bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
											Transform.SetParent_Injected(((UnityEngine.Object)transform3).m_CachedPtr, (IntPtr)0, true);
											if ((object)_AngelSprite != null)
											{
												_AngelSprite.enabled = false;
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

	private void PlaySFX()
	{
		//IL_01d5: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_010d: Expected O, but got I4
		//IL_0173: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_javelin2, soundConfig, 500f, 5, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		soundConfig2.Detune = 250f;
		soundConfig2.Delay = 0.016f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.sfx_javelin2, soundConfig2, 500f, 15, time);
		SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
		soundConfig3.Volume = (float?)(object)1;
		soundConfig3.Rate = 1f;
		soundConfig3.Detune = 500f;
		soundConfig3.Delay = 0.032f;
		PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.sfx_javelin2, soundConfig3, 500f, 15, time);
		SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
		soundConfig4.Volume = (float?)(object)1;
		soundConfig4.Rate = 1f;
		soundConfig4.Detune = 1000f;
		soundConfig4.Delay = 0.048f;
		PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.sfx_javelin2, soundConfig4, 500f, 15, time);
		SoundManager.SoundConfig soundConfig5 = new SoundManager.SoundConfig();
		soundConfig5.Volume = (float?)(object)1;
		soundConfig5.Rate = 1f;
		soundConfig5.Detune = -1000f;
		PlaySoundResult playSoundResult5 = SoundManager.PlaySound(SfxType.sfx_javelin2, soundConfig5, 500f, 15, time);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0145: Expected O, but got Ref
		//IL_0257: Expected I, but got O
		//IL_025f: Expected I, but got O
		//IL_026f: Expected O, but got I
		//IL_02ef: Expected O, but got I4
		//IL_0244: Expected O, but got I4
		//IL_0d8f: Expected O, but got I4
		//IL_02ab: Expected O, but got I
		//IL_02e1: Expected O, but got I4
		//IL_0da7: Expected I4, but got O
		//IL_0372: Expected O, but got I4
		//IL_03ea: Expected O, but got I
		//IL_03ea: Expected O, but got I
		//IL_0417: Expected O, but got I
		//IL_0e0f: Expected O, but got Ref
		//IL_0e39: Expected O, but got I
		//IL_0eab: Expected O, but got Ref
		//IL_067d: Expected O, but got I
		//IL_0692: Expected O, but got I
		//IL_0f0e: Expected O, but got Ref
		//IL_089d: Expected O, but got I
		//IL_0f6d: Expected O, but got Ref
		//IL_103c: Expected O, but got Ref
		//IL_1099: Expected O, but got Ref
		//IL_0a3e: Expected O, but got Ref
		//IL_0a9d: Expected O, but got Ref
		//IL_0eda->IL0d09: Incompatible stack heights: 1 vs 0
		//IL_06f3->IL0d09: Incompatible stack heights: 1 vs 0
		//IL_07db->IL0d09: Incompatible stack heights: 4 vs 0
		//IL_0851->IL0d09: Incompatible stack heights: 4 vs 0
		//IL_082f->IL082f: Incompatible stack heights: 5 vs 4
		//IL_0903->IL0d09: Incompatible stack heights: 4 vs 0
		//IL_0ffc->IL0d09: Incompatible stack heights: 6 vs 0
		//IL_0b82->IL0d09: Incompatible stack heights: 16 vs 0
		//IL_0bae->IL0d09: Incompatible stack heights: 16 vs 0
		//IL_0c1d->IL0d09: Incompatible stack heights: 16 vs 0
		//IL_0bfb->IL0bfb: Incompatible stack heights: 17 vs 16
		//IL_0cc8->IL0cc8: Incompatible stack heights: 16 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals50 = new _003C_003Ec__DisplayClass26_0();
		Transform transform;
		Transform transform2;
		if (CS_0024_003C_003E8__locals50 != null)
		{
			CS_0024_003C_003E8__locals50._003C_003E4__this = this;
			base.InitProjectile(pool, weapon, index);
			Weapon weapon2 = _weapon;
			if ((object)_weapon != null)
			{
				if (!weapon2.IsHoming)
				{
					transform = base.AimForRandomEnemyInScreen();
					goto IL_01d1;
				}
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					Weapon weapon3 = _weapon;
					if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
					{
						float2 float5 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
						if ((object)core._stage != null)
						{
							Vector3 queryPos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
							_ = 0;
							EnemyController enemyController = core._stage.FindClosestEnemy(queryPos, excludeDead: true);
							bool flag = (object)enemyController == null;
							float num = 3.4028235E+38f;
							transform2 = null;
							if (!flag)
							{
								bool flag2 = ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0;
								num = 3.4028235E+38f;
								transform2 = null;
								if (!flag2)
								{
									transform = enemyController.transform;
									num = 3.4028235E+38f;
									goto IL_01d1;
								}
							}
							goto IL_0d4b;
						}
					}
				}
			}
		}
		goto IL_0d09;
		IL_0d68:
		float? trueWeapon;
		_trueWeapon = (SantaJavelin2Weapon)trueWeapon;
		int num2 = (int)_camera;
		if ((object)_camera != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rdi_v23 (System.Int32)+10]");
			if ((nint)0 != 0)
			{
				goto IL_0357;
			}
		}
		Camera main = Camera.main;
		_camera = main;
		goto IL_0357;
		IL_0d09:
		throw new NullReferenceException();
		IL_0357:
		_speed = 2f;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		_ = 0;
		_ = 0;
		_ = 3238002688L;
		_ = 1;
		_ = 3238002688L;
		_ = 1;
		if (body != null)
		{
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
			BaseBody baseBody2 = baseBody.setCircle(16f, (float?)(object)num3, (float?)(object)0);
			_ = 0;
			_ = 1056964608;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
			ArcadeSprite arcadeSprite2 = setOrigin(1f, (float?)(object)0);
			ArcadeSprite arcadeSprite3 = setVisible(visible: false);
			BaseBody baseBody3 = body;
			_isCullable = false;
			_isBroken = false;
			if (body != null)
			{
				baseBody3._enable = false;
				if (_expireTimer != null)
				{
					_expireTimer.Cancel();
				}
				_isDespawning = false;
				if ((object)_renderer != null)
				{
					_renderer.enabled = true;
					if ((object)_GroundFx != null)
					{
						_GroundFx.enabled = false;
						SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_JavelinSprite, 0.5f);
						if ((object)_Trail != null)
						{
							SpriteTrail spriteTrail = _Trail.setVisible(b: false);
							if ((object)_JavelinSprite != null)
							{
								_JavelinSprite.enabled = false;
								Weapon weapon4 = _weapon;
								if ((object)_weapon != null && (object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null)
								{
									Transform transform3 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.transform;
									if ((object)transform3 != null)
									{
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rax_v81 (UnityEngine.Transform)+10]");
										if ((nint)0 == 0)
										{
											UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform3);
										}
										else
										{
											object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rax_v81 (UnityEngine.Transform)+10]");
											Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj3);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-11]");
											CS_0024_003C_003E8__locals50.targetPos = (Vector3)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-9]");
											_ = 0;
											Transform transform4 = transform2.transform;
											if ((object)transform4 != null)
											{
												_ = 0;
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rax_v89 (UnityEngine.Transform)+10]");
												bool flag3 = (nint)0 == 0;
												object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rax_v89 (UnityEngine.Transform)+10]");
												Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj4);
												if ((object)_weapon != null)
												{
													float num4 = _weapon.PArea();
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-11]");
													float num5 = 0f * 64f;
													_ = 0;
													_ = 1;
													float num6 = num5 * 0.01f;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
													setVelocity(0f, (float?)(object)0);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-11]");
													CS_0024_003C_003E8__locals50.targetPos = (Vector3)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-D]");
													_ = 0;
													Bounds bounds = CameraExtensions.OrthographicBounds(_camera);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2476 @ rax_v99 (UnityEngine.Bounds)+10]");
													_ = 0;
													_ = bounds.m_Center;
													float2 flyAwayPosition = default(float2);
													base.position = flyAwayPosition;
													if ((object)_JavelinSprite != null)
													{
														Transform transform5 = _JavelinSprite.transform;
														float2 float6 = base.position;
														bool flag4 = (object)transform5 == null;
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2483 @ rax_v101 (UnityEngine.Transform)+10]");
														bool flag5 = (nint)0 == 0;
														object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2483 @ rax_v101 (UnityEngine.Transform)+10]");
														Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj5);
														bool flag6 = (object)_AngelSprite == null;
														_AngelSprite.enabled = true;
														if (_angelAlphaTween != null)
														{
															_angelAlphaTween.Kill();
														}
														SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_AngelSprite, 0f);
														TweenConfig tweenConfig = new TweenConfig();
														object[] array = new object[1];
														if (array != null)
														{
															if ((object)_AngelSprite != null)
															{
																int value = ((int*)(&array))->m_value;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj6 = default(object);
																bool flag7 = obj6 == null;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if (tweenConfig != null)
															{
																tweenConfig.targets = array;
																_ = 0;
																tweenConfig.duration = 100f;
																_ = 1059481190;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
																tweenConfig.alpha = (float?)(object)0;
																TweenCallback onComplete = delegate
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4CCF]");
																	if ((nint)0 == 0)
																	{
																		_ = 1;
																	}
																	SantaJavelin2Projectile santaJavelin2Projectile = CS_0024_003C_003E8__locals50._003C_003E4__this;
																	santaJavelin2Projectile._AngelAnimation.SetAnimation("idle");
																};
																tweenConfig.onComplete = onComplete;
																MultiTargetTween angelAlphaTween = Tweens.Add(tweenConfig);
																_angelAlphaTween = angelAlphaTween;
																if ((object)_AngelSprite != null)
																{
																	Transform transform6 = _AngelSprite.transform;
																	float2 float7 = base.position;
																	bool flag8 = (object)transform6 == null;
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2795 @ rax_v124 (UnityEngine.Transform)+10]");
																	bool flag9 = (nint)0 == 0;
																	object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2795 @ rax_v124 (UnityEngine.Transform)+10]");
																	Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj7);
																	float2 float8 = base.position;
																	float2 float9 = base.position;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2476 @ rax_v99 (UnityEngine.Bounds)+10]");
																	float num7 = 0f * 2f;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-2D]");
																	float num8 = 0f + num7;
																	CS_0024_003C_003E8__locals50.flyAwayPosition = (Vector3)flyAwayPosition;
																	_ = 0;
																	if ((object)_Trail != null)
																	{
																		Transform transform7 = _Trail.transform;
																		_ = 0;
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2483 @ rax_v101 (UnityEngine.Transform)+10]");
																		bool flag10 = (nint)0 == 0;
																		object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2483 @ rax_v101 (UnityEngine.Transform)+10]");
																		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj8);
																		bool flag11 = (object)transform7 == null;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v132 (UnityEngine.Transform)+10]");
																		bool flag12 = (nint)0 == 0;
																		object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v132 (UnityEngine.Transform)+10]");
																		Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj9);
																		bool flag13 = (object)_Trail == null;
																		_Trail.Reset();
																		PhaserScene s_scene = ArcadePhysics.s_scene;
																		bool flag14 = ArcadePhysics.s_scene == null;
																		PhaserScene.Renderer renderer = s_scene._renderer;
																		bool flag15 = s_scene._renderer == null;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
																		bool flag16 = (object)_renderer == null;
																		int sortingOrder = default(int);
																		_renderer.sortingOrder = sortingOrder;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v2 (VampireSurvivors.Objects.Projectiles.SantaJavelin2Projectile+<>c__DisplayClass26_0)+20]");
																		_ = 0;
																		float2 float10 = base.position;
																		_ = CS_0024_003C_003E8__locals50.targetPos;
																		Vector2 vector = (Vector2)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
																		((Vector2*)vector)->Normalize();
																		bool flag17 = (object)_GroundFx == null;
																		Transform transform8 = _GroundFx.transform;
																		bool flag18 = (object)transform8 == null;
																		Vector3 vector2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-9]");
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-11]");
																		_ = 0;
																		transform8.position = vector2;
																		bool flag19 = (object)_GroundFx == null;
																		_GroundFx.enabled = true;
																		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_GroundFx, 0.15f);
																		SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale(_GroundFx, 0f);
																		if (_tween1 != null)
																		{
																			_tween1.Kill();
																		}
																		TweenConfig tweenConfig2 = new TweenConfig();
																		object[] array2 = new object[1];
																		if ((object)_GroundFx != null)
																		{
																			Transform transform9 = _GroundFx.transform;
																			if (array2 != null)
																			{
																				if ((object)transform9 != null)
																				{
																					SpriteRenderer spriteRenderer5 = RenderingExtensions.SetScale((SpriteRenderer)(object)transform9, 0f);
																					bool flag20 = (object)spriteRenderer5 == null;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																				if (tweenConfig2 != null)
																				{
																					_ = 0;
																					float num9 = num6 * 0.35f;
																					_ = 1;
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
																					_ = 0;
																					_ = 1132068864;
																					_ = 1;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
																					_ = 0;
																					TweenCallback tweenCallback = delegate
																					{
																						//IL_0100: Expected I, but got O
																						//IL_017c: Expected O, but got I4
																						//IL_03d7: Expected O, but got Ref
																						//IL_09ed: Expected I, but got O
																						//IL_0a45: Expected I, but got O
																						//IL_07c4: Expected O, but got Ref
																						//IL_0910: Expected O, but got I
																						//IL_06a7->IL0957: Incompatible stack heights: 6 vs 0
																						//IL_06e2->IL0957: Incompatible stack heights: 6 vs 0
																						//IL_0774->IL0957: Incompatible stack heights: 6 vs 0
																						//IL_0796->IL0957: Incompatible stack heights: 6 vs 0
																						//IL_08fb->IL0957: Incompatible stack heights: 6 vs 0
																						//IL_0a8a->IL0957: Incompatible stack heights: 6 vs 0
																						SantaJavelin2Projectile santaJavelin2Projectile = CS_0024_003C_003E8__locals50._003C_003E4__this;
																						if ((object)CS_0024_003C_003E8__locals50._003C_003E4__this != null)
																						{
																							if (santaJavelin2Projectile._tween2 != null)
																							{
																								santaJavelin2Projectile._tween2.Kill();
																							}
																							SantaJavelin2Projectile santaJavelin2Projectile2 = CS_0024_003C_003E8__locals50._003C_003E4__this;
																							TweenConfig tweenConfig3 = new TweenConfig();
																							object[] array3 = new object[1];
																							SantaJavelin2Projectile santaJavelin2Projectile3 = CS_0024_003C_003E8__locals50._003C_003E4__this;
																							if ((object)CS_0024_003C_003E8__locals50._003C_003E4__this != null && (object)santaJavelin2Projectile3._GroundFx != null)
																							{
																								Transform transform10 = santaJavelin2Projectile3._GroundFx.transform;
																								if (array3 != null)
																								{
																									if ((object)transform10 != null)
																									{
																										nint num13 = (nint)array3;
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																										object obj13 = default(object);
																										if (obj13 == null)
																										{
																											ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
																											throw ex;
																										}
																									}
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																									if (tweenConfig3 != null)
																									{
																										tweenConfig3.targets = array3;
																										tweenConfig3.duration = 250f;
																										tweenConfig3.scale = (float?)(object)1;
																										MultiTargetTween tween2 = Tweens.Add(tweenConfig3);
																										if ((object)CS_0024_003C_003E8__locals50._003C_003E4__this != null)
																										{
																											santaJavelin2Projectile2._tween2 = tween2;
																											SantaJavelin2Projectile santaJavelin2Projectile4 = CS_0024_003C_003E8__locals50._003C_003E4__this;
																											if ((object)CS_0024_003C_003E8__locals50._003C_003E4__this != null)
																											{
																												GameManager core2 = GM.Core;
																												if ((object)GM.Core != null && core2._playerOptions != null)
																												{
																													PlayerOptionsData config = core2._playerOptions.Config;
																													if (config != null && (object)santaJavelin2Projectile4._Trail != null)
																													{
																														SpriteTrail spriteTrail2 = santaJavelin2Projectile4._Trail.setVisible(config._003CFlashingVFXEnabled_003Ek__BackingField);
																														TweenConfig tweenConfig4 = (TweenConfig)(object)CS_0024_003C_003E8__locals50._003C_003E4__this;
																														if ((object)CS_0024_003C_003E8__locals50._003C_003E4__this != null && tweenConfig4.staggerDelay != null)
																														{
																															((Renderer)(object)tweenConfig4.staggerDelay).enabled = true;
																															SantaJavelin2Projectile santaJavelin2Projectile5 = CS_0024_003C_003E8__locals50._003C_003E4__this;
																															if ((object)CS_0024_003C_003E8__locals50._003C_003E4__this != null)
																															{
																																Tween positionTween = santaJavelin2Projectile5._positionTween;
																																if (santaJavelin2Projectile5._positionTween != null && positionTween._003Cactive_003Ek__BackingField)
																																{
																																	DG.Tweening.TweenExtensions.Kill(santaJavelin2Projectile5._positionTween);
																																}
																																SantaJavelin2Projectile santaJavelin2Projectile6 = CS_0024_003C_003E8__locals50._003C_003E4__this;
																																if ((object)CS_0024_003C_003E8__locals50._003C_003E4__this != null)
																																{
																																	Vector3 value2 = default(Vector3);
																																	TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(santaJavelin2Projectile6._cachedTransform, (Vector3)(&value2), 0.25f);
																																	if (tweenerCore != null)
																																	{
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1194 @ rax_v42 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																																		if ((nint)0 != 0)
																																		{
																																			_ = 1;
																																			_ = 0;
																																		}
																																	}
																																	TweenCallback tweenCallback2 = CS_0024_003C_003E8__locals50._003C_003E4__this.Break;
																																	if (tweenerCore != null)
																																	{
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1194 @ rax_v42 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																																		if ((nint)0 == 0)
																																		{
																																		}
																																	}
																																	santaJavelin2Projectile6._positionTween = tweenerCore;
																																	TweenConfig tweenConfig5 = (TweenConfig)(object)CS_0024_003C_003E8__locals50._003C_003E4__this;
																																	if ((object)CS_0024_003C_003E8__locals50._003C_003E4__this != null)
																																	{
																																		TweenConfig staggerScale = (TweenConfig)(object)tweenConfig5.staggerScale;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
																																		if ((nint)0 == 0)
																																		{
																																			_ = 1;
																																		}
																																		if (tweenConfig5.staggerScale != null)
																																		{
																																			staggerScale.onComplete = (TweenCallback)(object)"DefaultGameTweenId";
																																			SantaJavelin2Projectile santaJavelin2Projectile7 = CS_0024_003C_003E8__locals50._003C_003E4__this;
																																			if ((object)CS_0024_003C_003E8__locals50._003C_003E4__this != null && (object)santaJavelin2Projectile7._Trail != null)
																																			{
																																				Transform transform11 = santaJavelin2Projectile7._Trail.transform;
																																				bool flag22 = ((TweenConfig)(object)transform11).targets == null;
																																				Transform.set_localScale_Injected((IntPtr)((TweenConfig)(object)transform11).targets, ref value2);
																																				SantaJavelin2Projectile santaJavelin2Projectile8 = CS_0024_003C_003E8__locals50._003C_003E4__this;
																																				Transform transform12 = santaJavelin2Projectile8._JavelinSprite.transform;
																																				bool flag23 = (object)transform12 == null;
																																				bool flag24 = ((TweenConfig)(object)transform12).targets == null;
																																				Vector3 value3 = default(Vector3);
																																				Transform.set_localScale_Injected((IntPtr)((TweenConfig)(object)transform12).targets, ref value3);
																																				SantaJavelin2Projectile santaJavelin2Projectile9 = CS_0024_003C_003E8__locals50._003C_003E4__this;
																																				bool flag25 = (object)CS_0024_003C_003E8__locals50._003C_003E4__this == null;
																																				bool flag26 = (object)santaJavelin2Projectile9._JavelinSprite == null;
																																				Transform target = santaJavelin2Projectile9._JavelinSprite.transform;
																																				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScaleX(target, 4f, 0.25f);
																																				SantaJavelin2Projectile santaJavelin2Projectile10 = CS_0024_003C_003E8__locals50._003C_003E4__this;
																																				bool flag27 = (object)CS_0024_003C_003E8__locals50._003C_003E4__this == null;
																																				TweenCallback onUpdate = CS_0024_003C_003E8__locals50._003C_003E9__2;
																																				Tween positionTween2 = santaJavelin2Projectile10._positionTween;
																																				if (CS_0024_003C_003E8__locals50._003C_003E9__2 == null)
																																				{
																																					onUpdate = (CS_0024_003C_003E8__locals50._003C_003E9__2 = delegate
																																					{
																																						//IL_0008: Expected O, but got Ref
																																						//IL_00bf: Expected O, but got I4
																																						//IL_0249: Expected O, but got Ref
																																						//IL_0102: Expected O, but got I
																																						//IL_02b5: Expected I, but got O
																																						//IL_030e: Expected O, but got Ref
																																						object obj15 = default(object);
																																						object obj14 = (object)(&obj15);
																																						SantaJavelin2Projectile santaJavelin2Projectile13 = CS_0024_003C_003E8__locals50._003C_003E4__this;
																																						if ((object)CS_0024_003C_003E8__locals50._003C_003E4__this != null)
																																						{
																																							Component explosionPfx = santaJavelin2Projectile13._explosionPfx1;
																																							_ = 0;
																																							if ((object)santaJavelin2Projectile13._explosionPfx1 != null)
																																							{
																																								Transform transform13 = santaJavelin2Projectile13._explosionPfx1.transform;
																																								if ((object)transform13 != null)
																																								{
																																									bool flag28 = ((UnityEngine.Object)transform13).m_CachedPtr == (IntPtr)0;
																																									Transform.get_position_Injected(((UnityEngine.Object)transform13).m_CachedPtr, out Vector3 ret);
																																									_ = 1;
																																									_ = 1;
																																									bool flag29 = (object)santaJavelin2Projectile13._explosionPfx1 == null;
																																									_ = 0;
																																									_ = 0;
																																									_ = 0;
																																									obj14 = 0;
																																									_ = 0;
																																									_ = 0;
																																									_ = 0;
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
																																									_ = 0;
																																									bool flag30 = ((UnityEngine.Object)explosionPfx).m_CachedPtr == (IntPtr)0;
																																									object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj15, 64));
																																									ParticleSystem.Emit_Injected(((UnityEngine.Object)explosionPfx).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj16, 1);
																																									Transform transform14 = (Transform)(object)CS_0024_003C_003E8__locals50._003C_003E4__this;
																																									bool flag31 = (object)CS_0024_003C_003E8__locals50._003C_003E4__this == null;
																																									SantaJavelin2Projectile santaJavelin2Projectile14 = CS_0024_003C_003E8__locals50._003C_003E4__this;
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rdi_v14 (UnityEngine.Transform)+120]");
																																									Transform transform15 = (Transform)0;
																																									_ = 0;
																																									bool flag32 = (object)CS_0024_003C_003E8__locals50._003C_003E4__this == null;
																																									bool flag33 = (object)santaJavelin2Projectile14._explosionPfx2 == null;
																																									Transform transform16 = santaJavelin2Projectile14._explosionPfx2.transform;
																																									bool flag34 = (object)transform16 == null;
																																									bool flag35 = (object)((_003C_003Ec__DisplayClass26_0)(object)transform16)._003C_003E4__this == null;
																																									Transform.get_position_Injected((IntPtr)((_003C_003Ec__DisplayClass26_0)(object)transform16)._003C_003E4__this, out ret);
																																									_ = 1;
																																									_ = 1;
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rdi_v14 (UnityEngine.Transform)+120]");
																																									bool flag36 = (nint)0 == 0;
																																									_ = 0;
																																									_ = 0;
																																									_ = 0;
																																									_ = 0;
																																									_ = 0;
																																									_ = 0;
																																									_ = 0;
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
																																									_ = 0;
																																									bool flag37 = ((UnityEngine.Object)transform15).m_CachedPtr == (IntPtr)0;
																																									object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj15, 80));
																																									ParticleSystem.Emit_Injected(((UnityEngine.Object)transform15).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj17, 1);
																																									return;
																																								}
																																							}
																																						}
																																						throw new NullReferenceException();
																																					});
																																				}
																																				if (santaJavelin2Projectile10._positionTween != null)
																																				{
																																					positionTween2.onUpdate = onUpdate;
																																					SantaJavelin2Projectile santaJavelin2Projectile11 = CS_0024_003C_003E8__locals50._003C_003E4__this;
																																					if ((object)CS_0024_003C_003E8__locals50._003C_003E4__this != null)
																																					{
																																						Tween positionTweenAngel = santaJavelin2Projectile11._positionTweenAngel;
																																						if (santaJavelin2Projectile11._positionTweenAngel != null && positionTweenAngel._003Cactive_003Ek__BackingField)
																																						{
																																							DG.Tweening.TweenExtensions.Kill(santaJavelin2Projectile11._positionTweenAngel);
																																						}
																																						SantaJavelin2Projectile santaJavelin2Projectile12 = CS_0024_003C_003E8__locals50._003C_003E4__this;
																																						if ((object)CS_0024_003C_003E8__locals50._003C_003E4__this != null && (object)santaJavelin2Projectile12._AngelSprite != null)
																																						{
																																							Transform target2 = santaJavelin2Projectile12._AngelSprite.transform;
																																							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOMove(target2, (Vector3)(&value3), 0.25f);
																																							if (tweenerCore3 != null)
																																							{
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1790 @ rax_v75 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																																								if ((nint)0 != 0)
																																								{
																																									_ = 1;
																																									_ = 0;
																																								}
																																							}
																																							TweenCallback tweenCallback3 = CS_0024_003C_003E8__locals50._003C_003E9__3;
																																							if (CS_0024_003C_003E8__locals50._003C_003E9__3 == null)
																																							{
																																								tweenCallback3 = (CS_0024_003C_003E8__locals50._003C_003E9__3 = delegate
																																								{
																																									SantaJavelin2Projectile santaJavelin2Projectile13 = CS_0024_003C_003E8__locals50._003C_003E4__this;
																																									santaJavelin2Projectile13._AngelSprite.enabled = false;
																																								});
																																							}
																																							if (tweenerCore3 != null)
																																							{
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1790 @ rax_v75 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																																								if ((nint)0 == 0)
																																								{
																																								}
																																							}
																																							santaJavelin2Projectile12._positionTweenAngel = tweenerCore3;
																																							TweenConfig tweenConfig6 = (TweenConfig)(object)CS_0024_003C_003E8__locals50._003C_003E4__this;
																																							if ((object)CS_0024_003C_003E8__locals50._003C_003E4__this != null)
																																							{
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v21 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+160]");
																																								TweenConfig tweenConfig7 = (TweenConfig)0;
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
																																								if ((nint)0 == 0)
																																								{
																																									_ = 1;
																																								}
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v21 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+160]");
																																								if ((nint)0 != 0)
																																								{
																																									tweenConfig7.onComplete = (TweenCallback)(object)"DefaultGameTweenId";
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
																					};
																					MultiTargetTween tween = Tweens.Add(tweenConfig2);
																					_tween1 = tween;
																					PlaySFX();
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
		goto IL_0d09;
		IL_01d1:
		transform2 = transform;
		goto IL_0d4b;
		IL_0d4b:
		object obj12;
		if ((object)transform2 != null && ((UnityEngine.Object)transform2).m_CachedPtr != (IntPtr)0)
		{
			Weapon weapon5 = _weapon;
			if ((object)_weapon == null)
			{
				trueWeapon = (float?)(object)0;
				goto IL_0d68;
			}
			nint num10 = (nint)typeof(SantaJavelin2Weapon);
			nint num11 = (nint)weapon5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1259 @ r8_v76 (Il2CppClass<VampireSurvivors.Objects.Weapons.SantaJavelin2Weapon>)+130]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1260 @ r9_v30 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1259 @ r8_v76 (Il2CppClass<VampireSurvivors.Objects.Weapons.SantaJavelin2Weapon>)+130]");
			if (num12 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1260 @ r9_v30 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1372 @ rax_v235+FFFFFFF8+v1261 @ rax_v230*8]");
				if (0 == (nint)typeof(SantaJavelin2Weapon))
				{
					obj12 = 1;
					goto IL_0d77;
				}
			}
			obj12 = 0;
			goto IL_0d77;
		}
		Despawn();
		return;
		IL_0d77:
		bool flag21 = obj12 == null;
		trueWeapon = (float?)(object)0;
		if (!flag21)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0d68;
	}

	public override void InternalUpdate()
	{
		if ((object)_JavelinSprite != null)
		{
			Transform transform = _JavelinSprite.transform;
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void Break()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00a1: Expected I, but got O
		//IL_00b1: Expected O, but got I
		//IL_00da: Invalid comparison between F4 and I4
		//IL_085b: Expected I, but got O
		//IL_0111: Expected O, but got I
		//IL_012c: Invalid comparison between F4 and I4
		//IL_02d1: Expected I, but got O
		//IL_0355: Expected I, but got O
		//IL_03e2: Expected O, but got I
		//IL_041f: Expected O, but got I
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Expected O, but got Unknown
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Expected O, but got Unknown
		//IL_055a: Expected O, but got I
		//IL_055a: Expected O, but got I
		//IL_05b7: Expected O, but got I4
		//IL_0728: Expected O, but got I4
		//IL_096a: Expected O, but got Ref
		//IL_0a3b: Expected O, but got Ref
		//IL_0a5a->IL0a5a: Incompatible stack heights: 8 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (_isBroken)
		{
			return;
		}
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			if (weapon._explodeOnExpire)
			{
				float2 pos = base.position;
				Projectile projectile = _weapon.SpawnExplosionAt(pos, 0, 1, 0f);
				Weapon weapon2 = null;
				int num = 1;
			}
			Weapon trueWeapon = _trueWeapon;
			float2 float5 = base.position;
			if ((object)_trueWeapon != null)
			{
				nint num2 = (nint)trueWeapon;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+410]");
				float2 float6 = (float2)0;
				float num3 = ((Weapon)_trueWeapon).PAmount();
				float num4 = 1f * 0.5f;
				if (!(num4 > 0f))
				{
					goto IL_015b;
				}
				float2 float7 = default(float2);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rbx_v16 (VampireSurvivors.Objects.Weapons.Weapon)+228]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rbx_v16 (VampireSurvivors.Objects.Weapons.Weapon)+228]");
					Projectile projectile2 = ((BulletPool)0).SpawnAt(float7, _trueWeapon);
					int num5 = 0 + 1;
					bool flag = num4 > (float)num5;
					float6 = float7;
					Weapon weapon2 = _trueWeapon;
					int num = 0;
					if (flag)
					{
						continue;
					}
					goto IL_015b;
				}
			}
		}
		goto IL_07c2;
		IL_015b:
		_isBroken = true;
		nint num6 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v781 @ rax_v42 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num7 = 0;
		ArcadeSprite sprite = _sprite;
		if ((object)_sprite != null)
		{
			BaseBody baseBody = sprite.body;
			if (sprite.body != null)
			{
				baseBody._velocity = Vector2.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rcx_v35 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
				_ = 0;
				if (_objectsHit != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
					BaseBody baseBody2 = body;
					if (body != null)
					{
						baseBody2._enable = true;
						if (_tween4 != null)
						{
							_tween4.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[2];
						if ((object)_JavelinSprite != null)
						{
							Transform transform = _JavelinSprite.transform;
							if (array != null)
							{
								if ((object)transform != null)
								{
									nint num8 = (nint)array;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj3 = default(object);
									if (obj3 == null)
									{
										ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
										throw ex;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if ((object)_Trail != null)
								{
									Transform transform2 = _Trail.transform;
									if ((object)transform2 != null)
									{
										nint num9 = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj4 = default(object);
										if (obj4 == null)
										{
											ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
											throw ex2;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig != null)
									{
										tweenConfig.targets = array;
										_ = 0;
										_ = 0;
										_ = 1;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+150]");
										tweenConfig.alpha = (float?)(object)0;
										tweenConfig.duration = 200f;
										tweenConfig.ease = Ease.InQuad;
										_ = 0;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+150]");
										tweenConfig.scale = (float?)(object)0;
										TweenCallback onComplete = StartDespawn;
										tweenConfig.onComplete = onComplete;
										MultiTargetTween tween = Tweens.Add(tweenConfig);
										_tween4 = tween;
										if ((object)_weapon != null)
										{
											float num10 = _weapon.PArea();
											float num11 = (float)Vector2.zeroVector * 32f;
											_ = 0;
											_ = 0;
											_ = 1;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
											object obj5 = num11 ^ 0;
											float num12 = (float)obj5 + 16f;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
											object obj6 = num11 ^ 0;
											float num13 = (float)obj6 + 16f;
											if (body != null)
											{
												BaseBody baseBody3 = body;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+160]");
												nint num14 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+150]");
												BaseBody baseBody4 = baseBody3.setCircle(num11, (float?)(object)num14, (float?)(object)0);
												PhaserScene s_scene = ArcadePhysics.s_scene;
												if (ArcadePhysics.s_scene != null)
												{
													PhaserScene.Renderer renderer = s_scene._renderer;
													if (s_scene._renderer != null)
													{
														int num15 = renderer.pixelHeight >> 31;
														object obj7 = renderer.pixelHeight - num15;
														object obj8 = obj7 >> 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
														if ((object)_GroundFx != null)
														{
															int sortingOrder = default(int);
															_GroundFx.sortingOrder = sortingOrder;
															GameManager core = GM.Core;
															if ((object)GM.Core != null && core._playerOptions != null)
															{
																PlayerOptionsData config = core._playerOptions.Config;
																if (config != null)
																{
																	if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
																	{
																		return;
																	}
																	object explosionPfx = _explosionPfx1;
																	_ = 0;
																	if ((object)_explosionPfx1 != null)
																	{
																		Transform transform3 = _explosionPfx1.transform;
																		if ((object)transform3 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rax_v83 (UnityEngine.Transform)+10]");
																			bool flag2 = (nint)0 == 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rax_v83 (UnityEngine.Transform)+10]");
																			Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
																			_ = 1;
																			_ = 1;
																			bool flag3 = (object)_explosionPfx1 == null;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
																			_ = 0;
																			_ = 0;
																			_ = 0;
																			obj = 0;
																			_ = 0;
																			_ = 0;
																			_ = 0;
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rsi_v21 (System.Object)+10]");
																			bool flag4 = (nint)0 == 0;
																			object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rsi_v21 (System.Object)+10]");
																			ParticleSystem.Emit_Injected((IntPtr)0, ref *(ParticleSystem.EmitParams*)obj9, 12);
																			object explosionPfx2 = _explosionPfx2;
																			_ = 0;
																			bool flag5 = (object)_explosionPfx2 == null;
																			Transform transform4 = _explosionPfx2.transform;
																			bool flag6 = (object)transform4 == null;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1543 @ rax_v94 (UnityEngine.Transform)+10]");
																			bool flag7 = (nint)0 == 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1543 @ rax_v94 (UnityEngine.Transform)+10]");
																			Transform.get_position_Injected((IntPtr)0, out ret);
																			_ = 1;
																			_ = 1;
																			bool flag8 = (object)_explosionPfx2 == null;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
																			_ = 0;
																			_ = 0;
																			_ = 0;
																			_ = 0;
																			_ = 0;
																			_ = 0;
																			_ = 0;
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1005 @ rsi_v22 (System.Object)+10]");
																			bool flag9 = (nint)0 == 0;
																			object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1005 @ rsi_v22 (System.Object)+10]");
																			ParticleSystem.Emit_Injected((IntPtr)0, ref *(ParticleSystem.EmitParams*)obj10, 12);
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
		goto IL_07c2;
		IL_07c2:
		throw new NullReferenceException();
	}

	private void StartDespawn()
	{
		//IL_015a: Expected I, but got O
		//IL_01be: Expected O, but got I4
		_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass29_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		if (_isDespawning)
		{
			return;
		}
		SpriteTrail spriteTrail = _Trail.setVisible(b: false);
		Tween positionTween = _positionTween;
		_isCullable = true;
		if (_positionTween != null && positionTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_positionTween);
		}
		SpriteTrail spriteTrail2 = _Trail.setVisible(b: false);
		_isDespawning = true;
		CS_0024_003C_003E8__locals6.despawnDelay = 1100;
		if (_tween4 != null)
		{
			_tween4.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_JavelinSprite != null)
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
		TweenCallback onComplete = delegate
		{
			//IL_0099: Expected I, but got O
			SantaJavelin2Projectile santaJavelin2Projectile = CS_0024_003C_003E8__locals6._003C_003E4__this;
			BaseBody baseBody = santaJavelin2Projectile.body;
			baseBody._enable = false;
			SantaJavelin2Projectile santaJavelin2Projectile2 = CS_0024_003C_003E8__locals6._003C_003E4__this;
			if (santaJavelin2Projectile2._expireTimer != null)
			{
				santaJavelin2Projectile2._expireTimer.Cancel();
			}
			object obj2 = CS_0024_003C_003E8__locals6._003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r8_v1 (Il2CppClass<System.Object>)+370]");
			Action onComplete2 = new Action(obj2, (IntPtr)0);
			nint num2 = (nint)obj2;
			float duration = (float)CS_0024_003C_003E8__locals6.despawnDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween4 = tween;
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		_isCullable = true;
		_GroundFx.enabled = false;
		Tween positionTween = _positionTween;
		if (_positionTween != null && positionTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_positionTween);
		}
		SpriteTrail spriteTrail = _Trail.setVisible(b: false);
		base.Despawn();
	}

	private void GetComponents()
	{
		Camera camera = _camera;
		if ((object)_camera == null || ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0)
		{
			Camera main = Camera.main;
			_camera = main;
		}
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_016e: Expected O, but got I4
		//IL_0187: Expected O, but got Ref
		//IL_01a1: Expected native int or pointer, but got O
		//IL_01bb: Expected O, but got I
		//IL_01db: Expected O, but got Ref
		//IL_01f5: Expected native int or pointer, but got O
		//IL_020f: Expected O, but got I
		//IL_022f: Expected O, but got Ref
		//IL_0249: Expected native int or pointer, but got O
		//IL_087a: Expected O, but got I
		//IL_0281: Expected O, but got Ref
		//IL_02a8: Expected O, but got I
		//IL_02c2: Expected native int or pointer, but got O
		//IL_08b4: Expected O, but got I
		//IL_02fa: Expected O, but got Ref
		//IL_0314: Expected native int or pointer, but got O
		//IL_08ee: Expected O, but got I
		//IL_034c: Expected O, but got Ref
		//IL_0373: Expected O, but got I
		//IL_038d: Expected native int or pointer, but got O
		//IL_03a8: Expected O, but got I
		//IL_0928: Expected O, but got I
		//IL_03e1: Expected O, but got I
		//IL_0435: Expected I, but got O
		//IL_0570: Expected O, but got Ref
		//IL_058a: Expected native int or pointer, but got O
		//IL_05bc: Expected O, but got Ref
		//IL_05d6: Expected native int or pointer, but got O
		//IL_0608: Expected O, but got Ref
		//IL_0622: Expected native int or pointer, but got O
		//IL_065a: Expected O, but got Ref
		//IL_0693: Expected native int or pointer, but got O
		//IL_06cb: Expected O, but got Ref
		//IL_0704: Expected native int or pointer, but got O
		//IL_0799: Expected I, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 592))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+250]");
			particlesManager = (ParticleEmitterManager)0;
		}
		else
		{
			particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particlesManager = particlesManager;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Burst1");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+98]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B8]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 248));
		_ = 0;
		_ = 4;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+250]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+108]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		particleSystemConfig._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.15f, 0.15f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+118]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+128]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
		particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-10]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 312));
		_ = 0;
		_ = 1082130432;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+250]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0.35f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+138]");
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+148]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
		_ = 0;
		_ = 0;
		_ = 16776345;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+250]");
		particleSystemConfig._tint = (uint?)(object)0;
		particleSystemConfig._on = false;
		ParticleSystem explosionPfx = _particlesManager.CreateEmitter(particleSystemConfig, null, "ExplosionPfx1");
		_explosionPfx1 = explosionPfx;
		Transform transform = _explosionPfx1.transform;
		nint num2 = (nint)_cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v16 (Il2CppMethodInfo)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v16 (Il2CppMethodInfo)+10]");
		Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
		bool flag2 = (object)transform == null;
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		list2._002Ector();
		bool flag4 = list2 == null;
		int version2 = list2._version + 1;
		list2._version = version2;
		string[] items2 = list2._items;
		bool flag5 = list2._items == null;
		if (list2._size >= items2.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"Burst1");
		}
		else
		{
			int num3 = list2._size + 1;
			list2._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		bool flag6 = particleSystemConfig2 == null;
		minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
		_ = 0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 344));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+158]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+168]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 376));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+178]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+188]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 408));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(100f, 200f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+198]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+40]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 440));
		_ = 0;
		_ = 4;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+250]");
		_ = 0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 472));
		_ = 0;
		_ = 1082130432;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+250]");
		_ = 0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(0.35f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1D8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1E8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+90]");
		_ = 0;
		_ = 0;
		_ = 16776345;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+250]");
		_ = 0;
		_ = 0;
		ParticleSystem explosionPfx2 = _particlesManager.CreateEmitter(particleSystemConfig, null, "ExplosionPfx1");
		_explosionPfx2 = explosionPfx2;
		Transform transform2 = _explosionPfx2.transform;
		nint num4 = (nint)_cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rbx_v19 (Il2CppMethodInfo)+10]");
		bool flag7 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rbx_v19 (Il2CppMethodInfo)+10]");
		Transform.get_position_Injected((IntPtr)0, out ret);
		bool flag8 = (object)transform2 == null;
		bool flag9 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		bool flag10 = gravityWellConfig == null;
		_ = 1065353216;
		_ = 1112014848;
		_ = 1101004800;
		bool flag11 = (object)_particlesManager == null;
		GravityWell well = _particlesManager.CreateGravityWell(gravityWellConfig);
		_well = well;
		bool flag12 = (object)_well == null;
		Transform transform3 = _well.transform;
		bool flag13 = (object)transform3 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1320 @ rax_v129 (UnityEngine.Transform)+10]");
		bool flag14 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1320 @ rax_v129 (UnityEngine.Transform)+10]");
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)0, ref value2);
	}
}
