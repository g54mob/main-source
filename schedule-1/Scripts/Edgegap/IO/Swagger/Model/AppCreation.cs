using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class AppCreation
	{
		[JsonProperty(PropertyName = "success")]
		[DataMember(Name = "success", EmitDefaultValue = false)]
		public bool? Success { get; set; }

		[JsonProperty(PropertyName = "version")]
		[DataMember(Name = "version", EmitDefaultValue = false)]
		public AppVersion Version { get; set; }

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
