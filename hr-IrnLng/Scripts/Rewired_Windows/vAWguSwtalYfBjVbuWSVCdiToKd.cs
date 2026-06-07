using System;
using System.Runtime.InteropServices;

internal class vAWguSwtalYfBjVbuWSVCdiToKd : FgWgxCSfHbOCKeqhjQMaYTLjaRh, vOKuLqUuTXkMszTugCpPmUUGfmr
{
	public vAWguSwtalYfBjVbuWSVCdiToKd(IntPtr pointer)
		: base(pointer)
	{
	}

	public vAWguSwtalYfBjVbuWSVCdiToKd(object iunknowObject)
	{
		base.NativePointer = Marshal.GetIUnknownForObject(iunknowObject);
	}

	protected vAWguSwtalYfBjVbuWSVCdiToKd()
	{
	}

	public virtual void liKDUtlOrAMUiVyLSCKzaVdnfNV(Guid P_0, out IntPtr P_1)
	{
		((vOKuLqUuTXkMszTugCpPmUUGfmr)this).liKDUtlOrAMUiVyLSCKzaVdnfNV(ref P_0, out P_1).zHpTMwuToxnnciRWweSPaClPGJQ();
	}

	public virtual IntPtr sEFSYdiBSuFFQaMliWKzwLWNErx(Guid P_0)
	{
		IntPtr zero = IntPtr.Zero;
		((vOKuLqUuTXkMszTugCpPmUUGfmr)this).liKDUtlOrAMUiVyLSCKzaVdnfNV(ref P_0, out zero);
		return zero;
	}

	public static bool mPeBkcNSFmKaodOmYgQYFJoFsQvG<T>(T P_0, T P_1) where T : vAWguSwtalYfBjVbuWSVCdiToKd
	{
		if (object.Equals(P_0, P_1))
		{
			return true;
		}
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		return P_0.NativePointer == P_1.NativePointer;
	}

	public virtual T liKDUtlOrAMUiVyLSCKzaVdnfNV<T>() where T : vAWguSwtalYfBjVbuWSVCdiToKd
	{
		liKDUtlOrAMUiVyLSCKzaVdnfNV(JOFzuBXkNUfGEywCsKAgVeZrrPQ.xIzFKzBrScusgIgzonXSDEIBBjBl(typeof(T)), out var intPtr);
		return FgWgxCSfHbOCKeqhjQMaYTLjaRh.WxliJmcswjjTPTiIBOtybNDHdQxj<T>(intPtr);
	}

	internal virtual T emrCywFXWbyrZmCDvXqlMlrTNAd<T>()
	{
		liKDUtlOrAMUiVyLSCKzaVdnfNV(JOFzuBXkNUfGEywCsKAgVeZrrPQ.xIzFKzBrScusgIgzonXSDEIBBjBl(typeof(T)), out var intPtr);
		return FgWgxCSfHbOCKeqhjQMaYTLjaRh.tJhGdlzLWNGqXPfwgQxBwgHbCTo<T>(intPtr);
	}

	public static T XfFjEfjbaPbhAdXIFtDUgYESCQXo<T>(object P_0) where T : vAWguSwtalYfBjVbuWSVCdiToKd
	{
		using vAWguSwtalYfBjVbuWSVCdiToKd vAWguSwtalYfBjVbuWSVCdiToKd2 = new vAWguSwtalYfBjVbuWSVCdiToKd(Marshal.GetIUnknownForObject(P_0));
		return vAWguSwtalYfBjVbuWSVCdiToKd2.liKDUtlOrAMUiVyLSCKzaVdnfNV<T>();
	}

	public static T XfFjEfjbaPbhAdXIFtDUgYESCQXo<T>(IntPtr P_0) where T : vAWguSwtalYfBjVbuWSVCdiToKd
	{
		using vAWguSwtalYfBjVbuWSVCdiToKd vAWguSwtalYfBjVbuWSVCdiToKd2 = new vAWguSwtalYfBjVbuWSVCdiToKd(P_0);
		return vAWguSwtalYfBjVbuWSVCdiToKd2.liKDUtlOrAMUiVyLSCKzaVdnfNV<T>();
	}

	internal static T ZndpgsEbeCNOGvrAfGvSUzRUdNQ<T>(IntPtr P_0)
	{
		using vAWguSwtalYfBjVbuWSVCdiToKd vAWguSwtalYfBjVbuWSVCdiToKd2 = new vAWguSwtalYfBjVbuWSVCdiToKd(P_0);
		return vAWguSwtalYfBjVbuWSVCdiToKd2.emrCywFXWbyrZmCDvXqlMlrTNAd<T>();
	}

	public static T liKDUtlOrAMUiVyLSCKzaVdnfNV<T>(object P_0) where T : vAWguSwtalYfBjVbuWSVCdiToKd
	{
		using vAWguSwtalYfBjVbuWSVCdiToKd vAWguSwtalYfBjVbuWSVCdiToKd2 = new vAWguSwtalYfBjVbuWSVCdiToKd(Marshal.GetIUnknownForObject(P_0));
		return vAWguSwtalYfBjVbuWSVCdiToKd2.liKDUtlOrAMUiVyLSCKzaVdnfNV<T>();
	}

