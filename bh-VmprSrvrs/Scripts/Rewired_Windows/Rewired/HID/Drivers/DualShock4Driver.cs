using System;
using System.Diagnostics;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualShock4Driver : HIDDeviceDriver, IDriver_DualShock4, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		private enum ruJOuhYLPMaCiAqpBJMWvpGxbBrOA
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum fzaCQJuUzBDfjWkdbtRacrpJArot
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private static class dzIITeDaVDACSqPIDFfwKCEiyRfs
		{
			private const uint tQEeHSZbCOBMvlXLJGePCGooMNIY = 3988292384u;

			public unsafe static uint tPTyLWvcFmWOoocwnISOwMnxBCSd(byte* P_0, int P_1, uint P_2)
			{
				return 0u;
			}

			public unsafe static uint rqhucABlHGUqLQGpvjXqGQWzHqfk(uint P_0, byte* P_1, int P_2)
			{
				return 0u;
			}

			private unsafe static uint ZbueHhbRjhVBOxUAWLAEiVfmrnKC(uint P_0, byte* P_1, int P_2, uint P_3)
			{
				return 0u;
			}
		}

		private enum PhnUuOTegMxgMvxyWwaYeIvyIElF
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			Unknown = 3
		}

		private const float lGUkLYtzAkQKVBmYGtNTbMutzTGs = 4f;

		private const int xvrFyGeNwwUJSpmEnoiHWPaUMHFCA = 14;

		private const int gRXfOpHspNvBguAUZOYqawGhrCliB = 2;

		private const int XgXCbIJKVnZrHgfWAhpiCjzeFORt = 0;

		private const int AboljghgckAErdAQbvYKPLKpmPmcA = 1912;

		private const int pvMYbqwCHzdJtAspYFKfjGVKkVID = 0;

		private const int ihuvHYnDMsTzHhGNrMcCCNLxhNjU = 941;

		private const bool ZfDmCRcRveCgTktcbRhVYSVkhpkI = false;

		private const bool dylAHQAlPLNuQcBwAkfUIncRbPbOc = true;

		private const float TqVohkabOHjSqaaYEgXAPNcWSNjh = 2.5f;

		private const int sAPyGaarNafzeeCpHWTlnURndShAb = 0;

		private const int nOafOnUOhhLMeqKCSvcAvvhPAMEP = 0;

		private const int JWrJKZqNambjrOxqKaShaquqpGHfA = 1;

		private const int zEwElQHkvKQfuNMveZunUgiLfHosA = 0;

		private const int VuxPsnedWFfyhdapnUXHICqJCMsK = 0;

		private const int MTUoAVlJFlDoOCZIfkGMDbMNcpxvA = 0;

		private const int OcLaeLnGcCoyIAXBsQABHjFRUcfN = 1;

		private const int XfOyUwVgBCFvEOmepUWpKzjQUcaK = 17;

		private const int JdFbecOARussehYeNSqskpyeOUrx = 0;

		private const int sEZfGprfQaHLwwHyhomgKmTjIwGl = 2;

		private const int ZMKtVIPdSRlnVLPFnrxzcgglTUys = 64;

		private const int uLZXvmptAOUQmbjPcMxQcmImUQEH = 78;

		private const byte KQKxFvADmrAMczEalyeqMviSbSlL = 17;

		private const byte aBCejBUOBcYBbkBcpkXEEJuRCnJe = 5;

		private const byte MYsFyarWoKzQQLjCarwUaeiNjaWGA = 2;

		private const byte NbOZzkVmvfkiqsRwygELtTMEaaWN = 37;

		private const byte rhuZFCLOCAepZroiNXraaWpqrBre = 5;

		private const byte qTDUrtdbrSVbgeRkToTiqSzcouyW = 41;

		private const byte MhWGEpAQNjDNLLjHdpLflojzTjvuA = 163;

		private const byte NXeOwbulHcBKuttukQjqfFMOLzbE = 49;

		private const byte miWeRqKdzeNyRDgCDGchznPEaarO = 18;

		private const byte FbfUXbCTZCmesRJcRqDXJVATQqmp = 16;

		private const byte wvoyMSahrPDXtbhXiNeKbDTERLTwA = 161;

		private const byte CLtQGpIRqbItbZIQLUhdlzDyqKYO = 162;

		private const byte brgEeFiagCPdbKuMKdEuESKdJfPFB = 163;

		private const int aapsEHBBYohqnuDtPWXihdtByVKM = 1;

		private const int pJaFOBjdqaDsyvHfAUGemEBREAlIb = 2;

		private const int aqXUNFtNWzeJYFNAQEPeYdkfrACE = 3;

		private const int NzhGauNDBSpLiZUsYkAZTLLbYgbU = 4;

		private const int bFyFrMKHRpCuEIZIvbZTbGguRMqd = 8;

		private const int TQXFOzzDxGuyJSsdFfArVyGiFIrH = 9;

		private const int JTiicZKieOabNCJdzrUipTdbpQlK = 5;

		private const int BaIRUnzUrIaZKjAcGvcihvoliexk = 19;

		private const int ecqMIqZkctEZtPRZDtetnFJCbKCBA = 13;

		private const int myVNADrhPRzLtGPbpvQdnOfzFDNR = 35;

		private const int ZwMUoMCicrGAsHpeHYAypvTWhiOqA = 5;

		private const int jAYbiAJTqJYMXyKAWVfxEWwnRqDK = 6;

		private const int aAvWPEAhYouUpbdwAoNYMaqMbuZj = 7;

		private const int wcQEXVpLVZskFidATCNaDBScBexLA = 10;

		private const int wsxiXqVgTAYUBSFmOLXrvtzsYlvD = 30;

		private const int lkoXrSDfCkpyuytLrDcCkjIsmRHQ = 27;

		private const byte dFnKdzkjNRCmRAfDKjRPeOviYGSfB = 200;

		private const byte cmmdjSFHJZCaMRcDNOazCGvgMhYk = 53;

		private const byte diUoJzoWVamVdHnpFZLXQKFQVfGS = 255;

		private const byte dpstCwQqrlbCFnfDIxkqQWxgctRb = 0;

		private const bool dLYTLrOQYrkGYgruCDQgtlzbAtae = true;

		private const int brixosYvtdgcAtdDyxtZBOubqPKg = 60;

		private const int zftZSzciuTGIuIeANPJuUmHNMiifA = 60;

		private const int LxFyZSXlRaDqXPdoqxZMHBZJNeSb = 187500;

		private const float CKHFydFRsYwmPKafgqAAbeGKQYgqc = 8192f;

		private const float frcLHVhfhOxvlkLJkPQbNhYebdiR = 0.0010652969f;

		private const float EmxfOefrkpJpuAxgOxUDbyFfinXkb = 0.06103702f;

		private const bool QlFhWIvzQEdrxiEdXdNmDqaYVMMD = true;

		private const bool IJmcWQKvkzrkeNJPPBkPDAIOFwDY = true;

		private const bool vMUBQlEyNQwzPMoxPRpoYUqAVReO = true;

		private const bool ZmMKyhjaWqbFqUEOfWYoDQAFxGgG = true;

		private const float pkRRCnuiPovFeFaiicPmIiHNMgsd = 4096f;

		private const float MZvfMfemmKZXxlVvRoEWKipOJzpJ = 16384f;

		private const float fhXJlpNdhNldtoFmmdDUdaSHsZWlA = 16777216f;

		private const float nrMKfrxFmEYFihMAjAUshyydAqWBA = 268435460f;

		private const float QTuAwUbTjYEWPoLSlRHuwGxpntxCA = 0.01999998f;

		private const float kCTbhEgFbqbGYwBIHpBfpWoOUcPUA = 8192f;

		private const float KBsqQvQMFoqeJqamabtEVRhssnTn = 0.98f;

		private const float WEvMdRBkJXeowiHTaBxmBXlLRWAM = 45f;

		private const float JSoyjUaNpaHhngZmnAXfaUzuXRorA = 20f;

		private readonly IHIDDevice odKkSTumXHVlmMIfkntqYLybJAso;

		private readonly HIDProperties WpREqtiSwPiIdDtpTNoXManaRwAmA;

		private readonly bool xkcVUfLVDSDkmkEQfBkhyhSHKtCy;

		private readonly UGTokEHpGHxdrwhYtrRotjdnHkVm NpJXtlPhunPHRitAkHvnUIjnjsiH;

		private readonly int mljcpTANNCAmSxvintbEgNcGzhKCA;

		private readonly int BkgVjKCILLuoHxoOczEoWqUJCaKE;

		private readonly bool SqbZIPZPVcbujFPpzsdDNKYJZvgHA;

		private readonly byte sABApqfcfHjZXgasQIgKcWCvpJLfA;

		private readonly int cCSakjnTOdYXictKfkZNbKEXLREA;

		private readonly int erUvyiZGmINqkOVKQSTmHfSejsiX;

		private readonly int kGYwGbBpcquhfvqvPbufEKeSXMupA;

		private readonly int qWWgEjOpcLKQFISnBEUYBXExpLxlA;

		private readonly NativeBuffer hEmChqExFRHXqNumAgKrwASbNEcfA;

		private readonly NativeBuffer PwBkUFgcLmWqKcFEuzJqykROLzyr;

		private readonly kotbTAfQioNEwLHSkuVgCDNCKFGrA TOkhpXZiuJhDFroIKiMuKmdrllycA;

		private readonly byte[] oattqsSOAzwjYHSWzfgBsMBMajAeA;

		private bool SRDaXVhFXoDKBCaJeTLyoQXjDPAnb;

		private bool GhkcvqDsFLKaBIEODzbefioiYNzzb;

		private double ocbBXwKoIsPQJnCqawVKcJQutlHr;

		private int dlKTgrIJDvYggZYJaucgebitefBs;

		private PhnUuOTegMxgMvxyWwaYeIvyIElF HNtdtjeyGhLLhWDUBglGjVtzlEAwA;

		private Quaternion XMTAfybLXwnhSKNWIJNYbTsbJKPHA;

		private ushort uvXEZHJvOedPdwAipaoyjNdQDsJIA;

		private float fHnfcubqAySAlGddcvRAZlzJwOWaB;

		private double iEAUNUeGxNcVzhExzEpQjbxNlbir;

		private float rpQsVdIDLAtCFgmZsaVIvMTelCAF;

		private bool CUpqmQIeKUMNUUXhRMeVxtOHLTRy;

		private bool rnSMWfRFuQnxrlTQrwRrmFlDqOAH;

		private bool tWqPahlcATXuksVjTFbpaTbtcCxn;

		private bool yiENBIqXtSMNgMoLYMkcSdFteYZgA;

		private byte cltlDVIKqZxAkEALUfgaQCKrQnrB;

		private byte SqLzpYkWLaLLCggjKcyTMRcJHsTQ;

		private Quaternion uZWnCiGaGRXLZzeFYHvgccwqnVNr;

		private Quaternion cgItPNLaYKcNgkUidkSlfuJvFoIhA;

		private bool VjwCwsKtUSIyxsDenKARxNFzGJK;

		private int hcUKKlnqljjwMbQojZskbaXCyMsuA;

		private int[] CMfyfkmIrQIRpYkKhfBGfqwWMwPPA;

		private int[] NtRXRxjhTrdSYiOdZQBaeSmHHGHnb;

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

		public DualShock4Driver(InitArgs P_0)
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

		private void LguaZnARYBOgbqygrPdtcibVcqeEb(XhYmzuUQGnhOTiFQlJuRwfesjZJm P_0)
		{
		}

		private bool SjWxbsUAppyuLabVwAPlOLHmduQS(XhYmzuUQGnhOTiFQlJuRwfesjZJm P_0)
		{
			return false;
		}

		private void ltBlOUXHOtuethNYgzhNKyBDCFoL()
		{
		}

		private bool QBXseaIjtJpWjOpqFqSlmfFBabxK(XhYmzuUQGnhOTiFQlJuRwfesjZJm P_0)
		{
			return false;
		}

		private void UcOBOpgAJfkVyPjzCjryWWHtXxtL(NativeBuffer P_0, double P_1)
		{
		}

		private void eRuqaevxhjUNodetTQAyVczuQLJj(FWfncLHkdkAtpfBEQVIdHvRpLZvXA[] P_0, NativeBuffer P_1, double P_2)
		{
		}

		private void pawEAiGspokzIytzNfGamzAIfxlZA()
		{
		}

		private void WfoxaFRXxWcGkIsjGXLYJOPRbVhF(NativeBuffer P_0)
		{
		}

		private void qLtHyvCBQloLDrPFsTvNxqWHyIYk()
		{
		}

		private static bool lJOFnhkpdIFLqhISJpAPCFmpxOXXb(ref Vector3 P_0)
		{
			return false;
		}

		private void jtgSJEOPRpASVleODHFGvaTtfscEA(Vector3 P_0, Vector3 P_1)
		{
		}

		private static Quaternion hKflnZnMQBGBqgvBHHwQHIglFKmk(Quaternion P_0, Vector3 P_1)
		{
			return default(Quaternion);
		}

		private static Vector3 KacicmudkdFuxMeYoMBHjPKJWvtg(Vector3 P_0, Vector3 P_1)
		{
			return default(Vector3);
		}

		private Quaternion XCQDVGaTwrfmUqjeLOHhKWuGNwy(Quaternion P_0, ruJOuhYLPMaCiAqpBJMWvpGxbBrOA P_1)
		{
			return default(Quaternion);
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			return default(Quaternion);
		}

		private float csTLDILoBOyDzuGEBmvUAAicoEAA(float P_0, float P_1)
		{
			return 0f;
		}

		private Vector3 AuIaJFydVgcJyHRgTUrqEUqRxVXo(Vector3 P_0, float P_1 = 0f)
		{
			return default(Vector3);
		}

		private Quaternion aARbGFQFVwGHUntjlicPgycmqowFA(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private Quaternion uYZZywAetvVVruFaghgpVWnHPfac(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private float DxZDWyetKJcWnIIPnGFLnNiZLJbN(Vector3 P_0)
		{
			return 0f;
		}

		private bool FmbLKgsEDcEQKBJYOgiNxrRiGfAzA(float P_0)
		{
			return false;
		}

		private bool CcqbLacstJJQKTuhtfPFhyJCIFAUb(Vector3 P_0, out fzaCQJuUzBDfjWkdbtRacrpJArot P_1)
		{
			P_1 = default(fzaCQJuUzBDfjWkdbtRacrpJArot);
			return false;
		}

		private bool DIaLapOQUVKqSiRUmROUqCmqGjCV(Vector3 P_0)
		{
			return false;
		}

		private bool OgRfqwMhMIKWMUBMdgjdhoiqtnVEA(Vector3 P_0)
		{
			return false;
		}

		private Vector3 MyOnutQpWYLpVDdyywYBLtqWwTyt(float[] P_0)
		{
			return default(Vector3);
		}

		private Vector3 UkcAuyrTMpTtUIdvOMjRKMHeIkkDA(RingBuffer<xWLdBqQUVoBsyEoHRMNAPSsWHYdgb.fxhQEpWZkJURQyIkTidPochghpyBA> P_0)
		{
			return default(Vector3);
		}

		private Vector3 fCiAIrFgCWfSpMNxgoqFRjTpchjD(Vector3 P_0, float P_1)
		{
			return default(Vector3);
		}

		private int PCmUAVyJIEfjdEUQipWcAEikyWjAb(int P_0)
		{
			return 0;
		}

		private void WjIBEHCppKWUwojzlvzicRbHonGuA(byte[] P_0, float[] P_1)
		{
		}

		private void PUyMFnzjrebtxekwdnjvpbITipWR(byte[] P_0, float[] P_1)
		{
		}

		private float cnxfbSAFcxbvAcIkFvQvpOmqhOGKb()
		{
			return 0f;
		}

		private void WTCSPDOAraVJJSsqYoHxlHQlTFBT(NativeBuffer P_0, ZgmSdKScSeDYiGUNgbCGiBZRFYxC.TouchData[] P_1)
		{
		}

		private int JAuaumOVoTCNXCsloOWPGvFjOyrY(int P_0, bool P_1, int P_2)
		{
			return 0;
		}

		private void nBvmFvxagvAPwGsuBRHuBvnZHkqdA()
		{
		}

		private void pJcoCAHnlefvimZNQEmrCsOZxlmA()
		{
		}

		private void ymgntAqsrYFUREncjNdqFRrgmLkhb()
		{
		}

		private void KeSclDeZSxSrmdpGCksziKdiLFqPA()
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

		[Conditional("DEBUG_THIS")]
		private static void uPAlJCTOsPIHrUDGDbLCbCkLuyzC(object P_0)
		{
		}
	}
}
