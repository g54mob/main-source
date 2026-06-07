using System;

namespace Gh.Tk
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public sealed class PersistenceIgnoreParentAttribute : Attribute
	{
	}
}
