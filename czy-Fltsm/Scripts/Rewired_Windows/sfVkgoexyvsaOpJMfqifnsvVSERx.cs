using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

internal static class sfVkgoexyvsaOpJMfqifnsvVSERx
{
	private static Dictionary<IntPtr, List<nyEyEVpwtBLysGWCTfBveczkhVhA>> IuqNkhiBBLpOwkybDdlWvnWjeLJs;

	[ThreadStatic]
	private static Dictionary<IntPtr, List<nyEyEVpwtBLysGWCTfBveczkhVhA>> SHYnQOwEtjHIGCfAUDQFxQcPdVW;

	[CompilerGenerated]
	private static EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY> m_OvRjmujugNMdYFmqPmNwDBsDtHsJ;

	[CompilerGenerated]
	private static EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY> m_RBNSTUdchtDOnjQvFQekwYjEEbdmA;

	private static Dictionary<IntPtr, List<nyEyEVpwtBLysGWCTfBveczkhVhA>> TNkSxlozvHSlLJASwdnQDXcyncij
	{
		get
		{
			if (eMRFJEccocWfyHvIpHNvgZTHdrJg.aTnSxEHfMeLGEFgFPxVwouSEzLye)
			{
				if (SHYnQOwEtjHIGCfAUDQFxQcPdVW == null)
				{
					SHYnQOwEtjHIGCfAUDQFxQcPdVW = new Dictionary<IntPtr, List<nyEyEVpwtBLysGWCTfBveczkhVhA>>(VehLvZhFwzyabSRceWtfTlvngyxq.kuXkGinAfwFHjIIAbkWEtmpgeNeG);
				}
				return SHYnQOwEtjHIGCfAUDQFxQcPdVW;
			}
			if (IuqNkhiBBLpOwkybDdlWvnWjeLJs == null)
			{
				IuqNkhiBBLpOwkybDdlWvnWjeLJs = new Dictionary<IntPtr, List<nyEyEVpwtBLysGWCTfBveczkhVhA>>(VehLvZhFwzyabSRceWtfTlvngyxq.kuXkGinAfwFHjIIAbkWEtmpgeNeG);
			}
			return IuqNkhiBBLpOwkybDdlWvnWjeLJs;
		}
	}

