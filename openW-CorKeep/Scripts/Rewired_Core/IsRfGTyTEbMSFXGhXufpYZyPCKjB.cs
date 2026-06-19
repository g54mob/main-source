using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class IsRfGTyTEbMSFXGhXufpYZyPCKjB
{
	private class WjeCJdbFCXwaFWdgjmYQYjmLBWlk
	{
		public readonly InputAction YyhnHGDnhdItELumartWHSppgVkR;

		public readonly int TWAFGhtFHodFycRREKpmvEUMTFfMA;

		public readonly int WYWHjwqjCImpnaUsubPtuAmWwWDo;

		public WjeCJdbFCXwaFWdgjmYQYjmLBWlk(InputAction P_0, int P_1)
		{
			YyhnHGDnhdItELumartWHSppgVkR = P_0;
			TWAFGhtFHodFycRREKpmvEUMTFfMA = P_0.id;
			WYWHjwqjCImpnaUsubPtuAmWwWDo = P_1;
		}
	}

	private InputAction[] oaenHdXHJBvbITkXtzSXwZIraGql;

	private ADictionary<string, WjeCJdbFCXwaFWdgjmYQYjmLBWlk> PBprmoXcOZBTshdbWtOLgHLCchuVA;

	private WjeCJdbFCXwaFWdgjmYQYjmLBWlk[] wwWeUDGJiTcmFBKJwpSuEHxJdAtRc;

	private ReadOnlyCollection<InputAction> uXsqcGuVlSTvbiZXZfhQNmaXCtuCA;

	private int ynxkipDRULkfgylVLgDTlTDrNIOb;

	private int VDajWSchtAiMAEtgIefHvZNoJXaw;

	private List<string> ifqiKtHnkEYHAjWfULEYScTjsBAbA;

	private List<int> DbYacYRAgNMYipOibpCEFzsZmCeX;

	public IList<InputAction> zDegZifxhvKwqdNZQWkPQxguqoRu => uXsqcGuVlSTvbiZXZfhQNmaXCtuCA;

	public int hfitTKBgvpRyxgDrUNUsfsirTdhU => ynxkipDRULkfgylVLgDTlTDrNIOb;

	public int gybAtbieWPNpFVpXiXYFojvGoFkI => VDajWSchtAiMAEtgIefHvZNoJXaw;

	public IsRfGTyTEbMSFXGhXufpYZyPCKjB(List<InputAction> P_0)
	{
		ifqiKtHnkEYHAjWfULEYScTjsBAbA = new List<string>();
		DbYacYRAgNMYipOibpCEFzsZmCeX = new List<int>();
		oaenHdXHJBvbITkXtzSXwZIraGql = P_0.ToArray();
		ynxkipDRULkfgylVLgDTlTDrNIOb = oaenHdXHJBvbITkXtzSXwZIraGql.Length;
		int num = -1;
		for (int i = 0; i < ynxkipDRULkfgylVLgDTlTDrNIOb; i++)
		{
			int id = oaenHdXHJBvbITkXtzSXwZIraGql[i].id;
			if (id > num)
			{
				num = id;
			}
		}
		VDajWSchtAiMAEtgIefHvZNoJXaw = num;
		wwWeUDGJiTcmFBKJwpSuEHxJdAtRc = new WjeCJdbFCXwaFWdgjmYQYjmLBWlk[num + 1];
		for (int j = 0; j < ynxkipDRULkfgylVLgDTlTDrNIOb; j++)
		{
			InputAction inputAction = oaenHdXHJBvbITkXtzSXwZIraGql[j];
			wwWeUDGJiTcmFBKJwpSuEHxJdAtRc[inputAction.id] = new WjeCJdbFCXwaFWdgjmYQYjmLBWlk(inputAction, j);
		}
		PBprmoXcOZBTshdbWtOLgHLCchuVA = new ADictionary<string, WjeCJdbFCXwaFWdgjmYQYjmLBWlk>(ynxkipDRULkfgylVLgDTlTDrNIOb, StringComparer.OrdinalIgnoreCase);
		for (int k = 0; k < ynxkipDRULkfgylVLgDTlTDrNIOb; k++)
		{
			InputAction inputAction2 = oaenHdXHJBvbITkXtzSXwZIraGql[k];
			try
			{
				PBprmoXcOZBTshdbWtOLgHLCchuVA.Add(inputAction2.name, wwWeUDGJiTcmFBKJwpSuEHxJdAtRc[inputAction2.id]);
			}
			catch
			{
				Logger.LogError("Duplicate Action name \"" + inputAction2.name + "\" found in Action list. Duplicate Action names are not allowed. If you have edited the data manually outside the Rewired Input Manager, remove any duplicate Actions.");
			}
		}
		uXsqcGuVlSTvbiZXZfhQNmaXCtuCA = new ReadOnlyCollection<InputAction>(oaenHdXHJBvbITkXtzSXwZIraGql);
	}

	public InputAction OyHTFLcgDilBXYhxjDyZLUPUhlgCA(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return null;
		}
		if (!PBprmoXcOZBTshdbWtOLgHLCchuVA.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				HGTLcAFgAEGZVbQnvBeMqRFRQLdk(P_0);
			}
			return null;
		}
		return value.YyhnHGDnhdItELumartWHSppgVkR;
	}

	public InputAction iDEVoXmwrNGrhwAHjePABafBxcAw(int P_0)
	{
		if (P_0 < 0)
		{
			return null;
		}
		if (P_0 > VDajWSchtAiMAEtgIefHvZNoJXaw)
		{
			return null;
		}
		if (wwWeUDGJiTcmFBKJwpSuEHxJdAtRc[P_0] == null)
		{
			return null;
		}
		return wwWeUDGJiTcmFBKJwpSuEHxJdAtRc[P_0].YyhnHGDnhdItELumartWHSppgVkR;
	}

	public InputAction yTKMdleDUKDXUckqZKRbMrQknuoC(int P_0)
	{
		if (P_0 < 0 || P_0 >= ynxkipDRULkfgylVLgDTlTDrNIOb)
		{
			return null;
		}
		return oaenHdXHJBvbITkXtzSXwZIraGql[P_0];
	}

	public int WrZSPgWrjCWtZyTdqRRgtIkFBkbkA(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!PBprmoXcOZBTshdbWtOLgHLCchuVA.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				HGTLcAFgAEGZVbQnvBeMqRFRQLdk(P_0);
			}
			return -1;
		}
		return value.WYWHjwqjCImpnaUsubPtuAmWwWDo;
	}

	public int BHxFaZjfRzTlJULUJJhdhsCeRfErb(int P_0, bool P_1 = false)
	{
		if (P_0 < 0 || P_0 > VDajWSchtAiMAEtgIefHvZNoJXaw)
		{
			if (P_0 >= 0 && P_1)
			{
				WqwSHCiqHXENWugKyxbrxwsmYTQJ(P_0);
			}
			return -1;
		}
		WjeCJdbFCXwaFWdgjmYQYjmLBWlk wjeCJdbFCXwaFWdgjmYQYjmLBWlk = wwWeUDGJiTcmFBKJwpSuEHxJdAtRc[P_0];
		if (wjeCJdbFCXwaFWdgjmYQYjmLBWlk == null)
		{
			if (P_1)
			{
				WqwSHCiqHXENWugKyxbrxwsmYTQJ(P_0);
			}
			return -1;
		}
		return wjeCJdbFCXwaFWdgjmYQYjmLBWlk.WYWHjwqjCImpnaUsubPtuAmWwWDo;
	}

	public bool kKfzftXYrogEtbafWAFNfUdoDrvS(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!PBprmoXcOZBTshdbWtOLgHLCchuVA.ContainsKey(P_0))
		{
			if (P_1)
			{
				HGTLcAFgAEGZVbQnvBeMqRFRQLdk(P_0);
			}
			return false;
		}
		return true;
	}

	public bool OZxAJtLPnVXsFpAHyXBuwURRqvKi(int P_0)
	{
		if (P_0 < 0 || P_0 > VDajWSchtAiMAEtgIefHvZNoJXaw)
		{
			return false;
		}
		return wwWeUDGJiTcmFBKJwpSuEHxJdAtRc[P_0] != null;
	}

	public int pQQSNZfrGqsKTZGyjgGiauouofZl(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!PBprmoXcOZBTshdbWtOLgHLCchuVA.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				HGTLcAFgAEGZVbQnvBeMqRFRQLdk(P_0);
			}
			return -1;
		}
		return value.TWAFGhtFHodFycRREKpmvEUMTFfMA;
	}

	private void HGTLcAFgAEGZVbQnvBeMqRFRQLdk(string P_0)
	{
		if (!ifqiKtHnkEYHAjWfULEYScTjsBAbA.Contains(P_0))
		{
			ifqiKtHnkEYHAjWfULEYScTjsBAbA.Add(P_0);
			Logger.LogWarning("The Action \"" + P_0 + "\" does not exist. You can create Actions in the editor.");
		}
	}

	private void WqwSHCiqHXENWugKyxbrxwsmYTQJ(int P_0)
	{
		if (!DbYacYRAgNMYipOibpCEFzsZmCeX.Contains(P_0))
		{
			DbYacYRAgNMYipOibpCEFzsZmCeX.Add(P_0);
			Logger.LogWarning("No Action exists for Action Id " + P_0 + ". You can create Actions in the editor.");
		}
	}
}
