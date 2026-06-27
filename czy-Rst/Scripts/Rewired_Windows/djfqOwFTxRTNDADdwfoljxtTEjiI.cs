using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired;
using Rewired.Data;
using Rewired.Interfaces;

internal class djfqOwFTxRTNDADdwfoljxtTEjiI : IInputSource, IDisposable
{
	private static FKYcPWNUMoAdbCrNqFTAyfwrptpl PqWNCfcZQZESUkjRqwgpRrjXUorv;

	private List<FbLBdpdENtbItJFSSeBTXLBvWCbvA> veNhhXgSzrkyMxORnAQhKzyCVrUj;

	private ReadOnlyCollection<FbLBdpdENtbItJFSSeBTXLBvWCbvA> PJVBZABTVgAQxfiDsjjdIOofMCrgc;

	private ConfigVars kLWdLaTPCZicvxvfRtipPnbVJdki;

	private readonly bool XtCBmvnBJXczemJCAZaBLNYPPmxO;

	private readonly bool YzjdnJfIFiKlVtFBrGAEprcAbfiuA;

	private readonly bool IDbBvKAcBDRoBEeNbyXukiwayjDl;

	private bool iBBCuxNKVseJHjFuzQOdSYPjQHWdA;

	[CompilerGenerated]
	private Action m_OoaprQUlRkGtSriigHkWjSMFWChn;

	private readonly bool OgpNaahlMqakrgMbvOMvEqIfMFgrA;

	private readonly bool YvSZSyZGtkdiKEdDHBlLaDWgVwXr;

	private readonly bool HWpFPjCaFMjPTiJxbGSJvKzbfsIc;

	private bool vFncsUiPcvKEJHVEIjBHCewIkAAUb;

	private double otkqhWYPCPOscdUlitinrjEkrepB;

	private int PZeUHVHLUmGjAXAhhhgXkIMRLLdlA;

	private bool bgDLwDVvZFefsEutpZDCalhYMqPC;

	private static readonly string uwMVtcvctUcaiaRlqEpCEaXgqQsm = "Rewired Windows Gaming Input support is not available on this system.";

	private bool QwCapnIRaAGSNVDqwSIYQHyXnbBfA;

	public IUnifiedKeyboardSource VNXfsIIDOWTbTpxnYfSmCGUgJNQrA => null;

	public IUnifiedMouseSource URaPYhIAiihfqtyMUvbqFrjGwTGx => null;

	private event Action OoaprQUlRkGtSriigHkWjSMFWChn
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_OoaprQUlRkGtSriigHkWjSMFWChn;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_OoaprQUlRkGtSriigHkWjSMFWChn, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_OoaprQUlRkGtSriigHkWjSMFWChn;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_OoaprQUlRkGtSriigHkWjSMFWChn, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	event Action IInputSource.DeviceChangedEvent
	{
		add
		{
			OoaprQUlRkGtSriigHkWjSMFWChn += value;
		}
		remove
		{
			OoaprQUlRkGtSriigHkWjSMFWChn -= value;
		}
	}

