using System.Collections.Generic;
using NSMedieval.CommanderAI;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding.SiegeTraversalProvider;
using NodeCanvas.Framework;

namespace CommanderAI.BTConditions
{
	public class IsPathSiegeWalkable : ConditionTask<CommanderAgentProxy>
	{
		public BBParameter<List<MapNode>> siegePath;

		protected override bool OnCheck()
		{
			if (siegePath?.value == null)
			{
				return true;
			}
			List<MapNode> value = siegePath.value;
			MapNode mapNode = null;
			foreach (MapNode item in value)
			{
				if (mapNode != null && !SiegeTraversalProvider.IsSiegeWalkable(mapNode, item))
				{
					return false;
				}
				mapNode = item;
			}
			return true;
		}
	}
}
