using System;
using Oculus.Platform.Models;

namespace Oculus.Platform
{
	public class MessageWithMatchmakingAdminSnapshot : Message<MatchmakingAdminSnapshot>
	{
		public MessageWithMatchmakingAdminSnapshot(IntPtr c_message)
			: base(c_message)
		{
		}

		public override MatchmakingAdminSnapshot GetMatchmakingAdminSnapshot()
		{
			return base.Data;
		}

		protected override MatchmakingAdminSnapshot GetDataFromMessage(IntPtr c_message)
		{
			return new MatchmakingAdminSnapshot(CAPI.ovr_Message_GetMatchmakingAdminSnapshot(CAPI.ovr_Message_GetNativeMessage(c_message)));
		}
	}
}
