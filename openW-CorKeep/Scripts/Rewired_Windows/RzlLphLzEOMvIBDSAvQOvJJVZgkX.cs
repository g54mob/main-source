using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;

internal class RzlLphLzEOMvIBDSAvQOvJJVZgkX : PlatformInputManager
{
	private class jsGXYXRZOYjvYoskDsmyuZXsNuTg : IInputManagerJoystick, IInputManagerJoystickPublic, IDisposable
	{
		private int hGOYvvhMkBTTyXAIhVuankOzkGWL;

		private int pNUyuYdTSZhMKlgkgblBBYfnQDcV;

		public Guid lqbIYUgeEoeDikuGSzYKahXjDKUHb;

		public string wRGNJtzmVFlvbfNtEQzJYPEruBAy;

		public sFFXXFtEebhJcIFEaMaPQTQrWwKC zWDgGSdtKockwPrIbxjtZTzNwpnI;

		public string zmryjpcAbBuMBUbXLRVPHvvpECdF;

		public string CJETarhelTJZKNJOklrLQiURbCvY;

		public Guid jIpLVYbvAPBlNnuxIOBWDLADNEcW;

		public PidVid ChTGPyGmitiIoXYeHYItehvBLmIbb;

		public Guid cdYmnZHmxpAHgAmlFwCgErizZaVw;

		public int qSNsOnzZWWqFAAhwwFzpFzoZAYcyA;

		public int qDVdHWCnlrHwUQEyZNABsikdKYnwA;

		public int UibjcDpviAGDnSyTCSCLaapmRtIA;

		public int zfxOpWVHoGljOHOgTtBKMIfNqUTG;

		public int VMVFUCpeDzpAfeOnliLOpbIBsOve;

		public int waHEkrLBAZdtyDmneQPPpBETQWIDA;

		public bool qTVQlbvVtawgDNcTSqPnwNpqGuDf;

		public int jjOayZCestjjhFszAHIjUifkbgEFc;

		private float[] ezeZNrmJKQNmLfaNXqTTpOhhfZRZ;

		private float[] qJCkCqJNAmdkJHVuFHywUmghnwJF;

		private bool[] LTbsNjimgSrbvOLJbzTAAnYRrmAg;

		private HardwareJoystickMap_InputManager BiBOYAIFYvGOpFPZJKlmACwHqbQw;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> kIHFnoxiTDDvdgeJgWPiheTXkUau;

		private bool ebbcHTGRCKajXMGPwWsbJthOMMBmA;

		private bool SkADoAICNoGlVvLrgXveBBuutUePA;

		[CompilerGenerated]
		private Controller.Extension kkaCHLFDpqEsxqQNlTAhQImRKyUfb;

