using System.Collections.Generic;

namespace Rewired
{
	public struct InputActionEventData
	{
		private gjGAZYHMtBrBPTgtywbcfPTZqEdL XwtiUWggagKfGyXDHvnSUoyjdMGI;

		private InputActionEventType tuDfmhZwJbeqCkaeHQnkhDeLCRRZA;

		public readonly int playerId;

		public readonly int actionId;

		public readonly UpdateLoopType updateLoop;

		public InputActionEventType eventType
		{
			get
			{
				return tuDfmhZwJbeqCkaeHQnkhDeLCRRZA;
			}
			internal set
			{
				tuDfmhZwJbeqCkaeHQnkhDeLCRRZA = inputActionEventType;
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
				return ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.fEjqfVXFCLeaglorPplnfacFxZpK(actionId).name;
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
				return ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.fEjqfVXFCLeaglorPplnfacFxZpK(actionId).descriptiveName;
			}
		}

		public float GetAxis()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.ZPNikWIZSmUXPbeCTkmoPmYwisik();
		}

		public float GetAxisPrev()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.tBoKoceMomaWNQNUUBYOAkRNkCYBb();
		}

		public float GetAxisDelta()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.JeQxFDvtzLcrLojuzCoIbGuPerTBb();
		}

		public double GetAxisTimeActive()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.GThSpZrNBbRSSzzzFHAkhAPPqCqn();
		}

		public double GetAxisTimeInactive()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.MihHPPLRGWQMdehgttUgkyiqHNqy();
		}

		public float GetAxisRaw()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.GxmEpxBgzHPvglBWBgWeIaoEfdAb();
		}

		public float GetAxisRawDelta()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.CzBCLiMsRnnUruPoEvngzQvapSZL();
		}

		public float GetAxisRawPrev()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.RVNYFNnpJBJRpfldEntQCieHQtHUA();
		}

		public double GetAxisRawTimeActive()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.BDYUJxPlkYvnzrCdGWgbIZqXpAYJ();
		}

		public double GetAxisRawTimeInactive()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.wpuuxnmzVrpOmkQSerkzkLtZeerFA();
		}

		public AxisCoordinateMode GetAxisCoordinateMode()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.ARLWQobzNTSpXqggzrOhBsWogoeP();
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.YHrHKtqmuumUAQYnDefGLfEhgBveA();
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.cZBDCgGfqgALOiALvrWzEiOWGZRyA();
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.sWCddKnMroSYiETpGrWfqpSNOIlO();
		}

		public bool GetButton()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.FuonpZfnMsIoctilHoaxyYdyBhPe();
		}

		public bool GetButtonPrev()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.eaIDsdFDPMpzBFuLLeduvIngcxyu();
		}

		public bool GetButtonDown()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.mZHiYnhZVMTDhjZLvRUEntHJjuHw();
		}

		public bool GetButtonUp()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.iqFazvtbRNuTyRjsZusNMBvfGFtk();
		}

		public bool GetButtonSinglePressHold()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.LnEbufSAmJfOiJrZgUBgkniKbpvX();
		}

		public bool GetButtonSinglePressDown()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.PJZLJevQXCnMsBKtiMDQTOvWZFnT();
		}

		public bool GetButtonSinglePressUp()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.JALHxVPoifuEKIMLkheSGexBueSw();
		}

		public bool GetButtonDoublePressDown()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.FNHlZErpocbcPwpyCgAWLsREryqn();
		}

		public bool GetButtonDoublePressDown(float speed)
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.tLnEeLgQKBjaCqeaCLrHJskehaDz(speed);
		}

		public bool GetButtonDoublePressHold()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.abrksPPdfPiLvGHtuGKtogcpxTpNA();
		}

		public bool GetButtonDoublePressHold(float speed)
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.kGVFSQmZygeFnVSkIMyACXcsjYWn(speed);
		}

		public bool GetButtonDoublePressUp()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.VAkSoYTralfVjFNOGxGiuEOjoIbD();
		}

		public bool GetButtonDoublePressUp(float speed)
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.PgZCDPfFiDhZucAZhsJWDBAJMPxs(speed);
		}

		public bool GetButtonTimedPress(float time)
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.vqNJSnFQVahdImpeivdjhKUQqIsu(time, 0f);
		}

		public bool GetButtonTimedPress(float time, float expireIn)
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.vqNJSnFQVahdImpeivdjhKUQqIsu(time, expireIn);
		}

		public bool GetButtonTimedPressDown(float time)
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.ozTbjfKCrGMmVLCadArSyWqVaEObb(time);
		}

		public bool GetButtonTimedPressUp(float time)
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.JyAydMepCujFNZILhDNDebzzCUXNA(time, 0f);
		}

		public bool GetButtonTimedPressUp(float time, float expireIn)
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.JyAydMepCujFNZILhDNDebzzCUXNA(time, expireIn);
		}

		public bool GetButtonShortPress()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.RdgEOnrsqnbnoGfNCoCLhpgdSwMI();
		}

		public bool GetButtonShortPressDown()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.TQEUkSuCbHhTRsNYHVLHwiBiAJmv();
		}

		public bool GetButtonShortPressUp()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.nhyiJcforsMXtqvHiOplkNBDEfiw();
		}

		public bool GetButtonLongPress()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.MIDVkEBmOouwYDzNPnAVakZFrYSM();
		}

		public bool GetButtonLongPressDown()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.eNzEkBkljlqfudduKyxPNXKocpfeA();
		}

		public bool GetButtonLongPressUp()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.lHIaTenSobuARamRaqWxXFuiuQLm();
		}

		public bool GetButtonRepeating()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.lHFTMgTyfAsIuMPvUDjKbrRCkFKdb();
		}

		public double GetButtonTimePressed()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.msOjfiReGuRiDPUDpEwZNkNvVPqQ();
		}

		public double GetButtonTimeUnpressed()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.JHqcOAeTyVPcUAOVUnjtNiImbhGqA();
		}

		public bool GetNegativeButton()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.LJmoiCBrurlAHBkmMLoPOkULXlcW();
		}

		public bool GetNegativeButtonPrev()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.lWFlSmMbcEHZkEyFhvQJUQnAIBhtA();
		}

		public bool GetNegativeButtonDown()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.XBGdRySTTRFUMBwxafaWnApTtRmJA();
		}

		public bool GetNegativeButtonUp()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.YVCTqAOcuTWFVseiADubHQfIHfvNA();
		}

		public bool GetNegativeButtonSinglePressHold()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.kVBACYjrkutBMvqbSDIGIJrfbfTH();
		}

		public bool GetNegativeButtonSinglePressDown()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.YrNCuRzVhdeutyyIGfMETTxXEubP();
		}

		public bool GetNegativeButtonSinglePressUp()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.QgnCBglsGTlDpsjbieHyUVQwLeym();
		}

		public bool GetNegativeButtonDoublePressDown()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.RQURuYLufEuIfcMFzFejqPYVfPCU();
		}

		public bool GetNegativeButtonDoublePressDown(float speed)
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.XyoIVcyTTAxYTlnfVDbUXDonhvTx(speed);
		}

		public bool GetNegativeButtonDoublePressHold()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.uMfqxcjfQPGFkpBqidfRdIcYeGNb();
		}

		public bool GetNegativeButtonDoublePressHold(float speed)
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.NMwEhakyyZNMHxttUYJeQiizHIVv(speed);
		}

		public bool GetNegativeButtonDoublePressUp()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.cYkFcfdllVgywsbCTbzCVpEPmMDdA();
		}

		public bool GetNegativeButtonDoublePressUp(float speed)
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.ngxWDFyCNcCegAzotQFUbmjKqQQL(speed);
		}

		public bool GetNegativeButtonTimedPress(float time)
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.NwEDQpiPCmWnaFrueFvwiluVimmHA(time, 0f);
		}

		public bool GetNegativeButtonTimedPress(float time, float expireIn)
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.NwEDQpiPCmWnaFrueFvwiluVimmHA(time, expireIn);
		}

		public bool GetNegativeButtonTimedPressDown(float time)
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.mItFFVLDNLBtTwmTiuhZPnTrMVfK(time);
		}

		public bool GetNegativeButtonTimedPressUp(float time)
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.BSgsdzxNmbuIKPqdoHPKJhjNAtmK(time, 0f);
		}

		public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.BSgsdzxNmbuIKPqdoHPKJhjNAtmK(time, expireIn);
		}

		public bool GetNegativeButtonShortPress()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.sBAumCLTDURyhTfNUHsApUkQnXIU();
		}

		public bool GetNegativeButtonShortPressDown()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.evftNegrlGWJROygXVZfWvcDcQTr();
		}

		public bool GetNegativeButtonShortPressUp()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.NZYxPhfNRFZLbmhUATIoHwFxWSLu();
		}

		public bool GetNegativeButtonLongPress()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.KrmAAGjLIditkgMZfoBjWGpOAsakc();
		}

		public bool GetNegativeButtonLongPressDown()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.sSwnZwbvPqQCDbKtZFLHjyuaoFYWA();
		}

		public bool GetNegativeButtonLongPressUp()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.XYXatCuaXaSAkxfLudqJltsNhkhO();
		}

		public bool GetNegativeButtonRepeating()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.wiyiayBClpifliNehzHgFFTiWoTqA();
		}

		public double GetNegativeButtonTimePressed()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.gPZMYfIPDBtBNTDdtvmsTnjpmMzh();
		}

		public double GetNegativeButtonTimeUnpressed()
		{
			return XwtiUWggagKfGyXDHvnSUoyjdMGI.CZOvPBfJwDOFaTGwZlGBxECaagQkA();
		}

		public IList<InputActionSourceData> GetCurrentInputSources()
		{
			return ReInput.VeAmGFtEIHUuquEZXjxbJYdKKrEb.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(playerId, actionId, true)?.fddHjNCEbpRsAgsOjraMEXNMZukac();
		}

		public bool IsCurrentInputSource(ControllerType controllerType)
		{
			return ReInput.VeAmGFtEIHUuquEZXjxbJYdKKrEb.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(playerId, actionId, true)?.ydnFcnKfeakCbANdvCOTGECSfFSV(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
		{
			return ReInput.VeAmGFtEIHUuquEZXjxbJYdKKrEb.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(playerId, actionId, true)?.aSjozqWQYVhvXFhGgiShlOcjBOrj(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(Controller controller)
		{
			return ReInput.VeAmGFtEIHUuquEZXjxbJYdKKrEb.FVwxqLXNDbqPFnJzEdgojSDlcRBwA(playerId, actionId, true)?.zZWDpFQvuoSVtlynHnaxkgQwxhTj(controller) ?? false;
		}

		internal InputActionEventData(gjGAZYHMtBrBPTgtywbcfPTZqEdL P_0, int P_1, int P_2, UpdateLoopType P_3)
		{
			tuDfmhZwJbeqCkaeHQnkhDeLCRRZA = InputActionEventType.Update;
			XwtiUWggagKfGyXDHvnSUoyjdMGI = P_0;
			playerId = P_1;
			actionId = P_2;
			updateLoop = P_3;
		}
	}
}
