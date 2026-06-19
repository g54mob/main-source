using Unity.Entities;
using Unity.Mathematics;

public struct ImmunityZoneShapeSerializedCD : IComponentData, IQueryTypeParameter
{
	public int2 Offset;

	public int ShapeType;

	public float SizeValue1;

	public float SizeValue2;
}
