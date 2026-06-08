using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class qNixSHoItHYXSEVdzohlXXkPDgh : TypeSpecificParameters
{
	[CompilerGenerated]
	private int YVRDlKIRDCEnFVBTZLINjZFIirlS;

	[CompilerGenerated]
	private int hRPpsEQdBYhBzclEkbCDOZDXMVN;

	[CompilerGenerated]
	private int ZHfPEHImrxThpqOAtyiwvdKOlBM;

	[CompilerGenerated]
	private int[] doDcMOBapWelYPXCiKIVfjbbHcNa;

	public int ChannelCount
	{
		[CompilerGenerated]
		get
		{
			return YVRDlKIRDCEnFVBTZLINjZFIirlS;
		}
		[CompilerGenerated]
		set
		{
			YVRDlKIRDCEnFVBTZLINjZFIirlS = value;
		}
	}

	public int SamplePeriod
	{
		[CompilerGenerated]
		get
		{
			return hRPpsEQdBYhBzclEkbCDOZDXMVN;
		}
		[CompilerGenerated]
		set
		{
			hRPpsEQdBYhBzclEkbCDOZDXMVN = value;
		}
	}

	public int SampleCount
	{
		[CompilerGenerated]
		get
		{
			return ZHfPEHImrxThpqOAtyiwvdKOlBM;
		}
		[CompilerGenerated]
		set
		{
			ZHfPEHImrxThpqOAtyiwvdKOlBM = value;
		}
	}

	public int[] ForceData
	{
		[CompilerGenerated]
		get
		{
			return doDcMOBapWelYPXCiKIVfjbbHcNa;
		}
		[CompilerGenerated]
		set
		{
			doDcMOBapWelYPXCiKIVfjbbHcNa = value;
		}
	}

	public override int Size => XhNUbpKnHPBQaARiBNUpPFpGECJ.MNwplfZetGrtOlzgThGDriPKjRnh<IzWcURNhGSEsdkDiYLnvINQSplpW>();

	protected unsafe virtual TypeSpecificParameters wybJdAhTpvWqyyOomZLOcLcMQJK(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(IzWcURNhGSEsdkDiYLnvINQSplpW))
		{
			return null;
		}
		ChannelCount = ((IzWcURNhGSEsdkDiYLnvINQSplpW*)(void*)P_1)->tiSfIzWgUXipLgNhiDAcFqTkvPPI;
		SamplePeriod = ((IzWcURNhGSEsdkDiYLnvINQSplpW*)(void*)P_1)->OjXcMuXirdGlZQUvggOkWrotVNN;
		SampleCount = ((IzWcURNhGSEsdkDiYLnvINQSplpW*)(void*)P_1)->RcNdlZDsOdqLWiMQDBXVFbrsLxbc;
		ForceData = new int[SampleCount];
		fixed (int* forceData = ForceData)
		{
			XhNUbpKnHPBQaARiBNUpPFpGECJ.qzVukddgYEFywyhAwohqPAzjNic((IntPtr)forceData, ((IzWcURNhGSEsdkDiYLnvINQSplpW*)(void*)P_1)->ljqEJVAfeaEeGhqvTqLNIlScXspK, ForceData.Length * sizeof(IzWcURNhGSEsdkDiYLnvINQSplpW));
		}
		return this;
	}

	internal unsafe virtual IntPtr lowChckoFmJAJyiuKPzqepQclpma()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((IzWcURNhGSEsdkDiYLnvINQSplpW*)(void*)intPtr)->tiSfIzWgUXipLgNhiDAcFqTkvPPI = ChannelCount;
		((IzWcURNhGSEsdkDiYLnvINQSplpW*)(void*)intPtr)->OjXcMuXirdGlZQUvggOkWrotVNN = SamplePeriod;
		((IzWcURNhGSEsdkDiYLnvINQSplpW*)(void*)intPtr)->RcNdlZDsOdqLWiMQDBXVFbrsLxbc = SampleCount;
		IntPtr intPtr2 = Marshal.AllocHGlobal(ForceData.Length * 4);
		((IzWcURNhGSEsdkDiYLnvINQSplpW*)(void*)intPtr)->ljqEJVAfeaEeGhqvTqLNIlScXspK = intPtr2;
		fixed (int* forceData = ForceData)
		{
			XhNUbpKnHPBQaARiBNUpPFpGECJ.qzVukddgYEFywyhAwohqPAzjNic(intPtr2, (IntPtr)forceData, ForceData.Length * 4);
		}
		return intPtr;
	}

	internal unsafe virtual void QWotDfSeGdlaixQHoocIFHWoIrL(IntPtr P_0)
	{
		base.MarshalFree(P_0);
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(((IzWcURNhGSEsdkDiYLnvINQSplpW*)(void*)P_0)->ljqEJVAfeaEeGhqvTqLNIlScXspK);
		}
	}
}
