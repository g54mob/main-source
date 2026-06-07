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

internal class ecODeNRfSOumSuvMKclWjlhGLatX : PlatformInputManager
{
	private class MhvLrHXULSoIeHiRVHyHsfanHcMD : IInputManagerJoystick, IInputManagerJoystickPublic, IDisposable
	{
		private int MdjEVLtomDUEgiFYnYmqrSmkhwHV;

		private int GJbgvozKIXYsKUguoVQFBzTwKTnt;

		public Guid SiYFIeypQoUDaHqEQrHEbidsKDBK;

		public string DUxAiXzGLNIexMkvQgKBWOowiFZkA;

		public ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB QCaMzipLMuNtmcAObmOdJqTYgoaHA;

		public string KPSCzZiLzPfrVitNNZmZDJFifGkLA;

		public string hOfiWNdKvXmAIyvGgEKLOkkOnAuO;

		public Guid AGMbYadrEXvuJSszSAkWPmcSQvvk;

		public PidVid zHwWqUogezXDsjIyFdcrfCXUuaJl;

		public Guid FWbsFdJlfvOyeTlhTpLyKjKwkLAf;

		public int DgqaFVztEAeGWlemcsArrPEYjCleA;

		public int FYmISydcrrzrCfggHpGFcIMiAAeq;

		public int haNziUbodkULZbgeBWhYaxYoNIuk;

		public int YjYEZgaHRGVyIhkKHnQCsUVUxyGFA;

		public int yNyyAgpEgvNgxVpAhoBAxbVINgoV;

		public int ZBwNjRPvYREecPVlcDsPFssEHEZT;

		public bool VIodFJCxJmhnLmaLGSXtBgBlWEQDA;

		public int CExvnxqdclssdFtbVjynorJecSPl;

		private float[] VVUADDqUEOnBSQFiNgDdzPnyVWub;

		private float[] BBxkzORrIcGsJkwwBecoMLAorVMK;

		private bool[] sTAFhVgbsODytFrLpKKCgCsWxfTLA;

		private HardwareJoystickMap_InputManager kRiBViIfYdVHzmiRVcAiKCIUvhJw;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ZrwcOEEvBBGSxYFZqctcTjvOAOdHb;

		private bool FAlEdcZUcUyHxxTLmHxplHIPSWSB;

		private bool zQlbrcIGDsmkHgCzgdGuJLOddShr;

		[CompilerGenerated]
		private Controller.Extension RQTMnjJbdwzorpkNvndnSOCIwHBi;

		private bool XrnxsqWiYzZlQvCSckZdeqmdYtGc;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return MdjEVLtomDUEgiFYnYmqrSmkhwHV;
			}
			set
			{
				MdjEVLtomDUEgiFYnYmqrSmkhwHV = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return GJbgvozKIXYsKUguoVQFBzTwKTnt;
			}
			set
			{
				GJbgvozKIXYsKUguoVQFBzTwKTnt = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (!(DUxAiXzGLNIexMkvQgKBWOowiFZkA != "Unknown Controller"))
				{
					return hOfiWNdKvXmAIyvGgEKLOkkOnAuO;
				}
				return DUxAiXzGLNIexMkvQgKBWOowiFZkA;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (GJbgvozKIXYsKUguoVQFBzTwKTnt < 0)
				{
					return null;
				}
				return GJbgvozKIXYsKUguoVQFBzTwKTnt;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => AGMbYadrEXvuJSszSAkWPmcSQvvk;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid
		{
			get
			{
				if (QCaMzipLMuNtmcAObmOdJqTYgoaHA == null)
				{
					return Guid.Empty;
				}
				return QCaMzipLMuNtmcAObmOdJqTYgoaHA.rtwgSSQDZHJFgmonHcmFtqRJgOGHA;
			}
		}

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			[CompilerGenerated]
			get
			{
				return RQTMnjJbdwzorpkNvndnSOCIwHBi;
			}
			[CompilerGenerated]
			set
			{
				RQTMnjJbdwzorpkNvndnSOCIwHBi = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			if (VIodFJCxJmhnLmaLGSXtBgBlWEQDA)
			{
				QCaMzipLMuNtmcAObmOdJqTYgoaHA.vBijsFMkXbkPYFPndmHTrFxmEoef(motorIndex, amount, false);
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
			if (VIodFJCxJmhnLmaLGSXtBgBlWEQDA)
			{
				QCaMzipLMuNtmcAObmOdJqTYgoaHA.hGuKUXmzEOtCddJXqEGMttyATqkU();
			}
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public MhvLrHXULSoIeHiRVHyHsfanHcMD(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_0)
		{
			ZrwcOEEvBBGSxYFZqctcTjvOAOdHb = P_0;
			GJbgvozKIXYsKUguoVQFBzTwKTnt = -1;
			MdjEVLtomDUEgiFYnYmqrSmkhwHV = -1;
		}

		public void fkUpzyDHggcjdMhIjXWtJmBxfEbD()
		{
			FWbsFdJlfvOyeTlhTpLyKjKwkLAf = MiscTools.CreateGuidHashSHA1(hOfiWNdKvXmAIyvGgEKLOkkOnAuO + zHwWqUogezXDsjIyFdcrfCXUuaJl.ToProductGuid().ToString());
			FYmISydcrrzrCfggHpGFcIMiAAeq = YjYEZgaHRGVyIhkKHnQCsUVUxyGFA;
			haNziUbodkULZbgeBWhYaxYoNIuk = yNyyAgpEgvNgxVpAhoBAxbVINgoV + ZBwNjRPvYREecPVlcDsPFssEHEZT * 8;
			QZseYjzrAgbspjnklhKzGMFkGzCLB();
			SiYFIeypQoUDaHqEQrHEbidsKDBK = kRiBViIfYdVHzmiRVcAiKCIUvhJw.hardwareMapIdentifier.guid;
			DUxAiXzGLNIexMkvQgKBWOowiFZkA = kRiBViIfYdVHzmiRVcAiKCIUvhJw.controllerName;
			FAlEdcZUcUyHxxTLmHxplHIPSWSB = SiYFIeypQoUDaHqEQrHEbidsKDBK == Guid.Empty;
			VVUADDqUEOnBSQFiNgDdzPnyVWub = new float[FYmISydcrrzrCfggHpGFcIMiAAeq];
			BBxkzORrIcGsJkwwBecoMLAorVMK = new float[haNziUbodkULZbgeBWhYaxYoNIuk];
			sTAFhVgbsODytFrLpKKCgCsWxfTLA = new bool[haNziUbodkULZbgeBWhYaxYoNIuk];
			if (haNziUbodkULZbgeBWhYaxYoNIuk > 0)
			{
				HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)kRiBViIfYdVHzmiRVcAiKCIUvhJw.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						sTAFhVgbsODytFrLpKKCgCsWxfTLA[i] = buttons_orig[i].buttonInfo.isPressureSensitive;
					}
				}
			}
			Update();
		}

