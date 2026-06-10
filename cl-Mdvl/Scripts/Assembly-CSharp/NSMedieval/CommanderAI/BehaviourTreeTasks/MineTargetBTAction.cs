using NSMedieval.CommanderAI.Orders;
using NSMedieval.Village.Map;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Unit Orders")]
	[Description("Issue mining order on target dig position and wait until voxel is mined")]
	public class MineTargetBTAction : UnitsBTActionBase
	{
		[RequiredField]
		public BBParameter<MapNode> digNode;

		[RequiredField]
		public BBParameter<MapNode> prevNodeInPath;

		protected override string info => $"{base.info}: Dig voxel at {digNode}";

		protected override void OnStart()
		{
			if (digNode?.value?.GetNodeAbove() == null || base.Units == null || base.UnitCount == 0)
			{
				EndAction(success: false);
			}
		}

		protected override void OnTick()
		{
			if (digNode.value?.GetNodeAbove() == null || base.Units == null || base.UnitCount == 0)
			{
				EndAction(success: false);
				return;
			}
			MapNode nodeAbove = digNode.value.GetNodeAbove();
			if (digNode.value.IsVoxelAir())
			{
				EndAction(success: true);
				digNode.value = null;
				return;
			}
			bool flag = false;
			foreach (CommanderAIUnit unit in base.Units)
			{
				if (!unit.Humanoid.HasDiedOrFainted && !unit.Humanoid.HasDisposed)
				{
					flag = true;
					if (!(unit.CurrentOrder is DigVoxelOrder digVoxelOrder) || digVoxelOrder.VoxelPosition != nodeAbove.Position)
					{
						unit.CurrentOrder = new DigVoxelOrder(prevNodeInPath.value.Position, nodeAbove.Position);
					}
				}
			}
			if (!flag)
			{
				EndAction(success: false);
			}
		}

		protected override void OnStop(bool interrupted)
		{
			if (interrupted)
			{
				return;
			}
			foreach (CommanderAIUnit unit in base.Units)
			{
				unit.CurrentOrder = MoveOrder.Stop(unit);
			}
		}
	}
}
