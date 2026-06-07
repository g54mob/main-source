using UnityEngine;

public class PaletteController : Controller, ILogOrigin
{
	public Texture2D palette;

	public Material paletteMaterial;

	public Material paletteTextureMaterial;

	public Color[] colors;

	private Material[] materials;

	public override void Init()
	{
	}

	public Color GetColor(int colorI)
	{
		return default(Color);
	}

	public Material GetMaterial(int colorI)
	{
		return null;
	}
}
