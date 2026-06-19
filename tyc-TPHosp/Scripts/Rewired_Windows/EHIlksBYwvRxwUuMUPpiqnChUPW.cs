using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct EHIlksBYwvRxwUuMUPpiqnChUPW
{
	[FieldOffset(0)]
	private uint bVrFJvLWBKZJakASEAqTGanVnDRR;

	[FieldOffset(0)]
	private ulong uXVuwqANDUPxUlQOpQGbRlkSjjX;

	[FieldOffset(0)]
	private IntPtr usTDOEbgOOGaiPVLphPkXTayVjK;

	private static readonly bool BkUdrPIUwGplwCKYlqooVJJDDJEj;

	public static readonly int tnjnnszAeVgbCefqvSkKimCiVDd;

	static EHIlksBYwvRxwUuMUPpiqnChUPW()
	{
		tnjnnszAeVgbCefqvSkKimCiVDd = IntPtr.Size;
		BkUdrPIUwGplwCKYlqooVJJDDJEj = tnjnnszAeVgbCefqvSkKimCiVDd == 8;
	}

	public static EHIlksBYwvRxwUuMUPpiqnChUPW XKnIdqweJtJnkdixUOPtfzefctU(byte[] P_0, int P_1)
	{
		EHIlksBYwvRxwUuMUPpiqnChUPW result = default(EHIlksBYwvRxwUuMUPpiqnChUPW);
		if (BkUdrPIUwGplwCKYlqooVJJDDJEj)
		{
			result.uXVuwqANDUPxUlQOpQGbRlkSjjX = BitConverter.ToUInt64(P_0, P_1);
			result.usTDOEbgOOGaiPVLphPkXTayVjK = new IntPtr((long)result.uXVuwqANDUPxUlQOpQGbRlkSjjX);
		}
		else
		{
			result.bVrFJvLWBKZJakASEAqTGanVnDRR = BitConverter.ToUInt32(P_0, P_1);
			result.usTDOEbgOOGaiPVLphPkXTayVjK = new IntPtr((int)result.bVrFJvLWBKZJakASEAqTGanVnDRR);
		}
		return result;
	}

	public static implicit operator IntPtr(EHIlksBYwvRxwUuMUPpiqnChUPW obj)
	{
		return obj.usTDOEbgOOGaiPVLphPkXTayVjK;
	}

	public static implicit operator EHIlksBYwvRxwUuMUPpiqnChUPW(IntPtr obj)
	{
		EHIlksBYwvRxwUuMUPpiqnChUPW result = new EHIlksBYwvRxwUuMUPpiqnChUPW
		{
			usTDOEbgOOGaiPVLphPkXTayVjK = obj
		};
		if (BkUdrPIUwGplwCKYlqooVJJDDJEj)
		{
			result.uXVuwqANDUPxUlQOpQGbRlkSjjX = (ulong)obj.ToInt64();
		}
		else
		{
			result.bVrFJvLWBKZJakASEAqTGanVnDRR = (uint)obj.ToInt32();
		}
		return result;
	}

	public override string ToString()
	{
		if (BkUdrPIUwGplwCKYlqooVJJDDJEj)
		{
			return uXVuwqANDUPxUlQOpQGbRlkSjjX.ToString();
		}
		return bVrFJvLWBKZJakASEAqTGanVnDRR.ToString();
	}

	public int GumyXgoXjWccYPgLapqAZFRTzQs()
	{
		if (BkUdrPIUwGplwCKYlqooVJJDDJEj)
		{
			return (int)uXVuwqANDUPxUlQOpQGbRlkSjjX;
		}
		return (int)bVrFJvLWBKZJakASEAqTGanVnDRR;
	}
}
