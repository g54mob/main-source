using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct YvVkQPzMBUosNIBjDcPfESKuCCRN
{
	[FieldOffset(0)]
	private uint VQhHQKFVzrtipLyrDoQUxjLziTFX;

	[FieldOffset(0)]
	private ulong GLVxhLQDbwGsuSqfHikXfUJwffzUA;

	[FieldOffset(0)]
	private IntPtr InVcUxhuKlxvxgvaoBkIEMtANenK;

	private static readonly bool hWQcuKIWAfUxKlnIaMbrWrthBhKC;

	public static readonly int TnbqoUvYgoTtgZoGauUtjgKQTcti;

	static YvVkQPzMBUosNIBjDcPfESKuCCRN()
	{
		TnbqoUvYgoTtgZoGauUtjgKQTcti = IntPtr.Size;
		hWQcuKIWAfUxKlnIaMbrWrthBhKC = TnbqoUvYgoTtgZoGauUtjgKQTcti == 8;
	}

	public static YvVkQPzMBUosNIBjDcPfESKuCCRN roxDXNunuWegdGGVJoHuwBGRcdSk(byte[] P_0, int P_1)
	{
		YvVkQPzMBUosNIBjDcPfESKuCCRN result = default(YvVkQPzMBUosNIBjDcPfESKuCCRN);
		if (hWQcuKIWAfUxKlnIaMbrWrthBhKC)
		{
			result.GLVxhLQDbwGsuSqfHikXfUJwffzUA = BitConverter.ToUInt64(P_0, P_1);
			result.InVcUxhuKlxvxgvaoBkIEMtANenK = new IntPtr((long)result.GLVxhLQDbwGsuSqfHikXfUJwffzUA);
		}
		else
		{
			result.VQhHQKFVzrtipLyrDoQUxjLziTFX = BitConverter.ToUInt32(P_0, P_1);
			result.InVcUxhuKlxvxgvaoBkIEMtANenK = new IntPtr((int)result.VQhHQKFVzrtipLyrDoQUxjLziTFX);
		}
		return result;
	}

	[SpecialName]
	public static IntPtr bPhBTDiXwPSGeHgqUdzKHurTqKRxA(YvVkQPzMBUosNIBjDcPfESKuCCRN P_0)
	{
		return P_0.InVcUxhuKlxvxgvaoBkIEMtANenK;
	}

	[SpecialName]
	public static YvVkQPzMBUosNIBjDcPfESKuCCRN bPhBTDiXwPSGeHgqUdzKHurTqKRxA(IntPtr P_0)
	{
		YvVkQPzMBUosNIBjDcPfESKuCCRN result = new YvVkQPzMBUosNIBjDcPfESKuCCRN
		{
			InVcUxhuKlxvxgvaoBkIEMtANenK = P_0
		};
		if (hWQcuKIWAfUxKlnIaMbrWrthBhKC)
		{
			result.GLVxhLQDbwGsuSqfHikXfUJwffzUA = (ulong)P_0.ToInt64();
		}
		else
		{
			result.VQhHQKFVzrtipLyrDoQUxjLziTFX = (uint)P_0.ToInt32();
		}
		return result;
	}

	public string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
	{
		if (hWQcuKIWAfUxKlnIaMbrWrthBhKC)
		{
			return GLVxhLQDbwGsuSqfHikXfUJwffzUA.ToString();
		}
		return VQhHQKFVzrtipLyrDoQUxjLziTFX.ToString();
	}

	public int aTkpOHobTrGBLFwklNMJaYxzLCubA()
	{
		if (hWQcuKIWAfUxKlnIaMbrWrthBhKC)
		{
			return (int)GLVxhLQDbwGsuSqfHikXfUJwffzUA;
		}
		return (int)VQhHQKFVzrtipLyrDoQUxjLziTFX;
	}
}
