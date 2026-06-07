using UnityEngine;
using UnityEngine.UI;

public class MapEditor : MonoBehaviour
{
	public GameObject fileBrowserPanelPrefab;

	public GameObject editTerrainGameObject;

	public EditUnitPane editUnitPane;

	public EditDecalPane editDecalPane;

	public EditCMods editCModsPane;

	public GameObject terrainTexturePicketWindow;

	public TerrainTexturePicker texturePicker;

	public GameObject cliffTexturePicketWindow;

	public CliffTexturePicker cliffTexturePicker;

	public Toggle editTerrainToggle;

	public Slider editTerrainHeightSlider;

	public Slider editTerrainBrushSize;

	public Slider editTerrainCoverageSlider;

	public Toggle editTerrainBrushLevelLock;

	public Toggle terrainSetHeightToggle;

	public Toggle terrainSmoothToggle;

	public Toggle terrainMesaToggle;

	public Toggle terrainFractalToggle;

	public Slider terrainSmoothSlider;

	public Slider terrainMesaLevelsSlider;

	public Slider terrainMesaHeightSlider;

	public InputField terrainFractalSeedInputField;

	public Slider terrainFractalPersistenceSlider;

	public InputField terrainFractalScaleInputField;

	public Slider terrainFractalHeightSlider;

	public InputField creeperAmt;

	public InputField antiCreeperAmt;

	public Toggle editTexturesToggle;

	public RawImage currentTerrainTextureImage;

	public Material currentTerrainTextureMaterial;

	public Toggle editCliffTexturesToggle;

	public RawImage currentCliffTextureImage;

	public Toggle editDetailToggle;

	public Slider detailOpacity;

	public Slider detailScaleX;

	public Slider detailScaleY;

	public Toggle editDecayToggle;

	public Slider decaySlider;

	public Toggle editCreeperToggle;

	public Toggle editBreederToggle;

	public InputField editCreeperAmt;

	public Toggle editCreeperAC;

	public Dropdown editBreederDropdown;

	public Toggle editScapeToggle;

	public Dropdown scapeItemDropdown;

	public Toggle scapeAutoDelete;

	public Toggle scapeLevelFill;

	public InputField scapeLevelFillAmt;

	public Toggle scapePaintStumps;

	public Slider terrainBrightnessSlider;

	public Slider terrainScaleSlider;

	public Slider cliffScaleSlider;

	public Toggle paintTexturesToggle;

	public Toggle paintBrightnessToggle;

	public Toggle paintAutoBrightnessToggle;

	public InputField autoBrightInputField;

	public Dropdown themeDropdown;

	public Toggle lockTheme;

	public Dropdown planetDropdown;

	private short _currentTerrainTexture;

	private short _currentCliffTexture;

	public short currentTerrainTexture
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public short currentCliffTexture
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	public void Update()
	{
	}

	public void UnselectAll()
	{
	}

	public static string GetDecimalCreeperString(int creeper, int places)
	{
		return null;
	}

	public static int GetCreeperFromDecimalString(string cstring)
	{
		return 0;
	}

	public static string GetDecimalRateString(int creeper, int places, int interval = 30)
	{
		return null;
	}

	public static int GetRateFromDecimalString(string cstring, int interval = 30)
	{
		return 0;
	}

	private void OnEnable()
	{
	}

	public void OnDeleteAllCreeper()
	{
	}

	public void OnDeleteAllAC()
	{
	}

	public void OnFillCreeper()
	{
	}

	public void OnFillAntiCreeper()
	{
	}

	public void OnDampWaves()
	{
	}

	public void OnStumpAll()
	{
	}

	public void OnBuildEmitterClicked()
	{
	}

	public void OnBuildSporeLauncherClicked()
	{
	}

	public void OnBuildBlobNestClicked()
	{
	}

	public void OnBuildVineRootClicked()
	{
	}

	public void OnBuildSkimmerFactoryClicked()
	{
	}

	public void OnBuildDenierClicked()
	{
	}

	public void OnBuildAirSacCauldronClicked()
	{
	}

	public void OnBuildCrystalClicked()
	{
	}

	public void OnBuildFlopeClicked()
	{
	}

	public void OnBuildStashClicked()
	{
	}

	public void OnBuildMonolithClicked()
	{
	}

	public void OnBuildPodClicked()
	{
	}

	public void OnBuildInfoCacheClicked()
	{
	}

	public void OnBuildResourceBlueClicked()
	{
	}

	public void OnBuildResourceRedClicked()
	{
	}

	public void OnBuildResourceGreenClicked()
	{
	}

	public void OnBuildTotemClicked()
	{
	}

	public void OnBuildActivationAntennaClicked()
	{
	}

	public void OnBuildSurvivalBase()
	{
	}

	public void OnBuildERNClicked()
	{
	}

	public void OnBuildDecalClicked()
	{
	}

	public void OnBuildUltracClicked()
	{
	}

	public void OnBuildCytocreepLauncherClicked()
	{
	}

	public void OnBuildPterosaurNestClicked()
	{
	}

	public void OnBuildPterosaurClicked()
	{
	}

	public void OnBuildWallClicked()
	{
	}

	public void OnBuildCrazoniumWallClicked()
	{
	}

	public void OnBuildCollectorPanel5Clicked()
	{
	}

	public void OnBuildCollectorPanel3Clicked()
	{
	}

	public void OnRandomFractalSeed()
	{
	}

	public void OnSmoothTerrain()
	{
	}

	public void OnFractalTerrain()
	{
	}

	public void OnTerrainTextureSelected(short textureID)
	{
	}

	public void OnCliffTextureSelected(short textureID)
	{
	}

	public void OnDetailScaleXChange(float value)
	{
	}

	public void OnDetailScaleYChange(float value)
	{
	}

	private void SetDetailTextureScale()
	{
	}

	public void OnDefaultDetail()
	{
	}

	public void OnTerrainHeightSlider(float value)
	{
	}

	public void OnTerrainBrightnessSlider(float value)
	{
	}

	public void OnTerrainScaleSlider(float value)
	{
	}

	public void OnCliffScaleSlider(float value)
	{
	}

	public void OnRaiseTerrainClicked()
	{
	}

	public void OnLowerTerrainClicked()
	{
	}

	public void OnRepositionUnits()
	{
	}

	public void OnDeleteEggs()
	{
	}

	public void OnPopEggs()
	{
	}

	public void OnDeleteGreenar()
	{
	}

	public void OnResetOrbitals()
	{
	}

	public void OnSetTheme()
	{
	}

	private void FileBrowserWindowClosed()
	{
	}
}
