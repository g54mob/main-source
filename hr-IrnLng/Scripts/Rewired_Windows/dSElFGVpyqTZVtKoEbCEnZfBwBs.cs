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

internal class dSElFGVpyqTZVtKoEbCEnZfBwBs : PlatformInputManager
{
	private class LrvDPxHfGyvMeFaEPPjjJuwpEYq : IDisposable, IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private bool tRcZRyahcbitwohIPWrUYISZbXmH;

		private int CeIdVJsUwjdwsuPBCtZxfxIInIm;

		private readonly int KvysigyefodxLfLeLzZJLvcQVDJV;

		public Guid QmLKgYYPeYYRxIivEciniTYoXdO;

		public string YGVWsQIdEPlUdLcmFGBdDRxwphL;

		public Guid zAgUTYpwnGscdFlNDxXqCoyIrDh;

		public Rewired.Libraries.SharpDX.XInput.DeviceType LmCxCdpctlbWkBhaHlFmbFALKEJ;

		public XInputDeviceSubType zZDSOSlfNBhWwUJDseoHkaUNagX;

		public bool rPgbDjuxkQCjUxKyoCDTJEWtoRC;

		public bool sXwggIKUNmjykHzWTfQrbzPGTeLG;

		public bool vhBgxexuavhFyiAhHnDNfGvahEZJ;

		public bool ZTxcXqFCXcMcFbJzbogdaSAwtHxZ;

		private int UFjahodKKlKgpFmJebtvtJcWHphB;

		private int FJMdWUaGDInZZewwDxElGHTkrRvA;

		private int cOVEXSAIuvbznALDYKQQXTxspUvG;

		private int xOcVIiUgaPmbRhbRYiQWvhIsYap;

		private readonly float[] MyEdCYiRJtoncZaamVaftBLHcGOw;

		private readonly bool[] uIeLPvaOtikrhYebGzxpUwrhZxM;

		private HardwareJoystickMap_InputManager QKBgAKpFvffffqJCzlcbbQpNNbB;

		public readonly vpVfMtKUngfGMQjRsZBKhMWSnkMD fUWusVflpgaWsSNSoAiTBPWnobsa;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> muwCboYBpXBddhISLPoaIQYyEVOW;

		private Action aGvHagkLdITFxleAwMpeUrSNoZR;

		private bool eFIldJHAlwDZVMNuZYxdjxWSQFI;

		private bool UoPBhPBqUjBCLUUTzRsIuKGshLSj;

		private bool euujVPFzGztViWDbYvUutBvFQFP;

		public string instanceName
		{
			get
			{
				string text = productName;
				if (text == string.Empty)
				{
					return string.Empty;
				}
				return text + " " + KvysigyefodxLfLeLzZJLvcQVDJV;
			}
		}

		public string productName
		{
			get
			{
				if (!isConnected)
				{
					return string.Empty;
				}
				return zZDSOSlfNBhWwUJDseoHkaUNagX.ToString();
			}
		}

