using UnityEngine;

namespace Simulator
{
	public class ExcelDatabaseAttribute : PropertyAttribute
	{
		public readonly int priority;

		public bool readOnly;

		public bool debugOnly;

		public float width = 100f;

		public bool specialDrawer;

		public string overrideName;

		public ExcelDatabaseAttribute(int priority)
		{
			this.priority = priority;
		}
	}
}
