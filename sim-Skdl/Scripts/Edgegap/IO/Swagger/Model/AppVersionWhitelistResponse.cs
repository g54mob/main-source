using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class AppVersionWhitelistResponse
	{
		[JsonProperty(PropertyName = "whitelist_entries")]
		[DataMember(Name = "whitelist_entries", EmitDefaultValue = false)]
		public List<AppVersionWhitelistEntry> WhitelistEntries { get; set; }

		public override string ToString()
		{
			return null;
		}

		public string ToJson()
		{
			return null;
		}
	}
}
