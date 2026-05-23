using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;

internal static class YArxiaoUFURHoROqwvymvbvjQyj
{
	private static Dictionary<IntPtr, List<HGAmnWxjDYeqMmfyLbiAiQoTXuj>> QBFXXnpEGcREepHVFmdCytIRwFQ;

	[ThreadStatic]
	private static Dictionary<IntPtr, List<HGAmnWxjDYeqMmfyLbiAiQoTXuj>> jtGdjTllqviUEvKcrJvRqpQAXwo;

	private static EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> HMaZbKeZZmkLfMJsrvSMXYUTcib;

	private static EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> ETNyyHnwjzKrBktuZDPkbJUbQbA;

	private static Dictionary<IntPtr, List<HGAmnWxjDYeqMmfyLbiAiQoTXuj>> ObjectReferences
	{
		get
		{
			if (UTxdLAskJBbuOlCsuFFyqiRnBXfg.OeuVGksTnsrAbXpGewZTNPTcSKZ)
			{
				if (jtGdjTllqviUEvKcrJvRqpQAXwo == null)
				{
					jtGdjTllqviUEvKcrJvRqpQAXwo = new Dictionary<IntPtr, List<HGAmnWxjDYeqMmfyLbiAiQoTXuj>>(ftBbfDJnJOaBZckSJhnsHDriBOfR.KJEJVbuchEgTrbtlHcHBwPMsssP);
				}
				return jtGdjTllqviUEvKcrJvRqpQAXwo;
			}
			if (QBFXXnpEGcREepHVFmdCytIRwFQ == null)
			{
				QBFXXnpEGcREepHVFmdCytIRwFQ = new Dictionary<IntPtr, List<HGAmnWxjDYeqMmfyLbiAiQoTXuj>>(ftBbfDJnJOaBZckSJhnsHDriBOfR.KJEJVbuchEgTrbtlHcHBwPMsssP);
			}
			return QBFXXnpEGcREepHVFmdCytIRwFQ;
		}
	}

