using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired;
using Rewired.Data;
using Rewired.Interfaces;

internal class COdWbKJboNyalVwwCcRxsmbVOwLg : IInputSource, IDisposable
{
	private static mMRnaCZByBQHZrOOfOAEzqjppACA qxKxcPsdNNwjctECUYrzCudDNoOX;

	private List<sFFXXFtEebhJcIFEaMaPQTQrWwKC> CdLTslmCktBYggxMTJRzDHyGPsxG;

	private ReadOnlyCollection<sFFXXFtEebhJcIFEaMaPQTQrWwKC> kvPIbwRcYaJjRhYGQsidZaiKMMKV;

	private ConfigVars FVGDFMRJRTTBFoEwbegtQdnPDJRGA;

	private readonly bool aCEgTvyMRIESdFTgKbVKhWBhkOY;

	private readonly bool hojHPjYkYalYfMPUHJTQmJoYxvBy;

	private readonly bool xnuRcNEYVIXjDPCNCIaejmaqeaZb;

	private bool JBkOFhFAAkebQIrxXXhMNTNjLjGc;

	[CompilerGenerated]
	private Action m_dAoyRaIRYkeCcySrICfQqrQVCGEP;

	private readonly bool rhbZAOtOVyXXHPNqJqXzlLSzHXFN;

	private readonly bool hcWxvKRdymMJyXlEleUHpMAcyYeH;

	private readonly bool kAKBlfGLzYdCdInSFuBEwoMtarZpA;

	private bool OIxkUuFYffrrbOJPiUQFjFqucChhA;

	private double NpwEwVOGYTGpUiSZCSasgozsFjZkA;

	private int yDmqhfNRDgGSoAKwDItRDTOLhBSr;

	private bool ObBlihBhoHhLKTOhBwUEptvAMWep;

	private static readonly string DlMdCKruPMFMjvwoOaYtXVsmQDmb = "Rewired Windows Gaming Input support is not available on this system.";

	private bool tsGKRHXmpUenjAOtKpXCzImZQzumA;

	public IUnifiedKeyboardSource kPXEUcVnRKaQfmvocyDgXjGcIPzhA => null;

	public IUnifiedMouseSource xMavyVSGxghOGurJiLaqOgbCbJzGA => null;

	private event Action dAoyRaIRYkeCcySrICfQqrQVCGEP
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_dAoyRaIRYkeCcySrICfQqrQVCGEP;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_dAoyRaIRYkeCcySrICfQqrQVCGEP, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_dAoyRaIRYkeCcySrICfQqrQVCGEP;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_dAoyRaIRYkeCcySrICfQqrQVCGEP, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	event Action IInputSource.DeviceChangedEvent
	{
		add
		{
			dAoyRaIRYkeCcySrICfQqrQVCGEP += value;
		}
		remove
		{
			dAoyRaIRYkeCcySrICfQqrQVCGEP -= value;
		}
	}

