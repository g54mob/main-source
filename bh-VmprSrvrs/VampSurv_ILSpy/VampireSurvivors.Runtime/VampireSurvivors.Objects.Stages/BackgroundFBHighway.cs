using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using PhaserPort;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundFBHighway : BackgroundManager
{
	private float2 BikeOffset;

	private Vector2 _initialOffset;

	private TileSprite fb_bg_hw_Back;

	private TileSprite fb_bg_hw_Front;

	private float _speedFactor;

	private float _accelerationMul;

	private float _currentAcceleration;

	private float _yMul;

	private bool isFirstUpdate;

	private bool _created;

	private List<PhaserSprite> _frontCartSprites;

	private List<PhaserSprite> _backCartSprites;

	private List<float2> _cartOffsets;

	private float _distanceTravelled;

	private int _loopLength;

	private TilingTileset _tilingTileset;

	private int _loopsDone;

	private float _nextLoopDist;

	private float _inversionMul;

	private Timer _BarrelsSpawningTimer;

	private float _playerStartX;

	public unsafe override void Create()
	{
		//IL_0077: Expected I, but got O
		//IL_00a1: Expected O, but got I4
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00de: Expected I, but got O
		//IL_0108: Expected O, but got I4
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_0174: Expected I, but got O
		//IL_01a8: Expected I, but got O
		//IL_01ca: Expected I, but got O
		//IL_0237: Expected I, but got O
		//IL_0f57: Expected I, but got O
		//IL_028c: Expected I, but got O
		//IL_0365: Expected I, but got O
		//IL_02aa: Expected O, but got I
		//IL_02c6: Expected I, but got O
		//IL_02f3: Expected I, but got O
		//IL_0f7a: Expected I, but got O
		//IL_03ba: Expected I, but got O
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Expected F4, but got Unknown
		//IL_0f91: Expected I, but got O
		//IL_0faf: Expected I, but got O
		//IL_03d8: Expected O, but got I
		//IL_03f4: Expected I, but got O
		//IL_0468: Expected O, but got I
		//IL_048d: Expected I, but got O
		//IL_0421: Expected I, but got O
		//IL_04b9: Expected I, but got O
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Expected F4, but got Unknown
		//IL_04d5: Expected I, but got O
		//IL_0fc6: Expected I, but got O
		//IL_04ea: Expected O, but got I
		//IL_1032: Expected I, but got O
		//IL_0fed: Expected I, but got O
		//IL_05de: Expected O, but got I
		//IL_0571: Expected O, but got I
		//IL_0613: Expected F4, but got I
		//IL_05a6: Expected F4, but got I
		//IL_1059: Expected I, but got O
		//IL_062d: Expected O, but got I
		//IL_1080: Expected I, but got O
		//IL_0685: Expected O, but got I
		//IL_10ec: Expected I, but got O
		//IL_10a7: Expected I, but got O
		//IL_1113: Expected I, but got O
		//IL_0783: Expected O, but got I
		//IL_0898: Expected O, but got I4
		//IL_089d: Expected I, but got O
		//IL_08bd: Expected I4, but got I8
		//IL_08df: Expected O, but got I4
		//IL_08e4: Expected I, but got O
		//IL_091d: Expected O, but got I4
		//IL_0922: Expected I, but got O
		//IL_094d: Expected I, but got O
		//IL_0971: Expected O, but got I4
		//IL_1161: Expected I, but got O
		//IL_117a: Expected O, but got I4
		//IL_1188: Expected I, but got O
		//IL_0994: Expected O, but got I
		//IL_09b4: Expected O, but got I4
		//IL_09c2: Expected I, but got O
		//IL_09e9: Expected O, but got I4
		//IL_09f7: Expected I, but got O
		//IL_0a13: Expected I, but got O
		//IL_11b8: Expected O, but got I4
		//IL_0a42: Expected O, but got I4
		//IL_0ae9: Expected O, but got I4
		//IL_0aee: Expected I, but got O
		//IL_0b0e: Expected I4, but got I8
		//IL_0b30: Expected O, but got I4
		//IL_0b35: Expected I, but got O
		//IL_0b6e: Expected O, but got I4
		//IL_0b73: Expected I, but got O
		//IL_0b9e: Expected I, but got O
		//IL_0bcd: Expected O, but got I4
		//IL_0c11: Expected O, but got I4
		//IL_0c5b: Expected O, but got I4
		//IL_0c60: Expected I, but got O
		//IL_0c9f: Expected O, but got I4
		//IL_0ca4: Expected I, but got O
		//IL_0d30: Expected I, but got O
		//IL_11cf: Expected I, but got O
		//IL_11e8: Expected O, but got I4
		//IL_0d65: Expected O, but got I4
		//IL_0d81: Expected O, but got I4
		//IL_0d96: Expected O, but got I
		//IL_0da1: Expected O, but got F4
		//IL_0da6: Expected I, but got O
		//IL_0dae: Expected I, but got F4
		//IL_0dc5: Expected I, but got O
		//IL_0ddb: Expected O, but got I
		//IL_0de4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de9: Expected O, but got Unknown
		//IL_12d6: Expected F4, but got O
		//IL_0e79: Expected I, but got O
		//IL_126b: Expected O, but got I4
		//IL_1282: Expected I, but got I8
		//IL_12b0: Expected I4, but got O
		//IL_12b0: Expected I4, but got F4
		//IL_12c3: Expected I, but got O
		//IL_0e3b: Expected I, but got I8
		//IL_0f07: Expected F4, but got I4
		base.Create();
		Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
		Vector3 center = bounds.m_Center;
		_camBounds = (Bounds)bounds.m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v5 (UnityEngine.Bounds)+10]");
		_ = 0;
		bool flag = (object)GM.Core == null;
		nint num = unchecked((nint)null);
		float width;
		nint num3;
		if (!flag)
		{
			bool flag2 = GM.Core.IsStageVisuallyInverted();
			object obj = (flag2 ? 1 : 0) ^ 1;
			object obj2 = obj * 2;
			float inversionMul = (float)obj2 - 1f;
			_inversionMul = inversionMul;
			bool flag3 = (object)GM.Core == null;
			num = unchecked((nint)null);
			if (!flag3)
			{
				bool flag4 = GM.Core.IsStageVisuallyInverted();
				object obj3 = (flag4 ? 1 : 0) ^ 1;
				object obj4 = obj3 * 4;
				object obj5 = obj3 + obj4;
				object obj6 = obj5 << 4;
				float pickupLimitX = 40f - (float)obj6;
				_pickupLimitX = pickupLimitX;
				_pickupRecycleOffset = 40f;
				GameManager core = GM.Core;
				bool flag5 = (object)GM.Core == null;
				num = unchecked((nint)null);
				if (!flag5)
				{
					Stage stage = core._stage;
					bool flag6 = (object)core._stage == null;
					num = unchecked((nint)null);
					if (!flag6)
					{
						_tilingTileset = stage._tilingTileset;
						num = unchecked((nint)null);
						RacingBoundsMinY = -5.96f;
						RacingBoundsMaxY = -4.12f;
						RacingBoundsFlyingEnemiesY = -2f;
						if ((object)_tilingTileset != null)
						{
							List<Vector2> specialLocations = _tilingTileset.GetSpecialLocations("Racing_Bounds_Min_Y");
							bool flag7 = specialLocations == null;
							num = unchecked((nint)null);
							if (!flag7)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v963 @ rax_v33 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
								float num2;
								if ((nint)0 > (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v963 @ rax_v33 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
									bool flag8 = (nint)0 <= (nint)0;
									num = unchecked((nint)null);
									if (flag8)
									{
										goto IL_0f2a;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v963 @ rax_v33 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
									object obj7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v963 @ rax_v33 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
									bool flag9 = (nint)0 == 0;
									num = unchecked((nint)null);
									if (flag9)
									{
										goto IL_0f13;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v131+18]");
									bool flag10 = (nint)0 <= (nint)0;
									num = unchecked((nint)null);
									if (flag10)
									{
										goto IL_0f35;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v131+24]");
									float racingBoundsMinY = 0 ^ -0f;
									RacingBoundsMinY = racingBoundsMinY;
									num2 = -0f;
								}
								else
								{
									num2 = -0f;
								}
								bool flag11 = (object)_tilingTileset == null;
								num = unchecked((nint)null);
								if (!flag11)
								{
									List<Vector2> specialLocations2 = _tilingTileset.GetSpecialLocations("Racing_Bounds_Max_Y");
									bool flag12 = specialLocations2 == null;
									num = unchecked((nint)null);
									if (!flag12)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v964 @ rax_v34 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
										if ((nint)0 > (nint)0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v964 @ rax_v34 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
											bool flag13 = (nint)0 <= (nint)0;
											num = unchecked((nint)null);
											if (flag13)
											{
												goto IL_0f2a;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v964 @ rax_v34 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
											object obj8 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v964 @ rax_v34 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
											bool flag14 = (nint)0 == 0;
											num = unchecked((nint)null);
											if (flag14)
											{
												goto IL_0f13;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v130+18]");
											bool flag15 = (nint)0 <= (nint)0;
											num = unchecked((nint)null);
											if (flag15)
											{
												goto IL_0f35;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v130+24]");
											float racingBoundsMaxY = 0 ^ num2;
											RacingBoundsMaxY = racingBoundsMaxY;
										}
										bool flag16 = (object)GM.Core == null;
										num = unchecked((nint)null);
										if (!flag16)
										{
											num3 = (nint)ArcadePhysics.s_scene;
											bool flag17 = ArcadePhysics.s_scene == null;
											num = (nint)typeof(ArcadePhysics);
											if (!flag17)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
												object obj9 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
												bool flag18 = (nint)0 == 0;
												num = (nint)typeof(ArcadePhysics);
												if (!flag18)
												{
													bool flag19 = (object)GM.Core == null;
													num = (nint)typeof(ArcadePhysics);
													if (!flag19)
													{
														num = (nint)typeof(ArcadePhysics);
														num3 = (nint)ArcadePhysics.s_scene;
														if (ArcadePhysics.s_scene != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
															object obj10 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v967 @ rax_v42+14]");
																nint num4 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v965 @ rax_v38+10]");
																if (num4 > 0)
																{
																	if ((object)GM.Core != null)
																	{
																		num3 = (nint)ArcadePhysics.s_scene;
																		if (ArcadePhysics.s_scene != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
																			object obj11 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
																			if ((nint)0 != 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v179+14]");
																				width = 0f;
																				goto IL_100b;
																			}
																		}
																	}
																}
																else if ((object)GM.Core != null)
																{
																	num3 = (nint)ArcadePhysics.s_scene;
																	if (ArcadePhysics.s_scene != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
																		object obj12 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
																		if ((nint)0 != 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v970 @ rax_v175+10]");
																			width = 0f;
																			goto IL_100b;
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
		goto IL_0f13;
		IL_1262:
		object obj13 = 24;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		float num5 = default(float);
		string text = default(string);
		string text2 = default(string);
		TimerType type = default(TimerType);
		Timer barrelsSpawningTimer = Timers.Register(3.0000002f, action, null, isLooped: true, (byte)(int)num5 != 0, (MonoBehaviour)(object)text, (int)text2, type, isOnlineTimer: false, canPause: false);
		_BarrelsSpawningTimer = barrelsSpawningTimer;
		num = unchecked((nint)null);
		GameManager core2 = GM.Core;
		bool flag20 = (object)GM.Core == null;
		num3 = 1;
		if (!flag20)
		{
			bool flag21 = (object)core2._stage == null;
			num3 = 1;
			if (!flag21)
			{
				Weapon weapon = core2._stage.AddStageHazardWeapon(WeaponType.FB_EXPLOBARRELHAZARD);
				_loopsDone = 0;
				_nextLoopDist = _loopLength;
				_created = true;
				return;
			}
		}
		goto IL_0f13;
		IL_10c5:
		if ((object)GM.Core != null)
		{
			num3 = (nint)ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
				if ((nint)0 != 0 && (object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer = s_scene._renderer;
						if (s_scene._renderer != null)
						{
							float num6 = renderer.height * 0.5f;
							float y = num6 - 1f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v977 @ rax_v58+10]");
							float x = 0f * 0.5f;
							TileSprite component = RenderingExtensions.AddTileSprite(this, x, y, width, num5, text, text2);
							TileSprite tileSprite = RenderingExtensions.SetScrollFactor(component, 0f);
							bool flag22 = (object)tileSprite == null;
							num3 = 0;
							center = (Vector3)0;
							num = unchecked((nint)null);
							if (!flag22)
							{
								TileSprite tileSprite2 = tileSprite.SetDepth(-32767);
								bool flag23 = (object)tileSprite2 == null;
								num3 = 0;
								center = (Vector3)0;
								num = unchecked((nint)null);
								if (!flag23)
								{
									GameObject gameObject = tileSprite2.gameObject;
									bool flag24 = (object)gameObject == null;
									num3 = 0;
									center = (Vector3)0;
									num = unchecked((nint)null);
									if (!flag24)
									{
										((UnityEngine.Object)gameObject).SetName("fb_bg_hw_Back");
										fb_bg_hw_Back = tileSprite2;
										num = unchecked((nint)null);
										bool flag25 = (object)GM.Core == null;
										num3 = 0;
										center = (Vector3)0;
										if (!flag25)
										{
											num3 = (nint)ArcadePhysics.s_scene;
											bool flag26 = ArcadePhysics.s_scene == null;
											center = (Vector3)0;
											num = (nint)typeof(ArcadePhysics);
											if (!flag26)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
												object obj15 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
												bool flag27 = (nint)0 == 0;
												center = (Vector3)0;
												num = (nint)typeof(ArcadePhysics);
												if (!flag27)
												{
													bool flag28 = (object)GM.Core == null;
													center = (Vector3)0;
													num = (nint)typeof(ArcadePhysics);
													if (!flag28)
													{
														num = (nint)typeof(ArcadePhysics);
														PhaserScene s_scene2 = ArcadePhysics.s_scene;
														bool flag29 = ArcadePhysics.s_scene == null;
														center = (Vector3)0;
														if (!flag29)
														{
															PhaserScene.Renderer renderer2 = s_scene2._renderer;
															bool flag30 = s_scene2._renderer == null;
															center = (Vector3)0;
															if (!flag30)
															{
																float num7 = renderer2.height * 0.5f;
																float y2 = num7 - 1f;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v984 @ rax_v75+10]");
																float x2 = 0f * 0.5f;
																TileSprite component2 = RenderingExtensions.AddTileSprite(this, x2, y2, width, num5, text, text2);
																TileSprite tileSprite3 = RenderingExtensions.SetScrollFactor(component2, 0f);
																bool flag31 = (object)tileSprite3 == null;
																num3 = 0;
																center = (Vector3)0;
																num = unchecked((nint)null);
																if (!flag31)
																{
																	TileSprite tileSprite4 = tileSprite3.SetDepth(-32766);
																	bool flag32 = (object)tileSprite4 == null;
																	num3 = 0;
																	center = (Vector3)0;
																	num = unchecked((nint)null);
																	if (!flag32)
																	{
																		GameObject gameObject2 = tileSprite4.gameObject;
																		bool flag33 = (object)gameObject2 == null;
																		num3 = 0;
																		center = (Vector3)0;
																		num = unchecked((nint)null);
																		if (!flag33)
																		{
																			((UnityEngine.Object)gameObject2).SetName("fb_bg_hw_Front");
																			fb_bg_hw_Front = tileSprite4;
																			num = unchecked((nint)null);
																			TileSprite tileSprite5 = fb_bg_hw_Back;
																			bool flag34 = (object)fb_bg_hw_Back == null;
																			num3 = 0;
																			center = (Vector3)0;
																			if (!flag34)
																			{
																				Material material = MaterialManager.GetMaterial(MaterialType.ScrollableSprite);
																				bool flag35 = (object)tileSprite5._spriteRenderer == null;
																				num3 = 0;
																				center = (Vector3)0;
																				if (!flag35)
																				{
																					((Renderer)tileSprite5._spriteRenderer).SetMaterial(material);
																					TileSprite tileSprite6 = fb_bg_hw_Front;
																					bool flag36 = (object)fb_bg_hw_Front == null;
																					num3 = 0;
																					center = (Vector3)0;
																					num = unchecked((nint)null);
																					if (!flag36)
																					{
																						Material material2 = MaterialManager.GetMaterial(MaterialType.ScrollableSprite);
																						bool flag37 = (object)tileSprite6._spriteRenderer == null;
																						num3 = 0;
																						center = (Vector3)0;
																						num = unchecked((nint)null);
																						if (!flag37)
																						{
																							((Renderer)tileSprite6._spriteRenderer).SetMaterial(material2);
																							List<PhaserSprite> frontCartSprites = new List<PhaserSprite>();
																							_frontCartSprites = frontCartSprites;
																							List<PhaserSprite> backCartSprites = new List<PhaserSprite>();
																							_backCartSprites = backCartSprites;
																							List<float2> list = null;
																							TileSprite tileSprite7 = RenderingExtensions.SetScrollFactor((TileSprite)(object)list, 0f);
																							_cartOffsets = list;
																							num = unchecked((nint)null);
																							num3 = (nint)GM.Core;
																							bool flag38 = (object)GM.Core == null;
																							center = (Vector3)0;
																							if (!flag38)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+298]");
																								num3 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+298]");
																								bool flag39 = (nint)0 == 0;
																								center = (Vector3)0;
																								if (!flag39)
																								{
																									center = (Vector3)0;
																									List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
																									float num8 = default(float);
																									while (enumerator.MoveNext())
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundFBHighway)+84]");
																										center = (Vector3)0;
																										SpawnBikeForCharacter(null, (float2)num8);
																										num3 = unchecked((nint)null);
																										num = (nint)num8;
																									}
																									action = null;
																									nint num9 = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r10_v5 (Il2CppMethodInfo)+8]");
																									((Delegate)action).method_ptr = (IntPtr)0;
																									((Delegate)action).method = (nint)__ldftn(BackgroundFBHighway.HandleDestructibleSpawning);
																									((Delegate)action).m_target = this;
																									((Delegate)action).method_code = (IntPtr)action;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r10_v5 (Il2CppMethodInfo)+4C]");
																									object obj16 = (nint)0 >> 4;
																									object obj17 = obj16 & 1;
																									nint num10;
																									if (obj17 != null)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r10_v5 (Il2CppMethodInfo)+52]");
																										if ((nint)0 == 0)
																										{
																											num10 = unchecked((nint)6447293664L);
																											goto IL_1262;
																										}
																									}
																									else if ((object)this == null)
																									{
																										TileSprite tileSprite8 = RenderingExtensions.SetScrollFactor<TileSprite>(null, (float)center, (byte)num != 0);
																										throw tileSprite8;
																									}
																									num10 = ((Delegate)action).method_ptr;
																									((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
																									goto IL_1262;
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
		goto IL_0f13;
		IL_0f2a:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw null;
		IL_0f13:
		throw new NullReferenceException();
		IL_100b:
		if ((object)GM.Core != null)
		{
			num3 = (nint)ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
				object obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
				if ((nint)0 != 0 && (object)GM.Core != null)
				{
					num3 = (nint)ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
						object obj19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ rax_v52+14]");
							nint num11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v971 @ rax_v48+10]");
							if (num11 > 0)
							{
								if ((object)GM.Core != null)
								{
									num3 = (nint)ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
										if ((nint)0 != 0)
										{
											goto IL_10c5;
										}
									}
								}
							}
							else if ((object)GM.Core != null)
							{
								num3 = (nint)ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ r9_v18 (Il2CppMethodInfo)+28]");
									if ((nint)0 != 0)
									{
										goto IL_10c5;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0f13;
		IL_0f35:
		throw new IndexOutOfRangeException();
	}

	private void SpawnBikeForCharacter(VampireSurvivors.Objects.Characters.CharacterController character, float2 offset)
	{
		//IL_0101: Expected O, but got I4
		//IL_00cc: Expected O, but got I4
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
			item = (float2)0;
			cartOffsets = _cartOffsets;
		}
		else
		{
			PhaserWorld instance = PhaserWorld.Instance;
			PhaserSprite phaserSprite = instance.AddPhaserSprite((Vector2)0, "backgroundHighway", "Motoroid");
			GameObject gameObject = phaserSprite.gameObject;
			((UnityEngine.Object)gameObject).SetName("BikeSpriteFront");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
			item = offset;
			cartOffsets = _cartOffsets;
		}
		cartOffsets.Add(item);
	}

	private void HandleDestructibleSpawning()
	{
		//IL_01de: Expected O, but got I4
		//IL_01fb: Expected O, but got I4
		//IL_022b: Expected O, but got F4
		//IL_02ca: Expected O, but got F4
		//IL_036a: Expected O, but got F4
		//IL_03c9: Expected O, but got F4
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_02ad: Expected O, but got F4
		//IL_02b7->IL02bc: Incompatible stack heights: 1 vs 0
		//IL_0321->IL01a5: Incompatible stack heights: 1 vs 0
		//IL_02bc->IL011f: Incompatible stack heights: 1 vs 0
		object obj;
		Vector2 vector3 = default(Vector2);
		if ((object)GM.Core != null)
		{
			if (!GM.Core.IsStageHost)
			{
				return;
			}
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core._gameSessionData;
				if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					float2 position = gameSessionData._activeCharacter.position;
					obj = UnityEngine.Random.RandomRangeInt(6, 13);
					bool flag = (nint)obj <= 0;
					object obj2 = 0;
					Vector2 vector2 = default(Vector2);
					Vector2 vector = vector2;
					float num2 = default(float);
					float num = num2;
					float2 float5 = position;
					if (flag)
					{
						goto IL_011f;
					}
					while (true)
					{
						object obj3 = UnityEngine.Random.value;
						float num3 = (float)vector * 4.25f;
						float num4 = num3 + 4f;
						float num5 = num4 * _inversionMul;
						float num6 = num5 + (float)float5;
						object obj4 = UnityEngine.Random.value;
						float num7 = (float)vector - 0.5f;
						float num8 = num7 * 1.25f;
						GameManager core2 = GM.Core;
						float num9 = num8 + num;
						if ((object)GM.Core == null || (object)core2._stage == null)
						{
							break;
						}
						Destructible destructible = core2._stage.MakeDestructible(PropType.FB_EXPLOBARREL, vector3);
						if ((object)destructible == null)
						{
							break;
						}
						bool flag2 = ((UnityEngine.Object)destructible).m_CachedPtr == (IntPtr)0;
						IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)destructible).m_CachedPtr);
						Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						ContainWithinRacingBounds(target);
						obj2++;
						bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
						vector = vector3;
						num = num9;
						float5 = (float2)num6;
						if (!flag3)
						{
							goto IL_011f;
						}
					}
				}
			}
		}
		goto IL_01a6;
		IL_011f:
		if ((nint)obj < 12)
		{
			return;
		}
		object obj5 = UnityEngine.Random.value;
		object obj6 = UnityEngine.Random.value;
		GameManager core3 = GM.Core;
		if ((object)GM.Core != null && (object)core3._stage != null)
		{
			Destructible destructible2 = core3._stage.MakeDestructible(PropType.FB_EXPLOCAR, vector3);
			if ((object)destructible2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v67 (VampireSurvivors.Objects.Destructible)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v67 (VampireSurvivors.Objects.Destructible)+10]");
				IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
				Transform target2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				ContainWithinRacingBounds(target2);
				return;
			}
		}
		goto IL_01a6;
		IL_01a6:
		throw new NullReferenceException();
	}

	public override void OnInitCompleted()
	{
		base.OnInitCompleted();
		float yMax = default(float);
		bool skipInverseCalculation = default(bool);
		GM.Core.SetHardBoundsMinMax(-3.4028235E+38f, 390f, 3.4028235E+38f, yMax, skipInverseCalculation);
	}

	public void SetSpeedFactor(float factor)
	{
		_speedFactor = factor;
	}

	protected override void OnUpdate()
	{
		//IL_015e: Expected O, but got I
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01de: Expected O, but got I4
		base.OnUpdate();
		if (isFirstUpdate)
		{
			isFirstUpdate = false;
			ProCamera2D instance = ProCamera2D.Instance;
			instance.FollowVertical = false;
		}
		if (!PauseSystem._paused)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = _accelerationMul * _speedFactor;
			float num2 = num * _inversionMul;
			GameManager core = GM.Core;
			float num3 = deltaTime * num2;
			float num4 = num3 * 60f;
			Stage stage = core._stage;
			stage._tilingTileset.MoveTilesetForHorizontalRoad(num4);
			MoveVehiclesAndPickups(num4);
			float deltaTime2 = PauseSystem.DeltaTime;
			float num5 = _currentAcceleration * _speedFactor;
			float num6 = deltaTime2 * 1000f;
			float num7 = num5 * num6;
			float num8 = num7 * _accelerationMul;
			float distanceTravelled = num8 + _distanceTravelled;
			_distanceTravelled = distanceTravelled;
			float distanceTravelled2 = GetDistanceTravelled();
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v15 (VampireSurvivors.Objects.Stage)+138]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v15 (VampireSurvivors.Objects.Stage)+138]");
			object obj = num9 + 0;
			object obj2 = obj & -2147483649L;
			float num10 = (float)obj2 * 100f;
			float num11 = _nextLoopDist - num10;
			if (distanceTravelled2 > num11)
			{
				base.LoopPickupPositions();
				object obj3 = ++_loopsDone + 1;
				float nextLoopDist = (float)obj3 * (float)_loopLength;
				_nextLoopDist = nextLoopDist;
				GameManager core3 = GM.Core;
				PlayerOptionsData config = core3._playerOptions.Config;
				int num12 = config._003CTotalLapsHighway_003Ek__BackingField + 1;
				config._003CTotalLapsHighway_003Ek__BackingField = num12;
			}
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
		//IL_0034: Expected O, but got I
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_00b4: Expected O, but got I4
		float distanceTravelled = GetDistanceTravelled();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v5 (VampireSurvivors.Objects.Stage)+138]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v5 (VampireSurvivors.Objects.Stage)+138]");
		object obj = num + 0;
		object obj2 = obj & -2147483649L;
		float num2 = (float)obj2 * 100f;
		float num3 = _nextLoopDist - num2;
		if (distanceTravelled > num3)
		{
			base.LoopPickupPositions();
			object obj3 = ++_loopsDone + 1;
			float nextLoopDist = (float)obj3 * (float)_loopLength;
			_nextLoopDist = nextLoopDist;
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			int num4 = config._003CTotalLapsHighway_003Ek__BackingField + 1;
			config._003CTotalLapsHighway_003Ek__BackingField = num4;
		}
	}

	public override void InitPickupForLoopingStage(Pickup pickup)
	{
		//IL_00c1: Expected O, but got I4
		if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0 && (object)pickup._003CLoopedSpawnX_003Ek__BackingField == null)
		{
			float2 position = pickup.position;
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			float2 position2 = gameSessionData._activeCharacter.position;
			float distanceTravelled = GetDistanceTravelled();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
			pickup._003CLoopedSpawnX_003Ek__BackingField = (float?)(object)1;
		}
	}

	private void MoveVehiclesAndPickups(float movement)
	{
		if (!PauseSystem._paused)
		{
			TileSprite tileSprite = fb_bg_hw_Back;
			float num = movement * 0.125f;
			float num2 = num * 1.05f;
			float scrollOffsetX = (tileSprite._xScrollOffset = num2 + tileSprite._xScrollOffset);
			tileSprite._spriteScroller.SetScrollOffsetX(scrollOffsetX);
			TileSprite tileSprite2 = fb_bg_hw_Front;
			float scrollOffsetX2 = (tileSprite2._xScrollOffset = num + tileSprite2._xScrollOffset);
			tileSprite2._spriteScroller.SetScrollOffsetX(scrollOffsetX2);
			float2 cameraCenter = RenderingHelper.GetCameraCenter();
			float num3 = (float)cameraCenter * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003890");
			object obj = default(object);
			float num4 = (float)obj * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003890");
			TileSprite tileSprite3 = fb_bg_hw_Back;
			float num5 = num4 / 100f;
			float num6 = num5 * _yMul;
			float num7 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundFBHighway)+8C]");
			float scrollOffsetY = (tileSprite3._yScrollOffset = num7 + 0f);
			tileSprite3._spriteScroller.SetScrollOffsetY(scrollOffsetY);
			TileSprite tileSprite4 = fb_bg_hw_Front;
			float num8 = num5 * _yMul;
			float num9 = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundFBHighway)+8C]");
			float scrollOffsetY2 = (tileSprite4._yScrollOffset = num9 + 0f);
			tileSprite4._spriteScroller.SetScrollOffsetY(scrollOffsetY2);
			float2 offset = default(float2);
			GM.Core.MovePickupsAndDestructibles(offset);
		}
	}

	private void LateUpdate()
	{
		if (_created)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				Component component = null;
				throw new NullReferenceException();
			}
			UpdateCarts();
		}
	}

	private void UpdateCarts()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Expected O, but got Unknown
		//IL_015a: Invalid comparison between F4 and I4
		//IL_0188: Expected O, but got I4
		//IL_0421: Expected O, but got I4
		//IL_017a: Expected O, but got I4
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Expected O, but got Unknown
		//IL_0324: Expected O, but got F4
		//IL_038a: Expected O, but got I4
		GameManager core = GM.Core;
		object obj = 0;
		object obj2 = 0;
		object obj3 = 0;
		float num = default(float);
		PhaserSprite phaserSprite = default(PhaserSprite);
		float num4 = default(float);
		while (true)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
			if ((nint)obj3 >= characters._size)
			{
				return;
			}
			GameManager core2 = GM.Core;
			List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = core2._characters;
			if ((nint)obj >= characters2._size)
			{
				break;
			}
			VampireSurvivors.Objects.Characters.CharacterController[] items = characters2._items;
			VampireSurvivors.Objects.Characters.CharacterController characterController = items[obj];
			if (!items[obj].NeedsCart)
			{
				goto IL_03d0;
			}
			bool flag = GM.Core.IsStageVisuallyInverted();
			float2 float5 = items[obj].ApplyRacingOffset(CharacterVehicleType.FB_BIKE);
			RacingOffsetData racingOffsetData = characterController._currentCharacterData.GetRacingOffsetData(CharacterVehicleType.FB_BIKE);
			if (racingOffsetData != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186F6031Eh\"");
				object obj4 = ((num != 0f) ? ((object)0) : ((object)1));
				object obj5 = obj4 & (object?)racingOffsetData._003CracingAngle_003Ek__BackingField;
				bool flag2 = obj5 == null;
				object obj6 = !flag2;
				float num2 = num;
				if (obj6 == null)
				{
					bool flipX = items[obj].flipX;
					num2 = num;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			bool flipX2 = items[obj].flipX;
			if (!flag)
			{
				if (flipX2)
				{
					float num2 = 1.75f;
				}
				else
				{
					float num2 = 1f;
				}
			}
			else if (flipX2)
			{
				float num2 = -1f;
			}
			else
			{
				float num2 = -1.75f;
			}
			float num3 = characterController._defaultSpriteWidth / 42f;
			if (!(1f > num3))
			{
				object obj7 = 1f & -2147483649L;
				if ((nint)obj7 <= 2139095040)
				{
					goto IL_02c1;
				}
			}
			num3 = 1f;
			goto IL_02c1;
			IL_03d0:
			obj++;
			core = GM.Core;
			obj3 = obj;
			continue;
			IL_02c1:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			if ((object)phaserSprite != null && ((UnityEngine.Object)phaserSprite).m_CachedPtr != (IntPtr)0)
			{
				float2 position = items[obj].position;
				PhaserSprite phaserSprite2 = phaserSprite.setPosition((float2)num4);
				int depth = items[obj].depth;
				int depth2 = depth + 1;
				PhaserSprite phaserSprite3 = phaserSprite.setDepth(depth2);
				PhaserSprite phaserSprite4 = phaserSprite.setFlipX(flag);
				PhaserSprite phaserSprite5 = phaserSprite.setScale(num3, (float?)(object)0);
				float num2 = num4;
			}
			obj2++;
			goto IL_03d0;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void Cleanup()
	{
		//IL_00ad: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CTopLapsHighway_003Ek__BackingField < _loopsDone)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			config2._003CTopLapsHighway_003Ek__BackingField = _loopsDone;
		}
		_BarrelsSpawningTimer.Cancel();
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		GameManager core3 = GM.Core;
		core3._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
	}

	public override void OnFollowerAdded(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		float2 offset = default(float2);
		SpawnBikeForCharacter(character, offset);
	}

	public BackgroundFBHighway()
	{
		//IL_000b: Expected O, but got I4
		//IL_0020: Expected O, but got I8
		BikeOffset = (float2)1031127695;
		_ = 1034147594;
		_initialOffset = (Vector2)3204112712L;
		_ = 1085653647;
		_speedFactor = 1f;
		_accelerationMul = 1f;
		_currentAcceleration = 0.16f;
		_yMul = 1f;
		isFirstUpdate = true;
		_loopLength = 20000;
		base._002Ector();
	}
}
