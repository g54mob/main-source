using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct PhaseTransitionStateCD : IComponentData, IQueryTypeParameter
{
	public bool initialized;

	public float phase1HealthThreshold;

	public float phase1TransitionDuration;

	public float invulnerableDuration;

	public int currentPhase;

	[GhostField]
	public int currentSyncedPhase;

	[GhostField]
	public int internalState;

	public ThreadSafeTimerSimple timer;

	public ThreadSafeTimerSimple invulnerableTimer;

	[GhostField]
	public bool isInvulnerable;

	public int GetCurrentPhase(float healthRatio)
	{
		if (healthRatio <= phase1HealthThreshold)
		{
			return 1;
		}
		return 0;
	}
}
