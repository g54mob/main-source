using UnityEngine;
using UnityEngine.UI;

public class OverlayManager : MonoBehaviour
{
	private long MAX_FILE_SIZE;

	public EditThemePane themePane;

	public int overlayNumber;

	public Toggle enableToggle;

	public InputField scaleX;

	public InputField scaleY;

	public InputField offsetX;

	public InputField offsetY;

	public Toggle cliffCutoff;

	public Image colorButtonImage;

	public SliderInput opacity;

	public RawImage textureImage;

	public Button clearTextureButton;

	public InspectorChoice stockImageChoice;

	public Toggle pointToggle;

	private TerrainTheme tt;

	private bool quell;

	public void Awake()
	{
	}

	public void OnEnable()
	{
	}

	public void Refresh()
	{
	}

	public void Start()
	{
	}

	public void OnEnableChange(bool val)
	{
	}

	public void OnScaleXChange(string value)
	{
	}

	public void OnScaleYChange(string value)
	{
	}

	public void OnOffsetXChange(string value)
	{
	}

	public void OnOffsetYChange(string value)
	{
	}

	public void OnCliffCutoffChange(bool value)
	{
	}

	public void OnPointFilterChange(bool value)
	{
	}

	public void OnColorButtonClicked()
	{
	}

	public void OnColorChanged(Color color)
	{
	}

	public void OnOpacityChange(float value)
	{
	}

	public void OnLoadCustomImageClicked()
	{
	}

	public void OnImageLoaded(Texture2D tex)
	{
	}

	public void OnClearTextureClicked()
	{
	}

	private void SetTextureImage(Texture2D texture)
	{
	}
}
