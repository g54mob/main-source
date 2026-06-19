using System.Runtime.Serialization;

namespace Sentry.Protocol
{
	public enum DeviceOrientation
	{
		[EnumMember(Value = "portrait")]
		Portrait = 0,
		[EnumMember(Value = "landscape")]
		Landscape = 1
	}
}
