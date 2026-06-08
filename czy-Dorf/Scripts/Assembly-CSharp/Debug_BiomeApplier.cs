using System.Collections.Generic;
using Dorfromantik;
using UnityEngine;

public class Debug_BiomeApplier : MonoBehaviour
{
	[SerializeField]
	private Biome biome;

	[SerializeField]
	private Tile tileToUpdate;

	[SerializeField]
	private bool assignNewSeedToTile;

	[SerializeField]
	private Element elementToUpdate;

	[SerializeField]
	private bool assignNewSeedToElement;

	[SerializeField]
	private ElementGroupSegment elementGroupSegmentToUpdate;

	[SerializeField]
	private bool assignNewSeedToElementGroup;

	private void ApplyBiomeToTile(int overwriteSeed = -1)
	{
		if (!tileToUpdate)
		{
			Debug.LogError("no tile assigned");
			return;
		}
		if (!biome)
		{
			Debug.LogError("no biome assigned");
			return;
		}
		if (assignNewSeedToTile)
		{
			tileToUpdate.InitializeSeed(overwriteSeed);
			tileToUpdate.InitializeVisual();
		}
		BiomeManager.ApplyBiomeToTile(tileToUpdate, biome, null, forceApplyingBiome: true);
	}

	private void ApplyBiomeToObject()
	{
		if (!elementToUpdate)
		{
			Debug.LogWarning("no element assigned");
			return;
		}
		if (!biome)
		{
			Debug.LogError("no biome assigned");
			return;
		}
		if (assignNewSeedToElement)
		{
			elementToUpdate.Randomize();
		}
		BiomeManager.ApplyBiomeToObject(elementToUpdate, new Dictionary<Biome, float> { { biome, 1f } });
	}

	private void ApplyBiomeToInstanceable()
	{
		if (!elementGroupSegmentToUpdate)
		{
			Debug.LogWarning("no elementGroupSegment assigned");
			return;
		}
		if (!biome)
		{
			Debug.LogError("no biome assigned");
			return;
		}
		foreach (InstanceableVisual allElementDatum in elementGroupSegmentToUpdate.AllElementData)
		{
			if (assignNewSeedToElement)
			{
				allElementDatum.Randomize(Randomizer.GetRandomSeed());
			}
			BiomeManager.ApplyBiomeToObject(allElementDatum, new Dictionary<Biome, float> { { biome, 1f } });
		}
	}
}
