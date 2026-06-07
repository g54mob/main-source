using System;
using Oculus.Platform.Models;

namespace Oculus.Platform
{
	public class MessageWithRoomUnderCurrentRoom : Message<Room>
	{
		public MessageWithRoomUnderCurrentRoom(IntPtr c_message)
			: base(c_message)
		{
		}

		public override Room GetRoom()
		{
			return base.Data;
		}

		protected override Room GetDataFromMessage(IntPtr c_message)
		{
			return new Room(CAPI.ovr_Message_GetRoom(CAPI.ovr_Message_GetNativeMessage(c_message)));
		}
	}
}
