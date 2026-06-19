using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblSocialManagerEvent
	{
		public XUserHandle User { get; }

		public XblSocialManagerEventType EventType { get; }

		public int Hr { get; }

		public XblSocialManagerUserGroupHandle LoadedGroup { get; }

		public XblSocialManagerUser[] UsersAffected { get; }

		internal XblSocialManagerEvent(XGamingRuntime.Interop.XblSocialManagerEvent interopEvent)
		{
			User = new XUserHandle(interopEvent.user);
			EventType = interopEvent.eventType;
			Hr = interopEvent.hr;
			LoadedGroup = new XblSocialManagerUserGroupHandle(interopEvent.loadedGroup);
			UsersAffected = Array.ConvertAll(interopEvent.GetUserArray(), (XGamingRuntime.Interop.XblSocialManagerUser u) => new XblSocialManagerUser(u));
		}
	}
}
