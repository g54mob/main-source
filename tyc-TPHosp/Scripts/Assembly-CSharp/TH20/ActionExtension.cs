#define LOG_LEVEL_VERBOSE
using System;
using System.Linq;

namespace TH20
{
	public static class ActionExtension
	{
		public static bool VerifyCallValid;

		private static void VerifyValid()
		{
			if (!VerifyCallValid)
			{
				throw new Debug.AssertException("!VerifyCallValid - VerifyIsNull is not allowed to be called, set VerifyCallValid to TRUE if it should be");
			}
		}

		private static void ReportError(string actionName, Delegate[] delegates)
		{
			Logging.Error(LogChannels.Debug, "'{0}' has {1} objects still in invocation list:\n\t{2}", actionName, delegates.Length, string.Join("\n\t", delegates.Select((Delegate x) => x.Method.DeclaringType.Name + "." + x.Method.Name).ToArray()));
		}

		public static void VerifyIsNull(this Action action)
		{
			VerifyValid();
			if (action != null)
			{
				ReportError(action.Method.Name, action.GetInvocationList());
			}
		}

		public static void VerifyIsNull<T>(this Action<T> action)
		{
			VerifyValid();
			if (action != null)
			{
				ReportError(action.Method.Name, action.GetInvocationList());
			}
		}

		public static void VerifyIsNull<T1, T2>(this Action<T1, T2> action)
		{
			VerifyValid();
			if (action != null)
			{
				ReportError(action.Method.Name, action.GetInvocationList());
			}
		}

		public static void VerifyIsNull<T1, T2, T3>(this Action<T1, T2, T3> action)
		{
			VerifyValid();
			if (action != null)
			{
				ReportError(action.Method.Name, action.GetInvocationList());
			}
		}

		public static void VerifyIsNull<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
		{
			VerifyValid();
			if (action != null)
			{
				ReportError(action.Method.Name, action.GetInvocationList());
			}
		}

		public static void InvokeSafe(this Action action)
		{
			action?.Invoke();
		}

		public static void InvokeSafe<T>(this Action<T> action, T param)
		{
			action?.Invoke(param);
		}

		public static void InvokeSafe<T1, T2>(this Action<T1, T2> action, T1 param1, T2 param2)
		{
			action?.Invoke(param1, param2);
		}

		public static void InvokeSafe<T1, T2, T3>(this Action<T1, T2, T3> action, T1 param1, T2 param2, T3 param3)
		{
			action?.Invoke(param1, param2, param3);
		}

		public static void InvokeSafe<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 param1, T2 param2, T3 param3, T4 param4)
		{
			action?.Invoke(param1, param2, param3, param4);
		}
	}
}
