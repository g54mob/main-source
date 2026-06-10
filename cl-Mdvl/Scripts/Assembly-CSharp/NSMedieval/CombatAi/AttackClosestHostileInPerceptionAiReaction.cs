using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;

namespace NSMedieval.CombatAi
{
	public class AttackClosestHostileInPerceptionAiReaction : CombatAiReaction
	{
		public AttackClosestHostileInPerceptionAiReaction(CombatAiAgent agent)
			: base(agent)
		{
		}

		internal override void Refresh()
		{
			base.Refresh();
			if (base.CombatAi.IsStateSet(CombatAiState.PreferedTarget) || base.CombatAi.IsStateSet(CombatAiState.NextTarget) || base.CombatAgent.HasActivePath)
			{
				return;
			}
			HashSet<IDamageDealAgent> state = base.CombatAi.GetState<HashSet<IDamageDealAgent>>(CombatAiState.PerceptionHostiles);
			if (state == null || state.Count == 0)
			{
				return;
			}
			IDamageTakingAgent damageTakingAgent = null;
			float num = float.MaxValue;
			foreach (IDamageDealAgent item in state)
			{
				if (item?.CombatAi != null && !item.CombatAi.IsStateSet(CombatAiState.Fainted) && item.CombatAi.IsStateSet(CombatAiState.IsAggressive) && item is IDamageTakingAgent damageTakingAgent2 && CombatUtils.IsAttackPossible(base.CombatAgent, damageTakingAgent2) && CombatUtils.CanBeTargeted(damageTakingAgent2))
				{
					float num2 = base.CombatAgent.GetGridPosition().DistanceSquared(damageTakingAgent2.GetGridPosition());
					if (num2 < num)
					{
						num = num2;
						damageTakingAgent = damageTakingAgent2;
					}
				}
			}
			if (damageTakingAgent != null)
			{
				base.CombatAi.SetState(CombatAiState.NextTarget, damageTakingAgent);
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(19, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Reactions\\AttackClosestHostileInPerceptionAiReaction.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("SetNextTarget ");
					messageBuilder.AppendFormatted(damageTakingAgent);
					messageBuilder.AppendLiteral(" for ");
					messageBuilder.AppendFormatted(base.CombatAgent);
				}
				Log.Trace(messageBuilder);
				if (base.CombatAgent is HumanoidInstance humanoidInstance && humanoidInstance.ActiveBehaviour is WorkerBehaviour)
				{
					base.CombatAi.SetState(CombatAiState.IsDraftAutoTargetSet, true);
				}
			}
		}
	}
}
