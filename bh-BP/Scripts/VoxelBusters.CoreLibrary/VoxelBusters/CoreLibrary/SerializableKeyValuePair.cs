using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	[Serializable]
	public class SerializableKeyValuePair<TKey, TValue> : IEquatable<SerializableKeyValuePair<TKey, TValue>>
	{
		[SerializeField]
		private TKey m_key;

		[SerializeField]
		private TValue m_value;

		public TKey Key
		{
			get
			{
				return default(TKey);
			}
			set
			{
			}
		}

		public TValue Value
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		protected SerializableKeyValuePair(TKey key = default(TKey), TValue value = default(TValue))
		{
		}

		bool IEquatable<SerializableKeyValuePair<TKey, TValue>>.Equals(SerializableKeyValuePair<TKey, TValue> other)
		{
			return false;
		}
	}
}
