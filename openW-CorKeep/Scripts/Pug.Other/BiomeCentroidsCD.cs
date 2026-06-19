using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

public struct BiomeCentroidsCD : IComponentData, IQueryTypeParameter
{
	public NativeArray<int2> Centroids;
}
