using System.Collections.Generic;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;

namespace NSMedieval.Goap.Goals
{
	public class VomitGoal : Goal
	{
		private const float VomitDuration = 4.5f;

		private const float MaxSearchDistance = 15f;

		public VomitGoal(Agent selfAgent)
			: base("VomitGoal", selfAgent)
		{
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		public override bool CanStart(bool isForced = false)
		{
			return true;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			HumanoidInstance humanoid = (HumanoidInstance)base.AgentOwner;
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).WithMovementSpeedMultiplier(0.4f);
			GoapAction goapAction = new GoapAction("VomitAction");
			goapAction.TriggerAnimation("Vomit", ActionAnimationMode.Interrupt);
			goapAction.CompleteAfterTimeExpires(4.5f);
			goapAction.OnComplete = delegate
			{
				string afterVomitEffector = humanoid.CurrentHumanType.AfterVomitEffector;
				if (!string.IsNullOrEmpty(afterVomitEffector))
				{
					humanoid.Stats.StartEffector(afterVomitEffector);
				}
			};
			yield return goapAction;
		}

		private bool PrepareData()
		{
			IPathfindingAgent obj = (IPathfindingAgent)base.AgentOwner;
			Vec3Int randomPoint = IdlePointManager.GetRandomPoint(obj, obj.GetGridPosition(), 15f);
			SetTarget(TargetIndex.A, new TargetObject(randomPoint));
			return true;
		}
	}
}
