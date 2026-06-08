namespace Amazon.Runtime.Internal
{
	public class CSMConfiguration
	{
		public string Host { get; internal set; } = "127.0.0.1";

		public int Port { get; internal set; } = 31000;

		public bool Enabled { get; internal set; }

		public string ClientId { get; internal set; } = string.Empty;
	}
}
