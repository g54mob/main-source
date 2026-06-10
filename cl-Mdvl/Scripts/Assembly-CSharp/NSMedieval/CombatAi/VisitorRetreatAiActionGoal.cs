using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.GameEventSystem;
using NSMedieval.GameEventSystem.Events;
using NSMedieval.Goap;
using NSMedieval.State;

namespace NSMedieval.CombatAi
{
	public class VisitorRetreatAiActionGoal : CombatAiActionGoal
	{
		public VisitorRetreatAiActionGoal(Agent selfAgent)
			: base("VisitorRetreatAiActionGoal", selfAgent)
		{
		}

		public override bool CanStart(bool isForced = false)
		{
			HumanoidInstance humanoidInstance = base.AgentOwner as HumanoidInstance;
			if (humanoidInstance == null)
			{
				return false;
			}
			if (humanoidInstance.IsAtEvent())
			{
				return false;
			}
			foreach (AnimalInstance pet in humanoidInstance.Pets)
			{
				if (pet.GetGoapAgent() == null)
				{
					return false;
				}
			}
			if (!base.CombatAi.IsStateSet(CombatAiState.Fainted))
			{
				if (humanoidInstance == null || !humanoidInstance.IsLeaving)
				{
					return !MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.RunningEvents.Any((GameEventInstance e) => e is IVisitorEvent visitorEvent && visitorEvent.Contains(humanoidInstance));
				}
				return true;
			}
			return false;
		}

		protected override void OnStart()
		{
			base.OnStart();
			ForceGoapAgentGoal("EnemyWithdrawalGoal");
			if (base.AgentOwner is HumanoidInstance humanoidInstance && humanoidInstance.IsEnemy() && !humanoidInstance.IsLeaving)
			{
				Log.Info("TraderRetreatAiActionGoal: Forcing merchant to leave.", "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Goal\\ActionGoal\\VisitorRetreatAiActionGoal.cs");
				humanoidInstance.RetreatFromMap();
			}
		}
	}
}
