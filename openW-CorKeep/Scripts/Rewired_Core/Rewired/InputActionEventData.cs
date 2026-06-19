using System.Collections.Generic;

namespace Rewired
{
	public struct InputActionEventData
	{
		private fDpcCKCuzPiJSPYRYUOXoNEJrNYcb GmEAkGGHHcguVWnnhxXjLunxBWdNA;

		private InputActionEventType mTuuKpgWazOKRbcUbEDBfYnXSqkv;

		public readonly int playerId;

		public readonly int actionId;

		public readonly UpdateLoopType updateLoop;

		public InputActionEventType eventType
		{
			get
			{
				return mTuuKpgWazOKRbcUbEDBfYnXSqkv;
			}
			internal set
			{
				mTuuKpgWazOKRbcUbEDBfYnXSqkv = inputActionEventType;
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
				return ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.iDEVoXmwrNGrhwAHjePABafBxcAw(actionId).name;
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
				return ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.iDEVoXmwrNGrhwAHjePABafBxcAw(actionId).descriptiveName;
			}
		}

		public float GetAxis()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.KnkutKftHwuYOokXdGbLzZTyJRsc();
		}

		public float GetAxisPrev()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.cXVwqwFLrwcAUZbciwKrYuIRvMfI();
		}

		public float GetAxisDelta()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.GYzBXZCNULNUAxGMBiEfwxfJKQoU();
		}

		public double GetAxisTimeActive()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.XHMpxLAZsbwtHshVboUFPPUNrJPJ();
		}

		public double GetAxisTimeInactive()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.DQQBWHuzXYkcrrQbJgJFMfvakGDD();
		}

		public float GetAxisRaw()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.NfEoghEuLnJfqxUnwoWveanivKEy();
		}

		public float GetAxisRawDelta()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.TdghQobrotBDkopEoLVTYJgouCgoA();
		}

		public float GetAxisRawPrev()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.EGadHTOIaTgtghmXgjBjDCxfZOmzb();
		}

		public double GetAxisRawTimeActive()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.SjxZOtsoDSNVsaaHoFqCGqdRPSnYA();
		}

		public double GetAxisRawTimeInactive()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.tmZtXpTHwtcXbfYmOAiQWPwZJREI();
		}

		public AxisCoordinateMode GetAxisCoordinateMode()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.NOiGoaMiwHEZMfDSFCyCahPePLJWA();
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.PqGEWjRRfsifPVfVxPOxhtJzyYQj();
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.hCsYWozMXqlhFFjxTgkSfMRSGcmjb();
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.bllYlGUGQarspNvNsPkQMpRROjKU();
		}

		public bool GetButton()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.QjFgvPKGEeCadAwWpAOVbYVEwiocc();
		}

		public bool GetButtonPrev()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.xBfyujgxwYPkKCzxfLPLJMmuQzPG();
		}

		public bool GetButtonDown()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.tkgMQvUaqSzRkgPvBglpNsGXRHuK();
		}

		public bool GetButtonUp()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.pQiccvFOkHaSfeEAGxAyBgsphfSic();
		}

		public bool GetButtonSinglePressHold()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.CppttvrfXZuypUSpWtnBEPhObOGp();
		}

		public bool GetButtonSinglePressDown()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.QwZBioUoWnclJYPKXrhzcsKZeMN();
		}

		public bool GetButtonSinglePressUp()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.YIetwDuXfleVZXjOOGVpyoIZRdlg();
		}

		public bool GetButtonDoublePressDown()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.IuhXYUSRyKGCArYfkabqjQmWHZpB();
		}

		public bool GetButtonDoublePressDown(float speed)
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.wUCqyJpqbVGgXlUCgZmqnapuZFiL(speed);
		}

		public bool GetButtonDoublePressHold()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.xXMsQHeBKLhWuKrHKguIICttkXKG();
		}

		public bool GetButtonDoublePressHold(float speed)
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.hDuEdSZIVodLmMgAcBClwJzyStxt(speed);
		}

		public bool GetButtonDoublePressUp()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.IDBgQIkHMhRFsAsxiXHXUYDhJUSh();
		}

		public bool GetButtonDoublePressUp(float speed)
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.MAsIOVeSXLcrzYnfXRltcrTDvsUAA(speed);
		}

		public bool GetButtonTimedPress(float time)
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.sOsQEzsgKiHXPzOVEBhITTUQrJSc(time, 0f);
		}

		public bool GetButtonTimedPress(float time, float expireIn)
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.sOsQEzsgKiHXPzOVEBhITTUQrJSc(time, expireIn);
		}

		public bool GetButtonTimedPressDown(float time)
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.bIinHhvpUOIPAPGUJVspophPjzvH(time);
		}

		public bool GetButtonTimedPressUp(float time)
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.WIhbzSNjjwDnIIspHqtaHIgnUxqv(time, 0f);
		}

		public bool GetButtonTimedPressUp(float time, float expireIn)
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.WIhbzSNjjwDnIIspHqtaHIgnUxqv(time, expireIn);
		}

		public bool GetButtonShortPress()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.IjFBYreATrxTjLNbqySkhPrzZrjNA();
		}

		public bool GetButtonShortPressDown()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.WPpvGUJVQDjdSfNgllfkKsCeAiPM();
		}

		public bool GetButtonShortPressUp()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.sRHHMiCACydmibRnOXTCQfEROLPI();
		}

		public bool GetButtonLongPress()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.BTkggOefvqEUVCIxbmeoCMWRrttS();
		}

		public bool GetButtonLongPressDown()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.fVQgMTKMYhFErizSsNYktdPwEgAj();
		}

		public bool GetButtonLongPressUp()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.utjUHiKzTnssUhdvAnYCntvklNiU();
		}

		public bool GetButtonRepeating()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.gEgAMcaSKCMofNvLoSPhPyGOeqnO();
		}

		public double GetButtonTimePressed()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.xRtzVootfuEQSObnZUkktWGzudHd();
		}

		public double GetButtonTimeUnpressed()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.QFXCXYsEPPYOPXyjoFaESXVgAInI();
		}

		public bool GetNegativeButton()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.MZVcABaPnzwSAYScLIsjwTNwITCA();
		}

		public bool GetNegativeButtonPrev()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.ahgIigrJpIhpTnxlRkyDggCAkbSe();
		}

		public bool GetNegativeButtonDown()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.IlnDwsriqNmIJnrVMGHpsxuVmCDk();
		}

		public bool GetNegativeButtonUp()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.PkjAuEhiLFblGFpEoLUSgkwdAWMPc();
		}

		public bool GetNegativeButtonSinglePressHold()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.hMmBMCeSZmjRTcvFyylliQozOMsN();
		}

		public bool GetNegativeButtonSinglePressDown()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.PVixsVWcKhmAyzCuiqalzruTETQV();
		}

		public bool GetNegativeButtonSinglePressUp()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.XGGeYmbOfRhTwqlTUNjJhyHmjBDTA();
		}

		public bool GetNegativeButtonDoublePressDown()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.YOleStcIPOuiirfFFMDCYBYZcSve();
		}

		public bool GetNegativeButtonDoublePressDown(float speed)
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.OeHFCiBFoMONSFkDxrjrhjfrdKyBb(speed);
		}

		public bool GetNegativeButtonDoublePressHold()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.pqGlyrAICPMcQiGbQmHMHXBOqRlW();
		}

		public bool GetNegativeButtonDoublePressHold(float speed)
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.APRUMcTqPXHnSsLFqUoHcEftujgM(speed);
		}

		public bool GetNegativeButtonDoublePressUp()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.feDiVbIPALMttgtsxTidNqPRlVqF();
		}

		public bool GetNegativeButtonDoublePressUp(float speed)
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.kAUIGHIRmqgIhITYRXdfyDeKJHvGA(speed);
		}

		public bool GetNegativeButtonTimedPress(float time)
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.SGhUbfNCpyJYvQMUSVDVPEdBaLJM(time, 0f);
		}

		public bool GetNegativeButtonTimedPress(float time, float expireIn)
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.SGhUbfNCpyJYvQMUSVDVPEdBaLJM(time, expireIn);
		}

		public bool GetNegativeButtonTimedPressDown(float time)
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.lzWSNJyuyDIVWfatOfBuxuMlyjQV(time);
		}

		public bool GetNegativeButtonTimedPressUp(float time)
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.OjFDupAWRtqEHLCDApfpexwBEnJBb(time, 0f);
		}

		public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.OjFDupAWRtqEHLCDApfpexwBEnJBb(time, expireIn);
		}

		public bool GetNegativeButtonShortPress()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.dXjwGMaeXYEoLItTeUrdPplGifLc();
		}

		public bool GetNegativeButtonShortPressDown()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.xGIVsgNZGAhBEPFOvKvKctfPctqN();
		}

		public bool GetNegativeButtonShortPressUp()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.CirBXpYSwLpjktkuuieVfTCjxvsq();
		}

		public bool GetNegativeButtonLongPress()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.HkPSkWatznDEtFObKrhQofsAFDBy();
		}

		public bool GetNegativeButtonLongPressDown()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.bnLTdeGiNoyyYqFMzrKaIlOcyqfD();
		}

		public bool GetNegativeButtonLongPressUp()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.OAoJiIXLmaeobgaxEVYinJhHPJCFb();
		}

		public bool GetNegativeButtonRepeating()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.bVHaNgmFElRWmAMIPleLrwEkLgyI();
		}

		public double GetNegativeButtonTimePressed()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.xPiIAnbVqZPNUAWXLPBXtuczQHKS();
		}

		public double GetNegativeButtonTimeUnpressed()
		{
			return GmEAkGGHHcguVWnnhxXjLunxBWdNA.TNbcLDUZTVlllUKOxakoDCFmaDtBA();
		}

		public IList<InputActionSourceData> GetCurrentInputSources()
		{
			return ReInput.YNZnkUUWdETsfnFwfyPUjVPxExCq.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(playerId, actionId, true)?.oYKlLZhmEjOVJzniVUEhpSMHDcNL();
		}

		public bool IsCurrentInputSource(ControllerType controllerType)
		{
			return ReInput.YNZnkUUWdETsfnFwfyPUjVPxExCq.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(playerId, actionId, true)?.dGGDTxhsJsMSyBnPTtwkytBGfevn(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
		{
			return ReInput.YNZnkUUWdETsfnFwfyPUjVPxExCq.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(playerId, actionId, true)?.xjEfscgzlHvJWUMkQLOSoLtzLsOLA(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(Controller controller)
		{
			return ReInput.YNZnkUUWdETsfnFwfyPUjVPxExCq.SgLBiPuumpLfMmbFqGSJJoAhcmcNA(playerId, actionId, true)?.aFfeTPrJYcRssskAdiPKITNiDGkn(controller) ?? false;
		}

		internal InputActionEventData(fDpcCKCuzPiJSPYRYUOXoNEJrNYcb P_0, int P_1, int P_2, UpdateLoopType P_3)
		{
			mTuuKpgWazOKRbcUbEDBfYnXSqkv = InputActionEventType.Update;
			GmEAkGGHHcguVWnnhxXjLunxBWdNA = P_0;
			playerId = P_1;
			actionId = P_2;
			updateLoop = P_3;
		}
	}
}
