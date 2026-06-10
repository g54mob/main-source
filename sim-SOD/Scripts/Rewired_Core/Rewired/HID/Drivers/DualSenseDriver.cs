using System;
using Rewired.ControllerExtensions;
using Rewired.Drivers.Interfaces;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualSenseDriver : HIDDeviceDriver, IDisposable, IControllerDriver, IDriver_DualSense
	{
		private enum guQpORloDrCGyEqsraAPDccFyYJu
		{
			HRgcrJcfZzCDDHeiHjMYAnmhcidt = 0,
			dwiwQRYxVJMivtOxfiNSmpyytQD = 1,
			vBoRaGIGOFTRMsIfUawlIFIrbks = 2
		}

		private enum eslFWLYXZiZXLUraHFXLihikMoQ
		{
			bANLksuTeREfmxvNVHxsLpYEtSv = 0,
			NiPaAAhsTntFbVLstopfSkbdMMo = 1,
			dwiwQRYxVJMivtOxfiNSmpyytQD = 2
		}

		public enum noaGrpyOBBwrWFhtbarNGySyWoCV : byte
		{
			qDskAcBQodiJxfJWlAqGYhbePLMv = 0,
			MUDeEYZsyyZjUSmmmekvBvonFbNf = 1,
			IRWfHGYIvVAWXaOJFowUKfvwHuzd = 2
		}

		private const float zMMgjSbPPIJCPERvWAZqCUzCquuE = 4f;

		private const int AGbvGyAZcoNXFAfJJcJqOTZcEUj = 15;

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

		private const int uyMBYqiIenNLyipvfDlUAZazABv = 49;

		private const int AgHulkPpIHAfgVIuFPzSuYhkQkd = 0;

		private const int AItknSzanwRkvfJDxAtMFmfrccc = 1;

		private const int PNvWnNWcwJOmKQOuXploCckKSvi = 64;

		private const int mXkduUgImYbVXcvXROlKCdJLVAxP = 48;

		private const int aYLgdHZxyEcgRrfCgJwNiMjqgNJ = 547;

		private const int ZxaQxFTwmmEQLFuJpJdUSdTEbAF = 64;

		private const int zfnZrcRoyAOQzFznoyAOpXndrxG = 547;

		private const int mqlcAffHCiAYIKGSEGFTaDdyANDB = 1;

		private const int HszDSnJblbmjqqgjHqxPwhfElxll = 2;

		private const int MmRrAVDwXOhuwsqVPCMqbeldMKQ = 3;

		private const int MsqvBksSkUrAictMcOdJKbVfakyF = 4;

		private const int gakeJvTqEGuSVMiduIGddTjJJVb = 5;

		private const int rdtJSWQMWwWloyuZpqjXiopsgwD = 6;

		private const int tpPqKytEXchZrbIPCutPFXdMWKg = 8;

		private const int pNMFhZKxrZUwiIHvTdJeMMLHFYdf = 22;

		private const int TddOsVBPsyOLnGtrTKUTzjcfpHA = 16;

		private const int OPvaZNNjWJwirgXQhUzWmNsqCXB = 33;

		private const int xkYxeraQtNzhxcSnvHHctfQAdwB = 8;

		private const int KuKmucqooNAlkbLEomgbFNgaVWh = 9;

		private const int oXhEzNOwhTFiTwAxIeqptvFdEMK = 10;

		private const int AgKcoPBNXJHXwnumLjpkSnujIeSH = 28;

		private const int OmAgIMTVAbvOpsDKjanlqReuLLq = 54;

		private const int CoFfGzfpQISDRdaYWLRLOhKNNTtv = 55;

		private const int BCGVoYXHRggNSjLrSQXMgkMPISNf = 54;

		private const bool wMxEldjYtwqjAtYubgukPAFYssjA = true;

		private const int JBWKPSgwcavuBFFnhNqvQhyozak = 25;

		private const int thcbzeAFFukNZLBpubXaBrOBiycf = 3000000;

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

		private const uint uvZMztgBieVbvWSdhIqwXbFNKUo = 3940166985u;

		private readonly bool qqhHSYozAoWUOpaxPVZnuLzjfSY;

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

		private OutputReport KgtLjbxBQdTwAJUGebKaTegqdzu;

		private readonly Func<OutputReport, bool> sIYQGHZuBRrgcHkqHWAFymHybWP;

		private readonly Action<OutputReport> LfWnxXsegPrAMJywATffGawQTrN;

		private bool BkOcPnpiaXJIFuFhsRJSreRznqK;

		private bool ByuBaljynRBUXcMrbTFfHnOFXPfi;

		private double cGuTQFxqFsCuwHMLQEAZoAkwhWRD;

		private byte CfLusjYCGhZIEjAjcFfbBTNUeNKA;

		private bool DQWStrIUbqkXZRDmiwwhRzviDtV;

		private bool SDpdfflpdHwgrsuhDUrHrNVvcjz;

		private bool RZTegahKcNBltahRHeiCUWWpvHrm;

		private Quaternion zTyRfCYPMPazEbSulezLbgrGmxA;

		private DualSenseMicrophoneLightMode DoLYNQaixiZtdfNtMopreElZeuUf;

		private noaGrpyOBBwrWFhtbarNGySyWoCV fAgMEnYkFdfGDnoFkOqWBPzMDWv;

		private DualSensePlayerLightFlags srjGlFZkUSUHKggbQksRXalKTrI;

		private bool KtIRjVcraBrFdXRIAtJgHgytHls;

		private bool VCQEwTEzSvByhMOSxsMCHQSrjXCr;

		private uint CEubUtfogYSXXrSRdwolnNcGSNj;

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

		private static uint[] bIgiQOOmuciPbYZiMpTTatoWBLr;

		private bool isVibrating => false;

		public float BatteryLevel => 0f;

		public bool BatteryCharging => false;

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

		public DualSenseDriver(InitArgs initArgs)
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

		private void NJbewBpvbuVRvjcOpTlUdUpPpOq(NativeBuffer P_0, int P_1)
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

		private Quaternion ewzvqvifpVlwSvmFAphmGYxbbcH(Quaternion P_0, guQpORloDrCGyEqsraAPDccFyYJu P_1)
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

		private bool mZNdXsSmtIKhnkgrrprAmFbIWfM(Vector3 P_0, out eslFWLYXZiZXLUraHFXLihikMoQ P_1)
		{
			P_1 = default(eslFWLYXZiZXLUraHFXLihikMoQ);
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

		private static uint BbnDQsimpnwZpakVeCEeDbQpGJdf(NativeBuffer P_0, int P_1)
		{
			return 0u;
		}

		private static noaGrpyOBBwrWFhtbarNGySyWoCV eDbYYIbgEVosASpiCxIaAXoaoWP(DualSenseOtherLightBrightness P_0)
		{
			return default(noaGrpyOBBwrWFhtbarNGySyWoCV);
		}

		private static DualSenseOtherLightBrightness rSzqgNydZMyaJXpitmNpRnTzahX(noaGrpyOBBwrWFhtbarNGySyWoCV P_0)
		{
			return default(DualSenseOtherLightBrightness);
		}
	}
}
