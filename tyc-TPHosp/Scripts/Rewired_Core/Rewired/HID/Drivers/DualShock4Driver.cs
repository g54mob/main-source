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
		private enum WJhFMIZFrWmNWEpLKaMRBookODcp
		{
			xepxGaXVFkjSqUmmGpSRDuaJPAv = 0,
			BEudoXEezEvydtTCYEVTGAtHLCnM = 1,
			LLagxBetEMrlLQaxrdBfkQQQwTZ = 2
		}

		private enum OJIsQqtrPJwnHgFSiTilbiDStKl
		{
			DVDMTdEnkAaktJFJqNakDhECjSAS = 0,
			rHBeEZRbXmTrohwcYCIrqoxKDtXB = 1,
			BEudoXEezEvydtTCYEVTGAtHLCnM = 2
		}

		private const float BaWdJwdHXTaWllhbxcupmldTRkB = 4f;

		private const int iipHpfgLozalWqeLcbTeIaNNpzGR = 14;

		private const int kgatZjrqkhRZlSmJwpMFPplYfgh = 2;

		private const int KJhEoKbbyCNIozmORHGJMTteAJf = 0;

		private const int wMiKrXxyWpIRCmenGgXUqqWwPVL = 1912;

		private const int UvZNBEpGFxFASfQtSPNRPGSfQVDv = 0;

		private const int reBbwQBOUdUdkltuhUDMBRmMtOGa = 941;

		private const bool TNRmpfZnbhjtswVveBBfwtoPAbLi = false;

		private const bool NPNgMViiJqpWemfyfoUdhZROGwZ = true;

		private const float ldraAXksYcBtPwGhATUfzpWbypS = 2.5f;

		private const int HOdEdJSTJUeaQUUBHuIQSPbqnTZ = 0;

		private const int VyiGVnpSoxcIAkCTKnFpKEFzlzLF = 0;

		private const int oUOznPwpdDiEqYSIUzzvosJfSUf = 1;

		private const int BuhgGZYhULXcOPUGUWcfStyleZP = 0;

		private const int DlIBCEjbDbaWdfEkhWvkflvLhJP = 0;

		private const int PAEguigfJMrgPujadWyPQEUnxjM = 0;

		private const int aUeeXzbnqsxJIRQcVTDwMZKoDArt = 1;

		private const int YHeWTqgwYrqrYyFVBJRJwgpuObe = 17;

		private const int ciJnXxhWWMPLlryDcWoOAblJdYQ = 0;

		private const int TfxYLVbDHFvNCpXlIvGotljEcIQ = 2;

		private const int xkbZMOoTgOrkLoiygKCiengrXnP = 64;

		private const int toGhBnxqvVsjcskxodnldMYLLVni = 78;

		private const int GgtPoaNdEnluVcRKzJsDQvdHwqi = 1;

		private const int drgYoLCdgdDrGGfctSNoRddSCAV = 2;

		private const int mCNKsInlVPWWtKtFwzTeLapOhod = 3;

		private const int ouuRPrGcsDmltKsIRYrPeoTATvD = 4;

		private const int WZeiNejeABtaSiorRJjjTkbaOqW = 8;

		private const int VMlrZNgAGjrgpMoJOTJXCqtZITe = 9;

		private const int HXPFozDlRpTloHmXbXmFfjzvDjX = 5;

		private const int LzQnkCazxYgntgffagZkcCZkzzU = 19;

		private const int ztzcfKlWibhlcaTfahLHTdkMkuh = 13;

		private const int mWrIVUbQIYaKcQmEOvbSEpwFOxe = 35;

		private const int HNCOnkQelKsVwQorEUywPNIteMs = 5;

		private const int mvUOsxQSoSrazHlKJCPdxCwTIqA = 6;

		private const int KzrPWQabnUIbGgKfftXbABPIevbL = 7;

		private const int gAraCqjRCSbroEycjCoiLkSnZfb = 10;

		private const int yplmxIOpxalhtrcphmyIhTxzNvt = 30;

		private const int LhDBJUamPPqAhCNrlaEVybBdhqjg = 27;

		private const byte suJObQwMmaegsRBdjLBbqonkyDQ = 200;

		private const byte UPYEhGgOyLnXTXcQkwZOioHtASSd = 53;

		private const byte bWYVnGtSjSrBNVaFEkgGXnjlobn = byte.MaxValue;

		private const byte uTQjqkJyaPvdWGcWXDRFaIWtvMtI = 0;

		private const bool CantHuujCbNTVseHIFDygDTdTiM = true;

		private const int pXYoQHUmcflHYhuzAgvxyVeLMyX = 25;

		private const int FigbxKdJBnvIhztHWguyFSZcXBZ = 187500;

		private const float WWGmleAZFeOXZQBkpmWOoKEYJpK = 8192f;

		private const float keELRUkWdfjFkTfQzvdbWjYxPXw = 3.4971635f;

		private const float mwewEHflfYCtWKSpDeKJXYbddiM = 0.06103702f;

		private const bool lkfKnVPPRjcgmxmGslHDVjjHtov = true;

		private const bool DFQuKIukTiWtrIkANUIhjijtpMW = true;

		private const bool rPZPHaSQKYqzCUFiNAzymlAlSnc = true;

		private const bool tUozzEkwueNUiBqksVEYANLpjDe = true;

		private const float PYpBzdFsNCLIGjxosRUjNWaZpph = 4096f;

		private const float eJxcrxpzYNKurnnBCfmSLxNNftz = 16384f;

		private const float rMouXpeXcBUKSEOsGYIlGxBnqhg = 16777216f;

		private const float wFzmpBvRdhClivuGKhyXNpjHdcE = 268435460f;

		private const float YwRVAUkaQfKecgAUhnwlTPUyTvZ = 0.01999998f;

		private const float DyLCIZbymtIDTLmcKFzknrNsaQKA = 8192f;

		private const float WCcTVyVwbrraeIHhHCLyFidbUBs = 0.98f;

		private const float ZBZnkCkVBpcBNSaWjvESlpxDruS = 45f;

		private const float yWbFygSKNHznBgoHhrrFYyTDsHU = 20f;

		private readonly bool WjjAjXYgQtgiBDqpizqbKFzAkpt;

		private readonly DeviceConnectionType GuQIlEsVBMbQAOfbGIsHvWNZVwc;

		private readonly int XHAwhrylzzcoiDXhAtpYOumWuAPl;

		private readonly int LgiRSmavHonJUvuMWWNcrIaLMYP;

		private readonly bool LyyuqokPPLtpMesPieOnMecKBZqG;

		private readonly byte MVyaTUzHCqVKMixNLHoBXWLGpDe;

		private readonly int WbEjQotUNdqPSYvbHSxvOEeEsAc;

		private readonly int iAqBMzQgwBDIckEtRXFbLWJgbRQa;

		private readonly int EDXXhVYiDlJJtAaxPfSWjACVEWlt;

		private readonly int CXYnBPTTKgnVdDoXATXCjgZxjbL;

		private readonly int HBaCRwPgZrPREvxdpJHKjPtRile;

		private readonly int jXtInnMmDdGZPeiTjFpzAgHwRJUa;

		private readonly NativeBuffer wHROFVCPoBcgoRFVjtkCSkMeFuk;

		private readonly NativeBuffer rduQNjAjUwpDOenklfOCQHuddaf;

		private readonly OutputReport mrlYPePkWgGjXkbGVrGeWhyFtAPK;

		private readonly Func<OutputReport, bool> MGQfESFdwSETxDxqyVdJeMTdFOuC;

		private readonly Action<OutputReport> vqMzbKWSwIyLZlIopEOnsCgzEOm;

		private readonly GetHidFeatureData ERJpNsBEpiEpQSXlAOClShdkGwf;

		private bool jGOxswRfiQnpAKjvVmcALmNEnSp;

		private bool vkWkmhGnkCiGPufGqunxVGAuoPl;

		private double UIuQxCDBRfKZhvZspfAJKaLRfLk;

		private byte qhLwBqieAweIPNIxFWPhvUBlotx;

		private Quaternion ZdcORBqhUWdOBKRuAkZHmRzfODdc = Quaternion.identity;

		private ushort qRokMcLfaRgfIJXPKcDzHHcgtgEO;

		private float VwPtuanyGWRxHnWClOEVPmMNZxZ;

		private double RxZVOrhLqMXxerZsIpzDPSAzlLW;

		private float cybGKwJztDEKwjrhLCRFYDvpdgQD;

		private byte ASVkohcIKgYiekHPMRcChSgVZHX;

		private byte dMsEKmJIIILirFohWiiFNjWNlPPU;

		private Quaternion ZvzenEdfmTzcgEOrDYCpITUCXOgQ = Quaternion.identity;

		private Quaternion UUXMNmwDjatdzFWCpQSvVmPQfnR = Quaternion.identity;

		private bool ATCAQFGXcLCxwXHeGLKKEuFHTpsA;

		private int HOoUwCjwxAabnqBBdPJEReDAHuP;

		private int[] VkiimGZWwRHVKBOuVpJFzCsHpiQ = new int[2];

		private int[] qPHpsgxNmLqlyKloyCHkrbzTEuP = new int[2];

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
				num = ((!WjjAjXYgQtgiBDqpizqbKFzAkpt) ? ((float)(qhLwBqieAweIPNIxFWPhvUBlotx - 1) * 10f) : ((float)(qhLwBqieAweIPNIxFWPhvUBlotx + 2) * 10f));
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
				return (int)ASVkohcIKgYiekHPMRcChSgVZHX;
			}
			set
			{
				ASVkohcIKgYiekHPMRcChSgVZHX = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				jGOxswRfiQnpAKjvVmcALmNEnSp = true;
				if (ASVkohcIKgYiekHPMRcChSgVZHX == 0 && dMsEKmJIIILirFohWiiFNjWNlPPU == 0)
				{
					vkWkmhGnkCiGPufGqunxVGAuoPl = true;
				}
			}
		}

		public float LightFlashOffDuration
		{
			get
			{
				return (int)dMsEKmJIIILirFohWiiFNjWNlPPU;
			}
			set
			{
				dMsEKmJIIILirFohWiiFNjWNlPPU = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				jGOxswRfiQnpAKjvVmcALmNEnSp = true;
				if (ASVkohcIKgYiekHPMRcChSgVZHX == 0 && dMsEKmJIIILirFohWiiFNjWNlPPU == 0)
				{
					vkWkmhGnkCiGPufGqunxVGAuoPl = true;
				}
			}
		}

		public Vector3 AccelerometerValue => klPHkhJVvVcePIUQnuIeBCHkrqa(accelerometers[0].rawValue);

		public Vector3 AccelerometerValueRaw => new Vector3(accelerometers[0].rawValue[0], accelerometers[0].rawValue[1], accelerometers[0].rawValue[2]);

		public Vector3 GyroscopeValue => uAPtrWUbPXQoHhTqKhRjUbccauy(gyroscopes[0].events);

		public Vector3 GyroscopeValueRaw => new Vector3(gyroscopes[0].rawValue[0], gyroscopes[0].rawValue[1], gyroscopes[0].rawValue[2]);

		public Vector3 LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);
				return uAPtrWUbPXQoHhTqKhRjUbccauy(vector, VwPtuanyGWRxHnWClOEVPmMNZxZ);
			}
		}

		public Vector3 LastGyroscopeValueRaw => new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);

		public Quaternion Orientation => ZdcORBqhUWdOBKRuAkZHmRzfODdc;

		public int MaxTouches => 2;

		public void ResetOrientation()
		{
			ZdcORBqhUWdOBKRuAkZHmRzfODdc = Quaternion.identity;
			ATCAQFGXcLCxwXHeGLKKEuFHTpsA = false;
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
			ASVkohcIKgYiekHPMRcChSgVZHX = 0;
			dMsEKmJIIILirFohWiiFNjWNlPPU = 0;
			jGOxswRfiQnpAKjvVmcALmNEnSp = true;
			vkWkmhGnkCiGPufGqunxVGAuoPl = true;
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
			XHAwhrylzzcoiDXhAtpYOumWuAPl = initArgs.hatZeroValue;
			LgiRSmavHonJUvuMWWNcrIaLMYP = initArgs.hatSpan;
			WbEjQotUNdqPSYvbHSxvOEeEsAc = initArgs.inputReportLength;
			iAqBMzQgwBDIckEtRXFbLWJgbRQa = initArgs.outputReportLength;
			MGQfESFdwSETxDxqyVdJeMTdFOuC = initArgs.synchronousWriteOutputReportDelegate;
			vqMzbKWSwIyLZlIopEOnsCgzEOm = initArgs.asynchronousWriteOutputReportDelegate;
			ERJpNsBEpiEpQSXlAOClShdkGwf = initArgs.getFeatureReportDelegate;
			GuQIlEsVBMbQAOfbGIsHvWNZVwc = initArgs.connectionType;
			WjjAjXYgQtgiBDqpizqbKFzAkpt = GuQIlEsVBMbQAOfbGIsHvWNZVwc == DeviceConnectionType.gGXVuYpwdzdIqhuTWerNGskghzz;
			if (WjjAjXYgQtgiBDqpizqbKFzAkpt)
			{
				iAqBMzQgwBDIckEtRXFbLWJgbRQa = 78;
			}
			if (iAqBMzQgwBDIckEtRXFbLWJgbRQa < 23)
			{
				iAqBMzQgwBDIckEtRXFbLWJgbRQa = 23;
			}
			wHROFVCPoBcgoRFVjtkCSkMeFuk = new NativeBuffer(64);
			rduQNjAjUwpDOenklfOCQHuddaf = new NativeBuffer(iAqBMzQgwBDIckEtRXFbLWJgbRQa);
			mrlYPePkWgGjXkbGVrGeWhyFtAPK = new OutputReport(rduQNjAjUwpDOenklfOCQHuddaf.Pointer, rduQNjAjUwpDOenklfOCQHuddaf.Length, iAqBMzQgwBDIckEtRXFbLWJgbRQa);
			lights = new HIDLight[1]
			{
				new HIDLight(11, 24, 28)
			};
			lights[0].ValueChangedEvent += GBJaTSoaBWMGpLzBLvpdfHPvxwD;
			vibrationMotors = new HIDVibrationMotor[2]
			{
				new HIDVibrationMotor(0, 255),
				new HIDVibrationMotor(0, 255)
			};
			vibrationMotors[0].ValueChangedEvent += GBJaTSoaBWMGpLzBLvpdfHPvxwD;
			vibrationMotors[1].ValueChangedEvent += GBJaTSoaBWMGpLzBLvpdfHPvxwD;
			if (WjjAjXYgQtgiBDqpizqbKFzAkpt)
			{
				mrlYPePkWgGjXkbGVrGeWhyFtAPK.options |= OutputReportOptions.otABrxKOcWiIoGNjCGkFDaFrUnT;
				LyyuqokPPLtpMesPieOnMecKBZqG = true;
				LyyuqokPPLtpMesPieOnMecKBZqG = MWdbRGcNfhnGUHNBugXDSMzIjfT(CvGIYAiMgYJmSqaJkRZPGAFfBeJb.xZuRfCCvmDouxJKprRhnKByJKHD);
				if (!LyyuqokPPLtpMesPieOnMecKBZqG)
				{
					mrlYPePkWgGjXkbGVrGeWhyFtAPK.options &= ~OutputReportOptions.otABrxKOcWiIoGNjCGkFDaFrUnT;
				}
			}
			else
			{
				LyyuqokPPLtpMesPieOnMecKBZqG = true;
				LyyuqokPPLtpMesPieOnMecKBZqG = MWdbRGcNfhnGUHNBugXDSMzIjfT(CvGIYAiMgYJmSqaJkRZPGAFfBeJb.xZuRfCCvmDouxJKprRhnKByJKHD);
			}
			if (!LyyuqokPPLtpMesPieOnMecKBZqG)
			{
				throw new Exception("Special features not supported so just treat this as a standard HID device.");
			}
			MVyaTUzHCqVKMixNLHoBXWLGpDe = 1;
			EDXXhVYiDlJJtAaxPfSWjACVEWlt = 0;
			if (WjjAjXYgQtgiBDqpizqbKFzAkpt && LyyuqokPPLtpMesPieOnMecKBZqG)
			{
				MVyaTUzHCqVKMixNLHoBXWLGpDe = 17;
				EDXXhVYiDlJJtAaxPfSWjACVEWlt = 2;
			}
			CXYnBPTTKgnVdDoXATXCjgZxjbL = 5 + EDXXhVYiDlJJtAaxPfSWjACVEWlt;
			HBaCRwPgZrPREvxdpJHKjPtRile = 6 + EDXXhVYiDlJJtAaxPfSWjACVEWlt;
			jXtInnMmDdGZPeiTjFpzAgHwRJUa = 7 + EDXXhVYiDlJJtAaxPfSWjACVEWlt;
			buttons = new HIDButton[14];
			for (int i = 0; i < 14; i++)
			{
				buttons[i] = new HIDButton(MVyaTUzHCqVKMixNLHoBXWLGpDe, new HIDControllerElement.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new HIDAxis[6]
			{
				new HIDAxis(MVyaTUzHCqVKMixNLHoBXWLGpDe, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + EDXXhVYiDlJJtAaxPfSWjACVEWlt,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 127),
				new HIDAxis(MVyaTUzHCqVKMixNLHoBXWLGpDe, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + EDXXhVYiDlJJtAaxPfSWjACVEWlt,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 127),
				new HIDAxis(MVyaTUzHCqVKMixNLHoBXWLGpDe, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + EDXXhVYiDlJJtAaxPfSWjACVEWlt,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 127),
				new HIDAxis(MVyaTUzHCqVKMixNLHoBXWLGpDe, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + EDXXhVYiDlJJtAaxPfSWjACVEWlt,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 127),
				new HIDAxis(MVyaTUzHCqVKMixNLHoBXWLGpDe, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 8 + EDXXhVYiDlJJtAaxPfSWjACVEWlt,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 0),
				new HIDAxis(MVyaTUzHCqVKMixNLHoBXWLGpDe, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 9 + EDXXhVYiDlJJtAaxPfSWjACVEWlt,
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
				new HIDHat(MVyaTUzHCqVKMixNLHoBXWLGpDe, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 5 + EDXXhVYiDlJJtAaxPfSWjACVEWlt,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, QsYfgGFCirJisXEDSxcfUEyxkok)
			};
			accelerometers = new HIDAccelerometer[1]
			{
				new HIDAccelerometer(MVyaTUzHCqVKMixNLHoBXWLGpDe, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 19 + EDXXhVYiDlJJtAaxPfSWjACVEWlt,
					bitSize = 48
				}, 3, WfySlXgffbBFWglaGDLMfbFjiemi)
			};
			gyroscopes = new HIDGyroscope[1]
			{
				new HIDGyroscope(initArgs.updateLoopSetting, MVyaTUzHCqVKMixNLHoBXWLGpDe, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 13 + EDXXhVYiDlJJtAaxPfSWjACVEWlt,
					bitSize = 48
				}, 3, 25, HEtVjIDVGROiavpcmUCHcfJQerZ, KByaekhHRSQffcstTMRuPdIOWDWF)
			};
			touchpads = new HIDTouchpad[1]
			{
				new HIDTouchpad(MVyaTUzHCqVKMixNLHoBXWLGpDe, new HIDTouchpad.TouchpadInfo(2, 0, 1912, 0, 941, invertY: false, reverseY: true), new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 35 + EDXXhVYiDlJJtAaxPfSWjACVEWlt,
					bitSize = 48
				}, PWisseXocVEHUbjOZQJYirCLKhV)
			};
			RxZVOrhLqMXxerZsIpzDPSAzlLW = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			jgMGgaFnweLBtYkyfJkIAKaoaGJ();
			ugRtaBGghvBHfBNKfEpdiAjJGmNJ(CvGIYAiMgYJmSqaJkRZPGAFfBeJb.JeCFtnHdSHkNKaBJSloqagIGicGg);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < wHROFVCPoBcgoRFVjtkCSkMeFuk.Length)
			{
				return false;
			}
			cybGKwJztDEKwjrhLCRFYDvpdgQD = (float)(timestamp - RxZVOrhLqMXxerZsIpzDPSAzlLW);
			RxZVOrhLqMXxerZsIpzDPSAzlLW = timestamp;
			wHROFVCPoBcgoRFVjtkCSkMeFuk.Write(inputReportPtr, inputReportLength, wHROFVCPoBcgoRFVjtkCSkMeFuk.Length);
			olZfKtIHJAbghWtngMEAzVwKXGk(wHROFVCPoBcgoRFVjtkCSkMeFuk);
			dpxLoNUKQscDlKAbeZOSlMIeEvD(wHROFVCPoBcgoRFVjtkCSkMeFuk, timestamp);
			FZlxIiFbfuBYttTXpfAXtPpltho(axes, wHROFVCPoBcgoRFVjtkCSkMeFuk, timestamp);
			FZlxIiFbfuBYttTXpfAXtPpltho(hats, wHROFVCPoBcgoRFVjtkCSkMeFuk, timestamp);
			FZlxIiFbfuBYttTXpfAXtPpltho(accelerometers, wHROFVCPoBcgoRFVjtkCSkMeFuk, timestamp);
			FZlxIiFbfuBYttTXpfAXtPpltho(gyroscopes, wHROFVCPoBcgoRFVjtkCSkMeFuk, timestamp);
			FZlxIiFbfuBYttTXpfAXtPpltho(touchpads, wHROFVCPoBcgoRFVjtkCSkMeFuk, timestamp);
			qhLwBqieAweIPNIxFWPhvUBlotx = (byte)(wHROFVCPoBcgoRFVjtkCSkMeFuk[30 + EDXXhVYiDlJJtAaxPfSWjACVEWlt] & 0xF);
			oKKKtsnsejMUirdLRaLBbuyzSxNf();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualShock4Extension(this);
		}

		private void ugRtaBGghvBHfBNKfEpdiAjJGmNJ(CvGIYAiMgYJmSqaJkRZPGAFfBeJb P_0)
		{
			if (jGOxswRfiQnpAKjvVmcALmNEnSp)
			{
				MWdbRGcNfhnGUHNBugXDSMzIjfT(P_0);
				jGOxswRfiQnpAKjvVmcALmNEnSp = false;
			}
		}

		private bool MWdbRGcNfhnGUHNBugXDSMzIjfT(CvGIYAiMgYJmSqaJkRZPGAFfBeJb P_0)
		{
			pOvvcIDYnvotyPoiWFcSBJEwlEPO();
			bool result = ELTYrNSbPohkwkUYTOzoZuPMPVT(P_0);
			if (vkWkmhGnkCiGPufGqunxVGAuoPl)
			{
				result = ELTYrNSbPohkwkUYTOzoZuPMPVT(P_0);
				vkWkmhGnkCiGPufGqunxVGAuoPl = false;
			}
			return result;
		}

		private void pOvvcIDYnvotyPoiWFcSBJEwlEPO()
		{
			if (WjjAjXYgQtgiBDqpizqbKFzAkpt && LyyuqokPPLtpMesPieOnMecKBZqG)
			{
				rduQNjAjUwpDOenklfOCQHuddaf[0] = 17;
				rduQNjAjUwpDOenklfOCQHuddaf[1] = 128;
				rduQNjAjUwpDOenklfOCQHuddaf[3] = byte.MaxValue;
				rduQNjAjUwpDOenklfOCQHuddaf[6] = (byte)vibrationMotors[1].SpeedRaw;
				rduQNjAjUwpDOenklfOCQHuddaf[7] = (byte)vibrationMotors[0].SpeedRaw;
				rduQNjAjUwpDOenklfOCQHuddaf[8] = lights[0].ColorRRaw;
				rduQNjAjUwpDOenklfOCQHuddaf[9] = lights[0].ColorGRaw;
				rduQNjAjUwpDOenklfOCQHuddaf[10] = lights[0].ColorBRaw;
				rduQNjAjUwpDOenklfOCQHuddaf[11] = ASVkohcIKgYiekHPMRcChSgVZHX;
				rduQNjAjUwpDOenklfOCQHuddaf[12] = dMsEKmJIIILirFohWiiFNjWNlPPU;
				rduQNjAjUwpDOenklfOCQHuddaf[21] = 53;
				rduQNjAjUwpDOenklfOCQHuddaf[22] = 53;
				rduQNjAjUwpDOenklfOCQHuddaf[23] = byte.MaxValue;
				rduQNjAjUwpDOenklfOCQHuddaf[24] = 0;
			}
			else
			{
				rduQNjAjUwpDOenklfOCQHuddaf[0] = 5;
				rduQNjAjUwpDOenklfOCQHuddaf[1] = byte.MaxValue;
				rduQNjAjUwpDOenklfOCQHuddaf[4] = (byte)vibrationMotors[1].SpeedRaw;
				rduQNjAjUwpDOenklfOCQHuddaf[5] = (byte)vibrationMotors[0].SpeedRaw;
				rduQNjAjUwpDOenklfOCQHuddaf[6] = lights[0].ColorRRaw;
				rduQNjAjUwpDOenklfOCQHuddaf[7] = lights[0].ColorGRaw;
				rduQNjAjUwpDOenklfOCQHuddaf[8] = lights[0].ColorBRaw;
				rduQNjAjUwpDOenklfOCQHuddaf[9] = ASVkohcIKgYiekHPMRcChSgVZHX;
				rduQNjAjUwpDOenklfOCQHuddaf[10] = dMsEKmJIIILirFohWiiFNjWNlPPU;
				rduQNjAjUwpDOenklfOCQHuddaf[19] = 53;
				rduQNjAjUwpDOenklfOCQHuddaf[20] = 53;
				rduQNjAjUwpDOenklfOCQHuddaf[21] = byte.MaxValue;
				rduQNjAjUwpDOenklfOCQHuddaf[22] = 0;
			}
		}

		private bool ELTYrNSbPohkwkUYTOzoZuPMPVT(CvGIYAiMgYJmSqaJkRZPGAFfBeJb P_0)
		{
			UIuQxCDBRfKZhvZspfAJKaLRfLk = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case CvGIYAiMgYJmSqaJkRZPGAFfBeJb.xZuRfCCvmDouxJKprRhnKByJKHD:
				if (MGQfESFdwSETxDxqyVdJeMTdFOuC == null)
				{
					return false;
				}
				return MGQfESFdwSETxDxqyVdJeMTdFOuC(mrlYPePkWgGjXkbGVrGeWhyFtAPK);
			case CvGIYAiMgYJmSqaJkRZPGAFfBeJb.JeCFtnHdSHkNKaBJSloqagIGicGg:
				if (vqMzbKWSwIyLZlIopEOnsCgzEOm == null)
				{
					return false;
				}
				vqMzbKWSwIyLZlIopEOnsCgzEOm(mrlYPePkWgGjXkbGVrGeWhyFtAPK);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void dpxLoNUKQscDlKAbeZOSlMIeEvD(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[CXYnBPTTKgnVdDoXATXCjgZxjbL];
			buttons[0].SetValue((b & 0x10) != 0, P_1);
			buttons[1].SetValue((b & 0x20) != 0, P_1);
			buttons[2].SetValue((b & 0x40) != 0, P_1);
			buttons[3].SetValue((b & 0x80) != 0, P_1);
			b = P_0[HBaCRwPgZrPREvxdpJHKjPtRile];
			buttons[4].SetValue((b & 1) != 0, P_1);
			buttons[5].SetValue((b & 2) != 0, P_1);
			buttons[6].SetValue((b & 4) != 0, P_1);
			buttons[7].SetValue((b & 8) != 0, P_1);
			buttons[8].SetValue((b & 0x10) != 0, P_1);
			buttons[9].SetValue((b & 0x20) != 0, P_1);
			buttons[10].SetValue((b & 0x40) != 0, P_1);
			buttons[11].SetValue((b & 0x80) != 0, P_1);
			b = P_0[jXtInnMmDdGZPeiTjFpzAgHwRJUa];
			buttons[12].SetValue((b & 1) != 0, P_1);
			buttons[13].SetValue((b & 2) != 0, P_1);
		}

		private void FZlxIiFbfuBYttTXpfAXtPpltho(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].UpdateValue(P_1, P_2);
			}
		}

		private void jgMGgaFnweLBtYkyfJkIAKaoaGJ()
		{
			if (isVibrating && ReInput.realTime >= UIuQxCDBRfKZhvZspfAJKaLRfLk)
			{
				jGOxswRfiQnpAKjvVmcALmNEnSp = true;
			}
		}

		private void olZfKtIHJAbghWtngMEAzVwKXGk(NativeBuffer P_0)
		{
			if (LyyuqokPPLtpMesPieOnMecKBZqG)
			{
				ushort num = wHROFVCPoBcgoRFVjtkCSkMeFuk.ReadUShort(10 + EDXXhVYiDlJJtAaxPfSWjACVEWlt);
				float vwPtuanyGWRxHnWClOEVPmMNZxZ;
				if (num != qRokMcLfaRgfIJXPKcDzHHcgtgEO)
				{
					int num2 = ((num >= qRokMcLfaRgfIJXPKcDzHHcgtgEO) ? (num - qRokMcLfaRgfIJXPKcDzHHcgtgEO) : (num + 65535 - qRokMcLfaRgfIJXPKcDzHHcgtgEO));
					vwPtuanyGWRxHnWClOEVPmMNZxZ = (float)num2 / 187500f;
				}
				else
				{
					int num2 = 0;
					vwPtuanyGWRxHnWClOEVPmMNZxZ = 0f;
				}
				qRokMcLfaRgfIJXPKcDzHHcgtgEO = num;
				VwPtuanyGWRxHnWClOEVPmMNZxZ = vwPtuanyGWRxHnWClOEVPmMNZxZ;
			}
		}

		private void oKKKtsnsejMUirdLRaLBbuyzSxNf()
		{
			if (LyyuqokPPLtpMesPieOnMecKBZqG)
			{
				_ = VwPtuanyGWRxHnWClOEVPmMNZxZ;
				_ = 0f;
				Vector3 vector = uAPtrWUbPXQoHhTqKhRjUbccauy(new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]), VwPtuanyGWRxHnWClOEVPmMNZxZ);
				FRTmmQPUnWbnoCkNfeRJjAVgTgm(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].rawValue[0] * -1f, accelerometers[0].rawValue[1] * -1f, accelerometers[0].rawValue[2] * -1f);
				vIqQnZyoPJofwcMiwvGSgEkpnIY(vector2, vector);
			}
		}

		private static bool FRTmmQPUnWbnoCkNfeRJjAVgTgm(ref Vector3 P_0)
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

		private void vIqQnZyoPJofwcMiwvGSgEkpnIY(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && CZLhNpkJhHIPmYZfEcYMSLdbFCd(P_0, out var oJIsQqtrPJwnHgFSiTilbiDStKl))
			{
				Quaternion a = ZdcORBqhUWdOBKRuAkZHmRzfODdc * quaternion;
				if (!ATCAQFGXcLCxwXHeGLKKEuFHTpsA)
				{
					ATCAQFGXcLCxwXHeGLKKEuFHTpsA = true;
					ZvzenEdfmTzcgEOrDYCpITUCXOgQ = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					UUXMNmwDjatdzFWCpQSvVmPQfnR = ZdcORBqhUWdOBKRuAkZHmRzfODdc;
				}
				ZvzenEdfmTzcgEOrDYCpITUCXOgQ *= quaternion;
				UUXMNmwDjatdzFWCpQSvVmPQfnR *= quaternion;
				Quaternion b;
				if ((oJIsQqtrPJwnHgFSiTilbiDStKl & OJIsQqtrPJwnHgFSiTilbiDStKl.rHBeEZRbXmTrohwcYCIrqoxKDtXB) != OJIsQqtrPJwnHgFSiTilbiDStKl.DVDMTdEnkAaktJFJqNakDhECjSAS)
				{
					b = hfTBTuKtMsULxRRvqgTKcjKfGD(P_0, a.eulerAngles.y);
				}
				else if ((oJIsQqtrPJwnHgFSiTilbiDStKl & OJIsQqtrPJwnHgFSiTilbiDStKl.BEudoXEezEvydtTCYEVTGAtHLCnM) != OJIsQqtrPJwnHgFSiTilbiDStKl.DVDMTdEnkAaktJFJqNakDhECjSAS)
				{
					b = ciSkNzilcjgPyKNphzlKKmvQCNI(P_0);
					Vector3 vector = UUXMNmwDjatdzFWCpQSvVmPQfnR * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				ZdcORBqhUWdOBKRuAkZHmRzfODdc = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				ZdcORBqhUWdOBKRuAkZHmRzfODdc *= quaternion;
				if (ATCAQFGXcLCxwXHeGLKKEuFHTpsA)
				{
					ATCAQFGXcLCxwXHeGLKKEuFHTpsA = false;
				}
			}
		}

		private static Quaternion GnDbhehCIEjuCYJyAfLIPkQDvelB(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = new Vector3(P_0.x, P_0.y, P_0.z);
			Vector3 vector2 = yzBhkCObGRjFYQcdGegxLwggWMt(vector, P_1);
			return new Quaternion(vector2.x, vector2.y, vector2.z, P_0.w);
		}

		private static Vector3 yzBhkCObGRjFYQcdGegxLwggWMt(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion ATtcsiYFxKISFXJRxIvamtdILIs(Quaternion P_0, WJhFMIZFrWmNWEpLKaMRBookODcp P_1)
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

		private float oOsfJGhPjRJrLcLukCrsFKOPnEFb(float P_0, float P_1)
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

		private Vector3 sOKYpsBagyvRKtbHwfEuHjzunOtM(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
			float num2 = MathTools.Atan2(P_0.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x2, P_1, z);
		}

		private Quaternion hfTBTuKtMsULxRRvqgTKcjKfGD(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
			float num2 = MathTools.Atan2(P_0.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x2, P_1, z);
		}

		private Quaternion ciSkNzilcjgPyKNphzlKKmvQCNI(Vector3 P_0, float P_1 = 0f)
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

		private float OkUllPDafIJcMWDruwwqzgoggwQ(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool DAfEaAhBKzGlmcGGhwWqEwIsIPPP(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool CZLhNpkJhHIPmYZfEcYMSLdbFCd(Vector3 P_0, out OJIsQqtrPJwnHgFSiTilbiDStKl P_1)
		{
			P_0.Normalize();
			P_1 = OJIsQqtrPJwnHgFSiTilbiDStKl.DVDMTdEnkAaktJFJqNakDhECjSAS;
			bool result = false;
			if (ahOIlQUcStoZhRNmbGPnKRtcZYx(P_0))
			{
				result = true;
				P_1 |= OJIsQqtrPJwnHgFSiTilbiDStKl.rHBeEZRbXmTrohwcYCIrqoxKDtXB;
			}
			if (RfoQtLuEgMQmkhwweBlHXALPADd(P_0))
			{
				result = true;
				P_1 |= OJIsQqtrPJwnHgFSiTilbiDStKl.BEudoXEezEvydtTCYEVTGAtHLCnM;
			}
			return result;
		}

		private bool ahOIlQUcStoZhRNmbGPnKRtcZYx(Vector3 P_0)
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

		private bool RfoQtLuEgMQmkhwweBlHXALPADd(Vector3 P_0)
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

		private Vector3 klPHkhJVvVcePIUQnuIeBCHkrqa(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 uAPtrWUbPXQoHhTqKhRjUbccauy(ExpandableArray_DataContainer<HIDGyroscope.IpHgaKZrMNjSmSUYCtbQntPnitn> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				HIDGyroscope.IpHgaKZrMNjSmSUYCtbQntPnitn ipHgaKZrMNjSmSUYCtbQntPnitn = P_0[i];
				result += uAPtrWUbPXQoHhTqKhRjUbccauy(ipHgaKZrMNjSmSUYCtbQntPnitn.oSkMqvraGdJlEtuhSBPKAEKedMXe, ipHgaKZrMNjSmSUYCtbQntPnitn.DLvkFzjqfKhkjYXKoErIBgzYkBe);
			}
			return result;
		}

		private Vector3 uAPtrWUbPXQoHhTqKhRjUbccauy(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private Vector3 vcdecUbftXCTuSEyruorBwVJAows(Vector3 P_0)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 3.4971635f;
		}

		private int QsYfgGFCirJisXEDSxcfUEyxkok(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void WfySlXgffbBFWglaGDLMfbFjiemi(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void HEtVjIDVGROiavpcmUCHcfJQerZ(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float KByaekhHRSQffcstTMRuPdIOWDWF()
		{
			return VwPtuanyGWRxHnWClOEVPmMNZxZ;
		}

		private void PWisseXocVEHUbjOZQJYirCLKhV(NativeBuffer P_0, HIDTouchpad.TouchData[] P_1)
		{
			int num = 35 + EDXXhVYiDlJJtAaxPfSWjACVEWlt;
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
			P_1[0].touchId = RDPLPIBXEIHCqtKyqIwjJfzMbSf(0, flag, num2);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = RDPLPIBXEIHCqtKyqIwjJfzMbSf(1, flag2, num3);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int RDPLPIBXEIHCqtKyqIwjJfzMbSf(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				VkiimGZWwRHVKBOuVpJFzCsHpiQ[P_0] = -1;
				qPHpsgxNmLqlyKloyCHkrbzTEuP[P_0] = P_2;
				return -1;
			}
			if (P_2 != qPHpsgxNmLqlyKloyCHkrbzTEuP[P_0])
			{
				int hOoUwCjwxAabnqBBdPJEReDAHuP = HOoUwCjwxAabnqBBdPJEReDAHuP;
				if (HOoUwCjwxAabnqBBdPJEReDAHuP == int.MaxValue)
				{
					HOoUwCjwxAabnqBBdPJEReDAHuP = 0;
				}
				else
				{
					HOoUwCjwxAabnqBBdPJEReDAHuP++;
				}
				qPHpsgxNmLqlyKloyCHkrbzTEuP[P_0] = P_2;
				VkiimGZWwRHVKBOuVpJFzCsHpiQ[P_0] = hOoUwCjwxAabnqBBdPJEReDAHuP;
				return hOoUwCjwxAabnqBBdPJEReDAHuP;
			}
			return VkiimGZWwRHVKBOuVpJFzCsHpiQ[P_0];
		}

		private void GBJaTSoaBWMGpLzBLvpdfHPvxwD()
		{
			jGOxswRfiQnpAKjvVmcALmNEnSp = true;
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
				ugRtaBGghvBHfBNKfEpdiAjJGmNJ(CvGIYAiMgYJmSqaJkRZPGAFfBeJb.xZuRfCCvmDouxJKprRhnKByJKHD);
				if (wHROFVCPoBcgoRFVjtkCSkMeFuk != null)
				{
					wHROFVCPoBcgoRFVjtkCSkMeFuk.Dispose();
				}
				if (rduQNjAjUwpDOenklfOCQHuddaf != null)
				{
					rduQNjAjUwpDOenklfOCQHuddaf.Dispose();
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
