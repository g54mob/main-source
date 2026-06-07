using System;
using Rewired.Utils;

internal class xVZwRfIZmhFLiBymkMcWQqrSZgoh : IDisposable
{
	private readonly sGsLByENMOOLPRqYgWkgmPquaqHj pshxLsVBaxPobdRQOPmmlqHPIgYt;

	private readonly int vBkdwNvPEIeLLOlzCYbRhhkNTPUC;

	private long EWMAsCiobySnwGUQFHWkshYllcHAb;

	private long DbYpEhNgFpebuUuNvOLnOalIGNgo;

	private int HtrCVUWhDUrSGCCXAFLQdbxcAYpA;

	private bool pauHmcFGCCzHHFumzHFSdTiVbRzSA;

	private uint iYiMsgQfrMOmPWWHkCIQfCMHiqOQ;

	private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

	public int usMgZCzVVRvMWpxkcdNZKaEbUXwo => vBkdwNvPEIeLLOlzCYbRhhkNTPUC;

	public int XRpEabTisQZNNhHsxRpAhRgTkZPq => HtrCVUWhDUrSGCCXAFLQdbxcAYpA;

	public bool UxNAgZGpnicQqIqpEbGssHyIiVnz => pauHmcFGCCzHHFumzHFSdTiVbRzSA;

