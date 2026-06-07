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

internal class iSRKQFaLFTVLochDDvWWDqtmRpMt : PlatformInputManager
{
	private class ECaDvruUFTBXkTlxKwsaSudFiWbO : IInputManagerJoystick, IInputManagerJoystickPublic, IDisposable
	{
		private int EOgdMZOUlYxHIejPqKBaXNaUdtsS;

		private int AAuAXyUrBMBrwCwjlfuPtuJCSbCL;

		public Guid OBXOhoDpXnAtKEFDNeKUNFbQHTaCb;

		public string NLsfkBUzQCHFVYGaTCnRjsyQyMkHA;

		public TOhoLhSgVsNthvwMxYIJmahKNXwF WRpBNgGiZlOQMsmVeqldtlHwaxZFA;

		public string CJUPVEFuFSSjGtOWUDXnbPaENBXC;

		public string dfguTVSdkWjSmsiTngxTepwarXRP;

		public Guid WVXimkEwVUiVhEqkVdXWrokaeJSGA;

		public PidVid vtdtoCHknqEwUdjbEDIjWTZmIvinA;

		public Guid RiwnExmKeaerQbDkQPQoOeMMClrtA;

		public int JzxerLWoJNOvadSxpmxtZyUaOTIM;

		public int XQfXggIuayLKmbMjCAILYWUAdVRdA;

		public int xGUMlYQAmvwIfhmnUGeUWtMKWQNi;

		public int ISVduekCfNHbesZPWnOIoZmqtnne;

		public int kRtsomWbxeVcLZTRaehEXXLcboHL;

		public int THpRQPyqPOPkETwwrZmNlciiLygg;

		public bool FlxdDNCOWnIlUoIcDmjlCJbZTgjD;

		public int EXmwTlNGniRRLRLcWxWxIhTYoveT;

		private float[] JPWCiDgJVZPInaWOIlRZQXXKoKlbA;

		private float[] FrwBtKsbXrERfqjpOLHwkQMUFetp;

		private bool[] qHZNfLLXlVFtRxVYyfrUyrswumsJ;

		private HardwareJoystickMap_InputManager mCxMxmfQPuAqZssGWWpuyIYcdogU;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> BCpoIjEOBOpdPZCsrSukHvrkJaMd;

		private bool NMZCizekLRMJxZxQteopsHDjmFlZA;

		private bool pDeaReGrAjgHxFyidppeTvUuFPQUb;

		[CompilerGenerated]
		private Controller.Extension HDWAijdqctiUJUhSuPEfzuCiQhgSA;

		private bool PFgENkrxjwEyNvWBxfXNhKyVHBGZ;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return EOgdMZOUlYxHIejPqKBaXNaUdtsS;
			}
			set
			{
				EOgdMZOUlYxHIejPqKBaXNaUdtsS = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return AAuAXyUrBMBrwCwjlfuPtuJCSbCL;
			}
			set
			{
				AAuAXyUrBMBrwCwjlfuPtuJCSbCL = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (!(NLsfkBUzQCHFVYGaTCnRjsyQyMkHA != "Unknown Controller"))
				{
					return dfguTVSdkWjSmsiTngxTepwarXRP;
				}
				return NLsfkBUzQCHFVYGaTCnRjsyQyMkHA;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (AAuAXyUrBMBrwCwjlfuPtuJCSbCL < 0)
				{
					return null;
				}
				return AAuAXyUrBMBrwCwjlfuPtuJCSbCL;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => WVXimkEwVUiVhEqkVdXWrokaeJSGA;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid
		{
			get
			{
				if (WRpBNgGiZlOQMsmVeqldtlHwaxZFA == null)
				{
					return Guid.Empty;
				}
				return WRpBNgGiZlOQMsmVeqldtlHwaxZFA.vDxCsYxJKQMeAyKaGhPNjLVlhTfeb;
			}
		}

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			[CompilerGenerated]
			get
			{
				return HDWAijdqctiUJUhSuPEfzuCiQhgSA;
			}
			[CompilerGenerated]
			set
			{
				HDWAijdqctiUJUhSuPEfzuCiQhgSA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			if (FlxdDNCOWnIlUoIcDmjlCJbZTgjD)
			{
				WRpBNgGiZlOQMsmVeqldtlHwaxZFA.hVlvLVvYIyaNsRvEyXwZXWjYHdXK(motorIndex, amount, false);
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
			if (FlxdDNCOWnIlUoIcDmjlCJbZTgjD)
			{
				WRpBNgGiZlOQMsmVeqldtlHwaxZFA.rVpiQDTyXRhRFrLSfhvWPEqelhZh();
			}
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public ECaDvruUFTBXkTlxKwsaSudFiWbO(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_0)
		{
			BCpoIjEOBOpdPZCsrSukHvrkJaMd = P_0;
			AAuAXyUrBMBrwCwjlfuPtuJCSbCL = -1;
			EOgdMZOUlYxHIejPqKBaXNaUdtsS = -1;
		}

		public void jEBDBphuIlJFVGxcqykEfekDNwWm()
		{
			RiwnExmKeaerQbDkQPQoOeMMClrtA = MiscTools.CreateGuidHashSHA1(dfguTVSdkWjSmsiTngxTepwarXRP + vtdtoCHknqEwUdjbEDIjWTZmIvinA.ToProductGuid().ToString());
			XQfXggIuayLKmbMjCAILYWUAdVRdA = ISVduekCfNHbesZPWnOIoZmqtnne;
			xGUMlYQAmvwIfhmnUGeUWtMKWQNi = kRtsomWbxeVcLZTRaehEXXLcboHL + THpRQPyqPOPkETwwrZmNlciiLygg * 8;
			GCbyAtSFQpTlRzhcczpbiVsmuWzc();
			OBXOhoDpXnAtKEFDNeKUNFbQHTaCb = mCxMxmfQPuAqZssGWWpuyIYcdogU.hardwareMapIdentifier.guid;
			NLsfkBUzQCHFVYGaTCnRjsyQyMkHA = mCxMxmfQPuAqZssGWWpuyIYcdogU.controllerName;
			NMZCizekLRMJxZxQteopsHDjmFlZA = ((OBXOhoDpXnAtKEFDNeKUNFbQHTaCb == Guid.Empty) ? true : false);
			JPWCiDgJVZPInaWOIlRZQXXKoKlbA = new float[XQfXggIuayLKmbMjCAILYWUAdVRdA];
			FrwBtKsbXrERfqjpOLHwkQMUFetp = new float[xGUMlYQAmvwIfhmnUGeUWtMKWQNi];
			qHZNfLLXlVFtRxVYyfrUyrswumsJ = new bool[xGUMlYQAmvwIfhmnUGeUWtMKWQNi];
			if (xGUMlYQAmvwIfhmnUGeUWtMKWQNi > 0)
			{
				HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)mCxMxmfQPuAqZssGWWpuyIYcdogU.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						qHZNfLLXlVFtRxVYyfrUyrswumsJ[i] = buttons_orig[i].buttonInfo.isPressureSensitive;
					}
				}
			}
			Update();
		}

