using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Muna
{
	[Serializable]
	[Preserve]
	public class Predictor
	{
		public string tag;

		public User owner;

		public string name;

		public string description;

		public PredictorStatus status;

		public PredictorAccess access;

		[JsonConverter(typeof(IsoDateTimeConverter))]
		public DateTime created;

		public string? card;

		public string? media;

		public Signature? signature;

		public string? license;
	}
}
