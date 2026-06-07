using UnityEngine;

public static class uPaddingBleed
{
	private struct Tile
	{
		public int minX;

		public int maxX;

		public int minY;

		public int maxY;

		public int width;

		public int height;
	}

	public static void BleedEdges(Texture2D texture, int padding, Rect[] texturePositions, bool repeatingTextures)
	{
	}

	private static int OffsetPos(int pos, int offset, int max)
	{
		return 0;
	}

	private static Color[] StretchPaddingH(Color[] pixels, int padding, Tile tile)
	{
		return null;
	}

	private static Color[] StretchPaddingV(Color[] pixels, int padding, Tile tile)
	{
		return null;
	}
}
