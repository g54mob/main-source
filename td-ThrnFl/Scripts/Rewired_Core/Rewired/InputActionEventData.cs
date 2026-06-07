using System.Collections.Generic;

namespace Rewired
{
	public struct InputActionEventData
	{
		private KvDFldULABgCdeUydTfHpQtIJWLLA hhmhHzxmkaxvehIUSyVpjcOmATgU;

		private InputActionEventType PaSBCMWSZbRkkrdtAagLgeGMFzdr;

		public readonly int playerId;

		public readonly int actionId;

		public readonly UpdateLoopType updateLoop;

		public InputActionEventType eventType
		{
			get
			{
				return PaSBCMWSZbRkkrdtAagLgeGMFzdr;
			}
			internal set
			{
				PaSBCMWSZbRkkrdtAagLgeGMFzdr = paSBCMWSZbRkkrdtAagLgeGMFzdr;
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
				return ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.PpmmVsSKOBgRYGwcKkaQOYCIXbJmA(actionId).name;
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
				return ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.PpmmVsSKOBgRYGwcKkaQOYCIXbJmA(actionId).descriptiveName;
			}
		}

		public float GetAxis()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.vDILMvZTSozNrqNZOlPRyQknMOMj();
		}

		public float GetAxisPrev()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.JrvFLXhmewpPhJaTZAZzRipCiguO();
		}

		public float GetAxisDelta()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.jpLkkNkxMBEvyhxWgflApKtEPryb();
		}

		public double GetAxisTimeActive()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.kkCMeeKTjhrwiKoUDXBaWhCJwOJA();
		}

		public double GetAxisTimeInactive()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.uxegwgUfCSjdHhmrsPkVHgChpSSJ();
		}

		public float GetAxisRaw()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.cSmTNGoDybvqVlYYDlRblGGxcFDQ();
		}

		public float GetAxisRawDelta()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.orEirFTIDxeIXGlfJPoRyMZnkLdjA();
		}

		public float GetAxisRawPrev()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.vHGqiugXaRiLTkkhTgchZCUUTHhC();
		}

		public double GetAxisRawTimeActive()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.loVHpKAOaIHANgBeDxZSpdAMcXqFA();
		}

		public double GetAxisRawTimeInactive()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.dHKEBxDinhUJtHFtxOqVNNKUXyb();
		}

		public AxisCoordinateMode GetAxisCoordinateMode()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.scEfVaoZVNYzgbzgkXgKasWzUeKe();
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.gxodwCtJoyfkiVuuCcwbwlegnKLG();
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.WRYQxHHnakkgcPLKsDTKZLoXwljq();
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.SNBQIheQzuBxKRrsDgTMELsAqgJlA();
		}

		public bool GetButton()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.jonBMeBgjqmpKxavKozLAPygznlzb();
		}

		public bool GetButtonPrev()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.ErHrVSCsDYUYvOhOGtaLWvLzkRUv();
		}

		public bool GetButtonDown()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.AHAfXYajBSoiRkPUeJcdIbrWdSzT();
		}

		public bool GetButtonUp()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.QhIFFGmODJeZADKlMzrwrvViMkFFA();
		}

		public bool GetButtonSinglePressHold()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.leJpQSBpsXypUKkUlFCVJOOJkVZW();
		}

		public bool GetButtonSinglePressDown()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.vrSuqTsbLGDvCIrahfArgEVLgbLiA();
		}

		public bool GetButtonSinglePressUp()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.jJOOiwSjatfNcHHSlzJnnXBSKHmJ();
		}

		public bool GetButtonDoublePressDown()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.tvImnpuywgLJxlOvXThhyVvVEkMg();
		}

		public bool GetButtonDoublePressDown(float speed)
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.TWgLCmJHQFLpcxWpHeDkkWKfOdtj(speed);
		}

		public bool GetButtonDoublePressHold()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.WOwXIyGppVwABMTkrJzSXfGglMPL();
		}

		public bool GetButtonDoublePressHold(float speed)
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.QoYnapdumcutNIkvTnBhtWWxoDqI(speed);
		}

		public bool GetButtonDoublePressUp()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.vPrBnrkMrjYSHKYITZyPdXwkaOFYA();
		}

		public bool GetButtonDoublePressUp(float speed)
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.bYYGrmiMaVaqWzWEkxGjsYiEgnNS(speed);
		}

		public bool GetButtonTimedPress(float time)
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.NzQrTYSnDcGRqbNdniVOSQqJoqAG(time, 0f);
		}

		public bool GetButtonTimedPress(float time, float expireIn)
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.NzQrTYSnDcGRqbNdniVOSQqJoqAG(time, expireIn);
		}

		public bool GetButtonTimedPressDown(float time)
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.KfKWyEBfMWRJtXfkuyNnrMnWwSgd(time);
		}

		public bool GetButtonTimedPressUp(float time)
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.vkBYJdlMzighvOYTkGrsYDUmsodE(time, 0f);
		}

		public bool GetButtonTimedPressUp(float time, float expireIn)
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.vkBYJdlMzighvOYTkGrsYDUmsodE(time, expireIn);
		}

		public bool GetButtonShortPress()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.bongdQqmupfQSHXCTmfmQNCkYumU();
		}

		public bool GetButtonShortPressDown()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.tHJnnjrHfPYknbNDKOKeNLhbhpQu();
		}

		public bool GetButtonShortPressUp()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.RvdqpLgLtagjFduEnuOEFivMTDAm();
		}

		public bool GetButtonLongPress()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.qAzFnnISixTyoWOKoTqCFzESwanA();
		}

		public bool GetButtonLongPressDown()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.OsyHPaidTpYBYijoDgHmuEybJsBh();
		}

		public bool GetButtonLongPressUp()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.TYRlaLcnebEhljBSxanWDgYblAxxA();
		}

		public bool GetButtonRepeating()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.VKhtDAKdScfYZJwREarPYfPRnkrA();
		}

		public double GetButtonTimePressed()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.SZRUDVYaAebPzKtUqmvcmrhqprOp();
		}

		public double GetButtonTimeUnpressed()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.lmrvcvGDgXHliFQXRgyQBsUnLruE();
		}

		public bool GetNegativeButton()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.pXjVqdAzojvTbKvxXpykfDkEPpQj();
		}

		public bool GetNegativeButtonPrev()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.TLGzmXXWqWqdMxqYeLawjKRLjOHj();
		}

		public bool GetNegativeButtonDown()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.lHHuINDJBTdpehTarhalhiDIerGx();
		}

		public bool GetNegativeButtonUp()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.cZnPzBTkHgebnurRTrMvxFZoHRQ();
		}

		public bool GetNegativeButtonSinglePressHold()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.OHEgpxkImiJCqolaVZUxvFDoULlV();
		}

		public bool GetNegativeButtonSinglePressDown()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.icISRcgmlpGTPhvBVPBbXqHOwYNCA();
		}

		public bool GetNegativeButtonSinglePressUp()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.irkDtFaWCXlYTvtuvGUVfEsfFYIm();
		}

		public bool GetNegativeButtonDoublePressDown()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.fYZBTbGfbYLpPxbUaZzCTeiQnxgL();
		}

		public bool GetNegativeButtonDoublePressDown(float speed)
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.xplklLjFBUdExfyeGIYreySaXLpwA(speed);
		}

		public bool GetNegativeButtonDoublePressHold()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.YGkWZSiInTjlrsjIxnmWOZqHTSyp();
		}

		public bool GetNegativeButtonDoublePressHold(float speed)
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.zEbnlZdaiDyetgJiLTFBfyCksxhK(speed);
		}

		public bool GetNegativeButtonDoublePressUp()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.UjlXvEeEfPTBOaVXQsBvSCiAkqlp();
		}

		public bool GetNegativeButtonDoublePressUp(float speed)
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.ZywGlizWJkjZOJCxihYfIdZPfKmM(speed);
		}

		public bool GetNegativeButtonTimedPress(float time)
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.jkHbbEpqSaAWWOfPzcBDKMxSWYOd(time, 0f);
		}

		public bool GetNegativeButtonTimedPress(float time, float expireIn)
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.jkHbbEpqSaAWWOfPzcBDKMxSWYOd(time, expireIn);
		}

		public bool GetNegativeButtonTimedPressDown(float time)
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.IUwmguQiJVJAbdBMtRmgmQtufkZN(time);
		}

		public bool GetNegativeButtonTimedPressUp(float time)
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.jJneXQoPwtMJsElqheSfDuRYcmEWA(time, 0f);
		}

		public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.jJneXQoPwtMJsElqheSfDuRYcmEWA(time, expireIn);
		}

		public bool GetNegativeButtonShortPress()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.WPHBHjUnRAgFXAwQRWvlCCQRCpohA();
		}

		public bool GetNegativeButtonShortPressDown()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.QcKgRpnjObkdVpdAhACjXQCKkbT();
		}

		public bool GetNegativeButtonShortPressUp()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.zLRaEWaNUNqANdVnZVCXenCmgBzG();
		}

		public bool GetNegativeButtonLongPress()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.ccfbVnEYphSAKDcOvANEplTREnGG();
		}

		public bool GetNegativeButtonLongPressDown()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.KBxcgZydRgMdteooSrGuDoCtzlkw();
		}

		public bool GetNegativeButtonLongPressUp()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.jtWfJjCxRaLtWlmSjupulMQKlEFlA();
		}

		public bool GetNegativeButtonRepeating()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.SwdFNDSojvQADMMjyGKRyavbMKvL();
		}

		public double GetNegativeButtonTimePressed()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.GECGbGVSZFbGpcWiwvgJuuHcRUDUA();
		}

		public double GetNegativeButtonTimeUnpressed()
		{
			return hhmhHzxmkaxvehIUSyVpjcOmATgU.yfNogkwubBsGKCahGLJuSIojWNik();
		}

		public IList<InputActionSourceData> GetCurrentInputSources()
		{
			return ReInput.zEtuNvknIQbzOpsTCdeQeEswlwDw.rHxPDwYVNrsGvqoRZhPDldvonnvd(playerId, actionId, true)?.FoeAtyFrrbPFunbJapNzsBbSQNIG();
		}

		public bool IsCurrentInputSource(ControllerType controllerType)
		{
			return ReInput.zEtuNvknIQbzOpsTCdeQeEswlwDw.rHxPDwYVNrsGvqoRZhPDldvonnvd(playerId, actionId, true)?.YskeyUbRiqSRHpHgeoLcXzmNdzsPA(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
		{
			return ReInput.zEtuNvknIQbzOpsTCdeQeEswlwDw.rHxPDwYVNrsGvqoRZhPDldvonnvd(playerId, actionId, true)?.UKmKVTHWYFiMjClZtAjEUfQkSxHR(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(Controller controller)
		{
			return ReInput.zEtuNvknIQbzOpsTCdeQeEswlwDw.rHxPDwYVNrsGvqoRZhPDldvonnvd(playerId, actionId, true)?.ZOTeygDrbgabFIkjQguMlJmpJJnSA(controller) ?? false;
		}

		internal InputActionEventData(KvDFldULABgCdeUydTfHpQtIJWLLA P_0, int P_1, int P_2, UpdateLoopType P_3)
		{
			PaSBCMWSZbRkkrdtAagLgeGMFzdr = InputActionEventType.Update;
			hhmhHzxmkaxvehIUSyVpjcOmATgU = P_0;
			playerId = P_1;
			actionId = P_2;
			updateLoop = P_3;
		}
	}
}
