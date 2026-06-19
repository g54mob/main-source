using System.Collections.Generic;
using PugTilemap;
using UnityEngine;

public class RootPlantAuthoring : MonoBehaviour
{
	public Tileset tileset;

	public float minTimeBetweenSpread;

	public float maxTimeBetweenSpread;

	public List<Tileset> canGrowOnTilesets;

	private void OnValidate()
	{
		if (canGrowOnTilesets.Count > 7)
		{
			Debug.LogError("can't fit this many tilesets currently");
			canGrowOnTilesets.RemoveRange(7, canGrowOnTilesets.Count - 7);
		}
	}
}
