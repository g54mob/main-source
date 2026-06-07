using System;
using System.Runtime.CompilerServices;

internal struct CdXvfQpULBXyvsFJvnbpvspdeBpd
{
	private int VQhHQKFVzrtipLyrDoQUxjLziTFX;

	private long GLVxhLQDbwGsuSqfHikXfUJwffzUA;

	private static readonly bool hWQcuKIWAfUxKlnIaMbrWrthBhKC;

	public static readonly int TnbqoUvYgoTtgZoGauUtjgKQTcti;

	static CdXvfQpULBXyvsFJvnbpvspdeBpd()
	{
		hWQcuKIWAfUxKlnIaMbrWrthBhKC = IntPtr.Size == 8;
		TnbqoUvYgoTtgZoGauUtjgKQTcti = (hWQcuKIWAfUxKlnIaMbrWrthBhKC ? 8 : 4);
	}

	public static CdXvfQpULBXyvsFJvnbpvspdeBpd roxDXNunuWegdGGVJoHuwBGRcdSk(byte[] P_0, int P_1)
	{
		CdXvfQpULBXyvsFJvnbpvspdeBpd result = default(CdXvfQpULBXyvsFJvnbpvspdeBpd);
		if (hWQcuKIWAfUxKlnIaMbrWrthBhKC)
		{
			result.GLVxhLQDbwGsuSqfHikXfUJwffzUA = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.VQhHQKFVzrtipLyrDoQUxjLziTFX = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int bPhBTDiXwPSGeHgqUdzKHurTqKRxA(CdXvfQpULBXyvsFJvnbpvspdeBpd P_0)
	{
		if (hWQcuKIWAfUxKlnIaMbrWrthBhKC)
		{
			return (int)P_0.GLVxhLQDbwGsuSqfHikXfUJwffzUA;
		}
		return P_0.VQhHQKFVzrtipLyrDoQUxjLziTFX;
	}

	[SpecialName]
	public static long bPhBTDiXwPSGeHgqUdzKHurTqKRxA(CdXvfQpULBXyvsFJvnbpvspdeBpd P_0)
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
