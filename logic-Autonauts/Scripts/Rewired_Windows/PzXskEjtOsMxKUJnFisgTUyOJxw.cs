using System;
using System.Diagnostics;
using System.Threading;
using Rewired;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class PzXskEjtOsMxKUJnFisgTUyOJxw : IDisposable
{
	private enum rUlTjuikKyveVZoObQqlPsThjng
	{
		lpCqsMGfRWqDlmFqiiyTlDQVdUxi = 0,
		VrxsdTdjmGOXbxjLZVMoSukAvXl = 1,
		IOUeCihMRshsEYfUyFnAQDTVFsUU = 2,
		IGnmJoaPhZjHvexNYoSXNiJvHWJ = 3,
		PqKuWgCIhAVuxfdKThCiHNgFqsk = 4,
		dpXWgSWUjXxnzhKgpfqZJVnYRId = 5
	}

	public enum CECgeRugmDBxOeMGrMbkPQKXGIF
	{
		lpCqsMGfRWqDlmFqiiyTlDQVdUxi = 0,
		oBpsGyqHJqGwGwOgINlQTbBFqRf = 1,
		LbxGOspuQJicPsndOHdoFgIBrOT = 2,
		VrxsdTdjmGOXbxjLZVMoSukAvXl = 3,
		NXkzBMMIVNOJpVVBDOlEZnGJfcS = 4
	}

	public const int qHzfyAEIZFKUFeOKOvzyiVANzEA = 4;

	private const int aNPGsrILGVsHdndWTNQHfPbuSpEL = 10;

	private readonly string aaXeFsDbWqQBbhjxXjUbpalQNgG;

	private IntPtr YWmAVJbZBqgWDutqPRyfuhoYjwFw = VQAeymlutODDFHuzZiqfpGyqIVI.PoLOyXNSTnnzTCwVFaqGtiubPUP;

	private readonly NativeBuffer BnTkMddEMRIYxgTpcAWVDYoOLbph;

	private readonly int dmNeiBORwsWvFhJFblVEJnGYEgYC;

	private readonly VQAeymlutODDFHuzZiqfpGyqIVI.JhDyzrRApSSdqxFwWfETpXYwdaSK hNakSuXtPxnMDIXbMjHnrZCdOAU;

	private readonly object daBubAefjHTyMwJRqBvAuAKQQmr;

	private readonly object DrbQKwtcuXhGBoVeTuHPCFHjCtw;

	private readonly uint IWfnwYlCIQwmoxlUAZFFYAYFWzI;

	private NativeOverlapped knROBSUBGSgCEZEWCNTRajYMCuFc;

	private rUlTjuikKyveVZoObQqlPsThjng zLGaNcaSEBUVfqJfVmUHsDhPgluZ;

	private int EJEMnGqHGTsebTWIrxWKilJwTNR;

	private bool wUrhttoLZvhwkguJJJdEdnlMSwc;

	private int rTCQuyrLjBKrBXudhLwmFyuPpau;

	private int RhFDELKhEAFnTgeZiukUhXxoitVv;

	public readonly int zymuldsZAQcQCWSqCMDOxlJNjvDe;

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	private bool IsConnected
	{
		get
		{
			return eCKdLvtfldigSEOJNAhOjiRdUQDt.ncOgwleEAxgwzUjZqavrgAmuBnpv(aaXeFsDbWqQBbhjxXjUbpalQNgG);
		}
	}

	public PzXskEjtOsMxKUJnFisgTUyOJxw(string devicePath, int reportLength, int timeout)
	{
		if (string.IsNullOrEmpty(devicePath))
		{
			throw new ArgumentNullException("devicePath");
		}
		if (reportLength <= 0)
		{
			throw new ArgumentOutOfRangeException("reportLength must be > 0");
		}
		IWfnwYlCIQwmoxlUAZFFYAYFWzI = ObjectInstanceTracker.Default.Register(this);
		aaXeFsDbWqQBbhjxXjUbpalQNgG = devicePath;
		if (!niXwtXfgpyghvjnWvSFbRxLWNHX())
		{
			throw new Exception("Could not open HID device.");
		}
		dmNeiBORwsWvFhJFblVEJnGYEgYC = reportLength;
		zymuldsZAQcQCWSqCMDOxlJNjvDe = reportLength + 4;
		BnTkMddEMRIYxgTpcAWVDYoOLbph = new NativeBuffer(zymuldsZAQcQCWSqCMDOxlJNjvDe);
		knROBSUBGSgCEZEWCNTRajYMCuFc = default(NativeOverlapped);
		zLGaNcaSEBUVfqJfVmUHsDhPgluZ = rUlTjuikKyveVZoObQqlPsThjng.lpCqsMGfRWqDlmFqiiyTlDQVdUxi;
		EJEMnGqHGTsebTWIrxWKilJwTNR = ((timeout < 0) ? 65535 : timeout);
		daBubAefjHTyMwJRqBvAuAKQQmr = new object();
		DrbQKwtcuXhGBoVeTuHPCFHjCtw = new object();
		hNakSuXtPxnMDIXbMjHnrZCdOAU = jyBLuesEwYhoJFNfMnGyOyQGldp;
		gRZcVtephTEHZvTXJFpoYOeTypkH(knROBSUBGSgCEZEWCNTRajYMCuFc);
	}

	public CECgeRugmDBxOeMGrMbkPQKXGIF BzRDvjvAQHKNUfdBiARKBsCcKkSL(byte[] P_0)
	{
		lock (DrbQKwtcuXhGBoVeTuHPCFHjCtw)
		{
			if (nNxUslIcGUpqKgpPZYhuimcvWyC)
			{
				return CECgeRugmDBxOeMGrMbkPQKXGIF.NXkzBMMIVNOJpVVBDOlEZnGJfcS;
			}
			if (!yAmhteKubjITQDZbgVxpKCdDNVHy())
			{
				return (RhFDELKhEAFnTgeZiukUhXxoitVv >= 10) ? CECgeRugmDBxOeMGrMbkPQKXGIF.NXkzBMMIVNOJpVVBDOlEZnGJfcS : CECgeRugmDBxOeMGrMbkPQKXGIF.LbxGOspuQJicPsndOHdoFgIBrOT;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (P_0.Length < zymuldsZAQcQCWSqCMDOxlJNjvDe)
			{
				throw new Exception("buffer must be at least " + zymuldsZAQcQCWSqCMDOxlJNjvDe + " bytes");
			}
			switch (zLGaNcaSEBUVfqJfVmUHsDhPgluZ)
			{
			case rUlTjuikKyveVZoObQqlPsThjng.lpCqsMGfRWqDlmFqiiyTlDQVdUxi:
				cWPqpcqCTjqUIacomXzEsDnoJFc();
				break;
			case rUlTjuikKyveVZoObQqlPsThjng.VrxsdTdjmGOXbxjLZVMoSukAvXl:
				MJKJMnEWKgALhyAiJNmhtyHQqrD();
				break;
			case rUlTjuikKyveVZoObQqlPsThjng.IOUeCihMRshsEYfUyFnAQDTVFsUU:
				yeDiipBEcRWbaCeCXzbkRTgCOCBb();
				break;
			case rUlTjuikKyveVZoObQqlPsThjng.PqKuWgCIhAVuxfdKThCiHNgFqsk:
				gRAOISVoHUqvxzGpenDgaMkpzPU();
				break;
			}
			switch (zLGaNcaSEBUVfqJfVmUHsDhPgluZ)
			{
			case rUlTjuikKyveVZoObQqlPsThjng.lpCqsMGfRWqDlmFqiiyTlDQVdUxi:
				return CECgeRugmDBxOeMGrMbkPQKXGIF.lpCqsMGfRWqDlmFqiiyTlDQVdUxi;
			case rUlTjuikKyveVZoObQqlPsThjng.VrxsdTdjmGOXbxjLZVMoSukAvXl:
			case rUlTjuikKyveVZoObQqlPsThjng.IOUeCihMRshsEYfUyFnAQDTVFsUU:
			case rUlTjuikKyveVZoObQqlPsThjng.PqKuWgCIhAVuxfdKThCiHNgFqsk:
				return CECgeRugmDBxOeMGrMbkPQKXGIF.VrxsdTdjmGOXbxjLZVMoSukAvXl;
			case rUlTjuikKyveVZoObQqlPsThjng.dpXWgSWUjXxnzhKgpfqZJVnYRId:
				BnTkMddEMRIYxgTpcAWVDYoOLbph.TryReadBytes(P_0, zymuldsZAQcQCWSqCMDOxlJNjvDe);
				zLGaNcaSEBUVfqJfVmUHsDhPgluZ = rUlTjuikKyveVZoObQqlPsThjng.lpCqsMGfRWqDlmFqiiyTlDQVdUxi;
				return CECgeRugmDBxOeMGrMbkPQKXGIF.oBpsGyqHJqGwGwOgINlQTbBFqRf;
			case rUlTjuikKyveVZoObQqlPsThjng.IGnmJoaPhZjHvexNYoSXNiJvHWJ:
				zLGaNcaSEBUVfqJfVmUHsDhPgluZ = rUlTjuikKyveVZoObQqlPsThjng.lpCqsMGfRWqDlmFqiiyTlDQVdUxi;
				return CECgeRugmDBxOeMGrMbkPQKXGIF.LbxGOspuQJicPsndOHdoFgIBrOT;
			default:
				throw new NotImplementedException();
			}
		}
	}

	private bool cWPqpcqCTjqUIacomXzEsDnoJFc()
	{
		if (zLGaNcaSEBUVfqJfVmUHsDhPgluZ != rUlTjuikKyveVZoObQqlPsThjng.lpCqsMGfRWqDlmFqiiyTlDQVdUxi)
		{
			throw new Exception("Cannot StartRead from this state. State = " + (int)zLGaNcaSEBUVfqJfVmUHsDhPgluZ);
		}
		try
		{
			UsuwPiqVitnNRnZALvWAYQYnQRS();
			lock (daBubAefjHTyMwJRqBvAuAKQQmr)
			{
				bool flag = VQAeymlutODDFHuzZiqfpGyqIVI.anGkgjsECcjrieAygksQzeXsGLFP(YWmAVJbZBqgWDutqPRyfuhoYjwFw, BnTkMddEMRIYxgTpcAWVDYoOLbph, (uint)dmNeiBORwsWvFhJFblVEJnGYEgYC, ref knROBSUBGSgCEZEWCNTRajYMCuFc, hNakSuXtPxnMDIXbMjHnrZCdOAU);
				if (flag)
				{
					zLGaNcaSEBUVfqJfVmUHsDhPgluZ = rUlTjuikKyveVZoObQqlPsThjng.VrxsdTdjmGOXbxjLZVMoSukAvXl;
					wUrhttoLZvhwkguJJJdEdnlMSwc = true;
				}
				else
				{
					LbxGOspuQJicPsndOHdoFgIBrOT();
				}
				return flag;
			}
		}
		catch (Exception)
		{
			LbxGOspuQJicPsndOHdoFgIBrOT();
			return false;
		}
	}

	private void MJKJMnEWKgALhyAiJNmhtyHQqrD()
	{
		if (zLGaNcaSEBUVfqJfVmUHsDhPgluZ != rUlTjuikKyveVZoObQqlPsThjng.VrxsdTdjmGOXbxjLZVMoSukAvXl)
		{
			throw new Exception("Cannot CheckReadStatus from this state. State = " + (int)zLGaNcaSEBUVfqJfVmUHsDhPgluZ);
		}
		switch (vDpGTElrMvqBWfIYfLCXAvIUGkL())
		{
		case CECgeRugmDBxOeMGrMbkPQKXGIF.LbxGOspuQJicPsndOHdoFgIBrOT:
			LbxGOspuQJicPsndOHdoFgIBrOT();
			break;
		case CECgeRugmDBxOeMGrMbkPQKXGIF.oBpsGyqHJqGwGwOgINlQTbBFqRf:
			oBpsGyqHJqGwGwOgINlQTbBFqRf();
			break;
		case CECgeRugmDBxOeMGrMbkPQKXGIF.VrxsdTdjmGOXbxjLZVMoSukAvXl:
			break;
		}
	}

	private CECgeRugmDBxOeMGrMbkPQKXGIF vDpGTElrMvqBWfIYfLCXAvIUGkL()
	{
		if (zLGaNcaSEBUVfqJfVmUHsDhPgluZ != rUlTjuikKyveVZoObQqlPsThjng.VrxsdTdjmGOXbxjLZVMoSukAvXl)
		{
			return CECgeRugmDBxOeMGrMbkPQKXGIF.LbxGOspuQJicPsndOHdoFgIBrOT;
		}
		try
		{
			switch (VQAeymlutODDFHuzZiqfpGyqIVI.YvTgsKvYnXmJcwopxLPHZUAoCpn(EJEMnGqHGTsebTWIrxWKilJwTNR, true))
			{
			case 0u:
				return CECgeRugmDBxOeMGrMbkPQKXGIF.VrxsdTdjmGOXbxjLZVMoSukAvXl;
			case 192u:
			{
				int num;
				if (!VQAeymlutODDFHuzZiqfpGyqIVI.jhFMNwrdgkpzfZsGHuCjzvhaGqt(YWmAVJbZBqgWDutqPRyfuhoYjwFw, ref knROBSUBGSgCEZEWCNTRajYMCuFc, out num, false))
				{
					return CECgeRugmDBxOeMGrMbkPQKXGIF.LbxGOspuQJicPsndOHdoFgIBrOT;
				}
				return (num > 0) ? CECgeRugmDBxOeMGrMbkPQKXGIF.oBpsGyqHJqGwGwOgINlQTbBFqRf : CECgeRugmDBxOeMGrMbkPQKXGIF.LbxGOspuQJicPsndOHdoFgIBrOT;
			}
			case uint.MaxValue:
			case 128u:
			case 258u:
				return CECgeRugmDBxOeMGrMbkPQKXGIF.VrxsdTdjmGOXbxjLZVMoSukAvXl;
			default:
				return CECgeRugmDBxOeMGrMbkPQKXGIF.LbxGOspuQJicPsndOHdoFgIBrOT;
			}
		}
		catch
		{
			return CECgeRugmDBxOeMGrMbkPQKXGIF.LbxGOspuQJicPsndOHdoFgIBrOT;
		}
	}

	private void LbxGOspuQJicPsndOHdoFgIBrOT()
	{
		zLGaNcaSEBUVfqJfVmUHsDhPgluZ = rUlTjuikKyveVZoObQqlPsThjng.IOUeCihMRshsEYfUyFnAQDTVFsUU;
		yeDiipBEcRWbaCeCXzbkRTgCOCBb();
	}

	private void yeDiipBEcRWbaCeCXzbkRTgCOCBb()
	{
		if (zLGaNcaSEBUVfqJfVmUHsDhPgluZ != rUlTjuikKyveVZoObQqlPsThjng.IOUeCihMRshsEYfUyFnAQDTVFsUU)
		{
			throw new Exception("Cannot CheckErrorFinished from this state. State = " + (int)zLGaNcaSEBUVfqJfVmUHsDhPgluZ);
		}
		zLGaNcaSEBUVfqJfVmUHsDhPgluZ = rUlTjuikKyveVZoObQqlPsThjng.IGnmJoaPhZjHvexNYoSXNiJvHWJ;
	}

	private void oBpsGyqHJqGwGwOgINlQTbBFqRf()
	{
		zLGaNcaSEBUVfqJfVmUHsDhPgluZ = rUlTjuikKyveVZoObQqlPsThjng.PqKuWgCIhAVuxfdKThCiHNgFqsk;
		gRAOISVoHUqvxzGpenDgaMkpzPU();
	}

	private void gRAOISVoHUqvxzGpenDgaMkpzPU()
	{
		if (zLGaNcaSEBUVfqJfVmUHsDhPgluZ != rUlTjuikKyveVZoObQqlPsThjng.PqKuWgCIhAVuxfdKThCiHNgFqsk)
		{
			throw new Exception("Cannot CheckSuccessFinished from this state. State = " + (int)zLGaNcaSEBUVfqJfVmUHsDhPgluZ);
		}
		zLGaNcaSEBUVfqJfVmUHsDhPgluZ = rUlTjuikKyveVZoObQqlPsThjng.dpXWgSWUjXxnzhKgpfqZJVnYRId;
		BnTkMddEMRIYxgTpcAWVDYoOLbph.Write(ReInput.realTime, dmNeiBORwsWvFhJFblVEJnGYEgYC);
	}

	private void UsuwPiqVitnNRnZALvWAYQYnQRS()
	{
		gRZcVtephTEHZvTXJFpoYOeTypkH(knROBSUBGSgCEZEWCNTRajYMCuFc);
		BnTkMddEMRIYxgTpcAWVDYoOLbph.Clear();
		rTCQuyrLjBKrBXudhLwmFyuPpau = 0;
		wUrhttoLZvhwkguJJJdEdnlMSwc = false;
	}

	private void gRZcVtephTEHZvTXJFpoYOeTypkH(NativeOverlapped P_0)
	{
		P_0.EventHandle = new IntPtr((int)IWfnwYlCIQwmoxlUAZFFYAYFWzI);
		P_0.InternalHigh = IntPtr.Zero;
		P_0.InternalLow = IntPtr.Zero;
		P_0.OffsetHigh = 0;
		P_0.OffsetLow = 0;
	}

	private bool yAmhteKubjITQDZbgVxpKCdDNVHy()
	{
		if (RhFDELKhEAFnTgeZiukUhXxoitVv >= 10)
		{
			return false;
		}
		if (!niXwtXfgpyghvjnWvSFbRxLWNHX())
		{
			RhFDELKhEAFnTgeZiukUhXxoitVv++;
			return false;
		}
		if (RhFDELKhEAFnTgeZiukUhXxoitVv > 0)
		{
			RhFDELKhEAFnTgeZiukUhXxoitVv = 0;
		}
		return true;
	}

	private bool niXwtXfgpyghvjnWvSFbRxLWNHX()
	{
		if (YWmAVJbZBqgWDutqPRyfuhoYjwFw != VQAeymlutODDFHuzZiqfpGyqIVI.PoLOyXNSTnnzTCwVFaqGtiubPUP)
		{
			return true;
		}
		if (!IsConnected)
		{
			return false;
		}
		IntPtr intPtr = bUiVDUOAHpFECnWVzgHAGOUkHLxZ.GjSaDykfSUEoFcJhekNLJfmmDkUi(aaXeFsDbWqQBbhjxXjUbpalQNgG, dzJSyaujfBAKrLjAEgXlxqFRAJs.JbIUSaZPWtqxnRJbasSLgnHRzFR, 3221225472u, ubjwsWWWsVegtjdmbBZpanWemFc.QRQpmFyFgkPoxgPulHsTJfiujVP | ubjwsWWWsVegtjdmbBZpanWemFc.yGKvaEnFoNlkBgziUsjnlRqcLis);
		if (intPtr == VQAeymlutODDFHuzZiqfpGyqIVI.PoLOyXNSTnnzTCwVFaqGtiubPUP)
		{
			return false;
		}
		YWmAVJbZBqgWDutqPRyfuhoYjwFw = intPtr;
		return true;
	}

	private void JWyxuQLyyxgKiJQxfEwZTldbona()
	{
		if (!(YWmAVJbZBqgWDutqPRyfuhoYjwFw == VQAeymlutODDFHuzZiqfpGyqIVI.PoLOyXNSTnnzTCwVFaqGtiubPUP))
		{
			bUiVDUOAHpFECnWVzgHAGOUkHLxZ.RwpzeRLYdIrdAjRbNsZwnnMMCZv(YWmAVJbZBqgWDutqPRyfuhoYjwFw);
			YWmAVJbZBqgWDutqPRyfuhoYjwFw = VQAeymlutODDFHuzZiqfpGyqIVI.PoLOyXNSTnnzTCwVFaqGtiubPUP;
		}
	}

	[MonoPInvokeCallback(typeof(VQAeymlutODDFHuzZiqfpGyqIVI.JhDyzrRApSSdqxFwWfETpXYwdaSK))]
	private unsafe static void jyBLuesEwYhoJFNfMnGyOyQGldp(int P_0, int P_1, IntPtr P_2)
	{
		NativeOverlapped* ptr = (NativeOverlapped*)(void*)P_2;
		uint instanceId = (uint)ptr->EventHandle.ToInt32();
		PzXskEjtOsMxKUJnFisgTUyOJxw instance;
		if (!ObjectInstanceTracker.Default.TryGetInstance<PzXskEjtOsMxKUJnFisgTUyOJxw>(instanceId, out instance))
		{
			return;
		}
		lock (instance.daBubAefjHTyMwJRqBvAuAKQQmr)
		{
			instance.rTCQuyrLjBKrBXudhLwmFyuPpau = P_0;
			instance.wUrhttoLZvhwkguJJJdEdnlMSwc = false;
		}
	}

	public void Dispose()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~PzXskEjtOsMxKUJnFisgTUyOJxw()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		if (nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			return;
		}
		using (new Locker(DrbQKwtcuXhGBoVeTuHPCFHjCtw))
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(IWfnwYlCIQwmoxlUAZFFYAYFWzI);
			}
			JWyxuQLyyxgKiJQxfEwZTldbona();
			nNxUslIcGUpqKgpPZYhuimcvWyC = true;
		}
	}

	[Conditional("DEBUGTHIS")]
	private void NMrJyHMZCxUBcrDblwcqHVmhYaU(string P_0)
	{
	}
}
