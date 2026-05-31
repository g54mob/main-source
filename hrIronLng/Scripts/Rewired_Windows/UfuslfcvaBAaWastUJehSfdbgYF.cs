using System;
using System.Diagnostics;
using System.Threading;
using Rewired;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class UfuslfcvaBAaWastUJehSfdbgYF : IDisposable
{
	private enum XdAvCtAOUjdirVhJNdGGBhmZjXu
	{
		oNnPbpRqvbqQfEhkdTyGohPkVZI = 0,
		KsYaJicMAzhmtDTWGYzjRpinmiS = 1,
		POlCPHFwjBAAANdSvAxVUUYsalh = 2,
		XMSjzcrqzkSDREYbZnqHYQjUMCb = 3,
		EqjabNfBXjkjtmNEQRQdTSxgFbFo = 4,
		sOuEJXHGwmYNxFHUqBrjETObbMbH = 5
	}

	public enum lOZxstMQhXgHssEeWAsxHVPDhFFe
	{
		oNnPbpRqvbqQfEhkdTyGohPkVZI = 0,
		lbKFULdzfDWsACyUFlsLCGxoAxA = 1,
		AvMNaPumcgWmPOraZnuhCLouNeq = 2,
		KsYaJicMAzhmtDTWGYzjRpinmiS = 3,
		SDVfikFnuiKeZnnTUaKoMwkyTef = 4
	}

	public const int viUlfvVzlmeOByQTTxYjSBHiJDb = 8;

	private const int xFiazAOdaairbPuAYmSAKtoTfyh = 10;

	private readonly string daoTxRCmXXmibNhjAmdcoXelKQb;

	private IntPtr LXDCUiKbjPHeDVBwIruwccfrnje = MsdjFrwPRhtDqvryUwwfexLTAxz.WiLIFZKrwwnVxpsyMFmxeknBkQj;

	private readonly NativeBuffer MGmVOJiswkwnBAbvbGQwLtBdeEt;

	private readonly int ygatmsLYCNHRQDLdwNBLIFuphtb;

	private readonly MsdjFrwPRhtDqvryUwwfexLTAxz.nGJdhcAAGKsOdxLdxzVGlOLpDVYY stVYlDGAbMfRRIutPadoHwZBWDny;

	private readonly object aaiyIjzIJmOKGKzRnhLTdELxdLY;

	private readonly object SQKoHNmjQeURXAPyIAkWJLOMxNFt;

	private readonly uint VxUhDlcjidEycVnEHXAILRBgalp;

	private NativeOverlapped vmaxBrLJkfKeCjaCRyFCjZThihs;

	private XdAvCtAOUjdirVhJNdGGBhmZjXu ughcEFHOygcbbdUjQzQKMvwyDgT;

	private int VjdNJblSgmlGxnOOqElBGjAXNQuw;

	private bool nBAVoOpmnCRBgGBTMnFPivshATZ;

	private int eoxpWLcPlsTNSfnyswjnKlyQpRF;

	private int KbeFNcoRaphNDQADtPgTSAaLLqq;

	public readonly int eTBebYfVuxcYOohoLJeRgOSmyGi;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	private bool IsConnected => pDdfcWqxDAHCEFuHEUpBobYCGVaf.svxfQKxBmGjUbuRBnlfmDjpLwkW(daoTxRCmXXmibNhjAmdcoXelKQb);

	public UfuslfcvaBAaWastUJehSfdbgYF(string devicePath, int reportLength, int timeout)
	{
		if (string.IsNullOrEmpty(devicePath))
		{
			throw new ArgumentNullException("devicePath");
		}
		if (reportLength <= 0)
		{
			throw new ArgumentOutOfRangeException("reportLength must be > 0");
		}
		VxUhDlcjidEycVnEHXAILRBgalp = ObjectInstanceTracker.Default.Register(this);
		daoTxRCmXXmibNhjAmdcoXelKQb = devicePath;
		if (!yNqEbmJaNBpJzqZUoLGyKAUvRQku())
		{
			throw new Exception("Could not open HID device.");
		}
		ygatmsLYCNHRQDLdwNBLIFuphtb = reportLength;
		eTBebYfVuxcYOohoLJeRgOSmyGi = reportLength + 8;
		MGmVOJiswkwnBAbvbGQwLtBdeEt = new NativeBuffer(eTBebYfVuxcYOohoLJeRgOSmyGi);
		vmaxBrLJkfKeCjaCRyFCjZThihs = default(NativeOverlapped);
		ughcEFHOygcbbdUjQzQKMvwyDgT = XdAvCtAOUjdirVhJNdGGBhmZjXu.oNnPbpRqvbqQfEhkdTyGohPkVZI;
		VjdNJblSgmlGxnOOqElBGjAXNQuw = ((timeout < 0) ? 65535 : timeout);
		aaiyIjzIJmOKGKzRnhLTdELxdLY = new object();
		SQKoHNmjQeURXAPyIAkWJLOMxNFt = new object();
		stVYlDGAbMfRRIutPadoHwZBWDny = qWkAMPFnAhMGRYznRyErmLVhjcSY;
		dtacWSwUXqejVvKTIPvzDNvgneL(vmaxBrLJkfKeCjaCRyFCjZThihs);
	}

	public lOZxstMQhXgHssEeWAsxHVPDhFFe OyoZWUuiamgvSVRBhbJZhjZZxdr(byte[] P_0)
	{
		lock (SQKoHNmjQeURXAPyIAkWJLOMxNFt)
		{
			if (euujVPFzGztViWDbYvUutBvFQFP)
			{
				return lOZxstMQhXgHssEeWAsxHVPDhFFe.SDVfikFnuiKeZnnTUaKoMwkyTef;
			}
			if (!lZXoGFncFGedQxOfOeteTLocASqb())
			{
				return (KbeFNcoRaphNDQADtPgTSAaLLqq >= 10) ? lOZxstMQhXgHssEeWAsxHVPDhFFe.SDVfikFnuiKeZnnTUaKoMwkyTef : lOZxstMQhXgHssEeWAsxHVPDhFFe.AvMNaPumcgWmPOraZnuhCLouNeq;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (P_0.Length < eTBebYfVuxcYOohoLJeRgOSmyGi)
			{
				throw new Exception("buffer must be at least " + eTBebYfVuxcYOohoLJeRgOSmyGi + " bytes");
			}
			switch (ughcEFHOygcbbdUjQzQKMvwyDgT)
			{
			case XdAvCtAOUjdirVhJNdGGBhmZjXu.oNnPbpRqvbqQfEhkdTyGohPkVZI:
				fWgqzLpVsIISOCQmdQTLpfIJvCF();
				break;
			case XdAvCtAOUjdirVhJNdGGBhmZjXu.KsYaJicMAzhmtDTWGYzjRpinmiS:
				FjuHMLYaPNdzAomWyyyacEzkku();
				break;
			case XdAvCtAOUjdirVhJNdGGBhmZjXu.POlCPHFwjBAAANdSvAxVUUYsalh:
				vDyrsCZYEoVcyEQQGllvGgfxHPc();
				break;
			case XdAvCtAOUjdirVhJNdGGBhmZjXu.EqjabNfBXjkjtmNEQRQdTSxgFbFo:
				tlvJmrStllHEpDrwfFdpbehOGyp();
				break;
			}
			switch (ughcEFHOygcbbdUjQzQKMvwyDgT)
			{
			case XdAvCtAOUjdirVhJNdGGBhmZjXu.oNnPbpRqvbqQfEhkdTyGohPkVZI:
				return lOZxstMQhXgHssEeWAsxHVPDhFFe.oNnPbpRqvbqQfEhkdTyGohPkVZI;
			case XdAvCtAOUjdirVhJNdGGBhmZjXu.KsYaJicMAzhmtDTWGYzjRpinmiS:
			case XdAvCtAOUjdirVhJNdGGBhmZjXu.POlCPHFwjBAAANdSvAxVUUYsalh:
			case XdAvCtAOUjdirVhJNdGGBhmZjXu.EqjabNfBXjkjtmNEQRQdTSxgFbFo:
				return lOZxstMQhXgHssEeWAsxHVPDhFFe.KsYaJicMAzhmtDTWGYzjRpinmiS;
			case XdAvCtAOUjdirVhJNdGGBhmZjXu.sOuEJXHGwmYNxFHUqBrjETObbMbH:
				MGmVOJiswkwnBAbvbGQwLtBdeEt.TryReadBytes(P_0, eTBebYfVuxcYOohoLJeRgOSmyGi);
				ughcEFHOygcbbdUjQzQKMvwyDgT = XdAvCtAOUjdirVhJNdGGBhmZjXu.oNnPbpRqvbqQfEhkdTyGohPkVZI;
				return lOZxstMQhXgHssEeWAsxHVPDhFFe.lbKFULdzfDWsACyUFlsLCGxoAxA;
			case XdAvCtAOUjdirVhJNdGGBhmZjXu.XMSjzcrqzkSDREYbZnqHYQjUMCb:
				ughcEFHOygcbbdUjQzQKMvwyDgT = XdAvCtAOUjdirVhJNdGGBhmZjXu.oNnPbpRqvbqQfEhkdTyGohPkVZI;
				return lOZxstMQhXgHssEeWAsxHVPDhFFe.AvMNaPumcgWmPOraZnuhCLouNeq;
			default:
				throw new NotImplementedException();
			}
		}
	}

	private bool fWgqzLpVsIISOCQmdQTLpfIJvCF()
	{
		if (ughcEFHOygcbbdUjQzQKMvwyDgT != XdAvCtAOUjdirVhJNdGGBhmZjXu.oNnPbpRqvbqQfEhkdTyGohPkVZI)
		{
			throw new Exception("Cannot StartRead from this state. State = " + (int)ughcEFHOygcbbdUjQzQKMvwyDgT);
		}
		try
		{
			TzBPrZngbKbHBhJPAmtHpHNMMTtf();
			lock (aaiyIjzIJmOKGKzRnhLTdELxdLY)
			{
				bool flag = MsdjFrwPRhtDqvryUwwfexLTAxz.nGnxKfrugXJkRqcZdgNCdCmXWuj(LXDCUiKbjPHeDVBwIruwccfrnje, MGmVOJiswkwnBAbvbGQwLtBdeEt, (uint)ygatmsLYCNHRQDLdwNBLIFuphtb, ref vmaxBrLJkfKeCjaCRyFCjZThihs, stVYlDGAbMfRRIutPadoHwZBWDny);
				if (flag)
				{
					ughcEFHOygcbbdUjQzQKMvwyDgT = XdAvCtAOUjdirVhJNdGGBhmZjXu.KsYaJicMAzhmtDTWGYzjRpinmiS;
					nBAVoOpmnCRBgGBTMnFPivshATZ = true;
				}
				else
				{
					AvMNaPumcgWmPOraZnuhCLouNeq();
				}
				return flag;
			}
		}
		catch (Exception)
		{
			AvMNaPumcgWmPOraZnuhCLouNeq();
			return false;
		}
	}

	private void FjuHMLYaPNdzAomWyyyacEzkku()
	{
		if (ughcEFHOygcbbdUjQzQKMvwyDgT != XdAvCtAOUjdirVhJNdGGBhmZjXu.KsYaJicMAzhmtDTWGYzjRpinmiS)
		{
			throw new Exception("Cannot CheckReadStatus from this state. State = " + (int)ughcEFHOygcbbdUjQzQKMvwyDgT);
		}
		switch (gKAtPfaxcUYvSZzEoDBGXyNjNly())
		{
		case lOZxstMQhXgHssEeWAsxHVPDhFFe.AvMNaPumcgWmPOraZnuhCLouNeq:
			AvMNaPumcgWmPOraZnuhCLouNeq();
			break;
		case lOZxstMQhXgHssEeWAsxHVPDhFFe.lbKFULdzfDWsACyUFlsLCGxoAxA:
			lbKFULdzfDWsACyUFlsLCGxoAxA();
			break;
		case lOZxstMQhXgHssEeWAsxHVPDhFFe.KsYaJicMAzhmtDTWGYzjRpinmiS:
			break;
		}
	}

	private lOZxstMQhXgHssEeWAsxHVPDhFFe gKAtPfaxcUYvSZzEoDBGXyNjNly()
	{
		if (ughcEFHOygcbbdUjQzQKMvwyDgT != XdAvCtAOUjdirVhJNdGGBhmZjXu.KsYaJicMAzhmtDTWGYzjRpinmiS)
		{
			return lOZxstMQhXgHssEeWAsxHVPDhFFe.AvMNaPumcgWmPOraZnuhCLouNeq;
		}
		try
		{
			switch (MsdjFrwPRhtDqvryUwwfexLTAxz.RozzhgTBgdjmkYduyVMFQFLXwOQ(VjdNJblSgmlGxnOOqElBGjAXNQuw, true))
			{
			case 0u:
				return lOZxstMQhXgHssEeWAsxHVPDhFFe.KsYaJicMAzhmtDTWGYzjRpinmiS;
			case 192u:
			{
				if (!MsdjFrwPRhtDqvryUwwfexLTAxz.snelJPgwMTJVbhdYKnwiggyVOJU(LXDCUiKbjPHeDVBwIruwccfrnje, ref vmaxBrLJkfKeCjaCRyFCjZThihs, out var num, false))
				{
					return lOZxstMQhXgHssEeWAsxHVPDhFFe.AvMNaPumcgWmPOraZnuhCLouNeq;
				}
				return (num > 0) ? lOZxstMQhXgHssEeWAsxHVPDhFFe.lbKFULdzfDWsACyUFlsLCGxoAxA : lOZxstMQhXgHssEeWAsxHVPDhFFe.AvMNaPumcgWmPOraZnuhCLouNeq;
			}
			case uint.MaxValue:
			case 128u:
			case 258u:
				return lOZxstMQhXgHssEeWAsxHVPDhFFe.KsYaJicMAzhmtDTWGYzjRpinmiS;
			default:
				return lOZxstMQhXgHssEeWAsxHVPDhFFe.AvMNaPumcgWmPOraZnuhCLouNeq;
			}
		}
		catch
		{
			return lOZxstMQhXgHssEeWAsxHVPDhFFe.AvMNaPumcgWmPOraZnuhCLouNeq;
		}
	}

	private void AvMNaPumcgWmPOraZnuhCLouNeq()
	{
		ughcEFHOygcbbdUjQzQKMvwyDgT = XdAvCtAOUjdirVhJNdGGBhmZjXu.POlCPHFwjBAAANdSvAxVUUYsalh;
		vDyrsCZYEoVcyEQQGllvGgfxHPc();
	}

	private void vDyrsCZYEoVcyEQQGllvGgfxHPc()
	{
		if (ughcEFHOygcbbdUjQzQKMvwyDgT != XdAvCtAOUjdirVhJNdGGBhmZjXu.POlCPHFwjBAAANdSvAxVUUYsalh)
		{
			throw new Exception("Cannot CheckErrorFinished from this state. State = " + (int)ughcEFHOygcbbdUjQzQKMvwyDgT);
		}
		ughcEFHOygcbbdUjQzQKMvwyDgT = XdAvCtAOUjdirVhJNdGGBhmZjXu.XMSjzcrqzkSDREYbZnqHYQjUMCb;
	}

	private void lbKFULdzfDWsACyUFlsLCGxoAxA()
	{
		ughcEFHOygcbbdUjQzQKMvwyDgT = XdAvCtAOUjdirVhJNdGGBhmZjXu.EqjabNfBXjkjtmNEQRQdTSxgFbFo;
		tlvJmrStllHEpDrwfFdpbehOGyp();
	}

	private void tlvJmrStllHEpDrwfFdpbehOGyp()
	{
		if (ughcEFHOygcbbdUjQzQKMvwyDgT != XdAvCtAOUjdirVhJNdGGBhmZjXu.EqjabNfBXjkjtmNEQRQdTSxgFbFo)
		{
			throw new Exception("Cannot CheckSuccessFinished from this state. State = " + (int)ughcEFHOygcbbdUjQzQKMvwyDgT);
		}
		ughcEFHOygcbbdUjQzQKMvwyDgT = XdAvCtAOUjdirVhJNdGGBhmZjXu.sOuEJXHGwmYNxFHUqBrjETObbMbH;
		MGmVOJiswkwnBAbvbGQwLtBdeEt.Write(ReInput.realTime, ygatmsLYCNHRQDLdwNBLIFuphtb);
	}

	private void TzBPrZngbKbHBhJPAmtHpHNMMTtf()
	{
		dtacWSwUXqejVvKTIPvzDNvgneL(vmaxBrLJkfKeCjaCRyFCjZThihs);
		MGmVOJiswkwnBAbvbGQwLtBdeEt.Clear();
		eoxpWLcPlsTNSfnyswjnKlyQpRF = 0;
		nBAVoOpmnCRBgGBTMnFPivshATZ = false;
	}

	private void dtacWSwUXqejVvKTIPvzDNvgneL(NativeOverlapped P_0)
	{
		P_0.EventHandle = new IntPtr((int)VxUhDlcjidEycVnEHXAILRBgalp);
		P_0.InternalHigh = IntPtr.Zero;
		P_0.InternalLow = IntPtr.Zero;
		P_0.OffsetHigh = 0;
		P_0.OffsetLow = 0;
	}

	private bool lZXoGFncFGedQxOfOeteTLocASqb()
	{
		if (KbeFNcoRaphNDQADtPgTSAaLLqq >= 10)
		{
			return false;
		}
		if (!yNqEbmJaNBpJzqZUoLGyKAUvRQku())
		{
			KbeFNcoRaphNDQADtPgTSAaLLqq++;
			return false;
		}
		if (KbeFNcoRaphNDQADtPgTSAaLLqq > 0)
		{
			KbeFNcoRaphNDQADtPgTSAaLLqq = 0;
		}
		return true;
	}

	private bool yNqEbmJaNBpJzqZUoLGyKAUvRQku()
	{
		if (LXDCUiKbjPHeDVBwIruwccfrnje != MsdjFrwPRhtDqvryUwwfexLTAxz.WiLIFZKrwwnVxpsyMFmxeknBkQj)
		{
			return true;
		}
		if (!IsConnected)
		{
			return false;
		}
		IntPtr intPtr = oODKWlXjjUaKGJbFcHDHZKTTKwC.JehbOJsOgzCQFhpbtBPOfczwQrhm(daoTxRCmXXmibNhjAmdcoXelKQb, sSitzLtsLskxvjKvTBbkifCoAGX.URCiXxKcjnAOzIpDywkZQnayrkai, 3221225472u, dcMHdvBJUgQSpaRiuINemzFFmMJU.ZllbRgxAcXAWxMqOuwSYWhYHMiK | dcMHdvBJUgQSpaRiuINemzFFmMJU.bclhlbwGCgFOPAmoBhtegdfNbtDd);
		if (intPtr == MsdjFrwPRhtDqvryUwwfexLTAxz.WiLIFZKrwwnVxpsyMFmxeknBkQj)
		{
			return false;
		}
		LXDCUiKbjPHeDVBwIruwccfrnje = intPtr;
		return true;
	}

	private void UvHrZvEbOOuQkrsjogEOCCoIacZ()
	{
		if (!(LXDCUiKbjPHeDVBwIruwccfrnje == MsdjFrwPRhtDqvryUwwfexLTAxz.WiLIFZKrwwnVxpsyMFmxeknBkQj))
		{
			oODKWlXjjUaKGJbFcHDHZKTTKwC.MVKfBoILRvLoMFefORPtodZdMnK(LXDCUiKbjPHeDVBwIruwccfrnje);
			LXDCUiKbjPHeDVBwIruwccfrnje = MsdjFrwPRhtDqvryUwwfexLTAxz.WiLIFZKrwwnVxpsyMFmxeknBkQj;
		}
	}

	[MonoPInvokeCallback(typeof(MsdjFrwPRhtDqvryUwwfexLTAxz.nGJdhcAAGKsOdxLdxzVGlOLpDVYY))]
	private unsafe static void qWkAMPFnAhMGRYznRyErmLVhjcSY(int P_0, int P_1, IntPtr P_2)
	{
		NativeOverlapped* ptr = (NativeOverlapped*)(void*)P_2;
		uint instanceId = (uint)ptr->EventHandle.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<UfuslfcvaBAaWastUJehSfdbgYF>(instanceId, out var instance))
		{
			return;
		}
		lock (instance.aaiyIjzIJmOKGKzRnhLTdELxdLY)
		{
			instance.eoxpWLcPlsTNSfnyswjnKlyQpRF = P_0;
			instance.nBAVoOpmnCRBgGBTMnFPivshATZ = false;
		}
	}

	public void Dispose()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~UfuslfcvaBAaWastUJehSfdbgYF()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (euujVPFzGztViWDbYvUutBvFQFP)
		{
			return;
		}
		using (new Locker(SQKoHNmjQeURXAPyIAkWJLOMxNFt))
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(VxUhDlcjidEycVnEHXAILRBgalp);
			}
			UvHrZvEbOOuQkrsjogEOCCoIacZ();
			euujVPFzGztViWDbYvUutBvFQFP = true;
		}
	}

	[Conditional("DEBUGTHIS")]
	private void WZziERHIvCecDVjNmvyzStQQaLf(string P_0)
	{
	}
}
