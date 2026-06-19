using System.Runtime.Serialization;

namespace Sentry
{
	public enum SentryLevel : short
	{
		[EnumMember(Value = "debug")]
		Debug = 0,
		[EnumMember(Value = "info")]
		Info = 1,
		[EnumMember(Value = "warning")]
		Warning = 2,
		[EnumMember(Value = "error")]
		Error = 3,
		[EnumMember(Value = "fatal")]
		Fatal = 4
	}
}
