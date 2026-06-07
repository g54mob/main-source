using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

internal static class icjyVFxGnsyrnZBtbYHJVhAWctWT
{
	private static Dictionary<IntPtr, List<fDOberhqriNJJJqrQZHnIYJuvCQiA>> oBRZvCmdgSlLvnvWCBKvWFlwAatH;

	[ThreadStatic]
	private static Dictionary<IntPtr, List<fDOberhqriNJJJqrQZHnIYJuvCQiA>> HoUHlaaJNXMLXbaNiDbodMAbUULpA;

	[CompilerGenerated]
	private static EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl> m_vDkrPdnLzCeegKxtwVodfdrsfrGi;

	[CompilerGenerated]
	private static EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl> m_wQBVmoeoLTAnCyKnKzxDVAnItVjW;

	private static Dictionary<IntPtr, List<fDOberhqriNJJJqrQZHnIYJuvCQiA>> NteICkHplacCoAcKLXeiGEFeeJDGb
	{
		get
		{
			if (sRleBzhjzvmMDdXnfDtFGQeYBCUzA.umkXRJhWTAMGaRDBhUUwbIuZJXuL)
			{
				if (HoUHlaaJNXMLXbaNiDbodMAbUULpA == null)
				{
					HoUHlaaJNXMLXbaNiDbodMAbUULpA = new Dictionary<IntPtr, List<fDOberhqriNJJJqrQZHnIYJuvCQiA>>(FFLCtkeipiVaQodRerTDrKMmaDkt.scMHHSirPqdumNxgGmzedIlXazcLA);
				}
				return HoUHlaaJNXMLXbaNiDbodMAbUULpA;
			}
			if (oBRZvCmdgSlLvnvWCBKvWFlwAatH == null)
			{
				oBRZvCmdgSlLvnvWCBKvWFlwAatH = new Dictionary<IntPtr, List<fDOberhqriNJJJqrQZHnIYJuvCQiA>>(FFLCtkeipiVaQodRerTDrKMmaDkt.scMHHSirPqdumNxgGmzedIlXazcLA);
			}
			return oBRZvCmdgSlLvnvWCBKvWFlwAatH;
		}
	}

