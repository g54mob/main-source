using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class MatchmakerManagedReleaseResponse : MatchmakerReleaseResponseBase
	{
		[DataMember(Name = "release_config_name", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "release_config_name")]
		public string ReleaseConfigName { get; set; }

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
