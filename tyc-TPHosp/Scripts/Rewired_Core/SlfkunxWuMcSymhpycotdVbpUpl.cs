using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class SlfkunxWuMcSymhpycotdVbpUpl
{
	private class YZRbqcYaXSjldasIxGSNGmiQpKK
	{
		public readonly InputAction PzSFSpIsTMHLgXLtVnHyuulbaFyD;

		public readonly int bKgRNMZoNfkYtHsWtkGguFjJhGW;

		public readonly int VWLPdNJAnVsbaTxwWavyIyQGfYO;

		public YZRbqcYaXSjldasIxGSNGmiQpKK(InputAction action, int arrayIndex)
		{
			PzSFSpIsTMHLgXLtVnHyuulbaFyD = action;
			bKgRNMZoNfkYtHsWtkGguFjJhGW = action.id;
			VWLPdNJAnVsbaTxwWavyIyQGfYO = arrayIndex;
		}
	}

	private InputAction[] FVZFcijbhSedGqixiOmSCuonTtxZ;

	private ADictionary<string, YZRbqcYaXSjldasIxGSNGmiQpKK> qjjaNeuHhzsVMpYSGNcitamrlgQ;

	private YZRbqcYaXSjldasIxGSNGmiQpKK[] wKquoiEsOFJyAeHtAKURPNmgQrR;

	private ReadOnlyCollection<InputAction> gYXiSxcZLOmUgSxpUrKZWXpLNvx;

	private int IThzxcjZdOmZEQztVHFTXbHsusV;

	private int mvjaowPfVSqqnHoKKmaxIIddvoe;

	private List<string> STWFgozauaanrtBRYEiuCxAkebwn;

	private List<int> FjrCEukSXrnmPUGsnrZkrIqlkdk;

	public IList<InputAction> Actions => gYXiSxcZLOmUgSxpUrKZWXpLNvx;

	public int actionCount => IThzxcjZdOmZEQztVHFTXbHsusV;

	public int maxActionId => mvjaowPfVSqqnHoKKmaxIIddvoe;

	public SlfkunxWuMcSymhpycotdVbpUpl(List<InputAction> actions)
	{
		STWFgozauaanrtBRYEiuCxAkebwn = new List<string>();
		FjrCEukSXrnmPUGsnrZkrIqlkdk = new List<int>();
		FVZFcijbhSedGqixiOmSCuonTtxZ = actions.ToArray();
		IThzxcjZdOmZEQztVHFTXbHsusV = FVZFcijbhSedGqixiOmSCuonTtxZ.Length;
		int num = -1;
		for (int i = 0; i < IThzxcjZdOmZEQztVHFTXbHsusV; i++)
		{
			int id = FVZFcijbhSedGqixiOmSCuonTtxZ[i].id;
			if (id > num)
			{
				num = id;
			}
		}
		mvjaowPfVSqqnHoKKmaxIIddvoe = num;
		wKquoiEsOFJyAeHtAKURPNmgQrR = new YZRbqcYaXSjldasIxGSNGmiQpKK[num + 1];
		for (int j = 0; j < IThzxcjZdOmZEQztVHFTXbHsusV; j++)
		{
			InputAction inputAction = FVZFcijbhSedGqixiOmSCuonTtxZ[j];
			wKquoiEsOFJyAeHtAKURPNmgQrR[inputAction.id] = new YZRbqcYaXSjldasIxGSNGmiQpKK(inputAction, j);
		}
		qjjaNeuHhzsVMpYSGNcitamrlgQ = new ADictionary<string, YZRbqcYaXSjldasIxGSNGmiQpKK>(IThzxcjZdOmZEQztVHFTXbHsusV, StringComparer.OrdinalIgnoreCase);
		for (int k = 0; k < IThzxcjZdOmZEQztVHFTXbHsusV; k++)
		{
			InputAction inputAction2 = FVZFcijbhSedGqixiOmSCuonTtxZ[k];
			try
			{
				qjjaNeuHhzsVMpYSGNcitamrlgQ.Add(inputAction2.name, wKquoiEsOFJyAeHtAKURPNmgQrR[inputAction2.id]);
			}
			catch
			{
				Logger.LogError("Duplicate Action name \"" + inputAction2.name + "\" found in Action list. Duplicate Action names are not allowed. If you have edited the data manually outside the Rewired Input Manager, remove any duplicate Actions.");
			}
		}
		gYXiSxcZLOmUgSxpUrKZWXpLNvx = new ReadOnlyCollection<InputAction>(FVZFcijbhSedGqixiOmSCuonTtxZ);
	}

	public InputAction DKnkpbidVxizCMbIYGpxrzjWVmZ(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return null;
		}
		if (!qjjaNeuHhzsVMpYSGNcitamrlgQ.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				BZYgFHdRgbKTZZbItXTcxDGMZIu(P_0);
			}
			return null;
		}
		return value.PzSFSpIsTMHLgXLtVnHyuulbaFyD;
	}

	public InputAction bReSPxtAAhuMWEVILtQCAxJTMfu(int P_0)
	{
		if (P_0 < 0)
		{
			return null;
		}
		if (P_0 > mvjaowPfVSqqnHoKKmaxIIddvoe)
		{
			return null;
		}
		if (wKquoiEsOFJyAeHtAKURPNmgQrR[P_0] == null)
		{
			return null;
		}
		return wKquoiEsOFJyAeHtAKURPNmgQrR[P_0].PzSFSpIsTMHLgXLtVnHyuulbaFyD;
	}

	public InputAction VXeLAnoWliGcHOyDxpnQUgYcpQB(int P_0)
	{
		if (P_0 < 0 || P_0 >= IThzxcjZdOmZEQztVHFTXbHsusV)
		{
			return null;
		}
		return FVZFcijbhSedGqixiOmSCuonTtxZ[P_0];
	}

	public int EZvGxHsqIFFuTapSiFVRnGzgbyW(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!qjjaNeuHhzsVMpYSGNcitamrlgQ.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				BZYgFHdRgbKTZZbItXTcxDGMZIu(P_0);
			}
			return -1;
		}
		return value.VWLPdNJAnVsbaTxwWavyIyQGfYO;
	}

	public int EZvGxHsqIFFuTapSiFVRnGzgbyW(int P_0, bool P_1 = false)
	{
		if (P_0 < 0 || P_0 > mvjaowPfVSqqnHoKKmaxIIddvoe)
		{
			if (P_0 >= 0 && P_1)
			{
				BZYgFHdRgbKTZZbItXTcxDGMZIu(P_0);
			}
			return -1;
		}
		YZRbqcYaXSjldasIxGSNGmiQpKK yZRbqcYaXSjldasIxGSNGmiQpKK = wKquoiEsOFJyAeHtAKURPNmgQrR[P_0];
		if (yZRbqcYaXSjldasIxGSNGmiQpKK == null)
		{
			if (P_1)
			{
				BZYgFHdRgbKTZZbItXTcxDGMZIu(P_0);
			}
			return -1;
		}
		return yZRbqcYaXSjldasIxGSNGmiQpKK.VWLPdNJAnVsbaTxwWavyIyQGfYO;
	}

	public bool YRagHVGgqrxCGUgBYtkIqvCxSddL(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!qjjaNeuHhzsVMpYSGNcitamrlgQ.ContainsKey(P_0))
		{
			if (P_1)
			{
				BZYgFHdRgbKTZZbItXTcxDGMZIu(P_0);
			}
			return false;
		}
		return true;
	}

	public bool YRagHVGgqrxCGUgBYtkIqvCxSddL(int P_0)
	{
		if (P_0 < 0 || P_0 > mvjaowPfVSqqnHoKKmaxIIddvoe)
		{
			return false;
		}
		return wKquoiEsOFJyAeHtAKURPNmgQrR[P_0] != null;
	}

	public int QCCcivdnkZkmiacpJDFREoDsGax(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!qjjaNeuHhzsVMpYSGNcitamrlgQ.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				BZYgFHdRgbKTZZbItXTcxDGMZIu(P_0);
			}
			return -1;
		}
		return value.bKgRNMZoNfkYtHsWtkGguFjJhGW;
	}

	private void BZYgFHdRgbKTZZbItXTcxDGMZIu(string P_0)
	{
		if (!STWFgozauaanrtBRYEiuCxAkebwn.Contains(P_0))
		{
			STWFgozauaanrtBRYEiuCxAkebwn.Add(P_0);
			Logger.LogWarning("The Action \"" + P_0 + "\" does not exist. You can create Actions in the editor.");
		}
	}

	private void BZYgFHdRgbKTZZbItXTcxDGMZIu(int P_0)
	{
		if (!FjrCEukSXrnmPUGsnrZkrIqlkdk.Contains(P_0))
		{
			FjrCEukSXrnmPUGsnrZkrIqlkdk.Add(P_0);
			Logger.LogWarning("No Action exists for Action Id " + P_0 + ". You can create Actions in the editor.");
		}
	}
}
