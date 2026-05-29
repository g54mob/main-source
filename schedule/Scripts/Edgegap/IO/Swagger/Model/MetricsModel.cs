using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class MetricsModel
	{
		[JsonProperty(PropertyName = "labels")]
		[DataMember(Name = "labels", EmitDefaultValue = false)]
		public List<string> Labels { get; set; }

		[JsonProperty(PropertyName = "datasets")]
		[DataMember(Name = "datasets", EmitDefaultValue = false)]
		public List<decimal?> Datasets { get; set; }

		[JsonProperty(PropertyName = "timestamps")]
		[DataMember(Name = "timestamps", EmitDefaultValue = false)]
		public List<DateTime?> Timestamps { get; set; }

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
