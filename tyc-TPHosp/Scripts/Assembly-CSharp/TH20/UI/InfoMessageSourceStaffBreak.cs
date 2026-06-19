using System;

namespace TH20.UI
{
	[Serializable]
	public abstract class InfoMessageSourceStaffBreak : InfoMessageSource
	{
		public StaffDefinition.Type StaffType { protected get; set; }
	}
}
