namespace API
{
	public interface IApi
	{
		void API_Log();

		void API_SendAchievement(AchievementDefinition achievement);

		void API_SaveGame(int saveId, string data);

		string API_LoadGame(int saveId);

		bool API_HasSave(int saveId);

		void API_SaveApplication(string data);

		void API_SendXpInformation(int totalXp);

		string API_LoadApplication();

		bool API_HasApplicationSave();

		void API_RunCallbacks();
	}
}
