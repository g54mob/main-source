using System;
using Rewired.Utils;

internal class HrbEWQgpebVVqUNyRWFGLjblPkV : IDisposable
{
	private readonly OrGbzVsUcUYnmShreCvhbuxVmzF DBZCtHAzIvFuQOarCKsttoMaNgUG;

	private readonly int DKKPdqJtrWmgMVGECYdEoyLcPMS;

	private long efiBCdHCToXrRBThVNAjDcHGCiHd;

	private long zwiRAMxxkleZRTeplOwdBcEbFKm;

	private int lYFoKeyDJLzKbFrdRZFUqdoYgKS;

	private bool LPIUKNcMyUfPkIANfMPTcIhAeNxE;

	private uint IYqgTUcLGtGwpTeoDURoyLqgsUR;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	public int Capacity => DKKPdqJtrWmgMVGECYdEoyLcPMS;

	public int BytesInBuffer => lYFoKeyDJLzKbFrdRZFUqdoYgKS;

	public bool BufferOverrun => LPIUKNcMyUfPkIANfMPTcIhAeNxE;

	public HrbEWQgpebVVqUNyRWFGLjblPkV(int capacity)
	{
		DKKPdqJtrWmgMVGECYdEoyLcPMS = capacity;
		if (capacity <= 0)
		{
			throw new ArgumentOutOfRangeException("sizeInBytes");
		}
		DBZCtHAzIvFuQOarCKsttoMaNgUG = new OrGbzVsUcUYnmShreCvhbuxVmzF(capacity);
	}

	public unsafe int ujTUoJrkpPHtthAWMneMiOxOImEn(byte* P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		P_3 = (int)efiBCdHCToXrRBThVNAjDcHGCiHd;
		P_4 = IYqgTUcLGtGwpTeoDURoyLqgsUR;
		if (P_0 == null || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		int num = DBZCtHAzIvFuQOarCKsttoMaNgUG.epMaJBAdoLzeFFCbmvbUPnNNexnJ(P_0, P_1, P_2, (int)efiBCdHCToXrRBThVNAjDcHGCiHd);
		if (num == 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += DBZCtHAzIvFuQOarCKsttoMaNgUG.epMaJBAdoLzeFFCbmvbUPnNNexnJ(P_0 + num, P_1 - num, P_2 - num);
		}
		NfIqZvVdXaKzHIaxbkvetiuNEQXa(num);
		return num;
	}

	public unsafe int ujTUoJrkpPHtthAWMneMiOxOImEn(IntPtr P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			P_3 = (int)efiBCdHCToXrRBThVNAjDcHGCiHd;
			P_4 = IYqgTUcLGtGwpTeoDURoyLqgsUR;
			return 0;
		}
		return ujTUoJrkpPHtthAWMneMiOxOImEn((byte*)(void*)P_0, P_1, P_2, out P_3, out P_4);
	}

