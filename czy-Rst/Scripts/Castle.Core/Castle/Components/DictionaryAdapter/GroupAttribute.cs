using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
	public class GroupAttribute : Attribute
	{
		public object[] Group { get; private set; }

		public GroupAttribute(object group)
		{
			Group = new object[1] { group };
		}

		public GroupAttribute(params object[] group)
		{
			Group = group;
		}
	}
}
