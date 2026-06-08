using System;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class gEWwYLSxPEAKISAVsGBuSNYvGrOE
{
	[CompilerGenerated]
	private string asnJypFwYDrBZcLKiKHyAbItoPh;

	[CompilerGenerated]
	private QTBMtemSTKEFyypUdDxnYBkZCjsF IhbjGLIeHGBoLhDdjktAaMLEVWO;

	[CompilerGenerated]
	private IntPtr IRxvUdihzkflOstxdOpXuGLkdBC;

	public string DeviceName
	{
		[CompilerGenerated]
		get
		{
			return asnJypFwYDrBZcLKiKHyAbItoPh;
		}
		[CompilerGenerated]
		set
		{
			asnJypFwYDrBZcLKiKHyAbItoPh = value;
		}
	}

	public QTBMtemSTKEFyypUdDxnYBkZCjsF DeviceType
	{
		[CompilerGenerated]
		get
		{
			return IhbjGLIeHGBoLhDdjktAaMLEVWO;
		}
		[CompilerGenerated]
		set
		{
			IhbjGLIeHGBoLhDdjktAaMLEVWO = value;
		}
	}

	public IntPtr Handle
	{
		[CompilerGenerated]
		get
		{
			return IRxvUdihzkflOstxdOpXuGLkdBC;
		}
		[CompilerGenerated]
		set
		{
			IRxvUdihzkflOstxdOpXuGLkdBC = value;
		}
	}

	public gEWwYLSxPEAKISAVsGBuSNYvGrOE()
	{
	}

	internal gEWwYLSxPEAKISAVsGBuSNYvGrOE(ref coTdQBHIinEwNHUXyMqDcnzUPAno rawDeviceInfo, string deviceName, IntPtr deviceHandle)
	{
		DeviceName = deviceName;
		Handle = deviceHandle;
		DeviceType = rawDeviceInfo.YTPnvkUhAkJQzxOddhUvMmmVSrU;
	}

	internal static gEWwYLSxPEAKISAVsGBuSNYvGrOE FpCAFjlSksvpKExMiTMpyCIOxFF(ref coTdQBHIinEwNHUXyMqDcnzUPAno P_0, string P_1, IntPtr P_2)
	{
		gEWwYLSxPEAKISAVsGBuSNYvGrOE gEWwYLSxPEAKISAVsGBuSNYvGrOE2 = null;
		switch (P_0.YTPnvkUhAkJQzxOddhUvMmmVSrU)
		{
		case QTBMtemSTKEFyypUdDxnYBkZCjsF.BdxbQpdhxedMbOCtPJkbSeZAwWGg:
			return new mIFFTdrbNcbzbukmuqHJRmmAKeH(ref P_0, P_1, P_2);
		case QTBMtemSTKEFyypUdDxnYBkZCjsF.otHBHGZfzdEKPVeyweIkhCMmKxf:
			return new wCRDAgmcXgTHSgcfhQZuqEhrzdX(ref P_0, P_1, P_2);
		case QTBMtemSTKEFyypUdDxnYBkZCjsF.ViWzCydCNFcFRKBZTpduMcxrfKx:
			return new oSOpmAwseGFmFUJezbLUdpAnJSF(ref P_0, P_1, P_2);
		default:
			throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Unsupported Device Type [{0}]", new object[1] { (int)P_0.YTPnvkUhAkJQzxOddhUvMmmVSrU }));
		}
	}
}
