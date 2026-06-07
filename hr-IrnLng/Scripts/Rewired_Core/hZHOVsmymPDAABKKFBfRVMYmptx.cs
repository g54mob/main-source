using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using Rewired;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.InputSources.SDL2;
using Rewired.Interfaces;
using Rewired.Utils;

internal class hZHOVsmymPDAABKKFBfRVMYmptx : PlatformInputManager
{
	private class wAwgwPsralJpdsDBnMFJGEQwfJn : IInputManagerJoystickPublic, IInputManagerJoystick
	{
		private int jIpZegDsRCglpRpWZFkZhlMabSZS;

		private int sVCXCYtCFTJlHfQcwXhLqojaMtg;

		public Guid ndgbjpxTbxrFsttqZvzramhIWKV;

		public string nFsFNfbJDyCpcjknUKIrJJGWPCEl;

		public PECWzsyRHQmqJrheqhVEuVmEOuh llSbbcEmgPDyYqJudCgZifokjdS;

		public pqiQSYfiKDanXPEDRCELKcWEpuKg sklTyGKEuKrtnkivSotkvjbnDxA;

		public string fUmMSGRebexnyEYaqpVhNhnGvJi;

		public string iiSTExMiHYwCqXJDsMrnFbtdknJ;

		public int RlmaoXaMoKUZWqFptaxMnKyGgXWx;

		public int xWIfnycVeScryAKfrRyhksBsyEww;

		public Guid AYBEJbMugfcrciXWIEYsYfFwyNm;

		public PidVid xkvdTpabuwPDnVPwRjEibxPKerR;

		public Guid wCCXbXuXNHjbbJqNArKcbmlKkEH;

		public int EzjAOQiiOgRjrBlkextjpAQsAmTW;

		public int IzBqqGEfNsVzhrHRyHZJoAYcmhT;

		public int LoOFdmbheTAsuESCDdMXosrfRrI;

		public int ZbmMjjdtBUhdwuFWNNTANLGAfCs;

		public int QiFfGNetbcVqCvKCLrtCBhIIKvgZ;

		public int vRPfUqytaYtfWFfAbsznwaBZjhT;

		public bool zMvToNbUaokPYhGbImlUtxjMXck;

		public bool GkLKAMFRzbMjZIZtziMXVcnFggPj;

		public int HSFfOkgYdavTAaqGDaWBzgNaSgu;

		private float[] jzpVEtuClUvVjBdDtjXvLsbzhOL;

		private bool[] HgTlEIPAcVpesdxuHAohUBSLbkRC;

		private HardwareJoystickMap_InputManager rEqQznEUmYwtoLNJsErzjlKjjYY;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> BtXgoZzfyixretGRKXdmAjlGRaR;

		private bool MuyJtErmXPtRECIwLGUdXgzIPIS;

		private bool lIckeksaZUISOlJWqVjEgKdCPmH;

