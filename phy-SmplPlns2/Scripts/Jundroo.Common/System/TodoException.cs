using System.Collections.Generic;
using UnityEngine;

namespace System
{
	public class TodoException : Exception
	{
		public TodoException(string todo)
			: base(todo)
		{
		}
	}
	public class TodoException<T> : TodoException
	{
		private static HashSet<string> _logged = new HashSet<string>();

		private static HashSet<string> _thrown = new HashSet<string>();

		public TodoException(string todo)
			: base(todo)
		{
		}

		public static void ThrowOnce(string todo)
		{
			if (!_thrown.Contains(todo))
			{
				_thrown.Add(todo);
				throw new TodoException<T>(todo);
			}
		}

		public static void LogOnce(string todo)
		{
			if (!_logged.Contains(todo))
			{
				_logged.Add(todo);
				Debug.LogException(new TodoException<T>(todo));
			}
		}
	}
}
