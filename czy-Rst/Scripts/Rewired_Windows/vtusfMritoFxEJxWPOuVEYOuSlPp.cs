using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.InputSources.SDL2;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;

internal class vtusfMritoFxEJxWPOuVEYOuSlPp : PlatformInputManager
{
	private class NOQnaCfPLWczAzaLozNsZilVjsBL : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int sFDjxRCDijdDdLFdKqPGpVeFuwhKA;

		private int XmIbTpqMDyiqJhefcUdHFpSochQq;

		public Guid BKahnZwBgpsVjSGEacpkShgWMvBN;

		public string dtNFksjsqbjBehEwzIuSxUBuJDTBb;

		public ZnhcDWhSsvGoFpuQyaqClglYKkPD anNTVHfcXbGLeFRlqeodIVnRexcgb;

		public xjLgsosrXuEFBfVDNknXDxUCGowFB qNBlJxHOzqsHFsgOkguosZrCahfr;

		public string hHJVPjJPSwfXHDthJbtbAwKGMkMv;

		public string GlCxRUHXwboLAzQXHvpSbbuGsbxt;

		public int uwgJDDRxjFmpyxhWiHteoHbFRFDd;

		public int rDfFkRHTiTDtOjwQAOGFXvsnyJnD;

		public Guid KvjOvtwfWBiVDwdshbHGJGSiOYipA;

		public PidVid jbEArgYBAzxjBhzlThMuFGlHPqXX;

		public Guid kpKbJlbAhYDrgGWmmZTDAjupgPOJ;

		public int LsrBrpFvLPPirABQVpSoLvsaZPEqA;

		public int wrtYYYPFYAKITJoWORiQgjEBcTwP;

		public int ZTfyjbTSPjrfwYbAjxpawpDksivV;

		public int MkiNQYAeDYDHhIqJgDMBojPRmzcMA;

		public int OaenMNacHYgOkIiMwnfzFNgORbBK;

		public int IZgEBpDWYSdsaFuEVfPWzFKMqVJaA;

		public bool tMxsphSiopAqvzCfqlDejdrqTOgG;

		public bool CZQsBeYjgcyQwAASXzZtygdEtHjx;

		public int RRXaFIlYYBIRMOeBMIgmgFWkYvasA;

		private float[] VLtbslOrgiRPneBUTvlztnSZbhOG;

		private bool[] VlUjRgeTDIZdKLmecAtHWaufjqem;

		private HardwareJoystickMap_InputManager yBCUrfUDtiHYRvytUKTqVOSxAlFv;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> FYpFOHAGIufrbkQfmmalSMjRgSICA;

		private bool cNXDPvcPwIJznNRYkguSNQMmhXSjA;

		private bool bQjbvtMJKmVDaqkhwtQhBhSetLBW;

