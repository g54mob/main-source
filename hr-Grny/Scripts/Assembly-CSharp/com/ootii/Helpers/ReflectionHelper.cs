using System;
using System.Reflection;

namespace com.ootii.Helpers
{
	public class ReflectionHelper
	{
		public static bool IsSubclassOf(Type rType, Type rBaseType)
		{
			return false;
		}

		public static bool IsAssignableFrom(Type rType, Type rDerivedType)
		{
			return false;
		}

		public static T GetAttribute<T>(Type rObjectType)
		{
			return default(T);
		}

		public static T[] GetAttributes<T>(Type rObjectType)
		{
			return null;
		}

		public static bool IsDefined(Type rObjectType, Type rType)
		{
			return false;
		}

		public static bool IsDefined(FieldInfo rFieldInfo, Type rType)
		{
			return false;
		}

		public static bool IsDefined(MemberInfo rMemberInfo, Type rType)
		{
			return false;
		}

		public static bool IsDefined(PropertyInfo rPropertyInfo, Type rType)
		{
			return false;
		}

		public static void SetProperty(object rObject, string rName, object rValue)
		{
		}

		public static bool IsTypeValid(string rType)
		{
			return false;
		}

		public static bool IsPrimitive(Type rType)
		{
			return false;
		}

		public static bool IsValueType(Type rType)
		{
			return false;
		}

		public static bool IsGenericType(Type rType)
		{
			return false;
		}

		public static object GetDefaultValue(Type rType)
		{
			return null;
		}
	}
}
