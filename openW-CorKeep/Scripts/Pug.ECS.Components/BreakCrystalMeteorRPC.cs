using Unity.Entities;
using Unity.NetCode;

public struct BreakCrystalMeteorRPC : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public Entity entity;

	public float introTimeDuration;
}
