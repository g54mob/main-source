using System;

namespace ModIO
{
	[Serializable]
	public struct ServerSettings
	{
		public string serverURL;

		public uint gameId;

		public string gameKey;

		public string languageCode;

		public bool disableUploads;

		public ServerSettings(ServerSettings serverSettings)
		{
			serverURL = serverSettings.serverURL;
			gameId = serverSettings.gameId;
			gameKey = serverSettings.gameKey;
			disableUploads = serverSettings.disableUploads;
			languageCode = serverSettings.languageCode;
		}
	}
}
