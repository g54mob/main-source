using System;
using Rewired.Drivers.Interfaces;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class DualShock4Driver : HIDDeviceDriver, IDisposable, IControllerDriver, IDriver_DualShock4
	{
		private enum dJYkugHwNpikPqqHvvIjeSHmCcZ
		{
			GtXLBoJjMJIIZgbanjZkTINBqZp = 0,
			oeViMnGeDrcFmFpGjxNxpIWDNrWR = 1,
			oFHYKbgQkpGvSicdIHmFeAhKaqq = 2
		}

		private enum pKdGDClbhugTEMhDXdRBGrqMOCIz
		{
			kWwOvXSVQftLstpRDMaKvWdpfrv = 0,
			ACajcpJldFPYxBHmjkCNwxGYOUs = 1,
			oeViMnGeDrcFmFpGjxNxpIWDNrWR = 2
		}

		private const float dvJvOjfmsXNAZhYWkIDkYRzoeo = 4f;

		private const int NoIkHJatIKHMFGIHJxPWgXaDsAp = 14;

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

		private const int zIHkGIeYcMDaRGeXwfFtgJMqCrT = 17;

		private const int LjkFJFdwWjkacNFuHKhcSdKXbIx = 0;

		private const int eFEujnzFdgQaFNkzhyMElEYUQpf = 2;

		private const int IKAUooqrChnNMUEgDgUKDkDtEEcZ = 64;

		private const int APjJtVpuDmcOlOlfXKjFCMfLimM = 78;

		private const int plAlWORykQeFWQeOGPmtOoYPJHZ = 1;

		private const int IgQoAAJPoHaAawrIHOlbPWLxxyz = 2;

		private const int ZCumTorgroxuoaJPHxkSVdSICOI = 3;

		private const int BUDhuLOGKmTlaeQDaWFxchuIulm = 4;

		private const int tTDFvKnzyiFuJKBhyddRHCAutNf = 8;

		private const int mLIOrdcFcQnJoipBvAPhExGFwTB = 9;

		private const int mxgKMFTxnGPEhllFKUFptoGvbAe = 5;

		private const int uTjcRkafXxPLyUPnBjuQiDegdGlK = 19;

		private const int YuAStqtMMYIfpUCzBBnpTSXOkPS = 13;

		private const int ZWYDnydomnfnlykIratyYSHRdYJ = 35;

		private const int cTxQVYYuJvwXjsDfbfeGBTvjodJ = 5;

		private const int RptmQDYOSdxZynZEykJVzILVINn = 6;

		private const int htOnuosKTjBSBGsvAIDNeNsAKCMg = 7;

		private const int PutUekfrTjKkWagCNWOCRRfCmiK = 10;

		private const int VvMOFuIWBZtSqTPvGDemfKGlCMEB = 30;

		private const int qGcGreqVxmWnmfchMlQhbisdSNC = 27;

		private const byte TiQeDWaaXxRhffXUcTHVoZyjLdl = 200;

		private const byte zJfCJcFOEcjgSACWRwByaouajjxT = 53;

		private const byte EQfvduxNPxQsUncNvoDiXKMzWVY = byte.MaxValue;

		private const byte ZNpGOUXMEsaSBiuAaLXpbAhxTxAN = 0;

		private const bool YKJUIcRGCcQQSaYrRCIuahfahb = true;

		private const int GWfmoxKYGOQsNNKnxeuBwNBXojg = 25;

		private const int ejJZTrzvYAKFlZxIakSoPhDHqkC = 187500;

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

		private readonly bool ljIBclIgiAANWFrjBNeLyQYASYAC;

		private readonly DeviceConnectionType zSxuyyklwzGDTiEzneYdlGuBobV;

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

		private readonly OutputReport NqIwrAVCcNbKUFTUcaAOSzVPjfgd;

		private readonly Func<OutputReport, bool> zGragaBdAvmiqiZgBpxhyCoTgvTK;

		private readonly Action<OutputReport> QwhNoqAoCzNjUBkTYKdLiZWnfeJ;

		private readonly GetHidFeatureData jLgBbGDcVRvAZcJbnMrFEeEaTyW;

		private bool ChxsAQNkMjrIBiHhweumALkMRbKm;

		private bool IZBWfWUNcbReDADrJiiJHlbiFdq;

		private double vJPekyDfSWpysDDTKxcpOBINQzZ;

		private byte RieEoIkBuXXMSnStcWRVzbirHTK;

		private Quaternion edVttfsEqfZxArTmbWJdBuGrlaI;

		private ushort NLNHoGDjYoMQVfKVjoDLPdHbHHb;

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

		private Quaternion jYAWvSKNhhvuSzLjGCEUgAUOyIJ(Quaternion P_0, dJYkugHwNpikPqqHvvIjeSHmCcZ P_1)
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

		private bool hTiEvFcTDyeajqZpnIEoGpUpRnK(Vector3 P_0, out pKdGDClbhugTEMhDXdRBGrqMOCIz P_1)
		{
			P_1 = default(pKdGDClbhugTEMhDXdRBGrqMOCIz);
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

		private Vector3 ExEGAyFfPmxyfDcqOngPMeoFdNPN(Vector3 P_0)
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
