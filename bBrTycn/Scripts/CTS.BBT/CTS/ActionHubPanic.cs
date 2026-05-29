using CTS.BBT.AI;

namespace CTS
{
	public class ActionHubPanic : AgentHubAction
	{
		public ActionHubPanic(float randomMoveRadius = 10f, int? randomMoveAreaMask = null)
		{
			AddScoredAction(new AgentActionRandomMove(randomMoveRadius, randomMoveAreaMask), CalculateRandomMoveScore);
			AddScoredAction(new AgentActionSitUp(), CalculateSitUpScore);
			AddScoredAction(new AgentActionLeave(), CalculateLeaveScore);
		}

		protected override bool ShouldBeConsideredCompleted(Agent agent)
		{
			return !agent.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>();
		}

		private int CalculateSitUpScore(Agent agent)
		{
			if ((bool)agent.FurnitureAssignment.CurrentSeat)
			{
				return 100;
			}
			return -1;
		}

		private int CalculateLeaveScore(Agent agent)
		{
			if (agent.Cooldowns.IsOnCooldown(BBTAgentTags.StartedPanicking))
			{
				return -1;
			}
			return 50;
		}

		private int CalculateRandomMoveScore(Agent agent)
		{
			if (agent.Cooldowns.IsOnCooldown(BBTAgentTags.RandomMove))
			{
				return -1;
			}
			return 25;
		}
	}
}
