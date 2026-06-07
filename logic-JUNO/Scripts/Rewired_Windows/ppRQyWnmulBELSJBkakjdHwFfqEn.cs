using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct ppRQyWnmulBELSJBkakjdHwFfqEn : IEquatable<ppRQyWnmulBELSJBkakjdHwFfqEn>
{
	private int PQKWbSvuSSUTosQJUXfGwzxvudPg;

	public ppRQyWnmulBELSJBkakjdHwFfqEn(bool P_0)
	{
		PQKWbSvuSSUTosQJUXfGwzxvudPg = (P_0 ? 1 : 0);
	}

	public bool Equals(ppRQyWnmulBELSJBkakjdHwFfqEn other)
	{
		return PQKWbSvuSSUTosQJUXfGwzxvudPg == other.PQKWbSvuSSUTosQJUXfGwzxvudPg;
	}

	bool IEquatable<ppRQyWnmulBELSJBkakjdHwFfqEn>.Equals(ppRQyWnmulBELSJBkakjdHwFfqEn other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool VVCVrUHKwPdEJSvDPkgraHPYPAoR(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0 is ppRQyWnmulBELSJBkakjdHwFfqEn)
		{
			return Equals((ppRQyWnmulBELSJBkakjdHwFfqEn)P_0);
		}
		return false;
	}

	public int yllHfaheCbbtMkoZwTcQxiGyyJnt()
	{
		return PQKWbSvuSSUTosQJUXfGwzxvudPg;
	}

	[SpecialName]
	public static bool TELZObcccdBJxbJOobmOlCkHiFITA(ppRQyWnmulBELSJBkakjdHwFfqEn P_0, ppRQyWnmulBELSJBkakjdHwFfqEn P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool nZnaOUdSgHAkKjmIksKUloiDOZbWA(ppRQyWnmulBELSJBkakjdHwFfqEn P_0, ppRQyWnmulBELSJBkakjdHwFfqEn P_1)
	{
		return !P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool IfWGYDZqGoCNwdmicOvlfMsitomDB(ppRQyWnmulBELSJBkakjdHwFfqEn P_0)
	{
		return P_0.PQKWbSvuSSUTosQJUXfGwzxvudPg != 0;
	}

	[SpecialName]
	public static ppRQyWnmulBELSJBkakjdHwFfqEn ZYaMDIvhvNndapvAyDFsOQXrfCaI(bool P_0)
	{
		return new ppRQyWnmulBELSJBkakjdHwFfqEn(P_0);
	}

	public string AbMumKcgtIdTUArjQUVFIwdAwygaA()
	{
		return $"{PQKWbSvuSSUTosQJUXfGwzxvudPg != 0}";
	}
}