	public xVZwRfIZmhFLiBymkMcWQqrSZgoh(int P_0)
	{
		vBkdwNvPEIeLLOlzCYbRhhkNTPUC = P_0;
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("sizeInBytes");
		}
		pshxLsVBaxPobdRQOPmmlqHPIgYt = new sGsLByENMOOLPRqYgWkgmPquaqHj(P_0);
	}

	public unsafe int EGngQqDBRXlpYmNfKVeBqXohueYWA(byte* P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		P_3 = (int)EWMAsCiobySnwGUQFHWkshYllcHAb;
		P_4 = iYiMsgQfrMOmPWWHkCIQfCMHiqOQ;
		if (P_0 == null || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		int num = pshxLsVBaxPobdRQOPmmlqHPIgYt.USkYhwVnEVvwgNsEgQdHaEKaErnhA(P_0, P_1, P_2, (int)EWMAsCiobySnwGUQFHWkshYllcHAb);
		if (num == 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += pshxLsVBaxPobdRQOPmmlqHPIgYt.USkYhwVnEVvwgNsEgQdHaEKaErnhA(P_0 + num, P_1 - num, P_2 - num);
		}
		pimhdWfOnyfpsRLMxOvtettwEKXX(num);
		return num;
	}

	public unsafe int EGngQqDBRXlpYmNfKVeBqXohueYWA(IntPtr P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			P_3 = (int)EWMAsCiobySnwGUQFHWkshYllcHAb;
			P_4 = iYiMsgQfrMOmPWWHkCIQfCMHiqOQ;
			return 0;
		}
		return EGngQqDBRXlpYmNfKVeBqXohueYWA((byte*)(void*)P_0, P_1, P_2, out P_3, out P_4);
	}

	public unsafe int EGngQqDBRXlpYmNfKVeBqXohueYWA(byte[] P_0, int P_1, out int P_2, out uint P_3)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = (int)EWMAsCiobySnwGUQFHWkshYllcHAb;
			P_3 = iYiMsgQfrMOmPWWHkCIQfCMHiqOQ;
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return EGngQqDBRXlpYmNfKVeBqXohueYWA(ptr, P_0.Length, P_1, out P_2, out P_3);
		}
	}

	public unsafe int EGngQqDBRXlpYmNfKVeBqXohueYWA(byte* P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return EGngQqDBRXlpYmNfKVeBqXohueYWA(P_0, P_1, P_2, out num, out num2);
	}

	public int EGngQqDBRXlpYmNfKVeBqXohueYWA(IntPtr P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return EGngQqDBRXlpYmNfKVeBqXohueYWA(P_0, P_1, P_2, out num, out num2);
	}

	public int EGngQqDBRXlpYmNfKVeBqXohueYWA(byte[] P_0, int P_1)
	{
		int num;
		uint num2;
		return EGngQqDBRXlpYmNfKVeBqXohueYWA(P_0, P_1, out num, out num2);
	}

	public unsafe int lpzCMyRwfnpZCqiMQhipRjGrjZfC(byte* P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || HtrCVUWhDUrSGCCXAFLQdbxcAYpA == 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > HtrCVUWhDUrSGCCXAFLQdbxcAYpA)
		{
			P_2 = HtrCVUWhDUrSGCCXAFLQdbxcAYpA;
		}
		int num = pshxLsVBaxPobdRQOPmmlqHPIgYt.eYvBZBVlKdXWRcNEjwXxUBhbbrcEA(P_0, P_1, P_2, (int)DbYpEhNgFpebuUuNvOLnOalIGNgo);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += pshxLsVBaxPobdRQOPmmlqHPIgYt.eYvBZBVlKdXWRcNEjwXxUBhbbrcEA(P_0 + num, P_1 - num, P_2 - num);
		}
		ZZwgnzEBAUErCSHxbQIFrISzDQIcA(num);
		return num;
	}

	public unsafe int lpzCMyRwfnpZCqiMQhipRjGrjZfC(byte[] P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return lpzCMyRwfnpZCqiMQhipRjGrjZfC(ptr, P_0.Length, P_1);
		}
	}

	public unsafe int lpzCMyRwfnpZCqiMQhipRjGrjZfC(IntPtr P_0, int P_1, int P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		return lpzCMyRwfnpZCqiMQhipRjGrjZfC((byte*)(void*)P_0, P_1, P_2);
	}

	public unsafe int IoTsQYUEWkgltCZtieFiMPWUeNYUA(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || HtrCVUWhDUrSGCCXAFLQdbxcAYpA == 0 || P_3 < 0 || P_3 >= vBkdwNvPEIeLLOlzCYbRhhkNTPUC)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > HtrCVUWhDUrSGCCXAFLQdbxcAYpA)
		{
			P_2 = HtrCVUWhDUrSGCCXAFLQdbxcAYpA;
		}
		int num = pshxLsVBaxPobdRQOPmmlqHPIgYt.eYvBZBVlKdXWRcNEjwXxUBhbbrcEA(P_0, P_1, P_2, P_3);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += pshxLsVBaxPobdRQOPmmlqHPIgYt.eYvBZBVlKdXWRcNEjwXxUBhbbrcEA(P_0 + num, P_1 - num, P_2 - num);
		}
		return num;
	}

	public unsafe int IoTsQYUEWkgltCZtieFiMPWUeNYUA(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return IoTsQYUEWkgltCZtieFiMPWUeNYUA(ptr, P_0.Length, P_1, P_2);
		}
	}

	public unsafe int IoTsQYUEWkgltCZtieFiMPWUeNYUA(IntPtr P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_3 <= 0)
		{
			return 0;
		}
		return IoTsQYUEWkgltCZtieFiMPWUeNYUA((byte*)(void*)P_0, P_1, P_2, P_3);
	}

	public bool RWcjmtEWOihCnICrbgbyOHewqpcW(int P_0, uint P_1)
	{
		if (P_0 < 0 || P_0 >= vBkdwNvPEIeLLOlzCYbRhhkNTPUC)
		{
			return false;
		}
		if (P_0 < EWMAsCiobySnwGUQFHWkshYllcHAb)
		{
			if (P_1 == iYiMsgQfrMOmPWWHkCIQfCMHiqOQ)
			{
				return true;
			}
		}
		else if (P_0 >= EWMAsCiobySnwGUQFHWkshYllcHAb)
		{
			if (iYiMsgQfrMOmPWWHkCIQfCMHiqOQ == 0)
			{
				return false;
			}
			if (iYiMsgQfrMOmPWWHkCIQfCMHiqOQ - 1 == P_1)
			{
				return true;
			}
		}
		return false;
	}

	public void auNfBUgrkDddzhmMtDVjQBOyzhlCA()
	{
		EWMAsCiobySnwGUQFHWkshYllcHAb = 0L;
		DbYpEhNgFpebuUuNvOLnOalIGNgo = 0L;
		HtrCVUWhDUrSGCCXAFLQdbxcAYpA = 0;
		pauHmcFGCCzHHFumzHFSdTiVbRzSA = false;
		iYiMsgQfrMOmPWWHkCIQfCMHiqOQ = 0u;
	}

	private void pimhdWfOnyfpsRLMxOvtettwEKXX(int P_0)
	{
		if (P_0 <= 0)
		{
			return;
		}
		int num = (int)EWMAsCiobySnwGUQFHWkshYllcHAb;
		EWMAsCiobySnwGUQFHWkshYllcHAb += P_0;
		bool flag = false;
		if (num < DbYpEhNgFpebuUuNvOLnOalIGNgo)
		{
			if (EWMAsCiobySnwGUQFHWkshYllcHAb > DbYpEhNgFpebuUuNvOLnOalIGNgo)
			{
				flag = true;
			}
		}
		else if (num > DbYpEhNgFpebuUuNvOLnOalIGNgo)
		{
			if (EWMAsCiobySnwGUQFHWkshYllcHAb - vBkdwNvPEIeLLOlzCYbRhhkNTPUC > DbYpEhNgFpebuUuNvOLnOalIGNgo)
			{
				flag = true;
			}
		}
		else if (HtrCVUWhDUrSGCCXAFLQdbxcAYpA > 0)
		{
			flag = true;
		}
		if (flag)
		{
			pauHmcFGCCzHHFumzHFSdTiVbRzSA = true;
			DbYpEhNgFpebuUuNvOLnOalIGNgo = EWMAsCiobySnwGUQFHWkshYllcHAb;
			if (DbYpEhNgFpebuUuNvOLnOalIGNgo >= vBkdwNvPEIeLLOlzCYbRhhkNTPUC)
			{
				DbYpEhNgFpebuUuNvOLnOalIGNgo -= vBkdwNvPEIeLLOlzCYbRhhkNTPUC;
			}
		}
		if (EWMAsCiobySnwGUQFHWkshYllcHAb >= vBkdwNvPEIeLLOlzCYbRhhkNTPUC)
		{
			EWMAsCiobySnwGUQFHWkshYllcHAb -= vBkdwNvPEIeLLOlzCYbRhhkNTPUC;
			TQsZmbEbhFTDGWgpyvRIAUfuouHs();
		}
		HtrCVUWhDUrSGCCXAFLQdbxcAYpA = (int)MathTools.Clamp((long)HtrCVUWhDUrSGCCXAFLQdbxcAYpA + (long)P_0, 0L, vBkdwNvPEIeLLOlzCYbRhhkNTPUC);
	}

	private void ZZwgnzEBAUErCSHxbQIFrISzDQIcA(int P_0)
	{
		if (P_0 > 0)
		{
			if (pauHmcFGCCzHHFumzHFSdTiVbRzSA)
			{
				pauHmcFGCCzHHFumzHFSdTiVbRzSA = false;
			}
			DbYpEhNgFpebuUuNvOLnOalIGNgo += P_0;
			if (DbYpEhNgFpebuUuNvOLnOalIGNgo >= vBkdwNvPEIeLLOlzCYbRhhkNTPUC)
			{
				DbYpEhNgFpebuUuNvOLnOalIGNgo -= vBkdwNvPEIeLLOlzCYbRhhkNTPUC;
			}
			long num = (long)HtrCVUWhDUrSGCCXAFLQdbxcAYpA - (long)P_0;
			HtrCVUWhDUrSGCCXAFLQdbxcAYpA = (int)((num >= 0) ? num : 0);
		}
	}

	private void TQsZmbEbhFTDGWgpyvRIAUfuouHs()
	{
		if (iYiMsgQfrMOmPWWHkCIQfCMHiqOQ == uint.MaxValue)
		{
			iYiMsgQfrMOmPWWHkCIQfCMHiqOQ = 0u;
		}
		else
		{
			iYiMsgQfrMOmPWWHkCIQfCMHiqOQ++;
		}
	}

	public void Dispose()
	{
		hIlanWXkrCYfgvCyascUuCUOCBcL(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
	{
		try
		{
			hIlanWXkrCYfgvCyascUuCUOCBcL(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
	{
		if (!TExNvhkEWsBWipIUjadCDaTpNNDG)
		{
			if (P_0 && pshxLsVBaxPobdRQOPmmlqHPIgYt != null)
			{
				pshxLsVBaxPobdRQOPmmlqHPIgYt.Dispose();
			}
			TExNvhkEWsBWipIUjadCDaTpNNDG = true;
		}
	}
}
