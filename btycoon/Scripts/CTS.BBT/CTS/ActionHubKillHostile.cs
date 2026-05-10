using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;

namespace CTS
{
	public class ActionHubKillHostile : AgentHubAction
	{
		public PooledRef<Customer> Target { get; set; }

		public ActionHubKillHostile(Customer target)
		{
			Target = new PooledRef<Customer>(target);
			AddScoredAction(new AgentActionReaperDash
			{
				Target = target
			}, CalculateKillScore);
		}

		private int CalculateKillScore(Agent agent)
		{
			if (!Target.TryGetValue(out var outValue))
			{
				return -1;
			}
			if (!IsTargetValid(outValue))
			{
				return -1;
			}
			if (outValue.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				return 100;
			}
			if (outValue.RoomObject.CurrentRoom.NavArea != MonoSingleton<WorkerSpawner>.Instance.WorkerArea)
			{
				return -1;
			}
			return 100;
		}

		public static bool IsTargetValid(Customer target)
		{
			if (!target.Tags.HasTag(EAgentTag.IsInside))
			{
				return false;
			}
			if (!target.ContextualFSM.CurrentStateEquals<ContextualStateNormal, ContextualStatePanicking>())
			{
				return false;
			}
			if ((object)target.ControllingVampire != null)
			{
				return false;
			}
			return true;
		}

		protected override bool ShouldBeConsideredCompleted(Agent agent)
		{
			if (!Target.TryGetValue(out var outValue))
			{
				return true;
			}
			return outValue.IsDead;
		}
	}
}
