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
		private enum axieDAxnZmHYABcbJMxGvrZSTDco
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum qtDramHldnvjBrevhEimqxaaetdw
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private static class eBjxTVaRNvKjmBwKXMDsIBJTcTsU
		{
			private const uint gWpsqzezSojGPAFNDxTPQKvTaZHp = 3988292384u;

			public unsafe static uint yzoXJlAeXWKuKHiinpHYkFBARNDl(byte* P_0, int P_1, uint P_2)
			{
				return ~CVWXcyOGNLFKxUAGKbkCgCEZghDGA(CVWXcyOGNLFKxUAGKbkCgCEZghDGA(uint.MaxValue, (byte*)(&P_2), 1, 3988292384u), P_0, P_1, 3988292384u);
			}

			public unsafe static uint ybMeTvyeLaoQjrpnjtscYWNObNoR(uint P_0, byte* P_1, int P_2)
			{
				return CVWXcyOGNLFKxUAGKbkCgCEZghDGA(P_0, P_1, P_2, 3988292384u);
			}

			private unsafe static uint CVWXcyOGNLFKxUAGKbkCgCEZghDGA(uint P_0, byte* P_1, int P_2, uint P_3)
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

		private enum YJApjBaeVmbmQIwlIFGXaThBAuzb
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			Unknown = 3
		}

		private const float gQbNefWzOCiIfoiGGiiBernYxZBTA = 4f;

		private const int yLEuPdigoEWZoPPKhGLTVJjlMZIL = 14;

		private const int hMkTzQNMnjFXWxDYJFjyagFSWWwbA = 2;

		private const int UNoAinkxNZLljRvYKYtaUeqHGIMm = 0;

		private const int RwFnGLSwsIKOHfSCdDnUTnBAbHjn = 1912;

		private const int gmpzRTPUBJdqTbybQwYtvVOhaZTc = 0;

		private const int dZXdgbGOQSxbzmAVhiTSpYEYuNgjA = 941;

		private const bool MlkBBwVwzKhEnDByzksZYwMBTztS = false;

		private const bool wcSbezIUDnWqiGakkSGCdlbSTTeDA = true;

		private const float SeAHHNpOhCxKhZWAQNOMPfryKoRA = 2.5f;

		private const int tFoDhZJsXObrChfpFuoxoSEUBKcLA = 0;

		private const int wzNQjYjIdLuGODEUIEVCchuuVINZ = 0;

		private const int WoGLnsRMmUIjHxJiANfdcXnPkYEN = 1;

		private const int omZWKrVynwdvMnNlyDPvwYpmqVrV = 0;

		private const int YYxgAXNUzTrTGJrznnHQcvqdErz = 0;

		private const int JXlfpeONXDiTcgHEhpQOrDVkhjiU = 0;

		private const int TyiTmqGnoeuPqlXFcryXTFIsycwl = 1;

		private const int KvzFlZwITehXwhIqxlLfSGilSHrK = 17;

		private const int UfgPrLlOJAgOYOkmXTHogLrPKqoF = 0;

		private const int vjuEcEEzCUVHAFPgvVzyMhGCInZI = 2;

		private const int YRfgsnDqAjOdbWmBhNOxJitYCYjgb = 64;

		private const int xceenBAZIuYtYSqPitlCyuTRWlXf = 78;

		private const byte LTdMCWnZuNMMWCQqlXmkSelldhcJ = 17;

		private const byte lupJAApdAKEqNVWRbXkOUjKgOdMl = 5;

		private const byte BSZSXDAZsyqKiikEqaZAEergniVvA = 2;

		private const byte KWjBWRCwdPraQEBwgPrDOdRhygLOA = 37;

		private const byte sDPynnwOfqiGtYgaBifiesXFzQeh = 5;

		private const byte rEaHEGhUxeKzSJDeHkooiosgBwbAc = 41;

		private const byte XJpvjGpIBLDDhbCRxpgpOmwSOnsKA = 163;

		private const byte ANPrCoJvFMZObWnjajuHtSUvZozB = 49;

		private const byte xSrrgPdypOTwnmcUTPXrtdYfOceR = 18;

		private const byte MwWDaQdILmsgAeliJbuJFeJeYgzm = 16;

		private const byte zLRbjfaTjbIBHLMXyKRYNXIhCLOhA = 161;

		private const byte PFKfjWlgeBbpJjqKDHMvuhINJWZIA = 162;

		private const byte sFLuRsNUaaDnXRYCAWdiCoJqDlUgA = 163;

		private const int pREHqeiCSIbcXBzvJnawhUqgpXTO = 1;

		private const int mrNwzeAHwUbwCuxlKlumIHAaiEav = 2;

		private const int rzctHgKVqJaqcgNaMlOqMyqMxwTE = 3;

		private const int UeIOXRqTNuvJOkOqCUnPNVYQoiox = 4;

		private const int qITkcpxVWHEdopJkvKJFtVkTZFfg = 8;

		private const int MaJsMQKbwesnKdlFqEraNFLIRqZA = 9;

		private const int OlLHrylsakmKdvryvEoavmUEzmuc = 5;

		private const int UkzAyCYVjoWkaEoaSaSmhYhOvmyT = 19;

		private const int pSXKhTuqkJERPJiXPpDdgxIrfEVxA = 13;

		private const int vfqipkEvVteJZpjflhhfbpiUiXGlA = 35;

		private const int YbhHZxpouPVQGEbsBbtyftKzauHgA = 5;

		private const int sxvALtKkyjxCjvTCAuSbACzShZIdb = 6;

		private const int xeUrbZfEKQgHsOssCPQrYtmhhEoc = 7;

		private const int bSvuWcQiXpoCpHrKTsYgLfPVeMcK = 10;

		private const int vMeXPEwqDmSdZnPgIkhMjekBMyKc = 30;

		private const int woFEEfgyGSTcYHtDzELIasTTHBUzA = 27;

		private const byte wPONUEFPPdAgzOCJQMqDCkazFMZFA = 200;

		private const byte djVSMteBNfWGkykmLvllCpeNAdPK = 53;

		private const byte cdhkgAXBHOsXHarhVMmFSRCxFbPCA = byte.MaxValue;

		private const byte kPSCcnpcwBtYuKmxWIsmICFHgiai = 0;

		private const bool wTruJOvOQFqNuDlgYeXufivIEblD = true;

		private const int eZJCNvvtXfwmOMPkqSZRqbGDqFHA = 60;

		private const int wOOzfEFOsdcQUPLMPqkeuoUekubv = 60;

		private const int YAuXBiugfINIYmjdkERXPJMaDFll = 187500;

		private const float BowwPOuvmaFurJprgxtUkiJjgMzV = 8192f;

		private const float cUNJimCtdqhjZFARulijVLXHnbvO = 0.0010652969f;

		private const float RoIwhRQLyDubKEkqWczZovQZhpCl = 0.06103702f;

		private const bool DTmGnUSbamlIXRSqNOcyFhdxVFBG = true;

		private const bool JEFpDpnRcHcxGqbBRLMNLnLjumWL = true;

		private const bool ccjpbIhUFknypfJvDAukSTfrXarL = true;

		private const bool McltJUOupIdMAvEcjtzcBLXktCtD = true;

		private const float yXJgLdNaWfdexefioFQJEFxwBMzP = 4096f;

		private const float VIWaAIDFeqwNHUxPJUJAKLglwBoV = 16384f;

		private const float mqooMKqtdzTpRVVycQuUaMFqdFXr = 16777216f;

		private const float anrlSIMrwcDNGUCWfAziDudYJeFmA = 268435460f;

		private const float RWBzZdcuzwNCvwiIdKmgWjkSLtyo = 0.01999998f;

		private const float rykAEjdulKwMcsuQDdqvlQplaaGSA = 8192f;

		private const float ZzTLRCrHXQcwpHugyaUOLHaNjnQBA = 0.98f;

		private const float BnCIUswPTnzgGPYNobAyZdyyEEDeA = 45f;

		private const float GoRbEfDwdMbzNGeqrMorbSoZeBbWA = 20f;

		private readonly IHIDDevice xizofmTNNdijElJjozUyUonAbIxdA;

		private readonly HIDProperties JFquXIflkriIZOipJdFTBswHJwZab;

		private readonly bool yGRmqSyzPwJaYNFOtGcrgaBssjVV;

		private readonly RWcHFhaLOdObDBlAnlGahPsMjmIp OcBoIsjiFYPlLaQezcnAlcMjpjBA;

		private readonly int xFGzYmwUFonkgGYovkUAPbvzwzJl;

		private readonly int OBLsmnvQfzwshSyAgOPaWfloKjTG;

		private readonly bool LhEafmgrXGEsPJipdUORmCDoHhzdb;

		private readonly byte zqmUgBQmthBadXPwIROOCkBWJlKl;

		private readonly int hpxNrBKDTkEvdZgnAJrJpgFreXOv;

		private readonly int xJvFXXDeeoUcMCrCSHxuXBRZAcxgb;

		private readonly int jypdpSeeaMWlDfIbNKLtjMlvRAdZA;

		private readonly int vGhPtCtlsjAQjfdnJNxUWFVErXobA;

		private readonly NativeBuffer gZJxODUMDjoDYZnwShsjGYBWOYnG;

		private readonly NativeBuffer URuLveJKDAosaZLQangguREtfblW;

		private readonly fSMyuzvVmAACQsIYyLcgNLStbZVN AgHRAouoabENbHMKIRxmEoyCjhhMA;

		private readonly byte[] pvIfHVflUZNdyuOAhURTyHCdnvTT = new byte[1] { 162 };

		private bool NwuzqwsJRMBKnXkZTZuuOkQaZVBn;

		private bool LxHWALHQXbSmfjQQzlQukZjjTVin;

		private double nFYeQRrPWICprSHuyoBCiEXZEbSo;

		private int qGzoIhlHiTQEIcBEiJQymduEvSCD;

		private YJApjBaeVmbmQIwlIFGXaThBAuzb KDIQwIRiGFTDTleEFkKGDPkMMGNv = YJApjBaeVmbmQIwlIFGXaThBAuzb.Unknown;

		private Quaternion QrczIFkFLSEjkfgWAMyMaPzKUKMwA = Quaternion.identity;

		private ushort jnmvluoYGWlyLZyVpJDaxBsbmNWf;

		private float wqCwLBBFYUyUDGahdAwEpRoTFMDbA;

		private double nMvhUxHjlhySLYPftWZKnMaghQzj;

		private float evbDRMzMNkhnhGDHelFOTtTZSzJNA;

		private bool LJOFDnnuQyqFcpHpJZTHvzFaRJCV;

		private bool exzdfQsaccEfFCYUxHXhIcoeQqLvA;

		private bool qeDGPAAXAzHaYHmjXHObmcuQoEeP;

		private bool jdzkobPfjaQHCppDAZDoSGUGEWKDA;

		private byte nDQWIyjDSbvPsjNMLOOeChRMAmoI;

		private byte NUsKtbVvTOTugTJhYBjLMpvsyGMm;

		private Quaternion bHvKJffMLpBvQSXJQOweapyNXMrb = Quaternion.identity;

		private Quaternion vQhggiceWgFPCEnonQzdzvUEpiBdb = Quaternion.identity;

		private bool UiGLmZFhrmSrOCDNaCLMJDKwHtUP;

		private int cmxNnSSHdVBeytkqrCFiyOYvhOfT;

		private int[] JeMHiLFXluJcLpmQpeEKyxtbuJAh = new int[2];

		private int[] AlecwUOKNFZWcdntFSiwWkfqKMGn = new int[2];

		private bool isVibrating
		{
			get
			{
				for (int i = 0; i < base.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EVibrationMotorCount; i++)
				{
					if (vibrationMotors[i].OZyBFjtdbmGNdxlWalLBCWEMJQKG > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		float IDriver_DualShock4.BatteryLevel => qGzoIhlHiTQEIcBEiJQymduEvSCD;

		bool IDriver_DualShock4.BatteryCharging => KDIQwIRiGFTDTleEFkKGDPkMMGNv == YJApjBaeVmbmQIwlIFGXaThBAuzb.Charging;

		float IDriver_DualShock4.LeftMotor
		{
			get
			{
				return vibrationMotors[0].FdnMOOHJyNvOIoiYNtolKFnibDkk;
			}
			set
			{
				vibrationMotors[0].FdnMOOHJyNvOIoiYNtolKFnibDkk = value;
			}
		}

		float IDriver_DualShock4.RightMotor
		{
			get
			{
				return vibrationMotors[1].FdnMOOHJyNvOIoiYNtolKFnibDkk;
			}
			set
			{
				vibrationMotors[1].FdnMOOHJyNvOIoiYNtolKFnibDkk = value;
			}
		}

		float IDriver_DualShock4.LightColorR
		{
			get
			{
				return lights[0].vPYcTtJfKLscQqLvSiAHqbypUWfkA;
			}
			set
			{
				lights[0].vPYcTtJfKLscQqLvSiAHqbypUWfkA = value;
			}
		}

		float IDriver_DualShock4.LightColorG
		{
			get
			{
				return lights[0].ecnCyygCnjapnBhBOGwNyniPFYSD;
			}
			set
			{
				lights[0].ecnCyygCnjapnBhBOGwNyniPFYSD = value;
			}
		}

		float IDriver_DualShock4.LightColorB
		{
			get
			{
				return lights[0].SshhImoBPrhHQgNlYXqOEZnoeDjs;
			}
			set
			{
				lights[0].SshhImoBPrhHQgNlYXqOEZnoeDjs = value;
			}
		}

		float IDriver_DualShock4.LightFlashOnDuration
		{
			get
			{
				return (int)nDQWIyjDSbvPsjNMLOOeChRMAmoI;
			}
			set
			{
				nDQWIyjDSbvPsjNMLOOeChRMAmoI = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				mpcZQrtkrJxNFRhFRxGaKXthnpwl();
				if (nDQWIyjDSbvPsjNMLOOeChRMAmoI == 0 && NUsKtbVvTOTugTJhYBjLMpvsyGMm == 0)
				{
					LxHWALHQXbSmfjQQzlQukZjjTVin = true;
				}
			}
		}

		float IDriver_DualShock4.LightFlashOffDuration
		{
			get
			{
				return (int)NUsKtbVvTOTugTJhYBjLMpvsyGMm;
			}
			set
			{
				NUsKtbVvTOTugTJhYBjLMpvsyGMm = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				mpcZQrtkrJxNFRhFRxGaKXthnpwl();
				if (nDQWIyjDSbvPsjNMLOOeChRMAmoI == 0 && NUsKtbVvTOTugTJhYBjLMpvsyGMm == 0)
				{
					LxHWALHQXbSmfjQQzlQukZjjTVin = true;
				}
			}
		}

		Vector3 IDriver_DualShock4.AccelerometerValue => FtzgVWnzOkFdtoMucYpLZlztCBvkA(accelerometers[0].JLwYhuHtTQDoTLjyTSPTHSWTgggN);

		Vector3 IDriver_DualShock4.AccelerometerValueRaw => new Vector3(accelerometers[0].JLwYhuHtTQDoTLjyTSPTHSWTgggN[0], accelerometers[0].JLwYhuHtTQDoTLjyTSPTHSWTgggN[1], accelerometers[0].JLwYhuHtTQDoTLjyTSPTHSWTgggN[2]);

		Vector3 IDriver_DualShock4.GyroscopeValue => BaRFSTQSEXngqhxzMUiTCbMTuYtH(gyroscopes[0].jAaKjjHKnrIKIhusFAEDraeMOtzLA);

		Vector3 IDriver_DualShock4.GyroscopeValueRaw => new Vector3(gyroscopes[0].NKyhjzEpAZtHNcjqwLDpmKcEdGoA[0], gyroscopes[0].NKyhjzEpAZtHNcjqwLDpmKcEdGoA[1], gyroscopes[0].NKyhjzEpAZtHNcjqwLDpmKcEdGoA[2]);

		Vector3 IDriver_DualShock4.LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[0], gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[1], gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[2]);
				return qMPdZOmqGmdOLfXjgNfPVhiGkwqF(vector, wqCwLBBFYUyUDGahdAwEpRoTFMDbA);
			}
		}

		Vector3 IDriver_DualShock4.LastGyroscopeValueRaw => new Vector3(gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[0], gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[1], gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[2]);

		Quaternion IDriver_DualShock4.Orientation => QrczIFkFLSEjkfgWAMyMaPzKUKMwA;

		int IDriver_DualShock4.MaxTouches => 2;

		ushort IHIDControllerExtension.vendorId => JFquXIflkriIZOipJdFTBswHJwZab.vendorId;

		ushort IHIDControllerExtension.productId => JFquXIflkriIZOipJdFTBswHJwZab.productId;

		string IHIDControllerExtension.productName => JFquXIflkriIZOipJdFTBswHJwZab.productName;

		string IHIDControllerExtension.manufacturer => JFquXIflkriIZOipJdFTBswHJwZab.manufacturer;

		ushort IHIDControllerExtension.usagePage => JFquXIflkriIZOipJdFTBswHJwZab.usagePage;

		ushort IHIDControllerExtension.usage => JFquXIflkriIZOipJdFTBswHJwZab.usage;

		public void ResetOrientation()
		{
			QrczIFkFLSEjkfgWAMyMaPzKUKMwA = Quaternion.identity;
			UiGLmZFhrmSrOCDNaCLMJDKwHtUP = false;
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
				if (touchpads[0].XBRNyXRXsysdNperzXpLQXmtHcpj[i].isTouching)
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
			return touchpads[0].XBRNyXRXsysdNperzXpLQXmtHcpj[index].isTouching;
		}

		bool IDriver_DualShock4.IsTouchingAtIndex(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtIndex
			return this.IsTouchingAtIndex(index);
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return touchpads[0].GsLURatUIUplCESYptaZWyOBgXfU(touchId);
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
			return touchpads[0].XBRNyXRXsysdNperzXpLQXmtHcpj[index].touchId;
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
			YbNvcxfeAOXeGxhYaCCOmgMgdTsT.TouchData[] xBRNyXRXsysdNperzXpLQXmtHcpj = touchpads[0].XBRNyXRXsysdNperzXpLQXmtHcpj;
			if (!xBRNyXRXsysdNperzXpLQXmtHcpj[index].isTouching)
			{
				return false;
			}
			position.x = xBRNyXRXsysdNperzXpLQXmtHcpj[index].positionX;
			position.y = xBRNyXRXsysdNperzXpLQXmtHcpj[index].positionY;
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
			if (!touchpads[0].GsLURatUIUplCESYptaZWyOBgXfU(touchId))
			{
				return false;
			}
			YbNvcxfeAOXeGxhYaCCOmgMgdTsT.TouchData[] xBRNyXRXsysdNperzXpLQXmtHcpj = touchpads[0].XBRNyXRXsysdNperzXpLQXmtHcpj;
			for (int i = 0; i < xBRNyXRXsysdNperzXpLQXmtHcpj.Length; i++)
			{
				if (xBRNyXRXsysdNperzXpLQXmtHcpj[i].isTouching)
				{
					position.x = xBRNyXRXsysdNperzXpLQXmtHcpj[i].positionX;
					position.y = xBRNyXRXsysdNperzXpLQXmtHcpj[i].positionY;
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
			YbNvcxfeAOXeGxhYaCCOmgMgdTsT.TouchData[] xBRNyXRXsysdNperzXpLQXmtHcpj = touchpads[0].XBRNyXRXsysdNperzXpLQXmtHcpj;
			if (!xBRNyXRXsysdNperzXpLQXmtHcpj[index].isTouching)
			{
				return false;
			}
			positionX = xBRNyXRXsysdNperzXpLQXmtHcpj[index].positionAbsX;
			positionY = xBRNyXRXsysdNperzXpLQXmtHcpj[index].positionAbsY;
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
			if (!touchpads[0].GsLURatUIUplCESYptaZWyOBgXfU(touchId))
			{
				return false;
			}
			YbNvcxfeAOXeGxhYaCCOmgMgdTsT.TouchData[] xBRNyXRXsysdNperzXpLQXmtHcpj = touchpads[0].XBRNyXRXsysdNperzXpLQXmtHcpj;
			for (int i = 0; i < xBRNyXRXsysdNperzXpLQXmtHcpj.Length; i++)
			{
				if (xBRNyXRXsysdNperzXpLQXmtHcpj[i].isTouching)
				{
					positionX = xBRNyXRXsysdNperzXpLQXmtHcpj[i].positionAbsX;
					positionY = xBRNyXRXsysdNperzXpLQXmtHcpj[i].positionAbsY;
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
			nDQWIyjDSbvPsjNMLOOeChRMAmoI = 0;
			NUsKtbVvTOTugTJhYBjLMpvsyGMm = 0;
			NwuzqwsJRMBKnXkZTZuuOkQaZVBn = true;
			LxHWALHQXbSmfjQQzlQukZjjTVin = true;
			qeDGPAAXAzHaYHmjXHObmcuQoEeP = true;
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
				vibrationMotors[i].OZyBFjtdbmGNdxlWalLBCWEMJQKG = 0;
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
			xizofmTNNdijElJjozUyUonAbIxdA = P_0.hidDevice;
			JFquXIflkriIZOipJdFTBswHJwZab = xizofmTNNdijElJjozUyUonAbIxdA.properties;
			xFGzYmwUFonkgGYovkUAPbvzwzJl = P_0.hatZeroValue;
			OBLsmnvQfzwshSyAgOPaWfloKjTG = P_0.hatSpan;
			OcBoIsjiFYPlLaQezcnAlcMjpjBA = P_0.connectionType;
			yGRmqSyzPwJaYNFOtGcrgaBssjVV = OcBoIsjiFYPlLaQezcnAlcMjpjBA == RWcHFhaLOdObDBlAnlGahPsMjmIp.Bluetooth;
			if (yGRmqSyzPwJaYNFOtGcrgaBssjVV)
			{
				JFquXIflkriIZOipJdFTBswHJwZab.maxOutputReportLength = 78;
			}
			if (JFquXIflkriIZOipJdFTBswHJwZab.maxOutputReportLength < 23)
			{
				JFquXIflkriIZOipJdFTBswHJwZab.maxOutputReportLength = 23;
			}
			gZJxODUMDjoDYZnwShsjGYBWOYnG = new NativeBuffer(64);
			URuLveJKDAosaZLQangguREtfblW = new NativeBuffer(JFquXIflkriIZOipJdFTBswHJwZab.maxOutputReportLength);
			AgHRAouoabENbHMKIRxmEoyCjhhMA = new fSMyuzvVmAACQsIYyLcgNLStbZVN(URuLveJKDAosaZLQangguREtfblW.Pointer, URuLveJKDAosaZLQangguREtfblW.Length, JFquXIflkriIZOipJdFTBswHJwZab.maxOutputReportLength);
			lights = new ynsNWLqHUfktHdifyKAAkOjoGzXj[1]
			{
				new ynsNWLqHUfktHdifyKAAkOjoGzXj(11, 24, 28)
			};
			lights[0].TeuAgAnGMXibjdWBvyDVpORKtNep += qTQLsKAAeFxDKRUiRUgmXqceukno;
			exzdfQsaccEfFCYUxHXhIcoeQqLvA = true;
			vibrationMotors = new zjaGFxWobEvzfkfnDIafHMDeSyQp[2]
			{
				new zjaGFxWobEvzfkfnDIafHMDeSyQp(0, 255),
				new zjaGFxWobEvzfkfnDIafHMDeSyQp(0, 255)
			};
			vibrationMotors[0].YeWjEpYFmiaErkTfuJQxcFREviDXA += jrPIEjFkfcDUjQoafDIiZwmBjNxgA;
			vibrationMotors[1].YeWjEpYFmiaErkTfuJQxcFREviDXA += jrPIEjFkfcDUjQoafDIiZwmBjNxgA;
			if (xizofmTNNdijElJjozUyUonAbIxdA.GetHidFeatureData(2, 37, 1000, 3) == null)
			{
				throw new Exception();
			}
			jdzkobPfjaQHCppDAZDoSGUGEWKDA = true;
			if (yGRmqSyzPwJaYNFOtGcrgaBssjVV)
			{
				LhEafmgrXGEsPJipdUORmCDoHhzdb = true;
				AgHRAouoabENbHMKIRxmEoyCjhhMA.willCnjUwWfQuxoRCXqRPFFjILNI |= ldlbIDlGDTKMuLXyUtjBATffkGXI.WriteDirect;
				LhEafmgrXGEsPJipdUORmCDoHhzdb = ZEnCJHzGrZfqpFFVkWkvYBIZKeXx(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous);
				if (!LhEafmgrXGEsPJipdUORmCDoHhzdb)
				{
					AgHRAouoabENbHMKIRxmEoyCjhhMA.willCnjUwWfQuxoRCXqRPFFjILNI &= ~ldlbIDlGDTKMuLXyUtjBATffkGXI.WriteDirect;
				}
			}
			else
			{
				LhEafmgrXGEsPJipdUORmCDoHhzdb = ZEnCJHzGrZfqpFFVkWkvYBIZKeXx(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous);
			}
			if (!LhEafmgrXGEsPJipdUORmCDoHhzdb)
			{
				throw new Exception();
			}
			zqmUgBQmthBadXPwIROOCkBWJlKl = 1;
			hpxNrBKDTkEvdZgnAJrJpgFreXOv = 0;
			if (yGRmqSyzPwJaYNFOtGcrgaBssjVV && LhEafmgrXGEsPJipdUORmCDoHhzdb)
			{
				zqmUgBQmthBadXPwIROOCkBWJlKl = 17;
				hpxNrBKDTkEvdZgnAJrJpgFreXOv = 2;
			}
			xJvFXXDeeoUcMCrCSHxuXBRZAcxgb = 5 + hpxNrBKDTkEvdZgnAJrJpgFreXOv;
			jypdpSeeaMWlDfIbNKLtjMlvRAdZA = 6 + hpxNrBKDTkEvdZgnAJrJpgFreXOv;
			vGhPtCtlsjAQjfdnJNxUWFVErXobA = 7 + hpxNrBKDTkEvdZgnAJrJpgFreXOv;
			buttons = new WLKCiIfkjEHrYQVDYJcKGKPTVxLS[14];
			for (int i = 0; i < 14; i++)
			{
				buttons[i] = new WLKCiIfkjEHrYQVDYJcKGKPTVxLS(zqmUgBQmthBadXPwIROOCkBWJlKl, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new dnWPfQfDfnEmaJKgzGFSEYqFnsqm[6]
			{
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(zqmUgBQmthBadXPwIROOCkBWJlKl, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + hpxNrBKDTkEvdZgnAJrJpgFreXOv,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(zqmUgBQmthBadXPwIROOCkBWJlKl, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + hpxNrBKDTkEvdZgnAJrJpgFreXOv,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(zqmUgBQmthBadXPwIROOCkBWJlKl, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + hpxNrBKDTkEvdZgnAJrJpgFreXOv,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(zqmUgBQmthBadXPwIROOCkBWJlKl, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + hpxNrBKDTkEvdZgnAJrJpgFreXOv,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(zqmUgBQmthBadXPwIROOCkBWJlKl, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 8 + hpxNrBKDTkEvdZgnAJrJpgFreXOv,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(zqmUgBQmthBadXPwIROOCkBWJlKl, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 9 + hpxNrBKDTkEvdZgnAJrJpgFreXOv,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0)
			};
			hats = new NrHOvbJwrZapXdtjKfrfNYbTfeqF[1]
			{
				new NrHOvbJwrZapXdtjKfrfNYbTfeqF(zqmUgBQmthBadXPwIROOCkBWJlKl, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 5 + hpxNrBKDTkEvdZgnAJrJpgFreXOv,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, EsFepeVNAwajNfjUuflkAExNRWeLA)
			};
			accelerometers = new ghshtHzRELMvoutgmAIqgcgGRfGD[1]
			{
				new ghshtHzRELMvoutgmAIqgcgGRfGD(zqmUgBQmthBadXPwIROOCkBWJlKl, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					dataIndex = 19 + hpxNrBKDTkEvdZgnAJrJpgFreXOv,
					bitSize = 48
				}, 3, HorxjoWxlqQESKknvCViRhwqhpNS)
			};
			gyroscopes = new cAuwuHpmXWfmQkNNNMuQLAbjJQeRA[1]
			{
				new cAuwuHpmXWfmQkNNNMuQLAbjJQeRA(P_0.updateLoopSetting, zqmUgBQmthBadXPwIROOCkBWJlKl, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					dataIndex = 13 + hpxNrBKDTkEvdZgnAJrJpgFreXOv,
					bitSize = 48
				}, 3, 60, YzVpCMQylAxmDNXypCnlxIHqjgTK, diKTUlehuFydurPyjHvpYWfKsGBs)
			};
			touchpads = new YbNvcxfeAOXeGxhYaCCOmgMgdTsT[1]
			{
				new YbNvcxfeAOXeGxhYaCCOmgMgdTsT(zqmUgBQmthBadXPwIROOCkBWJlKl, new YbNvcxfeAOXeGxhYaCCOmgMgdTsT.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					dataIndex = 35 + hpxNrBKDTkEvdZgnAJrJpgFreXOv,
					bitSize = 48
				}, 60, HEljysepxAkHdMtgKMgdahPUBZUMA)
			};
			nMvhUxHjlhySLYPftWZKnMaghQzj = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			ceZWnLTBnYurqQkxNifcjSZjRbep();
			OoFYwQcsUlIiRRhitgSjyQekjwhiA(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Asynchronous);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < gZJxODUMDjoDYZnwShsjGYBWOYnG.Length)
			{
				return false;
			}
			evbDRMzMNkhnhGDHelFOTtTZSzJNA = (float)(timestamp - nMvhUxHjlhySLYPftWZKnMaghQzj);
			nMvhUxHjlhySLYPftWZKnMaghQzj = timestamp;
			gZJxODUMDjoDYZnwShsjGYBWOYnG.Write(inputReportPtr, inputReportLength, gZJxODUMDjoDYZnwShsjGYBWOYnG.Length);
			BPDAxosgteacUjFfSoiYRoSwWvms(gZJxODUMDjoDYZnwShsjGYBWOYnG);
			TLxauEDUTHJyIohwUOvuUYcQDbmh(gZJxODUMDjoDYZnwShsjGYBWOYnG, timestamp);
			QAOlVgyStIKpRmoWAGbpIzIYHZwjA[] array = axes;
			jJPJKPEgbDiAOMxuLLleJTsBHYON(array, gZJxODUMDjoDYZnwShsjGYBWOYnG, timestamp);
			array = hats;
			jJPJKPEgbDiAOMxuLLleJTsBHYON(array, gZJxODUMDjoDYZnwShsjGYBWOYnG, timestamp);
			array = accelerometers;
			jJPJKPEgbDiAOMxuLLleJTsBHYON(array, gZJxODUMDjoDYZnwShsjGYBWOYnG, timestamp);
			array = gyroscopes;
			jJPJKPEgbDiAOMxuLLleJTsBHYON(array, gZJxODUMDjoDYZnwShsjGYBWOYnG, timestamp);
			array = touchpads;
			jJPJKPEgbDiAOMxuLLleJTsBHYON(array, gZJxODUMDjoDYZnwShsjGYBWOYnG, timestamp);
			byte num = gZJxODUMDjoDYZnwShsjGYBWOYnG[30 + hpxNrBKDTkEvdZgnAJrJpgFreXOv];
			byte b = (byte)(num & 0xF);
			if ((num & 0x10) != 0)
			{
				if (b <= 10)
				{
					qGzoIhlHiTQEIcBEiJQymduEvSCD = MathTools.Clamp(b * 10 + 5, 0, 100);
					KDIQwIRiGFTDTleEFkKGDPkMMGNv = YJApjBaeVmbmQIwlIFGXaThBAuzb.Charging;
				}
				else
				{
					switch (b)
					{
					case 11:
						qGzoIhlHiTQEIcBEiJQymduEvSCD = 100;
						KDIQwIRiGFTDTleEFkKGDPkMMGNv = YJApjBaeVmbmQIwlIFGXaThBAuzb.Full;
						break;
					case 14:
						qGzoIhlHiTQEIcBEiJQymduEvSCD = 0;
						KDIQwIRiGFTDTleEFkKGDPkMMGNv = YJApjBaeVmbmQIwlIFGXaThBAuzb.Charging;
						break;
					default:
						qGzoIhlHiTQEIcBEiJQymduEvSCD = 0;
						KDIQwIRiGFTDTleEFkKGDPkMMGNv = YJApjBaeVmbmQIwlIFGXaThBAuzb.Unknown;
						break;
					}
				}
			}
			else
			{
				switch (MathTools.Clamp((int)b, 0, 8))
				{
				case 0:
					qGzoIhlHiTQEIcBEiJQymduEvSCD = 5;
					break;
				case 1:
					qGzoIhlHiTQEIcBEiJQymduEvSCD = 20;
					break;
				case 2:
					qGzoIhlHiTQEIcBEiJQymduEvSCD = 30;
					break;
				case 3:
					qGzoIhlHiTQEIcBEiJQymduEvSCD = 45;
					break;
				case 4:
					qGzoIhlHiTQEIcBEiJQymduEvSCD = 55;
					break;
				case 5:
					qGzoIhlHiTQEIcBEiJQymduEvSCD = 70;
					break;
				case 6:
					qGzoIhlHiTQEIcBEiJQymduEvSCD = 80;
					break;
				case 7:
					qGzoIhlHiTQEIcBEiJQymduEvSCD = 95;
					break;
				case 8:
					qGzoIhlHiTQEIcBEiJQymduEvSCD = 100;
					break;
				}
				KDIQwIRiGFTDTleEFkKGDPkMMGNv = YJApjBaeVmbmQIwlIFGXaThBAuzb.Discharging;
			}
			hjUPZUlMWVuJvQoHgDCPbrFsacNtA();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualShock4Extension(this);
		}

		private void OoFYwQcsUlIiRRhitgSjyQekjwhiA(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ P_0)
		{
			if (NwuzqwsJRMBKnXkZTZuuOkQaZVBn)
			{
				ZEnCJHzGrZfqpFFVkWkvYBIZKeXx(P_0);
				NwuzqwsJRMBKnXkZTZuuOkQaZVBn = false;
			}
		}

		private bool ZEnCJHzGrZfqpFFVkWkvYBIZKeXx(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ P_0)
		{
			scuMjfyqYNoyRWxUkYQZYeOgIUxV();
			bool result = TwuXZtpfhphXzrysLThnmSnauqqB(P_0);
			if (LxHWALHQXbSmfjQQzlQukZjjTVin)
			{
				result = TwuXZtpfhphXzrysLThnmSnauqqB(P_0);
				LxHWALHQXbSmfjQQzlQukZjjTVin = false;
			}
			return result;
		}

		private unsafe void scuMjfyqYNoyRWxUkYQZYeOgIUxV()
		{
			byte b = 0;
			b |= 1;
			LJOFDnnuQyqFcpHpJZTHvzFaRJCV = false;
			b |= 2;
			exzdfQsaccEfFCYUxHXhIcoeQqLvA = false;
			b |= 4;
			qeDGPAAXAzHaYHmjXHObmcuQoEeP = false;
			byte b2 = 128;
			if (yGRmqSyzPwJaYNFOtGcrgaBssjVV)
			{
				b2 |= 0x40;
			}
			if (jdzkobPfjaQHCppDAZDoSGUGEWKDA)
			{
				b2 |= 4;
				jdzkobPfjaQHCppDAZDoSGUGEWKDA = false;
			}
			if (yGRmqSyzPwJaYNFOtGcrgaBssjVV && LhEafmgrXGEsPJipdUORmCDoHhzdb)
			{
				URuLveJKDAosaZLQangguREtfblW[0] = 17;
				URuLveJKDAosaZLQangguREtfblW[1] = b2;
				URuLveJKDAosaZLQangguREtfblW[2] = 0;
				URuLveJKDAosaZLQangguREtfblW[3] = b;
				URuLveJKDAosaZLQangguREtfblW[4] = 0;
				URuLveJKDAosaZLQangguREtfblW[5] = 0;
				URuLveJKDAosaZLQangguREtfblW[6] = (byte)vibrationMotors[1].OZyBFjtdbmGNdxlWalLBCWEMJQKG;
				URuLveJKDAosaZLQangguREtfblW[7] = (byte)vibrationMotors[0].OZyBFjtdbmGNdxlWalLBCWEMJQKG;
				URuLveJKDAosaZLQangguREtfblW[8] = lights[0].mBcGJswVLOnTinvvOlCNUxHLUMIN;
				URuLveJKDAosaZLQangguREtfblW[9] = lights[0].kIAhQAlGFQuDKowPUabgZjXgBlcV;
				URuLveJKDAosaZLQangguREtfblW[10] = lights[0].OEydJgYetgIWftEcdQvalqXIIXGw;
				URuLveJKDAosaZLQangguREtfblW[11] = nDQWIyjDSbvPsjNMLOOeChRMAmoI;
				URuLveJKDAosaZLQangguREtfblW[12] = NUsKtbVvTOTugTJhYBjLMpvsyGMm;
				int jdsrPrFxmKEkhMzzoxOiDNYCqthA = AgHRAouoabENbHMKIRxmEoyCjhhMA.JdsrPrFxmKEkhMzzoxOiDNYCqthA;
				uint bytes = eBjxTVaRNvKjmBwKXMDsIBJTcTsU.yzoXJlAeXWKuKHiinpHYkFBARNDl((byte*)(void*)URuLveJKDAosaZLQangguREtfblW.Pointer, jdsrPrFxmKEkhMzzoxOiDNYCqthA - 4, 162u);
				URuLveJKDAosaZLQangguREtfblW.Write(bytes, jdsrPrFxmKEkhMzzoxOiDNYCqthA - 4);
			}
			else
			{
				URuLveJKDAosaZLQangguREtfblW[0] = 5;
				URuLveJKDAosaZLQangguREtfblW[1] = b;
				URuLveJKDAosaZLQangguREtfblW[2] = 0;
				URuLveJKDAosaZLQangguREtfblW[4] = (byte)vibrationMotors[1].OZyBFjtdbmGNdxlWalLBCWEMJQKG;
				URuLveJKDAosaZLQangguREtfblW[5] = (byte)vibrationMotors[0].OZyBFjtdbmGNdxlWalLBCWEMJQKG;
				URuLveJKDAosaZLQangguREtfblW[6] = lights[0].mBcGJswVLOnTinvvOlCNUxHLUMIN;
				URuLveJKDAosaZLQangguREtfblW[7] = lights[0].kIAhQAlGFQuDKowPUabgZjXgBlcV;
				URuLveJKDAosaZLQangguREtfblW[8] = lights[0].OEydJgYetgIWftEcdQvalqXIIXGw;
				URuLveJKDAosaZLQangguREtfblW[9] = nDQWIyjDSbvPsjNMLOOeChRMAmoI;
				URuLveJKDAosaZLQangguREtfblW[10] = NUsKtbVvTOTugTJhYBjLMpvsyGMm;
			}
		}

		private bool TwuXZtpfhphXzrysLThnmSnauqqB(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ P_0)
		{
			nFYeQRrPWICprSHuyoBCiEXZEbSo = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous:
				return xizofmTNNdijElJjozUyUonAbIxdA.WriteSync(AgHRAouoabENbHMKIRxmEoyCjhhMA, 0);
			case UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Asynchronous:
				xizofmTNNdijElJjozUyUonAbIxdA.WriteAsync(AgHRAouoabENbHMKIRxmEoyCjhhMA, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void TLxauEDUTHJyIohwUOvuUYcQDbmh(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[xJvFXXDeeoUcMCrCSHxuXBRZAcxgb];
			buttons[0].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x10) != 0, P_1);
			buttons[1].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x20) != 0, P_1);
			buttons[2].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x40) != 0, P_1);
			buttons[3].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x80) != 0, P_1);
			b = P_0[jypdpSeeaMWlDfIbNKLtjMlvRAdZA];
			buttons[4].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 1) != 0, P_1);
			buttons[5].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 2) != 0, P_1);
			buttons[6].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 4) != 0, P_1);
			buttons[7].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 8) != 0, P_1);
			buttons[8].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x10) != 0, P_1);
			buttons[9].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x20) != 0, P_1);
			buttons[10].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x40) != 0, P_1);
			buttons[11].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x80) != 0, P_1);
			b = P_0[vGhPtCtlsjAQjfdnJNxUWFVErXobA];
			buttons[12].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 1) != 0, P_1);
			buttons[13].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 2) != 0, P_1);
		}

		private void jJPJKPEgbDiAOMxuLLleJTsBHYON(QAOlVgyStIKpRmoWAGbpIzIYHZwjA[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].zlNHwfexPeybhRZVfQjgkewMqYcH(P_1, P_2);
			}
		}

		private void ceZWnLTBnYurqQkxNifcjSZjRbep()
		{
			if (isVibrating && ReInput.realTime >= nFYeQRrPWICprSHuyoBCiEXZEbSo)
			{
				NwuzqwsJRMBKnXkZTZuuOkQaZVBn = true;
				LJOFDnnuQyqFcpHpJZTHvzFaRJCV = true;
			}
		}

		private void BPDAxosgteacUjFfSoiYRoSwWvms(NativeBuffer P_0)
		{
			if (LhEafmgrXGEsPJipdUORmCDoHhzdb)
			{
				ushort num = gZJxODUMDjoDYZnwShsjGYBWOYnG.ReadUShort(10 + hpxNrBKDTkEvdZgnAJrJpgFreXOv);
				float num3;
				if (num != jnmvluoYGWlyLZyVpJDaxBsbmNWf)
				{
					int num2 = ((num >= jnmvluoYGWlyLZyVpJDaxBsbmNWf) ? (num - jnmvluoYGWlyLZyVpJDaxBsbmNWf) : (num + 65535 - jnmvluoYGWlyLZyVpJDaxBsbmNWf));
					num3 = (float)num2 / 187500f;
				}
				else
				{
					int num2 = 0;
					num3 = 0f;
				}
				jnmvluoYGWlyLZyVpJDaxBsbmNWf = num;
				wqCwLBBFYUyUDGahdAwEpRoTFMDbA = num3;
			}
		}

		private void hjUPZUlMWVuJvQoHgDCPbrFsacNtA()
		{
			if (LhEafmgrXGEsPJipdUORmCDoHhzdb)
			{
				_ = wqCwLBBFYUyUDGahdAwEpRoTFMDbA;
				_ = 0f;
				Vector3 vector = qMPdZOmqGmdOLfXjgNfPVhiGkwqF(new Vector3(gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[0], gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[1], gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[2]), wqCwLBBFYUyUDGahdAwEpRoTFMDbA);
				qrfWAAYOdebTYtkYvQnXVIpUdGWFA(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].JLwYhuHtTQDoTLjyTSPTHSWTgggN[0] * -1f, accelerometers[0].JLwYhuHtTQDoTLjyTSPTHSWTgggN[1] * -1f, accelerometers[0].JLwYhuHtTQDoTLjyTSPTHSWTgggN[2] * -1f);
				ayRGepjzTJDYvFCAFsmQEtMJEqdCc(vector2, vector);
			}
		}

		private static bool qrfWAAYOdebTYtkYvQnXVIpUdGWFA(ref Vector3 P_0)
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

		private void ayRGepjzTJDYvFCAFsmQEtMJEqdCc(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && DzNAaLHLjdTEuHThjCmVdqOKpNBMc(P_0, out var qtDramHldnvjBrevhEimqxaaetdw2))
			{
				Quaternion a = QrczIFkFLSEjkfgWAMyMaPzKUKMwA * quaternion;
				if (!UiGLmZFhrmSrOCDNaCLMJDKwHtUP)
				{
					UiGLmZFhrmSrOCDNaCLMJDKwHtUP = true;
					bHvKJffMLpBvQSXJQOweapyNXMrb = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					vQhggiceWgFPCEnonQzdzvUEpiBdb = QrczIFkFLSEjkfgWAMyMaPzKUKMwA;
				}
				bHvKJffMLpBvQSXJQOweapyNXMrb *= quaternion;
				vQhggiceWgFPCEnonQzdzvUEpiBdb *= quaternion;
				Quaternion b;
				if ((qtDramHldnvjBrevhEimqxaaetdw2 & qtDramHldnvjBrevhEimqxaaetdw.XZ) != qtDramHldnvjBrevhEimqxaaetdw.None)
				{
					b = hisvqohlVYVzyWlgfFBXefbDglxL(P_0, a.eulerAngles.y);
				}
				else if ((qtDramHldnvjBrevhEimqxaaetdw2 & qtDramHldnvjBrevhEimqxaaetdw.Y) != qtDramHldnvjBrevhEimqxaaetdw.None)
				{
					b = hjcqYZjwzBBrCXVYeKaGRDViDkGB(P_0);
					Vector3 vector = vQhggiceWgFPCEnonQzdzvUEpiBdb * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				QrczIFkFLSEjkfgWAMyMaPzKUKMwA = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				QrczIFkFLSEjkfgWAMyMaPzKUKMwA *= quaternion;
				if (UiGLmZFhrmSrOCDNaCLMJDKwHtUP)
				{
					UiGLmZFhrmSrOCDNaCLMJDKwHtUP = false;
				}
			}
		}

		private static Quaternion ihOBSwIOGlhAKCTXThaKENzUoPvsA(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = VUNDFFBqDVBBVtSvyxPXtJXcWmke(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 VUNDFFBqDVBBVtSvyxPXtJXcWmke(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion IpjuqabGVKlJKtetalpZnFNBHrtj(Quaternion P_0, axieDAxnZmHYABcbJMxGvrZSTDco P_1)
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

		private float hpPgnknFkdurjQFGIDBhSGPXzaBT(float P_0, float P_1)
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

		private Vector3 LWnyYgXLSWLBUwDsNCaoKEvsdXKr(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion hisvqohlVYVzyWlgfFBXefbDglxL(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion hjcqYZjwzBBrCXVYeKaGRDViDkGB(Vector3 P_0, float P_1 = 0f)
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

		private float SugPtJZvAzueZfqPfJkDdLhucTiP(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool EpSKfLDXTGhAygVGYALBlBCDNnNq(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool DzNAaLHLjdTEuHThjCmVdqOKpNBMc(Vector3 P_0, out qtDramHldnvjBrevhEimqxaaetdw P_1)
		{
			P_0.Normalize();
			P_1 = qtDramHldnvjBrevhEimqxaaetdw.None;
			bool result = false;
			if (AsVcwWpLMjSVqRgSiisGcLjJktRy(P_0))
			{
				result = true;
				P_1 |= qtDramHldnvjBrevhEimqxaaetdw.XZ;
			}
			if (HlcrZRrdAkACmhdGdvAnKkhJZnYTA(P_0))
			{
				result = true;
				P_1 |= qtDramHldnvjBrevhEimqxaaetdw.Y;
			}
			return result;
		}

		private bool AsVcwWpLMjSVqRgSiisGcLjJktRy(Vector3 P_0)
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

		private bool HlcrZRrdAkACmhdGdvAnKkhJZnYTA(Vector3 P_0)
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

		private Vector3 FtzgVWnzOkFdtoMucYpLZlztCBvkA(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 BaRFSTQSEXngqhxzMUiTCbMTuYtH(RingBuffer<cAuwuHpmXWfmQkNNNMuQLAbjJQeRA.arYEtUbayhJFeNamRRUDkYiZuhbN> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				cAuwuHpmXWfmQkNNNMuQLAbjJQeRA.arYEtUbayhJFeNamRRUDkYiZuhbN arYEtUbayhJFeNamRRUDkYiZuhbN = P_0[i];
				result += qMPdZOmqGmdOLfXjgNfPVhiGkwqF(arYEtUbayhJFeNamRRUDkYiZuhbN.IDEGgrKerbltszPxPYPGbtdsLRqgA, arYEtUbayhJFeNamRRUDkYiZuhbN.kGcGjoXESWeZAMcMRhPtzqsCrots);
			}
			return result;
		}

		private Vector3 qMPdZOmqGmdOLfXjgNfPVhiGkwqF(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int EsFepeVNAwajNfjUuflkAExNRWeLA(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void HorxjoWxlqQESKknvCViRhwqhpNS(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void YzVpCMQylAxmDNXypCnlxIHqjgTK(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float diKTUlehuFydurPyjHvpYWfKsGBs()
		{
			return wqCwLBBFYUyUDGahdAwEpRoTFMDbA;
		}

		private void HEljysepxAkHdMtgKMgdahPUBZUMA(NativeBuffer P_0, YbNvcxfeAOXeGxhYaCCOmgMgdTsT.TouchData[] P_1)
		{
			int num = 35 + hpxNrBKDTkEvdZgnAJrJpgFreXOv;
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
			P_1[0].touchId = SxDbRFHtcdkTtmRvkOnBinKIewkab(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = SxDbRFHtcdkTtmRvkOnBinKIewkab(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int SxDbRFHtcdkTtmRvkOnBinKIewkab(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				JeMHiLFXluJcLpmQpeEKyxtbuJAh[P_0] = -1;
				AlecwUOKNFZWcdntFSiwWkfqKMGn[P_0] = P_2;
				return -1;
			}
			if (P_2 != AlecwUOKNFZWcdntFSiwWkfqKMGn[P_0])
			{
				int num = cmxNnSSHdVBeytkqrCFiyOYvhOfT;
				if (cmxNnSSHdVBeytkqrCFiyOYvhOfT == int.MaxValue)
				{
					cmxNnSSHdVBeytkqrCFiyOYvhOfT = 0;
				}
				else
				{
					cmxNnSSHdVBeytkqrCFiyOYvhOfT++;
				}
				AlecwUOKNFZWcdntFSiwWkfqKMGn[P_0] = P_2;
				JeMHiLFXluJcLpmQpeEKyxtbuJAh[P_0] = num;
				return num;
			}
			return JeMHiLFXluJcLpmQpeEKyxtbuJAh[P_0];
		}

		private void qTQLsKAAeFxDKRUiRUgmXqceukno()
		{
			exzdfQsaccEfFCYUxHXhIcoeQqLvA = true;
			HanzCwsrQPobAIDEClTzQKuPJZzL();
		}

		private void mpcZQrtkrJxNFRhFRxGaKXthnpwl()
		{
			qeDGPAAXAzHaYHmjXHObmcuQoEeP = true;
			HanzCwsrQPobAIDEClTzQKuPJZzL();
		}

		private void jrPIEjFkfcDUjQoafDIiZwmBjNxgA()
		{
			LJOFDnnuQyqFcpHpJZTHvzFaRJCV = true;
			HanzCwsrQPobAIDEClTzQKuPJZzL();
		}

		private void HanzCwsrQPobAIDEClTzQKuPJZzL()
		{
			NwuzqwsJRMBKnXkZTZuuOkQaZVBn = true;
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
				OoFYwQcsUlIiRRhitgSjyQekjwhiA(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous);
				if (gZJxODUMDjoDYZnwShsjGYBWOYnG != null)
				{
					gZJxODUMDjoDYZnwShsjGYBWOYnG.Dispose();
				}
				if (URuLveJKDAosaZLQangguREtfblW != null)
				{
					URuLveJKDAosaZLQangguREtfblW.Dispose();
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
		private static void jHjCmdcOJfGBBnIBHWIMtpZkefgf(object P_0)
		{
			Logger.Log(P_0, requiredThreadSafety: true);
		}
	}
}
