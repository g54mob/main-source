using UnityEngine;

public class SpawnGrid
{
	private int _tileCount;

	private float _worldToIndexMultiplier;

	private int[] _queryIndices;

	private int _queryCount;

	public int Width { get; private set; }

	public int Height { get; private set; }

	public SpawnGridTile[,] Grid { get; private set; }

	public SpawnGrid(int width, int height, float reachableRadius)
	{
		Width = width;
		Height = height;
		Grid = new SpawnGridTile[width, height];
		_tileCount = Width * height;
		_queryIndices = new int[_tileCount];
		float num = reachableRadius * 2f / (float)width;
		float num2 = reachableRadius * 2f / (float)height;
		_worldToIndexMultiplier = ((num < num2) ? (1f / num2) : (1f / num));
		Vector2 vector = new Vector2(0f - reachableRadius, 0f - reachableRadius);
		vector.x += num / 2f;
		vector.y += num2 / 2f;
		int num3 = width - 1;
		int num4 = height - 1;
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				SpawnGridTile spawnGridTile = new SpawnGridTile(vector.x + num * (float)j, vector.y + num2 * (float)i, num, num2);
				if (j == 0 || i == 0 || j == num3 || i == num4)
				{
					spawnGridTile.ClearanceIndex = 0;
				}
				Grid[j, i] = spawnGridTile;
			}
		}
	}

	public void Reset(bool initialze = false)
	{
		int num = Width - 1;
		int num2 = Height - 1;
		for (int i = 0; i < Height; i++)
		{
			for (int j = 0; j < Width; j++)
			{
				SpawnGridTile spawnGridTile = Grid[j, i];
				spawnGridTile.Reset();
				if (j == 0 || i == 0 || j == num || i == num2)
				{
					spawnGridTile.ClearanceIndex = 0;
				}
			}
		}
	}

	public void BlockSphereInterior(Vector2 center, float radius)
	{
		for (int i = 0; i < Height; i++)
		{
			for (int j = 0; j < Width; j++)
			{
				Grid[j, i].SetBlockedWhenOverlappingSphere(center, radius);
			}
		}
		UpdateClearance();
	}

	public void BlockSphereExterior(Vector2 center, float radius)
	{
		for (int i = 0; i < Height; i++)
		{
			for (int j = 0; j < Width; j++)
			{
				Grid[j, i].SetBlockedWhenContainedBySphere(center, radius, invert: true);
			}
		}
		UpdateClearance();
	}

	public void UpdateClearance()
	{
		int num = Width - 1;
		int num2 = Height - 1;
		for (int i = 1; i < num; i++)
		{
			for (int j = 1; j < num2; j++)
			{
				SetTileClearanceIndex(Grid[j, i], j, i);
			}
		}
		int num3 = num2 - 1;
		while (0 < num3)
		{
			int num4 = num - 1;
			while (0 < num4)
			{
				SetTileClearanceIndex(Grid[num4, num3], num4, num3);
				num4--;
			}
			num3--;
		}
	}

	private void SetTileClearanceIndex(SpawnGridTile tile, int indexX, int indexY)
	{
		if (tile.IsBlocked)
		{
			tile.ClearanceIndex = 0;
			return;
		}
		int num = indexX + 2;
		int num2 = indexY + 2;
		int num3 = int.MaxValue;
		for (int i = indexY - 1; i < num2; i++)
		{
			for (int j = indexX - 1; j < num; j++)
			{
				if (j != indexX || i != indexY)
				{
					SpawnGridTile spawnGridTile = Grid[j, i];
					if (spawnGridTile.ClearanceIndex < num3)
					{
						num3 = spawnGridTile.ClearanceIndex;
					}
				}
			}
		}
		tile.ClearanceIndex = ((num3 != int.MaxValue) ? (num3 + 1) : 0);
	}

	public Vector2 ReturnRandomSpawnPosition(float requiredClearance)
	{
		int maxExclusive = ReturnAvailableIndexCount(Mathf.CeilToInt(requiredClearance * _worldToIndexMultiplier));
		int num = _queryIndices[Random.Range(0, maxExclusive)];
		int num2 = num % Width;
		int num3 = num / Height;
		Vector2 center = Grid[num2, num3].Center;
		BlockSphereInterior(center, requiredClearance);
		return center;
	}

	private int ReturnAvailableIndexCount(int requiredClearance)
	{
		_queryCount = 0;
		for (int i = 0; i < Height; i++)
		{
			for (int j = 0; j < Width; j++)
			{
				if (requiredClearance < Grid[j, i].ClearanceIndex)
				{
					_queryIndices[_queryCount++] = i * Width + j;
				}
			}
		}
		return _queryCount;
	}
}
