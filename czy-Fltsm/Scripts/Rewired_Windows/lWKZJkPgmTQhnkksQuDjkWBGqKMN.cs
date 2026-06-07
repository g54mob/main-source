using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired;
using Rewired.Data;
using Rewired.Interfaces;

internal class lWKZJkPgmTQhnkksQuDjkWBGqKMN : IInputSource, IDisposable
{
	private static JzdveMZUVasJFkcSCCrAJjOwdxJOA VrIplhaLPxqeMTYEzKvGTZKjsZv;

	private List<ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB> picbWBDwonLYslPWXJwdnFQVlHygb;

	private ReadOnlyCollection<ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB> BDmaMUVJYgqxFOuGKRJlLbKPdQFt;

	private ConfigVars ePbcWweNXPuSXQBixqZdUIPAQFQCb;

	private readonly bool BidzHnbBULlPUOsBiTATMvqWrsRm;

	private readonly bool CjUYCFCeGaIBtfiMPbqQqlQDovKV;

	private readonly bool YdMbWSfAKXEWvkqGTZrkWxYpdqxoA;

	private bool ibwZZbZEKqAnnnWrXdcvPrhqfXaO;

	[CompilerGenerated]
	private Action m_KDaAMIGUqlPwQFpWTCWRowCVALeA;

	private readonly bool KUTOanEHoOGJkaoNGgbrZkwEBMN;

	private readonly bool YHrjsmBVegBDiugQhVHVbHirUglw;

	private readonly bool FmbliPUSbQEHnGfCHpeWqxommpKQ;

	private bool rcCPbUPTddeZztuTkrOLfxArOiqK;

	private double mnLRTtYYANLqQZrPIEBygANpedQkA;

	private int ThFaLDJyDyNiqfwmNKYDJuWIFyNC;

	private bool bYeEyZTviPOVMeBnPihEbtBDEKdBA;

	private static readonly string gmlzeyriyWFMMHIsMLVWEFtfvOENA = "Rewired Windows Gaming Input support is not available on this system.";

	private bool KgtInvFmlYafdpmjKkSGQsYIhPlI;

	public IUnifiedKeyboardSource TTqDPYLmPMJwnPwgoqJwVoafLeil => null;

	public IUnifiedMouseSource AoLbDhShPcBqYJRfmJakABrXNheD => null;

	private event Action KDaAMIGUqlPwQFpWTCWRowCVALeA
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_KDaAMIGUqlPwQFpWTCWRowCVALeA;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_KDaAMIGUqlPwQFpWTCWRowCVALeA, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_KDaAMIGUqlPwQFpWTCWRowCVALeA;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_KDaAMIGUqlPwQFpWTCWRowCVALeA, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	event Action IInputSource.DeviceChangedEvent
	{
		add
		{
			KDaAMIGUqlPwQFpWTCWRowCVALeA += value;
		}
		remove
		{
			KDaAMIGUqlPwQFpWTCWRowCVALeA -= value;
		}
	}

