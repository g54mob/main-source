using Unity.Entities;

public struct TryMoveDeserializedEntityToDisabledCD : IComponentData, IQueryTypeParameter
{
	public Entity targetEntity;
}
