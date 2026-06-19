using Unity.Entities;

public struct EvolveStateCD : IComponentData, IQueryTypeParameter
{
	public ObjectID toEvolveInto;

	public int foodAmountToEvolve;
}
