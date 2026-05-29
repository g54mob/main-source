using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class MatchmakerComponentResponse : BaseModel
	{
		[DataMember(Name = "name", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "repository")]
		[DataMember(Name = "repository", EmitDefaultValue = false)]
		public string Repository { get; set; }

		[JsonProperty(PropertyName = "image")]
		[DataMember(Name = "image", EmitDefaultValue = false)]
		public string Image { get; set; }

		[JsonProperty(PropertyName = "tag")]
		[DataMember(Name = "tag", EmitDefaultValue = false)]
		public string Tag { get; set; }

		[DataMember(Name = "credentials", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "credentials")]
		public object Credentials { get; set; }

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
