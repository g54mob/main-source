using System;

namespace Mystery.Graphing
{
	public class EnumValueTransformer : LongValueTransformer
	{
		private Type enumType;

		public EnumValueTransformer(Type type)
		{
			if (!type.IsEnum)
			{
				throw new ArgumentException("Type must be an Enum");
			}
			enumType = type;
		}

		public override string ToString(long yValue)
		{
			return Enum.ToObject(enumType, yValue).ToString();
		}

		public override object Parse(string value, object fallback)
		{
			try
			{
				return Convert.ToInt64(Enum.Parse(enumType, value));
			}
			catch
			{
				return fallback;
			}
		}
	}
}
