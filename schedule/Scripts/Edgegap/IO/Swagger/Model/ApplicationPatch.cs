using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class ApplicationPatch
	{
		[DataMember(Name = "name", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[DataMember(Name = "is_active", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "is_active")]
		public bool? IsActive { get; set; }

		[JsonProperty(PropertyName = "image")]
		[DataMember(Name = "image", EmitDefaultValue = false)]
		public string Image { get; set; }

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
