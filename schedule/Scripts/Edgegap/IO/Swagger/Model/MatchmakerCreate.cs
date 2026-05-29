using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class MatchmakerCreate
	{
		[JsonProperty(PropertyName = "name")]
		[DataMember(Name = "name", EmitDefaultValue = false)]
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
