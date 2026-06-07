using System.Collections.Generic;

namespace Rewired
{
	public struct InputActionEventData
	{
		private dhgRPzBCLEtjJBicagpEtUtuCThf ETVdslujedSzWsCSTzcoETAAFAMH;

		private InputActionEventType spxizADxVwouKiezLetMAJKwzdLCA;

		public readonly int playerId;

		public readonly int actionId;

		public readonly UpdateLoopType updateLoop;

		public InputActionEventType eventType
		{
			get
			{
				return spxizADxVwouKiezLetMAJKwzdLCA;
			}
			internal set
			{
				spxizADxVwouKiezLetMAJKwzdLCA = inputActionEventType;
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
				return ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.cyZjgBDAIIsjivyJJljRrGGufDpj(actionId).name;
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
				return ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.cyZjgBDAIIsjivyJJljRrGGufDpj(actionId).descriptiveName;
			}
		}

		public float GetAxis()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.YUjfnjGGGnqMPGxXAPaENJeIDUqWc();
		}

		public float GetAxisPrev()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.gFAaxRimefDUHASXCLCgGaxeRyOBA();
		}

		public float GetAxisDelta()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.CEanUklplMerNgobhMomgCKByRHvB();
		}

		public double GetAxisTimeActive()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.LXLPgcvnRsPAOdhoJwEChctmxuoo();
		}

		public double GetAxisTimeInactive()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.HMPFEoFRINMQtOwnhBKCwkYZitiGA();
		}

		public float GetAxisRaw()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.TCDdfCbKggAPtiwQGokuKSEFYXbDA();
		}

		public float GetAxisRawDelta()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.TchNrNGLZqpqhynPGrgMfaRTHfDI();
		}

		public float GetAxisRawPrev()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.GzjLUajTFUHUlvGsMBpskFQeAJPjA();
		}

		public double GetAxisRawTimeActive()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.OboXbWJjsLlPftXoIOqFYsWmBCAj();
		}

		public double GetAxisRawTimeInactive()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.ttYncCqZNaEMomAFsgeRDmLuIMvab();
		}

		public AxisCoordinateMode GetAxisCoordinateMode()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.XtfqXDnNNCanHiYdrTIZBTaRqCcT();
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.ZMJFBMeekjOGMaOeHZvgyJsKTlrPA();
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.bbTJDBYubXJGDMKKbWFHaqAdnTaB();
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.bwoebdhvgzUuoIkpIOXswqkaitvB();
		}

		public bool GetButton()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.MxEcNwtqdlIeerRnDukWeLuLhuJf();
		}

		public bool GetButtonPrev()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.liXbUFHVCBpFhLWTDlKOjLPFBciB();
		}

		public bool GetButtonDown()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.rXrZPQfPVJBUbrjAjiOwpsbsoMBx();
		}

		public bool GetButtonUp()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.rrhxDOjcPWqQgLfbTarpEkBOkrpI();
		}

		public bool GetButtonSinglePressHold()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.IMesJCWkGWMkoFOzoNTQcWNjPzhC();
		}

		public bool GetButtonSinglePressDown()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.OIdzQJjuZVtKkZuiimJuXxTbGrpS();
		}

		public bool GetButtonSinglePressUp()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.KzdFwycHikmAYbIGeasoFGFhyGKTB();
		}

		public bool GetButtonDoublePressDown()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.YJhzSzvZoftaDehpMvWeRtvpaGoo();
		}

		public bool GetButtonDoublePressDown(float speed)
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.gLJFtiAyWSigKkAxGnnnHaGHaSXZ(speed);
		}

		public bool GetButtonDoublePressHold()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.lHTZzaPVbGAPhBJkgLSFycOIhdxcA();
		}

		public bool GetButtonDoublePressHold(float speed)
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.xGzEFpGsojiRndDhgKgoTOCODuKHB(speed);
		}

		public bool GetButtonDoublePressUp()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.AAYTylJNxkzMtJcWEpQIkGeEUBpL();
		}

		public bool GetButtonDoublePressUp(float speed)
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.UJzDLqngfKZfwwGFxLGcXaeidbxL(speed);
		}

		public bool GetButtonTimedPress(float time)
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.qozCBEkJHtwbCPinkrfRknkdhoqeb(time, 0f);
		}

		public bool GetButtonTimedPress(float time, float expireIn)
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.qozCBEkJHtwbCPinkrfRknkdhoqeb(time, expireIn);
		}

		public bool GetButtonTimedPressDown(float time)
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.jVjJkYKrrNEiZSHbnGbmIcYwvyOO(time);
		}

		public bool GetButtonTimedPressUp(float time)
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.GBgOspgmWlzNTXGUrDJdabTMgeLbb(time, 0f);
		}

		public bool GetButtonTimedPressUp(float time, float expireIn)
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.GBgOspgmWlzNTXGUrDJdabTMgeLbb(time, expireIn);
		}

		public bool GetButtonShortPress()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.UbUVWSbJsilCmSHGMfehdGYCIgCW();
		}

		public bool GetButtonShortPressDown()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.GQiBxAivXCVFEsHXHZjXqdpTfmLc();
		}

		public bool GetButtonShortPressUp()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.qlKBOPfbpvRTxIgGgYfNUsruDPswA();
		}

		public bool GetButtonLongPress()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.LmfrdlDnMtLuYDOWHWUteOtwwgQN();
		}

		public bool GetButtonLongPressDown()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.fITinqfPzqbfabpxMpdpXBmDXFlv();
		}

		public bool GetButtonLongPressUp()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.miaYeVbqUiWlNiWtwobHLCmPYlNd();
		}

		public bool GetButtonRepeating()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.wFjQJJLAvFQAiYmkUddgklxfsbWHA();
		}

		public double GetButtonTimePressed()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.hSwdgViNMjnoHaXGdaynKZfSMbgEA();
		}

		public double GetButtonTimeUnpressed()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.OdOMJtTggWNcMYBGCqrFyAsBXDYv();
		}

		public bool GetNegativeButton()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.UmCYrzZMweTSJRYbCywvSFwqDXcv();
		}

		public bool GetNegativeButtonPrev()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.cZhWZRGqyHFnygvAvSMnAcTrdhlJ();
		}

		public bool GetNegativeButtonDown()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.SXkkCHQJRMzOMmxushyoGBTkBdoIA();
		}

		public bool GetNegativeButtonUp()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.TagQxdEpgEJNLcLxWDqJBKBfzXpOA();
		}

		public bool GetNegativeButtonSinglePressHold()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.btfJMvnFgnhSOnWsOHJeYcVCLnPl();
		}

		public bool GetNegativeButtonSinglePressDown()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.NnjhgnrvOwajKeXwSEqNBRvoSlWB();
		}

		public bool GetNegativeButtonSinglePressUp()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.JbBDNNzhKAhAleqsuVYMGJoVCIgj();
		}

		public bool GetNegativeButtonDoublePressDown()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.KpqUbfJxlPbQjaLMbdyJejwmKxIT();
		}

		public bool GetNegativeButtonDoublePressDown(float speed)
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.WbGXiRufRLdVFrbmBJNuPjWWTCZj(speed);
		}

		public bool GetNegativeButtonDoublePressHold()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.vRZcnIbddISKHvRAubrBdvyngESr();
		}

		public bool GetNegativeButtonDoublePressHold(float speed)
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.IOKNZPyiJUFNvjeFKQCCUSZGeVLc(speed);
		}

		public bool GetNegativeButtonDoublePressUp()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.dXEfjYjchWzkqdkVDExsFxcoEwLAb();
		}

		public bool GetNegativeButtonDoublePressUp(float speed)
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.sJXRlomLwvumiMtlrFCyzJDlKXYd(speed);
		}

		public bool GetNegativeButtonTimedPress(float time)
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.MbiGHOFuOrudkJTfefnEApGkcIcZB(time, 0f);
		}

		public bool GetNegativeButtonTimedPress(float time, float expireIn)
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.MbiGHOFuOrudkJTfefnEApGkcIcZB(time, expireIn);
		}

		public bool GetNegativeButtonTimedPressDown(float time)
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.bCRGhyLPrIrwZcSBolJdJdKGiajh(time);
		}

		public bool GetNegativeButtonTimedPressUp(float time)
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.YTAjZKfozgkhUNaQeJhmPdPaeWoJ(time, 0f);
		}

		public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.YTAjZKfozgkhUNaQeJhmPdPaeWoJ(time, expireIn);
		}

		public bool GetNegativeButtonShortPress()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.fekVflJRTBrwpLSQSFoanCIvRlAy();
		}

		public bool GetNegativeButtonShortPressDown()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.nwHOEJwTdZLLNSGpDtDXAvEyveRv();
		}

		public bool GetNegativeButtonShortPressUp()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.GaqpYWpDXSGJnuNRYvOQFpdCdgDX();
		}

		public bool GetNegativeButtonLongPress()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.FRQHTzPnYughiSpCuiHJGALtWMmPA();
		}

		public bool GetNegativeButtonLongPressDown()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.hOSuOVrMBzfKDtHoTIHnFcQXgnWSA();
		}

		public bool GetNegativeButtonLongPressUp()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.SAtfgtyMVjIlidHIgorrvnAuINli();
		}

		public bool GetNegativeButtonRepeating()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.hpKBlFdTbcLxxEDttXJWVHxJfGLTA();
		}

		public double GetNegativeButtonTimePressed()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.lLjRBQUrTCvvTBKsvnwQLDDOIjbL();
		}

		public double GetNegativeButtonTimeUnpressed()
		{
			return ETVdslujedSzWsCSTzcoETAAFAMH.LWgnGcdKmURDmXofDlCdzZkFIQIU();
		}

		public IList<InputActionSourceData> GetCurrentInputSources()
		{
			return ReInput.MRYlWddHEDKxegbDTAfXRjoQYitX.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(playerId, actionId, true)?.sCJioeEbdozgSmoBldokHvfiZUcT();
		}

		public bool IsCurrentInputSource(ControllerType controllerType)
		{
			return ReInput.MRYlWddHEDKxegbDTAfXRjoQYitX.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(playerId, actionId, true)?.baBOLEYgyzDsjIjkljKfhMidPlQCb(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
		{
			return ReInput.MRYlWddHEDKxegbDTAfXRjoQYitX.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(playerId, actionId, true)?.pwHtsFYQtWhrDZNXssuNhOlGrgzF(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(Controller controller)
		{
			return ReInput.MRYlWddHEDKxegbDTAfXRjoQYitX.SzQMjqFNTiRRVtTiIQeEKTlKMdBW(playerId, actionId, true)?.iYaMCoEdjxKTlzCtBEfPqzoZlTNs(controller) ?? false;
		}

		internal InputActionEventData(dhgRPzBCLEtjJBicagpEtUtuCThf P_0, int P_1, int P_2, UpdateLoopType P_3)
		{
			spxizADxVwouKiezLetMAJKwzdLCA = InputActionEventType.Update;
			ETVdslujedSzWsCSTzcoETAAFAMH = P_0;
			playerId = P_1;
			actionId = P_2;
			updateLoop = P_3;
		}
	}
}
