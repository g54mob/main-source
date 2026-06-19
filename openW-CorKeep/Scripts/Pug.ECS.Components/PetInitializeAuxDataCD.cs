using Unity.Entities;

public struct PetInitializeAuxDataCD : IComponentData, IQueryTypeParameter
{
	public Entity EntityContainingPet;
}
