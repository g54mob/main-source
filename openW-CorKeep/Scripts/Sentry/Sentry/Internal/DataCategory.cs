using System;

namespace Sentry.Internal
{
	internal readonly struct DataCategory : IEnumeration<DataCategory>, IEquatable<DataCategory>, IComparable<DataCategory>, IEnumeration, IComparable
	{
		public static DataCategory Attachment = new DataCategory("attachment");

		public static DataCategory Default = new DataCategory("default");

		public static DataCategory Error = new DataCategory("error");

		public static DataCategory Internal = new DataCategory("internal");

		public static DataCategory Security = new DataCategory("security");

		public static DataCategory Session = new DataCategory("session");

		public static DataCategory Span = new DataCategory("span");

		public static DataCategory Transaction = new DataCategory("transaction");

		public static DataCategory Profile = new DataCategory("profile");

		private readonly string _value;

		string IEnumeration.Value => _value;

		public DataCategory(string value)
		{
			_value = value;
		}

		public int CompareTo(DataCategory other)
		{
			return string.Compare(_value, other._value, StringComparison.Ordinal);
		}

		public int CompareTo(object? obj)
		{
			if (obj == null)
			{
				return 1;
			}
			if (!(obj is DataCategory other))
			{
				throw new ArgumentException("Object must be of type DataCategory");
			}
			return CompareTo(other);
		}

		public bool Equals(DataCategory other)
		{
			return _value == other._value;
		}

		public override bool Equals(object? obj)
		{
			if (obj is DataCategory other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return _value.GetHashCode();
		}

		public override string ToString()
		{
			return _value;
		}
	}
}
