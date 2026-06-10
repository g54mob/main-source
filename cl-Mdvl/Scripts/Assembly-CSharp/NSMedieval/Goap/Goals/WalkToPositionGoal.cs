using System.Collections.Generic;
using NSMedieval.Goap.Actions;
using NSMedieval.Pathfinding;

namespace NSMedieval.Goap.Goals
{
	public class WalkToPositionGoal : Goal
	{
		private Vec3Int targetPosition;

		public WalkToPositionGoal(Agent selfAgent)
			: base("WalkToPositionGoal", selfAgent)
		{
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public void SetPosition(Vec3Int pos)
		{
			targetPosition = pos;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IPathfindingAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			return true;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).TickOnInterval(0.5f, delegate
			{
				SetTarget(TargetIndex.A, new TargetObject(targetPosition));
			});
		}

		private bool PrepareData()
		{
			SetTarget(TargetIndex.A, new TargetObject(targetPosition));
			return true;
		}
	}
}
