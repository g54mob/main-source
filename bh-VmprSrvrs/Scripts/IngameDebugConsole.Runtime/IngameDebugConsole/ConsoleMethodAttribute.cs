using System;

namespace IngameDebugConsole
{
	[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
	public class ConsoleMethodAttribute : Attribute
	{
		private string m_command;

		private string m_description;

		private string[] m_parameterNames;

		public string Command => null;

		public string Description => null;

		public string[] ParameterNames => null;

		public ConsoleMethodAttribute(string command, string description, params string[] parameterNames)
		{
		}
	}
}
