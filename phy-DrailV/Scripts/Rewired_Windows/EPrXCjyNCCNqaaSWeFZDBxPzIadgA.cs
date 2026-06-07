using System;
using Rewired.Utils;

internal class EPrXCjyNCCNqaaSWeFZDBxPzIadgA : IDisposable
{
	private readonly SoDaUPyxhCljCRyOJyRmuMKFqYxD njPEqelkqUAXHcVOBySkfuuGgySaA;

	private readonly int tWUGwPHeHbhDjybxHVkJvLSWIFSP;

	private long AceqDUIgxVrSAeDOAPsglljutcVM;

	private long TJkCErbxJGPRMatJyTahSHKNsTwQ;

	private int FcHlCPwEfeIQiqPWEglFtHEysYGl;

	private bool pOKNXaskChBqrnqaofdKeLPAPLfqA;

	private uint cGSaxecSxrDllgWJrgoKzknOQkIN;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	public int uZcnkQJNFiLjeNZwbKvRYdhkQDys => tWUGwPHeHbhDjybxHVkJvLSWIFSP;

	public int PdFZBvprcbrwrVesiuHCzKZIhTJo => FcHlCPwEfeIQiqPWEglFtHEysYGl;

	public bool CfbJtZwnnDpDOUfqVaYgJJcRLFlf => pOKNXaskChBqrnqaofdKeLPAPLfqA;

