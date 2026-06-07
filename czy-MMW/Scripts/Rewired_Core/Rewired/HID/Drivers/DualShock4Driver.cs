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
	internal class DualShock4Driver : HIDDeviceDriver, IDriver_DualShock4, IControllerDriver, IDisposable
	{
		private enum MMIAPStqLUVOKyMFUcIPvGVxWSwG
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum IDrEqiHvpDEsPEDRgehfBaeLpkbaA
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private const float UXNvPhKeSaFXjVqkZklMdjtbQYFk = 4f;

		private const int KwuYhesuiOCqvewgoEQCRtASOWDc = 14;

		private const int BSaoOHNpDqEWXQsCRgrMcLtoDmfb = 2;

		private const int iyCFBjwkXzhKvqHsVXDxUNwuBhSl = 0;

		private const int fDjZiPAIcwiRXKGyaBkNLVPtiSfGA = 1912;

		private const int MoTaqZHwInYqJCzYJTjgbvZQtpLW = 0;

		private const int TcfjMhMIOqgLxlxGyKyVQGZbQloC = 941;

		private const bool ceMTWgTAfgdTfeaUgirQGKOsVeddA = false;

		private const bool YlenDjATOBtZiXIIvZvVzfxhGoud = true;

		private const float qrCSIFDLOVgaWsSgDKQLNrdOiNwq = 2.5f;

		private const int JICqePZiRgerUWiDOvMwWCIrFimH = 0;

		private const int YqvcoMbOpvWZYkpyPHWLvagZtRTT = 0;

		private const int ukiwNiZGaaGeBIBGVbcqbutwILGKA = 1;

		private const int MaxFnSDbgMcYsATirSfgyhjLCNne = 0;

		private const int iMourCBnIFRqXlfRgpmIADjNZVhu = 0;

		private const int rnViMgEqVpfyeHcggerRbeBPuuwE = 0;

		private const int rcKkEkSgySRviMBbjPyQLdEFCxet = 1;

		private const int eePjSPmdNQCwgfGGoyeekSsISBrsA = 17;

		private const int aEIgEDjbPwmfSrpIYrGfqItqGZiBA = 0;

		private const int LcUlNEEpKqxWYgSEadCnQPMlsZDV = 2;

		private const int kUDxMrwgYBscdXXjyNVwyDjvHhrG = 64;

		private const int JvCLxHYDEUULQrunjFkVyBByvNFn = 78;

		private const int DhklAcmZWolRJeYZGdNhxcuJSrXi = 1;

		private const int WhakgHOgeazECNDvLsdnWGQHPkzB = 2;

		private const int NMWyywAPDhatkBZrBUodQNqjreNS = 3;

		private const int okuGTZuEZUeEKXuQHtmMLUIhqdwO = 4;

		private const int GExbjrEjLdHVivAnsrHWRhBsnIzZA = 8;

		private const int otEufSAOtYAtdUMRMDHcBsBkkOkU = 9;

		private const int unfAAcFtqIGvpxSLaQHjBtujLggqA = 5;

		private const int eELNrIYTlWHxwldWTUTltxjhLvwP = 19;

		private const int ZElsoTwXubEIPHMnESPmjDOIIRRU = 13;

		private const int TgEkkoElXXWUPKLLsumuzUchUlWK = 35;

		private const int eKFKVbnCmtBYWrAYOowrfCGGjUVi = 5;

		private const int YbBCStacLXJficueTVIqSbwbYoEC = 6;

		private const int DGaWwvlNKorvZtPYHKqJIgtECeOq = 7;

		private const int LHZExuUlTLmbpcLiCdbxPYZexpok = 10;

		private const int LRkvUJaRgOBDbKWjDMtwzWqkCFkV = 30;

		private const int YxpPLdeOnmrzSwziqWcByGPqWTII = 27;

		private const byte KxeLSINBBDFtvzGjFmrAIlkAcLDCA = 200;

		private const byte FqtBBzbyDDvPsTuGMeksBWkgNZFDA = 53;

		private const byte EuVrmIZpBsUORJBJKrXMShEWdiLy = byte.MaxValue;

		private const byte ELwgXxtlqvCkcazJVvHhQABcEnolA = 0;

		private const bool KrJXvGxYYpGtioKNDhpbjuejaBjKA = true;

		private const int atqOhkgbSdKpewoJBpdswCJiGMML = 25;

		private const int wMWDKesWjmXKONLXpAZAgJCTnOrdA = 187500;

		private const float hUkUIeaiFAprGkFEhybFcBuYBcpD = 8192f;

		private const float EQzhWgGmvCknZugtznWqXZXicBtK = 0.0010652969f;

		private const float xuJkLDCqJhkIdvEAVgKQyIcosfKC = 0.06103702f;

		private const bool rQEZRvSYbEswFqbmSGHfFRtUZQXCA = true;

		private const bool zsdEwrxvuzNfWFCvIBAOIDBQkpIRA = true;

		private const bool OULeqKlXFWluhQmTOeZzYZpWpKrv = true;

		private const bool eURvwWSVacgiMUhgwmelDiTJXuhr = true;

		private const float MqxGtnABgNiarXRSfpOSIQzJRHlOb = 4096f;

		private const float bduoXUPSeEuAFbQpAtIDUMiInGct = 16384f;

		private const float AXYZJSafrLkyXefYlsvXgNHXhGPU = 16777216f;

		private const float YNFNSAYyuWCtUxNcuerzcIbbhqHk = 268435460f;

		private const float lPzEcpwtmMNAfPeeqzAtSiShcZmD = 0.01999998f;

		private const float BCKBudqxMeTGgPuxKbByKxsKfhGd = 8192f;

		private const float bDrRMMxkZumjngZEhmVRLjcmYqGR = 0.98f;

		private const float rXqXBsyxVLhEOmVpvRchPvsJDNLF = 45f;

		private const float wLfDslHjZiqsNBMkexHkYaqmWtxG = 20f;

		private readonly bool OUxlvAeuJGkMWwKmaUdogYRNcyBq;

		private readonly DeviceConnectionType qRAUbEeSczEYtsVurhXyCaehakfs;

		private readonly int ZTgJoLqJeMheozCccZfRFxMSuuNE;

		private readonly int iXdctrcjEXOzbUpShGNfjIhRuVXwA;

		private readonly bool pTqyWeeDnehXTBZTiVgUUPkFqLnE;

		private readonly byte PjAKPRQcxVvWtgeSVlQHWTNbbGCO;

		private readonly int BPdPmXSZXYXscPthroOcbVfhEAZi;

		private readonly int qfrLdStLpmTyxtAjIgGoSpgvmnkN;

		private readonly int FbJhYDHIVEzTznwDVgWKMxJUOGYaA;

		private readonly int DtHKARgkmArAYQwsPaRdJBTsnezj;

		private readonly int ZATgPKkFkwgWBpCREKyiOkvCDSpl;

		private readonly int PHLktKtdaPcHtMUBEhcVRsTjMxwK;

		private readonly NativeBuffer AXvBNPINbJUQfsQSDkmZAVMbDzvb;

		private readonly NativeBuffer wISgMiNDFynTiijsflVhahOUfeln;

		private readonly OutputReport ksjTVycWuFUubpBsBqFbsckrgqnV;

		private readonly Func<OutputReport, bool> RNMgctCGepljmGhYThoQeioLUaVG;

		private readonly Action<OutputReport> KPUjsLwpGitUBNFHNhIUnONyllcf;

		private readonly GetHidFeatureData ZiThhKUfGZQViCGDXWzUeAyuFgbs;

		private bool lpWhAsyLKoZNzefVCnUnCUTPKsVC;

		private bool xZjPNOXNhFfxMMcsuLtgmnGOAkrc;

		private double PEeGxXzNSqOLhjKOjErLkwNsMaYwA;

		private byte IuPWlEhfVfYNAZHjvqOrkElvMiSw;

		private Quaternion guWNBToZKwyuGBqANfeHBdwtPNUE = Quaternion.identity;

		private ushort PmAMicutEasVJkGSaEUvhzeIrHGK;

		private float CkXALNFSmfHJXlFkoxDrSwiZTHX;

		private double DAXmilTqvPGhVgrVwAXPlpoNqcrHA;

		private float KuNqYYdaFKgyxeDpnOILnaDqhcJhA;

		private byte BwkeXklxMJgmskIcOwNnaORxjDccb;

		private byte pTSkPtTHZkIIsswDJsQCKzbHdvSl;

		private Quaternion LEBWDBfXWLUinrbvNeFvwivyeAYM = Quaternion.identity;

		private Quaternion DYBrNymEIIUbMAOGacRkxGMfrkBF = Quaternion.identity;

		private bool oeqiEBIZpWYPKvpdvHLLwZEXbkKDA;

		private int EdVAkKYqdzXdsIoMoZEheqMUANjq;

		private int[] zWinGFPthGMGBSCmywnHqKdYjvYX = new int[2];

		private int[] qNQpnMOFUlLjqOJNUtcfWCjHTqUf = new int[2];

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
				num = ((!OUxlvAeuJGkMWwKmaUdogYRNcyBq) ? ((float)(IuPWlEhfVfYNAZHjvqOrkElvMiSw - 1) * 10f) : ((float)(IuPWlEhfVfYNAZHjvqOrkElvMiSw + 2) * 10f));
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
				return (int)BwkeXklxMJgmskIcOwNnaORxjDccb;
			}
			set
			{
				BwkeXklxMJgmskIcOwNnaORxjDccb = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				lpWhAsyLKoZNzefVCnUnCUTPKsVC = true;
				if (BwkeXklxMJgmskIcOwNnaORxjDccb == 0 && pTSkPtTHZkIIsswDJsQCKzbHdvSl == 0)
				{
					xZjPNOXNhFfxMMcsuLtgmnGOAkrc = true;
				}
			}
		}

		float IDriver_DualShock4.LightFlashOffDuration
		{
			get
			{
				return (int)pTSkPtTHZkIIsswDJsQCKzbHdvSl;
			}
			set
			{
				pTSkPtTHZkIIsswDJsQCKzbHdvSl = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				lpWhAsyLKoZNzefVCnUnCUTPKsVC = true;
				if (BwkeXklxMJgmskIcOwNnaORxjDccb == 0 && pTSkPtTHZkIIsswDJsQCKzbHdvSl == 0)
				{
					xZjPNOXNhFfxMMcsuLtgmnGOAkrc = true;
				}
			}
		}

		Vector3 IDriver_DualShock4.AccelerometerValue => vDVOdYbeASKezXhYhuvSRArEBYbL(accelerometers[0].rawValue);

		Vector3 IDriver_DualShock4.AccelerometerValueRaw => new Vector3(accelerometers[0].rawValue[0], accelerometers[0].rawValue[1], accelerometers[0].rawValue[2]);

		Vector3 IDriver_DualShock4.GyroscopeValue => KpnmRxDzESaThdtVKCDJQFkeOaiS(gyroscopes[0].events);

		Vector3 IDriver_DualShock4.GyroscopeValueRaw => new Vector3(gyroscopes[0].rawValue[0], gyroscopes[0].rawValue[1], gyroscopes[0].rawValue[2]);

		Vector3 IDriver_DualShock4.LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);
				return IadEyAoKiSXgVYUfzKEITdkjtvkW(vector, CkXALNFSmfHJXlFkoxDrSwiZTHX);
			}
		}

		Vector3 IDriver_DualShock4.LastGyroscopeValueRaw => new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);

		Quaternion IDriver_DualShock4.Orientation => guWNBToZKwyuGBqANfeHBdwtPNUE;

		int IDriver_DualShock4.MaxTouches => 2;

		public void ResetOrientation()
		{
			guWNBToZKwyuGBqANfeHBdwtPNUE = Quaternion.identity;
			oeqiEBIZpWYPKvpdvHLLwZEXbkKDA = false;
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
			BwkeXklxMJgmskIcOwNnaORxjDccb = 0;
			pTSkPtTHZkIIsswDJsQCKzbHdvSl = 0;
			lpWhAsyLKoZNzefVCnUnCUTPKsVC = true;
			xZjPNOXNhFfxMMcsuLtgmnGOAkrc = true;
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
			ZTgJoLqJeMheozCccZfRFxMSuuNE = P_0.hatZeroValue;
			iXdctrcjEXOzbUpShGNfjIhRuVXwA = P_0.hatSpan;
			BPdPmXSZXYXscPthroOcbVfhEAZi = P_0.inputReportLength;
			qfrLdStLpmTyxtAjIgGoSpgvmnkN = P_0.outputReportLength;
			RNMgctCGepljmGhYThoQeioLUaVG = P_0.synchronousWriteOutputReportDelegate;
			KPUjsLwpGitUBNFHNhIUnONyllcf = P_0.asynchronousWriteOutputReportDelegate;
			ZiThhKUfGZQViCGDXWzUeAyuFgbs = P_0.getFeatureReportDelegate;
			qRAUbEeSczEYtsVurhXyCaehakfs = P_0.connectionType;
			OUxlvAeuJGkMWwKmaUdogYRNcyBq = qRAUbEeSczEYtsVurhXyCaehakfs == DeviceConnectionType.Bluetooth;
			if (OUxlvAeuJGkMWwKmaUdogYRNcyBq)
			{
				qfrLdStLpmTyxtAjIgGoSpgvmnkN = 78;
			}
			if (qfrLdStLpmTyxtAjIgGoSpgvmnkN < 23)
			{
				qfrLdStLpmTyxtAjIgGoSpgvmnkN = 23;
			}
			AXvBNPINbJUQfsQSDkmZAVMbDzvb = new NativeBuffer(64);
			wISgMiNDFynTiijsflVhahOUfeln = new NativeBuffer(qfrLdStLpmTyxtAjIgGoSpgvmnkN);
			ksjTVycWuFUubpBsBqFbsckrgqnV = new OutputReport(wISgMiNDFynTiijsflVhahOUfeln.Pointer, wISgMiNDFynTiijsflVhahOUfeln.Length, qfrLdStLpmTyxtAjIgGoSpgvmnkN);
			lights = new HIDLight[1]
			{
				new HIDLight(11, 24, 28)
			};
			lights[0].ValueChangedEvent += xXBFyOkGnTgOhfmDJEiAIaEoCKne;
			vibrationMotors = new HIDVibrationMotor[2]
			{
				new HIDVibrationMotor(0, 255),
				new HIDVibrationMotor(0, 255)
			};
			vibrationMotors[0].ValueChangedEvent += xXBFyOkGnTgOhfmDJEiAIaEoCKne;
			vibrationMotors[1].ValueChangedEvent += xXBFyOkGnTgOhfmDJEiAIaEoCKne;
			if (OUxlvAeuJGkMWwKmaUdogYRNcyBq)
			{
				ksjTVycWuFUubpBsBqFbsckrgqnV.options |= OutputReportOptions.WriteDirect;
				pTqyWeeDnehXTBZTiVgUUPkFqLnE = true;
				pTqyWeeDnehXTBZTiVgUUPkFqLnE = dOTeeqmfTHRmkjytlOEmaPyTNurU(IthEmOYLIWoAKOtZgfENDyquvbZK.Synchronous);
				if (!pTqyWeeDnehXTBZTiVgUUPkFqLnE)
				{
					ksjTVycWuFUubpBsBqFbsckrgqnV.options &= ~OutputReportOptions.WriteDirect;
				}
			}
			else
			{
				pTqyWeeDnehXTBZTiVgUUPkFqLnE = true;
				pTqyWeeDnehXTBZTiVgUUPkFqLnE = dOTeeqmfTHRmkjytlOEmaPyTNurU(IthEmOYLIWoAKOtZgfENDyquvbZK.Synchronous);
			}
			if (!pTqyWeeDnehXTBZTiVgUUPkFqLnE)
			{
				throw new Exception("Special features not supported so just treat this as a standard HID device.");
			}
			PjAKPRQcxVvWtgeSVlQHWTNbbGCO = 1;
			FbJhYDHIVEzTznwDVgWKMxJUOGYaA = 0;
			if (OUxlvAeuJGkMWwKmaUdogYRNcyBq && pTqyWeeDnehXTBZTiVgUUPkFqLnE)
			{
				PjAKPRQcxVvWtgeSVlQHWTNbbGCO = 17;
				FbJhYDHIVEzTznwDVgWKMxJUOGYaA = 2;
			}
			DtHKARgkmArAYQwsPaRdJBTsnezj = 5 + FbJhYDHIVEzTznwDVgWKMxJUOGYaA;
			ZATgPKkFkwgWBpCREKyiOkvCDSpl = 6 + FbJhYDHIVEzTznwDVgWKMxJUOGYaA;
			PHLktKtdaPcHtMUBEhcVRsTjMxwK = 7 + FbJhYDHIVEzTznwDVgWKMxJUOGYaA;
			buttons = new HIDButton[14];
			for (int i = 0; i < 14; i++)
			{
				buttons[i] = new HIDButton(PjAKPRQcxVvWtgeSVlQHWTNbbGCO, new HIDControllerElement.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new HIDAxis[6]
			{
				new HIDAxis(PjAKPRQcxVvWtgeSVlQHWTNbbGCO, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + FbJhYDHIVEzTznwDVgWKMxJUOGYaA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(PjAKPRQcxVvWtgeSVlQHWTNbbGCO, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + FbJhYDHIVEzTznwDVgWKMxJUOGYaA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(PjAKPRQcxVvWtgeSVlQHWTNbbGCO, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + FbJhYDHIVEzTznwDVgWKMxJUOGYaA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(PjAKPRQcxVvWtgeSVlQHWTNbbGCO, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + FbJhYDHIVEzTznwDVgWKMxJUOGYaA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(PjAKPRQcxVvWtgeSVlQHWTNbbGCO, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 8 + FbJhYDHIVEzTznwDVgWKMxJUOGYaA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new HIDAxis(PjAKPRQcxVvWtgeSVlQHWTNbbGCO, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 9 + FbJhYDHIVEzTznwDVgWKMxJUOGYaA,
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
				new HIDHat(PjAKPRQcxVvWtgeSVlQHWTNbbGCO, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 5 + FbJhYDHIVEzTznwDVgWKMxJUOGYaA,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, oedmHgRQSSmbVWraxwozSGfeaHyw)
			};
			accelerometers = new HIDAccelerometer[1]
			{
				new HIDAccelerometer(PjAKPRQcxVvWtgeSVlQHWTNbbGCO, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 19 + FbJhYDHIVEzTznwDVgWKMxJUOGYaA,
					bitSize = 48
				}, 3, lABwvaGbBCNeUlDPsDJpNJqJiuRh)
			};
			gyroscopes = new HIDGyroscope[1]
			{
				new HIDGyroscope(P_0.updateLoopSetting, PjAKPRQcxVvWtgeSVlQHWTNbbGCO, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 13 + FbJhYDHIVEzTznwDVgWKMxJUOGYaA,
					bitSize = 48
				}, 3, 25, mOxIuGAulmTwZaoUanBylrFZLkXm, LyYBtAkonlaqUCKqoomFUtEpPFNB)
			};
			touchpads = new HIDTouchpad[1]
			{
				new HIDTouchpad(PjAKPRQcxVvWtgeSVlQHWTNbbGCO, new HIDTouchpad.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 35 + FbJhYDHIVEzTznwDVgWKMxJUOGYaA,
					bitSize = 48
				}, rIVvHkxDnuUSbQSwLphqhFZtEVCG)
			};
			DAXmilTqvPGhVgrVwAXPlpoNqcrHA = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			OGxuHpXxhsyePvPWOujAzFtQsaCc();
			zfgpAEbozBkAOedJacqDcaSYFqFBb(IthEmOYLIWoAKOtZgfENDyquvbZK.Asynchronous);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < AXvBNPINbJUQfsQSDkmZAVMbDzvb.Length)
			{
				return false;
			}
			KuNqYYdaFKgyxeDpnOILnaDqhcJhA = (float)(timestamp - DAXmilTqvPGhVgrVwAXPlpoNqcrHA);
			DAXmilTqvPGhVgrVwAXPlpoNqcrHA = timestamp;
			AXvBNPINbJUQfsQSDkmZAVMbDzvb.Write(inputReportPtr, inputReportLength, AXvBNPINbJUQfsQSDkmZAVMbDzvb.Length);
			pZjMByuFdErlSSKDPBhRKREBTgaNA(AXvBNPINbJUQfsQSDkmZAVMbDzvb);
			nZXkrMLMBlWtGDfBTCZpEsIngOkq(AXvBNPINbJUQfsQSDkmZAVMbDzvb, timestamp);
			HIDControllerElement[] array = axes;
			DSzmUBUwnxkFMjQUKnkdHUamdNEY(array, AXvBNPINbJUQfsQSDkmZAVMbDzvb, timestamp);
			array = hats;
			DSzmUBUwnxkFMjQUKnkdHUamdNEY(array, AXvBNPINbJUQfsQSDkmZAVMbDzvb, timestamp);
			array = accelerometers;
			DSzmUBUwnxkFMjQUKnkdHUamdNEY(array, AXvBNPINbJUQfsQSDkmZAVMbDzvb, timestamp);
			array = gyroscopes;
			DSzmUBUwnxkFMjQUKnkdHUamdNEY(array, AXvBNPINbJUQfsQSDkmZAVMbDzvb, timestamp);
			array = touchpads;
			DSzmUBUwnxkFMjQUKnkdHUamdNEY(array, AXvBNPINbJUQfsQSDkmZAVMbDzvb, timestamp);
			IuPWlEhfVfYNAZHjvqOrkElvMiSw = (byte)(AXvBNPINbJUQfsQSDkmZAVMbDzvb[30 + FbJhYDHIVEzTznwDVgWKMxJUOGYaA] & 0xF);
			RqgAYUxBGlRWbjMlvDFWpvZJffPr();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualShock4Extension(this);
		}

		private void zfgpAEbozBkAOedJacqDcaSYFqFBb(IthEmOYLIWoAKOtZgfENDyquvbZK P_0)
		{
			if (lpWhAsyLKoZNzefVCnUnCUTPKsVC)
			{
				dOTeeqmfTHRmkjytlOEmaPyTNurU(P_0);
				lpWhAsyLKoZNzefVCnUnCUTPKsVC = false;
			}
		}

		private bool dOTeeqmfTHRmkjytlOEmaPyTNurU(IthEmOYLIWoAKOtZgfENDyquvbZK P_0)
		{
			CJWqtdoMQxtlVtFwdPrEChYVTZrD();
			bool result = qcelQPplVjGwQHdHZyubWfWDcQxX(P_0);
			if (xZjPNOXNhFfxMMcsuLtgmnGOAkrc)
			{
				result = qcelQPplVjGwQHdHZyubWfWDcQxX(P_0);
				xZjPNOXNhFfxMMcsuLtgmnGOAkrc = false;
			}
			return result;
		}

		private void CJWqtdoMQxtlVtFwdPrEChYVTZrD()
		{
			if (OUxlvAeuJGkMWwKmaUdogYRNcyBq && pTqyWeeDnehXTBZTiVgUUPkFqLnE)
			{
				wISgMiNDFynTiijsflVhahOUfeln[0] = 17;
				wISgMiNDFynTiijsflVhahOUfeln[1] = 128;
				wISgMiNDFynTiijsflVhahOUfeln[3] = byte.MaxValue;
				wISgMiNDFynTiijsflVhahOUfeln[6] = (byte)vibrationMotors[1].SpeedRaw;
				wISgMiNDFynTiijsflVhahOUfeln[7] = (byte)vibrationMotors[0].SpeedRaw;
				wISgMiNDFynTiijsflVhahOUfeln[8] = lights[0].ColorRRaw;
				wISgMiNDFynTiijsflVhahOUfeln[9] = lights[0].ColorGRaw;
				wISgMiNDFynTiijsflVhahOUfeln[10] = lights[0].ColorBRaw;
				wISgMiNDFynTiijsflVhahOUfeln[11] = BwkeXklxMJgmskIcOwNnaORxjDccb;
				wISgMiNDFynTiijsflVhahOUfeln[12] = pTSkPtTHZkIIsswDJsQCKzbHdvSl;
				wISgMiNDFynTiijsflVhahOUfeln[21] = 53;
				wISgMiNDFynTiijsflVhahOUfeln[22] = 53;
				wISgMiNDFynTiijsflVhahOUfeln[23] = byte.MaxValue;
				wISgMiNDFynTiijsflVhahOUfeln[24] = 0;
			}
			else
			{
				wISgMiNDFynTiijsflVhahOUfeln[0] = 5;
				wISgMiNDFynTiijsflVhahOUfeln[1] = byte.MaxValue;
				wISgMiNDFynTiijsflVhahOUfeln[4] = (byte)vibrationMotors[1].SpeedRaw;
				wISgMiNDFynTiijsflVhahOUfeln[5] = (byte)vibrationMotors[0].SpeedRaw;
				wISgMiNDFynTiijsflVhahOUfeln[6] = lights[0].ColorRRaw;
				wISgMiNDFynTiijsflVhahOUfeln[7] = lights[0].ColorGRaw;
				wISgMiNDFynTiijsflVhahOUfeln[8] = lights[0].ColorBRaw;
				wISgMiNDFynTiijsflVhahOUfeln[9] = BwkeXklxMJgmskIcOwNnaORxjDccb;
				wISgMiNDFynTiijsflVhahOUfeln[10] = pTSkPtTHZkIIsswDJsQCKzbHdvSl;
				wISgMiNDFynTiijsflVhahOUfeln[19] = 53;
				wISgMiNDFynTiijsflVhahOUfeln[20] = 53;
				wISgMiNDFynTiijsflVhahOUfeln[21] = byte.MaxValue;
				wISgMiNDFynTiijsflVhahOUfeln[22] = 0;
			}
		}

		private bool qcelQPplVjGwQHdHZyubWfWDcQxX(IthEmOYLIWoAKOtZgfENDyquvbZK P_0)
		{
			PEeGxXzNSqOLhjKOjErLkwNsMaYwA = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case IthEmOYLIWoAKOtZgfENDyquvbZK.Synchronous:
				if (RNMgctCGepljmGhYThoQeioLUaVG == null)
				{
					return false;
				}
				return RNMgctCGepljmGhYThoQeioLUaVG(ksjTVycWuFUubpBsBqFbsckrgqnV);
			case IthEmOYLIWoAKOtZgfENDyquvbZK.Asynchronous:
				if (KPUjsLwpGitUBNFHNhIUnONyllcf == null)
				{
					return false;
				}
				KPUjsLwpGitUBNFHNhIUnONyllcf(ksjTVycWuFUubpBsBqFbsckrgqnV);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void nZXkrMLMBlWtGDfBTCZpEsIngOkq(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[DtHKARgkmArAYQwsPaRdJBTsnezj];
			buttons[0].SetValue((b & 0x10) != 0, P_1);
			buttons[1].SetValue((b & 0x20) != 0, P_1);
			buttons[2].SetValue((b & 0x40) != 0, P_1);
			buttons[3].SetValue((b & 0x80) != 0, P_1);
			b = P_0[ZATgPKkFkwgWBpCREKyiOkvCDSpl];
			buttons[4].SetValue((b & 1) != 0, P_1);
			buttons[5].SetValue((b & 2) != 0, P_1);
			buttons[6].SetValue((b & 4) != 0, P_1);
			buttons[7].SetValue((b & 8) != 0, P_1);
			buttons[8].SetValue((b & 0x10) != 0, P_1);
			buttons[9].SetValue((b & 0x20) != 0, P_1);
			buttons[10].SetValue((b & 0x40) != 0, P_1);
			buttons[11].SetValue((b & 0x80) != 0, P_1);
			b = P_0[PHLktKtdaPcHtMUBEhcVRsTjMxwK];
			buttons[12].SetValue((b & 1) != 0, P_1);
			buttons[13].SetValue((b & 2) != 0, P_1);
		}

		private void DSzmUBUwnxkFMjQUKnkdHUamdNEY(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].UpdateValue(P_1, P_2);
			}
		}

		private void OGxuHpXxhsyePvPWOujAzFtQsaCc()
		{
			if (isVibrating && ReInput.realTime >= PEeGxXzNSqOLhjKOjErLkwNsMaYwA)
			{
				lpWhAsyLKoZNzefVCnUnCUTPKsVC = true;
			}
		}

		private void pZjMByuFdErlSSKDPBhRKREBTgaNA(NativeBuffer P_0)
		{
			if (pTqyWeeDnehXTBZTiVgUUPkFqLnE)
			{
				ushort num = AXvBNPINbJUQfsQSDkmZAVMbDzvb.ReadUShort(10 + FbJhYDHIVEzTznwDVgWKMxJUOGYaA);
				float ckXALNFSmfHJXlFkoxDrSwiZTHX;
				if (num != PmAMicutEasVJkGSaEUvhzeIrHGK)
				{
					int num2 = ((num >= PmAMicutEasVJkGSaEUvhzeIrHGK) ? (num - PmAMicutEasVJkGSaEUvhzeIrHGK) : (num + 65535 - PmAMicutEasVJkGSaEUvhzeIrHGK));
					ckXALNFSmfHJXlFkoxDrSwiZTHX = (float)num2 / 187500f;
				}
				else
				{
					int num2 = 0;
					ckXALNFSmfHJXlFkoxDrSwiZTHX = 0f;
				}
				PmAMicutEasVJkGSaEUvhzeIrHGK = num;
				CkXALNFSmfHJXlFkoxDrSwiZTHX = ckXALNFSmfHJXlFkoxDrSwiZTHX;
			}
		}

		private void RqgAYUxBGlRWbjMlvDFWpvZJffPr()
		{
			if (pTqyWeeDnehXTBZTiVgUUPkFqLnE)
			{
				_ = CkXALNFSmfHJXlFkoxDrSwiZTHX;
				_ = 0f;
				Vector3 vector = IadEyAoKiSXgVYUfzKEITdkjtvkW(new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]), CkXALNFSmfHJXlFkoxDrSwiZTHX);
				ATCJMISnDKYQLGeHyyICZjyvNKnc(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].rawValue[0] * -1f, accelerometers[0].rawValue[1] * -1f, accelerometers[0].rawValue[2] * -1f);
				YQpnJlffVzDylnOqAjIBjyCpfPrH(vector2, vector);
			}
		}

		private static bool ATCJMISnDKYQLGeHyyICZjyvNKnc(ref Vector3 P_0)
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

		private void YQpnJlffVzDylnOqAjIBjyCpfPrH(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && jdjftVDpEZHJwiLCgjwMkIKMCrXC(P_0, out var drEqiHvpDEsPEDRgehfBaeLpkbaA))
			{
				Quaternion a = guWNBToZKwyuGBqANfeHBdwtPNUE * quaternion;
				if (!oeqiEBIZpWYPKvpdvHLLwZEXbkKDA)
				{
					oeqiEBIZpWYPKvpdvHLLwZEXbkKDA = true;
					LEBWDBfXWLUinrbvNeFvwivyeAYM = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					DYBrNymEIIUbMAOGacRkxGMfrkBF = guWNBToZKwyuGBqANfeHBdwtPNUE;
				}
				LEBWDBfXWLUinrbvNeFvwivyeAYM *= quaternion;
				DYBrNymEIIUbMAOGacRkxGMfrkBF *= quaternion;
				Quaternion b;
				if ((drEqiHvpDEsPEDRgehfBaeLpkbaA & IDrEqiHvpDEsPEDRgehfBaeLpkbaA.XZ) != IDrEqiHvpDEsPEDRgehfBaeLpkbaA.None)
				{
					b = NcEggedgTkyCofaNwGQYhcfiwlxaA(P_0, a.eulerAngles.y);
				}
				else if ((drEqiHvpDEsPEDRgehfBaeLpkbaA & IDrEqiHvpDEsPEDRgehfBaeLpkbaA.Y) != IDrEqiHvpDEsPEDRgehfBaeLpkbaA.None)
				{
					b = RgAelFdlwtOUppyxldRdVVTPbUclA(P_0);
					Vector3 vector = DYBrNymEIIUbMAOGacRkxGMfrkBF * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				guWNBToZKwyuGBqANfeHBdwtPNUE = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				guWNBToZKwyuGBqANfeHBdwtPNUE *= quaternion;
				if (oeqiEBIZpWYPKvpdvHLLwZEXbkKDA)
				{
					oeqiEBIZpWYPKvpdvHLLwZEXbkKDA = false;
				}
			}
		}

		private static Quaternion ARuOFuYKKLgLMaFzQwdXTKbnPMtn(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = xBpyYJPBqjJSJUjmxZcMhtLDhHoQ(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 xBpyYJPBqjJSJUjmxZcMhtLDhHoQ(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion kbXHbkcvVeloISYNfzkSxBZopItS(Quaternion P_0, MMIAPStqLUVOKyMFUcIPvGVxWSwG P_1)
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

		private float FbpIjseheVfjhqtaJqYaGURarhHTA(float P_0, float P_1)
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

		private Vector3 bPLHjeFdLidYKZHMUEFddUhZoKOTA(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion NcEggedgTkyCofaNwGQYhcfiwlxaA(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion RgAelFdlwtOUppyxldRdVVTPbUclA(Vector3 P_0, float P_1 = 0f)
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

		private float efIBwZTSSTKdPMGlajjUtrjZGKeeA(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool yUgkwRXUZoVMgHuiBMMKzFImmyRJ(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool jdjftVDpEZHJwiLCgjwMkIKMCrXC(Vector3 P_0, out IDrEqiHvpDEsPEDRgehfBaeLpkbaA P_1)
		{
			P_0.Normalize();
			P_1 = IDrEqiHvpDEsPEDRgehfBaeLpkbaA.None;
			bool result = false;
			if (cwnQtEfaYRAPaJiedpnFXkdqXmVZ(P_0))
			{
				result = true;
				P_1 |= IDrEqiHvpDEsPEDRgehfBaeLpkbaA.XZ;
			}
			if (pAIfQXhHEKNWiGyoqVgeyhtackMo(P_0))
			{
				result = true;
				P_1 |= IDrEqiHvpDEsPEDRgehfBaeLpkbaA.Y;
			}
			return result;
		}

		private bool cwnQtEfaYRAPaJiedpnFXkdqXmVZ(Vector3 P_0)
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

		private bool pAIfQXhHEKNWiGyoqVgeyhtackMo(Vector3 P_0)
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

		private Vector3 vDVOdYbeASKezXhYhuvSRArEBYbL(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 KpnmRxDzESaThdtVKCDJQFkeOaiS(ExpandableArray_DataContainer<HIDGyroscope.GiuyxAjgsLMZoyJQQDMOmNkokChH> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				HIDGyroscope.GiuyxAjgsLMZoyJQQDMOmNkokChH giuyxAjgsLMZoyJQQDMOmNkokChH = P_0[i];
				result += IadEyAoKiSXgVYUfzKEITdkjtvkW(giuyxAjgsLMZoyJQQDMOmNkokChH.cWevxravOZkFimTGMKQZfvGPQDgd, giuyxAjgsLMZoyJQQDMOmNkokChH.EUSnZeZyQsAWYltoKOVynUanzgdH);
			}
			return result;
		}

		private Vector3 IadEyAoKiSXgVYUfzKEITdkjtvkW(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int oedmHgRQSSmbVWraxwozSGfeaHyw(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void lABwvaGbBCNeUlDPsDJpNJqJiuRh(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void mOxIuGAulmTwZaoUanBylrFZLkXm(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float LyYBtAkonlaqUCKqoomFUtEpPFNB()
		{
			return CkXALNFSmfHJXlFkoxDrSwiZTHX;
		}

		private void rIVvHkxDnuUSbQSwLphqhFZtEVCG(NativeBuffer P_0, HIDTouchpad.TouchData[] P_1)
		{
			int num = 35 + FbJhYDHIVEzTznwDVgWKMxJUOGYaA;
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
			P_1[0].touchId = ybnSNFlojBYWzuFNbqHAbGhlpDkF(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = ybnSNFlojBYWzuFNbqHAbGhlpDkF(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int ybnSNFlojBYWzuFNbqHAbGhlpDkF(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				zWinGFPthGMGBSCmywnHqKdYjvYX[P_0] = -1;
				qNQpnMOFUlLjqOJNUtcfWCjHTqUf[P_0] = P_2;
				return -1;
			}
			if (P_2 != qNQpnMOFUlLjqOJNUtcfWCjHTqUf[P_0])
			{
				int edVAkKYqdzXdsIoMoZEheqMUANjq = EdVAkKYqdzXdsIoMoZEheqMUANjq;
				if (EdVAkKYqdzXdsIoMoZEheqMUANjq == int.MaxValue)
				{
					EdVAkKYqdzXdsIoMoZEheqMUANjq = 0;
				}
				else
				{
					EdVAkKYqdzXdsIoMoZEheqMUANjq++;
				}
				qNQpnMOFUlLjqOJNUtcfWCjHTqUf[P_0] = P_2;
				zWinGFPthGMGBSCmywnHqKdYjvYX[P_0] = edVAkKYqdzXdsIoMoZEheqMUANjq;
				return edVAkKYqdzXdsIoMoZEheqMUANjq;
			}
			return zWinGFPthGMGBSCmywnHqKdYjvYX[P_0];
		}

		private void xXBFyOkGnTgOhfmDJEiAIaEoCKne()
		{
			lpWhAsyLKoZNzefVCnUnCUTPKsVC = true;
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
				zfgpAEbozBkAOedJacqDcaSYFqFBb(IthEmOYLIWoAKOtZgfENDyquvbZK.Synchronous);
				if (AXvBNPINbJUQfsQSDkmZAVMbDzvb != null)
				{
					AXvBNPINbJUQfsQSDkmZAVMbDzvb.Dispose();
				}
				if (wISgMiNDFynTiijsflVhahOUfeln != null)
				{
					wISgMiNDFynTiijsflVhahOUfeln.Dispose();
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
