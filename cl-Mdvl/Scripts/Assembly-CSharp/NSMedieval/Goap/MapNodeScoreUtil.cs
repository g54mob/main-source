using System;
using System.Collections.Generic;
using NSMedieval.Village.Map;

namespace NSMedieval.Goap
{
	public static class MapNodeScoreUtil
	{
		public static MapNode FindBestNode(this IEnumerable<MapNode> nodes, Func<MapNode, float> scorer, Predicate<MapNode> earlyOutCondition = null)
		{
			MapNode result = null;
			float num = float.MinValue;
			foreach (MapNode node in nodes)
			{
				float num2 = scorer(node);
				if (earlyOutCondition != null && earlyOutCondition(node))
				{
					return node;
				}
				if (num2 > num)
				{
					num = num2;
					result = node;
				}
			}
			return result;
		}
	}
}
