using Unity.Collections;
using Unity.Entities;

[AssumeReadOnly]
public struct BiomeRangesCD : IComponentData, IQueryTypeParameter
{
	public FixedList512Bytes<BiomeRanges> Value;
}
