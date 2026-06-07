using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout((LayoutKind)2, Pack = 1)]
internal struct oymhsAPIfMyZRMQaeDTCWtiWVvgh
{
	[FieldOffset(0)]
	private uint nMebgwUAaxtCqcdzVOkIdlmNnaRj;

	[FieldOffset(0)]
	private ulong yrAORwQSorUsBVKiFUQgGEXqJCkd;

	[FieldOffset(0)]
	private IntPtr hxXMxdcjfYCusTbKjhtOpsyrUABM;

	private static readonly bool aPCzxtenRrdnaImnfhRMtONvLFul;

	public static readonly int cpvgOWECUQEUFAOhISCaGGnWusfjB;

	static oymhsAPIfMyZRMQaeDTCWtiWVvgh()
	{
		cpvgOWECUQEUFAOhISCaGGnWusfjB = IntPtr.Size;
		aPCzxtenRrdnaImnfhRMtONvLFul = cpvgOWECUQEUFAOhISCaGGnWusfjB == 8;
	}

	public static oymhsAPIfMyZRMQaeDTCWtiWVvgh naAYQfrsWipUxkPhVtsEBasdCbFN(byte[] P_0, int P_1)
	{
		oymhsAPIfMyZRMQaeDTCWtiWVvgh result = default(oymhsAPIfMyZRMQaeDTCWtiWVvgh);
		if (aPCzxtenRrdnaImnfhRMtONvLFul)
		{
			result.yrAORwQSorUsBVKiFUQgGEXqJCkd = BitConverter.ToUInt64(P_0, P_1);
			result.hxXMxdcjfYCusTbKjhtOpsyrUABM = new IntPtr((long)result.yrAORwQSorUsBVKiFUQgGEXqJCkd);
		}
		else
		{
			result.nMebgwUAaxtCqcdzVOkIdlmNnaRj = BitConverter.ToUInt32(P_0, P_1);
			result.hxXMxdcjfYCusTbKjhtOpsyrUABM = new IntPtr((int)result.nMebgwUAaxtCqcdzVOkIdlmNnaRj);
		}
		return result;
	}

	[SpecialName]
	public static IntPtr dwVkMnBykzultIstPbxUETXpOOGX(oymhsAPIfMyZRMQaeDTCWtiWVvgh P_0)
	{
		return P_0.hxXMxdcjfYCusTbKjhtOpsyrUABM;
	}

	[SpecialName]
	public static oymhsAPIfMyZRMQaeDTCWtiWVvgh ImXPaiHLtatbwmhHshHWSHnnThoF(IntPtr P_0)
	{
		oymhsAPIfMyZRMQaeDTCWtiWVvgh result = new oymhsAPIfMyZRMQaeDTCWtiWVvgh
		{
			hxXMxdcjfYCusTbKjhtOpsyrUABM = P_0
		};
		if (aPCzxtenRrdnaImnfhRMtONvLFul)
		{
			result.yrAORwQSorUsBVKiFUQgGEXqJCkd = (ulong)P_0.ToInt64();
		}
		else
		{
			result.nMebgwUAaxtCqcdzVOkIdlmNnaRj = (uint)P_0.ToInt32();
		}
		return result;
	}

	public string YUBgQrCmUWyCyhvcsNJgTxfPQdrN()
	{
		if (aPCzxtenRrdnaImnfhRMtONvLFul)
		{
			return yrAORwQSorUsBVKiFUQgGEXqJCkd.ToString();
		}
		return nMebgwUAaxtCqcdzVOkIdlmNnaRj.ToString();
	}

	public int JvRDYSETmAOmGlhbESDLXnmVxbui()
	{
		if (aPCzxtenRrdnaImnfhRMtONvLFul)
		{
			return (int)yrAORwQSorUsBVKiFUQgGEXqJCkd;
		}
		return (int)nMebgwUAaxtCqcdzVOkIdlmNnaRj;
	}
}
