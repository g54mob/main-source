using UnityEngine;

public class PixelData
{
	public int width;

	public int height;

	public Color32[] data;

	public PixelData()
	{
	}

	public PixelData(Texture texture, RectInt? rect = null)
	{
	}

	public PixelData(Texture texture, int width, int height)
	{
	}
}
