using NSMedieval.Goap;
using NSMedieval.State;
using UnityEngine;

namespace GOAP.Action
{
	public static class CreatureExtensions
	{
		private const float StopAnimalMovementAtDistance = 2f;

		public static GoapAction StopAnimalTickerWhenInRange(this GoapAction action, TargetIndex target, float range = 2f)
		{
			action.OnTick = delegate
			{
				AnimalInstance objectAs = action.Goal.GetTarget(target).GetObjectAs<AnimalInstance>();
				if (objectAs == null)
				{
					action.Complete(ActionCompletionStatus.Fail);
				}
				else if (!(Vector3.Distance(((IGoapTargetable)action.AgentOwner).GetPosition(), objectAs.GetPosition()) > 2f))
				{
					objectAs.GetGoapAgent()?.StopTicker();
					objectAs.PathDriver.Abort();
				}
			};
			return action;
		}

		public static GoapAction AllowPathDriverFloating(this GoapAction action)
		{
			return new GoapAction("Allow Floating")
			{
				OnInit = delegate
				{
					IPathfindingAgent pathfindingAgent = action.AgentOwner as IPathfindingAgent;
					if (pathfindingAgent?.PathDriver != null)
					{
						pathfindingAgent.PathDriver.IsFloatingAllowed = true;
					}
				}
			};
		}

		public static GoapAction RestoreAnimalTickerOnFail(this GoapAction action, TargetIndex target)
		{
			action.OnComplete = delegate(ActionCompletionStatus status)
			{
				AnimalInstance objectAs = action.Goal.GetTarget(target).GetObjectAs<AnimalInstance>();
				if (objectAs != null)
				{
					if (status != ActionCompletionStatus.Success)
					{
						objectAs.GetGoapAgent()?.StartTicker();
					}
					else
					{
						objectAs.GetGoapAgent()?.StopTicker();
						objectAs.PathDriver.Abort();
					}
				}
			};
			return action;
		}
	}
}
