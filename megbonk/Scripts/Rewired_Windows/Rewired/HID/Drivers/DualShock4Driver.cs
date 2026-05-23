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
		private enum kitClctKihZiXmKkXMXxdbGInNah
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum ckAfeOCHQuMmQPQqpQFPMczqbBhDb
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private static class atuFqjbqgcWNbmmBTQrHDMMJJvqKB
		{
			private const uint yFmlPRynLvRQShERNwsNKuiLrXDB = 3988292384u;

			public unsafe static uint wpnOEHEkLJjRPaLvvsIfgoKMzwBk(byte* P_0, int P_1, uint P_2)
			{
				return 0u;
			}

			public unsafe static uint aQNvUVmWqvWTsOtgzrZHOHWQFbeP(uint P_0, byte* P_1, int P_2)
			{
				return 0u;
			}

			private unsafe static uint ClJFOSMIcKPSczeXKxLhqHDLCDXz(uint P_0, byte* P_1, int P_2, uint P_3)
			{
				return 0u;
			}
		}

		private enum MbXScNgSTlIodlRzYbgnewUBkkcvA
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			Unknown = 3
		}

		private const float mAavRRWbtFDpeBZFSPeoxicCrCBk = 4f;

		private const int ywZaQTqXJLNIbskPzwesBnunfnAiA = 14;

		private const int pytAagHEIsXMPSmVTrGNaxISJasW = 2;

		private const int QfpiVBcsiWiAsQoVUynRcWtPXgYEA = 0;

		private const int XgUDFnCNXDTQAGNDlUvlXWOUhkzC = 1912;

		private const int sBkKilDFbAvsUCyvUfNMhPCtjSBeA = 0;

		private const int vIKdgXSRfTsmknxMvwTbIbRGlpqf = 941;

		private const bool MArvGKJCCReBukrdbaVefMNFFJhzA = false;

		private const bool enJAfPKngiurfDQjcQjvvJsCAtqn = true;

		private const float QwhpEfVKzeMwHquZOrglVjqtQyuN = 2.5f;

		private const int zPleddFGaBjqZWrePNZSEdDWcyiR = 0;

		private const int eiQcyvpGbQVFcaPrQklibzdsckLC = 0;

		private const int QyXgSQZZPUsUYArMGGAZqoRIkEsA = 1;

		private const int exECDDFROfiuPdCcoqaWikqjyrhYB = 0;

		private const int OcPQnqREbgCqUHrylGCgHCgoWazEb = 0;

		private const int PIsiSQCiyWlorLoNfWgtpOAeFOaf = 0;

		private const int BpxZOEMsPvBvvEMSqwSqPaDeqUey = 1;

		private const int AmecAbHsqjaulJIlrmKKtWllXufgA = 17;

		private const int EWxgMzajkVofXixvHJyPNyyBTibyC = 0;

		private const int hajDPuEGpLdABGmfDniBIKBuCyBpB = 2;

		private const int IaudPHasvsiluLGVlrbWwcsIupvG = 64;

		private const int zsdxbfKPjxDXJfyUeCZpaPGHqpLK = 78;

		private const byte NKwDTkizTKyTVDrpjNaJEYcrATomA = 17;

		private const byte lIoDOobnnVfBGEiIhzubISZoYqCbA = 5;

		private const byte ZdIBQbOWVnABzZBZywufumugcKBBA = 2;

		private const byte IGwRBjgyMEzrXivFmIHmbfOzMzFJ = 37;

		private const byte guSgzVkLtftzydjdBQVTiMOVvNcv = 5;

		private const byte jndJlcIxGfsJDyYpZBqPyFnBQjfk = 41;

		private const byte BUqBcqvOuUSCcnOGbIHMqmtEdLkq = 163;

		private const byte QeOLuoDjMJBQJkzwmTWTcdHlDxumA = 49;

		private const byte pcglzIfOyBnqJPFKPkGhrBznKmqB = 18;

		private const byte MHFvocjGoptMRBFfLRUaHdKoUKdl = 16;

		private const byte nvMuQBTnMaKqSvtYqqAhHFFlpdGJ = 161;

		private const byte ZQVkFmjfJSggQHfNZgzGrIFJVmDU = 162;

		private const byte aRWaWKDBPfdmAIeNCaGLdSGGoRCub = 163;

		private const int vHXYQYmutXhnKcgyXZVZhmzuCbXjA = 1;

		private const int yBKFuWMlNHuvPXqqCdSVEhZybiaO = 2;

		private const int fPvpoCMhkAvrdNDKYrATALzOcFDaA = 3;

		private const int SoTQjxmwqbOvRLnsIQAwZJbQAdif = 4;

		private const int sYIlhBdOmIGVjDOIfdbkvfYJbthlA = 8;

		private const int GyfNbwYrUvtlkUXuJtlUTXGXIdex = 9;

		private const int YbOKGMzOLdJdaGUupTjNvrfQdJsw = 5;

		private const int KacbfoCOQbHhjBjlGGnPcniqWMetB = 19;

		private const int fCEiEdaFoSCREHGqLqFWtPXrgfJD = 13;

		private const int drhkqYKdwmESCGixpOhMlkjQxpAl = 35;

		private const int SksCJDpQHCHFBtztZEnDfGTtIoRi = 5;

		private const int mhmItXypVeFqeiGFUzaSWzyGnPWh = 6;

		private const int lVFqsVbPzTZjAbbbWAmneYmxZRMN = 7;

		private const int hJifrCjYkcPtcqkPDFRDbREeLWeDB = 10;

		private const int bnFrKdedHpuBqUvQOdZCjGtBBwoV = 30;

		private const int uxYZxVkQrXxbBoVOloOheBITEhCv = 27;

		private const byte yYLTCgDuKmlbyhQRWNagKvXbsqTD = 200;

		private const byte pYMGTRkAeqlNlNYpNTEUSPtBBsRT = 53;

		private const byte unwruiBwJTEdEHcGZHMeGFsbPEFE = 255;

		private const byte eELDVHvdTQpkxrpyQNfNInIPcCaBA = 0;

		private const bool uJgOzgfYtSvRjcCmWNoBpWdYuOjJ = true;

		private const int oyEPZnxmYOLzzldSiGbagFsGMAFeb = 60;

		private const int aZRinaJyVeLgPohVHiFTyKPufCnFA = 60;

		private const int CQjIICqIAZwEFJNsaLpeNTZyndxQ = 187500;

		private const float DzhdQgkbJbyfycgiiECxFiYdAwlJA = 8192f;

		private const float seOriQOCYdmxSuOkkXEQRfOXFFpK = 0.0010652969f;

		private const float ZZRdmtQoXEaiNCpdCxQaDcVHJBGIA = 0.06103702f;

		private const bool PknoBNAUKvQmAcFJXrpHXLivbbLQ = true;

		private const bool VwCeeDgfHIbtLzFIVjiuRZAxvMAWA = true;

		private const bool sSueyyDzynreutKsXQpPeYivlvtTA = true;

		private const bool GtsmaqCjPRcgBEiLlBIBFRUkIZfY = true;

		private const float mnUGlNBbTeSqyJHzoqawQvwurmrw = 4096f;

		private const float ByHzHyZVHzNOSdpGLcmjaKfvWlsaA = 16384f;

		private const float uZpDaUcGhuyASebGgLFjgDQuhHDI = 16777216f;

		private const float cwmFceGVNzCNSvXIhGNGyueEKCJC = 268435460f;

		private const float HHYaCPoNAdkFgXCBlSDNWPfCITuEA = 0.01999998f;

		private const float bHtBuHyOYHDkrBNHXVfKEFyheICn = 8192f;

		private const float VNMtImdJkVEtusVjiaznfTjFwJOIA = 0.98f;

		private const float HxZVoCocrgbNFcWjcbJLDajwqSPF = 45f;

		private const float AyMRQLHVGNoiODFrlaBCQujPzwxL = 20f;

		private readonly IHIDDevice lRaeaQRuLcsbHSjugvxXAkiWacvg;

		private readonly HIDProperties ZqnaCutbBoyHKjeuFgiiasxZwSVSA;

		private readonly bool cWMwlqccerlKJmmJjfVOacQqPFHN;

		private readonly RhzYuVirWegvYsLvvdtRvjIAEUGd GxfoxkgGLAqQusEXiaLOEMjUiFdVA;

		private readonly int dqZTmAaFmbhbxjRjdGvvBnsbtPVV;

		private readonly int OrSGzNrgbkehgjflkpdDMwyaIuTq;

		private readonly bool JqBuLSkQcNrOADnihhtqEPGcNmdm;

		private readonly byte vGtADxJUAaSMaJujcIujKSGqItOMB;

		private readonly int hDeHKvCdehdRuIswQAsgotWlOzQpA;

		private readonly int lskOFlmtHvztREaZAKBHRTUJWyxG;

		private readonly int fGugTowgJDqDEdYkTgNKUysdqDxg;

		private readonly int pQqeEuvNbmJjsSaiNEHpLXGCxveg;

		private readonly NativeBuffer ckUBJlSFkwkELcibEsQKADIQiodFA;

		private readonly NativeBuffer AblgESTyBDdKbqLpmZXLgBadVopd;

		private readonly ndPzSZhFNVeBDFDFsrPPRfBbUpJt SKXDOBeNcQMavdBUOMJTkzAYZzRA;

		private readonly byte[] ngRKtltjrMwZtXMLjqgoejBrIFXs;

		private bool ZGfajMeCkJjZuFgQLLZHEMJuFpLqA;

		private bool DHWFolZZicdpcGNBjdrBiNctbmuH;

		private double zxBgrrKtlNnByqhbeaXpCyWHuHUgb;

		private int ixgmbyjnmKEVZHBCopwFvacCWJQDA;

		private MbXScNgSTlIodlRzYbgnewUBkkcvA UUXCBqgZpCGSEqMNNazhfBrdGwTvb;

		private Quaternion CcbARtwowTcufJVVQMXhDZuKFkGr;

		private ushort jCrxeUcpjTWoIcBvjAoZHxxxEYQjA;

		private float cBZFOpJmjJKLQbgcdMTvduxRmKNl;

		private double xCgCkXETKaKtMdRezHvfdlriNTduA;

		private float eKcwUmfykzcqcwoGezmjhLWHgVFhA;

		private bool XuNGCRrEdvIEdSsaTihszNKadxCj;

		private bool omawcswVZzGeCtLLrbqWyDjsmEVp;

		private bool iPWUloUffenMTujqLtGWobzAfukW;

		private bool pnajuPFSrbEkFAIWKuNxSBXSyAFc;

		private byte tSLEPOpWzyiRbIiRBcjHUlCOOumO;

		private byte XKjdJJjViVUSdyXuCzauUQwqaEGv;

		private Quaternion pYeqTjzztokYyvnAAInLggyDsvAP;

		private Quaternion bawjREywlvGuFEQnlYFGnpPOYOXf;

		private bool QWZDKtXiMjQXTxuEgHhhZyZsNHUw;

		private int yvcucsQUkQzSrMnUdioJqZFvuNxD;

		private int[] XuXvKbHRGzICMSNFdhDhdqyltUOfA;

		private int[] YUzdmeUMkMHMvKTqBLSFMtswgIYf;

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

		private void WYAzrqiddohhCiCpnHbUFkhuJYpCA(GCmaQhFpjWTiwKeLtoDuCusTJlUIb P_0)
		{
		}

		private bool TUsULhxVWMLpagBAmaFYKTVDhSRdA(GCmaQhFpjWTiwKeLtoDuCusTJlUIb P_0)
		{
			return false;
		}

		private void cMfsGNkbdCzoIdGBwFheEMZinebS()
		{
		}

		private bool LMjlMnnOYgSeUQKhPAoQKkRyKQiBA(GCmaQhFpjWTiwKeLtoDuCusTJlUIb P_0)
		{
			return false;
		}

		private void FCedfwbNeOTIRTJaQQxHBCZMKrmYA(NativeBuffer P_0, double P_1)
		{
		}

		private void pYUUYnCcCQRvLrHdFfGDJwxHcKKm(GLNYbQuaOXeaSToXMWjUhtXAplaf[] P_0, NativeBuffer P_1, double P_2)
		{
		}

		private void qpECslPsUFOaxjNoFqSRniYnBNyR()
		{
		}

		private void XEWZFKeoKfDfFAmyUJNlXsRcSTsm(NativeBuffer P_0)
		{
		}

		private void vRLYmKlvEXCstjGcQjgnxOkbCDlA()
		{
		}

		private static bool uBwfTyUqGpwCFYpDfIGcHHcUkkCgb(ref Vector3 P_0)
		{
			return false;
		}

		private void wgMloNttyQRjapfLLVyfhWLCMzpf(Vector3 P_0, Vector3 P_1)
		{
		}

		private static Quaternion kwPSBUYldoOFJqIGJPVhNqgGEhls(Quaternion P_0, Vector3 P_1)
		{
			return default(Quaternion);
		}

		private static Vector3 LLOMUxFTZCEREEaLwUTwvXMysPyj(Vector3 P_0, Vector3 P_1)
		{
			return default(Vector3);
		}

		private Quaternion EDsitMlWkPfqPWTwwcGefoILBltN(Quaternion P_0, kitClctKihZiXmKkXMXxdbGInNah P_1)
		{
			return default(Quaternion);
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			return default(Quaternion);
		}

		private float hDOghQhFZkylslJBADoECqEDvYXU(float P_0, float P_1)
		{
			return 0f;
		}

		private Vector3 DouExMhLsFASHqHdDBhZlYyiObSJA(Vector3 P_0, float P_1 = 0f)
		{
			return default(Vector3);
		}

		private Quaternion pYlguQHhiLRWjmdavOsuQyaNJCfRA(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private Quaternion vybJxnlpJIBQqwOGoIzHfRIebhmZA(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private float GhsNzVPzcrCQAAKzFXgdxkqpMsH(Vector3 P_0)
		{
			return 0f;
		}

		private bool YZHuRnRoCFJirREPQcTaxeRZRRNJ(float P_0)
		{
			return false;
		}

		private bool BiUzsnDmSgZCbaporDpyopBthTZf(Vector3 P_0, out ckAfeOCHQuMmQPQqpQFPMczqbBhDb P_1)
		{
			P_1 = default(ckAfeOCHQuMmQPQqpQFPMczqbBhDb);
			return false;
		}

		private bool AHExdmhdjyeXpBeZujZlBkoIJXLxb(Vector3 P_0)
		{
			return false;
		}

		private bool FbUCforxbQBhhUPCtdCbkmQJTElc(Vector3 P_0)
		{
			return false;
		}

		private Vector3 JDeMPmpjEdcDwVpRaQDwFFuznBzI(float[] P_0)
		{
			return default(Vector3);
		}

		private Vector3 DrQACtGQvCEydOWsMixwuQPJyYpoA(RingBuffer<wlfdzvjuaZfnTkWOTlZxCBwptsuo.uBFqvefKBuWBtkgvFGvssozHNHtT> P_0)
		{
			return default(Vector3);
		}

		private Vector3 ecMLwcuWDtkwSGmMoBmoLljIFWkR(Vector3 P_0, float P_1)
		{
			return default(Vector3);
		}

		private int OdWolQHHbbgwIQTVoKNPGLuFqKqf(int P_0)
		{
			return 0;
		}

		private void TXmeJCWHMbbHFhDqbOtPNTjkDwJm(byte[] P_0, float[] P_1)
		{
		}

		private void CqIDookMWLJyCcMzhbvUnQMyzJPr(byte[] P_0, float[] P_1)
		{
		}

		private float btTAZXaBPMRefAytxeUYIlgWssPu()
		{
			return 0f;
		}

		private void TnqfNMbUGDAkoUXjEHRUncOGbcWI(NativeBuffer P_0, WrSlmJxoZFgCLSWPeQjtyKXyDhws.TouchData[] P_1)
		{
		}

		private int MhCEfrjZPeOLcgLiuQqibYLUCjoF(int P_0, bool P_1, int P_2)
		{
			return 0;
		}

		private void oCPdAqYZJUYBHkGhDJEJJyxuWxbG()
		{
		}

		private void mEzHSPnmMMRkGskUFRKXSdsxlXgV()
		{
		}

		private void fBKJbHRGYlHbivAzflwTDdvFftzk()
		{
		}

		private void PKoVNWkBtSHcLpILQPwOQxrVtpvv()
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
		private static void lXyGHVmhnieJWeCINkbdMpEkOKqdb(object P_0)
		{
		}
	}
}
