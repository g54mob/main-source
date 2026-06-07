using System;
using System.Reflection;

namespace IngameDebugConsole
{
	public class ConsoleMethodInfo
	{
		public readonly MethodInfo method;

		public readonly Type[] parameterTypes;

		public readonly object instance;

		public readonly string command;

		public readonly string signature;

		public readonly string[] parameters;

		public ConsoleMethodInfo(MethodInfo method, Type[] parameterTypes, object instance, string command, string signature, string[] parameters)
		{
		}

		public bool IsValid()
		{
			return false;
		}
	}
}
