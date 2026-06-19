using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct lyjWWNFEUSvnzPXMgqNfIVDcTyv
{
	[FieldOffset(0)]
	private int bVrFJvLWBKZJakASEAqTGanVnDRR;

	[FieldOffset(0)]
	private long uXVuwqANDUPxUlQOpQGbRlkSjjX;

	[FieldOffset(0)]
	private IntPtr usTDOEbgOOGaiPVLphPkXTayVjK;

	private static readonly bool BkUdrPIUwGplwCKYlqooVJJDDJEj;

	public static readonly int tnjnnszAeVgbCefqvSkKimCiVDd;

	static lyjWWNFEUSvnzPXMgqNfIVDcTyv()
	{
		tnjnnszAeVgbCefqvSkKimCiVDd = IntPtr.Size;
		BkUdrPIUwGplwCKYlqooVJJDDJEj = tnjnnszAeVgbCefqvSkKimCiVDd == 8;
	}

	public static lyjWWNFEUSvnzPXMgqNfIVDcTyv XKnIdqweJtJnkdixUOPtfzefctU(byte[] P_0, int P_1)
	{
		lyjWWNFEUSvnzPXMgqNfIVDcTyv result = default(lyjWWNFEUSvnzPXMgqNfIVDcTyv);
		if (BkUdrPIUwGplwCKYlqooVJJDDJEj)
		{
			result.uXVuwqANDUPxUlQOpQGbRlkSjjX = BitConverter.ToInt64(P_0, P_1);
			result.usTDOEbgOOGaiPVLphPkXTayVjK = new IntPtr(result.uXVuwqANDUPxUlQOpQGbRlkSjjX);
		}
		else
		{
			result.bVrFJvLWBKZJakASEAqTGanVnDRR = BitConverter.ToInt32(P_0, P_1);
			result.usTDOEbgOOGaiPVLphPkXTayVjK = new IntPtr(result.bVrFJvLWBKZJakASEAqTGanVnDRR);
		}
		return result;
	}

	public static implicit operator lyjWWNFEUSvnzPXMgqNfIVDcTyv(IntPtr obj)
	{
		lyjWWNFEUSvnzPXMgqNfIVDcTyv result = new lyjWWNFEUSvnzPXMgqNfIVDcTyv
		{
			usTDOEbgOOGaiPVLphPkXTayVjK = obj
		};
		if (BkUdrPIUwGplwCKYlqooVJJDDJEj)
		{
			result.uXVuwqANDUPxUlQOpQGbRlkSjjX = obj.ToInt64();
		}
		else
		{
			result.bVrFJvLWBKZJakASEAqTGanVnDRR = obj.ToInt32();
		}
		return result;
	}

	public static implicit operator IntPtr(lyjWWNFEUSvnzPXMgqNfIVDcTyv obj)
	{
		return obj.usTDOEbgOOGaiPVLphPkXTayVjK;
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
