using System;
using System.Runtime.CompilerServices;

internal struct BGPOsNPVcoRflMHWqvKfiKIPiHRD
{
	private uint VQhHQKFVzrtipLyrDoQUxjLziTFX;

	private ulong GLVxhLQDbwGsuSqfHikXfUJwffzUA;

	private static readonly bool hWQcuKIWAfUxKlnIaMbrWrthBhKC;

	public static readonly int TnbqoUvYgoTtgZoGauUtjgKQTcti;

	static BGPOsNPVcoRflMHWqvKfiKIPiHRD()
	{
		hWQcuKIWAfUxKlnIaMbrWrthBhKC = IntPtr.Size == 8;
		TnbqoUvYgoTtgZoGauUtjgKQTcti = (hWQcuKIWAfUxKlnIaMbrWrthBhKC ? 8 : 4);
	}

	public static BGPOsNPVcoRflMHWqvKfiKIPiHRD roxDXNunuWegdGGVJoHuwBGRcdSk(byte[] P_0, int P_1)
	{
		BGPOsNPVcoRflMHWqvKfiKIPiHRD result = default(BGPOsNPVcoRflMHWqvKfiKIPiHRD);
		if (hWQcuKIWAfUxKlnIaMbrWrthBhKC)
		{
			result.GLVxhLQDbwGsuSqfHikXfUJwffzUA = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.VQhHQKFVzrtipLyrDoQUxjLziTFX = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint bPhBTDiXwPSGeHgqUdzKHurTqKRxA(BGPOsNPVcoRflMHWqvKfiKIPiHRD P_0)
	{
		if (hWQcuKIWAfUxKlnIaMbrWrthBhKC)
		{
			return (uint)P_0.GLVxhLQDbwGsuSqfHikXfUJwffzUA;
		}
		return P_0.VQhHQKFVzrtipLyrDoQUxjLziTFX;
	}

	[SpecialName]
	public static ulong bPhBTDiXwPSGeHgqUdzKHurTqKRxA(BGPOsNPVcoRflMHWqvKfiKIPiHRD P_0)
	{
		if (hWQcuKIWAfUxKlnIaMbrWrthBhKC)
		{
			return P_0.GLVxhLQDbwGsuSqfHikXfUJwffzUA;
		}
		return P_0.VQhHQKFVzrtipLyrDoQUxjLziTFX;
	}

	public string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
	{
		if (hWQcuKIWAfUxKlnIaMbrWrthBhKC)
		{
			return GLVxhLQDbwGsuSqfHikXfUJwffzUA.ToString();
		}
		return VQhHQKFVzrtipLyrDoQUxjLziTFX.ToString();
	}
}
