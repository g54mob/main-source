using UnityEngine;

namespace PugTilemap.Grid
{
	public static class BitmapOptimizer
	{
		public static Vector2Int[] GetSpans(bool[] bitmap, Vector2Int origin, Vector2Int dimensions, Vector2Int[] spanGrid = null)
		{
			if (spanGrid == null)
			{
				spanGrid = new Vector2Int[dimensions.y * dimensions.x];
			}
			if (dimensions == Vector2Int.zero)
			{
				return spanGrid;
			}
			int x = dimensions.x;
			int y = dimensions.y;
			for (int i = origin.y; i < y; i++)
			{
				for (int j = origin.x; j < x; j++)
				{
					int num = i * x + j;
					if (!bitmap[num] || spanGrid[num] != Vector2Int.zero)
					{
						continue;
					}
					int num2 = int.MinValue;
					int num3 = int.MinValue;
					int num4 = int.MinValue;
					int num5 = int.MaxValue;
					for (int k = 0; k < x - j; k++)
					{
						for (int l = 0; l < num5 && l < y - i; l++)
						{
							int num6 = j + k;
							int num7 = (i + l) * x + num6;
							if (!bitmap[num7] || spanGrid[num7] != Vector2Int.zero)
							{
								num5 = l;
								break;
							}
							int num8 = (k + 1) * (l + 1);
							if (num8 > num2)
							{
								num2 = num8;
								num3 = k + 1;
								num4 = l + 1;
							}
						}
					}
					for (int m = 0; m < num4; m++)
					{
						for (int n = 0; n < num3; n++)
						{
							int num9 = (i + m) * x + (j + n);
							spanGrid[num9] = new Vector2Int(-n, -m);
						}
					}
					if (spanGrid[num] != Vector2Int.zero)
					{
						Debug.LogError($"spanGrid already occupied at {j},{i}");
					}
					spanGrid[num] = new Vector2Int(num3, num4);
				}
			}
			return spanGrid;
		}
	}
}
