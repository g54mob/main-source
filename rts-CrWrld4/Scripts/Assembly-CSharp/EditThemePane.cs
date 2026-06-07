using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions.ColorPicker;

public class EditThemePane : MonoBehaviour
{
	public GameObject controls;

	public Texture2D landAtlas64;

	public ColorPickerControl colorPicker;

	public Transform customDropdownList;

	public TextureListManager terrainTextureListManager;

	public TextureListManager terrainNormalListManager;

	public TextMeshProUGUI nameText;

	public GameObject undoButton;

	public GameObject redoButton;

	public ColorButton colorButton;

	public InputField colorBoost;

	public Slider scaleSlider;

	public Toggle stochasticToggle;

	public Slider normalIntensitySlider;

	public Slider normalScaleSlider;

	public InputField createThemeNameInputField;

	public MessageDialog messageDialog;

	public GameObject applyToMapButton;

	public GameObject textureControls;

	public GameObject normalControls;

	public ConfirmDialog confirmDialog;

	public Toggle cliffTextureToggle;

	public SliderInput cliffScaleSlider;

	public ColorButton cliffColorButton;

	public InputField cliffColorBoost;

	public Toggle cliffNormalTextureToggle;

	public SliderInput cliffNormalIntensitySlider;

	public SliderInput cliffNormalScaleSlider;

	public InputField minAutoBright;

	public InputField maxAutoBright;

	public InputField allAutoBright;

	public Dropdown customImageSlotDropdown;

	public OverlayManager overlayManager0;

	public OverlayManager overlayManager1;

	public GameObject terrainTexturesTab;

	public GameObject normalTexturesTab;

	private string lastThemeViewed;

	private TerrainTheme _theme;

	private int pickingTextureColor;

	public ConfirmDialog2 confirmDialog2;

	private bool needsSaving;

	private string _loadedThemeFile;

	private MaxStack<TerrainTheme> undoStack;

	private MaxStack<TerrainTheme> redoStack;

	private float lastSaveTime;

	private Color32[] grayPixels256;

	public TerrainTheme theme
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private string loadedThemeFile
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void RefreshDropdown()
	{
	}

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}

	public void Update()
	{
	}

	public void SetTheme(TerrainTheme theme)
	{
	}

	public void OnCancel()
	{
	}

	public void OnOverlay0ColorButtonClicked(Color cc)
	{
	}

	public void OnOverlay1ColorButtonClicked(Color cc)
	{
	}

	public void OnTextureColorButtonClicked()
	{
	}

	public void OnCliffColorButtonClicked()
	{
	}

	public void OnColorPicked(Color color)
	{
	}

	public void RefreshThemeView()
	{
	}

	public void OnColorChosen(Color color)
	{
	}

	private void ClearUndoStack()
	{
	}

	private void ClearRedoStack()
	{
	}

	public void PushUndo(bool clear = true)
	{
	}

	private void PushRedo()
	{
	}

	private void PopUndo()
	{
	}

	private void PopRedo()
	{
	}

	public void OnUndo()
	{
	}

	public void OnRedo()
	{
	}

	public void OnNewTheme()
	{
	}

	public void OnOpenTheme()
	{
	}

	public void OnSaveTheme()
	{
	}

	public void OnSaveAsTheme()
	{
	}

	public void OnCopyFromMapTheme()
	{
	}

	public void ImportThemeFromFile()
	{
	}

	private void ImportThemeBrowserOutput(string path)
	{
	}

	public void ExportThemeToFile()
	{
	}

	private void ExportThemeBrowserOutput(string path)
	{
	}

	public void OnApplyToMap()
	{
	}

	public void OnTerrainTextureSelected(int val)
	{
	}

	public void OnTerrainNormalSelected(int val)
	{
	}

	public void OnCliffTextureSelected()
	{
	}

	public void OnCliffNormalTextureSelected()
	{
	}

	public void PickedTextureFromAtlas(short val)
	{
	}

	public void PickedNormalFromAtlas(short val)
	{
	}

	public void PickedTextureFromAtlasForCliff(short val)
	{
	}

	public void PickedTextureFromAtlasForCliffNormal(short val)
	{
	}

	public void OnColorChanged(Color color)
	{
	}

	public void OnColorBoostChanged(string val)
	{
	}

	public void OnCliffColorBoostChanged(string val)
	{
	}

	public void OnScaleChanged(float i)
	{
	}

	public void OnNormalIntensityChanged(float i)
	{
	}

	public void OnNormalScaleChanged(float i)
	{
	}

	public void OnStochasticChanged(bool val)
	{
	}

	public void LoadImageFromFile()
	{
	}

	private void LoadImageBrowserOutput(string path)
	{
	}

	public void LoadOverlay0ImageFromFile()
	{
	}

	private void LoadOverlay0ImageBrowserOutput(string path)
	{
	}

	public void LoadOverlay1ImageFromFile()
	{
	}

	private void LoadOverlay1ImageBrowserOutput(string path)
	{
	}

	private void FileBrowserWindowClosed()
	{
	}

	private Texture2D CreateCustomTexture(byte[] data, bool scale, bool mipchain)
	{
		return null;
	}

	private Texture2D CreateOverlayTexture(byte[] data)
	{
		return null;
	}

	public void OnDeleteCustomTexture()
	{
	}

	public void OnCliffColorChanged(Color color)
	{
	}

	public void OnCliffScaleChanged(float i)
	{
	}

	public void OnCliffNormalScaleChanged(float i)
	{
	}

	public void OnCliffNormalIntensityChanged(float i)
	{
	}

	private void SetCliffColor(Color color)
	{
	}

	public void OnDefaultTexture()
	{
	}

	public void OnDefaultNormalTexture()
	{
	}

	public void OnRandomTextures()
	{
	}

	public void OnChangeBrightness(float val)
	{
	}

	public void OnAutoRampBrightness()
	{
	}

	public void OnCopyNormalAllUp()
	{
	}

	public void OnCopyNormalTextureUp()
	{
	}

	public void OnCopyNormalScaleUp()
	{
	}

	public void OnCopyNormalIntensityUp()
	{
	}

	public void OnCopyNormalAllDown()
	{
	}

	public void OnCopyNormalTextureDown()
	{
	}

	public void OnCopyNormalScaleDown()
	{
	}

	public void OnCopyNormalIntensityDown()
	{
	}

	private void OnCopyNormalUp(bool copyTexture, bool copyScale, bool copyIntensity)
	{
	}

	private void OnCopyNormalDown(bool copyTexture, bool copyScale, bool copyIntensity)
	{
	}

	public void OnCopyAllUp()
	{
	}

	public void OnCopyTextureUp()
	{
	}

	public void OnCopyColorUp()
	{
	}

	public void OnCopyScaleUp()
	{
	}

	public void OnCopyStochasticUp()
	{
	}

	public void OnCopyAllDown()
	{
	}

	public void OnCopyTextureDown()
	{
	}

	public void OnCopyColorDown()
	{
	}

	public void OnCopyScaleDown()
	{
	}

	public void OnCopyStochasticDown()
	{
	}

	private void OnCopyUp(bool copyTexture, bool copyColor, bool copyScale, bool copyStochastic)
	{
	}

	private void OnCopyDown(bool copyTexture, bool copyColor, bool copyScale, bool copyStochastic)
	{
	}

	public static Texture2D GetNormalMap(Color32[] pixels, int textureWidth, int textureHeight, float str = 1f)
	{
		return null;
	}

	private static float Intensity(Color32[] pixels, int textureWidth, int textureHeight, int x, int y)
	{
		return 0f;
	}
}
