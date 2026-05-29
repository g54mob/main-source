using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class Delete
	{
		[JsonProperty(PropertyName = "message")]
		[DataMember(Name = "message", EmitDefaultValue = false)]
		public string Message { get; set; }

		[DataMember(Name = "deployment_summary", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "deployment_summary")]
		public Status DeploymentSummary { get; set; }

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
