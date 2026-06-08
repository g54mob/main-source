#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Generators.Emitters
{
	internal class GenericUtil
	{
		public static GenericTypeParameterBuilder[] CopyGenericArguments(MethodInfo methodToCopyGenericsFrom, TypeBuilder builder, Dictionary<string, GenericTypeParameterBuilder> name2GenericType)
		{
			return CopyGenericArguments(methodToCopyGenericsFrom, name2GenericType, builder.DefineGenericParameters);
		}

		public static GenericTypeParameterBuilder[] CopyGenericArguments(MethodInfo methodToCopyGenericsFrom, MethodBuilder builder, Dictionary<string, GenericTypeParameterBuilder> name2GenericType)
		{
			return CopyGenericArguments(methodToCopyGenericsFrom, name2GenericType, builder.DefineGenericParameters);
		}

		public static Type ExtractCorrectType(Type paramType, Dictionary<string, GenericTypeParameterBuilder> name2GenericType)
		{
			if (paramType.GetTypeInfo().IsArray)
			{
				int arrayRank = paramType.GetArrayRank();
				Type elementType = paramType.GetElementType();
				if (elementType.GetTypeInfo().IsGenericParameter)
				{
					if (!name2GenericType.TryGetValue(elementType.Name, out var value))
					{
						return paramType;
					}
					if (arrayRank == 1)
					{
						return value.MakeArrayType();
					}
					return value.MakeArrayType(arrayRank);
				}
				if (arrayRank == 1)
				{
					return elementType.MakeArrayType();
				}
				return elementType.MakeArrayType(arrayRank);
			}
			if (paramType.GetTypeInfo().IsGenericParameter && name2GenericType.TryGetValue(paramType.Name, out var value2))
			{
				return value2.AsType();
			}
			return paramType;
		}

		public static Type[] ExtractParametersTypes(ParameterInfo[] baseMethodParameters, Dictionary<string, GenericTypeParameterBuilder> name2GenericType)
		{
			Type[] array = new Type[baseMethodParameters.Length];
			for (int i = 0; i < baseMethodParameters.Length; i++)
			{
				Type parameterType = baseMethodParameters[i].ParameterType;
				array[i] = ExtractCorrectType(parameterType, name2GenericType);
			}
			return array;
		}

		public static Dictionary<string, GenericTypeParameterBuilder> GetGenericArgumentsMap(AbstractTypeEmitter parentEmitter)
		{
			if (parentEmitter.GenericTypeParams == null || parentEmitter.GenericTypeParams.Length == 0)
			{
				return new Dictionary<string, GenericTypeParameterBuilder>(0);
			}
			Dictionary<string, GenericTypeParameterBuilder> dictionary = new Dictionary<string, GenericTypeParameterBuilder>(parentEmitter.GenericTypeParams.Length);
			GenericTypeParameterBuilder[] genericTypeParams = parentEmitter.GenericTypeParams;
			foreach (GenericTypeParameterBuilder genericTypeParameterBuilder in genericTypeParams)
			{
				dictionary.Add(genericTypeParameterBuilder.Name, genericTypeParameterBuilder);
			}
			return dictionary;
		}

		private static Type AdjustConstraintToNewGenericParameters(Type constraint, MethodInfo methodToCopyGenericsFrom, Type[] originalGenericParameters, GenericTypeParameterBuilder[] newGenericParameters)
		{
			if (constraint.GetTypeInfo().IsGenericType)
			{
				Type[] genericArguments = constraint.GetGenericArguments();
				for (int i = 0; i < genericArguments.Length; i++)
				{
					genericArguments[i] = AdjustConstraintToNewGenericParameters(genericArguments[i], methodToCopyGenericsFrom, originalGenericParameters, newGenericParameters);
				}
				return constraint.GetGenericTypeDefinition().MakeGenericType(genericArguments);
			}
			if (constraint.GetTypeInfo().IsGenericParameter)
			{
				if (constraint.GetTypeInfo().DeclaringMethod != null)
				{
					int num = Array.IndexOf(originalGenericParameters, constraint);
					Trace.Assert(num != -1, "When a generic method parameter has a constraint on another method parameter, both parameters must be declared on the same method.");
					return newGenericParameters[num].AsType();
				}
				Trace.Assert(constraint.DeclaringType.GetTypeInfo().IsGenericTypeDefinition);
				Trace.Assert(methodToCopyGenericsFrom.DeclaringType.GetTypeInfo().IsGenericType && constraint.DeclaringType == methodToCopyGenericsFrom.DeclaringType.GetGenericTypeDefinition(), "When a generic method parameter has a constraint on a generic type parameter, the generic type must be the declaring typer of the method.");
				int num2 = Array.IndexOf(constraint.DeclaringType.GetGenericArguments(), constraint);
				Trace.Assert(num2 != -1, "The generic parameter comes from the given type.");
				return methodToCopyGenericsFrom.DeclaringType.GetGenericArguments()[num2];
			}
			return constraint;
		}

		private static Type[] AdjustGenericConstraints(MethodInfo methodToCopyGenericsFrom, GenericTypeParameterBuilder[] newGenericParameters, Type[] originalGenericArguments, Type[] constraints)
		{
			Type[] array = new Type[constraints.Length];
			for (int i = 0; i < constraints.Length; i++)
			{
				array[i] = AdjustConstraintToNewGenericParameters(constraints[i], methodToCopyGenericsFrom, originalGenericArguments, newGenericParameters);
			}
			return array;
		}

		private static GenericTypeParameterBuilder[] CopyGenericArguments(MethodInfo methodToCopyGenericsFrom, Dictionary<string, GenericTypeParameterBuilder> name2GenericType, ApplyGenArgs genericParameterGenerator)
		{
			Type[] genericArguments = methodToCopyGenericsFrom.GetGenericArguments();
			if (genericArguments.Length == 0)
			{
				return null;
			}
			string[] argumentNames = GetArgumentNames(genericArguments);
			GenericTypeParameterBuilder[] array = genericParameterGenerator(argumentNames);
			for (int i = 0; i < array.Length; i++)
			{
				try
				{
					GenericParameterAttributes genericParameterAttributes = genericArguments[i].GetTypeInfo().GenericParameterAttributes;
					array[i].SetGenericParameterAttributes(genericParameterAttributes);
					Type[] interfaceConstraints = AdjustGenericConstraints(methodToCopyGenericsFrom, array, genericArguments, genericArguments[i].GetTypeInfo().GetGenericParameterConstraints());
					array[i].SetInterfaceConstraints(interfaceConstraints);
					CopyNonInheritableAttributes(array[i], genericArguments[i]);
				}
				catch (NotSupportedException)
				{
					array[i].SetGenericParameterAttributes(GenericParameterAttributes.None);
				}
				name2GenericType[argumentNames[i]] = array[i];
			}
			return array;
		}

		private static void CopyNonInheritableAttributes(GenericTypeParameterBuilder newGenericParameter, Type originalGenericArgument)
		{
			foreach (CustomAttributeInfo nonInheritableAttribute in originalGenericArgument.GetTypeInfo().GetNonInheritableAttributes())
			{
				newGenericParameter.SetCustomAttribute(nonInheritableAttribute.Builder);
			}
		}

		private static string[] GetArgumentNames(Type[] originalGenericArguments)
		{
			string[] array = new string[originalGenericArguments.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = originalGenericArguments[i].Name;
			}
			return array;
		}
	}
}
