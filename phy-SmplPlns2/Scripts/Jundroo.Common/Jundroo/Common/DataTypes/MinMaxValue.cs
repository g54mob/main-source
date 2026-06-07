using System;
using System.Xml.Linq;

namespace Jundroo.Common.DataTypes
{
	[Serializable]
	public struct MinMaxValue
	{
		public float MaxValue;

		public float MinValue;

		public MinMaxValue(float min, float max)
		{
			MinValue = min;
			MaxValue = max;
		}

		public static explicit operator MinMaxValue(XAttribute attribute)
		{
			if (attribute == null)
			{
				throw new ArgumentNullException("attribute");
			}
			string value = attribute.Value;
			if (string.IsNullOrWhiteSpace(value))
			{
				return default(MinMaxValue);
			}
			int num = value.IndexOf(',');
			if (num == -1)
			{
				throw new FormatException("The expected format of the MinMaxValue should be \"float,float\"");
			}
			string value2 = value.Remove(num).Trim();
			string value3 = value.Substring(num + 1).Trim();
			return new MinMaxValue(DataIO.ParseFloat(value2), DataIO.ParseFloat(value3));
		}

		public static explicit operator MinMaxValue?(XAttribute attribute)
		{
			if (attribute == null)
			{
				return null;
			}
			string value = attribute.Value;
			if (string.IsNullOrWhiteSpace(value))
			{
				return null;
			}
			int num = value.IndexOf(',');
			if (num == -1)
			{
				throw new FormatException("The expected format of the MinMaxValue should be \"float,float\"");
			}
			string value2 = value.Remove(num).Trim();
			string value3 = value.Substring(num + 1).Trim();
			return new MinMaxValue(DataIO.ParseFloat(value2), DataIO.ParseFloat(value3));
		}

		public override string ToString()
		{
			return DataIO.ToString(MinValue) + "," + DataIO.ToString(MaxValue);
		}
	}
	[Serializable]
	public struct MinMaxValue<T> : IEquatable<MinMaxValue<T>> where T : struct, IEquatable<T>
	{
		public T MaxValue;

		public T MinValue;

		public MinMaxValue(T min, T max)
		{
			MinValue = min;
			MaxValue = max;
		}

		public static bool operator !=(MinMaxValue<T> lhs, MinMaxValue<T> rhs)
		{
			return !lhs.Equals(rhs);
		}

		public static bool operator ==(MinMaxValue<T> lhs, MinMaxValue<T> rhs)
		{
			return lhs.Equals(rhs);
		}

		public bool Equals(MinMaxValue<T> other)
		{
			if (MinValue.Equals(other.MinValue))
			{
				return MaxValue.Equals(other.MaxValue);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is MinMaxValue<T>))
			{
				return false;
			}
			return Equals((MinMaxValue<T>)obj);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(MinValue, MaxValue);
		}

		public override string ToString()
		{
			return $"({MinValue}, {MaxValue})";
		}
	}
}
