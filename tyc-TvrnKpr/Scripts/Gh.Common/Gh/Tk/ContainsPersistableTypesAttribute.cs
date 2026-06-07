using System;

namespace Gh.Tk
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
	public sealed class ContainsPersistableTypesAttribute : Attribute
	{
	}
}
