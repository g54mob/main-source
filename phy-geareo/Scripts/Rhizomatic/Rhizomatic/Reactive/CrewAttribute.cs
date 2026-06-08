using System;

namespace Rhizomatic.Reactive
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
	public class CrewAttribute : Attribute
	{
		public Type memberType;

		public string name;

		public bool customName;

		public CrewAttribute(Type memberType)
		{
		}

		public CrewAttribute(Type memberType, string name)
		{
		}

		public string GetName(string fieldName)
		{
			return null;
		}
	}
}
