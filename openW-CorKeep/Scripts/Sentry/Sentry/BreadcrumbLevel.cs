using System.Runtime.Serialization;

namespace Sentry
{
	public enum BreadcrumbLevel
	{
		[EnumMember(Value = "debug")]
		Debug = -1,
		[EnumMember(Value = "info")]
		Info = 0,
		[EnumMember(Value = "warning")]
		Warning = 1,
		[EnumMember(Value = "error")]
		Error = 2,
		[EnumMember(Value = "critical")]
		Critical = 3
	}
}
