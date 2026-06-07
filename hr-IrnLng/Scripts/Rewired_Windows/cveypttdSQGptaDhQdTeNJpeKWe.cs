using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class cveypttdSQGptaDhQdTeNJpeKWe : jTTnjFcmJNutQYLpCwPogAkUWGz
{
	[CompilerGenerated]
	private int WcDDqahGVHKrnRhjwsFKQZtxHwuj;

	[CompilerGenerated]
	private int fyFciiXHVNbXRUfgZRXESOziGtE;

	[CompilerGenerated]
	private int VOxMyvXOloNCTCUqMvBpbcwpecH;

	[CompilerGenerated]
	private int[] pvDGHeelzXjjyJluREFSMjPUFhMd;

	public int ChannelCount
	{
		[CompilerGenerated]
		get
		{
			return WcDDqahGVHKrnRhjwsFKQZtxHwuj;
		}
		[CompilerGenerated]
		set
		{
			WcDDqahGVHKrnRhjwsFKQZtxHwuj = value;
		}
	}

	public int SamplePeriod
	{
		[CompilerGenerated]
		get
		{
			return fyFciiXHVNbXRUfgZRXESOziGtE;
		}
		[CompilerGenerated]
		set
		{
			fyFciiXHVNbXRUfgZRXESOziGtE = value;
		}
	}

	public int SampleCount
	{
		[CompilerGenerated]
		get
		{
			return VOxMyvXOloNCTCUqMvBpbcwpecH;
		}
		[CompilerGenerated]
		set
		{
			VOxMyvXOloNCTCUqMvBpbcwpecH = value;
		}
	}

	public int[] ForceData
	{
		[CompilerGenerated]
		get
		{
			return pvDGHeelzXjjyJluREFSMjPUFhMd;
		}
		[CompilerGenerated]
		set
		{
			pvDGHeelzXjjyJluREFSMjPUFhMd = value;
		}
	}

	public override int Size => JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<MsSNNtUxGHeOVdmGfmHkBYqpogs>();

	protected unsafe override jTTnjFcmJNutQYLpCwPogAkUWGz aRreqoecxmLuIAlYVRIPwMKrCMT(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(MsSNNtUxGHeOVdmGfmHkBYqpogs))
		{
			return null;
		}
		ChannelCount = ((MsSNNtUxGHeOVdmGfmHkBYqpogs*)(void*)P_1)->ppKcuVFOACmtlUJBHoJnapjDyAO;
		SamplePeriod = ((MsSNNtUxGHeOVdmGfmHkBYqpogs*)(void*)P_1)->KqTriGSkymUBbyNcLfZlCRFCOBI;
		SampleCount = ((MsSNNtUxGHeOVdmGfmHkBYqpogs*)(void*)P_1)->PINAypYKIuOPgUiwaqCMxvLXFoy;
		ForceData = new int[SampleCount];
		fixed (int* forceData = ForceData)
		{
			JOFzuBXkNUfGEywCsKAgVeZrrPQ.esVdJDaUiZZdCOdqRfdjVzLEMDz((IntPtr)forceData, ((MsSNNtUxGHeOVdmGfmHkBYqpogs*)(void*)P_1)->hqmkWlXXafOwuKCPuZGWxgePLxe, ForceData.Length * sizeof(MsSNNtUxGHeOVdmGfmHkBYqpogs));
		}
		return this;
	}

	internal unsafe override IntPtr diiFuCizNlbWbcWAcnolWnmjPwtB()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((MsSNNtUxGHeOVdmGfmHkBYqpogs*)(void*)intPtr)->ppKcuVFOACmtlUJBHoJnapjDyAO = ChannelCount;
		((MsSNNtUxGHeOVdmGfmHkBYqpogs*)(void*)intPtr)->KqTriGSkymUBbyNcLfZlCRFCOBI = SamplePeriod;
		((MsSNNtUxGHeOVdmGfmHkBYqpogs*)(void*)intPtr)->PINAypYKIuOPgUiwaqCMxvLXFoy = SampleCount;
		IntPtr intPtr2 = Marshal.AllocHGlobal(ForceData.Length * 4);
		((MsSNNtUxGHeOVdmGfmHkBYqpogs*)(void*)intPtr)->hqmkWlXXafOwuKCPuZGWxgePLxe = intPtr2;
		fixed (int* forceData = ForceData)
		{
			JOFzuBXkNUfGEywCsKAgVeZrrPQ.esVdJDaUiZZdCOdqRfdjVzLEMDz(intPtr2, (IntPtr)forceData, ForceData.Length * 4);
		}
		return intPtr;
	}

	internal unsafe override void OdygDBNQWwlgGNhRXdWTJchNXjM(IntPtr P_0)
	{
		base.OdygDBNQWwlgGNhRXdWTJchNXjM(P_0);
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(((MsSNNtUxGHeOVdmGfmHkBYqpogs*)(void*)P_0)->hqmkWlXXafOwuKCPuZGWxgePLxe);
		}
	}
}
