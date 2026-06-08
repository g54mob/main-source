namespace Kitchen
{
	public interface IPreference
	{
		Pref Key { get; }

		void Save();

		void Load();

		string SaveAsString();

		void LoadFromString(string value);
	}
}
