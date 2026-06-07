using System.Collections.Generic;

namespace Rewired
{
	public struct InputActionEventData
	{
		private HuFUPnVcilGVsLkOQFTNYtvJAVLr cxBySpNvldAcyKlPKUmQjvfbfxfE;

		private InputActionEventType gDgiBCcQTdepkHwQsNeRmBanNuDB;

		public readonly int playerId;

		public readonly int actionId;

		public readonly UpdateLoopType updateLoop;

		public InputActionEventType eventType
		{
			get
			{
				return gDgiBCcQTdepkHwQsNeRmBanNuDB;
			}
			internal set
			{
				gDgiBCcQTdepkHwQsNeRmBanNuDB = inputActionEventType;
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
				return ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.NummBjJsAIbMtuHufgkHhcuvBUSmA(actionId).name;
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
				return ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.NummBjJsAIbMtuHufgkHhcuvBUSmA(actionId).descriptiveName;
			}
		}

		public float GetAxis()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.AcvdmOzScVMcmBUZvbBnEUPMUIFm();
		}

		public float GetAxisPrev()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.qMrEIVBOXEVidwZRmnJsHUjElcFG();
		}

		public float GetAxisDelta()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.CllAsyZUJKwtqgDsmoSEQPEtzZgc();
		}

		public double GetAxisTimeActive()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.ZjbiUaIRTyNDkZWLNzBGgFdratSI();
		}

		public double GetAxisTimeInactive()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.VhPmGEPUpbTBQGqXfbGDkwRUotxR();
		}

		public float GetAxisRaw()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.HqTUEvWMbnrGUEHWWUiDJMMFFUPo();
		}

		public float GetAxisRawDelta()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.lgwUymtCKsIjYiLRmNXjaOAGppAYA();
		}

		public float GetAxisRawPrev()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.ARqkTOKJToBnOJOxCZVrebmHrddFA();
		}

		public double GetAxisRawTimeActive()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.KZRfFGjixsSnxYJAdiWaARhtVuoh();
		}

		public double GetAxisRawTimeInactive()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.ADjNgNvqOyPofYrVzKcEWCAdlwEw();
		}

		public AxisCoordinateMode GetAxisCoordinateMode()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.AxZtHedypmAohTRRWAUAOcTwrRrR();
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.qBNYDeVHZwgZzAdiNtmDFbgTiPysA();
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.vjbBgkjnTWudJfIykEIacpReYQZQB();
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.KhnXrfljsXCjgbYlebvmBTCekgGtA();
		}

		public bool GetButton()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.PKxzXBSMXndnnwoVrPblHLVDZExv();
		}

		public bool GetButtonPrev()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.BYuNmqXmcJEOqFjaSxNMkOUwwGWl();
		}

		public bool GetButtonDown()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.WBIaBbghQpgzOEKyaCjXLOtiaWQP();
		}

		public bool GetButtonUp()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.mjQmQdEkqdYvFzOGOLRYyQYeGhCg();
		}

		public bool GetButtonSinglePressHold()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.YefNDmxYaFaOfckhdzXTHQWiUwIP();
		}

		public bool GetButtonSinglePressDown()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.ZbZXwRDbpUbpKjPSFNzyAkHgzaVKB();
		}

		public bool GetButtonSinglePressUp()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.QslgJubMTuHarludIYDjkIVdWerS();
		}

		public bool GetButtonDoublePressDown()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.qLLgoCHAuTvEpknkLUncjRjpPpCPA();
		}

		public bool GetButtonDoublePressDown(float speed)
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.qLLgoCHAuTvEpknkLUncjRjpPpCPA(speed);
		}

		public bool GetButtonDoublePressHold()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.ExzCcLBqDxDpCccDPnSlIdKQoEOxA();
		}

		public bool GetButtonDoublePressHold(float speed)
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.ExzCcLBqDxDpCccDPnSlIdKQoEOxA(speed);
		}

		public bool GetButtonDoublePressUp()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.dIRAKDCSExHVTMEwLyuUgaSxPzmYA();
		}

		public bool GetButtonDoublePressUp(float speed)
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.dIRAKDCSExHVTMEwLyuUgaSxPzmYA(speed);
		}

		public bool GetButtonTimedPress(float time)
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.MijQAzbgipqhmrRTMEAjRYehWkeS(time, 0f);
		}

		public bool GetButtonTimedPress(float time, float expireIn)
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.MijQAzbgipqhmrRTMEAjRYehWkeS(time, expireIn);
		}

		public bool GetButtonTimedPressDown(float time)
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.OnVkLWxiYqOUxNEiNSRDGpDMlRXW(time);
		}

		public bool GetButtonTimedPressUp(float time)
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.FKIXfMMuStjlooachfgAhGsYeFxdA(time, 0f);
		}

		public bool GetButtonTimedPressUp(float time, float expireIn)
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.FKIXfMMuStjlooachfgAhGsYeFxdA(time, expireIn);
		}

		public bool GetButtonShortPress()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.XujDkxfqkqnIoHYvDKerQvlfvmkYA();
		}

		public bool GetButtonShortPressDown()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.GspCLfBRlvRsOJxFwoAeDebWMIwrA();
		}

		public bool GetButtonShortPressUp()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.eaNjLDcSHnFbCqctTYQcrKwgfyGlA();
		}

		public bool GetButtonLongPress()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.NIoDqkKPjEoFxDUldIBBPhbfUQJKB();
		}

		public bool GetButtonLongPressDown()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.EickhBxXSpLJmZfmCdxGysHgYJXu();
		}

		public bool GetButtonLongPressUp()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.EXdFXyZnCrhwMnlrmXSAPFUZVQyX();
		}

		public bool GetButtonRepeating()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.ddtetPkUaprMIuFlUQlSEQgCcCGx();
		}

		public double GetButtonTimePressed()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.kKaUCxZhJdapkBzUcxWGoijaMqLGb();
		}

		public double GetButtonTimeUnpressed()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.OhtneIzCDqXfuNzzZylFuTRKqweh();
		}

		public bool GetNegativeButton()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.ilFAZwkIaxHKmyAvsBXuJQNIEkYs();
		}

		public bool GetNegativeButtonPrev()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.vZjFXFEfAwXLmGsqgVakMDqwjAqm();
		}

		public bool GetNegativeButtonDown()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.unhchykaxdiheOqgVQewBhsRIfZDA();
		}

		public bool GetNegativeButtonUp()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.fFYMTDlJiVbySbkKFktNzGIHtFWr();
		}

		public bool GetNegativeButtonSinglePressHold()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.sSAcKCHLnzXXRUDysDovidHtMfIDA();
		}

		public bool GetNegativeButtonSinglePressDown()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.xPqNPIUyKmOkDxnElSvJUJmnqPx();
		}

		public bool GetNegativeButtonSinglePressUp()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.PSacIhqypanSwWLRlLNySDKJuXOi();
		}

		public bool GetNegativeButtonDoublePressDown()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.qDrbhExdaMtikEgOjSQeXXgpcOE();
		}

		public bool GetNegativeButtonDoublePressDown(float speed)
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.qDrbhExdaMtikEgOjSQeXXgpcOE(speed);
		}

		public bool GetNegativeButtonDoublePressHold()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.qPcUkEjeSlfflnmFngxJeNHykYzH();
		}

		public bool GetNegativeButtonDoublePressHold(float speed)
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.qPcUkEjeSlfflnmFngxJeNHykYzH(speed);
		}

		public bool GetNegativeButtonDoublePressUp()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.GtCARhmiIoXvysANTyjIfnagnZoV();
		}

		public bool GetNegativeButtonDoublePressUp(float speed)
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.GtCARhmiIoXvysANTyjIfnagnZoV(speed);
		}

		public bool GetNegativeButtonTimedPress(float time)
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.LPlGqCDEjrLvrznYozZSKYQyLwZgA(time, 0f);
		}

		public bool GetNegativeButtonTimedPress(float time, float expireIn)
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.LPlGqCDEjrLvrznYozZSKYQyLwZgA(time, expireIn);
		}

		public bool GetNegativeButtonTimedPressDown(float time)
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.mQrzgDhVvvDGCmvHktGucwxMaJWl(time);
		}

		public bool GetNegativeButtonTimedPressUp(float time)
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.jRlTkTJBiEfkwFuWPhmwLmDDKZyCb(time, 0f);
		}

		public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.jRlTkTJBiEfkwFuWPhmwLmDDKZyCb(time, expireIn);
		}

		public bool GetNegativeButtonShortPress()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.lIQHAOspqBODIsDHNyDmBsnQWNEQ();
		}

		public bool GetNegativeButtonShortPressDown()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.IIGKRCnbezOzZtZctpspeCdMcGyh();
		}

		public bool GetNegativeButtonShortPressUp()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.JmphWjkypJvmbntpVBPMUvADBKVu();
		}

		public bool GetNegativeButtonLongPress()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.OkilHHDaqVFWlDDtostqEcGEVAwAA();
		}

		public bool GetNegativeButtonLongPressDown()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.ZLGCVshBdxlKdulKDJOCVMHiBPyhb();
		}

		public bool GetNegativeButtonLongPressUp()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.RlPdEncQLrsGZBhKIQtgNrUbzrwX();
		}

		public bool GetNegativeButtonRepeating()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.nRtweucGmOdDTZEodSgPcojlorYW();
		}

		public double GetNegativeButtonTimePressed()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.NreGZYDpIwKJFFCjzXwBDlXbsyuaA();
		}

		public double GetNegativeButtonTimeUnpressed()
		{
			return cxBySpNvldAcyKlPKUmQjvfbfxfE.NATzAVhLaNeKJjngavEgVgcCAjhSA();
		}

		public IList<InputActionSourceData> GetCurrentInputSources()
		{
			return ReInput.OkLkjfkBGntRAvakyAvYRRgphMAiA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(playerId, actionId, true)?.eWtqIheNhXRbhUtxauGdKrtxgDin();
		}

		public bool IsCurrentInputSource(ControllerType controllerType)
		{
			return ReInput.OkLkjfkBGntRAvakyAvYRRgphMAiA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(playerId, actionId, true)?.MTGCvSRwICvOqrIqjpqZnxSqTqkf(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
		{
			return ReInput.OkLkjfkBGntRAvakyAvYRRgphMAiA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(playerId, actionId, true)?.MTGCvSRwICvOqrIqjpqZnxSqTqkf(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(Controller controller)
		{
			return ReInput.OkLkjfkBGntRAvakyAvYRRgphMAiA.ZsaWCDZFDKmAivELYJiSgHxiXbiE(playerId, actionId, true)?.MTGCvSRwICvOqrIqjpqZnxSqTqkf(controller) ?? false;
		}

		internal InputActionEventData(HuFUPnVcilGVsLkOQFTNYtvJAVLr P_0, int P_1, int P_2, UpdateLoopType P_3)
		{
			gDgiBCcQTdepkHwQsNeRmBanNuDB = InputActionEventType.Update;
			cxBySpNvldAcyKlPKUmQjvfbfxfE = P_0;
			playerId = P_1;
			actionId = P_2;
			updateLoop = P_3;
		}
	}
}
