namespace Photon.Realtime
{
	public class Region
	{
		public string Code { get; private set; }

		public string Cluster { get; private set; }

		public string HostAndPort { get; protected internal set; }

		public int Ping { get; set; }

		public bool WasPinged => false;

		public Region(string code, string address)
		{
		}

		public Region(string code, int ping)
		{
		}

		private void SetCodeAndCluster(string codeAsString)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public string ToString(bool compact = false)
		{
			return null;
		}
	}
}
