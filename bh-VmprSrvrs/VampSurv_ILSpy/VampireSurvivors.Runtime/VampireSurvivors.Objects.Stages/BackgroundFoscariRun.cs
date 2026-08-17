using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundFoscariRun : BackgroundManager
{
	protected float2 CartOffset;

	private Vector2 _initialOffset;

	private TileSprite fb_bg_hw_Back;

	private TileSprite fb_bg_hw_Front;

	private TileSprite rainbowRoad;

	private float _speedFactor;

	private float _accelerationMul;

	private bool isFirstUpdate;

	private bool _hasAlteredPrismaticMissile;

	private List<PhaserSprite> _frontCartSprites;

	private List<PhaserSprite> _backCartSprites;

	private List<float2> _cartOffsets;

	private float _distanceTravelled;

	private int _loopLength;

	private int _loopsDone;

	private float _nextLoopDist;

	private TilingTileset _tilingTileset;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _glitchEmitter;

	private ParticleSystem _glitchEmitter2;

	private bool _wasPaused;

	private float _inversionMul;

	private MapToken _mapToken;

	private float _playerStartX;

	private float _waterOffset;

	private TileSprite _water;

	private SpriteRenderer _waterFG;

	private VampireSurvivors.Objects.Characters.CharacterController _Luminaire;

	private Timer _pickupsLoopTimer;

	private float _itemLoopTimer;

	private float _itemLoopDelay;

	public unsafe void MakeWaterFallBackground()
	{
		//IL_057f: Expected O, but got Ref
		//IL_0986: Expected I4, but got I8
		//IL_094c->IL076f: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		float waterOffset;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				GameManager core2 = default(GameManager);
				if (!config._003CSelectedInverse_003Ek__BackingField)
				{
					core2 = GM.Core;
					if ((object)GM.Core == null)
					{
						goto IL_076f;
					}
				}
				if (core2._playerOptions != null)
				{
					PlayerOptionsData config2 = core2._playerOptions.Config;
					if (config2 != null)
					{
						if (!config2._003CSelectedInverse_003Ek__BackingField)
						{
							goto IL_018e;
						}
						GameManager core3 = GM.Core;
						if ((object)GM.Core != null && core3._playerOptions != null)
						{
							PlayerOptionsData config3 = core3._playerOptions.Config;
							if (config3 != null)
							{
								if (!config3._003CVisuallyInvertStages_003Ek__BackingField)
								{
									goto IL_018e;
								}
								waterOffset = 0.05f;
								goto IL_07c4;
							}
						}
					}
				}
			}
		}
		goto IL_076f;
		IL_07c4:
		if ((object)this != null)
		{
			_waterOffset = waterOffset;
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
								float y = renderer2.height * 0.5f;
								float x = renderer.width * 0.5f;
								GameObject go = base.gameObject;
								string spriteName = default(string);
								TileSpriteBuilder tileSpriteBuilder = RenderingExtensions.AddTileSprite(go, x, y, "background_Foscari", spriteName);
								if (tileSpriteBuilder != null)
								{
									tileSpriteBuilder._depth = -32768f;
									tileSpriteBuilder._depthMul = 1f;
									Transform parent = base.transform;
									tileSpriteBuilder._parent = parent;
									if ((object)GM.Core != null)
									{
										PhaserScene s_scene3 = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null)
										{
											PhaserScene.Renderer renderer3 = s_scene3._renderer;
											if (s_scene3._renderer != null && (object)GM.Core != null)
											{
												PhaserScene s_scene4 = ArcadePhysics.s_scene;
												if (ArcadePhysics.s_scene != null)
												{
													PhaserScene.Renderer renderer4 = s_scene4._renderer;
													if (s_scene4._renderer != null)
													{
														tileSpriteBuilder._tileHeight = renderer4.height;
														tileSpriteBuilder._tileWidth = renderer3.width;
														tileSpriteBuilder._name = "WaterBG";
														TileSprite water = tileSpriteBuilder.Build();
														_water = water;
														TileSprite tileSprite = RenderingExtensions.SetScrollFactor(_water, 0f);
														if ((object)GM.Core != null)
														{
															PhaserScene s_scene5 = ArcadePhysics.s_scene;
															if (ArcadePhysics.s_scene != null)
															{
																PhaserScene.Renderer renderer5 = s_scene5._renderer;
																if (s_scene5._renderer != null && (object)GM.Core != null)
																{
																	PhaserScene s_scene6 = ArcadePhysics.s_scene;
																	if (ArcadePhysics.s_scene != null)
																	{
																		PhaserScene.Renderer renderer6 = s_scene6._renderer;
																		if (s_scene6._renderer != null)
																		{
																			float y2 = renderer6.height * 0.5f;
																			float x2 = renderer5.width * 0.5f;
																			GameObject gameObject = base.gameObject;
																			SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, x2, y2, "", spriteName);
																			if ((object)spriteRenderer != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v68 (UnityEngine.SpriteRenderer)+10]");
																				bool flag = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v68 (UnityEngine.SpriteRenderer)+10]");
																				Renderer.set_sortingOrder_Injected((IntPtr)0, 1);
																				Transform parent2 = base.transform;
																				Transform transform = spriteRenderer.transform;
																				if ((object)transform != null)
																				{
																					transform.SetParent(parent2, worldPositionStays: true);
																					((UnityEngine.Object)spriteRenderer).SetName("WaterFG");
																					_waterFG = spriteRenderer;
																					SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScrollFactor(_waterFG, 0f);
																					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
																					object obj = default(object);
																					RenderingExtensions.SetTint(_waterFG, (Color?)(object)(&obj));
																					SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_waterFG, 0.35f);
																					string waterFG = (string)(object)_waterFG;
																					bool flag2 = (object)_waterFG == null;
																					bool flag3 = waterFG._stringLength == 0;
																					Renderer.set_sortingOrder_Injected((IntPtr)waterFG._stringLength, -1000);
																					bool flag4 = (object)_waterFG == null;
																					Transform transform2 = _waterFG.transform;
																					bool flag5 = (object)transform2 == null;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rax_v85 (UnityEngine.Transform)+10]");
																					bool flag6 = (nint)0 == 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rax_v85 (UnityEngine.Transform)+10]");
																					Vector3 value = default(Vector3);
																					Transform.set_localPosition_Injected((IntPtr)0, ref value);
																					bool flag7 = (object)GM.Core == null;
																					PhaserScene s_scene7 = ArcadePhysics.s_scene;
																					bool flag8 = ArcadePhysics.s_scene == null;
																					PhaserScene.Renderer renderer7 = s_scene7._renderer;
																					bool flag9 = s_scene7._renderer == null;
																					bool flag10 = (object)GM.Core == null;
																					PhaserScene s_scene8 = ArcadePhysics.s_scene;
																					bool flag11 = ArcadePhysics.s_scene == null;
																					PhaserScene.Renderer renderer8 = s_scene8._renderer;
																					bool flag12 = s_scene8._renderer == null;
																					SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale(xScale: renderer7.width / 5.12f, yScale: renderer8.height / 5.12f, component: _waterFG);
																					Material material = MaterialManager.GetMaterial(MaterialType.ScrollPerspective);
																					bool flag13 = (object)_waterFG == null;
																					((Renderer)_waterFG).SetMaterial(material);
																					bool flag14 = (object)_waterFG == null;
																					GameObject gameObject2 = _waterFG.gameObject;
																					bool flag15 = (object)gameObject2 == null;
																					PauseTimeHelper pauseTimeHelper = gameObject2.AddComponent<PauseTimeHelper>();
																					bool flag16 = (object)pauseTimeHelper == null;
																					pauseTimeHelper._renderer = _waterFG;
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
		goto IL_076f;
		IL_076f:
		throw new NullReferenceException();
		IL_018e:
		waterOffset = -0.05f;
		goto IL_07c4;
	}

	public override void Create()
	{
		//IL_02e0: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_006f: Expected O, but got I4
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_0190: Expected O, but got I
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected F4, but got Unknown
		//IL_024a: Expected O, but got I
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected F4, but got Unknown
		//IL_0352: Expected F4, but got I4
		base.Create();
		CartOffset = (float2)0;
		_ = 1041865114;
		bool flag = GM.Core.IsStageVisuallyInverted();
		object obj = (flag ? 1 : 0) ^ 1;
		object obj2 = obj * 2;
		float inversionMul = (float)obj2 - 1f;
		_inversionMul = inversionMul;
		bool flag2 = GM.Core.IsStageVisuallyInverted();
		object obj3 = (flag2 ? 1 : 0) ^ 1;
		object obj4 = obj3 * 4;
		object obj5 = obj3 + obj4;
		object obj6 = obj5 << 2;
		float pickupLimitX = 10f - (float)obj6;
		_pickupLimitX = pickupLimitX;
		_pickupRecycleOffset = 10f;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		_tilingTileset = stage._tilingTileset;
		RacingBoundsMinY = -21.5f;
		RacingBoundsMaxY = -18f;
		RacingBoundsFlyingEnemiesY = -16f;
		List<Vector2> specialLocations = _tilingTileset.GetSpecialLocations("Racing_Bounds_Min_Y");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v27 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		float num;
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v27 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_02eb;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v27 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rcx_v47+24]");
			float racingBoundsMinY = 0 ^ -0f;
			RacingBoundsMinY = racingBoundsMinY;
			num = -0f;
		}
		else
		{
			num = -0f;
		}
		List<Vector2> specialLocations2 = _tilingTileset.GetSpecialLocations("Racing_Bounds_Max_Y");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v28 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v28 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_02eb;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v28 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v46+24]");
			float racingBoundsMaxY = 0 ^ num;
			RacingBoundsMaxY = racingBoundsMaxY;
		}
		List<PhaserSprite> frontCartSprites = new List<PhaserSprite>();
		_frontCartSprites = frontCartSprites;
		List<PhaserSprite> backCartSprites = new List<PhaserSprite>();
		_backCartSprites = backCartSprites;
		List<float2> cartOffsets = new List<float2>();
		_cartOffsets = cartOffsets;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		float2 offset = default(float2);
		while (enumerator.MoveNext())
		{
			SpawnCartForCharacter(null, offset);
		}
		_loopsDone = 0;
		_nextLoopDist = _loopLength;
		MakeWaterFallBackground();
		return;
		IL_02eb:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw null;
	}

	private void SpawnCartForCharacter(VampireSurvivors.Objects.Characters.CharacterController character, float2 offset)
	{
		//IL_01a3: Expected O, but got I4
		//IL_01f2: Expected O, but got I4
		//IL_016e: Expected O, but got I4
		float2 item;
		List<float2> cartOffsets;
		if (!character.NeedsCart)
		{
			List<object> frontCartSprites = (List<object>)(object)_frontCartSprites;
			int version = frontCartSprites._version + 1;
			frontCartSprites._version = version;
			object[] items = frontCartSprites._items;
			if (frontCartSprites._size >= items.Length)
			{
				frontCartSprites.AddWithResize((object)null);
			}
			else
			{
				int size = frontCartSprites._size + 1;
				frontCartSprites._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			List<object> backCartSprites = (List<object>)(object)_backCartSprites;
			int version2 = backCartSprites._version + 1;
			backCartSprites._version = version2;
			object[] items2 = backCartSprites._items;
			if (backCartSprites._size >= items2.Length)
			{
				backCartSprites.AddWithResize((object)null);
			}
			else
			{
				int size2 = backCartSprites._size + 1;
				backCartSprites._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			item = (float2)0;
			cartOffsets = _cartOffsets;
		}
		else
		{
			PhaserWorld instance = PhaserWorld.Instance;
			PhaserSprite phaserSprite = instance.AddPhaserSprite((Vector2)0, "items", "_FS_CART_FRONT");
			GameObject gameObject = phaserSprite.gameObject;
			((UnityEngine.Object)gameObject).SetName("_frontCartSprite");
			PhaserWorld instance2 = PhaserWorld.Instance;
			PhaserSprite phaserSprite2 = instance2.AddPhaserSprite((Vector2)0, "items", "_FS_CART_BACK");
			GameObject gameObject2 = phaserSprite2.gameObject;
			((UnityEngine.Object)gameObject2).SetName("_backCartSprite");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
			item = offset;
			cartOffsets = _cartOffsets;
		}
		cartOffsets.Add(item);
	}

	public override void OnInitCompleted()
	{
		base.OnInitCompleted();
		float yMax = default(float);
		bool skipInverseCalculation = default(bool);
		GM.Core.SetHardBoundsMinMax(-3.4028235E+38f, 1800f, 3.4028235E+38f, yMax, skipInverseCalculation);
		base.OnPlayerEnteringDifferentTilemap();
	}

	protected override void OnUpdate()
	{
		//IL_053c: Expected F4, but got I4
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Expected O, but got Unknown
		//IL_01c0: Expected I, but got O
		//IL_013f: Expected F4, but got I4
		//IL_01ec: Invalid comparison between F4 and I4
		//IL_0243: Invalid comparison between F4 and I4
		//IL_02ab: Expected I, but got O
		//IL_02b9: Expected I, but got O
		//IL_02c9: Expected O, but got I
		//IL_0349: Expected O, but got I4
		//IL_05fb: Expected O, but got F4
		//IL_0305: Expected O, but got I
		//IL_033b: Expected O, but got I4
		//IL_0144->IL059c: Incompatible stack heights: 1 vs 0
		//IL_03b9->IL062c: Incompatible stack heights: 1 vs 0
		base.OnUpdate();
		List<VampireSurvivors.Objects.Characters.CharacterController> list = default(List<VampireSurvivors.Objects.Characters.CharacterController>);
		float num;
		if (isFirstUpdate)
		{
			isFirstUpdate = false;
			ProCamera2D instance = ProCamera2D.Instance;
			instance.FollowVertical = false;
			ProCamera2D instance2 = ProCamera2D.Instance;
			instance2.FollowHorizontal = false;
			Transform transform = _mainCamera.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			GameManager core = GM.Core;
			list = core._characters;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			while (enumerator.MoveNext())
			{
				Transform transform2 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ rbx_v19 (UnityEngine.Transform)+134]");
				if ((nint)0 == 76)
				{
					((VampireSurvivors.Objects.Characters.CharacterController)null).AddXp(200f, XPMultiplierMode.Normal);
					_Luminaire = null;
					list = null;
				}
				_ = 1;
				_ = 1;
				_ = 1;
				_ = 0;
				_ = 0;
			}
			num = 0f;
		}
		else
		{
			num = 0f;
		}
		if (PauseSystem._paused)
		{
			return;
		}
		if (!_hasAlteredPrismaticMissile)
		{
			VampireSurvivors.Objects.Characters.CharacterController luminaire = _Luminaire;
			if ((object)_Luminaire != null && ((UnityEngine.Object)luminaire).m_CachedPtr != (IntPtr)0)
			{
				VampireSurvivors.Objects.Characters.CharacterController luminaire2 = _Luminaire;
				float num2 = num;
				nint num3 = (nint)list;
				float num4 = num;
				while (true)
				{
					CharacterWeaponsManager weaponsManager = luminaire2._weaponsManager;
					List<Equipment> list2 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
					if (!(num4 < (float)list2._size))
					{
						break;
					}
					VampireSurvivors.Objects.Characters.CharacterController luminaire3 = _Luminaire;
					CharacterWeaponsManager weaponsManager2 = luminaire3._weaponsManager;
					List<Equipment> list3 = ((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField;
					bool flag2 = !(num2 < (float)list3._size);
					Equipment[] items = list3._items;
					VampireSurvivors.Objects.Characters.CharacterController characterController = (VampireSurvivors.Objects.Characters.CharacterController)(object)items[num2];
					if ((nint)((ArcadeSprite)characterController)._spriteRenderer != 133)
					{
						goto IL_05c5;
					}
					num3 = (nint)characterController;
					nint num5 = (nint)typeof(Weapon);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1371 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1371 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					object obj3;
					if (num6 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+C8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rax_v58+FFFFFFF8+v1372 @ rax_v44*8]");
						if (0 == (nint)typeof(Weapon))
						{
							obj3 = 1;
							goto IL_05e4;
						}
					}
					obj3 = 0;
					goto IL_05e4;
					IL_05e4:
					bool flag3 = obj3 == null;
					luminaire = (VampireSurvivors.Objects.Characters.CharacterController)num;
					if (!flag3)
					{
						luminaire = characterController;
					}
					if ((object)luminaire != null && ((UnityEngine.Object)luminaire).m_CachedPtr != (IntPtr)0)
					{
						luminaire._startingWeaponType = WeaponType.MAGIC_MISSILE;
						_hasAlteredPrismaticMissile = true;
					}
					goto IL_05c5;
					IL_05c5:
					num2++;
					luminaire2 = _Luminaire;
					num4 = num2;
				}
			}
		}
		float deltaTime = PauseSystem.DeltaTime;
		float num7 = _accelerationMul * _speedFactor;
		float num8 = num7 * _inversionMul;
		float num9 = deltaTime * num8;
		float num10 = num9 * 60f;
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		stage._tilingTileset.MoveTilesetForHorizontalRoad(num10);
		MoveCarts();
		float deltaTime2 = PauseSystem.DeltaTime;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj4 = num10 & 0;
		float num11 = (float)obj4 * 6.4f;
		float distanceTravelled = num11 + _distanceTravelled;
		_distanceTravelled = distanceTravelled;
		float deltaTime3 = PauseSystem.DeltaTime;
		float num12 = deltaTime3 * 1000f;
		if ((_itemLoopTimer = num12 + _itemLoopTimer) > _itemLoopDelay)
		{
			_itemLoopTimer = num;
			LoopPickupPositions();
		}
		if (!PauseSystem._paused)
		{
			float2 offset = default(float2);
			GM.Core.MovePickupsAndDestructibles(offset);
		}
	}

	public float GetDistanceTravelled()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 position = gameSessionData._activeCharacter.position;
		object obj = position - _playerStartX;
		object obj2 = obj & -2147483649L;
		float num = (float)obj2 * 100f;
		return num + _distanceTravelled;
	}

	private void CheckDistanceTravelled()
	{
	}

	private void OnLoopDone()
	{
		//IL_002c: Expected F4, but got I4
		LoopPickupPositions();
		int loopsDone = _loopsDone + 1;
		_loopsDone = loopsDone;
		_nextLoopDist = _loopLength;
	}

	public unsafe override void LoopPickupPositions()
	{
		//IL_0254: Invalid comparison between O and F4
		//IL_01d9: Expected O, but got F4
		//IL_0263->IL0272: Incompatible stack heights: 3 vs 0
		//IL_0113->IL0272: Incompatible stack heights: 3 vs 0
		//IL_0138->IL0272: Incompatible stack heights: 3 vs 0
		//IL_01ed->IL0272: Incompatible stack heights: 3 vs 0
		//IL_01df->IL0272: Incompatible stack heights: 3 vs 0
		bool flag = GM.Core.IsStageVisuallyInverted();
		Component component = null;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		float2 position3 = default(float2);
		while (enumerator.MoveNext())
		{
			Pickup component2 = ((Component)null).GetComponent<Pickup>();
			bool flag2 = (object)component2 == null;
			Transform cachedTrans = ((ArcadeSprite)component2).CachedTrans;
			bool flag3 = (object)cachedTrans == null;
			bool flag4 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			Component ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
			if (component2.body != null)
			{
				BaseBody body = component2.body;
				ArcadeTransform arcadeTransform = body._transform;
				arcadeTransform.position = (float2)ret;
				component = ret;
			}
			else
			{
				component = ret;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<Component, UIntPtr>(ref component) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)2f) && ((UnityEngine.Object)component2).m_CachedPtr != (IntPtr)0 && !component2._003CIgnoreForcedMovement_003Ek__BackingField)
			{
				if (!component2._003CDespawnInteadOfResetPosition_003Ek__BackingField)
				{
					GameManager core = GM.Core;
					GameSessionData gameSessionData = core._gameSessionData;
					float2 position = gameSessionData._activeCharacter.position;
					float value = UnityEngine.Random.value;
					float2 position2 = component2.position;
					float num = (float)position + 10f;
					component2.position = position3;
					component = (Component)num;
				}
				else
				{
					component2.Despawn();
				}
			}
		}
	}

	private void LateUpdate()
	{
		//IL_0079->IL0079: Incompatible stack heights: 1 vs 0
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbx_v4 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbx_v4 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
			Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			ContainWithinRacingBounds(target);
		}
	}

	private void MoveVehiclesAndPickups(float movement)
	{
		if (!PauseSystem._paused)
		{
			float2 offset = default(float2);
			GM.Core.MovePickupsAndDestructibles(offset);
		}
	}

	private void MoveCarts()
	{
		//IL_0265: Expected O, but got I4
		//IL_026e: Expected O, but got I4
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		GameManager core = GM.Core;
		object obj = 0;
		object obj2 = 0;
		object obj4 = default(object);
		object obj5 = default(object);
		object obj7 = default(object);
		PhaserSprite phaserSprite2 = default(PhaserSprite);
		float2 position2 = default(float2);
		PhaserSprite phaserSprite5 = default(PhaserSprite);
		while (true)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
			if ((nint)obj2 < characters._size)
			{
				GameManager core2 = GM.Core;
				List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = core2._characters;
				if ((nint)obj >= characters2._size)
				{
					break;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = characters2._items;
				if (items[obj].NeedsCart)
				{
					float2 float5 = items[obj].ApplyRacingOffset(CharacterVehicleType.CART);
					bool flipX = items[obj].flipX;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					float2 position = items[obj].position;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
					object obj3 = obj4 + obj5;
					object obj6 = obj7 + obj3;
					PhaserSprite phaserSprite = phaserSprite2.setPosition(position2);
					int depth = items[obj].depth;
					int depth2 = depth + 1;
					PhaserSprite phaserSprite3 = phaserSprite2.setDepth(depth2);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					float2 position3 = items[obj].position;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
					object obj8 = obj4 + obj5;
					object obj9 = obj8 + obj7;
					PhaserSprite phaserSprite4 = phaserSprite5.setPosition(position2);
					int depth3 = items[obj].depth;
					int depth4 = depth3 - 10;
					PhaserSprite phaserSprite6 = phaserSprite5.setDepth(depth4);
				}
				obj++;
				core = GM.Core;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void Cleanup()
	{
		//IL_0031: Expected O, but got I4
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		if (_pickupsLoopTimer != null)
		{
			_pickupsLoopTimer.Cancel();
		}
		GameManager core = GM.Core;
		core._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
	}

	private unsafe void MakeEmitters()
	{
		//IL_0008: Expected O, but got Ref
		//IL_02c9: Expected O, but got I4
		//IL_02f0: Expected O, but got I4
		//IL_0328: Expected O, but got I4
		//IL_0341: Expected O, but got Ref
		//IL_0368: Expected O, but got I
		//IL_0382: Expected native int or pointer, but got O
		//IL_039c: Expected O, but got I
		//IL_03d5: Expected O, but got I
		//IL_0435: Expected O, but got Ref
		//IL_0458: Expected F4, but got I4
		//IL_0453: Expected native int or pointer, but got O
		//IL_0b6c: Expected O, but got I
		//IL_048b: Expected O, but got Ref
		//IL_04a5: Expected native int or pointer, but got O
		//IL_0ba6: Expected O, but got I
		//IL_04dd: Expected O, but got Ref
		//IL_04f7: Expected native int or pointer, but got O
		//IL_0be0: Expected O, but got I
		//IL_0577: Expected O, but got I
		//IL_05a6: Expected O, but got I
		//IL_06e5: Expected O, but got I4
		//IL_070c: Expected O, but got I4
		//IL_0744: Expected O, but got I4
		//IL_075d: Expected O, but got Ref
		//IL_0784: Expected O, but got I
		//IL_079e: Expected native int or pointer, but got O
		//IL_07b8: Expected O, but got I
		//IL_07f1: Expected O, but got I
		//IL_0830: Expected O, but got Ref
		//IL_0853: Expected F4, but got I4
		//IL_084e: Expected native int or pointer, but got O
		//IL_0869: Expected O, but got I
		//IL_0c3a: Expected O, but got I
		//IL_0889: Expected O, but got Ref
		//IL_08a3: Expected native int or pointer, but got O
		//IL_0c74: Expected O, but got I
		//IL_08db: Expected O, but got Ref
		//IL_08f5: Expected native int or pointer, but got O
		//IL_0cae: Expected O, but got I
		//IL_0975: Expected O, but got I
		//IL_0996: Expected O, but got I
		//IL_0d70: Expected O, but got I
		//IL_0de5: Expected O, but got Ref
		//IL_0daf: Expected O, but got I
		//IL_0e1c: Expected O, but got Ref
		//IL_0e09->IL0b05: Incompatible stack heights: 3 vs 0
		//IL_0acc->IL0dd7: Incompatible stack heights: 4 vs 3
		//IL_0b05->IL0e0e: Incompatible stack heights: 4 vs 3
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)GM.Core != null)
		{
			bool flag = GM.Core.IsStageVisuallyInverted();
			PhaserScene phaserScene = base.scene;
			if (phaserScene != null)
			{
				PhaserScene.Renderer renderer = phaserScene._renderer;
				if (phaserScene._renderer != null)
				{
					PhaserScene phaserScene2 = base.scene;
					if (phaserScene2 != null)
					{
						PhaserScene.Renderer renderer2 = phaserScene2._renderer;
						if (phaserScene2._renderer != null)
						{
							float num = renderer2.screenWidth * 0.5f;
							Rectangle rectangle = new Rectangle();
							float x = num ^ -0f;
							rectangle._x = x;
							rectangle._width = renderer.screenWidth;
							rectangle._y = 0f;
							rectangle._height = 0.64f;
							Rectangle rectangle2 = new Rectangle();
							float x2 = num ^ -0f;
							rectangle2._x = x2;
							rectangle2._width = renderer.screenWidth;
							rectangle2._y = 0.32f;
							rectangle2._height = 0.64f;
							ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
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
										((List<object>)(object)list).AddWithResize((object)"WhiteDot");
									}
									else
									{
										int size = list._size + 1;
										list._size = size;
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
										float constant = _inversionMul * 5f;
										minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
										particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
										_ = 0;
										ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
										_ = 0;
										_ = 1;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
										particleSystemConfig._blendMode = (BlendMode?)(object)0;
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(200f, 250f));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+70]");
										particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
										_ = 0;
										_ = 0;
										_ = 40;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
										particleSystemConfig._quantity = (int?)(object)0;
										if ((object)GM.Core != null)
										{
											PhaserScene s_scene = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null)
											{
												PhaserScene.Renderer renderer3 = s_scene._renderer;
												if (s_scene._renderer != null)
												{
													ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, renderer3.pixelWidth));
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
													particleSystemConfig._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 2f));
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
													particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0.65f));
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D0]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
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
													_ = 1120403456;
													_ = 1;
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
													particleSystemConfig._frequency = (float?)(object)0;
													particleSystemConfig._on = true;
													_ = 6915750;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
													particleSystemConfig._tint = (uint?)(object)0;
													ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
													List<string> list2 = new List<string>();
													if (list2 != null)
													{
														int version2 = list2._version + 1;
														list2._version = version2;
														string[] items2 = list2._items;
														if (list2._items != null)
														{
															if (list2._size >= items2.Length)
															{
																((List<object>)(object)list2).AddWithResize((object)"WhiteDot");
															}
															else
															{
																int size2 = list2._size + 1;
																list2._size = size2;
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
																float constant2 = _inversionMul * -5f;
																minMaxCurve = new ParticleSystem.MinMaxCurve(constant2);
																particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
																_ = 0;
																ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 240));
																_ = 0;
																_ = 1;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
																particleSystemConfig2._blendMode = (BlendMode?)(object)0;
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(200f, 250f));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
																particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+100]");
																_ = 0;
																_ = 0;
																_ = 40;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
																particleSystemConfig2._quantity = (int?)(object)0;
																bool flag2 = (object)GM.Core == null;
																PhaserScene s_scene2 = ArcadePhysics.s_scene;
																PhaserScene.Renderer renderer4 = s_scene2._renderer;
																ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 272));
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(1f, renderer4.pixelWidth));
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
																obj = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+120]");
																_ = 0;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
																particleSystemConfig2._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
																_ = 0;
																ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 304));
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 2f));
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+130]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
																_ = 0;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+20]");
																particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+30]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+40]");
																_ = 0;
																ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 336));
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(1f, 0.65f));
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+150]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+160]");
																_ = 0;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
																particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
																_ = 0;
																particleSystemConfig2._emitZone = new EmitZone
																{
																	_type = EmitZoneType.Random,
																	_source = rectangle2
																};
																_ = 0;
																_ = 1120403456;
																_ = 1;
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
																particleSystemConfig2._frequency = (float?)(object)0;
																_ = 6915750;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
																particleSystemConfig2._tint = (uint?)(object)0;
																particleSystemConfig2._on = true;
																PhaserScene phaserScene3 = base.scene;
																Camera main = Camera.main;
																Transform parent = main.transform;
																ParticleSystem glitchEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent, "_glitchEmitter");
																_glitchEmitter = glitchEmitter;
																Transform transform = _glitchEmitter.transform;
																bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
																Vector3 value = default(Vector3);
																Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
																RenderingExtensions.SetDepth(_glitchEmitter, 3000);
																Camera main2 = Camera.main;
																Transform parent2 = main2.transform;
																ParticleSystem glitchEmitter2 = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig2, parent2, "_glitchEmitter");
																_glitchEmitter2 = glitchEmitter2;
																Transform transform2 = _glitchEmitter2.transform;
																bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																Vector3 value2 = default(Vector3);
																Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
																RenderingExtensions.SetDepth(_glitchEmitter2, 3000);
																_ = _glitchEmitter;
																_ = _glitchEmitter;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																object obj3 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																if ((nint)0 == 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																	bool flag5 = obj3 == null;
																}
																object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 520));
																Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3244 @ rax_v135 (should have been resolved before IL gen)");
																if ((object)_glitchEmitter2 != null)
																{
																	_ = _glitchEmitter2;
																	_ = _glitchEmitter2;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																	object obj5 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																	if ((nint)0 == 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																		bool flag6 = obj5 == null;
																	}
																	object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 520));
																	Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3331 @ rax_v140 (should have been resolved before IL gen)");
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

	public override void OnFollowerAdded(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		float2 offset = default(float2);
		SpawnCartForCharacter(character, offset);
	}

	public BackgroundFoscariRun()
	{
		//IL_000b: Expected O, but got I4
		//IL_0020: Expected O, but got I8
		CartOffset = (float2)0;
		_ = 1061997773;
		_initialOffset = (Vector2)3204112712L;
		_ = 1085653647;
		_speedFactor = 1f;
		_accelerationMul = 1f;
		isFirstUpdate = true;
		_loopLength = 12000;
		_itemLoopDelay = 5000f;
		base._002Ector();
	}
}
