namespace MoreMountains.Tools
{
	public struct MMGameEvent
	{
		public string EventName;

		private static MMGameEvent e;

		public MMGameEvent(string newName)
		{
			EventName = null;
		}

		public static void Trigger(string newName)
		{
		}
	}
}
