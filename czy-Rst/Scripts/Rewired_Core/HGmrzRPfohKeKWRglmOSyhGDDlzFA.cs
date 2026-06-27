using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class HGmrzRPfohKeKWRglmOSyhGDDlzFA
{
	private class RYLWFhUIlBUUYZaWBIulsLpHuxEL
	{
		public readonly InputAction ZMfVKuSKhGVLGUOOsXjjvqdgwTN;

		public readonly int GHtMrbMoHyllnWhYeLFLsHOEkHCd;

		public readonly int BmrfpaDKlKVeyjmIQrNMUPpUhnkk;

		public RYLWFhUIlBUUYZaWBIulsLpHuxEL(InputAction P_0, int P_1)
		{
			ZMfVKuSKhGVLGUOOsXjjvqdgwTN = P_0;
			GHtMrbMoHyllnWhYeLFLsHOEkHCd = P_0.id;
			BmrfpaDKlKVeyjmIQrNMUPpUhnkk = P_1;
		}
	}

	private InputAction[] nYFPFhmeiZTvFQwtRNQoMbHnXEXJ;

	private ADictionary<string, RYLWFhUIlBUUYZaWBIulsLpHuxEL> IxOohiotbZnrlkFigwRcbKZWOeJE;

	private RYLWFhUIlBUUYZaWBIulsLpHuxEL[] dhxGWXbXbNQZQXpgSkWZfuUppGGC;

	private ReadOnlyCollection<InputAction> vFTcCOLGWGRvqvtLhPPnltjFOpVC;

	private int pRQRcuevmXOSwlAFtrKkHiKrXwfN;

	private int WjVsjUNWSAfgTBYSyCRsZZOsJyLP;

	private List<string> fcNGdhAcBUBpFTfBkZenWWUpTglU;

	private List<int> EGnTyIqYHHeHlcoKLiXdpFzFhsZE;

	public IList<InputAction> gyJTduGYIhUqxuNheINoubncViuj => vFTcCOLGWGRvqvtLhPPnltjFOpVC;

	public int odNDRUwAOnhWgjLHmfyNZulfTYIm => pRQRcuevmXOSwlAFtrKkHiKrXwfN;

	public int lbIKIrRqnTGlQhQzEopadSmEADDSA => WjVsjUNWSAfgTBYSyCRsZZOsJyLP;

	public HGmrzRPfohKeKWRglmOSyhGDDlzFA(List<InputAction> P_0)
	{
		fcNGdhAcBUBpFTfBkZenWWUpTglU = new List<string>();
		EGnTyIqYHHeHlcoKLiXdpFzFhsZE = new List<int>();
		nYFPFhmeiZTvFQwtRNQoMbHnXEXJ = P_0.ToArray();
		pRQRcuevmXOSwlAFtrKkHiKrXwfN = nYFPFhmeiZTvFQwtRNQoMbHnXEXJ.Length;
		int num = -1;
		for (int i = 0; i < pRQRcuevmXOSwlAFtrKkHiKrXwfN; i++)
		{
			int id = nYFPFhmeiZTvFQwtRNQoMbHnXEXJ[i].id;
			if (id > num)
			{
				num = id;
			}
		}
		WjVsjUNWSAfgTBYSyCRsZZOsJyLP = num;
		dhxGWXbXbNQZQXpgSkWZfuUppGGC = new RYLWFhUIlBUUYZaWBIulsLpHuxEL[num + 1];
		for (int j = 0; j < pRQRcuevmXOSwlAFtrKkHiKrXwfN; j++)
		{
			InputAction inputAction = nYFPFhmeiZTvFQwtRNQoMbHnXEXJ[j];
			dhxGWXbXbNQZQXpgSkWZfuUppGGC[inputAction.id] = new RYLWFhUIlBUUYZaWBIulsLpHuxEL(inputAction, j);
		}
		IxOohiotbZnrlkFigwRcbKZWOeJE = new ADictionary<string, RYLWFhUIlBUUYZaWBIulsLpHuxEL>(pRQRcuevmXOSwlAFtrKkHiKrXwfN, StringComparer.OrdinalIgnoreCase);
		for (int k = 0; k < pRQRcuevmXOSwlAFtrKkHiKrXwfN; k++)
		{
			InputAction inputAction2 = nYFPFhmeiZTvFQwtRNQoMbHnXEXJ[k];
			try
			{
				IxOohiotbZnrlkFigwRcbKZWOeJE.Add(inputAction2.name, dhxGWXbXbNQZQXpgSkWZfuUppGGC[inputAction2.id]);
			}
			catch
			{
				Logger.LogError("Duplicate Action name \"" + inputAction2.name + "\" found in Action list. Duplicate Action names are not allowed. If you have edited the data manually outside the Rewired Input Manager, remove any duplicate Actions.");
			}
		}
		vFTcCOLGWGRvqvtLhPPnltjFOpVC = new ReadOnlyCollection<InputAction>(nYFPFhmeiZTvFQwtRNQoMbHnXEXJ);
	}

	public InputAction VImAJPVLgiorGVOJDSOudNQAjQHW(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return null;
		}
		if (!IxOohiotbZnrlkFigwRcbKZWOeJE.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				QsyfBOyxtCKeIaaHNojtICYDufYU(P_0);
			}
			return null;
		}
		return value.ZMfVKuSKhGVLGUOOsXjjvqdgwTN;
	}

	public InputAction fEjqfVXFCLeaglorPplnfacFxZpK(int P_0)
	{
		if (P_0 < 0)
		{
			return null;
		}
		if (P_0 > WjVsjUNWSAfgTBYSyCRsZZOsJyLP)
		{
			return null;
		}
		if (dhxGWXbXbNQZQXpgSkWZfuUppGGC[P_0] == null)
		{
			return null;
		}
		return dhxGWXbXbNQZQXpgSkWZfuUppGGC[P_0].ZMfVKuSKhGVLGUOOsXjjvqdgwTN;
	}

	public InputAction jLdKKhJcoSthDrlMlNcQsIemDYPCA(int P_0)
	{
		if (P_0 < 0 || P_0 >= pRQRcuevmXOSwlAFtrKkHiKrXwfN)
		{
			return null;
		}
		return nYFPFhmeiZTvFQwtRNQoMbHnXEXJ[P_0];
	}

	public int FPoTsijAGQiZSfqTEonVRgnRBHCBA(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!IxOohiotbZnrlkFigwRcbKZWOeJE.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				QsyfBOyxtCKeIaaHNojtICYDufYU(P_0);
			}
			return -1;
		}
		return value.BmrfpaDKlKVeyjmIQrNMUPpUhnkk;
	}

	public int WaOsqNIhktcJIChspDZEFYLNIIjmA(int P_0, bool P_1 = false)
	{
		if (P_0 < 0 || P_0 > WjVsjUNWSAfgTBYSyCRsZZOsJyLP)
		{
			if (P_0 >= 0 && P_1)
			{
				PsNfCKKLyNIqXUfwOhNMBBtHmrdnb(P_0);
			}
			return -1;
		}
		RYLWFhUIlBUUYZaWBIulsLpHuxEL rYLWFhUIlBUUYZaWBIulsLpHuxEL = dhxGWXbXbNQZQXpgSkWZfuUppGGC[P_0];
		if (rYLWFhUIlBUUYZaWBIulsLpHuxEL == null)
		{
			if (P_1)
			{
				PsNfCKKLyNIqXUfwOhNMBBtHmrdnb(P_0);
			}
			return -1;
		}
		return rYLWFhUIlBUUYZaWBIulsLpHuxEL.BmrfpaDKlKVeyjmIQrNMUPpUhnkk;
	}

	public bool xXQDfjCgWgpEifaPwfdozFqgKOALA(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!IxOohiotbZnrlkFigwRcbKZWOeJE.ContainsKey(P_0))
		{
			if (P_1)
			{
				QsyfBOyxtCKeIaaHNojtICYDufYU(P_0);
			}
			return false;
		}
		return true;
	}

	public bool TCShGtimUNxrAiibWRfDQtMZfTtkA(int P_0)
	{
		if (P_0 < 0 || P_0 > WjVsjUNWSAfgTBYSyCRsZZOsJyLP)
		{
			return false;
		}
		return dhxGWXbXbNQZQXpgSkWZfuUppGGC[P_0] != null;
	}

	public int urxGYFBOdknWEgSSRLCNrMdqeLifb(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!IxOohiotbZnrlkFigwRcbKZWOeJE.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				QsyfBOyxtCKeIaaHNojtICYDufYU(P_0);
			}
			return -1;
		}
		return value.GHtMrbMoHyllnWhYeLFLsHOEkHCd;
	}

	private void QsyfBOyxtCKeIaaHNojtICYDufYU(string P_0)
	{
		if (!fcNGdhAcBUBpFTfBkZenWWUpTglU.Contains(P_0))
		{
			fcNGdhAcBUBpFTfBkZenWWUpTglU.Add(P_0);
			Logger.LogWarning("The Action \"" + P_0 + "\" does not exist. You can create Actions in the editor.");
		}
	}

	private void PsNfCKKLyNIqXUfwOhNMBBtHmrdnb(int P_0)
	{
		if (!EGnTyIqYHHeHlcoKLiXdpFzFhsZE.Contains(P_0))
		{
			EGnTyIqYHHeHlcoKLiXdpFzFhsZE.Add(P_0);
			Logger.LogWarning("No Action exists for Action Id " + P_0 + ". You can create Actions in the editor.");
		}
	}
}
