using Unity.Entities;

public struct ChangeVariationWhenTookDamageCD : IComponentData, IQueryTypeParameter
{
	public int variationToChangeTo;
}
