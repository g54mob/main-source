using System;
using Oculus.Platform.Models;

namespace Oculus.Platform
{
	public class MessageWithMatchmakingBrowseResult : Message<MatchmakingBrowseResult>
	{
		public MessageWithMatchmakingBrowseResult(IntPtr c_message)
			: base(c_message)
		{
		}

		public override MatchmakingEnqueueResult GetMatchmakingEnqueueResult()
		{
			return base.Data.EnqueueResult;
		}

		public override RoomList GetRoomList()
		{
			return base.Data.Rooms;
		}

		protected override MatchmakingBrowseResult GetDataFromMessage(IntPtr c_message)
		{
			return new MatchmakingBrowseResult(CAPI.ovr_Message_GetMatchmakingBrowseResult(CAPI.ovr_Message_GetNativeMessage(c_message)));
		}
	}
}
