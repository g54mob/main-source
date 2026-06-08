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

internal class RwuqjFZefeIiGvIajuPSbfDUEbG : PlatformInputManager
{
	private class ptMebSqXEoBzBEOaTPyqDqsEryl : IInputManagerJoystickPublic, IInputManagerJoystick
	{
		private int HhStEfcVVlMiBjgWdCLXZvzOFhgb;

		private int SVlrBPWDEySKVHcSUJitCfBSxnO;

		public Guid NdHHxuQRnYAiYXlkbCSlISGovAq;

		public string ZGTmjgWFNFsgSCTjoNlvpXjmevb;

		public pErdarFuDrLltFruMSsYCDRyarSk BOANwqncOLYXWURmWjkyMSRMEGQ;

		public PqXIqBGoIivkjpVVhKhHIXloIJf SkCcAXgfijscHdWxkWFsSHOZWErK;

		public string FBYkTRckLemSakYJQMtfxOSmUPg;

		public string IifBwgifDjJLQbtRWmfjwrERSUof;

		public int fkLtKGzJsvTUqlGdRyYQcjTaPmb;

		public int LVhyNzNFybpcQeqlBtHhAycOnvD;

		public Guid qYoawwlzgWjKYCaKkjvoociYFuT;

		public PidVid LjGpBwDvaZYnRpwgjlueNWucAwo;

		public Guid IerddSLNXqqcFfmPgxIqNDWuwNi;

		public int ezQswNZyAXdiNHmgSaQroyfOVDk;

		public int wXeJUZjIVNWqHFFJQtwFIYdCqUi;

		public int bOvCrfWoeojdEksYxLnTCSWDiEj;

		public int lCNqQoAApxuECSfGdHgIftxqKOX;

		public int oGcycOAqtFGbygaGhDMChNbBqYZn;

		public int VRaBaRJBhrkeRbpjPHxbMRTvGos;

		public bool XOcpUHIIBydiGZIoNLAeVYoWsBq;

		public bool gkkruTywtCSgfaMjHfnJvKIxFVy;

		public int hSqMknHvfLaCaSKUtNrDJWiYQVX;

		private float[] JzCpTyTcKdiDVvPxFKAbxEFLDAw;

		private bool[] vEmeiLseeiFjOBSerAJjqspjZBa;

		private HardwareJoystickMap_InputManager REZiFujnwfIcWniRKvMxDxhPHlx;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> dUeoOAWeqXvgKLTHqOAcuSQkGJiK;

		private bool yvNsRHUPPyTccyoavGrrgtIginfh;

		private bool BjLRIbHSNziZuePSCMYMTKKmtVyj;

