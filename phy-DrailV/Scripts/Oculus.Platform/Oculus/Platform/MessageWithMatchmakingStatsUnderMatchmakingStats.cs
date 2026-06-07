using System;
using Oculus.Platform.Models;

namespace Oculus.Platform
{
	public class MessageWithMatchmakingStatsUnderMatchmakingStats : Message<MatchmakingStats>
	{
		public MessageWithMatchmakingStatsUnderMatchmakingStats(IntPtr c_message)
			: base(c_message)
		{
		}

		public override MatchmakingStats GetMatchmakingStats()
		{
			return base.Data;
		}

		protected override MatchmakingStats GetDataFromMessage(IntPtr c_message)
		{
			return new MatchmakingStats(CAPI.ovr_Message_GetMatchmakingStats(CAPI.ovr_Message_GetNativeMessage(c_message)));
		}
	}
}
