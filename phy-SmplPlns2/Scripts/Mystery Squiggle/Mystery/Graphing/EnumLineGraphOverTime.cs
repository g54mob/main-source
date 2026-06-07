using System;

namespace Mystery.Graphing
{
	public class EnumLineGraphOverTime : IntegerLineGraphOverTime
	{
		private Type enumType;

		private EnumValueTransformer defaultValueYTransformer;

		public override ValueTransformer<long> ValueTransformerY
		{
			get
			{
				if (defaultValueYTransformer == null)
				{
					defaultValueYTransformer = new EnumValueTransformer(enumType);
				}
				return defaultValueYTransformer;
			}
		}

		public EnumLineGraphOverTime(Type type)
		{
			if (!type.IsEnum)
			{
				throw new ArgumentException("Type must be an Enum");
			}
			enumType = type;
		}
	}
}
