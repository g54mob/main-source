using Photon.Pun;
using __Project__.Scripts.FloorPaintSystem;
using __Project__.Scripts.Interaction;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

namespace __Project__.Scripts.Multiplayer.Customization
{
	public class NetworkFloorBoxInteraction : NetworkInteraction
	{
		private FloorBoxInteraction m_FloorBoxInteraction;

		public FloorBoxInteraction FloorBoxInteraction => null;

		protected override void Initialize()
		{
		}

		public void SyncFloorBoxState_Broadcast(string userId)
		{
		}

		[PunRPC]
		public void SyncFloorBoxState_RPC(string senderUserID, int floorBoxViewId)
		{
		}

		public void ThrowBoxInstant_Broadcast()
		{
		}

		public void ThrowBox_Broadcast(FloorBox floorBox)
		{
		}

		[PunRPC]
		public void ThrowFloorBox_RPC(int viewId)
		{
		}

		public void DropBox_Broadcast(FloorBox floorBox)
		{
		}

		[PunRPC]
		public void DropBoxFloor_RPC(int viewId)
		{
		}

		public void ThrowIntoTrashBin_Broadcast()
		{
		}

		[PunRPC]
		public void ThrowFloorIntoTrashBin_RPC(string userID)
		{
		}

		public void PaintFloor_Broadcast(FloorBox floorBox, PaintableFloor targetFloor)
		{
		}

		[PunRPC]
		public void PaintFloor_RPC(int floorBoxViewID, int targetFloorID)
		{
		}
	}
}
