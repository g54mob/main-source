using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Config;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.InputSources.SDL2
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class SDL2InputSource : IInputSource, IDisposable
	{
		public delegate void acZTHYaYyhxtmGxPeWZzOkiyugii(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void BNuOijgtnvIsHycfQCgxafRUMiPIA(int joystickIndex);

		public delegate void VCfJAQuUzzcvJlhJSmUXnpYKbLmI(int joystickId);

		public delegate void xRIWNIcXZWTkoCLYHHEYdbofwrcv(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int DVamzoXSFVPGJIHkOdtxkAGShKeib = 32;

		private bool aBFCoOYnUjCVpLhbBzoBwESGdWQT;

		private bool rfrevdAQlmgMUqEyzisvdOncCcPLc;

		private bool bqtdSIcuyjpodnvPuyWubcfFkmJbb;

		private bool wYlsdqOmUxJDEPLqNjfChEOjIJTM;

		private bool fOASMLIjcdgofrOZaDlQJGLzbiRaA;

		private ADictionary<int, srlBRtRclsWYTCTseoEJvfJUEIIJA> iEEcsWdvoamBTqYvvLvJEUKAmBvV;

		private ADictionary<int, tETJppGPewZKkvPMfzeTdMCcoLA> ULBRKIeZuBcdOGKmEYEOAPAuAtLx;

		private HbXxmfJswkPCGAKIoZSlrDDopjDd.EGpRYNvpoBTDoGNyMrtKecGudyvM DHknLWKnkPlPSMLfBqQRfiXKTZWR;

		private NativeBuffer yuVZIutvXckLFQtomFpxLeASlamu;

		[CompilerGenerated]
		private Action wueFdYdGBMyITdNlxDYvQbdzbSbl;

		private bool WjsezAYiGdAORbqryhxuehoKNJeq;

		public bool initialized => fOASMLIjcdgofrOZaDlQJGLzbiRaA;

		private event Action _DeviceChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = wueFdYdGBMyITdNlxDYvQbdzbSbl;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref wueFdYdGBMyITdNlxDYvQbdzbSbl, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = wueFdYdGBMyITdNlxDYvQbdzbSbl;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref wueFdYdGBMyITdNlxDYvQbdzbSbl, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		event Action IInputSource.DeviceChangedEvent
		{
			add
			{
				_DeviceChangedEvent += value;
			}
			remove
			{
				_DeviceChangedEvent -= value;
			}
		}

		public SDL2InputSource(UpdateLoopSetting P_0, bool P_1, bool P_2, bool P_3, bool P_4)
		{
			aBFCoOYnUjCVpLhbBzoBwESGdWQT = P_1;
			rfrevdAQlmgMUqEyzisvdOncCcPLc = P_2;
			bqtdSIcuyjpodnvPuyWubcfFkmJbb = P_3;
			wYlsdqOmUxJDEPLqNjfChEOjIJTM = P_4;
			iEEcsWdvoamBTqYvvLvJEUKAmBvV = new ADictionary<int, srlBRtRclsWYTCTseoEJvfJUEIIJA>();
			ULBRKIeZuBcdOGKmEYEOAPAuAtLx = new ADictionary<int, tETJppGPewZKkvPMfzeTdMCcoLA>();
			int num = ((!UnityTools.isEditor || UnityTools.editorPlatform != EditorPlatform.OSX) ? 29184 : 25088);
			try
			{
				HbXxmfJswkPCGAKIoZSlrDDopjDd.DHdghIBiTOdoujtWtOgXoKqqVAZj(UnityTools.effectivePlatform);
				if (HbXxmfJswkPCGAKIoZSlrDDopjDd.yMUmrewBnAjYHIEENUfSVAOzhFYR((uint)num) < 0)
				{
					throw new Exception("Failed initialize SDL2!");
				}
				fOASMLIjcdgofrOZaDlQJGLzbiRaA = true;
				if (P_2)
				{
					xpWqPbPrATYaEzIuIffmqGJgrBBw();
				}
				hLfsExwbjjqYLxUGNQhqLymeUeTj();
				yuVZIutvXckLFQtomFpxLeASlamu = new NativeBuffer(56);
			}
			catch
			{
				fOASMLIjcdgofrOZaDlQJGLzbiRaA = false;
				Dispose();
				throw;
			}
		}

		public void SystemDeviceConnected()
		{
			throw new NotImplementedException();
		}

		void IInputSource.SystemDeviceConnected()
		{
			//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceConnected
			this.SystemDeviceConnected();
		}

		public void SystemDeviceDisconnected()
		{
			throw new NotImplementedException();
		}

		void IInputSource.SystemDeviceDisconnected()
		{
			//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceDisconnected
			this.SystemDeviceDisconnected();
		}

		public void Update()
		{
			_ = fOASMLIjcdgofrOZaDlQJGLzbiRaA;
		}

		void IInputSource.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
			if (fOASMLIjcdgofrOZaDlQJGLzbiRaA)
			{
				QrdBIPjsmWLKqTHWHKbEPaIXRWtR();
			}
		}

		void IInputSource.UpdateDevices(UpdateLoopType updateLoop)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateDevices
			this.UpdateDevices(updateLoop);
		}

		public void UpdateFinished()
		{
			_ = fOASMLIjcdgofrOZaDlQJGLzbiRaA;
		}

		void IInputSource.UpdateFinished()
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateFinished
			this.UpdateFinished();
		}

		public IList<T> GetJoysticks<T>() where T : class
		{
			if (!fOASMLIjcdgofrOZaDlQJGLzbiRaA)
			{
				return null;
			}
			List<bZTYrShHWPAVFFKErndDmtappVZBb> list = new List<bZTYrShHWPAVFFKErndDmtappVZBb>();
			if (aBFCoOYnUjCVpLhbBzoBwESGdWQT)
			{
				foreach (KeyValuePair<int, srlBRtRclsWYTCTseoEJvfJUEIIJA> item in iEEcsWdvoamBTqYvvLvJEUKAmBvV)
				{
					if (item.Value.DvdJYCQRAcBNHSfnNvdmBVWrHJVT)
					{
						list.Add(item.Value);
					}
				}
			}
			if (rfrevdAQlmgMUqEyzisvdOncCcPLc)
			{
				foreach (KeyValuePair<int, tETJppGPewZKkvPMfzeTdMCcoLA> item2 in ULBRKIeZuBcdOGKmEYEOAPAuAtLx)
				{
					tETJppGPewZKkvPMfzeTdMCcoLA value = item2.Value;
					if (value.DvdJYCQRAcBNHSfnNvdmBVWrHJVT)
					{
						list.Add(value);
					}
				}
			}
			return list as IList<T>;
		}

		IList<T> IInputSource.GetJoysticks<T>()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetJoysticks
			return this.GetJoysticks<T>();
		}

		private int NRkCysiwppkdcqMWnBQNSCGsMvCF()
		{
			if (!fOASMLIjcdgofrOZaDlQJGLzbiRaA)
			{
				return 0;
			}
			return Math.Min(HbXxmfJswkPCGAKIoZSlrDDopjDd.TnuCzkgkBYIAVjqSkBRmCzukMEvTB(), 32);
		}

		private int rVmwgGJFcIAHKYVRmkfKgxrIaXsm()
		{
			if (!fOASMLIjcdgofrOZaDlQJGLzbiRaA)
			{
				return 0;
			}
			int num = NRkCysiwppkdcqMWnBQNSCGsMvCF();
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				if (!HbXxmfJswkPCGAKIoZSlrDDopjDd.wdbobVVqGNZuweQHghUMfQylEikCb(i))
				{
					num2++;
				}
			}
			return num2;
		}

		private srlBRtRclsWYTCTseoEJvfJUEIIJA DfNeyvCCjslkTybDGLVLhWXTVtWHA(int P_0)
		{
			IntPtr intPtr = HbXxmfJswkPCGAKIoZSlrDDopjDd.HOAUdquJnoUzolkVgvLvRLyarHbJ(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			vmufigtVdJbTCNnGOSszzPPMTDbm vmufigtVdJbTCNnGOSszzPPMTDbm2 = new vmufigtVdJbTCNnGOSszzPPMTDbm(intPtr);
			LbOGBSopwOVdYGqFwBwchyJXbQKgA lbOGBSopwOVdYGqFwBwchyJXbQKgA = YnlPlhmAIunkBjpoPRRaDstMvxiA(P_0, vmufigtVdJbTCNnGOSszzPPMTDbm2);
			if (lbOGBSopwOVdYGqFwBwchyJXbQKgA == null)
			{
				HbXxmfJswkPCGAKIoZSlrDDopjDd.cJSmdTuRmGeoXAhdGqmtZkaoNAtC(intPtr);
				return null;
			}
			return new srlBRtRclsWYTCTseoEJvfJUEIIJA(vmufigtVdJbTCNnGOSszzPPMTDbm2, lbOGBSopwOVdYGqFwBwchyJXbQKgA);
		}

		private tETJppGPewZKkvPMfzeTdMCcoLA lVSVQgZRpNWoOJhfyiwAPxImJPBr(int P_0)
		{
			IntPtr intPtr = HbXxmfJswkPCGAKIoZSlrDDopjDd.iKiUuDzptzBJOTNOnJnlkXOzVeLF(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			wdZMiVlwBVDdgqTMrhpVydFwJWwO wdZMiVlwBVDdgqTMrhpVydFwJWwO2 = new wdZMiVlwBVDdgqTMrhpVydFwJWwO(intPtr);
			LbOGBSopwOVdYGqFwBwchyJXbQKgA lbOGBSopwOVdYGqFwBwchyJXbQKgA = lUCpTNTVnRFRXOtOGrIentILvpGo(P_0, wdZMiVlwBVDdgqTMrhpVydFwJWwO2);
			if (lbOGBSopwOVdYGqFwBwchyJXbQKgA == null)
			{
				return null;
			}
			if (!lbOGBSopwOVdYGqFwBwchyJXbQKgA.pMXIljnpbbiPhRYJKfSVBnlWFgf)
			{
				HbXxmfJswkPCGAKIoZSlrDDopjDd.kLBigQnOhpuyEqKEKbEyfhrQjoLm(intPtr);
				return null;
			}
			lbOGBSopwOVdYGqFwBwchyJXbQKgA.fURRUtmnNDkQHODfbChqkfFXAOjx = HbXxmfJswkPCGAKIoZSlrDDopjDd.eriWFxNHLcBgkdsMyRQhytnZXWeo(wdZMiVlwBVDdgqTMrhpVydFwJWwO2);
			return new tETJppGPewZKkvPMfzeTdMCcoLA(wdZMiVlwBVDdgqTMrhpVydFwJWwO2, lbOGBSopwOVdYGqFwBwchyJXbQKgA);
		}

		private LbOGBSopwOVdYGqFwBwchyJXbQKgA YnlPlhmAIunkBjpoPRRaDstMvxiA(int P_0, vmufigtVdJbTCNnGOSszzPPMTDbm P_1)
		{
			if (!fOASMLIjcdgofrOZaDlQJGLzbiRaA)
			{
				return null;
			}
			if (P_0 < 0 || P_0 >= 32)
			{
				return null;
			}
			if (P_1 == null || !P_1.IsValid)
			{
				return null;
			}
			return new LbOGBSopwOVdYGqFwBwchyJXbQKgA
			{
				ekbFlvpspIHyyePKOFzJAbzgUbNCb = P_0,
				jacfoxwaKEdjjcixECdHuHHTBFwh = HbXxmfJswkPCGAKIoZSlrDDopjDd.gSXMepecfqLdyLuEhSysVZzEHvkh(P_1),
				pMXIljnpbbiPhRYJKfSVBnlWFgf = HbXxmfJswkPCGAKIoZSlrDDopjDd.wdbobVVqGNZuweQHghUMfQylEikCb(P_0),
				FxoxFRTWlVnFpHtwkVrAzgdJvfaH = HbXxmfJswkPCGAKIoZSlrDDopjDd.TzuFcyQdEREzHnpIakLfZRinBklF(P_1),
				XFniIoScnnnWXfrFsWCXyDDnPVJc = HbXxmfJswkPCGAKIoZSlrDDopjDd.CjmGjXdsRJoKCQNctSfoihIABDlmA(P_1),
				AxljyxAGeSlZJTrZWEyDGeJAFwXS = HbXxmfJswkPCGAKIoZSlrDDopjDd.ztlFTPPlXIedUbSoJfqLjYDxfcmF(P_0),
				XMXtOZCmKaGJOiTiaduEIMOUnIzAA = HbXxmfJswkPCGAKIoZSlrDDopjDd.cpfdpJqfkXHJvcJJkGLMlSlgiWasA(P_1),
				tXnEOVWAmENiSGwvEpZeiHTYZgTd = HbXxmfJswkPCGAKIoZSlrDDopjDd.GGDkQigQPpfyajYymaFRaSkMLxzS(P_1),
				NIcGGHCFYtqmZwdvXtwgQHWbvukD = HbXxmfJswkPCGAKIoZSlrDDopjDd.WZWacFjvWpdFiZIgHOFLyHmrwcBmA(P_1),
				hCiaKThjLLJDFxywbfnkKUCPZhdNA = HbXxmfJswkPCGAKIoZSlrDDopjDd.UaHqMKxvWsWujliGlbYlrzbAsBNK(P_1)
			};
		}

		private LbOGBSopwOVdYGqFwBwchyJXbQKgA lUCpTNTVnRFRXOtOGrIentILvpGo(int P_0, wdZMiVlwBVDdgqTMrhpVydFwJWwO P_1)
		{
			if (P_1 == null || !P_1.IsValid)
			{
				return null;
			}
			vmufigtVdJbTCNnGOSszzPPMTDbm vmufigtVdJbTCNnGOSszzPPMTDbm2 = new vmufigtVdJbTCNnGOSszzPPMTDbm(HbXxmfJswkPCGAKIoZSlrDDopjDd.AcVEQQkveRHmNGEBipFKeZlfDIXGA(P_1));
			if (!vmufigtVdJbTCNnGOSszzPPMTDbm2.IsValid)
			{
				return null;
			}
			return YnlPlhmAIunkBjpoPRRaDstMvxiA(P_0, vmufigtVdJbTCNnGOSszzPPMTDbm2);
		}

		private void hLfsExwbjjqYLxUGNQhqLymeUeTj()
		{
			for (int i = 0; i < NRkCysiwppkdcqMWnBQNSCGsMvCF(); i++)
			{
				if (aBFCoOYnUjCVpLhbBzoBwESGdWQT)
				{
					ZQNGlFPbmHbHsezVwhKzpaTKNnPFb(i);
				}
				if (rfrevdAQlmgMUqEyzisvdOncCcPLc)
				{
					aRupGPGhdiseEwFloFcFEgiIWViV(i);
				}
			}
		}

		private void kLbBzkHBpfcCTNnWYZScenIkmRyfA()
		{
			if (rfrevdAQlmgMUqEyzisvdOncCcPLc)
			{
				foreach (KeyValuePair<int, tETJppGPewZKkvPMfzeTdMCcoLA> item in ULBRKIeZuBcdOGKmEYEOAPAuAtLx)
				{
					tETJppGPewZKkvPMfzeTdMCcoLA value = item.Value;
					value.wBJbTcgfHnEhmDenYCfaVIHZWqZx();
					value.Dispose();
				}
				ULBRKIeZuBcdOGKmEYEOAPAuAtLx.Clear();
			}
			if (!aBFCoOYnUjCVpLhbBzoBwESGdWQT)
			{
				return;
			}
			foreach (KeyValuePair<int, srlBRtRclsWYTCTseoEJvfJUEIIJA> item2 in iEEcsWdvoamBTqYvvLvJEUKAmBvV)
			{
				srlBRtRclsWYTCTseoEJvfJUEIIJA value2 = item2.Value;
				value2.wBJbTcgfHnEhmDenYCfaVIHZWqZx();
				value2.Dispose();
			}
			iEEcsWdvoamBTqYvvLvJEUKAmBvV.Clear();
		}

		private bool ZQNGlFPbmHbHsezVwhKzpaTKNnPFb(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (rfrevdAQlmgMUqEyzisvdOncCcPLc && HbXxmfJswkPCGAKIoZSlrDDopjDd.wdbobVVqGNZuweQHghUMfQylEikCb(P_0))
			{
				return false;
			}
			srlBRtRclsWYTCTseoEJvfJUEIIJA srlBRtRclsWYTCTseoEJvfJUEIIJA2 = DfNeyvCCjslkTybDGLVLhWXTVtWHA(P_0);
			if (srlBRtRclsWYTCTseoEJvfJUEIIJA2 == null)
			{
				return false;
			}
			int zYYgqhwkGDBNRFRrTuJySIaIjkCq = srlBRtRclsWYTCTseoEJvfJUEIIJA2.zYYgqhwkGDBNRFRrTuJySIaIjkCq;
			if (iEEcsWdvoamBTqYvvLvJEUKAmBvV.ContainsKey(zYYgqhwkGDBNRFRrTuJySIaIjkCq))
			{
				iEEcsWdvoamBTqYvvLvJEUKAmBvV[zYYgqhwkGDBNRFRrTuJySIaIjkCq].wBJbTcgfHnEhmDenYCfaVIHZWqZx();
				iEEcsWdvoamBTqYvvLvJEUKAmBvV[zYYgqhwkGDBNRFRrTuJySIaIjkCq] = srlBRtRclsWYTCTseoEJvfJUEIIJA2;
			}
			else
			{
				iEEcsWdvoamBTqYvvLvJEUKAmBvV.Add(zYYgqhwkGDBNRFRrTuJySIaIjkCq, srlBRtRclsWYTCTseoEJvfJUEIIJA2);
			}
			srlBRtRclsWYTCTseoEJvfJUEIIJA2.HZxShlCnEHLtQSJwMaArEkAaHiQTA();
			return true;
		}

		private void gaaDQojtYwtfBehquefKOInFYLjI(int P_0)
		{
			if (iEEcsWdvoamBTqYvvLvJEUKAmBvV.ContainsKey(P_0))
			{
				iEEcsWdvoamBTqYvvLvJEUKAmBvV[P_0].wBJbTcgfHnEhmDenYCfaVIHZWqZx();
				iEEcsWdvoamBTqYvvLvJEUKAmBvV.Remove(P_0);
			}
		}

		private bool aRupGPGhdiseEwFloFcFEgiIWViV(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (!HbXxmfJswkPCGAKIoZSlrDDopjDd.wdbobVVqGNZuweQHghUMfQylEikCb(P_0))
			{
				return false;
			}
			tETJppGPewZKkvPMfzeTdMCcoLA tETJppGPewZKkvPMfzeTdMCcoLA2 = lVSVQgZRpNWoOJhfyiwAPxImJPBr(P_0);
			if (tETJppGPewZKkvPMfzeTdMCcoLA2 == null)
			{
				return false;
			}
			int zYYgqhwkGDBNRFRrTuJySIaIjkCq = tETJppGPewZKkvPMfzeTdMCcoLA2.zYYgqhwkGDBNRFRrTuJySIaIjkCq;
			if (ULBRKIeZuBcdOGKmEYEOAPAuAtLx.ContainsKey(zYYgqhwkGDBNRFRrTuJySIaIjkCq))
			{
				ULBRKIeZuBcdOGKmEYEOAPAuAtLx[zYYgqhwkGDBNRFRrTuJySIaIjkCq].wBJbTcgfHnEhmDenYCfaVIHZWqZx();
				ULBRKIeZuBcdOGKmEYEOAPAuAtLx[zYYgqhwkGDBNRFRrTuJySIaIjkCq] = tETJppGPewZKkvPMfzeTdMCcoLA2;
			}
			else
			{
				ULBRKIeZuBcdOGKmEYEOAPAuAtLx.Add(zYYgqhwkGDBNRFRrTuJySIaIjkCq, tETJppGPewZKkvPMfzeTdMCcoLA2);
			}
			tETJppGPewZKkvPMfzeTdMCcoLA2.HZxShlCnEHLtQSJwMaArEkAaHiQTA();
			return true;
		}

		private void OpwCHESUUbWllXtchxqGZeNYXgiV(int P_0)
		{
			if (ULBRKIeZuBcdOGKmEYEOAPAuAtLx.ContainsKey(P_0))
			{
				ULBRKIeZuBcdOGKmEYEOAPAuAtLx[P_0].wBJbTcgfHnEhmDenYCfaVIHZWqZx();
				ULBRKIeZuBcdOGKmEYEOAPAuAtLx.Remove(P_0);
			}
		}

		private srlBRtRclsWYTCTseoEJvfJUEIIJA YBVldCKQejleQcVQcSaTiVTDaWcj(int P_0)
		{
			if (!iEEcsWdvoamBTqYvvLvJEUKAmBvV.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private tETJppGPewZKkvPMfzeTdMCcoLA HScMzGEREqizKFoyKTaXoBmlEXcF(int P_0)
		{
			if (!ULBRKIeZuBcdOGKmEYEOAPAuAtLx.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private void QrdBIPjsmWLKqTHWHKbEPaIXRWtR()
		{
			while (HbXxmfJswkPCGAKIoZSlrDDopjDd.BTKhXGuidUpokCAwCevHNOiQtvlO(yuVZIutvXckLFQtomFpxLeASlamu) != 0)
			{
				DHknLWKnkPlPSMLfBqQRfiXKTZWR.nOmGzsFVcBsMmFUuasUXaEneEYeLA(yuVZIutvXckLFQtomFpxLeASlamu);
				HbXxmfJswkPCGAKIoZSlrDDopjDd.RFwIQQiPDZSVzKegOADpAimkyDdLB tzLjQqFaoheUSSbpgzfIxHMBPcYx = DHknLWKnkPlPSMLfBqQRfiXKTZWR.TzLjQqFaoheUSSbpgzfIxHMBPcYx;
				double realTime = ReInput.realTime;
				switch (tzLjQqFaoheUSSbpgzfIxHMBPcYx)
				{
				case HbXxmfJswkPCGAKIoZSlrDDopjDd.RFwIQQiPDZSVzKegOADpAimkyDdLB.SDL_CONTROLLERAXISMOTION:
					HOTahqGEtwFipeDOXpSlgeXGBeTP(ref DHknLWKnkPlPSMLfBqQRfiXKTZWR.KEoqcsgEVGXXsbAPfdQMxHOZmxHm, realTime);
					break;
				case HbXxmfJswkPCGAKIoZSlrDDopjDd.RFwIQQiPDZSVzKegOADpAimkyDdLB.SDL_CONTROLLERBUTTONDOWN:
				case HbXxmfJswkPCGAKIoZSlrDDopjDd.RFwIQQiPDZSVzKegOADpAimkyDdLB.SDL_CONTROLLERBUTTONUP:
					upILPKNRGcTJrVtBXFnIMICkRQel(ref DHknLWKnkPlPSMLfBqQRfiXKTZWR.TLcRJyZQvvftJvzdjdNUSJkRjgrY, realTime);
					break;
				case HbXxmfJswkPCGAKIoZSlrDDopjDd.RFwIQQiPDZSVzKegOADpAimkyDdLB.SDL_CONTROLLERDEVICEREMAPPED:
					OQHkaRJAdtkmjktXUPMIDrilMAYy(ref DHknLWKnkPlPSMLfBqQRfiXKTZWR.KPxUpjKeGStCjmorniAqIfOlmwSG);
					break;
				case HbXxmfJswkPCGAKIoZSlrDDopjDd.RFwIQQiPDZSVzKegOADpAimkyDdLB.SDL_JOYAXISMOTION:
					MAhCbqyussNeOhvCmneEZooFwAXT(ref DHknLWKnkPlPSMLfBqQRfiXKTZWR.QouWvKKjvpsqzEeTriSCwcPrKDcH, realTime);
					break;
				case HbXxmfJswkPCGAKIoZSlrDDopjDd.RFwIQQiPDZSVzKegOADpAimkyDdLB.SDL_JOYBUTTONDOWN:
				case HbXxmfJswkPCGAKIoZSlrDDopjDd.RFwIQQiPDZSVzKegOADpAimkyDdLB.SDL_JOYBUTTONUP:
					sXTCKXYUqPzqZvEISyDMWgOyNwHc(ref DHknLWKnkPlPSMLfBqQRfiXKTZWR.ZoIDaVNbTrCScwBrGfCtIJueoWne, realTime);
					break;
				case HbXxmfJswkPCGAKIoZSlrDDopjDd.RFwIQQiPDZSVzKegOADpAimkyDdLB.SDL_JOYHATMOTION:
					QFubhBgUEklYhtdfyPOabVAuHwbZA(ref DHknLWKnkPlPSMLfBqQRfiXKTZWR.KjHqvPOPsmhWMOLLlayJaXnEGyFE, realTime);
					break;
				case HbXxmfJswkPCGAKIoZSlrDDopjDd.RFwIQQiPDZSVzKegOADpAimkyDdLB.SDL_JOYBALLMOTION:
					GtIhrnUvDajlIzuFZanEzlnUHdwP(ref DHknLWKnkPlPSMLfBqQRfiXKTZWR.wzbwvUlnJnZAVuwSTAkWYpvXMzbb, realTime);
					break;
				case HbXxmfJswkPCGAKIoZSlrDDopjDd.RFwIQQiPDZSVzKegOADpAimkyDdLB.SDL_JOYDEVICEADDED:
					CpEGIyLZnFJYHIJGYivZhCYtsvvb(ref DHknLWKnkPlPSMLfBqQRfiXKTZWR.apwHhDrxKsflJyJaMFTZADlueJVA);
					break;
				case HbXxmfJswkPCGAKIoZSlrDDopjDd.RFwIQQiPDZSVzKegOADpAimkyDdLB.SDL_JOYDEVICEREMOVED:
					nlVddsQJLnJFEqYNIPddriYKxjDH(ref DHknLWKnkPlPSMLfBqQRfiXKTZWR.apwHhDrxKsflJyJaMFTZADlueJVA);
					break;
				case HbXxmfJswkPCGAKIoZSlrDDopjDd.RFwIQQiPDZSVzKegOADpAimkyDdLB.SDL_CONTROLLERDEVICEADDED:
					sjAoXMVeVSfHPgZgDdJGgtGQgcZd(ref DHknLWKnkPlPSMLfBqQRfiXKTZWR.KPxUpjKeGStCjmorniAqIfOlmwSG);
					break;
				case HbXxmfJswkPCGAKIoZSlrDDopjDd.RFwIQQiPDZSVzKegOADpAimkyDdLB.SDL_CONTROLLERDEVICEREMOVED:
					FYChMMbigHeUkeyOimbkiQBBBGZg(ref DHknLWKnkPlPSMLfBqQRfiXKTZWR.KPxUpjKeGStCjmorniAqIfOlmwSG);
					break;
				}
			}
		}

		private void MAhCbqyussNeOhvCmneEZooFwAXT(ref HbXxmfJswkPCGAKIoZSlrDDopjDd.otWjdTOVROwktTXkCApRprMddAgb P_0, double P_1)
		{
			if (aBFCoOYnUjCVpLhbBzoBwESGdWQT)
			{
				UNvlSfekRsVTyPbgHBXjSfBkOEyu(P_0.HqnRDdFqOHzvCLZsCyHVaYTDVDRD, dstbaIewkvGVrkHumIlsJRjhZXNo.Axis, P_0.IfUyappalxGMLhNrhQktLcVQGuWDA, P_0.zeHyPucPQqCFRhsHgvZwJpFhCqUP, P_1);
			}
		}

		private void sXTCKXYUqPzqZvEISyDMWgOyNwHc(ref HbXxmfJswkPCGAKIoZSlrDDopjDd.UGqpDTHJymMCOvCiqAIskApOKuUbA P_0, double P_1)
		{
			if (aBFCoOYnUjCVpLhbBzoBwESGdWQT)
			{
				UNvlSfekRsVTyPbgHBXjSfBkOEyu(P_0.nLLyecFARTOIXyajQVCNWRXHqvJk, dstbaIewkvGVrkHumIlsJRjhZXNo.Button, P_0.ZuFXLPYohhztRJjXKFnvkTYiBrBO, P_0.sbVoCtACmoHMBqoEvhksnzZCRDbt, P_1);
			}
		}

		private void QFubhBgUEklYhtdfyPOabVAuHwbZA(ref HbXxmfJswkPCGAKIoZSlrDDopjDd.NelPnlXkpuGDrVQpyTcssBIaFcaGA P_0, double P_1)
		{
			if (aBFCoOYnUjCVpLhbBzoBwESGdWQT)
			{
				UNvlSfekRsVTyPbgHBXjSfBkOEyu(P_0.HYGCizvXiaDXnDvoxRmJUJIGKwEdA, dstbaIewkvGVrkHumIlsJRjhZXNo.Hat, P_0.lPDCYwAWBVPCoiNaUdVVyHfOSEzl, P_0.SLVmdSvJGcJxSdVpZQmxJalxGFOFA, P_1);
			}
		}

		private void GtIhrnUvDajlIzuFZanEzlnUHdwP(ref HbXxmfJswkPCGAKIoZSlrDDopjDd.miFIrsIKXbTixckNlFArMaVqhvqc P_0, double P_1)
		{
			_ = aBFCoOYnUjCVpLhbBzoBwESGdWQT;
		}

		private void CpEGIyLZnFJYHIJGYivZhCYtsvvb(ref HbXxmfJswkPCGAKIoZSlrDDopjDd.UQbJvRQtIvtSiRzocoAlpSgNsWCh P_0)
		{
			if (aBFCoOYnUjCVpLhbBzoBwESGdWQT)
			{
				ZQNGlFPbmHbHsezVwhKzpaTKNnPFb(P_0.KoNowzZnOqJALriAthIhjKpeGIzO);
				if (wueFdYdGBMyITdNlxDYvQbdzbSbl != null)
				{
					wueFdYdGBMyITdNlxDYvQbdzbSbl();
				}
			}
		}

		private void nlVddsQJLnJFEqYNIPddriYKxjDH(ref HbXxmfJswkPCGAKIoZSlrDDopjDd.UQbJvRQtIvtSiRzocoAlpSgNsWCh P_0)
		{
			if (aBFCoOYnUjCVpLhbBzoBwESGdWQT)
			{
				gaaDQojtYwtfBehquefKOInFYLjI(P_0.KoNowzZnOqJALriAthIhjKpeGIzO);
				if (wueFdYdGBMyITdNlxDYvQbdzbSbl != null)
				{
					wueFdYdGBMyITdNlxDYvQbdzbSbl();
				}
			}
		}

		private void HOTahqGEtwFipeDOXpSlgeXGBeTP(ref HbXxmfJswkPCGAKIoZSlrDDopjDd.kRCgpsCXmekSAITHoowEPphfpCbAb P_0, double P_1)
		{
			if (rfrevdAQlmgMUqEyzisvdOncCcPLc && P_0.WDGsfkFVhoPgvTGbdfaJxLlPwWfP != 6)
			{
				VuYimkqekkCzALzWRTaSqKJZiKfR(P_0.SHanvBXXeNOadzBgyjDoiQghRQFLA, dstbaIewkvGVrkHumIlsJRjhZXNo.Axis, P_0.WDGsfkFVhoPgvTGbdfaJxLlPwWfP, P_0.pwJXwfYOLUVpseUCnfQGqHnWDnjB, P_1);
			}
		}

		private void upILPKNRGcTJrVtBXFnIMICkRQel(ref HbXxmfJswkPCGAKIoZSlrDDopjDd.TvxcZheNMVFnfaBIREXLDlCFNYGg P_0, double P_1)
		{
			if (rfrevdAQlmgMUqEyzisvdOncCcPLc && P_0.OFteFmDjsDgjfsBlOzKWEbrcLqHAA != 15)
			{
				VuYimkqekkCzALzWRTaSqKJZiKfR(P_0.ezbLRASClTikjfmDSItRtIlVlHRG, dstbaIewkvGVrkHumIlsJRjhZXNo.Button, P_0.OFteFmDjsDgjfsBlOzKWEbrcLqHAA, P_0.ASqfcnCIRzDqqbGNpgQRrGqtcUKn, P_1);
			}
		}

		private void sjAoXMVeVSfHPgZgDdJGgtGQgcZd(ref HbXxmfJswkPCGAKIoZSlrDDopjDd.lYpcTTdJDphqupPyKZynALPjYLcv P_0)
		{
			if (rfrevdAQlmgMUqEyzisvdOncCcPLc)
			{
				aRupGPGhdiseEwFloFcFEgiIWViV(P_0.rNJWsQELhmQFrceMyocAsHtTTBYr);
				if (wueFdYdGBMyITdNlxDYvQbdzbSbl != null)
				{
					wueFdYdGBMyITdNlxDYvQbdzbSbl();
				}
			}
		}

		private void FYChMMbigHeUkeyOimbkiQBBBGZg(ref HbXxmfJswkPCGAKIoZSlrDDopjDd.lYpcTTdJDphqupPyKZynALPjYLcv P_0)
		{
			if (rfrevdAQlmgMUqEyzisvdOncCcPLc)
			{
				OpwCHESUUbWllXtchxqGZeNYXgiV(P_0.rNJWsQELhmQFrceMyocAsHtTTBYr);
				if (wueFdYdGBMyITdNlxDYvQbdzbSbl != null)
				{
					wueFdYdGBMyITdNlxDYvQbdzbSbl();
				}
			}
		}

		private void OQHkaRJAdtkmjktXUPMIDrilMAYy(ref HbXxmfJswkPCGAKIoZSlrDDopjDd.lYpcTTdJDphqupPyKZynALPjYLcv P_0)
		{
			_ = rfrevdAQlmgMUqEyzisvdOncCcPLc;
		}

		private void UNvlSfekRsVTyPbgHBXjSfBkOEyu(int P_0, dstbaIewkvGVrkHumIlsJRjhZXNo P_1, byte P_2, short P_3, double P_4)
		{
			YBVldCKQejleQcVQcSaTiVTDaWcj(P_0)?.WODITJAaSHtLwbyxrTLEkHPYAvMcA(P_1, P_2, P_3, P_4);
		}

		private void VuYimkqekkCzALzWRTaSqKJZiKfR(int P_0, dstbaIewkvGVrkHumIlsJRjhZXNo P_1, byte P_2, short P_3, double P_4)
		{
			HScMzGEREqizKFoyKTaXoBmlEXcF(P_0)?.WODITJAaSHtLwbyxrTLEkHPYAvMcA(P_1, P_2, P_3, P_4);
		}

		private void xpWqPbPrATYaEzIuIffmqGJgrBBw()
		{
			string[] array = PhOBXNARWNTuQFLywPJVjRIBOpxwb.PUMmqnAtsrSVpSfsNgzPiVTeBsms();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]) && array[i].Length > 32 && !(HbXxmfJswkPCGAKIoZSlrDDopjDd.XkaFesafKsVzBTzwVaIKpkaoMVPQA(new Guid(array[i].Substring(0, 32))) != string.Empty))
				{
					HbXxmfJswkPCGAKIoZSlrDDopjDd.ovBxSIRSHYMHXjQeApKRaTZJIMnA(array[i]);
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~SDL2InputSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (WjsezAYiGdAORbqryhxuehoKNJeq)
			{
				return;
			}
			if (disposing)
			{
				if (yuVZIutvXckLFQtomFpxLeASlamu != null)
				{
					yuVZIutvXckLFQtomFpxLeASlamu.Dispose();
				}
				kLbBzkHBpfcCTNnWYZScenIkmRyfA();
			}
			HbXxmfJswkPCGAKIoZSlrDDopjDd.ryLfqiChcpCmSXZtWDthdaXfBmjEA();
			fOASMLIjcdgofrOZaDlQJGLzbiRaA = false;
			WjsezAYiGdAORbqryhxuehoKNJeq = true;
		}
	}
}
