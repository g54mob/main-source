using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FluentAssertions
{
	[DebuggerNonUserCode]
	public static class FluentActions
	{
		public static Action Invoking(Action action)
		{
			return action;
		}

		public static Func<T> Invoking<T>(Func<T> func)
		{
			return func;
		}

		public static Func<Task> Awaiting(Func<Task> action)
		{
			return action;
		}

		public static Func<Task<T>> Awaiting<T>(Func<Task<T>> func)
		{
			return func;
		}

		public static Action Enumerating(Func<IEnumerable> enumerable)
		{
			return enumerable.Enumerating();
		}

		public static Action Enumerating<T>(Func<IEnumerable<T>> enumerable)
		{
			return enumerable.Enumerating();
		}
	}
}
