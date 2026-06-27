using System;

namespace Reflectify
{
	internal static class TypeExtensions
	{
		public static Type NullableOrActualType(this Type type)
		{
			if (type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				type = type.GetGenericArguments()[0];
			}
			return type;
		}
	}
}
