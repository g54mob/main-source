using Unity.Collections;
using Unity.Entities;

public struct SpawnCustomSceneCD : IComponentData, IQueryTypeParameter
{
	public FixedString32Bytes name;

	public uint seed;
}
