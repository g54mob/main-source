using System;

namespace SharpConfig
{
	internal sealed class FallbackStringConverter : ITypeStringConverter
	{
		public Type ConvertibleType => null;

		public string ConvertToString(object value)
		{
			return value.ToString();
		}

		public object ConvertFromString(string value, Type hint)
		{
			throw new NotImplementedException();
		}
	}
}
