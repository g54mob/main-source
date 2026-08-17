using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundSpace : BackgroundManager
{
	private TileSprite _stars2;

	private TileSprite _starsA;

	private TileSprite _starsB;

	private TileSprite _starsC;

	private TileSprite _starsD;

	private float _yMul;

	private BgmType _saveBgm;

	private BgmModType _saveBgmMod;

	private float _speedFactor;

	private int alphaMinuteStart;

	private List<Tilemap> stageTilemaps;

	private bool _spawnBraveStory;

	private bool _checkHeartDistance;

	private float2 relicPosition;

	private float2 _center;

	protected PhaserSprite _zodiacSprite;

	private MultiTargetTween _tween1;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween3;

	private float _value;

	private Pickup _spawnedBraveStoryRelic;

	private ParticleSystem _pfxSnowEmitter;

	private ParticleEmitterManager _pfxManager;

	private List<MultiTargetTween> spaceTweens;

	private bool _spaceTweensActive;

	private Circle _heartCircle;

	private PhaserSprite _heartSprite;

	public override void Create()
	{
		//IL_0167: Expected I4, but got I8
		//IL_032f: Expected I4, but got I8
		//IL_04f7: Expected I4, but got I8
		//IL_06bf: Expected I4, but got I8
		//IL_0899: Expected I4, but got I8
		base._003CHasMovingBg_003Ek__BackingField = true;
		base.Create();
		List<MultiTargetTween> list = new List<MultiTargetTween>();
		spaceTweens = list;
		_spaceTweensActive = false;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		float y = renderer2.height * 0.5f;
		float x = renderer.width * 0.5f;
		float height = default(float);
		string textureName = default(string);
		string spriteName = default(string);
		TileSprite component = RenderingExtensions.AddTileSprite(this, x, y, renderer3.width, height, textureName, spriteName);
		TileSprite tileSprite = RenderingExtensions.SetScrollFactor(component, 0f);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene4 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer4 = s_scene4._renderer;
			int depth = renderer4.pixelHeight - 1;
			TileSprite component2 = tileSprite.SetDepth(depth);
			TileSprite tileSprite2 = RenderingExtensions.SetScrollFactor(component2, 0f);
			TileSprite tileSprite3 = tileSprite2.SetDepth(-32767);
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(tileSprite3._spriteRenderer, 0.15f);
			TileSprite tileSprite4 = RenderingExtensions.SetBlendMode(tileSprite3, BlendMode.Add);
			GameObject gameObject = tileSprite4.gameObject;
			((UnityEngine.Object)gameObject).SetName("Stars2");
			_stars2 = tileSprite4;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene5 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer5 = s_scene5._renderer;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene6 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer6 = s_scene6._renderer;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene7 = ArcadePhysics.s_scene;
						PhaserScene.Renderer renderer7 = s_scene7._renderer;
						if ((object)GM.Core != null)
						{
							float y2 = renderer6.height * 0.5f;
							float x2 = renderer5.width * 0.5f;
							TileSprite component3 = RenderingExtensions.AddTileSprite(this, x2, y2, renderer7.width, height, textureName, spriteName);
							TileSprite component4 = RenderingExtensions.SetScrollFactor(component3, 0f);
							TileSprite tileSprite5 = RenderingExtensions.SetScrollFactor(component4, 0f);
							TileSprite tileSprite6 = tileSprite5.SetDepth(-32767);
							SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(tileSprite6._spriteRenderer, 0.05f);
							TileSprite tileSprite7 = RenderingExtensions.SetBlendMode(tileSprite6, BlendMode.Add);
							GameObject gameObject2 = tileSprite7.gameObject;
							((UnityEngine.Object)gameObject2).SetName("SpaceA");
							_starsA = tileSprite7;
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene8 = ArcadePhysics.s_scene;
								PhaserScene.Renderer renderer8 = s_scene8._renderer;
								if ((object)GM.Core != null)
								{
									PhaserScene s_scene9 = ArcadePhysics.s_scene;
									PhaserScene.Renderer renderer9 = s_scene9._renderer;
									if ((object)GM.Core != null)
									{
										PhaserScene s_scene10 = ArcadePhysics.s_scene;
										PhaserScene.Renderer renderer10 = s_scene10._renderer;
										if ((object)GM.Core != null)
										{
											float y3 = renderer9.height * 0.5f;
											float x3 = renderer8.width * 0.5f;
											TileSprite component5 = RenderingExtensions.AddTileSprite(this, x3, y3, renderer10.width, height, textureName, spriteName);
											TileSprite component6 = RenderingExtensions.SetScrollFactor(component5, 0f);
											TileSprite tileSprite8 = RenderingExtensions.SetScrollFactor(component6, 0f);
											TileSprite tileSprite9 = tileSprite8.SetDepth(-32767);
											SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(tileSprite9._spriteRenderer, 0.05f);
											TileSprite tileSprite10 = RenderingExtensions.SetBlendMode(tileSprite9, BlendMode.Add);
											GameObject gameObject3 = tileSprite10.gameObject;
											((UnityEngine.Object)gameObject3).SetName("SpaceB");
											_starsB = tileSprite10;
											if ((object)GM.Core != null)
											{
												PhaserScene s_scene11 = ArcadePhysics.s_scene;
												PhaserScene.Renderer renderer11 = s_scene11._renderer;
												if ((object)GM.Core != null)
												{
													PhaserScene s_scene12 = ArcadePhysics.s_scene;
													PhaserScene.Renderer renderer12 = s_scene12._renderer;
													if ((object)GM.Core != null)
													{
														PhaserScene s_scene13 = ArcadePhysics.s_scene;
														PhaserScene.Renderer renderer13 = s_scene13._renderer;
														if ((object)GM.Core != null)
														{
															float y4 = renderer12.height * 0.5f;
															float x4 = renderer11.width * 0.5f;
															TileSprite component7 = RenderingExtensions.AddTileSprite(this, x4, y4, renderer13.width, height, textureName, spriteName);
															TileSprite component8 = RenderingExtensions.SetScrollFactor(component7, 0f);
															TileSprite tileSprite11 = RenderingExtensions.SetScrollFactor(component8, 0f);
															TileSprite tileSprite12 = tileSprite11.SetDepth(-32767);
															SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha(tileSprite12._spriteRenderer, 0.05f);
															TileSprite tileSprite13 = RenderingExtensions.SetBlendMode(tileSprite12, BlendMode.Add);
															GameObject gameObject4 = tileSprite13.gameObject;
															((UnityEngine.Object)gameObject4).SetName("SpaceC");
															_starsC = tileSprite13;
															if ((object)GM.Core != null)
															{
																PhaserScene s_scene14 = ArcadePhysics.s_scene;
																PhaserScene.Renderer renderer14 = s_scene14._renderer;
																if ((object)GM.Core != null)
																{
																	PhaserScene s_scene15 = ArcadePhysics.s_scene;
																	PhaserScene.Renderer renderer15 = s_scene15._renderer;
																	if ((object)GM.Core != null)
																	{
																		PhaserScene s_scene16 = ArcadePhysics.s_scene;
																		PhaserScene.Renderer renderer16 = s_scene16._renderer;
																		if ((object)GM.Core != null)
																		{
																			PhaserScene s_scene17 = ArcadePhysics.s_scene;
																			PhaserScene.Renderer renderer17 = s_scene17._renderer;
																			float y5 = renderer15.height * 0.5f;
																			float x5 = renderer14.width * 0.5f;
																			TileSprite component9 = RenderingExtensions.AddTileSprite(this, x5, y5, renderer16.width, height, textureName, spriteName);
																			TileSprite component10 = RenderingExtensions.SetScrollFactor(component9, 0f);
																			TileSprite tileSprite14 = RenderingExtensions.SetScrollFactor(component10, 0f);
																			TileSprite tileSprite15 = tileSprite14.SetDepth(-32767);
																			SpriteRenderer spriteRenderer5 = RenderingExtensions.SetAlpha(tileSprite15._spriteRenderer, 0.05f);
																			TileSprite tileSprite16 = RenderingExtensions.SetBlendMode(tileSprite15, BlendMode.Add);
																			GameObject gameObject5 = tileSprite16.gameObject;
																			((UnityEngine.Object)gameObject5).SetName("SpaceD");
																			_starsD = tileSprite16;
																			TileSprite stars = _stars2;
																			Material material = MaterialManager.GetMaterial(MaterialType.ScrollableSpriteAdditive);
																			((Renderer)stars._spriteRenderer).SetMaterial(material);
																			TileSprite starsA = _starsA;
																			Material material2 = MaterialManager.GetMaterial(MaterialType.ScrollableSpriteAdditive);
																			((Renderer)starsA._spriteRenderer).SetMaterial(material2);
																			TileSprite starsB = _starsB;
																			Material material3 = MaterialManager.GetMaterial(MaterialType.ScrollableSpriteAdditive);
																			((Renderer)starsB._spriteRenderer).SetMaterial(material3);
																			TileSprite starsC = _starsC;
																			Material material4 = MaterialManager.GetMaterial(MaterialType.ScrollableSpriteAdditive);
																			((Renderer)starsC._spriteRenderer).SetMaterial(material4);
																			TileSprite starsD = _starsD;
																			Material material5 = MaterialManager.GetMaterial(MaterialType.ScrollableSpriteAdditive);
																			((Renderer)starsD._spriteRenderer).SetMaterial(material5);
																			_yMul = 1f;
																			GameManager core = GM.Core;
																			PlayerOptionsData config = core._playerOptions.Config;
																			if (config._003CSelectedInverse_003Ek__BackingField)
																			{
																				GameManager core2 = GM.Core;
																				PlayerOptionsData config2 = core2._playerOptions.Config;
																				if (config2._003CVisuallyInvertStages_003Ek__BackingField)
																				{
																					_yMul = -1f;
																				}
																			}
																			GameManager core3 = GM.Core;
																			PlayerOptionsData config3 = core3._playerOptions.Config;
																			_saveBgm = config3._003CSelectedBGM_003Ek__BackingField;
																			GameManager core4 = GM.Core;
																			PlayerOptionsData config4 = core4._playerOptions.Config;
																			_saveBgmMod = config4._003CSelectedBGMMod_003Ek__BackingField;
																			GameManager core5 = GM.Core;
																			PlayerOptionsData config5 = core5._playerOptions.Config;
																			List<AchievementType> list2 = config5._003CAchievements_003Ek__BackingField;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rcx_v124 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
																			if ((nint)0 != 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
																				object obj = default(object);
																				if ((nint)obj != -1)
																				{
																					return;
																				}
																			}
																			GameManager core6 = GM.Core;
																			PlayerOptionsData config6 = core6._playerOptions.Config;
																			config6._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
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
		throw new NullReferenceException();
	}

	public override void OnInitCompleted()
	{
		//IL_0026: Expected O, but got I
		//IL_005c: Expected O, but got I
		//IL_00c2: Expected O, but got I
		//IL_00f8: Expected O, but got I
		//IL_0187: Expected O, but got I4
		//IL_0a11: Expected I, but got O
		//IL_0a42: Expected O, but got I
		//IL_0165: Expected O, but got I4
		//IL_01b5: Expected O, but got I
		//IL_0a9a: Expected I, but got O
		//IL_0acb: Expected O, but got I
		//IL_0325: Expected O, but got I
		//IL_03d3: Expected O, but got I4
		//IL_0419: Expected O, but got I
		//IL_0ae2: Expected O, but got I4
		//IL_04d7: Expected O, but got I4
		//IL_0485: Expected O, but got I
		//IL_04ba: Expected F4, but got I
		//IL_055e: Expected O, but got I
		//IL_0594: Expected O, but got I
		//IL_0701: Expected F4, but got O
		//IL_0716: Expected F4, but got I
		//IL_07bb: Expected I4, but got I8
		base.OnInitCompleted();
		PlayerOptions core = (PlayerOptions)(object)GM.Core;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rcx_v10 (VampireSurvivors.Objects.PlayerOptions)+90]");
			core = (PlayerOptions)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rcx_v10 (VampireSurvivors.Objects.PlayerOptions)+90]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rcx_v10 (VampireSurvivors.Objects.PlayerOptions)+90]");
				PlayerOptionsData config = ((PlayerOptions)0).Config;
				if (config != null)
				{
					config._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
					core = (PlayerOptions)(object)GM.Core;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rcx_v10 (VampireSurvivors.Objects.PlayerOptions)+90]");
						core = (PlayerOptions)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rcx_v10 (VampireSurvivors.Objects.PlayerOptions)+90]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rcx_v10 (VampireSurvivors.Objects.PlayerOptions)+90]");
							PlayerOptionsData config2 = ((PlayerOptions)0).Config;
							if (config2 != null)
							{
								core = (PlayerOptions)(object)config2._003CCollectedItems_003Ek__BackingField;
								if (config2._003CCollectedItems_003Ek__BackingField != null)
								{
									object obj2;
									if (core.PowerUpPurchased != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
										object obj = default(object);
										bool flag = (nint)obj != -1;
										obj2 = 0;
										if (flag)
										{
											goto IL_0a03;
										}
									}
									_spawnBraveStory = true;
									obj2 = 0;
									goto IL_0a03;
								}
							}
						}
					}
				}
			}
		}
		goto IL_097b;
		IL_08b6:
		GameManager core2 = GM.Core;
		if ((object)GM.Core != null)
		{
			TilingBackground bgMan = core2._bgMan;
			if ((object)core2._bgMan != null)
			{
				TileSprite bgtile = bgMan._bgtile;
				core = (PlayerOptions)(object)typeof(RenderingExtensions);
				if ((object)bgMan._bgtile != null)
				{
					SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(bgtile._spriteRenderer, 0f);
					TileSprite stars = _stars2;
					if ((object)_stars2 != null)
					{
						SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(stars._spriteRenderer, 0f);
						return;
					}
				}
			}
		}
		goto IL_097b;
		IL_0ad9:
		object obj3 = 208;
		_center = relicPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundSpace)+D0]");
		_ = 0;
		PhaserWorld instance = PhaserWorld.Instance;
		bool flag2 = (object)instance == null;
		core = null;
		if (!flag2)
		{
			PhaserSprite zodiacSprite = instance.AddPhaserSprite((Vector2)0, "VFX", "Zodiac");
			_zodiacSprite = zodiacSprite;
			bool flag3 = (object)_zodiacSprite == null;
			core = (PlayerOptions)(object)_zodiacSprite;
			if (!flag3)
			{
				PhaserSprite phaserSprite = _zodiacSprite.setVisible(visible: false);
				core = (PlayerOptions)(object)GM.Core;
				if ((object)GM.Core != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rcx_v10 (VampireSurvivors.Objects.PlayerOptions)+90]");
					core = (PlayerOptions)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rcx_v10 (VampireSurvivors.Objects.PlayerOptions)+90]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rcx_v10 (VampireSurvivors.Objects.PlayerOptions)+90]");
						PlayerOptionsData config3 = ((PlayerOptions)0).Config;
						if (config3 != null)
						{
							core = (PlayerOptions)(object)config3._003CUnlockedCharacters_003Ek__BackingField;
							if (config3._003CUnlockedCharacters_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
								object obj4 = default(object);
								if (obj4 == null)
								{
									goto IL_08b6;
								}
								GameManager core3 = GM.Core;
								if ((object)GM.Core != null)
								{
									core = core3._playerOptions;
									if (core3._playerOptions != null)
									{
										PlayerOptionsData config4 = core3._playerOptions.Config;
										if (config4 != null && config4._003CUnlockedCharacters_003Ek__BackingField != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
											object obj5 = default(object);
											if (obj5 != null)
											{
												goto IL_08b6;
											}
											_checkHeartDistance = true;
											Circle circle = new Circle();
											circle._x = (float)_center;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundSpace)+D8]");
											circle._y = 0f;
											circle._radius = 0.32f;
											_heartCircle = circle;
											PhaserWorld instance2 = PhaserWorld.Instance;
											bool flag4 = (object)instance2 == null;
											core = null;
											if (!flag4)
											{
												Vector2 pos = default(Vector2);
												PhaserSprite heartSprite = instance2.AddPhaserSprite(pos, "items", "HeartRuby");
												_heartSprite = heartSprite;
												if ((object)_heartSprite != null)
												{
													PhaserSprite phaserSprite2 = _heartSprite.setDepth(-1997);
													if ((object)_heartSprite != null)
													{
														Transform target = _heartSprite.transform;
														TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 2f, 0.5f);
														if (tweenerCore != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1433 @ rax_v75 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1433 @ rax_v75 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
																if ((nint)0 == 0)
																{
																	_ = 4294967295L;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1433 @ rax_v75 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
																	if ((nint)0 == 0)
																	{
																		_ = 2139095040;
																	}
																}
															}
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
														Tween gameId = default(Tween);
														Tween tween = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
														goto IL_08b6;
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
		goto IL_097b;
		IL_0b2b:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_097b:
		throw new NullReferenceException();
		IL_0a03:
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1015 @ rax_v25 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core4 = GM.Core;
		bool flag5 = (object)GM.Core == null;
		core = (PlayerOptions)num2;
		if (!flag5)
		{
			Stage stage = core4._stage;
			bool flag6 = (object)core4._stage == null;
			core = (PlayerOptions)num2;
			if (!flag6)
			{
				core = (PlayerOptions)(object)stage._tilingTileset;
				if ((object)stage._tilingTileset != null && core._mainGameConfig != null)
				{
					List<SuperTiled2Unity.SuperMap>.Enumerator enumerator = default(List<SuperTiled2Unity.SuperMap>.Enumerator);
					if (enumerator.MoveNext())
					{
						core = null;
						throw new NullReferenceException();
					}
					nint num3 = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1191 @ rax_v34 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					nint num4 = 0;
					GameManager core5 = GM.Core;
					bool flag7 = (object)GM.Core == null;
					core = (PlayerOptions)num4;
					if (!flag7)
					{
						Stage stage2 = core5._stage;
						bool flag8 = (object)core5._stage == null;
						core = (PlayerOptions)num4;
						if (!flag8)
						{
							bool flag9 = (object)stage2._tilingTileset == null;
							core = (PlayerOptions)(object)stage2._tilingTileset;
							if (!flag9)
							{
								List<Vector2> specialLocations = stage2._tilingTileset.GetSpecialLocations("RelicPosition");
								bool flag10 = specialLocations == null;
								core = (PlayerOptions)(object)stage2._tilingTileset;
								if (!flag10)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v37 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
									if ((nint)0 <= (nint)0)
									{
										relicPosition = (float2)1159725056;
										float num5 = 2560f;
										goto IL_0ad9;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v37 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
									if ((nint)0 <= (nint)0)
									{
										goto IL_0b2b;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v37 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
									core = (PlayerOptions)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v37 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
									if ((nint)0 != 0)
									{
										relicPosition = (float2)core.PowerUpsRefunded;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v37 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
										if ((nint)0 <= (nint)0)
										{
											goto IL_0b2b;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v37 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
										core = (PlayerOptions)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v37 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rcx_v10 (VampireSurvivors.Objects.PlayerOptions)+24]");
											float num5 = 0f;
											goto IL_0ad9;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_097b;
	}

	private void GetCenter()
	{
		//IL_0059: Expected O, but got F4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		float num = (float)relicPosition * 0.01f;
		float num2 = num + (float)tilingTileset._currentBounds;
		_center = (float2)num2;
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		TilingTileset tilingTileset2 = stage2._tilingTileset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundSpace)+D0]");
		float num3 = 0f * 0.01f;
		float num4 = (float)tilingTileset2._currentBounds - num3;
		GameManager core3 = GM.Core;
		Stage stage3 = core3._stage;
		TilingTileset tilingTileset3 = stage3._tilingTileset;
		if (tilingTileset3._inverted)
		{
			GameManager core4 = GM.Core;
			PlayerOptionsData config = core4._playerOptions.Config;
			if (config._003CVisuallyInvertStages_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundSpace)+D0]");
				float num5 = 0f * 0.01f;
				float num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundSpace)+D8]");
				float num7 = num6 + 0f;
			}
		}
	}

	protected override void OnUpdate()
	{
		//IL_034e: Expected F4, but got I4
		//IL_06b5: Invalid comparison between F4 and I4
		//IL_0340: Expected F4, but got I4
		//IL_04e9: Expected O, but got I
		//IL_0507: Expected O, but got I
		//IL_05b1: Expected F4, but got I4
		//IL_061d: Expected F4, but got I4
		//IL_0484->IL075e: Incompatible stack heights: 4 vs 1
		//IL_067f->IL075e: Incompatible stack heights: 7 vs 1
		//IL_0624->IL0624: Incompatible stack heights: 10 vs 6
		base.OnUpdate();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = (float)renderer.screenCenter * _speedFactor;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num2 = _yMul * _speedFactor;
		float num3 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v611 @ rax_v13 (PhaserScene+Renderer)+38]");
		float num4 = num3 * 0f;
		TileSprite stars = _stars2;
		stars._xScrollOffset = num;
		stars._spriteScroller.SetScrollOffsetX(num);
		TileSprite stars2 = _stars2;
		stars2._yScrollOffset = num4;
		stars2._spriteScroller.SetScrollOffsetY(num4);
		TileSprite starsA = _starsA;
		starsA._xScrollOffset = num;
		starsA._spriteScroller.SetScrollOffsetX(num);
		TileSprite starsA2 = _starsA;
		starsA2._yScrollOffset = num4;
		starsA2._spriteScroller.SetScrollOffsetY(num4);
		TileSprite starsB = _starsB;
		float scrollOffsetX = (starsB._xScrollOffset = num ^ -0f);
		starsB._spriteScroller.SetScrollOffsetX(scrollOffsetX);
		TileSprite starsB2 = _starsB;
		starsB2._yScrollOffset = num4;
		starsB2._spriteScroller.SetScrollOffsetY(num4);
		TileSprite starsC = _starsC;
		starsC._xScrollOffset = num;
		starsC._spriteScroller.SetScrollOffsetX(num);
		TileSprite starsC2 = _starsC;
		float scrollOffsetY = (starsC2._yScrollOffset = num4 ^ -0f);
		starsC2._spriteScroller.SetScrollOffsetY(scrollOffsetY);
		TileSprite starsD = _starsD;
		float scrollOffsetX2 = (starsD._xScrollOffset = num ^ -0f);
		starsD._spriteScroller.SetScrollOffsetX(scrollOffsetX2);
		TileSprite starsD2 = _starsD;
		float scrollOffsetY2 = (starsD2._yScrollOffset = num4 ^ -0f);
		starsD2._spriteScroller.SetScrollOffsetY(scrollOffsetY2);
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
		float num7;
		float num6 = default(float);
		if ((object)stageModifiers._003CTimeLimit_003Ek__BackingField != null)
		{
			object obj = default(object);
			float num5 = core._003CSurvivedSeconds_003Ek__BackingField / (float)obj;
			num6 = num5;
			num7 = 1f;
		}
		else
		{
			num7 = 0f;
		}
		bool flag = num7 == 0f;
		bool flag2 = num6 > 1f;
		float num8 = 1f;
		if (!flag2)
		{
			num8 = num6;
		}
		float num9 = num8 * 0.4f;
		float alpha = num9 + 0.1f;
		float num10 = num8 * 0.3f;
		float alpha2 = num10 + 0.2f;
		GameManager core2 = GM.Core;
		TilingBackground bgMan = core2._bgMan;
		TileSprite bgtile = bgMan._bgtile;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(bgtile._spriteRenderer, alpha);
		TileSprite stars3 = _stars2;
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(stars3._spriteRenderer, alpha2);
		if (!_checkHeartDistance)
		{
			return;
		}
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator point = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		while (enumerator.MoveNext())
		{
			Transform transform = ((Component)null).transform;
			bool flag3 = (object)transform == null;
			bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			bool flag5 = _heartCircle == null;
			if (_heartCircle.Contains((Vector2)point))
			{
				_checkHeartDistance = false;
				Transform core3 = (Transform)(object)GM.Core;
				bool flag6 = (object)GM.Core == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1411 @ rbx_v14 (UnityEngine.Transform)+90]");
				bool flag7 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1411 @ rbx_v14 (UnityEngine.Transform)+90]");
				PlayerOptionsData config = ((PlayerOptions)0).Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1411 @ rbx_v14 (UnityEngine.Transform)+90]");
				if (((PlayerOptions)0).UnlockSecret(SecretType.BreakSpaceBounds, config))
				{
					GameManager core4 = GM.Core;
					bool flag8 = (object)GM.Core == null;
					bool flag9 = core4._playerOptions == null;
					core4._playerOptions.UnlockCharacter(CharacterType.SPACEDUDETTE);
					PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.ThingFound, 0f, 10, 0f, volume, rate, detune, loop, 1f);
					GameManager core5 = GM.Core;
					bool flag10 = (object)GM.Core == null;
					bool flag11 = core5._playerOptions == null;
					core5._playerOptions.Save();
					num6 = 1.0653532E+09f;
				}
				PhaserSprite heartSprite = _heartSprite;
				bool flag12 = (object)_heartSprite == null;
				TweenerCore<Color, Color, ColorOptions> gameId = DOTweenModuleSprite.DOFade(heartSprite._spriteRenderer, 0f, 2.5f);
				Tween tween = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
			}
		}
	}

	public override void CheckMinute(int minute)
	{
		//IL_008e: Expected O, but got F4
		//IL_05d4: Expected O, but got I4
		//IL_01e5: Expected F4, but got I
		//IL_01e5: Expected F4, but got O
		//IL_031b: Expected O, but got I4
		//IL_0352: Expected O, but got I4
		//IL_03d7: Expected I, but got O
		//IL_03f3: Expected I, but got O
		//IL_0482: Expected O, but got I4
		if (minute == 18 && _spawnBraveStory)
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			TilingTileset tilingTileset = stage._tilingTileset;
			float num = (float)relicPosition * 0.01f;
			float num2 = num + (float)tilingTileset._currentBounds;
			_center = (float2)num2;
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			TilingTileset tilingTileset2 = stage2._tilingTileset;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundSpace)+D0]");
			float num3 = 0f * 0.01f;
			float num4 = (float)tilingTileset2._currentBounds - num3;
			GameManager core3 = GM.Core;
			Stage stage3 = core3._stage;
			TilingTileset tilingTileset3 = stage3._tilingTileset;
			if (tilingTileset3._inverted)
			{
				GameManager core4 = GM.Core;
				PlayerOptionsData config = core4._playerOptions.Config;
				if (config._003CVisuallyInvertStages_003Ek__BackingField)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundSpace)+D0]");
					float num5 = 0f * 0.01f;
					float num6 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundSpace)+D8]");
					float num7 = num6 + 0f;
				}
			}
			GameManager core5 = GM.Core;
			GizmoManager gizmoManager = core5._gizmoManager;
			float2 center = _center;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundSpace)+D8]");
			gizmoManager.ShowHighlightAt((float)center, 0f);
			Vector2 pos = default(Vector2);
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool validatePickups = default(bool);
			Pickup spawnedBraveStoryRelic = GM.Core.MakeStagePickup(pos, ItemType.RELIC, WeaponType.VOID, value, relicType, validatePickups);
			_spawnedBraveStoryRelic = spawnedBraveStoryRelic;
		}
		if (minute != alphaMinuteStart)
		{
			return;
		}
		GameManager core6 = GM.Core;
		Stage stage4 = core6._stage;
		Tilemap tilemapLayer = stage4._tilingTileset.GetTilemapLayer("Walls");
		if ((object)tilemapLayer != null && ((UnityEngine.Object)tilemapLayer).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = tilemapLayer.gameObject;
			gameObject.SetActive(value: false);
		}
		GameManager core7 = GM.Core;
		Stage stage5 = core7._stage;
		Tilemap tilemapLayer2 = stage5._tilingTileset.GetTilemapLayer("PlayerWall");
		bool flag = (object)tilemapLayer2 == null;
		object obj = 0;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)tilemapLayer2).m_CachedPtr == (IntPtr)0;
			obj = 0;
			if (!flag2)
			{
				GameObject gameObject2 = tilemapLayer2.gameObject;
				gameObject2.SetActive(value: false);
				obj = 0;
			}
		}
		GameManager core8 = GM.Core;
		Stage stage6 = core8._stage;
		stage6._hasWallsCheckDestructibleLogic = false;
		stage6._hasTileSet = false;
		List<Tilemap>.Enumerator enumerator = default(List<Tilemap>.Enumerator);
		while (enumerator.MoveNext())
		{
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			bool flag3 = array == null;
			nint num8 = (nint)typeof(object[]);
			if (!flag3)
			{
				num8 = (nint)typeof(object[]);
				if (array.Length > 0)
				{
					array[0] = null;
					if (tweenConfig != null)
					{
						tweenConfig.targets = array;
						tweenConfig.alpha = (float?)(object)1;
						tweenConfig.duration = 60000f;
						MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
						continue;
					}
					throw new NullReferenceException();
				}
				throw new IndexOutOfRangeException();
			}
			throw new NullReferenceException();
		}
		StartSpaceTweens();
		if (_checkHeartDistance)
		{
			_checkHeartDistance = false;
			PhaserSprite heartSprite = _heartSprite;
			if ((object)_heartSprite != null && ((UnityEngine.Object)heartSprite).m_CachedPtr != (IntPtr)0)
			{
				PhaserSprite phaserSprite = _heartSprite.setVisible(visible: false);
			}
		}
	}

	public void StartSpaceTweens()
	{
		//IL_002c: Expected I, but got O
		//IL_0084: Expected I, but got O
		//IL_00dc: Expected I, but got O
		//IL_0134: Expected I, but got O
		//IL_0198: Expected O, but got I4
		//IL_01f3: Expected I, but got O
		//IL_0249: Expected O, but got I4
		//IL_0293: Expected I4, but got I8
		//IL_02f8: Expected I, but got O
		//IL_034e: Expected O, but got I4
		//IL_0398: Expected I4, but got I8
		//IL_03fd: Expected I, but got O
		//IL_0453: Expected O, but got I4
		//IL_049d: Expected I4, but got I8
		//IL_0502: Expected I, but got O
		//IL_0558: Expected O, but got I4
		//IL_05a2: Expected I4, but got I8
		_spaceTweensActive = true;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[4];
		if ((object)_starsA != null)
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
		if ((object)_starsB != null)
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
		if ((object)_starsC != null)
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
		if ((object)_starsD != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 420f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_starsA != null)
		{
			nint num5 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.duration = 212.5f;
		tweenConfig2.yoyo = true;
		tweenConfig2.delay = 425f;
		tweenConfig2.repeatDelay = 1275f;
		tweenConfig2.repeat = -1;
		MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		if ((object)_starsB != null)
		{
			nint num6 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
				throw ex6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		tweenConfig3.alpha = (float?)(object)1;
		tweenConfig3.duration = 212.5f;
		tweenConfig3.yoyo = true;
		tweenConfig3.delay = 850f;
		tweenConfig3.repeatDelay = 1275f;
		tweenConfig3.repeat = -1;
		MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
		TweenConfig tweenConfig4 = new TweenConfig();
		object[] array4 = new object[1];
		if ((object)_starsC != null)
		{
			nint num7 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
				throw ex7;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig4.targets = array4;
		tweenConfig4.alpha = (float?)(object)1;
		tweenConfig4.duration = 212.5f;
		tweenConfig4.yoyo = true;
		tweenConfig4.delay = 1275f;
		tweenConfig4.repeatDelay = 1275f;
		tweenConfig4.repeat = -1;
		MultiTargetTween multiTargetTween4 = Tweens.Add(tweenConfig4);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
		TweenConfig tweenConfig5 = new TweenConfig();
		object[] array5 = new object[1];
		if ((object)_starsD != null)
		{
			nint num8 = (nint)array5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			if (obj8 == null)
			{
				ArrayTypeMismatchException ex8 = new ArrayTypeMismatchException();
				throw ex8;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig5.targets = array5;
		tweenConfig5.alpha = (float?)(object)1;
		tweenConfig5.duration = 212.5f;
		tweenConfig5.yoyo = true;
		tweenConfig5.delay = 1700f;
		tweenConfig5.repeatDelay = 1275f;
		tweenConfig5.repeat = -1;
		MultiTargetTween multiTargetTween5 = Tweens.Add(tweenConfig5);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
	}

	public override void Cleanup()
	{
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		config._003CSelectedBGM_003Ek__BackingField = _saveBgm;
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		config2._003CSelectedBGMMod_003Ek__BackingField = _saveBgmMod;
		List<Tilemap> list = stageTilemaps;
		int version = list._version + 1;
		list._version = version;
		list._size = 0;
		if (list._size > 0)
		{
			Array.Clear(list._items, 0, list._size);
		}
	}

	public override void EnableMovingBackground()
	{
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
		GameManager core4 = GM.Core;
		Stage stage = core4._stage;
		Tilemap tilemapLayer = stage._tilingTileset.GetTilemapLayer("Obstacle");
		if ((object)tilemapLayer != null && ((UnityEngine.Object)tilemapLayer).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = tilemapLayer.gameObject;
			gameObject.SetActive(value: true);
		}
		GameManager core5 = GM.Core;
		Stage stage2 = core5._stage;
		Tilemap tilemapLayer2 = stage2._tilingTileset.GetTilemapLayer("Decals");
		if ((object)tilemapLayer2 != null && ((UnityEngine.Object)tilemapLayer2).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject2 = tilemapLayer2.gameObject;
			gameObject2.SetActive(value: true);
		}
		if (_spaceTweensActive)
		{
			StartSpaceTweens();
		}
	}

	public override void DisableMovingBackground()
	{
		//IL_04cf: Expected I, but got O
		//IL_0012: Expected I, but got O
		//IL_0048: Expected I, but got O
		//IL_00cf: Expected I, but got O
		//IL_0111: Expected I, but got O
		//IL_0143: Expected I, but got O
		//IL_0171: Expected I, but got O
		//IL_0208: Expected I, but got O
		//IL_02b6: Expected I, but got O
		//IL_034d: Expected I, but got O
		//IL_0287: Expected I, but got O
		//IL_0552: Expected I, but got O
		//IL_03a8: Expected I, but got O
		//IL_03da: Expected I, but got O
		//IL_05a0: Expected I, but got O
		//IL_03fe: Expected I, but got O
		//IL_04a4: Expected O, but got I
		_speedFactor = 0f;
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		bool flag = (object)GM.Core == null;
		nint num3 = num2;
		if (!flag)
		{
			num3 = (nint)core._bgMan;
			if ((object)core._bgMan != null)
			{
				_ = 0;
				nint num4 = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rax_v9 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
				num3 = 0;
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					TilingBackground bgMan = core2._bgMan;
					if ((object)core2._bgMan != null)
					{
						bool flag2 = (object)bgMan._bgtile == null;
						num3 = (nint)bgMan._bgtile;
						if (!flag2)
						{
							Transform transform = bgMan._bgtile.transform;
							Camera main = Camera.main;
							bool flag3 = (object)main == null;
							num3 = unchecked((nint)null);
							if (!flag3)
							{
								Transform parent = main.transform;
								bool flag4 = (object)transform == null;
								num3 = (nint)main;
								if (!flag4)
								{
									transform.SetParent(parent, worldPositionStays: true);
									nint num5 = (nint)typeof(GM);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v16 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
									nint num6 = 0;
									GameManager core3 = GM.Core;
									bool flag5 = (object)GM.Core == null;
									num3 = num6;
									if (!flag5)
									{
										Stage stage = core3._stage;
										bool flag6 = (object)core3._stage == null;
										num3 = num6;
										if (!flag6)
										{
											bool flag7 = (object)stage._tilingTileset == null;
											num3 = (nint)stage._tilingTileset;
											if (!flag7)
											{
												Tilemap tilemapLayer = stage._tilingTileset.GetTilemapLayer("Obstacle");
												if ((object)tilemapLayer != null && ((UnityEngine.Object)tilemapLayer).m_CachedPtr != (IntPtr)0)
												{
													GameObject gameObject = tilemapLayer.gameObject;
													bool flag8 = (object)gameObject == null;
													num3 = (nint)tilemapLayer;
													if (flag8)
													{
														goto IL_04aa;
													}
													gameObject.SetActive(value: false);
												}
												nint num7 = (nint)typeof(GM);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v526 @ rax_v25 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
												nint num8 = 0;
												GameManager core4 = GM.Core;
												bool flag9 = (object)GM.Core == null;
												num3 = num8;
												if (!flag9)
												{
													Stage stage2 = core4._stage;
													bool flag10 = (object)core4._stage == null;
													num3 = num8;
													if (!flag10)
													{
														bool flag11 = (object)stage2._tilingTileset == null;
														num3 = (nint)stage2._tilingTileset;
														if (!flag11)
														{
															Tilemap tilemapLayer2 = stage2._tilingTileset.GetTilemapLayer("Decals");
															bool flag12 = (object)tilemapLayer2 == null;
															num3 = (nint)typeof(UnityEngine.Object);
															if (!flag12)
															{
																bool flag13 = ((UnityEngine.Object)tilemapLayer2).m_CachedPtr == (IntPtr)0;
																num3 = (nint)typeof(UnityEngine.Object);
																if (!flag13)
																{
																	GameObject gameObject2 = tilemapLayer2.gameObject;
																	bool flag14 = (object)gameObject2 == null;
																	num3 = (nint)tilemapLayer2;
																	if (flag14)
																	{
																		goto IL_04aa;
																	}
																	gameObject2.SetActive(value: false);
																	num3 = (nint)gameObject2;
																}
															}
															if (spaceTweens != null)
															{
																List<MultiTargetTween>.Enumerator enumerator = default(List<MultiTargetTween>.Enumerator);
																if (enumerator.MoveNext())
																{
																	MultiTargetTween multiTargetTween = null;
																	throw new NullReferenceException();
																}
																num3 = (nint)spaceTweens;
																if (spaceTweens != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v4 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+1C]");
																	_ = (nint)0 + (nint)1;
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v4 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+18]");
																	if ((nint)0 > (nint)0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v4 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+10]");
																		nint num9 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v4 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+18]");
																		Array.Clear((Array)num9, 0, 0);
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
		goto IL_04aa;
		IL_04aa:
		throw new NullReferenceException();
	}

	public BackgroundSpace()
	{
		//IL_0010: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		_speedFactor = 1.1f;
		alphaMinuteStart = 11;
		List<Tilemap> list = new List<Tilemap>();
		stageTilemaps = list;
		relicPosition = (float2)1159725056;
		_ = 1159725056;
		_center = (float2)1159725056;
		_ = 1159725056;
		base._002Ector();
	}
}
