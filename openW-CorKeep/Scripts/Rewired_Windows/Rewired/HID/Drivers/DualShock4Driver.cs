using System;
using System.Diagnostics;
using Rewired.ControllerExtensions;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualShock4Driver : HIDDeviceDriver, IDriver_DualShock4, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		private enum NGuFbeAlAkShcBAsxPiSxgPYyDHpA
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum HoNZqYBfovUxrcucXxMohxcgfiKm
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private static class LFtZljwOSdxaEGdTzXewVrJXDKBl
		{
			private const uint LitSQJqHTkQxlFaIfnSHNutFRRiM = 3988292384u;

			public unsafe static uint LjgniRQzpUhtoCchFquUnOJEZoeI(byte* P_0, int P_1, uint P_2)
			{
				return ~nLIvKIAPOJomNLSBkhsYdjMJttyf(nLIvKIAPOJomNLSBkhsYdjMJttyf(uint.MaxValue, (byte*)(&P_2), 1, 3988292384u), P_0, P_1, 3988292384u);
			}

			public unsafe static uint LQJtHwyUsnULczsHloyNgVSNgVk(uint P_0, byte* P_1, int P_2)
			{
				return nLIvKIAPOJomNLSBkhsYdjMJttyf(P_0, P_1, P_2, 3988292384u);
			}

			private unsafe static uint nLIvKIAPOJomNLSBkhsYdjMJttyf(uint P_0, byte* P_1, int P_2, uint P_3)
			{
				for (int i = 0; i < P_2; i++)
				{
					P_0 ^= P_1[i];
					for (int j = 0; j < 8; j++)
					{
						P_0 = (P_0 >> 1) ^ (((P_0 & 1) != 0) ? P_3 : 0);
					}
				}
				return P_0;
			}
		}

		private enum zxCbZRqqtmmWKNqbwvWQdMNZlYXK
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			Unknown = 3
		}

		private const float DylWEPGFZWRtLrbVkVbJshpSSVws = 4f;

		private const int TCATpPgavCRiKILLRBAFSChfuLfQ = 14;

		private const int CcgtZeNvkzkmaeKTjyaovsLSQQJM = 2;

		private const int vtkwGBgEGByLNMADqKJyVZoTNQhT = 0;

		private const int grFXgvCCtEszzixZTohIYuBELfKK = 1912;

		private const int ZlbDzzZsHHYOdiFxuhJfukNxiGoi = 0;

		private const int GpHGIVSZDMlUZHHQPKEKJfAOANJGA = 941;

		private const bool xonzYaLuYapFaYrPqdHDNAhJnIrB = false;

		private const bool VmWLGTYNAxCHQKnlEXNAIezGIZTsA = true;

		private const float fcgDhtLjJjHMwkURatUWPYdlFMDGb = 2.5f;

		private const int QIaJJtVOGMaIoeQahjhdkXGIKYLBA = 0;

		private const int VfPTJirrqNuraECXqxEQemeghMkcA = 0;

		private const int dQEYNCZvtSDSncdjqsslpqlBBErEA = 1;

		private const int ZrLNkBZGsqnEqetyUbAdnSzaTuYL = 0;

		private const int loKdGmNHHtTGbPgiLcwJLfxwVSYp = 0;

		private const int qhhFNIAYERmLWhuNLhcUGqJgyrNVA = 0;

		private const int ikwvDCAhvgZQGqQEEkYLUOKycrBG = 1;

		private const int nmbjapsfAyYvGySxXqvtVNkrWwUF = 17;

		private const int dssbWznMsKFrmXvCfEygbhiRCEPF = 0;

		private const int OpkilyYTiIqMoStnBEekVAYACawl = 2;

		private const int hVxeUHenDvwQNlSWXrLdxafAOSOS = 64;

		private const int IvkYcvIJMglMiNWMYwdWhBcVMmyC = 78;

		private const byte mDxsjqzdLRhceVfSHGbiHBjfzsBm = 17;

		private const byte QordoirtDIjrfUcWXKuYDlMmAtrg = 5;

		private const byte elFrxpMtraVvOtcXUCIOalxghyieA = 2;

		private const byte vQdIyniXwVgNoUwdIkSDcGDjJyil = 37;

		private const byte RUJYzVoOZkZGFBEzzzaezAVRfjXQ = 5;

		private const byte SJoFgaCEocZSgUKnrehavEmVrsOx = 41;

		private const byte qTlPJufMGVYuBFDGPPrbrksIvpFw = 163;

		private const byte fkRAZcXyqWesaTNiUuqceQWpRVDw = 49;

		private const byte MVltGdlGuEDFZbxRdxAdvuSxeyPlA = 18;

		private const byte fSUGYsCdYkeRqYrnnLxNZMDwooCNA = 16;

		private const byte GBZLLFRJgzbulFuCYhSUYjKvlRxx = 161;

		private const byte yXGFHwJjjHxYvifBbLFlDiEDqGeBA = 162;

		private const byte NXTPrGPAnkPWlCJZmkuePZNoardW = 163;

		private const int UQCfAAeZQYXlJKoehlImwcMgLScC = 1;

		private const int LwPoZUMbdCNTazGowIwiNvAwMIZx = 2;

		private const int SjkFlOKHAVcXIfOMwcTaBBsSihcY = 3;

		private const int xkSXxbsZOeQswrVnqAyLQjAUjeRU = 4;

		private const int HONQMTdGAPvvUoyAVXTHoHSTZgEg = 8;

		private const int pbifSaArguzFDgkanDDjhKBBpPDlA = 9;

		private const int vnXnVIvRpyVSHamuRBcmujqYphFg = 5;

		private const int xoxQysEwiXVGZRvqrFwrepOhkThb = 19;

		private const int IUHzHfkkxNcabjjMjtYtjaSfoKcNA = 13;

		private const int CigfNQGwOxHqdGmoVtmvkiwYjZvZA = 35;

		private const int hmzFbRnntDchaZIfxdswEaCpSgyPA = 5;

		private const int ZrnknToJbphpZhINwgRzPLhUEDfib = 6;

		private const int UuKaBHdtJCTDzFnhoiYIcNtbyzviA = 7;

		private const int AqfAPSQCVnZeNGADvjygIuRBudFi = 10;

		private const int OCIBdfsLbcdlDBkAsQdvikcDBMBIc = 30;

		private const int JzDGgDibPMCTsAMGLYAAhvVHQPdPA = 27;

		private const byte VYCxuqZjCzCXPJUOuklLRbwrJSgw = 200;

		private const byte GZBmgDucAnkzElyxvokjDNsRWYmn = 53;

		private const byte LAjdEgbRSYqgnFvqirbXxJAvprqmB = byte.MaxValue;

		private const byte NHUwpVhUfDIzITRciLOsFeJRKiRu = 0;

		private const bool JDnKiyrVJRVGAKDssfUcqieSQTEl = true;

		private const int XbVeczvMmVkNOFDACCDHBQnArkwrA = 60;

		private const int VPElFqRizjvKoCfVvbbwdyCgHmCS = 60;

		private const int rgqhBQqYgGqJkdgwEFQTAUGgTvOg = 187500;

		private const float iAsQpciBjgWLVSteQnsEpPJflQWy = 8192f;

		private const float LjRaGSSTquFWddMEWcnngITJJpSjc = 0.0010652969f;

		private const float gzKoHfQulFuQoBPjmhmFlCMBcrrZ = 0.06103702f;

		private const bool uDsiONWzgkMghORVjVNiMavvTSaG = true;

		private const bool auZDMHrxTNHysvCidEdLKJFpqAzj = true;

		private const bool VvhBMapcQgGLFubijBtaRRzzZcUG = true;

		private const bool lfbZuaIXvUAhcgMPFmHkKiXsBrCX = true;

		private const float ZjXQfLNszlSeTzAfQERDHDrcKxEI = 4096f;

		private const float kOGooIFfrgivbRGarSkWBoIrHsDE = 16384f;

		private const float TxmwmyyWqtTYdSThCovAvqJaxByO = 16777216f;

		private const float FAzBqoMUnkhukEBNDBgqMtzClksAb = 268435460f;

		private const float oGHmzTylewltFbtXLnOaRjmYexXQ = 0.01999998f;

		private const float GpgkgJyYkSChAxxFdPvhBSnluizw = 8192f;

		private const float kjFniklMEOLeJWxuSZSOSugDbvld = 0.98f;

		private const float mQIBsUjyEhoVqdWEYdHolSqoxUwlA = 45f;

		private const float zzBJgZLSsOaQfzrfBdfzkXyNnROfA = 20f;

		private readonly IHIDDevice CWbWFAHuAdKSkqCoKGFgBFfQtUQKA;

		private readonly HIDProperties qzcqxsvOdvKtvPDchdSXJviDIykLA;

		private readonly bool LRPKAiiAziutaCDILjOdlTBulxiE;

		private readonly gQgddHFyNfVGfPIXZPBcuigOMkbz vCuFOwupbXAwZDYXEGttCBuWIdQXA;

		private readonly int QXWKyAiDWecZQdFbDkZAoEtfbfabb;

		private readonly int dxVOdVvfNdiVJLVtEjFcFyxaDSit;

		private readonly bool cWMKHGmqMGgFlzIuJERVeLXwXrGTA;

		private readonly byte YGmqfnQDafkZTUGduMKWJzJATonI;

		private readonly int UtbjwpYJKgfhHULakGUDufZzLVzI;

		private readonly int UEhGzvqolsrVcuxPkhmeCpVDkuYX;

		private readonly int OplHRmaRfGQChJwelTKhFWzrESEr;

		private readonly int WHjXTmxOzpVjXstgnpiUWSZCNRBM;

		private readonly NativeBuffer ZNZNonYqKrLsmUSdiIqdRVRKEICt;

		private readonly NativeBuffer lLoYVSTQKILJSWDNIGdghdQnSvEeA;

		private readonly MwEMUNdEdQpngdbXMtjwIdOvEFgfA xhZVaAiKhhZyJTIRcLqchtgSjpYq;

		private readonly byte[] UtIFfzFpRZsIWnlPLjSHzlAjRjaqA = new byte[1] { 162 };

		private bool mIolQKeSYQbvLAfWrDhyTVUqFVyp;

		private bool uqXnaxFKEdSDPmxPRSHutldpmVHP;

		private double WSOOyjnDkExcDZEpCdREdEZNjpzG;

		private int LBzaEwxBYXJdefGUAbKkIzzAazzoA;

		private zxCbZRqqtmmWKNqbwvWQdMNZlYXK zUEsTuRZxPwGtsHVxLCCIsWIOGyg = zxCbZRqqtmmWKNqbwvWQdMNZlYXK.Unknown;

		private Quaternion bXemivkxYCqAYjSVuqlIGMpAvOjv = Quaternion.identity;

		private ushort ILiJiOgPUEWphOnDRACoyIkxcKvH;

		private float VyAolrNzNCmlnBhgXflAGimNnYaDA;

		private double SKnBqLJmRnXvbHwYZPEKicqmlfAh;

		private float FpbKkblYmKhLGvKOCUIapNJbXiH;

		private bool mDAHbNhxFwgqMwcidFENQaPkrRhWA;

		private bool fSBmSkviGQhaTViJYpNhwyawaNB;

		private bool HjDhneCOJpSPcAQilaJzvraEpYFVA;

		private bool EAtcMDBRwwDmwtoMcVSucXYQyWjgA;

		private byte OEGurMjmRvMLUqfPzJXkHKNWLEDX;

		private byte eewaTRNODAeLOIgEaCPZVvNemotE;

		private Quaternion EqlauxxVTtlsBXZAwFLeddnVERtDA = Quaternion.identity;

		private Quaternion EoveIGygDgrkueVpPUspgKYIyscU = Quaternion.identity;

		private bool lpIzAjRPeitdyNLAGLMOUdGmfrdg;

		private int PSlxNcEQoZBTKehjPHKsrvEnrSCw;

		private int[] aUQrJbRoZycRtqRPVdkMpzkdmydE = new int[2];

		private int[] rDaLYuKvKJzhEuwqznImBejgYgli = new int[2];

		private bool isVibrating
		{
			get
			{
				for (int i = 0; i < base.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EVibrationMotorCount; i++)
				{
					if (vibrationMotors[i].rXanWTxGcklOZyeDGcMFZMCGBbhL > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		float IDriver_DualShock4.BatteryLevel => LBzaEwxBYXJdefGUAbKkIzzAazzoA;

		bool IDriver_DualShock4.BatteryCharging => zUEsTuRZxPwGtsHVxLCCIsWIOGyg == zxCbZRqqtmmWKNqbwvWQdMNZlYXK.Charging;

		float IDriver_DualShock4.LeftMotor
		{
			get
			{
				return vibrationMotors[0].kebuKyNPnNUAwnkFlyJfDbfeAhBW;
			}
			set
			{
				vibrationMotors[0].kebuKyNPnNUAwnkFlyJfDbfeAhBW = value;
			}
		}

		float IDriver_DualShock4.RightMotor
		{
			get
			{
				return vibrationMotors[1].kebuKyNPnNUAwnkFlyJfDbfeAhBW;
			}
			set
			{
				vibrationMotors[1].kebuKyNPnNUAwnkFlyJfDbfeAhBW = value;
			}
		}

		float IDriver_DualShock4.LightColorR
		{
			get
			{
				return lights[0].OYKivTjERXZRaQCccSXNqDmvhGKCA;
			}
			set
			{
				lights[0].OYKivTjERXZRaQCccSXNqDmvhGKCA = value;
			}
		}

		float IDriver_DualShock4.LightColorG
		{
			get
			{
				return lights[0].TfziCEmzXhXLDQWicRELpXxNVlrg;
			}
			set
			{
				lights[0].TfziCEmzXhXLDQWicRELpXxNVlrg = value;
			}
		}

		float IDriver_DualShock4.LightColorB
		{
			get
			{
				return lights[0].xOpRkCySihaekhawqhWWFspcFMSF;
			}
			set
			{
				lights[0].xOpRkCySihaekhawqhWWFspcFMSF = value;
			}
		}

		float IDriver_DualShock4.LightFlashOnDuration
		{
			get
			{
				return (int)OEGurMjmRvMLUqfPzJXkHKNWLEDX;
			}
			set
			{
				OEGurMjmRvMLUqfPzJXkHKNWLEDX = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				DsstyHneeFCAjCnYbgNaTjnnrDZI();
				if (OEGurMjmRvMLUqfPzJXkHKNWLEDX == 0 && eewaTRNODAeLOIgEaCPZVvNemotE == 0)
				{
					uqXnaxFKEdSDPmxPRSHutldpmVHP = true;
				}
			}
		}

		float IDriver_DualShock4.LightFlashOffDuration
		{
			get
			{
				return (int)eewaTRNODAeLOIgEaCPZVvNemotE;
			}
			set
			{
				eewaTRNODAeLOIgEaCPZVvNemotE = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				DsstyHneeFCAjCnYbgNaTjnnrDZI();
				if (OEGurMjmRvMLUqfPzJXkHKNWLEDX == 0 && eewaTRNODAeLOIgEaCPZVvNemotE == 0)
				{
					uqXnaxFKEdSDPmxPRSHutldpmVHP = true;
				}
			}
		}

		Vector3 IDriver_DualShock4.AccelerometerValue => aKbEtaDnVwqMFhphAMwNJItPjLKCB(accelerometers[0].idaOHKBnMGIFbSErnXWBOkCLqsFq);

		Vector3 IDriver_DualShock4.AccelerometerValueRaw => new Vector3(accelerometers[0].idaOHKBnMGIFbSErnXWBOkCLqsFq[0], accelerometers[0].idaOHKBnMGIFbSErnXWBOkCLqsFq[1], accelerometers[0].idaOHKBnMGIFbSErnXWBOkCLqsFq[2]);

		Vector3 IDriver_DualShock4.GyroscopeValue => wxRvSjCVdHIlKqadmNvJDSLBudUf(gyroscopes[0].WCqcHNKNqnqvyfzphQRNHzkUYjOs);

		Vector3 IDriver_DualShock4.GyroscopeValueRaw => new Vector3(gyroscopes[0].wXaANDSmoAgGvfdyOuMHrJOabbtz[0], gyroscopes[0].wXaANDSmoAgGvfdyOuMHrJOabbtz[1], gyroscopes[0].wXaANDSmoAgGvfdyOuMHrJOabbtz[2]);

		Vector3 IDriver_DualShock4.LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[0], gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[1], gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[2]);
				return LVZTRaomhgSMpeBUUEoXKxgAoHNK(vector, VyAolrNzNCmlnBhgXflAGimNnYaDA);
			}
		}

		Vector3 IDriver_DualShock4.LastGyroscopeValueRaw => new Vector3(gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[0], gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[1], gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[2]);

		Quaternion IDriver_DualShock4.Orientation => bXemivkxYCqAYjSVuqlIGMpAvOjv;

		int IDriver_DualShock4.MaxTouches => 2;

		ushort IHIDControllerExtension.vendorId => qzcqxsvOdvKtvPDchdSXJviDIykLA.vendorId;

		ushort IHIDControllerExtension.productId => qzcqxsvOdvKtvPDchdSXJviDIykLA.productId;

		string IHIDControllerExtension.productName => qzcqxsvOdvKtvPDchdSXJviDIykLA.productName;

		string IHIDControllerExtension.manufacturer => qzcqxsvOdvKtvPDchdSXJviDIykLA.manufacturer;

		ushort IHIDControllerExtension.usagePage => qzcqxsvOdvKtvPDchdSXJviDIykLA.usagePage;

		ushort IHIDControllerExtension.usage => qzcqxsvOdvKtvPDchdSXJviDIykLA.usage;

		public void ResetOrientation()
		{
			bXemivkxYCqAYjSVuqlIGMpAvOjv = Quaternion.identity;
			lpIzAjRPeitdyNLAGLMOUdGmfrdg = false;
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
				if (touchpads[0].iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].isTouching)
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
			return touchpads[0].iVNpVhZhCmFMvyxmNYTLNjsnDNML[index].isTouching;
		}

		bool IDriver_DualShock4.IsTouchingAtIndex(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtIndex
			return this.IsTouchingAtIndex(index);
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return touchpads[0].tMXqrOzATSzAqZvTXLlZBoUVnLGs(touchId);
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
			return touchpads[0].iVNpVhZhCmFMvyxmNYTLNjsnDNML[index].touchId;
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
			hwDBnDzZlOwqwaLOCXGWdEQuXFFf.TouchData[] iVNpVhZhCmFMvyxmNYTLNjsnDNML = touchpads[0].iVNpVhZhCmFMvyxmNYTLNjsnDNML;
			if (!iVNpVhZhCmFMvyxmNYTLNjsnDNML[index].isTouching)
			{
				return false;
			}
			position.x = iVNpVhZhCmFMvyxmNYTLNjsnDNML[index].positionX;
			position.y = iVNpVhZhCmFMvyxmNYTLNjsnDNML[index].positionY;
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
			if (!touchpads[0].tMXqrOzATSzAqZvTXLlZBoUVnLGs(touchId))
			{
				return false;
			}
			hwDBnDzZlOwqwaLOCXGWdEQuXFFf.TouchData[] iVNpVhZhCmFMvyxmNYTLNjsnDNML = touchpads[0].iVNpVhZhCmFMvyxmNYTLNjsnDNML;
			for (int i = 0; i < iVNpVhZhCmFMvyxmNYTLNjsnDNML.Length; i++)
			{
				if (iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].isTouching)
				{
					position.x = iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].positionX;
					position.y = iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].positionY;
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
			hwDBnDzZlOwqwaLOCXGWdEQuXFFf.TouchData[] iVNpVhZhCmFMvyxmNYTLNjsnDNML = touchpads[0].iVNpVhZhCmFMvyxmNYTLNjsnDNML;
			if (!iVNpVhZhCmFMvyxmNYTLNjsnDNML[index].isTouching)
			{
				return false;
			}
			positionX = iVNpVhZhCmFMvyxmNYTLNjsnDNML[index].positionAbsX;
			positionY = iVNpVhZhCmFMvyxmNYTLNjsnDNML[index].positionAbsY;
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
			if (!touchpads[0].tMXqrOzATSzAqZvTXLlZBoUVnLGs(touchId))
			{
				return false;
			}
			hwDBnDzZlOwqwaLOCXGWdEQuXFFf.TouchData[] iVNpVhZhCmFMvyxmNYTLNjsnDNML = touchpads[0].iVNpVhZhCmFMvyxmNYTLNjsnDNML;
			for (int i = 0; i < iVNpVhZhCmFMvyxmNYTLNjsnDNML.Length; i++)
			{
				if (iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].isTouching)
				{
					positionX = iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].positionAbsX;
					positionY = iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].positionAbsY;
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
			OEGurMjmRvMLUqfPzJXkHKNWLEDX = 0;
			eewaTRNODAeLOIgEaCPZVvNemotE = 0;
			mIolQKeSYQbvLAfWrDhyTVUqFVyp = true;
			uqXnaxFKEdSDPmxPRSHutldpmVHP = true;
			HjDhneCOJpSPcAQilaJzvraEpYFVA = true;
		}

		void IDriver_DualShock4.StopLightFlash()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopLightFlash
			this.StopLightFlash();
		}

		public void StopVibration()
		{
			int num = base.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EVibrationMotorCount;
			for (int i = 0; i < num; i++)
			{
				vibrationMotors[i].rXanWTxGcklOZyeDGcMFZMCGBbhL = 0;
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
			CWbWFAHuAdKSkqCoKGFgBFfQtUQKA = P_0.hidDevice;
			qzcqxsvOdvKtvPDchdSXJviDIykLA = CWbWFAHuAdKSkqCoKGFgBFfQtUQKA.properties;
			QXWKyAiDWecZQdFbDkZAoEtfbfabb = P_0.hatZeroValue;
			dxVOdVvfNdiVJLVtEjFcFyxaDSit = P_0.hatSpan;
			vCuFOwupbXAwZDYXEGttCBuWIdQXA = P_0.connectionType;
			LRPKAiiAziutaCDILjOdlTBulxiE = vCuFOwupbXAwZDYXEGttCBuWIdQXA == gQgddHFyNfVGfPIXZPBcuigOMkbz.Bluetooth;
			if (LRPKAiiAziutaCDILjOdlTBulxiE)
			{
				qzcqxsvOdvKtvPDchdSXJviDIykLA.maxOutputReportLength = 78;
			}
			if (qzcqxsvOdvKtvPDchdSXJviDIykLA.maxOutputReportLength < 23)
			{
				qzcqxsvOdvKtvPDchdSXJviDIykLA.maxOutputReportLength = 23;
			}
			ZNZNonYqKrLsmUSdiIqdRVRKEICt = new NativeBuffer(64);
			lLoYVSTQKILJSWDNIGdghdQnSvEeA = new NativeBuffer(qzcqxsvOdvKtvPDchdSXJviDIykLA.maxOutputReportLength);
			xhZVaAiKhhZyJTIRcLqchtgSjpYq = new MwEMUNdEdQpngdbXMtjwIdOvEFgfA(lLoYVSTQKILJSWDNIGdghdQnSvEeA.Pointer, lLoYVSTQKILJSWDNIGdghdQnSvEeA.Length, qzcqxsvOdvKtvPDchdSXJviDIykLA.maxOutputReportLength);
			lights = new TlkpubcBJbLfvkJeODXKdsluGNyG[1]
			{
				new TlkpubcBJbLfvkJeODXKdsluGNyG(11, 24, 28)
			};
			lights[0].ieqOaerHmHMqFmIjZGBVkdVIFYNf += BvKYSyMehPsmaIoxdIrwYswmkoKQ;
			fSBmSkviGQhaTViJYpNhwyawaNB = true;
			vibrationMotors = new OuyedDeYgCfMJhRepxbdANVcvqtM[2]
			{
				new OuyedDeYgCfMJhRepxbdANVcvqtM(0, 255),
				new OuyedDeYgCfMJhRepxbdANVcvqtM(0, 255)
			};
			vibrationMotors[0].hzMbcPJOtgkpFhGaEaJpzIVCRwkNA += IXVBcJaLygsbLVHjNcXwrEeXNNUIA;
			vibrationMotors[1].hzMbcPJOtgkpFhGaEaJpzIVCRwkNA += IXVBcJaLygsbLVHjNcXwrEeXNNUIA;
			if (CWbWFAHuAdKSkqCoKGFgBFfQtUQKA.GetHidFeatureData(2, 37, 1000, 3) == null)
			{
				throw new Exception();
			}
			EAtcMDBRwwDmwtoMcVSucXYQyWjgA = true;
			if (LRPKAiiAziutaCDILjOdlTBulxiE)
			{
				cWMKHGmqMGgFlzIuJERVeLXwXrGTA = true;
				xhZVaAiKhhZyJTIRcLqchtgSjpYq.NadNaDdOvUUOWifUshEFULBlVOiN |= MejVVrrMOBdCIGddmesHFxhfxqsN.WriteDirect;
				cWMKHGmqMGgFlzIuJERVeLXwXrGTA = ysjqgdxiAPTuPKGeMzGtNbKNutiI(pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous);
				if (!cWMKHGmqMGgFlzIuJERVeLXwXrGTA)
				{
					xhZVaAiKhhZyJTIRcLqchtgSjpYq.NadNaDdOvUUOWifUshEFULBlVOiN &= ~MejVVrrMOBdCIGddmesHFxhfxqsN.WriteDirect;
				}
			}
			else
			{
				cWMKHGmqMGgFlzIuJERVeLXwXrGTA = ysjqgdxiAPTuPKGeMzGtNbKNutiI(pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous);
			}
			if (!cWMKHGmqMGgFlzIuJERVeLXwXrGTA)
			{
				throw new Exception();
			}
			YGmqfnQDafkZTUGduMKWJzJATonI = 1;
			UtbjwpYJKgfhHULakGUDufZzLVzI = 0;
			if (LRPKAiiAziutaCDILjOdlTBulxiE && cWMKHGmqMGgFlzIuJERVeLXwXrGTA)
			{
				YGmqfnQDafkZTUGduMKWJzJATonI = 17;
				UtbjwpYJKgfhHULakGUDufZzLVzI = 2;
			}
			UEhGzvqolsrVcuxPkhmeCpVDkuYX = 5 + UtbjwpYJKgfhHULakGUDufZzLVzI;
			OplHRmaRfGQChJwelTKhFWzrESEr = 6 + UtbjwpYJKgfhHULakGUDufZzLVzI;
			WHjXTmxOzpVjXstgnpiUWSZCNRBM = 7 + UtbjwpYJKgfhHULakGUDufZzLVzI;
			buttons = new jIFGialkYdAmDDAGsjKrXJoDparB[14];
			for (int i = 0; i < 14; i++)
			{
				buttons[i] = new jIFGialkYdAmDDAGsjKrXJoDparB(YGmqfnQDafkZTUGduMKWJzJATonI, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new OLAxjmdqJbHeCArvVCNIDgdBciXE[6]
			{
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(YGmqfnQDafkZTUGduMKWJzJATonI, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + UtbjwpYJKgfhHULakGUDufZzLVzI,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(YGmqfnQDafkZTUGduMKWJzJATonI, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + UtbjwpYJKgfhHULakGUDufZzLVzI,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(YGmqfnQDafkZTUGduMKWJzJATonI, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + UtbjwpYJKgfhHULakGUDufZzLVzI,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(YGmqfnQDafkZTUGduMKWJzJATonI, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + UtbjwpYJKgfhHULakGUDufZzLVzI,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(YGmqfnQDafkZTUGduMKWJzJATonI, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 8 + UtbjwpYJKgfhHULakGUDufZzLVzI,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(YGmqfnQDafkZTUGduMKWJzJATonI, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 9 + UtbjwpYJKgfhHULakGUDufZzLVzI,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0)
			};
			hats = new cqHyUHXvbVNypcmuagNrSpCNtoPi[1]
			{
				new cqHyUHXvbVNypcmuagNrSpCNtoPi(YGmqfnQDafkZTUGduMKWJzJATonI, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 5 + UtbjwpYJKgfhHULakGUDufZzLVzI,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, bVDhNIAJRaaOjTcPSvyaqLdLoCLeA)
			};
			accelerometers = new JIxBNLfOAPhdPBxkKRDEqbmYHLnib[1]
			{
				new JIxBNLfOAPhdPBxkKRDEqbmYHLnib(YGmqfnQDafkZTUGduMKWJzJATonI, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					dataIndex = 19 + UtbjwpYJKgfhHULakGUDufZzLVzI,
					bitSize = 48
				}, 3, sQvMJCEggeitwLVoXFLcGEuwLpqTA)
			};
			gyroscopes = new XeuQUxbgIYfXehYWxYnOrZfhgALkA[1]
			{
				new XeuQUxbgIYfXehYWxYnOrZfhgALkA(P_0.updateLoopSetting, YGmqfnQDafkZTUGduMKWJzJATonI, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					dataIndex = 13 + UtbjwpYJKgfhHULakGUDufZzLVzI,
					bitSize = 48
				}, 3, 60, ljLTLgGiFEKdbWGfJPllgyJwnUwF, OWIQuZsnnBAQQkSxPYcbDQxIUYen)
			};
			touchpads = new hwDBnDzZlOwqwaLOCXGWdEQuXFFf[1]
			{
				new hwDBnDzZlOwqwaLOCXGWdEQuXFFf(YGmqfnQDafkZTUGduMKWJzJATonI, new hwDBnDzZlOwqwaLOCXGWdEQuXFFf.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					dataIndex = 35 + UtbjwpYJKgfhHULakGUDufZzLVzI,
					bitSize = 48
				}, 60, ckpDAKvBoKzaBcxniGhfqxVCmDlt)
			};
			SKnBqLJmRnXvbHwYZPEKicqmlfAh = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			HKJqNxRVaOiAEBOyrAwmsUBnMfDR();
			zpHLWakARvZTdSfjZbTbFjuyXwIFA(pVnphHvTNRURYWZADvNPfpgNNbuB.Asynchronous);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < ZNZNonYqKrLsmUSdiIqdRVRKEICt.Length)
			{
				return false;
			}
			FpbKkblYmKhLGvKOCUIapNJbXiH = (float)(timestamp - SKnBqLJmRnXvbHwYZPEKicqmlfAh);
			SKnBqLJmRnXvbHwYZPEKicqmlfAh = timestamp;
			ZNZNonYqKrLsmUSdiIqdRVRKEICt.Write(inputReportPtr, inputReportLength, ZNZNonYqKrLsmUSdiIqdRVRKEICt.Length);
			itDiGauwXuBkjasTyjSYGIfgnJpc(ZNZNonYqKrLsmUSdiIqdRVRKEICt);
			qMbOWyPCMRgAehaWyRJyJUeUXCPE(ZNZNonYqKrLsmUSdiIqdRVRKEICt, timestamp);
			tNSBtIwTqUeWpGtNoXsrdaEOoFDcA[] array = axes;
			AzHxhlYmvBlJqRdzpwOqUwMXKExD(array, ZNZNonYqKrLsmUSdiIqdRVRKEICt, timestamp);
			array = hats;
			AzHxhlYmvBlJqRdzpwOqUwMXKExD(array, ZNZNonYqKrLsmUSdiIqdRVRKEICt, timestamp);
			array = accelerometers;
			AzHxhlYmvBlJqRdzpwOqUwMXKExD(array, ZNZNonYqKrLsmUSdiIqdRVRKEICt, timestamp);
			array = gyroscopes;
			AzHxhlYmvBlJqRdzpwOqUwMXKExD(array, ZNZNonYqKrLsmUSdiIqdRVRKEICt, timestamp);
			array = touchpads;
			AzHxhlYmvBlJqRdzpwOqUwMXKExD(array, ZNZNonYqKrLsmUSdiIqdRVRKEICt, timestamp);
			byte num = ZNZNonYqKrLsmUSdiIqdRVRKEICt[30 + UtbjwpYJKgfhHULakGUDufZzLVzI];
			byte b = (byte)(num & 0xF);
			if ((num & 0x10) != 0)
			{
				if (b <= 10)
				{
					LBzaEwxBYXJdefGUAbKkIzzAazzoA = MathTools.Clamp(b * 10 + 5, 0, 100);
					zUEsTuRZxPwGtsHVxLCCIsWIOGyg = zxCbZRqqtmmWKNqbwvWQdMNZlYXK.Charging;
				}
				else
				{
					switch (b)
					{
					case 11:
						LBzaEwxBYXJdefGUAbKkIzzAazzoA = 100;
						zUEsTuRZxPwGtsHVxLCCIsWIOGyg = zxCbZRqqtmmWKNqbwvWQdMNZlYXK.Full;
						break;
					case 14:
						LBzaEwxBYXJdefGUAbKkIzzAazzoA = 0;
						zUEsTuRZxPwGtsHVxLCCIsWIOGyg = zxCbZRqqtmmWKNqbwvWQdMNZlYXK.Charging;
						break;
					default:
						LBzaEwxBYXJdefGUAbKkIzzAazzoA = 0;
						zUEsTuRZxPwGtsHVxLCCIsWIOGyg = zxCbZRqqtmmWKNqbwvWQdMNZlYXK.Unknown;
						break;
					}
				}
			}
			else
			{
				switch (MathTools.Clamp((int)b, 0, 8))
				{
				case 0:
					LBzaEwxBYXJdefGUAbKkIzzAazzoA = 5;
					break;
				case 1:
					LBzaEwxBYXJdefGUAbKkIzzAazzoA = 20;
					break;
				case 2:
					LBzaEwxBYXJdefGUAbKkIzzAazzoA = 30;
					break;
				case 3:
					LBzaEwxBYXJdefGUAbKkIzzAazzoA = 45;
					break;
				case 4:
					LBzaEwxBYXJdefGUAbKkIzzAazzoA = 55;
					break;
				case 5:
					LBzaEwxBYXJdefGUAbKkIzzAazzoA = 70;
					break;
				case 6:
					LBzaEwxBYXJdefGUAbKkIzzAazzoA = 80;
					break;
				case 7:
					LBzaEwxBYXJdefGUAbKkIzzAazzoA = 95;
					break;
				case 8:
					LBzaEwxBYXJdefGUAbKkIzzAazzoA = 100;
					break;
				}
				zUEsTuRZxPwGtsHVxLCCIsWIOGyg = zxCbZRqqtmmWKNqbwvWQdMNZlYXK.Discharging;
			}
			CFGWzirSFTusDFXWQOTPiOPgjeujA();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualShock4Extension(this);
		}

		private void zpHLWakARvZTdSfjZbTbFjuyXwIFA(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
			if (mIolQKeSYQbvLAfWrDhyTVUqFVyp)
			{
				ysjqgdxiAPTuPKGeMzGtNbKNutiI(P_0);
				mIolQKeSYQbvLAfWrDhyTVUqFVyp = false;
			}
		}

		private bool ysjqgdxiAPTuPKGeMzGtNbKNutiI(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
			RmoZJVwkFNLJfFdZSsZJHmOcNMYt();
			bool result = wKkahjlpgraKxuAnxiEfAjEszePGA(P_0);
			if (uqXnaxFKEdSDPmxPRSHutldpmVHP)
			{
				result = wKkahjlpgraKxuAnxiEfAjEszePGA(P_0);
				uqXnaxFKEdSDPmxPRSHutldpmVHP = false;
			}
			return result;
		}

		private unsafe void RmoZJVwkFNLJfFdZSsZJHmOcNMYt()
		{
			byte b = 0;
			b |= 1;
			mDAHbNhxFwgqMwcidFENQaPkrRhWA = false;
			b |= 2;
			fSBmSkviGQhaTViJYpNhwyawaNB = false;
			b |= 4;
			HjDhneCOJpSPcAQilaJzvraEpYFVA = false;
			byte b2 = 128;
			if (LRPKAiiAziutaCDILjOdlTBulxiE)
			{
				b2 |= 0x40;
			}
			if (EAtcMDBRwwDmwtoMcVSucXYQyWjgA)
			{
				b2 |= 4;
				EAtcMDBRwwDmwtoMcVSucXYQyWjgA = false;
			}
			if (LRPKAiiAziutaCDILjOdlTBulxiE && cWMKHGmqMGgFlzIuJERVeLXwXrGTA)
			{
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[0] = 17;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[1] = b2;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[2] = 0;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[3] = b;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[4] = 0;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[5] = 0;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[6] = (byte)vibrationMotors[1].rXanWTxGcklOZyeDGcMFZMCGBbhL;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[7] = (byte)vibrationMotors[0].rXanWTxGcklOZyeDGcMFZMCGBbhL;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[8] = lights[0].LLchhSHiYWLgKJawqrLLaTDNyKxcA;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[9] = lights[0].HqCVfkrMQUVRcbdOevdmSmRmtWNj;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[10] = lights[0].jSiVbYCgDkpLtoziFaBcgRJEJmvE;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[11] = OEGurMjmRvMLUqfPzJXkHKNWLEDX;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[12] = eewaTRNODAeLOIgEaCPZVvNemotE;
				int gYvbRztLqcPpQaEsDreUlHXMLoES = xhZVaAiKhhZyJTIRcLqchtgSjpYq.gYvbRztLqcPpQaEsDreUlHXMLoES;
				uint bytes = LFtZljwOSdxaEGdTzXewVrJXDKBl.LjgniRQzpUhtoCchFquUnOJEZoeI((byte*)(void*)lLoYVSTQKILJSWDNIGdghdQnSvEeA.Pointer, gYvbRztLqcPpQaEsDreUlHXMLoES - 4, 162u);
				lLoYVSTQKILJSWDNIGdghdQnSvEeA.Write(bytes, gYvbRztLqcPpQaEsDreUlHXMLoES - 4);
			}
			else
			{
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[0] = 5;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[1] = b;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[2] = 0;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[4] = (byte)vibrationMotors[1].rXanWTxGcklOZyeDGcMFZMCGBbhL;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[5] = (byte)vibrationMotors[0].rXanWTxGcklOZyeDGcMFZMCGBbhL;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[6] = lights[0].LLchhSHiYWLgKJawqrLLaTDNyKxcA;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[7] = lights[0].HqCVfkrMQUVRcbdOevdmSmRmtWNj;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[8] = lights[0].jSiVbYCgDkpLtoziFaBcgRJEJmvE;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[9] = OEGurMjmRvMLUqfPzJXkHKNWLEDX;
				lLoYVSTQKILJSWDNIGdghdQnSvEeA[10] = eewaTRNODAeLOIgEaCPZVvNemotE;
			}
		}

		private bool wKkahjlpgraKxuAnxiEfAjEszePGA(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
			WSOOyjnDkExcDZEpCdREdEZNjpzG = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous:
				return CWbWFAHuAdKSkqCoKGFgBFfQtUQKA.WriteSync(xhZVaAiKhhZyJTIRcLqchtgSjpYq, 0);
			case pVnphHvTNRURYWZADvNPfpgNNbuB.Asynchronous:
				CWbWFAHuAdKSkqCoKGFgBFfQtUQKA.WriteAsync(xhZVaAiKhhZyJTIRcLqchtgSjpYq, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void qMbOWyPCMRgAehaWyRJyJUeUXCPE(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[UEhGzvqolsrVcuxPkhmeCpVDkuYX];
			buttons[0].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 0x10) != 0, P_1);
			buttons[1].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 0x20) != 0, P_1);
			buttons[2].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 0x40) != 0, P_1);
			buttons[3].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 0x80) != 0, P_1);
			b = P_0[OplHRmaRfGQChJwelTKhFWzrESEr];
			buttons[4].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 1) != 0, P_1);
			buttons[5].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 2) != 0, P_1);
			buttons[6].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 4) != 0, P_1);
			buttons[7].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 8) != 0, P_1);
			buttons[8].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 0x10) != 0, P_1);
			buttons[9].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 0x20) != 0, P_1);
			buttons[10].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 0x40) != 0, P_1);
			buttons[11].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 0x80) != 0, P_1);
			b = P_0[WHjXTmxOzpVjXstgnpiUWSZCNRBM];
			buttons[12].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 1) != 0, P_1);
			buttons[13].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 2) != 0, P_1);
		}

		private void AzHxhlYmvBlJqRdzpwOqUwMXKExD(tNSBtIwTqUeWpGtNoXsrdaEOoFDcA[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].SnJrVNcoeoNiXCCQLiNahDsWooVr(P_1, P_2);
			}
		}

		private void HKJqNxRVaOiAEBOyrAwmsUBnMfDR()
		{
			if (isVibrating && ReInput.realTime >= WSOOyjnDkExcDZEpCdREdEZNjpzG)
			{
				mIolQKeSYQbvLAfWrDhyTVUqFVyp = true;
				mDAHbNhxFwgqMwcidFENQaPkrRhWA = true;
			}
		}

		private void itDiGauwXuBkjasTyjSYGIfgnJpc(NativeBuffer P_0)
		{
			if (cWMKHGmqMGgFlzIuJERVeLXwXrGTA)
			{
				ushort num = ZNZNonYqKrLsmUSdiIqdRVRKEICt.ReadUShort(10 + UtbjwpYJKgfhHULakGUDufZzLVzI);
				float vyAolrNzNCmlnBhgXflAGimNnYaDA;
				if (num != ILiJiOgPUEWphOnDRACoyIkxcKvH)
				{
					int num2 = ((num >= ILiJiOgPUEWphOnDRACoyIkxcKvH) ? (num - ILiJiOgPUEWphOnDRACoyIkxcKvH) : (num + 65535 - ILiJiOgPUEWphOnDRACoyIkxcKvH));
					vyAolrNzNCmlnBhgXflAGimNnYaDA = (float)num2 / 187500f;
				}
				else
				{
					int num2 = 0;
					vyAolrNzNCmlnBhgXflAGimNnYaDA = 0f;
				}
				ILiJiOgPUEWphOnDRACoyIkxcKvH = num;
				VyAolrNzNCmlnBhgXflAGimNnYaDA = vyAolrNzNCmlnBhgXflAGimNnYaDA;
			}
		}

		private void CFGWzirSFTusDFXWQOTPiOPgjeujA()
		{
			if (cWMKHGmqMGgFlzIuJERVeLXwXrGTA)
			{
				_ = VyAolrNzNCmlnBhgXflAGimNnYaDA;
				_ = 0f;
				Vector3 vector = LVZTRaomhgSMpeBUUEoXKxgAoHNK(new Vector3(gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[0], gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[1], gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[2]), VyAolrNzNCmlnBhgXflAGimNnYaDA);
				PwdOakIvomqsooIJBcoNYczImWlO(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].idaOHKBnMGIFbSErnXWBOkCLqsFq[0] * -1f, accelerometers[0].idaOHKBnMGIFbSErnXWBOkCLqsFq[1] * -1f, accelerometers[0].idaOHKBnMGIFbSErnXWBOkCLqsFq[2] * -1f);
				FFTDGJbPMZijLeRBfJfYRsIOJoCQA(vector2, vector);
			}
		}

		private static bool PwdOakIvomqsooIJBcoNYczImWlO(ref Vector3 P_0)
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

		private void FFTDGJbPMZijLeRBfJfYRsIOJoCQA(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && oPFkClVVohqrSAmkPLtBxnOvdLyW(P_0, out var hoNZqYBfovUxrcucXxMohxcgfiKm))
			{
				Quaternion a = bXemivkxYCqAYjSVuqlIGMpAvOjv * quaternion;
				if (!lpIzAjRPeitdyNLAGLMOUdGmfrdg)
				{
					lpIzAjRPeitdyNLAGLMOUdGmfrdg = true;
					EqlauxxVTtlsBXZAwFLeddnVERtDA = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					EoveIGygDgrkueVpPUspgKYIyscU = bXemivkxYCqAYjSVuqlIGMpAvOjv;
				}
				EqlauxxVTtlsBXZAwFLeddnVERtDA *= quaternion;
				EoveIGygDgrkueVpPUspgKYIyscU *= quaternion;
				Quaternion b;
				if ((hoNZqYBfovUxrcucXxMohxcgfiKm & HoNZqYBfovUxrcucXxMohxcgfiKm.XZ) != HoNZqYBfovUxrcucXxMohxcgfiKm.None)
				{
					b = YpeFyGjWzYioKVuUBEOPnxePkOCE(P_0, a.eulerAngles.y);
				}
				else if ((hoNZqYBfovUxrcucXxMohxcgfiKm & HoNZqYBfovUxrcucXxMohxcgfiKm.Y) != HoNZqYBfovUxrcucXxMohxcgfiKm.None)
				{
					b = CPmGrjbRlVeOXQtGAZYwWETsRiTK(P_0);
					Vector3 vector = EoveIGygDgrkueVpPUspgKYIyscU * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				bXemivkxYCqAYjSVuqlIGMpAvOjv = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				bXemivkxYCqAYjSVuqlIGMpAvOjv *= quaternion;
				if (lpIzAjRPeitdyNLAGLMOUdGmfrdg)
				{
					lpIzAjRPeitdyNLAGLMOUdGmfrdg = false;
				}
			}
		}

		private static Quaternion PaQgAtIHTzhyxIWlPrAuKxGFJMcb(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = cMRvXtHxvLcxdaqLQebVyUJqQgFL(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 cMRvXtHxvLcxdaqLQebVyUJqQgFL(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion bTzOXMvaIGQwwgysWccXucVFJtUG(Quaternion P_0, NGuFbeAlAkShcBAsxPiSxgPYyDHpA P_1)
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

		private float UtRUBUzjrfFtBRlVmMGpNVNXsPiJ(float P_0, float P_1)
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

		private Vector3 uAtGpQLfOUmzohmvzVQwHllgZhth(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion YpeFyGjWzYioKVuUBEOPnxePkOCE(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion CPmGrjbRlVeOXQtGAZYwWETsRiTK(Vector3 P_0, float P_1 = 0f)
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

		private float zkkvTxFBRvGTvctGVybLiDbuiFBZ(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool tyOaDlCDWWBhAMpHkGKPHcUAHfalb(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool oPFkClVVohqrSAmkPLtBxnOvdLyW(Vector3 P_0, out HoNZqYBfovUxrcucXxMohxcgfiKm P_1)
		{
			P_0.Normalize();
			P_1 = HoNZqYBfovUxrcucXxMohxcgfiKm.None;
			bool result = false;
			if (pFWUaAxXpWxSWlJAZtYtrbFplsV(P_0))
			{
				result = true;
				P_1 |= HoNZqYBfovUxrcucXxMohxcgfiKm.XZ;
			}
			if (yseuzdhxLuLpKcjHZmVhxXbTbrvS(P_0))
			{
				result = true;
				P_1 |= HoNZqYBfovUxrcucXxMohxcgfiKm.Y;
			}
			return result;
		}

		private bool pFWUaAxXpWxSWlJAZtYtrbFplsV(Vector3 P_0)
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

		private bool yseuzdhxLuLpKcjHZmVhxXbTbrvS(Vector3 P_0)
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

		private Vector3 aKbEtaDnVwqMFhphAMwNJItPjLKCB(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 wxRvSjCVdHIlKqadmNvJDSLBudUf(RingBuffer<XeuQUxbgIYfXehYWxYnOrZfhgALkA.NMUfRuddrxzsOdYlzmZPObqZgnUAb> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				XeuQUxbgIYfXehYWxYnOrZfhgALkA.NMUfRuddrxzsOdYlzmZPObqZgnUAb nMUfRuddrxzsOdYlzmZPObqZgnUAb = P_0[i];
				result += LVZTRaomhgSMpeBUUEoXKxgAoHNK(nMUfRuddrxzsOdYlzmZPObqZgnUAb.rbEgINakgzYISAmqheGGqOdwGNTDA, nMUfRuddrxzsOdYlzmZPObqZgnUAb.HskqKKXFdIkNuFNXjQqjwcHGwfED);
			}
			return result;
		}

		private Vector3 LVZTRaomhgSMpeBUUEoXKxgAoHNK(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int bVDhNIAJRaaOjTcPSvyaqLdLoCLeA(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void sQvMJCEggeitwLVoXFLcGEuwLpqTA(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void ljLTLgGiFEKdbWGfJPllgyJwnUwF(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float OWIQuZsnnBAQQkSxPYcbDQxIUYen()
		{
			return VyAolrNzNCmlnBhgXflAGimNnYaDA;
		}

		private void ckpDAKvBoKzaBcxniGhfqxVCmDlt(NativeBuffer P_0, hwDBnDzZlOwqwaLOCXGWdEQuXFFf.TouchData[] P_1)
		{
			int num = 35 + UtbjwpYJKgfhHULakGUDufZzLVzI;
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
			P_1[0].touchId = zrJjtbnUdrpgJGKiObaDeLESFcPp(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = zrJjtbnUdrpgJGKiObaDeLESFcPp(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int zrJjtbnUdrpgJGKiObaDeLESFcPp(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				aUQrJbRoZycRtqRPVdkMpzkdmydE[P_0] = -1;
				rDaLYuKvKJzhEuwqznImBejgYgli[P_0] = P_2;
				return -1;
			}
			if (P_2 != rDaLYuKvKJzhEuwqznImBejgYgli[P_0])
			{
				int pSlxNcEQoZBTKehjPHKsrvEnrSCw = PSlxNcEQoZBTKehjPHKsrvEnrSCw;
				if (PSlxNcEQoZBTKehjPHKsrvEnrSCw == int.MaxValue)
				{
					PSlxNcEQoZBTKehjPHKsrvEnrSCw = 0;
				}
				else
				{
					PSlxNcEQoZBTKehjPHKsrvEnrSCw++;
				}
				rDaLYuKvKJzhEuwqznImBejgYgli[P_0] = P_2;
				aUQrJbRoZycRtqRPVdkMpzkdmydE[P_0] = pSlxNcEQoZBTKehjPHKsrvEnrSCw;
				return pSlxNcEQoZBTKehjPHKsrvEnrSCw;
			}
			return aUQrJbRoZycRtqRPVdkMpzkdmydE[P_0];
		}

		private void BvKYSyMehPsmaIoxdIrwYswmkoKQ()
		{
			fSBmSkviGQhaTViJYpNhwyawaNB = true;
			kOfNcIelXNjKsNiTyiSbJncRhLUQ();
		}

		private void DsstyHneeFCAjCnYbgNaTjnnrDZI()
		{
			HjDhneCOJpSPcAQilaJzvraEpYFVA = true;
			kOfNcIelXNjKsNiTyiSbJncRhLUQ();
		}

		private void IXVBcJaLygsbLVHjNcXwrEeXNNUIA()
		{
			mDAHbNhxFwgqMwcidFENQaPkrRhWA = true;
			kOfNcIelXNjKsNiTyiSbJncRhLUQ();
		}

		private void kOfNcIelXNjKsNiTyiSbJncRhLUQ()
		{
			mIolQKeSYQbvLAfWrDhyTVUqFVyp = true;
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
				zpHLWakARvZTdSfjZbTbFjuyXwIFA(pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous);
				if (ZNZNonYqKrLsmUSdiIqdRVRKEICt != null)
				{
					ZNZNonYqKrLsmUSdiIqdRVRKEICt.Dispose();
				}
				if (lLoYVSTQKILJSWDNIGdghdQnSvEeA != null)
				{
					lLoYVSTQKILJSWDNIGdghdQnSvEeA.Dispose();
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

		[Conditional("DEBUG_THIS")]
		private static void AbnopNkBRlBljwJGbCJSJaRmbcTcb(object P_0)
		{
			Logger.Log(P_0, requiredThreadSafety: true);
		}
	}
}
