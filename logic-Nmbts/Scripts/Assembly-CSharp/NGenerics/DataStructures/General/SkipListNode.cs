using System;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	internal sealed class SkipListNode<TKey, TValue>
	{
		internal TKey Key { get; private set; }

		internal TValue Value { get; set; }

		internal SkipListNode<TKey, TValue> Right { get; set; }

		internal SkipListNode<TKey, TValue> Down { get; set; }

		internal SkipListNode()
		{
		}

		internal SkipListNode(TKey key, TValue val)
		{
			Key = key;
			Value = val;
		}
	}
}
