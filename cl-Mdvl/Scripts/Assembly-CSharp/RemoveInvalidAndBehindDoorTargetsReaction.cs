using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval;
using NSMedieval.CombatAi;
using NSMedieval.Draft;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;

public class RemoveInvalidAndBehindDoorTargetsReaction : CombatAiReaction
{
	private HumanoidInstance human;

	private WorkerBehaviour worker;

	public RemoveInvalidAndBehindDoorTargetsReaction(CombatAiAgent agent)
		: base(agent)
	{
		human = (HumanoidInstance)agent.AgentOwner;
		worker = human.WorkerBehaviour;
	}

	internal override void CombatTick()
	{
		using (ProfilerSampleJanitor.Begin("RemoveInvalidAndBehindDoorTargetsReaction::CombatTick"))
		{
			IDamageTakingAgent state = base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget);
			if (!CombatUtils.IsNullOrDisposed(state) && ShouldRemoveTarget(state))
			{
				MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(base.CombatAgent);
			}
		}
	}

	private bool ShouldRemoveTarget(IDamageTakingAgent preferredTarget)
	{
		if (preferredTarget == base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.LastAttackOrderTarget))
		{
			return false;
		}
		if (CombatAttackerPositioningManager.IsInAttackPosition(base.CombatAgent, preferredTarget))
		{
			return false;
		}
		if (CombatUtils.PathGoesThroughUnbreachedDoors(base.CombatAgent.GetNode(), preferredTarget.GetNode()))
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(63, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Reactions\\RemoveInvalidAndBehindDoorTargetsReaction.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(base.CombatAgent);
				messageBuilder.AppendLiteral(" removing target because path would go through unbreached doors");
			}
			Log.Trace(messageBuilder);
			return true;
		}
		if (worker == null)
		{
			return false;
		}
		bool flag = CombatUtils.GetAttackType(preferredTarget as IDamageDealAgent) != AttackType.Melee;
		if (flag && DateTime.UtcNow.Ticks - worker.LastDraftOrderTime < 300000000 && worker.LastDraftOrder is DraftOrderGoToLocation draftOrderGoToLocation && human.PathDriver.IsMoving && human.PathDriver.FinalDestination == draftOrderGoToLocation.TargetGridPosition)
		{
			return true;
		}
		if (!flag && DateTime.UtcNow.Ticks - worker.LastDraftOrderTime < 50000000 && worker.LastDraftOrder is DraftOrderGoToLocation draftOrderGoToLocation2 && human.PathDriver.IsMoving && human.PathDriver.FinalDestination == draftOrderGoToLocation2.TargetGridPosition)
		{
			return true;
		}
		return false;
	}
}
