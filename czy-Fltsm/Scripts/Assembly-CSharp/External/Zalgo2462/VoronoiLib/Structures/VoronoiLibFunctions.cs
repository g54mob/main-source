using System.Collections.Generic;
using UnityEngine;

namespace External.Zalgo2462.VoronoiLib.Structures
{
	public static class VoronoiLibFunctions
	{
		public static bool AddBoundsEdgesToCell(List<VEdge> cell, Rect bounds)
		{
			VEdge vEdge = cell[0];
			VEdge vEdge2 = cell[cell.Count - 1];
			if (vEdge.Start == vEdge2.End)
			{
				return false;
			}
			if (vEdge.Start.X == vEdge2.End.X || vEdge.Start.Y == vEdge2.End.Y)
			{
				cell.Add(new VEdge(vEdge2.End, null, null)
				{
					End = vEdge.Start
				});
				return true;
			}
			VPoint vPoint = ((!Mathf.Approximately((float)vEdge.Start.X, bounds.xMin) && !Mathf.Approximately((float)vEdge.Start.X, bounds.xMax)) ? new VPoint(vEdge2.End.X, vEdge.Start.Y) : new VPoint(vEdge.Start.X, vEdge2.End.Y));
			cell.Add(new VEdge(vEdge2.End, null, null)
			{
				End = vPoint
			});
			cell.Add(new VEdge(vPoint, null, null)
			{
				End = vEdge.Start
			});
			return true;
		}
	}
}
