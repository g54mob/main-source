using System.Collections.Generic;

namespace ParadoxNotion.Serialization.FullSerializer
{
	public sealed class fsData
	{
		private object _value;

		public static readonly fsData True;

		public static readonly fsData False;

		public static readonly fsData Null;

		public fsDataType Type => default(fsDataType);

		public bool IsNull => false;

		public bool IsDouble => false;

		public bool IsInt64 => false;

		public bool IsBool => false;

		public bool IsString => false;

		public bool IsDictionary => false;

		public bool IsList => false;

		public double AsDouble => 0.0;

		public long AsInt64 => 0L;

		public bool AsBool => false;

		public string AsString => null;

		public Dictionary<string, fsData> AsDictionary => null;

		public List<fsData> AsList => null;

		public fsData()
		{
		}

		public fsData(bool boolean)
		{
		}

		public fsData(double f)
		{
		}

		public fsData(long i)
		{
		}

		public fsData(string str)
		{
		}

		public fsData(Dictionary<string, fsData> dict)
		{
		}

		public fsData(List<fsData> list)
		{
		}

		public static fsData CreateDictionary()
		{
			return null;
		}

		public static fsData CreateList()
		{
			return null;
		}

		public static fsData CreateList(int capacity)
		{
			return null;
		}

		internal void BecomeDictionary()
		{
		}

		internal fsData Clone()
		{
			return null;
		}

		private T Cast<T>()
		{
			return default(T);
		}

		public override string ToString()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(fsData other)
		{
			return false;
		}

		public static bool operator ==(fsData a, fsData b)
		{
			return false;
		}

		public static bool operator !=(fsData a, fsData b)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
