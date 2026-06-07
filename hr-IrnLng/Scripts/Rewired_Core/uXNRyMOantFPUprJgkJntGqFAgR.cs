using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class uXNRyMOantFPUprJgkJntGqFAgR
{
	private class ZtzGbmaXvyGolcIgABdpWAEsPnI
	{
		public readonly InputAction xsesbFLayFBwyaGRKdXrvgYNpVUw;

		public readonly int RUucinekeLVhzGKuGszOeYlJzub;

		public readonly int nDpdslgPKKDFcWQADzizSrHaBdq;

		public ZtzGbmaXvyGolcIgABdpWAEsPnI(InputAction action, int arrayIndex)
		{
			xsesbFLayFBwyaGRKdXrvgYNpVUw = action;
			RUucinekeLVhzGKuGszOeYlJzub = action.id;
			nDpdslgPKKDFcWQADzizSrHaBdq = arrayIndex;
		}
	}

	private InputAction[] fYdsLGWtQRWYGhHTrruLkORNrXZ;

	private ADictionary<string, ZtzGbmaXvyGolcIgABdpWAEsPnI> KZDBRYBtCesHMaRiXDLdtdFHHhmi;

	private ZtzGbmaXvyGolcIgABdpWAEsPnI[] COQfJQjMrSuHUrhNLESAVpFUjdb;

	private ReadOnlyCollection<InputAction> QfjYxPBHiTldyNjDLhAAIwQvxhH;

	private int aWHkSQSJQTlgGNVPOfZAXseWDcb;

	private int YrDBRIuiaBTFzKBwVMesGqGJUzE;

	private List<string> ydacsYGXerSYzmrlNsFxbvaKppG;

	private List<int> lSZzGALiaiXnLNjMmFIpnYVBxpM;

	public IList<InputAction> Actions => QfjYxPBHiTldyNjDLhAAIwQvxhH;

	public int actionCount => aWHkSQSJQTlgGNVPOfZAXseWDcb;

	public int maxActionId => YrDBRIuiaBTFzKBwVMesGqGJUzE;

	public uXNRyMOantFPUprJgkJntGqFAgR(List<InputAction> actions)
	{
		ydacsYGXerSYzmrlNsFxbvaKppG = new List<string>();
		lSZzGALiaiXnLNjMmFIpnYVBxpM = new List<int>();
		fYdsLGWtQRWYGhHTrruLkORNrXZ = actions.ToArray();
		aWHkSQSJQTlgGNVPOfZAXseWDcb = fYdsLGWtQRWYGhHTrruLkORNrXZ.Length;
		int num = -1;
		for (int i = 0; i < aWHkSQSJQTlgGNVPOfZAXseWDcb; i++)
		{
			int id = fYdsLGWtQRWYGhHTrruLkORNrXZ[i].id;
			if (id > num)
			{
				num = id;
			}
		}
		YrDBRIuiaBTFzKBwVMesGqGJUzE = num;
		COQfJQjMrSuHUrhNLESAVpFUjdb = new ZtzGbmaXvyGolcIgABdpWAEsPnI[num + 1];
		for (int j = 0; j < aWHkSQSJQTlgGNVPOfZAXseWDcb; j++)
		{
			InputAction inputAction = fYdsLGWtQRWYGhHTrruLkORNrXZ[j];
			COQfJQjMrSuHUrhNLESAVpFUjdb[inputAction.id] = new ZtzGbmaXvyGolcIgABdpWAEsPnI(inputAction, j);
		}
		KZDBRYBtCesHMaRiXDLdtdFHHhmi = new ADictionary<string, ZtzGbmaXvyGolcIgABdpWAEsPnI>(aWHkSQSJQTlgGNVPOfZAXseWDcb, StringComparer.OrdinalIgnoreCase);
		for (int k = 0; k < aWHkSQSJQTlgGNVPOfZAXseWDcb; k++)
		{
			InputAction inputAction2 = fYdsLGWtQRWYGhHTrruLkORNrXZ[k];
			try
			{
				KZDBRYBtCesHMaRiXDLdtdFHHhmi.Add(inputAction2.name, COQfJQjMrSuHUrhNLESAVpFUjdb[inputAction2.id]);
			}
			catch
			{
				Logger.LogError("Duplicate Action name \"" + inputAction2.name + "\" found in Action list. Duplicate Action names are not allowed. If you have edited the data manually outside the Rewired Input Manager, remove any duplicate Actions.");
			}
		}
		QfjYxPBHiTldyNjDLhAAIwQvxhH = new ReadOnlyCollection<InputAction>(fYdsLGWtQRWYGhHTrruLkORNrXZ);
	}

	public InputAction foeDsFJMSKPZnHiDHArgvpAmVTU(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return null;
		}
		if (!KZDBRYBtCesHMaRiXDLdtdFHHhmi.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				nFeymvIVBeJaXGjiyBFpDpnohMGh(P_0);
			}
			return null;
		}
		return value.xsesbFLayFBwyaGRKdXrvgYNpVUw;
	}

	public InputAction NXSdxZEXhqvBULQyUjzTUlotAOY(int P_0)
	{
		if (P_0 < 0)
		{
			return null;
		}
		if (P_0 > YrDBRIuiaBTFzKBwVMesGqGJUzE)
		{
			return null;
		}
		if (COQfJQjMrSuHUrhNLESAVpFUjdb[P_0] == null)
		{
			return null;
		}
		return COQfJQjMrSuHUrhNLESAVpFUjdb[P_0].xsesbFLayFBwyaGRKdXrvgYNpVUw;
	}

	public InputAction tlCsXbFIrbtDiBdpidNJQdEUhja(int P_0)
	{
		if (P_0 < 0 || P_0 >= aWHkSQSJQTlgGNVPOfZAXseWDcb)
		{
			return null;
		}
		return fYdsLGWtQRWYGhHTrruLkORNrXZ[P_0];
	}

	public int iFNXApJjlWtDZdwedJFKpfGAMok(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!KZDBRYBtCesHMaRiXDLdtdFHHhmi.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				nFeymvIVBeJaXGjiyBFpDpnohMGh(P_0);
			}
			return -1;
		}
		return value.nDpdslgPKKDFcWQADzizSrHaBdq;
	}

	public int iFNXApJjlWtDZdwedJFKpfGAMok(int P_0, bool P_1 = false)
	{
		if (P_0 < 0 || P_0 > YrDBRIuiaBTFzKBwVMesGqGJUzE)
		{
			if (P_0 >= 0 && P_1)
			{
				nFeymvIVBeJaXGjiyBFpDpnohMGh(P_0);
			}
			return -1;
		}
		ZtzGbmaXvyGolcIgABdpWAEsPnI ztzGbmaXvyGolcIgABdpWAEsPnI = COQfJQjMrSuHUrhNLESAVpFUjdb[P_0];
		if (ztzGbmaXvyGolcIgABdpWAEsPnI == null)
		{
			if (P_1)
			{
				nFeymvIVBeJaXGjiyBFpDpnohMGh(P_0);
			}
			return -1;
		}
		return ztzGbmaXvyGolcIgABdpWAEsPnI.nDpdslgPKKDFcWQADzizSrHaBdq;
	}

	public bool qUMsmxJoDabnMgpnPbuRnplJapZC(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!KZDBRYBtCesHMaRiXDLdtdFHHhmi.ContainsKey(P_0))
		{
			if (P_1)
			{
				nFeymvIVBeJaXGjiyBFpDpnohMGh(P_0);
			}
			return false;
		}
		return true;
	}

	public bool qUMsmxJoDabnMgpnPbuRnplJapZC(int P_0)
	{
		if (P_0 < 0 || P_0 > YrDBRIuiaBTFzKBwVMesGqGJUzE)
		{
			return false;
		}
		return COQfJQjMrSuHUrhNLESAVpFUjdb[P_0] != null;
	}

	public int eaEBFTCPQPNmMfDIsPQAWgiCaLm(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!KZDBRYBtCesHMaRiXDLdtdFHHhmi.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				nFeymvIVBeJaXGjiyBFpDpnohMGh(P_0);
			}
			return -1;
		}
		return value.RUucinekeLVhzGKuGszOeYlJzub;
	}

	private void nFeymvIVBeJaXGjiyBFpDpnohMGh(string P_0)
	{
		if (!ydacsYGXerSYzmrlNsFxbvaKppG.Contains(P_0))
		{
			ydacsYGXerSYzmrlNsFxbvaKppG.Add(P_0);
			Logger.LogWarning("The Action \"" + P_0 + "\" does not exist. You can create Actions in the editor.");
		}
	}

	private void nFeymvIVBeJaXGjiyBFpDpnohMGh(int P_0)
	{
		if (!lSZzGALiaiXnLNjMmFIpnYVBxpM.Contains(P_0))
		{
			lSZzGALiaiXnLNjMmFIpnYVBxpM.Add(P_0);
			Logger.LogWarning("No Action exists for Action Id " + P_0 + ". You can create Actions in the editor.");
		}
	}
}
