using System;

internal struct tMVYqALdVYAGFHBZPwBgwNZQbpA
{
	private int bVrFJvLWBKZJakASEAqTGanVnDRR;

	private long uXVuwqANDUPxUlQOpQGbRlkSjjX;

	private static readonly bool BkUdrPIUwGplwCKYlqooVJJDDJEj;

	public static readonly int tnjnnszAeVgbCefqvSkKimCiVDd;

	static tMVYqALdVYAGFHBZPwBgwNZQbpA()
	{
		BkUdrPIUwGplwCKYlqooVJJDDJEj = IntPtr.Size == 8;
		tnjnnszAeVgbCefqvSkKimCiVDd = (BkUdrPIUwGplwCKYlqooVJJDDJEj ? 8 : 4);
	}

	public static tMVYqALdVYAGFHBZPwBgwNZQbpA XKnIdqweJtJnkdixUOPtfzefctU(byte[] P_0, int P_1)
	{
		tMVYqALdVYAGFHBZPwBgwNZQbpA result = default(tMVYqALdVYAGFHBZPwBgwNZQbpA);
		if (BkUdrPIUwGplwCKYlqooVJJDDJEj)
		{
			result.uXVuwqANDUPxUlQOpQGbRlkSjjX = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.bVrFJvLWBKZJakASEAqTGanVnDRR = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	public static implicit operator int(tMVYqALdVYAGFHBZPwBgwNZQbpA obj)
	{
		if (BkUdrPIUwGplwCKYlqooVJJDDJEj)
		{
			return (int)obj.uXVuwqANDUPxUlQOpQGbRlkSjjX;
		}
		return obj.bVrFJvLWBKZJakASEAqTGanVnDRR;
	}

	public static implicit operator long(tMVYqALdVYAGFHBZPwBgwNZQbpA obj)
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
