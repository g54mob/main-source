using ModIO.Implementation.Wss.Messages.Objects;
using Newtonsoft.Json.Linq;

namespace ModIO.Implementation.Wss.Messages
{
	internal static class WssRequest
	{
		public static WssMessage DeviceLogin()
		{
			return new WssMessage
			{
				operation = "device_login",
				context = JToken.FromObject(default(WssDeviceLoginRequest))
			};
		}
	}
}
