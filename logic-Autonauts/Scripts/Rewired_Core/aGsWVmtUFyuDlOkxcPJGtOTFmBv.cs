using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.InputSources.SDL2;
using Rewired.Interfaces;
using Rewired.Utils;

internal class aGsWVmtUFyuDlOkxcPJGtOTFmBv : PlatformInputManager
{
	private class pkFwwXNgPsUAHNkXgqodKLsnqBS : IInputManagerJoystickPublic, IInputManagerJoystick
	{
		private int GHfkhSadilGfAxFyuOxXFmXoNB;

		private int pypcACKajeDXMgihCBBcoMfRHezM;

		public Guid ocZIgneRSUDLHotByUrmWfynkiD;

		public string idBUOvcDwFFfLroYpWUohJPxkTQ;

		public CjjRDclXuvjouyeLLeBBHCfpqqbM cQAbwffNRFwBZBvyPeSpfAaABXvc;

		public wQJNyUaUvslgkGHqqbQGKnHjBYM viWvrGBFplpSGbGOfgAjDicUVNU;

		public string ubFxRAANNNuvDTppDHhsfZqrrTe;

		public string tbpVRpBintMlFYmEBYAejKmUJRZ;

		public int MBlnXHlBnwRpMqEKOvVoilzgzEB;

		public int aTbsowlFdtdDNHGQGyHgAISJkkq;

		public Guid PXqNZrJMXSojPxhffbCdeIGJhWcf;

		public PidVid wMQkUdjKDZdPGBUJeJKzEFSdMDTF;

		public Guid bDjREJxTewszSCCahgztXzcduUN;

		public int VEHPIavzDVjAYkBtLrqAgBoFQZp;

		public int NTatWULjiHpTYqyINRDSMJXXVvR;

		public int UsfsOskiNyjyRRYviYBYSQeIHPE;

		public int YEZgNdJkWdDhBOvxapXVbnLavXwP;

		public int VEwPZpcCBNaKrRnFyrYRJVohPVc;

		public int muqcoKtsIxBhKaKEKUceDAlgNRL;

		public bool kSItSFmbvTzcvaKvvviPTGktjjic;

		public bool JgidXSSSAGvvkDcAIVICtlmgnKR;

		public int QTcZLynCWHLLppDxcAAAPxKXLEc;

		private float[] wbUISjltnzArWBKEUafkjffKERTS;

		private bool[] CFcByKWcDyyvXwtHigPcgEPuCPR;

		private HardwareJoystickMap_InputManager kABaypBwJpdJPQfaNrcsDzJUopW;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> SquvrBwjLHJfDioapylbqZuppCD;

		private bool BWNCoGmOwkTflVtLyUCybvonruM;

		private bool qEBChkdMenIWbHajRwlLiEqfOWVs;

