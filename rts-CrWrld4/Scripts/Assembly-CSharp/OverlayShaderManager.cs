using UnityEngine;
using UnityEngine.UI;

public class OverlayShaderManager : MonoBehaviour
{
	private long MAX_FILE_SIZE;

	public EditOverlay editOverlay;

	private Material overlayMaterial;

	public int materialNumber;

	public Toggle enableToggle;

	public InputField tileX;

	public InputField tileY;

	public InputField offsetX;

	public InputField offsetY;

	public Toggle cliffCutoff;

	public Image colorButtonImage;

	public RawImage textureImage;

	public Button clearTextureButton;

	public InspectorChoice stockImageChoice;

	public Dropdown filterChoice;

	public void Awake()
	{
	}

	public void OnEnable()
	{
	}

	public void Start()
	{
	}

	public Material GetOverlayMaterial()
	{
		return null;
	}

	public void OnEnableChange(bool val)
	{
	}

	public void OnTileXChange(string value)
	{
	}

	public void OnTileYChange(string value)
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

	public void OnColorChanged(Color color)
	{
	}

	public void OnLoadCustomImageClicked()
	{
	}

	public void OnFilterChanged(int val)
	{
	}

	public void OnLoadStockImageClicked()
	{
	}

	public void OnClearTextureClicked()
	{
	}

	private void UpdateTextureImage()
	{
	}

	private void SetTextureImage(Texture texture)
	{
	}

	public void LoadPNGFromFile()
	{
	}

	private void LoadFileBrowserOutput(string path)
	{
	}

	private void FileBrowserWindowClosed()
	{
	}
}
