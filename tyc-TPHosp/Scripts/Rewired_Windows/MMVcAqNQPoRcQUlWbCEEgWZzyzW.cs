using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;

internal static class MMVcAqNQPoRcQUlWbCEEgWZzyzW
{
	private static Dictionary<IntPtr, List<BvmZWGSEDoIBupvQMYZaZuINGYG>> ULjCnlUWWCphCgivWZLgNYaHnCn;

	[ThreadStatic]
	private static Dictionary<IntPtr, List<BvmZWGSEDoIBupvQMYZaZuINGYG>> jgqQHJGKzHeNcCugiPhthTVjWSTO;

	private static EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT> FwINWQVaHCkmFZcYqARuaukJqrEo;

	private static EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT> UIvGGLDSfNBztVdWYNjKhIajCZvl;

	private static Dictionary<IntPtr, List<BvmZWGSEDoIBupvQMYZaZuINGYG>> ObjectReferences
	{
		get
		{
			if (EITytYXBLfHOmGaKzQhQMNbzoWAU.IIEbzkeVzYnWHDIuFpEzSslFeVgS)
			{
				if (jgqQHJGKzHeNcCugiPhthTVjWSTO == null)
				{
					jgqQHJGKzHeNcCugiPhthTVjWSTO = new Dictionary<IntPtr, List<BvmZWGSEDoIBupvQMYZaZuINGYG>>(znrPgLCsFsmkpdWuwRzCgWVPDXs.SWaUzxFXpeNoRchZEIpfFUkcLvq);
				}
				return jgqQHJGKzHeNcCugiPhthTVjWSTO;
			}
			if (ULjCnlUWWCphCgivWZLgNYaHnCn == null)
			{
				ULjCnlUWWCphCgivWZLgNYaHnCn = new Dictionary<IntPtr, List<BvmZWGSEDoIBupvQMYZaZuINGYG>>(znrPgLCsFsmkpdWuwRzCgWVPDXs.SWaUzxFXpeNoRchZEIpfFUkcLvq);
			}
			return ULjCnlUWWCphCgivWZLgNYaHnCn;
		}
	}

