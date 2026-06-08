using System;
using System.Collections.Generic;
using System.Reflection;

namespace Castle.DynamicProxy.Generators
{
	internal class MethodSignatureComparer : IEqualityComparer<MethodInfo>
	{
		public static readonly MethodSignatureComparer Instance = new MethodSignatureComparer();

		private static readonly Type preserveBaseOverridesAttribute = Type.GetType("System.Runtime.CompilerServices.PreserveBaseOverridesAttribute", throwOnError: false);

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
					if (genericArguments[i].IsGenericParameter != genericArguments2[i].IsGenericParameter)
					{
						return false;
					}
					if (!genericArguments[i].IsGenericParameter && !genericArguments[i].Equals(genericArguments2[i]))
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

		public bool EqualReturnTypes(MethodInfo x, MethodInfo y)
		{
			Type returnType = x.ReturnType;
			Type returnType2 = y.ReturnType;
			if (EqualSignatureTypes(returnType, returnType2))
			{
				return true;
			}
			if (preserveBaseOverridesAttribute != null)
			{
				if (!x.IsDefined(preserveBaseOverridesAttribute, inherit: false) || !returnType2.IsAssignableFrom(returnType))
				{
					if (y.IsDefined(preserveBaseOverridesAttribute, inherit: false))
					{
						return returnType.IsAssignableFrom(returnType2);
					}
					return false;
				}
				return true;
			}
			return false;
		}

		private bool EqualSignatureTypes(Type x, Type y)
		{
			if (x.IsGenericParameter != y.IsGenericParameter)
			{
				return false;
			}
			if (x.IsGenericType != y.IsGenericType)
			{
				return false;
			}
			if (x.IsGenericParameter)
			{
				if (x.GenericParameterPosition != y.GenericParameterPosition)
				{
					return false;
				}
			}
			else if (x.IsGenericType)
			{
				Type genericTypeDefinition = x.GetGenericTypeDefinition();
				Type genericTypeDefinition2 = y.GetGenericTypeDefinition();
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
			if (EqualNames(x, y) && EqualGenericParameters(x, y) && EqualReturnTypes(x, y))
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
