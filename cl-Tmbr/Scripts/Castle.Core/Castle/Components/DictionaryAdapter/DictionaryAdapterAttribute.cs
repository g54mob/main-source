using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class DictionaryAdapterAttribute : Attribute
	{
		public Type InterfaceType { get; private set; }

		public DictionaryAdapterAttribute(Type interfaceType)
		{
			InterfaceType = interfaceType;
		}
	}
}
