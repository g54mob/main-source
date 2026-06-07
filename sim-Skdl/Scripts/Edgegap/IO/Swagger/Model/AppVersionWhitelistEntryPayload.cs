using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class AppVersionWhitelistEntryPayload
	{
		[DataMember(Name = "cidr", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "cidr")]
		public string Cidr { get; set; }

		[JsonProperty(PropertyName = "label")]
		[DataMember(Name = "label", EmitDefaultValue = false)]
		public string Label { get; set; }

		[DataMember(Name = "is_active", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "is_active")]
		public bool? IsActive { get; set; }

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
