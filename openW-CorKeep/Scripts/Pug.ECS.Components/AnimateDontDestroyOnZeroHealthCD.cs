using Unity.Entities;

public struct AnimateDontDestroyOnZeroHealthCD : IComponentData, IQueryTypeParameter
{
	public bool hadZeroHealth;
}
