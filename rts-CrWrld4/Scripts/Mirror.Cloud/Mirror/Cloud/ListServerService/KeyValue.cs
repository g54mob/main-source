using System;

namespace Mirror.Cloud.ListServerService
{
	[Serializable]
	public struct KeyValue
	{
		private const int MaxKeySize = 32;

		private const int MaxValueSize = 256;

		public string key;

		public string value;

		public KeyValue(string key, string value)
		{
			this.key = null;
			this.value = null;
		}

		public void Validate()
		{
		}
	}
}
