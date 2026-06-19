namespace PugPlatform
{
	public interface IRichPresence
	{
		void StartSession(RichPresenceSessionTypes type);

		void EndSession();

		void SetSessionKey(string sessionKey);

		void SetPartySize(int size);

		void SetCurrentBiome(string biome);

		void SetCurrentTask(string task);
	}
}
