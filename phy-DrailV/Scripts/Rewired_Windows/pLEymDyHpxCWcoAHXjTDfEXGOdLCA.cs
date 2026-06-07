using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired;
using Rewired.Data;
using Rewired.Interfaces;

internal class pLEymDyHpxCWcoAHXjTDfEXGOdLCA : IDisposable, IInputSource
{
	private static NebFbjcyIYuVGyepRxTmZTEcCkKG bgqjBPgdCbVlhQBuETobvasnhSLmA;

	private List<NPcbXYOMZTPjQpCotxkrcLlyrqWf> uhsZTQOPiTWQesgStEowZrhIaYfdA;

	private ReadOnlyCollection<NPcbXYOMZTPjQpCotxkrcLlyrqWf> PWHqJQglIBsJzAEEKDkmBDBWGqcEA;

	private ConfigVars eDnCxCrWCeKIIFWwkGuzhumfpjvt;

	private readonly bool FmjIfSbbZQGmwOGQxbLsdNcTtdJv;

	private readonly bool xNlCJqFHDDPBFbzaNwmArLLBCiYx;

	private readonly bool MqObAwOsakkeKyBGuZsgrIetfdvr;

	private bool AMsDKfQELTtRsYmdAcBafomeQmYbA;

	[CompilerGenerated]
	private Action m_WkyGkICOmpKKyrmoxsMhfScSuttv;

	private readonly bool RDTXrslsCFSGTYbHCcgmwpkbgfSaA;

	private readonly bool qtVYmdtvCcTVgfxJLiVcSqvmixDp;

	private readonly bool ydaNrmNaGYNAVJkTnDrQKkScVlDS;

	private bool RbRkpVLCCnBJFKqKXgZnWSjvSAAt;

	private double flPBgwRTJkDhjdFPAeJntkULjyMx;

	private int eVPsSTNDAXJAKLITPFtsFjPZhgsV;

	private bool aaLcKtDxyPptecMBsYmTCDYxVvFf;

	private static readonly string mZfnGSStxUfCVQnenNfflSbaEsrb = "Rewired Windows Gaming Input support is not available on this system.";

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	public IUnifiedKeyboardSource adHBjcvEdNpHymhIkbHtEHAdbNujb => null;

	public IUnifiedMouseSource EZQxJKKBmfLZMsxGaqwTRwIDnTEb => null;

	private event Action WkyGkICOmpKKyrmoxsMhfScSuttv
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_WkyGkICOmpKKyrmoxsMhfScSuttv;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_WkyGkICOmpKKyrmoxsMhfScSuttv, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_WkyGkICOmpKKyrmoxsMhfScSuttv;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_WkyGkICOmpKKyrmoxsMhfScSuttv, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public event Action DeviceChangedEvent
	{
		add
		{
			WkyGkICOmpKKyrmoxsMhfScSuttv += value;
		}
		remove
		{
			WkyGkICOmpKKyrmoxsMhfScSuttv -= value;
		}
	}

