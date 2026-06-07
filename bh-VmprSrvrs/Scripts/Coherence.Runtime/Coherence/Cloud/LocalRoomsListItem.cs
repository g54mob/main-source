using System.Collections.Generic;

namespace Coherence.Cloud
{
	public struct LocalRoomsListItem
	{
		public ulong UniqueID;

		public ushort ID;

		public int MaxClients;

		public string SchemaName;

		public int ConnectionCount;

		public string LastCheckTime;

		public string ProjectID;

		public Dictionary<string, string> KVP;

		public string[] Tags;
	}
}