		private bool iUUTgAEmizcCdKrGioPTatAcwUap;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return hGOYvvhMkBTTyXAIhVuankOzkGWL;
			}
			set
			{
				hGOYvvhMkBTTyXAIhVuankOzkGWL = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return pNUyuYdTSZhMKlgkgblBBYfnQDcV;
			}
			set
			{
				pNUyuYdTSZhMKlgkgblBBYfnQDcV = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (!(wRGNJtzmVFlvbfNtEQzJYPEruBAy != "Unknown Controller"))
				{
					return CJETarhelTJZKNJOklrLQiURbCvY;
				}
				return wRGNJtzmVFlvbfNtEQzJYPEruBAy;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (pNUyuYdTSZhMKlgkgblBBYfnQDcV < 0)
				{
					return null;
				}
				return pNUyuYdTSZhMKlgkgblBBYfnQDcV;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => jIpLVYbvAPBlNnuxIOBWDLADNEcW;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid
		{
			get
			{
				if (zWDgGSdtKockwPrIbxjtZTzNwpnI == null)
				{
					return Guid.Empty;
				}
				return zWDgGSdtKockwPrIbxjtZTzNwpnI.UqNTZcGDZRSyoPrzTNwRjhAOWjLG;
			}
		}

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			[CompilerGenerated]
			get
			{
				return kkaCHLFDpqEsxqQNlTAhQImRKyUfb;
			}
			[CompilerGenerated]
			set
			{
				kkaCHLFDpqEsxqQNlTAhQImRKyUfb = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			if (qTVQlbvVtawgDNcTSqPnwNpqGuDf)
			{
				zWDgGSdtKockwPrIbxjtZTzNwpnI.CmBbgpeQZhQhOMkZzpRNYtXllIpUA(motorIndex, amount, false);
			}
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			if (qTVQlbvVtawgDNcTSqPnwNpqGuDf)
			{
				zWDgGSdtKockwPrIbxjtZTzNwpnI.KFBNDrqMYOLZdIJVwxDYfxUDaKdI();
			}
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public jsGXYXRZOYjvYoskDsmyuZXsNuTg(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_0)
		{
			kIHFnoxiTDDvdgeJgWPiheTXkUau = P_0;
			pNUyuYdTSZhMKlgkgblBBYfnQDcV = -1;
			hGOYvvhMkBTTyXAIhVuankOzkGWL = -1;
		}

		public void YphXuDDrXsTrbfZpfJoMXJUufryP()
		{
			cdYmnZHmxpAHgAmlFwCgErizZaVw = MiscTools.CreateGuidHashSHA1(CJETarhelTJZKNJOklrLQiURbCvY + ChTGPyGmitiIoXYeHYItehvBLmIbb.ToProductGuid().ToString());
			qDVdHWCnlrHwUQEyZNABsikdKYnwA = zfxOpWVHoGljOHOgTtBKMIfNqUTG;
			UibjcDpviAGDnSyTCSCLaapmRtIA = VMVFUCpeDzpAfeOnliLOpbIBsOve + waHEkrLBAZdtyDmneQPPpBETQWIDA * 8;
			bPDLuFnWysrQtGgobhpvAvNLzYDD();
			lqbIYUgeEoeDikuGSzYKahXjDKUHb = BiBOYAIFYvGOpFPZJKlmACwHqbQw.hardwareMapIdentifier.guid;
			wRGNJtzmVFlvbfNtEQzJYPEruBAy = BiBOYAIFYvGOpFPZJKlmACwHqbQw.controllerName;
			ebbcHTGRCKajXMGPwWsbJthOMMBmA = lqbIYUgeEoeDikuGSzYKahXjDKUHb == Guid.Empty;
			ezeZNrmJKQNmLfaNXqTTpOhhfZRZ = new float[qDVdHWCnlrHwUQEyZNABsikdKYnwA];
			qJCkCqJNAmdkJHVuFHywUmghnwJF = new float[UibjcDpviAGDnSyTCSCLaapmRtIA];
			LTbsNjimgSrbvOLJbzTAAnYRrmAg = new bool[UibjcDpviAGDnSyTCSCLaapmRtIA];
			if (UibjcDpviAGDnSyTCSCLaapmRtIA > 0)
			{
				HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)BiBOYAIFYvGOpFPZJKlmACwHqbQw.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						LTbsNjimgSrbvOLJbzTAAnYRrmAg[i] = buttons_orig[i].buttonInfo.isPressureSensitive;
					}
				}
			}
			Update();
		}

		public void DkcLlrceLEqSWviIkoVnDeHCqmpR(jsGXYXRZOYjvYoskDsmyuZXsNuTg P_0)
		{
			if (P_0 != null)
			{
				pNUyuYdTSZhMKlgkgblBBYfnQDcV = P_0.pNUyuYdTSZhMKlgkgblBBYfnQDcV;
				hGOYvvhMkBTTyXAIhVuankOzkGWL = P_0.hGOYvvhMkBTTyXAIhVuankOzkGWL;
				for (int i = 0; i < MathTools.Min(qJCkCqJNAmdkJHVuFHywUmghnwJF.Length, P_0.qJCkCqJNAmdkJHVuFHywUmghnwJF.Length); i++)
				{
					qJCkCqJNAmdkJHVuFHywUmghnwJF[i] = P_0.qJCkCqJNAmdkJHVuFHywUmghnwJF[i];
				}
				for (int j = 0; j < MathTools.Min(LTbsNjimgSrbvOLJbzTAAnYRrmAg.Length, P_0.LTbsNjimgSrbvOLJbzTAAnYRrmAg.Length); j++)
				{
					LTbsNjimgSrbvOLJbzTAAnYRrmAg[j] = P_0.LTbsNjimgSrbvOLJbzTAAnYRrmAg[j];
				}
				for (int k = 0; k < MathTools.Min(ezeZNrmJKQNmLfaNXqTTpOhhfZRZ.Length, P_0.ezeZNrmJKQNmLfaNXqTTpOhhfZRZ.Length); k++)
				{
					ezeZNrmJKQNmLfaNXqTTpOhhfZRZ[k] = P_0.ezeZNrmJKQNmLfaNXqTTpOhhfZRZ[k];
				}
				SkADoAICNoGlVvLrgXveBBuutUePA = P_0.SkADoAICNoGlVvLrgXveBBuutUePA;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			HZoWDhsVpvGsiNZMFkUdVVGUfzgL();
			RkmDWLJLaMljlsJGPgeEGLZHMOQoA();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (qDVdHWCnlrHwUQEyZNABsikdKYnwA != dataUpdater.axisCount || UibjcDpviAGDnSyTCSCLaapmRtIA != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < qDVdHWCnlrHwUQEyZNABsikdKYnwA; i++)
			{
				dataUpdater.axisValues[i] = ezeZNrmJKQNmLfaNXqTTpOhhfZRZ[i];
			}
			for (int j = 0; j < UibjcDpviAGDnSyTCSCLaapmRtIA; j++)
			{
				if (LTbsNjimgSrbvOLJbzTAAnYRrmAg[j])
				{
					dataUpdater.buttonPressureValues[j] = qJCkCqJNAmdkJHVuFHywUmghnwJF[j];
				}
				else
				{
					dataUpdater.buttonValues[j] = qJCkCqJNAmdkJHVuFHywUmghnwJF[j] > 0f;
				}
			}
			if (SkADoAICNoGlVvLrgXveBBuutUePA && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int ZtNHttTjyIcdePcwNgGNqUfNUoio(jsGXYXRZOYjvYoskDsmyuZXsNuTg P_0)
		{
			if (P_0.hGOYvvhMkBTTyXAIhVuankOzkGWL == hGOYvvhMkBTTyXAIhVuankOzkGWL)
			{
				return 2;
			}
			if (zfxOpWVHoGljOHOgTtBKMIfNqUTG != P_0.zfxOpWVHoGljOHOgTtBKMIfNqUTG)
			{
				return 0;
			}
			if (VMVFUCpeDzpAfeOnliLOpbIBsOve != P_0.VMVFUCpeDzpAfeOnliLOpbIBsOve)
			{
				return 0;
			}
			if (waHEkrLBAZdtyDmneQPPpBETQWIDA != P_0.waHEkrLBAZdtyDmneQPPpBETQWIDA)
			{
				return 0;
			}
			if (P_0.jIpLVYbvAPBlNnuxIOBWDLADNEcW == jIpLVYbvAPBlNnuxIOBWDLADNEcW)
			{
				return 2;
			}
			if (P_0.cdYmnZHmxpAHgAmlFwCgErizZaVw == cdYmnZHmxpAHgAmlFwCgErizZaVw)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo GxmcwJNrGADsdeKsLRcIUAxxShOUA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			AisdEoKzykXyMwYDsWacAidFcbOL(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			fRGHIczfioFhwfnIvcWRLocudMYMA(bridgedController);
			return bridgedController;
		}

		BridgedController IInputManagerJoystick.ToBridgedController()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToBridgedController
			return this.ToBridgedController();
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(hGOYvvhMkBTTyXAIhVuankOzkGWL);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void HZoWDhsVpvGsiNZMFkUdVVGUfzgL()
		{
			if (qDVdHWCnlrHwUQEyZNABsikdKYnwA <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_WindowsWGI_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)BiBOYAIFYvGOpFPZJKlmACwHqbQw.map).Axes_orig;
			if (axes_orig != null)
			{
				for (int i = 0; i < axes_orig.Length; i++)
				{
					LUdBkBGdeHQJMJMvVAeGpqLFKCVLA(axes_orig[i], i);
				}
			}
		}

		private void RkmDWLJLaMljlsJGPgeEGLZHMOQoA()
		{
			if (UibjcDpviAGDnSyTCSCLaapmRtIA <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)BiBOYAIFYvGOpFPZJKlmACwHqbQw.map).Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					ObKZGRQAEjXxwXXqJllFdaWlNtrI(buttons_orig[i], i);
				}
			}
		}

		private void LUdBkBGdeHQJMJMvVAeGpqLFKCVLA(HardwareJoystickMap.Platform_WindowsWGI_Base.Axis P_0, int P_1)
		{
			if (P_1 >= qDVdHWCnlrHwUQEyZNABsikdKYnwA)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			ezeZNrmJKQNmLfaNXqTTpOhhfZRZ[P_1] = MoJCTAOZseuILgXYgcdcbmdrwZrn(P_0);
			if (!SkADoAICNoGlVvLrgXveBBuutUePA && ezeZNrmJKQNmLfaNXqTTpOhhfZRZ[P_1] != 0f)
			{
				SkADoAICNoGlVvLrgXveBBuutUePA = true;
			}
		}

		private void ObKZGRQAEjXxwXXqJllFdaWlNtrI(HardwareJoystickMap.Platform_WindowsWGI_Base.Button P_0, int P_1)
		{
			if (P_1 >= UibjcDpviAGDnSyTCSCLaapmRtIA)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			qJCkCqJNAmdkJHVuFHywUmghnwJF[P_1] = GwJJVsMtgEUdylGPgfZOfbEQMhBQ(P_0);
			if (!SkADoAICNoGlVvLrgXveBBuutUePA && qJCkCqJNAmdkJHVuFHywUmghnwJF[P_1] != 0f)
			{
				SkADoAICNoGlVvLrgXveBBuutUePA = true;
			}
		}

		private float MoJCTAOZseuILgXYgcdcbmdrwZrn(HardwareJoystickMap.Platform_WindowsWGI_Base.Axis P_0)
		{
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0)
				{
					return 0f;
				}
				return vhROTxrEBtblyugOhSNUaLKghdxgA(sourceAxis);
			}
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= VMVFUCpeDzpAfeOnliLOpbIBsOve || sourceButton >= 256)
				{
					return 0f;
				}
				if (!zWDgGSdtKockwPrIbxjtZTzNwpnI.SzTuQVqAJKYNHDiHtrcYuCUbKRlU(sourceButton))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			if (P_0.sourceType == 2)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= waHEkrLBAZdtyDmneQPPpBETQWIDA || sourceHat >= 4)
				{
					return 0f;
				}
				int num = zWDgGSdtKockwPrIbxjtZTzNwpnI.TAwokATJzSFHXnTVDdcYbFXSyIov(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = SiEasMMJTZhSLbIwWZSWVkKtdBzX(num, AxisDirection.Horizontal);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				else
				{
					num2 = SiEasMMJTZhSLbIwWZSWVkKtdBzX(num, AxisDirection.Vertical);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				if (P_0.invert)
				{
					num2 *= -1f;
				}
				return num2;
			}
			return 0f;
		}

		private float vhROTxrEBtblyugOhSNUaLKghdxgA(int P_0)
		{
			if (P_0 < 0 || P_0 >= zWDgGSdtKockwPrIbxjtZTzNwpnI.PMzrvbKvkfPgCVbzUsFjoeVOURkb)
			{
				return 0f;
			}
			return zWDgGSdtKockwPrIbxjtZTzNwpnI.qZiXLrbopCWUKyspMdZdpFeWEAsv(P_0);
		}

		private float GwJJVsMtgEUdylGPgfZOfbEQMhBQ(HardwareJoystickMap.Platform_WindowsWGI_Base.Button P_0)
		{
			if (P_0.sourceType == 0)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (zWDgGSdtKockwPrIbxjtZTzNwpnI.SzTuQVqAJKYNHDiHtrcYuCUbKRlU(P_0.ignoreIfButtonsActiveButtons[i]))
						{
							return 0f;
						}
					}
				}
				if (P_0.requireMultipleButtons)
				{
					bool flag = false;
					for (int j = 0; j < P_0.requiredButtons.Length; j++)
					{
						if (!zWDgGSdtKockwPrIbxjtZTzNwpnI.SzTuQVqAJKYNHDiHtrcYuCUbKRlU(P_0.requiredButtons[j]))
						{
							return 0f;
						}
						flag = true;
					}
					if (flag)
					{
						return 1f;
					}
					return 0f;
				}
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= VMVFUCpeDzpAfeOnliLOpbIBsOve || sourceButton >= 256)
				{
					return 0f;
				}
				if (!zWDgGSdtKockwPrIbxjtZTzNwpnI.SzTuQVqAJKYNHDiHtrcYuCUbKRlU(sourceButton))
				{
					return 0f;
				}
				return 1f;
			}
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0)
				{
					return 0f;
				}
				float num = vhROTxrEBtblyugOhSNUaLKghdxgA(sourceAxis);
				float num2 = MathTools.Abs(num);
				if (num2 <= P_0.axisDeadZone)
				{
					return 0f;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num < 0f)
					{
						return 0f;
					}
				}
				else if (num > 0f)
				{
					return 0f;
				}
				return num2;
			}
			if (P_0.sourceType == 2)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= waHEkrLBAZdtyDmneQPPpBETQWIDA || sourceHat >= 4)
				{
					return 0f;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return eZAipVonGvlnSurEDBRTxmedwTdv(zWDgGSdtKockwPrIbxjtZTzNwpnI.TAwokATJzSFHXnTVDdcYbFXSyIov(sourceHat), 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return eZAipVonGvlnSurEDBRTxmedwTdv(zWDgGSdtKockwPrIbxjtZTzNwpnI.TAwokATJzSFHXnTVDdcYbFXSyIov(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return eZAipVonGvlnSurEDBRTxmedwTdv(zWDgGSdtKockwPrIbxjtZTzNwpnI.TAwokATJzSFHXnTVDdcYbFXSyIov(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return eZAipVonGvlnSurEDBRTxmedwTdv(zWDgGSdtKockwPrIbxjtZTzNwpnI.TAwokATJzSFHXnTVDdcYbFXSyIov(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return eZAipVonGvlnSurEDBRTxmedwTdv(zWDgGSdtKockwPrIbxjtZTzNwpnI.TAwokATJzSFHXnTVDdcYbFXSyIov(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return eZAipVonGvlnSurEDBRTxmedwTdv(zWDgGSdtKockwPrIbxjtZTzNwpnI.TAwokATJzSFHXnTVDdcYbFXSyIov(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return eZAipVonGvlnSurEDBRTxmedwTdv(zWDgGSdtKockwPrIbxjtZTzNwpnI.TAwokATJzSFHXnTVDdcYbFXSyIov(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return eZAipVonGvlnSurEDBRTxmedwTdv(zWDgGSdtKockwPrIbxjtZTzNwpnI.TAwokATJzSFHXnTVDdcYbFXSyIov(sourceHat), 7, P_0.sourceHatType);
				}
			}
			return 0f;
		}

		private float eZAipVonGvlnSurEDBRTxmedwTdv(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (BiBOYAIFYvGOpFPZJKlmACwHqbQw.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return 0f;
			}
			int num = 4500 * P_1;
			if (P_2 == HatType.EightWay && P_0 != num)
			{
				return 0f;
			}
			int num2;
			int num3;
			if (P_2 == HatType.EightWay)
			{
				num2 = 31500;
				num3 = 4500;
			}
			else
			{
				num2 = 27000;
				num3 = 9000;
			}
			if (P_1 == 0 && P_0 > num2)
			{
				P_0 -= 36000;
			}
			if (P_0 < num + num3 && P_0 > num - num3)
			{
				return 1f;
			}
			return 0f;
		}

		private float SiEasMMJTZhSLbIwWZSWVkKtdBzX(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (P_1 == AxisDirection.Vertical)
			{
				if (P_0 > 27000 || P_0 < 9000)
				{
					return 1f;
				}
				if (P_0 < 27000 && P_0 > 9000)
				{
					return -1f;
				}
				return 0f;
			}
			if (P_0 > 0 && P_0 < 18000)
			{
				return 1f;
			}
			if (P_0 > 18000)
			{
				return -1f;
			}
			return 0f;
		}

		private void bPDLuFnWysrQtGgobhpvAvNLzYDD()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = GxmcwJNrGADsdeKsLRcIUAxxShOUA();
			BiBOYAIFYvGOpFPZJKlmACwHqbQw = kIHFnoxiTDDvdgeJgWPiheTXkUau(bridgedControllerHWInfo);
			bool flag = false;
			bool flag2 = false;
			if (BiBOYAIFYvGOpFPZJKlmACwHqbQw == null || BiBOYAIFYvGOpFPZJKlmACwHqbQw.hardwareMapIdentifier.guid == Consts.joystickGuid_unknownController)
			{
				if (zWDgGSdtKockwPrIbxjtZTzNwpnI.AojGIrLhtcjaYmVEwiJmTkrTmlYk)
				{
					bridgedControllerHWInfo.hw_pidVid = new PidVid(4607, 10462);
					bridgedControllerHWInfo.hw_productId = bridgedControllerHWInfo.hw_pidVid.productId;
					bridgedControllerHWInfo.hw_vendorId = bridgedControllerHWInfo.hw_pidVid.vendorId;
					BiBOYAIFYvGOpFPZJKlmACwHqbQw = kIHFnoxiTDDvdgeJgWPiheTXkUau(bridgedControllerHWInfo);
					flag2 = true;
				}
				if (BiBOYAIFYvGOpFPZJKlmACwHqbQw == null || BiBOYAIFYvGOpFPZJKlmACwHqbQw.hardwareMapIdentifier.guid == Consts.joystickGuid_unknownController)
				{
					bridgedControllerHWInfo.hw_pidVid = new PidVid(736, 1118);
					bridgedControllerHWInfo.hw_productId = bridgedControllerHWInfo.hw_pidVid.productId;
					bridgedControllerHWInfo.hw_vendorId = bridgedControllerHWInfo.hw_pidVid.vendorId;
					bridgedControllerHWInfo.definitionMatchTag = string.Empty;
					BiBOYAIFYvGOpFPZJKlmACwHqbQw = kIHFnoxiTDDvdgeJgWPiheTXkUau(bridgedControllerHWInfo);
					flag = true;
				}
			}
			if (BiBOYAIFYvGOpFPZJKlmACwHqbQw == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (flag)
			{
				string text = string.Format("{0}:{1}", zWDgGSdtKockwPrIbxjtZTzNwpnI.nEIczxaNOfZCxCgYfmrTLVPGboagA.vendorId.ToString("x4"), zWDgGSdtKockwPrIbxjtZTzNwpnI.nEIczxaNOfZCxCgYfmrTLVPGboagA.productId.ToString("x4"));
				string key = LocalizationManager.AppendToKeyAsPath("windows_gaming_input_gamepad", text);
				BiBOYAIFYvGOpFPZJKlmACwHqbQw.deviceLocalizationInfo.InsertParentKey(0, key);
				BiBOYAIFYvGOpFPZJKlmACwHqbQw.deviceLocalizationInfo.InsertParentKey(1, "windows_gaming_input_gamepad");
				BiBOYAIFYvGOpFPZJKlmACwHqbQw.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text}]";
			}
			else if (zWDgGSdtKockwPrIbxjtZTzNwpnI.AojGIrLhtcjaYmVEwiJmTkrTmlYk && (flag2 || BiBOYAIFYvGOpFPZJKlmACwHqbQw.hardwareMapIdentifier.guid == Consts.joystickGuid_steamController))
			{
				string text2 = string.Format("{0}:{1}", zWDgGSdtKockwPrIbxjtZTzNwpnI.nEIczxaNOfZCxCgYfmrTLVPGboagA.vendorId.ToString("x4"), zWDgGSdtKockwPrIbxjtZTzNwpnI.nEIczxaNOfZCxCgYfmrTLVPGboagA.productId.ToString("x4"));
				string key2 = LocalizationManager.AppendToKeyAsPath((BiBOYAIFYvGOpFPZJKlmACwHqbQw.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(BiBOYAIFYvGOpFPZJKlmACwHqbQw.deviceLocalizationInfo.parentKeys[0])) ? BiBOYAIFYvGOpFPZJKlmACwHqbQw.deviceLocalizationInfo.parentKeys[0] : "steam_controller", text2);
				BiBOYAIFYvGOpFPZJKlmACwHqbQw.deviceLocalizationInfo.InsertParentKey(0, key2);
				BiBOYAIFYvGOpFPZJKlmACwHqbQw.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text2}]";
			}
			qDVdHWCnlrHwUQEyZNABsikdKYnwA = BiBOYAIFYvGOpFPZJKlmACwHqbQw.axisCount;
			UibjcDpviAGDnSyTCSCLaapmRtIA = BiBOYAIFYvGOpFPZJKlmACwHqbQw.buttonCount;
		}

		private string rfpCwVysVFUOEsJPwrICSdhbSfZy()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.WindowsGamingInput}{zWDgGSdtKockwPrIbxjtZTzNwpnI.RYXEhaYponftQkccoSjnHvzGrSxiA}{CJETarhelTJZKNJOklrLQiURbCvY}{ChTGPyGmitiIoXYeHYItehvBLmIbb.ToString()}");
		}

		private void AisdEoKzykXyMwYDsWacAidFcbOL(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.WindowsGamingInput;
			P_0.inputSource = zWDgGSdtKockwPrIbxjtZTzNwpnI.nREvZivNVhtdmtWrFJlqfppUtUAF;
			P_0.deviceType = (ControlDeviceType)zWDgGSdtKockwPrIbxjtZTzNwpnI.RYXEhaYponftQkccoSjnHvzGrSxiA;
			P_0.hardwareIdentifier = rfpCwVysVFUOEsJPwrICSdhbSfZy();
			P_0.hardwareAxisCount = zfxOpWVHoGljOHOgTtBKMIfNqUTG;
			P_0.hardwareButtonCount = VMVFUCpeDzpAfeOnliLOpbIBsOve;
			P_0.hardwareHatCount = waHEkrLBAZdtyDmneQPPpBETQWIDA;
			if (zWDgGSdtKockwPrIbxjtZTzNwpnI.AojGIrLhtcjaYmVEwiJmTkrTmlYk)
			{
				P_0.definitionMatchTag = "[STEAMCONFIGURED]";
			}
			P_0.hw_productName = CJETarhelTJZKNJOklrLQiURbCvY;
			P_0.hw_deviceGuid = jIpLVYbvAPBlNnuxIOBWDLADNEcW;
			P_0.hw_productId = ChTGPyGmitiIoXYeHYItehvBLmIbb.productId;
			P_0.hw_vendorId = ChTGPyGmitiIoXYeHYItehvBLmIbb.vendorId;
			P_0.hw_pidVid = ChTGPyGmitiIoXYeHYItehvBLmIbb;
			P_0.hw_isBluetoothDevice = false;
			P_0.hw_bluetoothDeviceName = CJETarhelTJZKNJOklrLQiURbCvY;
			P_0.hw_supportsVibration = qTVQlbvVtawgDNcTSqPnwNpqGuDf;
			P_0.hw_localVibrationMotorCount = jjOayZCestjjhFszAHIjUifkbgEFc;
		}

		private void fRGHIczfioFhwfnIvcWRLocudMYMA(BridgedController P_0)
		{
			AisdEoKzykXyMwYDsWacAidFcbOL(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = BiBOYAIFYvGOpFPZJKlmACwHqbQw.ToGameHardwareControllerMap();
			P_0.instanceName = zmryjpcAbBuMBUbXLRVPHvvpECdF;
			P_0.productName = CJETarhelTJZKNJOklrLQiURbCvY;
			P_0.axisCount = qDVdHWCnlrHwUQEyZNABsikdKYnwA;
			P_0.buttonCount = UibjcDpviAGDnSyTCSCLaapmRtIA;
			P_0.isButtonPressureSensitive = new bool[UibjcDpviAGDnSyTCSCLaapmRtIA];
			Array.Copy(LTbsNjimgSrbvOLJbzTAAnYRrmAg, P_0.isButtonPressureSensitive, UibjcDpviAGDnSyTCSCLaapmRtIA);
			P_0.unknownControllerHats = EoDvswPtcUDezWkjOFrAFOzQEpRKA();
			P_0.controllerTypeGuid = lqbIYUgeEoeDikuGSzYKahXjDKUHb;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void fEkGnwdBvGsoUvxhUdExERthZyjab()
		{
			for (int i = 0; i < UibjcDpviAGDnSyTCSCLaapmRtIA; i++)
			{
				qJCkCqJNAmdkJHVuFHywUmghnwJF[i] = 0f;
			}
			for (int j = 0; j < qDVdHWCnlrHwUQEyZNABsikdKYnwA; j++)
			{
				ezeZNrmJKQNmLfaNXqTTpOhhfZRZ[j] = 0f;
			}
		}

		private UnknownControllerHat[] EoDvswPtcUDezWkjOFrAFOzQEpRKA()
		{
			if (!ebbcHTGRCKajXMGPwWsbJthOMMBmA)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			for (int i = 0; i < 2; i++)
			{
				int num = 128 + i * 8;
				UnknownControllerHat.HatButtons hatButtons = new UnknownControllerHat.HatButtons(new int[8]
				{
					num,
					num + 1,
					num + 2,
					num + 3,
					num + 4,
					num + 5,
					num + 6,
					num + 7
				});
				array[i] = new UnknownControllerHat(hatButtons);
			}
			return array;
		}

		public void Dispose()
		{
			rtstuUcHcWDqZkGTNzypDdjudVLf(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void iVkykrxcRuNkUtXiCBSNbFYwhhls()
		{
			try
			{
				rtstuUcHcWDqZkGTNzypDdjudVLf(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void rtstuUcHcWDqZkGTNzypDdjudVLf(bool P_0)
		{
			if (!iUUTgAEmizcCdKrGioPTatAcwUap)
			{
				if (P_0 && zWDgGSdtKockwPrIbxjtZTzNwpnI != null)
				{
					zWDgGSdtKockwPrIbxjtZTzNwpnI.Dispose();
				}
				iUUTgAEmizcCdKrGioPTatAcwUap = true;
			}
		}

		public static int XIfwHzCsgDLxZKhGbHdZmPmOrszx(jsGXYXRZOYjvYoskDsmyuZXsNuTg P_0, jsGXYXRZOYjvYoskDsmyuZXsNuTg P_1)
		{
			if (P_0.pNUyuYdTSZhMKlgkgblBBYfnQDcV < P_1.pNUyuYdTSZhMKlgkgblBBYfnQDcV)
			{
				return -1;
			}
			if (P_0.pNUyuYdTSZhMKlgkgblBBYfnQDcV > P_1.pNUyuYdTSZhMKlgkgblBBYfnQDcV)
			{
				return 1;
			}
			return 0;
		}

		public static int gCuNBwdzZzrFumZiiBmcBKLVfanfA(jsGXYXRZOYjvYoskDsmyuZXsNuTg P_0, jsGXYXRZOYjvYoskDsmyuZXsNuTg P_1)
		{
			if (P_0.qSNsOnzZWWqFAAhwwFzpFzoZAYcyA < P_1.qSNsOnzZWWqFAAhwwFzpFzoZAYcyA)
			{
				return -1;
			}
			if (P_0.qSNsOnzZWWqFAAhwwFzpFzoZAYcyA > P_1.qSNsOnzZWWqFAAhwwFzpFzoZAYcyA)
			{
				return 1;
			}
			return 0;
		}
	}

	private class BTwedYDgAPeOkbElwmbjuUDFVFEW
	{
		public enum xTjkCcCCRamqzSbewBpYkakCcxngA
		{
			Exact = 0,
			Approximate = 1
		}

		public class ZpLLNNCudyfFGzcLLZTrilnVAEuP
		{
			public int CUeniocvfSBpmuKEBqaYoXCdMnwn;

			public Guid TJzFKKwcPhEhFhROOeMvKffnqraXA;

			public Guid vTvfPJNDqIJfLSpuHoAOjlgLfhyfA;

			public int GhCWFoKIsJQuzaVUzpgXMOjtRqNs;

			public int pfhkYlVZiamdfQRlRFsQHyZWGuMbA;

			public int pniZddojNboDTOZxbYzHdNvXCgb;

			public int mYQSgdGSmONafdqSbYrGNgkeFyXN;

			public int HpAlRcgbRpgfIcbKouNqakSSOyGm;

			public int ZRAcZyIDXMpbUWMihGWaLshcQrcs;

			public bool rjaKJRYIyHhyzNuvCkfiEKAfgUdQ(jsGXYXRZOYjvYoskDsmyuZXsNuTg P_0, xTjkCcCCRamqzSbewBpYkakCcxngA P_1)
			{
				if (pfhkYlVZiamdfQRlRFsQHyZWGuMbA != P_0.zfxOpWVHoGljOHOgTtBKMIfNqUTG)
				{
					return false;
				}
				if (pniZddojNboDTOZxbYzHdNvXCgb != P_0.VMVFUCpeDzpAfeOnliLOpbIBsOve)
				{
					return false;
				}
				if (mYQSgdGSmONafdqSbYrGNgkeFyXN != P_0.waHEkrLBAZdtyDmneQPPpBETQWIDA)
				{
					return false;
				}
				if (HpAlRcgbRpgfIcbKouNqakSSOyGm != P_0.UibjcDpviAGDnSyTCSCLaapmRtIA)
				{
					return false;
				}
				if (ZRAcZyIDXMpbUWMihGWaLshcQrcs != P_0.qDVdHWCnlrHwUQEyZNABsikdKYnwA)
				{
					return false;
				}
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == CUeniocvfSBpmuKEBqaYoXCdMnwn)
				{
					return true;
				}
				return P_1 switch
				{
					xTjkCcCCRamqzSbewBpYkakCcxngA.Exact => TJzFKKwcPhEhFhROOeMvKffnqraXA == P_0.jIpLVYbvAPBlNnuxIOBWDLADNEcW, 
					xTjkCcCCRamqzSbewBpYkakCcxngA.Approximate => vTvfPJNDqIJfLSpuHoAOjlgLfhyfA == P_0.cdYmnZHmxpAHgAmlFwCgErizZaVw, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		private sealed class vuinZanBxKvIzVbFtVgxwjoYDmlB : IEnumerable<ZpLLNNCudyfFGzcLLZTrilnVAEuP>, IEnumerable, IEnumerator<ZpLLNNCudyfFGzcLLZTrilnVAEuP>, IEnumerator, IDisposable
		{
			private int KiiTNrIeSbHFslSKVjDjSmsCpeOV;

			private ZpLLNNCudyfFGzcLLZTrilnVAEuP rPxxdyoFBSfLigcJPwoLybDYMAtd;

			private int cycBkXZQwOsCmahTqvSTxYjmwDne;

			public BTwedYDgAPeOkbElwmbjuUDFVFEW PCoffMItCzHuhLiWcFGxAJxniWzk;

			private jsGXYXRZOYjvYoskDsmyuZXsNuTg PjzkwBUwnFOqRDHfadGoyLTUlYaL;

			public jsGXYXRZOYjvYoskDsmyuZXsNuTg uDBOqJpYKtChZXKkfwoRsyrYdIWV;

			private xTjkCcCCRamqzSbewBpYkakCcxngA ePAGkEQxGOnxLUEQPgaLqwRiFuiH;

			public xTjkCcCCRamqzSbewBpYkakCcxngA PHPfVLAnkKQqeSHJErFocaLSefLGA;

			private int BslCgujgFrptRsSVRHCGcxNSlfnQ;

			private int TjcTXzQSEXnSzQOOIOevYMGXaAtDA;

			ZpLLNNCudyfFGzcLLZTrilnVAEuP IEnumerator<ZpLLNNCudyfFGzcLLZTrilnVAEuP>.Current
			{
				[DebuggerHidden]
				get
				{
					return rPxxdyoFBSfLigcJPwoLybDYMAtd;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return rPxxdyoFBSfLigcJPwoLybDYMAtd;
				}
			}

			[DebuggerHidden]
			public vuinZanBxKvIzVbFtVgxwjoYDmlB(int P_0)
			{
				KiiTNrIeSbHFslSKVjDjSmsCpeOV = P_0;
				cycBkXZQwOsCmahTqvSTxYjmwDne = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				KiiTNrIeSbHFslSKVjDjSmsCpeOV = -2;
			}

			private bool MoveNext()
			{
				int kiiTNrIeSbHFslSKVjDjSmsCpeOV = KiiTNrIeSbHFslSKVjDjSmsCpeOV;
				BTwedYDgAPeOkbElwmbjuUDFVFEW pCoffMItCzHuhLiWcFGxAJxniWzk = PCoffMItCzHuhLiWcFGxAJxniWzk;
				if (kiiTNrIeSbHFslSKVjDjSmsCpeOV != 0)
				{
					if (kiiTNrIeSbHFslSKVjDjSmsCpeOV != 1)
					{
						return false;
					}
					KiiTNrIeSbHFslSKVjDjSmsCpeOV = -1;
					goto IL_0083;
				}
				KiiTNrIeSbHFslSKVjDjSmsCpeOV = -1;
				BslCgujgFrptRsSVRHCGcxNSlfnQ = pCoffMItCzHuhLiWcFGxAJxniWzk.vWOmaEGbAEQMTAaEjepuuNukXvwv.Count;
				TjcTXzQSEXnSzQOOIOevYMGXaAtDA = 0;
				goto IL_0093;
				IL_0083:
				TjcTXzQSEXnSzQOOIOevYMGXaAtDA++;
				goto IL_0093;
				IL_0093:
				if (TjcTXzQSEXnSzQOOIOevYMGXaAtDA < BslCgujgFrptRsSVRHCGcxNSlfnQ)
				{
					if (pCoffMItCzHuhLiWcFGxAJxniWzk.vWOmaEGbAEQMTAaEjepuuNukXvwv[TjcTXzQSEXnSzQOOIOevYMGXaAtDA].rjaKJRYIyHhyzNuvCkfiEKAfgUdQ(PjzkwBUwnFOqRDHfadGoyLTUlYaL, ePAGkEQxGOnxLUEQPgaLqwRiFuiH))
					{
						rPxxdyoFBSfLigcJPwoLybDYMAtd = pCoffMItCzHuhLiWcFGxAJxniWzk.vWOmaEGbAEQMTAaEjepuuNukXvwv[TjcTXzQSEXnSzQOOIOevYMGXaAtDA];
						KiiTNrIeSbHFslSKVjDjSmsCpeOV = 1;
						return true;
					}
					goto IL_0083;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ZpLLNNCudyfFGzcLLZTrilnVAEuP> IEnumerable<ZpLLNNCudyfFGzcLLZTrilnVAEuP>.GetEnumerator()
			{
				vuinZanBxKvIzVbFtVgxwjoYDmlB vuinZanBxKvIzVbFtVgxwjoYDmlB2;
				if (KiiTNrIeSbHFslSKVjDjSmsCpeOV == -2 && cycBkXZQwOsCmahTqvSTxYjmwDne == Environment.CurrentManagedThreadId)
				{
					KiiTNrIeSbHFslSKVjDjSmsCpeOV = 0;
					vuinZanBxKvIzVbFtVgxwjoYDmlB2 = this;
				}
				else
				{
					vuinZanBxKvIzVbFtVgxwjoYDmlB2 = new vuinZanBxKvIzVbFtVgxwjoYDmlB(0);
					vuinZanBxKvIzVbFtVgxwjoYDmlB2.PCoffMItCzHuhLiWcFGxAJxniWzk = PCoffMItCzHuhLiWcFGxAJxniWzk;
				}
				vuinZanBxKvIzVbFtVgxwjoYDmlB2.PjzkwBUwnFOqRDHfadGoyLTUlYaL = uDBOqJpYKtChZXKkfwoRsyrYdIWV;
				vuinZanBxKvIzVbFtVgxwjoYDmlB2.ePAGkEQxGOnxLUEQPgaLqwRiFuiH = PHPfVLAnkKQqeSHJErFocaLSefLGA;
				return vuinZanBxKvIzVbFtVgxwjoYDmlB2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ZpLLNNCudyfFGzcLLZTrilnVAEuP>)this).GetEnumerator();
			}
		}

		private List<ZpLLNNCudyfFGzcLLZTrilnVAEuP> vWOmaEGbAEQMTAaEjepuuNukXvwv;

		public BTwedYDgAPeOkbElwmbjuUDFVFEW()
		{
			vWOmaEGbAEQMTAaEjepuuNukXvwv = new List<ZpLLNNCudyfFGzcLLZTrilnVAEuP>();
		}

		public void AFCfcgKARzPvVzDJlmyfjcPzcnPcA(jsGXYXRZOYjvYoskDsmyuZXsNuTg P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = vWOmaEGbAEQMTAaEjepuuNukXvwv.Count;
			for (int i = 0; i < count; i++)
			{
				if (vWOmaEGbAEQMTAaEjepuuNukXvwv[i].rjaKJRYIyHhyzNuvCkfiEKAfgUdQ(P_0, xTjkCcCCRamqzSbewBpYkakCcxngA.Exact))
				{
					vWOmaEGbAEQMTAaEjepuuNukXvwv[i].CUeniocvfSBpmuKEBqaYoXCdMnwn = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					vWOmaEGbAEQMTAaEjepuuNukXvwv[i].TJzFKKwcPhEhFhROOeMvKffnqraXA = P_0.jIpLVYbvAPBlNnuxIOBWDLADNEcW;
					vWOmaEGbAEQMTAaEjepuuNukXvwv[i].vTvfPJNDqIJfLSpuHoAOjlgLfhyfA = P_0.cdYmnZHmxpAHgAmlFwCgErizZaVw;
					vWOmaEGbAEQMTAaEjepuuNukXvwv[i].GhCWFoKIsJQuzaVUzpgXMOjtRqNs = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					vWOmaEGbAEQMTAaEjepuuNukXvwv[i].pfhkYlVZiamdfQRlRFsQHyZWGuMbA = P_0.zfxOpWVHoGljOHOgTtBKMIfNqUTG;
					vWOmaEGbAEQMTAaEjepuuNukXvwv[i].pniZddojNboDTOZxbYzHdNvXCgb = P_0.VMVFUCpeDzpAfeOnliLOpbIBsOve;
					vWOmaEGbAEQMTAaEjepuuNukXvwv[i].mYQSgdGSmONafdqSbYrGNgkeFyXN = P_0.waHEkrLBAZdtyDmneQPPpBETQWIDA;
					vWOmaEGbAEQMTAaEjepuuNukXvwv[i].HpAlRcgbRpgfIcbKouNqakSSOyGm = P_0.UibjcDpviAGDnSyTCSCLaapmRtIA;
					vWOmaEGbAEQMTAaEjepuuNukXvwv[i].ZRAcZyIDXMpbUWMihGWaLshcQrcs = P_0.qDVdHWCnlrHwUQEyZNABsikdKYnwA;
					bPkrOsmDiBFWsFxmrJRwPYvBeSxOA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.jIpLVYbvAPBlNnuxIOBWDLADNEcW, i);
					return;
				}
			}
			vWOmaEGbAEQMTAaEjepuuNukXvwv.Add(new ZpLLNNCudyfFGzcLLZTrilnVAEuP
			{
				CUeniocvfSBpmuKEBqaYoXCdMnwn = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				TJzFKKwcPhEhFhROOeMvKffnqraXA = P_0.jIpLVYbvAPBlNnuxIOBWDLADNEcW,
				vTvfPJNDqIJfLSpuHoAOjlgLfhyfA = P_0.cdYmnZHmxpAHgAmlFwCgErizZaVw,
				GhCWFoKIsJQuzaVUzpgXMOjtRqNs = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				pfhkYlVZiamdfQRlRFsQHyZWGuMbA = P_0.zfxOpWVHoGljOHOgTtBKMIfNqUTG,
				pniZddojNboDTOZxbYzHdNvXCgb = P_0.VMVFUCpeDzpAfeOnliLOpbIBsOve,
				mYQSgdGSmONafdqSbYrGNgkeFyXN = P_0.waHEkrLBAZdtyDmneQPPpBETQWIDA,
				HpAlRcgbRpgfIcbKouNqakSSOyGm = P_0.UibjcDpviAGDnSyTCSCLaapmRtIA,
				ZRAcZyIDXMpbUWMihGWaLshcQrcs = P_0.qDVdHWCnlrHwUQEyZNABsikdKYnwA
			});
			bPkrOsmDiBFWsFxmrJRwPYvBeSxOA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.jIpLVYbvAPBlNnuxIOBWDLADNEcW, vWOmaEGbAEQMTAaEjepuuNukXvwv.Count - 1);
		}

		public bool DUYKgHMrGACXYmykyntLEFpdxvXo(jsGXYXRZOYjvYoskDsmyuZXsNuTg P_0, xTjkCcCCRamqzSbewBpYkakCcxngA P_1)
		{
			int count = vWOmaEGbAEQMTAaEjepuuNukXvwv.Count;
			for (int i = 0; i < count; i++)
			{
				if (vWOmaEGbAEQMTAaEjepuuNukXvwv[i].rjaKJRYIyHhyzNuvCkfiEKAfgUdQ(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(vuinZanBxKvIzVbFtVgxwjoYDmlB))]
		public IEnumerable<ZpLLNNCudyfFGzcLLZTrilnVAEuP> FSsTeZhILfhlpgbXDmoaCvRGexcSb(jsGXYXRZOYjvYoskDsmyuZXsNuTg P_0, xTjkCcCCRamqzSbewBpYkakCcxngA P_1)
		{
			return new vuinZanBxKvIzVbFtVgxwjoYDmlB(-2)
			{
				PCoffMItCzHuhLiWcFGxAJxniWzk = this,
				uDBOqJpYKtChZXKkfwoRsyrYdIWV = P_0,
				PHPfVLAnkKQqeSHJErFocaLSefLGA = P_1
			};
		}

		private void bPkrOsmDiBFWsFxmrJRwPYvBeSxOA(int P_0, Guid P_1, int P_2)
		{
			for (int num = vWOmaEGbAEQMTAaEjepuuNukXvwv.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (vWOmaEGbAEQMTAaEjepuuNukXvwv[num].CUeniocvfSBpmuKEBqaYoXCdMnwn == P_0 || vWOmaEGbAEQMTAaEjepuuNukXvwv[num].TJzFKKwcPhEhFhROOeMvKffnqraXA == P_1))
				{
					vWOmaEGbAEQMTAaEjepuuNukXvwv.RemoveAt(num);
				}
			}
		}
	}

	private const bool jAfcOqKNUXCyFqsUgYSoAEKdFjYx = true;

	private COdWbKJboNyalVwwCcRxsmbVOwLg HcofNKEvdjimRbWaruZzwLCwOCmWA;

	private List<jsGXYXRZOYjvYoskDsmyuZXsNuTg> GFHbUyVNCdiRcicisvCGPpQzSAvIA;

	private int GoUfFjFOcpBmsfDuHwYqBkWVKaZZb;

	private BTwedYDgAPeOkbElwmbjuUDFVFEW IPtDzgWCKdaCEkXRiaTuIasMalIfA;

	private bool TFFNLmvLCOjRvToRWaifwEZZUqpx;

	private ConfigVars mWQhUzexAqmRgAlFrmLMECyzNRFq;

	private Action<int, ControllerDataUpdater> lDDolGcjIOmMrxKPvOhYqzqTKhmg;

	private PlatformInputManager HcmbGQUELgmEIxhtmqOllzASgKxi;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> zLPOZuPBTBULOWmKPMlCMGHqbyQx;

	private readonly Func<int> UbEjOOwcmutgEdaVZEjDKHBzdueV;

	private Func<PidVid, bool> SryHaxvClIHmoCItzlnUGpIEAuoFB;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => GoUfFjFOcpBmsfDuHwYqBkWVKaZZb;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => HcmbGQUELgmEIxhtmqOllzASgKxi;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => HcofNKEvdjimRbWaruZzwLCwOCmWA;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.WindowsGamingInput;

	protected COdWbKJboNyalVwwCcRxsmbVOwLg GkYbgwNnJwBEKpkMKkHVClBIACse => HcofNKEvdjimRbWaruZzwLCwOCmWA;

	public RzlLphLzEOMvIBDSAvQOvJJVZgkX(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2, Func<PidVid, bool> P_3)
	{
		try
		{
			mWQhUzexAqmRgAlFrmLMECyzNRFq = P_0;
			zLPOZuPBTBULOWmKPMlCMGHqbyQx = P_1;
			UbEjOOwcmutgEdaVZEjDKHBzdueV = P_2;
			SryHaxvClIHmoCItzlnUGpIEAuoFB = P_3;
			HcmbGQUELgmEIxhtmqOllzASgKxi = this;
			HcofNKEvdjimRbWaruZzwLCwOCmWA = new COdWbKJboNyalVwwCcRxsmbVOwLg(P_0, true, false, false);
			HcofNKEvdjimRbWaruZzwLCwOCmWA.Rewired_002EInterfaces_002EIInputSource_002EDeviceChangedEvent += SystemDeviceConnected;
			lDDolGcjIOmMrxKPvOhYqzqTKhmg = UpdateControllerData;
		}
		catch (Exception)
		{
			OnDestroy();
			throw;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		IPtDzgWCKdaCEkXRiaTuIasMalIfA = new BTwedYDgAPeOkbElwmbjuUDFVFEW();
		HcofNKEvdjimRbWaruZzwLCwOCmWA.XdfPSlIpInCXIHZJkyXCMBJMiYBhA();
		AGhMbSflmbJZqfzeLzzwBKWycMyfA();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (HcofNKEvdjimRbWaruZzwLCwOCmWA != null)
		{
			HcofNKEvdjimRbWaruZzwLCwOCmWA.Update();
		}
		if (TFFNLmvLCOjRvToRWaifwEZZUqpx)
		{
			FmaspqBJHcKLzJlvRNfAgEhRnTaB();
		}
		if (HcofNKEvdjimRbWaruZzwLCwOCmWA != null)
		{
			HcofNKEvdjimRbWaruZzwLCwOCmWA.UpdateDevices(updateLoop);
		}
		IRTfYwDDGICJlPgtxijZobZJQkODA();
		if (HcofNKEvdjimRbWaruZzwLCwOCmWA != null)
		{
			HcofNKEvdjimRbWaruZzwLCwOCmWA.UpdateFinished();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (GFHbUyVNCdiRcicisvCGPpQzSAvIA != null)
		{
			int count = GFHbUyVNCdiRcicisvCGPpQzSAvIA.Count;
			for (int i = 0; i < count; i++)
			{
				if (GFHbUyVNCdiRcicisvCGPpQzSAvIA[i] != null)
				{
					GFHbUyVNCdiRcicisvCGPpQzSAvIA[i].Dispose();
				}
			}
		}
		if (HcofNKEvdjimRbWaruZzwLCwOCmWA != null)
		{
			HcofNKEvdjimRbWaruZzwLCwOCmWA.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return lDDolGcjIOmMrxKPvOhYqzqTKhmg;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < GoUfFjFOcpBmsfDuHwYqBkWVKaZZb; i++)
		{
			if (GFHbUyVNCdiRcicisvCGPpQzSAvIA[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
			{
				GFHbUyVNCdiRcicisvCGPpQzSAvIA[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		TFFNLmvLCOjRvToRWaifwEZZUqpx = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		TFFNLmvLCOjRvToRWaifwEZZUqpx = true;
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return HcofNKEvdjimRbWaruZzwLCwOCmWA.xMavyVSGxghOGurJiLaqOgbCbJzGA;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return HcofNKEvdjimRbWaruZzwLCwOCmWA.kPXEUcVnRKaQfmvocyDgXjGcIPzhA;
	}

	protected bool DhGObVSkLTUwichUyFUlLOszpjFd(PidVid P_0)
	{
		return SryHaxvClIHmoCItzlnUGpIEAuoFB(P_0);
	}

	private void AGhMbSflmbJZqfzeLzzwBKWycMyfA()
	{
		OUXbahuqZtNeJIcaaPmwLOckLzRR(MQhVvAOkbJItAxHOggzurjkCWlsI());
	}

	private void OUXbahuqZtNeJIcaaPmwLOckLzRR(IList<sFFXXFtEebhJcIFEaMaPQTQrWwKC> P_0)
	{
		int num = 0;
		List<jsGXYXRZOYjvYoskDsmyuZXsNuTg> gFHbUyVNCdiRcicisvCGPpQzSAvIA = GFHbUyVNCdiRcicisvCGPpQzSAvIA;
		int goUfFjFOcpBmsfDuHwYqBkWVKaZZb = GoUfFjFOcpBmsfDuHwYqBkWVKaZZb;
		GFHbUyVNCdiRcicisvCGPpQzSAvIA = new List<jsGXYXRZOYjvYoskDsmyuZXsNuTg>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				sFFXXFtEebhJcIFEaMaPQTQrWwKC sFFXXFtEebhJcIFEaMaPQTQrWwKC2 = P_0[i];
				jsGXYXRZOYjvYoskDsmyuZXsNuTg jsGXYXRZOYjvYoskDsmyuZXsNuTg2 = new jsGXYXRZOYjvYoskDsmyuZXsNuTg(zLPOZuPBTBULOWmKPMlCMGHqbyQx);
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.zWDgGSdtKockwPrIbxjtZTzNwpnI = sFFXXFtEebhJcIFEaMaPQTQrWwKC2;
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.jIpLVYbvAPBlNnuxIOBWDLADNEcW = sFFXXFtEebhJcIFEaMaPQTQrWwKC2.iNcbXhrkRtshEZzrzCiIatjPlhwT;
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.zmryjpcAbBuMBUbXLRVPHvvpECdF = sFFXXFtEebhJcIFEaMaPQTQrWwKC2.DermERFDDuknNAWqrwNxFHjOdvDY;
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.CJETarhelTJZKNJOklrLQiURbCvY = sFFXXFtEebhJcIFEaMaPQTQrWwKC2.DermERFDDuknNAWqrwNxFHjOdvDY;
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.ChTGPyGmitiIoXYeHYItehvBLmIbb = sFFXXFtEebhJcIFEaMaPQTQrWwKC2.nEIczxaNOfZCxCgYfmrTLVPGboagA;
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.qSNsOnzZWWqFAAhwwFzpFzoZAYcyA = sFFXXFtEebhJcIFEaMaPQTQrWwKC2.jdQZkLWhOTCuwBoGagjeqoLzuPso;
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.zfxOpWVHoGljOHOgTtBKMIfNqUTG = sFFXXFtEebhJcIFEaMaPQTQrWwKC2.PMzrvbKvkfPgCVbzUsFjoeVOURkb;
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.VMVFUCpeDzpAfeOnliLOpbIBsOve = sFFXXFtEebhJcIFEaMaPQTQrWwKC2.BuiaglcGIZgHfQKRClweFCeQurANA;
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.waHEkrLBAZdtyDmneQPPpBETQWIDA = sFFXXFtEebhJcIFEaMaPQTQrWwKC2.TBOfVQNrqBnKBfdYuPFDbQvzxpkp;
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.qTVQlbvVtawgDNcTSqPnwNpqGuDf = sFFXXFtEebhJcIFEaMaPQTQrWwKC2.YKHgWtXHnzKtfxYWBRJiWiTKmVKc;
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.jjOayZCestjjhFszAHIjUifkbgEFc = sFFXXFtEebhJcIFEaMaPQTQrWwKC2.uNZlJEPrenlWUhFkhZeOQpFMHbbc;
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension = sFFXXFtEebhJcIFEaMaPQTQrWwKC2.HfxmctBNvxaXZgrVfTpdBEsoqERYA;
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.zWDgGSdtKockwPrIbxjtZTzNwpnI = sFFXXFtEebhJcIFEaMaPQTQrWwKC2;
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.YphXuDDrXsTrbfZpfJoMXJUufryP();
				GFHbUyVNCdiRcicisvCGPpQzSAvIA.Add(jsGXYXRZOYjvYoskDsmyuZXsNuTg2);
				num++;
			}
		}
		GoUfFjFOcpBmsfDuHwYqBkWVKaZZb = num;
		VWfNYYHBnsiMaomuUddmBMbLbEzBb(goUfFjFOcpBmsfDuHwYqBkWVKaZZb, num, gFHbUyVNCdiRcicisvCGPpQzSAvIA, GFHbUyVNCdiRcicisvCGPpQzSAvIA);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(GFHbUyVNCdiRcicisvCGPpQzSAvIA[j]));
			}
		}
		uRhwysdnuBCKEsMfMIabCqlfLwTQ(gFHbUyVNCdiRcicisvCGPpQzSAvIA, GFHbUyVNCdiRcicisvCGPpQzSAvIA, false);
		uRhwysdnuBCKEsMfMIabCqlfLwTQ(GFHbUyVNCdiRcicisvCGPpQzSAvIA, gFHbUyVNCdiRcicisvCGPpQzSAvIA, true);
	}

	private void IRTfYwDDGICJlPgtxijZobZJQkODA()
	{
		for (int i = 0; i < GoUfFjFOcpBmsfDuHwYqBkWVKaZZb; i++)
		{
			GFHbUyVNCdiRcicisvCGPpQzSAvIA[i]?.Update();
		}
	}

	private IList<sFFXXFtEebhJcIFEaMaPQTQrWwKC> MQhVvAOkbJItAxHOggzurjkCWlsI()
	{
		return HcofNKEvdjimRbWaruZzwLCwOCmWA.GetJoysticks<sFFXXFtEebhJcIFEaMaPQTQrWwKC>();
	}

	private void VWfNYYHBnsiMaomuUddmBMbLbEzBb(int P_0, int P_1, List<jsGXYXRZOYjvYoskDsmyuZXsNuTg> P_2, List<jsGXYXRZOYjvYoskDsmyuZXsNuTg> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(jsGXYXRZOYjvYoskDsmyuZXsNuTg.gCuNBwdzZzrFumZiiBmcBKLVfanfA);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			KXNwqaDTWormjvhwlDzcPQfoArAG(P_1, P_3, P_0, P_2, BTwedYDgAPeOkbElwmbjuUDFVFEW.xTjkCcCCRamqzSbewBpYkakCcxngA.Exact);
			KXNwqaDTWormjvhwlDzcPQfoArAG(P_1, P_3, P_0, P_2, BTwedYDgAPeOkbElwmbjuUDFVFEW.xTjkCcCCRamqzSbewBpYkakCcxngA.Approximate);
		}
		pEffNfIBDxbaZnAzVATwsTJJMUiPA(P_1, P_3, BTwedYDgAPeOkbElwmbjuUDFVFEW.xTjkCcCCRamqzSbewBpYkakCcxngA.Exact);
		pEffNfIBDxbaZnAzVATwsTJJMUiPA(P_1, P_3, BTwedYDgAPeOkbElwmbjuUDFVFEW.xTjkCcCCRamqzSbewBpYkakCcxngA.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			jsGXYXRZOYjvYoskDsmyuZXsNuTg jsGXYXRZOYjvYoskDsmyuZXsNuTg2 = P_3[i];
			if (jsGXYXRZOYjvYoskDsmyuZXsNuTg2 != null && jsGXYXRZOYjvYoskDsmyuZXsNuTg2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = MmxodsrmOiUKXUMHodAmedjEcNhl(P_3);
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = UbEjOOwcmutgEdaVZEjDKHBzdueV();
				IPtDzgWCKdaCEkXRiaTuIasMalIfA.AFCfcgKARzPvVzDJlmyfjcPzcnPcA(jsGXYXRZOYjvYoskDsmyuZXsNuTg2);
			}
		}
		P_3.Sort(jsGXYXRZOYjvYoskDsmyuZXsNuTg.XIfwHzCsgDLxZKhGbHdZmPmOrszx);
	}

	private void SzJgeczwuGgxPMURACAtxwrcKxmT(List<jsGXYXRZOYjvYoskDsmyuZXsNuTg> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (i != P_1 && P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == P_2)
			{
				P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = -1;
			}
		}
	}

	private bool MNrckLOcxfJNfImNgslyQseODSSy(List<jsGXYXRZOYjvYoskDsmyuZXsNuTg> P_0, int P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == P_1)
			{
				return false;
			}
		}
		return true;
	}

	private int MmxodsrmOiUKXUMHodAmedjEcNhl(List<jsGXYXRZOYjvYoskDsmyuZXsNuTg> P_0)
	{
		int num = 0;
		while (true)
		{
			bool flag = false;
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == num)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				break;
			}
			num++;
		}
		return num;
	}

	private bool JpgFDUTRfOLVvCTXDuHQpivsWbap(List<jsGXYXRZOYjvYoskDsmyuZXsNuTg> P_0, int P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void KXNwqaDTWormjvhwlDzcPQfoArAG(int P_0, List<jsGXYXRZOYjvYoskDsmyuZXsNuTg> P_1, int P_2, List<jsGXYXRZOYjvYoskDsmyuZXsNuTg> P_3, BTwedYDgAPeOkbElwmbjuUDFVFEW.xTjkCcCCRamqzSbewBpYkakCcxngA P_4)
	{
		int num = ((P_4 != BTwedYDgAPeOkbElwmbjuUDFVFEW.xTjkCcCCRamqzSbewBpYkakCcxngA.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			jsGXYXRZOYjvYoskDsmyuZXsNuTg jsGXYXRZOYjvYoskDsmyuZXsNuTg2 = P_1[i];
			if (jsGXYXRZOYjvYoskDsmyuZXsNuTg2 == null || jsGXYXRZOYjvYoskDsmyuZXsNuTg2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				jsGXYXRZOYjvYoskDsmyuZXsNuTg jsGXYXRZOYjvYoskDsmyuZXsNuTg3 = P_3[j];
				if (jsGXYXRZOYjvYoskDsmyuZXsNuTg3 != null && !JpgFDUTRfOLVvCTXDuHQpivsWbap(P_1, jsGXYXRZOYjvYoskDsmyuZXsNuTg3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && jsGXYXRZOYjvYoskDsmyuZXsNuTg2.ZtNHttTjyIcdePcwNgGNqUfNUoio(jsGXYXRZOYjvYoskDsmyuZXsNuTg3) >= num)
				{
					jsGXYXRZOYjvYoskDsmyuZXsNuTg2.DkcLlrceLEqSWviIkoVnDeHCqmpR(jsGXYXRZOYjvYoskDsmyuZXsNuTg3);
					IPtDzgWCKdaCEkXRiaTuIasMalIfA.AFCfcgKARzPvVzDJlmyfjcPzcnPcA(jsGXYXRZOYjvYoskDsmyuZXsNuTg2);
				}
			}
		}
	}

	private void pEffNfIBDxbaZnAzVATwsTJJMUiPA(int P_0, List<jsGXYXRZOYjvYoskDsmyuZXsNuTg> P_1, BTwedYDgAPeOkbElwmbjuUDFVFEW.xTjkCcCCRamqzSbewBpYkakCcxngA P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			jsGXYXRZOYjvYoskDsmyuZXsNuTg jsGXYXRZOYjvYoskDsmyuZXsNuTg2 = P_1[i];
			if (jsGXYXRZOYjvYoskDsmyuZXsNuTg2 == null || jsGXYXRZOYjvYoskDsmyuZXsNuTg2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			BTwedYDgAPeOkbElwmbjuUDFVFEW.ZpLLNNCudyfFGzcLLZTrilnVAEuP zpLLNNCudyfFGzcLLZTrilnVAEuP = null;
			foreach (BTwedYDgAPeOkbElwmbjuUDFVFEW.ZpLLNNCudyfFGzcLLZTrilnVAEuP item in IPtDzgWCKdaCEkXRiaTuIasMalIfA.FSsTeZhILfhlpgbXDmoaCvRGexcSb(jsGXYXRZOYjvYoskDsmyuZXsNuTg2, P_2))
			{
				if (!JpgFDUTRfOLVvCTXDuHQpivsWbap(P_1, item.CUeniocvfSBpmuKEBqaYoXCdMnwn) && item.GhCWFoKIsJQuzaVUzpgXMOjtRqNs >= 0)
				{
					zpLLNNCudyfFGzcLLZTrilnVAEuP = item;
					break;
				}
			}
			if (zpLLNNCudyfFGzcLLZTrilnVAEuP != null)
			{
				int num = zpLLNNCudyfFGzcLLZTrilnVAEuP.GhCWFoKIsJQuzaVUzpgXMOjtRqNs;
				if (!MNrckLOcxfJNfImNgslyQseODSSy(P_1, num))
				{
					num = (zpLLNNCudyfFGzcLLZTrilnVAEuP.GhCWFoKIsJQuzaVUzpgXMOjtRqNs = MmxodsrmOiUKXUMHodAmedjEcNhl(P_1));
				}
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				jsGXYXRZOYjvYoskDsmyuZXsNuTg2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = zpLLNNCudyfFGzcLLZTrilnVAEuP.CUeniocvfSBpmuKEBqaYoXCdMnwn;
				IPtDzgWCKdaCEkXRiaTuIasMalIfA.AFCfcgKARzPvVzDJlmyfjcPzcnPcA(jsGXYXRZOYjvYoskDsmyuZXsNuTg2);
			}
		}
	}

	private void FmaspqBJHcKLzJlvRNfAgEhRnTaB()
	{
		HcofNKEvdjimRbWaruZzwLCwOCmWA.XdfPSlIpInCXIHZJkyXCMBJMiYBhA();
		IList<sFFXXFtEebhJcIFEaMaPQTQrWwKC> list = MQhVvAOkbJItAxHOggzurjkCWlsI();
		if (TpLNAjOdpdTZdtPloHNeQDbrHalj(list))
		{
			OUXbahuqZtNeJIcaaPmwLOckLzRR(list);
		}
		TFFNLmvLCOjRvToRWaifwEZZUqpx = false;
	}

	private bool TpLNAjOdpdTZdtPloHNeQDbrHalj(IList<sFFXXFtEebhJcIFEaMaPQTQrWwKC> P_0)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && !KRKAXAgYCOmiwQFSWFGBCNgNnSMZ(P_0[i].iNcbXhrkRtshEZzrzCiIatjPlhwT))
			{
				return true;
			}
		}
		int count2 = GFHbUyVNCdiRcicisvCGPpQzSAvIA.Count;
		for (int j = 0; j < count2; j++)
		{
			if (GFHbUyVNCdiRcicisvCGPpQzSAvIA[j] != null && !qrWcPfZbroHIzknrHErYkaWvdnox(P_0, GFHbUyVNCdiRcicisvCGPpQzSAvIA[j].jIpLVYbvAPBlNnuxIOBWDLADNEcW))
			{
				return true;
			}
		}
		return false;
	}

	private bool KRKAXAgYCOmiwQFSWFGBCNgNnSMZ(Guid P_0)
	{
		int count = GFHbUyVNCdiRcicisvCGPpQzSAvIA.Count;
		for (int i = 0; i < count; i++)
		{
			if (GFHbUyVNCdiRcicisvCGPpQzSAvIA[i] != null && GFHbUyVNCdiRcicisvCGPpQzSAvIA[i].jIpLVYbvAPBlNnuxIOBWDLADNEcW == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool qrWcPfZbroHIzknrHErYkaWvdnox(IList<sFFXXFtEebhJcIFEaMaPQTQrWwKC> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].iNcbXhrkRtshEZzrzCiIatjPlhwT == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void uRhwysdnuBCKEsMfMIabCqlfLwTQ(List<jsGXYXRZOYjvYoskDsmyuZXsNuTg> P_0, List<jsGXYXRZOYjvYoskDsmyuZXsNuTg> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			jsGXYXRZOYjvYoskDsmyuZXsNuTg jsGXYXRZOYjvYoskDsmyuZXsNuTg2 = P_0[i];
			if (jsGXYXRZOYjvYoskDsmyuZXsNuTg2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					jsGXYXRZOYjvYoskDsmyuZXsNuTg jsGXYXRZOYjvYoskDsmyuZXsNuTg3 = P_1[j];
					if (jsGXYXRZOYjvYoskDsmyuZXsNuTg3 != null && jsGXYXRZOYjvYoskDsmyuZXsNuTg2.jIpLVYbvAPBlNnuxIOBWDLADNEcW == jsGXYXRZOYjvYoskDsmyuZXsNuTg3.jIpLVYbvAPBlNnuxIOBWDLADNEcW)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				bcJUQLgeqzMyKKxfZyuZrCJuMPbe(P_0[i], P_2);
			}
		}
	}

	private void bcJUQLgeqzMyKKxfZyuZrCJuMPbe(jsGXYXRZOYjvYoskDsmyuZXsNuTg P_0, bool P_1)
	{
		if (P_1)
		{
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0.ToBridgedController());
			}
		}
		else if (_DeviceDisconnectedEvent != null)
		{
			_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
		}
	}
}
