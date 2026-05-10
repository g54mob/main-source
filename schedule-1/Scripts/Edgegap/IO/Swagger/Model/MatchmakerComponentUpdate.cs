using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class MatchmakerComponentUpdate
	{
		[DataMember(Name = "name", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[DataMember(Name = "repository", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "repository")]
		public string Repository { get; set; }

		[JsonProperty(PropertyName = "image")]
		[DataMember(Name = "image", EmitDefaultValue = false)]
		public string Image { get; set; }

		[DataMember(Name = "tag", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "tag")]
		public string Tag { get; set; }

		[JsonProperty(PropertyName = "credentials")]
		[DataMember(Name = "credentials", EmitDefaultValue = false)]
		public object Credentials { get; set; }

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
