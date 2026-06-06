using System.Collections.Generic;
using External.Zalgo2462.VoronoiLib.Structures;
using PajamaLlama.Flotsam.World;
using PajamaLlama.Procedural;
using UnityEngine;

public class WorldRegionBorderSegment
{
	private IWorldRegion _region;

	private IWorldRegion _neighbor;

	public VEdge Edge { get; private set; }

	public VoronoiSite Site { get; private set; }

	public Polygon2DLine Line { get; private set; }

	public Vector2 Start => Line.Point;

	public Vector2 End { get; private set; }

	public WorldRegionTypeFlags Flags { get; private set; }

	public Rect MarginRect { get; private set; }

	public WorldRegionBorderSegment(VEdge edge, IWorldRegion region, List<VoronoiSite> sites, float margin = 0f)
	{
		Edge = edge;
		End = edge.End.ToVector2();
		Line = new Polygon2DLine(edge.Start.ToVector2(), End);
		Flags = region.TypeFlags;
		foreach (VoronoiSite site in sites)
		{
			if (site.Cell.Contains(edge))
			{
				Site = site;
				break;
			}
		}
		MarginRect = Line.ReturnMarginRect(margin);
		_region = region;
	}

	public bool SetNeighbor(IWorldRegion worldRegion)
	{
		WorldRegionBorderSegment[] border = worldRegion.Border;
		for (int i = 0; i < border.Length; i++)
		{
			if (border[i].Edge == Edge)
			{
				_neighbor = worldRegion;
				Flags |= _neighbor.TypeFlags;
				return true;
			}
		}
		return false;
	}
}
