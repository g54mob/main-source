using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.View;

namespace NSMedieval.Goap.Goals
{
	public class ProductionTrainGoal : ProductionBaseGoal
	{
		public ProductionTrainGoal(Agent selfAgent)
			: base("ProductionTrainGoal", selfAgent, JobType.Train)
		{
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			SetCombatAnimationEnabled(enabled: false);
		}

		public override void Dispose()
		{
			base.Dispose();
			SetCombatAnimationEnabled(enabled: false);
		}

		protected override void ProduceActionOnComplete(ActionCompletionStatus status)
		{
			base.ProduceActionOnComplete(status);
			SetCombatAnimationEnabled(enabled: false);
		}

		protected override void ProduceActionOnInit()
		{
			base.ProduceActionOnInit();
			SetCombatAnimationEnabled(enabled: true);
		}

		private void SetCombatAnimationEnabled(bool enabled)
		{
			IDamageDealAgent damageDealAgent = (IDamageDealAgent)base.AgentOwner;
			if (damageDealAgent != null)
			{
				AnimatedAgentView agentView = ((CreatureBase)damageDealAgent).GetAgentView<AnimatedAgentView>();
				if (!(agentView == null))
				{
					agentView.CombatAnimationEventsEnabled = enabled;
				}
			}
		}
	}
}
