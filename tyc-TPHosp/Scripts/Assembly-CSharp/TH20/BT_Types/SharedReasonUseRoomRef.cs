using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class SharedReasonUseRoomRef : SharedObjectRef<ReasonUseRoomRef, ReasonUseRoom>
	{
		public static implicit operator SharedReasonUseRoomRef(ReasonUseRoomRef value)
		{
			return new SharedReasonUseRoomRef
			{
				Value = value
			};
		}
	}
}
