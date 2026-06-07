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

internal class DGeBQlGPLqneYoaqQWDWeIPFUOuA : PlatformInputManager
{
	private class YhAVGDWXRPElABcAwbGZPlHyAsm : IInputManagerJoystickPublic, IInputManagerJoystick
	{
		private int TcKoYfigmhWFfimOKaOKeTOPnAQ;

		private int QovxBPKLdqHelKEcdGLoDhrEJtsP;

		public Guid ReLSneGtMGimyQaICDlebjstllEH;

		public string NDTJquOSkHIWqLsRFIYsSKJflNR;

		public jubkEfPWovmVDOzYftHZlVlzvfw HrKwtmtRDFnaeZJljhCzhLkJIIeA;

		public XqPQWVQCzoiUVqNxOwUOrPFfeBF KOwcVsrLduAvDUBHbanJeoGoONt;

		public string TlZBIVFqZBqEoMngnZzoQImlnStY;

		public string MbrQwRnmlvxaToztrCqZEslEYAm;

		public int dUFmmEnRQtqCUuTnapnLPxMpqTR;

		public int NdbvKbBBJrSYqhcLkswavvMBjSd;

		public Guid uNwIAadyRUHwiZgeVCXdRHCFIBn;

		public PidVid PwAPPePhJPAsncuOIyMlQuCrJGKc;

		public Guid UdzmHEFosksAvkflFwdfeLstDZW;

		public int gGEWoFRvVVAnXKYZvrqbJLFBTeE;

		public int cIiBqNbLwRxGzElhlgDShdHLhGAg;

		public int rQtiVxCoBsJBsxYwQMRSjbeCdSR;

		public int bfRBSyiMEnqYkaJuaERXkSDgrMIl;

		public int iseCLQKKKNFGEzGoUHhRwvJfUWj;

		public int RUsxtZLmGlDUbqVLggiivRxcpCE;

		public bool PpQCTIiUxNTFQkUcLaiHwscvqivF;

		public bool wweKDPecOEKQRjeLwREKUOeenHA;

		public int dFeMnzRTSNcMYNGuAWZUeFGTLNj;

		private float[] TEOYPaJNdnEWbgWRoihqYehIhMK;

		private bool[] pcgUSJiXRsTNqMrGSyukNhNuJeO;

		private HardwareJoystickMap_InputManager RCNejcvnZtMAmgendVbiwgNYmdD;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> brkuSOIQTXGziCshBbHdBPqhLfY;

		private bool sEVjABKhsyjSSpjYMrGkQbufDdVJ;

		private bool BvBiBtBhorGlOOqcvDhVgnidONSn;

