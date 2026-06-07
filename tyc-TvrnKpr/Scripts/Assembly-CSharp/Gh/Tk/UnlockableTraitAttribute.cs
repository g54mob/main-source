using System;

namespace Gh.Tk
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	public sealed class UnlockableTraitAttribute : Attribute
	{
	}
}
