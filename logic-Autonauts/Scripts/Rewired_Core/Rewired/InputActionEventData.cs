using System.Collections.Generic;

namespace Rewired
{
	public struct InputActionEventData
	{
		private CvKbBDBykgOtczqdWEjAImsohWR tvUFTiRdcmVkeeWqGJeDnGqQBkf;

		private InputActionEventType zdzZjvqAEcldtxdPuEKzkOQYwvs;

		public readonly int playerId;

		public readonly int actionId;

		public readonly UpdateLoopType updateLoop;

		public InputActionEventType eventType
		{
			get
			{
				return zdzZjvqAEcldtxdPuEKzkOQYwvs;
			}
			internal set
			{
				zdzZjvqAEcldtxdPuEKzkOQYwvs = value;
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
				return ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.YvfKaVFkYNkHtYuRlvvGuDrWhaQ(actionId).name;
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
				return ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.YvfKaVFkYNkHtYuRlvvGuDrWhaQ(actionId).descriptiveName;
			}
		}

		public float GetAxis()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.BscAVytxcCBkilFutmFsULYtqRF();
		}

		public float GetAxisPrev()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.nBcptjXKjHAyjSgEkspdFFUtFBF();
		}

		public float GetAxisDelta()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.FWqrdMBKKArdbCsaupQHAvMUZeZ();
		}

		public float GetAxisTimeActive()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.QlsZJKCPPdMMezfBNiIPqeuYKCU();
		}

		public float GetAxisTimeInactive()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.IsCKtsVajcjEGiegzADGjaKbpPrp();
		}

		public float GetAxisRaw()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.KfAFlDbMroUFANmhWhpKpXVscgPy();
		}

		public float GetAxisRawDelta()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.ovrCLOGpIbrcKBnmgOGqeGVtoJOl();
		}

		public float GetAxisRawPrev()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.RFtmscItPvoqKaeIKqYmnAxaEFjc();
		}

		public float GetAxisRawTimeActive()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.LJWSkgbzTlDfRuxelvtoMqlKbck();
		}

		public float GetAxisRawTimeInactive()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.TrkGHhjmArHpdwqsdHfVGLRIPUA();
		}

		public AxisCoordinateMode GetAxisCoordinateMode()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.ZzCfsKahtdtlpsxqCePBmIIDunbH();
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.bDEegGHDBrFOfRFVTkpQgjrgjloI();
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.yuyzRIpPZDneVqqZyFLhjQWxykJ();
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.LjedWJflqCBcmHyMkmozYLDVmKUF();
		}

		public bool GetButton()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.OMsDoddGLoMsnAOixNusrDCoKsdq();
		}

		public bool GetButtonPrev()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.AAdwUYLeaIBDydaNOceNayNTDMI();
		}

		public bool GetButtonDown()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.VoFALJiXKwwyQgLPqqsGLZcLBoM();
		}

		public bool GetButtonUp()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.zZfNFOMmkwRPDTjWQEBszXZnyS();
		}

		public bool GetButtonSinglePressHold()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.HSgGoWrdyQlRfGWElIYGTWJBSOK();
		}

		public bool GetButtonSinglePressDown()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.ODUcBxgJzPGmQZrvLHwtywMKnSVC();
		}

		public bool GetButtonSinglePressUp()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.VfgUqUOpVrAbpFtGMvSgiqUMoGr();
		}

		public bool GetButtonDoublePressDown()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.zLExFcCVwGmJlXFXVImjVBwCEZKB();
		}

		public bool GetButtonDoublePressDown(float speed)
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.zLExFcCVwGmJlXFXVImjVBwCEZKB(speed);
		}

		public bool GetButtonDoublePressHold()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.RuiZcjLOJskVOMqsJZYkxDIjyhA();
		}

		public bool GetButtonDoublePressHold(float speed)
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.RuiZcjLOJskVOMqsJZYkxDIjyhA(speed);
		}

		public bool GetButtonDoublePressUp()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.muCXbdCwQsGYDmNJFtnRwqLKQDq();
		}

		public bool GetButtonDoublePressUp(float speed)
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.muCXbdCwQsGYDmNJFtnRwqLKQDq(speed);
		}

		public bool GetButtonTimedPress(float time)
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.LIagbRzpgaHmaNasOBJuJLfEbEmS(time, 0f);
		}

		public bool GetButtonTimedPress(float time, float expireIn)
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.LIagbRzpgaHmaNasOBJuJLfEbEmS(time, expireIn);
		}

		public bool GetButtonTimedPressDown(float time)
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.TmWmkgzOAdaTdHxVZjOYtSYjapHU(time);
		}

		public bool GetButtonTimedPressUp(float time)
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.SnZcquUjSouueUwNdDjJzfjnhdte(time, 0f);
		}

		public bool GetButtonTimedPressUp(float time, float expireIn)
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.SnZcquUjSouueUwNdDjJzfjnhdte(time, expireIn);
		}

		public bool GetButtonShortPress()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.MEkWNPeIovcPibcOIDriEloGWCek();
		}

		public bool GetButtonShortPressDown()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.JFwxaZRBlqWpKNDcitBhgiyflkm();
		}

		public bool GetButtonShortPressUp()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.hXCuaxWdNcueYQiGLdDrJSdNZAIM();
		}

		public bool GetButtonLongPress()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.EWlxTOVmbBtSlquMQaYQrQofJeT();
		}

		public bool GetButtonLongPressDown()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.FklPSljcUaxKydxZYdiDkSYZolB();
		}

		public bool GetButtonLongPressUp()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.HvqSyQJyWgHfIBWSkTRNTFVuOsy();
		}

		public bool GetButtonRepeating()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.qPoCvloGegNyKIgEIqqJKorfkQQ();
		}

		public float GetButtonTimePressed()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.jnrghDiZPgbmyiBvsKLDzacNTQXV();
		}

		public float GetButtonTimeUnpressed()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.JEsKHudJBvOeefFUHbwCaBYpWQc();
		}

		public bool GetNegativeButton()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.nkChpEwCeyIAcExUuFGdJLElwIA();
		}

		public bool GetNegativeButtonPrev()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.gzqiXpQjOddOoitBcBObUOtREys();
		}

		public bool GetNegativeButtonDown()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.npsYQCyKleLimEhZDAdnaxnwlFNO();
		}

		public bool GetNegativeButtonUp()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.sqLJephBcMrzUHldDlcYpoVsgfQC();
		}

		public bool GetNegativeButtonSinglePressHold()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.ngPfxaJknmSuXcFPylUatEwGRfE();
		}

		public bool GetNegativeButtonSinglePressDown()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.kLYaolUGcRNJqlKSEZFkBHCVEHX();
		}

		public bool GetNegativeButtonSinglePressUp()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.KTpXYTuqpfgzcuQcdAthQbBmJOK();
		}

		public bool GetNegativeButtonDoublePressDown()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.dOAGKPSipdZlaAbbEokZoDIHHLC();
		}

		public bool GetNegativeButtonDoublePressDown(float speed)
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.dOAGKPSipdZlaAbbEokZoDIHHLC(speed);
		}

		public bool GetNegativeButtonDoublePressHold()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.fdzmsdIYwqztXcolheWsrQJMyv();
		}

		public bool GetNegativeButtonDoublePressHold(float speed)
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.fdzmsdIYwqztXcolheWsrQJMyv(speed);
		}

		public bool GetNegativeButtonDoublePressUp()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.XdNeOHquIhupqYJaJiORbbtHbhq();
		}

		public bool GetNegativeButtonDoublePressUp(float speed)
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.XdNeOHquIhupqYJaJiORbbtHbhq(speed);
		}

		public bool GetNegativeButtonTimedPress(float time)
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.WMiTTwIKzyDqbfPtkXAZnODLxCJw(time, 0f);
		}

		public bool GetNegativeButtonTimedPress(float time, float expireIn)
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.WMiTTwIKzyDqbfPtkXAZnODLxCJw(time, expireIn);
		}

		public bool GetNegativeButtonTimedPressDown(float time)
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.zFcbFfEbtqAVMVOymyDrayobmQYK(time);
		}

		public bool GetNegativeButtonTimedPressUp(float time)
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.uEyIDtIDaHApazSzDPxtOwMsWvuF(time, 0f);
		}

		public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.uEyIDtIDaHApazSzDPxtOwMsWvuF(time, expireIn);
		}

		public bool GetNegativeButtonShortPress()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.miFsbiglmYCEIAQeXkMbXRqjCtSb();
		}

		public bool GetNegativeButtonShortPressDown()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.JKHpwqnigmDeLJUNtVsqeZifnYu();
		}

		public bool GetNegativeButtonShortPressUp()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.IcsRdTqDrEgjriRMBoSRZQDqaiFs();
		}

		public bool GetNegativeButtonLongPress()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.RLljstHsoOvZfhmQakvzwAXfDac();
		}

		public bool GetNegativeButtonLongPressDown()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.SjLycOTsrePJjJUvBGJNSZOVUxa();
		}

		public bool GetNegativeButtonLongPressUp()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.KICXvNWuNoIHXBEvQauvdVBOXPcS();
		}

		public bool GetNegativeButtonRepeating()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.eTqXvIgOuFMZVnfBflDIiPcAHfM();
		}

		public float GetNegativeButtonTimePressed()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.SNpTuqvaAdXSNapYjhpWziGUhCc();
		}

		public float GetNegativeButtonTimeUnpressed()
		{
			return tvUFTiRdcmVkeeWqGJeDnGqQBkf.SdYdndgjwYvDZnPLsdBngufGdHlP();
		}

		public IList<InputActionSourceData> GetCurrentInputSources()
		{
			CvKbBDBykgOtczqdWEjAImsohWR cvKbBDBykgOtczqdWEjAImsohWR = ReInput.TjEnOXyhIcFYKPeZiqgPVRhKsqQ.OUnbwyZZsFhhoRnwAIfHsGBBrEe(playerId, actionId, true);
			if (cvKbBDBykgOtczqdWEjAImsohWR == null)
			{
				return null;
			}
			return cvKbBDBykgOtczqdWEjAImsohWR.ltyejBmKjAhszqAMwxRwOxaYHbi();
		}

		public bool IsCurrentInputSource(ControllerType controllerType)
		{
			CvKbBDBykgOtczqdWEjAImsohWR cvKbBDBykgOtczqdWEjAImsohWR = ReInput.TjEnOXyhIcFYKPeZiqgPVRhKsqQ.OUnbwyZZsFhhoRnwAIfHsGBBrEe(playerId, actionId, true);
			if (cvKbBDBykgOtczqdWEjAImsohWR == null)
			{
				return false;
			}
			return cvKbBDBykgOtczqdWEjAImsohWR.DeJlmiFsOPqKkRgDxwnGrhHZjAk(controllerType);
		}

		public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
		{
			CvKbBDBykgOtczqdWEjAImsohWR cvKbBDBykgOtczqdWEjAImsohWR = ReInput.TjEnOXyhIcFYKPeZiqgPVRhKsqQ.OUnbwyZZsFhhoRnwAIfHsGBBrEe(playerId, actionId, true);
			if (cvKbBDBykgOtczqdWEjAImsohWR == null)
			{
				return false;
			}
			return cvKbBDBykgOtczqdWEjAImsohWR.DeJlmiFsOPqKkRgDxwnGrhHZjAk(controllerType, controllerId);
		}

		public bool IsCurrentInputSource(Controller controller)
		{
			CvKbBDBykgOtczqdWEjAImsohWR cvKbBDBykgOtczqdWEjAImsohWR = ReInput.TjEnOXyhIcFYKPeZiqgPVRhKsqQ.OUnbwyZZsFhhoRnwAIfHsGBBrEe(playerId, actionId, true);
			if (cvKbBDBykgOtczqdWEjAImsohWR == null)
			{
				return false;
			}
			return cvKbBDBykgOtczqdWEjAImsohWR.DeJlmiFsOPqKkRgDxwnGrhHZjAk(controller);
		}

		internal InputActionEventData(CvKbBDBykgOtczqdWEjAImsohWR vc, int playerId, int actionId, UpdateLoopType updateLoop)
		{
			zdzZjvqAEcldtxdPuEKzkOQYwvs = InputActionEventType.Update;
			tvUFTiRdcmVkeeWqGJeDnGqQBkf = vc;
			this.playerId = playerId;
			this.actionId = actionId;
			this.updateLoop = updateLoop;
		}
	}
}