		[CompilerGenerated]
		private Controller.Extension CzWfLFCZapuholGnObdLEsHulZf;

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return TcKoYfigmhWFfimOKaOKeTOPnAQ;
			}
			set
			{
				TcKoYfigmhWFfimOKaOKeTOPnAQ = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return QovxBPKLdqHelKEcdGLoDhrEJtsP;
			}
			set
			{
				QovxBPKLdqHelKEcdGLoDhrEJtsP = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				return NDTJquOSkHIWqLsRFIYsSKJflNR;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (QovxBPKLdqHelKEcdGLoDhrEJtsP < 0)
				{
					return null;
				}
				return QovxBPKLdqHelKEcdGLoDhrEJtsP;
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
				return uNwIAadyRUHwiZgeVCXdRHCFIBn;
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
				return CzWfLFCZapuholGnObdLEsHulZf;
			}
			[CompilerGenerated]
			set
			{
				CzWfLFCZapuholGnObdLEsHulZf = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			HrKwtmtRDFnaeZJljhCzhLkJIIeA.SetVibration(motorIndex, amount, false);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		public YhAVGDWXRPElABcAwbGZPlHyAsm(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			brkuSOIQTXGziCshBbHdBPqhLfY = getHardwareJoystickMap_InputManager;
			QovxBPKLdqHelKEcdGLoDhrEJtsP = -1;
			TcKoYfigmhWFfimOKaOKeTOPnAQ = -1;
		}

		public void sbcTSexDWKGUOKrMGnEajLgRvts()
		{
			UdzmHEFosksAvkflFwdfeLstDZW = MiscTools.CreateGuidHashSHA1(TlZBIVFqZBqEoMngnZzoQImlnStY + PwAPPePhJPAsncuOIyMlQuCrJGKc.ToProductGuid());
			while (true)
			{
				int num = 804169293;
				while (true)
				{
					switch (num ^ 0x2FEEA649)
					{
					case 2:
						break;
					case 5:
						NDTJquOSkHIWqLsRFIYsSKJflNR = RCNejcvnZtMAmgendVbiwgNYmdD.controllerName;
						sEVjABKhsyjSSpjYMrGkQbufDdVJ = ((ReLSneGtMGimyQaICDlebjstllEH == Guid.Empty) ? true : false);
						num = 804169290;
						continue;
					case 3:
						TEOYPaJNdnEWbgWRoihqYehIhMK = new float[cIiBqNbLwRxGzElhlgDShdHLhGAg];
						num = 804169288;
						continue;
					case 4:
						cIiBqNbLwRxGzElhlgDShdHLhGAg = bfRBSyiMEnqYkaJuaERXkSDgrMIl;
						rQtiVxCoBsJBsxYwQMRSjbeCdSR = iseCLQKKKNFGEzGoUHhRwvJfUWj + RUsxtZLmGlDUbqVLggiivRxcpCE * 8;
						num = 804169289;
						continue;
					case 0:
						TiLfIVyvvCkOyWkDMxfDMSbgDnI();
						ReLSneGtMGimyQaICDlebjstllEH = RCNejcvnZtMAmgendVbiwgNYmdD.hardwareMapIdentifier.guid;
						num = 804169292;
						continue;
					default:
						pcgUSJiXRsTNqMrGSyukNhNuJeO = new bool[rQtiVxCoBsJBsxYwQMRSjbeCdSR];
						Update();
						return;
					}
					break;
				}
			}
		}

		public void wdORaALJIVHeMdYgqVfHekvpUfr(YhAVGDWXRPElABcAwbGZPlHyAsm P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				QovxBPKLdqHelKEcdGLoDhrEJtsP = P_0.QovxBPKLdqHelKEcdGLoDhrEJtsP;
				TcKoYfigmhWFfimOKaOKeTOPnAQ = P_0.TcKoYfigmhWFfimOKaOKeTOPnAQ;
				int num = 645112322;
				while (true)
				{
					switch (num ^ 0x2673A205)
					{
					case 3:
						num = 645112327;
						continue;
					case 2:
						break;
					case 7:
						num3 = 0;
						num = 645112324;
						continue;
					case 0:
						pcgUSJiXRsTNqMrGSyukNhNuJeO[num3] = P_0.pcgUSJiXRsTNqMrGSyukNhNuJeO[num3];
						num3++;
						num = 645112324;
						continue;
					case 5:
						TEOYPaJNdnEWbgWRoihqYehIhMK[num2] = P_0.TEOYPaJNdnEWbgWRoihqYehIhMK[num2];
						num = 645112321;
						continue;
					case 4:
						num2++;
						num = 645112323;
						continue;
					case 1:
						if (num3 >= MathTools.Min(pcgUSJiXRsTNqMrGSyukNhNuJeO.Length, P_0.pcgUSJiXRsTNqMrGSyukNhNuJeO.Length))
						{
							num2 = 0;
							num = 645112323;
							continue;
						}
						goto case 0;
					default:
						if (num2 >= MathTools.Min(TEOYPaJNdnEWbgWRoihqYehIhMK.Length, P_0.TEOYPaJNdnEWbgWRoihqYehIhMK.Length))
						{
							BvBiBtBhorGlOOqcvDhVgnidONSn = P_0.BvBiBtBhorGlOOqcvDhVgnidONSn;
							return;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			ACWFShdsqMXYShMhIOVlhqSySfj();
			bWqXMuWKIQJCfsxGeWCQkichWXy();
			if (!BvBiBtBhorGlOOqcvDhVgnidONSn && HrKwtmtRDFnaeZJljhCzhLkJIIeA.HasEverReceivedInput)
			{
				BvBiBtBhorGlOOqcvDhVgnidONSn = true;
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (cIiBqNbLwRxGzElhlgDShdHLhGAg == dataUpdater.axisCount)
			{
				int num3 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = -583961543;
					while (true)
					{
						switch (num ^ -583961542)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							if (num3 >= rQtiVxCoBsJBsxYwQMRSjbeCdSR)
							{
								if (BvBiBtBhorGlOOqcvDhVgnidONSn && !dataUpdater.hasReceivedInput)
								{
									dataUpdater.hasReceivedInput = true;
									num = -583961550;
									continue;
								}
								return;
							}
							goto case 7;
						case 2:
							goto end_IL_000e;
						case 6:
							dataUpdater.axisValues[num2] = TEOYPaJNdnEWbgWRoihqYehIhMK[num2];
							num2++;
							num = -583961549;
							continue;
						case 3:
							goto IL_00a8;
						case 7:
							dataUpdater.buttonValues[num3] = pcgUSJiXRsTNqMrGSyukNhNuJeO[num3];
							num = -583961537;
							continue;
						case 5:
							num3++;
							num = -583961541;
							continue;
						case 4:
							num2 = 0;
							num = -583961549;
							continue;
						case 9:
							if (num2 >= cIiBqNbLwRxGzElhlgDShdHLhGAg)
							{
								num3 = 0;
								num = -583961541;
								continue;
							}
							goto case 6;
						case 8:
							return;
						}
						break;
						IL_00a8:
						int num4;
						if (rQtiVxCoBsJBsxYwQMRSjbeCdSR != dataUpdater.buttonCount)
						{
							num = -583961544;
							num4 = num;
						}
						else
						{
							num = -583961538;
							num4 = num;
						}
					}
					continue;
					end_IL_000e:
					break;
				}
			}
			throw new Exception("This controller signature does not match the data object!");
		}

		public int CGvNMgTtJKByfBoLCudPLkyvgkV(YhAVGDWXRPElABcAwbGZPlHyAsm P_0)
		{
			if (P_0.TcKoYfigmhWFfimOKaOKeTOPnAQ == TcKoYfigmhWFfimOKaOKeTOPnAQ)
			{
				return 2;
			}
			if (bfRBSyiMEnqYkaJuaERXkSDgrMIl != P_0.bfRBSyiMEnqYkaJuaERXkSDgrMIl)
			{
				return 0;
			}
			if (iseCLQKKKNFGEzGoUHhRwvJfUWj != P_0.iseCLQKKKNFGEzGoUHhRwvJfUWj)
			{
				return 0;
			}
			if (RUsxtZLmGlDUbqVLggiivRxcpCE != P_0.RUsxtZLmGlDUbqVLggiivRxcpCE)
			{
				return 0;
			}
			if (P_0.uNwIAadyRUHwiZgeVCXdRHCFIBn == uNwIAadyRUHwiZgeVCXdRHCFIBn)
			{
				return 2;
			}
			if (P_0.UdzmHEFosksAvkflFwdfeLstDZW == UdzmHEFosksAvkflFwdfeLstDZW)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo JBMvgOBJziXYPUQkaqihlBPPMXw()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			while (true)
			{
				int num = -1325426745;
				while (true)
				{
					switch (num ^ -1325426746)
					{
					case 2:
						break;
					case 1:
						goto IL_0024;
					default:
						return bridgedControllerHWInfo;
					}
					break;
					IL_0024:
					azaIOTDxGZMNUjlkOgiJDaxzXhfj(bridgedControllerHWInfo);
					num = -1325426746;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			azaIOTDxGZMNUjlkOgiJDaxzXhfj(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(TcKoYfigmhWFfimOKaOKeTOPnAQ);
		}

		private void ACWFShdsqMXYShMhIOVlhqSySfj()
		{
			if (cIiBqNbLwRxGzElhlgDShdHLhGAg <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Axis[] axes_orig = default(HardwareJoystickMap.Platform_SDL2_Base.Axis[]);
			int num2 = default(int);
			while (true)
			{
				InputPlatform platform = RCNejcvnZtMAmgendVbiwgNYmdD.map.platform;
				int num = 1918187052;
				while (true)
				{
					switch (num ^ 0x7255362D)
					{
					case 3:
						num = 1918187055;
						continue;
					default:
						return;
					case 6:
						FEWoMHAQidYgObBFKwqnUlfwBruf(axes_orig[num2], num2);
						num2++;
						num = 1918187048;
						continue;
					case 1:
						if (platform == InputPlatform.xzaOPbUxziNeuflqekRIWgtGJg)
						{
							HardwareJoystickMap.Platform_SDL2_Base platform_SDL2_Base = (HardwareJoystickMap.Platform_SDL2_Base)RCNejcvnZtMAmgendVbiwgNYmdD.map;
							axes_orig = platform_SDL2_Base.Axes_orig;
							if (axes_orig == null)
							{
								return;
							}
							goto case 0;
						}
						return;
					case 0:
						num2 = 0;
						num = 1918187048;
						continue;
					case 2:
						break;
					case 5:
					{
						int num3;
						if (num2 >= axes_orig.Length)
						{
							num = 1918187049;
							num3 = num;
						}
						else
						{
							num = 1918187051;
							num3 = num;
						}
						continue;
					}
					case 4:
						return;
					}
					break;
				}
			}
		}

		private void bWqXMuWKIQJCfsxGeWCQkichWXy()
		{
			if (rQtiVxCoBsJBsxYwQMRSjbeCdSR <= 0)
			{
				goto IL_0009;
			}
			goto IL_0064;
			IL_0009:
			int num = -1276139295;
			goto IL_000e;
			IL_000e:
			HardwareJoystickMap.Platform_SDL2_Base.Button[] buttons_orig = default(HardwareJoystickMap.Platform_SDL2_Base.Button[]);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1276139293)
				{
				case 6:
					break;
				case 0:
					ZuXsYyLYhMBnnAMxzOyPExeTZkc(buttons_orig[num2], num2);
					num = -1276139296;
					continue;
				case 3:
					num2++;
					num = -1276139289;
					continue;
				case 2:
					return;
				case 1:
					goto IL_005b;
				case 5:
					goto IL_0064;
				default:
					if (num2 >= buttons_orig.Length)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0009;
			IL_005b:
			num2 = 0;
			num = -1276139289;
			goto IL_000e;
			IL_0064:
			HardwareJoystickMap.Platform_SDL2_Base platform_SDL2_Base = (HardwareJoystickMap.Platform_SDL2_Base)RCNejcvnZtMAmgendVbiwgNYmdD.map;
			buttons_orig = platform_SDL2_Base.Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			goto IL_005b;
		}

		private void FEWoMHAQidYgObBFKwqnUlfwBruf(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0, int P_1)
		{
			if (P_1 >= cIiBqNbLwRxGzElhlgDShdHLhGAg)
			{
				goto IL_0009;
			}
			goto IL_003d;
			IL_0009:
			int num = 1291978899;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x4D020891)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			case 3:
				goto IL_003d;
			case 1:
				return;
			}
			goto IL_0009;
			IL_003d:
			TEOYPaJNdnEWbgWRoihqYehIhMK[P_1] = MZBONfLuZbixRkBmJqUhwMoksCq(P_0);
			num = 1291978896;
			goto IL_000e;
		}

		private void ZuXsYyLYhMBnnAMxzOyPExeTZkc(HardwareJoystickMap.Platform_SDL2_Base.Button P_0, int P_1)
		{
			if (P_1 >= rQtiVxCoBsJBsxYwQMRSjbeCdSR)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			pcgUSJiXRsTNqMrGSyukNhNuJeO[P_1] = uzIVkYjEcCOqJgyQjMKkDXWAHmv(P_0);
		}

		private float MZBONfLuZbixRkBmJqUhwMoksCq(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0)
		{
			int sourceAxis = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				sourceAxis = P_0.sourceAxis;
				goto IL_0013;
			}
			int sourceHat = default(int);
			int num;
			if (P_0.sourceType != HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.sourceType != HardwareElementSourceTypeWithHat.Hat)
				{
					return 0f;
				}
				sourceHat = P_0.sourceHat;
				num = -1334898083;
			}
			else
			{
				num = -1334898089;
			}
			goto IL_0018;
			IL_0013:
			num = -1334898102;
			goto IL_0018;
			IL_0018:
			float result = default(float);
			float num2 = default(float);
			int sourceButton = default(int);
			int hatValue = default(int);
			while (true)
			{
				switch (num ^ -1334898088)
				{
				case 17:
					break;
				case 9:
					result = 1f;
					num = -1334898084;
					continue;
				case 13:
					return 0f;
				case 0:
					if (P_0.sourceHatRange == AxisRange.Positive)
					{
						if (num2 < 0f)
						{
							num = -1334898086;
							continue;
						}
					}
					else if (num2 > 0f)
					{
						return 0f;
					}
					goto IL_01e8;
				case 1:
					return 0f;
				case 3:
				{
					int num5;
					if (sourceButton >= 0)
					{
						num = -1334898081;
						num5 = num;
					}
					else
					{
						num = -1334898091;
						num5 = num;
					}
					continue;
				}
				case 5:
				{
					int num3;
					if (sourceHat >= 0)
					{
						num = -1334898092;
						num3 = num;
					}
					else
					{
						num = -1334898082;
						num3 = num;
					}
					continue;
				}
				case 6:
					return 0f;
				case 7:
					if (sourceButton < iseCLQKKKNFGEzGoUHhRwvJfUWj)
					{
						if (sourceButton < 256)
						{
							if (!HrKwtmtRDFnaeZJljhCzhLkJIIeA.GetButtonValue(sourceButton))
							{
								return 0f;
							}
							int num4;
							if (P_0.buttonAxisContribution == Pole.Positive)
							{
								num = -1334898095;
								num4 = num;
							}
							else
							{
								num = -1334898104;
								num4 = num;
							}
						}
						else
						{
							num = -1334898091;
						}
						continue;
					}
					goto case 13;
				case 2:
					return 0f;
				case 15:
					sourceButton = P_0.sourceButton;
					num = -1334898085;
					continue;
				case 11:
					return 0f;
				case 12:
					if (sourceHat < RUsxtZLmGlDUbqVLggiivRxcpCE)
					{
						if (sourceHat < 4)
						{
							hatValue = HrKwtmtRDFnaeZJljhCzhLkJIIeA.GetHatValue(sourceHat);
							num = -1334898094;
						}
						else
						{
							num = -1334898082;
						}
						continue;
					}
					goto case 6;
				case 10:
					if (hatValue >= 0)
					{
						if (P_0.sourceHatDirection == AxisDirection.Horizontal)
						{
							num2 = pINPEAUvCAyhjLjFBiRCKZgqsYY(hatValue, AxisDirection.Horizontal);
							if (P_0.sourceHatRange != AxisRange.Full)
							{
								num = -1334898088;
								continue;
							}
						}
						else
						{
							num2 = pINPEAUvCAyhjLjFBiRCKZgqsYY(hatValue, AxisDirection.Vertical);
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
									num = -1334898093;
									continue;
								}
							}
						}
						goto IL_01e8;
					}
					num = -1334898087;
					continue;
				case 4:
					return result;
				case 14:
					return 0f;
				case 18:
					if (sourceAxis >= 0 && sourceAxis < bfRBSyiMEnqYkaJuaERXkSDgrMIl)
					{
						if (sourceAxis < 56)
						{
							return HrKwtmtRDFnaeZJljhCzhLkJIIeA.GetAxisValue(sourceAxis);
						}
						num = -1334898090;
						continue;
					}
					goto case 14;
				case 16:
					result = -1f;
					num = -1334898084;
					continue;
				default:
					{
						return num2;
					}
					IL_01e8:
					if (P_0.invert)
					{
						num2 *= -1f;
						num = -1334898096;
						continue;
					}
					goto default;
				}
				break;
			}
			goto IL_0013;
		}

		private bool uzIVkYjEcCOqJgyQjMKkDXWAHmv(HardwareJoystickMap.Platform_SDL2_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				goto IL_000b;
			}
			int num;
			int sourceHat = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				num = -901240486;
			}
			else
			{
				if (P_0.sourceType != HardwareElementSourceTypeWithHat.Hat)
				{
					goto IL_03dd;
				}
				sourceHat = P_0.sourceHat;
				num = -901240496;
			}
			goto IL_0010;
			IL_000b:
			num = -901240484;
			goto IL_0010;
			IL_0010:
			int sourceButton = default(int);
			int num2 = default(int);
			HatDirection sourceHatDirection = default(HatDirection);
			int sourceAxis = default(int);
			bool flag = default(bool);
			int num7 = default(int);
			float axisValue = default(float);
			while (true)
			{
				switch (num ^ -901240489)
				{
				case 18:
					break;
				case 23:
					return false;
				case 16:
					return false;
				case 10:
					return true;
				case 20:
					goto IL_00c8;
				case 7:
					goto IL_00e7;
				case 19:
					return false;
				case 9:
					goto IL_0114;
				case 6:
					goto IL_012f;
				case 1:
					goto IL_014d;
				case 15:
					if (sourceButton < iseCLQKKKNFGEzGoUHhRwvJfUWj)
					{
						goto IL_0169;
					}
					goto case 12;
				case 11:
					if (P_0.ignoreIfButtonsActive)
					{
						num2 = 0;
						num = -901240509;
						continue;
					}
					goto IL_02cd;
				case 13:
					goto IL_0195;
				case 17:
					return false;
				case 3:
					goto IL_01d1;
				case 12:
					return false;
				case 21:
					goto IL_021a;
				case 5:
					goto IL_0249;
				case 22:
					return false;
				case 8:
					goto IL_029c;
				case 2:
					goto IL_02cd;
				case 14:
					if (sourceHat >= RUsxtZLmGlDUbqVLggiivRxcpCE)
					{
						goto case 19;
					}
					goto IL_02f3;
				default:
					goto IL_0305;
				case 4:
					goto IL_03dd;
				}
				break;
				IL_02f3:
				if (sourceHat < 4)
				{
					sourceHatDirection = P_0.sourceHatDirection;
					num = -901240481;
				}
				else
				{
					num = -901240508;
				}
				continue;
				IL_0195:
				sourceAxis = P_0.sourceAxis;
				int num3;
				if (sourceAxis > 0)
				{
					num = -901240495;
					num3 = num;
				}
				else
				{
					num = -901240506;
					num3 = num;
				}
				continue;
				IL_00e7:
				int num4;
				if (sourceHat >= 0)
				{
					num = -901240487;
					num4 = num;
				}
				else
				{
					num = -901240508;
					num4 = num;
				}
				continue;
				IL_029c:
				switch (sourceHatDirection)
				{
				default:
					num = -901240493;
					continue;
				case HatDirection.Up:
					break;
				case HatDirection.UpRight:
					return qpRlMQxQnELVcGnTGJDrFGrpeawk(HrKwtmtRDFnaeZJljhCzhLkJIIeA.GetHatValue(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return qpRlMQxQnELVcGnTGJDrFGrpeawk(HrKwtmtRDFnaeZJljhCzhLkJIIeA.GetHatValue(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return qpRlMQxQnELVcGnTGJDrFGrpeawk(HrKwtmtRDFnaeZJljhCzhLkJIIeA.GetHatValue(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return qpRlMQxQnELVcGnTGJDrFGrpeawk(HrKwtmtRDFnaeZJljhCzhLkJIIeA.GetHatValue(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return qpRlMQxQnELVcGnTGJDrFGrpeawk(HrKwtmtRDFnaeZJljhCzhLkJIIeA.GetHatValue(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return qpRlMQxQnELVcGnTGJDrFGrpeawk(HrKwtmtRDFnaeZJljhCzhLkJIIeA.GetHatValue(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return qpRlMQxQnELVcGnTGJDrFGrpeawk(HrKwtmtRDFnaeZJljhCzhLkJIIeA.GetHatValue(sourceHat), 7, P_0.sourceHatType);
				}
				goto IL_0305;
				IL_0305:
				return qpRlMQxQnELVcGnTGJDrFGrpeawk(HrKwtmtRDFnaeZJljhCzhLkJIIeA.GetHatValue(sourceHat), 0, P_0.sourceHatType);
				IL_0249:
				if (!HrKwtmtRDFnaeZJljhCzhLkJIIeA.GetButtonValue(P_0.ignoreIfButtonsActiveButtons[num2]))
				{
					num2++;
					num = -901240509;
				}
				else
				{
					num = -901240512;
				}
				continue;
				IL_00c8:
				int num5;
				if (num2 >= P_0.ignoreIfButtonsActiveButtons.Length)
				{
					num = -901240491;
					num5 = num;
				}
				else
				{
					num = -901240494;
					num5 = num;
				}
				continue;
				IL_02cd:
				if (!P_0.requireMultipleButtons)
				{
					sourceButton = P_0.sourceButton;
					int num6;
					if (sourceButton >= 0)
					{
						num = -901240488;
						num6 = num;
					}
					else
					{
						num = -901240485;
						num6 = num;
					}
				}
				else
				{
					flag = false;
					num7 = 0;
					num = -901240482;
				}
				continue;
				IL_021a:
				if (MathTools.Abs(axisValue) <= P_0.axisDeadZone)
				{
					return false;
				}
				if (P_0.sourceAxisPole != Pole.Positive)
				{
					if (axisValue > 0f)
					{
						num = -901240511;
						continue;
					}
				}
				else if (axisValue < 0f)
				{
					num = -901240505;
					continue;
				}
				return true;
				IL_0169:
				if (sourceButton >= 256)
				{
					num = -901240485;
					continue;
				}
				return HrKwtmtRDFnaeZJljhCzhLkJIIeA.GetButtonValue(sourceButton);
				IL_012f:
				int num8;
				if (sourceAxis >= bfRBSyiMEnqYkaJuaERXkSDgrMIl)
				{
					num = -901240506;
					num8 = num;
				}
				else
				{
					num = -901240490;
					num8 = num;
				}
				continue;
				IL_014d:
				if (sourceAxis >= 56)
				{
					num = -901240506;
					continue;
				}
				axisValue = HrKwtmtRDFnaeZJljhCzhLkJIIeA.GetAxisValue(sourceAxis);
				num = -901240510;
				continue;
				IL_01d1:
				if (!HrKwtmtRDFnaeZJljhCzhLkJIIeA.GetButtonValue(P_0.requiredButtons[num7]))
				{
					return false;
				}
				flag = true;
				num7++;
				num = -901240482;
				continue;
				IL_0114:
				if (num7 >= P_0.requiredButtons.Length)
				{
					if (!flag)
					{
						return false;
					}
					num = -901240483;
					continue;
				}
				goto IL_01d1;
			}
			goto IL_000b;
			IL_03dd:
			return false;
		}

		private bool qpRlMQxQnELVcGnTGJDrFGrpeawk(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (RCNejcvnZtMAmgendVbiwgNYmdD.isUnknownController)
			{
				goto IL_0013;
			}
			goto IL_007f;
			IL_0073:
			if (!InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return false;
			}
			goto IL_007f;
			IL_0013:
			int num = -1778289572;
			goto IL_0018;
			IL_0018:
			int num2 = default(int);
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num ^ -1778289575)
				{
				case 9:
					break;
				case 8:
					num = -1778289570;
					continue;
				case 1:
					goto IL_0063;
				case 5:
					goto IL_0073;
				case 3:
					num2 = 9000;
					num = -1778289570;
					continue;
				case 11:
					num3 = 31500;
					num = -1778289569;
					continue;
				case 0:
					num3 = 27000;
					num = -1778289574;
					continue;
				case 12:
					goto IL_00c0;
				case 4:
					return false;
				case 7:
					if (P_1 == 0 && P_0 > num3)
					{
						P_0 -= 36000;
						num = -1778289579;
						continue;
					}
					goto IL_00c0;
				case 6:
					num2 = 4500;
					num = -1778289583;
					continue;
				case 2:
					goto IL_0114;
				default:
					return true;
				}
				break;
				IL_0114:
				if (P_2 != HatType.EightWay || P_0 == num4)
				{
					int num5;
					if (P_2 == HatType.EightWay)
					{
						num = -1778289582;
						num5 = num;
					}
					else
					{
						num = -1778289575;
						num5 = num;
					}
				}
				else
				{
					num = -1778289571;
				}
				continue;
				IL_0063:
				if (P_0 > num4 - num2)
				{
					num = -1778289581;
					continue;
				}
				goto IL_0128;
				IL_00c0:
				if (P_0 < num4 + num2)
				{
					num = -1778289576;
					continue;
				}
				goto IL_0128;
				IL_0128:
				return false;
			}
			goto IL_0013;
			IL_007f:
			int num6 = 4500;
			num4 = num6 * P_1;
			num = -1778289573;
			goto IL_0018;
		}

		private float pINPEAUvCAyhjLjFBiRCKZgqsYY(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (P_1 == AxisDirection.Vertical)
			{
				if (P_0 <= 27000)
				{
					goto IL_0015;
				}
				goto IL_0052;
			}
			int num;
			if (P_0 > 0)
			{
				num = -1342054970;
				goto IL_001a;
			}
			goto IL_008c;
			IL_007e:
			if (P_0 < 18000)
			{
				return 1f;
			}
			goto IL_008c;
			IL_0052:
			return 1f;
			IL_001a:
			while (true)
			{
				switch (num ^ -1342054970)
				{
				case 3:
					break;
				case 5:
					goto IL_0043;
				case 1:
					goto IL_0052;
				case 6:
					return -1f;
				case 0:
					goto IL_007e;
				case 2:
					goto IL_009e;
				default:
					return -1f;
				}
				break;
				IL_009e:
				if (P_0 >= 9000)
				{
					if (P_0 < 27000)
					{
						num = -1342054973;
						continue;
					}
					goto IL_006d;
				}
				num = -1342054969;
				continue;
				IL_006d:
				return 0f;
				IL_0043:
				if (P_0 > 9000)
				{
					num = -1342054976;
					continue;
				}
				goto IL_006d;
			}
			goto IL_0015;
			IL_008c:
			if (P_0 > 18000)
			{
				num = -1342054974;
				goto IL_001a;
			}
			return 0f;
			IL_0015:
			num = -1342054972;
			goto IL_001a;
		}

		private ControlDeviceType IdKeHRNFnPwGMmUldQSizztrVyM(XqPQWVQCzoiUVqNxOwUOrPFfeBF P_0)
		{
			switch (P_0)
			{
			case XqPQWVQCzoiUVqNxOwUOrPFfeBF.sPSdDimdHdkUZBwhcqdUzIdejYne:
				return ControlDeviceType.sPSdDimdHdkUZBwhcqdUzIdejYne;
			case XqPQWVQCzoiUVqNxOwUOrPFfeBF.dNyyENhbShZpwawrFNHGUzXrCYg:
				return ControlDeviceType.dNyyENhbShZpwawrFNHGUzXrCYg;
			case XqPQWVQCzoiUVqNxOwUOrPFfeBF.tkHFoIOLgynnsbjfJgGsghWKZpu:
				return ControlDeviceType.tkHFoIOLgynnsbjfJgGsghWKZpu;
			case XqPQWVQCzoiUVqNxOwUOrPFfeBF.EuQbsbgswOBiYuQiqzeyNfABXek:
				return ControlDeviceType.EuQbsbgswOBiYuQiqzeyNfABXek;
			default:
				return ControlDeviceType.srbgNzJMznryeuABhpjzUCNZxjJP;
			}
		}

		private void TiLfIVyvvCkOyWkDMxfDMSbgDnI()
		{
			RCNejcvnZtMAmgendVbiwgNYmdD = brkuSOIQTXGziCshBbHdBPqhLfY(JBMvgOBJziXYPUQkaqihlBPPMXw());
			string text = default(string);
			while (true)
			{
				int num = 1711143534;
				while (true)
				{
					switch (num ^ 0x65FDFA6D)
					{
					case 4:
						break;
					case 3:
						if (RCNejcvnZtMAmgendVbiwgNYmdD == null)
						{
							Logger.LogError("Default hardware map not found!");
							return;
						}
						goto case 1;
					case 1:
						if (RCNejcvnZtMAmgendVbiwgNYmdD.useSystemName && !string.IsNullOrEmpty(MbrQwRnmlvxaToztrCqZEslEYAm))
						{
							text = Regex.Replace(MbrQwRnmlvxaToztrCqZEslEYAm, "\\s+", " ");
							text = text.Trim();
							int num2;
							if (string.IsNullOrEmpty(text))
							{
								num = 1711143533;
								num2 = num;
							}
							else
							{
								num = 1711143535;
								num2 = num;
							}
							continue;
						}
						goto default;
					case 2:
						RCNejcvnZtMAmgendVbiwgNYmdD.controllerName = text;
						num = 1711143533;
						continue;
					default:
						cIiBqNbLwRxGzElhlgDShdHLhGAg = RCNejcvnZtMAmgendVbiwgNYmdD.axisCount;
						rQtiVxCoBsJBsxYwQMRSjbeCdSR = RCNejcvnZtMAmgendVbiwgNYmdD.buttonCount;
						return;
					}
					break;
				}
			}
		}

		private string LbGrdiipCCDFbkyPrurfKpIAOLmu()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), HrKwtmtRDFnaeZJljhCzhLkJIIeA.InputSource, TlZBIVFqZBqEoMngnZzoQImlnStY, dUFmmEnRQtqCUuTnapnLPxMpqTR, PwAPPePhJPAsncuOIyMlQuCrJGKc.ToProductGuid()));
		}

		private void azaIOTDxGZMNUjlkOgiJDaxzXhfj(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.SDL2;
			P_0.inputSource = HrKwtmtRDFnaeZJljhCzhLkJIIeA.InputSource;
			while (true)
			{
				int num = 1914346937;
				while (true)
				{
					switch (num ^ 0x721A9DB8)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						P_0.deviceType = IdKeHRNFnPwGMmUldQSizztrVyM(KOwcVsrLduAvDUBHbanJeoGoONt);
						num = 1914346939;
						continue;
					case 4:
						P_0.hw_pidVid = PwAPPePhJPAsncuOIyMlQuCrJGKc;
						num = 1914346941;
						continue;
					case 3:
						P_0.hardwareIdentifier = LbGrdiipCCDFbkyPrurfKpIAOLmu();
						num = 1914346936;
						continue;
					case 5:
						P_0.hw_isBluetoothDevice = PpQCTIiUxNTFQkUcLaiHwscvqivF;
						P_0.hw_bluetoothDeviceName = TlZBIVFqZBqEoMngnZzoQImlnStY;
						P_0.hw_systemDeviceName = TlZBIVFqZBqEoMngnZzoQImlnStY;
						P_0.hw_supportsVibration = wweKDPecOEKQRjeLwREKUOeenHA;
						P_0.hw_isSDL2Gamepad = HrKwtmtRDFnaeZJljhCzhLkJIIeA.DeviceType == XqPQWVQCzoiUVqNxOwUOrPFfeBF.dNyyENhbShZpwawrFNHGUzXrCYg;
						P_0.hw_localVibrationMotorCount = dFeMnzRTSNcMYNGuAWZUeFGTLNj;
						num = 1914346942;
						continue;
					case 0:
						P_0.hardwareAxisCount = bfRBSyiMEnqYkaJuaERXkSDgrMIl;
						P_0.hardwareButtonCount = iseCLQKKKNFGEzGoUHhRwvJfUWj;
						P_0.hardwareHatCount = RUsxtZLmGlDUbqVLggiivRxcpCE;
						P_0.hw_productName = TlZBIVFqZBqEoMngnZzoQImlnStY;
						P_0.hw_deviceGuid = uNwIAadyRUHwiZgeVCXdRHCFIBn;
						P_0.hw_productId = dUFmmEnRQtqCUuTnapnLPxMpqTR;
						num = 1914346940;
						continue;
					case 6:
						return;
					}
					break;
				}
			}
		}

		private void azaIOTDxGZMNUjlkOgiJDaxzXhfj(BridgedController P_0)
		{
			azaIOTDxGZMNUjlkOgiJDaxzXhfj((BridgedControllerHWInfo)P_0);
			while (true)
			{
				int num = -1786796161;
				while (true)
				{
					switch (num ^ -1786796163)
					{
					case 0:
						break;
					case 2:
						goto IL_0025;
					default:
						P_0.instanceName = TlZBIVFqZBqEoMngnZzoQImlnStY;
						P_0.productName = TlZBIVFqZBqEoMngnZzoQImlnStY;
						P_0.axisCount = cIiBqNbLwRxGzElhlgDShdHLhGAg;
						P_0.buttonCount = rQtiVxCoBsJBsxYwQMRSjbeCdSR;
						P_0.unknownControllerHats = ZDSbDmtNJHNgVWgIRYJgajBbdLXF();
						P_0.controllerTypeGuid = ReLSneGtMGimyQaICDlebjstllEH;
						P_0.controllerExtension = extension;
						return;
					}
					break;
					IL_0025:
					P_0.sourceJoystick = this;
					P_0.gameHardwareMap = RCNejcvnZtMAmgendVbiwgNYmdD.ToGameHardwareControllerMap();
					num = -1786796164;
				}
			}
		}

		private void WpyTbuqHjCBPEywsoQxCzmsTIQi()
		{
			int num = 0;
			int num2 = default(int);
			while (true)
			{
				int num3;
				if (num >= rQtiVxCoBsJBsxYwQMRSjbeCdSR)
				{
					num2 = 0;
					num3 = -190509985;
					goto IL_0009;
				}
				goto IL_004b;
				IL_0009:
				while (true)
				{
					switch (num3 ^ -190509989)
					{
					case 5:
						num3 = -190509992;
						continue;
					case 0:
						num2++;
						num3 = -190509985;
						continue;
					case 1:
						break;
					case 3:
						goto IL_004b;
					case 2:
						TEOYPaJNdnEWbgWRoihqYehIhMK[num2] = 0f;
						num3 = -190509989;
						continue;
					default:
						if (num2 >= cIiBqNbLwRxGzElhlgDShdHLhGAg)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
				continue;
				IL_004b:
				pcgUSJiXRsTNqMrGSyukNhNuJeO[num] = false;
				num++;
				num3 = -190509990;
				goto IL_0009;
			}
		}

		private UnknownControllerHat[] ZDSbDmtNJHNgVWgIRYJgajBbdLXF()
		{
			if (!sEVjABKhsyjSSpjYMrGkQbufDdVJ)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			int num = 0;
			int[] array2 = default(int[]);
			while (num < 2)
			{
				while (true)
				{
					int num2 = 128 + num * 8;
					int num3 = -953133100;
					while (true)
					{
						switch (num3 ^ -953133097)
						{
						case 0:
							num3 = -953133099;
							continue;
						case 6:
							array2[2] = num2 + 2;
							array2[3] = num2 + 3;
							array2[4] = num2 + 4;
							num3 = -953133101;
							continue;
						case 1:
						{
							UnknownControllerHat.HatButtons buttons = new UnknownControllerHat.HatButtons(array2);
							array[num] = new UnknownControllerHat(buttons);
							num++;
							num3 = -953133102;
							continue;
						}
						case 3:
							array2 = new int[8];
							num3 = -953133104;
							continue;
						case 2:
							break;
						case 4:
							array2[5] = num2 + 5;
							array2[6] = num2 + 6;
							array2[7] = num2 + 7;
							num3 = -953133098;
							continue;
						case 7:
							array2[0] = num2;
							array2[1] = num2 + 1;
							num3 = -953133103;
							continue;
						default:
							goto end_IL_0094;
						}
						break;
					}
					continue;
					end_IL_0094:
					break;
				}
			}
			return array;
		}

		public static int CECochyvCrVYqtdgWNaKQYzgzdw(YhAVGDWXRPElABcAwbGZPlHyAsm P_0, YhAVGDWXRPElABcAwbGZPlHyAsm P_1)
		{
			if (P_0.QovxBPKLdqHelKEcdGLoDhrEJtsP < P_1.QovxBPKLdqHelKEcdGLoDhrEJtsP)
			{
				return -1;
			}
			if (P_0.QovxBPKLdqHelKEcdGLoDhrEJtsP > P_1.QovxBPKLdqHelKEcdGLoDhrEJtsP)
			{
				return 1;
			}
			return 0;
		}

		public static int UvyUDGHCzuhmcgBXjeHEeaJcpIE(YhAVGDWXRPElABcAwbGZPlHyAsm P_0, YhAVGDWXRPElABcAwbGZPlHyAsm P_1)
		{
			if (P_0.gGEWoFRvVVAnXKYZvrqbJLFBTeE < P_1.gGEWoFRvVVAnXKYZvrqbJLFBTeE)
			{
				goto IL_000e;
			}
			int num;
			if (P_0.gGEWoFRvVVAnXKYZvrqbJLFBTeE > P_1.gGEWoFRvVVAnXKYZvrqbJLFBTeE)
			{
				num = 324059034;
				goto IL_0013;
			}
			return 0;
			IL_000e:
			num = 324059033;
			goto IL_0013;
			IL_0013:
			switch (num ^ 0x1350BF9B)
			{
			case 0:
				break;
			case 2:
				return -1;
			default:
				return 1;
			}
			goto IL_000e;
		}
	}

	private class wqZlUqNnuFyTyZNovvlAoCAakYj
	{
		public enum eaBhLPwpFTvDVlWiRXLKqmolnLy
		{
			fyLkgCmTpqIuMAMCxJOMkArnGwx = 0,
			DVvUbKVHsTUhKpitpaArZixJgbT = 1
		}

		public class hvIwztZrUAHqTndGuvrhqsfARyf
		{
			public int YZYerWLyrZezITIzzsjvGpplKQw;

			public Guid GmccNuFyvwHynCnhZFJRHUjCwoC;

			public Guid UdzmHEFosksAvkflFwdfeLstDZW;

			public int GWoLlqegGvGyTtMNhZYqvtRENGv;

			public int bfRBSyiMEnqYkaJuaERXkSDgrMIl;

			public int iseCLQKKKNFGEzGoUHhRwvJfUWj;

			public int RUsxtZLmGlDUbqVLggiivRxcpCE;

			public bool CGvNMgTtJKByfBoLCudPLkyvgkV(YhAVGDWXRPElABcAwbGZPlHyAsm P_0, eaBhLPwpFTvDVlWiRXLKqmolnLy P_1)
			{
				if (P_0.rewiredId == YZYerWLyrZezITIzzsjvGpplKQw)
				{
					return true;
				}
				if (bfRBSyiMEnqYkaJuaERXkSDgrMIl != P_0.bfRBSyiMEnqYkaJuaERXkSDgrMIl)
				{
					return false;
				}
				if (iseCLQKKKNFGEzGoUHhRwvJfUWj != P_0.iseCLQKKKNFGEzGoUHhRwvJfUWj)
				{
					return false;
				}
				if (RUsxtZLmGlDUbqVLggiivRxcpCE != P_0.RUsxtZLmGlDUbqVLggiivRxcpCE)
				{
					return false;
				}
				switch (P_1)
				{
				case eaBhLPwpFTvDVlWiRXLKqmolnLy.fyLkgCmTpqIuMAMCxJOMkArnGwx:
					return GmccNuFyvwHynCnhZFJRHUjCwoC == P_0.uNwIAadyRUHwiZgeVCXdRHCFIBn;
				case eaBhLPwpFTvDVlWiRXLKqmolnLy.DVvUbKVHsTUhKpitpaArZixJgbT:
					return UdzmHEFosksAvkflFwdfeLstDZW == P_0.UdzmHEFosksAvkflFwdfeLstDZW;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private List<hvIwztZrUAHqTndGuvrhqsfARyf> rokTPxsNitEbJnvAHMxvBQpZKze;

		public wqZlUqNnuFyTyZNovvlAoCAakYj()
		{
			rokTPxsNitEbJnvAHMxvBQpZKze = new List<hvIwztZrUAHqTndGuvrhqsfARyf>();
		}

		public void hGoGXvVewDdznIUDiLVJVGFrUsD(YhAVGDWXRPElABcAwbGZPlHyAsm P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int count = rokTPxsNitEbJnvAHMxvBQpZKze.Count;
				int num = 0;
				int num2 = 414608280;
				while (true)
				{
					switch (num2 ^ 0x18B66B9D)
					{
					case 7:
						num2 = 414608284;
						continue;
					case 1:
						break;
					case 9:
					{
						int num3;
						if (!rokTPxsNitEbJnvAHMxvBQpZKze[num].CGvNMgTtJKByfBoLCudPLkyvgkV(P_0, eaBhLPwpFTvDVlWiRXLKqmolnLy.fyLkgCmTpqIuMAMCxJOMkArnGwx))
						{
							num2 = 414608283;
							num3 = num2;
						}
						else
						{
							num2 = 414608285;
							num3 = num2;
						}
						continue;
					}
					case 5:
						num2 = 414608287;
						continue;
					case 4:
						rokTPxsNitEbJnvAHMxvBQpZKze[num].RUsxtZLmGlDUbqVLggiivRxcpCE = P_0.RUsxtZLmGlDUbqVLggiivRxcpCE;
						num2 = 414608277;
						continue;
					case 0:
						rokTPxsNitEbJnvAHMxvBQpZKze[num].YZYerWLyrZezITIzzsjvGpplKQw = P_0.rewiredId;
						rokTPxsNitEbJnvAHMxvBQpZKze[num].GmccNuFyvwHynCnhZFJRHUjCwoC = P_0.uNwIAadyRUHwiZgeVCXdRHCFIBn;
						rokTPxsNitEbJnvAHMxvBQpZKze[num].UdzmHEFosksAvkflFwdfeLstDZW = P_0.UdzmHEFosksAvkflFwdfeLstDZW;
						rokTPxsNitEbJnvAHMxvBQpZKze[num].GWoLlqegGvGyTtMNhZYqvtRENGv = P_0.inputManagerId;
						rokTPxsNitEbJnvAHMxvBQpZKze[num].bfRBSyiMEnqYkaJuaERXkSDgrMIl = P_0.bfRBSyiMEnqYkaJuaERXkSDgrMIl;
						rokTPxsNitEbJnvAHMxvBQpZKze[num].iseCLQKKKNFGEzGoUHhRwvJfUWj = P_0.iseCLQKKKNFGEzGoUHhRwvJfUWj;
						num2 = 414608281;
						continue;
					case 6:
						num++;
						num2 = 414608287;
						continue;
					case 2:
						if (num >= count)
						{
							rokTPxsNitEbJnvAHMxvBQpZKze.Add(new hvIwztZrUAHqTndGuvrhqsfARyf
							{
								YZYerWLyrZezITIzzsjvGpplKQw = P_0.rewiredId,
								GmccNuFyvwHynCnhZFJRHUjCwoC = P_0.uNwIAadyRUHwiZgeVCXdRHCFIBn,
								UdzmHEFosksAvkflFwdfeLstDZW = P_0.UdzmHEFosksAvkflFwdfeLstDZW,
								GWoLlqegGvGyTtMNhZYqvtRENGv = P_0.inputManagerId,
								bfRBSyiMEnqYkaJuaERXkSDgrMIl = P_0.bfRBSyiMEnqYkaJuaERXkSDgrMIl,
								iseCLQKKKNFGEzGoUHhRwvJfUWj = P_0.iseCLQKKKNFGEzGoUHhRwvJfUWj,
								RUsxtZLmGlDUbqVLggiivRxcpCE = P_0.RUsxtZLmGlDUbqVLggiivRxcpCE
							});
							num2 = 414608286;
							continue;
						}
						goto case 9;
					case 8:
						BfoPnOzEfehguKuapcNsLLRRhsb(P_0.rewiredId, P_0.uNwIAadyRUHwiZgeVCXdRHCFIBn, num);
						return;
					default:
						BfoPnOzEfehguKuapcNsLLRRhsb(P_0.rewiredId, P_0.uNwIAadyRUHwiZgeVCXdRHCFIBn, rokTPxsNitEbJnvAHMxvBQpZKze.Count - 1);
						return;
					}
					break;
				}
			}
		}

		public bool WfhdeimYiTFGUIbHSjqOJaakYWS(YhAVGDWXRPElABcAwbGZPlHyAsm P_0, eaBhLPwpFTvDVlWiRXLKqmolnLy P_1)
		{
			int count = rokTPxsNitEbJnvAHMxvBQpZKze.Count;
			int num = 0;
			while (true)
			{
				int num2 = 1796407071;
				while (true)
				{
					switch (num2 ^ 0x6B12FF1E)
					{
					case 0:
						break;
					case 1:
						num2 = 1796407068;
						continue;
					case 3:
						if (rokTPxsNitEbJnvAHMxvBQpZKze[num].CGvNMgTtJKByfBoLCudPLkyvgkV(P_0, P_1))
						{
							return true;
						}
						num++;
						num2 = 1796407068;
						continue;
					default:
						if (num >= count)
						{
							return false;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public hvIwztZrUAHqTndGuvrhqsfARyf OlRyGPawIBmfpGbjKDHJQXdzfaeG(YhAVGDWXRPElABcAwbGZPlHyAsm P_0, eaBhLPwpFTvDVlWiRXLKqmolnLy P_1)
		{
			int count = rokTPxsNitEbJnvAHMxvBQpZKze.Count;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= count)
				{
					num2 = -1207904427;
					num3 = num2;
				}
				else
				{
					num2 = -1207904425;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1207904426)
					{
					case 2:
						num2 = -1207904425;
						continue;
					case 1:
						if (rokTPxsNitEbJnvAHMxvBQpZKze[num].CGvNMgTtJKByfBoLCudPLkyvgkV(P_0, P_1))
						{
							return rokTPxsNitEbJnvAHMxvBQpZKze[num];
						}
						num++;
						num2 = -1207904426;
						continue;
					case 0:
						break;
					default:
						return null;
					}
					break;
				}
			}
		}

		private void BfoPnOzEfehguKuapcNsLLRRhsb(int P_0, Guid P_1, int P_2)
		{
			int num = rokTPxsNitEbJnvAHMxvBQpZKze.Count - 1;
			while (num >= 0)
			{
				while (true)
				{
					int num2;
					if (num != P_2)
					{
						int num3;
						if (rokTPxsNitEbJnvAHMxvBQpZKze[num].YZYerWLyrZezITIzzsjvGpplKQw != P_0)
						{
							num2 = 229198378;
							num3 = num2;
						}
						else
						{
							num2 = 229198382;
							num3 = num2;
						}
						goto IL_0018;
					}
					goto IL_00a6;
					IL_0018:
					while (true)
					{
						switch (num2 ^ 0xDA94A2A)
						{
						case 5:
							num2 = 229198377;
							continue;
						case 3:
							break;
						case 4:
							rokTPxsNitEbJnvAHMxvBQpZKze.RemoveAt(num);
							num2 = 229198379;
							continue;
						case 0:
							goto IL_0079;
						case 1:
							goto IL_00a6;
						default:
							goto end_IL_003d;
						}
						break;
						IL_0079:
						int num4;
						if (!(rokTPxsNitEbJnvAHMxvBQpZKze[num].GmccNuFyvwHynCnhZFJRHUjCwoC == P_1))
						{
							num2 = 229198379;
							num4 = num2;
						}
						else
						{
							num2 = 229198382;
							num4 = num2;
						}
					}
					continue;
					IL_00a6:
					num--;
					num2 = 229198376;
					goto IL_0018;
					continue;
					end_IL_003d:
					break;
				}
			}
		}
	}

	internal const bool iGnxYwRWiTPdScoiohDdqoEntM = true;

	private IInputSource FXkavZACisNCWLIPykvLbGBTlyBs;

	private List<YhAVGDWXRPElABcAwbGZPlHyAsm> AVRtfMRpOzQlHvmKXxpZoBGaQUn;

	private int xrSChNBBhEWHvkeIhZBjNmkdZsmA;

	private wqZlUqNnuFyTyZNovvlAoCAakYj VYIiPbQDTfmyzeeKLOEXjAUgGAe;

	private bool LDAcgYOFyYXGHPLDHfJvYGEiUNl;

	private Action<int, ControllerDataUpdater> EpczCkvPPKAdjiQfdfFMvZxBJnNl;

	private PlatformInputManager SUAsPHGFrajzPXFANEuqbUoeMlU;

	private readonly bool lgIWiCmutwdCNHwQPrQVIcHvAlBJ;

	private readonly bool JUQVxgIOnvaTgssgbzTlGcephgU;

	private readonly bool uLrDDqgVKMsgrfbQADELDAPhHnjW;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> brkuSOIQTXGziCshBbHdBPqhLfY;

	private readonly Func<int> wHXHOjgCCjfwhXpVEAfBjzTabcoI;

	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			return xrSChNBBhEWHvkeIhZBjNmkdZsmA;
		}
	}

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager
	{
		get
		{
			return SUAsPHGFrajzPXFANEuqbUoeMlU;
		}
	}

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource
	{
		get
		{
			return FXkavZACisNCWLIPykvLbGBTlyBs;
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

	public DGeBQlGPLqneYoaqQWDWeIPFUOuA(ConfigVars configVars, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId, bool handleJoysticks, bool handleUnifiedMouse, bool handleUnifiedKeyboard)
	{
		try
		{
			brkuSOIQTXGziCshBbHdBPqhLfY = getHardwareJoystickMap_InputManager;
			wHXHOjgCCjfwhXpVEAfBjzTabcoI = getNewJoystickId;
			lgIWiCmutwdCNHwQPrQVIcHvAlBJ = handleJoysticks;
			JUQVxgIOnvaTgssgbzTlGcephgU = handleUnifiedMouse;
			uLrDDqgVKMsgrfbQADELDAPhHnjW = handleUnifiedKeyboard;
			SUAsPHGFrajzPXFANEuqbUoeMlU = this;
			FXkavZACisNCWLIPykvLbGBTlyBs = new SDL2InputSource(configVars.updateLoop, handleJoysticks, handleJoysticks, handleUnifiedMouse, handleUnifiedKeyboard);
			EpczCkvPPKAdjiQfdfFMvZxBJnNl = UpdateControllerData;
			FXkavZACisNCWLIPykvLbGBTlyBs.DeviceChangedEvent += BmvdVcmqmHAOAJfiWIQRViACsBqa;
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
		if (lgIWiCmutwdCNHwQPrQVIcHvAlBJ)
		{
			VYIiPbQDTfmyzeeKLOEXjAUgGAe = new wqZlUqNnuFyTyZNovvlAoCAakYj();
			MBWbLtwiramKtsVixhpKLRHaVam();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (FXkavZACisNCWLIPykvLbGBTlyBs != null)
		{
			goto IL_000b;
		}
		goto IL_00dc;
		IL_000b:
		int num = 907937929;
		goto IL_0010;
		IL_0010:
		int num3 = default(int);
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x361E088D)
			{
			case 13:
				break;
			default:
				return;
			case 8:
				goto IL_0058;
			case 12:
				goto IL_0069;
			case 10:
			{
				YhAVGDWXRPElABcAwbGZPlHyAsm yhAVGDWXRPElABcAwbGZPlHyAsm2 = AVRtfMRpOzQlHvmKXxpZoBGaQUn[num3];
				if (yhAVGDWXRPElABcAwbGZPlHyAsm2 != null)
				{
					yhAVGDWXRPElABcAwbGZPlHyAsm2.HrKwtmtRDFnaeZJljhCzhLkJIIeA.Update(updateLoop);
					num = 907937930;
					continue;
				}
				goto case 7;
			}
			case 3:
				goto IL_00a9;
			case 7:
				num3++;
				num = 907937926;
				continue;
			case 1:
				goto IL_00dc;
			case 0:
				FXkavZACisNCWLIPykvLbGBTlyBs.UpdateDevices(updateLoop);
				num = 907937934;
				continue;
			case 5:
				goto IL_0115;
			case 11:
				goto IL_0126;
			case 4:
				FXkavZACisNCWLIPykvLbGBTlyBs.Update();
				num = 907937932;
				continue;
			case 6:
			{
				YhAVGDWXRPElABcAwbGZPlHyAsm yhAVGDWXRPElABcAwbGZPlHyAsm = AVRtfMRpOzQlHvmKXxpZoBGaQUn[num2];
				if (yhAVGDWXRPElABcAwbGZPlHyAsm != null)
				{
					yhAVGDWXRPElABcAwbGZPlHyAsm.HrKwtmtRDFnaeZJljhCzhLkJIIeA.UpdateFinished();
					num = 907937935;
					continue;
				}
				goto case 2;
			}
			case 2:
				num2++;
				num = 907937921;
				continue;
			case 9:
				return;
			}
			break;
			IL_0126:
			int num4;
			if (num3 >= xrSChNBBhEWHvkeIhZBjNmkdZsmA)
			{
				num = 907937933;
				num4 = num;
			}
			else
			{
				num = 907937927;
				num4 = num;
			}
			continue;
			IL_0069:
			int num5;
			if (num2 >= xrSChNBBhEWHvkeIhZBjNmkdZsmA)
			{
				num = 907937928;
				num5 = num;
			}
			else
			{
				num = 907937931;
				num5 = num;
			}
		}
		goto IL_000b;
		IL_0058:
		if (FXkavZACisNCWLIPykvLbGBTlyBs != null)
		{
			num3 = 0;
			num = 907937926;
			goto IL_0010;
		}
		goto IL_00a9;
		IL_00dc:
		if (lgIWiCmutwdCNHwQPrQVIcHvAlBJ)
		{
			if (LDAcgYOFyYXGHPLDHfJvYGEiUNl)
			{
				YUdSTENKKNoVxApSKeakGqiLoBfc();
				num = 907937925;
				goto IL_0010;
			}
			goto IL_0058;
		}
		goto IL_0115;
		IL_0115:
		bool jUQVxgIOnvaTgssgbzTlGcephgU = JUQVxgIOnvaTgssgbzTlGcephgU;
		num = 907937924;
		goto IL_0010;
		IL_00a9:
		njzLgbngHRtFtusDoWSXPlqSohr();
		if (FXkavZACisNCWLIPykvLbGBTlyBs != null)
		{
			FXkavZACisNCWLIPykvLbGBTlyBs.UpdateFinished();
			num2 = 0;
			num = 907937921;
			goto IL_0010;
		}
		goto IL_0115;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		int count = default(int);
		if (AVRtfMRpOzQlHvmKXxpZoBGaQUn != null)
		{
			count = AVRtfMRpOzQlHvmKXxpZoBGaQUn.Count;
			goto IL_0014;
		}
		goto IL_0087;
		IL_0087:
		int num;
		if (FXkavZACisNCWLIPykvLbGBTlyBs != null)
		{
			FXkavZACisNCWLIPykvLbGBTlyBs.Dispose();
			num = -238954642;
			goto IL_0019;
		}
		return;
		IL_0014:
		num = -238954647;
		goto IL_0019;
		IL_0019:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ -238954641)
			{
			case 4:
				break;
			default:
				return;
			case 3:
				goto IL_0042;
			case 0:
				if (AVRtfMRpOzQlHvmKXxpZoBGaQUn[num2] != null)
				{
					jubkEfPWovmVDOzYftHZlVlzvfw hrKwtmtRDFnaeZJljhCzhLkJIIeA = AVRtfMRpOzQlHvmKXxpZoBGaQUn[num2].HrKwtmtRDFnaeZJljhCzhLkJIIeA;
					if (hrKwtmtRDFnaeZJljhCzhLkJIIeA != null)
					{
						hrKwtmtRDFnaeZJljhCzhLkJIIeA.Unacquire();
						num = -238954643;
						continue;
					}
				}
				goto case 2;
			case 5:
				goto IL_0087;
			case 6:
				num2 = 0;
				num = -238954644;
				continue;
			case 2:
				num2++;
				num = -238954644;
				continue;
			case 1:
				return;
			}
			break;
			IL_0042:
			int num3;
			if (num2 < count)
			{
				num = -238954641;
				num3 = num;
			}
			else
			{
				num = -238954646;
				num3 = num;
			}
		}
		goto IL_0014;
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return EpczCkvPPKAdjiQfdfFMvZxBJnNl;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!lgIWiCmutwdCNHwQPrQVIcHvAlBJ)
		{
			return;
		}
		while (true)
		{
			int num = 0;
			int num2 = -1750251196;
			while (true)
			{
				switch (num2 ^ -1750251194)
				{
				case 0:
					num2 = -1750251197;
					continue;
				default:
					return;
				case 2:
				{
					int num3;
					if (num >= xrSChNBBhEWHvkeIhZBjNmkdZsmA)
					{
						num2 = -1750251195;
						num3 = num2;
					}
					else
					{
						num2 = -1750251198;
						num3 = num2;
					}
					continue;
				}
				case 1:
					num++;
					num2 = -1750251196;
					continue;
				case 4:
					if (AVRtfMRpOzQlHvmKXxpZoBGaQUn[num].inputManagerId == inputManagerId)
					{
						AVRtfMRpOzQlHvmKXxpZoBGaQUn[num].FillData(data);
						return;
					}
					goto case 1;
				case 5:
					break;
				case 3:
					return;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		if (lgIWiCmutwdCNHwQPrQVIcHvAlBJ)
		{
			LDAcgYOFyYXGHPLDHfJvYGEiUNl = true;
			goto IL_000f;
		}
		goto IL_002d;
		IL_002d:
		int num;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
			num = -1477966302;
			goto IL_0014;
		}
		return;
		IL_000f:
		num = -1477966303;
		goto IL_0014;
		IL_0014:
		switch (num ^ -1477966301)
		{
		case 0:
			break;
		default:
			return;
		case 2:
			goto IL_002d;
		case 1:
			return;
		}
		goto IL_000f;
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		if (lgIWiCmutwdCNHwQPrQVIcHvAlBJ)
		{
			LDAcgYOFyYXGHPLDHfJvYGEiUNl = true;
			goto IL_000f;
		}
		goto IL_002d;
		IL_002d:
		int num;
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
			num = -41594749;
			goto IL_0014;
		}
		return;
		IL_000f:
		num = -41594752;
		goto IL_0014;
		IL_0014:
		switch (num ^ -41594750)
		{
		case 0:
			break;
		default:
			return;
		case 2:
			goto IL_002d;
		case 1:
			return;
		}
		goto IL_000f;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		bool lgIWiCmutwdCNHwQPrQVIcHvAlBJ2 = lgIWiCmutwdCNHwQPrQVIcHvAlBJ;
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

	private void MBWbLtwiramKtsVixhpKLRHaVam()
	{
		MBWbLtwiramKtsVixhpKLRHaVam(PpKdQcnXKFTlyOtFxhfHWhvnXgY());
	}

	private void MBWbLtwiramKtsVixhpKLRHaVam(IList<jubkEfPWovmVDOzYftHZlVlzvfw> P_0)
	{
		int num = 0;
		int num5 = default(int);
		List<YhAVGDWXRPElABcAwbGZPlHyAsm> aVRtfMRpOzQlHvmKXxpZoBGaQUn = default(List<YhAVGDWXRPElABcAwbGZPlHyAsm>);
		int num3 = default(int);
		YhAVGDWXRPElABcAwbGZPlHyAsm yhAVGDWXRPElABcAwbGZPlHyAsm = default(YhAVGDWXRPElABcAwbGZPlHyAsm);
		jubkEfPWovmVDOzYftHZlVlzvfw jubkEfPWovmVDOzYftHZlVlzvfw2 = default(jubkEfPWovmVDOzYftHZlVlzvfw);
		int num6 = default(int);
		int count = default(int);
		while (true)
		{
			int num2 = 1987125672;
			while (true)
			{
				switch (num2 ^ 0x767121AF)
				{
				case 5:
					break;
				case 8:
					SAHmPdomeKmRmWDMHYyWboYkaxQ(num5, num, aVRtfMRpOzQlHvmKXxpZoBGaQUn, AVRtfMRpOzQlHvmKXxpZoBGaQUn);
					num3 = 0;
					num2 = 1987125666;
					continue;
				case 19:
					num2 = 1987125673;
					continue;
				case 1:
					DtOBegFLamhBKwlmzaaiccPahGxz(aVRtfMRpOzQlHvmKXxpZoBGaQUn, AVRtfMRpOzQlHvmKXxpZoBGaQUn, false);
					num2 = 1987125694;
					continue;
				case 9:
					yhAVGDWXRPElABcAwbGZPlHyAsm.bfRBSyiMEnqYkaJuaERXkSDgrMIl = jubkEfPWovmVDOzYftHZlVlzvfw2.AxisCount;
					yhAVGDWXRPElABcAwbGZPlHyAsm.iseCLQKKKNFGEzGoUHhRwvJfUWj = jubkEfPWovmVDOzYftHZlVlzvfw2.ButtonCount;
					num2 = 1987125691;
					continue;
				case 14:
					if (_UpdateControllerInfoEvent != null)
					{
						_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(AVRtfMRpOzQlHvmKXxpZoBGaQUn[num3]));
						num2 = 1987125693;
						continue;
					}
					goto case 18;
				case 15:
					if (P_0[num6] != null)
					{
						jubkEfPWovmVDOzYftHZlVlzvfw2 = P_0[num6];
						yhAVGDWXRPElABcAwbGZPlHyAsm = new YhAVGDWXRPElABcAwbGZPlHyAsm(brkuSOIQTXGziCshBbHdBPqhLfY);
						yhAVGDWXRPElABcAwbGZPlHyAsm.HrKwtmtRDFnaeZJljhCzhLkJIIeA = jubkEfPWovmVDOzYftHZlVlzvfw2;
						yhAVGDWXRPElABcAwbGZPlHyAsm.uNwIAadyRUHwiZgeVCXdRHCFIBn = jubkEfPWovmVDOzYftHZlVlzvfw2.InstanceGuid;
						num2 = 1987125676;
						continue;
					}
					goto case 12;
				case 11:
					yhAVGDWXRPElABcAwbGZPlHyAsm.dUFmmEnRQtqCUuTnapnLPxMpqTR = jubkEfPWovmVDOzYftHZlVlzvfw2.ProductId;
					yhAVGDWXRPElABcAwbGZPlHyAsm.NdbvKbBBJrSYqhcLkswavvMBjSd = jubkEfPWovmVDOzYftHZlVlzvfw2.VendorId;
					yhAVGDWXRPElABcAwbGZPlHyAsm.KOwcVsrLduAvDUBHbanJeoGoONt = jubkEfPWovmVDOzYftHZlVlzvfw2.DeviceType;
					yhAVGDWXRPElABcAwbGZPlHyAsm.gGEWoFRvVVAnXKYZvrqbJLFBTeE = jubkEfPWovmVDOzYftHZlVlzvfw2.JoystickId;
					num2 = 1987125670;
					continue;
				case 18:
					num3++;
					num2 = 1987125666;
					continue;
				case 4:
					yhAVGDWXRPElABcAwbGZPlHyAsm.extension = jubkEfPWovmVDOzYftHZlVlzvfw2.ControllerExtension;
					jubkEfPWovmVDOzYftHZlVlzvfw2.Acquire();
					yhAVGDWXRPElABcAwbGZPlHyAsm.sbcTSexDWKGUOKrMGnEajLgRvts();
					AVRtfMRpOzQlHvmKXxpZoBGaQUn.Add(yhAVGDWXRPElABcAwbGZPlHyAsm);
					num2 = 1987125695;
					continue;
				case 6:
					if (num6 >= count)
					{
						xrSChNBBhEWHvkeIhZBjNmkdZsmA = num;
						num2 = 1987125671;
						continue;
					}
					goto case 15;
				case 3:
					yhAVGDWXRPElABcAwbGZPlHyAsm.TlZBIVFqZBqEoMngnZzoQImlnStY = jubkEfPWovmVDOzYftHZlVlzvfw2.SystemName;
					yhAVGDWXRPElABcAwbGZPlHyAsm.MbrQwRnmlvxaToztrCqZEslEYAm = jubkEfPWovmVDOzYftHZlVlzvfw2.FriendlyName;
					yhAVGDWXRPElABcAwbGZPlHyAsm.PwAPPePhJPAsncuOIyMlQuCrJGKc = jubkEfPWovmVDOzYftHZlVlzvfw2.PidVid;
					num2 = 1987125668;
					continue;
				case 20:
					yhAVGDWXRPElABcAwbGZPlHyAsm.RUsxtZLmGlDUbqVLggiivRxcpCE = jubkEfPWovmVDOzYftHZlVlzvfw2.HatCount;
					yhAVGDWXRPElABcAwbGZPlHyAsm.PpQCTIiUxNTFQkUcLaiHwscvqivF = jubkEfPWovmVDOzYftHZlVlzvfw2.IsBluetoothDevice;
					yhAVGDWXRPElABcAwbGZPlHyAsm.wweKDPecOEKQRjeLwREKUOeenHA = jubkEfPWovmVDOzYftHZlVlzvfw2.SupportsVibration;
					num2 = 1987125677;
					continue;
				case 12:
					num6++;
					num2 = 1987125673;
					continue;
				case 2:
					yhAVGDWXRPElABcAwbGZPlHyAsm.dFeMnzRTSNcMYNGuAWZUeFGTLNj = jubkEfPWovmVDOzYftHZlVlzvfw2.VibrationMotorCount;
					num2 = 1987125675;
					continue;
				case 10:
					count = P_0.Count;
					num6 = 0;
					num2 = 1987125692;
					continue;
				case 7:
					aVRtfMRpOzQlHvmKXxpZoBGaQUn = AVRtfMRpOzQlHvmKXxpZoBGaQUn;
					num2 = 1987125679;
					continue;
				case 0:
					num5 = xrSChNBBhEWHvkeIhZBjNmkdZsmA;
					AVRtfMRpOzQlHvmKXxpZoBGaQUn = new List<YhAVGDWXRPElABcAwbGZPlHyAsm>();
					num2 = 1987125669;
					continue;
				case 16:
					num++;
					num2 = 1987125667;
					continue;
				case 13:
				{
					int num4;
					if (num3 < num)
					{
						num2 = 1987125665;
						num4 = num2;
					}
					else
					{
						num2 = 1987125678;
						num4 = num2;
					}
					continue;
				}
				default:
					DtOBegFLamhBKwlmzaaiccPahGxz(AVRtfMRpOzQlHvmKXxpZoBGaQUn, aVRtfMRpOzQlHvmKXxpZoBGaQUn, true);
					return;
				}
				break;
			}
		}
	}

	private void njzLgbngHRtFtusDoWSXPlqSohr()
	{
		int num = 0;
		while (num < xrSChNBBhEWHvkeIhZBjNmkdZsmA)
		{
			while (true)
			{
				YhAVGDWXRPElABcAwbGZPlHyAsm yhAVGDWXRPElABcAwbGZPlHyAsm = AVRtfMRpOzQlHvmKXxpZoBGaQUn[num];
				int num2;
				if (yhAVGDWXRPElABcAwbGZPlHyAsm != null)
				{
					yhAVGDWXRPElABcAwbGZPlHyAsm.Update();
					num2 = 1640977737;
					goto IL_0009;
				}
				goto IL_0043;
				IL_0009:
				while (true)
				{
					switch (num2 ^ 0x61CF5548)
					{
					case 0:
						num2 = 1640977738;
						continue;
					case 2:
						break;
					case 1:
						goto IL_0043;
					default:
						goto end_IL_0026;
					}
					break;
				}
				continue;
				IL_0043:
				num++;
				num2 = 1640977739;
				goto IL_0009;
				continue;
				end_IL_0026:
				break;
			}
		}
	}

	private bool CPaAqfCUxMjXGzHUphitDFxnSyX(VRdFMbYDznLdPhuJVzJXYifOWcT P_0)
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

	private IList<jubkEfPWovmVDOzYftHZlVlzvfw> PpKdQcnXKFTlyOtFxhfHWhvnXgY()
	{
		return FXkavZACisNCWLIPykvLbGBTlyBs.GetJoysticks<jubkEfPWovmVDOzYftHZlVlzvfw>();
	}

	private void SAHmPdomeKmRmWDMHYyWboYkaxQ(int P_0, int P_1, List<YhAVGDWXRPElABcAwbGZPlHyAsm> P_2, List<YhAVGDWXRPElABcAwbGZPlHyAsm> P_3)
	{
		if (P_1 > 0)
		{
			goto IL_0007;
		}
		goto IL_00b2;
		IL_0007:
		int num = 127233199;
		goto IL_000c;
		IL_000c:
		int num2 = default(int);
		YhAVGDWXRPElABcAwbGZPlHyAsm yhAVGDWXRPElABcAwbGZPlHyAsm = default(YhAVGDWXRPElABcAwbGZPlHyAsm);
		while (true)
		{
			switch (num ^ 0x7956CAB)
			{
			case 10:
				break;
			default:
				return;
			case 4:
				P_3.Sort(YhAVGDWXRPElABcAwbGZPlHyAsm.UvyUDGHCzuhmcgBXjeHEeaJcpIE);
				num = 127233187;
				continue;
			case 5:
				goto IL_0062;
			case 9:
				num2++;
				num = 127233197;
				continue;
			case 0:
				yhAVGDWXRPElABcAwbGZPlHyAsm = P_3[num2];
				num = 127233193;
				continue;
			case 6:
				if (num2 >= P_1)
				{
					P_3.Sort(YhAVGDWXRPElABcAwbGZPlHyAsm.CECochyvCrVYqtdgWNaKQYzgzdw);
					num = 127233192;
					continue;
				}
				goto case 0;
			case 8:
				goto IL_00b2;
			case 2:
				if (yhAVGDWXRPElABcAwbGZPlHyAsm == null)
				{
					goto case 9;
				}
				goto IL_00e6;
			case 7:
				SWJVUJtNevBpHELnpTBupupzivbg(P_1, P_3, wqZlUqNnuFyTyZNovvlAoCAakYj.eaBhLPwpFTvDVlWiRXLKqmolnLy.DVvUbKVHsTUhKpitpaArZixJgbT);
				num2 = 0;
				num = 127233197;
				continue;
			case 1:
				yhAVGDWXRPElABcAwbGZPlHyAsm.inputManagerId = lthALbyMafUeFUSoDiwZaXONIhC(P_3);
				yhAVGDWXRPElABcAwbGZPlHyAsm.rewiredId = wHXHOjgCCjfwhXpVEAfBjzTabcoI();
				VYIiPbQDTfmyzeeKLOEXjAUgGAe.hGoGXvVewDdznIUDiLVJVGFrUsD(yhAVGDWXRPElABcAwbGZPlHyAsm);
				num = 127233186;
				continue;
			case 3:
				return;
			}
			break;
			IL_00e6:
			int num3;
			if (yhAVGDWXRPElABcAwbGZPlHyAsm.inputManagerId < 0)
			{
				num = 127233194;
				num3 = num;
			}
			else
			{
				num = 127233186;
				num3 = num;
			}
		}
		goto IL_0007;
		IL_0062:
		SWJVUJtNevBpHELnpTBupupzivbg(P_1, P_3, wqZlUqNnuFyTyZNovvlAoCAakYj.eaBhLPwpFTvDVlWiRXLKqmolnLy.fyLkgCmTpqIuMAMCxJOMkArnGwx);
		num = 127233196;
		goto IL_000c;
		IL_00b2:
		if (P_0 > 0 && P_1 > 0)
		{
			CJTiCwRYBKtdCjdVGCYyAKtmlkc(P_1, P_3, P_0, P_2, wqZlUqNnuFyTyZNovvlAoCAakYj.eaBhLPwpFTvDVlWiRXLKqmolnLy.fyLkgCmTpqIuMAMCxJOMkArnGwx);
			CJTiCwRYBKtdCjdVGCYyAKtmlkc(P_1, P_3, P_0, P_2, wqZlUqNnuFyTyZNovvlAoCAakYj.eaBhLPwpFTvDVlWiRXLKqmolnLy.DVvUbKVHsTUhKpitpaArZixJgbT);
			num = 127233198;
			goto IL_000c;
		}
		goto IL_0062;
	}

	private void jMgFvMJOWRWuceXBnZGyQCpTgME(List<YhAVGDWXRPElABcAwbGZPlHyAsm> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				int num2;
				int num3;
				if (num == P_1)
				{
					num2 = 1197670723;
					num3 = num2;
				}
				else
				{
					num2 = 1197670720;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x47630141)
					{
					case 4:
						num2 = 1197670722;
						continue;
					case 2:
						num++;
						num2 = 1197670721;
						continue;
					case 1:
						if (P_0[num] != null && P_0[num].inputManagerId == P_2)
						{
							P_0[num].inputManagerId = -1;
							num2 = 1197670723;
							continue;
						}
						goto case 2;
					case 3:
						break;
					default:
						goto end_IL_0068;
					}
					break;
				}
				continue;
				end_IL_0068:
				break;
			}
		}
	}

	private bool tdJERshKrZupAABGOtPFZhjIApQ(List<YhAVGDWXRPElABcAwbGZPlHyAsm> P_0, int P_1)
	{
		int count = P_0.Count;
		int num = 0;
		while (true)
		{
			int num2 = -1732807000;
			while (true)
			{
				switch (num2 ^ -1732806998)
				{
				case 0:
					break;
				case 2:
					num2 = -1732806999;
					continue;
				case 3:
				{
					int num3;
					if (num < count)
					{
						num2 = -1732806997;
						num3 = num2;
					}
					else
					{
						num2 = -1732806994;
						num3 = num2;
					}
					continue;
				}
				case 1:
					if (P_0[num] != null && P_0[num].inputManagerId == P_1)
					{
						return false;
					}
					num++;
					num2 = -1732806999;
					continue;
				default:
					return true;
				}
				break;
			}
		}
	}

	private int lthALbyMafUeFUSoDiwZaXONIhC(List<YhAVGDWXRPElABcAwbGZPlHyAsm> P_0)
	{
		int num = 0;
		bool flag = default(bool);
		int num3 = default(int);
		int count = default(int);
		while (true)
		{
			int num2 = -1858741098;
			while (true)
			{
				switch (num2 ^ -1858741104)
				{
				case 4:
					break;
				case 2:
					if (!flag)
					{
						num2 = -1858741103;
						continue;
					}
					num++;
					goto case 6;
				case 3:
					if (P_0[num3] != null && P_0[num3].inputManagerId == num)
					{
						flag = true;
						num2 = -1858741102;
						continue;
					}
					goto case 5;
				case 5:
					num3++;
					num2 = -1858741104;
					continue;
				case 0:
				{
					int num4;
					if (num3 >= count)
					{
						num2 = -1858741102;
						num4 = num2;
					}
					else
					{
						num2 = -1858741101;
						num4 = num2;
					}
					continue;
				}
				case 6:
					flag = false;
					count = P_0.Count;
					num3 = 0;
					num2 = -1858741104;
					continue;
				default:
					return num;
				}
				break;
			}
		}
	}

	private bool reYntWceOkPUZwwqHtuPFEoKbLb(List<YhAVGDWXRPElABcAwbGZPlHyAsm> P_0, int P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		int num = 0;
		while (num < P_0.Count)
		{
			while (true)
			{
				if (P_0[num].rewiredId == P_1)
				{
					return true;
				}
				num++;
				int num2 = -124194434;
				while (true)
				{
					switch (num2 ^ -124194433)
					{
					case 0:
						num2 = -124194435;
						continue;
					case 2:
						break;
					default:
						goto end_IL_0027;
					}
					break;
				}
				continue;
				end_IL_0027:
				break;
			}
		}
		return false;
	}

	private void CJTiCwRYBKtdCjdVGCYyAKtmlkc(int P_0, List<YhAVGDWXRPElABcAwbGZPlHyAsm> P_1, int P_2, List<YhAVGDWXRPElABcAwbGZPlHyAsm> P_3, wqZlUqNnuFyTyZNovvlAoCAakYj.eaBhLPwpFTvDVlWiRXLKqmolnLy P_4)
	{
		if (P_4 != wqZlUqNnuFyTyZNovvlAoCAakYj.eaBhLPwpFTvDVlWiRXLKqmolnLy.fyLkgCmTpqIuMAMCxJOMkArnGwx)
		{
			goto IL_0007;
		}
		int num = 2;
		goto IL_009b;
		IL_0097:
		num = 1;
		goto IL_009b;
		IL_0007:
		int num2 = -1380845057;
		goto IL_000c;
		IL_000c:
		int num4 = default(int);
		YhAVGDWXRPElABcAwbGZPlHyAsm yhAVGDWXRPElABcAwbGZPlHyAsm2 = default(YhAVGDWXRPElABcAwbGZPlHyAsm);
		int num3 = default(int);
		int num5 = default(int);
		while (true)
		{
			switch (num2 ^ -1380845058)
			{
			case 3:
				break;
			case 7:
				num4++;
				num2 = -1380845062;
				continue;
			case 8:
			{
				yhAVGDWXRPElABcAwbGZPlHyAsm2 = P_1[num3];
				int num6;
				if (yhAVGDWXRPElABcAwbGZPlHyAsm2 == null)
				{
					num2 = -1380845060;
					num6 = num2;
				}
				else
				{
					num2 = -1380845058;
					num6 = num2;
				}
				continue;
			}
			case 2:
				num3++;
				num2 = -1380845065;
				continue;
			case 6:
				num3 = 0;
				num2 = -1380845065;
				continue;
			case 4:
				goto IL_007f;
			case 1:
				goto IL_0097;
			case 0:
				if (yhAVGDWXRPElABcAwbGZPlHyAsm2.inputManagerId < 0)
				{
					num4 = 0;
					num2 = -1380845062;
					continue;
				}
				goto case 2;
			case 5:
			{
				YhAVGDWXRPElABcAwbGZPlHyAsm yhAVGDWXRPElABcAwbGZPlHyAsm = P_3[num4];
				if (yhAVGDWXRPElABcAwbGZPlHyAsm != null && !reYntWceOkPUZwwqHtuPFEoKbLb(P_1, yhAVGDWXRPElABcAwbGZPlHyAsm.rewiredId) && yhAVGDWXRPElABcAwbGZPlHyAsm2.CGvNMgTtJKByfBoLCudPLkyvgkV(yhAVGDWXRPElABcAwbGZPlHyAsm) >= num5)
				{
					yhAVGDWXRPElABcAwbGZPlHyAsm2.wdORaALJIVHeMdYgqVfHekvpUfr(yhAVGDWXRPElABcAwbGZPlHyAsm);
					VYIiPbQDTfmyzeeKLOEXjAUgGAe.hGoGXvVewDdznIUDiLVJVGFrUsD(yhAVGDWXRPElABcAwbGZPlHyAsm2);
					num2 = -1380845063;
					continue;
				}
				goto case 7;
			}
			default:
				if (num3 >= P_0)
				{
					return;
				}
				goto case 8;
			}
			break;
			IL_007f:
			int num7;
			if (num4 < P_2)
			{
				num2 = -1380845061;
				num7 = num2;
			}
			else
			{
				num2 = -1380845060;
				num7 = num2;
			}
		}
		goto IL_0007;
		IL_009b:
		num5 = num;
		num2 = -1380845064;
		goto IL_000c;
	}

	private void SWJVUJtNevBpHELnpTBupupzivbg(int P_0, List<YhAVGDWXRPElABcAwbGZPlHyAsm> P_1, wqZlUqNnuFyTyZNovvlAoCAakYj.eaBhLPwpFTvDVlWiRXLKqmolnLy P_2)
	{
		int num = 0;
		int num4 = default(int);
		wqZlUqNnuFyTyZNovvlAoCAakYj.hvIwztZrUAHqTndGuvrhqsfARyf hvIwztZrUAHqTndGuvrhqsfARyf = default(wqZlUqNnuFyTyZNovvlAoCAakYj.hvIwztZrUAHqTndGuvrhqsfARyf);
		while (num < P_0)
		{
			while (true)
			{
				IL_00cb:
				YhAVGDWXRPElABcAwbGZPlHyAsm yhAVGDWXRPElABcAwbGZPlHyAsm = P_1[num];
				int num2;
				if (yhAVGDWXRPElABcAwbGZPlHyAsm != null)
				{
					int num3;
					if (yhAVGDWXRPElABcAwbGZPlHyAsm.inputManagerId >= 0)
					{
						num2 = 107492897;
						num3 = num2;
					}
					else
					{
						num2 = 107492899;
						num3 = num2;
					}
					goto IL_000c;
				}
				goto IL_00bd;
				IL_000c:
				while (true)
				{
					switch (num2 ^ 0x6683624)
					{
					case 4:
						num2 = 107492901;
						continue;
					case 3:
						num4 = (hvIwztZrUAHqTndGuvrhqsfARyf.GWoLlqegGvGyTtMNhZYqvtRENGv = lthALbyMafUeFUSoDiwZaXONIhC(P_1));
						num2 = 107492902;
						continue;
					case 7:
						break;
					case 0:
						yhAVGDWXRPElABcAwbGZPlHyAsm.rewiredId = hvIwztZrUAHqTndGuvrhqsfARyf.YZYerWLyrZezITIzzsjvGpplKQw;
						VYIiPbQDTfmyzeeKLOEXjAUgGAe.hGoGXvVewDdznIUDiLVJVGFrUsD(yhAVGDWXRPElABcAwbGZPlHyAsm);
						num2 = 107492897;
						continue;
					case 5:
						goto end_IL_000c;
					case 1:
						goto IL_00cb;
					case 2:
						yhAVGDWXRPElABcAwbGZPlHyAsm.inputManagerId = num4;
						num2 = 107492900;
						continue;
					default:
						goto end_IL_00cb;
					}
					hvIwztZrUAHqTndGuvrhqsfARyf = VYIiPbQDTfmyzeeKLOEXjAUgGAe.OlRyGPawIBmfpGbjKDHJQXdzfaeG(yhAVGDWXRPElABcAwbGZPlHyAsm, P_2);
					if (hvIwztZrUAHqTndGuvrhqsfARyf == null || reYntWceOkPUZwwqHtuPFEoKbLb(P_1, hvIwztZrUAHqTndGuvrhqsfARyf.YZYerWLyrZezITIzzsjvGpplKQw))
					{
						break;
					}
					num4 = hvIwztZrUAHqTndGuvrhqsfARyf.GWoLlqegGvGyTtMNhZYqvtRENGv;
					if (num4 < 0)
					{
						break;
					}
					int num5;
					if (tdJERshKrZupAABGOtPFZhjIApQ(P_1, num4))
					{
						num2 = 107492902;
						num5 = num2;
					}
					else
					{
						num2 = 107492903;
						num5 = num2;
					}
					continue;
					end_IL_000c:
					break;
				}
				goto IL_00bd;
				IL_00bd:
				num++;
				num2 = 107492898;
				goto IL_000c;
				continue;
				end_IL_00cb:
				break;
			}
		}
	}

	private void YUdSTENKKNoVxApSKeakGqiLoBfc()
	{
		IList<jubkEfPWovmVDOzYftHZlVlzvfw> list = PpKdQcnXKFTlyOtFxhfHWhvnXgY();
		MBWbLtwiramKtsVixhpKLRHaVam(list);
		LDAcgYOFyYXGHPLDHfJvYGEiUNl = false;
	}

	private bool hXJLHlYsxiqopPvGhwftUXQBvzA(IList<jubkEfPWovmVDOzYftHZlVlzvfw> P_0)
	{
		int count = P_0.Count;
		int num = 0;
		int num4 = default(int);
		int count2 = default(int);
		while (true)
		{
			int num2;
			int num3;
			if (num >= count)
			{
				num2 = 579095692;
				num3 = num2;
			}
			else
			{
				num2 = 579095691;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x22844C8F)
				{
				case 6:
					num2 = 579095691;
					continue;
				case 5:
					if (AVRtfMRpOzQlHvmKXxpZoBGaQUn[num4] != null && !HUsZfnuNKnAkovTFwwFvtmfDtxy(P_0, AVRtfMRpOzQlHvmKXxpZoBGaQUn[num4].uNwIAadyRUHwiZgeVCXdRHCFIBn))
					{
						num2 = 579095695;
						continue;
					}
					num4++;
					num2 = 579095693;
					continue;
				case 7:
					break;
				case 3:
					count2 = AVRtfMRpOzQlHvmKXxpZoBGaQUn.Count;
					num2 = 579095694;
					continue;
				case 4:
					if (P_0[num] != null && !cLeZwKsczVGPCKVaDfWbTdAjAfWn(P_0[num].InstanceGuid))
					{
						return true;
					}
					num++;
					num2 = 579095688;
					continue;
				case 0:
					return true;
				case 1:
					num4 = 0;
					num2 = 579095693;
					continue;
				default:
					if (num4 >= count2)
					{
						return false;
					}
					goto case 5;
				}
				break;
			}
		}
	}

	private bool cLeZwKsczVGPCKVaDfWbTdAjAfWn(Guid P_0)
	{
		int count = AVRtfMRpOzQlHvmKXxpZoBGaQUn.Count;
		int num = 0;
		while (true)
		{
			int num2 = 541631352;
			while (true)
			{
				switch (num2 ^ 0x2048A37B)
				{
				case 0:
					break;
				case 3:
					num2 = 541631354;
					continue;
				case 2:
					if (AVRtfMRpOzQlHvmKXxpZoBGaQUn[num] != null && AVRtfMRpOzQlHvmKXxpZoBGaQUn[num].uNwIAadyRUHwiZgeVCXdRHCFIBn == P_0)
					{
						return true;
					}
					num++;
					num2 = 541631354;
					continue;
				default:
					if (num >= count)
					{
						return false;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	private bool HUsZfnuNKnAkovTFwwFvtmfDtxy(IList<jubkEfPWovmVDOzYftHZlVlzvfw> P_0, Guid P_1)
	{
		int count = P_0.Count;
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < count)
			{
				num2 = -1586802572;
				num3 = num2;
			}
			else
			{
				num2 = -1586802574;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ -1586802569)
				{
				case 4:
					num2 = -1586802572;
					continue;
				case 3:
					if (P_0[num] != null)
					{
						num2 = -1586802569;
						continue;
					}
					goto IL_0047;
				case 1:
					return true;
				case 2:
					break;
				case 0:
					if (P_0[num].InstanceGuid == P_1)
					{
						num2 = -1586802570;
						continue;
					}
					goto IL_0047;
				default:
					{
						return false;
					}
					IL_0047:
					num++;
					num2 = -1586802571;
					continue;
				}
				break;
			}
		}
	}

	private void DtOBegFLamhBKwlmzaaiccPahGxz(List<YhAVGDWXRPElABcAwbGZPlHyAsm> P_0, List<YhAVGDWXRPElABcAwbGZPlHyAsm> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num3 = default(int);
		int num4 = default(int);
		int num5 = default(int);
		int num6 = default(int);
		bool flag = default(bool);
		YhAVGDWXRPElABcAwbGZPlHyAsm yhAVGDWXRPElABcAwbGZPlHyAsm = default(YhAVGDWXRPElABcAwbGZPlHyAsm);
		while (true)
		{
			IL_00ed:
			int num;
			if (P_0 != null)
			{
				num = P_0.Count;
				goto IL_0086;
			}
			int num2 = 1190740525;
			goto IL_000c;
			IL_0086:
			num3 = num;
			num4 = ((P_1 != null) ? P_1.Count : 0);
			num5 = 0;
			num2 = 1190740516;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				YhAVGDWXRPElABcAwbGZPlHyAsm yhAVGDWXRPElABcAwbGZPlHyAsm2;
				switch (num2 ^ 0x46F94227)
				{
				case 13:
					num2 = 1190740513;
					continue;
				case 7:
					num6++;
					num2 = 1190740523;
					continue;
				case 9:
					if (!flag)
					{
						jdgXxQHlYgOTDPrZOCVnfSFXUtzk(P_0[num5], P_2);
						num2 = 1190740515;
						continue;
					}
					goto case 4;
				case 10:
					break;
				case 3:
					num2 = 1190740527;
					continue;
				case 1:
					yhAVGDWXRPElABcAwbGZPlHyAsm2 = P_1[num6];
					if (yhAVGDWXRPElABcAwbGZPlHyAsm2 == null)
					{
						goto case 7;
					}
					goto IL_00b8;
				case 5:
					flag = true;
					num2 = 1190740524;
					continue;
				case 6:
					goto IL_00ed;
				case 4:
					num5++;
					num2 = 1190740527;
					continue;
				case 11:
					num2 = 1190740526;
					continue;
				case 0:
					yhAVGDWXRPElABcAwbGZPlHyAsm = P_0[num5];
					if (yhAVGDWXRPElABcAwbGZPlHyAsm == null)
					{
						goto case 4;
					}
					goto IL_011d;
				case 12:
					goto IL_0137;
				case 2:
					num6 = 0;
					num2 = 1190740523;
					continue;
				default:
					if (num5 >= num3)
					{
						return;
					}
					goto case 0;
				}
				break;
				IL_0137:
				int num7;
				if (num6 < num4)
				{
					num2 = 1190740518;
					num7 = num2;
				}
				else
				{
					num2 = 1190740526;
					num7 = num2;
				}
				continue;
				IL_011d:
				flag = false;
				int num8;
				if (P_1 != null)
				{
					num2 = 1190740517;
					num8 = num2;
				}
				else
				{
					num2 = 1190740526;
					num8 = num2;
				}
				continue;
				IL_00b8:
				int num9;
				if (!(yhAVGDWXRPElABcAwbGZPlHyAsm.uNwIAadyRUHwiZgeVCXdRHCFIBn == yhAVGDWXRPElABcAwbGZPlHyAsm2.uNwIAadyRUHwiZgeVCXdRHCFIBn))
				{
					num2 = 1190740512;
					num9 = num2;
				}
				else
				{
					num2 = 1190740514;
					num9 = num2;
				}
			}
			num = 0;
			goto IL_0086;
		}
	}

	private void jdgXxQHlYgOTDPrZOCVnfSFXUtzk(YhAVGDWXRPElABcAwbGZPlHyAsm P_0, bool P_1)
	{
		if (P_1)
		{
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0.ToBridgedController());
			}
			return;
		}
		while (_DeviceDisconnectedEvent != null)
		{
			_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
			int num = 958415026;
			while (true)
			{
				switch (num ^ 0x392040B0)
				{
				case 0:
					goto IL_001d;
				default:
					return;
				case 1:
					break;
				case 2:
					return;
				}
				break;
				IL_001d:
				num = 958415025;
			}
		}
	}

	private void BmvdVcmqmHAOAJfiWIQRViACsBqa()
	{
		if (lgIWiCmutwdCNHwQPrQVIcHvAlBJ)
		{
			LDAcgYOFyYXGHPLDHfJvYGEiUNl = true;
		}
		SystemDeviceConnected();
	}
}
