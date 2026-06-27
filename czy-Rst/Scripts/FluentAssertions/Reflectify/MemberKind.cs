using System;

namespace Reflectify
{
	[Flags]
	internal enum MemberKind
	{
		None = 0,
		Public = 1,
		Internal = 2,
		ExplicitlyImplemented = 4,
		DefaultInterfaceProperties = 8,
		Static = 0x10
	}
}
