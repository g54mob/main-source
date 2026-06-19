using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct gucLkXvEiWCZWkHkbOGaIbKxUUki
{
	[FieldOffset(0)]
	private int uZuwWnwSLdNPNtZJcTFgVphARUIG;

	[FieldOffset(0)]
	private long FCSfBimxNFDCNGMsqffHOUOFpkA;

	[FieldOffset(0)]
	private IntPtr UYIpUFREirBOAqAbFrIppyIHhkAL;

	private static readonly bool PSUbUCDPoLclaadHidRqnGXubGjDA;

	public static readonly int azJHqxnpPciFJcxtjstdBpuHvDNt;

	static gucLkXvEiWCZWkHkbOGaIbKxUUki()
	{
		azJHqxnpPciFJcxtjstdBpuHvDNt = IntPtr.Size;
		PSUbUCDPoLclaadHidRqnGXubGjDA = azJHqxnpPciFJcxtjstdBpuHvDNt == 8;
	}

	public static gucLkXvEiWCZWkHkbOGaIbKxUUki RQAlRKALXAWvupBzZgHGkwzpjPQd(byte[] P_0, int P_1)
	{
		gucLkXvEiWCZWkHkbOGaIbKxUUki result = default(gucLkXvEiWCZWkHkbOGaIbKxUUki);
		if (PSUbUCDPoLclaadHidRqnGXubGjDA)
		{
			result.FCSfBimxNFDCNGMsqffHOUOFpkA = BitConverter.ToInt64(P_0, P_1);
			result.UYIpUFREirBOAqAbFrIppyIHhkAL = new IntPtr(result.FCSfBimxNFDCNGMsqffHOUOFpkA);
		}
		else
		{
			result.uZuwWnwSLdNPNtZJcTFgVphARUIG = BitConverter.ToInt32(P_0, P_1);
			result.UYIpUFREirBOAqAbFrIppyIHhkAL = new IntPtr(result.uZuwWnwSLdNPNtZJcTFgVphARUIG);
		}
		return result;
	}

	[SpecialName]
	public static gucLkXvEiWCZWkHkbOGaIbKxUUki WCxXnxVsdBFddnZitYhgksgQtjoJ(IntPtr P_0)
	{
		gucLkXvEiWCZWkHkbOGaIbKxUUki result = new gucLkXvEiWCZWkHkbOGaIbKxUUki
		{
			UYIpUFREirBOAqAbFrIppyIHhkAL = P_0
		};
		if (PSUbUCDPoLclaadHidRqnGXubGjDA)
		{
			result.FCSfBimxNFDCNGMsqffHOUOFpkA = P_0.ToInt64();
		}
		else
		{
			result.uZuwWnwSLdNPNtZJcTFgVphARUIG = P_0.ToInt32();
		}
		return result;
	}

	[SpecialName]
	public static IntPtr IXAEbEiKrMWcXAlrSlFGcboVsEzAA(gucLkXvEiWCZWkHkbOGaIbKxUUki P_0)
	{
		return P_0.UYIpUFREirBOAqAbFrIppyIHhkAL;
	}

	public string aahafBSJZbmVSUkOKfFCAHOcRqslA()
	{
		if (PSUbUCDPoLclaadHidRqnGXubGjDA)
		{
			return FCSfBimxNFDCNGMsqffHOUOFpkA.ToString();
		}
		return uZuwWnwSLdNPNtZJcTFgVphARUIG.ToString();
	}
}
