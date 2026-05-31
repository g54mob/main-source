using UnityEngine;
using UnityEngine.Tilemaps;

[ExecuteInEditMode]
public class PerlinNoiseMap : MonoBehaviour
{
	[SerializeField]
	private Tilemap rend;

	[SerializeField]
	private TileBase tile;

	[Range(1f, 100f)]
	[SerializeField]
	private int probability = 25;

	[SerializeField]
	private Vector2Int mapSize = new Vector2Int(144, 8);

	[SerializeField]
	private float scale = 7f;

	[SerializeField]
	private Vector2Int offset;

	[SerializeField]
	private TileBase[] flowerTiles;

	private void OnEnable()
	{
		rend.ClearAllTiles();
		if (flowerTiles.Length != 0)
		{
			GenerateFlowerMap();
		}
		else
		{
			GenerateMap();
		}
	}

	private void GenerateMap()
	{
		for (int i = 0; i < mapSize.x; i++)
		{
			for (int j = 0; j < mapSize.y; j++)
			{
				TileBase tileUsingPerlin = GetTileUsingPerlin(i, j);
				if ((bool)tileUsingPerlin)
				{
					rend.SetTile(new Vector3Int(i, j, 0), tileUsingPerlin);
				}
			}
		}
	}

	private void GenerateFlowerMap()
	{
		for (int i = 0; i < mapSize.x; i++)
		{
			for (int j = 0; j < mapSize.y; j++)
			{
				TileBase flowerTileUsingPerlin = GetFlowerTileUsingPerlin(i, j);
				if ((bool)flowerTileUsingPerlin)
				{
					rend.SetTile(new Vector3Int(i, j, 0), flowerTileUsingPerlin);
				}
			}
		}
	}

	private TileBase GetTileUsingPerlin(int x, int y)
	{
		float num = Mathf.Clamp(Mathf.PerlinNoise((float)(x - offset.x) / scale, (float)(y - offset.y) / scale), 0f, 1f) * 100f;
		if (num == 100f)
		{
			num = 99f;
		}
		if (Mathf.FloorToInt(num) >= probability)
		{
			return null;
		}
		return tile;
	}

	private TileBase GetFlowerTileUsingPerlin(int x, int y)
	{
		float num = Mathf.Clamp(Mathf.PerlinNoise((float)(x - offset.x) / scale, (float)(y - offset.y) / scale), 0f, 1f) * 100f;
		if (num == 100f)
		{
			num = 99f;
		}
		int num2 = Mathf.FloorToInt(num % (float)flowerTiles.Length);
		return flowerTiles[num2];
	}
}
