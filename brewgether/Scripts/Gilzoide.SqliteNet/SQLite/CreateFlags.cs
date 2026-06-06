using System;

namespace SQLite
{
	[Flags]
	public enum CreateFlags
	{
		None = 0,
		ImplicitPK = 1,
		ImplicitIndex = 2,
		AllImplicit = 3,
		AutoIncPK = 4,
		FullTextSearch3 = 0x100,
		FullTextSearch4 = 0x200
	}
}
