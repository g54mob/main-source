using System;

namespace Rhizomatic.Reactive
{
	[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
	public sealed class CrewMethodAttribute : Attribute
	{
		public string name;

		public bool customName;

		public CrewMethodAttribute()
		{
		}

		public CrewMethodAttribute(string name)
		{
		}

		public string GetName(string fieldName)
		{
			return null;
		}
	}
}