		[CompilerGenerated]
		private Controller.Extension yTMulEihZosuYlmzuqzfHQYfgNUo;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return sFDjxRCDijdDdLFdKqPGpVeFuwhKA;
			}
			set
			{
				sFDjxRCDijdDdLFdKqPGpVeFuwhKA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return XmIbTpqMDyiqJhefcUdHFpSochQq;
			}
			set
			{
				XmIbTpqMDyiqJhefcUdHFpSochQq = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name => dtNFksjsqbjBehEwzIuSxUBuJDTBb;

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (XmIbTpqMDyiqJhefcUdHFpSochQq < 0)
				{
					return null;
				}
				return XmIbTpqMDyiqJhefcUdHFpSochQq;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => KvjOvtwfWBiVDwdshbHGJGSiOYipA;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			[CompilerGenerated]
			get
			{
				return yTMulEihZosuYlmzuqzfHQYfgNUo;
			}
			[CompilerGenerated]
			set
			{
				yTMulEihZosuYlmzuqzfHQYfgNUo = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			anNTVHfcXbGLeFRlqeodIVnRexcgb.IXDrJrQPpgMYgSXgQrnpmKMZbbcc(motorIndex, amount, false);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public NOQnaCfPLWczAzaLozNsZilVjsBL(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_0)
		{
			FYpFOHAGIufrbkQfmmalSMjRgSICA = P_0;
			XmIbTpqMDyiqJhefcUdHFpSochQq = -1;
			sFDjxRCDijdDdLFdKqPGpVeFuwhKA = -1;
		}

		public void tgIQKRMGGldLixabLaDitAsJKCPD()
		{
			kpKbJlbAhYDrgGWmmZTDAjupgPOJ = MiscTools.CreateGuidHashSHA1(hHJVPjJPSwfXHDthJbtbAwKGMkMv + jbEArgYBAzxjBhzlThMuFGlHPqXX.ToProductGuid().ToString());
			wrtYYYPFYAKITJoWORiQgjEBcTwP = MkiNQYAeDYDHhIqJgDMBojPRmzcMA;
			ZTfyjbTSPjrfwYbAjxpawpDksivV = OaenMNacHYgOkIiMwnfzFNgORbBK + IZgEBpDWYSdsaFuEVfPWzFKMqVJaA * 8;
			LTHeBthsMdLRtkAkYwPpSZPGxJCEA();
			BKahnZwBgpsVjSGEacpkShgWMvBN = yBCUrfUDtiHYRvytUKTqVOSxAlFv.hardwareMapIdentifier.guid;
			dtNFksjsqbjBehEwzIuSxUBuJDTBb = yBCUrfUDtiHYRvytUKTqVOSxAlFv.controllerName;
			cNXDPvcPwIJznNRYkguSNQMmhXSjA = ((BKahnZwBgpsVjSGEacpkShgWMvBN == Guid.Empty) ? true : false);
			VLtbslOrgiRPneBUTvlztnSZbhOG = new float[wrtYYYPFYAKITJoWORiQgjEBcTwP];
			VlUjRgeTDIZdKLmecAtHWaufjqem = new bool[ZTfyjbTSPjrfwYbAjxpawpDksivV];
			Update();
		}

		public void ZOWXblVTYxOGKiKIDpwktcHExkPV(NOQnaCfPLWczAzaLozNsZilVjsBL P_0)
		{
			if (P_0 != null)
			{
				XmIbTpqMDyiqJhefcUdHFpSochQq = P_0.XmIbTpqMDyiqJhefcUdHFpSochQq;
				sFDjxRCDijdDdLFdKqPGpVeFuwhKA = P_0.sFDjxRCDijdDdLFdKqPGpVeFuwhKA;
				for (int i = 0; i < MathTools.Min(VlUjRgeTDIZdKLmecAtHWaufjqem.Length, P_0.VlUjRgeTDIZdKLmecAtHWaufjqem.Length); i++)
				{
					VlUjRgeTDIZdKLmecAtHWaufjqem[i] = P_0.VlUjRgeTDIZdKLmecAtHWaufjqem[i];
				}
				for (int j = 0; j < MathTools.Min(VLtbslOrgiRPneBUTvlztnSZbhOG.Length, P_0.VLtbslOrgiRPneBUTvlztnSZbhOG.Length); j++)
				{
					VLtbslOrgiRPneBUTvlztnSZbhOG[j] = P_0.VLtbslOrgiRPneBUTvlztnSZbhOG[j];
				}
				bQjbvtMJKmVDaqkhwtQhBhSetLBW = P_0.bQjbvtMJKmVDaqkhwtQhBhSetLBW;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			FtoCEuIqFyjBunuPyqjIQAGXTyucA();
			YIXvPBgCPfzkbyodvjvBEqmjMJvNA();
			if (!bQjbvtMJKmVDaqkhwtQhBhSetLBW && anNTVHfcXbGLeFRlqeodIVnRexcgb.suhiXDcLreybtEckkbHvvCAocmBZ)
			{
				bQjbvtMJKmVDaqkhwtQhBhSetLBW = true;
			}
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (wrtYYYPFYAKITJoWORiQgjEBcTwP != dataUpdater.axisCount || ZTfyjbTSPjrfwYbAjxpawpDksivV != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < wrtYYYPFYAKITJoWORiQgjEBcTwP; i++)
			{
				dataUpdater.axisValues[i] = VLtbslOrgiRPneBUTvlztnSZbhOG[i];
			}
			for (int j = 0; j < ZTfyjbTSPjrfwYbAjxpawpDksivV; j++)
			{
				dataUpdater.buttonValues[j] = VlUjRgeTDIZdKLmecAtHWaufjqem[j];
			}
			if (bQjbvtMJKmVDaqkhwtQhBhSetLBW && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int lMDemZhOBOnPODuphamkgIVUIezOA(NOQnaCfPLWczAzaLozNsZilVjsBL P_0)
		{
			if (P_0.sFDjxRCDijdDdLFdKqPGpVeFuwhKA == sFDjxRCDijdDdLFdKqPGpVeFuwhKA)
			{
				return 2;
			}
			if (MkiNQYAeDYDHhIqJgDMBojPRmzcMA != P_0.MkiNQYAeDYDHhIqJgDMBojPRmzcMA)
			{
				return 0;
			}
			if (OaenMNacHYgOkIiMwnfzFNgORbBK != P_0.OaenMNacHYgOkIiMwnfzFNgORbBK)
			{
				return 0;
			}
			if (IZgEBpDWYSdsaFuEVfPWzFKMqVJaA != P_0.IZgEBpDWYSdsaFuEVfPWzFKMqVJaA)
			{
				return 0;
			}
			if (P_0.KvjOvtwfWBiVDwdshbHGJGSiOYipA == KvjOvtwfWBiVDwdshbHGJGSiOYipA)
			{
				return 2;
			}
			if (P_0.kpKbJlbAhYDrgGWmmZTDAjupgPOJ == kpKbJlbAhYDrgGWmmZTDAjupgPOJ)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo LKAyIpjLbcOMwzaqpXUluAHNXXdO()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			anIMULdkbhItRTZiVOqLQzzzeBcc(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			OBsitOsZoCVSldEqJzEbjHwbmHQW(bridgedController);
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
			return new ControllerDisconnectedEventArgs(sFDjxRCDijdDdLFdKqPGpVeFuwhKA);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void FtoCEuIqFyjBunuPyqjIQAGXTyucA()
		{
			if (wrtYYYPFYAKITJoWORiQgjEBcTwP <= 0 || yBCUrfUDtiHYRvytUKTqVOSxAlFv.map.platform != InputPlatform.SDL2)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_SDL2_Base)yBCUrfUDtiHYRvytUKTqVOSxAlFv.map).Axes_orig;
			if (axes_orig != null)
			{
				for (int i = 0; i < axes_orig.Length; i++)
				{
					RprjeRAQcsVYKTkIbWevuVprBszj(axes_orig[i], i);
				}
			}
		}

		private void YIXvPBgCPfzkbyodvjvBEqmjMJvNA()
		{
			if (ZTfyjbTSPjrfwYbAjxpawpDksivV <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_SDL2_Base)yBCUrfUDtiHYRvytUKTqVOSxAlFv.map).Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					eIXKeUxbybWslCaNCDlVElOcjeKr(buttons_orig[i], i);
				}
			}
		}

		private void RprjeRAQcsVYKTkIbWevuVprBszj(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0, int P_1)
		{
			if (P_1 >= wrtYYYPFYAKITJoWORiQgjEBcTwP)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			VLtbslOrgiRPneBUTvlztnSZbhOG[P_1] = HrraPBBhyrlGNFZHEZugEsjAasioc(P_0);
		}

		private void eIXKeUxbybWslCaNCDlVElOcjeKr(HardwareJoystickMap.Platform_SDL2_Base.Button P_0, int P_1)
		{
			if (P_1 >= ZTfyjbTSPjrfwYbAjxpawpDksivV)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			VlUjRgeTDIZdKLmecAtHWaufjqem[P_1] = UJMofoMAzznpoQdmDluWcMGhfSKo(P_0);
		}

		private float HrraPBBhyrlGNFZHEZugEsjAasioc(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= MkiNQYAeDYDHhIqJgDMBojPRmzcMA || sourceAxis >= 56)
				{
					return 0f;
				}
				return anNTVHfcXbGLeFRlqeodIVnRexcgb.cbjjNhnAOhePXINKZxVPJOxpmhJH(sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= OaenMNacHYgOkIiMwnfzFNgORbBK || sourceButton >= 256)
				{
					return 0f;
				}
				if (!anNTVHfcXbGLeFRlqeodIVnRexcgb.wlgOFKhsGPgfquzcEiUtERDfEUmn(sourceButton))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= IZgEBpDWYSdsaFuEVfPWzFKMqVJaA || sourceHat >= 4)
				{
					return 0f;
				}
				int num = anNTVHfcXbGLeFRlqeodIVnRexcgb.MMbigrSYldbobHYryGyFLUQWilbr(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = lSbRjdhSDqGoIFQFrApijKqwnLFx(num, AxisDirection.Horizontal);
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
					num2 = lSbRjdhSDqGoIFQFrApijKqwnLFx(num, AxisDirection.Vertical);
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

		private bool UJMofoMAzznpoQdmDluWcMGhfSKo(HardwareJoystickMap.Platform_SDL2_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (anNTVHfcXbGLeFRlqeodIVnRexcgb.wlgOFKhsGPgfquzcEiUtERDfEUmn(P_0.ignoreIfButtonsActiveButtons[i]))
						{
							return false;
						}
					}
				}
				if (P_0.requireMultipleButtons)
				{
					bool flag = false;
					for (int j = 0; j < P_0.requiredButtons.Length; j++)
					{
						if (!anNTVHfcXbGLeFRlqeodIVnRexcgb.wlgOFKhsGPgfquzcEiUtERDfEUmn(P_0.requiredButtons[j]))
						{
							return false;
						}
						flag = true;
					}
					if (flag)
					{
						return true;
					}
					return false;
				}
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= OaenMNacHYgOkIiMwnfzFNgORbBK || sourceButton >= 256)
				{
					return false;
				}
				return anNTVHfcXbGLeFRlqeodIVnRexcgb.wlgOFKhsGPgfquzcEiUtERDfEUmn(sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis <= 0 || sourceAxis >= MkiNQYAeDYDHhIqJgDMBojPRmzcMA || sourceAxis >= 56)
				{
					return false;
				}
				float num = anNTVHfcXbGLeFRlqeodIVnRexcgb.cbjjNhnAOhePXINKZxVPJOxpmhJH(sourceAxis);
				if (MathTools.Abs(num) <= P_0.axisDeadZone)
				{
					return false;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num < 0f)
					{
						return false;
					}
				}
				else if (num > 0f)
				{
					return false;
				}
				return true;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= IZgEBpDWYSdsaFuEVfPWzFKMqVJaA || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return oegOvsRfnEtunBqUBZOWsyMCzVMK(anNTVHfcXbGLeFRlqeodIVnRexcgb.MMbigrSYldbobHYryGyFLUQWilbr(sourceHat), 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return oegOvsRfnEtunBqUBZOWsyMCzVMK(anNTVHfcXbGLeFRlqeodIVnRexcgb.MMbigrSYldbobHYryGyFLUQWilbr(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return oegOvsRfnEtunBqUBZOWsyMCzVMK(anNTVHfcXbGLeFRlqeodIVnRexcgb.MMbigrSYldbobHYryGyFLUQWilbr(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return oegOvsRfnEtunBqUBZOWsyMCzVMK(anNTVHfcXbGLeFRlqeodIVnRexcgb.MMbigrSYldbobHYryGyFLUQWilbr(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return oegOvsRfnEtunBqUBZOWsyMCzVMK(anNTVHfcXbGLeFRlqeodIVnRexcgb.MMbigrSYldbobHYryGyFLUQWilbr(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return oegOvsRfnEtunBqUBZOWsyMCzVMK(anNTVHfcXbGLeFRlqeodIVnRexcgb.MMbigrSYldbobHYryGyFLUQWilbr(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return oegOvsRfnEtunBqUBZOWsyMCzVMK(anNTVHfcXbGLeFRlqeodIVnRexcgb.MMbigrSYldbobHYryGyFLUQWilbr(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return oegOvsRfnEtunBqUBZOWsyMCzVMK(anNTVHfcXbGLeFRlqeodIVnRexcgb.MMbigrSYldbobHYryGyFLUQWilbr(sourceHat), 7, P_0.sourceHatType);
				}
			}
			return false;
		}

		private bool oegOvsRfnEtunBqUBZOWsyMCzVMK(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (yBCUrfUDtiHYRvytUKTqVOSxAlFv.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return false;
			}
			int num = 4500 * P_1;
			if (P_2 == HatType.EightWay && P_0 != num)
			{
				return false;
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
				return true;
			}
			return false;
		}

		private float lSbRjdhSDqGoIFQFrApijKqwnLFx(int P_0, AxisDirection P_1)
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

		private ControlDeviceType VnwMjmVAfEELDeTBnvwBRwlogixhA(xjLgsosrXuEFBfVDNknXDxUCGowFB P_0)
		{
			return P_0 switch
			{
				xjLgsosrXuEFBfVDNknXDxUCGowFB.Joystick => ControlDeviceType.Joystick, 
				xjLgsosrXuEFBfVDNknXDxUCGowFB.Gamepad => ControlDeviceType.Gamepad, 
				xjLgsosrXuEFBfVDNknXDxUCGowFB.Keyboard => ControlDeviceType.Keyboard, 
				xjLgsosrXuEFBfVDNknXDxUCGowFB.Mouse => ControlDeviceType.Mouse, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void LTHeBthsMdLRtkAkYwPpSZPGxJCEA()
		{
			yBCUrfUDtiHYRvytUKTqVOSxAlFv = FYpFOHAGIufrbkQfmmalSMjRgSICA(LKAyIpjLbcOMwzaqpXUluAHNXXdO());
			if (yBCUrfUDtiHYRvytUKTqVOSxAlFv == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (yBCUrfUDtiHYRvytUKTqVOSxAlFv.useSystemName)
			{
				if (!string.IsNullOrEmpty(GlCxRUHXwboLAzQXHvpSbbuGsbxt))
				{
					string text = Regex.Replace(GlCxRUHXwboLAzQXHvpSbbuGsbxt, "\\s+", " ");
					text = text.Trim();
					if (!string.IsNullOrEmpty(text))
					{
						yBCUrfUDtiHYRvytUKTqVOSxAlFv.controllerName = text;
					}
				}
				if (yBCUrfUDtiHYRvytUKTqVOSxAlFv.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(yBCUrfUDtiHYRvytUKTqVOSxAlFv.deviceLocalizationInfo.parentKeys[0]))
				{
					string a = yBCUrfUDtiHYRvytUKTqVOSxAlFv.deviceLocalizationInfo.parentKeys[0];
					string text2 = string.Format("{0}:{1}", anNTVHfcXbGLeFRlqeodIVnRexcgb.IrTtoyQjUDhNcxvVbhwJCjiRgyDOA.vendorId.ToString("x4"), anNTVHfcXbGLeFRlqeodIVnRexcgb.IrTtoyQjUDhNcxvVbhwJCjiRgyDOA.productId.ToString("x4"));
					yBCUrfUDtiHYRvytUKTqVOSxAlFv.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(a, text2));
					if (!string.IsNullOrEmpty(anNTVHfcXbGLeFRlqeodIVnRexcgb.TQKIGfdgbQfLeUXMeTpYKUvYaUiF))
					{
						yBCUrfUDtiHYRvytUKTqVOSxAlFv.deviceLocalizationInfo.InsertParentKey(1, LocalizationManager.AppendToKeyAsPath(a, anNTVHfcXbGLeFRlqeodIVnRexcgb.TQKIGfdgbQfLeUXMeTpYKUvYaUiF));
					}
					if (!string.IsNullOrEmpty(anNTVHfcXbGLeFRlqeodIVnRexcgb.TQKIGfdgbQfLeUXMeTpYKUvYaUiF))
					{
						yBCUrfUDtiHYRvytUKTqVOSxAlFv.deviceLocalizationInfo.additionalIdentifyingInformation = $"{anNTVHfcXbGLeFRlqeodIVnRexcgb.TQKIGfdgbQfLeUXMeTpYKUvYaUiF} [{text2}]";
					}
					else
					{
						yBCUrfUDtiHYRvytUKTqVOSxAlFv.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text2}]";
					}
				}
			}
			wrtYYYPFYAKITJoWORiQgjEBcTwP = yBCUrfUDtiHYRvytUKTqVOSxAlFv.axisCount;
			ZTfyjbTSPjrfwYbAjxpawpDksivV = yBCUrfUDtiHYRvytUKTqVOSxAlFv.buttonCount;
		}

		private string PXgajdSBbGwHHrHbgABSqiIZSdVG()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{anNTVHfcXbGLeFRlqeodIVnRexcgb.VYUmMqWFNHfNqEhmxAoRpdgJAoZdb}{hHJVPjJPSwfXHDthJbtbAwKGMkMv}{uwgJDDRxjFmpyxhWiHteoHbFRFDd}{jbEArgYBAzxjBhzlThMuFGlHPqXX.ToProductGuid()}");
		}

		private void anIMULdkbhItRTZiVOqLQzzzeBcc(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.SDL2;
			P_0.inputSource = anNTVHfcXbGLeFRlqeodIVnRexcgb.VYUmMqWFNHfNqEhmxAoRpdgJAoZdb;
			P_0.deviceType = VnwMjmVAfEELDeTBnvwBRwlogixhA(qNBlJxHOzqsHFsgOkguosZrCahfr);
			P_0.hardwareIdentifier = PXgajdSBbGwHHrHbgABSqiIZSdVG();
			P_0.hardwareAxisCount = MkiNQYAeDYDHhIqJgDMBojPRmzcMA;
			P_0.hardwareButtonCount = OaenMNacHYgOkIiMwnfzFNgORbBK;
			P_0.hardwareHatCount = IZgEBpDWYSdsaFuEVfPWzFKMqVJaA;
			P_0.hw_productName = hHJVPjJPSwfXHDthJbtbAwKGMkMv;
			P_0.hw_deviceGuid = KvjOvtwfWBiVDwdshbHGJGSiOYipA;
			P_0.hw_productId = uwgJDDRxjFmpyxhWiHteoHbFRFDd;
			P_0.hw_pidVid = jbEArgYBAzxjBhzlThMuFGlHPqXX;
			P_0.hw_isBluetoothDevice = tMxsphSiopAqvzCfqlDejdrqTOgG;
			P_0.hw_bluetoothDeviceName = hHJVPjJPSwfXHDthJbtbAwKGMkMv;
			P_0.hw_systemDeviceName = hHJVPjJPSwfXHDthJbtbAwKGMkMv;
			P_0.hw_supportsVibration = CZQsBeYjgcyQwAASXzZtygdEtHjx;
			P_0.hw_isSDL2Gamepad = anNTVHfcXbGLeFRlqeodIVnRexcgb.NgOsfHDNxSDrFAZUbTjGyIdYlwPi == xjLgsosrXuEFBfVDNknXDxUCGowFB.Gamepad;
			P_0.hw_localVibrationMotorCount = RRXaFIlYYBIRMOeBMIgmgFWkYvasA;
		}

		private void OBsitOsZoCVSldEqJzEbjHwbmHQW(BridgedController P_0)
		{
			anIMULdkbhItRTZiVOqLQzzzeBcc(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = yBCUrfUDtiHYRvytUKTqVOSxAlFv.ToGameHardwareControllerMap();
			P_0.instanceName = hHJVPjJPSwfXHDthJbtbAwKGMkMv;
			P_0.productName = hHJVPjJPSwfXHDthJbtbAwKGMkMv;
			P_0.axisCount = wrtYYYPFYAKITJoWORiQgjEBcTwP;
			P_0.buttonCount = ZTfyjbTSPjrfwYbAjxpawpDksivV;
			P_0.unknownControllerHats = DFoKOKoItGWzinkDLTAHxOciGmfHA();
			P_0.controllerTypeGuid = BKahnZwBgpsVjSGEacpkShgWMvBN;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void kfsayndojucHMrghpPsqlngHpokx()
		{
			for (int i = 0; i < ZTfyjbTSPjrfwYbAjxpawpDksivV; i++)
			{
				VlUjRgeTDIZdKLmecAtHWaufjqem[i] = false;
			}
			for (int j = 0; j < wrtYYYPFYAKITJoWORiQgjEBcTwP; j++)
			{
				VLtbslOrgiRPneBUTvlztnSZbhOG[j] = 0f;
			}
		}

		private UnknownControllerHat[] DFoKOKoItGWzinkDLTAHxOciGmfHA()
		{
			if (!cNXDPvcPwIJznNRYkguSNQMmhXSjA)
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

		public static int oSFhuQLnptwyierocmdHQeELTpRl(NOQnaCfPLWczAzaLozNsZilVjsBL P_0, NOQnaCfPLWczAzaLozNsZilVjsBL P_1)
		{
			if (P_0.XmIbTpqMDyiqJhefcUdHFpSochQq < P_1.XmIbTpqMDyiqJhefcUdHFpSochQq)
			{
				return -1;
			}
			if (P_0.XmIbTpqMDyiqJhefcUdHFpSochQq > P_1.XmIbTpqMDyiqJhefcUdHFpSochQq)
			{
				return 1;
			}
			return 0;
		}

		public static int FJbRCKxrUPxaBfJQCCUFifnUmBlD(NOQnaCfPLWczAzaLozNsZilVjsBL P_0, NOQnaCfPLWczAzaLozNsZilVjsBL P_1)
		{
			if (P_0.LsrBrpFvLPPirABQVpSoLvsaZPEqA < P_1.LsrBrpFvLPPirABQVpSoLvsaZPEqA)
			{
				return -1;
			}
			if (P_0.LsrBrpFvLPPirABQVpSoLvsaZPEqA > P_1.LsrBrpFvLPPirABQVpSoLvsaZPEqA)
			{
				return 1;
			}
			return 0;
		}
	}

	private class JOsEIXEHffHIgvnSkGWkWzxFzGzoA
	{
		public enum joqbMlaImizJdgqRbEbUDIbIEFgD
		{
			Exact = 0,
			Approximate = 1
		}

		public class kMNNJeyhviRDLSIgvePKBffKIBwr
		{
			public int GYsFnEaawfylltevAHxDdwKHcUEAA;

			public Guid ZcfeEYNXufmxIjLCDOTyKMqgJUIo;

			public Guid orcGkRFISxOvJMJXnpoocsXEbSVdb;

			public int nHZqReLRyIFakwnjmLhFdmOfpmRT;

			public int nhFfbFZbRaEcchDBDgCUUsBhfJOb;

			public int iXteeSGSGsdjAoRwjOQMZkhLyOQy;

			public int fXCqZuIiboIsvuwPtiayxCVAQDhl;

			public bool gPuEghKpomcoGJJSQHkfpnUGExKyA(NOQnaCfPLWczAzaLozNsZilVjsBL P_0, joqbMlaImizJdgqRbEbUDIbIEFgD P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == GYsFnEaawfylltevAHxDdwKHcUEAA)
				{
					return true;
				}
				if (nhFfbFZbRaEcchDBDgCUUsBhfJOb != P_0.MkiNQYAeDYDHhIqJgDMBojPRmzcMA)
				{
					return false;
				}
				if (iXteeSGSGsdjAoRwjOQMZkhLyOQy != P_0.OaenMNacHYgOkIiMwnfzFNgORbBK)
				{
					return false;
				}
				if (fXCqZuIiboIsvuwPtiayxCVAQDhl != P_0.IZgEBpDWYSdsaFuEVfPWzFKMqVJaA)
				{
					return false;
				}
				return P_1 switch
				{
					joqbMlaImizJdgqRbEbUDIbIEFgD.Exact => ZcfeEYNXufmxIjLCDOTyKMqgJUIo == P_0.KvjOvtwfWBiVDwdshbHGJGSiOYipA, 
					joqbMlaImizJdgqRbEbUDIbIEFgD.Approximate => orcGkRFISxOvJMJXnpoocsXEbSVdb == P_0.kpKbJlbAhYDrgGWmmZTDAjupgPOJ, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		private sealed class HAORluTeiYQlkypEkhyxdLCIDDZSA : IEnumerable<kMNNJeyhviRDLSIgvePKBffKIBwr>, IEnumerable, IEnumerator<kMNNJeyhviRDLSIgvePKBffKIBwr>, IEnumerator, IDisposable
		{
			private int ARzfKkdeAmjoKXojBwyFtKxwQaFr;

			private kMNNJeyhviRDLSIgvePKBffKIBwr wTQCTUdkMgxDfrjJuEXIESBOhEEpA;

			private int gEPInqfcOPFqRdALaUmYYcCaDJOWA;

			public JOsEIXEHffHIgvnSkGWkWzxFzGzoA XxPBlBeVpGtKjWoDsTeMnVZOWFxnA;

			private NOQnaCfPLWczAzaLozNsZilVjsBL qYhksREcbvpzbAGSKbrgynYGVmHQ;

			public NOQnaCfPLWczAzaLozNsZilVjsBL cgsAFekjOSfTqkayeLdyBbvCOPYpB;

			private joqbMlaImizJdgqRbEbUDIbIEFgD hGGHYNUfTFsfclMhaxsZCikoaHqH;

			public joqbMlaImizJdgqRbEbUDIbIEFgD OOtEOGBYWFApFVMdHpZjAUoySTcH;

			private int fxImflvRgtrkBYWPalvcYETGrcer;

			private int sAofBwCVXbPwxttXwKhpjtCPMmAIb;

			kMNNJeyhviRDLSIgvePKBffKIBwr IEnumerator<kMNNJeyhviRDLSIgvePKBffKIBwr>.Current
			{
				[DebuggerHidden]
				get
				{
					return wTQCTUdkMgxDfrjJuEXIESBOhEEpA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return wTQCTUdkMgxDfrjJuEXIESBOhEEpA;
				}
			}

			[DebuggerHidden]
			public HAORluTeiYQlkypEkhyxdLCIDDZSA(int P_0)
			{
				ARzfKkdeAmjoKXojBwyFtKxwQaFr = P_0;
				gEPInqfcOPFqRdALaUmYYcCaDJOWA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int aRzfKkdeAmjoKXojBwyFtKxwQaFr = ARzfKkdeAmjoKXojBwyFtKxwQaFr;
				JOsEIXEHffHIgvnSkGWkWzxFzGzoA xxPBlBeVpGtKjWoDsTeMnVZOWFxnA = XxPBlBeVpGtKjWoDsTeMnVZOWFxnA;
				if (aRzfKkdeAmjoKXojBwyFtKxwQaFr != 0)
				{
					if (aRzfKkdeAmjoKXojBwyFtKxwQaFr != 1)
					{
						return false;
					}
					ARzfKkdeAmjoKXojBwyFtKxwQaFr = -1;
					goto IL_0083;
				}
				ARzfKkdeAmjoKXojBwyFtKxwQaFr = -1;
				fxImflvRgtrkBYWPalvcYETGrcer = xxPBlBeVpGtKjWoDsTeMnVZOWFxnA.nYAbLuSrMbKxKPnysVxnnJvzvkhl.Count;
				sAofBwCVXbPwxttXwKhpjtCPMmAIb = 0;
				goto IL_0093;
				IL_0083:
				sAofBwCVXbPwxttXwKhpjtCPMmAIb++;
				goto IL_0093;
				IL_0093:
				if (sAofBwCVXbPwxttXwKhpjtCPMmAIb < fxImflvRgtrkBYWPalvcYETGrcer)
				{
					if (xxPBlBeVpGtKjWoDsTeMnVZOWFxnA.nYAbLuSrMbKxKPnysVxnnJvzvkhl[sAofBwCVXbPwxttXwKhpjtCPMmAIb].gPuEghKpomcoGJJSQHkfpnUGExKyA(qYhksREcbvpzbAGSKbrgynYGVmHQ, hGGHYNUfTFsfclMhaxsZCikoaHqH))
					{
						wTQCTUdkMgxDfrjJuEXIESBOhEEpA = xxPBlBeVpGtKjWoDsTeMnVZOWFxnA.nYAbLuSrMbKxKPnysVxnnJvzvkhl[sAofBwCVXbPwxttXwKhpjtCPMmAIb];
						ARzfKkdeAmjoKXojBwyFtKxwQaFr = 1;
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
			IEnumerator<kMNNJeyhviRDLSIgvePKBffKIBwr> IEnumerable<kMNNJeyhviRDLSIgvePKBffKIBwr>.GetEnumerator()
			{
				HAORluTeiYQlkypEkhyxdLCIDDZSA hAORluTeiYQlkypEkhyxdLCIDDZSA;
				if (ARzfKkdeAmjoKXojBwyFtKxwQaFr == -2 && gEPInqfcOPFqRdALaUmYYcCaDJOWA == Environment.CurrentManagedThreadId)
				{
					ARzfKkdeAmjoKXojBwyFtKxwQaFr = 0;
					hAORluTeiYQlkypEkhyxdLCIDDZSA = this;
				}
				else
				{
					hAORluTeiYQlkypEkhyxdLCIDDZSA = new HAORluTeiYQlkypEkhyxdLCIDDZSA(0);
					hAORluTeiYQlkypEkhyxdLCIDDZSA.XxPBlBeVpGtKjWoDsTeMnVZOWFxnA = XxPBlBeVpGtKjWoDsTeMnVZOWFxnA;
				}
				hAORluTeiYQlkypEkhyxdLCIDDZSA.qYhksREcbvpzbAGSKbrgynYGVmHQ = cgsAFekjOSfTqkayeLdyBbvCOPYpB;
				hAORluTeiYQlkypEkhyxdLCIDDZSA.hGGHYNUfTFsfclMhaxsZCikoaHqH = OOtEOGBYWFApFVMdHpZjAUoySTcH;
				return hAORluTeiYQlkypEkhyxdLCIDDZSA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<kMNNJeyhviRDLSIgvePKBffKIBwr>)this).GetEnumerator();
			}
		}

		private List<kMNNJeyhviRDLSIgvePKBffKIBwr> nYAbLuSrMbKxKPnysVxnnJvzvkhl;

		public JOsEIXEHffHIgvnSkGWkWzxFzGzoA()
		{
			nYAbLuSrMbKxKPnysVxnnJvzvkhl = new List<kMNNJeyhviRDLSIgvePKBffKIBwr>();
		}

		public void FEjhcnwdlMaIMuDhYaZUOsmSMHpn(NOQnaCfPLWczAzaLozNsZilVjsBL P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = nYAbLuSrMbKxKPnysVxnnJvzvkhl.Count;
			for (int i = 0; i < count; i++)
			{
				if (nYAbLuSrMbKxKPnysVxnnJvzvkhl[i].gPuEghKpomcoGJJSQHkfpnUGExKyA(P_0, joqbMlaImizJdgqRbEbUDIbIEFgD.Exact))
				{
					nYAbLuSrMbKxKPnysVxnnJvzvkhl[i].GYsFnEaawfylltevAHxDdwKHcUEAA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					nYAbLuSrMbKxKPnysVxnnJvzvkhl[i].ZcfeEYNXufmxIjLCDOTyKMqgJUIo = P_0.KvjOvtwfWBiVDwdshbHGJGSiOYipA;
					nYAbLuSrMbKxKPnysVxnnJvzvkhl[i].orcGkRFISxOvJMJXnpoocsXEbSVdb = P_0.kpKbJlbAhYDrgGWmmZTDAjupgPOJ;
					nYAbLuSrMbKxKPnysVxnnJvzvkhl[i].nHZqReLRyIFakwnjmLhFdmOfpmRT = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					nYAbLuSrMbKxKPnysVxnnJvzvkhl[i].nhFfbFZbRaEcchDBDgCUUsBhfJOb = P_0.MkiNQYAeDYDHhIqJgDMBojPRmzcMA;
					nYAbLuSrMbKxKPnysVxnnJvzvkhl[i].iXteeSGSGsdjAoRwjOQMZkhLyOQy = P_0.OaenMNacHYgOkIiMwnfzFNgORbBK;
					nYAbLuSrMbKxKPnysVxnnJvzvkhl[i].fXCqZuIiboIsvuwPtiayxCVAQDhl = P_0.IZgEBpDWYSdsaFuEVfPWzFKMqVJaA;
					nXerLkHqMGXylvOSJMNksYgZgHNG(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.KvjOvtwfWBiVDwdshbHGJGSiOYipA, i);
					return;
				}
			}
			nYAbLuSrMbKxKPnysVxnnJvzvkhl.Add(new kMNNJeyhviRDLSIgvePKBffKIBwr
			{
				GYsFnEaawfylltevAHxDdwKHcUEAA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				ZcfeEYNXufmxIjLCDOTyKMqgJUIo = P_0.KvjOvtwfWBiVDwdshbHGJGSiOYipA,
				orcGkRFISxOvJMJXnpoocsXEbSVdb = P_0.kpKbJlbAhYDrgGWmmZTDAjupgPOJ,
				nHZqReLRyIFakwnjmLhFdmOfpmRT = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				nhFfbFZbRaEcchDBDgCUUsBhfJOb = P_0.MkiNQYAeDYDHhIqJgDMBojPRmzcMA,
				iXteeSGSGsdjAoRwjOQMZkhLyOQy = P_0.OaenMNacHYgOkIiMwnfzFNgORbBK,
				fXCqZuIiboIsvuwPtiayxCVAQDhl = P_0.IZgEBpDWYSdsaFuEVfPWzFKMqVJaA
			});
			nXerLkHqMGXylvOSJMNksYgZgHNG(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.KvjOvtwfWBiVDwdshbHGJGSiOYipA, nYAbLuSrMbKxKPnysVxnnJvzvkhl.Count - 1);
		}

		public bool ZVqcHdDWsafuAsGyZhbQvXaAsoaJ(NOQnaCfPLWczAzaLozNsZilVjsBL P_0, joqbMlaImizJdgqRbEbUDIbIEFgD P_1)
		{
			int count = nYAbLuSrMbKxKPnysVxnnJvzvkhl.Count;
			for (int i = 0; i < count; i++)
			{
				if (nYAbLuSrMbKxKPnysVxnnJvzvkhl[i].gPuEghKpomcoGJJSQHkfpnUGExKyA(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(HAORluTeiYQlkypEkhyxdLCIDDZSA))]
		public IEnumerable<kMNNJeyhviRDLSIgvePKBffKIBwr> zfFOechTJwSnKxdducIvrnssLQLM(NOQnaCfPLWczAzaLozNsZilVjsBL P_0, joqbMlaImizJdgqRbEbUDIbIEFgD P_1)
		{
			return new HAORluTeiYQlkypEkhyxdLCIDDZSA(-2)
			{
				XxPBlBeVpGtKjWoDsTeMnVZOWFxnA = this,
				cgsAFekjOSfTqkayeLdyBbvCOPYpB = P_0,
				OOtEOGBYWFApFVMdHpZjAUoySTcH = P_1
			};
		}

		private void nXerLkHqMGXylvOSJMNksYgZgHNG(int P_0, Guid P_1, int P_2)
		{
			for (int num = nYAbLuSrMbKxKPnysVxnnJvzvkhl.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (nYAbLuSrMbKxKPnysVxnnJvzvkhl[num].GYsFnEaawfylltevAHxDdwKHcUEAA == P_0 || nYAbLuSrMbKxKPnysVxnnJvzvkhl[num].ZcfeEYNXufmxIjLCDOTyKMqgJUIo == P_1))
				{
					nYAbLuSrMbKxKPnysVxnnJvzvkhl.RemoveAt(num);
				}
			}
		}
	}

	internal const bool uaJOieAgLXFuTeVimJsjkdMvdEAr = true;

	private IInputSource XIjcClIQfAAKRtPBdzdXitWOISxJ;

	private List<NOQnaCfPLWczAzaLozNsZilVjsBL> SbSIHYadlMFxGgPWuodfLDFULBxQ;

	private int MiaohrTKBzoQtAVylHzCOPwEuisk;

	private JOsEIXEHffHIgvnSkGWkWzxFzGzoA qlasIeUpKlVubSrBxLgTnkfcWqrb;

	private bool HzIGCxUrNBJCrzhVFizeZDaBxlTN;

	private Action<int, ControllerDataUpdater> XxpuHBlJsaxougNJaKjJpoRCUfN;

	private PlatformInputManager XXrcsErCsLxewWHPDeYLQqJBPmSw;

	private readonly bool ytgNvzObfDiQiIMwZXBJstemqVsF;

	private readonly bool ycpNSDdDdJuVKcSWHfyGTPnSbhDe;

	private readonly bool iVedjuekUcrbQesTiuVqGpoPtQLg;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> JMYYRjqaGEzVXvVftGdVePcZEKRF;

	private readonly Func<int> PYupvISBYcokBoxrpJYtnrNDliJB;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => MiaohrTKBzoQtAVylHzCOPwEuisk;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => XXrcsErCsLxewWHPDeYLQqJBPmSw;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => XIjcClIQfAAKRtPBdzdXitWOISxJ;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.SDL2;

	public vtusfMritoFxEJxWPOuVEYOuSlPp(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2, bool P_3, bool P_4, bool P_5)
	{
		try
		{
			JMYYRjqaGEzVXvVftGdVePcZEKRF = P_1;
			PYupvISBYcokBoxrpJYtnrNDliJB = P_2;
			ytgNvzObfDiQiIMwZXBJstemqVsF = P_3;
			ycpNSDdDdJuVKcSWHfyGTPnSbhDe = P_4;
			iVedjuekUcrbQesTiuVqGpoPtQLg = P_5;
			XXrcsErCsLxewWHPDeYLQqJBPmSw = this;
			XIjcClIQfAAKRtPBdzdXitWOISxJ = new SDL2InputSource(P_0.updateLoop, P_3, P_3, P_4, P_5);
			XxpuHBlJsaxougNJaKjJpoRCUfN = UpdateControllerData;
			XIjcClIQfAAKRtPBdzdXitWOISxJ.DeviceChangedEvent += lwmuxIhINvCezEdzSeHyyiLMHDiCA;
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
		if (ytgNvzObfDiQiIMwZXBJstemqVsF)
		{
			qlasIeUpKlVubSrBxLgTnkfcWqrb = new JOsEIXEHffHIgvnSkGWkWzxFzGzoA();
			vQaGONLtYkxgPupVQePKJprXeUgAb();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (XIjcClIQfAAKRtPBdzdXitWOISxJ != null)
		{
			XIjcClIQfAAKRtPBdzdXitWOISxJ.Update();
		}
		if (ytgNvzObfDiQiIMwZXBJstemqVsF)
		{
			if (HzIGCxUrNBJCrzhVFizeZDaBxlTN)
			{
				KzqgnATrRlRoSwSgDArfuzRLPWvf();
			}
			if (XIjcClIQfAAKRtPBdzdXitWOISxJ != null)
			{
				for (int i = 0; i < MiaohrTKBzoQtAVylHzCOPwEuisk; i++)
				{
					SbSIHYadlMFxGgPWuodfLDFULBxQ[i]?.anNTVHfcXbGLeFRlqeodIVnRexcgb.CByDqtIPRsDdqZHHJbezKWqQfIGDA(updateLoop);
				}
				XIjcClIQfAAKRtPBdzdXitWOISxJ.UpdateDevices(updateLoop);
			}
			wbJsZbwpDZLSlbadTgrfGcJMkVqZA();
			if (XIjcClIQfAAKRtPBdzdXitWOISxJ != null)
			{
				XIjcClIQfAAKRtPBdzdXitWOISxJ.UpdateFinished();
				for (int j = 0; j < MiaohrTKBzoQtAVylHzCOPwEuisk; j++)
				{
					SbSIHYadlMFxGgPWuodfLDFULBxQ[j]?.anNTVHfcXbGLeFRlqeodIVnRexcgb.mNMxxXvuUtdWsERXwwuSPrQDYJHA();
				}
			}
		}
		_ = ycpNSDdDdJuVKcSWHfyGTPnSbhDe;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (SbSIHYadlMFxGgPWuodfLDFULBxQ != null)
		{
			int count = SbSIHYadlMFxGgPWuodfLDFULBxQ.Count;
			for (int i = 0; i < count; i++)
			{
				if (SbSIHYadlMFxGgPWuodfLDFULBxQ[i] != null)
				{
					SbSIHYadlMFxGgPWuodfLDFULBxQ[i].anNTVHfcXbGLeFRlqeodIVnRexcgb?.TazBSdCtNaIRxxrPAurSTkZzgDlpA();
				}
			}
		}
		if (XIjcClIQfAAKRtPBdzdXitWOISxJ != null)
		{
			XIjcClIQfAAKRtPBdzdXitWOISxJ.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return XxpuHBlJsaxougNJaKjJpoRCUfN;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!ytgNvzObfDiQiIMwZXBJstemqVsF)
		{
			return;
		}
		for (int i = 0; i < MiaohrTKBzoQtAVylHzCOPwEuisk; i++)
		{
			if (SbSIHYadlMFxGgPWuodfLDFULBxQ[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
			{
				SbSIHYadlMFxGgPWuodfLDFULBxQ[i].FillData(data);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		if (ytgNvzObfDiQiIMwZXBJstemqVsF)
		{
			HzIGCxUrNBJCrzhVFizeZDaBxlTN = true;
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		if (ytgNvzObfDiQiIMwZXBJstemqVsF)
		{
			HzIGCxUrNBJCrzhVFizeZDaBxlTN = true;
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = ytgNvzObfDiQiIMwZXBJstemqVsF;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return null;
	}

	private void vQaGONLtYkxgPupVQePKJprXeUgAb()
	{
		ZTdcqvxvxeCkQIFbflyPxXuVbppY(wQvBXeTkRfnzBQDAopvMMLrytUAj());
	}

	private void ZTdcqvxvxeCkQIFbflyPxXuVbppY(IList<ZnhcDWhSsvGoFpuQyaqClglYKkPD> P_0)
	{
		int num = 0;
		List<NOQnaCfPLWczAzaLozNsZilVjsBL> sbSIHYadlMFxGgPWuodfLDFULBxQ = SbSIHYadlMFxGgPWuodfLDFULBxQ;
		int miaohrTKBzoQtAVylHzCOPwEuisk = MiaohrTKBzoQtAVylHzCOPwEuisk;
		SbSIHYadlMFxGgPWuodfLDFULBxQ = new List<NOQnaCfPLWczAzaLozNsZilVjsBL>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				ZnhcDWhSsvGoFpuQyaqClglYKkPD znhcDWhSsvGoFpuQyaqClglYKkPD = P_0[i];
				NOQnaCfPLWczAzaLozNsZilVjsBL nOQnaCfPLWczAzaLozNsZilVjsBL = new NOQnaCfPLWczAzaLozNsZilVjsBL(JMYYRjqaGEzVXvVftGdVePcZEKRF);
				nOQnaCfPLWczAzaLozNsZilVjsBL.anNTVHfcXbGLeFRlqeodIVnRexcgb = znhcDWhSsvGoFpuQyaqClglYKkPD;
				nOQnaCfPLWczAzaLozNsZilVjsBL.KvjOvtwfWBiVDwdshbHGJGSiOYipA = znhcDWhSsvGoFpuQyaqClglYKkPD.ocbTYztmyxijHBBPAOjSLNJkimdu;
				nOQnaCfPLWczAzaLozNsZilVjsBL.hHJVPjJPSwfXHDthJbtbAwKGMkMv = znhcDWhSsvGoFpuQyaqClglYKkPD.TQKIGfdgbQfLeUXMeTpYKUvYaUiF;
				nOQnaCfPLWczAzaLozNsZilVjsBL.GlCxRUHXwboLAzQXHvpSbbuGsbxt = znhcDWhSsvGoFpuQyaqClglYKkPD.CcBTVuamfxgcdWLMBXGVdbZyLkOf;
				nOQnaCfPLWczAzaLozNsZilVjsBL.jbEArgYBAzxjBhzlThMuFGlHPqXX = znhcDWhSsvGoFpuQyaqClglYKkPD.IrTtoyQjUDhNcxvVbhwJCjiRgyDOA;
				nOQnaCfPLWczAzaLozNsZilVjsBL.uwgJDDRxjFmpyxhWiHteoHbFRFDd = znhcDWhSsvGoFpuQyaqClglYKkPD.uMDVmpOiepofEkNTTArVktXaWtBd;
				nOQnaCfPLWczAzaLozNsZilVjsBL.rDfFkRHTiTDtOjwQAOGFXvsnyJnD = znhcDWhSsvGoFpuQyaqClglYKkPD.TAhOxPAbMmMadjEpIbmBHiUmnlDb;
				nOQnaCfPLWczAzaLozNsZilVjsBL.qNBlJxHOzqsHFsgOkguosZrCahfr = znhcDWhSsvGoFpuQyaqClglYKkPD.NgOsfHDNxSDrFAZUbTjGyIdYlwPi;
				nOQnaCfPLWczAzaLozNsZilVjsBL.LsrBrpFvLPPirABQVpSoLvsaZPEqA = znhcDWhSsvGoFpuQyaqClglYKkPD.TVUiVnyfkIDnUFJTxBBkiAEAURbz;
				nOQnaCfPLWczAzaLozNsZilVjsBL.MkiNQYAeDYDHhIqJgDMBojPRmzcMA = znhcDWhSsvGoFpuQyaqClglYKkPD.hKhcbcPMXoBnwTSbXkxFHqSbVtDH;
				nOQnaCfPLWczAzaLozNsZilVjsBL.OaenMNacHYgOkIiMwnfzFNgORbBK = znhcDWhSsvGoFpuQyaqClglYKkPD.PpYgSsLwnAkjTfSAOOFEaqqEGUtn;
				nOQnaCfPLWczAzaLozNsZilVjsBL.IZgEBpDWYSdsaFuEVfPWzFKMqVJaA = znhcDWhSsvGoFpuQyaqClglYKkPD.wgwclzHKasGiSyQXDpVBmuilbdLEb;
				nOQnaCfPLWczAzaLozNsZilVjsBL.tMxsphSiopAqvzCfqlDejdrqTOgG = znhcDWhSsvGoFpuQyaqClglYKkPD.LKdbPmFyHJSobDKKUtYKtNACuRjFA;
				nOQnaCfPLWczAzaLozNsZilVjsBL.CZQsBeYjgcyQwAASXzZtygdEtHjx = znhcDWhSsvGoFpuQyaqClglYKkPD.vURJQJBlgqKwLKshZgjxDOeMvcTo;
				nOQnaCfPLWczAzaLozNsZilVjsBL.RRXaFIlYYBIRMOeBMIgmgFWkYvasA = znhcDWhSsvGoFpuQyaqClglYKkPD.kBSBbtyioChuvBsneEcsLJpuyDMpA;
				nOQnaCfPLWczAzaLozNsZilVjsBL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension = znhcDWhSsvGoFpuQyaqClglYKkPD.DpsGXyUPRWoFieOiAKJPwDAJgUaAA;
				znhcDWhSsvGoFpuQyaqClglYKkPD.FJpBKtIHMncKtvrAZQogLYQfnNveA();
				nOQnaCfPLWczAzaLozNsZilVjsBL.tgIQKRMGGldLixabLaDitAsJKCPD();
				SbSIHYadlMFxGgPWuodfLDFULBxQ.Add(nOQnaCfPLWczAzaLozNsZilVjsBL);
				num++;
			}
		}
		MiaohrTKBzoQtAVylHzCOPwEuisk = num;
		GZkzIgbprEuuAtLKnNIasNeHgoJw(miaohrTKBzoQtAVylHzCOPwEuisk, num, sbSIHYadlMFxGgPWuodfLDFULBxQ, SbSIHYadlMFxGgPWuodfLDFULBxQ);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(SbSIHYadlMFxGgPWuodfLDFULBxQ[j]));
			}
		}
		olwrmOFKKmAWqxnbJVgNgqemtRdh(sbSIHYadlMFxGgPWuodfLDFULBxQ, SbSIHYadlMFxGgPWuodfLDFULBxQ, false);
		olwrmOFKKmAWqxnbJVgNgqemtRdh(SbSIHYadlMFxGgPWuodfLDFULBxQ, sbSIHYadlMFxGgPWuodfLDFULBxQ, true);
	}

	private void wbJsZbwpDZLSlbadTgrfGcJMkVqZA()
	{
		for (int i = 0; i < MiaohrTKBzoQtAVylHzCOPwEuisk; i++)
		{
			SbSIHYadlMFxGgPWuodfLDFULBxQ[i]?.Update();
		}
	}

	private bool OMtZAbpHYAzWfIqHXjIoZgginhGs(trnrvEuPTvoGZCrpGMYKWzalvNci P_0)
	{
		try
		{
			return P_0.WXoEIjcyHRuAGvAkuygpIIcWJZIoA();
		}
		catch
		{
			return false;
		}
	}

	private IList<ZnhcDWhSsvGoFpuQyaqClglYKkPD> wQvBXeTkRfnzBQDAopvMMLrytUAj()
	{
		return XIjcClIQfAAKRtPBdzdXitWOISxJ.GetJoysticks<ZnhcDWhSsvGoFpuQyaqClglYKkPD>();
	}

	private void GZkzIgbprEuuAtLKnNIasNeHgoJw(int P_0, int P_1, List<NOQnaCfPLWczAzaLozNsZilVjsBL> P_2, List<NOQnaCfPLWczAzaLozNsZilVjsBL> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(NOQnaCfPLWczAzaLozNsZilVjsBL.FJbRCKxrUPxaBfJQCCUFifnUmBlD);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			ACwRhUfYXPtmJWHEAQpCmemYKelj(P_1, P_3, P_0, P_2, JOsEIXEHffHIgvnSkGWkWzxFzGzoA.joqbMlaImizJdgqRbEbUDIbIEFgD.Exact);
			ACwRhUfYXPtmJWHEAQpCmemYKelj(P_1, P_3, P_0, P_2, JOsEIXEHffHIgvnSkGWkWzxFzGzoA.joqbMlaImizJdgqRbEbUDIbIEFgD.Approximate);
		}
		hZBgPGefQRBlcJZqcbTfIQFSnQmY(P_1, P_3, JOsEIXEHffHIgvnSkGWkWzxFzGzoA.joqbMlaImizJdgqRbEbUDIbIEFgD.Exact);
		hZBgPGefQRBlcJZqcbTfIQFSnQmY(P_1, P_3, JOsEIXEHffHIgvnSkGWkWzxFzGzoA.joqbMlaImizJdgqRbEbUDIbIEFgD.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			NOQnaCfPLWczAzaLozNsZilVjsBL nOQnaCfPLWczAzaLozNsZilVjsBL = P_3[i];
			if (nOQnaCfPLWczAzaLozNsZilVjsBL != null && nOQnaCfPLWczAzaLozNsZilVjsBL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				nOQnaCfPLWczAzaLozNsZilVjsBL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = beRwrIHivwrWOQURWtYeIDfZqpxh(P_3);
				nOQnaCfPLWczAzaLozNsZilVjsBL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = PYupvISBYcokBoxrpJYtnrNDliJB();
				qlasIeUpKlVubSrBxLgTnkfcWqrb.FEjhcnwdlMaIMuDhYaZUOsmSMHpn(nOQnaCfPLWczAzaLozNsZilVjsBL);
			}
		}
		P_3.Sort(NOQnaCfPLWczAzaLozNsZilVjsBL.oSFhuQLnptwyierocmdHQeELTpRl);
	}

	private void qmLnmkkOtKbGXIavIGMbFhkoWaRy(List<NOQnaCfPLWczAzaLozNsZilVjsBL> P_0, int P_1, int P_2)
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

	private bool XyxGcOuBleCacorCReUaBTlrmQkO(List<NOQnaCfPLWczAzaLozNsZilVjsBL> P_0, int P_1)
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

	private int beRwrIHivwrWOQURWtYeIDfZqpxh(List<NOQnaCfPLWczAzaLozNsZilVjsBL> P_0)
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

	private bool aWJyStQiQBNndFqzYAGNbJNvbzws(List<NOQnaCfPLWczAzaLozNsZilVjsBL> P_0, int P_1)
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

	private void ACwRhUfYXPtmJWHEAQpCmemYKelj(int P_0, List<NOQnaCfPLWczAzaLozNsZilVjsBL> P_1, int P_2, List<NOQnaCfPLWczAzaLozNsZilVjsBL> P_3, JOsEIXEHffHIgvnSkGWkWzxFzGzoA.joqbMlaImizJdgqRbEbUDIbIEFgD P_4)
	{
		int num = ((P_4 != JOsEIXEHffHIgvnSkGWkWzxFzGzoA.joqbMlaImizJdgqRbEbUDIbIEFgD.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			NOQnaCfPLWczAzaLozNsZilVjsBL nOQnaCfPLWczAzaLozNsZilVjsBL = P_1[i];
			if (nOQnaCfPLWczAzaLozNsZilVjsBL == null || nOQnaCfPLWczAzaLozNsZilVjsBL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				NOQnaCfPLWczAzaLozNsZilVjsBL nOQnaCfPLWczAzaLozNsZilVjsBL2 = P_3[j];
				if (nOQnaCfPLWczAzaLozNsZilVjsBL2 != null && !aWJyStQiQBNndFqzYAGNbJNvbzws(P_1, nOQnaCfPLWczAzaLozNsZilVjsBL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && nOQnaCfPLWczAzaLozNsZilVjsBL.lMDemZhOBOnPODuphamkgIVUIezOA(nOQnaCfPLWczAzaLozNsZilVjsBL2) >= num)
				{
					nOQnaCfPLWczAzaLozNsZilVjsBL.ZOWXblVTYxOGKiKIDpwktcHExkPV(nOQnaCfPLWczAzaLozNsZilVjsBL2);
					qlasIeUpKlVubSrBxLgTnkfcWqrb.FEjhcnwdlMaIMuDhYaZUOsmSMHpn(nOQnaCfPLWczAzaLozNsZilVjsBL);
				}
			}
		}
	}

	private void hZBgPGefQRBlcJZqcbTfIQFSnQmY(int P_0, List<NOQnaCfPLWczAzaLozNsZilVjsBL> P_1, JOsEIXEHffHIgvnSkGWkWzxFzGzoA.joqbMlaImizJdgqRbEbUDIbIEFgD P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			NOQnaCfPLWczAzaLozNsZilVjsBL nOQnaCfPLWczAzaLozNsZilVjsBL = P_1[i];
			if (nOQnaCfPLWczAzaLozNsZilVjsBL == null || nOQnaCfPLWczAzaLozNsZilVjsBL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			JOsEIXEHffHIgvnSkGWkWzxFzGzoA.kMNNJeyhviRDLSIgvePKBffKIBwr kMNNJeyhviRDLSIgvePKBffKIBwr = null;
			foreach (JOsEIXEHffHIgvnSkGWkWzxFzGzoA.kMNNJeyhviRDLSIgvePKBffKIBwr item in qlasIeUpKlVubSrBxLgTnkfcWqrb.zfFOechTJwSnKxdducIvrnssLQLM(nOQnaCfPLWczAzaLozNsZilVjsBL, P_2))
			{
				if (!aWJyStQiQBNndFqzYAGNbJNvbzws(P_1, item.GYsFnEaawfylltevAHxDdwKHcUEAA) && item.nHZqReLRyIFakwnjmLhFdmOfpmRT >= 0)
				{
					kMNNJeyhviRDLSIgvePKBffKIBwr = item;
					break;
				}
			}
			if (kMNNJeyhviRDLSIgvePKBffKIBwr != null)
			{
				int num = kMNNJeyhviRDLSIgvePKBffKIBwr.nHZqReLRyIFakwnjmLhFdmOfpmRT;
				if (!XyxGcOuBleCacorCReUaBTlrmQkO(P_1, num))
				{
					num = (kMNNJeyhviRDLSIgvePKBffKIBwr.nHZqReLRyIFakwnjmLhFdmOfpmRT = beRwrIHivwrWOQURWtYeIDfZqpxh(P_1));
				}
				nOQnaCfPLWczAzaLozNsZilVjsBL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				nOQnaCfPLWczAzaLozNsZilVjsBL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = kMNNJeyhviRDLSIgvePKBffKIBwr.GYsFnEaawfylltevAHxDdwKHcUEAA;
				qlasIeUpKlVubSrBxLgTnkfcWqrb.FEjhcnwdlMaIMuDhYaZUOsmSMHpn(nOQnaCfPLWczAzaLozNsZilVjsBL);
			}
		}
	}

	private void KzqgnATrRlRoSwSgDArfuzRLPWvf()
	{
		IList<ZnhcDWhSsvGoFpuQyaqClglYKkPD> list = wQvBXeTkRfnzBQDAopvMMLrytUAj();
		ZTdcqvxvxeCkQIFbflyPxXuVbppY(list);
		HzIGCxUrNBJCrzhVFizeZDaBxlTN = false;
	}

	private bool rjtoqtzNkxTHhupISIXRcvEEDOlLA(IList<ZnhcDWhSsvGoFpuQyaqClglYKkPD> P_0)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && !TRXLGictwqGqEeVJsEtBtZPLpBbg(P_0[i].ocbTYztmyxijHBBPAOjSLNJkimdu))
			{
				return true;
			}
		}
		int count2 = SbSIHYadlMFxGgPWuodfLDFULBxQ.Count;
		for (int j = 0; j < count2; j++)
		{
			if (SbSIHYadlMFxGgPWuodfLDFULBxQ[j] != null && !kifvoSsxcSdgYMnVNoUtUGdpvUx(P_0, SbSIHYadlMFxGgPWuodfLDFULBxQ[j].KvjOvtwfWBiVDwdshbHGJGSiOYipA))
			{
				return true;
			}
		}
		return false;
	}

	private bool TRXLGictwqGqEeVJsEtBtZPLpBbg(Guid P_0)
	{
		int count = SbSIHYadlMFxGgPWuodfLDFULBxQ.Count;
		for (int i = 0; i < count; i++)
		{
			if (SbSIHYadlMFxGgPWuodfLDFULBxQ[i] != null && SbSIHYadlMFxGgPWuodfLDFULBxQ[i].KvjOvtwfWBiVDwdshbHGJGSiOYipA == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool kifvoSsxcSdgYMnVNoUtUGdpvUx(IList<ZnhcDWhSsvGoFpuQyaqClglYKkPD> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].ocbTYztmyxijHBBPAOjSLNJkimdu == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void olwrmOFKKmAWqxnbJVgNgqemtRdh(List<NOQnaCfPLWczAzaLozNsZilVjsBL> P_0, List<NOQnaCfPLWczAzaLozNsZilVjsBL> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			NOQnaCfPLWczAzaLozNsZilVjsBL nOQnaCfPLWczAzaLozNsZilVjsBL = P_0[i];
			if (nOQnaCfPLWczAzaLozNsZilVjsBL == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					NOQnaCfPLWczAzaLozNsZilVjsBL nOQnaCfPLWczAzaLozNsZilVjsBL2 = P_1[j];
					if (nOQnaCfPLWczAzaLozNsZilVjsBL2 != null && nOQnaCfPLWczAzaLozNsZilVjsBL.KvjOvtwfWBiVDwdshbHGJGSiOYipA == nOQnaCfPLWczAzaLozNsZilVjsBL2.KvjOvtwfWBiVDwdshbHGJGSiOYipA)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				HChCxBihBHeOJAdNBusnlTNjwKgWb(P_0[i], P_2);
			}
		}
	}

	private void HChCxBihBHeOJAdNBusnlTNjwKgWb(NOQnaCfPLWczAzaLozNsZilVjsBL P_0, bool P_1)
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

	private void lwmuxIhINvCezEdzSeHyyiLMHDiCA()
	{
		if (ytgNvzObfDiQiIMwZXBJstemqVsF)
		{
			HzIGCxUrNBJCrzhVFizeZDaBxlTN = true;
		}
		SystemDeviceConnected();
	}
}
