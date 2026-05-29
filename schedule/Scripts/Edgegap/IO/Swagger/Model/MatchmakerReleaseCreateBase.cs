using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class MatchmakerReleaseCreateBase
	{
		[JsonProperty(PropertyName = "version")]
		[DataMember(Name = "version", EmitDefaultValue = false)]
		public string Version { get; set; }

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
