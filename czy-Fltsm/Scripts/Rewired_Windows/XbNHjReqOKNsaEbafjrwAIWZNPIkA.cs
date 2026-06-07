using System;
using System.Runtime.CompilerServices;

internal struct XbNHjReqOKNsaEbafjrwAIWZNPIkA
{
	private uint VKdSqVCxCxvODHHOgFcAklXUSqZtA;

	private ulong njGBwAjyXxpTjrhdaOHGnyTdffYx;

	private static readonly bool mAlLwdCBIdeWCcmxuDcOgCDgomgi;

	public static readonly int OiklJJMvLbCLxohzMrEbIiuIsGas;

	static XbNHjReqOKNsaEbafjrwAIWZNPIkA()
	{
		mAlLwdCBIdeWCcmxuDcOgCDgomgi = IntPtr.Size == 8;
		OiklJJMvLbCLxohzMrEbIiuIsGas = (mAlLwdCBIdeWCcmxuDcOgCDgomgi ? 8 : 4);
	}

	public static XbNHjReqOKNsaEbafjrwAIWZNPIkA kJmOqaKmJqGfGeUHAlbdPTKRxmQp(byte[] P_0, int P_1)
	{
		XbNHjReqOKNsaEbafjrwAIWZNPIkA result = default(XbNHjReqOKNsaEbafjrwAIWZNPIkA);
		if (mAlLwdCBIdeWCcmxuDcOgCDgomgi)
		{
			result.njGBwAjyXxpTjrhdaOHGnyTdffYx = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.VKdSqVCxCxvODHHOgFcAklXUSqZtA = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint CIxlhdppeYukOYlEBDjWEoEuNkeZ(XbNHjReqOKNsaEbafjrwAIWZNPIkA P_0)
	{
		if (mAlLwdCBIdeWCcmxuDcOgCDgomgi)
		{
			return (uint)P_0.njGBwAjyXxpTjrhdaOHGnyTdffYx;
		}
		return P_0.VKdSqVCxCxvODHHOgFcAklXUSqZtA;
	}

	[SpecialName]
	public static ulong CIxlhdppeYukOYlEBDjWEoEuNkeZ(XbNHjReqOKNsaEbafjrwAIWZNPIkA P_0)
	{
		if (mAlLwdCBIdeWCcmxuDcOgCDgomgi)
		{
			return P_0.njGBwAjyXxpTjrhdaOHGnyTdffYx;
		}
		return P_0.VKdSqVCxCxvODHHOgFcAklXUSqZtA;
	}

	public string nbxHRIVSGldewBmtbjnEnQBGCoLC()
	{
		if (mAlLwdCBIdeWCcmxuDcOgCDgomgi)
		{
			return njGBwAjyXxpTjrhdaOHGnyTdffYx.ToString();
		}
		return VKdSqVCxCxvODHHOgFcAklXUSqZtA.ToString();
	}
}
