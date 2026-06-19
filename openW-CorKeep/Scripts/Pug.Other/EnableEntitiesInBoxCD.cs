using Pug.UnityExtensions;
using Unity.Entities;

public struct EnableEntitiesInBoxCD : IComponentData, IQueryTypeParameter
{
	public PugGeometry.AxisAlignedBoundingBox Area;
}
