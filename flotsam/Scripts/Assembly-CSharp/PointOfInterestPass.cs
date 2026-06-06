using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PointOfInterestPass", menuName = "Flotsam/Procedural Generation/Point of Interest Pass", order = 2)]
public class PointOfInterestPass : TileGeneratorPass
{
	public PointOfInterestProperties[] PointsOfInterest;

	public bool UseRegions;

	public override IEnumerator Run(TileGenerator generator, IRegion dataRegion = null)
	{
		ListPool<PointOfInterestProperties>.List list = ListPool<PointOfInterestProperties>.Get(PointsOfInterest);
		foreach (TileGeneratorNode item in generator.ReturnNodes(TileGenerator.PassNodeSelectors.All))
		{
			if (!item.Locked)
			{
				item.SetSpawner(new PointOfInterestSpawner(ReturnPointOfInterestProperties(generator, item, list), item.WorldPosition));
			}
		}
		list.Dispose();
		yield break;
	}

	private PointOfInterestProperties ReturnPointOfInterestProperties(TileGenerator generator, TileGeneratorNode node, List<PointOfInterestProperties> poisToDistribute)
	{
		if (UseRegions && generator.TryReturnRegionTileProperties(node, out var pointOfInterestProperties))
		{
			return pointOfInterestProperties;
		}
		if (poisToDistribute.Count == 0)
		{
			poisToDistribute.AddRange(PointsOfInterest);
		}
		int index = Random.Range(0, poisToDistribute.Count);
		pointOfInterestProperties = poisToDistribute[index];
		poisToDistribute.RemoveAt(index);
		return pointOfInterestProperties;
	}
}
