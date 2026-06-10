using FoxyVoxel.Logging;
using NSMedieval.Goap;

namespace NSMedieval.CombatAi
{
	public abstract class CombatAiGoal : Goal
	{
		private IDamageDealAgent agent;

		internal CombatAiAgent CombatAi => (CombatAiAgent)base.Agent;

		internal IDamageDealAgent CombatAgent => agent;

		public CombatAiGoal(string id, Agent selfAgent, GoalInterruptMode interruptMode = GoalInterruptMode.Never)
			: base(id, selfAgent, interruptMode)
		{
			agent = base.AgentOwner as IDamageDealAgent;
			if (agent == null)
			{
				Log.Error("This should never happen!", "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Goal\\CombatAiGoal.cs");
			}
		}

		public override bool AgentTypeCheck()
		{
			return true;
		}

		internal Agent GetGoapAgent()
		{
			return ((IGoapAgentOwner)agent).GetGoapAgent();
		}

		internal virtual void Update()
		{
		}

		protected virtual void OnStart()
		{
		}

		protected virtual void OnEnd()
		{
		}
	}
}