	public static event EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> Tracked
	{
		add
		{
			EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> eventHandler = HMaZbKeZZmkLfMJsrvSMXYUTcib;
			EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> value2 = (EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref HMaZbKeZZmkLfMJsrvSMXYUTcib, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> eventHandler = HMaZbKeZZmkLfMJsrvSMXYUTcib;
			EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> value2 = (EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref HMaZbKeZZmkLfMJsrvSMXYUTcib, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public static event EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> UnTracked
	{
		add
		{
			EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> eventHandler = ETNyyHnwjzKrBktuZDPkbJUbQbA;
			EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> value2 = (EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref ETNyyHnwjzKrBktuZDPkbJUbQbA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> eventHandler = ETNyyHnwjzKrBktuZDPkbJUbQbA;
			EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> value2 = (EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref ETNyyHnwjzKrBktuZDPkbJUbQbA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	static YArxiaoUFURHoROqwvymvbvjQyj()
	{
		AppDomain.CurrentDomain.DomainUnload += qkggzZHhQgUtodpegJHOtHsGQqvv;
		AppDomain.CurrentDomain.ProcessExit += qkggzZHhQgUtodpegJHOtHsGQqvv;
	}

	private static void qkggzZHhQgUtodpegJHOtHsGQqvv(object P_0, EventArgs P_1)
	{
		if (UTxdLAskJBbuOlCsuFFyqiRnBXfg.OHtJUSxyesXsYXboMJoyodSBmyq)
		{
			string value = AReprvTumlLPIquIJwaRuJZftFy();
			if (!string.IsNullOrEmpty(value))
			{
				Console.WriteLine(value);
			}
		}
	}

	public static void QYpkCyjSXiJZyMPcZoYYJzYcBMX(gZHsmLYRWYRWOYtXCrCKGLdQONK P_0)
	{
		if (P_0 == null || P_0.NativePointer == IntPtr.Zero)
		{
			return;
		}
		lock (ObjectReferences)
		{
			List<HGAmnWxjDYeqMmfyLbiAiQoTXuj> value;
			if (!ObjectReferences.TryGetValue(P_0.NativePointer, out value))
			{
				value = new List<HGAmnWxjDYeqMmfyLbiAiQoTXuj>();
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
			value.Add(new HGAmnWxjDYeqMmfyLbiAiQoTXuj(DateTime.Now, P_0, stringBuilder.ToString()));
			RnFiLyyWBLzeemyjLskGhFcybBS(P_0);
		}
	}

	public static List<HGAmnWxjDYeqMmfyLbiAiQoTXuj> SahEcyAYIxyfuYacDzqDNNvmCaR(IntPtr P_0)
	{
		lock (ObjectReferences)
		{
			List<HGAmnWxjDYeqMmfyLbiAiQoTXuj> value;
			if (ObjectReferences.TryGetValue(P_0, out value))
			{
				return new List<HGAmnWxjDYeqMmfyLbiAiQoTXuj>(value);
			}
		}
		return new List<HGAmnWxjDYeqMmfyLbiAiQoTXuj>();
	}

	public static HGAmnWxjDYeqMmfyLbiAiQoTXuj SahEcyAYIxyfuYacDzqDNNvmCaR(gZHsmLYRWYRWOYtXCrCKGLdQONK P_0)
	{
		lock (ObjectReferences)
		{
			List<HGAmnWxjDYeqMmfyLbiAiQoTXuj> value;
			if (ObjectReferences.TryGetValue(P_0.NativePointer, out value))
			{
				foreach (HGAmnWxjDYeqMmfyLbiAiQoTXuj item in value)
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

	public static void XUDfEfcoQvjDCfIcKEcTauTkIDxp(gZHsmLYRWYRWOYtXCrCKGLdQONK P_0)
	{
		if (P_0 == null || P_0.NativePointer == IntPtr.Zero)
		{
			return;
		}
		lock (ObjectReferences)
		{
			List<HGAmnWxjDYeqMmfyLbiAiQoTXuj> value;
			if (!ObjectReferences.TryGetValue(P_0.NativePointer, out value))
			{
				return;
			}
			for (int num = value.Count - 1; num >= 0; num--)
			{
				HGAmnWxjDYeqMmfyLbiAiQoTXuj hGAmnWxjDYeqMmfyLbiAiQoTXuj = value[num];
				if (object.ReferenceEquals(hGAmnWxjDYeqMmfyLbiAiQoTXuj.Object.Target, P_0))
				{
					value.RemoveAt(num);
				}
				else if (!hGAmnWxjDYeqMmfyLbiAiQoTXuj.IsAlive)
				{
					value.RemoveAt(num);
				}
			}
			if (value.Count == 0)
			{
				ObjectReferences.Remove(P_0.NativePointer);
			}
			LOcLeFbqthXpLksnnAFJVzZkEeC(P_0);
		}
	}

	public static List<HGAmnWxjDYeqMmfyLbiAiQoTXuj> ZOmsvqDIIGfooeolAeMNbISEToqD()
	{
		List<HGAmnWxjDYeqMmfyLbiAiQoTXuj> list = new List<HGAmnWxjDYeqMmfyLbiAiQoTXuj>();
		lock (ObjectReferences)
		{
			foreach (List<HGAmnWxjDYeqMmfyLbiAiQoTXuj> value in ObjectReferences.Values)
			{
				foreach (HGAmnWxjDYeqMmfyLbiAiQoTXuj item in value)
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

	public static string AReprvTumlLPIquIJwaRuJZftFy()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (HGAmnWxjDYeqMmfyLbiAiQoTXuj item in ZOmsvqDIIGfooeolAeMNbISEToqD())
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

	private static void RnFiLyyWBLzeemyjLskGhFcybBS(gZHsmLYRWYRWOYtXCrCKGLdQONK P_0)
	{
		EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> hMaZbKeZZmkLfMJsrvSMXYUTcib = HMaZbKeZZmkLfMJsrvSMXYUTcib;
		if (hMaZbKeZZmkLfMJsrvSMXYUTcib != null)
		{
			hMaZbKeZZmkLfMJsrvSMXYUTcib(null, new fMCZTTkdCbysCsikguVVZOBaFtwh(P_0));
		}
	}

	private static void LOcLeFbqthXpLksnnAFJVzZkEeC(gZHsmLYRWYRWOYtXCrCKGLdQONK P_0)
	{
		EventHandler<fMCZTTkdCbysCsikguVVZOBaFtwh> eTNyyHnwjzKrBktuZDPkbJUbQbA = ETNyyHnwjzKrBktuZDPkbJUbQbA;
		if (eTNyyHnwjzKrBktuZDPkbJUbQbA != null)
		{
			eTNyyHnwjzKrBktuZDPkbJUbQbA(null, new fMCZTTkdCbysCsikguVVZOBaFtwh(P_0));
		}
	}
}
