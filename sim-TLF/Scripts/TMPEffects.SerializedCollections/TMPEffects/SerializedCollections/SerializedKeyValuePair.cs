using System;

namespace TMPEffects.SerializedCollections
{
	[Serializable]
	public struct SerializedKeyValuePair<TKey, TValue>
	{
		public TKey Key;

		public TValue Value;

		public SerializedKeyValuePair(TKey key, TValue value)
		{
			Key = key;
			Value = value;
		}
	}
}