	public static event EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT> Tracked
	{
		add
		{
			EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT> eventHandler = FwINWQVaHCkmFZcYqARuaukJqrEo;
			EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT> value2 = (EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref FwINWQVaHCkmFZcYqARuaukJqrEo, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT> eventHandler = FwINWQVaHCkmFZcYqARuaukJqrEo;
			EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT> value2 = (EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref FwINWQVaHCkmFZcYqARuaukJqrEo, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public static event EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT> UnTracked
	{
		add
		{
			EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT> eventHandler = UIvGGLDSfNBztVdWYNjKhIajCZvl;
			EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT> value2 = (EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref UIvGGLDSfNBztVdWYNjKhIajCZvl, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT> eventHandler = UIvGGLDSfNBztVdWYNjKhIajCZvl;
			EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT> value2 = (EventHandler<lwkpVFNzSVNhmlHGfKbxuzjqbwT>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref UIvGGLDSfNBztVdWYNjKhIajCZvl, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	static MMVcAqNQPoRcQUlWbCEEgWZzyzW()
	{
		AppDomain.CurrentDomain.DomainUnload += axYFsVIlKICNWszIhftmiVCOnyE;
		AppDomain.CurrentDomain.ProcessExit += axYFsVIlKICNWszIhftmiVCOnyE;
	}

	private static void axYFsVIlKICNWszIhftmiVCOnyE(object P_0, EventArgs P_1)
	{
		if (EITytYXBLfHOmGaKzQhQMNbzoWAU.STPuhKSPcKWcaQeCTPrWZORXhuP)
		{
			string value = KoUVvSyeeJybqvkqMEkhFxZfAmB();
			if (!string.IsNullOrEmpty(value))
			{
				Console.WriteLine(value);
			}
		}
	}

	public static void AFVkKgKILEqJQTXMYmIkiJqsXmw(gEzWBZtKpodhyJneHyYqvTiSSEh P_0)
	{
		if (P_0 == null || P_0.NativePointer == IntPtr.Zero)
		{
			return;
		}
		lock (ObjectReferences)
		{
			if (!ObjectReferences.TryGetValue(P_0.NativePointer, out var value))
			{
				value = new List<BvmZWGSEDoIBupvQMYZaZuINGYG>();
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
			value.Add(new BvmZWGSEDoIBupvQMYZaZuINGYG(DateTime.Now, P_0, stringBuilder.ToString()));
			RoxWOiJvZtQsKlfNGgIeKvWuQYp(P_0);
		}
	}

	public static List<BvmZWGSEDoIBupvQMYZaZuINGYG> SnXWYarLWHAxUNNKUUfbiwNydPi(IntPtr P_0)
	{
		lock (ObjectReferences)
		{
			if (ObjectReferences.TryGetValue(P_0, out var value))
			{
				return new List<BvmZWGSEDoIBupvQMYZaZuINGYG>(value);
			}
		}
		return new List<BvmZWGSEDoIBupvQMYZaZuINGYG>();
	}

	public static BvmZWGSEDoIBupvQMYZaZuINGYG SnXWYarLWHAxUNNKUUfbiwNydPi(gEzWBZtKpodhyJneHyYqvTiSSEh P_0)
	{
		lock (ObjectReferences)
		{
			if (ObjectReferences.TryGetValue(P_0.NativePointer, out var value))
			{
				foreach (BvmZWGSEDoIBupvQMYZaZuINGYG item in value)
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

	public static void LSvcOpBRUTsFmFWKDEJdNNrSUKI(gEzWBZtKpodhyJneHyYqvTiSSEh P_0)
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
				BvmZWGSEDoIBupvQMYZaZuINGYG bvmZWGSEDoIBupvQMYZaZuINGYG = value[num];
				if (object.ReferenceEquals(bvmZWGSEDoIBupvQMYZaZuINGYG.Object.Target, P_0))
				{
					value.RemoveAt(num);
				}
				else if (!bvmZWGSEDoIBupvQMYZaZuINGYG.IsAlive)
				{
					value.RemoveAt(num);
				}
			}
			if (value.Count == 0)
			{
				ObjectReferences.Remove(P_0.NativePointer);
			}
			TRKClPhKzJZmtBbXuagrgqrhqHnl(P_0);
		}
	}

	public static List<BvmZWGSEDoIBupvQMYZaZuINGYG> JVGDuuoStmZCVdTuBehAvwBKvcP()
	{
		List<BvmZWGSEDoIBupvQMYZaZuINGYG> list = new List<BvmZWGSEDoIBupvQMYZaZuINGYG>();
		lock (ObjectReferences)
		{
			foreach (List<BvmZWGSEDoIBupvQMYZaZuINGYG> value in ObjectReferences.Values)
			{
				foreach (BvmZWGSEDoIBupvQMYZaZuINGYG item in value)
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

	public static string KoUVvSyeeJybqvkqMEkhFxZfAmB()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (BvmZWGSEDoIBupvQMYZaZuINGYG item in JVGDuuoStmZCVdTuBehAvwBKvcP())
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

	private static void RoxWOiJvZtQsKlfNGgIeKvWuQYp(gEzWBZtKpodhyJneHyYqvTiSSEh P_0)
	{
		FwINWQVaHCkmFZcYqARuaukJqrEo?.Invoke(null, new lwkpVFNzSVNhmlHGfKbxuzjqbwT(P_0));
	}

	private static void TRKClPhKzJZmtBbXuagrgqrhqHnl(gEzWBZtKpodhyJneHyYqvTiSSEh P_0)
	{
		UIvGGLDSfNBztVdWYNjKhIajCZvl?.Invoke(null, new lwkpVFNzSVNhmlHGfKbxuzjqbwT(P_0));
	}
}
