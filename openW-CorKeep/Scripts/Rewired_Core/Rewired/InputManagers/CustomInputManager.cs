using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Platforms.Custom;
using Rewired.Utils;

namespace Rewired.InputManagers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class CustomInputManager : PlatformInputManager
	{
		private class tKmyBCUFDGAskupVEaLDgYMLJBCEA : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName
		{
			private readonly InputSource VIlMdumdXpMnlEbWJGhBsVVHhCUe;

			private readonly CustomInputSource JqYEkNdVwMkYyWtObLTLCOHUqeUR;

			private readonly Controller.Extension gRIiNdMFQKgkJtQcVYHccmoxBbQV;

			private int AIaeRaPeYaWUdsZDMPRtYIlPEXnaA;

			private int oZdhWKFQeMFriTxgIkhXfgXuOzrm;

			private long? kViryqqWweorEPCjyeTXyhIPZkfV;

			private int MXOGrUtFEkGHCsHduuGYdwysctRI;

			public Guid glKeYeVHlEUGSNCneAjIYXUVLpiN;

			public string FyqhoikKLPdNLGHAEIKVQIVglDXX;

			public string StAjuHfExFDmNGmgloeKbTmjXmNGb;

			private int rLypBphtooJWQpgHBEEQEQuFJqDg;

			private int XtyflDXKCPeZWDeWmKgExoBjjbalA;

			private float[] hDEChTLNbXxaiXBjOfNgiPdJVaVI;

			private bool[] cQaIwvzMGGgQdGpRdtCiwzhOJDXB;

			private float[] aAXHxAeOBbkmOCbSfbpaWVtIVPCQB;

			private bool[] mSvOGeoKYoAwWgaZOhFIIPTFLSqUB;

			private HardwareJoystickMap_InputManager fZIQeGVSoaLGbjhYGERckyjaUoXG;

			public CustomInputSource.Joystick FEuCgyBlqeQSzhJdqebWFVRyxarc;

			private bool GxoMqyBolTMdoWmJmUIKnJCRqhBi;

			private readonly bool MVOoWQraORrQdHXflbrScjOeNiPR;

			private readonly LocalizedString qjoFrdkEKgmwHSWahoFKognMtQCm;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> yndZozjWGfsDiBcwSwdCRmAUnnxl;

			public int MGdvHaDTOVQQecABjAKNvJgAGMJX
			{
				get
				{
					if (FEuCgyBlqeQSzhJdqebWFVRyxarc == null)
					{
						return 0;
					}
					return FEuCgyBlqeQSzhJdqebWFVRyxarc.buttonCount;
				}
			}

			public int ASBTkCnvigqVTCqxqPWRLHoyoEzg
			{
				get
				{
					if (FEuCgyBlqeQSzhJdqebWFVRyxarc == null)
					{
						return 0;
					}
					return FEuCgyBlqeQSzhJdqebWFVRyxarc.axisCount;
				}
			}

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.rewiredId
			{
				get
				{
					return AIaeRaPeYaWUdsZDMPRtYIlPEXnaA;
				}
				set
				{
					AIaeRaPeYaWUdsZDMPRtYIlPEXnaA = value;
				}
			}

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.inputManagerId
			{
				get
				{
					return oZdhWKFQeMFriTxgIkhXfgXuOzrm;
				}
				set
				{
					oZdhWKFQeMFriTxgIkhXfgXuOzrm = value;
				}
			}

			[CustomObfuscation(rename = false)]
			string IInputManagerJoystickPublic.name
			{
				get
				{
					string text = ((!string.IsNullOrEmpty(FEuCgyBlqeQSzhJdqebWFVRyxarc.customName)) ? FEuCgyBlqeQSzhJdqebWFVRyxarc.customName : FyqhoikKLPdNLGHAEIKVQIVglDXX);
					if (text == "Unknown Controller")
					{
						text = StAjuHfExFDmNGmgloeKbTmjXmNGb;
					}
					return text;
				}
			}

			[CustomObfuscation(rename = false)]
			long? IInputManagerJoystickPublic.systemId => kViryqqWweorEPCjyeTXyhIPZkfV;

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.unityId => MXOGrUtFEkGHCsHduuGYdwysctRI;

			[CustomObfuscation(rename = false)]
			Guid IInputManagerJoystickPublic.instanceGuid
			{
				get
				{
					if (!kViryqqWweorEPCjyeTXyhIPZkfV.HasValue)
					{
						return Guid.Empty;
					}
					return MiscTools.CreateGuidHashSHA1(Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename + "_" + kViryqqWweorEPCjyeTXyhIPZkfV);
				}
			}

			[CustomObfuscation(rename = false)]
			Guid IInputManagerJoystickPublic.persistentGuid
			{
				get
				{
					if (!(FEuCgyBlqeQSzhJdqebWFVRyxarc.deviceInstanceGuid != Guid.Empty))
					{
						return Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
					}
					return FEuCgyBlqeQSzhJdqebWFVRyxarc.deviceInstanceGuid;
				}
			}

			[CustomObfuscation(rename = false)]
			Controller.Extension IInputManagerJoystickPublic.extension => gRIiNdMFQKgkJtQcVYHccmoxBbQV;

			[CustomObfuscation(rename = false)]
			public void SetVibration(float amount, int motorIndex)
			{
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

			public tKmyBCUFDGAskupVEaLDgYMLJBCEA(CustomInputSource P_0, long? P_1, int P_2, CustomInputSource.Joystick P_3, InputSource P_4, Controller.Extension P_5, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_6)
			{
				MVOoWQraORrQdHXflbrScjOeNiPR = P_0.bLnaYaOcwMGBBAKowoyPgsxgfIRHB == InputSource.PS4 || P_0.bLnaYaOcwMGBBAKowoyPgsxgfIRHB == InputSource.PS5;
				qjoFrdkEKgmwHSWahoFKognMtQCm = new LocalizedString();
				JqYEkNdVwMkYyWtObLTLCOHUqeUR = P_0;
				VIlMdumdXpMnlEbWJGhBsVVHhCUe = P_4;
				kViryqqWweorEPCjyeTXyhIPZkfV = P_1;
				FEuCgyBlqeQSzhJdqebWFVRyxarc = P_3;
				MXOGrUtFEkGHCsHduuGYdwysctRI = P_2;
				gRIiNdMFQKgkJtQcVYHccmoxBbQV = P_5;
				yndZozjWGfsDiBcwSwdCRmAUnnxl = P_6;
				oZdhWKFQeMFriTxgIkhXfgXuOzrm = -1;
				AIaeRaPeYaWUdsZDMPRtYIlPEXnaA = -1;
				xUVAjfBzPCxQsKZRCApNeJeOCCZj();
				CWhWoIlOvWGuOWpnWdNztkWzoOcG();
				glKeYeVHlEUGSNCneAjIYXUVLpiN = fZIQeGVSoaLGbjhYGERckyjaUoXG.hardwareMapIdentifier.guid;
				FyqhoikKLPdNLGHAEIKVQIVglDXX = fZIQeGVSoaLGbjhYGERckyjaUoXG.controllerName;
				hDEChTLNbXxaiXBjOfNgiPdJVaVI = new float[rLypBphtooJWQpgHBEEQEQuFJqDg];
				cQaIwvzMGGgQdGpRdtCiwzhOJDXB = new bool[XtyflDXKCPeZWDeWmKgExoBjjbalA];
				aAXHxAeOBbkmOCbSfbpaWVtIVPCQB = new float[XtyflDXKCPeZWDeWmKgExoBjjbalA];
				mSvOGeoKYoAwWgaZOhFIIPTFLSqUB = new bool[XtyflDXKCPeZWDeWmKgExoBjjbalA];
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)fZIQeGVSoaLGbjhYGERckyjaUoXG.map).Buttons;
				if (buttons != null)
				{
					int num = MathTools.Min(buttons.Length, XtyflDXKCPeZWDeWmKgExoBjjbalA);
					for (int i = 0; i < num; i++)
					{
						if (buttons[i] != null && buttons[i].buttonInfo != null)
						{
							mSvOGeoKYoAwWgaZOhFIIPTFLSqUB[i] = buttons[i].buttonInfo.isPressureSensitive;
						}
					}
				}
				Update();
			}

			public void xUVAjfBzPCxQsKZRCApNeJeOCCZj()
			{
				StAjuHfExFDmNGmgloeKbTmjXmNGb = FEuCgyBlqeQSzhJdqebWFVRyxarc.deviceName;
			}

			[CustomObfuscation(rename = false)]
			public void Update()
			{
				if (FEuCgyBlqeQSzhJdqebWFVRyxarc.isConnected)
				{
					mJdfzbbPaHYXSDRjNNzKaTAZucbr();
					hHxCVoArmskcVgrJxqqScnOAuMOib();
				}
			}

			void IInputManagerJoystick.Update()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Update
				this.Update();
			}

			public int aPvxawEmuhgINEAxSAPLGWkfoZkjb(tKmyBCUFDGAskupVEaLDgYMLJBCEA P_0)
			{
				if (P_0.StAjuHfExFDmNGmgloeKbTmjXmNGb == StAjuHfExFDmNGmgloeKbTmjXmNGb && P_0.kViryqqWweorEPCjyeTXyhIPZkfV == kViryqqWweorEPCjyeTXyhIPZkfV)
				{
					return 2;
				}
				if (P_0.StAjuHfExFDmNGmgloeKbTmjXmNGb == StAjuHfExFDmNGmgloeKbTmjXmNGb)
				{
					return 1;
				}
				return 0;
			}

			private void RwyPuvXADVJnbccZpnGIeLjhaQaI(BridgedControllerHWInfo P_0)
			{
				P_0.inputManagerSource = VIlMdumdXpMnlEbWJGhBsVVHhCUe;
				P_0.inputSource = VIlMdumdXpMnlEbWJGhBsVVHhCUe;
				P_0.hardwareIdentifier = tiBIKsEFuVKgHUfKrQSoZdWyeIMe();
				P_0.hardwareAxisCount = rLypBphtooJWQpgHBEEQEQuFJqDg;
				P_0.hardwareButtonCount = XtyflDXKCPeZWDeWmKgExoBjjbalA;
				P_0.hardwareHatCount = 0;
				P_0.hw_productName = StAjuHfExFDmNGmgloeKbTmjXmNGb;
				P_0.hw_supportsVibration = FEuCgyBlqeQSzhJdqebWFVRyxarc.supportsVibration;
				P_0.userCustomIdentifier = FEuCgyBlqeQSzhJdqebWFVRyxarc.customIdentifier;
			}

			private void WLfuqnTGnDsNhZFCNbKgDQmpdojx(BridgedController P_0)
			{
				RwyPuvXADVJnbccZpnGIeLjhaQaI(P_0);
				P_0.sourceJoystick = this;
				P_0.gameHardwareMap = fZIQeGVSoaLGbjhYGERckyjaUoXG.ToGameHardwareControllerMap();
				P_0.instanceName = StAjuHfExFDmNGmgloeKbTmjXmNGb;
				P_0.productName = StAjuHfExFDmNGmgloeKbTmjXmNGb;
				P_0.isXInputDevice = false;
				P_0.axisCount = rLypBphtooJWQpgHBEEQEQuFJqDg;
				P_0.buttonCount = XtyflDXKCPeZWDeWmKgExoBjjbalA;
				P_0.controllerTypeGuid = glKeYeVHlEUGSNCneAjIYXUVLpiN;
				P_0.customInputSource = JqYEkNdVwMkYyWtObLTLCOHUqeUR;
				P_0.controllerExtension = gRIiNdMFQKgkJtQcVYHccmoxBbQV;
				P_0.isButtonPressureSensitive = new bool[mSvOGeoKYoAwWgaZOhFIIPTFLSqUB.Length];
				for (int i = 0; i < mSvOGeoKYoAwWgaZOhFIIPTFLSqUB.Length; i++)
				{
					P_0.isButtonPressureSensitive[i] = mSvOGeoKYoAwWgaZOhFIIPTFLSqUB[i];
				}
			}

			[CustomObfuscation(rename = false)]
			public void FillData(ControllerDataUpdater dataUpdater)
			{
				if (rLypBphtooJWQpgHBEEQEQuFJqDg != dataUpdater.axisCount || XtyflDXKCPeZWDeWmKgExoBjjbalA != dataUpdater.buttonCount)
				{
					throw new Exception("This controller signature does not match the data object!");
				}
				for (int i = 0; i < rLypBphtooJWQpgHBEEQEQuFJqDg; i++)
				{
					dataUpdater.axisValues[i] = hDEChTLNbXxaiXBjOfNgiPdJVaVI[i];
				}
				for (int j = 0; j < XtyflDXKCPeZWDeWmKgExoBjjbalA; j++)
				{
					if (mSvOGeoKYoAwWgaZOhFIIPTFLSqUB[j])
					{
						dataUpdater.buttonPressureValues[j] = aAXHxAeOBbkmOCbSfbpaWVtIVPCQB[j];
					}
					dataUpdater.buttonValues[j] = cQaIwvzMGGgQdGpRdtCiwzhOJDXB[j];
				}
				if (GxoMqyBolTMdoWmJmUIKnJCRqhBi && !dataUpdater.hasReceivedInput)
				{
					dataUpdater.hasReceivedInput = true;
				}
			}

			void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
			{
				//ILSpy generated this explicit interface implementation from .override directive in FillData
				this.FillData(dataUpdater);
			}

			public BridgedControllerHWInfo MUtUjMvClkDOtItmAYzUmfHLdBvHb()
			{
				BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
				RwyPuvXADVJnbccZpnGIeLjhaQaI(bridgedControllerHWInfo);
				return bridgedControllerHWInfo;
			}

			[CustomObfuscation(rename = false)]
			public BridgedController ToBridgedController()
			{
				BridgedController bridgedController = new BridgedController();
				WLfuqnTGnDsNhZFCNbKgDQmpdojx(bridgedController);
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
				return new ControllerDisconnectedEventArgs(AIaeRaPeYaWUdsZDMPRtYIlPEXnaA);
			}

			ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
				return this.ToControllerDisconnectedEventArgs();
			}

			private void mJdfzbbPaHYXSDRjNNzKaTAZucbr()
			{
				HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)fZIQeGVSoaLGbjhYGERckyjaUoXG.map).Axes;
				if (axes == null)
				{
					return;
				}
				for (int i = 0; i < axes.Length; i++)
				{
					if (axes[i] != null)
					{
						if (i >= rLypBphtooJWQpgHBEEQEQuFJqDg)
						{
							throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
						}
						hDEChTLNbXxaiXBjOfNgiPdJVaVI[i] = gqndInqMiZHLDbywtkVGztVKFCdd(axes[i]);
						if (!GxoMqyBolTMdoWmJmUIKnJCRqhBi && hDEChTLNbXxaiXBjOfNgiPdJVaVI[i] != 0f)
						{
							GxoMqyBolTMdoWmJmUIKnJCRqhBi = true;
						}
					}
				}
			}

			private void hHxCVoArmskcVgrJxqqScnOAuMOib()
			{
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)fZIQeGVSoaLGbjhYGERckyjaUoXG.map).Buttons;
				if (buttons == null)
				{
					return;
				}
				for (int i = 0; i < buttons.Length; i++)
				{
					if (i >= XtyflDXKCPeZWDeWmKgExoBjjbalA)
					{
						throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
					}
					cQaIwvzMGGgQdGpRdtCiwzhOJDXB[i] = HiyxxGOfUuBeIpUIXQsJlLeYpptD(buttons[i], out aAXHxAeOBbkmOCbSfbpaWVtIVPCQB[i]);
					if (!GxoMqyBolTMdoWmJmUIKnJCRqhBi && (cQaIwvzMGGgQdGpRdtCiwzhOJDXB[i] || (mSvOGeoKYoAwWgaZOhFIIPTFLSqUB[i] && aAXHxAeOBbkmOCbSfbpaWVtIVPCQB[i] != 0f)))
					{
						GxoMqyBolTMdoWmJmUIKnJCRqhBi = true;
					}
				}
			}

			private bool HiyxxGOfUuBeIpUIXQsJlLeYpptD(HardwareJoystickMap.Platform_Custom.Button P_0, out float P_1)
			{
				if (P_0.sourceType == 0)
				{
					bool result = iUezcSqCIdhtkiEhYnfaxrVwofMh(P_0.sourceButton, out P_1);
					if (MathTools.Abs(P_1) <= P_0.axisDeadZone)
					{
						P_1 = 0f;
					}
					return result;
				}
				if (P_0.sourceType == 1)
				{
					P_1 = 0f;
					float num = AYmGkOsXSYGpxUXMMwrSmsWUQchN(P_0.sourceAxis);
					if (MathTools.Abs(num) <= P_0.axisDeadZone)
					{
						return false;
					}
					if (P_0.sourceAxisPole == Pole.Positive && num < 0f)
					{
						return false;
					}
					if (P_0.sourceAxisPole == Pole.Negative && num > 0f)
					{
						return false;
					}
					if (num < 0f)
					{
						num *= -1f;
					}
					if (num > 1f)
					{
						num = 1f;
					}
					P_1 = num;
					return true;
				}
				P_1 = 0f;
				return false;
			}

			private bool ThbOZAglTgyhllIeGDpZeyiTHLZC(float P_0, float P_1)
			{
				return MathTools.IsNear(P_1, P_0, 0.1f);
			}

			private float gqndInqMiZHLDbywtkVGztVKFCdd(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				if (P_0.sourceType == 1)
				{
					return AYmGkOsXSYGpxUXMMwrSmsWUQchN(P_0.sourceAxis);
				}
				if (P_0.sourceType == 0)
				{
					if (!iUezcSqCIdhtkiEhYnfaxrVwofMh(P_0.sourceButton, out var _))
					{
						return 0f;
					}
					if (P_0.buttonAxisContribution == Pole.Positive)
					{
						return 1f;
					}
					return -1f;
				}
				throw new NotImplementedException();
			}

			private float AYmGkOsXSYGpxUXMMwrSmsWUQchN(int P_0)
			{
				return FEuCgyBlqeQSzhJdqebWFVRyxarc.GetAxisValue(P_0);
			}

			private bool iUezcSqCIdhtkiEhYnfaxrVwofMh(int P_0, out float P_1)
			{
				FEuCgyBlqeQSzhJdqebWFVRyxarc.anJpKhKcqGVLJivUEsqvvkloyCCK(P_0, out var result, out P_1);
				return result;
			}

			private void CWhWoIlOvWGuOWpnWdNztkWzoOcG()
			{
				fZIQeGVSoaLGbjhYGERckyjaUoXG = yndZozjWGfsDiBcwSwdCRmAUnnxl(MUtUjMvClkDOtItmAYzUmfHLdBvHb());
				if (fZIQeGVSoaLGbjhYGERckyjaUoXG == null)
				{
					Logger.LogError("Default hardware map not found!");
					return;
				}
				if (FEuCgyBlqeQSzhJdqebWFVRyxarc is IInputManagerHardwareJoystickMapHandler)
				{
					try
					{
						((IInputManagerHardwareJoystickMapHandler)FEuCgyBlqeQSzhJdqebWFVRyxarc).InitializeHardwareJoystickMap(fZIQeGVSoaLGbjhYGERckyjaUoXG);
					}
					catch
					{
					}
				}
				rLypBphtooJWQpgHBEEQEQuFJqDg = fZIQeGVSoaLGbjhYGERckyjaUoXG.axisCount;
				XtyflDXKCPeZWDeWmKgExoBjjbalA = fZIQeGVSoaLGbjhYGERckyjaUoXG.buttonCount;
			}

			private void mrnrezrOVsjeldBizanKtCIJfeUJ()
			{
				Array.Clear(cQaIwvzMGGgQdGpRdtCiwzhOJDXB, 0, cQaIwvzMGGgQdGpRdtCiwzhOJDXB.Length);
				Array.Clear(aAXHxAeOBbkmOCbSfbpaWVtIVPCQB, 0, aAXHxAeOBbkmOCbSfbpaWVtIVPCQB.Length);
				Array.Clear(hDEChTLNbXxaiXBjOfNgiPdJVaVI, 0, hDEChTLNbXxaiXBjOfNgiPdJVaVI.Length);
			}

			private string tiBIKsEFuVKgHUfKrQSoZdWyeIMe()
			{
				if (ReInput.currentPlatform == Platform.Webplayer)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{VIlMdumdXpMnlEbWJGhBsVVHhCUe.ToString()}{StAjuHfExFDmNGmgloeKbTmjXmNGb}");
				}
				if (mtomRtgTRNntCRDCGTAlowoDhPZo.BxgHUpymmvRaFbsNhjtTNtpbaJviA)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{mtomRtgTRNntCRDCGTAlowoDhPZo.IuwQjqroVfRyluGOIAArtKvpEzDfA()}{StAjuHfExFDmNGmgloeKbTmjXmNGb}");
				}
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{VIlMdumdXpMnlEbWJGhBsVVHhCUe.ToString()}{StAjuHfExFDmNGmgloeKbTmjXmNGb}");
			}

			bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
			{
				if (!(FEuCgyBlqeQSzhJdqebWFVRyxarc is ITryGetLocalizedName))
				{
					if (MVOoWQraORrQdHXflbrScjOeNiPR)
					{
						if ((LocalizationManager.GetAndUpdateLocalizedString(qjoFrdkEKgmwHSWahoFKognMtQCm, fZIQeGVSoaLGbjhYGERckyjaUoXG.deviceLocalizationInfo.parentKeys, "controller", Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename, out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
						{
							string text = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename;
							string text2 = null;
							MatchCollection matchCollection = Regex.Matches(text, "^(.*) ([0-9]+)$");
							if (matchCollection.Count > 0 && matchCollection[0].Groups != null && matchCollection[0].Groups.Count > 2)
							{
								text = matchCollection[0].Groups[1].Value;
								text2 = matchCollection[0].Groups[2].Value;
							}
							if (!string.IsNullOrEmpty(text2))
							{
								value = $"{text} {text2}";
							}
							qjoFrdkEKgmwHSWahoFKognMtQCm.cachedValue = value;
						}
						return true;
					}
					value = null;
					return false;
				}
				return ((ITryGetLocalizedName)FEuCgyBlqeQSzhJdqebWFVRyxarc).TryGetLocalizedName(out value);
			}

			public static int GnRmddLcJAdppkheNNuLoiYBhsym(tKmyBCUFDGAskupVEaLDgYMLJBCEA P_0, tKmyBCUFDGAskupVEaLDgYMLJBCEA P_1)
			{
				if (P_0.oZdhWKFQeMFriTxgIkhXfgXuOzrm < P_1.oZdhWKFQeMFriTxgIkhXfgXuOzrm)
				{
					return -1;
				}
				if (P_0.oZdhWKFQeMFriTxgIkhXfgXuOzrm > P_1.oZdhWKFQeMFriTxgIkhXfgXuOzrm)
				{
					return 1;
				}
				return 0;
			}

			public static int iadZrJBuDACIfgwNvmipROMRSoPU(tKmyBCUFDGAskupVEaLDgYMLJBCEA P_0, tKmyBCUFDGAskupVEaLDgYMLJBCEA P_1)
			{
				if (P_0.kViryqqWweorEPCjyeTXyhIPZkfV < P_1.kViryqqWweorEPCjyeTXyhIPZkfV)
				{
					return -1;
				}
				if (P_0.kViryqqWweorEPCjyeTXyhIPZkfV > P_1.kViryqqWweorEPCjyeTXyhIPZkfV)
				{
					return 1;
				}
				return 0;
			}
		}

		private class NybZEiSlsIDDXTJkvpKBQBHiIZQP
		{
			public enum gSEkcODxnJNCXNCveUUutURVNdAT
			{
				Exact = 0,
				Approximate = 1
			}

			public class pjvjNVeXMBHzvKLgYrNtOoJJfTZkA
			{
				public int TPDWuQGBpxckcBToBfYTauUGVcwZA;

				public long? ZmQFwwqNQWhaQdhKoRFPcwxKbrtE;

				public string VHSlFpgsBfvurCFBprhwaPEwTHHp;

				public int qbQEAQhqNJIPdPQCwrhssBkBlmOh;

				public int xzcPMUNFAtzMHykAjeyIeuDmbtvGb;

				public int urfGWxLAxVZrYQfjrGiDdYhiUOdrA;

				public pjvjNVeXMBHzvKLgYrNtOoJJfTZkA(int P_0, long? P_1, string P_2, int P_3, int P_4, int P_5)
				{
					TPDWuQGBpxckcBToBfYTauUGVcwZA = P_0;
					ZmQFwwqNQWhaQdhKoRFPcwxKbrtE = P_1;
					VHSlFpgsBfvurCFBprhwaPEwTHHp = P_2;
					qbQEAQhqNJIPdPQCwrhssBkBlmOh = P_3;
					xzcPMUNFAtzMHykAjeyIeuDmbtvGb = P_4;
					urfGWxLAxVZrYQfjrGiDdYhiUOdrA = P_5;
				}

				public bool HniSxEaKmbnIrDLqOkpIrOYOBrBU(tKmyBCUFDGAskupVEaLDgYMLJBCEA P_0, gSEkcODxnJNCXNCveUUutURVNdAT P_1)
				{
					if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == TPDWuQGBpxckcBToBfYTauUGVcwZA)
					{
						return true;
					}
					if (P_0.MGdvHaDTOVQQecABjAKNvJgAGMJX != xzcPMUNFAtzMHykAjeyIeuDmbtvGb)
					{
						return false;
					}
					if (P_0.ASBTkCnvigqVTCqxqPWRLHoyoEzg != urfGWxLAxVZrYQfjrGiDdYhiUOdrA)
					{
						return false;
					}
					switch (P_1)
					{
					case gSEkcODxnJNCXNCveUUutURVNdAT.Exact:
						if (ZmQFwwqNQWhaQdhKoRFPcwxKbrtE == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId)
						{
							return VHSlFpgsBfvurCFBprhwaPEwTHHp == P_0.StAjuHfExFDmNGmgloeKbTmjXmNGb;
						}
						return false;
					case gSEkcODxnJNCXNCveUUutURVNdAT.Approximate:
						return VHSlFpgsBfvurCFBprhwaPEwTHHp == P_0.StAjuHfExFDmNGmgloeKbTmjXmNGb;
					default:
						throw new NotImplementedException();
					}
				}
			}

			private sealed class kTcfnabpFCNZAxMrWGFmEOoqhmfJA : IEnumerable<pjvjNVeXMBHzvKLgYrNtOoJJfTZkA>, IEnumerable, IEnumerator<pjvjNVeXMBHzvKLgYrNtOoJJfTZkA>, IEnumerator, IDisposable
			{
				private int BStvHMVniuIecREefbBwfdhKwMqWA;

				private pjvjNVeXMBHzvKLgYrNtOoJJfTZkA VKwMbCGgzaqJJTdfScGdfrfDHRFP;

				private int mWxUePOjFtsHzZsMIWowCsDNWkae;

				public NybZEiSlsIDDXTJkvpKBQBHiIZQP YpZgTKFKgHALzCrgympoBeBOEvXxA;

				private tKmyBCUFDGAskupVEaLDgYMLJBCEA NdtJkrMnhhauKHhcFiKThtKaxRwdB;

				public tKmyBCUFDGAskupVEaLDgYMLJBCEA xDMavbfrDsSQkrCaGmoXWinrRZhD;

				private gSEkcODxnJNCXNCveUUutURVNdAT FglQlUlidAXQqlmyuAEXWgVEUzOn;

				public gSEkcODxnJNCXNCveUUutURVNdAT HsGfFBtPLDhbaeFIXNqDPPlNOnBqA;

				private int AtAbgEBwtjEbxjYvGRyPqPPvjDFaA;

				private int zmYXnOUMAIgyAmviAEQfFImXfmxXA;

				pjvjNVeXMBHzvKLgYrNtOoJJfTZkA IEnumerator<pjvjNVeXMBHzvKLgYrNtOoJJfTZkA>.Current
				{
					[DebuggerHidden]
					get
					{
						return VKwMbCGgzaqJJTdfScGdfrfDHRFP;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return VKwMbCGgzaqJJTdfScGdfrfDHRFP;
					}
				}

				[DebuggerHidden]
				public kTcfnabpFCNZAxMrWGFmEOoqhmfJA(int P_0)
				{
					BStvHMVniuIecREefbBwfdhKwMqWA = P_0;
					mWxUePOjFtsHzZsMIWowCsDNWkae = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					BStvHMVniuIecREefbBwfdhKwMqWA = -2;
				}

				private bool MoveNext()
				{
					int bStvHMVniuIecREefbBwfdhKwMqWA = BStvHMVniuIecREefbBwfdhKwMqWA;
					NybZEiSlsIDDXTJkvpKBQBHiIZQP ypZgTKFKgHALzCrgympoBeBOEvXxA = YpZgTKFKgHALzCrgympoBeBOEvXxA;
					if (bStvHMVniuIecREefbBwfdhKwMqWA != 0)
					{
						if (bStvHMVniuIecREefbBwfdhKwMqWA != 1)
						{
							return false;
						}
						BStvHMVniuIecREefbBwfdhKwMqWA = -1;
						goto IL_0083;
					}
					BStvHMVniuIecREefbBwfdhKwMqWA = -1;
					AtAbgEBwtjEbxjYvGRyPqPPvjDFaA = ypZgTKFKgHALzCrgympoBeBOEvXxA.PGHZfCSNMpXnrhLeJljPktcBZxMk.Count;
					zmYXnOUMAIgyAmviAEQfFImXfmxXA = 0;
					goto IL_0093;
					IL_0083:
					zmYXnOUMAIgyAmviAEQfFImXfmxXA++;
					goto IL_0093;
					IL_0093:
					if (zmYXnOUMAIgyAmviAEQfFImXfmxXA < AtAbgEBwtjEbxjYvGRyPqPPvjDFaA)
					{
						if (ypZgTKFKgHALzCrgympoBeBOEvXxA.PGHZfCSNMpXnrhLeJljPktcBZxMk[zmYXnOUMAIgyAmviAEQfFImXfmxXA].HniSxEaKmbnIrDLqOkpIrOYOBrBU(NdtJkrMnhhauKHhcFiKThtKaxRwdB, FglQlUlidAXQqlmyuAEXWgVEUzOn))
						{
							VKwMbCGgzaqJJTdfScGdfrfDHRFP = ypZgTKFKgHALzCrgympoBeBOEvXxA.PGHZfCSNMpXnrhLeJljPktcBZxMk[zmYXnOUMAIgyAmviAEQfFImXfmxXA];
							BStvHMVniuIecREefbBwfdhKwMqWA = 1;
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
				IEnumerator<pjvjNVeXMBHzvKLgYrNtOoJJfTZkA> IEnumerable<pjvjNVeXMBHzvKLgYrNtOoJJfTZkA>.GetEnumerator()
				{
					kTcfnabpFCNZAxMrWGFmEOoqhmfJA kTcfnabpFCNZAxMrWGFmEOoqhmfJA2;
					if (BStvHMVniuIecREefbBwfdhKwMqWA == -2 && mWxUePOjFtsHzZsMIWowCsDNWkae == Environment.CurrentManagedThreadId)
					{
						BStvHMVniuIecREefbBwfdhKwMqWA = 0;
						kTcfnabpFCNZAxMrWGFmEOoqhmfJA2 = this;
					}
					else
					{
						kTcfnabpFCNZAxMrWGFmEOoqhmfJA2 = new kTcfnabpFCNZAxMrWGFmEOoqhmfJA(0);
						kTcfnabpFCNZAxMrWGFmEOoqhmfJA2.YpZgTKFKgHALzCrgympoBeBOEvXxA = YpZgTKFKgHALzCrgympoBeBOEvXxA;
					}
					kTcfnabpFCNZAxMrWGFmEOoqhmfJA2.NdtJkrMnhhauKHhcFiKThtKaxRwdB = xDMavbfrDsSQkrCaGmoXWinrRZhD;
					kTcfnabpFCNZAxMrWGFmEOoqhmfJA2.FglQlUlidAXQqlmyuAEXWgVEUzOn = HsGfFBtPLDhbaeFIXNqDPPlNOnBqA;
					return kTcfnabpFCNZAxMrWGFmEOoqhmfJA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<pjvjNVeXMBHzvKLgYrNtOoJJfTZkA>)this).GetEnumerator();
				}
			}

			private List<pjvjNVeXMBHzvKLgYrNtOoJJfTZkA> PGHZfCSNMpXnrhLeJljPktcBZxMk;

			public int IcohutgFbWvWOeTgzBgdEdRKNiBwb => PGHZfCSNMpXnrhLeJljPktcBZxMk.Count;

			public NybZEiSlsIDDXTJkvpKBQBHiIZQP()
			{
				PGHZfCSNMpXnrhLeJljPktcBZxMk = new List<pjvjNVeXMBHzvKLgYrNtOoJJfTZkA>();
			}

			public void QGsBeBQfpGYdZumnnSLCgViGRDRl(tKmyBCUFDGAskupVEaLDgYMLJBCEA P_0)
			{
				if (P_0 == null)
				{
					return;
				}
				int count = PGHZfCSNMpXnrhLeJljPktcBZxMk.Count;
				for (int i = 0; i < count; i++)
				{
					if (PGHZfCSNMpXnrhLeJljPktcBZxMk[i].HniSxEaKmbnIrDLqOkpIrOYOBrBU(P_0, gSEkcODxnJNCXNCveUUutURVNdAT.Exact))
					{
						PGHZfCSNMpXnrhLeJljPktcBZxMk[i].TPDWuQGBpxckcBToBfYTauUGVcwZA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
						PGHZfCSNMpXnrhLeJljPktcBZxMk[i].ZmQFwwqNQWhaQdhKoRFPcwxKbrtE = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId;
						PGHZfCSNMpXnrhLeJljPktcBZxMk[i].VHSlFpgsBfvurCFBprhwaPEwTHHp = P_0.StAjuHfExFDmNGmgloeKbTmjXmNGb;
						PGHZfCSNMpXnrhLeJljPktcBZxMk[i].qbQEAQhqNJIPdPQCwrhssBkBlmOh = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
						PGHZfCSNMpXnrhLeJljPktcBZxMk[i].xzcPMUNFAtzMHykAjeyIeuDmbtvGb = P_0.MGdvHaDTOVQQecABjAKNvJgAGMJX;
						PGHZfCSNMpXnrhLeJljPktcBZxMk[i].urfGWxLAxVZrYQfjrGiDdYhiUOdrA = P_0.ASBTkCnvigqVTCqxqPWRLHoyoEzg;
						AbyFubNucElvzZrtGbzzmIrGnXNJ(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, i);
						return;
					}
				}
				PGHZfCSNMpXnrhLeJljPktcBZxMk.Add(new pjvjNVeXMBHzvKLgYrNtOoJJfTZkA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId, P_0.StAjuHfExFDmNGmgloeKbTmjXmNGb, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId, P_0.MGdvHaDTOVQQecABjAKNvJgAGMJX, P_0.ASBTkCnvigqVTCqxqPWRLHoyoEzg));
				AbyFubNucElvzZrtGbzzmIrGnXNJ(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, PGHZfCSNMpXnrhLeJljPktcBZxMk.Count - 1);
			}

			public bool dRRZjXHZDKYYyCwDSFobloXcSnRE(tKmyBCUFDGAskupVEaLDgYMLJBCEA P_0, gSEkcODxnJNCXNCveUUutURVNdAT P_1)
			{
				int count = PGHZfCSNMpXnrhLeJljPktcBZxMk.Count;
				for (int i = 0; i < count; i++)
				{
					if (PGHZfCSNMpXnrhLeJljPktcBZxMk[i].HniSxEaKmbnIrDLqOkpIrOYOBrBU(P_0, P_1))
					{
						return true;
					}
				}
				return false;
			}

			[IteratorStateMachine(typeof(kTcfnabpFCNZAxMrWGFmEOoqhmfJA))]
			public IEnumerable<pjvjNVeXMBHzvKLgYrNtOoJJfTZkA> engqtEcfvVxSjNdhATqZHTfbalEd(tKmyBCUFDGAskupVEaLDgYMLJBCEA P_0, gSEkcODxnJNCXNCveUUutURVNdAT P_1)
			{
				return new kTcfnabpFCNZAxMrWGFmEOoqhmfJA(-2)
				{
					YpZgTKFKgHALzCrgympoBeBOEvXxA = this,
					xDMavbfrDsSQkrCaGmoXWinrRZhD = P_0,
					HsGfFBtPLDhbaeFIXNqDPPlNOnBqA = P_1
				};
			}

			public int NzAdiiDHUmdTeTcmQCesTLiOIghiA(pjvjNVeXMBHzvKLgYrNtOoJJfTZkA P_0)
			{
				int count = PGHZfCSNMpXnrhLeJljPktcBZxMk.Count;
				for (int i = 0; i < count; i++)
				{
					if (PGHZfCSNMpXnrhLeJljPktcBZxMk[i] == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private void AbyFubNucElvzZrtGbzzmIrGnXNJ(int P_0, int P_1)
			{
				for (int num = PGHZfCSNMpXnrhLeJljPktcBZxMk.Count - 1; num >= 0; num--)
				{
					if (num != P_1 && PGHZfCSNMpXnrhLeJljPktcBZxMk[num].TPDWuQGBpxckcBToBfYTauUGVcwZA == P_0)
					{
						PGHZfCSNMpXnrhLeJljPktcBZxMk.RemoveAt(num);
					}
				}
			}
		}

		private List<tKmyBCUFDGAskupVEaLDgYMLJBCEA> rOmFqmNhYbZsOHzEPjtLqzDOnPco;

		private int auCPtJYCyQOaBKVeKroMXbBEIlDT;

		private NybZEiSlsIDDXTJkvpKBQBHiIZQP ByPsdZOqNWRPcmBNjLpvQiBgAHTKA;

		private UpdateLoopType nKOoVRoFxleHlwocndqlpgRfaDhIA;

		private Action<int, ControllerDataUpdater> RiRcLYVLlzwKjtTUagRRRFbIpZqJ;

		private PlatformInputManager baZCXDcyDzcPSeKxRSRPChjpfJhtA;

		private CustomInputSource vtXCmyvaPWScmpmFWADPqrlrqMFJ;

		private bool voEBInUlKjnyIXJZzYoxcdrRGXDg;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> LtIchRJpLiIKrIFcIKeghhvMNmtd;

		private Func<int> BphXarCbdBYQJgreIsmfNzeCKlmQ;

		[CustomObfuscation(rename = false)]
		int PlatformInputManager.deviceCount => auCPtJYCyQOaBKVeKroMXbBEIlDT;

		[CustomObfuscation(rename = false)]
		PlatformInputManager PlatformInputManager.primaryInputManager => baZCXDcyDzcPSeKxRSRPChjpfJhtA;

		[CustomObfuscation(rename = false)]
		IInputSource PlatformInputManager.inputSource => null;

		[CustomObfuscation(rename = false)]
		InputSource PlatformInputManager.inputSourceType => vtXCmyvaPWScmpmFWADPqrlrqMFJ.bLnaYaOcwMGBBAKowoyPgsxgfIRHB;

		public CustomInputManager(CustomInputSource P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3)
		{
			vtXCmyvaPWScmpmFWADPqrlrqMFJ = P_0;
			LtIchRJpLiIKrIFcIKeghhvMNmtd = P_2;
			BphXarCbdBYQJgreIsmfNzeCKlmQ = P_3;
			baZCXDcyDzcPSeKxRSRPChjpfJhtA = this;
			try
			{
				RiRcLYVLlzwKjtTUagRRRFbIpZqJ = UpdateControllerData;
				P_0.PEDundHsobIJDExszbKNoSPTEwBNA += SystemDeviceConnected;
				P_0.znSvNANBdcJAKYbCSGxwCPFueizkA += SystemDeviceDisconnected;
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
			ByPsdZOqNWRPcmBNjLpvQiBgAHTKA = new NybZEiSlsIDDXTJkvpKBQBHiIZQP();
			rOmFqmNhYbZsOHzEPjtLqzDOnPco = new List<tKmyBCUFDGAskupVEaLDgYMLJBCEA>();
			voEBInUlKjnyIXJZzYoxcdrRGXDg = true;
			vtXCmyvaPWScmpmFWADPqrlrqMFJ.ClXPqQHQbxEYbLGYANIBDPkrIbwHA();
		}

		[CustomObfuscation(rename = false)]
		public override void Update(UpdateLoopType updateLoop)
		{
			nKOoVRoFxleHlwocndqlpgRfaDhIA = updateLoop;
			if (vtXCmyvaPWScmpmFWADPqrlrqMFJ.isReady)
			{
				vtXCmyvaPWScmpmFWADPqrlrqMFJ.Update();
				vtXCmyvaPWScmpmFWADPqrlrqMFJ.yJJiJyHClDKYfyDcnimKwpopQEQH();
				if (voEBInUlKjnyIXJZzYoxcdrRGXDg)
				{
					utixRmOfOkrEcJEphmBxaavMtlf();
				}
				JxubTgfCMMqyawuNsxakxBZHlVjDb();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
			if (vtXCmyvaPWScmpmFWADPqrlrqMFJ != null)
			{
				vtXCmyvaPWScmpmFWADPqrlrqMFJ.Dispose();
			}
		}

		[CustomObfuscation(rename = false)]
		public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
		{
			return RiRcLYVLlzwKjtTUagRRRFbIpZqJ;
		}

		[CustomObfuscation(rename = false)]
		public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
		{
			for (int i = 0; i < auCPtJYCyQOaBKVeKroMXbBEIlDT; i++)
			{
				if (rOmFqmNhYbZsOHzEPjtLqzDOnPco[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
				{
					rOmFqmNhYbZsOHzEPjtLqzDOnPco[i].FillData(data);
					return;
				}
			}
			Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceConnected()
		{
			voEBInUlKjnyIXJZzYoxcdrRGXDg = true;
			if (_SystemDeviceConnectedEvent != null)
			{
				_SystemDeviceConnectedEvent();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceDisconnected()
		{
			voEBInUlKjnyIXJZzYoxcdrRGXDg = true;
			if (_SystemDeviceDisconnectedEvent != null)
			{
				_SystemDeviceDisconnectedEvent();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SetUnityJoystickId(int joystickId, int unityJoystickIndex)
		{
		}

		[CustomObfuscation(rename = false)]
		public override IUnifiedMouseSource GetUnifiedMouseSource()
		{
			return vtXCmyvaPWScmpmFWADPqrlrqMFJ.KNNmHhsEvsKWVztdXBolepStAmgc();
		}

		[CustomObfuscation(rename = false)]
		public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
		{
			return vtXCmyvaPWScmpmFWADPqrlrqMFJ.VfDFosXAxNHisBveamNjBMdoEblEA();
		}

		private void KDPJfvcSZrUPVitKZpYzsqHxaLMe(CustomInputSource.Joystick[] P_0)
		{
			int num = 0;
			List<tKmyBCUFDGAskupVEaLDgYMLJBCEA> list = rOmFqmNhYbZsOHzEPjtLqzDOnPco;
			int num2 = auCPtJYCyQOaBKVeKroMXbBEIlDT;
			rOmFqmNhYbZsOHzEPjtLqzDOnPco = new List<tKmyBCUFDGAskupVEaLDgYMLJBCEA>();
			for (int i = 0; i < P_0.Length; i++)
			{
				if (P_0[i] != null)
				{
					tKmyBCUFDGAskupVEaLDgYMLJBCEA item = new tKmyBCUFDGAskupVEaLDgYMLJBCEA(vtXCmyvaPWScmpmFWADPqrlrqMFJ, P_0[i].systemId, P_0[i].unityId, P_0[i], vtXCmyvaPWScmpmFWADPqrlrqMFJ.bLnaYaOcwMGBBAKowoyPgsxgfIRHB, P_0[i].extension, LtIchRJpLiIKrIFcIKeghhvMNmtd);
					rOmFqmNhYbZsOHzEPjtLqzDOnPco.Add(item);
					num++;
				}
			}
			auCPtJYCyQOaBKVeKroMXbBEIlDT = num;
			mDCgMoFBMnyWgKIAaySAIGWQUfvkA(num2, num, list, rOmFqmNhYbZsOHzEPjtLqzDOnPco);
			for (int j = 0; j < num; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(rOmFqmNhYbZsOHzEPjtLqzDOnPco[j]));
				}
			}
			PtwhMOWyJPdKfFGaejKlLOrqEzcu(list, rOmFqmNhYbZsOHzEPjtLqzDOnPco, false);
			PtwhMOWyJPdKfFGaejKlLOrqEzcu(rOmFqmNhYbZsOHzEPjtLqzDOnPco, list, true);
		}

		private void JxubTgfCMMqyawuNsxakxBZHlVjDb()
		{
			for (int i = 0; i < auCPtJYCyQOaBKVeKroMXbBEIlDT; i++)
			{
				rOmFqmNhYbZsOHzEPjtLqzDOnPco[i].Update();
			}
		}

		private void mDCgMoFBMnyWgKIAaySAIGWQUfvkA(int P_0, int P_1, List<tKmyBCUFDGAskupVEaLDgYMLJBCEA> P_2, List<tKmyBCUFDGAskupVEaLDgYMLJBCEA> P_3)
		{
			if (P_1 > 0)
			{
				P_3.Sort(tKmyBCUFDGAskupVEaLDgYMLJBCEA.iadZrJBuDACIfgwNvmipROMRSoPU);
			}
			if (P_0 > 0 && P_1 > 0)
			{
				AwXxfrslhFAjcyglYboFIJhOFAnGA(P_1, P_3, P_0, P_2, NybZEiSlsIDDXTJkvpKBQBHiIZQP.gSEkcODxnJNCXNCveUUutURVNdAT.Exact);
				if (vtXCmyvaPWScmpmFWADPqrlrqMFJ.useApproximateMatching)
				{
					AwXxfrslhFAjcyglYboFIJhOFAnGA(P_1, P_3, P_0, P_2, NybZEiSlsIDDXTJkvpKBQBHiIZQP.gSEkcODxnJNCXNCveUUutURVNdAT.Approximate);
				}
			}
			jdUVXijOQSgWCnPHFMvFgaoxcyim(P_1, P_3, NybZEiSlsIDDXTJkvpKBQBHiIZQP.gSEkcODxnJNCXNCveUUutURVNdAT.Exact);
			if (vtXCmyvaPWScmpmFWADPqrlrqMFJ.useApproximateMatching)
			{
				jdUVXijOQSgWCnPHFMvFgaoxcyim(P_1, P_3, NybZEiSlsIDDXTJkvpKBQBHiIZQP.gSEkcODxnJNCXNCveUUutURVNdAT.Approximate);
			}
			for (int i = 0; i < P_1; i++)
			{
				tKmyBCUFDGAskupVEaLDgYMLJBCEA tKmyBCUFDGAskupVEaLDgYMLJBCEA2 = P_3[i];
				if (tKmyBCUFDGAskupVEaLDgYMLJBCEA2 != null && tKmyBCUFDGAskupVEaLDgYMLJBCEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
				{
					tKmyBCUFDGAskupVEaLDgYMLJBCEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = qHTgMdhnfDIsZSGrsuJMEREDBlqJ(P_3);
					tKmyBCUFDGAskupVEaLDgYMLJBCEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ReInput.GetNewJoystickId();
					ByPsdZOqNWRPcmBNjLpvQiBgAHTKA.QGsBeBQfpGYdZumnnSLCgViGRDRl(tKmyBCUFDGAskupVEaLDgYMLJBCEA2);
				}
			}
			P_3.Sort(tKmyBCUFDGAskupVEaLDgYMLJBCEA.GnRmddLcJAdppkheNNuLoiYBhsym);
		}

		private void pAHSCfvmeZurhuxUHlTpIdbHdNREA(List<tKmyBCUFDGAskupVEaLDgYMLJBCEA> P_0, int P_1, int P_2)
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

		private bool rAHRvGjbHEOIPPDdCZPzhMjXOuEM(List<tKmyBCUFDGAskupVEaLDgYMLJBCEA> P_0, int P_1)
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

		private int qHTgMdhnfDIsZSGrsuJMEREDBlqJ(List<tKmyBCUFDGAskupVEaLDgYMLJBCEA> P_0)
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

		private bool ngrwmhXlAMFBSpDlVagBdWKmalhGA(List<tKmyBCUFDGAskupVEaLDgYMLJBCEA> P_0, int P_1)
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

		private void AwXxfrslhFAjcyglYboFIJhOFAnGA(int P_0, List<tKmyBCUFDGAskupVEaLDgYMLJBCEA> P_1, int P_2, List<tKmyBCUFDGAskupVEaLDgYMLJBCEA> P_3, NybZEiSlsIDDXTJkvpKBQBHiIZQP.gSEkcODxnJNCXNCveUUutURVNdAT P_4)
		{
			int num = ((P_4 != NybZEiSlsIDDXTJkvpKBQBHiIZQP.gSEkcODxnJNCXNCveUUutURVNdAT.Exact) ? 1 : 2);
			for (int i = 0; i < P_0; i++)
			{
				tKmyBCUFDGAskupVEaLDgYMLJBCEA tKmyBCUFDGAskupVEaLDgYMLJBCEA2 = P_1[i];
				if (tKmyBCUFDGAskupVEaLDgYMLJBCEA2 == null || tKmyBCUFDGAskupVEaLDgYMLJBCEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
				{
					continue;
				}
				for (int j = 0; j < P_2; j++)
				{
					tKmyBCUFDGAskupVEaLDgYMLJBCEA tKmyBCUFDGAskupVEaLDgYMLJBCEA3 = P_3[j];
					if (tKmyBCUFDGAskupVEaLDgYMLJBCEA3 != null && !ngrwmhXlAMFBSpDlVagBdWKmalhGA(P_1, tKmyBCUFDGAskupVEaLDgYMLJBCEA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && tKmyBCUFDGAskupVEaLDgYMLJBCEA2.aPvxawEmuhgINEAxSAPLGWkfoZkjb(tKmyBCUFDGAskupVEaLDgYMLJBCEA3) >= num)
					{
						tKmyBCUFDGAskupVEaLDgYMLJBCEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = tKmyBCUFDGAskupVEaLDgYMLJBCEA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
						tKmyBCUFDGAskupVEaLDgYMLJBCEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = tKmyBCUFDGAskupVEaLDgYMLJBCEA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
						ByPsdZOqNWRPcmBNjLpvQiBgAHTKA.QGsBeBQfpGYdZumnnSLCgViGRDRl(tKmyBCUFDGAskupVEaLDgYMLJBCEA2);
					}
				}
			}
		}

		private void jdUVXijOQSgWCnPHFMvFgaoxcyim(int P_0, List<tKmyBCUFDGAskupVEaLDgYMLJBCEA> P_1, NybZEiSlsIDDXTJkvpKBQBHiIZQP.gSEkcODxnJNCXNCveUUutURVNdAT P_2)
		{
			for (int i = 0; i < P_0; i++)
			{
				tKmyBCUFDGAskupVEaLDgYMLJBCEA tKmyBCUFDGAskupVEaLDgYMLJBCEA2 = P_1[i];
				if (tKmyBCUFDGAskupVEaLDgYMLJBCEA2 == null || tKmyBCUFDGAskupVEaLDgYMLJBCEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
				{
					continue;
				}
				NybZEiSlsIDDXTJkvpKBQBHiIZQP.pjvjNVeXMBHzvKLgYrNtOoJJfTZkA pjvjNVeXMBHzvKLgYrNtOoJJfTZkA = null;
				foreach (NybZEiSlsIDDXTJkvpKBQBHiIZQP.pjvjNVeXMBHzvKLgYrNtOoJJfTZkA item in ByPsdZOqNWRPcmBNjLpvQiBgAHTKA.engqtEcfvVxSjNdhATqZHTfbalEd(tKmyBCUFDGAskupVEaLDgYMLJBCEA2, P_2))
				{
					if (!ngrwmhXlAMFBSpDlVagBdWKmalhGA(P_1, item.TPDWuQGBpxckcBToBfYTauUGVcwZA) && item.qbQEAQhqNJIPdPQCwrhssBkBlmOh >= 0)
					{
						pjvjNVeXMBHzvKLgYrNtOoJJfTZkA = item;
						break;
					}
				}
				if (pjvjNVeXMBHzvKLgYrNtOoJJfTZkA != null)
				{
					int num = pjvjNVeXMBHzvKLgYrNtOoJJfTZkA.qbQEAQhqNJIPdPQCwrhssBkBlmOh;
					if (!rAHRvGjbHEOIPPDdCZPzhMjXOuEM(P_1, num))
					{
						num = (pjvjNVeXMBHzvKLgYrNtOoJJfTZkA.qbQEAQhqNJIPdPQCwrhssBkBlmOh = qHTgMdhnfDIsZSGrsuJMEREDBlqJ(P_1));
					}
					tKmyBCUFDGAskupVEaLDgYMLJBCEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
					tKmyBCUFDGAskupVEaLDgYMLJBCEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = pjvjNVeXMBHzvKLgYrNtOoJJfTZkA.TPDWuQGBpxckcBToBfYTauUGVcwZA;
					ByPsdZOqNWRPcmBNjLpvQiBgAHTKA.QGsBeBQfpGYdZumnnSLCgViGRDRl(tKmyBCUFDGAskupVEaLDgYMLJBCEA2);
				}
			}
		}

		private void utixRmOfOkrEcJEphmBxaavMtlf()
		{
			CustomInputSource.Joystick[] array = vtXCmyvaPWScmpmFWADPqrlrqMFJ.TCVGTCmshWaexcHsYzLeunIqYgwIA();
			if (VDmZbOdoTorXGnJbagZTbSAiRKSU(array))
			{
				KDPJfvcSZrUPVitKZpYzsqHxaLMe(array);
			}
			voEBInUlKjnyIXJZzYoxcdrRGXDg = false;
		}

		private bool VDmZbOdoTorXGnJbagZTbSAiRKSU(CustomInputSource.Joystick[] P_0)
		{
			int num = P_0.Length;
			int count = rOmFqmNhYbZsOHzEPjtLqzDOnPco.Count;
			if (num != count)
			{
				return true;
			}
			for (int i = 0; i < num; i++)
			{
				if (P_0[i] == null)
				{
					continue;
				}
				long? systemId = P_0[i].systemId;
				bool flag = false;
				for (int j = 0; j < count; j++)
				{
					if (rOmFqmNhYbZsOHzEPjtLqzDOnPco[j] != null && systemId == rOmFqmNhYbZsOHzEPjtLqzDOnPco[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return true;
				}
			}
			for (int k = 0; k < count; k++)
			{
				if (rOmFqmNhYbZsOHzEPjtLqzDOnPco[k] == null)
				{
					continue;
				}
				long? num2 = rOmFqmNhYbZsOHzEPjtLqzDOnPco[k].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId;
				bool flag2 = false;
				for (int l = 0; l < num; l++)
				{
					if (P_0[l] != null && num2 == P_0[l].systemId)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					return true;
				}
			}
			return false;
		}

		private void PtwhMOWyJPdKfFGaejKlLOrqEzcu(List<tKmyBCUFDGAskupVEaLDgYMLJBCEA> P_0, List<tKmyBCUFDGAskupVEaLDgYMLJBCEA> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				return;
			}
			int num = P_0?.Count ?? 0;
			int num2 = P_1?.Count ?? 0;
			for (int i = 0; i < num; i++)
			{
				tKmyBCUFDGAskupVEaLDgYMLJBCEA tKmyBCUFDGAskupVEaLDgYMLJBCEA2 = P_0[i];
				if (tKmyBCUFDGAskupVEaLDgYMLJBCEA2 == null)
				{
					continue;
				}
				bool flag = false;
				if (P_1 != null)
				{
					for (int j = 0; j < num2; j++)
					{
						tKmyBCUFDGAskupVEaLDgYMLJBCEA tKmyBCUFDGAskupVEaLDgYMLJBCEA3 = P_1[j];
						if (tKmyBCUFDGAskupVEaLDgYMLJBCEA3 != null && tKmyBCUFDGAskupVEaLDgYMLJBCEA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == tKmyBCUFDGAskupVEaLDgYMLJBCEA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					uuCGGZIdvrOfXRRsFFHOFDKQDcsS(P_0[i], P_2);
				}
			}
		}

		private void uuCGGZIdvrOfXRRsFFHOFDKQDcsS(tKmyBCUFDGAskupVEaLDgYMLJBCEA P_0, bool P_1)
		{
			if (P_1)
			{
				P_0.xUVAjfBzPCxQsKZRCApNeJeOCCZj();
			}
			IhCqHBeeheBLlEMjpfuVcZNfUDBYB(P_0, P_1);
		}

		private void IhCqHBeeheBLlEMjpfuVcZNfUDBYB(tKmyBCUFDGAskupVEaLDgYMLJBCEA P_0, bool P_1)
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
}
