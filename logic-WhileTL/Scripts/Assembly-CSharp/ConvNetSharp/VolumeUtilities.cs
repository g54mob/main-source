using System;

namespace ConvNetSharp
{
	public static class VolumeUtilities
	{
		private static readonly Random Random = new Random(RandomUtilities.Seed);

		public static Volume Augment(this Volume volume, int crop, int dx = -1, int dy = -1, bool flipLeftRight = false)
		{
			if (dx == -1)
			{
				dx = Random.Next(volume.Width - crop);
			}
			if (dy == -1)
			{
				dy = Random.Next(volume.Height - crop);
			}
			Volume volume2;
			if (crop != volume.Width || dx != 0 || dy != 0)
			{
				volume2 = new Volume(crop, crop, volume.Depth, 0.0);
				for (int i = 0; i < crop; i++)
				{
					for (int j = 0; j < crop; j++)
					{
						if (i + dx >= 0 && i + dx < volume.Width && j + dy >= 0 && j + dy < volume.Width)
						{
							for (int k = 0; k < volume.Depth; k++)
							{
								volume2.Set(i, j, k, volume.Get(i + dx, j + dy, k));
							}
						}
					}
				}
			}
			else
			{
				volume2 = volume;
			}
			if (flipLeftRight)
			{
				Volume volume3 = volume2.CloneAndZero();
				for (int l = 0; l < volume2.Width; l++)
				{
					for (int m = 0; m < volume2.Height; m++)
					{
						for (int n = 0; n < volume2.Depth; n++)
						{
							volume3.Set(l, m, n, volume2.Get(volume2.Width - l - 1, m, n));
						}
					}
				}
				volume2 = volume3;
			}
			return volume2;
		}
	}
}
