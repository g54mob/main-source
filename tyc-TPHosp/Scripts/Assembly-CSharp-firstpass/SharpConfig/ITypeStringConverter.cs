using System;

namespace SharpConfig
{
	public interface ITypeStringConverter
	{
		Type ConvertibleType { get; }

		string ConvertToString(object value);

		object ConvertFromString(string value, Type hint);
	}
}
