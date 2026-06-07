using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

internal static class wuTBNeZbNBPFdhnIaqBRLrFTlmGd
{
	private static Dictionary<IntPtr, List<jlaiJdAMfHFcxKQzVfXfSGqdhKQX>> eTdiULKextSTDFGdXznhKWytAtfc;

	[ThreadStatic]
	private static Dictionary<IntPtr, List<jlaiJdAMfHFcxKQzVfXfSGqdhKQX>> VzwYAsMEVaMolHAPfTFcYMfuaSZo;

	[CompilerGenerated]
	private static EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc> m_pJKEHbRxHrVgAqBjpdMhvUOhfzCH;

	[CompilerGenerated]
	private static EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc> m_eWbjDmQbZowEgAOhFFPLTXMJKPlU;

	private static Dictionary<IntPtr, List<jlaiJdAMfHFcxKQzVfXfSGqdhKQX>> LbWVvwbUhTcnIGiAMeWqFEerSRLwA
	{
		get
		{
			if (qXVrmlDmxYBrxRanyFRVJMJFvMUCA.mDIGgFRuLxMdGpyRaxmujpXGPiil)
			{
				if (VzwYAsMEVaMolHAPfTFcYMfuaSZo == null)
				{
					VzwYAsMEVaMolHAPfTFcYMfuaSZo = new Dictionary<IntPtr, List<jlaiJdAMfHFcxKQzVfXfSGqdhKQX>>(TMbYWaAxHPBnyEZgvpDJdfxfVlsD.gJsNcONkPLhPCNtuJITwMZKAcjaR);
				}
				return VzwYAsMEVaMolHAPfTFcYMfuaSZo;
			}
			if (eTdiULKextSTDFGdXznhKWytAtfc == null)
			{
				eTdiULKextSTDFGdXznhKWytAtfc = new Dictionary<IntPtr, List<jlaiJdAMfHFcxKQzVfXfSGqdhKQX>>(TMbYWaAxHPBnyEZgvpDJdfxfVlsD.gJsNcONkPLhPCNtuJITwMZKAcjaR);
			}
			return eTdiULKextSTDFGdXznhKWytAtfc;
		}
	}

