using System;
using System.Collections.Generic;

namespace DevConsole
{
	public class Command : CommandBase
	{
		public delegate void ConsoleMethod();

		public Command(string name, ConsoleMethod method)
			: base(name, method, null)
		{
		}

		public Command(string name, ConsoleMethod method, string helpText)
			: base(name, method, helpText, null)
		{
		}

		public Command(string name, ConsoleMethod method, HelpMethod helpMethod)
			: base(name, method, helpMethod, null)
		{
		}

		public Command(ConsoleMethod method)
			: base(method)
		{
		}

		public Command(ConsoleMethod method, string helpText)
			: base(method, helpText)
		{
		}

		public Command(ConsoleMethod method, HelpMethod helpMethod)
			: base(method, helpMethod)
		{
		}

		protected override object[] ParseArguments(string args)
		{
			return new object[0];
		}

		protected override string ArgumentList()
		{
			return "Nothing";
		}
	}
	public class Command<T0> : CommandBase
	{
		public delegate void ConsoleMethod(T0 arg0);

		public Command(string name, ConsoleMethod method, params Func<string[], IEnumerable<string>>[] pHelp)
			: base(name, method, pHelp)
		{
		}

		public Command(string name, ConsoleMethod method, string helpText, params Func<string[], IEnumerable<string>>[] pHelp)
			: base(name, method, helpText, pHelp)
		{
		}

		public Command(string name, ConsoleMethod method, HelpMethod helpMethod, params Func<string[], IEnumerable<string>>[] pHelp)
			: base(name, method, helpMethod, pHelp)
		{
		}

		public Command(ConsoleMethod method)
			: base(method)
		{
		}

		public Command(ConsoleMethod method, string helpText)
			: base(method, helpText)
		{
		}

		public Command(ConsoleMethod method, HelpMethod helpMethod)
			: base(method, helpMethod)
		{
		}

		protected override object[] ParseArguments(string args)
		{
			string text = args.Trim();
			if (text.StartsWith("\"") && text.EndsWith("\""))
			{
				args = text.Substring(1, text.Length - 2);
			}
			return new object[1] { GetValueType<T0>(args) };
		}

		protected override string ArgumentList()
		{
			return GetTypeName(typeof(T0));
		}
	}
	public class Command<T0, T1> : CommandBase
	{
		public delegate void ConsoleMethod(T0 arg0, T1 arg1);

		public Command(string name, ConsoleMethod method, params Func<string[], IEnumerable<string>>[] pHelp)
			: base(name, method, pHelp)
		{
		}

		public Command(string name, ConsoleMethod method, string helpText, params Func<string[], IEnumerable<string>>[] pHelp)
			: base(name, method, helpText, pHelp)
		{
		}

		public Command(string name, ConsoleMethod method, HelpMethod helpMethod, params Func<string[], IEnumerable<string>>[] pHelp)
			: base(name, method, helpMethod, pHelp)
		{
		}

		public Command(ConsoleMethod method)
			: base(method)
		{
		}

		public Command(ConsoleMethod method, string helpText)
			: base(method, helpText)
		{
		}

		public Command(ConsoleMethod method, HelpMethod helpMethod)
			: base(method, helpMethod)
		{
		}

		protected override object[] ParseArguments(string message)
		{
			string[] array = Console.SplitString(message);
			if (array.Length < 2)
			{
				throw new ArgumentException("Not enough arguments");
			}
			return new object[2]
			{
				GetValueType<T0>(array[0]),
				GetValueType<T1>(array[1])
			};
		}

		protected override string ArgumentList()
		{
			return GetTypeName(typeof(T0)) + ", " + GetTypeName(typeof(T1));
		}
	}
	public class Command<T0, T1, T2> : CommandBase
	{
		public delegate void ConsoleMethod(T0 arg0, T1 arg1, T2 arg2);

		public Command(string name, ConsoleMethod method, params Func<string[], IEnumerable<string>>[] pHelp)
			: base(name, method, pHelp)
		{
		}

		public Command(string name, ConsoleMethod method, string helpText, params Func<string[], IEnumerable<string>>[] pHelp)
			: base(name, method, helpText, pHelp)
		{
		}

		public Command(string name, ConsoleMethod method, HelpMethod helpMethod, params Func<string[], IEnumerable<string>>[] pHelp)
			: base(name, method, helpMethod, pHelp)
		{
		}

		public Command(ConsoleMethod method)
			: base(method)
		{
		}

		public Command(ConsoleMethod method, string helpText)
			: base(method, helpText)
		{
		}

		public Command(ConsoleMethod method, HelpMethod helpMethod)
			: base(method, helpMethod)
		{
		}

		protected override object[] ParseArguments(string message)
		{
			string[] array = Console.SplitString(message);
			if (array.Length < 3)
			{
				throw new ArgumentException("Not enough arguments");
			}
			return new object[3]
			{
				GetValueType<T0>(array[0]),
				GetValueType<T1>(array[1]),
				GetValueType<T2>(array[2])
			};
		}

		protected override string ArgumentList()
		{
			return GetTypeName(typeof(T0)) + ", " + GetTypeName(typeof(T1)) + ", " + GetTypeName(typeof(T2));
		}
	}
}
