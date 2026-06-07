using System;
using System.Diagnostics;
using Rewired;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class nnYVActHyYBSThdgoLUrqHycacvi : IDisposable
{
	private enum LYDapponDVmVpQsYxHJyLkNiiuOb
	{
		Idle = 0,
		Waiting = 1,
		ErrorPending = 2,
		FinishedError = 3,
		SuccessPending = 4,
		FinishedSuccess = 5
	}

	public enum GZlFTCHmVxbAXaLxEQyIUjUKzmGCA
	{
		Idle = 0,
		Success = 1,
		Error = 2,
		Waiting = 3,
		CriticalError = 4
	}

	public const int eetiWBHYFdPDxEGycnDUSOMwFREH = 8;

	private const int PRwnVbyqxkkAVWJyJEZSvCUszOuI = 10;

	private readonly string MkPouzyXuDrfyPgarOMlETkjOILN;

	private IntPtr ilaDRXBjpIjdHmPUwPyhaYWHGuExb = rbLhFKixDkgASAwyfqBoqMqgWggFC.EEWuOauAobBDlKqMznNNkaDveGYD;

	private readonly NativeBuffer wWQIDsiHVISTQoYPUqDxtdvXoeje;

	private readonly int DRFNziRYIjTbAKOJhpxvERMVNTcI;

	private readonly rbLhFKixDkgASAwyfqBoqMqgWggFC.QPGHEPgTyQGDciVClCVxOorgbFdf IVTOMQlAqsCjGFMGhpBRHbcOkilm;

	private readonly object tskqSZKCInzflSCQGIMHbcFCFHlV;

	private readonly uint GIkTHJCesCbzmXNXKctGaqJDnoKDb;

	private global::fviBsPibnZIXPweFTnYyOGgPmdAKA<rbLhFKixDkgASAwyfqBoqMqgWggFC.vCvDqNaTBflsyTvCGTXemeSVSCtM> ZiCSgYckJehlPUwWBGcbjhUDGreI;

	private LYDapponDVmVpQsYxHJyLkNiiuOb LEwLdeOwoVwTQZtdxPbABesUBIMFA;

	private int ZqrFWqDVscfpjxQxuCtKjEKyGmZCA;

	private bool yobfbEqPQKqxfFJkMjKnemNdToz;

	private int SXZCBPKXdOrVbrvYUajXIKtVJBqfA;

	private int ggebuZhgRMpkvgWPFQKyhDlAfywCB;

	public readonly int RXQGqdYrgYsTbLXrrvzQYnADvAbX;

	private bool dsYGBagAfBPorbavGmfKxXaPrYJG;

	private bool xiCusfPPFFKxkJHkqqhLnSxVJGXe => OPLEcXnXDXrWZrMZuMEHPFiRdVOC.whyIRRPqaTMQHiOzHkugwCbEZLMT(MkPouzyXuDrfyPgarOMlETkjOILN);

	public nnYVActHyYBSThdgoLUrqHycacvi(string P_0, int P_1, int P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("devicePath");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("reportLength must be > 0");
		}
		GIkTHJCesCbzmXNXKctGaqJDnoKDb = ObjectInstanceTracker.Default.Register(this);
		MkPouzyXuDrfyPgarOMlETkjOILN = P_0;
		if (!jUzvaSgUxxPZfjuEoaadannSMdhp())
		{
			throw new Exception("Could not open HID device.");
		}
		DRFNziRYIjTbAKOJhpxvERMVNTcI = P_1;
		RXQGqdYrgYsTbLXrrvzQYnADvAbX = P_1 + 8;
		wWQIDsiHVISTQoYPUqDxtdvXoeje = new NativeBuffer(RXQGqdYrgYsTbLXrrvzQYnADvAbX);
		ZiCSgYckJehlPUwWBGcbjhUDGreI = new global::fviBsPibnZIXPweFTnYyOGgPmdAKA<rbLhFKixDkgASAwyfqBoqMqgWggFC.vCvDqNaTBflsyTvCGTXemeSVSCtM>();
		LEwLdeOwoVwTQZtdxPbABesUBIMFA = LYDapponDVmVpQsYxHJyLkNiiuOb.Idle;
		ZqrFWqDVscfpjxQxuCtKjEKyGmZCA = ((P_2 < 0) ? 65535 : P_2);
		tskqSZKCInzflSCQGIMHbcFCFHlV = new object();
		IVTOMQlAqsCjGFMGhpBRHbcOkilm = smQYJxjCDcEHBGXmShzsoXjMUJKJ;
		CyOtDwCdZydgKMNLJekGeisxZGwiA();
	}

	public GZlFTCHmVxbAXaLxEQyIUjUKzmGCA MXybvyjxwMIQBsQzgZvPzXsboOjv(byte[] P_0)
	{
		lock (tskqSZKCInzflSCQGIMHbcFCFHlV)
		{
			if (dsYGBagAfBPorbavGmfKxXaPrYJG)
			{
				return GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.CriticalError;
			}
			if (!KjSzrKXVhOFxOgErILEgLFqzqFdY())
			{
				return (ggebuZhgRMpkvgWPFQKyhDlAfywCB >= 10) ? GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.CriticalError : GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Error;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (P_0.Length < RXQGqdYrgYsTbLXrrvzQYnADvAbX)
			{
				int rXQGqdYrgYsTbLXrrvzQYnADvAbX = RXQGqdYrgYsTbLXrrvzQYnADvAbX;
				throw new Exception("buffer must be at least " + rXQGqdYrgYsTbLXrrvzQYnADvAbX + " bytes");
			}
			switch (LEwLdeOwoVwTQZtdxPbABesUBIMFA)
			{
			case LYDapponDVmVpQsYxHJyLkNiiuOb.Idle:
				yoBYAnZFWmOBzXbpcWHFrUhlcZkL();
				break;
			case LYDapponDVmVpQsYxHJyLkNiiuOb.Waiting:
				MqPILAWBCPHMaXXtyBQFjIeShNbhA();
				break;
			case LYDapponDVmVpQsYxHJyLkNiiuOb.ErrorPending:
				ZyPVNBBsplxcDbDpKdDMrWvvdJCt();
				break;
			case LYDapponDVmVpQsYxHJyLkNiiuOb.SuccessPending:
				pAudRFKitVgpiEALzmdYjpujpawZB();
				break;
			}
			switch (LEwLdeOwoVwTQZtdxPbABesUBIMFA)
			{
			case LYDapponDVmVpQsYxHJyLkNiiuOb.Idle:
				return GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Idle;
			case LYDapponDVmVpQsYxHJyLkNiiuOb.Waiting:
			case LYDapponDVmVpQsYxHJyLkNiiuOb.ErrorPending:
			case LYDapponDVmVpQsYxHJyLkNiiuOb.SuccessPending:
				return GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Waiting;
			case LYDapponDVmVpQsYxHJyLkNiiuOb.FinishedSuccess:
				wWQIDsiHVISTQoYPUqDxtdvXoeje.TryReadBytes(P_0, RXQGqdYrgYsTbLXrrvzQYnADvAbX);
				LEwLdeOwoVwTQZtdxPbABesUBIMFA = LYDapponDVmVpQsYxHJyLkNiiuOb.Idle;
				return GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Success;
			case LYDapponDVmVpQsYxHJyLkNiiuOb.FinishedError:
				LEwLdeOwoVwTQZtdxPbABesUBIMFA = LYDapponDVmVpQsYxHJyLkNiiuOb.Idle;
				return GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Error;
			default:
				throw new NotImplementedException();
			}
		}
	}

	private bool yoBYAnZFWmOBzXbpcWHFrUhlcZkL()
	{
		if (LEwLdeOwoVwTQZtdxPbABesUBIMFA != LYDapponDVmVpQsYxHJyLkNiiuOb.Idle)
		{
			int lEwLdeOwoVwTQZtdxPbABesUBIMFA = (int)LEwLdeOwoVwTQZtdxPbABesUBIMFA;
			throw new Exception("Cannot StartRead from this state. State = " + lEwLdeOwoVwTQZtdxPbABesUBIMFA);
		}
		try
		{
			PCLYFywRZGEEtiwlbaKFGNdYQfcU();
			bool num = rbLhFKixDkgASAwyfqBoqMqgWggFC.AcuhWKhNiBESpDMVJvGWtTAjQOkKB(ilaDRXBjpIjdHmPUwPyhaYWHGuExb, wWQIDsiHVISTQoYPUqDxtdvXoeje, (uint)DRFNziRYIjTbAKOJhpxvERMVNTcI, GPQlDciUdfdOnXgKBdRMipKfgYXfA.ghwWDZgcaAyQwxhiOEzvUChMhnWV(ZiCSgYckJehlPUwWBGcbjhUDGreI.tZHTTFeJUuMIafBxOHvDpPeWftgs), IVTOMQlAqsCjGFMGhpBRHbcOkilm);
			if (num)
			{
				LEwLdeOwoVwTQZtdxPbABesUBIMFA = LYDapponDVmVpQsYxHJyLkNiiuOb.Waiting;
				yobfbEqPQKqxfFJkMjKnemNdToz = true;
			}
			else
			{
				kwTZIckEYiDWuesjtpWZHLoxgPdNA();
			}
			return num;
		}
		catch (Exception)
		{
			kwTZIckEYiDWuesjtpWZHLoxgPdNA();
			return false;
		}
	}

	private void MqPILAWBCPHMaXXtyBQFjIeShNbhA()
	{
		if (LEwLdeOwoVwTQZtdxPbABesUBIMFA != LYDapponDVmVpQsYxHJyLkNiiuOb.Waiting)
		{
			int lEwLdeOwoVwTQZtdxPbABesUBIMFA = (int)LEwLdeOwoVwTQZtdxPbABesUBIMFA;
			throw new Exception("Cannot CheckReadStatus from this state. State = " + lEwLdeOwoVwTQZtdxPbABesUBIMFA);
		}
		switch (IEOHyieGDJabeqbadLdlfexZJKvU())
		{
		case GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Error:
			kwTZIckEYiDWuesjtpWZHLoxgPdNA();
			break;
		case GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Success:
			FRzZTBksmoAEnCKfbdynkAoDnywab();
			break;
		case GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Waiting:
			break;
		}
	}

	private GZlFTCHmVxbAXaLxEQyIUjUKzmGCA IEOHyieGDJabeqbadLdlfexZJKvU()
	{
		if (LEwLdeOwoVwTQZtdxPbABesUBIMFA != LYDapponDVmVpQsYxHJyLkNiiuOb.Waiting)
		{
			return GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Error;
		}
		try
		{
			switch (rbLhFKixDkgASAwyfqBoqMqgWggFC.YTsQFWhEyUyQFVLXKDXGZVQqCigj(ZqrFWqDVscfpjxQxuCtKjEKyGmZCA, true))
			{
			case 0u:
				return GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Waiting;
			case 192u:
			{
				if (!rbLhFKixDkgASAwyfqBoqMqgWggFC.fEDGbpFJaAZuuwTVPByUkJCNZqwr(ilaDRXBjpIjdHmPUwPyhaYWHGuExb, GPQlDciUdfdOnXgKBdRMipKfgYXfA.ghwWDZgcaAyQwxhiOEzvUChMhnWV(ZiCSgYckJehlPUwWBGcbjhUDGreI.tZHTTFeJUuMIafBxOHvDpPeWftgs), out var num, false))
				{
					return GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Error;
				}
				return (num > 0) ? GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Success : GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Error;
			}
			case uint.MaxValue:
			case 128u:
			case 258u:
				return GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Waiting;
			default:
				return GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Error;
			}
		}
		catch
		{
			return GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Error;
		}
	}

	private void kwTZIckEYiDWuesjtpWZHLoxgPdNA()
	{
		LEwLdeOwoVwTQZtdxPbABesUBIMFA = LYDapponDVmVpQsYxHJyLkNiiuOb.ErrorPending;
		ZyPVNBBsplxcDbDpKdDMrWvvdJCt();
	}

	private void ZyPVNBBsplxcDbDpKdDMrWvvdJCt()
	{
		if (LEwLdeOwoVwTQZtdxPbABesUBIMFA != LYDapponDVmVpQsYxHJyLkNiiuOb.ErrorPending)
		{
			int lEwLdeOwoVwTQZtdxPbABesUBIMFA = (int)LEwLdeOwoVwTQZtdxPbABesUBIMFA;
			throw new Exception("Cannot CheckErrorFinished from this state. State = " + lEwLdeOwoVwTQZtdxPbABesUBIMFA);
		}
		LEwLdeOwoVwTQZtdxPbABesUBIMFA = LYDapponDVmVpQsYxHJyLkNiiuOb.FinishedError;
	}

	private void FRzZTBksmoAEnCKfbdynkAoDnywab()
	{
		LEwLdeOwoVwTQZtdxPbABesUBIMFA = LYDapponDVmVpQsYxHJyLkNiiuOb.SuccessPending;
		pAudRFKitVgpiEALzmdYjpujpawZB();
	}

	private void pAudRFKitVgpiEALzmdYjpujpawZB()
	{
		if (LEwLdeOwoVwTQZtdxPbABesUBIMFA != LYDapponDVmVpQsYxHJyLkNiiuOb.SuccessPending)
		{
			int lEwLdeOwoVwTQZtdxPbABesUBIMFA = (int)LEwLdeOwoVwTQZtdxPbABesUBIMFA;
			throw new Exception("Cannot CheckSuccessFinished from this state. State = " + lEwLdeOwoVwTQZtdxPbABesUBIMFA);
		}
		LEwLdeOwoVwTQZtdxPbABesUBIMFA = LYDapponDVmVpQsYxHJyLkNiiuOb.FinishedSuccess;
		wWQIDsiHVISTQoYPUqDxtdvXoeje.Write(ReInput.realTime, DRFNziRYIjTbAKOJhpxvERMVNTcI);
	}

	private void PCLYFywRZGEEtiwlbaKFGNdYQfcU()
	{
		CyOtDwCdZydgKMNLJekGeisxZGwiA();
		wWQIDsiHVISTQoYPUqDxtdvXoeje.Clear();
		SXZCBPKXdOrVbrvYUajXIKtVJBqfA = 0;
		yobfbEqPQKqxfFJkMjKnemNdToz = false;
	}

	private void CyOtDwCdZydgKMNLJekGeisxZGwiA()
	{
		rbLhFKixDkgASAwyfqBoqMqgWggFC.vCvDqNaTBflsyTvCGTXemeSVSCtM vCvDqNaTBflsyTvCGTXemeSVSCtM = default(rbLhFKixDkgASAwyfqBoqMqgWggFC.vCvDqNaTBflsyTvCGTXemeSVSCtM);
		vCvDqNaTBflsyTvCGTXemeSVSCtM.qmsiWTFCmsclscpcKXSfEaHEJWyab = new IntPtr((int)GIkTHJCesCbzmXNXKctGaqJDnoKDb);
		vCvDqNaTBflsyTvCGTXemeSVSCtM.KgCAUXmqWItnzMaATRpmFLViBmTx = IntPtr.Zero;
		vCvDqNaTBflsyTvCGTXemeSVSCtM.QeUKKfdvNJmAwzWguVidYOqThmAq = IntPtr.Zero;
		vCvDqNaTBflsyTvCGTXemeSVSCtM.dMKrAHDcEueAtGoHUDDAgRwcXSvtb = 0;
		vCvDqNaTBflsyTvCGTXemeSVSCtM.ksqMeQsOpRyTRBWevONEdwUxELvj = 0;
		ZiCSgYckJehlPUwWBGcbjhUDGreI.DQhGuHkiLPiepdDMdWxlcsNDMVLKA = vCvDqNaTBflsyTvCGTXemeSVSCtM;
	}

	private bool KjSzrKXVhOFxOgErILEgLFqzqFdY()
	{
		if (ggebuZhgRMpkvgWPFQKyhDlAfywCB >= 10)
		{
			return false;
		}
		if (!jUzvaSgUxxPZfjuEoaadannSMdhp())
		{
			ggebuZhgRMpkvgWPFQKyhDlAfywCB++;
			return false;
		}
		if (ggebuZhgRMpkvgWPFQKyhDlAfywCB > 0)
		{
			ggebuZhgRMpkvgWPFQKyhDlAfywCB = 0;
		}
		return true;
	}

	private bool jUzvaSgUxxPZfjuEoaadannSMdhp()
	{
		if (ilaDRXBjpIjdHmPUwPyhaYWHGuExb != rbLhFKixDkgASAwyfqBoqMqgWggFC.EEWuOauAobBDlKqMznNNkaDveGYD)
		{
			return true;
		}
		if (!xiCusfPPFFKxkJHkqqhLnSxVJGXe)
		{
			return false;
		}
		IntPtr intPtr = TDrocuSAzVTRFYTGGytFvXQEcNyK.XvjMDVUYhYNCHNEfnTAJzpAIpijp(MkPouzyXuDrfyPgarOMlETkjOILN, LAEqXGatZhNViyPVbDeaAdZrcwzGA.Overlapped, 3221225472u, WraHawEAftdcZOtmCkwEFWAOkevE.ShareRead | WraHawEAftdcZOtmCkwEFWAOkevE.ShareWrite);
		if (intPtr == rbLhFKixDkgASAwyfqBoqMqgWggFC.EEWuOauAobBDlKqMznNNkaDveGYD)
		{
			return false;
		}
		ilaDRXBjpIjdHmPUwPyhaYWHGuExb = intPtr;
		return true;
	}

	private void jmjHISxGeklgQFEsPAsOHDsHStyRA()
	{
		if (!(ilaDRXBjpIjdHmPUwPyhaYWHGuExb == rbLhFKixDkgASAwyfqBoqMqgWggFC.EEWuOauAobBDlKqMznNNkaDveGYD))
		{
			TDrocuSAzVTRFYTGGytFvXQEcNyK.MhFXyWCDPqfNDqGpbBprALtTnKvIb(ilaDRXBjpIjdHmPUwPyhaYWHGuExb);
			ilaDRXBjpIjdHmPUwPyhaYWHGuExb = rbLhFKixDkgASAwyfqBoqMqgWggFC.EEWuOauAobBDlKqMznNNkaDveGYD;
		}
	}

	[MonoPInvokeCallback(typeof(rbLhFKixDkgASAwyfqBoqMqgWggFC.QPGHEPgTyQGDciVClCVxOorgbFdf))]
	private static void smQYJxjCDcEHBGXmShzsoXjMUJKJ(int P_0, int P_1, IntPtr P_2)
	{
	}

	public void Dispose()
	{
		bCOWbRehfKzfkukTwBQHFWnYuwXd(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void dZuNGQpARBDhTspkCeZfhlkUHiwEA()
	{
		try
		{
			bCOWbRehfKzfkukTwBQHFWnYuwXd(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void bCOWbRehfKzfkukTwBQHFWnYuwXd(bool P_0)
	{
		if (dsYGBagAfBPorbavGmfKxXaPrYJG)
		{
			return;
		}
		using (new Locker(tskqSZKCInzflSCQGIMHbcFCFHlV))
		{
			if (P_0)
			{
				ZiCSgYckJehlPUwWBGcbjhUDGreI.Dispose();
				ObjectInstanceTracker.Default.Unregister(GIkTHJCesCbzmXNXKctGaqJDnoKDb);
			}
			jmjHISxGeklgQFEsPAsOHDsHStyRA();
			dsYGBagAfBPorbavGmfKxXaPrYJG = true;
		}
	}

	[Conditional("DEBUGTHIS")]
	private void mdmZeGAkOFoELXMOWRsowrKhdQdo(string P_0)
	{
	}
}
