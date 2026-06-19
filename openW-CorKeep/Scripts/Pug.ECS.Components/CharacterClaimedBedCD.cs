using Unity.Entities;

public struct CharacterClaimedBedCD : IComponentData, IQueryTypeParameter
{
	public Entity claimedBedEntity;
}
