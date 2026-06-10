using NSMedieval.CombatAi;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.State;
using NSMedieval.Village.Map;

namespace NSMedieval.Goap.Goals
{
	public abstract class FollowOrderBaseGoal<T> : Goal where T : OrderBase
	{
		protected readonly VillageMap Map;

		private readonly HumanoidInstance humanoidOwner;

		protected T CurrentOrder { get; private set; }

		protected CombatAiAgent CombatAi => (base.AgentOwner as CreatureBase)?.CombatAi;

		protected EnemyBehaviour EnemyOwner => humanoidOwner?.EnemyBehaviour;

		protected FollowOrderBaseGoal(Agent selfAgent, string id)
			: base(id, selfAgent, GoalInterruptMode.HigherPriority)
		{
			humanoidOwner = (HumanoidInstance)base.AgentOwner;
			Map = humanoidOwner.Map;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (EnemyOwner == null)
			{
				return false;
			}
			if (EnemyOwner.Humanoid.IsLeaving)
			{
				return false;
			}
			CurrentOrder = EnemyOwner.CurrentOrder as T;
			if (CurrentOrder == null)
			{
				return false;
			}
			if (!CanStartFollowingOrder())
			{
				return false;
			}
			return true;
		}

		public override bool AgentTypeCheck()
		{
			return EnemyOwner != null;
		}

		protected abstract bool CanStartFollowingOrder();
	}
}
