using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class SfPfxaQrjElDDUkmFFxxeUUjFvLIA
{
	private class MqyBLSjJagxtFUVSxfBYNCtpjayab
	{
		public readonly InputAction GypVDhzgNYmBYMrKcmWETJyNsmdi;

		public readonly int LyOOMsRnvXUmbMbJUuEeGJpoaGcE;

		public readonly int KlMpBDKqYbqvEvAkgErxsnacrIgc;

		public MqyBLSjJagxtFUVSxfBYNCtpjayab(InputAction P_0, int P_1)
		{
			GypVDhzgNYmBYMrKcmWETJyNsmdi = P_0;
			LyOOMsRnvXUmbMbJUuEeGJpoaGcE = P_0.id;
			KlMpBDKqYbqvEvAkgErxsnacrIgc = P_1;
		}
	}

	private InputAction[] esJHMdglmbmEJOjfUiPeaDLePfUA;

	private ADictionary<string, MqyBLSjJagxtFUVSxfBYNCtpjayab> RUfcvDlsakYNesFJOXbRFYxiAjxE;

	private MqyBLSjJagxtFUVSxfBYNCtpjayab[] iqSYsUyOaedHXPxAcTwoLqSFdiqE;

	private ReadOnlyCollection<InputAction> gDcunvGXBfiYnlpuFwhSZdgnCLve;

	private int eHnicTjXhoGpvrpVTdlZDdULXgNtA;

	private int TKcfxbGAVxXHWWVCUPuVLnUAPidwA;

	private List<string> cmyWoKTxAnSLSZBVKFTSqxKLssJN;

	private List<int> ZiQguterWqAVopsEtbTCFPdhbdpSc;

	public IList<InputAction> jyuLoFNATCeressrQgpNGCxIRXCeA => gDcunvGXBfiYnlpuFwhSZdgnCLve;

	public int rteTWhhmTUbNhvGBYPwqrljVWpck => eHnicTjXhoGpvrpVTdlZDdULXgNtA;

	public int elpMIISnqilIDGlbcGYXcsaqcTnO => TKcfxbGAVxXHWWVCUPuVLnUAPidwA;

	public SfPfxaQrjElDDUkmFFxxeUUjFvLIA(List<InputAction> P_0)
	{
		cmyWoKTxAnSLSZBVKFTSqxKLssJN = new List<string>();
		ZiQguterWqAVopsEtbTCFPdhbdpSc = new List<int>();
		esJHMdglmbmEJOjfUiPeaDLePfUA = P_0.ToArray();
		eHnicTjXhoGpvrpVTdlZDdULXgNtA = esJHMdglmbmEJOjfUiPeaDLePfUA.Length;
		int num = -1;
		for (int i = 0; i < eHnicTjXhoGpvrpVTdlZDdULXgNtA; i++)
		{
			int id = esJHMdglmbmEJOjfUiPeaDLePfUA[i].id;
			if (id > num)
			{
				num = id;
			}
		}
		TKcfxbGAVxXHWWVCUPuVLnUAPidwA = num;
		iqSYsUyOaedHXPxAcTwoLqSFdiqE = new MqyBLSjJagxtFUVSxfBYNCtpjayab[num + 1];
		for (int j = 0; j < eHnicTjXhoGpvrpVTdlZDdULXgNtA; j++)
		{
			InputAction inputAction = esJHMdglmbmEJOjfUiPeaDLePfUA[j];
			iqSYsUyOaedHXPxAcTwoLqSFdiqE[inputAction.id] = new MqyBLSjJagxtFUVSxfBYNCtpjayab(inputAction, j);
		}
		RUfcvDlsakYNesFJOXbRFYxiAjxE = new ADictionary<string, MqyBLSjJagxtFUVSxfBYNCtpjayab>(eHnicTjXhoGpvrpVTdlZDdULXgNtA, StringComparer.OrdinalIgnoreCase);
		for (int k = 0; k < eHnicTjXhoGpvrpVTdlZDdULXgNtA; k++)
		{
			InputAction inputAction2 = esJHMdglmbmEJOjfUiPeaDLePfUA[k];
			try
			{
				RUfcvDlsakYNesFJOXbRFYxiAjxE.Add(inputAction2.name, iqSYsUyOaedHXPxAcTwoLqSFdiqE[inputAction2.id]);
			}
			catch
			{
				Logger.LogError("Duplicate Action name \"" + inputAction2.name + "\" found in Action list. Duplicate Action names are not allowed. If you have edited the data manually outside the Rewired Input Manager, remove any duplicate Actions.");
			}
		}
		gDcunvGXBfiYnlpuFwhSZdgnCLve = new ReadOnlyCollection<InputAction>(esJHMdglmbmEJOjfUiPeaDLePfUA);
	}

	public InputAction UrFBGeUydNKZVDjXjxgTLOAaAyxj(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return null;
		}
		if (!RUfcvDlsakYNesFJOXbRFYxiAjxE.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				NSJPBrpverlNHgONxDOQamUrlpiyA(P_0);
			}
			return null;
		}
		return value.GypVDhzgNYmBYMrKcmWETJyNsmdi;
	}

	public InputAction qeCoWwYQZyXOvrKpdOUYPOmlJAHl(int P_0)
	{
		if (P_0 < 0)
		{
			return null;
		}
		if (P_0 > TKcfxbGAVxXHWWVCUPuVLnUAPidwA)
		{
			return null;
		}
		if (iqSYsUyOaedHXPxAcTwoLqSFdiqE[P_0] == null)
		{
			return null;
		}
		return iqSYsUyOaedHXPxAcTwoLqSFdiqE[P_0].GypVDhzgNYmBYMrKcmWETJyNsmdi;
	}

	public InputAction oMQPACIRpnYACfqGBeJpGOmEqEvHb(int P_0)
	{
		if (P_0 < 0 || P_0 >= eHnicTjXhoGpvrpVTdlZDdULXgNtA)
		{
			return null;
		}
		return esJHMdglmbmEJOjfUiPeaDLePfUA[P_0];
	}

	public int WLLVULumRpsTJtCNqGAyjxbbVSyG(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!RUfcvDlsakYNesFJOXbRFYxiAjxE.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				NSJPBrpverlNHgONxDOQamUrlpiyA(P_0);
			}
			return -1;
		}
		return value.KlMpBDKqYbqvEvAkgErxsnacrIgc;
	}

	public int TZdqRkBElGhiTOcaFowdeDTzaUBEA(int P_0, bool P_1 = false)
	{
		if (P_0 < 0 || P_0 > TKcfxbGAVxXHWWVCUPuVLnUAPidwA)
		{
			if (P_0 >= 0 && P_1)
			{
				YkmVGpYBzqRNAjBmuRwjpsvGEnZx(P_0);
			}
			return -1;
		}
		MqyBLSjJagxtFUVSxfBYNCtpjayab mqyBLSjJagxtFUVSxfBYNCtpjayab = iqSYsUyOaedHXPxAcTwoLqSFdiqE[P_0];
		if (mqyBLSjJagxtFUVSxfBYNCtpjayab == null)
		{
			if (P_1)
			{
				YkmVGpYBzqRNAjBmuRwjpsvGEnZx(P_0);
			}
			return -1;
		}
		return mqyBLSjJagxtFUVSxfBYNCtpjayab.KlMpBDKqYbqvEvAkgErxsnacrIgc;
	}

	public bool kqhTfIxqZZYbleHTCgEVftiUWEeiA(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!RUfcvDlsakYNesFJOXbRFYxiAjxE.ContainsKey(P_0))
		{
			if (P_1)
			{
				NSJPBrpverlNHgONxDOQamUrlpiyA(P_0);
			}
			return false;
		}
		return true;
	}

	public bool SytSSChqDwGYVoxzucIogIUtqHDR(int P_0)
	{
		if (P_0 < 0 || P_0 > TKcfxbGAVxXHWWVCUPuVLnUAPidwA)
		{
			return false;
		}
		return iqSYsUyOaedHXPxAcTwoLqSFdiqE[P_0] != null;
	}

	public int rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!RUfcvDlsakYNesFJOXbRFYxiAjxE.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				NSJPBrpverlNHgONxDOQamUrlpiyA(P_0);
			}
			return -1;
		}
		return value.LyOOMsRnvXUmbMbJUuEeGJpoaGcE;
	}

	private void NSJPBrpverlNHgONxDOQamUrlpiyA(string P_0)
	{
		if (!cmyWoKTxAnSLSZBVKFTSqxKLssJN.Contains(P_0))
		{
			cmyWoKTxAnSLSZBVKFTSqxKLssJN.Add(P_0);
			Logger.LogWarning("The Action \"" + P_0 + "\" does not exist. You can create Actions in the editor.");
		}
	}

	private void YkmVGpYBzqRNAjBmuRwjpsvGEnZx(int P_0)
	{
		if (!ZiQguterWqAVopsEtbTCFPdhbdpSc.Contains(P_0))
		{
			ZiQguterWqAVopsEtbTCFPdhbdpSc.Add(P_0);
			Logger.LogWarning("No Action exists for Action Id " + P_0 + ". You can create Actions in the editor.");
		}
	}
}
