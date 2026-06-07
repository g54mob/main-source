using System;
using UnityEngine;

namespace DevConsole
{
	public class Vector2Command : CommandBase
	{
		public delegate void ConsoleMethod(Vector2 vector);

		public Vector2Command(string name, ConsoleMethod method)
			: base(name, method, null)
		{
		}

		public Vector2Command(string name, ConsoleMethod method, string helpText)
			: base(name, method, helpText, null)
		{
		}

		public Vector2Command(string name, ConsoleMethod method, HelpMethod helpMethod)
			: base(name, method, helpMethod, null)
		{
		}

		public Vector2Command(ConsoleMethod method)
			: base(method)
		{
		}

		public Vector2Command(ConsoleMethod method, string helpText)
			: base(method, helpText)
		{
		}

		public Vector2Command(ConsoleMethod method, HelpMethod helpMethod)
			: base(method, helpMethod)
		{
		}

		protected override object[] ParseArguments(string message)
		{
			try
			{
				string[] array = message.Split(' ');
				Vector2 vector = new Vector2(float.Parse(array[0]), float.Parse(array[1]));
				return new object[1] { vector };
			}
			catch
			{
				throw new ArgumentException("The entered value is not a valid");
			}
		}

		protected override string ArgumentList()
		{
			return "2D vector";
		}
	}
}
