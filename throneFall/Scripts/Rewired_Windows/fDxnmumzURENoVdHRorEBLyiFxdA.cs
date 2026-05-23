using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired;
using Rewired.Data;
using Rewired.Interfaces;

internal class fDxnmumzURENoVdHRorEBLyiFxdA : IInputSource, IDisposable
{
	private static ZCgSuEkHKfsXrytTXKLOHjMMmbeJ DkcADtAPMUsPSvKJBvfthcBmbrmeb;

	private List<TOhoLhSgVsNthvwMxYIJmahKNXwF> jtRaBhNzyllOIBFGSJvXzEtfCHIb;

	private ReadOnlyCollection<TOhoLhSgVsNthvwMxYIJmahKNXwF> ZqjOCMgORfKTzEnJNZqjrsWbhZmv;

	private ConfigVars wikLuoWUIfojLtjuoMdyXqcYRrC;

	private readonly bool HugbbdCANSaPiMStdtIDsjikjKsF;

	private readonly bool GWXPmVhSTfuaNrEBOiTOFGWjfqdRA;

	private readonly bool OrDoMQxaHOtgNggNYOvgLAUVcdUO;

	private bool sojtvziaZjMnBfbkITLzhXvIQHHl;

	[CompilerGenerated]
	private Action m_GhGBgWzXHdccOcRyNnpQaOycaJaIB;

	private readonly bool CuVahiKSEfQtzfwlcQLdoReDMItob;

	private readonly bool UzsaIiekvzAkQKiBymsVcJmNylOtA;

	private readonly bool BUyQfNfoqRoxPYhPOTPEEXeMesbj;

	private bool bPXLtQchkgCRDipEzkCRtVYLILJEb;

	private double mSGdUjdVRCNVcXjADgXmYLVHwAzg;

	private int BuUEODiQOvdcYlqdKhvDavucvYsx;

	private bool lGtGxFsCvAAvywVyMJSGFLNliDUz;

	private static readonly string cTgKJoSgrJrHgQfpVEkQphpPuZzK = "Rewired Windows Gaming Input support is not available on this system.";

	private bool AzeLsnqBqDAXTbzmBtJQNeEkkmQdA;

	public IUnifiedKeyboardSource PitqxQuzQHruJDHtftLcpfiXXEXV => null;

	public IUnifiedMouseSource QBUIVvArenXoggHErrgsFmRhtUXdB => null;

	private event Action GhGBgWzXHdccOcRyNnpQaOycaJaIB
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_GhGBgWzXHdccOcRyNnpQaOycaJaIB;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_GhGBgWzXHdccOcRyNnpQaOycaJaIB, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_GhGBgWzXHdccOcRyNnpQaOycaJaIB;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_GhGBgWzXHdccOcRyNnpQaOycaJaIB, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	event Action IInputSource.DeviceChangedEvent
	{
		add
		{
			GhGBgWzXHdccOcRyNnpQaOycaJaIB += value;
		}
		remove
		{
			GhGBgWzXHdccOcRyNnpQaOycaJaIB -= value;
		}
	}

