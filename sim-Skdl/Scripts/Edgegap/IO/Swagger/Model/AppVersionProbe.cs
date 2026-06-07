using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class AppVersionProbe
	{
		[DataMember(Name = "optimal_ping", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "optimal_ping")]
		public int? OptimalPing { get; set; }

		[DataMember(Name = "rejected_ping", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "rejected_ping")]
		public int? RejectedPing { get; set; }

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
