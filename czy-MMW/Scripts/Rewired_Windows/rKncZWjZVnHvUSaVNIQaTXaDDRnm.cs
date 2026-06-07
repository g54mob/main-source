using System;
using System.Threading;
using Rewired;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class rKncZWjZVnHvUSaVNIQaTXaDDRnm : IDisposable
{
	private enum FKquuLufGkgNOffFAWqIqbwDEBct
	{
		Idle = 0,
		Waiting = 1,
		ErrorPending = 2,
		FinishedError = 3,
		SuccessPending = 4,
		FinishedSuccess = 5
	}

	public enum MAYBLejVoAYEMfgKvpnVbKGjcFEfb
	{
		Idle = 0,
		Success = 1,
		Error = 2,
		Waiting = 3,
		CriticalError = 4
	}

	private readonly string IRufcPjoPeQztyFTKYZspRiSKrJw;

	private IntPtr wuFrJfnbYtMvSmzxPftcbrYnaZKDA = fAunNklVkNVYXHmNViKtxTcpaNJX.MgbcoOgqxQTRwjHLAlsQJiuQaFOw;

	private readonly NativeBuffer sypAbEgmizKHPBllffncYGfoAHbu;

	private readonly int RWwZjGHVjCBLBdYqCheujvWyjoar;

	private readonly fAunNklVkNVYXHmNViKtxTcpaNJX.KUxZhxoTtfEvMTbTQLulhyjRQHzD QbgeAanSxDdIHCyfIBkKOsgrJZjAb;

	private readonly object GjwCzLCjkCtVDrUycNkdCupYHCPA;

	private readonly object zeDAynYCjEFraxVffDJMJELfSilBA;

	private readonly uint IGZJNzGTXrNftmouvsaVDULmnFKR;

	private NativeOverlapped VBfMjcuqoJjGQrRScPAaQESifRkh;

	private FKquuLufGkgNOffFAWqIqbwDEBct DlFFhUiOFkQFHEaMIQoNymsvstKcA;

	private int FXWWCOLrPXqnmGEIHMeNGREJrLBU;

	private bool ecXnsDAUozihgCiwRCcRWtsmeSuL;

	private int AQoLXbJVEfTFgAxxrmHCpjluesgR;

	private int gJTrctwicfjgmHtsupDpsohQJHoAb;

	public readonly int TSjtwPULFbuLcoYKSqgVdoSaczfM;

	private bool hSrSlWggAsAZeIiKhUnZUPgscYTgA;

	private bool xZjamVJpcoWudyYiLpdSQROaaSRF => UGgQLjvmeopnQGcfVJPQeoBwAGKHA.ejTSXrLFZyjUILmCkDftbRvvokQOA(IRufcPjoPeQztyFTKYZspRiSKrJw);

	public rKncZWjZVnHvUSaVNIQaTXaDDRnm(string P_0, int P_1, int P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("devicePath");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("reportLength must be > 0");
		}
		IGZJNzGTXrNftmouvsaVDULmnFKR = ObjectInstanceTracker.Default.Register(this);
		IRufcPjoPeQztyFTKYZspRiSKrJw = P_0;
		if (!jsKekgoaWODFmdQjZydawBplqClkA())
		{
			throw new Exception("Could not open HID device.");
		}
		RWwZjGHVjCBLBdYqCheujvWyjoar = P_1;
		TSjtwPULFbuLcoYKSqgVdoSaczfM = P_1 + 8;
		sypAbEgmizKHPBllffncYGfoAHbu = new NativeBuffer(TSjtwPULFbuLcoYKSqgVdoSaczfM);
		VBfMjcuqoJjGQrRScPAaQESifRkh = default(NativeOverlapped);
		DlFFhUiOFkQFHEaMIQoNymsvstKcA = FKquuLufGkgNOffFAWqIqbwDEBct.Idle;
		FXWWCOLrPXqnmGEIHMeNGREJrLBU = ((P_2 < 0) ? 65535 : P_2);
		GjwCzLCjkCtVDrUycNkdCupYHCPA = new object();
		zeDAynYCjEFraxVffDJMJELfSilBA = new object();
		QbgeAanSxDdIHCyfIBkKOsgrJZjAb = FuvxrnLqKdtSWCOmIKixtgrDSCQx;
		DvrvpYFMidcDYtOtKKjOrPLkQdIx(VBfMjcuqoJjGQrRScPAaQESifRkh);
	}

	public MAYBLejVoAYEMfgKvpnVbKGjcFEfb CBLtzOfRynOhSZMJLmHAUhcMjHxJ(byte[] P_0)
	{
		lock (zeDAynYCjEFraxVffDJMJELfSilBA)
		{
			if (hSrSlWggAsAZeIiKhUnZUPgscYTgA)
			{
				return MAYBLejVoAYEMfgKvpnVbKGjcFEfb.CriticalError;
			}
			if (!YhdFlkTgCdQjXXQOlBXbuWoALcpP())
			{
				return (gJTrctwicfjgmHtsupDpsohQJHoAb >= 10) ? MAYBLejVoAYEMfgKvpnVbKGjcFEfb.CriticalError : MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Error;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (P_0.Length < TSjtwPULFbuLcoYKSqgVdoSaczfM)
			{
				int tSjtwPULFbuLcoYKSqgVdoSaczfM = TSjtwPULFbuLcoYKSqgVdoSaczfM;
				throw new Exception("buffer must be at least " + tSjtwPULFbuLcoYKSqgVdoSaczfM + " bytes");
			}
			switch (DlFFhUiOFkQFHEaMIQoNymsvstKcA)
			{
			case FKquuLufGkgNOffFAWqIqbwDEBct.Idle:
				mLqhGNRqvRNJeofMFRYOIjnSUgwW();
				break;
			case FKquuLufGkgNOffFAWqIqbwDEBct.Waiting:
				EUaUesGfhwQsfgLIFJnQAjolkzrh();
				break;
			case FKquuLufGkgNOffFAWqIqbwDEBct.ErrorPending:
				VogDjCHYYafOAKCfvCRGUhFQmANB();
				break;
			case FKquuLufGkgNOffFAWqIqbwDEBct.SuccessPending:
				vJRXWvMKqejZhvkkOuoVUkjOBhee();
				break;
			}
			switch (DlFFhUiOFkQFHEaMIQoNymsvstKcA)
			{
			case FKquuLufGkgNOffFAWqIqbwDEBct.Idle:
				return MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Idle;
			case FKquuLufGkgNOffFAWqIqbwDEBct.Waiting:
			case FKquuLufGkgNOffFAWqIqbwDEBct.ErrorPending:
			case FKquuLufGkgNOffFAWqIqbwDEBct.SuccessPending:
				return MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Waiting;
			case FKquuLufGkgNOffFAWqIqbwDEBct.FinishedSuccess:
				sypAbEgmizKHPBllffncYGfoAHbu.TryReadBytes(P_0, TSjtwPULFbuLcoYKSqgVdoSaczfM);
				DlFFhUiOFkQFHEaMIQoNymsvstKcA = FKquuLufGkgNOffFAWqIqbwDEBct.Idle;
				return MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Success;
			case FKquuLufGkgNOffFAWqIqbwDEBct.FinishedError:
				DlFFhUiOFkQFHEaMIQoNymsvstKcA = FKquuLufGkgNOffFAWqIqbwDEBct.Idle;
				return MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Error;
			default:
				throw new NotImplementedException();
			}
		}
	}

	private bool mLqhGNRqvRNJeofMFRYOIjnSUgwW()
	{
		if (DlFFhUiOFkQFHEaMIQoNymsvstKcA != FKquuLufGkgNOffFAWqIqbwDEBct.Idle)
		{
			int dlFFhUiOFkQFHEaMIQoNymsvstKcA = (int)DlFFhUiOFkQFHEaMIQoNymsvstKcA;
			throw new Exception("Cannot StartRead from this state. State = " + dlFFhUiOFkQFHEaMIQoNymsvstKcA);
		}
		try
		{
			PlyELOuJabiWoNlWECFIvNrfgIkQ();
			lock (GjwCzLCjkCtVDrUycNkdCupYHCPA)
			{
				bool num = fAunNklVkNVYXHmNViKtxTcpaNJX.RTwHsUIjzOZWVbVddQMaiLYHZcgc(wuFrJfnbYtMvSmzxPftcbrYnaZKDA, sypAbEgmizKHPBllffncYGfoAHbu, (uint)RWwZjGHVjCBLBdYqCheujvWyjoar, ref VBfMjcuqoJjGQrRScPAaQESifRkh, QbgeAanSxDdIHCyfIBkKOsgrJZjAb);
				if (num)
				{
					DlFFhUiOFkQFHEaMIQoNymsvstKcA = FKquuLufGkgNOffFAWqIqbwDEBct.Waiting;
					ecXnsDAUozihgCiwRCcRWtsmeSuL = true;
				}
				else
				{
					sViNCCwvdVSMzDIMSHRQbiaAqkdTA();
				}
				return num;
			}
		}
		catch (Exception)
		{
			sViNCCwvdVSMzDIMSHRQbiaAqkdTA();
			return false;
		}
	}

	private void EUaUesGfhwQsfgLIFJnQAjolkzrh()
	{
		if (DlFFhUiOFkQFHEaMIQoNymsvstKcA != FKquuLufGkgNOffFAWqIqbwDEBct.Waiting)
		{
			int dlFFhUiOFkQFHEaMIQoNymsvstKcA = (int)DlFFhUiOFkQFHEaMIQoNymsvstKcA;
			throw new Exception("Cannot CheckReadStatus from this state. State = " + dlFFhUiOFkQFHEaMIQoNymsvstKcA);
		}
		switch (CVzYiSmnagrrhPDFOeiyETjyupdr())
		{
		case MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Error:
			sViNCCwvdVSMzDIMSHRQbiaAqkdTA();
			break;
		case MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Success:
			ZaAqNbajLLBWiafEQShkdrqwSPoeb();
			break;
		case MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Waiting:
			break;
		}
	}

	private MAYBLejVoAYEMfgKvpnVbKGjcFEfb CVzYiSmnagrrhPDFOeiyETjyupdr()
	{
		if (DlFFhUiOFkQFHEaMIQoNymsvstKcA != FKquuLufGkgNOffFAWqIqbwDEBct.Waiting)
		{
			return MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Error;
		}
		try
		{
			switch (fAunNklVkNVYXHmNViKtxTcpaNJX.GPPIpepaVjeiUiGgfFUFGkKPjfolA(FXWWCOLrPXqnmGEIHMeNGREJrLBU, true))
			{
			case 0u:
				return MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Waiting;
			case 192u:
			{
				if (!fAunNklVkNVYXHmNViKtxTcpaNJX.WIUxTRLsnUXyXDgkqScCOiAJhXhP(wuFrJfnbYtMvSmzxPftcbrYnaZKDA, ref VBfMjcuqoJjGQrRScPAaQESifRkh, out var num, false))
				{
					return MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Error;
				}
				return (num > 0) ? MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Success : MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Error;
			}
			case uint.MaxValue:
			case 128u:
			case 258u:
				return MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Waiting;
			default:
				return MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Error;
			}
		}
		catch
		{
			return MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Error;
		}
	}

	private void sViNCCwvdVSMzDIMSHRQbiaAqkdTA()
	{
		DlFFhUiOFkQFHEaMIQoNymsvstKcA = FKquuLufGkgNOffFAWqIqbwDEBct.ErrorPending;
		VogDjCHYYafOAKCfvCRGUhFQmANB();
	}

	private void VogDjCHYYafOAKCfvCRGUhFQmANB()
	{
		if (DlFFhUiOFkQFHEaMIQoNymsvstKcA != FKquuLufGkgNOffFAWqIqbwDEBct.ErrorPending)
		{
			int dlFFhUiOFkQFHEaMIQoNymsvstKcA = (int)DlFFhUiOFkQFHEaMIQoNymsvstKcA;
			throw new Exception("Cannot CheckErrorFinished from this state. State = " + dlFFhUiOFkQFHEaMIQoNymsvstKcA);
		}
		DlFFhUiOFkQFHEaMIQoNymsvstKcA = FKquuLufGkgNOffFAWqIqbwDEBct.FinishedError;
	}

	private void ZaAqNbajLLBWiafEQShkdrqwSPoeb()
	{
		DlFFhUiOFkQFHEaMIQoNymsvstKcA = FKquuLufGkgNOffFAWqIqbwDEBct.SuccessPending;
		vJRXWvMKqejZhvkkOuoVUkjOBhee();
	}

	private void vJRXWvMKqejZhvkkOuoVUkjOBhee()
	{
		if (DlFFhUiOFkQFHEaMIQoNymsvstKcA != FKquuLufGkgNOffFAWqIqbwDEBct.SuccessPending)
		{
			int dlFFhUiOFkQFHEaMIQoNymsvstKcA = (int)DlFFhUiOFkQFHEaMIQoNymsvstKcA;
			throw new Exception("Cannot CheckSuccessFinished from this state. State = " + dlFFhUiOFkQFHEaMIQoNymsvstKcA);
		}
		DlFFhUiOFkQFHEaMIQoNymsvstKcA = FKquuLufGkgNOffFAWqIqbwDEBct.FinishedSuccess;
		sypAbEgmizKHPBllffncYGfoAHbu.Write(ReInput.realTime, RWwZjGHVjCBLBdYqCheujvWyjoar);
	}

	private void PlyELOuJabiWoNlWECFIvNrfgIkQ()
	{
		DvrvpYFMidcDYtOtKKjOrPLkQdIx(VBfMjcuqoJjGQrRScPAaQESifRkh);
		sypAbEgmizKHPBllffncYGfoAHbu.Clear();
		AQoLXbJVEfTFgAxxrmHCpjluesgR = 0;
		ecXnsDAUozihgCiwRCcRWtsmeSuL = false;
	}

	private void DvrvpYFMidcDYtOtKKjOrPLkQdIx(NativeOverlapped P_0)
	{
		P_0.EventHandle = new IntPtr((int)IGZJNzGTXrNftmouvsaVDULmnFKR);
		P_0.InternalHigh = IntPtr.Zero;
		P_0.InternalLow = IntPtr.Zero;
		P_0.OffsetHigh = 0;
		P_0.OffsetLow = 0;
	}

	private bool YhdFlkTgCdQjXXQOlBXbuWoALcpP()
	{
		if (gJTrctwicfjgmHtsupDpsohQJHoAb >= 10)
		{
			return false;
		}
		if (!jsKekgoaWODFmdQjZydawBplqClkA())
		{
			gJTrctwicfjgmHtsupDpsohQJHoAb++;
			return false;
		}
		if (gJTrctwicfjgmHtsupDpsohQJHoAb > 0)
		{
			gJTrctwicfjgmHtsupDpsohQJHoAb = 0;
		}
		return true;
	}

	private bool jsKekgoaWODFmdQjZydawBplqClkA()
	{
		if (wuFrJfnbYtMvSmzxPftcbrYnaZKDA != fAunNklVkNVYXHmNViKtxTcpaNJX.MgbcoOgqxQTRwjHLAlsQJiuQaFOw)
		{
			return true;
		}
		if (!xZjamVJpcoWudyYiLpdSQROaaSRF)
		{
			return false;
		}
		IntPtr intPtr = TaGiqOKwYiENMdhhzxzQRMUlWLgnA.XSWDHjHKWjJGSpeKUsFEjAMpvDpHA(IRufcPjoPeQztyFTKYZspRiSKrJw, BRvZRgaIaGRTbVAcMnrrpnHIBwlm.Overlapped, 3221225472u, KRPRwOAGzKdnjlMGlzppsDAvdDnU.ShareRead | KRPRwOAGzKdnjlMGlzppsDAvdDnU.ShareWrite);
		if (intPtr == fAunNklVkNVYXHmNViKtxTcpaNJX.MgbcoOgqxQTRwjHLAlsQJiuQaFOw)
		{
			return false;
		}
		wuFrJfnbYtMvSmzxPftcbrYnaZKDA = intPtr;
		return true;
	}

	private void ppOYYulfDNMsBaJJgmhRizeeGGyR()
	{
		if (!(wuFrJfnbYtMvSmzxPftcbrYnaZKDA == fAunNklVkNVYXHmNViKtxTcpaNJX.MgbcoOgqxQTRwjHLAlsQJiuQaFOw))
		{
			TaGiqOKwYiENMdhhzxzQRMUlWLgnA.EFwDiwGomPDZEFJEGMeiiUbwMjnM(wuFrJfnbYtMvSmzxPftcbrYnaZKDA);
			wuFrJfnbYtMvSmzxPftcbrYnaZKDA = fAunNklVkNVYXHmNViKtxTcpaNJX.MgbcoOgqxQTRwjHLAlsQJiuQaFOw;
		}
	}

	[MonoPInvokeCallback(typeof(fAunNklVkNVYXHmNViKtxTcpaNJX.KUxZhxoTtfEvMTbTQLulhyjRQHzD))]
	private unsafe static void FuvxrnLqKdtSWCOmIKixtgrDSCQx(int P_0, int P_1, IntPtr P_2)
	{
		NativeOverlapped* ptr = (NativeOverlapped*)(void*)P_2;
		uint instanceId = (uint)ptr->EventHandle.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<rKncZWjZVnHvUSaVNIQaTXaDDRnm>(instanceId, out var instance))
		{
			return;
		}
		lock (instance.GjwCzLCjkCtVDrUycNkdCupYHCPA)
		{
			instance.AQoLXbJVEfTFgAxxrmHCpjluesgR = P_0;
			instance.ecXnsDAUozihgCiwRCcRWtsmeSuL = false;
		}
	}

	public void Dispose()
	{
		jejSwPwFWjrllPhTTQbSmyCvLMPh(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void pxBPLifGqilZINKTfYpeIfgzbVoO()
	{
		try
		{
			jejSwPwFWjrllPhTTQbSmyCvLMPh(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void jejSwPwFWjrllPhTTQbSmyCvLMPh(bool P_0)
	{
		if (hSrSlWggAsAZeIiKhUnZUPgscYTgA)
		{
			return;
		}
		using (new Locker(zeDAynYCjEFraxVffDJMJELfSilBA))
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(IGZJNzGTXrNftmouvsaVDULmnFKR);
			}
			ppOYYulfDNMsBaJJgmhRizeeGGyR();
			hSrSlWggAsAZeIiKhUnZUPgscYTgA = true;
		}
	}
}
