using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundManager : GameMonoBehaviour
{
	protected Camera _mainCamera;

	public Bounds _camBounds;

	protected SignalBus _signalBus;

	private bool _003CIsBackgroundActive_003Ek__BackingField = true;

	private bool _003CAlias_003Ek__BackingField;

	private bool _003CHasMovingBg_003Ek__BackingField;

	private bool _003CDisableMovingBg_003Ek__BackingField;

	protected float _pickupLimitX = -40f;

	protected float _pickupRecycleOffset = 40f;

	public float RacingBoundsMinY = -20.8f;

	public float RacingBoundsMaxY = -18f;

	public float RacingBoundsFlyingEnemiesY = -15f;

	public float CharmMod = 1f;

	public float CurseMod = 1f;

	private int _003CxxlBatsDefeated_003Ek__BackingField;

	public Stack<SuperTile> dynamicWallTiles;

	private bool IsBackgroundActive
	{
		get
		{
			return _003CIsBackgroundActive_003Ek__BackingField;
		}
		set
		{
			_003CIsBackgroundActive_003Ek__BackingField = value;
		}
	}

	public bool Alias
	{
		get
		{
			return _003CAlias_003Ek__BackingField;
		}
		protected set
		{
			_003CAlias_003Ek__BackingField = value;
		}
	}

	public bool HasMovingBg
	{
		get
		{
			return _003CHasMovingBg_003Ek__BackingField;
		}
		protected set
		{
			_003CHasMovingBg_003Ek__BackingField = value;
		}
	}

	public bool DisableMovingBg
	{
		get
		{
			return _003CDisableMovingBg_003Ek__BackingField;
		}
		set
		{
			_003CDisableMovingBg_003Ek__BackingField = value;
		}
	}

	public PhaserScene scene
	{
		get
		{
			if ((object)GM.Core == null)
			{
				return (PhaserScene)(object)new NullReferenceException();
			}
			return ArcadePhysics.s_scene;
		}
	}

	public virtual bool SpawnEnemiesOnStart => true;

	public int xxlBatsDefeated
	{
		get
		{
			return _003CxxlBatsDefeated_003Ek__BackingField;
		}
		set
		{
			_003CxxlBatsDefeated_003Ek__BackingField = value;
		}
	}

	public virtual void Awake()
	{
		Camera main = Camera.main;
		_mainCamera = main;
		_camBounds = (Bounds)CameraExtensions.OrthographicBounds(_mainCamera).m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v5 (UnityEngine.Bounds)+10]");
		_ = 0;
	}

	protected override void OnDestroy()
	{
		Action<UISignals.ToggleMovingBackgroundSignal> action = null;
		((BackgroundManager)(object)action).ToggleMovingBackground((UISignals.ToggleMovingBackgroundSignal)this);
		((BackgroundManager)(object)_signalBus).ToggleMovingBackground((UISignals.ToggleMovingBackgroundSignal)action);
	}

	protected override void OnUpdate()
	{
		_camBounds = (Bounds)CameraExtensions.OrthographicBounds(_mainCamera).m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v3 (UnityEngine.Bounds)+10]");
		_ = 0;
	}

	public virtual void Create()
	{
		GameManager core = GM.Core;
		_signalBus = core._signalBus;
		Action<UISignals.ToggleMovingBackgroundSignal> action = null;
		((BackgroundManager)(object)action).ToggleMovingBackground((UISignals.ToggleMovingBackgroundSignal)this);
		((BackgroundManager)(object)_signalBus).ToggleMovingBackground((UISignals.ToggleMovingBackgroundSignal)action);
		_003CIsBackgroundActive_003Ek__BackingField = true;
	}

	public virtual void OnInitCompleted()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		config._003CDisableMovingBackground_003Ek__BackingField = false;
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		_003CDisableMovingBg_003Ek__BackingField = config2._003CDisableMovingBackground_003Ek__BackingField;
		if (!config2._003CDisableMovingBackground_003Ek__BackingField)
		{
			EnableMovingBackground();
		}
		else
		{
			DisableMovingBackground();
		}
	}

	public virtual void CustomPreload(Action onComplete)
	{
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public virtual void Cleanup()
	{
		_003CIsBackgroundActive_003Ek__BackingField = false;
	}

	public virtual void RosaryTriggered()
	{
	}

	private void ToggleMovingBackground(UISignals.ToggleMovingBackgroundSignal sig)
	{
		//IL_000a: Expected I4, but got O
		_003CDisableMovingBg_003Ek__BackingField = (byte)(int)sig != 0;
		if ((object)sig == null)
		{
			EnableMovingBackground();
		}
		else
		{
			DisableMovingBackground();
		}
	}

	private void HandleDisableMovingBackground()
	{
		if (!_003CDisableMovingBg_003Ek__BackingField)
		{
			EnableMovingBackground();
		}
		else
		{
			DisableMovingBackground();
		}
	}

	public virtual void CheckMinute(int minute)
	{
	}

	public virtual void DisableMovingBackground()
	{
	}

	public virtual void EnableMovingBackground()
	{
	}

	public virtual void CheckHalfMinute()
	{
	}

	public virtual void OnPropTriggered(PropType propType, PizzaCircle pizzaCircle, VampireSurvivors.Objects.Characters.CharacterController player)
	{
	}

	public virtual void OnItemTriggered(ItemType itemType, Pickup pickup, VampireSurvivors.Objects.Characters.CharacterController player)
	{
	}

	public virtual void OnPlayerEnteringDifferentTilemap()
	{
	}

	public void ResetPickupPositions()
	{
		//IL_003a: Expected O, but got I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		bool flag = GM.Core.IsStageVisuallyInverted();
		object obj = (flag ? 1 : 0) ^ 1;
		object obj2 = obj * 2;
		object obj3 = obj2 - 1;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		if (enumerator.MoveNext())
		{
			Component component = null;
			throw new NullReferenceException();
		}
	}

	public virtual void LoopPickupPositions()
	{
		bool flag = GM.Core.IsStageVisuallyInverted();
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		if (enumerator.MoveNext())
		{
			Component component = null;
			throw new NullReferenceException();
		}
	}

	public virtual void InitPickupForLoopingStage(Pickup pickup)
	{
	}

	public virtual string GetDetailedMap(StageData stageData)
	{
		if (stageData != null)
		{
			Tileset tileset = stageData._003Ctileset_003Ek__BackingField;
			if (stageData._003Ctileset_003Ek__BackingField != null)
			{
				return tileset._003CdetailsTexture_003Ek__BackingField;
			}
		}
		return null;
	}

	public virtual string GetDetailedMapStaticBackgroundImage(StageData stageData)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3DA7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return "";
	}

	public unsafe virtual void SetupDarknessFog(ref PhaserSprite fog, ref PhaserSprite fogEdgeA, ref PhaserSprite fogEdgeB)
	{
		//IL_0186: Expected O, but got I4
		//IL_077e: Expected O, but got I4
		//IL_06d3: Expected O, but got I4
		//IL_06e8: Invalid comparison between F4 and O
		//IL_02f2: Expected F4, but got I4
		//IL_0395: Expected O, but got I4
		//IL_0732: Expected O, but got I4
		//IL_0510: Expected O, but got I4
		//IL_0764: Expected O, but got I4
		//IL_0111->IL060e: Incompatible stack heights: 1 vs 0
		//IL_0140->IL060e: Incompatible stack heights: 1 vs 0
		//IL_016f->IL060e: Incompatible stack heights: 1 vs 0
		//IL_01a2->IL060e: Incompatible stack heights: 1 vs 0
		//IL_01cc->IL060e: Incompatible stack heights: 1 vs 0
		//IL_0209->IL060e: Incompatible stack heights: 1 vs 0
		//IL_0246->IL060e: Incompatible stack heights: 1 vs 0
		//IL_027f->IL060e: Incompatible stack heights: 1 vs 0
		//IL_02ae->IL060e: Incompatible stack heights: 1 vs 0
		//IL_034f->IL060e: Incompatible stack heights: 2 vs 0
		//IL_037e->IL060e: Incompatible stack heights: 2 vs 0
		//IL_03b1->IL060e: Incompatible stack heights: 2 vs 0
		//IL_03db->IL060e: Incompatible stack heights: 2 vs 0
		//IL_041d->IL060e: Incompatible stack heights: 2 vs 0
		//IL_044c->IL060e: Incompatible stack heights: 2 vs 0
		//IL_0476->IL060e: Incompatible stack heights: 2 vs 0
		//IL_04ca->IL060e: Incompatible stack heights: 2 vs 0
		//IL_04f9->IL060e: Incompatible stack heights: 2 vs 0
		//IL_052c->IL060e: Incompatible stack heights: 2 vs 0
		//IL_0556->IL060e: Incompatible stack heights: 2 vs 0
		//IL_0598->IL060e: Incompatible stack heights: 2 vs 0
		//IL_05c7->IL060e: Incompatible stack heights: 2 vs 0
		//IL_05f1->IL060e: Incompatible stack heights: 2 vs 0
		if ((object)_mainCamera != null)
		{
			Transform transform = _mainCamera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Camera main = Camera.main;
				Bounds bounds = CameraExtensions.OrthographicBounds(main);
				Vector2 vector = default(Vector2);
				float num = (float)vector * 2f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v974 @ rax_v28 (UnityEngine.Bounds)+10]");
				float num2 = 0f * 2f;
				Camera main2 = Camera.main;
				Bounds bounds2 = CameraExtensions.OrthographicBoundsIgnoringBorders(main2);
				float num3 = (float)vector * 2f;
				float num4 = ((num2 > num) ? num : (num / 1.5999999f));
				GameObject gameObject = base.gameObject;
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "vfx", "fog");
				if ((object)phaserSprite != null)
				{
					PhaserSprite phaserSprite2 = phaserSprite.setAlpha(1f);
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite phaserSprite3 = phaserSprite2.setDepth(3001);
						if ((object)phaserSprite3 != null)
						{
							PhaserSprite phaserSprite4 = phaserSprite3.setScale(num4, (float?)(object)1);
							if ((object)phaserSprite4 != null)
							{
								GameObject gameObject2 = phaserSprite4.gameObject;
								if ((object)gameObject2 != null)
								{
									((UnityEngine.Object)gameObject2).SetName("sDarkness");
									Transform transform2 = phaserSprite4.transform;
									if ((object)transform2 != null)
									{
										transform2.SetParent(transform, worldPositionStays: true);
										ref PhaserSprite reference = ref *(PhaserSprite*)phaserSprite4;
										if ((object)fog != null)
										{
											PhaserSprite phaserSprite5 = fog.setPosition(vector);
											PhaserSprite phaserSprite6 = fog;
											if ((object)fog != null)
											{
												GameObject spriteRenderer = (GameObject)(object)phaserSprite6._spriteRenderer;
												if ((object)phaserSprite6._spriteRenderer != null)
												{
													bool flag2 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
													Renderer.get_bounds_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out Bounds _);
													float num5 = num / num2;
													GameObject gameObject3 = (GameObject)Screen.width;
													object obj = Screen.height;
													object obj2 = (object)gameObject3 / obj;
													float originX;
													float originX2;
													if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) && !(1f > num5))
													{
														num3 -= num4;
														originX = 0f;
														originX2 = 1f;
													}
													else
													{
														originX = 0.5f;
														originX2 = 0.5f;
													}
													float xScale = num3 * 100f;
													GameObject gameObject4 = base.gameObject;
													PhaserSprite phaserSprite7 = RenderingExtensions.AddPhaserSprite(gameObject4, vector, "vfx", "blackDot");
													if ((object)phaserSprite7 != null)
													{
														PhaserSprite phaserSprite8 = phaserSprite7.setAlpha(1f);
														if ((object)phaserSprite8 != null)
														{
															PhaserSprite phaserSprite9 = phaserSprite8.setScale(xScale, (float?)(object)1);
															if ((object)phaserSprite9 != null)
															{
																GameObject gameObject5 = phaserSprite9.gameObject;
																if ((object)gameObject5 != null)
																{
																	((UnityEngine.Object)gameObject5).SetName("sDarknessExtraA");
																	PhaserSprite phaserSprite10 = phaserSprite9.setTint(0u);
																	if ((object)phaserSprite10 != null)
																	{
																		PhaserSprite phaserSprite11 = phaserSprite10.setDepth(3001);
																		if ((object)phaserSprite11 != null)
																		{
																			Transform transform3 = phaserSprite11.transform;
																			if ((object)transform3 != null)
																			{
																				transform3.SetParent(transform, worldPositionStays: true);
																				PhaserSprite phaserSprite12 = phaserSprite11.setOrigin(originX2, (float?)(object)1);
																				ref PhaserSprite reference2 = ref *(PhaserSprite*)phaserSprite12;
																				GameObject gameObject6 = base.gameObject;
																				PhaserSprite phaserSprite13 = RenderingExtensions.AddPhaserSprite(gameObject6, vector, "vfx", "blackDot");
																				if ((object)phaserSprite13 != null)
																				{
																					PhaserSprite phaserSprite14 = phaserSprite13.setAlpha(1f);
																					if ((object)phaserSprite14 != null)
																					{
																						PhaserSprite phaserSprite15 = phaserSprite14.setScale(xScale, (float?)(object)1);
																						if ((object)phaserSprite15 != null)
																						{
																							GameObject gameObject7 = phaserSprite15.gameObject;
																							if ((object)gameObject7 != null)
																							{
																								((UnityEngine.Object)gameObject7).SetName("sDarknessExtraB");
																								PhaserSprite phaserSprite16 = phaserSprite15.setTint(0u);
																								if ((object)phaserSprite16 != null)
																								{
																									PhaserSprite phaserSprite17 = phaserSprite16.setDepth(3001);
																									if ((object)phaserSprite17 != null)
																									{
																										Transform transform4 = phaserSprite17.transform;
																										if ((object)transform4 != null)
																										{
																											transform4.SetParent(transform, worldPositionStays: true);
																											PhaserSprite phaserSprite18 = phaserSprite17.setOrigin(originX, (float?)(object)1);
																											ref PhaserSprite reference3 = ref *(PhaserSprite*)phaserSprite18;
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
		throw new NullReferenceException();
	}

	public void ContainWithinRacingBounds(Transform target)
	{
		//IL_006b: Invalid comparison between F4 and O
		//IL_0014: Invalid comparison between O and F4
		bool flag = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)target).m_CachedPtr, out Vector3 _);
		float racingBoundsMinY = RacingBoundsMinY;
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)racingBoundsMinY) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)RacingBoundsMaxY))
		{
		}
		bool flag2 = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)target).m_CachedPtr, ref value);
	}

	public virtual bool ShouldPlayNormalMusic()
	{
		return true;
	}

	public virtual void OnFollowerAdded(VampireSurvivors.Objects.Characters.CharacterController character)
	{
	}

	public virtual float GetKillRatio()
	{
		//IL_0013: Invalid comparison between F4 and I4
		//IL_002c: Expected F4, but got I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected I4, but got Unknown
		//IL_00aa: Expected F4, but got I4
		GameManager core = GM.Core;
		float result;
		if ((object)GM.Core != null)
		{
			bool flag = core._003CSurvivedSeconds_003Ek__BackingField == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186F83FAFh\"");
			result = 0f;
			if (flag)
			{
				goto IL_00e6;
			}
			if (core._playerOptions != null)
			{
				PlayerOptionsData config = core._playerOptions.Config;
				if (config != null)
				{
					int num = (int)(config._003CRunEnemies_003Ek__BackingField / core._003CSurvivedSeconds_003Ek__BackingField);
					result = num;
					goto IL_00e6;
				}
			}
		}
		throw new NullReferenceException();
		IL_00e6:
		return result;
	}

	public virtual bool ShouldShowCursor(float2 position)
	{
		return true;
	}

	public virtual bool HasCustomMapRules()
	{
		return false;
	}

	public virtual bool HasCustomMadGrooveRestriction()
	{
		return false;
	}

	public virtual bool IsPositionPulledByMadGroove(float2 position)
	{
		return true;
	}

	public virtual bool HasExtraSafeXYLogic()
	{
		return false;
	}

	public virtual float2 ExtraSafeXY(float2 position, float2 playerPosition)
	{
		return position;
	}

	public virtual float GetMap_SizeX()
	{
		return 20.48f;
	}

	public virtual float GetMap_SizeY()
	{
		return 20.48f;
	}

	public virtual float2 GetMap_PlayerPos()
	{
		//IL_0158: Expected I, but got O
		//IL_0176: Expected I, but got O
		GameManager core = GM.Core;
		ArcadeSprite arcadeSprite;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					GameSessionData gameSessionData = core2._gameSessionData;
					if (core2._gameSessionData != null)
					{
						arcadeSprite = gameSessionData._activeCharacter;
						if ((object)gameSessionData._activeCharacter != null)
						{
							goto IL_0146;
						}
					}
				}
			}
			else if ((object)OnlineStageManager._instance != null)
			{
				int mySeatNumber = OnlineStageManager._instance.GetMySeatNumber();
				if ((object)OnlineStageManager._instance != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterForSeatNumber = OnlineStageManager._instance.GetCharacterForSeatNumber(mySeatNumber);
					if ((object)characterForSeatNumber != null)
					{
						arcadeSprite = characterForSeatNumber;
						goto IL_0146;
					}
				}
			}
		}
		return (float2)new NullReferenceException();
		IL_0146:
		float2 position = arcadeSprite.position;
		nint num = (nint)this;
		float map_SizeX = GetMap_SizeX();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		nint num2 = (nint)this;
		float map_SizeY = GetMap_SizeY();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		float2 result = default(float2);
		return result;
	}

	public virtual int GetMap_SupportHorizontal()
	{
		return 0;
	}

	public virtual bool GetMap_DrawGrid()
	{
		return true;
	}

	public virtual bool ShouldShowPickupIconOnMap(Vector3 worldPosition)
	{
		return true;
	}

	public Vector2 GetPlayerStartingPosition()
	{
		//IL_0220: Expected I, but got O
		//IL_0153: Expected I, but got O
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				Transform tilingTileset = (Transform)(object)stage._tilingTileset;
				Vector2 result = default(Vector2);
				if ((object)stage._tilingTileset == null || ((UnityEngine.Object)tilingTileset).m_CachedPtr == (IntPtr)0)
				{
					return result;
				}
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					Stage stage2 = core2._stage;
					if ((object)core2._stage != null && (object)stage2._tilingTileset != null)
					{
						List<SuperObject> scriptsFromName = stage2._tilingTileset.GetScriptsFromName("PlayerStart");
						SuperObject superObject = Enumerable.FirstOrDefault(scriptsFromName);
						bool flag = (object)superObject == null;
						nint num = (nint)typeof(UnityEngine.Object);
						if (!flag)
						{
							bool flag2 = ((UnityEngine.Object)superObject).m_CachedPtr == (IntPtr)0;
							num = (nint)typeof(UnityEngine.Object);
							if (!flag2)
							{
								Transform transform = superObject.transform;
								if ((object)transform != null)
								{
									bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
									return result;
								}
								goto IL_01a9;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
						Vector2 result2 = default(Vector2);
						return result2;
					}
				}
			}
		}
		goto IL_01a9;
		IL_01a9:
		throw new NullReferenceException();
	}

	public BackgroundManager()
	{
		Stack<SuperTile> stack = new Stack<SuperTile>();
		dynamicWallTiles = stack;
		base._onResumeSent = true;
	}
}
