using System;
using Rewired;
using Rewired.Platforms;
using Rewired.Utils;

internal class hqPZfWsfbiiIsgJaREHtYrvfJTqoA
{
	public int CQaIJbhvgyFSEYFljGMMiADWAajjA;

	public int JmvBupowbcCTTfSJlvnCnepjWgYi;

	public bool BINabxjEiHuOxoxkmQvTUwvLFTMn;

	public string zylJmZBipxOVHKVKJcbVeJDfuvGD;

	public string TrEjXvwKerXddZGUIlHzjkztVfLf;

	public Guid pFoIPICCxRYTyqUMBfcBpqhPYSvf;

	public Guid uuscSrFKlkgmfNMcfWVOHFjcdxrMA;

	public int hOQNsRShNSzckEhPNXXHNdyubLNhA;

	public int LNoaUZKHNiohqJjJjICrztdiOUrf;

	public int xcboHJORFPZJhzhAeFYpPalFwgET;

	public int LZvoiRvXYfuqftjTMPClBWwhDmHx;

	public PidVid zBGGmvjBzujHtKbRkfZkgdXkqTsW;

	public Guid EOwoefKENNwdtlEthsPdmwwFxVLc;

	public int BrJNqEcMwuAQcHsrOZhqiuinGtvbb;

	public int rYHIAmpOSauZKGTFhVXqqeKJmIkN;

	public void SGYdCFrcPqGwMbKCHsgNJFCIMOAfb()
	{
		byte[] value = pFoIPICCxRYTyqUMBfcBpqhPYSvf.ToByteArray();
		int startIndex;
		int startIndex2;
		switch (UnityTools.effectivePlatform)
		{
		case Platform.Windows:
			startIndex = 0;
			startIndex2 = 2;
			break;
		case Platform.OSX:
			startIndex = 0;
			startIndex2 = 8;
			break;
		case Platform.Linux:
			startIndex = 4;
			startIndex2 = 8;
			break;
		default:
			throw new NotImplementedException();
		}
		BrJNqEcMwuAQcHsrOZhqiuinGtvbb = BitConverter.ToUInt16(value, startIndex);
		rYHIAmpOSauZKGTFhVXqqeKJmIkN = BitConverter.ToUInt16(value, startIndex2);
		zBGGmvjBzujHtKbRkfZkgdXkqTsW = new PidVid((ushort)rYHIAmpOSauZKGTFhVXqqeKJmIkN, (ushort)BrJNqEcMwuAQcHsrOZhqiuinGtvbb);
		EOwoefKENNwdtlEthsPdmwwFxVLc = MiscTools.CreateGuidHashSHA1(zylJmZBipxOVHKVKJcbVeJDfuvGD + zBGGmvjBzujHtKbRkfZkgdXkqTsW.ToString() + JmvBupowbcCTTfSJlvnCnepjWgYi);
		if (string.IsNullOrEmpty(TrEjXvwKerXddZGUIlHzjkztVfLf))
		{
			TrEjXvwKerXddZGUIlHzjkztVfLf = zylJmZBipxOVHKVKJcbVeJDfuvGD;
		}
	}

	public virtual string YOwiCBPtIgEbMUPHeAWsphMCDJbR()
	{
		string text = string.Concat(string.Concat(string.Concat(string.Concat("" + "joystickIndex = " + CQaIJbhvgyFSEYFljGMMiADWAajjA + "\n", "joystickId = ", JmvBupowbcCTTfSJlvnCnepjWgYi.ToString(), "\n"), "isGameController = ", BINabxjEiHuOxoxkmQvTUwvLFTMn.ToString(), "\n"), "hardwareName = ", zylJmZBipxOVHKVKJcbVeJDfuvGD, "\n"), "friendlyName = ", TrEjXvwKerXddZGUIlHzjkztVfLf, "\n");
		Guid guid = pFoIPICCxRYTyqUMBfcBpqhPYSvf;
		string text2 = text + "sdlJoystickGuid = " + guid.ToString() + "\n";
		guid = uuscSrFKlkgmfNMcfWVOHFjcdxrMA;
		string text3 = string.Concat(string.Concat(string.Concat(string.Concat(text2 + "sdlDeviceGuid = " + guid.ToString() + "\n", "buttonCount = ", hOQNsRShNSzckEhPNXXHNdyubLNhA.ToString(), "\n"), "axisCount = ", LNoaUZKHNiohqJjJjICrztdiOUrf.ToString(), "\n"), "hatCount = ", xcboHJORFPZJhzhAeFYpPalFwgET.ToString(), "\n"), "ballCount = ", LZvoiRvXYfuqftjTMPClBWwhDmHx.ToString(), "\n");
		PidVid pidVid = zBGGmvjBzujHtKbRkfZkgdXkqTsW;
		string text4 = text3 + "pidVid = " + pidVid.ToString() + "\n";
		guid = EOwoefKENNwdtlEthsPdmwwFxVLc;
		return string.Concat(string.Concat(text4 + "instanceGuid = " + guid.ToString() + "\n", "vendorId = ", BrJNqEcMwuAQcHsrOZhqiuinGtvbb.ToString(), "\n"), "productId = ", rYHIAmpOSauZKGTFhVXqqeKJmIkN.ToString(), "\n");
	}
}
