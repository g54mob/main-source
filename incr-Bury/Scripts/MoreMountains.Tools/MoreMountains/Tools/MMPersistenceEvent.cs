namespace MoreMountains.Tools
{
	public struct MMPersistenceEvent
	{
		public MMPersistenceEventType PersistenceEventType;

		public string PersistenceID;

		private static MMPersistenceEvent e;

		public MMPersistenceEvent(MMPersistenceEventType eventType, string persistenceID)
		{
			PersistenceEventType = eventType;
			PersistenceID = persistenceID;
		}

		public static void Trigger(MMPersistenceEventType eventType, string persistencyID)
		{
			e.PersistenceEventType = eventType;
			e.PersistenceID = persistencyID;
			MMEventManager.TriggerEvent(e);
		}
	}
}
