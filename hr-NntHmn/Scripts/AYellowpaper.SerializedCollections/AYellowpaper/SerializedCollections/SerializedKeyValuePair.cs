using System;

namespace AYellowpaper.SerializedCollections
{
	[Serializable]
	public struct SerializedKeyValuePair<TKey, TValue>
	{
		public TKey Key;

		public TValue Value;

		public SerializedKeyValuePair(TKey key, TValue value)
		{
			Key = default(TKey);
			Value = default(TValue);
		}
	}
}
