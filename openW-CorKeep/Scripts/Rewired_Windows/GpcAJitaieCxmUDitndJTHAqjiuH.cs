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

internal class GpcAJitaieCxmUDitndJTHAqjiuH : PlatformInputManager
{
	private class mqQXAszjWSSXueXWOWdqChjPgnqX : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int RIHDZnDXprKwHKTmoBISGLmPBgMdA;

		private int iGerPAcWqLBpdayOvcNfSCAirnhB;

		public Guid aygBCpgrkzLZFHFSYsdyJgSWxGiD;

		public string CUNfMMmPrfBkUfPbPRhMRTDiSXgKA;

		public yTxKLgtyFntzrmhxUvcIusyQEikI JVJbbWbERbkYDSuLMvhIMlDXfHnc;

		public MfXGUMqqMigqjYxIzGsVcmGOmwFk XPLzjNDlsoBNrdVRSlSuhejYEdGO;

		public string KhRrpVVjNukgxUiyfDizBRKCRslX;

		public string zsONreLgxbVuscVCjvmKsksAZpAO;

		public int DlwrLlPIeHjHSeMmCzGntdZFmBou;

		public int GDznsxTwCFeQoorloXNNQgvxAyYU;

		public Guid nmvsZOwTgDkKddntTMQIVAsyWqNe;

		public PidVid OgAZaKAVBfWLvieffNCaWIvVwPgL;

		public Guid HJKFKTdQmAkvOBCrYWpDDycruDpJ;

		public int ullITPjmMDwBFSYJbDPgiOweIFvw;

		public int NxzLymToXYptbKwHyChGhDGBiFPZ;

		public int sUxmJNJMMdwUCHwXZAwcznXsiuSy;

		public int bTsWqkYXGGMsNbZQOlHZujNRgbJfA;

		public int dYkBBveUEODNYLkNYsChOFyMZMaK;

		public int rfwfdNFVVEhLUxyDhmUIEjWKMJoS;

		public bool YLrSbPWhhhaxDgnBWhkikqpcfXZq;

		public bool deMRbSEPbadfAIPXjtObAdrIuFAhA;

		public int ahHtmpvZLDyuRDEgapauOKSmlBec;

		private float[] oMxRsFCjKikfJfHltuypotkZtgpG;

		private bool[] uVKTzWuWHScGsMnRINtFJyOphgJh;

		private HardwareJoystickMap_InputManager LGYkLBSklynefcwjiYimKBMdvuoI;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> azlnhkGPdwSZzrsnMphLFhlJGdwB;

		private bool PrLhrVXttAaMLSCLQvzEZgYkDHzBA;

		private bool AfMRNRSNypkMCleEyDtvIGakXaCb;

