using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;

internal static class OZjnAJDBaYEdCGKUNigSwfsHazW
{
	private static Dictionary<IntPtr, List<RguJrsWDFWUrJzcWyNxWbCkjlFn>> EphOVxQOmKFdUchcIdYhfAfjNQX;

	[ThreadStatic]
	private static Dictionary<IntPtr, List<RguJrsWDFWUrJzcWyNxWbCkjlFn>> xTiUezQkbttbJgNqGePBzxnmWLk;

	private static EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> HWikoRhDghIaIJKELfSFMGbYgtD;

	private static EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> WtnEljAInzCROCtIuWHyIqWFhKOL;

	private static Dictionary<IntPtr, List<RguJrsWDFWUrJzcWyNxWbCkjlFn>> ObjectReferences
	{
		get
		{
			if (CuHnMkVeNLwsFgNOTqJgvbDRMVd.GuAgYMTnnmgqaOlyXCeRHIBCuWX)
			{
				if (xTiUezQkbttbJgNqGePBzxnmWLk == null)
				{
					xTiUezQkbttbJgNqGePBzxnmWLk = new Dictionary<IntPtr, List<RguJrsWDFWUrJzcWyNxWbCkjlFn>>(lZpeqfWhFUSQWlnuCpJaSsrfUKV.EjyQGTPbpGpCemqJsbLVjvWEZcLv);
				}
				return xTiUezQkbttbJgNqGePBzxnmWLk;
			}
			if (EphOVxQOmKFdUchcIdYhfAfjNQX == null)
			{
				EphOVxQOmKFdUchcIdYhfAfjNQX = new Dictionary<IntPtr, List<RguJrsWDFWUrJzcWyNxWbCkjlFn>>(lZpeqfWhFUSQWlnuCpJaSsrfUKV.EjyQGTPbpGpCemqJsbLVjvWEZcLv);
			}
			return EphOVxQOmKFdUchcIdYhfAfjNQX;
		}
	}

