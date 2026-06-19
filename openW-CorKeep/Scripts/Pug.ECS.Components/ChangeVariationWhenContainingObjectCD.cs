using Unity.Entities;

public struct ChangeVariationWhenContainingObjectCD : IComponentData, IQueryTypeParameter
{
	public ObjectID objectID;

	public int variationToChangeTo;

	public bool alsoRemoveCollider;

	public ObjectID reinstantiateToNewObjectId;

	public LootTableID addLootFromTableToNewObject;

	public EffectID playEffectOnReinstantiate;
}
