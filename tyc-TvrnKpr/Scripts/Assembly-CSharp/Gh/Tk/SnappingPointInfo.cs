using Unity.Mathematics;

namespace Gh.Tk
{
	public class SnappingPointInfo
	{
		public string Id { get; private set; }

		public EntityObject EntityObject { get; private set; }

		public float3 PositionOffset { get; private set; }

		public quaternion Rotation { get; private set; }

		public SnappingPointInfo(string id, EntityObject entityObject, float3 positionOffset, quaternion rotation)
		{
		}
	}
}
