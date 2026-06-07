using System;
using System.Reflection;

namespace Jundroo.DevConsole.Commands
{
	public struct RegisteredCommandInfo
	{
		public string CommandText { get; private set; }

		public ParameterInfo[] Parameters { get; private set; }

		public Type ReturnType { get; private set; }

		public RegisteredCommandInfo(string commandText, Delegate commandDelegate)
		{
			this = default(RegisteredCommandInfo);
			CommandText = commandText;
			Parameters = commandDelegate.Method.GetParameters();
			ReturnType = commandDelegate.Method.ReturnType;
		}
	}
}
