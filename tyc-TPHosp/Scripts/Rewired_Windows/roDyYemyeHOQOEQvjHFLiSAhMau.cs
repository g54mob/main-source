using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class roDyYemyeHOQOEQvjHFLiSAhMau : efmrLSrolSjovsfxfjCVLLJRnGz
{
	[CompilerGenerated]
	private int JgeWxARhvQdQYTfiNfnLwGZsqwu;

	[CompilerGenerated]
	private int ciwiMzSlvWXBcmvygqdnzpQzFYS;

	[CompilerGenerated]
	private int CBEtgqIEBhzDuukgjINMCHTecaRc;

	[CompilerGenerated]
	private int[] uaghlfoBBCnSBJuusrPvUcKDlmI;

	public int ChannelCount
	{
		[CompilerGenerated]
		get
		{
			return JgeWxARhvQdQYTfiNfnLwGZsqwu;
		}
		[CompilerGenerated]
		set
		{
			JgeWxARhvQdQYTfiNfnLwGZsqwu = value;
		}
	}

	public int SamplePeriod
	{
		[CompilerGenerated]
		get
		{
			return ciwiMzSlvWXBcmvygqdnzpQzFYS;
		}
		[CompilerGenerated]
		set
		{
			ciwiMzSlvWXBcmvygqdnzpQzFYS = value;
		}
	}

	public int SampleCount
	{
		[CompilerGenerated]
		get
		{
			return CBEtgqIEBhzDuukgjINMCHTecaRc;
		}
		[CompilerGenerated]
		set
		{
			CBEtgqIEBhzDuukgjINMCHTecaRc = value;
		}
	}

	public int[] ForceData
	{
		[CompilerGenerated]
		get
		{
			return uaghlfoBBCnSBJuusrPvUcKDlmI;
		}
		[CompilerGenerated]
		set
		{
			uaghlfoBBCnSBJuusrPvUcKDlmI = value;
		}
	}

	public override int Size => QvyMHYIdbHWMtWGQBjyLybggaNAi.PVPOiGJSBGvoBbaMPpcfSPOcCOq<BIzepwVVmSMqiHfOEUQVyKDcRck>();

	protected unsafe override efmrLSrolSjovsfxfjCVLLJRnGz jgUKJdlhVlbmjmcGcqukHIxicKDF(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(BIzepwVVmSMqiHfOEUQVyKDcRck))
		{
			return null;
		}
		ChannelCount = ((BIzepwVVmSMqiHfOEUQVyKDcRck*)(void*)P_1)->qzdkUKUogHanWCaPsndUXXUOGYE;
		SamplePeriod = ((BIzepwVVmSMqiHfOEUQVyKDcRck*)(void*)P_1)->RdmBJZJFOlXGKHQyaLRQWhkDMQUK;
		SampleCount = ((BIzepwVVmSMqiHfOEUQVyKDcRck*)(void*)P_1)->WaggQsTFyjWLTsEiTRglQMwWammH;
		ForceData = new int[SampleCount];
		fixed (int* forceData = ForceData)
		{
			QvyMHYIdbHWMtWGQBjyLybggaNAi.jMquLSbqoOKLzeBecvZYwYcJcSl((IntPtr)forceData, ((BIzepwVVmSMqiHfOEUQVyKDcRck*)(void*)P_1)->yyFccsOuIolcBoLFHdsxWkDCxxc, ForceData.Length * sizeof(BIzepwVVmSMqiHfOEUQVyKDcRck));
		}
		return this;
	}

	internal unsafe override IntPtr ytPODbihcgKkYwOfQIFAEFNEgkj()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((BIzepwVVmSMqiHfOEUQVyKDcRck*)(void*)intPtr)->qzdkUKUogHanWCaPsndUXXUOGYE = ChannelCount;
		((BIzepwVVmSMqiHfOEUQVyKDcRck*)(void*)intPtr)->RdmBJZJFOlXGKHQyaLRQWhkDMQUK = SamplePeriod;
		((BIzepwVVmSMqiHfOEUQVyKDcRck*)(void*)intPtr)->WaggQsTFyjWLTsEiTRglQMwWammH = SampleCount;
		IntPtr intPtr2 = Marshal.AllocHGlobal(ForceData.Length * 4);
		((BIzepwVVmSMqiHfOEUQVyKDcRck*)(void*)intPtr)->yyFccsOuIolcBoLFHdsxWkDCxxc = intPtr2;
		fixed (int* forceData = ForceData)
		{
			QvyMHYIdbHWMtWGQBjyLybggaNAi.jMquLSbqoOKLzeBecvZYwYcJcSl(intPtr2, (IntPtr)forceData, ForceData.Length * 4);
		}
		return intPtr;
	}

	internal unsafe override void HRXVOMCLwtFtpdpxuwJyOuZOqNYw(IntPtr P_0)
	{
		base.HRXVOMCLwtFtpdpxuwJyOuZOqNYw(P_0);
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(((BIzepwVVmSMqiHfOEUQVyKDcRck*)(void*)P_0)->yyFccsOuIolcBoLFHdsxWkDCxxc);
		}
	}
}
