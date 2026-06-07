namespace MoreMountains.Tools
{
	public struct MMFadeStopEvent
	{
		public int ID;

		public bool Restore;

		private static MMFadeStopEvent e;

		public MMFadeStopEvent(int id = 0, bool restore = false)
		{
			Restore = restore;
			ID = id;
		}

		public static void Trigger(int id = 0, bool restore = false)
		{
			e.ID = id;
			e.Restore = restore;
			MMEventManager.TriggerEvent(e);
		}
	}
}
