using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Muna
{
	[Serializable]
	[Preserve]
	public class Prediction
	{
		public string id;

		public string tag;

		[JsonConverter(typeof(IsoDateTimeConverter))]
		public DateTime created;

		public object?[]? results;

		public double? latency;

		public string? error;

		public string? logs;

		public PredictionResource[]? resources;

		public string? configuration;
	}
}
