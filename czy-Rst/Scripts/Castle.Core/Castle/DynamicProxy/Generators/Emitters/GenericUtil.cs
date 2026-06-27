#define TRACE
using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Generators.Emitters
{
	internal class GenericUtil
	{
		public static GenericTypeParameterBuilder[] CopyGenericArguments(MethodInfo methodToCopyGenericsFrom, TypeBuilder builder)
		{
			return CopyGenericArguments(methodToCopyGenericsFrom, builder.DefineGenericParameters);
		}

		public static GenericTypeParameterBuilder[] CopyGenericArguments(MethodInfo methodToCopyGenericsFrom, MethodBuilder builder)
		{
			return CopyGenericArguments(methodToCopyGenericsFrom, builder.DefineGenericParameters);
		}

		private static Type AdjustConstraintToNewGenericParameters(Type constraint, MethodInfo methodToCopyGenericsFrom, Type[] originalGenericParameters, GenericTypeParameterBuilder[] newGenericParameters)
		{
			if (constraint.IsGenericType)
			{
				Type[] genericArguments = constraint.GetGenericArguments();
				for (int i = 0; i < genericArguments.Length; i++)
				{
					genericArguments[i] = AdjustConstraintToNewGenericParameters(genericArguments[i], methodToCopyGenericsFrom, originalGenericParameters, newGenericParameters);
				}
				return constraint.GetGenericTypeDefinition().MakeGenericType(genericArguments);
			}
			if (constraint.IsGenericParameter)
			{
				if (constraint.DeclaringMethod != null)
				{
					int num = Array.IndexOf(originalGenericParameters, constraint);
					Trace.Assert(num != -1, "When a generic method parameter has a constraint on another method parameter, both parameters must be declared on the same method.");
					return newGenericParameters[num];
				}
				Trace.Assert(constraint.DeclaringType.IsGenericTypeDefinition);
				Trace.Assert(methodToCopyGenericsFrom.DeclaringType.IsGenericType && constraint.DeclaringType == methodToCopyGenericsFrom.DeclaringType.GetGenericTypeDefinition(), "When a generic method parameter has a constraint on a generic type parameter, the generic type must be the declaring typer of the method.");
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

		private static GenericTypeParameterBuilder[] CopyGenericArguments(MethodInfo methodToCopyGenericsFrom, ApplyGenArgs genericParameterGenerator)
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
					GenericParameterAttributes genericParameterAttributes = genericArguments[i].GenericParameterAttributes;
					array[i].SetGenericParameterAttributes(genericParameterAttributes);
					Type[] interfaceConstraints = AdjustGenericConstraints(methodToCopyGenericsFrom, array, genericArguments, genericArguments[i].GetGenericParameterConstraints());
					array[i].SetInterfaceConstraints(interfaceConstraints);
					CopyNonInheritableAttributes(array[i], genericArguments[i]);
				}
				catch (NotSupportedException)
				{
					array[i].SetGenericParameterAttributes(GenericParameterAttributes.None);
				}
			}
			return array;
		}

		private static void CopyNonInheritableAttributes(GenericTypeParameterBuilder newGenericParameter, Type originalGenericArgument)
		{
			foreach (CustomAttributeInfo nonInheritableAttribute in originalGenericArgument.GetNonInheritableAttributes())
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
