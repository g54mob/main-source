using System.Collections.Generic;

namespace Rewired
{
	public struct InputActionEventData
	{
		private juUkCOtINcePpkOEZitZVEIfgiwq MxUwsGjVGwkMxJtfBTiOldMDXIE;

		private InputActionEventType SkpfswjAbyRqgVYqdsfskygZZqV;

		public readonly int playerId;

		public readonly int actionId;

		public readonly UpdateLoopType updateLoop;

		public InputActionEventType eventType
		{
			get
			{
				return SkpfswjAbyRqgVYqdsfskygZZqV;
			}
			internal set
			{
				SkpfswjAbyRqgVYqdsfskygZZqV = value;
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
				return ReInput.lUCgcEIquFfuykgBneGrfARQlcR.lwbVaAtXlFYOutHegWQNuVVFpCl(actionId).name;
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
				return ReInput.lUCgcEIquFfuykgBneGrfARQlcR.lwbVaAtXlFYOutHegWQNuVVFpCl(actionId).descriptiveName;
			}
		}

		public float GetAxis()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.yVcOttFFFEXExGWTsiXvWxyyabi();
		}

		public float GetAxisPrev()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.AjecSoCdxZoJeYzNvEDytVvgsEaJ();
		}

		public float GetAxisDelta()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.oYgeGHftjGZemfpNfwEWJCsRGMwE();
		}

		public double GetAxisTimeActive()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.pnsYwPcqyvIXnAxIQsTGkFUBcPve();
		}

		public double GetAxisTimeInactive()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.xoCMbnnjEoKFVDEPaFkHfuognYAb();
		}

		public float GetAxisRaw()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.jyWAvEiMviYlVTYdFOaVHgfjpXc();
		}

		public float GetAxisRawDelta()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.VobczBXzqxfTuADGjnIpEbruYfh();
		}

		public float GetAxisRawPrev()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.oGbFPxyeivBtXNjbFKjlfCTbxSU();
		}

		public double GetAxisRawTimeActive()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.crMWdnRmMtgSwRxUgJWcAGKBEoDe();
		}

		public double GetAxisRawTimeInactive()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.asasiuXJlxkXcFOVeQKYEktBLEv();
		}

		public AxisCoordinateMode GetAxisCoordinateMode()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.aSYVmNRIYhecyIAPVoNUAKmGqzS();
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.YwUFRVveorVzccyqCSTNhByjoIZ();
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.TnmqhZHaNDxwUFmndmEcharqzNo();
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.oGslYUNDIYdgjPfthVOmLGjYINl();
		}

		public bool GetButton()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.jFcZHuafkqlzijBvuFElJkopdfY();
		}

		public bool GetButtonPrev()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.zzfmTHlfPMxAtELqZGBGFqlGwNnV();
		}

		public bool GetButtonDown()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.onTOiISwdiwnVPNqdGBZbNYGehbR();
		}

		public bool GetButtonUp()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.QNRTkSkGFuwIIacWXFtSgclWddbW();
		}

		public bool GetButtonSinglePressHold()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.qTwZgHDTVAWJghKpsdDNNalKTRt();
		}

		public bool GetButtonSinglePressDown()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.rWGwOgpOlZtlVSGUSNQagovTRCe();
		}

		public bool GetButtonSinglePressUp()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.ksFbLuWovwSusHlHjefsFuJGTK();
		}

		public bool GetButtonDoublePressDown()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.WECszamZhCGBaugBWVuoFSBDSIn();
		}

		public bool GetButtonDoublePressDown(float speed)
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.WECszamZhCGBaugBWVuoFSBDSIn(speed);
		}

		public bool GetButtonDoublePressHold()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.iTwfkmbsmuNlVtrJSWahfnhaZvd();
		}

		public bool GetButtonDoublePressHold(float speed)
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.iTwfkmbsmuNlVtrJSWahfnhaZvd(speed);
		}

		public bool GetButtonDoublePressUp()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.ZMCGeiorCsJPKHuHAAUEkrZDYOT();
		}

		public bool GetButtonDoublePressUp(float speed)
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.ZMCGeiorCsJPKHuHAAUEkrZDYOT(speed);
		}

		public bool GetButtonTimedPress(float time)
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.wjcGKQZuBmrbfwBXXwRdXiTLDuF(time, 0f);
		}

		public bool GetButtonTimedPress(float time, float expireIn)
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.wjcGKQZuBmrbfwBXXwRdXiTLDuF(time, expireIn);
		}

		public bool GetButtonTimedPressDown(float time)
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.miEXqrPenrbMiQxgAmdPATywugk(time);
		}

		public bool GetButtonTimedPressUp(float time)
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.jmNRPvoFbexhblUyuiMQvmLaNaK(time, 0f);
		}

		public bool GetButtonTimedPressUp(float time, float expireIn)
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.jmNRPvoFbexhblUyuiMQvmLaNaK(time, expireIn);
		}

		public bool GetButtonShortPress()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.rcyyMPULmrKbLHvLwAnFfUFVPPR();
		}

		public bool GetButtonShortPressDown()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.gYeTCyhGKkaVGgZezuemqGJatLX();
		}

		public bool GetButtonShortPressUp()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.SWCZiMymsQdLThvSsmwiALEkBbK();
		}

		public bool GetButtonLongPress()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.npfgXZtKMFFklVbTJfFAvKLyliC();
		}

		public bool GetButtonLongPressDown()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.uFlaryDYfyMDhMCsXKNCoPyChog();
		}

		public bool GetButtonLongPressUp()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.saoXXohfyQyJUwjpBiSVZjfdbXy();
		}

		public bool GetButtonRepeating()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.XOsefyWDHwZOXjmpVlXGYKJafdt();
		}

		public double GetButtonTimePressed()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.GlbGvItEcsropotExwhQogMKCTc();
		}

		public double GetButtonTimeUnpressed()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.ahmYllXzqpwHbQCxSzCLwkosRBZ();
		}

		public bool GetNegativeButton()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.GjQmURQfLsUJtlDpxsliLlcucXv();
		}

		public bool GetNegativeButtonPrev()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.FyoNDogMdbcLjbRknabaNMHMibXI();
		}

		public bool GetNegativeButtonDown()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.GispJZAEfezEtdemUKdarjXvYVi();
		}

		public bool GetNegativeButtonUp()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.ZrNBCoHGXMCmZyMECcLNhxpdYovR();
		}

		public bool GetNegativeButtonSinglePressHold()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.WfZeMfhNAoMJIXMavAKrtJsNDWbF();
		}

		public bool GetNegativeButtonSinglePressDown()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.RNCfZoiaVVeQzBKphLchHPwpEZqI();
		}

		public bool GetNegativeButtonSinglePressUp()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.zXrIaGSPAdFttfFXmjrycWpcxZhm();
		}

		public bool GetNegativeButtonDoublePressDown()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.WvMfdYEiKbIIpujENcBAnywGvUbe();
		}

		public bool GetNegativeButtonDoublePressDown(float speed)
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.WvMfdYEiKbIIpujENcBAnywGvUbe(speed);
		}

		public bool GetNegativeButtonDoublePressHold()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.OEdSYxLPfkelucpBeITTaFuMcTK();
		}

		public bool GetNegativeButtonDoublePressHold(float speed)
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.OEdSYxLPfkelucpBeITTaFuMcTK(speed);
		}

		public bool GetNegativeButtonDoublePressUp()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.ucXHXUUqxlkhvzJNWDPYfuRMgyD();
		}

		public bool GetNegativeButtonDoublePressUp(float speed)
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.ucXHXUUqxlkhvzJNWDPYfuRMgyD(speed);
		}

		public bool GetNegativeButtonTimedPress(float time)
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.hgFujwoGsFfsjeIjlnOMWpEhXwA(time, 0f);
		}

		public bool GetNegativeButtonTimedPress(float time, float expireIn)
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.hgFujwoGsFfsjeIjlnOMWpEhXwA(time, expireIn);
		}

		public bool GetNegativeButtonTimedPressDown(float time)
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.CDyaTaJIXcGhBvDctqVqeSYmNsx(time);
		}

		public bool GetNegativeButtonTimedPressUp(float time)
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.DXkcQgzDXDwqfjqKEWeeiIsjEkL(time, 0f);
		}

		public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.DXkcQgzDXDwqfjqKEWeeiIsjEkL(time, expireIn);
		}

		public bool GetNegativeButtonShortPress()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.PjVCYxGaFYdJXhjLQSraPNYqlkv();
		}

		public bool GetNegativeButtonShortPressDown()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.cGPAZhRoZybdYmPyydBfiaWgoJDG();
		}

		public bool GetNegativeButtonShortPressUp()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.ddscAWCaYKgqaGgjOFzIJWfzTjkO();
		}

		public bool GetNegativeButtonLongPress()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.oMxTTcjOLMYEoYDddFPmgSxilnH();
		}

		public bool GetNegativeButtonLongPressDown()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.rcVJaTxSByOtwqWKUaiYAkfAyxL();
		}

		public bool GetNegativeButtonLongPressUp()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.jGCWDEuaegGYCmImHJEiHDpRWGB();
		}

		public bool GetNegativeButtonRepeating()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.ZxiIuRYtBDEJCMjqsaKVbuOFqEda();
		}

		public double GetNegativeButtonTimePressed()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.dxkXhZgtdvRCHZnoEEZfzgZJXB();
		}

		public double GetNegativeButtonTimeUnpressed()
		{
			return MxUwsGjVGwkMxJtfBTiOldMDXIE.bwACWmRNWMEBWqsttspcoPFcGyG();
		}

		public IList<InputActionSourceData> GetCurrentInputSources()
		{
			return ReInput.akUdmKMbrqFLXkjqdKLUZOPTArx.hclDKzezyJcwtJoSXLrWuaySJmJS(playerId, actionId, true)?.IuoAwCWdCAjYeLqfbcSvMLYTuGV();
		}

		public bool IsCurrentInputSource(ControllerType controllerType)
		{
			return ReInput.akUdmKMbrqFLXkjqdKLUZOPTArx.hclDKzezyJcwtJoSXLrWuaySJmJS(playerId, actionId, true)?.adBGAlpCrTxrtgKicbPRkjxIekDn(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
		{
			return ReInput.akUdmKMbrqFLXkjqdKLUZOPTArx.hclDKzezyJcwtJoSXLrWuaySJmJS(playerId, actionId, true)?.adBGAlpCrTxrtgKicbPRkjxIekDn(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(Controller controller)
		{
			return ReInput.akUdmKMbrqFLXkjqdKLUZOPTArx.hclDKzezyJcwtJoSXLrWuaySJmJS(playerId, actionId, true)?.adBGAlpCrTxrtgKicbPRkjxIekDn(controller) ?? false;
		}

		internal InputActionEventData(juUkCOtINcePpkOEZitZVEIfgiwq vc, int playerId, int actionId, UpdateLoopType updateLoop)
		{
			SkpfswjAbyRqgVYqdsfskygZZqV = InputActionEventType.Update;
			MxUwsGjVGwkMxJtfBTiOldMDXIE = vc;
			this.playerId = playerId;
			this.actionId = actionId;
			this.updateLoop = updateLoop;
		}
	}
}
