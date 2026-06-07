using System.Collections.Generic;

namespace Rewired
{
	public struct InputActionEventData
	{
		private pEQcyInzaqspNDwmuMYGrewsNaQ AiYMrYvHfmgGTECLagDHCliIfUw;

		private InputActionEventType ETdYAeWExySaEFQlWEwhFEMGwsh;

		public readonly int playerId;

		public readonly int actionId;

		public readonly UpdateLoopType updateLoop;

		public InputActionEventType eventType
		{
			get
			{
				return ETdYAeWExySaEFQlWEwhFEMGwsh;
			}
			internal set
			{
				ETdYAeWExySaEFQlWEwhFEMGwsh = value;
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
				return ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.lklRvOtWMNouCgbGRftSXhlYipRk(actionId).name;
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
				return ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.lklRvOtWMNouCgbGRftSXhlYipRk(actionId).descriptiveName;
			}
		}

		public float GetAxis()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.gsiPWtFMoYarPDgrBaZqlwGphcI();
		}

		public float GetAxisPrev()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.OBiksylQWJjQjwhzYenDgZXxIGF();
		}

		public float GetAxisDelta()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.kHkiELtELGSNYqhHUvcRdAVKOAK();
		}

		public float GetAxisTimeActive()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.bUaYiNmIXdjUJTjiveYBXOsUPPR();
		}

		public float GetAxisTimeInactive()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.psOpurpDxgftdfKhDDJAvXOrVIiN();
		}

		public float GetAxisRaw()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.pAQaeYoVtoBapeKmsZlYocRkDjMw();
		}

		public float GetAxisRawDelta()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.BrfyKBLVGfxHnFinMTEmvoVfrMJ();
		}

		public float GetAxisRawPrev()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.qgrhzzkMBnrVfACVsTCkWkpyeIoh();
		}

		public float GetAxisRawTimeActive()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.mOITPhTjUfqJAAcOZnvmvsEKekb();
		}

		public float GetAxisRawTimeInactive()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.utiQMiNlOleKIQrxVDjZdOJGPFZ();
		}

		public AxisCoordinateMode GetAxisCoordinateMode()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.mHKXpTDrzdaIAFdfieNXajCPOekA();
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.KLSupPtdLzGdSilInlpUGGnsXuxv();
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.FUaEIRfNVTsFuwAGCOHfAQOzffEz();
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.qwaTTQNPgEqFLYgJOIopoXDFCDDD();
		}

		public bool GetButton()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.lvyTpewEByrJQaPpHiuasLSeNzw();
		}

		public bool GetButtonPrev()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.tInrXBfJiKwsRBkSagZTLPBXVbJ();
		}

		public bool GetButtonDown()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.kmPAfEKnCyTirEYSWkaOedaLedN();
		}

		public bool GetButtonUp()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.OyXGTSwiLyydixsXoAkXTFGBrMP();
		}

		public bool GetButtonSinglePressHold()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.oumQrJVceWMuKcaHRTCQmoJRcBFg();
		}

		public bool GetButtonSinglePressDown()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.xlSsEefXfNsXbZyirAyfPSKMcTW();
		}

		public bool GetButtonSinglePressUp()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.iHwerJAqVfEQSCtTfkIyzFItSBcF();
		}

		public bool GetButtonDoublePressDown()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.KVYBArGysOtyKpvWvichEouJUIXn();
		}

		public bool GetButtonDoublePressDown(float speed)
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.KVYBArGysOtyKpvWvichEouJUIXn(speed);
		}

		public bool GetButtonDoublePressHold()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.khySxihXVeHHtgPjnBNkOYPffuJ();
		}

		public bool GetButtonDoublePressHold(float speed)
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.khySxihXVeHHtgPjnBNkOYPffuJ(speed);
		}

		public bool GetButtonDoublePressUp()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.FTMCwioxGgIbwHAYvDlTcFPHSAlC();
		}

		public bool GetButtonDoublePressUp(float speed)
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.FTMCwioxGgIbwHAYvDlTcFPHSAlC(speed);
		}

		public bool GetButtonTimedPress(float time)
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.wxklcERvuaELJtrzqLHaclhYEDjd(time, 0f);
		}

		public bool GetButtonTimedPress(float time, float expireIn)
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.wxklcERvuaELJtrzqLHaclhYEDjd(time, expireIn);
		}

		public bool GetButtonTimedPressDown(float time)
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.gXOEjzDoUrBmGKJUrFSCuhWtwuYK(time);
		}

		public bool GetButtonTimedPressUp(float time)
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.dVFrovmlIiHHPqBCNJnHYplrEkef(time, 0f);
		}

		public bool GetButtonTimedPressUp(float time, float expireIn)
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.dVFrovmlIiHHPqBCNJnHYplrEkef(time, expireIn);
		}

		public bool GetButtonShortPress()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.dJmBEWIMgftsPBEHqbpmuIkQYJxk();
		}

		public bool GetButtonShortPressDown()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.oCihxYaxpocUbbxviEHrhZuUjztL();
		}

		public bool GetButtonShortPressUp()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.SkODxaakXeCDpheFdlLpOtdzPNBu();
		}

		public bool GetButtonLongPress()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.lTpGWRDldJqfUaMTglYKLAkbshOG();
		}

		public bool GetButtonLongPressDown()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.ssrFVmHAOuxfRJhWgmeRXJABOcY();
		}

		public bool GetButtonLongPressUp()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.sMcCvPBnIygOxQxPIOLBFgBkKtzz();
		}

		public bool GetButtonRepeating()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.XMuJsoWGwkdqfiGJyXqPtcfjmlP();
		}

		public float GetButtonTimePressed()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.SavYoOxADmATHGxsSrTLDxkRgDY();
		}

		public float GetButtonTimeUnpressed()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.essNSlXgTdhzXVlZtlOOJFAnNtj();
		}

		public bool GetNegativeButton()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.WvSmeLExuitBNiAVEhCleOWlTFR();
		}

		public bool GetNegativeButtonPrev()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.BlgxYmcQCnviNYPYAGDfxudXrYl();
		}

		public bool GetNegativeButtonDown()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.EYuDJVDMraHBZVsAfWxxjYhezKIh();
		}

		public bool GetNegativeButtonUp()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.RvVOlcFiiUoCnzwclOyOUWFywkR();
		}

		public bool GetNegativeButtonSinglePressHold()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.QCBwuzrcxibRyGfWCxMmKFAWaMD();
		}

		public bool GetNegativeButtonSinglePressDown()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.HuWvifqevXgZvJHwwFePyKBJRSJ();
		}

		public bool GetNegativeButtonSinglePressUp()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.fIhcEUGPpnDDBjOfPoKpwrBwGZXP();
		}

		public bool GetNegativeButtonDoublePressDown()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.OrCBIqmjbhyTOgyyigLkLYAFQHD();
		}

		public bool GetNegativeButtonDoublePressDown(float speed)
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.OrCBIqmjbhyTOgyyigLkLYAFQHD(speed);
		}

		public bool GetNegativeButtonDoublePressHold()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.KZjyNrTKNgHQOrbmJvBAPWMRDOy();
		}

		public bool GetNegativeButtonDoublePressHold(float speed)
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.KZjyNrTKNgHQOrbmJvBAPWMRDOy(speed);
		}

		public bool GetNegativeButtonDoublePressUp()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.ydVhKMKFAjcRDuehjQcVWBjVngj();
		}

		public bool GetNegativeButtonDoublePressUp(float speed)
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.ydVhKMKFAjcRDuehjQcVWBjVngj(speed);
		}

		public bool GetNegativeButtonTimedPress(float time)
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.rZebOrKydgpDEirkUXGZClPDYFE(time, 0f);
		}

		public bool GetNegativeButtonTimedPress(float time, float expireIn)
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.rZebOrKydgpDEirkUXGZClPDYFE(time, expireIn);
		}

		public bool GetNegativeButtonTimedPressDown(float time)
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.SFiwEaJijuQchcXlQFVdLdqbCFZ(time);
		}

		public bool GetNegativeButtonTimedPressUp(float time)
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.HCqzYczWwBrILaUmphxfNZWkmkt(time, 0f);
		}

		public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.HCqzYczWwBrILaUmphxfNZWkmkt(time, expireIn);
		}

		public bool GetNegativeButtonShortPress()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.TyRKchCmgGezpurjlGIlwHyhCqPF();
		}

		public bool GetNegativeButtonShortPressDown()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.atJfdtVakiPTsxMWLswiHzqhnXh();
		}

		public bool GetNegativeButtonShortPressUp()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.pcuMeEWadAiOMfhHbUSXCfHyYbGq();
		}

		public bool GetNegativeButtonLongPress()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.sZjovgfYuOueYRjHKfaxPMBhEtfH();
		}

		public bool GetNegativeButtonLongPressDown()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.hWPFdJhnxwiqIMvmzcJTtrGXBwxy();
		}

		public bool GetNegativeButtonLongPressUp()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.zAIHmYaXXkGasjpkiIupayFWwSbZ();
		}

		public bool GetNegativeButtonRepeating()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.PHyBYFIwgNChoJCUNazGaNwOIWH();
		}

		public float GetNegativeButtonTimePressed()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.tbxdrfiVMdWdyMEVJLnEzUAKcPdx();
		}

		public float GetNegativeButtonTimeUnpressed()
		{
			return AiYMrYvHfmgGTECLagDHCliIfUw.xKMTiqFxsOOiwbjIEqDjBXbdlGs();
		}

		public IList<InputActionSourceData> GetCurrentInputSources()
		{
			pEQcyInzaqspNDwmuMYGrewsNaQ pEQcyInzaqspNDwmuMYGrewsNaQ2 = ReInput.uzYFVAOPCugnffcKSwcZmFfGUjB.bjnqvpILJQKZbVguFAHRXYXTit(playerId, actionId, true);
			if (pEQcyInzaqspNDwmuMYGrewsNaQ2 == null)
			{
				return null;
			}
			return pEQcyInzaqspNDwmuMYGrewsNaQ2.UleOkOGoxWEVCKRDCDLucxkKCqxs();
		}

		public bool IsCurrentInputSource(ControllerType controllerType)
		{
			pEQcyInzaqspNDwmuMYGrewsNaQ pEQcyInzaqspNDwmuMYGrewsNaQ2 = ReInput.uzYFVAOPCugnffcKSwcZmFfGUjB.bjnqvpILJQKZbVguFAHRXYXTit(playerId, actionId, true);
			if (pEQcyInzaqspNDwmuMYGrewsNaQ2 == null)
			{
				return false;
			}
			return pEQcyInzaqspNDwmuMYGrewsNaQ2.eeTsKlpHADAPFlgMBcwMEGTPLwjj(controllerType);
		}

		public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
		{
			pEQcyInzaqspNDwmuMYGrewsNaQ pEQcyInzaqspNDwmuMYGrewsNaQ2 = ReInput.uzYFVAOPCugnffcKSwcZmFfGUjB.bjnqvpILJQKZbVguFAHRXYXTit(playerId, actionId, true);
			if (pEQcyInzaqspNDwmuMYGrewsNaQ2 == null)
			{
				return false;
			}
			return pEQcyInzaqspNDwmuMYGrewsNaQ2.eeTsKlpHADAPFlgMBcwMEGTPLwjj(controllerType, controllerId);
		}

		public bool IsCurrentInputSource(Controller controller)
		{
			pEQcyInzaqspNDwmuMYGrewsNaQ pEQcyInzaqspNDwmuMYGrewsNaQ2 = ReInput.uzYFVAOPCugnffcKSwcZmFfGUjB.bjnqvpILJQKZbVguFAHRXYXTit(playerId, actionId, true);
			if (pEQcyInzaqspNDwmuMYGrewsNaQ2 == null)
			{
				return false;
			}
			return pEQcyInzaqspNDwmuMYGrewsNaQ2.eeTsKlpHADAPFlgMBcwMEGTPLwjj(controller);
		}

		internal InputActionEventData(pEQcyInzaqspNDwmuMYGrewsNaQ vc, int playerId, int actionId, UpdateLoopType updateLoop)
		{
			ETdYAeWExySaEFQlWEwhFEMGwsh = InputActionEventType.Update;
			AiYMrYvHfmgGTECLagDHCliIfUw = vc;
			this.playerId = playerId;
			this.actionId = actionId;
			this.updateLoop = updateLoop;
		}
	}
}
