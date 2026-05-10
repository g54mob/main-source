using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class Deployments
	{
		[DataMember(Name = "data", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "data")]
		public List<Deployment> Data { get; set; }

		[JsonProperty(PropertyName = "total_count")]
		[DataMember(Name = "total_count", EmitDefaultValue = false)]
		public int? TotalCount { get; set; }

		[JsonProperty(PropertyName = "pagination")]
		[DataMember(Name = "pagination", EmitDefaultValue = false)]
		public Pagination Pagination { get; set; }

		[JsonProperty(PropertyName = "message")]
		[DataMember(Name = "message", EmitDefaultValue = false)]
		public List<string> Message { get; set; }

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
