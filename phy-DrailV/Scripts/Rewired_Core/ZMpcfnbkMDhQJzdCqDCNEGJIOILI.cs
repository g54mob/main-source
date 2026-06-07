using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class ZMpcfnbkMDhQJzdCqDCNEGJIOILI
{
	private class RaEFKFekntdFFbqZAhlkjKiFALigc
	{
		public readonly InputAction OaIcAeBefvvQjPAvMJqPXNzMJNWUA;

		public readonly int krsTtHLNxEdniCjaeNCXXDxqAnqr;

		public readonly int WrBJMYFDQirhbAyJVLvHtgjnzjog;

		public RaEFKFekntdFFbqZAhlkjKiFALigc(InputAction P_0, int P_1)
		{
			OaIcAeBefvvQjPAvMJqPXNzMJNWUA = P_0;
			krsTtHLNxEdniCjaeNCXXDxqAnqr = P_0.id;
			WrBJMYFDQirhbAyJVLvHtgjnzjog = P_1;
		}
	}

	private InputAction[] OqPckbdWVndaJdjfjcDhYJiGOjJMA;

	private ADictionary<string, RaEFKFekntdFFbqZAhlkjKiFALigc> pIxaFlwhRCjMHgjEDcnLAhmSdfcP;

	private RaEFKFekntdFFbqZAhlkjKiFALigc[] rlayglCOomdfXbvrFfdgmakNNjdDA;

	private ReadOnlyCollection<InputAction> fsNEAsepdvcRrNojDuxktmpwfhTW;

	private int LoxvfplpBtEGVFEvWseaqtRXiwrT;

	private int bvzyspXvRzbSyYIGBFQEbrjIpyGE;

	private List<string> HVGaHthKIROuugfDDHTZGSONnxMaA;

	private List<int> SIjOHtavrKdHMLSiykyRQnsEdmWg;

	public IList<InputAction> JztSgslzhagKBJhbGNArekIIiZlf => fsNEAsepdvcRrNojDuxktmpwfhTW;

	public int AYaeikGbAWJSxAusdDGtShFwSvkHb => LoxvfplpBtEGVFEvWseaqtRXiwrT;

	public int WsnXzBfcMhAtQgXzLfeanZnPAyXtA => bvzyspXvRzbSyYIGBFQEbrjIpyGE;

	public ZMpcfnbkMDhQJzdCqDCNEGJIOILI(List<InputAction> P_0)
	{
		HVGaHthKIROuugfDDHTZGSONnxMaA = new List<string>();
		SIjOHtavrKdHMLSiykyRQnsEdmWg = new List<int>();
		OqPckbdWVndaJdjfjcDhYJiGOjJMA = P_0.ToArray();
		LoxvfplpBtEGVFEvWseaqtRXiwrT = OqPckbdWVndaJdjfjcDhYJiGOjJMA.Length;
		int num = -1;
		for (int i = 0; i < LoxvfplpBtEGVFEvWseaqtRXiwrT; i++)
		{
			int id = OqPckbdWVndaJdjfjcDhYJiGOjJMA[i].id;
			if (id > num)
			{
				num = id;
			}
		}
		bvzyspXvRzbSyYIGBFQEbrjIpyGE = num;
		rlayglCOomdfXbvrFfdgmakNNjdDA = new RaEFKFekntdFFbqZAhlkjKiFALigc[num + 1];
		for (int j = 0; j < LoxvfplpBtEGVFEvWseaqtRXiwrT; j++)
		{
			InputAction inputAction = OqPckbdWVndaJdjfjcDhYJiGOjJMA[j];
			rlayglCOomdfXbvrFfdgmakNNjdDA[inputAction.id] = new RaEFKFekntdFFbqZAhlkjKiFALigc(inputAction, j);
		}
		pIxaFlwhRCjMHgjEDcnLAhmSdfcP = new ADictionary<string, RaEFKFekntdFFbqZAhlkjKiFALigc>(LoxvfplpBtEGVFEvWseaqtRXiwrT, StringComparer.OrdinalIgnoreCase);
		for (int k = 0; k < LoxvfplpBtEGVFEvWseaqtRXiwrT; k++)
		{
			InputAction inputAction2 = OqPckbdWVndaJdjfjcDhYJiGOjJMA[k];
			try
			{
				pIxaFlwhRCjMHgjEDcnLAhmSdfcP.Add(inputAction2.name, rlayglCOomdfXbvrFfdgmakNNjdDA[inputAction2.id]);
			}
			catch
			{
				Logger.LogError("Duplicate Action name \"" + inputAction2.name + "\" found in Action list. Duplicate Action names are not allowed. If you have edited the data manually outside the Rewired Input Manager, remove any duplicate Actions.");
			}
		}
		fsNEAsepdvcRrNojDuxktmpwfhTW = new ReadOnlyCollection<InputAction>(OqPckbdWVndaJdjfjcDhYJiGOjJMA);
	}

	public InputAction AtKeaiuZuopusRbNFvrKAbfpRMOD(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return null;
		}
		if (!pIxaFlwhRCjMHgjEDcnLAhmSdfcP.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				CuMfXQdZISRKWYLYojeBOxIlFCGo(P_0);
			}
			return null;
		}
		return value.OaIcAeBefvvQjPAvMJqPXNzMJNWUA;
	}

	public InputAction qKuCVofiSWfeXLQSYWsbtNcyAMGe(int P_0)
	{
		if (P_0 < 0)
		{
			return null;
		}
		if (P_0 > bvzyspXvRzbSyYIGBFQEbrjIpyGE)
		{
			return null;
		}
		if (rlayglCOomdfXbvrFfdgmakNNjdDA[P_0] == null)
		{
			return null;
		}
		return rlayglCOomdfXbvrFfdgmakNNjdDA[P_0].OaIcAeBefvvQjPAvMJqPXNzMJNWUA;
	}

	public InputAction StmVcaqiZXHRSPDLwwObvLYPgxbr(int P_0)
	{
		if (P_0 < 0 || P_0 >= LoxvfplpBtEGVFEvWseaqtRXiwrT)
		{
			return null;
		}
		return OqPckbdWVndaJdjfjcDhYJiGOjJMA[P_0];
	}

	public int PujFpIgnaejxCcbCzrcoRIpZaecab(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!pIxaFlwhRCjMHgjEDcnLAhmSdfcP.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				CuMfXQdZISRKWYLYojeBOxIlFCGo(P_0);
			}
			return -1;
		}
		return value.WrBJMYFDQirhbAyJVLvHtgjnzjog;
	}

	public int PujFpIgnaejxCcbCzrcoRIpZaecab(int P_0, bool P_1 = false)
	{
		if (P_0 < 0 || P_0 > bvzyspXvRzbSyYIGBFQEbrjIpyGE)
		{
			if (P_0 >= 0 && P_1)
			{
				CuMfXQdZISRKWYLYojeBOxIlFCGo(P_0);
			}
			return -1;
		}
		RaEFKFekntdFFbqZAhlkjKiFALigc raEFKFekntdFFbqZAhlkjKiFALigc = rlayglCOomdfXbvrFfdgmakNNjdDA[P_0];
		if (raEFKFekntdFFbqZAhlkjKiFALigc == null)
		{
			if (P_1)
			{
				CuMfXQdZISRKWYLYojeBOxIlFCGo(P_0);
			}
			return -1;
		}
		return raEFKFekntdFFbqZAhlkjKiFALigc.WrBJMYFDQirhbAyJVLvHtgjnzjog;
	}

	public bool XrqcBMeuSMEFFHtBARTfiYGSMlVMB(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!pIxaFlwhRCjMHgjEDcnLAhmSdfcP.ContainsKey(P_0))
		{
			if (P_1)
			{
				CuMfXQdZISRKWYLYojeBOxIlFCGo(P_0);
			}
			return false;
		}
		return true;
	}

	public bool XrqcBMeuSMEFFHtBARTfiYGSMlVMB(int P_0)
	{
		if (P_0 < 0 || P_0 > bvzyspXvRzbSyYIGBFQEbrjIpyGE)
		{
			return false;
		}
		return rlayglCOomdfXbvrFfdgmakNNjdDA[P_0] != null;
	}

	public int LdMwxkpmOahQpxrdWsSafRVVeUPg(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!pIxaFlwhRCjMHgjEDcnLAhmSdfcP.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				CuMfXQdZISRKWYLYojeBOxIlFCGo(P_0);
			}
			return -1;
		}
		return value.krsTtHLNxEdniCjaeNCXXDxqAnqr;
	}

	private void CuMfXQdZISRKWYLYojeBOxIlFCGo(string P_0)
	{
		if (!HVGaHthKIROuugfDDHTZGSONnxMaA.Contains(P_0))
		{
			HVGaHthKIROuugfDDHTZGSONnxMaA.Add(P_0);
			Logger.LogWarning("The Action \"" + P_0 + "\" does not exist. You can create Actions in the editor.");
		}
	}

	private void CuMfXQdZISRKWYLYojeBOxIlFCGo(int P_0)
	{
		if (!SIjOHtavrKdHMLSiykyRQnsEdmWg.Contains(P_0))
		{
			SIjOHtavrKdHMLSiykyRQnsEdmWg.Add(P_0);
			Logger.LogWarning("No Action exists for Action Id " + P_0 + ". You can create Actions in the editor.");
		}
	}
}
