using System;
using System.Diagnostics;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class DualSenseDriver : HIDDeviceDriver, IDriver_DualSense, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		private enum kvwBDkUHizhskXvGKAHNREFHUVCP
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum sABjIvxxggHpTFVPmsQDRUSqxZxO
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private enum GUgBYLjtKJqjGvJMCAoevQMCqvYT : byte
		{
			Off = 0,
			Feedback = 1,
			Weapon = 2,
			Vibration = 3,
			SlopeFeedback = 4
		}

		private enum fkSqeWTysZDpOIBJEmtVDFtelNNj : byte
		{
			High = 0,
			Medium = 1,
			Low = 2
		}

		private enum qrdUEZcSRAMHnTNbvtpJtsBEWITF : byte
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			TemperatureOutOfRange = 10,
			TemperatureError = 11,
			ChargingError = 15
		}

		private enum KJqJzulyXqEFlhJVXWdwjlwTgvoH
		{
			NotCharging = 0,
			Discharging = 1,
			Charging = 2,
			Full = 3,
			Unknown = 4
		}

		private enum NKJEfkOAOspCDTzDkoYOifkeCwNs : byte
		{
			None = 0,
			CompatibleVibrationMode1 = 1,
			HapticsSelect = 2,
			RightTriggerEffect = 4,
			LeftTriggerEffect = 8,
			AudioVolume = 0x10,
			ToggleInternalSpeaker = 0x20,
			MicrophoneVolume = 0x40,
			ToggleInternalMicOrExternalSpeaker = 0x80
		}

		private enum kkfdMpwlKCpDwpPrayIjhFdSiBIe : byte
		{
			None = 0,
			MicrophoneLEDControl = 1,
			PowerSaveControl = 2,
			LightbarControl = 4,
			TurnOffLEDs = 8,
			PlayerIndicatorLEDControl = 0x10,
			Unknown1 = 0x20,
			ChangeOverallMotorEffectPower = 0x40,
			Unknown2 = 0x80
		}

		private enum LEffsctAMGbWEBYJiqLqaLkpdiczA : byte
		{
			None = 0,
			OtherLightBrightnessControl = 1,
			LightbarSetupControl = 2,
			CompatibleVibrationMode2 = 4
		}

		private struct kMndXHEsfaEUZBXtCKqcwYRKdqFR
		{
			private const string JAOVEEUwjtmJjsmpCPQVQsRveQHR = "Value must be between 0 and 16.";

			public byte eDUszCNgKaYwnfHGbaorpLLgvLCD;

			public byte oRxnOJXhzwDcuLBSquRprYCRlOQg
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public byte CtOTtPwZRooDaPFjgDUQWCllJoam
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public kMndXHEsfaEUZBXtCKqcwYRKdqFR(byte P_0)
			{
				eDUszCNgKaYwnfHGbaorpLLgvLCD = 0;
			}

			public kMndXHEsfaEUZBXtCKqcwYRKdqFR(byte P_0, byte P_1)
			{
				eDUszCNgKaYwnfHGbaorpLLgvLCD = 0;
			}
		}

		private static class TGNSCQLoXZFfmHxRbwPpkCLYagJh
		{
			public enum PfoYgTBrbBPAGvPXJdsKMgsafDFj : byte
			{
				Off = 5,
				Feedback = 33,
				Weapon = 37,
				Vibration = 38,
				Bow = 34,
				Galloping = 35,
				Machine = 39,
				Simple_Feedback = 1,
				Simple_Weapon = 2,
				Simple_Vibration = 6,
				Limited_Feedback = 17,
				Limited_Weapon = 18,
				DebugFC = 252,
				DebugFD = 253,
				DebugFE = 254
			}

			public static class DNtxROILKGPJXusbjeJQrZRnAKFs
			{
				public static class lLybawKmHeRyLYNbpcoSAmbPlfYM
				{
					public static bool fDENjyvFTmYtalWdRwpPfZJYrRhN(byte[] P_0, int P_1)
					{
						return false;
					}

					public static bool xRoUNueNuGlZlnAgPEqnjSLKeHYC(byte[] P_0, int P_1, float P_2, float P_3)
					{
						return false;
					}

					public static bool uonaYRxFMGUOMWvOVYIRZsoSBbAh(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						return false;
					}

					public static bool gxVpjEeGoWBnNjVfSwnWieccbeYFA(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						return false;
					}

					public static bool cDpSXfZRJsmsTfWVdNNxZuptqYys(byte[] P_0, int P_1, float[] P_2)
					{
						return false;
					}

					public static bool iNoJdgtdydCsNPGTMPZKTWNzszVS(byte[] P_0, int P_1, float P_2, float P_3, float P_4, float P_5)
					{
						return false;
					}

					public static bool eBBkUIddJaJhASRGyGrgBFcmEXeO(byte[] P_0, int P_1, float[] P_2, float P_3)
					{
						return false;
					}
				}

				[Serializable]
				private sealed class TulZNsWDloNTNjuWotKDmDpAHwuAA
				{
					public static readonly TulZNsWDloNTNjuWotKDmDpAHwuAA _003C_003E9;

					public static Func<byte, bool> _003C_003E9__4_0;

					public static Func<byte, bool> _003C_003E9__6_0;

					internal bool QFnrttvgclDHBoeSSegiJzHwQgpVA(byte P_0)
					{
						return false;
					}

					internal bool JmLefoJrpYxirqoxJQAIWMucaohMA(byte P_0)
					{
						return false;
					}
				}

				public static bool ZOYQNtCQliGqUtHREanAEMaYZLzh(byte[] P_0, int P_1)
				{
					return false;
				}

				public static bool lVWKVPWwWlkHDzUPSmLhbvfxQlKV(byte[] P_0, int P_1, byte P_2, byte P_3)
				{
					return false;
				}

				public static bool nAjoKagIRFOAkokJoLzXBMiHpvwM(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}

				public static bool LiWSbPuHtMBlnHPLkUlZRHwcpQMFA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}

				public static bool binMBSdkGzbzFEIVrteFRMKrErhE(byte[] P_0, int P_1, byte[] P_2)
				{
					return false;
				}

				public static bool xxHauSrWEOswuAwSJmZJOqYkJNOP(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
				{
					return false;
				}

				public static bool BFYQIWDOQWdzpFvSvLFfXbWQMlcbA(byte[] P_0, int P_1, byte P_2, byte[] P_3)
				{
					return false;
				}

				public static bool nQRVHAGGuLpcCHrvUrYlVOHmsPh(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
				{
					return false;
				}

				public static bool DRluJotSXljeyZFUNcWRkQXJvmIl(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6)
				{
					return false;
				}

				public static bool XICUMhYKplejAqJEadULHTMmaVsm(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6, byte P_7)
				{
					return false;
				}

				public static bool MIQxPxeeGuywzwPrTMAqzjeSdUnH(byte[] P_0, int P_1, byte P_2, byte P_3)
				{
					return false;
				}

				public static bool AxuHoZMNPPljlJIpmOHawSOBIYtaA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}

				public static bool AsEizNIUBosaYJxrMwXbvOxTlNIr(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}

				public static bool AUMlMRUloZHKhbIOiqJihAAayQrSB(byte[] P_0, int P_1, byte P_2, byte P_3)
				{
					return false;
				}

				public static bool MDyMzoHySJMeYcxwnBKUwAVcxxYG(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}
			}
		}

		private const float zwjIPyRLMJZKhYPkKgvxyrdonJto = 4f;

		private const int xkrJiRWfLnbnjyZgxDZpXtNXsCcs = 15;

		private const int TmhmWHsESKopbPGkTRasHMhnaMmd = 2;

		private const int adlRNOEBOQjAbYWAdcqDMKRtZhBh = 0;

		private const int rGMGmDCpPkoKfPYyRgjXGhCvJBmW = 1912;

		private const int jZzUQryYjuNkmCzZBpHCApmReExeA = 0;

		private const int CzqpJLTikcJREwYOipRaTDmCAmjh = 941;

		private const bool YWAqJISuRmPgomnhcpJKyafGAJpDA = false;

		private const bool PMpASzmDjbLJNCMBSeZHhvatOwCeb = true;

		private const float mVjBfiTmDzuYcCqSJQSHJqVaatBp = 2.5f;

		private const int wYIXQZEBIYkLSHHicZZlEjBacKHQ = 0;

		private const int hFXPDNKYuJEpYtkbvxtkNusQXtdk = 0;

		private const int esWwQexmqsexOeNiCnDcucaYMXUdA = 1;

		private const int TSOxxaHqUhnJQwtRCLSedmGygfSo = 0;

		private const int BZRgfQCjrzIfjSpeFEixrwRIjBVuA = 0;

		private const int MtQuqusnKjSDbXsDeFTgPpRgnPzr = 0;

		private const int tpLekoFVeXeqAfgzIVrEwTccPaDMc = 1;

		private const int MoDJClQLMLfKzIGSdKFMYoohjRMx = 49;

		private const int otubaWKLqfNPBwmIoieqGxbcDEqi = 0;

		private const int XRBCbmgFlycUcfQAxTTHRIjfCtwRA = 1;

		private const int mtDLMXEoRGccuaBpxuYRPuWIqnDLA = 64;

		private const int sLyGoepRCXIRaJThAocWkXSSApbh = 48;

		private const int OnnJqyjNzgvCwGDvJyDoIOkobqCV = 78;

		private const int aGAtITNaNzSwluqSynFcfCBTCfKu = 5;

		private const int UqAItfosGuQvtxZmIrJGIKoubEjFA = 41;

		private const byte JJroeWOLhZgJWaTbXVoOwOTdlAsuA = 1;

		private const byte hsCwPzNELfASmjkjUWzuWxasCSZo = 2;

		private const int bkqAVqewDImeboaGtOMNIIKrnakCb = 1;

		private const int EJPJaRMIBeFAdyZfoWklvKKJvhdv = 2;

		private const int bYKEBtIGOzRcWGEulwxbaxwQGdneA = 3;

		private const int BOFxlZdvOgfjWQsWsDyFxnjvEXB = 4;

		private const int SqZpMsuhGTFHTusPEVKKsbMpyXOv = 5;

		private const int TMwwxPTTNVwjLCQYtbNQNvZuStCC = 6;

		private const int mAXahlnJcKEDqhoYQKQjXFBPdBiE = 8;

		private const int QYiBhvkJTZztMCZWiHfckIcyurYB = 22;

		private const int stoOtJbbKZbBaOwEKjnRqvAXDhis = 16;

		private const int dNlBTzXlhbTYdkpbaisNXlKIOTwx = 33;

		private const int QcsjidVqmmTqZggJdCqjFcnMhfbd = 8;

		private const int uYVLFBsXTloQqmPTelUrsBeeCmdl = 9;

		private const int YxXDyZJxslpXPQSYqPrPQtSxAKhB = 10;

		private const int nwrNEmUYCOaHNXTHlGPcyQbLEeUd = 28;

		private const int unDjsFcttbCzpbOxmkSmCuXhSRlEb = 53;

		private const int rGPSaisJDeSSzpKQERMoPrbMTwRR = 54;

		private const int wTlCjdIZlyDypDlbBFsSyAkbKZtr = 43;

		private const int hoapmYoElufIctaYBnAozUwgmaXy = 42;

		private const int RCUCblbgLKKAbztHCCznZSaGirBpA = 48;

		private const bool AktFHhgvPigUwwbbGZbpGukwqAsr = true;

		private const int TNesMjxLVLeORmSPJGdARegPOypR = 60;

		private const int fKBhKRsIOvDxMbSTfGarSLEGokSU = 60;

		private const int jXZLYPSJGMarOhsKwiIMMksFAxkB = 3000000;

		private const float KeoDiDiHPvZKnVbKOoWOdDLgfkPH = 8192f;

		private const float wrBCWFdtIMwalcszpkolXmbDKvZz = 0.0010652969f;

		private const float pVIpLVsIUGHgImHCrqRfzlZkBkaGA = 0.06103702f;

		private const bool iFsNLXHrqozOgxBTjGZadNzQzluB = true;

		private const bool PXSHVcdkCkCMuzzCkrDYmiDtNaEw = true;

		private const bool MQzeFROgezAdPJzlCPBdUYoyBFDj = true;

		private const bool wTrBKFesuapfBCOPFSEOLELkbsEiA = true;

		private const float BnrFtEgfxqMfnbWhFEglhHozBcuIA = 4096f;

		private const float PAjpTPWlCIDGDGqFhCqUkFCWrtFM = 16384f;

		private const float AXuWLlyDQBQbTQIEaieqcuVkzSby = 16777216f;

		private const float HSQQBzSoyACYuZlhPLcKJcdiGKjF = 268435460f;

		private const float cgLlhsYHPCIcpPNepBOhtNPsnFcY = 0.01999998f;

		private const float qHRMuNIuMsShHCoWXxCygAmihvDM = 8192f;

		private const float fGDDbIcTadUMYVKRllEmjuoaynyV = 0.98f;

		private const float KRvKZMLViPKWkJcHxSmutqqfOmiJ = 45f;

		private const float GziKRReUYLSfnhPhncEQgssPEiOgA = 20f;

		private const DualSenseVibrationMode FdkbLIyhzqCbDgIGeQPMHSSigajJB = DualSenseVibrationMode.Compatible2;

		private readonly IHIDDevice WjXiusOhiXnKBSjilbAPiAsCCGcoA;

		private readonly HIDProperties sliQHRbGWzhmowhKRaRRqIRHOoPx;

		private readonly bool EOberOecUNciaNVjAYmPZcfUvaGu;

		private readonly int fcWArtIcqVFbuoAKjwRMvwTLCkyWA;

		private readonly int zTuvVoXhALTjQrHepzGlaGwvePud;

		private bool quqGFVhKVucOHGWbBGPixxkOJrVzb;

		private byte jGvrUubdkhVFUpCpGMIplfxoEwQcA;

		private int KfiebYdpbOQjCMGcHcuAkRPSbyvCb;

		private int BuIaDzmxAcIVQMBHNvWNFDbBuWPD;

		private int owojqlFanfKPinQSXfnTOoXDcdIl;

		private int XezEFMcoeFHslkvxJkApEthbRVwUA;

		private readonly NativeBuffer lwxnnmvzKmNIwklejJqAlFxmlhGM;

		private readonly NativeBuffer BVzdkYOsICNYnfXJjXhYAhHlHDKr;

		private bvbVwPMivxlHVYJUjAzbVqMqOlbN cZRLpsSlmeGIDUbuKBWBCqUvjkkSA;

		private int tPFvhCURlWiDrYsjPnVpmoavOkG;

		private bool zKMUmmWjajCREkfqbQBmCWDUePbB;

		private bool zducorjzFtlPUumyUQeluATbCLCRA;

		private double wjPGYtLfIZLlFIpBnAZriGuaAfKGb;

		private int amXmGjTVJPIFlPCMAGqPHDJICbQnA;

		private KJqJzulyXqEFlhJVXWdwjlwTgvoH uMVuynKDuKeopARAOCHvPmREZTaR;

		private bool XZzNdQHjwdFLrWvALURtNsPIDaWH;

		private Quaternion gvYAaDOIQzoeZoUjFesnXFNmImEe;

		private DualSenseMicrophoneLightMode yJdCzWgWxKfRoFCdkaOHDdGWALxG;

		private fkSqeWTysZDpOIBJEmtVDFtelNNj KIpSrtYMzAFPljZfmaokqCMhcZkTA;

		private DualSensePlayerLightFlags FmMgghqnRwzTxECJMjFHlaDyFiXCA;

		private bool FXeuSwFLwcpwmFxhCuxGIOCrnqGB;

		private uint JZQPYDxAVflNgiPSjkihVUPdVasi;

		private float rkQhJUhomGpVYzdlSDCTcFNHkaMEA;

		private double heiIAtxzevkIkkPXcpRhDuBFrcHh;

		private float ApsmqdKtWReETsMgTdCBsfKWtAqw;

		private readonly IDualSenseTriggerEffect[] JMKnssUfxYCbgicpsmCDWAeLLIfaA;

		private readonly byte[] wCBjObNOrIUVZXLMabAaYRBIxZtv;

		private readonly byte[] uxQeAZEGRTFZGGDfOjtzJIffQGbbA;

		private DualSenseTriggerEffectState[] ASJUBrPXEjfalgOCrrogrOqlUjHt;

		private DualSenseVibrationMode QcsbtZvdMFtkxNYFEscQfWHXrARq;

		private byte jzAeOqbYXJgsnZJRXLlWYkTHFotfA;

		private bool HxvEjxbztySZcfTwoPuQEVEnKpnz;

		private bool IphdtJbWIjCLOcIMJJwzkYyHLIVEb;

		private bool MLDHCFvQrcNRAotOjfNcrDsyBkrq;

		private bool DgTHWAtexfsXJFjoDFiwnxSITBmh;

		private bool ZVgRrRYGSGmLwnHvRjmntptlPbKd;

		private bool mKdJPQEkqLAXhHRLDBZIchjmXwuB;

		private bool aPkElDdAyvTQsFaLbTAbTxqTkOQE;

		private bool IPvraNUxnBqxEhAinwSIoaRXjGYf;

		private bool JKQXVOsgIlUuoRMhiKCVsgYDyDaQ;

		private byte AAGaXlXnsTagjvfwxPiOZaixaEzM;

		private byte ieVgUimRQpESEbjXGZpXWaulARPq;

		private Quaternion CvvVGSzgCjtbWuvAAGVuNZYilGLS;

		private Quaternion gaQooWrJywhfpUoWwFMOwvwlSPZw;

		private bool wGvjNJoxmzHvSBjKSJwIOcVEBIqgA;

		private int dghctFkEROxPWnFttnTTBkLOcFxlA;

		private int[] RpsciPXxxDpVXtzkHjUsmcwXVsGl;

		private int[] cuZxjBgBxxgMAzrWzHbXXeicEGMaA;

		private static uint[] scdvGpmmoFSPYoozsgKSGVHFROFsA;

		private const uint WmbBgEawrIoirRtpVIrmAmEMfQXtA = 3940166985u;

		private bool isVibrating => false;

		public float BatteryLevel => 0f;

		public bool BatteryCharging => false;

		public DualSenseVibrationMode vibrationMode
		{
			get
			{
				return default(DualSenseVibrationMode);
			}
			set
			{
			}
		}

		public float LeftMotor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RightMotor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LightColorR
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LightColorG
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LightColorB
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LightFlashOnDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LightFlashOffDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public DualSenseMicrophoneLightMode microphoneLightMode
		{
			get
			{
				return default(DualSenseMicrophoneLightMode);
			}
			set
			{
			}
		}

		public DualSenseOtherLightBrightness otherLightBrightness
		{
			get
			{
				return default(DualSenseOtherLightBrightness);
			}
			set
			{
			}
		}

		public DualSensePlayerLightFlags playerLights
		{
			get
			{
				return default(DualSensePlayerLightFlags);
			}
			set
			{
			}
		}

		public Vector3 AccelerometerValue => default(Vector3);

		public Vector3 AccelerometerValueRaw => default(Vector3);

		public Vector3 GyroscopeValue => default(Vector3);

		public Vector3 GyroscopeValueRaw => default(Vector3);

		public Vector3 LastGyroscopeValue => default(Vector3);

		public Vector3 LastGyroscopeValueRaw => default(Vector3);

		public Quaternion Orientation => default(Quaternion);

		public int MaxTouches => 0;

		ushort IHIDControllerExtension.vendorId => 0;

		ushort IHIDControllerExtension.productId => 0;

		string IHIDControllerExtension.productName => null;

		string IHIDControllerExtension.manufacturer => null;

		ushort IHIDControllerExtension.usagePage => 0;

		ushort IHIDControllerExtension.usage => 0;

		public void ResetOrientation()
		{
		}

		public int GetTouchCount()
		{
			return 0;
		}

		public bool IsTouchingAtIndex(int index)
		{
			return false;
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return false;
		}

		public int GetTouchIdAtIndex(int index)
		{
			return 0;
		}

		public bool GetTouchPositionByIndex(int index, out Vector2 position)
		{
			position = default(Vector2);
			return false;
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			position = default(Vector2);
			return false;
		}

		public bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			positionX = default(int);
			positionY = default(int);
			return false;
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			positionX = default(int);
			positionY = default(int);
			return false;
		}

		public void StopLightFlash()
		{
		}

		public void StopVibration()
		{
		}

		public bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
		{
			return false;
		}

		public DualSenseTriggerEffectStates GetTriggerEffectStates()
		{
			return default(DualSenseTriggerEffectStates);
		}

		public DualSenseDriver(InitArgs P_0)
			: base(default(InitArgs))
		{
		}

		protected override void OnInitialize()
		{
		}

		public override void Update(UpdateLoopType updateLoop)
		{
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			return false;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return null;
		}

		private void PsDiCDMyqitvMXmJKDfgJJpBczUcA(ApGJLxYzFsobivPGgnsYkhrKhjyh P_0)
		{
		}

		private bool zuebszJtaWbPLISvLlBBiGAxYIhx(ApGJLxYzFsobivPGgnsYkhrKhjyh P_0)
		{
			return false;
		}

		private void KtdCOvkAyVERaIrNiafneExVXLpe()
		{
		}

		private void hdakWzBPZVCFdVSdQdVCbuDGbNKX(NativeBuffer P_0, int P_1)
		{
		}

		private void PffrwhHtYUlEAtNDlcjMVgFDzvIr(ref IDualSenseTriggerEffect P_0, NativeBuffer P_1, int P_2)
		{
		}

		private bool SAadammuXJgYnbJdJpupagAEUyQQ(ApGJLxYzFsobivPGgnsYkhrKhjyh P_0)
		{
			return false;
		}

		private void hBechHFvVdqXluQJsfMgIJGgONhg(NativeBuffer P_0, double P_1)
		{
		}

		private void OMgVtKgWOARBIkJkZaoytDlMvGUH(MdziBGNqephqKFAONQgipbAHplCzA[] P_0, NativeBuffer P_1, double P_2)
		{
		}

		private void nwlIdrMnLXhBCwfUJwbWfoFkBCMw()
		{
		}

		private void JhEpRSpBVfZDpiHNvdoZdFthIheIA(NativeBuffer P_0)
		{
		}

		private void GAThPthelKLChNNIsCvVqwGEwGIrA()
		{
		}

		private static bool HPdPCraVbAIFYtQIIcskyPcjxqmW(ref Vector3 P_0)
		{
			return false;
		}

		private void dVgcZXafbPrLuEwuGeNAfbYhzNyBB(Vector3 P_0, Vector3 P_1)
		{
		}

		private static Quaternion SwvdiKKnrlkrcsszSzsUQOgxGhNfb(Quaternion P_0, Vector3 P_1)
		{
			return default(Quaternion);
		}

		private static Vector3 vIzByxmjwPNdxzNQklbRWguOsyx(Vector3 P_0, Vector3 P_1)
		{
			return default(Vector3);
		}

		private Quaternion IyoxNszjtggQBGdVAEKbGeOBrAMg(Quaternion P_0, kvwBDkUHizhskXvGKAHNREFHUVCP P_1)
		{
			return default(Quaternion);
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			return default(Quaternion);
		}

		private float XEeIAiadDzbkyzrieVaiNLvYxZQ(float P_0, float P_1)
		{
			return 0f;
		}

		private Vector3 AkvwDMgRAPurpznjqjrScCfFzvQBA(Vector3 P_0, float P_1 = 0f)
		{
			return default(Vector3);
		}

		private Quaternion dgOaWAwMDCezDsYqSGGYmOyXYnwX(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private Quaternion ccLFZWCRmYwXFGdiPmZQsiqhVksJ(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private float AGWmAECmJomVSKnwYAASuConxTdo(Vector3 P_0)
		{
			return 0f;
		}

		private bool TyQgbPSMnlKjJpAZeZhZThoiArSEA(float P_0)
		{
			return false;
		}

		private bool bNgdkzdNuQpZhbZpjtCAFvPfqLsXb(Vector3 P_0, out sABjIvxxggHpTFVPmsQDRUSqxZxO P_1)
		{
			P_1 = default(sABjIvxxggHpTFVPmsQDRUSqxZxO);
			return false;
		}

		private bool pLGtpvjxfVxzRInOxLhuXgkyIwam(Vector3 P_0)
		{
			return false;
		}

		private bool bHvdtbaxpscuMlMsXmiaJpRaZSNy(Vector3 P_0)
		{
			return false;
		}

		private Vector3 vsblcSwqfEWVDTzsXMufPqJXuHHV(float[] P_0)
		{
			return default(Vector3);
		}

		private Vector3 KVIyiWNbgIHwtGonVUMytIbOEfIm(RingBuffer<omJTadSTUfHtFlRTSobFSDlwxmMU.wmlHdmQTjMmOhjNiIETGodgSQDTq> P_0)
		{
			return default(Vector3);
		}

		private Vector3 nQXfZUfbXxmufDWAVYQmhZuSxowx(Vector3 P_0, float P_1)
		{
			return default(Vector3);
		}

		private int XXKgJSfnwpMfYGWrdGaiInzuvBqsc(int P_0)
		{
			return 0;
		}

		private void swCQrCtgLUhVSCdBrjRLodrSIUsbb(byte[] P_0, float[] P_1)
		{
		}

		private void eHTpRZmaqUOdiUBJoSRaoJMIjwwI(byte[] P_0, float[] P_1)
		{
		}

		private float gHvlXgYoxzWtpINsNaOTbwDeVRmg()
		{
			return 0f;
		}

		private void wsaipZDjqAVUYeBnlkReOCrySLWn(NativeBuffer P_0, EWahEPKvarCbHRiElXgHuZAhtMQj.TouchData[] P_1)
		{
		}

		private int MJwUnTiiDwgOjFOPvkwCyfAnuojm(int P_0, bool P_1, int P_2)
		{
			return 0;
		}

		private void wuDUfeelXJnwgzxMKPTGJcuYHZTJ()
		{
		}

		private void KvLYbrzxQWXAsHtCVHcffjGzqsjc()
		{
		}

		private void xNvZdaMdrQMNyBfWmCtgFHUEUvps()
		{
		}

		private void PBkAKjPZzcSpjNCcBCqvDltCPtOJA()
		{
		}

		~DualSenseDriver()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public static bool Matches(int vid, int pid)
		{
			return false;
		}

		private static uint VlYzktZOccpIcYPxMeUGewtoIugSA(NativeBuffer P_0, int P_1)
		{
			return 0u;
		}

		private static fkSqeWTysZDpOIBJEmtVDFtelNNj dZqxyozONXjsVDUiiiXOMhHXPYhm(DualSenseOtherLightBrightness P_0)
		{
			return default(fkSqeWTysZDpOIBJEmtVDFtelNNj);
		}

		private static DualSenseOtherLightBrightness UzYFkLpjftPsooqZOLacMqEPZoEY(fkSqeWTysZDpOIBJEmtVDFtelNNj P_0)
		{
			return default(DualSenseOtherLightBrightness);
		}

		private static GUgBYLjtKJqjGvJMCAoevQMCqvYT NNQmzMMefkMgBnZBBxcZFGdoXpyL(DualSenseTriggerType P_0, byte P_1)
		{
			return default(GUgBYLjtKJqjGvJMCAoevQMCqvYT);
		}

		private static DualSenseTriggerEffectState gkGjqZxEvqCGZHCvVyjDgDvlTLaL(DualSenseTriggerType P_0, byte P_1, byte P_2)
		{
			return default(DualSenseTriggerEffectState);
		}

		[Conditional("DEBUG_THIS")]
		protected static void DLog(object msg)
		{
		}
	}
}
