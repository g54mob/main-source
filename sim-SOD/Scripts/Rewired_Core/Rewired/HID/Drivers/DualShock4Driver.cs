using System;
using Rewired.Drivers.Interfaces;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualShock4Driver : HIDDeviceDriver, IDisposable, IControllerDriver, IDriver_DualShock4
	{
		private enum sppOuXdCxHvxJcEHzEbFYByBkyJ
		{
			HRgcrJcfZzCDDHeiHjMYAnmhcidt = 0,
			dwiwQRYxVJMivtOxfiNSmpyytQD = 1,
			vBoRaGIGOFTRMsIfUawlIFIrbks = 2
		}

		private enum ogMLchZdVUYMOUyHDVktFJVhCKUC
		{
			bANLksuTeREfmxvNVHxsLpYEtSv = 0,
			NiPaAAhsTntFbVLstopfSkbdMMo = 1,
			dwiwQRYxVJMivtOxfiNSmpyytQD = 2
		}

		private const float zMMgjSbPPIJCPERvWAZqCUzCquuE = 4f;

		private const int AGbvGyAZcoNXFAfJJcJqOTZcEUj = 14;

		private const int YiuRgsBEsytJuuIFTlLBxOvjZrS = 2;

		private const int sgjzQPNIgLeftHTAmgcRywvJXpW = 0;

		private const int QMafGMLMQiauBMzzfVPMOpWXgWa = 1912;

		private const int cuNPBXLaFkhsTwdpbwyTmJIWdeu = 0;

		private const int TuDuXHgMpsDjhHwPKslKnyqplxx = 941;

		private const bool nXVbVsthtyRedOIhDcwhKHqytIy = false;

		private const bool lFDWyIOPixPVhAQnSaZrCXHronsB = true;

		private const float LWzDSCIqCxfPGIxpzRfvTxCWHNr = 2.5f;

		private const int dazArWaOVLfQFuJNgqhEeLxZqYg = 0;

		private const int rRiDgWZshkcDqmTCdqJzkHvOIhi = 0;

		private const int WbUIjgFSlYGEJVsSdHChqYuWXzd = 1;

		private const int luzcWOktKQMOFvmSbTXzuyaSoUu = 0;

		private const int hNASDDHkPuAYwNVqUEdaFVlsDYo = 0;

		private const int rKKvsxSijHLFUQrdOfhLoQYUiOn = 0;

		private const int WUmNBeFgozxTDssgquAghaUNxWY = 1;

		private const int uewLIlYnOeXALURBowQXOBhVanR = 17;

		private const int AgHulkPpIHAfgVIuFPzSuYhkQkd = 0;

		private const int bjnZkIXDPKfPXFzbzxkkPHhvjxx = 2;

		private const int PNvWnNWcwJOmKQOuXploCckKSvi = 64;

		private const int LHUPOkJdtWiVnMWhVRAbeyKkKiE = 78;

		private const int mqlcAffHCiAYIKGSEGFTaDdyANDB = 1;

		private const int HszDSnJblbmjqqgjHqxPwhfElxll = 2;

		private const int MmRrAVDwXOhuwsqVPCMqbeldMKQ = 3;

		private const int MsqvBksSkUrAictMcOdJKbVfakyF = 4;

		private const int gakeJvTqEGuSVMiduIGddTjJJVb = 8;

		private const int rdtJSWQMWwWloyuZpqjXiopsgwD = 9;

		private const int tpPqKytEXchZrbIPCutPFXdMWKg = 5;

		private const int pNMFhZKxrZUwiIHvTdJeMMLHFYdf = 19;

		private const int TddOsVBPsyOLnGtrTKUTzjcfpHA = 13;

		private const int OPvaZNNjWJwirgXQhUzWmNsqCXB = 35;

		private const int xkYxeraQtNzhxcSnvHHctfQAdwB = 5;

		private const int KuKmucqooNAlkbLEomgbFNgaVWh = 6;

		private const int oXhEzNOwhTFiTwAxIeqptvFdEMK = 7;

		private const int AgKcoPBNXJHXwnumLjpkSnujIeSH = 10;

		private const int SzbfXTaipnVuoDGfWNtYBxxSUxE = 30;

		private const int hHTPDyQTMwagzpjQQdTfPJIOHWA = 27;

		private const byte CFNjQajEKpOWvizDWespYryDwXx = 200;

		private const byte qyMlJamkgWnbQUMOLcEKIPVArfp = 53;

		private const byte LZMqFDBTdTGZMzwPvsJGborSjES = byte.MaxValue;

		private const byte GGYCmjbImYgNVEmYsKcPooYObnUy = 0;

		private const bool wMxEldjYtwqjAtYubgukPAFYssjA = true;

		private const int JBWKPSgwcavuBFFnhNqvQhyozak = 25;

		private const int thcbzeAFFukNZLBpubXaBrOBiycf = 187500;

		private const float aQWFursILnBgCIaiIKRKXAUdqqfF = 8192f;

		private const float AiQJQJYLtwxabpfAKKMvasCGqQD = 3.4971635f;

		private const float SrmlyUBIfDUeZycxmUHTrOdYcQbC = 0.06103702f;

		private const bool RolaIkAdLacIrfDydZUZEfjugEGf = true;

		private const bool vHEEBXSRtrDzqyKxqnbnBbtMbFf = true;

		private const bool BbFLaduIQPfVTkraocOqAISEvSD = true;

		private const bool FEubrTiYaduxfhrsHlcExgVCiUBF = true;

		private const float jYdijszZZJMyPXGgVtdddEeejKWC = 4096f;

		private const float QotvmiXbtQSkmPGzxYIGdnnukOK = 16384f;

		private const float RmmFcmUjsObuHqSexFzhetDICFPk = 16777216f;

		private const float AJrpiIDVreRYrTFUtVqXzOjoTqv = 268435460f;

		private const float yATgPDHGwopmfiGSdQOpqnKVRcec = 0.01999998f;

		private const float pYBWGESaNkvSAMsSzQesRHJZvCb = 8192f;

		private const float yMyVTjjzegiZfejFeuvabkmSjTN = 0.98f;

		private const float znLobHKuRgrPQwiUGlOYZbdwPNn = 45f;

		private const float KRlmTzsbTGdZAQITAXGRuEmcxPn = 20f;

		private readonly bool qqhHSYozAoWUOpaxPVZnuLzjfSY;

		private readonly DeviceConnectionType mcEUIFERVXgDFoqppIVPAXDsogFq;

		private readonly int zRIvMqWhSyCHzpbVtYgUSaXpbKe;

		private readonly int bqaKWtANZtpwDJGMbgPiToncpfm;

		private readonly bool dBckDnUDFORLBOGDJiztgsctWeT;

		private readonly byte qcqLPXDWOnwuFYyVkDZFnBPvIgBk;

		private readonly int ulWWhxZlAixACcdreRppykSrbXH;

		private readonly int CNykQugzkYtsdwDfoyilxoRPwor;

		private readonly int sLTbRMiCTqxyquuvsdPUgeEkafW;

		private readonly int ssSljMlcCvuFafWBjpoMHzNUTOm;

		private readonly int fOcIBvdUVynfVLIpIviCXLroPQL;

		private readonly int LQtareweZmCpWDILEIAdLGPXMkvc;

		private readonly NativeBuffer WeTLTQgjeKEBrrORCNRYigMNAHP;

		private readonly NativeBuffer JTaZSyknCdqJDInuGhEEgXuUHFU;

		private readonly OutputReport KgtLjbxBQdTwAJUGebKaTegqdzu;

		private readonly Func<OutputReport, bool> sIYQGHZuBRrgcHkqHWAFymHybWP;

		private readonly Action<OutputReport> LfWnxXsegPrAMJywATffGawQTrN;

		private readonly GetHidFeatureData wIHzvjrqhhvkFuaphqfpoLxPVhY;

		private bool BkOcPnpiaXJIFuFhsRJSreRznqK;

		private bool ByuBaljynRBUXcMrbTFfHnOFXPfi;

		private double cGuTQFxqFsCuwHMLQEAZoAkwhWRD;

		private byte CfLusjYCGhZIEjAjcFfbBTNUeNKA;

		private Quaternion zTyRfCYPMPazEbSulezLbgrGmxA;

		private ushort CEubUtfogYSXXrSRdwolnNcGSNj;

		private float rZPyWdHUsTPAIVMzQraDjURaGlo;

		private double jZZCrwTdwDlQrDagdGPTfBEMGAn;

		private float IylCUhvWpCfyfJszibgLuszIJDx;

		private byte cDHxgcCQMfqohMcXnauAhBwkLggd;

		private byte ZZmEhRkALTYoPEnxsXNzPOmqkkL;

		private Quaternion drzncRTqLSKQjohRklHjhQIdvaX;

		private Quaternion ybHhEWdWJbLRybfSWopKYzgvLGIM;

		private bool qObEAircKGTxsluqhzSrYZSgMJv;

		private int lZOAGfCJyopKmMQNsCyLRxwvCeHn;

		private int[] rDswkBpCsKGnHxeeoAoTNtqwgBzb;

		private int[] WXRQxzLhwWEWheZyTidoJBzkJLe;

		private bool isVibrating => false;

		public float BatteryLevel => 0f;

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

		public Vector3 AccelerometerValue => default(Vector3);

		public Vector3 AccelerometerValueRaw => default(Vector3);

		public Vector3 GyroscopeValue => default(Vector3);

		public Vector3 GyroscopeValueRaw => default(Vector3);

		public Vector3 LastGyroscopeValue => default(Vector3);

		public Vector3 LastGyroscopeValueRaw => default(Vector3);

		public Quaternion Orientation => default(Quaternion);

		public int MaxTouches => 0;

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

		public DualShock4Driver(InitArgs initArgs)
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

		private void WiLwiEqhjwtuklcOGQszyDbvJGa(qtYOVDQyuJWkDWXBHmYRaOJGJPk P_0)
		{
		}

		private bool qdtLBJUBzwUcZtTJTEqDyLvpCUsD(qtYOVDQyuJWkDWXBHmYRaOJGJPk P_0)
		{
			return false;
		}

		private void NJbewBpvbuVRvjcOpTlUdUpPpOq()
		{
		}

		private bool elREEMihZvtWhUjKwNOejGLbJimb(qtYOVDQyuJWkDWXBHmYRaOJGJPk P_0)
		{
			return false;
		}

		private void JzhqFYipGthZqgIzHnMCRHSPSms(NativeBuffer P_0, double P_1)
		{
		}

		private void tPnynrrElxAzqRtVYgUBAHXStQHi(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
		{
		}

		private void ZSIyOxhfmrafgsWsIAFUwQwXrve()
		{
		}

		private void UnRSHerXLJIWcVdaBpiUHFuplIZ(NativeBuffer P_0)
		{
		}

		private void QCKclvLhyuvipLLDqeaHeCsUIAsB()
		{
		}

		private static bool zwTeUPjClPLDlcpHIuZTTPHZJlL(ref Vector3 P_0)
		{
			return false;
		}

		private void FoexFEIIFICRbGWsLitEAKmYFxv(Vector3 P_0, Vector3 P_1)
		{
		}

		private static Quaternion wIHrvOkUIBARLxsHlsWJKIHcLCZ(Quaternion P_0, Vector3 P_1)
		{
			return default(Quaternion);
		}

		private static Vector3 AXFwhFsJQIKBJidhlbPrhfuPXrOh(Vector3 P_0, Vector3 P_1)
		{
			return default(Vector3);
		}

		private Quaternion ewzvqvifpVlwSvmFAphmGYxbbcH(Quaternion P_0, sppOuXdCxHvxJcEHzEbFYByBkyJ P_1)
		{
			return default(Quaternion);
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			return default(Quaternion);
		}

		private float UBwZhTlbsSNHUveAvOtakYmKzaa(float P_0, float P_1)
		{
			return 0f;
		}

		private Vector3 UYUxVvfoQnpiTZPiLxIwZbJNdZW(Vector3 P_0, float P_1 = 0f)
		{
			return default(Vector3);
		}

		private Quaternion RmneHAfOOBmOQLwBKdJJBwsvwEqL(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private Quaternion IeWlaiCluyNQbqlfWiYAyulzehn(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private float cGOYlUjmfTSfJkTdZFrwPvyRLvl(Vector3 P_0)
		{
			return 0f;
		}

		private bool hapKqPJRYqsJbokUOkpoQHGPCkif(float P_0)
		{
			return false;
		}

		private bool mZNdXsSmtIKhnkgrrprAmFbIWfM(Vector3 P_0, out ogMLchZdVUYMOUyHDVktFJVhCKUC P_1)
		{
			P_1 = default(ogMLchZdVUYMOUyHDVktFJVhCKUC);
			return false;
		}

		private bool WsUYMNaHAgVAkplyODxzswzTBeG(Vector3 P_0)
		{
			return false;
		}

		private bool pkgvfOGDuJfIxXjmPMaFrMFsGwA(Vector3 P_0)
		{
			return false;
		}

		private Vector3 UeHFJoerHUCEUXiUKRDscnQNnINJ(float[] P_0)
		{
			return default(Vector3);
		}

		private Vector3 QxHhtLuVPAKnQFrexAOrkecLNZX(ExpandableArray_DataContainer<HIDGyroscope.oiDemRpcICkkdwKOtjWObBRIoKCe> P_0)
		{
			return default(Vector3);
		}

		private Vector3 QxHhtLuVPAKnQFrexAOrkecLNZX(Vector3 P_0, float P_1)
		{
			return default(Vector3);
		}

		private Vector3 FdAyPcFdMPdhVcgGITdYSTyRJRL(Vector3 P_0)
		{
			return default(Vector3);
		}

		private int uDQHzjHfSkJrjgbWEdShacsrIRZJ(int P_0)
		{
			return 0;
		}

		private void uhwbGCAcpyfxHBBwzshIPqLXBQP(byte[] P_0, float[] P_1)
		{
		}

		private void ptjpwBvYIQIohJcKNhBZUaPdKVc(byte[] P_0, float[] P_1)
		{
		}

		private float yWqsFnzVRZPVeUtHgydqHEdtsbd()
		{
			return 0f;
		}

		private void ptoiKbtMaUxlLPMKmadKAZEuIQg(NativeBuffer P_0, HIDTouchpad.TouchData[] P_1)
		{
		}

		private int tWBAHTfmGJtqfJmkNAvzzNrfDME(int P_0, bool P_1, int P_2)
		{
			return 0;
		}

		private void kvHeDJCKFPlkwrGPgwYbDTJEqFq()
		{
		}

		~DualShock4Driver()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public static bool Matches(int vid, int pid)
		{
			return false;
		}
	}
}
