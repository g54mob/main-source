using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PhaserTilemapBoundingBoxesAsset : ScriptableObject
{
	[Serializable]
	public struct BoundCombine
	{
		public int bound1;

		public int bound2;

		public bool IsValid(int count)
		{
			return false;
		}
	}

	private const int NotSet = 9999;

	public Hash128 hash;

	public BoundCombine combine;

	public List<BoundsInt> allBounds;

	public static Hash128 CalculateHash(Tilemap tilemap)
	{
		return default(Hash128);
	}

	public void MakeWholeBound(PhaserTilemap from)
	{
	}

	public void Setup(PhaserTilemap from)
	{
	}

	public void CombineTiles(BoundCombine combineInstance)
	{
	}

	private int NumCombinable(List<BoundsInt> nextGroup)
	{
		return 0;
	}

	private BoundsInt CombineBoundsY(List<BoundsInt> nextGroup)
	{
		return default(BoundsInt);
	}

	private BoundsInt CombineBounds(List<BoundsInt> nextGroup)
	{
		return default(BoundsInt);
	}

	private BoundsInt Combine(BoundsInt i1, BoundsInt i2)
	{
		return default(BoundsInt);
	}
}