	public pLEymDyHpxCWcoAHXjTDfEXGOdLCA(ConfigVars P_0, bool P_1, bool P_2, bool P_3)
	{
		try
		{
			eDnCxCrWCeKIIFWwkGuzhumfpjvt = P_0;
			FmjIfSbbZQGmwOGQxbLsdNcTtdJv = P_1;
			xNlCJqFHDDPBFbzaNwmArLLBCiYx = P_2;
			MqObAwOsakkeKyBGuZsgrIetfdvr = P_3;
			if (P_2)
			{
				throw new NotImplementedException("WGI mouse input not implemented.");
			}
			if (P_3)
			{
				throw new NotImplementedException("WGI keyboard input not implemented.");
			}
			try
			{
				if (!lgYKhAZykBItMBLqoSTMmewCDmYI.pNYeNieUNOhItxyALWuQlBuWV())
				{
					Logger.LogWarning(mZfnGSStxUfCVQnenNfflSbaEsrb + " Requires " + lgYKhAZykBItMBLqoSTMmewCDmYI.FXtGaTCTXeieRFXbmeltMoWDmPHBb() + " or greater.");
					throw new Exception();
				}
			}
			catch (DllNotFoundException)
			{
				Logger.LogWarning(mZfnGSStxUfCVQnenNfflSbaEsrb + " Either Rewired_WindowsGamingInput.dll is missing or this version of Windows does not meet the minimum version requirements for Windows Gaming Input support.");
				throw new Exception();
			}
			catch
			{
				Logger.LogWarning(mZfnGSStxUfCVQnenNfflSbaEsrb);
				throw new Exception();
			}
			RDTXrslsCFSGTYbHCcgmwpkbgfSaA = true;
			if (ydaNrmNaGYNAVJkTnDrQKkScVlDS)
			{
				qtVYmdtvCcTVgfxJLiVcSqvmixDp = false;
			}
			if (RDTXrslsCFSGTYbHCcgmwpkbgfSaA)
			{
				bgqjBPgdCbVlhQBuETobvasnhSLmA = new NebFbjcyIYuVGyepRxTmZTEcCkKG(xtrMJKEARssGUSAduIcUCuWkDmPm);
			}
			uhsZTQOPiTWQesgStEowZrhIaYfdA = new List<NPcbXYOMZTPjQpCotxkrcLlyrqWf>();
			PWHqJQglIBsJzAEEKDkmBDBWGqcEA = new ReadOnlyCollection<NPcbXYOMZTPjQpCotxkrcLlyrqWf>(uhsZTQOPiTWQesgStEowZrhIaYfdA);
			if (RDTXrslsCFSGTYbHCcgmwpkbgfSaA)
			{
				bgqjBPgdCbVlhQBuETobvasnhSLmA.eYENURNiLdjNLHPgGqToUCsgEvbx += lBMiIrPdZfvHjMarbnPVLCAJERrs;
			}
			if (P_1)
			{
				wVvzxdrDDEaQGilyJYsnhosKfeoBb(true);
			}
			ReInput.ApplicationFocusChangedEvent += orUMILCIqROwyBKfAAnTVqdZfYkj;
		}
		catch (Exception)
		{
			Dispose();
			throw;
		}
	}

	public void WSPvZFdLBPLYaAvDOopBJcbIPhan()
	{
		AMsDKfQELTtRsYmdAcBafomeQmYbA = false;
		wVvzxdrDDEaQGilyJYsnhosKfeoBb(false);
	}

	public bool sGpbxaQopaOdreijKwIPSJCLFXaDA(PidVid P_0)
	{
		if (RDTXrslsCFSGTYbHCcgmwpkbgfSaA && KjCHeFcNkYjJzESIKPSiBBloOtLf.sHQxsruLPLSKpajmNwvcvzEGGxGT(P_0.vendorId, P_0.productId))
		{
			return true;
		}
		return false;
	}

	public void SystemDeviceDisconnected()
	{
		lBMiIrPdZfvHjMarbnPVLCAJERrs();
	}

	public void SystemDeviceConnected()
	{
		lBMiIrPdZfvHjMarbnPVLCAJERrs();
	}

	public void Update()
	{
		if (aaLcKtDxyPptecMBsYmTCDYxVvFf)
		{
			lBMiIrPdZfvHjMarbnPVLCAJERrs();
		}
		if (RDTXrslsCFSGTYbHCcgmwpkbgfSaA)
		{
			bgqjBPgdCbVlhQBuETobvasnhSLmA.mefhGqvTkcrETnFSidhNngFjAYNV();
		}
	}

	public void UpdateDevices(UpdateLoopType updateLoop)
	{
		if (FmjIfSbbZQGmwOGQxbLsdNcTtdJv)
		{
			for (int i = 0; i < uhsZTQOPiTWQesgStEowZrhIaYfdA.Count; i++)
			{
				uhsZTQOPiTWQesgStEowZrhIaYfdA[i]?.mefhGqvTkcrETnFSidhNngFjAYNV(updateLoop);
			}
			if (RDTXrslsCFSGTYbHCcgmwpkbgfSaA)
			{
				bgqjBPgdCbVlhQBuETobvasnhSLmA.OBEYSjRjLIWTDPJJuJgIZZuPDcZo();
			}
		}
	}

	public void UpdateFinished()
	{
		for (int i = 0; i < uhsZTQOPiTWQesgStEowZrhIaYfdA.Count; i++)
		{
			uhsZTQOPiTWQesgStEowZrhIaYfdA[i]?.MqQjLCryqEPDlgJVxyKAVvUubRHs();
		}
	}

	public IList<T> GetJoysticks<T>() where T : class
	{
		return PWHqJQglIBsJzAEEKDkmBDBWGqcEA as IList<T>;
	}

