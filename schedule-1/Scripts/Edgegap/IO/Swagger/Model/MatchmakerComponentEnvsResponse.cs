using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class MatchmakerComponentEnvsResponse : BaseModel
	{
		[DataMember(Name = "key", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "key")]
		public string Key { get; set; }

		[DataMember(Name = "value", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "value")]
		public string Value { get; set; }

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
