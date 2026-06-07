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
		private enum oiItXErrFRuSQQeEaWuAonFMAjKw
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum cGrIJDAfJCJTpYpXWzfUkcQlqnrW
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		public enum veiIwkesPxzjuPZHaKXAyktzmTHv : byte
		{
			High = 0,
			Medium = 1,
			Low = 2
		}

		private const float nXEeqVVMLgFSfHHRZInzUGGdBNrnA = 4f;

		private const int CslwhBCeGKNctEjyAWkxAmQhbouC = 15;

		private const int ExsCUzZluIzVOcatUJJAzyWmsyDf = 2;

		private const int wrpLLAFhadRhLJykrLMKywASEYBq = 0;

		private const int MBkEDXHJUQRczIYXuTfHDIfWIVzZA = 1912;

		private const int iGRSXCJHkEuzvqRMyKAWeBbFJong = 0;

		private const int BIDldIsuAIHANVAADiCNtRPqLQoT = 941;

		private const bool hlRwptfddYTlPEgTEWZyIsLtjqzi = false;

		private const bool ftNqrNIMcFEFBWgVBuxaDTkwEupl = true;

		private const float HLxgRXDMWPKTwvAZusJelPtVCugcb = 2.5f;

		private const int vLveCZkLAtYgzypUlBTGaWBGbkxD = 0;

		private const int pgmMPnVigUEgvwPpkSYiazqNVhvP = 0;

		private const int KmWgatQydoAQxkYiceqcQmBRFCuP = 1;

		private const int dezZNbmGAaKjVvejopeIoDLLBhoc = 0;

		private const int bbGrIURaVWFYAGLCBxNrCTIhdhbib = 0;

		private const int vXIRtyGRlvIJgKFNLHJWCylPafqcb = 0;

		private const int GKaAUpJqsZDhdbgCryKfLpfUVGRPA = 1;

		private const int ijABlisybDJCOcLskXURKHMksBkD = 49;

		private const int EtRNanDUGbWvQTuEWUTNiZOxcbyr = 0;

		private const int WxpvNXdncMLnFhbbaiUHTWTiTStG = 1;

		private const int LAvZPQOWyrCTaYDAWHBxWvVDhMzk = 64;

		private const int ohkxDywkfeNpPpbCWHgTxukKxXwe = 48;

		private const int eJZrXKToUuwPlzwOlKdUeYXhwDAG = 547;

		private const int VkaZcAJvkAAitVuUgxxRWoGZCQGI = 64;

		private const int lUzbOmRBumRWqJeHtdITkjykkUeLA = 547;

		private const int cCzhWepMAEGuwIolRjUIcUzlwLQE = 1;

		private const int JDtlHkrwtVFbYmuRGBPMfeCTmAuo = 2;

		private const int UaTULYNqLensEoohWvefdPWkbpBS = 3;

		private const int CEcMKxaOewfYOuDuzFRUkYeaJJtSA = 4;

		private const int yJaCsOXUvcEhmKVfbkjmjAwYiuid = 5;

		private const int vohOsTKEoGInGavjqYEAicMpPOSG = 6;

		private const int zZJxxfbBaAXVVptYDSWkVUvPvfpB = 8;

		private const int lCMFsGKYpfeCGjKPFKfrSIucWlmac = 22;

		private const int NQzztSHIsUfDZMCZQZuShTBgluFo = 16;

		private const int StEKRNQinwFTqoeuiVYyBlNdSDb = 33;

		private const int bXYeBaqbvntyNakVcpddrVvJOFMH = 8;

		private const int AGMxClcjgtGhWnJszGpaNXJxelyL = 9;

		private const int ukjXHQWChnDkjgBHDYQktdwoxSDG = 10;

		private const int QqUJhQNqDlIXQguEUsVlEdVsVRFDA = 28;

		private const int WyIpPRBBQVlFZgDccaCogeBjbcziA = 54;

		private const int GzFfTghyKwMVhkqyZVdSffhSVcir = 55;

		private const int FPORjLDgZQnLwTZFNzRDgBdIEnWx = 54;

		private const bool kXnfokGCrYlbsSmWeFYtQOmBIHym = true;

		private const int ZNCVcDaisUpljNARmEjiQnDfBYlBA = 25;

		private const int zRogklBlXITXxViPplvffUxxNqbl = 3000000;

		private const float wfGFfsdmTPOmqNaWZqxRoQfutFigA = 8192f;

		private const float EvAYNIYgzQxSNzFoDywmqehTJbMI = 0.0010652969f;

		private const float MEwYrFDUdxcufoLLpZpWtaSBYvcP = 0.06103702f;

		private const bool JadkBprzLCmYVFcCCfkWxQKbslNr = true;

		private const bool pvQDdSQcJPjZCyewpXmiJGGXGUgp = true;

		private const bool VmVMKkwIevLTpmUnjqDhCajDlBOH = true;

		private const bool LrkNiGGLeNlbDhlOGWONmbuFvlGX = true;

		private const float rMtaajdRRhGmxJrUAYTmnmVpdzHbA = 4096f;

		private const float KBzTllBhxayoAHXViGiRhuKdhlPT = 16384f;

		private const float DBmFtjdKmgCmlqsQcxVccoqXKcGJA = 16777216f;

		private const float IVzkqFLbfIPVHBtkkfJAtcGtazsi = 268435460f;

		private const float aKVDGQAHiElgBGAqDOoalkpSnNxu = 0.01999998f;

		private const float joHJvZYGcCKlcMjCkoezLmcAdKiT = 8192f;

		private const float qYgsIajQmYbNHkSxzXDvriVHPYSJ = 0.98f;

		private const float rzVhwMOBQKxIgqqiDRCBJbEpaEgi = 45f;

		private const float GGxxIuehXunNkCtjDUkEqPNlGkaw = 20f;

		private readonly bool mfhHHZDeGKwAerjXMKtuAyMiebVJb;

		private readonly int tfCaAlUddOCMDpNLiBaLWiFcVKtX;

		private readonly int hCcVfuOGPHdJjPBqqCKxPAHphExEA;

		private readonly bool npyfciUyVoHSnUerAVKcaBFuVxMj;

		private readonly byte oQgeYSXpWLxenSKdxzrEfRgcSDGx;

		private readonly int mxWQqmVBOMYMouNHdLJimlpmMeAO;

		private readonly int AcoCFfFmwmUcDsuLncKsMhwWZTiSA;

		private readonly int aaVwjRixZYvhKujDvJHLcxrpSTTG;

		private readonly int cgCzoHlIMBBHIfRrsfEDjTaVztduA;

		private readonly int ddgDIoApNQBrntLTNMKZKFEtvrIWA;

		private readonly int DrypMkXBQnyVQrHDwwGKoGORaeE;

		private readonly NativeBuffer QRRGDLqbiaCGBhafJDtJkPxMcuSN;

		private readonly NativeBuffer ZFeOTfqkMHEFlOYAHOmVynLZegZx;

		private OutputReport QSlMBqvPWXLKoPeajJppRMZfOavF;

		private readonly Func<OutputReport, bool> myQDjUZwqprLMPhYIhkWexcvAGWR;

		private readonly Action<OutputReport> RTIYeSihwbcKqHTKBbLiGsTLCGSGA;

		private bool XWSrvgraqjZjnwaXbFfJreoctENR;

		private bool DJeJvyeEjtOMtQLTIDdovHtYlont;

		private double kSuNZIdJHWusABnzDJuUsPJtFzGFA;

		private byte WsLojkAlIPwEcbRVdaLaDQcNCuXq;

		private bool VcSRiqONnQYDbXpAhdYkRrSngQOIA;

		private bool KfPusglvxHcRlkRGwFEDzieIAkOA;

		private bool TjJEdjItgxEjFrjrhyAFSlviryyQ;

		private Quaternion rFwWMXOGIzsuslfMeQLEvhETLxPK;

		private DualSenseMicrophoneLightMode HzBlODqHtOTvZrPJHkHqcvOGtDNT;

		private veiIwkesPxzjuPZHaKXAyktzmTHv pqycJohCFJdOzTrfddADEJQdJrosB;

		private DualSensePlayerLightFlags yFdDbEPHekfGmglANtEQNCPHayTDA;

		private bool IHWWxwschlgnLFXzDDvdPxDayZqi;

		private bool JNQErGdkMNbkJCOmuogZQPxuWyBt;

		private uint GaaRwKzysJBhennqkUcGvPdNoemB;

		private float nOLrXwBsYzNWyDdmPXqIzzprpZdI;

		private double bNRTmnBuqvjCZLvAkckWhnjVlowJ;

		private float MjbTeEthmsyNKVVzvYWOwUvDganc;

		private byte wQRQrvASEDryHYitwkSPBKLtwNnv;

		private byte TpsZfwuAUnGGYEqJmevAVcvhsNnN;

		private Quaternion nGdbqCTUmosIHuHNtfLkkhrmQCWfA;

		private Quaternion mmXhVDOkVNgFEIxoDAZRppVqsnBmA;

		private bool oLUBNLrEosMHPzsGiTLZMeybWrUU;

		private int rkGKPiFhaWAWAfGtnEMYifPdgHYiB;

		private int[] tpmdIqhoXutjjjSHnUUKTLmlqsjb;

		private int[] SKHxoaRqwmPCTqJKKZVnXeAnNchS;

		private static uint[] nXsfXBFEsCXXRYMYHfdQEsRNGikdb;

		private const uint yiFZvsyGmYPeLYjNgBqdFJaAtrdY = 3940166985u;

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

		public DualSenseDriver(InitArgs P_0)
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

		private void SxJxxXaKnQbzArRgVwwkuUYcyrhI(sEFlMWgexWIvWAvMGQUwmUTmbxg P_0)
		{
		}

		private bool oRzeIEUwpKiibeptUGAIucAuHzdsA(sEFlMWgexWIvWAvMGQUwmUTmbxg P_0)
		{
			return false;
		}

		private void JYzhIOlRjERfDdfGmAdHjrjKUGnT()
		{
		}

		private void JYzhIOlRjERfDdfGmAdHjrjKUGnT(NativeBuffer P_0, int P_1)
		{
		}

		private bool qaREVHHsFJUMDlAslfcvwbycMXnBb(sEFlMWgexWIvWAvMGQUwmUTmbxg P_0)
		{
			return false;
		}

		private void NmpnNBiKKVbSAuwNMDZPPwvGzdji(NativeBuffer P_0, double P_1)
		{
		}

		private void jcpPocnebBUnOJmnVNaIDNqLQtUw(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
		{
		}

		private void FDCtdcngMXnUYsIgNbPUcTGWAxrc()
		{
		}

		private void OCXNuzdfFtEGYLKRASPNRtDyJAKO(NativeBuffer P_0)
		{
		}

		private void SOjkodDiSsmNONbbEOOySJZfbbCb()
		{
		}

		private static bool tJPtqMtKpxNAXuZpTAnSRgwIeJGh(ref Vector3 P_0)
		{
			return false;
		}

		private void VassZFIXhmBUDASgCDmLWLXPUdye(Vector3 P_0, Vector3 P_1)
		{
		}

		private static Quaternion ezRcqeiqCvjEhtCEyBUNcWxdPwVRA(Quaternion P_0, Vector3 P_1)
		{
			return default(Quaternion);
		}

		private static Vector3 QJJleWeAWawNdsTDyjzqzqZAJSPW(Vector3 P_0, Vector3 P_1)
		{
			return default(Vector3);
		}

		private Quaternion kIbnhoiKxxfouftnBFJhEtCcdJEbA(Quaternion P_0, oiItXErrFRuSQQeEaWuAonFMAjKw P_1)
		{
			return default(Quaternion);
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			return default(Quaternion);
		}

		private float SqoEhEhDjkfDybLSwbadachTnAzS(float P_0, float P_1)
		{
			return 0f;
		}

		private Vector3 ALKgCixRyXvfdNKhQFIlLCOGMCPi(Vector3 P_0, float P_1 = 0f)
		{
			return default(Vector3);
		}

		private Quaternion XWjjSJIVQrQWeDnnNwhSooDixVrl(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private Quaternion EtSwbfMpqAdUBeyJRxyBaeSkuGyO(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private float wRUlaPjFbpojlqdFIezxBJHEliieA(Vector3 P_0)
		{
			return 0f;
		}

		private bool fOhAxQPWMKyRNwvmDQHtMStAUNnU(float P_0)
		{
			return false;
		}

		private bool qKDCzOCzPkhVPmHscRJvoCaVKNBB(Vector3 P_0, out cGrIJDAfJCJTpYpXWzfUkcQlqnrW P_1)
		{
			P_1 = default(cGrIJDAfJCJTpYpXWzfUkcQlqnrW);
			return false;
		}

		private bool MEYNDUwCQALMQhsQLnBacwOYAXLN(Vector3 P_0)
		{
			return false;
		}

		private bool vWwqpDImetIuBROJUMmSbszhZNBC(Vector3 P_0)
		{
			return false;
		}

		private Vector3 IpXFAznEXalCgeYkZOntbRnYjSYk(float[] P_0)
		{
			return default(Vector3);
		}

		private Vector3 KIVspQiBxeIkiNKVomoqiLzWilWd(ExpandableArray_DataContainer<HIDGyroscope.uSZnGClQbqaFyycJkqLkPwPrhXGb> P_0)
		{
			return default(Vector3);
		}

		private Vector3 KIVspQiBxeIkiNKVomoqiLzWilWd(Vector3 P_0, float P_1)
		{
			return default(Vector3);
		}

		private int iOGiaoxGMIQdBbpisMuemuZFiyAl(int P_0)
		{
			return 0;
		}

		private void evuiVHSvdGdvxROIeKVZHgaUuwAH(byte[] P_0, float[] P_1)
		{
		}

		private void livoxOdSCmOuPRuAWVPWCCyapafj(byte[] P_0, float[] P_1)
		{
		}

		private float qKitYmlEFnJMOGMFzOnnVetyHTos()
		{
			return 0f;
		}

		private void jEqfWchuAgzzbZcMnYNRQlffpBfE(NativeBuffer P_0, HIDTouchpad.TouchData[] P_1)
		{
		}

		private int lRGQQnDApauJEFEOZZoNnMkPjXyA(int P_0, bool P_1, int P_2)
		{
			return 0;
		}

		private void gkPgSOhCVzcwKXxrfymguLkTrelRA()
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

		private static uint HLzIJhmKpDtNZkWrbnqhtodkakyt(NativeBuffer P_0, int P_1)
		{
			return 0u;
		}

		private static veiIwkesPxzjuPZHaKXAyktzmTHv wpzDhLbUwxmbuKcYVDfbYNRxLlWk(DualSenseOtherLightBrightness P_0)
		{
			return default(veiIwkesPxzjuPZHaKXAyktzmTHv);
		}

		private static DualSenseOtherLightBrightness jGpWjAqQHggyvHaMedhuiPcaKOILA(veiIwkesPxzjuPZHaKXAyktzmTHv P_0)
		{
			return default(DualSenseOtherLightBrightness);
		}
	}
}
