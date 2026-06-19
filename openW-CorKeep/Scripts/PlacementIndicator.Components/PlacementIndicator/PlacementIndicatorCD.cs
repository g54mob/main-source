using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

namespace PlacementIndicator
{
	public struct PlacementIndicatorCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public float2 relativePlayerPosition;

		public BlobAssetReference<BlobCurve> joystickAxisToSpeed;
	}
}
