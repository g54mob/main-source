using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class uCuayZZTndmvaGUTxqadLfFQsIne : otSneItFPAOjHxBOOToSbdWIRemC
{
	private readonly Dictionary<Guid, hYPTbHLbDzmnRCEIttaDJYGkhVmt> jysamDcRNekzzyKVFNaUuDGVICXpA = new Dictionary<Guid, hYPTbHLbDzmnRCEIttaDJYGkhVmt>();

	private static readonly Dictionary<Type, List<Type>> nCIIIKkpLnVBRnZNDQYwmfHUCUIf = new Dictionary<Type, List<Type>>();

	private IntPtr argTdPlOkEgQcHmLkpqnBSHRdGqf;

	[CompilerGenerated]
	private IntPtr[] zvEMaukAEjtJbgiFOkSvVQgRrlvL;

	public IntPtr[] hCGxxCApDrOyQgmddZKCWLXdjNEH
	{
		[CompilerGenerated]
		get
		{
			return zvEMaukAEjtJbgiFOkSvVQgRrlvL;
		}
		[CompilerGenerated]
		private set
		{
			zvEMaukAEjtJbgiFOkSvVQgRrlvL = array;
		}
	}

	public void QZpcBtcvPPJZyAhfJTroGeLewZBFb(JEPBkoFoKXnaFOUZIttNtjjJjbESA P_0)
	{
		P_0.IPZlEcCcosbYPUjHzMUvonHazimy = this;
		Type type = P_0.GetType();
		List<Type> value;
		lock (nCIIIKkpLnVBRnZNDQYwmfHUCUIf)
		{
			if (!nCIIIKkpLnVBRnZNDQYwmfHUCUIf.TryGetValue(type, out value))
			{
				Type[] interfaces = type.GetInterfaces();
				value = new List<Type>();
				value.AddRange(interfaces);
				nCIIIKkpLnVBRnZNDQYwmfHUCUIf.Add(type, value);
				Type[] array = interfaces;
				foreach (Type type2 in array)
				{
					if (KbhjJaHkCaItnSUvAUUBLRyDHZos.PQqSRaDkwBMsNpGTXrKkiSAOUFfe(type2) == null)
					{
						value.Remove(type2);
						continue;
					}
					Type[] interfaces2 = type2.GetInterfaces();
					foreach (Type item in interfaces2)
					{
						value.Remove(item);
					}
				}
			}
		}
		hYPTbHLbDzmnRCEIttaDJYGkhVmt hYPTbHLbDzmnRCEIttaDJYGkhVmt2 = null;
		foreach (Type item2 in value)
		{
			hYPTbHLbDzmnRCEIttaDJYGkhVmt hYPTbHLbDzmnRCEIttaDJYGkhVmt3 = (hYPTbHLbDzmnRCEIttaDJYGkhVmt)Activator.CreateInstance(KbhjJaHkCaItnSUvAUUBLRyDHZos.PQqSRaDkwBMsNpGTXrKkiSAOUFfe(item2).bTuCWJmMZrJGezwXyYKYYhoqPiNC);
			hYPTbHLbDzmnRCEIttaDJYGkhVmt3.BfKHizrUzUBaobNxIjQMDtpDzYeDb(P_0);
			if (hYPTbHLbDzmnRCEIttaDJYGkhVmt2 == null)
			{
				hYPTbHLbDzmnRCEIttaDJYGkhVmt2 = hYPTbHLbDzmnRCEIttaDJYGkhVmt3;
				jysamDcRNekzzyKVFNaUuDGVICXpA.Add(DSADfzJWcYvVGtBGYXOIqyseMdgY.wRWdWDKSVKIyqtnhdcMzydvLOAou, hYPTbHLbDzmnRCEIttaDJYGkhVmt2);
			}
			jysamDcRNekzzyKVFNaUuDGVICXpA.Add(UzSdPpQstdjpcZsalnZeqrJQhDdn.BydJGWyAVzMxIqlyYjQEkWfvEvwo(item2), hYPTbHLbDzmnRCEIttaDJYGkhVmt3);
			Type[] array = item2.GetInterfaces();
			foreach (Type type3 in array)
			{
				if (KbhjJaHkCaItnSUvAUUBLRyDHZos.PQqSRaDkwBMsNpGTXrKkiSAOUFfe(type3) != null)
				{
					jysamDcRNekzzyKVFNaUuDGVICXpA.Add(UzSdPpQstdjpcZsalnZeqrJQhDdn.BydJGWyAVzMxIqlyYjQEkWfvEvwo(type3), hYPTbHLbDzmnRCEIttaDJYGkhVmt3);
				}
			}
		}
	}

	internal IntPtr QZcFutmekaWzfIkDPXmnsFgorAXC(Type P_0)
	{
		return GKbpKPteZlvaGdlhItteTgBUIYGd(UzSdPpQstdjpcZsalnZeqrJQhDdn.BydJGWyAVzMxIqlyYjQEkWfvEvwo(P_0));
	}

	internal IntPtr GKbpKPteZlvaGdlhItteTgBUIYGd(Guid P_0)
	{
		return remxjSSuWggWGglhLEinUdApkoEB(P_0)?.ACFwmzDwqOrdlJWEMfNgthgFfemb ?? IntPtr.Zero;
	}

	internal hYPTbHLbDzmnRCEIttaDJYGkhVmt remxjSSuWggWGglhLEinUdApkoEB(Guid P_0)
	{
		jysamDcRNekzzyKVFNaUuDGVICXpA.TryGetValue(P_0, out var value);
		return value;
	}

	protected virtual void cIBnnXbpyflYZxqBHipNxIqVvWWL(bool P_0)
	{
		if (!P_0)
		{
			return;
		}
		foreach (hYPTbHLbDzmnRCEIttaDJYGkhVmt value in jysamDcRNekzzyKVFNaUuDGVICXpA.Values)
		{
			value.Dispose();
		}
		jysamDcRNekzzyKVFNaUuDGVICXpA.Clear();
		if (argTdPlOkEgQcHmLkpqnBSHRdGqf != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(argTdPlOkEgQcHmLkpqnBSHRdGqf);
			argTdPlOkEgQcHmLkpqnBSHRdGqf = IntPtr.Zero;
		}
	}
}
