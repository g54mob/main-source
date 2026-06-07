using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblSocialManagerEvent
	{
		public XUserHandle User { get; private set; }

		public XblSocialManagerEventType EventType { get; private set; }

		public int Hr { get; private set; }

		public XblSocialManagerUserGroupHandle LoadedGroup { get; private set; }

		public XblSocialManagerUser[] UsersAffected { get; private set; }

		internal XblSocialManagerEvent(XGamingRuntime.Interop.XblSocialManagerEvent interopEvent)
		{
		}
	}
}
