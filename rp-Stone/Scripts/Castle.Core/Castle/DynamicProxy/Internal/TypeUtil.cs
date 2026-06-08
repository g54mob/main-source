using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Generators.Emitters;

namespace Castle.DynamicProxy.Internal
{
	public static class TypeUtil
	{
		private sealed class TypeNameComparer : IComparer<Type>
		{
			public static readonly TypeNameComparer Instance = new TypeNameComparer();

			public int Compare(Type x, Type y)
			{
				int num = string.CompareOrdinal(x.FullName, y.FullName);
				if (num == 0)
				{
					return string.CompareOrdinal(x.GetTypeInfo().Assembly.FullName, y.GetTypeInfo().Assembly.FullName);
				}
				return num;
			}
		}

		public static bool IsNullableType(this Type type)
		{
			if (type.GetTypeInfo().IsGenericType)
			{
				return type.GetGenericTypeDefinition() == typeof(Nullable<>);
			}
			return false;
		}

		public static FieldInfo[] GetAllFields(this Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (!type.GetTypeInfo().IsClass)
			{
				throw new ArgumentException($"Type {type} is not a class type. This method supports only classes");
			}
			List<FieldInfo> list = new List<FieldInfo>();
			Type type2 = type;
			while (type2 != typeof(object))
			{
				FieldInfo[] fields = type2.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				list.AddRange(fields);
				type2 = type2.GetTypeInfo().BaseType;
			}
			return list.ToArray();
		}

		public static Type[] GetAllInterfaces(params Type[] types)
		{
			if (types == null)
			{
				return Type.EmptyTypes;
			}
			HashSet<Type> hashSet = new HashSet<Type>();
			foreach (Type type in types)
			{
				if (!(type == null) && (!type.GetTypeInfo().IsInterface || hashSet.Add(type)))
				{
					Type[] interfaces = type.GetInterfaces();
					foreach (Type item in interfaces)
					{
						hashSet.Add(item);
					}
				}
			}
			return Sort(hashSet);
		}

		public static Type[] GetAllInterfaces(this Type type)
		{
			return GetAllInterfaces(new Type[1] { type });
		}

		public static Type GetClosedParameterType(this AbstractTypeEmitter type, Type parameter)
		{
			if (parameter.GetTypeInfo().IsGenericTypeDefinition)
			{
				return parameter.GetGenericTypeDefinition().MakeGenericType(type.GetGenericArgumentsFor(parameter));
			}
			if (parameter.GetTypeInfo().IsGenericType)
			{
				Type[] genericArguments = parameter.GetGenericArguments();
				if (CloseGenericParametersIfAny(type, genericArguments))
				{
					return parameter.GetGenericTypeDefinition().MakeGenericType(genericArguments);
				}
			}
			if (parameter.GetTypeInfo().IsGenericParameter)
			{
				return type.GetGenericArgument(parameter.Name);
			}
			if (parameter.GetTypeInfo().IsArray)
			{
				Type closedParameterType = type.GetClosedParameterType(parameter.GetElementType());
				int arrayRank = parameter.GetArrayRank();
				if (arrayRank != 1)
				{
					return closedParameterType.MakeArrayType(arrayRank);
				}
				return closedParameterType.MakeArrayType();
			}
			if (parameter.GetTypeInfo().IsByRef)
			{
				return type.GetClosedParameterType(parameter.GetElementType()).MakeByRefType();
			}
			return parameter;
		}

		public static Type GetTypeOrNull(object target)
		{
			return target?.GetType();
		}

		public static Type[] AsTypeArray(this GenericTypeParameterBuilder[] typeInfos)
		{
			Type[] array = new Type[typeInfos.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = typeInfos[i].AsType();
			}
			return array;
		}

		public static bool IsFinalizer(this MethodInfo methodInfo)
		{
			if (string.Equals("Finalize", methodInfo.Name))
			{
				return methodInfo.GetBaseDefinition().DeclaringType == typeof(object);
			}
			return false;
		}

		public static bool IsGetType(this MethodInfo methodInfo)
		{
			if (methodInfo.DeclaringType == typeof(object))
			{
				return string.Equals("GetType", methodInfo.Name, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		public static bool IsMemberwiseClone(this MethodInfo methodInfo)
		{
			if (methodInfo.DeclaringType == typeof(object))
			{
				return string.Equals("MemberwiseClone", methodInfo.Name, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		public static void SetStaticField(this Type type, string fieldName, BindingFlags additionalFlags, object value)
		{
			BindingFlags bindingAttr = additionalFlags | BindingFlags.Static;
			FieldInfo field = type.GetField(fieldName, bindingAttr);
			if (field == null)
			{
				throw new ProxyGenerationException($"Could not find field named '{fieldName}' on type {type}. This is likely a bug in DynamicProxy. Please report it.");
			}
			try
			{
				field.SetValue(null, value);
			}
			catch (MissingFieldException innerException)
			{
				throw new ProxyGenerationException($"Could not find field named '{fieldName}' on type {type}. This is likely a bug in DynamicProxy. Please report it.", innerException);
			}
			catch (TargetException innerException2)
			{
				throw new ProxyGenerationException($"There was an error trying to set field named '{fieldName}' on type {type}. This is likely a bug in DynamicProxy. Please report it.", innerException2);
			}
			catch (TargetInvocationException ex)
			{
				if (!(ex.InnerException is TypeInitializationException))
				{
					throw;
				}
				throw new ProxyGenerationException($"There was an error in static constructor on type {type}. This is likely a bug in DynamicProxy. Please report it.", ex);
			}
		}

		public static MemberInfo[] Sort(MemberInfo[] members)
		{
			MemberInfo[] array = new MemberInfo[members.Length];
			Array.Copy(members, array, members.Length);
			Array.Sort(array, (MemberInfo l, MemberInfo r) => string.Compare(l.Name, r.Name, StringComparison.OrdinalIgnoreCase));
			return array;
		}

		internal static bool IsDelegateType(this Type type)
		{
			return type.GetTypeInfo().BaseType == typeof(MulticastDelegate);
		}

		private static bool CloseGenericParametersIfAny(AbstractTypeEmitter emitter, Type[] arguments)
		{
			bool result = false;
			for (int i = 0; i < arguments.Length; i++)
			{
				Type closedParameterType = emitter.GetClosedParameterType(arguments[i]);
				if (closedParameterType != null && (object)closedParameterType != arguments[i])
				{
					arguments[i] = closedParameterType;
					result = true;
				}
			}
			return result;
		}

		private static Type[] Sort(ICollection<Type> types)
		{
			Type[] array = new Type[types.Count];
			types.CopyTo(array, 0);
			Array.Sort(array, TypeNameComparer.Instance);
			return array;
		}
	}
}
