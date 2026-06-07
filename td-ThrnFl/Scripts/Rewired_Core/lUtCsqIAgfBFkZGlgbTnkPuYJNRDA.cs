using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class lUtCsqIAgfBFkZGlgbTnkPuYJNRDA
{
	private class bDCmdKPhKTtMoSTgEnlCHLnUEGmF
	{
		public readonly InputAction hVTSmnlzWvJuhJFVFUCQUvGqfCvp;

		public readonly int uvsZbKNruqdKPRAolAKkKVrDZKwuA;

		public readonly int jbohYFhSzWosCGyJBLqjVxFoDPSqb;

		public bDCmdKPhKTtMoSTgEnlCHLnUEGmF(InputAction P_0, int P_1)
		{
			hVTSmnlzWvJuhJFVFUCQUvGqfCvp = P_0;
			uvsZbKNruqdKPRAolAKkKVrDZKwuA = P_0.id;
			jbohYFhSzWosCGyJBLqjVxFoDPSqb = P_1;
		}
	}

	private InputAction[] RSMCkAKzuJUohILoIZEFkhfsmhhPA;

	private ADictionary<string, bDCmdKPhKTtMoSTgEnlCHLnUEGmF> ysXXHZnSjHEADvdIlTbHAOmDXerO;

	private bDCmdKPhKTtMoSTgEnlCHLnUEGmF[] TcudncceLNyzsPOaTLnaGKUDiHwMB;

	private ReadOnlyCollection<InputAction> TbYzFbMJQIBsUcmmktQOEkNYGszHA;

	private int VzNBXZtRgFJrAuLWeYJFsqsudADcA;

	private int gIsClKIGUIJdwSZtgIXAqmGvOnnb;

	private List<string> FtUGhKVvJOEIxQiYrvFSjdwwbABv;

	private List<int> gwcTtEnHRsXXOfRESfETKFGnZfPA;

	public IList<InputAction> GpGjcLJqOjgpHpNgraZJfJTtxhEz => TbYzFbMJQIBsUcmmktQOEkNYGszHA;

	public int GoIOqdlPCzCvEFwUfldukyRwTcoY => VzNBXZtRgFJrAuLWeYJFsqsudADcA;

	public int HpPlLEMphRQiePRaLceXxlEXrinm => gIsClKIGUIJdwSZtgIXAqmGvOnnb;

	public lUtCsqIAgfBFkZGlgbTnkPuYJNRDA(List<InputAction> P_0)
	{
		FtUGhKVvJOEIxQiYrvFSjdwwbABv = new List<string>();
		gwcTtEnHRsXXOfRESfETKFGnZfPA = new List<int>();
		RSMCkAKzuJUohILoIZEFkhfsmhhPA = P_0.ToArray();
		VzNBXZtRgFJrAuLWeYJFsqsudADcA = RSMCkAKzuJUohILoIZEFkhfsmhhPA.Length;
		int num = -1;
		for (int i = 0; i < VzNBXZtRgFJrAuLWeYJFsqsudADcA; i++)
		{
			int id = RSMCkAKzuJUohILoIZEFkhfsmhhPA[i].id;
			if (id > num)
			{
				num = id;
			}
		}
		gIsClKIGUIJdwSZtgIXAqmGvOnnb = num;
		TcudncceLNyzsPOaTLnaGKUDiHwMB = new bDCmdKPhKTtMoSTgEnlCHLnUEGmF[num + 1];
		for (int j = 0; j < VzNBXZtRgFJrAuLWeYJFsqsudADcA; j++)
		{
			InputAction inputAction = RSMCkAKzuJUohILoIZEFkhfsmhhPA[j];
			TcudncceLNyzsPOaTLnaGKUDiHwMB[inputAction.id] = new bDCmdKPhKTtMoSTgEnlCHLnUEGmF(inputAction, j);
		}
		ysXXHZnSjHEADvdIlTbHAOmDXerO = new ADictionary<string, bDCmdKPhKTtMoSTgEnlCHLnUEGmF>(VzNBXZtRgFJrAuLWeYJFsqsudADcA, StringComparer.OrdinalIgnoreCase);
		for (int k = 0; k < VzNBXZtRgFJrAuLWeYJFsqsudADcA; k++)
		{
			InputAction inputAction2 = RSMCkAKzuJUohILoIZEFkhfsmhhPA[k];
			try
			{
				ysXXHZnSjHEADvdIlTbHAOmDXerO.Add(inputAction2.name, TcudncceLNyzsPOaTLnaGKUDiHwMB[inputAction2.id]);
			}
			catch
			{
				Logger.LogError("Duplicate Action name \"" + inputAction2.name + "\" found in Action list. Duplicate Action names are not allowed. If you have edited the data manually outside the Rewired Input Manager, remove any duplicate Actions.");
			}
		}
		TbYzFbMJQIBsUcmmktQOEkNYGszHA = new ReadOnlyCollection<InputAction>(RSMCkAKzuJUohILoIZEFkhfsmhhPA);
	}

	public InputAction hblokcMPisiOeQwMIhTTYxyBYsjy(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return null;
		}
		if (!ysXXHZnSjHEADvdIlTbHAOmDXerO.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				gHvaXxtEfUHVcvGEAiMMnCuSZUuF(P_0);
			}
			return null;
		}
		return value.hVTSmnlzWvJuhJFVFUCQUvGqfCvp;
	}

	public InputAction PpmmVsSKOBgRYGwcKkaQOYCIXbJmA(int P_0)
	{
		if (P_0 < 0)
		{
			return null;
		}
		if (P_0 > gIsClKIGUIJdwSZtgIXAqmGvOnnb)
		{
			return null;
		}
		if (TcudncceLNyzsPOaTLnaGKUDiHwMB[P_0] == null)
		{
			return null;
		}
		return TcudncceLNyzsPOaTLnaGKUDiHwMB[P_0].hVTSmnlzWvJuhJFVFUCQUvGqfCvp;
	}

	public InputAction BUydWMGMgACRxwrLofLjLHAboWlF(int P_0)
	{
		if (P_0 < 0 || P_0 >= VzNBXZtRgFJrAuLWeYJFsqsudADcA)
		{
			return null;
		}
		return RSMCkAKzuJUohILoIZEFkhfsmhhPA[P_0];
	}

	public int nGtOoNcuCYgrmozQJioimkJEvJsL(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!ysXXHZnSjHEADvdIlTbHAOmDXerO.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				gHvaXxtEfUHVcvGEAiMMnCuSZUuF(P_0);
			}
			return -1;
		}
		return value.jbohYFhSzWosCGyJBLqjVxFoDPSqb;
	}

	public int iSPjDaBlidVkgDFbcWGdrWlErgNn(int P_0, bool P_1 = false)
	{
		if (P_0 < 0 || P_0 > gIsClKIGUIJdwSZtgIXAqmGvOnnb)
		{
			if (P_0 >= 0 && P_1)
			{
				rWMhRdGCoVZOdcHfZUrlkzHpDoNI(P_0);
			}
			return -1;
		}
		bDCmdKPhKTtMoSTgEnlCHLnUEGmF bDCmdKPhKTtMoSTgEnlCHLnUEGmF2 = TcudncceLNyzsPOaTLnaGKUDiHwMB[P_0];
		if (bDCmdKPhKTtMoSTgEnlCHLnUEGmF2 == null)
		{
			if (P_1)
			{
				rWMhRdGCoVZOdcHfZUrlkzHpDoNI(P_0);
			}
			return -1;
		}
		return bDCmdKPhKTtMoSTgEnlCHLnUEGmF2.jbohYFhSzWosCGyJBLqjVxFoDPSqb;
	}

	public bool LDJCLCfOtmjeQhBKncYPuCSjyEch(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!ysXXHZnSjHEADvdIlTbHAOmDXerO.ContainsKey(P_0))
		{
			if (P_1)
			{
				gHvaXxtEfUHVcvGEAiMMnCuSZUuF(P_0);
			}
			return false;
		}
		return true;
	}

	public bool xONrOQjcURQHkhZoRaJylFgMFpBW(int P_0)
	{
		if (P_0 < 0 || P_0 > gIsClKIGUIJdwSZtgIXAqmGvOnnb)
		{
			return false;
		}
		return TcudncceLNyzsPOaTLnaGKUDiHwMB[P_0] != null;
	}

	public int QxyvowDDpotMoPiXIJWolBJvCxOV(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!ysXXHZnSjHEADvdIlTbHAOmDXerO.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				gHvaXxtEfUHVcvGEAiMMnCuSZUuF(P_0);
			}
			return -1;
		}
		return value.uvsZbKNruqdKPRAolAKkKVrDZKwuA;
	}

	private void gHvaXxtEfUHVcvGEAiMMnCuSZUuF(string P_0)
	{
		if (!FtUGhKVvJOEIxQiYrvFSjdwwbABv.Contains(P_0))
		{
			FtUGhKVvJOEIxQiYrvFSjdwwbABv.Add(P_0);
			Logger.LogWarning("The Action \"" + P_0 + "\" does not exist. You can create Actions in the editor.");
		}
	}

	private void rWMhRdGCoVZOdcHfZUrlkzHpDoNI(int P_0)
	{
		if (!gwcTtEnHRsXXOfRESfETKFGnZfPA.Contains(P_0))
		{
			gwcTtEnHRsXXOfRESfETKFGnZfPA.Add(P_0);
			Logger.LogWarning("No Action exists for Action Id " + P_0 + ". You can create Actions in the editor.");
		}
	}
}
