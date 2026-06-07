using System.Collections.Generic;

namespace Rewired
{
	public struct InputActionEventData
	{
		private VvbRiPIRRDOGFeaGvZCVmBjRfXT oYheOBEKSVfBFHpzHdTAEVpyfjjB;

		private InputActionEventType skCXQflGfBodQoycRuGsAVLfAHe;

		public readonly int playerId;

		public readonly int actionId;

		public readonly UpdateLoopType updateLoop;

		public InputActionEventType eventType
		{
			get
			{
				return skCXQflGfBodQoycRuGsAVLfAHe;
			}
			internal set
			{
				skCXQflGfBodQoycRuGsAVLfAHe = value;
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
				return ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.NXSdxZEXhqvBULQyUjzTUlotAOY(actionId).name;
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
				return ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.NXSdxZEXhqvBULQyUjzTUlotAOY(actionId).descriptiveName;
			}
		}

		public float GetAxis()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.MUPgTaacHnwLRmoJOGqdcZFUrOL();
		}

		public float GetAxisPrev()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.yhRTsdEWjwmGOFpFVsccvsWQDxL();
		}

		public float GetAxisDelta()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.MxVwcGGHbhfnGaNVFIbAAyLbxvPW();
		}

		public double GetAxisTimeActive()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.ROFGAKBXkOUSJeiEwdoIaObzuwAv();
		}

		public double GetAxisTimeInactive()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.XordwqAACJLMnlJHKUPRKMLQKpf();
		}

		public float GetAxisRaw()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.TXbcHqVYmBHhznWplhLLhIEHQBL();
		}

		public float GetAxisRawDelta()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.foEYEhchSOmnmeJMLCbFaILSvQG();
		}

		public float GetAxisRawPrev()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.MfSnbsPnoWwCjfydtGxjRngFzAj();
		}

		public double GetAxisRawTimeActive()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.OspDFsiqCYnXKftWMMvwNmljEZeJ();
		}

		public double GetAxisRawTimeInactive()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.QsPMxpiDfIBdQvNJUKjEgcEdDeIh();
		}

		public AxisCoordinateMode GetAxisCoordinateMode()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.YQlzAWiCZMlULuDcbVAWgHxwLnp();
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.wrzdWLIoStIKtAegJzJFnwZdBuh();
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.vOVSrAcaeceLsbxuJNqiLFDYiMV();
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.OGNTTWyRbuqPgdvDWeihzMCoqOf();
		}

		public bool GetButton()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.JFLhhsViRZmASHFRAirmzVNMOhf();
		}

		public bool GetButtonPrev()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.NyQDvOIzDpkRBsleftaSWfWiBaUD();
		}

		public bool GetButtonDown()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.CmwiIVrqfDqUrfdgDhwXnRxwqAE();
		}

		public bool GetButtonUp()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.cpecOFaBXVFHwWEOrZWGPOEkoSMP();
		}

		public bool GetButtonSinglePressHold()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.QTLvXIaYFpPMOZfpIGILrPOecaW();
		}

		public bool GetButtonSinglePressDown()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.PpZWnKYAyeadsuKqJmajERczqNY();
		}

		public bool GetButtonSinglePressUp()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.ADNfTWTmfSlOGQjlvAAfCePfsin();
		}

		public bool GetButtonDoublePressDown()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.iglKEgVKDfDRCUxquknahEhdtbQ();
		}

		public bool GetButtonDoublePressDown(float speed)
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.iglKEgVKDfDRCUxquknahEhdtbQ(speed);
		}

		public bool GetButtonDoublePressHold()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.UUZmGlAOcRhchLoNsdBteRISnEQE();
		}

		public bool GetButtonDoublePressHold(float speed)
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.UUZmGlAOcRhchLoNsdBteRISnEQE(speed);
		}

		public bool GetButtonDoublePressUp()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.pnzcIdXJrVISsrBwsrgSONYhjwk();
		}

		public bool GetButtonDoublePressUp(float speed)
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.pnzcIdXJrVISsrBwsrgSONYhjwk(speed);
		}

		public bool GetButtonTimedPress(float time)
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.MJFiUNuBLTbsJUlFjOVlfkwzBgo(time, 0f);
		}

		public bool GetButtonTimedPress(float time, float expireIn)
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.MJFiUNuBLTbsJUlFjOVlfkwzBgo(time, expireIn);
		}

		public bool GetButtonTimedPressDown(float time)
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.AhxzbaandODBCebugdYNafXSfVN(time);
		}

		public bool GetButtonTimedPressUp(float time)
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.JmakveFOtToTPFfcUGpGDreIVVz(time, 0f);
		}

		public bool GetButtonTimedPressUp(float time, float expireIn)
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.JmakveFOtToTPFfcUGpGDreIVVz(time, expireIn);
		}

		public bool GetButtonShortPress()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.TDNQHJbeFKJoDxwtrnohFGhnGia();
		}

		public bool GetButtonShortPressDown()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.SZLlYDUKPLfOpUVKZFqrIpeYOdq();
		}

		public bool GetButtonShortPressUp()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.uRjrrpPoOXyApRzAqZxwayRoyBU();
		}

		public bool GetButtonLongPress()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.DPQEfEAGIkMdCxLzhUjNTnVWWUN();
		}

		public bool GetButtonLongPressDown()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.UFEBQdeMjJKkVodijCmWCvPyPZJ();
		}

		public bool GetButtonLongPressUp()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.UuXvkSSlJNzydOxqRRfMzGOVYQy();
		}

		public bool GetButtonRepeating()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.xOVlFzhoZHfZzLUlrOuAqsoKUMU();
		}

		public double GetButtonTimePressed()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.eJIkDJIkPHkALOKPLNjWUzeoogP();
		}

		public double GetButtonTimeUnpressed()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.MiBhFkgQyEvQDqNzuybFYrVQgkac();
		}

		public bool GetNegativeButton()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.gjvFsQfWVLkGJLUlHHOwfcVAxgI();
		}

		public bool GetNegativeButtonPrev()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.tWNGjrHjjCtCJlLkJMXkyfcwFWa();
		}

		public bool GetNegativeButtonDown()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.wiPVOSjfQFqDVBfmgbvuPukNqlZ();
		}

		public bool GetNegativeButtonUp()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.lSoChdolRrcjvhCMgWkTNuSJzJM();
		}

		public bool GetNegativeButtonSinglePressHold()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.wfyKocGkSJJKuvaaDQlbFFZlulI();
		}

		public bool GetNegativeButtonSinglePressDown()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.rNxXdvHMHaWDHmdpbxJrhVReEuF();
		}

		public bool GetNegativeButtonSinglePressUp()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.LzYqCFtmOAPwFtaNIIAsdeKJjuUW();
		}

		public bool GetNegativeButtonDoublePressDown()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.wvfXZLJtMOTHRZqKjHcKgEZqIhQy();
		}

		public bool GetNegativeButtonDoublePressDown(float speed)
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.wvfXZLJtMOTHRZqKjHcKgEZqIhQy(speed);
		}

		public bool GetNegativeButtonDoublePressHold()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.agUAqgemdZpaKOMTCmtHqKZcEwxg();
		}

		public bool GetNegativeButtonDoublePressHold(float speed)
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.agUAqgemdZpaKOMTCmtHqKZcEwxg(speed);
		}

		public bool GetNegativeButtonDoublePressUp()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.KCcpdVlzpCIiXRUPqJoMFQeqdHsG();
		}

		public bool GetNegativeButtonDoublePressUp(float speed)
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.KCcpdVlzpCIiXRUPqJoMFQeqdHsG(speed);
		}

		public bool GetNegativeButtonTimedPress(float time)
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.HgLItgBCWBsCCYWNBKmKgGDoubH(time, 0f);
		}

		public bool GetNegativeButtonTimedPress(float time, float expireIn)
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.HgLItgBCWBsCCYWNBKmKgGDoubH(time, expireIn);
		}

		public bool GetNegativeButtonTimedPressDown(float time)
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.cDGRdmSKZRTpXeZTLCaInrAktM(time);
		}

		public bool GetNegativeButtonTimedPressUp(float time)
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.rwPIJlCPHsrUNNKCobpqYFjHDAa(time, 0f);
		}

		public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.rwPIJlCPHsrUNNKCobpqYFjHDAa(time, expireIn);
		}

		public bool GetNegativeButtonShortPress()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.nHowdczhJjGQpHoPuhSaxofMeXU();
		}

		public bool GetNegativeButtonShortPressDown()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.QfazomiUZJqoaCvaEoGdIyvImmi();
		}

		public bool GetNegativeButtonShortPressUp()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.RBTuBJtXUddlICbnuMOEmSITWbP();
		}

		public bool GetNegativeButtonLongPress()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.AoOcxpYeHjMNEyQbNoVoYGGKEYs();
		}

		public bool GetNegativeButtonLongPressDown()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.DDgdmSGHKLLlIOmMiTkGuXLuBNc();
		}

		public bool GetNegativeButtonLongPressUp()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.JGzwiBNdgTVqoMIKduxivCKdvVw();
		}

		public bool GetNegativeButtonRepeating()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.pXXQSEbZHuROokYgEnrXGPzdGtEF();
		}

		public double GetNegativeButtonTimePressed()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.DhArtyydFWSPilbKMhnJVHChwHy();
		}

		public double GetNegativeButtonTimeUnpressed()
		{
			return oYheOBEKSVfBFHpzHdTAEVpyfjjB.BfgghzcXbdXcPKaJgTuZMqYCxjg();
		}

		public IList<InputActionSourceData> GetCurrentInputSources()
		{
			return ReInput.AkpZeTvTvDWYnEqWDyDWrcufUCI.RBIWoiWucaBtFKDYvIAUOHZykHm(playerId, actionId, true)?.uvXaIVxGMrdmWpixZvZhiudfpZs();
		}

		public bool IsCurrentInputSource(ControllerType controllerType)
		{
			return ReInput.AkpZeTvTvDWYnEqWDyDWrcufUCI.RBIWoiWucaBtFKDYvIAUOHZykHm(playerId, actionId, true)?.CEioayAKpkHgZSUoQlmVRVAagDk(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
		{
			return ReInput.AkpZeTvTvDWYnEqWDyDWrcufUCI.RBIWoiWucaBtFKDYvIAUOHZykHm(playerId, actionId, true)?.CEioayAKpkHgZSUoQlmVRVAagDk(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(Controller controller)
		{
			return ReInput.AkpZeTvTvDWYnEqWDyDWrcufUCI.RBIWoiWucaBtFKDYvIAUOHZykHm(playerId, actionId, true)?.CEioayAKpkHgZSUoQlmVRVAagDk(controller) ?? false;
		}

		internal InputActionEventData(VvbRiPIRRDOGFeaGvZCVmBjRfXT vc, int playerId, int actionId, UpdateLoopType updateLoop)
		{
			skCXQflGfBodQoycRuGsAVLfAHe = InputActionEventType.Update;
			oYheOBEKSVfBFHpzHdTAEVpyfjjB = vc;
			this.playerId = playerId;
			this.actionId = actionId;
			this.updateLoop = updateLoop;
		}
	}
}
