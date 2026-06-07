using System;
using System.Reflection;

namespace Assets.Packages.DevConsole.Commands
{
	public struct RegisteredCommandInfo
	{
		public Delegate CommandDelegate { get; private set; }

		public string CommandText { get; private set; }

		public string[] ParameterNames { get; private set; }

		public ParameterInfo[] Parameters { get; private set; }

		public Type ReturnType { get; private set; }

		public RegisteredCommandInfo(string commandText, Delegate commandDelegate, params string[] parameterNames)
		{
			this = default(RegisteredCommandInfo);
			CommandText = commandText;
			CommandDelegate = commandDelegate;
			Parameters = commandDelegate.Method.GetParameters();
			ReturnType = commandDelegate.Method.ReturnType;
			ParameterNames = new string[Parameters.Length];
			for (int i = 0; i < Parameters.Length; i++)
			{
				if (i < parameterNames.Length)
				{
					ParameterNames[i] = parameterNames[i]?.Replace(" ", string.Empty);
				}
			}
		}
	}
}