	public fDxnmumzURENoVdHRorEBLyiFxdA(ConfigVars P_0, bool P_1, bool P_2, bool P_3)
	{
		try
		{
			wikLuoWUIfojLtjuoMdyXqcYRrC = P_0;
			HugbbdCANSaPiMStdtIDsjikjKsF = P_1;
			GWXPmVhSTfuaNrEBOiTOFGWjfqdRA = P_2;
			OrDoMQxaHOtgNggNYOvgLAUVcdUO = P_3;
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
				if (!fHTWvRQigOspLqWwlUksTsmndmm.uZEfTPehrtJbnGoJlUIGGzgvEgFzA())
				{
					Logger.LogWarning(cTgKJoSgrJrHgQfpVEkQphpPuZzK + " Requires " + fHTWvRQigOspLqWwlUksTsmndmm.QLpqyJdbFZIkksLwXTuwvflJJdYj() + " or greater.");
					throw new Exception();
				}
			}
			catch (DllNotFoundException)
			{
				Logger.LogWarning(cTgKJoSgrJrHgQfpVEkQphpPuZzK + " Either Rewired_WindowsGamingInput.dll is missing or this version of Windows does not meet the minimum version requirements for Windows Gaming Input support.");
				throw new Exception();
			}
			catch
			{
				Logger.LogWarning(cTgKJoSgrJrHgQfpVEkQphpPuZzK);
				throw new Exception();
			}
			CuVahiKSEfQtzfwlcQLdoReDMItob = true;
			if (BUyQfNfoqRoxPYhPOTPEEXeMesbj)
			{
				UzsaIiekvzAkQKiBymsVcJmNylOtA = false;
			}
			if (CuVahiKSEfQtzfwlcQLdoReDMItob)
			{
				DkcADtAPMUsPSvKJBvfthcBmbrmeb = new ZCgSuEkHKfsXrytTXKLOHjMMmbeJ(lPiDDLaAikpJqeVdqmXBLdvfcdHxA);
			}
			jtRaBhNzyllOIBFGSJvXzEtfCHIb = new List<TOhoLhSgVsNthvwMxYIJmahKNXwF>();
			ZqjOCMgORfKTzEnJNZqjrsWbhZmv = new ReadOnlyCollection<TOhoLhSgVsNthvwMxYIJmahKNXwF>(jtRaBhNzyllOIBFGSJvXzEtfCHIb);
			if (CuVahiKSEfQtzfwlcQLdoReDMItob)
			{
				DkcADtAPMUsPSvKJBvfthcBmbrmeb.qCMhKpLyztkyPvAMKCOGJepqtsTz += bicDebnynkOICluCDNaHUDiNEbIB;
			}
			if (P_1)
			{
				FTdEFfFdaBsIuzsSYkiZZUIDivvP(true);
			}
			ReInput.ApplicationFocusChangedEvent += augOxcCKwSDqnrmHZJzZwFFnnAOp;
		}
		catch (Exception)
		{
			Dispose();
			throw;
		}
	}

	public void moFjvZxDBaDvaEoItRZQDmrpJLdSA()
	{
		sojtvziaZjMnBfbkITLzhXvIQHHl = false;
		FTdEFfFdaBsIuzsSYkiZZUIDivvP(false);
	}

	public bool zuPhDDqWjtHMNLKqmHHkOGeMeafU(PidVid P_0)
	{
		if (CuVahiKSEfQtzfwlcQLdoReDMItob && YiNGTscaFlfcYGbkCqpCNRhAgAbi.KQgsdngivtaVkcdVHXUaHSZhadcNA(P_0.vendorId, P_0.productId))
		{
			return true;
		}
		return false;
	}

	public void SystemDeviceDisconnected()
	{
		bicDebnynkOICluCDNaHUDiNEbIB();
	}

	void IInputSource.SystemDeviceDisconnected()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceDisconnected
		this.SystemDeviceDisconnected();
	}

	public void SystemDeviceConnected()
	{
		bicDebnynkOICluCDNaHUDiNEbIB();
	}

	void IInputSource.SystemDeviceConnected()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceConnected
		this.SystemDeviceConnected();
	}

	public void Update()
	{
		if (lGtGxFsCvAAvywVyMJSGFLNliDUz)
		{
			bicDebnynkOICluCDNaHUDiNEbIB();
		}
		if (CuVahiKSEfQtzfwlcQLdoReDMItob)
		{
			DkcADtAPMUsPSvKJBvfthcBmbrmeb.SKAzQpcmSrbwreWnxiQCIcWrslZi();
		}
	}

	void IInputSource.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void UpdateDevices(UpdateLoopType updateLoop)
	{
		if (HugbbdCANSaPiMStdtIDsjikjKsF)
		{
			for (int i = 0; i < jtRaBhNzyllOIBFGSJvXzEtfCHIb.Count; i++)
			{
				jtRaBhNzyllOIBFGSJvXzEtfCHIb[i]?.oXrIZgrGfJfVtbNkrZxdsEuCFcgS(updateLoop);
			}
			if (CuVahiKSEfQtzfwlcQLdoReDMItob)
			{
				DkcADtAPMUsPSvKJBvfthcBmbrmeb.QhJTPZKBRpRxMPHcTVHzeygqAHZg();
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
		for (int i = 0; i < jtRaBhNzyllOIBFGSJvXzEtfCHIb.Count; i++)
		{
			jtRaBhNzyllOIBFGSJvXzEtfCHIb[i]?.cNcvraBcXZPmQfnesTPpNCjzsqBT();
		}
	}

	void IInputSource.UpdateFinished()
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateFinished
		this.UpdateFinished();
	}

	public IList<T> GetJoysticks<T>() where T : class
	{
		return ZqjOCMgORfKTzEnJNZqjrsWbhZmv as IList<T>;
	}

	IList<T> IInputSource.GetJoysticks<T>()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetJoysticks
		return this.GetJoysticks<T>();
	}

	private void FTdEFfFdaBsIuzsSYkiZZUIDivvP(bool P_0)
	{
		if (lGtGxFsCvAAvywVyMJSGFLNliDUz)
		{
			lGtGxFsCvAAvywVyMJSGFLNliDUz = false;
		}
		List<TOhoLhSgVsNthvwMxYIJmahKNXwF> list = new List<TOhoLhSgVsNthvwMxYIJmahKNXwF>();
		int num = 0;
		if (CuVahiKSEfQtzfwlcQLdoReDMItob)
		{
			IList<dAMJUizrgPTBRKExuFwRvYIoTEmL> list2 = DkcADtAPMUsPSvKJBvfthcBmbrmeb.ZZFDglbUoouXUFQCBynRiPKNkogu();
			for (int i = 0; i < list2.Count; i++)
			{
				dAMJUizrgPTBRKExuFwRvYIoTEmL dAMJUizrgPTBRKExuFwRvYIoTEmL2 = list2[i];
				if (dAMJUizrgPTBRKExuFwRvYIoTEmL2 != null)
				{
					list.Add(dAMJUizrgPTBRKExuFwRvYIoTEmL2);
					num++;
				}
			}
		}
		if (list.Count == 0)
		{
			jtRaBhNzyllOIBFGSJvXzEtfCHIb.Clear();
			return;
		}
		int count = list.Count;
		int count2 = jtRaBhNzyllOIBFGSJvXzEtfCHIb.Count;
		TOhoLhSgVsNthvwMxYIJmahKNXwF[] array = new TOhoLhSgVsNthvwMxYIJmahKNXwF[count];
		for (int j = 0; j < count; j++)
		{
			bool flag = false;
			for (int k = 0; k < count2; k++)
			{
				if (list[j] != null && jtRaBhNzyllOIBFGSJvXzEtfCHIb[k] != null && list[j].HUCcYDKLAaTdukQocacUWZZckgSK == jtRaBhNzyllOIBFGSJvXzEtfCHIb[k].HUCcYDKLAaTdukQocacUWZZckgSK)
				{
					array[j] = jtRaBhNzyllOIBFGSJvXzEtfCHIb[k];
					array[j].LBqNqFVAfwHHxCJKeFDwMjDSrkReb(list[j]);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				array[j] = list[j];
			}
		}
		jtRaBhNzyllOIBFGSJvXzEtfCHIb.Clear();
		for (int l = 0; l < count; l++)
		{
			if (array[l] != null)
			{
				jtRaBhNzyllOIBFGSJvXzEtfCHIb.Add(array[l]);
			}
		}
	}

	private void bicDebnynkOICluCDNaHUDiNEbIB()
	{
		if (HugbbdCANSaPiMStdtIDsjikjKsF)
		{
			sojtvziaZjMnBfbkITLzhXvIQHHl = true;
		}
		if (this.GhGBgWzXHdccOcRyNnpQaOycaJaIB != null)
		{
			this.GhGBgWzXHdccOcRyNnpQaOycaJaIB();
		}
	}

	private int lPiDDLaAikpJqeVdqmXBLdvfcdHxA()
	{
		int buUEODiQOvdcYlqdKhvDavucvYsx = BuUEODiQOvdcYlqdKhvDavucvYsx;
		if (BuUEODiQOvdcYlqdKhvDavucvYsx == int.MaxValue)
		{
			BuUEODiQOvdcYlqdKhvDavucvYsx = 0;
			return buUEODiQOvdcYlqdKhvDavucvYsx;
		}
		BuUEODiQOvdcYlqdKhvDavucvYsx++;
		return buUEODiQOvdcYlqdKhvDavucvYsx;
	}

	private void augOxcCKwSDqnrmHZJzZwFFnnAOp(bool P_0)
	{
		if (HugbbdCANSaPiMStdtIDsjikjKsF && P_0)
		{
			lGtGxFsCvAAvywVyMJSGFLNliDUz = true;
		}
	}

	public void Dispose()
	{
		ojFgEBFlOuAEURyZVBUvjFWCsDsS(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void IsNTxaSwWlsiuSAWhgbkesWAXzXj()
	{
		try
		{
			ojFgEBFlOuAEURyZVBUvjFWCsDsS(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void ojFgEBFlOuAEURyZVBUvjFWCsDsS(bool P_0)
	{
		if (AzeLsnqBqDAXTbzmBtJQNeEkkmQdA)
		{
			return;
		}
		if (P_0)
		{
			ReInput.ApplicationFocusChangedEvent -= augOxcCKwSDqnrmHZJzZwFFnnAOp;
			if (DkcADtAPMUsPSvKJBvfthcBmbrmeb != null)
			{
				DkcADtAPMUsPSvKJBvfthcBmbrmeb.Dispose();
			}
			if (jtRaBhNzyllOIBFGSJvXzEtfCHIb != null)
			{
				for (int i = 0; i < jtRaBhNzyllOIBFGSJvXzEtfCHIb.Count; i++)
				{
					if (jtRaBhNzyllOIBFGSJvXzEtfCHIb[i] != null)
					{
						jtRaBhNzyllOIBFGSJvXzEtfCHIb[i].Dispose();
					}
				}
			}
		}
		AzeLsnqBqDAXTbzmBtJQNeEkkmQdA = true;
	}
}
