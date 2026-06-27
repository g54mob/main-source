using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

internal static class ityRkokCxtWviRcXZKNxkHrOObxF
{
	private static Dictionary<IntPtr, List<nMTMPSbLbrybOonBsHTVlrScjvxU>> CqZNfduOeJuGUMAkvHpGcTgaDKzi;

	[ThreadStatic]
	private static Dictionary<IntPtr, List<nMTMPSbLbrybOonBsHTVlrScjvxU>> SNiNGSWtPpovsuqycwzAMdijRbfU;

	[CompilerGenerated]
	private static EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf> m_YmchQydhhZTiatnnrACyrOEIKbOY;

	[CompilerGenerated]
	private static EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf> m_XXamWwdsSjwRUymQfKskFTDZrVXB;

	private static Dictionary<IntPtr, List<nMTMPSbLbrybOonBsHTVlrScjvxU>> ZSNUfvwuqTDarxoFIdFEIgYfUhOX
	{
		get
		{
			if (azoHsKsltgxwSdxNRpblhVvIifhS.wLCkpADjeqDnyIvvhJHwslEHRhYaA)
			{
				if (SNiNGSWtPpovsuqycwzAMdijRbfU == null)
				{
					SNiNGSWtPpovsuqycwzAMdijRbfU = new Dictionary<IntPtr, List<nMTMPSbLbrybOonBsHTVlrScjvxU>>(PaSKFstjmlOBRyltETpqABfembPe.qmojRobKgggrNiNJDLQSksRfgeYX);
				}
				return SNiNGSWtPpovsuqycwzAMdijRbfU;
			}
			if (CqZNfduOeJuGUMAkvHpGcTgaDKzi == null)
			{
				CqZNfduOeJuGUMAkvHpGcTgaDKzi = new Dictionary<IntPtr, List<nMTMPSbLbrybOonBsHTVlrScjvxU>>(PaSKFstjmlOBRyltETpqABfembPe.qmojRobKgggrNiNJDLQSksRfgeYX);
			}
			return CqZNfduOeJuGUMAkvHpGcTgaDKzi;
		}
	}

