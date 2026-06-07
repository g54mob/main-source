using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class PortMapping
	{
		[DataMember(Name = "external", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "external")]
		public int? External { get; set; }

		[JsonProperty(PropertyName = "internal")]
		[DataMember(Name = "internal", EmitDefaultValue = false)]
		public int? Internal { get; set; }

		[DataMember(Name = "protocol", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "protocol")]
		public string Protocol { get; set; }

		[DataMember(Name = "name", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[DataMember(Name = "tls_upgrade", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "tls_upgrade")]
		public bool? TlsUpgrade { get; set; }

		[DataMember(Name = "link", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "link")]
		public string Link { get; set; }

		[DataMember(Name = "proxy", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "proxy")]
		public int? Proxy { get; set; }

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
