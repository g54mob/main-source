using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding.SiegeTraversalProvider;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Siege")]
	[Description("Sets current and previous positions of siege plan. Will return success once all siege actions are done.")]
	public class SiegeNextStepPlanBTAction : CommanderAIBTActionBase
	{
		[RequiredField]
		public BBParameter<List<MapNode>> siegePath;

		public BBParameter<MapNode> previousNode;

		public BBParameter<MapNode> currentNode;

		private List<MapNode> previousPath;

		protected override void OnStart()
		{
			if (siegePath?.value == null)
			{
				EndAction(success: false);
				return;
			}
			if (previousPath != siegePath.value)
			{
				previousPath = siegePath.value;
				currentNode.value = null;
				previousNode.value = null;
			}
			if (currentNode == null)
			{
				currentNode = new BBParameter<MapNode>();
				previousNode = new BBParameter<MapNode>();
			}
			List<MapNode> value = siegePath.value;
			MapNode mapNode = previousNode.value;
			while (value.Count > 0)
			{
				int index = value.Count - 1;
				MapNode mapNode2 = value[index];
				if (mapNode2 == mapNode)
				{
					value.RemoveAt(index);
					continue;
				}
				if (mapNode2 != null && mapNode != null)
				{
					bool flag = false;
					foreach (MapNode neighbour in mapNode2.Neighbours)
					{
						if (neighbour == mapNode)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						mapNode = null;
					}
				}
				if (mapNode != null)
				{
					if (!SiegeTraversalProvider.IsSiegeWalkable(mapNode, mapNode2))
					{
						Log.Trace($"Is not walkable {mapNode.Position} -> {mapNode2?.Position}", SiegeTraversalProvider.LogPath);
						currentNode.SetValue(mapNode2);
						previousNode.SetValue(mapNode);
						EndAction(success: true);
						return;
					}
					Log.Trace($"Is walkable {mapNode.Position} -> {mapNode2?.Position}", SiegeTraversalProvider.LogPath);
					mapNode = mapNode2;
					value.RemoveAt(index);
				}
				else
				{
					mapNode = mapNode2;
				}
			}
			FinishSiege();
		}

		private void FinishSiege()
		{
			ResetState();
			EndAction(success: false);
		}

		private void ResetState()
		{
			siegePath.value = null;
			previousNode.value = null;
			currentNode.value = null;
		}

		protected override void OnStop(bool interrupted)
		{
			base.OnStop(interrupted);
			if (interrupted)
			{
				ResetState();
			}
		}
	}
}
