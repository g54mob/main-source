using UnityEngine;

namespace Kitchen
{
	public class SnapshotTexture
	{
		public Texture2D Snapshot;

		public float XScale;

		public float YScale;

		public Color[] Pixels;

		public SnapshotTexture(Texture2D texture, float xscale, float yscale)
		{
			Snapshot = texture;
			XScale = xscale;
			YScale = yscale;
			Pixels = texture.GetPixels();
		}

		public (int, int) GetCoord(float x, float y)
		{
			return ((int)((0.5f + x / XScale / 2f) * (float)Snapshot.width), (int)((0.5f + y / YScale / 2f) * (float)Snapshot.height));
		}

		public Color Get(float x, float y)
		{
			var (num, num2) = GetCoord(x, y);
			if (num < 0 || num >= Snapshot.width || num2 < 0 || num2 >= Snapshot.height)
			{
				return Color.black;
			}
			return Pixels[num + Snapshot.width * num2];
		}

		public float Test(float x, float y)
		{
			var (num, num2) = GetCoord(x, y);
			if (num < 0 || num >= Snapshot.width || num2 < 0 || num2 >= Snapshot.height)
			{
				return 0f;
			}
			return Pixels[num + Snapshot.width * num2].r;
		}
	}
}
