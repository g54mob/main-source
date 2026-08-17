using System;
using System.Collections.Generic;
using System.Linq;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.Speedup;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Objects.Stages;

public class Background2 : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<SuperObject, bool> _003C_003E9__25_0;

		public static Func<SuperObject, bool> _003C_003E9__25_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe bool _003CCreate_003Eb__25_0(SuperObject o)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3A41]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)o != null)
			{
				string tiledName = o.m_TiledName;
				if (o.m_TiledName != null)
				{
					object obj = "Piano";
					if ((object)o.m_TiledName != "Piano")
					{
						if ("Piano" != null)
						{
							int stringLength = tiledName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("Piano" + 20);
								ulong length = (ulong)(tiledName._stringLength + tiledName._stringLength);
								return System.SpanHelpers.SequenceEqual(ref *(byte*)(o.m_TiledName + 20), ref second, length);
							}
						}
						return false;
					}
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal unsafe bool _003CCreate_003Eb__25_1(SuperObject o)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3A42]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)o != null)
			{
				string tiledName = o.m_TiledName;
				if (o.m_TiledName != null)
				{
					object obj = "Coffin";
					if ((object)o.m_TiledName != "Coffin")
					{
						if ("Coffin" != null)
						{
							int stringLength = tiledName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("Coffin" + 20);
								ulong length = (ulong)(tiledName._stringLength + tiledName._stringLength);
								return System.SpanHelpers.SequenceEqual(ref *(byte*)(o.m_TiledName + 20), ref second, length);
							}
						}
						return false;
					}
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public string texture;

		internal void _003CCustomPreload_003Eb__0(Action cb)
		{
			//IL_0029: Expected I4, but got O
			_003C_003Ec__DisplayClass30_1 obj = new _003C_003Ec__DisplayClass30_1();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass30_1)(object)action)._003CCustomPreload_003Eb__1((byte)(int)obj != 0);
			GameManager core = GM.Core;
			string customCacheGroup = default(string);
			CharacterLoader.LoadCharacterTextureAsync(texture, CharacterType.AVATAR, action, core._dataManager, customCacheGroup);
		}
	}

	private sealed class _003C_003Ec__DisplayClass30_1
	{
		public Action cb;

		internal void _003CCustomPreload_003Eb__1(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private bool _triggerCheck;

	private bool _hasSpawnedTrickster;

	private bool _hasDefeatedTrickster;

	private bool _saveDmg;

	private bool _canInteractWithPiano;

	private BgmType? _saveBgm;

	private BgmModType? _saveBgmMod;

	private EnemyTrickster _enemyTrickster;

	private Timer _pianoInteractionTimer;

	private Timer _undeadsTimer;

	private int _undeadsTimerLoopCount;

	private PhaserSprite _sDarkness;

	private PhaserSprite _sDarknessExtraA;

	private PhaserSprite _sDarknessExtraB;

	private SuperObject _piano;

	private SuperObject _coffin;

	private Vector2 _pianoPos;

	private Vector2 _coffinPos;

	private float _pianoOffset = 11f;

	private float _displayHeight;

	private float _displayWidth;

	private bool _pianoDone;

	private PickupCoffinEmpty _rightCoffin;

	private readonly bool _quickDebug;

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (!_triggerCheck || !GM.Core.IsStageHost)
		{
			return;
		}
		float2 position = default(float2);
		bool includeFollowers = default(bool);
		VampireSurvivors.Objects.Characters.CharacterController closestPlayer = GM.Core.GetClosestPlayer(position, PlayerInclusionMode.OnlyAlive, 3.4028235E+38f, includeFollowers);
		if ((object)closestPlayer == null || ((UnityEngine.Object)closestPlayer).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		object obj = default(object);
		if (!_hasSpawnedTrickster)
		{
			float num = (float)_pianoPos * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background2)+E4]");
			float num2 = 0f * 100f;
			float2 position2 = closestPlayer.position;
			float num3 = (float)obj * 100f;
			float num4 = (float)position2 * 100f;
			float num5 = num2 - num3;
			float num6 = num - num4;
			float num7 = num5 * num5;
			float num8 = num6 * num6;
			float num9 = num8 + num7;
			bool flag = !(60000f > num9);
			float2 float5 = position2;
			if (!flag)
			{
				_hasSpawnedTrickster = true;
				RevealTrickster();
				float5 = position2;
			}
		}
		if (!_hasDefeatedTrickster || _pianoDone)
		{
			return;
		}
		float num10 = (float)_pianoPos * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background2)+E4]");
		float num11 = 0f * 100f;
		float2 position3 = closestPlayer.position;
		float num12 = (float)position3 * 100f;
		float num13 = (float)obj * 100f;
		float num14 = num10 - num12;
		float num15 = num11 - num13;
		float num16 = num14 * num14;
		float num17 = num15 * num15;
		float num18 = num16 + num17;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
		object message = default(object);
		Debug.Log(message);
		if (300f > num18 && _canInteractWithPiano)
		{
			_canInteractWithPiano = false;
			SpeedupManager instance = SpeedupManager.Instance;
			instance.SetSpeedupBlocked(isBlocked: true);
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				GM.Core.QueueEnterPianoScene(closestPlayer);
				return;
			}
			OnlineStageManager instance2 = OnlineStageManager._instance;
			Action<long, CoherenceSync> action = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA56D0");
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F6D7F0");
		}
	}

	public unsafe override void Create()
	{
		//IL_074c: Expected O, but got I
		//IL_055e: Expected O, but got I4
		//IL_055e: Expected O, but got I
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_056c: Expected O, but got Unknown
		//IL_0888: Expected O, but got I
		//IL_065a: Expected O, but got I4
		//IL_065a: Expected O, but got I
		//IL_0663: Unknown result type (might be due to invalid IL or missing references)
		//IL_0668: Expected O, but got Unknown
		//IL_08d7: Expected O, but got I
		//IL_097c: Expected O, but got F4
		//IL_0a0b: Expected O, but got F4
		//IL_09a0->IL06f2: Incompatible stack heights: 1 vs 0
		//IL_06e3->IL06f2: Incompatible stack heights: 1 vs 0
		//IL_0a10->IL0771: Incompatible stack heights: 2 vs 0
		base.Create();
		_pianoDone = false;
		_triggerCheck = false;
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				_saveDmg = config._003CDamageNumbersEnabled_003Ek__BackingField;
				if (_quickDebug)
				{
					goto IL_02ab;
				}
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null && core2._playerOptions != null)
				{
					PlayerOptionsData config2 = core2._playerOptions.Config;
					if (config2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v157 (VampireSurvivors.Data.PlayerOptionsData)+188]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v157 (VampireSurvivors.Data.PlayerOptionsData)+188]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v123+18]");
							if ((nint)0 == 0)
							{
								return;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							object obj2 = default(object);
							if ((nint)obj2 == -1)
							{
								return;
							}
							GameManager core3 = GM.Core;
							if ((object)GM.Core != null && core3._playerOptions != null)
							{
								PlayerOptionsData config3 = core3._playerOptions.Config;
								if (config3 != null && config3._003CUnlockedWeapons_003Ek__BackingField != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
									object obj3 = default(object);
									if (obj3 == null)
									{
										return;
									}
									GameManager core4 = GM.Core;
									if ((object)GM.Core != null && core4._playerOptions != null)
									{
										PlayerOptionsData config4 = core4._playerOptions.Config;
										if (config4 != null)
										{
											if (config4._003CSelectedInverse_003Ek__BackingField)
											{
												goto IL_02ab;
											}
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
		goto IL_06f2;
		IL_02ab:
		GameManager core5 = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core5._stage;
			if ((object)core5._stage != null)
			{
				TilingTileset tilingTileset = stage._tilingTileset;
				if ((object)stage._tilingTileset != null)
				{
					Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__25_0;
					if (_003C_003Ec._003C_003E9__25_0 == null)
					{
						predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__25_0 = delegate(SuperObject o)
						{
							//IL_0144: Expected I4, but got O
							//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
							//IL_00e6: Expected Ref, but got Unknown
							//IL_00fd: Expected I8, but got I4
							//IL_010b: Unknown result type (might be due to invalid IL or missing references)
							//IL_0110: Expected Ref, but got Unknown
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3A41]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if ((object)o != null)
							{
								string tiledName = o.m_TiledName;
								if (o.m_TiledName != null)
								{
									object obj12 = "Piano";
									if ((object)o.m_TiledName != "Piano")
									{
										if ("Piano" != null)
										{
											int stringLength = tiledName._stringLength;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
											if ((nint)stringLength == 0)
											{
												ref byte second = ref *(byte*)("Piano" + 20);
												ulong length = (ulong)(tiledName._stringLength + tiledName._stringLength);
												return System.SpanHelpers.SequenceEqual(ref *(byte*)(o.m_TiledName + 20), ref second, length);
											}
										}
										return false;
									}
									return true;
								}
							}
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						});
					}
					object obj4 = Enumerable.FirstOrDefault(tilingTileset.SavedScripts, predicate);
					if (obj4 == null)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ rax_v26 (System.Object)+10]");
					if ((nint)0 == 0)
					{
						return;
					}
					GameManager core6 = GM.Core;
					if ((object)GM.Core != null)
					{
						Stage stage2 = core6._stage;
						if ((object)core6._stage != null)
						{
							TilingTileset tilingTileset2 = stage2._tilingTileset;
							if ((object)stage2._tilingTileset != null)
							{
								Func<object, bool> predicate2 = (Func<object, bool>)_003C_003Ec._003C_003E9__25_1;
								if (_003C_003Ec._003C_003E9__25_1 == null)
								{
									predicate2 = (Func<object, bool>)(_003C_003Ec._003C_003E9__25_1 = delegate(SuperObject o)
									{
										//IL_0144: Expected I4, but got O
										//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
										//IL_00e6: Expected Ref, but got Unknown
										//IL_00fd: Expected I8, but got I4
										//IL_010b: Unknown result type (might be due to invalid IL or missing references)
										//IL_0110: Expected Ref, but got Unknown
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3A42]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
										if ((object)o != null)
										{
											string tiledName = o.m_TiledName;
											if (o.m_TiledName != null)
											{
												object obj12 = "Coffin";
												if ((object)o.m_TiledName != "Coffin")
												{
													if ("Coffin" != null)
													{
														int stringLength = tiledName._stringLength;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
														if ((nint)stringLength == 0)
														{
															ref byte second = ref *(byte*)("Coffin" + 20);
															ulong length = (ulong)(tiledName._stringLength + tiledName._stringLength);
															return System.SpanHelpers.SequenceEqual(ref *(byte*)(o.m_TiledName + 20), ref second, length);
														}
													}
													return false;
												}
												return true;
											}
										}
										NullReferenceException ex = new NullReferenceException();
										return (byte)(int)ex != 0;
									});
								}
								object obj5 = Enumerable.FirstOrDefault(tilingTileset2.SavedScripts, predicate2);
								if (obj5 == null)
								{
									return;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1231 @ rax_v38 (System.Object)+10]");
								if ((nint)0 == 0)
								{
									return;
								}
								GameManager core7 = GM.Core;
								if ((object)GM.Core != null)
								{
									Action action = BigPianoOut;
									if (core7._signalBus != null)
									{
										nint num = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rbx_v12 (Il2CppMethodInfo)+38]");
										if ((nint)0 == 0)
										{
										}
										object obj6 = null;
										if (obj6 != null)
										{
											Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ClosePianoSignal>)obj6)._003CSubscribeId_003Eb__0;
											((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ClosePianoSignal>)0)._003CSubscribeId_003Eb__0((object)1);
											object obj8 = default(object);
											object obj7 = obj8 + 32;
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
											SignalBus signalBus = core7._signalBus;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v54 (System.Object)+10]");
											Type signalType = default(Type);
											Action<object> callback = default(Action<object>);
											signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
											GameManager core8 = GM.Core;
											if ((object)GM.Core != null)
											{
												Action action3 = ProcessRightCoffinOpened;
												if (core8._signalBus != null)
												{
													nint num2 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rbx_v16 (Il2CppMethodInfo)+38]");
													if ((nint)0 == 0)
													{
													}
													object obj9 = null;
													if (obj9 != null)
													{
														Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.RightCoffinOpened>)obj9)._003CSubscribeId_003Eb__0;
														((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.RightCoffinOpened>)0)._003CSubscribeId_003Eb__0((object)1);
														object obj11 = default(object);
														object obj10 = obj11 + 32;
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
														SignalBus signalBus2 = core8._signalBus;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v71 (System.Object)+10]");
														Type signalType2 = default(Type);
														signalBus2.SubscribeInternal(signalType2, (object)null, (object)0, callback);
														_triggerCheck = true;
														_canInteractWithPiano = true;
														_piano = (SuperObject)obj4;
														if ((object)_piano != null)
														{
															Transform transform = _piano.transform;
															if ((object)transform != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v79 (UnityEngine.Transform)+10]");
																bool flag = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v79 (UnityEngine.Transform)+10]");
																Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
																float num3 = _pianoOffset * 20.48f;
																float num4 = num3 + (float)ret;
																_pianoPos = (Vector2)num4;
																_coffin = (SuperObject)obj5;
																if ((object)_coffin != null)
																{
																	Transform transform2 = _coffin.transform;
																	if ((object)transform2 != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v86 (UnityEngine.Transform)+10]");
																		bool flag2 = (nint)0 == 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v86 (UnityEngine.Transform)+10]");
																		Transform.get_position_Injected((IntPtr)0, out ret);
																		float num5 = _pianoOffset * 20.48f;
																		float num6 = num5 + (float)ret;
																		_coffinPos = (Vector2)num6;
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
		goto IL_06f2;
		IL_06f2:
		throw new NullReferenceException();
	}

	public void BigPianoIn(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		SpeedupManager instance = SpeedupManager.Instance;
		instance.SetSpeedupBlocked(isBlocked: true);
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			GM.Core.QueueEnterPianoScene(player);
			return;
		}
		OnlineStageManager instance2 = OnlineStageManager._instance;
		Action<long, CoherenceSync> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA56D0");
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F6D7F0");
	}

	public void BigPianoOut()
	{
		SpeedupManager instance = SpeedupManager.Instance;
		instance.SetSpeedupBlocked(isBlocked: false);
		Action onComplete = delegate
		{
			_canInteractWithPiano = true;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer pianoInteractionTimer = Timers.Register(5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_pianoInteractionTimer = pianoInteractionTimer;
	}

	public unsafe void BigSpoop()
	{
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected Ref, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected Ref, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected Ref, but got Unknown
		//IL_023f: Expected O, but got I4
		//IL_026f: Expected O, but got I4
		//IL_03cc: Expected O, but got I
		//IL_0426: Expected O, but got I
		//IL_040b: Expected O, but got I4
		SpeedupManager instance = SpeedupManager.Instance;
		instance.SetSpeedupBlocked(isBlocked: false);
		GameManager core = GM.Core;
		core._lootManager.SetPlainLootTable();
		_pianoDone = true;
		GameManager.SfxVolumeFactor = 0.35f;
		_canInteractWithPiano = false;
		if (_pianoInteractionTimer != null)
		{
			_pianoInteractionTimer.Cancel();
		}
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		stage._tilingTileset.spianami();
		GameManager core3 = GM.Core;
		Stage stage2 = core3._stage;
		List<Vector2> destructibleLocations = stage2._destructibleLocations;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rcx_v17 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float displayHeight = renderer.height + 0.19999999f;
			_displayHeight = displayHeight;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene2._renderer;
				ref PhaserSprite fogEdgeB = ref *(PhaserSprite*)(this + 200);
				float displayWidth = renderer2.width + 0.19999999f;
				ref PhaserSprite fogEdgeA = ref *(PhaserSprite*)(this + 192);
				ref PhaserSprite fog = ref *(PhaserSprite*)(this + 184);
				_displayWidth = displayWidth;
				base.SetupDarknessFog(ref fog, ref fogEdgeA, ref fogEdgeB);
				GameManager core4 = GM.Core;
				PlayerOptionsData config = core4._playerOptions.Config;
				SoundManager.StopMusic(config._003CSelectedBGM_003Ek__BackingField);
				MasterAudio.StopMixer();
				GameManager core5 = GM.Core;
				PlayerOptionsData config2 = core5._playerOptions.Config;
				_saveDmg = config2._003CDamageNumbersEnabled_003Ek__BackingField;
				GameManager core6 = GM.Core;
				PlayerOptionsData config3 = core6._playerOptions.Config;
				_saveBgm = (BgmType?)(object)1;
				GameManager core7 = GM.Core;
				PlayerOptionsData config4 = core7._playerOptions.Config;
				_saveBgmMod = (BgmModType?)(object)1;
				GameManager core8 = GM.Core;
				PlayerOptionsData config5 = core8._playerOptions.Config;
				config5._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Spoopy;
				GameManager core9 = GM.Core;
				PlayerOptionsData config6 = core9._playerOptions.Config;
				config6._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
				GameManager core10 = GM.Core;
				PlayerOptionsData config7 = core10._playerOptions.Config;
				config7._003CDamageNumbersEnabled_003Ek__BackingField = false;
				GM.Core.SetupMusicBanger();
				GameManager core11 = GM.Core;
				core11._canRunTickerTimer = false;
				GM.Core.EraseEnemies(showVfx: false);
				GameManager core12 = GM.Core;
				Stage stage3 = core12._stage;
				StageData stageData = stage3._stageData;
				stageData._003Cminimum_003Ek__BackingField = 30;
				GameManager core13 = GM.Core;
				List<EnemyType?> list = new List<EnemyType?>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rax_v65 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rax_v65 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rax_v65 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rdx_v21+18]");
				if (num >= 0)
				{
					list.AddWithResize((EnemyType?)(object)1);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rax_v65 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
					object obj2 = (nint)0 + (nint)1;
					_ = 1;
				}
				List<EnemyType?> bosses = new List<EnemyType?>();
				core13._stage.UpdateEnemyPools(list, bosses);
				GameManager core14 = GM.Core;
				Stage stage4 = core14._stage;
				stage4._003CStopCheckingMinutes_003Ek__BackingField = true;
				Action onComplete = delegate
				{
					//IL_00ae: Expected O, but got I4
					//IL_0144: Expected O, but got I4
					GameManager core15 = GM.Core;
					Stage stage5 = core15._stage;
					StageData stageData2 = stage5._stageData;
					int num2 = stageData2._003Cminimum_003Ek__BackingField + 30;
					stageData2._003Cminimum_003Ek__BackingField = num2;
					GameManager core16 = GM.Core;
					Stage stage6 = core16._stage;
					List<System.Int32Enum?> enemyTypes = (List<System.Int32Enum?>)(object)stage6._enemyTypes;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v9 (System.Collections.Generic.List`1<System.Nullable`1<System.Int32Enum>>)+18]");
					Stage stage7;
					List<EnemyType?> list3;
					if ((nint)0 != 0)
					{
						int num3 = enemyTypes.IndexOf((System.Int32Enum?)(object)1);
						if (num3 != -1)
						{
							GameManager core17 = GM.Core;
							stage7 = core17._stage;
							List<EnemyType?> list2 = new List<EnemyType?>();
							list3 = list2;
							goto IL_0136;
						}
					}
					GameManager core18 = GM.Core;
					stage7 = core18._stage;
					List<EnemyType?> list4 = new List<EnemyType?>();
					list3 = list4;
					goto IL_0136;
					IL_0136:
					int num4 = list3.IndexOf((EnemyType?)(object)1);
					List<EnemyType?> bosses2 = new List<EnemyType?>();
					stage7.UpdateEnemyPools(list3, bosses2);
					if (++_undeadsTimerLoopCount >= 5 && _undeadsTimer != null)
					{
						_undeadsTimer.Cancel();
					}
				};
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer undeadsTimer = Timers.Register(30.000002f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_undeadsTimer = undeadsTimer;
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 981 Invalid \"Jump target not found in method: 0x186ECA000\"");
			}
		}
		throw new NullReferenceException();
	}

	public override void Cleanup()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		GameManager core = GM.Core;
		Action token = BigPianoOut;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		core._signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		GameManager core2 = GM.Core;
		Action token2 = ProcessRightCoffinOpened;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		core2._signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
		if ((object)_saveBgm != null)
		{
			GameManager core3 = GM.Core;
			PlayerOptionsData config = core3._playerOptions.Config;
			if ((object)_saveBgm == null)
			{
				goto IL_0250;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background2)+8C]");
			config._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Forest;
			GameManager core4 = GM.Core;
			PlayerOptionsData config2 = core4._playerOptions.Config;
			config2._003CDamageNumbersEnabled_003Ek__BackingField = _saveDmg;
		}
		if ((object)_saveBgmMod != null)
		{
			GameManager core5 = GM.Core;
			PlayerOptionsData config3 = core5._playerOptions.Config;
			if ((object)_saveBgmMod == null)
			{
				goto IL_0250;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background2)+94]");
			config3._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
		}
		GameManager.SfxVolumeFactor = 1f;
		return;
		IL_0250:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	public override void CustomPreload(Action onComplete)
	{
		//IL_006f: Expected I, but got O
		AsyncLoader asyncLoader = new AsyncLoader(onComplete);
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			List<string> texturesForCharacterType = CharacterLoader.GetTexturesForCharacterType(CharacterType.AVATAR, core._playerOptions, core._dataManager);
			if (texturesForCharacterType != null)
			{
				List<string>.Enumerator enumerator = default(List<string>.Enumerator);
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass30_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass30_0();
					bool flag = CS_0024_003C_003E8__locals3 == null;
					nint num = (nint)typeof(_003C_003Ec__DisplayClass30_0);
					if (!flag)
					{
						CS_0024_003C_003E8__locals3.texture = null;
						Action<Action> loadCall = delegate(Action cb)
						{
							//IL_0029: Expected I4, but got O
							_003C_003Ec__DisplayClass30_1 obj = new _003C_003Ec__DisplayClass30_1();
							obj.cb = cb;
							Action<bool> action = null;
							((_003C_003Ec__DisplayClass30_1)(object)action)._003CCustomPreload_003Eb__1((byte)(int)obj != 0);
							GameManager core2 = GM.Core;
							string customCacheGroup = default(string);
							CharacterLoader.LoadCharacterTextureAsync(CS_0024_003C_003E8__locals3.texture, CharacterType.AVATAR, action, core2._dataManager, customCacheGroup);
						};
						if (asyncLoader != null)
						{
							asyncLoader.Add(loadCall);
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				if (asyncLoader != null)
				{
					asyncLoader.Load();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void MakeCoffins()
	{
		//IL_0057: Expected O, but got F4
		//IL_00d8: Expected I, but got O
		//IL_00e6: Expected I, but got O
		//IL_00f6: Expected O, but got I
		//IL_0176: Expected O, but got I4
		//IL_0132: Expected O, but got I
		//IL_0168: Expected O, but got I4
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected O, but got Unknown
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		List<PickupCoffinEmpty> list = new List<PickupCoffinEmpty>();
		float num = (float)_coffinPos - 20.48f;
		_coffinPos = (Vector2)num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background2)+EC]");
		float num2 = 0f + 20.48f;
		PickupCoffinEmpty pickupCoffinEmpty = null;
		Vector2 pos = default(Vector2);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		do
		{
			PickupCoffinEmpty pickupCoffinEmpty2 = null;
			do
			{
				Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.COFFIN_EMPTY, WeaponType.VOID, value, relicType, validatePickups);
				PickupCoffinEmpty pickupCoffinEmpty3;
				if ((object)pickup == null)
				{
					pickupCoffinEmpty3 = null;
					goto IL_02c4;
				}
				nint num3 = (nint)pickup;
				nint num4 = (nint)typeof(PickupCoffinEmpty);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCoffinEmpty>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCoffinEmpty>)+130]");
				object obj3;
				if (num5 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v44+FFFFFFF8+v461 @ rax_v40*8]");
					if (0 == (nint)typeof(PickupCoffinEmpty))
					{
						obj3 = 1;
						goto IL_029d;
					}
				}
				obj3 = 0;
				goto IL_029d;
				IL_029d:
				bool flag = obj3 == null;
				pickupCoffinEmpty3 = null;
				if (!flag)
				{
					pickupCoffinEmpty3 = (PickupCoffinEmpty)pickup;
				}
				goto IL_02c4;
				IL_02c4:
				if ((object)pickupCoffinEmpty3 != null && ((UnityEngine.Object)pickupCoffinEmpty3).m_CachedPtr != (IntPtr)0)
				{
					pickupCoffinEmpty3.SetChar(CharacterType.VOID);
					((List<object>)(object)list).Add((object)pickupCoffinEmpty3);
				}
				pickupCoffinEmpty2 = (PickupCoffinEmpty)(pickupCoffinEmpty2 + 1);
			}
			while ((nint)pickupCoffinEmpty2 < 3);
			pickupCoffinEmpty = (PickupCoffinEmpty)(pickupCoffinEmpty + 1);
		}
		while ((nint)pickupCoffinEmpty < 3);
		PickupCoffinEmpty rightCoffin = Extensions.PickRnd(list);
		_rightCoffin = rightCoffin;
		_rightCoffin.SetChar(CharacterType.AVATAR);
		PickupCoffinEmpty rightCoffin2 = _rightCoffin;
		Action action = OnRightCoffinOpened;
		rightCoffin2._003COnOpen_003Ek__BackingField = action;
	}

	private void OnRightCoffinOpened()
	{
		//IL_009e: Expected I8, but got O
		//IL_0082: Expected I8, but got O
		//IL_0057: Expected O, but got I
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 69 Invalid \"Jump target not found in method: 0x186ECA5C0\"");
		}
		long num = (long)OnlineStageManager._instance;
		Action<long> action = null;
		((OnlineStageManager)(object)action).RightCoffinOpened((long)OnlineStageManager._instance);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rbx_v4 (System.Int64)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	private void ProcessRightCoffinOpened()
	{
		//IL_009d: Expected I, but got O
		//IL_0107: Expected I, but got O
		//IL_0171: Expected I, but got O
		//IL_01d5: Expected O, but got I4
		if (_undeadsTimer != null)
		{
			_undeadsTimer.Cancel();
		}
		GM.Core.EraseEnemies(showVfx: false);
		SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 3000f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[3];
		PhaserSprite sDarkness = _sDarkness;
		if ((object)sDarkness._spriteRenderer != null)
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
		PhaserSprite sDarknessExtraA = _sDarknessExtraA;
		if ((object)sDarknessExtraA._spriteRenderer != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		PhaserSprite sDarknessExtraB = _sDarknessExtraB;
		if ((object)sDarknessExtraB._spriteRenderer != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 5000f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		Action onComplete = delegate
		{
			//IL_0303->IL0291: Incompatible stack heights: 1 vs 0
			//IL_00d1->IL00d1: Incompatible stack heights: 1 vs 0
			if ((object)GM.Core != null)
			{
				if (!GM.Core.IsStageHost)
				{
					goto IL_00d1;
				}
				GameManager core3 = GM.Core;
				if ((object)GM.Core != null && (object)_rightCoffin != null)
				{
					Transform transform = _rightCoffin.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						if ((object)core3._stage != null)
						{
							Vector2 spawnPos = default(Vector2);
							bool forceSpawn = default(bool);
							GameObject gameObject = core3._stage.SpawnEnemy(EnemyType.BOSS_SHARD_INFERNAS, spawnPos, asRemote: false, forceSpawn);
							goto IL_00d1;
						}
					}
				}
			}
			goto IL_0291;
			IL_00d1:
			GameManager core4 = GM.Core;
			if ((object)GM.Core != null && core4._playerOptions != null)
			{
				PlayerOptionsData config = core4._playerOptions.Config;
				if (config != null)
				{
					config._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Flame;
					GameManager core5 = GM.Core;
					if ((object)GM.Core != null && core5._playerOptions != null)
					{
						PlayerOptionsData config2 = core5._playerOptions.Config;
						if (config2 != null)
						{
							config2._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
							GameManager core6 = GM.Core;
							if ((object)GM.Core != null && core6._playerOptions != null)
							{
								PlayerOptionsData config3 = core6._playerOptions.Config;
								if (config3 != null)
								{
									config3._003CDamageNumbersEnabled_003Ek__BackingField = true;
									if ((object)GM.Core != null)
									{
										GM.Core.SetupMusicBanger();
										return;
									}
								}
							}
						}
					}
				}
			}
			goto IL_0291;
			IL_0291:
			throw new NullReferenceException();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		GameManager core = GM.Core;
		List<EnemyType?> enemies = new List<EnemyType?>();
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		core._stage.UpdateEnemyPools(enemies, stage._bossTypes);
		GM.Core.EraseEnemies(showVfx: false);
	}

	private void RevealTrickster()
	{
		GameManager core = GM.Core;
		Vector2 spawnPos = default(Vector2);
		bool forceSpawn = default(bool);
		GameObject gameObject = core._stage.SpawnEnemy(EnemyType.BOSS_XLTRICKSTER, spawnPos, asRemote: false, forceSpawn);
		if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
		{
			EnemyTrickster component = gameObject.GetComponent<EnemyTrickster>();
			_enemyTrickster = component;
			EnemyTrickster enemyTrickster = _enemyTrickster;
			if ((object)_enemyTrickster != null && ((UnityEngine.Object)enemyTrickster).m_CachedPtr != (IntPtr)0)
			{
				Action onDefeat = HandleTricksterDefeat;
				_enemyTrickster.OnDefeat = onDefeat;
			}
		}
	}

	private void HandleTricksterDefeat()
	{
		EnemyTrickster enemyTrickster = _enemyTrickster;
		if ((object)_enemyTrickster != null && ((UnityEngine.Object)enemyTrickster).m_CachedPtr != (IntPtr)0)
		{
			EnemyTrickster enemyTrickster2 = _enemyTrickster;
			Action value = HandleTricksterDefeat;
			Delegate obj = Delegate.Remove(enemyTrickster2._003COnDefeat_003Ek__BackingField, value);
			if ((object)obj != null)
			{
				bool flag = (object)obj.GetType() != typeof(Action);
				Delegate obj2 = null;
				if (!flag)
				{
					obj2 = obj;
				}
				bool flag2 = (object)obj2 == null;
				obj = obj2;
				if (flag2)
				{
					throw new InvalidCastException();
				}
			}
			enemyTrickster2._003COnDefeat_003Ek__BackingField = (Action)obj;
		}
		_canInteractWithPiano = true;
		_hasDefeatedTrickster = true;
	}

	private unsafe void SetupDarkness()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Ref, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Ref, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Ref, but got Unknown
		base.SetupDarknessFog(ref *(PhaserSprite*)(this + 184), ref *(PhaserSprite*)(this + 192), ref *(PhaserSprite*)(this + 200));
	}

	private void _003CBigPianoOut_003Eb__27_0()
	{
		_canInteractWithPiano = true;
	}

	private void _003CBigSpoop_003Eb__28_0()
	{
		//IL_00ae: Expected O, but got I4
		//IL_0144: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageData stageData = stage._stageData;
		int num = stageData._003Cminimum_003Ek__BackingField + 30;
		stageData._003Cminimum_003Ek__BackingField = num;
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		List<System.Int32Enum?> enemyTypes = (List<System.Int32Enum?>)(object)stage2._enemyTypes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v9 (System.Collections.Generic.List`1<System.Nullable`1<System.Int32Enum>>)+18]");
		Stage stage3;
		List<EnemyType?> list2;
		if ((nint)0 != 0)
		{
			int num2 = enemyTypes.IndexOf((System.Int32Enum?)(object)1);
			if (num2 != -1)
			{
				GameManager core3 = GM.Core;
				stage3 = core3._stage;
				List<EnemyType?> list = new List<EnemyType?>();
				list2 = list;
				goto IL_0136;
			}
		}
		GameManager core4 = GM.Core;
		stage3 = core4._stage;
		List<EnemyType?> list3 = new List<EnemyType?>();
		list2 = list3;
		goto IL_0136;
		IL_0136:
		int num3 = list2.IndexOf((EnemyType?)(object)1);
		List<EnemyType?> bosses = new List<EnemyType?>();
		stage3.UpdateEnemyPools(list2, bosses);
		if (++_undeadsTimerLoopCount >= 5 && _undeadsTimer != null)
		{
			_undeadsTimer.Cancel();
		}
	}

	private void _003CProcessRightCoffinOpened_003Eb__33_0()
	{
		//IL_0303->IL0291: Incompatible stack heights: 1 vs 0
		//IL_00d1->IL00d1: Incompatible stack heights: 1 vs 0
		if ((object)GM.Core != null)
		{
			if (!GM.Core.IsStageHost)
			{
				goto IL_00d1;
			}
			GameManager core = GM.Core;
			if ((object)GM.Core != null && (object)_rightCoffin != null)
			{
				Transform transform = _rightCoffin.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					if ((object)core._stage != null)
					{
						Vector2 spawnPos = default(Vector2);
						bool forceSpawn = default(bool);
						GameObject gameObject = core._stage.SpawnEnemy(EnemyType.BOSS_SHARD_INFERNAS, spawnPos, asRemote: false, forceSpawn);
						goto IL_00d1;
					}
				}
			}
		}
		goto IL_0291;
		IL_00d1:
		GameManager core2 = GM.Core;
		if ((object)GM.Core != null && core2._playerOptions != null)
		{
			PlayerOptionsData config = core2._playerOptions.Config;
			if (config != null)
			{
				config._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Flame;
				GameManager core3 = GM.Core;
				if ((object)GM.Core != null && core3._playerOptions != null)
				{
					PlayerOptionsData config2 = core3._playerOptions.Config;
					if (config2 != null)
					{
						config2._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
						GameManager core4 = GM.Core;
						if ((object)GM.Core != null && core4._playerOptions != null)
						{
							PlayerOptionsData config3 = core4._playerOptions.Config;
							if (config3 != null)
							{
								config3._003CDamageNumbersEnabled_003Ek__BackingField = true;
								if ((object)GM.Core != null)
								{
									GM.Core.SetupMusicBanger();
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0291;
		IL_0291:
		throw new NullReferenceException();
	}
}
