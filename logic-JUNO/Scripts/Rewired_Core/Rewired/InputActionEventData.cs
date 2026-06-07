using System.Collections.Generic;

namespace Rewired
{
	public struct InputActionEventData
	{
		private pDpcIvKINqIAQeDxKXPLLXNhacXfb IaYDmvpQhLbpBiNBlFIjceiTdhsoA;

		private InputActionEventType emsUmYATQSNPPgxofbYLpyutqHvy;

		public readonly int playerId;

		public readonly int actionId;

		public readonly UpdateLoopType updateLoop;

		public InputActionEventType eventType
		{
			get
			{
				return emsUmYATQSNPPgxofbYLpyutqHvy;
			}
			internal set
			{
				emsUmYATQSNPPgxofbYLpyutqHvy = inputActionEventType;
			}
		}

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(playerId);
			}
		}

		public string actionName
		{
			get
			{
				if (!ReInput.isReady)
				{
					return string.Empty;
				}
				return ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.qeCoWwYQZyXOvrKpdOUYPOmlJAHl(actionId).name;
			}
		}

		public string actionDescriptiveName
		{
			get
			{
				if (!ReInput.isReady)
				{
					return string.Empty;
				}
				return ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.qeCoWwYQZyXOvrKpdOUYPOmlJAHl(actionId).descriptiveName;
			}
		}

		public float GetAxis()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.QoqRapVfNVFpGbfOnTBHEzMMMoAAA();
		}

		public float GetAxisPrev()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.uIZMyZpElPRhKSvEssphCHLzKWoT();
		}

		public float GetAxisDelta()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.KlhaTcfuwaKKGckmELLnUiiRtvfPB();
		}

		public double GetAxisTimeActive()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.BUKcfyaiKOajNjrdIhfXzBVkfGGcB();
		}

		public double GetAxisTimeInactive()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.VPKrHsMOXrcvsujsDbdFKvgEjXGbA();
		}

		public float GetAxisRaw()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.HgSolGqzrWgygyBlaPrrqoDQbdPe();
		}

		public float GetAxisRawDelta()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.XIoGLJHhQCAImotkwoKLJBzQrxrp();
		}

		public float GetAxisRawPrev()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.KFwDFmCqYqFyolxhyoAzmOmdbffNA();
		}

		public double GetAxisRawTimeActive()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.AyfcUCEonpJCklgdgqjMcusxRjcO();
		}

		public double GetAxisRawTimeInactive()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.hZFEnQbfCAppnyvAGALIfSlxssDIA();
		}

		public AxisCoordinateMode GetAxisCoordinateMode()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.TPuGOHbqKylOUuxmVajKCrESBuAuA();
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.JqQrKQrHdZjxREDjnBQnifARuNFWA();
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.rVsQDLZrrHonFGrLRntIAFKaTqtg();
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.jEzpRdmloJvrzWblmjASKRCxGEJH();
		}

		public bool GetButton()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.YQHfsMysqVjztjwtrTJFEIeKPird();
		}

		public bool GetButtonPrev()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.lwjmXUEiKjWVAPRRtMBJTmfQpHIG();
		}

		public bool GetButtonDown()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.jrqnIQwfWvLcsfINFBfxTCLjSkbp();
		}

		public bool GetButtonUp()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.zXkcXAuzSiVuvHFqjJGyoytJKnVj();
		}

		public bool GetButtonSinglePressHold()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.UjvvuWLmvgjYpZbBYeiDUBimhnLF();
		}

		public bool GetButtonSinglePressDown()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.KcijJVoMSdfrhAFbQSgjUvpyWTPAA();
		}

		public bool GetButtonSinglePressUp()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.KCmTzwSFlOBbJMDRKbTfAeflpmkPA();
		}

		public bool GetButtonDoublePressDown()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.GDwIHbuFrNEBEgimaGrnEbDdmsCnc();
		}

		public bool GetButtonDoublePressDown(float speed)
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.giKSymFnBekDXeKoefEobpuGompRA(speed);
		}

		public bool GetButtonDoublePressHold()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.zKGnswOBuqJioRtxAHbSEZwTXIRL();
		}

		public bool GetButtonDoublePressHold(float speed)
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.bKsRSxbtfTpamFQsojBxcIkAeIev(speed);
		}

		public bool GetButtonDoublePressUp()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.KDBYFnIapWCuRVHWmUVtOSeNqVoB();
		}

		public bool GetButtonDoublePressUp(float speed)
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.QgeCOiegreCsvsCBPcovahClMBVmA(speed);
		}

		public bool GetButtonTimedPress(float time)
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.mHwOISIcKLYELmfuIzMWVmQuGYSN(time, 0f);
		}

		public bool GetButtonTimedPress(float time, float expireIn)
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.mHwOISIcKLYELmfuIzMWVmQuGYSN(time, expireIn);
		}

		public bool GetButtonTimedPressDown(float time)
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.ncabbIfRkvnLKsQgZnQbciyloOmfb(time);
		}

		public bool GetButtonTimedPressUp(float time)
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.OipdrlFpLTVyCpXDZzgoIHdLUKfKA(time, 0f);
		}

		public bool GetButtonTimedPressUp(float time, float expireIn)
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.OipdrlFpLTVyCpXDZzgoIHdLUKfKA(time, expireIn);
		}

		public bool GetButtonShortPress()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.UXRCACstvUhSzSsNqQPqZVmZvEoP();
		}

		public bool GetButtonShortPressDown()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.YWvQkhzwkcccOuvCrukmIILSCZYM();
		}

		public bool GetButtonShortPressUp()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.cfPlJFcsmJfsgdcDIMEUaUXDbjKob();
		}

		public bool GetButtonLongPress()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.PSmFidGuPRXVZPuRjIzgWBTnKIqV();
		}

		public bool GetButtonLongPressDown()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.jpOUeomRsCoKfdlsscOgcxMOCxVWA();
		}

		public bool GetButtonLongPressUp()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.eOzBxHcRvWjlQkJRYXNQjgwEcwvr();
		}

		public bool GetButtonRepeating()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.omigMRGRorchncQbopMtNSJoXBgN();
		}

		public double GetButtonTimePressed()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.dmzodTCnTDaLIhHXVpPqjpRXLTEfb();
		}

		public double GetButtonTimeUnpressed()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.AaLaGpGvbiAZNECVsNAWbUKGexsKA();
		}

		public bool GetNegativeButton()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.YPJJifGpzKGpOHFiwhVoQgKlzzCdA();
		}

		public bool GetNegativeButtonPrev()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.ySaGSRRDbrMediuPDkdswdvuaTRaA();
		}

		public bool GetNegativeButtonDown()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.KeraHXgHMqVrTuinGHPvxuntPHYeA();
		}

		public bool GetNegativeButtonUp()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.PWnDobdZzmcwAbkseaPUoybpajTDc();
		}

		public bool GetNegativeButtonSinglePressHold()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.jZiCUrcsbTGEXfgxqGopKopVvbhdA();
		}

		public bool GetNegativeButtonSinglePressDown()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.NJcypgkPuGBRciwSwxWrlIthaGZl();
		}

		public bool GetNegativeButtonSinglePressUp()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.RHUCUDueBsZAoiLdSTqTowAUPoET();
		}

		public bool GetNegativeButtonDoublePressDown()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.CIrimpCYopBncgDXXcTCCCEzFVczA();
		}

		public bool GetNegativeButtonDoublePressDown(float speed)
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.SXVAGXvfSlaIOhobhQqxpAqXefbfA(speed);
		}

		public bool GetNegativeButtonDoublePressHold()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.nlOcMAgJcslyMdNXCUgGLAQygveK();
		}

		public bool GetNegativeButtonDoublePressHold(float speed)
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.MvTUmTtOfqkLMpnrmrmTekmLKmjK(speed);
		}

		public bool GetNegativeButtonDoublePressUp()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.vDFVcMuncazFnvnIrNUxXVAlCXnk();
		}

		public bool GetNegativeButtonDoublePressUp(float speed)
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.sgGOOklIMBhBhMuiVcunLYdccsgR(speed);
		}

		public bool GetNegativeButtonTimedPress(float time)
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.IUlNISpQBLKTrVbaUExFDHkpdaCP(time, 0f);
		}

		public bool GetNegativeButtonTimedPress(float time, float expireIn)
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.IUlNISpQBLKTrVbaUExFDHkpdaCP(time, expireIn);
		}

		public bool GetNegativeButtonTimedPressDown(float time)
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.nzKXiwKtOuYZEsvHGMKynCFVEhBj(time);
		}

		public bool GetNegativeButtonTimedPressUp(float time)
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.UqRAuOeHxIPHVZFvSvqrzozjyIAt(time, 0f);
		}

		public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.UqRAuOeHxIPHVZFvSvqrzozjyIAt(time, expireIn);
		}

		public bool GetNegativeButtonShortPress()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.bXzEmfKpQvDHeXwRmNFlDUcorJaq();
		}

		public bool GetNegativeButtonShortPressDown()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.dtOdLTararwkQAEqbloYduuveWbxA();
		}

		public bool GetNegativeButtonShortPressUp()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.KGnCXSdaSodcwVoWeIdTInDVQAvpA();
		}

		public bool GetNegativeButtonLongPress()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.TXZvEnCwDEJInMiFQLkEiGreusUX();
		}

		public bool GetNegativeButtonLongPressDown()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.vRTDJRmXEZEfKfPbzLkaSmmUUVoO();
		}

		public bool GetNegativeButtonLongPressUp()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.EqzadOhGBxxvhvLQcHgdTejBsTcb();
		}

		public bool GetNegativeButtonRepeating()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.ziPlaNCCiOmYyLBmPfgPjsLWmVtL();
		}

		public double GetNegativeButtonTimePressed()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.pqWYOHOIyYKAVxfXhABrIlNxqDr();
		}

		public double GetNegativeButtonTimeUnpressed()
		{
			return IaYDmvpQhLbpBiNBlFIjceiTdhsoA.BTtZHqanlsEmrHLcjjpkiZWGuswbA();
		}

		public IList<InputActionSourceData> GetCurrentInputSources()
		{
			return ReInput.WUBqcfcHLvbkdiiUnEhQlzYVACJm.GFHCguACECBmAcjhhkDLNaZRTRlkc(playerId, actionId, true)?.szASbmZogCYJNuGKHRDzvjDvIwQaA();
		}

		public bool IsCurrentInputSource(ControllerType controllerType)
		{
			return ReInput.WUBqcfcHLvbkdiiUnEhQlzYVACJm.GFHCguACECBmAcjhhkDLNaZRTRlkc(playerId, actionId, true)?.xtEZeUXviXJAwShbVnHqugUqTryE(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
		{
			return ReInput.WUBqcfcHLvbkdiiUnEhQlzYVACJm.GFHCguACECBmAcjhhkDLNaZRTRlkc(playerId, actionId, true)?.dCMguBXiJyFKWTLAMgTIDNqBbHNM(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(Controller controller)
		{
			return ReInput.WUBqcfcHLvbkdiiUnEhQlzYVACJm.GFHCguACECBmAcjhhkDLNaZRTRlkc(playerId, actionId, true)?.qshFBeZqoXvWyfqWhQGSOAWCrqtC(controller) ?? false;
		}

		internal InputActionEventData(pDpcIvKINqIAQeDxKXPLLXNhacXfb P_0, int P_1, int P_2, UpdateLoopType P_3)
		{
			emsUmYATQSNPPgxofbYLpyutqHvy = InputActionEventType.Update;
			IaYDmvpQhLbpBiNBlFIjceiTdhsoA = P_0;
			playerId = P_1;
			actionId = P_2;
			updateLoop = P_3;
		}
	}
}
