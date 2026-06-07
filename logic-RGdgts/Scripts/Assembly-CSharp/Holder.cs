using System;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UI.Common;
using UnityEngine;

public class Holder : SerializedMonoBehaviour
{
	public enum TransitionDurations
	{
		Short = 0,
		Normal = 1,
		Longish = 2,
		Long = 3,
		Shortest = 4
	}

	[Serializable]
	public class ConsoleColor
	{
		public int foregroundId;

		public int backgroundId;

		public Color color;
	}

	public string documentationURL;

	public string discordURL;

	public string twitterURL;

	public string redditURL;

	public float defaultTicksPerSecond;

	public AnimationCurve flipMotherboardCurve;

	public GameObject motherboardPrefab;

	public MultitoolConnectorVariations defaultMultitoolConnectorVariation;

	public PowerButtonVariations[] defaultPowerButtonVariations;

	public float motherboardShadowDistanceMultiplier;

	[SortingLayer]
	public int[] excludedSortingLayersFromModulesLights;

	public Dictionary<string, AssetType> assetFileExtensions;

	public int cameraMovementBorderSize;

	public float cameraMovementSpeed;

	public AnimationCurve cameraMovementCurve;

	public float zoomValue;

	public TransitionDurations zoomInTransitionDuration;

	public TransitionDurations zoomOutTransitionDuration;

	public Ease zoomEase;

	public int maxStickerWidth;

	public Sprite defaultUIcursor;

	public Dictionary<int, UIColorEntity> UIColorPalette;

	public Dictionary<TransitionDurations, float> transitionDurations;

	public Dictionary<ModuleGestalt.ModuleGroup, Sprite> moduleGroupIcons;

	public Dictionary<AssetType, GameObject> assetInspector;

	public Dictionary<AssetType, Sprite> assetIcons;

	public Dictionary<AssetType, Sprite> assetCreateIcoon;

	public Dictionary<AssetType, MultiToolAppTypes> assetEditorApp;

	public Dictionary<MultiToolAppTypes, Sprite> appIcon;

	public Dictionary<GadgetWorkshopStates, Sprite> gadgetStatusIcon;

	public ConsoleColor[] consoleColors;

	public Material spriteLitMaterial;

	public Material shadowMaterial;

	public Material gadgetPreview;

	public Material printingGadgetPreview;

	public Material printingGadgetShadow;

	public Material blitMotherboardCaseDataMaterial;

	public Material hologramMaterial;

	public Material blitWebcamMaterial;

	public Material paletteMaterial;

	public Material paletteTextureMaterial;

	public Material renderShadedGadgetMaterial;

	[Space]
	public Material motherboardBlitMaterial;

	public Material motherboardBlitNormalMaterial;

	public Dictionary<Motherboard.Layer, Material> motherboardLayersMaterial;

	[Space]
	public Material renderPointMaterial;

	public Material renderPointGridMaterial;

	public Material renderLineMaterial;

	public Material renderCircleMaterial;

	public Material fillCircleMaterial;

	public Material drawSpriteRGBMaterial;

	public Material drawSpritePaletteMaterial;

	public Material rasterSpriteRGBMaterial;

	public Material rasterSpritePaletteMaterial;

	public Material fillColorMaterial;

	public Shader projectorBlitAlphaShader;

	public Shader destroyingGadgetPreview;

	public Shader destroyingGadgetShadow;

	public Shader blitSpritesheetShader;

	public Shader blitPrintEffectShader;

	public Shader blitMaskPrintShader;

	public Shader blitStickerDataShader;

	public Shader blitColorShader;

	public Sprite onePixelWhiteSprite;

	public Texture2D flatNormal;

	public Texture2D flatGadgetNormal;

	public Sprite noGadgetDrawerPreviewSprite;

	public Sprite noGadgetUIPreviewSprite;

	public Texture2D webcamNotConnectedTexture;

	public Texture2D webcamNotAllowedTexture;

	public static Holder instance;

