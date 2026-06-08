using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Interface)]
	public class XmlDefaultsAttribute : Attribute
	{
		public bool Qualified { get; set; }

		public bool IsNullable { get; set; }
	}
}
