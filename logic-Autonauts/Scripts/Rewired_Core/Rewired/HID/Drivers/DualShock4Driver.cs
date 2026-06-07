using System;
using Rewired.ControllerExtensions;
using Rewired.Drivers.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualShock4Driver : HIDDeviceDriver, IDisposable, IControllerDriver, IDriver_DualShock4
	{
		private enum vOgaRorzkksunQUGmCfRIAUbpUU
		{
			ONxNRgxmPYmOzWGzoGjCgnOUVzaH = 0,
			iirGQdEwriPMGDPBwDbLcEJUBwV = 1,
			mBlhIdKCMygCgVWsFwHlaQuPofb = 2
		}

		private enum bFDDCMFPHzfBqEoEaYPljPrEFHLM
		{
			iOlZgcuFwLCPNAjSgaSDuxucio = 0,
			ArUkprxFsGMtZtnJwGanYDIJBWb = 1,
			iirGQdEwriPMGDPBwDbLcEJUBwV = 2
		}

		private const float yWXoZlJINtWVzxemHUouQDBOIhz = 4f;

		private const int VDaLjZYdsRIqheXEANPwCBhYDPo = 14;

		private const int DVrnfHLFmDCcIQyWQIWXrdZNJYZ = 2;

		private const int hdclqsFocebaLrKDtKLXsSLhuwJ = 0;

		private const int LcjVqxTvIDxftiLiiwwKWucfbtf = 1912;

		private const int deUzbsFTWDlGpQkAsXEVsfyypCp = 0;

		private const int ELEdUqiJQNqSFlKpJcBEbxEVCoo = 941;

		private const bool sQpFBtUbXdIDeOyGJujSAKCjDn = false;

		private const bool ygMEKzSdaAPKPumoXxgxJhzHpqp = true;

		private const float EmaxsrOnCOECcgcskdItBXyuWMeA = 2.5f;

		private const int cksPnnuFGcRrfSQVjGcSgXpvJwb = 0;

		private const int iRdtbDBegJBznQZWomXjsNpgrFp = 0;

		private const int LcBrNHUgxlLPlKhDcDzvCEYgsayM = 1;

		private const int yCgompgMXbNYdRLvskjXuECaxat = 0;

		private const int ibBidiJhBHHHIEjxTfIeLLRMBBhW = 0;

		private const int wvPFEMQybyJKgssyTKoReyoyVnc = 0;

		private const int BifrALJbcGgobYdxjCXqCzyjKgXe = 1;

		private const int tErDwYKxEVjFjacQtJTNzCLfKcIM = 17;

		private const int BeIhVBZcYiEsQBpvCgCIYaREKRsC = 0;

		private const int sUsAjtZZVxKkfrLywRYeZaNJSqu = 2;

		private const int OPsagwOZqqCNisUpCNAeOgMmdLnd = 64;

		private const int MvRrmBVdxpCnTcgAIpqnquwCdSF = 78;

		private const int brqUIClSMZDqzwDPekXSaTSNOUB = 1;

		private const int OsemuWhPzKesCALwSrMVdLHiEyy = 2;

		private const int XZCdiaJZDbybMUeEEnhulAXNKND = 3;

		private const int NqvKdJuIgbOHKEpPrlINIUfXopl = 4;

		private const int jZfrDUHGEnLlxopgvzWfjpXnOWg = 8;

		private const int eawnTjQQRDHGAEKzuXoXeVfArcW = 9;

		private const int gmCMFNfIJFMrVZbOZRYPVEVqBNb = 5;

		private const int gNFvVkEmjgVLKaceMMoiIIdbHFui = 19;

		private const int YFaBCqcLkPMYXwqeUchBspMToKT = 13;

		private const int PNazqyTiSshDJGbHuHjOosEWILW = 35;

		private const int eXQBUgkvBaqVnWiDksmtdkhiiSu = 5;

		private const int LeRCGZuczmFGGBRAlRNhZAnQAcg = 6;

		private const int xXcicWKlqyMlnYknHDdNvzBVZBr = 7;

		private const int DFPMOkBmVcSGIAldYNYahbOVzbP = 10;

		private const int TwuXygffIvIQtoeLriGDoBiiLZ = 30;

		private const int kUMzCqUSHprAWTruNGMHDYfyKUR = 27;

		private const byte FfKqsBOJMWdTLLbYFWBzEdOpMYc = 200;

		private const byte dXVJXesRufodagNBONQIKtfiaIw = 53;

		private const byte CDVGdskLtsnQuGBYwNuQKhToPVDS = byte.MaxValue;

		private const byte XSRIHIjaydMYlKFjdZaTiIyyyKJ = 0;

		private const bool SBkPuDbgDHzFHvWlUqvVnsFOUJN = true;

		private const bool mTZwjeEyFSOPWEZVpSefFADkJmc = true;

		private const bool IxMtcUqKaoMahCHlldygMIqoPMM = false;

		private const bool xWePDWKUjXkxocXvsBZkMCzwtPe = true;

		private const int QBRkzVqgeVqnVtmAagkbCAIMqLh = 25;

		private const bool MEfJJuMrmAasVZsxWjRWyhtcBBAj = true;

		private const float nPTvUQyNXCDpkMkfHzqKGqiLFzw = 8192f;

		private const float iOuxVBjbPkVpjllpGSIbhYSMTTT = 4096f;

		private const float FpwFKDRqzhKvAdlquzzKzIZShNT = 16384f;

		private const float QcfvCLCmefhrpSMreiUneqpicMM = 16777216f;

		private const float VypBhWHpBcKPnlZeEgTpfJUsIsk = 268435460f;

		private const float vNWQhiQQqJanPiGTPeppitwhwnrF = 0.01999998f;

		private const float acGgYnKpkJgJoqAlqihePcrrlie = 8192f;

		private const float BVKzqqGnHGcPRTPZnxxVccwhfIX = 0.0009765625f;

		private const float FQteIfcXxeMnhdEuhqoHjnBkkHac = 0.05595291f;

		private const float nVrfrQtluZnOTOkMdUAalEWcIwS = 0.98f;

		private const float mkMYkEUZuTmqcAPoDOOgFFCUSam = 45f;

		private const float JsoChCacBxKAsXyWFWlLcaQCSKqe = 10f;

		private readonly bool rsstixgQIJNSkPGeEeojspLRFRF;

		private readonly int shLANVAjdDDLRRTcoTrISsMNfcr;

		private readonly int oQjkYhEHzAyxjzJgeDbgBExOijx;

		private readonly bool cDxOMWGCJrOVpaFAIkSvyAMHgxE;

		private readonly byte relYbiFMYILflqJGvvsJtvzLUlC;

		private readonly int pUVDFYLvGTlVyKRgjKYluqeZBCW;

		private readonly int VzzUgFqoelfzPSaspaXhBrvbttmJ;

		private readonly int xYOVSbsDXLanAEFopfMMiGuEnyT;

		private readonly int fRVeVpflMMKKYSVMeyDYHLzufRzU;

		private readonly int cblzdKvKDXuufhxmLEZGBgDKpXI;

		private readonly int SMuJmZmgBZargmpEZdYfIjrhpQe;

		private readonly NativeBuffer RBWbtggyAdLBBLQKDwGIqmFtGqY;

		private readonly NativeBuffer QTvgeNabKIuYngzpDpvGaqKuMlN;

		private readonly OutputReport LwwCfYrHYYIqqrfRbeSqPqWCpel;

		private readonly Func<OutputReport, bool> xVVyGgNsqweTIzstWzQJegvUeuI;

		private readonly Action<OutputReport> CjDBJyHuwywJegdtLbKnPIGyviWF;

		private bool SVBExMdEoeiIzKSqvocQxLdJHgL;

		private bool ImlNCMuNvybLtizuApahnGozpMp;

		private float rdxGqopNFLdzOdtKHjjNgaOIePAr;

		private byte XcAgIYSRAUIDcTEqffKxcNleWKLb;

		private Quaternion ogpvvHIQgxriGDjgwZPJdLhupHC = Quaternion.identity;

		private ushort LSbcuKnEchIpfFsQoDrxlnOkALw;

		private float cdMOhKTYSiCiqtMHZENXxGyULUz;

		private float uCWbeRJjkuHsLjtluPpZfbcinVcM;

		private float XYuubApnwdbaDdjmjPNZoEVsIlq;

		private byte lDAeEFEACIBdJHuMkGZMuJMMNltP;

		private byte CbpwGKeHQuKNYaDcweqLTViKhth;

		private Quaternion mEqBbuFdknGLTUzytACtxVkVUgM = Quaternion.identity;

		private bool viPwTjtdmzCmHFBjiOyKKzwIBcC;

		private int ejJMwWFoyTNZUgtIpJJHvYKRrlC;

		private int[] qBhOgmvBergqvNfdfRwLNkKCEre = new int[2];

		private int[] VkIgFCjLijMBHeAtScOaLRFIIYlX = new int[2];

		private bool isVibrating
		{
			get
			{
				int num = 0;
				while (num < base.VibrationMotorCount)
				{
					while (true)
					{
						if (vibrationMotors[num].SpeedRaw > 0)
						{
							return true;
						}
						num++;
						int num2 = -1783149548;
						while (true)
						{
							switch (num2 ^ -1783149548)
							{
							case 2:
								num2 = -1783149547;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0022;
							}
							break;
						}
						continue;
						end_IL_0022:
						break;
					}
				}
				return false;
			}
		}

		public float BatteryLevel
		{
			get
			{
				float value = 0f;
				while (true)
				{
					int num = -1785627037;
					while (true)
					{
						switch (num ^ -1785627038)
						{
						case 3:
							break;
						case 1:
						{
							int num2;
							if (rsstixgQIJNSkPGeEeojspLRFRF)
							{
								num = -1785627038;
								num2 = num;
							}
							else
							{
								num = -1785627034;
								num2 = num;
							}
							continue;
						}
						case 0:
							value = (float)(XcAgIYSRAUIDcTEqffKxcNleWKLb + 2) * 10f;
							num = -1785627040;
							continue;
						case 4:
							value = (float)(XcAgIYSRAUIDcTEqffKxcNleWKLb - 1) * 10f;
							num = -1785627040;
							continue;
						default:
							return MathTools.Clamp(value, 0f, 100f);
						}
						break;
					}
				}
			}
		}

		public float LeftMotor
		{
			get
			{
				return vibrationMotors[0].Speed;
			}
			set
			{
				vibrationMotors[0].Speed = value;
			}
		}

		public float RightMotor
		{
			get
			{
				return vibrationMotors[1].Speed;
			}
			set
			{
				vibrationMotors[1].Speed = value;
			}
		}

		public float LightColorR
		{
			get
			{
				return lights[0].ColorR;
			}
			set
			{
				lights[0].ColorR = value;
			}
		}

		public float LightColorG
		{
			get
			{
				return lights[0].ColorG;
			}
			set
			{
				lights[0].ColorG = value;
			}
		}

		public float LightColorB
		{
			get
			{
				return lights[0].ColorB;
			}
			set
			{
				lights[0].ColorB = value;
			}
		}

		public float LightFlashOnDuration
		{
			get
			{
				return (int)lDAeEFEACIBdJHuMkGZMuJMMNltP;
			}
			set
			{
				lDAeEFEACIBdJHuMkGZMuJMMNltP = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				SVBExMdEoeiIzKSqvocQxLdJHgL = true;
				while (true)
				{
					int num = -2075366734;
					while (true)
					{
						switch (num ^ -2075366730)
						{
						case 3:
							break;
						default:
							return;
						case 4:
						{
							int num3;
							if (lDAeEFEACIBdJHuMkGZMuJMMNltP != 0)
							{
								num = -2075366729;
								num3 = num;
							}
							else
							{
								num = -2075366730;
								num3 = num;
							}
							continue;
						}
						case 2:
							ImlNCMuNvybLtizuApahnGozpMp = true;
							num = -2075366729;
							continue;
						case 0:
						{
							int num2;
							if (CbpwGKeHQuKNYaDcweqLTViKhth != 0)
							{
								num = -2075366729;
								num2 = num;
							}
							else
							{
								num = -2075366732;
								num2 = num;
							}
							continue;
						}
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		public float LightFlashOffDuration
		{
			get
			{
				return (int)CbpwGKeHQuKNYaDcweqLTViKhth;
			}
			set
			{
				CbpwGKeHQuKNYaDcweqLTViKhth = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				SVBExMdEoeiIzKSqvocQxLdJHgL = true;
				if (lDAeEFEACIBdJHuMkGZMuJMMNltP == 0 && CbpwGKeHQuKNYaDcweqLTViKhth == 0)
				{
					ImlNCMuNvybLtizuApahnGozpMp = true;
				}
			}
		}

		public Vector3 AccelerometerValue
		{
			get
			{
				return PBYTnLtaBlMFgIlDBgogfXizCJQ(accelerometers[0].rawValue);
			}
		}

		public Vector3 AccelerometerValueRaw
		{
			get
			{
				return new Vector3(accelerometers[0].rawValue[0], accelerometers[0].rawValue[1], accelerometers[0].rawValue[2]);
			}
		}

		public Vector3 GyroscopeValue
		{
			get
			{
				return HJAJCeeZJhXZonzHmnhvuAKrWPO(gyroscopes[0].events);
			}
		}

		public Vector3 GyroscopeValueRaw
		{
			get
			{
				return new Vector3(gyroscopes[0].rawValue[0], gyroscopes[0].rawValue[1], gyroscopes[0].rawValue[2]);
			}
		}

		public Vector3 LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);
				return HJAJCeeZJhXZonzHmnhvuAKrWPO(vector, cdMOhKTYSiCiqtMHZENXxGyULUz);
			}
		}

		public Vector3 LastGyroscopeValueRaw
		{
			get
			{
				return new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);
			}
		}

		public Quaternion Orientation
		{
			get
			{
				return ogpvvHIQgxriGDjgwZPJdLhupHC;
			}
		}

		public int MaxTouches
		{
			get
			{
				return 2;
			}
		}

		public void ResetOrientation()
		{
			ogpvvHIQgxriGDjgwZPJdLhupHC = Quaternion.identity;
		}

		public int GetTouchCount()
		{
			int num = 0;
			int num2 = 0;
			while (true)
			{
				int num3;
				int num4;
				if (num2 >= 2)
				{
					num3 = 1545439043;
					num4 = num3;
				}
				else
				{
					num3 = 1545439042;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ 0x5C1D8743)
					{
					case 4:
						num3 = 1545439042;
						continue;
					case 1:
						if (touchpads[0].values[num2].isTouching)
						{
							num++;
							num3 = 1545439040;
							continue;
						}
						goto case 3;
					case 3:
						num2++;
						num3 = 1545439041;
						continue;
					case 2:
						break;
					default:
						return num;
					}
					break;
				}
			}
		}

		public bool IsTouchingAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return false;
			}
			return touchpads[0].values[index].isTouching;
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return touchpads[0].IsTouching(touchId);
		}

		public int GetTouchIdAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return -1;
			}
			return touchpads[0].values[index].touchId;
		}

		public bool GetTouchPositionByIndex(int index, out Vector2 position)
		{
			position = default(Vector2);
			HIDTouchpad.TouchData[] values = default(HIDTouchpad.TouchData[]);
			int num;
			if (index >= 0)
			{
				if (index >= 2)
				{
					goto IL_000f;
				}
				values = touchpads[0].values;
				num = -2006926061;
				goto IL_0014;
			}
			goto IL_002d;
			IL_002d:
			return false;
			IL_0044:
			if (!values[index].isTouching)
			{
				return false;
			}
			position.x = values[index].positionX;
			position.y = values[index].positionY;
			return true;
			IL_000f:
			num = -2006926064;
			goto IL_0014;
			IL_0014:
			switch (num ^ -2006926062)
			{
			case 0:
				break;
			case 2:
				goto IL_002d;
			default:
				goto IL_0044;
			}
			goto IL_000f;
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			position = default(Vector2);
			if (!touchpads[0].IsTouching(touchId))
			{
				goto IL_0017;
			}
			HIDTouchpad.TouchData[] values = touchpads[0].values;
			int num = 1077566020;
			goto IL_001c;
			IL_001c:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x403A5A46)
				{
				case 0:
					break;
				case 5:
					return false;
				case 2:
					num2 = 0;
					num = 1077566018;
					continue;
				case 3:
					num2++;
					num = 1077566018;
					continue;
				case 1:
					if (values[num2].isTouching)
					{
						position.x = values[num2].positionX;
						position.y = values[num2].positionY;
						num = 1077566021;
						continue;
					}
					goto case 3;
				default:
					if (num2 >= values.Length)
					{
						return true;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0017;
			IL_0017:
			num = 1077566019;
			goto IL_001c;
		}

		public bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			HIDTouchpad.TouchData[] values = default(HIDTouchpad.TouchData[]);
			int num;
			if (index >= 0)
			{
				if (index >= 2)
				{
					goto IL_000e;
				}
				values = touchpads[0].values;
				num = -2048141783;
				goto IL_0013;
			}
			goto IL_0030;
			IL_0013:
			while (true)
			{
				switch (num ^ -2048141782)
				{
				case 0:
					break;
				case 2:
					goto IL_0030;
				case 3:
					goto IL_0047;
				default:
					return false;
				}
				break;
				IL_0047:
				if (!values[index].isTouching)
				{
					num = -2048141781;
					continue;
				}
				positionX = values[index].positionAbsX;
				positionY = values[index].positionAbsY;
				return true;
			}
			goto IL_000e;
			IL_0030:
			return false;
			IL_000e:
			num = -2048141784;
			goto IL_0013;
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			HIDTouchpad.TouchData[] values = default(HIDTouchpad.TouchData[]);
			int num2 = default(int);
			while (true)
			{
				int num = -755802951;
				while (true)
				{
					switch (num ^ -755802947)
					{
					case 0:
						break;
					case 4:
						if (!touchpads[0].IsTouching(touchId))
						{
							return false;
						}
						values = touchpads[0].values;
						num2 = 0;
						num = -755802946;
						continue;
					case 3:
						num = -755802948;
						continue;
					case 2:
						if (values[num2].isTouching)
						{
							positionX = values[num2].positionAbsX;
							positionY = values[num2].positionAbsY;
							num = -755802952;
							continue;
						}
						goto case 5;
					case 1:
					{
						int num3;
						if (num2 >= values.Length)
						{
							num = -755802949;
							num3 = num;
						}
						else
						{
							num = -755802945;
							num3 = num;
						}
						continue;
					}
					case 5:
						num2++;
						num = -755802948;
						continue;
					default:
						return true;
					}
					break;
				}
			}
		}

		public void StopLightFlash()
		{
			lDAeEFEACIBdJHuMkGZMuJMMNltP = 0;
			CbpwGKeHQuKNYaDcweqLTViKhth = 0;
			SVBExMdEoeiIzKSqvocQxLdJHgL = true;
			ImlNCMuNvybLtizuApahnGozpMp = true;
		}

		public void StopVibration()
		{
			int vibrationMotorCount = base.VibrationMotorCount;
			int num = 0;
			while (num < vibrationMotorCount)
			{
				while (true)
				{
					vibrationMotors[num].SpeedRaw = 0;
					num++;
					int num2 = 316316935;
					while (true)
					{
						switch (num2 ^ 0x12DA9D06)
						{
						case 0:
							num2 = 316316932;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0029;
						}
						break;
					}
					continue;
					end_IL_0029:
					break;
				}
			}
		}

		public DualShock4Driver(InitArgs initArgs)
		{
			int num3 = default(int);
			while (true)
			{
				int num = -336629925;
				while (true)
				{
					switch (num ^ -336629935)
					{
					case 18:
						break;
					default:
						return;
					case 15:
						if (cDxOMWGCJrOVpaFAIkSvyAMHgxE)
						{
							relYbiFMYILflqJGvvsJtvzLUlC = 17;
							xYOVSbsDXLanAEFopfMMiGuEnyT = 2;
							num = -336629932;
							continue;
						}
						goto case 5;
					case 1:
						if (num3 >= 14)
						{
							axes = new HIDAxis[6]
							{
								new HIDAxis(relYbiFMYILflqJGvvsJtvzLUlC, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 48,
									dataIndex = 1 + xYOVSbsDXLanAEFopfMMiGuEnyT,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 0,
									units = 0u,
									unitsExp = 0u
								}, false, 127),
								new HIDAxis(relYbiFMYILflqJGvvsJtvzLUlC, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 49,
									dataIndex = 2 + xYOVSbsDXLanAEFopfMMiGuEnyT,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 0,
									units = 0u,
									unitsExp = 0u
								}, false, 127),
								new HIDAxis(relYbiFMYILflqJGvvsJtvzLUlC, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 50,
									dataIndex = 3 + xYOVSbsDXLanAEFopfMMiGuEnyT,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 0,
									units = 0u,
									unitsExp = 0u
								}, false, 127),
								new HIDAxis(relYbiFMYILflqJGvvsJtvzLUlC, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 53,
									dataIndex = 4 + xYOVSbsDXLanAEFopfMMiGuEnyT,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 0,
									units = 0u,
									unitsExp = 0u
								}, false, 127),
								new HIDAxis(relYbiFMYILflqJGvvsJtvzLUlC, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 51,
									dataIndex = 8 + xYOVSbsDXLanAEFopfMMiGuEnyT,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 315,
									units = 0u,
									unitsExp = 0u
								}, false, 0),
								new HIDAxis(relYbiFMYILflqJGvvsJtvzLUlC, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 52,
									dataIndex = 9 + xYOVSbsDXLanAEFopfMMiGuEnyT,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 315,
									units = 0u,
									unitsExp = 0u
								}, false, 0)
							};
							num = -336629928;
							continue;
						}
						goto case 0;
					case 5:
						fRVeVpflMMKKYSVMeyDYHLzufRzU = 5 + xYOVSbsDXLanAEFopfMMiGuEnyT;
						cblzdKvKDXuufhxmLEZGBgDKpXI = 6 + xYOVSbsDXLanAEFopfMMiGuEnyT;
						SMuJmZmgBZargmpEZdYfIjrhpQe = 7 + xYOVSbsDXLanAEFopfMMiGuEnyT;
						buttons = new HIDButton[14];
						num3 = 0;
						num = -336629936;
						continue;
					case 13:
						if (VzzUgFqoelfzPSaspaXhBrvbttmJ < 23)
						{
							VzzUgFqoelfzPSaspaXhBrvbttmJ = 23;
							num = -336629926;
							continue;
						}
						goto case 11;
					case 7:
						shLANVAjdDDLRRTcoTrISsMNfcr = initArgs.hatZeroValue;
						oQjkYhEHzAyxjzJgeDbgBExOijx = initArgs.hatSpan;
						num = -336629927;
						continue;
					case 14:
						if (rsstixgQIJNSkPGeEeojspLRFRF)
						{
							VzzUgFqoelfzPSaspaXhBrvbttmJ = 78;
							num = -336629924;
							continue;
						}
						goto case 13;
					case 4:
						if (!rsstixgQIJNSkPGeEeojspLRFRF)
						{
							goto case 6;
						}
						LwwCfYrHYYIqqrfRbeSqPqWCpel.options |= OutputReportOptions.JuTyDNkOyqBtFUWaajwFrvtuaLrF;
						cDxOMWGCJrOVpaFAIkSvyAMHgxE = true;
						cDxOMWGCJrOVpaFAIkSvyAMHgxE = xFqYduKPrLutvTnMCKHHaIHLcTle(zpBwNyEewiHFbuFYIFwNwuraOAx.EKpTeocgxvNCIDckZbLvmCiYrDh);
						if (!cDxOMWGCJrOVpaFAIkSvyAMHgxE)
						{
							LwwCfYrHYYIqqrfRbeSqPqWCpel.options &= ~OutputReportOptions.JuTyDNkOyqBtFUWaajwFrvtuaLrF;
							num = -336629923;
							continue;
						}
						goto case 12;
					case 6:
						cDxOMWGCJrOVpaFAIkSvyAMHgxE = true;
						cDxOMWGCJrOVpaFAIkSvyAMHgxE = xFqYduKPrLutvTnMCKHHaIHLcTle(zpBwNyEewiHFbuFYIFwNwuraOAx.EKpTeocgxvNCIDckZbLvmCiYrDh);
						num = -336629923;
						continue;
					case 8:
						pUVDFYLvGTlVyKRgjKYluqeZBCW = initArgs.inputReportLength;
						num = -336629952;
						continue;
					case 16:
						LwwCfYrHYYIqqrfRbeSqPqWCpel = new OutputReport(QTvgeNabKIuYngzpDpvGaqKuMlN.Pointer, QTvgeNabKIuYngzpDpvGaqKuMlN.Length, VzzUgFqoelfzPSaspaXhBrvbttmJ);
						lights = new HIDLight[1]
						{
							new HIDLight(11, 24, 28)
						};
						lights[0].ValueChangedEvent += llIxbkOuVgUvQDMKzRpzNixmQKl;
						vibrationMotors = new HIDVibrationMotor[2]
						{
							new HIDVibrationMotor(0, 255),
							new HIDVibrationMotor(0, 255)
						};
						vibrationMotors[0].ValueChangedEvent += llIxbkOuVgUvQDMKzRpzNixmQKl;
						num = -336629934;
						continue;
					case 11:
						RBWbtggyAdLBBLQKDwGIqmFtGqY = new NativeBuffer(64);
						QTvgeNabKIuYngzpDpvGaqKuMlN = new NativeBuffer(VzzUgFqoelfzPSaspaXhBrvbttmJ);
						num = -336629951;
						continue;
					case 3:
						vibrationMotors[1].ValueChangedEvent += llIxbkOuVgUvQDMKzRpzNixmQKl;
						num = -336629931;
						continue;
					case 0:
						buttons[num3] = new HIDButton(relYbiFMYILflqJGvvsJtvzLUlC, new HIDControllerElement.HIDInfo
						{
							usagePage = 9,
							usage = (ushort)num3
						});
						num3++;
						num = -336629936;
						continue;
					case 9:
						hats = new HIDHat[1]
						{
							new HIDHat(relYbiFMYILflqJGvvsJtvzLUlC, new HIDControllerElement.HIDInfo
							{
								usagePage = 1,
								usage = 57,
								dataIndex = 5 + xYOVSbsDXLanAEFopfMMiGuEnyT,
								bitSize = 4,
								logicalMin = 0,
								logicalMax = 7,
								physicalMin = 0,
								physicalMax = 315,
								units = 20u,
								unitsExp = 0u
							}, jEJrBCvqKLicDHqBgivtbyYwZSAn)
						};
						accelerometers = new HIDAccelerometer[1]
						{
							new HIDAccelerometer(relYbiFMYILflqJGvvsJtvzLUlC, new HIDControllerElement.HIDInfo
							{
								usagePage = 1,
								dataIndex = 19 + xYOVSbsDXLanAEFopfMMiGuEnyT,
								bitSize = 48
							}, 3, tTxBEvQArDfujdJhyvNCNVtxTSQ)
						};
						gyroscopes = new HIDGyroscope[1]
						{
							new HIDGyroscope(initArgs.updateLoopSetting, relYbiFMYILflqJGvvsJtvzLUlC, new HIDControllerElement.HIDInfo
							{
								usagePage = 1,
								dataIndex = 13 + xYOVSbsDXLanAEFopfMMiGuEnyT,
								bitSize = 48
							}, 3, 25, aKaRTybySzNNJvRtOWgRQczRHob, lojbMUtTDidIMsmkjlNeJkwFCzaF)
						};
						touchpads = new HIDTouchpad[1]
						{
							new HIDTouchpad(relYbiFMYILflqJGvvsJtvzLUlC, new HIDTouchpad.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new HIDControllerElement.HIDInfo
							{
								usagePage = 1,
								dataIndex = 35 + xYOVSbsDXLanAEFopfMMiGuEnyT,
								bitSize = 48
							}, cqdCiOxcSfgGhzLajVQMUwIYBrj)
						};
						uCWbeRJjkuHsLjtluPpZfbcinVcM = ReInput.realTime;
						num = -336629933;
						continue;
					case 10:
						if (initArgs == null)
						{
							throw new ArgumentNullException("initArgs");
						}
						goto case 7;
					case 12:
					{
						relYbiFMYILflqJGvvsJtvzLUlC = 1;
						xYOVSbsDXLanAEFopfMMiGuEnyT = 0;
						int num2;
						if (rsstixgQIJNSkPGeEeojspLRFRF)
						{
							num = -336629922;
							num2 = num;
						}
						else
						{
							num = -336629932;
							num2 = num;
						}
						continue;
					}
					case 17:
						VzzUgFqoelfzPSaspaXhBrvbttmJ = initArgs.outputReportLength;
						xVVyGgNsqweTIzstWzQJegvUeuI = initArgs.synchronousWriteOutputReportDelegate;
						CjDBJyHuwywJegdtLbKnPIGyviWF = initArgs.asynchronousWriteOutputReportDelegate;
						rsstixgQIJNSkPGeEeojspLRFRF = initArgs.connectionType == DeviceConnectionType.HkHOtQTdmHcCvbpbnishLoIlAPNG;
						num = -336629921;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			UFDAYQzaGQaACGdtDkBAwNMvwrn();
			BVGIHfiDpXfcMFkJJPnnyGLJVSz(zpBwNyEewiHFbuFYIFwNwuraOAx.syPJIPLSIxcExZeAaBkiQLsdgAa);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, float timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				goto IL_0010;
			}
			if (inputReportLength < RBWbtggyAdLBBLQKDwGIqmFtGqY.Length)
			{
				return false;
			}
			float realTime = ReInput.realTime;
			int num = -1090376083;
			goto IL_0015;
			IL_0010:
			num = -1090376086;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ -1090376087)
				{
				case 0:
					break;
				case 1:
					OmvEduKEMDwCfGsAUMYnJwvhRxA(RBWbtggyAdLBBLQKDwGIqmFtGqY, realTime);
					num = -1090376081;
					continue;
				case 7:
					RBWbtggyAdLBBLQKDwGIqmFtGqY.Write(inputReportPtr, inputReportLength, RBWbtggyAdLBBLQKDwGIqmFtGqY.Length);
					NrMsFNtoLqTXOhgyAWRYLMxDiCO(RBWbtggyAdLBBLQKDwGIqmFtGqY);
					num = -1090376088;
					continue;
				case 5:
					uCWbeRJjkuHsLjtluPpZfbcinVcM = realTime;
					num = -1090376082;
					continue;
				case 4:
					XYuubApnwdbaDdjmjPNZoEVsIlq = realTime - uCWbeRJjkuHsLjtluPpZfbcinVcM;
					num = -1090376084;
					continue;
				case 6:
					sZiHDSjwxSeuMhlAVhrPPNrmkVY(axes, RBWbtggyAdLBBLQKDwGIqmFtGqY, realTime);
					sZiHDSjwxSeuMhlAVhrPPNrmkVY(hats, RBWbtggyAdLBBLQKDwGIqmFtGqY, realTime);
					sZiHDSjwxSeuMhlAVhrPPNrmkVY(accelerometers, RBWbtggyAdLBBLQKDwGIqmFtGqY, realTime);
					sZiHDSjwxSeuMhlAVhrPPNrmkVY(gyroscopes, RBWbtggyAdLBBLQKDwGIqmFtGqY, realTime);
					num = -1090376085;
					continue;
				case 3:
					return false;
				default:
					sZiHDSjwxSeuMhlAVhrPPNrmkVY(touchpads, RBWbtggyAdLBBLQKDwGIqmFtGqY, realTime);
					XcAgIYSRAUIDcTEqffKxcNleWKLb = (byte)(RBWbtggyAdLBBLQKDwGIqmFtGqY[30 + xYOVSbsDXLanAEFopfMMiGuEnyT] & 0xF);
					FZBZrSHBuHlBRxgCraXPSBWsOJd();
					return true;
				}
				break;
			}
			goto IL_0010;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualShock4Extension(this);
		}

		private void BVGIHfiDpXfcMFkJJPnnyGLJVSz(zpBwNyEewiHFbuFYIFwNwuraOAx P_0)
		{
			if (SVBExMdEoeiIzKSqvocQxLdJHgL)
			{
				xFqYduKPrLutvTnMCKHHaIHLcTle(P_0);
				SVBExMdEoeiIzKSqvocQxLdJHgL = false;
			}
		}

		private bool xFqYduKPrLutvTnMCKHHaIHLcTle(zpBwNyEewiHFbuFYIFwNwuraOAx P_0)
		{
			SasYrcdYnXAkLJvlqoJSdXavqFx();
			bool result = fbUvchqVJAMRZmINxLfcrXvFufv(P_0);
			while (true)
			{
				int num = -451681225;
				while (true)
				{
					switch (num ^ -451681226)
					{
					case 3:
						break;
					case 1:
						if (ImlNCMuNvybLtizuApahnGozpMp)
						{
							result = fbUvchqVJAMRZmINxLfcrXvFufv(P_0);
							num = -451681228;
							continue;
						}
						goto default;
					case 2:
						ImlNCMuNvybLtizuApahnGozpMp = false;
						num = -451681226;
						continue;
					default:
						return result;
					}
					break;
				}
			}
		}

		private void SasYrcdYnXAkLJvlqoJSdXavqFx()
		{
			if (rsstixgQIJNSkPGeEeojspLRFRF)
			{
				goto IL_000b;
			}
			goto IL_0148;
			IL_000b:
			int num = 947350981;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num ^ 0x38776DCF)
				{
				case 0:
					break;
				case 10:
					goto IL_004c;
				case 8:
					QTvgeNabKIuYngzpDpvGaqKuMlN[5] = (byte)vibrationMotors[0].SpeedRaw;
					QTvgeNabKIuYngzpDpvGaqKuMlN[6] = lights[0].ColorRRaw;
					QTvgeNabKIuYngzpDpvGaqKuMlN[7] = lights[0].ColorGRaw;
					num = 947350985;
					continue;
				case 6:
					QTvgeNabKIuYngzpDpvGaqKuMlN[8] = lights[0].ColorBRaw;
					QTvgeNabKIuYngzpDpvGaqKuMlN[9] = lDAeEFEACIBdJHuMkGZMuJMMNltP;
					QTvgeNabKIuYngzpDpvGaqKuMlN[10] = CbpwGKeHQuKNYaDcweqLTViKhth;
					num = 947350986;
					continue;
				case 3:
					QTvgeNabKIuYngzpDpvGaqKuMlN[23] = byte.MaxValue;
					QTvgeNabKIuYngzpDpvGaqKuMlN[24] = 0;
					return;
				case 7:
					QTvgeNabKIuYngzpDpvGaqKuMlN[21] = 53;
					num = 947350990;
					continue;
				case 2:
					goto IL_0148;
				case 5:
					QTvgeNabKIuYngzpDpvGaqKuMlN[19] = 53;
					QTvgeNabKIuYngzpDpvGaqKuMlN[20] = 53;
					QTvgeNabKIuYngzpDpvGaqKuMlN[21] = byte.MaxValue;
					num = 947350987;
					continue;
				case 1:
					QTvgeNabKIuYngzpDpvGaqKuMlN[22] = 53;
					num = 947350988;
					continue;
				case 9:
					QTvgeNabKIuYngzpDpvGaqKuMlN[0] = 17;
					QTvgeNabKIuYngzpDpvGaqKuMlN[1] = 128;
					QTvgeNabKIuYngzpDpvGaqKuMlN[3] = byte.MaxValue;
					QTvgeNabKIuYngzpDpvGaqKuMlN[6] = (byte)vibrationMotors[1].SpeedRaw;
					QTvgeNabKIuYngzpDpvGaqKuMlN[7] = (byte)vibrationMotors[0].SpeedRaw;
					QTvgeNabKIuYngzpDpvGaqKuMlN[8] = lights[0].ColorRRaw;
					QTvgeNabKIuYngzpDpvGaqKuMlN[9] = lights[0].ColorGRaw;
					QTvgeNabKIuYngzpDpvGaqKuMlN[10] = lights[0].ColorBRaw;
					QTvgeNabKIuYngzpDpvGaqKuMlN[11] = lDAeEFEACIBdJHuMkGZMuJMMNltP;
					QTvgeNabKIuYngzpDpvGaqKuMlN[12] = CbpwGKeHQuKNYaDcweqLTViKhth;
					num = 947350984;
					continue;
				default:
					QTvgeNabKIuYngzpDpvGaqKuMlN[22] = 0;
					return;
				}
				break;
				IL_004c:
				int num2;
				if (!cDxOMWGCJrOVpaFAIkSvyAMHgxE)
				{
					num = 947350989;
					num2 = num;
				}
				else
				{
					num = 947350982;
					num2 = num;
				}
			}
			goto IL_000b;
			IL_0148:
			QTvgeNabKIuYngzpDpvGaqKuMlN[0] = 5;
			QTvgeNabKIuYngzpDpvGaqKuMlN[1] = byte.MaxValue;
			QTvgeNabKIuYngzpDpvGaqKuMlN[4] = (byte)vibrationMotors[1].SpeedRaw;
			num = 947350983;
			goto IL_0010;
		}

		private bool fbUvchqVJAMRZmINxLfcrXvFufv(zpBwNyEewiHFbuFYIFwNwuraOAx P_0)
		{
			rdxGqopNFLdzOdtKHjjNgaOIePAr = ReInput.realTime + 4f;
			while (true)
			{
				int num = -276018234;
				while (true)
				{
					switch (num ^ -276018233)
					{
					case 0:
						break;
					case 1:
						switch (P_0)
						{
						case zpBwNyEewiHFbuFYIFwNwuraOAx.EKpTeocgxvNCIDckZbLvmCiYrDh:
							num = -276018235;
							break;
						case zpBwNyEewiHFbuFYIFwNwuraOAx.syPJIPLSIxcExZeAaBkiQLsdgAa:
							if (CjDBJyHuwywJegdtLbKnPIGyviWF == null)
							{
								num = -276018236;
								break;
							}
							CjDBJyHuwywJegdtLbKnPIGyviWF(LwwCfYrHYYIqqrfRbeSqPqWCpel);
							return true;
						default:
							throw new NotImplementedException();
						}
						continue;
					case 2:
						if (xVVyGgNsqweTIzstWzQJegvUeuI == null)
						{
							return false;
						}
						return xVVyGgNsqweTIzstWzQJegvUeuI(LwwCfYrHYYIqqrfRbeSqPqWCpel);
					default:
						return false;
					}
					break;
				}
			}
		}

		private void OmvEduKEMDwCfGsAUMYnJwvhRxA(NativeBuffer P_0, float P_1)
		{
			byte b = P_0[fRVeVpflMMKKYSVMeyDYHLzufRzU];
			while (true)
			{
				int num = 1194925782;
				while (true)
				{
					switch (num ^ 0x47391ED7)
					{
					case 2:
						break;
					case 1:
						buttons[0].SetValue((b & 0x10) != 0, P_1);
						buttons[1].SetValue((b & 0x20) != 0, P_1);
						num = 1194925780;
						continue;
					case 3:
						buttons[2].SetValue((b & 0x40) != 0, P_1);
						buttons[3].SetValue((b & 0x80) != 0, P_1);
						b = P_0[cblzdKvKDXuufhxmLEZGBgDKpXI];
						buttons[4].SetValue((b & 1) != 0, P_1);
						buttons[5].SetValue((b & 2) != 0, P_1);
						buttons[6].SetValue((b & 4) != 0, P_1);
						buttons[7].SetValue((b & 8) != 0, P_1);
						num = 1194925783;
						continue;
					default:
						buttons[8].SetValue((b & 0x10) != 0, P_1);
						buttons[9].SetValue((b & 0x20) != 0, P_1);
						buttons[10].SetValue((b & 0x40) != 0, P_1);
						buttons[11].SetValue((b & 0x80) != 0, P_1);
						b = P_0[SMuJmZmgBZargmpEZdYfIjrhpQe];
						buttons[12].SetValue((b & 1) != 0, P_1);
						buttons[13].SetValue((b & 2) != 0, P_1);
						return;
					}
					break;
				}
			}
		}

		private void sZiHDSjwxSeuMhlAVhrPPNrmkVY(HIDControllerElement[] P_0, NativeBuffer P_1, float P_2)
		{
			int num = 0;
			while (num < P_0.Length)
			{
				while (true)
				{
					P_0[num].UpdateValue(P_1, P_2);
					num++;
					int num2 = 185373042;
					while (true)
					{
						switch (num2 ^ 0xB0C9172)
						{
						case 2:
							num2 = 185373043;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0022;
						}
						break;
					}
					continue;
					end_IL_0022:
					break;
				}
			}
		}

		private void UFDAYQzaGQaACGdtDkBAwNMvwrn()
		{
			if (!isVibrating)
			{
				return;
			}
			while (true)
			{
				int num = -1338281908;
				while (true)
				{
					switch (num ^ -1338281907)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						if (ReInput.realTime >= rdxGqopNFLdzOdtKHjjNgaOIePAr)
						{
							goto IL_0033;
						}
						return;
					case 0:
						return;
					}
					break;
					IL_0033:
					SVBExMdEoeiIzKSqvocQxLdJHgL = true;
					num = -1338281907;
				}
			}
		}

		private void NrMsFNtoLqTXOhgyAWRYLMxDiCO(NativeBuffer P_0)
		{
			if (!cDxOMWGCJrOVpaFAIkSvyAMHgxE)
			{
				goto IL_000b;
			}
			goto IL_00d9;
			IL_000b:
			int num = 682532903;
			goto IL_0010;
			IL_0010:
			float num3 = default(float);
			ushort num2 = default(ushort);
			while (true)
			{
				switch (num ^ 0x28AEA022)
				{
				case 3:
					break;
				case 5:
					return;
				case 0:
					goto IL_0050;
				case 2:
					num3 = 0f;
					num = 682532900;
					continue;
				case 7:
					num3 = 1f / (float)(num2 - LSbcuKnEchIpfFsQoDrxlnOkALw);
					num = 682532899;
					continue;
				case 9:
					if (num2 < LSbcuKnEchIpfFsQoDrxlnOkALw)
					{
						num3 = 1f / (float)(num2 + 65535 - LSbcuKnEchIpfFsQoDrxlnOkALw);
						num = 682532900;
						continue;
					}
					goto IL_0050;
				case 1:
					num = 682532900;
					continue;
				case 6:
					LSbcuKnEchIpfFsQoDrxlnOkALw = num2;
					cdMOhKTYSiCiqtMHZENXxGyULUz = num3;
					num = 682532902;
					continue;
				case 8:
					goto IL_00d9;
				default:
					cdMOhKTYSiCiqtMHZENXxGyULUz = XYuubApnwdbaDdjmjPNZoEVsIlq;
					return;
				}
				break;
				IL_0050:
				int num4;
				if (num2 > LSbcuKnEchIpfFsQoDrxlnOkALw)
				{
					num = 682532901;
					num4 = num;
				}
				else
				{
					num = 682532896;
					num4 = num;
				}
			}
			goto IL_000b;
			IL_00d9:
			num2 = RBWbtggyAdLBBLQKDwGIqmFtGqY.ReadUShort(10 + xYOVSbsDXLanAEFopfMMiGuEnyT);
			num = 682532907;
			goto IL_0010;
		}

		private void FZBZrSHBuHlBRxgCraXPSBWsOJd()
		{
			if (cDxOMWGCJrOVpaFAIkSvyAMHgxE && !(cdMOhKTYSiCiqtMHZENXxGyULUz <= 0f))
			{
				Vector3 vector = HJAJCeeZJhXZonzHmnhvuAKrWPO(new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]), cdMOhKTYSiCiqtMHZENXxGyULUz);
				Vector3 vector2 = new Vector3(accelerometers[0].rawValue[0] * -1f, accelerometers[0].rawValue[1] * -1f, accelerometers[0].rawValue[2] * -1f);
				ModXlaEDTdYTjidWKOOwSYTmcwC(vector2, vector);
			}
		}

		private void ModXlaEDTdYTjidWKOOwSYTmcwC(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			bFDDCMFPHzfBqEoEaYPljPrEFHLM bFDDCMFPHzfBqEoEaYPljPrEFHLM2 = default(bFDDCMFPHzfBqEoEaYPljPrEFHLM);
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && vZKvzFMvwviBWIqcuOeIwJdgwrT(P_0, out bFDDCMFPHzfBqEoEaYPljPrEFHLM2))
			{
				goto IL_0033;
			}
			goto IL_00da;
			IL_0038:
			int num;
			Quaternion b = default(Quaternion);
			Quaternion a = default(Quaternion);
			while (true)
			{
				switch (num ^ 0x2A38305)
				{
				case 2:
					break;
				default:
					return;
				case 9:
					goto IL_0074;
				case 3:
					b = EvklhxUZWuRXcxLALwTTgdSXcLt(P_0, a.eulerAngles.y);
					num = 44270339;
					continue;
				case 10:
					b = HEZeMNGAwBdTBmAwFSnOivVBCcof(P_0);
					num = 44270339;
					continue;
				case 8:
					mEqBbuFdknGLTUzytACtxVkVUgM *= quaternion;
					num = 44270340;
					continue;
				case 7:
					goto IL_00da;
				case 0:
					b = Quaternion.identity;
					num = 44270339;
					continue;
				case 1:
					goto IL_0119;
				case 4:
					a = ogpvvHIQgxriGDjgwZPJdLhupHC * quaternion;
					if (!viPwTjtdmzCmHFBjiOyKKzwIBcC)
					{
						viPwTjtdmzCmHFBjiOyKKzwIBcC = true;
						mEqBbuFdknGLTUzytACtxVkVUgM = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
						num = 44270349;
						continue;
					}
					goto case 8;
				case 6:
					ogpvvHIQgxriGDjgwZPJdLhupHC = Quaternion.Lerp(a, b, 0.01999998f);
					return;
				case 5:
					return;
				}
				break;
				IL_0119:
				int num2;
				if ((bFDDCMFPHzfBqEoEaYPljPrEFHLM2 & bFDDCMFPHzfBqEoEaYPljPrEFHLM.ArUkprxFsGMtZtnJwGanYDIJBWb) == 0)
				{
					num = 44270348;
					num2 = num;
				}
				else
				{
					num = 44270342;
					num2 = num;
				}
				continue;
				IL_0074:
				int num3;
				if ((bFDDCMFPHzfBqEoEaYPljPrEFHLM2 & bFDDCMFPHzfBqEoEaYPljPrEFHLM.iirGQdEwriPMGDPBwDbLcEJUBwV) != bFDDCMFPHzfBqEoEaYPljPrEFHLM.iOlZgcuFwLCPNAjSgaSDuxucio)
				{
					num = 44270351;
					num3 = num;
				}
				else
				{
					num = 44270341;
					num3 = num;
				}
			}
			goto IL_0033;
			IL_00da:
			ogpvvHIQgxriGDjgwZPJdLhupHC *= quaternion;
			if (viPwTjtdmzCmHFBjiOyKKzwIBcC)
			{
				viPwTjtdmzCmHFBjiOyKKzwIBcC = false;
				num = 44270336;
				goto IL_0038;
			}
			return;
			IL_0033:
			num = 44270337;
			goto IL_0038;
		}

		private static Quaternion jmQZDUsKKiJojLdhkGVGGOmKFST(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = new Vector3(P_0.x, P_0.y, P_0.z);
			Vector3 vector2 = DlKjRiyUYvlKrUZkuMadbjQdbsJi(vector, P_1);
			return new Quaternion(vector2.x, vector2.y, vector2.z, P_0.w);
		}

		private static Vector3 DlKjRiyUYvlKrUZkuMadbjQdbsJi(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion ztqJOCgujyWruNFWRnMiCEDNMjO(Quaternion P_0, vOgaRorzkksunQUGmCfRIAUbpUU P_1)
		{
			Vector4 vector = default(Vector4);
			if (MathTools.Approximately(P_0.w, 0f))
			{
				goto IL_001d;
			}
			goto IL_0068;
			IL_001d:
			int num = -1645070809;
			goto IL_0022;
			IL_0022:
			while (true)
			{
				switch (num ^ -1645070813)
				{
				case 2:
					break;
				case 4:
					if (MathTools.Approximately(P_0[(int)P_1], 0f))
					{
						P_0 = Quaternion.identity;
						num = -1645070814;
						continue;
					}
					goto IL_0068;
				case 3:
					goto IL_0068;
				case 0:
					P_0 = new Quaternion(vector[0], vector[1], vector[2], vector[3]);
					num = -1645070814;
					continue;
				default:
					return P_0;
				}
				break;
			}
			goto IL_001d;
			IL_0068:
			float num2 = P_0[(int)P_1];
			float num3 = MathTools.Sqrt(P_0.w * P_0.w + num2 * num2);
			vector[3] = P_0.w / num3;
			vector[(int)P_1] = num2 / num3;
			num = -1645070813;
			goto IL_0022;
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			float num = quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z + quaternion.w * quaternion.w;
			float num2 = 1f / num;
			Quaternion result = default(Quaternion);
			result.x = (0f - quaternion.x) * num2;
			result.y = (0f - quaternion.y) * num2;
			result.z = (0f - quaternion.z) * num2;
			while (true)
			{
				int num3 = -994340565;
				while (true)
				{
					switch (num3 ^ -994340566)
					{
					case 0:
						break;
					case 1:
						goto IL_0099;
					default:
						return result;
					}
					break;
					IL_0099:
					result.w = quaternion.w * num2;
					num3 = -994340568;
				}
			}
		}

		private float HbtbfupWlzCTwVkzylLawPeacjf(float P_0, float P_1)
		{
			P_0 = MathTools.ClampAngle360(P_0);
			P_1 = MathTools.ClampAngle360(P_1);
			if (P_0 == P_1)
			{
				return 0f;
			}
			if (P_0 >= 180f)
			{
				P_0 -= 360f;
				goto IL_002b;
			}
			goto IL_0049;
			IL_0049:
			int num;
			if (P_1 >= 180f)
			{
				P_1 -= 360f;
				num = -298960160;
				goto IL_0030;
			}
			goto IL_0061;
			IL_0061:
			return P_0 - P_1;
			IL_002b:
			num = -298960157;
			goto IL_0030;
			IL_0030:
			switch (num ^ -298960158)
			{
			case 0:
				break;
			case 1:
				goto IL_0049;
			default:
				goto IL_0061;
			}
			goto IL_002b;
		}

		private Vector3 NYXCFKvtuWLsjxNGIIYcHPTfKsVK(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num3 = default(float);
			float x = default(float);
			while (true)
			{
				int num2 = -909915589;
				while (true)
				{
					switch (num2 ^ -909915590)
					{
					case 0:
						break;
					case 1:
					{
						float x2 = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
						num3 = MathTools.Atan2(P_0.x, x2);
						num2 = -909915592;
						continue;
					}
					case 2:
						x = num * 57.29578f + 180f;
						num2 = -909915591;
						continue;
					default:
					{
						float z = (0f - num3) * 57.29578f;
						return new Vector3(x, P_1, z);
					}
					}
					break;
				}
			}
		}

		private Quaternion EvklhxUZWuRXcxLALwTTgdSXcLt(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = default(float);
			while (true)
			{
				int num2 = 1241087066;
				while (true)
				{
					switch (num2 ^ 0x49F97C5B)
					{
					case 2:
						break;
					case 1:
						goto IL_0032;
					default:
					{
						float num3 = MathTools.Atan2(P_0.x, x);
						float x2 = num * 57.29578f + 180f;
						float z = (0f - num3) * 57.29578f;
						return Quaternion.Euler(x2, P_1, z);
					}
					}
					break;
					IL_0032:
					x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
					num2 = 1241087067;
				}
			}
		}

		private Quaternion HEZeMNGAwBdTBmAwFSnOivVBCcof(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
			float num2 = MathTools.Atan2(P_0.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			Quaternion quaternion = Quaternion.Euler(0f, 0f, z) * Quaternion.Euler(x2, 0f, 0f);
			if (P_1 != 0f)
			{
				return quaternion * Quaternion.Euler(0f, P_1, 0f);
			}
			return quaternion;
		}

		private float lCVLNfdabgsklYPgIEqwZPIlBIs(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool aPmXSiHHIZMYXMzBRFIqCqulcnbF(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool vZKvzFMvwviBWIqcuOeIwJdgwrT(Vector3 P_0, out bFDDCMFPHzfBqEoEaYPljPrEFHLM P_1)
		{
			P_0.Normalize();
			P_1 = bFDDCMFPHzfBqEoEaYPljPrEFHLM.iOlZgcuFwLCPNAjSgaSDuxucio;
			bool result = default(bool);
			while (true)
			{
				int num = -1501276920;
				while (true)
				{
					switch (num ^ -1501276916)
					{
					case 3:
						break;
					case 2:
						if (oubRdCMmQiNDlxnLSFDqbjwGrFT(P_0))
						{
							result = true;
							P_1 |= bFDDCMFPHzfBqEoEaYPljPrEFHLM.iirGQdEwriPMGDPBwDbLcEJUBwV;
							num = -1501276915;
							continue;
						}
						goto default;
					case 0:
						P_1 |= bFDDCMFPHzfBqEoEaYPljPrEFHLM.ArUkprxFsGMtZtnJwGanYDIJBWb;
						num = -1501276914;
						continue;
					case 4:
						result = false;
						if (FSBhokyxIZLVEPZzVCVhowJzvtV(P_0))
						{
							result = true;
							num = -1501276916;
							continue;
						}
						goto case 2;
					default:
						return result;
					}
					break;
				}
			}
		}

		private bool FSBhokyxIZLVEPZzVCVhowJzvtV(Vector3 P_0)
		{
			if (P_0.y > 0f)
			{
				return false;
			}
			if (Vector3.Angle(Vector3.down, P_0) > 45f)
			{
				return false;
			}
			return true;
		}

		private bool oubRdCMmQiNDlxnLSFDqbjwGrFT(Vector3 P_0)
		{
			return false;
		}

		private Vector3 PBYTnLtaBlMFgIlDBgogfXizCJQ(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 HJAJCeeZJhXZonzHmnhvuAKrWPO(ExpandableArray_DataContainer<HIDGyroscope.fUKOPkxWszrPBUNUmlhKThawZdL> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			int num2 = default(int);
			while (true)
			{
				int num = 1911664273;
				while (true)
				{
					switch (num ^ 0x71F1AE90)
					{
					case 3:
						break;
					case 1:
						num2 = 0;
						num = 1911664276;
						continue;
					case 0:
					{
						HIDGyroscope.fUKOPkxWszrPBUNUmlhKThawZdL fUKOPkxWszrPBUNUmlhKThawZdL = P_0[num2];
						result += HJAJCeeZJhXZonzHmnhvuAKrWPO(fUKOPkxWszrPBUNUmlhKThawZdL.ZIjTqFZkYVUthlHkiaPIqluvIsp, fUKOPkxWszrPBUNUmlhKThawZdL.obiuMVBNsaFUWKmAOQSExGWXESCf);
						num2++;
						num = 1911664276;
						continue;
					}
					case 4:
					{
						int num3;
						if (num2 >= count)
						{
							num = 1911664274;
							num3 = num;
						}
						else
						{
							num = 1911664272;
							num3 = num;
						}
						continue;
					}
					default:
						return result;
					}
					break;
				}
			}
		}

		private Vector3 HJAJCeeZJhXZonzHmnhvuAKrWPO(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.05595291f * P_1;
		}

		private int jEJrBCvqKLicDHqBgivtbyYwZSAn(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void tTxBEvQArDfujdJhyvNCNVtxTSQ(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void aKaRTybySzNNJvRtOWgRQczRHob(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			while (true)
			{
				int num = -1420488018;
				while (true)
				{
					switch (num ^ -1420488020)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0029;
					case 1:
						return;
					}
					break;
					IL_0029:
					P_1[1] = BitConverter.ToInt16(P_0, 2);
					P_1[2] = BitConverter.ToInt16(P_0, 4);
					num = -1420488019;
				}
			}
		}

		private float lojbMUtTDidIMsmkjlNeJkwFCzaF()
		{
			return cdMOhKTYSiCiqtMHZENXxGyULUz;
		}

		private void cqdCiOxcSfgGhzLajVQMUwIYBrj(NativeBuffer P_0, HIDTouchpad.TouchData[] P_1)
		{
			int num = 35 + xYOVSbsDXLanAEFopfMMiGuEnyT;
			int positionRawX = P_0[1 + num] + (P_0[2 + num] & 0xF) * 255;
			int positionRawY = ((P_0[2 + num] & 0xF0) >> 4) + P_0[3 + num] * 16;
			int positionRawX2 = default(int);
			int positionRawY2 = default(int);
			bool flag2 = default(bool);
			byte b = default(byte);
			bool flag = default(bool);
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num2 = 116143383;
				while (true)
				{
					switch (num2 ^ 0x6EC3512)
					{
					case 2:
						break;
					case 5:
						positionRawX2 = P_0[5 + num] + (P_0[6 + num] & 0xF) * 255;
						positionRawY2 = ((P_0[6 + num] & 0xF0) >> 4) + P_0[7 + num] * 16;
						num2 = 116143378;
						continue;
					case 1:
					{
						flag2 = b < 128;
						byte b2 = P_0[num + 4];
						flag = b2 < 128;
						num4 = b & 0x7F;
						num3 = b2 & 0x7F;
						P_1[0].isTouching = flag2;
						num2 = 116143382;
						continue;
					}
					case 0:
						b = P_0[num];
						num2 = 116143379;
						continue;
					case 4:
						P_1[0].touchId = ijQlIoxcCedNVfMbEGNzptLRHUB(0, flag2, num4);
						P_1[0].positionRawX = positionRawX;
						num2 = 116143377;
						continue;
					default:
						P_1[0].positionRawY = positionRawY;
						P_1[1].isTouching = flag;
						P_1[1].touchId = ijQlIoxcCedNVfMbEGNzptLRHUB(1, flag, num3);
						P_1[1].positionRawX = positionRawX2;
						P_1[1].positionRawY = positionRawY2;
						return;
					}
					break;
				}
			}
		}

		private int ijQlIoxcCedNVfMbEGNzptLRHUB(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				goto IL_0003;
			}
			int num = default(int);
			int num2;
			if (P_2 != VkIgFCjLijMBHeAtScOaLRFIIYlX[P_0])
			{
				num = ejJMwWFoyTNZUgtIpJJHvYKRrlC;
				int num3;
				if (ejJMwWFoyTNZUgtIpJJHvYKRrlC != int.MaxValue)
				{
					num2 = -398729715;
					num3 = num2;
				}
				else
				{
					num2 = -398729713;
					num3 = num2;
				}
				goto IL_0008;
			}
			return qBhOgmvBergqvNfdfRwLNkKCEre[P_0];
			IL_0008:
			while (true)
			{
				switch (num2 ^ -398729713)
				{
				case 3:
					break;
				case 2:
					ejJMwWFoyTNZUgtIpJJHvYKRrlC++;
					num2 = -398729718;
					continue;
				case 4:
					return -1;
				case 0:
					ejJMwWFoyTNZUgtIpJJHvYKRrlC = 0;
					num2 = -398729718;
					continue;
				case 1:
					qBhOgmvBergqvNfdfRwLNkKCEre[P_0] = -1;
					VkIgFCjLijMBHeAtScOaLRFIIYlX[P_0] = P_2;
					num2 = -398729717;
					continue;
				default:
					VkIgFCjLijMBHeAtScOaLRFIIYlX[P_0] = P_2;
					qBhOgmvBergqvNfdfRwLNkKCEre[P_0] = num;
					return num;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num2 = -398729714;
			goto IL_0008;
		}

		private void llIxbkOuVgUvQDMKzRpzNixmQKl()
		{
			SVBExMdEoeiIzKSqvocQxLdJHgL = true;
		}

		~DualShock4Driver()
		{
			Dispose(false);
		}

		protected override void Dispose(bool disposing)
		{
			if (base.disposed)
			{
				return;
			}
			while (true)
			{
				base.Dispose(disposing);
				int num;
				int num2;
				if (!disposing)
				{
					num = -2101375877;
					num2 = num;
				}
				else
				{
					num = -2101375875;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -2101375879)
					{
					case 0:
						num = -2101375878;
						continue;
					default:
						return;
					case 3:
						break;
					case 4:
						StopVibration();
						BVGIHfiDpXfcMFkJJPnnyGLJVSz(zpBwNyEewiHFbuFYIFwNwuraOAx.EKpTeocgxvNCIDckZbLvmCiYrDh);
						if (RBWbtggyAdLBBLQKDwGIqmFtGqY != null)
						{
							RBWbtggyAdLBBLQKDwGIqmFtGqY.Dispose();
							num = -2101375880;
							continue;
						}
						goto case 1;
					case 1:
						if (QTvgeNabKIuYngzpDpvGaqKuMlN != null)
						{
							QTvgeNabKIuYngzpDpvGaqKuMlN.Dispose();
							num = -2101375877;
							continue;
						}
						return;
					case 2:
						return;
					}
					break;
				}
			}
		}

		public static bool Matches(int vid, int pid)
		{
			if (vid == 1356)
			{
				if (pid != 1476 && pid != 2976)
				{
					return pid == 2508;
				}
				return true;
			}
			return false;
		}
	}
}
