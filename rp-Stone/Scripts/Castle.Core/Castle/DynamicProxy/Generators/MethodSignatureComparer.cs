using System;
using System.Collections.Generic;
using System.Reflection;

namespace Castle.DynamicProxy.Generators
{
	public class MethodSignatureComparer : IEqualityComparer<MethodInfo>
	{
		public static readonly MethodSignatureComparer Instance = new MethodSignatureComparer();

		public bool EqualGenericParameters(MethodInfo x, MethodInfo y)
		{
			if (x.IsGenericMethod != y.IsGenericMethod)
			{
				return false;
			}
			if (x.IsGenericMethod)
			{
				Type[] genericArguments = x.GetGenericArguments();
				Type[] genericArguments2 = y.GetGenericArguments();
				if (genericArguments.Length != genericArguments2.Length)
				{
					return false;
				}
				for (int i = 0; i < genericArguments.Length; i++)
				{
					if (genericArguments[i].GetTypeInfo().IsGenericParameter != genericArguments2[i].GetTypeInfo().IsGenericParameter)
					{
						return false;
					}
					if (!genericArguments[i].GetTypeInfo().IsGenericParameter && !genericArguments[i].Equals(genericArguments2[i]))
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool EqualParameters(MethodInfo x, MethodInfo y)
		{
			ParameterInfo[] parameters = x.GetParameters();
			ParameterInfo[] parameters2 = y.GetParameters();
			if (parameters.Length != parameters2.Length)
			{
				return false;
			}
			for (int i = 0; i < parameters.Length; i++)
			{
				if (!EqualSignatureTypes(parameters[i].ParameterType, parameters2[i].ParameterType))
				{
					return false;
				}
			}
			return true;
		}

		public bool EqualSignatureTypes(Type x, Type y)
		{
			TypeInfo typeInfo = x.GetTypeInfo();
			TypeInfo typeInfo2 = y.GetTypeInfo();
			if (typeInfo.IsGenericParameter != typeInfo2.IsGenericParameter)
			{
				return false;
			}
			if (typeInfo.IsGenericType != typeInfo2.IsGenericType)
			{
				return false;
			}
			if (typeInfo.IsGenericParameter)
			{
				if (typeInfo.GenericParameterPosition != typeInfo2.GenericParameterPosition)
				{
					return false;
				}
			}
			else if (typeInfo.IsGenericType)
			{
				Type genericTypeDefinition = typeInfo.GetGenericTypeDefinition();
				Type genericTypeDefinition2 = typeInfo2.GetGenericTypeDefinition();
				if (genericTypeDefinition != genericTypeDefinition2)
				{
					return false;
				}
				Type[] genericArguments = x.GetGenericArguments();
				Type[] genericArguments2 = y.GetGenericArguments();
				if (genericArguments.Length != genericArguments2.Length)
				{
					return false;
				}
				for (int i = 0; i < genericArguments.Length; i++)
				{
					if (!EqualSignatureTypes(genericArguments[i], genericArguments2[i]))
					{
						return false;
					}
				}
			}
			else if (!x.Equals(y))
			{
				return false;
			}
			return true;
		}

		public bool Equals(MethodInfo x, MethodInfo y)
		{
			if (x == null && y == null)
			{
				return true;
			}
			if (x == null || y == null)
			{
				return false;
			}
			if (EqualNames(x, y) && EqualGenericParameters(x, y) && EqualSignatureTypes(x.ReturnType, y.ReturnType))
			{
				return EqualParameters(x, y);
			}
			return false;
		}

		public int GetHashCode(MethodInfo obj)
		{
			return obj.Name.GetHashCode() ^ obj.GetParameters().Length;
		}

		private bool EqualNames(MethodInfo x, MethodInfo y)
		{
			return x.Name == y.Name;
		}
	}
}
