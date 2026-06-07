using System;
using System.Collections.Generic;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	public class Association<TKey, TValue>
	{
		public TKey Key { get; set; }

		public TValue Value { get; set; }

		public Association()
		{
		}

		public Association(TKey key, TValue value)
		{
			Key = key;
			Value = value;
		}

		public Association(KeyValuePair<TKey, TValue> value)
		{
			Key = value.Key;
			Value = value.Value;
		}

		public KeyValuePair<TKey, TValue> ToKeyValuePair()
		{
			return new KeyValuePair<TKey, TValue>(Key, Value);
		}

		public override string ToString()
		{
			return string.Format("{0} : {1}", Key, Value);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj == this)
			{
				return true;
			}
			Association<TKey, TValue> association = obj as Association<TKey, TValue>;
			if (association == null)
			{
				return false;
			}
			if (Key.Equals(association.Key))
			{
				return Value.Equals(association.Value);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ((!object.Equals(Key, default(TKey))) ? Key.GetHashCode() : 0) + ((!object.Equals(Value, default(TValue))) ? Value.GetHashCode() : 0) * 37;
		}
	}
}