	private void wVvzxdrDDEaQGilyJYsnhosKfeoBb(bool P_0)
	{
		if (aaLcKtDxyPptecMBsYmTCDYxVvFf)
		{
			aaLcKtDxyPptecMBsYmTCDYxVvFf = false;
		}
		List<NPcbXYOMZTPjQpCotxkrcLlyrqWf> list = new List<NPcbXYOMZTPjQpCotxkrcLlyrqWf>();
		int num = 0;
		if (RDTXrslsCFSGTYbHCcgmwpkbgfSaA)
		{
			IList<pzZEzDdoMuZGgUNhqysbzQlOheWD> list2 = bgqjBPgdCbVlhQBuETobvasnhSLmA.LRVtwyTWSgrntlaZRBVqrFfsbLRz();
			for (int i = 0; i < list2.Count; i++)
			{
				pzZEzDdoMuZGgUNhqysbzQlOheWD pzZEzDdoMuZGgUNhqysbzQlOheWD2 = list2[i];
				if (pzZEzDdoMuZGgUNhqysbzQlOheWD2 != null)
				{
					list.Add(pzZEzDdoMuZGgUNhqysbzQlOheWD2);
					num++;
				}
			}
		}
		if (list.Count == 0)
		{
			uhsZTQOPiTWQesgStEowZrhIaYfdA.Clear();
			return;
		}
		int count = list.Count;
		int count2 = uhsZTQOPiTWQesgStEowZrhIaYfdA.Count;
		NPcbXYOMZTPjQpCotxkrcLlyrqWf[] array = new NPcbXYOMZTPjQpCotxkrcLlyrqWf[count];
		for (int j = 0; j < count; j++)
		{
			bool flag = false;
			for (int k = 0; k < count2; k++)
			{
				if (list[j] != null && uhsZTQOPiTWQesgStEowZrhIaYfdA[k] != null && list[j].SCGcrIIDMjURHdkJjDIzHoMbvWQHA == uhsZTQOPiTWQesgStEowZrhIaYfdA[k].SCGcrIIDMjURHdkJjDIzHoMbvWQHA)
				{
					array[j] = uhsZTQOPiTWQesgStEowZrhIaYfdA[k];
					array[j].GakDHFgZtfHRkJQPyctqdjzIeosJc(list[j]);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				array[j] = list[j];
			}
		}
		uhsZTQOPiTWQesgStEowZrhIaYfdA.Clear();
		for (int l = 0; l < count; l++)
		{
			if (array[l] != null)
			{
				uhsZTQOPiTWQesgStEowZrhIaYfdA.Add(array[l]);
			}
		}
	}

	private void lBMiIrPdZfvHjMarbnPVLCAJERrs()
	{
		if (FmjIfSbbZQGmwOGQxbLsdNcTtdJv)
		{
			AMsDKfQELTtRsYmdAcBafomeQmYbA = true;
		}
		if (this.WkyGkICOmpKKyrmoxsMhfScSuttv != null)
		{
			this.WkyGkICOmpKKyrmoxsMhfScSuttv();
		}
	}

	private int xtrMJKEARssGUSAduIcUCuWkDmPm()
	{
		int result = eVPsSTNDAXJAKLITPFtsFjPZhgsV;
		if (eVPsSTNDAXJAKLITPFtsFjPZhgsV == int.MaxValue)
		{
			eVPsSTNDAXJAKLITPFtsFjPZhgsV = 0;
			return result;
		}
		eVPsSTNDAXJAKLITPFtsFjPZhgsV++;
		return result;
	}

	private void orUMILCIqROwyBKfAAnTVqdZfYkj(bool P_0)
	{
		if (FmjIfSbbZQGmwOGQxbLsdNcTtdJv && P_0)
		{
			aaLcKtDxyPptecMBsYmTCDYxVvFf = true;
		}
	}

	public void Dispose()
	{
		vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
	{
		try
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			return;
		}
		if (P_0)
		{
			ReInput.ApplicationFocusChangedEvent -= orUMILCIqROwyBKfAAnTVqdZfYkj;
			if (bgqjBPgdCbVlhQBuETobvasnhSLmA != null)
			{
				bgqjBPgdCbVlhQBuETobvasnhSLmA.Dispose();
			}
			if (uhsZTQOPiTWQesgStEowZrhIaYfdA != null)
			{
				for (int i = 0; i < uhsZTQOPiTWQesgStEowZrhIaYfdA.Count; i++)
				{
					if (uhsZTQOPiTWQesgStEowZrhIaYfdA[i] != null)
					{
						uhsZTQOPiTWQesgStEowZrhIaYfdA[i].Dispose();
					}
				}
			}
		}
		JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
	}
}
