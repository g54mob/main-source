using UnityEngine;

public class ColorPaletteManager : MonoBehaviour
{
	public enum Palette
	{
		None = -1,
		Light = 0,
		Wall = 1
	}

	[SerializeField]
	private Color[] LampLightColors;

	[SerializeField]
	private Color[] wallColors;

	private static ColorPaletteManager instance;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
	}

	public static Color[] GetPalette(Palette palette)
	{
		return palette switch
		{
			Palette.None => null, 
			Palette.Light => GetLampLightColors(), 
			Palette.Wall => GetWallColors(), 
			_ => null, 
		};
	}

	public static Color[] GetLampLightColors()
	{
		return instance.LampLightColors;
	}

	public static Color[] GetWallColors()
	{
		return instance.wallColors;
	}
}
