using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[AssumeReadOnly]
public struct SubMapRegistry : IComponentData, IQueryTypeParameter
{
	public NativeParallelHashMap<int2, Entity> IndexToEntity;
}
