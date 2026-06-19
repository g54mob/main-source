namespace XGamingRuntime
{
	public class XblPresenceQueryFilters
	{
		public XblPresenceDeviceType[] DeviceTypes { get; }

		public uint[] TitleIds { get; }

		public XblPresenceDetailLevel DetailLevel { get; }

		public bool OnlineOnly { get; }

		public bool BroadcastingOnly { get; }

		private XblPresenceQueryFilters(XblPresenceDeviceType[] deviceTypes, uint[] titleIds, XblPresenceDetailLevel detailLevel, bool onlineOnly, bool broadcastingOnly)
		{
			DeviceTypes = deviceTypes;
			TitleIds = titleIds;
			DetailLevel = detailLevel;
			OnlineOnly = onlineOnly;
			BroadcastingOnly = broadcastingOnly;
		}

		public static int Create(XblPresenceDeviceType[] deviceTypes, uint[] titleIds, XblPresenceDetailLevel detailLevel, bool onlineOnly, bool broadcastingOnly, out XblPresenceQueryFilters queryFilters)
		{
			queryFilters = new XblPresenceQueryFilters(deviceTypes, titleIds, detailLevel, onlineOnly, broadcastingOnly);
			return 0;
		}
	}
}
