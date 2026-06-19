using System;
using System.Collections;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

[Serializable]
public class PugMapData
{
	public class TileIterator : IEnumerator<int>, IEnumerator, IDisposable
	{
		private PugMapData mapData;

		private int currentLayer;

		private int currentChunk;

		private int currentCell = -1;

		public int Current => currentCell;

		object IEnumerator.Current => currentCell;

		public Vector3Int CurrentPosition => mapData.bounds.PositionFromCellIndex(Current);

		public PugmapTileData CurrentTileData => mapData.layers[currentLayer].tileData;

		public TileIterator(PugMapData mapData)
		{
			this.mapData = mapData;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			currentCell++;
			return CarryOver();
		}

		public bool CarryOver()
		{
			if (currentLayer >= mapData.layers.Count)
			{
				return false;
			}
			if (currentChunk >= mapData.layers[currentLayer].tileDataChunks.Count)
			{
				currentLayer++;
				currentChunk = 0;
				currentCell = 0;
				return CarryOver();
			}
			if (currentCell >= mapData.layers[currentLayer].tileDataChunks[currentChunk].e)
			{
				currentChunk++;
				currentCell = 0;
				return CarryOver();
			}
			if (currentCell < mapData.layers[currentLayer].tileDataChunks[currentChunk].s)
			{
				currentCell = mapData.layers[currentLayer].tileDataChunks[currentChunk].s;
				return CarryOver();
			}
			return true;
		}

		public void Reset()
		{
			currentCell = -1;
			currentChunk = 0;
			currentLayer = 0;
		}
	}

	public int seed;

	public BoundsInt bounds;

	public List<Vector3> objectPositions = new List<Vector3>();

	public List<PugMapObjectData> objects = new List<PugMapObjectData>();

	public List<PugMapLayerData> layers = new List<PugMapLayerData>();

	public PugMapData()
	{
	}

	public PugMapData(BoundsInt bounds)
	{
		this.bounds = bounds;
	}

	public PugMapData(PugMapData other)
	{
		seed = other.seed;
		bounds = other.bounds;
		objectPositions = new List<Vector3>(other.objectPositions);
		objects = new List<PugMapObjectData>(other.objects);
		layers = new List<PugMapLayerData>(other.layers);
	}

	public TileIterator GetTileIterator()
	{
		return new TileIterator(this);
	}
}
