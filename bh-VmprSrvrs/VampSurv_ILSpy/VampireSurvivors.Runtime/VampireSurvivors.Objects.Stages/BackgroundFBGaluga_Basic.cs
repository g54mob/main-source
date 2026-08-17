using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.Speedup;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundFBGaluga_Basic : BackgroundManager
{
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public float2 mainPosition;

		internal void _003CSpawnSimondo_003Eb__0()
		{
			GameManager core = GM.Core;
			Vector2 spawnPos = default(Vector2);
			bool forceSpawn = default(bool);
			GameObject gameObject = core._stage.SpawnEnemy(EnemyType.FB_SIMONDO, spawnPos, asRemote: false, forceSpawn);
			EnemyController component = gameObject.GetComponent<EnemyController>();
			component._003CIsCullable_003Ek__BackingField = false;
		}
	}

	private TilingTileset _tilingTileset;

	private float _mapHeight;

	private bool _hasSpawnedBigFuzz;

	private EnemyBigFuzz _bigFuzz;

	private Color _dayColor;

	private Color _nightColor;

	private Light2D _globalLight;

	private List<Vector2> _exploCarLocations;

	private List<Vector2> _exploBarrelLocations;

	private Timer _destructibleTimer;

	private float DestructibleFrequency = 5000f;

	[NonSerialized]
	public PhaserSprite _leftDoor;

	[NonSerialized]
	public PhaserSprite _rightDoor;

	[NonSerialized]
	public PhaserSprite _doorFrame;

	[NonSerialized]
	public PhaserSprite _doorSpace;

	[NonSerialized]
	public PhaserSprite _doorMask;

	private PhaserSprite _waterAnim;

	private TileSprite _water;

	private Timer _simondoTimer;

	private const float DayCycleDuration = 1800f;

	public override void Awake()
	{
		//IL_0181: Expected O, but got I4
		base.Awake();
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "firstBlood", "_fb_water_tiles_01");
		PhaserSprite waterAnim = phaserSprite.setVisible(visible: false);
		_waterAnim = waterAnim;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("_fb_water_tiles_0", 1, 8, "firstBlood", num);
		PhaserSprite waterAnim2 = _waterAnim;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		waterAnim2._spriteAnimation.AddAnimation("loop", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite waterAnim3 = _waterAnim;
		waterAnim3._spriteAnimation.SetAnimation("loop");
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene2._renderer;
				float y = renderer2.height * 0.5f;
				float x = renderer.width * 0.5f;
				GameObject go = base.gameObject;
				TileSpriteBuilder tileSpriteBuilder = RenderingExtensions.AddTileSprite(go, x, y, "firstBlood", (string)num);
				tileSpriteBuilder._depth = -10001f;
				tileSpriteBuilder._depthMul = 1f;
				Transform parent = base.transform;
				tileSpriteBuilder._parent = parent;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer3 = s_scene3._renderer;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene4 = ArcadePhysics.s_scene;
						PhaserScene.Renderer renderer4 = s_scene4._renderer;
						tileSpriteBuilder._tileHeight = renderer4.height;
						tileSpriteBuilder._tileWidth = renderer3.width;
						tileSpriteBuilder._name = "Water";
						TileSprite water = tileSpriteBuilder.Build();
						_water = water;
						TileSprite tileSprite = RenderingExtensions.SetScrollFactor(_water, 0f);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Create()
	{
		//IL_007c: Expected O, but got I4
		base.Create();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		SuperMap defaultMap = stage._tilingTileset.DefaultMap;
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		SuperMap defaultMap2 = stage2._tilingTileset.DefaultMap;
		object obj = defaultMap.m_TileHeight * defaultMap2.m_Height;
		float mapHeight = (float)obj * 0.01f;
		_mapHeight = mapHeight;
		GameManager core3 = GM.Core;
		Stage stage3 = core3._stage;
		_tilingTileset = stage3._tilingTileset;
		List<Vector2> specialLocations = _tilingTileset.GetSpecialLocations("ExploCarProp");
		_exploCarLocations = specialLocations;
		List<Vector2> specialLocations2 = _tilingTileset.GetSpecialLocations("ExploBarrelProp");
		_exploBarrelLocations = specialLocations2;
		Color color = default(Color);
		_dayColor = color;
		_nightColor = color;
		GameManager core4 = GM.Core;
		PlayerOptionsData config = core4._playerOptions.Config;
		if (config._003CSelectedInverse_003Ek__BackingField)
		{
			_dayColor = color;
			_nightColor = color;
		}
		GameManager core5 = GM.Core;
		_globalLight = core5._GlobalLight;
		Light2D globalLight = _globalLight;
		globalLight.m_Intensity = 0.5f;
		Light2D globalLight2 = _globalLight;
		globalLight2.m_BlendStyleIndex = 0;
		Light2D globalLight3 = _globalLight;
		globalLight3.m_LightOrder = 17;
		Light2D globalLight4 = _globalLight;
		globalLight4.m_OverlapOperation = Light2D.OverlapOperation.AlphaBlend;
		if (_destructibleTimer != null)
		{
			_destructibleTimer.Cancel();
		}
		Action onComplete = HandleDestructibleSpawning;
		float duration = DestructibleFrequency * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer destructibleTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_destructibleTimer = destructibleTimer;
		SpawnBigFuzzBattleLocation();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 822 Invalid \"Jump target not found in method: 0x186F5C9D0\"");
		throw new NullReferenceException();
	}

	public override void OnInitCompleted()
	{
		//IL_001e: Expected I, but got O
		base.OnInitCompleted();
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			nint num = (nint)typeof(UnityEngine.Object);
			throw new NullReferenceException();
		}
	}

	protected void SpawnSimondo()
	{
		//IL_011b: Expected I4, but got I8
		//IL_0129: Expected O, but got I4
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass22_0();
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		List<Vector2> specialLocations = _tilingTileset.GetSpecialLocations("BossPlateSpawn");
		if (specialLocations == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rax_v7 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			float2 mainPosition = default(float2);
			CS_0024_003C_003E8__locals1.mainPosition = mainPosition;
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			int num = config._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.FB_SIMONDO);
			Action onComplete = delegate
			{
				GameManager core2 = GM.Core;
				Vector2 spawnPos = default(Vector2);
				bool forceSpawn = default(bool);
				GameObject gameObject = core2._stage.SpawnEnemy(EnemyType.FB_SIMONDO, spawnPos, asRemote: false, forceSpawn);
				EnemyController component = gameObject.GetComponent<EnemyController>();
				component._003CIsCullable_003Ek__BackingField = false;
			};
			int num2 = num >> 31;
			int num3 = (int)(num2 & 0xFFF24460L);
			object obj = num3 + 1200000;
			float duration = (float)obj * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer simondoTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_simondoTimer = simondoTimer;
		}
	}

	protected void SpawnBigFuzzBattleLocation()
	{
		//IL_0092: Expected O, but got I
		//IL_08cf: Expected O, but got I4
		//IL_0afd: Expected O, but got I4
		//IL_0175: Expected O, but got I4
		//IL_0931: Expected I4, but got I8
		//IL_029d: Expected O, but got I4
		//IL_09a0: Expected I4, but got I8
		//IL_03c5: Expected O, but got I4
		//IL_0a0f: Expected I4, but got I8
		//IL_04ed: Expected O, but got I4
		//IL_0a78: Expected I4, but got I8
		//IL_0605: Expected O, but got I4
		//IL_0ad3: Expected I4, but got I8
		//IL_00b2->IL0894: Incompatible stack heights: 1 vs 0
		//IL_0130->IL0894: Incompatible stack heights: 1 vs 0
		//IL_015e->IL0894: Incompatible stack heights: 1 vs 0
		//IL_0191->IL0894: Incompatible stack heights: 1 vs 0
		//IL_01bb->IL0894: Incompatible stack heights: 1 vs 0
		//IL_094d->IL0894: Incompatible stack heights: 2 vs 0
		//IL_0258->IL0894: Incompatible stack heights: 2 vs 0
		//IL_0286->IL0894: Incompatible stack heights: 2 vs 0
		//IL_02b9->IL0894: Incompatible stack heights: 2 vs 0
		//IL_02e3->IL0894: Incompatible stack heights: 2 vs 0
		//IL_09bc->IL0894: Incompatible stack heights: 3 vs 0
		//IL_0380->IL0894: Incompatible stack heights: 3 vs 0
		//IL_03ae->IL0894: Incompatible stack heights: 3 vs 0
		//IL_03e1->IL0894: Incompatible stack heights: 3 vs 0
		//IL_040b->IL0894: Incompatible stack heights: 3 vs 0
		//IL_0a2b->IL0894: Incompatible stack heights: 4 vs 0
		//IL_04a8->IL0894: Incompatible stack heights: 4 vs 0
		//IL_04d6->IL0894: Incompatible stack heights: 4 vs 0
		//IL_0509->IL0894: Incompatible stack heights: 4 vs 0
		//IL_0533->IL0894: Incompatible stack heights: 4 vs 0
		//IL_05af->IL0894: Incompatible stack heights: 5 vs 0
		//IL_05de->IL0894: Incompatible stack heights: 5 vs 0
		//IL_0621->IL0894: Incompatible stack heights: 5 vs 0
		//IL_064b->IL0894: Incompatible stack heights: 5 vs 0
		//IL_0aef->IL0894: Incompatible stack heights: 6 vs 0
		//IL_069a->IL0894: Incompatible stack heights: 6 vs 0
		//IL_06c6->IL0894: Incompatible stack heights: 6 vs 0
		//IL_070d->IL0894: Incompatible stack heights: 6 vs 0
		//IL_0743->IL0894: Incompatible stack heights: 6 vs 0
		//IL_0765->IL0894: Incompatible stack heights: 6 vs 0
		//IL_07a1->IL0894: Incompatible stack heights: 6 vs 0
		//IL_07c3->IL0894: Incompatible stack heights: 6 vs 0
		//IL_07f5->IL0894: Incompatible stack heights: 6 vs 0
		//IL_0851->IL0894: Incompatible stack heights: 6 vs 0
		//IL_0893->IL0893: Incompatible stack heights: 6 vs 0
		if ((object)_tilingTileset != null)
		{
			List<Vector2> specialLocations = _tilingTileset.GetSpecialLocations("BossSpawn");
			if (specialLocations == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v39 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 <= (nint)0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v39 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			bool flag = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v39 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v39 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rax_v41+18]");
				if ((nint)0 <= (nint)0)
				{
					throw new IndexOutOfRangeException();
				}
				float? num = (float?)(object)Screen.height;
				object obj2 = Screen.width;
				float num2 = ((System.Runtime.CompilerServices.Unsafe.As<float?, UIntPtr>(ref num) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2)) ? 2f : 1.7f);
				float num3 = 2f / num2;
				Vector2 vector = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(this, vector, "firstBlood", "DoorLeft");
				if ((object)phaserSprite != null)
				{
					PhaserSprite phaserSprite2 = phaserSprite.setOrigin(vector);
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite phaserSprite3 = phaserSprite2.setScale(num2, (float?)(object)0);
						if ((object)phaserSprite3 != null)
						{
							Transform transform = phaserSprite3.transform;
							if ((object)transform != null)
							{
								bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								nint num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1433 @ rcx_v47 (Il2CppMethodInfo)+38]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
								}
								Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
								PhaserSprite phaserSprite4 = phaserSprite3.setDepth(-1620);
								if ((object)phaserSprite4 != null)
								{
									PhaserSprite leftDoor = phaserSprite4.setTint(8947848u);
									_leftDoor = leftDoor;
									PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(this, vector, "firstBlood", "DoorRight");
									if ((object)phaserSprite5 != null)
									{
										PhaserSprite phaserSprite6 = phaserSprite5.setOrigin(vector);
										if ((object)phaserSprite6 != null)
										{
											PhaserSprite phaserSprite7 = phaserSprite6.setScale(num2, (float?)(object)0);
											if ((object)phaserSprite7 != null)
											{
												Transform transform2 = phaserSprite7.transform;
												if ((object)transform2 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v64 (UnityEngine.Transform)+10]");
													bool flag3 = (nint)0 == 0;
													nint num5 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1833 @ rcx_v58 (Il2CppMethodInfo)+38]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v64 (UnityEngine.Transform)+10]");
													Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
													PhaserSprite phaserSprite8 = phaserSprite7.setDepth(-1620);
													if ((object)phaserSprite8 != null)
													{
														PhaserSprite rightDoor = phaserSprite8.setTint(8947848u);
														_rightDoor = rightDoor;
														PhaserSprite phaserSprite9 = RenderingExtensions.AddPhaserSprite(this, vector, "firstBlood", "DoorFrame");
														if ((object)phaserSprite9 != null)
														{
															PhaserSprite phaserSprite10 = phaserSprite9.setOrigin(vector);
															if ((object)phaserSprite10 != null)
															{
																PhaserSprite phaserSprite11 = phaserSprite10.setScale(num2, (float?)(object)0);
																if ((object)phaserSprite11 != null)
																{
																	Transform transform3 = phaserSprite11.transform;
																	if ((object)transform3 != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v76 (UnityEngine.Transform)+10]");
																		bool flag4 = (nint)0 == 0;
																		nint num6 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1959 @ rcx_v69 (Il2CppMethodInfo)+38]");
																		if ((nint)0 == 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v76 (UnityEngine.Transform)+10]");
																		Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
																		PhaserSprite phaserSprite12 = phaserSprite11.setDepth(-1610);
																		if ((object)phaserSprite12 != null)
																		{
																			PhaserSprite doorFrame = phaserSprite12.setTint(8947848u);
																			_doorFrame = doorFrame;
																			PhaserSprite phaserSprite13 = RenderingExtensions.AddPhaserSprite(this, vector, "firstBlood", "DoorSpace");
																			if ((object)phaserSprite13 != null)
																			{
																				PhaserSprite phaserSprite14 = phaserSprite13.setOrigin(vector);
																				if ((object)phaserSprite14 != null)
																				{
																					PhaserSprite phaserSprite15 = phaserSprite14.setScale(num2, (float?)(object)0);
																					if ((object)phaserSprite15 != null)
																					{
																						Transform transform4 = phaserSprite15.transform;
																						if ((object)transform4 != null)
																						{
																							bool flag5 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
																							nint num7 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2085 @ rcx_v80 (Il2CppMethodInfo)+38]");
																							if ((nint)0 == 0)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
																							}
																							Transform.SetParent_Injected(((UnityEngine.Object)transform4).m_CachedPtr, (IntPtr)0, true);
																							PhaserSprite doorSpace = phaserSprite15.setDepth(-1700);
																							_doorSpace = doorSpace;
																							PhaserSprite phaserSprite16 = RenderingExtensions.AddPhaserSprite(this, vector, "vfx", "WhiteDot");
																							if ((object)phaserSprite16 != null)
																							{
																								PhaserSprite phaserSprite17 = phaserSprite16.setOrigin(vector);
																								if ((object)phaserSprite17 != null)
																								{
																									float xScale = num2 * 250f;
																									PhaserSprite phaserSprite18 = phaserSprite17.setScale(xScale, (float?)(object)1);
																									if ((object)phaserSprite18 != null)
																									{
																										Transform transform5 = phaserSprite18.transform;
																										if ((object)transform5 != null)
																										{
																											bool flag6 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
																											Transform.SetParent_Injected(((UnityEngine.Object)transform5).m_CachedPtr, (IntPtr)0, true);
																											PhaserSprite phaserSprite19 = phaserSprite18.setDepth(-1700);
																											if ((object)phaserSprite19 != null)
																											{
																												PhaserSprite doorMask = phaserSprite19.setVisible(visible: false);
																												_doorMask = doorMask;
																												if ((object)_doorMask != null)
																												{
																													GameObject gameObject = _doorMask.gameObject;
																													if ((object)gameObject != null)
																													{
																														SpriteMask spriteMask = gameObject.AddComponent<SpriteMask>();
																														Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
																														if ((object)spriteMask != null)
																														{
																															spriteMask.sprite = sprite;
																															PhaserSprite leftDoor2 = _leftDoor;
																															if ((object)_leftDoor != null && (object)leftDoor2._spriteRenderer != null)
																															{
																																leftDoor2._spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
																																PhaserSprite rightDoor2 = _rightDoor;
																																if ((object)_rightDoor != null && (object)rightDoor2._spriteRenderer != null)
																																{
																																	rightDoor2._spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
																																	if ((object)_leftDoor != null)
																																	{
																																		float width = _leftDoor.Width;
																																		float num8 = width * 0.25f;
																																		float num9 = num8 * num3;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
																																		if ((object)_rightDoor != null)
																																		{
																																			float width2 = _rightDoor.Width;
																																			float num10 = width2 * 0.25f;
																																			float num11 = num10 * num3;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
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

	protected unsafe void HandleDestructibleSpawning()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected Ref, but got Unknown
		GameManager core = GM.Core;
		Destructible destructible = core._stage.SpawnPropInRandomLocation(60f, PropType.FB_EXPLOCAR, ref *(List<Vector2>*)(this + 192));
		GameManager core2 = GM.Core;
		core2._stage.SpawnChocenDestructibleOutOfSight(PropType.FB_EXPLOBARREL);
	}

	protected override void OnUpdate()
	{
		//IL_0094: Expected F4, but got O
		//IL_00b0: Expected F4, but got O
		//IL_00eb: Expected F4, but got I
		//IL_010a: Expected F4, but got I
		if (!_hasSpawnedBigFuzz)
		{
			UpdateDayNight();
		}
		PhaserSprite waterAnim = _waterAnim;
		Sprite sprite = waterAnim._spriteRenderer.sprite;
		string frameName = ((UnityEngine.Object)sprite).GetName();
		_water.SetFrame(frameName, "firstBlood");
		TileSprite water = _water;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		water._xScrollOffset = (float)renderer.screenCenter;
		water._spriteScroller.SetScrollOffsetX((float)renderer.screenCenter);
		TileSprite water2 = _water;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v19 (PhaserScene+Renderer)+38]");
		water2._yScrollOffset = 0f;
		SpriteScroller spriteScroller = water2._spriteScroller;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v19 (PhaserScene+Renderer)+38]");
		spriteScroller.SetScrollOffsetY(0f);
	}

	private void UpdateDayNight()
	{
		//IL_00e2: Expected I, but got O
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0119: Invalid comparison between I4 and F4
		//IL_00c1: Expected F4, but got I4
		//IL_00d3: Expected O, but got F4
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		float num3 = core._003CSurvivedSeconds_003Ek__BackingField / 1800f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj2 = default(object);
		object obj = obj2 & 1;
		float num4 = ((obj == null) ? core._003CSurvivedSeconds_003Ek__BackingField : (1800f - core._003CSurvivedSeconds_003Ek__BackingField));
		float num5 = num4 / 1800f;
		if (!(0f > num5))
		{
			if (num5 > 1f)
			{
				num5 = 1f;
			}
		}
		else
		{
			num5 = 0f;
		}
		object obj3 = _nightColor - _dayColor;
		float num6 = (float)obj3 * num5;
		float num7 = num6 + (float)_dayColor;
		Light2D globalLight = _globalLight;
		globalLight.m_Color = (Color)num7;
	}

	public void SetBigFuzzObject(EnemyBigFuzz bigFuzz)
	{
		_bigFuzz = bigFuzz;
	}

	private void LateUpdate()
	{
	}

	public override void Cleanup()
	{
		//IL_00e8: Expected O, but got I4
		EnemyBigFuzz bigFuzz = _bigFuzz;
		if ((object)_bigFuzz != null && ((UnityEngine.Object)bigFuzz).m_CachedPtr != (IntPtr)0)
		{
			EnemyBigFuzz bigFuzz2 = _bigFuzz;
			SpeedupManager instance = SpeedupManager.Instance;
			instance.SetSpeedupBlocked(isBlocked: false);
			if (bigFuzz2._removedEquipment != null)
			{
				GM.Core.GiveBackAllEquipmentToPlayers(bigFuzz2._removedEquipment);
			}
		}
		if (_simondoTimer != null)
		{
			_simondoTimer.Cancel();
		}
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		GameManager core = GM.Core;
		core._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
	}
}
