namespace BestHTTP.SocketIO.Events
{
	public static class EventNames
	{
		public const string Connect = "connect";

		public const string Disconnect = "disconnect";

		public const string Event = "event";

		public const string Ack = "ack";

		public const string Error = "error";

		public const string BinaryEvent = "binaryevent";

		public const string BinaryAck = "binaryack";

		private static string[] SocketIONames;

		private static string[] TransportNames;

		private static string[] BlacklistedEvents;

		public static string GetNameFor(SocketIOEventTypes type)
		{
			return null;
		}

		public static string GetNameFor(TransportEventTypes transEvent)
		{
			return null;
		}

		public static bool IsBlacklisted(string eventName)
		{
			return false;
		}
	}
}
