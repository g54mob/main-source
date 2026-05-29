using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class MatchmakerReleaseConfigResponse : BaseModel
	{
		[DataMember(Name = "name", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "configuration")]
		[DataMember(Name = "configuration", EmitDefaultValue = false)]
		public string Configuration { get; set; }

		public override string ToString()
		{
			return null;
		}

		public new string ToJson()
		{
			return null;
		}
	}
}
