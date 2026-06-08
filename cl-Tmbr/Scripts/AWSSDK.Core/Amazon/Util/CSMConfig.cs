namespace Amazon.Util
{
	public class CSMConfig
	{
		internal const string DEFAULT_HOST = "127.0.0.1";

		internal const int DEFAULT_PORT = 31000;

		public string CSMHost { get; set; } = "127.0.0.1";

		public int CSMPort { get; set; } = 31000;

		public string CSMClientId { get; set; }

		public bool? CSMEnabled { get; set; }
	}
}
