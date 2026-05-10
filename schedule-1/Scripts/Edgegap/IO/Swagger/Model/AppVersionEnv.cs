using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class AppVersionEnv
	{
		[DataMember(Name = "key", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "key")]
		public string Key { get; set; }

		[DataMember(Name = "value", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "value")]
		public string Value { get; set; }

		[DataMember(Name = "is_secret", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "is_secret")]
		public bool? IsSecret { get; set; }

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
