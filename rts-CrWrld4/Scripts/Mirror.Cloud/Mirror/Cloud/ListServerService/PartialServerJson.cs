using System;
using System.Collections.Generic;

namespace Mirror.Cloud.ListServerService
{
	[Serializable]
	public struct PartialServerJson : ICanBeJson
	{
		public int playerCount;

		public int maxPlayerCount;

		public string displayName;

		public KeyValue[] customData;

		public void SetCustomData(Dictionary<string, string> data)
		{
		}

		public void Validate()
		{
		}
	}
}
