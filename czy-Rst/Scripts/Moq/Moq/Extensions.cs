using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Moq
{
	internal static class Extensions
	{
		private static readonly ConcurrentDictionary<Tuple<Type, Type>, InterfaceMapping> mappingsCache = new ConcurrentDictionary<Tuple<Type, Type>, InterfaceMapping>();

		public static bool CanCreateInstance(this Type type)
		{
			if (!type.IsValueType)
			{
				return type.GetConstructor(Type.EmptyTypes) != null;
			}
			return true;
		}

		public static bool CanRead(this PropertyInfo property, out MethodInfo getter)
		{
			PropertyInfo getterProperty;
			return property.CanRead(out getter, out getterProperty);
		}

		public static bool CanRead(this PropertyInfo property, out MethodInfo getter, out PropertyInfo getterProperty)
		{
			if (property.CanRead)
			{
				getter = property.GetGetMethod(nonPublic: true);
				getterProperty = property;
				return true;
			}
			MethodInfo setMethod = property.GetSetMethod(nonPublic: true);
			MethodInfo baseSetter = setMethod.GetBaseDefinition();
			if (baseSetter != setMethod)
			{
				PropertyInfo property2 = baseSetter.DeclaringType.GetMember(property.Name, MemberTypes.Property, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Cast<PropertyInfo>().First((PropertyInfo p) => p.GetSetMethod(nonPublic: true) == baseSetter);
				return property2.CanRead(out getter, out getterProperty);
			}
			getter = null;
			getterProperty = null;
			return false;
		}

		public static bool CanWrite(this PropertyInfo property, out MethodInfo setter)
		{
			PropertyInfo setterProperty;
			return property.CanWrite(out setter, out setterProperty);
		}

		public static bool CanWrite(this PropertyInfo property, out MethodInfo setter, out PropertyInfo setterProperty)
		{
			if (property.CanWrite)
			{
				setter = property.GetSetMethod(nonPublic: true);
				setterProperty = property;
				return true;
			}
			MethodInfo getMethod = property.GetGetMethod(nonPublic: true);
			MethodInfo baseGetter = getMethod.GetBaseDefinition();
			if (baseGetter != getMethod)
			{
				PropertyInfo property2 = baseGetter.DeclaringType.GetMember(property.Name, MemberTypes.Property, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Cast<PropertyInfo>().First((PropertyInfo p) => p.GetGetMethod(nonPublic: true) == baseGetter);
				return property2.CanWrite(out setter, out setterProperty);
			}
			setter = null;
			setterProperty = null;
			return false;
		}

		public static object GetDefaultValue(this Type type)
		{
			if (!type.IsValueType)
			{
				return null;
			}
			return Activator.CreateInstance(type);
		}

		public static MethodInfo GetImplementingMethod(this MethodInfo method, Type proxyType)
		{
			if (method.IsGenericMethod)
			{
				method = method.GetGenericMethodDefinition();
			}
			Type declaringType = method.DeclaringType;
			if (declaringType.IsInterface)
			{
				InterfaceMapping interfaceMap = GetInterfaceMap(proxyType, method.DeclaringType);
				int num = Array.IndexOf<MethodInfo>(interfaceMap.InterfaceMethods, method);
				return interfaceMap.TargetMethods[num].GetBaseDefinition();
			}
			if (declaringType.IsDelegateType())
			{
				return proxyType.GetMethod("Invoke");
			}
			return method.GetBaseDefinition();
		}

		public static object InvokePreserveStack(this Delegate del, IReadOnlyList<object> args = null)
		{
			try
			{
				return del.DynamicInvoke((args as object[]) ?? args?.ToArray());
			}
			catch (TargetInvocationException ex)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
				throw;
			}
		}

		public static bool IsExtensionMethod(this MethodInfo method)
		{
			if (method.IsStatic)
			{
				return method.IsDefined(typeof(ExtensionAttribute));
			}
			return false;
		}

		public static bool IsGetAccessor(this MethodInfo method)
		{
			if (method.IsSpecialName)
			{
				return method.Name.StartsWith("get_", StringComparison.Ordinal);
			}
			return false;
		}

		public static bool IsSetAccessor(this MethodInfo method)
		{
			if (method.IsSpecialName)
			{
				return method.Name.StartsWith("set_", StringComparison.Ordinal);
			}
			return false;
		}

		public static bool IsIndexerAccessor(this MethodInfo method)
		{
			int num = method.GetParameters().Length;
			if (!method.IsGetAccessor() || num <= 0)
			{
				if (method.IsSetAccessor())
				{
					return num > 1;
				}
				return false;
			}
			return true;
		}

		public static bool IsPropertyAccessor(this MethodInfo method)
		{
			int num = method.GetParameters().Length;
			if (!method.IsGetAccessor() || num != 0)
			{
				if (method.IsSetAccessor())
				{
					return num == 1;
				}
				return false;
			}
			return true;
		}

		public static bool IsEventAddAccessor(this MethodInfo method)
		{
			return method.Name.StartsWith("add_", StringComparison.Ordinal);
		}

		public static bool IsEventRemoveAccessor(this MethodInfo method)
		{
			return method.Name.StartsWith("remove_", StringComparison.Ordinal);
		}

		public static bool IsDelegateType(this Type type)
		{
			return type.BaseType == typeof(MulticastDelegate);
		}

		public static bool IsMockable(this Type type)
		{
			if (type.IsSealed)
			{
				return type.IsDelegateType();
			}
			return true;
		}

		public static bool IsTypeMatcher(this Type type)
		{
			return Attribute.IsDefined(type, typeof(TypeMatcherAttribute));
		}

		public static bool IsTypeMatcher(this Type type, out Type typeMatcherType)
		{
			if (type.IsTypeMatcher())
			{
				TypeMatcherAttribute typeMatcherAttribute = (TypeMatcherAttribute)Attribute.GetCustomAttribute(type, typeof(TypeMatcherAttribute));
				typeMatcherType = typeMatcherAttribute.Type ?? type;
				Guard.ImplementsTypeMatcherProtocol(typeMatcherType);
				return true;
			}
			typeMatcherType = null;
			return false;
		}

		public static bool IsOrContainsTypeMatcher(this Type type)
		{
			if (type.IsTypeMatcher())
			{
				return true;
			}
			if (type.HasElementType)
			{
				return type.GetElementType().IsOrContainsTypeMatcher();
			}
			if (type.IsGenericType)
			{
				return type.GetGenericArguments().Any(IsOrContainsTypeMatcher);
			}
			return false;
		}

		public static bool ImplementsTypeMatcherProtocol(this Type type)
		{
			if (typeof(ITypeMatcher).IsAssignableFrom(type))
			{
				return type.CanCreateInstance();
			}
			return false;
		}

		public static bool CanOverride(this MethodBase method)
		{
			if (method.IsVirtual && !method.IsFinal)
			{
				return !method.IsPrivate;
			}
			return false;
		}

		public static bool CanOverrideGet(this PropertyInfo property)
		{
			if (property.CanRead(out MethodInfo getter))
			{
				return getter.CanOverride();
			}
			return false;
		}

		public static bool CanOverrideSet(this PropertyInfo property)
		{
			if (property.CanWrite(out MethodInfo setter))
			{
				return setter.CanOverride();
			}
			return false;
		}

		public static IEnumerable<MethodInfo> GetMethods(this Type type, string name)
		{
			return type.GetMember(name).OfType<MethodInfo>();
		}

		public static bool CompareTo<TTypes, TOtherTypes>(this TTypes types, TOtherTypes otherTypes, bool exact, bool considerTypeMatchers) where TTypes : IReadOnlyList<Type> where TOtherTypes : IReadOnlyList<Type>
		{
			int count = otherTypes.Count;
			if (types.Count != count)
			{
				return false;
			}
			for (int i = 0; i < count; i++)
			{
				Type type = types[i];
				if (considerTypeMatchers && type.IsOrContainsTypeMatcher())
				{
					type = type.SubstituteTypeMatchers(otherTypes[i]);
				}
				if (exact)
				{
					if (!type.Equals(otherTypes[i]))
					{
						return false;
					}
				}
				else if (!type.IsAssignableFrom(otherTypes[i]))
				{
					return false;
				}
			}
			return true;
		}

		public static string GetParameterTypeList(this MethodInfo method)
		{
			return new StringBuilder().AppendCommaSeparated(method.GetParameters(), StringBuilderExtensions.AppendParameterType).ToString();
		}

		public static ParameterTypes GetParameterTypes(this MethodInfo method)
		{
			return new ParameterTypes(method.GetParameters());
		}

		public static bool CompareParameterTypesTo<TOtherTypes>(this Delegate function, TOtherTypes otherTypes) where TOtherTypes : IReadOnlyList<Type>
		{
			MethodInfo methodInfo = function.GetMethodInfo();
			if (methodInfo.GetParameterTypes().CompareTo(otherTypes, exact: false, considerTypeMatchers: false))
			{
				return true;
			}
			MethodInfo invokeMethodFromUntypedDelegateCallback = GetInvokeMethodFromUntypedDelegateCallback(function);
			if (invokeMethodFromUntypedDelegateCallback != null && invokeMethodFromUntypedDelegateCallback.GetParameterTypes().CompareTo(otherTypes, exact: false, considerTypeMatchers: false))
			{
				return true;
			}
			return false;
		}

		private static MethodInfo GetInvokeMethodFromUntypedDelegateCallback(Delegate callback)
		{
			try
			{
				return callback.GetType().GetMethod("Invoke", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			}
			catch (AmbiguousMatchException)
			{
				return null;
			}
		}

		public static Type SubstituteTypeMatchers(this Type type, Type other)
		{
			if (type.IsTypeMatcher(out Type typeMatcherType))
			{
				ITypeMatcher typeMatcher = (ITypeMatcher)Activator.CreateInstance(typeMatcherType);
				if (typeMatcher.Matches(other))
				{
					return other;
				}
			}
			else if (type.HasElementType && other.HasElementType)
			{
				Type elementType = type.GetElementType();
				Type elementType2 = other.GetElementType();
				if (type.IsArray && other.IsArray)
				{
					int arrayRank = type.GetArrayRank();
					int arrayRank2 = other.GetArrayRank();
					if (arrayRank == arrayRank2)
					{
						Type type2 = elementType.SubstituteTypeMatchers(elementType2);
						if (type2.Equals(elementType))
						{
							return type;
						}
						if (arrayRank != 1)
						{
							return type2.MakeArrayType(arrayRank);
						}
						return type2.MakeArrayType();
					}
				}
				else
				{
					if (type.IsByRef && other.IsByRef)
					{
						Type type3 = elementType.SubstituteTypeMatchers(elementType2);
						if (!(type3 == elementType))
						{
							return type3.MakeByRefType();
						}
						return type;
					}
					if (type.IsPointer && other.IsPointer)
					{
						Type type4 = elementType.SubstituteTypeMatchers(elementType2);
						if (!(type4 == elementType))
						{
							return type4.MakePointerType();
						}
						return type;
					}
				}
			}
			else if (type.IsGenericType && other.IsGenericType)
			{
				Type genericTypeDefinition = type.GetGenericTypeDefinition();
				Type genericTypeDefinition2 = other.GetGenericTypeDefinition();
				if (genericTypeDefinition.Equals(genericTypeDefinition2))
				{
					Type[] genericArguments = type.GetGenericArguments();
					Type[] genericArguments2 = other.GetGenericArguments();
					bool flag = false;
					for (int i = 0; i < genericArguments.Length; i++)
					{
						Type type5 = genericArguments[i].SubstituteTypeMatchers(genericArguments2[i]);
						if (!type5.Equals(genericArguments[i]))
						{
							flag = true;
							genericArguments[i] = type5;
						}
					}
					if (!flag)
					{
						return type;
					}
					return genericTypeDefinition.MakeGenericType(genericArguments);
				}
			}
			return type;
		}

		private static InterfaceMapping GetInterfaceMap(Type type, Type interfaceType)
		{
			return mappingsCache.GetOrAdd(Tuple.Create(type, interfaceType), (Tuple<Type, Type> tuple) => tuple.Item1.GetInterfaceMap(tuple.Item2));
		}

		public static IEnumerable<Mock> FindAllInnerMocks(this SetupCollection setups)
		{
			return from innerMock in setups.FindAll((Setup setup) => !setup.IsConditional).SelectMany((Setup setup) => setup.InnerMocks)
				where innerMock != null
				select innerMock;
		}

		public static Mock FindLastInnerMock(this SetupCollection setups, Func<Setup, bool> predicate)
		{
			return setups.FindLast((Setup setup) => !setup.IsConditional && predicate(setup))?.InnerMocks.SingleOrDefault();
		}
	}
}
