using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class MatchmakerReleaseResponse : MatchmakerReleaseResponseBase
	{
		[DataMember(Name = "frontend_component_name", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "frontend_component_name")]
		public string FrontendComponentName { get; set; }

		[JsonProperty(PropertyName = "director_component_name")]
		[DataMember(Name = "director_component_name", EmitDefaultValue = false)]
		public string DirectorComponentName { get; set; }

		[JsonProperty(PropertyName = "match_function_component_name")]
		[DataMember(Name = "match_function_component_name", EmitDefaultValue = false)]
		public string MatchFunctionComponentName { get; set; }

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
