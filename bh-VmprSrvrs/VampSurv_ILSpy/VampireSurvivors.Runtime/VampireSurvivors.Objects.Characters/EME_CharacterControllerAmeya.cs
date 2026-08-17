using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters;

public class EME_CharacterControllerAmeya : EME_CharacterControllerShowstopper
{
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public Pickup_EME_Cat spawnedCat;

		public EME_CharacterControllerAmeya _003C_003E4__this;

		internal void _003CSpawnCatsInsideBounds_003Eb__0()
		{
			EME_CharacterControllerAmeya eME_CharacterControllerAmeya = _003C_003E4__this;
			PhysicsGroup catsPhysicsGroup = eME_CharacterControllerAmeya._catsPhysicsGroup;
			if (((HashSet<object>)(object)((Group)catsPhysicsGroup).children).Contains((object)spawnedCat))
			{
				EME_CharacterControllerAmeya eME_CharacterControllerAmeya2 = _003C_003E4__this;
				eME_CharacterControllerAmeya2._catsPhysicsGroup.remove(spawnedCat);
				EME_CharacterControllerAmeya eME_CharacterControllerAmeya3 = _003C_003E4__this;
				eME_CharacterControllerAmeya3._catsPhysicsGroup.UpdateHashSetElements();
			}
		}

