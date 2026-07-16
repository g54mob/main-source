public class SaveDataContext
{
	public MetaSavefile MetaSave { get; private set; }

	public JourneySavefile JourneySave { get; private set; }

	public SettingsSavefile SettingsSave { get; private set; }

	public SaveDataContext(MetaSavefile meta, JourneySavefile journey, SettingsSavefile settings)
	{
		MetaSave = meta;
		JourneySave = journey;
		SettingsSave = settings;
	}
}
