using System;

namespace Gh
{
	public struct ReferencableLookupKey : IEquatable<ReferencableLookupKey>
	{
		private int _intId;

		private string _stringId;

		public static implicit operator int(ReferencableLookupKey value)
		{
			return 0;
		}

		public static implicit operator ReferencableLookupKey(int value)
		{
			return default(ReferencableLookupKey);
		}

		public static implicit operator string(ReferencableLookupKey value)
		{
			return null;
		}

		public static implicit operator ReferencableLookupKey(string value)
		{
			return default(ReferencableLookupKey);
		}

		public bool IsEmpty()
		{
			return false;
		}

		public bool Equals(ReferencableLookupKey other)
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

		public string ToValueString()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
