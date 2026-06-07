using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;

internal static class HWqjatSQvvhmhmpIMFgflakwrbY
{
	private static Dictionary<IntPtr, List<GJAcZNYjdUXNLaChyfXkNzGZYI>> JxEJZwHVsPnrvARhjdtTgwRMjCp;

	[ThreadStatic]
	private static Dictionary<IntPtr, List<GJAcZNYjdUXNLaChyfXkNzGZYI>> mUZvoCHlREFnTWaiTjBWwksZDEX;

	private static EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF> OhpkjFALlXiimzkIHprVTcVEZvW;

	private static EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF> JuCyUuDDdGhEdHUfdBtVfLiaHed;

	private static Dictionary<IntPtr, List<GJAcZNYjdUXNLaChyfXkNzGZYI>> ObjectReferences
	{
		get
		{
			if (VvwRDTUEfmYWLWuKYFjraCAuDAU.DjkTfGGVLRQuowqUrgMaDAjOJcn)
			{
				if (mUZvoCHlREFnTWaiTjBWwksZDEX == null)
				{
					mUZvoCHlREFnTWaiTjBWwksZDEX = new Dictionary<IntPtr, List<GJAcZNYjdUXNLaChyfXkNzGZYI>>(ofYppEHGpjlmUJhkFjhhTRsOEJe.BIVLMsAJofwaqCjVpNRCkfBbdtc);
				}
				return mUZvoCHlREFnTWaiTjBWwksZDEX;
			}
			if (JxEJZwHVsPnrvARhjdtTgwRMjCp == null)
			{
				JxEJZwHVsPnrvARhjdtTgwRMjCp = new Dictionary<IntPtr, List<GJAcZNYjdUXNLaChyfXkNzGZYI>>(ofYppEHGpjlmUJhkFjhhTRsOEJe.BIVLMsAJofwaqCjVpNRCkfBbdtc);
			}
			return JxEJZwHVsPnrvARhjdtTgwRMjCp;
		}
	}

