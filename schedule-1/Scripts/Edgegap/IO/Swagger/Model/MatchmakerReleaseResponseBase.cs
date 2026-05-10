using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class MatchmakerReleaseResponseBase : BaseModel
	{
		[DataMember(Name = "app_name", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "app_name")]
		public string AppName { get; set; }

		[DataMember(Name = "version_name", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "version_name")]
		public string VersionName { get; set; }

		[DataMember(Name = "version", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "version")]
		public string Version { get; set; }

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
