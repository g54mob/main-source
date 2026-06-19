using System;

internal struct ayVQLhfZkhEnILDhXFIkBjfQFsF
{
	private uint bVrFJvLWBKZJakASEAqTGanVnDRR;

	private ulong uXVuwqANDUPxUlQOpQGbRlkSjjX;

	private static readonly bool BkUdrPIUwGplwCKYlqooVJJDDJEj;

	public static readonly int tnjnnszAeVgbCefqvSkKimCiVDd;

	static ayVQLhfZkhEnILDhXFIkBjfQFsF()
	{
		BkUdrPIUwGplwCKYlqooVJJDDJEj = IntPtr.Size == 8;
		tnjnnszAeVgbCefqvSkKimCiVDd = (BkUdrPIUwGplwCKYlqooVJJDDJEj ? 8 : 4);
	}

	public static ayVQLhfZkhEnILDhXFIkBjfQFsF XKnIdqweJtJnkdixUOPtfzefctU(byte[] P_0, int P_1)
	{
		ayVQLhfZkhEnILDhXFIkBjfQFsF result = default(ayVQLhfZkhEnILDhXFIkBjfQFsF);
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

	public static implicit operator uint(ayVQLhfZkhEnILDhXFIkBjfQFsF obj)
	{
		if (BkUdrPIUwGplwCKYlqooVJJDDJEj)
		{
			return (uint)obj.uXVuwqANDUPxUlQOpQGbRlkSjjX;
		}
		return obj.bVrFJvLWBKZJakASEAqTGanVnDRR;
	}

	public static implicit operator ulong(ayVQLhfZkhEnILDhXFIkBjfQFsF obj)
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