	public unsafe int ujTUoJrkpPHtthAWMneMiOxOImEn(byte[] P_0, int P_1, out int P_2, out uint P_3)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = (int)efiBCdHCToXrRBThVNAjDcHGCiHd;
			P_3 = IYqgTUcLGtGwpTeoDURoyLqgsUR;
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return ujTUoJrkpPHtthAWMneMiOxOImEn(ptr, P_0.Length, P_1, out P_2, out P_3);
		}
	}

	public unsafe int ujTUoJrkpPHtthAWMneMiOxOImEn(byte* P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return ujTUoJrkpPHtthAWMneMiOxOImEn(P_0, P_1, P_2, out num, out num2);
	}

	public int ujTUoJrkpPHtthAWMneMiOxOImEn(IntPtr P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return ujTUoJrkpPHtthAWMneMiOxOImEn(P_0, P_1, P_2, out num, out num2);
	}

	public int ujTUoJrkpPHtthAWMneMiOxOImEn(byte[] P_0, int P_1)
	{
		int num;
		uint num2;
		return ujTUoJrkpPHtthAWMneMiOxOImEn(P_0, P_1, out num, out num2);
	}

	public unsafe int DTWqTxyQfjlbrIFGzfuUHiIHdt(byte* P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || lYFoKeyDJLzKbFrdRZFUqdoYgKS == 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > lYFoKeyDJLzKbFrdRZFUqdoYgKS)
		{
			P_2 = lYFoKeyDJLzKbFrdRZFUqdoYgKS;
		}
		int num = DBZCtHAzIvFuQOarCKsttoMaNgUG.YcTavaBvopmAydprftBqiBcNIfcn(P_0, P_1, P_2, (int)zwiRAMxxkleZRTeplOwdBcEbFKm);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += DBZCtHAzIvFuQOarCKsttoMaNgUG.YcTavaBvopmAydprftBqiBcNIfcn(P_0 + num, P_1 - num, P_2 - num);
		}
		jqYCiUcKuCznlBFShjYSqsDOIYS(num);
		return num;
	}

	public unsafe int DTWqTxyQfjlbrIFGzfuUHiIHdt(byte[] P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return DTWqTxyQfjlbrIFGzfuUHiIHdt(ptr, P_0.Length, P_1);
		}
	}

	public unsafe int DTWqTxyQfjlbrIFGzfuUHiIHdt(IntPtr P_0, int P_1, int P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		return DTWqTxyQfjlbrIFGzfuUHiIHdt((byte*)(void*)P_0, P_1, P_2);
	}

	public unsafe int qTlgsteogoNhWhAWikNtfEJajJWG(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || lYFoKeyDJLzKbFrdRZFUqdoYgKS == 0 || P_3 < 0 || P_3 >= DKKPdqJtrWmgMVGECYdEoyLcPMS)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > lYFoKeyDJLzKbFrdRZFUqdoYgKS)
		{
			P_2 = lYFoKeyDJLzKbFrdRZFUqdoYgKS;
		}
		int num = DBZCtHAzIvFuQOarCKsttoMaNgUG.YcTavaBvopmAydprftBqiBcNIfcn(P_0, P_1, P_2, P_3);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += DBZCtHAzIvFuQOarCKsttoMaNgUG.YcTavaBvopmAydprftBqiBcNIfcn(P_0 + num, P_1 - num, P_2 - num);
		}
		return num;
	}

	public unsafe int qTlgsteogoNhWhAWikNtfEJajJWG(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return qTlgsteogoNhWhAWikNtfEJajJWG(ptr, P_0.Length, P_1, P_2);
		}
	}

	public unsafe int qTlgsteogoNhWhAWikNtfEJajJWG(IntPtr P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_3 <= 0)
		{
			return 0;
		}
		return qTlgsteogoNhWhAWikNtfEJajJWG((byte*)(void*)P_0, P_1, P_2, P_3);
	}

	public bool fsKXIAurwqhSMRhWnbHdPwdRnbq(int P_0, uint P_1)
	{
		if (P_0 < 0 || P_0 >= DKKPdqJtrWmgMVGECYdEoyLcPMS)
		{
			return false;
		}
		if (P_0 < efiBCdHCToXrRBThVNAjDcHGCiHd)
		{
			if (P_1 == IYqgTUcLGtGwpTeoDURoyLqgsUR)
			{
				return true;
			}
		}
		else if (P_0 >= efiBCdHCToXrRBThVNAjDcHGCiHd)
		{
			if (IYqgTUcLGtGwpTeoDURoyLqgsUR == 0)
			{
				return false;
			}
			if (IYqgTUcLGtGwpTeoDURoyLqgsUR - 1 == P_1)
			{
				return true;
			}
		}
		return false;
	}

	public void IJzuzpKYWPzhEvGrjeLwYBPHnpv()
	{
		efiBCdHCToXrRBThVNAjDcHGCiHd = 0L;
		zwiRAMxxkleZRTeplOwdBcEbFKm = 0L;
		lYFoKeyDJLzKbFrdRZFUqdoYgKS = 0;
		LPIUKNcMyUfPkIANfMPTcIhAeNxE = false;
		IYqgTUcLGtGwpTeoDURoyLqgsUR = 0u;
	}

	private void NfIqZvVdXaKzHIaxbkvetiuNEQXa(int P_0)
	{
		if (P_0 <= 0)
		{
			return;
		}
		int num = (int)efiBCdHCToXrRBThVNAjDcHGCiHd;
		efiBCdHCToXrRBThVNAjDcHGCiHd += P_0;
		bool flag = false;
		if (num < zwiRAMxxkleZRTeplOwdBcEbFKm)
		{
			if (efiBCdHCToXrRBThVNAjDcHGCiHd > zwiRAMxxkleZRTeplOwdBcEbFKm)
			{
				flag = true;
			}
		}
		else if (num > zwiRAMxxkleZRTeplOwdBcEbFKm)
		{
			if (efiBCdHCToXrRBThVNAjDcHGCiHd - DKKPdqJtrWmgMVGECYdEoyLcPMS > zwiRAMxxkleZRTeplOwdBcEbFKm)
			{
				flag = true;
			}
		}
		else if (lYFoKeyDJLzKbFrdRZFUqdoYgKS > 0)
		{
			flag = true;
		}
		if (flag)
		{
			LPIUKNcMyUfPkIANfMPTcIhAeNxE = true;
			zwiRAMxxkleZRTeplOwdBcEbFKm = efiBCdHCToXrRBThVNAjDcHGCiHd;
			if (zwiRAMxxkleZRTeplOwdBcEbFKm >= DKKPdqJtrWmgMVGECYdEoyLcPMS)
			{
				zwiRAMxxkleZRTeplOwdBcEbFKm -= DKKPdqJtrWmgMVGECYdEoyLcPMS;
			}
		}
		if (efiBCdHCToXrRBThVNAjDcHGCiHd >= DKKPdqJtrWmgMVGECYdEoyLcPMS)
		{
			efiBCdHCToXrRBThVNAjDcHGCiHd -= DKKPdqJtrWmgMVGECYdEoyLcPMS;
			nZWYWIyTZFaFnZqWsCFDAFsNVmXB();
		}
		lYFoKeyDJLzKbFrdRZFUqdoYgKS = (int)MathTools.Clamp((long)lYFoKeyDJLzKbFrdRZFUqdoYgKS + (long)P_0, 0L, DKKPdqJtrWmgMVGECYdEoyLcPMS);
	}

	private void jqYCiUcKuCznlBFShjYSqsDOIYS(int P_0)
	{
		if (P_0 > 0)
		{
			if (LPIUKNcMyUfPkIANfMPTcIhAeNxE)
			{
				LPIUKNcMyUfPkIANfMPTcIhAeNxE = false;
			}
			zwiRAMxxkleZRTeplOwdBcEbFKm += P_0;
			if (zwiRAMxxkleZRTeplOwdBcEbFKm >= DKKPdqJtrWmgMVGECYdEoyLcPMS)
			{
				zwiRAMxxkleZRTeplOwdBcEbFKm -= DKKPdqJtrWmgMVGECYdEoyLcPMS;
			}
			long num = (long)lYFoKeyDJLzKbFrdRZFUqdoYgKS - (long)P_0;
			lYFoKeyDJLzKbFrdRZFUqdoYgKS = (int)((num >= 0) ? num : 0);
		}
	}

	private void nZWYWIyTZFaFnZqWsCFDAFsNVmXB()
	{
		if (IYqgTUcLGtGwpTeoDURoyLqgsUR == uint.MaxValue)
		{
			IYqgTUcLGtGwpTeoDURoyLqgsUR = 0u;
		}
		else
		{
			IYqgTUcLGtGwpTeoDURoyLqgsUR++;
		}
	}

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~HrbEWQgpebVVqUNyRWFGLjblPkV()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	protected void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			if (P_0 && DBZCtHAzIvFuQOarCKsttoMaNgUG != null)
			{
				DBZCtHAzIvFuQOarCKsttoMaNgUG.Dispose();
			}
			dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
		}
	}
}
