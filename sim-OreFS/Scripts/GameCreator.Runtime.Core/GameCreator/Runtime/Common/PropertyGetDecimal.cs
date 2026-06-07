using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class PropertyGetDecimal : TPropertyGet<PropertyTypeGetDecimal, double>
	{
		public PropertyGetDecimal()
			: base((PropertyTypeGetDecimal)new GetDecimalDecimal())
		{
		}

		public PropertyGetDecimal(PropertyTypeGetDecimal defaultType)
			: base(defaultType)
		{
		}

		public PropertyGetDecimal(double value)
			: base((PropertyTypeGetDecimal)new GetDecimalDecimal(value))
		{
		}

		public PropertyGetDecimal(float value)
			: base((PropertyTypeGetDecimal)new GetDecimalDecimal(value))
		{
		}
	}
}
