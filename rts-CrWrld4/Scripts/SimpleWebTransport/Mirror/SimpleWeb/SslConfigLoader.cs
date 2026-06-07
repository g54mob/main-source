namespace Mirror.SimpleWeb
{
	internal class SslConfigLoader
	{
		internal struct Cert
		{
			public string path;

			public string password;
		}

		internal static SslConfig Load(SimpleWebTransport transport)
		{
			return default(SslConfig);
		}

		internal static Cert LoadCertJson(string certJsonPath)
		{
			return default(Cert);
		}
	}
}
