using System.Collections.Generic;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class FishShoal : EntityMonoBehaviour
{
	public List<GameObject> fishTypes;

	private bool isLarvaFish;

	private bool isMoldFish;

	private float m_nextBobTime;

	private void Start()
	{
		NewBobTime();
	}

	private void NewBobTime()
	{
		m_nextBobTime = Time.time + Random.Range(0.5f, 4f);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		TileInfo topTile = Manager.multiMap.GetTileLayerLookup().GetTopTile(base.WorldPosition.RoundToInt2());
		isLarvaFish = ((topTile.tileType == TileType.water && topTile.tileset == 6) ? true : false);
		isMoldFish = ((topTile.tileType == TileType.water && topTile.tileset == 9) ? true : false);
		if (isMoldFish)
		{
			SetFishTypeActive(2);
		}
		else if (isLarvaFish)
		{
			SetFishTypeActive(1);
		}
		else
		{
			SetFishTypeActive(0);
		}
		if (Time.time > m_nextBobTime)
		{
			WaterSim.AddImpulse(base.transform.position, 0.25f, 0.25f);
			NewBobTime();
		}
	}

	private void SetFishTypeActive(int activeIndex)
	{
		for (int i = 0; i < fishTypes.Count; i++)
		{
			fishTypes[i].SetActive(i == activeIndex);
		}
	}
}
