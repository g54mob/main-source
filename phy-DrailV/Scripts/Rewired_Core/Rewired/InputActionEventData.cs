using System.Collections.Generic;

namespace Rewired
{
	public struct InputActionEventData
	{
		private oQRCFcJpUjLqOkwwnIxnfTMKhLJWA RgPlhihrHhdlWpTPpQuawkWwhvzQ;

		private InputActionEventType ZMyftASyehnPBeLIFihGDnmgZPeOA;

		public readonly int playerId;

		public readonly int actionId;

		public readonly UpdateLoopType updateLoop;

		public InputActionEventType eventType
		{
			get
			{
				return ZMyftASyehnPBeLIFihGDnmgZPeOA;
			}
			internal set
			{
				ZMyftASyehnPBeLIFihGDnmgZPeOA = zMyftASyehnPBeLIFihGDnmgZPeOA;
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
				return ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.qKuCVofiSWfeXLQSYWsbtNcyAMGe(actionId).name;
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
				return ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.qKuCVofiSWfeXLQSYWsbtNcyAMGe(actionId).descriptiveName;
			}
		}

		public float GetAxis()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.bLjUqDJVGVSlWmxjKKTBRMkNFIFdA();
		}

		public float GetAxisPrev()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.NwhhRAfbaWNuJFqlJkXCStnDAvJS();
		}

		public float GetAxisDelta()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.rgjeHltckJwFXBOdZKIcLKeaujPV();
		}

		public double GetAxisTimeActive()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.kgnNbvqDxiCoChuiiZNsNfKwboQwA();
		}

		public double GetAxisTimeInactive()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.gyVTKVxNShoWkvjtCqbzlgWNhlRc();
		}

		public float GetAxisRaw()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.mtDFbsoRVlrEoxEmreAlGujQTODw();
		}

		public float GetAxisRawDelta()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.YjodcvLLiiMIiuQlBtRHFinVIpAV();
		}

		public float GetAxisRawPrev()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.hUkWLcyhKkGyVnBbrhNUuNsSzzfB();
		}

		public double GetAxisRawTimeActive()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.fWZqwFFoFkbvFvemEQwUNXEsDKsj();
		}

		public double GetAxisRawTimeInactive()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.hGppqWNmmuXeHfzECKOsTbXcooQe();
		}

		public AxisCoordinateMode GetAxisCoordinateMode()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.fNFIsnXuHuRWXglfvwbqJEcpiNtm();
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.RsTSttdtpigyBMEEySbvksLKRMqf();
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.GafpUbHFjWFAhtVWTQgYuLoNBGNCA();
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.lXzwAqBGGBAWYnLZRuZOEsdjmqSn();
		}

		public bool GetButton()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.aBjKkYedffJMBNyjOkVFOWaUaAhq();
		}

		public bool GetButtonPrev()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.qveZUhnPEVcbIJyEhVLiIhpjriCfA();
		}

		public bool GetButtonDown()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.jYWxpmOgglOGuxLGHjZnFKAvkMEVA();
		}

		public bool GetButtonUp()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.NSCNnosVEfppjSDmbInqdnhriOUCb();
		}

		public bool GetButtonSinglePressHold()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.rHtSQnVSLBplJZRFObHrOFjzcoQK();
		}

		public bool GetButtonSinglePressDown()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.csDrdChbJQIOmksuuVxOxEagdqDu();
		}

		public bool GetButtonSinglePressUp()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.jVbQtlyEpufFHIoPlezNcnoiygzJA();
		}

		public bool GetButtonDoublePressDown()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.RcXDvTiiILQzTCKEyfHSAYQmjxOV();
		}

		public bool GetButtonDoublePressDown(float speed)
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.RcXDvTiiILQzTCKEyfHSAYQmjxOV(speed);
		}

		public bool GetButtonDoublePressHold()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.fGrfpCetbdrKqeHbFsuPvafPRESbB();
		}

		public bool GetButtonDoublePressHold(float speed)
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.fGrfpCetbdrKqeHbFsuPvafPRESbB(speed);
		}

		public bool GetButtonDoublePressUp()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.GzDJQAgdenEgvphMsgEaElrcFvuTA();
		}

		public bool GetButtonDoublePressUp(float speed)
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.GzDJQAgdenEgvphMsgEaElrcFvuTA(speed);
		}

		public bool GetButtonTimedPress(float time)
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.rYvZrqLIEfQSIYbjvmJRAFXiqciG(time, 0f);
		}

		public bool GetButtonTimedPress(float time, float expireIn)
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.rYvZrqLIEfQSIYbjvmJRAFXiqciG(time, expireIn);
		}

		public bool GetButtonTimedPressDown(float time)
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.dQHQTENqnyfFFiAjapdkHkNZNRzb(time);
		}

		public bool GetButtonTimedPressUp(float time)
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.mhYvIBoWyhPMAFuOIKKgwRFPHBhy(time, 0f);
		}

		public bool GetButtonTimedPressUp(float time, float expireIn)
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.mhYvIBoWyhPMAFuOIKKgwRFPHBhy(time, expireIn);
		}

		public bool GetButtonShortPress()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.wKnbzcWwOaLrOzSBtGWFcSCeammv();
		}

		public bool GetButtonShortPressDown()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.nvhKouvEJvdTwMHxRHsUnWQJpIqN();
		}

		public bool GetButtonShortPressUp()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.PdHcAEwphxEAeVbNuimEHvTzFeWgA();
		}

		public bool GetButtonLongPress()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.sLaxixlWJSqMBnbTfnalgnERAeXk();
		}

		public bool GetButtonLongPressDown()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.jYqabKZmwtoSQsSFjJmkhmYbPIFD();
		}

		public bool GetButtonLongPressUp()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.tAtdOjdZyxcBaKsDNFasfYtMXWcq();
		}

		public bool GetButtonRepeating()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.QmlGqIFOMvtlmEVTrTFoiHXNYGYBA();
		}

		public double GetButtonTimePressed()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.PbmZLevtftCnMKgsLjcibFAvEqNdA();
		}

		public double GetButtonTimeUnpressed()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.lQflqVBPjiOaAwdHezMflrsJAygFA();
		}

		public bool GetNegativeButton()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.BUDvRzCDOdNgSDFFXUnYMQiVSgEo();
		}

		public bool GetNegativeButtonPrev()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.QjvTGGincqjqIbxSLkbGWDLjDQuqA();
		}

		public bool GetNegativeButtonDown()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.HelmxrCyZjEmODVCgMtGwDwOrjHf();
		}

		public bool GetNegativeButtonUp()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.MwMEOSDIIFPGmIGayVPhiNpATkQH();
		}

		public bool GetNegativeButtonSinglePressHold()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.LcUGNRHrNzbefybEPWAFRskoKhOvA();
		}

		public bool GetNegativeButtonSinglePressDown()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.QFDHMOeOEOExSdgRtNyXnQixJsHoA();
		}

		public bool GetNegativeButtonSinglePressUp()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.iPoDluKIPcUUSfnvMOzWXPhECoWjA();
		}

		public bool GetNegativeButtonDoublePressDown()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.DyBFksccVwqlIJdyxdRmDnwtBhAjb();
		}

		public bool GetNegativeButtonDoublePressDown(float speed)
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.DyBFksccVwqlIJdyxdRmDnwtBhAjb(speed);
		}

		public bool GetNegativeButtonDoublePressHold()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.FzqOFPHPyvGIVUQrCGUhfYylwPxh();
		}

		public bool GetNegativeButtonDoublePressHold(float speed)
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.FzqOFPHPyvGIVUQrCGUhfYylwPxh(speed);
		}

		public bool GetNegativeButtonDoublePressUp()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.xPOfYcFAqcbGQXNpkmPkGuHehRgWB();
		}

		public bool GetNegativeButtonDoublePressUp(float speed)
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.xPOfYcFAqcbGQXNpkmPkGuHehRgWB(speed);
		}

		public bool GetNegativeButtonTimedPress(float time)
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.ctxzUBojHfaMDKluBWpwDbvbWeTO(time, 0f);
		}

		public bool GetNegativeButtonTimedPress(float time, float expireIn)
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.ctxzUBojHfaMDKluBWpwDbvbWeTO(time, expireIn);
		}

		public bool GetNegativeButtonTimedPressDown(float time)
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.TTdplYZkHbfsyVDzFsLCzAwVeYYD(time);
		}

		public bool GetNegativeButtonTimedPressUp(float time)
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.IibrkGxpYUNpGLFuwWQMdmaEFqwi(time, 0f);
		}

		public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.IibrkGxpYUNpGLFuwWQMdmaEFqwi(time, expireIn);
		}

		public bool GetNegativeButtonShortPress()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.UEfZNGvENjameDloZdGLWGDrNETA();
		}

		public bool GetNegativeButtonShortPressDown()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.rzYKbXTMvvIApGCKOLCHjMrDgBuf();
		}

		public bool GetNegativeButtonShortPressUp()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.avyVqEOPNYRRSMRmPrcRJvCUOLZ();
		}

		public bool GetNegativeButtonLongPress()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.pAoCECnEGXfuTmEPNDDQlTrTSAoL();
		}

		public bool GetNegativeButtonLongPressDown()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.epYInvbADrkzNKygaikcJwafHBur();
		}

		public bool GetNegativeButtonLongPressUp()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.aODPQqwcjhbzrAQcbMXYMkzoKxaq();
		}

		public bool GetNegativeButtonRepeating()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.COhDpfBOOMpezHoIGQMbFrKVmpCnb();
		}

		public double GetNegativeButtonTimePressed()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.eUmWvRTEecgodbzDAHEtwMggHcmhA();
		}

		public double GetNegativeButtonTimeUnpressed()
		{
			return RgPlhihrHhdlWpTPpQuawkWwhvzQ.mrZLVQNpOVrhrEGEJhmYbVTHCtdM();
		}

		public IList<InputActionSourceData> GetCurrentInputSources()
		{
			return ReInput.vnBcsWOiBrsweGQzTZwXEVWsKEyb.spuIPZtVjMmDKIpmbCpwlvidgLqV(playerId, actionId, true)?.LZhBfaIDDDONHnFPFohPDwSgLKoK();
		}

		public bool IsCurrentInputSource(ControllerType controllerType)
		{
			return ReInput.vnBcsWOiBrsweGQzTZwXEVWsKEyb.spuIPZtVjMmDKIpmbCpwlvidgLqV(playerId, actionId, true)?.dQUgVLFxmOnOYVMUKZXlbwznHLmNA(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
		{
			return ReInput.vnBcsWOiBrsweGQzTZwXEVWsKEyb.spuIPZtVjMmDKIpmbCpwlvidgLqV(playerId, actionId, true)?.dQUgVLFxmOnOYVMUKZXlbwznHLmNA(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(Controller controller)
		{
			return ReInput.vnBcsWOiBrsweGQzTZwXEVWsKEyb.spuIPZtVjMmDKIpmbCpwlvidgLqV(playerId, actionId, true)?.dQUgVLFxmOnOYVMUKZXlbwznHLmNA(controller) ?? false;
		}

		internal InputActionEventData(oQRCFcJpUjLqOkwwnIxnfTMKhLJWA P_0, int P_1, int P_2, UpdateLoopType P_3)
		{
			ZMyftASyehnPBeLIFihGDnmgZPeOA = InputActionEventType.Update;
			RgPlhihrHhdlWpTPpQuawkWwhvzQ = P_0;
			playerId = P_1;
			actionId = P_2;
			updateLoop = P_3;
		}
	}
}