	public djfqOwFTxRTNDADdwfoljxtTEjiI(ConfigVars P_0, bool P_1, bool P_2, bool P_3)
	{
		try
		{
			kLWdLaTPCZicvxvfRtipPnbVJdki = P_0;
			XtCBmvnBJXczemJCAZaBLNYPPmxO = P_1;
			YzjdnJfIFiKlVtFBrGAEprcAbfiuA = P_2;
			IDbBvKAcBDRoBEeNbyXukiwayjDl = P_3;
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
				if (!zozEkloLkrVHftHQJGwuJDULcirhA.mYioCBMEviDubGOLWGRGNWIIBvWYA())
				{
					Logger.LogWarning(uwMVtcvctUcaiaRlqEpCEaXgqQsm + " Requires " + zozEkloLkrVHftHQJGwuJDULcirhA.WJtrRYQTIeHyfGioVCaGCTIeUTEB() + " or greater.");
					throw new Exception();
				}
			}
			catch (DllNotFoundException)
			{
				Logger.LogWarning(uwMVtcvctUcaiaRlqEpCEaXgqQsm + " Either Rewired_WindowsGamingInput.dll is missing or this version of Windows does not meet the minimum version requirements for Windows Gaming Input support.");
				throw new Exception();
			}
			catch
			{
				Logger.LogWarning(uwMVtcvctUcaiaRlqEpCEaXgqQsm);
				throw new Exception();
			}
			OgpNaahlMqakrgMbvOMvEqIfMFgrA = true;
			if (HWpFPjCaFMjPTiJxbGSJvKzbfsIc)
			{
				YvSZSyZGtkdiKEdDHBlLaDWgVwXr = false;
			}
			if (OgpNaahlMqakrgMbvOMvEqIfMFgrA)
			{
				PqWNCfcZQZESUkjRqwgpRrjXUorv = new FKYcPWNUMoAdbCrNqFTAyfwrptpl(hFSnCBvwixAKcxInZbKXjOPORqOhA);
			}
			veNhhXgSzrkyMxORnAQhKzyCVrUj = new List<FbLBdpdENtbItJFSSeBTXLBvWCbvA>();
			PJVBZABTVgAQxfiDsjjdIOofMCrgc = new ReadOnlyCollection<FbLBdpdENtbItJFSSeBTXLBvWCbvA>(veNhhXgSzrkyMxORnAQhKzyCVrUj);
			if (OgpNaahlMqakrgMbvOMvEqIfMFgrA)
			{
				PqWNCfcZQZESUkjRqwgpRrjXUorv.eOyuNlqrvarnRFeQhCNWPQZDCbKz += jaIKLkGSycPEYZgknkUwbohqGZiK;
			}
			if (P_1)
			{
				PaTUCngkcIVJoHpMtWzZwJussgqO(true);
			}
			ReInput.ApplicationFocusChangedEvent += cEMjwmbMwPwlbJWLuJiVVVbSDNZM;
		}
		catch (Exception)
		{
			Dispose();
			throw;
		}
	}

	public void mldXsXYIHdHmmIOKMeAAQXFOLSsQA()
	{
		iBBCuxNKVseJHjFuzQOdSYPjQHWdA = false;
		PaTUCngkcIVJoHpMtWzZwJussgqO(false);
	}

	public bool ftPeHyLvmlMDYziBSMqrvWpFheCb(PidVid P_0)
	{
		if (OgpNaahlMqakrgMbvOMvEqIfMFgrA && IjjaNsTYgyWsWoGkfrdEwXNhabgW.WCYFilJJfkGYuUJZcXJaAfbUWsbcA(P_0.vendorId, P_0.productId))
		{
			return true;
		}
		return false;
	}

	public void SystemDeviceDisconnected()
	{
		jaIKLkGSycPEYZgknkUwbohqGZiK();
	}

	void IInputSource.SystemDeviceDisconnected()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceDisconnected
		this.SystemDeviceDisconnected();
	}

	public void SystemDeviceConnected()
	{
		jaIKLkGSycPEYZgknkUwbohqGZiK();
	}

	void IInputSource.SystemDeviceConnected()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceConnected
		this.SystemDeviceConnected();
	}

	public void Update()
	{
		if (bgDLwDVvZFefsEutpZDCalhYMqPC)
		{
			jaIKLkGSycPEYZgknkUwbohqGZiK();
		}
		if (OgpNaahlMqakrgMbvOMvEqIfMFgrA)
		{
			PqWNCfcZQZESUkjRqwgpRrjXUorv.qfyprJCmAqfTUvCTtIlbiCTvUnA();
		}
	}

	void IInputSource.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void UpdateDevices(UpdateLoopType updateLoop)
	{
		if (XtCBmvnBJXczemJCAZaBLNYPPmxO)
		{
			for (int i = 0; i < veNhhXgSzrkyMxORnAQhKzyCVrUj.Count; i++)
			{
				veNhhXgSzrkyMxORnAQhKzyCVrUj[i]?.kBVXWsIjlIIGzHVgMQVfHhSzipxQ(updateLoop);
			}
			if (OgpNaahlMqakrgMbvOMvEqIfMFgrA)
			{
				PqWNCfcZQZESUkjRqwgpRrjXUorv.CNtdALddRwFMSkxkycUvcFKcZPAuB();
			}
		}
	}

	void IInputSource.UpdateDevices(UpdateLoopType updateLoop)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateDevices
		this.UpdateDevices(updateLoop);
	}

	public void UpdateFinished()
	{
		for (int i = 0; i < veNhhXgSzrkyMxORnAQhKzyCVrUj.Count; i++)
		{
			veNhhXgSzrkyMxORnAQhKzyCVrUj[i]?.oDMEysiXXQanOPpgNgIxfyRKDzIDb();
		}
	}

	void IInputSource.UpdateFinished()
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateFinished
		this.UpdateFinished();
	}

	public IList<T> GetJoysticks<T>() where T : class
	{
		return PJVBZABTVgAQxfiDsjjdIOofMCrgc as IList<T>;
	}

	IList<T> IInputSource.GetJoysticks<T>()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetJoysticks
		return this.GetJoysticks<T>();
	}

	private void PaTUCngkcIVJoHpMtWzZwJussgqO(bool P_0)
	{
		if (bgDLwDVvZFefsEutpZDCalhYMqPC)
		{
			bgDLwDVvZFefsEutpZDCalhYMqPC = false;
		}
		List<FbLBdpdENtbItJFSSeBTXLBvWCbvA> list = new List<FbLBdpdENtbItJFSSeBTXLBvWCbvA>();
		int num = 0;
		if (OgpNaahlMqakrgMbvOMvEqIfMFgrA)
		{
			IList<tNoWbaKqbSUoLubXNGsZYacBCvle> list2 = PqWNCfcZQZESUkjRqwgpRrjXUorv.LwlshxzNqbsYIfcIoLuFPCiidvxeA();
			for (int i = 0; i < list2.Count; i++)
			{
				tNoWbaKqbSUoLubXNGsZYacBCvle tNoWbaKqbSUoLubXNGsZYacBCvle2 = list2[i];
				if (tNoWbaKqbSUoLubXNGsZYacBCvle2 != null)
				{
					list.Add(tNoWbaKqbSUoLubXNGsZYacBCvle2);
					num++;
				}
			}
		}
		if (list.Count == 0)
		{
			veNhhXgSzrkyMxORnAQhKzyCVrUj.Clear();
			return;
		}
		int count = list.Count;
		int count2 = veNhhXgSzrkyMxORnAQhKzyCVrUj.Count;
		FbLBdpdENtbItJFSSeBTXLBvWCbvA[] array = new FbLBdpdENtbItJFSSeBTXLBvWCbvA[count];
		for (int j = 0; j < count; j++)
		{
			bool flag = false;
			for (int k = 0; k < count2; k++)
			{
				if (list[j] != null && veNhhXgSzrkyMxORnAQhKzyCVrUj[k] != null && list[j].PTanXcxCpdOkoSsaVfScvbWRzJrb == veNhhXgSzrkyMxORnAQhKzyCVrUj[k].PTanXcxCpdOkoSsaVfScvbWRzJrb)
				{
					array[j] = veNhhXgSzrkyMxORnAQhKzyCVrUj[k];
					array[j].DYWanVIavhzKlMdGJFOgTSjlnzCDb(list[j]);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				array[j] = list[j];
			}
		}
		veNhhXgSzrkyMxORnAQhKzyCVrUj.Clear();
		for (int l = 0; l < count; l++)
		{
			if (array[l] != null)
			{
				veNhhXgSzrkyMxORnAQhKzyCVrUj.Add(array[l]);
			}
		}
	}

	private void jaIKLkGSycPEYZgknkUwbohqGZiK()
	{
		if (XtCBmvnBJXczemJCAZaBLNYPPmxO)
		{
			iBBCuxNKVseJHjFuzQOdSYPjQHWdA = true;
		}
		if (this.OoaprQUlRkGtSriigHkWjSMFWChn != null)
		{
			this.OoaprQUlRkGtSriigHkWjSMFWChn();
		}
	}

	private int hFSnCBvwixAKcxInZbKXjOPORqOhA()
	{
		int pZeUHVHLUmGjAXAhhhgXkIMRLLdlA = PZeUHVHLUmGjAXAhhhgXkIMRLLdlA;
		if (PZeUHVHLUmGjAXAhhhgXkIMRLLdlA == int.MaxValue)
		{
			PZeUHVHLUmGjAXAhhhgXkIMRLLdlA = 0;
			return pZeUHVHLUmGjAXAhhhgXkIMRLLdlA;
		}
		PZeUHVHLUmGjAXAhhhgXkIMRLLdlA++;
		return pZeUHVHLUmGjAXAhhhgXkIMRLLdlA;
	}

	private void cEMjwmbMwPwlbJWLuJiVVVbSDNZM(bool P_0)
	{
		if (XtCBmvnBJXczemJCAZaBLNYPPmxO && P_0)
		{
			bgDLwDVvZFefsEutpZDCalhYMqPC = true;
		}
	}

	public void Dispose()
	{
		cnrtDVocEftTWliVyBLzEzorSOtQ(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void YjaAsgncgiduguUQMdauNuwrEWxb()
	{
		try
		{
			cnrtDVocEftTWliVyBLzEzorSOtQ(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void cnrtDVocEftTWliVyBLzEzorSOtQ(bool P_0)
	{
		if (QwCapnIRaAGSNVDqwSIYQHyXnbBfA)
		{
			return;
		}
		if (P_0)
		{
			ReInput.ApplicationFocusChangedEvent -= cEMjwmbMwPwlbJWLuJiVVVbSDNZM;
			if (PqWNCfcZQZESUkjRqwgpRrjXUorv != null)
			{
				PqWNCfcZQZESUkjRqwgpRrjXUorv.Dispose();
			}
			if (veNhhXgSzrkyMxORnAQhKzyCVrUj != null)
			{
				for (int i = 0; i < veNhhXgSzrkyMxORnAQhKzyCVrUj.Count; i++)
				{
					if (veNhhXgSzrkyMxORnAQhKzyCVrUj[i] != null)
					{
						veNhhXgSzrkyMxORnAQhKzyCVrUj[i].Dispose();
					}
				}
			}
		}
		QwCapnIRaAGSNVDqwSIYQHyXnbBfA = true;
	}
}
