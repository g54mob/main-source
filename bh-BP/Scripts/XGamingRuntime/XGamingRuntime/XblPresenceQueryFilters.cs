namespace XGamingRuntime
{
	public class XblPresenceQueryFilters
	{
		public XblPresenceDeviceType[] DeviceTypes { get; private set; }

		public uint[] TitleIds { get; private set; }

		public XblPresenceDetailLevel DetailLevel { get; private set; }

		public bool OnlineOnly { get; private set; }

		public bool BroadcastingOnly { get; private set; }

		private XblPresenceQueryFilters(XblPresenceDeviceType[] deviceTypes, uint[] titleIds, XblPresenceDetailLevel detailLevel, bool onlineOnly, bool broadcastingOnly)
		{
		}

		public static int Create(XblPresenceDeviceType[] deviceTypes, uint[] titleIds, XblPresenceDetailLevel detailLevel, bool onlineOnly, bool broadcastingOnly, out XblPresenceQueryFilters queryFilters)
		{
			queryFilters = null;
			return 0;
		}
	}
}
