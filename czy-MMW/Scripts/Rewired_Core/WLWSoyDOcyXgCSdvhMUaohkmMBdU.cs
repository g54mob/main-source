using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class WLWSoyDOcyXgCSdvhMUaohkmMBdU
{
	private class QTjlMWAgpEoMSFTRFuUJwcJkeIQw
	{
		public readonly InputAction KEacEdisKyBRFjIZGNVZCnAcSAFJb;

		public readonly int PEVVvIWoajlbnOmecFnlmGlxSySI;

		public readonly int GHZsJFBWhJHXebONIvCqInPnZcgI;

		public QTjlMWAgpEoMSFTRFuUJwcJkeIQw(InputAction P_0, int P_1)
		{
			KEacEdisKyBRFjIZGNVZCnAcSAFJb = P_0;
			PEVVvIWoajlbnOmecFnlmGlxSySI = P_0.id;
			GHZsJFBWhJHXebONIvCqInPnZcgI = P_1;
		}
	}

	private InputAction[] uDnGZCwbmKNGPIQaXJPQUKhGrWFG;

	private ADictionary<string, QTjlMWAgpEoMSFTRFuUJwcJkeIQw> VbonRZacdCIbncUWcuiOrcuhMyVp;

	private QTjlMWAgpEoMSFTRFuUJwcJkeIQw[] iMPRcipjXWACABdcOvqlpAWKnFYS;

	private ReadOnlyCollection<InputAction> oktlMfBdWRTGmxiejhZHzXBwjgZx;

	private int iocvpVmYkGgAsrFIbpGKBogAqIhM;

	private int PexRmvVxATqePTHHkPVKZcgBBIZCA;

	private List<string> ufxFJAMLpPhwRLEouylXYyCEWFvG;

	private List<int> LcBQpxmgXAdopIiHJxqZMbLuPPHCA;

	public IList<InputAction> nBhOyBMUUwEcliaRuIBSgZoZtveD => oktlMfBdWRTGmxiejhZHzXBwjgZx;

	public int fWdSJncAgqWKojGWkiexBNsAiSOd => iocvpVmYkGgAsrFIbpGKBogAqIhM;

	public int eHkaHMARfQIlOsYaKzrQtIClDjZDb => PexRmvVxATqePTHHkPVKZcgBBIZCA;

	public WLWSoyDOcyXgCSdvhMUaohkmMBdU(List<InputAction> P_0)
	{
		ufxFJAMLpPhwRLEouylXYyCEWFvG = new List<string>();
		LcBQpxmgXAdopIiHJxqZMbLuPPHCA = new List<int>();
		uDnGZCwbmKNGPIQaXJPQUKhGrWFG = P_0.ToArray();
		iocvpVmYkGgAsrFIbpGKBogAqIhM = uDnGZCwbmKNGPIQaXJPQUKhGrWFG.Length;
		int num = -1;
		for (int i = 0; i < iocvpVmYkGgAsrFIbpGKBogAqIhM; i++)
		{
			int id = uDnGZCwbmKNGPIQaXJPQUKhGrWFG[i].id;
			if (id > num)
			{
				num = id;
			}
		}
		PexRmvVxATqePTHHkPVKZcgBBIZCA = num;
		iMPRcipjXWACABdcOvqlpAWKnFYS = new QTjlMWAgpEoMSFTRFuUJwcJkeIQw[num + 1];
		for (int j = 0; j < iocvpVmYkGgAsrFIbpGKBogAqIhM; j++)
		{
			InputAction inputAction = uDnGZCwbmKNGPIQaXJPQUKhGrWFG[j];
			iMPRcipjXWACABdcOvqlpAWKnFYS[inputAction.id] = new QTjlMWAgpEoMSFTRFuUJwcJkeIQw(inputAction, j);
		}
		VbonRZacdCIbncUWcuiOrcuhMyVp = new ADictionary<string, QTjlMWAgpEoMSFTRFuUJwcJkeIQw>(iocvpVmYkGgAsrFIbpGKBogAqIhM, StringComparer.OrdinalIgnoreCase);
		for (int k = 0; k < iocvpVmYkGgAsrFIbpGKBogAqIhM; k++)
		{
			InputAction inputAction2 = uDnGZCwbmKNGPIQaXJPQUKhGrWFG[k];
			try
			{
				VbonRZacdCIbncUWcuiOrcuhMyVp.Add(inputAction2.name, iMPRcipjXWACABdcOvqlpAWKnFYS[inputAction2.id]);
			}
			catch
			{
				Logger.LogError("Duplicate Action name \"" + inputAction2.name + "\" found in Action list. Duplicate Action names are not allowed. If you have edited the data manually outside the Rewired Input Manager, remove any duplicate Actions.");
			}
		}
		oktlMfBdWRTGmxiejhZHzXBwjgZx = new ReadOnlyCollection<InputAction>(uDnGZCwbmKNGPIQaXJPQUKhGrWFG);
	}

	public InputAction QKCYqwFmItpkITKiPWYYxsvfwMVD(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return null;
		}
		if (!VbonRZacdCIbncUWcuiOrcuhMyVp.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				BzUcSfgszHtyONgKTzbBISawPPSDA(P_0);
			}
			return null;
		}
		return value.KEacEdisKyBRFjIZGNVZCnAcSAFJb;
	}

	public InputAction cyZjgBDAIIsjivyJJljRrGGufDpj(int P_0)
	{
		if (P_0 < 0)
		{
			return null;
		}
		if (P_0 > PexRmvVxATqePTHHkPVKZcgBBIZCA)
		{
			return null;
		}
		if (iMPRcipjXWACABdcOvqlpAWKnFYS[P_0] == null)
		{
			return null;
		}
		return iMPRcipjXWACABdcOvqlpAWKnFYS[P_0].KEacEdisKyBRFjIZGNVZCnAcSAFJb;
	}

	public InputAction ojNcNKHVaHIdBanHhjakowYXRcVZA(int P_0)
	{
		if (P_0 < 0 || P_0 >= iocvpVmYkGgAsrFIbpGKBogAqIhM)
		{
			return null;
		}
		return uDnGZCwbmKNGPIQaXJPQUKhGrWFG[P_0];
	}

	public int KpOIGZtIuRNCEjCCCtdlFGTylpOl(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!VbonRZacdCIbncUWcuiOrcuhMyVp.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				BzUcSfgszHtyONgKTzbBISawPPSDA(P_0);
			}
			return -1;
		}
		return value.GHZsJFBWhJHXebONIvCqInPnZcgI;
	}

	public int HdyzUsIgYoZMEAvhvRqeQdmcylrC(int P_0, bool P_1 = false)
	{
		if (P_0 < 0 || P_0 > PexRmvVxATqePTHHkPVKZcgBBIZCA)
		{
			if (P_0 >= 0 && P_1)
			{
				MNvhVtLteUhwJrxfSPXqHXTTNLlQ(P_0);
			}
			return -1;
		}
		QTjlMWAgpEoMSFTRFuUJwcJkeIQw qTjlMWAgpEoMSFTRFuUJwcJkeIQw = iMPRcipjXWACABdcOvqlpAWKnFYS[P_0];
		if (qTjlMWAgpEoMSFTRFuUJwcJkeIQw == null)
		{
			if (P_1)
			{
				MNvhVtLteUhwJrxfSPXqHXTTNLlQ(P_0);
			}
			return -1;
		}
		return qTjlMWAgpEoMSFTRFuUJwcJkeIQw.GHZsJFBWhJHXebONIvCqInPnZcgI;
	}

	public bool utmEkIeACxBGkdoGiklIEXOZPaUmA(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!VbonRZacdCIbncUWcuiOrcuhMyVp.ContainsKey(P_0))
		{
			if (P_1)
			{
				BzUcSfgszHtyONgKTzbBISawPPSDA(P_0);
			}
			return false;
		}
		return true;
	}

	public bool SByHFKqDWWqrMsNsCdjvEQeskxdFb(int P_0)
	{
		if (P_0 < 0 || P_0 > PexRmvVxATqePTHHkPVKZcgBBIZCA)
		{
			return false;
		}
		return iMPRcipjXWACABdcOvqlpAWKnFYS[P_0] != null;
	}

	public int rnRgZqWgdruGSKkLVaIxIODNYhyJA(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!VbonRZacdCIbncUWcuiOrcuhMyVp.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				BzUcSfgszHtyONgKTzbBISawPPSDA(P_0);
			}
			return -1;
		}
		return value.PEVVvIWoajlbnOmecFnlmGlxSySI;
	}

	private void BzUcSfgszHtyONgKTzbBISawPPSDA(string P_0)
	{
		if (!ufxFJAMLpPhwRLEouylXYyCEWFvG.Contains(P_0))
		{
			ufxFJAMLpPhwRLEouylXYyCEWFvG.Add(P_0);
			Logger.LogWarning("The Action \"" + P_0 + "\" does not exist. You can create Actions in the editor.");
		}
	}

	private void MNvhVtLteUhwJrxfSPXqHXTTNLlQ(int P_0)
	{
		if (!LcBQpxmgXAdopIiHJxqZMbLuPPHCA.Contains(P_0))
		{
			LcBQpxmgXAdopIiHJxqZMbLuPPHCA.Add(P_0);
			Logger.LogWarning("No Action exists for Action Id " + P_0 + ". You can create Actions in the editor.");
		}
	}
}
