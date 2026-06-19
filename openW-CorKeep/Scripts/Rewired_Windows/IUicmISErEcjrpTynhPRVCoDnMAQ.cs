using System;
using Rewired;
using Rewired.Platforms.Microsoft.WindowsGamingInput;

internal sealed class IUicmISErEcjrpTynhPRVCoDnMAQ : enOTfxHYpbapfAkzTEjUfpeMjnWTA
{
	private const int mXKbBQhdneOdanClhWjVGoaZRpMkA = 14;

	private const int apyAYUHEEWubqIzvaoJroTuavWUf = 6;

	private const int KfUrTTLbBcNkrwbbnexPbSQxOnV = 0;

	private const int ulsocgphIfkaWziCdNpeiVnMdCog = 4;

	private const bool PpaQxywBomboCmLMJvDQzmhbNIrT = true;

	private jPxdIFDnOkTonljyRaQphHTzlDNB gKjpoSBOCrPaysEydzKqVviOVLJP;

	private PnWZbRpKCvwNHCKoFStsrOitTtdC hACNayCHtnpxXwgEPvuLbtknUkbw;

	private PnWZbRpKCvwNHCKoFStsrOitTtdC oCAgBZIkwtCFAcdpFJWgzMuCXvkWB;

	private double FUxPkZVSWLgLGilXplhWZEFImeCg;

	private bool KnBBFXNZZYdvYyjCeKJRMxoDxDYR;

	private double hAPTyvVzmWrHIgJrxoFpaizmKyQq;

	private Action<jPxdIFDnOkTonljyRaQphHTzlDNB, PnWZbRpKCvwNHCKoFStsrOitTtdC> ulOwbTnwCsWynEIlNQZGpUhZBCjA;

	public jPxdIFDnOkTonljyRaQphHTzlDNB PFjTpLsFCCfACBZhuAncIRyMiMBrA => gKjpoSBOCrPaysEydzKqVviOVLJP;

	bool enOTfxHYpbapfAkzTEjUfpeMjnWTA.YKHgWtXHnzKtfxYWBRJiWiTKmVKc => true;

	int enOTfxHYpbapfAkzTEjUfpeMjnWTA.uNZlJEPrenlWUhFkhZeOQpFMHbbc => 4;

	public IUicmISErEcjrpTynhPRVCoDnMAQ(jPxdIFDnOkTonljyRaQphHTzlDNB P_0, int P_1, Action<jPxdIFDnOkTonljyRaQphHTzlDNB, PnWZbRpKCvwNHCKoFStsrOitTtdC> P_2)
		: base(WGIDeviceType.Gamepad, P_0, P_1, 14, 6, 0)
	{
		if (jPxdIFDnOkTonljyRaQphHTzlDNB.tvIHWdMiscXDqBHRJsYWZGOFUrad(P_0, null))
		{
			throw new ArgumentNullException("gamepad");
		}
		if (P_2 == null)
		{
			throw new ArgumentNullException("commitVibrationDelegate");
		}
		gKjpoSBOCrPaysEydzKqVviOVLJP = P_0;
		ulOwbTnwCsWynEIlNQZGpUhZBCjA = P_2;
	}