	public static event EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY> OvRjmujugNMdYFmqPmNwDBsDtHsJ
	{
		[CompilerGenerated]
		add
		{
			EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY> eventHandler = sfVkgoexyvsaOpJMfqifnsvVSERx.m_OvRjmujugNMdYFmqPmNwDBsDtHsJ;
			EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY> value2 = (EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref sfVkgoexyvsaOpJMfqifnsvVSERx.m_OvRjmujugNMdYFmqPmNwDBsDtHsJ, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY> eventHandler = sfVkgoexyvsaOpJMfqifnsvVSERx.m_OvRjmujugNMdYFmqPmNwDBsDtHsJ;
			EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY> value2 = (EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref sfVkgoexyvsaOpJMfqifnsvVSERx.m_OvRjmujugNMdYFmqPmNwDBsDtHsJ, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public static event EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY> RBNSTUdchtDOnjQvFQekwYjEEbdmA
	{
		[CompilerGenerated]
		add
		{
			EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY> eventHandler = sfVkgoexyvsaOpJMfqifnsvVSERx.m_RBNSTUdchtDOnjQvFQekwYjEEbdmA;
			EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY> value2 = (EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref sfVkgoexyvsaOpJMfqifnsvVSERx.m_RBNSTUdchtDOnjQvFQekwYjEEbdmA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY> eventHandler = sfVkgoexyvsaOpJMfqifnsvVSERx.m_RBNSTUdchtDOnjQvFQekwYjEEbdmA;
			EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY> value2 = (EventHandler<RYwIDTaNdYFLqfCOftJMJFZWrHUY>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref sfVkgoexyvsaOpJMfqifnsvVSERx.m_RBNSTUdchtDOnjQvFQekwYjEEbdmA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	static sfVkgoexyvsaOpJMfqifnsvVSERx()
	{
		AppDomain.CurrentDomain.DomainUnload += ylkocOHVsXbHFxFQZElvPMrpsmgR;
		AppDomain.CurrentDomain.ProcessExit += ylkocOHVsXbHFxFQZElvPMrpsmgR;
	}

	private static void ylkocOHVsXbHFxFQZElvPMrpsmgR(object P_0, EventArgs P_1)
	{
		if (eMRFJEccocWfyHvIpHNvgZTHdrJg.PUiGldsbeBPvDyVIbuBSYGvWCOsbA)
		{
			string value = wVZBADuTApeaaVHOsaVjjBpilqGl();
			if (!string.IsNullOrEmpty(value))
			{
				Console.WriteLine(value);
			}
		}
	}

	public static void PbDLWZKTJifAklBzEOCsjzNIneXs(MndfuDfWnbszkTmnTPSZnWvaJpehA P_0)
	{
		if (P_0 == null || P_0.cOaLXRsqVRuSojLsgpkROlcJOCEr == IntPtr.Zero)
		{
			return;
		}
		lock (TNkSxlozvHSlLJASwdnQDXcyncij)
		{
			if (!TNkSxlozvHSlLJASwdnQDXcyncij.TryGetValue(P_0.cOaLXRsqVRuSojLsgpkROlcJOCEr, out var value))
			{
				value = new List<nyEyEVpwtBLysGWCTfBveczkhVhA>();
				TNkSxlozvHSlLJASwdnQDXcyncij.Add(P_0.cOaLXRsqVRuSojLsgpkROlcJOCEr, value);
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
			value.Add(new nyEyEVpwtBLysGWCTfBveczkhVhA(DateTime.Now, P_0, stringBuilder.ToString()));
			uXXGfBJzLgjWmPZwkgFRgrrQoRUVA(P_0);
		}
	}

	public static List<nyEyEVpwtBLysGWCTfBveczkhVhA> FPGBoCBQoXwMyHunwXHXmiMhYlDxA(IntPtr P_0)
	{
		lock (TNkSxlozvHSlLJASwdnQDXcyncij)
		{
			if (TNkSxlozvHSlLJASwdnQDXcyncij.TryGetValue(P_0, out var value))
			{
				return new List<nyEyEVpwtBLysGWCTfBveczkhVhA>(value);
			}
		}
		return new List<nyEyEVpwtBLysGWCTfBveczkhVhA>();
	}

	public static nyEyEVpwtBLysGWCTfBveczkhVhA flcgSWkGdghwYKBjSuxablfrgEDnA(MndfuDfWnbszkTmnTPSZnWvaJpehA P_0)
	{
		lock (TNkSxlozvHSlLJASwdnQDXcyncij)
		{
			if (TNkSxlozvHSlLJASwdnQDXcyncij.TryGetValue(P_0.cOaLXRsqVRuSojLsgpkROlcJOCEr, out var value))
			{
				foreach (nyEyEVpwtBLysGWCTfBveczkhVhA item in value)
				{
					if (item.rSlZfmfBULwcGLLvbPCizKkFaROgA.Target == P_0)
					{
						return item;
					}
				}
			}
		}
		return null;
	}

	public static void FEjwzRvadeEXOZeMYjzkgyxcrfoVA(MndfuDfWnbszkTmnTPSZnWvaJpehA P_0)
	{
		if (P_0 == null || P_0.cOaLXRsqVRuSojLsgpkROlcJOCEr == IntPtr.Zero)
		{
			return;
		}
		lock (TNkSxlozvHSlLJASwdnQDXcyncij)
		{
			if (!TNkSxlozvHSlLJASwdnQDXcyncij.TryGetValue(P_0.cOaLXRsqVRuSojLsgpkROlcJOCEr, out var value))
			{
				return;
			}
			for (int num = value.Count - 1; num >= 0; num--)
			{
				nyEyEVpwtBLysGWCTfBveczkhVhA nyEyEVpwtBLysGWCTfBveczkhVhA2 = value[num];
				if (nyEyEVpwtBLysGWCTfBveczkhVhA2.rSlZfmfBULwcGLLvbPCizKkFaROgA.Target == P_0)
				{
					value.RemoveAt(num);
				}
				else if (!nyEyEVpwtBLysGWCTfBveczkhVhA2.elXsmaTtFphLcMbeRALpWIxWnCoK)
				{
					value.RemoveAt(num);
				}
			}
			if (value.Count == 0)
			{
				TNkSxlozvHSlLJASwdnQDXcyncij.Remove(P_0.cOaLXRsqVRuSojLsgpkROlcJOCEr);
			}
			nAUmyJfXlubTsnHxRheHpakoSXRP(P_0);
		}
	}

	public static List<nyEyEVpwtBLysGWCTfBveczkhVhA> glrRAtrapHCjnAhfIgZqGRGIYHVVB()
	{
		List<nyEyEVpwtBLysGWCTfBveczkhVhA> list = new List<nyEyEVpwtBLysGWCTfBveczkhVhA>();
		lock (TNkSxlozvHSlLJASwdnQDXcyncij)
		{
			foreach (List<nyEyEVpwtBLysGWCTfBveczkhVhA> value in TNkSxlozvHSlLJASwdnQDXcyncij.Values)
			{
				foreach (nyEyEVpwtBLysGWCTfBveczkhVhA item in value)
				{
					if (item.elXsmaTtFphLcMbeRALpWIxWnCoK)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}
	}

	public static string wVZBADuTApeaaVHOsaVjjBpilqGl()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (nyEyEVpwtBLysGWCTfBveczkhVhA item in glrRAtrapHCjnAhfIgZqGRGIYHVVB())
		{
			string text = item.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.AppendFormat("[{0}]: {1}", num, text);
				object target = item.rSlZfmfBULwcGLLvbPCizKkFaROgA.Target;
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

	private static void uXXGfBJzLgjWmPZwkgFRgrrQoRUVA(MndfuDfWnbszkTmnTPSZnWvaJpehA P_0)
	{
		sfVkgoexyvsaOpJMfqifnsvVSERx.OvRjmujugNMdYFmqPmNwDBsDtHsJ?.Invoke(null, new RYwIDTaNdYFLqfCOftJMJFZWrHUY(P_0));
	}

	private static void nAUmyJfXlubTsnHxRheHpakoSXRP(MndfuDfWnbszkTmnTPSZnWvaJpehA P_0)
	{
		sfVkgoexyvsaOpJMfqifnsvVSERx.RBNSTUdchtDOnjQvFQekwYjEEbdmA?.Invoke(null, new RYwIDTaNdYFLqfCOftJMJFZWrHUY(P_0));
	}
}
