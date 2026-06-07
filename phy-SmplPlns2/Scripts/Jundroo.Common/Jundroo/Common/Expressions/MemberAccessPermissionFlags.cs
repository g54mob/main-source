using System;

namespace Jundroo.Common.Expressions
{
	[Flags]
	public enum MemberAccessPermissionFlags
	{
		None = 0,
		AllowAnnotated = 1,
		AllowPublic = 2,
		AllowProperties = 4,
		AllowMethods = 8,
		AllowBaseClass = 0x10,
		Default = 0xD
	}
}