	public void fyELHMXiRZejmUTvmheMTiOxqOXF(UEhDjvAzZPVreaJMknILCleqWCHcA P_0, double P_1)
	{
		eaHYyeZhPOdJoTRBZOYhzuZBZLEE.SetValue(0, (P_0.ojmbDbIHbbRGJJwfKUZLCJSNDwaM & GamepadButtons.A) != 0, P_1);
		eaHYyeZhPOdJoTRBZOYhzuZBZLEE.SetValue(1, (P_0.ojmbDbIHbbRGJJwfKUZLCJSNDwaM & GamepadButtons.B) != 0, P_1);
		eaHYyeZhPOdJoTRBZOYhzuZBZLEE.SetValue(2, (P_0.ojmbDbIHbbRGJJwfKUZLCJSNDwaM & GamepadButtons.X) != 0, P_1);
		eaHYyeZhPOdJoTRBZOYhzuZBZLEE.SetValue(3, (P_0.ojmbDbIHbbRGJJwfKUZLCJSNDwaM & GamepadButtons.Y) != 0, P_1);
		eaHYyeZhPOdJoTRBZOYhzuZBZLEE.SetValue(4, (P_0.ojmbDbIHbbRGJJwfKUZLCJSNDwaM & GamepadButtons.LeftShoulder) != 0, P_1);
		eaHYyeZhPOdJoTRBZOYhzuZBZLEE.SetValue(5, (P_0.ojmbDbIHbbRGJJwfKUZLCJSNDwaM & GamepadButtons.RightShoulder) != 0, P_1);
		eaHYyeZhPOdJoTRBZOYhzuZBZLEE.SetValue(6, (P_0.ojmbDbIHbbRGJJwfKUZLCJSNDwaM & GamepadButtons.View) != 0, P_1);
		eaHYyeZhPOdJoTRBZOYhzuZBZLEE.SetValue(7, (P_0.ojmbDbIHbbRGJJwfKUZLCJSNDwaM & GamepadButtons.Menu) != 0, P_1);
		eaHYyeZhPOdJoTRBZOYhzuZBZLEE.SetValue(8, (P_0.ojmbDbIHbbRGJJwfKUZLCJSNDwaM & GamepadButtons.LeftThumbstick) != 0, P_1);
		eaHYyeZhPOdJoTRBZOYhzuZBZLEE.SetValue(9, (P_0.ojmbDbIHbbRGJJwfKUZLCJSNDwaM & GamepadButtons.RightThumbstick) != 0, P_1);
		eaHYyeZhPOdJoTRBZOYhzuZBZLEE.SetValue(10, (P_0.ojmbDbIHbbRGJJwfKUZLCJSNDwaM & GamepadButtons.DPadUp) != 0, P_1);
		eaHYyeZhPOdJoTRBZOYhzuZBZLEE.SetValue(11, (P_0.ojmbDbIHbbRGJJwfKUZLCJSNDwaM & GamepadButtons.DPadRight) != 0, P_1);
		eaHYyeZhPOdJoTRBZOYhzuZBZLEE.SetValue(12, (P_0.ojmbDbIHbbRGJJwfKUZLCJSNDwaM & GamepadButtons.DPadDown) != 0, P_1);
		eaHYyeZhPOdJoTRBZOYhzuZBZLEE.SetValue(13, (P_0.ojmbDbIHbbRGJJwfKUZLCJSNDwaM & GamepadButtons.DPadLeft) != 0, P_1);
		FKWYJHlMchXInWMCyWHovNuOgTDG[0].xNqjcsxSEPibyMcvuQfgeDgmJDaC = (float)P_0.rcDmnwEzdsAfHcETxvoWNSemgQWg;
		FKWYJHlMchXInWMCyWHovNuOgTDG[1].xNqjcsxSEPibyMcvuQfgeDgmJDaC = (float)P_0.lyuolFKMfJESyuKeYQHzUOoSMblW;
		FKWYJHlMchXInWMCyWHovNuOgTDG[2].xNqjcsxSEPibyMcvuQfgeDgmJDaC = (float)P_0.PxaNRbxnOWiIOnpMEFONfmjPQjGEA;
		FKWYJHlMchXInWMCyWHovNuOgTDG[3].xNqjcsxSEPibyMcvuQfgeDgmJDaC = (float)P_0.EdUJeuZhHWxzEMFpbpDJxIidekVR;
		FKWYJHlMchXInWMCyWHovNuOgTDG[4].xNqjcsxSEPibyMcvuQfgeDgmJDaC = (float)P_0.AjKMdhzqdiTBjpZBjgwYrSNJdNFU;
		FKWYJHlMchXInWMCyWHovNuOgTDG[5].xNqjcsxSEPibyMcvuQfgeDgmJDaC = (float)P_0.rKdfjbwlUCJuRHSNYepREsnBUVGD;
	}

	public void hKClbpZVTvUWoLWQSdqTvTdQpUtj(UpdateLoopType P_0)
	{
		base.ZMHOwCOpmODxTECrwVDbYvKvnlYo(P_0);
		ZmVaImANzYOLKXTRsumqbfwyALlr();
	}

