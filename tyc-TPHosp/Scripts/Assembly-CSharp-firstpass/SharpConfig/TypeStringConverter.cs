using System;

namespace SharpConfig
{
	public abstract class TypeStringConverter<T> : ITypeStringConverter
	{
		public Type ConvertibleType => typeof(T);

		public abstract string ConvertToString(object value);

		public abstract object ConvertFromString(string value, Type hint);
	}
}
