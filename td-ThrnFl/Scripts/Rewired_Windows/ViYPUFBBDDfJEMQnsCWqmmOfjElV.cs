using System;
using System.Runtime.CompilerServices;

internal struct ViYPUFBBDDfJEMQnsCWqmmOfjElV
{
	private uint ZqmUULzJlmvhpJRRtJWADLEunTkC;

	private ulong hyDiYKIEEecqFtukdvsEFFFFlkzt;

	private static readonly bool kTezllvPPmbXcDcrxtkQkGBQgjBHb;

	public static readonly int IofpHRdoGgwIHqngLxuliDmaROVf;

	static ViYPUFBBDDfJEMQnsCWqmmOfjElV()
	{
		kTezllvPPmbXcDcrxtkQkGBQgjBHb = IntPtr.Size == 8;
		IofpHRdoGgwIHqngLxuliDmaROVf = (kTezllvPPmbXcDcrxtkQkGBQgjBHb ? 8 : 4);
	}

	public static ViYPUFBBDDfJEMQnsCWqmmOfjElV aVlSYiraUfMmsAmUDIshzSCzdxni(byte[] P_0, int P_1)
	{
		ViYPUFBBDDfJEMQnsCWqmmOfjElV result = default(ViYPUFBBDDfJEMQnsCWqmmOfjElV);
		if (kTezllvPPmbXcDcrxtkQkGBQgjBHb)
		{
			result.hyDiYKIEEecqFtukdvsEFFFFlkzt = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.ZqmUULzJlmvhpJRRtJWADLEunTkC = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint UNsZEjSLxHJlcERZASUACEvCraZE(ViYPUFBBDDfJEMQnsCWqmmOfjElV P_0)
	{
		if (kTezllvPPmbXcDcrxtkQkGBQgjBHb)
		{
			return (uint)P_0.hyDiYKIEEecqFtukdvsEFFFFlkzt;
		}
		return P_0.ZqmUULzJlmvhpJRRtJWADLEunTkC;
	}

	[SpecialName]
	public static ulong UNsZEjSLxHJlcERZASUACEvCraZE(ViYPUFBBDDfJEMQnsCWqmmOfjElV P_0)
	{
		if (kTezllvPPmbXcDcrxtkQkGBQgjBHb)
		{
			return P_0.hyDiYKIEEecqFtukdvsEFFFFlkzt;
		}
		return P_0.ZqmUULzJlmvhpJRRtJWADLEunTkC;
	}

	public string zVwetFjmHoDEKwJlwvKSWVAsTHemA()
	{
		if (kTezllvPPmbXcDcrxtkQkGBQgjBHb)
		{
			return hyDiYKIEEecqFtukdvsEFFFFlkzt.ToString();
		}
		return ZqmUULzJlmvhpJRRtJWADLEunTkC.ToString();
	}
}