	public lWKZJkPgmTQhnkksQuDjkWBGqKMN(ConfigVars P_0, bool P_1, bool P_2, bool P_3)
	{
		try
		{
			ePbcWweNXPuSXQBixqZdUIPAQFQCb = P_0;
			BidzHnbBULlPUOsBiTATMvqWrsRm = P_1;
			CjUYCFCeGaIBtfiMPbqQqlQDovKV = P_2;
			YdMbWSfAKXEWvkqGTZrkWxYpdqxoA = P_3;
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
				if (!tsCBxloSjtavBHHVzKUqIGsQvsPTA.alDrjDEyLsOdDocEwvEYXuiXlNwI())
				{
					Logger.LogWarning(gmlzeyriyWFMMHIsMLVWEFtfvOENA + " Requires " + tsCBxloSjtavBHHVzKUqIGsQvsPTA.KFkmWDCAMAcxEshtOFgeDXjhcWxDb() + " or greater.");
					throw new Exception();
				}
			}
			catch (DllNotFoundException)
			{
				Logger.LogWarning(gmlzeyriyWFMMHIsMLVWEFtfvOENA + " Either Rewired_WindowsGamingInput.dll is missing or this version of Windows does not meet the minimum version requirements for Windows Gaming Input support.");
				throw new Exception();
			}
			catch
			{
				Logger.LogWarning(gmlzeyriyWFMMHIsMLVWEFtfvOENA);
				throw new Exception();
			}
			KUTOanEHoOGJkaoNGgbrZkwEBMN = true;
			if (FmbliPUSbQEHnGfCHpeWqxommpKQ)
			{
				YHrjsmBVegBDiugQhVHVbHirUglw = false;
			}
			if (KUTOanEHoOGJkaoNGgbrZkwEBMN)
			{
				VrIplhaLPxqeMTYEzKvGTZKjsZv = new JzdveMZUVasJFkcSCCrAJjOwdxJOA(djulFfjhfpwIHPoGboIDJtUXokuD);
			}
			picbWBDwonLYslPWXJwdnFQVlHygb = new List<ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB>();
			BDmaMUVJYgqxFOuGKRJlLbKPdQFt = new ReadOnlyCollection<ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB>(picbWBDwonLYslPWXJwdnFQVlHygb);
			if (KUTOanEHoOGJkaoNGgbrZkwEBMN)
			{
				VrIplhaLPxqeMTYEzKvGTZKjsZv.mmJkWdehmoDVzbePVtvAEhjKcdiR += rGzBpyEWpyMlyrlxTIaqIoRGdZIMb;
			}
			if (P_1)
			{
				FiwfKhsytIlaWnUJDBeNzrYjeMGf(true);
			}
			ReInput.ApplicationFocusChangedEvent += kdnTzmhslLNBVvAKWdMZQKRDrXfP;
		}
		catch (Exception)
		{
			Dispose();
			throw;
		}
	}

	public void swMCBZUMKdBIOaZDgDmYMylJSGQx()
	{
		ibwZZbZEKqAnnnWrXdcvPrhqfXaO = false;
		FiwfKhsytIlaWnUJDBeNzrYjeMGf(false);
	}

	public bool hmALJPBkwmzsjNTbloegeAoiWvMW(PidVid P_0)
	{
		if (KUTOanEHoOGJkaoNGgbrZkwEBMN && QXMSgcVznodSmSMxPAPQfqnygfQgA.GzlLsbVsgiwhCpQQIlqucVVHahXK(P_0.vendorId, P_0.productId))
		{
			return true;
		}
		return false;
	}

	public void SystemDeviceDisconnected()
	{
		rGzBpyEWpyMlyrlxTIaqIoRGdZIMb();
	}

	void IInputSource.SystemDeviceDisconnected()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceDisconnected
		this.SystemDeviceDisconnected();
	}

	public void SystemDeviceConnected()
	{
		rGzBpyEWpyMlyrlxTIaqIoRGdZIMb();
	}

	void IInputSource.SystemDeviceConnected()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceConnected
		this.SystemDeviceConnected();
	}

	public void Update()
	{
		if (bYeEyZTviPOVMeBnPihEbtBDEKdBA)
		{
			rGzBpyEWpyMlyrlxTIaqIoRGdZIMb();
		}
		if (KUTOanEHoOGJkaoNGgbrZkwEBMN)
		{
			VrIplhaLPxqeMTYEzKvGTZKjsZv.KeLoRfDFJkxCDiuaiuVMspEJZhym();
		}
	}

	void IInputSource.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void UpdateDevices(UpdateLoopType updateLoop)
	{
		if (BidzHnbBULlPUOsBiTATMvqWrsRm)
		{
			for (int i = 0; i < picbWBDwonLYslPWXJwdnFQVlHygb.Count; i++)
			{
				picbWBDwonLYslPWXJwdnFQVlHygb[i]?.qMadxgUviENuFflzscwvgIcwktXAA(updateLoop);
			}
			if (KUTOanEHoOGJkaoNGgbrZkwEBMN)
			{
				VrIplhaLPxqeMTYEzKvGTZKjsZv.MZKVtJfHYkOiyZCxKNarSqoKrDet();
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
		for (int i = 0; i < picbWBDwonLYslPWXJwdnFQVlHygb.Count; i++)
		{
			picbWBDwonLYslPWXJwdnFQVlHygb[i]?.aBjBIgiWRCXfcvGbniRzblOTjeog();
		}
	}

	void IInputSource.UpdateFinished()
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateFinished
		this.UpdateFinished();
	}

	public IList<T> GetJoysticks<T>() where T : class
	{
		return BDmaMUVJYgqxFOuGKRJlLbKPdQFt as IList<T>;
	}

	IList<T> IInputSource.GetJoysticks<T>()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetJoysticks
		return this.GetJoysticks<T>();
	}

	private void FiwfKhsytIlaWnUJDBeNzrYjeMGf(bool P_0)
	{
		if (bYeEyZTviPOVMeBnPihEbtBDEKdBA)
		{
			bYeEyZTviPOVMeBnPihEbtBDEKdBA = false;
		}
		List<ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB> list = new List<ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB>();
		int num = 0;
		if (KUTOanEHoOGJkaoNGgbrZkwEBMN)
		{
			IList<dsXpdqMEhGdwtHOaddkDMBIIySZOA> list2 = VrIplhaLPxqeMTYEzKvGTZKjsZv.JcEQExxxPdoWiLNnUOxBUCnxpALd();
			for (int i = 0; i < list2.Count; i++)
			{
				dsXpdqMEhGdwtHOaddkDMBIIySZOA dsXpdqMEhGdwtHOaddkDMBIIySZOA2 = list2[i];
				if (dsXpdqMEhGdwtHOaddkDMBIIySZOA2 != null)
				{
					list.Add(dsXpdqMEhGdwtHOaddkDMBIIySZOA2);
					num++;
				}
			}
		}
		if (list.Count == 0)
		{
			picbWBDwonLYslPWXJwdnFQVlHygb.Clear();
			return;
		}
		int count = list.Count;
		int count2 = picbWBDwonLYslPWXJwdnFQVlHygb.Count;
		ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB[] array = new ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB[count];
		for (int j = 0; j < count; j++)
		{
			bool flag = false;
			for (int k = 0; k < count2; k++)
			{
				if (list[j] != null && picbWBDwonLYslPWXJwdnFQVlHygb[k] != null && list[j].DlFRWDrCDbleCmLxvwDIeTLMcxrr == picbWBDwonLYslPWXJwdnFQVlHygb[k].DlFRWDrCDbleCmLxvwDIeTLMcxrr)
				{
					array[j] = picbWBDwonLYslPWXJwdnFQVlHygb[k];
					array[j].XifIPXkIqvqdRREHdfcaNoFufzwU(list[j]);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				array[j] = list[j];
			}
		}
		picbWBDwonLYslPWXJwdnFQVlHygb.Clear();
		for (int l = 0; l < count; l++)
		{
			if (array[l] != null)
			{
				picbWBDwonLYslPWXJwdnFQVlHygb.Add(array[l]);
			}
		}
	}

	private void rGzBpyEWpyMlyrlxTIaqIoRGdZIMb()
	{
		if (BidzHnbBULlPUOsBiTATMvqWrsRm)
		{
			ibwZZbZEKqAnnnWrXdcvPrhqfXaO = true;
		}
		if (this.KDaAMIGUqlPwQFpWTCWRowCVALeA != null)
		{
			this.KDaAMIGUqlPwQFpWTCWRowCVALeA();
		}
	}

	private int djulFfjhfpwIHPoGboIDJtUXokuD()
	{
		int thFaLDJyDyNiqfwmNKYDJuWIFyNC = ThFaLDJyDyNiqfwmNKYDJuWIFyNC;
		if (ThFaLDJyDyNiqfwmNKYDJuWIFyNC == int.MaxValue)
		{
			ThFaLDJyDyNiqfwmNKYDJuWIFyNC = 0;
			return thFaLDJyDyNiqfwmNKYDJuWIFyNC;
		}
		ThFaLDJyDyNiqfwmNKYDJuWIFyNC++;
		return thFaLDJyDyNiqfwmNKYDJuWIFyNC;
	}

	private void kdnTzmhslLNBVvAKWdMZQKRDrXfP(bool P_0)
	{
		if (BidzHnbBULlPUOsBiTATMvqWrsRm && P_0)
		{
			bYeEyZTviPOVMeBnPihEbtBDEKdBA = true;
		}
	}

	public void Dispose()
	{
		sAQAqXoxBlLtuBLYUShvZkKwLUNo(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void KjCnnorAjatPSEXXkiDwEVIgbQaQ()
	{
		try
		{
			sAQAqXoxBlLtuBLYUShvZkKwLUNo(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void sAQAqXoxBlLtuBLYUShvZkKwLUNo(bool P_0)
	{
		if (KgtInvFmlYafdpmjKkSGQsYIhPlI)
		{
			return;
		}
		if (P_0)
		{
			ReInput.ApplicationFocusChangedEvent -= kdnTzmhslLNBVvAKWdMZQKRDrXfP;
			if (VrIplhaLPxqeMTYEzKvGTZKjsZv != null)
			{
				VrIplhaLPxqeMTYEzKvGTZKjsZv.Dispose();
			}
			if (picbWBDwonLYslPWXJwdnFQVlHygb != null)
			{
				for (int i = 0; i < picbWBDwonLYslPWXJwdnFQVlHygb.Count; i++)
				{
					if (picbWBDwonLYslPWXJwdnFQVlHygb[i] != null)
					{
						picbWBDwonLYslPWXJwdnFQVlHygb[i].Dispose();
					}
				}
			}
		}
		KgtInvFmlYafdpmjKkSGQsYIhPlI = true;
	}
}
