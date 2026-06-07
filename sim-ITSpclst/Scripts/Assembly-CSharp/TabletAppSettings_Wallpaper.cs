using UnityEngine;
using UnityEngine.UI;

public class TabletAppSettings_Wallpaper : MonoBehaviour
{
	[Header("Components")]
	public TabletAppSettings settings;

	public RectTransform This_Settings;

	public GameObject This_Settings_View;

	[Header("Button Components")]
	public Image[] bg;

	public Sprite[] wallpaperSetter;

	[Header("Variables")]
	public int selectedWallpaper;

	[Header("Color Def")]
	public string hexColorBlue;

	public string hexColorLightGray;

	public Color newColorBlue;

	public Color newColorLightGray;

	public void SetWallpaper(int wallpaperID)
	{
	}

	public void RefreshWallpaper()
	{
	}

	public void ResetFrameWallpaper()
	{
	}

	public void OpenThisView()
	{
	}

	public void CloseThisView()
	{
	}

	public void SetPaletteCollor()
	{
	}
}
