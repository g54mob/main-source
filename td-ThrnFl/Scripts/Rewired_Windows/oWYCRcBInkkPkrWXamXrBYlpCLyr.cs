using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

internal static class oWYCRcBInkkPkrWXamXrBYlpCLyr
{
	private static Dictionary<IntPtr, List<fNpDOSHYzuYwINORHNORiWgZNgujb>> SddEdfRzYOjUGkCoQEnIPwMPCtwE;

	[ThreadStatic]
	private static Dictionary<IntPtr, List<fNpDOSHYzuYwINORHNORiWgZNgujb>> YhUAXKffHaeoiDWeDRcQRjEnAaaNB;

	[CompilerGenerated]
	private static EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA> m_IhSrBuQIxYoziRUpYPHavEanDsDZ;

	[CompilerGenerated]
	private static EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA> m_BoCxBWEbeggrLAomGbVoofbkZmYO;

	private static Dictionary<IntPtr, List<fNpDOSHYzuYwINORHNORiWgZNgujb>> RFbHcxTNwYJbvBhHvpUSbNkUSsPV
	{
		get
		{
			if (ayQzvKBeptCbAgHBymutTQPjmgsBb.gIgzqIubcvxwyRkhOOUeSycwJwBo)
			{
				if (YhUAXKffHaeoiDWeDRcQRjEnAaaNB == null)
				{
					YhUAXKffHaeoiDWeDRcQRjEnAaaNB = new Dictionary<IntPtr, List<fNpDOSHYzuYwINORHNORiWgZNgujb>>(XnsNbHWsjuTlJIHprKDjdRlLpbSj.miMXIiQporaiTSODwXPAJnvMerXkA);
				}
				return YhUAXKffHaeoiDWeDRcQRjEnAaaNB;
			}
			if (SddEdfRzYOjUGkCoQEnIPwMPCtwE == null)
			{
				SddEdfRzYOjUGkCoQEnIPwMPCtwE = new Dictionary<IntPtr, List<fNpDOSHYzuYwINORHNORiWgZNgujb>>(XnsNbHWsjuTlJIHprKDjdRlLpbSj.miMXIiQporaiTSODwXPAJnvMerXkA);
			}
			return SddEdfRzYOjUGkCoQEnIPwMPCtwE;
		}
	}

