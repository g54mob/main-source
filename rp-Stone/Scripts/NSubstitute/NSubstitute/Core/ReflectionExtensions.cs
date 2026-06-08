using System;
using System.Linq;
using System.Reflection;

namespace NSubstitute.Core
{
	public static class ReflectionExtensions
	{
		public static PropertyInfo? GetPropertyFromSetterCallOrNull(this MethodInfo call)
		{
			if (!CanBePropertySetterCall(call))
			{
				return null;
			}
			PropertyInfo[] allProperties = GetAllProperties(call.DeclaringType);
			foreach (PropertyInfo propertyInfo in allProperties)
			{
				if (propertyInfo.GetSetMethod(nonPublic: true) == call)
				{
					return propertyInfo;
				}
			}
			return null;
		}

		public static PropertyInfo? GetPropertyFromGetterCallOrNull(this MethodInfo call)
		{
			return GetAllProperties(call.DeclaringType).FirstOrDefault((PropertyInfo x) => x.GetGetMethod(nonPublic: true) == call);
		}

		public static bool IsParams(this ParameterInfo parameterInfo)
		{
			return parameterInfo.IsDefined(typeof(ParamArrayAttribute), inherit: false);
		}

		private static bool CanBePropertySetterCall(MethodInfo call)
		{
			return call.Name.StartsWith("set_", StringComparison.Ordinal);
		}

		private static PropertyInfo[] GetAllProperties(Type? type)
		{
			if (!(type != null))
			{
				return new PropertyInfo[0];
			}
			return type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}
	}
}
