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
		private enum quGSAGQhBznZMxjzywmSOenfhUlo
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum onhacIqtcvaJcTxEGneoJCqHqwpc
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private static class gFIqPITVeiXqJrYsNBkXzfovCtUA
		{
			private const uint yzJDxxCBMtMRDMwJkuQPVxDeLGKoA = 3988292384u;

			public unsafe static uint urIKOzzjyLFYObQwCaTOLxjfQzAH(byte* P_0, int P_1, uint P_2)
			{
				return ~SWyCUqdnFCFInueYpxvMBBuysuWR(SWyCUqdnFCFInueYpxvMBBuysuWR(uint.MaxValue, (byte*)(&P_2), 1, 3988292384u), P_0, P_1, 3988292384u);
			}

			public unsafe static uint wQmOyvFFfrZWnJhNGbbefcxlYshF(uint P_0, byte* P_1, int P_2)
			{
				return SWyCUqdnFCFInueYpxvMBBuysuWR(P_0, P_1, P_2, 3988292384u);
			}

			private unsafe static uint SWyCUqdnFCFInueYpxvMBBuysuWR(uint P_0, byte* P_1, int P_2, uint P_3)
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

		private enum MDgyZfHKqnywwyjcvKyENkluJptJ
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			Unknown = 3
		}

		private const float gJNAbpFjERzPteKShpjLACDIlEMQc = 4f;

		private const int uHeiWdXyyFbSwjFEAtOByxFCEQPo = 14;

		private const int hJQiaSaslcGxMRDYyGwiNabzbJvBA = 2;

		private const int MGFldDBFKUTpvCAvdFcxhMqeHPJA = 0;

		private const int XDvdDXEdqTMHZCDSQjoAfqfEtQwJb = 1912;

		private const int gdXAmRkPAGHgTfVilOrpAKlGSrWsB = 0;

		private const int dWdsldroCJwwtydHOnIGpZkvrAjW = 941;

		private const bool KEGGJqaIfHHDdhvyWpEBfAcsibwL = false;

		private const bool ksyHzbpaJqefeGCkNrVOrADhQGhhA = true;

		private const float UFUEpZgoYkwDYvWqvAcUefBUBXlG = 2.5f;

		private const int zpSMqPyPHLIgUHuvykpnpIitwBpM = 0;

		private const int iBlfiUdCtKKNIEbSjPEUSQGVXBGbA = 0;

		private const int AEcCsgAymLZgVDvknZuvRJRuQHJO = 1;

		private const int aMrEJncqnbtgALXpVDYhRXPTKMqX = 0;

		private const int KAurlWuLGweVZuAzOwuRzDTRVZwH = 0;

		private const int NTPugejUZWEpoABGAlsICDzRDsnDA = 0;

		private const int DvWWgKxeFdjFiXDWPgdTyuDRlybE = 1;

		private const int OtFYiLRPSdeviLclEuNrrAiEVHgf = 17;

		private const int OICMZOrHRvvOsYmgqYuRMDoBThR = 0;

		private const int dCKXDChAGBYFYbakYUZodfmjXmYG = 2;

		private const int MBNsdrFbAyxolCQBWOPjFSLhfTiy = 64;

		private const int tkKhIFbiQxPQCejLNemMLxlyVfCi = 78;

		private const byte LUBNUYWwKAVONwiXOIqHfPNUwtPb = 17;

		private const byte ttFbOASCOTVNHvcRKlOUpouDSJTV = 5;

		private const byte PgtgUHnhylxLuUFCFoEQJjNTuvIu = 2;

		private const byte EbDpRTBTnEalMhTkZikBMwdEMzIr = 37;

		private const byte oNlhThBaMdJpvcaqcznwPtnecolN = 5;

		private const byte rTGoZIjrbvvuAthukotiJLCictor = 41;

		private const byte TJTeaAYNHShQreVBChvzfZQbhyrhA = 163;

		private const byte AYrqvUkpvDOHGyorVufqKlaYMhjI = 49;

		private const byte hFBhxBFIdJYdpAMEoLCzFEqOsjbAb = 18;

		private const byte YcyvtAYAJfLhOIMcunnNqQfZBzmn = 16;

		private const byte xjrpsjkllyhWNsWHFCUKcQgMjWVFA = 161;

		private const byte ZqmWaKEowGfwBeUIqvHtAWcqANOz = 162;

		private const byte wNfHYawEaxSyFbgEvIcaAlxTpsBdb = 163;

		private const int xUaMUcTMVJzHTrpmaligMIQRQaEg = 1;

		private const int yhxFwgjmsZJfOCohhgUuzcoBgRhT = 2;

		private const int dRIsRohUXMhVcQNRzsvwpuAjsKMg = 3;

		private const int WQuBSJkLJdnEAnEarquJAumDjdvBc = 4;

		private const int iFljShWVTAVsiRHBCIPDKBjwKEoT = 8;

		private const int UgShHSpTnxlipTdvefTxiedwZEzP = 9;

		private const int ABtAKaQCsvfljFDpUpXyeGCnvghDA = 5;

		private const int KJRbsWpnoxzowyyonJgyYRPhzJbD = 19;

		private const int fafdwTGByCIMZeQNFiKfMIuLMPUvB = 13;

		private const int rtKTgyvKDsAQDFtdQUyfCmErpMPn = 35;

		private const int IsNoYfYmqEFFYmDowAqyiMuOKjIJA = 5;

		private const int aAJNErFiaqYPbbLCzvTjfNRbZQZr = 6;

		private const int rGooupGiINnxDmfezAmEpIPGeIJl = 7;

		private const int lLZpeNxBgEhtGnGjgbssenTwxtYb = 10;

		private const int rRmAdDTTobNspLWJftKjYAWmRSpj = 30;

		private const int aExmZzJnSNOxExWLWgUEBGpoYYLN = 27;

		private const byte sHuaLIoTDmFtdAcVzTlZKjKGeDITA = 200;

		private const byte jIxZvbRbRkFsoMDoeEmtvhSssTWO = 53;

		private const byte cuLzfQqIFDLOZYNbgzbTpcwItkIo = byte.MaxValue;

		private const byte magDTxYckWByoeolrIJqZndqUzpSA = 0;

		private const bool wWLjOUCnIIdugnhxvpWaIsEjDmim = true;

		private const int cGjDSBIPzAzeecaXJFIBmUNbjoYG = 60;

		private const int eikkcQqwocKJIxeGaCngdVkPLjixA = 60;

		private const int OoOUgwZUhDAMWCafXfZNgbcPICgw = 187500;

		private const float RdAFWEBFibmvprPlBJsMjZpEfVsrA = 8192f;

		private const float cXzWrwjobfBoTdIPJlUvkYtogwgg = 0.0010652969f;

		private const float ZfsFiNtDgYnaAslkjOaZJhmyccLbA = 0.06103702f;

		private const bool RxSLidnLlxcVFhPWeDYkwRHMSFUL = true;

		private const bool BLfmnEMkIUnDWSZMeIDJcttGxoFe = true;

		private const bool kjPkSeQJGrwErNlhoRUizJNASCmG = true;

		private const bool KJDwAMnYwRgCYLTGKgJugbdXwycJ = true;

		private const float csprvdqfmcjgvUDgHjQRAhTBhByPA = 4096f;

		private const float RIaTUGkgQjWMLyBLsEkCtSnEScfe = 16384f;

		private const float akOaNSfLngUwTShqRmnYhRxJrGIAb = 16777216f;

		private const float mnTCJQrVwfWYUgZCIQecXLDxoxUm = 268435460f;

		private const float RXfiGxLWfdwVtKACOWnspZEpCelN = 0.01999998f;

		private const float xBYnFlZMxXPJiULYserzjhVETpReA = 8192f;

		private const float VvzGMOIcVNvGblCkDATCmKKaecRR = 0.98f;

		private const float BkmyXcLyXuQvGlkRTbFyqOIJUTWp = 45f;

		private const float KmrpPvardNIoLGVqOortpIGetScy = 20f;

		private readonly IHIDDevice bKTZcuiFPwLqYTgpDnTwbOZzFugl;

		private readonly HIDProperties NLKHYQIDssXuPyzziAmZJKGcxrIk;

		private readonly bool knfveMFFTvGHAbgUYlWvZmxNodOl;

		private readonly RXEzGxJeQkuaNxkYCJIkKyWznLNi UfAzmWPSkIAWffvALtdpbMKlsjgi;

		private readonly int dTckHwTjFtCpwwroWILGAcFIkkGZA;

		private readonly int WKnjUhMjIccxtsXkPBTkhDBXgTWX;

		private readonly bool LoeooaBrJVCvDUTvWKVFdqfZbywFA;

		private readonly byte xXSNcJtrbcIjxtoJhYeEpHjbKzRJ;

		private readonly int vAVCGPtrNjGDjrOdbJKJKIzMtGRWA;

		private readonly int jmDsGHTZcpqtSJsMpoXgczxqtysj;

		private readonly int zvDqoWDdkRekJKsbcmKjMdRGzXsZ;

		private readonly int xtBbsIiGekSNfjFjHsqGdadzrWxvB;

		private readonly NativeBuffer uxxJNXtDTuGSEbnmxGctApxefVyTB;

		private readonly NativeBuffer WiKcakiaPJFpivtAPInqGFqDAckSB;

		private readonly dccInhMggZtLYGkWFjXacEyGQoUL GNlGHujReeuYliyMvDemNVGbJyoMA;

		private readonly byte[] dbkWIJSdQAwkoSSYWFQFHAaYPmEx = new byte[1] { 162 };

		private bool TVMhjmJTTViLrpFFeqtubsmJBCSM;

		private bool ZUbkTTczDkCnxLLKKXJcZTDSjClM;

		private double buctVEfYRqPfyEmBuvCHTrgjoVN;

		private int eMJbyQORTCDjQKzRFQokFqJhixVh;

		private MDgyZfHKqnywwyjcvKyENkluJptJ WJiPYtuCGGANRXEsaBWyiELbDEpB = MDgyZfHKqnywwyjcvKyENkluJptJ.Unknown;

		private Quaternion OAEKLVRJLZOkkGpCnClOKaLvwXDUA = Quaternion.identity;

		private ushort dZCwMmNEpPowXjcgUCQwWEWUxEHd;

		private float uFmFMZoIWLuBDsElYazEHWWcBXQJA;

		private double jGRwvsatcelbPqpKWXeEEfCBskcG;

		private float sUTCeIUaBxgpxzKPRQWOEifyuNWi;

		private bool FkewUbERUvKKyNUnonGPKrjRYWDL;

		private bool oXRgDGZqvbgaHkKKYWShHcIBxDMK;

		private bool wRjtWSjcSambMtGliuLrRQAhMXhp;

		private bool tTXYxtgVfbbOCDPJhnEcnJgbiNHU;

		private byte rJacPwOEUqUkcTWGeaRalRftIJjiA;

		private byte NTCZfjePRPQaTftVhGVAbNwXlZjB;

		private Quaternion hlPPVDWDQkEZjirTjFukBNDoQtLF = Quaternion.identity;

		private Quaternion lkPshkLRKtqUUDkeOxuxKRmdRhEu = Quaternion.identity;

		private bool EfeBQRmMhhhHGqGFDVRMiscLIgPr;

		private int ooDAsUabpORtyNPgQNAaKTaCRFohA;

		private int[] BlmABVoDdtKGLFcSAIvUZWHOpzZl = new int[2];

		private int[] SHSOxUdlNKGPeFinqEpmgfDHbXPlA = new int[2];

		private bool isVibrating
		{
			get
			{
				for (int i = 0; i < base.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EVibrationMotorCount; i++)
				{
					if (vibrationMotors[i].IqUCAdAupfvNpXYQVecZbYudoQHV > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		float IDriver_DualShock4.BatteryLevel => eMJbyQORTCDjQKzRFQokFqJhixVh;

		bool IDriver_DualShock4.BatteryCharging => WJiPYtuCGGANRXEsaBWyiELbDEpB == MDgyZfHKqnywwyjcvKyENkluJptJ.Charging;

		float IDriver_DualShock4.LeftMotor
		{
			get
			{
				return vibrationMotors[0].VkXdVAiMyWDgMKEYwLoxttDNIods;
			}
			set
			{
				vibrationMotors[0].VkXdVAiMyWDgMKEYwLoxttDNIods = value;
			}
		}

		float IDriver_DualShock4.RightMotor
		{
			get
			{
				return vibrationMotors[1].VkXdVAiMyWDgMKEYwLoxttDNIods;
			}
			set
			{
				vibrationMotors[1].VkXdVAiMyWDgMKEYwLoxttDNIods = value;
			}
		}

		float IDriver_DualShock4.LightColorR
		{
			get
			{
				return lights[0].bFcLWhUVQYrhAtojtbBTOwUMnPuo;
			}
			set
			{
				lights[0].bFcLWhUVQYrhAtojtbBTOwUMnPuo = value;
			}
		}

		float IDriver_DualShock4.LightColorG
		{
			get
			{
				return lights[0].cPTNHiJyYcdHppnnfDGHBtVeMsBm;
			}
			set
			{
				lights[0].cPTNHiJyYcdHppnnfDGHBtVeMsBm = value;
			}
		}

		float IDriver_DualShock4.LightColorB
		{
			get
			{
				return lights[0].UWJkPgTZOsCYAYhmbdbUfaNJAMak;
			}
			set
			{
				lights[0].UWJkPgTZOsCYAYhmbdbUfaNJAMak = value;
			}
		}

		float IDriver_DualShock4.LightFlashOnDuration
		{
			get
			{
				return (int)rJacPwOEUqUkcTWGeaRalRftIJjiA;
			}
			set
			{
				rJacPwOEUqUkcTWGeaRalRftIJjiA = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				idGdYzWLhKiaNpeVsfqkGvRMOmhdA();
				if (rJacPwOEUqUkcTWGeaRalRftIJjiA == 0 && NTCZfjePRPQaTftVhGVAbNwXlZjB == 0)
				{
					ZUbkTTczDkCnxLLKKXJcZTDSjClM = true;
				}
			}
		}

		float IDriver_DualShock4.LightFlashOffDuration
		{
			get
			{
				return (int)NTCZfjePRPQaTftVhGVAbNwXlZjB;
			}
			set
			{
				NTCZfjePRPQaTftVhGVAbNwXlZjB = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				idGdYzWLhKiaNpeVsfqkGvRMOmhdA();
				if (rJacPwOEUqUkcTWGeaRalRftIJjiA == 0 && NTCZfjePRPQaTftVhGVAbNwXlZjB == 0)
				{
					ZUbkTTczDkCnxLLKKXJcZTDSjClM = true;
				}
			}
		}

		Vector3 IDriver_DualShock4.AccelerometerValue => XDZaKYCSAnWgxHAoPKoHwvREgSmkA(accelerometers[0].VNYkooeoXLtNVzxyiQWNaRkcrEnm);

		Vector3 IDriver_DualShock4.AccelerometerValueRaw => new Vector3(accelerometers[0].VNYkooeoXLtNVzxyiQWNaRkcrEnm[0], accelerometers[0].VNYkooeoXLtNVzxyiQWNaRkcrEnm[1], accelerometers[0].VNYkooeoXLtNVzxyiQWNaRkcrEnm[2]);

		Vector3 IDriver_DualShock4.GyroscopeValue => VozKbDrSHAetmZlKlJVFviRadUed(gyroscopes[0].bRYYalqPvoZZKKsccsFDDVGzVieM);

		Vector3 IDriver_DualShock4.GyroscopeValueRaw => new Vector3(gyroscopes[0].ZCKmYdzExBcrTEdbLYeNBVgDsXZH[0], gyroscopes[0].ZCKmYdzExBcrTEdbLYeNBVgDsXZH[1], gyroscopes[0].ZCKmYdzExBcrTEdbLYeNBVgDsXZH[2]);

		Vector3 IDriver_DualShock4.LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[0], gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[1], gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[2]);
				return uEvgISRXgtqoNTcLRaULwoQpnzpk(vector, uFmFMZoIWLuBDsElYazEHWWcBXQJA);
			}
		}

		Vector3 IDriver_DualShock4.LastGyroscopeValueRaw => new Vector3(gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[0], gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[1], gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[2]);

		Quaternion IDriver_DualShock4.Orientation => OAEKLVRJLZOkkGpCnClOKaLvwXDUA;

		int IDriver_DualShock4.MaxTouches => 2;

		ushort IHIDControllerExtension.vendorId => NLKHYQIDssXuPyzziAmZJKGcxrIk.vendorId;

		ushort IHIDControllerExtension.productId => NLKHYQIDssXuPyzziAmZJKGcxrIk.productId;

		string IHIDControllerExtension.productName => NLKHYQIDssXuPyzziAmZJKGcxrIk.productName;

		string IHIDControllerExtension.manufacturer => NLKHYQIDssXuPyzziAmZJKGcxrIk.manufacturer;

		ushort IHIDControllerExtension.usagePage => NLKHYQIDssXuPyzziAmZJKGcxrIk.usagePage;

		ushort IHIDControllerExtension.usage => NLKHYQIDssXuPyzziAmZJKGcxrIk.usage;

		public void ResetOrientation()
		{
			OAEKLVRJLZOkkGpCnClOKaLvwXDUA = Quaternion.identity;
			EfeBQRmMhhhHGqGFDVRMiscLIgPr = false;
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
				if (touchpads[0].NjrKDEoRljbTLZdbSWZHjMXESqOB[i].isTouching)
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
			return touchpads[0].NjrKDEoRljbTLZdbSWZHjMXESqOB[index].isTouching;
		}

		bool IDriver_DualShock4.IsTouchingAtIndex(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtIndex
			return this.IsTouchingAtIndex(index);
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return touchpads[0].KezhOiULMJFiOJiOOejHvhuyqIuIA(touchId);
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
			return touchpads[0].NjrKDEoRljbTLZdbSWZHjMXESqOB[index].touchId;
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
			SRlmwzCpkDCiOPGALkZGROsZKGfx.TouchData[] njrKDEoRljbTLZdbSWZHjMXESqOB = touchpads[0].NjrKDEoRljbTLZdbSWZHjMXESqOB;
			if (!njrKDEoRljbTLZdbSWZHjMXESqOB[index].isTouching)
			{
				return false;
			}
			position.x = njrKDEoRljbTLZdbSWZHjMXESqOB[index].positionX;
			position.y = njrKDEoRljbTLZdbSWZHjMXESqOB[index].positionY;
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
			if (!touchpads[0].KezhOiULMJFiOJiOOejHvhuyqIuIA(touchId))
			{
				return false;
			}
			SRlmwzCpkDCiOPGALkZGROsZKGfx.TouchData[] njrKDEoRljbTLZdbSWZHjMXESqOB = touchpads[0].NjrKDEoRljbTLZdbSWZHjMXESqOB;
			for (int i = 0; i < njrKDEoRljbTLZdbSWZHjMXESqOB.Length; i++)
			{
				if (njrKDEoRljbTLZdbSWZHjMXESqOB[i].isTouching)
				{
					position.x = njrKDEoRljbTLZdbSWZHjMXESqOB[i].positionX;
					position.y = njrKDEoRljbTLZdbSWZHjMXESqOB[i].positionY;
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
			SRlmwzCpkDCiOPGALkZGROsZKGfx.TouchData[] njrKDEoRljbTLZdbSWZHjMXESqOB = touchpads[0].NjrKDEoRljbTLZdbSWZHjMXESqOB;
			if (!njrKDEoRljbTLZdbSWZHjMXESqOB[index].isTouching)
			{
				return false;
			}
			positionX = njrKDEoRljbTLZdbSWZHjMXESqOB[index].positionAbsX;
			positionY = njrKDEoRljbTLZdbSWZHjMXESqOB[index].positionAbsY;
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
			if (!touchpads[0].KezhOiULMJFiOJiOOejHvhuyqIuIA(touchId))
			{
				return false;
			}
			SRlmwzCpkDCiOPGALkZGROsZKGfx.TouchData[] njrKDEoRljbTLZdbSWZHjMXESqOB = touchpads[0].NjrKDEoRljbTLZdbSWZHjMXESqOB;
			for (int i = 0; i < njrKDEoRljbTLZdbSWZHjMXESqOB.Length; i++)
			{
				if (njrKDEoRljbTLZdbSWZHjMXESqOB[i].isTouching)
				{
					positionX = njrKDEoRljbTLZdbSWZHjMXESqOB[i].positionAbsX;
					positionY = njrKDEoRljbTLZdbSWZHjMXESqOB[i].positionAbsY;
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
			rJacPwOEUqUkcTWGeaRalRftIJjiA = 0;
			NTCZfjePRPQaTftVhGVAbNwXlZjB = 0;
			TVMhjmJTTViLrpFFeqtubsmJBCSM = true;
			ZUbkTTczDkCnxLLKKXJcZTDSjClM = true;
			wRjtWSjcSambMtGliuLrRQAhMXhp = true;
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
				vibrationMotors[i].IqUCAdAupfvNpXYQVecZbYudoQHV = 0;
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
			bKTZcuiFPwLqYTgpDnTwbOZzFugl = P_0.hidDevice;
			NLKHYQIDssXuPyzziAmZJKGcxrIk = bKTZcuiFPwLqYTgpDnTwbOZzFugl.properties;
			dTckHwTjFtCpwwroWILGAcFIkkGZA = P_0.hatZeroValue;
			WKnjUhMjIccxtsXkPBTkhDBXgTWX = P_0.hatSpan;
			UfAzmWPSkIAWffvALtdpbMKlsjgi = P_0.connectionType;
			knfveMFFTvGHAbgUYlWvZmxNodOl = UfAzmWPSkIAWffvALtdpbMKlsjgi == RXEzGxJeQkuaNxkYCJIkKyWznLNi.Bluetooth;
			if (knfveMFFTvGHAbgUYlWvZmxNodOl)
			{
				NLKHYQIDssXuPyzziAmZJKGcxrIk.maxOutputReportLength = 78;
			}
			if (NLKHYQIDssXuPyzziAmZJKGcxrIk.maxOutputReportLength < 23)
			{
				NLKHYQIDssXuPyzziAmZJKGcxrIk.maxOutputReportLength = 23;
			}
			uxxJNXtDTuGSEbnmxGctApxefVyTB = new NativeBuffer(64);
			WiKcakiaPJFpivtAPInqGFqDAckSB = new NativeBuffer(NLKHYQIDssXuPyzziAmZJKGcxrIk.maxOutputReportLength);
			GNlGHujReeuYliyMvDemNVGbJyoMA = new dccInhMggZtLYGkWFjXacEyGQoUL(WiKcakiaPJFpivtAPInqGFqDAckSB.Pointer, WiKcakiaPJFpivtAPInqGFqDAckSB.Length, NLKHYQIDssXuPyzziAmZJKGcxrIk.maxOutputReportLength);
			lights = new iaSQTyJQfafVqZneFJUiRVRBDWdc[1]
			{
				new iaSQTyJQfafVqZneFJUiRVRBDWdc(11, 24, 28)
			};
			lights[0].TnMtrKGOeSsLjFPJAGfRQtnlOdlF += gzoazKddmYJQSflodezoPcAdZtgXb;
			oXRgDGZqvbgaHkKKYWShHcIBxDMK = true;
			vibrationMotors = new pMGtGvfvhFCynWDpoUnlyTrPulZp[2]
			{
				new pMGtGvfvhFCynWDpoUnlyTrPulZp(0, 255),
				new pMGtGvfvhFCynWDpoUnlyTrPulZp(0, 255)
			};
			vibrationMotors[0].AvoxNtfnozFNrfrnTlHdoendJzWW += vdtXDnqAjfWVtcoyUOXkiVUeqWgs;
			vibrationMotors[1].AvoxNtfnozFNrfrnTlHdoendJzWW += vdtXDnqAjfWVtcoyUOXkiVUeqWgs;
			if (bKTZcuiFPwLqYTgpDnTwbOZzFugl.GetHidFeatureData(2, 37, 1000, 3) == null)
			{
				throw new Exception();
			}
			tTXYxtgVfbbOCDPJhnEcnJgbiNHU = true;
			if (knfveMFFTvGHAbgUYlWvZmxNodOl)
			{
				LoeooaBrJVCvDUTvWKVFdqfZbywFA = true;
				GNlGHujReeuYliyMvDemNVGbJyoMA.ofRcrROmEPgbgDZJnODVczeCRfSh |= zQFonDSyLUVtcnBuzoJLlVRGpkWG.WriteDirect;
				LoeooaBrJVCvDUTvWKVFdqfZbywFA = NMBVxBMzQCdffdHsNpTpfukubhOh(ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous);
				if (!LoeooaBrJVCvDUTvWKVFdqfZbywFA)
				{
					GNlGHujReeuYliyMvDemNVGbJyoMA.ofRcrROmEPgbgDZJnODVczeCRfSh &= ~zQFonDSyLUVtcnBuzoJLlVRGpkWG.WriteDirect;
				}
			}
			else
			{
				LoeooaBrJVCvDUTvWKVFdqfZbywFA = NMBVxBMzQCdffdHsNpTpfukubhOh(ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous);
			}
			if (!LoeooaBrJVCvDUTvWKVFdqfZbywFA)
			{
				throw new Exception();
			}
			xXSNcJtrbcIjxtoJhYeEpHjbKzRJ = 1;
			vAVCGPtrNjGDjrOdbJKJKIzMtGRWA = 0;
			if (knfveMFFTvGHAbgUYlWvZmxNodOl && LoeooaBrJVCvDUTvWKVFdqfZbywFA)
			{
				xXSNcJtrbcIjxtoJhYeEpHjbKzRJ = 17;
				vAVCGPtrNjGDjrOdbJKJKIzMtGRWA = 2;
			}
			jmDsGHTZcpqtSJsMpoXgczxqtysj = 5 + vAVCGPtrNjGDjrOdbJKJKIzMtGRWA;
			zvDqoWDdkRekJKsbcmKjMdRGzXsZ = 6 + vAVCGPtrNjGDjrOdbJKJKIzMtGRWA;
			xtBbsIiGekSNfjFjHsqGdadzrWxvB = 7 + vAVCGPtrNjGDjrOdbJKJKIzMtGRWA;
			buttons = new YgmprUEDpDakYucBfpnWbXzouOGJ[14];
			for (int i = 0; i < 14; i++)
			{
				buttons[i] = new YgmprUEDpDakYucBfpnWbXzouOGJ(xXSNcJtrbcIjxtoJhYeEpHjbKzRJ, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new nZeIQQWnQohhanyhWEOObGRunlRc[6]
			{
				new nZeIQQWnQohhanyhWEOObGRunlRc(xXSNcJtrbcIjxtoJhYeEpHjbKzRJ, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + vAVCGPtrNjGDjrOdbJKJKIzMtGRWA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new nZeIQQWnQohhanyhWEOObGRunlRc(xXSNcJtrbcIjxtoJhYeEpHjbKzRJ, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + vAVCGPtrNjGDjrOdbJKJKIzMtGRWA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new nZeIQQWnQohhanyhWEOObGRunlRc(xXSNcJtrbcIjxtoJhYeEpHjbKzRJ, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + vAVCGPtrNjGDjrOdbJKJKIzMtGRWA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new nZeIQQWnQohhanyhWEOObGRunlRc(xXSNcJtrbcIjxtoJhYeEpHjbKzRJ, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + vAVCGPtrNjGDjrOdbJKJKIzMtGRWA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new nZeIQQWnQohhanyhWEOObGRunlRc(xXSNcJtrbcIjxtoJhYeEpHjbKzRJ, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 8 + vAVCGPtrNjGDjrOdbJKJKIzMtGRWA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new nZeIQQWnQohhanyhWEOObGRunlRc(xXSNcJtrbcIjxtoJhYeEpHjbKzRJ, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 9 + vAVCGPtrNjGDjrOdbJKJKIzMtGRWA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0)
			};
			hats = new XXzPjtyGkCdrTJCzxAmvdoaeCgbHb[1]
			{
				new XXzPjtyGkCdrTJCzxAmvdoaeCgbHb(xXSNcJtrbcIjxtoJhYeEpHjbKzRJ, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 5 + vAVCGPtrNjGDjrOdbJKJKIzMtGRWA,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, MzjtgeoVWdDqVXjAHVuwxXHsqNrM)
			};
			accelerometers = new cMLqHjOwHUDOjQfvBFTMHfOrKnXJ[1]
			{
				new cMLqHjOwHUDOjQfvBFTMHfOrKnXJ(xXSNcJtrbcIjxtoJhYeEpHjbKzRJ, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					dataIndex = 19 + vAVCGPtrNjGDjrOdbJKJKIzMtGRWA,
					bitSize = 48
				}, 3, BGZjkkhPjbnXUqwrYFXykcITGgYV)
			};
			gyroscopes = new mtYfxDYuHHPxAtRRwphKvfBUCHvHA[1]
			{
				new mtYfxDYuHHPxAtRRwphKvfBUCHvHA(P_0.updateLoopSetting, xXSNcJtrbcIjxtoJhYeEpHjbKzRJ, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					dataIndex = 13 + vAVCGPtrNjGDjrOdbJKJKIzMtGRWA,
					bitSize = 48
				}, 3, 60, WOnaCmhfOXiFKdiBABprQlmRuEcc, poqiXzLxcAUuuHFaSwmlpJJzBRIk)
			};
			touchpads = new SRlmwzCpkDCiOPGALkZGROsZKGfx[1]
			{
				new SRlmwzCpkDCiOPGALkZGROsZKGfx(xXSNcJtrbcIjxtoJhYeEpHjbKzRJ, new SRlmwzCpkDCiOPGALkZGROsZKGfx.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					dataIndex = 35 + vAVCGPtrNjGDjrOdbJKJKIzMtGRWA,
					bitSize = 48
				}, 60, XTLptyOrbZVCnXqoborjKCnjIIXaA)
			};
			jGRwvsatcelbPqpKWXeEEfCBskcG = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			snrEuJeWnZBkaiYbgKaqMalIFkvz();
			QInKvSNmOmDpHelaCfPjVBGVAnwwA(ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Asynchronous);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < uxxJNXtDTuGSEbnmxGctApxefVyTB.Length)
			{
				return false;
			}
			sUTCeIUaBxgpxzKPRQWOEifyuNWi = (float)(timestamp - jGRwvsatcelbPqpKWXeEEfCBskcG);
			jGRwvsatcelbPqpKWXeEEfCBskcG = timestamp;
			uxxJNXtDTuGSEbnmxGctApxefVyTB.Write(inputReportPtr, inputReportLength, uxxJNXtDTuGSEbnmxGctApxefVyTB.Length);
			JEvFkeDtOnnLCBbavjaCggwNcXjf(uxxJNXtDTuGSEbnmxGctApxefVyTB);
			BfFlFEsTSUAfUUvTdPAshsshWTlD(uxxJNXtDTuGSEbnmxGctApxefVyTB, timestamp);
			QTwvMqRjxXBwLOoUpuezGnwheUbM[] array = axes;
			fFdQYFrdNURpCgeMocdkkITgDNLE(array, uxxJNXtDTuGSEbnmxGctApxefVyTB, timestamp);
			array = hats;
			fFdQYFrdNURpCgeMocdkkITgDNLE(array, uxxJNXtDTuGSEbnmxGctApxefVyTB, timestamp);
			array = accelerometers;
			fFdQYFrdNURpCgeMocdkkITgDNLE(array, uxxJNXtDTuGSEbnmxGctApxefVyTB, timestamp);
			array = gyroscopes;
			fFdQYFrdNURpCgeMocdkkITgDNLE(array, uxxJNXtDTuGSEbnmxGctApxefVyTB, timestamp);
			array = touchpads;
			fFdQYFrdNURpCgeMocdkkITgDNLE(array, uxxJNXtDTuGSEbnmxGctApxefVyTB, timestamp);
			byte num = uxxJNXtDTuGSEbnmxGctApxefVyTB[30 + vAVCGPtrNjGDjrOdbJKJKIzMtGRWA];
			byte b = (byte)(num & 0xF);
			if ((num & 0x10) != 0)
			{
				if (b <= 10)
				{
					eMJbyQORTCDjQKzRFQokFqJhixVh = MathTools.Clamp(b * 10 + 5, 0, 100);
					WJiPYtuCGGANRXEsaBWyiELbDEpB = MDgyZfHKqnywwyjcvKyENkluJptJ.Charging;
				}
				else
				{
					switch (b)
					{
					case 11:
						eMJbyQORTCDjQKzRFQokFqJhixVh = 100;
						WJiPYtuCGGANRXEsaBWyiELbDEpB = MDgyZfHKqnywwyjcvKyENkluJptJ.Full;
						break;
					case 14:
						eMJbyQORTCDjQKzRFQokFqJhixVh = 0;
						WJiPYtuCGGANRXEsaBWyiELbDEpB = MDgyZfHKqnywwyjcvKyENkluJptJ.Charging;
						break;
					default:
						eMJbyQORTCDjQKzRFQokFqJhixVh = 0;
						WJiPYtuCGGANRXEsaBWyiELbDEpB = MDgyZfHKqnywwyjcvKyENkluJptJ.Unknown;
						break;
					}
				}
			}
			else
			{
				switch (MathTools.Clamp((int)b, 0, 8))
				{
				case 0:
					eMJbyQORTCDjQKzRFQokFqJhixVh = 5;
					break;
				case 1:
					eMJbyQORTCDjQKzRFQokFqJhixVh = 20;
					break;
				case 2:
					eMJbyQORTCDjQKzRFQokFqJhixVh = 30;
					break;
				case 3:
					eMJbyQORTCDjQKzRFQokFqJhixVh = 45;
					break;
				case 4:
					eMJbyQORTCDjQKzRFQokFqJhixVh = 55;
					break;
				case 5:
					eMJbyQORTCDjQKzRFQokFqJhixVh = 70;
					break;
				case 6:
					eMJbyQORTCDjQKzRFQokFqJhixVh = 80;
					break;
				case 7:
					eMJbyQORTCDjQKzRFQokFqJhixVh = 95;
					break;
				case 8:
					eMJbyQORTCDjQKzRFQokFqJhixVh = 100;
					break;
				}
				WJiPYtuCGGANRXEsaBWyiELbDEpB = MDgyZfHKqnywwyjcvKyENkluJptJ.Discharging;
			}
			bPeFEUHIOMHKdDuXcTJRNCtNBhGOb();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualShock4Extension(this);
		}

		private void QInKvSNmOmDpHelaCfPjVBGVAnwwA(ScLWlPMAqEiHtjIIWbjHNAZkYXXI P_0)
		{
			if (TVMhjmJTTViLrpFFeqtubsmJBCSM)
			{
				NMBVxBMzQCdffdHsNpTpfukubhOh(P_0);
				TVMhjmJTTViLrpFFeqtubsmJBCSM = false;
			}
		}

		private bool NMBVxBMzQCdffdHsNpTpfukubhOh(ScLWlPMAqEiHtjIIWbjHNAZkYXXI P_0)
		{
			mUWwkzLzGIKzZmzAPLVNnKsFRRsI();
			bool result = DxKQsHMUjimGDZDiwMWnNauTftbu(P_0);
			if (ZUbkTTczDkCnxLLKKXJcZTDSjClM)
			{
				result = DxKQsHMUjimGDZDiwMWnNauTftbu(P_0);
				ZUbkTTczDkCnxLLKKXJcZTDSjClM = false;
			}
			return result;
		}

		private unsafe void mUWwkzLzGIKzZmzAPLVNnKsFRRsI()
		{
			byte b = 0;
			b |= 1;
			FkewUbERUvKKyNUnonGPKrjRYWDL = false;
			b |= 2;
			oXRgDGZqvbgaHkKKYWShHcIBxDMK = false;
			b |= 4;
			wRjtWSjcSambMtGliuLrRQAhMXhp = false;
			byte b2 = 128;
			if (knfveMFFTvGHAbgUYlWvZmxNodOl)
			{
				b2 |= 0x40;
			}
			if (tTXYxtgVfbbOCDPJhnEcnJgbiNHU)
			{
				b2 |= 4;
				tTXYxtgVfbbOCDPJhnEcnJgbiNHU = false;
			}
			if (knfveMFFTvGHAbgUYlWvZmxNodOl && LoeooaBrJVCvDUTvWKVFdqfZbywFA)
			{
				WiKcakiaPJFpivtAPInqGFqDAckSB[0] = 17;
				WiKcakiaPJFpivtAPInqGFqDAckSB[1] = b2;
				WiKcakiaPJFpivtAPInqGFqDAckSB[2] = 0;
				WiKcakiaPJFpivtAPInqGFqDAckSB[3] = b;
				WiKcakiaPJFpivtAPInqGFqDAckSB[4] = 0;
				WiKcakiaPJFpivtAPInqGFqDAckSB[5] = 0;
				WiKcakiaPJFpivtAPInqGFqDAckSB[6] = (byte)vibrationMotors[1].IqUCAdAupfvNpXYQVecZbYudoQHV;
				WiKcakiaPJFpivtAPInqGFqDAckSB[7] = (byte)vibrationMotors[0].IqUCAdAupfvNpXYQVecZbYudoQHV;
				WiKcakiaPJFpivtAPInqGFqDAckSB[8] = lights[0].iPItKgFTHBtGuRUztlDNfIvkSBLr;
				WiKcakiaPJFpivtAPInqGFqDAckSB[9] = lights[0].oEsbyWGtXRtvGKQJpHjyopbJnsxS;
				WiKcakiaPJFpivtAPInqGFqDAckSB[10] = lights[0].SMEmhyfAzxVApXucSoIcGVvjYfNI;
				WiKcakiaPJFpivtAPInqGFqDAckSB[11] = rJacPwOEUqUkcTWGeaRalRftIJjiA;
				WiKcakiaPJFpivtAPInqGFqDAckSB[12] = NTCZfjePRPQaTftVhGVAbNwXlZjB;
				int zJBuOJOStbVKiBMhUsKGVrrxvlom = GNlGHujReeuYliyMvDemNVGbJyoMA.ZJBuOJOStbVKiBMhUsKGVrrxvlom;
				uint bytes = gFIqPITVeiXqJrYsNBkXzfovCtUA.urIKOzzjyLFYObQwCaTOLxjfQzAH((byte*)(void*)WiKcakiaPJFpivtAPInqGFqDAckSB.Pointer, zJBuOJOStbVKiBMhUsKGVrrxvlom - 4, 162u);
				WiKcakiaPJFpivtAPInqGFqDAckSB.Write(bytes, zJBuOJOStbVKiBMhUsKGVrrxvlom - 4);
			}
			else
			{
				WiKcakiaPJFpivtAPInqGFqDAckSB[0] = 5;
				WiKcakiaPJFpivtAPInqGFqDAckSB[1] = b;
				WiKcakiaPJFpivtAPInqGFqDAckSB[2] = 0;
				WiKcakiaPJFpivtAPInqGFqDAckSB[4] = (byte)vibrationMotors[1].IqUCAdAupfvNpXYQVecZbYudoQHV;
				WiKcakiaPJFpivtAPInqGFqDAckSB[5] = (byte)vibrationMotors[0].IqUCAdAupfvNpXYQVecZbYudoQHV;
				WiKcakiaPJFpivtAPInqGFqDAckSB[6] = lights[0].iPItKgFTHBtGuRUztlDNfIvkSBLr;
				WiKcakiaPJFpivtAPInqGFqDAckSB[7] = lights[0].oEsbyWGtXRtvGKQJpHjyopbJnsxS;
				WiKcakiaPJFpivtAPInqGFqDAckSB[8] = lights[0].SMEmhyfAzxVApXucSoIcGVvjYfNI;
				WiKcakiaPJFpivtAPInqGFqDAckSB[9] = rJacPwOEUqUkcTWGeaRalRftIJjiA;
				WiKcakiaPJFpivtAPInqGFqDAckSB[10] = NTCZfjePRPQaTftVhGVAbNwXlZjB;
			}
		}

		private bool DxKQsHMUjimGDZDiwMWnNauTftbu(ScLWlPMAqEiHtjIIWbjHNAZkYXXI P_0)
		{
			buctVEfYRqPfyEmBuvCHTrgjoVN = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous:
				return bKTZcuiFPwLqYTgpDnTwbOZzFugl.WriteSync(GNlGHujReeuYliyMvDemNVGbJyoMA, 0);
			case ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Asynchronous:
				bKTZcuiFPwLqYTgpDnTwbOZzFugl.WriteAsync(GNlGHujReeuYliyMvDemNVGbJyoMA, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void BfFlFEsTSUAfUUvTdPAshsshWTlD(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[jmDsGHTZcpqtSJsMpoXgczxqtysj];
			buttons[0].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 0x10) != 0, P_1);
			buttons[1].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 0x20) != 0, P_1);
			buttons[2].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 0x40) != 0, P_1);
			buttons[3].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 0x80) != 0, P_1);
			b = P_0[zvDqoWDdkRekJKsbcmKjMdRGzXsZ];
			buttons[4].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 1) != 0, P_1);
			buttons[5].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 2) != 0, P_1);
			buttons[6].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 4) != 0, P_1);
			buttons[7].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 8) != 0, P_1);
			buttons[8].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 0x10) != 0, P_1);
			buttons[9].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 0x20) != 0, P_1);
			buttons[10].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 0x40) != 0, P_1);
			buttons[11].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 0x80) != 0, P_1);
			b = P_0[xtBbsIiGekSNfjFjHsqGdadzrWxvB];
			buttons[12].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 1) != 0, P_1);
			buttons[13].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 2) != 0, P_1);
		}

		private void fFdQYFrdNURpCgeMocdkkITgDNLE(QTwvMqRjxXBwLOoUpuezGnwheUbM[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].nbdaOhPzrnnznbxNEnDgLWCrHhfx(P_1, P_2);
			}
		}

		private void snrEuJeWnZBkaiYbgKaqMalIFkvz()
		{
			if (isVibrating && ReInput.realTime >= buctVEfYRqPfyEmBuvCHTrgjoVN)
			{
				TVMhjmJTTViLrpFFeqtubsmJBCSM = true;
				FkewUbERUvKKyNUnonGPKrjRYWDL = true;
			}
		}

		private void JEvFkeDtOnnLCBbavjaCggwNcXjf(NativeBuffer P_0)
		{
			if (LoeooaBrJVCvDUTvWKVFdqfZbywFA)
			{
				ushort num = uxxJNXtDTuGSEbnmxGctApxefVyTB.ReadUShort(10 + vAVCGPtrNjGDjrOdbJKJKIzMtGRWA);
				float num3;
				if (num != dZCwMmNEpPowXjcgUCQwWEWUxEHd)
				{
					int num2 = ((num >= dZCwMmNEpPowXjcgUCQwWEWUxEHd) ? (num - dZCwMmNEpPowXjcgUCQwWEWUxEHd) : (num + 65535 - dZCwMmNEpPowXjcgUCQwWEWUxEHd));
					num3 = (float)num2 / 187500f;
				}
				else
				{
					int num2 = 0;
					num3 = 0f;
				}
				dZCwMmNEpPowXjcgUCQwWEWUxEHd = num;
				uFmFMZoIWLuBDsElYazEHWWcBXQJA = num3;
			}
		}

		private void bPeFEUHIOMHKdDuXcTJRNCtNBhGOb()
		{
			if (LoeooaBrJVCvDUTvWKVFdqfZbywFA)
			{
				_ = uFmFMZoIWLuBDsElYazEHWWcBXQJA;
				_ = 0f;
				Vector3 vector = uEvgISRXgtqoNTcLRaULwoQpnzpk(new Vector3(gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[0], gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[1], gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[2]), uFmFMZoIWLuBDsElYazEHWWcBXQJA);
				uhJFZIbrzrHSIJiAEFyLysJtHPVcA(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].VNYkooeoXLtNVzxyiQWNaRkcrEnm[0] * -1f, accelerometers[0].VNYkooeoXLtNVzxyiQWNaRkcrEnm[1] * -1f, accelerometers[0].VNYkooeoXLtNVzxyiQWNaRkcrEnm[2] * -1f);
				eyjOzxWcXEvVdcbOyifSMvanirajA(vector2, vector);
			}
		}

		private static bool uhJFZIbrzrHSIJiAEFyLysJtHPVcA(ref Vector3 P_0)
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

		private void eyjOzxWcXEvVdcbOyifSMvanirajA(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && PbbNvTcgrcpTadDlAFfJdJeAmEACb(P_0, out var onhacIqtcvaJcTxEGneoJCqHqwpc2))
			{
				Quaternion a = OAEKLVRJLZOkkGpCnClOKaLvwXDUA * quaternion;
				if (!EfeBQRmMhhhHGqGFDVRMiscLIgPr)
				{
					EfeBQRmMhhhHGqGFDVRMiscLIgPr = true;
					hlPPVDWDQkEZjirTjFukBNDoQtLF = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					lkPshkLRKtqUUDkeOxuxKRmdRhEu = OAEKLVRJLZOkkGpCnClOKaLvwXDUA;
				}
				hlPPVDWDQkEZjirTjFukBNDoQtLF *= quaternion;
				lkPshkLRKtqUUDkeOxuxKRmdRhEu *= quaternion;
				Quaternion b;
				if ((onhacIqtcvaJcTxEGneoJCqHqwpc2 & onhacIqtcvaJcTxEGneoJCqHqwpc.XZ) != onhacIqtcvaJcTxEGneoJCqHqwpc.None)
				{
					b = dKpykIbNHWKaypvIGGLNSHshhoX(P_0, a.eulerAngles.y);
				}
				else if ((onhacIqtcvaJcTxEGneoJCqHqwpc2 & onhacIqtcvaJcTxEGneoJCqHqwpc.Y) != onhacIqtcvaJcTxEGneoJCqHqwpc.None)
				{
					b = dlOjKJUEaQDAxbfXTCRmoStLYUxT(P_0);
					Vector3 vector = lkPshkLRKtqUUDkeOxuxKRmdRhEu * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				OAEKLVRJLZOkkGpCnClOKaLvwXDUA = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				OAEKLVRJLZOkkGpCnClOKaLvwXDUA *= quaternion;
				if (EfeBQRmMhhhHGqGFDVRMiscLIgPr)
				{
					EfeBQRmMhhhHGqGFDVRMiscLIgPr = false;
				}
			}
		}

		private static Quaternion mlkZlkjbGwVNUltBahlMeaZdEzcI(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = DwpMDVuXaSUDFPSOXuCRQQtJLSrG(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 DwpMDVuXaSUDFPSOXuCRQQtJLSrG(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion OATdtuUeHDgeYFPhJKuXFSripEyDb(Quaternion P_0, quGSAGQhBznZMxjzywmSOenfhUlo P_1)
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

		private float vAhbhqWXgkebjqdAvPYtvZjodWWg(float P_0, float P_1)
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

		private Vector3 XPdbyrmDZNKIiSmsEPmrjRJHCXcA(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion dKpykIbNHWKaypvIGGLNSHshhoX(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion dlOjKJUEaQDAxbfXTCRmoStLYUxT(Vector3 P_0, float P_1 = 0f)
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

		private float OeUioRJoSmWvHdFFQRrNfUXgRWnYb(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool AdkYcHwoPRpNqQZKdbWRMQkoMeYt(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool PbbNvTcgrcpTadDlAFfJdJeAmEACb(Vector3 P_0, out onhacIqtcvaJcTxEGneoJCqHqwpc P_1)
		{
			P_0.Normalize();
			P_1 = onhacIqtcvaJcTxEGneoJCqHqwpc.None;
			bool result = false;
			if (SCdvtSAKKkDCebGONivQLlLedcSJA(P_0))
			{
				result = true;
				P_1 |= onhacIqtcvaJcTxEGneoJCqHqwpc.XZ;
			}
			if (FIUEEVjCKvDLahHWFCRnTBHUwuZDc(P_0))
			{
				result = true;
				P_1 |= onhacIqtcvaJcTxEGneoJCqHqwpc.Y;
			}
			return result;
		}

		private bool SCdvtSAKKkDCebGONivQLlLedcSJA(Vector3 P_0)
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

		private bool FIUEEVjCKvDLahHWFCRnTBHUwuZDc(Vector3 P_0)
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

		private Vector3 XDZaKYCSAnWgxHAoPKoHwvREgSmkA(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 VozKbDrSHAetmZlKlJVFviRadUed(RingBuffer<mtYfxDYuHHPxAtRRwphKvfBUCHvHA.kHgxaIUQumRSmtlkwfNRJICwIywm> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				mtYfxDYuHHPxAtRRwphKvfBUCHvHA.kHgxaIUQumRSmtlkwfNRJICwIywm kHgxaIUQumRSmtlkwfNRJICwIywm = P_0[i];
				result += uEvgISRXgtqoNTcLRaULwoQpnzpk(kHgxaIUQumRSmtlkwfNRJICwIywm.CqaRbtXIhghqiCpvcMOWeYBPOEnjA, kHgxaIUQumRSmtlkwfNRJICwIywm.unCFBcqDYBEiWsYKeCdlMEUrtnuJ);
			}
			return result;
		}

		private Vector3 uEvgISRXgtqoNTcLRaULwoQpnzpk(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int MzjtgeoVWdDqVXjAHVuwxXHsqNrM(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void BGZjkkhPjbnXUqwrYFXykcITGgYV(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void WOnaCmhfOXiFKdiBABprQlmRuEcc(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float poqiXzLxcAUuuHFaSwmlpJJzBRIk()
		{
			return uFmFMZoIWLuBDsElYazEHWWcBXQJA;
		}

		private void XTLptyOrbZVCnXqoborjKCnjIIXaA(NativeBuffer P_0, SRlmwzCpkDCiOPGALkZGROsZKGfx.TouchData[] P_1)
		{
			int num = 35 + vAVCGPtrNjGDjrOdbJKJKIzMtGRWA;
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
			P_1[0].touchId = AAjPQVYFeoFOtdnxXAuLOCwlZldoA(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = AAjPQVYFeoFOtdnxXAuLOCwlZldoA(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int AAjPQVYFeoFOtdnxXAuLOCwlZldoA(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				BlmABVoDdtKGLFcSAIvUZWHOpzZl[P_0] = -1;
				SHSOxUdlNKGPeFinqEpmgfDHbXPlA[P_0] = P_2;
				return -1;
			}
			if (P_2 != SHSOxUdlNKGPeFinqEpmgfDHbXPlA[P_0])
			{
				int num = ooDAsUabpORtyNPgQNAaKTaCRFohA;
				if (ooDAsUabpORtyNPgQNAaKTaCRFohA == int.MaxValue)
				{
					ooDAsUabpORtyNPgQNAaKTaCRFohA = 0;
				}
				else
				{
					ooDAsUabpORtyNPgQNAaKTaCRFohA++;
				}
				SHSOxUdlNKGPeFinqEpmgfDHbXPlA[P_0] = P_2;
				BlmABVoDdtKGLFcSAIvUZWHOpzZl[P_0] = num;
				return num;
			}
			return BlmABVoDdtKGLFcSAIvUZWHOpzZl[P_0];
		}

		private void gzoazKddmYJQSflodezoPcAdZtgXb()
		{
			oXRgDGZqvbgaHkKKYWShHcIBxDMK = true;
			ZWJkFgDZOGKmMeeIzKGtrdSmoQyN();
		}

		private void idGdYzWLhKiaNpeVsfqkGvRMOmhdA()
		{
			wRjtWSjcSambMtGliuLrRQAhMXhp = true;
			ZWJkFgDZOGKmMeeIzKGtrdSmoQyN();
		}

		private void vdtXDnqAjfWVtcoyUOXkiVUeqWgs()
		{
			FkewUbERUvKKyNUnonGPKrjRYWDL = true;
			ZWJkFgDZOGKmMeeIzKGtrdSmoQyN();
		}

		private void ZWJkFgDZOGKmMeeIzKGtrdSmoQyN()
		{
			TVMhjmJTTViLrpFFeqtubsmJBCSM = true;
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
				QInKvSNmOmDpHelaCfPjVBGVAnwwA(ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous);
				if (uxxJNXtDTuGSEbnmxGctApxefVyTB != null)
				{
					uxxJNXtDTuGSEbnmxGctApxefVyTB.Dispose();
				}
				if (WiKcakiaPJFpivtAPInqGFqDAckSB != null)
				{
					WiKcakiaPJFpivtAPInqGFqDAckSB.Dispose();
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
		private static void fHRLwrHAEqiBNVaRaaLCDYjFxfvLA(object P_0)
		{
			Logger.Log(P_0, requiredThreadSafety: true);
		}
	}
}
