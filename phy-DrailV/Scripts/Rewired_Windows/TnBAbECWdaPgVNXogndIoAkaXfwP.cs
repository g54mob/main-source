using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct TnBAbECWdaPgVNXogndIoAkaXfwP
{
	[FieldOffset(0)]
	private int VQhHQKFVzrtipLyrDoQUxjLziTFX;

	[FieldOffset(0)]
	private long GLVxhLQDbwGsuSqfHikXfUJwffzUA;

	[FieldOffset(0)]
	private IntPtr InVcUxhuKlxvxgvaoBkIEMtANenK;

	private static readonly bool hWQcuKIWAfUxKlnIaMbrWrthBhKC;

	public static readonly int TnbqoUvYgoTtgZoGauUtjgKQTcti;

	static TnBAbECWdaPgVNXogndIoAkaXfwP()
	{
		TnbqoUvYgoTtgZoGauUtjgKQTcti = IntPtr.Size;
		hWQcuKIWAfUxKlnIaMbrWrthBhKC = TnbqoUvYgoTtgZoGauUtjgKQTcti == 8;
	}

	public static TnBAbECWdaPgVNXogndIoAkaXfwP roxDXNunuWegdGGVJoHuwBGRcdSk(byte[] P_0, int P_1)
	{
		TnBAbECWdaPgVNXogndIoAkaXfwP result = default(TnBAbECWdaPgVNXogndIoAkaXfwP);
		if (hWQcuKIWAfUxKlnIaMbrWrthBhKC)
		{
			result.GLVxhLQDbwGsuSqfHikXfUJwffzUA = BitConverter.ToInt64(P_0, P_1);
			result.InVcUxhuKlxvxgvaoBkIEMtANenK = new IntPtr(result.GLVxhLQDbwGsuSqfHikXfUJwffzUA);
		}
		else
		{
			result.VQhHQKFVzrtipLyrDoQUxjLziTFX = BitConverter.ToInt32(P_0, P_1);
			result.InVcUxhuKlxvxgvaoBkIEMtANenK = new IntPtr(result.VQhHQKFVzrtipLyrDoQUxjLziTFX);
		}
		return result;
	}

	[SpecialName]
	public static TnBAbECWdaPgVNXogndIoAkaXfwP bPhBTDiXwPSGeHgqUdzKHurTqKRxA(IntPtr P_0)
	{
		TnBAbECWdaPgVNXogndIoAkaXfwP result = new TnBAbECWdaPgVNXogndIoAkaXfwP
		{
			InVcUxhuKlxvxgvaoBkIEMtANenK = P_0
		};
		if (hWQcuKIWAfUxKlnIaMbrWrthBhKC)
		{
			result.GLVxhLQDbwGsuSqfHikXfUJwffzUA = P_0.ToInt64();
		}
		else
		{
			result.VQhHQKFVzrtipLyrDoQUxjLziTFX = P_0.ToInt32();
		}
		return result;
	}

	[SpecialName]
	public static IntPtr bPhBTDiXwPSGeHgqUdzKHurTqKRxA(TnBAbECWdaPgVNXogndIoAkaXfwP P_0)
	{
		return P_0.InVcUxhuKlxvxgvaoBkIEMtANenK;
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
