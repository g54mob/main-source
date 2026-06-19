using System;
using System.Runtime.CompilerServices;

internal struct ozgcFzqZMIdjgtpkbMCmEiyAaRNv
{
	private uint sbKjBzMAvfVoNaOiuVwEhjCTkxYd;

	private ulong SFbmxkhvJfiSpAWdilwMrKbqklHX;

	private static readonly bool XaGdANKAKhOzWHNautiQeenpGqddb;

	public static readonly int nGVBKbELJhDIhADzEQtzUIMLrGboA;

	static ozgcFzqZMIdjgtpkbMCmEiyAaRNv()
	{
		XaGdANKAKhOzWHNautiQeenpGqddb = IntPtr.Size == 8;
		nGVBKbELJhDIhADzEQtzUIMLrGboA = (XaGdANKAKhOzWHNautiQeenpGqddb ? 8 : 4);
	}

	public static ozgcFzqZMIdjgtpkbMCmEiyAaRNv PSZCdGCJVqdgCvrZCcGvDZqQMuZbA(byte[] P_0, int P_1)
	{
		ozgcFzqZMIdjgtpkbMCmEiyAaRNv result = default(ozgcFzqZMIdjgtpkbMCmEiyAaRNv);
		if (XaGdANKAKhOzWHNautiQeenpGqddb)
		{
			result.SFbmxkhvJfiSpAWdilwMrKbqklHX = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.sbKjBzMAvfVoNaOiuVwEhjCTkxYd = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint vgOcmFjkuIPdWbOWZuQGeMglYsxn(ozgcFzqZMIdjgtpkbMCmEiyAaRNv P_0)
	{
		if (XaGdANKAKhOzWHNautiQeenpGqddb)
		{
			return (uint)P_0.SFbmxkhvJfiSpAWdilwMrKbqklHX;
		}
		return P_0.sbKjBzMAvfVoNaOiuVwEhjCTkxYd;
	}

	[SpecialName]
	public static ulong vgOcmFjkuIPdWbOWZuQGeMglYsxn(ozgcFzqZMIdjgtpkbMCmEiyAaRNv P_0)
	{
		if (XaGdANKAKhOzWHNautiQeenpGqddb)
		{
			return P_0.SFbmxkhvJfiSpAWdilwMrKbqklHX;
		}
		return P_0.sbKjBzMAvfVoNaOiuVwEhjCTkxYd;
	}

	public string OKAtWtFzSnmgeqywntYWtkkFlCQr()
	{
		if (XaGdANKAKhOzWHNautiQeenpGqddb)
		{
			return SFbmxkhvJfiSpAWdilwMrKbqklHX.ToString();
		}
		return sbKjBzMAvfVoNaOiuVwEhjCTkxYd.ToString();
	}
}
