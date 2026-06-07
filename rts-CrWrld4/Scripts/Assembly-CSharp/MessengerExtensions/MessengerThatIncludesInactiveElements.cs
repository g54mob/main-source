using System.Reflection;
using UnityEngine;

namespace MessengerExtensions
{
	public static class MessengerThatIncludesInactiveElements
	{
		private static BindingFlags flags;

		private static void InvokeIfExists(this object objectToCheck, string methodName, params object[] parameters)
		{
		}

		private static void InvokeIfExists(this object objectToCheck, string methodName)
		{
		}

		public static void InvokeMethod(this GameObject gameobject, string methodName, bool includeInactive, params object[] parameters)
		{
		}

		public static void InvokeMethod(this GameObject gameobject, string methodName, bool includeInactive)
		{
		}

		public static void InvokeMethod(this Component component, string methodName, bool includeInactive, params object[] parameters)
		{
		}

		public static void InvokeMethod(this Component component, string methodName, bool includeInactive)
		{
		}

		public static void InvokeMethodInChildren(this GameObject gameobject, string methodName, bool includeInactive, params object[] parameters)
		{
		}

		public static void InvokeMethodInChildren(this GameObject gameobject, string methodName, bool includeInactive)
		{
		}

		public static void InvokeMethodInChildren(this Component component, string methodName, bool includeInactive, params object[] parameters)
		{
		}

		public static void InvokeMethodInChildren(this Component component, string methodName, bool includeInactive)
		{
		}

		public static void SendMessageUpwardsToAll(this GameObject gameobject, string methodName, bool includeInactive, params object[] parameters)
		{
		}

		public static void SendMessageUpwardsToAll(this Component component, string methodName, bool includeInactive, params object[] parameters)
		{
		}
	}
}
