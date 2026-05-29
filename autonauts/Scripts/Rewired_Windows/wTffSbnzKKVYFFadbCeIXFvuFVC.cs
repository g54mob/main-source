using System;
using System.Runtime.InteropServices;

internal class wTffSbnzKKVYFFadbCeIXFvuFVC : CndQdhRoXYCqAIOwkhIvRMCMVjY, gPbOONVObkswwBnmjltGtATrtiA
{
	public wTffSbnzKKVYFFadbCeIXFvuFVC(IntPtr pointer)
		: base(pointer)
	{
	}

	public wTffSbnzKKVYFFadbCeIXFvuFVC(object iunknowObject)
	{
		base.NativePointer = Marshal.GetIUnknownForObject(iunknowObject);
	}

	protected wTffSbnzKKVYFFadbCeIXFvuFVC()
	{
	}

	public virtual void mdlFdUwPptifehaTBGIgrlgAsOq(Guid P_0, out IntPtr P_1)
	{
		((gPbOONVObkswwBnmjltGtATrtiA)this).QueryInterface(ref P_0, out P_1).moUKMvtdvMYFxCOFvigNjjXmpVy();
	}

	public virtual IntPtr rLkQPErYrVjfEYEWhmMencIkdXSe(Guid P_0)
	{
		IntPtr zero = IntPtr.Zero;
		((gPbOONVObkswwBnmjltGtATrtiA)this).QueryInterface(ref P_0, out zero);
		return zero;
	}

	public static bool jqPdhLKIfXdAiPXaVdMZzCvcOZSS<T>(T P_0, T P_1) where T : wTffSbnzKKVYFFadbCeIXFvuFVC
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

	public virtual T mdlFdUwPptifehaTBGIgrlgAsOq<T>() where T : wTffSbnzKKVYFFadbCeIXFvuFVC
	{
		IntPtr intPtr;
		mdlFdUwPptifehaTBGIgrlgAsOq(QiyhMeApbloIAQYCjGAvUEQIhAz.eJGRPSwwoFMekYKtfHcXZcReBes(typeof(T)), out intPtr);
		return CndQdhRoXYCqAIOwkhIvRMCMVjY.ZScGNopAWKvTUpCYGztYcWeFDEh<T>(intPtr);
	}

	internal virtual T fMAEtVjYmGXCLtITkaBwPZigZAKD<T>()
	{
		IntPtr intPtr;
		mdlFdUwPptifehaTBGIgrlgAsOq(QiyhMeApbloIAQYCjGAvUEQIhAz.eJGRPSwwoFMekYKtfHcXZcReBes(typeof(T)), out intPtr);
		return CndQdhRoXYCqAIOwkhIvRMCMVjY.ckWaMRwiVoiNozoedQSIbSIESVJ<T>(intPtr);
	}

	public static T UfaaNEskYeGHQjnAeGPJHaFfsFk<T>(object P_0) where T : wTffSbnzKKVYFFadbCeIXFvuFVC
	{
		using (wTffSbnzKKVYFFadbCeIXFvuFVC wTffSbnzKKVYFFadbCeIXFvuFVC2 = new wTffSbnzKKVYFFadbCeIXFvuFVC(Marshal.GetIUnknownForObject(P_0)))
		{
			return wTffSbnzKKVYFFadbCeIXFvuFVC2.mdlFdUwPptifehaTBGIgrlgAsOq<T>();
		}
	}

	public static T UfaaNEskYeGHQjnAeGPJHaFfsFk<T>(IntPtr P_0) where T : wTffSbnzKKVYFFadbCeIXFvuFVC
	{
		using (wTffSbnzKKVYFFadbCeIXFvuFVC wTffSbnzKKVYFFadbCeIXFvuFVC2 = new wTffSbnzKKVYFFadbCeIXFvuFVC(P_0))
		{
			return wTffSbnzKKVYFFadbCeIXFvuFVC2.mdlFdUwPptifehaTBGIgrlgAsOq<T>();
		}
	}

	internal static T CnEjvRBKIdgvOFFEcrlRVZCxYUv<T>(IntPtr P_0)
	{
		using (wTffSbnzKKVYFFadbCeIXFvuFVC wTffSbnzKKVYFFadbCeIXFvuFVC2 = new wTffSbnzKKVYFFadbCeIXFvuFVC(P_0))
		{
			return wTffSbnzKKVYFFadbCeIXFvuFVC2.fMAEtVjYmGXCLtITkaBwPZigZAKD<T>();
		}
	}

	public static T mdlFdUwPptifehaTBGIgrlgAsOq<T>(object P_0) where T : wTffSbnzKKVYFFadbCeIXFvuFVC
	{
		using (wTffSbnzKKVYFFadbCeIXFvuFVC wTffSbnzKKVYFFadbCeIXFvuFVC2 = new wTffSbnzKKVYFFadbCeIXFvuFVC(Marshal.GetIUnknownForObject(P_0)))
		{
			return wTffSbnzKKVYFFadbCeIXFvuFVC2.mdlFdUwPptifehaTBGIgrlgAsOq<T>();
		}
	}

