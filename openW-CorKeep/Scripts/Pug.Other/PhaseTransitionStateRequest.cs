using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct PhaseTransitionStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._phaseTransitionGroup.HasComponent(entity))
		{
			return c._healthGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (!stateInfo.HasState(StateID.PhaseTransition))
		{
			PhaseTransitionStateCD value = c._phaseTransitionGroup[entity];
			int currentPhase = value.GetCurrentPhase(c._healthGroup[entity].Normalized);
			value.isInvulnerable = false;
			if (!value.initialized || currentPhase < value.currentPhase)
			{
				value.currentPhase = currentPhase;
				value.currentSyncedPhase = currentPhase;
			}
			value.initialized = true;
			if (value.currentPhase < currentPhase)
			{
				value.invulnerableTimer.Stop();
				value.timer.Stop();
				value.internalState = 0;
				stateInfo.EnterState(StateID.PhaseTransition);
			}
			c._phaseTransitionGroup[entity] = value;
		}
	}
}
