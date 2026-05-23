using System;
using System.Collections.Generic;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	[AddComponentMenu("Pathfinding/Modifiers/Funnel Modifier")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/funnelmodifier.html")]
	public class FunnelModifier : MonoModifier
	{
		public enum FunnelQuality
		{
			Medium = 0,
			High = 1
		}

		public FunnelQuality quality;

		public bool splitAtEveryPortal;

		public bool accountForGridPenalties;

		public override int Order => 10;

		public override void Apply(Path p)
		{
			if (p.path == null || p.path.Count == 0 || p.vectorPath == null || p.vectorPath.Count == 0)
			{
				return;
			}
			List<Vector3> list = ListPool<Vector3>.Claim();
			List<Funnel.PathPart> list2 = Funnel.SplitIntoParts(p);
			if (list2.Count == 0)
			{
				return;
			}
			if (quality == FunnelQuality.High)
			{
				Funnel.Simplify(list2, ref p.path);
			}
			for (int i = 0; i < list2.Count; i++)
			{
				Funnel.PathPart part = list2[i];
				if (part.type == Funnel.PartType.NodeSequence)
				{
					if (p.path[part.startIndex].Graph is GridGraph { neighbours: not NumNeighbours.Six })
					{
						Func<GraphNode, uint> traversalCost = null;
						if (accountForGridPenalties)
						{
							traversalCost = p.GetTraversalCost;
						}
						Func<GraphNode, bool> filter = p.CanTraverse;
						List<Vector3> list3 = GridStringPulling.Calculate(p.path, part.startIndex, part.endIndex, part.startPoint, part.endPoint, traversalCost, filter);
						list.AddRange(list3);
						ListPool<Vector3>.Release(ref list3);
					}
					else
					{
						Funnel.FunnelPortals funnel = Funnel.ConstructFunnelPortals(p.path, part);
						List<Vector3> list4 = Funnel.Calculate(funnel, splitAtEveryPortal);
						list.AddRange(list4);
						ListPool<Vector3>.Release(ref funnel.left);
						ListPool<Vector3>.Release(ref funnel.right);
						ListPool<Vector3>.Release(ref list4);
					}
				}
				else
				{
					if (i == 0 || list2[i - 1].type == Funnel.PartType.OffMeshLink)
					{
						list.Add(part.startPoint);
					}
					if (i == list2.Count - 1 || list2[i + 1].type == Funnel.PartType.OffMeshLink)
					{
						list.Add(part.endPoint);
					}
				}
			}
			ListPool<Funnel.PathPart>.Release(ref list2);
			ListPool<Vector3>.Release(ref p.vectorPath);
			p.vectorPath = list;
		}
	}
}
