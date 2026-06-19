using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class DiggingSpot : EntityMonoBehaviour
{
	[Serializable]
	public class TilesetDependentSprite
	{
		public Tileset tileset;

		public Sprite sprite;
	}

	public SpriteRenderer sr;

	public List<TilesetDependentSprite> tilesetDependentSprites;

	private int activeSpriteTileset = -1;

	public override void OnOccupied()
	{
		base.OnOccupied();
		activeSpriteTileset = -1;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		int index = 0;
		int tileset = Manager.multiMap.GetTileLayerLookup().GetTopTile(base.WorldPosition.RoundToInt2()).tileset;
		if (tileset == activeSpriteTileset)
		{
			return;
		}
		activeSpriteTileset = tileset;
		for (int i = 0; i < tilesetDependentSprites.Count; i++)
		{
			if (tilesetDependentSprites[i].tileset == (Tileset)activeSpriteTileset)
			{
				index = i;
				break;
			}
		}
		sr.sprite = tilesetDependentSprites[index].sprite;
	}
}
