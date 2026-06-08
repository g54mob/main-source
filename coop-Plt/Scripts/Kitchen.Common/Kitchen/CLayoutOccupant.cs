using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[InternalBufferCapacity(64)]
	public struct CLayoutOccupant : IBufferElementData
	{
		public Vector3 Position;

		public Entity Entity;

		public OccupancyLayer Layer;
	}
}
