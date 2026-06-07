using System;
using DV.PointSet;
using UnityEngine;

public class TrackChunk
{
	public bool isSleepers;

	public RailTrack track;

	public EquiPointSet pointSet;

	public int minIndex;

	public int maxIndex;

	public Vector2Int coords;

	public TrackChunkPoolObject[] poolObjects = new TrackChunkPoolObject[3];

	public TrackChunk(EquiPointSet pointSet, Vector2Int coords)
	{
		this.pointSet = pointSet ?? throw new ArgumentNullException("pointSet");
		this.coords = coords;
		minIndex = int.MaxValue;
		maxIndex = int.MinValue;
	}

	public void Include(EquiPointSet.Point point)
	{
		if (point.index < minIndex)
		{
			minIndex = point.index;
		}
		if (point.index > maxIndex)
		{
			maxIndex = point.index;
		}
	}

	public void AssignPoolObjects(TrackChunkPoolObject obj1, TrackChunkPoolObject obj2 = null, TrackChunkPoolObject obj3 = null)
	{
		poolObjects[0] = obj1;
		poolObjects[1] = obj2;
		poolObjects[2] = obj3;
	}

	public void ReleasePoolObjects()
	{
		ReleasePoolObject(0);
		ReleasePoolObject(1);
		ReleasePoolObject(2);
	}

	private void ReleasePoolObject(int index)
	{
		if (poolObjects[index] != null)
		{
			poolObjects[index].ReturnToPool();
			poolObjects[index] = null;
		}
	}
}
