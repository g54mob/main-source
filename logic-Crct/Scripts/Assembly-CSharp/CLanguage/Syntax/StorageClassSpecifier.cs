using System;

namespace CLanguage.Syntax
{
	[Flags]
	public enum StorageClassSpecifier
	{
		None = 0,
		Typedef = 1,
		Extern = 2,
		Static = 4,
		Auto = 8,
		Register = 0x10
	}
}
