using NSMedieval.Goap;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public sealed class BodyguardFollowTraderAiActionGoal : CombatAiActionGoal
	{
		private readonly CreatureBase creatureAgent;

		public BodyguardFollowTraderAiActionGoal(Agent selfAgent)
			: base("BodyguardFollowTraderAiActionGoal", selfAgent)
		{
			creatureAgent = base.CombatAgent as CreatureBase;
		}

		public override bool CanStart(bool isForced = false)
		{
			HumanoidInstance humanoidInstance = base.CombatAi.GetState<HumanoidInstance>(CombatAiState.FollowTarget);
			if (humanoidInstance?.ActiveBehaviour is TraderBehaviour traderBehaviour && traderBehaviour.TraderType.IdleDoNotWalk)
			{
				return false;
			}
			if (humanoidInstance != null && humanoidInstance.IsTrader())
			{
				return Vector3.Distance(humanoidInstance.GetPosition(), base.CombatAgent.GetPosition()) > 5f;
			}
			return false;
		}

		internal override void Update()
		{
			CreatureBase creatureBase = base.CombatAi.GetState<CreatureBase>(CombatAiState.FollowTarget);
			if (creatureBase == null || creatureBase.HasFainted || creatureBase.HasDisposed)
			{
				base.CombatAi.SetState(CombatAiState.FollowTarget, null);
				base.Update();
				return;
			}
			if (creatureAgent.FollowCreature != creatureBase)
			{
				creatureAgent.SetFollowCreature(creatureBase);
			}
			base.Update();
		}

		protected override bool ShouldAbort()
		{
			if (!(base.TotalTickingTime > 4f))
			{
				return base.ShouldAbort();
			}
			return true;
		}

		protected override void OnStart()
		{
			base.OnStart();
			CreatureBase followCreature = base.CombatAi.GetState<CreatureBase>(CombatAiState.FollowTarget);
			creatureAgent.SetFollowCreature(followCreature);
			ForceGoapAgentGoal("FollowGoal");
		}
	}
}
