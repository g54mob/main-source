using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaletteImport : MonoBehaviour
{
	public enum PROCESS_PIXELS_METHOD
	{
		Average = 0,
		Max = 1,
		Min = 2
	}

	public Slider redSlider;

	public Slider greenSlider;

	public Slider blueSlider;

	public Toggle imagePaletteToggle;

	public Toggle bwPaletteToggle;

	public Toggle uniquePaletteToggle;

	public Toggle egaPaletteToggle;

	public Toggle alphaVoid;

	public Slider scaleSlider;

	public InputField startHeight;

	public Slider smoothSlider;

	public Toggle paletteCount16Toggle;

	public Toggle paletteCount8Toggle;

	public Toggle paletteCount4Toggle;

	public Toggle paletteCount2Toggle;

	public Text dockButtonText;

	public Transform previewImageContainer;

	public RawImage previewImage;

	public PaletteColorBoxContainer paletteColorBoxContainer;

	private Texture2D previewTexture;

	private Color32[] loadedPixels;

	private Color32[] pixels;

	private Color32[] palette;

	private Color32[] reducedColorData;

	private Color32[] BWPalette2;

	private Color32[] BWPalette4;

	private Color32[] BWPalette8;

	private Color32[] BWPalette16;

	private Color32[] EGAPalette2;

	private Color32[] EGAPalette4;

	private Color32[] EGAPalette8;

	private Color32[] EGAPalette16;

	private Color32[] UNIQUEPalette16;

	private Color32[] UNIQUEPalette8;

	private Color32[] UNIQUEPalette4;

	private Color32[] UNIQUEPalette2;

	private bool docked;

	public void Update()
	{
	}

	public Color32[] ApplyFilters(Color32[] pixels)
	{
		return null;
	}

	public void SetMapImageFromData(byte[] imageData)
	{
	}

	private byte[] ConvertImageToTerrainHeight(int[] pdata)
	{
		return null;
	}

	private byte[] SmoothTerrain(float[] valData, int smoothAmt)
	{
		return null;
	}

	public Color32[] GetPalette(Color32[] colorData)
	{
		return null;
	}

	private Color32 GetAverageColor(List<Color32> colorData)
	{
		return default(Color32);
	}

	private void SplitBucket(List<Color32> colorData, out List<Color32> leftBucket, out List<Color32> rightBucket)
	{
		leftBucket = null;
		rightBucket = null;
	}

	public Color32[] ConvertImageToPalette(Color32[] colorData, Color32[] palette)
	{
		return null;
	}

	private int[] ConvertImageToPaletteIndices(Color32[] colorData, Color32[] palette)
	{
		return null;
	}

	private int GetNearestColorIndex(Color32 c, Color32[] palette)
	{
		return 0;
	}

	public void GenerateMap()
	{
	}

	public void OnDefaultPaletteOrder()
	{
	}

	public void OnBrightPaletteOrder()
	{
	}

	public void OnPaletteTypeChanged(bool val)
	{
	}

	public void OnPaletteCountChanged(bool val)
	{
	}

	public void OnSliderChanged(float val)
	{
	}

	public void OnPopButton()
	{
	}

	private void DockPreviewImage(bool dock)
	{
	}

	private Color32[] BoxScale(Texture2D texture)
	{
		return null;
	}

	private Color GetColorFromPixelBlock(Color[] pixelBlock, PROCESS_PIXELS_METHOD processMethod, float redAmt, float greenAmt, float blueAmt)
	{
		return default(Color);
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
