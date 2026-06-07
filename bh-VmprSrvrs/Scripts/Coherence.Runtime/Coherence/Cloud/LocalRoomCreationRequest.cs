using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct LocalRoomCreationRequest
	{
		[JsonProperty("UniqueID")]
		public int UniqueID;

		[JsonProperty("MaxClients")]
		public int MaxClients;

		[JsonProperty("MaxEntities")]
		public int MaxEntities;

		[JsonProperty("OutStatsFreq")]
		public int OutStatsFreq;

		[JsonProperty("LogStatsFreq")]
		public int LogStatsFreq;

		[JsonProperty("SchemaName")]
		public string SchemaName;

		[JsonProperty("SchemaTimeout")]
		public int SchemaTimeout;

		[JsonProperty("SchemaUrls")]
		public string[] SchemaUrls;

		[JsonProperty("Schemas")]
		public string[] Schemas;

		[JsonProperty("DisconnectTimeout")]
		public int DisconnectTimeout;

		[JsonProperty("DebugStreams")]
		public bool DebugStreams;

		[JsonProperty("Frequency")]
		public int Frequency;

		[JsonProperty("MinQueryDistance")]
		public float MinQueryDistance;

		[JsonProperty("WebSupport")]
		public bool WebSupport;

		[JsonProperty("CleanupTimeout")]
		public int CleanupTimeout;

		[JsonProperty("ProjectID")]
		public string ProjectID;

		[JsonProperty("KVP")]
		public Dictionary<string, string> KeyValues;

		[JsonProperty("Tags")]
		public string[] Tags;

		[JsonProperty("Secret")]
		public string Secret;

		[JsonProperty("HostAuthority")]
		public int HostAuthority;
	}
}
