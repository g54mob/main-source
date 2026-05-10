using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class DeployEnvModel
	{
		[JsonProperty(PropertyName = "key")]
		[DataMember(Name = "key", EmitDefaultValue = false)]
		public string Key { get; set; }

		[JsonProperty(PropertyName = "value")]
		[DataMember(Name = "value", EmitDefaultValue = false)]
		public string Value { get; set; }

		[DataMember(Name = "is_hidden", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "is_hidden")]
		public bool? IsHidden { get; set; }

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
