using System;

namespace ModApi.Planet.Modifiers.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
	public class DataSlotAttribute : Attribute
	{
		public DataSlotType DataSlotType { get; }

		public string Name { get; set; }

		public bool Optional { get; }

		public int Order { get; set; }

		public string Tooltip { get; set; }

		public bool UserEditable { get; }

		public DataSlotAttribute(DataSlotType dataSlotType, string name, bool optional = false, bool userEditable = true)
		{
			DataSlotType = dataSlotType;
			Name = name;
			Optional = optional;
			UserEditable = userEditable;
		}
	}
}
