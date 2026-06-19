using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct HealthRegenerationCD : IComponentData, IQueryTypeParameter
{
	public const float BETWEEN_HEALS_DELAY = 5f;

	public TickTimer RegenDelayTimer;

	public float NormalizedHealthIncreasePerFiveSeconds;

	public float HealDelayAfterLeavingCombat;
}
