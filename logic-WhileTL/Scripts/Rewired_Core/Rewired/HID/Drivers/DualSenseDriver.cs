using System;
using Rewired.ControllerExtensions;
using Rewired.Drivers.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
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

		private Quaternion rFwWMXOGIzsuslfMeQLEvhETLxPK = Quaternion.identity;

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

		private Quaternion nGdbqCTUmosIHuHNtfLkkhrmQCWfA = Quaternion.identity;

		private Quaternion mmXhVDOkVNgFEIxoDAZRppVqsnBmA = Quaternion.identity;

		private bool oLUBNLrEosMHPzsGiTLZMeybWrUU;

		private int rkGKPiFhaWAWAfGtnEMYifPdgHYiB;

		private int[] tpmdIqhoXutjjjSHnUUKTLmlqsjb = new int[2];

		private int[] SKHxoaRqwmPCTqJKKZVnXeAnNchS = new int[2];

		private static uint[] nXsfXBFEsCXXRYMYHfdQEsRNGikdb = new uint[256]
		{
			3523407757u, 2768625435u, 1007455905u, 1259060791u, 3580832660u, 2724731650u, 996231864u, 1281784366u, 3705235391u, 2883475241u,
			852952723u, 1171273221u, 3686048678u, 2897449776u, 901431946u, 1119744540u, 3484811241u, 3098726271u, 565944005u, 1455205971u,
			3369614320u, 3219065702u, 651582172u, 1372678730u, 3245242331u, 3060352845u, 794826487u, 1483155041u, 3322131394u, 2969862996u,
			671994606u, 1594548856u, 3916222277u, 2657877971u, 123907689u, 1885708031u, 3993045852u, 2567322570u, 1010288u, 1997036262u,
			3887548279u, 2427484129u, 163128923u, 2126386893u, 3772416878u, 2547889144u, 248832578u, 2043925204u, 4108050209u, 2212294583u,
			450215437u, 1842515611u, 4088798008u, 2226203566u, 498629140u, 1790921346u, 4194326291u, 2366072709u, 336475711u, 1661535913u,
			4251816714u, 2322244508u, 325317158u, 1684325040u, 2766056989u, 3554254475u, 1255198513u, 1037565863u, 2746444292u, 3568589458u,
			1304234792u, 985283518u, 2852464175u, 3707901625u, 1141589763u, 856455061u, 2909332022u, 3664761504u, 1130791706u, 878818188u,
			3110715001u, 3463352047u, 1466425173u, 543223747u, 3187964512u, 3372436214u, 1342839628u, 655174618u, 3081909835u, 3233089245u,
			1505515367u, 784033777u, 2967466578u, 3352871620u, 1590793086u, 701932520u, 2679148245u, 3904355907u, 1908338681u, 112844655u,
			2564639436u, 4024072794u, 1993550816u, 30677878u, 2439710439u, 3865851505u, 2137352139u, 140662621u, 2517025534u, 3775001192u,
			2013832146u, 252678980u, 2181537457u, 4110462503u, 1812594589u, 453955339u, 2238339752u, 4067256894u, 1801730948u, 476252946u,
			2363233923u, 4225443349u, 1657960367u, 366298937u, 2343686810u, 4239843852u, 1707062198u, 314082080u, 1069182125u, 1220369467u,
			3518238081u, 2796764439u, 953657524u, 1339070498u, 3604597144u, 2715744526u, 828499103u, 1181144073u, 3748627891u, 2825434405u,
			906764422u, 1091244048u, 3624026538u, 2936369468u, 571309257u, 1426738271u, 3422756325u, 3137613171u, 627095760u, 1382516806u,
			3413039612u, 3161057642u, 752284923u, 1540473965u, 3268974039u, 3051332929u, 733688034u, 1555824756u, 3316994510u, 2998034776u,
			81022053u, 1943239923u, 3940166985u, 2648514015u, 62490748u, 1958656234u, 3988253008u, 2595281350u, 168805463u, 2097738945u,
			3825313147u, 2466682349u, 224526414u, 2053451992u, 3815530850u, 2490061300u, 425942017u, 1852075159u, 4151131437u, 2154433979u,
			504272920u, 1762240654u, 4026595636u, 2265434530u, 397988915u, 1623188645u, 4189500703u, 2393998729u, 282398762u, 1741824188u,
			4275794182u, 2312913296u, 1231433021u, 1046551979u, 2808630289u, 3496967303u, 1309403428u, 957143474u, 2684717064u, 3607279774u,
			1203610895u, 817534361u, 2847130659u, 3736401077u, 1087398166u, 936857984u, 2933784634u, 3654889644u, 1422998873u, 601230799u,
			3135200373u, 3453512931u, 1404893504u, 616286678u, 3182598252u, 3400902906u, 1510651243u, 755860989u, 3020215367u, 3271812305u,
			1567060338u, 710951396u, 3010007134u, 3295551688u, 1913130485u, 84884835u, 2617666777u, 3942734927u, 1969605100u, 40040826u,
			2607524032u, 3966539862u, 2094237127u, 198489425u, 2464015595u, 3856323709u, 2076066270u, 213479752u, 2511347954u, 3803648100u,
			1874795921u, 414723335u, 2175892669u, 4139142187u, 1758648712u, 534112542u, 2262612132u, 4057696306u, 1633981859u, 375629109u,
			2406151311u, 4167943193u, 1711886778u, 286155052u, 2282172566u, 4278190080u
		};

		private const uint yiFZvsyGmYPeLYjNgBqdFJaAtrdY = 3940166985u;

		private bool isVibrating
		{
			get
			{
				for (int i = 0; i < base.VibrationMotorCount; i++)
				{
					if (vibrationMotors[i].SpeedRaw > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		public float BatteryLevel
		{
			get
			{
				float num = 0f;
				num = ((!mfhHHZDeGKwAerjXMKtuAyMiebVJb) ? ((float)(WsLojkAlIPwEcbRVdaLaDQcNCuXq - 1) * 10f) : ((float)(WsLojkAlIPwEcbRVdaLaDQcNCuXq + 2) * 10f));
				return MathTools.Clamp(num, 0f, 100f);
			}
		}

		public bool BatteryCharging => VcSRiqONnQYDbXpAhdYkRrSngQOIA;

		public float LeftMotor
		{
			get
			{
				return vibrationMotors[0].Speed;
			}
			set
			{
				vibrationMotors[0].Speed = value;
			}
		}

		public float RightMotor
		{
			get
			{
				return vibrationMotors[1].Speed;
			}
			set
			{
				vibrationMotors[1].Speed = value;
			}
		}

		public float LightColorR
		{
			get
			{
				return lights[0].ColorR;
			}
			set
			{
				lights[0].ColorR = value;
			}
		}

		public float LightColorG
		{
			get
			{
				return lights[0].ColorG;
			}
			set
			{
				lights[0].ColorG = value;
			}
		}

		public float LightColorB
		{
			get
			{
				return lights[0].ColorB;
			}
			set
			{
				lights[0].ColorB = value;
			}
		}

		public float LightFlashOnDuration
		{
			get
			{
				return (int)wQRQrvASEDryHYitwkSPBKLtwNnv;
			}
			set
			{
				wQRQrvASEDryHYitwkSPBKLtwNnv = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				XWSrvgraqjZjnwaXbFfJreoctENR = true;
				if (wQRQrvASEDryHYitwkSPBKLtwNnv == 0 && TpsZfwuAUnGGYEqJmevAVcvhsNnN == 0)
				{
					DJeJvyeEjtOMtQLTIDdovHtYlont = true;
				}
			}
		}

		public float LightFlashOffDuration
		{
			get
			{
				return (int)TpsZfwuAUnGGYEqJmevAVcvhsNnN;
			}
			set
			{
				TpsZfwuAUnGGYEqJmevAVcvhsNnN = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				XWSrvgraqjZjnwaXbFfJreoctENR = true;
				if (wQRQrvASEDryHYitwkSPBKLtwNnv == 0 && TpsZfwuAUnGGYEqJmevAVcvhsNnN == 0)
				{
					DJeJvyeEjtOMtQLTIDdovHtYlont = true;
				}
			}
		}

		public DualSenseMicrophoneLightMode microphoneLightMode
		{
			get
			{
				return HzBlODqHtOTvZrPJHkHqcvOGtDNT;
			}
			set
			{
				HzBlODqHtOTvZrPJHkHqcvOGtDNT = value;
				XWSrvgraqjZjnwaXbFfJreoctENR = true;
			}
		}

		public DualSenseOtherLightBrightness otherLightBrightness
		{
			get
			{
				return jGpWjAqQHggyvHaMedhuiPcaKOILA(pqycJohCFJdOzTrfddADEJQdJrosB);
			}
			set
			{
				pqycJohCFJdOzTrfddADEJQdJrosB = wpzDhLbUwxmbuKcYVDfbYNRxLlWk(value);
				XWSrvgraqjZjnwaXbFfJreoctENR = true;
			}
		}

		public DualSensePlayerLightFlags playerLights
		{
			get
			{
				return yFdDbEPHekfGmglANtEQNCPHayTDA;
			}
			set
			{
				yFdDbEPHekfGmglANtEQNCPHayTDA = value;
				XWSrvgraqjZjnwaXbFfJreoctENR = true;
			}
		}

		public Vector3 AccelerometerValue => IpXFAznEXalCgeYkZOntbRnYjSYk(accelerometers[0].rawValue);

		public Vector3 AccelerometerValueRaw => new Vector3(accelerometers[0].rawValue[0], accelerometers[0].rawValue[1], accelerometers[0].rawValue[2]);

		public Vector3 GyroscopeValue => KIVspQiBxeIkiNKVomoqiLzWilWd(gyroscopes[0].events);

		public Vector3 GyroscopeValueRaw => new Vector3(gyroscopes[0].rawValue[0], gyroscopes[0].rawValue[1], gyroscopes[0].rawValue[2]);

		public Vector3 LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);
				return KIVspQiBxeIkiNKVomoqiLzWilWd(vector, nOLrXwBsYzNWyDdmPXqIzzprpZdI);
			}
		}

		public Vector3 LastGyroscopeValueRaw => new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);

		public Quaternion Orientation => rFwWMXOGIzsuslfMeQLEvhETLxPK;

		public int MaxTouches => 2;

		public void ResetOrientation()
		{
			rFwWMXOGIzsuslfMeQLEvhETLxPK = Quaternion.identity;
			oLUBNLrEosMHPzsGiTLZMeybWrUU = false;
		}

		public int GetTouchCount()
		{
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				if (touchpads[0].values[i].isTouching)
				{
					num++;
				}
			}
			return num;
		}

		public bool IsTouchingAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return false;
			}
			return touchpads[0].values[index].isTouching;
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return touchpads[0].IsTouching(touchId);
		}

		public int GetTouchIdAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return -1;
			}
			return touchpads[0].values[index].touchId;
		}

		public bool GetTouchPositionByIndex(int index, out Vector2 position)
		{
			position = default(Vector2);
			if (index < 0 || index >= 2)
			{
				return false;
			}
			HIDTouchpad.TouchData[] values = touchpads[0].values;
			if (!values[index].isTouching)
			{
				return false;
			}
			position.x = values[index].positionX;
			position.y = values[index].positionY;
			return true;
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			position = default(Vector2);
			if (!touchpads[0].IsTouching(touchId))
			{
				return false;
			}
			HIDTouchpad.TouchData[] values = touchpads[0].values;
			for (int i = 0; i < values.Length; i++)
			{
				if (values[i].isTouching)
				{
					position.x = values[i].positionX;
					position.y = values[i].positionY;
				}
			}
			return true;
		}

		public bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (index < 0 || index >= 2)
			{
				return false;
			}
			HIDTouchpad.TouchData[] values = touchpads[0].values;
			if (!values[index].isTouching)
			{
				return false;
			}
			positionX = values[index].positionAbsX;
			positionY = values[index].positionAbsY;
			return true;
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (!touchpads[0].IsTouching(touchId))
			{
				return false;
			}
			HIDTouchpad.TouchData[] values = touchpads[0].values;
			for (int i = 0; i < values.Length; i++)
			{
				if (values[i].isTouching)
				{
					positionX = values[i].positionAbsX;
					positionY = values[i].positionAbsY;
				}
			}
			return true;
		}

		public void StopLightFlash()
		{
			wQRQrvASEDryHYitwkSPBKLtwNnv = 0;
			TpsZfwuAUnGGYEqJmevAVcvhsNnN = 0;
			XWSrvgraqjZjnwaXbFfJreoctENR = true;
			DJeJvyeEjtOMtQLTIDdovHtYlont = true;
		}

		public void StopVibration()
		{
			int vibrationMotorCount = base.VibrationMotorCount;
			for (int i = 0; i < vibrationMotorCount; i++)
			{
				vibrationMotors[i].SpeedRaw = 0;
			}
		}

		public DualSenseDriver(InitArgs P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			tfCaAlUddOCMDpNLiBaLWiFcVKtX = P_0.hatZeroValue;
			hCcVfuOGPHdJjPBqqCKxPAHphExEA = P_0.hatSpan;
			mxWQqmVBOMYMouNHdLJimlpmMeAO = P_0.inputReportLength;
			AcoCFfFmwmUcDsuLncKsMhwWZTiSA = P_0.outputReportLength;
			myQDjUZwqprLMPhYIhkWexcvAGWR = P_0.synchronousWriteOutputReportDelegate;
			RTIYeSihwbcKqHTKBbLiGsTLCGSGA = P_0.asynchronousWriteOutputReportDelegate;
			mfhHHZDeGKwAerjXMKtuAyMiebVJb = P_0.connectionType == DeviceConnectionType.Bluetooth;
			if (mfhHHZDeGKwAerjXMKtuAyMiebVJb)
			{
				AcoCFfFmwmUcDsuLncKsMhwWZTiSA = 547;
			}
			else
			{
				AcoCFfFmwmUcDsuLncKsMhwWZTiSA = 48;
			}
			QRRGDLqbiaCGBhafJDtJkPxMcuSN = new NativeBuffer(64);
			ZFeOTfqkMHEFlOYAHOmVynLZegZx = new NativeBuffer(AcoCFfFmwmUcDsuLncKsMhwWZTiSA);
			QSlMBqvPWXLKoPeajJppRMZfOavF = new OutputReport(ZFeOTfqkMHEFlOYAHOmVynLZegZx.Pointer, ZFeOTfqkMHEFlOYAHOmVynLZegZx.Length, AcoCFfFmwmUcDsuLncKsMhwWZTiSA);
			lights = new HIDLight[1]
			{
				new HIDLight(11, 24, 28)
			};
			lights[0].ValueChangedEvent += gkPgSOhCVzcwKXxrfymguLkTrelRA;
			vibrationMotors = new HIDVibrationMotor[2]
			{
				new HIDVibrationMotor(0, 255),
				new HIDVibrationMotor(0, 255)
			};
			vibrationMotors[0].ValueChangedEvent += gkPgSOhCVzcwKXxrfymguLkTrelRA;
			vibrationMotors[1].ValueChangedEvent += gkPgSOhCVzcwKXxrfymguLkTrelRA;
			if (mfhHHZDeGKwAerjXMKtuAyMiebVJb)
			{
				byte[] array = P_0.getFeatureReportDelegate(5);
				npyfciUyVoHSnUerAVKcaBFuVxMj = array != null && array.Length != 0;
				if (npyfciUyVoHSnUerAVKcaBFuVxMj)
				{
					oRzeIEUwpKiibeptUGAIucAuHzdsA(sEFlMWgexWIvWAvMGQUwmUTmbxg.Synchronous);
				}
			}
			else
			{
				npyfciUyVoHSnUerAVKcaBFuVxMj = true;
				npyfciUyVoHSnUerAVKcaBFuVxMj = oRzeIEUwpKiibeptUGAIucAuHzdsA(sEFlMWgexWIvWAvMGQUwmUTmbxg.Synchronous);
			}
			if (!npyfciUyVoHSnUerAVKcaBFuVxMj)
			{
				throw new Exception("Special features not supported so just treat this as a standard HID device.");
			}
			oQgeYSXpWLxenSKdxzrEfRgcSDGx = 1;
			aaVwjRixZYvhKujDvJHLcxrpSTTG = 0;
			if (mfhHHZDeGKwAerjXMKtuAyMiebVJb && npyfciUyVoHSnUerAVKcaBFuVxMj)
			{
				oQgeYSXpWLxenSKdxzrEfRgcSDGx = 49;
				aaVwjRixZYvhKujDvJHLcxrpSTTG = 1;
			}
			cgCzoHlIMBBHIfRrsfEDjTaVztduA = 8 + aaVwjRixZYvhKujDvJHLcxrpSTTG;
			ddgDIoApNQBrntLTNMKZKFEtvrIWA = 9 + aaVwjRixZYvhKujDvJHLcxrpSTTG;
			DrypMkXBQnyVQrHDwwGKoGORaeE = 10 + aaVwjRixZYvhKujDvJHLcxrpSTTG;
			buttons = new HIDButton[15];
			for (int i = 0; i < 15; i++)
			{
				buttons[i] = new HIDButton(oQgeYSXpWLxenSKdxzrEfRgcSDGx, new HIDControllerElement.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new HIDAxis[6]
			{
				new HIDAxis(oQgeYSXpWLxenSKdxzrEfRgcSDGx, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + aaVwjRixZYvhKujDvJHLcxrpSTTG,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(oQgeYSXpWLxenSKdxzrEfRgcSDGx, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + aaVwjRixZYvhKujDvJHLcxrpSTTG,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(oQgeYSXpWLxenSKdxzrEfRgcSDGx, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + aaVwjRixZYvhKujDvJHLcxrpSTTG,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(oQgeYSXpWLxenSKdxzrEfRgcSDGx, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + aaVwjRixZYvhKujDvJHLcxrpSTTG,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(oQgeYSXpWLxenSKdxzrEfRgcSDGx, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 5 + aaVwjRixZYvhKujDvJHLcxrpSTTG,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new HIDAxis(oQgeYSXpWLxenSKdxzrEfRgcSDGx, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 6 + aaVwjRixZYvhKujDvJHLcxrpSTTG,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0)
			};
			hats = new HIDHat[1]
			{
				new HIDHat(oQgeYSXpWLxenSKdxzrEfRgcSDGx, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 8 + aaVwjRixZYvhKujDvJHLcxrpSTTG,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, iOGiaoxGMIQdBbpisMuemuZFiyAl)
			};
			accelerometers = new HIDAccelerometer[1]
			{
				new HIDAccelerometer(oQgeYSXpWLxenSKdxzrEfRgcSDGx, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 22 + aaVwjRixZYvhKujDvJHLcxrpSTTG,
					bitSize = 48
				}, 3, evuiVHSvdGdvxROIeKVZHgaUuwAH)
			};
			gyroscopes = new HIDGyroscope[1]
			{
				new HIDGyroscope(P_0.updateLoopSetting, oQgeYSXpWLxenSKdxzrEfRgcSDGx, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 16 + aaVwjRixZYvhKujDvJHLcxrpSTTG,
					bitSize = 48
				}, 3, 25, livoxOdSCmOuPRuAWVPWCCyapafj, qKitYmlEFnJMOGMFzOnnVetyHTos)
			};
			touchpads = new HIDTouchpad[1]
			{
				new HIDTouchpad(oQgeYSXpWLxenSKdxzrEfRgcSDGx, new HIDTouchpad.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 33 + aaVwjRixZYvhKujDvJHLcxrpSTTG,
					bitSize = 48
				}, jEqfWchuAgzzbZcMnYNRQlffpBfE)
			};
			bNRTmnBuqvjCZLvAkckWhnjVlowJ = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			FDCtdcngMXnUYsIgNbPUcTGWAxrc();
			SxJxxXaKnQbzArRgVwwkuUYcyrhI(sEFlMWgexWIvWAvMGQUwmUTmbxg.Asynchronous);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < QRRGDLqbiaCGBhafJDtJkPxMcuSN.Length)
			{
				return false;
			}
			MjbTeEthmsyNKVVzvYWOwUvDganc = (float)(timestamp - bNRTmnBuqvjCZLvAkckWhnjVlowJ);
			bNRTmnBuqvjCZLvAkckWhnjVlowJ = timestamp;
			QRRGDLqbiaCGBhafJDtJkPxMcuSN.Write(inputReportPtr, inputReportLength, QRRGDLqbiaCGBhafJDtJkPxMcuSN.Length);
			OCXNuzdfFtEGYLKRASPNRtDyJAKO(QRRGDLqbiaCGBhafJDtJkPxMcuSN);
			NmpnNBiKKVbSAuwNMDZPPwvGzdji(QRRGDLqbiaCGBhafJDtJkPxMcuSN, timestamp);
			HIDControllerElement[] array = axes;
			jcpPocnebBUnOJmnVNaIDNqLQtUw(array, QRRGDLqbiaCGBhafJDtJkPxMcuSN, timestamp);
			array = hats;
			jcpPocnebBUnOJmnVNaIDNqLQtUw(array, QRRGDLqbiaCGBhafJDtJkPxMcuSN, timestamp);
			array = accelerometers;
			jcpPocnebBUnOJmnVNaIDNqLQtUw(array, QRRGDLqbiaCGBhafJDtJkPxMcuSN, timestamp);
			array = gyroscopes;
			jcpPocnebBUnOJmnVNaIDNqLQtUw(array, QRRGDLqbiaCGBhafJDtJkPxMcuSN, timestamp);
			array = touchpads;
			jcpPocnebBUnOJmnVNaIDNqLQtUw(array, QRRGDLqbiaCGBhafJDtJkPxMcuSN, timestamp);
			VcSRiqONnQYDbXpAhdYkRrSngQOIA = (QRRGDLqbiaCGBhafJDtJkPxMcuSN[54 + aaVwjRixZYvhKujDvJHLcxrpSTTG] & 8) != 0;
			KfPusglvxHcRlkRGwFEDzieIAkOA = (QRRGDLqbiaCGBhafJDtJkPxMcuSN[55 + aaVwjRixZYvhKujDvJHLcxrpSTTG] & 0x20) != 0;
			WsLojkAlIPwEcbRVdaLaDQcNCuXq = (byte)(QRRGDLqbiaCGBhafJDtJkPxMcuSN[55 + aaVwjRixZYvhKujDvJHLcxrpSTTG] & 0xF);
			TjJEdjItgxEjFrjrhyAFSlviryyQ = (QRRGDLqbiaCGBhafJDtJkPxMcuSN[54 + aaVwjRixZYvhKujDvJHLcxrpSTTG] & 1) != 0;
			SOjkodDiSsmNONbbEOOySJZfbbCb();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualSenseExtension(this);
		}

		private void SxJxxXaKnQbzArRgVwwkuUYcyrhI(sEFlMWgexWIvWAvMGQUwmUTmbxg P_0)
		{
			if (XWSrvgraqjZjnwaXbFfJreoctENR)
			{
				oRzeIEUwpKiibeptUGAIucAuHzdsA(P_0);
				XWSrvgraqjZjnwaXbFfJreoctENR = false;
			}
		}

		private bool oRzeIEUwpKiibeptUGAIucAuHzdsA(sEFlMWgexWIvWAvMGQUwmUTmbxg P_0)
		{
			JYzhIOlRjERfDdfGmAdHjrjKUGnT();
			bool result = qaREVHHsFJUMDlAslfcvwbycMXnBb(P_0);
			if (DJeJvyeEjtOMtQLTIDdovHtYlont)
			{
				result = qaREVHHsFJUMDlAslfcvwbycMXnBb(P_0);
				DJeJvyeEjtOMtQLTIDdovHtYlont = false;
			}
			return result;
		}

		private void JYzhIOlRjERfDdfGmAdHjrjKUGnT()
		{
			if (mfhHHZDeGKwAerjXMKtuAyMiebVJb && npyfciUyVoHSnUerAVKcaBFuVxMj)
			{
				ZFeOTfqkMHEFlOYAHOmVynLZegZx[0] = 49;
				ZFeOTfqkMHEFlOYAHOmVynLZegZx[1] = 2;
				JYzhIOlRjERfDdfGmAdHjrjKUGnT(ZFeOTfqkMHEFlOYAHOmVynLZegZx, 2);
				uint num = HLzIJhmKpDtNZkWrbnqhtodkakyt(ZFeOTfqkMHEFlOYAHOmVynLZegZx, 74);
				ZFeOTfqkMHEFlOYAHOmVynLZegZx[74] = (byte)(num & 0xFF);
				ZFeOTfqkMHEFlOYAHOmVynLZegZx[75] = (byte)((num & 0xFF00) >> 8);
				ZFeOTfqkMHEFlOYAHOmVynLZegZx[76] = (byte)((num & 0xFF0000) >> 16);
				ZFeOTfqkMHEFlOYAHOmVynLZegZx[77] = (byte)((num & 0xFF000000u) >> 24);
			}
			else
			{
				ZFeOTfqkMHEFlOYAHOmVynLZegZx[0] = 2;
				JYzhIOlRjERfDdfGmAdHjrjKUGnT(ZFeOTfqkMHEFlOYAHOmVynLZegZx, 1);
			}
		}

		private void JYzhIOlRjERfDdfGmAdHjrjKUGnT(NativeBuffer P_0, int P_1)
		{
			P_0[P_1] = byte.MaxValue;
			P_0[1 + P_1] = 247;
			P_0[2 + P_1] = (byte)vibrationMotors[1].SpeedRaw;
			P_0[3 + P_1] = (byte)vibrationMotors[0].SpeedRaw;
			P_0[8 + P_1] = (byte)HzBlODqHtOTvZrPJHkHqcvOGtDNT;
			P_0[43 + P_1] = (byte)yFdDbEPHekfGmglANtEQNCPHayTDA;
			if (IHWWxwschlgnLFXzDDvdPxDayZqi)
			{
				P_0[43 + P_1] = (byte)(P_0[43 + P_1] & -33);
			}
			else
			{
				P_0[43 + P_1] |= 32;
			}
			P_0[38 + P_1] = 3;
			P_0[41 + P_1] = (byte)(JNQErGdkMNbkJCOmuogZQPxuWyBt ? 1 : 2);
			P_0[42 + P_1] = (byte)pqycJohCFJdOzTrfddADEJQdJrosB;
			P_0[44 + P_1] = lights[0].ColorRRaw;
			P_0[45 + P_1] = lights[0].ColorGRaw;
			P_0[46 + P_1] = lights[0].ColorBRaw;
		}

		private bool qaREVHHsFJUMDlAslfcvwbycMXnBb(sEFlMWgexWIvWAvMGQUwmUTmbxg P_0)
		{
			kSuNZIdJHWusABnzDJuUsPJtFzGFA = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case sEFlMWgexWIvWAvMGQUwmUTmbxg.Synchronous:
				if (myQDjUZwqprLMPhYIhkWexcvAGWR == null)
				{
					return false;
				}
				return myQDjUZwqprLMPhYIhkWexcvAGWR(QSlMBqvPWXLKoPeajJppRMZfOavF);
			case sEFlMWgexWIvWAvMGQUwmUTmbxg.Asynchronous:
				if (RTIYeSihwbcKqHTKBbLiGsTLCGSGA == null)
				{
					return false;
				}
				RTIYeSihwbcKqHTKBbLiGsTLCGSGA(QSlMBqvPWXLKoPeajJppRMZfOavF);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void NmpnNBiKKVbSAuwNMDZPPwvGzdji(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[cgCzoHlIMBBHIfRrsfEDjTaVztduA];
			buttons[0].SetValue((b & 0x10) != 0, P_1);
			buttons[1].SetValue((b & 0x20) != 0, P_1);
			buttons[2].SetValue((b & 0x40) != 0, P_1);
			buttons[3].SetValue((b & 0x80) != 0, P_1);
			b = P_0[ddgDIoApNQBrntLTNMKZKFEtvrIWA];
			buttons[4].SetValue((b & 1) != 0, P_1);
			buttons[5].SetValue((b & 2) != 0, P_1);
			buttons[6].SetValue((b & 4) != 0, P_1);
			buttons[7].SetValue((b & 8) != 0, P_1);
			buttons[8].SetValue((b & 0x10) != 0, P_1);
			buttons[9].SetValue((b & 0x20) != 0, P_1);
			buttons[10].SetValue((b & 0x40) != 0, P_1);
			buttons[11].SetValue((b & 0x80) != 0, P_1);
			b = P_0[DrypMkXBQnyVQrHDwwGKoGORaeE];
			buttons[12].SetValue((b & 1) != 0, P_1);
			buttons[13].SetValue((b & 2) != 0, P_1);
			if (npyfciUyVoHSnUerAVKcaBFuVxMj)
			{
				buttons[14].SetValue((b & 4) != 0, P_1);
			}
		}

		private void jcpPocnebBUnOJmnVNaIDNqLQtUw(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].UpdateValue(P_1, P_2);
			}
		}

		private void FDCtdcngMXnUYsIgNbPUcTGWAxrc()
		{
			if (isVibrating && ReInput.realTime >= kSuNZIdJHWusABnzDJuUsPJtFzGFA)
			{
				XWSrvgraqjZjnwaXbFfJreoctENR = true;
			}
		}

		private void OCXNuzdfFtEGYLKRASPNRtDyJAKO(NativeBuffer P_0)
		{
			if (npyfciUyVoHSnUerAVKcaBFuVxMj)
			{
				uint num = QRRGDLqbiaCGBhafJDtJkPxMcuSN.ReadUInt(28 + aaVwjRixZYvhKujDvJHLcxrpSTTG);
				float num3;
				if (num != GaaRwKzysJBhennqkUcGvPdNoemB)
				{
					uint num2 = (uint)((num >= GaaRwKzysJBhennqkUcGvPdNoemB) ? (num - GaaRwKzysJBhennqkUcGvPdNoemB) : ((long)num + 4294967295L - GaaRwKzysJBhennqkUcGvPdNoemB));
					num3 = (float)num2 / 3000000f;
				}
				else
				{
					uint num2 = 0u;
					num3 = 0f;
				}
				GaaRwKzysJBhennqkUcGvPdNoemB = num;
				nOLrXwBsYzNWyDdmPXqIzzprpZdI = num3;
			}
		}

		private void SOjkodDiSsmNONbbEOOySJZfbbCb()
		{
			if (npyfciUyVoHSnUerAVKcaBFuVxMj && !(nOLrXwBsYzNWyDdmPXqIzzprpZdI <= 0f))
			{
				Vector3 vector = KIVspQiBxeIkiNKVomoqiLzWilWd(new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]), nOLrXwBsYzNWyDdmPXqIzzprpZdI);
				tJPtqMtKpxNAXuZpTAnSRgwIeJGh(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].rawValue[0] * -1f, accelerometers[0].rawValue[1] * -1f, accelerometers[0].rawValue[2] * -1f);
				VassZFIXhmBUDASgCDmLWLXPUdye(vector2, vector);
			}
		}

		private static bool tJPtqMtKpxNAXuZpTAnSRgwIeJGh(ref Vector3 P_0)
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

		private void VassZFIXhmBUDASgCDmLWLXPUdye(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && qKDCzOCzPkhVPmHscRJvoCaVKNBB(P_0, out var cGrIJDAfJCJTpYpXWzfUkcQlqnrW2))
			{
				Quaternion a = rFwWMXOGIzsuslfMeQLEvhETLxPK * quaternion;
				if (!oLUBNLrEosMHPzsGiTLZMeybWrUU)
				{
					oLUBNLrEosMHPzsGiTLZMeybWrUU = true;
					nGdbqCTUmosIHuHNtfLkkhrmQCWfA = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					mmXhVDOkVNgFEIxoDAZRppVqsnBmA = rFwWMXOGIzsuslfMeQLEvhETLxPK;
				}
				nGdbqCTUmosIHuHNtfLkkhrmQCWfA *= quaternion;
				mmXhVDOkVNgFEIxoDAZRppVqsnBmA *= quaternion;
				Quaternion b;
				if ((cGrIJDAfJCJTpYpXWzfUkcQlqnrW2 & cGrIJDAfJCJTpYpXWzfUkcQlqnrW.XZ) != cGrIJDAfJCJTpYpXWzfUkcQlqnrW.None)
				{
					b = XWjjSJIVQrQWeDnnNwhSooDixVrl(P_0, a.eulerAngles.y);
				}
				else if ((cGrIJDAfJCJTpYpXWzfUkcQlqnrW2 & cGrIJDAfJCJTpYpXWzfUkcQlqnrW.Y) != cGrIJDAfJCJTpYpXWzfUkcQlqnrW.None)
				{
					b = EtSwbfMpqAdUBeyJRxyBaeSkuGyO(P_0);
					Vector3 vector = mmXhVDOkVNgFEIxoDAZRppVqsnBmA * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				rFwWMXOGIzsuslfMeQLEvhETLxPK = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				rFwWMXOGIzsuslfMeQLEvhETLxPK *= quaternion;
				if (oLUBNLrEosMHPzsGiTLZMeybWrUU)
				{
					oLUBNLrEosMHPzsGiTLZMeybWrUU = false;
				}
			}
		}

		private static Quaternion ezRcqeiqCvjEhtCEyBUNcWxdPwVRA(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = QJJleWeAWawNdsTDyjzqzqZAJSPW(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 QJJleWeAWawNdsTDyjzqzqZAJSPW(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion kIbnhoiKxxfouftnBFJhEtCcdJEbA(Quaternion P_0, oiItXErrFRuSQQeEaWuAonFMAjKw P_1)
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

		private float SqoEhEhDjkfDybLSwbadachTnAzS(float P_0, float P_1)
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

		private Vector3 ALKgCixRyXvfdNKhQFIlLCOGMCPi(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion XWjjSJIVQrQWeDnnNwhSooDixVrl(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion EtSwbfMpqAdUBeyJRxyBaeSkuGyO(Vector3 P_0, float P_1 = 0f)
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

		private float wRUlaPjFbpojlqdFIezxBJHEliieA(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool fOhAxQPWMKyRNwvmDQHtMStAUNnU(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool qKDCzOCzPkhVPmHscRJvoCaVKNBB(Vector3 P_0, out cGrIJDAfJCJTpYpXWzfUkcQlqnrW P_1)
		{
			P_0.Normalize();
			P_1 = cGrIJDAfJCJTpYpXWzfUkcQlqnrW.None;
			bool result = false;
			if (MEYNDUwCQALMQhsQLnBacwOYAXLN(P_0))
			{
				result = true;
				P_1 |= cGrIJDAfJCJTpYpXWzfUkcQlqnrW.XZ;
			}
			if (vWwqpDImetIuBROJUMmSbszhZNBC(P_0))
			{
				result = true;
				P_1 |= cGrIJDAfJCJTpYpXWzfUkcQlqnrW.Y;
			}
			return result;
		}

		private bool MEYNDUwCQALMQhsQLnBacwOYAXLN(Vector3 P_0)
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

		private bool vWwqpDImetIuBROJUMmSbszhZNBC(Vector3 P_0)
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

		private Vector3 IpXFAznEXalCgeYkZOntbRnYjSYk(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 KIVspQiBxeIkiNKVomoqiLzWilWd(ExpandableArray_DataContainer<HIDGyroscope.uSZnGClQbqaFyycJkqLkPwPrhXGb> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				HIDGyroscope.uSZnGClQbqaFyycJkqLkPwPrhXGb uSZnGClQbqaFyycJkqLkPwPrhXGb = P_0[i];
				result += KIVspQiBxeIkiNKVomoqiLzWilWd(uSZnGClQbqaFyycJkqLkPwPrhXGb.KwkGJdCTWMjNlfHXodMLTqnUYWrpA, uSZnGClQbqaFyycJkqLkPwPrhXGb.tozEffDuwdrDSuxnWfJRrdFygaEGA);
			}
			return result;
		}

		private Vector3 KIVspQiBxeIkiNKVomoqiLzWilWd(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int iOGiaoxGMIQdBbpisMuemuZFiyAl(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void evuiVHSvdGdvxROIeKVZHgaUuwAH(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void livoxOdSCmOuPRuAWVPWCCyapafj(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float qKitYmlEFnJMOGMFzOnnVetyHTos()
		{
			return nOLrXwBsYzNWyDdmPXqIzzprpZdI;
		}

		private void jEqfWchuAgzzbZcMnYNRQlffpBfE(NativeBuffer P_0, HIDTouchpad.TouchData[] P_1)
		{
			int num = 33 + aaVwjRixZYvhKujDvJHLcxrpSTTG;
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
			P_1[0].touchId = lRGQQnDApauJEFEOZZoNnMkPjXyA(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = lRGQQnDApauJEFEOZZoNnMkPjXyA(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int lRGQQnDApauJEFEOZZoNnMkPjXyA(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				tpmdIqhoXutjjjSHnUUKTLmlqsjb[P_0] = -1;
				SKHxoaRqwmPCTqJKKZVnXeAnNchS[P_0] = P_2;
				return -1;
			}
			if (P_2 != SKHxoaRqwmPCTqJKKZVnXeAnNchS[P_0])
			{
				int num = rkGKPiFhaWAWAfGtnEMYifPdgHYiB;
				if (rkGKPiFhaWAWAfGtnEMYifPdgHYiB == int.MaxValue)
				{
					rkGKPiFhaWAWAfGtnEMYifPdgHYiB = 0;
				}
				else
				{
					rkGKPiFhaWAWAfGtnEMYifPdgHYiB++;
				}
				SKHxoaRqwmPCTqJKKZVnXeAnNchS[P_0] = P_2;
				tpmdIqhoXutjjjSHnUUKTLmlqsjb[P_0] = num;
				return num;
			}
			return tpmdIqhoXutjjjSHnUUKTLmlqsjb[P_0];
		}

		private void gkPgSOhCVzcwKXxrfymguLkTrelRA()
		{
			XWSrvgraqjZjnwaXbFfJreoctENR = true;
		}

		~DualSenseDriver()
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
				SxJxxXaKnQbzArRgVwwkuUYcyrhI(sEFlMWgexWIvWAvMGQUwmUTmbxg.Synchronous);
				if (QRRGDLqbiaCGBhafJDtJkPxMcuSN != null)
				{
					QRRGDLqbiaCGBhafJDtJkPxMcuSN.Dispose();
				}
				if (ZFeOTfqkMHEFlOYAHOmVynLZegZx != null)
				{
					ZFeOTfqkMHEFlOYAHOmVynLZegZx.Dispose();
				}
			}
		}

		public static bool Matches(int vid, int pid)
		{
			if (vid == 1356 && pid == 3302)
			{
				return true;
			}
			return false;
		}

		private static uint HLzIJhmKpDtNZkWrbnqhtodkakyt(NativeBuffer P_0, int P_1)
		{
			uint num = 3940166985u;
			for (int i = 0; i < P_1; i++)
			{
				num = nXsfXBFEsCXXRYMYHfdQEsRNGikdb[(byte)num ^ P_0[i]] ^ (num >> 8);
			}
			return num;
		}

		private static veiIwkesPxzjuPZHaKXAyktzmTHv wpzDhLbUwxmbuKcYVDfbYNRxLlWk(DualSenseOtherLightBrightness P_0)
		{
			return P_0 switch
			{
				DualSenseOtherLightBrightness.High => veiIwkesPxzjuPZHaKXAyktzmTHv.High, 
				DualSenseOtherLightBrightness.Medium => veiIwkesPxzjuPZHaKXAyktzmTHv.Medium, 
				DualSenseOtherLightBrightness.Low => veiIwkesPxzjuPZHaKXAyktzmTHv.Low, 
				_ => throw new NotImplementedException(), 
			};
		}

		private static DualSenseOtherLightBrightness jGpWjAqQHggyvHaMedhuiPcaKOILA(veiIwkesPxzjuPZHaKXAyktzmTHv P_0)
		{
			return P_0 switch
			{
				veiIwkesPxzjuPZHaKXAyktzmTHv.High => DualSenseOtherLightBrightness.High, 
				veiIwkesPxzjuPZHaKXAyktzmTHv.Medium => DualSenseOtherLightBrightness.Medium, 
				veiIwkesPxzjuPZHaKXAyktzmTHv.Low => DualSenseOtherLightBrightness.Low, 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
