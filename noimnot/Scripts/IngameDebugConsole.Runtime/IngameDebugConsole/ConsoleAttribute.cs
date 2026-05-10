using System;
using System.Reflection;

namespace IngameDebugConsole
{
	public abstract class ConsoleAttribute : Attribute
	{
		public MethodInfo Method { get; private set; }

		public abstract int Order { get; }

		public void SetMethod(MethodInfo method)
		{
		}

		public abstract void Load();
	}
}
