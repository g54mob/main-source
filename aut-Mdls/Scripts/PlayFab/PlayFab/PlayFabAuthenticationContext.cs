namespace PlayFab
{
	public sealed class PlayFabAuthenticationContext
	{
		public string ClientSessionTicket;

		public string PlayFabId;

		public string EntityToken;

		public string EntityId;

		public string EntityType;

		public string TelemetryKey;

		public PlayFabAuthenticationContext()
		{
		}

		public PlayFabAuthenticationContext(string clientSessionTicket, string entityToken, string playFabId, string entityId, string entityType, string telemetryKey = null)
			: this()
		{
			ClientSessionTicket = clientSessionTicket;
			PlayFabId = playFabId;
			EntityToken = entityToken;
			EntityId = entityId;
			EntityType = entityType;
			TelemetryKey = telemetryKey;
		}

		public void CopyFrom(PlayFabAuthenticationContext other)
		{
			ClientSessionTicket = other.ClientSessionTicket;
			PlayFabId = other.PlayFabId;
			EntityToken = other.EntityToken;
			EntityId = other.EntityId;
			EntityType = other.EntityType;
			TelemetryKey = other.TelemetryKey;
		}

		public bool IsClientLoggedIn()
		{
			return !string.IsNullOrEmpty(ClientSessionTicket);
		}

		public bool IsEntityLoggedIn()
		{
			return !string.IsNullOrEmpty(EntityToken);
		}

		public bool IsTelemetryKeyProvided()
		{
			return !string.IsNullOrEmpty(TelemetryKey);
		}

		public void ForgetAllCredentials()
		{
			PlayFabId = null;
			ClientSessionTicket = null;
			EntityToken = null;
			EntityId = null;
			EntityType = null;
			TelemetryKey = null;
		}
	}
}
