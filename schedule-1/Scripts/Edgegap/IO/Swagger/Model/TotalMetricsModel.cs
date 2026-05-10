using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class TotalMetricsModel
	{
		[DataMember(Name = "receive_total", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "receive_total")]
		public MetricsModel ReceiveTotal { get; set; }

		[DataMember(Name = "transmit_total", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "transmit_total")]
		public MetricsModel TransmitTotal { get; set; }

		[JsonProperty(PropertyName = "disk_read_total")]
		[DataMember(Name = "disk_read_total", EmitDefaultValue = false)]
		public MetricsModel DiskReadTotal { get; set; }

		[DataMember(Name = "disk_write_total", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "disk_write_total")]
		public MetricsModel DiskWriteTotal { get; set; }

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
