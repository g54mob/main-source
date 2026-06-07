using System;
using System.Xml.Linq;

namespace ModApi.Common
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
}
