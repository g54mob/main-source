using UnityEngine;
using UnityEngine.UI;

public class PersonalizationSettings : PTSMonoBehaviour
{
	public WarningDatabase warningDatabase;

	public SystemOScypek systemmOScypek;

	public Sprite[] wallpaperList;

	public int selectedWallpaper;

	public int selectedColorPalete;

	public string hexColor;

	[SerializeField]
	public Image Wallpaper;

	[SerializeField]
	public Image BarMain;

	[SerializeField]
	public Image BarRight;

	[SerializeField]
	public Image MenuBarDown;

	[SerializeField]
	public Image MenuBar;

	[SerializeField]
	public Image NetworkBar;

	public Image[] Frame;

	public Image[] ColorFrame;

	[HideInInspector]
	public Color newColor;

	public void BackgroundCheck()
	{
	}

	public void ResetFrame()
	{
	}

	private void ResetColorPaleteFram()
	{
	}

	public void ChangeWallpaper(int wallpapers)
	{
	}

	public void ChangeColorPalette(int id, string hex)
	{
	}
}
