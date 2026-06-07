using System;
using Rewired.ControllerExtensions;
using Rewired.Drivers.Interfaces;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class DualSenseDriver : HIDDeviceDriver, IDisposable, IControllerDriver, IDriver_DualSense
	{
		private enum jyjuYiZkvJBwcMtuffMhQAJmCxF
		{
			GtXLBoJjMJIIZgbanjZkTINBqZp = 0,
			oeViMnGeDrcFmFpGjxNxpIWDNrWR = 1,
			oFHYKbgQkpGvSicdIHmFeAhKaqq = 2
		}

		private enum vDSdnbfejIcWDkWfDkshMWOHcQks
		{
			kWwOvXSVQftLstpRDMaKvWdpfrv = 0,
			ACajcpJldFPYxBHmjkCNwxGYOUs = 1,
			oeViMnGeDrcFmFpGjxNxpIWDNrWR = 2
		}

		public enum yGHCTCYklxnkQRtrhxKlQevRxoC : byte
		{
			vjVavBdBCLFQjHZKrLNuDSQDILS = 0,
			LgCytwrEEswUeKaIeBNOTTCUfFH = 1,
			BytBvtkNDzjDLFORVIRsaFSFHifY = 2
		}

		private const float dvJvOjfmsXNAZhYWkIDkYRzoeo = 4f;

		private const int NoIkHJatIKHMFGIHJxPWgXaDsAp = 15;

		private const int ZFTXhVpSGSMocaKBHIQjbDOEMFIR = 2;

		private const int lIMwBoviEfoMfBaAyHYxQaGcriS = 0;

		private const int BtLbezhsySfpDInbrkQawxrakme = 1912;

		private const int zpwljyjolGZnFoqzvBLvUNdbbwo = 0;

		private const int KEawQiECyYtIfLjkIUZoHENYAnz = 941;

		private const bool wTsORVNwZYOEdYdbZwJFmdLZQAg = false;

		private const bool qVoYyjkYVPSftGdMOyqVrsoOnho = true;

		private const float QCQfyrsisFjUMYivtUARxghjWJd = 2.5f;

		private const int kUWGBjQwfbDvBwcJcAOwGvEkjCc = 0;

		private const int cDPexJrqUQVnLgNBtUBVQxmnWCi = 0;

		private const int TpTXVeyVqyBBgaMzAlLoyTfXdpp = 1;

		private const int eoEDybEayoCTDghIhNgFBCTvhkqH = 0;

		private const int yQdjOuhDhKRxgPoaISmEbGSHUVu = 0;

		private const int cAfOsSqgVlOqIErhEQJxWEtvFSl = 0;

		private const int BTDBpXdnUNCeTimgGiZSvHlNcpEW = 1;

		private const int vRdFkDCPMTTQesHbxMUsaXHYdTp = 49;

		private const int LjkFJFdwWjkacNFuHKhcSdKXbIx = 0;

		private const int HTQYOrDgWWAIhejFxQvudtHCKgih = 1;

		private const int IKAUooqrChnNMUEgDgUKDkDtEEcZ = 64;

		private const int rrNeGhAQUkfOHAnRZkEasFqyLShm = 48;

		private const int hTeLWmbNMeOrDtNCsbLbAUKBHPLg = 547;

		private const int MHDwiibuWKNQFDGwhGgwqZAjehP = 64;

		private const int iECfnIkbAmTVKaHjeMRoePkeIzbK = 547;

		private const int plAlWORykQeFWQeOGPmtOoYPJHZ = 1;

		private const int IgQoAAJPoHaAawrIHOlbPWLxxyz = 2;

		private const int ZCumTorgroxuoaJPHxkSVdSICOI = 3;

		private const int BUDhuLOGKmTlaeQDaWFxchuIulm = 4;

		private const int tTDFvKnzyiFuJKBhyddRHCAutNf = 5;

		private const int mLIOrdcFcQnJoipBvAPhExGFwTB = 6;

		private const int mxgKMFTxnGPEhllFKUFptoGvbAe = 8;

		private const int uTjcRkafXxPLyUPnBjuQiDegdGlK = 22;

		private const int YuAStqtMMYIfpUCzBBnpTSXOkPS = 16;

		private const int ZWYDnydomnfnlykIratyYSHRdYJ = 33;

		private const int cTxQVYYuJvwXjsDfbfeGBTvjodJ = 8;

		private const int RptmQDYOSdxZynZEykJVzILVINn = 9;

		private const int htOnuosKTjBSBGsvAIDNeNsAKCMg = 10;

		private const int PutUekfrTjKkWagCNWOCRRfCmiK = 28;

		private const int RijrUxjMoXFansQEjMBBWoFJaBkH = 54;

		private const int PyoQIZmuuGTsmQEQqBrJhWyZSj = 55;

		private const int MsrUGznGhACXWTpLOiZmQdxcUJZ = 54;

		private const bool YKJUIcRGCcQQSaYrRCIuahfahb = true;

		private const int GWfmoxKYGOQsNNKnxeuBwNBXojg = 25;

		private const int ejJZTrzvYAKFlZxIakSoPhDHqkC = 3000000;

		private const float lWhcGCWqtVfbQGiiGSiematOPujg = 8192f;

		private const float ZDfQzogBHSNuhjVIIBxLAqjlbmT = 3.4971635f;

		private const float TVXGAnpEZjdVHqhdybwtRAWjXKz = 0.06103702f;

		private const bool OqYeDRJhBQPsjDwuNrivFYkDEcG = true;

		private const bool qfrzcusMnVDSaIgUgFWRYrEtSjda = true;

		private const bool MJwnjMGZifGuJuDcgHfOofzjXKP = true;

		private const bool KTNBnemMGNkTvjkLFXkmIeUlMrT = true;

		private const float eeMNUPRxljfWNPNoVOPNXHFRCcE = 4096f;

		private const float XeWKpFlLwcngsLCbhpJgDzIFQDG = 16384f;

		private const float USJcSBiEAuhbXekenWGRCXwpXDH = 16777216f;

		private const float DFYrHtzMXAiElVqUdIefPjYTRBn = 268435460f;

		private const float pBoxmryYGOxlmAMiOzdBJtJmwCu = 0.01999998f;

		private const float cxiagvFyQGNeKQUixzhYejskHnrH = 8192f;

		private const float lCDbuCBJQIGofyfRsAmQNdVvbxH = 0.98f;

		private const float iWsPSqsLfGgwIkaGAFWybtCTATvK = 45f;

		private const float NWSfuWQnjyEREMEBGtCtSdJJiXr = 20f;

		private const uint trgPiUIPMWsYlUejrbvKnHuqeOme = 3940166985u;

		private readonly bool ljIBclIgiAANWFrjBNeLyQYASYAC;

		private readonly int gCbbXFHkLCHBfHdlGnfwJkNKSdkL;

		private readonly int aLJMqSkOjXdcVIVSvVPYTvZDfvoI;

		private readonly bool szBxOOislqNKFUgZXlUBSlVKegJc;

		private readonly byte nUFlPqvGaRDpVSIDaAunBOiQgyFF;

		private readonly int lbxZMSbJoYZzAgjzoQZHWvnEDmP;

		private readonly int ZFRuIPEjWcbnniongRNPHekkTkh;

		private readonly int vIwSPtQsjUdeeoMtiaMmiMfHNhMc;

		private readonly int rxzLafPYqLMogjEBlHKknXktQOw;

		private readonly int oGJbNOLffQJyDXKzADNclWMZAMT;

		private readonly int UXSDFROJjAzwQYYZMspVcHiqJun;

		private readonly NativeBuffer TNsrdxUzSigJvhkTABqkSBrupPX;

		private readonly NativeBuffer YiDkrZSsLRSeHQoRYfEyOJZtZhA;

		private OutputReport NqIwrAVCcNbKUFTUcaAOSzVPjfgd;

		private readonly Func<OutputReport, bool> zGragaBdAvmiqiZgBpxhyCoTgvTK;

		private readonly Action<OutputReport> QwhNoqAoCzNjUBkTYKdLiZWnfeJ;

		private bool ChxsAQNkMjrIBiHhweumALkMRbKm;

		private bool IZBWfWUNcbReDADrJiiJHlbiFdq;

		private double vJPekyDfSWpysDDTKxcpOBINQzZ;

		private byte RieEoIkBuXXMSnStcWRVzbirHTK;

		private bool ETtDRKmfNWKwLXhuwDWFvaCJdFN;

		private bool LlEhZUHVXjbnxiHjRXCfFKoUfwv;

		private bool YacURpgUPdyxFhRliBoIknTOZvH;

		private Quaternion edVttfsEqfZxArTmbWJdBuGrlaI;

		private DualSenseMicrophoneLightMode AdanntWHbAiezbHpAQNLIBUwieU;

		private yGHCTCYklxnkQRtrhxKlQevRxoC oSBwGAwfnLIBRnfBiVDynSElIEv;

		private DualSensePlayerLightFlags bcAbayapQqHLKDqaCRBtkhLlyZKT;

		private bool DRdbtWcIJvRchtDBEUKWsrRAmBlB;

		private bool CDlYkKPqNPtbLIOChzckcnjYVBA;

		private uint NLNHoGDjYoMQVfKVjoDLPdHbHHb;

		private float uxqVSYdKatYAUHuMKxYpVihRsMk;

		private double iwwtgDzvKdgerBXabqlbJUjvvIb;

		private float HsGeiQXNXkIfxXPpuWLxCKEzoHl;

		private byte jToIAByBaRvQtOEJxRqipxTPiga;

		private byte UlRccQjIcfSLaKMjvaalYrlXbsmN;

		private Quaternion upEcVkbfGyFHhLwvoeUBRHfSmzVV;

		private Quaternion roUolcazJpKmjWWGBWiVOHCYSG;

		private bool bUxCohKXYsUIzopyhqQsicsThKZH;

		private int oojyChdOaSBcgYPoyFwpZTpUetT;

		private int[] ulLKUiRGAspsLpnwkgBjzsLTDFxe;

		private int[] JOeHgOvqIaVJzeuhJUxAbUmLNcm;

		private static uint[] gBPBazgDCIoUlEPmQEyjOLFdyPp;

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

		private void BgiySjYJNMTqwljIAhpXOeOScHyg(langamgpCrFDZAyXTaThMJylRDe P_0)
		{
		}

		private bool fVAxseiaLYEjXhJFRLDnGqAQHCoj(langamgpCrFDZAyXTaThMJylRDe P_0)
		{
			return false;
		}

		private void SUWXUaJrRCSUjhqatnyyZfhoGbu()
		{
		}

		private void SUWXUaJrRCSUjhqatnyyZfhoGbu(NativeBuffer P_0, int P_1)
		{
		}

		private bool jRmbybWcjNPDpGJKuGrMfRcMtae(langamgpCrFDZAyXTaThMJylRDe P_0)
		{
			return false;
		}

		private void YUQoGhMUuTiuoibvVdSmdbngLQcP(NativeBuffer P_0, double P_1)
		{
		}

		private void uEQFxSNLHXgJiBDRGvzRlggnKJF(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
		{
		}

		private void AbfLIGRyCBGyaaekAgquUbDuwrw()
		{
		}

		private void JLyacRKHpvuLwFLrXrKeddTWrhNe(NativeBuffer P_0)
		{
		}

		private void PJjiRGvoGCebtiFXscNrAaLhSSkw()
		{
		}

		private static bool mSuOUsHEPhtCrmFXILLrxSyyNWJ(ref Vector3 P_0)
		{
			return false;
		}

		private void GjZLLlqytgSKzWLqDBAgmNTripj(Vector3 P_0, Vector3 P_1)
		{
		}

		private static Quaternion zHuFJKfCmxMJVbfsexVwSujPFPQC(Quaternion P_0, Vector3 P_1)
		{
			return default(Quaternion);
		}

		private static Vector3 LZiDlyWoGqCPTcdkfiPRFVzodTO(Vector3 P_0, Vector3 P_1)
		{
			return default(Vector3);
		}

		private Quaternion jYAWvSKNhhvuSzLjGCEUgAUOyIJ(Quaternion P_0, jyjuYiZkvJBwcMtuffMhQAJmCxF P_1)
		{
			return default(Quaternion);
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			return default(Quaternion);
		}

		private float PNRClifPDsrKIHdgJbbANAlDpzwt(float P_0, float P_1)
		{
			return 0f;
		}

		private Vector3 PIjwXWZcCVqgPRBXFvMShHMcajOi(Vector3 P_0, float P_1 = 0f)
		{
			return default(Vector3);
		}

		private Quaternion UAIbclaqLlBEOFJVKwGfALiOEts(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private Quaternion LjnYaBqhEMkXzawzArtaIgQChdt(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private float hjtNYtFNmjsfDqhxDosAfPTuZjn(Vector3 P_0)
		{
			return 0f;
		}

		private bool kFEWWixBkScCvyWSCEEMggnsfogi(float P_0)
		{
			return false;
		}

		private bool hTiEvFcTDyeajqZpnIEoGpUpRnK(Vector3 P_0, out vDSdnbfejIcWDkWfDkshMWOHcQks P_1)
		{
			P_1 = default(vDSdnbfejIcWDkWfDkshMWOHcQks);
			return false;
		}

		private bool NhxumkCuNAXvebiISAtZCAHqoBO(Vector3 P_0)
		{
			return false;
		}

		private bool cFXLBxshCtlDzRTgLgTpNPkPjeQC(Vector3 P_0)
		{
			return false;
		}

		private Vector3 HfujJNLlHiRjKgIRKeEWJnckQDN(float[] P_0)
		{
			return default(Vector3);
		}

		private Vector3 DgwoZsWYxiDfOBfunEtVSsHsJVR(ExpandableArray_DataContainer<HIDGyroscope.jqaIYcFksubflmsUxNhitaolnQQ> P_0)
		{
			return default(Vector3);
		}

		private Vector3 DgwoZsWYxiDfOBfunEtVSsHsJVR(Vector3 P_0, float P_1)
		{
			return default(Vector3);
		}

		private int rpHRMSLaSskfEbAIldFLYPebLEV(int P_0)
		{
			return 0;
		}

		private void lfZXDbyOZEGoLgNsjHHqRvosNDXg(byte[] P_0, float[] P_1)
		{
		}

		private void ueSAJqFDsmRDnMRyRtEtVykAAGqs(byte[] P_0, float[] P_1)
		{
		}

		private float bhHVYONnbnmSeCNraHBYzjlEFifK()
		{
			return 0f;
		}

		private void ecPPKIVQGuKiBZpMgXruoaxVAWs(NativeBuffer P_0, HIDTouchpad.TouchData[] P_1)
		{
		}

		private int ceoGxgThydnxvJvmHDYRBXYOSSS(int P_0, bool P_1, int P_2)
		{
			return 0;
		}

		private void nbifbucpvvrrufWXmojPzamrEZm()
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

		private static uint WpWuDsUVCHStUoPvszAHVrUELnu(NativeBuffer P_0, int P_1)
		{
			return 0u;
		}

		private static yGHCTCYklxnkQRtrhxKlQevRxoC tMWRqpTwmbatCQWaYFWCuYRLvkD(DualSenseOtherLightBrightness P_0)
		{
			return default(yGHCTCYklxnkQRtrhxKlQevRxoC);
		}

		private static DualSenseOtherLightBrightness qjQWEkUOvypcPBFmjeqTbdmGynL(yGHCTCYklxnkQRtrhxKlQevRxoC P_0)
		{
			return default(DualSenseOtherLightBrightness);
		}
	}
}
