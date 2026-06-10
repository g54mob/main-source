using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;

namespace NSMedieval.CombatAi
{
	public class EnemyRetreatAiActionGoal : CombatAiActionGoal
	{
		private readonly EnemyBehaviour enemy;

		private ActiveRaidInfo raidInfo;

		public EnemyRetreatAiActionGoal(Agent selfAgent)
			: base("EnemyRetreatAiActionGoal", selfAgent)
		{
			enemy = (base.AgentOwner as HumanoidInstance).EnemyBehaviour;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (base.CombatAi.GetState<bool>(CombatAiState.StuckWhileRetreating))
			{
				return false;
			}
			if (raidInfo == null && enemy.RaidId != 0)
			{
				raidInfo = ActiveRaidInfo.GetById(enemy.RaidId);
				if (raidInfo == null)
				{
					return true;
				}
			}
			ActiveRaidInfo activeRaidInfo = raidInfo;
			if (activeRaidInfo != null && activeRaidInfo.HasEnded)
			{
				return !base.CombatAi.IsStateSet(CombatAiState.Fainted);
			}
			return false;
		}

		protected override void OnStart()
		{
			base.OnStart();
			HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
			if (!base.CombatAi.IsStateSet(CombatAiState.EnemyIsRetreating))
			{
				HumanoidInstance obj = base.AgentOwner as HumanoidInstance;
				if (obj == null || !obj.IsLeaving)
				{
					if (!humanoidInstance.HasFainted)
					{
						humanoidInstance.GetGoapAgent().Abort();
					}
					humanoidInstance.IsLeaving = true;
					MonoSingleton<NPCController>.Instance.OnLeaveMapEvent(humanoidInstance);
					ForceGoapAgentGoal("EnemyWithdrawalGoal");
					MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(humanoidInstance, null);
					return;
				}
			}
			ForceGoapAgentGoal("EnemyWithdrawalGoal");
		}
	}
}
