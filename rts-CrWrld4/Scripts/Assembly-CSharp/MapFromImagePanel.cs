using UnityEngine;
using UnityEngine.UI;

public class MapFromImagePanel : MonoBehaviour
{
	public InputField minHeight;

	public InputField maxHeight;

	public Slider redSlider;

	public Slider greenSlider;

	public Slider blueSlider;

	public Slider scaleSlider;

	public Slider offsetSlider;

	public Toggle alphaVoid;

	public InputField alpha;

	public Slider smoothSlider;

	public Toggle avgMethod;

	public Toggle maxMethod;

	public Toggle minMethod;

	public RawImage mapImage;

	private Texture2D mapTexture;

	private byte[] imageData;

	public void OnLoadImageClicked()
	{
	}

	public void OnGrayScale()
	{
	}

	public void ClosePanel()
	{
	}

	public void SetMapImageFromData()
	{
	}

	public void GenerateMap()
	{
	}

	public void LoadImageFromFile()
	{
	}

	private void LoadFileBrowserOutput(string path)
	{
	}

	private void FileBrowserWindowClosed()
	{
	}
}
