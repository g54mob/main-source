using System.Collections.Generic;

namespace ExitGames.Client.Photon
{
	public class Hashtable : Dictionary<object, object>
	{
		internal static readonly object[] boxedByte;

		public new object this[object key]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		public static object GetBoxedByte(byte value)
		{
			return null;
		}

		static Hashtable()
		{
		}

		public Hashtable()
		{
		}

		public Hashtable(int x)
		{
		}

		public void Add(byte k, object v)
		{
		}

		public void Remove(byte k)
		{
		}

		public bool ContainsKey(byte key)
		{
			return false;
		}

		public new DictionaryEntryEnumerator GetEnumerator()
		{
			return default(DictionaryEntryEnumerator);
		}

		public override string ToString()
		{
			return null;
		}

		public object Clone()
		{
			return null;
		}
	}
}
