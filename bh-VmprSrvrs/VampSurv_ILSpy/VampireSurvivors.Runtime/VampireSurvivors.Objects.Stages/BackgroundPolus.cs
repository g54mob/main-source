using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundPolus : BackgroundManager
{
	private MeshRenderer _magicWaterImage;

	private TileSprite _lavaTile;

	private bool _hasShaderBackground;

	private PhaserSprite _waterAnim;

	private float scrollOffset;

	private bool _hasGeneratedBackgroundSprites;

	private TileSprite _backgroundStars;

	private PhaserSprite _backgroundMountainsFar;

	private PhaserSprite _backgroundMountainsMid;

	private PhaserSprite _backgroundMountainsNear;

	private SpriteScroller _backgroundMountainsFarScroller;

	private SpriteScroller _backgroundMountainsMidScroller;

	private SpriteScroller _backgroundMountainsNearScroller;

	private float _mapHeight;

	public override void Create()
	{
		//IL_014e: Expected O, but got I4
		base.Create();
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "LavaTile1");
		PhaserSprite waterAnim = phaserSprite.setVisible(visible: false);
		_waterAnim = waterAnim;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("LavaTile", 1, 16, "vfx", num);
		PhaserSprite waterAnim2 = _waterAnim;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		waterAnim2._spriteAnimation.AddAnimation("loop", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite waterAnim3 = _waterAnim;
		waterAnim3._spriteAnimation.SetAnimation("loop");
		GameManager core = GM.Core;
		Stage stage = core._stage;
		SuperMap defaultMap = stage._tilingTileset.DefaultMap;
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		SuperMap defaultMap2 = stage2._tilingTileset.DefaultMap;
		object obj = defaultMap.m_TileHeight * defaultMap2.m_Height;
		float mapHeight = (float)obj * 0.01f;
		_mapHeight = mapHeight;
		MakeTheLava();
		MakeBackgroundSprites();
	}

	protected override void OnUpdate()
	{
		//IL_00ec: Expected F4, but got I
		//IL_010b: Expected F4, but got I
		if (!_hasShaderBackground)
		{
			PhaserSprite waterAnim = _waterAnim;
			Sprite sprite = waterAnim._spriteRenderer.sprite;
			string frameName = ((UnityEngine.Object)sprite).GetName();
			_lavaTile.SetFrame(frameName, "vfx");
			TileSprite lavaTile = _lavaTile;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float scrollOffsetX = (lavaTile._xScrollOffset = scrollOffset + (float)renderer.screenCenter);
			lavaTile._spriteScroller.SetScrollOffsetX(scrollOffsetX);
			TileSprite lavaTile2 = _lavaTile;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v18 (PhaserScene+Renderer)+38]");
			lavaTile2._yScrollOffset = 0f;
			SpriteScroller spriteScroller = lavaTile2._spriteScroller;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v18 (PhaserScene+Renderer)+38]");
			spriteScroller.SetScrollOffsetY(0f);
		}
	}

	private void LateUpdate()
	{
		if (_hasGeneratedBackgroundSprites)
		{
			Transform trans = _backgroundStars.transform;
			ShiftY(trans, -24f);
			Transform trans2 = _backgroundMountainsNear.transform;
			LockY(trans2, -24f);
			Transform trans3 = _backgroundMountainsMid.transform;
			LockY(trans3, -22.6f);
			Transform trans4 = _backgroundMountainsFar.transform;
			LockY(trans4, -21.5f);
			ForceScrollOffset(_backgroundMountainsNearScroller);
			ForceScrollOffset(_backgroundMountainsMidScroller);
			ForceScrollOffset(_backgroundMountainsFarScroller);
		}
	}

	public override void Cleanup()
	{
		//IL_0013: Expected O, but got I4
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		GameManager core = GM.Core;
		core._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
	}

	private void InitVFX()
	{
		//IL_0231: Expected I4, but got I8
		GameObject original = Resources.Load<GameObject>("MagicWater");
		Camera main = Camera.main;
		Transform parent = main.transform;
		GameObject gameObject = UnityEngine.Object.Instantiate(original, parent, worldPositionStays: false);
		int2 renderTextureSize = CameraExtensions.GetRenderTextureSize(_mainCamera);
		Transform transform = gameObject.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform transform2 = gameObject.transform;
		Transform child = transform2.GetChild(0);
		GameObject gameObject2 = child.gameObject;
		int layer = (gameObject2.layer = LayerMask.NameToLayer("Default"));
		gameObject.layer = layer;
		Transform transform3 = gameObject.transform;
		Transform child2 = transform3.GetChild(0);
		bool flag2 = ((UnityEngine.Object)child2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)child2).m_CachedPtr, ref value2);
		Transform transform4 = gameObject.transform;
		Transform child3 = transform4.GetChild(0);
		MeshRenderer component = child3.GetComponent<MeshRenderer>();
		bool flag3 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		Renderer.set_sortingOrder_Injected(((UnityEngine.Object)component).m_CachedPtr, -9000);
		Transform transform5 = gameObject.transform;
		Transform child4 = transform5.GetChild(0);
		MeshRenderer component2 = child4.GetComponent<MeshRenderer>();
		_magicWaterImage = component2;
	}

	private void MakeTheLava()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float y = renderer2.height * 0.5f;
		float x = renderer.width * 0.5f;
		GameObject go = base.gameObject;
		string spriteName = default(string);
		TileSpriteBuilder tileSpriteBuilder = RenderingExtensions.AddTileSprite(go, x, y, "vfx", spriteName);
		tileSpriteBuilder._depth = -10001f;
		tileSpriteBuilder._depthMul = 1f;
		Transform parent = base.transform;
		tileSpriteBuilder._parent = parent;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		PhaserScene s_scene4 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer4 = s_scene4._renderer;
		tileSpriteBuilder._tileHeight = renderer4.height;
		tileSpriteBuilder._tileWidth = renderer3.width;
		tileSpriteBuilder._name = "LavaTile";
		TileSprite lavaTile = tileSpriteBuilder.Build();
		_lavaTile = lavaTile;
		TileSprite tileSprite = RenderingExtensions.SetScrollFactor(_lavaTile, 0f);
	}

	private void MakeBackgroundSprites()
	{
		//IL_033e: Expected O, but got I4
		//IL_045c: Expected O, but got I4
		//IL_057a: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		if (stage._stageType != StageType.POLUS && stage._stageType != StageType.ADV_CHAL_002_Security && stage._stageType != StageType.ADV_CHAL_006_Trouble)
		{
			return;
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float y = renderer2.height * 0.5f;
		float x = renderer.width * 0.5f;
		GameObject go = base.gameObject;
		string spriteName = default(string);
		TileSpriteBuilder tileSpriteBuilder = RenderingExtensions.AddTileSprite(go, x, y, "collab1_parallax_stars_final", spriteName);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer3 = s_scene3._renderer;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer4 = s_scene4._renderer;
				tileSpriteBuilder._tileWidth = renderer3.width;
				tileSpriteBuilder._tileHeight = renderer4.height;
				tileSpriteBuilder._depth = -10000f;
				tileSpriteBuilder._depthMul = 1f;
				tileSpriteBuilder._name = "PolusBackgroundStars";
				TileSprite backgroundStars = tileSpriteBuilder.Build();
				_backgroundStars = backgroundStars;
				TileSprite tileSprite = RenderingExtensions.SetScrollFactor(_backgroundStars, 0f);
				GameManager core2 = GM.Core;
				PlayerOptionsData config = core2._playerOptions.Config;
				if (config._003CSelectedInverse_003Ek__BackingField)
				{
				}
				GameManager core3 = GM.Core;
				PlayerOptionsData config2 = core3._playerOptions.Config;
				if (config2._003CSelectedInverse_003Ek__BackingField || (object)GM.Core != null)
				{
					GameManager core4 = GM.Core;
					PlayerOptionsData config3 = core4._playerOptions.Config;
					if (!config3._003CSelectedInverse_003Ek__BackingField || (object)GM.Core != null)
					{
						GameObject gameObject = base.gameObject;
						Vector2 pos = default(Vector2);
						PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "collab1 parallax front", "collab1 parallax front");
						PhaserSprite phaserSprite2 = phaserSprite.setDepth(-9997f);
						PhaserSprite phaserSprite3 = phaserSprite2.setOrigin(0.5f, (float?)(object)1);
						PhaserSprite phaserSprite4 = phaserSprite3.SetAsTiledSprite();
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene5 = ArcadePhysics.s_scene;
							PhaserScene.Renderer renderer5 = s_scene5._renderer;
							PhaserSprite component = phaserSprite4.SetTileWidth(renderer5.width);
							PhaserSprite phaserSprite5 = RenderingExtensions.SetScrollFactor(component, 0f);
							GameObject gameObject2 = phaserSprite5.gameObject;
							((UnityEngine.Object)gameObject2).SetName("PolusBackgroundMountainsNear");
							_backgroundMountainsNear = phaserSprite5;
							if ((object)GM.Core != null)
							{
								GameObject gameObject3 = base.gameObject;
								PhaserSprite phaserSprite6 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "collab1 parallax mid", "collab1 parallax mid");
								PhaserSprite phaserSprite7 = phaserSprite6.setDepth(-9998f);
								PhaserSprite phaserSprite8 = phaserSprite7.setOrigin(0.5f, (float?)(object)1);
								PhaserSprite phaserSprite9 = phaserSprite8.SetAsTiledSprite();
								if ((object)GM.Core != null)
								{
									PhaserScene s_scene6 = ArcadePhysics.s_scene;
									PhaserScene.Renderer renderer6 = s_scene6._renderer;
									PhaserSprite component2 = phaserSprite9.SetTileWidth(renderer6.width);
									PhaserSprite phaserSprite10 = RenderingExtensions.SetScrollFactor(component2, 0f);
									GameObject gameObject4 = phaserSprite10.gameObject;
									((UnityEngine.Object)gameObject4).SetName("PolusBackgroundMountainsMid");
									_backgroundMountainsMid = phaserSprite10;
									if ((object)GM.Core != null)
									{
										GameObject gameObject5 = base.gameObject;
										PhaserSprite phaserSprite11 = RenderingExtensions.AddPhaserSprite(gameObject5, pos, "collab1 parallax back", "collab1 parallax back");
										PhaserSprite phaserSprite12 = phaserSprite11.setDepth(-9999f);
										PhaserSprite phaserSprite13 = phaserSprite12.setOrigin(0.5f, (float?)(object)1);
										PhaserSprite phaserSprite14 = phaserSprite13.SetAsTiledSprite();
										if ((object)GM.Core != null)
										{
											PhaserScene s_scene7 = ArcadePhysics.s_scene;
											PhaserScene.Renderer renderer7 = s_scene7._renderer;
											PhaserSprite component3 = phaserSprite14.SetTileWidth(renderer7.width);
											PhaserSprite phaserSprite15 = RenderingExtensions.SetScrollFactor(component3, 0f);
											GameObject gameObject6 = phaserSprite15.gameObject;
											((UnityEngine.Object)gameObject6).SetName("PolusBackgroundMountainsFar");
											_backgroundMountainsFar = phaserSprite15;
											PhaserSprite backgroundMountainsNear = _backgroundMountainsNear;
											GameObject gameObject7 = backgroundMountainsNear._spriteRenderer.gameObject;
											SpriteScroller backgroundMountainsNearScroller = gameObject7.AddComponent<SpriteScroller>();
											_backgroundMountainsNearScroller = backgroundMountainsNearScroller;
											PhaserSprite backgroundMountainsMid = _backgroundMountainsMid;
											GameObject gameObject8 = backgroundMountainsMid._spriteRenderer.gameObject;
											SpriteScroller backgroundMountainsMidScroller = gameObject8.AddComponent<SpriteScroller>();
											_backgroundMountainsMidScroller = backgroundMountainsMidScroller;
											PhaserSprite backgroundMountainsFar = _backgroundMountainsFar;
											GameObject gameObject9 = backgroundMountainsFar._spriteRenderer.gameObject;
											SpriteScroller backgroundMountainsFarScroller = gameObject9.AddComponent<SpriteScroller>();
											_backgroundMountainsFarScroller = backgroundMountainsFarScroller;
											GameManager core5 = GM.Core;
											PlayerOptionsData config4 = core5._playerOptions.Config;
											if (config4._003CSelectedInverse_003Ek__BackingField)
											{
												GameManager core6 = GM.Core;
												PlayerOptionsData config5 = core6._playerOptions.Config;
												if (config5._003CVisuallyInvertStages_003Ek__BackingField)
												{
													TileSprite backgroundStars2 = _backgroundStars;
													backgroundStars2._spriteRenderer.flipY = true;
													PhaserSprite phaserSprite16 = _backgroundMountainsNear.setFlipY(flipY: true);
													PhaserSprite phaserSprite17 = _backgroundMountainsMid.setFlipY(flipY: true);
													PhaserSprite phaserSprite18 = _backgroundMountainsFar.setFlipY(flipY: true);
												}
											}
											_hasGeneratedBackgroundSprites = true;
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
		throw new NullReferenceException();
	}

	private void LockY(Transform trans, float yPos)
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CSelectedInverse_003Ek__BackingField)
		{
		}
		bool flag = ((UnityEngine.Object)trans).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)trans).m_CachedPtr, out Vector3 _);
		bool flag2 = ((UnityEngine.Object)trans).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)trans).m_CachedPtr, ref value);
	}

	private void ShiftY(Transform trans, float min)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_023d: Expected O, but got F4
		//IL_0262: Invalid comparison between F4 and I4
		//IL_0271: Invalid comparison between F4 and I4
		//IL_02fc: Expected O, but got I4
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Expected O, but got Unknown
		//IL_02de: Expected I, but got O
		//IL_0167: Expected O, but got I
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01d2: Invalid comparison between F4 and I4
		//IL_01e1: Invalid comparison between F4 and I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag = !config._003CSelectedInverse_003Ek__BackingField;
		float num = min;
		if (!flag)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			bool flag2 = !config2._003CVisuallyInvertStages_003Ek__BackingField;
			num = min;
			if (!flag2)
			{
				float mapHeight = _mapHeight;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				object obj = mapHeight ^ 0;
				float num2 = (float)obj - min;
				num = num2;
			}
		}
		bool flag3 = ((UnityEngine.Object)trans).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)trans).m_CachedPtr, out Vector3 _);
		GameManager core3 = GM.Core;
		PlayerOptionsData config3 = core3._playerOptions.Config;
		bool flag4;
		bool flag5;
		bool flag6;
		if (config3._003CSelectedInverse_003Ek__BackingField)
		{
			GameManager core4 = GM.Core;
			PlayerOptionsData config4 = core4._playerOptions.Config;
			if (config4._003CVisuallyInvertStages_003Ek__BackingField)
			{
				nint num3 = (nint)ArcadePhysics.s_scene;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r9_v6 (Il2CppMethodInfo)+28]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v52+38]");
				float num4 = 0f - num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v52+38]");
				object obj3 = 0 ^ num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v52+38]");
				object obj4 = 0 ^ num4;
				object obj5 = obj3 & obj4;
				flag4 = (nint)obj5 < 0;
				flag5 = num4 < 0f;
				flag6 = num4 == 0f;
				goto IL_02e3;
			}
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num5 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v44 (PhaserScene+Renderer)+38]");
		float num6 = num5 - 0f;
		float num7 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v44 (PhaserScene+Renderer)+38]");
		object obj6 = num7 ^ 0;
		object obj7 = num ^ num6;
		object obj8 = obj6 & obj7;
		flag4 = (nint)obj8 < 0;
		flag5 = num6 < 0f;
		flag6 = num6 == 0f;
		goto IL_02e3;
		IL_02e3:
		bool flag7 = flag5 == flag4;
		object obj9 = !flag6;
		object obj10 = flag7 & obj9;
		if (obj10 == null)
		{
		}
		bool flag8 = ((UnityEngine.Object)trans).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)trans).m_CachedPtr, ref value);
	}

	private unsafe void ForceScrollOffset(SpriteScroller scroller)
	{
		if ((object)scroller != null)
		{
			Transform transform = scroller.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				scroller.SetScrollOffsetX(ret);
				return;
			}
		}
		throw new NullReferenceException();
	}
}
