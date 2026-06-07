using System;
using System.Collections.Generic;

namespace BestHTTP.SocketIO
{
	public sealed class HandshakeData
	{
		public string Sid { get; private set; }

		public List<string> Upgrades { get; private set; }

		public TimeSpan PingInterval { get; private set; }

		public TimeSpan PingTimeout { get; private set; }

		public bool Parse(string str)
		{
			return false;
		}

		private static object Get(Dictionary<string, object> from, string key)
		{
			return null;
		}

		private static string GetString(Dictionary<string, object> from, string key)
		{
			return null;
		}

		private static List<string> GetStringList(Dictionary<string, object> from, string key)
		{
			return null;
		}

		private static int GetInt(Dictionary<string, object> from, string key)
		{
			return 0;
		}
	}
}
