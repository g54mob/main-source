using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Libraries.SharpDX.XInput;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class iJBgwMICNtsxCQITcDMiEfutRJOA : PlatformInputManager
{
	private class mktvZqLqiNHPUOBkcEORiAUZwMfL : IInputManagerJoystick, IInputManagerJoystickPublic, IDisposable
	{
		private bool ZecGFQzcoEwxEmjENydPiveGsUCA;

		private int jqqredMvAaFSGQEIAmnuIMwRFyel;

		private readonly int uAHBjxbATsyTurxjSCHPstFFfZYV;

		public Guid HAyxLvzwPoYtctDkWvIUuCEToQGl;

		public string AQbIGpWYKSNmWoAvuLBptQuXrzKi;

		public Guid beCaBgfbbqnnFQAxeivqYeUFcqWbA;

		public Rewired.Libraries.SharpDX.XInput.DeviceType mfVSrjYImYrkNKegRzpaWhfUZtuS;

		public XInputDeviceSubType GOoBmfcdKWtlPymAZTHADxVKGUOV;

		public bool pMttHiLqhJHtVNPnNNyOoHVqPiaG;

		public bool QIwmEYfQHzkYQbnAaMLBjrYhBLGFA;

		public bool SdSHAWIsIbJzTNQzNGIXyypuJadq;

		public bool caKqEkCbOmCTpcbVipHNeCnCxTqyB;

		private int frsGxYmNngWMiYXbQCBAugpYDCBX;

		private int KrwakueqDpOAfXkssOdavBZxzHDX;

		private int WIgyEAGrddZFfKJmaRAkabrHevjf;

		private int qxEGDLvKNkVlwzCirrPEolXWsSQO;

		private readonly float[] eTQvZDJtQRdPFwZxGhTkRMTRPsUD;

		private readonly bool[] dZIKiBiNeFNQceFmDCbnGwbIWGASA;

		private HardwareJoystickMap_InputManager FaQsMPlKHQHEPKKkGuZuFLuUwrw;

		public readonly XuefDHxaNwtvevAqswljAJrmkdGP JUbGYxGlyKymyyrMXiLloNpvYOS;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ZorWNIhpTpMpdOTfFGHHoJVMdrUj;

		private Action DqKzZUDbcBgvAzTbvzrYxAUzdypeA;

		private bool xDqLdhoPdYADfiiOBJJbqLpIRIsjA;

		private bool OtyxJemglyztqSPszRKsYDVqSUYo;

		private bool IGLabjAFnGXiwSEhcxGurjCXmgNab;

		public string wnUjyrGaeMNwhxTbqtVTNxcSSsvo
		{
			get
			{
				string text = jckYJrDgYtlxVJegBMzAUAOLwRRD;
				if (text == string.Empty)
				{
					return string.Empty;
				}
				int num = uAHBjxbATsyTurxjSCHPstFFfZYV;
				return text + " " + num;
			}
		}

		public string jckYJrDgYtlxVJegBMzAUAOLwRRD
		{
			get
			{
				if (!XJkOMmPmJldLduScaArHDKnjddzE)
				{
					return string.Empty;
				}
				return GOoBmfcdKWtlPymAZTHADxVKGUOV.ToString();
			}
		}

		public bool XJkOMmPmJldLduScaArHDKnjddzE
		{
			get
			{
				if (JUbGYxGlyKymyyrMXiLloNpvYOS == null || !caKqEkCbOmCTpcbVipHNeCnCxTqyB)
				{
					return false;
				}
				if (xDqLdhoPdYADfiiOBJJbqLpIRIsjA && !krAsdaSJsxiOJsaCkHPWIQNkaenVA(YbzJgKeTTWsWMjKfgBIaIPgcBFRo.Asynchronous))
				{
					atAGDgDwfixzESLmPIkJXcnEreJL();
				}
				return xDqLdhoPdYADfiiOBJJbqLpIRIsjA;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return jqqredMvAaFSGQEIAmnuIMwRFyel;
			}
			set
			{
				jqqredMvAaFSGQEIAmnuIMwRFyel = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId => uAHBjxbATsyTurxjSCHPstFFfZYV;

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (ZecGFQzcoEwxEmjENydPiveGsUCA)
				{
					return GOoBmfcdKWtlPymAZTHADxVKGUOV.ToString() + " " + (uAHBjxbATsyTurxjSCHPstFFfZYV + 1);
				}
				return "XInput " + GOoBmfcdKWtlPymAZTHADxVKGUOV.ToString() + " " + (uAHBjxbATsyTurxjSCHPstFFfZYV + 1);
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId => uAHBjxbATsyTurxjSCHPstFFfZYV;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension => null;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => beCaBgfbbqnnFQAxeivqYeUFcqWbA;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			JUbGYxGlyKymyyrMXiLloNpvYOS.ObYBLoHIvqQiYAiKAdjtAWpawNyYA(amount, motorIndex);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			JUbGYxGlyKymyyrMXiLloNpvYOS.UnFcWVuiNFpiGVPnkiXjrNlsblXq();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public mktvZqLqiNHPUOBkcEORiAUZwMfL(int P_0, bool P_1, XuefDHxaNwtvevAqswljAJrmkdGP P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Action P_4)
		{
			JUbGYxGlyKymyyrMXiLloNpvYOS = P_2;
			ZecGFQzcoEwxEmjENydPiveGsUCA = P_1;
			uAHBjxbATsyTurxjSCHPstFFfZYV = P_0;
			ZorWNIhpTpMpdOTfFGHHoJVMdrUj = P_3;
			DqKzZUDbcBgvAzTbvzrYxAUzdypeA = P_4;
			jqqredMvAaFSGQEIAmnuIMwRFyel = -1;
			frsGxYmNngWMiYXbQCBAugpYDCBX = 6;
			KrwakueqDpOAfXkssOdavBZxzHDX = 15;
			WIgyEAGrddZFfKJmaRAkabrHevjf = frsGxYmNngWMiYXbQCBAugpYDCBX;
			qxEGDLvKNkVlwzCirrPEolXWsSQO = KrwakueqDpOAfXkssOdavBZxzHDX;
			eTQvZDJtQRdPFwZxGhTkRMTRPsUD = new float[frsGxYmNngWMiYXbQCBAugpYDCBX];
			dZIKiBiNeFNQceFmDCbnGwbIWGASA = new bool[KrwakueqDpOAfXkssOdavBZxzHDX];
			LxUzJxygLecPjtbvfFXxXdnZnAMu();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			JUbGYxGlyKymyyrMXiLloNpvYOS.EbvzGNoedtlVIpRGSudOuCnTAfTg();
			bool[] array = JUbGYxGlyKymyyrMXiLloNpvYOS.SLvDlnVlnuNtqwTWSvmmVGeeACtI;
			qoRGmUAUMPTitTayIGPtrMTBLiRU(array, ref JUbGYxGlyKymyyrMXiLloNpvYOS.zDhPVYqWgphMswhpDDVSTFtbfyQc);
			tKmqxGJTTEUDcAPKCyaIEoLtqGhd(array, ref JUbGYxGlyKymyyrMXiLloNpvYOS.zDhPVYqWgphMswhpDDVSTFtbfyQc);
			JUbGYxGlyKymyyrMXiLloNpvYOS.GtZisfcduqYRtmihmAtECgmjzSQp();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public void krTzlsykNPGwhrtkvBBiOawsQtei(bool P_0)
		{
			if (JUbGYxGlyKymyyrMXiLloNpvYOS != null)
			{
				SdSHAWIsIbJzTNQzNGIXyypuJadq = P_0;
			}
		}

		public bool krAsdaSJsxiOJsaCkHPWIQNkaenVA(YbzJgKeTTWsWMjKfgBIaIPgcBFRo P_0)
		{
			VaBfCEQHbbJPzoWAXEHHfaOFOozNA(RlGCiEASRQalzdPNDqxQPRTLWJCiA(P_0));
			return xDqLdhoPdYADfiiOBJJbqLpIRIsjA;
		}

		public bool RlGCiEASRQalzdPNDqxQPRTLWJCiA(YbzJgKeTTWsWMjKfgBIaIPgcBFRo P_0)
		{
			if (JUbGYxGlyKymyyrMXiLloNpvYOS == null)
			{
				return false;
			}
			return JUbGYxGlyKymyyrMXiLloNpvYOS.cikZkQOBCAwUBwKUMmBzVWwdRTgi(P_0);
		}

		public void VaBfCEQHbbJPzoWAXEHHfaOFOozNA(bool P_0)
		{
			xDqLdhoPdYADfiiOBJJbqLpIRIsjA = P_0;
		}

		public void EOCWmQfiLRaDktRgdbGcxCUXdswt()
		{
			if (!caKqEkCbOmCTpcbVipHNeCnCxTqyB || fIXndhqhljrRkOdRYOYdxVxIUCjx())
			{
				LxUzJxygLecPjtbvfFXxXdnZnAMu();
			}
			if (caKqEkCbOmCTpcbVipHNeCnCxTqyB && xDqLdhoPdYADfiiOBJJbqLpIRIsjA)
			{
				JUbGYxGlyKymyyrMXiLloNpvYOS.sccfNafvvDmMIcQDUIlleipAkTJxB();
			}
		}

		public void qKqpuapYXUUdaUFlYDFKhayDblGaA()
		{
			jqqredMvAaFSGQEIAmnuIMwRFyel = -1;
			caKqEkCbOmCTpcbVipHNeCnCxTqyB = false;
			JUbGYxGlyKymyyrMXiLloNpvYOS.QhanVSXhMHWKHcBBJNYMFltusNGj();
			Array.Clear(eTQvZDJtQRdPFwZxGhTkRMTRPsUD, 0, eTQvZDJtQRdPFwZxGhTkRMTRPsUD.Length);
			Array.Clear(dZIKiBiNeFNQceFmDCbnGwbIWGASA, 0, dZIKiBiNeFNQceFmDCbnGwbIWGASA.Length);
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (frsGxYmNngWMiYXbQCBAugpYDCBX != dataUpdater.axisCount || KrwakueqDpOAfXkssOdavBZxzHDX != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < frsGxYmNngWMiYXbQCBAugpYDCBX; i++)
			{
				dataUpdater.axisValues[i] = eTQvZDJtQRdPFwZxGhTkRMTRPsUD[i];
			}
			for (int j = 0; j < KrwakueqDpOAfXkssOdavBZxzHDX; j++)
			{
				dataUpdater.buttonValues[j] = dZIKiBiNeFNQceFmDCbnGwbIWGASA[j];
			}
			if (OtyxJemglyztqSPszRKsYDVqSUYo && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public BridgedControllerHWInfo uSkozRXUaFuUayDpHeUQTEKYNKwe()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			WPFaqJmcePamdSzdNQQQHLowUTQd(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			WvZPThgVYfBRthqezpaMManJtxFE(bridgedController);
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
			return new ControllerDisconnectedEventArgs(jqqredMvAaFSGQEIAmnuIMwRFyel);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void LxUzJxygLecPjtbvfFXxXdnZnAMu()
		{
			if (JUbGYxGlyKymyyrMXiLloNpvYOS == null || !krAsdaSJsxiOJsaCkHPWIQNkaenVA(YbzJgKeTTWsWMjKfgBIaIPgcBFRo.Synchronous))
			{
				return;
			}
			try
			{
				gNLWiShIENFcfjXhkVTGaHdQaJhD();
				ZPZgVGbxrAyXJFtcFqZXyNlZexJX zPZgVGbxrAyXJFtcFqZXyNlZexJX = JUbGYxGlyKymyyrMXiLloNpvYOS.oiWFrfllcwKRDwvnZWWHvETDICmT.HjBVskpNNfyvIHbAUcDuUxkgBaaH(kwsWRBKxVgkhqFFDlrNAqajbFDTBA.Any);
				mfVSrjYImYrkNKegRzpaWhfUZtuS = zPZgVGbxrAyXJFtcFqZXyNlZexJX.qUObQDBEtKfnCPiNSgJAIuEGNTtxA;
				GOoBmfcdKWtlPymAZTHADxVKGUOV = (XInputDeviceSubType)zPZgVGbxrAyXJFtcFqZXyNlZexJX.PEhfpnpNsfpoMtYQNJhCtcOkRPoo;
				if (JUbGYxGlyKymyyrMXiLloNpvYOS.oiWFrfllcwKRDwvnZWWHvETDICmT.HBfxEcxYhwcaEIPcWCQoLGeTuZSF(default(VgOyTCkBfUisISRqngkvhzxaTaRIA)).zgGgBJaZGIhgHSVxTCWwZCDNKQXcA)
				{
					pMttHiLqhJHtVNPnNNyOoHVqPiaG = true;
				}
				QIwmEYfQHzkYQbnAaMLBjrYhBLGFA = (zPZgVGbxrAyXJFtcFqZXyNlZexJX.WJaDBdCbdLdGagoGqpKeYZCuvxco & vxSDxtaKEElMCjfzztrmxjSAhsOf.VoiceSupported) == vxSDxtaKEElMCjfzztrmxjSAhsOf.VoiceSupported;
				TFulclbyiFCkkQKeNVPiZDIytSrx();
				HAyxLvzwPoYtctDkWvIUuCEToQGl = FaQsMPlKHQHEPKKkGuZuFLuUwrw.hardwareMapIdentifier.guid;
				AQbIGpWYKSNmWoAvuLBptQuXrzKi = FaQsMPlKHQHEPKKkGuZuFLuUwrw.controllerName;
				JUbGYxGlyKymyyrMXiLloNpvYOS.sccfNafvvDmMIcQDUIlleipAkTJxB();
				beCaBgfbbqnnFQAxeivqYeUFcqWbA = MiscTools.CreateGuidHashSHA1(string.Concat(mfVSrjYImYrkNKegRzpaWhfUZtuS, GOoBmfcdKWtlPymAZTHADxVKGUOV, uAHBjxbATsyTurxjSCHPstFFfZYV));
				caKqEkCbOmCTpcbVipHNeCnCxTqyB = true;
			}
			catch (Exception)
			{
				caKqEkCbOmCTpcbVipHNeCnCxTqyB = false;
				xDqLdhoPdYADfiiOBJJbqLpIRIsjA = false;
				beCaBgfbbqnnFQAxeivqYeUFcqWbA = Guid.Empty;
			}
		}

		private bool fIXndhqhljrRkOdRYOYdxVxIUCjx()
		{
			try
			{
				if (GOoBmfcdKWtlPymAZTHADxVKGUOV != (XInputDeviceSubType)JUbGYxGlyKymyyrMXiLloNpvYOS.oiWFrfllcwKRDwvnZWWHvETDICmT.HjBVskpNNfyvIHbAUcDuUxkgBaaH(kwsWRBKxVgkhqFFDlrNAqajbFDTBA.Any).PEhfpnpNsfpoMtYQNJhCtcOkRPoo)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private void gNLWiShIENFcfjXhkVTGaHdQaJhD()
		{
			QIwmEYfQHzkYQbnAaMLBjrYhBLGFA = false;
			pMttHiLqhJHtVNPnNNyOoHVqPiaG = false;
			SdSHAWIsIbJzTNQzNGIXyypuJadq = false;
			caKqEkCbOmCTpcbVipHNeCnCxTqyB = false;
		}

		private void atAGDgDwfixzESLmPIkJXcnEreJL()
		{
			if (DqKzZUDbcBgvAzTbvzrYxAUzdypeA != null)
			{
				DqKzZUDbcBgvAzTbvzrYxAUzdypeA();
			}
			JUbGYxGlyKymyyrMXiLloNpvYOS.QhanVSXhMHWKHcBBJNYMFltusNGj();
		}

		private void qoRGmUAUMPTitTayIGPtrMTBLiRU(bool[] P_0, ref kFZDBEkoCZGcWyRPqSWxGvIVtaLr P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_XInput_Base)FaQsMPlKHQHEPKKkGuZuFLuUwrw.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (i >= frsGxYmNngWMiYXbQCBAugpYDCBX)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				eTQvZDJtQRdPFwZxGhTkRMTRPsUD[i] = mRSFilGHgWdKwaTMckuDHDqXZISsb(axes_orig[i], P_0, ref P_1);
				if (!OtyxJemglyztqSPszRKsYDVqSUYo && eTQvZDJtQRdPFwZxGhTkRMTRPsUD[i] != 0f)
				{
					OtyxJemglyztqSPszRKsYDVqSUYo = true;
				}
			}
		}

		private void tKmqxGJTTEUDcAPKCyaIEoLtqGhd(bool[] P_0, ref kFZDBEkoCZGcWyRPqSWxGvIVtaLr P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_XInput_Base)FaQsMPlKHQHEPKKkGuZuFLuUwrw.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= KrwakueqDpOAfXkssOdavBZxzHDX)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				dZIKiBiNeFNQceFmDCbnGwbIWGASA[i] = NSJdOPYUJEVluyXCgiOEmhRAaOnR(buttons_orig[i], P_0, ref P_1);
				if (!OtyxJemglyztqSPszRKsYDVqSUYo && dZIKiBiNeFNQceFmDCbnGwbIWGASA[i])
				{
					OtyxJemglyztqSPszRKsYDVqSUYo = true;
				}
			}
		}

		private float mRSFilGHgWdKwaTMckuDHDqXZISsb(HardwareJoystickMap.Platform_XInput_Base.Axis P_0, bool[] P_1, ref kFZDBEkoCZGcWyRPqSWxGvIVtaLr P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return 0f;
				}
				return QvRbvFTURZmntuUoAAHBGhRMeNScA(P_0.sourceAxis, ref P_2);
			}
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return 0f;
				}
				if (!DgheHqiCATPuURBrsMOWWWHtjQdV(P_0.sourceButton, P_1))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			return 0f;
		}

		private float QvRbvFTURZmntuUoAAHBGhRMeNScA(XInputAxis P_0, ref kFZDBEkoCZGcWyRPqSWxGvIVtaLr P_1)
		{
			return P_0 switch
			{
				XInputAxis.LeftThumbX => XuefDHxaNwtvevAqswljAJrmkdGP.PqNstGyFvZwhMCFqqbDahhmFqAWA(P_1.LmUHEQvGjwMjaYJmamgyoGJFTyPU), 
				XInputAxis.LeftThumbY => XuefDHxaNwtvevAqswljAJrmkdGP.PqNstGyFvZwhMCFqqbDahhmFqAWA(P_1.yrNNKTfnwsThgdNlAmbQRxsgymOB), 
				XInputAxis.RightThumbX => XuefDHxaNwtvevAqswljAJrmkdGP.PqNstGyFvZwhMCFqqbDahhmFqAWA(P_1.JOLFBidEQPtOBpdoihipFzrYTPRoA), 
				XInputAxis.RightThumbY => XuefDHxaNwtvevAqswljAJrmkdGP.PqNstGyFvZwhMCFqqbDahhmFqAWA(P_1.pyScHYIHmViFPGnMOnAlqfmxlJOYA), 
				XInputAxis.LeftTrigger => XuefDHxaNwtvevAqswljAJrmkdGP.drEnsaSGMeGbczSFVlRKFteCFcwh(P_1.ByqpfWnUopokKKBCFoMnZfjcqNsq), 
				XInputAxis.RightTrigger => XuefDHxaNwtvevAqswljAJrmkdGP.drEnsaSGMeGbczSFVlRKFteCFcwh(P_1.GjVDbZrcFmMCKotMKdrPyQLFjfhr), 
				_ => 0f, 
			};
		}

		private bool NSJdOPYUJEVluyXCgiOEmhRAaOnR(HardwareJoystickMap.Platform_XInput_Base.Button P_0, bool[] P_1, ref kFZDBEkoCZGcWyRPqSWxGvIVtaLr P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return false;
				}
				return DgheHqiCATPuURBrsMOWWWHtjQdV(P_0.sourceButton, P_1);
			}
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return false;
				}
				float num = QvRbvFTURZmntuUoAAHBGhRMeNScA(P_0.sourceAxis, ref P_2);
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
			return false;
		}

		private bool DgheHqiCATPuURBrsMOWWWHtjQdV(XInputButton P_0, bool[] P_1)
		{
			return P_0 switch
			{
				XInputButton.DPadUp => P_1[0], 
				XInputButton.DPadDown => P_1[1], 
				XInputButton.DPadLeft => P_1[2], 
				XInputButton.DPadRight => P_1[3], 
				XInputButton.Start => P_1[4], 
				XInputButton.Back => P_1[5], 
				XInputButton.LeftThumb => P_1[6], 
				XInputButton.RightThumb => P_1[7], 
				XInputButton.LeftShoulder => P_1[8], 
				XInputButton.RightShoulder => P_1[9], 
				XInputButton.Guide => P_1[10], 
				XInputButton.A => P_1[11], 
				XInputButton.B => P_1[12], 
				XInputButton.X => P_1[13], 
				XInputButton.Y => P_1[14], 
				_ => false, 
			};
		}

		private void TFulclbyiFCkkQKeNVPiZDIytSrx()
		{
			FaQsMPlKHQHEPKKkGuZuFLuUwrw = ZorWNIhpTpMpdOTfFGHHoJVMdrUj(uSkozRXUaFuUayDpHeUQTEKYNKwe());
			if (FaQsMPlKHQHEPKKkGuZuFLuUwrw == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			frsGxYmNngWMiYXbQCBAugpYDCBX = FaQsMPlKHQHEPKKkGuZuFLuUwrw.axisCount;
			KrwakueqDpOAfXkssOdavBZxzHDX = FaQsMPlKHQHEPKKkGuZuFLuUwrw.buttonCount;
		}

		private bool evfdkIJESVNZorOHtFdbSRdqxQvPA(ref VgOyTCkBfUisISRqngkvhzxaTaRIA P_0)
		{
			if (P_0.ViUGCyvuVuAPFeLFUSajAFSNqQEvA > 0 || P_0.IOafBsvtXyoYBbdMyNmqeTiflmRp > 0)
			{
				return true;
			}
			return false;
		}

		private void ZrjGSZgCoyLNSVKwbFPGbVjuUEvP(ref VgOyTCkBfUisISRqngkvhzxaTaRIA P_0)
		{
			P_0.ViUGCyvuVuAPFeLFUSajAFSNqQEvA = 0;
			P_0.IOafBsvtXyoYBbdMyNmqeTiflmRp = 0;
		}

		private void WtklzIsfnLBCKLIFnHXrrENzYHOR(ref VgOyTCkBfUisISRqngkvhzxaTaRIA P_0, ref VgOyTCkBfUisISRqngkvhzxaTaRIA P_1)
		{
			P_1.ViUGCyvuVuAPFeLFUSajAFSNqQEvA = P_0.ViUGCyvuVuAPFeLFUSajAFSNqQEvA;
			P_1.IOafBsvtXyoYBbdMyNmqeTiflmRp = P_0.IOafBsvtXyoYBbdMyNmqeTiflmRp;
		}

		private string dmwLeknOqkAMmIUnnmboEyJhjyneb()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.XInput.ToString()}{mfVSrjYImYrkNKegRzpaWhfUZtuS.ToString()}{GOoBmfcdKWtlPymAZTHADxVKGUOV.ToString()}");
		}

		private void WPFaqJmcePamdSzdNQQQHLowUTQd(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.XInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = ControlDeviceType.Unknown;
			P_0.hardwareIdentifier = dmwLeknOqkAMmIUnnmboEyJhjyneb();
			P_0.hardwareAxisCount = WIgyEAGrddZFfKJmaRAkabrHevjf;
			P_0.hardwareButtonCount = qxEGDLvKNkVlwzCirrPEolXWsSQO;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = jckYJrDgYtlxVJegBMzAUAOLwRRD;
			P_0.hw_supportsVoice = QIwmEYfQHzkYQbnAaMLBjrYhBLGFA;
			P_0.hw_supportsVibration = pMttHiLqhJHtVNPnNNyOoHVqPiaG;
			P_0.hw_localVibrationMotorCount = (pMttHiLqhJHtVNPnNNyOoHVqPiaG ? 2 : 0);
			P_0.hw_xInputSubType = GOoBmfcdKWtlPymAZTHADxVKGUOV;
		}

		private void WvZPThgVYfBRthqezpaMManJtxFE(BridgedController P_0)
		{
			WPFaqJmcePamdSzdNQQQHLowUTQd(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = FaQsMPlKHQHEPKKkGuZuFLuUwrw.ToGameHardwareControllerMap();
			P_0.instanceName = "XInput " + wnUjyrGaeMNwhxTbqtVTNxcSSsvo;
			P_0.productName = "XInput " + jckYJrDgYtlxVJegBMzAUAOLwRRD;
			P_0.isXInputDevice = true;
			P_0.axisCount = frsGxYmNngWMiYXbQCBAugpYDCBX;
			P_0.buttonCount = KrwakueqDpOAfXkssOdavBZxzHDX;
			P_0.controllerTypeGuid = HAyxLvzwPoYtctDkWvIUuCEToQGl;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		public void Dispose()
		{
			EvVCBNmUKbUnuxkhYPDLFsRsurXA(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void QqtjtplXACANrPEFQQlviyXFmPVJ()
		{
			try
			{
				EvVCBNmUKbUnuxkhYPDLFsRsurXA(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void EvVCBNmUKbUnuxkhYPDLFsRsurXA(bool P_0)
		{
			if (IGLabjAFnGXiwSEhcxGurjCXmgNab)
			{
				return;
			}
			if (P_0)
			{
				if (XJkOMmPmJldLduScaArHDKnjddzE)
				{
					JUbGYxGlyKymyyrMXiLloNpvYOS.zfQlFfiZlvJDcmkyNbBMqCYqSkJQ();
				}
				if (JUbGYxGlyKymyyrMXiLloNpvYOS != null)
				{
					JUbGYxGlyKymyyrMXiLloNpvYOS.Dispose();
				}
			}
			IGLabjAFnGXiwSEhcxGurjCXmgNab = true;
		}
	}

	private class vvYLGkDbzPGSZNaxLbmPbXIibWkgA
	{
		private class xMNxdGRILYgKxenMfLZPVDZacBDN
		{
			public bool YGubPaKnYDGlPhrRGDIQgTueGejS;

			public int fXlheGgHysZibjTchrUaOSEiaZpD;

			public XInputDeviceSubType XaZhgkYNwPOoMQaJEhpZitrtHEZU;

			public void vLJgCEhLcwQDxKigcctQAYWEfaWL(mktvZqLqiNHPUOBkcEORiAUZwMfL P_0, bool P_1)
			{
				YGubPaKnYDGlPhrRGDIQgTueGejS = P_1;
				fXlheGgHysZibjTchrUaOSEiaZpD = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
				XaZhgkYNwPOoMQaJEhpZitrtHEZU = P_0.GOoBmfcdKWtlPymAZTHADxVKGUOV;
			}

			public xMNxdGRILYgKxenMfLZPVDZacBDN(int P_0, XInputDeviceSubType P_1)
			{
				fXlheGgHysZibjTchrUaOSEiaZpD = P_0;
				XaZhgkYNwPOoMQaJEhpZitrtHEZU = P_1;
			}
		}

		private List<xMNxdGRILYgKxenMfLZPVDZacBDN> rWEHJPfPlTRGtbLZmakCjrQYMoxcA;

		public vvYLGkDbzPGSZNaxLbmPbXIibWkgA()
		{
			rWEHJPfPlTRGtbLZmakCjrQYMoxcA = new List<xMNxdGRILYgKxenMfLZPVDZacBDN>();
		}

		public void gqgOvdWHcedrePsUzBTxiHPDOvHtA(mktvZqLqiNHPUOBkcEORiAUZwMfL P_0, bool P_1)
		{
			if (pymxQWFiikwkkyYZGvdJfwCTNTDB(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.GOoBmfcdKWtlPymAZTHADxVKGUOV, true) < 0)
			{
				xMNxdGRILYgKxenMfLZPVDZacBDN xMNxdGRILYgKxenMfLZPVDZacBDN2 = new xMNxdGRILYgKxenMfLZPVDZacBDN(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.GOoBmfcdKWtlPymAZTHADxVKGUOV);
				xMNxdGRILYgKxenMfLZPVDZacBDN2.YGubPaKnYDGlPhrRGDIQgTueGejS = P_1;
				rWEHJPfPlTRGtbLZmakCjrQYMoxcA.Add(xMNxdGRILYgKxenMfLZPVDZacBDN2);
			}
		}

		public void iTjuCkOSPsOrTwWunVMpNojXIKnh(int P_0, mktvZqLqiNHPUOBkcEORiAUZwMfL P_1, bool P_2)
		{
			if (P_0 >= 0 && P_0 < rWEHJPfPlTRGtbLZmakCjrQYMoxcA.Count)
			{
				rWEHJPfPlTRGtbLZmakCjrQYMoxcA[P_0].vLJgCEhLcwQDxKigcctQAYWEfaWL(P_1, P_2);
			}
		}

		public int SXFxViYmuvgxeEpJxwFuqkYCSwZlA(XInputDeviceSubType P_0, bool P_1)
		{
			int count = rWEHJPfPlTRGtbLZmakCjrQYMoxcA.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_1 || !rWEHJPfPlTRGtbLZmakCjrQYMoxcA[i].YGubPaKnYDGlPhrRGDIQgTueGejS) && rWEHJPfPlTRGtbLZmakCjrQYMoxcA[i].XaZhgkYNwPOoMQaJEhpZitrtHEZU == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		public int pymxQWFiikwkkyYZGvdJfwCTNTDB(int P_0, XInputDeviceSubType P_1, bool P_2)
		{
			int count = rWEHJPfPlTRGtbLZmakCjrQYMoxcA.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_2 || !rWEHJPfPlTRGtbLZmakCjrQYMoxcA[i].YGubPaKnYDGlPhrRGDIQgTueGejS) && rWEHJPfPlTRGtbLZmakCjrQYMoxcA[i].fXlheGgHysZibjTchrUaOSEiaZpD == P_0 && rWEHJPfPlTRGtbLZmakCjrQYMoxcA[i].XaZhgkYNwPOoMQaJEhpZitrtHEZU == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		public int PTJHXzcrkvOklUMBQiMxuFWQHFso(int P_0)
		{
			if (P_0 < 0 || P_0 >= rWEHJPfPlTRGtbLZmakCjrQYMoxcA.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return rWEHJPfPlTRGtbLZmakCjrQYMoxcA[P_0].fXlheGgHysZibjTchrUaOSEiaZpD;
		}

		public void ZdhPONFoiGUegtMQkxNftSUEsASi(int P_0, bool P_1)
		{
			if (P_0 >= 0 && P_0 < rWEHJPfPlTRGtbLZmakCjrQYMoxcA.Count)
			{
				rWEHJPfPlTRGtbLZmakCjrQYMoxcA[P_0].YGubPaKnYDGlPhrRGDIQgTueGejS = P_1;
			}
		}
	}

	private class wCFbSldxIEAZqtUDpOxBCwjBMacub
	{
		public bool hgeKeaoMSXaPcejtqETxkjwOgclDA;

		private double ZbBBZcDlBRnfFAlgFiqxzTmRFegGb;

		public float StCPcWQaxAuVQRVbuiKGgqQKOuLm;

		public wCFbSldxIEAZqtUDpOxBCwjBMacub()
		{
		}

		public wCFbSldxIEAZqtUDpOxBCwjBMacub(float P_0)
		{
			StCPcWQaxAuVQRVbuiKGgqQKOuLm = P_0;
		}

		public void vipEKxaKadjTGEEELnpOdcJGktuyA()
		{
			hgeKeaoMSXaPcejtqETxkjwOgclDA = true;
			ZbBBZcDlBRnfFAlgFiqxzTmRFegGb = (double)StCPcWQaxAuVQRVbuiKGgqQKOuLm + ReInput.unscaledTime;
		}

		public void IblBEApkvLtobZoxmWrmgwzjjpHI(float P_0)
		{
			hgeKeaoMSXaPcejtqETxkjwOgclDA = true;
			StCPcWQaxAuVQRVbuiKGgqQKOuLm = P_0;
			ZbBBZcDlBRnfFAlgFiqxzTmRFegGb = (double)StCPcWQaxAuVQRVbuiKGgqQKOuLm + ReInput.unscaledTime;
		}

		public bool IJlSgHKnPXHqKCNwqOxdwLXHSRlT()
		{
			if (!hgeKeaoMSXaPcejtqETxkjwOgclDA)
			{
				return false;
			}
			if (ReInput.unscaledTime >= ZbBBZcDlBRnfFAlgFiqxzTmRFegGb)
			{
				hgeKeaoMSXaPcejtqETxkjwOgclDA = false;
				return true;
			}
			return false;
		}

		public void KvyJZaWBzjTEXIIRuIivIlhTIJtD()
		{
			hgeKeaoMSXaPcejtqETxkjwOgclDA = false;
			ZbBBZcDlBRnfFAlgFiqxzTmRFegGb = 0.0;
		}

		public void AUXuDvLgRJlFOeFfwHRTTfOLiTSD(float P_0)
		{
			StCPcWQaxAuVQRVbuiKGgqQKOuLm = P_0;
		}

		public wCFbSldxIEAZqtUDpOxBCwjBMacub CogmixoNhsESGChiehyAHHlPmIXHb()
		{
			return (wCFbSldxIEAZqtUDpOxBCwjBMacub)MemberwiseClone();
		}
	}

	public class XuefDHxaNwtvevAqswljAJrmkdGP : IDisposable
	{
		public readonly ofXpjCnmsnfKFMCIaEhNMWozSAtl oiWFrfllcwKRDwvnZWWHvETDICmT;

		public kFZDBEkoCZGcWyRPqSWxGvIVtaLr zDhPVYqWgphMswhpDDVSTFtbfyQc;

		private bool eDznINicpbjusPFrzbAcKJfaBWLA;

		private readonly ButtonLoopSet ydwvOpcqwbibmeNdEQVwMUYWpnyN;

		private kFZDBEkoCZGcWyRPqSWxGvIVtaLr WqDQpuJJXsvRwvEVucFPfaXoFmuS;

		private bool nWAXSdEtdgTSgtGCqWQFCYHeJOHi;

		private DualThreadLowLevelInputEventQueue zgmCDVzBtGwmTnNcSNuJINRsCjXkA;

		private readonly object HrTNUSpmJDDmKekjlCQDowzbAWOg;

		private RingBuffer<VgOyTCkBfUisISRqngkvhzxaTaRIA> zDCSWGFFgARgNupxgohtOaaNPgKH = new RingBuffer<VgOyTCkBfUisISRqngkvhzxaTaRIA>(5);

		private RingBuffer<VgOyTCkBfUisISRqngkvhzxaTaRIA> VKUimuOtCLelcenvuqVtXDMHWYAo = new RingBuffer<VgOyTCkBfUisISRqngkvhzxaTaRIA>(5);

		private readonly object dsGCeSkUgyZDZjXwylQkftlwTzqcA = new object();

		private readonly object HJAwnooZEjOkYHmzZvFZnoPribBy = new object();

		private VgOyTCkBfUisISRqngkvhzxaTaRIA POiUpLByrmYhGiMyXNKopwHtjRsI;

		private double rtjcdYkvYtyKZyxARTtsQBmOoIPO;

		private bool KFkTpWoecyuZNspRSqmfkpmoGkDU;

		public bool[] SLvDlnVlnuNtqwTWSvmmVGeeACtI => ydwvOpcqwbibmeNdEQVwMUYWpnyN.Current.effectiveValue;

		public XuefDHxaNwtvevAqswljAJrmkdGP(int P_0, UpdateLoopSetting P_1)
		{
			oiWFrfllcwKRDwvnZWWHvETDICmT = new ofXpjCnmsnfKFMCIaEhNMWozSAtl((SyPeGQSMVTzOjUCpHCdTfJBjsAtGA)P_0);
			ydwvOpcqwbibmeNdEQVwMUYWpnyN = new ButtonLoopSet(P_1, 15);
			HrTNUSpmJDDmKekjlCQDowzbAWOg = new object();
			zgmCDVzBtGwmTnNcSNuJINRsCjXkA = new DualThreadLowLevelInputEventQueue((int)((float)lOimudEEADkCsfXveaIQPguQeEbk.UkYuObHPviBjKuyijpofFIgljEwT * 0.25f), 15, 6, 0);
		}

		public void EbvzGNoedtlVIpRGSudOuCnTAfTg()
		{
			ydwvOpcqwbibmeNdEQVwMUYWpnyN.SetUpdateLoop(ReInput.currentUpdateLoop);
			ALZOtKMjtqCYJZCFZXOOqXNFkRCQ(ref zDhPVYqWgphMswhpDDVSTFtbfyQc);
		}

		public void GtZisfcduqYRtmihmAtECgmjzSQp()
		{
			MDkywSteigFyykAuaxhtUeTDsAqb();
			ydwvOpcqwbibmeNdEQVwMUYWpnyN.Current.ClearWasTrueThisFrame();
		}

		public void sccfNafvvDmMIcQDUIlleipAkTJxB()
		{
			ruPFhYIPAmdAHNpoOWIqctzIdJwH();
			eDznINicpbjusPFrzbAcKJfaBWLA = true;
			nWAXSdEtdgTSgtGCqWQFCYHeJOHi = oiWFrfllcwKRDwvnZWWHvETDICmT.IWbLYNMluIhRKbYgrkONYbgHGPLH;
		}

		public void QhanVSXhMHWKHcBBJNYMFltusNGj()
		{
			eDznINicpbjusPFrzbAcKJfaBWLA = false;
			nWAXSdEtdgTSgtGCqWQFCYHeJOHi = false;
			ruPFhYIPAmdAHNpoOWIqctzIdJwH();
		}

		public bool cikZkQOBCAwUBwKUMmBzVWwdRTgi(YbzJgKeTTWsWMjKfgBIaIPgcBFRo P_0)
		{
			return P_0 switch
			{
				YbzJgKeTTWsWMjKfgBIaIPgcBFRo.Synchronous => nWAXSdEtdgTSgtGCqWQFCYHeJOHi = oiWFrfllcwKRDwvnZWWHvETDICmT.IWbLYNMluIhRKbYgrkONYbgHGPLH, 
				YbzJgKeTTWsWMjKfgBIaIPgcBFRo.Asynchronous => nWAXSdEtdgTSgtGCqWQFCYHeJOHi, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void ObYBLoHIvqQiYAiKAdjtAWpawNyYA(float P_0, int P_1)
		{
			switch (P_1)
			{
			case 0:
				POiUpLByrmYhGiMyXNKopwHtjRsI.ViUGCyvuVuAPFeLFUSajAFSNqQEvA = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			case 1:
				POiUpLByrmYhGiMyXNKopwHtjRsI.IOafBsvtXyoYBbdMyNmqeTiflmRp = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			}
			lRAfBiJliPoXXyFiEtxgtraWLWYZ();
		}

		public void UnFcWVuiNFpiGVPnkiXjrNlsblXq()
		{
			POiUpLByrmYhGiMyXNKopwHtjRsI.ViUGCyvuVuAPFeLFUSajAFSNqQEvA = 0;
			POiUpLByrmYhGiMyXNKopwHtjRsI.IOafBsvtXyoYBbdMyNmqeTiflmRp = 0;
			lRAfBiJliPoXXyFiEtxgtraWLWYZ();
		}

		public void zfQlFfiZlvJDcmkyNbBMqCYqSkJQ()
		{
			POiUpLByrmYhGiMyXNKopwHtjRsI.ViUGCyvuVuAPFeLFUSajAFSNqQEvA = 0;
			POiUpLByrmYhGiMyXNKopwHtjRsI.IOafBsvtXyoYBbdMyNmqeTiflmRp = 0;
			lock (HJAwnooZEjOkYHmzZvFZnoPribBy)
			{
				lock (dsGCeSkUgyZDZjXwylQkftlwTzqcA)
				{
					zDCSWGFFgARgNupxgohtOaaNPgKH.Clear();
					VKUimuOtCLelcenvuqVtXDMHWYAo.Clear();
					RoUJUHIxeGsSTlNqPAxahRXhlZjh(oiWFrfllcwKRDwvnZWWHvETDICmT, POiUpLByrmYhGiMyXNKopwHtjRsI, ref rtjcdYkvYtyKZyxARTtsQBmOoIPO);
				}
			}
		}

		public void uWQHFfhUsVIiTKvbgRggXUkWstUI()
		{
			if (!eDznINicpbjusPFrzbAcKJfaBWLA || !nWAXSdEtdgTSgtGCqWQFCYHeJOHi)
			{
				return;
			}
			EFuZxUthyxEKBIgUnCFZfCcqupNqA eFuZxUthyxEKBIgUnCFZfCcqupNqA;
			double realTime;
			try
			{
				if (!oiWFrfllcwKRDwvnZWWHvETDICmT.SVCEqJdUFNkCZzUjrdSEEfUGaTtgb(out eFuZxUthyxEKBIgUnCFZfCcqupNqA))
				{
					nWAXSdEtdgTSgtGCqWQFCYHeJOHi = false;
					return;
				}
				realTime = ReInput.realTime;
			}
			catch
			{
				nWAXSdEtdgTSgtGCqWQFCYHeJOHi = false;
				return;
			}
			lock (HrTNUSpmJDDmKekjlCQDowzbAWOg)
			{
				if (!vHjuiUlnPtAabdiPAEypFsXJXNaqb(eFuZxUthyxEKBIgUnCFZfCcqupNqA.uCCxivPNsqmbrZfeZLnmgCSpeJZH, WqDQpuJJXsvRwvEVucFPfaXoFmuS))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = zgmCDVzBtGwmTnNcSNuJINRsCjXkA.T_CreateEvent())
					{
						RJhQLXafiDAHXyxTgDkSJlFbBpcs(ref eFuZxUthyxEKBIgUnCFZfCcqupNqA.uCCxivPNsqmbrZfeZLnmgCSpeJZH, realTime, newEventWrapper.Event);
					}
					WqDQpuJJXsvRwvEVucFPfaXoFmuS = eFuZxUthyxEKBIgUnCFZfCcqupNqA.uCCxivPNsqmbrZfeZLnmgCSpeJZH;
				}
			}
		}

		public void kpzbKxDWusAQdecIYsfapwqvUIBX()
		{
			if (!eDznINicpbjusPFrzbAcKJfaBWLA || !nWAXSdEtdgTSgtGCqWQFCYHeJOHi || ReInput.realTime < rtjcdYkvYtyKZyxARTtsQBmOoIPO + 0.009999999776482582)
			{
				return;
			}
			lock (HJAwnooZEjOkYHmzZvFZnoPribBy)
			{
				lock (dsGCeSkUgyZDZjXwylQkftlwTzqcA)
				{
					MiscTools.Swap(ref zDCSWGFFgARgNupxgohtOaaNPgKH, ref VKUimuOtCLelcenvuqVtXDMHWYAo);
				}
				iuMEhPMbboliHvoiJhIrUzsPTZU(VKUimuOtCLelcenvuqVtXDMHWYAo, oiWFrfllcwKRDwvnZWWHvETDICmT, ref rtjcdYkvYtyKZyxARTtsQBmOoIPO);
			}
		}

		private void MDkywSteigFyykAuaxhtUeTDsAqb()
		{
			IybGpvJxubaveMuJRZRQuxiDXcbg();
		}

		private void IybGpvJxubaveMuJRZRQuxiDXcbg()
		{
			if (!(ReInput.realTime < rtjcdYkvYtyKZyxARTtsQBmOoIPO + 1.5) && (!Mathf.Approximately((int)POiUpLByrmYhGiMyXNKopwHtjRsI.ViUGCyvuVuAPFeLFUSajAFSNqQEvA, 0f) || !Mathf.Approximately((int)POiUpLByrmYhGiMyXNKopwHtjRsI.IOafBsvtXyoYBbdMyNmqeTiflmRp, 0f)))
			{
				lRAfBiJliPoXXyFiEtxgtraWLWYZ();
			}
		}

		private void lRAfBiJliPoXXyFiEtxgtraWLWYZ()
		{
			lock (dsGCeSkUgyZDZjXwylQkftlwTzqcA)
			{
				zDCSWGFFgARgNupxgohtOaaNPgKH.Enqueue(POiUpLByrmYhGiMyXNKopwHtjRsI);
			}
		}

		private static void iuMEhPMbboliHvoiJhIrUzsPTZU(RingBuffer<VgOyTCkBfUisISRqngkvhzxaTaRIA> P_0, ofXpjCnmsnfKFMCIaEhNMWozSAtl P_1, ref double P_2)
		{
			if (P_0.Count > 0)
			{
				RoUJUHIxeGsSTlNqPAxahRXhlZjh(P_1, P_0[P_0.Count - 1], ref P_2);
				P_0.Clear();
			}
		}

		private static void RoUJUHIxeGsSTlNqPAxahRXhlZjh(ofXpjCnmsnfKFMCIaEhNMWozSAtl P_0, VgOyTCkBfUisISRqngkvhzxaTaRIA P_1, ref double P_2)
		{
			try
			{
				P_0.HBfxEcxYhwcaEIPcWCQoLGeTuZSF(P_1);
			}
			catch
			{
			}
			P_2 = ReInput.realTime;
		}

		private void ALZOtKMjtqCYJZCFZXOOqXNFkRCQ(ref kFZDBEkoCZGcWyRPqSWxGvIVtaLr P_0)
		{
			while (zgmCDVzBtGwmTnNcSNuJINRsCjXkA.ProcessNewEvents())
			{
				HKPAdMpSDNeZEoZFrjSbdTfndKP(ref P_0, ref zgmCDVzBtGwmTnNcSNuJINRsCjXkA.currentEvent);
				for (int i = 0; i < 15; i++)
				{
					ydwvOpcqwbibmeNdEQVwMUYWpnyN.SetValue(i, yCBjuychUhZxWIjuCAVHMcgQgSjw((int)P_0.bVKArfTiasUmkYNGsaIoGtCHiQWE, i), zgmCDVzBtGwmTnNcSNuJINRsCjXkA.currentEvent.GetTimestamp());
				}
			}
		}

		private void RJhQLXafiDAHXyxTgDkSJlFbBpcs(ref kFZDBEkoCZGcWyRPqSWxGvIVtaLr P_0, double P_1, LowLevelInputEvent P_2)
		{
			P_2.SetTimestamp(P_1);
			int bVKArfTiasUmkYNGsaIoGtCHiQWE = (int)P_0.bVKArfTiasUmkYNGsaIoGtCHiQWE;
			P_2.SetButtonsBitMask((bVKArfTiasUmkYNGsaIoGtCHiQWE & 0x7FF) | ((bVKArfTiasUmkYNGsaIoGtCHiQWE & (bVKArfTiasUmkYNGsaIoGtCHiQWE & -4096)) >> 1), 0);
			P_2.SetAxisValue(0, PqNstGyFvZwhMCFqqbDahhmFqAWA(P_0.LmUHEQvGjwMjaYJmamgyoGJFTyPU));
			P_2.SetAxisValue(1, PqNstGyFvZwhMCFqqbDahhmFqAWA(P_0.yrNNKTfnwsThgdNlAmbQRxsgymOB));
			P_2.SetAxisValue(2, PqNstGyFvZwhMCFqqbDahhmFqAWA(P_0.JOLFBidEQPtOBpdoihipFzrYTPRoA));
			P_2.SetAxisValue(3, PqNstGyFvZwhMCFqqbDahhmFqAWA(P_0.pyScHYIHmViFPGnMOnAlqfmxlJOYA));
			P_2.SetAxisValue(4, drEnsaSGMeGbczSFVlRKFteCFcwh(P_0.ByqpfWnUopokKKBCFoMnZfjcqNsq));
			P_2.SetAxisValue(5, drEnsaSGMeGbczSFVlRKFteCFcwh(P_0.GjVDbZrcFmMCKotMKdrPyQLFjfhr));
		}

		private void HKPAdMpSDNeZEoZFrjSbdTfndKP(ref kFZDBEkoCZGcWyRPqSWxGvIVtaLr P_0, ref LowLevelInputEvent P_1)
		{
			int buttonsBitMask = P_1.GetButtonsBitMask(0);
			P_0.bVKArfTiasUmkYNGsaIoGtCHiQWE = (nSRvTrWwYVRxeMgrIKvLadvJGTUdA)((buttonsBitMask & 0x7FF) | ((buttonsBitMask & (buttonsBitMask & -2048)) << 1));
			P_0.LmUHEQvGjwMjaYJmamgyoGJFTyPU = (short)(P_1.GetAxisValue(0) * 32768f);
			P_0.yrNNKTfnwsThgdNlAmbQRxsgymOB = (short)(P_1.GetAxisValue(1) * 32768f);
			P_0.JOLFBidEQPtOBpdoihipFzrYTPRoA = (short)(P_1.GetAxisValue(2) * 32768f);
			P_0.pyScHYIHmViFPGnMOnAlqfmxlJOYA = (short)(P_1.GetAxisValue(3) * 32768f);
			P_0.ByqpfWnUopokKKBCFoMnZfjcqNsq = (byte)(P_1.GetAxisValue(4) * 255f);
			P_0.GjVDbZrcFmMCKotMKdrPyQLFjfhr = (byte)(P_1.GetAxisValue(5) * 255f);
		}

		private static bool yCBjuychUhZxWIjuCAVHMcgQgSjw(int P_0, int P_1)
		{
			if (P_1 > 10)
			{
				P_1++;
			}
			return (P_0 & (1 << P_1)) != 0;
		}

		private void ruPFhYIPAmdAHNpoOWIqctzIdJwH()
		{
			lock (HrTNUSpmJDDmKekjlCQDowzbAWOg)
			{
				zDhPVYqWgphMswhpDDVSTFtbfyQc = default(kFZDBEkoCZGcWyRPqSWxGvIVtaLr);
				WqDQpuJJXsvRwvEVucFPfaXoFmuS = default(kFZDBEkoCZGcWyRPqSWxGvIVtaLr);
				ydwvOpcqwbibmeNdEQVwMUYWpnyN.Clear();
				zgmCDVzBtGwmTnNcSNuJINRsCjXkA.Clear();
			}
		}

		public void Dispose()
		{
			qhZYOLzmuzEDUXwLPArmDhbYRLAJb(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void rbgJayrMbcEmkrwjrCrpJEPVwCmVA()
		{
			try
			{
				qhZYOLzmuzEDUXwLPArmDhbYRLAJb(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void qhZYOLzmuzEDUXwLPArmDhbYRLAJb(bool P_0)
		{
			if (!KFkTpWoecyuZNspRSqmfkpmoGkDU)
			{
				if (P_0)
				{
					zgmCDVzBtGwmTnNcSNuJINRsCjXkA.Dispose();
				}
				KFkTpWoecyuZNspRSqmfkpmoGkDU = true;
			}
		}

		public static float PqNstGyFvZwhMCFqqbDahhmFqAWA(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 32768f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		public static float drEnsaSGMeGbczSFVlRKFteCFcwh(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 255f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private static bool vHjuiUlnPtAabdiPAEypFsXJXNaqb(kFZDBEkoCZGcWyRPqSWxGvIVtaLr P_0, kFZDBEkoCZGcWyRPqSWxGvIVtaLr P_1)
		{
			if (P_0.bVKArfTiasUmkYNGsaIoGtCHiQWE == P_1.bVKArfTiasUmkYNGsaIoGtCHiQWE && P_0.ByqpfWnUopokKKBCFoMnZfjcqNsq == P_1.ByqpfWnUopokKKBCFoMnZfjcqNsq && P_0.GjVDbZrcFmMCKotMKdrPyQLFjfhr == P_1.GjVDbZrcFmMCKotMKdrPyQLFjfhr && P_0.LmUHEQvGjwMjaYJmamgyoGJFTyPU == P_1.LmUHEQvGjwMjaYJmamgyoGJFTyPU && P_0.yrNNKTfnwsThgdNlAmbQRxsgymOB == P_1.yrNNKTfnwsThgdNlAmbQRxsgymOB && P_0.JOLFBidEQPtOBpdoihipFzrYTPRoA == P_1.JOLFBidEQPtOBpdoihipFzrYTPRoA)
			{
				return P_0.pyScHYIHmViFPGnMOnAlqfmxlJOYA == P_1.pyScHYIHmViFPGnMOnAlqfmxlJOYA;
			}
			return false;
		}
	}

	public enum YbzJgKeTTWsWMjKfgBIaIPgcBFRo
	{
		Synchronous = 0,
		Asynchronous = 1
	}

	public const int myHSzWdrIlbuGvLeaDBxpxlvAqnV = 4;

	public const int eXUigVzItVbhLbpnsBWsZLNjcmt = 32768;

	public const int abGyzgGyWICXMlKzELcJBZstjmrH = -32768;

	public const int JeNIeKfJXJQBWKMROpVJIWcCgnbbb = 255;

	public const int eHsbuBisvnSzRZPRdCPXbJQixsXoA = 0;

	public const int TcSTejXQNeQqlvQTXkMWiierhtPBA = 18;

	public const int AjJzwcYEVmDlMPerMigcjlnSOdWd = 14;

	public const int UlEnFPjHHFDIxewncvGeyVQRVMfx = 6;

	public const int eVNqVvWFXsNYYbPOceYHCOnkWsfs = 15;

	private mktvZqLqiNHPUOBkcEORiAUZwMfL[] pjVpQpHBesgWfReTNoyGisngvJum;

	private bool qhHFIInFSoxUOGQTalpsxjPeckFj;

	private wCFbSldxIEAZqtUDpOxBCwjBMacub BpJlIDCeTCeRdLihIsbKVUVNopA;

	private vvYLGkDbzPGSZNaxLbmPbXIibWkgA yATGzsWFFfbbQTanYWVovHGUyDzR;

	private global::LLuerUMhyjncgwVxBNqCJPLVjyLE<bool> VPGdbbgaZBlQJCGSxxTSaFZHhEllB;

	private bool[] furQOviOtFLNygSsTQIrkJYccvgt;

	private bool[] hGSRzWwRdrWdoqcvVJpRyHJDskHW;

	private bool bytpZiDInoMuHTRFiIxdwaxwmXXS;

	private readonly bool mBiYHQIDWNSNFEhRvvwivguBIEEI;

	private readonly UpdateLoopSetting BSuZGqmOOHmctsoBsUxfJWSKteCH;

	private UpdateLoopType woGFnyHVbetewzPgpvVsTtZygedt;

	private UpdateLoopType DlVTqAstVTENOIXNNMYVAEAvTYEw;

	private Action<int, ControllerDataUpdater> ulGMskKCmGtzcaHxNPghncECjUzE;

	private bool wPsOndApqlfncqBWJnmLcIeAEoIgA;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> CVHxnIPHYZhrGRyQuIJZKiDBxjrN;

	private Func<int> gDskjoOhBTOdEwQSSZXnUBeQcCEu;

	private static Guid[] OLMRJvGrrHCAmskrJLmvdOGjIBOkA;

	private static string[] sphUUflmYKQhhxaaTGqyhvATbkel;

	private static string[] qoCMCfLrdCceLHQdqlhFFTNFYyvdb;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (pjVpQpHBesgWfReTNoyGisngvJum[i].XJkOMmPmJldLduScaArHDKnjddzE)
				{
					num++;
				}
			}
			return num;
		}
	}

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => this;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => null;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.XInput;

	public iJBgwMICNtsxCQITcDMiEfutRJOA(bool P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3)
	{
		mBiYHQIDWNSNFEhRvvwivguBIEEI = P_0;
		BSuZGqmOOHmctsoBsUxfJWSKteCH = P_1;
		wPsOndApqlfncqBWJnmLcIeAEoIgA = true;
		try
		{
			if (!NKhLafDUxKEtAzgKmqVtfOxhlfXd.KXMEDABXLFBQTgrvjtSkYgOvGGGVb(out var phpbXZBgzwuxaaVuvRrOUKUQUlCFA, out var text, out var _))
			{
				throw new Exception("XInput is not available.");
			}
			if (phpbXZBgzwuxaaVuvRrOUKUQUlCFA < PhpbXZBgzwuxaaVuvRrOUKUQUlCFA.XINPUT_1_3)
			{
				Rewired.Logger.LogWarning("The version of XInput (" + text + ") detected on your system is out of date. Please update to the latest version of XInput. Input will still function, but all features may not be available. See the documentation for required dependencies.");
			}
			else
			{
				_ = 4;
			}
			CVHxnIPHYZhrGRyQuIJZKiDBxjrN = P_2;
			gDskjoOhBTOdEwQSSZXnUBeQcCEu = P_3;
			bytpZiDInoMuHTRFiIxdwaxwmXXS = UnityTools.platform == Platform.WindowsAppStore;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(BSuZGqmOOHmctsoBsUxfJWSKteCH, list);
				int num2 = 0;
				if (num2 < list.Count)
				{
					DlVTqAstVTENOIXNNMYVAEAvTYEw = list[num2];
				}
			}
			VPGdbbgaZBlQJCGSxxTSaFZHhEllB = new global::LLuerUMhyjncgwVxBNqCJPLVjyLE<bool>(true, AKRoVadAXxraDUqTVwjBzkAoqgbl);
			furQOviOtFLNygSsTQIrkJYccvgt = new bool[4];
			hGSRzWwRdrWdoqcvVJpRyHJDskHW = new bool[4];
			ulGMskKCmGtzcaHxNPghncECjUzE = UpdateControllerData;
			if (bytpZiDInoMuHTRFiIxdwaxwmXXS)
			{
				MzFwMyYafhMaZpgJRUuICFlLVnXo();
			}
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
		if (wPsOndApqlfncqBWJnmLcIeAEoIgA)
		{
			BpJlIDCeTCeRdLihIsbKVUVNopA = new wCFbSldxIEAZqtUDpOxBCwjBMacub(1f);
		}
		yATGzsWFFfbbQTanYWVovHGUyDzR = new vvYLGkDbzPGSZNaxLbmPbXIibWkgA();
		if (pjVpQpHBesgWfReTNoyGisngvJum == null)
		{
			pjVpQpHBesgWfReTNoyGisngvJum = new mktvZqLqiNHPUOBkcEORiAUZwMfL[4];
			for (int i = 0; i < 4; i++)
			{
				XuefDHxaNwtvevAqswljAJrmkdGP xuefDHxaNwtvevAqswljAJrmkdGP = new XuefDHxaNwtvevAqswljAJrmkdGP(i, BSuZGqmOOHmctsoBsUxfJWSKteCH);
				lOimudEEADkCsfXveaIQPguQeEbk.ANuGBWudliodGbGfCbfveIhMhBLIA.ThreadUpdateEvent += xuefDHxaNwtvevAqswljAJrmkdGP.uWQHFfhUsVIiTKvbgRggXUkWstUI;
				lOimudEEADkCsfXveaIQPguQeEbk.HJgXpVuyIspPItbPFVgKPnoPkhXP.ThreadUpdateEvent += xuefDHxaNwtvevAqswljAJrmkdGP.kpzbKxDWusAQdecIYsfapwqvUIBX;
				pjVpQpHBesgWfReTNoyGisngvJum[i] = new mktvZqLqiNHPUOBkcEORiAUZwMfL(i, bytpZiDInoMuHTRFiIxdwaxwmXXS, xuefDHxaNwtvevAqswljAJrmkdGP, CVHxnIPHYZhrGRyQuIJZKiDBxjrN, SystemDeviceDisconnected);
			}
		}
		pVsVitZdWfvdHcXoHdjmEmzpNoje(true);
		Update(UpdateLoopType.Update);
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		woGFnyHVbetewzPgpvVsTtZygedt = currentUpdateLoop;
		KYwgQGgfnLZCPHPPsHTaFZBBhQiRA();
		for (int i = 0; i < 4; i++)
		{
			if (pjVpQpHBesgWfReTNoyGisngvJum[i] != null && pjVpQpHBesgWfReTNoyGisngvJum[i].XJkOMmPmJldLduScaArHDKnjddzE)
			{
				pjVpQpHBesgWfReTNoyGisngvJum[i].Update();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (VPGdbbgaZBlQJCGSxxTSaFZHhEllB != null)
		{
			VPGdbbgaZBlQJCGSxxTSaFZHhEllB.bkHmwKfdIczaMGhYiGtzFjzCYJlw();
		}
		if (pjVpQpHBesgWfReTNoyGisngvJum != null)
		{
			for (int i = 0; i < 4; i++)
			{
				if (pjVpQpHBesgWfReTNoyGisngvJum[i] != null)
				{
					if (lOimudEEADkCsfXveaIQPguQeEbk.ANuGBWudliodGbGfCbfveIhMhBLIA != null)
					{
						lOimudEEADkCsfXveaIQPguQeEbk.ANuGBWudliodGbGfCbfveIhMhBLIA.ThreadUpdateEvent -= pjVpQpHBesgWfReTNoyGisngvJum[i].JUbGYxGlyKymyyrMXiLloNpvYOS.uWQHFfhUsVIiTKvbgRggXUkWstUI;
					}
					if (lOimudEEADkCsfXveaIQPguQeEbk.HJgXpVuyIspPItbPFVgKPnoPkhXP != null)
					{
						lOimudEEADkCsfXveaIQPguQeEbk.HJgXpVuyIspPItbPFVgKPnoPkhXP.ThreadUpdateEvent -= pjVpQpHBesgWfReTNoyGisngvJum[i].JUbGYxGlyKymyyrMXiLloNpvYOS.kpzbKxDWusAQdecIYsfapwqvUIBX;
					}
					pjVpQpHBesgWfReTNoyGisngvJum[i].Dispose();
				}
			}
		}
		NKhLafDUxKEtAzgKmqVtfOxhlfXd.BGOWdUaAnfPpdznnNjvNXWspNEuK();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return ulGMskKCmGtzcaHxNPghncECjUzE;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		pjVpQpHBesgWfReTNoyGisngvJum[assignedControllerId].FillData(data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		pVsVitZdWfvdHcXoHdjmEmzpNoje(true);
		IbeaXEayqZRqDaIhGAmvKTXQJuuaA();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		pVsVitZdWfvdHcXoHdjmEmzpNoje(true);
		IbeaXEayqZRqDaIhGAmvKTXQJuuaA();
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
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return null;
	}

	private bool woxkAdocbAoWjrHSJdbYXbjBzZKq()
	{
		if (woGFnyHVbetewzPgpvVsTtZygedt != DlVTqAstVTENOIXNNMYVAEAvTYEw)
		{
			return false;
		}
		bool num = BpJlIDCeTCeRdLihIsbKVUVNopA.IJlSgHKnPXHqKCNwqOxdwLXHSRlT();
		if (num)
		{
			pVsVitZdWfvdHcXoHdjmEmzpNoje(true);
		}
		return num;
	}

	private void pVsVitZdWfvdHcXoHdjmEmzpNoje(bool P_0)
	{
		qhHFIInFSoxUOGQTalpsxjPeckFj = P_0;
		if (wPsOndApqlfncqBWJnmLcIeAEoIgA)
		{
			BpJlIDCeTCeRdLihIsbKVUVNopA.vipEKxaKadjTGEEELnpOdcJGktuyA();
		}
	}

	private void IbeaXEayqZRqDaIhGAmvKTXQJuuaA()
	{
		if (VPGdbbgaZBlQJCGSxxTSaFZHhEllB != null)
		{
			VPGdbbgaZBlQJCGSxxTSaFZHhEllB.gmaIrfraLSFEAKpuADuceEGDgZoWb();
		}
	}

	private void MzFwMyYafhMaZpgJRUuICFlLVnXo()
	{
		_ = new ofXpjCnmsnfKFMCIaEhNMWozSAtl().IWbLYNMluIhRKbYgrkONYbgHGPLH;
	}

	private void KYwgQGgfnLZCPHPPsHTaFZBBhQiRA()
	{
		bool flag = false;
		if (wPsOndApqlfncqBWJnmLcIeAEoIgA)
		{
			flag = woxkAdocbAoWjrHSJdbYXbjBzZKq();
		}
		if (!flag && qhHFIInFSoxUOGQTalpsxjPeckFj)
		{
			ssGgvRhJhdxQPTkzuYgdMucVtRAoA(vikRPoyALPGnohhdtYGQQPIGVwmt());
			pVsVitZdWfvdHcXoHdjmEmzpNoje(false);
			IbeaXEayqZRqDaIhGAmvKTXQJuuaA();
			return;
		}
		if (qhHFIInFSoxUOGQTalpsxjPeckFj)
		{
			ChaLyqBSGXTENqfFEKlrhifiLSjc();
		}
		if (VPGdbbgaZBlQJCGSxxTSaFZHhEllB.snsDQUpOcRaGRKbTkYpwRvywuGYh && VPGdbbgaZBlQJCGSxxTSaFZHhEllB.iuGaMmcGKafyNfJkNqVWhILJWPAm())
		{
			FZcHjPyEVrzDHwNhDKaNFeuBFjxhA();
		}
	}

	private void ChaLyqBSGXTENqfFEKlrhifiLSjc()
	{
		qhHFIInFSoxUOGQTalpsxjPeckFj = false;
		if (!VPGdbbgaZBlQJCGSxxTSaFZHhEllB.snsDQUpOcRaGRKbTkYpwRvywuGYh)
		{
			VPGdbbgaZBlQJCGSxxTSaFZHhEllB.SgOnxhdhoJMkOXBTPqeBcreyDTgn();
		}
	}

	private void FZcHjPyEVrzDHwNhDKaNFeuBFjxhA()
	{
		lock (furQOviOtFLNygSsTQIrkJYccvgt)
		{
			Array.Copy(furQOviOtFLNygSsTQIrkJYccvgt, hGSRzWwRdrWdoqcvVJpRyHJDskHW, 4);
		}
		ssGgvRhJhdxQPTkzuYgdMucVtRAoA(hGSRzWwRdrWdoqcvVJpRyHJDskHW);
	}

	private bool AKRoVadAXxraDUqTVwjBzkAoqgbl()
	{
		lock (furQOviOtFLNygSsTQIrkJYccvgt)
		{
			for (int i = 0; i < 4; i++)
			{
				if (pjVpQpHBesgWfReTNoyGisngvJum[i] != null)
				{
					furQOviOtFLNygSsTQIrkJYccvgt[i] = pjVpQpHBesgWfReTNoyGisngvJum[i].RlGCiEASRQalzdPNDqxQPRTLWJCiA(YbzJgKeTTWsWMjKfgBIaIPgcBFRo.Synchronous);
				}
			}
		}
		return true;
	}

	private bool[] vikRPoyALPGnohhdtYGQQPIGVwmt()
	{
		for (int i = 0; i < 4; i++)
		{
			hGSRzWwRdrWdoqcvVJpRyHJDskHW[i] = pjVpQpHBesgWfReTNoyGisngvJum[i].RlGCiEASRQalzdPNDqxQPRTLWJCiA(YbzJgKeTTWsWMjKfgBIaIPgcBFRo.Synchronous);
		}
		return hGSRzWwRdrWdoqcvVJpRyHJDskHW;
	}

	private void ssGgvRhJhdxQPTkzuYgdMucVtRAoA(bool[] P_0)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (pjVpQpHBesgWfReTNoyGisngvJum[i] != null && pjVpQpHBesgWfReTNoyGisngvJum[i].SdSHAWIsIbJzTNQzNGIXyypuJadq)
			{
				bool flag = P_0[i];
				pjVpQpHBesgWfReTNoyGisngvJum[i].VaBfCEQHbbJPzoWAXEHHfaOFOozNA(flag);
				if (!flag)
				{
					xzeBQjFcVLBjNKtdPJaDSHWYGEozA(pjVpQpHBesgWfReTNoyGisngvJum[i], false);
				}
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (pjVpQpHBesgWfReTNoyGisngvJum[j] != null && !pjVpQpHBesgWfReTNoyGisngvJum[j].SdSHAWIsIbJzTNQzNGIXyypuJadq)
			{
				bool flag2 = P_0[j];
				pjVpQpHBesgWfReTNoyGisngvJum[j].VaBfCEQHbbJPzoWAXEHHfaOFOozNA(flag2);
				if (flag2 && !xzeBQjFcVLBjNKtdPJaDSHWYGEozA(pjVpQpHBesgWfReTNoyGisngvJum[j], true))
				{
					num |= ((j == 0) ? 1 : (1 << j));
				}
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (pjVpQpHBesgWfReTNoyGisngvJum[k] != null)
			{
				int num2 = ((k == 0) ? 1 : (1 << k));
				if ((num & num2) != 1 << k)
				{
					pjVpQpHBesgWfReTNoyGisngvJum[k].krTzlsykNPGwhrtkvBBiOawsQtei(P_0[k]);
				}
			}
		}
	}

	private bool xzeBQjFcVLBjNKtdPJaDSHWYGEozA(mktvZqLqiNHPUOBkcEORiAUZwMfL P_0, bool P_1)
	{
		if (P_1)
		{
			P_0.EOCWmQfiLRaDktRgdbGcxCUXdswt();
			if (!P_0.caKqEkCbOmCTpcbVipHNeCnCxTqyB)
			{
				return false;
			}
			int num = yATGzsWFFfbbQTanYWVovHGUyDzR.SXFxViYmuvgxeEpJxwFuqkYCSwZlA(P_0.GOoBmfcdKWtlPymAZTHADxVKGUOV, false);
			if (num >= 0)
			{
				P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = yATGzsWFFfbbQTanYWVovHGUyDzR.PTJHXzcrkvOklUMBQiMxuFWQHFso(num);
				yATGzsWFFfbbQTanYWVovHGUyDzR.iTjuCkOSPsOrTwWunVMpNojXIKnh(num, P_0, true);
			}
			else
			{
				P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = gDskjoOhBTOdEwQSSZXnUBeQcCEu();
				yATGzsWFFfbbQTanYWVovHGUyDzR.gqgOvdWHcedrePsUzBTxiHPDOvHtA(P_0, true);
			}
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(P_0));
			}
			BridgedController obj = P_0.ToBridgedController();
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(obj);
			}
		}
		else
		{
			int num2 = yATGzsWFFfbbQTanYWVovHGUyDzR.pymxQWFiikwkkyYZGvdJfwCTNTDB(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.GOoBmfcdKWtlPymAZTHADxVKGUOV, true);
			if (num2 >= 0)
			{
				yATGzsWFFfbbQTanYWVovHGUyDzR.ZdhPONFoiGUegtMQkxNftSUEsASi(num2, false);
			}
			ControllerDisconnectedEventArgs obj2 = P_0.ToControllerDisconnectedEventArgs();
			P_0.qKqpuapYXUUdaUFlYDFKhayDblGaA();
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(obj2);
			}
		}
		return true;
	}

	static iJBgwMICNtsxCQITcDMiEfutRJOA()
	{
		OLMRJvGrrHCAmskrJLmvdOGjIBOkA = new Guid[2]
		{
			new Guid("72100955-0000-0000-0000-504944564944"),
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		sphUUflmYKQhhxaaTGqyhvATbkel = new string[1] { "Xbox Bluetooth Gamepad" };
		qoCMCfLrdCceLHQdqlhFFTNFYyvdb = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool nsFVRFMKeqbpXkshgJjJxgkLGncZ(string P_0, string P_1, string P_2, Guid P_3)
	{
		if (ArrayTools.Contains(OLMRJvGrrHCAmskrJLmvdOGjIBOkA, P_3))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < sphUUflmYKQhhxaaTGqyhvATbkel.Length; i++)
			{
				if (P_1.Equals(sphUUflmYKQhhxaaTGqyhvATbkel[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		if (!string.IsNullOrEmpty(P_2))
		{
			for (int j = 0; j < qoCMCfLrdCceLHQdqlhFFTNFYyvdb.Length; j++)
			{
				if (Regex.IsMatch(P_2, qoCMCfLrdCceLHQdqlhFFTNFYyvdb[j], RegexOptions.IgnoreCase))
				{
					return true;
				}
			}
		}
		P_0 = P_0.ToLower();
		int num = P_0.IndexOf("vid_");
		if (num < 0)
		{
			return false;
		}
		if (P_0.IndexOf("ig_") < num)
		{
			return false;
		}
		return true;
	}
}
