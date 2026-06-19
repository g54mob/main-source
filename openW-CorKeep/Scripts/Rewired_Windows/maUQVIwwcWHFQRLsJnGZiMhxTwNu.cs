using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal abstract class maUQVIwwcWHFQRLsJnGZiMhxTwNu : DuIezjEccnsLnaCsFQdyOKsmFVrxb
{
	[CompilerGenerated]
	private OoSlEvNijyXWSRDrosRXWoOMMObY dUIfqxImUbfmqdmKqzjJBrhDPchEb;

	public OoSlEvNijyXWSRDrosRXWoOMMObY qmxDbjYdiuINBZatNFrwWfFUqsVW
	{
		[CompilerGenerated]
		get
		{
			return dUIfqxImUbfmqdmKqzjJBrhDPchEb;
		}
		[CompilerGenerated]
		private set
		{
			dUIfqxImUbfmqdmKqzjJBrhDPchEb = ooSlEvNijyXWSRDrosRXWoOMMObY;
		}
	}

	protected abstract LVbAjYjVnqLmmHuJDBGGsBdzcOcRA ftqzXvPmwqIGPaVGerDLqVdtdtDH { get; }

	public unsafe virtual void WMPfEkOhSjTKbIrBiJcOKkGozpTx(OoSlEvNijyXWSRDrosRXWoOMMObY P_0)
	{
		qmxDbjYdiuINBZatNFrwWfFUqsVW = P_0;
		base.NyNAWzgABNADwGOukARROJWSWCZo = Marshal.AllocHGlobal(IntPtr.Size * 2);
		GCHandle value = GCHandle.Alloc(this);
		Marshal.WriteIntPtr(base.NyNAWzgABNADwGOukARROJWSWCZo, ftqzXvPmwqIGPaVGerDLqVdtdtDH.GpGKwckOeObdHOlbuOVdVYDANnIn);
		((IntPtr*)(void*)base.NyNAWzgABNADwGOukARROJWSWCZo)[1] = GCHandle.ToIntPtr(value);
	}

	protected unsafe virtual void vapMLLnSoSFTqOzVSDdflcHsZisX(bool P_0)
	{
		if (base.NyNAWzgABNADwGOukARROJWSWCZo != IntPtr.Zero)
		{
			GCHandle.FromIntPtr(((IntPtr*)(void*)base.NyNAWzgABNADwGOukARROJWSWCZo)[1]).Free();
			Marshal.FreeHGlobal(base.NyNAWzgABNADwGOukARROJWSWCZo);
			base.NyNAWzgABNADwGOukARROJWSWCZo = IntPtr.Zero;
		}
		qmxDbjYdiuINBZatNFrwWfFUqsVW = null;
		DICVgAtHTHBoFLxYITpuBZXsciAP(P_0);
	}

	internal unsafe static _0001 TlreMhvpGWHNqBHVhmjzrMhwXKgl<_0001>(IntPtr P_0) where _0001 : maUQVIwwcWHFQRLsJnGZiMhxTwNu
	{
		return (_0001)GCHandle.FromIntPtr(((IntPtr*)(void*)P_0)[1]).Target;
	}
}
