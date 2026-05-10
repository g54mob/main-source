using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class SelectorModel
	{
		[DataMember(Name = "tag", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "tag")]
		public string Tag { get; set; }

		[JsonProperty(PropertyName = "tag_only")]
		[DataMember(Name = "tag_only", EmitDefaultValue = false)]
		public bool? TagOnly { get; set; }

		[JsonProperty(PropertyName = "env")]
		[DataMember(Name = "env", EmitDefaultValue = false)]
		public object Env { get; set; }

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
