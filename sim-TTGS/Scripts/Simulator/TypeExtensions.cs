using System;
using System.Linq;

public static class TypeExtensions
{
	public static bool InheritsOrImplements(this Type type, Type baseType)
	{
		type = ResolveGenericType(type);
		baseType = ResolveGenericType(baseType);
		while (type != typeof(object))
		{
			if (baseType == type || HasAnyInterfaces(type, baseType))
			{
				return true;
			}
			type = ResolveGenericType(type.BaseType);
			if (type == null)
			{
				return false;
			}
		}
		return false;
	}

	private static Type ResolveGenericType(Type type)
	{
		if ((object)type == null || !type.IsGenericType)
		{
			return type;
		}
		Type genericTypeDefinition = type.GetGenericTypeDefinition();
		if (!(genericTypeDefinition != type))
		{
			return type;
		}
		return genericTypeDefinition;
	}

	private static bool HasAnyInterfaces(Type type, Type interfaceType)
	{
		return type.GetInterfaces().Any((Type i) => ResolveGenericType(i) == interfaceType);
	}
}
