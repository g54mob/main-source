using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct SfqsPVLmRZgSrVufaicZklrTKZnE
{
	[FieldOffset(0)]
	private uint VsLgpESVaVnIBpzDMfJrDfWigOMA;

	[FieldOffset(0)]
	private ulong EmKPlzKGVuEZbWKKHtvxsGRdEVdi;

	[FieldOffset(0)]
	private IntPtr ZGJAXqkZyPkaGYpEtiOREZtgyXESA;

	private static readonly bool IPQcugiDQojuWPpxzQjTBUWiMlbj;

	public static readonly int SvvBNFKYHNMAheJrAuhnpuarRpsQA;

	static SfqsPVLmRZgSrVufaicZklrTKZnE()
	{
		SvvBNFKYHNMAheJrAuhnpuarRpsQA = IntPtr.Size;
		IPQcugiDQojuWPpxzQjTBUWiMlbj = SvvBNFKYHNMAheJrAuhnpuarRpsQA == 8;
	}

	public static SfqsPVLmRZgSrVufaicZklrTKZnE DISWPwjNJfzWNrSbBaIVrRhoAaAX(byte[] P_0, int P_1)
	{
		SfqsPVLmRZgSrVufaicZklrTKZnE result = default(SfqsPVLmRZgSrVufaicZklrTKZnE);
		if (IPQcugiDQojuWPpxzQjTBUWiMlbj)
		{
			result.EmKPlzKGVuEZbWKKHtvxsGRdEVdi = BitConverter.ToUInt64(P_0, P_1);
			result.ZGJAXqkZyPkaGYpEtiOREZtgyXESA = new IntPtr((long)result.EmKPlzKGVuEZbWKKHtvxsGRdEVdi);
		}
		else
		{
			result.VsLgpESVaVnIBpzDMfJrDfWigOMA = BitConverter.ToUInt32(P_0, P_1);
			result.ZGJAXqkZyPkaGYpEtiOREZtgyXESA = new IntPtr((int)result.VsLgpESVaVnIBpzDMfJrDfWigOMA);
		}
		return result;
	}

	[SpecialName]
	public static IntPtr DmZETaZVlmwbDRShBfAZkMGinPLN(SfqsPVLmRZgSrVufaicZklrTKZnE P_0)
	{
		return P_0.ZGJAXqkZyPkaGYpEtiOREZtgyXESA;
	}

	[SpecialName]
	public static SfqsPVLmRZgSrVufaicZklrTKZnE oOPSXpTSDzhMIfZBiGDTaFGuKlhK(IntPtr P_0)
	{
		SfqsPVLmRZgSrVufaicZklrTKZnE result = new SfqsPVLmRZgSrVufaicZklrTKZnE
		{
			ZGJAXqkZyPkaGYpEtiOREZtgyXESA = P_0
		};
		if (IPQcugiDQojuWPpxzQjTBUWiMlbj)
		{
			result.EmKPlzKGVuEZbWKKHtvxsGRdEVdi = (ulong)P_0.ToInt64();
		}
		else
		{
			result.VsLgpESVaVnIBpzDMfJrDfWigOMA = (uint)P_0.ToInt32();
		}
		return result;
	}

	public string gnVGPuYrBVPMIyumkpgjjuaSkSol()
	{
		if (IPQcugiDQojuWPpxzQjTBUWiMlbj)
		{
			return EmKPlzKGVuEZbWKKHtvxsGRdEVdi.ToString();
		}
		return VsLgpESVaVnIBpzDMfJrDfWigOMA.ToString();
	}

	public int zhJUXJCEnNSVwcGrOlLOjhrQsstF()
	{
		if (IPQcugiDQojuWPpxzQjTBUWiMlbj)
		{
			return (int)EmKPlzKGVuEZbWKKHtvxsGRdEVdi;
		}
		return (int)VsLgpESVaVnIBpzDMfJrDfWigOMA;
	}
}
