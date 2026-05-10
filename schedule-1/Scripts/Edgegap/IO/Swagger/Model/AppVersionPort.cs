using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class AppVersionPort
	{
		[JsonProperty(PropertyName = "port")]
		[DataMember(Name = "port", EmitDefaultValue = false)]
		public int? Port { get; set; }

		[JsonProperty(PropertyName = "protocol")]
		[DataMember(Name = "protocol", EmitDefaultValue = false)]
		public string Protocol { get; set; }

		[JsonProperty(PropertyName = "to_check")]
		[DataMember(Name = "to_check", EmitDefaultValue = false)]
		public bool? ToCheck { get; set; }

		[DataMember(Name = "tls_upgrade", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "tls_upgrade")]
		public bool? TlsUpgrade { get; set; }

		[DataMember(Name = "name", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

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
