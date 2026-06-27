using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class BeBaLmImdiuVhhtUznyINMfYdpzd
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int DPSTFsQuBKsaELlWKSYcMyVlIfyU(void* deviceInstance, IntPtr data);

	private readonly IntPtr RsoTImsewhwXwtEHwITcuhMdaCY;

	private readonly DPSTFsQuBKsaELlWKSYcMyVlIfyU YCnDfXqyDkIDuWaCdPvbinjAKrPn;

	[CompilerGenerated]
	private List<KKJhDmbloZiPSijenAUHmuFyaVyJ> ZEhdSqDPiUdJEqGMizHxnhHZrbEQA;

	public IntPtr qGRJPXhlibZLUbmsybmcxbsYZvSs => RsoTImsewhwXwtEHwITcuhMdaCY;

	public List<KKJhDmbloZiPSijenAUHmuFyaVyJ> NNBKIRTANKRJvnoOOszrDyqhgJNd
	{
		[CompilerGenerated]
		get
		{
			return ZEhdSqDPiUdJEqGMizHxnhHZrbEQA;
		}
		[CompilerGenerated]
		private set
		{
			ZEhdSqDPiUdJEqGMizHxnhHZrbEQA = zEhdSqDPiUdJEqGMizHxnhHZrbEQA;
		}
	}

	public unsafe BeBaLmImdiuVhhtUznyINMfYdpzd()
	{
		YCnDfXqyDkIDuWaCdPvbinjAKrPn = wjTqWkLJKkPpjtqanIfDOZQzcskL;
		RsoTImsewhwXwtEHwITcuhMdaCY = Marshal.GetFunctionPointerForDelegate(YCnDfXqyDkIDuWaCdPvbinjAKrPn);
		NNBKIRTANKRJvnoOOszrDyqhgJNd = new List<KKJhDmbloZiPSijenAUHmuFyaVyJ>();
	}

	[MonoPInvokeCallback(typeof(DPSTFsQuBKsaELlWKSYcMyVlIfyU))]
	private unsafe static int wjTqWkLJKkPpjtqanIfDOZQzcskL(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<BeBaLmImdiuVhhtUznyINMfYdpzd>(instanceId, out var instance))
		{
			return 1;
		}
		KKJhDmbloZiPSijenAUHmuFyaVyJ kKJhDmbloZiPSijenAUHmuFyaVyJ = new KKJhDmbloZiPSijenAUHmuFyaVyJ();
		kKJhDmbloZiPSijenAUHmuFyaVyJ.aBrimRgOFFpnKLJrkUxETvGIsaPkA(ref *(KKJhDmbloZiPSijenAUHmuFyaVyJ.exlkBwgtMBbTmvLvMGfXGTGkqfwZ*)P_0);
		instance.NNBKIRTANKRJvnoOOszrDyqhgJNd.Add(kKJhDmbloZiPSijenAUHmuFyaVyJ);
		return 1;
	}
}
