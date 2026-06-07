using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class hMQIZPyKJMwNVAVsJSknVtsealZN : PlatformInputManager
{
	private class XOzFcGbsRRLbaSAchCXEukINevyoA : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int AWDPTZahSurPaRegJCJbfSjbLABDA;

		private int DBqwflQuDhjOwzNeyukXHgJnkOfY;

		private int XnxPMcDVeYJBWHnXiEncxXfStLbv;

		public Guid SRIKvGKsUVvKdhMhLSwDFQSDInVe;

		public string hRZPRklmxuLdfxuIMUpivvXNqsjL;

		public int WjaavdqYYofItFUSBKFDHrqFoasn;

		public string WWkhxeFfUZaGTHMZoSdMWgSzynWT;

		public string nhThQQCNiKeXRJirNPvVqwWWjFgi;

		private int MXkNViMtSkCXhVAqsNOXkqgyAXmH = 29;

		private int JUTanEOVBHbwVHQHKsAHkvZOyxmj = 20;

		private float[] YfLoKOFOHkBmsDeLrJINqoJgfdBs;

		private bool[] iBbGdzIuvxfCvxbSBnLZfvrWDwZPA;

		private bool[] IaYnBKdGAXLJJUYKcKIrwcLdJvyT;

		private float[] NCOIpjSNzzDUnBqJKZoWnmcPgTuN;

		private bool[] abnnaTyAdAjUEBBSvaawpkNwfnnvA;

		private HardwareJoystickMap_InputManager AWCbIECppuLDtCThiwONsElGeIEub;

		private bool KOCtFDDOIabeTGjesaCmoXILgaNrA;

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
				if (!(hRZPRklmxuLdfxuIMUpivvXNqsjL != "Unknown Controller"))
				{
					return WWkhxeFfUZaGTHMZoSdMWgSzynWT;
				}
				return hRZPRklmxuLdfxuIMUpivvXNqsjL;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (XnxPMcDVeYJBWHnXiEncxXfStLbv < 1)
				{
					return null;
				}
				return XnxPMcDVeYJBWHnXiEncxXfStLbv;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return XnxPMcDVeYJBWHnXiEncxXfStLbv;
			}
			set
			{
				XnxPMcDVeYJBWHnXiEncxXfStLbv = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid
		{
			get
			{
				if ((ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull) || UnityTools.effectivePlatform == Platform.OSX)
				{
					return MiscTools.CreateGuidHashSHA1(name);
				}
				if (UnityTools.isIOSPlatform)
				{
					return MiscTools.CreateGuidHashSHA1(WWkhxeFfUZaGTHMZoSdMWgSzynWT);
				}
				return MiscTools.CreateGuidHashSHA1(name + "_" + XnxPMcDVeYJBWHnXiEncxXfStLbv);
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension => null;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		public XOzFcGbsRRLbaSAchCXEukINevyoA()
		{
			DBqwflQuDhjOwzNeyukXHgJnkOfY = -1;
			AWDPTZahSurPaRegJCJbfSjbLABDA = -1;
			XnxPMcDVeYJBWHnXiEncxXfStLbv = 0;
		}

		public void nUvScElMaHbXPGbUJUjTDRAbOMntA()
		{
			QUChOlDwNBGjhwrZDvEmAwZUZaZWA();
			SRIKvGKsUVvKdhMhLSwDFQSDInVe = AWCbIECppuLDtCThiwONsElGeIEub.hardwareMapIdentifier.guid;
			hRZPRklmxuLdfxuIMUpivvXNqsjL = AWCbIECppuLDtCThiwONsElGeIEub.controllerName;
			YfLoKOFOHkBmsDeLrJINqoJgfdBs = new float[MXkNViMtSkCXhVAqsNOXkqgyAXmH];
			iBbGdzIuvxfCvxbSBnLZfvrWDwZPA = new bool[JUTanEOVBHbwVHQHKsAHkvZOyxmj];
			IaYnBKdGAXLJJUYKcKIrwcLdJvyT = new bool[MXkNViMtSkCXhVAqsNOXkqgyAXmH];
			abnnaTyAdAjUEBBSvaawpkNwfnnvA = new bool[29];
			NCOIpjSNzzDUnBqJKZoWnmcPgTuN = new float[29];
			Update();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (XnxPMcDVeYJBWHnXiEncxXfStLbv > 0)
			{
				tYwYHrMIMOgXHqIxPQTCYzKLkSyv();
				FJVWeNzOMPCUZWnjHQjGXusGLrqs();
				eVhPgKUIwZyGaTlvvzdxWzILOpns();
			}
		}

		public int TUibHCXgdJpNwgxVPYRazOMZLYAI(XOzFcGbsRRLbaSAchCXEukINevyoA P_0)
		{
			if ((!string.IsNullOrEmpty(nhThQQCNiKeXRJirNPvVqwWWjFgi) || !string.IsNullOrEmpty(P_0.nhThQQCNiKeXRJirNPvVqwWWjFgi)) && !string.Equals(nhThQQCNiKeXRJirNPvVqwWWjFgi, P_0.nhThQQCNiKeXRJirNPvVqwWWjFgi, StringComparison.Ordinal))
			{
				return 0;
			}
			if (P_0.WWkhxeFfUZaGTHMZoSdMWgSzynWT == WWkhxeFfUZaGTHMZoSdMWgSzynWT && P_0.WjaavdqYYofItFUSBKFDHrqFoasn == WjaavdqYYofItFUSBKFDHrqFoasn)
			{
				return 2;
			}
			if (P_0.WWkhxeFfUZaGTHMZoSdMWgSzynWT == WWkhxeFfUZaGTHMZoSdMWgSzynWT)
			{
				return 1;
			}
			return 0;
		}

		private void zdHnvQFaOLYLcQqdXRgyYLSDYaNB(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.Fallback;
			P_0.inputSource = MvFScWscrxeEtNjKiqsXvDnglmgC();
			P_0.hardwareIdentifier = OFTaxqRnIObDkzwyLzlCIkEhFxYg();
			P_0.hardwareAxisCount = 0;
			P_0.hardwareButtonCount = 0;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = WWkhxeFfUZaGTHMZoSdMWgSzynWT;
		}

		private void zdHnvQFaOLYLcQqdXRgyYLSDYaNB(BridgedController P_0)
		{
			zdHnvQFaOLYLcQqdXRgyYLSDYaNB((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = AWCbIECppuLDtCThiwONsElGeIEub.ToGameHardwareControllerMap();
			P_0.instanceName = WWkhxeFfUZaGTHMZoSdMWgSzynWT;
			P_0.productName = WWkhxeFfUZaGTHMZoSdMWgSzynWT;
			P_0.isXInputDevice = false;
			P_0.axisCount = MXkNViMtSkCXhVAqsNOXkqgyAXmH;
			P_0.buttonCount = JUTanEOVBHbwVHQHKsAHkvZOyxmj;
			P_0.controllerTypeGuid = SRIKvGKsUVvKdhMhLSwDFQSDInVe;
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (MXkNViMtSkCXhVAqsNOXkqgyAXmH != dataUpdater.axisCount || JUTanEOVBHbwVHQHKsAHkvZOyxmj != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			float[] axisValues = dataUpdater.axisValues;
			bool[] axisHasBeenPressedOSXLinux = dataUpdater.axisHasBeenPressedOSXLinux;
			for (int i = 0; i < MXkNViMtSkCXhVAqsNOXkqgyAXmH; i++)
			{
				if (axisValues[i] != YfLoKOFOHkBmsDeLrJINqoJgfdBs[i])
				{
					axisValues[i] = YfLoKOFOHkBmsDeLrJINqoJgfdBs[i];
					if (axisHasBeenPressedOSXLinux[i] != IaYnBKdGAXLJJUYKcKIrwcLdJvyT[i])
					{
						axisHasBeenPressedOSXLinux[i] = IaYnBKdGAXLJJUYKcKIrwcLdJvyT[i];
					}
				}
			}
			bool[] buttonValues = dataUpdater.buttonValues;
			for (int j = 0; j < JUTanEOVBHbwVHQHKsAHkvZOyxmj; j++)
			{
				if (buttonValues[j] != iBbGdzIuvxfCvxbSBnLZfvrWDwZPA[j])
				{
					buttonValues[j] = iBbGdzIuvxfCvxbSBnLZfvrWDwZPA[j];
				}
			}
			if (KOCtFDDOIabeTGjesaCmoXILgaNrA && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public void cOcSPELJlsFTkIVjGVEDCMKXCFWSA(int P_0)
		{
			if (P_0 >= 1 && P_0 <= 16)
			{
				unityId = P_0;
			}
		}

		public void LBzVtFJIkcPPzVDXtIaEDVWUHolP()
		{
			XnxPMcDVeYJBWHnXiEncxXfStLbv = 0;
			csDwaLbbpqniYeCtbmAvRaFuJHyd();
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

		private void tYwYHrMIMOgXHqIxPQTCYzKLkSyv()
		{
			for (int i = 0; i < 29; i++)
			{
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(XnxPMcDVeYJBWHnXiEncxXfStLbv, i);
				if (NCOIpjSNzzDUnBqJKZoWnmcPgTuN[i] != joystickAxisValueByJoystickId)
				{
					NCOIpjSNzzDUnBqJKZoWnmcPgTuN[i] = joystickAxisValueByJoystickId;
					if (!abnnaTyAdAjUEBBSvaawpkNwfnnvA[i] && joystickAxisValueByJoystickId != 0f)
					{
						abnnaTyAdAjUEBBSvaawpkNwfnnvA[i] = true;
					}
				}
			}
		}

		private void FJVWeNzOMPCUZWnjHQjGXusGLrqs()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_Fallback_Base)AWCbIECppuLDtCThiwONsElGeIEub.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i] == null)
				{
					continue;
				}
				if (i >= MXkNViMtSkCXhVAqsNOXkqgyAXmH)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				float num = HzIOlHJRYcDpORuJITPEIKgEEJzIA(axes_orig[i]);
				if (YfLoKOFOHkBmsDeLrJINqoJgfdBs[i] == num)
				{
					continue;
				}
				YfLoKOFOHkBmsDeLrJINqoJgfdBs[i] = num;
				if (!IaYnBKdGAXLJJUYKcKIrwcLdJvyT[i])
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis)
					{
						float num2 = HzIOlHJRYcDpORuJITPEIKgEEJzIA(axes_orig[i].sourceAxis);
						IaYnBKdGAXLJJUYKcKIrwcLdJvyT[i] = num2 != 0f;
					}
					else
					{
						IaYnBKdGAXLJJUYKcKIrwcLdJvyT[i] = true;
					}
				}
				if (!KOCtFDDOIabeTGjesaCmoXILgaNrA && YfLoKOFOHkBmsDeLrJINqoJgfdBs[i] != 0f)
				{
					KOCtFDDOIabeTGjesaCmoXILgaNrA = true;
				}
			}
		}

		private void eVhPgKUIwZyGaTlvvzdxWzILOpns()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_Fallback_Base)AWCbIECppuLDtCThiwONsElGeIEub.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= JUTanEOVBHbwVHQHKsAHkvZOyxmj)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				bool flag = raLPokxvYPjAARjYkxPNzamygBsx(buttons_orig[i]);
				if (iBbGdzIuvxfCvxbSBnLZfvrWDwZPA[i] != flag)
				{
					iBbGdzIuvxfCvxbSBnLZfvrWDwZPA[i] = flag;
					if (!KOCtFDDOIabeTGjesaCmoXILgaNrA && iBbGdzIuvxfCvxbSBnLZfvrWDwZPA[i])
					{
						KOCtFDDOIabeTGjesaCmoXILgaNrA = true;
					}
				}
			}
		}

		private bool raLPokxvYPjAARjYkxPNzamygBsx(HardwareJoystickMap.Platform_Fallback_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (raLPokxvYPjAARjYkxPNzamygBsx(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!raLPokxvYPjAARjYkxPNzamygBsx(P_0.requiredButtons[j]))
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
				if (P_0.sourceButton == UnityButton.None)
				{
					return false;
				}
				return raLPokxvYPjAARjYkxPNzamygBsx(P_0.sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return false;
				}
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
				return true;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				if (P_0.unityHat_sourceAxis1 == UnityAxis.None || P_0.unityHat_sourceAxis2 == UnityAxis.None)
				{
					return false;
				}
				UnityAxis unityHat_sourceAxis = P_0.unityHat_sourceAxis1;
				UnityAxis unityHat_sourceAxis2 = P_0.unityHat_sourceAxis2;
				float num2 = HzIOlHJRYcDpORuJITPEIKgEEJzIA(unityHat_sourceAxis);
				float num3 = HzIOlHJRYcDpORuJITPEIKgEEJzIA(unityHat_sourceAxis2);
				float x;
				float y;
				if (P_0.unityHat_checkNeverPressed)
				{
					if (oapYkDcCIPszIKVLGkboPrfWlysH(unityHat_sourceAxis) || oapYkDcCIPszIKVLGkboPrfWlysH(unityHat_sourceAxis2))
					{
						x = P_0.unityHat_zeroValues.x;
						y = P_0.unityHat_zeroValues.y;
					}
					else
					{
						x = P_0.unityHat_neverPressedZeroValues.x;
						y = P_0.unityHat_neverPressedZeroValues.y;
					}
				}
				else
				{
					x = P_0.unityHat_zeroValues.x;
					y = P_0.unityHat_zeroValues.y;
				}
				if (MathTools.Approximately(num2, x) && MathTools.Approximately(num3, y))
				{
					return false;
				}
				if (YGXszIhcyyRtmpKCztmpojcNFoXdA(P_0.unityHat_isActiveAxisValues1.x, num2) && YGXszIhcyyRtmpKCztmpojcNFoXdA(P_0.unityHat_isActiveAxisValues1.y, num3))
				{
					return true;
				}
				if (YGXszIhcyyRtmpKCztmpojcNFoXdA(P_0.unityHat_isActiveAxisValues2.x, num2) && YGXszIhcyyRtmpKCztmpojcNFoXdA(P_0.unityHat_isActiveAxisValues2.y, num3))
				{
					return true;
				}
				if (YGXszIhcyyRtmpKCztmpojcNFoXdA(P_0.unityHat_isActiveAxisValues3.x, num2) && YGXszIhcyyRtmpKCztmpojcNFoXdA(P_0.unityHat_isActiveAxisValues3.y, num3))
				{
					return true;
				}
			}
			else
			{
				if (P_0.sourceType == HardwareElementSourceTypeWithHat.Key)
				{
					if (P_0.sourceKeyCode == KeyCode.None)
					{
						return false;
					}
					return Input.GetKey(P_0.sourceKeyCode);
				}
				if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					CustomCalculation customCalculation = P_0.customCalculation;
					if (customCalculation == null)
					{
						return false;
					}
					if (customCalculation.ResultType != TypeWrapper.DataType.Single)
					{
						return false;
					}
					HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
					if (customCalculationSourceData == null)
					{
						return false;
					}
					for (int k = 0; k < customCalculationSourceData.Length; k++)
					{
						if (customCalculationSourceData[k] == null)
						{
							continue;
						}
						switch ((HardwareElementSourceTypeWithHat)customCalculationSourceData[k].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Button:
						{
							if (iZUbynatOAUdIpePaHaeivteJHZEc(customCalculationSourceData[k], out var flag3))
							{
								customCalculation.AddData(flag3 ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Axis:
						{
							if (ZpVoWsSVrcfJQAAnJIerZMTLJOiS(customCalculationSourceData[k], out var num4))
							{
								customCalculation.AddData((num4 != 0f) ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Key:
						{
							if (eaMCBSFwealoDiVCYNZuSXPjHISg(customCalculationSourceData[k], out var flag2))
							{
								customCalculation.AddData(flag2 ? 1f : 0f);
							}
							break;
						}
						}
					}
					if (!customCalculation.Process())
					{
						return false;
					}
					if (customCalculation.Result.type != TypeWrapper.DataType.Single)
					{
						return false;
					}
					return (float)customCalculation.Result != 0f;
				}
			}
			return false;
		}

		private bool YGXszIhcyyRtmpKCztmpojcNFoXdA(float P_0, float P_1)
		{
			return MathTools.IsNear(P_1, P_0, 0.1f);
		}

		private float HzIOlHJRYcDpORuJITPEIKgEEJzIA(HardwareJoystickMap.Platform_Fallback_Base.Axis P_0)
		{
			switch (P_0.sourceType)
			{
			case HardwareElementSourceTypeWithHat.Axis:
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return 0f;
				}
				if (!oapYkDcCIPszIKVLGkboPrfWlysH(P_0.sourceAxis))
				{
					return 0f;
				}
				return HzIOlHJRYcDpORuJITPEIKgEEJzIA(P_0.sourceAxis);
			case HardwareElementSourceTypeWithHat.Button:
				if (P_0.sourceButton == UnityButton.None)
				{
					return 0f;
				}
				if (!raLPokxvYPjAARjYkxPNzamygBsx(P_0.sourceButton))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			case HardwareElementSourceTypeWithHat.Key:
				if (P_0.sourceKeyCode == KeyCode.None)
				{
					return 0f;
				}
				if (!Input.GetKey(P_0.sourceKeyCode))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			case HardwareElementSourceTypeWithHat.Custom:
			{
				CustomCalculation customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					return 0f;
				}
				for (int i = 0; i < customCalculationSourceData.Length; i++)
				{
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && ZpVoWsSVrcfJQAAnJIerZMTLJOiS(customCalculationSourceData[i], out var item))
					{
						customCalculation.AddData(item);
					}
				}
				if (!customCalculation.Process())
				{
					return 0f;
				}
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				return customCalculation.Result;
			}
			default:
				return 0f;
			}
		}

		private float HzIOlHJRYcDpORuJITPEIKgEEJzIA(UnityAxis P_0)
		{
			if (P_0 == UnityAxis.None)
			{
				return 0f;
			}
			int num = (int)(P_0 - 1);
			return NCOIpjSNzzDUnBqJKZoWnmcPgTuN[num];
		}

		private bool raLPokxvYPjAARjYkxPNzamygBsx(UnityButton P_0)
		{
			int buttonIndex = (int)(P_0 - 1);
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(XnxPMcDVeYJBWHnXiEncxXfStLbv, buttonIndex);
		}

		private bool iZUbynatOAUdIpePaHaeivteJHZEc(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
		{
			P_1 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			UnityButton sourceElement = (UnityButton)P_0.sourceElement;
			if (sourceElement == UnityButton.None)
			{
				return false;
			}
			P_1 = raLPokxvYPjAARjYkxPNzamygBsx(sourceElement);
			return true;
		}

		private bool eaMCBSFwealoDiVCYNZuSXPjHISg(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
		{
			P_1 = false;
			if (P_0.sourceType != 3)
			{
				return false;
			}
			KeyCode sourceElement = (KeyCode)P_0.sourceElement;
			if (sourceElement == KeyCode.None)
			{
				return false;
			}
			P_1 = Input.GetKey(sourceElement);
			return true;
		}

		private bool ZpVoWsSVrcfJQAAnJIerZMTLJOiS(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				return false;
			}
			UnityAxis sourceElement = (UnityAxis)P_0.sourceElement;
			if (sourceElement == UnityAxis.None)
			{
				return false;
			}
			P_1 = HzIOlHJRYcDpORuJITPEIKgEEJzIA(sourceElement);
			switch (P_0.sourceAxisRange)
			{
			case AxisRange.Negative:
				if (P_1 > 0f)
				{
					P_1 = 0f;
				}
				break;
			case AxisRange.Positive:
				if (P_1 < 0f)
				{
					P_1 = 0f;
				}
				break;
			}
			if (P_0.deadzone > 0f && MathTools.Abs(P_1) <= P_0.deadzone)
			{
				P_1 = 0f;
			}
			if (P_0.invert)
			{
				P_1 *= -1f;
			}
			return true;
		}

		private bool oapYkDcCIPszIKVLGkboPrfWlysH(UnityAxis P_0)
		{
			int num = (int)(P_0 - 1);
			return abnnaTyAdAjUEBBSvaawpkNwfnnvA[num];
		}

		private void QUChOlDwNBGjhwrZDvEmAwZUZaZWA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = CbTPOuTrRpsQMrnAdeZCLmbrivjbA();
			if (UnityTools.isAndroidPlatform)
			{
				if (Regex.IsMatch(WWkhxeFfUZaGTHMZoSdMWgSzynWT, "Xbox Wireless Controller.*"))
				{
					UnityTools.externalTools.GetDeviceVIDPIDs(out var vids, out var pids);
					for (int i = 0; i < vids.Count; i++)
					{
						if (vids[i] == 1118 && pids[i] == 736)
						{
							bridgedControllerHWInfo.definitionMatchTag = "[FW1]";
							break;
						}
					}
				}
				else if (UnityTools.qzTujNnjGDlxsPwAaUDjnOIzcOGM != null)
				{
					IAndroidFallbackDS4Helper ds4Helper = UnityTools.qzTujNnjGDlxsPwAaUDjnOIzcOGM.ds4Helper;
					if (ds4Helper != null && ds4Helper.IsDS4(WWkhxeFfUZaGTHMZoSdMWgSzynWT))
					{
						if (ds4Helper.IsDS4KeyMapped(WjaavdqYYofItFUSBKFDHrqFoasn))
						{
							bridgedControllerHWInfo.definitionMatchTag = "[KEYMAP]";
						}
						else
						{
							bridgedControllerHWInfo.definitionMatchTag = "[NOKEYMAP]";
						}
					}
				}
			}
			AWCbIECppuLDtCThiwONsElGeIEub = ReInput.GetHardwareJoystickMap_InputManager(bridgedControllerHWInfo);
			if (AWCbIECppuLDtCThiwONsElGeIEub == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			if (UnityTools.isIOSPlatform && AWCbIECppuLDtCThiwONsElGeIEub.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController)
			{
				string text = FGXkAijAGpQylbjHVflWGmBliDzDA(WWkhxeFfUZaGTHMZoSdMWgSzynWT);
				if (!string.IsNullOrEmpty(text))
				{
					AWCbIECppuLDtCThiwONsElGeIEub.controllerName = text;
					if (AWCbIECppuLDtCThiwONsElGeIEub.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(AWCbIECppuLDtCThiwONsElGeIEub.deviceLocalizationInfo.parentKeys[0]))
					{
						AWCbIECppuLDtCThiwONsElGeIEub.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(AWCbIECppuLDtCThiwONsElGeIEub.deviceLocalizationInfo.parentKeys[0], text));
					}
					AWCbIECppuLDtCThiwONsElGeIEub.deviceLocalizationInfo.additionalIdentifyingInformation = text;
				}
			}
			else if (AWCbIECppuLDtCThiwONsElGeIEub.useSystemName && !string.IsNullOrEmpty(WWkhxeFfUZaGTHMZoSdMWgSzynWT))
			{
				string text2 = Regex.Replace(WWkhxeFfUZaGTHMZoSdMWgSzynWT, "\\s+", " ");
				text2 = text2.Trim();
				if (!string.IsNullOrEmpty(text2))
				{
					AWCbIECppuLDtCThiwONsElGeIEub.controllerName = text2;
					if (AWCbIECppuLDtCThiwONsElGeIEub.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(AWCbIECppuLDtCThiwONsElGeIEub.deviceLocalizationInfo.parentKeys[0]))
					{
						AWCbIECppuLDtCThiwONsElGeIEub.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(AWCbIECppuLDtCThiwONsElGeIEub.deviceLocalizationInfo.parentKeys[0], text2));
					}
					AWCbIECppuLDtCThiwONsElGeIEub.deviceLocalizationInfo.additionalIdentifyingInformation = text2;
				}
			}
			MXkNViMtSkCXhVAqsNOXkqgyAXmH = AWCbIECppuLDtCThiwONsElGeIEub.axisCount;
			JUTanEOVBHbwVHQHKsAHkvZOyxmj = AWCbIECppuLDtCThiwONsElGeIEub.buttonCount;
		}

		private void csDwaLbbpqniYeCtbmAvRaFuJHyd()
		{
			Array.Clear(iBbGdzIuvxfCvxbSBnLZfvrWDwZPA, 0, iBbGdzIuvxfCvxbSBnLZfvrWDwZPA.Length);
			Array.Clear(YfLoKOFOHkBmsDeLrJINqoJgfdBs, 0, YfLoKOFOHkBmsDeLrJINqoJgfdBs.Length);
		}

		private string OFTaxqRnIObDkzwyLzlCIkEhFxYg()
		{
			if (ReInput.currentPlatform == Platform.Webplayer)
			{
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{MvFScWscrxeEtNjKiqsXvDnglmgC().ToString()}{WWkhxeFfUZaGTHMZoSdMWgSzynWT}");
			}
			if (UnityTools.isIOSPlatform)
			{
				string arg = Regex.Replace(WWkhxeFfUZaGTHMZoSdMWgSzynWT, "joystick [0-9]+ by ", "");
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{MvFScWscrxeEtNjKiqsXvDnglmgC().ToString()}{arg}");
			}
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{MvFScWscrxeEtNjKiqsXvDnglmgC().ToString()}{WWkhxeFfUZaGTHMZoSdMWgSzynWT}");
		}

		private InputSource MvFScWscrxeEtNjKiqsXvDnglmgC()
		{
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(WWkhxeFfUZaGTHMZoSdMWgSzynWT))
			{
				return InputSource.Fallback_PreConfigured;
			}
			return InputSource.Fallback;
		}

		public static int bysvDFWAHFIftaGNXVmikMUoHVvnA(XOzFcGbsRRLbaSAchCXEukINevyoA P_0, XOzFcGbsRRLbaSAchCXEukINevyoA P_1)
		{
			if (P_0.inputManagerId < P_1.inputManagerId)
			{
				return -1;
			}
			if (P_0.inputManagerId > P_1.inputManagerId)
			{
				return 1;
			}
			return 0;
		}

		public static int pRyNEShAnKWtVYAoCetQuGyzUbyn(XOzFcGbsRRLbaSAchCXEukINevyoA P_0, XOzFcGbsRRLbaSAchCXEukINevyoA P_1)
		{
			if (P_0.unityId < P_1.unityId)
			{
				return -1;
			}
			if (P_0.unityId > P_1.unityId)
			{
				return 1;
			}
			return 0;
		}

		private static string FGXkAijAGpQylbjHVflWGmBliDzDA(string P_0)
		{
			string input = Regex.Replace(P_0, "\\[.*\\] joystick [0-9]+ by ", "");
			input = Regex.Replace(input, "\\s+", " ");
			if (!string.IsNullOrEmpty(input))
			{
				input = input.Trim();
			}
			return input;
		}
	}

	private class nZKtUeuYZCbALjdVzeKtJKkFBydGb
	{
		public enum UdLnDMDBEfKdIsyLTfKBVlQSbuBGA
		{
			Exact = 0,
			Approximate = 1
		}

		public class ZtHqZuvmFxrbFnRCbundQdIYwCzf
		{
			public int PoDKkXNZKOoZdyxGaKFAmJnBpZjC;

			public int WjaavdqYYofItFUSBKFDHrqFoasn;

			public string JDXbjCEHJBBbpZUnyLpKiAJcbjjdb;

			public int LDliaNeAUqfNlGOOcEgvxJDercVuA;

			public string nhThQQCNiKeXRJirNPvVqwWWjFgi;

			public bool TUibHCXgdJpNwgxVPYRazOMZLYAI(XOzFcGbsRRLbaSAchCXEukINevyoA P_0, UdLnDMDBEfKdIsyLTfKBVlQSbuBGA P_1)
			{
				if (P_0.rewiredId == PoDKkXNZKOoZdyxGaKFAmJnBpZjC)
				{
					return true;
				}
				if ((!string.IsNullOrEmpty(nhThQQCNiKeXRJirNPvVqwWWjFgi) || !string.IsNullOrEmpty(P_0.nhThQQCNiKeXRJirNPvVqwWWjFgi)) && !string.Equals(nhThQQCNiKeXRJirNPvVqwWWjFgi, P_0.nhThQQCNiKeXRJirNPvVqwWWjFgi, StringComparison.Ordinal))
				{
					return false;
				}
				switch (P_1)
				{
				case UdLnDMDBEfKdIsyLTfKBVlQSbuBGA.Exact:
					if (WjaavdqYYofItFUSBKFDHrqFoasn == P_0.WjaavdqYYofItFUSBKFDHrqFoasn)
					{
						return JDXbjCEHJBBbpZUnyLpKiAJcbjjdb == P_0.WWkhxeFfUZaGTHMZoSdMWgSzynWT;
					}
					return false;
				case UdLnDMDBEfKdIsyLTfKBVlQSbuBGA.Approximate:
					return JDXbjCEHJBBbpZUnyLpKiAJcbjjdb == P_0.WWkhxeFfUZaGTHMZoSdMWgSzynWT;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class BudwfxmQrrmoeadDeiNXDPaJxDuPA : IDisposable, IEnumerable<ZtHqZuvmFxrbFnRCbundQdIYwCzf>, IEnumerator<ZtHqZuvmFxrbFnRCbundQdIYwCzf>, IEnumerable, IEnumerator
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ZtHqZuvmFxrbFnRCbundQdIYwCzf vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public nZKtUeuYZCbALjdVzeKtJKkFBydGb zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private XOzFcGbsRRLbaSAchCXEukINevyoA PPLekmpxyeaCalMMLsyiHANzmPht;

			public XOzFcGbsRRLbaSAchCXEukINevyoA dPHIVjRDubtebhsvurMEHsmzsQyy;

			private UdLnDMDBEfKdIsyLTfKBVlQSbuBGA eTKuBlPFOuiTvIIHBAuXRdCOKbbbb;

			public UdLnDMDBEfKdIsyLTfKBVlQSbuBGA ADPaiKhTaBrtDUTfHyDEtiWqEVVk;

			private int wELWqlBnItHYSvuhGaGHFUnOXsvh;

			private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

			ZtHqZuvmFxrbFnRCbundQdIYwCzf IEnumerator<ZtHqZuvmFxrbFnRCbundQdIYwCzf>.Current
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
			public BudwfxmQrrmoeadDeiNXDPaJxDuPA(int P_0)
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
				nZKtUeuYZCbALjdVzeKtJKkFBydGb nZKtUeuYZCbALjdVzeKtJKkFBydGb2 = zITtixdgVFWlEnpDnrTdnZsdTFkt;
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
				wELWqlBnItHYSvuhGaGHFUnOXsvh = nZKtUeuYZCbALjdVzeKtJKkFBydGb2.kPbexRcNIgkoIUHQQYRQrEHvMBzi.Count;
				PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
				goto IL_0093;
				IL_0083:
				PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
				goto IL_0093;
				IL_0093:
				if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < wELWqlBnItHYSvuhGaGHFUnOXsvh)
				{
					if (nZKtUeuYZCbALjdVzeKtJKkFBydGb2.kPbexRcNIgkoIUHQQYRQrEHvMBzi[PrfhaiCANHhjwtWLxlpNIHvkLSmF].TUibHCXgdJpNwgxVPYRazOMZLYAI(PPLekmpxyeaCalMMLsyiHANzmPht, eTKuBlPFOuiTvIIHBAuXRdCOKbbbb))
					{
						vjnbYLtrPMftzpjohNfommerCnGo = nZKtUeuYZCbALjdVzeKtJKkFBydGb2.kPbexRcNIgkoIUHQQYRQrEHvMBzi[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
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
			IEnumerator<ZtHqZuvmFxrbFnRCbundQdIYwCzf> IEnumerable<ZtHqZuvmFxrbFnRCbundQdIYwCzf>.GetEnumerator()
			{
				BudwfxmQrrmoeadDeiNXDPaJxDuPA budwfxmQrrmoeadDeiNXDPaJxDuPA;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					budwfxmQrrmoeadDeiNXDPaJxDuPA = this;
				}
				else
				{
					budwfxmQrrmoeadDeiNXDPaJxDuPA = new BudwfxmQrrmoeadDeiNXDPaJxDuPA(0);
					budwfxmQrrmoeadDeiNXDPaJxDuPA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				budwfxmQrrmoeadDeiNXDPaJxDuPA.PPLekmpxyeaCalMMLsyiHANzmPht = dPHIVjRDubtebhsvurMEHsmzsQyy;
				budwfxmQrrmoeadDeiNXDPaJxDuPA.eTKuBlPFOuiTvIIHBAuXRdCOKbbbb = ADPaiKhTaBrtDUTfHyDEtiWqEVVk;
				return budwfxmQrrmoeadDeiNXDPaJxDuPA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ZtHqZuvmFxrbFnRCbundQdIYwCzf>)this).GetEnumerator();
			}
		}

		private List<ZtHqZuvmFxrbFnRCbundQdIYwCzf> kPbexRcNIgkoIUHQQYRQrEHvMBzi;

		public int ZQqQltuirEhRybMOxWCRGTiKWPGW => kPbexRcNIgkoIUHQQYRQrEHvMBzi.Count;

		public nZKtUeuYZCbALjdVzeKtJKkFBydGb()
		{
			kPbexRcNIgkoIUHQQYRQrEHvMBzi = new List<ZtHqZuvmFxrbFnRCbundQdIYwCzf>();
		}

		public void etdZpFVoMIOwufjLtmaknStPcvGU(XOzFcGbsRRLbaSAchCXEukINevyoA P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = kPbexRcNIgkoIUHQQYRQrEHvMBzi.Count;
			for (int i = 0; i < count; i++)
			{
				if (kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].TUibHCXgdJpNwgxVPYRazOMZLYAI(P_0, UdLnDMDBEfKdIsyLTfKBVlQSbuBGA.Exact))
				{
					kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].PoDKkXNZKOoZdyxGaKFAmJnBpZjC = P_0.rewiredId;
					kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].JDXbjCEHJBBbpZUnyLpKiAJcbjjdb = P_0.WWkhxeFfUZaGTHMZoSdMWgSzynWT;
					kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].WjaavdqYYofItFUSBKFDHrqFoasn = P_0.WjaavdqYYofItFUSBKFDHrqFoasn;
					kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].LDliaNeAUqfNlGOOcEgvxJDercVuA = P_0.inputManagerId;
					kPbexRcNIgkoIUHQQYRQrEHvMBzi[i].nhThQQCNiKeXRJirNPvVqwWWjFgi = P_0.nhThQQCNiKeXRJirNPvVqwWWjFgi;
					CMjFsiFrLxitfwruosgZvzzbCFuDA(P_0.rewiredId, i);
					return;
				}
			}
			kPbexRcNIgkoIUHQQYRQrEHvMBzi.Add(new ZtHqZuvmFxrbFnRCbundQdIYwCzf
			{
				PoDKkXNZKOoZdyxGaKFAmJnBpZjC = P_0.rewiredId,
				JDXbjCEHJBBbpZUnyLpKiAJcbjjdb = P_0.WWkhxeFfUZaGTHMZoSdMWgSzynWT,
				WjaavdqYYofItFUSBKFDHrqFoasn = P_0.WjaavdqYYofItFUSBKFDHrqFoasn,
				LDliaNeAUqfNlGOOcEgvxJDercVuA = P_0.inputManagerId,
				nhThQQCNiKeXRJirNPvVqwWWjFgi = P_0.nhThQQCNiKeXRJirNPvVqwWWjFgi
			});
			CMjFsiFrLxitfwruosgZvzzbCFuDA(P_0.rewiredId, kPbexRcNIgkoIUHQQYRQrEHvMBzi.Count - 1);
		}

		public bool XrqcBMeuSMEFFHtBARTfiYGSMlVMB(XOzFcGbsRRLbaSAchCXEukINevyoA P_0, UdLnDMDBEfKdIsyLTfKBVlQSbuBGA P_1)
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

		public IEnumerable<ZtHqZuvmFxrbFnRCbundQdIYwCzf> nffAsUegsnbGPpSPyXBkIUXWBpMiA(XOzFcGbsRRLbaSAchCXEukINevyoA P_0, UdLnDMDBEfKdIsyLTfKBVlQSbuBGA P_1)
		{
			return new BudwfxmQrrmoeadDeiNXDPaJxDuPA(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				dPHIVjRDubtebhsvurMEHsmzsQyy = P_0,
				ADPaiKhTaBrtDUTfHyDEtiWqEVVk = P_1
			};
		}

		public int PujFpIgnaejxCcbCzrcoRIpZaecab(ZtHqZuvmFxrbFnRCbundQdIYwCzf P_0)
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

	private List<XOzFcGbsRRLbaSAchCXEukINevyoA> FUWUMuBhggyFQEOUCASaOJmITfwR;

	private int wfXcGbTMFLTAwDvEytkMGYATlJxS;

	private nZKtUeuYZCbALjdVzeKtJKkFBydGb AXHLLNOarmUpwPzyUrjqTImAJvzZ;

	private bool IyVoDwWZYTkSKsbJSXOYyMoCctgEA;

	private bool CosapGKdswHzqcjfhBxrDyHBYfRTB;

	private UpdateLoopType oLPSGLPrThUSDXxJlTVDuFNuQqAB;

	private UpdateLoopType EwvqugXuIIuLKhhMivVhbiaIpWTK;

	private TimerAbs mfVYSrkbZtNqnXauqcmSIoTdEnwe;

	private Action<int, ControllerDataUpdater> HCxdAMptrVyNqjBtiFgxnKPxMREK;

	private PlatformInputManager DOLMBlAuzrRqMqRPSTlLJGeCWdRS;

	private readonly IUnifiedKeyboardSource PzCGgWIamxzzSMcCojDohlTbTTqTb;

	private readonly IUnifiedMouseSource vXGhHLNKblfcbAJFWpwHMnLSDRar;

	private bool taUhEFtCiDQFMSCIuDmAiTuFekrPA;

	private string[] PQucmqRusArzLYydwehEnRBvhYxr;

	[CustomObfuscation(rename = false)]
	public override int deviceCount => wfXcGbTMFLTAwDvEytkMGYATlJxS;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => DOLMBlAuzrRqMqRPSTlLJGeCWdRS;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => null;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.Fallback;

	public hMQIZPyKJMwNVAVsJSknVtsealZN(UpdateLoopSetting P_0)
	{
		DOLMBlAuzrRqMqRPSTlLJGeCWdRS = this;
		PzCGgWIamxzzSMcCojDohlTbTTqTb = new UnityUnifiedKeyboardSource();
		vXGhHLNKblfcbAJFWpwHMnLSDRar = new UnityUnifiedMouseSource();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			int num = 0;
			if (num < list.Count)
			{
				EwvqugXuIIuLKhhMivVhbiaIpWTK = list[num];
			}
		}
		PQucmqRusArzLYydwehEnRBvhYxr = new string[0];
		HCxdAMptrVyNqjBtiFgxnKPxMREK = UpdateControllerData;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.qzTujNnjGDlxsPwAaUDjnOIzcOGM != null)
		{
			UnityTools.qzTujNnjGDlxsPwAaUDjnOIzcOGM.DeviceChangedEvent += BEyVkvRyruPYOEHgTQCNQIGMEuPL;
		}
		mfVYSrkbZtNqnXauqcmSIoTdEnwe = new TimerAbs(1.0);
		AXHLLNOarmUpwPzyUrjqTImAJvzZ = new nZKtUeuYZCbALjdVzeKtJKkFBydGb();
		NNRegRGwZdbXcWVmwpEjRzhQeNlBA();
		IyVoDwWZYTkSKsbJSXOYyMoCctgEA = true;
		mfVYSrkbZtNqnXauqcmSIoTdEnwe.Start();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		oLPSGLPrThUSDXxJlTVDuFNuQqAB = updateLoop;
		HABubbvrkhTwLsxTUiJzjeGKhMmFA();
		if (IyVoDwWZYTkSKsbJSXOYyMoCctgEA)
		{
			FBokPeRBoOhMkvYGDuNRMXWrguuJ();
		}
		qiskyArBYQnsKNKyfKfvpGFiOZus(updateLoop);
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.qzTujNnjGDlxsPwAaUDjnOIzcOGM != null)
		{
			UnityTools.qzTujNnjGDlxsPwAaUDjnOIzcOGM.DeviceChangedEvent -= BEyVkvRyruPYOEHgTQCNQIGMEuPL;
		}
		(PzCGgWIamxzzSMcCojDohlTbTTqTb as IDisposable).Dispose();
		(vXGhHLNKblfcbAJFWpwHMnLSDRar as IDisposable).Dispose();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return HCxdAMptrVyNqjBtiFgxnKPxMREK;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < wfXcGbTMFLTAwDvEytkMGYATlJxS; i++)
		{
			if (FUWUMuBhggyFQEOUCASaOJmITfwR[i].inputManagerId == assignedControllerId)
			{
				FUWUMuBhggyFQEOUCASaOJmITfwR[i].FillData(data);
				return;
			}
		}
		Rewired.Logger.LogError("Invalid joystick Id " + assignedControllerId + "!");
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

	private void BEyVkvRyruPYOEHgTQCNQIGMEuPL()
	{
		IyVoDwWZYTkSKsbJSXOYyMoCctgEA = true;
		CosapGKdswHzqcjfhBxrDyHBYfRTB = true;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		for (int i = 0; i < FUWUMuBhggyFQEOUCASaOJmITfwR.Count; i++)
		{
			if (FUWUMuBhggyFQEOUCASaOJmITfwR[i].unityId == unityJoystickId)
			{
				FUWUMuBhggyFQEOUCASaOJmITfwR[i].LBzVtFJIkcPPzVDXtIaEDVWUHolP();
			}
		}
		for (int j = 0; j < FUWUMuBhggyFQEOUCASaOJmITfwR.Count; j++)
		{
			if (FUWUMuBhggyFQEOUCASaOJmITfwR[j].rewiredId == joystickId)
			{
				FUWUMuBhggyFQEOUCASaOJmITfwR[j].cOcSPELJlsFTkIVjGVEDCMKXCFWSA(unityJoystickId);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return vXGhHLNKblfcbAJFWpwHMnLSDRar;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return PzCGgWIamxzzSMcCojDohlTbTTqTb;
	}

	private void NNRegRGwZdbXcWVmwpEjRzhQeNlBA()
	{
		NNRegRGwZdbXcWVmwpEjRzhQeNlBA(Input.GetJoystickNames());
	}

	private void NNRegRGwZdbXcWVmwpEjRzhQeNlBA(string[] P_0)
	{
		int num = 0;
		List<XOzFcGbsRRLbaSAchCXEukINevyoA> fUWUMuBhggyFQEOUCASaOJmITfwR = FUWUMuBhggyFQEOUCASaOJmITfwR;
		int num2 = wfXcGbTMFLTAwDvEytkMGYATlJxS;
		FUWUMuBhggyFQEOUCASaOJmITfwR = new List<XOzFcGbsRRLbaSAchCXEukINevyoA>();
		for (int i = 0; i < P_0.Length; i++)
		{
			string text = StringTools.SanitizeDeviceString(P_0[i]);
			if (UnityTools.IsValidUnityJoystickName(text))
			{
				XOzFcGbsRRLbaSAchCXEukINevyoA xOzFcGbsRRLbaSAchCXEukINevyoA = new XOzFcGbsRRLbaSAchCXEukINevyoA();
				xOzFcGbsRRLbaSAchCXEukINevyoA.WWkhxeFfUZaGTHMZoSdMWgSzynWT = text;
				xOzFcGbsRRLbaSAchCXEukINevyoA.hRZPRklmxuLdfxuIMUpivvXNqsjL = text;
				xOzFcGbsRRLbaSAchCXEukINevyoA.WjaavdqYYofItFUSBKFDHrqFoasn = i;
				xOzFcGbsRRLbaSAchCXEukINevyoA.unityId = i + 1;
				if (UnityTools.isAndroidPlatform && UnityTools.qzTujNnjGDlxsPwAaUDjnOIzcOGM != null)
				{
					xOzFcGbsRRLbaSAchCXEukINevyoA.nhThQQCNiKeXRJirNPvVqwWWjFgi = UnityTools.qzTujNnjGDlxsPwAaUDjnOIzcOGM.GetUniqueDeviceIdentifier(text, i);
				}
				xOzFcGbsRRLbaSAchCXEukINevyoA.nUvScElMaHbXPGbUJUjTDRAbOMntA();
				FUWUMuBhggyFQEOUCASaOJmITfwR.Add(xOzFcGbsRRLbaSAchCXEukINevyoA);
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
		PQucmqRusArzLYydwehEnRBvhYxr = P_0;
	}

	private void qiskyArBYQnsKNKyfKfvpGFiOZus(UpdateLoopType P_0)
	{
		int count = FUWUMuBhggyFQEOUCASaOJmITfwR.Count;
		for (int i = 0; i < count; i++)
		{
			if (FUWUMuBhggyFQEOUCASaOJmITfwR[i] != null)
			{
				FUWUMuBhggyFQEOUCASaOJmITfwR[i].Update();
			}
		}
	}

	private void RQriXSiYZlIhQlOKVPdgXgEmWHZ(int P_0, int P_1, List<XOzFcGbsRRLbaSAchCXEukINevyoA> P_2, List<XOzFcGbsRRLbaSAchCXEukINevyoA> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(XOzFcGbsRRLbaSAchCXEukINevyoA.pRyNEShAnKWtVYAoCetQuGyzUbyn);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			JiISXIZWxNkSNAJJXCzTcwRWcJrX(P_1, P_3, P_0, P_2, nZKtUeuYZCbALjdVzeKtJKkFBydGb.UdLnDMDBEfKdIsyLTfKBVlQSbuBGA.Exact);
			JiISXIZWxNkSNAJJXCzTcwRWcJrX(P_1, P_3, P_0, P_2, nZKtUeuYZCbALjdVzeKtJKkFBydGb.UdLnDMDBEfKdIsyLTfKBVlQSbuBGA.Approximate);
		}
		ZxMnClrqCkkIKuhtkAkNIZRLlMiT(P_1, P_3, nZKtUeuYZCbALjdVzeKtJKkFBydGb.UdLnDMDBEfKdIsyLTfKBVlQSbuBGA.Exact);
		ZxMnClrqCkkIKuhtkAkNIZRLlMiT(P_1, P_3, nZKtUeuYZCbALjdVzeKtJKkFBydGb.UdLnDMDBEfKdIsyLTfKBVlQSbuBGA.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			XOzFcGbsRRLbaSAchCXEukINevyoA xOzFcGbsRRLbaSAchCXEukINevyoA = P_3[i];
			if (xOzFcGbsRRLbaSAchCXEukINevyoA != null && xOzFcGbsRRLbaSAchCXEukINevyoA.inputManagerId < 0)
			{
				xOzFcGbsRRLbaSAchCXEukINevyoA.inputManagerId = oascgJGqUakhIBruUtJygUsrPpREb(P_3);
				xOzFcGbsRRLbaSAchCXEukINevyoA.rewiredId = ReInput.GetNewJoystickId();
				AXHLLNOarmUpwPzyUrjqTImAJvzZ.etdZpFVoMIOwufjLtmaknStPcvGU(xOzFcGbsRRLbaSAchCXEukINevyoA);
			}
		}
		P_3.Sort(XOzFcGbsRRLbaSAchCXEukINevyoA.bysvDFWAHFIftaGNXVmikMUoHVvnA);
	}

	private void solUsRNigSZftXBPocPDmTnjvCBg(List<XOzFcGbsRRLbaSAchCXEukINevyoA> P_0, int P_1, int P_2)
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

	private bool klYqnApnwEMvDnQFJsQkzFXkxtRX(List<XOzFcGbsRRLbaSAchCXEukINevyoA> P_0, int P_1)
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

	private int oascgJGqUakhIBruUtJygUsrPpREb(List<XOzFcGbsRRLbaSAchCXEukINevyoA> P_0)
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

	private bool cXRIFomJuhRUSXTyIOAgnIYsipeg(List<XOzFcGbsRRLbaSAchCXEukINevyoA> P_0, int P_1)
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

	private void JiISXIZWxNkSNAJJXCzTcwRWcJrX(int P_0, List<XOzFcGbsRRLbaSAchCXEukINevyoA> P_1, int P_2, List<XOzFcGbsRRLbaSAchCXEukINevyoA> P_3, nZKtUeuYZCbALjdVzeKtJKkFBydGb.UdLnDMDBEfKdIsyLTfKBVlQSbuBGA P_4)
	{
		int num = ((P_4 != nZKtUeuYZCbALjdVzeKtJKkFBydGb.UdLnDMDBEfKdIsyLTfKBVlQSbuBGA.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			XOzFcGbsRRLbaSAchCXEukINevyoA xOzFcGbsRRLbaSAchCXEukINevyoA = P_1[i];
			if (xOzFcGbsRRLbaSAchCXEukINevyoA == null || xOzFcGbsRRLbaSAchCXEukINevyoA.inputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				XOzFcGbsRRLbaSAchCXEukINevyoA xOzFcGbsRRLbaSAchCXEukINevyoA2 = P_3[j];
				if (xOzFcGbsRRLbaSAchCXEukINevyoA2 != null && !cXRIFomJuhRUSXTyIOAgnIYsipeg(P_1, xOzFcGbsRRLbaSAchCXEukINevyoA2.rewiredId) && xOzFcGbsRRLbaSAchCXEukINevyoA.TUibHCXgdJpNwgxVPYRazOMZLYAI(xOzFcGbsRRLbaSAchCXEukINevyoA2) >= num)
				{
					xOzFcGbsRRLbaSAchCXEukINevyoA.inputManagerId = xOzFcGbsRRLbaSAchCXEukINevyoA2.inputManagerId;
					xOzFcGbsRRLbaSAchCXEukINevyoA.rewiredId = xOzFcGbsRRLbaSAchCXEukINevyoA2.rewiredId;
					if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
					{
						xOzFcGbsRRLbaSAchCXEukINevyoA.unityId = xOzFcGbsRRLbaSAchCXEukINevyoA2.unityId;
					}
					AXHLLNOarmUpwPzyUrjqTImAJvzZ.etdZpFVoMIOwufjLtmaknStPcvGU(xOzFcGbsRRLbaSAchCXEukINevyoA);
				}
			}
		}
	}

	private void ZxMnClrqCkkIKuhtkAkNIZRLlMiT(int P_0, List<XOzFcGbsRRLbaSAchCXEukINevyoA> P_1, nZKtUeuYZCbALjdVzeKtJKkFBydGb.UdLnDMDBEfKdIsyLTfKBVlQSbuBGA P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			XOzFcGbsRRLbaSAchCXEukINevyoA xOzFcGbsRRLbaSAchCXEukINevyoA = P_1[i];
			if (xOzFcGbsRRLbaSAchCXEukINevyoA == null || xOzFcGbsRRLbaSAchCXEukINevyoA.inputManagerId >= 0)
			{
				continue;
			}
			nZKtUeuYZCbALjdVzeKtJKkFBydGb.ZtHqZuvmFxrbFnRCbundQdIYwCzf ztHqZuvmFxrbFnRCbundQdIYwCzf = null;
			foreach (nZKtUeuYZCbALjdVzeKtJKkFBydGb.ZtHqZuvmFxrbFnRCbundQdIYwCzf item in AXHLLNOarmUpwPzyUrjqTImAJvzZ.nffAsUegsnbGPpSPyXBkIUXWBpMiA(xOzFcGbsRRLbaSAchCXEukINevyoA, P_2))
			{
				if (!cXRIFomJuhRUSXTyIOAgnIYsipeg(P_1, item.PoDKkXNZKOoZdyxGaKFAmJnBpZjC) && item.LDliaNeAUqfNlGOOcEgvxJDercVuA >= 0)
				{
					ztHqZuvmFxrbFnRCbundQdIYwCzf = item;
					break;
				}
			}
			if (ztHqZuvmFxrbFnRCbundQdIYwCzf != null)
			{
				int num = ztHqZuvmFxrbFnRCbundQdIYwCzf.LDliaNeAUqfNlGOOcEgvxJDercVuA;
				if (!klYqnApnwEMvDnQFJsQkzFXkxtRX(P_1, num))
				{
					num = (ztHqZuvmFxrbFnRCbundQdIYwCzf.LDliaNeAUqfNlGOOcEgvxJDercVuA = oascgJGqUakhIBruUtJygUsrPpREb(P_1));
				}
				xOzFcGbsRRLbaSAchCXEukINevyoA.inputManagerId = num;
				xOzFcGbsRRLbaSAchCXEukINevyoA.rewiredId = ztHqZuvmFxrbFnRCbundQdIYwCzf.PoDKkXNZKOoZdyxGaKFAmJnBpZjC;
				AXHLLNOarmUpwPzyUrjqTImAJvzZ.etdZpFVoMIOwufjLtmaknStPcvGU(xOzFcGbsRRLbaSAchCXEukINevyoA);
			}
		}
	}

	private void FBokPeRBoOhMkvYGDuNRMXWrguuJ()
	{
		string[] joystickNames = Input.GetJoystickNames();
		if (CosapGKdswHzqcjfhBxrDyHBYfRTB || yzIJgrQHYsHrxolnFVxYFynuWMug(joystickNames))
		{
			NNRegRGwZdbXcWVmwpEjRzhQeNlBA(joystickNames);
		}
		IyVoDwWZYTkSKsbJSXOYyMoCctgEA = false;
		if (CosapGKdswHzqcjfhBxrDyHBYfRTB)
		{
			CosapGKdswHzqcjfhBxrDyHBYfRTB = false;
		}
	}

	private bool yzIJgrQHYsHrxolnFVxYFynuWMug(string[] P_0)
	{
		if (P_0.Length != PQucmqRusArzLYydwehEnRBvhYxr.Length)
		{
			return true;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (!string.Equals(P_0[i], PQucmqRusArzLYydwehEnRBvhYxr[i], StringComparison.Ordinal))
			{
				return true;
			}
		}
		return false;
	}

	private void MMDbBEBBOxkQPFDselRRsAlEXjucA(List<XOzFcGbsRRLbaSAchCXEukINevyoA> P_0, List<XOzFcGbsRRLbaSAchCXEukINevyoA> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			XOzFcGbsRRLbaSAchCXEukINevyoA xOzFcGbsRRLbaSAchCXEukINevyoA = P_0[i];
			if (xOzFcGbsRRLbaSAchCXEukINevyoA == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					XOzFcGbsRRLbaSAchCXEukINevyoA xOzFcGbsRRLbaSAchCXEukINevyoA2 = P_1[j];
					if (xOzFcGbsRRLbaSAchCXEukINevyoA2 != null && xOzFcGbsRRLbaSAchCXEukINevyoA.rewiredId == xOzFcGbsRRLbaSAchCXEukINevyoA2.rewiredId)
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

	private void ajbGTsFPidClCieJTDaEyrhzPGaV(XOzFcGbsRRLbaSAchCXEukINevyoA P_0, bool P_1)
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

	private void HABubbvrkhTwLsxTUiJzjeGKhMmFA()
	{
		if (oLPSGLPrThUSDXxJlTVDuFNuQqAB == EwvqugXuIIuLKhhMivVhbiaIpWTK && mfVYSrkbZtNqnXauqcmSIoTdEnwe.Update())
		{
			IyVoDwWZYTkSKsbJSXOYyMoCctgEA = true;
			mfVYSrkbZtNqnXauqcmSIoTdEnwe.Start();
		}
	}
}
