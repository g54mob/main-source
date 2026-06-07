using System;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class iyIwThXmVTAIckoxFwEfUfmQUsL
{
	[CompilerGenerated]
	private string oKrftVEiQCcVhdGeZUUfuKySnAaB;

	[CompilerGenerated]
	private MAPTyOhgNVdBQSioUpquSdYiRkd GNdgNpFpPZqazzCZAgkZhMrdrVXh;

	[CompilerGenerated]
	private IntPtr GyjiKPdCtxbhgSLPASHIwqbJCIR;

	public string DeviceName
	{
		[CompilerGenerated]
		get
		{
			return oKrftVEiQCcVhdGeZUUfuKySnAaB;
		}
		[CompilerGenerated]
		set
		{
			oKrftVEiQCcVhdGeZUUfuKySnAaB = value;
		}
	}

	public MAPTyOhgNVdBQSioUpquSdYiRkd DeviceType
	{
		[CompilerGenerated]
		get
		{
			return GNdgNpFpPZqazzCZAgkZhMrdrVXh;
		}
		[CompilerGenerated]
		set
		{
			GNdgNpFpPZqazzCZAgkZhMrdrVXh = value;
		}
	}

	public IntPtr Handle
	{
		[CompilerGenerated]
		get
		{
			return GyjiKPdCtxbhgSLPASHIwqbJCIR;
		}
		[CompilerGenerated]
		set
		{
			GyjiKPdCtxbhgSLPASHIwqbJCIR = value;
		}
	}

	public iyIwThXmVTAIckoxFwEfUfmQUsL()
	{
	}

	internal iyIwThXmVTAIckoxFwEfUfmQUsL(ref ghJPqjSBgqEidmvfDuvMlyNpuRu rawDeviceInfo, string deviceName, IntPtr deviceHandle)
	{
		DeviceName = deviceName;
		Handle = deviceHandle;
		DeviceType = rawDeviceInfo.UANajORgEjGJZDtTWdmqYjUulHF;
	}

	internal static iyIwThXmVTAIckoxFwEfUfmQUsL RwYRYRusefnxswccZKlgeBuliwQ(ref ghJPqjSBgqEidmvfDuvMlyNpuRu P_0, string P_1, IntPtr P_2)
	{
		iyIwThXmVTAIckoxFwEfUfmQUsL iyIwThXmVTAIckoxFwEfUfmQUsL2 = null;
		return P_0.UANajORgEjGJZDtTWdmqYjUulHF switch
		{
			MAPTyOhgNVdBQSioUpquSdYiRkd.FwhTFJcoxdOAZsdJarteiktzdNZ => new eCLbMTsKFfJvBGnCXBKQePUbRlEi(ref P_0, P_1, P_2), 
			MAPTyOhgNVdBQSioUpquSdYiRkd.cXiIaGSjeBKnSzIJGvtEtwBDTsm => new ywLOAUvBgpZmmGINCJnpgrBQkkG(ref P_0, P_1, P_2), 
			MAPTyOhgNVdBQSioUpquSdYiRkd.NcOiPCmfYWmxxojUswKfONTIHos => new wYCeZavIwRTCxwBGOGuHfYkGsOU(ref P_0, P_1, P_2), 
			_ => throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Unsupported Device Type [{0}]", new object[1] { (int)P_0.UANajORgEjGJZDtTWdmqYjUulHF })), 
		};
	}
}
