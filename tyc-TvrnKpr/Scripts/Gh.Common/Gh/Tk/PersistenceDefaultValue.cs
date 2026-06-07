using System;

namespace Gh.Tk
{
	[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
	public sealed class PersistenceDefaultValue : Attribute
	{
		public object Value { get; private set; }

		public PersistenceDefaultValue(object value)
		{
		}
	}
}
