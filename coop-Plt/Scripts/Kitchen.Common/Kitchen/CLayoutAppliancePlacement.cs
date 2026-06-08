using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[InternalBufferCapacity(32)]
	public struct CLayoutAppliancePlacement : IBufferElementData
	{
		public Vector3 Position;

		public Quaternion Rotation;

		public int Appliance;
	}
}
