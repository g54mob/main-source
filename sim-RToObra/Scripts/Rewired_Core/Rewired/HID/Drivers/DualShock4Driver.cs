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
		private enum SJypzpVxRgDShwLQEGDypUpSoNA
		{
			hrvDKjXiVQjvUsukQQpGUdUOUqr = 0,
			HsdTpmcCbyhcpteKCHBHGDBMpxWc = 1,
			DEvxJokNMsYdVcFtlbLhfXyZzgo = 2
		}

		private enum OIJTHJtnXdTuDYmTeTRraFfLFEWg
		{
			TCGihQKDgeeGtvEXifcuojmabzj = 0,
			nHExoOJHSKhwzDejIGfajTEJGjw = 1,
			HsdTpmcCbyhcpteKCHBHGDBMpxWc = 2
		}

		private const float PNDJSsfJBfvqSNcrzQkedvVCuiq = 4f;

		private const int uoEjKyevFzzSGFeoHwcdjcYUdf = 14;

		private const int aHtmGQruiJHmncmNqQBRQnBBJCM = 2;

		private const int CCaqtflKwydDoNzMNEHZHHTjjxU = 0;

		private const int emraveGvCToEKaMrfIsCkxgEbyip = 1912;

		private const int UwYsmttJwHOASkjfYJhJXaoqCow = 0;

		private const int nyKBrhYNOLbcmLbczAXEKUCRfzn = 941;

		private const bool JvWQsUPtiBtlqWvCcPFvtEEKAik = false;

		private const bool LdQoFkwcuMNzwADbdDahFyvDXdsH = true;

		private const float vVccpeKaOKQrLeEbQdOrNsaidBng = 2.5f;

		private const int XocMwjGHhkoEniVwVIWxZJMzOiB = 0;

		private const int XQbaqQxSqPpKQeqVOZTfJmxerMc = 0;

		private const int mcVLSCadddMuSsYOGlxtjzSkdtj = 1;

		private const int PTgnboKKfhswIvORAythFOmcskU = 0;

		private const int ZKVMarfiPZgefBHwnaCcYoFQaOmX = 0;

		private const int NiNPLZwUnwjpNYulbcENBvooHEx = 0;

		private const int aVxcwGlIgKsNImSkZwVwKaaxQrS = 1;

		private const int KibubLqFMVssYARTBADDfxXdpSZ = 17;

		private const int wiULSIbeKaJPlbJcymKYXvVOVGx = 0;

		private const int FLcggyhgLbbNWZtlIVUmwALFvxz = 2;

		private const int tqqfaxqveyujZSpcmEqwlGUyMbg = 64;

		private const int fRqyMjRnxMjwCgxicpnNxmKIiSI = 78;

		private const int ENyHlJNhGDcrRUdKlKkDNBNEBDDH = 1;

		private const int tNyGpVBtnSfFvoTnavIHKTJictd = 2;

		private const int cqSXjxtFXtYYliDDcclcQdVJnIO = 3;

		private const int aUdPiGUMsnOetmDEBRMDbGbJdeeE = 4;

		private const int CZxefPtMCnkcSWbtNlhlMeVnPGh = 8;

		private const int XzoeguicEBoLdcWNYRCTTUFYyaV = 9;

		private const int TWwHYPmZDLlibLXdLrZwyNsCnk = 5;

		private const int VRPaUnDajoEavRWvuwqsKztrrQlb = 19;

		private const int tFqwLfvgkJrzeKvduIpJIkILPNW = 13;

		private const int aQuurElIPkCiOaMFEdSVHCFYGHt = 35;

		private const int LHZYmVAbFoJYoolIQqCcIIccpXB = 5;

		private const int cWVXrIIAwwuVzhAkTZEtsSUOLZp = 6;

		private const int CacrDbkSfofNIidnhDavGbzZbGM = 7;

		private const int iFHiNxjgPwWffqXeuaCqWhGXzmC = 10;

		private const int gWmQtvKfMUzSjFhJxcxOqVvcQFY = 30;

		private const int DiUoXhggZdcCxvebhSYPuetiQLE = 27;

		private const byte oaYlrOoNGIDuobpLnaVrdVEhzXz = 200;

		private const byte ECBcEvYugnBDPQVYuLuYtblwIhl = 53;

		private const byte jDBcwnHnteVrDvpVIRyAjOBosKKn = byte.MaxValue;

		private const byte ogLFFuTivnnQnyKgVTGXBcvkfFK = 0;

		private const bool pkqFtYFxZBLsoTKaeWrPEeVIECUB = true;

		private const bool HFJrnvoPRWlFdqcCRhEdgqLmJbp = true;

		private const bool dcAqnLEgIkfnKwvkXnQqvAimCNH = false;

		private const bool QNsKWNumvLZWVEBwYAFmzNdyuyt = true;

		private const int xYRnKqGBiFROIDbzAgxvjeGWpsc = 25;

		private const bool tBrtKxkPaGZXinBkmdVIZnleBQFA = true;

		private const float OPBaNTIRFAhSXgqypIqQLtyZCwdo = 8192f;

		private const float XXocYUdPNarEGSDconGfgCADSUSN = 4096f;

		private const float mQePRKtRljlSxTStSodSCkHOJEG = 16384f;

		private const float jLpaZEsigzdKYwsmCdOzXTtqALD = 16777216f;

		private const float cFcEjglilTjxgXTIOiSVUKPIXLr = 268435460f;

		private const float GVChmnkuwBOleSZUdtYlEMezsGg = 0.01999998f;

		private const float TzOcpemUmLTHHWKkEJlwuWldlTz = 8192f;

		private const float aFTuwfshDTZqobEKzxKlFkUagPD = 0.0009765625f;

		private const float wOlUFanxryCAIqplJvuZAJTgAYfD = 0.05595291f;

		private const float IjzOkNZHaLPjkcSRVQWyAnWmzsJ = 0.98f;

		private const float BOGHPlmJlXLDFckClCmWmBJSVXl = 45f;

		private const float mQktkBCUBnetRWiFdArDFFCWwFr = 10f;

		private readonly bool IPmdjkAEMPygLJbnslqnNUFTGYEh;

		private readonly int ZuJUdCsQtJchgnotWnEYnVMXpZe;

		private readonly int BNlvTZuaNEZiINaOUJRyylCWGluH;

		private readonly bool PerPoXkTXfpOMQfRmGkfJQQHaoP;

		private readonly byte IBtisnbbWWhGYoIFHfsNUGxPeeLX;

		private readonly int IHXNCBnWSZMiTkqhXGCjTYcVeXV;

		private readonly int uMlElWUrgbAIiKkrXJRnPAvpqytV;

		private readonly int UKQIuyGITJLNlkJdHGiQDgySzqS;

		private readonly int EqJUUgTPAMPnpzGTWoBKqTxaUEy;

		private readonly int LNhGgNDPZPxNQoVvjFRWNyRKYYRm;

		private readonly int lqaAMJIZSHTFOORbtbjXnblDwbb;

		private readonly NativeBuffer kBUmUcAyFhoFeddZhyvELUyrNQP;

		private readonly NativeBuffer xQtqlAYhQUqbOGYibktAZaYeTPW;

		private readonly OutputReport wDqsBPZBSKtSLRDQNHWwaHOApvg;

		private readonly Func<OutputReport, bool> KoLbpdtSgwWZhTuekQfZVolIbnZ;

		private readonly Action<OutputReport> beVWMbKDuyboNeDypPMnahQkenTj;

		private bool nMRHwDHVkyhFMsbxVAyMIhvJflG;

		private bool zTheBZCijedqOOizslwtClyldJc;

		private float EHhmtnRpZFDWxBhVxCnDiVSQCODb;

		private byte mhKlLLqqMAKyZlptFRQvuxlqHUM;

		private Quaternion BqzyKqeMRqWdVzqIGDtBAZJqmAW = Quaternion.identity;

		private ushort ofrjjRPapttBAlbDWLilShKwGHj;

		private float DDCLILznEmjHXRNGlShJQmgUAjo;

		private float ZyMzwUpLeqFNyNWsSptXYJmqUTp;

		private float czatfHRzqfCSyRnqBZwBRVKyPLf;

		private byte YFQNDSyDOKaQqFCDUMVSsqUKNcks;

		private byte razBnFUPWcgkvONpWLoHwSoEgea;

		private Quaternion RwqCCllDmvDcaeupJLChTYgRdhLT = Quaternion.identity;

		private bool IAVhrwZXyddpahAmYQQWnhnCQyR;

		private int TzJfvFzrmRpepYoNHgNTYZIRTkP;

		private int[] ZpXAlFZqpXnApjyTRbLgLCEZsh = new int[2];

		private int[] eVCzMVdIwbBgoceyyoIcZaFUlHuH = new int[2];

		private bool isVibrating
		{
			get
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < base.VibrationMotorCount)
					{
						num2 = 1413113691;
						num3 = num2;
					}
					else
					{
						num2 = 1413113688;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x543A6759)
						{
						case 3:
							num2 = 1413113691;
							continue;
						case 0:
							break;
						case 4:
							return true;
						case 2:
							if (vibrationMotors[num].SpeedRaw <= 0)
							{
								num++;
								num2 = 1413113689;
							}
							else
							{
								num2 = 1413113693;
							}
							continue;
						default:
							return false;
						}
						break;
					}
				}
			}
		}

		public float BatteryLevel
		{
			get
			{
				float value = 0f;
				if (IPmdjkAEMPygLJbnslqnNUFTGYEh)
				{
					goto IL_000e;
				}
				goto IL_0034;
				IL_000e:
				int num = -7709056;
				goto IL_0013;
				IL_0013:
				while (true)
				{
					switch (num ^ -7709054)
					{
					case 4:
						break;
					case 3:
						goto IL_0034;
					case 1:
						num = -7709054;
						continue;
					case 2:
						value = (float)(mhKlLLqqMAKyZlptFRQvuxlqHUM + 2) * 10f;
						num = -7709053;
						continue;
					default:
						return MathTools.Clamp(value, 0f, 100f);
					}
					break;
				}
				goto IL_000e;
				IL_0034:
				value = (float)(mhKlLLqqMAKyZlptFRQvuxlqHUM - 1) * 10f;
				num = -7709054;
				goto IL_0013;
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
				return (int)YFQNDSyDOKaQqFCDUMVSsqUKNcks;
			}
			set
			{
				YFQNDSyDOKaQqFCDUMVSsqUKNcks = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				nMRHwDHVkyhFMsbxVAyMIhvJflG = true;
				if (YFQNDSyDOKaQqFCDUMVSsqUKNcks != 0 || razBnFUPWcgkvONpWLoHwSoEgea != 0)
				{
					return;
				}
				while (true)
				{
					int num = 277419137;
					while (true)
					{
						switch (num ^ 0x10891483)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0061;
						case 1:
							return;
						}
						break;
						IL_0061:
						zTheBZCijedqOOizslwtClyldJc = true;
						num = 277419138;
					}
				}
			}
		}

		public float LightFlashOffDuration
		{
			get
			{
				return (int)razBnFUPWcgkvONpWLoHwSoEgea;
			}
			set
			{
				razBnFUPWcgkvONpWLoHwSoEgea = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				nMRHwDHVkyhFMsbxVAyMIhvJflG = true;
				if (YFQNDSyDOKaQqFCDUMVSsqUKNcks != 0 || razBnFUPWcgkvONpWLoHwSoEgea != 0)
				{
					return;
				}
				while (true)
				{
					int num = 2092996671;
					while (true)
					{
						switch (num ^ 0x7CC0983D)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0061;
						case 1:
							return;
						}
						break;
						IL_0061:
						zTheBZCijedqOOizslwtClyldJc = true;
						num = 2092996668;
					}
				}
			}
		}

		public Vector3 AccelerometerValue
		{
			get
			{
				return gfIksWBUPneTPwaSnJsaSgelRIB(accelerometers[0].rawValue);
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
				return wtISYhCRCzycHFisAlOtNIIrXDR(gyroscopes[0].events);
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
				return wtISYhCRCzycHFisAlOtNIIrXDR(vector, DDCLILznEmjHXRNGlShJQmgUAjo);
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
				return BqzyKqeMRqWdVzqIGDtBAZJqmAW;
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
			BqzyKqeMRqWdVzqIGDtBAZJqmAW = Quaternion.identity;
		}

		public int GetTouchCount()
		{
			int num = 0;
			int num2 = 0;
			while (num2 < 2)
			{
				while (true)
				{
					int num3;
					if (touchpads[0].values[num2].isTouching)
					{
						num++;
						num3 = -185660250;
						goto IL_000b;
					}
					goto IL_004d;
					IL_000b:
					while (true)
					{
						switch (num3 ^ -185660251)
						{
						case 0:
							num3 = -185660252;
							continue;
						case 1:
							break;
						case 3:
							goto IL_004d;
						default:
							goto end_IL_0028;
						}
						break;
					}
					continue;
					IL_004d:
					num2++;
					num3 = -185660249;
					goto IL_000b;
					continue;
					end_IL_0028:
					break;
				}
			}
			return num;
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
			if (index >= 0)
			{
				while (true)
				{
					int num = 560320241;
					while (true)
					{
						switch (num ^ 0x2165CEF0)
						{
						case 0:
							break;
						case 1:
							goto IL_0022;
						default:
							goto end_IL_0004;
						}
						break;
						IL_0022:
						if (index >= 2)
						{
							num = 560320242;
							continue;
						}
						return touchpads[0].values[index].touchId;
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			return -1;
		}

		public bool GetTouchPositionByIndex(int index, out Vector2 position)
		{
			position = default(Vector2);
			while (true)
			{
				int num = -509860250;
				while (true)
				{
					switch (num ^ -509860249)
					{
					case 0:
						break;
					case 1:
						if (index >= 0)
						{
							if (index >= 2)
							{
								goto IL_002d;
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
						goto default;
					default:
						return false;
					}
					break;
					IL_002d:
					num = -509860251;
				}
			}
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			position = default(Vector2);
			HIDTouchpad.TouchData[] values = default(HIDTouchpad.TouchData[]);
			int num2 = default(int);
			while (true)
			{
				int num = 1552280307;
				while (true)
				{
					switch (num ^ 0x5C85EAF6)
					{
					case 0:
						break;
					case 5:
						if (!touchpads[0].IsTouching(touchId))
						{
							return false;
						}
						values = touchpads[0].values;
						num2 = 0;
						num = 1552280304;
						continue;
					case 3:
						if (values[num2].isTouching)
						{
							position.x = values[num2].positionX;
							position.y = values[num2].positionY;
							num = 1552280311;
							continue;
						}
						goto case 1;
					case 1:
						num2++;
						num = 1552280308;
						continue;
					case 2:
					{
						int num3;
						if (num2 < values.Length)
						{
							num = 1552280309;
							num3 = num;
						}
						else
						{
							num = 1552280306;
							num3 = num;
						}
						continue;
					}
					case 6:
						num = 1552280308;
						continue;
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
			while (true)
			{
				int num = 99202557;
				while (true)
				{
					switch (num ^ 0x5E9B5FC)
					{
					case 0:
						break;
					case 1:
						if (index >= 0)
						{
							if (index >= 2)
							{
								goto IL_002c;
							}
							HIDTouchpad.TouchData[] values = touchpads[0].values;
							if (!values[index].isTouching)
							{
								return false;
							}
							positionX = values[index].positionAbsX;
							positionY = values[index].positionAbsY;
							return true;
						}
						goto default;
					default:
						return false;
					}
					break;
					IL_002c:
					num = 99202558;
				}
			}
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (!touchpads[0].IsTouching(touchId))
			{
				return false;
			}
			HIDTouchpad.TouchData[] values = touchpads[0].values;
			int num2 = default(int);
			while (true)
			{
				int num = 1436662393;
				while (true)
				{
					switch (num ^ 0x55A1BA78)
					{
					case 4:
						break;
					case 1:
						num2 = 0;
						num = 1436662392;
						continue;
					case 2:
						num2++;
						num = 1436662392;
						continue;
					case 3:
						if (values[num2].isTouching)
						{
							positionX = values[num2].positionAbsX;
							positionY = values[num2].positionAbsY;
							num = 1436662394;
							continue;
						}
						goto case 2;
					default:
						if (num2 >= values.Length)
						{
							return true;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public void StopLightFlash()
		{
			YFQNDSyDOKaQqFCDUMVSsqUKNcks = 0;
			razBnFUPWcgkvONpWLoHwSoEgea = 0;
			nMRHwDHVkyhFMsbxVAyMIhvJflG = true;
			zTheBZCijedqOOizslwtClyldJc = true;
		}

		public void StopVibration()
		{
			int vibrationMotorCount = base.VibrationMotorCount;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= vibrationMotorCount)
				{
					num2 = 728445219;
					num3 = num2;
				}
				else
				{
					num2 = 728445218;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x2B6B3123)
					{
					case 3:
						num2 = 728445218;
						continue;
					default:
						return;
					case 1:
						vibrationMotors[num].SpeedRaw = 0;
						num++;
						num2 = 728445217;
						continue;
					case 2:
						break;
					case 0:
						return;
					}
					break;
				}
			}
		}

		public DualShock4Driver(InitArgs initArgs)
		{
			int num2 = default(int);
			while (true)
			{
				int num = 1816774694;
				while (true)
				{
					switch (num ^ 0x6C49C82E)
					{
					case 13:
						break;
					case 12:
						PerPoXkTXfpOMQfRmGkfJQQHaoP = true;
						PerPoXkTXfpOMQfRmGkfJQQHaoP = ACsIgxEitXcAKXzTiBHLxHBNdSep(UNPjxDoysgcOYEVoxVPcTxAqJcM.lTnAdpWaglqAxhztbdqtVMKSoaa);
						num = 1816774700;
						continue;
					case 6:
						EqJUUgTPAMPnpzGTWoBKqTxaUEy = 5 + UKQIuyGITJLNlkJdHGiQDgySzqS;
						num = 1816774701;
						continue;
					case 16:
						uMlElWUrgbAIiKkrXJRnPAvpqytV = 78;
						num = 1816774703;
						continue;
					case 14:
					{
						KoLbpdtSgwWZhTuekQfZVolIbnZ = initArgs.synchronousWriteOutputReportDelegate;
						beVWMbKDuyboNeDypPMnahQkenTj = initArgs.asynchronousWriteOutputReportDelegate;
						IPmdjkAEMPygLJbnslqnNUFTGYEh = initArgs.connectionType == DeviceConnectionType.qsDfuTzZaVPhIJLeNOadBBAjTAI;
						int num5;
						if (IPmdjkAEMPygLJbnslqnNUFTGYEh)
						{
							num = 1816774718;
							num5 = num;
						}
						else
						{
							num = 1816774703;
							num5 = num;
						}
						continue;
					}
					case 4:
					{
						int num3;
						if (!IPmdjkAEMPygLJbnslqnNUFTGYEh)
						{
							num = 1816774696;
							num3 = num;
						}
						else
						{
							num = 1816774702;
							num3 = num;
						}
						continue;
					}
					case 17:
						wDqsBPZBSKtSLRDQNHWwaHOApvg.options &= ~OutputReportOptions.iTJdYGHWgyKEolybYDyTnKjmMCoD;
						num = 1816774700;
						continue;
					case 5:
						kBUmUcAyFhoFeddZhyvELUyrNQP = new NativeBuffer(64);
						num = 1816774695;
						continue;
					case 11:
						buttons[num2] = new HIDButton(IBtisnbbWWhGYoIFHfsNUGxPeeLX, new HIDControllerElement.HIDInfo
						{
							usagePage = 9,
							usage = (ushort)num2
						});
						num2++;
						num = 1816774697;
						continue;
					case 3:
						LNhGgNDPZPxNQoVvjFRWNyRKYYRm = 6 + UKQIuyGITJLNlkJdHGiQDgySzqS;
						lqaAMJIZSHTFOORbtbjXnblDwbb = 7 + UKQIuyGITJLNlkJdHGiQDgySzqS;
						num = 1816774689;
						continue;
					case 2:
						IBtisnbbWWhGYoIFHfsNUGxPeeLX = 1;
						UKQIuyGITJLNlkJdHGiQDgySzqS = 0;
						num = 1816774698;
						continue;
					case 1:
						if (uMlElWUrgbAIiKkrXJRnPAvpqytV < 23)
						{
							uMlElWUrgbAIiKkrXJRnPAvpqytV = 23;
							num = 1816774699;
							continue;
						}
						goto case 5;
					case 15:
						buttons = new HIDButton[14];
						num2 = 0;
						num = 1816774697;
						continue;
					case 9:
						xQtqlAYhQUqbOGYibktAZaYeTPW = new NativeBuffer(uMlElWUrgbAIiKkrXJRnPAvpqytV);
						wDqsBPZBSKtSLRDQNHWwaHOApvg = new OutputReport(xQtqlAYhQUqbOGYibktAZaYeTPW.Pointer, xQtqlAYhQUqbOGYibktAZaYeTPW.Length, uMlElWUrgbAIiKkrXJRnPAvpqytV);
						lights = new HIDLight[1]
						{
							new HIDLight(11, 24, 28)
						};
						lights[0].ValueChangedEvent += QuUBefhkJoFCpSvXPRjpEsdcMJcg;
						vibrationMotors = new HIDVibrationMotor[2]
						{
							new HIDVibrationMotor(0, 255),
							new HIDVibrationMotor(0, 255)
						};
						vibrationMotors[0].ValueChangedEvent += QuUBefhkJoFCpSvXPRjpEsdcMJcg;
						vibrationMotors[1].ValueChangedEvent += QuUBefhkJoFCpSvXPRjpEsdcMJcg;
						if (IPmdjkAEMPygLJbnslqnNUFTGYEh)
						{
							wDqsBPZBSKtSLRDQNHWwaHOApvg.options |= OutputReportOptions.iTJdYGHWgyKEolybYDyTnKjmMCoD;
							PerPoXkTXfpOMQfRmGkfJQQHaoP = true;
							num = 1816774692;
							continue;
						}
						goto case 12;
					case 18:
						ZuJUdCsQtJchgnotWnEYnVMXpZe = initArgs.hatZeroValue;
						BNlvTZuaNEZiINaOUJRyylCWGluH = initArgs.hatSpan;
						IHXNCBnWSZMiTkqhXGCjTYcVeXV = initArgs.inputReportLength;
						uMlElWUrgbAIiKkrXJRnPAvpqytV = initArgs.outputReportLength;
						num = 1816774688;
						continue;
					case 10:
					{
						PerPoXkTXfpOMQfRmGkfJQQHaoP = ACsIgxEitXcAKXzTiBHLxHBNdSep(UNPjxDoysgcOYEVoxVPcTxAqJcM.lTnAdpWaglqAxhztbdqtVMKSoaa);
						int num4;
						if (PerPoXkTXfpOMQfRmGkfJQQHaoP)
						{
							num = 1816774700;
							num4 = num;
						}
						else
						{
							num = 1816774719;
							num4 = num;
						}
						continue;
					}
					case 0:
						if (PerPoXkTXfpOMQfRmGkfJQQHaoP)
						{
							IBtisnbbWWhGYoIFHfsNUGxPeeLX = 17;
							UKQIuyGITJLNlkJdHGiQDgySzqS = 2;
							num = 1816774696;
							continue;
						}
						goto case 6;
					case 8:
						if (initArgs == null)
						{
							throw new ArgumentNullException("initArgs");
						}
						goto case 18;
					default:
						if (num2 >= 14)
						{
							axes = new HIDAxis[6]
							{
								new HIDAxis(IBtisnbbWWhGYoIFHfsNUGxPeeLX, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 48,
									dataIndex = 1 + UKQIuyGITJLNlkJdHGiQDgySzqS,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 0,
									units = 0u,
									unitsExp = 0u
								}, false, 127),
								new HIDAxis(IBtisnbbWWhGYoIFHfsNUGxPeeLX, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 49,
									dataIndex = 2 + UKQIuyGITJLNlkJdHGiQDgySzqS,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 0,
									units = 0u,
									unitsExp = 0u
								}, false, 127),
								new HIDAxis(IBtisnbbWWhGYoIFHfsNUGxPeeLX, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 50,
									dataIndex = 3 + UKQIuyGITJLNlkJdHGiQDgySzqS,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 0,
									units = 0u,
									unitsExp = 0u
								}, false, 127),
								new HIDAxis(IBtisnbbWWhGYoIFHfsNUGxPeeLX, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 53,
									dataIndex = 4 + UKQIuyGITJLNlkJdHGiQDgySzqS,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 0,
									units = 0u,
									unitsExp = 0u
								}, false, 127),
								new HIDAxis(IBtisnbbWWhGYoIFHfsNUGxPeeLX, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 51,
									dataIndex = 8 + UKQIuyGITJLNlkJdHGiQDgySzqS,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 315,
									units = 0u,
									unitsExp = 0u
								}, false, 0),
								new HIDAxis(IBtisnbbWWhGYoIFHfsNUGxPeeLX, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 52,
									dataIndex = 9 + UKQIuyGITJLNlkJdHGiQDgySzqS,
									bitSize = 8,
									logicalMin = 0,
									logicalMax = 255,
									physicalMin = 0,
									physicalMax = 315,
									units = 0u,
									unitsExp = 0u
								}, false, 0)
							};
							hats = new HIDHat[1]
							{
								new HIDHat(IBtisnbbWWhGYoIFHfsNUGxPeeLX, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									usage = 57,
									dataIndex = 5 + UKQIuyGITJLNlkJdHGiQDgySzqS,
									bitSize = 4,
									logicalMin = 0,
									logicalMax = 7,
									physicalMin = 0,
									physicalMax = 315,
									units = 20u,
									unitsExp = 0u
								}, OZVJCHVuQRDHwhJESGzfdPGcpPXg)
							};
							accelerometers = new HIDAccelerometer[1]
							{
								new HIDAccelerometer(IBtisnbbWWhGYoIFHfsNUGxPeeLX, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									dataIndex = 19 + UKQIuyGITJLNlkJdHGiQDgySzqS,
									bitSize = 48
								}, 3, KfnWFiyMnJFYWBOoIDDEkithkDJ)
							};
							gyroscopes = new HIDGyroscope[1]
							{
								new HIDGyroscope(initArgs.updateLoopSetting, IBtisnbbWWhGYoIFHfsNUGxPeeLX, new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									dataIndex = 13 + UKQIuyGITJLNlkJdHGiQDgySzqS,
									bitSize = 48
								}, 3, 25, NsoYwvXAMxiVoPSgaWbJtBxNaEa, WVxFGFNrZebWrUluTTeeuhuHwIx)
							};
							touchpads = new HIDTouchpad[1]
							{
								new HIDTouchpad(IBtisnbbWWhGYoIFHfsNUGxPeeLX, new HIDTouchpad.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new HIDControllerElement.HIDInfo
								{
									usagePage = 1,
									dataIndex = 35 + UKQIuyGITJLNlkJdHGiQDgySzqS,
									bitSize = 48
								}, ZpfLGLPckdPLWXJSNJGEhpuQEck)
							};
							ZyMzwUpLeqFNyNWsSptXYJmqUTp = ReInput.realTime;
							return;
						}
						goto case 11;
					}
					break;
				}
			}
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			dJnLHrLkCrXvnwufhwWcVWfBtmx();
			mhIXIkSvdPJvbpqArtnvHhRDBxw(UNPjxDoysgcOYEVoxVPcTxAqJcM.PLXbAAdESbUPAfTXKCgcjTqziVz);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, float timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				goto IL_0010;
			}
			if (inputReportLength < kBUmUcAyFhoFeddZhyvELUyrNQP.Length)
			{
				return false;
			}
			float realTime = ReInput.realTime;
			int num = -506384698;
			goto IL_0015;
			IL_0010:
			num = -506384701;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ -506384702)
				{
				case 0:
					break;
				case 5:
					TncRWDNnjIHJtHMNjIvXiptqHAB(touchpads, kBUmUcAyFhoFeddZhyvELUyrNQP, realTime);
					num = -506384704;
					continue;
				case 3:
					TncRWDNnjIHJtHMNjIvXiptqHAB(axes, kBUmUcAyFhoFeddZhyvELUyrNQP, realTime);
					TncRWDNnjIHJtHMNjIvXiptqHAB(hats, kBUmUcAyFhoFeddZhyvELUyrNQP, realTime);
					TncRWDNnjIHJtHMNjIvXiptqHAB(accelerometers, kBUmUcAyFhoFeddZhyvELUyrNQP, realTime);
					num = -506384700;
					continue;
				case 4:
					czatfHRzqfCSyRnqBZwBRVKyPLf = realTime - ZyMzwUpLeqFNyNWsSptXYJmqUTp;
					ZyMzwUpLeqFNyNWsSptXYJmqUTp = realTime;
					kBUmUcAyFhoFeddZhyvELUyrNQP.Write(inputReportPtr, inputReportLength, kBUmUcAyFhoFeddZhyvELUyrNQP.Length);
					uSSbnKXlVwCkvZlpkaSWdkYPLpZT(kBUmUcAyFhoFeddZhyvELUyrNQP);
					bWqXMuWKIQJCfsxGeWCQkichWXy(kBUmUcAyFhoFeddZhyvELUyrNQP, realTime);
					num = -506384703;
					continue;
				case 1:
					return false;
				case 6:
					TncRWDNnjIHJtHMNjIvXiptqHAB(gyroscopes, kBUmUcAyFhoFeddZhyvELUyrNQP, realTime);
					num = -506384697;
					continue;
				default:
					mhKlLLqqMAKyZlptFRQvuxlqHUM = (byte)(kBUmUcAyFhoFeddZhyvELUyrNQP[30 + UKQIuyGITJLNlkJdHGiQDgySzqS] & 0xF);
					yxHKHUtasBIuQNNoZTPMjWeyAgQ();
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

		private void mhIXIkSvdPJvbpqArtnvHhRDBxw(UNPjxDoysgcOYEVoxVPcTxAqJcM P_0)
		{
			if (!nMRHwDHVkyhFMsbxVAyMIhvJflG)
			{
				goto IL_0008;
			}
			goto IL_003c;
			IL_0008:
			int num = 962807595;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x39634728)
				{
				case 4:
					break;
				default:
					return;
				case 1:
					nMRHwDHVkyhFMsbxVAyMIhvJflG = false;
					num = 962807592;
					continue;
				case 2:
					goto IL_003c;
				case 3:
					return;
				case 0:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_003c:
			ACsIgxEitXcAKXzTiBHLxHBNdSep(P_0);
			num = 962807593;
			goto IL_000d;
		}

		private bool ACsIgxEitXcAKXzTiBHLxHBNdSep(UNPjxDoysgcOYEVoxVPcTxAqJcM P_0)
		{
			lIqLuvZbhVpBcfGmWiwKUvgnIba();
			bool result = WkEAduGURWkiggCMBLveDEjiPugA(P_0);
			if (zTheBZCijedqOOizslwtClyldJc)
			{
				result = WkEAduGURWkiggCMBLveDEjiPugA(P_0);
				zTheBZCijedqOOizslwtClyldJc = false;
			}
			return result;
		}

		private void lIqLuvZbhVpBcfGmWiwKUvgnIba()
		{
			if (IPmdjkAEMPygLJbnslqnNUFTGYEh && PerPoXkTXfpOMQfRmGkfJQQHaoP)
			{
				xQtqlAYhQUqbOGYibktAZaYeTPW[0] = 17;
				xQtqlAYhQUqbOGYibktAZaYeTPW[1] = 128;
				goto IL_0035;
			}
			goto IL_0136;
			IL_003a:
			int num;
			while (true)
			{
				switch (num ^ 0x2E215B97)
				{
				case 3:
					break;
				case 2:
					xQtqlAYhQUqbOGYibktAZaYeTPW[22] = 53;
					xQtqlAYhQUqbOGYibktAZaYeTPW[23] = byte.MaxValue;
					xQtqlAYhQUqbOGYibktAZaYeTPW[24] = 0;
					num = 773938066;
					continue;
				case 8:
					xQtqlAYhQUqbOGYibktAZaYeTPW[9] = YFQNDSyDOKaQqFCDUMVSsqUKNcks;
					xQtqlAYhQUqbOGYibktAZaYeTPW[10] = razBnFUPWcgkvONpWLoHwSoEgea;
					xQtqlAYhQUqbOGYibktAZaYeTPW[19] = 53;
					num = 773938077;
					continue;
				case 10:
					xQtqlAYhQUqbOGYibktAZaYeTPW[20] = 53;
					num = 773938076;
					continue;
				case 5:
					return;
				case 4:
					xQtqlAYhQUqbOGYibktAZaYeTPW[8] = lights[0].ColorBRaw;
					num = 773938079;
					continue;
				case 7:
					goto IL_0136;
				case 1:
					xQtqlAYhQUqbOGYibktAZaYeTPW[3] = byte.MaxValue;
					xQtqlAYhQUqbOGYibktAZaYeTPW[6] = (byte)vibrationMotors[1].SpeedRaw;
					num = 773938065;
					continue;
				case 0:
					xQtqlAYhQUqbOGYibktAZaYeTPW[11] = YFQNDSyDOKaQqFCDUMVSsqUKNcks;
					xQtqlAYhQUqbOGYibktAZaYeTPW[12] = razBnFUPWcgkvONpWLoHwSoEgea;
					xQtqlAYhQUqbOGYibktAZaYeTPW[21] = 53;
					num = 773938069;
					continue;
				case 6:
					xQtqlAYhQUqbOGYibktAZaYeTPW[7] = (byte)vibrationMotors[0].SpeedRaw;
					xQtqlAYhQUqbOGYibktAZaYeTPW[8] = lights[0].ColorRRaw;
					xQtqlAYhQUqbOGYibktAZaYeTPW[9] = lights[0].ColorGRaw;
					xQtqlAYhQUqbOGYibktAZaYeTPW[10] = lights[0].ColorBRaw;
					num = 773938071;
					continue;
				case 9:
					xQtqlAYhQUqbOGYibktAZaYeTPW[7] = lights[0].ColorGRaw;
					num = 773938067;
					continue;
				default:
					xQtqlAYhQUqbOGYibktAZaYeTPW[21] = byte.MaxValue;
					xQtqlAYhQUqbOGYibktAZaYeTPW[22] = 0;
					return;
				}
				break;
			}
			goto IL_0035;
			IL_0136:
			xQtqlAYhQUqbOGYibktAZaYeTPW[0] = 5;
			xQtqlAYhQUqbOGYibktAZaYeTPW[1] = byte.MaxValue;
			xQtqlAYhQUqbOGYibktAZaYeTPW[4] = (byte)vibrationMotors[1].SpeedRaw;
			xQtqlAYhQUqbOGYibktAZaYeTPW[5] = (byte)vibrationMotors[0].SpeedRaw;
			xQtqlAYhQUqbOGYibktAZaYeTPW[6] = lights[0].ColorRRaw;
			num = 773938078;
			goto IL_003a;
			IL_0035:
			num = 773938070;
			goto IL_003a;
		}

		private bool WkEAduGURWkiggCMBLveDEjiPugA(UNPjxDoysgcOYEVoxVPcTxAqJcM P_0)
		{
			EHhmtnRpZFDWxBhVxCnDiVSQCODb = ReInput.realTime + 4f;
			bool result = default(bool);
			int num;
			if (P_0 == UNPjxDoysgcOYEVoxVPcTxAqJcM.lTnAdpWaglqAxhztbdqtVMKSoaa)
			{
				if (KoLbpdtSgwWZhTuekQfZVolIbnZ == null)
				{
					goto IL_001c;
				}
				result = KoLbpdtSgwWZhTuekQfZVolIbnZ(wDqsBPZBSKtSLRDQNHWwaHOApvg);
				num = -1459496499;
			}
			else
			{
				if (P_0 != UNPjxDoysgcOYEVoxVPcTxAqJcM.PLXbAAdESbUPAfTXKCgcjTqziVz)
				{
					throw new NotImplementedException();
				}
				num = -1459496497;
			}
			goto IL_0021;
			IL_001c:
			num = -1459496498;
			goto IL_0021;
			IL_0021:
			switch (num ^ -1459496497)
			{
			case 3:
				break;
			case 1:
				return false;
			case 2:
				return result;
			default:
				if (beVWMbKDuyboNeDypPMnahQkenTj == null)
				{
					return false;
				}
				beVWMbKDuyboNeDypPMnahQkenTj(wDqsBPZBSKtSLRDQNHWwaHOApvg);
				return true;
			}
			goto IL_001c;
		}

		private void bWqXMuWKIQJCfsxGeWCQkichWXy(NativeBuffer P_0, float P_1)
		{
			byte b = P_0[EqJUUgTPAMPnpzGTWoBKqTxaUEy];
			buttons[0].SetValue((b & 0x10) != 0, P_1);
			buttons[1].SetValue((b & 0x20) != 0, P_1);
			buttons[2].SetValue((b & 0x40) != 0, P_1);
			buttons[3].SetValue((b & 0x80) != 0, P_1);
			b = P_0[LNhGgNDPZPxNQoVvjFRWNyRKYYRm];
			while (true)
			{
				int num = 289244254;
				while (true)
				{
					switch (num ^ 0x113D845F)
					{
					case 4:
						break;
					case 1:
						buttons[4].SetValue((b & 1) != 0, P_1);
						buttons[5].SetValue((b & 2) != 0, P_1);
						num = 289244252;
						continue;
					case 3:
						buttons[6].SetValue((b & 4) != 0, P_1);
						buttons[7].SetValue((b & 8) != 0, P_1);
						buttons[8].SetValue((b & 0x10) != 0, P_1);
						num = 289244255;
						continue;
					case 0:
						buttons[9].SetValue((b & 0x20) != 0, P_1);
						buttons[10].SetValue((b & 0x40) != 0, P_1);
						num = 289244253;
						continue;
					default:
						buttons[11].SetValue((b & 0x80) != 0, P_1);
						b = P_0[lqaAMJIZSHTFOORbtbjXnblDwbb];
						buttons[12].SetValue((b & 1) != 0, P_1);
						buttons[13].SetValue((b & 2) != 0, P_1);
						return;
					}
					break;
				}
			}
		}

		private void TncRWDNnjIHJtHMNjIvXiptqHAB(HIDControllerElement[] P_0, NativeBuffer P_1, float P_2)
		{
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < P_0.Length)
				{
					num2 = 404111487;
					num3 = num2;
				}
				else
				{
					num2 = 404111486;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x1816407E)
					{
					case 2:
						num2 = 404111487;
						continue;
					default:
						return;
					case 1:
						P_0[num].UpdateValue(P_1, P_2);
						num++;
						num2 = 404111485;
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

		private void dJnLHrLkCrXvnwufhwWcVWfBtmx()
		{
			if (isVibrating && ReInput.realTime >= EHhmtnRpZFDWxBhVxCnDiVSQCODb)
			{
				nMRHwDHVkyhFMsbxVAyMIhvJflG = true;
			}
		}

		private void uSSbnKXlVwCkvZlpkaSWdkYPLpZT(NativeBuffer P_0)
		{
			if (!PerPoXkTXfpOMQfRmGkfJQQHaoP)
			{
				return;
			}
			float dDCLILznEmjHXRNGlShJQmgUAjo = default(float);
			while (true)
			{
				ushort num = kBUmUcAyFhoFeddZhyvELUyrNQP.ReadUShort(10 + UKQIuyGITJLNlkJdHGiQDgySzqS);
				int num2 = -545978529;
				while (true)
				{
					switch (num2 ^ -545978535)
					{
					case 0:
						num2 = -545978534;
						continue;
					default:
						return;
					case 5:
						if (num > ofrjjRPapttBAlbDWLilShKwGHj)
						{
							dDCLILznEmjHXRNGlShJQmgUAjo = 1f / (float)(num - ofrjjRPapttBAlbDWLilShKwGHj);
							num2 = -545978530;
							continue;
						}
						goto case 4;
					case 6:
						if (num < ofrjjRPapttBAlbDWLilShKwGHj)
						{
							dDCLILznEmjHXRNGlShJQmgUAjo = 1f / (float)(num + 65535 - ofrjjRPapttBAlbDWLilShKwGHj);
							num2 = -545978530;
							continue;
						}
						goto case 5;
					case 4:
						dDCLILznEmjHXRNGlShJQmgUAjo = 0f;
						num2 = -545978530;
						continue;
					case 3:
						break;
					case 7:
						ofrjjRPapttBAlbDWLilShKwGHj = num;
						num2 = -545978536;
						continue;
					case 1:
						DDCLILznEmjHXRNGlShJQmgUAjo = dDCLILznEmjHXRNGlShJQmgUAjo;
						DDCLILznEmjHXRNGlShJQmgUAjo = czatfHRzqfCSyRnqBZwBRVKyPLf;
						num2 = -545978533;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void yxHKHUtasBIuQNNoZTPMjWeyAgQ()
		{
			if (!PerPoXkTXfpOMQfRmGkfJQQHaoP)
			{
				goto IL_0008;
			}
			goto IL_0036;
			IL_0008:
			int num = -884611360;
			goto IL_000d;
			IL_000d:
			switch (num ^ -884611359)
			{
			case 2:
				break;
			case 1:
				return;
			case 4:
				goto IL_0036;
			case 0:
				return;
			default:
			{
				Vector3 vector = wtISYhCRCzycHFisAlOtNIIrXDR(new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]), DDCLILznEmjHXRNGlShJQmgUAjo);
				Vector3 vector2 = new Vector3(accelerometers[0].rawValue[0] * -1f, accelerometers[0].rawValue[1] * -1f, accelerometers[0].rawValue[2] * -1f);
				tqhIKiigFbbAwQxmgOhWpaWsfxf(vector2, vector);
				return;
			}
			}
			goto IL_0008;
			IL_0036:
			int num2;
			if (DDCLILznEmjHXRNGlShJQmgUAjo <= 0f)
			{
				num = -884611359;
				num2 = num;
			}
			else
			{
				num = -884611358;
				num2 = num;
			}
			goto IL_000d;
		}

		private void tqhIKiigFbbAwQxmgOhWpaWsfxf(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			OIJTHJtnXdTuDYmTeTRraFfLFEWg oIJTHJtnXdTuDYmTeTRraFfLFEWg = default(OIJTHJtnXdTuDYmTeTRraFfLFEWg);
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && CAWknWkhOtRGqsjMKOSuNHBkteW(P_0, out oIJTHJtnXdTuDYmTeTRraFfLFEWg))
			{
				goto IL_0033;
			}
			goto IL_00ec;
			IL_0038:
			int num;
			Quaternion b = default(Quaternion);
			Quaternion a = default(Quaternion);
			while (true)
			{
				switch (num ^ 0x1C4527AE)
				{
				case 0:
					break;
				default:
					return;
				case 4:
					goto IL_0074;
				case 3:
					if (IAVhrwZXyddpahAmYQQWnhnCQyR)
					{
						IAVhrwZXyddpahAmYQQWnhnCQyR = false;
						num = 474294182;
						continue;
					}
					return;
				case 10:
					RwqCCllDmvDcaeupJLChTYgRdhLT *= quaternion;
					if ((oIJTHJtnXdTuDYmTeTRraFfLFEWg & OIJTHJtnXdTuDYmTeTRraFfLFEWg.nHExoOJHSKhwzDejIGfajTEJGjw) != OIJTHJtnXdTuDYmTeTRraFfLFEWg.TCGihQKDgeeGtvEXifcuojmabzj)
					{
						b = dhagaeodIeCaZTtNzbkTBVAXLGmW(P_0, a.eulerAngles.y);
						num = 474294188;
						continue;
					}
					goto case 1;
				case 5:
					goto IL_00ec;
				case 7:
					IAVhrwZXyddpahAmYQQWnhnCQyR = true;
					num = 474294183;
					continue;
				case 6:
					b = Quaternion.identity;
					num = 474294188;
					continue;
				case 9:
					RwqCCllDmvDcaeupJLChTYgRdhLT = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					num = 474294180;
					continue;
				case 2:
					BqzyKqeMRqWdVzqIGDtBAZJqmAW = Quaternion.Lerp(a, b, 0.01999998f);
					return;
				case 1:
					if ((oIJTHJtnXdTuDYmTeTRraFfLFEWg & OIJTHJtnXdTuDYmTeTRraFfLFEWg.HsdTpmcCbyhcpteKCHBHGDBMpxWc) != OIJTHJtnXdTuDYmTeTRraFfLFEWg.TCGihQKDgeeGtvEXifcuojmabzj)
					{
						b = giFUJOwViBqcokLnxDtGTORTDnt(P_0);
						num = 474294188;
						continue;
					}
					goto case 6;
				case 8:
					return;
				}
				break;
				IL_0074:
				a = BqzyKqeMRqWdVzqIGDtBAZJqmAW * quaternion;
				int num2;
				if (!IAVhrwZXyddpahAmYQQWnhnCQyR)
				{
					num = 474294185;
					num2 = num;
				}
				else
				{
					num = 474294180;
					num2 = num;
				}
			}
			goto IL_0033;
			IL_00ec:
			BqzyKqeMRqWdVzqIGDtBAZJqmAW *= quaternion;
			num = 474294189;
			goto IL_0038;
			IL_0033:
			num = 474294186;
			goto IL_0038;
		}

		private static Quaternion WoCAETIzOugaKdEeMWRYlLkKiVA(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = new Vector3(P_0.x, P_0.y, P_0.z);
			Vector3 vector2 = kZIoWrUVEtMrYcRbCQetUoIbbzQ(vector, P_1);
			return new Quaternion(vector2.x, vector2.y, vector2.z, P_0.w);
		}

		private static Vector3 kZIoWrUVEtMrYcRbCQetUoIbbzQ(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion WtoONZQLpeSKZhWXfOQsdUNVaqD(Quaternion P_0, SJypzpVxRgDShwLQEGDypUpSoNA P_1)
		{
			Vector4 vector = default(Vector4);
			float num4 = default(float);
			float num3 = default(float);
			while (true)
			{
				int num = 1322516340;
				while (true)
				{
					switch (num ^ 0x4ED3FF70)
					{
					case 0:
						break;
					case 2:
						vector[3] = P_0.w / num4;
						vector[(int)P_1] = num3 / num4;
						P_0 = new Quaternion(vector[0], vector[1], vector[2], vector[3]);
						num = 1322516341;
						continue;
					case 3:
						P_0 = Quaternion.identity;
						num = 1322516341;
						continue;
					case 4:
						if (MathTools.Approximately(P_0.w, 0f))
						{
							int num2;
							if (!MathTools.Approximately(P_0[(int)P_1], 0f))
							{
								num = 1322516337;
								num2 = num;
							}
							else
							{
								num = 1322516339;
								num2 = num;
							}
							continue;
						}
						goto case 1;
					case 1:
						num3 = P_0[(int)P_1];
						num4 = MathTools.Sqrt(P_0.w * P_0.w + num3 * num3);
						num = 1322516338;
						continue;
					default:
						return P_0;
					}
					break;
				}
			}
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			float num = quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z + quaternion.w * quaternion.w;
			float num2 = 1f / num;
			Quaternion result = default(Quaternion);
			result.x = (0f - quaternion.x) * num2;
			while (true)
			{
				int num3 = 2072120669;
				while (true)
				{
					switch (num3 ^ 0x7B820D5E)
					{
					case 2:
						break;
					case 3:
						result.y = (0f - quaternion.y) * num2;
						num3 = 2072120670;
						continue;
					case 0:
						result.z = (0f - quaternion.z) * num2;
						num3 = 2072120671;
						continue;
					default:
						result.w = quaternion.w * num2;
						return result;
					}
					break;
				}
			}
		}

		private float ibjbgvVzxnFxVfIqSshaXRcgNhs(float P_0, float P_1)
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
				num = 1508343208;
				goto IL_0030;
			}
			goto IL_0061;
			IL_0061:
			return P_0 - P_1;
			IL_002b:
			num = 1508343211;
			goto IL_0030;
			IL_0030:
			switch (num ^ 0x59E77DA9)
			{
			case 0:
				break;
			case 2:
				goto IL_0049;
			default:
				goto IL_0061;
			}
			goto IL_002b;
		}

		private Vector3 ubRWdXJakAaRQZBHwECaJyPbtbAl(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
			float num2 = MathTools.Atan2(P_0.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x2, P_1, z);
		}

		private Quaternion dhagaeodIeCaZTtNzbkTBVAXLGmW(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
			float num2 = MathTools.Atan2(P_0.x, x);
			float x2 = default(float);
			while (true)
			{
				int num3 = -980594866;
				while (true)
				{
					switch (num3 ^ -980594865)
					{
					case 2:
						break;
					case 1:
						goto IL_0069;
					default:
					{
						float z = (0f - num2) * 57.29578f;
						return Quaternion.Euler(x2, P_1, z);
					}
					}
					break;
					IL_0069:
					x2 = num * 57.29578f + 180f;
					num3 = -980594865;
				}
			}
		}

		private Quaternion giFUJOwViBqcokLnxDtGTORTDnt(Vector3 P_0, float P_1 = 0f)
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

		private float ICBrSgDwrobPQesrwAuocnGleFz(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool NzcCLvczOPwlgBmEjjIkvzkzoeee(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool CAWknWkhOtRGqsjMKOSuNHBkteW(Vector3 P_0, out OIJTHJtnXdTuDYmTeTRraFfLFEWg P_1)
		{
			P_0.Normalize();
			bool result = default(bool);
			while (true)
			{
				int num = -1323442457;
				while (true)
				{
					switch (num ^ -1323442459)
					{
					case 4:
						break;
					case 2:
						P_1 = OIJTHJtnXdTuDYmTeTRraFfLFEWg.TCGihQKDgeeGtvEXifcuojmabzj;
						result = false;
						if (gUZQrjUyUNwVzdxmlKQnZLHvaiO(P_0))
						{
							result = true;
							num = -1323442460;
							continue;
						}
						goto case 0;
					case 0:
						if (ZmjKlswgeasNwBPycJzTEriYeEK(P_0))
						{
							result = true;
							P_1 |= OIJTHJtnXdTuDYmTeTRraFfLFEWg.HsdTpmcCbyhcpteKCHBHGDBMpxWc;
							num = -1323442458;
							continue;
						}
						goto default;
					case 1:
						P_1 |= OIJTHJtnXdTuDYmTeTRraFfLFEWg.nHExoOJHSKhwzDejIGfajTEJGjw;
						num = -1323442459;
						continue;
					default:
						return result;
					}
					break;
				}
			}
		}

		private bool gUZQrjUyUNwVzdxmlKQnZLHvaiO(Vector3 P_0)
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

		private bool ZmjKlswgeasNwBPycJzTEriYeEK(Vector3 P_0)
		{
			return false;
		}

		private Vector3 gfIksWBUPneTPwaSnJsaSgelRIB(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 wtISYhCRCzycHFisAlOtNIIrXDR(ExpandableArray_DataContainer<HIDGyroscope.KGLRdXPUfwSsizYSSfUaLfurGQ> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					HIDGyroscope.KGLRdXPUfwSsizYSSfUaLfurGQ kGLRdXPUfwSsizYSSfUaLfurGQ = P_0[num];
					int num2 = -657694114;
					while (true)
					{
						switch (num2 ^ -657694115)
						{
						case 0:
							num2 = -657694113;
							continue;
						case 2:
							break;
						case 1:
							num++;
							num2 = -657694119;
							continue;
						case 3:
							result += wtISYhCRCzycHFisAlOtNIIrXDR(kGLRdXPUfwSsizYSSfUaLfurGQ.mgdDrIvxATYlYDqhWbLUTOsrlhk, kGLRdXPUfwSsizYSSfUaLfurGQ.FeeKHQjHmaGhpevLgnOQQqEXhVFc);
							num2 = -657694116;
							continue;
						default:
							goto end_IL_0039;
						}
						break;
					}
					continue;
					end_IL_0039:
					break;
				}
			}
			return result;
		}

		private Vector3 wtISYhCRCzycHFisAlOtNIIrXDR(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.05595291f * P_1;
		}

		private int OZVJCHVuQRDHwhJESGzfdPGcpPXg(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void KfnWFiyMnJFYWBOoIDDEkithkDJ(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void NsoYwvXAMxiVoPSgaWbJtBxNaEa(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			while (true)
			{
				int num = 1939230119;
				while (true)
				{
					switch (num ^ 0x73964DA6)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						P_1[1] = BitConverter.ToInt16(P_0, 2);
						num = 1939230116;
						continue;
					case 2:
						P_1[2] = BitConverter.ToInt16(P_0, 4);
						num = 1939230118;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private float WVxFGFNrZebWrUluTTeeuhuHwIx()
		{
			return DDCLILznEmjHXRNGlShJQmgUAjo;
		}

		private void ZpfLGLPckdPLWXJSNJGEhpuQEck(NativeBuffer P_0, HIDTouchpad.TouchData[] P_1)
		{
			int num = 35 + UKQIuyGITJLNlkJdHGiQDgySzqS;
			int positionRawX = P_0[1 + num] + (P_0[2 + num] & 0xF) * 255;
			bool flag2 = default(bool);
			byte b = default(byte);
			bool flag = default(bool);
			int num4 = default(int);
			int num3 = default(int);
			int positionRawY = default(int);
			int positionRawX2 = default(int);
			int positionRawY2 = default(int);
			while (true)
			{
				int num2 = -1110121140;
				while (true)
				{
					switch (num2 ^ -1110121139)
					{
					case 0:
						break;
					case 5:
					{
						flag2 = b < 128;
						byte b2 = P_0[num + 4];
						flag = b2 < 128;
						num4 = b & 0x7F;
						num3 = b2 & 0x7F;
						P_1[0].isTouching = flag2;
						num2 = -1110121143;
						continue;
					}
					case 4:
						P_1[0].touchId = TwMutOTYkuWuVJqwVUrCsHRCESI(0, flag2, num4);
						num2 = -1110121138;
						continue;
					case 1:
						positionRawY = ((P_0[2 + num] & 0xF0) >> 4) + P_0[3 + num] * 16;
						positionRawX2 = P_0[5 + num] + (P_0[6 + num] & 0xF) * 255;
						num2 = -1110121137;
						continue;
					case 2:
						positionRawY2 = ((P_0[6 + num] & 0xF0) >> 4) + P_0[7 + num] * 16;
						b = P_0[num];
						num2 = -1110121144;
						continue;
					default:
						P_1[0].positionRawX = positionRawX;
						P_1[0].positionRawY = positionRawY;
						P_1[1].isTouching = flag;
						P_1[1].touchId = TwMutOTYkuWuVJqwVUrCsHRCESI(1, flag, num3);
						P_1[1].positionRawX = positionRawX2;
						P_1[1].positionRawY = positionRawY2;
						return;
					}
					break;
				}
			}
		}

		private int TwMutOTYkuWuVJqwVUrCsHRCESI(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				ZpXAlFZqpXnApjyTRbLgLCEZsh[P_0] = -1;
				goto IL_000c;
			}
			int tzJfvFzrmRpepYoNHgNTYZIRTkP = default(int);
			int num;
			if (P_2 != eVCzMVdIwbBgoceyyoIcZaFUlHuH[P_0])
			{
				tzJfvFzrmRpepYoNHgNTYZIRTkP = TzJfvFzrmRpepYoNHgNTYZIRTkP;
				if (TzJfvFzrmRpepYoNHgNTYZIRTkP == int.MaxValue)
				{
					TzJfvFzrmRpepYoNHgNTYZIRTkP = 0;
					num = -1397775390;
					goto IL_0011;
				}
				goto IL_008e;
			}
			return ZpXAlFZqpXnApjyTRbLgLCEZsh[P_0];
			IL_008e:
			TzJfvFzrmRpepYoNHgNTYZIRTkP++;
			num = -1397775390;
			goto IL_0011;
			IL_0011:
			while (true)
			{
				switch (num ^ -1397775391)
				{
				case 2:
					break;
				case 1:
					eVCzMVdIwbBgoceyyoIcZaFUlHuH[P_0] = P_2;
					num = -1397775391;
					continue;
				case 3:
					eVCzMVdIwbBgoceyyoIcZaFUlHuH[P_0] = P_2;
					ZpXAlFZqpXnApjyTRbLgLCEZsh[P_0] = tzJfvFzrmRpepYoNHgNTYZIRTkP;
					num = -1397775388;
					continue;
				case 0:
					return -1;
				case 4:
					goto IL_008e;
				default:
					return tzJfvFzrmRpepYoNHgNTYZIRTkP;
				}
				break;
			}
			goto IL_000c;
			IL_000c:
			num = -1397775392;
			goto IL_0011;
		}

		private void QuUBefhkJoFCpSvXPRjpEsdcMJcg()
		{
			nMRHwDHVkyhFMsbxVAyMIhvJflG = true;
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
				if (!disposing)
				{
					break;
				}
				StopVibration();
				mhIXIkSvdPJvbpqArtnvHhRDBxw(UNPjxDoysgcOYEVoxVPcTxAqJcM.lTnAdpWaglqAxhztbdqtVMKSoaa);
				int num = 1083164471;
				while (true)
				{
					switch (num ^ 0x408FC735)
					{
					case 0:
						num = 1083164470;
						continue;
					default:
						return;
					case 4:
						xQtqlAYhQUqbOGYibktAZaYeTPW.Dispose();
						num = 1083164464;
						continue;
					case 2:
						if (kBUmUcAyFhoFeddZhyvELUyrNQP != null)
						{
							kBUmUcAyFhoFeddZhyvELUyrNQP.Dispose();
							num = 1083164468;
							continue;
						}
						goto case 1;
					case 3:
						break;
					case 1:
					{
						int num2;
						if (xQtqlAYhQUqbOGYibktAZaYeTPW != null)
						{
							num = 1083164465;
							num2 = num;
						}
						else
						{
							num = 1083164464;
							num2 = num;
						}
						continue;
					}
					case 5:
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
