using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class kIpaqKJeYViyQlZKhSEwilKRxsFS : KhpAjhNKlrKeefViVonIWJnYNnTN<JhoBtcutmcUDoefXADHDWiuvEeyS, dBuKVIZcqeadrkyEOnlBbBNemPtd>
{
	private static readonly List<DafEBfUiyDVfsTszWOqUigCfcGlF> wkLLPpqfzDHxSZHkEzuZGTmpFqcH;

	[CompilerGenerated]
	private List<DafEBfUiyDVfsTszWOqUigCfcGlF> SagAlcSjuGMaZRSyoOKpBmVuZIzn;

	public List<DafEBfUiyDVfsTszWOqUigCfcGlF> cMIcTudwVwVsTPTUDSEFKmSyNGrg => wkLLPpqfzDHxSZHkEzuZGTmpFqcH;

	public List<DafEBfUiyDVfsTszWOqUigCfcGlF> xahUFCdQmsKuYNgyNIyIlobIHuxp
	{
		[CompilerGenerated]
		get
		{
			return SagAlcSjuGMaZRSyoOKpBmVuZIzn;
		}
		[CompilerGenerated]
		private set
		{
			SagAlcSjuGMaZRSyoOKpBmVuZIzn = sagAlcSjuGMaZRSyoOKpBmVuZIzn;
		}
	}

	static kIpaqKJeYViyQlZKhSEwilKRxsFS()
	{
		wkLLPpqfzDHxSZHkEzuZGTmpFqcH = new List<DafEBfUiyDVfsTszWOqUigCfcGlF>(256);
		foreach (object value in Enum.GetValues(typeof(DafEBfUiyDVfsTszWOqUigCfcGlF)))
		{
			wkLLPpqfzDHxSZHkEzuZGTmpFqcH.Add((DafEBfUiyDVfsTszWOqUigCfcGlF)value);
		}
	}

	public kIpaqKJeYViyQlZKhSEwilKRxsFS()
	{
		xahUFCdQmsKuYNgyNIyIlobIHuxp = new List<DafEBfUiyDVfsTszWOqUigCfcGlF>(16);
	}

	public bool aLLZVIRjmdeJAGNclbWArGKYNNIqA(DafEBfUiyDVfsTszWOqUigCfcGlF P_0)
	{
		return xahUFCdQmsKuYNgyNIyIlobIHuxp.Contains(P_0);
	}

	public void Update(dBuKVIZcqeadrkyEOnlBbBNemPtd P_0)
	{
		if (P_0.sctJcKOivJnhysqmuqppgCQnwDwH != DafEBfUiyDVfsTszWOqUigCfcGlF.Unknown)
		{
			bool flag = aLLZVIRjmdeJAGNclbWArGKYNNIqA(P_0.sctJcKOivJnhysqmuqppgCQnwDwH);
			if (P_0.aLLZVIRjmdeJAGNclbWArGKYNNIqA && !flag)
			{
				xahUFCdQmsKuYNgyNIyIlobIHuxp.Add(P_0.sctJcKOivJnhysqmuqppgCQnwDwH);
			}
			else if (P_0.PYThKjchJlHrFzsQxafYfUNTALsd && flag)
			{
				xahUFCdQmsKuYNgyNIyIlobIHuxp.Remove(P_0.sctJcKOivJnhysqmuqppgCQnwDwH);
			}
		}
	}

	public unsafe void MarshalFrom(IntPtr P_0)
	{
		xahUFCdQmsKuYNgyNIyIlobIHuxp.Clear();
		JhoBtcutmcUDoefXADHDWiuvEeyS* ptr = (JhoBtcutmcUDoefXADHDWiuvEeyS*)(void*)P_0;
		dBuKVIZcqeadrkyEOnlBbBNemPtd dBuKVIZcqeadrkyEOnlBbBNemPtd2 = default(dBuKVIZcqeadrkyEOnlBbBNemPtd);
		byte* ptr2 = &ptr->gmvSxoNJQwMzQnpbftIqRXTrocdA.unKMigUMcqBdvXfHMEauDxkFVqZY;
		for (int i = 0; i < 256; i++)
		{
			dBuKVIZcqeadrkyEOnlBbBNemPtd2.TgDPyOeIUhscbagHlJQhbhIdtxuU = i;
			dBuKVIZcqeadrkyEOnlBbBNemPtd2.pWRdAJigDslyLjNIYbVMMkTWOPgC = ptr2[i];
			if (dBuKVIZcqeadrkyEOnlBbBNemPtd2.aLLZVIRjmdeJAGNclbWArGKYNNIqA)
			{
				xahUFCdQmsKuYNgyNIyIlobIHuxp.Add(dBuKVIZcqeadrkyEOnlBbBNemPtd2.sctJcKOivJnhysqmuqppgCQnwDwH);
			}
		}
	}

	public virtual string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
	{
		return string.Format(CultureInfo.InvariantCulture, "PressedKeys: {0}", new object[1] { egeTdzIGHudlgfKlEvWOdRMMLrIl.bHIzBJRRlInpNDkEXBvKBHXNpuXb(",", xahUFCdQmsKuYNgyNIyIlobIHuxp) });
	}
}
