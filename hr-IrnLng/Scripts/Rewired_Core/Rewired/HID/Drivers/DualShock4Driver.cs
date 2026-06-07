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
		private enum oQBufakNELaVUBVvPKQSefXINbG
		{
			BOQGguqqubCWKDSUZpMHZEZjhNc = 0,
			bHGPZbBUWDPVpGBeVeXCBQUznQJt = 1,
			zzAPBlNdVXWHJNLxcVpkevnqJed = 2
		}

		private enum edaNKcQaXSXJLpbztRoWrwjcxZj
		{
			xHdBaRgdNDZThJOvnpmpFtvdLIun = 0,
			VXjtnraIizIIukDUXLQquwSuhjv = 1,
			bHGPZbBUWDPVpGBeVeXCBQUznQJt = 2
		}

		private const float dWgKllCWiILMCmLXaoFpsCYrPff = 4f;

		private const int KEPWIVLoHsLSAdrpdXFruDkpWpy = 14;

		private const int StSDqTSzHcSqfDOnfmAEHyGixwH = 2;

		private const int cAHenuUNXFruiossCkFEClOOhAH = 0;

		private const int CWWrorMjPwpoYlFMTiUHavxGJDz = 1912;

		private const int qlxfmcfGaoZrKoBRNADWhSrhXXbx = 0;

		private const int NohKZmdTdifYkiiEyDVJRLXaeYsE = 941;

		private const bool lKfcETgiWcsAecbDdKJmieXlHnxA = false;

		private const bool nCvDjlZyBfOYaboFaqNcpisiGPf = true;

		private const float TgXzfzZbnjAcJxwRLMdmrazVdea = 2.5f;

		private const int tKRsOxtxmViJQVzbWUETMwSCOrx = 0;

		private const int bsIRaDOqBgutSHhfNzTiKwaXFrj = 0;

		private const int OBuOWVRMCINqSZEqDdfkguRTVSg = 1;

		private const int xJLypvdevIwLMYBsNdiwGAHPpHpi = 0;

		private const int pxqqpkIIwwBMtoCOmhCdjrYzxrv = 0;

		private const int hRmRqWBDYVErJlbPuaQCQZdPMhc = 0;

		private const int ShUryPIOHxcuCJmISQHpHSzWPUB = 1;

		private const int obYjQNLblcPSIvjtMHWuyIUpYIY = 17;

		private const int KfrEuDGebTcitidWjnYFCVWzsfo = 0;

		private const int jYFigtKNyMheUaAHXdEnivCajOmR = 2;

		private const int FTPhjwVLJHfRHFpAlpUnBmPDxvrk = 64;

		private const int DbcvwNQoKEkQudMTlGjaIYldLHBD = 78;

		private const int otJdBIosnyyDNvWuaegIEtMjRcW = 1;

		private const int PMZlxWwdEjaflHtLfGRGXrYRIGm = 2;

		private const int SwbxqJMksYttsZvNpxtYNCsszFP = 3;

		private const int OrCdyZlDBYGLjcDmWfYYAskCgVlS = 4;

		private const int ygWYeWCjtOFJExqPSDrcPgOUXag = 8;

		private const int fDPjwjATfgDVfoPnNDBUtQGhnBEo = 9;

		private const int bobwBHaikgHAySVzaaNWItGTorvf = 5;

		private const int rMaMXcVGsZPtjdFNdovpwgnIrPc = 19;

		private const int DFNpaSoFeCgcjoFdzEMBAJsEkR = 13;

		private const int WtZXcwSGnTLtcDroRrzPQzVljnO = 35;

		private const int pAqcCOjXEXfkueHBZcirDRrFXOUZ = 5;

		private const int YlyGVJftRPmDvYOeMiHiVvLjxwmQ = 6;

		private const int gfDgroDBKLrIKiZPiRNqDHgkRhVg = 7;

		private const int WgeFgyGqwPMpnTDWlAYxZaXkLBH = 10;

		private const int CLZBQsgjQbvMrBqHgMkPllMRFhXn = 30;

		private const int vTdMgsFvaOgvbWnDsKCMrBcHagRC = 27;

		private const byte CbvrtXNTlrLzaERvyTtcuZxIifa = 200;

		private const byte cdctMyfMFMCsNahcrnLDgsuNkGsK = 53;

		private const byte HaciJaMQPDUALItyXskJVYTVrcB = byte.MaxValue;

		private const byte YZkXZQyPDKwKKZsuASVSEjfPsER = 0;

		private const bool eWPCrUTsSmeFNbfCBBNzwDcHDBwE = true;

		private const int BesExpijNmlmADuBFZwedoJfeApM = 25;

		private const int pEUQlLKnyiSEEiIROkPvVdphENf = 187500;

		private const float ekyHwEriVhxRNJIlsasVutRwBFs = 8192f;

		private const float WugayyBQAmjkubOywlraGExHBZYV = 3.4971635f;

		private const float MjAXpPICgNlhCRJUMwISHYnFnxy = 0.06103702f;

		private const bool FWHneVaLqqBimyGCzGfWBPYtvlF = true;

		private const bool lSqfloVDwlyKpZRaCVQalEWJZYw = true;

		private const bool FFdioKzQfPGEYLUUOAnzeunTExO = true;

		private const bool PAMBKwJTNzsmeIrKpXXFYTmTfpY = true;

		private const float bjHUlDiCkZzsMceItSkeZITtAfF = 4096f;

		private const float OqFZoDOeIUjbtwnBDztVJwUnnbZ = 16384f;

		private const float NWCDMZDRNKvUQBQMJEssWkSDwaS = 16777216f;

		private const float QwHBGdDUUwWYmIgiNfkWQHCtkiaU = 268435460f;

		private const float oJriwgDOVatwelxowzWiPNdGBzt = 0.01999998f;

		private const float tbhQhpXOBsAyJtdULflnvksGtGs = 8192f;

		private const float itYiJCygNsEAqXbbQISdINTPpOWA = 0.98f;

		private const float jSfdFwBToaVgLGJyeZSFhrGvOccj = 45f;

		private const float QJDyUNlipWSJltdcgnUqABebkmp = 20f;

		private readonly bool mMPhpzrlAiLsTCNuvodwKAKqjED;

		private readonly DeviceConnectionType eXkpqMDkKHWKqVDpPsOebwanHiS;

		private readonly int flmiOHBCOudXmFKDPbbPieZjwAtZ;

		private readonly int ltKevSEVezIwOsauZJVhZbJxLGfl;

		private readonly bool bHSEZINYoKxWGtkrnKYyOWRyLRC;

		private readonly byte mYYgeyIefhdpWlgtOgyKDCyuRxC;

		private readonly int ossUeMAergkBVXHROHOeEIxycyCc;

		private readonly int QTKxYTxFmQrnkRBzSNCmBilYBRc;

		private readonly int mWrgKdrDcevatBVDCUEFUdxrTMZ;

		private readonly int ukcKvHyfwrInOUdNLNByxyKZvfN;

		private readonly int nvOejAuhkiazSshFcHwFloCdtdA;

		private readonly int NTTXIVxtmsQiPrbpaadsjcqEaVkt;

		private readonly NativeBuffer AefEkpbfHElTyBMlaqmDNCteGkjO;

		private readonly NativeBuffer TPSpSLhbrlBSIvSWkEtRGjZVKkR;

		private readonly OutputReport IvPKgKkDdjiQRIeyQBKtobHpCOfP;

		private readonly Func<OutputReport, bool> caiqrwIKNFaqbsKYlJrOKtgxQKM;

		private readonly Action<OutputReport> sXCsxnNDNTRewUgWMsCsNbDKWD;

		private readonly GetHidFeatureData iXdBIAkIQlFbGFBFLPAkvYKEskF;

		private bool RZchZGqANZCUKLHDEBwBNAckBGTa;

		private bool VGURhWdQMTFOObsJhgieHNpOgBh;

		private double eFUvTsaAssdhlmVzqhdQQNTllrC;

		private byte UdfRUIBZbxHcJUlNKIKqfXwJyuR;

		private Quaternion lJQccxhVnXnfTvAIBVHWrFIZLRPG = Quaternion.identity;

		private ushort SyOzjQejNQcMUJGrBnLyAVDELwqh;

		private float dFjDVWUPlZtEDaqqeXUQBYvhpTn;

		private double zajIjBKoFZMamamCDGhKcLrHnvuc;

		private float MEHyhMotCWHdqckBGbJAAKSZSsm;

		private byte uEjVeHBcdnGlujJlXlNXfmHfeDz;

		private byte JaUtjKnwhHmTpphPFpmGzObryJx;

		private Quaternion pIRrCmOoPCdXmXBHIMUiZHdamIY = Quaternion.identity;

		private Quaternion mBbrEfTYyrEdbAhksWuJZqXclqL = Quaternion.identity;

		private bool aMulxfaoRIxUsCpWLcARqAgnqbG;

		private int zJcrbYEPTwTntlnvMZCYVgXodJQ;

		private int[] vhEwFmcQLMImQUmIGmRWnIXdwuq = new int[2];

		private int[] GdrIeUEZnMZfyZgMhOuhfrWzcZd = new int[2];

		private bool isVibrating
		{
			get
			{
				for (int i = 0; i < base.VibrationMotorCount; i++)
				{
					if (vibrationMotors[i].SpeedRaw > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		public float BatteryLevel
		{
			get
			{
				float num = 0f;
				num = ((!mMPhpzrlAiLsTCNuvodwKAKqjED) ? ((float)(UdfRUIBZbxHcJUlNKIKqfXwJyuR - 1) * 10f) : ((float)(UdfRUIBZbxHcJUlNKIKqfXwJyuR + 2) * 10f));
				return MathTools.Clamp(num, 0f, 100f);
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
				return (int)uEjVeHBcdnGlujJlXlNXfmHfeDz;
			}
			set
			{
				uEjVeHBcdnGlujJlXlNXfmHfeDz = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				RZchZGqANZCUKLHDEBwBNAckBGTa = true;
				if (uEjVeHBcdnGlujJlXlNXfmHfeDz == 0 && JaUtjKnwhHmTpphPFpmGzObryJx == 0)
				{
					VGURhWdQMTFOObsJhgieHNpOgBh = true;
				}
			}
		}

		public float LightFlashOffDuration
		{
			get
			{
				return (int)JaUtjKnwhHmTpphPFpmGzObryJx;
			}
			set
			{
				JaUtjKnwhHmTpphPFpmGzObryJx = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				RZchZGqANZCUKLHDEBwBNAckBGTa = true;
				if (uEjVeHBcdnGlujJlXlNXfmHfeDz == 0 && JaUtjKnwhHmTpphPFpmGzObryJx == 0)
				{
					VGURhWdQMTFOObsJhgieHNpOgBh = true;
				}
			}
		}

		public Vector3 AccelerometerValue => ObjaoVadkAjRNZsmweslXOdEulC(accelerometers[0].rawValue);

		public Vector3 AccelerometerValueRaw => new Vector3(accelerometers[0].rawValue[0], accelerometers[0].rawValue[1], accelerometers[0].rawValue[2]);

		public Vector3 GyroscopeValue => GnnEYwfGaGGVTgrMPbzshWJKmcCs(gyroscopes[0].events);

		public Vector3 GyroscopeValueRaw => new Vector3(gyroscopes[0].rawValue[0], gyroscopes[0].rawValue[1], gyroscopes[0].rawValue[2]);

		public Vector3 LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);
				return GnnEYwfGaGGVTgrMPbzshWJKmcCs(vector, dFjDVWUPlZtEDaqqeXUQBYvhpTn);
			}
		}

		public Vector3 LastGyroscopeValueRaw => new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);

		public Quaternion Orientation => lJQccxhVnXnfTvAIBVHWrFIZLRPG;

		public int MaxTouches => 2;

		public void ResetOrientation()
		{
			lJQccxhVnXnfTvAIBVHWrFIZLRPG = Quaternion.identity;
			aMulxfaoRIxUsCpWLcARqAgnqbG = false;
		}

		public int GetTouchCount()
		{
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				if (touchpads[0].values[i].isTouching)
				{
					num++;
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
			if (!touchpads[0].IsTouching(touchId))
			{
				return false;
			}
			HIDTouchpad.TouchData[] values = touchpads[0].values;
			for (int i = 0; i < values.Length; i++)
			{
				if (values[i].isTouching)
				{
					position.x = values[i].positionX;
					position.y = values[i].positionY;
				}
			}
			return true;
		}

		public bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (index < 0 || index >= 2)
			{
				return false;
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

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (!touchpads[0].IsTouching(touchId))
			{
				return false;
			}
			HIDTouchpad.TouchData[] values = touchpads[0].values;
			for (int i = 0; i < values.Length; i++)
			{
				if (values[i].isTouching)
				{
					positionX = values[i].positionAbsX;
					positionY = values[i].positionAbsY;
				}
			}
			return true;
		}

		public void StopLightFlash()
		{
			uEjVeHBcdnGlujJlXlNXfmHfeDz = 0;
			JaUtjKnwhHmTpphPFpmGzObryJx = 0;
			RZchZGqANZCUKLHDEBwBNAckBGTa = true;
			VGURhWdQMTFOObsJhgieHNpOgBh = true;
		}

		public void StopVibration()
		{
			int vibrationMotorCount = base.VibrationMotorCount;
			for (int i = 0; i < vibrationMotorCount; i++)
			{
				vibrationMotors[i].SpeedRaw = 0;
			}
		}

		public DualShock4Driver(InitArgs initArgs)
		{
			if (initArgs == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			flmiOHBCOudXmFKDPbbPieZjwAtZ = initArgs.hatZeroValue;
			ltKevSEVezIwOsauZJVhZbJxLGfl = initArgs.hatSpan;
			ossUeMAergkBVXHROHOeEIxycyCc = initArgs.inputReportLength;
			QTKxYTxFmQrnkRBzSNCmBilYBRc = initArgs.outputReportLength;
			caiqrwIKNFaqbsKYlJrOKtgxQKM = initArgs.synchronousWriteOutputReportDelegate;
			sXCsxnNDNTRewUgWMsCsNbDKWD = initArgs.asynchronousWriteOutputReportDelegate;
			iXdBIAkIQlFbGFBFLPAkvYKEskF = initArgs.getFeatureReportDelegate;
			eXkpqMDkKHWKqVDpPsOebwanHiS = initArgs.connectionType;
			mMPhpzrlAiLsTCNuvodwKAKqjED = eXkpqMDkKHWKqVDpPsOebwanHiS == DeviceConnectionType.SFwcoIElPuWXQcTCEiAmKWHEztR;
			if (mMPhpzrlAiLsTCNuvodwKAKqjED)
			{
				QTKxYTxFmQrnkRBzSNCmBilYBRc = 78;
			}
			if (QTKxYTxFmQrnkRBzSNCmBilYBRc < 23)
			{
				QTKxYTxFmQrnkRBzSNCmBilYBRc = 23;
			}
			AefEkpbfHElTyBMlaqmDNCteGkjO = new NativeBuffer(64);
			TPSpSLhbrlBSIvSWkEtRGjZVKkR = new NativeBuffer(QTKxYTxFmQrnkRBzSNCmBilYBRc);
			IvPKgKkDdjiQRIeyQBKtobHpCOfP = new OutputReport(TPSpSLhbrlBSIvSWkEtRGjZVKkR.Pointer, TPSpSLhbrlBSIvSWkEtRGjZVKkR.Length, QTKxYTxFmQrnkRBzSNCmBilYBRc);
			lights = new HIDLight[1]
			{
				new HIDLight(11, 24, 28)
			};
			lights[0].ValueChangedEvent += ufpgEoXGwVrNvUffWjXkzVeFgwd;
			vibrationMotors = new HIDVibrationMotor[2]
			{
				new HIDVibrationMotor(0, 255),
				new HIDVibrationMotor(0, 255)
			};
			vibrationMotors[0].ValueChangedEvent += ufpgEoXGwVrNvUffWjXkzVeFgwd;
			vibrationMotors[1].ValueChangedEvent += ufpgEoXGwVrNvUffWjXkzVeFgwd;
			if (mMPhpzrlAiLsTCNuvodwKAKqjED)
			{
				IvPKgKkDdjiQRIeyQBKtobHpCOfP.options |= OutputReportOptions.SnyKKJtaVHjKmHrRHkBKJDmDebh;
				bHSEZINYoKxWGtkrnKYyOWRyLRC = true;
				bHSEZINYoKxWGtkrnKYyOWRyLRC = kaNyqmHaSydJUQEzzPxMKRWwlat(wruyziXHZVSFMldlrVBWMmkPnqz.PMWgOuJtLQMJprSBqurejINtaRpv);
				if (!bHSEZINYoKxWGtkrnKYyOWRyLRC)
				{
					IvPKgKkDdjiQRIeyQBKtobHpCOfP.options &= ~OutputReportOptions.SnyKKJtaVHjKmHrRHkBKJDmDebh;
				}
			}
			else
			{
				bHSEZINYoKxWGtkrnKYyOWRyLRC = true;
				bHSEZINYoKxWGtkrnKYyOWRyLRC = kaNyqmHaSydJUQEzzPxMKRWwlat(wruyziXHZVSFMldlrVBWMmkPnqz.PMWgOuJtLQMJprSBqurejINtaRpv);
			}
			if (!bHSEZINYoKxWGtkrnKYyOWRyLRC)
			{
				throw new Exception("Special features not supported so just treat this as a standard HID device.");
			}
			mYYgeyIefhdpWlgtOgyKDCyuRxC = 1;
			mWrgKdrDcevatBVDCUEFUdxrTMZ = 0;
			if (mMPhpzrlAiLsTCNuvodwKAKqjED && bHSEZINYoKxWGtkrnKYyOWRyLRC)
			{
				mYYgeyIefhdpWlgtOgyKDCyuRxC = 17;
				mWrgKdrDcevatBVDCUEFUdxrTMZ = 2;
			}
			ukcKvHyfwrInOUdNLNByxyKZvfN = 5 + mWrgKdrDcevatBVDCUEFUdxrTMZ;
			nvOejAuhkiazSshFcHwFloCdtdA = 6 + mWrgKdrDcevatBVDCUEFUdxrTMZ;
			NTTXIVxtmsQiPrbpaadsjcqEaVkt = 7 + mWrgKdrDcevatBVDCUEFUdxrTMZ;
			buttons = new HIDButton[14];
			for (int i = 0; i < 14; i++)
			{
				buttons[i] = new HIDButton(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new HIDAxis[6]
			{
				new HIDAxis(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 127),
				new HIDAxis(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 127),
				new HIDAxis(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 127),
				new HIDAxis(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 127),
				new HIDAxis(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 8 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 0),
				new HIDAxis(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 9 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
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
				new HIDHat(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 5 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, qzaGrAcormgAqQMqJbwwWrRXoWQ)
			};
			accelerometers = new HIDAccelerometer[1]
			{
				new HIDAccelerometer(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 19 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 48
				}, 3, uSYDKtPBWyZoEqdOREHBfpeQIyAD)
			};
			gyroscopes = new HIDGyroscope[1]
			{
				new HIDGyroscope(initArgs.updateLoopSetting, mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 13 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 48
				}, 3, 25, niNgMuslxKaZgceMxOEEXwymfdpS, wLAjPGyPuBdMrcpLISPdnjzqkNmK)
			};
			touchpads = new HIDTouchpad[1]
			{
				new HIDTouchpad(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDTouchpad.TouchpadInfo(2, 0, 1912, 0, 941, invertY: false, reverseY: true), new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 35 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 48
				}, hTEgDKFmZOwwMCewGRBTSwbbtrb)
			};
			zajIjBKoFZMamamCDGhKcLrHnvuc = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			TMgvRQklZtspzPeGgFcHCfRKbSfF();
			EtdDVpxGUsaoldQogYbkpOQgEyjc(wruyziXHZVSFMldlrVBWMmkPnqz.hXynUPOhxYJwCUolLiXrgDrOcWu);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < AefEkpbfHElTyBMlaqmDNCteGkjO.Length)
			{
				return false;
			}
			MEHyhMotCWHdqckBGbJAAKSZSsm = (float)(timestamp - zajIjBKoFZMamamCDGhKcLrHnvuc);
			zajIjBKoFZMamamCDGhKcLrHnvuc = timestamp;
			AefEkpbfHElTyBMlaqmDNCteGkjO.Write(inputReportPtr, inputReportLength, AefEkpbfHElTyBMlaqmDNCteGkjO.Length);
			AVtNjJgBaVgRtIaBrLEPhbFamUMc(AefEkpbfHElTyBMlaqmDNCteGkjO);
			DmLZJnvnrnNkrBYTnoYZbojIVhn(AefEkpbfHElTyBMlaqmDNCteGkjO, timestamp);
			hwHaYIiTEvRaleSlaFhMhqeHzxK(axes, AefEkpbfHElTyBMlaqmDNCteGkjO, timestamp);
			hwHaYIiTEvRaleSlaFhMhqeHzxK(hats, AefEkpbfHElTyBMlaqmDNCteGkjO, timestamp);
			hwHaYIiTEvRaleSlaFhMhqeHzxK(accelerometers, AefEkpbfHElTyBMlaqmDNCteGkjO, timestamp);
			hwHaYIiTEvRaleSlaFhMhqeHzxK(gyroscopes, AefEkpbfHElTyBMlaqmDNCteGkjO, timestamp);
			hwHaYIiTEvRaleSlaFhMhqeHzxK(touchpads, AefEkpbfHElTyBMlaqmDNCteGkjO, timestamp);
			UdfRUIBZbxHcJUlNKIKqfXwJyuR = (byte)(AefEkpbfHElTyBMlaqmDNCteGkjO[30 + mWrgKdrDcevatBVDCUEFUdxrTMZ] & 0xF);
			GBwAUEfKFiUziSkhMWXIqaJJQjla();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualShock4Extension(this);
		}

		private void EtdDVpxGUsaoldQogYbkpOQgEyjc(wruyziXHZVSFMldlrVBWMmkPnqz P_0)
		{
			if (RZchZGqANZCUKLHDEBwBNAckBGTa)
			{
				kaNyqmHaSydJUQEzzPxMKRWwlat(P_0);
				RZchZGqANZCUKLHDEBwBNAckBGTa = false;
			}
		}

		private bool kaNyqmHaSydJUQEzzPxMKRWwlat(wruyziXHZVSFMldlrVBWMmkPnqz P_0)
		{
			FyXDTkkoQgBIkIOMPrsPJPpQWUph();
			bool result = aVzxnnjmGlRYclaUUzLjDmhmPEn(P_0);
			if (VGURhWdQMTFOObsJhgieHNpOgBh)
			{
				result = aVzxnnjmGlRYclaUUzLjDmhmPEn(P_0);
				VGURhWdQMTFOObsJhgieHNpOgBh = false;
			}
			return result;
		}

		private void FyXDTkkoQgBIkIOMPrsPJPpQWUph()
		{
			if (mMPhpzrlAiLsTCNuvodwKAKqjED && bHSEZINYoKxWGtkrnKYyOWRyLRC)
			{
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[0] = 17;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[1] = 128;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[3] = byte.MaxValue;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[6] = (byte)vibrationMotors[1].SpeedRaw;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[7] = (byte)vibrationMotors[0].SpeedRaw;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[8] = lights[0].ColorRRaw;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[9] = lights[0].ColorGRaw;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[10] = lights[0].ColorBRaw;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[11] = uEjVeHBcdnGlujJlXlNXfmHfeDz;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[12] = JaUtjKnwhHmTpphPFpmGzObryJx;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[21] = 53;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[22] = 53;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[23] = byte.MaxValue;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[24] = 0;
			}
			else
			{
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[0] = 5;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[1] = byte.MaxValue;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[4] = (byte)vibrationMotors[1].SpeedRaw;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[5] = (byte)vibrationMotors[0].SpeedRaw;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[6] = lights[0].ColorRRaw;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[7] = lights[0].ColorGRaw;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[8] = lights[0].ColorBRaw;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[9] = uEjVeHBcdnGlujJlXlNXfmHfeDz;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[10] = JaUtjKnwhHmTpphPFpmGzObryJx;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[19] = 53;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[20] = 53;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[21] = byte.MaxValue;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[22] = 0;
			}
		}

		private bool aVzxnnjmGlRYclaUUzLjDmhmPEn(wruyziXHZVSFMldlrVBWMmkPnqz P_0)
		{
			eFUvTsaAssdhlmVzqhdQQNTllrC = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case wruyziXHZVSFMldlrVBWMmkPnqz.PMWgOuJtLQMJprSBqurejINtaRpv:
				if (caiqrwIKNFaqbsKYlJrOKtgxQKM == null)
				{
					return false;
				}
				return caiqrwIKNFaqbsKYlJrOKtgxQKM(IvPKgKkDdjiQRIeyQBKtobHpCOfP);
			case wruyziXHZVSFMldlrVBWMmkPnqz.hXynUPOhxYJwCUolLiXrgDrOcWu:
				if (sXCsxnNDNTRewUgWMsCsNbDKWD == null)
				{
					return false;
				}
				sXCsxnNDNTRewUgWMsCsNbDKWD(IvPKgKkDdjiQRIeyQBKtobHpCOfP);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void DmLZJnvnrnNkrBYTnoYZbojIVhn(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[ukcKvHyfwrInOUdNLNByxyKZvfN];
			buttons[0].SetValue((b & 0x10) != 0, P_1);
			buttons[1].SetValue((b & 0x20) != 0, P_1);
			buttons[2].SetValue((b & 0x40) != 0, P_1);
			buttons[3].SetValue((b & 0x80) != 0, P_1);
			b = P_0[nvOejAuhkiazSshFcHwFloCdtdA];
			buttons[4].SetValue((b & 1) != 0, P_1);
			buttons[5].SetValue((b & 2) != 0, P_1);
			buttons[6].SetValue((b & 4) != 0, P_1);
			buttons[7].SetValue((b & 8) != 0, P_1);
			buttons[8].SetValue((b & 0x10) != 0, P_1);
			buttons[9].SetValue((b & 0x20) != 0, P_1);
			buttons[10].SetValue((b & 0x40) != 0, P_1);
			buttons[11].SetValue((b & 0x80) != 0, P_1);
			b = P_0[NTTXIVxtmsQiPrbpaadsjcqEaVkt];
			buttons[12].SetValue((b & 1) != 0, P_1);
			buttons[13].SetValue((b & 2) != 0, P_1);
		}

		private void hwHaYIiTEvRaleSlaFhMhqeHzxK(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].UpdateValue(P_1, P_2);
			}
		}

		private void TMgvRQklZtspzPeGgFcHCfRKbSfF()
		{
			if (isVibrating && ReInput.realTime >= eFUvTsaAssdhlmVzqhdQQNTllrC)
			{
				RZchZGqANZCUKLHDEBwBNAckBGTa = true;
			}
		}

		private void AVtNjJgBaVgRtIaBrLEPhbFamUMc(NativeBuffer P_0)
		{
			if (bHSEZINYoKxWGtkrnKYyOWRyLRC)
			{
				ushort num = AefEkpbfHElTyBMlaqmDNCteGkjO.ReadUShort(10 + mWrgKdrDcevatBVDCUEFUdxrTMZ);
				float num3;
				if (num != SyOzjQejNQcMUJGrBnLyAVDELwqh)
				{
					int num2 = ((num >= SyOzjQejNQcMUJGrBnLyAVDELwqh) ? (num - SyOzjQejNQcMUJGrBnLyAVDELwqh) : (num + 65535 - SyOzjQejNQcMUJGrBnLyAVDELwqh));
					num3 = (float)num2 / 187500f;
				}
				else
				{
					int num2 = 0;
					num3 = 0f;
				}
				SyOzjQejNQcMUJGrBnLyAVDELwqh = num;
				dFjDVWUPlZtEDaqqeXUQBYvhpTn = num3;
			}
		}

		private void GBwAUEfKFiUziSkhMWXIqaJJQjla()
		{
			if (bHSEZINYoKxWGtkrnKYyOWRyLRC)
			{
				_ = dFjDVWUPlZtEDaqqeXUQBYvhpTn;
				_ = 0f;
				Vector3 vector = GnnEYwfGaGGVTgrMPbzshWJKmcCs(new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]), dFjDVWUPlZtEDaqqeXUQBYvhpTn);
				xohcDsacOFZCkALnqUHMJfyYnqIA(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].rawValue[0] * -1f, accelerometers[0].rawValue[1] * -1f, accelerometers[0].rawValue[2] * -1f);
				XvOcAbIDkGASqOjGxNMFhkNGTEia(vector2, vector);
			}
		}

		private static bool xohcDsacOFZCkALnqUHMJfyYnqIA(ref Vector3 P_0)
		{
			if (P_0.magnitude < 0.004f)
			{
				P_0.x = 0f;
				P_0.y = 0f;
				P_0.z = 0f;
				return false;
			}
			return true;
		}

		private void XvOcAbIDkGASqOjGxNMFhkNGTEia(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && gFxxeBFCYAuggBcTRMOFEuGTnQT(P_0, out var edaNKcQaXSXJLpbztRoWrwjcxZj2))
			{
				Quaternion a = lJQccxhVnXnfTvAIBVHWrFIZLRPG * quaternion;
				if (!aMulxfaoRIxUsCpWLcARqAgnqbG)
				{
					aMulxfaoRIxUsCpWLcARqAgnqbG = true;
					pIRrCmOoPCdXmXBHIMUiZHdamIY = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					mBbrEfTYyrEdbAhksWuJZqXclqL = lJQccxhVnXnfTvAIBVHWrFIZLRPG;
				}
				pIRrCmOoPCdXmXBHIMUiZHdamIY *= quaternion;
				mBbrEfTYyrEdbAhksWuJZqXclqL *= quaternion;
				Quaternion b;
				if ((edaNKcQaXSXJLpbztRoWrwjcxZj2 & edaNKcQaXSXJLpbztRoWrwjcxZj.VXjtnraIizIIukDUXLQquwSuhjv) != edaNKcQaXSXJLpbztRoWrwjcxZj.xHdBaRgdNDZThJOvnpmpFtvdLIun)
				{
					b = DrLyVdRffFDYNoKtmaNMOTRipHj(P_0, a.eulerAngles.y);
				}
				else if ((edaNKcQaXSXJLpbztRoWrwjcxZj2 & edaNKcQaXSXJLpbztRoWrwjcxZj.bHGPZbBUWDPVpGBeVeXCBQUznQJt) != edaNKcQaXSXJLpbztRoWrwjcxZj.xHdBaRgdNDZThJOvnpmpFtvdLIun)
				{
					b = KbqZTtHDtyBqxDDbotDQAMfoWbu(P_0);
					Vector3 vector = mBbrEfTYyrEdbAhksWuJZqXclqL * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				lJQccxhVnXnfTvAIBVHWrFIZLRPG = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				lJQccxhVnXnfTvAIBVHWrFIZLRPG *= quaternion;
				if (aMulxfaoRIxUsCpWLcARqAgnqbG)
				{
					aMulxfaoRIxUsCpWLcARqAgnqbG = false;
				}
			}
		}

		private static Quaternion wqhnMAppxDVTMYMQNDLJmHtlboRG(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = new Vector3(P_0.x, P_0.y, P_0.z);
			Vector3 vector2 = AmpcUezhbYwYSNIVTJgmZPLSFWF(vector, P_1);
			return new Quaternion(vector2.x, vector2.y, vector2.z, P_0.w);
		}

		private static Vector3 AmpcUezhbYwYSNIVTJgmZPLSFWF(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion ePVCTOrkCFhxNKhjkaUvcnKgWVC(Quaternion P_0, oQBufakNELaVUBVvPKQSefXINbG P_1)
		{
			Vector4 vector = default(Vector4);
			if (MathTools.Approximately(P_0.w, 0f) && MathTools.Approximately(P_0[(int)P_1], 0f))
			{
				P_0 = Quaternion.identity;
			}
			else
			{
				float num = P_0[(int)P_1];
				float num2 = MathTools.Sqrt(P_0.w * P_0.w + num * num);
				vector[3] = P_0.w / num2;
				vector[(int)P_1] = num / num2;
				P_0 = new Quaternion(vector[0], vector[1], vector[2], vector[3]);
			}
			return P_0;
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

		private float GBISkccpIKbMRFQAZDfdGGzEVUvT(float P_0, float P_1)
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
			}
			if (P_1 >= 180f)
			{
				P_1 -= 360f;
			}
			return P_0 - P_1;
		}

		private Vector3 YcmnCIkrZniyQeztlUGftkAGIGR(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
			float num2 = MathTools.Atan2(P_0.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x2, P_1, z);
		}

		private Quaternion DrLyVdRffFDYNoKtmaNMOTRipHj(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
			float num2 = MathTools.Atan2(P_0.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x2, P_1, z);
		}

		private Quaternion KbqZTtHDtyBqxDDbotDQAMfoWbu(Vector3 P_0, float P_1 = 0f)
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

		private float caseOfmmOLduOZWNfaejIlROmawI(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool lJTBJyObViQaqDEmyEbpepfWVaj(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool gFxxeBFCYAuggBcTRMOFEuGTnQT(Vector3 P_0, out edaNKcQaXSXJLpbztRoWrwjcxZj P_1)
		{
			P_0.Normalize();
			P_1 = edaNKcQaXSXJLpbztRoWrwjcxZj.xHdBaRgdNDZThJOvnpmpFtvdLIun;
			bool result = false;
			if (CTyxvgxhreIBtOAKyUKaIzAQtNX(P_0))
			{
				result = true;
				P_1 |= edaNKcQaXSXJLpbztRoWrwjcxZj.VXjtnraIizIIukDUXLQquwSuhjv;
			}
			if (vbKEWrNjJDhDyCwWzNZYTKwlBRTc(P_0))
			{
				result = true;
				P_1 |= edaNKcQaXSXJLpbztRoWrwjcxZj.bHGPZbBUWDPVpGBeVeXCBQUznQJt;
			}
			return result;
		}

		private bool CTyxvgxhreIBtOAKyUKaIzAQtNX(Vector3 P_0)
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

		private bool vbKEWrNjJDhDyCwWzNZYTKwlBRTc(Vector3 P_0)
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

		private Vector3 ObjaoVadkAjRNZsmweslXOdEulC(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 GnnEYwfGaGGVTgrMPbzshWJKmcCs(ExpandableArray_DataContainer<HIDGyroscope.ubnVRumZvQibiLoaPGlFgdqPNxLF> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				HIDGyroscope.ubnVRumZvQibiLoaPGlFgdqPNxLF ubnVRumZvQibiLoaPGlFgdqPNxLF = P_0[i];
				result += GnnEYwfGaGGVTgrMPbzshWJKmcCs(ubnVRumZvQibiLoaPGlFgdqPNxLF.EcKfTFWnqsKEYsThPRHDCjhWUGd, ubnVRumZvQibiLoaPGlFgdqPNxLF.fcZZPDOEDPeOhDbjpaAZcXRmWqQH);
			}
			return result;
		}

		private Vector3 GnnEYwfGaGGVTgrMPbzshWJKmcCs(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private Vector3 LPDpNkMQUIeekLpOiBguJkanXcQb(Vector3 P_0)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 3.4971635f;
		}

		private int qzaGrAcormgAqQMqJbwwWrRXoWQ(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void uSYDKtPBWyZoEqdOREHBfpeQIyAD(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void niNgMuslxKaZgceMxOEEXwymfdpS(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float wLAjPGyPuBdMrcpLISPdnjzqkNmK()
		{
			return dFjDVWUPlZtEDaqqeXUQBYvhpTn;
		}

		private void hTEgDKFmZOwwMCewGRBTSwbbtrb(NativeBuffer P_0, HIDTouchpad.TouchData[] P_1)
		{
			int num = 35 + mWrgKdrDcevatBVDCUEFUdxrTMZ;
			int positionRawX = P_0[1 + num] + (P_0[2 + num] & 0xF) * 255;
			int positionRawY = ((P_0[2 + num] & 0xF0) >> 4) + P_0[3 + num] * 16;
			int positionRawX2 = P_0[5 + num] + (P_0[6 + num] & 0xF) * 255;
			int positionRawY2 = ((P_0[6 + num] & 0xF0) >> 4) + P_0[7 + num] * 16;
			byte b = P_0[num];
			bool flag = b < 128;
			byte b2 = P_0[num + 4];
			bool flag2 = b2 < 128;
			int num2 = b & 0x7F;
			int num3 = b2 & 0x7F;
			P_1[0].isTouching = flag;
			P_1[0].touchId = dqlXcoyorJDlwaSIfdUgVjIoadBD(0, flag, num2);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = dqlXcoyorJDlwaSIfdUgVjIoadBD(1, flag2, num3);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int dqlXcoyorJDlwaSIfdUgVjIoadBD(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				vhEwFmcQLMImQUmIGmRWnIXdwuq[P_0] = -1;
				GdrIeUEZnMZfyZgMhOuhfrWzcZd[P_0] = P_2;
				return -1;
			}
			if (P_2 != GdrIeUEZnMZfyZgMhOuhfrWzcZd[P_0])
			{
				int num = zJcrbYEPTwTntlnvMZCYVgXodJQ;
				if (zJcrbYEPTwTntlnvMZCYVgXodJQ == int.MaxValue)
				{
					zJcrbYEPTwTntlnvMZCYVgXodJQ = 0;
				}
				else
				{
					zJcrbYEPTwTntlnvMZCYVgXodJQ++;
				}
				GdrIeUEZnMZfyZgMhOuhfrWzcZd[P_0] = P_2;
				vhEwFmcQLMImQUmIGmRWnIXdwuq[P_0] = num;
				return num;
			}
			return vhEwFmcQLMImQUmIGmRWnIXdwuq[P_0];
		}

		private void ufpgEoXGwVrNvUffWjXkzVeFgwd()
		{
			RZchZGqANZCUKLHDEBwBNAckBGTa = true;
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
			base.Dispose(disposing);
			if (disposing)
			{
				StopVibration();
				EtdDVpxGUsaoldQogYbkpOQgEyjc(wruyziXHZVSFMldlrVBWMmkPnqz.PMWgOuJtLQMJprSBqurejINtaRpv);
				if (AefEkpbfHElTyBMlaqmDNCteGkjO != null)
				{
					AefEkpbfHElTyBMlaqmDNCteGkjO.Dispose();
				}
				if (TPSpSLhbrlBSIvSWkEtRGjZVKkR != null)
				{
					TPSpSLhbrlBSIvSWkEtRGjZVKkR.Dispose();
				}
			}
		}

		public static bool Matches(int vid, int pid)
		{
			for (int i = 0; i < Consts.pidVids_sony_dualShock4.Count; i++)
			{
				if (Consts.pidVids_sony_dualShock4[i].vendorId == vid && Consts.pidVids_sony_dualShock4[i].productId == pid)
				{
					return true;
				}
			}
			return false;
		}
	}
}
