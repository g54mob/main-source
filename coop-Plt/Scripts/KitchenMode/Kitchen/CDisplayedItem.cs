using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[InternalBufferCapacity(4)]
	public struct CDisplayedItem : IBufferElementData
	{
		public bool IsComplete;

		public Vector3 SeatPosition;

		public Vector3 TablePosition;

		public Entity Item;

		public int ItemID;

		public bool IsSide;

		public bool ShowExtra;

		public int ExtraID;

		public bool IsSatisfiedBySharer;
	}
}
