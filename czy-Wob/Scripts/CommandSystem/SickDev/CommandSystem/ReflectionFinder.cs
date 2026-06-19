using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SickDev.CommandSystem
{
	internal static class ReflectionFinder
	{
		private static Type[] cache;

		public static Type[] LoadUserClassesAndStructs(string[] assembliesWithCommands = null, bool reload = false)
		{
			if (reload || cache == null)
			{
				List<Type> list = new List<Type>();
				Assembly[] assembliesWithCommands2 = GetAssembliesWithCommands(assembliesWithCommands);
				CommandsManager.SendMessage("Loading CommandSystem data from: " + string.Join(", ", assembliesWithCommands2.ToList().ConvertAll((Assembly x) => x.ManifestModule.Name).ToArray()) + ".");
				for (int num = 0; num < assembliesWithCommands2.Length; num++)
				{
					list.AddRange(assembliesWithCommands2[num].GetTypes());
				}
				cache = list.Where((Type x) => x.IsClass || (x.IsValueType && !x.IsEnum)).ToArray();
			}
			return cache;
		}

		private static Assembly[] GetAssembliesWithCommands(string[] assembliesWithCommands)
		{
			List<Assembly> list = new List<Assembly>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assembliesWithCommands.Length; i++)
			{
				bool flag = false;
				for (int j = 0; j < assemblies.Length; j++)
				{
					if (assemblies[j].ManifestModule.Name == assembliesWithCommands[i])
					{
						flag = true;
						list.Add(assemblies[j]);
						break;
					}
				}
				if (!flag)
				{
					CommandsManager.SendMessage("Assembly with name '" + assembliesWithCommands[i] + "' could not be found. Please, make sure the assembly is properly loaded");
				}
			}
			return list.ToArray();
		}
	}
}
