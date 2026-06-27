using System;

namespace FluentAssertions.Equivalency
{
	[Flags]
	public enum MemberVisibility
	{
		None = 0,
		Internal = 1,
		Public = 2,
		ExplicitlyImplemented = 4,
		DefaultInterfaceProperties = 8
	}
}
