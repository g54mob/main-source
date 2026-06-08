using Kitchen.Layouts;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[InternalBufferCapacity(256)]
	public struct CLayoutRoomTile : IBufferElementData
	{
		public Vector3 Position;

		public int RoomID;

		public RoomType Type;

		public bool HasFeature;

		public Reachability Reachability;

		public bool CanReach(Orientation o)
		{
			return o switch
			{
				Orientation.Right => Reachability[1, 0], 
				Orientation.Down => Reachability[0, -1], 
				Orientation.Left => Reachability[-1, 0], 
				Orientation.Up => Reachability[0, 1], 
				_ => false, 
			};
		}
	}
}
