using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class Sessions
	{
		[DataMember(Name = "data", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "data")]
		public List<SessionContext> Data { get; set; }

		[DataMember(Name = "total_count", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "total_count")]
		public int? TotalCount { get; set; }

		[JsonProperty(PropertyName = "pagination")]
		[DataMember(Name = "pagination", EmitDefaultValue = false)]
		public Pagination Pagination { get; set; }

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
