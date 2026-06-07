using System;
using System.Diagnostics;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class DualShock4Driver : HIDDeviceDriver, IDriver_DualShock4, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		private enum mMBEPkMiKPfBTnXtUUeLlnFTIrSn
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum chsblKgNwWayCHrvijRbiSidZfRH
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private static class wESlDjRwSYLnnzWMYNvlSVFSxHWI
		{
			private const uint yIWRaRVSHTwRQmsROjOQWZzCjhlr = 3988292384u;

			public unsafe static uint eYZHRYnjorVLQneCeuPDoJPBhzUb(byte* P_0, int P_1, uint P_2)
			{
				return 0u;
			}

			public unsafe static uint kbhcDTNAYXYNeDnroGtphUNXybYuA(uint P_0, byte* P_1, int P_2)
			{
				return 0u;
			}

			private unsafe static uint KkdJQAvGSiYNwwZGBdDNiPQWJJdJ(uint P_0, byte* P_1, int P_2, uint P_3)
			{
				return 0u;
			}
		}

		private enum QpmvBBZrFVybTgoZkGHSkDGSsKCA
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			Unknown = 3
		}

		private const float koQlmDhVXjSNiCKCRWjWjPnPCrnX = 4f;

		private const int sApwHLZZjbVOnddGkUIUBrpebTqK = 14;

		private const int daBWxwgSuOqGXJDSIGovesVZgaGcb = 2;

		private const int QmFWVLTFSqALijVAVTxjIKwYiBik = 0;

		private const int BIopOfzxhzUFEJfCgRoZBqTBmdBq = 1912;

		private const int kMEzEtaaVuwzQPiaZfJctEHgaAfN = 0;

		private const int xpiggNBjHdzwwOcFkkMPjOOXRbOwA = 941;

		private const bool EXFVxSmXqdLZstqaqpMSChSARsXK = false;

		private const bool sEdYkZfKAOadtUvqrsFZtizVglGiA = true;

		private const float MVqFdziZYmeBTtUPqCZfXhyjwQcb = 2.5f;

		private const int tiDblpjgInXyVQXnWSriUGSHoyMwA = 0;

		private const int igarnqKIiqSLTvGYHuOFbtabDwpaA = 0;

		private const int CQxojWifdljkALvmXbyohenWriaZ = 1;

		private const int muiuKZcsaXnkLRalprSawuddHjLw = 0;

		private const int IMdagdkPpScQgqrVigMvMrrpmJic = 0;

		private const int FmSEdYdgIsztzGeIkMmTtFNhxZCt = 0;

		private const int XITLvOhPjLrIrDyLbghWLjOnILEI = 1;

		private const int MmORbbNCWJHstLiqabemSkaywsFQ = 17;

		private const int QUXZDnKmYvjaZcKoUKofiUnYcIIg = 0;

		private const int vXFKRutpXxAEBhOimWfhYNEPmThg = 2;

		private const int IxYDyDcLHUNgeRGVqiRunevTtmHJA = 64;

		private const int pFRaylzaZDsTNymHneaZIsXKvinKA = 78;

		private const byte PhUWdsSUlkVOXoqsaIvlSAfsJmWH = 17;

		private const byte dLYDliQdHrBjMdWTyUqZKdQtwJei = 5;

		private const byte TNkVZnvtpNfPnIKApPYNqvxvEQjv = 2;

		private const byte SlUeQxfDqqCdLmdcfvoGKlDsoStBA = 37;

		private const byte gbayeXLDDRvJqgtyWzHlwJtQHXAd = 5;

		private const byte tDLEMgbxgNKuPOpmGzvfPiaCISBRA = 41;

		private const byte FWYsnwILYsBOsohDmGdmsFmLDDOIA = 163;

		private const byte SQydonkqezCFZmvMzgCnzImytYUC = 49;

		private const byte zSKpopCUwbhboUQQQfOuziCccQADA = 18;

		private const byte KhhguyAIUXPdXEHaEptEHzJjKrPL = 16;

		private const byte vcaDfLKyoKkWEogZfIKBSRYcCrmQA = 161;

		private const byte ZDrhnsWNpmcuWMIKWVPunXGCythm = 162;

		private const byte qGwWBSiypDlcUpKGLhihbIZhbRisA = 163;

		private const int hkvAZGXTDxFtWnYxKLztfSojBjpQ = 1;

		private const int gpgutGbmdjezXKgbBYgfYkSbdkQeA = 2;

		private const int nYRpMinCterllYRMHwbEUcAHPEpC = 3;

		private const int UGzmZbJqEJkMTWqqPGuUBpGRdUSv = 4;

		private const int uvggHbECOmVlANRBkLgGhTDMxOBe = 8;

		private const int KBfsoUfmLxvgsBnMnJmqNZAuhGdA = 9;

		private const int UnaRFASenDlxaNgzmJRxdRkJBAUl = 5;

		private const int ARIcOifbqPIhxyJwFINhrFvHuUGt = 19;

		private const int dmmNlnJQzsiWCQoDMWQwvIYoAyno = 13;

		private const int leFFdYdlKMDKSEVzyEamwzaXKheAA = 35;

		private const int ShUETZJYbkYBHwbqIaktHpGazCrWA = 5;

		private const int kKAdHXRxnUeJwDlYHFJktWrDajcRA = 6;

		private const int tnNrZPMFtprOcygDVQPUGbRyBcDB = 7;

		private const int lHKcmYnUCOrmobsEKvEfXUVOCVOI = 10;

		private const int ddnPnVnbJaHcDQFPavojCmCdqGcA = 30;

		private const int gToBMNcBZffxNovFmEKVqgTKAzylA = 27;

		private const byte cpdlAaoRQOXraiSFRzwMSGseDcdu = 200;

		private const byte fwcUlPLKOCPOnUanYaGuIgsGwljj = 53;

		private const byte ibMmoawfOpcQSkUtWfbGdAUcyBnyA = byte.MaxValue;

		private const byte cqdGmPKhXwoDxoAdNBYvMgHWGMSI = 0;

		private const bool geCaJsWFPgtftvhvFbgfvfiXfuJn = true;

		private const int segIxiCkJylvukDfzPGLPboHCfUb = 60;

		private const int aYfxragQzGbLHJnCUPhrgrUdXIXW = 60;

		private const int AeFDNSDuvbIVDQnKdJeYNUjdbRPd = 187500;

		private const float TsHTHoDzvXqrmbNjrHmVhuDsAoJCb = 8192f;

		private const float iJakmWlNiPFqQtWJdYlcJrTQVJTo = 0.0010652969f;

		private const float DsdulnpGtySwJmWkFBuIuoSYtJsq = 0.06103702f;

		private const bool TeZGPqrkaXqKJnAjKLKjXhaibpjD = true;

		private const bool TBkxODKWtslrHOcVKYDKFtZuYSuh = true;

		private const bool yeYdpqMUOVkEmXUxWRInKltcpIFH = true;

		private const bool QVSbhirvNhajZPEIoipbFHTnFPDK = true;

		private const float gBquhHkEdQkmuMRkhMkKQznpweZI = 4096f;

		private const float BthCNechnNjCEckPSfIVkWkgclIcb = 16384f;

		private const float mOFmEsFZkUGeOfjyzelNioXdLntpA = 16777216f;

		private const float oyClYurZlJsCFmoCsewdasdDkYjaA = 268435460f;

		private const float RkmYXBTCsRpZsGVGujhbYriTABSM = 0.01999998f;

		private const float fJVCMHHTahvJzWAYOplgHIxaHGcEb = 8192f;

		private const float BJiBPiKNExQbqzhipDWXNGaYjHiS = 0.98f;

		private const float BXxgAMLqMWzQLbAPnCZxLmghkodr = 45f;

		private const float MaaDIJIaifziMGYmeAtcTGuMojHib = 20f;

		private readonly IHIDDevice dWMLrQogYACkZePlvWXfcCjXWqRNA;

		private readonly HIDProperties JhHxVaEYdQsNCantSRYGaCiIgQvcA;

		private readonly bool ebaAoyNLCJGWXfrUiifcqeNbDXheA;

		private readonly DNNJRJXIFKOeGnMWgZMdzIqFiIcT QVLwavZtwyEijmWvylaMFaPVFXt;

		private readonly int tbtBQQJTSRUvjiMqcJTXDUbgBVfn;

		private readonly int SduqVPQVSQjkwksEpBJlQnydsFhC;

		private bool JhpcjIJBMdFvIrAhyiJKEUNbhPZmc;

		private byte rQDIwftriUOCcvQcPCXZQbNPbGiK;

		private int hQMJjxxUEXPWebfzHCpQzLHahKiD;

		private int vYIgVxBZnBinPaTEFkaxuNLUOWBEA;

		private int rQUfduDLvdvgYJkdYKQaOYloiyRlA;

		private int veUMzoMzjIVpaHufQwyDFpHHtmQL;

		private readonly NativeBuffer yNszCfrkIWOYXnAwZmceSrXZwoRK;

		private readonly NativeBuffer WMBobGmiIfppxbjIjynfmkAuNTRy;

		private bvbVwPMivxlHVYJUjAzbVqMqOlbN EZsrUYJOzGbEisMOZGarAywDoXHZ;

		private readonly byte[] bithLrOgFqRgdAtAkGKMmpQwPvpL;

		private bool DlHzeGLhCxbNgElZGNxrbYOzSvtJA;

		private bool VqwzUdmQMAUjaRoIyyPjsxjeDzEl;

		private double zuniEdMnRbTpqeHsldtPkMDYVsaH;

		private int erMuaqISGsFPJUDEzOMjcbFXFlee;

		private QpmvBBZrFVybTgoZkGHSkDGSsKCA QCtGHomUNkIwUDRMQBENBBiHqubl;

		private Quaternion OwNwIfPcWdUgrQMABDfZgZtFbcejA;

		private ushort nOXrtCTbLrCuAvkkslCvjQeyaWaT;

		private float eqtTLbsBLlOFCoZpcPvLbMkSUejM;

		private double lUOtMBcQuQnFKsQduJTJrsobLzXE;

		private float whIdFsMsKVKeozGHbbOHpRNAZTjQ;

		private bool VZbFTVAAHDROfFUlELMUlvFxbzyr;

		private bool wfKdnsNevZnqQsQKuYuigekjKYdw;

		private bool ofqDHkzyFUSxXrzlEhRwssiHPaES;

		private bool dbOngFwDmVDIXfHDTkIjdKYJdccGb;

		private byte lVjEkWAgNWqItDOGKPlxGALTiDCK;

		private byte VgLMVDctIfMFfhxfFYTSATtdUcik;

		private Quaternion pYYUvaKXCLKcbwJRNTprgbSylixA;

		private Quaternion nyWDgAgZPJtMJxHceXysgfOZfYfrA;

		private bool AXxZBbkhwTPkPaEHrHpXFvKtNjcj;

		private int oSKljohkiobznBXegmUnDoAmsyPqA;

		private int[] VDtNRjeaoXBOYDGMqInTfctaTYyiA;

		private int[] SdPeqoKhOaUPfVXfGrhxRGntpqeYA;

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

		private void QzuwyaDOHSAnUdjewsNksAsxfSBIA(ApGJLxYzFsobivPGgnsYkhrKhjyh P_0)
		{
		}

		private bool FdWIvpAhkeevstHZdJdgGIKEYOdx(ApGJLxYzFsobivPGgnsYkhrKhjyh P_0)
		{
			return false;
		}

		private void kBLKnXHoTapdSulApCJIKvSpTiHW()
		{
		}

		private bool THFRdhKaQGmPAZmOYKeUqCehWkOD(ApGJLxYzFsobivPGgnsYkhrKhjyh P_0)
		{
			return false;
		}

		private void XvQcImaUIqGEHKlxHZslWBGBdTOH(NativeBuffer P_0, double P_1)
		{
		}

		private void dYwRHhdggsgRPeXwInqtJmkYUkwM(MdziBGNqephqKFAONQgipbAHplCzA[] P_0, NativeBuffer P_1, double P_2)
		{
		}

		private void gIiufvcdupEefByxKRezjtJkmDGZA()
		{
		}

		private void VmqKHGVgyHxwZFgfLddNPmWxLNUv(NativeBuffer P_0)
		{
		}

		private void zwjqXsWvPugMyiQLjqBAvNVfAIrfA()
		{
		}

		private static bool kpOTUotEiBcMLjLSgpcORVxTAikNA(ref Vector3 P_0)
		{
			return false;
		}

		private void iKygiZMQIkdPsioEGEhDbdUCPGPUb(Vector3 P_0, Vector3 P_1)
		{
		}

		private static Quaternion aVhcYSlCRUKTVbBVCkjRLOlJcjZkA(Quaternion P_0, Vector3 P_1)
		{
			return default(Quaternion);
		}

		private static Vector3 ZjwJDrobloUCSRgMdsxMzCFloOWi(Vector3 P_0, Vector3 P_1)
		{
			return default(Vector3);
		}

		private Quaternion MQYgCYCGAtqeJRqrlatYzVUQdYJC(Quaternion P_0, mMBEPkMiKPfBTnXtUUeLlnFTIrSn P_1)
		{
			return default(Quaternion);
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			return default(Quaternion);
		}

		private float hQyeYQUfQWnvowEtHWSeWFZWAozC(float P_0, float P_1)
		{
			return 0f;
		}

		private Vector3 ZJUiXUaBWxGYTEQuWBujGptnbzof(Vector3 P_0, float P_1 = 0f)
		{
			return default(Vector3);
		}

		private Quaternion nsJnhMGNEfMnxgJvcEfUcvnKUqTJ(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private Quaternion dPTqLdIzkiAPwhTZrZjxRZvnjuIe(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private float CRRRdvqWNIgbUDpPmWrYjLzvndAS(Vector3 P_0)
		{
			return 0f;
		}

		private bool OvhinfmYAdwRzMUITIvEtzIKPobi(float P_0)
		{
			return false;
		}

		private bool BjsCqxCiyEtVvHbfgevAvgKuellrA(Vector3 P_0, out chsblKgNwWayCHrvijRbiSidZfRH P_1)
		{
			P_1 = default(chsblKgNwWayCHrvijRbiSidZfRH);
			return false;
		}

		private bool QQoauiIWVWmFnpfOjtpZwatIfZdGA(Vector3 P_0)
		{
			return false;
		}

		private bool PALQTzUPLDCVxZXQyULuuyfWhNox(Vector3 P_0)
		{
			return false;
		}

		private Vector3 PrIIXqMGTBqmuEZuvlwGBGpkRrRw(float[] P_0)
		{
			return default(Vector3);
		}

		private Vector3 ZAcJIjjfTodqlFhbDLNCCRISFGVy(RingBuffer<omJTadSTUfHtFlRTSobFSDlwxmMU.wmlHdmQTjMmOhjNiIETGodgSQDTq> P_0)
		{
			return default(Vector3);
		}

		private Vector3 sLydIsPnfZucIBILrGjOBBcVInII(Vector3 P_0, float P_1)
		{
			return default(Vector3);
		}

		private int SlogdYmgHZXmQFJYdUotEkbQViQN(int P_0)
		{
			return 0;
		}

		private void ZzKvjOxTwZEBPyiraLVnLmgpUDtu(byte[] P_0, float[] P_1)
		{
		}

		private void IBcrdkvAsjJuArkymATofKXfgLjkA(byte[] P_0, float[] P_1)
		{
		}

		private float hEbWABXmtmaytBdyaSsaYhdFOofq()
		{
			return 0f;
		}

		private void DeAhoWbMgflCyrLgHAhyPtNHobwxA(NativeBuffer P_0, EWahEPKvarCbHRiElXgHuZAhtMQj.TouchData[] P_1)
		{
		}

		private int KKoDBhdYnIIIqOfvrcoGLbCDUQSdA(int P_0, bool P_1, int P_2)
		{
			return 0;
		}

		private void ildOcsnuloUSLfvcEWntXIohCWPY()
		{
		}

		private void aQNFENYfwweqEpiZGeFjADpiGTYP()
		{
		}

		private void ttcgQZohuBcXcFesclNlsFaOOnBEb()
		{
		}

		private void ZnEZOIPOBaRqBwDGJMAcIlyGdrVJ()
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
		private static void zxWOmFZVUKXTCRJkMDePfhBzGwUG(object P_0)
		{
		}
	}
}
