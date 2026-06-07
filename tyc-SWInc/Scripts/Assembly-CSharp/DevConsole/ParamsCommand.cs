using System;
using System.Collections.Generic;

namespace DevConsole
{
	public class ParamsCommand<T0> : CommandBase
	{
		public delegate void ConsoleMethod(params T0[] arg0);

		public ParamsCommand(string name, ConsoleMethod method, params Func<string[], IEnumerable<string>>[] pHelp)
			: base(name, method, pHelp)
		{
		}

		public ParamsCommand(string name, ConsoleMethod method, string helpText, params Func<string[], IEnumerable<string>>[] pHelp)
			: base(name, method, helpText, pHelp)
		{
		}

		public ParamsCommand(string name, ConsoleMethod method, HelpMethod helpMethod, params Func<string[], IEnumerable<string>>[] pHelp)
			: base(name, method, helpMethod, pHelp)
		{
		}

		public ParamsCommand(ConsoleMethod method)
			: base(method)
		{
		}

		public ParamsCommand(ConsoleMethod method, string helpText)
			: base(method, helpText)
		{
		}

		public ParamsCommand(ConsoleMethod method, HelpMethod helpMethod)
			: base(method, helpMethod)
		{
		}

		protected override object[] ParseArguments(string message)
		{
			string[] array = Console.SplitString(message);
			T0[] array2 = new T0[array.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = GetValueType<T0>(array[i]);
			}
			return new object[1] { array2 };
		}

		protected override string ArgumentList()
		{
			return GetTypeName(typeof(T0)) + " array";
		}
	}
}
