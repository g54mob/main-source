using Unity.Entities;

public struct DamageEffectCD : IComponentData, IQueryTypeParameter
{
	public int trigger;
}
