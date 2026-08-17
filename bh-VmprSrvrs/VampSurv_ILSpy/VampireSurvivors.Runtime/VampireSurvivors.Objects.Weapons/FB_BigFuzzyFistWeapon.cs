using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons;

public class FB_BigFuzzyFistWeapon : Weapon
{
	private class FistState
	{
		public enum Phase
		{
			Waiting,
			FadingIn,
			PunchingDown,
			Retracting,
			FadingOut
		}

		public PhaserSprite _fist;

		public float _alpha;

		public float _punchProgress;

		public EnemyController _punchTarget;

		public Phase _phase;

		public int _punchesLeft;

		public float2 _fistOffset;

		public float2 _punchTargetPos;

		public Vector2 _fistVelocity;

		public FistState()
		{
			//IL_000f: Expected O, but got I8
			_fistOffset = (float2)3204448256L;
			_ = 1065353216;
		}
	}

	private PhaserSprite _leftFist;

	private PhaserSprite _rightFist;

	private FistState[] _fistStates;

	private int _nextFist;

	private float _rage;

	private float maxCooldownOffset = 0.3f;

	private float cooldownOffset;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0300: Expected O, but got I8
		//IL_03a1: Expected O, but got I8
		//IL_034a: Expected I, but got O
		//IL_03eb: Expected I, but got O
		//IL_05b9: Expected O, but got F4
		//IL_05c8: Expected I, but got O
		//IL_05db: Expected O, but got I4
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fd: Expected I4, but got Unknown
		//IL_060f: Expected O, but got Ref
		//IL_065b: Expected O, but got I
		//IL_06e7: Expected O, but got I
		//IL_0704: Unknown result type (might be due to invalid IL or missing references)
		//IL_0709: Expected O, but got Unknown
		//IL_08dd: Expected O, but got Ref
		//IL_09d9: Expected O, but got Ref
		//IL_0b3a->IL0a91: Incompatible stack heights: 1 vs 0
		//IL_00f1->IL0a91: Incompatible stack heights: 1 vs 0
		//IL_0120->IL0a91: Incompatible stack heights: 1 vs 0
		//IL_014a->IL0a91: Incompatible stack heights: 1 vs 0
		//IL_0186->IL0a91: Incompatible stack heights: 1 vs 0
		//IL_01d2->IL0a91: Incompatible stack heights: 1 vs 0
		//IL_01fc->IL0a91: Incompatible stack heights: 1 vs 0
		//IL_0bb4->IL0a91: Incompatible stack heights: 2 vs 0
		//IL_0272->IL0a91: Incompatible stack heights: 2 vs 0
		//IL_029c->IL0a91: Incompatible stack heights: 2 vs 0
		//IL_0320->IL0a91: Incompatible stack heights: 2 vs 0
		//IL_03c1->IL0a91: Incompatible stack heights: 2 vs 0
		//IL_036d->IL036d: Incompatible stack heights: 3 vs 2
		//IL_043c->IL0a91: Incompatible stack heights: 2 vs 0
		//IL_040e->IL040e: Incompatible stack heights: 3 vs 2
		//IL_0493->IL0a91: Incompatible stack heights: 3 vs 0
		//IL_0bdd->IL0a91: Incompatible stack heights: 3 vs 0
		//IL_04fe->IL0a91: Incompatible stack heights: 4 vs 0
		//IL_053b->IL0a91: Incompatible stack heights: 4 vs 0
		//IL_0592->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_068e->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_074a->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_076c->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_07c1->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_07e3->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_082e->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_0861->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_088d->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_08cb->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_08f7->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_092a->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_095d->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_0989->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_09c7->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_09f3->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_0a3a->IL0a91: Incompatible stack heights: 5 vs 0
		//IL_0a7c->IL0a91: Incompatible stack heights: 5 vs 0
		base.InitWeapon(characterController, weaponType);
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "Big Fuzzy Fist-Fist-F1", "firstBlood");
			if ((object)phaserSprite != null)
			{
				Transform transform = phaserSprite.transform;
				if ((object)transform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v29 (UnityEngine.Transform)+10]");
					bool flag = (nint)0 == 0;
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v999 @ rcx_v27 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v29 (UnityEngine.Transform)+10]");
					Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
					PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite phaserSprite3 = phaserSprite2.setVisible(visible: false);
						if ((object)phaserSprite3 != null)
						{
							PhaserSprite phaserSprite4 = phaserSprite3.setFlipX(flipX: true);
							if ((object)phaserSprite4 != null)
							{
								GameObject gameObject2 = phaserSprite4.gameObject;
								if ((object)gameObject2 != null)
								{
									((UnityEngine.Object)gameObject2).SetName("LeftFist");
									_leftFist = phaserSprite4;
									if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
									{
										float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
										GameObject gameObject3 = base.gameObject;
										PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "Big Fuzzy Fist-Fist-F1", "firstBlood");
										if ((object)phaserSprite5 != null)
										{
											Transform transform2 = phaserSprite5.transform;
											if ((object)transform2 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rax_v46 (UnityEngine.Transform)+10]");
												bool flag2 = (nint)0 == 0;
												nint num2 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1444 @ rcx_v43 (Il2CppMethodInfo)+38]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rax_v46 (UnityEngine.Transform)+10]");
												Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
												PhaserSprite phaserSprite6 = phaserSprite5.setAlpha(0f);
												if ((object)phaserSprite6 != null)
												{
													PhaserSprite phaserSprite7 = phaserSprite6.setVisible(visible: false);
													if ((object)phaserSprite7 != null)
													{
														GameObject gameObject4 = phaserSprite7.gameObject;
														if ((object)gameObject4 != null)
														{
															((UnityEngine.Object)gameObject4).SetName("RightFist");
															_rightFist = phaserSprite7;
															FistState[] fistStates = new FistState[2];
															_fistStates = fistStates;
															FistState[] fistStates2 = _fistStates;
															FistState fistState = new FistState
															{
																_fistOffset = (float2)3204448256L
															};
															_ = 1065353216;
															if (_fistStates != null)
															{
																if (fistState != null)
																{
																	nint num3 = (nint)fistStates2;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																	object obj = default(object);
																	bool flag3 = obj == null;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																FistState[] fistStates3 = _fistStates;
																FistState fistState2 = new FistState
																{
																	_fistOffset = (float2)3204448256L
																};
																_ = 1065353216;
																if (_fistStates != null)
																{
																	if (fistState2 != null)
																	{
																		nint num4 = (nint)fistStates3;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																		object obj2 = default(object);
																		bool flag4 = obj2 == null;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	FistState[] fistStates4 = _fistStates;
																	if (_fistStates != null)
																	{
																		bool flag5 = fistStates4.Length <= 0;
																		FistState fistState3 = fistStates4[0];
																		if (fistStates4[0] != null)
																		{
																			fistState3._fist = _leftFist;
																			FistState[] fistStates5 = _fistStates;
																			if (_fistStates != null)
																			{
																				bool flag6 = fistStates5.Length <= 1;
																				FistState fistState4 = fistStates5[1];
																				if (fistStates5[1] != null)
																				{
																					fistState4._fist = _rightFist;
																					FistState[] fistStates6 = _fistStates;
																					if (_fistStates != null)
																					{
																						bool flag7 = fistStates6.Length <= 1;
																						FistState fistState5 = fistStates6[1];
																						if (fistStates6[1] != null)
																						{
																							float num5 = (float)fistState5._fistOffset * -1f;
																							fistState5._fistOffset = (float2)num5;
																							List<Sprite> list = null;
																							nint num6 = unchecked((nint)null);
																							object obj3 = 0;
																							float num7 = default(float);
																							bool shouldLoop = default(bool);
																							bool startRandomFrame = default(bool);
																							Action onComplete = default(Action);
																							bool autoSetAnimation = default(bool);
																							while (true)
																							{
																								int value = obj3 + 1;
																								string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&num7), CultureInfo.invariant_culture_info);
																								string spriteName = "Big Fuzzy Fist-Fist-F" + text;
																								Sprite sprite = SpriteManager.GetSprite(spriteName, "firstBlood", ignoreExtension: false);
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1799 @ rax_v72 (System.Collections.Generic.List`1<UnityEngine.Sprite>)+10]");
																								object obj4 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1799 @ rax_v72 (System.Collections.Generic.List`1<UnityEngine.Sprite>)+1C]");
																								_ = (nint)0 + (nint)1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1799 @ rax_v72 (System.Collections.Generic.List`1<UnityEngine.Sprite>)+10]");
																								if ((nint)0 == 0)
																								{
																									break;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1799 @ rax_v72 (System.Collections.Generic.List`1<UnityEngine.Sprite>)+18]");
																								nint num8 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ r9_v15+18]");
																								if (num8 >= 0)
																								{
																									((List<object>)(object)list).AddWithResize((object)sprite);
																								}
																								else
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1799 @ rax_v72 (System.Collections.Generic.List`1<UnityEngine.Sprite>)+18]");
																									object obj5 = (nint)0 + (nint)1;
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																								}
																								obj3++;
																								if ((nint)obj3 < 4)
																								{
																									continue;
																								}
																								PhaserSprite leftFist = _leftFist;
																								if ((object)_leftFist == null || (object)leftFist._spriteAnimation == null)
																								{
																									break;
																								}
																								leftFist._spriteAnimation.AddAnimation("idle", list, 8, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
																								PhaserSprite rightFist = _rightFist;
																								if ((object)_rightFist == null || (object)rightFist._spriteAnimation == null)
																								{
																									break;
																								}
																								rightFist._spriteAnimation.AddAnimation("idle", list, 8, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
																								if ((object)_leftFist == null)
																								{
																									break;
																								}
																								PhaserSprite phaserSprite8 = _leftFist.setDepth(1000);
																								if ((object)_leftFist == null)
																								{
																									break;
																								}
																								Transform transform3 = _leftFist.transform;
																								if ((object)transform3 == null)
																								{
																									break;
																								}
																								Vector3 localEulerAngles = transform3.localEulerAngles;
																								Transform transform4 = _leftFist.transform;
																								if ((object)transform4 == null)
																								{
																									break;
																								}
																								transform4.localEulerAngles = (Vector3)(&num7);
																								if ((object)_leftFist == null)
																								{
																									break;
																								}
																								PhaserSprite phaserSprite9 = _leftFist.setFlipX(flipX: true);
																								if ((object)_rightFist == null)
																								{
																									break;
																								}
																								PhaserSprite phaserSprite10 = _rightFist.setDepth(1000);
																								if ((object)_rightFist == null)
																								{
																									break;
																								}
																								Transform transform5 = _rightFist.transform;
																								if ((object)transform5 == null)
																								{
																									break;
																								}
																								Vector3 localEulerAngles2 = transform5.localEulerAngles;
																								Transform transform6 = _rightFist.transform;
																								if ((object)transform6 == null)
																								{
																									break;
																								}
																								transform6.localEulerAngles = (Vector3)(&num7);
																								if ((object)_rightFist == null)
																								{
																									break;
																								}
																								PhaserSprite phaserSprite11 = _rightFist.setFlipX(flipX: false);
																								Action<GameplaySignals.CharacterReceivedDamageSignal> action = null;
																								((FB_BigFuzzyFistWeapon)(object)action).RetaliateOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
																								if (_signalBus == null)
																								{
																									break;
																								}
																								((FB_BigFuzzyFistWeapon)(object)_signalBus).RetaliateOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)action);
																								Action<GameplaySignals.CharacterLostShieldSignal> action2 = null;
																								((FB_BigFuzzyFistWeapon)(object)action2).RetaliateOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)this);
																								if (_signalBus == null)
																								{
																									break;
																								}
																								((FB_BigFuzzyFistWeapon)(object)_signalBus).RetaliateOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)action2);
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

	public override void Cleanup()
	{
		GameObject obj = _leftFist.gameObject;
		UnityEngine.Object.Destroy(obj, 0f);
		GameObject obj2 = _rightFist.gameObject;
		UnityEngine.Object.Destroy(obj2, 0f);
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterReceivedDamageSignal> action = null;
			((FB_BigFuzzyFistWeapon)(object)action).RetaliateOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
			((FB_BigFuzzyFistWeapon)(object)_signalBus).RetaliateOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)action);
		}
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterLostShieldSignal> action2 = null;
			((FB_BigFuzzyFistWeapon)(object)action2).RetaliateOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)this);
			((FB_BigFuzzyFistWeapon)(object)_signalBus).RetaliateOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)action2);
		}
		base.Cleanup();
	}

	private void RetaliateOnPlayerDamage(GameplaySignals.CharacterReceivedDamageSignal signal)
	{
		//IL_0104: Expected O, but got I4
		//IL_011e: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		bool flag2 = (object)signal == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				if ((object)signal != null)
				{
					object obj3 = (object)signal - (object)((Equipment)this)._003COwner_003Ek__BackingField;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [signal @ rdx (VampireSurvivors.Signals.GameplaySignals+CharacterReceivedDamageSignal)+10]");
				flag4 = (nint)0 == 0;
			}
			if (!flag4)
			{
				return;
			}
		}
		_rage = 1f;
		base.Fire();
	}

	private void RetaliateOnPlayerShield(GameplaySignals.CharacterLostShieldSignal signal)
	{
		//IL_011d: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController character = signal.Character;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		bool flag2 = (object)signal.Character == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				if ((object)signal.Character != null)
				{
					object obj3 = (object)signal.Character - (object)((Equipment)this)._003COwner_003Ek__BackingField;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)character).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		_rage = 1f;
		base.Fire();
	}

	private void Retaliate()
	{
		_rage = 1f;
		base.Fire();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		//IL_01f7: Invalid comparison between O and F4
		//IL_00c1: Expected O, but got I4
		//IL_00e3: Invalid comparison between F4 and I4
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_01aa: Invalid comparison between F4 and O
		FistState[] fistStates = _fistStates;
		int nextFist = _nextFist;
		FistState fistState = fistStates[nextFist];
		int punchesLeft = fistState._punchesLeft + 1;
		fistState._punchesLeft = punchesLeft;
		int nextFist2 = 1 - _nextFist;
		_nextFist = nextFist2;
		float num = base.PAmount();
		float num2 = default(float);
		if (num2 > 1f)
		{
			float num3 = base.PAmount();
			if (num2 > 1f)
			{
				object obj = 1;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					num2 = (float)obj * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					if (!(num2 > 0f))
					{
						DoNextPunch();
					}
					else
					{
						Action onComplete = delegate
						{
							//IL_00bc: Expected O, but got I4
							GameObject gameObject = base.gameObject;
							bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj3 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj3 != null)
							{
								FistState[] fistStates2 = _fistStates;
								int nextFist3 = _nextFist;
								FistState fistState2 = fistStates2[nextFist3];
								int punchesLeft2 = fistState2._punchesLeft + 1;
								fistState2._punchesLeft = punchesLeft2;
								int nextFist4 = 1 - _nextFist;
								_nextFist = nextFist4;
							}
						};
						float num4 = (float)obj * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
						num2 = num4 * 0.001f;
						Timer lastShotTimer = Timers.Register(num2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
					}
					obj++;
					float num5 = base.PAmount();
				}
				while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj));
			}
		}
		float num6 = PInterval();
		float num7 = _lastFiringInterval - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = num7 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num8 = PInterval();
			_lastFiringInterval = num2;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public override void InternalUpdate()
	{
		//IL_007e: Invalid comparison between I4 and F4
		base.InternalUpdate();
		FistState[] fistStates = _fistStates;
		UpdateFist(fistStates[0]);
		FistState[] fistStates2 = _fistStates;
		UpdateFist(fistStates2[1]);
		float deltaTime = PauseSystem.DeltaTime;
		if (0f > (_rage -= deltaTime))
		{
			_rage = 0f;
		}
	}

	private unsafe void UpdateFist(FistState fist)
	{
		//IL_0479: Expected I, but got O
		//IL_009e: Expected O, but got I4
		//IL_04ce: Expected O, but got I
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_06b6: Expected O, but got F4
		//IL_06bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c4: Expected Ref, but got Unknown
		//IL_04ea: Expected I, but got O
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_0220: Invalid comparison between I4 and F4
		//IL_044e: Expected I, but got O
		//IL_0264: Expected O, but got I4
		//IL_059d: Expected I4, but got O
		//IL_05a6: Expected O, but got I4
		//IL_05ab: Expected I, but got O
		//IL_0146: Invalid comparison between I4 and F4
		//IL_027b: Expected O, but got I4
		//IL_035f: Expected I, but got O
		float deltaTime = PauseSystem.DeltaTime;
		bool flag = fist._punchesLeft <= 1;
		float num = deltaTime;
		if (!flag)
		{
			if (0 <= fist._punchesLeft)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			}
			num = deltaTime * (float)fist._punchesLeft;
		}
		bool flag2 = fist._phase == FistState.Phase.Waiting;
		FistState fistState3 = default(FistState);
		nint num5;
		if (!flag2)
		{
			object obj = fist._phase - 1;
			if (flag2)
			{
				EnemyController punchTarget = fist._punchTarget;
				if ((object)fist._punchTarget != null && ((UnityEngine.Object)punchTarget).m_CachedPtr != (IntPtr)0)
				{
					ArcadeSprite punchTarget2 = fist._punchTarget;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rax_v27 (ArcadeSprite)+260]");
					if ((nint)0 == 0)
					{
						float2 position = punchTarget2.position;
						fist._punchTargetPos = position;
					}
				}
				float num2 = num * 5f;
				bool flag3 = !((fist._alpha = num2 + fist._alpha) > 1f);
				FistState fistState = fist;
				if (!flag3)
				{
					fist._alpha = 1f;
					fist._phase = FistState.Phase.PunchingDown;
					fistState = fist;
				}
				goto IL_042e;
			}
			object obj2 = obj - 1;
			if (!flag2)
			{
				object obj3 = obj2 - 1;
				if (!flag2)
				{
					bool flag4 = (nint)obj3 != 1;
					FistState fistState = fist;
					if (!flag4)
					{
						float num3 = num * 5f;
						if (!(0f > (fist._alpha -= num3)))
						{
							bool flag5 = SwitchToNewFistTarget(fist);
							bool flag6 = !flag5;
							fistState = fist;
							if (!flag6)
							{
								fist._phase = FistState.Phase.FadingIn;
								fistState = fist;
							}
						}
						else
						{
							fist._alpha = 0f;
							fist._phase = FistState.Phase.Waiting;
							PhaserSprite phaserSprite = fist._fist.setVisible(visible: false);
							fistState = null;
						}
						goto IL_042e;
					}
				}
				else
				{
					float num4 = num * 2.5f;
					bool flag7 = !(0f > (fist._punchProgress -= num4));
					FistState fistState = fist;
					if (!flag7)
					{
						fist._punchProgress = 0f;
						bool flag8 = SwitchToNewFistTarget(fist);
						FistState fistState2 = (FistState)2;
						if (!flag8)
						{
							fistState2 = (FistState)4;
						}
						fist._phase = (FistState.Phase)fistState2;
						fistState = (FistState)4;
						num5 = unchecked((nint)null);
					}
				}
			}
			else
			{
				EnemyController punchTarget3 = fist._punchTarget;
				if ((object)fist._punchTarget != null && ((UnityEngine.Object)punchTarget3).m_CachedPtr != (IntPtr)0)
				{
					ArcadeSprite punchTarget4 = fist._punchTarget;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rax_v42 (ArcadeSprite)+260]");
					if ((nint)0 == 0)
					{
						float2 position2 = punchTarget4.position;
						fist._punchTargetPos = position2;
					}
				}
				float num6 = num * 2.5f;
				bool flag9 = (fist._punchProgress = num6 + fist._punchProgress) < 1f;
				FistState fistState = fist;
				if (!flag9)
				{
					fist._punchProgress = 1f;
					fist._phase = FistState.Phase.Retracting;
					Projectile projectile = base.FireOneProjectile((Vector2)fistState3, 0);
					fistState = fistState3;
					num5 = unchecked((nint)null);
				}
			}
		}
		else
		{
			bool flag10 = SwitchToNewFistTarget(fist);
			bool flag11 = !flag10;
			FistState fistState = fist;
			num5 = unchecked((nint)null);
			if (!flag11)
			{
				fist._phase = FistState.Phase.FadingIn;
				PhaserSprite phaserSprite2 = fist._fist.setVisible(visible: true);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [fist @ rdx (VampireSurvivors.Objects.Weapons.FB_BigFuzzyFistWeapon+FistState)+3C]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [fist @ rdx (VampireSurvivors.Objects.Weapons.FB_BigFuzzyFistWeapon+FistState)+34]");
				object obj4 = num7 + 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				fistState = fistState3;
				num5 = unchecked((nint)null);
			}
		}
		goto IL_04ef;
		IL_042e:
		PhaserSprite phaserSprite3 = fist._fist.setAlpha(fist._alpha);
		num5 = unchecked((nint)null);
		goto IL_04ef;
		IL_04ef:
		float num8 = DOVirtual.EasedValue(0f, 1f, fist._punchProgress, Ease.InBack);
		float2 position3 = fist._fist.position;
		float num9 = 1f - fist._punchProgress;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
		float smoothTime = num9 * 0.5f;
		object obj5 = Time.deltaTime;
		float maxSpeed = default(float);
		float deltaTime2 = default(float);
		Vector2 vector = Vector2.SmoothDamp((Vector2)fistState3, (Vector2)fistState3, ref *(Vector2*)(fist + 64), smoothTime, maxSpeed, deltaTime2);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
	}

	private bool SwitchToNewFistTarget(FistState fist)
	{
		//IL_010d: Expected I4, but got O
		FistState fistState = default(FistState);
		if (fistState != null)
		{
			if (fistState._punchesLeft > 0)
			{
				EnemyController nextTarget = GetNextTarget(fistState);
				fistState._punchTarget = nextTarget;
				int punchesLeft = fistState._punchesLeft - 1;
				fistState._punchesLeft = punchesLeft;
				EnemyController punchTarget = fistState._punchTarget;
				if ((object)fistState._punchTarget != null && ((UnityEngine.Object)punchTarget).m_CachedPtr != (IntPtr)0)
				{
					if ((object)fistState._punchTarget != null)
					{
						float2 position = fistState._punchTarget.position;
						fistState._punchTargetPos = position;
						return true;
					}
					goto IL_00ff;
				}
			}
			return false;
		}
		goto IL_00ff;
		IL_00ff:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void DoNextPunch(float speedMultiplier = 1f)
	{
		FistState[] fistStates = _fistStates;
		int nextFist = _nextFist;
		FistState fistState = fistStates[nextFist];
		int punchesLeft = fistState._punchesLeft + 1;
		fistState._punchesLeft = punchesLeft;
		int nextFist2 = 1 - _nextFist;
		_nextFist = nextFist2;
	}

	private EnemyController GetNextTarget(FistState fist)
	{
		//IL_02c3: Invalid comparison between I4 and F4
		//IL_0047: Expected F4, but got I4
		//IL_00ab: Expected F4, but got I4
		//IL_00f1: Invalid comparison between I4 and F4
		//IL_0105: Expected F4, but got I4
		//IL_010e: Expected F4, but got I4
		//IL_012a: Expected F4, but got I4
		//IL_0133: Expected F4, but got I4
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected O, but got Unknown
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.MaxHp();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873DF38Ch\"");
		object obj = default(object);
		float num2;
		if (obj == null)
		{
			num2 = 0f;
		}
		else
		{
			float num3 = ((Equipment)this)._003COwner_003Ek__BackingField.MaxHp();
			num2 = characterController._currentHp / (float)obj;
		}
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		GameManager core = GM.Core;
		float num4 = num2 * -0.14999998f;
		float excludedBorderPercentage = num4 + 0.45f;
		List<EnemyController> allEnemiesInScreenBounds = core._stage.GetAllEnemiesInScreenBounds(excludedBorderPercentage);
		bool flag = 0f < _rage;
		EnemyController enemyController = null;
		float num5 = 0f;
		float num6 = 0f;
		if (!flag)
		{
			enemyController = null;
			num5 = 0f;
			num6 = 0f;
			EnemyController enemyController2 = null;
			EnemyController enemyController3 = null;
			EnemyController result = default(EnemyController);
			while ((nint)enemyController2 < allEnemiesInScreenBounds._size)
			{
				if ((nint)enemyController3 < allEnemiesInScreenBounds._size)
				{
					EnemyController[] items = allEnemiesInScreenBounds._items;
					EnemyController enemyController4 = items[(object)enemyController3];
					if (!(enemyController4._maxHp > num6))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873DF488h\"");
						if (enemyController4._maxHp == num6)
						{
							enemyController3 = (EnemyController)(enemyController3 + 1);
							num5 = num6;
							enemyController2 = enemyController3;
							continue;
						}
					}
					else
					{
						enemyController = enemyController4;
						num6 = enemyController4._maxHp;
					}
					enemyController3 = (EnemyController)(enemyController3 + 1);
					enemyController2 = enemyController3;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
		}
		if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873DF544h\"");
			if (num5 != num6)
			{
				goto IL_0350;
			}
		}
		float2 targetSearchCenter = GetTargetSearchCenter(fist);
		EnemyController enemyController5 = ClosestEnemyInSet(allEnemiesInScreenBounds, targetSearchCenter);
		enemyController = enemyController5;
		goto IL_0350;
		IL_0350:
		return enemyController;
	}

	private float2 GetTargetSearchCenter(FistState fist)
	{
		//IL_002e: Invalid comparison between F4 and I4
		//IL_00bc: Expected O, but got I4
		//IL_00c5: Expected F4, but got I4
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		if (!(_rage > 0f))
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			float num = (float)characterController._currentDirection * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v9 (VampireSurvivors.Objects.Characters.CharacterController)+174]");
			float num2 = 0f * 0.5f;
			float num3 = (float)position + num;
			object obj = default(object);
			float num4 = (float)obj + num2;
			FistState fistState = fist;
			object obj2 = 0;
			float num5 = 0f;
			float2 result = default(float2);
			while (true)
			{
				FistState[] fistStates = _fistStates;
				if ((nint)obj2 >= fistStates.Length)
				{
					break;
				}
				if (fistStates[obj2] != fist)
				{
					fistState = fistStates[obj2];
					if (fistState._phase != FistState.Phase.Waiting)
					{
						FistState fistState2 = fistStates[obj2];
						float normalizedHp = ((Equipment)this)._003COwner_003Ek__BackingField.NormalizedHp;
						float num6 = (float)fistState2._punchTargetPos - num3;
						num5 = normalizedHp * 0.25f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v7 (VampireSurvivors.Objects.Weapons.FB_BigFuzzyFistWeapon+FistState)+3C]");
						float num7 = 0f - num4;
						float num8 = num6 * num5;
						float num9 = num7 * num5;
						float num10 = num8 + num3;
						float num11 = num9 + num4;
						fistState = null;
					}
				}
				obj2++;
				if ((nint)obj2 >= 2)
				{
					return result;
				}
			}
			return (float2)new IndexOutOfRangeException();
		}
		return ((Equipment)this)._003COwner_003Ek__BackingField.position;
	}

	private EnemyController ClosestEnemyInSet(List<EnemyController> set, float2 queryPos)
	{
		float num = 3.4028235E+38f;
		EnemyController result = null;
		List<EnemyController>.Enumerator enumerator = default(List<EnemyController>.Enumerator);
		while (enumerator.MoveNext())
		{
			EnemyController enemyController = null;
		}
		return result;
	}

	protected override void OnUpdate()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.MaxHp();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		object obj = default(object);
		float num2 = 1f / (float)obj;
		float num3 = num2 * characterController._currentHp;
		float num4 = 1f - num3;
		float num5 = num4 * maxCooldownOffset;
		cooldownOffset = num5;
	}

	public override float PInterval()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
		{
			goto IL_0197;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num3 = default(float);
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			if (characterController2._sineCooldown == null)
			{
				goto IL_0197;
			}
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float num = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldown();
				VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && characterController3._sineCooldown != null)
				{
					float value = characterController3._sineCooldown.Value;
					float num2 = num3 + characterController2._003CSilentCooldown_003Ek__BackingField;
					float num4 = num2 - cooldownOffset;
					num3 = value * num4;
					bool flag = !(0.1f < num3);
					float num5 = 0.1f;
					if (!flag)
					{
						num5 = num3;
					}
					WeaponData currentWeaponData = _currentWeaponData;
					if (_currentWeaponData != null)
					{
						return num5 * currentWeaponData._003Cinterval_003Ek__BackingField;
					}
				}
			}
		}
		goto IL_0253;
		IL_0253:
		throw new NullReferenceException();
		IL_0197:
		VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num6 = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldown();
			WeaponData currentWeaponData2 = _currentWeaponData;
			if (_currentWeaponData != null)
			{
				float num7 = num3 + characterController4._003CSilentCooldown_003Ek__BackingField;
				float num8 = num7 - cooldownOffset;
				bool flag2 = !(0.1f < num8);
				float num9 = 0.1f;
				if (!flag2)
				{
					num9 = num8;
				}
				return num9 * currentWeaponData2._003Cinterval_003Ek__BackingField;
			}
		}
		goto IL_0253;
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		if (!visible)
		{
			PhaserSprite phaserSprite = _leftFist.setVisible(visible: false);
			FistState[] fistStates = _fistStates;
			FistState fistState = fistStates[0];
			fistState._phase = FistState.Phase.Waiting;
			FistState[] fistStates2 = _fistStates;
			FistState fistState2 = fistStates2[0];
			fistState2._punchesLeft = 0;
			FistState[] fistStates3 = _fistStates;
			FistState fistState3 = fistStates3[0];
			fistState3._punchProgress = 0f;
			PhaserSprite phaserSprite2 = _rightFist.setVisible(visible: false);
			FistState[] fistStates4 = _fistStates;
			FistState fistState4 = fistStates4[1];
			fistState4._phase = FistState.Phase.Waiting;
			FistState[] fistStates5 = _fistStates;
			FistState fistState5 = fistStates5[1];
			fistState5._punchesLeft = 0;
			FistState[] fistStates6 = _fistStates;
			FistState fistState6 = fistStates6[1];
			fistState6._punchProgress = 0f;
		}
	}

	private void _003CFire_003Eb__13_0()
	{
		//IL_00bc: Expected O, but got I4
		GameObject gameObject = base.gameObject;
		bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
		object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
		if (obj != null)
		{
			FistState[] fistStates = _fistStates;
			int nextFist = _nextFist;
			FistState fistState = fistStates[nextFist];
			int punchesLeft = fistState._punchesLeft + 1;
			fistState._punchesLeft = punchesLeft;
			int nextFist2 = 1 - _nextFist;
			_nextFist = nextFist2;
		}
	}
}
