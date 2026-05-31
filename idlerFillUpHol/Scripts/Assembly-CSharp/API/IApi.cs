namespace API
{
	public interface IApi
	{
		void API_Log();

		void API_SendAchievement(AchievementDefinition achievement);

		void API_SaveGame(string data);

		string API_LoadGame();

		bool API_HasSave();

		void API_SaveApplication(string data);

		void API_SendXpInformation(int totalXp);

		string API_LoadApplication();

		bool API_HasApplicationSave();
	}
}