	public static event EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> Tracked
	{
		add
		{
			EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> eventHandler = HWikoRhDghIaIJKELfSFMGbYgtD;
			EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> value2 = (EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref HWikoRhDghIaIJKELfSFMGbYgtD, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> eventHandler = HWikoRhDghIaIJKELfSFMGbYgtD;
			EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> value2 = (EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref HWikoRhDghIaIJKELfSFMGbYgtD, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public static event EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> UnTracked
	{
		add
		{
			EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> eventHandler = WtnEljAInzCROCtIuWHyIqWFhKOL;
			EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> value2 = (EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref WtnEljAInzCROCtIuWHyIqWFhKOL, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> eventHandler = WtnEljAInzCROCtIuWHyIqWFhKOL;
			EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> value2 = (EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref WtnEljAInzCROCtIuWHyIqWFhKOL, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	static OZjnAJDBaYEdCGKUNigSwfsHazW()
	{
		AppDomain.CurrentDomain.DomainUnload += ejKiDfGOXwgYvyCJLBaMYheggzp;
		AppDomain.CurrentDomain.ProcessExit += ejKiDfGOXwgYvyCJLBaMYheggzp;
	}

	private static void ejKiDfGOXwgYvyCJLBaMYheggzp(object P_0, EventArgs P_1)
	{
		if (CuHnMkVeNLwsFgNOTqJgvbDRMVd.MgNQMuWOaeiYLcQIflDkFpzlLwoZ)
		{
			string value = UCIaoJgRqfUGXtRgcVsTzOBNfZad();
			if (!string.IsNullOrEmpty(value))
			{
				Console.WriteLine(value);
			}
		}
	}

	public static void GtXDdMQtLaKpjPhCoCUMYnECXAH(wTffSbnzKKVYFFadbCeIXFvuFVC P_0)
	{
		if (P_0 == null || P_0.NativePointer == IntPtr.Zero)
		{
			return;
		}
		lock (ObjectReferences)
		{
			List<RguJrsWDFWUrJzcWyNxWbCkjlFn> value;
			if (!ObjectReferences.TryGetValue(P_0.NativePointer, out value))
			{
				value = new List<RguJrsWDFWUrJzcWyNxWbCkjlFn>();
				ObjectReferences.Add(P_0.NativePointer, value);
			}
			StringBuilder stringBuilder = new StringBuilder();
			StackTrace stackTrace = new StackTrace(3, true);
			StackFrame[] frames = stackTrace.GetFrames();
			foreach (StackFrame stackFrame in frames)
			{
				if (stackFrame.GetFileLineNumber() != 0)
				{
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "\t{0}({1},{2}) : {3}", stackFrame.GetFileName(), stackFrame.GetFileLineNumber(), stackFrame.GetFileColumnNumber(), stackFrame.GetMethod()).AppendLine();
				}
			}
			value.Add(new RguJrsWDFWUrJzcWyNxWbCkjlFn(DateTime.Now, P_0, stringBuilder.ToString()));
			RbvtlKPDVBzgjrfBmIeUjomKITOu(P_0);
		}
	}

	public static List<RguJrsWDFWUrJzcWyNxWbCkjlFn> QYDfLSnALpsGfPExecRVCpKKeSN(IntPtr P_0)
	{
		lock (ObjectReferences)
		{
			List<RguJrsWDFWUrJzcWyNxWbCkjlFn> value;
			if (ObjectReferences.TryGetValue(P_0, out value))
			{
				return new List<RguJrsWDFWUrJzcWyNxWbCkjlFn>(value);
			}
		}
		return new List<RguJrsWDFWUrJzcWyNxWbCkjlFn>();
	}

	public static RguJrsWDFWUrJzcWyNxWbCkjlFn QYDfLSnALpsGfPExecRVCpKKeSN(wTffSbnzKKVYFFadbCeIXFvuFVC P_0)
	{
		lock (ObjectReferences)
		{
			List<RguJrsWDFWUrJzcWyNxWbCkjlFn> value;
			if (ObjectReferences.TryGetValue(P_0.NativePointer, out value))
			{
				foreach (RguJrsWDFWUrJzcWyNxWbCkjlFn item in value)
				{
					if (object.ReferenceEquals(item.Object.Target, P_0))
					{
						return item;
					}
				}
			}
		}
		return null;
	}

	public static void PEzDlLROdbMfXTAEvglZxWJmRyz(wTffSbnzKKVYFFadbCeIXFvuFVC P_0)
	{
		if (P_0 == null || P_0.NativePointer == IntPtr.Zero)
		{
			return;
		}
		lock (ObjectReferences)
		{
			List<RguJrsWDFWUrJzcWyNxWbCkjlFn> value;
			if (!ObjectReferences.TryGetValue(P_0.NativePointer, out value))
			{
				return;
			}
			for (int num = value.Count - 1; num >= 0; num--)
			{
				RguJrsWDFWUrJzcWyNxWbCkjlFn rguJrsWDFWUrJzcWyNxWbCkjlFn = value[num];
				if (object.ReferenceEquals(rguJrsWDFWUrJzcWyNxWbCkjlFn.Object.Target, P_0))
				{
					value.RemoveAt(num);
				}
				else if (!rguJrsWDFWUrJzcWyNxWbCkjlFn.IsAlive)
				{
					value.RemoveAt(num);
				}
			}
			if (value.Count == 0)
			{
				ObjectReferences.Remove(P_0.NativePointer);
			}
			LCCMUtCphzDAKrQJUkKDGQHQzEI(P_0);
		}
	}

	public static List<RguJrsWDFWUrJzcWyNxWbCkjlFn> RKUgpYsgYQbzdbhNdDQHZdCkcsaf()
	{
		List<RguJrsWDFWUrJzcWyNxWbCkjlFn> list = new List<RguJrsWDFWUrJzcWyNxWbCkjlFn>();
		lock (ObjectReferences)
		{
			foreach (List<RguJrsWDFWUrJzcWyNxWbCkjlFn> value in ObjectReferences.Values)
			{
				foreach (RguJrsWDFWUrJzcWyNxWbCkjlFn item in value)
				{
					if (item.IsAlive)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}
	}

	public static string UCIaoJgRqfUGXtRgcVsTzOBNfZad()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (RguJrsWDFWUrJzcWyNxWbCkjlFn item in RKUgpYsgYQbzdbhNdDQHZdCkcsaf())
		{
			string text = item.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.AppendFormat("[{0}]: {1}", num, text);
				object target = item.Object.Target;
				if (target != null)
				{
					string name = target.GetType().Name;
					int value;
					if (!dictionary.TryGetValue(name, out value))
					{
						dictionary[name] = 0;
					}
					dictionary[name] = value + 1;
				}
			}
			num++;
		}
		List<string> list = new List<string>(dictionary.Keys);
		list.Sort();
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Count per Type:");
		foreach (string item2 in list)
		{
			stringBuilder.AppendFormat("{0} : {1}", item2, dictionary[item2]);
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	private static void RbvtlKPDVBzgjrfBmIeUjomKITOu(wTffSbnzKKVYFFadbCeIXFvuFVC P_0)
	{
		EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> hWikoRhDghIaIJKELfSFMGbYgtD = HWikoRhDghIaIJKELfSFMGbYgtD;
		if (hWikoRhDghIaIJKELfSFMGbYgtD != null)
		{
			hWikoRhDghIaIJKELfSFMGbYgtD(null, new pkFQrLJOdxvRdwKLhZNEXBKjzs(P_0));
		}
	}

	private static void LCCMUtCphzDAKrQJUkKDGQHQzEI(wTffSbnzKKVYFFadbCeIXFvuFVC P_0)
	{
		EventHandler<pkFQrLJOdxvRdwKLhZNEXBKjzs> wtnEljAInzCROCtIuWHyIqWFhKOL = WtnEljAInzCROCtIuWHyIqWFhKOL;
		if (wtnEljAInzCROCtIuWHyIqWFhKOL != null)
		{
			wtnEljAInzCROCtIuWHyIqWFhKOL(null, new pkFQrLJOdxvRdwKLhZNEXBKjzs(P_0));
		}
	}
}
