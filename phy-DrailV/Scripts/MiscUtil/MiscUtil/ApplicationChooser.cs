using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace MiscUtil
{
	public class ApplicationChooser
	{
		private const string Keys = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		public static void Run(Type type, string[] args)
		{
			Assembly assembly = type.Assembly;
			List<MethodBase> list = new List<MethodBase>();
			Type[] types = assembly.GetTypes();
			foreach (Type type2 in types)
			{
				if ((object)type2 != type)
				{
					MethodBase entryPoint = GetEntryPoint(type2);
					if ((object)entryPoint != null)
					{
						list.Add(entryPoint);
					}
				}
			}
			list.Sort((MethodBase x, MethodBase y) => x.DeclaringType.Name.CompareTo(y.DeclaringType.Name));
			if (list.Count == 0)
			{
				Console.WriteLine("No entry points found. Press return to exit.");
				Console.ReadLine();
				return;
			}
			for (int num = 0; num < list.Count; num++)
			{
				Console.WriteLine("{0}: {1}", "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"[num], GetEntryPointName(list[num]));
			}
			Console.WriteLine();
			Console.Write("Entry point to run? ");
			Console.Out.Flush();
			char keyChar = Console.ReadKey().KeyChar;
			Console.WriteLine();
			if (keyChar == '\r')
			{
				return;
			}
			int num2 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(char.ToUpper(keyChar));
			if (num2 == -1 || num2 >= list.Count)
			{
				Console.WriteLine("Invalid choice");
			}
			else
			{
				try
				{
					MethodBase methodBase = list[num2];
					methodBase.Invoke(null, (methodBase.GetParameters().Length == 0) ? null : new object[1] { args });
				}
				catch (Exception arg)
				{
					Console.WriteLine("Exception: {0}", arg);
				}
			}
			Console.WriteLine();
			Console.WriteLine("Press return to exit.");
			Console.ReadLine();
		}

		private static object GetEntryPointName(MethodBase methodBase)
		{
			Type declaringType = methodBase.DeclaringType;
			object[] customAttributes = declaringType.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
			if (customAttributes.Length != 0)
			{
				return $"{declaringType.Name} [{((DescriptionAttribute)customAttributes[0]).Description}]";
			}
			return declaringType.Name;
		}

		internal static MethodBase GetEntryPoint(Type type)
		{
			if (type.IsGenericTypeDefinition || type.IsGenericType)
			{
				return null;
			}
			BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
			MethodInfo[] methods = type.GetMethods(bindingAttr);
			MethodInfo methodInfo = null;
			MethodInfo methodInfo2 = null;
			MethodInfo[] array = methods;
			foreach (MethodInfo methodInfo3 in array)
			{
				if (!(methodInfo3.Name != "Main") && !methodInfo3.IsGenericMethod && !methodInfo3.IsGenericMethodDefinition)
				{
					ParameterInfo[] parameters = methodInfo3.GetParameters();
					if (parameters.Length == 0)
					{
						methodInfo = methodInfo3;
					}
					else if (parameters.Length == 1 && !parameters[0].IsOut && !parameters[0].IsOptional && (object)parameters[0].ParameterType == typeof(string[]))
					{
						methodInfo2 = methodInfo3;
					}
				}
			}
			return methodInfo2 ?? methodInfo;
		}
	}
}
