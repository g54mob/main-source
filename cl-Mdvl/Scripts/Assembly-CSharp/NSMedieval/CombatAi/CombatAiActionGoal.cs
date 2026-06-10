using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Goap.Actions;
using NSMedieval.Goap.Goals;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public abstract class CombatAiActionGoal : CombatAiGoal
	{
		private string forcedGoapGoal;

		private bool shouldAbort;

		private HumanoidInstance humanoidInstance;

		protected CombatAiActionGoal(string id, Agent selfAgent)
			: base(id, selfAgent, GoalInterruptMode.HigherPriority)
		{
			humanoidInstance = base.AgentOwner as HumanoidInstance;
		}

		internal override void Update()
		{
			base.Update();
			shouldAbort = ShouldAbort();
			if (!shouldAbort)
			{
				ForceGoapAgentGoalTickCheck();
			}
		}

		protected override void OnStart()
		{
			base.OnStart();
			shouldAbort = false;
		}

		protected override void OnEnd()
		{
			forcedGoapGoal = string.Empty;
			base.OnEnd();
		}

		protected void ForceGoapAgentGoal(string goalName)
		{
			forcedGoapGoal = goalName;
		}

		protected virtual bool ShouldAbort()
		{
			return false;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction goapAction = GeneralActions.WaitForever();
			goapAction.OnInit = OnStart;
			goapAction.OnComplete = delegate
			{
				OnEnd();
			};
			goapAction.CompleteAtCondition(() => !CanStart() || shouldAbort);
			yield return goapAction;
		}

		private void ForceGoapAgentGoalTickCheck()
		{
			if (string.IsNullOrEmpty(forcedGoapGoal))
			{
				return;
			}
			Agent goapAgent = base.AgentOwner.GetGoapAgent();
			if (goapAgent == null)
			{
				return;
			}
			Goal currentGoal = goapAgent.GetCurrentGoal();
			if ((currentGoal != null && currentGoal.Id.Equals(forcedGoapGoal)) || currentGoal is EquipGoal || currentGoal is AutoEquipGoal)
			{
				return;
			}
			if (currentGoal is OperateTrebuchetGoal || currentGoal is DeliverAmmunitionToTrebuchetGoal)
			{
				HashSet<IDamageDealAgent> attackersForTarget = MonoSingleton<CombatTargetManager>.Instance.GetAttackersForTarget(humanoidInstance);
				if (attackersForTarget == null)
				{
					return;
				}
				bool flag = false;
				foreach (IDamageDealAgent item in attackersForTarget)
				{
					AnimatedAgentView agentView = ((CreatureBase)item).GetAgentView<AnimatedAgentView>();
					if (!(agentView == null))
					{
						bool flag2 = Vector3.Distance(humanoidInstance.GetPosition(), agentView.GetAsCreature().GetPosition()) <= 3f;
						if (CombatUtils.GetAttackType(item) == AttackType.Melee && flag2)
						{
							flag = true;
							humanoidInstance.OperatingSiegeWeapon = false;
							MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(humanoidInstance, item as IDamageTakingAgent);
							break;
						}
					}
				}
				if (!flag)
				{
					return;
				}
			}
			base.AgentOwner.GetGoapAgent().ForceNextGoal(forcedGoapGoal);
		}
	}
}
