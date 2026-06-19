using Unity.Entities;
using Unity.Mathematics;

public struct CritterCatchingCD : IComponentData, IQueryTypeParameter
{
	public float2 minMaxRandomDefaultCraftingTime;
}
