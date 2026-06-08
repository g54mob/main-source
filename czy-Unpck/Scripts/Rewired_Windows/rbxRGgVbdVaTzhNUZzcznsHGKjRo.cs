using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX;

internal class rbxRGgVbdVaTzhNUZzcznsHGKjRo : bmLmBCpqnyTtLeIFgDTVIITYzQAA
{
	private readonly Dictionary<Guid, kiUcNJVlbDiUFZMANgySDecsoISU> sBWktheIFuBfeGFVJtDLcQhnpspc = new Dictionary<Guid, kiUcNJVlbDiUFZMANgySDecsoISU>();

	private static readonly Dictionary<Type, List<Type>> CBoMcbxCjzbRzaPZLDUUVfGcfgH = new Dictionary<Type, List<Type>>();

	private IntPtr lDAdifGwKPOMHKdCGMuSEXfofot;

	[CompilerGenerated]
	private IntPtr[] QgPxQZuFKjWmVPNcCPciSyuDLtv;

	public IntPtr[] Guids
	{
		[CompilerGenerated]
		get
		{
			return QgPxQZuFKjWmVPNcCPciSyuDLtv;
		}
		[CompilerGenerated]
		private set
		{
			QgPxQZuFKjWmVPNcCPciSyuDLtv = value;
		}
	}

	public void XcqbVqdtLKNrEHBlIGziwanWbzsI(YcEKPykyufPoBZCDgnRECPtNieq P_0)
	{
		P_0.Shadow = this;
		Type type = P_0.GetType();
		List<Type> value;
		lock (CBoMcbxCjzbRzaPZLDUUVfGcfgH)
		{
			if (!CBoMcbxCjzbRzaPZLDUUVfGcfgH.TryGetValue(type, out value))
			{
				Type[] interfaces = type.GetInterfaces();
				value = new List<Type>();
				value.AddRange(interfaces);
				CBoMcbxCjzbRzaPZLDUUVfGcfgH.Add(type, value);
				Type[] array = interfaces;
				foreach (Type type2 in array)
				{
					ShadowAttribute shadowAttribute = ShadowAttribute.Get(type2);
					if (shadowAttribute == null)
					{
						value.Remove(type2);
						continue;
					}
					Type[] interfaces2 = type2.GetInterfaces();
					Type[] array2 = interfaces2;
					foreach (Type item in array2)
					{
						value.Remove(item);
					}
				}
			}
		}
		kiUcNJVlbDiUFZMANgySDecsoISU kiUcNJVlbDiUFZMANgySDecsoISU2 = null;
		foreach (Type item2 in value)
		{
			ShadowAttribute shadowAttribute2 = ShadowAttribute.Get(item2);
			kiUcNJVlbDiUFZMANgySDecsoISU kiUcNJVlbDiUFZMANgySDecsoISU3 = (kiUcNJVlbDiUFZMANgySDecsoISU)Activator.CreateInstance(shadowAttribute2.Type);
			kiUcNJVlbDiUFZMANgySDecsoISU3.XcqbVqdtLKNrEHBlIGziwanWbzsI(P_0);
			if (kiUcNJVlbDiUFZMANgySDecsoISU2 == null)
			{
				kiUcNJVlbDiUFZMANgySDecsoISU2 = kiUcNJVlbDiUFZMANgySDecsoISU3;
				sBWktheIFuBfeGFVJtDLcQhnpspc.Add(IPNZOvMlSasjEEMEsInJToOiseY.PtSWpVHSVmgYSmhRHbuiDnAFumD, kiUcNJVlbDiUFZMANgySDecsoISU2);
			}
			sBWktheIFuBfeGFVJtDLcQhnpspc.Add(XhNUbpKnHPBQaARiBNUpPFpGECJ.fptDFZDgIbRuErYVNLSLMGyyTaQi(item2), kiUcNJVlbDiUFZMANgySDecsoISU3);
			Type[] interfaces3 = item2.GetInterfaces();
			Type[] array3 = interfaces3;
			foreach (Type type3 in array3)
			{
				ShadowAttribute shadowAttribute3 = ShadowAttribute.Get(type3);
				if (shadowAttribute3 != null)
				{
					sBWktheIFuBfeGFVJtDLcQhnpspc.Add(XhNUbpKnHPBQaARiBNUpPFpGECJ.fptDFZDgIbRuErYVNLSLMGyyTaQi(type3), kiUcNJVlbDiUFZMANgySDecsoISU3);
				}
			}
		}
	}

	internal IntPtr TRyLtPfiiFpGPNucOuzDDNMGpwr(Type P_0)
	{
		return TRyLtPfiiFpGPNucOuzDDNMGpwr(XhNUbpKnHPBQaARiBNUpPFpGECJ.fptDFZDgIbRuErYVNLSLMGyyTaQi(P_0));
	}

	internal IntPtr TRyLtPfiiFpGPNucOuzDDNMGpwr(Guid P_0)
	{
		return YDpmQdsvnmlqyHPHyoYFZbXeodP(P_0)?.NativePointer ?? IntPtr.Zero;
	}

	internal kiUcNJVlbDiUFZMANgySDecsoISU YDpmQdsvnmlqyHPHyoYFZbXeodP(Guid P_0)
	{
		sBWktheIFuBfeGFVJtDLcQhnpspc.TryGetValue(P_0, out var value);
		return value;
	}

	protected override void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (!P_0)
		{
			return;
		}
		foreach (kiUcNJVlbDiUFZMANgySDecsoISU value in sBWktheIFuBfeGFVJtDLcQhnpspc.Values)
		{
			value.Dispose();
		}
		sBWktheIFuBfeGFVJtDLcQhnpspc.Clear();
		if (lDAdifGwKPOMHKdCGMuSEXfofot != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(lDAdifGwKPOMHKdCGMuSEXfofot);
			lDAdifGwKPOMHKdCGMuSEXfofot = IntPtr.Zero;
		}
	}
}
