using Kitchen.Layouts;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[InternalBufferCapacity(16)]
	public struct CLayoutFeature : IBufferElementData
	{
		public Vector3 Tile1;

		public Vector3 Tile2;

		public FeatureType Type;
	}
}
