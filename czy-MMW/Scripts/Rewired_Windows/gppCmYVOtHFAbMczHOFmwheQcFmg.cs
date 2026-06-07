using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

internal static class gppCmYVOtHFAbMczHOFmwheQcFmg
{
	private static Dictionary<IntPtr, List<tRWrAqQFELdkPdRwaGBSevaiiZkVA>> IWkUJZQxxOrRRhPlIPFeuQyczqmA;

	[ThreadStatic]
	private static Dictionary<IntPtr, List<tRWrAqQFELdkPdRwaGBSevaiiZkVA>> MKxQPwrMsXSidrLXwAvJMvMtZXeQ;

	[CompilerGenerated]
	private static EventHandler<JJShEpFJZgwnJlueFjPTWiFDpPhm> EIfbFYECQbozhekUtBIfXQeWDRXGb;

	[CompilerGenerated]
	private static EventHandler<JJShEpFJZgwnJlueFjPTWiFDpPhm> DgxzcTAVwHbKXbLNdUfoVxFJXSoB;

	private static Dictionary<IntPtr, List<tRWrAqQFELdkPdRwaGBSevaiiZkVA>> BxGYwLFYXndhgyxaUZdFSRyzFXJd
	{
		get
		{
			if (kcdifiZFMUezHgkaNInqAbRSrDkFb.uHZfasoiBWYkpsHUnYNvhLoVBXRgA)
			{
				if (MKxQPwrMsXSidrLXwAvJMvMtZXeQ == null)
				{
					MKxQPwrMsXSidrLXwAvJMvMtZXeQ = new Dictionary<IntPtr, List<tRWrAqQFELdkPdRwaGBSevaiiZkVA>>(XWFDxvACNZLQrzMlCZymEbciAKSd.khfeYMUZPYaIIdKuXCxPccnvKORF);
				}
				return MKxQPwrMsXSidrLXwAvJMvMtZXeQ;
			}
			if (IWkUJZQxxOrRRhPlIPFeuQyczqmA == null)
			{
				IWkUJZQxxOrRRhPlIPFeuQyczqmA = new Dictionary<IntPtr, List<tRWrAqQFELdkPdRwaGBSevaiiZkVA>>(XWFDxvACNZLQrzMlCZymEbciAKSd.khfeYMUZPYaIIdKuXCxPccnvKORF);
			}
			return IWkUJZQxxOrRRhPlIPFeuQyczqmA;
		}
	}

	static gppCmYVOtHFAbMczHOFmwheQcFmg()
	{
		AppDomain.CurrentDomain.DomainUnload += amMFEuCsOpqIaWGchAFwlGxeOYLAA;
		AppDomain.CurrentDomain.ProcessExit += amMFEuCsOpqIaWGchAFwlGxeOYLAA;
	}

	private static void amMFEuCsOpqIaWGchAFwlGxeOYLAA(object P_0, EventArgs P_1)
	{
		if (kcdifiZFMUezHgkaNInqAbRSrDkFb.XFYPrRDOflGFoVmuVnfZTjPVseLh)
		{
			string value = sLzpnzFsjLhPRinqUQIosvvrgZvP();
			if (!string.IsNullOrEmpty(value))
			{
				Console.WriteLine(value);
			}
		}
	}