		[CompilerGenerated]
		private Controller.Extension gEEulInraWAPfQDmDEbakVnonQMO;

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return jIpZegDsRCglpRpWZFkZhlMabSZS;
			}
			set
			{
				jIpZegDsRCglpRpWZFkZhlMabSZS = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return sVCXCYtCFTJlHfQcwXhLqojaMtg;
			}
			set
			{
				sVCXCYtCFTJlHfQcwXhLqojaMtg = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name => nFsFNfbJDyCpcjknUKIrJJGWPCEl;

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (sVCXCYtCFTJlHfQcwXhLqojaMtg < 0)
				{
					return null;
				}
				return sVCXCYtCFTJlHfQcwXhLqojaMtg;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId => 0;

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => AYBEJbMugfcrciXWIEYsYfFwyNm;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension
		{
			[CompilerGenerated]
			get
			{
				return gEEulInraWAPfQDmDEbakVnonQMO;
			}
			[CompilerGenerated]
			set
			{
				gEEulInraWAPfQDmDEbakVnonQMO = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			llSbbcEmgPDyYqJudCgZifokjdS.GrEBJDcBfbuRYGVsYRbMDagpoXIG(motorIndex, amount, false);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		public wAwgwPsralJpdsDBnMFJGEQwfJn(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			BtXgoZzfyixretGRKXdmAjlGRaR = getHardwareJoystickMap_InputManager;
			sVCXCYtCFTJlHfQcwXhLqojaMtg = -1;
			jIpZegDsRCglpRpWZFkZhlMabSZS = -1;
		}

		public void KfBKHnOxjftuCpCkJBMbkWxcLWv()
		{
			wCCXbXuXNHjbbJqNArKcbmlKkEH = MiscTools.CreateGuidHashSHA1(fUmMSGRebexnyEYaqpVhNhnGvJi + xkvdTpabuwPDnVPwRjEibxPKerR.ToProductGuid());
			IzBqqGEfNsVzhrHRyHZJoAYcmhT = ZbmMjjdtBUhdwuFWNNTANLGAfCs;
			LoOFdmbheTAsuESCDdMXosrfRrI = QiFfGNetbcVqCvKCLrtCBhIIKvgZ + vRPfUqytaYtfWFfAbsznwaBZjhT * 8;
			nXglhCVRQvdNmlZfFNtWDSyReON();
			ndgbjpxTbxrFsttqZvzramhIWKV = rEqQznEUmYwtoLNJsErzjlKjjYY.hardwareMapIdentifier.guid;
			nFsFNfbJDyCpcjknUKIrJJGWPCEl = rEqQznEUmYwtoLNJsErzjlKjjYY.controllerName;
			MuyJtErmXPtRECIwLGUdXgzIPIS = ((ndgbjpxTbxrFsttqZvzramhIWKV == Guid.Empty) ? true : false);
			jzpVEtuClUvVjBdDtjXvLsbzhOL = new float[IzBqqGEfNsVzhrHRyHZJoAYcmhT];
			HgTlEIPAcVpesdxuHAohUBSLbkRC = new bool[LoOFdmbheTAsuESCDdMXosrfRrI];
			Update();
		}

		public void AIlTBlatymduYQhsnDZKtmbGMpq(wAwgwPsralJpdsDBnMFJGEQwfJn P_0)
		{
			if (P_0 != null)
			{
				sVCXCYtCFTJlHfQcwXhLqojaMtg = P_0.sVCXCYtCFTJlHfQcwXhLqojaMtg;
				jIpZegDsRCglpRpWZFkZhlMabSZS = P_0.jIpZegDsRCglpRpWZFkZhlMabSZS;
				for (int i = 0; i < MathTools.Min(HgTlEIPAcVpesdxuHAohUBSLbkRC.Length, P_0.HgTlEIPAcVpesdxuHAohUBSLbkRC.Length); i++)
				{
					HgTlEIPAcVpesdxuHAohUBSLbkRC[i] = P_0.HgTlEIPAcVpesdxuHAohUBSLbkRC[i];
				}
				for (int j = 0; j < MathTools.Min(jzpVEtuClUvVjBdDtjXvLsbzhOL.Length, P_0.jzpVEtuClUvVjBdDtjXvLsbzhOL.Length); j++)
				{
					jzpVEtuClUvVjBdDtjXvLsbzhOL[j] = P_0.jzpVEtuClUvVjBdDtjXvLsbzhOL[j];
				}
				lIckeksaZUISOlJWqVjEgKdCPmH = P_0.lIckeksaZUISOlJWqVjEgKdCPmH;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			eDxlTkEkZjIqIOaXTGEydwFFOfoR();
			DmLZJnvnrnNkrBYTnoYZbojIVhn();
			if (!lIckeksaZUISOlJWqVjEgKdCPmH && llSbbcEmgPDyYqJudCgZifokjdS.HasEverReceivedInput)
			{
				lIckeksaZUISOlJWqVjEgKdCPmH = true;
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (IzBqqGEfNsVzhrHRyHZJoAYcmhT != dataUpdater.axisCount || LoOFdmbheTAsuESCDdMXosrfRrI != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < IzBqqGEfNsVzhrHRyHZJoAYcmhT; i++)
			{
				dataUpdater.axisValues[i] = jzpVEtuClUvVjBdDtjXvLsbzhOL[i];
			}
			for (int j = 0; j < LoOFdmbheTAsuESCDdMXosrfRrI; j++)
			{
				dataUpdater.buttonValues[j] = HgTlEIPAcVpesdxuHAohUBSLbkRC[j];
			}
			if (lIckeksaZUISOlJWqVjEgKdCPmH && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public int kGUAgzoWmpBJnomvNrYAMpbELMU(wAwgwPsralJpdsDBnMFJGEQwfJn P_0)
		{
			if (P_0.jIpZegDsRCglpRpWZFkZhlMabSZS == jIpZegDsRCglpRpWZFkZhlMabSZS)
			{
				return 2;
			}
			if (ZbmMjjdtBUhdwuFWNNTANLGAfCs != P_0.ZbmMjjdtBUhdwuFWNNTANLGAfCs)
			{
				return 0;
			}
			if (QiFfGNetbcVqCvKCLrtCBhIIKvgZ != P_0.QiFfGNetbcVqCvKCLrtCBhIIKvgZ)
			{
				return 0;
			}
			if (vRPfUqytaYtfWFfAbsznwaBZjhT != P_0.vRPfUqytaYtfWFfAbsznwaBZjhT)
			{
				return 0;
			}
			if (P_0.AYBEJbMugfcrciXWIEYsYfFwyNm == AYBEJbMugfcrciXWIEYsYfFwyNm)
			{
				return 2;
			}
			if (P_0.wCCXbXuXNHjbbJqNArKcbmlKkEH == wCCXbXuXNHjbbJqNArKcbmlKkEH)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo nGxBhPkTOZfyTEzcjVyqmmIgztnf()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			OZHQiQgSzsqBMEXKRiXEjRuQMNq(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			OZHQiQgSzsqBMEXKRiXEjRuQMNq(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(jIpZegDsRCglpRpWZFkZhlMabSZS);
		}

		private void eDxlTkEkZjIqIOaXTGEydwFFOfoR()
		{
			if (IzBqqGEfNsVzhrHRyHZJoAYcmhT <= 0)
			{
				return;
			}
			InputPlatform platform = rEqQznEUmYwtoLNJsErzjlKjjYY.map.platform;
			if (platform != InputPlatform.HzEUSSCMOAGDmIPBhFeSCXxGOclT)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base platform_SDL2_Base = (HardwareJoystickMap.Platform_SDL2_Base)rEqQznEUmYwtoLNJsErzjlKjjYY.map;
			HardwareJoystickMap.Platform_SDL2_Base.Axis[] axes_orig = platform_SDL2_Base.Axes_orig;
			if (axes_orig != null)
			{
				for (int i = 0; i < axes_orig.Length; i++)
				{
					hepUhCneJOKPOUxrPeaoTuwXEWb(axes_orig[i], i);
				}
			}
		}

		private void DmLZJnvnrnNkrBYTnoYZbojIVhn()
		{
			if (LoOFdmbheTAsuESCDdMXosrfRrI <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base platform_SDL2_Base = (HardwareJoystickMap.Platform_SDL2_Base)rEqQznEUmYwtoLNJsErzjlKjjYY.map;
			HardwareJoystickMap.Platform_SDL2_Base.Button[] buttons_orig = platform_SDL2_Base.Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					lDoYpQiKHhcnUhTCsUIxDhfaczz(buttons_orig[i], i);
				}
			}
		}

		private void hepUhCneJOKPOUxrPeaoTuwXEWb(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0, int P_1)
		{
			if (P_1 >= IzBqqGEfNsVzhrHRyHZJoAYcmhT)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			jzpVEtuClUvVjBdDtjXvLsbzhOL[P_1] = cgmAKoDiHUFFXhNnFYmsRnBjTDvK(P_0);
		}

		private void lDoYpQiKHhcnUhTCsUIxDhfaczz(HardwareJoystickMap.Platform_SDL2_Base.Button P_0, int P_1)
		{
			if (P_1 >= LoOFdmbheTAsuESCDdMXosrfRrI)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			HgTlEIPAcVpesdxuHAohUBSLbkRC[P_1] = YkbkFPCFEvZkXFmauWArEBZdXhq(P_0);
		}

		private float cgmAKoDiHUFFXhNnFYmsRnBjTDvK(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= ZbmMjjdtBUhdwuFWNNTANLGAfCs || sourceAxis >= 56)
				{
					return 0f;
				}
				return llSbbcEmgPDyYqJudCgZifokjdS.cgmAKoDiHUFFXhNnFYmsRnBjTDvK(sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= QiFfGNetbcVqCvKCLrtCBhIIKvgZ || sourceButton >= 256)
				{
					return 0f;
				}
				if (!llSbbcEmgPDyYqJudCgZifokjdS.YkbkFPCFEvZkXFmauWArEBZdXhq(sourceButton))
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
				if (sourceHat < 0 || sourceHat >= vRPfUqytaYtfWFfAbsznwaBZjhT || sourceHat >= 4)
				{
					return 0f;
				}
				int num = llSbbcEmgPDyYqJudCgZifokjdS.fSCEutveMhGuUVKBWGzWxSRAfCfE(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = XYswVZbjAzhBvuxdWgaNNVfZPZT(num, AxisDirection.Horizontal);
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
					num2 = XYswVZbjAzhBvuxdWgaNNVfZPZT(num, AxisDirection.Vertical);
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

		private bool YkbkFPCFEvZkXFmauWArEBZdXhq(HardwareJoystickMap.Platform_SDL2_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (llSbbcEmgPDyYqJudCgZifokjdS.YkbkFPCFEvZkXFmauWArEBZdXhq(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!llSbbcEmgPDyYqJudCgZifokjdS.YkbkFPCFEvZkXFmauWArEBZdXhq(P_0.requiredButtons[j]))
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
				if (sourceButton < 0 || sourceButton >= QiFfGNetbcVqCvKCLrtCBhIIKvgZ || sourceButton >= 256)
				{
					return false;
				}
				return llSbbcEmgPDyYqJudCgZifokjdS.YkbkFPCFEvZkXFmauWArEBZdXhq(sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis <= 0 || sourceAxis >= ZbmMjjdtBUhdwuFWNNTANLGAfCs || sourceAxis >= 56)
				{
					return false;
				}
				float num = llSbbcEmgPDyYqJudCgZifokjdS.cgmAKoDiHUFFXhNnFYmsRnBjTDvK(sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= vRPfUqytaYtfWFfAbsznwaBZjhT || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return KMiArTABKdjcylElVrJmAngICHz(llSbbcEmgPDyYqJudCgZifokjdS.fSCEutveMhGuUVKBWGzWxSRAfCfE(sourceHat), 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return KMiArTABKdjcylElVrJmAngICHz(llSbbcEmgPDyYqJudCgZifokjdS.fSCEutveMhGuUVKBWGzWxSRAfCfE(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return KMiArTABKdjcylElVrJmAngICHz(llSbbcEmgPDyYqJudCgZifokjdS.fSCEutveMhGuUVKBWGzWxSRAfCfE(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return KMiArTABKdjcylElVrJmAngICHz(llSbbcEmgPDyYqJudCgZifokjdS.fSCEutveMhGuUVKBWGzWxSRAfCfE(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return KMiArTABKdjcylElVrJmAngICHz(llSbbcEmgPDyYqJudCgZifokjdS.fSCEutveMhGuUVKBWGzWxSRAfCfE(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return KMiArTABKdjcylElVrJmAngICHz(llSbbcEmgPDyYqJudCgZifokjdS.fSCEutveMhGuUVKBWGzWxSRAfCfE(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return KMiArTABKdjcylElVrJmAngICHz(llSbbcEmgPDyYqJudCgZifokjdS.fSCEutveMhGuUVKBWGzWxSRAfCfE(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return KMiArTABKdjcylElVrJmAngICHz(llSbbcEmgPDyYqJudCgZifokjdS.fSCEutveMhGuUVKBWGzWxSRAfCfE(sourceHat), 7, P_0.sourceHatType);
				}
			}
			return false;
		}

		private bool KMiArTABKdjcylElVrJmAngICHz(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (rEqQznEUmYwtoLNJsErzjlKjjYY.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return false;
			}
			int num = 4500;
			int num2 = num * P_1;
			if (P_2 == HatType.EightWay && P_0 != num2)
			{
				return false;
			}
			int num3;
			int num4;
			if (P_2 == HatType.EightWay)
			{
				num3 = 31500;
				num4 = 4500;
			}
			else
			{
				num3 = 27000;
				num4 = 9000;
			}
			if (P_1 == 0 && P_0 > num3)
			{
				P_0 -= 36000;
			}
			if (P_0 < num2 + num4 && P_0 > num2 - num4)
			{
				return true;
			}
			return false;
		}

		private float XYswVZbjAzhBvuxdWgaNNVfZPZT(int P_0, AxisDirection P_1)
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

		private ControlDeviceType ekpBuSDuWiVPSQHRoOQvgucSxaF(pqiQSYfiKDanXPEDRCELKcWEpuKg P_0)
		{
			return P_0 switch
			{
				pqiQSYfiKDanXPEDRCELKcWEpuKg.SRzHntXksMAdDsrLdjhLausTYzs => ControlDeviceType.SRzHntXksMAdDsrLdjhLausTYzs, 
				pqiQSYfiKDanXPEDRCELKcWEpuKg.FkuTeNINGnHkhHTSsaBIaLcmEbXx => ControlDeviceType.FkuTeNINGnHkhHTSsaBIaLcmEbXx, 
				pqiQSYfiKDanXPEDRCELKcWEpuKg.RCedHXktmDuEaJMNAKkvapTxIktB => ControlDeviceType.RCedHXktmDuEaJMNAKkvapTxIktB, 
				pqiQSYfiKDanXPEDRCELKcWEpuKg.oNtyvjTqZbBsgFbifrnlIOieMqj => ControlDeviceType.oNtyvjTqZbBsgFbifrnlIOieMqj, 
				_ => ControlDeviceType.CxIBFsnaOMTSettXyfvwFIXcUdA, 
			};
		}

		private void nXglhCVRQvdNmlZfFNtWDSyReON()
		{
			rEqQznEUmYwtoLNJsErzjlKjjYY = BtXgoZzfyixretGRKXdmAjlGRaR(nGxBhPkTOZfyTEzcjVyqmmIgztnf());
			if (rEqQznEUmYwtoLNJsErzjlKjjYY == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (rEqQznEUmYwtoLNJsErzjlKjjYY.useSystemName && !string.IsNullOrEmpty(iiSTExMiHYwCqXJDsMrnFbtdknJ))
			{
				string text = Regex.Replace(iiSTExMiHYwCqXJDsMrnFbtdknJ, "\\s+", " ");
				text = text.Trim();
				if (!string.IsNullOrEmpty(text))
				{
					rEqQznEUmYwtoLNJsErzjlKjjYY.controllerName = text;
				}
			}
			IzBqqGEfNsVzhrHRyHZJoAYcmhT = rEqQznEUmYwtoLNJsErzjlKjjYY.axisCount;
			LoOFdmbheTAsuESCDdMXosrfRrI = rEqQznEUmYwtoLNJsErzjlKjjYY.buttonCount;
		}

		private string lzlCfjPlhdUonFFzybxoaeZrLkv()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{llSbbcEmgPDyYqJudCgZifokjdS.InputSource}{fUmMSGRebexnyEYaqpVhNhnGvJi}{RlmaoXaMoKUZWqFptaxMnKyGgXWx}{xkvdTpabuwPDnVPwRjEibxPKerR.ToProductGuid()}");
		}

		private void OZHQiQgSzsqBMEXKRiXEjRuQMNq(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.SDL2;
			P_0.inputSource = llSbbcEmgPDyYqJudCgZifokjdS.InputSource;
			P_0.deviceType = ekpBuSDuWiVPSQHRoOQvgucSxaF(sklTyGKEuKrtnkivSotkvjbnDxA);
			P_0.hardwareIdentifier = lzlCfjPlhdUonFFzybxoaeZrLkv();
			P_0.hardwareAxisCount = ZbmMjjdtBUhdwuFWNNTANLGAfCs;
			P_0.hardwareButtonCount = QiFfGNetbcVqCvKCLrtCBhIIKvgZ;
			P_0.hardwareHatCount = vRPfUqytaYtfWFfAbsznwaBZjhT;
			P_0.hw_productName = fUmMSGRebexnyEYaqpVhNhnGvJi;
			P_0.hw_deviceGuid = AYBEJbMugfcrciXWIEYsYfFwyNm;
			P_0.hw_productId = RlmaoXaMoKUZWqFptaxMnKyGgXWx;
			P_0.hw_pidVid = xkvdTpabuwPDnVPwRjEibxPKerR;
			P_0.hw_isBluetoothDevice = zMvToNbUaokPYhGbImlUtxjMXck;
			P_0.hw_bluetoothDeviceName = fUmMSGRebexnyEYaqpVhNhnGvJi;
			P_0.hw_systemDeviceName = fUmMSGRebexnyEYaqpVhNhnGvJi;
			P_0.hw_supportsVibration = GkLKAMFRzbMjZIZtziMXVcnFggPj;
			P_0.hw_isSDL2Gamepad = llSbbcEmgPDyYqJudCgZifokjdS.DeviceType == pqiQSYfiKDanXPEDRCELKcWEpuKg.FkuTeNINGnHkhHTSsaBIaLcmEbXx;
			P_0.hw_localVibrationMotorCount = HSFfOkgYdavTAaqGDaWBzgNaSgu;
		}

		private void OZHQiQgSzsqBMEXKRiXEjRuQMNq(BridgedController P_0)
		{
			OZHQiQgSzsqBMEXKRiXEjRuQMNq((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = rEqQznEUmYwtoLNJsErzjlKjjYY.ToGameHardwareControllerMap();
			P_0.instanceName = fUmMSGRebexnyEYaqpVhNhnGvJi;
			P_0.productName = fUmMSGRebexnyEYaqpVhNhnGvJi;
			P_0.axisCount = IzBqqGEfNsVzhrHRyHZJoAYcmhT;
			P_0.buttonCount = LoOFdmbheTAsuESCDdMXosrfRrI;
			P_0.unknownControllerHats = rDpSFfYHqedNJkxgKnRnhuYYcoC();
			P_0.controllerTypeGuid = ndgbjpxTbxrFsttqZvzramhIWKV;
			P_0.controllerExtension = extension;
		}

		private void aILttORIOjwAcZKnnhVEedfkbcj()
		{
			for (int i = 0; i < LoOFdmbheTAsuESCDdMXosrfRrI; i++)
			{
				HgTlEIPAcVpesdxuHAohUBSLbkRC[i] = false;
			}
			for (int j = 0; j < IzBqqGEfNsVzhrHRyHZJoAYcmhT; j++)
			{
				jzpVEtuClUvVjBdDtjXvLsbzhOL[j] = 0f;
			}
		}

		private UnknownControllerHat[] rDpSFfYHqedNJkxgKnRnhuYYcoC()
		{
			if (!MuyJtErmXPtRECIwLGUdXgzIPIS)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			for (int i = 0; i < 2; i++)
			{
				int num = 128 + i * 8;
				UnknownControllerHat.HatButtons buttons = new UnknownControllerHat.HatButtons(new int[8]
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
				array[i] = new UnknownControllerHat(buttons);
			}
			return array;
		}

		public static int snpUatNrOhnqYMrVlODtTBLMwGy(wAwgwPsralJpdsDBnMFJGEQwfJn P_0, wAwgwPsralJpdsDBnMFJGEQwfJn P_1)
		{
			if (P_0.sVCXCYtCFTJlHfQcwXhLqojaMtg < P_1.sVCXCYtCFTJlHfQcwXhLqojaMtg)
			{
				return -1;
			}
			if (P_0.sVCXCYtCFTJlHfQcwXhLqojaMtg > P_1.sVCXCYtCFTJlHfQcwXhLqojaMtg)
			{
				return 1;
			}
			return 0;
		}

		public static int sNVFIBbqIFsIaMNbwPoLVnYRpEFk(wAwgwPsralJpdsDBnMFJGEQwfJn P_0, wAwgwPsralJpdsDBnMFJGEQwfJn P_1)
		{
			if (P_0.EzjAOQiiOgRjrBlkextjpAQsAmTW < P_1.EzjAOQiiOgRjrBlkextjpAQsAmTW)
			{
				return -1;
			}
			if (P_0.EzjAOQiiOgRjrBlkextjpAQsAmTW > P_1.EzjAOQiiOgRjrBlkextjpAQsAmTW)
			{
				return 1;
			}
			return 0;
		}
	}

	private class whAvoeXCdJcVugUuJmTYUwehLbD
	{
		public enum KOhWvQSGwsCHteQuXkIGpapsVZM
		{
			JlcFwBXJAZQpAvmagfRVInsQEVib = 0,
			lkctGikYsLMhbYMEyImPMsrGWJw = 1
		}

		public class pzKRJFlbTnhtpuiUbOzqTiaWkkP
		{
			public int sjbjANsWQaKxKgfHgxDuZgoAatr;

			public Guid ocDFctqVRVXkjlFXQuNGYFHpaVHi;

			public Guid wCCXbXuXNHjbbJqNArKcbmlKkEH;

			public int kPTxDqHUNQFlgCKgmbPPsQsvVsL;

			public int ZbmMjjdtBUhdwuFWNNTANLGAfCs;

			public int QiFfGNetbcVqCvKCLrtCBhIIKvgZ;

			public int vRPfUqytaYtfWFfAbsznwaBZjhT;

			public bool kGUAgzoWmpBJnomvNrYAMpbELMU(wAwgwPsralJpdsDBnMFJGEQwfJn P_0, KOhWvQSGwsCHteQuXkIGpapsVZM P_1)
			{
				if (P_0.rewiredId == sjbjANsWQaKxKgfHgxDuZgoAatr)
				{
					return true;
				}
				if (ZbmMjjdtBUhdwuFWNNTANLGAfCs != P_0.ZbmMjjdtBUhdwuFWNNTANLGAfCs)
				{
					return false;
				}
				if (QiFfGNetbcVqCvKCLrtCBhIIKvgZ != P_0.QiFfGNetbcVqCvKCLrtCBhIIKvgZ)
				{
					return false;
				}
				if (vRPfUqytaYtfWFfAbsznwaBZjhT != P_0.vRPfUqytaYtfWFfAbsznwaBZjhT)
				{
					return false;
				}
				return P_1 switch
				{
					KOhWvQSGwsCHteQuXkIGpapsVZM.JlcFwBXJAZQpAvmagfRVInsQEVib => ocDFctqVRVXkjlFXQuNGYFHpaVHi == P_0.AYBEJbMugfcrciXWIEYsYfFwyNm, 
					KOhWvQSGwsCHteQuXkIGpapsVZM.lkctGikYsLMhbYMEyImPMsrGWJw => wCCXbXuXNHjbbJqNArKcbmlKkEH == P_0.wCCXbXuXNHjbbJqNArKcbmlKkEH, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		private sealed class toBCrAKAZipKEYZZAyvVqAvhMzPE : IDisposable, IEnumerator, IEnumerable, IEnumerable<pzKRJFlbTnhtpuiUbOzqTiaWkkP>, IEnumerator<pzKRJFlbTnhtpuiUbOzqTiaWkkP>
		{
			private pzKRJFlbTnhtpuiUbOzqTiaWkkP WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public whAvoeXCdJcVugUuJmTYUwehLbD GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public wAwgwPsralJpdsDBnMFJGEQwfJn gHvYZHUarOaorfxsTfLYBukkoDdr;

			public wAwgwPsralJpdsDBnMFJGEQwfJn UbjxuEellXeMyafFoPliUyZkaWij;

			public KOhWvQSGwsCHteQuXkIGpapsVZM NDuIiQmBXOqfkYsxTjDpIDbLijzg;

			public KOhWvQSGwsCHteQuXkIGpapsVZM bHlBJlWzmhLdKSVRZFPkQzpzAEJ;

			public int RipzaMeXkBzWHlXLENAjqhAXDtl;

			public int mHNUnJhfGxhBdbwddNEdzrObqJc;

			pzKRJFlbTnhtpuiUbOzqTiaWkkP IEnumerator<pzKRJFlbTnhtpuiUbOzqTiaWkkP>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<pzKRJFlbTnhtpuiUbOzqTiaWkkP> IEnumerable<pzKRJFlbTnhtpuiUbOzqTiaWkkP>.GetEnumerator()
			{
				toBCrAKAZipKEYZZAyvVqAvhMzPE toBCrAKAZipKEYZZAyvVqAvhMzPE2;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					toBCrAKAZipKEYZZAyvVqAvhMzPE2 = this;
				}
				else
				{
					toBCrAKAZipKEYZZAyvVqAvhMzPE2 = new toBCrAKAZipKEYZZAyvVqAvhMzPE(0);
					toBCrAKAZipKEYZZAyvVqAvhMzPE2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				toBCrAKAZipKEYZZAyvVqAvhMzPE2.gHvYZHUarOaorfxsTfLYBukkoDdr = UbjxuEellXeMyafFoPliUyZkaWij;
				toBCrAKAZipKEYZZAyvVqAvhMzPE2.NDuIiQmBXOqfkYsxTjDpIDbLijzg = bHlBJlWzmhLdKSVRZFPkQzpzAEJ;
				return toBCrAKAZipKEYZZAyvVqAvhMzPE2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<pzKRJFlbTnhtpuiUbOzqTiaWkkP>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					RipzaMeXkBzWHlXLENAjqhAXDtl = GxphHAMqMhNBLjnlhXuBQmXaALiE.DBNLceLJjOSJnIoFWvBsUwReOrv.Count;
					mHNUnJhfGxhBdbwddNEdzrObqJc = 0;
					goto IL_00a3;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_0095;
					}
					IL_00a3:
					if (mHNUnJhfGxhBdbwddNEdzrObqJc >= RipzaMeXkBzWHlXLENAjqhAXDtl)
					{
						break;
					}
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.DBNLceLJjOSJnIoFWvBsUwReOrv[mHNUnJhfGxhBdbwddNEdzrObqJc].kGUAgzoWmpBJnomvNrYAMpbELMU(gHvYZHUarOaorfxsTfLYBukkoDdr, NDuIiQmBXOqfkYsxTjDpIDbLijzg))
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = GxphHAMqMhNBLjnlhXuBQmXaALiE.DBNLceLJjOSJnIoFWvBsUwReOrv[mHNUnJhfGxhBdbwddNEdzrObqJc];
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						return true;
					}
					goto IL_0095;
					IL_0095:
					mHNUnJhfGxhBdbwddNEdzrObqJc++;
					goto IL_00a3;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public toBCrAKAZipKEYZZAyvVqAvhMzPE(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private List<pzKRJFlbTnhtpuiUbOzqTiaWkkP> DBNLceLJjOSJnIoFWvBsUwReOrv;

		public whAvoeXCdJcVugUuJmTYUwehLbD()
		{
			DBNLceLJjOSJnIoFWvBsUwReOrv = new List<pzKRJFlbTnhtpuiUbOzqTiaWkkP>();
		}

		public void TXPDIkiKZyOgtxZjjNIOUuEOnmW(wAwgwPsralJpdsDBnMFJGEQwfJn P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = DBNLceLJjOSJnIoFWvBsUwReOrv.Count;
			for (int i = 0; i < count; i++)
			{
				if (DBNLceLJjOSJnIoFWvBsUwReOrv[i].kGUAgzoWmpBJnomvNrYAMpbELMU(P_0, KOhWvQSGwsCHteQuXkIGpapsVZM.JlcFwBXJAZQpAvmagfRVInsQEVib))
				{
					DBNLceLJjOSJnIoFWvBsUwReOrv[i].sjbjANsWQaKxKgfHgxDuZgoAatr = P_0.rewiredId;
					DBNLceLJjOSJnIoFWvBsUwReOrv[i].ocDFctqVRVXkjlFXQuNGYFHpaVHi = P_0.AYBEJbMugfcrciXWIEYsYfFwyNm;
					DBNLceLJjOSJnIoFWvBsUwReOrv[i].wCCXbXuXNHjbbJqNArKcbmlKkEH = P_0.wCCXbXuXNHjbbJqNArKcbmlKkEH;
					DBNLceLJjOSJnIoFWvBsUwReOrv[i].kPTxDqHUNQFlgCKgmbPPsQsvVsL = P_0.inputManagerId;
					DBNLceLJjOSJnIoFWvBsUwReOrv[i].ZbmMjjdtBUhdwuFWNNTANLGAfCs = P_0.ZbmMjjdtBUhdwuFWNNTANLGAfCs;
					DBNLceLJjOSJnIoFWvBsUwReOrv[i].QiFfGNetbcVqCvKCLrtCBhIIKvgZ = P_0.QiFfGNetbcVqCvKCLrtCBhIIKvgZ;
					DBNLceLJjOSJnIoFWvBsUwReOrv[i].vRPfUqytaYtfWFfAbsznwaBZjhT = P_0.vRPfUqytaYtfWFfAbsznwaBZjhT;
					fgJODZEmUJbPsdCEyOZvWvEmnPm(P_0.rewiredId, P_0.AYBEJbMugfcrciXWIEYsYfFwyNm, i);
					return;
				}
			}
			DBNLceLJjOSJnIoFWvBsUwReOrv.Add(new pzKRJFlbTnhtpuiUbOzqTiaWkkP
			{
				sjbjANsWQaKxKgfHgxDuZgoAatr = P_0.rewiredId,
				ocDFctqVRVXkjlFXQuNGYFHpaVHi = P_0.AYBEJbMugfcrciXWIEYsYfFwyNm,
				wCCXbXuXNHjbbJqNArKcbmlKkEH = P_0.wCCXbXuXNHjbbJqNArKcbmlKkEH,
				kPTxDqHUNQFlgCKgmbPPsQsvVsL = P_0.inputManagerId,
				ZbmMjjdtBUhdwuFWNNTANLGAfCs = P_0.ZbmMjjdtBUhdwuFWNNTANLGAfCs,
				QiFfGNetbcVqCvKCLrtCBhIIKvgZ = P_0.QiFfGNetbcVqCvKCLrtCBhIIKvgZ,
				vRPfUqytaYtfWFfAbsznwaBZjhT = P_0.vRPfUqytaYtfWFfAbsznwaBZjhT
			});
			fgJODZEmUJbPsdCEyOZvWvEmnPm(P_0.rewiredId, P_0.AYBEJbMugfcrciXWIEYsYfFwyNm, DBNLceLJjOSJnIoFWvBsUwReOrv.Count - 1);
		}

		public bool qUMsmxJoDabnMgpnPbuRnplJapZC(wAwgwPsralJpdsDBnMFJGEQwfJn P_0, KOhWvQSGwsCHteQuXkIGpapsVZM P_1)
		{
			int count = DBNLceLJjOSJnIoFWvBsUwReOrv.Count;
			for (int i = 0; i < count; i++)
			{
				if (DBNLceLJjOSJnIoFWvBsUwReOrv[i].kGUAgzoWmpBJnomvNrYAMpbELMU(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerable<pzKRJFlbTnhtpuiUbOzqTiaWkkP> SHNHDnJvrVJkCMTxccwUvluFGxE(wAwgwPsralJpdsDBnMFJGEQwfJn P_0, KOhWvQSGwsCHteQuXkIGpapsVZM P_1)
		{
			toBCrAKAZipKEYZZAyvVqAvhMzPE toBCrAKAZipKEYZZAyvVqAvhMzPE2 = new toBCrAKAZipKEYZZAyvVqAvhMzPE(-2);
			toBCrAKAZipKEYZZAyvVqAvhMzPE2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			toBCrAKAZipKEYZZAyvVqAvhMzPE2.UbjxuEellXeMyafFoPliUyZkaWij = P_0;
			toBCrAKAZipKEYZZAyvVqAvhMzPE2.bHlBJlWzmhLdKSVRZFPkQzpzAEJ = P_1;
			return toBCrAKAZipKEYZZAyvVqAvhMzPE2;
		}

		private void fgJODZEmUJbPsdCEyOZvWvEmnPm(int P_0, Guid P_1, int P_2)
		{
			for (int num = DBNLceLJjOSJnIoFWvBsUwReOrv.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (DBNLceLJjOSJnIoFWvBsUwReOrv[num].sjbjANsWQaKxKgfHgxDuZgoAatr == P_0 || DBNLceLJjOSJnIoFWvBsUwReOrv[num].ocDFctqVRVXkjlFXQuNGYFHpaVHi == P_1))
				{
					DBNLceLJjOSJnIoFWvBsUwReOrv.RemoveAt(num);
				}
			}
		}
	}

	internal const bool YBlWzJDolZAgldWQxpxQqgrxJUV = true;

	private IInputSource rGFnYGjLzRhYsnnHlhHIJMtuZKY;

	private List<wAwgwPsralJpdsDBnMFJGEQwfJn> kjwFdZmRbOPrZUBwYofYzTFLQnc;

	private int PntfPQsEGteZvXgyoThapnrOHwd;

	private whAvoeXCdJcVugUuJmTYUwehLbD zDjgwsHxmQpJhkRGMsAWvoTTUnrS;

	private bool vjxAyPbSJhAqNfkvQzrguHPZorgB;

	private Action<int, ControllerDataUpdater> oUTSfLSyrhEhRjXHwJZwIeaqWEL;

	private PlatformInputManager ukvfaICvkVuAVKulQnApsyLNAjRD;

	private readonly bool PbyhNBOEDhbNoCeKjEMDqIEDKC;

	private readonly bool fPdfCbrEyOcGiZWMmtJsZlnSFIF;

	private readonly bool QSGVPtmrFlRVhCgNDOeYBOvwOTw;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> BtXgoZzfyixretGRKXdmAjlGRaR;

	private readonly Func<int> CSyUdeDrhSRituolFvOGscMBBFl;

	[CustomObfuscation(rename = false)]
	public override int deviceCount => PntfPQsEGteZvXgyoThapnrOHwd;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => ukvfaICvkVuAVKulQnApsyLNAjRD;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => rGFnYGjLzRhYsnnHlhHIJMtuZKY;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.SDL2;

	public hZHOVsmymPDAABKKFBfRVMYmptx(ConfigVars configVars, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId, bool handleJoysticks, bool handleUnifiedMouse, bool handleUnifiedKeyboard)
	{
		try
		{
			BtXgoZzfyixretGRKXdmAjlGRaR = getHardwareJoystickMap_InputManager;
			CSyUdeDrhSRituolFvOGscMBBFl = getNewJoystickId;
			PbyhNBOEDhbNoCeKjEMDqIEDKC = handleJoysticks;
			fPdfCbrEyOcGiZWMmtJsZlnSFIF = handleUnifiedMouse;
			QSGVPtmrFlRVhCgNDOeYBOvwOTw = handleUnifiedKeyboard;
			ukvfaICvkVuAVKulQnApsyLNAjRD = this;
			rGFnYGjLzRhYsnnHlhHIJMtuZKY = new SDL2InputSource(configVars.updateLoop, handleJoysticks, handleJoysticks, handleUnifiedMouse, handleUnifiedKeyboard);
			oUTSfLSyrhEhRjXHwJZwIeaqWEL = UpdateControllerData;
			rGFnYGjLzRhYsnnHlhHIJMtuZKY.DeviceChangedEvent += lZAPNvJAReqjCGPKBbUUbsPrZej;
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
		if (PbyhNBOEDhbNoCeKjEMDqIEDKC)
		{
			zDjgwsHxmQpJhkRGMsAWvoTTUnrS = new whAvoeXCdJcVugUuJmTYUwehLbD();
			yAvsVgTTGDItlDdMcthFKeWXlDf();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (rGFnYGjLzRhYsnnHlhHIJMtuZKY != null)
		{
			rGFnYGjLzRhYsnnHlhHIJMtuZKY.Update();
		}
		if (PbyhNBOEDhbNoCeKjEMDqIEDKC)
		{
			if (vjxAyPbSJhAqNfkvQzrguHPZorgB)
			{
				wfYVPLmhaoedujmiFqdMztEymuO();
			}
			if (rGFnYGjLzRhYsnnHlhHIJMtuZKY != null)
			{
				for (int i = 0; i < PntfPQsEGteZvXgyoThapnrOHwd; i++)
				{
					kjwFdZmRbOPrZUBwYofYzTFLQnc[i]?.llSbbcEmgPDyYqJudCgZifokjdS.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(updateLoop);
				}
				rGFnYGjLzRhYsnnHlhHIJMtuZKY.UpdateDevices(updateLoop);
			}
			XOMSRbIiPeAQLGFCfLGDNIijuZwC();
			if (rGFnYGjLzRhYsnnHlhHIJMtuZKY != null)
			{
				rGFnYGjLzRhYsnnHlhHIJMtuZKY.UpdateFinished();
				for (int j = 0; j < PntfPQsEGteZvXgyoThapnrOHwd; j++)
				{
					kjwFdZmRbOPrZUBwYofYzTFLQnc[j]?.llSbbcEmgPDyYqJudCgZifokjdS.AOQgnFcBlXraMNObOnRwRhydWuOc();
				}
			}
		}
		_ = fPdfCbrEyOcGiZWMmtJsZlnSFIF;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (kjwFdZmRbOPrZUBwYofYzTFLQnc != null)
		{
			int count = kjwFdZmRbOPrZUBwYofYzTFLQnc.Count;
			for (int i = 0; i < count; i++)
			{
				if (kjwFdZmRbOPrZUBwYofYzTFLQnc[i] != null)
				{
					kjwFdZmRbOPrZUBwYofYzTFLQnc[i].llSbbcEmgPDyYqJudCgZifokjdS?.ttvOyebaHvGrSQtDayUlsplcBxx();
				}
			}
		}
		if (rGFnYGjLzRhYsnnHlhHIJMtuZKY != null)
		{
			rGFnYGjLzRhYsnnHlhHIJMtuZKY.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return oUTSfLSyrhEhRjXHwJZwIeaqWEL;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!PbyhNBOEDhbNoCeKjEMDqIEDKC)
		{
			return;
		}
		for (int i = 0; i < PntfPQsEGteZvXgyoThapnrOHwd; i++)
		{
			if (kjwFdZmRbOPrZUBwYofYzTFLQnc[i].inputManagerId == inputManagerId)
			{
				kjwFdZmRbOPrZUBwYofYzTFLQnc[i].FillData(data);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		if (PbyhNBOEDhbNoCeKjEMDqIEDKC)
		{
			vjxAyPbSJhAqNfkvQzrguHPZorgB = true;
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		if (PbyhNBOEDhbNoCeKjEMDqIEDKC)
		{
			vjxAyPbSJhAqNfkvQzrguHPZorgB = true;
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = PbyhNBOEDhbNoCeKjEMDqIEDKC;
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

	private void yAvsVgTTGDItlDdMcthFKeWXlDf()
	{
		yAvsVgTTGDItlDdMcthFKeWXlDf(prlPAzKQbosCanmbkjhWVliKjFH());
	}

	private void yAvsVgTTGDItlDdMcthFKeWXlDf(IList<PECWzsyRHQmqJrheqhVEuVmEOuh> P_0)
	{
		int num = 0;
		List<wAwgwPsralJpdsDBnMFJGEQwfJn> list = kjwFdZmRbOPrZUBwYofYzTFLQnc;
		int pntfPQsEGteZvXgyoThapnrOHwd = PntfPQsEGteZvXgyoThapnrOHwd;
		kjwFdZmRbOPrZUBwYofYzTFLQnc = new List<wAwgwPsralJpdsDBnMFJGEQwfJn>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				PECWzsyRHQmqJrheqhVEuVmEOuh pECWzsyRHQmqJrheqhVEuVmEOuh = P_0[i];
				wAwgwPsralJpdsDBnMFJGEQwfJn wAwgwPsralJpdsDBnMFJGEQwfJn2 = new wAwgwPsralJpdsDBnMFJGEQwfJn(BtXgoZzfyixretGRKXdmAjlGRaR);
				wAwgwPsralJpdsDBnMFJGEQwfJn2.llSbbcEmgPDyYqJudCgZifokjdS = pECWzsyRHQmqJrheqhVEuVmEOuh;
				wAwgwPsralJpdsDBnMFJGEQwfJn2.AYBEJbMugfcrciXWIEYsYfFwyNm = pECWzsyRHQmqJrheqhVEuVmEOuh.InstanceGuid;
				wAwgwPsralJpdsDBnMFJGEQwfJn2.fUmMSGRebexnyEYaqpVhNhnGvJi = pECWzsyRHQmqJrheqhVEuVmEOuh.SystemName;
				wAwgwPsralJpdsDBnMFJGEQwfJn2.iiSTExMiHYwCqXJDsMrnFbtdknJ = pECWzsyRHQmqJrheqhVEuVmEOuh.FriendlyName;
				wAwgwPsralJpdsDBnMFJGEQwfJn2.xkvdTpabuwPDnVPwRjEibxPKerR = pECWzsyRHQmqJrheqhVEuVmEOuh.PidVid;
				wAwgwPsralJpdsDBnMFJGEQwfJn2.RlmaoXaMoKUZWqFptaxMnKyGgXWx = pECWzsyRHQmqJrheqhVEuVmEOuh.ProductId;
				wAwgwPsralJpdsDBnMFJGEQwfJn2.xWIfnycVeScryAKfrRyhksBsyEww = pECWzsyRHQmqJrheqhVEuVmEOuh.VendorId;
				wAwgwPsralJpdsDBnMFJGEQwfJn2.sklTyGKEuKrtnkivSotkvjbnDxA = pECWzsyRHQmqJrheqhVEuVmEOuh.DeviceType;
				wAwgwPsralJpdsDBnMFJGEQwfJn2.EzjAOQiiOgRjrBlkextjpAQsAmTW = pECWzsyRHQmqJrheqhVEuVmEOuh.JoystickId;
				wAwgwPsralJpdsDBnMFJGEQwfJn2.ZbmMjjdtBUhdwuFWNNTANLGAfCs = pECWzsyRHQmqJrheqhVEuVmEOuh.AxisCount;
				wAwgwPsralJpdsDBnMFJGEQwfJn2.QiFfGNetbcVqCvKCLrtCBhIIKvgZ = pECWzsyRHQmqJrheqhVEuVmEOuh.ButtonCount;
				wAwgwPsralJpdsDBnMFJGEQwfJn2.vRPfUqytaYtfWFfAbsznwaBZjhT = pECWzsyRHQmqJrheqhVEuVmEOuh.HatCount;
				wAwgwPsralJpdsDBnMFJGEQwfJn2.zMvToNbUaokPYhGbImlUtxjMXck = pECWzsyRHQmqJrheqhVEuVmEOuh.IsBluetoothDevice;
				wAwgwPsralJpdsDBnMFJGEQwfJn2.GkLKAMFRzbMjZIZtziMXVcnFggPj = pECWzsyRHQmqJrheqhVEuVmEOuh.SupportsVibration;
				wAwgwPsralJpdsDBnMFJGEQwfJn2.HSFfOkgYdavTAaqGDaWBzgNaSgu = pECWzsyRHQmqJrheqhVEuVmEOuh.VibrationMotorCount;
				wAwgwPsralJpdsDBnMFJGEQwfJn2.extension = pECWzsyRHQmqJrheqhVEuVmEOuh.ControllerExtension;
				pECWzsyRHQmqJrheqhVEuVmEOuh.eUDXkvCONCSTXJGtWDCFZrxQFja();
				wAwgwPsralJpdsDBnMFJGEQwfJn2.KfBKHnOxjftuCpCkJBMbkWxcLWv();
				kjwFdZmRbOPrZUBwYofYzTFLQnc.Add(wAwgwPsralJpdsDBnMFJGEQwfJn2);
				num++;
			}
		}
		PntfPQsEGteZvXgyoThapnrOHwd = num;
		uayRUeBwFfgScjCqOBsLgfFLjQBi(pntfPQsEGteZvXgyoThapnrOHwd, num, list, kjwFdZmRbOPrZUBwYofYzTFLQnc);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(kjwFdZmRbOPrZUBwYofYzTFLQnc[j]));
			}
		}
		dvtoafoBVFcqUHDKsKmzitILBloS(list, kjwFdZmRbOPrZUBwYofYzTFLQnc, false);
		dvtoafoBVFcqUHDKsKmzitILBloS(kjwFdZmRbOPrZUBwYofYzTFLQnc, list, true);
	}

	private void XOMSRbIiPeAQLGFCfLGDNIijuZwC()
	{
		for (int i = 0; i < PntfPQsEGteZvXgyoThapnrOHwd; i++)
		{
			kjwFdZmRbOPrZUBwYofYzTFLQnc[i]?.Update();
		}
	}

	private bool upVJYmfHCbtGAEDvyEzmFOcCwxGA(jICFRufzUQekBJMtUUbIENujmvCQ P_0)
	{
		try
		{
			return P_0.BolQJaIhWbYYEqhgMprqjmvhWgM();
		}
		catch
		{
			return false;
		}
	}

	private IList<PECWzsyRHQmqJrheqhVEuVmEOuh> prlPAzKQbosCanmbkjhWVliKjFH()
	{
		return rGFnYGjLzRhYsnnHlhHIJMtuZKY.GetJoysticks<PECWzsyRHQmqJrheqhVEuVmEOuh>();
	}

	private void uayRUeBwFfgScjCqOBsLgfFLjQBi(int P_0, int P_1, List<wAwgwPsralJpdsDBnMFJGEQwfJn> P_2, List<wAwgwPsralJpdsDBnMFJGEQwfJn> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(wAwgwPsralJpdsDBnMFJGEQwfJn.sNVFIBbqIFsIaMNbwPoLVnYRpEFk);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			uvyHsbansrbOEFMvTGIzNDuVqFhl(P_1, P_3, P_0, P_2, whAvoeXCdJcVugUuJmTYUwehLbD.KOhWvQSGwsCHteQuXkIGpapsVZM.JlcFwBXJAZQpAvmagfRVInsQEVib);
			uvyHsbansrbOEFMvTGIzNDuVqFhl(P_1, P_3, P_0, P_2, whAvoeXCdJcVugUuJmTYUwehLbD.KOhWvQSGwsCHteQuXkIGpapsVZM.lkctGikYsLMhbYMEyImPMsrGWJw);
		}
		wPaQeUOLsWCfDaRkoDbzlEsIIQc(P_1, P_3, whAvoeXCdJcVugUuJmTYUwehLbD.KOhWvQSGwsCHteQuXkIGpapsVZM.JlcFwBXJAZQpAvmagfRVInsQEVib);
		wPaQeUOLsWCfDaRkoDbzlEsIIQc(P_1, P_3, whAvoeXCdJcVugUuJmTYUwehLbD.KOhWvQSGwsCHteQuXkIGpapsVZM.lkctGikYsLMhbYMEyImPMsrGWJw);
		for (int i = 0; i < P_1; i++)
		{
			wAwgwPsralJpdsDBnMFJGEQwfJn wAwgwPsralJpdsDBnMFJGEQwfJn2 = P_3[i];
			if (wAwgwPsralJpdsDBnMFJGEQwfJn2 != null && wAwgwPsralJpdsDBnMFJGEQwfJn2.inputManagerId < 0)
			{
				wAwgwPsralJpdsDBnMFJGEQwfJn2.inputManagerId = XsOsVyBtTACNZvhKSCqKhJNcObX(P_3);
				wAwgwPsralJpdsDBnMFJGEQwfJn2.rewiredId = CSyUdeDrhSRituolFvOGscMBBFl();
				zDjgwsHxmQpJhkRGMsAWvoTTUnrS.TXPDIkiKZyOgtxZjjNIOUuEOnmW(wAwgwPsralJpdsDBnMFJGEQwfJn2);
			}
		}
		P_3.Sort(wAwgwPsralJpdsDBnMFJGEQwfJn.snpUatNrOhnqYMrVlODtTBLMwGy);
	}

	private void ZYHxGNylvgpiiDGzmFDnBqagypH(List<wAwgwPsralJpdsDBnMFJGEQwfJn> P_0, int P_1, int P_2)
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

	private bool BHoDIxSSroZRExzlHLxMWTglSdB(List<wAwgwPsralJpdsDBnMFJGEQwfJn> P_0, int P_1)
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

	private int XsOsVyBtTACNZvhKSCqKhJNcObX(List<wAwgwPsralJpdsDBnMFJGEQwfJn> P_0)
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

	private bool TDbfjHTAtTEdVDROIPjYUelzQmc(List<wAwgwPsralJpdsDBnMFJGEQwfJn> P_0, int P_1)
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

	private void uvyHsbansrbOEFMvTGIzNDuVqFhl(int P_0, List<wAwgwPsralJpdsDBnMFJGEQwfJn> P_1, int P_2, List<wAwgwPsralJpdsDBnMFJGEQwfJn> P_3, whAvoeXCdJcVugUuJmTYUwehLbD.KOhWvQSGwsCHteQuXkIGpapsVZM P_4)
	{
		int num = ((P_4 != whAvoeXCdJcVugUuJmTYUwehLbD.KOhWvQSGwsCHteQuXkIGpapsVZM.JlcFwBXJAZQpAvmagfRVInsQEVib) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			wAwgwPsralJpdsDBnMFJGEQwfJn wAwgwPsralJpdsDBnMFJGEQwfJn2 = P_1[i];
			if (wAwgwPsralJpdsDBnMFJGEQwfJn2 == null || wAwgwPsralJpdsDBnMFJGEQwfJn2.inputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				wAwgwPsralJpdsDBnMFJGEQwfJn wAwgwPsralJpdsDBnMFJGEQwfJn3 = P_3[j];
				if (wAwgwPsralJpdsDBnMFJGEQwfJn3 != null && !TDbfjHTAtTEdVDROIPjYUelzQmc(P_1, wAwgwPsralJpdsDBnMFJGEQwfJn3.rewiredId) && wAwgwPsralJpdsDBnMFJGEQwfJn2.kGUAgzoWmpBJnomvNrYAMpbELMU(wAwgwPsralJpdsDBnMFJGEQwfJn3) >= num)
				{
					wAwgwPsralJpdsDBnMFJGEQwfJn2.AIlTBlatymduYQhsnDZKtmbGMpq(wAwgwPsralJpdsDBnMFJGEQwfJn3);
					zDjgwsHxmQpJhkRGMsAWvoTTUnrS.TXPDIkiKZyOgtxZjjNIOUuEOnmW(wAwgwPsralJpdsDBnMFJGEQwfJn2);
				}
			}
		}
	}

	private void wPaQeUOLsWCfDaRkoDbzlEsIIQc(int P_0, List<wAwgwPsralJpdsDBnMFJGEQwfJn> P_1, whAvoeXCdJcVugUuJmTYUwehLbD.KOhWvQSGwsCHteQuXkIGpapsVZM P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			wAwgwPsralJpdsDBnMFJGEQwfJn wAwgwPsralJpdsDBnMFJGEQwfJn2 = P_1[i];
			if (wAwgwPsralJpdsDBnMFJGEQwfJn2 == null || wAwgwPsralJpdsDBnMFJGEQwfJn2.inputManagerId >= 0)
			{
				continue;
			}
			whAvoeXCdJcVugUuJmTYUwehLbD.pzKRJFlbTnhtpuiUbOzqTiaWkkP pzKRJFlbTnhtpuiUbOzqTiaWkkP = null;
			foreach (whAvoeXCdJcVugUuJmTYUwehLbD.pzKRJFlbTnhtpuiUbOzqTiaWkkP item in zDjgwsHxmQpJhkRGMsAWvoTTUnrS.SHNHDnJvrVJkCMTxccwUvluFGxE(wAwgwPsralJpdsDBnMFJGEQwfJn2, P_2))
			{
				if (!TDbfjHTAtTEdVDROIPjYUelzQmc(P_1, item.sjbjANsWQaKxKgfHgxDuZgoAatr) && item.kPTxDqHUNQFlgCKgmbPPsQsvVsL >= 0)
				{
					pzKRJFlbTnhtpuiUbOzqTiaWkkP = item;
					break;
				}
			}
			if (pzKRJFlbTnhtpuiUbOzqTiaWkkP != null)
			{
				int num = pzKRJFlbTnhtpuiUbOzqTiaWkkP.kPTxDqHUNQFlgCKgmbPPsQsvVsL;
				if (!BHoDIxSSroZRExzlHLxMWTglSdB(P_1, num))
				{
					num = (pzKRJFlbTnhtpuiUbOzqTiaWkkP.kPTxDqHUNQFlgCKgmbPPsQsvVsL = XsOsVyBtTACNZvhKSCqKhJNcObX(P_1));
				}
				wAwgwPsralJpdsDBnMFJGEQwfJn2.inputManagerId = num;
				wAwgwPsralJpdsDBnMFJGEQwfJn2.rewiredId = pzKRJFlbTnhtpuiUbOzqTiaWkkP.sjbjANsWQaKxKgfHgxDuZgoAatr;
				zDjgwsHxmQpJhkRGMsAWvoTTUnrS.TXPDIkiKZyOgtxZjjNIOUuEOnmW(wAwgwPsralJpdsDBnMFJGEQwfJn2);
			}
		}
	}

	private void wfYVPLmhaoedujmiFqdMztEymuO()
	{
		IList<PECWzsyRHQmqJrheqhVEuVmEOuh> list = prlPAzKQbosCanmbkjhWVliKjFH();
		yAvsVgTTGDItlDdMcthFKeWXlDf(list);
		vjxAyPbSJhAqNfkvQzrguHPZorgB = false;
	}

	private bool RlkwRQpOLQQDoeMFZRsoshUnDQsD(IList<PECWzsyRHQmqJrheqhVEuVmEOuh> P_0)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && !OUBujVBCwsmFCeWOSGNeeXsOOFZ(P_0[i].InstanceGuid))
			{
				return true;
			}
		}
		int count2 = kjwFdZmRbOPrZUBwYofYzTFLQnc.Count;
		for (int j = 0; j < count2; j++)
		{
			if (kjwFdZmRbOPrZUBwYofYzTFLQnc[j] != null && !fnDzLaTroEvweQAltfeAqopsaWei(P_0, kjwFdZmRbOPrZUBwYofYzTFLQnc[j].AYBEJbMugfcrciXWIEYsYfFwyNm))
			{
				return true;
			}
		}
		return false;
	}

	private bool OUBujVBCwsmFCeWOSGNeeXsOOFZ(Guid P_0)
	{
		int count = kjwFdZmRbOPrZUBwYofYzTFLQnc.Count;
		for (int i = 0; i < count; i++)
		{
			if (kjwFdZmRbOPrZUBwYofYzTFLQnc[i] != null && kjwFdZmRbOPrZUBwYofYzTFLQnc[i].AYBEJbMugfcrciXWIEYsYfFwyNm == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool fnDzLaTroEvweQAltfeAqopsaWei(IList<PECWzsyRHQmqJrheqhVEuVmEOuh> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].InstanceGuid == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void dvtoafoBVFcqUHDKsKmzitILBloS(List<wAwgwPsralJpdsDBnMFJGEQwfJn> P_0, List<wAwgwPsralJpdsDBnMFJGEQwfJn> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			wAwgwPsralJpdsDBnMFJGEQwfJn wAwgwPsralJpdsDBnMFJGEQwfJn2 = P_0[i];
			if (wAwgwPsralJpdsDBnMFJGEQwfJn2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					wAwgwPsralJpdsDBnMFJGEQwfJn wAwgwPsralJpdsDBnMFJGEQwfJn3 = P_1[j];
					if (wAwgwPsralJpdsDBnMFJGEQwfJn3 != null && wAwgwPsralJpdsDBnMFJGEQwfJn2.AYBEJbMugfcrciXWIEYsYfFwyNm == wAwgwPsralJpdsDBnMFJGEQwfJn3.AYBEJbMugfcrciXWIEYsYfFwyNm)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				FyZjHIebzTuXOypeVTeqTYZyKta(P_0[i], P_2);
			}
		}
	}

	private void FyZjHIebzTuXOypeVTeqTYZyKta(wAwgwPsralJpdsDBnMFJGEQwfJn P_0, bool P_1)
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

	private void lZAPNvJAReqjCGPKBbUUbsPrZej()
	{
		if (PbyhNBOEDhbNoCeKjEMDqIEDKC)
		{
			vjxAyPbSJhAqNfkvQzrguHPZorgB = true;
		}
		SystemDeviceConnected();
	}
}