	public static T rLkQPErYrVjfEYEWhmMencIkdXSe<T>(IntPtr P_0) where T : wTffSbnzKKVYFFadbCeIXFvuFVC
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		Guid iid = QiyhMeApbloIAQYCjGAvUEQIhAz.eJGRPSwwoFMekYKtfHcXZcReBes(typeof(T));
		IntPtr ppv;
		if (!((hbpFHugbKyodFCJCiZcKFruzcGvs)Marshal.QueryInterface(P_0, ref iid, out ppv)).Failure)
		{
			return CndQdhRoXYCqAIOwkhIvRMCMVjY.ckWaMRwiVoiNozoedQSIbSIESVJ<T>(ppv);
		}
		return null;
	}

	public virtual T rLkQPErYrVjfEYEWhmMencIkdXSe<T>() where T : wTffSbnzKKVYFFadbCeIXFvuFVC
	{
		return CndQdhRoXYCqAIOwkhIvRMCMVjY.ZScGNopAWKvTUpCYGztYcWeFDEh<T>(rLkQPErYrVjfEYEWhmMencIkdXSe(QiyhMeApbloIAQYCjGAvUEQIhAz.eJGRPSwwoFMekYKtfHcXZcReBes(typeof(T))));
	}

	public static explicit operator wTffSbnzKKVYFFadbCeIXFvuFVC(IntPtr nativePointer)
	{
		if (!(nativePointer == IntPtr.Zero))
		{
			return new wTffSbnzKKVYFFadbCeIXFvuFVC(nativePointer);
		}
		return null;
	}

	protected void yOUkStBRhYTJIRPAmUfAluQctfi<T>(T P_0) where T : wTffSbnzKKVYFFadbCeIXFvuFVC
	{
		IntPtr nativePointer;
		P_0.mdlFdUwPptifehaTBGIgrlgAsOq(QiyhMeApbloIAQYCjGAvUEQIhAz.eJGRPSwwoFMekYKtfHcXZcReBes(GetType()), out nativePointer);
		base.NativePointer = nativePointer;
	}

	hbpFHugbKyodFCJCiZcKFruzcGvs gPbOONVObkswwBnmjltGtATrtiA.QueryInterface(ref Guid P_0, out IntPtr P_1)
	{
		return Marshal.QueryInterface(base.NativePointer, ref P_0, out P_1);
	}

	int gPbOONVObkswwBnmjltGtATrtiA.AddReference()
	{
		if (base.NativePointer == IntPtr.Zero)
		{
			throw new InvalidOperationException("COM Object pointer is null");
		}
		return Marshal.AddRef(base.NativePointer);
	}

	int gPbOONVObkswwBnmjltGtATrtiA.Release()
	{
		if (base.NativePointer == IntPtr.Zero)
		{
			throw new InvalidOperationException("COM Object pointer is null");
		}
		return Marshal.Release(base.NativePointer);
	}

	protected unsafe override void Dispose(bool P_0)
	{
		if (base.NativePointer != IntPtr.Zero)
		{
			if (!P_0 && CuHnMkVeNLwsFgNOTqJgvbDRMVd.NLtsPNOZUpekODbZZcxzGosCwLhs && !CuHnMkVeNLwsFgNOTqJgvbDRMVd.UcaevauZSgMRMFfDwOBlFCBoYCH)
			{
				OZjnAJDBaYEdCGKUNigSwfsHazW.QYDfLSnALpsGfPExecRVCpKKeSN(this);
			}
			if (P_0 || CuHnMkVeNLwsFgNOTqJgvbDRMVd.UcaevauZSgMRMFfDwOBlFCBoYCH)
			{
				((gPbOONVObkswwBnmjltGtATrtiA)this).Release();
			}
			if (CuHnMkVeNLwsFgNOTqJgvbDRMVd.MgNQMuWOaeiYLcQIflDkFpzlLwoZ)
			{
				OZjnAJDBaYEdCGKUNigSwfsHazW.PEzDlLROdbMfXTAEvglZxWJmRyz(this);
			}
			oQrDIzabSXnJeReNAUCNWaVKrkpV = null;
		}
		base.Dispose(P_0);
	}

	protected override void NativePointerUpdating()
	{
		if (CuHnMkVeNLwsFgNOTqJgvbDRMVd.MgNQMuWOaeiYLcQIflDkFpzlLwoZ)
		{
			OZjnAJDBaYEdCGKUNigSwfsHazW.PEzDlLROdbMfXTAEvglZxWJmRyz(this);
		}
	}

	protected override void NativePointerUpdated(IntPtr P_0)
	{
		if (CuHnMkVeNLwsFgNOTqJgvbDRMVd.MgNQMuWOaeiYLcQIflDkFpzlLwoZ)
		{
			OZjnAJDBaYEdCGKUNigSwfsHazW.GtXDdMQtLaKpjPhCoCUMYnECXAH(this);
		}
	}
}
