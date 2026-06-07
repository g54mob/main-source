using UnityEngine;

public class AtlasMaker
{
	public const int cols = 20;

	public const int pad = 76;

	public const int isize = 256;

	public const int width = 8192;

	public const int height = 8192;

	public static void MakeAtlas(string directory, string outputFile)
	{
	}

	public static void AddImage(Texture2D atlas, int xp, int yp, Color32[] data, int div = 1)
	{
	}

	private static void AddImage(Texture2D atlas, int i, Color32[] data)
	{
	}

	private static void SetDataSection(Color32[] src, Color32[] dst, int dstWidth, int x, int y, int width, int height)
	{
	}

	private static Color32[] GetDataSection(Color32[] src, int srcWidth, int x, int y, int width, int height)
	{
		return null;
	}
}