	public static T sEFSYdiBSuFFQaMliWKzwLWNErx<T>(IntPtr P_0) where T : vAWguSwtalYfBjVbuWSVCdiToKd
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		Guid iid = JOFzuBXkNUfGEywCsKAgVeZrrPQ.xIzFKzBrScusgIgzonXSDEIBBjBl(typeof(T));
		if (!((cTKAHZacuViBRtnMbZwDuEpUfDCh)Marshal.QueryInterface(P_0, ref iid, out var ppv)).Failure)
		{
			return FgWgxCSfHbOCKeqhjQMaYTLjaRh.tJhGdlzLWNGqXPfwgQxBwgHbCTo<T>(ppv);
		}
		return null;
	}

	public virtual T sEFSYdiBSuFFQaMliWKzwLWNErx<T>() where T : vAWguSwtalYfBjVbuWSVCdiToKd
	{
		return FgWgxCSfHbOCKeqhjQMaYTLjaRh.WxliJmcswjjTPTiIBOtybNDHdQxj<T>(sEFSYdiBSuFFQaMliWKzwLWNErx(JOFzuBXkNUfGEywCsKAgVeZrrPQ.xIzFKzBrScusgIgzonXSDEIBBjBl(typeof(T))));
	}

	public static explicit operator vAWguSwtalYfBjVbuWSVCdiToKd(IntPtr nativePointer)
	{
		if (!(nativePointer == IntPtr.Zero))
		{
			return new vAWguSwtalYfBjVbuWSVCdiToKd(nativePointer);
		}
		return null;
	}

	protected void vhpPSLWJnpbEipOWzlXRgZrHsNu<T>(T P_0) where T : vAWguSwtalYfBjVbuWSVCdiToKd
	{
		P_0.liKDUtlOrAMUiVyLSCKzaVdnfNV(JOFzuBXkNUfGEywCsKAgVeZrrPQ.xIzFKzBrScusgIgzonXSDEIBBjBl(GetType()), out var nativePointer);
		base.NativePointer = nativePointer;
	}

	private cTKAHZacuViBRtnMbZwDuEpUfDCh jJcpjElTiUnpHTvAxZLDEigjXmY(ref Guid P_0, out IntPtr P_1)
	{
		return Marshal.QueryInterface(base.NativePointer, ref P_0, out P_1);
	}

	cTKAHZacuViBRtnMbZwDuEpUfDCh vOKuLqUuTXkMszTugCpPmUUGfmr.liKDUtlOrAMUiVyLSCKzaVdnfNV(ref Guid P_0, out IntPtr P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in jJcpjElTiUnpHTvAxZLDEigjXmY
		return this.jJcpjElTiUnpHTvAxZLDEigjXmY(ref P_0, out P_1);
	}

	private int dwZLIjInoOZMzZqllkWgLgVRUUx()
	{
		if (base.NativePointer == IntPtr.Zero)
		{
			throw new InvalidOperationException("COM Object pointer is null");
		}
		return Marshal.AddRef(base.NativePointer);
	}

	int vOKuLqUuTXkMszTugCpPmUUGfmr.nVoJCbciWVkJFfzNgiHutojiwOL()
	{
		//ILSpy generated this explicit interface implementation from .override directive in dwZLIjInoOZMzZqllkWgLgVRUUx
		return this.dwZLIjInoOZMzZqllkWgLgVRUUx();
	}

	private int rQwhgqMleyUkzsAInwRkrLDwilVJ()
	{
		if (base.NativePointer == IntPtr.Zero)
		{
			throw new InvalidOperationException("COM Object pointer is null");
		}
		return Marshal.Release(base.NativePointer);
	}

	int vOKuLqUuTXkMszTugCpPmUUGfmr.YhGqcOYjANTtgKCQfFoFiVfqeBpx()
	{
		//ILSpy generated this explicit interface implementation from .override directive in rQwhgqMleyUkzsAInwRkrLDwilVJ
		return this.rQwhgqMleyUkzsAInwRkrLDwilVJ();
	}

	protected unsafe override void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (base.NativePointer != IntPtr.Zero)
		{
			if (!P_0 && VvwRDTUEfmYWLWuKYFjraCAuDAU.WESEwwZLsWKZQdQZQzvyzprzYKM && !VvwRDTUEfmYWLWuKYFjraCAuDAU.FINdwJArmHXtMUrVvlJaASUHMNsA)
			{
				HWqjatSQvvhmhmpIMFgflakwrbY.PYgQmrazoUqWjrASzZcCXOaxeza(this);
			}
			if (P_0 || VvwRDTUEfmYWLWuKYFjraCAuDAU.FINdwJArmHXtMUrVvlJaASUHMNsA)
			{
				((vOKuLqUuTXkMszTugCpPmUUGfmr)this).YhGqcOYjANTtgKCQfFoFiVfqeBpx();
			}
			if (VvwRDTUEfmYWLWuKYFjraCAuDAU.VGiFlLPKbNcEFwCSgLfnkweQlpV)
			{
				HWqjatSQvvhmhmpIMFgflakwrbY.WfCrOuCOoWfyDgfUgQgODmMVQMCq(this);
			}
			fRSdJIinkkjfuOwZLyQSrdGfQnO = null;
		}
		base.KRgasgBmyLeCeDGJhNGqwMeOqCwJ(P_0);
	}

	protected override void hajdtxuRNKFMJtRoePiOlVhbcEI()
	{
		if (VvwRDTUEfmYWLWuKYFjraCAuDAU.VGiFlLPKbNcEFwCSgLfnkweQlpV)
		{
			HWqjatSQvvhmhmpIMFgflakwrbY.WfCrOuCOoWfyDgfUgQgODmMVQMCq(this);
		}
	}

	protected override void YjQaFefqGrnqqqeiNUAuRzgYbMt(IntPtr P_0)
	{
		if (VvwRDTUEfmYWLWuKYFjraCAuDAU.VGiFlLPKbNcEFwCSgLfnkweQlpV)
		{
			HWqjatSQvvhmhmpIMFgflakwrbY.BaaZGrZPjDGsbzqUnzGZVCDlRPs(this);
		}
	}
}
