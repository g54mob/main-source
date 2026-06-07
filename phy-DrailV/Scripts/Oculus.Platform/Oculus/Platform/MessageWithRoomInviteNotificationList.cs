using System;
using Oculus.Platform.Models;

namespace Oculus.Platform
{
	public class MessageWithRoomInviteNotificationList : Message<RoomInviteNotificationList>
	{
		public MessageWithRoomInviteNotificationList(IntPtr c_message)
			: base(c_message)
		{
		}

		public override RoomInviteNotificationList GetRoomInviteNotificationList()
		{
			return base.Data;
		}

		protected override RoomInviteNotificationList GetDataFromMessage(IntPtr c_message)
		{
			return new RoomInviteNotificationList(CAPI.ovr_Message_GetRoomInviteNotificationArray(CAPI.ovr_Message_GetNativeMessage(c_message)));
		}
	}
}
