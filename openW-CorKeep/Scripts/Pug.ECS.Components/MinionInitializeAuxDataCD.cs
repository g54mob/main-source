using Unity.Entities;

public struct MinionInitializeAuxDataCD : IComponentData, IQueryTypeParameter
{
	public Entity EntityContainingPet;
}