	public void JnlDfVkogpwdtRrsOldUtVGtCqkqA(sFFXXFtEebhJcIFEaMaPQTQrWwKC P_0)
	{
		base.oqOJPpgmezzzXoVThFUcBCzrjQrg(P_0);
		if (P_0 is IUicmISErEcjrpTynhPRVCoDnMAQ uicmISErEcjrpTynhPRVCoDnMAQ)
		{
			gKjpoSBOCrPaysEydzKqVviOVLJP = uicmISErEcjrpTynhPRVCoDnMAQ.gKjpoSBOCrPaysEydzKqVviOVLJP;
		}
	}

	public float DrUUKnHuWzdChhrVtGVCAumdMSyU(int P_0)
	{
		PnWZbRpKCvwNHCKoFStsrOitTtdC pnWZbRpKCvwNHCKoFStsrOitTtdC = gKjpoSBOCrPaysEydzKqVviOVLJP.XiHevxeqEzXdyfHRcjuabBNsDGZk;
		return P_0 switch
		{
			0 => (float)pnWZbRpKCvwNHCKoFStsrOitTtdC.hodxYTXUQzFMwSNiJTIszeLFtJEg, 
			1 => (float)pnWZbRpKCvwNHCKoFStsrOitTtdC.HDhiBveRJjVYXSnPTOomLUAdWWsrA, 
			2 => (float)pnWZbRpKCvwNHCKoFStsrOitTtdC.pWZracdllSwKELuzLQeVZAeUPcny, 
			3 => (float)pnWZbRpKCvwNHCKoFStsrOitTtdC.hCWuPBcApbibXEVxerveeFthmNNEb, 
			_ => 0f, 
		};
	}

	public void nStmXoAjVsmubCWGoGrZwgLbgRdV(int P_0, float P_1, bool P_2)
	{
		if (P_0 >= 0 && P_0 < 4)
		{
			if (P_1 < 0f)
			{
				P_1 = 0f;
			}
			else if (P_1 > 1f)
			{
				P_1 = 1f;
			}
			if (P_2)
			{
				RUJFTsHUNRVwcuSZYJejtadzxqVOA(ref hACNayCHtnpxXwgEPvuLbtknUkbw);
			}
			switch (P_0)
			{
			case 0:
				hACNayCHtnpxXwgEPvuLbtknUkbw.hodxYTXUQzFMwSNiJTIszeLFtJEg = P_1;
				break;
			case 1:
				hACNayCHtnpxXwgEPvuLbtknUkbw.HDhiBveRJjVYXSnPTOomLUAdWWsrA = P_1;
				break;
			case 2:
				hACNayCHtnpxXwgEPvuLbtknUkbw.pWZracdllSwKELuzLQeVZAeUPcny = P_1;
				break;
			case 3:
				hACNayCHtnpxXwgEPvuLbtknUkbw.hCWuPBcApbibXEVxerveeFthmNNEb = P_1;
				break;
			}
			wBcidKMKGRjfHePtAHjLeBSJnpQfB(false);
		}
	}

	public void xjiMOSYhxRCeEdARKCCDXLOmKRvP()
	{
		RUJFTsHUNRVwcuSZYJejtadzxqVOA(ref hACNayCHtnpxXwgEPvuLbtknUkbw);
		wBcidKMKGRjfHePtAHjLeBSJnpQfB(true);
	}

	private void ZmVaImANzYOLKXTRsumqbfwyALlr()
	{
		if (KnBBFXNZZYdvYyjCeKJRMxoDxDYR)
		{
			tkyNxaaRaMYvLNbQYkIPdEYTixKO();
		}
		JiHxeQUhkoDaESbdRfrZNGryhGHA();
	}

	private void JiHxeQUhkoDaESbdRfrZNGryhGHA()
	{
		if (!(ReInput.unscaledTime < FUxPkZVSWLgLGilXplhWZEFImeCg) && BBQezLQwKBNffMTliKcBgmhTavbDA(ref hACNayCHtnpxXwgEPvuLbtknUkbw))
		{
			wBcidKMKGRjfHePtAHjLeBSJnpQfB(true);
		}
	}

	private void wBcidKMKGRjfHePtAHjLeBSJnpQfB(bool P_0)
	{
		KnBBFXNZZYdvYyjCeKJRMxoDxDYR = true;
		if (P_0)
		{
			AWizagRLFpecCKQtlrTsbiXIryQdA();
		}
	}

