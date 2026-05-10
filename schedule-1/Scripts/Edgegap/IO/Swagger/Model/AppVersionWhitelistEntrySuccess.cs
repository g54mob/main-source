using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class AppVersionWhitelistEntrySuccess
	{
		[DataMember(Name = "success", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "success")]
		public bool? Success { get; set; }

		[JsonProperty(PropertyName = "whitelist_entry")]
		[DataMember(Name = "whitelist_entry", EmitDefaultValue = false)]
		public AppVersionWhitelistEntry WhitelistEntry { get; set; }

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
