using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class AppVersions
	{
		[JsonProperty(PropertyName = "versions")]
		[DataMember(Name = "versions", EmitDefaultValue = false)]
		public List<AppVersion> Versions { get; set; }

		[JsonProperty(PropertyName = "total_count")]
		[DataMember(Name = "total_count", EmitDefaultValue = false)]
		public int? TotalCount { get; set; }

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
