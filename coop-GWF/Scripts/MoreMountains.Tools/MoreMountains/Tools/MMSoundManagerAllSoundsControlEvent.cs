namespace MoreMountains.Tools
{
	public struct MMSoundManagerAllSoundsControlEvent
	{
		public MMSoundManagerAllSoundsControlEventTypes EventType;

		private static MMSoundManagerAllSoundsControlEvent e;

		public MMSoundManagerAllSoundsControlEvent(MMSoundManagerAllSoundsControlEventTypes eventType)
		{
			EventType = eventType;
		}

		public static void Trigger(MMSoundManagerAllSoundsControlEventTypes eventType)
		{
			e.EventType = eventType;
			MMEventManager.TriggerEvent(e);
		}
	}
}
