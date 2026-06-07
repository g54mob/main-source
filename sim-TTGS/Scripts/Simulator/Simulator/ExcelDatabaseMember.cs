using System;

namespace Simulator
{
	[Serializable]
	public struct ExcelDatabaseMember
	{
		public string name;

		public string displayName;

		public int priority;

		public bool readOnly;

		public bool debugOnly;

		public float width;

		public bool specialDrawer;

		public ExcelDatabaseMember(string name, ExcelDatabaseAttribute att)
		{
			this.name = name;
			displayName = name;
			priority = att.priority;
			readOnly = att.readOnly;
			debugOnly = att.debugOnly;
			width = att.width;
			specialDrawer = att.specialDrawer;
		}
	}
}
