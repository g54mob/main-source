using System;
using System.Reflection;
using UnityEngine;

namespace TH20
{
	public static class ObjectValidationUtils
	{
		private enum ValidationFailAction
		{
			Assert = 0,
			UnityLog = 1,
			None = 2
		}

		private static bool FieldNeedsValidation(FieldInfo field, Type ownerType)
		{
			if (field.DeclaringType != ownerType)
			{
				return false;
			}
			if (!field.FieldType.IsClass)
			{
				return false;
			}
			if (field.FieldType != typeof(UnityEngine.Object) && !field.FieldType.IsSubclassOf(typeof(UnityEngine.Object)))
			{
				return false;
			}
			if (!UnitySerialisationUtils.FieldIsSerializedByUnity(field))
			{
				return false;
			}
			return true;
		}

		private static bool Validate(Type type, UnityEngine.Object instance, ValidationFailAction failAction)
		{
			bool flag = true;
			FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!FieldNeedsValidation(fieldInfo, type))
				{
					continue;
				}
				bool flag2 = fieldInfo.GetValue(instance) as UnityEngine.Object != null;
				flag = flag && flag2;
				switch (failAction)
				{
				case ValidationFailAction.UnityLog:
					if (!flag2)
					{
						UnityEngine.Debug.LogErrorFormat(instance, "{0} on {1} is null! You need to set it to something or it will break.", fieldInfo.Name, instance.name);
					}
					break;
				}
			}
			return flag;
		}

		public static bool ValidateAndUnityLogFailures(Type type, UnityEngine.Object instance)
		{
			return Validate(type, instance, ValidationFailAction.UnityLog);
		}

		public static bool ValidateAndUnityLogFailures<T>(T instance) where T : UnityEngine.Object
		{
			return ValidateAndUnityLogFailures(typeof(T), instance);
		}

		public static bool ValidateAndAssertFailures(Type type, UnityEngine.Object instance)
		{
			return Validate(type, instance, ValidationFailAction.Assert);
		}

		public static bool ValidateAndAssertFailures<T>(T instance) where T : UnityEngine.Object
		{
			return ValidateAndAssertFailures(typeof(T), instance);
		}

		public static bool ValidateAndReturnSuccess(Type type, UnityEngine.Object instance)
		{
			return Validate(type, instance, ValidationFailAction.None);
		}

		public static bool ValidateAndReturnSuccess<T>(T instance) where T : UnityEngine.Object
		{
			return ValidateAndReturnSuccess(typeof(T), instance);
		}
	}
}
