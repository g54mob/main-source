using System.Collections.Generic;

namespace Rewired
{
	public struct InputActionEventData
	{
		private lXvJAREcFJqTwbpbVaXyWnOsESQEA YhSkqVjwtoTglGIVuoWOrbdItZbQ;

		private InputActionEventType gOcmVoOSqxOenKEyyEiiksrehluk;

		public readonly int playerId;

		public readonly int actionId;

		public readonly UpdateLoopType updateLoop;

		public InputActionEventType eventType
		{
			get
			{
				return gOcmVoOSqxOenKEyyEiiksrehluk;
			}
			internal set
			{
				gOcmVoOSqxOenKEyyEiiksrehluk = inputActionEventType;
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
				return ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.sAOuuCAMJXQrJLEfgeCrKQxwHbAU(actionId).name;
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
				return ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.sAOuuCAMJXQrJLEfgeCrKQxwHbAU(actionId).descriptiveName;
			}
		}

		public float GetAxis()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.MsemiDNvFwuvkRHSoRvueQDDCJHf();
		}

		public float GetAxisPrev()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.iARuJzhKfksmmefEbtjGLMIccAzj();
		}

		public float GetAxisDelta()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.ExxDOAmagHRcREqfGZQurrWsFuDc();
		}

		public double GetAxisTimeActive()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.XiKxkUgGTtihtRtvqpcwOGOecMTd();
		}

		public double GetAxisTimeInactive()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.XuKFMGOoNSwfKUGeWhrwBSlRElRQ();
		}

		public float GetAxisRaw()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.DeKBwydovtExYTMFfxXAMhbNoHGib();
		}

		public float GetAxisRawDelta()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.BdaHQfLkEvGBCUeozQWwIYuZHFar();
		}

		public float GetAxisRawPrev()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.MqeXSgkURrlITajbbOSBTjoHZyCA();
		}

		public double GetAxisRawTimeActive()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.KElJOkInzYZLQVwltsxzlrlgwXtM();
		}

		public double GetAxisRawTimeInactive()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.roHxuXfMZhsRBUAwHVnNJcpuOWDc();
		}

		public AxisCoordinateMode GetAxisCoordinateMode()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.LQaElQuMCTXqbYumMnzYmPARIRub();
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.FuQAMivUrksgreotkQRWeINQfpWi();
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.vDulGhZlxqUzfkQBKWdlZKXfafgjA();
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.bNxKzNquaqGmLwDjtddfJNBiYgOuA();
		}

		public bool GetButton()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.IPBglEDiskLyDaFoCmNkHNTILvkoD();
		}

		public bool GetButtonPrev()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.nEpMkgAlUKaHmxrXsfKeYHsLoBLs();
		}

		public bool GetButtonDown()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.riuGhwaMOAdFGDFRYDzUUxYehYkQ();
		}

		public bool GetButtonUp()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.bSwJemwUEXGGBhhqyxFRvLmWIqGY();
		}

		public bool GetButtonSinglePressHold()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.MsrPrsRShXkgVvDLLEcmCVbzOLQcA();
		}

		public bool GetButtonSinglePressDown()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.IVgCBhoYMSCaNnypJLyYwFolNdOM();
		}

		public bool GetButtonSinglePressUp()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.IgudzUOMbpcOxmaZREBGjJgoJIdR();
		}

		public bool GetButtonDoublePressDown()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.GWidDBskfsOUcIruxijQqOWxDSXeA();
		}

		public bool GetButtonDoublePressDown(float speed)
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.mXMcUQLDjZKLbSwyrIXXizIZMakC(speed);
		}

		public bool GetButtonDoublePressHold()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.pcSwGAONmZlhYxnjFhOxZFzCnXKf();
		}

		public bool GetButtonDoublePressHold(float speed)
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.hckAhLzhvsGrGziwjLVYftlXjutR(speed);
		}

		public bool GetButtonDoublePressUp()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.KCDIMXAWapdXMarBIjGgyPDjYWOXB();
		}

		public bool GetButtonDoublePressUp(float speed)
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.KAqgQWsIxLEjXBUDMPaMLyXeYtAn(speed);
		}

		public bool GetButtonTimedPress(float time)
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.iLyUWcCExyFVnKqBTGfvQeHpisZi(time, 0f);
		}

		public bool GetButtonTimedPress(float time, float expireIn)
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.iLyUWcCExyFVnKqBTGfvQeHpisZi(time, expireIn);
		}

		public bool GetButtonTimedPressDown(float time)
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.jemjNeDdmCWQgidsYMLMtrxauMpI(time);
		}

		public bool GetButtonTimedPressUp(float time)
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.ItrlVrVHcgtqpFPEduZHYaUCqwsA(time, 0f);
		}

		public bool GetButtonTimedPressUp(float time, float expireIn)
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.ItrlVrVHcgtqpFPEduZHYaUCqwsA(time, expireIn);
		}

		public bool GetButtonShortPress()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.UETjCacldnZLRsCFfOVVOpvGqwdQ();
		}

		public bool GetButtonShortPressDown()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.ATbRCRlVsJgfySlKcqwDTzADtFRI();
		}

		public bool GetButtonShortPressUp()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.uVNPDdyMewbdUMNPZOzbJiEcBZXf();
		}

		public bool GetButtonLongPress()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.XTygVrQDMeWzdvNCcbVUNEDkwhfC();
		}

		public bool GetButtonLongPressDown()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.lRGuwAswCvNtFPgHzSVLyVOVTlEC();
		}

		public bool GetButtonLongPressUp()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.yWxoBlcLzlemoOuRRYRbcWvDjOcV();
		}

		public bool GetButtonRepeating()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.saeQPtCwGGaeReinxCUMSwIrhYpF();
		}

		public double GetButtonTimePressed()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.zPnrApSpNsImmvGZMcFVanMSfpHKA();
		}

		public double GetButtonTimeUnpressed()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.KCXSSDWhrBKElyGJfiInJrZHDPlM();
		}

		public bool GetNegativeButton()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.EVDaaHKwprBiqlvanCLDzZZcIJDp();
		}

		public bool GetNegativeButtonPrev()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.wmkdKpTjlGQnDOmTMMrTrHwnIdMn();
		}

		public bool GetNegativeButtonDown()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.KhxBPpPiOXgSvGNtPRGOvHsskrZq();
		}

		public bool GetNegativeButtonUp()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.BljscRLzpNviyYundTExtmvpLKYc();
		}

		public bool GetNegativeButtonSinglePressHold()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.rGkjONohjkzPrXbjtneWnEsYAJiY();
		}

		public bool GetNegativeButtonSinglePressDown()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.PssLqSiqevMTMMAUxerYquegHQSU();
		}

		public bool GetNegativeButtonSinglePressUp()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.TcMLIdmkPPhJICPtZbiektZPSCJSA();
		}

		public bool GetNegativeButtonDoublePressDown()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.YoviFHAdcEKwAGpTGbJvXaPmsntn();
		}

		public bool GetNegativeButtonDoublePressDown(float speed)
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.YfTFApbwCYgRwLFdqfiQjkzWPNuab(speed);
		}

		public bool GetNegativeButtonDoublePressHold()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.rvGwiiqhiBZeaJVBVAOzSLZtxOjX();
		}

		public bool GetNegativeButtonDoublePressHold(float speed)
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.YrTrWftClZWtgPLbnibohShAEeuZ(speed);
		}

		public bool GetNegativeButtonDoublePressUp()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.vGLssieehRSnPXSswQKUWHAoyAsE();
		}

		public bool GetNegativeButtonDoublePressUp(float speed)
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.mASgYYxHWsnQZmJkMriECBovlKfw(speed);
		}

		public bool GetNegativeButtonTimedPress(float time)
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.YLhODevbPifVPfCqHgMeDIrcXKTZ(time, 0f);
		}

		public bool GetNegativeButtonTimedPress(float time, float expireIn)
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.YLhODevbPifVPfCqHgMeDIrcXKTZ(time, expireIn);
		}

		public bool GetNegativeButtonTimedPressDown(float time)
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.tUWRRMMUWPlLcOYXTSOBqCIELkSU(time);
		}

		public bool GetNegativeButtonTimedPressUp(float time)
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.MlFIiayGhxVYtdBnJSeOifmmXqPP(time, 0f);
		}

		public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.MlFIiayGhxVYtdBnJSeOifmmXqPP(time, expireIn);
		}

		public bool GetNegativeButtonShortPress()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.xdtelTQZIAOrSbeDpLVYUthjzRlF();
		}

		public bool GetNegativeButtonShortPressDown()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.xhWVfrbsxAxhqeaigwQjfdPqaBad();
		}

		public bool GetNegativeButtonShortPressUp()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.KzMLkitOPOzISfQfTrceQUKGuebA();
		}

		public bool GetNegativeButtonLongPress()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.HNTYPDOjRxFFLksZTwvjllazYDRK();
		}

		public bool GetNegativeButtonLongPressDown()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.tlDAVpqQQoUumHLpmFcRHXlNablBb();
		}

		public bool GetNegativeButtonLongPressUp()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.SgsZyJhnWgsoZNcDPZVRIXrmkMEV();
		}

		public bool GetNegativeButtonRepeating()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.pZNwfbMswzBhQnSkWqbkqnETAquh();
		}

		public double GetNegativeButtonTimePressed()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.zNaDAwIDQVnPuTtpIZSukgwOvEWqA();
		}

		public double GetNegativeButtonTimeUnpressed()
		{
			return YhSkqVjwtoTglGIVuoWOrbdItZbQ.PhtHWpmnxNpVNzyigfJhEPPVAdcb();
		}

		public IList<InputActionSourceData> GetCurrentInputSources()
		{
			return ReInput.AtHYwRgWVYrmVOsWolCxiSLKHuEp.QHFuKKuEdmbuZhdfgZkffCESrqCA(playerId, actionId, true)?.eBQtUYNynlYApWIXWJsWoIZiGIVd();
		}

		public bool IsCurrentInputSource(ControllerType controllerType)
		{
			return ReInput.AtHYwRgWVYrmVOsWolCxiSLKHuEp.QHFuKKuEdmbuZhdfgZkffCESrqCA(playerId, actionId, true)?.jFAgNigHnmLKAJcfKPxPNnXhxbjAA(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
		{
			return ReInput.AtHYwRgWVYrmVOsWolCxiSLKHuEp.QHFuKKuEdmbuZhdfgZkffCESrqCA(playerId, actionId, true)?.vjIfirZTXZjTihsQVnZfKGdMCzMO(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(Controller controller)
		{
			return ReInput.AtHYwRgWVYrmVOsWolCxiSLKHuEp.QHFuKKuEdmbuZhdfgZkffCESrqCA(playerId, actionId, true)?.mejgJWIJguAiMBDakeUrxDLpVBwLb(controller) ?? false;
		}

		internal InputActionEventData(lXvJAREcFJqTwbpbVaXyWnOsESQEA P_0, int P_1, int P_2, UpdateLoopType P_3)
		{
			gOcmVoOSqxOenKEyyEiiksrehluk = InputActionEventType.Update;
			YhSkqVjwtoTglGIVuoWOrbdItZbQ = P_0;
			playerId = P_1;
			actionId = P_2;
			updateLoop = P_3;
		}
	}
}
