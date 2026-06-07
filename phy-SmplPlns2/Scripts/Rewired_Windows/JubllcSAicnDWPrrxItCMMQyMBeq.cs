using System;
using System.Runtime.CompilerServices;

internal struct JubllcSAicnDWPrrxItCMMQyMBeq
{
	private int mfNChXwenlRBAbDyRiCSfdhKYeik;

	private long rrejhGsXFgAzzLEsBsRfhSlYEWTAA;

	private static readonly bool SdpmmLayAkJeZPqtBVtpLkexrzKV;

	public static readonly int SICCQLiOBnuaLsegbGUSOYrZiPZq;

	static JubllcSAicnDWPrrxItCMMQyMBeq()
	{
		SdpmmLayAkJeZPqtBVtpLkexrzKV = IntPtr.Size == 8;
		SICCQLiOBnuaLsegbGUSOYrZiPZq = (SdpmmLayAkJeZPqtBVtpLkexrzKV ? 8 : 4);
	}

	public static JubllcSAicnDWPrrxItCMMQyMBeq uwpSFxiFCMExDDmRNKdDAihFnYrc(byte[] P_0, int P_1)
	{
		JubllcSAicnDWPrrxItCMMQyMBeq result = default(JubllcSAicnDWPrrxItCMMQyMBeq);
		if (SdpmmLayAkJeZPqtBVtpLkexrzKV)
		{
			result.rrejhGsXFgAzzLEsBsRfhSlYEWTAA = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.mfNChXwenlRBAbDyRiCSfdhKYeik = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int zBIrvgdGuETQrGuyVxMSGjIzmgDi(JubllcSAicnDWPrrxItCMMQyMBeq P_0)
	{
		if (SdpmmLayAkJeZPqtBVtpLkexrzKV)
		{
			return (int)P_0.rrejhGsXFgAzzLEsBsRfhSlYEWTAA;
		}
		return P_0.mfNChXwenlRBAbDyRiCSfdhKYeik;
	}

	[SpecialName]
	public static long zBIrvgdGuETQrGuyVxMSGjIzmgDi(JubllcSAicnDWPrrxItCMMQyMBeq P_0)
	{
		if (SdpmmLayAkJeZPqtBVtpLkexrzKV)
		{
			return P_0.rrejhGsXFgAzzLEsBsRfhSlYEWTAA;
		}
		return P_0.mfNChXwenlRBAbDyRiCSfdhKYeik;
	}

	public string vZXAzLXRUWlCMNyqurJWvYjSrbVS()
	{
		if (SdpmmLayAkJeZPqtBVtpLkexrzKV)
		{
			return rrejhGsXFgAzzLEsBsRfhSlYEWTAA.ToString();
		}
		return mfNChXwenlRBAbDyRiCSfdhKYeik.ToString();
	}
}
