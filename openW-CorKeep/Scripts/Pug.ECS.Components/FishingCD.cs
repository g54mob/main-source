using Unity.Entities;
using Unity.Mathematics;

public struct FishingCD : IComponentData, IQueryTypeParameter
{
	public float2 minMaxRandomDefaultCraftingTime;
}
