using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace com.ootii.Helpers
{
	public static class InterfaceHelper
	{
		private static Dictionary<Type, Type[]> mInterfaceTypes;

		static InterfaceHelper()
		{
		}

		public static T[] GetComponents<T>()
		{
			return null;
		}

		public static T[] GetComponents<T>(GameObject rGameObject)
		{
			return null;
		}

		public static T GetComponent<T>(GameObject rGameObject)
		{
			return default(T);
		}

		public static T[] FindComponentsOfType<T>()
		{
			return null;
		}

		public static Type[] GetInterfaceTypes(Type rInterface)
		{
			return null;
		}

		public static Assembly[] GetAssemblies()
		{
			return null;
		}

		public static Type[] GetTypes(this Assembly assembly)
		{
			return null;
		}
	}
}
