namespace CloudOnce.Internal.Providers
{
	public class DummyStorageWrapper : ICloudStorageProvider
	{
		private readonly CloudOnceEvents cloudOnceEvents;

		public DummyStorageWrapper(CloudOnceEvents events)
		{
			cloudOnceEvents = events;
		}

		public void Save()
		{
			DataManager.SaveToDisk();
			cloudOnceEvents.RaiseOnCloudSaveComplete(success: false);
		}

		public void Load()
		{
			cloudOnceEvents.RaiseOnCloudLoadComplete(success: false);
		}

		public void Synchronize()
		{
			Load();
			Save();
		}

		public bool ResetVariable(string key)
		{
			return DataManager.ResetCloudPref(key);
		}

		public bool DeleteVariable(string key)
		{
			return DataManager.DeleteCloudPref(key);
		}

		public string[] ClearUnusedVariables()
		{
			return DataManager.ClearStowawayVariablesFromGameData();
		}

		public void DeleteAll()
		{
			DataManager.DeleteAllCloudVariables();
		}
	}
}