		public bool isConnected
		{
			get
			{
				if (fUWusVflpgaWsSNSoAiTBPWnobsa == null || !ZTxcXqFCXcMcFbJzbogdaSAwtHxZ)
				{
					return false;
				}
				if (eFIldJHAlwDZVMNuZYxdjxWSQFI && !PVOVLQaxGGfpoIeMBxQAgDCTNbr(PpGLXDbpIbUQoQfJgPjVzGIXDryh.McTDqofjwxcaTvHmKRrvobGgrZf))
				{
					rHTwaVWzIhGzZcrrpRKTqeupoBe();
				}
				return eFIldJHAlwDZVMNuZYxdjxWSQFI;
			}
		}

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return CeIdVJsUwjdwsuPBCtZxfxIInIm;
			}
			set
			{
				CeIdVJsUwjdwsuPBCtZxfxIInIm = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId => KvysigyefodxLfLeLzZJLvcQVDJV;

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (tRcZRyahcbitwohIPWrUYISZbXmH)
				{
					return zZDSOSlfNBhWwUJDseoHkaUNagX.ToString() + " " + (KvysigyefodxLfLeLzZJLvcQVDJV + 1);
				}
				return "XInput " + zZDSOSlfNBhWwUJDseoHkaUNagX.ToString() + " " + (KvysigyefodxLfLeLzZJLvcQVDJV + 1);
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId => KvysigyefodxLfLeLzZJLvcQVDJV;

		[CustomObfuscation(rename = false)]
		public int unityId => 0;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension => null;

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => zAgUTYpwnGscdFlNDxXqCoyIrDh;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			fUWusVflpgaWsSNSoAiTBPWnobsa.nfmGmYcyUlTLqwzJLoQIeHZegFf(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			fUWusVflpgaWsSNSoAiTBPWnobsa.sBPDsqHNIOqsXGZWBzefFlYFtqJ();
		}

		public LrvDPxHfGyvMeFaEPPjjJuwpEYq(int systemId, bool isWin8AppStore, vpVfMtKUngfGMQjRsZBKhMWSnkMD sourceJoystick, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Action deviceDisconnectedDelegate)
		{
			fUWusVflpgaWsSNSoAiTBPWnobsa = sourceJoystick;
			tRcZRyahcbitwohIPWrUYISZbXmH = isWin8AppStore;
			KvysigyefodxLfLeLzZJLvcQVDJV = systemId;
			muwCboYBpXBddhISLPoaIQYyEVOW = getHardwareJoystickMap_InputManager;
			aGvHagkLdITFxleAwMpeUrSNoZR = deviceDisconnectedDelegate;
			CeIdVJsUwjdwsuPBCtZxfxIInIm = -1;
			UFjahodKKlKgpFmJebtvtJcWHphB = 6;
			FJMdWUaGDInZZewwDxElGHTkrRvA = 15;
			cOVEXSAIuvbznALDYKQQXTxspUvG = UFjahodKKlKgpFmJebtvtJcWHphB;
			xOcVIiUgaPmbRhbRYiQWvhIsYap = FJMdWUaGDInZZewwDxElGHTkrRvA;
			MyEdCYiRJtoncZaamVaftBLHcGOw = new float[UFjahodKKlKgpFmJebtvtJcWHphB];
			uIeLPvaOtikrhYebGzxpUwrhZxM = new bool[FJMdWUaGDInZZewwDxElGHTkrRvA];
			QaUcwhGLRRBnjcaMjVHoGuyQzyU();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			fUWusVflpgaWsSNSoAiTBPWnobsa.NNKDQtzuxXoooYVfbmDIlBryQvg();
			bool[] currentButtonValues = fUWusVflpgaWsSNSoAiTBPWnobsa.CurrentButtonValues;
			VVKAQHjDQMZyRjqEMoRgsckjyIh(currentButtonValues, ref fUWusVflpgaWsSNSoAiTBPWnobsa.wsxuYdlgBUJRnBGOPWCbPVxZBsB);
			yMmEMHIqZYcuTkSikVFFrOfyKDc(currentButtonValues, ref fUWusVflpgaWsSNSoAiTBPWnobsa.wsxuYdlgBUJRnBGOPWCbPVxZBsB);
			fUWusVflpgaWsSNSoAiTBPWnobsa.xbrgbsymhweSXlyAZAqkvRqFNEB();
		}

		public void YYIbizKGxLGaVnJRqxHgOoZTMpK(bool P_0)
		{
			if (fUWusVflpgaWsSNSoAiTBPWnobsa != null)
			{
				vhBgxexuavhFyiAhHnDNfGvahEZJ = P_0;
			}
		}

		public bool PVOVLQaxGGfpoIeMBxQAgDCTNbr(PpGLXDbpIbUQoQfJgPjVzGIXDryh P_0)
		{
			FPsdgujyNxlnpWBNIHemIDivhFY(UdRmJTAFcfCpSRTYduMvUfAoPUW(P_0));
			return eFIldJHAlwDZVMNuZYxdjxWSQFI;
		}

		public bool UdRmJTAFcfCpSRTYduMvUfAoPUW(PpGLXDbpIbUQoQfJgPjVzGIXDryh P_0)
		{
			if (fUWusVflpgaWsSNSoAiTBPWnobsa == null)
			{
				return false;
			}
			return fUWusVflpgaWsSNSoAiTBPWnobsa.UdRmJTAFcfCpSRTYduMvUfAoPUW(P_0);
		}

		public void FPsdgujyNxlnpWBNIHemIDivhFY(bool P_0)
		{
			eFIldJHAlwDZVMNuZYxdjxWSQFI = P_0;
		}

		public void jtEatkevZEpPorDVxHmTCvzGACqR()
		{
			if (!ZTxcXqFCXcMcFbJzbogdaSAwtHxZ || eUdFyjJVQyBKJwFEmukgKVsSfII())
			{
				QaUcwhGLRRBnjcaMjVHoGuyQzyU();
			}
			if (ZTxcXqFCXcMcFbJzbogdaSAwtHxZ && eFIldJHAlwDZVMNuZYxdjxWSQFI)
			{
				fUWusVflpgaWsSNSoAiTBPWnobsa.DfsndYxHYVKUdQgDuAfETngfexb();
			}
		}

		public void EgfcjPvvEnaEjugFaqbWLfYFiGh()
		{
			CeIdVJsUwjdwsuPBCtZxfxIInIm = -1;
			ZTxcXqFCXcMcFbJzbogdaSAwtHxZ = false;
			fUWusVflpgaWsSNSoAiTBPWnobsa.ibjqBHyFNJOhWJActsfrTOPbIjF();
			Array.Clear(MyEdCYiRJtoncZaamVaftBLHcGOw, 0, MyEdCYiRJtoncZaamVaftBLHcGOw.Length);
			Array.Clear(uIeLPvaOtikrhYebGzxpUwrhZxM, 0, uIeLPvaOtikrhYebGzxpUwrhZxM.Length);
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (UFjahodKKlKgpFmJebtvtJcWHphB != dataUpdater.axisCount || FJMdWUaGDInZZewwDxElGHTkrRvA != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < UFjahodKKlKgpFmJebtvtJcWHphB; i++)
			{
				dataUpdater.axisValues[i] = MyEdCYiRJtoncZaamVaftBLHcGOw[i];
			}
			for (int j = 0; j < FJMdWUaGDInZZewwDxElGHTkrRvA; j++)
			{
				dataUpdater.buttonValues[j] = uIeLPvaOtikrhYebGzxpUwrhZxM[j];
			}
			if (UoPBhPBqUjBCLUUTzRsIuKGshLSj && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public BridgedControllerHWInfo OiAyslXLaikGHSduwzwAoxjCWis()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			znmRFnJWmRHaLzxNQMvWhUZoLvz(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			znmRFnJWmRHaLzxNQMvWhUZoLvz(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(CeIdVJsUwjdwsuPBCtZxfxIInIm);
		}

		private void QaUcwhGLRRBnjcaMjVHoGuyQzyU()
		{
			if (fUWusVflpgaWsSNSoAiTBPWnobsa == null || !PVOVLQaxGGfpoIeMBxQAgDCTNbr(PpGLXDbpIbUQoQfJgPjVzGIXDryh.qalJCBWGPnTWajUHtqFaMFwFuVa))
			{
				return;
			}
			try
			{
				CFvOHSgUEsImnAfPAOTDKCxJRaI();
				YzYsCymgJtbmvMuKUCCJNSxkFlq yzYsCymgJtbmvMuKUCCJNSxkFlq = fUWusVflpgaWsSNSoAiTBPWnobsa.vKBaAPQDZOAtcrDDXredlCKNpPr.NDxIjHDGTvZtZFGNyGSlQyhMYhM(zexdwdVbzZaMEDmtcOGGUXzKpPqk.zqTMGLDmSVTokYzpiquViBjRSYz);
				LmCxCdpctlbWkBhaHlFmbFALKEJ = yzYsCymgJtbmvMuKUCCJNSxkFlq.UANajORgEjGJZDtTWdmqYjUulHF;
				zZDSOSlfNBhWwUJDseoHkaUNagX = (XInputDeviceSubType)yzYsCymgJtbmvMuKUCCJNSxkFlq.UJyFcVkOaaxYbmeozgUqENcFyuEX;
				if (fUWusVflpgaWsSNSoAiTBPWnobsa.vKBaAPQDZOAtcrDDXredlCKNpPr.nfmGmYcyUlTLqwzJLoQIeHZegFf(default(IVNavipaXjEHkzqGczlxUctDvay)).Success)
				{
					rPgbDjuxkQCjUxKyoCDTJEWtoRC = true;
				}
				sXwggIKUNmjykHzWTfQrbzPGTeLG = (yzYsCymgJtbmvMuKUCCJNSxkFlq.wbmxfUinNZtnthzDdPSUImGyMjT & grRcaVDlyjNKgfCTaQicYYSfltnH.ICWxnKxyrtsikECplrOVNhWFgXE) == grRcaVDlyjNKgfCTaQicYYSfltnH.ICWxnKxyrtsikECplrOVNhWFgXE;
				YOJqghcNXYHtfCjcMsnGHhFpgHI();
				QmLKgYYPeYYRxIivEciniTYoXdO = QKBgAKpFvffffqJCzlcbbQpNNbB.hardwareMapIdentifier.guid;
				YGVWsQIdEPlUdLcmFGBdDRxwphL = QKBgAKpFvffffqJCzlcbbQpNNbB.controllerName;
				fUWusVflpgaWsSNSoAiTBPWnobsa.DfsndYxHYVKUdQgDuAfETngfexb();
				zAgUTYpwnGscdFlNDxXqCoyIrDh = MiscTools.CreateGuidHashSHA1(string.Concat(LmCxCdpctlbWkBhaHlFmbFALKEJ, zZDSOSlfNBhWwUJDseoHkaUNagX, KvysigyefodxLfLeLzZJLvcQVDJV));
				ZTxcXqFCXcMcFbJzbogdaSAwtHxZ = true;
			}
			catch (Exception)
			{
				ZTxcXqFCXcMcFbJzbogdaSAwtHxZ = false;
				eFIldJHAlwDZVMNuZYxdjxWSQFI = false;
				zAgUTYpwnGscdFlNDxXqCoyIrDh = Guid.Empty;
			}
		}

		private bool eUdFyjJVQyBKJwFEmukgKVsSfII()
		{
			try
			{
				if (zZDSOSlfNBhWwUJDseoHkaUNagX != (XInputDeviceSubType)fUWusVflpgaWsSNSoAiTBPWnobsa.vKBaAPQDZOAtcrDDXredlCKNpPr.NDxIjHDGTvZtZFGNyGSlQyhMYhM(zexdwdVbzZaMEDmtcOGGUXzKpPqk.zqTMGLDmSVTokYzpiquViBjRSYz).UJyFcVkOaaxYbmeozgUqENcFyuEX)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private void CFvOHSgUEsImnAfPAOTDKCxJRaI()
		{
			sXwggIKUNmjykHzWTfQrbzPGTeLG = false;
			rPgbDjuxkQCjUxKyoCDTJEWtoRC = false;
			vhBgxexuavhFyiAhHnDNfGvahEZJ = false;
			ZTxcXqFCXcMcFbJzbogdaSAwtHxZ = false;
		}

		private void rHTwaVWzIhGzZcrrpRKTqeupoBe()
		{
			if (aGvHagkLdITFxleAwMpeUrSNoZR != null)
			{
				aGvHagkLdITFxleAwMpeUrSNoZR();
			}
			fUWusVflpgaWsSNSoAiTBPWnobsa.ibjqBHyFNJOhWJActsfrTOPbIjF();
		}

		private void VVKAQHjDQMZyRjqEMoRgsckjyIh(bool[] P_0, ref hrUcIohoksJRyJjOnZazbIlswca P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_XInput_Base)QKBgAKpFvffffqJCzlcbbQpNNbB.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (i >= UFjahodKKlKgpFmJebtvtJcWHphB)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				MyEdCYiRJtoncZaamVaftBLHcGOw[i] = TgLPLRPKTlXSaoodLpemjkZzehs(axes_orig[i], P_0, ref P_1);
				if (!UoPBhPBqUjBCLUUTzRsIuKGshLSj && MyEdCYiRJtoncZaamVaftBLHcGOw[i] != 0f)
				{
					UoPBhPBqUjBCLUUTzRsIuKGshLSj = true;
				}
			}
		}

		private void yMmEMHIqZYcuTkSikVFFrOfyKDc(bool[] P_0, ref hrUcIohoksJRyJjOnZazbIlswca P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_XInput_Base)QKBgAKpFvffffqJCzlcbbQpNNbB.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= FJMdWUaGDInZZewwDxElGHTkrRvA)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				uIeLPvaOtikrhYebGzxpUwrhZxM[i] = hCGghiHxSAcLADozffLtfQoDJspU(buttons_orig[i], P_0, ref P_1);
				if (!UoPBhPBqUjBCLUUTzRsIuKGshLSj && uIeLPvaOtikrhYebGzxpUwrhZxM[i])
				{
					UoPBhPBqUjBCLUUTzRsIuKGshLSj = true;
				}
			}
		}

		private float TgLPLRPKTlXSaoodLpemjkZzehs(HardwareJoystickMap.Platform_XInput_Base.Axis P_0, bool[] P_1, ref hrUcIohoksJRyJjOnZazbIlswca P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return 0f;
				}
				return TgLPLRPKTlXSaoodLpemjkZzehs(P_0.sourceAxis, ref P_2);
			}
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return 0f;
				}
				if (!hCGghiHxSAcLADozffLtfQoDJspU(P_0.sourceButton, P_1))
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

		private float TgLPLRPKTlXSaoodLpemjkZzehs(XInputAxis P_0, ref hrUcIohoksJRyJjOnZazbIlswca P_1)
		{
			return P_0 switch
			{
				XInputAxis.LeftThumbX => vpVfMtKUngfGMQjRsZBKhMWSnkMD.gGNoAhCUXzgDbDcskWksokriYti(P_1.xcjJKYsOhJDGyABhRrYnugjrIwJO), 
				XInputAxis.LeftThumbY => vpVfMtKUngfGMQjRsZBKhMWSnkMD.gGNoAhCUXzgDbDcskWksokriYti(P_1.PgPPQFmlukMjHbGCkPHKcBNDHQVe), 
				XInputAxis.RightThumbX => vpVfMtKUngfGMQjRsZBKhMWSnkMD.gGNoAhCUXzgDbDcskWksokriYti(P_1.NGFeKsUVpmGlLgiHwjABwrxVngW), 
				XInputAxis.RightThumbY => vpVfMtKUngfGMQjRsZBKhMWSnkMD.gGNoAhCUXzgDbDcskWksokriYti(P_1.ttypRSEQZPochloohJAmnomPllh), 
				XInputAxis.LeftTrigger => vpVfMtKUngfGMQjRsZBKhMWSnkMD.pFvogLNFlkHNdCYuzUoyjSxIujK(P_1.VyvdwxScxQAVyTEQdmFkjznaCyW), 
				XInputAxis.RightTrigger => vpVfMtKUngfGMQjRsZBKhMWSnkMD.pFvogLNFlkHNdCYuzUoyjSxIujK(P_1.btnmAjJJoIFOiKKnAaBWbPcbjLby), 
				_ => 0f, 
			};
		}

		private bool hCGghiHxSAcLADozffLtfQoDJspU(HardwareJoystickMap.Platform_XInput_Base.Button P_0, bool[] P_1, ref hrUcIohoksJRyJjOnZazbIlswca P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return false;
				}
				return hCGghiHxSAcLADozffLtfQoDJspU(P_0.sourceButton, P_1);
			}
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return false;
				}
				float num = TgLPLRPKTlXSaoodLpemjkZzehs(P_0.sourceAxis, ref P_2);
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

		private bool hCGghiHxSAcLADozffLtfQoDJspU(XInputButton P_0, bool[] P_1)
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

		private void YOJqghcNXYHtfCjcMsnGHhFpgHI()
		{
			QKBgAKpFvffffqJCzlcbbQpNNbB = muwCboYBpXBddhISLPoaIQYyEVOW(OiAyslXLaikGHSduwzwAoxjCWis());
			if (QKBgAKpFvffffqJCzlcbbQpNNbB == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			UFjahodKKlKgpFmJebtvtJcWHphB = QKBgAKpFvffffqJCzlcbbQpNNbB.axisCount;
			FJMdWUaGDInZZewwDxElGHTkrRvA = QKBgAKpFvffffqJCzlcbbQpNNbB.buttonCount;
		}

		private bool EjsnOMdXogBNRAPJZgIoewkzsmr(ref IVNavipaXjEHkzqGczlxUctDvay P_0)
		{
			if (P_0.SqDdIlyWecEOOyqeEcwEpyvkhtr > 0 || P_0.TJRKKbdsxZPXCMwHrxaOXCmKfRA > 0)
			{
				return true;
			}
			return false;
		}

		private void fDYPJUjxxsRkSlvqrisnBivQLrH(ref IVNavipaXjEHkzqGczlxUctDvay P_0)
		{
			P_0.SqDdIlyWecEOOyqeEcwEpyvkhtr = 0;
			P_0.TJRKKbdsxZPXCMwHrxaOXCmKfRA = 0;
		}

		private void zzzusXZHfUXiXDZbBQeZdqEsjvBE(ref IVNavipaXjEHkzqGczlxUctDvay P_0, ref IVNavipaXjEHkzqGczlxUctDvay P_1)
		{
			P_1.SqDdIlyWecEOOyqeEcwEpyvkhtr = P_0.SqDdIlyWecEOOyqeEcwEpyvkhtr;
			P_1.TJRKKbdsxZPXCMwHrxaOXCmKfRA = P_0.TJRKKbdsxZPXCMwHrxaOXCmKfRA;
		}

		private string AbSdQehDUFLFwmADWQZyBfSeEcFK()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.XInput.ToString()}{LmCxCdpctlbWkBhaHlFmbFALKEJ.ToString()}{zZDSOSlfNBhWwUJDseoHkaUNagX.ToString()}");
		}

		private void znmRFnJWmRHaLzxNQMvWhUZoLvz(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.XInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = ControlDeviceType.CxIBFsnaOMTSettXyfvwFIXcUdA;
			P_0.hardwareIdentifier = AbSdQehDUFLFwmADWQZyBfSeEcFK();
			P_0.hardwareAxisCount = cOVEXSAIuvbznALDYKQQXTxspUvG;
			P_0.hardwareButtonCount = xOcVIiUgaPmbRhbRYiQWvhIsYap;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = productName;
			P_0.hw_supportsVoice = sXwggIKUNmjykHzWTfQrbzPGTeLG;
			P_0.hw_supportsVibration = rPgbDjuxkQCjUxKyoCDTJEWtoRC;
			P_0.hw_localVibrationMotorCount = (rPgbDjuxkQCjUxKyoCDTJEWtoRC ? 2 : 0);
			P_0.hw_xInputSubType = zZDSOSlfNBhWwUJDseoHkaUNagX;
		}

		private void znmRFnJWmRHaLzxNQMvWhUZoLvz(BridgedController P_0)
		{
			znmRFnJWmRHaLzxNQMvWhUZoLvz((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = QKBgAKpFvffffqJCzlcbbQpNNbB.ToGameHardwareControllerMap();
			P_0.instanceName = "XInput " + instanceName;
			P_0.productName = "XInput " + productName;
			P_0.isXInputDevice = true;
			P_0.axisCount = UFjahodKKlKgpFmJebtvtJcWHphB;
			P_0.buttonCount = FJMdWUaGDInZZewwDxElGHTkrRvA;
			P_0.controllerTypeGuid = QmLKgYYPeYYRxIivEciniTYoXdO;
			P_0.controllerExtension = extension;
		}

		public void Dispose()
		{
			KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
			GC.SuppressFinalize(this);
		}

		~LrvDPxHfGyvMeFaEPPjjJuwpEYq()
		{
			KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
		}

		protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
		{
			if (euujVPFzGztViWDbYvUutBvFQFP)
			{
				return;
			}
			if (P_0)
			{
				if (isConnected)
				{
					fUWusVflpgaWsSNSoAiTBPWnobsa.LsNGDRXXNZFAzXijzhLTsNGAjEy();
				}
				if (fUWusVflpgaWsSNSoAiTBPWnobsa != null)
				{
					fUWusVflpgaWsSNSoAiTBPWnobsa.Dispose();
				}
			}
			euujVPFzGztViWDbYvUutBvFQFP = true;
		}
	}

	private class pFMGGxVoIWfbNhrnOVCqszJFPjhW
	{
		private class LwhwlFUMDxzArnsPAuyNUHefLtO
		{
			public bool cwHmKhGHAHYjRsJjovGwPkOHtHB;

			public int DnWOcqJTVBlYFHDWvysyPeNuQSq;

			public XInputDeviceSubType zZDSOSlfNBhWwUJDseoHkaUNagX;

			public void RMEkOMsGFSFWbHqrAFftMTIKNIHO(LrvDPxHfGyvMeFaEPPjjJuwpEYq P_0, bool P_1)
			{
				cwHmKhGHAHYjRsJjovGwPkOHtHB = P_1;
				DnWOcqJTVBlYFHDWvysyPeNuQSq = P_0.rewiredId;
				zZDSOSlfNBhWwUJDseoHkaUNagX = P_0.zZDSOSlfNBhWwUJDseoHkaUNagX;
			}

			public LwhwlFUMDxzArnsPAuyNUHefLtO(int rewiredId, XInputDeviceSubType deviceSubType)
			{
				DnWOcqJTVBlYFHDWvysyPeNuQSq = rewiredId;
				zZDSOSlfNBhWwUJDseoHkaUNagX = deviceSubType;
			}
		}

		private List<LwhwlFUMDxzArnsPAuyNUHefLtO> cRyaCDjwErkISWbxXDsigITBKjqT;

		public pFMGGxVoIWfbNhrnOVCqszJFPjhW()
		{
			cRyaCDjwErkISWbxXDsigITBKjqT = new List<LwhwlFUMDxzArnsPAuyNUHefLtO>();
		}

		public void cfXbhJeOeydImHXTyIgBDnIVsrPR(LrvDPxHfGyvMeFaEPPjjJuwpEYq P_0, bool P_1)
		{
			int num = HkuBROogyjTXYCIdeWrOxVjcZYh(P_0.rewiredId, P_0.zZDSOSlfNBhWwUJDseoHkaUNagX, true);
			if (num < 0)
			{
				LwhwlFUMDxzArnsPAuyNUHefLtO lwhwlFUMDxzArnsPAuyNUHefLtO = new LwhwlFUMDxzArnsPAuyNUHefLtO(P_0.rewiredId, P_0.zZDSOSlfNBhWwUJDseoHkaUNagX);
				lwhwlFUMDxzArnsPAuyNUHefLtO.cwHmKhGHAHYjRsJjovGwPkOHtHB = P_1;
				cRyaCDjwErkISWbxXDsigITBKjqT.Add(lwhwlFUMDxzArnsPAuyNUHefLtO);
			}
		}

		public void RMEkOMsGFSFWbHqrAFftMTIKNIHO(int P_0, LrvDPxHfGyvMeFaEPPjjJuwpEYq P_1, bool P_2)
		{
			if (P_0 >= 0 && P_0 < cRyaCDjwErkISWbxXDsigITBKjqT.Count)
			{
				cRyaCDjwErkISWbxXDsigITBKjqT[P_0].RMEkOMsGFSFWbHqrAFftMTIKNIHO(P_1, P_2);
			}
		}

		public int sxDFduksJKPkmAkeaVFgLdDkhOfg(XInputDeviceSubType P_0, bool P_1)
		{
			int count = cRyaCDjwErkISWbxXDsigITBKjqT.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_1 || !cRyaCDjwErkISWbxXDsigITBKjqT[i].cwHmKhGHAHYjRsJjovGwPkOHtHB) && cRyaCDjwErkISWbxXDsigITBKjqT[i].zZDSOSlfNBhWwUJDseoHkaUNagX == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		public int HkuBROogyjTXYCIdeWrOxVjcZYh(int P_0, XInputDeviceSubType P_1, bool P_2)
		{
			int count = cRyaCDjwErkISWbxXDsigITBKjqT.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_2 || !cRyaCDjwErkISWbxXDsigITBKjqT[i].cwHmKhGHAHYjRsJjovGwPkOHtHB) && cRyaCDjwErkISWbxXDsigITBKjqT[i].DnWOcqJTVBlYFHDWvysyPeNuQSq == P_0 && cRyaCDjwErkISWbxXDsigITBKjqT[i].zZDSOSlfNBhWwUJDseoHkaUNagX == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		public int PnODXQzsEOkeXfyfWJkhSdwlWDl(int P_0)
		{
			if (P_0 < 0 || P_0 >= cRyaCDjwErkISWbxXDsigITBKjqT.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return cRyaCDjwErkISWbxXDsigITBKjqT[P_0].DnWOcqJTVBlYFHDWvysyPeNuQSq;
		}

		public void mnOqUOFXTKlLXBETbBcglzPrYaZ(int P_0, bool P_1)
		{
			if (P_0 >= 0 && P_0 < cRyaCDjwErkISWbxXDsigITBKjqT.Count)
			{
				cRyaCDjwErkISWbxXDsigITBKjqT[P_0].cwHmKhGHAHYjRsJjovGwPkOHtHB = P_1;
			}
		}
	}

	private class ggqONODMpzFipsvhNOGygbocthl
	{
		public bool TzfzawCCKmiSQugewgJVCFLKEbAP;

		private double FKkEVClhSunTECYHjOfbkOsISAJ;

		public float tBoUpppgZNaGCvLZuJHCmhsItew;

		public ggqONODMpzFipsvhNOGygbocthl()
		{
		}

		public ggqONODMpzFipsvhNOGygbocthl(float inLength)
		{
			tBoUpppgZNaGCvLZuJHCmhsItew = inLength;
		}

		public void GLqFjpJWOmaiIIPQEPXLKjDgABxr()
		{
			TzfzawCCKmiSQugewgJVCFLKEbAP = true;
			FKkEVClhSunTECYHjOfbkOsISAJ = (double)tBoUpppgZNaGCvLZuJHCmhsItew + ReInput.unscaledTime;
		}

		public void GLqFjpJWOmaiIIPQEPXLKjDgABxr(float P_0)
		{
			TzfzawCCKmiSQugewgJVCFLKEbAP = true;
			tBoUpppgZNaGCvLZuJHCmhsItew = P_0;
			FKkEVClhSunTECYHjOfbkOsISAJ = (double)tBoUpppgZNaGCvLZuJHCmhsItew + ReInput.unscaledTime;
		}

		public bool RMEkOMsGFSFWbHqrAFftMTIKNIHO()
		{
			if (!TzfzawCCKmiSQugewgJVCFLKEbAP)
			{
				return false;
			}
			if (ReInput.unscaledTime >= FKkEVClhSunTECYHjOfbkOsISAJ)
			{
				TzfzawCCKmiSQugewgJVCFLKEbAP = false;
				return true;
			}
			return false;
		}

		public void avkcOhFlGGeHrNSdTQlLZUnJDbw()
		{
			TzfzawCCKmiSQugewgJVCFLKEbAP = false;
			FKkEVClhSunTECYHjOfbkOsISAJ = 0.0;
		}

		public void VDCqKoBaPWYvwDyEgAdKKLXAJak(float P_0)
		{
			tBoUpppgZNaGCvLZuJHCmhsItew = P_0;
		}

		public ggqONODMpzFipsvhNOGygbocthl DQpsWSoZALvEYhrAWLqrMwaAKNk()
		{
			return (ggqONODMpzFipsvhNOGygbocthl)MemberwiseClone();
		}
	}

	public class vpVfMtKUngfGMQjRsZBKhMWSnkMD : IDisposable
	{
		public readonly biGdEyfgIQaWprfghoTBDxkfEGEU vKBaAPQDZOAtcrDDXredlCKNpPr;

		public hrUcIohoksJRyJjOnZazbIlswca wsxuYdlgBUJRnBGOPWCbPVxZBsB;

		private bool eFIldJHAlwDZVMNuZYxdjxWSQFI;

		private readonly ButtonLoopSet sdzgyVcwHqRpNJLIhbGtHGVnHPZd;

		private hrUcIohoksJRyJjOnZazbIlswca SbdDDuQbDUehHPCIdmLpPmQfjIV;

		private bool CTmQqFCAurIslDMCuAwKpvrpPMo;

		private DualThreadLowLevelInputEventQueue svaNJVSHYqJtTvuXjDrXdclMBTr;

		private readonly object DYqmLYQWtnCkUZCOjwXSRkHXDqs;

		private RingBuffer<IVNavipaXjEHkzqGczlxUctDvay> ZeOwKNpsePnHCvJOihkjcfCPTSE = new RingBuffer<IVNavipaXjEHkzqGczlxUctDvay>(5);

		private RingBuffer<IVNavipaXjEHkzqGczlxUctDvay> NILgvLBATLlJHszTLNIxeysQcUiC = new RingBuffer<IVNavipaXjEHkzqGczlxUctDvay>(5);

		private readonly object trTyFPHKaIQqKZkMYeptltgJEHz = new object();

		private readonly object kBmEBaEBFLGzLGyIPERTprEEJtE = new object();

		private IVNavipaXjEHkzqGczlxUctDvay QdzZYKeIlPUmLVrpMfsyHZeCRvB;

		private double eSTSPhWHpxTtkMdQxmITYFDXDqY;

		private bool euujVPFzGztViWDbYvUutBvFQFP;

		public bool[] CurrentButtonValues => sdzgyVcwHqRpNJLIhbGtHGVnHPZd.Current.effectiveValue;

		public vpVfMtKUngfGMQjRsZBKhMWSnkMD(int controllerIndex, UpdateLoopSetting updateLoops)
		{
			vKBaAPQDZOAtcrDDXredlCKNpPr = new biGdEyfgIQaWprfghoTBDxkfEGEU((TLOzBcPflexWLvPrKuyTsBwOAqU)controllerIndex);
			sdzgyVcwHqRpNJLIhbGtHGVnHPZd = new ButtonLoopSet(updateLoops, 15);
			DYqmLYQWtnCkUZCOjwXSRkHXDqs = new object();
			svaNJVSHYqJtTvuXjDrXdclMBTr = new DualThreadLowLevelInputEventQueue((int)((float)oizETVRXykJREMrljZxCoqipUeW.joystickRefreshRate * 0.25f), 15, 6, 0);
		}

		public void NNKDQtzuxXoooYVfbmDIlBryQvg()
		{
			sdzgyVcwHqRpNJLIhbGtHGVnHPZd.SetUpdateLoop(ReInput.currentUpdateLoop);
			RMWKIjwZMjxqyuDOYeaObewVngm(ref wsxuYdlgBUJRnBGOPWCbPVxZBsB);
		}

		public void xbrgbsymhweSXlyAZAqkvRqFNEB()
		{
			gGtbVLIbxBhBuUZPpggraTfTvCr();
			sdzgyVcwHqRpNJLIhbGtHGVnHPZd.Current.ClearWasTrueThisFrame();
		}

		public void DfsndYxHYVKUdQgDuAfETngfexb()
		{
			TzBPrZngbKbHBhJPAmtHpHNMMTtf();
			eFIldJHAlwDZVMNuZYxdjxWSQFI = true;
			CTmQqFCAurIslDMCuAwKpvrpPMo = vKBaAPQDZOAtcrDDXredlCKNpPr.IsConnected;
		}

		public void ibjqBHyFNJOhWJActsfrTOPbIjF()
		{
			eFIldJHAlwDZVMNuZYxdjxWSQFI = false;
			CTmQqFCAurIslDMCuAwKpvrpPMo = false;
			TzBPrZngbKbHBhJPAmtHpHNMMTtf();
		}

		public bool UdRmJTAFcfCpSRTYduMvUfAoPUW(PpGLXDbpIbUQoQfJgPjVzGIXDryh P_0)
		{
			return P_0 switch
			{
				PpGLXDbpIbUQoQfJgPjVzGIXDryh.qalJCBWGPnTWajUHtqFaMFwFuVa => CTmQqFCAurIslDMCuAwKpvrpPMo = vKBaAPQDZOAtcrDDXredlCKNpPr.IsConnected, 
				PpGLXDbpIbUQoQfJgPjVzGIXDryh.McTDqofjwxcaTvHmKRrvobGgrZf => CTmQqFCAurIslDMCuAwKpvrpPMo, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void nfmGmYcyUlTLqwzJLoQIeHZegFf(float P_0, int P_1)
		{
			switch (P_1)
			{
			case 0:
				QdzZYKeIlPUmLVrpMfsyHZeCRvB.SqDdIlyWecEOOyqeEcwEpyvkhtr = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			case 1:
				QdzZYKeIlPUmLVrpMfsyHZeCRvB.TJRKKbdsxZPXCMwHrxaOXCmKfRA = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			}
			hzEuQtDZnoiTuXSvIPaTmQjimvW();
		}

		public void sBPDsqHNIOqsXGZWBzefFlYFtqJ()
		{
			QdzZYKeIlPUmLVrpMfsyHZeCRvB.SqDdIlyWecEOOyqeEcwEpyvkhtr = 0;
			QdzZYKeIlPUmLVrpMfsyHZeCRvB.TJRKKbdsxZPXCMwHrxaOXCmKfRA = 0;
			hzEuQtDZnoiTuXSvIPaTmQjimvW();
		}

		public void LsNGDRXXNZFAzXijzhLTsNGAjEy()
		{
			QdzZYKeIlPUmLVrpMfsyHZeCRvB.SqDdIlyWecEOOyqeEcwEpyvkhtr = 0;
			QdzZYKeIlPUmLVrpMfsyHZeCRvB.TJRKKbdsxZPXCMwHrxaOXCmKfRA = 0;
			lock (kBmEBaEBFLGzLGyIPERTprEEJtE)
			{
				lock (trTyFPHKaIQqKZkMYeptltgJEHz)
				{
					ZeOwKNpsePnHCvJOihkjcfCPTSE.Clear();
					NILgvLBATLlJHszTLNIxeysQcUiC.Clear();
					IYoaBrCcCglttdAPKwJfDsGRQULk(vKBaAPQDZOAtcrDDXredlCKNpPr, QdzZYKeIlPUmLVrpMfsyHZeCRvB, ref eSTSPhWHpxTtkMdQxmITYFDXDqY);
				}
			}
		}

		public void SxqVNaMrRMtlOMKLOfQkAYtJYqel()
		{
			if (!eFIldJHAlwDZVMNuZYxdjxWSQFI || !CTmQqFCAurIslDMCuAwKpvrpPMo)
			{
				return;
			}
			RurWwwaiAKvkjxYcgOjFhSgRbOg rurWwwaiAKvkjxYcgOjFhSgRbOg;
			double realTime;
			try
			{
				if (!vKBaAPQDZOAtcrDDXredlCKNpPr.nXpAElfMyRBejuHmJdLDEwIxBEDW(out rurWwwaiAKvkjxYcgOjFhSgRbOg))
				{
					CTmQqFCAurIslDMCuAwKpvrpPMo = false;
					return;
				}
				realTime = ReInput.realTime;
			}
			catch
			{
				CTmQqFCAurIslDMCuAwKpvrpPMo = false;
				return;
			}
			lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
			{
				if (!SMzyHOEAHfnOGRmxHgDUfLkCpLrN(rurWwwaiAKvkjxYcgOjFhSgRbOg.cMDdbqtCLCmlakqTbYRMVcREdGI, SbdDDuQbDUehHPCIdmLpPmQfjIV))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = svaNJVSHYqJtTvuXjDrXdclMBTr.T_CreateEvent())
					{
						YPPKAVlNxrcwSbhCdKrDKJBimoVR(ref rurWwwaiAKvkjxYcgOjFhSgRbOg.cMDdbqtCLCmlakqTbYRMVcREdGI, realTime, newEventWrapper.Event);
					}
					SbdDDuQbDUehHPCIdmLpPmQfjIV = rurWwwaiAKvkjxYcgOjFhSgRbOg.cMDdbqtCLCmlakqTbYRMVcREdGI;
				}
			}
		}

		public void hNfaXfhkFnPcMHXHiqhiBkWJgBCK()
		{
			if (!eFIldJHAlwDZVMNuZYxdjxWSQFI || !CTmQqFCAurIslDMCuAwKpvrpPMo || ReInput.realTime < eSTSPhWHpxTtkMdQxmITYFDXDqY + 0.009999999776482582)
			{
				return;
			}
			lock (kBmEBaEBFLGzLGyIPERTprEEJtE)
			{
				lock (trTyFPHKaIQqKZkMYeptltgJEHz)
				{
					MiscTools.Swap(ref ZeOwKNpsePnHCvJOihkjcfCPTSE, ref NILgvLBATLlJHszTLNIxeysQcUiC);
				}
				uvJZMzmzyjRZBoJigRCqJBELKFs(NILgvLBATLlJHszTLNIxeysQcUiC, vKBaAPQDZOAtcrDDXredlCKNpPr, ref eSTSPhWHpxTtkMdQxmITYFDXDqY);
			}
		}

		private void gGtbVLIbxBhBuUZPpggraTfTvCr()
		{
			DLJbuVJQZwsChYwFQIdAwXkGbpm();
		}

		private void DLJbuVJQZwsChYwFQIdAwXkGbpm()
		{
			if (!(ReInput.realTime < eSTSPhWHpxTtkMdQxmITYFDXDqY + 1.5) && (!Mathf.Approximately((int)QdzZYKeIlPUmLVrpMfsyHZeCRvB.SqDdIlyWecEOOyqeEcwEpyvkhtr, 0f) || !Mathf.Approximately((int)QdzZYKeIlPUmLVrpMfsyHZeCRvB.TJRKKbdsxZPXCMwHrxaOXCmKfRA, 0f)))
			{
				hzEuQtDZnoiTuXSvIPaTmQjimvW();
			}
		}

		private void hzEuQtDZnoiTuXSvIPaTmQjimvW()
		{
			lock (trTyFPHKaIQqKZkMYeptltgJEHz)
			{
				ZeOwKNpsePnHCvJOihkjcfCPTSE.Enqueue(QdzZYKeIlPUmLVrpMfsyHZeCRvB);
			}
		}

		private static void uvJZMzmzyjRZBoJigRCqJBELKFs(RingBuffer<IVNavipaXjEHkzqGczlxUctDvay> P_0, biGdEyfgIQaWprfghoTBDxkfEGEU P_1, ref double P_2)
		{
			if (P_0.Count > 0)
			{
				IYoaBrCcCglttdAPKwJfDsGRQULk(P_1, P_0[P_0.Count - 1], ref P_2);
				P_0.Clear();
			}
		}

		private static void IYoaBrCcCglttdAPKwJfDsGRQULk(biGdEyfgIQaWprfghoTBDxkfEGEU P_0, IVNavipaXjEHkzqGczlxUctDvay P_1, ref double P_2)
		{
			try
			{
				P_0.nfmGmYcyUlTLqwzJLoQIeHZegFf(P_1);
			}
			catch
			{
			}
			P_2 = ReInput.realTime;
		}

		private void RMWKIjwZMjxqyuDOYeaObewVngm(ref hrUcIohoksJRyJjOnZazbIlswca P_0)
		{
			while (svaNJVSHYqJtTvuXjDrXdclMBTr.ProcessNewEvents())
			{
				txtblvlGjpzLZamphVDmjOFXUnq(ref P_0, ref svaNJVSHYqJtTvuXjDrXdclMBTr.currentEvent);
				for (int i = 0; i < 15; i++)
				{
					sdzgyVcwHqRpNJLIhbGtHGVnHPZd.SetValue(i, hCGghiHxSAcLADozffLtfQoDJspU((int)P_0.TUYMVHGCBHgHkIfQYSkUtTsGyCJ, i), svaNJVSHYqJtTvuXjDrXdclMBTr.currentEvent.GetTimestamp());
				}
			}
		}

		private void YPPKAVlNxrcwSbhCdKrDKJBimoVR(ref hrUcIohoksJRyJjOnZazbIlswca P_0, double P_1, LowLevelInputEvent P_2)
		{
			P_2.SetTimestamp(P_1);
			int tUYMVHGCBHgHkIfQYSkUtTsGyCJ = (int)P_0.TUYMVHGCBHgHkIfQYSkUtTsGyCJ;
			P_2.SetButtonsBitMask((tUYMVHGCBHgHkIfQYSkUtTsGyCJ & 0x7FF) | ((tUYMVHGCBHgHkIfQYSkUtTsGyCJ & (tUYMVHGCBHgHkIfQYSkUtTsGyCJ & -4096)) >> 1), 0);
			P_2.SetAxisValue(0, gGNoAhCUXzgDbDcskWksokriYti(P_0.xcjJKYsOhJDGyABhRrYnugjrIwJO));
			P_2.SetAxisValue(1, gGNoAhCUXzgDbDcskWksokriYti(P_0.PgPPQFmlukMjHbGCkPHKcBNDHQVe));
			P_2.SetAxisValue(2, gGNoAhCUXzgDbDcskWksokriYti(P_0.NGFeKsUVpmGlLgiHwjABwrxVngW));
			P_2.SetAxisValue(3, gGNoAhCUXzgDbDcskWksokriYti(P_0.ttypRSEQZPochloohJAmnomPllh));
			P_2.SetAxisValue(4, pFvogLNFlkHNdCYuzUoyjSxIujK(P_0.VyvdwxScxQAVyTEQdmFkjznaCyW));
			P_2.SetAxisValue(5, pFvogLNFlkHNdCYuzUoyjSxIujK(P_0.btnmAjJJoIFOiKKnAaBWbPcbjLby));
		}

		private void txtblvlGjpzLZamphVDmjOFXUnq(ref hrUcIohoksJRyJjOnZazbIlswca P_0, ref LowLevelInputEvent P_1)
		{
			int buttonsBitMask = P_1.GetButtonsBitMask(0);
			P_0.TUYMVHGCBHgHkIfQYSkUtTsGyCJ = (qjObmXDFgcOeKlMPNnsRPZpkuBf)((buttonsBitMask & 0x7FF) | ((buttonsBitMask & (buttonsBitMask & -2048)) << 1));
			P_0.xcjJKYsOhJDGyABhRrYnugjrIwJO = (short)(P_1.GetAxisValue(0) * 32768f);
			P_0.PgPPQFmlukMjHbGCkPHKcBNDHQVe = (short)(P_1.GetAxisValue(1) * 32768f);
			P_0.NGFeKsUVpmGlLgiHwjABwrxVngW = (short)(P_1.GetAxisValue(2) * 32768f);
			P_0.ttypRSEQZPochloohJAmnomPllh = (short)(P_1.GetAxisValue(3) * 32768f);
			P_0.VyvdwxScxQAVyTEQdmFkjznaCyW = (byte)(P_1.GetAxisValue(4) * 255f);
			P_0.btnmAjJJoIFOiKKnAaBWbPcbjLby = (byte)(P_1.GetAxisValue(5) * 255f);
		}

		private static bool hCGghiHxSAcLADozffLtfQoDJspU(int P_0, int P_1)
		{
			if (P_1 > 10)
			{
				P_1++;
			}
			return (P_0 & (1 << P_1)) != 0;
		}

		private void TzBPrZngbKbHBhJPAmtHpHNMMTtf()
		{
			lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
			{
				wsxuYdlgBUJRnBGOPWCbPVxZBsB = default(hrUcIohoksJRyJjOnZazbIlswca);
				SbdDDuQbDUehHPCIdmLpPmQfjIV = default(hrUcIohoksJRyJjOnZazbIlswca);
				sdzgyVcwHqRpNJLIhbGtHGVnHPZd.Clear();
				svaNJVSHYqJtTvuXjDrXdclMBTr.Clear();
			}
		}

		public void Dispose()
		{
			KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
			GC.SuppressFinalize(this);
		}

		~vpVfMtKUngfGMQjRsZBKhMWSnkMD()
		{
			KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
		}

		protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
		{
			if (!euujVPFzGztViWDbYvUutBvFQFP)
			{
				if (P_0)
				{
					svaNJVSHYqJtTvuXjDrXdclMBTr.Dispose();
				}
				euujVPFzGztViWDbYvUutBvFQFP = true;
			}
		}

		public static float gGNoAhCUXzgDbDcskWksokriYti(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 32768f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		public static float pFvogLNFlkHNdCYuzUoyjSxIujK(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 255f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private static bool SMzyHOEAHfnOGRmxHgDUfLkCpLrN(hrUcIohoksJRyJjOnZazbIlswca P_0, hrUcIohoksJRyJjOnZazbIlswca P_1)
		{
			if (P_0.TUYMVHGCBHgHkIfQYSkUtTsGyCJ == P_1.TUYMVHGCBHgHkIfQYSkUtTsGyCJ && P_0.VyvdwxScxQAVyTEQdmFkjznaCyW == P_1.VyvdwxScxQAVyTEQdmFkjznaCyW && P_0.btnmAjJJoIFOiKKnAaBWbPcbjLby == P_1.btnmAjJJoIFOiKKnAaBWbPcbjLby && P_0.xcjJKYsOhJDGyABhRrYnugjrIwJO == P_1.xcjJKYsOhJDGyABhRrYnugjrIwJO && P_0.PgPPQFmlukMjHbGCkPHKcBNDHQVe == P_1.PgPPQFmlukMjHbGCkPHKcBNDHQVe && P_0.NGFeKsUVpmGlLgiHwjABwrxVngW == P_1.NGFeKsUVpmGlLgiHwjABwrxVngW)
			{
				return P_0.ttypRSEQZPochloohJAmnomPllh == P_1.ttypRSEQZPochloohJAmnomPllh;
			}
			return false;
		}
	}

	public enum PpGLXDbpIbUQoQfJgPjVzGIXDryh
	{
		qalJCBWGPnTWajUHtqFaMFwFuVa = 0,
		McTDqofjwxcaTvHmKRrvobGgrZf = 1
	}

	public const int DIeEkZhBYxynTsRIMWRRtbwOuryN = 4;

	public const int zVrTdppTmggdpSIGLcfDBRvldASp = 32768;

	public const int imAgLaJNJAIqcJSPDIamBYvdHobV = -32768;

	public const int wzQXBLtVSntXEirPtuFicuazABd = 255;

	public const int LjWKKDDhHdyGSKxqXcRgMGYXPlo = 0;

	public const int YnCaGUGXZOFdOirDiwmJqikHmKf = 18;

	public const int vIJNGHhLpkOEmaRPykTpNGsQowC = 14;

	public const int IbPXLvryHOqDuXoJahQcInhCOob = 6;

	public const int jchzvdTiCHghIfTRXztaZiypYYf = 15;

	private LrvDPxHfGyvMeFaEPPjjJuwpEYq[] eCBEdeYeSWJTQebjNjaOjohcRkP;

	private bool FHneqUzjpxkXMcDRIHsjQPzMHrS;

	private ggqONODMpzFipsvhNOGygbocthl ngTAOjGgsFfOtoZuTRSGkLPQSWNp;

	private pFMGGxVoIWfbNhrnOVCqszJFPjhW hkllBbSvWePFkNoJvTVpOZjERes;

	private global::SmnfRaZRTCRKUNzdKVQSwqJahva<bool> xnhEOafvVmqEfCZFepVuWHXDLfDy;

	private bool[] pLHuQxfJkgpTrczpWqmovVzAJFs;

	private bool[] EilmEnqLsVTWsYdmwhDpwpIljnf;

	private bool tRcZRyahcbitwohIPWrUYISZbXmH;

	private readonly bool XNiBcbfAOVRvBFxCZCDGBOPRVKF;

	private readonly UpdateLoopSetting FgREoWxRjDNWqaQZIHifDtHgOgI;

	private UpdateLoopType uuMOmKLvdgUaEkHIsavlcBLLSxtM;

	private UpdateLoopType ONsZCaBGWLSMOUplxjXTIrifLKU;

	private Action<int, ControllerDataUpdater> JcoiPGandIoCihCSGbQPMEFfAvAL;

	private bool YWwDiCDFaAGANtMKIHatcwCxUmBz;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> muwCboYBpXBddhISLPoaIQYyEVOW;

	private Func<int> ngZnFDsAelLLgZWmCeeSqxddlic;

	private static Guid[] fMRBdOjEEAtfvOJlGAwmbvPXVhUb;

	private static string[] XCLNOLeklYdbugOerDBXHgnBEhy;

	private static string[] PgVEloazmXKuhiqvNlehBdKpJWIi;

	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (eCBEdeYeSWJTQebjNjaOjohcRkP[i].isConnected)
				{
					num++;
				}
			}
			return num;
		}
	}

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => this;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => null;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.XInput;

	public dSElFGVpyqTZVtKoEbCEnZfBwBs(bool isWin10AUHack, UpdateLoopSetting updateLoop, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
	{
		XNiBcbfAOVRvBFxCZCDGBOPRVKF = isWin10AUHack;
		FgREoWxRjDNWqaQZIHifDtHgOgI = updateLoop;
		YWwDiCDFaAGANtMKIHatcwCxUmBz = true;
		try
		{
			if (!GBsSePSycbozcSRUzuvhWWKEEli.QaUcwhGLRRBnjcaMjVHoGuyQzyU(out var sTemBjjrVJIdAePWymtErDMfxOd, out var text, out var _))
			{
				throw new Exception("XInput is not available.");
			}
			if (sTemBjjrVJIdAePWymtErDMfxOd < STemBjjrVJIdAePWymtErDMfxOd.TnAeluaekfbSgGxrupogglCaDyBb)
			{
				Rewired.Logger.LogWarning("The version of XInput (" + text + ") detected on your system is out of date. Please update to the latest version of XInput. Input will still function, but all features may not be available. See the documentation for required dependencies.");
			}
			else
			{
				_ = 4;
			}
			muwCboYBpXBddhISLPoaIQYyEVOW = getHardwareJoystickMap_InputManager;
			ngZnFDsAelLLgZWmCeeSqxddlic = getNewJoystickId;
			tRcZRyahcbitwohIPWrUYISZbXmH = UnityTools.platform == Platform.WindowsAppStore;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(FgREoWxRjDNWqaQZIHifDtHgOgI, list);
				int num2 = 0;
				if (num2 < list.Count)
				{
					ONsZCaBGWLSMOUplxjXTIrifLKU = list[num2];
				}
			}
			xnhEOafvVmqEfCZFepVuWHXDLfDy = new global::SmnfRaZRTCRKUNzdKVQSwqJahva<bool>(useSharedThread: true, vutZGDydgzCPbtophjUIjlfDYRu);
			pLHuQxfJkgpTrczpWqmovVzAJFs = new bool[4];
			EilmEnqLsVTWsYdmwhDpwpIljnf = new bool[4];
			JcoiPGandIoCihCSGbQPMEFfAvAL = UpdateControllerData;
			if (tRcZRyahcbitwohIPWrUYISZbXmH)
			{
				gIdwgJtRpelzLADPjuhEHQdMCXH();
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
		if (YWwDiCDFaAGANtMKIHatcwCxUmBz)
		{
			ngTAOjGgsFfOtoZuTRSGkLPQSWNp = new ggqONODMpzFipsvhNOGygbocthl(1f);
		}
		hkllBbSvWePFkNoJvTVpOZjERes = new pFMGGxVoIWfbNhrnOVCqszJFPjhW();
		if (eCBEdeYeSWJTQebjNjaOjohcRkP == null)
		{
			eCBEdeYeSWJTQebjNjaOjohcRkP = new LrvDPxHfGyvMeFaEPPjjJuwpEYq[4];
			for (int i = 0; i < 4; i++)
			{
				vpVfMtKUngfGMQjRsZBKhMWSnkMD vpVfMtKUngfGMQjRsZBKhMWSnkMD2 = new vpVfMtKUngfGMQjRsZBKhMWSnkMD(i, FgREoWxRjDNWqaQZIHifDtHgOgI);
				oizETVRXykJREMrljZxCoqipUeW.joystickInputThread.ThreadUpdateEvent += vpVfMtKUngfGMQjRsZBKhMWSnkMD2.SxqVNaMrRMtlOMKLOfQkAYtJYqel;
				oizETVRXykJREMrljZxCoqipUeW.joystickOutputThread.ThreadUpdateEvent += vpVfMtKUngfGMQjRsZBKhMWSnkMD2.hNfaXfhkFnPcMHXHiqhiBkWJgBCK;
				eCBEdeYeSWJTQebjNjaOjohcRkP[i] = new LrvDPxHfGyvMeFaEPPjjJuwpEYq(i, tRcZRyahcbitwohIPWrUYISZbXmH, vpVfMtKUngfGMQjRsZBKhMWSnkMD2, muwCboYBpXBddhISLPoaIQYyEVOW, SystemDeviceDisconnected);
			}
		}
		xaZndTikSIPezZbQljQmVwDWpPJ(true);
		Update(UpdateLoopType.Update);
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		uuMOmKLvdgUaEkHIsavlcBLLSxtM = currentUpdateLoop;
		exSgneZYdsIdkachYNIgzYiIeQJ();
		for (int i = 0; i < 4; i++)
		{
			if (eCBEdeYeSWJTQebjNjaOjohcRkP[i] != null && eCBEdeYeSWJTQebjNjaOjohcRkP[i].isConnected)
			{
				eCBEdeYeSWJTQebjNjaOjohcRkP[i].Update();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (xnhEOafvVmqEfCZFepVuWHXDLfDy != null)
		{
			xnhEOafvVmqEfCZFepVuWHXDLfDy.KRgasgBmyLeCeDGJhNGqwMeOqCwJ();
		}
		if (eCBEdeYeSWJTQebjNjaOjohcRkP != null)
		{
			for (int i = 0; i < 4; i++)
			{
				if (eCBEdeYeSWJTQebjNjaOjohcRkP[i] != null)
				{
					if (oizETVRXykJREMrljZxCoqipUeW.joystickInputThread != null)
					{
						oizETVRXykJREMrljZxCoqipUeW.joystickInputThread.ThreadUpdateEvent -= eCBEdeYeSWJTQebjNjaOjohcRkP[i].fUWusVflpgaWsSNSoAiTBPWnobsa.SxqVNaMrRMtlOMKLOfQkAYtJYqel;
					}
					if (oizETVRXykJREMrljZxCoqipUeW.joystickOutputThread != null)
					{
						oizETVRXykJREMrljZxCoqipUeW.joystickOutputThread.ThreadUpdateEvent -= eCBEdeYeSWJTQebjNjaOjohcRkP[i].fUWusVflpgaWsSNSoAiTBPWnobsa.hNfaXfhkFnPcMHXHiqhiBkWJgBCK;
					}
					eCBEdeYeSWJTQebjNjaOjohcRkP[i].Dispose();
				}
			}
		}
		GBsSePSycbozcSRUzuvhWWKEEli.sCgtROBexWTssqnqFGbMqaFuiIS();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return JcoiPGandIoCihCSGbQPMEFfAvAL;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		eCBEdeYeSWJTQebjNjaOjohcRkP[assignedControllerId].FillData(data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		xaZndTikSIPezZbQljQmVwDWpPJ(true);
		nQvePwQfvZtDuhMLfRgoFuYtBTi();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		xaZndTikSIPezZbQljQmVwDWpPJ(true);
		nQvePwQfvZtDuhMLfRgoFuYtBTi();
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

	private bool FIDHjtgiwOyFJmFLvUFKIjlvxt()
	{
		if (uuMOmKLvdgUaEkHIsavlcBLLSxtM != ONsZCaBGWLSMOUplxjXTIrifLKU)
		{
			return false;
		}
		bool flag = ngTAOjGgsFfOtoZuTRSGkLPQSWNp.RMEkOMsGFSFWbHqrAFftMTIKNIHO();
		if (flag)
		{
			xaZndTikSIPezZbQljQmVwDWpPJ(true);
		}
		return flag;
	}

	private void xaZndTikSIPezZbQljQmVwDWpPJ(bool P_0)
	{
		FHneqUzjpxkXMcDRIHsjQPzMHrS = P_0;
		if (YWwDiCDFaAGANtMKIHatcwCxUmBz)
		{
			ngTAOjGgsFfOtoZuTRSGkLPQSWNp.GLqFjpJWOmaiIIPQEPXLKjDgABxr();
		}
	}

	private void nQvePwQfvZtDuhMLfRgoFuYtBTi()
	{
		if (xnhEOafvVmqEfCZFepVuWHXDLfDy != null)
		{
			xnhEOafvVmqEfCZFepVuWHXDLfDy.avkcOhFlGGeHrNSdTQlLZUnJDbw();
		}
	}

	private void gIdwgJtRpelzLADPjuhEHQdMCXH()
	{
		biGdEyfgIQaWprfghoTBDxkfEGEU biGdEyfgIQaWprfghoTBDxkfEGEU2 = new biGdEyfgIQaWprfghoTBDxkfEGEU();
		_ = biGdEyfgIQaWprfghoTBDxkfEGEU2.IsConnected;
	}

	private void exSgneZYdsIdkachYNIgzYiIeQJ()
	{
		bool flag = false;
		if (YWwDiCDFaAGANtMKIHatcwCxUmBz)
		{
			flag = FIDHjtgiwOyFJmFLvUFKIjlvxt();
		}
		if (!flag && FHneqUzjpxkXMcDRIHsjQPzMHrS)
		{
			DvtxfZInDTSwpAWNavypjEREqkk(jvkgctIlpzqTfczRzSfiuRtmZAL());
			xaZndTikSIPezZbQljQmVwDWpPJ(false);
			nQvePwQfvZtDuhMLfRgoFuYtBTi();
			return;
		}
		if (FHneqUzjpxkXMcDRIHsjQPzMHrS)
		{
			ADgVHLRwiilDWZwTLColkzizLqb();
		}
		if (xnhEOafvVmqEfCZFepVuWHXDLfDy.isRunning && xnhEOafvVmqEfCZFepVuWHXDLfDy.wcZXiwBuSxlGFrbXURQEZElVWiH())
		{
			PTWORQqgBdUCodONUbJlUWFGkKU();
		}
	}

	private void ADgVHLRwiilDWZwTLColkzizLqb()
	{
		FHneqUzjpxkXMcDRIHsjQPzMHrS = false;
		if (!xnhEOafvVmqEfCZFepVuWHXDLfDy.isRunning)
		{
			xnhEOafvVmqEfCZFepVuWHXDLfDy.HnocEhRkacOxHhLLsmQmCGWhJlU();
		}
	}

	private void PTWORQqgBdUCodONUbJlUWFGkKU()
	{
		lock (pLHuQxfJkgpTrczpWqmovVzAJFs)
		{
			Array.Copy(pLHuQxfJkgpTrczpWqmovVzAJFs, EilmEnqLsVTWsYdmwhDpwpIljnf, 4);
		}
		DvtxfZInDTSwpAWNavypjEREqkk(EilmEnqLsVTWsYdmwhDpwpIljnf);
	}

	private bool vutZGDydgzCPbtophjUIjlfDYRu()
	{
		lock (pLHuQxfJkgpTrczpWqmovVzAJFs)
		{
			for (int i = 0; i < 4; i++)
			{
				if (eCBEdeYeSWJTQebjNjaOjohcRkP[i] != null)
				{
					pLHuQxfJkgpTrczpWqmovVzAJFs[i] = eCBEdeYeSWJTQebjNjaOjohcRkP[i].UdRmJTAFcfCpSRTYduMvUfAoPUW(PpGLXDbpIbUQoQfJgPjVzGIXDryh.qalJCBWGPnTWajUHtqFaMFwFuVa);
				}
			}
		}
		return true;
	}

	private bool[] jvkgctIlpzqTfczRzSfiuRtmZAL()
	{
		for (int i = 0; i < 4; i++)
		{
			EilmEnqLsVTWsYdmwhDpwpIljnf[i] = eCBEdeYeSWJTQebjNjaOjohcRkP[i].UdRmJTAFcfCpSRTYduMvUfAoPUW(PpGLXDbpIbUQoQfJgPjVzGIXDryh.qalJCBWGPnTWajUHtqFaMFwFuVa);
		}
		return EilmEnqLsVTWsYdmwhDpwpIljnf;
	}

	private void DvtxfZInDTSwpAWNavypjEREqkk(bool[] P_0)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (eCBEdeYeSWJTQebjNjaOjohcRkP[i] != null && eCBEdeYeSWJTQebjNjaOjohcRkP[i].vhBgxexuavhFyiAhHnDNfGvahEZJ)
			{
				bool flag = P_0[i];
				eCBEdeYeSWJTQebjNjaOjohcRkP[i].FPsdgujyNxlnpWBNIHemIDivhFY(flag);
				if (!flag)
				{
					ybsGugBBooRgYsLwSUUgUZpACxl(eCBEdeYeSWJTQebjNjaOjohcRkP[i], false);
				}
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (eCBEdeYeSWJTQebjNjaOjohcRkP[j] != null && !eCBEdeYeSWJTQebjNjaOjohcRkP[j].vhBgxexuavhFyiAhHnDNfGvahEZJ)
			{
				bool flag2 = P_0[j];
				eCBEdeYeSWJTQebjNjaOjohcRkP[j].FPsdgujyNxlnpWBNIHemIDivhFY(flag2);
				if (flag2 && !ybsGugBBooRgYsLwSUUgUZpACxl(eCBEdeYeSWJTQebjNjaOjohcRkP[j], true))
				{
					num |= ((j == 0) ? 1 : (1 << j));
				}
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (eCBEdeYeSWJTQebjNjaOjohcRkP[k] != null)
			{
				int num2 = ((k == 0) ? 1 : (1 << k));
				if ((num & num2) != 1 << k)
				{
					eCBEdeYeSWJTQebjNjaOjohcRkP[k].YYIbizKGxLGaVnJRqxHgOoZTMpK(P_0[k]);
				}
			}
		}
	}

	private bool ybsGugBBooRgYsLwSUUgUZpACxl(LrvDPxHfGyvMeFaEPPjjJuwpEYq P_0, bool P_1)
	{
		if (P_1)
		{
			P_0.jtEatkevZEpPorDVxHmTCvzGACqR();
			if (!P_0.ZTxcXqFCXcMcFbJzbogdaSAwtHxZ)
			{
				return false;
			}
			int num = hkllBbSvWePFkNoJvTVpOZjERes.sxDFduksJKPkmAkeaVFgLdDkhOfg(P_0.zZDSOSlfNBhWwUJDseoHkaUNagX, false);
			if (num >= 0)
			{
				P_0.rewiredId = hkllBbSvWePFkNoJvTVpOZjERes.PnODXQzsEOkeXfyfWJkhSdwlWDl(num);
				hkllBbSvWePFkNoJvTVpOZjERes.RMEkOMsGFSFWbHqrAFftMTIKNIHO(num, P_0, true);
			}
			else
			{
				P_0.rewiredId = ngZnFDsAelLLgZWmCeeSqxddlic();
				hkllBbSvWePFkNoJvTVpOZjERes.cfXbhJeOeydImHXTyIgBDnIVsrPR(P_0, true);
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
			int num2 = hkllBbSvWePFkNoJvTVpOZjERes.HkuBROogyjTXYCIdeWrOxVjcZYh(P_0.rewiredId, P_0.zZDSOSlfNBhWwUJDseoHkaUNagX, true);
			if (num2 >= 0)
			{
				hkllBbSvWePFkNoJvTVpOZjERes.mnOqUOFXTKlLXBETbBcglzPrYaZ(num2, false);
			}
			ControllerDisconnectedEventArgs obj2 = P_0.ToControllerDisconnectedEventArgs();
			P_0.EgfcjPvvEnaEjugFaqbWLfYFiGh();
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(obj2);
			}
		}
		return true;
	}

	static dSElFGVpyqTZVtKoEbCEnZfBwBs()
	{
		fMRBdOjEEAtfvOJlGAwmbvPXVhUb = new Guid[2]
		{
			new Guid("72100955-0000-0000-0000-504944564944"),
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		XCLNOLeklYdbugOerDBXHgnBEhy = new string[1] { "Xbox Bluetooth Gamepad" };
		PgVEloazmXKuhiqvNlehBdKpJWIi = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool AtUjsMHXuqlHRCvkrgGRGBocvYd(string P_0, string P_1, string P_2, Guid P_3)
	{
		if (ArrayTools.Contains(fMRBdOjEEAtfvOJlGAwmbvPXVhUb, P_3))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < XCLNOLeklYdbugOerDBXHgnBEhy.Length; i++)
			{
				if (P_1.Equals(XCLNOLeklYdbugOerDBXHgnBEhy[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		if (!string.IsNullOrEmpty(P_2))
		{
			for (int j = 0; j < PgVEloazmXKuhiqvNlehBdKpJWIi.Length; j++)
			{
				if (Regex.IsMatch(P_2, PgVEloazmXKuhiqvNlehBdKpJWIi[j], RegexOptions.IgnoreCase))
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
