using System;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class bURkZovRhaRlbJuBnqAqELdHxri
{
	[CompilerGenerated]
	private string dmaxlMaewbuyopHMbCUoMKvVAZFA;

	[CompilerGenerated]
	private TUEeiLGHzyEyJIpYufytZOXrNfMo JFgtXghJniBSmAgzaeuCEmomUUq;

	[CompilerGenerated]
	private IntPtr DQwmlIHVvSSbflvmgPuNqcnQPgq;

	public string DeviceName
	{
		[CompilerGenerated]
		get
		{
			return dmaxlMaewbuyopHMbCUoMKvVAZFA;
		}
		[CompilerGenerated]
		set
		{
			dmaxlMaewbuyopHMbCUoMKvVAZFA = value;
		}
	}

	public TUEeiLGHzyEyJIpYufytZOXrNfMo DeviceType
	{
		[CompilerGenerated]
		get
		{
			return JFgtXghJniBSmAgzaeuCEmomUUq;
		}
		[CompilerGenerated]
		set
		{
			JFgtXghJniBSmAgzaeuCEmomUUq = value;
		}
	}

	public IntPtr Handle
	{
		[CompilerGenerated]
		get
		{
			return DQwmlIHVvSSbflvmgPuNqcnQPgq;
		}
		[CompilerGenerated]
		set
		{
			DQwmlIHVvSSbflvmgPuNqcnQPgq = value;
		}
	}

	public bURkZovRhaRlbJuBnqAqELdHxri()
	{
	}

	internal bURkZovRhaRlbJuBnqAqELdHxri(ref rmEJdycGWDVDyBWXvluXtPAmEiJ rawDeviceInfo, string deviceName, IntPtr deviceHandle)
	{
		DeviceName = deviceName;
		Handle = deviceHandle;
		DeviceType = rawDeviceInfo.XRAgRlviNYwGByvwryzeCXzsCcj;
	}

	internal static bURkZovRhaRlbJuBnqAqELdHxri GvBNWJSWGUWdjPUZrOAzsnketLf(ref rmEJdycGWDVDyBWXvluXtPAmEiJ P_0, string P_1, IntPtr P_2)
	{
		bURkZovRhaRlbJuBnqAqELdHxri bURkZovRhaRlbJuBnqAqELdHxri2 = null;
		switch (P_0.XRAgRlviNYwGByvwryzeCXzsCcj)
		{
		case TUEeiLGHzyEyJIpYufytZOXrNfMo.UAeiRUQTBSvtMZfpSWbrqScgDKu:
			return new dQKGNKOGnMQxAfhybGNXHfXiiDv(ref P_0, P_1, P_2);
		case TUEeiLGHzyEyJIpYufytZOXrNfMo.xASCPheTPZjjySaqzxbejdrWIOZ:
			return new nXIbSVLdUYcmjdrdarLgyyAHexfg(ref P_0, P_1, P_2);
		case TUEeiLGHzyEyJIpYufytZOXrNfMo.UQBduDQfcpFVodDJGKokyQOHOEHN:
			return new nJispLRSkKygVFomtgGktrNOPpe(ref P_0, P_1, P_2);
		default:
			throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Unsupported Device Type [{0}]", (int)P_0.XRAgRlviNYwGByvwryzeCXzsCcj));
		}
	}
}
