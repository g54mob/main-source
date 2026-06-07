using System;

namespace CLanguage.Syntax
{
	[Flags]
	public enum TypeQualifiers
	{
		None = 0,
		Const = 1,
		Restrict = 2,
		Volatile = 4
	}
}
