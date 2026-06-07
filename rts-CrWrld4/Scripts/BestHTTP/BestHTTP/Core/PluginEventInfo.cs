namespace BestHTTP.Core
{
	public readonly struct PluginEventInfo
	{
		public readonly PluginEvents Event;

		public readonly object Payload;

		public PluginEventInfo(PluginEvents @event)
		{
			Event = default(PluginEvents);
			Payload = null;
		}

		public PluginEventInfo(PluginEvents @event, object payload)
		{
			Event = default(PluginEvents);
			Payload = null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
