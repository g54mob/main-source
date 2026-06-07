using System;
using UnityEngine;

namespace DevConsole
{
	public class Vector3Command : CommandBase
	{
		public delegate void ConsoleMethod(Vector3 vector);

		public Vector3Command(string name, ConsoleMethod method)
			: base(name, method, null)
		{
		}

		public Vector3Command(string name, ConsoleMethod method, string helpText)
			: base(name, method, helpText, null)
		{
		}

		public Vector3Command(string name, ConsoleMethod method, HelpMethod helpMethod)
			: base(name, method, helpMethod, null)
		{
		}

		public Vector3Command(ConsoleMethod method)
			: base(method)
		{
		}

		public Vector3Command(ConsoleMethod method, string helpText)
			: base(method, helpText)
		{
		}

		public Vector3Command(ConsoleMethod method, HelpMethod helpMethod)
			: base(method, helpMethod)
		{
		}

		protected override object[] ParseArguments(string message)
		{
			try
			{
				string[] array = message.Split(' ');
				Vector3 vector = new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));
				return new object[1] { vector };
			}
			catch
			{
				throw new ArgumentException("The entered value is not a valid");
			}
		}

		protected override string ArgumentList()
		{
			return "3D vector";
		}
	}
}
