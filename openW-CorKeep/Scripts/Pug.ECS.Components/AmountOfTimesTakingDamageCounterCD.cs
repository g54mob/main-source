using Unity.Entities;

public struct AmountOfTimesTakingDamageCounterCD : IComponentData, IQueryTypeParameter
{
	public int count;
}
