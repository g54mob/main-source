using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class Request
	{
		[DataMember(Name = "request_id", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "request_id")]
		public string RequestId { get; set; }

		[JsonProperty(PropertyName = "request_dns")]
		[DataMember(Name = "request_dns", EmitDefaultValue = false)]
		public string RequestDns { get; set; }

		[JsonProperty(PropertyName = "request_app")]
		[DataMember(Name = "request_app", EmitDefaultValue = false)]
		public string RequestApp { get; set; }

		[DataMember(Name = "request_version", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "request_version")]
		public string RequestVersion { get; set; }

		[DataMember(Name = "request_user_count", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "request_user_count")]
		public int? RequestUserCount { get; set; }

		[JsonProperty(PropertyName = "city")]
		[DataMember(Name = "city", EmitDefaultValue = false)]
		public string City { get; set; }

		[DataMember(Name = "country", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "country")]
		public string Country { get; set; }

		[JsonProperty(PropertyName = "continent")]
		[DataMember(Name = "continent", EmitDefaultValue = false)]
		public string Continent { get; set; }

		[DataMember(Name = "administrative_division", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "administrative_division")]
		public string AdministrativeDivision { get; set; }

		[DataMember(Name = "tags", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "tags")]
		public List<string> Tags { get; set; }

		[DataMember(Name = "container_log_storage", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "container_log_storage")]
		public ContainerLogStorageModel ContainerLogStorage { get; set; }

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
