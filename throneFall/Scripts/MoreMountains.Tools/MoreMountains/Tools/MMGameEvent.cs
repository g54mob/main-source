namespace MoreMountains.Tools
{
	public struct MMGameEvent
	{
		public string EventName;

		private static MMGameEvent e;

		public MMGameEvent(string newName)
		{
			EventName = newName;
		}

		public static void Trigger(string newName)
		{
			e.EventName = newName;
			MMEventManager.TriggerEvent(e);
		}
	}
}
