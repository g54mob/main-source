using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace GameCreator.Runtime.Console
{
	internal static class Database
	{
		[field: NonSerialized]
		private static Dictionary<PropertyName, Command> Commands { get; set; }

		public static Dictionary<PropertyName, Command> Get
		{
			get
			{
				if (Commands == null)
				{
					Commands = new Dictionary<PropertyName, Command>();
					Type typeFromHandle = typeof(Command);
					Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
					List<Type> list = new List<Type>();
					Assembly[] array = assemblies;
					Type[] types;
					for (int i = 0; i < array.Length; i++)
					{
						types = array[i].GetTypes();
						foreach (Type type in types)
						{
							if (!type.IsInterface && !type.IsAbstract && typeFromHandle.IsAssignableFrom(type))
							{
								list.Add(type);
							}
						}
					}
					types = list.ToArray();
					for (int i = 0; i < types.Length; i++)
					{
						if (Activator.CreateInstance(types[i]) is Command command)
						{
							Commands[command.Name] = command;
						}
					}
				}
				return Commands;
			}
		}
	}
}
