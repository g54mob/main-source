using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class MatchmakerComponentCreate
	{
		[DataMember(Name = "name", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "repository")]
		[DataMember(Name = "repository", EmitDefaultValue = false)]
		public string Repository { get; set; }

		[DataMember(Name = "image", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "image")]
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
