using System;
using System.Reflection;

namespace Mandragora.Utils
{
	public static class ReflectionUtils
	{
		public static void SetValue(object instance, object value, string fieldName, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic)
		{
			instance.GetType().GetField(fieldName, bindingFlags).SetValue(instance, value);
		}

		public static void SetValue(object instance, object value, string fieldName, Type type, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic)
		{
			type.GetField(fieldName, bindingFlags).SetValue(instance, value);
		}

		public static T GetValue<T>(object instance, string fieldName, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic)
		{
			return (T)instance.GetType().GetField(fieldName, bindingFlags).GetValue(instance);
		}

		public static T GetValue<T>(object instance, string fieldName, Type type, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic)
		{
			return (T)type.GetField(fieldName, bindingFlags).GetValue(instance);
		}

		public static void InvokeMethod(object instance, string methodName, object[] parameters, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic)
		{
			instance.GetType().GetMethod(methodName, bindingFlags).Invoke(instance, parameters);
		}
	}
}
