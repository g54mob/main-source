using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LitJson
{
	[Serializable]
	public class JsonData : IJsonWrapper, IList, ICollection, IEnumerable, IOrderedDictionary, IDictionary, IEquatable<JsonData>
	{
		private object val;

		private string json;

		private JsonType type;

		private IList<KeyValuePair<string, JsonData>> list;

		public int Count => 0;

		public bool IsArray => false;

		public bool IsBoolean => false;

		public bool IsReal => false;

		public bool IsNatural => false;

		public bool IsObject => false;

		public bool IsString => false;

		public ICollection<string> Keys => null;

		int ICollection.Count => 0;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => null;

		ICollection IDictionary.Values => null;

		bool IList.IsFixedSize => false;

		bool IList.IsReadOnly => false;

		object IDictionary.this[object key]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		object IOrderedDictionary.this[int idx]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		object IList.this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JsonData this[string name]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JsonData this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JsonData(bool boolean)
		{
		}

		public JsonData(double number)
		{
		}

		public JsonData(long number)
		{
		}

		public JsonData(string str)
		{
		}

		public JsonData(object obj)
		{
		}

		public JsonData()
		{
		}

		public JsonData(sbyte number)
		{
		}

		public JsonData(byte number)
		{
		}

		public JsonData(short number)
		{
		}

		public JsonData(ushort number)
		{
		}

		public JsonData(int number)
		{
		}

		public JsonData(uint number)
		{
		}

		public JsonData(ulong number)
		{
		}

		public JsonData(float number)
		{
		}

		public JsonData(decimal number)
		{
		}

		public static implicit operator JsonData(bool data)
		{
			return null;
		}

		public static implicit operator JsonData(double data)
		{
			return null;
		}

		public static implicit operator JsonData(long data)
		{
			return null;
		}

		public static implicit operator JsonData(string data)
		{
			return null;
		}

		public static explicit operator bool(JsonData data)
		{
			return false;
		}

		public static explicit operator float(JsonData data)
		{
			return 0f;
		}

		public static explicit operator double(JsonData data)
		{
			return 0.0;
		}

		public static explicit operator decimal(JsonData data)
		{
			return default(decimal);
		}

		public static explicit operator sbyte(JsonData data)
		{
			return 0;
		}

		public static explicit operator byte(JsonData data)
		{
			return 0;
		}

		public static explicit operator short(JsonData data)
		{
			return 0;
		}

		public static explicit operator ushort(JsonData data)
		{
			return 0;
		}

		public static explicit operator int(JsonData data)
		{
			return 0;
		}

		public static explicit operator uint(JsonData data)
		{
			return 0u;
		}

		public static explicit operator long(JsonData data)
		{
			return 0L;
		}

		public static explicit operator ulong(JsonData data)
		{
			return 0uL;
		}

		public static explicit operator string(JsonData data)
		{
			return null;
		}

		void ICollection.CopyTo(Array array, int index)
		{
		}

		void IDictionary.Add(object key, object value)
		{
		}

		void IDictionary.Clear()
		{
		}

		bool IDictionary.Contains(object key)
		{
			return false;
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return null;
		}

		void IDictionary.Remove(object key)
		{
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public bool GetBoolean()
		{
			return false;
		}

		public double GetReal()
		{
			return 0.0;
		}

		public long GetNatural()
		{
			return 0L;
		}

		public string GetString()
		{
			return null;
		}

		private IDictionary<string, JsonData> GetObject()
		{
			return null;
		}

		private IList<JsonData> GetArray()
		{
			return null;
		}

		public void SetBoolean(bool val)
		{
		}

		public void SetReal(double val)
		{
		}

		public void SetNatural(long val)
		{
		}

		public void SetString(string val)
		{
		}

		void IJsonWrapper.ToJson(JsonWriter writer)
		{
		}

		int IList.Add(object value)
		{
			return 0;
		}

		void IList.Clear()
		{
		}

		bool IList.Contains(object value)
		{
			return false;
		}

		int IList.IndexOf(object value)
		{
			return 0;
		}

		void IList.Insert(int index, object value)
		{
		}

		void IList.Remove(object value)
		{
		}

		void IList.RemoveAt(int index)
		{
		}

		IDictionaryEnumerator IOrderedDictionary.GetEnumerator()
		{
			return null;
		}

		void IOrderedDictionary.Insert(int idx, object key, object value)
		{
		}

		void IOrderedDictionary.RemoveAt(int idx)
		{
		}

		private ICollection EnsureCollection()
		{
			return null;
		}

		private IDictionary EnsureDictionary()
		{
			return null;
		}

		private IList EnsureList()
		{
			return null;
		}

		private JsonData ToJsonData(object obj)
		{
			return null;
		}

		private static void WriteJson(IJsonWrapper obj, JsonWriter writer)
		{
		}

		public int Add(object value)
		{
			return 0;
		}

		public void Clear()
		{
		}

		public bool Equals(JsonData data)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public JsonType GetJsonType()
		{
			return default(JsonType);
		}

		public void SetJsonType(JsonType type)
		{
		}

		public string ToJson()
		{
			return null;
		}

		public void ToJson(JsonWriter writer)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
