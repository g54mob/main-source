using System;

namespace Gh.Tk
{
	[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
	public sealed class PersistenceAllowBrokenReferenceOnLoad : Attribute
	{
	}
}
