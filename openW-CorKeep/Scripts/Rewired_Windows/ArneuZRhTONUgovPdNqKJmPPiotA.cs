using System;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class ArneuZRhTONUgovPdNqKJmPPiotA : IDisposable
{
	public delegate void KKKcyycAXsOaXIZWWBHrVmDBsSqS(IntPtr reportPointer, int reportByteLength, int reportCount, double timestamp);

	private const int rCsEDSvqHJJPJuLLzjVqZkkoYBqx = 512;

	private const int PRQcnymyAOnqoZMACYPngckQGIncA = 250;

	private readonly KKKcyycAXsOaXIZWWBHrVmDBsSqS UtyZZAadVEVtWVMaTnTrvGMVARmF;

	private readonly YRwmGSQbMJjPfCvFvZWpMQELhPLC GdcuzIrdWtOOyRIXzBMbFdMBXemvA;

	private readonly ThreadHelper zGeWSavkzBVWjGloESTZzQIAjaNq;

	private readonly int JQZqCJCbEikplDZmxAfEHAjWFUmz;

	private readonly int gncFbqbturpqRNHiJnYAyREqCwGKA;

	private readonly string dRZoikQhAIaIXaNnKlXfdrwhbEgOc;

	private readonly byte[] plBCHakdNIMfoHxecZjLCLftctBZA;

	private readonly byte[] WAIzwDrEMSswVdMuZhEkZipJkmyc;

	private int mTZBFuHQAguoeGeclWIfPhrWOUnhA;

	private jCIiucNiFgpCzJLbdfgxfzvgbTvgA lpehcUxrYeHvjxzeMPTKusPWcVjy;

	private jCIiucNiFgpCzJLbdfgxfzvgbTvgA QNygmDspbaSsyTALMagTIcwIYvOT;

	private bool mgYZyelgbgNUVOVvzTdrDaHHQkky;

	public ArneuZRhTONUgovPdNqKJmPPiotA(string P_0, int P_1, string P_2, KKKcyycAXsOaXIZWWBHrVmDBsSqS P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("hidDevicePath");
		}
		if (P_3 == null)
		{
			throw new ArgumentNullException("processReportDelegate");
		}
		gncFbqbturpqRNHiJnYAyREqCwGKA = P_1;
		if (gncFbqbturpqRNHiJnYAyREqCwGKA <= 0)
		{
			gncFbqbturpqRNHiJnYAyREqCwGKA = 512;
		}
		JQZqCJCbEikplDZmxAfEHAjWFUmz = P_1 + 8;
		dRZoikQhAIaIXaNnKlXfdrwhbEgOc = P_2;
		UtyZZAadVEVtWVMaTnTrvGMVARmF = P_3;
		int num = JQZqCJCbEikplDZmxAfEHAjWFUmz * 60;
		if (num <= 0)
		{
			Logger.LogError("Invalid report buffer size. This device \"" + P_2 + "\" will not function.");
			throw new Exception();
		}
		try
		{
			GdcuzIrdWtOOyRIXzBMbFdMBXemvA = new YRwmGSQbMJjPfCvFvZWpMQELhPLC(P_0, P_1, 250);
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			lpehcUxrYeHvjxzeMPTKusPWcVjy = new jCIiucNiFgpCzJLbdfgxfzvgbTvgA(num);
			QNygmDspbaSsyTALMagTIcwIYvOT = new jCIiucNiFgpCzJLbdfgxfzvgbTvgA(num);
			plBCHakdNIMfoHxecZjLCLftctBZA = new byte[JQZqCJCbEikplDZmxAfEHAjWFUmz];
			WAIzwDrEMSswVdMuZhEkZipJkmyc = new byte[JQZqCJCbEikplDZmxAfEHAjWFUmz];
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			zGeWSavkzBVWjGloESTZzQIAjaNq = ThreadHelper.Create();
			zGeWSavkzBVWjGloESTZzQIAjaNq.ThreadUpdateEvent += TZmCdtIDPDKsCpCCVfRpHxPvJRZU;
			zGeWSavkzBVWjGloESTZzQIAjaNq.Start(wait: false);
		}
		catch (Exception)
		{
			Logger.LogError("Error creating thread. This device \"" + P_2 + "\" will not function.");
			throw;
		}
	}

	public unsafe void YilWdqlrzQVQOqYHvCZznRYlQHD()
	{
		try
		{
			if (AGwQloLvVOuGiHsTldceUbsgAKHY())
			{
				return;
			}
			aofBWdVkSfAiZxkYXVSQtUxoLgdi();
			int num = 0;
			byte[] array = plBCHakdNIMfoHxecZjLCLftctBZA;
			fixed (byte* ptr = array)
			{
				while (lpehcUxrYeHvjxzeMPTKusPWcVjy.YHOBImUOKoqcIKRmPnKNzdGOjZUX(array, JQZqCJCbEikplDZmxAfEHAjWFUmz) > 0)
				{
					UtyZZAadVEVtWVMaTnTrvGMVARmF((IntPtr)ptr, gncFbqbturpqRNHiJnYAyREqCwGKA, 1, *(double*)(ptr + gncFbqbturpqRNHiJnYAyREqCwGKA));
					num++;
				}
			}
		}
		catch
		{
		}
	}

	private void aofBWdVkSfAiZxkYXVSQtUxoLgdi()
	{
		lock (lpehcUxrYeHvjxzeMPTKusPWcVjy)
		{
			lock (QNygmDspbaSsyTALMagTIcwIYvOT)
			{
				MiscTools.Swap(ref lpehcUxrYeHvjxzeMPTKusPWcVjy, ref QNygmDspbaSsyTALMagTIcwIYvOT);
			}
		}
	}

	private void TZmCdtIDPDKsCpCCVfRpHxPvJRZU()
	{
		if (mTZBFuHQAguoeGeclWIfPhrWOUnhA != 0)
		{
			Thread.Sleep(500);
			return;
		}
		try
		{
			byte[] wAIzwDrEMSswVdMuZhEkZipJkmyc = WAIzwDrEMSswVdMuZhEkZipJkmyc;
			if (!QMvKTDKlPaoLlazjtDXZxsbaCKTD(wAIzwDrEMSswVdMuZhEkZipJkmyc))
			{
				return;
			}
			lock (QNygmDspbaSsyTALMagTIcwIYvOT)
			{
				QNygmDspbaSsyTALMagTIcwIYvOT.HfCOiCGsagcekRGFseGiJZvFKEDS(wAIzwDrEMSswVdMuZhEkZipJkmyc, wAIzwDrEMSswVdMuZhEkZipJkmyc.Length);
			}
		}
		catch
		{
		}
	}

	private bool QMvKTDKlPaoLlazjtDXZxsbaCKTD(byte[] P_0)
	{
		switch (GdcuzIrdWtOOyRIXzBMbFdMBXemvA.nkEYpKWTrRaNxPXahvFBThCUhBVy(P_0))
		{
		case YRwmGSQbMJjPfCvFvZWpMQELhPLC.dsBQuquASkcclcamBtgOtBcfEzwMA.Success:
			return true;
		case YRwmGSQbMJjPfCvFvZWpMQELhPLC.dsBQuquASkcclcamBtgOtBcfEzwMA.Error:
			Thread.Sleep(500);
			break;
		case YRwmGSQbMJjPfCvFvZWpMQELhPLC.dsBQuquASkcclcamBtgOtBcfEzwMA.CriticalError:
			mTZBFuHQAguoeGeclWIfPhrWOUnhA = 1;
			break;
		}
		return false;
	}

	private bool AGwQloLvVOuGiHsTldceUbsgAKHY()
	{
		if (mTZBFuHQAguoeGeclWIfPhrWOUnhA != 0)
		{
			if (mTZBFuHQAguoeGeclWIfPhrWOUnhA == 1)
			{
				Logger.LogError("Error communicating with HID device. This device \"" + dRZoikQhAIaIXaNnKlXfdrwhbEgOc + "\" will not function.");
				mTZBFuHQAguoeGeclWIfPhrWOUnhA = 2;
				try
				{
					zGeWSavkzBVWjGloESTZzQIAjaNq.Stop(wait: false);
				}
				catch
				{
				}
			}
			return true;
		}
		return false;
	}

	public void Dispose()
	{
		xsMuuvFXQSCdUfuyMrDwtZCCUAXH(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void anrsdaZqceFnLdgxLgmAKPSmAcQiA()
	{
		try
		{
			xsMuuvFXQSCdUfuyMrDwtZCCUAXH(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void xsMuuvFXQSCdUfuyMrDwtZCCUAXH(bool P_0)
	{
		if (mgYZyelgbgNUVOVvzTdrDaHHQkky)
		{
			return;
		}
		if (P_0)
		{
			if (zGeWSavkzBVWjGloESTZzQIAjaNq != null)
			{
				zGeWSavkzBVWjGloESTZzQIAjaNq.Dispose();
			}
			if (GdcuzIrdWtOOyRIXzBMbFdMBXemvA != null)
			{
				GdcuzIrdWtOOyRIXzBMbFdMBXemvA.Dispose();
			}
		}
		mgYZyelgbgNUVOVvzTdrDaHHQkky = true;
	}
}
