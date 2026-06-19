using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class DirectionalCircuit : EntityMonoBehaviour
{
	[Serializable]
	public class Sprites
	{
		public Sprite sprite;

		public Sprite emissiveSprite;
	}

	public SpriteRenderer sr;

	public SpriteRenderer emissiveSR;

	public List<Sprites> directionSprites;

	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		base.OnHide();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		int index = base.variation;
		sr.sprite = directionSprites[index].sprite;
		emissiveSR.sprite = directionSprites[index].emissiveSprite;
	}
}