	public static event EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf> YmchQydhhZTiatnnrACyrOEIKbOY
	{
		[CompilerGenerated]
		add
		{
			EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf> eventHandler = ityRkokCxtWviRcXZKNxkHrOObxF.m_YmchQydhhZTiatnnrACyrOEIKbOY;
			EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf> value2 = (EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref ityRkokCxtWviRcXZKNxkHrOObxF.m_YmchQydhhZTiatnnrACyrOEIKbOY, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf> eventHandler = ityRkokCxtWviRcXZKNxkHrOObxF.m_YmchQydhhZTiatnnrACyrOEIKbOY;
			EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf> value2 = (EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref ityRkokCxtWviRcXZKNxkHrOObxF.m_YmchQydhhZTiatnnrACyrOEIKbOY, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public static event EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf> XXamWwdsSjwRUymQfKskFTDZrVXB
	{
		[CompilerGenerated]
		add
		{
			EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf> eventHandler = ityRkokCxtWviRcXZKNxkHrOObxF.m_XXamWwdsSjwRUymQfKskFTDZrVXB;
			EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf> value2 = (EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref ityRkokCxtWviRcXZKNxkHrOObxF.m_XXamWwdsSjwRUymQfKskFTDZrVXB, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf> eventHandler = ityRkokCxtWviRcXZKNxkHrOObxF.m_XXamWwdsSjwRUymQfKskFTDZrVXB;
			EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf> value2 = (EventHandler<RgHorVeDeIdpUqgDZzKCINbRDncf>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref ityRkokCxtWviRcXZKNxkHrOObxF.m_XXamWwdsSjwRUymQfKskFTDZrVXB, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	static ityRkokCxtWviRcXZKNxkHrOObxF()
	{
		AppDomain.CurrentDomain.DomainUnload += spVcTEdHrDHLxIZZDrVdIIJiyyFAd;
		AppDomain.CurrentDomain.ProcessExit += spVcTEdHrDHLxIZZDrVdIIJiyyFAd;
	}

	private static void spVcTEdHrDHLxIZZDrVdIIJiyyFAd(object P_0, EventArgs P_1)
	{
		if (azoHsKsltgxwSdxNRpblhVvIifhS.DqNGSfohrPNphWbZJvoILcFLbOWm)
		{
			string value = eCeRaHsAMtLSMrRHOVGjuOHzlxol();
			if (!string.IsNullOrEmpty(value))
			{
				Console.WriteLine(value);
			}
		}
	}

	public static void XYqfgBCCCuacCZvwyatikUrXaZxi(MVODoHWtmlXSEWwatoJRHSNlznOK P_0)
	{
		if (P_0 == null || P_0.wkJiNziQVZeKUDzpAUZiJMbAGjgE == IntPtr.Zero)
		{
			return;
		}
		lock (ZSNUfvwuqTDarxoFIdFEIgYfUhOX)
		{
			if (!ZSNUfvwuqTDarxoFIdFEIgYfUhOX.TryGetValue(P_0.wkJiNziQVZeKUDzpAUZiJMbAGjgE, out var value))
			{
				value = new List<nMTMPSbLbrybOonBsHTVlrScjvxU>();
				ZSNUfvwuqTDarxoFIdFEIgYfUhOX.Add(P_0.wkJiNziQVZeKUDzpAUZiJMbAGjgE, value);
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
			value.Add(new nMTMPSbLbrybOonBsHTVlrScjvxU(DateTime.Now, P_0, stringBuilder.ToString()));
			ieuKxDnNQkiMGnqxIjeDowFVBEsi(P_0);
		}
	}

	public static List<nMTMPSbLbrybOonBsHTVlrScjvxU> LLvNJGEnpRkiIYuyOduPxOoartrJ(IntPtr P_0)
	{
		lock (ZSNUfvwuqTDarxoFIdFEIgYfUhOX)
		{
			if (ZSNUfvwuqTDarxoFIdFEIgYfUhOX.TryGetValue(P_0, out var value))
			{
				return new List<nMTMPSbLbrybOonBsHTVlrScjvxU>(value);
			}
		}
		return new List<nMTMPSbLbrybOonBsHTVlrScjvxU>();
	}

	public static nMTMPSbLbrybOonBsHTVlrScjvxU hxXbsEKxmkAcyrNiqPVyaNVgOyxe(MVODoHWtmlXSEWwatoJRHSNlznOK P_0)
	{
		lock (ZSNUfvwuqTDarxoFIdFEIgYfUhOX)
		{
			if (ZSNUfvwuqTDarxoFIdFEIgYfUhOX.TryGetValue(P_0.wkJiNziQVZeKUDzpAUZiJMbAGjgE, out var value))
			{
				foreach (nMTMPSbLbrybOonBsHTVlrScjvxU item in value)
				{
					if (item.hOEUNknQNHQbmfyaZuLymDMGhPqT.Target == P_0)
					{
						return item;
					}
				}
			}
		}
		return null;
	}

	public static void DCWMEFjeowinszxDsOLspsXbjPAl(MVODoHWtmlXSEWwatoJRHSNlznOK P_0)
	{
		if (P_0 == null || P_0.wkJiNziQVZeKUDzpAUZiJMbAGjgE == IntPtr.Zero)
		{
			return;
		}
		lock (ZSNUfvwuqTDarxoFIdFEIgYfUhOX)
		{
			if (!ZSNUfvwuqTDarxoFIdFEIgYfUhOX.TryGetValue(P_0.wkJiNziQVZeKUDzpAUZiJMbAGjgE, out var value))
			{
				return;
			}
			for (int num = value.Count - 1; num >= 0; num--)
			{
				nMTMPSbLbrybOonBsHTVlrScjvxU nMTMPSbLbrybOonBsHTVlrScjvxU2 = value[num];
				if (nMTMPSbLbrybOonBsHTVlrScjvxU2.hOEUNknQNHQbmfyaZuLymDMGhPqT.Target == P_0)
				{
					value.RemoveAt(num);
				}
				else if (!nMTMPSbLbrybOonBsHTVlrScjvxU2.wracHqcBSjmPKayrapovTNBRUlQyA)
				{
					value.RemoveAt(num);
				}
			}
			if (value.Count == 0)
			{
				ZSNUfvwuqTDarxoFIdFEIgYfUhOX.Remove(P_0.wkJiNziQVZeKUDzpAUZiJMbAGjgE);
			}
			vydJYZzcxolCPZgclAJnyYfzTbjD(P_0);
		}
	}

	public static List<nMTMPSbLbrybOonBsHTVlrScjvxU> cTEjfZbsIXTFqLkeatssGgxRDvLB()
	{
		List<nMTMPSbLbrybOonBsHTVlrScjvxU> list = new List<nMTMPSbLbrybOonBsHTVlrScjvxU>();
		lock (ZSNUfvwuqTDarxoFIdFEIgYfUhOX)
		{
			foreach (List<nMTMPSbLbrybOonBsHTVlrScjvxU> value in ZSNUfvwuqTDarxoFIdFEIgYfUhOX.Values)
			{
				foreach (nMTMPSbLbrybOonBsHTVlrScjvxU item in value)
				{
					if (item.wracHqcBSjmPKayrapovTNBRUlQyA)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}
	}

	public static string eCeRaHsAMtLSMrRHOVGjuOHzlxol()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (nMTMPSbLbrybOonBsHTVlrScjvxU item in cTEjfZbsIXTFqLkeatssGgxRDvLB())
		{
			string text = item.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.AppendFormat("[{0}]: {1}", num, text);
				object target = item.hOEUNknQNHQbmfyaZuLymDMGhPqT.Target;
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

	private static void ieuKxDnNQkiMGnqxIjeDowFVBEsi(MVODoHWtmlXSEWwatoJRHSNlznOK P_0)
	{
		ityRkokCxtWviRcXZKNxkHrOObxF.YmchQydhhZTiatnnrACyrOEIKbOY?.Invoke(null, new RgHorVeDeIdpUqgDZzKCINbRDncf(P_0));
	}

	private static void vydJYZzcxolCPZgclAJnyYfzTbjD(MVODoHWtmlXSEWwatoJRHSNlznOK P_0)
	{
		ityRkokCxtWviRcXZKNxkHrOObxF.XXamWwdsSjwRUymQfKskFTDZrVXB?.Invoke(null, new RgHorVeDeIdpUqgDZzKCINbRDncf(P_0));
	}
}
