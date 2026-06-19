using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class StaffRef : CharacterRef
	{
		public StaffRef()
		{
		}

		public StaffRef(Staff staff)
			: base(staff)
		{
		}
	}
}