	public static event EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF> Tracked
	{
		add
		{
			EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF> eventHandler = OhpkjFALlXiimzkIHprVTcVEZvW;
			EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF> value2 = (EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref OhpkjFALlXiimzkIHprVTcVEZvW, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF> eventHandler = OhpkjFALlXiimzkIHprVTcVEZvW;
			EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF> value2 = (EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref OhpkjFALlXiimzkIHprVTcVEZvW, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public static event EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF> UnTracked
	{
		add
		{
			EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF> eventHandler = JuCyUuDDdGhEdHUfdBtVfLiaHed;
			EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF> value2 = (EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref JuCyUuDDdGhEdHUfdBtVfLiaHed, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF> eventHandler = JuCyUuDDdGhEdHUfdBtVfLiaHed;
			EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF> value2 = (EventHandler<yhBkDIWlyCqRNHGKUEXSgZYdbqNF>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref JuCyUuDDdGhEdHUfdBtVfLiaHed, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	static HWqjatSQvvhmhmpIMFgflakwrbY()
	{
		AppDomain.CurrentDomain.DomainUnload += rOrRvARZiVHApYROGBXTBPrDTtK;
		AppDomain.CurrentDomain.ProcessExit += rOrRvARZiVHApYROGBXTBPrDTtK;
	}

	private static void rOrRvARZiVHApYROGBXTBPrDTtK(object P_0, EventArgs P_1)
	{
		if (VvwRDTUEfmYWLWuKYFjraCAuDAU.VGiFlLPKbNcEFwCSgLfnkweQlpV)
		{
			string value = TCnjdyEvMIOkBKJkxOcUdwOysALf();
			if (!string.IsNullOrEmpty(value))
			{
				Console.WriteLine(value);
			}
		}
	}

	public static void BaaZGrZPjDGsbzqUnzGZVCDlRPs(vAWguSwtalYfBjVbuWSVCdiToKd P_0)
	{
		if (P_0 == null || P_0.NativePointer == IntPtr.Zero)
		{
			return;
		}
		lock (ObjectReferences)
		{
			if (!ObjectReferences.TryGetValue(P_0.NativePointer, out var value))
			{
				value = new List<GJAcZNYjdUXNLaChyfXkNzGZYI>();
				ObjectReferences.Add(P_0.NativePointer, value);
			}
			StringBuilder stringBuilder = new StringBuilder();
			StackTrace stackTrace = new StackTrace(3, fNeedFileInfo: true);
			StackFrame[] frames = stackTrace.GetFrames();
			foreach (StackFrame stackFrame in frames)
			{
				if (stackFrame.GetFileLineNumber() != 0)
				{
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "\t{0}({1},{2}) : {3}", stackFrame.GetFileName(), stackFrame.GetFileLineNumber(), stackFrame.GetFileColumnNumber(), stackFrame.GetMethod()).AppendLine();
				}
			}
			value.Add(new GJAcZNYjdUXNLaChyfXkNzGZYI(DateTime.Now, P_0, stringBuilder.ToString()));
			SbQwXrQhjaAOxJXPvsGFbrSzQuf(P_0);
		}
	}

	public static List<GJAcZNYjdUXNLaChyfXkNzGZYI> PYgQmrazoUqWjrASzZcCXOaxeza(IntPtr P_0)
	{
		lock (ObjectReferences)
		{
			if (ObjectReferences.TryGetValue(P_0, out var value))
			{
				return new List<GJAcZNYjdUXNLaChyfXkNzGZYI>(value);
			}
		}
		return new List<GJAcZNYjdUXNLaChyfXkNzGZYI>();
	}

	public static GJAcZNYjdUXNLaChyfXkNzGZYI PYgQmrazoUqWjrASzZcCXOaxeza(vAWguSwtalYfBjVbuWSVCdiToKd P_0)
	{
		lock (ObjectReferences)
		{
			if (ObjectReferences.TryGetValue(P_0.NativePointer, out var value))
			{
				foreach (GJAcZNYjdUXNLaChyfXkNzGZYI item in value)
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

	public static void WfCrOuCOoWfyDgfUgQgODmMVQMCq(vAWguSwtalYfBjVbuWSVCdiToKd P_0)
	{
		if (P_0 == null || P_0.NativePointer == IntPtr.Zero)
		{
			return;
		}
		lock (ObjectReferences)
		{
			if (!ObjectReferences.TryGetValue(P_0.NativePointer, out var value))
			{
				return;
			}
			for (int num = value.Count - 1; num >= 0; num--)
			{
				GJAcZNYjdUXNLaChyfXkNzGZYI gJAcZNYjdUXNLaChyfXkNzGZYI = value[num];
				if (object.ReferenceEquals(gJAcZNYjdUXNLaChyfXkNzGZYI.Object.Target, P_0))
				{
					value.RemoveAt(num);
				}
				else if (!gJAcZNYjdUXNLaChyfXkNzGZYI.IsAlive)
				{
					value.RemoveAt(num);
				}
			}
			if (value.Count == 0)
			{
				ObjectReferences.Remove(P_0.NativePointer);
			}
			SdlJEQPXEYuhATVtBEtMHWkvHyl(P_0);
		}
	}

	public static List<GJAcZNYjdUXNLaChyfXkNzGZYI> IkngvpEfmbyTpENHquEIFWZLulPs()
	{
		List<GJAcZNYjdUXNLaChyfXkNzGZYI> list = new List<GJAcZNYjdUXNLaChyfXkNzGZYI>();
		lock (ObjectReferences)
		{
			foreach (List<GJAcZNYjdUXNLaChyfXkNzGZYI> value in ObjectReferences.Values)
			{
				foreach (GJAcZNYjdUXNLaChyfXkNzGZYI item in value)
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

	public static string TCnjdyEvMIOkBKJkxOcUdwOysALf()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (GJAcZNYjdUXNLaChyfXkNzGZYI item in IkngvpEfmbyTpENHquEIFWZLulPs())
		{
			string text = item.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.AppendFormat("[{0}]: {1}", num, text);
				object target = item.Object.Target;
				if (target != null)
				{
					string name = target.GetType().Name;
					if (!dictionary.TryGetValue(name, out var value))
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

	private static void SbQwXrQhjaAOxJXPvsGFbrSzQuf(vAWguSwtalYfBjVbuWSVCdiToKd P_0)
	{
		OhpkjFALlXiimzkIHprVTcVEZvW?.Invoke(null, new yhBkDIWlyCqRNHGKUEXSgZYdbqNF(P_0));
	}

	private static void SdlJEQPXEYuhATVtBEtMHWkvHyl(vAWguSwtalYfBjVbuWSVCdiToKd P_0)
	{
		JuCyUuDDdGhEdHUfdBtVfLiaHed?.Invoke(null, new yhBkDIWlyCqRNHGKUEXSgZYdbqNF(P_0));
	}
}
