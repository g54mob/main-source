using Unity.Collections;
using Unity.Entities;

public struct CustomSceneCD : IComponentData, IQueryTypeParameter
{
	public FixedString32Bytes name;
}
