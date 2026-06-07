using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
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
		private class aXKdbsJagcDNmCLkhMgrMqUCuHJN : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName
		{
			private readonly InputSource JNMBmPSsDBEFBkOLyoQWUaGjLnyvA;

			private readonly CustomInputSource MoLAgKKKHrYfylPGQUulAQPlyoYt;

			private readonly Controller.Extension OFqIbfCUNqUzQiOnvNfKvZuUmZBo;

			private int AWDPTZahSurPaRegJCJbfSjbLABDA;

			private int DBqwflQuDhjOwzNeyukXHgJnkOfY;

			private long? ClpbIocOfjuVFcRPCslxGKsbMgGS;

			private int XnxPMcDVeYJBWHnXiEncxXfStLbv;

			public Guid SRIKvGKsUVvKdhMhLSwDFQSDInVe;

			public string QywcrZJIAFFVkJlPRKocGLzgQsvr;

			public string sbnXECOsTgfoWczdRvgPHKbvVbFz;

			private int MXkNViMtSkCXhVAqsNOXkqgyAXmH;

			private int JUTanEOVBHbwVHQHKsAHkvZOyxmj;

			private float[] YfLoKOFOHkBmsDeLrJINqoJgfdBs;

			private bool[] iBbGdzIuvxfCvxbSBnLZfvrWDwZPA;

			private float[] hEafeccIgxXSKmhVbGlfTKKLxIeJA;

			private bool[] JUGCYelCcmfgNwrgXeARCvVduNTHA;

			private HardwareJoystickMap_InputManager AWCbIECppuLDtCThiwONsElGeIEub;

			public CustomInputSource.Joystick hkTaypAGfkgcsLVpgqHPzctIrHcNA;

			private bool KOCtFDDOIabeTGjesaCmoXILgaNrA;

			private readonly bool hzBjfDyniAbKwpbDGKxVClvjNCCl;

			private readonly LocalizedString pBHGSdiKqWIcVIxiLTzkoXwKRJelA;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> kKluBaSojOoBlftxKOIOxwWJcxHk;

			public int zqbnhwKOcKeCZgUaPhMsNMpJqrwSA
			{
				get
				{
					if (hkTaypAGfkgcsLVpgqHPzctIrHcNA == null)
					{
						return 0;
					}
					return hkTaypAGfkgcsLVpgqHPzctIrHcNA.buttonCount;
				}
			}

			public int msArXGKyTuNvjcoAJyFcezvJxamf
			{
				get
				{
					if (hkTaypAGfkgcsLVpgqHPzctIrHcNA == null)
					{
						return 0;
					}
					return hkTaypAGfkgcsLVpgqHPzctIrHcNA.axisCount;
				}
			}

			[CustomObfuscation(rename = false)]
			public int rewiredId
			{
				get
				{
					return AWDPTZahSurPaRegJCJbfSjbLABDA;
				}
				set
				{
					AWDPTZahSurPaRegJCJbfSjbLABDA = value;
				}
			}

			[CustomObfuscation(rename = false)]
			public int inputManagerId
			{
				get
				{
					return DBqwflQuDhjOwzNeyukXHgJnkOfY;
				}
				set
				{
					DBqwflQuDhjOwzNeyukXHgJnkOfY = value;
				}
			}

			[CustomObfuscation(rename = false)]
			public string name
			{
				get
				{
					string text = ((!string.IsNullOrEmpty(hkTaypAGfkgcsLVpgqHPzctIrHcNA.customName)) ? hkTaypAGfkgcsLVpgqHPzctIrHcNA.customName : QywcrZJIAFFVkJlPRKocGLzgQsvr);
					if (text == "Unknown Controller")
					{
						text = sbnXECOsTgfoWczdRvgPHKbvVbFz;
					}
					return text;
				}
			}

			[CustomObfuscation(rename = false)]
			public long? systemId => ClpbIocOfjuVFcRPCslxGKsbMgGS;

			[CustomObfuscation(rename = false)]
			public int unityId => XnxPMcDVeYJBWHnXiEncxXfStLbv;

			[CustomObfuscation(rename = false)]
			public Guid instanceGuid
			{
				get
				{
					if (!ClpbIocOfjuVFcRPCslxGKsbMgGS.HasValue)
					{
						return Guid.Empty;
					}
					return MiscTools.CreateGuidHashSHA1(name + "_" + ClpbIocOfjuVFcRPCslxGKsbMgGS);
				}
			}

			[CustomObfuscation(rename = false)]
			public Guid persistentGuid
			{
				get
				{
					if (!(hkTaypAGfkgcsLVpgqHPzctIrHcNA.deviceInstanceGuid != Guid.Empty))
					{
						return instanceGuid;
					}
					return hkTaypAGfkgcsLVpgqHPzctIrHcNA.deviceInstanceGuid;
				}
			}

			[CustomObfuscation(rename = false)]
			public Controller.Extension extension => OFqIbfCUNqUzQiOnvNfKvZuUmZBo;

			[CustomObfuscation(rename = false)]
			public void SetVibration(float amount, int motorIndex)
			{
			}

			[CustomObfuscation(rename = false)]
			public void StopVibration()
			{
			}

			public aXKdbsJagcDNmCLkhMgrMqUCuHJN(CustomInputSource P_0, long? P_1, int P_2, CustomInputSource.Joystick P_3, InputSource P_4, Controller.Extension P_5, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_6)
			{
				hzBjfDyniAbKwpbDGKxVClvjNCCl = P_0.JNMBmPSsDBEFBkOLyoQWUaGjLnyvA == InputSource.PS4 || P_0.JNMBmPSsDBEFBkOLyoQWUaGjLnyvA == InputSource.PS5;
				pBHGSdiKqWIcVIxiLTzkoXwKRJelA = new LocalizedString();
				MoLAgKKKHrYfylPGQUulAQPlyoYt = P_0;
				JNMBmPSsDBEFBkOLyoQWUaGjLnyvA = P_4;
				ClpbIocOfjuVFcRPCslxGKsbMgGS = P_1;
				hkTaypAGfkgcsLVpgqHPzctIrHcNA = P_3;
				XnxPMcDVeYJBWHnXiEncxXfStLbv = P_2;
				OFqIbfCUNqUzQiOnvNfKvZuUmZBo = P_5;
				kKluBaSojOoBlftxKOIOxwWJcxHk = P_6;
				DBqwflQuDhjOwzNeyukXHgJnkOfY = -1;
				AWDPTZahSurPaRegJCJbfSjbLABDA = -1;
				AKBthARIICiQKchrlioKjuzGiShgA();
				QUChOlDwNBGjhwrZDvEmAwZUZaZWA();
				SRIKvGKsUVvKdhMhLSwDFQSDInVe = AWCbIECppuLDtCThiwONsElGeIEub.hardwareMapIdentifier.guid;
				QywcrZJIAFFVkJlPRKocGLzgQsvr = AWCbIECppuLDtCThiwONsElGeIEub.controllerName;
				YfLoKOFOHkBmsDeLrJINqoJgfdBs = new float[MXkNViMtSkCXhVAqsNOXkqgyAXmH];
				iBbGdzIuvxfCvxbSBnLZfvrWDwZPA = new bool[JUTanEOVBHbwVHQHKsAHkvZOyxmj];
				hEafeccIgxXSKmhVbGlfTKKLxIeJA = new float[JUTanEOVBHbwVHQHKsAHkvZOyxmj];
				JUGCYelCcmfgNwrgXeARCvVduNTHA = new bool[JUTanEOVBHbwVHQHKsAHkvZOyxmj];
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)AWCbIECppuLDtCThiwONsElGeIEub.map).Buttons;
				if (buttons != null)
				{
					int num = MathTools.Min(buttons.Length, JUTanEOVBHbwVHQHKsAHkvZOyxmj);
					for (int i = 0; i < num; i++)
					{
						if (buttons[i] != null && buttons[i].buttonInfo != null)
						{
							JUGCYelCcmfgNwrgXeARCvVduNTHA[i] = buttons[i].buttonInfo.isPressureSensitive;
						}
					}
				}
				Update();
			}

			public void AKBthARIICiQKchrlioKjuzGiShgA()
			{
				sbnXECOsTgfoWczdRvgPHKbvVbFz = hkTaypAGfkgcsLVpgqHPzctIrHcNA.deviceName;
			}

			[CustomObfuscation(rename = false)]
			public void Update()
			{
				if (hkTaypAGfkgcsLVpgqHPzctIrHcNA.isConnected)
				{
					FJVWeNzOMPCUZWnjHQjGXusGLrqs();
					eVhPgKUIwZyGaTlvvzdxWzILOpns();
				}
			}

			public int TUibHCXgdJpNwgxVPYRazOMZLYAI(aXKdbsJagcDNmCLkhMgrMqUCuHJN P_0)
			{
				if (P_0.sbnXECOsTgfoWczdRvgPHKbvVbFz == sbnXECOsTgfoWczdRvgPHKbvVbFz && P_0.ClpbIocOfjuVFcRPCslxGKsbMgGS == ClpbIocOfjuVFcRPCslxGKsbMgGS)
				{
					return 2;
				}
				if (P_0.sbnXECOsTgfoWczdRvgPHKbvVbFz == sbnXECOsTgfoWczdRvgPHKbvVbFz)
				{
					return 1;
				}
				return 0;
			}

			private void zdHnvQFaOLYLcQqdXRgyYLSDYaNB(BridgedControllerHWInfo P_0)
			{
				P_0.inputManagerSource = JNMBmPSsDBEFBkOLyoQWUaGjLnyvA;
				P_0.inputSource = JNMBmPSsDBEFBkOLyoQWUaGjLnyvA;
				P_0.hardwareIdentifier = OFTaxqRnIObDkzwyLzlCIkEhFxYg();
				P_0.hardwareAxisCount = MXkNViMtSkCXhVAqsNOXkqgyAXmH;
				P_0.hardwareButtonCount = JUTanEOVBHbwVHQHKsAHkvZOyxmj;
				P_0.hardwareHatCount = 0;
				P_0.hw_productName = sbnXECOsTgfoWczdRvgPHKbvVbFz;
				P_0.hw_supportsVibration = hkTaypAGfkgcsLVpgqHPzctIrHcNA.supportsVibration;
				P_0.userCustomIdentifier = hkTaypAGfkgcsLVpgqHPzctIrHcNA.customIdentifier;
			}

			private void zdHnvQFaOLYLcQqdXRgyYLSDYaNB(BridgedController P_0)
			{
				zdHnvQFaOLYLcQqdXRgyYLSDYaNB((BridgedControllerHWInfo)P_0);
				P_0.sourceJoystick = this;
				P_0.gameHardwareMap = AWCbIECppuLDtCThiwONsElGeIEub.ToGameHardwareControllerMap();
				P_0.instanceName = sbnXECOsTgfoWczdRvgPHKbvVbFz;
				P_0.productName = sbnXECOsTgfoWczdRvgPHKbvVbFz;
				P_0.isXInputDevice = false;
				P_0.axisCount = MXkNViMtSkCXhVAqsNOXkqgyAXmH;
				P_0.buttonCount = JUTanEOVBHbwVHQHKsAHkvZOyxmj;
				P_0.controllerTypeGuid = SRIKvGKsUVvKdhMhLSwDFQSDInVe;
				P_0.customInputSource = MoLAgKKKHrYfylPGQUulAQPlyoYt;
				P_0.controllerExtension = OFqIbfCUNqUzQiOnvNfKvZuUmZBo;
				P_0.isButtonPressureSensitive = new bool[JUGCYelCcmfgNwrgXeARCvVduNTHA.Length];
				for (int i = 0; i < JUGCYelCcmfgNwrgXeARCvVduNTHA.Length; i++)
				{
					P_0.isButtonPressureSensitive[i] = JUGCYelCcmfgNwrgXeARCvVduNTHA[i];
				}
			}

			[CustomObfuscation(rename = false)]
			public void FillData(ControllerDataUpdater dataUpdater)
			{
				if (MXkNViMtSkCXhVAqsNOXkqgyAXmH != dataUpdater.axisCount || JUTanEOVBHbwVHQHKsAHkvZOyxmj != dataUpdater.buttonCount)
				{
					throw new Exception("This controller signature does not match the data object!");
				}
				for (int i = 0; i < MXkNViMtSkCXhVAqsNOXkqgyAXmH; i++)
				{
					dataUpdater.axisValues[i] = YfLoKOFOHkBmsDeLrJINqoJgfdBs[i];
				}
				for (int j = 0; j < JUTanEOVBHbwVHQHKsAHkvZOyxmj; j++)
				{
					if (JUGCYelCcmfgNwrgXeARCvVduNTHA[j])
					{
						dataUpdater.buttonPressureValues[j] = hEafeccIgxXSKmhVbGlfTKKLxIeJA[j];
					}
					dataUpdater.buttonValues[j] = iBbGdzIuvxfCvxbSBnLZfvrWDwZPA[j];
				}
				if (KOCtFDDOIabeTGjesaCmoXILgaNrA && !dataUpdater.hasReceivedInput)
				{
					dataUpdater.hasReceivedInput = true;
				}
			}

			public BridgedControllerHWInfo CbTPOuTrRpsQMrnAdeZCLmbrivjbA()
			{
				BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
				zdHnvQFaOLYLcQqdXRgyYLSDYaNB(bridgedControllerHWInfo);
				return bridgedControllerHWInfo;
			}

			[CustomObfuscation(rename = false)]
			public BridgedController ToBridgedController()
			{
				BridgedController bridgedController = new BridgedController();
				zdHnvQFaOLYLcQqdXRgyYLSDYaNB(bridgedController);
				return bridgedController;
			}

			[CustomObfuscation(rename = false)]
			public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
			{
				return new ControllerDisconnectedEventArgs(AWDPTZahSurPaRegJCJbfSjbLABDA);
			}

			private void FJVWeNzOMPCUZWnjHQjGXusGLrqs()
			{
				HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)AWCbIECppuLDtCThiwONsElGeIEub.map).Axes;
				if (axes == null)
				{
					return;
				}
				for (int i = 0; i < axes.Length; i++)
				{
					if (axes[i] != null)
					{
						if (i >= MXkNViMtSkCXhVAqsNOXkqgyAXmH)
						{
							throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
						}
						YfLoKOFOHkBmsDeLrJINqoJgfdBs[i] = HzIOlHJRYcDpORuJITPEIKgEEJzIA(axes[i]);
						if (!KOCtFDDOIabeTGjesaCmoXILgaNrA && YfLoKOFOHkBmsDeLrJINqoJgfdBs[i] != 0f)
						{
							KOCtFDDOIabeTGjesaCmoXILgaNrA = true;
						}
					}
				}
			}

			private void eVhPgKUIwZyGaTlvvzdxWzILOpns()
			{
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)AWCbIECppuLDtCThiwONsElGeIEub.map).Buttons;
				if (buttons == null)
				{
					return;
				}
				for (int i = 0; i < buttons.Length; i++)
				{
					if (i >= JUTanEOVBHbwVHQHKsAHkvZOyxmj)
					{
						throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
					}
					iBbGdzIuvxfCvxbSBnLZfvrWDwZPA[i] = raLPokxvYPjAARjYkxPNzamygBsx(buttons[i], out hEafeccIgxXSKmhVbGlfTKKLxIeJA[i]);
					if (!KOCtFDDOIabeTGjesaCmoXILgaNrA && (iBbGdzIuvxfCvxbSBnLZfvrWDwZPA[i] || (JUGCYelCcmfgNwrgXeARCvVduNTHA[i] && hEafeccIgxXSKmhVbGlfTKKLxIeJA[i] != 0f)))
					{
						KOCtFDDOIabeTGjesaCmoXILgaNrA = true;
					}
				}
			}

			private bool raLPokxvYPjAARjYkxPNzamygBsx(HardwareJoystickMap.Platform_Custom.Button P_0, out float P_1)
			{
				if (P_0.sourceType == 0)
				{
					bool result = raLPokxvYPjAARjYkxPNzamygBsx(P_0.sourceButton, out P_1);
					if (MathTools.Abs(P_1) <= P_0.axisDeadZone)
					{
						P_1 = 0f;
					}
					return result;
				}
				if (P_0.sourceType == 1)
				{
					P_1 = 0f;
					float num = HzIOlHJRYcDpORuJITPEIKgEEJzIA(P_0.sourceAxis);
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

			private bool YGXszIhcyyRtmpKCztmpojcNFoXdA(float P_0, float P_1)
			{
				return MathTools.IsNear(P_1, P_0, 0.1f);
			}

			private float HzIOlHJRYcDpORuJITPEIKgEEJzIA(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				if (P_0.sourceType == 1)
				{
					return HzIOlHJRYcDpORuJITPEIKgEEJzIA(P_0.sourceAxis);
				}
				if (P_0.sourceType == 0)
				{
					if (!raLPokxvYPjAARjYkxPNzamygBsx(P_0.sourceButton, out var _))
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

			private float HzIOlHJRYcDpORuJITPEIKgEEJzIA(int P_0)
			{
				return hkTaypAGfkgcsLVpgqHPzctIrHcNA.GetAxisValue(P_0);
			}

			private bool raLPokxvYPjAARjYkxPNzamygBsx(int P_0, out float P_1)
			{
				hkTaypAGfkgcsLVpgqHPzctIrHcNA.FsGdhSEhMGjXNdbYItAJZWIAjGZkb(P_0, out var result, out P_1);
				return result;
			}

			private void QUChOlDwNBGjhwrZDvEmAwZUZaZWA()
			{
				AWCbIECppuLDtCThiwONsElGeIEub = kKluBaSojOoBlftxKOIOxwWJcxHk(CbTPOuTrRpsQMrnAdeZCLmbrivjbA());
				if (AWCbIECppuLDtCThiwONsElGeIEub == null)
				{
					Logger.LogError("Default hardware map not found!");
					return;
				}
				if (hkTaypAGfkgcsLVpgqHPzctIrHcNA is IInputManagerHardwareJoystickMapHandler)
				{
					try
					{
						((IInputManagerHardwareJoystickMapHandler)hkTaypAGfkgcsLVpgqHPzctIrHcNA).InitializeHardwareJoystickMap(AWCbIECppuLDtCThiwONsElGeIEub);
					}
					catch
					{
					}
				}
				MXkNViMtSkCXhVAqsNOXkqgyAXmH = AWCbIECppuLDtCThiwONsElGeIEub.axisCount;
				JUTanEOVBHbwVHQHKsAHkvZOyxmj = AWCbIECppuLDtCThiwONsElGeIEub.buttonCount;
			}

			private void csDwaLbbpqniYeCtbmAvRaFuJHyd()
			{
				Array.Clear(iBbGdzIuvxfCvxbSBnLZfvrWDwZPA, 0, iBbGdzIuvxfCvxbSBnLZfvrWDwZPA.Length);
				Array.Clear(hEafeccIgxXSKmhVbGlfTKKLxIeJA, 0, hEafeccIgxXSKmhVbGlfTKKLxIeJA.Length);
				Array.Clear(YfLoKOFOHkBmsDeLrJINqoJgfdBs, 0, YfLoKOFOHkBmsDeLrJINqoJgfdBs.Length);
			}

			private string OFTaxqRnIObDkzwyLzlCIkEhFxYg()
			{
				if (ReInput.currentPlatform == Platform.Webplayer)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{JNMBmPSsDBEFBkOLyoQWUaGjLnyvA.ToString()}{sbnXECOsTgfoWczdRvgPHKbvVbFz}");
				}
				if (xfQMULbDolNOSljfhItZwOwIzFQO.SYETLKcbFhUFoZVjYnuOpkJSSgOW)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{xfQMULbDolNOSljfhItZwOwIzFQO.EbPnojGmSIdVpxOuBCKNjblcKeje()}{sbnXECOsTgfoWczdRvgPHKbvVbFz}");
				}
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{JNMBmPSsDBEFBkOLyoQWUaGjLnyvA.ToString()}{sbnXECOsTgfoWczdRvgPHKbvVbFz}");
			}

			private bool DxHoDPNzMdHYSxVnpKKUgghuWmEP(out string P_0)
			{
				if (!(hkTaypAGfkgcsLVpgqHPzctIrHcNA is ITryGetLocalizedName))
				{
					if (hzBjfDyniAbKwpbDGKxVClvjNCCl)
					{
						if ((LocalizationManager.GetAndUpdateLocalizedString(pBHGSdiKqWIcVIxiLTzkoXwKRJelA, AWCbIECppuLDtCThiwONsElGeIEub.deviceLocalizationInfo.parentKeys, "controller", name, out P_0) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
						{
							string value = name;
							string text = null;
							MatchCollection matchCollection = Regex.Matches(value, "^(.*) ([0-9]+)$");
							if (matchCollection.Count > 0 && matchCollection[0].Groups != null && matchCollection[0].Groups.Count > 2)
							{
								value = matchCollection[0].Groups[1].Value;
								text = matchCollection[0].Groups[2].Value;
							}
							if (!string.IsNullOrEmpty(text))
							{
								P_0 = $"{value} {text}";
							}
							pBHGSdiKqWIcVIxiLTzkoXwKRJelA.cachedValue = P_0;
						}
						return true;
					}
					P_0 = null;
					return false;
				}
				return ((ITryGetLocalizedName)hkTaypAGfkgcsLVpgqHPzctIrHcNA).TryGetLocalizedName(out P_0);
			}

			bool ITryGetLocalizedName.TryGetLocalizedName(out string P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in DxHoDPNzMdHYSxVnpKKUgghuWmEP
				return this.DxHoDPNzMdHYSxVnpKKUgghuWmEP(out P_0);
			}

			public static int bysvDFWAHFIftaGNXVmikMUoHVvnA(aXKdbsJagcDNmCLkhMgrMqUCuHJN P_0, aXKdbsJagcDNmCLkhMgrMqUCuHJN P_1)
			{
				if (P_0.DBqwflQuDhjOwzNeyukXHgJnkOfY < P_1.DBqwflQuDhjOwzNeyukXHgJnkOfY)
				{
					return -1;
				}
				if (P_0.DBqwflQuDhjOwzNeyukXHgJnkOfY > P_1.DBqwflQuDhjOwzNeyukXHgJnkOfY)
				{
					return 1;
				}
				return 0;
			}

			public static int GrgeiHJAqlWYynnWJHqdnuLSZvLTA(aXKdbsJagcDNmCLkhMgrMqUCuHJN P_0, aXKdbsJagcDNmCLkhMgrMqUCuHJN P_1)
			{
				if (P_0.ClpbIocOfjuVFcRPCslxGKsbMgGS < P_1.ClpbIocOfjuVFcRPCslxGKsbMgGS)
				{
					return -1;
				}
				if (P_0.ClpbIocOfjuVFcRPCslxGKsbMgGS > P_1.ClpbIocOfjuVFcRPCslxGKsbMgGS)
				{
					return 1;
				}
				return 0;
			}
		}

		private class EOJKsOPTVawkLfhDWWStUrLbBrNg
		{
			public enum vXgKbwMqQfAfXrTWJEdMppXWEhVm
			{
				Exact = 0,
				Approximate = 1
			}

			public class cTVgOhlLrtfEtksLbqqZlCTIJVSqA
			{
				public int PoDKkXNZKOoZdyxGaKFAmJnBpZjC;

				public long? vvRHmUUDQhTCXXeKvDFsZOiWCoigA;

				public string JDXbjCEHJBBbpZUnyLpKiAJcbjjdb;

				public int LDliaNeAUqfNlGOOcEgvxJDercVuA;

				public int JUTanEOVBHbwVHQHKsAHkvZOyxmj;

				public int MXkNViMtSkCXhVAqsNOXkqgyAXmH;

				public cTVgOhlLrtfEtksLbqqZlCTIJVSqA(int P_0, long? P_1, string P_2, int P_3, int P_4, int P_5)
				{
					PoDKkXNZKOoZdyxGaKFAmJnBpZjC = P_0;
					vvRHmUUDQhTCXXeKvDFsZOiWCoigA = P_1;
					JDXbjCEHJBBbpZUnyLpKiAJcbjjdb = P_2;
					LDliaNeAUqfNlGOOcEgvxJDercVuA = P_3;
					JUTanEOVBHbwVHQHKsAHkvZOyxmj = P_4;
					MXkNViMtSkCXhVAqsNOXkqgyAXmH = P_5;
				}

				public bool TUibHCXgdJpNwgxVPYRazOMZLYAI(aXKdbsJagcDNmCLkhMgrMqUCuHJN P_0, vXgKbwMqQfAfXrTWJEdMppXWEhVm P_1)
				{
					if (P_0.rewiredId == PoDKkXNZKOoZdyxGaKFAmJnBpZjC)
					{
						return true;
					}
					if (P_0.zqbnhwKOcKeCZgUaPhMsNMpJqrwSA != JUTanEOVBHbwVHQHKsAHkvZOyxmj)
					{
						return false;
					}
					if (P_0.msArXGKyTuNvjcoAJyFcezvJxamf != MXkNViMtSkCXhVAqsNOXkqgyAXmH)
					{
						return false;
					}
					switch (P_1)
					{
					case vXgKbwMqQfAfXrTWJEdMppXWEhVm.Exact:
						if (vvRHmUUDQhTCXXeKvDFsZOiWCoigA == P_0.systemId)
						{
							return JDXbjCEHJBBbpZUnyLpKiAJcbjjdb == P_0.sbnXECOsTgfoWczdRvgPHKbvVbFz;
						}
						return false;
					case vXgKbwMqQfAfXrTWJEdMppXWEhVm.Approximate:
						return JDXbjCEHJBBbpZUnyLpKiAJcbjjdb == P_0.sbnXECOsTgfoWczdRvgPHKbvVbFz;
					default:
						throw new NotImplementedException();
					}
				}
			}

			private sealed class dlliqSlqJzNMniKrTOEYQWkjrhqo : IDisposable, IEnumerable, IEnumerator, IEnumerable<cTVgOhlLrtfEtksLbqqZlCTIJVSqA>, IEnumerator<cTVgOhlLrtfEtksLbqqZlCTIJVSqA>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private cTVgOhlLrtfEtksLbqqZlCTIJVSqA vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public EOJKsOPTVawkLfhDWWStUrLbBrNg zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private aXKdbsJagcDNmCLkhMgrMqUCuHJN PPLekmpxyeaCalMMLsyiHANzmPht;

				public aXKdbsJagcDNmCLkhMgrMqUCuHJN dPHIVjRDubtebhsvurMEHsmzsQyy;

				private vXgKbwMqQfAfXrTWJEdMppXWEhVm eTKuBlPFOuiTvIIHBAuXRdCOKbbbb;

				public vXgKbwMqQfAfXrTWJEdMppXWEhVm ADPaiKhTaBrtDUTfHyDEtiWqEVVk;

				private int wELWqlBnItHYSvuhGaGHFUnOXsvh;

				private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

				cTVgOhlLrtfEtksLbqqZlCTIJVSqA IEnumerator<cTVgOhlLrtfEtksLbqqZlCTIJVSqA>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public dlliqSlqJzNMniKrTOEYQWkjrhqo(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					EOJKsOPTVawkLfhDWWStUrLbBrNg eOJKsOPTVawkLfhDWWStUrLbBrNg = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					if (num != 0)
					{
						if (num != 1)
						{
							return false;
						}
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						goto IL_0083;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					wELWqlBnItHYSvuhGaGHFUnOXsvh = eOJKsOPTVawkLfhDWWStUrLbBrNg.kPbexRcNIgkoIUHQQYRQrEHvMBzi.Count;
					PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
					goto IL_0093;
					IL_0083:
					PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
					goto IL_0093;
					IL_0093:
					if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < wELWqlBnItHYSvuhGaGHFUnOXsvh)
					{
						if (eOJKsOPTVawkLfhDWWStUrLbBrNg.kPbexRcNIgkoIUHQQYRQrEHvMBzi[PrfhaiCANHhjwtWLxlpNIHvkLSmF].TUibHCXgdJpNwgxVPYRazOMZLYAI(PPLekmpxyeaCalMMLsyiHANzmPht, eTKuBlPFOuiTvIIHBAuXRdCOKbbbb))
						{
							vjnbYLtrPMftzpjohNfommerCnGo = eOJKsOPTVawkLfhDWWStUrLbBrNg.kPbexRcNIgkoIUHQQYRQrEHvMBzi[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
				IEnumerator<cTVgOhlLrtfEtksLbqqZlCTIJVSqA> IEnumerable<cTVgOhlLrtfEtksLbqqZlCTIJVSqA>.GetEnumerator()
				{
					dlliqSlqJzNMniKrTOEYQWkjrhqo dlliqSlqJzNMniKrTOEYQWkjrhqo2;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						dlliqSlqJzNMniKrTOEYQWkjrhqo2 = this;
					}
					else
					{
						dlliqSlqJzNMniKrTOEYQWkjrhqo2 = new dlliqSlqJzNMniKrTOEYQWkjrhqo(0);
						dlliqSlqJzNMniKrTOEYQWkjrhqo2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					dlliqSlqJzNMniKrTOEYQWkjrhqo2.PPLekmpxyeaCalMMLsyiHANzmPht = dPHIVjRDubtebhsvurMEHsmzsQyy;
					dlliqSlqJzNMniKrTOEYQWkjrhqo2.eTKuBlPFOuiTvIIHBAuXRdCOKbbbb = ADPaiKhTaBrtDUTfHyDEtiWqEVVk;
					return dlliqSlqJzNMniKrTOEYQWkjrhqo2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<cTVgOhlLrtfEtksLbqqZlCTIJVSqA>)this).GetEnumerator();
				}
			}

			private List<cTVgOhlLrtfEtksLbqqZlCTIJVSqA> kPbexRcNIgkoIUHQQYRQrEHvMBzi;

			public int ZQqQltuirEhRybMOxWCRGTiKWPGW => kPbexRcNIgkoIUHQQYRQrEHvMBzi.Count;

			public EOJKsOPTVawkLfhDWWStUrLbBrNg()
			{
				kPbexRcNIgkoIUHQQYRQrEHvMBzi = new List<cTVgOhlLrtfEtksLbqqZlCTIJVSqA>();
			}

			public void etdZpFVoMIOwufjLtmaknStPcvGU(aXKdbsJagcDNmCLkhMgrMqUCuHJN P_0)
			{
				if (P_0 == null)
				{
					return;
				}
				int count = kPbexRcNIgkoIUHQQYRQrEHvMBzi.Count;
				for (int i = 0; i < count; i++)
				{
					if (kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].TUibHCXgdJpNwgxVPYRazOMZLYAI(P_0, vXgKbwMqQfAfXrTWJEdMppXWEhVm.Exact))
					{
						kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].PoDKkXNZKOoZdyxGaKFAmJnBpZjC = P_0.rewiredId;
						kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].vvRHmUUDQhTCXXeKvDFsZOiWCoigA = P_0.systemId;
						kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].JDXbjCEHJBBbpZUnyLpKiAJcbjjdb = P_0.sbnXECOsTgfoWczdRvgPHKbvVbFz;
						kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].LDliaNeAUqfNlGOOcEgvxJDercVuA = P_0.inputManagerId;
						kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].JUTanEOVBHbwVHQHKsAHkvZOyxmj = P_0.zqbnhwKOcKeCZgUaPhMsNMpJqrwSA;
						kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].MXkNViMtSkCXhVAqsNOXkqgyAXmH = P_0.msArXGKyTuNvjcoAJyFcezvJxamf;
						CMjFsiFrLxitfwruosgZvzzbCFuDA(P_0.rewiredId, i);
						return;
					}
				}
				kPbexRcNIgkoIUHQQYRQrEHvMBzi.Add(new cTVgOhlLrtfEtksLbqqZlCTIJVSqA(P_0.rewiredId, P_0.systemId, P_0.sbnXECOsTgfoWczdRvgPHKbvVbFz, P_0.inputManagerId, P_0.zqbnhwKOcKeCZgUaPhMsNMpJqrwSA, P_0.msArXGKyTuNvjcoAJyFcezvJxamf));
				CMjFsiFrLxitfwruosgZvzzbCFuDA(P_0.rewiredId, kPbexRcNIgkoIUHQQYRQrEHvMBzi.Count - 1);
			}

			public bool XrqcBMeuSMEFFHtBARTfiYGSMlVMB(aXKdbsJagcDNmCLkhMgrMqUCuHJN P_0, vXgKbwMqQfAfXrTWJEdMppXWEhVm P_1)
			{
				int count = kPbexRcNIgkoIUHQQYRQrEHvMBzi.Count;
				for (int i = 0; i < count; i++)
				{
					if (kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].TUibHCXgdJpNwgxVPYRazOMZLYAI(P_0, P_1))
					{
						return true;
					}
				}
				return false;
			}

			public IEnumerable<cTVgOhlLrtfEtksLbqqZlCTIJVSqA> nffAsUegsnbGPpSPyXBkIUXWBpMiA(aXKdbsJagcDNmCLkhMgrMqUCuHJN P_0, vXgKbwMqQfAfXrTWJEdMppXWEhVm P_1)
			{
				return new dlliqSlqJzNMniKrTOEYQWkjrhqo(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
					dPHIVjRDubtebhsvurMEHsmzsQyy = P_0,
					ADPaiKhTaBrtDUTfHyDEtiWqEVVk = P_1
				};
			}

			public int PujFpIgnaejxCcbCzrcoRIpZaecab(cTVgOhlLrtfEtksLbqqZlCTIJVSqA P_0)
			{
				int count = kPbexRcNIgkoIUHQQYRQrEHvMBzi.Count;
				for (int i = 0; i < count; i++)
				{
					if (kPbexRcNIgkoIUHQQYRQrEHvMBzi[i] == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private void CMjFsiFrLxitfwruosgZvzzbCFuDA(int P_0, int P_1)
			{
				for (int num = kPbexRcNIgkoIUHQQYRQrEHvMBzi.Count - 1; num >= 0; num--)
				{
					if (num != P_1 && kPbexRcNIgkoIUHQQYRQrEHvMBzi[num].PoDKkXNZKOoZdyxGaKFAmJnBpZjC == P_0)
					{
						kPbexRcNIgkoIUHQQYRQrEHvMBzi.RemoveAt(num);
					}
				}
			}
		}

		private List<aXKdbsJagcDNmCLkhMgrMqUCuHJN> FUWUMuBhggyFQEOUCASaOJmITfwR;

		private int wfXcGbTMFLTAwDvEytkMGYATlJxS;

		private EOJKsOPTVawkLfhDWWStUrLbBrNg AXHLLNOarmUpwPzyUrjqTImAJvzZ;

		private UpdateLoopType oLPSGLPrThUSDXxJlTVDuFNuQqAB;

		private Action<int, ControllerDataUpdater> HCxdAMptrVyNqjBtiFgxnKPxMREK;

		private PlatformInputManager DOLMBlAuzrRqMqRPSTlLJGeCWdRS;

		private CustomInputSource MoLAgKKKHrYfylPGQUulAQPlyoYt;

		private bool IyVoDwWZYTkSKsbJSXOYyMoCctgEA;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> kKluBaSojOoBlftxKOIOxwWJcxHk;

		private Func<int> jbCzHXeaCghjiwDuBObiXpdMPmld;

		[CustomObfuscation(rename = false)]
		public override int deviceCount => wfXcGbTMFLTAwDvEytkMGYATlJxS;

		[CustomObfuscation(rename = false)]
		public override PlatformInputManager primaryInputManager => DOLMBlAuzrRqMqRPSTlLJGeCWdRS;

		[CustomObfuscation(rename = false)]
		public override IInputSource inputSource => null;

		[CustomObfuscation(rename = false)]
		public override InputSource inputSourceType => MoLAgKKKHrYfylPGQUulAQPlyoYt.JNMBmPSsDBEFBkOLyoQWUaGjLnyvA;

		public CustomInputManager(CustomInputSource P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3)
		{
			MoLAgKKKHrYfylPGQUulAQPlyoYt = P_0;
			kKluBaSojOoBlftxKOIOxwWJcxHk = P_2;
			jbCzHXeaCghjiwDuBObiXpdMPmld = P_3;
			DOLMBlAuzrRqMqRPSTlLJGeCWdRS = this;
			try
			{
				HCxdAMptrVyNqjBtiFgxnKPxMREK = UpdateControllerData;
				P_0.utcbOSfIUgHkpApnzrrYIirhDhVCb += SystemDeviceConnected;
				P_0.BFpjGlqLjXCgxIDjCiyfgLkbIHgRB += SystemDeviceDisconnected;
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
			AXHLLNOarmUpwPzyUrjqTImAJvzZ = new EOJKsOPTVawkLfhDWWStUrLbBrNg();
			FUWUMuBhggyFQEOUCASaOJmITfwR = new List<aXKdbsJagcDNmCLkhMgrMqUCuHJN>();
			IyVoDwWZYTkSKsbJSXOYyMoCctgEA = true;
			MoLAgKKKHrYfylPGQUulAQPlyoYt.TlzckGoQDITHcUYaslQXPQBOhTwq();
		}

		[CustomObfuscation(rename = false)]
		public override void Update(UpdateLoopType updateLoop)
		{
			oLPSGLPrThUSDXxJlTVDuFNuQqAB = updateLoop;
			if (MoLAgKKKHrYfylPGQUulAQPlyoYt.isReady)
			{
				MoLAgKKKHrYfylPGQUulAQPlyoYt.Update();
				MoLAgKKKHrYfylPGQUulAQPlyoYt.cwOErHdoGDKEsFmyGHskstVlrOhbB();
				if (IyVoDwWZYTkSKsbJSXOYyMoCctgEA)
				{
					FBokPeRBoOhMkvYGDuNRMXWrguuJ();
				}
				qiskyArBYQnsKNKyfKfvpGFiOZus();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
			if (MoLAgKKKHrYfylPGQUulAQPlyoYt != null)
			{
				MoLAgKKKHrYfylPGQUulAQPlyoYt.Dispose();
			}
		}

		[CustomObfuscation(rename = false)]
		public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
		{
			return HCxdAMptrVyNqjBtiFgxnKPxMREK;
		}

		[CustomObfuscation(rename = false)]
		public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
		{
			for (int i = 0; i < wfXcGbTMFLTAwDvEytkMGYATlJxS; i++)
			{
				if (FUWUMuBhggyFQEOUCASaOJmITfwR[i].inputManagerId == inputManagerId)
				{
					FUWUMuBhggyFQEOUCASaOJmITfwR[i].FillData(data);
					return;
				}
			}
			Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceConnected()
		{
			IyVoDwWZYTkSKsbJSXOYyMoCctgEA = true;
			if (_SystemDeviceConnectedEvent != null)
			{
				_SystemDeviceConnectedEvent();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceDisconnected()
		{
			IyVoDwWZYTkSKsbJSXOYyMoCctgEA = true;
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
			return MoLAgKKKHrYfylPGQUulAQPlyoYt.IIhpAaXiKsDxxPRINWMLIdgMdsoS();
		}

		[CustomObfuscation(rename = false)]
		public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
		{
			return MoLAgKKKHrYfylPGQUulAQPlyoYt.ufjIvKCyejCncZnncxoHsJXMAdU();
		}

		private void NNRegRGwZdbXcWVmwpEjRzhQeNlBA(CustomInputSource.Joystick[] P_0)
		{
			int num = 0;
			List<aXKdbsJagcDNmCLkhMgrMqUCuHJN> fUWUMuBhggyFQEOUCASaOJmITfwR = FUWUMuBhggyFQEOUCASaOJmITfwR;
			int num2 = wfXcGbTMFLTAwDvEytkMGYATlJxS;
			FUWUMuBhggyFQEOUCASaOJmITfwR = new List<aXKdbsJagcDNmCLkhMgrMqUCuHJN>();
			for (int i = 0; i < P_0.Length; i++)
			{
				if (P_0[i] != null)
				{
					aXKdbsJagcDNmCLkhMgrMqUCuHJN item = new aXKdbsJagcDNmCLkhMgrMqUCuHJN(MoLAgKKKHrYfylPGQUulAQPlyoYt, P_0[i].systemId, P_0[i].unityId, P_0[i], MoLAgKKKHrYfylPGQUulAQPlyoYt.JNMBmPSsDBEFBkOLyoQWUaGjLnyvA, P_0[i].extension, kKluBaSojOoBlftxKOIOxwWJcxHk);
					FUWUMuBhggyFQEOUCASaOJmITfwR.Add(item);
					num++;
				}
			}
			wfXcGbTMFLTAwDvEytkMGYATlJxS = num;
			RQriXSiYZlIhQlOKVPdgXgEmWHZ(num2, num, fUWUMuBhggyFQEOUCASaOJmITfwR, FUWUMuBhggyFQEOUCASaOJmITfwR);
			for (int j = 0; j < num; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(FUWUMuBhggyFQEOUCASaOJmITfwR[j]));
				}
			}
			MMDbBEBBOxkQPFDselRRsAlEXjucA(fUWUMuBhggyFQEOUCASaOJmITfwR, FUWUMuBhggyFQEOUCASaOJmITfwR, false);
			MMDbBEBBOxkQPFDselRRsAlEXjucA(FUWUMuBhggyFQEOUCASaOJmITfwR, fUWUMuBhggyFQEOUCASaOJmITfwR, true);
		}

		private void qiskyArBYQnsKNKyfKfvpGFiOZus()
		{
			for (int i = 0; i < wfXcGbTMFLTAwDvEytkMGYATlJxS; i++)
			{
				FUWUMuBhggyFQEOUCASaOJmITfwR[i].Update();
			}
		}

		private void RQriXSiYZlIhQlOKVPdgXgEmWHZ(int P_0, int P_1, List<aXKdbsJagcDNmCLkhMgrMqUCuHJN> P_2, List<aXKdbsJagcDNmCLkhMgrMqUCuHJN> P_3)
		{
			if (P_1 > 0)
			{
				P_3.Sort(aXKdbsJagcDNmCLkhMgrMqUCuHJN.GrgeiHJAqlWYynnWJHqdnuLSZvLTA);
			}
			if (P_0 > 0 && P_1 > 0)
			{
				JiISXIZWxNkSNAJJXCzTcwRWcJrX(P_1, P_3, P_0, P_2, EOJKsOPTVawkLfhDWWStUrLbBrNg.vXgKbwMqQfAfXrTWJEdMppXWEhVm.Exact);
				if (MoLAgKKKHrYfylPGQUulAQPlyoYt.useApproximateMatching)
				{
					JiISXIZWxNkSNAJJXCzTcwRWcJrX(P_1, P_3, P_0, P_2, EOJKsOPTVawkLfhDWWStUrLbBrNg.vXgKbwMqQfAfXrTWJEdMppXWEhVm.Approximate);
				}
			}
			ZxMnClrqCkkIKuhtkAkNIZRLlMiT(P_1, P_3, EOJKsOPTVawkLfhDWWStUrLbBrNg.vXgKbwMqQfAfXrTWJEdMppXWEhVm.Exact);
			if (MoLAgKKKHrYfylPGQUulAQPlyoYt.useApproximateMatching)
			{
				ZxMnClrqCkkIKuhtkAkNIZRLlMiT(P_1, P_3, EOJKsOPTVawkLfhDWWStUrLbBrNg.vXgKbwMqQfAfXrTWJEdMppXWEhVm.Approximate);
			}
			for (int i = 0; i < P_1; i++)
			{
				aXKdbsJagcDNmCLkhMgrMqUCuHJN aXKdbsJagcDNmCLkhMgrMqUCuHJN2 = P_3[i];
				if (aXKdbsJagcDNmCLkhMgrMqUCuHJN2 != null && aXKdbsJagcDNmCLkhMgrMqUCuHJN2.inputManagerId < 0)
				{
					aXKdbsJagcDNmCLkhMgrMqUCuHJN2.inputManagerId = oascgJGqUakhIBruUtJygUsrPpREb(P_3);
					aXKdbsJagcDNmCLkhMgrMqUCuHJN2.rewiredId = ReInput.GetNewJoystickId();
					AXHLLNOarmUpwPzyUrjqTImAJvzZ.etdZpFVoMIOwufjLtmaknStPcvGU(aXKdbsJagcDNmCLkhMgrMqUCuHJN2);
				}
			}
			P_3.Sort(aXKdbsJagcDNmCLkhMgrMqUCuHJN.bysvDFWAHFIftaGNXVmikMUoHVvnA);
		}

		private void solUsRNigSZftXBPocPDmTnjvCBg(List<aXKdbsJagcDNmCLkhMgrMqUCuHJN> P_0, int P_1, int P_2)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (i != P_1 && P_0[i] != null && P_0[i].inputManagerId == P_2)
				{
					P_0[i].inputManagerId = -1;
				}
			}
		}

		private bool klYqnApnwEMvDnQFJsQkzFXkxtRX(List<aXKdbsJagcDNmCLkhMgrMqUCuHJN> P_0, int P_1)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && P_0[i].inputManagerId == P_1)
				{
					return false;
				}
			}
			return true;
		}

		private int oascgJGqUakhIBruUtJygUsrPpREb(List<aXKdbsJagcDNmCLkhMgrMqUCuHJN> P_0)
		{
			int num = 0;
			while (true)
			{
				bool flag = false;
				int count = P_0.Count;
				for (int i = 0; i < count; i++)
				{
					if (P_0[i] != null && P_0[i].inputManagerId == num)
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

		private bool cXRIFomJuhRUSXTyIOAgnIYsipeg(List<aXKdbsJagcDNmCLkhMgrMqUCuHJN> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return false;
			}
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].rewiredId == P_1)
				{
					return true;
				}
			}
			return false;
		}

		private void JiISXIZWxNkSNAJJXCzTcwRWcJrX(int P_0, List<aXKdbsJagcDNmCLkhMgrMqUCuHJN> P_1, int P_2, List<aXKdbsJagcDNmCLkhMgrMqUCuHJN> P_3, EOJKsOPTVawkLfhDWWStUrLbBrNg.vXgKbwMqQfAfXrTWJEdMppXWEhVm P_4)
		{
			int num = ((P_4 != EOJKsOPTVawkLfhDWWStUrLbBrNg.vXgKbwMqQfAfXrTWJEdMppXWEhVm.Exact) ? 1 : 2);
			for (int i = 0; i < P_0; i++)
			{
				aXKdbsJagcDNmCLkhMgrMqUCuHJN aXKdbsJagcDNmCLkhMgrMqUCuHJN2 = P_1[i];
				if (aXKdbsJagcDNmCLkhMgrMqUCuHJN2 == null || aXKdbsJagcDNmCLkhMgrMqUCuHJN2.inputManagerId >= 0)
				{
					continue;
				}
				for (int j = 0; j < P_2; j++)
				{
					aXKdbsJagcDNmCLkhMgrMqUCuHJN aXKdbsJagcDNmCLkhMgrMqUCuHJN3 = P_3[j];
					if (aXKdbsJagcDNmCLkhMgrMqUCuHJN3 != null && !cXRIFomJuhRUSXTyIOAgnIYsipeg(P_1, aXKdbsJagcDNmCLkhMgrMqUCuHJN3.rewiredId) && aXKdbsJagcDNmCLkhMgrMqUCuHJN2.TUibHCXgdJpNwgxVPYRazOMZLYAI(aXKdbsJagcDNmCLkhMgrMqUCuHJN3) >= num)
					{
						aXKdbsJagcDNmCLkhMgrMqUCuHJN2.inputManagerId = aXKdbsJagcDNmCLkhMgrMqUCuHJN3.inputManagerId;
						aXKdbsJagcDNmCLkhMgrMqUCuHJN2.rewiredId = aXKdbsJagcDNmCLkhMgrMqUCuHJN3.rewiredId;
						AXHLLNOarmUpwPzyUrjqTImAJvzZ.etdZpFVoMIOwufjLtmaknStPcvGU(aXKdbsJagcDNmCLkhMgrMqUCuHJN2);
					}
				}
			}
		}

		private void ZxMnClrqCkkIKuhtkAkNIZRLlMiT(int P_0, List<aXKdbsJagcDNmCLkhMgrMqUCuHJN> P_1, EOJKsOPTVawkLfhDWWStUrLbBrNg.vXgKbwMqQfAfXrTWJEdMppXWEhVm P_2)
		{
			for (int i = 0; i < P_0; i++)
			{
				aXKdbsJagcDNmCLkhMgrMqUCuHJN aXKdbsJagcDNmCLkhMgrMqUCuHJN2 = P_1[i];
				if (aXKdbsJagcDNmCLkhMgrMqUCuHJN2 == null || aXKdbsJagcDNmCLkhMgrMqUCuHJN2.inputManagerId >= 0)
				{
					continue;
				}
				EOJKsOPTVawkLfhDWWStUrLbBrNg.cTVgOhlLrtfEtksLbqqZlCTIJVSqA cTVgOhlLrtfEtksLbqqZlCTIJVSqA = null;
				foreach (EOJKsOPTVawkLfhDWWStUrLbBrNg.cTVgOhlLrtfEtksLbqqZlCTIJVSqA item in AXHLLNOarmUpwPzyUrjqTImAJvzZ.nffAsUegsnbGPpSPyXBkIUXWBpMiA(aXKdbsJagcDNmCLkhMgrMqUCuHJN2, P_2))
				{
					if (!cXRIFomJuhRUSXTyIOAgnIYsipeg(P_1, item.PoDKkXNZKOoZdyxGaKFAmJnBpZjC) && item.LDliaNeAUqfNlGOOcEgvxJDercVuA >= 0)
					{
						cTVgOhlLrtfEtksLbqqZlCTIJVSqA = item;
						break;
					}
				}
				if (cTVgOhlLrtfEtksLbqqZlCTIJVSqA != null)
				{
					int num = cTVgOhlLrtfEtksLbqqZlCTIJVSqA.LDliaNeAUqfNlGOOcEgvxJDercVuA;
					if (!klYqnApnwEMvDnQFJsQkzFXkxtRX(P_1, num))
					{
						num = (cTVgOhlLrtfEtksLbqqZlCTIJVSqA.LDliaNeAUqfNlGOOcEgvxJDercVuA = oascgJGqUakhIBruUtJygUsrPpREb(P_1));
					}
					aXKdbsJagcDNmCLkhMgrMqUCuHJN2.inputManagerId = num;
					aXKdbsJagcDNmCLkhMgrMqUCuHJN2.rewiredId = cTVgOhlLrtfEtksLbqqZlCTIJVSqA.PoDKkXNZKOoZdyxGaKFAmJnBpZjC;
					AXHLLNOarmUpwPzyUrjqTImAJvzZ.etdZpFVoMIOwufjLtmaknStPcvGU(aXKdbsJagcDNmCLkhMgrMqUCuHJN2);
				}
			}
		}

		private void FBokPeRBoOhMkvYGDuNRMXWrguuJ()
		{
			CustomInputSource.Joystick[] array = MoLAgKKKHrYfylPGQUulAQPlyoYt.nQJGOcXPfsgelZsYveOAHeAYhGIi();
			if (yzIJgrQHYsHrxolnFVxYFynuWMug(array))
			{
				NNRegRGwZdbXcWVmwpEjRzhQeNlBA(array);
			}
			IyVoDwWZYTkSKsbJSXOYyMoCctgEA = false;
		}

		private bool yzIJgrQHYsHrxolnFVxYFynuWMug(CustomInputSource.Joystick[] P_0)
		{
			int num = P_0.Length;
			int count = FUWUMuBhggyFQEOUCASaOJmITfwR.Count;
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
					if (FUWUMuBhggyFQEOUCASaOJmITfwR[j] != null && systemId == FUWUMuBhggyFQEOUCASaOJmITfwR[j].systemId)
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
				if (FUWUMuBhggyFQEOUCASaOJmITfwR[k] == null)
				{
					continue;
				}
				long? systemId2 = FUWUMuBhggyFQEOUCASaOJmITfwR[k].systemId;
				bool flag2 = false;
				for (int l = 0; l < num; l++)
				{
					if (P_0[l] != null && systemId2 == P_0[l].systemId)
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

		private void MMDbBEBBOxkQPFDselRRsAlEXjucA(List<aXKdbsJagcDNmCLkhMgrMqUCuHJN> P_0, List<aXKdbsJagcDNmCLkhMgrMqUCuHJN> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				return;
			}
			int num = P_0?.Count ?? 0;
			int num2 = P_1?.Count ?? 0;
			for (int i = 0; i < num; i++)
			{
				aXKdbsJagcDNmCLkhMgrMqUCuHJN aXKdbsJagcDNmCLkhMgrMqUCuHJN2 = P_0[i];
				if (aXKdbsJagcDNmCLkhMgrMqUCuHJN2 == null)
				{
					continue;
				}
				bool flag = false;
				if (P_1 != null)
				{
					for (int j = 0; j < num2; j++)
					{
						aXKdbsJagcDNmCLkhMgrMqUCuHJN aXKdbsJagcDNmCLkhMgrMqUCuHJN3 = P_1[j];
						if (aXKdbsJagcDNmCLkhMgrMqUCuHJN3 != null && aXKdbsJagcDNmCLkhMgrMqUCuHJN2.rewiredId == aXKdbsJagcDNmCLkhMgrMqUCuHJN3.rewiredId)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					ajbGTsFPidClCieJTDaEyrhzPGaV(P_0[i], P_2);
				}
			}
		}

		private void ajbGTsFPidClCieJTDaEyrhzPGaV(aXKdbsJagcDNmCLkhMgrMqUCuHJN P_0, bool P_1)
		{
			if (P_1)
			{
				P_0.AKBthARIICiQKchrlioKjuzGiShgA();
			}
			NEYqvDlmIqNjJeojWEOjnwQNZBDP(P_0, P_1);
		}

		private void NEYqvDlmIqNjJeojWEOjnwQNZBDP(aXKdbsJagcDNmCLkhMgrMqUCuHJN P_0, bool P_1)
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
