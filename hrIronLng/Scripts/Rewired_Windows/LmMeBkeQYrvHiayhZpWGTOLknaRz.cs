using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class LmMeBkeQYrvHiayhZpWGTOLknaRz : global::vnUBANiQfJIVAasLhjdkZgyRflNB<onTxcGhLaYefYarieKNhPkzMsmwW, EQXKzqKcqQADVluRyerdTxYPechD>
{
	private static readonly List<qrEjnDBpsfLaOQSXihQkOtzQgir> THorwZbkdxgegQeTisdtgSxODIa;

	[CompilerGenerated]
	private List<qrEjnDBpsfLaOQSXihQkOtzQgir> nuNBUSARasRRvZKDWJAJIjSALIbN;

	public List<qrEjnDBpsfLaOQSXihQkOtzQgir> AllKeys => THorwZbkdxgegQeTisdtgSxODIa;

	public List<qrEjnDBpsfLaOQSXihQkOtzQgir> PressedKeys
	{
		[CompilerGenerated]
		get
		{
			return nuNBUSARasRRvZKDWJAJIjSALIbN;
		}
		[CompilerGenerated]
		private set
		{
			nuNBUSARasRRvZKDWJAJIjSALIbN = value;
		}
	}

	static LmMeBkeQYrvHiayhZpWGTOLknaRz()
	{
		THorwZbkdxgegQeTisdtgSxODIa = new List<qrEjnDBpsfLaOQSXihQkOtzQgir>(256);
		foreach (object value in Enum.GetValues(typeof(qrEjnDBpsfLaOQSXihQkOtzQgir)))
		{
			THorwZbkdxgegQeTisdtgSxODIa.Add((qrEjnDBpsfLaOQSXihQkOtzQgir)value);
		}
	}

	public LmMeBkeQYrvHiayhZpWGTOLknaRz()
	{
		PressedKeys = new List<qrEjnDBpsfLaOQSXihQkOtzQgir>(16);
	}

	public bool BkisruUdkXdcqWkBJUEqcXJtMFW(qrEjnDBpsfLaOQSXihQkOtzQgir P_0)
	{
		return PressedKeys.Contains(P_0);
	}

	public void RMEkOMsGFSFWbHqrAFftMTIKNIHO(EQXKzqKcqQADVluRyerdTxYPechD P_0)
	{
		if (P_0.Key != qrEjnDBpsfLaOQSXihQkOtzQgir.vCzaCJAEVtIPxCWyepokaLtcMzhL)
		{
			bool flag = BkisruUdkXdcqWkBJUEqcXJtMFW(P_0.Key);
			if (P_0.IsPressed && !flag)
			{
				PressedKeys.Add(P_0.Key);
			}
			else if (P_0.IsReleased && flag)
			{
				PressedKeys.Remove(P_0.Key);
			}
		}
	}

	void global::vnUBANiQfJIVAasLhjdkZgyRflNB<onTxcGhLaYefYarieKNhPkzMsmwW, EQXKzqKcqQADVluRyerdTxYPechD>.RMEkOMsGFSFWbHqrAFftMTIKNIHO(EQXKzqKcqQADVluRyerdTxYPechD P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in RMEkOMsGFSFWbHqrAFftMTIKNIHO
		this.RMEkOMsGFSFWbHqrAFftMTIKNIHO(P_0);
	}

	public unsafe void aRreqoecxmLuIAlYVRIPwMKrCMT(IntPtr P_0)
	{
		PressedKeys.Clear();
		onTxcGhLaYefYarieKNhPkzMsmwW* ptr = (onTxcGhLaYefYarieKNhPkzMsmwW*)(void*)P_0;
		EQXKzqKcqQADVluRyerdTxYPechD eQXKzqKcqQADVluRyerdTxYPechD = default(EQXKzqKcqQADVluRyerdTxYPechD);
		byte* ptr2 = &ptr->ZwTebNImJujhPcmEDRneClYsUweg.NEjLgWFFkWUKDSMuokQOBljqmmZ;
		for (int i = 0; i < 256; i++)
		{
			eQXKzqKcqQADVluRyerdTxYPechD.gNavkshxABbPNhmoZfKZdJPCWhoN = i;
			eQXKzqKcqQADVluRyerdTxYPechD.EUwgGvplcUPAtidagjfqCcpnyEke = ptr2[i];
			if (eQXKzqKcqQADVluRyerdTxYPechD.IsPressed)
			{
				PressedKeys.Add(eQXKzqKcqQADVluRyerdTxYPechD.Key);
			}
		}
	}

	void global::vnUBANiQfJIVAasLhjdkZgyRflNB<onTxcGhLaYefYarieKNhPkzMsmwW, EQXKzqKcqQADVluRyerdTxYPechD>.aRreqoecxmLuIAlYVRIPwMKrCMT(IntPtr P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in aRreqoecxmLuIAlYVRIPwMKrCMT
		this.aRreqoecxmLuIAlYVRIPwMKrCMT(P_0);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "PressedKeys: {0}", new object[1] { JOFzuBXkNUfGEywCsKAgVeZrrPQ.OIlEUrSiFgjSFdEJhLLHCtYsqjmh(",", PressedKeys) });
	}
}
