using System;

internal struct qXPBkzhlmkEioDqagmPmqJOJykr
{
	private int bVrFJvLWBKZJakASEAqTGanVnDRR;

	private long uXVuwqANDUPxUlQOpQGbRlkSjjX;

	private static readonly bool BkUdrPIUwGplwCKYlqooVJJDDJEj;

	public static readonly int tnjnnszAeVgbCefqvSkKimCiVDd;

	static qXPBkzhlmkEioDqagmPmqJOJykr()
	{
		BkUdrPIUwGplwCKYlqooVJJDDJEj = IntPtr.Size == 8;
		tnjnnszAeVgbCefqvSkKimCiVDd = (BkUdrPIUwGplwCKYlqooVJJDDJEj ? 8 : 4);
	}

	public static qXPBkzhlmkEioDqagmPmqJOJykr XKnIdqweJtJnkdixUOPtfzefctU(byte[] P_0, int P_1)
	{
		qXPBkzhlmkEioDqagmPmqJOJykr result = default(qXPBkzhlmkEioDqagmPmqJOJykr);
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

	public static implicit operator int(qXPBkzhlmkEioDqagmPmqJOJykr obj)
	{
		if (BkUdrPIUwGplwCKYlqooVJJDDJEj)
		{
			return (int)obj.uXVuwqANDUPxUlQOpQGbRlkSjjX;
		}
		return obj.bVrFJvLWBKZJakASEAqTGanVnDRR;
	}

	public static implicit operator long(qXPBkzhlmkEioDqagmPmqJOJykr obj)
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
