using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class NetworkMetricsModel
	{
		[DataMember(Name = "receive", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "receive")]
		public MetricsModel Receive { get; set; }

		[DataMember(Name = "transmit", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "transmit")]
		public MetricsModel Transmit { get; set; }

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