	private void tkyNxaaRaMYvLNbQYkIPdEYTixKO()
	{
		if (KnBBFXNZZYdvYyjCeKJRMxoDxDYR && !(ReInput.unscaledTime < hAPTyvVzmWrHIgJrxoFpaizmKyQq + 0.009999999776482582))
		{
			AWizagRLFpecCKQtlrTsbiXIryQdA();
		}
	}

	private void AWizagRLFpecCKQtlrTsbiXIryQdA()
	{
		if (!BBQezLQwKBNffMTliKcBgmhTavbDA(ref hACNayCHtnpxXwgEPvuLbtknUkbw) && !BBQezLQwKBNffMTliKcBgmhTavbDA(ref oCAgBZIkwtCFAcdpFJWgzMuCXvkWB))
		{
			KnBBFXNZZYdvYyjCeKJRMxoDxDYR = false;
			return;
		}
		ulOwbTnwCsWynEIlNQZGpUhZBCjA(gKjpoSBOCrPaysEydzKqVviOVLJP, hACNayCHtnpxXwgEPvuLbtknUkbw);
		double unscaledTime = ReInput.unscaledTime;
		FUxPkZVSWLgLGilXplhWZEFImeCg = unscaledTime + 1.5;
		hAPTyvVzmWrHIgJrxoFpaizmKyQq = unscaledTime;
		DNENUdtLIqgqpaLxZYaJopUCnrDP(ref hACNayCHtnpxXwgEPvuLbtknUkbw, ref oCAgBZIkwtCFAcdpFJWgzMuCXvkWB);
		KnBBFXNZZYdvYyjCeKJRMxoDxDYR = false;
	}

	private bool BBQezLQwKBNffMTliKcBgmhTavbDA(ref PnWZbRpKCvwNHCKoFStsrOitTtdC P_0)
	{
		if (P_0.hodxYTXUQzFMwSNiJTIszeLFtJEg > 0.0 || P_0.HDhiBveRJjVYXSnPTOomLUAdWWsrA > 0.0 || P_0.pWZracdllSwKELuzLQeVZAeUPcny > 0.0 || P_0.hCWuPBcApbibXEVxerveeFthmNNEb > 0.0)
		{
			return true;
		}
		return false;
	}

	private void RUJFTsHUNRVwcuSZYJejtadzxqVOA(ref PnWZbRpKCvwNHCKoFStsrOitTtdC P_0)
	{
		P_0.hodxYTXUQzFMwSNiJTIszeLFtJEg = 0.0;
		P_0.HDhiBveRJjVYXSnPTOomLUAdWWsrA = 0.0;
		P_0.pWZracdllSwKELuzLQeVZAeUPcny = 0.0;
		P_0.hCWuPBcApbibXEVxerveeFthmNNEb = 0.0;
	}

	private void DNENUdtLIqgqpaLxZYaJopUCnrDP(ref PnWZbRpKCvwNHCKoFStsrOitTtdC P_0, ref PnWZbRpKCvwNHCKoFStsrOitTtdC P_1)
	{
		P_1.hodxYTXUQzFMwSNiJTIszeLFtJEg = P_0.hodxYTXUQzFMwSNiJTIszeLFtJEg;
		P_1.HDhiBveRJjVYXSnPTOomLUAdWWsrA = P_0.HDhiBveRJjVYXSnPTOomLUAdWWsrA;
		P_1.pWZracdllSwKELuzLQeVZAeUPcny = P_0.pWZracdllSwKELuzLQeVZAeUPcny;
		P_1.hCWuPBcApbibXEVxerveeFthmNNEb = P_0.hCWuPBcApbibXEVxerveeFthmNNEb;
	}

	protected bool PVbaIdTXETwpYAyPpBNqSDYScFGkA(bool P_0)
	{
		if (base.sXlmrVhgGMETPcHmxsyVfEAbVYJs(P_0))
		{
			return true;
		}
		if (P_0 && jPxdIFDnOkTonljyRaQphHTzlDNB.atgPZerduFMPKEBVkUAstBvWrdbG(gKjpoSBOCrPaysEydzKqVviOVLJP, null))
		{
			try
			{
				gKjpoSBOCrPaysEydzKqVviOVLJP.XiHevxeqEzXdyfHRcjuabBNsDGZk = default(PnWZbRpKCvwNHCKoFStsrOitTtdC);
			}
			catch
			{
			}
		}
		return false;
	}
}
