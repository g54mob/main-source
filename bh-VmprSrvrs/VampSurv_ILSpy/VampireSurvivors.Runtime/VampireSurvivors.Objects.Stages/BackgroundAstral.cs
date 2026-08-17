using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.Speedup;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundAstral : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<SuperObject, bool> _003C_003E9__55_0;

		public static Action<Action> _003C_003E9__56_0;

		public static Action<Action> _003C_003E9__56_1;

		public static Func<SuperObject, bool> _003C_003E9__59_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe bool _003CMakeDoor46Event_003Eb__55_0(SuperObject o)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3AFD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)o != null)
			{
				string tiledName = o.m_TiledName;
				if (o.m_TiledName != null)
				{
					object obj = "Door46";
					if ((object)o.m_TiledName != "Door46")
					{
						if ("Door46" != null)
						{
							int stringLength = tiledName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("Door46" + 20);
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

		internal void _003CCustomPreload_003Eb__56_0(Action cb)
		{
			//IL_001d: Expected O, but got I4
			AudioLoader.LoadSFXAsync(SfxType.Wind, "SFX", (DlcType?)(object)0, cb);
		}

		internal void _003CCustomPreload_003Eb__56_1(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0046: Expected O, but got I4
			_003C_003Ec__DisplayClass56_2 obj = new _003C_003Ec__DisplayClass56_2();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass56_2)(object)action)._003CCustomPreload_003Eb__4((byte)(int)obj != 0);
			SpriteLoader.LoadTextureAsync("UI_StageIcons", "Gameplay", (DlcType?)(object)0, action);
		}

		internal unsafe bool _003CMakePizza_003Eb__59_0(SuperObject o)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3B00]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)o != null)
			{
				string tiledName = o.m_TiledName;
				if (o.m_TiledName != null)
				{
					object obj = "ASTRALSTAIR_PIZZA";
					if ((object)o.m_TiledName != "ASTRALSTAIR_PIZZA")
					{
						if ("ASTRALSTAIR_PIZZA" != null)
						{
							int stringLength = tiledName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("ASTRALSTAIR_PIZZA" + 20);
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

	private sealed class _003C_003Ec__DisplayClass45_0
	{
		public PhaserSprite p;

		public bool isLeft;

		public BackgroundAstral _003C_003E4__this;

		internal unsafe void _003CMakeSpinningPortraits_003Eb__0()
		{
			//IL_002b: Expected O, but got Ref
			if (isLeft)
			{
			}
			Transform transform = p.transform;
			object obj = default(object);
			transform.localEulerAngles = (Vector3)(&obj);
			BackgroundAstral backgroundAstral = _003C_003E4__this;
			string spriteName = Extensions.PickRnd(backgroundAstral._portraitFrames);
			PhaserSprite phaserSprite = p.setFrame(spriteName, "UI_StageIcons");
		}
	}

	private sealed class _003C_003Ec__DisplayClass46_0
	{
		public BackgroundAstral _003C_003E4__this;

		public object[] players;

		public TweenCallback _003C_003E9__3;

		internal void _003CStartIntroSequence_003Eb__0()
		{
			//IL_000e: Expected O, but got I4
			//IL_0017: Expected O, but got I4
			//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b2: Expected O, but got Unknown
			//IL_00e2->IL016c: Incompatible stack heights: 1 vs 0
			//IL_0108->IL016c: Incompatible stack heights: 1 vs 0
			//IL_013b->IL016c: Incompatible stack heights: 1 vs 0
			//IL_0216->IL016c: Incompatible stack heights: 2 vs 0
			//IL_02cc->IL016c: Incompatible stack heights: 5 vs 0
			//IL_016b->IL02d1: Incompatible stack heights: 5 vs 0
			BackgroundAstral backgroundAstral = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				object obj = 0;
				object obj2 = 0;
				Vector3 value = default(Vector3);
				while (true)
				{
					List<PhaserSprite> portraits = backgroundAstral._portraits;
					if (backgroundAstral._portraits == null)
					{
						break;
					}
					if ((nint)obj2 < portraits._size)
					{
						BackgroundAstral backgroundAstral2 = _003C_003E4__this;
						if ((object)_003C_003E4__this == null)
						{
							break;
						}
						List<PhaserSprite> portraits2 = backgroundAstral2._portraits;
						if (backgroundAstral2._portraits == null)
						{
							break;
						}
						bool flag = (nint)obj >= portraits2._size;
						PhaserSprite[] items = portraits2._items;
						if (portraits2._items == null || (object)items[obj] == null)
						{
							break;
						}
						Transform transform = items[obj].transform;
						if ((object)transform == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v30 (UnityEngine.Transform)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v30 (UnityEngine.Transform)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 _);
						Transform transform2 = items[obj].transform;
						Transform transform3 = items[obj].transform;
						if ((object)transform3 == null)
						{
							break;
						}
						bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
						bool flag4 = (object)transform2 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v789 @ rax_v36 (UnityEngine.Transform)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v789 @ rax_v36 (UnityEngine.Transform)+10]");
						Transform.set_position_Injected((IntPtr)0, ref value);
						backgroundAstral = _003C_003E4__this;
						obj++;
						if ((object)_003C_003E4__this == null)
						{
							break;
						}
						obj2 = obj;
						continue;
					}
					return;
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CStartIntroSequence_003Eb__1()
		{
			SpeedupManager instance = SpeedupManager.Instance;
			instance.SetSpeedupBlocked(isBlocked: true);
			GameManager core = GM.Core;
			core._canRunTickerTimer = true;
			GameManager core2 = GM.Core;
			core2._stage.StartTimers();
			GameManager core3 = GM.Core;
			PlayerOptionsData config = core3._playerOptions.Config;
			config._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_AstralStair;
			GameManager core4 = GM.Core;
			PlayerOptionsData config2 = core4._playerOptions.Config;
			config2._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
			GM.Core.SetupMusicBanger();
			_003C_003E4__this.StartFlipBeats();
			_003C_003E4__this.StartBeatsLoop();
			_003C_003E4__this.EnterHand();
		}

		internal unsafe void _003CStartIntroSequence_003Eb__2()
		{
			//IL_00e9: Expected O, but got I4
			GameManager core = GM.Core;
			Stage stage = core._stage;
			Action onComplete = delegate
			{
				_003C_003E4__this._stopPlayerMovement = false;
				GameManager core2 = GM.Core;
				core2._003CCanInterrupt_003Ek__BackingField = true;
				GameManager core3 = GM.Core;
				core3._003CCanPause_003Ek__BackingField = true;
			};
			stage._tilingTileset.FadeAllLayers(1f, 1500f, onComplete);
			BackgroundAstral backgroundAstral = _003C_003E4__this;
			if (backgroundAstral._trisection != null)
			{
				backgroundAstral._trisection.ShowCircles();
			}
			SpeedupManager instance = SpeedupManager.Instance;
			instance.SetSpeedupBlocked(isBlocked: false);
			TweenConfig tweenConfig = new TweenConfig();
			tweenConfig.targets = players;
			tweenConfig.duration = 1500f;
			tweenConfig.y = (float?)(object)1;
			TweenCallback onComplete2 = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				onComplete2 = (_003C_003E9__3 = delegate
				{
					//IL_00fc: Expected I, but got O
					//IL_012d: Expected O, but got I
					//IL_0164: Expected O, but got I
					//IL_020f: Expected O, but got Ref
					//IL_01d1: Expected O, but got I4
					//IL_01d9: Expected O, but got Ref
					//IL_0246: Expected O, but got Ref
					//IL_025c: Expected O, but got Ref
					//IL_02ac: Expected I, but got O
					//IL_02dd: Expected O, but got I
					//IL_0314: Expected O, but got I
					//IL_03b5: Expected I, but got O
					//IL_03e6: Expected O, but got I
					//IL_041d: Expected O, but got I
					bool flag = (object)_003C_003E4__this == null;
					Stage stage2 = (Stage)(object)_003C_003E4__this;
					if (!flag)
					{
						_003C_003E4__this.RestorePlayersCharmStat();
						stage2 = (Stage)(object)GM.Core;
						if ((object)GM.Core != null)
						{
							stage2 = (Stage)(object)stage2._enemySpawnLocations;
							if (stage2._enemySpawnLocations != null)
							{
								((Stage)(object)stage2._enemySpawnLocations).RecalculateCurseAndCharm();
								BackgroundAstral backgroundAstral2 = _003C_003E4__this;
								if ((object)_003C_003E4__this != null)
								{
									stage2 = (Stage)(object)backgroundAstral2._trisection;
									if (backgroundAstral2._trisection != null)
									{
										((Stage)(object)backgroundAstral2._trisection).OnUpdate();
									}
									BackgroundAstral backgroundAstral3 = _003C_003E4__this;
									if ((object)_003C_003E4__this != null)
									{
										backgroundAstral3._isEventTrisectionEnabled = true;
										nint num = (nint)typeof(GM);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v13 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
										nint num2 = 0;
										GameManager core2 = GM.Core;
										bool flag2 = (object)GM.Core == null;
										stage2 = (Stage)num2;
										if (!flag2)
										{
											Stage stage3 = core2._stage;
											bool flag3 = (object)core2._stage == null;
											stage2 = (Stage)num2;
											if (!flag3)
											{
												stage2 = (Stage)(object)stage3._tilingTileset;
												if ((object)stage3._tilingTileset != null && stage2._noShadowLocations != null)
												{
													List<PickupTeleporter>.Enumerator enumerator = default(List<PickupTeleporter>.Enumerator);
													if (enumerator.MoveNext())
													{
														object obj = 0;
														List<PickupTeleporter>.Enumerator enumerator2 = (List<PickupTeleporter>.Enumerator)(&enumerator);
														throw new NullReferenceException();
													}
													GameManager core3 = GM.Core;
													bool flag4 = (object)GM.Core == null;
													stage2 = (Stage)(&enumerator);
													if (!flag4)
													{
														Stage stage4 = core3._stage;
														bool flag5 = (object)core3._stage == null;
														stage2 = (Stage)(&enumerator);
														if (!flag5)
														{
															stage2 = (Stage)(&enumerator);
															if (stage4._isCharmApplied)
															{
																return;
															}
															stage4._isCharmApplied = true;
															StageData stageData = stage4._stageData;
															if (stage4._stageData != null)
															{
																nint num3 = (nint)typeof(GM);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v25 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
																nint num4 = 0;
																GameManager core4 = GM.Core;
																bool flag6 = (object)GM.Core == null;
																stage2 = (Stage)num4;
																if (!flag6)
																{
																	GameSessionData gameSessionData = core4._gameSessionData;
																	bool flag7 = core4._gameSessionData == null;
																	stage2 = (Stage)num4;
																	if (!flag7)
																	{
																		stage2 = (Stage)(object)gameSessionData._activeCharacter;
																		if ((object)gameSessionData._activeCharacter != null)
																		{
																			DestructibleFactory destructibleFactory = stage2._destructibleFactory;
																			if ((object)stage2._destructibleFactory != null)
																			{
																				int num5 = stageData._003Cminimum_003Ek__BackingField;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v6 (VampireSurvivors.Framework.DestructibleFactory)+B4]");
																				int num6 = (int)((nint)num5 + (nint)0);
																				stageData._003Cminimum_003Ek__BackingField = num6;
																				nint num7 = (nint)typeof(GM);
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rax_v30 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
																				nint num8 = 0;
																				GameManager core5 = GM.Core;
																				bool flag8 = (object)GM.Core == null;
																				stage2 = (Stage)num8;
																				if (!flag8)
																				{
																					GameSessionData gameSessionData2 = core5._gameSessionData;
																					bool flag9 = core5._gameSessionData == null;
																					stage2 = (Stage)num8;
																					if (!flag9)
																					{
																						stage2 = (Stage)(object)gameSessionData2._activeCharacter;
																						if ((object)gameSessionData2._activeCharacter != null)
																						{
																							DestructibleFactory destructibleFactory2 = stage2._destructibleFactory;
																							if ((object)stage2._destructibleFactory != null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v33 (VampireSurvivors.Framework.DestructibleFactory)+B4]");
																								int maximum = (int)((nint)0 + (nint)stage4._defaultMaximum);
																								stage4._maximum = maximum;
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
				});
			}
			tweenConfig.onComplete = onComplete2;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}

		internal unsafe void _003CStartIntroSequence_003Eb__3()
		{
			//IL_00fc: Expected I, but got O
			//IL_012d: Expected O, but got I
			//IL_0164: Expected O, but got I
			//IL_020f: Expected O, but got Ref
			//IL_01d1: Expected O, but got I4
			//IL_01d9: Expected O, but got Ref
			//IL_0246: Expected O, but got Ref
			//IL_025c: Expected O, but got Ref
			//IL_02ac: Expected I, but got O
			//IL_02dd: Expected O, but got I
			//IL_0314: Expected O, but got I
			//IL_03b5: Expected I, but got O
			//IL_03e6: Expected O, but got I
			//IL_041d: Expected O, but got I
			bool flag = (object)_003C_003E4__this == null;
			Stage stage = (Stage)(object)_003C_003E4__this;
			if (!flag)
			{
				_003C_003E4__this.RestorePlayersCharmStat();
				stage = (Stage)(object)GM.Core;
				if ((object)GM.Core != null)
				{
					stage = (Stage)(object)stage._enemySpawnLocations;
					if (stage._enemySpawnLocations != null)
					{
						((Stage)(object)stage._enemySpawnLocations).RecalculateCurseAndCharm();
						BackgroundAstral backgroundAstral = _003C_003E4__this;
						if ((object)_003C_003E4__this != null)
						{
							stage = (Stage)(object)backgroundAstral._trisection;
							if (backgroundAstral._trisection != null)
							{
								((Stage)(object)backgroundAstral._trisection).OnUpdate();
							}
							BackgroundAstral backgroundAstral2 = _003C_003E4__this;
							if ((object)_003C_003E4__this != null)
							{
								backgroundAstral2._isEventTrisectionEnabled = true;
								nint num = (nint)typeof(GM);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v13 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
								nint num2 = 0;
								GameManager core = GM.Core;
								bool flag2 = (object)GM.Core == null;
								stage = (Stage)num2;
								if (!flag2)
								{
									Stage stage2 = core._stage;
									bool flag3 = (object)core._stage == null;
									stage = (Stage)num2;
									if (!flag3)
									{
										stage = (Stage)(object)stage2._tilingTileset;
										if ((object)stage2._tilingTileset != null && stage._noShadowLocations != null)
										{
											List<PickupTeleporter>.Enumerator enumerator = default(List<PickupTeleporter>.Enumerator);
											if (enumerator.MoveNext())
											{
												object obj = 0;
												List<PickupTeleporter>.Enumerator enumerator2 = (List<PickupTeleporter>.Enumerator)(&enumerator);
												throw new NullReferenceException();
											}
											GameManager core2 = GM.Core;
											bool flag4 = (object)GM.Core == null;
											stage = (Stage)(&enumerator);
											if (!flag4)
											{
												Stage stage3 = core2._stage;
												bool flag5 = (object)core2._stage == null;
												stage = (Stage)(&enumerator);
												if (!flag5)
												{
													stage = (Stage)(&enumerator);
													if (stage3._isCharmApplied)
													{
														return;
													}
													stage3._isCharmApplied = true;
													StageData stageData = stage3._stageData;
													if (stage3._stageData != null)
													{
														nint num3 = (nint)typeof(GM);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v25 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
														nint num4 = 0;
														GameManager core3 = GM.Core;
														bool flag6 = (object)GM.Core == null;
														stage = (Stage)num4;
														if (!flag6)
														{
															GameSessionData gameSessionData = core3._gameSessionData;
															bool flag7 = core3._gameSessionData == null;
															stage = (Stage)num4;
															if (!flag7)
															{
																stage = (Stage)(object)gameSessionData._activeCharacter;
																if ((object)gameSessionData._activeCharacter != null)
																{
																	DestructibleFactory destructibleFactory = stage._destructibleFactory;
																	if ((object)stage._destructibleFactory != null)
																	{
																		int num5 = stageData._003Cminimum_003Ek__BackingField;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v6 (VampireSurvivors.Framework.DestructibleFactory)+B4]");
																		int num6 = (int)((nint)num5 + (nint)0);
																		stageData._003Cminimum_003Ek__BackingField = num6;
																		nint num7 = (nint)typeof(GM);
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rax_v30 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
																		nint num8 = 0;
																		GameManager core4 = GM.Core;
																		bool flag8 = (object)GM.Core == null;
																		stage = (Stage)num8;
																		if (!flag8)
																		{
																			GameSessionData gameSessionData2 = core4._gameSessionData;
																			bool flag9 = core4._gameSessionData == null;
																			stage = (Stage)num8;
																			if (!flag9)
																			{
																				stage = (Stage)(object)gameSessionData2._activeCharacter;
																				if ((object)gameSessionData2._activeCharacter != null)
																				{
																					DestructibleFactory destructibleFactory2 = stage._destructibleFactory;
																					if ((object)stage._destructibleFactory != null)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v33 (VampireSurvivors.Framework.DestructibleFactory)+B4]");
																						int maximum = (int)((nint)0 + (nint)stage3._defaultMaximum);
																						stage3._maximum = maximum;
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
	}

	private sealed class _003C_003Ec__DisplayClass56_0
	{
		public string texture;

		internal void _003CCustomPreload_003Eb__2(Action cb)
		{
			//IL_0029: Expected I4, but got O
			_003C_003Ec__DisplayClass56_1 obj = new _003C_003Ec__DisplayClass56_1();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass56_1)(object)action)._003CCustomPreload_003Eb__3((byte)(int)obj != 0);
			GameManager core = GM.Core;
			string customCacheGroup = default(string);
			CharacterLoader.LoadCharacterTextureAsync(texture, CharacterType.ROSE, action, core._dataManager, customCacheGroup);
		}
	}

	private sealed class _003C_003Ec__DisplayClass56_1
	{
		public Action cb;

		internal void _003CCustomPreload_003Eb__3(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass56_2
	{
		public Action cb;

		internal void _003CCustomPreload_003Eb__4(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private StageEventTrisectionManager _trisection;

	private TileSprite _stars2;

	private PhaserSprite _carpet;

	private PhaserSprite _hand;

	private PhaserSprite _pizzaASprite;

	private Circle _pizzaA;

	private float _yMul;

	private float _startingX;

	private float _startingY;

	private float _distanceFromStartingY = 122.88f;

	private float _red = 255f;

	private float _blue = 255f;

	private int[] _cachedPlayerCharm;

	private bool _stopPlayerMovement;

	private bool _isPlayingIntroSequence;

	private bool _isEventTrisectionEnabled;

	private bool _isOnBeatComplete;

	private bool _canPizza;

	private BgmType _saveBgm;

	private BgmModType _saveBgmMod;

	private Timer _initialTimeout;

	private Timer _flipInterval;

	private Timer _flipClearTimeout;

	private Timer _mainInterval;

	private float _speedFactor = 1.1f;

	private List<PhaserSprite> _portraits;

	private List<MultiTargetTween> _portraitsTweens;

	private List<string> _portraitFrames;

	private PickupTeleporter secretDoor;

	private BgmType _secretEventSaveBgm;

	private PickupCoffin secretCoffin;

	private const float BGMDuration = 83650f;

	private const float InitialTimeoutDuration = 34000f;

	private const float FlipIntervalDuration = 800f;

	private const float FlipClearTimeoutDuration = 75000f;

	private void OnDrawGizmos()
	{
		if (_pizzaA != null)
		{
			Circle pizzaA = _pizzaA;
			VSDebug.DrawDebugCircle(pizzaA._x, pizzaA._y, pizzaA._radius);
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		Action<Pickup> value = OnRemoteItemInstantiated;
		Delegate obj = Delegate.Remove(ItemInstantiator.OnRemoteItemInstantiated, value);
		if ((object)obj == null)
		{
			ItemInstantiator.OnRemoteItemInstantiated = (Action<Pickup>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Action<Pickup> action = default(Action<Pickup>);
		if (action != null)
		{
			ItemInstantiator.OnRemoteItemInstantiated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	public override void Create()
	{
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_0d3b: Expected I4, but got I8
		base._003CHasMovingBg_003Ek__BackingField = true;
		if (!GM.Core.IsStageHost)
		{
			Action<Pickup> b = OnRemoteItemInstantiated;
			Delegate obj = Delegate.Combine(ItemInstantiator.OnRemoteItemInstantiated, b);
			if ((object)obj == null)
			{
				ItemInstantiator.OnRemoteItemInstantiated = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Action<Pickup> action = default(Action<Pickup>);
				if (action == null)
				{
					throw new InvalidCastException();
				}
				ItemInstantiator.OnRemoteItemInstantiated = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_0be6;
				}
			}
		}
		base.Create();
		_canPizza = true;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rcx_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool flag;
		if ((nint)0 == 0)
		{
			flag = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			object obj3 = obj4 - -1;
			bool flag2 = obj3 == null;
			flag = !flag2;
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		List<ItemType> list2 = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rcx_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool flag3;
		if ((nint)0 == 0)
		{
			flag3 = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj6 = default(object);
			object obj5 = obj6 - -1;
			bool flag4 = obj5 == null;
			flag3 = !flag4;
		}
		if (flag && flag3)
		{
			goto IL_0c24;
		}
		GameManager core3 = GM.Core;
		PlayerOptionsData config3 = core3._playerOptions.Config;
		config3._003CSelectedHurry_003Ek__BackingField = false;
		GameManager core4 = GM.Core;
		PlayerOptionsData config4 = core4._playerOptions.Config;
		config4._003CSelectedReapers_003Ek__BackingField = false;
		GameManager core5 = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = core5._characters;
		int[] cachedPlayerCharm = new int[characters._size];
		_cachedPlayerCharm = cachedPlayerCharm;
		GameManager core6 = GM.Core;
		bool flag5 = false;
		bool flag6 = false;
		GameManager core7 = GM.Core;
		while (true)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = core6._characters;
			if ((flag5 ? 1 : 0) >= characters2._size)
			{
				break;
			}
			List<VampireSurvivors.Objects.Characters.CharacterController> characters3 = core7._characters;
			if ((flag6 ? 1 : 0) < characters3._size)
			{
				VampireSurvivors.Objects.Characters.CharacterController[] items = characters3._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController = items[flag6 ? 1u : 0u];
				PlayerModifierStats playerStats = characterController._playerStats;
				int[] cachedPlayerCharm2 = _cachedPlayerCharm;
				cachedPlayerCharm2[flag6 ? 1u : 0u] = playerStats._003CCharm_003Ek__BackingField;
				GameManager core8 = GM.Core;
				List<VampireSurvivors.Objects.Characters.CharacterController> characters4 = core8._characters;
				if ((flag6 ? 1 : 0) < characters4._size)
				{
					VampireSurvivors.Objects.Characters.CharacterController[] items2 = characters4._items;
					VampireSurvivors.Objects.Characters.CharacterController characterController2 = items2[flag6 ? 1u : 0u];
					PlayerModifierStats playerStats2 = characterController2._playerStats;
					playerStats2._003CCharm_003Ek__BackingField = 0;
					flag6 = (byte)((flag6 ? 1u : 0u) + 1u) != 0;
					core7 = GM.Core;
					flag5 = flag6;
					core6 = GM.Core;
					continue;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			throw new IndexOutOfRangeException();
		}
		GameManager core9 = GM.Core;
		PlayerOptions playerOptions = core9._playerOptions;
		PlayerOptionsData playerOptionsData;
		if (playerOptions._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions._hostGameConfig == null)
			{
				if (playerOptions._currentAdventureSaveData != null)
				{
					playerOptionsData = playerOptions._currentAdventureSaveData;
					if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0c8b;
					}
				}
				playerOptionsData = playerOptions._mainGameConfig;
			}
			else
			{
				playerOptionsData = playerOptions._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
		}
		goto IL_0c8b;
		IL_0dbb:
		PlayerOptionsData playerOptionsData2;
		if (playerOptionsData2._003CVisuallyInvertStages_003Ek__BackingField)
		{
			TileSprite stars = _stars2;
			stars._spriteRenderer.flipY = true;
			_yMul = -1f;
		}
		goto IL_0e67;
		IL_0e67:
		GameManager core10 = GM.Core;
		PlayerOptions playerOptions2 = core10._playerOptions;
		PlayerOptionsData playerOptionsData3;
		if (playerOptions2._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions2._hostGameConfig == null)
			{
				if (playerOptions2._currentAdventureSaveData != null)
				{
					playerOptionsData3 = playerOptions2._currentAdventureSaveData;
					if ((object)playerOptionsData3._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0e02;
					}
				}
				playerOptionsData3 = playerOptions2._mainGameConfig;
			}
			else
			{
				playerOptionsData3 = playerOptions2._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData3 = playerOptions2._onlineClientWithRunDataConfig;
		}
		goto IL_0e02;
		IL_0be6:
		throw new InvalidCastException();
		IL_0e44:
		PlayerOptionsData playerOptionsData4;
		_saveBgmMod = playerOptionsData4._003CSelectedBGMMod_003Ek__BackingField;
		return;
		IL_0d74:
		PlayerOptionsData playerOptionsData5;
		if (playerOptionsData5._003CSelectedInverse_003Ek__BackingField)
		{
			GameManager core11 = GM.Core;
			PlayerOptions playerOptions3 = core11._playerOptions;
			if (playerOptions3._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions3._hostGameConfig == null)
				{
					if (playerOptions3._currentAdventureSaveData != null)
					{
						playerOptionsData2 = playerOptions3._currentAdventureSaveData;
						if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_0dbb;
						}
					}
					playerOptionsData2 = playerOptions3._mainGameConfig;
				}
				else
				{
					playerOptionsData2 = playerOptions3._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData2 = playerOptions3._onlineClientWithRunDataConfig;
			}
			goto IL_0dbb;
		}
		goto IL_0e67;
		IL_0c8b:
		if (playerOptionsData._003CSelectedGoldenEggs_003Ek__BackingField)
		{
			GameManager core12 = GM.Core;
			float num = core12._eggManager.RemoveBonuses();
			GameManager core13 = GM.Core;
			core13._stage.RecalculateCurseAndCharm();
		}
		GameManager core14 = GM.Core;
		core14._stage.ResetStageMinimumSpawnToDefault();
		GameManager core15 = GM.Core;
		Stage stage = core15._stage;
		stage._maximum = stage._defaultMaximum;
		goto IL_0c24;
		IL_0c24:
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene2._renderer;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer3 = s_scene3._renderer;
					if ((object)GM.Core != null)
					{
						float y = renderer2.height * 0.5f;
						float x = renderer.width * 0.5f;
						float height = default(float);
						string textureName = default(string);
						string spriteName = default(string);
						TileSprite component = RenderingExtensions.AddTileSprite(this, x, y, renderer3.width, height, textureName, spriteName);
						TileSprite tileSprite = RenderingExtensions.SetScrollFactor(component, 0f);
						PhaserScene s_scene4 = ArcadePhysics.s_scene;
						PhaserScene.Renderer renderer4 = s_scene4._renderer;
						int sortingOrder = renderer4.pixelHeight - 1;
						tileSprite._spriteRenderer.sortingOrder = sortingOrder;
						TileSprite tileSprite2 = RenderingExtensions.SetScrollFactor(tileSprite, 0f);
						object spriteRenderer = tileSprite2._spriteRenderer;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rdi_v10 (System.Object)+10]");
						if ((nint)0 == 0)
						{
							UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(spriteRenderer);
							goto IL_0be6;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rdi_v10 (System.Object)+10]");
						Renderer.set_sortingOrder_Injected((IntPtr)0, -32767);
						SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(tileSprite2._spriteRenderer, 16711680u);
						SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(tileSprite2._spriteRenderer, 0.15f);
						Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
						((Renderer)tileSprite2._spriteRenderer).SetMaterial(material);
						GameObject gameObject = tileSprite2.gameObject;
						((UnityEngine.Object)gameObject).SetName("Stars2");
						_stars2 = tileSprite2;
						TileSprite stars2 = _stars2;
						Material material2 = MaterialManager.GetMaterial(MaterialType.ScrollableSpriteAdditive);
						((Renderer)stars2._spriteRenderer).SetMaterial(material2);
						_yMul = 1f;
						GameManager core16 = GM.Core;
						PlayerOptions playerOptions4 = core16._playerOptions;
						if (playerOptions4._onlineClientWithRunDataConfig == null)
						{
							if (playerOptions4._hostGameConfig == null)
							{
								if (playerOptions4._currentAdventureSaveData != null)
								{
									playerOptionsData5 = playerOptions4._currentAdventureSaveData;
									if ((object)playerOptionsData5._003CSelectedAdventureType_003Ek__BackingField != null)
									{
										goto IL_0d74;
									}
								}
								playerOptionsData5 = playerOptions4._mainGameConfig;
							}
							else
							{
								playerOptionsData5 = playerOptions4._hostGameConfig;
							}
						}
						else
						{
							playerOptionsData5 = playerOptions4._onlineClientWithRunDataConfig;
						}
						goto IL_0d74;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0e02:
		_saveBgm = playerOptionsData3._003CSelectedBGM_003Ek__BackingField;
		GameManager core17 = GM.Core;
		PlayerOptions playerOptions5 = core17._playerOptions;
		if (playerOptions5._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions5._hostGameConfig == null)
			{
				if (playerOptions5._currentAdventureSaveData != null)
				{
					playerOptionsData4 = playerOptions5._currentAdventureSaveData;
					if ((object)playerOptionsData4._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0e44;
					}
				}
				playerOptionsData4 = playerOptions5._mainGameConfig;
			}
			else
			{
				playerOptionsData4 = playerOptions5._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData4 = playerOptions5._onlineClientWithRunDataConfig;
		}
		goto IL_0e44;
	}

	private void OnRemoteItemInstantiated(Pickup obj)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		if ((object)obj == null)
		{
			return;
		}
		nint num = (nint)typeof(PickupTeleporter);
		nint num2 = (nint)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.PickupTeleporter>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.PickupTeleporter>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v24+FFFFFFF8+v50 @ rax_v3*8]");
			if (0 == (nint)typeof(PickupTeleporter))
			{
				obj4 = 1;
				goto IL_0162;
			}
		}
		obj4 = 0;
		goto IL_0162;
		IL_0162:
		bool flag = obj4 == null;
		Pickup pickup = null;
		if (!flag)
		{
			pickup = obj;
		}
		if ((object)pickup != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v6 (VampireSurvivors.Objects.Pickups.Pickup)+238]");
			if ((nint)0 != 0)
			{
				secretDoor = (PickupTeleporter)pickup;
				Action<VampireSurvivors.Objects.Characters.CharacterController> value = OnReturnStarted;
				secretDoor.OnTeleportStartedAction += value;
				Action value2 = OnSecretFinished;
				secretDoor.OnTeleportFinishedAction += value2;
			}
		}
	}

	public override void OnInitCompleted()
	{
		//IL_0093: Expected I, but got O
		//IL_00fb: Expected I4, but got I8
		//IL_0117: Expected O, but got I4
		//IL_0195: Expected I, but got O
		//IL_01eb: Expected O, but got I4
		//IL_020b: Expected I4, but got I8
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Expected O, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected O, but got Unknown
		base.OnInitCompleted();
		GameManager core = GM.Core;
		TilingBackground bgMan = core._bgMan;
		TileSprite bgtile = bgMan._bgtile;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(bgtile._spriteRenderer, 0.35f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_stars2 != null)
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
		tweenConfig.duration = 1000f;
		tweenConfig.repeat = -1;
		tweenConfig.yoyo = true;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		GameManager core2 = GM.Core;
		TilingBackground bgMan2 = core2._bgMan;
		if ((object)bgMan2._bgtile != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.duration = 3000f;
		tweenConfig2.repeat = -1;
		tweenConfig2.yoyo = true;
		MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
		GameManager core3 = GM.Core;
		PlayerOptionsData config = core3._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool flag;
		if ((nint)0 == 0)
		{
			flag = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			object obj3 = obj4 - -1;
			bool flag2 = obj3 == null;
			flag = !flag2;
		}
		GameManager core4 = GM.Core;
		PlayerOptionsData config2 = core4._playerOptions.Config;
		List<ItemType> list2 = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rcx_v38 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool flag3;
		if ((nint)0 == 0)
		{
			flag3 = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj6 = default(object);
			object obj5 = obj6 - -1;
			bool flag4 = obj5 == null;
			flag3 = !flag4;
		}
		if (flag && flag3)
		{
			MakePizza();
			StartFlipBeats();
			StartBeatsLoop();
			return;
		}
		GameManager core5 = GM.Core;
		Stage stage = core5._stage;
		if (stage._isCharmApplied)
		{
			StageData stageData = stage._stageData;
			stage._isCharmApplied = false;
			GameManager core6 = GM.Core;
			GameSessionData gameSessionData = core6._gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
			PlayerModifierStats playerStats = activeCharacter._playerStats;
			int num3 = stageData._003Cminimum_003Ek__BackingField - playerStats._003CCharm_003Ek__BackingField;
			stageData._003Cminimum_003Ek__BackingField = num3;
			GameManager core7 = GM.Core;
			GameSessionData gameSessionData2 = core7._gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter2 = gameSessionData2._activeCharacter;
			PlayerModifierStats playerStats2 = activeCharacter2._playerStats;
			int maximum = stage._defaultMaximum - playerStats2._003CCharm_003Ek__BackingField;
			stage._maximum = maximum;
		}
		FirstTimeSetup();
		SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
		if (!flag3)
		{
			GameManager core8 = GM.Core;
			StageEventTrisectionManager trisection = core8._diContainer.Instantiate<StageEventTrisectionManager>();
			_trisection = trisection;
			_trisection.Initialize();
			GameManager core9 = GM.Core;
			_trisection.Init(core9._stage);
		}
	}

	protected unsafe override void OnUpdate()
	{
		//IL_009a: Expected O, but got I4
		//IL_0117: Expected O, but got F4
		//IL_09ca: Expected O, but got F4
		//IL_09d2: Invalid comparison between O and F4
		//IL_017d: Expected O, but got I4
		//IL_03e0: Invalid comparison between I4 and F4
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_048f: Expected O, but got Unknown
		//IL_04c8: Invalid comparison between I4 and F4
		//IL_03fd: Invalid comparison between F4 and I4
		//IL_04e8: Expected F4, but got I4
		//IL_0455: Invalid comparison between I4 and F4
		//IL_0475: Expected F4, but got I4
		//IL_0131->IL06d5: Incompatible stack heights: 3 vs 2
		//IL_0747->IL0747: Incompatible stack heights: 2 vs 0
		//IL_05d4->IL064d: Incompatible stack heights: 1 vs 0
		//IL_0603->IL064d: Incompatible stack heights: 1 vs 0
		base.OnUpdate();
		_isOnBeatComplete = true;
		if (!_stopPlayerMovement)
		{
			goto IL_019f;
		}
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator ret;
		if ((object)GM.Core != null)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
			if (core._characters != null)
			{
				ret = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core._characters;
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator characters2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core._characters;
				object obj = 0;
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				float num2 = default(float);
				float2 position = default(float2);
				while (enumerator.MoveNext())
				{
					ArcadeSprite arcadeSprite = null;
					Transform cachedTrans = ((ArcadeSprite)null).CachedTrans;
					bool flag = (object)cachedTrans == null;
					bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
					float ret2;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret2));
					float num;
					float num3;
					if (arcadeSprite.body != null)
					{
						BaseBody body = arcadeSprite.body;
						ArcadeTransform arcadeTransform = body._transform;
						bool flag3 = body._transform == null;
						arcadeTransform.position = (float2)ret2;
						num = num2;
						num3 = ret2;
					}
					else
					{
						num = num2;
						num3 = ret2;
					}
					float num4 = _startingX - 0.48f;
					if (num4 > num3)
					{
						num3 = _startingX - 0.48f;
					}
					float num5 = _startingX + 0.48f;
					if (!(num3 > num5))
					{
						float num6 = _startingY + 0.16f;
						if (num > num6)
						{
							num = _startingY + 0.16f;
						}
					}
					characters2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(_startingY - 0.32f);
					if (System.Runtime.CompilerServices.Unsafe.As<List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator, UIntPtr>(ref characters2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num))
					{
						obj = 1;
					}
					((ArcadeSprite)null).position = position;
				}
				bool flag4 = obj == null;
				int version = characters._version;
				if (!flag4)
				{
					StartIntroSequence();
					version = characters._version;
				}
				goto IL_019f;
			}
		}
		goto IL_064d;
		IL_019f:
		TileSprite stars = _stars2;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null && (object)_stars2 != null)
				{
					float scrollOffsetX = (stars._xScrollOffset = _speedFactor * (float)renderer.screenCenter);
					if ((object)stars._spriteScroller != null)
					{
						stars._spriteScroller.SetScrollOffsetX(scrollOffsetX);
						TileSprite stars2 = _stars2;
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene2 = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null)
							{
								PhaserScene.Renderer renderer2 = s_scene2._renderer;
								if (s_scene2._renderer != null && (object)_stars2 != null)
								{
									float num7 = _yMul * _speedFactor;
									float num8 = num7;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rcx_v31 (PhaserScene+Renderer)+38]");
									float num9 = (stars2._yScrollOffset = num8 * 0f);
									if ((object)stars2._spriteScroller != null)
									{
										stars2._spriteScroller.SetScrollOffsetY(num9);
										_red = 255f;
										_blue = 255f;
										if ((object)GM.Core != null)
										{
											PhaserScene s_scene3 = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null)
											{
												PhaserScene.Renderer renderer3 = s_scene3._renderer;
												if (s_scene3._renderer != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rcx_v35 (PhaserScene+Renderer)+38]");
													float num10 = 0f + 48f;
													if (!(0f > num10))
													{
														bool flag5 = !(num10 > 0f);
														float num11 = num9;
														if (!flag5)
														{
															float num12 = num10 / 102.399994f;
															float num13 = num12 * 255f;
															num11 = 255f - num13;
															if (0f > num11)
															{
																num11 = 0f;
															}
															_blue = num11;
														}
													}
													else
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
														object obj2 = num10 ^ 0;
														float num14 = (float)obj2 / 102.399994f;
														float num15 = num14 * 255f;
														float num11 = 255f - num15;
														if (0f > num11)
														{
															num11 = 0f;
														}
														_red = num11;
													}
													GameManager core2 = GM.Core;
													if ((object)GM.Core != null)
													{
														TilingBackground bgMan = core2._bgMan;
														if ((object)core2._bgMan != null)
														{
															GameManager core3 = GM.Core;
															TilingBackground bgMan2 = core3._bgMan;
															TileSprite bgtile = bgMan2._bgtile;
															if ((object)bgMan2._bgtile != null)
															{
																ArcadeSprite spriteRenderer = (ArcadeSprite)(object)bgtile._spriteRenderer;
																if ((object)bgtile._spriteRenderer != null)
																{
																	bool flag6 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
																	SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out *(Color*)(&ret));
																	Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm1\"");
																	Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
																	object obj3 = default(object);
																	float num16 = (float)obj3 / 255f;
																	object obj4 = obj3 >> 8;
																	float num17 = (float)obj4 / 255f;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CC9590");
																	Color32 tint = default(Color32);
																	TileSprite tileSprite = RenderingExtensions.SetTint(bgMan._bgtile, tint);
																	TileSprite stars3 = _stars2;
																	if ((object)_stars2 != null)
																	{
																		ArcadeSprite spriteRenderer2 = (ArcadeSprite)(object)stars3._spriteRenderer;
																		if ((object)stars3._spriteRenderer != null)
																		{
																			bool flag7 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
																			SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, out *(Color*)(&ret));
																			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm1\"");
																			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
																			object obj5 = default(object);
																			float num18 = (float)obj5 / 255f;
																			object obj6 = obj5 >> 8;
																			float num19 = (float)obj6 / 255f;
																			object obj7 = obj5 >> 16;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CC9590");
																			Color32 tint2 = default(Color32);
																			TileSprite tileSprite2 = RenderingExtensions.SetTint(_stars2, tint2);
																			if (_canPizza)
																			{
																				CheckPizzas();
																			}
																			if (_trisection != null)
																			{
																				_trisection.TrisectionUpdate();
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
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_064d;
		IL_064d:
		throw new NullReferenceException();
	}

	public override void CheckHalfMinute()
	{
		if (!_isEventTrisectionEnabled)
		{
			return;
		}
		if (_trisection != null)
		{
			_trisection.ShowCircles();
		}
		Action onComplete = delegate
		{
			if (_trisection != null)
			{
				_trisection.Spinnn();
			}
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public override void CheckMinute(int minute)
	{
		if (_isEventTrisectionEnabled && _trisection != null)
		{
			_trisection.TriggerTrisectionEvent();
		}
	}

	public override void Cleanup()
	{
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		if (_initialTimeout != null)
		{
			_initialTimeout.Cancel();
		}
		if (_flipInterval != null)
		{
			_flipInterval.Cancel();
		}
		if (_flipClearTimeout != null)
		{
			_flipClearTimeout.Cancel();
		}
		if (_mainInterval != null)
		{
			_mainInterval.Cancel();
		}
		RestorePlayersCharmStat();
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		config._003CSelectedBGM_003Ek__BackingField = _saveBgm;
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		config2._003CSelectedBGMMod_003Ek__BackingField = _saveBgmMod;
	}

	private unsafe void FirstTimeSetup()
	{
		//IL_0053: Expected F4, but got O
		//IL_0248: Expected O, but got I4
		//IL_0250: Expected O, but got Ref
		_stopPlayerMovement = true;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		_startingX = (float)tilingTileset._003CStartPosition_003Ek__BackingField;
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		TilingTileset tilingTileset2 = stage2._tilingTileset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rcx_v6 (VampireSurvivors.Objects.TilingTileset)+DC]");
		float startingY = 0f + _distanceFromStartingY;
		_startingY = startingY;
		float2 float5 = default(float2);
		GM.Core.CheckAllWeaponsForTeleport(float5);
		bool focusCameraOnPlayer = default(bool);
		GM.Core.TeleportPlayers(float5, float5, centered: true, focusCameraOnPlayer);
		if ((object)GM.Core == null)
		{
			throw new NullReferenceException();
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, float5, "background_Astral", "carpet");
		PhaserSprite carpet = phaserSprite.setDepth(-3000f);
		_carpet = carpet;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		if (enumerator.MoveNext())
		{
			Component component = null;
			throw new NullReferenceException();
		}
		GameManager core3 = GM.Core;
		core3._canRunTickerTimer = false;
		GameManager core4 = GM.Core;
		Stage stage3 = core4._stage;
		if (stage3._spawnTimer != null)
		{
			stage3._spawnTimer.Cancel();
		}
		MakeSpinningPortraits();
		GameManager core5 = GM.Core;
		Stage stage4 = core5._stage;
		stage4._tilingTileset.SetAllLayersAlpha(0f);
		List<PickupTeleporter>.Enumerator enumerator2 = default(List<PickupTeleporter>.Enumerator);
		if (enumerator2.MoveNext())
		{
			object obj = 0;
			List<PickupTeleporter>.Enumerator enumerator3 = (List<PickupTeleporter>.Enumerator)(&enumerator2);
			throw new NullReferenceException();
		}
	}

	private unsafe void MakeSpinningPortraits()
	{
		//IL_011f: Expected O, but got I4
		//IL_05f4: Expected O, but got F4
		//IL_019f: Expected I4, but got I8
		//IL_0643: Expected O, but got F4
		//IL_01da: Expected O, but got I4
		//IL_0669: Expected O, but got F4
		//IL_0691: Invalid comparison between F4 and I4
		//IL_0464: Expected I4, but got O
		//IL_04a0: Expected O, but got I4
		//IL_04d0: Expected I4, but got I8
		//IL_0788: Expected O, but got I4
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_059d: Expected O, but got Unknown
		//IL_025e->IL05bb: Incompatible stack heights: 1 vs 0
		//IL_028d->IL05bb: Incompatible stack heights: 1 vs 0
		//IL_0758->IL05bb: Incompatible stack heights: 1 vs 0
		//IL_0369->IL05bb: Incompatible stack heights: 1 vs 0
		//IL_031b->IL05bb: Incompatible stack heights: 1 vs 0
		//IL_038b->IL05bb: Incompatible stack heights: 1 vs 0
		//IL_033d->IL05bb: Incompatible stack heights: 1 vs 0
		//IL_03b2->IL05bb: Incompatible stack heights: 1 vs 0
		//IL_03d4->IL05bb: Incompatible stack heights: 1 vs 0
		//IL_03f1->IL05bb: Incompatible stack heights: 1 vs 0
		//IL_0480->IL05bb: Incompatible stack heights: 1 vs 0
		//IL_044d->IL044d: Incompatible stack heights: 2 vs 1
		//IL_0557->IL05bb: Incompatible stack heights: 1 vs 0
		//IL_0580->IL05bb: Incompatible stack heights: 1 vs 0
		//IL_05b5->IL07bc: Incompatible stack heights: 1 vs 0
		List<PhaserSprite> portraits = _portraits;
		if (_portraits != null)
		{
			int version = portraits._version + 1;
			portraits._version = version;
			portraits._size = 0;
			if (portraits._size > 0)
			{
				Array.Clear(portraits._items, 0, portraits._size);
			}
			List<MultiTargetTween> portraitsTweens = _portraitsTweens;
			if (_portraitsTweens != null)
			{
				int version2 = portraitsTweens._version + 1;
				portraitsTweens._version = version2;
				portraitsTweens._size = 0;
				if (portraitsTweens._size > 0)
				{
					Array.Clear(portraitsTweens._items, 0, portraitsTweens._size);
				}
				float? num = (float?)(object)0;
				Vector2 vector = default(Vector2);
				while (true)
				{
					_003C_003Ec__DisplayClass45_0 CS_0024_003C_003E8__locals18 = new _003C_003Ec__DisplayClass45_0();
					if (CS_0024_003C_003E8__locals18 == null)
					{
						break;
					}
					CS_0024_003C_003E8__locals18._003C_003E4__this = this;
					object obj = UnityEngine.Random.value;
					if ((object)GM.Core == null)
					{
						break;
					}
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene == null)
					{
						break;
					}
					string spriteName = Extensions.PickRnd(_portraitFrames);
					PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, vector, "UI_StageIcons", spriteName);
					if ((object)phaserSprite == null)
					{
						break;
					}
					PhaserSprite phaserSprite2 = phaserSprite.setDepth(-10000);
					object obj2 = UnityEngine.Random.value;
					if ((object)phaserSprite2 == null)
					{
						break;
					}
					float num2 = (float)vector * 0.5f;
					float num3 = num2 + 0.5f;
					PhaserSprite p = phaserSprite2.setScale(num3, (float?)(object)0);
					CS_0024_003C_003E8__locals18.p = p;
					object obj3 = UnityEngine.Random.value;
					bool flag = num3 < 0.5f;
					float num4 = num3 - 0.5f;
					bool flag2 = num4 == 0f;
					bool flag3 = !flag;
					bool flag4 = !flag2;
					bool isLeft = flag4 & flag3;
					CS_0024_003C_003E8__locals18.isLeft = isLeft;
					if ((object)CS_0024_003C_003E8__locals18.p == null)
					{
						break;
					}
					Transform transform = CS_0024_003C_003E8__locals18.p.transform;
					if ((object)transform == null)
					{
						break;
					}
					bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					if (CS_0024_003C_003E8__locals18.isLeft)
					{
						float num5 = -2.56f;
					}
					else
					{
						PhaserScene phaserScene = base.scene;
						if (phaserScene == null)
						{
							break;
						}
						PhaserScene.Renderer renderer = phaserScene._renderer;
						if (phaserScene._renderer == null)
						{
							break;
						}
						float num5 = renderer.width + 2.56f;
					}
					if ((object)CS_0024_003C_003E8__locals18.p == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
					PhaserSprite phaserSprite3 = RenderingExtensions.SetScrollFactor(CS_0024_003C_003E8__locals18.p, 0f);
					if (CS_0024_003C_003E8__locals18.isLeft)
					{
						PhaserScene phaserScene2 = base.scene;
						if (phaserScene2 == null || phaserScene2._renderer == null)
						{
							break;
						}
					}
					else
					{
						PhaserScene phaserScene3 = base.scene;
						if (phaserScene3 == null || phaserScene3._renderer == null)
						{
							break;
						}
						PhaserScene phaserScene4 = base.scene;
						if (phaserScene4 == null || phaserScene4._renderer == null)
						{
							break;
						}
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					if (array == null)
					{
						break;
					}
					if ((object)CS_0024_003C_003E8__locals18.p != null)
					{
						PhaserSprite phaserSprite4 = RenderingExtensions.SetScrollFactor(CS_0024_003C_003E8__locals18.p, 0f);
						bool flag6 = (object)phaserSprite4 == null;
					}
					PhaserSprite phaserSprite5 = RenderingExtensions.SetScrollFactor((PhaserSprite)(object)array, 0f, (byte)(int)CS_0024_003C_003E8__locals18.p != 0);
					if (tweenConfig == null)
					{
						break;
					}
					tweenConfig.targets = array;
					tweenConfig.localX = (float?)(object)1;
					float value = UnityEngine.Random.value;
					float num6 = value * 2000f;
					tweenConfig.repeat = -1;
					float duration = num6 + 5000f;
					tweenConfig.duration = duration;
					if (CS_0024_003C_003E8__locals18.isLeft)
					{
						float num7 = 8f;
					}
					else
					{
						float num7 = -8f;
					}
					tweenConfig.angle = (float?)(object)1;
					tweenConfig.rotateMode = RotateMode.Fast;
					TweenCallback onStart = delegate
					{
						//IL_002b: Expected O, but got Ref
						if (CS_0024_003C_003E8__locals18.isLeft)
						{
						}
						Transform transform2 = CS_0024_003C_003E8__locals18.p.transform;
						object obj4 = default(object);
						transform2.localEulerAngles = (Vector3)(&obj4);
						BackgroundAstral backgroundAstral = CS_0024_003C_003E8__locals18._003C_003E4__this;
						string spriteName2 = Extensions.PickRnd(backgroundAstral._portraitFrames);
						PhaserSprite phaserSprite6 = CS_0024_003C_003E8__locals18.p.setFrame(spriteName2, "UI_StageIcons");
					};
					tweenConfig.onStart = onStart;
					MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
					if (_portraits == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
					if (_portraitsTweens == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
					num = (float?)(object)((_003F?)num + 1);
					if ((nint)num >= 64)
					{
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void StartIntroSequence()
	{
		//IL_00c2: Expected I, but got O
		//IL_0126: Expected O, but got I4
		//IL_018e: Expected O, but got I4
		//IL_0197: Expected O, but got I4
		//IL_0310: Expected O, but got I4
		//IL_0575: Expected I, but got O
		//IL_058b: Expected O, but got I
		//IL_0594: Unknown result type (might be due to invalid IL or missing references)
		//IL_0599: Expected O, but got Unknown
		//IL_039d: Expected I, but got O
		//IL_05bf: Expected O, but got I4
		//IL_05d6: Expected I, but got I8
		//IL_05f5: Expected I, but got O
		//IL_060b: Expected O, but got I
		//IL_0614: Unknown result type (might be due to invalid IL or missing references)
		//IL_0619: Expected O, but got Unknown
		//IL_0386: Expected I, but got I8
		//IL_043c: Expected I, but got O
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected O, but got Unknown
		//IL_0251: Expected I, but got O
		//IL_064d: Expected I, but got I8
		//IL_066c: Expected I, but got O
		//IL_0682: Expected O, but got I
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0690: Expected O, but got Unknown
		//IL_0425: Expected I, but got I8
		//IL_04e0: Expected I, but got O
		//IL_06c4: Expected I, but got I8
		//IL_04b3: Expected I, but got I8
		_003C_003Ec__DisplayClass46_0 obj = new _003C_003Ec__DisplayClass46_0();
		obj._003C_003E4__this = this;
		if (_isPlayingIntroSequence)
		{
			return;
		}
		GameManager core = GM.Core;
		core._003CCanInterrupt_003Ek__BackingField = false;
		GameManager core2 = GM.Core;
		core2._003CCanPause_003Ek__BackingField = false;
		_isPlayingIntroSequence = true;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_carpet != null)
		{
			nint num = (nint)array;
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
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		GameManager core3 = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = core3._characters;
		object[] players = new object[characters._size];
		obj.players = players;
		GameManager core4 = GM.Core;
		object obj3 = 0;
		object obj4 = 0;
		object obj5 = default(object);
		while (true)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = core4._characters;
			if ((nint)obj4 < characters2._size)
			{
				object[] players2 = obj.players;
				GameManager core5 = GM.Core;
				List<VampireSurvivors.Objects.Characters.CharacterController> characters3 = core5._characters;
				if ((nint)obj3 < characters3._size)
				{
					VampireSurvivors.Objects.Characters.CharacterController[] items = characters3._items;
					if ((object)items[obj3] != null)
					{
						nint num2 = (nint)players2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						if (obj5 == null)
						{
							break;
						}
					}
					players2[obj3] = items[obj3];
					obj3++;
					core4 = GM.Core;
					obj4 = obj3;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			tweenConfig2.targets = obj.players;
			tweenConfig2.duration = 32000f;
			tweenConfig2.delay = 500f;
			tweenConfig2.y = (float?)(object)1;
			TweenCallback tweenCallback = null;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v866 @ r10_v2 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass46_0._003CStartIntroSequence_003Eb__0);
			((Delegate)tweenCallback).m_target = obj;
			((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v866 @ r10_v2 (Il2CppMethodInfo)+4C]");
			object obj6 = (nint)0 >> 4;
			object obj7 = obj6 & 1;
			nint num4;
			if (obj7 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v866 @ r10_v2 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num4 = unchecked((nint)6447293664L);
					goto IL_05b6;
				}
			}
			((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
			num4 = ((Delegate)tweenCallback).method_ptr;
			goto IL_05b6;
			IL_06ad:
			TweenCallback tweenCallback2;
			((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
			tweenConfig2.onComplete = tweenCallback2;
			MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
			return;
			IL_0636:
			TweenCallback tweenCallback3;
			((Delegate)tweenCallback3).extra_arg = unchecked((nint)6447293568L);
			tweenConfig2.onStart = tweenCallback3;
			tweenCallback2 = null;
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass46_0._003CStartIntroSequence_003Eb__2);
			((Delegate)tweenCallback2).m_target = obj;
			((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r10_v4 (Il2CppMethodInfo)+4C]");
			object obj8 = (nint)0 >> 4;
			object obj9 = obj8 & 1;
			nint num6;
			if (obj9 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r10_v4 (Il2CppMethodInfo)+52]");
				bool flag = (nint)0 == 0;
				num6 = unchecked((nint)6447293664L);
				if (flag)
				{
					goto IL_06ad;
				}
			}
			num6 = ((Delegate)tweenCallback2).method_ptr;
			((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
			goto IL_06ad;
			IL_05b6:
			object obj10 = 24;
			((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
			tweenConfig2.onUpdate = tweenCallback;
			tweenCallback3 = null;
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1138 @ r10_v3 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback3).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback3).method = (nint)__ldftn(_003C_003Ec__DisplayClass46_0._003CStartIntroSequence_003Eb__1);
			((Delegate)tweenCallback3).m_target = obj;
			((Delegate)tweenCallback3).method_code = (IntPtr)tweenCallback3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1138 @ r10_v3 (Il2CppMethodInfo)+4C]");
			object obj11 = (nint)0 >> 4;
			object obj12 = obj11 & 1;
			nint num8;
			if (obj12 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1138 @ r10_v3 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num8 = unchecked((nint)6447293664L);
					goto IL_0636;
				}
			}
			((Delegate)tweenCallback3).method_code = (IntPtr)((Delegate)tweenCallback3).m_target;
			num8 = ((Delegate)tweenCallback3).method_ptr;
			goto IL_0636;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private unsafe void EnterHand()
	{
		//IL_006a: Expected O, but got Ref
		//IL_0094: Expected O, but got I4
		//IL_01f9: Expected I, but got O
		//IL_024f: Expected O, but got I4
		//IL_0279: Expected O, but got I4
		//IL_02fc: Expected I, but got O
		//IL_0352: Expected O, but got I4
		PhaserScene phaserScene = base.scene;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		Vector2 pos = default(Vector2);
		PhaserSprite component = RenderingExtensions.sprite(s_scene.add, pos, "enemiesM", "hand_pinch_01");
		PhaserSprite phaserSprite = RenderingExtensions.SetScrollFactor(component, 0f);
		Transform transform = phaserSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		PhaserSprite phaserSprite2 = phaserSprite.setDepth(3000f);
		PhaserSprite phaserSprite3 = phaserSprite2.setScale(2f, (float?)(object)0);
		GameObject gameObject = phaserSprite3.gameObject;
		((UnityEngine.Object)gameObject).SetName("Hand");
		_hand = phaserSprite3;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("hand_pinch_", 1, 2, "enemiesM", num);
		PhaserSprite hand = _hand;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		hand._spriteAnimation.AddAnimation("pinch_start", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("hand_pinch_", 3, 4, "enemiesM", num);
		PhaserSprite hand2 = _hand;
		hand2._spriteAnimation.AddAnimation("pinch_do", animationFrames2, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite hand3 = _hand;
		hand3._spriteAnimation.SetAnimation("pinch_start");
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_hand != null)
		{
			nint num2 = (nint)array;
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
		tweenConfig.localY = (float?)(object)1;
		tweenConfig.duration = 2000f;
		tweenConfig.delay = 30000f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete2 = delegate
		{
			//IL_0061: Expected I, but got O
			//IL_00c5: Expected O, but got I4
			//IL_014e: Expected O, but got I4
			//IL_015c: Expected O, but got I4
			//IL_0178: Expected O, but got I4
			PhaserSprite hand4 = _hand;
			hand4._spriteAnimation.SetAnimation("pinch_do");
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			if ((object)_hand != null)
			{
				nint num4 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			tweenConfig3.duration = 1000f;
			tweenConfig3.localY = (float?)(object)1;
			MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
			List<PhaserSprite> portraits = _portraits;
			if (portraits._size > 0)
			{
				TweenConfig tweenConfig4 = new TweenConfig();
				PhaserSprite[] targets = _portraits.ToArray();
				tweenConfig4.targets = targets;
				tweenConfig4.alpha = (float?)(object)1;
				tweenConfig4.scaleX = (float?)(object)1;
				tweenConfig4.duration = 1500f;
				tweenConfig4.scaleY = (float?)(object)1;
				TweenCallback onComplete3 = delegate
				{
					//IL_0202: Expected O, but got I4
					//IL_020b: Expected O, but got I4
					//IL_00c5: Expected O, but got I4
					//IL_00ce: Expected O, but got I4
					//IL_009b: Unknown result type (might be due to invalid IL or missing references)
					//IL_00a0: Expected O, but got Unknown
					//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
					//IL_01b3: Expected O, but got Unknown
					List<MultiTargetTween> portraitsTweens = _portraitsTweens;
					object obj5 = 0;
					object obj6 = 0;
					while (true)
					{
						if ((nint)obj6 >= portraitsTweens._size)
						{
							List<PhaserSprite> portraits2 = _portraits;
							object obj7 = 0;
							object obj8 = 0;
							while (true)
							{
								if ((nint)obj8 >= portraits2._size)
								{
									return;
								}
								List<PhaserSprite> portraits3 = _portraits;
								if ((nint)obj7 >= portraits3._size)
								{
									break;
								}
								PhaserSprite[] items = portraits3._items;
								PhaserSprite phaserSprite4 = items[obj7];
								if ((object)items[obj7] != null && ((UnityEngine.Object)phaserSprite4).m_CachedPtr != (IntPtr)0)
								{
									items[obj7].destroy();
								}
								portraits2 = _portraits;
								obj7++;
								bool flag = _portraits != null;
								obj8 = obj7;
								if (!flag)
								{
									throw new NullReferenceException();
								}
							}
							break;
						}
						List<MultiTargetTween> portraitsTweens2 = _portraitsTweens;
						if ((nint)obj5 >= portraitsTweens2._size)
						{
							break;
						}
						MultiTargetTween[] items2 = portraitsTweens2._items;
						if (items2[obj5] != null)
						{
							items2[obj5].Kill();
						}
						portraitsTweens = _portraitsTweens;
						obj5++;
						obj6 = obj5;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				};
				tweenConfig4.onComplete = onComplete3;
				MultiTargetTween multiTargetTween4 = Tweens.Add(tweenConfig4);
			}
		};
		tweenConfig.onComplete = onComplete2;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_hand != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.duration = 500f;
		tweenConfig2.delay = 33500f;
		MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
	}

	private void FadeInTileset()
	{
		GameManager core = GM.Core;
		Stage stage = core._stage;
		Action onComplete = delegate
		{
			_stopPlayerMovement = false;
			GameManager core2 = GM.Core;
			core2._003CCanInterrupt_003Ek__BackingField = true;
			GameManager core3 = GM.Core;
			core3._003CCanPause_003Ek__BackingField = true;
		};
		stage._tilingTileset.FadeAllLayers(1f, 1500f, onComplete);
	}

	private bool IsIntroSequence()
	{
		//IL_01b3: Expected I4, but got O
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
				if (config._003CCollectedItems_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					bool flag;
					if ((nint)0 == 0)
					{
						flag = false;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj2 = default(object);
						object obj = obj2 - -1;
						bool flag2 = obj == null;
						flag = !flag2;
					}
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null && core2._playerOptions != null)
					{
						PlayerOptionsData config2 = core2._playerOptions.Config;
						if (config2 != null)
						{
							List<ItemType> list2 = config2._003CCollectedItems_003Ek__BackingField;
							if (config2._003CCollectedItems_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
								bool flag3;
								if ((nint)0 == 0)
								{
									flag3 = false;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
									object obj4 = default(object);
									object obj3 = obj4 - -1;
									bool flag4 = obj3 == null;
									flag3 = !flag4;
								}
								if (flag)
								{
									return !flag3;
								}
								return true;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void StartFlipBeats()
	{
		Action onComplete = delegate
		{
			Action onComplete3 = OnBeat;
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			Timer flipInterval = TimerHelper.RegisterMillisUI(800f, onComplete3, null, isLooped: true, useRealTime2, autoDestroyOwner2, repeat2);
			_flipInterval = flipInterval;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		Timer initialTimeout = TimerHelper.RegisterMillisUI(34000f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		_initialTimeout = initialTimeout;
		Action onComplete2 = delegate
		{
			if (_flipInterval != null)
			{
				_flipInterval.Cancel();
			}
		};
		Timer flipClearTimeout = TimerHelper.RegisterMillisUI(75000f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		_flipClearTimeout = flipClearTimeout;
	}

	private void StartBeatsLoop()
	{
		Action onComplete = StartFlipBeats;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		Timer mainInterval = TimerHelper.RegisterMillisUI(83650f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat);
		_mainInterval = mainInterval;
	}

	private void OnBeat()
	{
		if (_isOnBeatComplete)
		{
			_isOnBeatComplete = false;
			HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
			while (enumerator.MoveNext())
			{
				Component component = null;
			}
		}
	}

	private void StopBeat()
	{
		if (_initialTimeout != null)
		{
			_initialTimeout.Cancel();
		}
		if (_flipInterval != null)
		{
			_flipInterval.Cancel();
		}
		if (_flipClearTimeout != null)
		{
			_flipClearTimeout.Cancel();
		}
		if (_mainInterval != null)
		{
			_mainInterval.Cancel();
		}
	}

	private unsafe Color GetColor(float alpha)
	{
		//IL_001c: Expected native int or pointer, but got O
		//IL_0029: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		Color color = default(Color);
		float r = default(float);
		((Color*)(nint)color)->r = r;
		((Color*)(nint)color)->a = alpha;
		return color;
	}

	public unsafe float2 MakeDoor46Event(float2 previousDestination, PickupTeleporter sourceTeleporter)
	{
		//IL_0800: Expected I, but got O
		//IL_0816: Expected O, but got I
		//IL_0832: Expected I, but got O
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_0097: Expected O, but got I8
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_0a48: Expected O, but got I4
		//IL_0a58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5d: Expected O, but got Unknown
		//IL_00b9: Expected I, but got O
		//IL_01a9: Expected I, but got O
		//IL_01b7: Expected I, but got O
		//IL_01c7: Expected O, but got I
		//IL_013c: Expected O, but got I
		//IL_0247: Expected O, but got I4
		//IL_0203: Expected O, but got I
		//IL_0239: Expected O, but got I4
		//IL_0422: Expected I, but got O
		//IL_0430: Expected I, but got O
		//IL_0440: Expected O, but got I
		//IL_03b0: Expected O, but got I4
		//IL_04c0: Expected O, but got I4
		//IL_09e6: Expected I4, but got O
		//IL_09f6: Expected O, but got I
		//IL_047c: Expected O, but got I
		//IL_0320: Expected O, but got I
		//IL_0320: Expected O, but got I
		//IL_04d3: Expected I4, but got O
		//IL_04e3: Expected O, but got I
		//IL_04b2: Expected O, but got I4
		//IL_035a: Expected O, but got I
		//IL_0a27: Expected O, but got I4
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0690: Expected O, but got Unknown
		//IL_052a: Expected O, but got I4
		//IL_0754: Expected O, but got I4
		//IL_05c7: Expected F4, but got O
		//IL_036d->IL036d: Incompatible stack heights: 6 vs 3
		//IL_0787->IL0a35: Incompatible stack heights: 5 vs 1
		//IL_066b->IL066b: Incompatible stack heights: 9 vs 4
		GameManager core = GM.Core;
		bool flag = (object)GM.Core == null;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		Func<SuperObject, bool> predicate = _003C_003Ec._003C_003E9__55_0;
		nint num2 = default(nint);
		if (_003C_003Ec._003C_003E9__55_0 == null)
		{
			Func<SuperObject, bool> func = (_003C_003Ec._003C_003E9__55_0 = delegate(SuperObject o)
			{
				//IL_0144: Expected I4, but got O
				//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e6: Expected Ref, but got Unknown
				//IL_00fd: Expected I8, but got I4
				//IL_010b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0110: Expected Ref, but got Unknown
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3AFD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if ((object)o != null)
				{
					string tiledName = o.m_TiledName;
					if (o.m_TiledName != null)
					{
						object obj18 = "Door46";
						if ((object)o.m_TiledName != "Door46")
						{
							if ("Door46" != null)
							{
								int stringLength = tiledName._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
								if ((nint)stringLength == 0)
								{
									ref byte second = ref *(byte*)("Door46" + 20);
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
			nint num = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rax_v193 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundAstral+<>c>)+B8]");
			object obj = (nint)0 + (nint)8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag2 = (nint)0 == 0;
			num2 = unchecked((nint)null);
			predicate = func;
			if (!flag2)
			{
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = 6603577472L;
				object obj6 = obj3 & 0x3F;
				nint num4;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rbx_v24+462E0+v439 @ rdx_v61*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rbx_v24+462E0+v439 @ rdx_v61*8]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rbx_v24+462E0+v439 @ rdx_v61*8]");
					if (num3 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rbx_v24+462E0+v439 @ rdx_v61*8]");
					num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rbx_v24+462E0+v439 @ rdx_v61*8]");
				}
				while (num4 != 0);
				num2 = unchecked((nint)null);
				predicate = func;
			}
		}
		object obj9 = Enumerable.FirstOrDefault(tilingTileset.SavedScripts, (Func<object, bool>)predicate);
		Vector3 ret;
		bool flag6;
		Pickup pickup2;
		float2 float5 = default(float2);
		nint num5;
		object obj12;
		Pickup pickup;
		if (obj9 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ rax_v15 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				Transform transform = ((Component)obj9).transform;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
				bool flag4 = (object)GM.Core == null;
				if (!GM.Core.IsStageHost)
				{
					bool flag5 = NetworkItems.IsNetworkItem(ItemType.COFFIN);
					flag6 = false;
					pickup = (Pickup)num2;
					if (flag5)
					{
						goto IL_0197;
					}
				}
				pickup2 = PickupManager.CreatePickup(float5, ItemType.COFFIN);
				bool flag7 = (object)pickup2 != null;
				flag6 = true;
				pickup = pickup2;
				if (!flag7)
				{
					goto IL_0197;
				}
				num5 = (nint)pickup2;
				nint num6 = (nint)typeof(PickupCoffin);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1246 @ rdx_v44 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCoffin>)+130]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1245 @ r8_v37 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1246 @ rdx_v44 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCoffin>)+130]");
				if (num7 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1245 @ r8_v37 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1352 @ rax_v139+FFFFFFF8+v1247 @ rax_v134*8]");
					if (0 == (nint)typeof(PickupCoffin))
					{
						obj12 = 1;
						goto IL_0929;
					}
				}
				obj12 = 0;
				goto IL_0929;
			}
		}
		goto IL_0a35;
		IL_09c9:
		object obj13;
		bool flag8 = obj13 == null;
		ItemType itemType = (ItemType)typeof(PickupTeleporter);
		Pickup pickup4;
		Pickup pickup3 = pickup4;
		nint num8;
		pickup = (Pickup)num8;
		Pickup pickup5 = null;
		if (!flag8)
		{
			itemType = (ItemType)typeof(PickupTeleporter);
			pickup3 = pickup4;
			pickup = (Pickup)num8;
			pickup5 = pickup4;
		}
		goto IL_09ba;
		IL_0929:
		bool flag9 = obj12 == null;
		flag6 = (byte)num5 != 0;
		pickup = pickup2;
		Pickup pickup6 = null;
		if (!flag9)
		{
			flag6 = (byte)num5 != 0;
			pickup = pickup2;
			pickup6 = pickup2;
		}
		goto IL_091a;
		IL_0197:
		pickup6 = null;
		goto IL_091a;
		IL_0a35:
		return float5;
		IL_09ba:
		secretDoor = (PickupTeleporter)pickup5;
		PickupTeleporter pickupTeleporter = secretDoor;
		bool flag10 = (object)secretDoor == null;
		Action action = (Action)itemType;
		if (!flag10)
		{
			bool flag11 = ((UnityEngine.Object)pickupTeleporter).m_CachedPtr == (IntPtr)0;
			action = (Action)itemType;
			if (!flag11)
			{
				PickupTeleporter pickupTeleporter2 = secretDoor;
				bool flag12 = (object)secretDoor == null;
				pickupTeleporter2._003CIsAstralSecretDoor_003Ek__BackingField = true;
				bool flag13 = (object)secretDoor == null;
				secretDoor.LinkTo(sourceTeleporter);
				PickupTeleporter pickupTeleporter3 = secretDoor;
				bool flag14 = (object)secretDoor == null;
				pickupTeleporter3._destinationX = (float)previousDestination;
				float destinationY = default(float);
				pickupTeleporter3._destinationY = destinationY;
				Action<VampireSurvivors.Objects.Characters.CharacterController> value = OnReturnStarted;
				bool flag15 = (object)secretDoor == null;
				secretDoor.OnTeleportStartedAction += value;
				Action action2 = OnSecretFinished;
				bool flag16 = (object)secretDoor == null;
				secretDoor.OnTeleportFinishedAction += action2;
				action = action2;
				pickup3 = null;
				pickup = null;
			}
		}
		float num9 = (float)ret / 0.01f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj15 = default(object);
		object obj14 = obj15 ^ 0;
		float num10 = (float)obj14 / 0.01f;
		bool flag17 = (object)GM.Core == null;
		float xMax = num9 + 300f;
		float yMin = num10 - 300f;
		float xMin = num9 - 300f;
		float num11 = default(float);
		bool skipInverseCalculation = default(bool);
		GM.Core.SetHardBoundsMinMax(xMin, yMin, xMax, num11, skipInverseCalculation);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
		BgmType bgmType = default(BgmType);
		SoundManager.FadeMusic(bgmType, 0f, 500f);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Wind, new SoundManager.SoundConfig
		{
			Rate = 1f,
			Volume = (float?)(object)1,
			Loop = true
		}, 0f, 10, num11);
		goto IL_0a35;
		IL_0410:
		pickup5 = null;
		goto IL_09ba;
		IL_091a:
		secretCoffin = (PickupCoffin)pickup6;
		Transform transform2 = (Transform)(object)secretCoffin;
		if ((object)secretCoffin != null && ((UnityEngine.Object)transform2).m_CachedPtr != (IntPtr)0)
		{
			bool flag18 = (object)secretCoffin == null;
			secretCoffin.SetChar(CharacterType.ROSE);
			Transform transform3 = (Transform)(object)secretCoffin;
			bool flag19 = (object)secretCoffin == null;
			secretCoffin.SetFrame("CoffinW");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181470E50");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1057 @ rdi_v19 (UnityEngine.Transform)+218]");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1057 @ rdi_v19 (UnityEngine.Transform)+C8]");
			Sprite sprite = SpriteManager.GetSprite((string)num12, (string)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1057 @ rdi_v19 (UnityEngine.Transform)+1E8]");
			bool flag20 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1057 @ rdi_v19 (UnityEngine.Transform)+1E8]");
			((SpriteRenderer)0).sprite = sprite;
			flag6 = false;
			pickup = null;
		}
		bool flag21 = (object)GM.Core == null;
		if (!GM.Core.IsStageHost)
		{
			bool flag22 = NetworkItems.IsNetworkItem(ItemType.TELEPORTER);
			itemType = ItemType.VOID;
			pickup3 = (Pickup)flag6;
			if (flag22)
			{
				goto IL_0410;
			}
		}
		pickup4 = PickupManager.CreatePickup(float5, ItemType.TELEPORTER);
		bool flag23 = (object)pickup4 != null;
		itemType = ItemType.TELEPORTER;
		pickup3 = pickup4;
		pickup = null;
		if (!flag23)
		{
			goto IL_0410;
		}
		num8 = (nint)pickup4;
		nint num13 = (nint)typeof(PickupTeleporter);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1948 @ rdx_v32 (Il2CppClass<VampireSurvivors.Objects.Items.PickupTeleporter>)+130]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1947 @ r9_v18 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1948 @ rdx_v32 (Il2CppClass<VampireSurvivors.Objects.Items.PickupTeleporter>)+130]");
		if (num14 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1947 @ r9_v18 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2017 @ rax_v91+FFFFFFF8+v1949 @ rax_v86*8]");
			if (0 == (nint)typeof(PickupTeleporter))
			{
				obj13 = 1;
				goto IL_09c9;
			}
		}
		obj13 = 0;
		goto IL_09c9;
	}

	public override void CustomPreload(Action onComplete)
	{
		//IL_006f: Expected I, but got O
		AsyncLoader asyncLoader = new AsyncLoader(onComplete);
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			List<string> texturesForCharacterType = CharacterLoader.GetTexturesForCharacterType(CharacterType.ROSE, core._playerOptions, core._dataManager);
			if (texturesForCharacterType != null)
			{
				List<string>.Enumerator enumerator = default(List<string>.Enumerator);
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass56_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass56_0();
					bool flag = CS_0024_003C_003E8__locals3 == null;
					nint num = (nint)typeof(_003C_003Ec__DisplayClass56_0);
					if (!flag)
					{
						CS_0024_003C_003E8__locals3.texture = null;
						Action<Action> loadCall = delegate(Action cb)
						{
							//IL_0029: Expected I4, but got O
							_003C_003Ec__DisplayClass56_1 obj = new _003C_003Ec__DisplayClass56_1();
							obj.cb = cb;
							Action<bool> action = null;
							((_003C_003Ec__DisplayClass56_1)(object)action)._003CCustomPreload_003Eb__3((byte)(int)obj != 0);
							GameManager core2 = GM.Core;
							string customCacheGroup = default(string);
							CharacterLoader.LoadCharacterTextureAsync(CS_0024_003C_003E8__locals3.texture, CharacterType.ROSE, action, core2._dataManager, customCacheGroup);
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
				Action<Action> loadCall2 = _003C_003Ec._003C_003E9__56_0;
				if (_003C_003Ec._003C_003E9__56_0 == null)
				{
					loadCall2 = (_003C_003Ec._003C_003E9__56_0 = delegate(Action cb)
					{
						//IL_001d: Expected O, but got I4
						AudioLoader.LoadSFXAsync(SfxType.Wind, "SFX", (DlcType?)(object)0, cb);
					});
				}
				if (asyncLoader != null)
				{
					asyncLoader.Add(loadCall2);
					Action<Action> loadCall3 = _003C_003Ec._003C_003E9__56_1;
					if (_003C_003Ec._003C_003E9__56_1 == null)
					{
						loadCall3 = (_003C_003Ec._003C_003E9__56_1 = delegate(Action cb)
						{
							//IL_0029: Expected I4, but got O
							//IL_0046: Expected O, but got I4
							_003C_003Ec__DisplayClass56_2 obj = new _003C_003Ec__DisplayClass56_2();
							obj.cb = cb;
							Action<bool> action = null;
							((_003C_003Ec__DisplayClass56_2)(object)action)._003CCustomPreload_003Eb__4((byte)(int)obj != 0);
							SpriteLoader.LoadTextureAsync("UI_StageIcons", "Gameplay", (DlcType?)(object)0, action);
						});
					}
					asyncLoader.Add(loadCall3);
					asyncLoader.Load();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void OnSecretFinished()
	{
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Expected O, but got Unknown
		SoundManager.StopSound(SfxType.Wind);
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				List<CharacterType> list = config._003COpenedCoffins_003Ek__BackingField;
				if (config._003COpenedCoffins_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rcx_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj = default(object);
						if ((nint)obj != -1)
						{
							GameManager core2 = GM.Core;
							if ((object)GM.Core != null)
							{
								PlayerOptions playerOptions = core2._playerOptions;
								if (core2._playerOptions != null)
								{
									bool flag = core2._playerOptions.UnlockSecret(SecretType.PrincessShadow, playerOptions._mainGameConfig);
									goto IL_017d;
								}
							}
							goto IL_034f;
						}
					}
					goto IL_017d;
				}
			}
		}
		goto IL_034f;
		IL_0443:
		throw new InvalidCastException();
		IL_034f:
		NullReferenceException ex = new NullReferenceException();
		goto IL_0443;
		IL_0387:
		PickupCoffin pickupCoffin = secretCoffin;
		if ((object)secretCoffin != null && ((UnityEngine.Object)pickupCoffin).m_CachedPtr != (IntPtr)0)
		{
			if ((object)secretCoffin != null)
			{
				secretCoffin.DisposeAsTaken();
				return;
			}
			goto IL_034f;
		}
		return;
		IL_017d:
		PickupTeleporter pickupTeleporter = secretDoor;
		if ((object)secretDoor == null || ((UnityEngine.Object)pickupTeleporter).m_CachedPtr == (IntPtr)0)
		{
			goto IL_0387;
		}
		PickupTeleporter pickupTeleporter2 = secretDoor;
		Action value = OnSecretFinished;
		if ((object)secretDoor == null)
		{
			goto IL_034f;
		}
		Delegate obj2 = pickupTeleporter2.OnTeleportFinishedAction;
		object obj3 = secretDoor + 552;
		while (true)
		{
			Delegate obj4 = Delegate.Remove(obj2, value);
			bool flag2 = (object)obj4 == null;
			Delegate obj5 = null;
			if (!flag2)
			{
				bool flag3 = (object)obj4.GetType() != typeof(Action);
				obj5 = null;
				if (!flag3)
				{
					obj5 = obj4;
				}
				if ((object)obj5 == null)
				{
					break;
				}
			}
			bool flag4 = obj2 == obj3;
			Delegate obj6;
			if (obj2 == obj3)
			{
				obj3 = obj5;
				obj6 = obj2;
			}
			else
			{
				obj6 = (Delegate)obj3;
			}
			Delegate obj7 = obj2;
			if (!flag4)
			{
				obj7 = obj6;
			}
			bool flag5 = (object)obj7 != obj2;
			obj2 = obj7;
			if (flag5)
			{
				continue;
			}
			goto IL_02c0;
		}
		goto IL_0443;
		IL_02c0:
		if ((object)secretDoor == null)
		{
			goto IL_034f;
		}
		secretDoor.DisposeAsTaken();
		goto IL_0387;
	}

	public void OnReturnStarted(VampireSurvivors.Objects.Characters.CharacterController playerTeleported)
	{
		//IL_0085: Expected O, but got I4
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_00f9: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CSelectedOnlineFreeRoam_003Ek__BackingField && !playerTeleported._coherenceSync.HasStateAuthority)
		{
			return;
		}
		GameManager core2 = GM.Core;
		core2._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
		PickupTeleporter pickupTeleporter = secretDoor;
		if ((object)secretDoor != null && ((UnityEngine.Object)pickupTeleporter).m_CachedPtr != (IntPtr)0)
		{
			PickupTeleporter pickupTeleporter2 = secretDoor;
			Action<VampireSurvivors.Objects.Characters.CharacterController> value = OnReturnStarted;
			Delegate obj = pickupTeleporter2.OnTeleportStartedAction;
			object obj2 = pickupTeleporter2 + 544;
			object obj5 = default(object);
			bool flag3;
			do
			{
				Delegate obj3 = Delegate.Remove(obj, value);
				object obj4;
				if ((object)obj3 == null)
				{
					obj4 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = obj5 == null;
					obj4 = obj5;
					if (flag)
					{
						throw new InvalidCastException();
					}
				}
				bool flag2 = obj == obj2;
				Delegate obj6;
				if (obj == obj2)
				{
					obj2 = obj4;
					obj6 = obj;
				}
				else
				{
					obj6 = (Delegate)obj2;
				}
				Delegate obj7 = obj;
				if (!flag2)
				{
					obj7 = obj6;
				}
				flag3 = (object)obj7 != obj;
				obj = obj7;
			}
			while (flag3);
		}
		GameManager core3 = GM.Core;
		PlayerOptions playerOptions = core3._playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, mainGameConfig._003CMusicVolume_003Ek__BackingField, 500f);
	}

	private unsafe void MakePizza()
	{
		//IL_033f: Expected I, but got O
		//IL_0355: Expected O, but got I
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_012f: Expected O, but got I8
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0455: Expected O, but got I4
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_046a: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected F4, but got Unknown
		//IL_029a: Expected F4, but got O
		//IL_04bb->IL02c5: Incompatible stack heights: 1 vs 0
		//IL_01dc->IL02c5: Incompatible stack heights: 1 vs 0
		//IL_021d->IL02c5: Incompatible stack heights: 1 vs 0
		//IL_025f->IL02c5: Incompatible stack heights: 1 vs 0
		//IL_0447->IL03f7: Incompatible stack heights: 2 vs 1
		if ((object)GM.Core != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController playerOne = GM.Core.PlayerOne;
			if ((object)playerOne != null)
			{
				float2 position = playerOne.position;
				if ((object)GM.Core != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController playerOne2 = GM.Core.PlayerOne;
					if ((object)playerOne2 != null)
					{
						float2 position2 = playerOne2.position;
						object obj = default(object);
						float y = (float)obj + 2f;
						GameManager core = GM.Core;
						Stage stage = core._stage;
						TilingTileset tilingTileset = stage._tilingTileset;
						bool flag = (object)stage._tilingTileset == null;
						Func<SuperObject, bool> predicate = _003C_003Ec._003C_003E9__59_0;
						if (_003C_003Ec._003C_003E9__59_0 == null)
						{
							Func<SuperObject, bool> func = (_003C_003Ec._003C_003E9__59_0 = delegate(SuperObject o)
							{
								//IL_0144: Expected I4, but got O
								//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
								//IL_00e6: Expected Ref, but got Unknown
								//IL_00fd: Expected I8, but got I4
								//IL_010b: Unknown result type (might be due to invalid IL or missing references)
								//IL_0110: Expected Ref, but got Unknown
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3B00]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if ((object)o != null)
								{
									string tiledName = o.m_TiledName;
									if (o.m_TiledName != null)
									{
										object obj11 = "ASTRALSTAIR_PIZZA";
										if ((object)o.m_TiledName != "ASTRALSTAIR_PIZZA")
										{
											if ("ASTRALSTAIR_PIZZA" != null)
											{
												int stringLength = tiledName._stringLength;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
												if ((nint)stringLength == 0)
												{
													ref byte second = ref *(byte*)("ASTRALSTAIR_PIZZA" + 20);
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
							nint num = (nint)typeof(_003C_003Ec);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ rax_v72 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundAstral+<>c>)+B8]");
							object obj2 = (nint)0 + (nint)32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
							bool flag2 = (nint)0 == 0;
							predicate = func;
							if (!flag2)
							{
								object obj3 = obj2 >> 12;
								object obj4 = obj3 & 0x1FFFFF;
								object obj5 = obj4 >> 6;
								object obj6 = 6603577472L;
								object obj7 = obj4 & 0x3F;
								nint num3;
								do
								{
									object obj8 = 1 << (int)obj7;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rbx_v13+462E0+v687 @ rdx_v29*8]");
									object obj9 = 0 | obj8;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rbx_v13+462E0+v687 @ rdx_v29*8]");
									nint num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rbx_v13+462E0+v687 @ rdx_v29*8]");
									if (num2 == 0)
									{
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rbx_v13+462E0+v687 @ rdx_v29*8]");
									num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rbx_v13+462E0+v687 @ rdx_v29*8]");
								}
								while (num3 != 0);
								predicate = func;
							}
						}
						object obj10 = Enumerable.FirstOrDefault(tilingTileset.SavedScripts, (Func<object, bool>)predicate);
						bool flag3 = obj10 == null;
						float2 float5 = position;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v716 @ rax_v29 (System.Object)+10]");
							bool flag4 = (nint)0 == 0;
							float5 = position;
							if (!flag4)
							{
								Transform transform = ((Component)obj10).transform;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v53 (UnityEngine.Transform)+10]");
								bool flag5 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v53 (UnityEngine.Transform)+10]");
								float2 ret;
								Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
								float num4 = default(float);
								y = num4;
								float5 = ret;
							}
						}
						PhaserScene phaserScene = base.scene;
						if (phaserScene != null)
						{
							PhaserScene.Renderer renderer = phaserScene._renderer;
							if (phaserScene._renderer != null)
							{
								float height = renderer.height;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
								float depth = height ^ 0;
								PhaserScene phaserScene2 = base.scene;
								if (phaserScene2 != null)
								{
									Vector2 pos = default(Vector2);
									PhaserSprite phaserSprite = RenderingExtensions.sprite(phaserScene2.add, pos, "items", "PizzaTime");
									if ((object)phaserSprite != null)
									{
										PhaserSprite pizzaASprite = phaserSprite.setDepth(depth);
										_pizzaASprite = pizzaASprite;
										_pizzaA = new Circle
										{
											_x = (float)float5,
											_y = y,
											_radius = 0.16f
										};
										return;
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

	private unsafe void CheckPizzas()
	{
		//IL_003d: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (_canPizza && _pizzaA != null && enumerator.MoveNext())
		{
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private void AnimPizza()
	{
		//IL_0175: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_00dd: Expected O, but got I4
		//IL_0115: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Bumper, soundConfig, 100f, 4, time);
		PhaserSprite phaserSprite = _pizzaASprite.setAlpha(0.65f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_pizzaASprite != null)
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
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.ease = Ease.InOutBounce;
		tweenConfig.yoyo = false;
		tweenConfig.duration = 1000f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			_pizzaASprite.destroy();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void RestorePlayersCharmStat()
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		if (_cachedPlayerCharm == null)
		{
			return;
		}
		int[] cachedPlayerCharm = _cachedPlayerCharm;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < cachedPlayerCharm.Length)
			{
				GameManager core = GM.Core;
				List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
				if ((nint)obj >= characters._size)
				{
					break;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = characters._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController = items[obj];
				int[] cachedPlayerCharm2 = _cachedPlayerCharm;
				PlayerModifierStats playerStats = characterController._playerStats;
				object obj3 = obj + 1;
				playerStats._003CCharm_003Ek__BackingField = cachedPlayerCharm2[obj];
				cachedPlayerCharm = _cachedPlayerCharm;
				obj = obj3;
				obj2 = obj3;
				continue;
			}
			_cachedPlayerCharm = null;
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void EnableMovingBackground()
	{
		//IL_00a2: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		_speedFactor = 1.1f;
		GameManager core = GM.Core;
		TilingBackground bgMan = core._bgMan;
		bgMan._canScroll = true;
		GameManager core2 = GM.Core;
		TilingBackground bgMan2 = core2._bgMan;
		Transform transform = bgMan2._bgtile.transform;
		GameManager core3 = GM.Core;
		Transform parent = core3._bgMan.transform;
		transform.SetParent(parent, worldPositionStays: true);
		List<PhaserSprite> portraits = _portraits;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < portraits._size)
			{
				List<PhaserSprite> portraits2 = _portraits;
				if ((nint)obj >= portraits2._size)
				{
					break;
				}
				PhaserSprite[] items = portraits2._items;
				PhaserSprite phaserSprite = items[obj];
				if ((object)items[obj] != null && ((UnityEngine.Object)phaserSprite).m_CachedPtr != (IntPtr)0)
				{
					PhaserSprite phaserSprite2 = items[obj].setVisible(visible: true);
				}
				portraits = _portraits;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void DisableMovingBackground()
	{
		//IL_00bb: Expected F4, but got I4
		//IL_00c5: Expected F4, but got I4
		//IL_01fc: Invalid comparison between F4 and I4
		//IL_00e6: Invalid comparison between F4 and I4
		_speedFactor = 0f;
		GameManager core = GM.Core;
		TilingBackground bgMan = core._bgMan;
		bgMan._canScroll = false;
		GameManager core2 = GM.Core;
		TilingBackground bgMan2 = core2._bgMan;
		Transform transform = bgMan2._bgtile.transform;
		Camera main = Camera.main;
		Transform parent = main.transform;
		transform.SetParent(parent, worldPositionStays: true);
		if (_portraits == null)
		{
			return;
		}
		List<PhaserSprite> portraits = _portraits;
		float num = 0f;
		float num2 = 0f;
		while (true)
		{
			if (num2 < (float)portraits._size)
			{
				List<PhaserSprite> portraits2 = _portraits;
				if (!(num < (float)portraits2._size))
				{
					break;
				}
				PhaserSprite[] items = portraits2._items;
				PhaserSprite phaserSprite = items[num];
				if ((object)items[num] != null && ((UnityEngine.Object)phaserSprite).m_CachedPtr != (IntPtr)0)
				{
					PhaserSprite phaserSprite2 = items[num].setVisible(visible: false);
				}
				portraits = _portraits;
				num++;
				num2 = num;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public BackgroundAstral()
	{
		List<PhaserSprite> portraits = new List<PhaserSprite>();
		_portraits = portraits;
		_portraitsTweens = new List<MultiTargetTween>();
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"stage_forest.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"stage_batcountry.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"stage_bone.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"stage_bridge.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"stage_chapel.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"stage_foscari.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"stage_foscari2.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"stage_green.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items9 = list._items;
		if (list._size >= items9.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"stage_library.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items10 = list._items;
		if (list._size >= items10.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"stage_machine.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items11 = list._items;
		if (list._size >= items11.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"stage_molise.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items12 = list._items;
		if (list._size >= items12.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"stage_moonspell.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items13 = list._items;
		if (list._size >= items13.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"stage_rash.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items14 = list._items;
		if (list._size >= items14.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"stage_tower.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items15 = list._items;
		if (list._size >= items15.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"stage_x.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items16 = list._items;
		if (list._size >= items16.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"stage_water.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_portraitFrames = list;
		base._002Ector();
	}

	private void _003CCheckHalfMinute_003Eb__41_0()
	{
		if (_trisection != null)
		{
			_trisection.Spinnn();
		}
	}

	private void _003CEnterHand_003Eb__47_0()
	{
		//IL_0061: Expected I, but got O
		//IL_00c5: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_015c: Expected O, but got I4
		//IL_0178: Expected O, but got I4
		PhaserSprite hand = _hand;
		hand._spriteAnimation.SetAnimation("pinch_do");
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_hand != null)
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
		tweenConfig.duration = 1000f;
		tweenConfig.localY = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		List<PhaserSprite> portraits = _portraits;
		if (portraits._size <= 0)
		{
			return;
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		PhaserSprite[] targets = _portraits.ToArray();
		tweenConfig2.targets = targets;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.scaleX = (float?)(object)1;
		tweenConfig2.duration = 1500f;
		tweenConfig2.scaleY = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_0202: Expected O, but got I4
			//IL_020b: Expected O, but got I4
			//IL_00c5: Expected O, but got I4
			//IL_00ce: Expected O, but got I4
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Expected O, but got Unknown
			List<MultiTargetTween> portraitsTweens = _portraitsTweens;
			object obj2 = 0;
			object obj3 = 0;
			while (true)
			{
				if ((nint)obj3 >= portraitsTweens._size)
				{
					List<PhaserSprite> portraits2 = _portraits;
					object obj4 = 0;
					object obj5 = 0;
					while (true)
					{
						if ((nint)obj5 >= portraits2._size)
						{
							return;
						}
						List<PhaserSprite> portraits3 = _portraits;
						if ((nint)obj4 >= portraits3._size)
						{
							break;
						}
						PhaserSprite[] items = portraits3._items;
						PhaserSprite phaserSprite = items[obj4];
						if ((object)items[obj4] != null && ((UnityEngine.Object)phaserSprite).m_CachedPtr != (IntPtr)0)
						{
							items[obj4].destroy();
						}
						portraits2 = _portraits;
						obj4++;
						bool flag = _portraits != null;
						obj5 = obj4;
						if (!flag)
						{
							throw new NullReferenceException();
						}
					}
					break;
				}
				List<MultiTargetTween> portraitsTweens2 = _portraitsTweens;
				if ((nint)obj2 >= portraitsTweens2._size)
				{
					break;
				}
				MultiTargetTween[] items2 = portraitsTweens2._items;
				if (items2[obj2] != null)
				{
					items2[obj2].Kill();
				}
				portraitsTweens = _portraitsTweens;
				obj2++;
				obj3 = obj2;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		};
		tweenConfig2.onComplete = onComplete;
		MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
	}

	private void _003CEnterHand_003Eb__47_1()
	{
		//IL_0202: Expected O, but got I4
		//IL_020b: Expected O, but got I4
		//IL_00c5: Expected O, but got I4
		//IL_00ce: Expected O, but got I4
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		List<MultiTargetTween> portraitsTweens = _portraitsTweens;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < portraitsTweens._size)
			{
				List<MultiTargetTween> portraitsTweens2 = _portraitsTweens;
				if ((nint)obj >= portraitsTweens2._size)
				{
					break;
				}
				MultiTargetTween[] items = portraitsTweens2._items;
				if (items[obj] != null)
				{
					items[obj].Kill();
				}
				portraitsTweens = _portraitsTweens;
				obj++;
				obj2 = obj;
				continue;
			}
			List<PhaserSprite> portraits = _portraits;
			object obj3 = 0;
			object obj4 = 0;
			while (true)
			{
				if ((nint)obj4 < portraits._size)
				{
					List<PhaserSprite> portraits2 = _portraits;
					if ((nint)obj3 >= portraits2._size)
					{
						break;
					}
					PhaserSprite[] items2 = portraits2._items;
					PhaserSprite phaserSprite = items2[obj3];
					if ((object)items2[obj3] != null && ((UnityEngine.Object)phaserSprite).m_CachedPtr != (IntPtr)0)
					{
						items2[obj3].destroy();
					}
					portraits = _portraits;
					obj3++;
					bool flag = _portraits != null;
					obj4 = obj3;
					if (!flag)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				return;
			}
			break;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void _003CFadeInTileset_003Eb__48_0()
	{
		_stopPlayerMovement = false;
		GameManager core = GM.Core;
		core._003CCanInterrupt_003Ek__BackingField = true;
		GameManager core2 = GM.Core;
		core2._003CCanPause_003Ek__BackingField = true;
	}

	private void _003CStartFlipBeats_003Eg__StartFlipInterval_007C50_0()
	{
		Action onComplete = OnBeat;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		Timer flipInterval = TimerHelper.RegisterMillisUI(800f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat);
		_flipInterval = flipInterval;
	}

	private void _003CStartFlipBeats_003Eb__50_1()
	{
		if (_flipInterval != null)
		{
			_flipInterval.Cancel();
		}
	}

	private void _003CAnimPizza_003Eb__61_0()
	{
		_pizzaASprite.destroy();
	}
}
