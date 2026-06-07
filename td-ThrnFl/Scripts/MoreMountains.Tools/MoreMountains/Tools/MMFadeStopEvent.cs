namespace MoreMountains.Tools
{
	public struct MMFadeStopEvent
	{
		public int ID;

		private static MMFadeStopEvent e;

		public MMFadeStopEvent(int id = 0)
		{
			ID = id;
		}

		public static void Trigger(int id = 0)
		{
			e.ID = id;
			MMEventManager.TriggerEvent(e);
		}
	}
}
