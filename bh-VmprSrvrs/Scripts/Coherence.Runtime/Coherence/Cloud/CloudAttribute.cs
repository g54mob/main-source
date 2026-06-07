using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct CloudAttribute
	{
		[JsonProperty("key")]
		private string key;

		[JsonProperty("val")]
		private object value;

		[JsonProperty("pub")]
		private bool? isPublic;

		[JsonProperty("idx")]
		private string index;

		[JsonProperty("aggr")]
		private string aggregate;

		[JsonIgnore]
		public string Key => null;

		public CloudAttribute(string key, long value, bool? isPublic = null)
		{
			this.key = null;
			this.value = null;
			this.isPublic = null;
			index = null;
			aggregate = null;
		}

		public CloudAttribute(string key, string value, bool? isPublic = null)
		{
			this.key = null;
			this.value = null;
			this.isPublic = null;
			index = null;
			aggregate = null;
		}

		public CloudAttribute(string key, long value, IntAttributeIndex index, IntAggregator aggregate, bool? isPublic = null)
		{
			this.key = null;
			this.value = null;
			this.isPublic = null;
			this.index = null;
			this.aggregate = null;
		}

		public CloudAttribute(string key, string value, StringAttributeIndex index, StringAggregator aggregate, bool? isPublic = null)
		{
			this.key = null;
			this.value = null;
			this.isPublic = null;
			this.index = null;
			this.aggregate = null;
		}

		public long GetLongValue()
		{
			return 0L;
		}

		public string GetStringValue()
		{
			return null;
		}

		private void LogError(string errorMsg)
		{
		}
	}
}
