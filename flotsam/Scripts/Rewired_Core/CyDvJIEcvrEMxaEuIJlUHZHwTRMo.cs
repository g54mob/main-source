using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class CyDvJIEcvrEMxaEuIJlUHZHwTRMo
{
	private class QeaPmlNykLuxIvGquJnlVsckAclD
	{
		public readonly InputAction CwxyZJvzZtgnusfIlccjDKbKrMeDb;

		public readonly int LxWfYsiPxmaVWyatPKaJiPYnFArxA;

		public readonly int YWYazpMHiUYtXRVUzBCWrMothZZm;

		public QeaPmlNykLuxIvGquJnlVsckAclD(InputAction P_0, int P_1)
		{
			CwxyZJvzZtgnusfIlccjDKbKrMeDb = P_0;
			LxWfYsiPxmaVWyatPKaJiPYnFArxA = P_0.id;
			YWYazpMHiUYtXRVUzBCWrMothZZm = P_1;
		}
	}

	private InputAction[] egqdBodrpJObeecxIwuqcbUpWzaRb;

	private ADictionary<string, QeaPmlNykLuxIvGquJnlVsckAclD> VExsqljcgDBJWGKVLQVmRMTdqkykA;

	private QeaPmlNykLuxIvGquJnlVsckAclD[] ybAGKSeyEZrqlAvrhFNRROtOBJxhb;

	private ReadOnlyCollection<InputAction> wAwweBEiLADlJaBpKqmlhUauzuqbA;

	private int cnjygtdhxBAgDVLTSohcyDDOxSWS;

	private int NzqhgDQDQOAiqfcGRwikosTRQbiK;

	private List<string> ggmgQgFCGIaVeFhLVoLvJnXOEAQLA;

	private List<int> LWOmBNxUsPAsGOYIwLUrAePgZRwC;

	public IList<InputAction> jfcDDlHmBpYiSSIzFklkPMeTElLiA => wAwweBEiLADlJaBpKqmlhUauzuqbA;

	public int bckRRJzTFliiXHIVPBVFqqmIRafV => cnjygtdhxBAgDVLTSohcyDDOxSWS;

	public int echKJcMQeDVAxadtvbMojJnhdfmM => NzqhgDQDQOAiqfcGRwikosTRQbiK;

	public CyDvJIEcvrEMxaEuIJlUHZHwTRMo(List<InputAction> P_0)
	{
		ggmgQgFCGIaVeFhLVoLvJnXOEAQLA = new List<string>();
		LWOmBNxUsPAsGOYIwLUrAePgZRwC = new List<int>();
		egqdBodrpJObeecxIwuqcbUpWzaRb = P_0.ToArray();
		cnjygtdhxBAgDVLTSohcyDDOxSWS = egqdBodrpJObeecxIwuqcbUpWzaRb.Length;
		int num = -1;
		for (int i = 0; i < cnjygtdhxBAgDVLTSohcyDDOxSWS; i++)
		{
			int id = egqdBodrpJObeecxIwuqcbUpWzaRb[i].id;
			if (id > num)
			{
				num = id;
			}
		}
		NzqhgDQDQOAiqfcGRwikosTRQbiK = num;
		ybAGKSeyEZrqlAvrhFNRROtOBJxhb = new QeaPmlNykLuxIvGquJnlVsckAclD[num + 1];
		for (int j = 0; j < cnjygtdhxBAgDVLTSohcyDDOxSWS; j++)
		{
			InputAction inputAction = egqdBodrpJObeecxIwuqcbUpWzaRb[j];
			ybAGKSeyEZrqlAvrhFNRROtOBJxhb[inputAction.id] = new QeaPmlNykLuxIvGquJnlVsckAclD(inputAction, j);
		}
		VExsqljcgDBJWGKVLQVmRMTdqkykA = new ADictionary<string, QeaPmlNykLuxIvGquJnlVsckAclD>(cnjygtdhxBAgDVLTSohcyDDOxSWS, StringComparer.OrdinalIgnoreCase);
		for (int k = 0; k < cnjygtdhxBAgDVLTSohcyDDOxSWS; k++)
		{
			InputAction inputAction2 = egqdBodrpJObeecxIwuqcbUpWzaRb[k];
			try
			{
				VExsqljcgDBJWGKVLQVmRMTdqkykA.Add(inputAction2.name, ybAGKSeyEZrqlAvrhFNRROtOBJxhb[inputAction2.id]);
			}
			catch
			{
				Logger.LogError("Duplicate Action name \"" + inputAction2.name + "\" found in Action list. Duplicate Action names are not allowed. If you have edited the data manually outside the Rewired Input Manager, remove any duplicate Actions.");
			}
		}
		wAwweBEiLADlJaBpKqmlhUauzuqbA = new ReadOnlyCollection<InputAction>(egqdBodrpJObeecxIwuqcbUpWzaRb);
	}

	public InputAction MaBqBGMglwlFblDVqevucOFjoimZA(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return null;
		}
		if (!VExsqljcgDBJWGKVLQVmRMTdqkykA.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				LkNLtDbSsCAQzSpPqUAprOLaPLdL(P_0);
			}
			return null;
		}
		return value.CwxyZJvzZtgnusfIlccjDKbKrMeDb;
	}

	public InputAction sAOuuCAMJXQrJLEfgeCrKQxwHbAU(int P_0)
	{
		if (P_0 < 0)
		{
			return null;
		}
		if (P_0 > NzqhgDQDQOAiqfcGRwikosTRQbiK)
		{
			return null;
		}
		if (ybAGKSeyEZrqlAvrhFNRROtOBJxhb[P_0] == null)
		{
			return null;
		}
		return ybAGKSeyEZrqlAvrhFNRROtOBJxhb[P_0].CwxyZJvzZtgnusfIlccjDKbKrMeDb;
	}

	public InputAction uqYYtgClUWJVgNOIYRTOBfbTgekg(int P_0)
	{
		if (P_0 < 0 || P_0 >= cnjygtdhxBAgDVLTSohcyDDOxSWS)
		{
			return null;
		}
		return egqdBodrpJObeecxIwuqcbUpWzaRb[P_0];
	}

	public int GUBPPhmqZCglriHZbaAZukoqMhrUA(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!VExsqljcgDBJWGKVLQVmRMTdqkykA.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				LkNLtDbSsCAQzSpPqUAprOLaPLdL(P_0);
			}
			return -1;
		}
		return value.YWYazpMHiUYtXRVUzBCWrMothZZm;
	}

	public int JhlDaGJYzfnrxwSiGQiEnISqUoWv(int P_0, bool P_1 = false)
	{
		if (P_0 < 0 || P_0 > NzqhgDQDQOAiqfcGRwikosTRQbiK)
		{
			if (P_0 >= 0 && P_1)
			{
				CMmQrDQziNYpcRybtcSUikVPDAQd(P_0);
			}
			return -1;
		}
		QeaPmlNykLuxIvGquJnlVsckAclD qeaPmlNykLuxIvGquJnlVsckAclD = ybAGKSeyEZrqlAvrhFNRROtOBJxhb[P_0];
		if (qeaPmlNykLuxIvGquJnlVsckAclD == null)
		{
			if (P_1)
			{
				CMmQrDQziNYpcRybtcSUikVPDAQd(P_0);
			}
			return -1;
		}
		return qeaPmlNykLuxIvGquJnlVsckAclD.YWYazpMHiUYtXRVUzBCWrMothZZm;
	}

	public bool iFplZcxJCkqLNSPnNGQuijkZwhVc(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!VExsqljcgDBJWGKVLQVmRMTdqkykA.ContainsKey(P_0))
		{
			if (P_1)
			{
				LkNLtDbSsCAQzSpPqUAprOLaPLdL(P_0);
			}
			return false;
		}
		return true;
	}

	public bool SbvIUabXsNXWvItKnYCZlGRehkIm(int P_0)
	{
		if (P_0 < 0 || P_0 > NzqhgDQDQOAiqfcGRwikosTRQbiK)
		{
			return false;
		}
		return ybAGKSeyEZrqlAvrhFNRROtOBJxhb[P_0] != null;
	}

	public int dmYQlGLkZgonreWukheZbeHXtLFC(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!VExsqljcgDBJWGKVLQVmRMTdqkykA.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				LkNLtDbSsCAQzSpPqUAprOLaPLdL(P_0);
			}
			return -1;
		}
		return value.LxWfYsiPxmaVWyatPKaJiPYnFArxA;
	}

	private void LkNLtDbSsCAQzSpPqUAprOLaPLdL(string P_0)
	{
		if (!ggmgQgFCGIaVeFhLVoLvJnXOEAQLA.Contains(P_0))
		{
			ggmgQgFCGIaVeFhLVoLvJnXOEAQLA.Add(P_0);
			Logger.LogWarning("The Action \"" + P_0 + "\" does not exist. You can create Actions in the editor.");
		}
	}

	private void CMmQrDQziNYpcRybtcSUikVPDAQd(int P_0)
	{
		if (!LWOmBNxUsPAsGOYIwLUrAePgZRwC.Contains(P_0))
		{
			LWOmBNxUsPAsGOYIwLUrAePgZRwC.Add(P_0);
			Logger.LogWarning("No Action exists for Action Id " + P_0 + ". You can create Actions in the editor.");
		}
	}
}