		[CompilerGenerated]
		private Controller.Extension zDlgRYaTGbZEULHSapgnzgsXcBG;

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return GHfkhSadilGfAxFyuOxXFmXoNB;
			}
			set
			{
				GHfkhSadilGfAxFyuOxXFmXoNB = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return pypcACKajeDXMgihCBBcoMfRHezM;
			}
			set
			{
				pypcACKajeDXMgihCBBcoMfRHezM = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				return idBUOvcDwFFfLroYpWUohJPxkTQ;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (pypcACKajeDXMgihCBBcoMfRHezM < 0)
				{
					return null;
				}
				return pypcACKajeDXMgihCBBcoMfRHezM;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return 0;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid
		{
			get
			{
				return PXqNZrJMXSojPxhffbCdeIGJhWcf;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid
		{
			get
			{
				return instanceGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension
		{
			[CompilerGenerated]
			get
			{
				return zDlgRYaTGbZEULHSapgnzgsXcBG;
			}
			[CompilerGenerated]
			set
			{
				zDlgRYaTGbZEULHSapgnzgsXcBG = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			cQAbwffNRFwBZBvyPeSpfAaABXvc.SetVibration(motorIndex, amount, false);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		public pkFwwXNgPsUAHNkXgqodKLsnqBS(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			SquvrBwjLHJfDioapylbqZuppCD = getHardwareJoystickMap_InputManager;
			pypcACKajeDXMgihCBBcoMfRHezM = -1;
			GHfkhSadilGfAxFyuOxXFmXoNB = -1;
		}

		public void NbodIzVoMOIfxhiTmzGcfYqHqqpP()
		{
			bDjREJxTewszSCCahgztXzcduUN = MiscTools.CreateGuidHashSHA1(ubFxRAANNNuvDTppDHhsfZqrrTe + wMQkUdjKDZdPGBUJeJKzEFSdMDTF.ToProductGuid());
			NTatWULjiHpTYqyINRDSMJXXVvR = YEZgNdJkWdDhBOvxapXVbnLavXwP;
			while (true)
			{
				int num = -978974178;
				while (true)
				{
					switch (num ^ -978974184)
					{
					case 5:
						break;
					case 6:
						UsfsOskiNyjyRRYviYBYSQeIHPE = VEwPZpcCBNaKrRnFyrYRJVohPVc + muqcoKtsIxBhKaKEKUceDAlgNRL * 8;
						num = -978974183;
						continue;
					case 1:
						cYHcXCOFpORyFoNYyhyTldjiUMD();
						num = -978974181;
						continue;
					case 3:
						ocZIgneRSUDLHotByUrmWfynkiD = kABaypBwJpdJPQfaNrcsDzJUopW.hardwareMapIdentifier.guid;
						num = -978974182;
						continue;
					case 0:
						BWNCoGmOwkTflVtLyUCybvonruM = ((ocZIgneRSUDLHotByUrmWfynkiD == Guid.Empty) ? true : false);
						num = -978974192;
						continue;
					case 8:
						wbUISjltnzArWBKEUafkjffKERTS = new float[NTatWULjiHpTYqyINRDSMJXXVvR];
						num = -978974177;
						continue;
					case 7:
						CFcByKWcDyyvXwtHigPcgEPuCPR = new bool[UsfsOskiNyjyRRYviYBYSQeIHPE];
						num = -978974180;
						continue;
					case 2:
						idBUOvcDwFFfLroYpWUohJPxkTQ = kABaypBwJpdJPQfaNrcsDzJUopW.controllerName;
						num = -978974184;
						continue;
					default:
						Update();
						return;
					}
					break;
				}
			}
		}

		public void TCWWrbhTnTgbtRDgCDABRkmhLPq(pkFwwXNgPsUAHNkXgqodKLsnqBS P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int num3 = default(int);
			while (true)
			{
				pypcACKajeDXMgihCBBcoMfRHezM = P_0.pypcACKajeDXMgihCBBcoMfRHezM;
				GHfkhSadilGfAxFyuOxXFmXoNB = P_0.GHfkhSadilGfAxFyuOxXFmXoNB;
				int num = 0;
				int num2 = -642073617;
				while (true)
				{
					switch (num2 ^ -642073618)
					{
					case 4:
						num2 = -642073620;
						continue;
					default:
						return;
					case 7:
						if (num3 >= MathTools.Min(wbUISjltnzArWBKEUafkjffKERTS.Length, P_0.wbUISjltnzArWBKEUafkjffKERTS.Length))
						{
							qEBChkdMenIWbHajRwlLiEqfOWVs = P_0.qEBChkdMenIWbHajRwlLiEqfOWVs;
							num2 = -642073619;
							continue;
						}
						goto case 5;
					case 0:
						num2 = -642073623;
						continue;
					case 5:
						wbUISjltnzArWBKEUafkjffKERTS[num3] = P_0.wbUISjltnzArWBKEUafkjffKERTS[num3];
						num3++;
						num2 = -642073623;
						continue;
					case 6:
						CFcByKWcDyyvXwtHigPcgEPuCPR[num] = P_0.CFcByKWcDyyvXwtHigPcgEPuCPR[num];
						num++;
						num2 = -642073617;
						continue;
					case 1:
						if (num >= MathTools.Min(CFcByKWcDyyvXwtHigPcgEPuCPR.Length, P_0.CFcByKWcDyyvXwtHigPcgEPuCPR.Length))
						{
							num3 = 0;
							num2 = -642073618;
							continue;
						}
						goto case 6;
					case 2:
						break;
					case 3:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			pZGbWgDuiUJknDkmqIIleMKulPyz();
			OmvEduKEMDwCfGsAUMYnJwvhRxA();
			if (!qEBChkdMenIWbHajRwlLiEqfOWVs && cQAbwffNRFwBZBvyPeSpfAaABXvc.HasEverReceivedInput)
			{
				qEBChkdMenIWbHajRwlLiEqfOWVs = true;
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (NTatWULjiHpTYqyINRDSMJXXVvR == dataUpdater.axisCount)
			{
				int num3 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = 1933774204;
					while (true)
					{
						switch (num ^ 0x73430D7D)
						{
						case 4:
							break;
						default:
							return;
						case 2:
							if (qEBChkdMenIWbHajRwlLiEqfOWVs && !dataUpdater.hasReceivedInput)
							{
								dataUpdater.hasReceivedInput = true;
								num = 1933774196;
								continue;
							}
							return;
						case 3:
							goto end_IL_000e;
						case 1:
							goto IL_0085;
						case 8:
							num = 1933774205;
							continue;
						case 7:
							dataUpdater.buttonValues[num3] = CFcByKWcDyyvXwtHigPcgEPuCPR[num3];
							num3++;
							num = 1933774200;
							continue;
						case 0:
							if (num2 >= NTatWULjiHpTYqyINRDSMJXXVvR)
							{
								num3 = 0;
								num = 1933774200;
								continue;
							}
							goto case 10;
						case 6:
							num2 = 0;
							num = 1933774197;
							continue;
						case 5:
							goto IL_00f0;
						case 10:
							dataUpdater.axisValues[num2] = wbUISjltnzArWBKEUafkjffKERTS[num2];
							num2++;
							num = 1933774205;
							continue;
						case 9:
							return;
						}
						break;
						IL_00f0:
						int num4;
						if (num3 >= UsfsOskiNyjyRRYviYBYSQeIHPE)
						{
							num = 1933774207;
							num4 = num;
						}
						else
						{
							num = 1933774202;
							num4 = num;
						}
						continue;
						IL_0085:
						int num5;
						if (UsfsOskiNyjyRRYviYBYSQeIHPE == dataUpdater.buttonCount)
						{
							num = 1933774203;
							num5 = num;
						}
						else
						{
							num = 1933774206;
							num5 = num;
						}
					}
					continue;
					end_IL_000e:
					break;
				}
			}
			throw new Exception("This controller signature does not match the data object!");
		}

		public int texDHprRVSCDIhdEcHxFsscbHjUA(pkFwwXNgPsUAHNkXgqodKLsnqBS P_0)
		{
			if (P_0.GHfkhSadilGfAxFyuOxXFmXoNB == GHfkhSadilGfAxFyuOxXFmXoNB)
			{
				return 2;
			}
			if (YEZgNdJkWdDhBOvxapXVbnLavXwP != P_0.YEZgNdJkWdDhBOvxapXVbnLavXwP)
			{
				return 0;
			}
			if (VEwPZpcCBNaKrRnFyrYRJVohPVc != P_0.VEwPZpcCBNaKrRnFyrYRJVohPVc)
			{
				return 0;
			}
			if (muqcoKtsIxBhKaKEKUceDAlgNRL != P_0.muqcoKtsIxBhKaKEKUceDAlgNRL)
			{
				return 0;
			}
			if (P_0.PXqNZrJMXSojPxhffbCdeIGJhWcf == PXqNZrJMXSojPxhffbCdeIGJhWcf)
			{
				return 2;
			}
			if (P_0.bDjREJxTewszSCCahgztXzcduUN == bDjREJxTewszSCCahgztXzcduUN)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo qOeDHherkAoikMXOIsfGhJBfRvh()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			VDeqJOjTSTlabFOpcCmVfVrbzeiM(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			VDeqJOjTSTlabFOpcCmVfVrbzeiM(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(GHfkhSadilGfAxFyuOxXFmXoNB);
		}

		private void pZGbWgDuiUJknDkmqIIleMKulPyz()
		{
			if (NTatWULjiHpTYqyINRDSMJXXVvR <= 0)
			{
				return;
			}
			int num2 = default(int);
			while (true)
			{
				InputPlatform platform = kABaypBwJpdJPQfaNrcsDzJUopW.map.platform;
				if (platform != InputPlatform.IxbHVCPxPdNPRUkNUofPdkkhUmv)
				{
					break;
				}
				HardwareJoystickMap.Platform_SDL2_Base platform_SDL2_Base = (HardwareJoystickMap.Platform_SDL2_Base)kABaypBwJpdJPQfaNrcsDzJUopW.map;
				HardwareJoystickMap.Platform_SDL2_Base.Axis[] axes_orig = platform_SDL2_Base.Axes_orig;
				int num = -1600604639;
				while (true)
				{
					switch (num ^ -1600604637)
					{
					case 4:
						num = -1600604636;
						continue;
					default:
						return;
					case 0:
						num = -1600604640;
						continue;
					case 6:
						num2 = 0;
						num = -1600604637;
						continue;
					case 5:
						sHGEHYaMwtVJtJrEysuztLdwesfB(axes_orig[num2], num2);
						num2++;
						num = -1600604640;
						continue;
					case 2:
					{
						int num4;
						if (axes_orig != null)
						{
							num = -1600604635;
							num4 = num;
						}
						else
						{
							num = -1600604629;
							num4 = num;
						}
						continue;
					}
					case 3:
					{
						int num3;
						if (num2 >= axes_orig.Length)
						{
							num = -1600604638;
							num3 = num;
						}
						else
						{
							num = -1600604634;
							num3 = num;
						}
						continue;
					}
					case 7:
						break;
					case 8:
						return;
					case 1:
						return;
					}
					break;
				}
			}
		}

		private void OmvEduKEMDwCfGsAUMYnJwvhRxA()
		{
			if (UsfsOskiNyjyRRYviYBYSQeIHPE <= 0)
			{
				return;
			}
			int num3 = default(int);
			while (true)
			{
				HardwareJoystickMap.Platform_SDL2_Base platform_SDL2_Base = (HardwareJoystickMap.Platform_SDL2_Base)kABaypBwJpdJPQfaNrcsDzJUopW.map;
				HardwareJoystickMap.Platform_SDL2_Base.Button[] buttons_orig = platform_SDL2_Base.Buttons_orig;
				int num;
				int num2;
				if (buttons_orig == null)
				{
					num = -328846417;
					num2 = num;
				}
				else
				{
					num = -328846422;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -328846421)
					{
					case 0:
						num = -328846423;
						continue;
					case 1:
						num3 = 0;
						num = -328846424;
						continue;
					case 4:
						return;
					case 2:
						break;
					case 5:
						omRcDfhThEboYGemPAITqzaTaWb(buttons_orig[num3], num3);
						num3++;
						num = -328846424;
						continue;
					default:
						if (num3 >= buttons_orig.Length)
						{
							return;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		private void sHGEHYaMwtVJtJrEysuztLdwesfB(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0, int P_1)
		{
			if (P_1 >= NTatWULjiHpTYqyINRDSMJXXVvR)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			wbUISjltnzArWBKEUafkjffKERTS[P_1] = dLTmadjmjVluMhSlcxbDwCyzhb(P_0);
		}

		private void omRcDfhThEboYGemPAITqzaTaWb(HardwareJoystickMap.Platform_SDL2_Base.Button P_0, int P_1)
		{
			if (P_1 >= UsfsOskiNyjyRRYviYBYSQeIHPE)
			{
				while (true)
				{
					switch (-14818964 ^ -14818963)
					{
					case 0:
						continue;
					case 1:
						throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
					}
					break;
				}
			}
			CFcByKWcDyyvXwtHigPcgEPuCPR[P_1] = VMMfdBCZsMnRqIWVFlCcPeWKEbcs(P_0);
		}

		private float dLTmadjmjVluMhSlcxbDwCyzhb(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis >= 0 && sourceAxis < YEZgNdJkWdDhBOvxapXVbnLavXwP)
				{
					if (sourceAxis < 56)
					{
						return cQAbwffNRFwBZBvyPeSpfAaABXvc.GetAxisValue(sourceAxis);
					}
					goto IL_002e;
				}
				goto IL_0232;
			}
			int num;
			if (P_0.sourceType != HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.sourceType != HardwareElementSourceTypeWithHat.Hat)
				{
					return 0f;
				}
				num = 1308643056;
			}
			else
			{
				num = 1308643071;
			}
			goto IL_0033;
			IL_0033:
			float result = default(float);
			int sourceButton = default(int);
			int sourceHat = default(int);
			float num2 = default(float);
			while (true)
			{
				switch (num ^ 0x4E004EF9)
				{
				case 8:
					break;
				case 5:
					return 0f;
				case 11:
					return result;
				case 9:
					goto IL_00c8;
				case 13:
					return 0f;
				case 10:
					goto IL_011d;
				case 12:
					return 0f;
				case 6:
					sourceButton = P_0.sourceButton;
					if (sourceButton < 0)
					{
						goto case 13;
					}
					goto IL_016f;
				case 2:
					goto IL_018c;
				case 0:
					goto IL_019c;
				case 14:
					return 0f;
				case 3:
					if (sourceHat >= muqcoKtsIxBhKaKEKUceDAlgNRL)
					{
						goto case 14;
					}
					goto IL_0223;
				case 1:
					goto IL_0232;
				case 4:
					goto IL_025a;
				default:
					goto IL_0270;
				}
				break;
				IL_025a:
				if (num2 < 0f)
				{
					num = 1308643068;
					continue;
				}
				goto IL_0094;
				IL_0270:
				return num2;
				IL_0223:
				if (sourceHat < 4)
				{
					int hatValue = cQAbwffNRFwBZBvyPeSpfAaABXvc.GetHatValue(sourceHat);
					if (hatValue < 0)
					{
						return 0f;
					}
					if (P_0.sourceHatDirection != AxisDirection.Horizontal)
					{
						num2 = CxPADXiGhABwChHOreLIjsyqjlJ(hatValue, AxisDirection.Vertical);
						if (P_0.sourceHatRange != AxisRange.Full)
						{
							if (P_0.sourceHatRange == AxisRange.Positive)
							{
								num = 1308643069;
								continue;
							}
							if (num2 > 0f)
							{
								return 0f;
							}
						}
						goto IL_0094;
					}
					num2 = CxPADXiGhABwChHOreLIjsyqjlJ(hatValue, AxisDirection.Horizontal);
					num = 1308643065;
					continue;
				}
				num = 1308643063;
				continue;
				IL_0094:
				if (P_0.invert)
				{
					num2 *= -1f;
					num = 1308643070;
					continue;
				}
				goto IL_0270;
				IL_018c:
				result = -1f;
				num = 1308643058;
				continue;
				IL_019c:
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
						num = 1308643061;
						continue;
					}
				}
				goto IL_0094;
				IL_016f:
				int num3;
				if (sourceButton >= VEwPZpcCBNaKrRnFyrYRJVohPVc)
				{
					num = 1308643060;
					num3 = num;
				}
				else
				{
					num = 1308643059;
					num3 = num;
				}
				continue;
				IL_00c8:
				sourceHat = P_0.sourceHat;
				int num4;
				if (sourceHat >= 0)
				{
					num = 1308643066;
					num4 = num;
				}
				else
				{
					num = 1308643063;
					num4 = num;
				}
				continue;
				IL_011d:
				if (sourceButton < 256)
				{
					if (!cQAbwffNRFwBZBvyPeSpfAaABXvc.GetButtonValue(sourceButton))
					{
						return 0f;
					}
					if (P_0.buttonAxisContribution == Pole.Positive)
					{
						result = 1f;
						num = 1308643058;
						continue;
					}
					goto IL_018c;
				}
				num = 1308643060;
			}
			goto IL_002e;
			IL_002e:
			num = 1308643064;
			goto IL_0033;
			IL_0232:
			return 0f;
		}

		private bool VMMfdBCZsMnRqIWVFlCcPeWKEbcs(HardwareJoystickMap.Platform_SDL2_Base.Button P_0)
		{
			int num = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					num = 0;
					goto IL_012c;
				}
				goto IL_017c;
			}
			int sourceAxis = default(int);
			int num2;
			int sourceHat = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				sourceAxis = P_0.sourceAxis;
				int num3;
				if (sourceAxis > 0)
				{
					num2 = -1780503218;
					num3 = num2;
				}
				else
				{
					num2 = -1780503229;
					num3 = num2;
				}
			}
			else
			{
				if (P_0.sourceType != HardwareElementSourceTypeWithHat.Hat)
				{
					goto IL_0371;
				}
				sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= muqcoKtsIxBhKaKEKUceDAlgNRL)
				{
					goto IL_0191;
				}
				if (sourceHat < 4)
				{
					switch (P_0.sourceHatDirection)
					{
					case HatDirection.Up:
						goto IL_0299;
					case HatDirection.UpRight:
						return PpBGPTDNbMMiXyiCwiZrgcznerj(cQAbwffNRFwBZBvyPeSpfAaABXvc.GetHatValue(sourceHat), 1, P_0.sourceHatType);
					case HatDirection.Right:
						return PpBGPTDNbMMiXyiCwiZrgcznerj(cQAbwffNRFwBZBvyPeSpfAaABXvc.GetHatValue(sourceHat), 2, P_0.sourceHatType);
					case HatDirection.DownRight:
						return PpBGPTDNbMMiXyiCwiZrgcznerj(cQAbwffNRFwBZBvyPeSpfAaABXvc.GetHatValue(sourceHat), 3, P_0.sourceHatType);
					case HatDirection.Down:
						return PpBGPTDNbMMiXyiCwiZrgcznerj(cQAbwffNRFwBZBvyPeSpfAaABXvc.GetHatValue(sourceHat), 4, P_0.sourceHatType);
					case HatDirection.DownLeft:
						return PpBGPTDNbMMiXyiCwiZrgcznerj(cQAbwffNRFwBZBvyPeSpfAaABXvc.GetHatValue(sourceHat), 5, P_0.sourceHatType);
					case HatDirection.Left:
						return PpBGPTDNbMMiXyiCwiZrgcznerj(cQAbwffNRFwBZBvyPeSpfAaABXvc.GetHatValue(sourceHat), 6, P_0.sourceHatType);
					case HatDirection.UpLeft:
						return PpBGPTDNbMMiXyiCwiZrgcznerj(cQAbwffNRFwBZBvyPeSpfAaABXvc.GetHatValue(sourceHat), 7, P_0.sourceHatType);
					}
					num2 = -1780503226;
				}
				else
				{
					num2 = -1780503227;
				}
			}
			goto IL_0022;
			IL_017c:
			if (!P_0.requireMultipleButtons)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= VEwPZpcCBNaKrRnFyrYRJVohPVc)
				{
					goto IL_00ad;
				}
				if (sourceButton < 256)
				{
					return cQAbwffNRFwBZBvyPeSpfAaABXvc.GetButtonValue(sourceButton);
				}
				num2 = -1780503219;
			}
			else
			{
				num2 = -1780503232;
			}
			goto IL_0022;
			IL_0371:
			return false;
			IL_00ad:
			return false;
			IL_020e:
			float axisValue = default(float);
			if (MathTools.Abs(axisValue) <= P_0.axisDeadZone)
			{
				return false;
			}
			if (P_0.sourceAxisPole == Pole.Positive)
			{
				if (axisValue < 0f)
				{
					return false;
				}
			}
			else if (axisValue > 0f)
			{
				return false;
			}
			return true;
			IL_012c:
			int num4;
			if (num < P_0.ignoreIfButtonsActiveButtons.Length)
			{
				num2 = -1780503230;
				num4 = num2;
			}
			else
			{
				num2 = -1780503228;
				num4 = num2;
			}
			goto IL_0022;
			IL_0191:
			return false;
			IL_0299:
			return PpBGPTDNbMMiXyiCwiZrgcznerj(cQAbwffNRFwBZBvyPeSpfAaABXvc.GetHatValue(sourceHat), 0, P_0.sourceHatType);
			IL_0022:
			int num5 = default(int);
			bool flag = default(bool);
			while (true)
			{
				switch (num2 ^ -1780503217)
				{
				case 3:
					num2 = -1780503230;
					continue;
				case 17:
					return true;
				case 5:
					num5 = 0;
					num2 = -1780503224;
					continue;
				case 2:
					break;
				case 1:
					if (sourceAxis < YEZgNdJkWdDhBOvxapXVbnLavXwP)
					{
						goto IL_00f3;
					}
					goto case 12;
				case 12:
					return false;
				case 4:
					num5++;
					num2 = -1780503224;
					continue;
				case 6:
					goto IL_012c;
				case 13:
					goto IL_014b;
				case 15:
					flag = false;
					num2 = -1780503222;
					continue;
				case 11:
					goto IL_017c;
				case 10:
					goto IL_0191;
				case 14:
					goto IL_01cc;
				case 16:
					goto IL_01dc;
				case 0:
					goto IL_020e;
				case 7:
					goto IL_027a;
				default:
					goto IL_0299;
				case 9:
					goto IL_0371;
				}
				break;
				IL_027a:
				int num6;
				if (num5 < P_0.requiredButtons.Length)
				{
					num2 = -1780503201;
					num6 = num2;
				}
				else
				{
					num2 = -1780503231;
					num6 = num2;
				}
				continue;
				IL_01cc:
				if (!flag)
				{
					return false;
				}
				num2 = -1780503202;
				continue;
				IL_00f3:
				if (sourceAxis >= 56)
				{
					num2 = -1780503229;
					continue;
				}
				axisValue = cQAbwffNRFwBZBvyPeSpfAaABXvc.GetAxisValue(sourceAxis);
				num2 = -1780503217;
				continue;
				IL_01dc:
				if (!cQAbwffNRFwBZBvyPeSpfAaABXvc.GetButtonValue(P_0.requiredButtons[num5]))
				{
					return false;
				}
				flag = true;
				num2 = -1780503221;
				continue;
				IL_014b:
				if (cQAbwffNRFwBZBvyPeSpfAaABXvc.GetButtonValue(P_0.ignoreIfButtonsActiveButtons[num]))
				{
					return false;
				}
				num++;
				num2 = -1780503223;
			}
			goto IL_00ad;
		}

		private bool PpBGPTDNbMMiXyiCwiZrgcznerj(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (kABaypBwJpdJPQfaNrcsDzJUopW.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				goto IL_001d;
			}
			int num = 4500;
			int num2 = num * P_1;
			if (P_2 == HatType.EightWay && P_0 != num2)
			{
				return false;
			}
			int num3 = default(int);
			int num4 = default(int);
			int num5;
			if (P_2 == HatType.EightWay)
			{
				num3 = 31500;
				num4 = 4500;
				num5 = -698172698;
				goto IL_0022;
			}
			goto IL_009e;
			IL_001d:
			num5 = -698172703;
			goto IL_0022;
			IL_0022:
			while (true)
			{
				switch (num5 ^ -698172700)
				{
				case 0:
					break;
				case 5:
					return false;
				case 2:
					if (P_1 == 0 && P_0 > num3)
					{
						P_0 -= 36000;
						num5 = -698172697;
						continue;
					}
					goto IL_008b;
				case 3:
					goto IL_008b;
				case 4:
					goto IL_009e;
				default:
					return true;
				}
				break;
				IL_008b:
				if (P_0 < num2 + num4 && P_0 > num2 - num4)
				{
					num5 = -698172699;
					continue;
				}
				return false;
			}
			goto IL_001d;
			IL_009e:
			num3 = 27000;
			num4 = 9000;
			num5 = -698172698;
			goto IL_0022;
		}

		private float CxPADXiGhABwChHOreLIjsyqjlJ(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (P_1 == AxisDirection.Vertical)
			{
				while (true)
				{
					int num = -1213199827;
					while (true)
					{
						switch (num ^ -1213199826)
						{
						case 0:
							break;
						case 3:
							if (P_0 > 27000)
							{
								goto case 1;
							}
							if (P_0 < 9000)
							{
								num = -1213199825;
								continue;
							}
							if (P_0 < 27000)
							{
								num = -1213199830;
								continue;
							}
							goto IL_0074;
						case 1:
							return 1f;
						case 4:
							if (P_0 > 9000)
							{
								num = -1213199828;
								continue;
							}
							goto IL_0074;
						default:
							{
								return -1f;
							}
							IL_0074:
							return 0f;
						}
						break;
					}
				}
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

		private ControlDeviceType fGrvGrxiPTIjODoVKziAvrnMkT(wQJNyUaUvslgkGHqqbQGKnHjBYM P_0)
		{
			if (P_0 == wQJNyUaUvslgkGHqqbQGKnHjBYM.PuCbofQgRbFngIhqGEvCTItySLuC)
			{
				return ControlDeviceType.PuCbofQgRbFngIhqGEvCTItySLuC;
			}
			if (P_0 == wQJNyUaUvslgkGHqqbQGKnHjBYM.OjRdrXVzVQaGEGzhFLzNjhrLLBZ)
			{
				goto IL_0009;
			}
			if (P_0 == wQJNyUaUvslgkGHqqbQGKnHjBYM.GHCARZcZuTQFTJwhHaaINSEOYrk)
			{
				return ControlDeviceType.GHCARZcZuTQFTJwhHaaINSEOYrk;
			}
			int num;
			if (P_0 == wQJNyUaUvslgkGHqqbQGKnHjBYM.nLYuKjOBqUkoTONDQzckmzvJOpb)
			{
				num = -1060585374;
				goto IL_000e;
			}
			return ControlDeviceType.XYhwUwaOlrfFTKoMRqftWpJVYyOD;
			IL_0009:
			num = -1060585373;
			goto IL_000e;
			IL_000e:
			switch (num ^ -1060585374)
			{
			case 2:
				break;
			case 1:
				return ControlDeviceType.OjRdrXVzVQaGEGzhFLzNjhrLLBZ;
			default:
				return ControlDeviceType.nLYuKjOBqUkoTONDQzckmzvJOpb;
			}
			goto IL_0009;
		}

		private void cYHcXCOFpORyFoNYyhyTldjiUMD()
		{
			kABaypBwJpdJPQfaNrcsDzJUopW = SquvrBwjLHJfDioapylbqZuppCD(qOeDHherkAoikMXOIsfGhJBfRvh());
			if (kABaypBwJpdJPQfaNrcsDzJUopW == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			while (kABaypBwJpdJPQfaNrcsDzJUopW.useSystemName && !string.IsNullOrEmpty(tbpVRpBintMlFYmEBYAejKmUJRZ))
			{
				string text = Regex.Replace(tbpVRpBintMlFYmEBYAejKmUJRZ, "\\s+", " ");
				text = text.Trim();
				if (string.IsNullOrEmpty(text))
				{
					break;
				}
				kABaypBwJpdJPQfaNrcsDzJUopW.controllerName = text;
				int num = 1687898141;
				while (true)
				{
					switch (num ^ 0x649B481C)
					{
					case 0:
						num = 1687898142;
						continue;
					case 2:
						break;
					default:
						goto end_IL_0048;
					}
					break;
				}
				continue;
				end_IL_0048:
				break;
			}
			NTatWULjiHpTYqyINRDSMJXXVvR = kABaypBwJpdJPQfaNrcsDzJUopW.axisCount;
			UsfsOskiNyjyRRYviYBYSQeIHPE = kABaypBwJpdJPQfaNrcsDzJUopW.buttonCount;
		}

		private string kBUmalGNIKAaGKQCRMlxUGQYoGzN()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), cQAbwffNRFwBZBvyPeSpfAaABXvc.InputSource, ubFxRAANNNuvDTppDHhsfZqrrTe, MBlnXHlBnwRpMqEKOvVoilzgzEB, wMQkUdjKDZdPGBUJeJKzEFSdMDTF.ToProductGuid()));
		}

		private void VDeqJOjTSTlabFOpcCmVfVrbzeiM(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.SDL2;
			P_0.inputSource = cQAbwffNRFwBZBvyPeSpfAaABXvc.InputSource;
			P_0.deviceType = fGrvGrxiPTIjODoVKziAvrnMkT(viWvrGBFplpSGbGOfgAjDicUVNU);
			P_0.hardwareIdentifier = kBUmalGNIKAaGKQCRMlxUGQYoGzN();
			P_0.hardwareAxisCount = YEZgNdJkWdDhBOvxapXVbnLavXwP;
			P_0.hardwareButtonCount = VEwPZpcCBNaKrRnFyrYRJVohPVc;
			P_0.hardwareHatCount = muqcoKtsIxBhKaKEKUceDAlgNRL;
			P_0.hw_productName = ubFxRAANNNuvDTppDHhsfZqrrTe;
			P_0.hw_deviceGuid = PXqNZrJMXSojPxhffbCdeIGJhWcf;
			P_0.hw_productId = MBlnXHlBnwRpMqEKOvVoilzgzEB;
			P_0.hw_pidVid = wMQkUdjKDZdPGBUJeJKzEFSdMDTF;
			P_0.hw_isBluetoothDevice = kSItSFmbvTzcvaKvvviPTGktjjic;
			P_0.hw_bluetoothDeviceName = ubFxRAANNNuvDTppDHhsfZqrrTe;
			P_0.hw_systemDeviceName = ubFxRAANNNuvDTppDHhsfZqrrTe;
			P_0.hw_supportsVibration = JgidXSSSAGvvkDcAIVICtlmgnKR;
			P_0.hw_isSDL2Gamepad = cQAbwffNRFwBZBvyPeSpfAaABXvc.DeviceType == wQJNyUaUvslgkGHqqbQGKnHjBYM.OjRdrXVzVQaGEGzhFLzNjhrLLBZ;
			P_0.hw_localVibrationMotorCount = QTcZLynCWHLLppDxcAAAPxKXLEc;
		}

		private void VDeqJOjTSTlabFOpcCmVfVrbzeiM(BridgedController P_0)
		{
			VDeqJOjTSTlabFOpcCmVfVrbzeiM((BridgedControllerHWInfo)P_0);
			while (true)
			{
				int num = 2043711114;
				while (true)
				{
					switch (num ^ 0x79D08E8E)
					{
					case 2:
						break;
					case 3:
						P_0.buttonCount = UsfsOskiNyjyRRYviYBYSQeIHPE;
						num = 2043711119;
						continue;
					case 0:
						P_0.instanceName = ubFxRAANNNuvDTppDHhsfZqrrTe;
						P_0.productName = ubFxRAANNNuvDTppDHhsfZqrrTe;
						P_0.axisCount = NTatWULjiHpTYqyINRDSMJXXVvR;
						num = 2043711117;
						continue;
					case 4:
						P_0.sourceJoystick = this;
						P_0.gameHardwareMap = kABaypBwJpdJPQfaNrcsDzJUopW.ToGameHardwareControllerMap();
						num = 2043711118;
						continue;
					default:
						P_0.unknownControllerHats = cZKKtjFxHVHRmwNFdXkqBvJjWzC();
						P_0.controllerTypeGuid = ocZIgneRSUDLHotByUrmWfynkiD;
						P_0.controllerExtension = extension;
						return;
					}
					break;
				}
			}
		}

		private void brsDapQXrGBkdEYpGtzSUxqDfVba()
		{
			int num = 0;
			int num2 = default(int);
			while (true)
			{
				IL_0061:
				int num3;
				if (num >= UsfsOskiNyjyRRYviYBYSQeIHPE)
				{
					num2 = 0;
					num3 = 1408498661;
					goto IL_0009;
				}
				goto IL_0051;
				IL_0009:
				while (true)
				{
					switch (num3 ^ 0x53F3FBE7)
					{
					case 0:
						num3 = 1408498658;
						continue;
					case 1:
						wbUISjltnzArWBKEUafkjffKERTS[num2] = 0f;
						num2++;
						num3 = 1408498661;
						continue;
					case 3:
						num++;
						num3 = 1408498659;
						continue;
					case 5:
						break;
					case 4:
						goto IL_0061;
					default:
						if (num2 >= NTatWULjiHpTYqyINRDSMJXXVvR)
						{
							return;
						}
						goto case 1;
					}
					break;
				}
				goto IL_0051;
				IL_0051:
				CFcByKWcDyyvXwtHigPcgEPuCPR[num] = false;
				num3 = 1408498660;
				goto IL_0009;
			}
		}

		private UnknownControllerHat[] cZKKtjFxHVHRmwNFdXkqBvJjWzC()
		{
			if (!BWNCoGmOwkTflVtLyUCybvonruM)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			int num = 0;
			int[] array2 = default(int[]);
			int num3 = default(int);
			while (true)
			{
				int num2 = 1221115664;
				while (true)
				{
					switch (num2 ^ 0x48C8BF14)
					{
					case 3:
						break;
					case 4:
						num2 = 1221115665;
						continue;
					case 1:
					{
						array2[3] = num3 + 3;
						array2[4] = num3 + 4;
						array2[5] = num3 + 5;
						array2[6] = num3 + 6;
						array2[7] = num3 + 7;
						UnknownControllerHat.HatButtons buttons = new UnknownControllerHat.HatButtons(array2);
						array[num] = new UnknownControllerHat(buttons);
						num++;
						num2 = 1221115665;
						continue;
					}
					case 2:
						num3 = 128 + num * 8;
						array2 = new int[8];
						num2 = 1221115668;
						continue;
					case 0:
						array2[0] = num3;
						array2[1] = num3 + 1;
						array2[2] = num3 + 2;
						num2 = 1221115669;
						continue;
					default:
						if (num >= 2)
						{
							return array;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public static int zmQlznUzlUiCzHqfYViktMhhuKc(pkFwwXNgPsUAHNkXgqodKLsnqBS P_0, pkFwwXNgPsUAHNkXgqodKLsnqBS P_1)
		{
			if (P_0.pypcACKajeDXMgihCBBcoMfRHezM < P_1.pypcACKajeDXMgihCBBcoMfRHezM)
			{
				return -1;
			}
			if (P_0.pypcACKajeDXMgihCBBcoMfRHezM > P_1.pypcACKajeDXMgihCBBcoMfRHezM)
			{
				return 1;
			}
			return 0;
		}

		public static int jLiPHBpjTmCeLGMcBwqEJZJkwYP(pkFwwXNgPsUAHNkXgqodKLsnqBS P_0, pkFwwXNgPsUAHNkXgqodKLsnqBS P_1)
		{
			if (P_0.VEHPIavzDVjAYkBtLrqAgBoFQZp < P_1.VEHPIavzDVjAYkBtLrqAgBoFQZp)
			{
				return -1;
			}
			if (P_0.VEHPIavzDVjAYkBtLrqAgBoFQZp > P_1.VEHPIavzDVjAYkBtLrqAgBoFQZp)
			{
				return 1;
			}
			return 0;
		}
	}

	private class gqVOweREYXhIKoQGEiYRrBKrDpW
	{
		public enum mqBBYDcGaCgWXlcIkYaLgKgiXqK
		{
			OhRlOZGftuFdhsJLJdBYcXflSzkM = 0,
			miFZPclZwwzlANpYVeOKmkxlzSo = 1
		}

		public class NbZpnZLMgvqCdkFFacrnbyoACafE
		{
			public int lJGmoPjWlZhCnfYmPrnrnNrpiFd;

			public Guid lTmxvbpsRsiExyqKrXNlyAuEpLd;

			public Guid bDjREJxTewszSCCahgztXzcduUN;

			public int hkuClqGgyrjaNFrDJJuCSthMWeZ;

			public int YEZgNdJkWdDhBOvxapXVbnLavXwP;

			public int VEwPZpcCBNaKrRnFyrYRJVohPVc;

			public int muqcoKtsIxBhKaKEKUceDAlgNRL;

			public bool texDHprRVSCDIhdEcHxFsscbHjUA(pkFwwXNgPsUAHNkXgqodKLsnqBS P_0, mqBBYDcGaCgWXlcIkYaLgKgiXqK P_1)
			{
				if (P_0.rewiredId == lJGmoPjWlZhCnfYmPrnrnNrpiFd)
				{
					return true;
				}
				if (YEZgNdJkWdDhBOvxapXVbnLavXwP != P_0.YEZgNdJkWdDhBOvxapXVbnLavXwP)
				{
					goto IL_001e;
				}
				if (VEwPZpcCBNaKrRnFyrYRJVohPVc != P_0.VEwPZpcCBNaKrRnFyrYRJVohPVc)
				{
					return false;
				}
				if (muqcoKtsIxBhKaKEKUceDAlgNRL != P_0.muqcoKtsIxBhKaKEKUceDAlgNRL)
				{
					return false;
				}
				int num;
				if (P_1 == mqBBYDcGaCgWXlcIkYaLgKgiXqK.OhRlOZGftuFdhsJLJdBYcXflSzkM)
				{
					num = -1255774771;
					goto IL_0023;
				}
				if (P_1 == mqBBYDcGaCgWXlcIkYaLgKgiXqK.miFZPclZwwzlANpYVeOKmkxlzSo)
				{
					return bDjREJxTewszSCCahgztXzcduUN == P_0.bDjREJxTewszSCCahgztXzcduUN;
				}
				throw new NotImplementedException();
				IL_0023:
				switch (num ^ -1255774771)
				{
				case 2:
					break;
				case 1:
					return false;
				default:
					return lTmxvbpsRsiExyqKrXNlyAuEpLd == P_0.PXqNZrJMXSojPxhffbCdeIGJhWcf;
				}
				goto IL_001e;
				IL_001e:
				num = -1255774772;
				goto IL_0023;
			}
		}

		private List<NbZpnZLMgvqCdkFFacrnbyoACafE> KbaDSiCRyndUgELDxxppquzLFodU;

		public gqVOweREYXhIKoQGEiYRrBKrDpW()
		{
			KbaDSiCRyndUgELDxxppquzLFodU = new List<NbZpnZLMgvqCdkFFacrnbyoACafE>();
		}

		public void CzcBIezjgBkIUujMOARHJgPbWVOP(pkFwwXNgPsUAHNkXgqodKLsnqBS P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int num2 = default(int);
			while (true)
			{
				int count = KbaDSiCRyndUgELDxxppquzLFodU.Count;
				int num = 1109813229;
				while (true)
				{
					switch (num ^ 0x422667E9)
					{
					case 7:
						num = 1109813228;
						continue;
					case 10:
						KbaDSiCRyndUgELDxxppquzLFodU[num2].lTmxvbpsRsiExyqKrXNlyAuEpLd = P_0.PXqNZrJMXSojPxhffbCdeIGJhWcf;
						KbaDSiCRyndUgELDxxppquzLFodU[num2].bDjREJxTewszSCCahgztXzcduUN = P_0.bDjREJxTewszSCCahgztXzcduUN;
						num = 1109813217;
						continue;
					case 11:
						num2++;
						num = 1109813224;
						continue;
					case 4:
						num2 = 0;
						num = 1109813225;
						continue;
					case 5:
						break;
					case 9:
						iAyKOJFTncPoHepzJVFmwURBpNi(P_0.rewiredId, P_0.PXqNZrJMXSojPxhffbCdeIGJhWcf, num2);
						return;
					case 2:
						if (KbaDSiCRyndUgELDxxppquzLFodU[num2].texDHprRVSCDIhdEcHxFsscbHjUA(P_0, mqBBYDcGaCgWXlcIkYaLgKgiXqK.OhRlOZGftuFdhsJLJdBYcXflSzkM))
						{
							KbaDSiCRyndUgELDxxppquzLFodU[num2].lJGmoPjWlZhCnfYmPrnrnNrpiFd = P_0.rewiredId;
							num = 1109813219;
							continue;
						}
						goto case 11;
					case 6:
						KbaDSiCRyndUgELDxxppquzLFodU[num2].VEwPZpcCBNaKrRnFyrYRJVohPVc = P_0.VEwPZpcCBNaKrRnFyrYRJVohPVc;
						KbaDSiCRyndUgELDxxppquzLFodU[num2].muqcoKtsIxBhKaKEKUceDAlgNRL = P_0.muqcoKtsIxBhKaKEKUceDAlgNRL;
						num = 1109813216;
						continue;
					case 8:
						KbaDSiCRyndUgELDxxppquzLFodU[num2].hkuClqGgyrjaNFrDJJuCSthMWeZ = P_0.inputManagerId;
						num = 1109813226;
						continue;
					case 3:
						KbaDSiCRyndUgELDxxppquzLFodU[num2].YEZgNdJkWdDhBOvxapXVbnLavXwP = P_0.YEZgNdJkWdDhBOvxapXVbnLavXwP;
						num = 1109813231;
						continue;
					case 0:
						num = 1109813224;
						continue;
					default:
						if (num2 >= count)
						{
							KbaDSiCRyndUgELDxxppquzLFodU.Add(new NbZpnZLMgvqCdkFFacrnbyoACafE
							{
								lJGmoPjWlZhCnfYmPrnrnNrpiFd = P_0.rewiredId,
								lTmxvbpsRsiExyqKrXNlyAuEpLd = P_0.PXqNZrJMXSojPxhffbCdeIGJhWcf,
								bDjREJxTewszSCCahgztXzcduUN = P_0.bDjREJxTewszSCCahgztXzcduUN,
								hkuClqGgyrjaNFrDJJuCSthMWeZ = P_0.inputManagerId,
								YEZgNdJkWdDhBOvxapXVbnLavXwP = P_0.YEZgNdJkWdDhBOvxapXVbnLavXwP,
								VEwPZpcCBNaKrRnFyrYRJVohPVc = P_0.VEwPZpcCBNaKrRnFyrYRJVohPVc,
								muqcoKtsIxBhKaKEKUceDAlgNRL = P_0.muqcoKtsIxBhKaKEKUceDAlgNRL
							});
							iAyKOJFTncPoHepzJVFmwURBpNi(P_0.rewiredId, P_0.PXqNZrJMXSojPxhffbCdeIGJhWcf, KbaDSiCRyndUgELDxxppquzLFodU.Count - 1);
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public bool hVhfCpEYePxtliVMkmzCRpiiDkB(pkFwwXNgPsUAHNkXgqodKLsnqBS P_0, mqBBYDcGaCgWXlcIkYaLgKgiXqK P_1)
		{
			int count = KbaDSiCRyndUgELDxxppquzLFodU.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					if (KbaDSiCRyndUgELDxxppquzLFodU[num].texDHprRVSCDIhdEcHxFsscbHjUA(P_0, P_1))
					{
						return true;
					}
					num++;
					int num2 = -938135034;
					while (true)
					{
						switch (num2 ^ -938135036)
						{
						case 0:
							num2 = -938135035;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002e;
						}
						break;
					}
					continue;
					end_IL_002e:
					break;
				}
			}
			return false;
		}

		public NbZpnZLMgvqCdkFFacrnbyoACafE lYJFZOeYSDYSWqqagvNTnOjxepl(pkFwwXNgPsUAHNkXgqodKLsnqBS P_0, mqBBYDcGaCgWXlcIkYaLgKgiXqK P_1)
		{
			int count = KbaDSiCRyndUgELDxxppquzLFodU.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					if (KbaDSiCRyndUgELDxxppquzLFodU[num].texDHprRVSCDIhdEcHxFsscbHjUA(P_0, P_1))
					{
						return KbaDSiCRyndUgELDxxppquzLFodU[num];
					}
					num++;
					int num2 = -1888679135;
					while (true)
					{
						switch (num2 ^ -1888679135)
						{
						case 2:
							num2 = -1888679136;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002e;
						}
						break;
					}
					continue;
					end_IL_002e:
					break;
				}
			}
			return null;
		}

		private void iAyKOJFTncPoHepzJVFmwURBpNi(int P_0, Guid P_1, int P_2)
		{
			int num = KbaDSiCRyndUgELDxxppquzLFodU.Count - 1;
			while (num >= 0)
			{
				while (true)
				{
					IL_0072:
					int num2;
					if (num != P_2)
					{
						int num3;
						if (KbaDSiCRyndUgELDxxppquzLFodU[num].lJGmoPjWlZhCnfYmPrnrnNrpiFd != P_0)
						{
							num2 = 869021910;
							num3 = num2;
						}
						else
						{
							num2 = 869021905;
							num3 = num2;
						}
						goto IL_0018;
					}
					goto IL_003d;
					IL_0018:
					while (true)
					{
						switch (num2 ^ 0x33CC38D5)
						{
						case 0:
							num2 = 869021911;
							continue;
						case 5:
							break;
						case 3:
							goto IL_0048;
						case 2:
							goto IL_0072;
						case 4:
							KbaDSiCRyndUgELDxxppquzLFodU.RemoveAt(num);
							num2 = 869021904;
							continue;
						default:
							goto end_IL_0072;
						}
						break;
						IL_0048:
						int num4;
						if (KbaDSiCRyndUgELDxxppquzLFodU[num].lTmxvbpsRsiExyqKrXNlyAuEpLd == P_1)
						{
							num2 = 869021905;
							num4 = num2;
						}
						else
						{
							num2 = 869021904;
							num4 = num2;
						}
					}
					goto IL_003d;
					IL_003d:
					num--;
					num2 = 869021908;
					goto IL_0018;
					continue;
					end_IL_0072:
					break;
				}
			}
		}
	}

	internal const bool XUOkwXECnauQSqdUWvtDGoPEwwB = true;

	private IInputSource sIivcCoCkwTtlsLUOdbFtQRFopY;

	private List<pkFwwXNgPsUAHNkXgqodKLsnqBS> jkFiqNnyAtbymFOLlvWZRfYeLku;

	private int QpGtgOrxdSaeYYJRHgHfdBynVbjv;

	private gqVOweREYXhIKoQGEiYRrBKrDpW cBQhEyiNFbRkGCtCdGNTEMPiFbh;

	private bool oCfgXkGkSgDkbBQjCfrbIAyBZc;

	private Action<int, ControllerDataUpdater> xykDZfHJBUnQEfowVcHAJyncPoER;

	private PlatformInputManager hdSfCWqBbgExirMqfOCeUEacXMD;

	private readonly bool GFOBjFaStuGtqdhXChMRrxXGhaGJ;

	private readonly bool wRKFazdkphScTnCtRJlrOfqlPrVc;

	private readonly bool HTbuCzrVISVHITgLmqOPxlHXTus;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> SquvrBwjLHJfDioapylbqZuppCD;

	private readonly Func<int> JWZMJaIeQbeZYzwUqzlBWSLcbtjA;

	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			return QpGtgOrxdSaeYYJRHgHfdBynVbjv;
		}
	}

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager
	{
		get
		{
			return hdSfCWqBbgExirMqfOCeUEacXMD;
		}
	}

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource
	{
		get
		{
			return sIivcCoCkwTtlsLUOdbFtQRFopY;
		}
	}

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			return InputSource.SDL2;
		}
	}

	public aGsWVmtUFyuDlOkxcPJGtOTFmBv(ConfigVars configVars, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId, bool handleJoysticks, bool handleUnifiedMouse, bool handleUnifiedKeyboard)
	{
		try
		{
			SquvrBwjLHJfDioapylbqZuppCD = getHardwareJoystickMap_InputManager;
			JWZMJaIeQbeZYzwUqzlBWSLcbtjA = getNewJoystickId;
			GFOBjFaStuGtqdhXChMRrxXGhaGJ = handleJoysticks;
			wRKFazdkphScTnCtRJlrOfqlPrVc = handleUnifiedMouse;
			HTbuCzrVISVHITgLmqOPxlHXTus = handleUnifiedKeyboard;
			hdSfCWqBbgExirMqfOCeUEacXMD = this;
			sIivcCoCkwTtlsLUOdbFtQRFopY = new SDL2InputSource(configVars.updateLoop, handleJoysticks, handleJoysticks, handleUnifiedMouse, handleUnifiedKeyboard);
			xykDZfHJBUnQEfowVcHAJyncPoER = UpdateControllerData;
			sIivcCoCkwTtlsLUOdbFtQRFopY.DeviceChangedEvent += wubQuhYteLdprRmhoURXDsKQAnd;
		}
		catch (Exception ex)
		{
			OnDestroy();
			throw ex;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (GFOBjFaStuGtqdhXChMRrxXGhaGJ)
		{
			cBQhEyiNFbRkGCtCdGNTEMPiFbh = new gqVOweREYXhIKoQGEiYRrBKrDpW();
			pBKGiqCzbgfPGMFhRdFSwUDshjx();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (sIivcCoCkwTtlsLUOdbFtQRFopY != null)
		{
			goto IL_000b;
		}
		goto IL_008b;
		IL_000b:
		int num = -347003301;
		goto IL_0010;
		IL_0010:
		pkFwwXNgPsUAHNkXgqodKLsnqBS pkFwwXNgPsUAHNkXgqodKLsnqBS2 = default(pkFwwXNgPsUAHNkXgqodKLsnqBS);
		int num2 = default(int);
		pkFwwXNgPsUAHNkXgqodKLsnqBS pkFwwXNgPsUAHNkXgqodKLsnqBS3 = default(pkFwwXNgPsUAHNkXgqodKLsnqBS);
		int num3 = default(int);
		while (true)
		{
			switch (num ^ -347003298)
			{
			case 0:
				break;
			case 8:
				goto IL_006c;
			case 7:
				goto IL_008b;
			case 1:
				if (pkFwwXNgPsUAHNkXgqodKLsnqBS2 != null)
				{
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.cQAbwffNRFwBZBvyPeSpfAaABXvc.UpdateFinished();
					num = -347003314;
					continue;
				}
				goto case 16;
			case 9:
				goto IL_00cd;
			case 5:
				sIivcCoCkwTtlsLUOdbFtQRFopY.Update();
				num = -347003303;
				continue;
			case 2:
				num2 = 0;
				num = -347003311;
				continue;
			case 17:
				pkFwwXNgPsUAHNkXgqodKLsnqBS3 = jkFiqNnyAtbymFOLlvWZRfYeLku[num2];
				num = -347003305;
				continue;
			case 4:
				pkFwwXNgPsUAHNkXgqodKLsnqBS3.cQAbwffNRFwBZBvyPeSpfAaABXvc.Update(updateLoop);
				num = -347003308;
				continue;
			case 15:
				goto IL_0132;
			case 12:
				goto IL_014f;
			case 6:
				goto IL_016b;
			case 13:
				pkFwwXNgPsUAHNkXgqodKLsnqBS2 = jkFiqNnyAtbymFOLlvWZRfYeLku[num3];
				num = -347003297;
				continue;
			case 3:
				lMlcWXDhUZyoYToHgCauFZahHGiP();
				num = -347003310;
				continue;
			case 18:
				sIivcCoCkwTtlsLUOdbFtQRFopY.UpdateDevices(updateLoop);
				num = -347003306;
				continue;
			case 14:
				sIivcCoCkwTtlsLUOdbFtQRFopY.UpdateFinished();
				num3 = 0;
				num = -347003304;
				continue;
			case 10:
				num2++;
				num = -347003311;
				continue;
			case 16:
				num3++;
				num = -347003304;
				continue;
			default:
				goto IL_01f8;
			}
			break;
			IL_016b:
			int num4;
			if (num3 >= QpGtgOrxdSaeYYJRHgHfdBynVbjv)
			{
				num = -347003307;
				num4 = num;
			}
			else
			{
				num = -347003309;
				num4 = num;
			}
			continue;
			IL_006c:
			OojMLjXcFZUGyMEfOYjCmtjMhke();
			int num5;
			if (sIivcCoCkwTtlsLUOdbFtQRFopY == null)
			{
				num = -347003307;
				num5 = num;
			}
			else
			{
				num = -347003312;
				num5 = num;
			}
			continue;
			IL_0132:
			int num6;
			if (num2 < QpGtgOrxdSaeYYJRHgHfdBynVbjv)
			{
				num = -347003313;
				num6 = num;
			}
			else
			{
				num = -347003316;
				num6 = num;
			}
			continue;
			IL_014f:
			int num7;
			if (sIivcCoCkwTtlsLUOdbFtQRFopY != null)
			{
				num = -347003300;
				num7 = num;
			}
			else
			{
				num = -347003306;
				num7 = num;
			}
			continue;
			IL_00cd:
			int num8;
			if (pkFwwXNgPsUAHNkXgqodKLsnqBS3 == null)
			{
				num = -347003308;
				num8 = num;
			}
			else
			{
				num = -347003302;
				num8 = num;
			}
		}
		goto IL_000b;
		IL_01f8:
		bool wRKFazdkphScTnCtRJlrOfqlPrVc2 = wRKFazdkphScTnCtRJlrOfqlPrVc;
		return;
		IL_008b:
		if (GFOBjFaStuGtqdhXChMRrxXGhaGJ)
		{
			int num9;
			if (oCfgXkGkSgDkbBQjCfrbIAyBZc)
			{
				num = -347003299;
				num9 = num;
			}
			else
			{
				num = -347003310;
				num9 = num;
			}
			goto IL_0010;
		}
		goto IL_01f8;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (jkFiqNnyAtbymFOLlvWZRfYeLku != null)
		{
			goto IL_0008;
		}
		goto IL_003d;
		IL_0008:
		int num = -808819948;
		goto IL_000d;
		IL_000d:
		int num2 = default(int);
		int count = default(int);
		CjjRDclXuvjouyeLLeBBHCfpqqbM cQAbwffNRFwBZBvyPeSpfAaABXvc = default(CjjRDclXuvjouyeLLeBBHCfpqqbM);
		while (true)
		{
			switch (num ^ -808819947)
			{
			case 6:
				break;
			default:
				return;
			case 0:
				goto IL_003d;
			case 4:
				num2++;
				num = -808819950;
				continue;
			case 1:
				count = jkFiqNnyAtbymFOLlvWZRfYeLku.Count;
				num2 = 0;
				num = -808819950;
				continue;
			case 3:
				if (jkFiqNnyAtbymFOLlvWZRfYeLku[num2] == null)
				{
					goto case 4;
				}
				goto IL_0088;
			case 7:
				goto IL_00b1;
			case 2:
				cQAbwffNRFwBZBvyPeSpfAaABXvc.Unacquire();
				num = -808819951;
				continue;
			case 5:
				return;
			}
			break;
			IL_00b1:
			int num3;
			if (num2 < count)
			{
				num = -808819946;
				num3 = num;
			}
			else
			{
				num = -808819947;
				num3 = num;
			}
			continue;
			IL_0088:
			cQAbwffNRFwBZBvyPeSpfAaABXvc = jkFiqNnyAtbymFOLlvWZRfYeLku[num2].cQAbwffNRFwBZBvyPeSpfAaABXvc;
			int num4;
			if (cQAbwffNRFwBZBvyPeSpfAaABXvc != null)
			{
				num = -808819945;
				num4 = num;
			}
			else
			{
				num = -808819951;
				num4 = num;
			}
		}
		goto IL_0008;
		IL_003d:
		if (sIivcCoCkwTtlsLUOdbFtQRFopY != null)
		{
			sIivcCoCkwTtlsLUOdbFtQRFopY.Dispose();
			num = -808819952;
			goto IL_000d;
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return xykDZfHJBUnQEfowVcHAJyncPoER;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!GFOBjFaStuGtqdhXChMRrxXGhaGJ)
		{
			goto IL_0008;
		}
		goto IL_0087;
		IL_0008:
		int num = 1374746429;
		goto IL_000d;
		IL_000d:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x51F0F738)
			{
			case 4:
				break;
			default:
				return;
			case 1:
				num2++;
				num = 1374746424;
				continue;
			case 8:
				return;
			case 3:
				jkFiqNnyAtbymFOLlvWZRfYeLku[num2].FillData(data);
				num = 1374746416;
				continue;
			case 0:
				goto IL_006d;
			case 2:
				goto IL_0087;
			case 7:
				goto IL_0093;
			case 5:
				return;
			case 6:
				return;
			}
			break;
			IL_0093:
			int num3;
			if (jkFiqNnyAtbymFOLlvWZRfYeLku[num2].inputManagerId != inputManagerId)
			{
				num = 1374746425;
				num3 = num;
			}
			else
			{
				num = 1374746427;
				num3 = num;
			}
			continue;
			IL_006d:
			int num4;
			if (num2 < QpGtgOrxdSaeYYJRHgHfdBynVbjv)
			{
				num = 1374746431;
				num4 = num;
			}
			else
			{
				num = 1374746430;
				num4 = num;
			}
		}
		goto IL_0008;
		IL_0087:
		num2 = 0;
		num = 1374746424;
		goto IL_000d;
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		if (GFOBjFaStuGtqdhXChMRrxXGhaGJ)
		{
			goto IL_0008;
		}
		goto IL_004e;
		IL_0008:
		int num = 1602009241;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x5F7CB898)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				oCfgXkGkSgDkbBQjCfrbIAyBZc = true;
				num = 1602009244;
				continue;
			case 2:
				_SystemDeviceConnectedEvent();
				num = 1602009240;
				continue;
			case 4:
				goto IL_004e;
			case 0:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_004e:
		int num2;
		if (_SystemDeviceConnectedEvent != null)
		{
			num = 1602009242;
			num2 = num;
		}
		else
		{
			num = 1602009240;
			num2 = num;
		}
		goto IL_000d;
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		if (GFOBjFaStuGtqdhXChMRrxXGhaGJ)
		{
			goto IL_0008;
		}
		goto IL_0038;
		IL_0008:
		int num = 1516287892;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x5A60B796)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				oCfgXkGkSgDkbBQjCfrbIAyBZc = true;
				num = 1516287893;
				continue;
			case 3:
				goto IL_0038;
			case 1:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_0038:
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
			num = 1516287895;
			goto IL_000d;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		bool gFOBjFaStuGtqdhXChMRrxXGhaGJ = GFOBjFaStuGtqdhXChMRrxXGhaGJ;
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

	private void pBKGiqCzbgfPGMFhRdFSwUDshjx()
	{
		pBKGiqCzbgfPGMFhRdFSwUDshjx(esEBRpPnUXWKXaqSRtgPrIbfntV());
	}

	private void pBKGiqCzbgfPGMFhRdFSwUDshjx(IList<CjjRDclXuvjouyeLLeBBHCfpqqbM> P_0)
	{
		int num = 0;
		List<pkFwwXNgPsUAHNkXgqodKLsnqBS> list = jkFiqNnyAtbymFOLlvWZRfYeLku;
		int qpGtgOrxdSaeYYJRHgHfdBynVbjv = QpGtgOrxdSaeYYJRHgHfdBynVbjv;
		pkFwwXNgPsUAHNkXgqodKLsnqBS pkFwwXNgPsUAHNkXgqodKLsnqBS2 = default(pkFwwXNgPsUAHNkXgqodKLsnqBS);
		CjjRDclXuvjouyeLLeBBHCfpqqbM cjjRDclXuvjouyeLLeBBHCfpqqbM = default(CjjRDclXuvjouyeLLeBBHCfpqqbM);
		int num3 = default(int);
		int num4 = default(int);
		int count = default(int);
		while (true)
		{
			int num2 = 852418627;
			while (true)
			{
				switch (num2 ^ 0x32CEE046)
				{
				case 0:
					break;
				case 3:
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.extension = cjjRDclXuvjouyeLLeBBHCfpqqbM.ControllerExtension;
					cjjRDclXuvjouyeLLeBBHCfpqqbM.Acquire();
					num2 = 852418647;
					continue;
				case 15:
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.PXqNZrJMXSojPxhffbCdeIGJhWcf = cjjRDclXuvjouyeLLeBBHCfpqqbM.InstanceGuid;
					num2 = 852418628;
					continue;
				case 4:
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.muqcoKtsIxBhKaKEKUceDAlgNRL = cjjRDclXuvjouyeLLeBBHCfpqqbM.HatCount;
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.kSItSFmbvTzcvaKvvviPTGktjjic = cjjRDclXuvjouyeLLeBBHCfpqqbM.IsBluetoothDevice;
					num2 = 852418636;
					continue;
				case 9:
					if (P_0[num3] != null)
					{
						cjjRDclXuvjouyeLLeBBHCfpqqbM = P_0[num3];
						pkFwwXNgPsUAHNkXgqodKLsnqBS2 = new pkFwwXNgPsUAHNkXgqodKLsnqBS(SquvrBwjLHJfDioapylbqZuppCD);
						pkFwwXNgPsUAHNkXgqodKLsnqBS2.cQAbwffNRFwBZBvyPeSpfAaABXvc = cjjRDclXuvjouyeLLeBBHCfpqqbM;
						num2 = 852418633;
						continue;
					}
					goto case 6;
				case 2:
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.ubFxRAANNNuvDTppDHhsfZqrrTe = cjjRDclXuvjouyeLLeBBHCfpqqbM.SystemName;
					num2 = 852418635;
					continue;
				case 6:
					num3++;
					num2 = 852418632;
					continue;
				case 10:
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.JgidXSSSAGvvkDcAIVICtlmgnKR = cjjRDclXuvjouyeLLeBBHCfpqqbM.SupportsVibration;
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.QTcZLynCWHLLppDxcAAAPxKXLEc = cjjRDclXuvjouyeLLeBBHCfpqqbM.VibrationMotorCount;
					num2 = 852418629;
					continue;
				case 11:
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(jkFiqNnyAtbymFOLlvWZRfYeLku[num4]));
					num2 = 852418631;
					continue;
				case 19:
				{
					int num6;
					if (_UpdateControllerInfoEvent == null)
					{
						num2 = 852418631;
						num6 = num2;
					}
					else
					{
						num2 = 852418637;
						num6 = num2;
					}
					continue;
				}
				case 1:
					num4++;
					num2 = 852418625;
					continue;
				case 12:
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.VEwPZpcCBNaKrRnFyrYRJVohPVc = cjjRDclXuvjouyeLLeBBHCfpqqbM.ButtonCount;
					num2 = 852418626;
					continue;
				case 18:
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.YEZgNdJkWdDhBOvxapXVbnLavXwP = cjjRDclXuvjouyeLLeBBHCfpqqbM.AxisCount;
					num2 = 852418634;
					continue;
				case 5:
					jkFiqNnyAtbymFOLlvWZRfYeLku = new List<pkFwwXNgPsUAHNkXgqodKLsnqBS>();
					count = P_0.Count;
					num3 = 0;
					num2 = 852418632;
					continue;
				case 7:
				{
					int num5;
					if (num4 < num)
					{
						num2 = 852418645;
						num5 = num2;
					}
					else
					{
						num2 = 852418646;
						num5 = num2;
					}
					continue;
				}
				case 14:
					if (num3 >= count)
					{
						QpGtgOrxdSaeYYJRHgHfdBynVbjv = num;
						nFPQMeOiyGmsFomDtcaSCOUgIsTF(qpGtgOrxdSaeYYJRHgHfdBynVbjv, num, list, jkFiqNnyAtbymFOLlvWZRfYeLku);
						num4 = 0;
						num2 = 852418625;
						continue;
					}
					goto case 9;
				case 8:
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.VEHPIavzDVjAYkBtLrqAgBoFQZp = cjjRDclXuvjouyeLLeBBHCfpqqbM.JoystickId;
					num2 = 852418644;
					continue;
				case 17:
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.NbodIzVoMOIfxhiTmzGcfYqHqqpP();
					jkFiqNnyAtbymFOLlvWZRfYeLku.Add(pkFwwXNgPsUAHNkXgqodKLsnqBS2);
					num++;
					num2 = 852418624;
					continue;
				case 13:
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.tbpVRpBintMlFYmEBYAejKmUJRZ = cjjRDclXuvjouyeLLeBBHCfpqqbM.FriendlyName;
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.wMQkUdjKDZdPGBUJeJKzEFSdMDTF = cjjRDclXuvjouyeLLeBBHCfpqqbM.PidVid;
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.MBlnXHlBnwRpMqEKOvVoilzgzEB = cjjRDclXuvjouyeLLeBBHCfpqqbM.ProductId;
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.aTbsowlFdtdDNHGQGyHgAISJkkq = cjjRDclXuvjouyeLLeBBHCfpqqbM.VendorId;
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.viWvrGBFplpSGbGOfgAjDicUVNU = cjjRDclXuvjouyeLLeBBHCfpqqbM.DeviceType;
					num2 = 852418638;
					continue;
				default:
					oQChKjbOquuMrWKdTwrmVgDaXkc(list, jkFiqNnyAtbymFOLlvWZRfYeLku, false);
					oQChKjbOquuMrWKdTwrmVgDaXkc(jkFiqNnyAtbymFOLlvWZRfYeLku, list, true);
					return;
				}
				break;
			}
		}
	}

	private void OojMLjXcFZUGyMEfOYjCmtjMhke()
	{
		int num = 0;
		while (true)
		{
			int num2 = 1939410669;
			while (true)
			{
				switch (num2 ^ 0x73990EEE)
				{
				case 0:
					break;
				case 3:
					num2 = 1939410671;
					continue;
				case 4:
				{
					pkFwwXNgPsUAHNkXgqodKLsnqBS pkFwwXNgPsUAHNkXgqodKLsnqBS2 = jkFiqNnyAtbymFOLlvWZRfYeLku[num];
					if (pkFwwXNgPsUAHNkXgqodKLsnqBS2 != null)
					{
						pkFwwXNgPsUAHNkXgqodKLsnqBS2.Update();
						num2 = 1939410668;
						continue;
					}
					goto case 2;
				}
				case 2:
					num++;
					num2 = 1939410671;
					continue;
				default:
					if (num >= QpGtgOrxdSaeYYJRHgHfdBynVbjv)
					{
						return;
					}
					goto case 4;
				}
				break;
			}
		}
	}

	private bool rRiCDgwDhQpMdXmMXVxhgYtzjXE(iflCBykpCtyCmFAlnduVbpFYFGW P_0)
	{
		try
		{
			return P_0.IsAttached();
		}
		catch
		{
			return false;
		}
	}

	private IList<CjjRDclXuvjouyeLLeBBHCfpqqbM> esEBRpPnUXWKXaqSRtgPrIbfntV()
	{
		return sIivcCoCkwTtlsLUOdbFtQRFopY.GetJoysticks<CjjRDclXuvjouyeLLeBBHCfpqqbM>();
	}

	private void nFPQMeOiyGmsFomDtcaSCOUgIsTF(int P_0, int P_1, List<pkFwwXNgPsUAHNkXgqodKLsnqBS> P_2, List<pkFwwXNgPsUAHNkXgqodKLsnqBS> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(pkFwwXNgPsUAHNkXgqodKLsnqBS.jLiPHBpjTmCeLGMcBwqEJZJkwYP);
			goto IL_001a;
		}
		goto IL_00bb;
		IL_00bb:
		bool flag = P_0 > 0 && P_1 > 0;
		int num = 336824691;
		goto IL_001f;
		IL_001a:
		num = 336824699;
		goto IL_001f;
		IL_001f:
		int num2 = default(int);
		pkFwwXNgPsUAHNkXgqodKLsnqBS pkFwwXNgPsUAHNkXgqodKLsnqBS2 = default(pkFwwXNgPsUAHNkXgqodKLsnqBS);
		while (true)
		{
			switch (num ^ 0x1413897A)
			{
			case 7:
				break;
			case 0:
				num2++;
				num = 336824696;
				continue;
			case 9:
				if (flag)
				{
					rXDbrbtyNWDCpRVSolUyjKvqIhp(P_1, P_3, P_0, P_2, gqVOweREYXhIKoQGEiYRrBKrDpW.mqBBYDcGaCgWXlcIkYaLgKgiXqK.OhRlOZGftuFdhsJLJdBYcXflSzkM);
					rXDbrbtyNWDCpRVSolUyjKvqIhp(P_1, P_3, P_0, P_2, gqVOweREYXhIKoQGEiYRrBKrDpW.mqBBYDcGaCgWXlcIkYaLgKgiXqK.miFZPclZwwzlANpYVeOKmkxlzSo);
					num = 336824690;
					continue;
				}
				goto case 8;
			case 5:
				xtNfNMKFmfYIygncVYHsbFvnNoe(P_1, P_3, gqVOweREYXhIKoQGEiYRrBKrDpW.mqBBYDcGaCgWXlcIkYaLgKgiXqK.miFZPclZwwzlANpYVeOKmkxlzSo);
				num2 = 0;
				num = 336824696;
				continue;
			case 6:
				if (pkFwwXNgPsUAHNkXgqodKLsnqBS2.inputManagerId < 0)
				{
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.inputManagerId = IojKdiCykxLgoivdxmqNHsMNBtN(P_3);
					num = 336824697;
					continue;
				}
				goto case 0;
			case 1:
				goto IL_00bb;
			case 3:
				pkFwwXNgPsUAHNkXgqodKLsnqBS2.rewiredId = JWZMJaIeQbeZYzwUqzlBWSLcbtjA();
				cBQhEyiNFbRkGCtCdGNTEMPiFbh.CzcBIezjgBkIUujMOARHJgPbWVOP(pkFwwXNgPsUAHNkXgqodKLsnqBS2);
				num = 336824698;
				continue;
			case 4:
				goto IL_00f8;
			case 8:
				xtNfNMKFmfYIygncVYHsbFvnNoe(P_1, P_3, gqVOweREYXhIKoQGEiYRrBKrDpW.mqBBYDcGaCgWXlcIkYaLgKgiXqK.OhRlOZGftuFdhsJLJdBYcXflSzkM);
				num = 336824703;
				continue;
			default:
				if (num2 >= P_1)
				{
					P_3.Sort(pkFwwXNgPsUAHNkXgqodKLsnqBS.zmQlznUzlUiCzHqfYViktMhhuKc);
					return;
				}
				goto IL_00f8;
			}
			break;
			IL_00f8:
			pkFwwXNgPsUAHNkXgqodKLsnqBS2 = P_3[num2];
			int num3;
			if (pkFwwXNgPsUAHNkXgqodKLsnqBS2 == null)
			{
				num = 336824698;
				num3 = num;
			}
			else
			{
				num = 336824700;
				num3 = num;
			}
		}
		goto IL_001a;
	}

	private void YzqMoBhvKRalBOYGHRNonNnPINV(List<pkFwwXNgPsUAHNkXgqodKLsnqBS> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		int num2 = default(int);
		while (true)
		{
			int num = -826271144;
			while (true)
			{
				switch (num ^ -826271143)
				{
				case 0:
					break;
				case 2:
					num2++;
					num = -826271139;
					continue;
				case 3:
					if (num2 != P_1 && P_0[num2] != null && P_0[num2].inputManagerId == P_2)
					{
						P_0[num2].inputManagerId = -1;
						num = -826271141;
						continue;
					}
					goto case 2;
				case 1:
					num2 = 0;
					num = -826271139;
					continue;
				default:
					if (num2 >= count)
					{
						return;
					}
					goto case 3;
				}
				break;
			}
		}
	}

	private bool WFsHpGVScPZlQaWKivTImrGOHRY(List<pkFwwXNgPsUAHNkXgqodKLsnqBS> P_0, int P_1)
	{
		int count = P_0.Count;
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num >= count)
			{
				num2 = 1349656083;
				num3 = num2;
			}
			else
			{
				num2 = 1349656086;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x50721E17)
				{
				case 3:
					num2 = 1349656086;
					continue;
				case 0:
					return false;
				case 5:
					break;
				case 1:
					if (P_0[num] != null)
					{
						num2 = 1349656085;
						continue;
					}
					goto IL_0037;
				case 2:
					if (P_0[num].inputManagerId == P_1)
					{
						num2 = 1349656087;
						continue;
					}
					goto IL_0037;
				default:
					{
						return true;
					}
					IL_0037:
					num++;
					num2 = 1349656082;
					continue;
				}
				break;
			}
		}
	}

	private int IojKdiCykxLgoivdxmqNHsMNBtN(List<pkFwwXNgPsUAHNkXgqodKLsnqBS> P_0)
	{
		int num = 0;
		bool flag = default(bool);
		int count = default(int);
		int num3 = default(int);
		while (true)
		{
			int num2 = -187993133;
			while (true)
			{
				switch (num2 ^ -187993129)
				{
				case 0:
					break;
				default:
					flag = false;
					count = P_0.Count;
					num3 = 0;
					num2 = -187993132;
					continue;
				case 6:
					num2 = -187993134;
					continue;
				case 8:
					num3++;
					num2 = -187993132;
					continue;
				case 2:
				{
					int num4;
					if (P_0[num3] == null)
					{
						num2 = -187993121;
						num4 = num2;
					}
					else
					{
						num2 = -187993130;
						num4 = num2;
					}
					continue;
				}
				case 1:
					if (P_0[num3].inputManagerId == num)
					{
						flag = true;
						num2 = -187993135;
						continue;
					}
					goto case 8;
				case 3:
				{
					int num5;
					if (num3 < count)
					{
						num2 = -187993131;
						num5 = num2;
					}
					else
					{
						num2 = -187993134;
						num5 = num2;
					}
					continue;
				}
				case 5:
					if (!flag)
					{
						return num;
					}
					num++;
					num2 = -187993136;
					continue;
				}
				break;
			}
		}
	}

	private bool QHMDmJGdAwPrsYvhnfrFmKuYnKq(List<pkFwwXNgPsUAHNkXgqodKLsnqBS> P_0, int P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num >= P_0.Count)
			{
				num2 = -1527743468;
				num3 = num2;
			}
			else
			{
				num2 = -1527743467;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ -1527743468)
				{
				case 2:
					num2 = -1527743467;
					continue;
				case 1:
					if (P_0[num].rewiredId == P_1)
					{
						return true;
					}
					num++;
					num2 = -1527743465;
					continue;
				case 3:
					break;
				default:
					return false;
				}
				break;
			}
		}
	}

	private void rXDbrbtyNWDCpRVSolUyjKvqIhp(int P_0, List<pkFwwXNgPsUAHNkXgqodKLsnqBS> P_1, int P_2, List<pkFwwXNgPsUAHNkXgqodKLsnqBS> P_3, gqVOweREYXhIKoQGEiYRrBKrDpW.mqBBYDcGaCgWXlcIkYaLgKgiXqK P_4)
	{
		int num = ((P_4 != gqVOweREYXhIKoQGEiYRrBKrDpW.mqBBYDcGaCgWXlcIkYaLgKgiXqK.OhRlOZGftuFdhsJLJdBYcXflSzkM) ? 1 : 2);
		int num3 = default(int);
		int num6 = default(int);
		pkFwwXNgPsUAHNkXgqodKLsnqBS pkFwwXNgPsUAHNkXgqodKLsnqBS2 = default(pkFwwXNgPsUAHNkXgqodKLsnqBS);
		pkFwwXNgPsUAHNkXgqodKLsnqBS pkFwwXNgPsUAHNkXgqodKLsnqBS3 = default(pkFwwXNgPsUAHNkXgqodKLsnqBS);
		while (true)
		{
			int num2 = 1555989530;
			while (true)
			{
				switch (num2 ^ 0x5CBE8419)
				{
				case 0:
					break;
				case 3:
					num3 = 0;
					num2 = 1555989533;
					continue;
				case 7:
				{
					int num7;
					if (num6 >= P_2)
					{
						num2 = 1555989528;
						num7 = num2;
					}
					else
					{
						num2 = 1555989520;
						num7 = num2;
					}
					continue;
				}
				case 1:
					num3++;
					num2 = 1555989533;
					continue;
				case 8:
					num6++;
					num2 = 1555989534;
					continue;
				case 2:
				{
					int num5;
					if (pkFwwXNgPsUAHNkXgqodKLsnqBS2.inputManagerId < 0)
					{
						num2 = 1555989535;
						num5 = num2;
					}
					else
					{
						num2 = 1555989528;
						num5 = num2;
					}
					continue;
				}
				case 9:
					pkFwwXNgPsUAHNkXgqodKLsnqBS3 = P_3[num6];
					num2 = 1555989532;
					continue;
				case 6:
					num6 = 0;
					num2 = 1555989534;
					continue;
				case 5:
					if (pkFwwXNgPsUAHNkXgqodKLsnqBS3 != null && !QHMDmJGdAwPrsYvhnfrFmKuYnKq(P_1, pkFwwXNgPsUAHNkXgqodKLsnqBS3.rewiredId) && pkFwwXNgPsUAHNkXgqodKLsnqBS2.texDHprRVSCDIhdEcHxFsscbHjUA(pkFwwXNgPsUAHNkXgqodKLsnqBS3) >= num)
					{
						pkFwwXNgPsUAHNkXgqodKLsnqBS2.TCWWrbhTnTgbtRDgCDABRkmhLPq(pkFwwXNgPsUAHNkXgqodKLsnqBS3);
						cBQhEyiNFbRkGCtCdGNTEMPiFbh.CzcBIezjgBkIUujMOARHJgPbWVOP(pkFwwXNgPsUAHNkXgqodKLsnqBS2);
						num2 = 1555989521;
						continue;
					}
					goto case 8;
				case 10:
				{
					pkFwwXNgPsUAHNkXgqodKLsnqBS2 = P_1[num3];
					int num4;
					if (pkFwwXNgPsUAHNkXgqodKLsnqBS2 == null)
					{
						num2 = 1555989528;
						num4 = num2;
					}
					else
					{
						num2 = 1555989531;
						num4 = num2;
					}
					continue;
				}
				default:
					if (num3 >= P_0)
					{
						return;
					}
					goto case 10;
				}
				break;
			}
		}
	}

	private void xtNfNMKFmfYIygncVYHsbFvnNoe(int P_0, List<pkFwwXNgPsUAHNkXgqodKLsnqBS> P_1, gqVOweREYXhIKoQGEiYRrBKrDpW.mqBBYDcGaCgWXlcIkYaLgKgiXqK P_2)
	{
		int num = 0;
		pkFwwXNgPsUAHNkXgqodKLsnqBS pkFwwXNgPsUAHNkXgqodKLsnqBS2 = default(pkFwwXNgPsUAHNkXgqodKLsnqBS);
		gqVOweREYXhIKoQGEiYRrBKrDpW.NbZpnZLMgvqCdkFFacrnbyoACafE nbZpnZLMgvqCdkFFacrnbyoACafE = default(gqVOweREYXhIKoQGEiYRrBKrDpW.NbZpnZLMgvqCdkFFacrnbyoACafE);
		int num3 = default(int);
		while (true)
		{
			int num2 = -376745468;
			while (true)
			{
				switch (num2 ^ -376745470)
				{
				case 7:
					break;
				case 3:
					if (pkFwwXNgPsUAHNkXgqodKLsnqBS2 != null && pkFwwXNgPsUAHNkXgqodKLsnqBS2.inputManagerId < 0)
					{
						nbZpnZLMgvqCdkFFacrnbyoACafE = cBQhEyiNFbRkGCtCdGNTEMPiFbh.lYJFZOeYSDYSWqqagvNTnOjxepl(pkFwwXNgPsUAHNkXgqodKLsnqBS2, P_2);
						if (nbZpnZLMgvqCdkFFacrnbyoACafE != null && !QHMDmJGdAwPrsYvhnfrFmKuYnKq(P_1, nbZpnZLMgvqCdkFFacrnbyoACafE.lJGmoPjWlZhCnfYmPrnrnNrpiFd))
						{
							num3 = nbZpnZLMgvqCdkFFacrnbyoACafE.hkuClqGgyrjaNFrDJJuCSthMWeZ;
							if (num3 >= 0)
							{
								int num4;
								if (WFsHpGVScPZlQaWKivTImrGOHRY(P_1, num3))
								{
									num2 = -376745469;
									num4 = num2;
								}
								else
								{
									num2 = -376745466;
									num4 = num2;
								}
								continue;
							}
						}
					}
					goto case 5;
				case 4:
					num3 = (nbZpnZLMgvqCdkFFacrnbyoACafE.hkuClqGgyrjaNFrDJJuCSthMWeZ = IojKdiCykxLgoivdxmqNHsMNBtN(P_1));
					num2 = -376745469;
					continue;
				case 5:
					num++;
					num2 = -376745472;
					continue;
				case 0:
					pkFwwXNgPsUAHNkXgqodKLsnqBS2 = P_1[num];
					num2 = -376745471;
					continue;
				case 1:
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.inputManagerId = num3;
					pkFwwXNgPsUAHNkXgqodKLsnqBS2.rewiredId = nbZpnZLMgvqCdkFFacrnbyoACafE.lJGmoPjWlZhCnfYmPrnrnNrpiFd;
					cBQhEyiNFbRkGCtCdGNTEMPiFbh.CzcBIezjgBkIUujMOARHJgPbWVOP(pkFwwXNgPsUAHNkXgqodKLsnqBS2);
					num2 = -376745465;
					continue;
				case 6:
					num2 = -376745472;
					continue;
				default:
					if (num >= P_0)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
		}
	}

	private void lMlcWXDhUZyoYToHgCauFZahHGiP()
	{
		IList<CjjRDclXuvjouyeLLeBBHCfpqqbM> list = esEBRpPnUXWKXaqSRtgPrIbfntV();
		pBKGiqCzbgfPGMFhRdFSwUDshjx(list);
		while (true)
		{
			int num = -537799675;
			while (true)
			{
				switch (num ^ -537799673)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					goto IL_002c;
				case 1:
					return;
				}
				break;
				IL_002c:
				oCfgXkGkSgDkbBQjCfrbIAyBZc = false;
				num = -537799674;
			}
		}
	}

	private bool SeXECUiByzFeJnRsasbrYvFSefu(IList<CjjRDclXuvjouyeLLeBBHCfpqqbM> P_0)
	{
		int count = P_0.Count;
		int num = 0;
		int num3 = default(int);
		int count2 = default(int);
		while (true)
		{
			int num2 = 1373380749;
			while (true)
			{
				switch (num2 ^ 0x51DC208F)
				{
				case 4:
					break;
				case 2:
					num2 = 1373380745;
					continue;
				case 3:
					num3 = 0;
					num2 = 1373380751;
					continue;
				case 7:
					count2 = jkFiqNnyAtbymFOLlvWZRfYeLku.Count;
					num2 = 1373380748;
					continue;
				case 1:
					if (P_0[num] != null && !XysGpDHUfLsspTnvfqAzwWUnziHU(P_0[num].InstanceGuid))
					{
						return true;
					}
					num++;
					num2 = 1373380745;
					continue;
				case 5:
					if (!wmiMqaEfTvxCXTdAIikBWpiFekg(P_0, jkFiqNnyAtbymFOLlvWZRfYeLku[num3].PXqNZrJMXSojPxhffbCdeIGJhWcf))
					{
						return true;
					}
					goto IL_00ae;
				case 8:
					if (jkFiqNnyAtbymFOLlvWZRfYeLku[num3] != null)
					{
						num2 = 1373380746;
						continue;
					}
					goto IL_00ae;
				case 6:
				{
					int num4;
					if (num < count)
					{
						num2 = 1373380750;
						num4 = num2;
					}
					else
					{
						num2 = 1373380744;
						num4 = num2;
					}
					continue;
				}
				default:
					{
						if (num3 >= count2)
						{
							return false;
						}
						goto case 8;
					}
					IL_00ae:
					num3++;
					num2 = 1373380751;
					continue;
				}
				break;
			}
		}
	}

	private bool XysGpDHUfLsspTnvfqAzwWUnziHU(Guid P_0)
	{
		int count = jkFiqNnyAtbymFOLlvWZRfYeLku.Count;
		int num2 = default(int);
		while (true)
		{
			int num = -1363542004;
			while (true)
			{
				switch (num ^ -1363542003)
				{
				case 0:
					break;
				case 3:
				{
					int num3;
					if (num2 >= count)
					{
						num = -1363542001;
						num3 = num;
					}
					else
					{
						num = -1363542007;
						num3 = num;
					}
					continue;
				}
				case 4:
					if (jkFiqNnyAtbymFOLlvWZRfYeLku[num2] != null && jkFiqNnyAtbymFOLlvWZRfYeLku[num2].PXqNZrJMXSojPxhffbCdeIGJhWcf == P_0)
					{
						return true;
					}
					num2++;
					num = -1363542002;
					continue;
				case 1:
					num2 = 0;
					num = -1363542002;
					continue;
				default:
					return false;
				}
				break;
			}
		}
	}

	private bool wmiMqaEfTvxCXTdAIikBWpiFekg(IList<CjjRDclXuvjouyeLLeBBHCfpqqbM> P_0, Guid P_1)
	{
		int count = P_0.Count;
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < count)
			{
				num2 = 1431366502;
				num3 = num2;
			}
			else
			{
				num2 = 1431366503;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x5550EB67)
				{
				case 2:
					num2 = 1431366502;
					continue;
				case 1:
					if (P_0[num] != null && P_0[num].InstanceGuid == P_1)
					{
						return true;
					}
					num++;
					num2 = 1431366500;
					continue;
				case 3:
					break;
				default:
					return false;
				}
				break;
			}
		}
	}

	private void oQChKjbOquuMrWKdTwrmVgDaXkc(List<pkFwwXNgPsUAHNkXgqodKLsnqBS> P_0, List<pkFwwXNgPsUAHNkXgqodKLsnqBS> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num3 = default(int);
		int num4 = default(int);
		pkFwwXNgPsUAHNkXgqodKLsnqBS pkFwwXNgPsUAHNkXgqodKLsnqBS2 = default(pkFwwXNgPsUAHNkXgqodKLsnqBS);
		int num5 = default(int);
		int num6 = default(int);
		bool flag = default(bool);
		pkFwwXNgPsUAHNkXgqodKLsnqBS pkFwwXNgPsUAHNkXgqodKLsnqBS3 = default(pkFwwXNgPsUAHNkXgqodKLsnqBS);
		while (true)
		{
			IL_0133:
			int num;
			if (P_0 != null)
			{
				num = P_0.Count;
				goto IL_008c;
			}
			int num2 = 475720544;
			goto IL_000c;
			IL_008c:
			num3 = num;
			num4 = ((P_1 != null) ? P_1.Count : 0);
			num2 = 475720554;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num2 ^ 0x1C5AEB67)
				{
				case 10:
					num2 = 475720545;
					continue;
				case 0:
				{
					pkFwwXNgPsUAHNkXgqodKLsnqBS2 = P_0[num5];
					int num7;
					if (pkFwwXNgPsUAHNkXgqodKLsnqBS2 != null)
					{
						num2 = 475720556;
						num7 = num2;
					}
					else
					{
						num2 = 475720555;
						num7 = num2;
					}
					continue;
				}
				case 12:
					num5++;
					num2 = 475720550;
					continue;
				case 7:
					break;
				case 13:
					num5 = 0;
					num2 = 475720546;
					continue;
				case 8:
					num6++;
					num2 = 475720553;
					continue;
				case 5:
					num2 = 475720550;
					continue;
				case 9:
					goto IL_00ca;
				case 2:
					flag = true;
					num2 = 475720552;
					continue;
				case 15:
					if (!flag)
					{
						OfeHsDDvEoLmeubGkgNtdbFKDqss(P_0[num5], P_2);
						num2 = 475720555;
						continue;
					}
					goto case 12;
				case 3:
					goto IL_010b;
				case 6:
					goto IL_0133;
				case 4:
					pkFwwXNgPsUAHNkXgqodKLsnqBS3 = P_1[num6];
					num2 = 475720558;
					continue;
				case 14:
					goto IL_0157;
				case 11:
					flag = false;
					if (P_1 != null)
					{
						num6 = 0;
						num2 = 475720553;
						continue;
					}
					goto case 15;
				default:
					if (num5 >= num3)
					{
						return;
					}
					goto case 0;
				}
				break;
				IL_0157:
				int num8;
				if (num6 >= num4)
				{
					num2 = 475720552;
					num8 = num2;
				}
				else
				{
					num2 = 475720547;
					num8 = num2;
				}
				continue;
				IL_010b:
				int num9;
				if (pkFwwXNgPsUAHNkXgqodKLsnqBS2.PXqNZrJMXSojPxhffbCdeIGJhWcf == pkFwwXNgPsUAHNkXgqodKLsnqBS3.PXqNZrJMXSojPxhffbCdeIGJhWcf)
				{
					num2 = 475720549;
					num9 = num2;
				}
				else
				{
					num2 = 475720559;
					num9 = num2;
				}
				continue;
				IL_00ca:
				int num10;
				if (pkFwwXNgPsUAHNkXgqodKLsnqBS3 == null)
				{
					num2 = 475720559;
					num10 = num2;
				}
				else
				{
					num2 = 475720548;
					num10 = num2;
				}
			}
			num = 0;
			goto IL_008c;
		}
	}

	private void OfeHsDDvEoLmeubGkgNtdbFKDqss(pkFwwXNgPsUAHNkXgqodKLsnqBS P_0, bool P_1)
	{
		if (P_1)
		{
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0.ToBridgedController());
			}
			return;
		}
		while (true)
		{
			int num;
			int num2;
			if (_DeviceDisconnectedEvent == null)
			{
				num = -694521;
				num2 = num;
			}
			else
			{
				num = -694523;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ -694523)
				{
				case 3:
					num = -694524;
					continue;
				default:
					return;
				case 1:
					break;
				case 0:
					_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
					num = -694521;
					continue;
				case 2:
					return;
				}
				break;
			}
		}
	}

	private void wubQuhYteLdprRmhoURXDsKQAnd()
	{
		if (GFOBjFaStuGtqdhXChMRrxXGhaGJ)
		{
			while (true)
			{
				int num = 29907149;
				while (true)
				{
					switch (num ^ 0x1C858CF)
					{
					case 0:
						break;
					case 2:
						oCfgXkGkSgDkbBQjCfrbIAyBZc = true;
						num = 29907150;
						continue;
					default:
						goto end_IL_0008;
					}
					break;
				}
				continue;
				end_IL_0008:
				break;
			}
		}
		SystemDeviceConnected();
	}
}
