using System;

namespace ModApi.Ui.Inspector
{
	[AttributeUsage(AttributeTargets.Field)]
	public class InspectorGroupAttribute : Attribute
	{
		public string GroupName { get; }

		public bool Reset { get; set; }

		public InspectorGroupAttribute(string groupName)
		{
			GroupName = groupName;
		}
	}
}
