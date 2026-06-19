using System;

internal struct rSBXsXBAhPAcixRqfUTPrfwpGsJA
{
	private uint bVrFJvLWBKZJakASEAqTGanVnDRR;

	private ulong uXVuwqANDUPxUlQOpQGbRlkSjjX;

	private static readonly bool BkUdrPIUwGplwCKYlqooVJJDDJEj;

	public static readonly int tnjnnszAeVgbCefqvSkKimCiVDd;

	static rSBXsXBAhPAcixRqfUTPrfwpGsJA()
	{
		BkUdrPIUwGplwCKYlqooVJJDDJEj = IntPtr.Size == 8;
		tnjnnszAeVgbCefqvSkKimCiVDd = (BkUdrPIUwGplwCKYlqooVJJDDJEj ? 8 : 4);
	}

	public static rSBXsXBAhPAcixRqfUTPrfwpGsJA XKnIdqweJtJnkdixUOPtfzefctU(byte[] P_0, int P_1)
	{
		rSBXsXBAhPAcixRqfUTPrfwpGsJA result = default(rSBXsXBAhPAcixRqfUTPrfwpGsJA);
		if (BkUdrPIUwGplwCKYlqooVJJDDJEj)
		{
			result.uXVuwqANDUPxUlQOpQGbRlkSjjX = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.bVrFJvLWBKZJakASEAqTGanVnDRR = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	public static implicit operator uint(rSBXsXBAhPAcixRqfUTPrfwpGsJA obj)
	{
		if (BkUdrPIUwGplwCKYlqooVJJDDJEj)
		{
			return (uint)obj.uXVuwqANDUPxUlQOpQGbRlkSjjX;
		}
		return obj.bVrFJvLWBKZJakASEAqTGanVnDRR;
	}

	public static implicit operator ulong(rSBXsXBAhPAcixRqfUTPrfwpGsJA obj)
	{
		if (BkUdrPIUwGplwCKYlqooVJJDDJEj)
		{
			return obj.uXVuwqANDUPxUlQOpQGbRlkSjjX;
		}
		return obj.bVrFJvLWBKZJakASEAqTGanVnDRR;
	}

	public override string ToString()
	{
		if (BkUdrPIUwGplwCKYlqooVJJDDJEj)
		{
			return uXVuwqANDUPxUlQOpQGbRlkSjjX.ToString();
		}
		return bVrFJvLWBKZJakASEAqTGanVnDRR.ToString();
	}
}