		[CompilerGenerated]
		private Controller.Extension HTYPLuaYOqiLioWgUNqzAJExPNtQ;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return RIHDZnDXprKwHKTmoBISGLmPBgMdA;
			}
			set
			{
				RIHDZnDXprKwHKTmoBISGLmPBgMdA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return iGerPAcWqLBpdayOvcNfSCAirnhB;
			}
			set
			{
				iGerPAcWqLBpdayOvcNfSCAirnhB = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name => CUNfMMmPrfBkUfPbPRhMRTDiSXgKA;

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (iGerPAcWqLBpdayOvcNfSCAirnhB < 0)
				{
					return null;
				}
				return iGerPAcWqLBpdayOvcNfSCAirnhB;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => nmvsZOwTgDkKddntTMQIVAsyWqNe;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			[CompilerGenerated]
			get
			{
				return HTYPLuaYOqiLioWgUNqzAJExPNtQ;
			}
			[CompilerGenerated]
			set
			{
				HTYPLuaYOqiLioWgUNqzAJExPNtQ = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			JVJbbWbERbkYDSuLMvhIMlDXfHnc.tRXcVtSGUnpjmNKMsFkbpTANzpQw(motorIndex, amount, false);
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

		public mqQXAszjWSSXueXWOWdqChjPgnqX(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_0)
		{
			azlnhkGPdwSZzrsnMphLFhlJGdwB = P_0;
			iGerPAcWqLBpdayOvcNfSCAirnhB = -1;
			RIHDZnDXprKwHKTmoBISGLmPBgMdA = -1;
		}

		public void ErGAymQcLxzCjuJtzBhuafYDtIyx()
		{
			HJKFKTdQmAkvOBCrYWpDDycruDpJ = MiscTools.CreateGuidHashSHA1(KhRrpVVjNukgxUiyfDizBRKCRslX + OgAZaKAVBfWLvieffNCaWIvVwPgL.ToProductGuid().ToString());
			NxzLymToXYptbKwHyChGhDGBiFPZ = bTsWqkYXGGMsNbZQOlHZujNRgbJfA;
			sUxmJNJMMdwUCHwXZAwcznXsiuSy = dYkBBveUEODNYLkNYsChOFyMZMaK + rfwfdNFVVEhLUxyDhmUIEjWKMJoS * 8;
			glFgdPeTFbPcPFLzmGGxFARMPVbhA();
			aygBCpgrkzLZFHFSYsdyJgSWxGiD = LGYkLBSklynefcwjiYimKBMdvuoI.hardwareMapIdentifier.guid;
			CUNfMMmPrfBkUfPbPRhMRTDiSXgKA = LGYkLBSklynefcwjiYimKBMdvuoI.controllerName;
			PrLhrVXttAaMLSCLQvzEZgYkDHzBA = aygBCpgrkzLZFHFSYsdyJgSWxGiD == Guid.Empty;
			oMxRsFCjKikfJfHltuypotkZtgpG = new float[NxzLymToXYptbKwHyChGhDGBiFPZ];
			uVKTzWuWHScGsMnRINtFJyOphgJh = new bool[sUxmJNJMMdwUCHwXZAwcznXsiuSy];
			Update();
		}

		public void sPOmBZHXFfMrqbeJtTfcilZCZsmy(mqQXAszjWSSXueXWOWdqChjPgnqX P_0)
		{
			if (P_0 != null)
			{
				iGerPAcWqLBpdayOvcNfSCAirnhB = P_0.iGerPAcWqLBpdayOvcNfSCAirnhB;
				RIHDZnDXprKwHKTmoBISGLmPBgMdA = P_0.RIHDZnDXprKwHKTmoBISGLmPBgMdA;
				for (int i = 0; i < MathTools.Min(uVKTzWuWHScGsMnRINtFJyOphgJh.Length, P_0.uVKTzWuWHScGsMnRINtFJyOphgJh.Length); i++)
				{
					uVKTzWuWHScGsMnRINtFJyOphgJh[i] = P_0.uVKTzWuWHScGsMnRINtFJyOphgJh[i];
				}
				for (int j = 0; j < MathTools.Min(oMxRsFCjKikfJfHltuypotkZtgpG.Length, P_0.oMxRsFCjKikfJfHltuypotkZtgpG.Length); j++)
				{
					oMxRsFCjKikfJfHltuypotkZtgpG[j] = P_0.oMxRsFCjKikfJfHltuypotkZtgpG[j];
				}
				AfMRNRSNypkMCleEyDtvIGakXaCb = P_0.AfMRNRSNypkMCleEyDtvIGakXaCb;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			aKohgOkLYaYuYhCYYLcOPBMXNoHN();
			tVHOpneWEtpVPdyaTnoZhQodiNQM();
			if (!AfMRNRSNypkMCleEyDtvIGakXaCb && JVJbbWbERbkYDSuLMvhIMlDXfHnc.RezEQvkgruNsDRznSYUvqEjciwwc)
			{
				AfMRNRSNypkMCleEyDtvIGakXaCb = true;
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
			if (NxzLymToXYptbKwHyChGhDGBiFPZ != dataUpdater.axisCount || sUxmJNJMMdwUCHwXZAwcznXsiuSy != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < NxzLymToXYptbKwHyChGhDGBiFPZ; i++)
			{
				dataUpdater.axisValues[i] = oMxRsFCjKikfJfHltuypotkZtgpG[i];
			}
			for (int j = 0; j < sUxmJNJMMdwUCHwXZAwcznXsiuSy; j++)
			{
				dataUpdater.buttonValues[j] = uVKTzWuWHScGsMnRINtFJyOphgJh[j];
			}
			if (AfMRNRSNypkMCleEyDtvIGakXaCb && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int CrBgOzITQMmaiSTmTDbwFrLKjaUN(mqQXAszjWSSXueXWOWdqChjPgnqX P_0)
		{
			if (P_0.RIHDZnDXprKwHKTmoBISGLmPBgMdA == RIHDZnDXprKwHKTmoBISGLmPBgMdA)
			{
				return 2;
			}
			if (bTsWqkYXGGMsNbZQOlHZujNRgbJfA != P_0.bTsWqkYXGGMsNbZQOlHZujNRgbJfA)
			{
				return 0;
			}
			if (dYkBBveUEODNYLkNYsChOFyMZMaK != P_0.dYkBBveUEODNYLkNYsChOFyMZMaK)
			{
				return 0;
			}
			if (rfwfdNFVVEhLUxyDhmUIEjWKMJoS != P_0.rfwfdNFVVEhLUxyDhmUIEjWKMJoS)
			{
				return 0;
			}
			if (P_0.nmvsZOwTgDkKddntTMQIVAsyWqNe == nmvsZOwTgDkKddntTMQIVAsyWqNe)
			{
				return 2;
			}
			if (P_0.HJKFKTdQmAkvOBCrYWpDDycruDpJ == HJKFKTdQmAkvOBCrYWpDDycruDpJ)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo uCQOiZlRmcmxOcgzRSDdxMHRSJYt()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			JVGAuuzNxtbhJOPEvjFaATvtXmkDA(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			rLefRqgolOaxTgijdtFhEucDbLfhd(bridgedController);
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
			return new ControllerDisconnectedEventArgs(RIHDZnDXprKwHKTmoBISGLmPBgMdA);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void aKohgOkLYaYuYhCYYLcOPBMXNoHN()
		{
			if (NxzLymToXYptbKwHyChGhDGBiFPZ <= 0 || LGYkLBSklynefcwjiYimKBMdvuoI.map.platform != InputPlatform.SDL2)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_SDL2_Base)LGYkLBSklynefcwjiYimKBMdvuoI.map).Axes_orig;
			if (axes_orig != null)
			{
				for (int i = 0; i < axes_orig.Length; i++)
				{
					oizBifCAryeYqYcRLXhtdSjxRHAh(axes_orig[i], i);
				}
			}
		}

		private void tVHOpneWEtpVPdyaTnoZhQodiNQM()
		{
			if (sUxmJNJMMdwUCHwXZAwcznXsiuSy <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_SDL2_Base)LGYkLBSklynefcwjiYimKBMdvuoI.map).Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					FaPeZkllHnfIJDJUuwUPXkSsyVth(buttons_orig[i], i);
				}
			}
		}

		private void oizBifCAryeYqYcRLXhtdSjxRHAh(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0, int P_1)
		{
			if (P_1 >= NxzLymToXYptbKwHyChGhDGBiFPZ)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			oMxRsFCjKikfJfHltuypotkZtgpG[P_1] = kNnJrvrBjrWxhURSzPbijqfuReLT(P_0);
		}

		private void FaPeZkllHnfIJDJUuwUPXkSsyVth(HardwareJoystickMap.Platform_SDL2_Base.Button P_0, int P_1)
		{
			if (P_1 >= sUxmJNJMMdwUCHwXZAwcznXsiuSy)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			uVKTzWuWHScGsMnRINtFJyOphgJh[P_1] = lTOwFCOGezKEIBLtrsvCtqWvTWjQ(P_0);
		}

		private float kNnJrvrBjrWxhURSzPbijqfuReLT(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= bTsWqkYXGGMsNbZQOlHZujNRgbJfA || sourceAxis >= 56)
				{
					return 0f;
				}
				return JVJbbWbERbkYDSuLMvhIMlDXfHnc.DWpXcPhQNfBOzRfRzBoNKQvjuSgk(sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= dYkBBveUEODNYLkNYsChOFyMZMaK || sourceButton >= 256)
				{
					return 0f;
				}
				if (!JVJbbWbERbkYDSuLMvhIMlDXfHnc.JswvfwtLZJgUUfDbwpVbDIBrVULP(sourceButton))
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
				if (sourceHat < 0 || sourceHat >= rfwfdNFVVEhLUxyDhmUIEjWKMJoS || sourceHat >= 4)
				{
					return 0f;
				}
				int num = JVJbbWbERbkYDSuLMvhIMlDXfHnc.fcrEERdKsnzBPsEiIjnLqIKILtAxA(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = UUrtJPhkUsGZwCYSVgOyidscgDgU(num, AxisDirection.Horizontal);
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
					num2 = UUrtJPhkUsGZwCYSVgOyidscgDgU(num, AxisDirection.Vertical);
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

		private bool lTOwFCOGezKEIBLtrsvCtqWvTWjQ(HardwareJoystickMap.Platform_SDL2_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (JVJbbWbERbkYDSuLMvhIMlDXfHnc.JswvfwtLZJgUUfDbwpVbDIBrVULP(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!JVJbbWbERbkYDSuLMvhIMlDXfHnc.JswvfwtLZJgUUfDbwpVbDIBrVULP(P_0.requiredButtons[j]))
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
				if (sourceButton < 0 || sourceButton >= dYkBBveUEODNYLkNYsChOFyMZMaK || sourceButton >= 256)
				{
					return false;
				}
				return JVJbbWbERbkYDSuLMvhIMlDXfHnc.JswvfwtLZJgUUfDbwpVbDIBrVULP(sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis <= 0 || sourceAxis >= bTsWqkYXGGMsNbZQOlHZujNRgbJfA || sourceAxis >= 56)
				{
					return false;
				}
				float num = JVJbbWbERbkYDSuLMvhIMlDXfHnc.DWpXcPhQNfBOzRfRzBoNKQvjuSgk(sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= rfwfdNFVVEhLUxyDhmUIEjWKMJoS || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return RjuXVIHzaUGFJIKTpGLIkzEKBrpoA(JVJbbWbERbkYDSuLMvhIMlDXfHnc.fcrEERdKsnzBPsEiIjnLqIKILtAxA(sourceHat), 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return RjuXVIHzaUGFJIKTpGLIkzEKBrpoA(JVJbbWbERbkYDSuLMvhIMlDXfHnc.fcrEERdKsnzBPsEiIjnLqIKILtAxA(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return RjuXVIHzaUGFJIKTpGLIkzEKBrpoA(JVJbbWbERbkYDSuLMvhIMlDXfHnc.fcrEERdKsnzBPsEiIjnLqIKILtAxA(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return RjuXVIHzaUGFJIKTpGLIkzEKBrpoA(JVJbbWbERbkYDSuLMvhIMlDXfHnc.fcrEERdKsnzBPsEiIjnLqIKILtAxA(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return RjuXVIHzaUGFJIKTpGLIkzEKBrpoA(JVJbbWbERbkYDSuLMvhIMlDXfHnc.fcrEERdKsnzBPsEiIjnLqIKILtAxA(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return RjuXVIHzaUGFJIKTpGLIkzEKBrpoA(JVJbbWbERbkYDSuLMvhIMlDXfHnc.fcrEERdKsnzBPsEiIjnLqIKILtAxA(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return RjuXVIHzaUGFJIKTpGLIkzEKBrpoA(JVJbbWbERbkYDSuLMvhIMlDXfHnc.fcrEERdKsnzBPsEiIjnLqIKILtAxA(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return RjuXVIHzaUGFJIKTpGLIkzEKBrpoA(JVJbbWbERbkYDSuLMvhIMlDXfHnc.fcrEERdKsnzBPsEiIjnLqIKILtAxA(sourceHat), 7, P_0.sourceHatType);
				}
			}
			return false;
		}

		private bool RjuXVIHzaUGFJIKTpGLIkzEKBrpoA(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (LGYkLBSklynefcwjiYimKBMdvuoI.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float UUrtJPhkUsGZwCYSVgOyidscgDgU(int P_0, AxisDirection P_1)
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

		private ControlDeviceType obuZJCHUeExczGyAVMrJINvcpsEX(MfXGUMqqMigqjYxIzGsVcmGOmwFk P_0)
		{
			return P_0 switch
			{
				MfXGUMqqMigqjYxIzGsVcmGOmwFk.Joystick => ControlDeviceType.Joystick, 
				MfXGUMqqMigqjYxIzGsVcmGOmwFk.Gamepad => ControlDeviceType.Gamepad, 
				MfXGUMqqMigqjYxIzGsVcmGOmwFk.Keyboard => ControlDeviceType.Keyboard, 
				MfXGUMqqMigqjYxIzGsVcmGOmwFk.Mouse => ControlDeviceType.Mouse, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void glFgdPeTFbPcPFLzmGGxFARMPVbhA()
		{
			LGYkLBSklynefcwjiYimKBMdvuoI = azlnhkGPdwSZzrsnMphLFhlJGdwB(uCQOiZlRmcmxOcgzRSDdxMHRSJYt());
			if (LGYkLBSklynefcwjiYimKBMdvuoI == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (LGYkLBSklynefcwjiYimKBMdvuoI.useSystemName)
			{
				if (!string.IsNullOrEmpty(zsONreLgxbVuscVCjvmKsksAZpAO))
				{
					string text = Regex.Replace(zsONreLgxbVuscVCjvmKsksAZpAO, "\\s+", " ");
					text = text.Trim();
					if (!string.IsNullOrEmpty(text))
					{
						LGYkLBSklynefcwjiYimKBMdvuoI.controllerName = text;
					}
				}
				if (LGYkLBSklynefcwjiYimKBMdvuoI.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(LGYkLBSklynefcwjiYimKBMdvuoI.deviceLocalizationInfo.parentKeys[0]))
				{
					string a = LGYkLBSklynefcwjiYimKBMdvuoI.deviceLocalizationInfo.parentKeys[0];
					string text2 = string.Format("{0}:{1}", JVJbbWbERbkYDSuLMvhIMlDXfHnc.fMZrOOEFDXGwImnWFZzNoxiBocwP.vendorId.ToString("x4"), JVJbbWbERbkYDSuLMvhIMlDXfHnc.fMZrOOEFDXGwImnWFZzNoxiBocwP.productId.ToString("x4"));
					LGYkLBSklynefcwjiYimKBMdvuoI.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(a, text2));
					if (!string.IsNullOrEmpty(JVJbbWbERbkYDSuLMvhIMlDXfHnc.mGOmHPnmiQYYAZsBYWlCTmvUcSHi))
					{
						LGYkLBSklynefcwjiYimKBMdvuoI.deviceLocalizationInfo.InsertParentKey(1, LocalizationManager.AppendToKeyAsPath(a, JVJbbWbERbkYDSuLMvhIMlDXfHnc.mGOmHPnmiQYYAZsBYWlCTmvUcSHi));
					}
					if (!string.IsNullOrEmpty(JVJbbWbERbkYDSuLMvhIMlDXfHnc.mGOmHPnmiQYYAZsBYWlCTmvUcSHi))
					{
						LGYkLBSklynefcwjiYimKBMdvuoI.deviceLocalizationInfo.additionalIdentifyingInformation = $"{JVJbbWbERbkYDSuLMvhIMlDXfHnc.mGOmHPnmiQYYAZsBYWlCTmvUcSHi} [{text2}]";
					}
					else
					{
						LGYkLBSklynefcwjiYimKBMdvuoI.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text2}]";
					}
				}
			}
			NxzLymToXYptbKwHyChGhDGBiFPZ = LGYkLBSklynefcwjiYimKBMdvuoI.axisCount;
			sUxmJNJMMdwUCHwXZAwcznXsiuSy = LGYkLBSklynefcwjiYimKBMdvuoI.buttonCount;
		}

		private string qbRbGBCTUGsDzaqEAQVKdIwBpWoo()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{JVJbbWbERbkYDSuLMvhIMlDXfHnc.sEGymECmULCcAGgvPmhZiuoNVygTA}{KhRrpVVjNukgxUiyfDizBRKCRslX}{DlwrLlPIeHjHSeMmCzGntdZFmBou}{OgAZaKAVBfWLvieffNCaWIvVwPgL.ToProductGuid()}");
		}

		private void JVGAuuzNxtbhJOPEvjFaATvtXmkDA(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.SDL2;
			P_0.inputSource = JVJbbWbERbkYDSuLMvhIMlDXfHnc.sEGymECmULCcAGgvPmhZiuoNVygTA;
			P_0.deviceType = obuZJCHUeExczGyAVMrJINvcpsEX(XPLzjNDlsoBNrdVRSlSuhejYEdGO);
			P_0.hardwareIdentifier = qbRbGBCTUGsDzaqEAQVKdIwBpWoo();
			P_0.hardwareAxisCount = bTsWqkYXGGMsNbZQOlHZujNRgbJfA;
			P_0.hardwareButtonCount = dYkBBveUEODNYLkNYsChOFyMZMaK;
			P_0.hardwareHatCount = rfwfdNFVVEhLUxyDhmUIEjWKMJoS;
			P_0.hw_productName = KhRrpVVjNukgxUiyfDizBRKCRslX;
			P_0.hw_deviceGuid = nmvsZOwTgDkKddntTMQIVAsyWqNe;
			P_0.hw_productId = DlwrLlPIeHjHSeMmCzGntdZFmBou;
			P_0.hw_pidVid = OgAZaKAVBfWLvieffNCaWIvVwPgL;
			P_0.hw_isBluetoothDevice = YLrSbPWhhhaxDgnBWhkikqpcfXZq;
			P_0.hw_bluetoothDeviceName = KhRrpVVjNukgxUiyfDizBRKCRslX;
			P_0.hw_systemDeviceName = KhRrpVVjNukgxUiyfDizBRKCRslX;
			P_0.hw_supportsVibration = deMRbSEPbadfAIPXjtObAdrIuFAhA;
			P_0.hw_isSDL2Gamepad = JVJbbWbERbkYDSuLMvhIMlDXfHnc.eSAILtBHoSiDxDrUFKuSzltGfcqF == MfXGUMqqMigqjYxIzGsVcmGOmwFk.Gamepad;
			P_0.hw_localVibrationMotorCount = ahHtmpvZLDyuRDEgapauOKSmlBec;
		}

		private void rLefRqgolOaxTgijdtFhEucDbLfhd(BridgedController P_0)
		{
			JVGAuuzNxtbhJOPEvjFaATvtXmkDA(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = LGYkLBSklynefcwjiYimKBMdvuoI.ToGameHardwareControllerMap();
			P_0.instanceName = KhRrpVVjNukgxUiyfDizBRKCRslX;
			P_0.productName = KhRrpVVjNukgxUiyfDizBRKCRslX;
			P_0.axisCount = NxzLymToXYptbKwHyChGhDGBiFPZ;
			P_0.buttonCount = sUxmJNJMMdwUCHwXZAwcznXsiuSy;
			P_0.unknownControllerHats = uHiCmoksmOaKQTqUjJXXncauXmCkA();
			P_0.controllerTypeGuid = aygBCpgrkzLZFHFSYsdyJgSWxGiD;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void NcaCeJbgJgadgkgcDlEugAgLkoNU()
		{
			for (int i = 0; i < sUxmJNJMMdwUCHwXZAwcznXsiuSy; i++)
			{
				uVKTzWuWHScGsMnRINtFJyOphgJh[i] = false;
			}
			for (int j = 0; j < NxzLymToXYptbKwHyChGhDGBiFPZ; j++)
			{
				oMxRsFCjKikfJfHltuypotkZtgpG[j] = 0f;
			}
		}

		private UnknownControllerHat[] uHiCmoksmOaKQTqUjJXXncauXmCkA()
		{
			if (!PrLhrVXttAaMLSCLQvzEZgYkDHzBA)
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

		public static int NPRNYyNoitXkMfCsMjlFLfCFFXoN(mqQXAszjWSSXueXWOWdqChjPgnqX P_0, mqQXAszjWSSXueXWOWdqChjPgnqX P_1)
		{
			if (P_0.iGerPAcWqLBpdayOvcNfSCAirnhB < P_1.iGerPAcWqLBpdayOvcNfSCAirnhB)
			{
				return -1;
			}
			if (P_0.iGerPAcWqLBpdayOvcNfSCAirnhB > P_1.iGerPAcWqLBpdayOvcNfSCAirnhB)
			{
				return 1;
			}
			return 0;
		}

		public static int sNdtsohgmTIYtyQUurNJnDzOtcCN(mqQXAszjWSSXueXWOWdqChjPgnqX P_0, mqQXAszjWSSXueXWOWdqChjPgnqX P_1)
		{
			if (P_0.ullITPjmMDwBFSYJbDPgiOweIFvw < P_1.ullITPjmMDwBFSYJbDPgiOweIFvw)
			{
				return -1;
			}
			if (P_0.ullITPjmMDwBFSYJbDPgiOweIFvw > P_1.ullITPjmMDwBFSYJbDPgiOweIFvw)
			{
				return 1;
			}
			return 0;
		}
	}

	private class iqiFkxHHqpRxGibPWjHagofHWUCJA
	{
		public enum AKwXdTceDmFOZhBfJENxeQOOKULEA
		{
			Exact = 0,
			Approximate = 1
		}

		public class HmBvFQuRiyoypFOdBrTAOpTEDXJC
		{
			public int lgkePeyJhfJYBtScevqTwNKLxIlt;

			public Guid czFekFujbOMkucBnFQmfReinSxCA;

			public Guid DNiDMnWMTpuItKHCZBhurnHWYYwU;

			public int KFDwrUJLrAiLIxWoQjqFoBKpIoeIA;

			public int WMnCHXDjiRVbUwiYtsjYTAoxUvuT;

			public int RhbgCuITPuzSslvlTELCAFhPtOtV;

			public int WKEKnECvlopCHlpnNhZaiHVEYeII;

			public bool HoqfEJjGzkoVcGQRAyzbdeSDMlbWc(mqQXAszjWSSXueXWOWdqChjPgnqX P_0, AKwXdTceDmFOZhBfJENxeQOOKULEA P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == lgkePeyJhfJYBtScevqTwNKLxIlt)
				{
					return true;
				}
				if (WMnCHXDjiRVbUwiYtsjYTAoxUvuT != P_0.bTsWqkYXGGMsNbZQOlHZujNRgbJfA)
				{
					return false;
				}
				if (RhbgCuITPuzSslvlTELCAFhPtOtV != P_0.dYkBBveUEODNYLkNYsChOFyMZMaK)
				{
					return false;
				}
				if (WKEKnECvlopCHlpnNhZaiHVEYeII != P_0.rfwfdNFVVEhLUxyDhmUIEjWKMJoS)
				{
					return false;
				}
				return P_1 switch
				{
					AKwXdTceDmFOZhBfJENxeQOOKULEA.Exact => czFekFujbOMkucBnFQmfReinSxCA == P_0.nmvsZOwTgDkKddntTMQIVAsyWqNe, 
					AKwXdTceDmFOZhBfJENxeQOOKULEA.Approximate => DNiDMnWMTpuItKHCZBhurnHWYYwU == P_0.HJKFKTdQmAkvOBCrYWpDDycruDpJ, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		private sealed class coUULGLAdWVUIdzVYibnEhAIXHqW : IEnumerable<HmBvFQuRiyoypFOdBrTAOpTEDXJC>, IEnumerable, IEnumerator<HmBvFQuRiyoypFOdBrTAOpTEDXJC>, IEnumerator, IDisposable
		{
			private int xPjXcCbRNqLCsUyQpvDTslKyaOoE;

			private HmBvFQuRiyoypFOdBrTAOpTEDXJC VMhKkrfRwFsJcpISZQGVrDICAbo;

			private int DkJEPQyIVRONhNCUEgrMEnWiTZdFA;

			public iqiFkxHHqpRxGibPWjHagofHWUCJA mrNINzNNwCOzRdzGUMhMCwPExBSm;

			private mqQXAszjWSSXueXWOWdqChjPgnqX BglAQxbAijLMVBsJicisBbMCMgezA;

			public mqQXAszjWSSXueXWOWdqChjPgnqX VruxCSaLfEuQehpQSyaOgvZOBvuB;

			private AKwXdTceDmFOZhBfJENxeQOOKULEA IAOfbbILAZLdWgssYcmHBzssujTf;

			public AKwXdTceDmFOZhBfJENxeQOOKULEA jInccUXLxLzhrSeQxgjoLcqmIHOb;

			private int ERUXFXrjfjwVxRqMSscmRlRAYcDT;

			private int ZNmhdWFwYriRDspYIDqfCuONjgnTA;

			HmBvFQuRiyoypFOdBrTAOpTEDXJC IEnumerator<HmBvFQuRiyoypFOdBrTAOpTEDXJC>.Current
			{
				[DebuggerHidden]
				get
				{
					return VMhKkrfRwFsJcpISZQGVrDICAbo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return VMhKkrfRwFsJcpISZQGVrDICAbo;
				}
			}

			[DebuggerHidden]
			public coUULGLAdWVUIdzVYibnEhAIXHqW(int P_0)
			{
				xPjXcCbRNqLCsUyQpvDTslKyaOoE = P_0;
				DkJEPQyIVRONhNCUEgrMEnWiTZdFA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				xPjXcCbRNqLCsUyQpvDTslKyaOoE = -2;
			}

			private bool MoveNext()
			{
				int num = xPjXcCbRNqLCsUyQpvDTslKyaOoE;
				iqiFkxHHqpRxGibPWjHagofHWUCJA iqiFkxHHqpRxGibPWjHagofHWUCJA2 = mrNINzNNwCOzRdzGUMhMCwPExBSm;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					xPjXcCbRNqLCsUyQpvDTslKyaOoE = -1;
					goto IL_0083;
				}
				xPjXcCbRNqLCsUyQpvDTslKyaOoE = -1;
				ERUXFXrjfjwVxRqMSscmRlRAYcDT = iqiFkxHHqpRxGibPWjHagofHWUCJA2.WJODdIONSlpaqEflKUixinpfpbII.Count;
				ZNmhdWFwYriRDspYIDqfCuONjgnTA = 0;
				goto IL_0093;
				IL_0083:
				ZNmhdWFwYriRDspYIDqfCuONjgnTA++;
				goto IL_0093;
				IL_0093:
				if (ZNmhdWFwYriRDspYIDqfCuONjgnTA < ERUXFXrjfjwVxRqMSscmRlRAYcDT)
				{
					if (iqiFkxHHqpRxGibPWjHagofHWUCJA2.WJODdIONSlpaqEflKUixinpfpbII[ZNmhdWFwYriRDspYIDqfCuONjgnTA].HoqfEJjGzkoVcGQRAyzbdeSDMlbWc(BglAQxbAijLMVBsJicisBbMCMgezA, IAOfbbILAZLdWgssYcmHBzssujTf))
					{
						VMhKkrfRwFsJcpISZQGVrDICAbo = iqiFkxHHqpRxGibPWjHagofHWUCJA2.WJODdIONSlpaqEflKUixinpfpbII[ZNmhdWFwYriRDspYIDqfCuONjgnTA];
						xPjXcCbRNqLCsUyQpvDTslKyaOoE = 1;
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
			IEnumerator<HmBvFQuRiyoypFOdBrTAOpTEDXJC> IEnumerable<HmBvFQuRiyoypFOdBrTAOpTEDXJC>.GetEnumerator()
			{
				coUULGLAdWVUIdzVYibnEhAIXHqW coUULGLAdWVUIdzVYibnEhAIXHqW2;
				if (xPjXcCbRNqLCsUyQpvDTslKyaOoE == -2 && DkJEPQyIVRONhNCUEgrMEnWiTZdFA == Environment.CurrentManagedThreadId)
				{
					xPjXcCbRNqLCsUyQpvDTslKyaOoE = 0;
					coUULGLAdWVUIdzVYibnEhAIXHqW2 = this;
				}
				else
				{
					coUULGLAdWVUIdzVYibnEhAIXHqW2 = new coUULGLAdWVUIdzVYibnEhAIXHqW(0);
					coUULGLAdWVUIdzVYibnEhAIXHqW2.mrNINzNNwCOzRdzGUMhMCwPExBSm = mrNINzNNwCOzRdzGUMhMCwPExBSm;
				}
				coUULGLAdWVUIdzVYibnEhAIXHqW2.BglAQxbAijLMVBsJicisBbMCMgezA = VruxCSaLfEuQehpQSyaOgvZOBvuB;
				coUULGLAdWVUIdzVYibnEhAIXHqW2.IAOfbbILAZLdWgssYcmHBzssujTf = jInccUXLxLzhrSeQxgjoLcqmIHOb;
				return coUULGLAdWVUIdzVYibnEhAIXHqW2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<HmBvFQuRiyoypFOdBrTAOpTEDXJC>)this).GetEnumerator();
			}
		}

		private List<HmBvFQuRiyoypFOdBrTAOpTEDXJC> WJODdIONSlpaqEflKUixinpfpbII;

		public iqiFkxHHqpRxGibPWjHagofHWUCJA()
		{
			WJODdIONSlpaqEflKUixinpfpbII = new List<HmBvFQuRiyoypFOdBrTAOpTEDXJC>();
		}

		public void athBPVytqKFJkfnugIpYLFoYfTMP(mqQXAszjWSSXueXWOWdqChjPgnqX P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = WJODdIONSlpaqEflKUixinpfpbII.Count;
			for (int i = 0; i < count; i++)
			{
				if (WJODdIONSlpaqEflKUixinpfpbII[i].HoqfEJjGzkoVcGQRAyzbdeSDMlbWc(P_0, AKwXdTceDmFOZhBfJENxeQOOKULEA.Exact))
				{
					WJODdIONSlpaqEflKUixinpfpbII[i].lgkePeyJhfJYBtScevqTwNKLxIlt = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					WJODdIONSlpaqEflKUixinpfpbII[i].czFekFujbOMkucBnFQmfReinSxCA = P_0.nmvsZOwTgDkKddntTMQIVAsyWqNe;
					WJODdIONSlpaqEflKUixinpfpbII[i].DNiDMnWMTpuItKHCZBhurnHWYYwU = P_0.HJKFKTdQmAkvOBCrYWpDDycruDpJ;
					WJODdIONSlpaqEflKUixinpfpbII[i].KFDwrUJLrAiLIxWoQjqFoBKpIoeIA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					WJODdIONSlpaqEflKUixinpfpbII[i].WMnCHXDjiRVbUwiYtsjYTAoxUvuT = P_0.bTsWqkYXGGMsNbZQOlHZujNRgbJfA;
					WJODdIONSlpaqEflKUixinpfpbII[i].RhbgCuITPuzSslvlTELCAFhPtOtV = P_0.dYkBBveUEODNYLkNYsChOFyMZMaK;
					WJODdIONSlpaqEflKUixinpfpbII[i].WKEKnECvlopCHlpnNhZaiHVEYeII = P_0.rfwfdNFVVEhLUxyDhmUIEjWKMJoS;
					CJsTdCBaFKclDajFbaBavTiZsect(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.nmvsZOwTgDkKddntTMQIVAsyWqNe, i);
					return;
				}
			}
			WJODdIONSlpaqEflKUixinpfpbII.Add(new HmBvFQuRiyoypFOdBrTAOpTEDXJC
			{
				lgkePeyJhfJYBtScevqTwNKLxIlt = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				czFekFujbOMkucBnFQmfReinSxCA = P_0.nmvsZOwTgDkKddntTMQIVAsyWqNe,
				DNiDMnWMTpuItKHCZBhurnHWYYwU = P_0.HJKFKTdQmAkvOBCrYWpDDycruDpJ,
				KFDwrUJLrAiLIxWoQjqFoBKpIoeIA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				WMnCHXDjiRVbUwiYtsjYTAoxUvuT = P_0.bTsWqkYXGGMsNbZQOlHZujNRgbJfA,
				RhbgCuITPuzSslvlTELCAFhPtOtV = P_0.dYkBBveUEODNYLkNYsChOFyMZMaK,
				WKEKnECvlopCHlpnNhZaiHVEYeII = P_0.rfwfdNFVVEhLUxyDhmUIEjWKMJoS
			});
			CJsTdCBaFKclDajFbaBavTiZsect(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.nmvsZOwTgDkKddntTMQIVAsyWqNe, WJODdIONSlpaqEflKUixinpfpbII.Count - 1);
		}

		public bool kMqYgVFBlaKGedlbbsdOivsYsYBJ(mqQXAszjWSSXueXWOWdqChjPgnqX P_0, AKwXdTceDmFOZhBfJENxeQOOKULEA P_1)
		{
			int count = WJODdIONSlpaqEflKUixinpfpbII.Count;
			for (int i = 0; i < count; i++)
			{
				if (WJODdIONSlpaqEflKUixinpfpbII[i].HoqfEJjGzkoVcGQRAyzbdeSDMlbWc(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(coUULGLAdWVUIdzVYibnEhAIXHqW))]
		public IEnumerable<HmBvFQuRiyoypFOdBrTAOpTEDXJC> GsZcnQjSRezFaedeYRYtaOwiGLoH(mqQXAszjWSSXueXWOWdqChjPgnqX P_0, AKwXdTceDmFOZhBfJENxeQOOKULEA P_1)
		{
			return new coUULGLAdWVUIdzVYibnEhAIXHqW(-2)
			{
				mrNINzNNwCOzRdzGUMhMCwPExBSm = this,
				VruxCSaLfEuQehpQSyaOgvZOBvuB = P_0,
				jInccUXLxLzhrSeQxgjoLcqmIHOb = P_1
			};
		}

		private void CJsTdCBaFKclDajFbaBavTiZsect(int P_0, Guid P_1, int P_2)
		{
			for (int num = WJODdIONSlpaqEflKUixinpfpbII.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (WJODdIONSlpaqEflKUixinpfpbII[num].lgkePeyJhfJYBtScevqTwNKLxIlt == P_0 || WJODdIONSlpaqEflKUixinpfpbII[num].czFekFujbOMkucBnFQmfReinSxCA == P_1))
				{
					WJODdIONSlpaqEflKUixinpfpbII.RemoveAt(num);
				}
			}
		}
	}

	internal const bool DhLowWEKLPFjnvlBSAvfpQVnEIlE = true;

	private IInputSource epxwZUYuMarftiCRscRElCfGOCOb;

	private List<mqQXAszjWSSXueXWOWdqChjPgnqX> fgMmQusetIMkehVLSiOfGXmSBOGE;

	private int nWcwHFXtMhmhBTQzNMqWTkaMSiJW;

	private iqiFkxHHqpRxGibPWjHagofHWUCJA TNvdUgGQcOMkOVTaFGEowfwcISHR;

	private bool qoUdaZUUOFdrRaiElkuwtOwNongCA;

	private Action<int, ControllerDataUpdater> malDUvJOGuENSlzQzTBtQUkBWUCq;

	private PlatformInputManager uhIsDhnVPFEIZMVbHVVBZdFkvLc;

	private readonly bool HeolXJWJgBNREJirdUrZvncgagPK;

	private readonly bool LwtlvnrJqHLwebGVxcVAYiVMpraG;

	private readonly bool PLaZHKuDBgKOoxaUUzJcFioLrOiI;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> sVGaLNqLFWKbnaewBDtBbwABAaqF;

	private readonly Func<int> iYkVhLYbEwIPKnDeZAESByfDPhDfA;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => nWcwHFXtMhmhBTQzNMqWTkaMSiJW;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => uhIsDhnVPFEIZMVbHVVBZdFkvLc;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => epxwZUYuMarftiCRscRElCfGOCOb;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.SDL2;

	public GpcAJitaieCxmUDitndJTHAqjiuH(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2, bool P_3, bool P_4, bool P_5)
	{
		try
		{
			sVGaLNqLFWKbnaewBDtBbwABAaqF = P_1;
			iYkVhLYbEwIPKnDeZAESByfDPhDfA = P_2;
			HeolXJWJgBNREJirdUrZvncgagPK = P_3;
			LwtlvnrJqHLwebGVxcVAYiVMpraG = P_4;
			PLaZHKuDBgKOoxaUUzJcFioLrOiI = P_5;
			uhIsDhnVPFEIZMVbHVVBZdFkvLc = this;
			epxwZUYuMarftiCRscRElCfGOCOb = new SDL2InputSource(P_0.updateLoop, P_3, P_3, P_4, P_5);
			malDUvJOGuENSlzQzTBtQUkBWUCq = UpdateControllerData;
			epxwZUYuMarftiCRscRElCfGOCOb.DeviceChangedEvent += YciWUyfCEvdqFNXigIzwjFTWZVBG;
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
		if (HeolXJWJgBNREJirdUrZvncgagPK)
		{
			TNvdUgGQcOMkOVTaFGEowfwcISHR = new iqiFkxHHqpRxGibPWjHagofHWUCJA();
			EocDqlJsXudRnzYEiPKYsxlHgONn();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (epxwZUYuMarftiCRscRElCfGOCOb != null)
		{
			epxwZUYuMarftiCRscRElCfGOCOb.Update();
		}
		if (HeolXJWJgBNREJirdUrZvncgagPK)
		{
			if (qoUdaZUUOFdrRaiElkuwtOwNongCA)
			{
				vyqWnoRCGpkDgnDdjPUxthPFLhQk();
			}
			if (epxwZUYuMarftiCRscRElCfGOCOb != null)
			{
				for (int i = 0; i < nWcwHFXtMhmhBTQzNMqWTkaMSiJW; i++)
				{
					fgMmQusetIMkehVLSiOfGXmSBOGE[i]?.JVJbbWbERbkYDSuLMvhIMlDXfHnc.zmiQJSLOuISAArGdgdjGJoKMUfgA(updateLoop);
				}
				epxwZUYuMarftiCRscRElCfGOCOb.UpdateDevices(updateLoop);
			}
			JcPvzNsGAPQjFyGkzbgvFlDSCJTxA();
			if (epxwZUYuMarftiCRscRElCfGOCOb != null)
			{
				epxwZUYuMarftiCRscRElCfGOCOb.UpdateFinished();
				for (int j = 0; j < nWcwHFXtMhmhBTQzNMqWTkaMSiJW; j++)
				{
					fgMmQusetIMkehVLSiOfGXmSBOGE[j]?.JVJbbWbERbkYDSuLMvhIMlDXfHnc.LZNaDNvDzUOQcNPUpSnaFWtEMWuS();
				}
			}
		}
		_ = LwtlvnrJqHLwebGVxcVAYiVMpraG;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (fgMmQusetIMkehVLSiOfGXmSBOGE != null)
		{
			int count = fgMmQusetIMkehVLSiOfGXmSBOGE.Count;
			for (int i = 0; i < count; i++)
			{
				if (fgMmQusetIMkehVLSiOfGXmSBOGE[i] != null)
				{
					fgMmQusetIMkehVLSiOfGXmSBOGE[i].JVJbbWbERbkYDSuLMvhIMlDXfHnc?.yerluDzWOsCgVuPEeKcMvMFftDGo();
				}
			}
		}
		if (epxwZUYuMarftiCRscRElCfGOCOb != null)
		{
			epxwZUYuMarftiCRscRElCfGOCOb.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return malDUvJOGuENSlzQzTBtQUkBWUCq;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!HeolXJWJgBNREJirdUrZvncgagPK)
		{
			return;
		}
		for (int i = 0; i < nWcwHFXtMhmhBTQzNMqWTkaMSiJW; i++)
		{
			if (fgMmQusetIMkehVLSiOfGXmSBOGE[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
			{
				fgMmQusetIMkehVLSiOfGXmSBOGE[i].FillData(data);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		if (HeolXJWJgBNREJirdUrZvncgagPK)
		{
			qoUdaZUUOFdrRaiElkuwtOwNongCA = true;
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		if (HeolXJWJgBNREJirdUrZvncgagPK)
		{
			qoUdaZUUOFdrRaiElkuwtOwNongCA = true;
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = HeolXJWJgBNREJirdUrZvncgagPK;
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

	private void EocDqlJsXudRnzYEiPKYsxlHgONn()
	{
		alxISTfsoqgXgMaoNIjNfugNrvCNA(FRfhqUPBChWYpLGJMgyKBjzcpzdG());
	}

	private void alxISTfsoqgXgMaoNIjNfugNrvCNA(IList<yTxKLgtyFntzrmhxUvcIusyQEikI> P_0)
	{
		int num = 0;
		List<mqQXAszjWSSXueXWOWdqChjPgnqX> list = fgMmQusetIMkehVLSiOfGXmSBOGE;
		int num2 = nWcwHFXtMhmhBTQzNMqWTkaMSiJW;
		fgMmQusetIMkehVLSiOfGXmSBOGE = new List<mqQXAszjWSSXueXWOWdqChjPgnqX>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				yTxKLgtyFntzrmhxUvcIusyQEikI yTxKLgtyFntzrmhxUvcIusyQEikI2 = P_0[i];
				mqQXAszjWSSXueXWOWdqChjPgnqX mqQXAszjWSSXueXWOWdqChjPgnqX2 = new mqQXAszjWSSXueXWOWdqChjPgnqX(sVGaLNqLFWKbnaewBDtBbwABAaqF);
				mqQXAszjWSSXueXWOWdqChjPgnqX2.JVJbbWbERbkYDSuLMvhIMlDXfHnc = yTxKLgtyFntzrmhxUvcIusyQEikI2;
				mqQXAszjWSSXueXWOWdqChjPgnqX2.nmvsZOwTgDkKddntTMQIVAsyWqNe = yTxKLgtyFntzrmhxUvcIusyQEikI2.RlfuyNbvhriYtEwIihgOABHwzqAW;
				mqQXAszjWSSXueXWOWdqChjPgnqX2.KhRrpVVjNukgxUiyfDizBRKCRslX = yTxKLgtyFntzrmhxUvcIusyQEikI2.mGOmHPnmiQYYAZsBYWlCTmvUcSHi;
				mqQXAszjWSSXueXWOWdqChjPgnqX2.zsONreLgxbVuscVCjvmKsksAZpAO = yTxKLgtyFntzrmhxUvcIusyQEikI2.hWHvOzevrpNMXTdKpONPiwZuNinH;
				mqQXAszjWSSXueXWOWdqChjPgnqX2.OgAZaKAVBfWLvieffNCaWIvVwPgL = yTxKLgtyFntzrmhxUvcIusyQEikI2.fMZrOOEFDXGwImnWFZzNoxiBocwP;
				mqQXAszjWSSXueXWOWdqChjPgnqX2.DlwrLlPIeHjHSeMmCzGntdZFmBou = yTxKLgtyFntzrmhxUvcIusyQEikI2.PVVtSKQhjnhVybGOrORLdsrwTAqp;
				mqQXAszjWSSXueXWOWdqChjPgnqX2.GDznsxTwCFeQoorloXNNQgvxAyYU = yTxKLgtyFntzrmhxUvcIusyQEikI2.qBKfoJLxwScxGibTFWmeWouGLfKX;
				mqQXAszjWSSXueXWOWdqChjPgnqX2.XPLzjNDlsoBNrdVRSlSuhejYEdGO = yTxKLgtyFntzrmhxUvcIusyQEikI2.eSAILtBHoSiDxDrUFKuSzltGfcqF;
				mqQXAszjWSSXueXWOWdqChjPgnqX2.ullITPjmMDwBFSYJbDPgiOweIFvw = yTxKLgtyFntzrmhxUvcIusyQEikI2.wlEUBuyjiYQefAOEJWmETSaCBESC;
				mqQXAszjWSSXueXWOWdqChjPgnqX2.bTsWqkYXGGMsNbZQOlHZujNRgbJfA = yTxKLgtyFntzrmhxUvcIusyQEikI2.IWbOmSPeUeqlQMAgxcdXYaUbZFqw;
				mqQXAszjWSSXueXWOWdqChjPgnqX2.dYkBBveUEODNYLkNYsChOFyMZMaK = yTxKLgtyFntzrmhxUvcIusyQEikI2.iyAEqSCFgCbMlDwLCyYQNtstCKSzb;
				mqQXAszjWSSXueXWOWdqChjPgnqX2.rfwfdNFVVEhLUxyDhmUIEjWKMJoS = yTxKLgtyFntzrmhxUvcIusyQEikI2.VicKNVWvbwnZmLGOxCQBhrsnMvmw;
				mqQXAszjWSSXueXWOWdqChjPgnqX2.YLrSbPWhhhaxDgnBWhkikqpcfXZq = yTxKLgtyFntzrmhxUvcIusyQEikI2.uChLrIumYFuHZRkHowVKSBGCoFOy;
				mqQXAszjWSSXueXWOWdqChjPgnqX2.deMRbSEPbadfAIPXjtObAdrIuFAhA = yTxKLgtyFntzrmhxUvcIusyQEikI2.EkVaojaJdsQFnDXkpaqjhQuMhamBb;
				mqQXAszjWSSXueXWOWdqChjPgnqX2.ahHtmpvZLDyuRDEgapauOKSmlBec = yTxKLgtyFntzrmhxUvcIusyQEikI2.ZKiVFGanCORZIxgvKtkOAtWwRdHB;
				mqQXAszjWSSXueXWOWdqChjPgnqX2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension = yTxKLgtyFntzrmhxUvcIusyQEikI2.oZiDvEEEMWSqALrpyvAPtsURwIHt;
				yTxKLgtyFntzrmhxUvcIusyQEikI2.aunImRHNPbIxThcXninudPWCdHUqB();
				mqQXAszjWSSXueXWOWdqChjPgnqX2.ErGAymQcLxzCjuJtzBhuafYDtIyx();
				fgMmQusetIMkehVLSiOfGXmSBOGE.Add(mqQXAszjWSSXueXWOWdqChjPgnqX2);
				num++;
			}
		}
		nWcwHFXtMhmhBTQzNMqWTkaMSiJW = num;
		healiWtgcCuLsuDJBfFmhhmHskqsA(num2, num, list, fgMmQusetIMkehVLSiOfGXmSBOGE);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(fgMmQusetIMkehVLSiOfGXmSBOGE[j]));
			}
		}
		VnyFbyJoZkrWUetydGGBpAawHvWo(list, fgMmQusetIMkehVLSiOfGXmSBOGE, false);
		VnyFbyJoZkrWUetydGGBpAawHvWo(fgMmQusetIMkehVLSiOfGXmSBOGE, list, true);
	}

	private void JcPvzNsGAPQjFyGkzbgvFlDSCJTxA()
	{
		for (int i = 0; i < nWcwHFXtMhmhBTQzNMqWTkaMSiJW; i++)
		{
			fgMmQusetIMkehVLSiOfGXmSBOGE[i]?.Update();
		}
	}

	private bool jAzMaLvNLYYhRNLChXxqKfgmizln(MwhtVuoJUxjrhNamguNYJdmfgjPz P_0)
	{
		try
		{
			return P_0.rFeFkHsFUPsveNMjKcrrdHgMqBtBA();
		}
		catch
		{
			return false;
		}
	}

	private IList<yTxKLgtyFntzrmhxUvcIusyQEikI> FRfhqUPBChWYpLGJMgyKBjzcpzdG()
	{
		return epxwZUYuMarftiCRscRElCfGOCOb.GetJoysticks<yTxKLgtyFntzrmhxUvcIusyQEikI>();
	}

	private void healiWtgcCuLsuDJBfFmhhmHskqsA(int P_0, int P_1, List<mqQXAszjWSSXueXWOWdqChjPgnqX> P_2, List<mqQXAszjWSSXueXWOWdqChjPgnqX> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(mqQXAszjWSSXueXWOWdqChjPgnqX.sNdtsohgmTIYtyQUurNJnDzOtcCN);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			xUsfeolQSVWnbRJQaLFOdsWEIvOe(P_1, P_3, P_0, P_2, iqiFkxHHqpRxGibPWjHagofHWUCJA.AKwXdTceDmFOZhBfJENxeQOOKULEA.Exact);
			xUsfeolQSVWnbRJQaLFOdsWEIvOe(P_1, P_3, P_0, P_2, iqiFkxHHqpRxGibPWjHagofHWUCJA.AKwXdTceDmFOZhBfJENxeQOOKULEA.Approximate);
		}
		YNDeniheJRgQYgMxcKUdkFPPQKNKB(P_1, P_3, iqiFkxHHqpRxGibPWjHagofHWUCJA.AKwXdTceDmFOZhBfJENxeQOOKULEA.Exact);
		YNDeniheJRgQYgMxcKUdkFPPQKNKB(P_1, P_3, iqiFkxHHqpRxGibPWjHagofHWUCJA.AKwXdTceDmFOZhBfJENxeQOOKULEA.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			mqQXAszjWSSXueXWOWdqChjPgnqX mqQXAszjWSSXueXWOWdqChjPgnqX2 = P_3[i];
			if (mqQXAszjWSSXueXWOWdqChjPgnqX2 != null && mqQXAszjWSSXueXWOWdqChjPgnqX2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				mqQXAszjWSSXueXWOWdqChjPgnqX2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = AEXKgsLLgqAWeJoIqiyeNtfVonUJ(P_3);
				mqQXAszjWSSXueXWOWdqChjPgnqX2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = iYkVhLYbEwIPKnDeZAESByfDPhDfA();
				TNvdUgGQcOMkOVTaFGEowfwcISHR.athBPVytqKFJkfnugIpYLFoYfTMP(mqQXAszjWSSXueXWOWdqChjPgnqX2);
			}
		}
		P_3.Sort(mqQXAszjWSSXueXWOWdqChjPgnqX.NPRNYyNoitXkMfCsMjlFLfCFFXoN);
	}

	private void LwVPDWcgyQEHnPtqaNonCbqokEcJ(List<mqQXAszjWSSXueXWOWdqChjPgnqX> P_0, int P_1, int P_2)
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

	private bool mkrkliimJmBCYnNKnHaoWAphEoPJ(List<mqQXAszjWSSXueXWOWdqChjPgnqX> P_0, int P_1)
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

	private int AEXKgsLLgqAWeJoIqiyeNtfVonUJ(List<mqQXAszjWSSXueXWOWdqChjPgnqX> P_0)
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

	private bool RiBMsHCrXZiCNOykuITNmxTpIzVU(List<mqQXAszjWSSXueXWOWdqChjPgnqX> P_0, int P_1)
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

	private void xUsfeolQSVWnbRJQaLFOdsWEIvOe(int P_0, List<mqQXAszjWSSXueXWOWdqChjPgnqX> P_1, int P_2, List<mqQXAszjWSSXueXWOWdqChjPgnqX> P_3, iqiFkxHHqpRxGibPWjHagofHWUCJA.AKwXdTceDmFOZhBfJENxeQOOKULEA P_4)
	{
		int num = ((P_4 != iqiFkxHHqpRxGibPWjHagofHWUCJA.AKwXdTceDmFOZhBfJENxeQOOKULEA.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			mqQXAszjWSSXueXWOWdqChjPgnqX mqQXAszjWSSXueXWOWdqChjPgnqX2 = P_1[i];
			if (mqQXAszjWSSXueXWOWdqChjPgnqX2 == null || mqQXAszjWSSXueXWOWdqChjPgnqX2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				mqQXAszjWSSXueXWOWdqChjPgnqX mqQXAszjWSSXueXWOWdqChjPgnqX3 = P_3[j];
				if (mqQXAszjWSSXueXWOWdqChjPgnqX3 != null && !RiBMsHCrXZiCNOykuITNmxTpIzVU(P_1, mqQXAszjWSSXueXWOWdqChjPgnqX3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && mqQXAszjWSSXueXWOWdqChjPgnqX2.CrBgOzITQMmaiSTmTDbwFrLKjaUN(mqQXAszjWSSXueXWOWdqChjPgnqX3) >= num)
				{
					mqQXAszjWSSXueXWOWdqChjPgnqX2.sPOmBZHXFfMrqbeJtTfcilZCZsmy(mqQXAszjWSSXueXWOWdqChjPgnqX3);
					TNvdUgGQcOMkOVTaFGEowfwcISHR.athBPVytqKFJkfnugIpYLFoYfTMP(mqQXAszjWSSXueXWOWdqChjPgnqX2);
				}
			}
		}
	}

	private void YNDeniheJRgQYgMxcKUdkFPPQKNKB(int P_0, List<mqQXAszjWSSXueXWOWdqChjPgnqX> P_1, iqiFkxHHqpRxGibPWjHagofHWUCJA.AKwXdTceDmFOZhBfJENxeQOOKULEA P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			mqQXAszjWSSXueXWOWdqChjPgnqX mqQXAszjWSSXueXWOWdqChjPgnqX2 = P_1[i];
			if (mqQXAszjWSSXueXWOWdqChjPgnqX2 == null || mqQXAszjWSSXueXWOWdqChjPgnqX2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			iqiFkxHHqpRxGibPWjHagofHWUCJA.HmBvFQuRiyoypFOdBrTAOpTEDXJC hmBvFQuRiyoypFOdBrTAOpTEDXJC = null;
			foreach (iqiFkxHHqpRxGibPWjHagofHWUCJA.HmBvFQuRiyoypFOdBrTAOpTEDXJC item in TNvdUgGQcOMkOVTaFGEowfwcISHR.GsZcnQjSRezFaedeYRYtaOwiGLoH(mqQXAszjWSSXueXWOWdqChjPgnqX2, P_2))
			{
				if (!RiBMsHCrXZiCNOykuITNmxTpIzVU(P_1, item.lgkePeyJhfJYBtScevqTwNKLxIlt) && item.KFDwrUJLrAiLIxWoQjqFoBKpIoeIA >= 0)
				{
					hmBvFQuRiyoypFOdBrTAOpTEDXJC = item;
					break;
				}
			}
			if (hmBvFQuRiyoypFOdBrTAOpTEDXJC != null)
			{
				int num = hmBvFQuRiyoypFOdBrTAOpTEDXJC.KFDwrUJLrAiLIxWoQjqFoBKpIoeIA;
				if (!mkrkliimJmBCYnNKnHaoWAphEoPJ(P_1, num))
				{
					num = (hmBvFQuRiyoypFOdBrTAOpTEDXJC.KFDwrUJLrAiLIxWoQjqFoBKpIoeIA = AEXKgsLLgqAWeJoIqiyeNtfVonUJ(P_1));
				}
				mqQXAszjWSSXueXWOWdqChjPgnqX2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				mqQXAszjWSSXueXWOWdqChjPgnqX2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = hmBvFQuRiyoypFOdBrTAOpTEDXJC.lgkePeyJhfJYBtScevqTwNKLxIlt;
				TNvdUgGQcOMkOVTaFGEowfwcISHR.athBPVytqKFJkfnugIpYLFoYfTMP(mqQXAszjWSSXueXWOWdqChjPgnqX2);
			}
		}
	}

	private void vyqWnoRCGpkDgnDdjPUxthPFLhQk()
	{
		IList<yTxKLgtyFntzrmhxUvcIusyQEikI> list = FRfhqUPBChWYpLGJMgyKBjzcpzdG();
		alxISTfsoqgXgMaoNIjNfugNrvCNA(list);
		qoUdaZUUOFdrRaiElkuwtOwNongCA = false;
	}

	private bool IVrwQJjkzvTqVzYHiMYVeUEOlWCP(IList<yTxKLgtyFntzrmhxUvcIusyQEikI> P_0)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && !qGTbfSsYaizZovtSGZfJmmJJxnAg(P_0[i].RlfuyNbvhriYtEwIihgOABHwzqAW))
			{
				return true;
			}
		}
		int count2 = fgMmQusetIMkehVLSiOfGXmSBOGE.Count;
		for (int j = 0; j < count2; j++)
		{
			if (fgMmQusetIMkehVLSiOfGXmSBOGE[j] != null && !FbeEVCAbcqEKSdBuxZxKJgYvEfdTA(P_0, fgMmQusetIMkehVLSiOfGXmSBOGE[j].nmvsZOwTgDkKddntTMQIVAsyWqNe))
			{
				return true;
			}
		}
		return false;
	}

	private bool qGTbfSsYaizZovtSGZfJmmJJxnAg(Guid P_0)
	{
		int count = fgMmQusetIMkehVLSiOfGXmSBOGE.Count;
		for (int i = 0; i < count; i++)
		{
			if (fgMmQusetIMkehVLSiOfGXmSBOGE[i] != null && fgMmQusetIMkehVLSiOfGXmSBOGE[i].nmvsZOwTgDkKddntTMQIVAsyWqNe == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool FbeEVCAbcqEKSdBuxZxKJgYvEfdTA(IList<yTxKLgtyFntzrmhxUvcIusyQEikI> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].RlfuyNbvhriYtEwIihgOABHwzqAW == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void VnyFbyJoZkrWUetydGGBpAawHvWo(List<mqQXAszjWSSXueXWOWdqChjPgnqX> P_0, List<mqQXAszjWSSXueXWOWdqChjPgnqX> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			mqQXAszjWSSXueXWOWdqChjPgnqX mqQXAszjWSSXueXWOWdqChjPgnqX2 = P_0[i];
			if (mqQXAszjWSSXueXWOWdqChjPgnqX2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					mqQXAszjWSSXueXWOWdqChjPgnqX mqQXAszjWSSXueXWOWdqChjPgnqX3 = P_1[j];
					if (mqQXAszjWSSXueXWOWdqChjPgnqX3 != null && mqQXAszjWSSXueXWOWdqChjPgnqX2.nmvsZOwTgDkKddntTMQIVAsyWqNe == mqQXAszjWSSXueXWOWdqChjPgnqX3.nmvsZOwTgDkKddntTMQIVAsyWqNe)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				kcrKZbnxYZufrwdCGSlvAmPmVUDP(P_0[i], P_2);
			}
		}
	}

	private void kcrKZbnxYZufrwdCGSlvAmPmVUDP(mqQXAszjWSSXueXWOWdqChjPgnqX P_0, bool P_1)
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

	private void YciWUyfCEvdqFNXigIzwjFTWZVBG()
	{
		if (HeolXJWJgBNREJirdUrZvncgagPK)
		{
			qoUdaZUUOFdrRaiElkuwtOwNongCA = true;
		}
		SystemDeviceConnected();
	}
}