	public COdWbKJboNyalVwwCcRxsmbVOwLg(ConfigVars P_0, bool P_1, bool P_2, bool P_3)
	{
		try
		{
			FVGDFMRJRTTBFoEwbegtQdnPDJRGA = P_0;
			aCEgTvyMRIESdFTgKbVKhWBhkOY = P_1;
			hojHPjYkYalYfMPUHJTQmJoYxvBy = P_2;
			xnuRcNEYVIXjDPCNCIaejmaqeaZb = P_3;
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
				if (!CujeeBcirxyINwnVbhnsGACTyjMg.TOkwcrYyokTNXNjCeYCILPQAZfxS())
				{
					Logger.LogWarning(DlMdCKruPMFMjvwoOaYtXVsmQDmb + " Requires " + CujeeBcirxyINwnVbhnsGACTyjMg.fjDdXhOkKYFwYJqjCqDwPIJieSsS() + " or greater.");
					throw new Exception();
				}
			}
			catch (DllNotFoundException)
			{
				Logger.LogWarning(DlMdCKruPMFMjvwoOaYtXVsmQDmb + " Either Rewired_WindowsGamingInput.dll is missing or this version of Windows does not meet the minimum version requirements for Windows Gaming Input support.");
				throw new Exception();
			}
			catch
			{
				Logger.LogWarning(DlMdCKruPMFMjvwoOaYtXVsmQDmb);
				throw new Exception();
			}
			rhbZAOtOVyXXHPNqJqXzlLSzHXFN = true;
			if (kAKBlfGLzYdCdInSFuBEwoMtarZpA)
			{
				hcWxvKRdymMJyXlEleUHpMAcyYeH = false;
			}
			if (rhbZAOtOVyXXHPNqJqXzlLSzHXFN)
			{
				qxKxcPsdNNwjctECUYrzCudDNoOX = new mMRnaCZByBQHZrOOfOAEzqjppACA(GyOXcpbCfpsvIgbetgNNCLNIzmrEA);
			}
			CdLTslmCktBYggxMTJRzDHyGPsxG = new List<sFFXXFtEebhJcIFEaMaPQTQrWwKC>();
			kvPIbwRcYaJjRhYGQsidZaiKMMKV = new ReadOnlyCollection<sFFXXFtEebhJcIFEaMaPQTQrWwKC>(CdLTslmCktBYggxMTJRzDHyGPsxG);
			if (rhbZAOtOVyXXHPNqJqXzlLSzHXFN)
			{
				qxKxcPsdNNwjctECUYrzCudDNoOX.JpkqnXiIouVWpWmZZNWYMQVTIhtp += GhUcPYOaleyeuGbzVHniwgjwRTJK;
			}
			if (P_1)
			{
				kERRcXkNjGQsWGULJAqFbQeeDcTm(true);
			}
			ReInput.ApplicationFocusChangedEvent += PkUDYIrzbHGoBQsAOpQNCEdYFfaK;
		}
		catch (Exception)
		{
			Dispose();
			throw;
		}
	}

	public void XdfPSlIpInCXIHZJkyXCMBJMiYBhA()
	{
		JBkOFhFAAkebQIrxXXhMNTNjLjGc = false;
		kERRcXkNjGQsWGULJAqFbQeeDcTm(false);
	}

	public bool MAlcKvVRgeKdtylhjFTgebIzhvHu(PidVid P_0)
	{
		if (rhbZAOtOVyXXHPNqJqXzlLSzHXFN && jPxdIFDnOkTonljyRaQphHTzlDNB.jAKGKLVEsaEtWaMSOqYiDubYRsCZ(P_0.vendorId, P_0.productId))
		{
			return true;
		}
		return false;
	}

	public void SystemDeviceDisconnected()
	{
		GhUcPYOaleyeuGbzVHniwgjwRTJK();
	}

	void IInputSource.SystemDeviceDisconnected()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceDisconnected
		this.SystemDeviceDisconnected();
	}

	public void SystemDeviceConnected()
	{
		GhUcPYOaleyeuGbzVHniwgjwRTJK();
	}

	void IInputSource.SystemDeviceConnected()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceConnected
		this.SystemDeviceConnected();
	}

	public void Update()
	{
		if (ObBlihBhoHhLKTOhBwUEptvAMWep)
		{
			GhUcPYOaleyeuGbzVHniwgjwRTJK();
		}
		if (rhbZAOtOVyXXHPNqJqXzlLSzHXFN)
		{
			qxKxcPsdNNwjctECUYrzCudDNoOX.hxsbCTVTVmnLJPiomImCFyiMbphY();
		}
	}

	void IInputSource.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void UpdateDevices(UpdateLoopType updateLoop)
	{
		if (aCEgTvyMRIESdFTgKbVKhWBhkOY)
		{
			for (int i = 0; i < CdLTslmCktBYggxMTJRzDHyGPsxG.Count; i++)
			{
				CdLTslmCktBYggxMTJRzDHyGPsxG[i]?.ZMHOwCOpmODxTECrwVDbYvKvnlYo(updateLoop);
			}
			if (rhbZAOtOVyXXHPNqJqXzlLSzHXFN)
			{
				qxKxcPsdNNwjctECUYrzCudDNoOX.vjvabnzAeTzquyxILLrQrCZkHpQ();
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
		for (int i = 0; i < CdLTslmCktBYggxMTJRzDHyGPsxG.Count; i++)
		{
			CdLTslmCktBYggxMTJRzDHyGPsxG[i]?.LbSIWSCwEQNUchOffNZnxsZCBhzJA();
		}
	}

	void IInputSource.UpdateFinished()
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateFinished
		this.UpdateFinished();
	}

	public IList<T> GetJoysticks<T>() where T : class
	{
		return kvPIbwRcYaJjRhYGQsidZaiKMMKV as IList<T>;
	}

	IList<T> IInputSource.GetJoysticks<T>()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetJoysticks
		return this.GetJoysticks<T>();
	}

	private void kERRcXkNjGQsWGULJAqFbQeeDcTm(bool P_0)
	{
		if (ObBlihBhoHhLKTOhBwUEptvAMWep)
		{
			ObBlihBhoHhLKTOhBwUEptvAMWep = false;
		}
		List<sFFXXFtEebhJcIFEaMaPQTQrWwKC> list = new List<sFFXXFtEebhJcIFEaMaPQTQrWwKC>();
		int num = 0;
		if (rhbZAOtOVyXXHPNqJqXzlLSzHXFN)
		{
			IList<IUicmISErEcjrpTynhPRVCoDnMAQ> list2 = qxKxcPsdNNwjctECUYrzCudDNoOX.uhpSHNjkldxjeyXPOjdTQFkwLbCx();
			for (int i = 0; i < list2.Count; i++)
			{
				IUicmISErEcjrpTynhPRVCoDnMAQ uicmISErEcjrpTynhPRVCoDnMAQ = list2[i];
				if (uicmISErEcjrpTynhPRVCoDnMAQ != null)
				{
					list.Add(uicmISErEcjrpTynhPRVCoDnMAQ);
					num++;
				}
			}
		}
		if (list.Count == 0)
		{
			CdLTslmCktBYggxMTJRzDHyGPsxG.Clear();
			return;
		}
		int count = list.Count;
		int count2 = CdLTslmCktBYggxMTJRzDHyGPsxG.Count;
		sFFXXFtEebhJcIFEaMaPQTQrWwKC[] array = new sFFXXFtEebhJcIFEaMaPQTQrWwKC[count];
		for (int j = 0; j < count; j++)
		{
			bool flag = false;
			for (int k = 0; k < count2; k++)
			{
				if (list[j] != null && CdLTslmCktBYggxMTJRzDHyGPsxG[k] != null && list[j].iNcbXhrkRtshEZzrzCiIatjPlhwT == CdLTslmCktBYggxMTJRzDHyGPsxG[k].iNcbXhrkRtshEZzrzCiIatjPlhwT)
				{
					array[j] = CdLTslmCktBYggxMTJRzDHyGPsxG[k];
					array[j].oqOJPpgmezzzXoVThFUcBCzrjQrg(list[j]);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				array[j] = list[j];
			}
		}
		CdLTslmCktBYggxMTJRzDHyGPsxG.Clear();
		for (int l = 0; l < count; l++)
		{
			if (array[l] != null)
			{
				CdLTslmCktBYggxMTJRzDHyGPsxG.Add(array[l]);
			}
		}
	}

	private void GhUcPYOaleyeuGbzVHniwgjwRTJK()
	{
		if (aCEgTvyMRIESdFTgKbVKhWBhkOY)
		{
			JBkOFhFAAkebQIrxXXhMNTNjLjGc = true;
		}
		if (this.dAoyRaIRYkeCcySrICfQqrQVCGEP != null)
		{
			this.dAoyRaIRYkeCcySrICfQqrQVCGEP();
		}
	}

	private int GyOXcpbCfpsvIgbetgNNCLNIzmrEA()
	{
		int result = yDmqhfNRDgGSoAKwDItRDTOLhBSr;
		if (yDmqhfNRDgGSoAKwDItRDTOLhBSr == int.MaxValue)
		{
			yDmqhfNRDgGSoAKwDItRDTOLhBSr = 0;
			return result;
		}
		yDmqhfNRDgGSoAKwDItRDTOLhBSr++;
		return result;
	}

	private void PkUDYIrzbHGoBQsAOpQNCEdYFfaK(bool P_0)
	{
		if (aCEgTvyMRIESdFTgKbVKhWBhkOY && P_0)
		{
			ObBlihBhoHhLKTOhBwUEptvAMWep = true;
		}
	}

	public void Dispose()
	{
		PBzTdlawZvGcgmrOQeEdTnyfBKUo(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void hcbCgIxUrcoWEngHydgqbWmdGWzOA()
	{
		try
		{
			PBzTdlawZvGcgmrOQeEdTnyfBKUo(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void PBzTdlawZvGcgmrOQeEdTnyfBKUo(bool P_0)
	{
		if (tsGKRHXmpUenjAOtKpXCzImZQzumA)
		{
			return;
		}
		if (P_0)
		{
			ReInput.ApplicationFocusChangedEvent -= PkUDYIrzbHGoBQsAOpQNCEdYFfaK;
			if (qxKxcPsdNNwjctECUYrzCudDNoOX != null)
			{
				qxKxcPsdNNwjctECUYrzCudDNoOX.Dispose();
			}
			if (CdLTslmCktBYggxMTJRzDHyGPsxG != null)
			{
				for (int i = 0; i < CdLTslmCktBYggxMTJRzDHyGPsxG.Count; i++)
				{
					if (CdLTslmCktBYggxMTJRzDHyGPsxG[i] != null)
					{
						CdLTslmCktBYggxMTJRzDHyGPsxG[i].Dispose();
					}
				}
			}
		}
		tsGKRHXmpUenjAOtKpXCzImZQzumA = true;
	}
}
