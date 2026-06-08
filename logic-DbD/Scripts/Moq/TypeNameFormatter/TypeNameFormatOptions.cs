using System;

namespace TypeNameFormatter
{
	[Flags]
	internal enum TypeNameFormatOptions
	{
		Default = 0,
		Namespaces = 1,
		NoAnonymousTypes = 2,
		NoGenericParameterNames = 4,
		NoKeywords = 8,
		NoNullableQuestionMark = 0x10,
		NoTuple = 0x20
	}
}
