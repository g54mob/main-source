using System;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class vExjksMabWUnVIMvagNEfjZDaFR
{
	[CompilerGenerated]
	private string fUIHKSTxaXRcMkleiwTGnkRPMIk;

	[CompilerGenerated]
	private TNuYvFcSdWFqveHgvUhHbRntguj TcIAnmYOrSEuSbTFffGeBnSgmJRd;

	[CompilerGenerated]
	private IntPtr BiOHUWqPXwypTsZDrWdjLpOOEKD;

	public string DeviceName
	{
		[CompilerGenerated]
		get
		{
			return fUIHKSTxaXRcMkleiwTGnkRPMIk;
		}
		[CompilerGenerated]
		set
		{
			fUIHKSTxaXRcMkleiwTGnkRPMIk = value;
		}
	}

	public TNuYvFcSdWFqveHgvUhHbRntguj DeviceType
	{
		[CompilerGenerated]
		get
		{
			return TcIAnmYOrSEuSbTFffGeBnSgmJRd;
		}
		[CompilerGenerated]
		set
		{
			TcIAnmYOrSEuSbTFffGeBnSgmJRd = value;
		}
	}

	public IntPtr Handle
	{
		[CompilerGenerated]
		get
		{
			return BiOHUWqPXwypTsZDrWdjLpOOEKD;
		}
		[CompilerGenerated]
		set
		{
			BiOHUWqPXwypTsZDrWdjLpOOEKD = value;
		}
	}

	public vExjksMabWUnVIMvagNEfjZDaFR()
	{
	}

	internal vExjksMabWUnVIMvagNEfjZDaFR(ref jrcDlgXvKdneOKRryQPpUJwoVWg rawDeviceInfo, string deviceName, IntPtr deviceHandle)
	{
		DeviceName = deviceName;
		Handle = deviceHandle;
		DeviceType = rawDeviceInfo.HSgsKXENkcvZsdtDvNAJblnfTHZ;
	}

	internal static vExjksMabWUnVIMvagNEfjZDaFR APjQhUnAGuypJSbqyvqXDiZucuA(ref jrcDlgXvKdneOKRryQPpUJwoVWg P_0, string P_1, IntPtr P_2)
	{
		vExjksMabWUnVIMvagNEfjZDaFR vExjksMabWUnVIMvagNEfjZDaFR2 = null;
		return P_0.HSgsKXENkcvZsdtDvNAJblnfTHZ switch
		{
			TNuYvFcSdWFqveHgvUhHbRntguj.YIMjNMrHOiIZiGZsLTHFXIEgJNJ => new bugieSpilmSbyiYYybatwGrmmnM(ref P_0, P_1, P_2), 
			TNuYvFcSdWFqveHgvUhHbRntguj.bheAcljDHpoAOeHYhiVCoSJIEJwV => new jJcYkFcLIiBRJsFVtCfWkRoPPyKi(ref P_0, P_1, P_2), 
			TNuYvFcSdWFqveHgvUhHbRntguj.QWzvIXfHqDcsOQVtNnKAnsyXzLg => new rLhOMlqnMWdFMhQKjcKaLEBRpMEf(ref P_0, P_1, P_2), 
			_ => throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Unsupported Device Type [{0}]", new object[1] { (int)P_0.HSgsKXENkcvZsdtDvNAJblnfTHZ })), 
		};
	}
}
