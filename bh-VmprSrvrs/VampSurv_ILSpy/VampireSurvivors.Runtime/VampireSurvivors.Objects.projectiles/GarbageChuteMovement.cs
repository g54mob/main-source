using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class GarbageChuteMovement
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__16_2;

		public static TweenCallback _003C_003E9__18_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CstartChute_003Eb__16_2()
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_GarbageEnd, 2000f, 10, 0f, volume, rate, detune, loop, 1f);
		}

		internal void _003CmoveChuteDown_003Eb__18_0()
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_GarbageStart, 2000f, 10, 0f, volume, rate, detune, loop, 1f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public GarbageChuteMovement _003C_003E4__this;

		public float newChutePosX;

		public float dur;

		public TweenCallback _003C_003E9__1;

		internal void _003CmoveChuteAcross_003Eb__0()
		{
			//IL_0098: Expected I, but got O
			GarbageChuteMovement garbageChuteMovement = _003C_003E4__this;
			TweenConfig tweenConfig = new TweenConfig();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary._002Ector();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"ChuteOffsetX", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = dur;
			object[] array = new object[1];
			if (_003C_003E4__this != null)
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
			tweenConfig.ease = Ease.InOutSine;
			TweenCallback onComplete = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				onComplete = (_003C_003E9__1 = delegate
				{
					_003C_003E4__this.moveChuteAcross();
				});
			}
			tweenConfig.onComplete = onComplete;
			MultiTargetTween chuteMoveTweens = Tweens.Add(tweenConfig);
			garbageChuteMovement.ChuteMoveTweens = chuteMoveTweens;
		}

		internal void _003CmoveChuteAcross_003Eb__1()
		{
			_003C_003E4__this.moveChuteAcross();
		}
	}

	[NonSerialized]
	public PhaserSprite ChuteSprite;

	[NonSerialized]
	public PhaserSprite ChuteSpriteLeft;

	[NonSerialized]
	public PhaserSprite ChuteSpriteRight;

	[NonSerialized]
	public MultiTargetTween ChuteMoveTweens;

	[NonSerialized]
	public bool ChuteActive;

	[NonSerialized]
	public bool ChuteFollowingScreen;

	[NonSerialized]
	public float ChuteOffsetX;

	[NonSerialized]
	public float ChuteOffsetY;

	private float _chuteSpeed = 0.01f;

	private GarbageChuteWeapon _trueWeapon;

	private int _chuteIndex;

	private Timer _moveChuteTimer;

	private Timer _projectileStartTimer;

	private Timer _projectileEndTimer;

	private Timer _projectileLeftScreenTimer;

	public void createChute(GarbageChuteWeapon weapon, int index)
	{
		_trueWeapon = weapon;
		_chuteIndex = index;
		ChuteOffsetX = 0f;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		ChuteOffsetY = renderer.height;
	}

	public void startChute()
	{
		//IL_00eb: Expected O, but got I4
		//IL_0128: Expected O, but got I
		//IL_0205: Expected O, but got I4
		//IL_0242: Expected O, but got I
		//IL_036a: Expected O, but got I4
		//IL_061f->IL059a: Incompatible stack heights: 1 vs 0
		//IL_0057->IL059a: Incompatible stack heights: 1 vs 0
		//IL_0646->IL059a: Incompatible stack heights: 1 vs 0
		//IL_007e->IL059a: Incompatible stack heights: 1 vs 0
		//IL_00a0->IL059a: Incompatible stack heights: 1 vs 0
		//IL_00d1->IL059a: Incompatible stack heights: 1 vs 0
		//IL_0113->IL059a: Incompatible stack heights: 1 vs 0
		//IL_0148->IL059a: Incompatible stack heights: 1 vs 0
		//IL_06a6->IL059a: Incompatible stack heights: 2 vs 0
		//IL_0170->IL059a: Incompatible stack heights: 2 vs 0
		//IL_06cd->IL059a: Incompatible stack heights: 2 vs 0
		//IL_0198->IL059a: Incompatible stack heights: 2 vs 0
		//IL_01ba->IL059a: Incompatible stack heights: 2 vs 0
		//IL_01eb->IL059a: Incompatible stack heights: 2 vs 0
		//IL_022d->IL059a: Incompatible stack heights: 2 vs 0
		//IL_0262->IL059a: Incompatible stack heights: 2 vs 0
		//IL_0727->IL059a: Incompatible stack heights: 3 vs 0
		//IL_028b->IL059a: Incompatible stack heights: 3 vs 0
		//IL_02a9->IL059a: Incompatible stack heights: 3 vs 0
		//IL_074e->IL059a: Incompatible stack heights: 3 vs 0
		//IL_02d0->IL059a: Incompatible stack heights: 3 vs 0
		//IL_02f2->IL059a: Incompatible stack heights: 3 vs 0
		//IL_032d->IL059a: Incompatible stack heights: 3 vs 0
		//IL_034c->IL059a: Incompatible stack heights: 3 vs 0
		//IL_03a1->IL059a: Incompatible stack heights: 3 vs 0
		//IL_03d4->IL059a: Incompatible stack heights: 3 vs 0
		//IL_0407->IL059a: Incompatible stack heights: 3 vs 0
		//IL_053e->IL059a: Incompatible stack heights: 3 vs 0
		PhaserSprite chuteSpriteLeft = ChuteSpriteLeft;
		if ((object)ChuteSpriteLeft != null)
		{
			SpriteRenderer spriteRenderer = chuteSpriteLeft._spriteRenderer;
			if ((object)chuteSpriteLeft._spriteRenderer != null)
			{
				bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				SpriteRenderer.set_drawMode_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, SpriteDrawMode.Tiled);
				PhaserSprite chuteSpriteLeft2 = ChuteSpriteLeft;
				if ((object)ChuteSpriteLeft != null && (object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)chuteSpriteLeft2._spriteRenderer != null)
					{
						Vector2 size = default(Vector2);
						chuteSpriteLeft2._spriteRenderer.size = size;
						if ((object)ChuteSpriteLeft != null)
						{
							PhaserSprite phaserSprite = ChuteSpriteLeft.setScale(0.2f, (float?)(object)1);
							SpriteRenderer chuteSpriteRight = (SpriteRenderer)(object)ChuteSpriteRight;
							if ((object)ChuteSpriteRight != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rbx_v11 (UnityEngine.SpriteRenderer)+28]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rbx_v11 (UnityEngine.SpriteRenderer)+28]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rbx_v12 (System.Object)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rbx_v12 (System.Object)+10]");
									SpriteRenderer.set_drawMode_Injected((IntPtr)0, SpriteDrawMode.Tiled);
									PhaserSprite chuteSpriteRight2 = ChuteSpriteRight;
									if ((object)ChuteSpriteRight != null && (object)GM.Core != null)
									{
										PhaserScene s_scene2 = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null && s_scene2._renderer != null && (object)chuteSpriteRight2._spriteRenderer != null)
										{
											chuteSpriteRight2._spriteRenderer.size = size;
											if ((object)ChuteSpriteRight != null)
											{
												PhaserSprite phaserSprite2 = ChuteSpriteRight.setScale(0.2f, (float?)(object)1);
												SpriteRenderer chuteSprite = (SpriteRenderer)(object)ChuteSprite;
												if ((object)ChuteSprite != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rbx_v14 (UnityEngine.SpriteRenderer)+28]");
													SpriteRenderer spriteRenderer2 = (SpriteRenderer)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rbx_v14 (UnityEngine.SpriteRenderer)+28]");
													if ((nint)0 != 0)
													{
														bool flag3 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
														SpriteRenderer.set_drawMode_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, SpriteDrawMode.Tiled);
														PhaserSprite chuteSprite2 = ChuteSprite;
														if ((object)ChuteSprite != null && (object)_trueWeapon != null && (object)GM.Core != null)
														{
															PhaserScene s_scene3 = ArcadePhysics.s_scene;
															if (ArcadePhysics.s_scene != null && s_scene3._renderer != null && (object)chuteSprite2._spriteRenderer != null)
															{
																chuteSprite2._spriteRenderer.size = size;
																GarbageChuteWeapon trueWeapon = _trueWeapon;
																if ((object)_trueWeapon != null && (object)ChuteSprite != null)
																{
																	PhaserSprite phaserSprite3 = ChuteSprite.setScale(trueWeapon.ChuteArea, (float?)(object)1);
																	float chuteOffsetX = calcNewChuteXPos();
																	ChuteOffsetX = chuteOffsetX;
																	if ((object)ChuteSprite != null)
																	{
																		PhaserSprite phaserSprite4 = ChuteSprite.setVisible(visible: true);
																		if ((object)ChuteSpriteLeft != null)
																		{
																			PhaserSprite phaserSprite5 = ChuteSpriteLeft.setVisible(visible: true);
																			if ((object)ChuteSpriteRight != null)
																			{
																				PhaserSprite phaserSprite6 = ChuteSpriteRight.setVisible(visible: true);
																				moveChuteAcross();
																				Action onComplete = delegate
																				{
																					moveChuteDown();
																				};
																				bool useRealTime = default(bool);
																				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																				int repeat = default(int);
																				TimerType type = default(TimerType);
																				Timer moveChuteTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																				_moveChuteTimer = moveChuteTimer;
																				Action onComplete2 = delegate
																				{
																					//IL_0049: Expected F4, but got I4
																					ChuteFollowingScreen = true;
																					_trueWeapon.startFiringProjectile(_chuteIndex);
																					float? volume = default(float?);
																					float rate = default(float);
																					float detune = default(float);
																					bool loop = default(bool);
																					PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_GarbageStart, 2000f, 10, 0f, volume, rate, detune, loop, 1f);
																				};
																				Timer projectileStartTimer = Timers.Register(1.2f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																				_projectileStartTimer = projectileStartTimer;
																				Action onComplete3 = _003C_003Ec._003C_003E9__16_2;
																				if (_003C_003Ec._003C_003E9__16_2 == null)
																				{
																					onComplete3 = (_003C_003Ec._003C_003E9__16_2 = delegate
																					{
																						//IL_0033: Expected F4, but got I4
																						float? volume = default(float?);
																						float rate = default(float);
																						float detune = default(float);
																						bool loop = default(bool);
																						PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_GarbageEnd, 2000f, 10, 0f, volume, rate, detune, loop, 1f);
																					});
																				}
																				Timer projectileEndTimer = Timers.Register(2f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																				_projectileEndTimer = projectileEndTimer;
																				if ((object)_trueWeapon != null)
																				{
																					float num = _trueWeapon.PDuration();
																					bool flag4 = !(2000f > 2f);
																					float num2 = 2f;
																					if (!flag4)
																					{
																						num2 = 2000f;
																					}
																					Action onComplete4 = delegate
																					{
																						hideChute();
																					};
																					float num3 = num2 + 2000f;
																					float duration = num3 * 0.001f;
																					Timer projectileLeftScreenTimer = Timers.Register(duration, onComplete4, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																					_projectileLeftScreenTimer = projectileLeftScreenTimer;
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

	private void moveChuteAcross()
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0167: Expected I, but got O
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals11._003C_003E4__this = this;
		float newChutePosX = calcNewChuteXPos();
		CS_0024_003C_003E8__locals11.newChutePosX = newChutePosX;
		float2 position = ChuteSprite.position;
		object obj = position - CS_0024_003C_003E8__locals11.newChutePosX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = obj & 0;
		float dur = (float)obj2 / _chuteSpeed;
		CS_0024_003C_003E8__locals11.dur = dur;
		if (ChuteMoveTweens != null)
		{
			ChuteMoveTweens.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = renderer.height * 0.95f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"ChuteOffsetY", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		tweenConfig.duration = 100f;
		object[] array = new object[1];
		nint num2 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj3 = default(object);
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			TweenCallback onComplete = delegate
			{
				//IL_0098: Expected I, but got O
				GarbageChuteMovement garbageChuteMovement = CS_0024_003C_003E8__locals11._003C_003E4__this;
				TweenConfig tweenConfig2 = new TweenConfig();
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary2._002Ector();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value2 = default(object);
				bool flag2 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"ChuteOffsetX", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				tweenConfig2.custom = dictionary2;
				tweenConfig2.duration = CS_0024_003C_003E8__locals11.dur;
				object[] array2 = new object[1];
				if (CS_0024_003C_003E8__locals11._003C_003E4__this != null)
				{
					nint num3 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj4 = default(object);
					if (obj4 == null)
					{
						ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
						throw ex2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				tweenConfig2.ease = Ease.InOutSine;
				TweenCallback onComplete2 = CS_0024_003C_003E8__locals11._003C_003E9__1;
				if (CS_0024_003C_003E8__locals11._003C_003E9__1 == null)
				{
					onComplete2 = (CS_0024_003C_003E8__locals11._003C_003E9__1 = delegate
					{
						CS_0024_003C_003E8__locals11._003C_003E4__this.moveChuteAcross();
					});
				}
				tweenConfig2.onComplete = onComplete2;
				MultiTargetTween chuteMoveTweens2 = Tweens.Add(tweenConfig2);
				garbageChuteMovement.ChuteMoveTweens = chuteMoveTweens2;
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween chuteMoveTweens = Tweens.Add(tweenConfig);
			ChuteMoveTweens = chuteMoveTweens;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void moveChuteDown()
	{
		//IL_00d3: Expected I, but got O
		if (ChuteMoveTweens != null)
		{
			ChuteMoveTweens.Kill();
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float chuteOffsetY = renderer.height * 0.95f;
		ChuteOffsetY = chuteOffsetY;
		TweenConfig tweenConfig = new TweenConfig();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"ChuteOffsetY", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		tweenConfig.duration = 200f;
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.ease = Ease.InOutSine;
			TweenCallback onComplete = _003C_003Ec._003C_003E9__18_0;
			if (_003C_003Ec._003C_003E9__18_0 == null)
			{
				onComplete = (_003C_003Ec._003C_003E9__18_0 = delegate
				{
					//IL_0033: Expected F4, but got I4
					float? volume = default(float?);
					float rate = default(float);
					float detune = default(float);
					bool loop = default(bool);
					PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_GarbageStart, 2000f, 10, 0f, volume, rate, detune, loop, 1f);
				});
			}
			tweenConfig.onComplete = onComplete;
			MultiTargetTween chuteMoveTweens = Tweens.Add(tweenConfig);
			ChuteMoveTweens = chuteMoveTweens;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void hideChute()
	{
		//IL_00ae: Expected I, but got O
		TweenConfig tweenConfig = new TweenConfig();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary._002Ector();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"ChuteOffsetY", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		tweenConfig.duration = 100f;
		object[] array = new object[1];
		if (this != null)
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
		tweenConfig.ease = Ease.InOutSine;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite = ChuteSprite.setVisible(visible: false);
			PhaserSprite phaserSprite2 = ChuteSpriteLeft.setVisible(visible: false);
			PhaserSprite phaserSprite3 = ChuteSpriteRight.setVisible(visible: false);
			ChuteActive = false;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween chuteMoveTweens = Tweens.Add(tweenConfig);
		ChuteMoveTweens = chuteMoveTweens;
	}

	public void ManuallyHideChute()
	{
		if (ChuteActive && ChuteFollowingScreen)
		{
			if (ChuteMoveTweens != null)
			{
				ChuteMoveTweens.Kill();
			}
			if (_moveChuteTimer != null)
			{
				_moveChuteTimer.Cancel();
			}
			if (_projectileStartTimer != null)
			{
				_projectileStartTimer.Cancel();
			}
			if (_projectileEndTimer != null)
			{
				_projectileEndTimer.Cancel();
			}
			if (_projectileLeftScreenTimer != null)
			{
				_projectileLeftScreenTimer.Cancel();
			}
			hideChute();
		}
	}

	private float calcNewChuteXPos()
	{
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		GarbageChuteWeapon trueWeapon = _trueWeapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)trueWeapon)._003COwner_003Ek__BackingField;
		float maxInclusive;
		float minInclusive;
		if (!characterController._isFlipped)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			float width = renderer2.width;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj = width ^ 0;
			float width2 = renderer.width;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj2 = width2 ^ 0;
			maxInclusive = (float)obj * 0.1f;
			minInclusive = (float)obj2 * 0.4f;
		}
		else
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer3 = s_scene3._renderer;
			PhaserScene s_scene4 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer4 = s_scene4._renderer;
			maxInclusive = renderer4.width * 0.4f;
			minInclusive = renderer3.width * 0.1f;
		}
		return UnityEngine.Random.Range(minInclusive, maxInclusive);
	}

	public void Cleanup()
	{
		PhaserSprite phaserSprite = ChuteSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = ChuteSpriteLeft.setVisible(visible: false);
		PhaserSprite phaserSprite3 = ChuteSpriteRight.setVisible(visible: false);
		if (ChuteMoveTweens != null)
		{
			ChuteMoveTweens.Kill();
		}
		_trueWeapon = null;
		if (_moveChuteTimer != null)
		{
			_moveChuteTimer.Cancel();
		}
		if (_projectileStartTimer != null)
		{
			_projectileStartTimer.Cancel();
		}
		if (_projectileEndTimer != null)
		{
			_projectileEndTimer.Cancel();
		}
		if (_projectileLeftScreenTimer != null)
		{
			_projectileLeftScreenTimer.Cancel();
		}
	}

	private void _003CstartChute_003Eb__16_0()
	{
		moveChuteDown();
	}

	private void _003CstartChute_003Eb__16_1()
	{
		//IL_0049: Expected F4, but got I4
		ChuteFollowingScreen = true;
		_trueWeapon.startFiringProjectile(_chuteIndex);
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_GarbageStart, 2000f, 10, 0f, volume, rate, detune, loop, 1f);
	}

	private void _003CstartChute_003Eb__16_3()
	{
		hideChute();
	}

	private void _003ChideChute_003Eb__19_0()
	{
		PhaserSprite phaserSprite = ChuteSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = ChuteSpriteLeft.setVisible(visible: false);
		PhaserSprite phaserSprite3 = ChuteSpriteRight.setVisible(visible: false);
		ChuteActive = false;
	}
}
