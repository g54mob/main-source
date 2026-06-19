using System;
using System.Reflection;
using UnityEngine.Events;

namespace Loxodon.Framework.Binding.Proxy.Targets
{
	public static class UnityEventExtentions
	{
		public static void AddListener(this UnityEventBase unity, Delegate listener)
		{
			unity.GetType().GetMethod("AddListener").Invoke(unity, new object[1] { listener });
		}

		public static void RemoveListener(this UnityEventBase unity, Delegate listener)
		{
			unity.GetType().GetMethod("RemoveListener").Invoke(unity, new object[1] { listener });
		}

		public static Type GetListenerType(this UnityEventBase unity)
		{
			MethodInfo method = unity.GetType().GetMethod("AddListener");
			if (method == null)
			{
				return null;
			}
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters == null || parameters.Length == 0)
			{
				return null;
			}
			return parameters[0].ParameterType;
		}

		public static Type GetInvokeParameterType(this UnityEventBase unity)
		{
			MethodInfo method = unity.GetType().GetMethod("Invoke");
			if (method == null)
			{
				return null;
			}
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters == null || parameters.Length == 0)
			{
				return null;
			}
			return parameters[0].ParameterType;
		}
	}
}
