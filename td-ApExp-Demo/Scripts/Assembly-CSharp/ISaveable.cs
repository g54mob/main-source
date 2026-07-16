public interface ISaveable
{
	void Save(SaveDataContext saveDataContext);

	void Load(SaveDataContext saveDataContext, bool isNewJourney);
}
