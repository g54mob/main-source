namespace Assets.Scripts.Multiplayer.Lobbies
{
	public class LobbyData
	{
		public ulong Id { get; }

		public int Latency { get; }

		public int MaxCraftPartCount { get; }

		public int MaxPlayers { get; }

		public string Name { get; }

		public ulong OwnerId { get; }

		public bool PasswordProtected { get; set; }

		public int Players { get; }

		public int ReportCount { get; }

		public LobbyData(ulong id, ulong ownerId, string name, int latency, int players, int maxPlayers, int maxCraftPartCount, int reportCount, bool passwordProtected)
		{
			Id = id;
			OwnerId = ownerId;
			Name = name;
			Latency = latency;
			Players = players;
			MaxPlayers = maxPlayers;
			MaxCraftPartCount = maxCraftPartCount;
			ReportCount = reportCount;
			PasswordProtected = passwordProtected;
		}
	}
}
