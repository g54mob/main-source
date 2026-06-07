using System.Threading;
using UnityEngine;

public class TextureScale
{
	public class ThreadData
	{
		public int start;

		public int end;

		public ThreadData(int s, int e)
		{
		}
	}

	private static Color[] texColors;

	private static Color[] newColors;

	private static int w;

	private static float ratioX;

	private static float ratioY;

	private static int w2;

	private static int finishCount;

	private static Mutex mutex;

	public static void Point(Texture2D tex, int newWidth, int newHeight)
	{
	}

	public static void Bilinear(Texture2D tex, int newWidth, int newHeight)
	{
	}

	private static void ThreadedScale(Texture2D tex, int newWidth, int newHeight, bool useBilinear)
	{
	}

	public static void BilinearScale(object obj)
	{
	}

	public static void PointScale(object obj)
	{
	}

	private static Color ColorLerpUnclamped(Color c1, Color c2, float value)
	{
		return default(Color);
	}
}
