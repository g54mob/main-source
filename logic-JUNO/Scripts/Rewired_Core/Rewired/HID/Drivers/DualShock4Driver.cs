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
	internal class DualShock4Driver : HIDDeviceDriver, IDriver_DualShock4, IControllerDriver, IDisposable
	{
		private enum EgVLOCyIroyLguEEcXjELfpuwQSD
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum WJutleEDitqRSKXWQbKwOYCYPOLV
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private const float UbOszxTZVOaRyFbDxIJLLDowakrd = 4f;

		private const int CvnLCbtPdEbFzmghYbjDpuFLmgkS = 14;

		private const int FrZvcKYVahzMBAhtiRSwYZtgjmWE = 2;

		private const int aEHvApfMYLufsqnplTqaioOlhlgiA = 0;

		private const int fhmUuLNdTWsQSAzMSTBOdizmgFHg = 1912;

		private const int IHGMfJUEPPMTAUcPpLKnLdnRlNxP = 0;

		private const int XIiCuzRPRGLwcrHeUJxWiLeaVoIs = 941;

		private const bool oABiBgiCgApamAcHOTWFnoijqEHwA = false;

		private const bool GsdeAbVfCrbQnDgVXMkUDXJuUmYw = true;

		private const float uURFJDMlRxtXPyJfdldMxlJTbnMKA = 2.5f;

		private const int NpXtWJAgSOARHYjOywAruBesCpCcA = 0;

		private const int KkahQYcgoVsKDmapjbxUVEGGBvdP = 0;

		private const int gevhOqGvKSLaYCCBjNYdCUTvzJul = 1;

		private const int CxiMfnQvcaVRPCaEVpItGTXWuhPJ = 0;

		private const int qgfeiWQfLveRCgnEQaBTAwLCGpTzb = 0;

		private const int nGQdyrLSQZUtZJpAYDCgNjWEKSDB = 0;

		private const int jITXTcZSfshUpUjcJfTVIfyABVYyA = 1;

		private const int mKOYHFvzSeqZzKXBCDhhmxMLveZk = 17;

		private const int mbZWTPkSMYaKVpiZuAleaGNhlvKhA = 0;

		private const int HYHzMYXMRMLhNuTHESrkkMygpdzs = 2;

		private const int cbQfcjpqBhKFaVEgYgabQvFoHbPhA = 64;

		private const int ZRXbcXJXHsHwJijyFmHOgMbdUlzsA = 78;

		private const int HNxBLqbbVOkKSksCupMgcHEcOafIB = 1;

		private const int KBadryJNzOWmPRcMzFiciAeOizSv = 2;

		private const int NqPJtwJFWRkQxZzyfLuwcYYkOfbJ = 3;

		private const int oNxXCTvEEmbSFFwBbXbNzRggHmIi = 4;

		private const int CyejkhopQTxwlOPkWLiPZKzjPqDx = 8;

		private const int ywPewAHhmcMKqOZQmpmjdglfZmKM = 9;

		private const int ghcMLoypjmaCsMCOKZkaLaGeCMAZ = 5;

		private const int abKeiUCHuqAGrZtDnSuszLRmoLIfb = 19;

		private const int JikhmJrdrBfpWFgcgzXrJemNbczC = 13;

		private const int TJZboCFCefpaWCKUSHpjLKcksXwC = 35;

		private const int sQQbXtklnRNoNxQTasZwLCgNAJvgA = 5;

		private const int GiCRkpzAbtjemaxhrlyriyPunywu = 6;

		private const int ZZjeptiqFEeGKGjBtQnQxwPVCCuWA = 7;

		private const int ToMtogHIUrzWogrlcSSilenviPIZ = 10;

		private const int XlfiHFxcbeNaiMEizVAbBgUvebAaA = 30;

		private const int QDmAWlbOFGhGDkwcQBhQSFzzXyiQ = 27;

		private const byte UaxYwMYKKpIDqzwqbKELeICVlBxL = 200;

		private const byte TtglOlvZEpKmrLBZqZHvkeUvexrW = 53;

		private const byte ANQqOPEAPMlEdHSGaIgLsafHYSvD = byte.MaxValue;

		private const byte MfdQYnyDpBqLrlmMduiwyRfrpNKs = 0;

		private const bool CKCKcYejDFIWhqCUrlCiXnCkFfHfA = true;

		private const int GWsfULoMqDTYhrwqHoaXrlBgfPxU = 60;

		private const int EtdlFGQXdfmXBwBjuSjyWMcMJqFG = 60;

		private const int aQHoFivioWLfZNjGXrsDxSgYHsPX = 187500;

		private const float lDFBpSbsbySlayjCHaBWGmjDfpXHA = 8192f;

		private const float WJaqhmDcisRsAmsfNGOzrrcxMfRf = 0.0010652969f;

		private const float bexppHBVnDNSXhNHvPeJIFsxkMin = 0.06103702f;

		private const bool jkZiElRveeRNUgavaLkihmNDsuvx = true;

		private const bool ppqTdpsurRoYXHHwoDrNlqfBkXmO = true;

		private const bool OrAufAqwIwLJuKaQibsmatVFDgTAA = true;

		private const bool eyYHfWZifSGHTCqfOHNyjwpIFONHA = true;

		private const float QTuPglWbxrMRqPQFJMzZsvVMlYPF = 4096f;

		private const float bZlbAUGQzeBjWhfgeUfQeqOAFoOec = 16384f;

		private const float KADACUrfovBQUaWPFSXOChlQsdtH = 16777216f;

		private const float IrYKkQXnvevdRzvjURLoINceLdrF = 268435460f;

		private const float bMiVzvfPuaepiNClAEsuiFSkOMQG = 0.01999998f;

		private const float PITSIzhZyEeHxZqncOChsPVJLHwh = 8192f;

		private const float pJifLIJiMCkQeLaXJruOKbArHQwLA = 0.98f;

		private const float zrrCmWjIdtIDNyiIHwesfMHGxKhC = 45f;

		private const float eSyEKpGhgQAZQHgTWqCrwzYhucFv = 20f;

		private readonly bool ERcBeMCdQyqfLYonQwOhiIlMmOzgb;

		private readonly DeviceConnectionType avLDaCfSfPRrmoplNgOzagWoqIZxA;

		private readonly int LQxOqwtPIyQAjxKBSyOYhaFJGPfG;

		private readonly int qrwKcnktLdfGojUHRIaogoTSHdzV;

		private readonly bool pqnjFolcKKeKINdQCFyRgkdYIQXwA;

		private readonly byte BgDXAFNnsdvtmihLrGbGjupwPcmgb;

		private readonly int LSsKoBBICaepjXkUBPepFFCgiLxC;

		private readonly int iLqbiKmtqCGXyEfywllnDsAyvNAiA;

		private readonly int TeMUPXJcYaBqmKgEdlrHgRnPkesFb;

		private readonly int RzKaZDlfhciCDWvblIRclGvhDTZhA;

		private readonly int NhUBhObsfQbXOnDYaEbbkWTDWzRQ;

		private readonly int TlOfFQoizhgLkSKOsHdWlozggUSH;

		private readonly NativeBuffer ODoCcRNGIrnrXazTpTXpoRxynkVg;

		private readonly NativeBuffer scDznqKKUWCKjyfQHOieUgKJKfNC;

		private readonly OutputReport kVqSCezbrbptadjzjZkuAiGkMzTg;

		private readonly Func<OutputReport, bool> NkNtCeVGRHHYfGxafpIREUQAvkbX;

		private readonly Action<OutputReport> WjFgJNzPJCCgUHUodMWFTxIvVUKd;

		private readonly GetHidFeatureData HpWVuCDPNxDuxMEAnXUNGPMxbAHIA;

		private bool xLDgDwpEWIsFsgymuGKswlaOcexi;

		private bool pgsIeJQaMreWyMXbCVcoCUHLHoYP;

		private double FBlWoDeSVGBcoEhLPIUOUSlvcEisA;

		private byte MXSgeSeNQNzwRZtaHsfgQXBgwGeP;

		private Quaternion kAJGmPnbWWeVxRchddQMgjBeJjyDb = Quaternion.identity;

		private ushort BjZaheftZKFLItgROepcbXYXfRoEb;

		private float UArZnVGoNUoKSdhAIUWGLNQblCxL;

		private double TxMyrnKoafWUOtrOYCsEFBQEcADbA;

		private float WQMGXIBkOeaLghkmCRbKYXpDrSxTb;

		private byte PzlNSqwwVxiBdMIjixewqEhyCjKkA;

		private byte fQLXGrSHSWvvtiqMvDdVqdLKiZkdA;

		private Quaternion HyIeODiYBfdwgnGwfCoyUmRbaacgA = Quaternion.identity;

		private Quaternion TvUCauxqZkzfZKLBCiNhgDsmCJpib = Quaternion.identity;

		private bool gXzQPZOIckrwLdDiVleGxlgSiQen;

		private int QWGjmYJuKDELzYTbCpKcQwaDhUZe;

		private int[] lTzZHHGreuAdGUKvMVGEQmJHXTkr = new int[2];

		private int[] uuNiPEHYEXepdCnCuCAkqULEhpwK = new int[2];

		private bool isVibrating
		{
			get
			{
				for (int i = 0; i < base.Rewired_002EDrivers_002EInterfaces_002EIControllerDriver_002EVibrationMotorCount; i++)
				{
					if (vibrationMotors[i].SpeedRaw > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		float IDriver_DualShock4.BatteryLevel
		{
			get
			{
				float num = 0f;
				num = ((!ERcBeMCdQyqfLYonQwOhiIlMmOzgb) ? ((float)(MXSgeSeNQNzwRZtaHsfgQXBgwGeP - 1) * 10f) : ((float)(MXSgeSeNQNzwRZtaHsfgQXBgwGeP + 2) * 10f));
				return MathTools.Clamp(num, 0f, 100f);
			}
		}

		float IDriver_DualShock4.LeftMotor
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

		float IDriver_DualShock4.RightMotor
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

		float IDriver_DualShock4.LightColorR
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

		float IDriver_DualShock4.LightColorG
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

		float IDriver_DualShock4.LightColorB
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

		float IDriver_DualShock4.LightFlashOnDuration
		{
			get
			{
				return (int)PzlNSqwwVxiBdMIjixewqEhyCjKkA;
			}
			set
			{
				PzlNSqwwVxiBdMIjixewqEhyCjKkA = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				xLDgDwpEWIsFsgymuGKswlaOcexi = true;
				if (PzlNSqwwVxiBdMIjixewqEhyCjKkA == 0 && fQLXGrSHSWvvtiqMvDdVqdLKiZkdA == 0)
				{
					pgsIeJQaMreWyMXbCVcoCUHLHoYP = true;
				}
			}
		}

		float IDriver_DualShock4.LightFlashOffDuration
		{
			get
			{
				return (int)fQLXGrSHSWvvtiqMvDdVqdLKiZkdA;
			}
			set
			{
				fQLXGrSHSWvvtiqMvDdVqdLKiZkdA = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				xLDgDwpEWIsFsgymuGKswlaOcexi = true;
				if (PzlNSqwwVxiBdMIjixewqEhyCjKkA == 0 && fQLXGrSHSWvvtiqMvDdVqdLKiZkdA == 0)
				{
					pgsIeJQaMreWyMXbCVcoCUHLHoYP = true;
				}
			}
		}

		Vector3 IDriver_DualShock4.AccelerometerValue => nxGNCVkFdcFmBHHBFFIFtNnZmbLh(accelerometers[0].rawValue);

		Vector3 IDriver_DualShock4.AccelerometerValueRaw => new Vector3(accelerometers[0].rawValue[0], accelerometers[0].rawValue[1], accelerometers[0].rawValue[2]);

		Vector3 IDriver_DualShock4.GyroscopeValue => tVkvBBZWPLLDbERKjweNiOezSLVT(gyroscopes[0].events);

		Vector3 IDriver_DualShock4.GyroscopeValueRaw => new Vector3(gyroscopes[0].rawValue[0], gyroscopes[0].rawValue[1], gyroscopes[0].rawValue[2]);

		Vector3 IDriver_DualShock4.LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);
				return WdaNbUjgpklXYEpgZkpPtYAgNTWP(vector, UArZnVGoNUoKSdhAIUWGLNQblCxL);
			}
		}

		Vector3 IDriver_DualShock4.LastGyroscopeValueRaw => new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);

		Quaternion IDriver_DualShock4.Orientation => kAJGmPnbWWeVxRchddQMgjBeJjyDb;

		int IDriver_DualShock4.MaxTouches => 2;

		public void ResetOrientation()
		{
			kAJGmPnbWWeVxRchddQMgjBeJjyDb = Quaternion.identity;
			gXzQPZOIckrwLdDiVleGxlgSiQen = false;
		}

		void IDriver_DualShock4.ResetOrientation()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ResetOrientation
			this.ResetOrientation();
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

		int IDriver_DualShock4.GetTouchCount()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchCount
			return this.GetTouchCount();
		}

		public bool IsTouchingAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return false;
			}
			return touchpads[0].values[index].isTouching;
		}

		bool IDriver_DualShock4.IsTouchingAtIndex(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtIndex
			return this.IsTouchingAtIndex(index);
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return touchpads[0].IsTouching(touchId);
		}

		bool IDriver_DualShock4.IsTouchingAtTouchId(int touchId)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtTouchId
			return this.IsTouchingAtTouchId(touchId);
		}

		public int GetTouchIdAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return -1;
			}
			return touchpads[0].values[index].touchId;
		}

		int IDriver_DualShock4.GetTouchIdAtIndex(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchIdAtIndex
			return this.GetTouchIdAtIndex(index);
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

		bool IDriver_DualShock4.GetTouchPositionByIndex(int index, out Vector2 position)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByIndex
			return this.GetTouchPositionByIndex(index, out position);
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

		bool IDriver_DualShock4.GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByTouchId
			return this.GetTouchPositionByTouchId(touchId, out position);
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

		bool IDriver_DualShock4.GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionAbsoluteByIndex
			return this.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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

		bool IDriver_DualShock4.GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionAbsoluteByTouchId
			return this.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
		}

		public void StopLightFlash()
		{
			PzlNSqwwVxiBdMIjixewqEhyCjKkA = 0;
			fQLXGrSHSWvvtiqMvDdVqdLKiZkdA = 0;
			xLDgDwpEWIsFsgymuGKswlaOcexi = true;
			pgsIeJQaMreWyMXbCVcoCUHLHoYP = true;
		}

		void IDriver_DualShock4.StopLightFlash()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopLightFlash
			this.StopLightFlash();
		}

		public void StopVibration()
		{
			int num = base.Rewired_002EDrivers_002EInterfaces_002EIControllerDriver_002EVibrationMotorCount;
			for (int i = 0; i < num; i++)
			{
				vibrationMotors[i].SpeedRaw = 0;
			}
		}

		void IDriver_DualShock4.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public DualShock4Driver(InitArgs P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			LQxOqwtPIyQAjxKBSyOYhaFJGPfG = P_0.hatZeroValue;
			qrwKcnktLdfGojUHRIaogoTSHdzV = P_0.hatSpan;
			LSsKoBBICaepjXkUBPepFFCgiLxC = P_0.inputReportLength;
			iLqbiKmtqCGXyEfywllnDsAyvNAiA = P_0.outputReportLength;
			NkNtCeVGRHHYfGxafpIREUQAvkbX = P_0.synchronousWriteOutputReportDelegate;
			WjFgJNzPJCCgUHUodMWFTxIvVUKd = P_0.asynchronousWriteOutputReportDelegate;
			HpWVuCDPNxDuxMEAnXUNGPMxbAHIA = P_0.getFeatureReportDelegate;
			avLDaCfSfPRrmoplNgOzagWoqIZxA = P_0.connectionType;
			ERcBeMCdQyqfLYonQwOhiIlMmOzgb = avLDaCfSfPRrmoplNgOzagWoqIZxA == DeviceConnectionType.Bluetooth;
			if (ERcBeMCdQyqfLYonQwOhiIlMmOzgb)
			{
				iLqbiKmtqCGXyEfywllnDsAyvNAiA = 78;
			}
			if (iLqbiKmtqCGXyEfywllnDsAyvNAiA < 23)
			{
				iLqbiKmtqCGXyEfywllnDsAyvNAiA = 23;
			}
			ODoCcRNGIrnrXazTpTXpoRxynkVg = new NativeBuffer(64);
			scDznqKKUWCKjyfQHOieUgKJKfNC = new NativeBuffer(iLqbiKmtqCGXyEfywllnDsAyvNAiA);
			kVqSCezbrbptadjzjZkuAiGkMzTg = new OutputReport(scDznqKKUWCKjyfQHOieUgKJKfNC.Pointer, scDznqKKUWCKjyfQHOieUgKJKfNC.Length, iLqbiKmtqCGXyEfywllnDsAyvNAiA);
			lights = new HIDLight[1]
			{
				new HIDLight(11, 24, 28)
			};
			lights[0].ValueChangedEvent += fEAEGcbDBRbDDhsfnVbluIYlkgHT;
			vibrationMotors = new HIDVibrationMotor[2]
			{
				new HIDVibrationMotor(0, 255),
				new HIDVibrationMotor(0, 255)
			};
			vibrationMotors[0].ValueChangedEvent += fEAEGcbDBRbDDhsfnVbluIYlkgHT;
			vibrationMotors[1].ValueChangedEvent += fEAEGcbDBRbDDhsfnVbluIYlkgHT;
			if (ERcBeMCdQyqfLYonQwOhiIlMmOzgb)
			{
				kVqSCezbrbptadjzjZkuAiGkMzTg.options |= OutputReportOptions.WriteDirect;
				pqnjFolcKKeKINdQCFyRgkdYIQXwA = true;
				pqnjFolcKKeKINdQCFyRgkdYIQXwA = lvSTtqfpQnFRjrQsXephKIMWQYPp(WweBMfPLHmZJRWKTQOAYhINlTVzC.Synchronous);
				if (!pqnjFolcKKeKINdQCFyRgkdYIQXwA)
				{
					kVqSCezbrbptadjzjZkuAiGkMzTg.options &= ~OutputReportOptions.WriteDirect;
				}
			}
			else
			{
				pqnjFolcKKeKINdQCFyRgkdYIQXwA = true;
				pqnjFolcKKeKINdQCFyRgkdYIQXwA = lvSTtqfpQnFRjrQsXephKIMWQYPp(WweBMfPLHmZJRWKTQOAYhINlTVzC.Synchronous);
			}
			if (!pqnjFolcKKeKINdQCFyRgkdYIQXwA)
			{
				throw new Exception("Special features not supported so just treat this as a standard HID device.");
			}
			BgDXAFNnsdvtmihLrGbGjupwPcmgb = 1;
			TeMUPXJcYaBqmKgEdlrHgRnPkesFb = 0;
			if (ERcBeMCdQyqfLYonQwOhiIlMmOzgb && pqnjFolcKKeKINdQCFyRgkdYIQXwA)
			{
				BgDXAFNnsdvtmihLrGbGjupwPcmgb = 17;
				TeMUPXJcYaBqmKgEdlrHgRnPkesFb = 2;
			}
			RzKaZDlfhciCDWvblIRclGvhDTZhA = 5 + TeMUPXJcYaBqmKgEdlrHgRnPkesFb;
			NhUBhObsfQbXOnDYaEbbkWTDWzRQ = 6 + TeMUPXJcYaBqmKgEdlrHgRnPkesFb;
			TlOfFQoizhgLkSKOsHdWlozggUSH = 7 + TeMUPXJcYaBqmKgEdlrHgRnPkesFb;
			buttons = new HIDButton[14];
			for (int i = 0; i < 14; i++)
			{
				buttons[i] = new HIDButton(BgDXAFNnsdvtmihLrGbGjupwPcmgb, new HIDControllerElement.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new HIDAxis[6]
			{
				new HIDAxis(BgDXAFNnsdvtmihLrGbGjupwPcmgb, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + TeMUPXJcYaBqmKgEdlrHgRnPkesFb,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(BgDXAFNnsdvtmihLrGbGjupwPcmgb, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + TeMUPXJcYaBqmKgEdlrHgRnPkesFb,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(BgDXAFNnsdvtmihLrGbGjupwPcmgb, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + TeMUPXJcYaBqmKgEdlrHgRnPkesFb,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(BgDXAFNnsdvtmihLrGbGjupwPcmgb, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + TeMUPXJcYaBqmKgEdlrHgRnPkesFb,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(BgDXAFNnsdvtmihLrGbGjupwPcmgb, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 8 + TeMUPXJcYaBqmKgEdlrHgRnPkesFb,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new HIDAxis(BgDXAFNnsdvtmihLrGbGjupwPcmgb, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 9 + TeMUPXJcYaBqmKgEdlrHgRnPkesFb,
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
				new HIDHat(BgDXAFNnsdvtmihLrGbGjupwPcmgb, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 5 + TeMUPXJcYaBqmKgEdlrHgRnPkesFb,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, ykIpgKeJecFIhYdBvDoVuFzvdAcA)
			};
			accelerometers = new HIDAccelerometer[1]
			{
				new HIDAccelerometer(BgDXAFNnsdvtmihLrGbGjupwPcmgb, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 19 + TeMUPXJcYaBqmKgEdlrHgRnPkesFb,
					bitSize = 48
				}, 3, lxEvUgRUayyEDhdWOiuovhWSgMnkA)
			};
			gyroscopes = new HIDGyroscope[1]
			{
				new HIDGyroscope(P_0.updateLoopSetting, BgDXAFNnsdvtmihLrGbGjupwPcmgb, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 13 + TeMUPXJcYaBqmKgEdlrHgRnPkesFb,
					bitSize = 48
				}, 3, 60, avgzvSRmeCGZWyGNMEqxeZbGgIdtA, BMzKBxbqxDZwfGkRKXrpuGFidPbI)
			};
			touchpads = new HIDTouchpad[1]
			{
				new HIDTouchpad(BgDXAFNnsdvtmihLrGbGjupwPcmgb, new HIDTouchpad.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 35 + TeMUPXJcYaBqmKgEdlrHgRnPkesFb,
					bitSize = 48
				}, 60, vpADcmafeKmncOFZjqKbDhpsCeqdA)
			};
			TxMyrnKoafWUOtrOYCsEFBQEcADbA = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			GngbRBCLyQHozzoOcPPcTbhXCXWh();
			zBpCZCyqslxdTkyASgBKAceTjQphA(WweBMfPLHmZJRWKTQOAYhINlTVzC.Asynchronous);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < ODoCcRNGIrnrXazTpTXpoRxynkVg.Length)
			{
				return false;
			}
			WQMGXIBkOeaLghkmCRbKYXpDrSxTb = (float)(timestamp - TxMyrnKoafWUOtrOYCsEFBQEcADbA);
			TxMyrnKoafWUOtrOYCsEFBQEcADbA = timestamp;
			ODoCcRNGIrnrXazTpTXpoRxynkVg.Write(inputReportPtr, inputReportLength, ODoCcRNGIrnrXazTpTXpoRxynkVg.Length);
			xgoCYwdiwqBCBfEWrLESXjsAVKKjA(ODoCcRNGIrnrXazTpTXpoRxynkVg);
			jwOXkIWXWFblNDAUdhusmYemoqKy(ODoCcRNGIrnrXazTpTXpoRxynkVg, timestamp);
			HIDControllerElement[] array = axes;
			VYaABVLUmZiiZIzNifHsjhGpEhkpA(array, ODoCcRNGIrnrXazTpTXpoRxynkVg, timestamp);
			array = hats;
			VYaABVLUmZiiZIzNifHsjhGpEhkpA(array, ODoCcRNGIrnrXazTpTXpoRxynkVg, timestamp);
			array = accelerometers;
			VYaABVLUmZiiZIzNifHsjhGpEhkpA(array, ODoCcRNGIrnrXazTpTXpoRxynkVg, timestamp);
			array = gyroscopes;
			VYaABVLUmZiiZIzNifHsjhGpEhkpA(array, ODoCcRNGIrnrXazTpTXpoRxynkVg, timestamp);
			array = touchpads;
			VYaABVLUmZiiZIzNifHsjhGpEhkpA(array, ODoCcRNGIrnrXazTpTXpoRxynkVg, timestamp);
			MXSgeSeNQNzwRZtaHsfgQXBgwGeP = (byte)(ODoCcRNGIrnrXazTpTXpoRxynkVg[30 + TeMUPXJcYaBqmKgEdlrHgRnPkesFb] & 0xF);
			VTlNxGuZpTrDezgeDqTZTPtANHdi();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualShock4Extension(this);
		}

		private void zBpCZCyqslxdTkyASgBKAceTjQphA(WweBMfPLHmZJRWKTQOAYhINlTVzC P_0)
		{
			if (xLDgDwpEWIsFsgymuGKswlaOcexi)
			{
				lvSTtqfpQnFRjrQsXephKIMWQYPp(P_0);
				xLDgDwpEWIsFsgymuGKswlaOcexi = false;
			}
		}

		private bool lvSTtqfpQnFRjrQsXephKIMWQYPp(WweBMfPLHmZJRWKTQOAYhINlTVzC P_0)
		{
			GnLhKrdNYLWQRhbeTidLwuQSraXe();
			bool result = gzxzLXiYYFhUDRcGrJByehqKqoJr(P_0);
			if (pgsIeJQaMreWyMXbCVcoCUHLHoYP)
			{
				result = gzxzLXiYYFhUDRcGrJByehqKqoJr(P_0);
				pgsIeJQaMreWyMXbCVcoCUHLHoYP = false;
			}
			return result;
		}

		private void GnLhKrdNYLWQRhbeTidLwuQSraXe()
		{
			if (ERcBeMCdQyqfLYonQwOhiIlMmOzgb && pqnjFolcKKeKINdQCFyRgkdYIQXwA)
			{
				scDznqKKUWCKjyfQHOieUgKJKfNC[0] = 17;
				scDznqKKUWCKjyfQHOieUgKJKfNC[1] = 128;
				scDznqKKUWCKjyfQHOieUgKJKfNC[3] = byte.MaxValue;
				scDznqKKUWCKjyfQHOieUgKJKfNC[6] = (byte)vibrationMotors[1].SpeedRaw;
				scDznqKKUWCKjyfQHOieUgKJKfNC[7] = (byte)vibrationMotors[0].SpeedRaw;
				scDznqKKUWCKjyfQHOieUgKJKfNC[8] = lights[0].ColorRRaw;
				scDznqKKUWCKjyfQHOieUgKJKfNC[9] = lights[0].ColorGRaw;
				scDznqKKUWCKjyfQHOieUgKJKfNC[10] = lights[0].ColorBRaw;
				scDznqKKUWCKjyfQHOieUgKJKfNC[11] = PzlNSqwwVxiBdMIjixewqEhyCjKkA;
				scDznqKKUWCKjyfQHOieUgKJKfNC[12] = fQLXGrSHSWvvtiqMvDdVqdLKiZkdA;
				scDznqKKUWCKjyfQHOieUgKJKfNC[21] = 53;
				scDznqKKUWCKjyfQHOieUgKJKfNC[22] = 53;
				scDznqKKUWCKjyfQHOieUgKJKfNC[23] = byte.MaxValue;
				scDznqKKUWCKjyfQHOieUgKJKfNC[24] = 0;
			}
			else
			{
				scDznqKKUWCKjyfQHOieUgKJKfNC[0] = 5;
				scDznqKKUWCKjyfQHOieUgKJKfNC[1] = byte.MaxValue;
				scDznqKKUWCKjyfQHOieUgKJKfNC[4] = (byte)vibrationMotors[1].SpeedRaw;
				scDznqKKUWCKjyfQHOieUgKJKfNC[5] = (byte)vibrationMotors[0].SpeedRaw;
				scDznqKKUWCKjyfQHOieUgKJKfNC[6] = lights[0].ColorRRaw;
				scDznqKKUWCKjyfQHOieUgKJKfNC[7] = lights[0].ColorGRaw;
				scDznqKKUWCKjyfQHOieUgKJKfNC[8] = lights[0].ColorBRaw;
				scDznqKKUWCKjyfQHOieUgKJKfNC[9] = PzlNSqwwVxiBdMIjixewqEhyCjKkA;
				scDznqKKUWCKjyfQHOieUgKJKfNC[10] = fQLXGrSHSWvvtiqMvDdVqdLKiZkdA;
				scDznqKKUWCKjyfQHOieUgKJKfNC[19] = 53;
				scDznqKKUWCKjyfQHOieUgKJKfNC[20] = 53;
				scDznqKKUWCKjyfQHOieUgKJKfNC[21] = byte.MaxValue;
				scDznqKKUWCKjyfQHOieUgKJKfNC[22] = 0;
			}
		}

		private bool gzxzLXiYYFhUDRcGrJByehqKqoJr(WweBMfPLHmZJRWKTQOAYhINlTVzC P_0)
		{
			FBlWoDeSVGBcoEhLPIUOUSlvcEisA = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case WweBMfPLHmZJRWKTQOAYhINlTVzC.Synchronous:
				if (NkNtCeVGRHHYfGxafpIREUQAvkbX == null)
				{
					return false;
				}
				return NkNtCeVGRHHYfGxafpIREUQAvkbX(kVqSCezbrbptadjzjZkuAiGkMzTg);
			case WweBMfPLHmZJRWKTQOAYhINlTVzC.Asynchronous:
				if (WjFgJNzPJCCgUHUodMWFTxIvVUKd == null)
				{
					return false;
				}
				WjFgJNzPJCCgUHUodMWFTxIvVUKd(kVqSCezbrbptadjzjZkuAiGkMzTg);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void jwOXkIWXWFblNDAUdhusmYemoqKy(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[RzKaZDlfhciCDWvblIRclGvhDTZhA];
			buttons[0].SetValue((b & 0x10) != 0, P_1);
			buttons[1].SetValue((b & 0x20) != 0, P_1);
			buttons[2].SetValue((b & 0x40) != 0, P_1);
			buttons[3].SetValue((b & 0x80) != 0, P_1);
			b = P_0[NhUBhObsfQbXOnDYaEbbkWTDWzRQ];
			buttons[4].SetValue((b & 1) != 0, P_1);
			buttons[5].SetValue((b & 2) != 0, P_1);
			buttons[6].SetValue((b & 4) != 0, P_1);
			buttons[7].SetValue((b & 8) != 0, P_1);
			buttons[8].SetValue((b & 0x10) != 0, P_1);
			buttons[9].SetValue((b & 0x20) != 0, P_1);
			buttons[10].SetValue((b & 0x40) != 0, P_1);
			buttons[11].SetValue((b & 0x80) != 0, P_1);
			b = P_0[TlOfFQoizhgLkSKOsHdWlozggUSH];
			buttons[12].SetValue((b & 1) != 0, P_1);
			buttons[13].SetValue((b & 2) != 0, P_1);
		}

		private void VYaABVLUmZiiZIzNifHsjhGpEhkpA(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].UpdateValue(P_1, P_2);
			}
		}

		private void GngbRBCLyQHozzoOcPPcTbhXCXWh()
		{
			if (isVibrating && ReInput.realTime >= FBlWoDeSVGBcoEhLPIUOUSlvcEisA)
			{
				xLDgDwpEWIsFsgymuGKswlaOcexi = true;
			}
		}

		private void xgoCYwdiwqBCBfEWrLESXjsAVKKjA(NativeBuffer P_0)
		{
			if (pqnjFolcKKeKINdQCFyRgkdYIQXwA)
			{
				ushort num = ODoCcRNGIrnrXazTpTXpoRxynkVg.ReadUShort(10 + TeMUPXJcYaBqmKgEdlrHgRnPkesFb);
				float uArZnVGoNUoKSdhAIUWGLNQblCxL;
				if (num != BjZaheftZKFLItgROepcbXYXfRoEb)
				{
					int num2 = ((num >= BjZaheftZKFLItgROepcbXYXfRoEb) ? (num - BjZaheftZKFLItgROepcbXYXfRoEb) : (num + 65535 - BjZaheftZKFLItgROepcbXYXfRoEb));
					uArZnVGoNUoKSdhAIUWGLNQblCxL = (float)num2 / 187500f;
				}
				else
				{
					int num2 = 0;
					uArZnVGoNUoKSdhAIUWGLNQblCxL = 0f;
				}
				BjZaheftZKFLItgROepcbXYXfRoEb = num;
				UArZnVGoNUoKSdhAIUWGLNQblCxL = uArZnVGoNUoKSdhAIUWGLNQblCxL;
			}
		}

		private void VTlNxGuZpTrDezgeDqTZTPtANHdi()
		{
			if (pqnjFolcKKeKINdQCFyRgkdYIQXwA)
			{
				_ = UArZnVGoNUoKSdhAIUWGLNQblCxL;
				_ = 0f;
				Vector3 vector = WdaNbUjgpklXYEpgZkpPtYAgNTWP(new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]), UArZnVGoNUoKSdhAIUWGLNQblCxL);
				OBMCOERUmyhLBAApQDTFnJZcfPaJ(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].rawValue[0] * -1f, accelerometers[0].rawValue[1] * -1f, accelerometers[0].rawValue[2] * -1f);
				UnyCilaqMVuksfovexASTcmorDNU(vector2, vector);
			}
		}

		private static bool OBMCOERUmyhLBAApQDTFnJZcfPaJ(ref Vector3 P_0)
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

		private void UnyCilaqMVuksfovexASTcmorDNU(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && bJuqhNGXebgzhcsASUWVIasHoqxK(P_0, out var wJutleEDitqRSKXWQbKwOYCYPOLV))
			{
				Quaternion a = kAJGmPnbWWeVxRchddQMgjBeJjyDb * quaternion;
				if (!gXzQPZOIckrwLdDiVleGxlgSiQen)
				{
					gXzQPZOIckrwLdDiVleGxlgSiQen = true;
					HyIeODiYBfdwgnGwfCoyUmRbaacgA = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					TvUCauxqZkzfZKLBCiNhgDsmCJpib = kAJGmPnbWWeVxRchddQMgjBeJjyDb;
				}
				HyIeODiYBfdwgnGwfCoyUmRbaacgA *= quaternion;
				TvUCauxqZkzfZKLBCiNhgDsmCJpib *= quaternion;
				Quaternion b;
				if ((wJutleEDitqRSKXWQbKwOYCYPOLV & WJutleEDitqRSKXWQbKwOYCYPOLV.XZ) != WJutleEDitqRSKXWQbKwOYCYPOLV.None)
				{
					b = NYNUtumZYYlbvxwWYjrPGZFfDlPm(P_0, a.eulerAngles.y);
				}
				else if ((wJutleEDitqRSKXWQbKwOYCYPOLV & WJutleEDitqRSKXWQbKwOYCYPOLV.Y) != WJutleEDitqRSKXWQbKwOYCYPOLV.None)
				{
					b = NZXlaNwAjBUryeEmFawsnPlQAsOeA(P_0);
					Vector3 vector = TvUCauxqZkzfZKLBCiNhgDsmCJpib * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				kAJGmPnbWWeVxRchddQMgjBeJjyDb = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				kAJGmPnbWWeVxRchddQMgjBeJjyDb *= quaternion;
				if (gXzQPZOIckrwLdDiVleGxlgSiQen)
				{
					gXzQPZOIckrwLdDiVleGxlgSiQen = false;
				}
			}
		}

		private static Quaternion OXjdUkcBBhRcRFcmaUOYffZwniDfb(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = bFwJZDCWnPIxGMBdPuRTDJbGahSJA(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 bFwJZDCWnPIxGMBdPuRTDJbGahSJA(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion ueYTosuVAEERHSeYBSJTRTnhreVy(Quaternion P_0, EgVLOCyIroyLguEEcXjELfpuwQSD P_1)
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

		private float TeySkwsgfxgIabthnBpjmmhxXHdAA(float P_0, float P_1)
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

		private Vector3 xLWvcaSLGICvJFDRylkihmRQaianA(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion NYNUtumZYYlbvxwWYjrPGZFfDlPm(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion NZXlaNwAjBUryeEmFawsnPlQAsOeA(Vector3 P_0, float P_1 = 0f)
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

		private float qYPzfDSGRnSmEUiyWAGZZdDQCqYn(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool yybfKLWSySamnLxfvdRXToktAvUc(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool bJuqhNGXebgzhcsASUWVIasHoqxK(Vector3 P_0, out WJutleEDitqRSKXWQbKwOYCYPOLV P_1)
		{
			P_0.Normalize();
			P_1 = WJutleEDitqRSKXWQbKwOYCYPOLV.None;
			bool result = false;
			if (gCkIeEicThJsbbqfePOWQKBsrYbMB(P_0))
			{
				result = true;
				P_1 |= WJutleEDitqRSKXWQbKwOYCYPOLV.XZ;
			}
			if (luLNMFkCLmkLrUgzMyErSdZdWJkI(P_0))
			{
				result = true;
				P_1 |= WJutleEDitqRSKXWQbKwOYCYPOLV.Y;
			}
			return result;
		}

		private bool gCkIeEicThJsbbqfePOWQKBsrYbMB(Vector3 P_0)
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

		private bool luLNMFkCLmkLrUgzMyErSdZdWJkI(Vector3 P_0)
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

		private Vector3 nxGNCVkFdcFmBHHBFFIFtNnZmbLh(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 tVkvBBZWPLLDbERKjweNiOezSLVT(RingBuffer<HIDGyroscope.OhjuMudkxrxhcFUaaGLQSPzGFPF> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				HIDGyroscope.OhjuMudkxrxhcFUaaGLQSPzGFPF ohjuMudkxrxhcFUaaGLQSPzGFPF = P_0[i];
				result += WdaNbUjgpklXYEpgZkpPtYAgNTWP(ohjuMudkxrxhcFUaaGLQSPzGFPF.stvAgpvMmtnJlkoKkQdWZaBKzoMT, ohjuMudkxrxhcFUaaGLQSPzGFPF.QrPZYcYyTMgjTnwjmdfpJlOyqPXW);
			}
			return result;
		}

		private Vector3 WdaNbUjgpklXYEpgZkpPtYAgNTWP(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int ykIpgKeJecFIhYdBvDoVuFzvdAcA(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void lxEvUgRUayyEDhdWOiuovhWSgMnkA(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void avgzvSRmeCGZWyGNMEqxeZbGgIdtA(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float BMzKBxbqxDZwfGkRKXrpuGFidPbI()
		{
			return UArZnVGoNUoKSdhAIUWGLNQblCxL;
		}

		private void vpADcmafeKmncOFZjqKbDhpsCeqdA(NativeBuffer P_0, HIDTouchpad.TouchData[] P_1)
		{
			int num = 35 + TeMUPXJcYaBqmKgEdlrHgRnPkesFb;
			int positionRawX = P_0[1 + num] + (P_0[2 + num] & 0xF) * 255;
			int positionRawY = ((P_0[2 + num] & 0xF0) >> 4) + P_0[3 + num] * 16;
			int positionRawX2 = P_0[5 + num] + (P_0[6 + num] & 0xF) * 255;
			int positionRawY2 = ((P_0[6 + num] & 0xF0) >> 4) + P_0[7 + num] * 16;
			byte b = P_0[num];
			bool flag = b < 128;
			byte num2 = P_0[num + 4];
			bool flag2 = num2 < 128;
			int num3 = b & 0x7F;
			int num4 = num2 & 0x7F;
			P_1[0].isTouching = flag;
			P_1[0].touchId = giqDMXoYjzpLussOTXYTNdcgNoAk(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = giqDMXoYjzpLussOTXYTNdcgNoAk(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int giqDMXoYjzpLussOTXYTNdcgNoAk(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				lTzZHHGreuAdGUKvMVGEQmJHXTkr[P_0] = -1;
				uuNiPEHYEXepdCnCuCAkqULEhpwK[P_0] = P_2;
				return -1;
			}
			if (P_2 != uuNiPEHYEXepdCnCuCAkqULEhpwK[P_0])
			{
				int qWGjmYJuKDELzYTbCpKcQwaDhUZe = QWGjmYJuKDELzYTbCpKcQwaDhUZe;
				if (QWGjmYJuKDELzYTbCpKcQwaDhUZe == int.MaxValue)
				{
					QWGjmYJuKDELzYTbCpKcQwaDhUZe = 0;
				}
				else
				{
					QWGjmYJuKDELzYTbCpKcQwaDhUZe++;
				}
				uuNiPEHYEXepdCnCuCAkqULEhpwK[P_0] = P_2;
				lTzZHHGreuAdGUKvMVGEQmJHXTkr[P_0] = qWGjmYJuKDELzYTbCpKcQwaDhUZe;
				return qWGjmYJuKDELzYTbCpKcQwaDhUZe;
			}
			return lTzZHHGreuAdGUKvMVGEQmJHXTkr[P_0];
		}

		private void fEAEGcbDBRbDDhsfnVbluIYlkgHT()
		{
			xLDgDwpEWIsFsgymuGKswlaOcexi = true;
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
				zBpCZCyqslxdTkyASgBKAceTjQphA(WweBMfPLHmZJRWKTQOAYhINlTVzC.Synchronous);
				if (ODoCcRNGIrnrXazTpTXpoRxynkVg != null)
				{
					ODoCcRNGIrnrXazTpTXpoRxynkVg.Dispose();
				}
				if (scDznqKKUWCKjyfQHOieUgKJKfNC != null)
				{
					scDznqKKUWCKjyfQHOieUgKJKfNC.Dispose();
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
