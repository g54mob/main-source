using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class MatchmakerResponse : BaseModel
	{
		[JsonProperty(PropertyName = "name")]
		[DataMember(Name = "name", EmitDefaultValue = false)]
		public string Name { get; set; }

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
