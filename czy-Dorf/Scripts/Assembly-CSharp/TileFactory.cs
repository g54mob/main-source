using System.Collections.Generic;
using Dorfromantik;
using UnityEngine;

public class TileFactory : ScriptableObject
{
	[SerializeField]
	private ElementGroupSegmentCreator elementGroupSegmentCreator;

	[SerializeField]
	private Tile referenceTile;

	public void InitializePrebuiltTile(Tile tileToInitialize)
	{
		ElementGroupSegment[] componentsInChildren = tileToInitialize.GetComponentsInChildren<ElementGroupSegment>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].Initialize(tileToInitialize, i);
			if ((bool)componentsInChildren[i].groundTileReplacement)
			{
				tileToInitialize.SetGroundReplacement(componentsInChildren[i].groundTileReplacement);
			}
		}
		tileToInitialize.Generated = true;
		tileToInitialize.Initialize();
	}

	public Tile CreateTile(Tile baseTile, List<SegmentData002> segments)
	{
		int num = 0;
		List<int> list = new List<int> { 0, 1, 2, 3, 4, 5 };
		foreach (SegmentData002 segment in segments)
		{
			ElementGroupSegment elementGroupSegment = elementGroupSegmentCreator.CreateSegment(segment);
			elementGroupSegment.transform.SetParent(baseTile.VisualContainer, worldPositionStays: true);
			elementGroupSegment.transform.localPosition = Vector3.zero;
			elementGroupSegment.transform.localRotation = Quaternion.AngleAxis(segment.rotation * 60, Vector3.up);
			elementGroupSegment.Initialize(baseTile, num, segment.rotation);
			foreach (int edge in elementGroupSegment.Edges)
			{
				list.Remove(edge);
			}
			if ((bool)elementGroupSegment.groundTileReplacement)
			{
				baseTile.SetGroundReplacement(elementGroupSegment.groundTileReplacement);
			}
			num++;
		}
		EdgeDecorationContainer[] componentsInChildren = referenceTile.GetComponentsInChildren<EdgeDecorationContainer>(includeInactive: true);
		foreach (EdgeDecorationContainer edgeDecorationContainer in componentsInChildren)
		{
			if (list.Contains(edgeDecorationContainer.edgeIndex))
			{
				baseTile.AddDecorationData(edgeDecorationContainer.GetComponentsInChildren<DecorationElement>());
			}
		}
		baseTile.Generated = true;
		return baseTile;
	}
}
