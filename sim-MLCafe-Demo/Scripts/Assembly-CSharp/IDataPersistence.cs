public interface IDataPersistence
{
	void LoadData(GameData data, bool isNewGameData);

	void SaveData(ref GameData data);
}
