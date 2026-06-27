using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace DistantLands.Cozy
{
	public static class EditorUtilities
	{
		public static T[] GetAllInstances<T>() where T : ScriptableObject
		{
			return null;
		}

		public static List<Type> ResetModuleList()
		{
			return (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
				from type in domainAssembly.GetTypes()
				where typeof(CozyModule).IsAssignableFrom(type)
				select type).ToList();
		}

		public static List<Type> ResetBiomeModulesList()
		{
			return (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
				from type in domainAssembly.GetTypes()
				where typeof(CozyModule).IsAssignableFrom(type) && type.GetInterfaces().Any((Type i) => i == typeof(ICozyBiomeModule))
				select type).ToList();
		}
	}
}
