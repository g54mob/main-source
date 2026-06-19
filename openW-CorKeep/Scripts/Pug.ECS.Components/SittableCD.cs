using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;

public struct SittableCD : IComponentData, IQueryTypeParameter
{
	public float2 sitPositionOffset;

	public FourDirectionFloat2 leavePositionOffset;
}
