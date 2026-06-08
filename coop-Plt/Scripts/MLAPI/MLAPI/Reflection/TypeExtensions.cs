using System;

namespace MLAPI.Reflection
{
	internal static class TypeExtensions
	{
		internal static bool HasInterface(this Type type, Type interfaceType)
		{
			Type[] interfaces = type.GetInterfaces();
			for (int i = 0; i < interfaces.Length; i++)
			{
				if ((object)interfaces[i] == interfaceType)
				{
					return true;
				}
			}
			return false;
		}

		internal static bool IsNullable(this Type type)
		{
			if (!type.IsValueType)
			{
				return true;
			}
			if ((object)Nullable.GetUnderlyingType(type) != null)
			{
				return true;
			}
			return false;
		}
	}
}