	public static event EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc> pJKEHbRxHrVgAqBjpdMhvUOhfzCH
	{
		[CompilerGenerated]
		add
		{
			EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc> eventHandler = wuTBNeZbNBPFdhnIaqBRLrFTlmGd.m_pJKEHbRxHrVgAqBjpdMhvUOhfzCH;
			EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc> value2 = (EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref wuTBNeZbNBPFdhnIaqBRLrFTlmGd.m_pJKEHbRxHrVgAqBjpdMhvUOhfzCH, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc> eventHandler = wuTBNeZbNBPFdhnIaqBRLrFTlmGd.m_pJKEHbRxHrVgAqBjpdMhvUOhfzCH;
			EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc> value2 = (EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref wuTBNeZbNBPFdhnIaqBRLrFTlmGd.m_pJKEHbRxHrVgAqBjpdMhvUOhfzCH, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public static event EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc> eWbjDmQbZowEgAOhFFPLTXMJKPlU
	{
		[CompilerGenerated]
		add
		{
			EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc> eventHandler = wuTBNeZbNBPFdhnIaqBRLrFTlmGd.m_eWbjDmQbZowEgAOhFFPLTXMJKPlU;
			EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc> value2 = (EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref wuTBNeZbNBPFdhnIaqBRLrFTlmGd.m_eWbjDmQbZowEgAOhFFPLTXMJKPlU, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc> eventHandler = wuTBNeZbNBPFdhnIaqBRLrFTlmGd.m_eWbjDmQbZowEgAOhFFPLTXMJKPlU;
			EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc> value2 = (EventHandler<VJasHeRqCkkXzEzBqFisdZTYsVtc>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref wuTBNeZbNBPFdhnIaqBRLrFTlmGd.m_eWbjDmQbZowEgAOhFFPLTXMJKPlU, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	static wuTBNeZbNBPFdhnIaqBRLrFTlmGd()
	{
		AppDomain.CurrentDomain.DomainUnload += ODMWSkMDeftTPRufuXQznRkydUOh;
		AppDomain.CurrentDomain.ProcessExit += ODMWSkMDeftTPRufuXQznRkydUOh;
	}

	private static void ODMWSkMDeftTPRufuXQznRkydUOh(object P_0, EventArgs P_1)
	{
		if (qXVrmlDmxYBrxRanyFRVJMJFvMUCA.cLHNavSxEvrDbbZbODTFYFlrAlBjA)
		{
			string value = gtQASEaYKmNTxCSNNiikOFFVNODY();
			if (!string.IsNullOrEmpty(value))
			{
				Console.WriteLine(value);
			}
		}
	}

	public static void qTXvdJUZfrPgRctjVQHnliUYThmm(YutCLanOuXTAhakKQUOtqCxgUWzR P_0)
	{
		if (P_0 == null || P_0.GMaPHoiZAJyngdXeSoVFwLOeWHKm == IntPtr.Zero)
		{
			return;
		}
		lock (LbWVvwbUhTcnIGiAMeWqFEerSRLwA)
		{
			if (!LbWVvwbUhTcnIGiAMeWqFEerSRLwA.TryGetValue(P_0.GMaPHoiZAJyngdXeSoVFwLOeWHKm, out var value))
			{
				value = new List<jlaiJdAMfHFcxKQzVfXfSGqdhKQX>();
				LbWVvwbUhTcnIGiAMeWqFEerSRLwA.Add(P_0.GMaPHoiZAJyngdXeSoVFwLOeWHKm, value);
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
			value.Add(new jlaiJdAMfHFcxKQzVfXfSGqdhKQX(DateTime.Now, P_0, stringBuilder.ToString()));
			jqxlTRBIxMdhDGWcHrkncBiUOGhcb(P_0);
		}
	}

	public static List<jlaiJdAMfHFcxKQzVfXfSGqdhKQX> guJPZPzmvydITgrIPqsqrdiQdTke(IntPtr P_0)
	{
		lock (LbWVvwbUhTcnIGiAMeWqFEerSRLwA)
		{
			if (LbWVvwbUhTcnIGiAMeWqFEerSRLwA.TryGetValue(P_0, out var value))
			{
				return new List<jlaiJdAMfHFcxKQzVfXfSGqdhKQX>(value);
			}
		}
		return new List<jlaiJdAMfHFcxKQzVfXfSGqdhKQX>();
	}

	public static jlaiJdAMfHFcxKQzVfXfSGqdhKQX guJPZPzmvydITgrIPqsqrdiQdTke(YutCLanOuXTAhakKQUOtqCxgUWzR P_0)
	{
		lock (LbWVvwbUhTcnIGiAMeWqFEerSRLwA)
		{
			if (LbWVvwbUhTcnIGiAMeWqFEerSRLwA.TryGetValue(P_0.GMaPHoiZAJyngdXeSoVFwLOeWHKm, out var value))
			{
				foreach (jlaiJdAMfHFcxKQzVfXfSGqdhKQX item in value)
				{
					if (item.tSGuyAQuCDoxkkrXvZXPyBpWAfvW.Target == P_0)
					{
						return item;
					}
				}
			}
		}
		return null;
	}

	public static void tMzhMMJacoJmdqapOojeMMPaYVCF(YutCLanOuXTAhakKQUOtqCxgUWzR P_0)
	{
		if (P_0 == null || P_0.GMaPHoiZAJyngdXeSoVFwLOeWHKm == IntPtr.Zero)
		{
			return;
		}
		lock (LbWVvwbUhTcnIGiAMeWqFEerSRLwA)
		{
			if (!LbWVvwbUhTcnIGiAMeWqFEerSRLwA.TryGetValue(P_0.GMaPHoiZAJyngdXeSoVFwLOeWHKm, out var value))
			{
				return;
			}
			for (int num = value.Count - 1; num >= 0; num--)
			{
				jlaiJdAMfHFcxKQzVfXfSGqdhKQX jlaiJdAMfHFcxKQzVfXfSGqdhKQX2 = value[num];
				if (jlaiJdAMfHFcxKQzVfXfSGqdhKQX2.tSGuyAQuCDoxkkrXvZXPyBpWAfvW.Target == P_0)
				{
					value.RemoveAt(num);
				}
				else if (!jlaiJdAMfHFcxKQzVfXfSGqdhKQX2.hwLkZcStndTkbbwaHqMDBwQCdCvu)
				{
					value.RemoveAt(num);
				}
			}
			if (value.Count == 0)
			{
				LbWVvwbUhTcnIGiAMeWqFEerSRLwA.Remove(P_0.GMaPHoiZAJyngdXeSoVFwLOeWHKm);
			}
			nnQFuoYwFiKPuWckvtQwhePWwFvw(P_0);
		}
	}

	public static List<jlaiJdAMfHFcxKQzVfXfSGqdhKQX> bLMCSBwNmZkmFQcaCWCmuRSwQdXN()
	{
		List<jlaiJdAMfHFcxKQzVfXfSGqdhKQX> list = new List<jlaiJdAMfHFcxKQzVfXfSGqdhKQX>();
		lock (LbWVvwbUhTcnIGiAMeWqFEerSRLwA)
		{
			foreach (List<jlaiJdAMfHFcxKQzVfXfSGqdhKQX> value in LbWVvwbUhTcnIGiAMeWqFEerSRLwA.Values)
			{
				foreach (jlaiJdAMfHFcxKQzVfXfSGqdhKQX item in value)
				{
					if (item.hwLkZcStndTkbbwaHqMDBwQCdCvu)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}
	}

	public static string gtQASEaYKmNTxCSNNiikOFFVNODY()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (jlaiJdAMfHFcxKQzVfXfSGqdhKQX item in bLMCSBwNmZkmFQcaCWCmuRSwQdXN())
		{
			string text = item.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.AppendFormat("[{0}]: {1}", num, text);
				object target = item.tSGuyAQuCDoxkkrXvZXPyBpWAfvW.Target;
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

	private static void jqxlTRBIxMdhDGWcHrkncBiUOGhcb(YutCLanOuXTAhakKQUOtqCxgUWzR P_0)
	{
		wuTBNeZbNBPFdhnIaqBRLrFTlmGd.pJKEHbRxHrVgAqBjpdMhvUOhfzCH?.Invoke(null, new VJasHeRqCkkXzEzBqFisdZTYsVtc(P_0));
	}

	private static void nnQFuoYwFiKPuWckvtQwhePWwFvw(YutCLanOuXTAhakKQUOtqCxgUWzR P_0)
	{
		wuTBNeZbNBPFdhnIaqBRLrFTlmGd.eWbjDmQbZowEgAOhFFPLTXMJKPlU?.Invoke(null, new VJasHeRqCkkXzEzBqFisdZTYsVtc(P_0));
	}
}
