using Unity.Entities;
using Unity.NetCode;

public struct EffectEventRpc : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public EffectEventCD Value;
}
