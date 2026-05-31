using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;

namespace ExitGames.Client.Photon
{
	public class ParameterDictionary : IEnumerable<KeyValuePair<byte, object>>, IEnumerable
	{
		public readonly NonAllocDictionary<byte, object> paramDict;

		public readonly StructWrapperPools wrapperPools;

		public object this[byte key]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Count => 0;

		public ParameterDictionary()
		{
		}

		public ParameterDictionary(int capacity)
		{
		}

		public static implicit operator NonAllocDictionary<byte, object>(ParameterDictionary value)
		{
			return null;
		}

		IEnumerator<KeyValuePair<byte, object>> IEnumerable<KeyValuePair<byte, object>>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public NonAllocDictionary<byte, object>.PairIterator GetEnumerator()
		{
			return default(NonAllocDictionary<byte, object>.PairIterator);
		}

		public void Clear()
		{
		}

		public void Add(byte code, string value)
		{
		}

		public void Add(byte code, Hashtable value)
		{
		}

		public void Add(byte code, byte value)
		{
		}

		public void Add(byte code, bool value)
		{
		}

		public void Add(byte code, short value)
		{
		}

		public void Add(byte code, int value)
		{
		}

		public void Add(byte code, long value)
		{
		}

		public void Add(byte code, object value)
		{
		}

		public T Unwrap<T>(byte key)
		{
			return default(T);
		}

		public T Get<T>(byte key)
		{
			return default(T);
		}

		public bool ContainsKey(byte key)
		{
			return false;
		}

		public object TryGetObject(byte key)
		{
			return null;
		}

		public bool TryGetValue(byte key, out object value)
		{
			value = null;
			return false;
		}

		public bool TryGetValue<T>(byte key, out T value) where T : struct
		{
			value = default(T);
			return false;
		}

		public string ToStringFull(bool includeTypes = true)
		{
			return null;
		}
	}
}