	public static event EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA> IhSrBuQIxYoziRUpYPHavEanDsDZ
	{
		[CompilerGenerated]
		add
		{
			EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA> eventHandler = oWYCRcBInkkPkrWXamXrBYlpCLyr.m_IhSrBuQIxYoziRUpYPHavEanDsDZ;
			EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA> value2 = (EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref oWYCRcBInkkPkrWXamXrBYlpCLyr.m_IhSrBuQIxYoziRUpYPHavEanDsDZ, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA> eventHandler = oWYCRcBInkkPkrWXamXrBYlpCLyr.m_IhSrBuQIxYoziRUpYPHavEanDsDZ;
			EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA> value2 = (EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref oWYCRcBInkkPkrWXamXrBYlpCLyr.m_IhSrBuQIxYoziRUpYPHavEanDsDZ, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public static event EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA> BoCxBWEbeggrLAomGbVoofbkZmYO
	{
		[CompilerGenerated]
		add
		{
			EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA> eventHandler = oWYCRcBInkkPkrWXamXrBYlpCLyr.m_BoCxBWEbeggrLAomGbVoofbkZmYO;
			EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA> value2 = (EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref oWYCRcBInkkPkrWXamXrBYlpCLyr.m_BoCxBWEbeggrLAomGbVoofbkZmYO, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA> eventHandler = oWYCRcBInkkPkrWXamXrBYlpCLyr.m_BoCxBWEbeggrLAomGbVoofbkZmYO;
			EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA> value2 = (EventHandler<FmldjJFkuBeoACeDiroWrePybGpcA>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref oWYCRcBInkkPkrWXamXrBYlpCLyr.m_BoCxBWEbeggrLAomGbVoofbkZmYO, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	static oWYCRcBInkkPkrWXamXrBYlpCLyr()
	{
		AppDomain.CurrentDomain.DomainUnload += cgfmMQwavEUYbfRNSnWvrRfBmdTW;
		AppDomain.CurrentDomain.ProcessExit += cgfmMQwavEUYbfRNSnWvrRfBmdTW;
	}

	private static void cgfmMQwavEUYbfRNSnWvrRfBmdTW(object P_0, EventArgs P_1)
	{
		if (ayQzvKBeptCbAgHBymutTQPjmgsBb.XclCLvZhrQoKlulDkAwKecjszBBN)
		{
			string value = eTIGbFFTCmGREkXVzqPtuXvUMmnFA();
			if (!string.IsNullOrEmpty(value))
			{
				Console.WriteLine(value);
			}
		}
	}

	public static void DOMCeXbYAbSlGpmmREniiJNiMnaXA(MSoQGDbwmmEgYqaQEfOTqzjYuOHC P_0)
	{
		if (P_0 == null || P_0.odpdeHVpSKtJOjaxhiXZmqovsVjq == IntPtr.Zero)
		{
			return;
		}
		lock (RFbHcxTNwYJbvBhHvpUSbNkUSsPV)
		{
			if (!RFbHcxTNwYJbvBhHvpUSbNkUSsPV.TryGetValue(P_0.odpdeHVpSKtJOjaxhiXZmqovsVjq, out var value))
			{
				value = new List<fNpDOSHYzuYwINORHNORiWgZNgujb>();
				RFbHcxTNwYJbvBhHvpUSbNkUSsPV.Add(P_0.odpdeHVpSKtJOjaxhiXZmqovsVjq, value);
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
			value.Add(new fNpDOSHYzuYwINORHNORiWgZNgujb(DateTime.Now, P_0, stringBuilder.ToString()));
			oHKDZvEYxdzEoNnAvmHNXpxaYmjC(P_0);
		}
	}

	public static List<fNpDOSHYzuYwINORHNORiWgZNgujb> XNSmCrhcEldOwhcjqeVEWMNwikl(IntPtr P_0)
	{
		lock (RFbHcxTNwYJbvBhHvpUSbNkUSsPV)
		{
			if (RFbHcxTNwYJbvBhHvpUSbNkUSsPV.TryGetValue(P_0, out var value))
			{
				return new List<fNpDOSHYzuYwINORHNORiWgZNgujb>(value);
			}
		}
		return new List<fNpDOSHYzuYwINORHNORiWgZNgujb>();
	}

	public static fNpDOSHYzuYwINORHNORiWgZNgujb pwhkAjnkutDytPkBFMykDjcXVowB(MSoQGDbwmmEgYqaQEfOTqzjYuOHC P_0)
	{
		lock (RFbHcxTNwYJbvBhHvpUSbNkUSsPV)
		{
			if (RFbHcxTNwYJbvBhHvpUSbNkUSsPV.TryGetValue(P_0.odpdeHVpSKtJOjaxhiXZmqovsVjq, out var value))
			{
				foreach (fNpDOSHYzuYwINORHNORiWgZNgujb item in value)
				{
					if (item.xaZSuSLVKFlkBBeudNiTIadkWxs.Target == P_0)
					{
						return item;
					}
				}
			}
		}
		return null;
	}

	public static void JkcXcBSdovsXwVBHNGeoWExWivBf(MSoQGDbwmmEgYqaQEfOTqzjYuOHC P_0)
	{
		if (P_0 == null || P_0.odpdeHVpSKtJOjaxhiXZmqovsVjq == IntPtr.Zero)
		{
			return;
		}
		lock (RFbHcxTNwYJbvBhHvpUSbNkUSsPV)
		{
			if (!RFbHcxTNwYJbvBhHvpUSbNkUSsPV.TryGetValue(P_0.odpdeHVpSKtJOjaxhiXZmqovsVjq, out var value))
			{
				return;
			}
			for (int num = value.Count - 1; num >= 0; num--)
			{
				fNpDOSHYzuYwINORHNORiWgZNgujb fNpDOSHYzuYwINORHNORiWgZNgujb2 = value[num];
				if (fNpDOSHYzuYwINORHNORiWgZNgujb2.xaZSuSLVKFlkBBeudNiTIadkWxs.Target == P_0)
				{
					value.RemoveAt(num);
				}
				else if (!fNpDOSHYzuYwINORHNORiWgZNgujb2.yDOOGqukMomCCMMlUGblqJfiAwJw)
				{
					value.RemoveAt(num);
				}
			}
			if (value.Count == 0)
			{
				RFbHcxTNwYJbvBhHvpUSbNkUSsPV.Remove(P_0.odpdeHVpSKtJOjaxhiXZmqovsVjq);
			}
			fpLcCBQcajDqCIloIoPXCRoOwWclA(P_0);
		}
	}

	public static List<fNpDOSHYzuYwINORHNORiWgZNgujb> sUaaVxGnoCQbTxGiLCsupzOmQCeT()
	{
		List<fNpDOSHYzuYwINORHNORiWgZNgujb> list = new List<fNpDOSHYzuYwINORHNORiWgZNgujb>();
		lock (RFbHcxTNwYJbvBhHvpUSbNkUSsPV)
		{
			foreach (List<fNpDOSHYzuYwINORHNORiWgZNgujb> value in RFbHcxTNwYJbvBhHvpUSbNkUSsPV.Values)
			{
				foreach (fNpDOSHYzuYwINORHNORiWgZNgujb item in value)
				{
					if (item.yDOOGqukMomCCMMlUGblqJfiAwJw)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}
	}

	public static string eTIGbFFTCmGREkXVzqPtuXvUMmnFA()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (fNpDOSHYzuYwINORHNORiWgZNgujb item in sUaaVxGnoCQbTxGiLCsupzOmQCeT())
		{
			string text = item.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.AppendFormat("[{0}]: {1}", num, text);
				object target = item.xaZSuSLVKFlkBBeudNiTIadkWxs.Target;
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

	private static void oHKDZvEYxdzEoNnAvmHNXpxaYmjC(MSoQGDbwmmEgYqaQEfOTqzjYuOHC P_0)
	{
		oWYCRcBInkkPkrWXamXrBYlpCLyr.IhSrBuQIxYoziRUpYPHavEanDsDZ?.Invoke(null, new FmldjJFkuBeoACeDiroWrePybGpcA(P_0));
	}

	private static void fpLcCBQcajDqCIloIoPXCRoOwWclA(MSoQGDbwmmEgYqaQEfOTqzjYuOHC P_0)
	{
		oWYCRcBInkkPkrWXamXrBYlpCLyr.BoCxBWEbeggrLAomGbVoofbkZmYO?.Invoke(null, new FmldjJFkuBeoACeDiroWrePybGpcA(P_0));
	}
}