		public void gTKiIBLuCZrcuOJDvfDbvVffBlJjA(ECaDvruUFTBXkTlxKwsaSudFiWbO P_0)
		{
			if (P_0 != null)
			{
				AAuAXyUrBMBrwCwjlfuPtuJCSbCL = P_0.AAuAXyUrBMBrwCwjlfuPtuJCSbCL;
				EOgdMZOUlYxHIejPqKBaXNaUdtsS = P_0.EOgdMZOUlYxHIejPqKBaXNaUdtsS;
				for (int i = 0; i < MathTools.Min(FrwBtKsbXrERfqjpOLHwkQMUFetp.Length, P_0.FrwBtKsbXrERfqjpOLHwkQMUFetp.Length); i++)
				{
					FrwBtKsbXrERfqjpOLHwkQMUFetp[i] = P_0.FrwBtKsbXrERfqjpOLHwkQMUFetp[i];
				}
				for (int j = 0; j < MathTools.Min(qHZNfLLXlVFtRxVYyfrUyrswumsJ.Length, P_0.qHZNfLLXlVFtRxVYyfrUyrswumsJ.Length); j++)
				{
					qHZNfLLXlVFtRxVYyfrUyrswumsJ[j] = P_0.qHZNfLLXlVFtRxVYyfrUyrswumsJ[j];
				}
				for (int k = 0; k < MathTools.Min(JPWCiDgJVZPInaWOIlRZQXXKoKlbA.Length, P_0.JPWCiDgJVZPInaWOIlRZQXXKoKlbA.Length); k++)
				{
					JPWCiDgJVZPInaWOIlRZQXXKoKlbA[k] = P_0.JPWCiDgJVZPInaWOIlRZQXXKoKlbA[k];
				}
				pDeaReGrAjgHxFyidppeTvUuFPQUb = P_0.pDeaReGrAjgHxFyidppeTvUuFPQUb;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			whQAcVRsqaZIMkqFOaEjfPgjgyKQ();
			ouEpffczrJwHPRaLQboIHpvoGTuxA();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (XQfXggIuayLKmbMjCAILYWUAdVRdA != dataUpdater.axisCount || xGUMlYQAmvwIfhmnUGeUWtMKWQNi != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < XQfXggIuayLKmbMjCAILYWUAdVRdA; i++)
			{
				dataUpdater.axisValues[i] = JPWCiDgJVZPInaWOIlRZQXXKoKlbA[i];
			}
			for (int j = 0; j < xGUMlYQAmvwIfhmnUGeUWtMKWQNi; j++)
			{
				if (qHZNfLLXlVFtRxVYyfrUyrswumsJ[j])
				{
					dataUpdater.buttonPressureValues[j] = FrwBtKsbXrERfqjpOLHwkQMUFetp[j];
				}
				else
				{
					dataUpdater.buttonValues[j] = FrwBtKsbXrERfqjpOLHwkQMUFetp[j] > 0f;
				}
			}
			if (pDeaReGrAjgHxFyidppeTvUuFPQUb && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int cmboXrifvJMSIqvlMIDSMPcubKNb(ECaDvruUFTBXkTlxKwsaSudFiWbO P_0)
		{
			if (P_0.EOgdMZOUlYxHIejPqKBaXNaUdtsS == EOgdMZOUlYxHIejPqKBaXNaUdtsS)
			{
				return 2;
			}
			if (ISVduekCfNHbesZPWnOIoZmqtnne != P_0.ISVduekCfNHbesZPWnOIoZmqtnne)
			{
				return 0;
			}
			if (kRtsomWbxeVcLZTRaehEXXLcboHL != P_0.kRtsomWbxeVcLZTRaehEXXLcboHL)
			{
				return 0;
			}
			if (THpRQPyqPOPkETwwrZmNlciiLygg != P_0.THpRQPyqPOPkETwwrZmNlciiLygg)
			{
				return 0;
			}
			if (P_0.WVXimkEwVUiVhEqkVdXWrokaeJSGA == WVXimkEwVUiVhEqkVdXWrokaeJSGA)
			{
				return 2;
			}
			if (P_0.RiwnExmKeaerQbDkQPQoOeMMClrtA == RiwnExmKeaerQbDkQPQoOeMMClrtA)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo hJYTBvsLDHeEFjsxWzqIwYXAukqs()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			vSWYnEhmpflmwHBBhcOselXkBtyv(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			AncllKYrhrpZWIiBkfONEDALRLsq(bridgedController);
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
			return new ControllerDisconnectedEventArgs(EOgdMZOUlYxHIejPqKBaXNaUdtsS);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void whQAcVRsqaZIMkqFOaEjfPgjgyKQ()
		{
			if (XQfXggIuayLKmbMjCAILYWUAdVRdA <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_WindowsWGI_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)mCxMxmfQPuAqZssGWWpuyIYcdogU.map).Axes_orig;
			if (axes_orig != null)
			{
				for (int i = 0; i < axes_orig.Length; i++)
				{
					iGLyPtYhbGQbwdVeYnqIYLtuIHxr(axes_orig[i], i);
				}
			}
		}

		private void ouEpffczrJwHPRaLQboIHpvoGTuxA()
		{
			if (xGUMlYQAmvwIfhmnUGeUWtMKWQNi <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)mCxMxmfQPuAqZssGWWpuyIYcdogU.map).Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					lGgaqlvNFeKrEatpGSrXHzuYkKTy(buttons_orig[i], i);
				}
			}
		}

		private void iGLyPtYhbGQbwdVeYnqIYLtuIHxr(HardwareJoystickMap.Platform_WindowsWGI_Base.Axis P_0, int P_1)
		{
			if (P_1 >= XQfXggIuayLKmbMjCAILYWUAdVRdA)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			JPWCiDgJVZPInaWOIlRZQXXKoKlbA[P_1] = jAnciepTdtuthXJRnvKoZuVUUMJf(P_0);
			if (!pDeaReGrAjgHxFyidppeTvUuFPQUb && JPWCiDgJVZPInaWOIlRZQXXKoKlbA[P_1] != 0f)
			{
				pDeaReGrAjgHxFyidppeTvUuFPQUb = true;
			}
		}

		private void lGgaqlvNFeKrEatpGSrXHzuYkKTy(HardwareJoystickMap.Platform_WindowsWGI_Base.Button P_0, int P_1)
		{
			if (P_1 >= xGUMlYQAmvwIfhmnUGeUWtMKWQNi)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			FrwBtKsbXrERfqjpOLHwkQMUFetp[P_1] = zmdakGlHpBOkSKGUnbZOFfwrEsbAA(P_0);
			if (!pDeaReGrAjgHxFyidppeTvUuFPQUb && FrwBtKsbXrERfqjpOLHwkQMUFetp[P_1] != 0f)
			{
				pDeaReGrAjgHxFyidppeTvUuFPQUb = true;
			}
		}

		private float jAnciepTdtuthXJRnvKoZuVUUMJf(HardwareJoystickMap.Platform_WindowsWGI_Base.Axis P_0)
		{
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0)
				{
					return 0f;
				}
				return UAxrpBIIUiHVKTCLeXLUKhwZMqFU(sourceAxis);
			}
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= kRtsomWbxeVcLZTRaehEXXLcboHL || sourceButton >= 256)
				{
					return 0f;
				}
				if (!WRpBNgGiZlOQMsmVeqldtlHwaxZFA.vvlFnpJRQRrjlgvOibkUbGiUBYVcb(sourceButton))
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
				if (sourceHat < 0 || sourceHat >= THpRQPyqPOPkETwwrZmNlciiLygg || sourceHat >= 4)
				{
					return 0f;
				}
				int num = WRpBNgGiZlOQMsmVeqldtlHwaxZFA.aQUkTmwKkLBfvYQKYfkUBZltwDKy(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = rzoLUebMAIcXnUJtBQIUlSyQYJTj(num, AxisDirection.Horizontal);
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
					num2 = rzoLUebMAIcXnUJtBQIUlSyQYJTj(num, AxisDirection.Vertical);
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

		private float UAxrpBIIUiHVKTCLeXLUKhwZMqFU(int P_0)
		{
			if (P_0 < 0 || P_0 >= WRpBNgGiZlOQMsmVeqldtlHwaxZFA.qRVOpNxeaanxUoDqJkbLEwWdRSlH)
			{
				return 0f;
			}
			return WRpBNgGiZlOQMsmVeqldtlHwaxZFA.XOYdgBHYoFssaNLaNRXlNDCdRTGiA(P_0);
		}

		private float zmdakGlHpBOkSKGUnbZOFfwrEsbAA(HardwareJoystickMap.Platform_WindowsWGI_Base.Button P_0)
		{
			if (P_0.sourceType == 0)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (WRpBNgGiZlOQMsmVeqldtlHwaxZFA.vvlFnpJRQRrjlgvOibkUbGiUBYVcb(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!WRpBNgGiZlOQMsmVeqldtlHwaxZFA.vvlFnpJRQRrjlgvOibkUbGiUBYVcb(P_0.requiredButtons[j]))
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
				if (sourceButton < 0 || sourceButton >= kRtsomWbxeVcLZTRaehEXXLcboHL || sourceButton >= 256)
				{
					return 0f;
				}
				if (!WRpBNgGiZlOQMsmVeqldtlHwaxZFA.vvlFnpJRQRrjlgvOibkUbGiUBYVcb(sourceButton))
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
				float num = UAxrpBIIUiHVKTCLeXLUKhwZMqFU(sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= THpRQPyqPOPkETwwrZmNlciiLygg || sourceHat >= 4)
				{
					return 0f;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return BfcmMhZAFqiNsbHVYOFJKXEOvCNUA(WRpBNgGiZlOQMsmVeqldtlHwaxZFA.aQUkTmwKkLBfvYQKYfkUBZltwDKy(sourceHat), 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return BfcmMhZAFqiNsbHVYOFJKXEOvCNUA(WRpBNgGiZlOQMsmVeqldtlHwaxZFA.aQUkTmwKkLBfvYQKYfkUBZltwDKy(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return BfcmMhZAFqiNsbHVYOFJKXEOvCNUA(WRpBNgGiZlOQMsmVeqldtlHwaxZFA.aQUkTmwKkLBfvYQKYfkUBZltwDKy(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return BfcmMhZAFqiNsbHVYOFJKXEOvCNUA(WRpBNgGiZlOQMsmVeqldtlHwaxZFA.aQUkTmwKkLBfvYQKYfkUBZltwDKy(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return BfcmMhZAFqiNsbHVYOFJKXEOvCNUA(WRpBNgGiZlOQMsmVeqldtlHwaxZFA.aQUkTmwKkLBfvYQKYfkUBZltwDKy(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return BfcmMhZAFqiNsbHVYOFJKXEOvCNUA(WRpBNgGiZlOQMsmVeqldtlHwaxZFA.aQUkTmwKkLBfvYQKYfkUBZltwDKy(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return BfcmMhZAFqiNsbHVYOFJKXEOvCNUA(WRpBNgGiZlOQMsmVeqldtlHwaxZFA.aQUkTmwKkLBfvYQKYfkUBZltwDKy(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return BfcmMhZAFqiNsbHVYOFJKXEOvCNUA(WRpBNgGiZlOQMsmVeqldtlHwaxZFA.aQUkTmwKkLBfvYQKYfkUBZltwDKy(sourceHat), 7, P_0.sourceHatType);
				}
			}
			return 0f;
		}

		private float BfcmMhZAFqiNsbHVYOFJKXEOvCNUA(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (mCxMxmfQPuAqZssGWWpuyIYcdogU.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float rzoLUebMAIcXnUJtBQIUlSyQYJTj(int P_0, AxisDirection P_1)
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

		private void GCbyAtSFQpTlRzhcczpbiVsmuWzc()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = hJYTBvsLDHeEFjsxWzqIwYXAukqs();
			mCxMxmfQPuAqZssGWWpuyIYcdogU = BCpoIjEOBOpdPZCsrSukHvrkJaMd(bridgedControllerHWInfo);
			bool flag = false;
			bool flag2 = false;
			if (mCxMxmfQPuAqZssGWWpuyIYcdogU == null || mCxMxmfQPuAqZssGWWpuyIYcdogU.hardwareMapIdentifier.guid == Consts.joystickGuid_unknownController)
			{
				if (WRpBNgGiZlOQMsmVeqldtlHwaxZFA.bRNzcVgiOxZxsTNWdqoubPDcfuwC)
				{
					bridgedControllerHWInfo.hw_pidVid = new PidVid(4607, 10462);
					bridgedControllerHWInfo.hw_productId = bridgedControllerHWInfo.hw_pidVid.productId;
					bridgedControllerHWInfo.hw_vendorId = bridgedControllerHWInfo.hw_pidVid.vendorId;
					mCxMxmfQPuAqZssGWWpuyIYcdogU = BCpoIjEOBOpdPZCsrSukHvrkJaMd(bridgedControllerHWInfo);
					flag2 = true;
				}
				if (mCxMxmfQPuAqZssGWWpuyIYcdogU == null || mCxMxmfQPuAqZssGWWpuyIYcdogU.hardwareMapIdentifier.guid == Consts.joystickGuid_unknownController)
				{
					bridgedControllerHWInfo.hw_pidVid = new PidVid(736, 1118);
					bridgedControllerHWInfo.hw_productId = bridgedControllerHWInfo.hw_pidVid.productId;
					bridgedControllerHWInfo.hw_vendorId = bridgedControllerHWInfo.hw_pidVid.vendorId;
					bridgedControllerHWInfo.definitionMatchTag = string.Empty;
					mCxMxmfQPuAqZssGWWpuyIYcdogU = BCpoIjEOBOpdPZCsrSukHvrkJaMd(bridgedControllerHWInfo);
					flag = true;
				}
			}
			if (mCxMxmfQPuAqZssGWWpuyIYcdogU == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (flag)
			{
				string text = string.Format("{0}:{1}", WRpBNgGiZlOQMsmVeqldtlHwaxZFA.UpqYCFgQVcecVDHViDhXrufjGfOU.vendorId.ToString("x4"), WRpBNgGiZlOQMsmVeqldtlHwaxZFA.UpqYCFgQVcecVDHViDhXrufjGfOU.productId.ToString("x4"));
				string key = LocalizationManager.AppendToKeyAsPath("windows_gaming_input_gamepad", text);
				mCxMxmfQPuAqZssGWWpuyIYcdogU.deviceLocalizationInfo.InsertParentKey(0, key);
				mCxMxmfQPuAqZssGWWpuyIYcdogU.deviceLocalizationInfo.InsertParentKey(1, "windows_gaming_input_gamepad");
				mCxMxmfQPuAqZssGWWpuyIYcdogU.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text}]";
			}
			else if (WRpBNgGiZlOQMsmVeqldtlHwaxZFA.bRNzcVgiOxZxsTNWdqoubPDcfuwC && (flag2 || mCxMxmfQPuAqZssGWWpuyIYcdogU.hardwareMapIdentifier.guid == Consts.joystickGuid_steamController))
			{
				string text2 = string.Format("{0}:{1}", WRpBNgGiZlOQMsmVeqldtlHwaxZFA.UpqYCFgQVcecVDHViDhXrufjGfOU.vendorId.ToString("x4"), WRpBNgGiZlOQMsmVeqldtlHwaxZFA.UpqYCFgQVcecVDHViDhXrufjGfOU.productId.ToString("x4"));
				string key2 = LocalizationManager.AppendToKeyAsPath((mCxMxmfQPuAqZssGWWpuyIYcdogU.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(mCxMxmfQPuAqZssGWWpuyIYcdogU.deviceLocalizationInfo.parentKeys[0])) ? mCxMxmfQPuAqZssGWWpuyIYcdogU.deviceLocalizationInfo.parentKeys[0] : "steam_controller", text2);
				mCxMxmfQPuAqZssGWWpuyIYcdogU.deviceLocalizationInfo.InsertParentKey(0, key2);
				mCxMxmfQPuAqZssGWWpuyIYcdogU.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text2}]";
			}
			XQfXggIuayLKmbMjCAILYWUAdVRdA = mCxMxmfQPuAqZssGWWpuyIYcdogU.axisCount;
			xGUMlYQAmvwIfhmnUGeUWtMKWQNi = mCxMxmfQPuAqZssGWWpuyIYcdogU.buttonCount;
		}

		private string OpZRVtTSVMcBkTJCpWnOgmHGorhI()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.WindowsGamingInput}{WRpBNgGiZlOQMsmVeqldtlHwaxZFA.cStqYEtEvcZLoVslppdbJHPhzBDv}{dfguTVSdkWjSmsiTngxTepwarXRP}{vtdtoCHknqEwUdjbEDIjWTZmIvinA.ToString()}");
		}

		private void vSWYnEhmpflmwHBBhcOselXkBtyv(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.WindowsGamingInput;
			P_0.inputSource = WRpBNgGiZlOQMsmVeqldtlHwaxZFA.IxiQGSYAQgEHSMyyYBPeDHTzRouW;
			P_0.deviceType = (ControlDeviceType)WRpBNgGiZlOQMsmVeqldtlHwaxZFA.cStqYEtEvcZLoVslppdbJHPhzBDv;
			P_0.hardwareIdentifier = OpZRVtTSVMcBkTJCpWnOgmHGorhI();
			P_0.hardwareAxisCount = ISVduekCfNHbesZPWnOIoZmqtnne;
			P_0.hardwareButtonCount = kRtsomWbxeVcLZTRaehEXXLcboHL;
			P_0.hardwareHatCount = THpRQPyqPOPkETwwrZmNlciiLygg;
			if (WRpBNgGiZlOQMsmVeqldtlHwaxZFA.bRNzcVgiOxZxsTNWdqoubPDcfuwC)
			{
				P_0.definitionMatchTag = "[STEAMCONFIGURED]";
			}
			P_0.hw_productName = dfguTVSdkWjSmsiTngxTepwarXRP;
			P_0.hw_deviceGuid = WVXimkEwVUiVhEqkVdXWrokaeJSGA;
			P_0.hw_productId = vtdtoCHknqEwUdjbEDIjWTZmIvinA.productId;
			P_0.hw_vendorId = vtdtoCHknqEwUdjbEDIjWTZmIvinA.vendorId;
			P_0.hw_pidVid = vtdtoCHknqEwUdjbEDIjWTZmIvinA;
			P_0.hw_isBluetoothDevice = false;
			P_0.hw_bluetoothDeviceName = dfguTVSdkWjSmsiTngxTepwarXRP;
			P_0.hw_supportsVibration = FlxdDNCOWnIlUoIcDmjlCJbZTgjD;
			P_0.hw_localVibrationMotorCount = EXmwTlNGniRRLRLcWxWxIhTYoveT;
		}

		private void AncllKYrhrpZWIiBkfONEDALRLsq(BridgedController P_0)
		{
			vSWYnEhmpflmwHBBhcOselXkBtyv(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = mCxMxmfQPuAqZssGWWpuyIYcdogU.ToGameHardwareControllerMap();
			P_0.instanceName = CJUPVEFuFSSjGtOWUDXnbPaENBXC;
			P_0.productName = dfguTVSdkWjSmsiTngxTepwarXRP;
			P_0.axisCount = XQfXggIuayLKmbMjCAILYWUAdVRdA;
			P_0.buttonCount = xGUMlYQAmvwIfhmnUGeUWtMKWQNi;
			P_0.isButtonPressureSensitive = new bool[xGUMlYQAmvwIfhmnUGeUWtMKWQNi];
			Array.Copy(qHZNfLLXlVFtRxVYyfrUyrswumsJ, P_0.isButtonPressureSensitive, xGUMlYQAmvwIfhmnUGeUWtMKWQNi);
			P_0.unknownControllerHats = tatIJQAgdLcCNOjiVMtGQtXpvwrEA();
			P_0.controllerTypeGuid = OBXOhoDpXnAtKEFDNeKUNFbQHTaCb;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void SVATWMudeFWIaIBmRYCtxnZmznXM()
		{
			for (int i = 0; i < xGUMlYQAmvwIfhmnUGeUWtMKWQNi; i++)
			{
				FrwBtKsbXrERfqjpOLHwkQMUFetp[i] = 0f;
			}
			for (int j = 0; j < XQfXggIuayLKmbMjCAILYWUAdVRdA; j++)
			{
				JPWCiDgJVZPInaWOIlRZQXXKoKlbA[j] = 0f;
			}
		}

		private UnknownControllerHat[] tatIJQAgdLcCNOjiVMtGQtXpvwrEA()
		{
			if (!NMZCizekLRMJxZxQteopsHDjmFlZA)
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
			UBMCOgTFpBvnxRfICFhzfpZDzkvQA(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void NjQBFLYYKxhsLShbVPBMPyxHwFTb()
		{
			try
			{
				UBMCOgTFpBvnxRfICFhzfpZDzkvQA(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void UBMCOgTFpBvnxRfICFhzfpZDzkvQA(bool P_0)
		{
			if (!PFgENkrxjwEyNvWBxfXNhKyVHBGZ)
			{
				if (P_0 && WRpBNgGiZlOQMsmVeqldtlHwaxZFA != null)
				{
					WRpBNgGiZlOQMsmVeqldtlHwaxZFA.Dispose();
				}
				PFgENkrxjwEyNvWBxfXNhKyVHBGZ = true;
			}
		}

		public static int kfBHwVDlxIeBnetVcUhVyWUbWrXFA(ECaDvruUFTBXkTlxKwsaSudFiWbO P_0, ECaDvruUFTBXkTlxKwsaSudFiWbO P_1)
		{
			if (P_0.AAuAXyUrBMBrwCwjlfuPtuJCSbCL < P_1.AAuAXyUrBMBrwCwjlfuPtuJCSbCL)
			{
				return -1;
			}
			if (P_0.AAuAXyUrBMBrwCwjlfuPtuJCSbCL > P_1.AAuAXyUrBMBrwCwjlfuPtuJCSbCL)
			{
				return 1;
			}
			return 0;
		}

		public static int NOSJsAEQKgNdGJSfdGkkvRbimlJo(ECaDvruUFTBXkTlxKwsaSudFiWbO P_0, ECaDvruUFTBXkTlxKwsaSudFiWbO P_1)
		{
			if (P_0.JzxerLWoJNOvadSxpmxtZyUaOTIM < P_1.JzxerLWoJNOvadSxpmxtZyUaOTIM)
			{
				return -1;
			}
			if (P_0.JzxerLWoJNOvadSxpmxtZyUaOTIM > P_1.JzxerLWoJNOvadSxpmxtZyUaOTIM)
			{
				return 1;
			}
			return 0;
		}
	}

	private class oOSPUcwhJYFmQIIozhxnOapaYKeU
	{
		public enum UJNiCnqAvUnNthdfxYOOlUfwJVi
		{
			Exact = 0,
			Approximate = 1
		}

		public class qIrKulptklEhiMfGIEFjCCXmONOxA
		{
			public int rCGjHOXigZuRMZZVCqwUUsaWVeOr;

			public Guid crJyJgZTIeJrvGLFRCrxDpBUwHYF;

			public Guid AbXCwfaSdPBRlddpWWJEDWEaksIj;

			public int rnuEeEbpnQMGRrLFuCeNleTOGdrhb;

			public int EsBlhNyMhxIRDeteAxaWgCvbgbsLA;

			public int kXTDWjMbYYRKYcXBsvbKhVlqWYiE;

			public int PCqrMPdDzHFlZENHmnYKhLGHbttQ;

			public int egyEvYNNYyDOoJBTlZfcAuevzvuI;

			public int wWieeApwYRTlixSpwKygbELNyCMH;

			public bool IOAmqtjKpAAWPyrcRwvaaDuYpDNo(ECaDvruUFTBXkTlxKwsaSudFiWbO P_0, UJNiCnqAvUnNthdfxYOOlUfwJVi P_1)
			{
				if (EsBlhNyMhxIRDeteAxaWgCvbgbsLA != P_0.ISVduekCfNHbesZPWnOIoZmqtnne)
				{
					return false;
				}
				if (kXTDWjMbYYRKYcXBsvbKhVlqWYiE != P_0.kRtsomWbxeVcLZTRaehEXXLcboHL)
				{
					return false;
				}
				if (PCqrMPdDzHFlZENHmnYKhLGHbttQ != P_0.THpRQPyqPOPkETwwrZmNlciiLygg)
				{
					return false;
				}
				if (egyEvYNNYyDOoJBTlZfcAuevzvuI != P_0.xGUMlYQAmvwIfhmnUGeUWtMKWQNi)
				{
					return false;
				}
				if (wWieeApwYRTlixSpwKygbELNyCMH != P_0.XQfXggIuayLKmbMjCAILYWUAdVRdA)
				{
					return false;
				}
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == rCGjHOXigZuRMZZVCqwUUsaWVeOr)
				{
					return true;
				}
				return P_1 switch
				{
					UJNiCnqAvUnNthdfxYOOlUfwJVi.Exact => crJyJgZTIeJrvGLFRCrxDpBUwHYF == P_0.WVXimkEwVUiVhEqkVdXWrokaeJSGA, 
					UJNiCnqAvUnNthdfxYOOlUfwJVi.Approximate => AbXCwfaSdPBRlddpWWJEDWEaksIj == P_0.RiwnExmKeaerQbDkQPQoOeMMClrtA, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		private sealed class WdIEVdQAhPJHqqfuiFrkQDZzMISH : IEnumerable<qIrKulptklEhiMfGIEFjCCXmONOxA>, IEnumerable, IEnumerator<qIrKulptklEhiMfGIEFjCCXmONOxA>, IEnumerator, IDisposable
		{
			private int btOikXpQBkbWKEaFOPmnskEvpYaj;

			private qIrKulptklEhiMfGIEFjCCXmONOxA AmzKhZLBEWDNnVHtEcusWRFbXhRH;

			private int JhAcDrydRXIeEJBgddnDXeuPLfLQ;

			public oOSPUcwhJYFmQIIozhxnOapaYKeU aFUOgkhVVubOLcyJpMQvkrTMzLRk;

			private ECaDvruUFTBXkTlxKwsaSudFiWbO kODmVvzfyGeYbdguxqGcbUfpSTQBb;

			public ECaDvruUFTBXkTlxKwsaSudFiWbO ZnzkZnCZZgDXbamfyewPKiRxDDgX;

			private UJNiCnqAvUnNthdfxYOOlUfwJVi RfgtfibzLZBzhdpNMwYRUpfLCXYF;

			public UJNiCnqAvUnNthdfxYOOlUfwJVi aWdNcfhXdFsGSvlUTcTkYUbvNsnu;

			private int yVVFuQSQxaFdjTAUESSMIJlfarJL;

			private int ayACsRIjXWnwRFtTfLwxnmowyZZgB;

			qIrKulptklEhiMfGIEFjCCXmONOxA IEnumerator<qIrKulptklEhiMfGIEFjCCXmONOxA>.Current
			{
				[DebuggerHidden]
				get
				{
					return AmzKhZLBEWDNnVHtEcusWRFbXhRH;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return AmzKhZLBEWDNnVHtEcusWRFbXhRH;
				}
			}

			[DebuggerHidden]
			public WdIEVdQAhPJHqqfuiFrkQDZzMISH(int P_0)
			{
				btOikXpQBkbWKEaFOPmnskEvpYaj = P_0;
				JhAcDrydRXIeEJBgddnDXeuPLfLQ = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = btOikXpQBkbWKEaFOPmnskEvpYaj;
				oOSPUcwhJYFmQIIozhxnOapaYKeU oOSPUcwhJYFmQIIozhxnOapaYKeU2 = aFUOgkhVVubOLcyJpMQvkrTMzLRk;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					btOikXpQBkbWKEaFOPmnskEvpYaj = -1;
					goto IL_0083;
				}
				btOikXpQBkbWKEaFOPmnskEvpYaj = -1;
				yVVFuQSQxaFdjTAUESSMIJlfarJL = oOSPUcwhJYFmQIIozhxnOapaYKeU2.GsPkthJSRuflxHsmtaCSUFHkENc.Count;
				ayACsRIjXWnwRFtTfLwxnmowyZZgB = 0;
				goto IL_0093;
				IL_0083:
				ayACsRIjXWnwRFtTfLwxnmowyZZgB++;
				goto IL_0093;
				IL_0093:
				if (ayACsRIjXWnwRFtTfLwxnmowyZZgB < yVVFuQSQxaFdjTAUESSMIJlfarJL)
				{
					if (oOSPUcwhJYFmQIIozhxnOapaYKeU2.GsPkthJSRuflxHsmtaCSUFHkENc[ayACsRIjXWnwRFtTfLwxnmowyZZgB].IOAmqtjKpAAWPyrcRwvaaDuYpDNo(kODmVvzfyGeYbdguxqGcbUfpSTQBb, RfgtfibzLZBzhdpNMwYRUpfLCXYF))
					{
						AmzKhZLBEWDNnVHtEcusWRFbXhRH = oOSPUcwhJYFmQIIozhxnOapaYKeU2.GsPkthJSRuflxHsmtaCSUFHkENc[ayACsRIjXWnwRFtTfLwxnmowyZZgB];
						btOikXpQBkbWKEaFOPmnskEvpYaj = 1;
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
			IEnumerator<qIrKulptklEhiMfGIEFjCCXmONOxA> IEnumerable<qIrKulptklEhiMfGIEFjCCXmONOxA>.GetEnumerator()
			{
				WdIEVdQAhPJHqqfuiFrkQDZzMISH wdIEVdQAhPJHqqfuiFrkQDZzMISH;
				if (btOikXpQBkbWKEaFOPmnskEvpYaj == -2 && JhAcDrydRXIeEJBgddnDXeuPLfLQ == Environment.CurrentManagedThreadId)
				{
					btOikXpQBkbWKEaFOPmnskEvpYaj = 0;
					wdIEVdQAhPJHqqfuiFrkQDZzMISH = this;
				}
				else
				{
					wdIEVdQAhPJHqqfuiFrkQDZzMISH = new WdIEVdQAhPJHqqfuiFrkQDZzMISH(0);
					wdIEVdQAhPJHqqfuiFrkQDZzMISH.aFUOgkhVVubOLcyJpMQvkrTMzLRk = aFUOgkhVVubOLcyJpMQvkrTMzLRk;
				}
				wdIEVdQAhPJHqqfuiFrkQDZzMISH.kODmVvzfyGeYbdguxqGcbUfpSTQBb = ZnzkZnCZZgDXbamfyewPKiRxDDgX;
				wdIEVdQAhPJHqqfuiFrkQDZzMISH.RfgtfibzLZBzhdpNMwYRUpfLCXYF = aWdNcfhXdFsGSvlUTcTkYUbvNsnu;
				return wdIEVdQAhPJHqqfuiFrkQDZzMISH;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<qIrKulptklEhiMfGIEFjCCXmONOxA>)this).GetEnumerator();
			}
		}

		private List<qIrKulptklEhiMfGIEFjCCXmONOxA> GsPkthJSRuflxHsmtaCSUFHkENc;

		public oOSPUcwhJYFmQIIozhxnOapaYKeU()
		{
			GsPkthJSRuflxHsmtaCSUFHkENc = new List<qIrKulptklEhiMfGIEFjCCXmONOxA>();
		}

		public void fzwNFMlMUuCTbEKSkJobLXnKPcvO(ECaDvruUFTBXkTlxKwsaSudFiWbO P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = GsPkthJSRuflxHsmtaCSUFHkENc.Count;
			for (int i = 0; i < count; i++)
			{
				if (GsPkthJSRuflxHsmtaCSUFHkENc[i].IOAmqtjKpAAWPyrcRwvaaDuYpDNo(P_0, UJNiCnqAvUnNthdfxYOOlUfwJVi.Exact))
				{
					GsPkthJSRuflxHsmtaCSUFHkENc[i].rCGjHOXigZuRMZZVCqwUUsaWVeOr = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					GsPkthJSRuflxHsmtaCSUFHkENc[i].crJyJgZTIeJrvGLFRCrxDpBUwHYF = P_0.WVXimkEwVUiVhEqkVdXWrokaeJSGA;
					GsPkthJSRuflxHsmtaCSUFHkENc[i].AbXCwfaSdPBRlddpWWJEDWEaksIj = P_0.RiwnExmKeaerQbDkQPQoOeMMClrtA;
					GsPkthJSRuflxHsmtaCSUFHkENc[i].rnuEeEbpnQMGRrLFuCeNleTOGdrhb = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					GsPkthJSRuflxHsmtaCSUFHkENc[i].EsBlhNyMhxIRDeteAxaWgCvbgbsLA = P_0.ISVduekCfNHbesZPWnOIoZmqtnne;
					GsPkthJSRuflxHsmtaCSUFHkENc[i].kXTDWjMbYYRKYcXBsvbKhVlqWYiE = P_0.kRtsomWbxeVcLZTRaehEXXLcboHL;
					GsPkthJSRuflxHsmtaCSUFHkENc[i].PCqrMPdDzHFlZENHmnYKhLGHbttQ = P_0.THpRQPyqPOPkETwwrZmNlciiLygg;
					GsPkthJSRuflxHsmtaCSUFHkENc[i].egyEvYNNYyDOoJBTlZfcAuevzvuI = P_0.xGUMlYQAmvwIfhmnUGeUWtMKWQNi;
					GsPkthJSRuflxHsmtaCSUFHkENc[i].wWieeApwYRTlixSpwKygbELNyCMH = P_0.XQfXggIuayLKmbMjCAILYWUAdVRdA;
					SBUgrQJQhIPaKCIvmgRwJkZqiDHAA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.WVXimkEwVUiVhEqkVdXWrokaeJSGA, i);
					return;
				}
			}
			GsPkthJSRuflxHsmtaCSUFHkENc.Add(new qIrKulptklEhiMfGIEFjCCXmONOxA
			{
				rCGjHOXigZuRMZZVCqwUUsaWVeOr = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				crJyJgZTIeJrvGLFRCrxDpBUwHYF = P_0.WVXimkEwVUiVhEqkVdXWrokaeJSGA,
				AbXCwfaSdPBRlddpWWJEDWEaksIj = P_0.RiwnExmKeaerQbDkQPQoOeMMClrtA,
				rnuEeEbpnQMGRrLFuCeNleTOGdrhb = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				EsBlhNyMhxIRDeteAxaWgCvbgbsLA = P_0.ISVduekCfNHbesZPWnOIoZmqtnne,
				kXTDWjMbYYRKYcXBsvbKhVlqWYiE = P_0.kRtsomWbxeVcLZTRaehEXXLcboHL,
				PCqrMPdDzHFlZENHmnYKhLGHbttQ = P_0.THpRQPyqPOPkETwwrZmNlciiLygg,
				egyEvYNNYyDOoJBTlZfcAuevzvuI = P_0.xGUMlYQAmvwIfhmnUGeUWtMKWQNi,
				wWieeApwYRTlixSpwKygbELNyCMH = P_0.XQfXggIuayLKmbMjCAILYWUAdVRdA
			});
			SBUgrQJQhIPaKCIvmgRwJkZqiDHAA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.WVXimkEwVUiVhEqkVdXWrokaeJSGA, GsPkthJSRuflxHsmtaCSUFHkENc.Count - 1);
		}

		public bool qCakPftPLTgnyPJhxsxJonXKmTbL(ECaDvruUFTBXkTlxKwsaSudFiWbO P_0, UJNiCnqAvUnNthdfxYOOlUfwJVi P_1)
		{
			int count = GsPkthJSRuflxHsmtaCSUFHkENc.Count;
			for (int i = 0; i < count; i++)
			{
				if (GsPkthJSRuflxHsmtaCSUFHkENc[i].IOAmqtjKpAAWPyrcRwvaaDuYpDNo(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(WdIEVdQAhPJHqqfuiFrkQDZzMISH))]
		public IEnumerable<qIrKulptklEhiMfGIEFjCCXmONOxA> yiIELbJCOuhLRWQACJmqINzhFuONc(ECaDvruUFTBXkTlxKwsaSudFiWbO P_0, UJNiCnqAvUnNthdfxYOOlUfwJVi P_1)
		{
			return new WdIEVdQAhPJHqqfuiFrkQDZzMISH(-2)
			{
				aFUOgkhVVubOLcyJpMQvkrTMzLRk = this,
				ZnzkZnCZZgDXbamfyewPKiRxDDgX = P_0,
				aWdNcfhXdFsGSvlUTcTkYUbvNsnu = P_1
			};
		}

		private void SBUgrQJQhIPaKCIvmgRwJkZqiDHAA(int P_0, Guid P_1, int P_2)
		{
			for (int num = GsPkthJSRuflxHsmtaCSUFHkENc.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (GsPkthJSRuflxHsmtaCSUFHkENc[num].rCGjHOXigZuRMZZVCqwUUsaWVeOr == P_0 || GsPkthJSRuflxHsmtaCSUFHkENc[num].crJyJgZTIeJrvGLFRCrxDpBUwHYF == P_1))
				{
					GsPkthJSRuflxHsmtaCSUFHkENc.RemoveAt(num);
				}
			}
		}
	}

	private const bool CUNvdIvnVQQLzFpZnYtwmJiOmUqh = true;

	private fDxnmumzURENoVdHRorEBLyiFxdA gEYumqKvygSInlmtohVfjyeNbPCt;

	private List<ECaDvruUFTBXkTlxKwsaSudFiWbO> fPrnCIiQJspsKVdXlEaERemSPIRF;

	private int hGgxiZtdfcQQAuontLEeSRehgpnAA;

	private oOSPUcwhJYFmQIIozhxnOapaYKeU biHrWGftLqIeyLRQvTFaoUYfsmmy;

	private bool qLjksAKkTRAbBeRQFuejKJlaGxFDA;

	private ConfigVars XGsltZNnPvhrWhdIqUNKeSIUGUbbA;

	private Action<int, ControllerDataUpdater> QpqLiFRFLpQDsOYoHOEdEWuDREcb;

	private PlatformInputManager aqGYKwjBUzGjiYqnbivlBudxjdLf;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> EzzIqIsCYMLvovALAGbWjqnNoxynA;

	private readonly Func<int> hwmUgNXrWxLoHGESMOVBsnnStKqb;

	private Func<PidVid, bool> hMWLTNIRwRJMYvNwqFfUTzihuhUs;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => hGgxiZtdfcQQAuontLEeSRehgpnAA;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => aqGYKwjBUzGjiYqnbivlBudxjdLf;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => gEYumqKvygSInlmtohVfjyeNbPCt;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.WindowsGamingInput;

	protected fDxnmumzURENoVdHRorEBLyiFxdA lBwIaAgaiflhsOfdNgmPapLhaVUX => gEYumqKvygSInlmtohVfjyeNbPCt;

	public iSRKQFaLFTVLochDDvWWDqtmRpMt(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2, Func<PidVid, bool> P_3)
	{
		try
		{
			XGsltZNnPvhrWhdIqUNKeSIUGUbbA = P_0;
			EzzIqIsCYMLvovALAGbWjqnNoxynA = P_1;
			hwmUgNXrWxLoHGESMOVBsnnStKqb = P_2;
			hMWLTNIRwRJMYvNwqFfUTzihuhUs = P_3;
			aqGYKwjBUzGjiYqnbivlBudxjdLf = this;
			gEYumqKvygSInlmtohVfjyeNbPCt = new fDxnmumzURENoVdHRorEBLyiFxdA(P_0, true, false, false);
			gEYumqKvygSInlmtohVfjyeNbPCt.Rewired_002EInterfaces_002EIInputSource_002EDeviceChangedEvent += SystemDeviceConnected;
			QpqLiFRFLpQDsOYoHOEdEWuDREcb = UpdateControllerData;
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
		biHrWGftLqIeyLRQvTFaoUYfsmmy = new oOSPUcwhJYFmQIIozhxnOapaYKeU();
		gEYumqKvygSInlmtohVfjyeNbPCt.moFjvZxDBaDvaEoItRZQDmrpJLdSA();
		zxLgIqSHxaVlMWJfYfxobriDLBSIb();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (gEYumqKvygSInlmtohVfjyeNbPCt != null)
		{
			gEYumqKvygSInlmtohVfjyeNbPCt.Update();
		}
		if (qLjksAKkTRAbBeRQFuejKJlaGxFDA)
		{
			wtSTPLmDShibruqkuLJrYgmqhevN();
		}
		if (gEYumqKvygSInlmtohVfjyeNbPCt != null)
		{
			gEYumqKvygSInlmtohVfjyeNbPCt.UpdateDevices(updateLoop);
		}
		pCbxtUchFZQlTVkyoDdXTeruNnix();
		if (gEYumqKvygSInlmtohVfjyeNbPCt != null)
		{
			gEYumqKvygSInlmtohVfjyeNbPCt.UpdateFinished();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (fPrnCIiQJspsKVdXlEaERemSPIRF != null)
		{
			int count = fPrnCIiQJspsKVdXlEaERemSPIRF.Count;
			for (int i = 0; i < count; i++)
			{
				if (fPrnCIiQJspsKVdXlEaERemSPIRF[i] != null)
				{
					fPrnCIiQJspsKVdXlEaERemSPIRF[i].Dispose();
				}
			}
		}
		if (gEYumqKvygSInlmtohVfjyeNbPCt != null)
		{
			gEYumqKvygSInlmtohVfjyeNbPCt.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return QpqLiFRFLpQDsOYoHOEdEWuDREcb;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < hGgxiZtdfcQQAuontLEeSRehgpnAA; i++)
		{
			if (fPrnCIiQJspsKVdXlEaERemSPIRF[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
			{
				fPrnCIiQJspsKVdXlEaERemSPIRF[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		qLjksAKkTRAbBeRQFuejKJlaGxFDA = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		qLjksAKkTRAbBeRQFuejKJlaGxFDA = true;
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
		return gEYumqKvygSInlmtohVfjyeNbPCt.QBUIVvArenXoggHErrgsFmRhtUXdB;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return gEYumqKvygSInlmtohVfjyeNbPCt.PitqxQuzQHruJDHtftLcpfiXXEXV;
	}

	protected bool elihvtlruEyuGPaibBwrvaoAcjxC(PidVid P_0)
	{
		return hMWLTNIRwRJMYvNwqFfUTzihuhUs(P_0);
	}

	private void zxLgIqSHxaVlMWJfYfxobriDLBSIb()
	{
		bNzBLRBxKyKKnfpbpeeirzEVeLfK(zPvcwWfiYuyeEKDlkicDRStuXYzA());
	}

	private void bNzBLRBxKyKKnfpbpeeirzEVeLfK(IList<TOhoLhSgVsNthvwMxYIJmahKNXwF> P_0)
	{
		int num = 0;
		List<ECaDvruUFTBXkTlxKwsaSudFiWbO> list = fPrnCIiQJspsKVdXlEaERemSPIRF;
		int num2 = hGgxiZtdfcQQAuontLEeSRehgpnAA;
		fPrnCIiQJspsKVdXlEaERemSPIRF = new List<ECaDvruUFTBXkTlxKwsaSudFiWbO>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				TOhoLhSgVsNthvwMxYIJmahKNXwF tOhoLhSgVsNthvwMxYIJmahKNXwF = P_0[i];
				ECaDvruUFTBXkTlxKwsaSudFiWbO eCaDvruUFTBXkTlxKwsaSudFiWbO = new ECaDvruUFTBXkTlxKwsaSudFiWbO(EzzIqIsCYMLvovALAGbWjqnNoxynA);
				eCaDvruUFTBXkTlxKwsaSudFiWbO.WRpBNgGiZlOQMsmVeqldtlHwaxZFA = tOhoLhSgVsNthvwMxYIJmahKNXwF;
				eCaDvruUFTBXkTlxKwsaSudFiWbO.WVXimkEwVUiVhEqkVdXWrokaeJSGA = tOhoLhSgVsNthvwMxYIJmahKNXwF.HUCcYDKLAaTdukQocacUWZZckgSK;
				eCaDvruUFTBXkTlxKwsaSudFiWbO.CJUPVEFuFSSjGtOWUDXnbPaENBXC = tOhoLhSgVsNthvwMxYIJmahKNXwF.yxZTnxkqUzRonrKnuDPxleLneJlI;
				eCaDvruUFTBXkTlxKwsaSudFiWbO.dfguTVSdkWjSmsiTngxTepwarXRP = tOhoLhSgVsNthvwMxYIJmahKNXwF.yxZTnxkqUzRonrKnuDPxleLneJlI;
				eCaDvruUFTBXkTlxKwsaSudFiWbO.vtdtoCHknqEwUdjbEDIjWTZmIvinA = tOhoLhSgVsNthvwMxYIJmahKNXwF.UpqYCFgQVcecVDHViDhXrufjGfOU;
				eCaDvruUFTBXkTlxKwsaSudFiWbO.JzxerLWoJNOvadSxpmxtZyUaOTIM = tOhoLhSgVsNthvwMxYIJmahKNXwF.MXsmrtnTFOYSKgUNrdTkWAdKSIYI;
				eCaDvruUFTBXkTlxKwsaSudFiWbO.ISVduekCfNHbesZPWnOIoZmqtnne = tOhoLhSgVsNthvwMxYIJmahKNXwF.qRVOpNxeaanxUoDqJkbLEwWdRSlH;
				eCaDvruUFTBXkTlxKwsaSudFiWbO.kRtsomWbxeVcLZTRaehEXXLcboHL = tOhoLhSgVsNthvwMxYIJmahKNXwF.shIYHZbKZGKvZzxWPToqoGUdXcaN;
				eCaDvruUFTBXkTlxKwsaSudFiWbO.THpRQPyqPOPkETwwrZmNlciiLygg = tOhoLhSgVsNthvwMxYIJmahKNXwF.qFuohcoUfIojdKBFfbJBLyNKWcIP;
				eCaDvruUFTBXkTlxKwsaSudFiWbO.FlxdDNCOWnIlUoIcDmjlCJbZTgjD = tOhoLhSgVsNthvwMxYIJmahKNXwF.tGjVdHkKsimGDEBUUJoTqKNxjlfE;
				eCaDvruUFTBXkTlxKwsaSudFiWbO.EXmwTlNGniRRLRLcWxWxIhTYoveT = tOhoLhSgVsNthvwMxYIJmahKNXwF.DKzIsdsuxeLHyIWDePMyuVPvQPDE;
				eCaDvruUFTBXkTlxKwsaSudFiWbO.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension = tOhoLhSgVsNthvwMxYIJmahKNXwF.cYDGLZsjseEvxFGAisvzmgEFUZxpA;
				eCaDvruUFTBXkTlxKwsaSudFiWbO.WRpBNgGiZlOQMsmVeqldtlHwaxZFA = tOhoLhSgVsNthvwMxYIJmahKNXwF;
				eCaDvruUFTBXkTlxKwsaSudFiWbO.jEBDBphuIlJFVGxcqykEfekDNwWm();
				fPrnCIiQJspsKVdXlEaERemSPIRF.Add(eCaDvruUFTBXkTlxKwsaSudFiWbO);
				num++;
			}
		}
		hGgxiZtdfcQQAuontLEeSRehgpnAA = num;
		oGNfxcininBcSNUbJOvssSFgcRRN(num2, num, list, fPrnCIiQJspsKVdXlEaERemSPIRF);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(fPrnCIiQJspsKVdXlEaERemSPIRF[j]));
			}
		}
		TWBfZYUIpACkcCHmXFutIgDGhbdMA(list, fPrnCIiQJspsKVdXlEaERemSPIRF, false);
		TWBfZYUIpACkcCHmXFutIgDGhbdMA(fPrnCIiQJspsKVdXlEaERemSPIRF, list, true);
	}

	private void pCbxtUchFZQlTVkyoDdXTeruNnix()
	{
		for (int i = 0; i < hGgxiZtdfcQQAuontLEeSRehgpnAA; i++)
		{
			fPrnCIiQJspsKVdXlEaERemSPIRF[i]?.Update();
		}
	}

	private IList<TOhoLhSgVsNthvwMxYIJmahKNXwF> zPvcwWfiYuyeEKDlkicDRStuXYzA()
	{
		return gEYumqKvygSInlmtohVfjyeNbPCt.GetJoysticks<TOhoLhSgVsNthvwMxYIJmahKNXwF>();
	}

	private void oGNfxcininBcSNUbJOvssSFgcRRN(int P_0, int P_1, List<ECaDvruUFTBXkTlxKwsaSudFiWbO> P_2, List<ECaDvruUFTBXkTlxKwsaSudFiWbO> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(ECaDvruUFTBXkTlxKwsaSudFiWbO.NOSJsAEQKgNdGJSfdGkkvRbimlJo);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			ldpPkMgCPdiZZAaryLJwbcLVETgdA(P_1, P_3, P_0, P_2, oOSPUcwhJYFmQIIozhxnOapaYKeU.UJNiCnqAvUnNthdfxYOOlUfwJVi.Exact);
			ldpPkMgCPdiZZAaryLJwbcLVETgdA(P_1, P_3, P_0, P_2, oOSPUcwhJYFmQIIozhxnOapaYKeU.UJNiCnqAvUnNthdfxYOOlUfwJVi.Approximate);
		}
		OwNTqLoVAksCjjrkIbBkdBbiEXIX(P_1, P_3, oOSPUcwhJYFmQIIozhxnOapaYKeU.UJNiCnqAvUnNthdfxYOOlUfwJVi.Exact);
		OwNTqLoVAksCjjrkIbBkdBbiEXIX(P_1, P_3, oOSPUcwhJYFmQIIozhxnOapaYKeU.UJNiCnqAvUnNthdfxYOOlUfwJVi.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			ECaDvruUFTBXkTlxKwsaSudFiWbO eCaDvruUFTBXkTlxKwsaSudFiWbO = P_3[i];
			if (eCaDvruUFTBXkTlxKwsaSudFiWbO != null && eCaDvruUFTBXkTlxKwsaSudFiWbO.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				eCaDvruUFTBXkTlxKwsaSudFiWbO.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = tiNBZUUhXxhshvCHhdxaAAFhvbJUA(P_3);
				eCaDvruUFTBXkTlxKwsaSudFiWbO.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = hwmUgNXrWxLoHGESMOVBsnnStKqb();
				biHrWGftLqIeyLRQvTFaoUYfsmmy.fzwNFMlMUuCTbEKSkJobLXnKPcvO(eCaDvruUFTBXkTlxKwsaSudFiWbO);
			}
		}
		P_3.Sort(ECaDvruUFTBXkTlxKwsaSudFiWbO.kfBHwVDlxIeBnetVcUhVyWUbWrXFA);
	}

	private void hEjMDEYkzNMVnfSMVhOxBBVBlcQU(List<ECaDvruUFTBXkTlxKwsaSudFiWbO> P_0, int P_1, int P_2)
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

	private bool naFTjdnSqchqNvdYrdfqoMGnuTiS(List<ECaDvruUFTBXkTlxKwsaSudFiWbO> P_0, int P_1)
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

	private int tiNBZUUhXxhshvCHhdxaAAFhvbJUA(List<ECaDvruUFTBXkTlxKwsaSudFiWbO> P_0)
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

	private bool qICressDeBxlTpQUGMRORRRVsmOP(List<ECaDvruUFTBXkTlxKwsaSudFiWbO> P_0, int P_1)
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

	private void ldpPkMgCPdiZZAaryLJwbcLVETgdA(int P_0, List<ECaDvruUFTBXkTlxKwsaSudFiWbO> P_1, int P_2, List<ECaDvruUFTBXkTlxKwsaSudFiWbO> P_3, oOSPUcwhJYFmQIIozhxnOapaYKeU.UJNiCnqAvUnNthdfxYOOlUfwJVi P_4)
	{
		int num = ((P_4 != oOSPUcwhJYFmQIIozhxnOapaYKeU.UJNiCnqAvUnNthdfxYOOlUfwJVi.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			ECaDvruUFTBXkTlxKwsaSudFiWbO eCaDvruUFTBXkTlxKwsaSudFiWbO = P_1[i];
			if (eCaDvruUFTBXkTlxKwsaSudFiWbO == null || eCaDvruUFTBXkTlxKwsaSudFiWbO.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				ECaDvruUFTBXkTlxKwsaSudFiWbO eCaDvruUFTBXkTlxKwsaSudFiWbO2 = P_3[j];
				if (eCaDvruUFTBXkTlxKwsaSudFiWbO2 != null && !qICressDeBxlTpQUGMRORRRVsmOP(P_1, eCaDvruUFTBXkTlxKwsaSudFiWbO2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && eCaDvruUFTBXkTlxKwsaSudFiWbO.cmboXrifvJMSIqvlMIDSMPcubKNb(eCaDvruUFTBXkTlxKwsaSudFiWbO2) >= num)
				{
					eCaDvruUFTBXkTlxKwsaSudFiWbO.gTKiIBLuCZrcuOJDvfDbvVffBlJjA(eCaDvruUFTBXkTlxKwsaSudFiWbO2);
					biHrWGftLqIeyLRQvTFaoUYfsmmy.fzwNFMlMUuCTbEKSkJobLXnKPcvO(eCaDvruUFTBXkTlxKwsaSudFiWbO);
				}
			}
		}
	}

	private void OwNTqLoVAksCjjrkIbBkdBbiEXIX(int P_0, List<ECaDvruUFTBXkTlxKwsaSudFiWbO> P_1, oOSPUcwhJYFmQIIozhxnOapaYKeU.UJNiCnqAvUnNthdfxYOOlUfwJVi P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			ECaDvruUFTBXkTlxKwsaSudFiWbO eCaDvruUFTBXkTlxKwsaSudFiWbO = P_1[i];
			if (eCaDvruUFTBXkTlxKwsaSudFiWbO == null || eCaDvruUFTBXkTlxKwsaSudFiWbO.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			oOSPUcwhJYFmQIIozhxnOapaYKeU.qIrKulptklEhiMfGIEFjCCXmONOxA qIrKulptklEhiMfGIEFjCCXmONOxA = null;
			foreach (oOSPUcwhJYFmQIIozhxnOapaYKeU.qIrKulptklEhiMfGIEFjCCXmONOxA item in biHrWGftLqIeyLRQvTFaoUYfsmmy.yiIELbJCOuhLRWQACJmqINzhFuONc(eCaDvruUFTBXkTlxKwsaSudFiWbO, P_2))
			{
				if (!qICressDeBxlTpQUGMRORRRVsmOP(P_1, item.rCGjHOXigZuRMZZVCqwUUsaWVeOr) && item.rnuEeEbpnQMGRrLFuCeNleTOGdrhb >= 0)
				{
					qIrKulptklEhiMfGIEFjCCXmONOxA = item;
					break;
				}
			}
			if (qIrKulptklEhiMfGIEFjCCXmONOxA != null)
			{
				int num = qIrKulptklEhiMfGIEFjCCXmONOxA.rnuEeEbpnQMGRrLFuCeNleTOGdrhb;
				if (!naFTjdnSqchqNvdYrdfqoMGnuTiS(P_1, num))
				{
					num = (qIrKulptklEhiMfGIEFjCCXmONOxA.rnuEeEbpnQMGRrLFuCeNleTOGdrhb = tiNBZUUhXxhshvCHhdxaAAFhvbJUA(P_1));
				}
				eCaDvruUFTBXkTlxKwsaSudFiWbO.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				eCaDvruUFTBXkTlxKwsaSudFiWbO.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = qIrKulptklEhiMfGIEFjCCXmONOxA.rCGjHOXigZuRMZZVCqwUUsaWVeOr;
				biHrWGftLqIeyLRQvTFaoUYfsmmy.fzwNFMlMUuCTbEKSkJobLXnKPcvO(eCaDvruUFTBXkTlxKwsaSudFiWbO);
			}
		}
	}

	private void wtSTPLmDShibruqkuLJrYgmqhevN()
	{
		gEYumqKvygSInlmtohVfjyeNbPCt.moFjvZxDBaDvaEoItRZQDmrpJLdSA();
		IList<TOhoLhSgVsNthvwMxYIJmahKNXwF> list = zPvcwWfiYuyeEKDlkicDRStuXYzA();
		if (enUsVhziiBhXUnolVTwuCLUIYZHA(list))
		{
			bNzBLRBxKyKKnfpbpeeirzEVeLfK(list);
		}
		qLjksAKkTRAbBeRQFuejKJlaGxFDA = false;
	}

	private bool enUsVhziiBhXUnolVTwuCLUIYZHA(IList<TOhoLhSgVsNthvwMxYIJmahKNXwF> P_0)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && !ljymAwVnHNWiUxgVZUVVrVWaPlwh(P_0[i].HUCcYDKLAaTdukQocacUWZZckgSK))
			{
				return true;
			}
		}
		int count2 = fPrnCIiQJspsKVdXlEaERemSPIRF.Count;
		for (int j = 0; j < count2; j++)
		{
			if (fPrnCIiQJspsKVdXlEaERemSPIRF[j] != null && !PduBwBwPyvyHHVGuMUSEWvcAmVWh(P_0, fPrnCIiQJspsKVdXlEaERemSPIRF[j].WVXimkEwVUiVhEqkVdXWrokaeJSGA))
			{
				return true;
			}
		}
		return false;
	}

	private bool ljymAwVnHNWiUxgVZUVVrVWaPlwh(Guid P_0)
	{
		int count = fPrnCIiQJspsKVdXlEaERemSPIRF.Count;
		for (int i = 0; i < count; i++)
		{
			if (fPrnCIiQJspsKVdXlEaERemSPIRF[i] != null && fPrnCIiQJspsKVdXlEaERemSPIRF[i].WVXimkEwVUiVhEqkVdXWrokaeJSGA == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool PduBwBwPyvyHHVGuMUSEWvcAmVWh(IList<TOhoLhSgVsNthvwMxYIJmahKNXwF> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].HUCcYDKLAaTdukQocacUWZZckgSK == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void TWBfZYUIpACkcCHmXFutIgDGhbdMA(List<ECaDvruUFTBXkTlxKwsaSudFiWbO> P_0, List<ECaDvruUFTBXkTlxKwsaSudFiWbO> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			ECaDvruUFTBXkTlxKwsaSudFiWbO eCaDvruUFTBXkTlxKwsaSudFiWbO = P_0[i];
			if (eCaDvruUFTBXkTlxKwsaSudFiWbO == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					ECaDvruUFTBXkTlxKwsaSudFiWbO eCaDvruUFTBXkTlxKwsaSudFiWbO2 = P_1[j];
					if (eCaDvruUFTBXkTlxKwsaSudFiWbO2 != null && eCaDvruUFTBXkTlxKwsaSudFiWbO.WVXimkEwVUiVhEqkVdXWrokaeJSGA == eCaDvruUFTBXkTlxKwsaSudFiWbO2.WVXimkEwVUiVhEqkVdXWrokaeJSGA)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				AVplboHfeoyeFfghCqJFDuMLBHZe(P_0[i], P_2);
			}
		}
	}

	private void AVplboHfeoyeFfghCqJFDuMLBHZe(ECaDvruUFTBXkTlxKwsaSudFiWbO P_0, bool P_1)
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
