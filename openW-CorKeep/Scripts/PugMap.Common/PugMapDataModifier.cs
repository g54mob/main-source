using System;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

[Serializable]
public class PugMapDataModifier
{
	[SerializeField]
	private PugMapData map;

	public PugMapDataModifier(PugMapData pugMapData)
	{
		map = pugMapData;
	}

	public PugMapData GetMapData()
	{
		return map;
	}

	public void SetNewBounds(BoundsInt bounds)
	{
		PugMapData other = map;
		map = new PugMapData(bounds);
		Copy(other);
	}

	public void Set(Vector3Int position, int tileset, TileType tileType, bool value = true)
	{
		if (!map.bounds.Contains(position))
		{
			if (!value)
			{
				return;
			}
			SetNewBounds(map.bounds.Fit(position));
		}
		int i;
		for (i = 0; i < map.layers.Count; i++)
		{
			PugMapLayerData pugMapLayerData = map.layers[i];
			if (pugMapLayerData.tileData.tilesetType == (ushort)tileset && pugMapLayerData.tileData.tileType == tileType)
			{
				break;
			}
		}
		if (i == map.layers.Count)
		{
			PugMapLayerData pugMapLayerData2 = new PugMapLayerData();
			pugMapLayerData2.tileData.tilesetType = (ushort)tileset;
			pugMapLayerData2.tileData.tileType = tileType;
			map.layers.Add(pugMapLayerData2);
		}
		int num = map.bounds.CellIndex(position);
		if (value)
		{
			int j;
			for (j = 0; j < map.layers[i].tileDataChunks.Count; j++)
			{
				PugMapLayerData.TileLayerChunk tileLayerChunk = map.layers[i].tileDataChunks[j];
				if (tileLayerChunk.e >= num)
				{
					if (tileLayerChunk.e == num)
					{
						tileLayerChunk.e++;
					}
					else if (tileLayerChunk.s == num + 1)
					{
						tileLayerChunk.s--;
					}
					else if (tileLayerChunk.s > num || tileLayerChunk.e <= num)
					{
						map.layers[i].tileDataChunks.Insert(j, new PugMapLayerData.TileLayerChunk(num, num + 1));
					}
					break;
				}
			}
			if (j == map.layers[i].tileDataChunks.Count)
			{
				map.layers[i].tileDataChunks.Add(new PugMapLayerData.TileLayerChunk(num, num + 1));
			}
			MergeAnyOverlappingChunks(tileset, tileType);
			return;
		}
		for (int num2 = map.layers[i].tileDataChunks.Count - 1; num2 >= 0; num2--)
		{
			PugMapLayerData.TileLayerChunk tileLayerChunk2 = map.layers[i].tileDataChunks[num2];
			if (tileLayerChunk2.s <= num)
			{
				if (tileLayerChunk2.s <= num && tileLayerChunk2.e > num)
				{
					int e = tileLayerChunk2.e;
					int s = tileLayerChunk2.s;
					if (tileLayerChunk2.e - tileLayerChunk2.s <= 1)
					{
						map.layers[i].tileDataChunks.RemoveAt(num2);
						break;
					}
					if (num == e - 1)
					{
						tileLayerChunk2.e = num;
						break;
					}
					if (num == s)
					{
						tileLayerChunk2.s = num + 1;
						break;
					}
					map.layers[i].tileDataChunks[num2].e = num;
					map.layers[i].tileDataChunks.Insert(num2 + 1, new PugMapLayerData.TileLayerChunk(num + 1, e));
					break;
				}
				if (num < tileLayerChunk2.s)
				{
					break;
				}
			}
		}
	}

	public void MergeAnyOverlappingChunks(int tileset, TileType tileType)
	{
		int i;
		for (i = 0; i < map.layers.Count; i++)
		{
			PugMapLayerData pugMapLayerData = map.layers[i];
			if (pugMapLayerData.tileData.tilesetType == (ushort)tileset && pugMapLayerData.tileData.tileType == tileType)
			{
				break;
			}
		}
		if (i == map.layers.Count)
		{
			return;
		}
		for (int num = map.layers[i].tileDataChunks.Count - 1; num >= 1; num--)
		{
			PugMapLayerData.TileLayerChunk tileLayerChunk = map.layers[i].tileDataChunks[num];
			int index = num - 1;
			PugMapLayerData.TileLayerChunk tileLayerChunk2 = map.layers[i].tileDataChunks[index];
			if (tileLayerChunk.s <= tileLayerChunk2.e)
			{
				tileLayerChunk2.e = tileLayerChunk.e;
				map.layers[i].tileDataChunks.RemoveAt(num);
			}
		}
	}

	public void AddObject(Vector3 position, int tileset, int objectType, int variant)
	{
		map.objectPositions.Add(position);
		map.objects.Add(new PugMapObjectData
		{
			t = (ushort)tileset,
			o = (ushort)objectType,
			v = (byte)variant
		});
	}

	public void Copy(PugMapData other)
	{
		foreach (PugMapLayerData layer in other.layers)
		{
			foreach (PugMapLayerData.TileLayerChunk tileDataChunk in layer.tileDataChunks)
			{
				for (int i = tileDataChunk.s; i < tileDataChunk.e; i++)
				{
					Vector3Int position = other.bounds.PositionFromCellIndex(i);
					Set(position, layer.tileData.tilesetType, layer.tileData.tileType);
				}
			}
		}
	}
}