	public EPrXCjyNCCNqaaSWeFZDBxPzIadgA(int P_0)
	{
		tWUGwPHeHbhDjybxHVkJvLSWIFSP = P_0;
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("sizeInBytes");
		}
		njPEqelkqUAXHcVOBySkfuuGgySaA = new SoDaUPyxhCljCRyOJyRmuMKFqYxD(P_0);
	}

	public unsafe int EvDntuhsTubUqbxfRrKDVdXsLcYv(byte* P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		P_3 = (int)AceqDUIgxVrSAeDOAPsglljutcVM;
		P_4 = cGSaxecSxrDllgWJrgoKzknOQkIN;
		if (P_0 == null || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		int num = njPEqelkqUAXHcVOBySkfuuGgySaA.SXQFQqvxMovHIpJOhLVDcMlbtntt(P_0, P_1, P_2, (int)AceqDUIgxVrSAeDOAPsglljutcVM);
		if (num == 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += njPEqelkqUAXHcVOBySkfuuGgySaA.SXQFQqvxMovHIpJOhLVDcMlbtntt(P_0 + num, P_1 - num, P_2 - num);
		}
		xACcGChNpPqWGCxQoTJhmcSlbABUA(num);
		return num;
	}

	public unsafe int EvDntuhsTubUqbxfRrKDVdXsLcYv(IntPtr P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			P_3 = (int)AceqDUIgxVrSAeDOAPsglljutcVM;
			P_4 = cGSaxecSxrDllgWJrgoKzknOQkIN;
			return 0;
		}
		return EvDntuhsTubUqbxfRrKDVdXsLcYv((byte*)(void*)P_0, P_1, P_2, out P_3, out P_4);
	}

	public unsafe int EvDntuhsTubUqbxfRrKDVdXsLcYv(byte[] P_0, int P_1, out int P_2, out uint P_3)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = (int)AceqDUIgxVrSAeDOAPsglljutcVM;
			P_3 = cGSaxecSxrDllgWJrgoKzknOQkIN;
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return EvDntuhsTubUqbxfRrKDVdXsLcYv(ptr, P_0.Length, P_1, out P_2, out P_3);
		}
	}

	public unsafe int EvDntuhsTubUqbxfRrKDVdXsLcYv(byte* P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return EvDntuhsTubUqbxfRrKDVdXsLcYv(P_0, P_1, P_2, out num, out num2);
	}

	public int EvDntuhsTubUqbxfRrKDVdXsLcYv(IntPtr P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return EvDntuhsTubUqbxfRrKDVdXsLcYv(P_0, P_1, P_2, out num, out num2);
	}

	public int EvDntuhsTubUqbxfRrKDVdXsLcYv(byte[] P_0, int P_1)
	{
		int num;
		uint num2;
		return EvDntuhsTubUqbxfRrKDVdXsLcYv(P_0, P_1, out num, out num2);
	}

	public unsafe int xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(byte* P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || FcHlCPwEfeIQiqPWEglFtHEysYGl == 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > FcHlCPwEfeIQiqPWEglFtHEysYGl)
		{
			P_2 = FcHlCPwEfeIQiqPWEglFtHEysYGl;
		}
		int num = njPEqelkqUAXHcVOBySkfuuGgySaA.qeNroLlBSCyhrSLEgTvpSIOkaxaGA(P_0, P_1, P_2, (int)TJkCErbxJGPRMatJyTahSHKNsTwQ);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += njPEqelkqUAXHcVOBySkfuuGgySaA.qeNroLlBSCyhrSLEgTvpSIOkaxaGA(P_0 + num, P_1 - num, P_2 - num);
		}
		NpOTrhciUjYhwkLrcolHncfagMMM(num);
		return num;
	}

	public unsafe int xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(byte[] P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(ptr, P_0.Length, P_1);
		}
	}

	public unsafe int xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(IntPtr P_0, int P_1, int P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		return xWPdFkhEuYbKoMqaTzNbLlMyFnpGA((byte*)(void*)P_0, P_1, P_2);
	}

	public unsafe int GufhlYiDQRuINbznbrreTKxVHLUu(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || FcHlCPwEfeIQiqPWEglFtHEysYGl == 0 || P_3 < 0 || P_3 >= tWUGwPHeHbhDjybxHVkJvLSWIFSP)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > FcHlCPwEfeIQiqPWEglFtHEysYGl)
		{
			P_2 = FcHlCPwEfeIQiqPWEglFtHEysYGl;
		}
		int num = njPEqelkqUAXHcVOBySkfuuGgySaA.qeNroLlBSCyhrSLEgTvpSIOkaxaGA(P_0, P_1, P_2, P_3);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += njPEqelkqUAXHcVOBySkfuuGgySaA.qeNroLlBSCyhrSLEgTvpSIOkaxaGA(P_0 + num, P_1 - num, P_2 - num);
		}
		return num;
	}

	public unsafe int GufhlYiDQRuINbznbrreTKxVHLUu(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return GufhlYiDQRuINbznbrreTKxVHLUu(ptr, P_0.Length, P_1, P_2);
		}
	}

	public unsafe int GufhlYiDQRuINbznbrreTKxVHLUu(IntPtr P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_3 <= 0)
		{
			return 0;
		}
		return GufhlYiDQRuINbznbrreTKxVHLUu((byte*)(void*)P_0, P_1, P_2, P_3);
	}

	public bool LOAKUriHGZEbByAroDTyQAHhOjqU(int P_0, uint P_1)
	{
		if (P_0 < 0 || P_0 >= tWUGwPHeHbhDjybxHVkJvLSWIFSP)
		{
			return false;
		}
		if (P_0 < AceqDUIgxVrSAeDOAPsglljutcVM)
		{
			if (P_1 == cGSaxecSxrDllgWJrgoKzknOQkIN)
			{
				return true;
			}
		}
		else if (P_0 >= AceqDUIgxVrSAeDOAPsglljutcVM)
		{
			if (cGSaxecSxrDllgWJrgoKzknOQkIN == 0)
			{
				return false;
			}
			if (cGSaxecSxrDllgWJrgoKzknOQkIN - 1 == P_1)
			{
				return true;
			}
		}
		return false;
	}

	public void sbvNiOKcscCGRBGGcMbdhHrjtptuB()
	{
		AceqDUIgxVrSAeDOAPsglljutcVM = 0L;
		TJkCErbxJGPRMatJyTahSHKNsTwQ = 0L;
		FcHlCPwEfeIQiqPWEglFtHEysYGl = 0;
		pOKNXaskChBqrnqaofdKeLPAPLfqA = false;
		cGSaxecSxrDllgWJrgoKzknOQkIN = 0u;
	}

	private void xACcGChNpPqWGCxQoTJhmcSlbABUA(int P_0)
	{
		if (P_0 <= 0)
		{
			return;
		}
		int num = (int)AceqDUIgxVrSAeDOAPsglljutcVM;
		AceqDUIgxVrSAeDOAPsglljutcVM += P_0;
		bool flag = false;
		if (num < TJkCErbxJGPRMatJyTahSHKNsTwQ)
		{
			if (AceqDUIgxVrSAeDOAPsglljutcVM > TJkCErbxJGPRMatJyTahSHKNsTwQ)
			{
				flag = true;
			}
		}
		else if (num > TJkCErbxJGPRMatJyTahSHKNsTwQ)
		{
			if (AceqDUIgxVrSAeDOAPsglljutcVM - tWUGwPHeHbhDjybxHVkJvLSWIFSP > TJkCErbxJGPRMatJyTahSHKNsTwQ)
			{
				flag = true;
			}
		}
		else if (FcHlCPwEfeIQiqPWEglFtHEysYGl > 0)
		{
			flag = true;
		}
		if (flag)
		{
			pOKNXaskChBqrnqaofdKeLPAPLfqA = true;
			TJkCErbxJGPRMatJyTahSHKNsTwQ = AceqDUIgxVrSAeDOAPsglljutcVM;
			if (TJkCErbxJGPRMatJyTahSHKNsTwQ >= tWUGwPHeHbhDjybxHVkJvLSWIFSP)
			{
				TJkCErbxJGPRMatJyTahSHKNsTwQ -= tWUGwPHeHbhDjybxHVkJvLSWIFSP;
			}
		}
		if (AceqDUIgxVrSAeDOAPsglljutcVM >= tWUGwPHeHbhDjybxHVkJvLSWIFSP)
		{
			AceqDUIgxVrSAeDOAPsglljutcVM -= tWUGwPHeHbhDjybxHVkJvLSWIFSP;
			BGQQLrmhxyecoIurzmjCIAGJbkJoc();
		}
		FcHlCPwEfeIQiqPWEglFtHEysYGl = (int)MathTools.Clamp((long)FcHlCPwEfeIQiqPWEglFtHEysYGl + (long)P_0, 0L, tWUGwPHeHbhDjybxHVkJvLSWIFSP);
	}

	private void NpOTrhciUjYhwkLrcolHncfagMMM(int P_0)
	{
		if (P_0 > 0)
		{
			if (pOKNXaskChBqrnqaofdKeLPAPLfqA)
			{
				pOKNXaskChBqrnqaofdKeLPAPLfqA = false;
			}
			TJkCErbxJGPRMatJyTahSHKNsTwQ += P_0;
			if (TJkCErbxJGPRMatJyTahSHKNsTwQ >= tWUGwPHeHbhDjybxHVkJvLSWIFSP)
			{
				TJkCErbxJGPRMatJyTahSHKNsTwQ -= tWUGwPHeHbhDjybxHVkJvLSWIFSP;
			}
			long num = (long)FcHlCPwEfeIQiqPWEglFtHEysYGl - (long)P_0;
			FcHlCPwEfeIQiqPWEglFtHEysYGl = (int)((num >= 0) ? num : 0);
		}
	}

	private void BGQQLrmhxyecoIurzmjCIAGJbkJoc()
	{
		if (cGSaxecSxrDllgWJrgoKzknOQkIN == uint.MaxValue)
		{
			cGSaxecSxrDllgWJrgoKzknOQkIN = 0u;
		}
		else
		{
			cGSaxecSxrDllgWJrgoKzknOQkIN++;
		}
	}

	public void Dispose()
	{
		vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
	{
		try
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (!JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			if (P_0 && njPEqelkqUAXHcVOBySkfuuGgySaA != null)
			{
				njPEqelkqUAXHcVOBySkfuuGgySaA.Dispose();
			}
			JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
		}
	}
}