	public static Dictionary<string, ModuleGestalt.Variation> sortedModuleGestaltVariationsByFullName;

	public static Dictionary<ModuleGestalt.ModuleCategory, List<ModuleGestalt.Variation>> sortedModuleGestaltVariationsByCategory;

	public static Dictionary<ModuleGestaltEnum, ModuleGestalt> moduleGestalts;

	public static Dictionary<ModuleGestaltVariationEnum, ModuleGestalt.Variation> moduleGestaltVariations;

	public static Dictionary<MotherboardSectionEnum, MotherboardSection> motherboardSections;

	public static Dictionary<CursorGestaltEnum, CursorGestalt> cursorGestalts;

	public static Dictionary<BrushGestaltEnum, BrushGestalt> brushGestalts;

	public static Dictionary<(ModuleGestalt.ModuleCategory, ModuleGestalt.ModuleGroup), ModulesDrawerGroupLayout> drawerLayoutsByModuleGroup;

	public static Dictionary<DataSelectionGestaltEnum, DataSelectionGestalt> dataSelectionGestalts;

	public static List<Color> colorSwatches;

	public static string userDataPath;

	public static string importPath;

	public static string exportPath;

	public static string recorderVideoPath;

	public static string gadgetsPath;

	public static string retroPath;

	public static string launcherConfigurationPath;

	public static char decimalSeparator;

	public const float pixelsPerUnit = 24f;

	public const float pixelSize = 1f / 24f;

	public const float gridSize = 1f / 24f;

	public static int[] moduleLightsSortingLayers;

	public static bool gadgetsDirCreated;

	private static string _colorSwatchesPath;

	[NonSerialized]
	[HideInInspector]
	public Dictionary<int, ConsoleColor> consoleForegroundColors;

	[NonSerialized]
	[HideInInspector]
	public Dictionary<int, ConsoleColor> consoleBackgroundColors;

	[NonSerialized]
	[HideInInspector]
	public Dictionary<ModuleGestaltEnum, Module> uniqueModules;

	[NonSerialized]
	[HideInInspector]
	public List<Texture2D> customCuttingMatTextures;

	private void Awake()
	{
	}

	public void ReloadCuttingMatTextures()
	{
	}

	private void FillWithImportSamples(string path)
	{
	}

	public static void LoadGestalts()
	{
	}

	public static Vector3 FloorCoordinate(Vector3 coord)
	{
		return default(Vector3);
	}

	public static Vector3 RoundCoordinate(Vector3 coord)
	{
		return default(Vector3);
	}

	public static Vector2Int WorldToPixelCoordinate(Vector3 coord)
	{
		return default(Vector2Int);
	}

	public static Vector2 PixelToWorld(Vector2Int p)
	{
		return default(Vector2);
	}

	public void RegisterLuaGestalts()
	{
	}

	public Sprite GetModuleGroupIcon(ModuleGestaltVariationEnum variationEnum)
	{
		return null;
	}

	public Sprite GetAssetIcon(AssetType assetT)
	{
		return null;
	}

	public Sprite GetCreateAssetIcon(AssetType assetT)
	{
		return null;
	}

	public Sprite GetAppIcon(MultiToolAppTypes appType)
	{
		return null;
	}

	public Sprite GetGadgetStatusIcon(GadgetWorkshopStates gadgetStatus)
	{
		return null;
	}

	public GameObject GetAssetInspector(AssetType assetType)
	{
		return null;
	}

	public MultiToolAppTypes GetAssetEditorApp(AssetType assetType)
	{
		return default(MultiToolAppTypes);
	}

	public List<string> GetAssetExtension(AssetType assetT)
	{
		return null;
	}

	public AssetType GetAssetTypeFromFilename(string filename)
	{
		return default(AssetType);
	}

	public AssetType GetAssetTypeFromExtension(string fileExtension)
	{
		return default(AssetType);
	}

	private void DeleteAllPlayerPrefs()
	{
	}

	private void DeleteVideoSettings()
	{
	}
}
