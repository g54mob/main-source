using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class ContainerLogStorageModel
	{
		[DataMember(Name = "enabled", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "enabled")]
		public bool? Enabled { get; set; }

		[DataMember(Name = "endpoint_storage", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "endpoint_storage")]
		public string EndpointStorage { get; set; }

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
