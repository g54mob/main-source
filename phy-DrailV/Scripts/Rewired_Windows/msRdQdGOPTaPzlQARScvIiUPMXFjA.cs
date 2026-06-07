using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class msRdQdGOPTaPzlQARScvIiUPMXFjA : IDisposable
{
	private class omFlkdPCJVimOAHkHcQBZDVjtEuy
	{
		public int LMvFEAtZBwQRlFfEWyZfAAUImHJg;

		public int OsTWxRwhRxJpeyxmILLwKEftpqsu;

		public uint LzTLJfKbzPagfFBxvrXCsiyDVbRZ;

		public object dZcKgsskYfScFSDwfzVlnKpRFISY;

		public void TBPPzgWuguKbGbwgzGoaAckRXMzv(int P_0, int P_1, uint P_2, object P_3)
		{
			LMvFEAtZBwQRlFfEWyZfAAUImHJg = P_0;
			OsTWxRwhRxJpeyxmILLwKEftpqsu = P_1;
			LzTLJfKbzPagfFBxvrXCsiyDVbRZ = P_2;
			dZcKgsskYfScFSDwfzVlnKpRFISY = P_3;
		}

		public void DwNKXiEShimVDUzntAObjUXyaFmo()
		{
			dZcKgsskYfScFSDwfzVlnKpRFISY = null;
		}
	}

	[Serializable]
	private sealed class BtFGfukniqhUOQscOtDyWrzZLERS
	{
		public static readonly BtFGfukniqhUOQscOtDyWrzZLERS _003C_003E9 = new BtFGfukniqhUOQscOtDyWrzZLERS();

		public static Func<omFlkdPCJVimOAHkHcQBZDVjtEuy> _003C_003E9__6_0;

		public static Action<omFlkdPCJVimOAHkHcQBZDVjtEuy> _003C_003E9__6_1;

		internal omFlkdPCJVimOAHkHcQBZDVjtEuy vnTTaxvfallYIxZsIuTDQJyUYEfk()
		{
			return new omFlkdPCJVimOAHkHcQBZDVjtEuy();
		}

		internal void GMWqtEgpnsJOdNMVMIynKDVdTcVu(omFlkdPCJVimOAHkHcQBZDVjtEuy P_0)
		{
			P_0.DwNKXiEShimVDUzntAObjUXyaFmo();
		}
	}

	private EPrXCjyNCCNqaaSWeFZDBxPzIadgA njPEqelkqUAXHcVOBySkfuuGgySaA;

	private ObjectPool<omFlkdPCJVimOAHkHcQBZDVjtEuy> GgqiGmtQsufRCndhxvJDVWptWoOL;

	private Queue<omFlkdPCJVimOAHkHcQBZDVjtEuy> rqYbqrxBAQmuDbeyRFPqHcdzqCNJ;

	private Action<object> aDLWhaECMrNyXlxJHHocZGTfOnGd;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	public bool OjMYnChscKhCFBpYnooAXHryNmpF => CviWQQDAeRalabGfFBJCnWpxwTtHA();

	public msRdQdGOPTaPzlQARScvIiUPMXFjA(int P_0, int P_1, Action<object> P_2 = null)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		njPEqelkqUAXHcVOBySkfuuGgySaA = new EPrXCjyNCCNqaaSWeFZDBxPzIadgA(P_0);
		GgqiGmtQsufRCndhxvJDVWptWoOL = new ObjectPool<omFlkdPCJVimOAHkHcQBZDVjtEuy>(P_1, BtFGfukniqhUOQscOtDyWrzZLERS._003C_003E9.vnTTaxvfallYIxZsIuTDQJyUYEfk, BtFGfukniqhUOQscOtDyWrzZLERS._003C_003E9.GMWqtEgpnsJOdNMVMIynKDVdTcVu);
		rqYbqrxBAQmuDbeyRFPqHcdzqCNJ = new Queue<omFlkdPCJVimOAHkHcQBZDVjtEuy>(P_1);
		aDLWhaECMrNyXlxJHHocZGTfOnGd = P_2;
	}

	public unsafe bool miPFrJiYaYbOloaoCfGOcsRcMhAoc(byte* P_0, int P_1, object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return false;
		}
		if (njPEqelkqUAXHcVOBySkfuuGgySaA.EvDntuhsTubUqbxfRrKDVdXsLcYv(P_0, P_1, P_1, out var num, out var num2) < P_1)
		{
			return false;
		}
		omFlkdPCJVimOAHkHcQBZDVjtEuy omFlkdPCJVimOAHkHcQBZDVjtEuy2 = GgqiGmtQsufRCndhxvJDVWptWoOL.Get();
		omFlkdPCJVimOAHkHcQBZDVjtEuy2.TBPPzgWuguKbGbwgzGoaAckRXMzv(num, P_1, num2, P_2);
		rqYbqrxBAQmuDbeyRFPqHcdzqCNJ.Enqueue(omFlkdPCJVimOAHkHcQBZDVjtEuy2);
		return true;
	}

	public unsafe bool miPFrJiYaYbOloaoCfGOcsRcMhAoc(byte* P_0, int P_1)
	{
		return miPFrJiYaYbOloaoCfGOcsRcMhAoc(P_0, P_1, null);
	}

	public unsafe bool miPFrJiYaYbOloaoCfGOcsRcMhAoc(IntPtr P_0, int P_1, object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			return false;
		}
		return miPFrJiYaYbOloaoCfGOcsRcMhAoc((byte*)(void*)P_0, P_1, P_2);
	}

	public bool miPFrJiYaYbOloaoCfGOcsRcMhAoc(IntPtr P_0, int P_1)
	{
		return miPFrJiYaYbOloaoCfGOcsRcMhAoc(P_0, P_1, null);
	}

	public unsafe bool miPFrJiYaYbOloaoCfGOcsRcMhAoc(byte[] P_0, int P_1, object P_2, int P_3 = 0)
	{
		if (P_0 == null || P_1 > P_0.Length)
		{
			return false;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_3 + P_1 > P_0.Length)
		{
			return false;
		}
		fixed (byte* ptr = P_0)
		{
			byte* ptr2 = ptr + P_3;
			return miPFrJiYaYbOloaoCfGOcsRcMhAoc(ptr2, P_1, P_2);
		}
	}

	public bool miPFrJiYaYbOloaoCfGOcsRcMhAoc(byte[] P_0, int P_1, int P_2 = 0)
	{
		return miPFrJiYaYbOloaoCfGOcsRcMhAoc(P_0, P_1, null, P_2);
	}

	public unsafe int RLhrdPYHxYFeAaaKFjyHeCmFYHcjA(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		omFlkdPCJVimOAHkHcQBZDVjtEuy omFlkdPCJVimOAHkHcQBZDVjtEuy2 = bgffMRKDyJMNkIiZKQbOiPXffTui(false);
		if (omFlkdPCJVimOAHkHcQBZDVjtEuy2 == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < omFlkdPCJVimOAHkHcQBZDVjtEuy2.OsTWxRwhRxJpeyxmILLwKEftpqsu)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Peek to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			return -1;
		}
		int num = njPEqelkqUAXHcVOBySkfuuGgySaA.GufhlYiDQRuINbznbrreTKxVHLUu(P_0, P_1, omFlkdPCJVimOAHkHcQBZDVjtEuy2.OsTWxRwhRxJpeyxmILLwKEftpqsu, omFlkdPCJVimOAHkHcQBZDVjtEuy2.LMvFEAtZBwQRlFfEWyZfAAUImHJg);
		if (num != omFlkdPCJVimOAHkHcQBZDVjtEuy2.OsTWxRwhRxJpeyxmILLwKEftpqsu)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			num = 0;
			P_2 = null;
			return -1;
		}
		P_2 = omFlkdPCJVimOAHkHcQBZDVjtEuy2.dZcKgsskYfScFSDwfzVlnKpRFISY;
		return num;
	}

	public unsafe int RLhrdPYHxYFeAaaKFjyHeCmFYHcjA(byte* P_0, int P_1)
	{
		object obj;
		return RLhrdPYHxYFeAaaKFjyHeCmFYHcjA(P_0, P_1, out obj);
	}

	public unsafe int RLhrdPYHxYFeAaaKFjyHeCmFYHcjA(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return RLhrdPYHxYFeAaaKFjyHeCmFYHcjA((byte*)(void*)P_0, P_1, out P_2);
	}

	public int RLhrdPYHxYFeAaaKFjyHeCmFYHcjA(IntPtr P_0, int P_1)
	{
		object obj;
		return RLhrdPYHxYFeAaaKFjyHeCmFYHcjA(P_0, P_1, out obj);
	}

	public unsafe int RLhrdPYHxYFeAaaKFjyHeCmFYHcjA(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return RLhrdPYHxYFeAaaKFjyHeCmFYHcjA(ptr, P_0.Length, out P_1);
		}
	}

	public int RLhrdPYHxYFeAaaKFjyHeCmFYHcjA(byte[] P_0)
	{
		object obj;
		return RLhrdPYHxYFeAaaKFjyHeCmFYHcjA(P_0, out obj);
	}

	public int yppxHBPNvnatvIaxTuwNrrPXrCDJA()
	{
		return bgffMRKDyJMNkIiZKQbOiPXffTui(false)?.OsTWxRwhRxJpeyxmILLwKEftpqsu ?? (-1);
	}

	public unsafe int bUMwdOCKNHDjeiCjytGPqHiSExxo(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		omFlkdPCJVimOAHkHcQBZDVjtEuy omFlkdPCJVimOAHkHcQBZDVjtEuy2 = bgffMRKDyJMNkIiZKQbOiPXffTui(true);
		if (omFlkdPCJVimOAHkHcQBZDVjtEuy2 == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < omFlkdPCJVimOAHkHcQBZDVjtEuy2.OsTWxRwhRxJpeyxmILLwKEftpqsu)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Dequeue to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			OuDRLULWqTlOYIPypKRKAHlvkovR(omFlkdPCJVimOAHkHcQBZDVjtEuy2, true);
			return -1;
		}
		int num = njPEqelkqUAXHcVOBySkfuuGgySaA.GufhlYiDQRuINbznbrreTKxVHLUu(P_0, P_1, omFlkdPCJVimOAHkHcQBZDVjtEuy2.OsTWxRwhRxJpeyxmILLwKEftpqsu, omFlkdPCJVimOAHkHcQBZDVjtEuy2.LMvFEAtZBwQRlFfEWyZfAAUImHJg);
		if (num != omFlkdPCJVimOAHkHcQBZDVjtEuy2.OsTWxRwhRxJpeyxmILLwKEftpqsu)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			P_2 = null;
			OuDRLULWqTlOYIPypKRKAHlvkovR(omFlkdPCJVimOAHkHcQBZDVjtEuy2, true);
			return -1;
		}
		P_2 = omFlkdPCJVimOAHkHcQBZDVjtEuy2.dZcKgsskYfScFSDwfzVlnKpRFISY;
		OuDRLULWqTlOYIPypKRKAHlvkovR(omFlkdPCJVimOAHkHcQBZDVjtEuy2, false);
		return num;
	}

	public unsafe int bUMwdOCKNHDjeiCjytGPqHiSExxo(byte* P_0, int P_1)
	{
		object obj;
		return bUMwdOCKNHDjeiCjytGPqHiSExxo(P_0, P_1, out obj);
	}

	public unsafe int bUMwdOCKNHDjeiCjytGPqHiSExxo(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return bUMwdOCKNHDjeiCjytGPqHiSExxo((byte*)(void*)P_0, P_1, out P_2);
	}

	public int bUMwdOCKNHDjeiCjytGPqHiSExxo(IntPtr P_0, int P_1)
	{
		object obj;
		return bUMwdOCKNHDjeiCjytGPqHiSExxo(P_0, P_1, out obj);
	}

	public unsafe int bUMwdOCKNHDjeiCjytGPqHiSExxo(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return bUMwdOCKNHDjeiCjytGPqHiSExxo(ptr, P_0.Length, out P_1);
		}
	}

	public int bUMwdOCKNHDjeiCjytGPqHiSExxo(byte[] P_0)
	{
		object obj;
		return bUMwdOCKNHDjeiCjytGPqHiSExxo(P_0, out obj);
	}

	public void sbvNiOKcscCGRBGGcMbdhHrjtptuB()
	{
		njPEqelkqUAXHcVOBySkfuuGgySaA.sbvNiOKcscCGRBGGcMbdhHrjtptuB();
		while (rqYbqrxBAQmuDbeyRFPqHcdzqCNJ.Count > 0)
		{
			OuDRLULWqTlOYIPypKRKAHlvkovR(rqYbqrxBAQmuDbeyRFPqHcdzqCNJ.Dequeue(), true);
		}
	}

	private omFlkdPCJVimOAHkHcQBZDVjtEuy bgffMRKDyJMNkIiZKQbOiPXffTui(bool P_0)
	{
		while (rqYbqrxBAQmuDbeyRFPqHcdzqCNJ.Count > 0)
		{
			omFlkdPCJVimOAHkHcQBZDVjtEuy omFlkdPCJVimOAHkHcQBZDVjtEuy2 = (P_0 ? rqYbqrxBAQmuDbeyRFPqHcdzqCNJ.Dequeue() : rqYbqrxBAQmuDbeyRFPqHcdzqCNJ.Peek());
			if (njPEqelkqUAXHcVOBySkfuuGgySaA.LOAKUriHGZEbByAroDTyQAHhOjqU(omFlkdPCJVimOAHkHcQBZDVjtEuy2.LMvFEAtZBwQRlFfEWyZfAAUImHJg, omFlkdPCJVimOAHkHcQBZDVjtEuy2.LzTLJfKbzPagfFBxvrXCsiyDVbRZ))
			{
				return omFlkdPCJVimOAHkHcQBZDVjtEuy2;
			}
			if (!P_0)
			{
				omFlkdPCJVimOAHkHcQBZDVjtEuy2 = rqYbqrxBAQmuDbeyRFPqHcdzqCNJ.Dequeue();
			}
			OuDRLULWqTlOYIPypKRKAHlvkovR(omFlkdPCJVimOAHkHcQBZDVjtEuy2, true);
		}
		return null;
	}

	private bool CviWQQDAeRalabGfFBJCnWpxwTtHA()
	{
		return bgffMRKDyJMNkIiZKQbOiPXffTui(false) != null;
	}

	private void OuDRLULWqTlOYIPypKRKAHlvkovR(omFlkdPCJVimOAHkHcQBZDVjtEuy P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1 && aDLWhaECMrNyXlxJHHocZGTfOnGd != null && P_0.dZcKgsskYfScFSDwfzVlnKpRFISY != null)
			{
				aDLWhaECMrNyXlxJHHocZGTfOnGd(P_0.dZcKgsskYfScFSDwfzVlnKpRFISY);
			}
			GgqiGmtQsufRCndhxvJDVWptWoOL.Return(P_0);
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
		if (JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			return;
		}
		if (P_0)
		{
			sbvNiOKcscCGRBGGcMbdhHrjtptuB();
			if (njPEqelkqUAXHcVOBySkfuuGgySaA != null)
			{
				njPEqelkqUAXHcVOBySkfuuGgySaA.Dispose();
			}
		}
		JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
	}

	public static bool AXEbSXjFxHcJblRgaeoxjHgqfZFC(msRdQdGOPTaPzlQARScvIiUPMXFjA P_0, msRdQdGOPTaPzlQARScvIiUPMXFjA P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		MiscTools.Swap(ref P_0.njPEqelkqUAXHcVOBySkfuuGgySaA, ref P_1.njPEqelkqUAXHcVOBySkfuuGgySaA);
		MiscTools.Swap(ref P_0.GgqiGmtQsufRCndhxvJDVWptWoOL, ref P_1.GgqiGmtQsufRCndhxvJDVWptWoOL);
		MiscTools.Swap(ref P_0.rqYbqrxBAQmuDbeyRFPqHcdzqCNJ, ref P_1.rqYbqrxBAQmuDbeyRFPqHcdzqCNJ);
		return true;
	}
}