	public static void LhvyDlrdhWtAPQDHmgwroJJTCSkl(WDLIqztsTFKKRNeHzsLEXCzxPiJg P_0)
	{
		if (P_0 == null || P_0.sFCfjzNbPtpSBOIOUASCBueAerzc == IntPtr.Zero)
		{
			return;
		}
		lock (BxGYwLFYXndhgyxaUZdFSRyzFXJd)
		{
			if (!BxGYwLFYXndhgyxaUZdFSRyzFXJd.TryGetValue(P_0.sFCfjzNbPtpSBOIOUASCBueAerzc, out var value))
			{
				value = new List<tRWrAqQFELdkPdRwaGBSevaiiZkVA>();
				BxGYwLFYXndhgyxaUZdFSRyzFXJd.Add(P_0.sFCfjzNbPtpSBOIOUASCBueAerzc, value);
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
			value.Add(new tRWrAqQFELdkPdRwaGBSevaiiZkVA(DateTime.Now, P_0, stringBuilder.ToString()));
			iNvNgpMLnYzNPwkKIzrYocxRnljI(P_0);
		}
	}

	public static tRWrAqQFELdkPdRwaGBSevaiiZkVA bnUiYmvERATAvkWZqHIjqHxuabok(WDLIqztsTFKKRNeHzsLEXCzxPiJg P_0)
	{
		lock (BxGYwLFYXndhgyxaUZdFSRyzFXJd)
		{
			if (BxGYwLFYXndhgyxaUZdFSRyzFXJd.TryGetValue(P_0.sFCfjzNbPtpSBOIOUASCBueAerzc, out var value))
			{
				foreach (tRWrAqQFELdkPdRwaGBSevaiiZkVA item in value)
				{
					if (item.tfTXCCAHqxDXnaBDPHkhaWuIdhbT.Target == P_0)
					{
						return item;
					}
				}
			}
		}
		return null;
	}

	public static void JMJcDfWULMdarguwwmFhtzbbJRNq(WDLIqztsTFKKRNeHzsLEXCzxPiJg P_0)
	{
		if (P_0 == null || P_0.sFCfjzNbPtpSBOIOUASCBueAerzc == IntPtr.Zero)
		{
			return;
		}
		lock (BxGYwLFYXndhgyxaUZdFSRyzFXJd)
		{
			if (!BxGYwLFYXndhgyxaUZdFSRyzFXJd.TryGetValue(P_0.sFCfjzNbPtpSBOIOUASCBueAerzc, out var value))
			{
				return;
			}
			for (int num = value.Count - 1; num >= 0; num--)
			{
				tRWrAqQFELdkPdRwaGBSevaiiZkVA tRWrAqQFELdkPdRwaGBSevaiiZkVA2 = value[num];
				if (tRWrAqQFELdkPdRwaGBSevaiiZkVA2.tfTXCCAHqxDXnaBDPHkhaWuIdhbT.Target == P_0)
				{
					value.RemoveAt(num);
				}
				else if (!tRWrAqQFELdkPdRwaGBSevaiiZkVA2.uafIYSdcbVUCZqfGxOkybPriLZRsb)
				{
					value.RemoveAt(num);
				}
			}
			if (value.Count == 0)
			{
				BxGYwLFYXndhgyxaUZdFSRyzFXJd.Remove(P_0.sFCfjzNbPtpSBOIOUASCBueAerzc);
			}
			nHaSDzOcJQyjXOJHfWvGkqullGwg(P_0);
		}
	}

	public static List<tRWrAqQFELdkPdRwaGBSevaiiZkVA> cdVyNoCPHvECtSHBcvfwYUIPlwpb()
	{
		List<tRWrAqQFELdkPdRwaGBSevaiiZkVA> list = new List<tRWrAqQFELdkPdRwaGBSevaiiZkVA>();
		lock (BxGYwLFYXndhgyxaUZdFSRyzFXJd)
		{
			foreach (List<tRWrAqQFELdkPdRwaGBSevaiiZkVA> value in BxGYwLFYXndhgyxaUZdFSRyzFXJd.Values)
			{
				foreach (tRWrAqQFELdkPdRwaGBSevaiiZkVA item in value)
				{
					if (item.uafIYSdcbVUCZqfGxOkybPriLZRsb)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}
	}

	public static string sLzpnzFsjLhPRinqUQIosvvrgZvP()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (tRWrAqQFELdkPdRwaGBSevaiiZkVA item in cdVyNoCPHvECtSHBcvfwYUIPlwpb())
		{
			string text = item.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.AppendFormat("[{0}]: {1}", num, text);
				object target = item.tfTXCCAHqxDXnaBDPHkhaWuIdhbT.Target;
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

	private static void iNvNgpMLnYzNPwkKIzrYocxRnljI(WDLIqztsTFKKRNeHzsLEXCzxPiJg P_0)
	{
		EIfbFYECQbozhekUtBIfXQeWDRXGb?.Invoke(null, new JJShEpFJZgwnJlueFjPTWiFDpPhm(P_0));
	}

	private static void nHaSDzOcJQyjXOJHfWvGkqullGwg(WDLIqztsTFKKRNeHzsLEXCzxPiJg P_0)
	{
		DgxzcTAVwHbKXbLNdUfoVxFJXSoB?.Invoke(null, new JJShEpFJZgwnJlueFjPTWiFDpPhm(P_0));
	}
}
