using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class uwbgviXXIJPMnGJRVuzdFTgToYVv
{
	private class qJYfNMhUBfyqrELpvqBOONFVUTwFA
	{
		public readonly InputAction vdALMvAgZvFlLzyVfJMtUKEHsXIp;

		public readonly int ZamYCQxLHAGKChjEHxjlKOSnIhez;

		public readonly int noHOGLzPhaaQTBvOeRvlfyFcDtwbb;

		public qJYfNMhUBfyqrELpvqBOONFVUTwFA(InputAction P_0, int P_1)
		{
			vdALMvAgZvFlLzyVfJMtUKEHsXIp = P_0;
			ZamYCQxLHAGKChjEHxjlKOSnIhez = P_0.id;
			noHOGLzPhaaQTBvOeRvlfyFcDtwbb = P_1;
		}
	}

	private InputAction[] vtVxJiVfrrALdGlBGAzJFINXNlBDb;

	private ADictionary<string, qJYfNMhUBfyqrELpvqBOONFVUTwFA> OsnLdiINfEiSjFloupAhLBTZOzkU;

	private qJYfNMhUBfyqrELpvqBOONFVUTwFA[] UBovPsuxMaOUzMDPaTcSxmBIjsxH;

	private ReadOnlyCollection<InputAction> IIPXvhAFelyVtyRvqXUjiWgphEDD;

	private int yrleecZQtxlFlecLrBMGnfkQIqfBA;

	private int SenLhoxaFfQQWdteovtccNUNyvMy;

	private List<string> ssOEScaBsNdPWmPpenhxDJbSYzMrA;

	private List<int> fFxDBmdORWRGoyTQHzWnXMJTdsWl;

	public IList<InputAction> aIbkLzPaXeQZjqLXplSFfffNDmjM => IIPXvhAFelyVtyRvqXUjiWgphEDD;

	public int jpqBhpZNsMGnDgHSymiPbcaZqtarA => yrleecZQtxlFlecLrBMGnfkQIqfBA;

	public int dVbqQOLNabUQwqcVwcAGKBYSCgRBA => SenLhoxaFfQQWdteovtccNUNyvMy;

	public uwbgviXXIJPMnGJRVuzdFTgToYVv(List<InputAction> P_0)
	{
		ssOEScaBsNdPWmPpenhxDJbSYzMrA = new List<string>();
		fFxDBmdORWRGoyTQHzWnXMJTdsWl = new List<int>();
		vtVxJiVfrrALdGlBGAzJFINXNlBDb = P_0.ToArray();
		yrleecZQtxlFlecLrBMGnfkQIqfBA = vtVxJiVfrrALdGlBGAzJFINXNlBDb.Length;
		int num = -1;
		for (int i = 0; i < yrleecZQtxlFlecLrBMGnfkQIqfBA; i++)
		{
			int id = vtVxJiVfrrALdGlBGAzJFINXNlBDb[i].id;
			if (id > num)
			{
				num = id;
			}
		}
		SenLhoxaFfQQWdteovtccNUNyvMy = num;
		UBovPsuxMaOUzMDPaTcSxmBIjsxH = new qJYfNMhUBfyqrELpvqBOONFVUTwFA[num + 1];
		for (int j = 0; j < yrleecZQtxlFlecLrBMGnfkQIqfBA; j++)
		{
			InputAction inputAction = vtVxJiVfrrALdGlBGAzJFINXNlBDb[j];
			UBovPsuxMaOUzMDPaTcSxmBIjsxH[inputAction.id] = new qJYfNMhUBfyqrELpvqBOONFVUTwFA(inputAction, j);
		}
		OsnLdiINfEiSjFloupAhLBTZOzkU = new ADictionary<string, qJYfNMhUBfyqrELpvqBOONFVUTwFA>(yrleecZQtxlFlecLrBMGnfkQIqfBA, StringComparer.OrdinalIgnoreCase);
		for (int k = 0; k < yrleecZQtxlFlecLrBMGnfkQIqfBA; k++)
		{
			InputAction inputAction2 = vtVxJiVfrrALdGlBGAzJFINXNlBDb[k];
			try
			{
				OsnLdiINfEiSjFloupAhLBTZOzkU.Add(inputAction2.name, UBovPsuxMaOUzMDPaTcSxmBIjsxH[inputAction2.id]);
			}
			catch
			{
				Logger.LogError("Duplicate Action name \"" + inputAction2.name + "\" found in Action list. Duplicate Action names are not allowed. If you have edited the data manually outside the Rewired Input Manager, remove any duplicate Actions.");
			}
		}
		IIPXvhAFelyVtyRvqXUjiWgphEDD = new ReadOnlyCollection<InputAction>(vtVxJiVfrrALdGlBGAzJFINXNlBDb);
	}

	public InputAction tcSJxzCVlgQKAcLFeGJqBHMyePYq(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return null;
		}
		if (!OsnLdiINfEiSjFloupAhLBTZOzkU.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				lKCMZbPclGfkApewJIluDraeIIAc(P_0);
			}
			return null;
		}
		return value.vdALMvAgZvFlLzyVfJMtUKEHsXIp;
	}

	public InputAction NummBjJsAIbMtuHufgkHhcuvBUSmA(int P_0)
	{
		if (P_0 < 0)
		{
			return null;
		}
		if (P_0 > SenLhoxaFfQQWdteovtccNUNyvMy)
		{
			return null;
		}
		if (UBovPsuxMaOUzMDPaTcSxmBIjsxH[P_0] == null)
		{
			return null;
		}
		return UBovPsuxMaOUzMDPaTcSxmBIjsxH[P_0].vdALMvAgZvFlLzyVfJMtUKEHsXIp;
	}

	public InputAction hCeyAnYhpPoqgslzJPuFiLfEVrjy(int P_0)
	{
		if (P_0 < 0 || P_0 >= yrleecZQtxlFlecLrBMGnfkQIqfBA)
		{
			return null;
		}
		return vtVxJiVfrrALdGlBGAzJFINXNlBDb[P_0];
	}

	public int oKnsZBCQtgEufGaLOKQQPSmAuaDB(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!OsnLdiINfEiSjFloupAhLBTZOzkU.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				lKCMZbPclGfkApewJIluDraeIIAc(P_0);
			}
			return -1;
		}
		return value.noHOGLzPhaaQTBvOeRvlfyFcDtwbb;
	}

	public int oKnsZBCQtgEufGaLOKQQPSmAuaDB(int P_0, bool P_1 = false)
	{
		if (P_0 < 0 || P_0 > SenLhoxaFfQQWdteovtccNUNyvMy)
		{
			if (P_0 >= 0 && P_1)
			{
				lKCMZbPclGfkApewJIluDraeIIAc(P_0);
			}
			return -1;
		}
		qJYfNMhUBfyqrELpvqBOONFVUTwFA qJYfNMhUBfyqrELpvqBOONFVUTwFA2 = UBovPsuxMaOUzMDPaTcSxmBIjsxH[P_0];
		if (qJYfNMhUBfyqrELpvqBOONFVUTwFA2 == null)
		{
			if (P_1)
			{
				lKCMZbPclGfkApewJIluDraeIIAc(P_0);
			}
			return -1;
		}
		return qJYfNMhUBfyqrELpvqBOONFVUTwFA2.noHOGLzPhaaQTBvOeRvlfyFcDtwbb;
	}

	public bool kUiCmZCewQfczGBdspnXBabLzrLy(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!OsnLdiINfEiSjFloupAhLBTZOzkU.ContainsKey(P_0))
		{
			if (P_1)
			{
				lKCMZbPclGfkApewJIluDraeIIAc(P_0);
			}
			return false;
		}
		return true;
	}

	public bool kUiCmZCewQfczGBdspnXBabLzrLy(int P_0)
	{
		if (P_0 < 0 || P_0 > SenLhoxaFfQQWdteovtccNUNyvMy)
		{
			return false;
		}
		return UBovPsuxMaOUzMDPaTcSxmBIjsxH[P_0] != null;
	}

	public int sZUzvhZEuuICVAuNpLMKkhgSakLkA(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!OsnLdiINfEiSjFloupAhLBTZOzkU.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				lKCMZbPclGfkApewJIluDraeIIAc(P_0);
			}
			return -1;
		}
		return value.ZamYCQxLHAGKChjEHxjlKOSnIhez;
	}

	private void lKCMZbPclGfkApewJIluDraeIIAc(string P_0)
	{
		if (!ssOEScaBsNdPWmPpenhxDJbSYzMrA.Contains(P_0))
		{
			ssOEScaBsNdPWmPpenhxDJbSYzMrA.Add(P_0);
			Logger.LogWarning("The Action \"" + P_0 + "\" does not exist. You can create Actions in the editor.");
		}
	}

	private void lKCMZbPclGfkApewJIluDraeIIAc(int P_0)
	{
		if (!fFxDBmdORWRGoyTQHzWnXMJTdsWl.Contains(P_0))
		{
			fFxDBmdORWRGoyTQHzWnXMJTdsWl.Add(P_0);
			Logger.LogWarning("No Action exists for Action Id " + P_0 + ". You can create Actions in the editor.");
		}
	}
}
