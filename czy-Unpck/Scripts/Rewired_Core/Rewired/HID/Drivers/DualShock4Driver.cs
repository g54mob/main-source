using System;
using Rewired.ControllerExtensions;
using Rewired.Drivers.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class DualShock4Driver : HIDDeviceDriver, IDisposable, IControllerDriver, IDriver_DualShock4
	{
		private enum OQmBDhiLSedxcCpnjdbIzGwwXafc
		{
			bOjsWxPvaOBcovrKzMHBnrsZkFR = 0,
			BHthfyenUmQSDsNqbVwGsEfPHjqb = 1,
			ZzjpoowFhsVnxfFVWsewAUAYcqC = 2
		}

		private enum EdNlFHbGmrUItDgrViyuRNLWLOa
		{
			XHUTYEIfTgeCBgXrVRVbPfGzuhN = 0,
			vXOaLwhTyAhDMnOWhkrgxQfUpQAN = 1,
			BHthfyenUmQSDsNqbVwGsEfPHjqb = 2
		}

		private const float PXJcUqbBgjKGgALXGDFfQLbTboCG = 4f;

		private const int wFuDaAjcZJRXwRVbVLebvOVVnWXe = 14;

		private const int eUfLWCfiDZObLbmlRBzChNbEgFwk = 2;

		private const int AzcNxxlLNszWKYIkmsGCusnqpya = 0;

		private const int azzPcSbfHSuywFTlMHBbEKimgEQ = 1912;

		private const int QlKXUvlIeZEawdYZvgeAuGSzTaA = 0;

		private const int pPGrtnQKjDqRSIfWOJqDfacQwrN = 941;

		private const bool LKQTcAFrSDAXWJXVDdgiQlgVbCU = false;

		private const bool NCIdWgohNWLEWPPDANssNoBOdnI = true;

		private const float rEoHkGopYUVpSHXafncJNIvtDJN = 2.5f;

		private const int VmiAmykWyqIGcwnngbzFwehoJEWB = 0;

		private const int PQdKUEjvNVnaixytbOsscPTlYAW = 0;

		private const int adBBoQgCOzLKibTkxLEoWRkjgdV = 1;

		private const int NkgEJkKXlbHKsKksvDBuYuezAuYN = 0;

		private const int PxDUCrxOoLWeDAhMSgjnBJxHJCS = 0;

		private const int RrFvDTmmUmVabBCPSbxUqxMhCWP = 0;

		private const int shtkSStFJOSxsjxOmWclptEyjfo = 1;

		private const int ACnDHBqItHEpqLApuaoQYcrastn = 17;

		private const int uEIgkGlWxmhULYqGBxzHsktRWLZ = 0;

		private const int JYkpKedgkrXpiINNvhbzXQrMahV = 2;

		private const int vTcPFlawJucUdPFSBxrbAZuzLMY = 64;

		private const int pcRdSUFrWbEBEgFHkJYekgUQJiiD = 78;

		private const int YSuUhFBbxLfUtbBsEPZEfqxHFBlm = 1;

		private const int boeJhPVjGIhhDzNPDihOehvxRfLI = 2;

		private const int uXWDxbfqAxeoDnhRJYjQvpYOKuJ = 3;

		private const int yQrAAACeRpBCLxMccFzUAWJSVsI = 4;

		private const int OGjGCZhvjnXGapFDotSwNhnyKNNm = 8;

		private const int DcwAQieqbNZUFrXdbgcWaarLeovs = 9;

		private const int RoSebGfNoZGJWOwrYGkQPLfvBECN = 5;

		private const int PlFgdNcSnwSHWVRNTNrCYPmhAHD = 19;

		private const int dDgxvbfXKFVAWRdBXWIMreqMiVs = 13;

		private const int yUafYnhjpiRqKTrezTCTfkwPwUhE = 35;

		private const int ZaVVeZWDAwBdEJjJhtTdvVYlcljK = 5;

		private const int ilHYdSOyRqcKBmbmcpkiZBqFmRF = 6;

		private const int GfcZZjyoWiaNebPDSGsgAdFOESmy = 7;

		private const int wgFdnrzxqcDUZrrKLhSrfJoIgto = 10;

		private const int cLgTuzABMYUFNAMNMRWFFHfhcUs = 30;

		private const int VTAFGjwninbcBEuTSpxKXJZbVXc = 27;

		private const byte sbIcVWwKfAdKCcxjCoqgKDmyRPV = 200;

		private const byte ABRlijKWBpEfbLOsTlmNWsFxDvD = 53;

		private const byte jBFAtrxEIwROtyRllHMHxDffDAy = byte.MaxValue;

		private const byte oaVHzTZtBhXNefiaqguYeXUnYps = 0;

		private const bool QXqaaXsVATafvDPWdYmhEKZbbqJ = true;

		private const int lDXyFuOKBVUfqAtVxFSgUzkPzjG = 25;

		private const int FfvuSEtGmZiFmUELarBtbMSJgcC = 187500;

		private const float CIZjXwEwcCavczYSCXByYWbUsPI = 8192f;

		private const float guBtAjmzCRLdWoHoEjYsgTOvewx = 3.4971635f;

		private const float mjdrfatCWomTexaTyLiSjXvrAKN = 0.06103702f;

		private const bool hymJNULCyDKSEQHYTHEIbzbJNWg = true;

		private const bool LSDnHdaouEiDDpruaEviBZvhmjDs = true;

		private const bool teKZKNUndooJuzyEiAMjKpGbrMz = true;

		private const bool pAbgUnyrXYlqWmhQPkcLmmXrYBl = true;

		private const float ZheccALwNmecaShWRdRmbmyFEco = 4096f;

		private const float oqwdcGtWKxosXIDBzGGJvPdHSNq = 16384f;

		private const float bzCzSUqDpqkwOlGbmfuBwBDbPxJ = 16777216f;

		private const float evyTcejNKZDLCBUwrMPCzxjLyZBM = 268435460f;

		private const float OJWbIvgsZHayILqmISAkvAAehqWc = 0.01999998f;

		private const float DbYILqaSPFVrtJCEtUQlPuNcexT = 8192f;

		private const float GRdAhNRMHNDKIvQzudGpjtavlun = 0.98f;

		private const float HrQUhhapiBijxjpiGEvBBDvcVNTn = 45f;

		private const float slcUxRYivnPQnRpPGOSAkcsJPGX = 20f;

		private readonly bool KkCFcbYtXTEdgmHLXDaDydYkKyW;

		private readonly DeviceConnectionType GzDBepeikkNSwfdZxJSSNnDXoRl;

		private readonly int FlNOkKgMUJBSGyBJbiEPCOkAXdK;

		private readonly int LtzwDDmxyMitiKporjwdeDaBjtWC;

		private readonly bool RHlnfDoTyfjZuJVlNedcqCoWAybg;

		private readonly byte AXxKxxdrNCociJjMmPAatTdGcjd;

		private readonly int MQTyZZdnoBGyrzLSkxmvwWWEBdg;

		private readonly int eSfZWtEDEtoAoxRSsokSfZVseJW;

		private readonly int OyCokeQhaNYtJplTsfhDJcERBvkE;

		private readonly int KKJggeDIhKHkHsRbvgHLJTFlEgA;

		private readonly int BuxSFlRiRHraGSPzKqZGDxWBWds;

		private readonly int duyEgSWWcLejpJDbWjCmrOHmkkJN;

		private readonly NativeBuffer aeMwQuQlPtdUYawrQqVFIuMiAPdF;

		private readonly NativeBuffer dPxPlSKThGVfgLiEEKYHuvifCBa;

		private readonly OutputReport ivorCZXlhEABpUusmuppDnoRgbCk;

		private readonly Func<OutputReport, bool> MZJGLphQViSbTOKYDaUYCuFBctzd;

		private readonly Action<OutputReport> lBRcRxYTqeMRxCOBUhfkEFojdet;

		private readonly GetHidFeatureData WwAcXFPuCMgDmrWPxdAaqijoDXq;

		private bool haXPdFXCTqGPeitNiiTTazNQsnaE;

		private bool hinjVTYXEwEHkJtZFTMklfScLpA;

		private double SenZkrDVsBqlXCtfGAWUoPeXOlh;

		private byte udCpKHcUvSCutmmTibqqJwPbVLw;

		private Quaternion JivVEqyizcCotmsGrpqQbnbjJiq = Quaternion.identity;

		private ushort uZrgDFdRFvKZwDofdvmeutcnuJBd;

		private float FhWLxVrmjyCNzKQgGOtMxAYBAUOH;

		private double LBWQDQvfDeipSEWKfQICWhGjUCLW;

		private float ogifJVGPAtkgWZQTkJyQuefhbFDQ;

		private byte UEMzZQsirEoHUNNtjcCJHuaHkzS;

		private byte tZjIJTOqjqkUFNULhlJODVMNbsY;

		private Quaternion PIuKgddGZndAQCrJexpqSrEYyrfD = Quaternion.identity;

		private Quaternion YCACTemOkGvBFoCqCurZlycEKQu = Quaternion.identity;

		private bool AMTeDaRWDpLuKwdGhAzPQmPBtQh;

		private int PkRJPDnjTLbGDJWjehyShsqKmwt;

		private int[] HIxedbgFXtFzaFwEqlgKbFoeJTFO = new int[2];

		private int[] wdIeVXzcJxQyQpJSDxJfLanHFVA = new int[2];

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
						int num2 = -1849794336;
						while (true)
						{
							switch (num2 ^ -1849794334)
							{
							case 0:
								num2 = -1849794333;
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
					int num = -339306359;
					while (true)
					{
						switch (num ^ -339306360)
						{
						case 3:
							break;
						case 1:
							if (KkCFcbYtXTEdgmHLXDaDydYkKyW)
							{
								value = (float)(udCpKHcUvSCutmmTibqqJwPbVLw + 2) * 10f;
								num = -339306358;
								continue;
							}
							goto case 0;
						case 0:
							value = (float)(udCpKHcUvSCutmmTibqqJwPbVLw - 1) * 10f;
							num = -339306358;
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
				return (int)UEMzZQsirEoHUNNtjcCJHuaHkzS;
			}
			set
			{
				UEMzZQsirEoHUNNtjcCJHuaHkzS = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				while (true)
				{
					int num = -1653957232;
					while (true)
					{
						switch (num ^ -1653957230)
						{
						case 0:
							break;
						default:
							return;
						case 2:
						{
							haXPdFXCTqGPeitNiiTTazNQsnaE = true;
							int num2;
							if (UEMzZQsirEoHUNNtjcCJHuaHkzS == 0)
							{
								num = -1653957229;
								num2 = num;
							}
							else
							{
								num = -1653957231;
								num2 = num;
							}
							continue;
						}
						case 1:
							if (tZjIJTOqjqkUFNULhlJODVMNbsY == 0)
							{
								hinjVTYXEwEHkJtZFTMklfScLpA = true;
								num = -1653957231;
								continue;
							}
							return;
						case 3:
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
				return (int)tZjIJTOqjqkUFNULhlJODVMNbsY;
			}
			set
			{
				tZjIJTOqjqkUFNULhlJODVMNbsY = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				haXPdFXCTqGPeitNiiTTazNQsnaE = true;
				if (UEMzZQsirEoHUNNtjcCJHuaHkzS != 0)
				{
					return;
				}
				while (true)
				{
					int num = 921841769;
					while (true)
					{
						switch (num ^ 0x36F23068)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							if (tZjIJTOqjqkUFNULhlJODVMNbsY == 0)
							{
								goto IL_0061;
							}
							return;
						case 2:
							return;
						}
						break;
						IL_0061:
						hinjVTYXEwEHkJtZFTMklfScLpA = true;
						num = 921841770;
					}
				}
			}
		}

		public Vector3 AccelerometerValue => aCWFOONWkvMWdrhoSKZhhnIcKWd(accelerometers[0].rawValue);

		public Vector3 AccelerometerValueRaw => new Vector3(accelerometers[0].rawValue[0], accelerometers[0].rawValue[1], accelerometers[0].rawValue[2]);

		public Vector3 GyroscopeValue => uLMyabGBmnAWfBQCjiYaouiwlTdk(gyroscopes[0].events);

		public Vector3 GyroscopeValueRaw => new Vector3(gyroscopes[0].rawValue[0], gyroscopes[0].rawValue[1], gyroscopes[0].rawValue[2]);

		public Vector3 LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);
				return uLMyabGBmnAWfBQCjiYaouiwlTdk(vector, FhWLxVrmjyCNzKQgGOtMxAYBAUOH);
			}
		}

		public Vector3 LastGyroscopeValueRaw => new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);

		public Quaternion Orientation => JivVEqyizcCotmsGrpqQbnbjJiq;

		public int MaxTouches => 2;

		public void ResetOrientation()
		{
			JivVEqyizcCotmsGrpqQbnbjJiq = Quaternion.identity;
			AMTeDaRWDpLuKwdGhAzPQmPBtQh = false;
		}

		public int GetTouchCount()
		{
			int num = 0;
			int num3 = default(int);
			while (true)
			{
				int num2 = -162004197;
				while (true)
				{
					switch (num2 ^ -162004194)
					{
					case 3:
						break;
					case 4:
					{
						int num4;
						if (num3 >= 2)
						{
							num2 = -162004193;
							num4 = num2;
						}
						else
						{
							num2 = -162004194;
							num4 = num2;
						}
						continue;
					}
					case 0:
						if (touchpads[0].values[num3].isTouching)
						{
							num++;
							num2 = -162004196;
							continue;
						}
						goto case 2;
					case 6:
						num2 = -162004198;
						continue;
					case 2:
						num3++;
						num2 = -162004198;
						continue;
					case 5:
						num3 = 0;
						num2 = -162004200;
						continue;
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
			if (index < 0 || index >= 2)
			{
				return false;
			}
			HIDTouchpad.TouchData[] values = touchpads[0].values;
			if (!values[index].isTouching)
			{
				return false;
			}
			position.x = values[index].positionX;
			position.y = values[index].positionY;
			return true;
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			position = default(Vector2);
			HIDTouchpad.TouchData[] values = default(HIDTouchpad.TouchData[]);
			int num2 = default(int);
			while (true)
			{
				int num = 1821798275;
				while (true)
				{
					switch (num ^ 0x6C966F87)
					{
					case 7:
						break;
					case 4:
						if (!touchpads[0].IsTouching(touchId))
						{
							return false;
						}
						values = touchpads[0].values;
						num = 1821798276;
						continue;
					case 6:
						position.x = values[num2].positionX;
						position.y = values[num2].positionY;
						num = 1821798274;
						continue;
					case 2:
					{
						int num4;
						if (values[num2].isTouching)
						{
							num = 1821798273;
							num4 = num;
						}
						else
						{
							num = 1821798274;
							num4 = num;
						}
						continue;
					}
					case 5:
						num2++;
						num = 1821798278;
						continue;
					case 3:
						num2 = 0;
						num = 1821798278;
						continue;
					case 1:
					{
						int num3;
						if (num2 < values.Length)
						{
							num = 1821798277;
							num3 = num;
						}
						else
						{
							num = 1821798279;
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
				if (!values[index].isTouching)
				{
					return false;
				}
				positionX = values[index].positionAbsX;
				num = 420198188;
				goto IL_0013;
			}
			goto IL_002c;
			IL_0013:
			switch (num ^ 0x190BB72E)
			{
			case 0:
				break;
			case 1:
				goto IL_002c;
			default:
				positionY = values[index].positionAbsY;
				return true;
			}
			goto IL_000e;
			IL_000e:
			num = 420198191;
			goto IL_0013;
			IL_002c:
			return false;
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (!touchpads[0].IsTouching(touchId))
			{
				goto IL_0016;
			}
			HIDTouchpad.TouchData[] values = touchpads[0].values;
			int num = 0;
			int num2 = 995315225;
			goto IL_001b;
			IL_001b:
			while (true)
			{
				switch (num2 ^ 0x3B534E1B)
				{
				case 0:
					break;
				case 1:
					return false;
				case 2:
					num2 = 995315224;
					continue;
				case 5:
					num++;
					num2 = 995315224;
					continue;
				case 4:
					if (values[num].isTouching)
					{
						positionX = values[num].positionAbsX;
						positionY = values[num].positionAbsY;
						num2 = 995315230;
						continue;
					}
					goto case 5;
				default:
					if (num >= values.Length)
					{
						return true;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0016;
			IL_0016:
			num2 = 995315226;
			goto IL_001b;
		}

		public void StopLightFlash()
		{
			UEMzZQsirEoHUNNtjcCJHuaHkzS = 0;
			tZjIJTOqjqkUFNULhlJODVMNbsY = 0;
			haXPdFXCTqGPeitNiiTTazNQsnaE = true;
			while (true)
			{
				int num = -1121419994;
				while (true)
				{
					switch (num ^ -1121419993)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0033;
					case 2:
						return;
					}
					break;
					IL_0033:
					hinjVTYXEwEHkJtZFTMklfScLpA = true;
					num = -1121419995;
				}
			}
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
					int num2 = 1135301367;
					while (true)
					{
						switch (num2 ^ 0x43AB52F6)
						{
						case 0:
							num2 = 1135301364;
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
				int num = -885206669;
				while (true)
				{
					switch (num ^ -885206684)
					{
					case 3:
						break;
					case 11:
						aeMwQuQlPtdUYawrQqVFIuMiAPdF = new NativeBuffer(64);
						num = -885206677;
						continue;
					case 5:
						OyCokeQhaNYtJplTsfhDJcERBvkE = 0;
						if (KkCFcbYtXTEdgmHLXDaDydYkKyW && RHlnfDoTyfjZuJVlNedcqCoWAybg)
						{
							AXxKxxdrNCociJjMmPAatTdGcjd = 17;
							OyCokeQhaNYtJplTsfhDJcERBvkE = 2;
							num = -885206672;
							continue;
						}
						goto case 20;
					case 22:
						RHlnfDoTyfjZuJVlNedcqCoWAybg = true;
						RHlnfDoTyfjZuJVlNedcqCoWAybg = YYoOzKqMeRqjkohwLimEuhYIMWt(WrVEVdhmDaiEyYHhLCqAumPxnFYB.pMrzmpQUTveEXenRCeQwcuyDgaOd);
						num = -885206671;
						continue;
					case 7:
						if (num3 >= 14)
						{
							axes = new HIDAxis[6]
							{
								new HIDAxis(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 48,
									dataIndex = 1 + OyCokeQhaNYtJplTsfhDJcERBvkE,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 0,
									units = 0u,
									unitsExp = 0u
								}, isSigned: false, 127),
								new HIDAxis(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 49,
									dataIndex = 2 + OyCokeQhaNYtJplTsfhDJcERBvkE,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 0,
									units = 0u,
									unitsExp = 0u
								}, isSigned: false, 127),
								new HIDAxis(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 50,
									dataIndex = 3 + OyCokeQhaNYtJplTsfhDJcERBvkE,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 0,
									units = 0u,
									unitsExp = 0u
								}, isSigned: false, 127),
								new HIDAxis(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 53,
									dataIndex = 4 + OyCokeQhaNYtJplTsfhDJcERBvkE,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 0,
									units = 0u,
									unitsExp = 0u
								}, isSigned: false, 127),
								new HIDAxis(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 51,
									dataIndex = 8 + OyCokeQhaNYtJplTsfhDJcERBvkE,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 315,
									units = 0u,
									unitsExp = 0u
								}, isSigned: false, 0),
								new HIDAxis(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 52,
									dataIndex = 9 + OyCokeQhaNYtJplTsfhDJcERBvkE,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 315,
									units = 0u,
									unitsExp = 0u
								}, isSigned: false, 0)
							};
							hats = new HIDHat[1]
							{
								new HIDHat(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 57,
									dataIndex = 5 + OyCokeQhaNYtJplTsfhDJcERBvkE,
									bitSize = 4,
									logicalMin = 0,
									logicalMax = 7,
									physicalMin = 0,
									physicalMax = 315,
									units = 20u,
									unitsExp = 0u
								}, CALdyVNfdFifKktknTAsimkzRSh)
							};
							accelerometers = new HIDAccelerometer[1]
							{
								new HIDAccelerometer(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									dataIndex = 19 + OyCokeQhaNYtJplTsfhDJcERBvkE,
									bitSize = 48
								}, 3, KthLgsyLIFfjuYoErgaPjHPcaRvM)
							};
							num = -885206668;
							continue;
						}
						goto case 9;
					case 17:
						ivorCZXlhEABpUusmuppDnoRgbCk = new OutputReport(dPxPlSKThGVfgLiEEKYHuvifCBa.Pointer, dPxPlSKThGVfgLiEEKYHuvifCBa.Length, eSfZWtEDEtoAoxRSsokSfZVseJW);
						lights = new HIDLight[1]
						{
							new HIDLight(11, 24, 28)
						};
						lights[0].ValueChangedEvent += SDGOlaqcBukiLszYmIncLPdbTOY;
						vibrationMotors = new HIDVibrationMotor[2]
						{
							new HIDVibrationMotor(0, 255),
							new HIDVibrationMotor(0, 255)
						};
						vibrationMotors[0].ValueChangedEvent += SDGOlaqcBukiLszYmIncLPdbTOY;
						vibrationMotors[1].ValueChangedEvent += SDGOlaqcBukiLszYmIncLPdbTOY;
						if (KkCFcbYtXTEdgmHLXDaDydYkKyW)
						{
							ivorCZXlhEABpUusmuppDnoRgbCk.options |= OutputReportOptions.cnNmAQWDociVApPwtNLEjRXnSBQ;
							RHlnfDoTyfjZuJVlNedcqCoWAybg = true;
							RHlnfDoTyfjZuJVlNedcqCoWAybg = YYoOzKqMeRqjkohwLimEuhYIMWt(WrVEVdhmDaiEyYHhLCqAumPxnFYB.pMrzmpQUTveEXenRCeQwcuyDgaOd);
							num = -885206676;
							continue;
						}
						goto case 22;
					case 23:
					{
						int num4;
						if (initArgs != null)
						{
							num = -885206682;
							num4 = num;
						}
						else
						{
							num = -885206684;
							num4 = num;
						}
						continue;
					}
					case 8:
						if (!RHlnfDoTyfjZuJVlNedcqCoWAybg)
						{
							ivorCZXlhEABpUusmuppDnoRgbCk.options &= ~OutputReportOptions.cnNmAQWDociVApPwtNLEjRXnSBQ;
							num = -885206665;
							continue;
						}
						goto case 21;
					case 21:
						if (!RHlnfDoTyfjZuJVlNedcqCoWAybg)
						{
							throw new Exception("Special features not supported so just treat this as a standard HID device.");
						}
						goto case 14;
					case 19:
						num = -885206671;
						continue;
					case 13:
						buttons = new HIDButton[14];
						num3 = 0;
						num = -885206685;
						continue;
					case 9:
						buttons[num3] = new HIDButton(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
						{
							usagePage = 9,
							usage = (ushort)num3
						});
						num3++;
						num = -885206685;
						continue;
					case 15:
						dPxPlSKThGVfgLiEEKYHuvifCBa = new NativeBuffer(eSfZWtEDEtoAoxRSsokSfZVseJW);
						num = -885206667;
						continue;
					case 1:
						eSfZWtEDEtoAoxRSsokSfZVseJW = 78;
						num = -885206680;
						continue;
					case 6:
						MZJGLphQViSbTOKYDaUYCuFBctzd = initArgs.synchronousWriteOutputReportDelegate;
						num = -885206666;
						continue;
					case 20:
						KKJggeDIhKHkHsRbvgHLJTFlEgA = 5 + OyCokeQhaNYtJplTsfhDJcERBvkE;
						num = -885206688;
						continue;
					case 14:
						AXxKxxdrNCociJjMmPAatTdGcjd = 1;
						num = -885206687;
						continue;
					case 18:
					{
						lBRcRxYTqeMRxCOBUhfkEFojdet = initArgs.asynchronousWriteOutputReportDelegate;
						WwAcXFPuCMgDmrWPxdAaqijoDXq = initArgs.getFeatureReportDelegate;
						GzDBepeikkNSwfdZxJSSNnDXoRl = initArgs.connectionType;
						KkCFcbYtXTEdgmHLXDaDydYkKyW = GzDBepeikkNSwfdZxJSSNnDXoRl == DeviceConnectionType.sFJAQBfZHNpXaWTCudNqcxaaCMg;
						int num2;
						if (KkCFcbYtXTEdgmHLXDaDydYkKyW)
						{
							num = -885206683;
							num2 = num;
						}
						else
						{
							num = -885206680;
							num2 = num;
						}
						continue;
					}
					case 0:
						throw new ArgumentNullException("initArgs");
					case 12:
						if (eSfZWtEDEtoAoxRSsokSfZVseJW < 23)
						{
							eSfZWtEDEtoAoxRSsokSfZVseJW = 23;
							num = -885206673;
							continue;
						}
						goto case 11;
					case 4:
						BuxSFlRiRHraGSPzKqZGDxWBWds = 6 + OyCokeQhaNYtJplTsfhDJcERBvkE;
						duyEgSWWcLejpJDbWjCmrOHmkkJN = 7 + OyCokeQhaNYtJplTsfhDJcERBvkE;
						num = -885206679;
						continue;
					case 2:
						FlNOkKgMUJBSGyBJbiEPCOkAXdK = initArgs.hatZeroValue;
						LtzwDDmxyMitiKporjwdeDaBjtWC = initArgs.hatSpan;
						MQTyZZdnoBGyrzLSkxmvwWWEBdg = initArgs.inputReportLength;
						eSfZWtEDEtoAoxRSsokSfZVseJW = initArgs.outputReportLength;
						num = -885206686;
						continue;
					case 16:
						gyroscopes = new HIDGyroscope[1]
						{
							new HIDGyroscope(initArgs.updateLoopSetting, AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
							{
								usagePage = 1,
								dataIndex = 13 + OyCokeQhaNYtJplTsfhDJcERBvkE,
								bitSize = 48
							}, 3, 25, PJeOizZvjtEYWAKATipWSDVSDQK, InnQpHFaiePFZBOHkFqvNhUWIeV)
						};
						num = -885206674;
						continue;
					default:
						touchpads = new HIDTouchpad[1]
						{
							new HIDTouchpad(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDTouchpad.TouchpadInfo(2, 0, 1912, 0, 941, invertY: false, reverseY: true), new HIDControllerElement.HIDInfo
							{
								usagePage = 1,
								dataIndex = 35 + OyCokeQhaNYtJplTsfhDJcERBvkE,
								bitSize = 48
							}, VsjZzRNXJlTxcWqumEeJIUONkGY)
						};
						LBWQDQvfDeipSEWKfQICWhGjUCLW = ReInput.realTime;
						return;
					}
					break;
				}
			}
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			jnPCjFfFDIflBYxOEUXHijiiZhM();
			gUULrqWdUNszJmicQQSwsanKBVW(WrVEVdhmDaiEyYHhLCqAumPxnFYB.RxDhwKbqppIzkwYthdHdClWgNNR);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < aeMwQuQlPtdUYawrQqVFIuMiAPdF.Length)
			{
				goto IL_0020;
			}
			ogifJVGPAtkgWZQTkJyQuefhbFDQ = (float)(timestamp - LBWQDQvfDeipSEWKfQICWhGjUCLW);
			LBWQDQvfDeipSEWKfQICWhGjUCLW = timestamp;
			aeMwQuQlPtdUYawrQqVFIuMiAPdF.Write(inputReportPtr, inputReportLength, aeMwQuQlPtdUYawrQqVFIuMiAPdF.Length);
			kvQGJWTjqgbANQTVFodBLNgClXv(aeMwQuQlPtdUYawrQqVFIuMiAPdF);
			int num = 355796621;
			goto IL_0025;
			IL_0025:
			while (true)
			{
				switch (num ^ 0x15350689)
				{
				case 0:
					break;
				case 2:
					RVgcSVBpQMbLHYUtIUJCVyTtCbz(gyroscopes, aeMwQuQlPtdUYawrQqVFIuMiAPdF, timestamp);
					num = 355796618;
					continue;
				case 3:
					RVgcSVBpQMbLHYUtIUJCVyTtCbz(touchpads, aeMwQuQlPtdUYawrQqVFIuMiAPdF, timestamp);
					udCpKHcUvSCutmmTibqqJwPbVLw = (byte)(aeMwQuQlPtdUYawrQqVFIuMiAPdF[30 + OyCokeQhaNYtJplTsfhDJcERBvkE] & 0xF);
					gBPjaFBjPZdeMcCvoTuCxIghdSSe();
					num = 355796616;
					continue;
				case 5:
					return false;
				case 4:
					nLotdmIEnGDlRjnDZLzPFXYmCSSJ(aeMwQuQlPtdUYawrQqVFIuMiAPdF, timestamp);
					RVgcSVBpQMbLHYUtIUJCVyTtCbz(axes, aeMwQuQlPtdUYawrQqVFIuMiAPdF, timestamp);
					RVgcSVBpQMbLHYUtIUJCVyTtCbz(hats, aeMwQuQlPtdUYawrQqVFIuMiAPdF, timestamp);
					RVgcSVBpQMbLHYUtIUJCVyTtCbz(accelerometers, aeMwQuQlPtdUYawrQqVFIuMiAPdF, timestamp);
					num = 355796619;
					continue;
				default:
					return true;
				}
				break;
			}
			goto IL_0020;
			IL_0020:
			num = 355796620;
			goto IL_0025;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualShock4Extension(this);
		}

		private void gUULrqWdUNszJmicQQSwsanKBVW(WrVEVdhmDaiEyYHhLCqAumPxnFYB P_0)
		{
			if (!haXPdFXCTqGPeitNiiTTazNQsnaE)
			{
				while (true)
				{
					switch (0x1556422C ^ 0x1556422E)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			YYoOzKqMeRqjkohwLimEuhYIMWt(P_0);
			haXPdFXCTqGPeitNiiTTazNQsnaE = false;
		}

		private bool YYoOzKqMeRqjkohwLimEuhYIMWt(WrVEVdhmDaiEyYHhLCqAumPxnFYB P_0)
		{
			hZiLtvTVSJEJKwVGdTRXbyAeDjI();
			bool result = OIUXarAwCISOJRuamQlSzTKmqCq(P_0);
			if (hinjVTYXEwEHkJtZFTMklfScLpA)
			{
				while (true)
				{
					int num = 117612602;
					while (true)
					{
						switch (num ^ 0x702A038)
						{
						case 0:
							break;
						case 2:
							result = OIUXarAwCISOJRuamQlSzTKmqCq(P_0);
							hinjVTYXEwEHkJtZFTMklfScLpA = false;
							num = 117612601;
							continue;
						default:
							goto end_IL_0016;
						}
						break;
					}
					continue;
					end_IL_0016:
					break;
				}
			}
			return result;
		}

		private void hZiLtvTVSJEJKwVGdTRXbyAeDjI()
		{
			if (KkCFcbYtXTEdgmHLXDaDydYkKyW && RHlnfDoTyfjZuJVlNedcqCoWAybg)
			{
				dPxPlSKThGVfgLiEEKYHuvifCBa[0] = 17;
				dPxPlSKThGVfgLiEEKYHuvifCBa[1] = 128;
				goto IL_0035;
			}
			goto IL_01f9;
			IL_003a:
			int num;
			while (true)
			{
				switch (num ^ 0x7FADC109)
				{
				case 5:
					break;
				default:
					return;
				case 4:
					dPxPlSKThGVfgLiEEKYHuvifCBa[3] = byte.MaxValue;
					num = 2142093576;
					continue;
				case 10:
					dPxPlSKThGVfgLiEEKYHuvifCBa[10] = tZjIJTOqjqkUFNULhlJODVMNbsY;
					dPxPlSKThGVfgLiEEKYHuvifCBa[19] = 53;
					num = 2142093577;
					continue;
				case 7:
					dPxPlSKThGVfgLiEEKYHuvifCBa[11] = UEMzZQsirEoHUNNtjcCJHuaHkzS;
					dPxPlSKThGVfgLiEEKYHuvifCBa[12] = tZjIJTOqjqkUFNULhlJODVMNbsY;
					dPxPlSKThGVfgLiEEKYHuvifCBa[21] = 53;
					dPxPlSKThGVfgLiEEKYHuvifCBa[22] = 53;
					num = 2142093579;
					continue;
				case 6:
					dPxPlSKThGVfgLiEEKYHuvifCBa[7] = (byte)vibrationMotors[0].SpeedRaw;
					dPxPlSKThGVfgLiEEKYHuvifCBa[8] = lights[0].ColorRRaw;
					dPxPlSKThGVfgLiEEKYHuvifCBa[9] = lights[0].ColorGRaw;
					num = 2142093569;
					continue;
				case 11:
					return;
				case 1:
					dPxPlSKThGVfgLiEEKYHuvifCBa[6] = (byte)vibrationMotors[1].SpeedRaw;
					num = 2142093583;
					continue;
				case 0:
					dPxPlSKThGVfgLiEEKYHuvifCBa[20] = 53;
					dPxPlSKThGVfgLiEEKYHuvifCBa[21] = byte.MaxValue;
					dPxPlSKThGVfgLiEEKYHuvifCBa[22] = 0;
					num = 2142093578;
					continue;
				case 2:
					dPxPlSKThGVfgLiEEKYHuvifCBa[23] = byte.MaxValue;
					dPxPlSKThGVfgLiEEKYHuvifCBa[24] = 0;
					num = 2142093570;
					continue;
				case 12:
					goto IL_01f9;
				case 8:
					dPxPlSKThGVfgLiEEKYHuvifCBa[10] = lights[0].ColorBRaw;
					num = 2142093582;
					continue;
				case 9:
					dPxPlSKThGVfgLiEEKYHuvifCBa[5] = (byte)vibrationMotors[0].SpeedRaw;
					dPxPlSKThGVfgLiEEKYHuvifCBa[6] = lights[0].ColorRRaw;
					dPxPlSKThGVfgLiEEKYHuvifCBa[7] = lights[0].ColorGRaw;
					dPxPlSKThGVfgLiEEKYHuvifCBa[8] = lights[0].ColorBRaw;
					dPxPlSKThGVfgLiEEKYHuvifCBa[9] = UEMzZQsirEoHUNNtjcCJHuaHkzS;
					num = 2142093571;
					continue;
				case 3:
					return;
				}
				break;
			}
			goto IL_0035;
			IL_01f9:
			dPxPlSKThGVfgLiEEKYHuvifCBa[0] = 5;
			dPxPlSKThGVfgLiEEKYHuvifCBa[1] = byte.MaxValue;
			dPxPlSKThGVfgLiEEKYHuvifCBa[4] = (byte)vibrationMotors[1].SpeedRaw;
			num = 2142093568;
			goto IL_003a;
			IL_0035:
			num = 2142093581;
			goto IL_003a;
		}

		private bool OIUXarAwCISOJRuamQlSzTKmqCq(WrVEVdhmDaiEyYHhLCqAumPxnFYB P_0)
		{
			SenZkrDVsBqlXCtfGAWUoPeXOlh = ReInput.realTime + 4.0;
			bool result = default(bool);
			int num;
			if (P_0 == WrVEVdhmDaiEyYHhLCqAumPxnFYB.pMrzmpQUTveEXenRCeQwcuyDgaOd)
			{
				if (MZJGLphQViSbTOKYDaUYCuFBctzd == null)
				{
					goto IL_0020;
				}
				result = MZJGLphQViSbTOKYDaUYCuFBctzd(ivorCZXlhEABpUusmuppDnoRgbCk);
				num = 1593050453;
			}
			else
			{
				if (P_0 != WrVEVdhmDaiEyYHhLCqAumPxnFYB.RxDhwKbqppIzkwYthdHdClWgNNR)
				{
					throw new NotImplementedException();
				}
				if (lBRcRxYTqeMRxCOBUhfkEFojdet != null)
				{
					lBRcRxYTqeMRxCOBUhfkEFojdet(ivorCZXlhEABpUusmuppDnoRgbCk);
					return true;
				}
				num = 1593050455;
			}
			goto IL_0025;
			IL_0025:
			switch (num ^ 0x5EF40556)
			{
			case 0:
				break;
			case 2:
				return false;
			case 3:
				return result;
			default:
				return false;
			}
			goto IL_0020;
			IL_0020:
			num = 1593050452;
			goto IL_0025;
		}

		private void nLotdmIEnGDlRjnDZLzPFXYmCSSJ(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[KKJggeDIhKHkHsRbvgHLJTFlEgA];
			buttons[0].SetValue((b & 0x10) != 0, P_1);
			while (true)
			{
				int num = 1497833756;
				while (true)
				{
					switch (num ^ 0x5947211D)
					{
					case 0:
						break;
					case 1:
						buttons[1].SetValue((b & 0x20) != 0, P_1);
						buttons[2].SetValue((b & 0x40) != 0, P_1);
						buttons[3].SetValue((b & 0x80) != 0, P_1);
						b = P_0[BuxSFlRiRHraGSPzKqZGDxWBWds];
						num = 1497833759;
						continue;
					case 2:
						buttons[4].SetValue((b & 1) != 0, P_1);
						buttons[5].SetValue((b & 2) != 0, P_1);
						buttons[6].SetValue((b & 4) != 0, P_1);
						buttons[7].SetValue((b & 8) != 0, P_1);
						buttons[8].SetValue((b & 0x10) != 0, P_1);
						buttons[9].SetValue((b & 0x20) != 0, P_1);
						buttons[10].SetValue((b & 0x40) != 0, P_1);
						buttons[11].SetValue((b & 0x80) != 0, P_1);
						b = P_0[duyEgSWWcLejpJDbWjCmrOHmkkJN];
						num = 1497833758;
						continue;
					default:
						buttons[12].SetValue((b & 1) != 0, P_1);
						buttons[13].SetValue((b & 2) != 0, P_1);
						return;
					}
					break;
				}
			}
		}

		private void RVgcSVBpQMbLHYUtIUJCVyTtCbz(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
		{
			int num = 0;
			while (num < P_0.Length)
			{
				while (true)
				{
					P_0[num].UpdateValue(P_1, P_2);
					int num2 = -1360199790;
					while (true)
					{
						switch (num2 ^ -1360199789)
						{
						case 3:
							num2 = -1360199791;
							continue;
						case 2:
							break;
						case 1:
							num++;
							num2 = -1360199789;
							continue;
						default:
							goto end_IL_0026;
						}
						break;
					}
					continue;
					end_IL_0026:
					break;
				}
			}
		}

		private void jnPCjFfFDIflBYxOEUXHijiiZhM()
		{
			if (isVibrating && ReInput.realTime >= SenZkrDVsBqlXCtfGAWUoPeXOlh)
			{
				haXPdFXCTqGPeitNiiTTazNQsnaE = true;
			}
		}

		private void kvQGJWTjqgbANQTVFodBLNgClXv(NativeBuffer P_0)
		{
			if (!RHlnfDoTyfjZuJVlNedcqCoWAybg)
			{
				return;
			}
			float fhWLxVrmjyCNzKQgGOtMxAYBAUOH = default(float);
			while (true)
			{
				IL_005d:
				ushort num = aeMwQuQlPtdUYawrQqVFIuMiAPdF.ReadUShort(10 + OyCokeQhaNYtJplTsfhDJcERBvkE);
				if (num == uZrgDFdRFvKZwDofdvmeutcnuJBd)
				{
					goto IL_003e;
				}
				int num2;
				int num3;
				if (num < uZrgDFdRFvKZwDofdvmeutcnuJBd)
				{
					num2 = num + 65535 - uZrgDFdRFvKZwDofdvmeutcnuJBd;
					num3 = 78120772;
					goto IL_000e;
				}
				goto IL_009d;
				IL_000e:
				while (true)
				{
					switch (num3 ^ 0x4A80742)
					{
					case 0:
						num3 = 78120769;
						continue;
					case 1:
						num3 = 78120775;
						continue;
					case 2:
						break;
					case 6:
						fhWLxVrmjyCNzKQgGOtMxAYBAUOH = (float)num2 / 187500f;
						num3 = 78120771;
						continue;
					case 3:
						goto IL_005d;
					case 4:
						goto IL_009d;
					default:
						uZrgDFdRFvKZwDofdvmeutcnuJBd = num;
						FhWLxVrmjyCNzKQgGOtMxAYBAUOH = fhWLxVrmjyCNzKQgGOtMxAYBAUOH;
						return;
					}
					break;
				}
				goto IL_003e;
				IL_009d:
				num2 = num - uZrgDFdRFvKZwDofdvmeutcnuJBd;
				num3 = 78120772;
				goto IL_000e;
				IL_003e:
				num2 = 0;
				fhWLxVrmjyCNzKQgGOtMxAYBAUOH = 0f;
				num3 = 78120775;
				goto IL_000e;
			}
		}

		private void gBPjaFBjPZdeMcCvoTuCxIghdSSe()
		{
			if (!RHlnfDoTyfjZuJVlNedcqCoWAybg)
			{
				goto IL_0008;
			}
			goto IL_0084;
			IL_0008:
			int num = 85474971;
			goto IL_000d;
			IL_000d:
			Vector3 vector2 = default(Vector3);
			while (true)
			{
				switch (num ^ 0x5183E99)
				{
				case 3:
					break;
				case 2:
					return;
				case 4:
					vector2 = uLMyabGBmnAWfBQCjiYaouiwlTdk(new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]), FhWLxVrmjyCNzKQgGOtMxAYBAUOH);
					XoOTfbBvSuqPGnhhQqeYTWRcKHb(ref vector2);
					num = 85474969;
					continue;
				case 1:
					goto IL_0084;
				default:
				{
					Vector3 vector = new Vector3(accelerometers[0].rawValue[0] * -1f, accelerometers[0].rawValue[1] * -1f, accelerometers[0].rawValue[2] * -1f);
					hvpViggNofQDCHeEBVtNSdydkjZ(vector, vector2);
					return;
				}
				}
				break;
			}
			goto IL_0008;
			IL_0084:
			_ = FhWLxVrmjyCNzKQgGOtMxAYBAUOH;
			_ = 0f;
			num = 85474973;
			goto IL_000d;
		}

		private static bool XoOTfbBvSuqPGnhhQqeYTWRcKHb(ref Vector3 P_0)
		{
			if (P_0.magnitude < 0.004f)
			{
				P_0.x = 0f;
				while (true)
				{
					int num = -1817733346;
					while (true)
					{
						switch (num ^ -1817733345)
						{
						case 2:
							break;
						case 1:
							goto IL_0036;
						default:
							return false;
						}
						break;
						IL_0036:
						P_0.y = 0f;
						P_0.z = 0f;
						num = -1817733345;
					}
				}
			}
			return true;
		}

		private void hvpViggNofQDCHeEBVtNSdydkjZ(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			float y = default(float);
			EdNlFHbGmrUItDgrViyuRNLWLOa edNlFHbGmrUItDgrViyuRNLWLOa = default(EdNlFHbGmrUItDgrViyuRNLWLOa);
			Quaternion a = default(Quaternion);
			Quaternion quaternion2 = default(Quaternion);
			while (true)
			{
				int num = 1485102892;
				while (true)
				{
					switch (num ^ 0x5884DF22)
					{
					case 4:
						break;
					default:
						return;
					case 1:
					{
						JivVEqyizcCotmsGrpqQbnbjJiq *= quaternion;
						int num3;
						if (!AMTeDaRWDpLuKwdGhAzPQmPBtQh)
						{
							num = 1485102880;
							num3 = num;
						}
						else
						{
							num = 1485102893;
							num3 = num;
						}
						continue;
					}
					case 10:
					{
						Vector3 vector = YCACTemOkGvBFoCqCurZlycEKQu * Vector3.right;
						y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
						num = 1485102889;
						continue;
					}
					case 13:
						num = 1485102884;
						continue;
					case 3:
					{
						int num2;
						if ((edNlFHbGmrUItDgrViyuRNLWLOa & EdNlFHbGmrUItDgrViyuRNLWLOa.BHthfyenUmQSDsNqbVwGsEfPHjqb) != EdNlFHbGmrUItDgrViyuRNLWLOa.XHUTYEIfTgeCBgXrVRVbPfGzuhN)
						{
							num = 1485102885;
							num2 = num;
						}
						else
						{
							num = 1485102898;
							num2 = num;
						}
						continue;
					}
					case 14:
						if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && IhKFGIImEfUjYmbBnztJgunlbbgf(P_0, out edNlFHbGmrUItDgrViyuRNLWLOa))
						{
							a = JivVEqyizcCotmsGrpqQbnbjJiq * quaternion;
							num = 1485102894;
							continue;
						}
						goto case 1;
					case 11:
						quaternion2 = Quaternion.Euler(0f, y, 0f) * quaternion2;
						num = 1485102895;
						continue;
					case 7:
						quaternion2 = mCXxDIqaPNYcEtgJSeEPewzKriV(P_0);
						num = 1485102888;
						continue;
					case 15:
						AMTeDaRWDpLuKwdGhAzPQmPBtQh = false;
						num = 1485102880;
						continue;
					case 6:
						JivVEqyizcCotmsGrpqQbnbjJiq = Quaternion.Lerp(a, quaternion2, 0.01999998f);
						num = 1485102887;
						continue;
					case 0:
						num = 1485102884;
						continue;
					case 9:
						YCACTemOkGvBFoCqCurZlycEKQu *= quaternion;
						if ((edNlFHbGmrUItDgrViyuRNLWLOa & EdNlFHbGmrUItDgrViyuRNLWLOa.vXOaLwhTyAhDMnOWhkrgxQfUpQAN) != EdNlFHbGmrUItDgrViyuRNLWLOa.XHUTYEIfTgeCBgXrVRVbPfGzuhN)
						{
							quaternion2 = trsUiauIhmiEvWDlOpBCohoKTWC(P_0, a.eulerAngles.y);
							num = 1485102882;
							continue;
						}
						goto case 3;
					case 16:
						quaternion2 = Quaternion.identity;
						num = 1485102884;
						continue;
					case 8:
						PIuKgddGZndAQCrJexpqSrEYyrfD *= quaternion;
						num = 1485102891;
						continue;
					case 5:
						return;
					case 12:
						if (!AMTeDaRWDpLuKwdGhAzPQmPBtQh)
						{
							AMTeDaRWDpLuKwdGhAzPQmPBtQh = true;
							PIuKgddGZndAQCrJexpqSrEYyrfD = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
							YCACTemOkGvBFoCqCurZlycEKQu = JivVEqyizcCotmsGrpqQbnbjJiq;
							num = 1485102890;
							continue;
						}
						goto case 8;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private static Quaternion GqOEiFUzrmKCyokIzwkJKHQTnHy(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = new Vector3(P_0.x, P_0.y, P_0.z);
			Vector3 vector2 = kLWuTtKpvxZIytcJnVJmpNqejZg(vector, P_1);
			return new Quaternion(vector2.x, vector2.y, vector2.z, P_0.w);
		}

		private static Vector3 kLWuTtKpvxZIytcJnVJmpNqejZg(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion EPoldXYCScKuluPrKZxdGRjCHed(Quaternion P_0, OQmBDhiLSedxcCpnjdbIzGwwXafc P_1)
		{
			Vector4 vector = default(Vector4);
			if (MathTools.Approximately(P_0.w, 0f) && MathTools.Approximately(P_0[(int)P_1], 0f))
			{
				goto IL_0031;
			}
			goto IL_0066;
			IL_0066:
			float num = P_0[(int)P_1];
			int num2 = -1701290706;
			goto IL_0036;
			IL_0031:
			num2 = -1701290712;
			goto IL_0036;
			IL_0036:
			float num3 = default(float);
			while (true)
			{
				switch (num2 ^ -1701290706)
				{
				case 7:
					break;
				case 4:
					goto IL_0066;
				case 2:
					vector[(int)P_1] = num / num3;
					num2 = -1701290709;
					continue;
				case 6:
					P_0 = Quaternion.identity;
					num2 = -1701290705;
					continue;
				case 5:
					P_0 = new Quaternion(vector[0], vector[1], vector[2], vector[3]);
					num2 = -1701290707;
					continue;
				case 1:
					num2 = -1701290707;
					continue;
				case 0:
					num3 = MathTools.Sqrt(P_0.w * P_0.w + num * num);
					vector[3] = P_0.w / num3;
					num2 = -1701290708;
					continue;
				default:
					return P_0;
				}
				break;
			}
			goto IL_0031;
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			float num = quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z + quaternion.w * quaternion.w;
			float num2 = 1f / num;
			Quaternion result = default(Quaternion);
			result.x = (0f - quaternion.x) * num2;
			result.y = (0f - quaternion.y) * num2;
			result.z = (0f - quaternion.z) * num2;
			result.w = quaternion.w * num2;
			return result;
		}

		private float uadLKdJzArgZdadKpFEjcSShEnIE(float P_0, float P_1)
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
				num = 221976870;
				goto IL_0030;
			}
			goto IL_0061;
			IL_0061:
			return P_0 - P_1;
			IL_002b:
			num = 221976869;
			goto IL_0030;
			IL_0030:
			switch (num ^ 0xD3B1924)
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

		private Vector3 ycNTgBJxNMLpeYlfLtllBetmdrga(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
			float x2 = default(float);
			float z = default(float);
			while (true)
			{
				int num2 = -23976549;
				while (true)
				{
					switch (num2 ^ -23976550)
					{
					case 2:
						break;
					case 1:
						goto IL_005b;
					default:
						return new Vector3(x2, P_1, z);
					}
					break;
					IL_005b:
					float num3 = MathTools.Atan2(P_0.x, x);
					x2 = num * 57.29578f + 180f;
					z = (0f - num3) * 57.29578f;
					num2 = -23976550;
				}
			}
		}

		private Quaternion trsUiauIhmiEvWDlOpBCohoKTWC(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
			float num3 = default(float);
			float x2 = default(float);
			while (true)
			{
				int num2 = 554392250;
				while (true)
				{
					switch (num2 ^ 0x210B5ABB)
					{
					case 3:
						break;
					case 1:
						num3 = MathTools.Atan2(P_0.x, x);
						num2 = 554392249;
						continue;
					case 2:
						x2 = num * 57.29578f + 180f;
						num2 = 554392251;
						continue;
					default:
					{
						float z = (0f - num3) * 57.29578f;
						return Quaternion.Euler(x2, P_1, z);
					}
					}
					break;
				}
			}
		}

		private Quaternion mCXxDIqaPNYcEtgJSeEPewzKriV(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = default(float);
			Quaternion quaternion = default(Quaternion);
			while (true)
			{
				int num2 = -497287959;
				while (true)
				{
					switch (num2 ^ -497287960)
					{
					case 0:
						break;
					case 1:
						x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
						num2 = -497287958;
						continue;
					case 2:
					{
						float num3 = MathTools.Atan2(P_0.x, x);
						float x2 = num * 57.29578f + 180f;
						float z = (0f - num3) * 57.29578f;
						quaternion = Quaternion.Euler(0f, 0f, z) * Quaternion.Euler(x2, 0f, 0f);
						num2 = -497287957;
						continue;
					}
					default:
						if (P_1 != 0f)
						{
							return quaternion * Quaternion.Euler(0f, P_1, 0f);
						}
						return quaternion;
					}
					break;
				}
			}
		}

		private float QYJovuDjWonekrNPJHpbTjkcLkF(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool ZisxBhrfUHBvOlocCbYtOMFgqLG(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool IhKFGIImEfUjYmbBnztJgunlbbgf(Vector3 P_0, out EdNlFHbGmrUItDgrViyuRNLWLOa P_1)
		{
			P_0.Normalize();
			bool result = default(bool);
			while (true)
			{
				int num = -976618189;
				while (true)
				{
					switch (num ^ -976618190)
					{
					case 2:
						break;
					case 1:
						P_1 = EdNlFHbGmrUItDgrViyuRNLWLOa.XHUTYEIfTgeCBgXrVRVbPfGzuhN;
						result = false;
						if (mtRXIdIqdBSRNqfQWnnsmQnmsgg(P_0))
						{
							result = true;
							P_1 |= EdNlFHbGmrUItDgrViyuRNLWLOa.vXOaLwhTyAhDMnOWhkrgxQfUpQAN;
							num = -976618190;
							continue;
						}
						goto case 0;
					case 0:
						if (VbpycyuBFqaISAOQLGwAQnRNlask(P_0))
						{
							result = true;
							P_1 |= EdNlFHbGmrUItDgrViyuRNLWLOa.BHthfyenUmQSDsNqbVwGsEfPHjqb;
							num = -976618191;
							continue;
						}
						goto default;
					default:
						return result;
					}
					break;
				}
			}
		}

		private bool mtRXIdIqdBSRNqfQWnnsmQnmsgg(Vector3 P_0)
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

		private bool VbpycyuBFqaISAOQLGwAQnRNlask(Vector3 P_0)
		{
			if (P_0.z < 0f)
			{
				return false;
			}
			if (Vector3.Angle(new Vector3(0f, 0f, 1f), P_0) > 20f)
			{
				return false;
			}
			return true;
		}

		private Vector3 aCWFOONWkvMWdrhoSKZhhnIcKWd(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 uLMyabGBmnAWfBQCjiYaouiwlTdk(ExpandableArray_DataContainer<HIDGyroscope.KBIcthKTrvImOspkbCGHzBZrrOsN> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			int num = 0;
			HIDGyroscope.KBIcthKTrvImOspkbCGHzBZrrOsN kBIcthKTrvImOspkbCGHzBZrrOsN = default(HIDGyroscope.KBIcthKTrvImOspkbCGHzBZrrOsN);
			while (true)
			{
				int num2 = -7686922;
				while (true)
				{
					switch (num2 ^ -7686926)
					{
					case 5:
						break;
					case 1:
						result += uLMyabGBmnAWfBQCjiYaouiwlTdk(kBIcthKTrvImOspkbCGHzBZrrOsN.exXEGrdtTPMqWAFhcADmmCipVY, kBIcthKTrvImOspkbCGHzBZrrOsN.VcyElInJLsFJXvLnLYxHhMeWqFl);
						num2 = -7686928;
						continue;
					case 3:
						kBIcthKTrvImOspkbCGHzBZrrOsN = P_0[num];
						num2 = -7686925;
						continue;
					case 2:
						num++;
						num2 = -7686926;
						continue;
					case 4:
						num2 = -7686926;
						continue;
					default:
						if (num >= count)
						{
							return result;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		private Vector3 uLMyabGBmnAWfBQCjiYaouiwlTdk(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private Vector3 zowHnnnuUrPnGduIWLFgKAPZOTd(Vector3 P_0)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 3.4971635f;
		}

		private int CALdyVNfdFifKktknTAsimkzRSh(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void KthLgsyLIFfjuYoErgaPjHPcaRvM(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void PJeOizZvjtEYWAKATipWSDVSDQK(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float InnQpHFaiePFZBOHkFqvNhUWIeV()
		{
			return FhWLxVrmjyCNzKQgGOtMxAYBAUOH;
		}

		private void VsjZzRNXJlTxcWqumEeJIUONkGY(NativeBuffer P_0, HIDTouchpad.TouchData[] P_1)
		{
			int num = 35 + OyCokeQhaNYtJplTsfhDJcERBvkE;
			int positionRawX = P_0[1 + num] + (P_0[2 + num] & 0xF) * 255;
			int positionRawY = ((P_0[2 + num] & 0xF0) >> 4) + P_0[3 + num] * 16;
			int positionRawX2 = P_0[5 + num] + (P_0[6 + num] & 0xF) * 255;
			int positionRawY2 = default(int);
			byte b2 = default(byte);
			bool flag = default(bool);
			byte b = default(byte);
			bool flag2 = default(bool);
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num2 = 273047306;
				while (true)
				{
					switch (num2 ^ 0x10465F09)
					{
					case 4:
						break;
					case 3:
						positionRawY2 = ((P_0[6 + num] & 0xF0) >> 4) + P_0[7 + num] * 16;
						b2 = P_0[num];
						flag = b2 < 128;
						b = P_0[num + 4];
						flag2 = b < 128;
						num2 = 273047307;
						continue;
					case 2:
						num3 = b2 & 0x7F;
						num2 = 273047304;
						continue;
					case 1:
						num4 = b & 0x7F;
						P_1[0].isTouching = flag;
						num2 = 273047305;
						continue;
					default:
						P_1[0].touchId = TqWfEhgBnkNcUdMOJKpkCdtUSOgu(0, flag, num3);
						P_1[0].positionRawX = positionRawX;
						P_1[0].positionRawY = positionRawY;
						P_1[1].isTouching = flag2;
						P_1[1].touchId = TqWfEhgBnkNcUdMOJKpkCdtUSOgu(1, flag2, num4);
						P_1[1].positionRawX = positionRawX2;
						P_1[1].positionRawY = positionRawY2;
						return;
					}
					break;
				}
			}
		}

		private int TqWfEhgBnkNcUdMOJKpkCdtUSOgu(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				HIxedbgFXtFzaFwEqlgKbFoeJTFO[P_0] = -1;
				goto IL_000f;
			}
			int num;
			if (P_2 != wdIeVXzcJxQyQpJSDxJfLanHFVA[P_0])
			{
				num = 1106525764;
				goto IL_0014;
			}
			return HIxedbgFXtFzaFwEqlgKbFoeJTFO[P_0];
			IL_000f:
			num = 1106525761;
			goto IL_0014;
			IL_0014:
			int pkRJPDnjTLbGDJWjehyShsqKmwt = default(int);
			while (true)
			{
				switch (num ^ 0x41F43E46)
				{
				case 5:
					break;
				case 0:
					PkRJPDnjTLbGDJWjehyShsqKmwt++;
					num = 1106525774;
					continue;
				case 6:
					PkRJPDnjTLbGDJWjehyShsqKmwt = 0;
					num = 1106525774;
					continue;
				case 2:
				{
					pkRJPDnjTLbGDJWjehyShsqKmwt = PkRJPDnjTLbGDJWjehyShsqKmwt;
					int num2;
					if (PkRJPDnjTLbGDJWjehyShsqKmwt == int.MaxValue)
					{
						num = 1106525760;
						num2 = num;
					}
					else
					{
						num = 1106525766;
						num2 = num;
					}
					continue;
				}
				case 3:
					HIxedbgFXtFzaFwEqlgKbFoeJTFO[P_0] = pkRJPDnjTLbGDJWjehyShsqKmwt;
					num = 1106525767;
					continue;
				case 7:
					wdIeVXzcJxQyQpJSDxJfLanHFVA[P_0] = P_2;
					num = 1106525762;
					continue;
				case 4:
					return -1;
				case 8:
					wdIeVXzcJxQyQpJSDxJfLanHFVA[P_0] = P_2;
					num = 1106525765;
					continue;
				default:
					return pkRJPDnjTLbGDJWjehyShsqKmwt;
				}
				break;
			}
			goto IL_000f;
		}

		private void SDGOlaqcBukiLszYmIncLPdbTOY()
		{
			haXPdFXCTqGPeitNiiTTazNQsnaE = true;
		}

		~DualShock4Driver()
		{
			Dispose(disposing: false);
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
				int num = 1257126262;
				while (true)
				{
					switch (num ^ 0x4AEE3977)
					{
					case 0:
						num = 1257126259;
						continue;
					default:
						return;
					case 5:
						dPxPlSKThGVfgLiEEKYHuvifCBa.Dispose();
						num = 1257126260;
						continue;
					case 2:
					{
						int num2;
						if (dPxPlSKThGVfgLiEEKYHuvifCBa == null)
						{
							num = 1257126260;
							num2 = num;
						}
						else
						{
							num = 1257126258;
							num2 = num;
						}
						continue;
					}
					case 1:
						if (disposing)
						{
							StopVibration();
							gUULrqWdUNszJmicQQSwsanKBVW(WrVEVdhmDaiEyYHhLCqAumPxnFYB.pMrzmpQUTveEXenRCeQwcuyDgaOd);
							if (aeMwQuQlPtdUYawrQqVFIuMiAPdF != null)
							{
								aeMwQuQlPtdUYawrQqVFIuMiAPdF.Dispose();
								num = 1257126261;
								continue;
							}
							goto case 2;
						}
						return;
					case 4:
						break;
					case 3:
						return;
					}
					break;
				}
			}
		}

		public static bool Matches(int vid, int pid)
		{
			int num = 0;
			while (num < Consts.pidVids_sony_dualShock4.Count)
			{
				while (true)
				{
					if (Consts.pidVids_sony_dualShock4[num].vendorId == vid && Consts.pidVids_sony_dualShock4[num].productId == pid)
					{
						return true;
					}
					num++;
					int num2 = 461333171;
					while (true)
					{
						switch (num2 ^ 0x1B7F62B1)
						{
						case 0:
							num2 = 461333168;
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
}
