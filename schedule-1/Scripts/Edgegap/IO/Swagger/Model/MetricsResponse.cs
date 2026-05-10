using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class MetricsResponse
	{
		[DataMember(Name = "total", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "total")]
		public TotalMetricsModel Total { get; set; }

		[DataMember(Name = "cpu", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "cpu")]
		public MetricsModel Cpu { get; set; }

		[JsonProperty(PropertyName = "mem")]
		[DataMember(Name = "mem", EmitDefaultValue = false)]
		public MetricsModel Mem { get; set; }

		[DataMember(Name = "network", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "network")]
		public NetworkMetricsModel Network { get; set; }

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
