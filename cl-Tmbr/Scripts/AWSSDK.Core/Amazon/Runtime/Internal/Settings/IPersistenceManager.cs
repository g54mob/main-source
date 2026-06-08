namespace Amazon.Runtime.Internal.Settings
{
	public interface IPersistenceManager
	{
		SettingsCollection GetSettings(string type);

		void SaveSettings(string type, SettingsCollection settings);
	}
}
