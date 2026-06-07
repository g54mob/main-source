using System;
using System.Runtime.CompilerServices;

internal struct uAYVdHjoaOtSYwFnNuGXZtuOLmV
{
	public IntPtr ZWtEIVCLNCpVNyDISCnCWMsygkK;

	private IntPtr dWETSjOdJIopmZgMznHIsluWewB;

	private int qtHmtKTCKgzHEMaHRowbZwYCUOe;

	public int YqQgSSxjDeGHweRjvcaeaUtSPfk;

	public int fcUgsJEhpqEhkDbQnIYjZCBVQJTD;

	internal bool IsValid
	{
		get
		{
			if (qtHmtKTCKgzHEMaHRowbZwYCUOe > 0)
			{
				return dWETSjOdJIopmZgMznHIsluWewB != IntPtr.Zero;
			}
			return false;
		}
	}

	public IntPtr RawDataPtr
	{
		get
		{
			return dWETSjOdJIopmZgMznHIsluWewB;
		}
	}

	public int RawDataBytes
	{
		get
		{
			return qtHmtKTCKgzHEMaHRowbZwYCUOe;
		}
	}

	internal unsafe uAYVdHjoaOtSYwFnNuGXZtuOLmV(ref xkJqMOEQeGTfwKaRfpLTGoGtuOK rawInput, lFiejEYdgGxyJrBQGJZafnfsfab memQueue)
	{
		ZWtEIVCLNCpVNyDISCnCWMsygkK = rawInput.uXaSVNCSQvDOAiNhBrdVzRoycNS.ZWtEIVCLNCpVNyDISCnCWMsygkK;
		YqQgSSxjDeGHweRjvcaeaUtSPfk = rawInput.qUOmbTETUXuKZoTqSzcKuTsxCRK.CsRDsajDDilvqJMXGxgAJSWOLYSO.YqQgSSxjDeGHweRjvcaeaUtSPfk;
		fcUgsJEhpqEhkDbQnIYjZCBVQJTD = rawInput.qUOmbTETUXuKZoTqSzcKuTsxCRK.CsRDsajDDilvqJMXGxgAJSWOLYSO.OFjTUdRKyJeXBBRSrpTflnNyjTH;
		qtHmtKTCKgzHEMaHRowbZwYCUOe = YqQgSSxjDeGHweRjvcaeaUtSPfk * fcUgsJEhpqEhkDbQnIYjZCBVQJTD;
		if (qtHmtKTCKgzHEMaHRowbZwYCUOe > 0)
		{
			fixed (IntPtr* pvzflyetJLYBvhKmQojHbDnbeWqZ = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref rawInput.qUOmbTETUXuKZoTqSzcKuTsxCRK.CsRDsajDDilvqJMXGxgAJSWOLYSO.pvzflyetJLYBvhKmQojHbDnbeWqZ))
			{
				dWETSjOdJIopmZgMznHIsluWewB = memQueue.xVijxMtzmKdJKIZiwPverJmHDTc((uint)qtHmtKTCKgzHEMaHRowbZwYCUOe, pvzflyetJLYBvhKmQojHbDnbeWqZ);
			}
		}
		else
		{
			dWETSjOdJIopmZgMznHIsluWewB = IntPtr.Zero;
		}
	}
}
