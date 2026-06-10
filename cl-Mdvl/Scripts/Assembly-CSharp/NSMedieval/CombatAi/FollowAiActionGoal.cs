using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public sealed class FollowAiActionGoal : CombatAiActionGoal
	{
		private readonly CreatureBase creatureAgent;

		private bool isMelee;

		public FollowAiActionGoal(Agent selfAgent)
			: base("FollowAiActionGoal", selfAgent)
		{
			creatureAgent = base.CombatAgent as CreatureBase;
		}

		public override bool CanStart(bool isForced = false)
		{
			CreatureBase creatureBase = base.CombatAi.GetState<CreatureBase>(CombatAiState.FollowTarget);
			isMelee = CombatUtils.GetAttackType(base.CombatAgent) == AttackType.Melee;
			if (creatureAgent != null && creatureBase != null)
			{
				return Vector3.Distance(creatureBase.GetPosition(), base.CombatAgent.GetPosition()) > 5f;
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
			if (isMelee && base.TotalTickingTime > 4f)
			{
				return true;
			}
			return base.ShouldAbort();
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
