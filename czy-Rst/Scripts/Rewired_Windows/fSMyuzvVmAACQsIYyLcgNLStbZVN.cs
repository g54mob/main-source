using System;
using System.Runtime.InteropServices;

internal struct fSMyuzvVmAACQsIYyLcgNLStbZVN
{
	public IntPtr laiCMfcNuutNUSYzPNLKPJwTLFsAA;

	public int zxhAFZhERSevIovnYQXigVCIACwv;

	public int JdsrPrFxmKEkhMzzoxOiDNYCqthA;

	public ldlbIDlGDTKMuLXyUtjBATffkGXI willCnjUwWfQuxoRCXqRPFFjILNI;

	public bool CvUQHhiqVQCklEjiXGnzBDAusbxlA
	{
		get
		{
			if (laiCMfcNuutNUSYzPNLKPJwTLFsAA != IntPtr.Zero && zxhAFZhERSevIovnYQXigVCIACwv > 0)
			{
				return JdsrPrFxmKEkhMzzoxOiDNYCqthA > 0;
			}
			return false;
		}
	}

	public fSMyuzvVmAACQsIYyLcgNLStbZVN(IntPtr P_0, int P_1, int P_2)
	{
		laiCMfcNuutNUSYzPNLKPJwTLFsAA = P_0;
		zxhAFZhERSevIovnYQXigVCIACwv = P_1;
		JdsrPrFxmKEkhMzzoxOiDNYCqthA = P_2;
		willCnjUwWfQuxoRCXqRPFFjILNI = ldlbIDlGDTKMuLXyUtjBATffkGXI.None;
	}

	public void XGPtwzDfxVsrtmBlnOXBBzudikpK()
	{
		laiCMfcNuutNUSYzPNLKPJwTLFsAA = IntPtr.Zero;
		zxhAFZhERSevIovnYQXigVCIACwv = 0;
		JdsrPrFxmKEkhMzzoxOiDNYCqthA = 0;
		willCnjUwWfQuxoRCXqRPFFjILNI = ldlbIDlGDTKMuLXyUtjBATffkGXI.None;
	}

	public string hdZQvFpqqYiuZXYNpVEspsfrWiUA()
	{
		string text = "OutputReport:\n";
		text = text + "buffer = " + ((laiCMfcNuutNUSYzPNLKPJwTLFsAA == IntPtr.Zero) ? "NULL" : ("Is Valid (" + laiCMfcNuutNUSYzPNLKPJwTLFsAA + ")")) + "\n";
		text = text + "bufferLength = " + zxhAFZhERSevIovnYQXigVCIACwv + "\n";
		text = text + "reportLength = " + JdsrPrFxmKEkhMzzoxOiDNYCqthA + "\n";
		string text2 = text;
		int num = (int)willCnjUwWfQuxoRCXqRPFFjILNI;
		text = text2 + "options = " + num + "\n";
		if (laiCMfcNuutNUSYzPNLKPJwTLFsAA != IntPtr.Zero)
		{
			text += "Buffer data:\n";
			for (int i = 0; i < JdsrPrFxmKEkhMzzoxOiDNYCqthA; i++)
			{
				text += Marshal.ReadByte(laiCMfcNuutNUSYzPNLKPJwTLFsAA, i).ToString("X2");
				if (i < JdsrPrFxmKEkhMzzoxOiDNYCqthA - 1)
				{
					text += ", ";
				}
			}
		}
		return text;
	}
}
