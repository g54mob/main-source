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
			serverURL = null;
			gameId = 0u;
			gameKey = null;
			languageCode = null;
			disableUploads = false;
		}
	}
}
