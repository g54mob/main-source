using System;
using System.Runtime.CompilerServices;

internal struct bppzUMfHYaaKkmhJvTLXUKJAsLl
{
	public IntPtr UdOaQKIUzemBrlkcmDTMEJLHkeko;

	private IntPtr kdhQtgOWxaJVWPRiXINYzbJIKil;

	private int thqpkLNWmGWBqKEUljjbAeRUCISc;

	public int DsrADThdkIpdIsTRXpmynAoAlaK;

	public int ihzsSYSJIANMfliVGXdPBmBKJbN;

	internal bool IsValid
	{
		get
		{
			if (thqpkLNWmGWBqKEUljjbAeRUCISc > 0)
			{
				return kdhQtgOWxaJVWPRiXINYzbJIKil != IntPtr.Zero;
			}
			return false;
		}
	}

	public IntPtr RawDataPtr => kdhQtgOWxaJVWPRiXINYzbJIKil;

	public int RawDataBytes => thqpkLNWmGWBqKEUljjbAeRUCISc;

	internal unsafe bppzUMfHYaaKkmhJvTLXUKJAsLl(ref arkOMRMkUkHvASjfJYFFLEtfKOm rawInput, yGDpJcSWtmEtudcouWqSeUlkaZd memQueue)
	{
		UdOaQKIUzemBrlkcmDTMEJLHkeko = rawInput.jeNBnEYVeHknokaDleDPusHoPpo.UdOaQKIUzemBrlkcmDTMEJLHkeko;
		DsrADThdkIpdIsTRXpmynAoAlaK = rawInput.zcrLsgWlluAxuaCfKiqkzQcyEEv.DLicOdRYvURWQSMtilIWDcxKExe.DsrADThdkIpdIsTRXpmynAoAlaK;
		ihzsSYSJIANMfliVGXdPBmBKJbN = rawInput.zcrLsgWlluAxuaCfKiqkzQcyEEv.DLicOdRYvURWQSMtilIWDcxKExe.LfCUuuLLCnvWjXivBKcjqbmgPyx;
		thqpkLNWmGWBqKEUljjbAeRUCISc = DsrADThdkIpdIsTRXpmynAoAlaK * ihzsSYSJIANMfliVGXdPBmBKJbN;
		if (thqpkLNWmGWBqKEUljjbAeRUCISc > 0)
		{
			fixed (IntPtr* ejWbnbhZptGnNWWUgCgDWnMeoEU = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref rawInput.zcrLsgWlluAxuaCfKiqkzQcyEEv.DLicOdRYvURWQSMtilIWDcxKExe.ejWbnbhZptGnNWWUgCgDWnMeoEU))
			{
				kdhQtgOWxaJVWPRiXINYzbJIKil = memQueue.aBXKlqdeXmyNlMpjIGSxjikZDLlO((uint)thqpkLNWmGWBqKEUljjbAeRUCISc, ejWbnbhZptGnNWWUgCgDWnMeoEU);
			}
		}
		else
		{
			kdhQtgOWxaJVWPRiXINYzbJIKil = IntPtr.Zero;
		}
	}
}
