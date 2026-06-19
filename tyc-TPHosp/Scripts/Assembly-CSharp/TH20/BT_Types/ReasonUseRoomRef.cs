using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class ReasonUseRoomRef : ObjectRef<ReasonUseRoom>
	{
		public ReasonUseRoomRef()
		{
		}

		public ReasonUseRoomRef(ReasonUseRoom reason)
			: base(reason)
		{
		}
	}
}
