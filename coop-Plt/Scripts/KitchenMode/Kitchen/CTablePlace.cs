using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[InternalBufferCapacity(8)]
	public struct CTablePlace : IBufferElementData
	{
		public CPosition SeatPosition;

		public Vector3 TablePosition;

		public Entity Chair;

		public static implicit operator CPosition(CTablePlace x)
		{
			return x.SeatPosition;
		}

		public static implicit operator CTablePlace(CPosition x)
		{
			return new CTablePlace
			{
				SeatPosition = x
			};
		}
	}
}