		internal void _003CSpawnCatsInsideBounds_003Eb__1()
		{
			EME_CharacterControllerAmeya eME_CharacterControllerAmeya = _003C_003E4__this;
			PhysicsGroup catsPhysicsGroup = eME_CharacterControllerAmeya._catsPhysicsGroup;
			if (((HashSet<object>)(object)((Group)catsPhysicsGroup).children).Contains((object)spawnedCat))
			{
				EME_CharacterControllerAmeya eME_CharacterControllerAmeya2 = _003C_003E4__this;
				eME_CharacterControllerAmeya2._catsPhysicsGroup.remove(spawnedCat);
				EME_CharacterControllerAmeya eME_CharacterControllerAmeya3 = _003C_003E4__this;
				eME_CharacterControllerAmeya3._catsPhysicsGroup.UpdateHashSetElements();
			}
		}
	}

	private float _catSpawnInterval = 5f;

	private float _catsPerSpawn = 1f;

	private float _rainbowCatSpawnChance;

	private Vector2 _spawnRectangleSize;

	private bool _allowCatSpawnsInCameraView;

	private PhysicsGroup _catsPhysicsGroup;

	private Camera _mainCamera;

	private readonly List<GameObject> _cachedCats;

	private const int MaxActiveCats = 20;

	public unsafe override void AfterFullInitialization()
	{
		//IL_057e: Expected I, but got O
		//IL_00e4: Expected I, but got O
		//IL_011f: Expected I, but got O
		//IL_0169: Expected I, but got O
		//IL_05f4: Expected I, but got O
		//IL_01eb: Expected I, but got O
		//IL_0202: Expected I, but got O
		//IL_04ab: Expected I, but got O
		//IL_0230: Expected O, but got I
		//IL_04d6: Expected I4, but got O
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Expected O, but got Unknown
		//IL_0283: Expected I, but got O
		//IL_0293: Expected O, but got I
		//IL_02a3: Expected O, but got I
		//IL_0629: Expected I, but got O
		//IL_02ef: Expected I, but got O
		//IL_066d: Expected O, but got I4
		//IL_066d: Expected O, but got I4
		//IL_066d: Expected O, but got I4
		//IL_032b: Expected O, but got I4
		//IL_032b: Expected O, but got I4
		//IL_032b: Expected O, but got I4
		//IL_0342: Expected I, but got O
		//IL_0381: Expected I, but got O
		//IL_039d: Expected O, but got I4
		//IL_078d: Expected I, but got O
		//IL_071a: Expected I, but got O
		base.AfterFullInitialization();
		Camera main = Camera.main;
		_mainCamera = main;
		Action onComplete = SpawnCats;
		float num = _catSpawnInterval * 1000f;
		float duration = num * 0.001f;
		bool flag = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num2 = default(int);
		TimerType timerType = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: true, flag, monoBehaviour, num2, timerType, isOnlineTimer: false, canPause: false);
		nint num3 = (nint)typeof(ArcadePhysics);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v10 (Il2CppClass<ArcadePhysics>)+B8]");
		nint num4 = 0;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		if (ArcadePhysics.s_scene != null)
		{
			Factory add = s_scene.add;
			if (s_scene.add != null)
			{
				PhysicsGroup physicsGroup = (PhysicsGroup)new Group(600);
				((Group)physicsGroup)._002Ector(600);
				physicsGroup._physicsType = PhysicsType.DYNAMIC_BODY;
				bool flag2 = add._world == null;
				num4 = (nint)add._world;
				if (!flag2)
				{
					RBush rBush = add._world.addGroupTree(physicsGroup);
					_catsPhysicsGroup = physicsGroup;
					num4 = (nint)add._world;
					PhysicsGroup catsPhysicsGroup = _catsPhysicsGroup;
					if (_catsPhysicsGroup != null)
					{
						catsPhysicsGroup._physicsType = PhysicsType.DYNAMIC_BODY;
						nint num5 = (nint)typeof(GM);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v900 @ rax_v31 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
						nint num6 = 0;
						GameManager core = GM.Core;
						bool flag3 = (object)GM.Core == null;
						num4 = num6;
						if (!flag3)
						{
							Stage stage = core._stage;
							bool flag4 = (object)core._stage == null;
							num4 = (nint)typeof(UnityEngine.Object);
							if (!flag4)
							{
								bool flag5 = ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0;
								num4 = (nint)typeof(UnityEngine.Object);
								if (!flag5)
								{
									num4 = (nint)GM.Core;
									if ((object)GM.Core != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rcx_v50 (Il2CppStaticFields<ArcadePhysics>)+B8]");
										object obj = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rcx_v50 (Il2CppStaticFields<ArcadePhysics>)+B8]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rax_v49+88]");
											if ((nint)0 == 0)
											{
												goto IL_0470;
											}
											num4 = (nint)GM.Core;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rcx_v50 (Il2CppStaticFields<ArcadePhysics>)+B8]");
											object obj2 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v51+208]");
											object obj3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v51+208]");
											if ((nint)0 != 0)
											{
												PhaserScene s_scene2 = ArcadePhysics.s_scene;
												bool flag6 = ArcadePhysics.s_scene == null;
												num4 = (nint)typeof(ArcadePhysics);
												if (!flag6)
												{
													bool flag7 = (object)s_scene2.physics == null;
													num4 = (nint)typeof(ArcadePhysics);
													if (!flag7)
													{
														ArcadePhysicsCallback arcadePhysicsCallback = OnCatOverlapsWall;
														TilemapSetCollider tilemapSetCollider = new TilemapSetCollider(ArcadePhysics.s_world, overlapOnly: false, _catsPhysicsGroup, (ArcadeColliderType)flag, (ArcadePhysicsCallback)(object)monoBehaviour, (ArcadePhysicsCallback)num2, (CallbackContext)timerType);
														tilemapSetCollider._002Ector(ArcadePhysics.s_world, overlapOnly: false, _catsPhysicsGroup, (ArcadeColliderType)flag, (ArcadePhysicsCallback)(object)monoBehaviour, (ArcadePhysicsCallback)num2, (CallbackContext)timerType);
														bool flag8 = tilemapSetCollider == null;
														num4 = (nint)tilemapSetCollider;
														if (!flag8)
														{
															Collider collider = tilemapSetCollider.setName("Pickup_EME_Cat>Tilemap");
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ r12_v8+60]");
															bool flag9 = (nint)0 == 0;
															num4 = (nint)tilemapSetCollider;
															if (!flag9)
															{
																List<PhaserTilemap>.Enumerator enumerator = default(List<PhaserTilemap>.Enumerator);
																if (enumerator.MoveNext())
																{
																	object obj4 = 0;
																	num4 = (nint)(&enumerator);
																	throw new NullReferenceException();
																}
																num4 = (nint)ArcadePhysics.s_scene;
																if (ArcadePhysics.s_scene != null && ArcadePhysics.s_world != null)
																{
																	World s_world = ArcadePhysics.s_world;
																	if (ArcadePhysics.s_world != null)
																	{
																		num4 = (nint)s_world._colliders;
																		if (s_world._colliders != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4520");
																			goto IL_0470;
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
									goto IL_052b;
								}
							}
							goto IL_0470;
						}
					}
				}
			}
		}
		goto IL_052b;
		IL_0470:
		CoherenceSync coherenceSync = _coherenceSync;
		if ((object)_coherenceSync != null)
		{
			NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
			if (coherenceSync._003CEntityState_003Ek__BackingField != null)
			{
				num4 = (nint)networkEntityState._003CAuthorityType_003Ek__BackingField;
				if (networkEntityState._003CAuthorityType_003Ek__BackingField == null)
				{
					goto IL_052b;
				}
				bool flag10 = (byte)(int)ArcadePhysics.s_scene != 0;
				if ((nint)ArcadePhysics.s_scene != 1)
				{
					object obj5 = ArcadePhysics.s_scene - 3;
					bool flag11 = obj5 == null;
					flag10 = flag11;
				}
				if (!flag10)
				{
					return;
				}
			}
			SpawnCatsInsideBounds();
			return;
		}
		goto IL_052b;
		IL_052b:
		throw new NullReferenceException();
	}

	private void SpawnCats()
	{
		//IL_0079: Expected O, but got I
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v6 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v6 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v6 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		SpawnCatsInsideBounds();
	}

	private unsafe Bounds CalculateSpawnBounds(Bounds cameraBounds)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_04fd: Expected O, but got I4
		//IL_04f8: Expected native int or pointer, but got O
		//IL_0522: Expected native int or pointer, but got O
		//IL_0535: Expected native int or pointer, but got O
		//IL_03b1: Expected I, but got O
		//IL_03b9: Expected I, but got O
		//IL_03c9: Expected O, but got I
		//IL_0449: Expected O, but got I4
		//IL_0405: Expected O, but got I
		//IL_043b: Expected O, but got I4
		//IL_04a2: Expected O, but got I
		//IL_04d2: Expected native int or pointer, but got O
		//IL_0255: Expected O, but got I
		//IL_0265: Expected O, but got I
		//IL_05a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ac: Expected O, but got Unknown
		//IL_05dc: Expected O, but got I4
		//IL_0226: Expected O, but got I
		//IL_05f2: Expected native int or pointer, but got O
		//IL_029e: Expected O, but got I
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected O, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		//IL_0657: Expected O, but got I
		//IL_0667: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Expected O, but got Unknown
		//IL_067c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Expected O, but got Unknown
		//IL_0691: Unknown result type (might be due to invalid IL or missing references)
		//IL_0696: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		Bounds bounds = default(Bounds);
		((Bounds*)(nint)bounds)->m_Center = (Vector3)0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ r8_v5 (UnityEngine.Bounds)+8]");
		_ = 0;
		Bounds bounds2 = default(Bounds);
		_ = bounds2.m_Center;
		Vector3 vector = default(Vector3);
		((Bounds*)(nint)bounds)->m_Center = vector;
		_ = 0;
		((Bounds*)(nint)bounds)->m_Extents = vector;
		_ = 0;
		GameManager core = GM.Core;
		Stage stage4;
		object obj19;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				if (stage._stageType != StageType.EMERALD)
				{
					GameManager core2 = GM.Core;
					Stage stage2 = core2._stage;
					TilingTileset tilingTileset = stage2._tilingTileset;
					if ((object)stage2._tilingTileset == null || ((UnityEngine.Object)tilingTileset).m_CachedPtr == (IntPtr)0)
					{
						goto IL_058e;
					}
					float num = (float)vector * 2f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdi_v5 (VampireSurvivors.Objects.TilingTileset)+A0]");
					_ = 0;
					_ = tilingTileset._currentBounds;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdi_v5 (VampireSurvivors.Objects.TilingTileset)+98]");
					_ = 0;
					float num2 = num * 0.5f;
					GameManager core3 = GM.Core;
					if ((object)GM.Core != null)
					{
						Stage stage3 = core3._stage;
						if ((object)core3._stage != null)
						{
							StageData stageData = stage3._stageData;
							if (stage3._stageData != null)
							{
								Tileset tileset = stageData._003Ctileset_003Ek__BackingField;
								if (stageData._003Ctileset_003Ek__BackingField != null)
								{
									Vector3 vector2;
									if (tileset._003CisTiling_003Ek__BackingField)
									{
										Bounds totalBounds = stage2._tilingTileset.GetTotalBounds();
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v37 (UnityEngine.Bounds)+10]");
										object obj3 = 0;
										vector2 = totalBounds.m_Center;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v37 (UnityEngine.Bounds)+10]");
										_ = 0;
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
										object obj3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
										vector2 = (Vector3)0;
									}
									_ = 0;
									Bounds bounds3 = (Bounds)(obj - 121);
									_ = 0;
									bool flag = ((Bounds*)bounds)->Intersects(bounds3);
									bool flag2 = !flag;
									Vector3 center = (Vector3)0;
									if (!flag2)
									{
										object obj4 = bounds.m_Center - bounds.m_Extents;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnBuffer @ rcx (UnityEngine.Bounds)+8]");
										nint num3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnBuffer @ rcx (UnityEngine.Bounds)+14]");
										object obj5 = num3 - 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnBuffer @ rcx (UnityEngine.Bounds)+4]");
										object obj6 = 0 - vector;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
										object obj7 = vector - 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-45]");
										object obj8 = vector - 0;
										object obj9 = vector2 - vector;
										if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8)))
										{
											obj5 = obj8;
										}
										object obj10 = bounds.m_Extents + bounds.m_Center;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnBuffer @ rcx (UnityEngine.Bounds)+14]");
										nint num4 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnBuffer @ rcx (UnityEngine.Bounds)+8]");
										object obj11 = num4 + 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnBuffer @ rcx (UnityEngine.Bounds)+10]");
										object obj12 = 0 + vector;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
										object obj13 = vector + 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-45]");
										object obj14 = vector + 0;
										object obj15 = vector2 + vector;
										if ((System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15) || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13)) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14))
										{
											obj11 = obj14;
										}
										object obj16 = obj11 - obj5;
										float num5 = (float)obj16 * 0.5f;
										center = vector;
									}
									((Bounds*)(nint)bounds)->m_Center = center;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
									_ = 0;
									goto IL_058e;
								}
							}
						}
					}
				}
				else
				{
					GameManager core4 = GM.Core;
					if ((object)GM.Core != null)
					{
						stage4 = core4._stage;
						if ((object)core4._stage != null)
						{
							BackgroundManager fancyBg = stage4._fancyBg;
							if ((object)stage4._fancyBg == null)
							{
								goto IL_058e;
							}
							nint num6 = (nint)typeof(BackgroundEmerald);
							nint num7 = (nint)fancyBg;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundEmerald>)+130]");
							object obj17 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundManager>)+130]");
							nint num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundEmerald>)+130]");
							if (num8 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundManager>)+C8]");
								object obj18 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ rax_v20+FFFFFFF8+v416 @ rax_v13*8]");
								if (0 == (nint)typeof(BackgroundEmerald))
								{
									obj19 = 1;
									goto IL_06dc;
								}
							}
							obj19 = 0;
							goto IL_06dc;
						}
					}
				}
			}
		}
		goto IL_04e1;
		IL_04e1:
		return (Bounds)new NullReferenceException();
		IL_06dc:
		bool flag3 = obj19 == null;
		BackgroundManager backgroundManager = null;
		if (!flag3)
		{
			backgroundManager = stage4._fancyBg;
		}
		if ((object)backgroundManager != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rax_v16 (VampireSurvivors.Objects.Stages.BackgroundManager)+80]");
			if ((nint)0 == 0)
			{
				goto IL_04e1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rax_v16 (VampireSurvivors.Objects.Stages.BackgroundManager)+80]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rax_v16 (VampireSurvivors.Objects.Stages.BackgroundManager)+D0]");
			EME_BiomeBounds.EmeraldsBiomeBounds boundsForBiome = ((EME_BiomeBounds)num9).GetBoundsForBiome(BackgroundEmerald.EmeraldsBiomes.Biome1);
			_ = boundsForBiome.BoundsColor;
			_ = boundsForBiome.BoundsColor;
			_ = boundsForBiome.BoundsColor;
			_ = 0;
			((Bounds*)(nint)bounds)->m_Center = vector;
		}
		goto IL_058e;
		IL_058e:
		return bounds;
	}

	private unsafe void SpawnCatsInsideBounds()
	{
		//IL_09cb: Invalid comparison between F4 and I4
		//IL_01b5: Expected F4, but got I4
		//IL_0199: Expected I4, but got O
		//IL_01e9: Expected O, but got Ref
		//IL_08c0: Invalid comparison between F4 and I4
		//IL_08ce: Expected F4, but got I4
		//IL_085c: Invalid comparison between O and F4
		//IL_086d: Expected I4, but got O
		//IL_0899: Expected I4, but got O
		//IL_03a5: Expected I, but got O
		//IL_03b3: Expected I, but got O
		//IL_03c3: Expected O, but got I
		//IL_0443: Expected O, but got I4
		//IL_03ff: Expected O, but got I
		//IL_0a32: Expected O, but got I4
		//IL_0a3f: Expected I4, but got O
		//IL_0458: Expected I4, but got O
		//IL_0435: Expected O, but got I4
		//IL_0745: Expected I4, but got O
		//IL_019e->IL099a: Incompatible stack heights: 2 vs 0
		//IL_0156->IL099a: Incompatible stack heights: 2 vs 0
		//IL_0acb->IL061d: Incompatible stack heights: 2 vs 0
		//IL_0afd->IL072f: Incompatible stack heights: 2 vs 0
		List<object> cachedCats = (List<object>)(object)_cachedCats;
		if (_cachedCats != null)
		{
			int version = cachedCats._version + 1;
			cachedCats._version = version;
			int num = cachedCats._size;
			cachedCats._size = 0;
			if (cachedCats._size > 0)
			{
				Array.Clear(cachedCats._items, 0, cachedCats._size);
			}
			PhysicsGroup catsPhysicsGroup = _catsPhysicsGroup;
			if (_catsPhysicsGroup != null)
			{
				GameObject children = (GameObject)(object)((Group)catsPhysicsGroup).children;
				if (((Group)catsPhysicsGroup).children != null)
				{
					HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
					while (enumerator.MoveNext())
					{
						ItemType itemType = ItemType.VOID;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rbx_v22 (VampireSurvivors.Data.ItemType)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rbx_v22 (VampireSurvivors.Data.ItemType)+10]");
						IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
						GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
						int version2 = cachedCats._version + 1;
						cachedCats._version = version2;
						object[] items = cachedCats._items;
						bool flag2 = cachedCats._items == null;
						if (cachedCats._size >= items.Length)
						{
							((List<object>)(object)_cachedCats).AddWithResize((object)gameObject);
							ItemType itemType2 = ItemType.VOID;
							children = gameObject;
							num = 0;
						}
						else
						{
							int num2 = cachedCats._size + 1;
							cachedCats._size = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							ItemType itemType2 = ItemType.VOID;
							children = gameObject;
							num = (int)gameObject;
						}
					}
					if (!(_catsPerSpawn > 0f))
					{
						return;
					}
					ItemType itemType3 = ItemType.EME_CAT_RAINBOW;
					float movementAngle = 0f;
					int num3 = default(int);
					Vector2 vector = default(Vector2);
					float value = default(float);
					ItemType relicType = default(ItemType);
					bool shouldCallValidatePickups = default(bool);
					bool isRemote = default(bool);
					object obj6 = default(object);
					object obj7 = default(object);
					while (true)
					{
						GameManager core = GM.Core;
						if ((object)GM.Core == null || (object)core._stage == null)
						{
							break;
						}
						Vector2? pickupPositionOutOfSight = ((Stage)(&num3)).GetPickupPositionOutOfSight(movementAngle);
						_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals22;
						Pickup pickup;
						int num5;
						nint num6;
						object obj3;
						ItemType itemType2;
						if ((object)pickupPositionOutOfSight != null)
						{
							float num4 = UnityEngine.Random.Range(0f, 1f);
							bool flag3 = !(_rainbowCatSpawnChance > num4);
							ItemType itemType4 = ItemType.EME_CATY;
							if (!flag3)
							{
								itemType4 = itemType3;
							}
							if (cachedCats._size < 20)
							{
								CS_0024_003C_003E8__locals22 = new _003C_003Ec__DisplayClass12_0();
								if (CS_0024_003C_003E8__locals22 == null)
								{
									break;
								}
								CS_0024_003C_003E8__locals22._003C_003E4__this = this;
								GameManager core2 = GM.Core;
								if ((object)GM.Core == null || core2._multiplayer == null)
								{
									break;
								}
								if (core2._multiplayer.IsOnlineMultiplayer)
								{
									if ((object)GM.Core == null)
									{
										break;
									}
									bool isStageHost = GM.Core.IsStageHost;
									bool flag4 = (byte)((isStageHost ? 1u : 0u) ^ 1u) != 0;
								}
								if ((object)GM.Core == null)
								{
									break;
								}
								pickup = GM.Core.MakePickup(vector, itemType4, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
								if ((object)pickup == null)
								{
									num = (int)itemType4;
									num5 = 0;
									goto IL_0a25;
								}
								num6 = (nint)pickup;
								nint num7 = (nint)typeof(Pickup_EME_Cat);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1520 @ rdx_v44 (Il2CppClass<VampireSurvivors.Objects.Items.Pickup_EME_Cat>)+130]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1519 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
								nint num8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1520 @ rdx_v44 (Il2CppClass<VampireSurvivors.Objects.Items.Pickup_EME_Cat>)+130]");
								if (num8 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1519 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1564 @ rax_v93+FFFFFFF8+v1521 @ rax_v88*8]");
									if (0 == (nint)typeof(Pickup_EME_Cat))
									{
										obj3 = 1;
										goto IL_0a44;
									}
								}
								obj3 = 0;
								goto IL_0a44;
							}
							float2 float5 = base.position;
							GameObject gameObject2 = MathTools.FurthestGameObject(vector, _cachedCats);
							if ((object)gameObject2 == null)
							{
								break;
							}
							Pickup_EME_Cat component = gameObject2.GetComponent<Pickup_EME_Cat>();
							if ((object)component == null)
							{
								break;
							}
							float2 float6 = component.position;
							float2 float7 = base.position;
							object obj4 = float7 - float6;
							object obj5 = obj6 - obj7;
							object obj8 = obj4 * obj4;
							object obj9 = obj5 * obj5;
							object obj10 = obj8 + obj9;
							float num9 = component._maxDistanceFromPlayerBeforeDespawn * component._maxDistanceFromPlayerBeforeDespawn;
							bool flag5 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num9);
							itemType2 = (ItemType)component;
							num = 0;
							if (!flag5)
							{
								component.position = vector;
								itemType2 = (ItemType)component;
								num = 0;
							}
						}
						goto IL_08a7;
						IL_0a44:
						bool flag6 = obj3 == null;
						num = (int)num6;
						num5 = 0;
						if (!flag6)
						{
							num = (int)num6;
							num5 = (int)pickup;
						}
						goto IL_0a25;
						IL_0a25:
						CS_0024_003C_003E8__locals22.spawnedCat = (Pickup_EME_Cat)num5;
						itemType2 = (ItemType)CS_0024_003C_003E8__locals22.spawnedCat;
						if ((object)CS_0024_003C_003E8__locals22.spawnedCat != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v970 @ rbx_v14 (VampireSurvivors.Data.ItemType)+10]");
							if ((nint)0 != 0)
							{
								if ((object)CS_0024_003C_003E8__locals22.spawnedCat == null)
								{
									break;
								}
								GameObject gameObject3 = CS_0024_003C_003E8__locals22.spawnedCat.gameObject;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
								if (_catsPhysicsGroup == null)
								{
									break;
								}
								Group obj11 = _catsPhysicsGroup.add(CS_0024_003C_003E8__locals22.spawnedCat);
								Pickup_EME_Cat spawnedCat = CS_0024_003C_003E8__locals22.spawnedCat;
								if ((object)CS_0024_003C_003E8__locals22.spawnedCat == null)
								{
									break;
								}
								Action b = delegate
								{
									EME_CharacterControllerAmeya eME_CharacterControllerAmeya = CS_0024_003C_003E8__locals22._003C_003E4__this;
									PhysicsGroup catsPhysicsGroup2 = eME_CharacterControllerAmeya._catsPhysicsGroup;
									if (((HashSet<object>)(object)((Group)catsPhysicsGroup2).children).Contains((object)CS_0024_003C_003E8__locals22.spawnedCat))
									{
										EME_CharacterControllerAmeya eME_CharacterControllerAmeya2 = CS_0024_003C_003E8__locals22._003C_003E4__this;
										eME_CharacterControllerAmeya2._catsPhysicsGroup.remove(CS_0024_003C_003E8__locals22.spawnedCat);
										EME_CharacterControllerAmeya eME_CharacterControllerAmeya3 = CS_0024_003C_003E8__locals22._003C_003E4__this;
										eME_CharacterControllerAmeya3._catsPhysicsGroup.UpdateHashSetElements();
									}
								};
								Delegate obj12 = Delegate.Combine(spawnedCat.OnGoToPlayer, b);
								if ((object)obj12 == null)
								{
									spawnedCat.OnGoToPlayer = null;
								}
								else
								{
									bool flag7 = (object)obj12.GetType() != typeof(Action);
									Delegate obj13 = null;
									if (!flag7)
									{
										obj13 = obj12;
									}
									bool flag8 = (object)obj13 == null;
									spawnedCat.OnGoToPlayer = (Action)obj13;
									bool flag9 = (object)obj12.GetType() != typeof(Action);
									Delegate obj14 = null;
									if (!flag9)
									{
										obj14 = obj12;
									}
									bool flag10 = (object)obj14 == null;
								}
								Pickup_EME_Cat spawnedCat2 = CS_0024_003C_003E8__locals22.spawnedCat;
								if ((object)CS_0024_003C_003E8__locals22.spawnedCat == null)
								{
									break;
								}
								Action action = delegate
								{
									EME_CharacterControllerAmeya eME_CharacterControllerAmeya = CS_0024_003C_003E8__locals22._003C_003E4__this;
									PhysicsGroup catsPhysicsGroup2 = eME_CharacterControllerAmeya._catsPhysicsGroup;
									if (((HashSet<object>)(object)((Group)catsPhysicsGroup2).children).Contains((object)CS_0024_003C_003E8__locals22.spawnedCat))
									{
										EME_CharacterControllerAmeya eME_CharacterControllerAmeya2 = CS_0024_003C_003E8__locals22._003C_003E4__this;
										eME_CharacterControllerAmeya2._catsPhysicsGroup.remove(CS_0024_003C_003E8__locals22.spawnedCat);
										EME_CharacterControllerAmeya eME_CharacterControllerAmeya3 = CS_0024_003C_003E8__locals22._003C_003E4__this;
										eME_CharacterControllerAmeya3._catsPhysicsGroup.UpdateHashSetElements();
									}
								};
								Delegate obj15 = Delegate.Combine(spawnedCat2.OnDespawn, action);
								if ((object)obj15 == null)
								{
									spawnedCat2.OnDespawn = null;
								}
								else
								{
									bool flag11 = (object)obj15.GetType() != typeof(Action);
									Delegate obj16 = null;
									if (!flag11)
									{
										obj16 = obj15;
									}
									bool flag12 = (object)obj16 == null;
									spawnedCat2.OnDespawn = (Action)obj16;
									bool flag13 = (object)obj15.GetType() != typeof(Action);
									Delegate obj17 = null;
									if (!flag13)
									{
										obj17 = obj15;
									}
									bool flag14 = (object)obj17 == null;
								}
								itemType3 = ItemType.EME_CAT_RAINBOW;
								itemType2 = (ItemType)action;
								num = 0;
								goto IL_08a7;
							}
						}
						Debug.LogError("Unable to spawn cat!");
						itemType3 = ItemType.EME_CAT_RAINBOW;
						goto IL_08a7;
						IL_08a7:
						int num10 = 0 + 1;
						bool flag15 = _catsPerSpawn > (float)num10;
						movementAngle = num10;
						if (!flag15)
						{
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private bool OnCatOverlapsWall(CallbackContext context, ArcadeColliderType catCollider, ArcadeColliderType tileCollider)
	{
		//IL_0175: Expected I4, but got O
		//IL_00a4: Expected I, but got O
		//IL_00ac: Expected I, but got O
		//IL_00bc: Expected O, but got I
		//IL_013c: Expected O, but got I4
		//IL_00f8: Expected O, but got I
		//IL_012e: Expected O, but got I4
		Pickup_EME_Cat componentInChildren;
		object obj3;
		if (catCollider != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				componentInChildren = gameObject.GetComponentInChildren<Pickup_EME_Cat>(includeInactive: false);
				if ((object)componentInChildren == null || ((UnityEngine.Object)componentInChildren).m_CachedPtr == (IntPtr)0 || tileCollider == null)
				{
					goto IL_0161;
				}
				nint num = (nint)typeof(PhaserTile);
				nint num2 = (nint)tileCollider;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdx_v5 (Il2CppClass<PhaserTile>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ r8_v6 (Il2CppClass<ArcadeColliderType>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdx_v5 (Il2CppClass<PhaserTile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ r8_v6 (Il2CppClass<ArcadeColliderType>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rax_v20+FFFFFFF8+v273 @ rax_v14*8]");
					if (0 == (nint)typeof(PhaserTile))
					{
						obj3 = 1;
						goto IL_01b4;
					}
				}
				obj3 = 0;
				goto IL_01b4;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0161:
		return false;
		IL_01b4:
		bool flag = obj3 == null;
		PhaserTile phaserTile = null;
		if (!flag)
		{
			phaserTile = (PhaserTile)tileCollider;
		}
		if (phaserTile != null)
		{
			componentInChildren.OnHasHitWallPhaser(phaserTile);
			return true;
		}
		goto IL_0161;
	}

	private void OnDrawGizmos()
	{
		//IL_02bc: Expected O, but got I4
		//IL_004b: Expected O, but got I
		//IL_0080: Expected O, but got I
		//IL_00c7: Expected O, but got I
		//IL_00f4: Invalid comparison between O and F4
		//IL_0131: Invalid comparison between F4 and O
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0171: Invalid comparison between O and F4
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_01b1: Invalid comparison between F4 and O
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected O, but got Unknown
		//IL_0289: Invalid comparison between F4 and O
		//IL_0442: Invalid comparison between F4 and O
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected O, but got Unknown
		//IL_03ff: Invalid comparison between F4 and O
		//IL_045c: Invalid comparison between F4 and O
		//IL_0355->IL02a7: Incompatible stack heights: 1 vs 0
		//IL_006b->IL02a7: Incompatible stack heights: 1 vs 0
		//IL_037f->IL0439: Incompatible stack heights: 1 vs 0
		//IL_00b1->IL0439: Incompatible stack heights: 1 vs 0
		//IL_0487->IL0439: Incompatible stack heights: 1 vs 0
		object obj = Application.isPlaying;
		if (obj == null)
		{
			return;
		}
		Transform transform = base.transform;
		Vector3 ret;
		object obj17 = default(object);
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
			float num = (float)_spawnRectangleSize * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EME_CharacterControllerAmeya)+458]");
			float num2 = 0f * 0.5f;
			Transform core = (Transform)(object)GM.Core;
			if ((object)GM.Core != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ rbx_v8 (UnityEngine.Transform)+B8]");
				Transform transform2 = (Transform)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ rbx_v8 (UnityEngine.Transform)+B8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rbx_v9 (UnityEngine.Transform)+208]");
					Transform transform3 = (Transform)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rbx_v9 (UnityEngine.Transform)+208]");
					if ((nint)0 == 0 || ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rbx_v9 (UnityEngine.Transform)+208]");
					Bounds totalBounds = ((TilingTileset)0).GetTotalBounds();
					float num3 = (float)ret - num;
					object obj3 = default(object);
					object obj2 = (object)totalBounds.m_Center + obj3;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3))
					{
						float num4 = num + (float)ret;
						object obj4 = (object)totalBounds.m_Center - obj3;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
						{
							object obj5 = default(object);
							float num5 = (float)obj5 - num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v822 @ rax_v34 (UnityEngine.Bounds)+10]");
							object obj6 = obj3 + 0;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5))
							{
								float num6 = num2 + (float)obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v822 @ rax_v34 (UnityEngine.Bounds)+10]");
								object obj7 = obj3 - 0;
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
								{
									object obj9 = default(object);
									object obj8 = obj3 + obj9;
									if ((nint)obj8 >= 0)
									{
										object obj10 = obj3 - obj9;
										if (0 >= (nint)obj10)
										{
											float num7 = (float)ret - num;
											float num8 = (float)obj5 - num2;
											object obj11 = (object)totalBounds.m_Center - obj3;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v822 @ rax_v34 (UnityEngine.Bounds)+10]");
											object obj12 = obj3 - 0;
											object obj14 = default(object);
											object obj13 = obj3 - obj14;
											if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num7) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11) || 0 < (nint)obj13)
											{
											}
											float num10 = default(float);
											object obj15 = default(object);
											if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num8) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12))
											{
												float num9 = num + (float)ret;
												num10 = num2 + (float)obj5;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v822 @ rax_v34 (UnityEngine.Bounds)+10]");
												obj15 = 0 + obj3;
												object obj16 = obj3 + (object)totalBounds.m_Center;
												obj17 = obj14 + obj3;
												if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num9) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj16))
												{
													goto IL_0411;
												}
											}
											if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num10) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15))
											{
												goto IL_0411;
											}
										}
									}
								}
							}
						}
					}
					goto IL_0475;
				}
			}
		}
		throw new NullReferenceException();
		IL_0411:
		if (0 <= (nint)obj17)
		{
		}
		goto IL_0475;
		IL_0475:
		Vector3 center = default(Vector3);
		Gizmos.DrawWireCube_Injected(ref center, ref ret);
	}

	public override void LevelUp()
	{
		base.LevelUp();
		if (((CharacterController)this)._level < 80)
		{
			if (((CharacterController)this)._level < 60)
			{
				if (((CharacterController)this)._level < 40)
				{
					if (((CharacterController)this)._level >= 20)
					{
						_catSpawnInterval = 5f;
						_catsPerSpawn = 2f;
					}
				}
				else
				{
					_catSpawnInterval = 4f;
					_catsPerSpawn = 2f;
				}
			}
			else
			{
				_catSpawnInterval = 4f;
				_catsPerSpawn = 3f;
			}
		}
		else
		{
			_catSpawnInterval = 3f;
			_catsPerSpawn = 3f;
		}
	}

	public EME_CharacterControllerAmeya()
	{
		List<GameObject> cachedCats = new List<GameObject>();
		_cachedCats = cachedCats;
		base._morphDuration = 13000f;
		((CharacterController)this)._002Ector();
	}
}