	public static event EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl> vDkrPdnLzCeegKxtwVodfdrsfrGi
	{
		[CompilerGenerated]
		add
		{
			EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl> eventHandler = icjyVFxGnsyrnZBtbYHJVhAWctWT.m_vDkrPdnLzCeegKxtwVodfdrsfrGi;
			EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl> value2 = (EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref icjyVFxGnsyrnZBtbYHJVhAWctWT.m_vDkrPdnLzCeegKxtwVodfdrsfrGi, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl> eventHandler = icjyVFxGnsyrnZBtbYHJVhAWctWT.m_vDkrPdnLzCeegKxtwVodfdrsfrGi;
			EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl> value2 = (EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref icjyVFxGnsyrnZBtbYHJVhAWctWT.m_vDkrPdnLzCeegKxtwVodfdrsfrGi, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public static event EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl> wQBVmoeoLTAnCyKnKzxDVAnItVjW
	{
		[CompilerGenerated]
		add
		{
			EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl> eventHandler = icjyVFxGnsyrnZBtbYHJVhAWctWT.m_wQBVmoeoLTAnCyKnKzxDVAnItVjW;
			EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl> value2 = (EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref icjyVFxGnsyrnZBtbYHJVhAWctWT.m_wQBVmoeoLTAnCyKnKzxDVAnItVjW, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl> eventHandler = icjyVFxGnsyrnZBtbYHJVhAWctWT.m_wQBVmoeoLTAnCyKnKzxDVAnItVjW;
			EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl> value2 = (EventHandler<VeMLQwtpeBHMXmUnrfeejCcViVDl>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref icjyVFxGnsyrnZBtbYHJVhAWctWT.m_wQBVmoeoLTAnCyKnKzxDVAnItVjW, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	static icjyVFxGnsyrnZBtbYHJVhAWctWT()
	{
		AppDomain.CurrentDomain.DomainUnload += CoylMyoxwAEbdtLplxUdtRRzlCCG;
		AppDomain.CurrentDomain.ProcessExit += CoylMyoxwAEbdtLplxUdtRRzlCCG;
	}

	private static void CoylMyoxwAEbdtLplxUdtRRzlCCG(object P_0, EventArgs P_1)
	{
		if (sRleBzhjzvmMDdXnfDtFGQeYBCUzA.gehiJvacQSaaNwXdZunDVCMcMdPtA)
		{
			string value = cKodrWYMNJqpDcPLMGJoQueKCRDe();
			if (!string.IsNullOrEmpty(value))
			{
				Console.WriteLine(value);
			}
		}
	}

	public static void gIzYFhwxjIsrPQvvGajOzfALTqKc(AJRifcVCqqldPIiAPgwvytGljCrw P_0)
	{
		if (P_0 == null || P_0.EEEaoiMKSwLCOBgsTjMBeDlbgYMaA == IntPtr.Zero)
		{
			return;
		}
		lock (NteICkHplacCoAcKLXeiGEFeeJDGb)
		{
			if (!NteICkHplacCoAcKLXeiGEFeeJDGb.TryGetValue(P_0.EEEaoiMKSwLCOBgsTjMBeDlbgYMaA, out var value))
			{
				value = new List<fDOberhqriNJJJqrQZHnIYJuvCQiA>();
				NteICkHplacCoAcKLXeiGEFeeJDGb.Add(P_0.EEEaoiMKSwLCOBgsTjMBeDlbgYMaA, value);
			}
			StringBuilder stringBuilder = new StringBuilder();
			StackFrame[] frames = new StackTrace(3, fNeedFileInfo: true).GetFrames();
			foreach (StackFrame stackFrame in frames)
			{
				if (stackFrame.GetFileLineNumber() != 0)
				{
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "\t{0}({1},{2}) : {3}", stackFrame.GetFileName(), stackFrame.GetFileLineNumber(), stackFrame.GetFileColumnNumber(), stackFrame.GetMethod()).AppendLine();
				}
			}
			value.Add(new fDOberhqriNJJJqrQZHnIYJuvCQiA(DateTime.Now, P_0, stringBuilder.ToString()));
			bLNfcRcdxxzIjPkuIPQvpDZNtEjaA(P_0);
		}
	}

	public static List<fDOberhqriNJJJqrQZHnIYJuvCQiA> gEzagBPCcPcKrMibSzWifLQHhrwV(IntPtr P_0)
	{
		lock (NteICkHplacCoAcKLXeiGEFeeJDGb)
		{
			if (NteICkHplacCoAcKLXeiGEFeeJDGb.TryGetValue(P_0, out var value))
			{
				return new List<fDOberhqriNJJJqrQZHnIYJuvCQiA>(value);
			}
		}
		return new List<fDOberhqriNJJJqrQZHnIYJuvCQiA>();
	}

	public static fDOberhqriNJJJqrQZHnIYJuvCQiA gEzagBPCcPcKrMibSzWifLQHhrwV(AJRifcVCqqldPIiAPgwvytGljCrw P_0)
	{
		lock (NteICkHplacCoAcKLXeiGEFeeJDGb)
		{
			if (NteICkHplacCoAcKLXeiGEFeeJDGb.TryGetValue(P_0.EEEaoiMKSwLCOBgsTjMBeDlbgYMaA, out var value))
			{
				foreach (fDOberhqriNJJJqrQZHnIYJuvCQiA item in value)
				{
					if (item.bIukRKkLMcBYSITRuOxHqcCZXzvr.Target == P_0)
					{
						return item;
					}
				}
			}
		}
		return null;
	}

	public static void xxPKGCpIiPwSXGEdPIGeIeszOKCp(AJRifcVCqqldPIiAPgwvytGljCrw P_0)
	{
		if (P_0 == null || P_0.EEEaoiMKSwLCOBgsTjMBeDlbgYMaA == IntPtr.Zero)
		{
			return;
		}
		lock (NteICkHplacCoAcKLXeiGEFeeJDGb)
		{
			if (!NteICkHplacCoAcKLXeiGEFeeJDGb.TryGetValue(P_0.EEEaoiMKSwLCOBgsTjMBeDlbgYMaA, out var value))
			{
				return;
			}
			for (int num = value.Count - 1; num >= 0; num--)
			{
				fDOberhqriNJJJqrQZHnIYJuvCQiA fDOberhqriNJJJqrQZHnIYJuvCQiA2 = value[num];
				if (fDOberhqriNJJJqrQZHnIYJuvCQiA2.bIukRKkLMcBYSITRuOxHqcCZXzvr.Target == P_0)
				{
					value.RemoveAt(num);
				}
				else if (!fDOberhqriNJJJqrQZHnIYJuvCQiA2.lNhWqqclxSiPHTFkYKuBLfxZoItw)
				{
					value.RemoveAt(num);
				}
			}
			if (value.Count == 0)
			{
				NteICkHplacCoAcKLXeiGEFeeJDGb.Remove(P_0.EEEaoiMKSwLCOBgsTjMBeDlbgYMaA);
			}
			fIkYDywOJZiiKhmcuuwoBliLPVbQA(P_0);
		}
	}

	public static List<fDOberhqriNJJJqrQZHnIYJuvCQiA> bawbgPGFgmVnnsZoPkNcmqfjdCLm()
	{
		List<fDOberhqriNJJJqrQZHnIYJuvCQiA> list = new List<fDOberhqriNJJJqrQZHnIYJuvCQiA>();
		lock (NteICkHplacCoAcKLXeiGEFeeJDGb)
		{
			foreach (List<fDOberhqriNJJJqrQZHnIYJuvCQiA> value in NteICkHplacCoAcKLXeiGEFeeJDGb.Values)
			{
				foreach (fDOberhqriNJJJqrQZHnIYJuvCQiA item in value)
				{
					if (item.lNhWqqclxSiPHTFkYKuBLfxZoItw)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}
	}

	public static string cKodrWYMNJqpDcPLMGJoQueKCRDe()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (fDOberhqriNJJJqrQZHnIYJuvCQiA item in bawbgPGFgmVnnsZoPkNcmqfjdCLm())
		{
			string text = item.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.AppendFormat("[{0}]: {1}", num, text);
				object target = item.bIukRKkLMcBYSITRuOxHqcCZXzvr.Target;
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

	private static void bLNfcRcdxxzIjPkuIPQvpDZNtEjaA(AJRifcVCqqldPIiAPgwvytGljCrw P_0)
	{
		icjyVFxGnsyrnZBtbYHJVhAWctWT.vDkrPdnLzCeegKxtwVodfdrsfrGi?.Invoke(null, new VeMLQwtpeBHMXmUnrfeejCcViVDl(P_0));
	}

	private static void fIkYDywOJZiiKhmcuuwoBliLPVbQA(AJRifcVCqqldPIiAPgwvytGljCrw P_0)
	{
		icjyVFxGnsyrnZBtbYHJVhAWctWT.wQBVmoeoLTAnCyKnKzxDVAnItVjW?.Invoke(null, new VeMLQwtpeBHMXmUnrfeejCcViVDl(P_0));
	}
}
