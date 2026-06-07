using System;
using System.Collections.Generic;

namespace Mirror.Cloud.ListServerService
{
	[Serializable]
	public struct ServerJson : ICanBeJson
	{
		public string protocol;

		public int port;

		public int playerCount;

		public int maxPlayerCount;

		public string displayName;

		public string address;

		public string customAddress;

		public KeyValue[] customData;

		public Uri GetServerUri()
		{
			return null;
		}

		public Uri GetCustomUri()
		{
			return null;
		}

		public void SetCustomData(Dictionary<string, string> data)
		{
		}

		public bool Validate()
		{
			return false;
		}
	}
}