		[CompilerGenerated]
		private Controller.Extension IgrBNRGQkhuGLKeavSEuQpUCshxk;

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return HhStEfcVVlMiBjgWdCLXZvzOFhgb;
			}
			set
			{
				HhStEfcVVlMiBjgWdCLXZvzOFhgb = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return SVlrBPWDEySKVHcSUJitCfBSxnO;
			}
			set
			{
				SVlrBPWDEySKVHcSUJitCfBSxnO = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name => ZGTmjgWFNFsgSCTjoNlvpXjmevb;

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (SVlrBPWDEySKVHcSUJitCfBSxnO < 0)
				{
					return null;
				}
				return SVlrBPWDEySKVHcSUJitCfBSxnO;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId => 0;

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => qYoawwlzgWjKYCaKkjvoociYFuT;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension
		{
			[CompilerGenerated]
			get
			{
				return IgrBNRGQkhuGLKeavSEuQpUCshxk;
			}
			[CompilerGenerated]
			set
			{
				IgrBNRGQkhuGLKeavSEuQpUCshxk = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			BOANwqncOLYXWURmWjkyMSRMEGQ.uPtTlYiohIZYwfJamuAMSPBFYor(motorIndex, amount, false);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		public ptMebSqXEoBzBEOaTPyqDqsEryl(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			dUeoOAWeqXvgKLTHqOAcuSQkGJiK = getHardwareJoystickMap_InputManager;
			SVlrBPWDEySKVHcSUJitCfBSxnO = -1;
			HhStEfcVVlMiBjgWdCLXZvzOFhgb = -1;
		}

		public void kfcRhmfnfWicmjTenihbZSYGYjYh()
		{
			IerddSLNXqqcFfmPgxIqNDWuwNi = MiscTools.CreateGuidHashSHA1(FBYkTRckLemSakYJQMtfxOSmUPg + LjGpBwDvaZYnRpwgjlueNWucAwo.ToProductGuid());
			wXeJUZjIVNWqHFFJQtwFIYdCqUi = lCNqQoAApxuECSfGdHgIftxqKOX;
			bOvCrfWoeojdEksYxLnTCSWDiEj = oGcycOAqtFGbygaGhDMChNbBqYZn + VRaBaRJBhrkeRbpjPHxbMRTvGos * 8;
			XxHELBuvCCtGAJntxYQUzFBhOFy();
			while (true)
			{
				int num = 1467552839;
				while (true)
				{
					int num2;
					switch (num ^ 0x57791446)
					{
					case 0:
						break;
					case 1:
						NdHHxuQRnYAiYXlkbCSlISGovAq = REZiFujnwfIcWniRKvMxDxhPHlx.hardwareMapIdentifier.guid;
						ZGTmjgWFNFsgSCTjoNlvpXjmevb = REZiFujnwfIcWniRKvMxDxhPHlx.controllerName;
						num2 = ((NdHHxuQRnYAiYXlkbCSlISGovAq == Guid.Empty) ? 1 : 0);
						goto IL_00a9;
					default:
						JzCpTyTcKdiDVvPxFKAbxEFLDAw = new float[wXeJUZjIVNWqHFFJQtwFIYdCqUi];
						vEmeiLseeiFjOBSerAJjqspjZBa = new bool[bOvCrfWoeojdEksYxLnTCSWDiEj];
						Update();
						return;
					}
					break;
					IL_00a9:
					yvNsRHUPPyTccyoavGrrgtIginfh = (byte)num2 != 0;
					num = 1467552836;
				}
			}
		}

		public void mJCczqeFiFMzoayoFJmEwVIjyQZW(ptMebSqXEoBzBEOaTPyqDqsEryl P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int num3 = default(int);
			while (true)
			{
				SVlrBPWDEySKVHcSUJitCfBSxnO = P_0.SVlrBPWDEySKVHcSUJitCfBSxnO;
				HhStEfcVVlMiBjgWdCLXZvzOFhgb = P_0.HhStEfcVVlMiBjgWdCLXZvzOFhgb;
				int num = 0;
				int num2 = 1313460580;
				while (true)
				{
					switch (num2 ^ 0x4E49D163)
					{
					case 6:
						num2 = 1313460578;
						continue;
					case 3:
						JzCpTyTcKdiDVvPxFKAbxEFLDAw[num3] = P_0.JzCpTyTcKdiDVvPxFKAbxEFLDAw[num3];
						num3++;
						num2 = 1313460583;
						continue;
					case 5:
						vEmeiLseeiFjOBSerAJjqspjZBa[num] = P_0.vEmeiLseeiFjOBSerAJjqspjZBa[num];
						num++;
						num2 = 1313460577;
						continue;
					case 2:
					{
						int num4;
						if (num >= MathTools.Min(vEmeiLseeiFjOBSerAJjqspjZBa.Length, P_0.vEmeiLseeiFjOBSerAJjqspjZBa.Length))
						{
							num2 = 1313460579;
							num4 = num2;
						}
						else
						{
							num2 = 1313460582;
							num4 = num2;
						}
						continue;
					}
					case 0:
						num3 = 0;
						num2 = 1313460583;
						continue;
					case 7:
						num2 = 1313460577;
						continue;
					case 1:
						break;
					default:
						if (num3 >= MathTools.Min(JzCpTyTcKdiDVvPxFKAbxEFLDAw.Length, P_0.JzCpTyTcKdiDVvPxFKAbxEFLDAw.Length))
						{
							BjLRIbHSNziZuePSCMYMTKKmtVyj = P_0.BjLRIbHSNziZuePSCMYMTKKmtVyj;
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			UDEtzvxqREkxyopZfQhiKhodhQPJ();
			while (true)
			{
				int num = -832375007;
				while (true)
				{
					switch (num ^ -832375008)
					{
					case 4:
						break;
					default:
						return;
					case 1:
						nLotdmIEnGDlRjnDZLzPFXYmCSSJ();
						num = -832375005;
						continue;
					case 3:
						if (!BjLRIbHSNziZuePSCMYMTKKmtVyj)
						{
							int num2;
							if (BOANwqncOLYXWURmWjkyMSRMEGQ.HasEverReceivedInput)
							{
								num = -832375008;
								num2 = num;
							}
							else
							{
								num = -832375006;
								num2 = num;
							}
							continue;
						}
						return;
					case 0:
						BjLRIbHSNziZuePSCMYMTKKmtVyj = true;
						num = -832375006;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (wXeJUZjIVNWqHFFJQtwFIYdCqUi == dataUpdater.axisCount)
			{
				int num3 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = 530748246;
					while (true)
					{
						switch (num ^ 0x1FA29353)
						{
						case 7:
							break;
						default:
							return;
						case 2:
							dataUpdater.axisValues[num3] = JzCpTyTcKdiDVvPxFKAbxEFLDAw[num3];
							num3++;
							num = 530748240;
							continue;
						case 8:
							dataUpdater.buttonValues[num2] = vEmeiLseeiFjOBSerAJjqspjZBa[num2];
							num2++;
							num = 530748243;
							continue;
						case 3:
							goto IL_0084;
						case 0:
							if (num2 >= bOvCrfWoeojdEksYxLnTCSWDiEj)
							{
								if (BjLRIbHSNziZuePSCMYMTKKmtVyj && !dataUpdater.hasReceivedInput)
								{
									dataUpdater.hasReceivedInput = true;
									num = 530748242;
									continue;
								}
								return;
							}
							goto case 8;
						case 5:
							goto IL_00cb;
						case 9:
							num3 = 0;
							num = 530748240;
							continue;
						case 6:
							goto end_IL_0011;
						case 4:
							num2 = 0;
							num = 530748243;
							continue;
						case 1:
							return;
						}
						break;
						IL_00cb:
						int num4;
						if (bOvCrfWoeojdEksYxLnTCSWDiEj != dataUpdater.buttonCount)
						{
							num = 530748245;
							num4 = num;
						}
						else
						{
							num = 530748250;
							num4 = num;
						}
						continue;
						IL_0084:
						int num5;
						if (num3 >= wXeJUZjIVNWqHFFJQtwFIYdCqUi)
						{
							num = 530748247;
							num5 = num;
						}
						else
						{
							num = 530748241;
							num5 = num;
						}
					}
					continue;
					end_IL_0011:
					break;
				}
			}
			throw new Exception("This controller signature does not match the data object!");
		}

		public int YfzaYuFFeAGpZYIlhOCKodCcBwd(ptMebSqXEoBzBEOaTPyqDqsEryl P_0)
		{
			if (P_0.HhStEfcVVlMiBjgWdCLXZvzOFhgb == HhStEfcVVlMiBjgWdCLXZvzOFhgb)
			{
				goto IL_000e;
			}
			if (lCNqQoAApxuECSfGdHgIftxqKOX != P_0.lCNqQoAApxuECSfGdHgIftxqKOX)
			{
				return 0;
			}
			if (oGcycOAqtFGbygaGhDMChNbBqYZn != P_0.oGcycOAqtFGbygaGhDMChNbBqYZn)
			{
				return 0;
			}
			if (VRaBaRJBhrkeRbpjPHxbMRTvGos != P_0.VRaBaRJBhrkeRbpjPHxbMRTvGos)
			{
				return 0;
			}
			if (P_0.qYoawwlzgWjKYCaKkjvoociYFuT == qYoawwlzgWjKYCaKkjvoociYFuT)
			{
				return 2;
			}
			int num;
			if (P_0.IerddSLNXqqcFfmPgxIqNDWuwNi == IerddSLNXqqcFfmPgxIqNDWuwNi)
			{
				num = -1326372612;
				goto IL_0013;
			}
			return 0;
			IL_000e:
			num = -1326372609;
			goto IL_0013;
			IL_0013:
			switch (num ^ -1326372611)
			{
			case 0:
				break;
			case 2:
				return 2;
			default:
				return 1;
			}
			goto IL_000e;
		}

		private BridgedControllerHWInfo NGITJKBCUwztnLMkPBVweIvQEACZ()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			eaqBkFPxlFldmaTQruLSPLTaGpDi(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			eaqBkFPxlFldmaTQruLSPLTaGpDi(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(HhStEfcVVlMiBjgWdCLXZvzOFhgb);
		}

		private void UDEtzvxqREkxyopZfQhiKhodhQPJ()
		{
			if (wXeJUZjIVNWqHFFJQtwFIYdCqUi <= 0)
			{
				goto IL_0009;
			}
			goto IL_0067;
			IL_0009:
			int num = -1514453019;
			goto IL_000e;
			IL_000e:
			HardwareJoystickMap.Platform_SDL2_Base.Axis[] axes_orig = default(HardwareJoystickMap.Platform_SDL2_Base.Axis[]);
			HardwareJoystickMap.Platform_SDL2_Base platform_SDL2_Base = default(HardwareJoystickMap.Platform_SDL2_Base);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1514453024)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					goto IL_003e;
				case 2:
					axes_orig = platform_SDL2_Base.Axes_orig;
					if (axes_orig == null)
					{
						return;
					}
					goto case 6;
				case 4:
					goto IL_0067;
				case 7:
					RDGcyJEKLdGmisvSfFIubiDzvPI(axes_orig[num2], num2);
					num2++;
					num = -1514453023;
					continue;
				case 6:
					num2 = 0;
					num = -1514453023;
					continue;
				case 5:
					return;
				case 3:
					return;
				}
				break;
				IL_003e:
				int num3;
				if (num2 >= axes_orig.Length)
				{
					num = -1514453021;
					num3 = num;
				}
				else
				{
					num = -1514453017;
					num3 = num;
				}
			}
			goto IL_0009;
			IL_0067:
			InputPlatform platform = REZiFujnwfIcWniRKvMxDxhPHlx.map.platform;
			if (platform == InputPlatform.hzbbqXbtQbxKAebJVOPUbWKsXBI)
			{
				platform_SDL2_Base = (HardwareJoystickMap.Platform_SDL2_Base)REZiFujnwfIcWniRKvMxDxhPHlx.map;
				num = -1514453022;
				goto IL_000e;
			}
		}

		private void nLotdmIEnGDlRjnDZLzPFXYmCSSJ()
		{
			if (bOvCrfWoeojdEksYxLnTCSWDiEj <= 0)
			{
				return;
			}
			while (true)
			{
				HardwareJoystickMap.Platform_SDL2_Base platform_SDL2_Base = (HardwareJoystickMap.Platform_SDL2_Base)REZiFujnwfIcWniRKvMxDxhPHlx.map;
				HardwareJoystickMap.Platform_SDL2_Base.Button[] buttons_orig = platform_SDL2_Base.Buttons_orig;
				if (buttons_orig == null)
				{
					break;
				}
				while (true)
				{
					int num = 0;
					int num2 = 1164610004;
					while (true)
					{
						switch (num2 ^ 0x456A89D6)
						{
						case 0:
							num2 = 1164610005;
							continue;
						default:
							return;
						case 2:
							break;
						case 5:
							XEBoZwZUbCbuBBLgMpjExCGAPlU(buttons_orig[num], num);
							num++;
							num2 = 1164610004;
							continue;
						case 4:
							goto end_IL_000f;
						case 3:
							goto end_IL_0060;
						case 1:
							return;
						}
						int num3;
						if (num >= buttons_orig.Length)
						{
							num2 = 1164610007;
							num3 = num2;
						}
						else
						{
							num2 = 1164610003;
							num3 = num2;
						}
						continue;
						end_IL_000f:
						break;
					}
					continue;
					end_IL_0060:
					break;
				}
			}
		}

		private void RDGcyJEKLdGmisvSfFIubiDzvPI(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0, int P_1)
		{
			if (P_1 >= wXeJUZjIVNWqHFFJQtwFIYdCqUi)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			JzCpTyTcKdiDVvPxFKAbxEFLDAw[P_1] = QEVsojLqDtQsxnvxgHocZSixiJS(P_0);
		}

		private void XEBoZwZUbCbuBBLgMpjExCGAPlU(HardwareJoystickMap.Platform_SDL2_Base.Button P_0, int P_1)
		{
			if (P_1 >= bOvCrfWoeojdEksYxLnTCSWDiEj)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			while (true)
			{
				vEmeiLseeiFjOBSerAJjqspjZBa[P_1] = oKAKkOrHJCSQdjvqMprroEgDqcJ(P_0);
				int num = 49154585;
				while (true)
				{
					switch (num ^ 0x2EE0A18)
					{
					case 0:
						goto IL_0014;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0014:
					num = 49154586;
				}
			}
		}

		private float QEVsojLqDtQsxnvxgHocZSixiJS(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				goto IL_000c;
			}
			int num;
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				num = -270932385;
			}
			else
			{
				if (P_0.sourceType != HardwareElementSourceTypeWithHat.Hat)
				{
					return 0f;
				}
				num = -270932399;
			}
			goto IL_0011;
			IL_0011:
			float result = default(float);
			int sourceButton = default(int);
			float num2 = default(float);
			int num4 = default(int);
			while (true)
			{
				switch (num ^ -270932395)
				{
				case 14:
					break;
				case 5:
					return 0f;
				case 1:
					result = 1f;
					num = -270932387;
					continue;
				case 6:
				{
					int num6;
					if (sourceButton >= oGcycOAqtFGbygaGhDMChNbBqYZn)
					{
						num = -270932394;
						num6 = num;
					}
					else
					{
						num = -270932388;
						num6 = num;
					}
					continue;
				}
				case 0:
					return 0f;
				case 3:
					return 0f;
				case 16:
					num2 = xYBenQEWAOxQXoKtmsZBfrUpyms(num4, AxisDirection.Horizontal);
					num = -270932390;
					continue;
				case 4:
				{
					int sourceHat = P_0.sourceHat;
					if (sourceHat >= 0 && sourceHat < VRaBaRJBhrkeRbpjPHxbMRTvGos)
					{
						if (sourceHat < 4)
						{
							num4 = BOANwqncOLYXWURmWjkyMSRMEGQ.FSxgkyMKKKphcbSZaWyIXvowzkQ(sourceHat);
							if (num4 < 0)
							{
								return 0f;
							}
							if (P_0.sourceHatDirection == AxisDirection.Horizontal)
							{
								num = -270932411;
								continue;
							}
							num2 = xYBenQEWAOxQXoKtmsZBfrUpyms(num4, AxisDirection.Vertical);
							num = -270932386;
						}
						else
						{
							num = -270932400;
						}
						continue;
					}
					goto case 5;
				}
				case 2:
				{
					int num5;
					if (sourceButton < 0)
					{
						num = -270932394;
						num5 = num;
					}
					else
					{
						num = -270932397;
						num5 = num;
					}
					continue;
				}
				case 13:
				{
					int sourceAxis = P_0.sourceAxis;
					if (sourceAxis >= 0 && sourceAxis < lCNqQoAApxuECSfGdHgIftxqKOX)
					{
						if (sourceAxis < 56)
						{
							return BOANwqncOLYXWURmWjkyMSRMEGQ.QEVsojLqDtQsxnvxgHocZSixiJS(sourceAxis);
						}
						num = -270932395;
						continue;
					}
					goto case 0;
				}
				case 10:
					sourceButton = P_0.sourceButton;
					num = -270932393;
					continue;
				case 9:
					if (sourceButton < 256)
					{
						if (!BOANwqncOLYXWURmWjkyMSRMEGQ.oKAKkOrHJCSQdjvqMprroEgDqcJ(sourceButton))
						{
							return 0f;
						}
						int num3;
						if (P_0.buttonAxisContribution == Pole.Positive)
						{
							num = -270932396;
							num3 = num;
						}
						else
						{
							num = -270932391;
							num3 = num;
						}
					}
					else
					{
						num = -270932394;
					}
					continue;
				case 11:
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
					goto IL_0205;
				case 8:
					return result;
				case 12:
					result = -1f;
					num = -270932387;
					continue;
				case 15:
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
					goto IL_0205;
				default:
					{
						return num2;
					}
					IL_0205:
					if (P_0.invert)
					{
						num2 *= -1f;
						num = -270932398;
						continue;
					}
					goto default;
				}
				break;
			}
			goto IL_000c;
			IL_000c:
			num = -270932392;
			goto IL_0011;
		}

		private bool oKAKkOrHJCSQdjvqMprroEgDqcJ(HardwareJoystickMap.Platform_SDL2_Base.Button P_0)
		{
			int num = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (!P_0.ignoreIfButtonsActive)
				{
					goto IL_0073;
				}
				num = 0;
				goto IL_014a;
			}
			int sourceHat = default(int);
			int num2;
			if (P_0.sourceType != HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceType != HardwareElementSourceTypeWithHat.Hat)
				{
					goto IL_0358;
				}
				sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= VRaBaRJBhrkeRbpjPHxbMRTvGos)
				{
					goto IL_0225;
				}
				if (sourceHat < 4)
				{
					switch (P_0.sourceHatDirection)
					{
					case HatDirection.Up:
						break;
					case HatDirection.UpRight:
						return ylJyLQdWMCxpSRgrlagamGDaAuA(BOANwqncOLYXWURmWjkyMSRMEGQ.FSxgkyMKKKphcbSZaWyIXvowzkQ(sourceHat), 1, P_0.sourceHatType);
					case HatDirection.Right:
						return ylJyLQdWMCxpSRgrlagamGDaAuA(BOANwqncOLYXWURmWjkyMSRMEGQ.FSxgkyMKKKphcbSZaWyIXvowzkQ(sourceHat), 2, P_0.sourceHatType);
					case HatDirection.DownRight:
						return ylJyLQdWMCxpSRgrlagamGDaAuA(BOANwqncOLYXWURmWjkyMSRMEGQ.FSxgkyMKKKphcbSZaWyIXvowzkQ(sourceHat), 3, P_0.sourceHatType);
					case HatDirection.Down:
						return ylJyLQdWMCxpSRgrlagamGDaAuA(BOANwqncOLYXWURmWjkyMSRMEGQ.FSxgkyMKKKphcbSZaWyIXvowzkQ(sourceHat), 4, P_0.sourceHatType);
					case HatDirection.DownLeft:
						return ylJyLQdWMCxpSRgrlagamGDaAuA(BOANwqncOLYXWURmWjkyMSRMEGQ.FSxgkyMKKKphcbSZaWyIXvowzkQ(sourceHat), 5, P_0.sourceHatType);
					case HatDirection.Left:
						return ylJyLQdWMCxpSRgrlagamGDaAuA(BOANwqncOLYXWURmWjkyMSRMEGQ.FSxgkyMKKKphcbSZaWyIXvowzkQ(sourceHat), 6, P_0.sourceHatType);
					case HatDirection.UpLeft:
						return ylJyLQdWMCxpSRgrlagamGDaAuA(BOANwqncOLYXWURmWjkyMSRMEGQ.FSxgkyMKKKphcbSZaWyIXvowzkQ(sourceHat), 7, P_0.sourceHatType);
					default:
						goto IL_0358;
					}
					goto IL_0280;
				}
				num2 = 469186300;
			}
			else
			{
				num2 = 469186292;
			}
			goto IL_001f;
			IL_014a:
			int num3;
			if (num >= P_0.ignoreIfButtonsActiveButtons.Length)
			{
				num2 = 469186299;
				num3 = num2;
			}
			else
			{
				num2 = 469186289;
				num3 = num2;
			}
			goto IL_001f;
			IL_0280:
			return ylJyLQdWMCxpSRgrlagamGDaAuA(BOANwqncOLYXWURmWjkyMSRMEGQ.FSxgkyMKKKphcbSZaWyIXvowzkQ(sourceHat), 0, P_0.sourceHatType);
			IL_017e:
			bool flag = default(bool);
			if (flag)
			{
				return true;
			}
			return false;
			IL_0358:
			return false;
			IL_0225:
			return false;
			IL_0073:
			int num4 = default(int);
			int sourceButton = default(int);
			if (P_0.requireMultipleButtons)
			{
				flag = false;
				num4 = 0;
				num2 = 469186291;
			}
			else
			{
				sourceButton = P_0.sourceButton;
				num2 = 469186294;
			}
			goto IL_001f;
			IL_001f:
			float num5 = default(float);
			while (true)
			{
				int sourceAxis;
				switch (num2 ^ 0x1BF736F4)
				{
				case 10:
					num2 = 469186289;
					continue;
				case 15:
					break;
				case 16:
					return false;
				case 6:
					goto IL_00d3;
				case 1:
					return false;
				case 4:
					return false;
				case 5:
					goto IL_0125;
				case 13:
					goto IL_014a;
				case 7:
					num2 = 469186298;
					continue;
				case 14:
					goto IL_0173;
				case 11:
					goto IL_0196;
				case 12:
					goto IL_01ac;
				case 0:
					sourceAxis = P_0.sourceAxis;
					if (sourceAxis > 0 && sourceAxis < lCNqQoAApxuECSfGdHgIftxqKOX)
					{
						goto IL_01ed;
					}
					goto case 9;
				case 2:
					if (sourceButton < 0 || sourceButton >= oGcycOAqtFGbygaGhDMChNbBqYZn)
					{
						goto case 1;
					}
					goto IL_0210;
				case 8:
					goto IL_0225;
				case 9:
					return false;
				default:
					goto IL_0280;
				}
				break;
				IL_0210:
				if (sourceButton < 256)
				{
					return BOANwqncOLYXWURmWjkyMSRMEGQ.oKAKkOrHJCSQdjvqMprroEgDqcJ(sourceButton);
				}
				num2 = 469186293;
				continue;
				IL_00d3:
				if (MathTools.Abs(num5) <= P_0.axisDeadZone)
				{
					num2 = 469186288;
					continue;
				}
				if (P_0.sourceAxisPole != Pole.Positive)
				{
					if (num5 > 0f)
					{
						return false;
					}
					goto IL_0096;
				}
				num2 = 469186303;
				continue;
				IL_0096:
				return true;
				IL_01ed:
				if (sourceAxis >= 56)
				{
					num2 = 469186301;
					continue;
				}
				num5 = BOANwqncOLYXWURmWjkyMSRMEGQ.QEVsojLqDtQsxnvxgHocZSixiJS(sourceAxis);
				num2 = 469186290;
				continue;
				IL_0173:
				if (num4 >= P_0.requiredButtons.Length)
				{
					goto IL_017e;
				}
				goto IL_01ac;
				IL_01ac:
				if (!BOANwqncOLYXWURmWjkyMSRMEGQ.oKAKkOrHJCSQdjvqMprroEgDqcJ(P_0.requiredButtons[num4]))
				{
					return false;
				}
				flag = true;
				num4++;
				num2 = 469186298;
				continue;
				IL_0196:
				if (num5 < 0f)
				{
					num2 = 469186276;
					continue;
				}
				goto IL_0096;
				IL_0125:
				if (BOANwqncOLYXWURmWjkyMSRMEGQ.oKAKkOrHJCSQdjvqMprroEgDqcJ(P_0.ignoreIfButtonsActiveButtons[num]))
				{
					return false;
				}
				num++;
				num2 = 469186297;
			}
			goto IL_0073;
		}

		private bool ylJyLQdWMCxpSRgrlagamGDaAuA(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (REZiFujnwfIcWniRKvMxDxhPHlx.isUnknownController)
			{
				goto IL_0016;
			}
			goto IL_00d2;
			IL_00d2:
			int num = 4500;
			int num2 = -122373417;
			goto IL_001b;
			IL_0016:
			num2 = -122373423;
			goto IL_001b;
			IL_001b:
			int num4 = default(int);
			int num3 = default(int);
			int num6 = default(int);
			while (true)
			{
				switch (num2 ^ -122373424)
				{
				case 4:
					break;
				case 5:
					goto IL_005b;
				case 0:
					goto IL_006a;
				case 11:
					goto IL_007a;
				case 3:
					return false;
				case 10:
					num2 = -122373416;
					continue;
				case 6:
					goto IL_00b0;
				case 1:
					goto IL_00c6;
				case 2:
					if (P_0 > num4)
					{
						P_0 -= 36000;
						num2 = -122373424;
						continue;
					}
					goto IL_006a;
				case 7:
					num3 = num * P_1;
					num2 = -122373419;
					continue;
				case 8:
					goto IL_0107;
				default:
					return true;
				}
				break;
				IL_0107:
				int num5;
				if (P_1 != 0)
				{
					num2 = -122373424;
					num5 = num2;
				}
				else
				{
					num2 = -122373422;
					num5 = num2;
				}
				continue;
				IL_00b0:
				num4 = 27000;
				num6 = 9000;
				num2 = -122373416;
				continue;
				IL_0120:
				return false;
				IL_007a:
				if (P_0 > num3 - num6)
				{
					num2 = -122373415;
					continue;
				}
				goto IL_0120;
				IL_005b:
				if (P_2 == HatType.EightWay && P_0 != num3)
				{
					num2 = -122373421;
					continue;
				}
				if (P_2 == HatType.EightWay)
				{
					num4 = 31500;
					num6 = 4500;
					num2 = -122373414;
					continue;
				}
				goto IL_00b0;
				IL_006a:
				if (P_0 < num3 + num6)
				{
					num2 = -122373413;
					continue;
				}
				goto IL_0120;
			}
			goto IL_0016;
			IL_00c6:
			if (!InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return false;
			}
			goto IL_00d2;
		}

		private float xYBenQEWAOxQXoKtmsZBfrUpyms(int P_0, AxisDirection P_1)
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

		private ControlDeviceType SIGuCBLfKJuUsfwDCwrnIpJwoPu(PqXIqBGoIivkjpVVhKhHIXloIJf P_0)
		{
			if (P_0 == PqXIqBGoIivkjpVVhKhHIXloIJf.etApNsmaydFifFQZNkCXGYFhvYDz)
			{
				goto IL_0003;
			}
			if (P_0 == PqXIqBGoIivkjpVVhKhHIXloIJf.rlDBEAevYUudHNlWSHcStzDSfSse)
			{
				return ControlDeviceType.rlDBEAevYUudHNlWSHcStzDSfSse;
			}
			if (P_0 == PqXIqBGoIivkjpVVhKhHIXloIJf.rCRUfGMYcabNQcwJmpNrFXaJmFK)
			{
				return ControlDeviceType.rCRUfGMYcabNQcwJmpNrFXaJmFK;
			}
			int num;
			if (P_0 == PqXIqBGoIivkjpVVhKhHIXloIJf.ONOENoDqLOAvQwxgTsKnLgJYNZAF)
			{
				num = 904128792;
				goto IL_0008;
			}
			return ControlDeviceType.mWddvsAGGdWECRlxCOhehpBItyh;
			IL_0008:
			switch (num ^ 0x35E3E918)
			{
			case 2:
				break;
			case 1:
				return ControlDeviceType.etApNsmaydFifFQZNkCXGYFhvYDz;
			default:
				return ControlDeviceType.ONOENoDqLOAvQwxgTsKnLgJYNZAF;
			}
			goto IL_0003;
			IL_0003:
			num = 904128793;
			goto IL_0008;
		}

		private void XxHELBuvCCtGAJntxYQUzFBhOFy()
		{
			REZiFujnwfIcWniRKvMxDxhPHlx = dUeoOAWeqXvgKLTHqOAcuSQkGJiK(NGITJKBCUwztnLMkPBVweIvQEACZ());
			while (true)
			{
				int num = -602809596;
				while (true)
				{
					switch (num ^ -602809593)
					{
					case 4:
						break;
					default:
						return;
					case 3:
					{
						int num2;
						if (REZiFujnwfIcWniRKvMxDxhPHlx == null)
						{
							num = -602809598;
							num2 = num;
						}
						else
						{
							num = -602809594;
							num2 = num;
						}
						continue;
					}
					case 5:
						Logger.LogError("Default hardware map not found!");
						return;
					case 2:
						wXeJUZjIVNWqHFFJQtwFIYdCqUi = REZiFujnwfIcWniRKvMxDxhPHlx.axisCount;
						bOvCrfWoeojdEksYxLnTCSWDiEj = REZiFujnwfIcWniRKvMxDxhPHlx.buttonCount;
						num = -602809593;
						continue;
					case 1:
						if (REZiFujnwfIcWniRKvMxDxhPHlx.useSystemName && !string.IsNullOrEmpty(IifBwgifDjJLQbtRWmfjwrERSUof))
						{
							string text = Regex.Replace(IifBwgifDjJLQbtRWmfjwrERSUof, "\\s+", " ");
							text = text.Trim();
							if (!string.IsNullOrEmpty(text))
							{
								REZiFujnwfIcWniRKvMxDxhPHlx.controllerName = text;
								num = -602809595;
								continue;
							}
						}
						goto case 2;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private string ZXITDkkHfUBfDdvzMISiUmuRJXG()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{BOANwqncOLYXWURmWjkyMSRMEGQ.InputSource}{FBYkTRckLemSakYJQMtfxOSmUPg}{fkLtKGzJsvTUqlGdRyYQcjTaPmb}{LjGpBwDvaZYnRpwgjlueNWucAwo.ToProductGuid()}");
		}

		private void eaqBkFPxlFldmaTQruLSPLTaGpDi(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.SDL2;
			P_0.inputSource = BOANwqncOLYXWURmWjkyMSRMEGQ.InputSource;
			P_0.deviceType = SIGuCBLfKJuUsfwDCwrnIpJwoPu(SkCcAXgfijscHdWxkWFsSHOZWErK);
			P_0.hardwareIdentifier = ZXITDkkHfUBfDdvzMISiUmuRJXG();
			P_0.hardwareAxisCount = lCNqQoAApxuECSfGdHgIftxqKOX;
			P_0.hardwareButtonCount = oGcycOAqtFGbygaGhDMChNbBqYZn;
			P_0.hardwareHatCount = VRaBaRJBhrkeRbpjPHxbMRTvGos;
			while (true)
			{
				int num = 1339377706;
				while (true)
				{
					switch (num ^ 0x4FD5482B)
					{
					case 0:
						break;
					case 1:
						goto IL_0079;
					default:
						P_0.hw_pidVid = LjGpBwDvaZYnRpwgjlueNWucAwo;
						P_0.hw_isBluetoothDevice = XOcpUHIIBydiGZIoNLAeVYoWsBq;
						P_0.hw_bluetoothDeviceName = FBYkTRckLemSakYJQMtfxOSmUPg;
						P_0.hw_systemDeviceName = FBYkTRckLemSakYJQMtfxOSmUPg;
						P_0.hw_supportsVibration = gkkruTywtCSgfaMjHfnJvKIxFVy;
						P_0.hw_isSDL2Gamepad = BOANwqncOLYXWURmWjkyMSRMEGQ.DeviceType == PqXIqBGoIivkjpVVhKhHIXloIJf.rlDBEAevYUudHNlWSHcStzDSfSse;
						P_0.hw_localVibrationMotorCount = hSqMknHvfLaCaSKUtNrDJWiYQVX;
						return;
					}
					break;
					IL_0079:
					P_0.hw_productName = FBYkTRckLemSakYJQMtfxOSmUPg;
					P_0.hw_deviceGuid = qYoawwlzgWjKYCaKkjvoociYFuT;
					P_0.hw_productId = fkLtKGzJsvTUqlGdRyYQcjTaPmb;
					num = 1339377705;
				}
			}
		}

		private void eaqBkFPxlFldmaTQruLSPLTaGpDi(BridgedController P_0)
		{
			eaqBkFPxlFldmaTQruLSPLTaGpDi((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = REZiFujnwfIcWniRKvMxDxhPHlx.ToGameHardwareControllerMap();
			P_0.instanceName = FBYkTRckLemSakYJQMtfxOSmUPg;
			P_0.productName = FBYkTRckLemSakYJQMtfxOSmUPg;
			while (true)
			{
				int num = 1226300578;
				while (true)
				{
					switch (num ^ 0x4917DCA0)
					{
					case 0:
						break;
					case 2:
						P_0.axisCount = wXeJUZjIVNWqHFFJQtwFIYdCqUi;
						P_0.buttonCount = bOvCrfWoeojdEksYxLnTCSWDiEj;
						num = 1226300577;
						continue;
					case 1:
						P_0.unknownControllerHats = RDMLhalQuBPElLAmqzqfJpjuvBn();
						P_0.controllerTypeGuid = NdHHxuQRnYAiYXlkbCSlISGovAq;
						num = 1226300579;
						continue;
					default:
						P_0.controllerExtension = extension;
						return;
					}
					break;
				}
			}
		}

		private void CkcLhseIWKxjephSBAjLOUYMCyM()
		{
			int num = 0;
			int num2 = default(int);
			while (true)
			{
				IL_007f:
				int num3;
				if (num >= bOvCrfWoeojdEksYxLnTCSWDiEj)
				{
					num2 = 0;
					num3 = -1061657614;
					goto IL_0009;
				}
				goto IL_006b;
				IL_0009:
				while (true)
				{
					switch (num3 ^ -1061657613)
					{
					case 5:
						num3 = -1061657609;
						continue;
					default:
						return;
					case 1:
						num3 = -1061657611;
						continue;
					case 6:
						break;
					case 3:
						JzCpTyTcKdiDVvPxFKAbxEFLDAw[num2] = 0f;
						num2++;
						num3 = -1061657611;
						continue;
					case 4:
						goto end_IL_0009;
					case 2:
						goto IL_007f;
					case 0:
						return;
					}
					int num4;
					if (num2 >= wXeJUZjIVNWqHFFJQtwFIYdCqUi)
					{
						num3 = -1061657613;
						num4 = num3;
					}
					else
					{
						num3 = -1061657616;
						num4 = num3;
					}
					continue;
					end_IL_0009:
					break;
				}
				goto IL_006b;
				IL_006b:
				vEmeiLseeiFjOBSerAJjqspjZBa[num] = false;
				num++;
				num3 = -1061657615;
				goto IL_0009;
			}
		}

		private UnknownControllerHat[] RDMLhalQuBPElLAmqzqfJpjuvBn()
		{
			if (!yvNsRHUPPyTccyoavGrrgtIginfh)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			int num = 0;
			while (num < 2)
			{
				while (true)
				{
					int num2 = 128 + num * 8;
					int[] array2 = new int[8];
					int num3 = -589693305;
					while (true)
					{
						switch (num3 ^ -589693306)
						{
						case 6:
							num3 = -589693307;
							continue;
						case 0:
							array2[4] = num2 + 4;
							num3 = -589693309;
							continue;
						case 1:
							array2[0] = num2;
							array2[1] = num2 + 1;
							num3 = -589693310;
							continue;
						case 5:
							array2[5] = num2 + 5;
							array2[6] = num2 + 6;
							array2[7] = num2 + 7;
							num3 = -589693308;
							continue;
						case 2:
						{
							UnknownControllerHat.HatButtons buttons = new UnknownControllerHat.HatButtons(array2);
							array[num] = new UnknownControllerHat(buttons);
							num++;
							num3 = -589693311;
							continue;
						}
						case 8:
							array2[3] = num2 + 3;
							num3 = -589693306;
							continue;
						case 3:
							break;
						case 4:
							array2[2] = num2 + 2;
							num3 = -589693298;
							continue;
						default:
							goto end_IL_00be;
						}
						break;
					}
					continue;
					end_IL_00be:
					break;
				}
			}
			return array;
		}

		public static int EOGdSkGkOKCvaGaRDrqjdrmHsdXG(ptMebSqXEoBzBEOaTPyqDqsEryl P_0, ptMebSqXEoBzBEOaTPyqDqsEryl P_1)
		{
			if (P_0.SVlrBPWDEySKVHcSUJitCfBSxnO < P_1.SVlrBPWDEySKVHcSUJitCfBSxnO)
			{
				return -1;
			}
			if (P_0.SVlrBPWDEySKVHcSUJitCfBSxnO > P_1.SVlrBPWDEySKVHcSUJitCfBSxnO)
			{
				return 1;
			}
			return 0;
		}

		public static int CNuzoMNyAiMHEtbpITTXVchrvxa(ptMebSqXEoBzBEOaTPyqDqsEryl P_0, ptMebSqXEoBzBEOaTPyqDqsEryl P_1)
		{
			if (P_0.ezQswNZyAXdiNHmgSaQroyfOVDk < P_1.ezQswNZyAXdiNHmgSaQroyfOVDk)
			{
				return -1;
			}
			if (P_0.ezQswNZyAXdiNHmgSaQroyfOVDk > P_1.ezQswNZyAXdiNHmgSaQroyfOVDk)
			{
				return 1;
			}
			return 0;
		}
	}

	private class dogFaTSPlllVfZoyaXxTFOdHiiU
	{
		public enum qHZDSIBhYQrndecePjMaNcAbECWD
		{
			zlJMCEeCIoRemLBsAgqNdRDgziDK = 0,
			BKFaaxAPcuBcJAcYJSBDkcEuaeHB = 1
		}

		public class XoLgRBGAfYsgfubmIhiiCvSilmyZ
		{
			public int UKCDHORBCFHBoYLTIFGoDfJwMEGs;

			public Guid MAoxEuNsNkUjTLSDghmOoJgBmws;

			public Guid IerddSLNXqqcFfmPgxIqNDWuwNi;

			public int MrgFvxEmVvleAtwmEJiJFGTJUZgS;

			public int lCNqQoAApxuECSfGdHgIftxqKOX;

			public int oGcycOAqtFGbygaGhDMChNbBqYZn;

			public int VRaBaRJBhrkeRbpjPHxbMRTvGos;

			public bool YfzaYuFFeAGpZYIlhOCKodCcBwd(ptMebSqXEoBzBEOaTPyqDqsEryl P_0, qHZDSIBhYQrndecePjMaNcAbECWD P_1)
			{
				if (P_0.rewiredId == UKCDHORBCFHBoYLTIFGoDfJwMEGs)
				{
					return true;
				}
				if (lCNqQoAApxuECSfGdHgIftxqKOX != P_0.lCNqQoAApxuECSfGdHgIftxqKOX)
				{
					return false;
				}
				if (oGcycOAqtFGbygaGhDMChNbBqYZn != P_0.oGcycOAqtFGbygaGhDMChNbBqYZn)
				{
					return false;
				}
				if (VRaBaRJBhrkeRbpjPHxbMRTvGos != P_0.VRaBaRJBhrkeRbpjPHxbMRTvGos)
				{
					return false;
				}
				switch (P_1)
				{
				case qHZDSIBhYQrndecePjMaNcAbECWD.zlJMCEeCIoRemLBsAgqNdRDgziDK:
					return MAoxEuNsNkUjTLSDghmOoJgBmws == P_0.qYoawwlzgWjKYCaKkjvoociYFuT;
				case qHZDSIBhYQrndecePjMaNcAbECWD.BKFaaxAPcuBcJAcYJSBDkcEuaeHB:
					return IerddSLNXqqcFfmPgxIqNDWuwNi == P_0.IerddSLNXqqcFfmPgxIqNDWuwNi;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class yQuzKmAFIloIVtnZxnSwwxqWNrw : IDisposable, IEnumerator, IEnumerable, IEnumerable<XoLgRBGAfYsgfubmIhiiCvSilmyZ>, IEnumerator<XoLgRBGAfYsgfubmIhiiCvSilmyZ>
		{
			private XoLgRBGAfYsgfubmIhiiCvSilmyZ ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public dogFaTSPlllVfZoyaXxTFOdHiiU syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public ptMebSqXEoBzBEOaTPyqDqsEryl GHCGdCDbjrofHQLylQoSJOXGrsCj;

			public ptMebSqXEoBzBEOaTPyqDqsEryl kBIDOXdTvkXDGsXBIDEoXEkSifNc;

			public qHZDSIBhYQrndecePjMaNcAbECWD deDQMJLHHfbmUIovbnujIcUjOUK;

			public qHZDSIBhYQrndecePjMaNcAbECWD DjGvqohErCEFaeFNfFegiWUXHde;

			public int tJWBKFXVQoaBvNgXagHdWqffeeO;

			public int WhgwdOUlEIMyBTjrFhGbNEbNklB;

			XoLgRBGAfYsgfubmIhiiCvSilmyZ IEnumerator<XoLgRBGAfYsgfubmIhiiCvSilmyZ>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<XoLgRBGAfYsgfubmIhiiCvSilmyZ> IEnumerable<XoLgRBGAfYsgfubmIhiiCvSilmyZ>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
				{
					goto IL_0012;
				}
				goto IL_0069;
				IL_0012:
				int num = -976807803;
				goto IL_0017;
				IL_0017:
				yQuzKmAFIloIVtnZxnSwwxqWNrw yQuzKmAFIloIVtnZxnSwwxqWNrw2 = default(yQuzKmAFIloIVtnZxnSwwxqWNrw);
				while (true)
				{
					switch (num ^ -976807804)
					{
					case 3:
						break;
					case 1:
						if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							yQuzKmAFIloIVtnZxnSwwxqWNrw2 = this;
							num = -976807808;
							continue;
						}
						goto IL_0069;
					case 0:
						yQuzKmAFIloIVtnZxnSwwxqWNrw2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -976807808;
						continue;
					case 5:
						goto IL_0069;
					case 4:
						yQuzKmAFIloIVtnZxnSwwxqWNrw2.GHCGdCDbjrofHQLylQoSJOXGrsCj = kBIDOXdTvkXDGsXBIDEoXEkSifNc;
						num = -976807802;
						continue;
					default:
						yQuzKmAFIloIVtnZxnSwwxqWNrw2.deDQMJLHHfbmUIovbnujIcUjOUK = DjGvqohErCEFaeFNfFegiWUXHde;
						return yQuzKmAFIloIVtnZxnSwwxqWNrw2;
					}
					break;
				}
				goto IL_0012;
				IL_0069:
				yQuzKmAFIloIVtnZxnSwwxqWNrw2 = new yQuzKmAFIloIVtnZxnSwwxqWNrw(0);
				num = -976807804;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<XoLgRBGAfYsgfubmIhiiCvSilmyZ>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
				while (true)
				{
					int num2 = -1720965159;
					while (true)
					{
						switch (num2 ^ -1720965156)
						{
						case 4:
							break;
						case 0:
						{
							int num3;
							if (WhgwdOUlEIMyBTjrFhGbNEbNklB < tJWBKFXVQoaBvNgXagHdWqffeeO)
							{
								num2 = -1720965158;
								num3 = num2;
							}
							else
							{
								num2 = -1720965157;
								num3 = num2;
							}
							continue;
						}
						case 6:
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.pYylSnaZhhHPlmcssGUseHaIflO[WhgwdOUlEIMyBTjrFhGbNEbNklB].YfzaYuFFeAGpZYIlhOCKodCcBwd(GHCGdCDbjrofHQLylQoSJOXGrsCj, deDQMJLHHfbmUIovbnujIcUjOUK))
							{
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.pYylSnaZhhHPlmcssGUseHaIflO[WhgwdOUlEIMyBTjrFhGbNEbNklB];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							}
							goto case 2;
						case 1:
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							num2 = -1720965153;
							continue;
						case 3:
							tJWBKFXVQoaBvNgXagHdWqffeeO = syCPfFbHYMDOvEPjTnPLBqiOhsPv.pYylSnaZhhHPlmcssGUseHaIflO.Count;
							WhgwdOUlEIMyBTjrFhGbNEbNklB = 0;
							num2 = -1720965156;
							continue;
						case 2:
							WhgwdOUlEIMyBTjrFhGbNEbNklB++;
							num2 = -1720965156;
							continue;
						case 5:
							switch (num)
							{
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = -1720965154;
								continue;
							case 0:
								break;
							default:
								num2 = -1720965157;
								continue;
							}
							goto case 1;
						default:
							return false;
						}
						break;
					}
				}
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
			public yQuzKmAFIloIVtnZxnSwwxqWNrw(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private List<XoLgRBGAfYsgfubmIhiiCvSilmyZ> pYylSnaZhhHPlmcssGUseHaIflO;

		public dogFaTSPlllVfZoyaXxTFOdHiiU()
		{
			pYylSnaZhhHPlmcssGUseHaIflO = new List<XoLgRBGAfYsgfubmIhiiCvSilmyZ>();
		}

		public void tXgmibXCLFITLeBlRtsWPalapKpT(ptMebSqXEoBzBEOaTPyqDqsEryl P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int num2 = default(int);
			while (true)
			{
				int count = pYylSnaZhhHPlmcssGUseHaIflO.Count;
				int num = -1258510020;
				while (true)
				{
					switch (num ^ -1258510018)
					{
					case 6:
						num = -1258510021;
						continue;
					case 0:
						if (pYylSnaZhhHPlmcssGUseHaIflO[num2].YfzaYuFFeAGpZYIlhOCKodCcBwd(P_0, qHZDSIBhYQrndecePjMaNcAbECWD.zlJMCEeCIoRemLBsAgqNdRDgziDK))
						{
							pYylSnaZhhHPlmcssGUseHaIflO[num2].UKCDHORBCFHBoYLTIFGoDfJwMEGs = P_0.rewiredId;
							pYylSnaZhhHPlmcssGUseHaIflO[num2].MAoxEuNsNkUjTLSDghmOoJgBmws = P_0.qYoawwlzgWjKYCaKkjvoociYFuT;
							pYylSnaZhhHPlmcssGUseHaIflO[num2].IerddSLNXqqcFfmPgxIqNDWuwNi = P_0.IerddSLNXqqcFfmPgxIqNDWuwNi;
							pYylSnaZhhHPlmcssGUseHaIflO[num2].MrgFvxEmVvleAtwmEJiJFGTJUZgS = P_0.inputManagerId;
							pYylSnaZhhHPlmcssGUseHaIflO[num2].lCNqQoAApxuECSfGdHgIftxqKOX = P_0.lCNqQoAApxuECSfGdHgIftxqKOX;
							pYylSnaZhhHPlmcssGUseHaIflO[num2].oGcycOAqtFGbygaGhDMChNbBqYZn = P_0.oGcycOAqtFGbygaGhDMChNbBqYZn;
							num = -1258510019;
							continue;
						}
						goto case 1;
					case 1:
						num2++;
						num = -1258510022;
						continue;
					case 5:
						break;
					case 2:
						num2 = 0;
						num = -1258510022;
						continue;
					case 3:
						pYylSnaZhhHPlmcssGUseHaIflO[num2].VRaBaRJBhrkeRbpjPHxbMRTvGos = P_0.VRaBaRJBhrkeRbpjPHxbMRTvGos;
						DEiihYzBOuDCWDVSMxebepjOOeX(P_0.rewiredId, P_0.qYoawwlzgWjKYCaKkjvoociYFuT, num2);
						return;
					default:
						if (num2 >= count)
						{
							pYylSnaZhhHPlmcssGUseHaIflO.Add(new XoLgRBGAfYsgfubmIhiiCvSilmyZ
							{
								UKCDHORBCFHBoYLTIFGoDfJwMEGs = P_0.rewiredId,
								MAoxEuNsNkUjTLSDghmOoJgBmws = P_0.qYoawwlzgWjKYCaKkjvoociYFuT,
								IerddSLNXqqcFfmPgxIqNDWuwNi = P_0.IerddSLNXqqcFfmPgxIqNDWuwNi,
								MrgFvxEmVvleAtwmEJiJFGTJUZgS = P_0.inputManagerId,
								lCNqQoAApxuECSfGdHgIftxqKOX = P_0.lCNqQoAApxuECSfGdHgIftxqKOX,
								oGcycOAqtFGbygaGhDMChNbBqYZn = P_0.oGcycOAqtFGbygaGhDMChNbBqYZn,
								VRaBaRJBhrkeRbpjPHxbMRTvGos = P_0.VRaBaRJBhrkeRbpjPHxbMRTvGos
							});
							DEiihYzBOuDCWDVSMxebepjOOeX(P_0.rewiredId, P_0.qYoawwlzgWjKYCaKkjvoociYFuT, pYylSnaZhhHPlmcssGUseHaIflO.Count - 1);
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public bool QUzJIwsyLBGiiDjdziRDeDUvrEq(ptMebSqXEoBzBEOaTPyqDqsEryl P_0, qHZDSIBhYQrndecePjMaNcAbECWD P_1)
		{
			int count = pYylSnaZhhHPlmcssGUseHaIflO.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					if (pYylSnaZhhHPlmcssGUseHaIflO[num].YfzaYuFFeAGpZYIlhOCKodCcBwd(P_0, P_1))
					{
						return true;
					}
					num++;
					int num2 = -2098199184;
					while (true)
					{
						switch (num2 ^ -2098199182)
						{
						case 0:
							num2 = -2098199181;
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

		public IEnumerable<XoLgRBGAfYsgfubmIhiiCvSilmyZ> ujuphkmYzsIfimEfOMVCHtLnQKt(ptMebSqXEoBzBEOaTPyqDqsEryl P_0, qHZDSIBhYQrndecePjMaNcAbECWD P_1)
		{
			yQuzKmAFIloIVtnZxnSwwxqWNrw yQuzKmAFIloIVtnZxnSwwxqWNrw2 = new yQuzKmAFIloIVtnZxnSwwxqWNrw(-2);
			yQuzKmAFIloIVtnZxnSwwxqWNrw2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			yQuzKmAFIloIVtnZxnSwwxqWNrw2.kBIDOXdTvkXDGsXBIDEoXEkSifNc = P_0;
			yQuzKmAFIloIVtnZxnSwwxqWNrw2.DjGvqohErCEFaeFNfFegiWUXHde = P_1;
			return yQuzKmAFIloIVtnZxnSwwxqWNrw2;
		}

		private void DEiihYzBOuDCWDVSMxebepjOOeX(int P_0, Guid P_1, int P_2)
		{
			int num = pYylSnaZhhHPlmcssGUseHaIflO.Count - 1;
			while (true)
			{
				int num2;
				int num3;
				if (num < 0)
				{
					num2 = -1787080822;
					num3 = num2;
				}
				else
				{
					num2 = -1787080818;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1787080822)
					{
					case 5:
						num2 = -1787080818;
						continue;
					default:
						return;
					case 4:
						if (num == P_2)
						{
							goto case 1;
						}
						if (pYylSnaZhhHPlmcssGUseHaIflO[num].UKCDHORBCFHBoYLTIFGoDfJwMEGs != P_0)
						{
							int num4;
							if (!(pYylSnaZhhHPlmcssGUseHaIflO[num].MAoxEuNsNkUjTLSDghmOoJgBmws == P_1))
							{
								num2 = -1787080821;
								num4 = num2;
							}
							else
							{
								num2 = -1787080824;
								num4 = num2;
							}
							continue;
						}
						goto case 2;
					case 1:
						num--;
						num2 = -1787080823;
						continue;
					case 2:
						pYylSnaZhhHPlmcssGUseHaIflO.RemoveAt(num);
						num2 = -1787080821;
						continue;
					case 3:
						break;
					case 0:
						return;
					}
					break;
				}
			}
		}
	}

	internal const bool yBQDRAFyzcChNxPYLhAMxAGRtfiD = true;

	private IInputSource RGiPJkMDpueuMBxNNWOIhzCOavB;

	private List<ptMebSqXEoBzBEOaTPyqDqsEryl> KjXmBSVldpfwjiNaozEQFsyjEtD;

	private int zCJDBcHESKfNGvcIMmoYVGihyIj;

	private dogFaTSPlllVfZoyaXxTFOdHiiU ZDGzEdGlsfPIXxxIiRhCInujjGU;

	private bool VjAUYAWOZYRvlAZvsjAqxlszqGZ;

	private Action<int, ControllerDataUpdater> QwkejmzJqWXCTBNLCkdLqDDUJzf;

	private PlatformInputManager UkMXWLCIyaKLnYPfeWzjKwidlAk;

	private readonly bool pdMGqWoOXsknpEqFelIOnbtitYp;

	private readonly bool FPIFkeEGKbvpYzaMGAMgxkAoecg;

	private readonly bool ovHxuPBnGuWLwvuhGjMIvvWhjBm;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> dUeoOAWeqXvgKLTHqOAcuSQkGJiK;

	private readonly Func<int> sSVyKfminzFIZSXvvbOACNrjwsU;

	[CustomObfuscation(rename = false)]
	public override int deviceCount => zCJDBcHESKfNGvcIMmoYVGihyIj;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => UkMXWLCIyaKLnYPfeWzjKwidlAk;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => RGiPJkMDpueuMBxNNWOIhzCOavB;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.SDL2;

	public RwuqjFZefeIiGvIajuPSbfDUEbG(ConfigVars configVars, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId, bool handleJoysticks, bool handleUnifiedMouse, bool handleUnifiedKeyboard)
	{
		try
		{
			dUeoOAWeqXvgKLTHqOAcuSQkGJiK = getHardwareJoystickMap_InputManager;
			sSVyKfminzFIZSXvvbOACNrjwsU = getNewJoystickId;
			pdMGqWoOXsknpEqFelIOnbtitYp = handleJoysticks;
			FPIFkeEGKbvpYzaMGAMgxkAoecg = handleUnifiedMouse;
			ovHxuPBnGuWLwvuhGjMIvvWhjBm = handleUnifiedKeyboard;
			UkMXWLCIyaKLnYPfeWzjKwidlAk = this;
			RGiPJkMDpueuMBxNNWOIhzCOavB = new SDL2InputSource(configVars.updateLoop, handleJoysticks, handleJoysticks, handleUnifiedMouse, handleUnifiedKeyboard);
			QwkejmzJqWXCTBNLCkdLqDDUJzf = UpdateControllerData;
			RGiPJkMDpueuMBxNNWOIhzCOavB.DeviceChangedEvent += JypHrqyqRPbmmioIzJtCFRiFKTY;
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
		if (pdMGqWoOXsknpEqFelIOnbtitYp)
		{
			ZDGzEdGlsfPIXxxIiRhCInujjGU = new dogFaTSPlllVfZoyaXxTFOdHiiU();
			YAYLplglEiMaFnRMMiGNmldzCmUa();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (RGiPJkMDpueuMBxNNWOIhzCOavB != null)
		{
			RGiPJkMDpueuMBxNNWOIhzCOavB.Update();
			goto IL_0016;
		}
		goto IL_00c6;
		IL_018a:
		_ = FPIFkeEGKbvpYzaMGAMgxkAoecg;
		return;
		IL_0016:
		int num = -359348637;
		goto IL_001b;
		IL_001b:
		int num3 = default(int);
		ptMebSqXEoBzBEOaTPyqDqsEryl ptMebSqXEoBzBEOaTPyqDqsEryl2 = default(ptMebSqXEoBzBEOaTPyqDqsEryl);
		int num2 = default(int);
		while (true)
		{
			switch (num ^ -359348635)
			{
			case 4:
				break;
			case 1:
				num3++;
				num = -359348625;
				continue;
			case 0:
				jqvaloCvHNpVrQxERwhVWaVTZgBw();
				num = -359348632;
				continue;
			case 3:
				if (ptMebSqXEoBzBEOaTPyqDqsEryl2 != null)
				{
					ptMebSqXEoBzBEOaTPyqDqsEryl2.BOANwqncOLYXWURmWjkyMSRMEGQ.yMpzPEgRxuylucHrikwaTLDBNvx();
					num = -359348631;
					continue;
				}
				goto case 12;
			case 8:
				if (RGiPJkMDpueuMBxNNWOIhzCOavB != null)
				{
					num3 = 0;
					num = -359348625;
					continue;
				}
				goto case 0;
			case 10:
				if (num3 >= zCJDBcHESKfNGvcIMmoYVGihyIj)
				{
					RGiPJkMDpueuMBxNNWOIhzCOavB.UpdateDevices(updateLoop);
					num = -359348635;
					continue;
				}
				goto case 7;
			case 6:
				goto IL_00c6;
			case 13:
				if (RGiPJkMDpueuMBxNNWOIhzCOavB != null)
				{
					RGiPJkMDpueuMBxNNWOIhzCOavB.UpdateFinished();
					num2 = 0;
					num = -359348633;
					continue;
				}
				goto IL_018a;
			case 7:
			{
				ptMebSqXEoBzBEOaTPyqDqsEryl ptMebSqXEoBzBEOaTPyqDqsEryl3 = KjXmBSVldpfwjiNaozEQFsyjEtD[num3];
				if (ptMebSqXEoBzBEOaTPyqDqsEryl3 != null)
				{
					ptMebSqXEoBzBEOaTPyqDqsEryl3.BOANwqncOLYXWURmWjkyMSRMEGQ.GzCliicOSMFLMvKajLgvnmGSSrh(updateLoop);
					num = -359348636;
					continue;
				}
				goto case 1;
			}
			case 5:
				ptMebSqXEoBzBEOaTPyqDqsEryl2 = KjXmBSVldpfwjiNaozEQFsyjEtD[num2];
				num = -359348634;
				continue;
			case 12:
				num2++;
				num = -359348633;
				continue;
			case 9:
				MFhjbGVDbNrOVBNutDpnZUWGDEP();
				num = -359348627;
				continue;
			case 2:
				goto IL_016d;
			default:
				goto IL_018a;
			}
			break;
			IL_016d:
			int num4;
			if (num2 >= zCJDBcHESKfNGvcIMmoYVGihyIj)
			{
				num = -359348626;
				num4 = num;
			}
			else
			{
				num = -359348640;
				num4 = num;
			}
		}
		goto IL_0016;
		IL_00c6:
		if (pdMGqWoOXsknpEqFelIOnbtitYp)
		{
			int num5;
			if (!VjAUYAWOZYRvlAZvsjAqxlszqGZ)
			{
				num = -359348627;
				num5 = num;
			}
			else
			{
				num = -359348628;
				num5 = num;
			}
			goto IL_001b;
		}
		goto IL_018a;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (KjXmBSVldpfwjiNaozEQFsyjEtD != null)
		{
			goto IL_0008;
		}
		goto IL_003d;
		IL_0008:
		int num = -231125808;
		goto IL_000d;
		IL_000d:
		int num2 = default(int);
		int count = default(int);
		while (true)
		{
			switch (num ^ -231125807)
			{
			case 5:
				break;
			default:
				return;
			case 2:
				goto IL_003d;
			case 0:
				if (KjXmBSVldpfwjiNaozEQFsyjEtD[num2] != null)
				{
					pErdarFuDrLltFruMSsYCDRyarSk bOANwqncOLYXWURmWjkyMSRMEGQ = KjXmBSVldpfwjiNaozEQFsyjEtD[num2].BOANwqncOLYXWURmWjkyMSRMEGQ;
					if (bOANwqncOLYXWURmWjkyMSRMEGQ != null)
					{
						bOANwqncOLYXWURmWjkyMSRMEGQ.FUAgHhEDNWeVqiqXUFRbfGQUGqIw();
						num = -231125806;
						continue;
					}
				}
				goto case 3;
			case 3:
				num2++;
				num = -231125802;
				continue;
			case 6:
				RGiPJkMDpueuMBxNNWOIhzCOavB.Dispose();
				num = -231125803;
				continue;
			case 1:
				count = KjXmBSVldpfwjiNaozEQFsyjEtD.Count;
				num2 = 0;
				num = -231125802;
				continue;
			case 7:
				goto IL_00c1;
			case 4:
				return;
			}
			break;
			IL_00c1:
			int num3;
			if (num2 >= count)
			{
				num = -231125805;
				num3 = num;
			}
			else
			{
				num = -231125807;
				num3 = num;
			}
		}
		goto IL_0008;
		IL_003d:
		int num4;
		if (RGiPJkMDpueuMBxNNWOIhzCOavB != null)
		{
			num = -231125801;
			num4 = num;
		}
		else
		{
			num = -231125803;
			num4 = num;
		}
		goto IL_000d;
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return QwkejmzJqWXCTBNLCkdLqDDUJzf;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!pdMGqWoOXsknpEqFelIOnbtitYp)
		{
			goto IL_0008;
		}
		goto IL_0073;
		IL_0008:
		int num = 730533055;
		goto IL_000d;
		IL_000d:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x2B8B0CBC)
			{
			case 5:
				break;
			case 3:
				return;
			case 2:
				if (KjXmBSVldpfwjiNaozEQFsyjEtD[num2].inputManagerId == inputManagerId)
				{
					KjXmBSVldpfwjiNaozEQFsyjEtD[num2].FillData(data);
					return;
				}
				goto case 0;
			case 0:
				num2++;
				num = 730533048;
				continue;
			case 1:
				goto IL_0073;
			default:
				if (num2 >= zCJDBcHESKfNGvcIMmoYVGihyIj)
				{
					return;
				}
				goto case 2;
			}
			break;
		}
		goto IL_0008;
		IL_0073:
		num2 = 0;
		num = 730533048;
		goto IL_000d;
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		if (pdMGqWoOXsknpEqFelIOnbtitYp)
		{
			VjAUYAWOZYRvlAZvsjAqxlszqGZ = true;
			goto IL_000f;
		}
		goto IL_002d;
		IL_002d:
		int num;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
			num = 4148450;
			goto IL_0014;
		}
		return;
		IL_000f:
		num = 4148449;
		goto IL_0014;
		IL_0014:
		switch (num ^ 0x3F4CE0)
		{
		case 0:
			break;
		default:
			return;
		case 1:
			goto IL_002d;
		case 2:
			return;
		}
		goto IL_000f;
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		if (pdMGqWoOXsknpEqFelIOnbtitYp)
		{
			VjAUYAWOZYRvlAZvsjAqxlszqGZ = true;
			goto IL_000f;
		}
		goto IL_002d;
		IL_002d:
		int num;
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
			num = -1082399168;
			goto IL_0014;
		}
		return;
		IL_000f:
		num = -1082399165;
		goto IL_0014;
		IL_0014:
		switch (num ^ -1082399166)
		{
		case 0:
			break;
		default:
			return;
		case 1:
			goto IL_002d;
		case 2:
			return;
		}
		goto IL_000f;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = pdMGqWoOXsknpEqFelIOnbtitYp;
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

	private void YAYLplglEiMaFnRMMiGNmldzCmUa()
	{
		YAYLplglEiMaFnRMMiGNmldzCmUa(PrWhuuhyjZqNMTZbMiKCbABcfqmH());
	}

	private void YAYLplglEiMaFnRMMiGNmldzCmUa(IList<pErdarFuDrLltFruMSsYCDRyarSk> P_0)
	{
		int num = 0;
		List<ptMebSqXEoBzBEOaTPyqDqsEryl> kjXmBSVldpfwjiNaozEQFsyjEtD = KjXmBSVldpfwjiNaozEQFsyjEtD;
		int num2 = zCJDBcHESKfNGvcIMmoYVGihyIj;
		KjXmBSVldpfwjiNaozEQFsyjEtD = new List<ptMebSqXEoBzBEOaTPyqDqsEryl>();
		int num4 = default(int);
		ptMebSqXEoBzBEOaTPyqDqsEryl ptMebSqXEoBzBEOaTPyqDqsEryl2 = default(ptMebSqXEoBzBEOaTPyqDqsEryl);
		pErdarFuDrLltFruMSsYCDRyarSk pErdarFuDrLltFruMSsYCDRyarSk2 = default(pErdarFuDrLltFruMSsYCDRyarSk);
		int num5 = default(int);
		int count = default(int);
		while (true)
		{
			int num3 = 358369221;
			while (true)
			{
				switch (num3 ^ 0x155C47CB)
				{
				case 4:
					break;
				case 7:
					num++;
					num3 = 358369227;
					continue;
				case 2:
					num4 = 0;
					num3 = 358369223;
					continue;
				case 9:
					ptMebSqXEoBzBEOaTPyqDqsEryl2.XOcpUHIIBydiGZIoNLAeVYoWsBq = pErdarFuDrLltFruMSsYCDRyarSk2.IsBluetoothDevice;
					ptMebSqXEoBzBEOaTPyqDqsEryl2.gkkruTywtCSgfaMjHfnJvKIxFVy = pErdarFuDrLltFruMSsYCDRyarSk2.SupportsVibration;
					num3 = 358369219;
					continue;
				case 1:
					if (_UpdateControllerInfoEvent != null)
					{
						_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(KjXmBSVldpfwjiNaozEQFsyjEtD[num5]));
						num3 = 358369230;
						continue;
					}
					goto case 5;
				case 11:
					if (P_0[num4] != null)
					{
						pErdarFuDrLltFruMSsYCDRyarSk2 = P_0[num4];
						ptMebSqXEoBzBEOaTPyqDqsEryl2 = new ptMebSqXEoBzBEOaTPyqDqsEryl(dUeoOAWeqXvgKLTHqOAcuSQkGJiK);
						ptMebSqXEoBzBEOaTPyqDqsEryl2.BOANwqncOLYXWURmWjkyMSRMEGQ = pErdarFuDrLltFruMSsYCDRyarSk2;
						num3 = 358369243;
						continue;
					}
					goto case 0;
				case 5:
					num5++;
					num3 = 358369242;
					continue;
				case 10:
					ptMebSqXEoBzBEOaTPyqDqsEryl2.lCNqQoAApxuECSfGdHgIftxqKOX = pErdarFuDrLltFruMSsYCDRyarSk2.AxisCount;
					ptMebSqXEoBzBEOaTPyqDqsEryl2.oGcycOAqtFGbygaGhDMChNbBqYZn = pErdarFuDrLltFruMSsYCDRyarSk2.ButtonCount;
					ptMebSqXEoBzBEOaTPyqDqsEryl2.VRaBaRJBhrkeRbpjPHxbMRTvGos = pErdarFuDrLltFruMSsYCDRyarSk2.HatCount;
					num3 = 358369218;
					continue;
				case 14:
					count = P_0.Count;
					num3 = 358369225;
					continue;
				case 6:
					KjXmBSVldpfwjiNaozEQFsyjEtD.Add(ptMebSqXEoBzBEOaTPyqDqsEryl2);
					num3 = 358369228;
					continue;
				case 17:
					if (num5 >= num)
					{
						DvAgAsBJXkezynrKQNPnZfxrsAT(kjXmBSVldpfwjiNaozEQFsyjEtD, KjXmBSVldpfwjiNaozEQFsyjEtD, false);
						num3 = 358369222;
						continue;
					}
					goto case 1;
				case 8:
					ptMebSqXEoBzBEOaTPyqDqsEryl2.hSqMknHvfLaCaSKUtNrDJWiYQVX = pErdarFuDrLltFruMSsYCDRyarSk2.VibrationMotorCount;
					ptMebSqXEoBzBEOaTPyqDqsEryl2.extension = pErdarFuDrLltFruMSsYCDRyarSk2.ControllerExtension;
					pErdarFuDrLltFruMSsYCDRyarSk2.UUktGbfjCvLkphIGDotAzFKLBuO();
					ptMebSqXEoBzBEOaTPyqDqsEryl2.kfcRhmfnfWicmjTenihbZSYGYjYh();
					num3 = 358369229;
					continue;
				case 15:
					num5 = 0;
					num3 = 358369242;
					continue;
				case 3:
					ptMebSqXEoBzBEOaTPyqDqsEryl2.IifBwgifDjJLQbtRWmfjwrERSUof = pErdarFuDrLltFruMSsYCDRyarSk2.FriendlyName;
					ptMebSqXEoBzBEOaTPyqDqsEryl2.LjGpBwDvaZYnRpwgjlueNWucAwo = pErdarFuDrLltFruMSsYCDRyarSk2.PidVid;
					ptMebSqXEoBzBEOaTPyqDqsEryl2.fkLtKGzJsvTUqlGdRyYQcjTaPmb = pErdarFuDrLltFruMSsYCDRyarSk2.ProductId;
					ptMebSqXEoBzBEOaTPyqDqsEryl2.LVhyNzNFybpcQeqlBtHhAycOnvD = pErdarFuDrLltFruMSsYCDRyarSk2.VendorId;
					ptMebSqXEoBzBEOaTPyqDqsEryl2.SkCcAXgfijscHdWxkWFsSHOZWErK = pErdarFuDrLltFruMSsYCDRyarSk2.DeviceType;
					ptMebSqXEoBzBEOaTPyqDqsEryl2.ezQswNZyAXdiNHmgSaQroyfOVDk = pErdarFuDrLltFruMSsYCDRyarSk2.JoystickId;
					num3 = 358369217;
					continue;
				case 0:
					num4++;
					num3 = 358369223;
					continue;
				case 12:
					if (num4 >= count)
					{
						zCJDBcHESKfNGvcIMmoYVGihyIj = num;
						WBFBlruLRCLpAZLkknTLUfchufi(num2, num, kjXmBSVldpfwjiNaozEQFsyjEtD, KjXmBSVldpfwjiNaozEQFsyjEtD);
						num3 = 358369220;
						continue;
					}
					goto case 11;
				case 16:
					ptMebSqXEoBzBEOaTPyqDqsEryl2.qYoawwlzgWjKYCaKkjvoociYFuT = pErdarFuDrLltFruMSsYCDRyarSk2.InstanceGuid;
					ptMebSqXEoBzBEOaTPyqDqsEryl2.FBYkTRckLemSakYJQMtfxOSmUPg = pErdarFuDrLltFruMSsYCDRyarSk2.SystemName;
					num3 = 358369224;
					continue;
				default:
					DvAgAsBJXkezynrKQNPnZfxrsAT(KjXmBSVldpfwjiNaozEQFsyjEtD, kjXmBSVldpfwjiNaozEQFsyjEtD, true);
					return;
				}
				break;
			}
		}
	}

	private void jqvaloCvHNpVrQxERwhVWaVTZgBw()
	{
		int num = 0;
		while (num < zCJDBcHESKfNGvcIMmoYVGihyIj)
		{
			while (true)
			{
				ptMebSqXEoBzBEOaTPyqDqsEryl ptMebSqXEoBzBEOaTPyqDqsEryl2 = KjXmBSVldpfwjiNaozEQFsyjEtD[num];
				int num2 = 1113464492;
				while (true)
				{
					switch (num2 ^ 0x425E1EA8)
					{
					case 3:
						num2 = 1113464489;
						continue;
					case 1:
						break;
					case 4:
						if (ptMebSqXEoBzBEOaTPyqDqsEryl2 != null)
						{
							ptMebSqXEoBzBEOaTPyqDqsEryl2.Update();
							num2 = 1113464490;
							continue;
						}
						goto case 2;
					case 2:
						num++;
						num2 = 1113464488;
						continue;
					default:
						goto end_IL_002a;
					}
					break;
				}
				continue;
				end_IL_002a:
				break;
			}
		}
	}

	private bool WQisalGCOMPRcqLzUdYcwILqAGvh(HhpxzhCmKzBlrkWbuqAWjmXFzKv P_0)
	{
		try
		{
			return P_0.pMCjfzlbSSSXwErueQwoZACHCXn();
		}
		catch
		{
			return false;
		}
	}

	private IList<pErdarFuDrLltFruMSsYCDRyarSk> PrWhuuhyjZqNMTZbMiKCbABcfqmH()
	{
		return RGiPJkMDpueuMBxNNWOIhzCOavB.GetJoysticks<pErdarFuDrLltFruMSsYCDRyarSk>();
	}

	private void WBFBlruLRCLpAZLkknTLUfchufi(int P_0, int P_1, List<ptMebSqXEoBzBEOaTPyqDqsEryl> P_2, List<ptMebSqXEoBzBEOaTPyqDqsEryl> P_3)
	{
		if (P_1 > 0)
		{
			goto IL_0007;
		}
		goto IL_0100;
		IL_0007:
		int num = 914040942;
		goto IL_000c;
		IL_000c:
		ptMebSqXEoBzBEOaTPyqDqsEryl ptMebSqXEoBzBEOaTPyqDqsEryl2 = default(ptMebSqXEoBzBEOaTPyqDqsEryl);
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x367B286A)
			{
			case 0:
				break;
			case 4:
				P_3.Sort(ptMebSqXEoBzBEOaTPyqDqsEryl.CNuzoMNyAiMHEtbpITTXVchrvxa);
				num = 914040940;
				continue;
			case 9:
				ptMebSqXEoBzBEOaTPyqDqsEryl2 = P_3[num2];
				num = 914040936;
				continue;
			case 8:
				goto IL_0072;
			case 1:
				IrBuLLxHFdDknWWFKqrzDdBoboV(P_1, P_3, dogFaTSPlllVfZoyaXxTFOdHiiU.qHZDSIBhYQrndecePjMaNcAbECWD.BKFaaxAPcuBcJAcYJSBDkcEuaeHB);
				num2 = 0;
				num = 914040943;
				continue;
			case 10:
				num2++;
				num = 914040943;
				continue;
			case 5:
				goto IL_00a7;
			case 2:
				if (ptMebSqXEoBzBEOaTPyqDqsEryl2 != null && ptMebSqXEoBzBEOaTPyqDqsEryl2.inputManagerId < 0)
				{
					ptMebSqXEoBzBEOaTPyqDqsEryl2.inputManagerId = xsxJptmMPnqGtRxSuBrOBHkSWsg(P_3);
					ptMebSqXEoBzBEOaTPyqDqsEryl2.rewiredId = sSVyKfminzFIZSXvvbOACNrjwsU();
					ZDGzEdGlsfPIXxxIiRhCInujjGU.tXgmibXCLFITLeBlRtsWPalapKpT(ptMebSqXEoBzBEOaTPyqDqsEryl2);
					num = 914040928;
					continue;
				}
				goto case 10;
			case 6:
				goto IL_0100;
			case 7:
				if (P_1 > 0)
				{
					WWBpSaLxuMDBckrvrBppKtPxZoIQ(P_1, P_3, P_0, P_2, dogFaTSPlllVfZoyaXxTFOdHiiU.qHZDSIBhYQrndecePjMaNcAbECWD.zlJMCEeCIoRemLBsAgqNdRDgziDK);
					WWBpSaLxuMDBckrvrBppKtPxZoIQ(P_1, P_3, P_0, P_2, dogFaTSPlllVfZoyaXxTFOdHiiU.qHZDSIBhYQrndecePjMaNcAbECWD.BKFaaxAPcuBcJAcYJSBDkcEuaeHB);
					num = 914040930;
					continue;
				}
				goto IL_0072;
			default:
				P_3.Sort(ptMebSqXEoBzBEOaTPyqDqsEryl.EOGdSkGkOKCvaGaRDrqjdrmHsdXG);
				return;
			}
			break;
			IL_00a7:
			int num3;
			if (num2 >= P_1)
			{
				num = 914040937;
				num3 = num;
			}
			else
			{
				num = 914040931;
				num3 = num;
			}
		}
		goto IL_0007;
		IL_0072:
		IrBuLLxHFdDknWWFKqrzDdBoboV(P_1, P_3, dogFaTSPlllVfZoyaXxTFOdHiiU.qHZDSIBhYQrndecePjMaNcAbECWD.zlJMCEeCIoRemLBsAgqNdRDgziDK);
		num = 914040939;
		goto IL_000c;
		IL_0100:
		if (P_0 > 0)
		{
			num = 914040941;
			goto IL_000c;
		}
		goto IL_0072;
	}

	private void bAaaRABRdZwxMnddEjixrGLYNAe(List<ptMebSqXEoBzBEOaTPyqDqsEryl> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		int num2 = default(int);
		while (true)
		{
			int num = 1260517905;
			while (true)
			{
				switch (num ^ 0x4B21FA10)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					num2++;
					num = 1260517910;
					continue;
				case 5:
					if (P_0[num2].inputManagerId == P_2)
					{
						P_0[num2].inputManagerId = -1;
						num = 1260517907;
						continue;
					}
					goto case 3;
				case 4:
					num = 1260517910;
					continue;
				case 6:
				{
					int num4;
					if (num2 < count)
					{
						num = 1260517911;
						num4 = num;
					}
					else
					{
						num = 1260517904;
						num4 = num;
					}
					continue;
				}
				case 1:
					num2 = 0;
					num = 1260517908;
					continue;
				case 7:
					if (num2 != P_1)
					{
						int num3;
						if (P_0[num2] != null)
						{
							num = 1260517909;
							num3 = num;
						}
						else
						{
							num = 1260517907;
							num3 = num;
						}
						continue;
					}
					goto case 3;
				case 0:
					return;
				}
				break;
			}
		}
	}

	private bool pgNWowjBpVDUsfPflzUQpiDLSMiQ(List<ptMebSqXEoBzBEOaTPyqDqsEryl> P_0, int P_1)
	{
		int count = P_0.Count;
		int num2 = default(int);
		while (true)
		{
			int num = 1513443208;
			while (true)
			{
				switch (num ^ 0x5A354F8C)
				{
				case 0:
					break;
				case 4:
					num2 = 0;
					num = 1513443214;
					continue;
				case 3:
					if (P_0[num2] != null && P_0[num2].inputManagerId == P_1)
					{
						return false;
					}
					num2++;
					num = 1513443214;
					continue;
				case 2:
				{
					int num3;
					if (num2 < count)
					{
						num = 1513443215;
						num3 = num;
					}
					else
					{
						num = 1513443213;
						num3 = num;
					}
					continue;
				}
				default:
					return true;
				}
				break;
			}
		}
	}

	private int xsxJptmMPnqGtRxSuBrOBHkSWsg(List<ptMebSqXEoBzBEOaTPyqDqsEryl> P_0)
	{
		int num = 0;
		bool flag = default(bool);
		int count = default(int);
		int num3 = default(int);
		while (true)
		{
			int num2 = 1043721828;
			while (true)
			{
				switch (num2 ^ 0x3E35EE63)
				{
				case 8:
					break;
				case 7:
					flag = false;
					count = P_0.Count;
					num3 = 0;
					num2 = 1043721826;
					continue;
				case 6:
					if (P_0[num3].inputManagerId == num)
					{
						flag = true;
						num2 = 1043721825;
						continue;
					}
					goto case 0;
				case 4:
				{
					int num5;
					if (P_0[num3] != null)
					{
						num2 = 1043721829;
						num5 = num2;
					}
					else
					{
						num2 = 1043721827;
						num5 = num2;
					}
					continue;
				}
				case 0:
					num3++;
					num2 = 1043721830;
					continue;
				case 1:
					num2 = 1043721830;
					continue;
				case 2:
					if (!flag)
					{
						num2 = 1043721824;
						continue;
					}
					num++;
					goto case 7;
				case 5:
				{
					int num4;
					if (num3 < count)
					{
						num2 = 1043721831;
						num4 = num2;
					}
					else
					{
						num2 = 1043721825;
						num4 = num2;
					}
					continue;
				}
				default:
					return num;
				}
				break;
			}
		}
	}

	private bool tDUJWQkhxomwvbhOaOoQeAWVFSH(List<ptMebSqXEoBzBEOaTPyqDqsEryl> P_0, int P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			int num2 = -1588674433;
			while (true)
			{
				switch (num2 ^ -1588674434)
				{
				case 2:
					break;
				case 1:
					num2 = -1588674435;
					continue;
				case 0:
					if (P_0[num].rewiredId == P_1)
					{
						return true;
					}
					num++;
					num2 = -1588674435;
					continue;
				default:
					if (num >= P_0.Count)
					{
						return false;
					}
					goto case 0;
				}
				break;
			}
		}
	}

	private void WWBpSaLxuMDBckrvrBppKtPxZoIQ(int P_0, List<ptMebSqXEoBzBEOaTPyqDqsEryl> P_1, int P_2, List<ptMebSqXEoBzBEOaTPyqDqsEryl> P_3, dogFaTSPlllVfZoyaXxTFOdHiiU.qHZDSIBhYQrndecePjMaNcAbECWD P_4)
	{
		if (P_4 != dogFaTSPlllVfZoyaXxTFOdHiiU.qHZDSIBhYQrndecePjMaNcAbECWD.zlJMCEeCIoRemLBsAgqNdRDgziDK)
		{
			goto IL_0004;
		}
		int num = 2;
		goto IL_0069;
		IL_0065:
		num = 1;
		goto IL_0069;
		IL_0004:
		int num2 = -992206637;
		goto IL_0009;
		IL_0009:
		int num3 = default(int);
		ptMebSqXEoBzBEOaTPyqDqsEryl ptMebSqXEoBzBEOaTPyqDqsEryl3 = default(ptMebSqXEoBzBEOaTPyqDqsEryl);
		int num4 = default(int);
		int num5 = default(int);
		while (true)
		{
			switch (num2 ^ -992206636)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				goto IL_0045;
			case 5:
				num3++;
				num2 = -992206628;
				continue;
			case 7:
				goto IL_0065;
			case 8:
				goto IL_0073;
			case 3:
				num2 = -992206628;
				continue;
			case 1:
				goto IL_0092;
			case 4:
				if (ptMebSqXEoBzBEOaTPyqDqsEryl3.inputManagerId < 0)
				{
					num3 = 0;
					num2 = -992206633;
					continue;
				}
				goto case 10;
			case 9:
			{
				ptMebSqXEoBzBEOaTPyqDqsEryl ptMebSqXEoBzBEOaTPyqDqsEryl2 = P_3[num3];
				if (ptMebSqXEoBzBEOaTPyqDqsEryl2 != null && !tDUJWQkhxomwvbhOaOoQeAWVFSH(P_1, ptMebSqXEoBzBEOaTPyqDqsEryl2.rewiredId) && ptMebSqXEoBzBEOaTPyqDqsEryl3.YfzaYuFFeAGpZYIlhOCKodCcBwd(ptMebSqXEoBzBEOaTPyqDqsEryl2) >= num4)
				{
					ptMebSqXEoBzBEOaTPyqDqsEryl3.mJCczqeFiFMzoayoFJmEwVIjyQZW(ptMebSqXEoBzBEOaTPyqDqsEryl2);
					ZDGzEdGlsfPIXxxIiRhCInujjGU.tXgmibXCLFITLeBlRtsWPalapKpT(ptMebSqXEoBzBEOaTPyqDqsEryl3);
					num2 = -992206639;
					continue;
				}
				goto case 5;
			}
			case 10:
				num5++;
				num2 = -992206634;
				continue;
			case 6:
				return;
			}
			break;
			IL_0092:
			ptMebSqXEoBzBEOaTPyqDqsEryl3 = P_1[num5];
			int num6;
			if (ptMebSqXEoBzBEOaTPyqDqsEryl3 == null)
			{
				num2 = -992206626;
				num6 = num2;
			}
			else
			{
				num2 = -992206640;
				num6 = num2;
			}
			continue;
			IL_0073:
			int num7;
			if (num3 >= P_2)
			{
				num2 = -992206626;
				num7 = num2;
			}
			else
			{
				num2 = -992206627;
				num7 = num2;
			}
			continue;
			IL_0045:
			int num8;
			if (num5 >= P_0)
			{
				num2 = -992206638;
				num8 = num2;
			}
			else
			{
				num2 = -992206635;
				num8 = num2;
			}
		}
		goto IL_0004;
		IL_0069:
		num4 = num;
		num5 = 0;
		num2 = -992206634;
		goto IL_0009;
	}

	private void IrBuLLxHFdDknWWFKqrzDdBoboV(int P_0, List<ptMebSqXEoBzBEOaTPyqDqsEryl> P_1, dogFaTSPlllVfZoyaXxTFOdHiiU.qHZDSIBhYQrndecePjMaNcAbECWD P_2)
	{
		int num = 0;
		dogFaTSPlllVfZoyaXxTFOdHiiU.XoLgRBGAfYsgfubmIhiiCvSilmyZ xoLgRBGAfYsgfubmIhiiCvSilmyZ = default(dogFaTSPlllVfZoyaXxTFOdHiiU.XoLgRBGAfYsgfubmIhiiCvSilmyZ);
		dogFaTSPlllVfZoyaXxTFOdHiiU.XoLgRBGAfYsgfubmIhiiCvSilmyZ current = default(dogFaTSPlllVfZoyaXxTFOdHiiU.XoLgRBGAfYsgfubmIhiiCvSilmyZ);
		int num5 = default(int);
		while (num < P_0)
		{
			ptMebSqXEoBzBEOaTPyqDqsEryl ptMebSqXEoBzBEOaTPyqDqsEryl2 = P_1[num];
			if (ptMebSqXEoBzBEOaTPyqDqsEryl2 != null && ptMebSqXEoBzBEOaTPyqDqsEryl2.inputManagerId < 0)
			{
				xoLgRBGAfYsgfubmIhiiCvSilmyZ = null;
				using (IEnumerator<dogFaTSPlllVfZoyaXxTFOdHiiU.XoLgRBGAfYsgfubmIhiiCvSilmyZ> enumerator = ZDGzEdGlsfPIXxxIiRhCInujjGU.ujuphkmYzsIfimEfOMVCHtLnQKt(ptMebSqXEoBzBEOaTPyqDqsEryl2, P_2).GetEnumerator())
				{
					while (true)
					{
						IL_005f:
						int num2;
						int num3;
						if (!enumerator.MoveNext())
						{
							num2 = -819419147;
							num3 = num2;
						}
						else
						{
							num2 = -819419146;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -819419148)
							{
							case 0:
								num2 = -819419146;
								continue;
							default:
								goto end_IL_003e;
							case 4:
								break;
							case 3:
								xoLgRBGAfYsgfubmIhiiCvSilmyZ = current;
								num2 = -819419147;
								continue;
							case 2:
								current = enumerator.Current;
								if (!tDUJWQkhxomwvbhOaOoQeAWVFSH(P_1, current.UKCDHORBCFHBoYLTIFGoDfJwMEGs))
								{
									int num4;
									if (current.MrgFvxEmVvleAtwmEJiJFGTJUZgS < 0)
									{
										num2 = -819419152;
										num4 = num2;
									}
									else
									{
										num2 = -819419145;
										num4 = num2;
									}
									continue;
								}
								break;
							case 1:
								goto end_IL_003e;
							}
							goto IL_005f;
							continue;
							end_IL_003e:
							break;
						}
						break;
					}
				}
				if (xoLgRBGAfYsgfubmIhiiCvSilmyZ != null)
				{
					num5 = xoLgRBGAfYsgfubmIhiiCvSilmyZ.MrgFvxEmVvleAtwmEJiJFGTJUZgS;
					goto IL_00cf;
				}
			}
			goto IL_014a;
			IL_00d4:
			int num6;
			while (true)
			{
				switch (num6 ^ -819419148)
				{
				case 5:
					break;
				case 3:
					if (!pgNWowjBpVDUsfPflzUQpiDLSMiQ(P_1, num5))
					{
						num5 = xsxJptmMPnqGtRxSuBrOBHkSWsg(P_1);
						num6 = -819419148;
						continue;
					}
					goto case 1;
				case 0:
					xoLgRBGAfYsgfubmIhiiCvSilmyZ.MrgFvxEmVvleAtwmEJiJFGTJUZgS = num5;
					num6 = -819419147;
					continue;
				case 1:
					ptMebSqXEoBzBEOaTPyqDqsEryl2.inputManagerId = num5;
					ptMebSqXEoBzBEOaTPyqDqsEryl2.rewiredId = xoLgRBGAfYsgfubmIhiiCvSilmyZ.UKCDHORBCFHBoYLTIFGoDfJwMEGs;
					ZDGzEdGlsfPIXxxIiRhCInujjGU.tXgmibXCLFITLeBlRtsWPalapKpT(ptMebSqXEoBzBEOaTPyqDqsEryl2);
					num6 = -819419146;
					continue;
				case 2:
					goto IL_014a;
				default:
					goto IL_0158;
				}
				break;
			}
			goto IL_00cf;
			IL_00cf:
			num6 = -819419145;
			goto IL_00d4;
			IL_014a:
			num++;
			num6 = -819419152;
			goto IL_00d4;
			IL_0158:;
		}
	}

	private void MFhjbGVDbNrOVBNutDpnZUWGDEP()
	{
		IList<pErdarFuDrLltFruMSsYCDRyarSk> list = PrWhuuhyjZqNMTZbMiKCbABcfqmH();
		YAYLplglEiMaFnRMMiGNmldzCmUa(list);
		VjAUYAWOZYRvlAZvsjAqxlszqGZ = false;
	}

	private bool hLZerFQUBneQMKuTxVTgEcfJWjN(IList<pErdarFuDrLltFruMSsYCDRyarSk> P_0)
	{
		int count = P_0.Count;
		int num = 0;
		int count2 = default(int);
		int num2 = default(int);
		while (true)
		{
			int num3;
			if (num >= count)
			{
				count2 = KjXmBSVldpfwjiNaozEQFsyjEtD.Count;
				num2 = 0;
				num3 = 877807746;
				goto IL_0010;
			}
			goto IL_009f;
			IL_00b4:
			num++;
			num3 = 877807750;
			goto IL_0010;
			IL_009f:
			if (P_0[num] != null)
			{
				num3 = 877807748;
				goto IL_0010;
			}
			goto IL_00b4;
			IL_0010:
			while (true)
			{
				switch (num3 ^ 0x34524880)
				{
				case 5:
					num3 = 877807745;
					continue;
				case 6:
					break;
				case 8:
					goto IL_005d;
				case 2:
					num3 = 877807747;
					continue;
				case 1:
					goto IL_009f;
				case 0:
					return true;
				case 4:
					goto IL_00c2;
				case 3:
					goto IL_00e0;
				default:
					return false;
				}
				break;
				IL_00e0:
				int num4;
				if (num2 >= count2)
				{
					num3 = 877807751;
					num4 = num3;
				}
				else
				{
					num3 = 877807752;
					num4 = num3;
				}
				continue;
				IL_00c2:
				if (!awgQSOmIIDfImKaMsHpcYBwuGzyc(P_0[num].InstanceGuid))
				{
					num3 = 877807744;
					continue;
				}
				goto IL_00b4;
				IL_005d:
				if (KjXmBSVldpfwjiNaozEQFsyjEtD[num2] != null && !RokGntgssbtwEklnRhFIDCCQUlTO(P_0, KjXmBSVldpfwjiNaozEQFsyjEtD[num2].qYoawwlzgWjKYCaKkjvoociYFuT))
				{
					return true;
				}
				num2++;
				num3 = 877807747;
			}
		}
	}

	private bool awgQSOmIIDfImKaMsHpcYBwuGzyc(Guid P_0)
	{
		int count = KjXmBSVldpfwjiNaozEQFsyjEtD.Count;
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num >= count)
			{
				num2 = 1320267381;
				num3 = num2;
			}
			else
			{
				num2 = 1320267378;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x4EB1AE71)
				{
				case 0:
					num2 = 1320267378;
					continue;
				case 3:
					if (KjXmBSVldpfwjiNaozEQFsyjEtD[num] != null)
					{
						num2 = 1320267376;
						continue;
					}
					goto IL_007b;
				case 2:
					break;
				case 1:
					if (KjXmBSVldpfwjiNaozEQFsyjEtD[num].qYoawwlzgWjKYCaKkjvoociYFuT == P_0)
					{
						return true;
					}
					goto IL_007b;
				default:
					{
						return false;
					}
					IL_007b:
					num++;
					num2 = 1320267379;
					continue;
				}
				break;
			}
		}
	}

	private bool RokGntgssbtwEklnRhFIDCCQUlTO(IList<pErdarFuDrLltFruMSsYCDRyarSk> P_0, Guid P_1)
	{
		int count = P_0.Count;
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num >= count)
			{
				num2 = -1572971275;
				num3 = num2;
			}
			else
			{
				num2 = -1572971273;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ -1572971275)
				{
				case 3:
					num2 = -1572971273;
					continue;
				case 2:
					if (P_0[num] != null && P_0[num].InstanceGuid == P_1)
					{
						return true;
					}
					num++;
					num2 = -1572971276;
					continue;
				case 1:
					break;
				default:
					return false;
				}
				break;
			}
		}
	}

	private void DvAgAsBJXkezynrKQNPnZfxrsAT(List<ptMebSqXEoBzBEOaTPyqDqsEryl> P_0, List<ptMebSqXEoBzBEOaTPyqDqsEryl> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			goto IL_0006;
		}
		goto IL_0149;
		IL_0006:
		int num = 180243595;
		goto IL_000b;
		IL_000b:
		int num5 = default(int);
		bool flag = default(bool);
		int num2 = default(int);
		ptMebSqXEoBzBEOaTPyqDqsEryl ptMebSqXEoBzBEOaTPyqDqsEryl2 = default(ptMebSqXEoBzBEOaTPyqDqsEryl);
		int num3 = default(int);
		int num6 = default(int);
		while (true)
		{
			int num7;
			switch (num ^ 0xABE4C8A)
			{
			case 7:
				break;
			case 9:
				goto IL_0053;
			case 13:
				num5++;
				num = 180243598;
				continue;
			case 11:
				if (!flag)
				{
					vymVnMTbjwdXhKDbpoWajlhAhRD(P_0[num2], P_2);
					num = 180243596;
					continue;
				}
				goto case 6;
			case 2:
				if (P_1 == null)
				{
					num = 180243594;
					continue;
				}
				num7 = P_1.Count;
				goto IL_00a9;
			case 0:
				num7 = 0;
				goto IL_00a9;
			case 5:
				num5 = 0;
				num = 180243598;
				continue;
			case 1:
				return;
			case 4:
				goto IL_00ce;
			case 6:
				num2++;
				num = 180243584;
				continue;
			case 12:
			{
				ptMebSqXEoBzBEOaTPyqDqsEryl ptMebSqXEoBzBEOaTPyqDqsEryl3 = P_1[num5];
				if (ptMebSqXEoBzBEOaTPyqDqsEryl3 != null && ptMebSqXEoBzBEOaTPyqDqsEryl2.qYoawwlzgWjKYCaKkjvoociYFuT == ptMebSqXEoBzBEOaTPyqDqsEryl3.qYoawwlzgWjKYCaKkjvoociYFuT)
				{
					flag = true;
					num = 180243585;
					continue;
				}
				goto case 13;
			}
			case 3:
			{
				ptMebSqXEoBzBEOaTPyqDqsEryl2 = P_0[num2];
				int num4;
				if (ptMebSqXEoBzBEOaTPyqDqsEryl2 != null)
				{
					num = 180243587;
					num4 = num;
				}
				else
				{
					num = 180243596;
					num4 = num;
				}
				continue;
			}
			case 8:
				goto IL_0149;
			default:
				{
					if (num2 >= num3)
					{
						return;
					}
					goto case 3;
				}
				IL_00a9:
				num6 = num7;
				num2 = 0;
				num = 180243584;
				continue;
			}
			break;
			IL_00ce:
			int num8;
			if (num5 >= num6)
			{
				num = 180243585;
				num8 = num;
			}
			else
			{
				num = 180243590;
				num8 = num;
			}
			continue;
			IL_0053:
			flag = false;
			int num9;
			if (P_1 == null)
			{
				num = 180243585;
				num9 = num;
			}
			else
			{
				num = 180243599;
				num9 = num;
			}
		}
		goto IL_0006;
		IL_0149:
		num3 = P_0?.Count ?? 0;
		num = 180243592;
		goto IL_000b;
	}

	private void vymVnMTbjwdXhKDbpoWajlhAhRD(ptMebSqXEoBzBEOaTPyqDqsEryl P_0, bool P_1)
	{
		if (P_1)
		{
			if (_DeviceConnectedEvent == null)
			{
				return;
			}
			goto IL_000b;
		}
		goto IL_0046;
		IL_0046:
		int num;
		if (_DeviceDisconnectedEvent != null)
		{
			_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
			num = 1112905745;
			goto IL_0010;
		}
		return;
		IL_000b:
		num = 1112905746;
		goto IL_0010;
		IL_0010:
		switch (num ^ 0x42559813)
		{
		case 3:
			break;
		default:
			return;
		case 1:
			_DeviceConnectedEvent(P_0.ToBridgedController());
			return;
		case 0:
			goto IL_0046;
		case 2:
			return;
		}
		goto IL_000b;
	}

	private void JypHrqyqRPbmmioIzJtCFRiFKTY()
	{
		if (pdMGqWoOXsknpEqFelIOnbtitYp)
		{
			goto IL_0008;
		}
		goto IL_0038;
		IL_0008:
		int num = -279432635;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ -279432634)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				VjAUYAWOZYRvlAZvsjAqxlszqGZ = true;
				num = -279432633;
				continue;
			case 1:
				goto IL_0038;
			case 2:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_0038:
		SystemDeviceConnected();
		num = -279432636;
		goto IL_000d;
	}
}
