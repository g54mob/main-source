using Unity.Entities;

public struct SoulOrbCD : IComponentData, IQueryTypeParameter
{
	public SoulID givesSoul;
}
