using UnityEngine;

namespace TH20
{
	public class RoomItemLookAtPOISourceComponent : LookAtPOISourceComponent
	{
		private RoomItem _roomItem;

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_roomItem = GetOwner<RoomItem>();
		}

		public override Vector3 LookAtPosition()
		{
			return _roomItem.WorldPosition;
		}

		public override Room GetRoomIn()
		{
			return _roomItem.OwningRoom;
		}
	}
}
