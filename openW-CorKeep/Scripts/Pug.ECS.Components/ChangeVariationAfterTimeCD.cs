using Unity.Entities;

public struct ChangeVariationAfterTimeCD : IComponentData, IQueryTypeParameter
{
	public int requiredVariation;

	public int variationToChangeTo;

	public TickTimer changeTimer;
}
