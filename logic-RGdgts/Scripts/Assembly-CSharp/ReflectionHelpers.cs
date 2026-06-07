using System;
using System.Reflection;

public static class ReflectionHelpers
{
	public static Type[] GetAllDerivedTypes(this AppDomain aAppDomain, Type aType)
	{
		return null;
	}

	public static Type[] GetAllInterfaceTypes(this AppDomain aAppDomain, Type interfaceType)
	{
		return null;
	}

	public static Type[] GetAllImplementedTypesForInterface(this AppDomain aAppDomain, Type anInterface)
	{
		return null;
	}

	public static Type GetInterface(this Type type, Type interfaceType)
	{
		return null;
	}

	public static Tuple<Type, MethodInfo, ATTRIBUTE>[] GetAllMethodsWithAttribute<ATTRIBUTE>(this AppDomain aAppDomain) where ATTRIBUTE : Attribute
	{
		return null;
	}
}
