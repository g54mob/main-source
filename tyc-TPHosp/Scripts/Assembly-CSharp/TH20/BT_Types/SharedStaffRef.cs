using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class SharedStaffRef : SharedCharacterRef
	{
		public new Staff Get => (Staff)base.Value.Get;

		public static implicit operator SharedStaffRef(StaffRef value)
		{
			return new SharedStaffRef
			{
				Value = value
			};
		}
	}
}
