namespace MoreMountains.Tools
{
	public struct MMSoundManagerEvent
	{
		public MMSoundManagerEventTypes EventType;

		private static MMSoundManagerEvent e;

		public MMSoundManagerEvent(MMSoundManagerEventTypes eventType)
		{
			EventType = eventType;
		}

		public static void Trigger(MMSoundManagerEventTypes eventType)
		{
			e.EventType = eventType;
			MMEventManager.TriggerEvent(e);
		}
	}
}
