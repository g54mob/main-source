using System;
using Oculus.Platform.Models;

namespace Oculus.Platform
{
	public class MessageWithRoomInviteNotification : Message<RoomInviteNotification>
	{
		public MessageWithRoomInviteNotification(IntPtr c_message)
			: base(c_message)
		{
		}

		public override RoomInviteNotification GetRoomInviteNotification()
		{
			return base.Data;
		}

		protected override RoomInviteNotification GetDataFromMessage(IntPtr c_message)
		{
			return new RoomInviteNotification(CAPI.ovr_Message_GetRoomInviteNotification(CAPI.ovr_Message_GetNativeMessage(c_message)));
		}
	}
}
