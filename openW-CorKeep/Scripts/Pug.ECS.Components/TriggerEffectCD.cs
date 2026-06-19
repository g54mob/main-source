using Unity.Entities;

public struct TriggerEffectCD : IComponentData, IQueryTypeParameter
{
	private byte _dummy;

	public bool IsTriggerEffectValid()
	{
		return false;
	}
}
