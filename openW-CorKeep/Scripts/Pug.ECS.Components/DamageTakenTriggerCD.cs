using Unity.Entities;
using Unity.NetCode;

[GhostEnabledBit]
public struct DamageTakenTriggerCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	public bool skipRequestTookDamageState;
}
