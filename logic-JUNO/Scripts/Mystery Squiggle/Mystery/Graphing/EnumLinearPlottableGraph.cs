using System;

namespace Mystery.Graphing
{
	public class EnumLinearPlottableGraph : IntegerLinearPlottableGraph
	{
		private Type enumType;

		public EnumLinearPlottableGraph(Type type)
		{
			if (!type.IsEnum)
			{
				throw new ArgumentException("Type must be an Enum");
			}
			enumType = type;
		}

		public override string YToString(long yValue)
		{
			return Enum.ToObject(enumType, yValue).ToString();
		}

		public override object ParseY(string value, object fallback)
		{
			return Enum.Parse(enumType, value);
		}
	}
}
