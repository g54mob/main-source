using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class IfExistsAttribute : Attribute
	{
	}
}