		public void eDJbiTsXJENDIWpYkyGnBfvLGieu(MhvLrHXULSoIeHiRVHyHsfanHcMD P_0)
		{
			if (P_0 != null)
			{
				GJbgvozKIXYsKUguoVQFBzTwKTnt = P_0.GJbgvozKIXYsKUguoVQFBzTwKTnt;
				MdjEVLtomDUEgiFYnYmqrSmkhwHV = P_0.MdjEVLtomDUEgiFYnYmqrSmkhwHV;
				for (int i = 0; i < MathTools.Min(BBxkzORrIcGsJkwwBecoMLAorVMK.Length, P_0.BBxkzORrIcGsJkwwBecoMLAorVMK.Length); i++)
				{
					BBxkzORrIcGsJkwwBecoMLAorVMK[i] = P_0.BBxkzORrIcGsJkwwBecoMLAorVMK[i];
				}
				for (int j = 0; j < MathTools.Min(sTAFhVgbsODytFrLpKKCgCsWxfTLA.Length, P_0.sTAFhVgbsODytFrLpKKCgCsWxfTLA.Length); j++)
				{
					sTAFhVgbsODytFrLpKKCgCsWxfTLA[j] = P_0.sTAFhVgbsODytFrLpKKCgCsWxfTLA[j];
				}
				for (int k = 0; k < MathTools.Min(VVUADDqUEOnBSQFiNgDdzPnyVWub.Length, P_0.VVUADDqUEOnBSQFiNgDdzPnyVWub.Length); k++)
				{
					VVUADDqUEOnBSQFiNgDdzPnyVWub[k] = P_0.VVUADDqUEOnBSQFiNgDdzPnyVWub[k];
				}
				zQlbrcIGDsmkHgCzgdGuJLOddShr = P_0.zQlbrcIGDsmkHgCzgdGuJLOddShr;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			uLYQBuZhlLtigBWDehrPRqNYzxN();
			mdFVXrJtaEyHzNCKRkDILjrYFWJcA();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (FYmISydcrrzrCfggHpGFcIMiAAeq != dataUpdater.axisCount || haNziUbodkULZbgeBWhYaxYoNIuk != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < FYmISydcrrzrCfggHpGFcIMiAAeq; i++)
			{
				dataUpdater.axisValues[i] = VVUADDqUEOnBSQFiNgDdzPnyVWub[i];
			}
			for (int j = 0; j < haNziUbodkULZbgeBWhYaxYoNIuk; j++)
			{
				if (sTAFhVgbsODytFrLpKKCgCsWxfTLA[j])
				{
					dataUpdater.buttonPressureValues[j] = BBxkzORrIcGsJkwwBecoMLAorVMK[j];
				}
				else
				{
					dataUpdater.buttonValues[j] = BBxkzORrIcGsJkwwBecoMLAorVMK[j] > 0f;
				}
			}
			if (zQlbrcIGDsmkHgCzgdGuJLOddShr && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int wHudIVFuwGWjqsHgPdbXIqLMhexMA(MhvLrHXULSoIeHiRVHyHsfanHcMD P_0)
		{
			if (P_0.MdjEVLtomDUEgiFYnYmqrSmkhwHV == MdjEVLtomDUEgiFYnYmqrSmkhwHV)
			{
				return 2;
			}
			if (YjYEZgaHRGVyIhkKHnQCsUVUxyGFA != P_0.YjYEZgaHRGVyIhkKHnQCsUVUxyGFA)
			{
				return 0;
			}
			if (yNyyAgpEgvNgxVpAhoBAxbVINgoV != P_0.yNyyAgpEgvNgxVpAhoBAxbVINgoV)
			{
				return 0;
			}
			if (ZBwNjRPvYREecPVlcDsPFssEHEZT != P_0.ZBwNjRPvYREecPVlcDsPFssEHEZT)
			{
				return 0;
			}
			if (P_0.AGMbYadrEXvuJSszSAkWPmcSQvvk == AGMbYadrEXvuJSszSAkWPmcSQvvk)
			{
				return 2;
			}
			if (P_0.FWbsFdJlfvOyeTlhTpLyKjKwkLAf == FWbsFdJlfvOyeTlhTpLyKjKwkLAf)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo nRBrpfRQXGzPpfwRLNeSEKPszXFf()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			hENQiUGLwafGIJVCgnxymGXQDqNeb(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			ETxZDMhowuaAuUISffCJeaOljGLo(bridgedController);
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
			return new ControllerDisconnectedEventArgs(MdjEVLtomDUEgiFYnYmqrSmkhwHV);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void uLYQBuZhlLtigBWDehrPRqNYzxN()
		{
			if (FYmISydcrrzrCfggHpGFcIMiAAeq <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_WindowsWGI_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)kRiBViIfYdVHzmiRVcAiKCIUvhJw.map).Axes_orig;
			if (axes_orig != null)
			{
				for (int i = 0; i < axes_orig.Length; i++)
				{
					sQIrCvhesDOGArNvFRJIwGhEfQWn(axes_orig[i], i);
				}
			}
		}

		private void mdFVXrJtaEyHzNCKRkDILjrYFWJcA()
		{
			if (haNziUbodkULZbgeBWhYaxYoNIuk <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)kRiBViIfYdVHzmiRVcAiKCIUvhJw.map).Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					bYhEKfOOOdFQydyuLMALIlugkFuFb(buttons_orig[i], i);
				}
			}
		}

		private void sQIrCvhesDOGArNvFRJIwGhEfQWn(HardwareJoystickMap.Platform_WindowsWGI_Base.Axis P_0, int P_1)
		{
			if (P_1 >= FYmISydcrrzrCfggHpGFcIMiAAeq)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			VVUADDqUEOnBSQFiNgDdzPnyVWub[P_1] = voiPAgGwgsaZXNDUmxAkpoFwiZal(P_0);
			if (!zQlbrcIGDsmkHgCzgdGuJLOddShr && VVUADDqUEOnBSQFiNgDdzPnyVWub[P_1] != 0f)
			{
				zQlbrcIGDsmkHgCzgdGuJLOddShr = true;
			}
		}

		private void bYhEKfOOOdFQydyuLMALIlugkFuFb(HardwareJoystickMap.Platform_WindowsWGI_Base.Button P_0, int P_1)
		{
			if (P_1 >= haNziUbodkULZbgeBWhYaxYoNIuk)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			BBxkzORrIcGsJkwwBecoMLAorVMK[P_1] = fCihKIWlaORBaWxBukmMtpoDCdQS(P_0);
			if (!zQlbrcIGDsmkHgCzgdGuJLOddShr && BBxkzORrIcGsJkwwBecoMLAorVMK[P_1] != 0f)
			{
				zQlbrcIGDsmkHgCzgdGuJLOddShr = true;
			}
		}

		private float voiPAgGwgsaZXNDUmxAkpoFwiZal(HardwareJoystickMap.Platform_WindowsWGI_Base.Axis P_0)
		{
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0)
				{
					return 0f;
				}
				return CTsPLRnxFxUkwXrQpewCyoijtzqR(sourceAxis);
			}
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= yNyyAgpEgvNgxVpAhoBAxbVINgoV || sourceButton >= 256)
				{
					return 0f;
				}
				if (!QCaMzipLMuNtmcAObmOdJqTYgoaHA.dzwHensTQSYfXgBQnJjMmgaiBEeg(sourceButton))
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
				if (sourceHat < 0 || sourceHat >= ZBwNjRPvYREecPVlcDsPFssEHEZT || sourceHat >= 4)
				{
					return 0f;
				}
				int num = QCaMzipLMuNtmcAObmOdJqTYgoaHA.qzXbjwVLbEECBKQNVxFUgzxFaKpfA(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = lqtRbuCJBJYVLGHmCmtYLwkqaHqX(num, AxisDirection.Horizontal);
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
					num2 = lqtRbuCJBJYVLGHmCmtYLwkqaHqX(num, AxisDirection.Vertical);
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

		private float CTsPLRnxFxUkwXrQpewCyoijtzqR(int P_0)
		{
			if (P_0 < 0 || P_0 >= QCaMzipLMuNtmcAObmOdJqTYgoaHA.sNWXwBMkdbMEkwbjIxZRonIRGVYk)
			{
				return 0f;
			}
			return QCaMzipLMuNtmcAObmOdJqTYgoaHA.HaXYVynvbKXUzBvUQsvmxYIXGlbc(P_0);
		}

		private float fCihKIWlaORBaWxBukmMtpoDCdQS(HardwareJoystickMap.Platform_WindowsWGI_Base.Button P_0)
		{
			if (P_0.sourceType == 0)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (QCaMzipLMuNtmcAObmOdJqTYgoaHA.dzwHensTQSYfXgBQnJjMmgaiBEeg(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!QCaMzipLMuNtmcAObmOdJqTYgoaHA.dzwHensTQSYfXgBQnJjMmgaiBEeg(P_0.requiredButtons[j]))
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
				if (sourceButton < 0 || sourceButton >= yNyyAgpEgvNgxVpAhoBAxbVINgoV || sourceButton >= 256)
				{
					return 0f;
				}
				if (!QCaMzipLMuNtmcAObmOdJqTYgoaHA.dzwHensTQSYfXgBQnJjMmgaiBEeg(sourceButton))
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
				float num = CTsPLRnxFxUkwXrQpewCyoijtzqR(sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= ZBwNjRPvYREecPVlcDsPFssEHEZT || sourceHat >= 4)
				{
					return 0f;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return RMnuBvoIQpmVCJLGLuoHvfEoJesl(QCaMzipLMuNtmcAObmOdJqTYgoaHA.qzXbjwVLbEECBKQNVxFUgzxFaKpfA(sourceHat), 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return RMnuBvoIQpmVCJLGLuoHvfEoJesl(QCaMzipLMuNtmcAObmOdJqTYgoaHA.qzXbjwVLbEECBKQNVxFUgzxFaKpfA(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return RMnuBvoIQpmVCJLGLuoHvfEoJesl(QCaMzipLMuNtmcAObmOdJqTYgoaHA.qzXbjwVLbEECBKQNVxFUgzxFaKpfA(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return RMnuBvoIQpmVCJLGLuoHvfEoJesl(QCaMzipLMuNtmcAObmOdJqTYgoaHA.qzXbjwVLbEECBKQNVxFUgzxFaKpfA(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return RMnuBvoIQpmVCJLGLuoHvfEoJesl(QCaMzipLMuNtmcAObmOdJqTYgoaHA.qzXbjwVLbEECBKQNVxFUgzxFaKpfA(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return RMnuBvoIQpmVCJLGLuoHvfEoJesl(QCaMzipLMuNtmcAObmOdJqTYgoaHA.qzXbjwVLbEECBKQNVxFUgzxFaKpfA(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return RMnuBvoIQpmVCJLGLuoHvfEoJesl(QCaMzipLMuNtmcAObmOdJqTYgoaHA.qzXbjwVLbEECBKQNVxFUgzxFaKpfA(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return RMnuBvoIQpmVCJLGLuoHvfEoJesl(QCaMzipLMuNtmcAObmOdJqTYgoaHA.qzXbjwVLbEECBKQNVxFUgzxFaKpfA(sourceHat), 7, P_0.sourceHatType);
				}
			}
			return 0f;
		}

		private float RMnuBvoIQpmVCJLGLuoHvfEoJesl(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (kRiBViIfYdVHzmiRVcAiKCIUvhJw.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float lqtRbuCJBJYVLGHmCmtYLwkqaHqX(int P_0, AxisDirection P_1)
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

		private void QZseYjzrAgbspjnklhKzGMFkGzCLB()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = nRBrpfRQXGzPpfwRLNeSEKPszXFf();
			kRiBViIfYdVHzmiRVcAiKCIUvhJw = ZrwcOEEvBBGSxYFZqctcTjvOAOdHb(bridgedControllerHWInfo);
			bool flag = false;
			bool flag2 = false;
			if (kRiBViIfYdVHzmiRVcAiKCIUvhJw == null || kRiBViIfYdVHzmiRVcAiKCIUvhJw.hardwareMapIdentifier.guid == Consts.joystickGuid_unknownController)
			{
				if (QCaMzipLMuNtmcAObmOdJqTYgoaHA.zoUgRFcJdexsWHLIwmFwFNZKZeDVA)
				{
					bridgedControllerHWInfo.hw_pidVid = new PidVid(4607, 10462);
					bridgedControllerHWInfo.hw_productId = bridgedControllerHWInfo.hw_pidVid.productId;
					bridgedControllerHWInfo.hw_vendorId = bridgedControllerHWInfo.hw_pidVid.vendorId;
					kRiBViIfYdVHzmiRVcAiKCIUvhJw = ZrwcOEEvBBGSxYFZqctcTjvOAOdHb(bridgedControllerHWInfo);
					flag2 = true;
				}
				if (kRiBViIfYdVHzmiRVcAiKCIUvhJw == null || kRiBViIfYdVHzmiRVcAiKCIUvhJw.hardwareMapIdentifier.guid == Consts.joystickGuid_unknownController)
				{
					bridgedControllerHWInfo.hw_pidVid = new PidVid(736, 1118);
					bridgedControllerHWInfo.hw_productId = bridgedControllerHWInfo.hw_pidVid.productId;
					bridgedControllerHWInfo.hw_vendorId = bridgedControllerHWInfo.hw_pidVid.vendorId;
					bridgedControllerHWInfo.definitionMatchTag = string.Empty;
					kRiBViIfYdVHzmiRVcAiKCIUvhJw = ZrwcOEEvBBGSxYFZqctcTjvOAOdHb(bridgedControllerHWInfo);
					flag = true;
				}
			}
			if (kRiBViIfYdVHzmiRVcAiKCIUvhJw == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (flag)
			{
				string text = string.Format("{0}:{1}", QCaMzipLMuNtmcAObmOdJqTYgoaHA.KvbuNFFMxjNezLIJrEANFEvNotff.vendorId.ToString("x4"), QCaMzipLMuNtmcAObmOdJqTYgoaHA.KvbuNFFMxjNezLIJrEANFEvNotff.productId.ToString("x4"));
				string key = LocalizationManager.AppendToKeyAsPath("windows_gaming_input_gamepad", text);
				kRiBViIfYdVHzmiRVcAiKCIUvhJw.deviceLocalizationInfo.InsertParentKey(0, key);
				kRiBViIfYdVHzmiRVcAiKCIUvhJw.deviceLocalizationInfo.InsertParentKey(1, "windows_gaming_input_gamepad");
				kRiBViIfYdVHzmiRVcAiKCIUvhJw.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text}]";
			}
			else if (QCaMzipLMuNtmcAObmOdJqTYgoaHA.zoUgRFcJdexsWHLIwmFwFNZKZeDVA && (flag2 || kRiBViIfYdVHzmiRVcAiKCIUvhJw.hardwareMapIdentifier.guid == Consts.joystickGuid_steamController))
			{
				string text2 = string.Format("{0}:{1}", QCaMzipLMuNtmcAObmOdJqTYgoaHA.KvbuNFFMxjNezLIJrEANFEvNotff.vendorId.ToString("x4"), QCaMzipLMuNtmcAObmOdJqTYgoaHA.KvbuNFFMxjNezLIJrEANFEvNotff.productId.ToString("x4"));
				string key2 = LocalizationManager.AppendToKeyAsPath((kRiBViIfYdVHzmiRVcAiKCIUvhJw.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(kRiBViIfYdVHzmiRVcAiKCIUvhJw.deviceLocalizationInfo.parentKeys[0])) ? kRiBViIfYdVHzmiRVcAiKCIUvhJw.deviceLocalizationInfo.parentKeys[0] : "steam_controller", text2);
				kRiBViIfYdVHzmiRVcAiKCIUvhJw.deviceLocalizationInfo.InsertParentKey(0, key2);
				kRiBViIfYdVHzmiRVcAiKCIUvhJw.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text2}]";
			}
			FYmISydcrrzrCfggHpGFcIMiAAeq = kRiBViIfYdVHzmiRVcAiKCIUvhJw.axisCount;
			haNziUbodkULZbgeBWhYaxYoNIuk = kRiBViIfYdVHzmiRVcAiKCIUvhJw.buttonCount;
		}

		private string YhQnxfyQBPAHYVSRwHdYSBPyvlQy()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.WindowsGamingInput}{QCaMzipLMuNtmcAObmOdJqTYgoaHA.kcmwoUABetcuUVVgqCNjvfFLGUwy}{hOfiWNdKvXmAIyvGgEKLOkkOnAuO}{zHwWqUogezXDsjIyFdcrfCXUuaJl.ToString()}");
		}

		private void hENQiUGLwafGIJVCgnxymGXQDqNeb(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.WindowsGamingInput;
			P_0.inputSource = QCaMzipLMuNtmcAObmOdJqTYgoaHA.CifiuGreHfGsaeCpTcekAvNgNxLbB;
			P_0.deviceType = (ControlDeviceType)QCaMzipLMuNtmcAObmOdJqTYgoaHA.kcmwoUABetcuUVVgqCNjvfFLGUwy;
			P_0.hardwareIdentifier = YhQnxfyQBPAHYVSRwHdYSBPyvlQy();
			P_0.hardwareAxisCount = YjYEZgaHRGVyIhkKHnQCsUVUxyGFA;
			P_0.hardwareButtonCount = yNyyAgpEgvNgxVpAhoBAxbVINgoV;
			P_0.hardwareHatCount = ZBwNjRPvYREecPVlcDsPFssEHEZT;
			if (QCaMzipLMuNtmcAObmOdJqTYgoaHA.zoUgRFcJdexsWHLIwmFwFNZKZeDVA)
			{
				P_0.definitionMatchTag = "[STEAMCONFIGURED]";
			}
			P_0.hw_productName = hOfiWNdKvXmAIyvGgEKLOkkOnAuO;
			P_0.hw_deviceGuid = AGMbYadrEXvuJSszSAkWPmcSQvvk;
			P_0.hw_productId = zHwWqUogezXDsjIyFdcrfCXUuaJl.productId;
			P_0.hw_vendorId = zHwWqUogezXDsjIyFdcrfCXUuaJl.vendorId;
			P_0.hw_pidVid = zHwWqUogezXDsjIyFdcrfCXUuaJl;
			P_0.hw_isBluetoothDevice = false;
			P_0.hw_bluetoothDeviceName = hOfiWNdKvXmAIyvGgEKLOkkOnAuO;
			P_0.hw_supportsVibration = VIodFJCxJmhnLmaLGSXtBgBlWEQDA;
			P_0.hw_localVibrationMotorCount = CExvnxqdclssdFtbVjynorJecSPl;
		}

		private void ETxZDMhowuaAuUISffCJeaOljGLo(BridgedController P_0)
		{
			hENQiUGLwafGIJVCgnxymGXQDqNeb(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = kRiBViIfYdVHzmiRVcAiKCIUvhJw.ToGameHardwareControllerMap();
			P_0.instanceName = KPSCzZiLzPfrVitNNZmZDJFifGkLA;
			P_0.productName = hOfiWNdKvXmAIyvGgEKLOkkOnAuO;
			P_0.axisCount = FYmISydcrrzrCfggHpGFcIMiAAeq;
			P_0.buttonCount = haNziUbodkULZbgeBWhYaxYoNIuk;
			P_0.isButtonPressureSensitive = new bool[haNziUbodkULZbgeBWhYaxYoNIuk];
			Array.Copy(sTAFhVgbsODytFrLpKKCgCsWxfTLA, P_0.isButtonPressureSensitive, haNziUbodkULZbgeBWhYaxYoNIuk);
			P_0.unknownControllerHats = nkmhdCFkrOtmldlkIErUZTVFnpIE();
			P_0.controllerTypeGuid = SiYFIeypQoUDaHqEQrHEbidsKDBK;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void WkPyrQLnCUvjMWfOSjutFPSQkBoC()
		{
			for (int i = 0; i < haNziUbodkULZbgeBWhYaxYoNIuk; i++)
			{
				BBxkzORrIcGsJkwwBecoMLAorVMK[i] = 0f;
			}
			for (int j = 0; j < FYmISydcrrzrCfggHpGFcIMiAAeq; j++)
			{
				VVUADDqUEOnBSQFiNgDdzPnyVWub[j] = 0f;
			}
		}

		private UnknownControllerHat[] nkmhdCFkrOtmldlkIErUZTVFnpIE()
		{
			if (!FAlEdcZUcUyHxxTLmHxplHIPSWSB)
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
			KQHGwicmuUTCXVTBLERhVbZxrIYJ(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void RFFdxTFnHqVKKxCyKcePupovqjkcA()
		{
			try
			{
				KQHGwicmuUTCXVTBLERhVbZxrIYJ(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void KQHGwicmuUTCXVTBLERhVbZxrIYJ(bool P_0)
		{
			if (!XrnxsqWiYzZlQvCSckZdeqmdYtGc)
			{
				if (P_0 && QCaMzipLMuNtmcAObmOdJqTYgoaHA != null)
				{
					QCaMzipLMuNtmcAObmOdJqTYgoaHA.Dispose();
				}
				XrnxsqWiYzZlQvCSckZdeqmdYtGc = true;
			}
		}

		public static int cPOOGJIqwHapBnWljGhFyjQHqDql(MhvLrHXULSoIeHiRVHyHsfanHcMD P_0, MhvLrHXULSoIeHiRVHyHsfanHcMD P_1)
		{
			if (P_0.GJbgvozKIXYsKUguoVQFBzTwKTnt < P_1.GJbgvozKIXYsKUguoVQFBzTwKTnt)
			{
				return -1;
			}
			if (P_0.GJbgvozKIXYsKUguoVQFBzTwKTnt > P_1.GJbgvozKIXYsKUguoVQFBzTwKTnt)
			{
				return 1;
			}
			return 0;
		}

		public static int JwPcSKfyHhfCsXNeayXcBnnYPgqq(MhvLrHXULSoIeHiRVHyHsfanHcMD P_0, MhvLrHXULSoIeHiRVHyHsfanHcMD P_1)
		{
			if (P_0.DgqaFVztEAeGWlemcsArrPEYjCleA < P_1.DgqaFVztEAeGWlemcsArrPEYjCleA)
			{
				return -1;
			}
			if (P_0.DgqaFVztEAeGWlemcsArrPEYjCleA > P_1.DgqaFVztEAeGWlemcsArrPEYjCleA)
			{
				return 1;
			}
			return 0;
		}
	}

	private class uEDHjqJmAXSXqUubisAlcHbKEJDjA
	{
		public enum SSCBrOiGHwwbfpzsaSQAusAJlhcIA
		{
			Exact = 0,
			Approximate = 1
		}

		public class cYsOShOAfuHWWIHDJwwxozBWKoti
		{
			public int vuNalSsAtCdeoaVIDxZShqksorfZ;

			public Guid cBKRCccILfOgPSiMAunfdTJgrbxm;

			public Guid OrWOyhNxmKqXNfbaVbbUjYMKVjtQ;

			public int jSnOJUSqgNjovVOghXsNKPDkwDEg;

			public int SeYJDTXKsucXxxKvVBHGaTtVsNVh;

			public int sjAZffvkmFRqwohQjbASRzTUCNXx;

			public int DpjeNLKskQQMdMeCpTvAZSSrhyGL;

			public int swlpqWerJflcYLHEgImyIoeTwuTnA;

			public int oipNUWUiHOuyYtnclvnsJpRrEljGA;

			public bool SCPAddGUeZlMbuJpKUeqElkyEHyl(MhvLrHXULSoIeHiRVHyHsfanHcMD P_0, SSCBrOiGHwwbfpzsaSQAusAJlhcIA P_1)
			{
				if (SeYJDTXKsucXxxKvVBHGaTtVsNVh != P_0.YjYEZgaHRGVyIhkKHnQCsUVUxyGFA)
				{
					return false;
				}
				if (sjAZffvkmFRqwohQjbASRzTUCNXx != P_0.yNyyAgpEgvNgxVpAhoBAxbVINgoV)
				{
					return false;
				}
				if (DpjeNLKskQQMdMeCpTvAZSSrhyGL != P_0.ZBwNjRPvYREecPVlcDsPFssEHEZT)
				{
					return false;
				}
				if (swlpqWerJflcYLHEgImyIoeTwuTnA != P_0.haNziUbodkULZbgeBWhYaxYoNIuk)
				{
					return false;
				}
				if (oipNUWUiHOuyYtnclvnsJpRrEljGA != P_0.FYmISydcrrzrCfggHpGFcIMiAAeq)
				{
					return false;
				}
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == vuNalSsAtCdeoaVIDxZShqksorfZ)
				{
					return true;
				}
				return P_1 switch
				{
					SSCBrOiGHwwbfpzsaSQAusAJlhcIA.Exact => cBKRCccILfOgPSiMAunfdTJgrbxm == P_0.AGMbYadrEXvuJSszSAkWPmcSQvvk, 
					SSCBrOiGHwwbfpzsaSQAusAJlhcIA.Approximate => OrWOyhNxmKqXNfbaVbbUjYMKVjtQ == P_0.FWbsFdJlfvOyeTlhTpLyKjKwkLAf, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		private sealed class QtRswzbkTCLmIuNrpDauoQHFzVdP : IEnumerable<cYsOShOAfuHWWIHDJwwxozBWKoti>, IEnumerable, IEnumerator<cYsOShOAfuHWWIHDJwwxozBWKoti>, IEnumerator, IDisposable
		{
			private int leVRMRMLEbaUuEHIXsarWNQXAyJt;

			private cYsOShOAfuHWWIHDJwwxozBWKoti UYiZqFkgLJzcXDOmXmXkcuNPtKuW;

			private int JCLwSlXeGEVpwXKtckIFxWidimwN;

			public uEDHjqJmAXSXqUubisAlcHbKEJDjA uzTnogSlUxfOtIcMmSvhbKValaioA;

			private MhvLrHXULSoIeHiRVHyHsfanHcMD qCMnbnOslRxmPcthufOuudjPGllj;

			public MhvLrHXULSoIeHiRVHyHsfanHcMD XxiBdbteIvDeHjsszCLVLgVPhINsA;

			private SSCBrOiGHwwbfpzsaSQAusAJlhcIA RWdNBwYZUUqcXtLCJDSNkjpdHNpw;

			public SSCBrOiGHwwbfpzsaSQAusAJlhcIA gFgQfpEGkUBrkzVVEUeqmmlVgvUeA;

			private int wICPnCfPPnRiVNTTTRzKayvZofst;

			private int geTYgJGQyZDIdjGPGVwpEeEAUXwC;

			cYsOShOAfuHWWIHDJwwxozBWKoti IEnumerator<cYsOShOAfuHWWIHDJwwxozBWKoti>.Current
			{
				[DebuggerHidden]
				get
				{
					return UYiZqFkgLJzcXDOmXmXkcuNPtKuW;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return UYiZqFkgLJzcXDOmXmXkcuNPtKuW;
				}
			}

			[DebuggerHidden]
			public QtRswzbkTCLmIuNrpDauoQHFzVdP(int P_0)
			{
				leVRMRMLEbaUuEHIXsarWNQXAyJt = P_0;
				JCLwSlXeGEVpwXKtckIFxWidimwN = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				leVRMRMLEbaUuEHIXsarWNQXAyJt = -2;
			}

			private bool MoveNext()
			{
				int num = leVRMRMLEbaUuEHIXsarWNQXAyJt;
				uEDHjqJmAXSXqUubisAlcHbKEJDjA uEDHjqJmAXSXqUubisAlcHbKEJDjA2 = uzTnogSlUxfOtIcMmSvhbKValaioA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					leVRMRMLEbaUuEHIXsarWNQXAyJt = -1;
					goto IL_0083;
				}
				leVRMRMLEbaUuEHIXsarWNQXAyJt = -1;
				wICPnCfPPnRiVNTTTRzKayvZofst = uEDHjqJmAXSXqUubisAlcHbKEJDjA2.UQfarmiWWCILHktKpwKsfwSjLrtwA.Count;
				geTYgJGQyZDIdjGPGVwpEeEAUXwC = 0;
				goto IL_0093;
				IL_0083:
				geTYgJGQyZDIdjGPGVwpEeEAUXwC++;
				goto IL_0093;
				IL_0093:
				if (geTYgJGQyZDIdjGPGVwpEeEAUXwC < wICPnCfPPnRiVNTTTRzKayvZofst)
				{
					if (uEDHjqJmAXSXqUubisAlcHbKEJDjA2.UQfarmiWWCILHktKpwKsfwSjLrtwA[geTYgJGQyZDIdjGPGVwpEeEAUXwC].SCPAddGUeZlMbuJpKUeqElkyEHyl(qCMnbnOslRxmPcthufOuudjPGllj, RWdNBwYZUUqcXtLCJDSNkjpdHNpw))
					{
						UYiZqFkgLJzcXDOmXmXkcuNPtKuW = uEDHjqJmAXSXqUubisAlcHbKEJDjA2.UQfarmiWWCILHktKpwKsfwSjLrtwA[geTYgJGQyZDIdjGPGVwpEeEAUXwC];
						leVRMRMLEbaUuEHIXsarWNQXAyJt = 1;
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
			IEnumerator<cYsOShOAfuHWWIHDJwwxozBWKoti> IEnumerable<cYsOShOAfuHWWIHDJwwxozBWKoti>.GetEnumerator()
			{
				QtRswzbkTCLmIuNrpDauoQHFzVdP qtRswzbkTCLmIuNrpDauoQHFzVdP;
				if (leVRMRMLEbaUuEHIXsarWNQXAyJt == -2 && JCLwSlXeGEVpwXKtckIFxWidimwN == Environment.CurrentManagedThreadId)
				{
					leVRMRMLEbaUuEHIXsarWNQXAyJt = 0;
					qtRswzbkTCLmIuNrpDauoQHFzVdP = this;
				}
				else
				{
					qtRswzbkTCLmIuNrpDauoQHFzVdP = new QtRswzbkTCLmIuNrpDauoQHFzVdP(0);
					qtRswzbkTCLmIuNrpDauoQHFzVdP.uzTnogSlUxfOtIcMmSvhbKValaioA = uzTnogSlUxfOtIcMmSvhbKValaioA;
				}
				qtRswzbkTCLmIuNrpDauoQHFzVdP.qCMnbnOslRxmPcthufOuudjPGllj = XxiBdbteIvDeHjsszCLVLgVPhINsA;
				qtRswzbkTCLmIuNrpDauoQHFzVdP.RWdNBwYZUUqcXtLCJDSNkjpdHNpw = gFgQfpEGkUBrkzVVEUeqmmlVgvUeA;
				return qtRswzbkTCLmIuNrpDauoQHFzVdP;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<cYsOShOAfuHWWIHDJwwxozBWKoti>)this).GetEnumerator();
			}
		}

		private List<cYsOShOAfuHWWIHDJwwxozBWKoti> UQfarmiWWCILHktKpwKsfwSjLrtwA;

		public uEDHjqJmAXSXqUubisAlcHbKEJDjA()
		{
			UQfarmiWWCILHktKpwKsfwSjLrtwA = new List<cYsOShOAfuHWWIHDJwwxozBWKoti>();
		}

		public void pinlDKCjJfbsVOEDxBBzHttwerWoA(MhvLrHXULSoIeHiRVHyHsfanHcMD P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = UQfarmiWWCILHktKpwKsfwSjLrtwA.Count;
			for (int i = 0; i < count; i++)
			{
				if (UQfarmiWWCILHktKpwKsfwSjLrtwA[i].SCPAddGUeZlMbuJpKUeqElkyEHyl(P_0, SSCBrOiGHwwbfpzsaSQAusAJlhcIA.Exact))
				{
					UQfarmiWWCILHktKpwKsfwSjLrtwA[i].vuNalSsAtCdeoaVIDxZShqksorfZ = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					UQfarmiWWCILHktKpwKsfwSjLrtwA[i].cBKRCccILfOgPSiMAunfdTJgrbxm = P_0.AGMbYadrEXvuJSszSAkWPmcSQvvk;
					UQfarmiWWCILHktKpwKsfwSjLrtwA[i].OrWOyhNxmKqXNfbaVbbUjYMKVjtQ = P_0.FWbsFdJlfvOyeTlhTpLyKjKwkLAf;
					UQfarmiWWCILHktKpwKsfwSjLrtwA[i].jSnOJUSqgNjovVOghXsNKPDkwDEg = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					UQfarmiWWCILHktKpwKsfwSjLrtwA[i].SeYJDTXKsucXxxKvVBHGaTtVsNVh = P_0.YjYEZgaHRGVyIhkKHnQCsUVUxyGFA;
					UQfarmiWWCILHktKpwKsfwSjLrtwA[i].sjAZffvkmFRqwohQjbASRzTUCNXx = P_0.yNyyAgpEgvNgxVpAhoBAxbVINgoV;
					UQfarmiWWCILHktKpwKsfwSjLrtwA[i].DpjeNLKskQQMdMeCpTvAZSSrhyGL = P_0.ZBwNjRPvYREecPVlcDsPFssEHEZT;
					UQfarmiWWCILHktKpwKsfwSjLrtwA[i].swlpqWerJflcYLHEgImyIoeTwuTnA = P_0.haNziUbodkULZbgeBWhYaxYoNIuk;
					UQfarmiWWCILHktKpwKsfwSjLrtwA[i].oipNUWUiHOuyYtnclvnsJpRrEljGA = P_0.FYmISydcrrzrCfggHpGFcIMiAAeq;
					KnBAFAgAsJoBqMLsxCgiAENOcKoCA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.AGMbYadrEXvuJSszSAkWPmcSQvvk, i);
					return;
				}
			}
			UQfarmiWWCILHktKpwKsfwSjLrtwA.Add(new cYsOShOAfuHWWIHDJwwxozBWKoti
			{
				vuNalSsAtCdeoaVIDxZShqksorfZ = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				cBKRCccILfOgPSiMAunfdTJgrbxm = P_0.AGMbYadrEXvuJSszSAkWPmcSQvvk,
				OrWOyhNxmKqXNfbaVbbUjYMKVjtQ = P_0.FWbsFdJlfvOyeTlhTpLyKjKwkLAf,
				jSnOJUSqgNjovVOghXsNKPDkwDEg = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				SeYJDTXKsucXxxKvVBHGaTtVsNVh = P_0.YjYEZgaHRGVyIhkKHnQCsUVUxyGFA,
				sjAZffvkmFRqwohQjbASRzTUCNXx = P_0.yNyyAgpEgvNgxVpAhoBAxbVINgoV,
				DpjeNLKskQQMdMeCpTvAZSSrhyGL = P_0.ZBwNjRPvYREecPVlcDsPFssEHEZT,
				swlpqWerJflcYLHEgImyIoeTwuTnA = P_0.haNziUbodkULZbgeBWhYaxYoNIuk,
				oipNUWUiHOuyYtnclvnsJpRrEljGA = P_0.FYmISydcrrzrCfggHpGFcIMiAAeq
			});
			KnBAFAgAsJoBqMLsxCgiAENOcKoCA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.AGMbYadrEXvuJSszSAkWPmcSQvvk, UQfarmiWWCILHktKpwKsfwSjLrtwA.Count - 1);
		}

		public bool uuttvbWxSKUNANPyqEaPQhLuhZSj(MhvLrHXULSoIeHiRVHyHsfanHcMD P_0, SSCBrOiGHwwbfpzsaSQAusAJlhcIA P_1)
		{
			int count = UQfarmiWWCILHktKpwKsfwSjLrtwA.Count;
			for (int i = 0; i < count; i++)
			{
				if (UQfarmiWWCILHktKpwKsfwSjLrtwA[i].SCPAddGUeZlMbuJpKUeqElkyEHyl(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(QtRswzbkTCLmIuNrpDauoQHFzVdP))]
		public IEnumerable<cYsOShOAfuHWWIHDJwwxozBWKoti> iTLzlGlBHdwlSYXeHNdubjrlrdne(MhvLrHXULSoIeHiRVHyHsfanHcMD P_0, SSCBrOiGHwwbfpzsaSQAusAJlhcIA P_1)
		{
			return new QtRswzbkTCLmIuNrpDauoQHFzVdP(-2)
			{
				uzTnogSlUxfOtIcMmSvhbKValaioA = this,
				XxiBdbteIvDeHjsszCLVLgVPhINsA = P_0,
				gFgQfpEGkUBrkzVVEUeqmmlVgvUeA = P_1
			};
		}

		private void KnBAFAgAsJoBqMLsxCgiAENOcKoCA(int P_0, Guid P_1, int P_2)
		{
			for (int num = UQfarmiWWCILHktKpwKsfwSjLrtwA.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (UQfarmiWWCILHktKpwKsfwSjLrtwA[num].vuNalSsAtCdeoaVIDxZShqksorfZ == P_0 || UQfarmiWWCILHktKpwKsfwSjLrtwA[num].cBKRCccILfOgPSiMAunfdTJgrbxm == P_1))
				{
					UQfarmiWWCILHktKpwKsfwSjLrtwA.RemoveAt(num);
				}
			}
		}
	}

	private const bool CmMlFCWpIFGfLhNGokfiDMyfqnBrB = true;

	private lWKZJkPgmTQhnkksQuDjkWBGqKMN uMBCmafzqtdeZpBibitjNUslWbzL;

	private List<MhvLrHXULSoIeHiRVHyHsfanHcMD> jhiLZANzCpKzeLAwmrwEtjycSpyH;

	private int dnfAYDCuNnjVoowQytkwgobDemOe;

	private uEDHjqJmAXSXqUubisAlcHbKEJDjA xuMcnOULSjZACVIHaFiyQZMVLjZv;

	private bool sTyBIUflUGVOxkADIeRricvCWoyGA;

	private ConfigVars BPhNDPolAiULqzCDbDaIGCYsLBKS;

	private Action<int, ControllerDataUpdater> WIyahoBcUUpfrdIRvnbEocKOXWvmA;

	private PlatformInputManager iLJUucIYQiMvQSMdcuXnnlmBeTcl;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> MQidUOFGFJnKWrqCLfQGCFhfZwRn;

	private readonly Func<int> xKhEeweqieuqYMKPNmhXeAjccgtgc;

	private Func<PidVid, bool> zTDjBDnovObLcbftfIqGpKaNkwjf;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => dnfAYDCuNnjVoowQytkwgobDemOe;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => iLJUucIYQiMvQSMdcuXnnlmBeTcl;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => uMBCmafzqtdeZpBibitjNUslWbzL;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.WindowsGamingInput;

	protected lWKZJkPgmTQhnkksQuDjkWBGqKMN tnpwuIXLragSEKKeGKZJQETRcYfFA => uMBCmafzqtdeZpBibitjNUslWbzL;

	public ecODeNRfSOumSuvMKclWjlhGLatX(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2, Func<PidVid, bool> P_3)
	{
		try
		{
			BPhNDPolAiULqzCDbDaIGCYsLBKS = P_0;
			MQidUOFGFJnKWrqCLfQGCFhfZwRn = P_1;
			xKhEeweqieuqYMKPNmhXeAjccgtgc = P_2;
			zTDjBDnovObLcbftfIqGpKaNkwjf = P_3;
			iLJUucIYQiMvQSMdcuXnnlmBeTcl = this;
			uMBCmafzqtdeZpBibitjNUslWbzL = new lWKZJkPgmTQhnkksQuDjkWBGqKMN(P_0, true, false, false);
			uMBCmafzqtdeZpBibitjNUslWbzL.Rewired_002EInterfaces_002EIInputSource_002EDeviceChangedEvent += SystemDeviceConnected;
			WIyahoBcUUpfrdIRvnbEocKOXWvmA = UpdateControllerData;
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
		xuMcnOULSjZACVIHaFiyQZMVLjZv = new uEDHjqJmAXSXqUubisAlcHbKEJDjA();
		uMBCmafzqtdeZpBibitjNUslWbzL.swMCBZUMKdBIOaZDgDmYMylJSGQx();
		zEYdsqptmxAAyAYwHSHkDEijJOpV();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (uMBCmafzqtdeZpBibitjNUslWbzL != null)
		{
			uMBCmafzqtdeZpBibitjNUslWbzL.Update();
		}
		if (sTyBIUflUGVOxkADIeRricvCWoyGA)
		{
			cMZXtXPUDaeTHiMnxBqxcvwOxnIQ();
		}
		if (uMBCmafzqtdeZpBibitjNUslWbzL != null)
		{
			uMBCmafzqtdeZpBibitjNUslWbzL.UpdateDevices(updateLoop);
		}
		thuJVMRAGQMuzTphbUDHvpMIauDC();
		if (uMBCmafzqtdeZpBibitjNUslWbzL != null)
		{
			uMBCmafzqtdeZpBibitjNUslWbzL.UpdateFinished();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (jhiLZANzCpKzeLAwmrwEtjycSpyH != null)
		{
			int count = jhiLZANzCpKzeLAwmrwEtjycSpyH.Count;
			for (int i = 0; i < count; i++)
			{
				if (jhiLZANzCpKzeLAwmrwEtjycSpyH[i] != null)
				{
					jhiLZANzCpKzeLAwmrwEtjycSpyH[i].Dispose();
				}
			}
		}
		if (uMBCmafzqtdeZpBibitjNUslWbzL != null)
		{
			uMBCmafzqtdeZpBibitjNUslWbzL.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return WIyahoBcUUpfrdIRvnbEocKOXWvmA;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < dnfAYDCuNnjVoowQytkwgobDemOe; i++)
		{
			if (jhiLZANzCpKzeLAwmrwEtjycSpyH[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
			{
				jhiLZANzCpKzeLAwmrwEtjycSpyH[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		sTyBIUflUGVOxkADIeRricvCWoyGA = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		sTyBIUflUGVOxkADIeRricvCWoyGA = true;
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
		return uMBCmafzqtdeZpBibitjNUslWbzL.AoLbDhShPcBqYJRfmJakABrXNheD;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return uMBCmafzqtdeZpBibitjNUslWbzL.TTqDPYLmPMJwnPwgoqJwVoafLeil;
	}

	protected bool mGrsLxCiwNEVmVwbwbutfJawlrIoA(PidVid P_0)
	{
		return zTDjBDnovObLcbftfIqGpKaNkwjf(P_0);
	}

	private void zEYdsqptmxAAyAYwHSHkDEijJOpV()
	{
		jgwotNiLBvSdZdjcwYPwNNMrZfGu(nKWDSmSWzFGBYeKWyBNmcpEADMrnb());
	}

	private void jgwotNiLBvSdZdjcwYPwNNMrZfGu(IList<ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB> P_0)
	{
		int num = 0;
		List<MhvLrHXULSoIeHiRVHyHsfanHcMD> list = jhiLZANzCpKzeLAwmrwEtjycSpyH;
		int num2 = dnfAYDCuNnjVoowQytkwgobDemOe;
		jhiLZANzCpKzeLAwmrwEtjycSpyH = new List<MhvLrHXULSoIeHiRVHyHsfanHcMD>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB zAiBOzjsAnIkPdrPiMzTFAvHaIZzB = P_0[i];
				MhvLrHXULSoIeHiRVHyHsfanHcMD mhvLrHXULSoIeHiRVHyHsfanHcMD = new MhvLrHXULSoIeHiRVHyHsfanHcMD(MQidUOFGFJnKWrqCLfQGCFhfZwRn);
				mhvLrHXULSoIeHiRVHyHsfanHcMD.QCaMzipLMuNtmcAObmOdJqTYgoaHA = zAiBOzjsAnIkPdrPiMzTFAvHaIZzB;
				mhvLrHXULSoIeHiRVHyHsfanHcMD.AGMbYadrEXvuJSszSAkWPmcSQvvk = zAiBOzjsAnIkPdrPiMzTFAvHaIZzB.DlFRWDrCDbleCmLxvwDIeTLMcxrr;
				mhvLrHXULSoIeHiRVHyHsfanHcMD.KPSCzZiLzPfrVitNNZmZDJFifGkLA = zAiBOzjsAnIkPdrPiMzTFAvHaIZzB.uJKQzlBwXskoNbvczHyrFuXXhNEm;
				mhvLrHXULSoIeHiRVHyHsfanHcMD.hOfiWNdKvXmAIyvGgEKLOkkOnAuO = zAiBOzjsAnIkPdrPiMzTFAvHaIZzB.uJKQzlBwXskoNbvczHyrFuXXhNEm;
				mhvLrHXULSoIeHiRVHyHsfanHcMD.zHwWqUogezXDsjIyFdcrfCXUuaJl = zAiBOzjsAnIkPdrPiMzTFAvHaIZzB.KvbuNFFMxjNezLIJrEANFEvNotff;
				mhvLrHXULSoIeHiRVHyHsfanHcMD.DgqaFVztEAeGWlemcsArrPEYjCleA = zAiBOzjsAnIkPdrPiMzTFAvHaIZzB.GJrqIfOKGFRlucbCgiAuyXjuIHbAA;
				mhvLrHXULSoIeHiRVHyHsfanHcMD.YjYEZgaHRGVyIhkKHnQCsUVUxyGFA = zAiBOzjsAnIkPdrPiMzTFAvHaIZzB.sNWXwBMkdbMEkwbjIxZRonIRGVYk;
				mhvLrHXULSoIeHiRVHyHsfanHcMD.yNyyAgpEgvNgxVpAhoBAxbVINgoV = zAiBOzjsAnIkPdrPiMzTFAvHaIZzB.evBvDBCJOLMmnbEVEXHaUUMTlaHk;
				mhvLrHXULSoIeHiRVHyHsfanHcMD.ZBwNjRPvYREecPVlcDsPFssEHEZT = zAiBOzjsAnIkPdrPiMzTFAvHaIZzB.eztnYuFZoBKBRGiIeicZHpTolrzNA;
				mhvLrHXULSoIeHiRVHyHsfanHcMD.VIodFJCxJmhnLmaLGSXtBgBlWEQDA = zAiBOzjsAnIkPdrPiMzTFAvHaIZzB.laigbTcFXtAVzrEWFneZnECFDaABb;
				mhvLrHXULSoIeHiRVHyHsfanHcMD.CExvnxqdclssdFtbVjynorJecSPl = zAiBOzjsAnIkPdrPiMzTFAvHaIZzB.DwatcvDClbquMOZTjJckEGXTeZqfA;
				mhvLrHXULSoIeHiRVHyHsfanHcMD.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension = zAiBOzjsAnIkPdrPiMzTFAvHaIZzB.aIGdrFTKjhGIHCgNdOUtElCnhUCo;
				mhvLrHXULSoIeHiRVHyHsfanHcMD.QCaMzipLMuNtmcAObmOdJqTYgoaHA = zAiBOzjsAnIkPdrPiMzTFAvHaIZzB;
				mhvLrHXULSoIeHiRVHyHsfanHcMD.fkUpzyDHggcjdMhIjXWtJmBxfEbD();
				jhiLZANzCpKzeLAwmrwEtjycSpyH.Add(mhvLrHXULSoIeHiRVHyHsfanHcMD);
				num++;
			}
		}
		dnfAYDCuNnjVoowQytkwgobDemOe = num;
		iPCJLwDhvydFwPImCxYcUNRIiGiT(num2, num, list, jhiLZANzCpKzeLAwmrwEtjycSpyH);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(jhiLZANzCpKzeLAwmrwEtjycSpyH[j]));
			}
		}
		HjQxHQdmYTFrUFvJYHNjUBVgkLUe(list, jhiLZANzCpKzeLAwmrwEtjycSpyH, false);
		HjQxHQdmYTFrUFvJYHNjUBVgkLUe(jhiLZANzCpKzeLAwmrwEtjycSpyH, list, true);
	}

	private void thuJVMRAGQMuzTphbUDHvpMIauDC()
	{
		for (int i = 0; i < dnfAYDCuNnjVoowQytkwgobDemOe; i++)
		{
			jhiLZANzCpKzeLAwmrwEtjycSpyH[i]?.Update();
		}
	}

	private IList<ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB> nKWDSmSWzFGBYeKWyBNmcpEADMrnb()
	{
		return uMBCmafzqtdeZpBibitjNUslWbzL.GetJoysticks<ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB>();
	}

	private void iPCJLwDhvydFwPImCxYcUNRIiGiT(int P_0, int P_1, List<MhvLrHXULSoIeHiRVHyHsfanHcMD> P_2, List<MhvLrHXULSoIeHiRVHyHsfanHcMD> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(MhvLrHXULSoIeHiRVHyHsfanHcMD.JwPcSKfyHhfCsXNeayXcBnnYPgqq);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			hOafbMNTGoVmpKzsvPeoLxBpOCBQ(P_1, P_3, P_0, P_2, uEDHjqJmAXSXqUubisAlcHbKEJDjA.SSCBrOiGHwwbfpzsaSQAusAJlhcIA.Exact);
			hOafbMNTGoVmpKzsvPeoLxBpOCBQ(P_1, P_3, P_0, P_2, uEDHjqJmAXSXqUubisAlcHbKEJDjA.SSCBrOiGHwwbfpzsaSQAusAJlhcIA.Approximate);
		}
		AkCYPBRVSfzpXtjWRipaFrTMWevE(P_1, P_3, uEDHjqJmAXSXqUubisAlcHbKEJDjA.SSCBrOiGHwwbfpzsaSQAusAJlhcIA.Exact);
		AkCYPBRVSfzpXtjWRipaFrTMWevE(P_1, P_3, uEDHjqJmAXSXqUubisAlcHbKEJDjA.SSCBrOiGHwwbfpzsaSQAusAJlhcIA.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			MhvLrHXULSoIeHiRVHyHsfanHcMD mhvLrHXULSoIeHiRVHyHsfanHcMD = P_3[i];
			if (mhvLrHXULSoIeHiRVHyHsfanHcMD != null && mhvLrHXULSoIeHiRVHyHsfanHcMD.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				mhvLrHXULSoIeHiRVHyHsfanHcMD.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = bzGHtIpnMyhHBAxOiJSakxZFeouJA(P_3);
				mhvLrHXULSoIeHiRVHyHsfanHcMD.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = xKhEeweqieuqYMKPNmhXeAjccgtgc();
				xuMcnOULSjZACVIHaFiyQZMVLjZv.pinlDKCjJfbsVOEDxBBzHttwerWoA(mhvLrHXULSoIeHiRVHyHsfanHcMD);
			}
		}
		P_3.Sort(MhvLrHXULSoIeHiRVHyHsfanHcMD.cPOOGJIqwHapBnWljGhFyjQHqDql);
	}

	private void lnghaExtiQaJRriDKhuxnRUhdEhf(List<MhvLrHXULSoIeHiRVHyHsfanHcMD> P_0, int P_1, int P_2)
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

	private bool bOQpjnEwbxVMrfQBkJAyQRUFLWDw(List<MhvLrHXULSoIeHiRVHyHsfanHcMD> P_0, int P_1)
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

	private int bzGHtIpnMyhHBAxOiJSakxZFeouJA(List<MhvLrHXULSoIeHiRVHyHsfanHcMD> P_0)
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

	private bool myHWogPpxAKXvxuLRyQGdPJdvAzh(List<MhvLrHXULSoIeHiRVHyHsfanHcMD> P_0, int P_1)
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

	private void hOafbMNTGoVmpKzsvPeoLxBpOCBQ(int P_0, List<MhvLrHXULSoIeHiRVHyHsfanHcMD> P_1, int P_2, List<MhvLrHXULSoIeHiRVHyHsfanHcMD> P_3, uEDHjqJmAXSXqUubisAlcHbKEJDjA.SSCBrOiGHwwbfpzsaSQAusAJlhcIA P_4)
	{
		int num = ((P_4 != uEDHjqJmAXSXqUubisAlcHbKEJDjA.SSCBrOiGHwwbfpzsaSQAusAJlhcIA.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			MhvLrHXULSoIeHiRVHyHsfanHcMD mhvLrHXULSoIeHiRVHyHsfanHcMD = P_1[i];
			if (mhvLrHXULSoIeHiRVHyHsfanHcMD == null || mhvLrHXULSoIeHiRVHyHsfanHcMD.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				MhvLrHXULSoIeHiRVHyHsfanHcMD mhvLrHXULSoIeHiRVHyHsfanHcMD2 = P_3[j];
				if (mhvLrHXULSoIeHiRVHyHsfanHcMD2 != null && !myHWogPpxAKXvxuLRyQGdPJdvAzh(P_1, mhvLrHXULSoIeHiRVHyHsfanHcMD2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && mhvLrHXULSoIeHiRVHyHsfanHcMD.wHudIVFuwGWjqsHgPdbXIqLMhexMA(mhvLrHXULSoIeHiRVHyHsfanHcMD2) >= num)
				{
					mhvLrHXULSoIeHiRVHyHsfanHcMD.eDJbiTsXJENDIWpYkyGnBfvLGieu(mhvLrHXULSoIeHiRVHyHsfanHcMD2);
					xuMcnOULSjZACVIHaFiyQZMVLjZv.pinlDKCjJfbsVOEDxBBzHttwerWoA(mhvLrHXULSoIeHiRVHyHsfanHcMD);
				}
			}
		}
	}

	private void AkCYPBRVSfzpXtjWRipaFrTMWevE(int P_0, List<MhvLrHXULSoIeHiRVHyHsfanHcMD> P_1, uEDHjqJmAXSXqUubisAlcHbKEJDjA.SSCBrOiGHwwbfpzsaSQAusAJlhcIA P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			MhvLrHXULSoIeHiRVHyHsfanHcMD mhvLrHXULSoIeHiRVHyHsfanHcMD = P_1[i];
			if (mhvLrHXULSoIeHiRVHyHsfanHcMD == null || mhvLrHXULSoIeHiRVHyHsfanHcMD.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			uEDHjqJmAXSXqUubisAlcHbKEJDjA.cYsOShOAfuHWWIHDJwwxozBWKoti cYsOShOAfuHWWIHDJwwxozBWKoti = null;
			foreach (uEDHjqJmAXSXqUubisAlcHbKEJDjA.cYsOShOAfuHWWIHDJwwxozBWKoti item in xuMcnOULSjZACVIHaFiyQZMVLjZv.iTLzlGlBHdwlSYXeHNdubjrlrdne(mhvLrHXULSoIeHiRVHyHsfanHcMD, P_2))
			{
				if (!myHWogPpxAKXvxuLRyQGdPJdvAzh(P_1, item.vuNalSsAtCdeoaVIDxZShqksorfZ) && item.jSnOJUSqgNjovVOghXsNKPDkwDEg >= 0)
				{
					cYsOShOAfuHWWIHDJwwxozBWKoti = item;
					break;
				}
			}
			if (cYsOShOAfuHWWIHDJwwxozBWKoti != null)
			{
				int num = cYsOShOAfuHWWIHDJwwxozBWKoti.jSnOJUSqgNjovVOghXsNKPDkwDEg;
				if (!bOQpjnEwbxVMrfQBkJAyQRUFLWDw(P_1, num))
				{
					num = (cYsOShOAfuHWWIHDJwwxozBWKoti.jSnOJUSqgNjovVOghXsNKPDkwDEg = bzGHtIpnMyhHBAxOiJSakxZFeouJA(P_1));
				}
				mhvLrHXULSoIeHiRVHyHsfanHcMD.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				mhvLrHXULSoIeHiRVHyHsfanHcMD.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = cYsOShOAfuHWWIHDJwwxozBWKoti.vuNalSsAtCdeoaVIDxZShqksorfZ;
				xuMcnOULSjZACVIHaFiyQZMVLjZv.pinlDKCjJfbsVOEDxBBzHttwerWoA(mhvLrHXULSoIeHiRVHyHsfanHcMD);
			}
		}
	}

	private void cMZXtXPUDaeTHiMnxBqxcvwOxnIQ()
	{
		uMBCmafzqtdeZpBibitjNUslWbzL.swMCBZUMKdBIOaZDgDmYMylJSGQx();
		IList<ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB> list = nKWDSmSWzFGBYeKWyBNmcpEADMrnb();
		if (aXsZSVCRthOEbCdfoZemIkZiaNkfA(list))
		{
			jgwotNiLBvSdZdjcwYPwNNMrZfGu(list);
		}
		sTyBIUflUGVOxkADIeRricvCWoyGA = false;
	}

	private bool aXsZSVCRthOEbCdfoZemIkZiaNkfA(IList<ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB> P_0)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && !vxrmWkiUSMhjqlRICsdPLBGCnKPn(P_0[i].DlFRWDrCDbleCmLxvwDIeTLMcxrr))
			{
				return true;
			}
		}
		int count2 = jhiLZANzCpKzeLAwmrwEtjycSpyH.Count;
		for (int j = 0; j < count2; j++)
		{
			if (jhiLZANzCpKzeLAwmrwEtjycSpyH[j] != null && !NuzObVVQjiMRdDPfVQhYazooadhx(P_0, jhiLZANzCpKzeLAwmrwEtjycSpyH[j].AGMbYadrEXvuJSszSAkWPmcSQvvk))
			{
				return true;
			}
		}
		return false;
	}

	private bool vxrmWkiUSMhjqlRICsdPLBGCnKPn(Guid P_0)
	{
		int count = jhiLZANzCpKzeLAwmrwEtjycSpyH.Count;
		for (int i = 0; i < count; i++)
		{
			if (jhiLZANzCpKzeLAwmrwEtjycSpyH[i] != null && jhiLZANzCpKzeLAwmrwEtjycSpyH[i].AGMbYadrEXvuJSszSAkWPmcSQvvk == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool NuzObVVQjiMRdDPfVQhYazooadhx(IList<ZAiBOzjsAnIkPdrPiMzTFAvHaIZzB> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].DlFRWDrCDbleCmLxvwDIeTLMcxrr == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void HjQxHQdmYTFrUFvJYHNjUBVgkLUe(List<MhvLrHXULSoIeHiRVHyHsfanHcMD> P_0, List<MhvLrHXULSoIeHiRVHyHsfanHcMD> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			MhvLrHXULSoIeHiRVHyHsfanHcMD mhvLrHXULSoIeHiRVHyHsfanHcMD = P_0[i];
			if (mhvLrHXULSoIeHiRVHyHsfanHcMD == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					MhvLrHXULSoIeHiRVHyHsfanHcMD mhvLrHXULSoIeHiRVHyHsfanHcMD2 = P_1[j];
					if (mhvLrHXULSoIeHiRVHyHsfanHcMD2 != null && mhvLrHXULSoIeHiRVHyHsfanHcMD.AGMbYadrEXvuJSszSAkWPmcSQvvk == mhvLrHXULSoIeHiRVHyHsfanHcMD2.AGMbYadrEXvuJSszSAkWPmcSQvvk)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				CLeGRlesqdfJUijlHLHRAzszzIgSb(P_0[i], P_2);
			}
		}
	}

	private void CLeGRlesqdfJUijlHLHRAzszzIgSb(MhvLrHXULSoIeHiRVHyHsfanHcMD P_0, bool P_1)
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
