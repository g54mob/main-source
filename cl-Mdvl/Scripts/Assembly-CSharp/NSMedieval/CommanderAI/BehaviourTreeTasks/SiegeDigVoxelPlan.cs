using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding.SiegeTraversalProvider;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Siege")]
	[Description("Takes current and previous path nodes, decides if voxels need to be mined. Returns success if target is set to position we want to dig.")]
	public class SiegeDigVoxelPlan : CommanderAIBTActionBase
	{
		public BBParameter<MapNode> currentNode;

		public BBParameter<MapNode> previousNode;

		public BBParameter<MapNode> target;

		protected override void OnStart()
		{
			if (currentNode.isNoneOrNull || previousNode.isNoneOrNull)
			{
				EndAction(success: false);
				return;
			}
			MapNode value = previousNode.value;
			MapNode value2 = currentNode.value;
			Vec3Int lhs = Vec3Int.zero;
			if (SiegeTraversalProvider.IsWallMine(value, value2))
			{
				lhs = value2.Position;
			}
			if (lhs == Vec3Int.zero)
			{
				EndAction(success: false);
				return;
			}
			target.SetValue(base.Map.GetNode(lhs));
			EndAction(success: true);
		}
	}
}
