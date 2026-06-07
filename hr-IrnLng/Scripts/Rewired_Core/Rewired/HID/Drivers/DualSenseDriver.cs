using System;
using Rewired.ControllerExtensions;
using Rewired.Drivers.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualSenseDriver : HIDDeviceDriver, IDisposable, IControllerDriver, IDriver_DualSense
	{
		private enum amatBmweLdVWjxIlHxOAYBNCtcM
		{
			BOQGguqqubCWKDSUZpMHZEZjhNc = 0,
			bHGPZbBUWDPVpGBeVeXCBQUznQJt = 1,
			zzAPBlNdVXWHJNLxcVpkevnqJed = 2
		}

		private enum mRHqibVSwsXGSvLDdvwUSCEbzrh
		{
			xHdBaRgdNDZThJOvnpmpFtvdLIun = 0,
			VXjtnraIizIIukDUXLQquwSuhjv = 1,
			bHGPZbBUWDPVpGBeVeXCBQUznQJt = 2
		}

		public enum hlMMUKjkAXmuFeNmPWxMUlvbJCJ : byte
		{
			mxOhlRIHXrCziqeVLLFRROozeMF = 0,
			IsjvvrItNywXZxAQMFdcBaTiHOK = 1,
			ElqgYfTWJNRxWvxlvHdHJGqpNam = 2
		}

		private const float dWgKllCWiILMCmLXaoFpsCYrPff = 4f;

		private const int KEPWIVLoHsLSAdrpdXFruDkpWpy = 15;

		private const int StSDqTSzHcSqfDOnfmAEHyGixwH = 2;

		private const int cAHenuUNXFruiossCkFEClOOhAH = 0;

		private const int CWWrorMjPwpoYlFMTiUHavxGJDz = 1912;

		private const int qlxfmcfGaoZrKoBRNADWhSrhXXbx = 0;

		private const int NohKZmdTdifYkiiEyDVJRLXaeYsE = 941;

		private const bool lKfcETgiWcsAecbDdKJmieXlHnxA = false;

		private const bool nCvDjlZyBfOYaboFaqNcpisiGPf = true;

		private const float TgXzfzZbnjAcJxwRLMdmrazVdea = 2.5f;

		private const int tKRsOxtxmViJQVzbWUETMwSCOrx = 0;

		private const int bsIRaDOqBgutSHhfNzTiKwaXFrj = 0;

		private const int OBuOWVRMCINqSZEqDdfkguRTVSg = 1;

		private const int xJLypvdevIwLMYBsNdiwGAHPpHpi = 0;

		private const int pxqqpkIIwwBMtoCOmhCdjrYzxrv = 0;

		private const int hRmRqWBDYVErJlbPuaQCQZdPMhc = 0;

		private const int ShUryPIOHxcuCJmISQHpHSzWPUB = 1;

		private const int qEwYnJrPVpAOxDtPLEWDEaJqDqmx = 49;

		private const int KfrEuDGebTcitidWjnYFCVWzsfo = 0;

		private const int SWXfZxsKBcVUwModNevHfrVspDlG = 1;

		private const int FTPhjwVLJHfRHFpAlpUnBmPDxvrk = 64;

		private const int ijGXRpxNDGsQOSUrtIKZNomCWtc = 48;

		private const int wFzEPoKKFITlYqUaQMBOiUGEluOr = 547;

		private const int TmIKhkSpTwRDKiMEVmmHsVMVVCQ = 64;

		private const int pxJLySIrFMPLVmANIOXFBcmatOi = 547;

		private const int otJdBIosnyyDNvWuaegIEtMjRcW = 1;

		private const int PMZlxWwdEjaflHtLfGRGXrYRIGm = 2;

		private const int SwbxqJMksYttsZvNpxtYNCsszFP = 3;

		private const int OrCdyZlDBYGLjcDmWfYYAskCgVlS = 4;

		private const int ygWYeWCjtOFJExqPSDrcPgOUXag = 5;

		private const int fDPjwjATfgDVfoPnNDBUtQGhnBEo = 6;

		private const int bobwBHaikgHAySVzaaNWItGTorvf = 8;

		private const int rMaMXcVGsZPtjdFNdovpwgnIrPc = 22;

		private const int DFNpaSoFeCgcjoFdzEMBAJsEkR = 16;

		private const int WtZXcwSGnTLtcDroRrzPQzVljnO = 33;

		private const int pAqcCOjXEXfkueHBZcirDRrFXOUZ = 8;

		private const int YlyGVJftRPmDvYOeMiHiVvLjxwmQ = 9;

		private const int gfDgroDBKLrIKiZPiRNqDHgkRhVg = 10;

		private const int WgeFgyGqwPMpnTDWlAYxZaXkLBH = 28;

		private const int CTwBDrbKzlEamxVmFQPsmGNzQmnh = 54;

		private const int GXhjPMkMrQSpQPBwohiGZZtIPsw = 55;

		private const int LIqXMhOGiukWLaDRyGwLQEnQjpED = 54;

		private const bool eWPCrUTsSmeFNbfCBBNzwDcHDBwE = true;

		private const int BesExpijNmlmADuBFZwedoJfeApM = 25;

		private const int pEUQlLKnyiSEEiIROkPvVdphENf = 3000000;

		private const float ekyHwEriVhxRNJIlsasVutRwBFs = 8192f;

		private const float WugayyBQAmjkubOywlraGExHBZYV = 3.4971635f;

		private const float MjAXpPICgNlhCRJUMwISHYnFnxy = 0.06103702f;

		private const bool FWHneVaLqqBimyGCzGfWBPYtvlF = true;

		private const bool lSqfloVDwlyKpZRaCVQalEWJZYw = true;

		private const bool FFdioKzQfPGEYLUUOAnzeunTExO = true;

		private const bool PAMBKwJTNzsmeIrKpXXFYTmTfpY = true;

		private const float bjHUlDiCkZzsMceItSkeZITtAfF = 4096f;

		private const float OqFZoDOeIUjbtwnBDztVJwUnnbZ = 16384f;

		private const float NWCDMZDRNKvUQBQMJEssWkSDwaS = 16777216f;

		private const float QwHBGdDUUwWYmIgiNfkWQHCtkiaU = 268435460f;

		private const float oJriwgDOVatwelxowzWiPNdGBzt = 0.01999998f;

		private const float tbhQhpXOBsAyJtdULflnvksGtGs = 8192f;

		private const float itYiJCygNsEAqXbbQISdINTPpOWA = 0.98f;

		private const float jSfdFwBToaVgLGJyeZSFhrGvOccj = 45f;

		private const float QJDyUNlipWSJltdcgnUqABebkmp = 20f;

		private const uint snbbfYfxVqBGwerZFltrVzgUXtlE = 3940166985u;

		private readonly bool mMPhpzrlAiLsTCNuvodwKAKqjED;

		private readonly int flmiOHBCOudXmFKDPbbPieZjwAtZ;

		private readonly int ltKevSEVezIwOsauZJVhZbJxLGfl;

		private readonly bool bHSEZINYoKxWGtkrnKYyOWRyLRC;

		private readonly byte mYYgeyIefhdpWlgtOgyKDCyuRxC;

		private readonly int ossUeMAergkBVXHROHOeEIxycyCc;

		private readonly int QTKxYTxFmQrnkRBzSNCmBilYBRc;

		private readonly int mWrgKdrDcevatBVDCUEFUdxrTMZ;

		private readonly int ukcKvHyfwrInOUdNLNByxyKZvfN;

		private readonly int nvOejAuhkiazSshFcHwFloCdtdA;

		private readonly int NTTXIVxtmsQiPrbpaadsjcqEaVkt;

		private readonly NativeBuffer AefEkpbfHElTyBMlaqmDNCteGkjO;

		private readonly NativeBuffer TPSpSLhbrlBSIvSWkEtRGjZVKkR;

		private OutputReport IvPKgKkDdjiQRIeyQBKtobHpCOfP;

		private readonly Func<OutputReport, bool> caiqrwIKNFaqbsKYlJrOKtgxQKM;

		private readonly Action<OutputReport> sXCsxnNDNTRewUgWMsCsNbDKWD;

		private bool RZchZGqANZCUKLHDEBwBNAckBGTa;

		private bool VGURhWdQMTFOObsJhgieHNpOgBh;

		private double eFUvTsaAssdhlmVzqhdQQNTllrC;

		private byte UdfRUIBZbxHcJUlNKIKqfXwJyuR;

		private bool FPsaUCJTSuJQOgZAAHLslwOvNWO;

		private bool MCTZAMiMQFityNlFzWQSLHusDMk;

		private bool VntTTJPqFNsaoIElCkHTagbwxco;

		private Quaternion lJQccxhVnXnfTvAIBVHWrFIZLRPG = Quaternion.identity;

		private DualSenseMicrophoneLightMode JzjcxzvcImagmMtVmLOwWIGAdTZ;

		private hlMMUKjkAXmuFeNmPWxMUlvbJCJ lBYnKOVislVDWWklERQJlHWLvWw;

		private DualSensePlayerLightFlags ykNixwGcDQTTBLOYibPAabZDDkJg;

		private bool QkgseYxSUXbyykYfqWEhlAPglsw;

		private bool RaqXqqacjtDzwjYmHhoLetnseKX;

		private uint SyOzjQejNQcMUJGrBnLyAVDELwqh;

		private float dFjDVWUPlZtEDaqqeXUQBYvhpTn;

		private double zajIjBKoFZMamamCDGhKcLrHnvuc;

		private float MEHyhMotCWHdqckBGbJAAKSZSsm;

		private byte uEjVeHBcdnGlujJlXlNXfmHfeDz;

		private byte JaUtjKnwhHmTpphPFpmGzObryJx;

		private Quaternion pIRrCmOoPCdXmXBHIMUiZHdamIY = Quaternion.identity;

		private Quaternion mBbrEfTYyrEdbAhksWuJZqXclqL = Quaternion.identity;

		private bool aMulxfaoRIxUsCpWLcARqAgnqbG;

		private int zJcrbYEPTwTntlnvMZCYVgXodJQ;

		private int[] vhEwFmcQLMImQUmIGmRWnIXdwuq = new int[2];

		private int[] GdrIeUEZnMZfyZgMhOuhfrWzcZd = new int[2];

		private static uint[] nuOnLpBRpgErahYouuiUMBTRgPm = new uint[256]
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
				num = ((!mMPhpzrlAiLsTCNuvodwKAKqjED) ? ((float)(UdfRUIBZbxHcJUlNKIKqfXwJyuR - 1) * 10f) : ((float)(UdfRUIBZbxHcJUlNKIKqfXwJyuR + 2) * 10f));
				return MathTools.Clamp(num, 0f, 100f);
			}
		}

		public bool BatteryCharging => FPsaUCJTSuJQOgZAAHLslwOvNWO;

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
				return (int)uEjVeHBcdnGlujJlXlNXfmHfeDz;
			}
			set
			{
				uEjVeHBcdnGlujJlXlNXfmHfeDz = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				RZchZGqANZCUKLHDEBwBNAckBGTa = true;
				if (uEjVeHBcdnGlujJlXlNXfmHfeDz == 0 && JaUtjKnwhHmTpphPFpmGzObryJx == 0)
				{
					VGURhWdQMTFOObsJhgieHNpOgBh = true;
				}
			}
		}

		public float LightFlashOffDuration
		{
			get
			{
				return (int)JaUtjKnwhHmTpphPFpmGzObryJx;
			}
			set
			{
				JaUtjKnwhHmTpphPFpmGzObryJx = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				RZchZGqANZCUKLHDEBwBNAckBGTa = true;
				if (uEjVeHBcdnGlujJlXlNXfmHfeDz == 0 && JaUtjKnwhHmTpphPFpmGzObryJx == 0)
				{
					VGURhWdQMTFOObsJhgieHNpOgBh = true;
				}
			}
		}

		public DualSenseMicrophoneLightMode microphoneLightMode
		{
			get
			{
				return JzjcxzvcImagmMtVmLOwWIGAdTZ;
			}
			set
			{
				JzjcxzvcImagmMtVmLOwWIGAdTZ = value;
				RZchZGqANZCUKLHDEBwBNAckBGTa = true;
			}
		}

		public DualSenseOtherLightBrightness otherLightBrightness
		{
			get
			{
				return hNLRucrkyCdCYcQBXquJbaRyYQX(lBYnKOVislVDWWklERQJlHWLvWw);
			}
			set
			{
				lBYnKOVislVDWWklERQJlHWLvWw = sIXDxzcUlPCnFAhYwnSdlqTjxDGu(value);
				RZchZGqANZCUKLHDEBwBNAckBGTa = true;
			}
		}

		public DualSensePlayerLightFlags playerLights
		{
			get
			{
				return ykNixwGcDQTTBLOYibPAabZDDkJg;
			}
			set
			{
				ykNixwGcDQTTBLOYibPAabZDDkJg = value;
				RZchZGqANZCUKLHDEBwBNAckBGTa = true;
			}
		}

		public Vector3 AccelerometerValue => ObjaoVadkAjRNZsmweslXOdEulC(accelerometers[0].rawValue);

		public Vector3 AccelerometerValueRaw => new Vector3(accelerometers[0].rawValue[0], accelerometers[0].rawValue[1], accelerometers[0].rawValue[2]);

		public Vector3 GyroscopeValue => GnnEYwfGaGGVTgrMPbzshWJKmcCs(gyroscopes[0].events);

		public Vector3 GyroscopeValueRaw => new Vector3(gyroscopes[0].rawValue[0], gyroscopes[0].rawValue[1], gyroscopes[0].rawValue[2]);

		public Vector3 LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);
				return GnnEYwfGaGGVTgrMPbzshWJKmcCs(vector, dFjDVWUPlZtEDaqqeXUQBYvhpTn);
			}
		}

		public Vector3 LastGyroscopeValueRaw => new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);

		public Quaternion Orientation => lJQccxhVnXnfTvAIBVHWrFIZLRPG;

		public int MaxTouches => 2;

		public void ResetOrientation()
		{
			lJQccxhVnXnfTvAIBVHWrFIZLRPG = Quaternion.identity;
			aMulxfaoRIxUsCpWLcARqAgnqbG = false;
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
			uEjVeHBcdnGlujJlXlNXfmHfeDz = 0;
			JaUtjKnwhHmTpphPFpmGzObryJx = 0;
			RZchZGqANZCUKLHDEBwBNAckBGTa = true;
			VGURhWdQMTFOObsJhgieHNpOgBh = true;
		}

		public void StopVibration()
		{
			int vibrationMotorCount = base.VibrationMotorCount;
			for (int i = 0; i < vibrationMotorCount; i++)
			{
				vibrationMotors[i].SpeedRaw = 0;
			}
		}

		public DualSenseDriver(InitArgs initArgs)
		{
			if (initArgs == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			flmiOHBCOudXmFKDPbbPieZjwAtZ = initArgs.hatZeroValue;
			ltKevSEVezIwOsauZJVhZbJxLGfl = initArgs.hatSpan;
			ossUeMAergkBVXHROHOeEIxycyCc = initArgs.inputReportLength;
			QTKxYTxFmQrnkRBzSNCmBilYBRc = initArgs.outputReportLength;
			caiqrwIKNFaqbsKYlJrOKtgxQKM = initArgs.synchronousWriteOutputReportDelegate;
			sXCsxnNDNTRewUgWMsCsNbDKWD = initArgs.asynchronousWriteOutputReportDelegate;
			mMPhpzrlAiLsTCNuvodwKAKqjED = initArgs.connectionType == DeviceConnectionType.SFwcoIElPuWXQcTCEiAmKWHEztR;
			if (mMPhpzrlAiLsTCNuvodwKAKqjED)
			{
				QTKxYTxFmQrnkRBzSNCmBilYBRc = 547;
			}
			else
			{
				QTKxYTxFmQrnkRBzSNCmBilYBRc = 48;
			}
			AefEkpbfHElTyBMlaqmDNCteGkjO = new NativeBuffer(64);
			TPSpSLhbrlBSIvSWkEtRGjZVKkR = new NativeBuffer(QTKxYTxFmQrnkRBzSNCmBilYBRc);
			IvPKgKkDdjiQRIeyQBKtobHpCOfP = new OutputReport(TPSpSLhbrlBSIvSWkEtRGjZVKkR.Pointer, TPSpSLhbrlBSIvSWkEtRGjZVKkR.Length, QTKxYTxFmQrnkRBzSNCmBilYBRc);
			lights = new HIDLight[1]
			{
				new HIDLight(11, 24, 28)
			};
			lights[0].ValueChangedEvent += ufpgEoXGwVrNvUffWjXkzVeFgwd;
			vibrationMotors = new HIDVibrationMotor[2]
			{
				new HIDVibrationMotor(0, 255),
				new HIDVibrationMotor(0, 255)
			};
			vibrationMotors[0].ValueChangedEvent += ufpgEoXGwVrNvUffWjXkzVeFgwd;
			vibrationMotors[1].ValueChangedEvent += ufpgEoXGwVrNvUffWjXkzVeFgwd;
			if (mMPhpzrlAiLsTCNuvodwKAKqjED)
			{
				byte[] array = initArgs.getFeatureReportDelegate(5);
				bHSEZINYoKxWGtkrnKYyOWRyLRC = array != null && array.Length > 0;
				if (bHSEZINYoKxWGtkrnKYyOWRyLRC)
				{
					kaNyqmHaSydJUQEzzPxMKRWwlat(wruyziXHZVSFMldlrVBWMmkPnqz.PMWgOuJtLQMJprSBqurejINtaRpv);
				}
			}
			else
			{
				bHSEZINYoKxWGtkrnKYyOWRyLRC = true;
				bHSEZINYoKxWGtkrnKYyOWRyLRC = kaNyqmHaSydJUQEzzPxMKRWwlat(wruyziXHZVSFMldlrVBWMmkPnqz.PMWgOuJtLQMJprSBqurejINtaRpv);
			}
			if (!bHSEZINYoKxWGtkrnKYyOWRyLRC)
			{
				throw new Exception("Special features not supported so just treat this as a standard HID device.");
			}
			mYYgeyIefhdpWlgtOgyKDCyuRxC = 1;
			mWrgKdrDcevatBVDCUEFUdxrTMZ = 0;
			if (mMPhpzrlAiLsTCNuvodwKAKqjED && bHSEZINYoKxWGtkrnKYyOWRyLRC)
			{
				mYYgeyIefhdpWlgtOgyKDCyuRxC = 49;
				mWrgKdrDcevatBVDCUEFUdxrTMZ = 1;
			}
			ukcKvHyfwrInOUdNLNByxyKZvfN = 8 + mWrgKdrDcevatBVDCUEFUdxrTMZ;
			nvOejAuhkiazSshFcHwFloCdtdA = 9 + mWrgKdrDcevatBVDCUEFUdxrTMZ;
			NTTXIVxtmsQiPrbpaadsjcqEaVkt = 10 + mWrgKdrDcevatBVDCUEFUdxrTMZ;
			buttons = new HIDButton[15];
			for (int i = 0; i < 15; i++)
			{
				buttons[i] = new HIDButton(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new HIDAxis[6]
			{
				new HIDAxis(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 127),
				new HIDAxis(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 127),
				new HIDAxis(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 127),
				new HIDAxis(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 127),
				new HIDAxis(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 5 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 0),
				new HIDAxis(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 6 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 0)
			};
			hats = new HIDHat[1]
			{
				new HIDHat(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 8 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, qzaGrAcormgAqQMqJbwwWrRXoWQ)
			};
			accelerometers = new HIDAccelerometer[1]
			{
				new HIDAccelerometer(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 22 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 48
				}, 3, uSYDKtPBWyZoEqdOREHBfpeQIyAD)
			};
			gyroscopes = new HIDGyroscope[1]
			{
				new HIDGyroscope(initArgs.updateLoopSetting, mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 16 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 48
				}, 3, 25, niNgMuslxKaZgceMxOEEXwymfdpS, wLAjPGyPuBdMrcpLISPdnjzqkNmK)
			};
			touchpads = new HIDTouchpad[1]
			{
				new HIDTouchpad(mYYgeyIefhdpWlgtOgyKDCyuRxC, new HIDTouchpad.TouchpadInfo(2, 0, 1912, 0, 941, invertY: false, reverseY: true), new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 33 + mWrgKdrDcevatBVDCUEFUdxrTMZ,
					bitSize = 48
				}, hTEgDKFmZOwwMCewGRBTSwbbtrb)
			};
			zajIjBKoFZMamamCDGhKcLrHnvuc = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			TMgvRQklZtspzPeGgFcHCfRKbSfF();
			EtdDVpxGUsaoldQogYbkpOQgEyjc(wruyziXHZVSFMldlrVBWMmkPnqz.hXynUPOhxYJwCUolLiXrgDrOcWu);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < AefEkpbfHElTyBMlaqmDNCteGkjO.Length)
			{
				return false;
			}
			MEHyhMotCWHdqckBGbJAAKSZSsm = (float)(timestamp - zajIjBKoFZMamamCDGhKcLrHnvuc);
			zajIjBKoFZMamamCDGhKcLrHnvuc = timestamp;
			AefEkpbfHElTyBMlaqmDNCteGkjO.Write(inputReportPtr, inputReportLength, AefEkpbfHElTyBMlaqmDNCteGkjO.Length);
			AVtNjJgBaVgRtIaBrLEPhbFamUMc(AefEkpbfHElTyBMlaqmDNCteGkjO);
			DmLZJnvnrnNkrBYTnoYZbojIVhn(AefEkpbfHElTyBMlaqmDNCteGkjO, timestamp);
			hwHaYIiTEvRaleSlaFhMhqeHzxK(axes, AefEkpbfHElTyBMlaqmDNCteGkjO, timestamp);
			hwHaYIiTEvRaleSlaFhMhqeHzxK(hats, AefEkpbfHElTyBMlaqmDNCteGkjO, timestamp);
			hwHaYIiTEvRaleSlaFhMhqeHzxK(accelerometers, AefEkpbfHElTyBMlaqmDNCteGkjO, timestamp);
			hwHaYIiTEvRaleSlaFhMhqeHzxK(gyroscopes, AefEkpbfHElTyBMlaqmDNCteGkjO, timestamp);
			hwHaYIiTEvRaleSlaFhMhqeHzxK(touchpads, AefEkpbfHElTyBMlaqmDNCteGkjO, timestamp);
			FPsaUCJTSuJQOgZAAHLslwOvNWO = (AefEkpbfHElTyBMlaqmDNCteGkjO[54 + mWrgKdrDcevatBVDCUEFUdxrTMZ] & 8) != 0;
			MCTZAMiMQFityNlFzWQSLHusDMk = (AefEkpbfHElTyBMlaqmDNCteGkjO[55 + mWrgKdrDcevatBVDCUEFUdxrTMZ] & 0x20) != 0;
			UdfRUIBZbxHcJUlNKIKqfXwJyuR = (byte)(AefEkpbfHElTyBMlaqmDNCteGkjO[55 + mWrgKdrDcevatBVDCUEFUdxrTMZ] & 0xF);
			VntTTJPqFNsaoIElCkHTagbwxco = (AefEkpbfHElTyBMlaqmDNCteGkjO[54 + mWrgKdrDcevatBVDCUEFUdxrTMZ] & 1) != 0;
			GBwAUEfKFiUziSkhMWXIqaJJQjla();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualSenseExtension(this);
		}

		private void EtdDVpxGUsaoldQogYbkpOQgEyjc(wruyziXHZVSFMldlrVBWMmkPnqz P_0)
		{
			if (RZchZGqANZCUKLHDEBwBNAckBGTa)
			{
				kaNyqmHaSydJUQEzzPxMKRWwlat(P_0);
				RZchZGqANZCUKLHDEBwBNAckBGTa = false;
			}
		}

		private bool kaNyqmHaSydJUQEzzPxMKRWwlat(wruyziXHZVSFMldlrVBWMmkPnqz P_0)
		{
			FyXDTkkoQgBIkIOMPrsPJPpQWUph();
			bool result = aVzxnnjmGlRYclaUUzLjDmhmPEn(P_0);
			if (VGURhWdQMTFOObsJhgieHNpOgBh)
			{
				result = aVzxnnjmGlRYclaUUzLjDmhmPEn(P_0);
				VGURhWdQMTFOObsJhgieHNpOgBh = false;
			}
			return result;
		}

		private void FyXDTkkoQgBIkIOMPrsPJPpQWUph()
		{
			if (mMPhpzrlAiLsTCNuvodwKAKqjED && bHSEZINYoKxWGtkrnKYyOWRyLRC)
			{
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[0] = 49;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[1] = 2;
				FyXDTkkoQgBIkIOMPrsPJPpQWUph(TPSpSLhbrlBSIvSWkEtRGjZVKkR, 2);
				uint num = HlDdaHtMGbApqJKpYxFfRxloqku(TPSpSLhbrlBSIvSWkEtRGjZVKkR, 74);
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[74] = (byte)(num & 0xFF);
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[75] = (byte)((num & 0xFF00) >> 8);
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[76] = (byte)((num & 0xFF0000) >> 16);
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[77] = (byte)((num & 0xFF000000u) >> 24);
			}
			else
			{
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[0] = 2;
				FyXDTkkoQgBIkIOMPrsPJPpQWUph(TPSpSLhbrlBSIvSWkEtRGjZVKkR, 1);
			}
		}

		private void FyXDTkkoQgBIkIOMPrsPJPpQWUph(NativeBuffer P_0, int P_1)
		{
			P_0[P_1] = byte.MaxValue;
			P_0[1 + P_1] = 247;
			P_0[2 + P_1] = (byte)vibrationMotors[1].SpeedRaw;
			P_0[3 + P_1] = (byte)vibrationMotors[0].SpeedRaw;
			P_0[8 + P_1] = (byte)JzjcxzvcImagmMtVmLOwWIGAdTZ;
			P_0[43 + P_1] = (byte)ykNixwGcDQTTBLOYibPAabZDDkJg;
			if (QkgseYxSUXbyykYfqWEhlAPglsw)
			{
				P_0[43 + P_1] = (byte)(P_0[43 + P_1] & -33);
			}
			else
			{
				P_0[43 + P_1] |= 32;
			}
			P_0[38 + P_1] = 3;
			P_0[41 + P_1] = (byte)(RaqXqqacjtDzwjYmHhoLetnseKX ? 1 : 2);
			P_0[42 + P_1] = (byte)lBYnKOVislVDWWklERQJlHWLvWw;
			P_0[44 + P_1] = lights[0].ColorRRaw;
			P_0[45 + P_1] = lights[0].ColorGRaw;
			P_0[46 + P_1] = lights[0].ColorBRaw;
		}

		private bool aVzxnnjmGlRYclaUUzLjDmhmPEn(wruyziXHZVSFMldlrVBWMmkPnqz P_0)
		{
			eFUvTsaAssdhlmVzqhdQQNTllrC = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case wruyziXHZVSFMldlrVBWMmkPnqz.PMWgOuJtLQMJprSBqurejINtaRpv:
				if (caiqrwIKNFaqbsKYlJrOKtgxQKM == null)
				{
					return false;
				}
				return caiqrwIKNFaqbsKYlJrOKtgxQKM(IvPKgKkDdjiQRIeyQBKtobHpCOfP);
			case wruyziXHZVSFMldlrVBWMmkPnqz.hXynUPOhxYJwCUolLiXrgDrOcWu:
				if (sXCsxnNDNTRewUgWMsCsNbDKWD == null)
				{
					return false;
				}
				sXCsxnNDNTRewUgWMsCsNbDKWD(IvPKgKkDdjiQRIeyQBKtobHpCOfP);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void DmLZJnvnrnNkrBYTnoYZbojIVhn(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[ukcKvHyfwrInOUdNLNByxyKZvfN];
			buttons[0].SetValue((b & 0x10) != 0, P_1);
			buttons[1].SetValue((b & 0x20) != 0, P_1);
			buttons[2].SetValue((b & 0x40) != 0, P_1);
			buttons[3].SetValue((b & 0x80) != 0, P_1);
			b = P_0[nvOejAuhkiazSshFcHwFloCdtdA];
			buttons[4].SetValue((b & 1) != 0, P_1);
			buttons[5].SetValue((b & 2) != 0, P_1);
			buttons[6].SetValue((b & 4) != 0, P_1);
			buttons[7].SetValue((b & 8) != 0, P_1);
			buttons[8].SetValue((b & 0x10) != 0, P_1);
			buttons[9].SetValue((b & 0x20) != 0, P_1);
			buttons[10].SetValue((b & 0x40) != 0, P_1);
			buttons[11].SetValue((b & 0x80) != 0, P_1);
			b = P_0[NTTXIVxtmsQiPrbpaadsjcqEaVkt];
			buttons[12].SetValue((b & 1) != 0, P_1);
			buttons[13].SetValue((b & 2) != 0, P_1);
			if (bHSEZINYoKxWGtkrnKYyOWRyLRC)
			{
				buttons[14].SetValue((b & 4) != 0, P_1);
			}
		}

		private void hwHaYIiTEvRaleSlaFhMhqeHzxK(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].UpdateValue(P_1, P_2);
			}
		}

		private void TMgvRQklZtspzPeGgFcHCfRKbSfF()
		{
			if (isVibrating && ReInput.realTime >= eFUvTsaAssdhlmVzqhdQQNTllrC)
			{
				RZchZGqANZCUKLHDEBwBNAckBGTa = true;
			}
		}

		private void AVtNjJgBaVgRtIaBrLEPhbFamUMc(NativeBuffer P_0)
		{
			if (bHSEZINYoKxWGtkrnKYyOWRyLRC)
			{
				uint num = AefEkpbfHElTyBMlaqmDNCteGkjO.ReadUInt(28 + mWrgKdrDcevatBVDCUEFUdxrTMZ);
				float num3;
				if (num != SyOzjQejNQcMUJGrBnLyAVDELwqh)
				{
					uint num2 = (uint)((num >= SyOzjQejNQcMUJGrBnLyAVDELwqh) ? (num - SyOzjQejNQcMUJGrBnLyAVDELwqh) : ((long)num + 4294967295L - SyOzjQejNQcMUJGrBnLyAVDELwqh));
					num3 = (float)num2 / 3000000f;
				}
				else
				{
					uint num2 = 0u;
					num3 = 0f;
				}
				SyOzjQejNQcMUJGrBnLyAVDELwqh = num;
				dFjDVWUPlZtEDaqqeXUQBYvhpTn = num3;
			}
		}

		private void GBwAUEfKFiUziSkhMWXIqaJJQjla()
		{
			if (bHSEZINYoKxWGtkrnKYyOWRyLRC && !(dFjDVWUPlZtEDaqqeXUQBYvhpTn <= 0f))
			{
				Vector3 vector = GnnEYwfGaGGVTgrMPbzshWJKmcCs(new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]), dFjDVWUPlZtEDaqqeXUQBYvhpTn);
				xohcDsacOFZCkALnqUHMJfyYnqIA(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].rawValue[0] * -1f, accelerometers[0].rawValue[1] * -1f, accelerometers[0].rawValue[2] * -1f);
				XvOcAbIDkGASqOjGxNMFhkNGTEia(vector2, vector);
			}
		}

		private static bool xohcDsacOFZCkALnqUHMJfyYnqIA(ref Vector3 P_0)
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

		private void XvOcAbIDkGASqOjGxNMFhkNGTEia(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && gFxxeBFCYAuggBcTRMOFEuGTnQT(P_0, out var mRHqibVSwsXGSvLDdvwUSCEbzrh2))
			{
				Quaternion a = lJQccxhVnXnfTvAIBVHWrFIZLRPG * quaternion;
				if (!aMulxfaoRIxUsCpWLcARqAgnqbG)
				{
					aMulxfaoRIxUsCpWLcARqAgnqbG = true;
					pIRrCmOoPCdXmXBHIMUiZHdamIY = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					mBbrEfTYyrEdbAhksWuJZqXclqL = lJQccxhVnXnfTvAIBVHWrFIZLRPG;
				}
				pIRrCmOoPCdXmXBHIMUiZHdamIY *= quaternion;
				mBbrEfTYyrEdbAhksWuJZqXclqL *= quaternion;
				Quaternion b;
				if ((mRHqibVSwsXGSvLDdvwUSCEbzrh2 & mRHqibVSwsXGSvLDdvwUSCEbzrh.VXjtnraIizIIukDUXLQquwSuhjv) != mRHqibVSwsXGSvLDdvwUSCEbzrh.xHdBaRgdNDZThJOvnpmpFtvdLIun)
				{
					b = DrLyVdRffFDYNoKtmaNMOTRipHj(P_0, a.eulerAngles.y);
				}
				else if ((mRHqibVSwsXGSvLDdvwUSCEbzrh2 & mRHqibVSwsXGSvLDdvwUSCEbzrh.bHGPZbBUWDPVpGBeVeXCBQUznQJt) != mRHqibVSwsXGSvLDdvwUSCEbzrh.xHdBaRgdNDZThJOvnpmpFtvdLIun)
				{
					b = KbqZTtHDtyBqxDDbotDQAMfoWbu(P_0);
					Vector3 vector = mBbrEfTYyrEdbAhksWuJZqXclqL * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				lJQccxhVnXnfTvAIBVHWrFIZLRPG = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				lJQccxhVnXnfTvAIBVHWrFIZLRPG *= quaternion;
				if (aMulxfaoRIxUsCpWLcARqAgnqbG)
				{
					aMulxfaoRIxUsCpWLcARqAgnqbG = false;
				}
			}
		}

		private static Quaternion wqhnMAppxDVTMYMQNDLJmHtlboRG(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = new Vector3(P_0.x, P_0.y, P_0.z);
			Vector3 vector2 = AmpcUezhbYwYSNIVTJgmZPLSFWF(vector, P_1);
			return new Quaternion(vector2.x, vector2.y, vector2.z, P_0.w);
		}

		private static Vector3 AmpcUezhbYwYSNIVTJgmZPLSFWF(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion ePVCTOrkCFhxNKhjkaUvcnKgWVC(Quaternion P_0, amatBmweLdVWjxIlHxOAYBNCtcM P_1)
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

		private float GBISkccpIKbMRFQAZDfdGGzEVUvT(float P_0, float P_1)
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

		private Vector3 YcmnCIkrZniyQeztlUGftkAGIGR(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
			float num2 = MathTools.Atan2(P_0.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x2, P_1, z);
		}

		private Quaternion DrLyVdRffFDYNoKtmaNMOTRipHj(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
			float num2 = MathTools.Atan2(P_0.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x2, P_1, z);
		}

		private Quaternion KbqZTtHDtyBqxDDbotDQAMfoWbu(Vector3 P_0, float P_1 = 0f)
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

		private float caseOfmmOLduOZWNfaejIlROmawI(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool lJTBJyObViQaqDEmyEbpepfWVaj(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool gFxxeBFCYAuggBcTRMOFEuGTnQT(Vector3 P_0, out mRHqibVSwsXGSvLDdvwUSCEbzrh P_1)
		{
			P_0.Normalize();
			P_1 = mRHqibVSwsXGSvLDdvwUSCEbzrh.xHdBaRgdNDZThJOvnpmpFtvdLIun;
			bool result = false;
			if (CTyxvgxhreIBtOAKyUKaIzAQtNX(P_0))
			{
				result = true;
				P_1 |= mRHqibVSwsXGSvLDdvwUSCEbzrh.VXjtnraIizIIukDUXLQquwSuhjv;
			}
			if (vbKEWrNjJDhDyCwWzNZYTKwlBRTc(P_0))
			{
				result = true;
				P_1 |= mRHqibVSwsXGSvLDdvwUSCEbzrh.bHGPZbBUWDPVpGBeVeXCBQUznQJt;
			}
			return result;
		}

		private bool CTyxvgxhreIBtOAKyUKaIzAQtNX(Vector3 P_0)
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

		private bool vbKEWrNjJDhDyCwWzNZYTKwlBRTc(Vector3 P_0)
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

		private Vector3 ObjaoVadkAjRNZsmweslXOdEulC(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 GnnEYwfGaGGVTgrMPbzshWJKmcCs(ExpandableArray_DataContainer<HIDGyroscope.ubnVRumZvQibiLoaPGlFgdqPNxLF> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				HIDGyroscope.ubnVRumZvQibiLoaPGlFgdqPNxLF ubnVRumZvQibiLoaPGlFgdqPNxLF = P_0[i];
				result += GnnEYwfGaGGVTgrMPbzshWJKmcCs(ubnVRumZvQibiLoaPGlFgdqPNxLF.EcKfTFWnqsKEYsThPRHDCjhWUGd, ubnVRumZvQibiLoaPGlFgdqPNxLF.fcZZPDOEDPeOhDbjpaAZcXRmWqQH);
			}
			return result;
		}

		private Vector3 GnnEYwfGaGGVTgrMPbzshWJKmcCs(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int qzaGrAcormgAqQMqJbwwWrRXoWQ(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void uSYDKtPBWyZoEqdOREHBfpeQIyAD(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void niNgMuslxKaZgceMxOEEXwymfdpS(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float wLAjPGyPuBdMrcpLISPdnjzqkNmK()
		{
			return dFjDVWUPlZtEDaqqeXUQBYvhpTn;
		}

		private void hTEgDKFmZOwwMCewGRBTSwbbtrb(NativeBuffer P_0, HIDTouchpad.TouchData[] P_1)
		{
			int num = 33 + mWrgKdrDcevatBVDCUEFUdxrTMZ;
			int positionRawX = P_0[1 + num] + (P_0[2 + num] & 0xF) * 255;
			int positionRawY = ((P_0[2 + num] & 0xF0) >> 4) + P_0[3 + num] * 16;
			int positionRawX2 = P_0[5 + num] + (P_0[6 + num] & 0xF) * 255;
			int positionRawY2 = ((P_0[6 + num] & 0xF0) >> 4) + P_0[7 + num] * 16;
			byte b = P_0[num];
			bool flag = b < 128;
			byte b2 = P_0[num + 4];
			bool flag2 = b2 < 128;
			int num2 = b & 0x7F;
			int num3 = b2 & 0x7F;
			P_1[0].isTouching = flag;
			P_1[0].touchId = dqlXcoyorJDlwaSIfdUgVjIoadBD(0, flag, num2);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = dqlXcoyorJDlwaSIfdUgVjIoadBD(1, flag2, num3);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int dqlXcoyorJDlwaSIfdUgVjIoadBD(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				vhEwFmcQLMImQUmIGmRWnIXdwuq[P_0] = -1;
				GdrIeUEZnMZfyZgMhOuhfrWzcZd[P_0] = P_2;
				return -1;
			}
			if (P_2 != GdrIeUEZnMZfyZgMhOuhfrWzcZd[P_0])
			{
				int num = zJcrbYEPTwTntlnvMZCYVgXodJQ;
				if (zJcrbYEPTwTntlnvMZCYVgXodJQ == int.MaxValue)
				{
					zJcrbYEPTwTntlnvMZCYVgXodJQ = 0;
				}
				else
				{
					zJcrbYEPTwTntlnvMZCYVgXodJQ++;
				}
				GdrIeUEZnMZfyZgMhOuhfrWzcZd[P_0] = P_2;
				vhEwFmcQLMImQUmIGmRWnIXdwuq[P_0] = num;
				return num;
			}
			return vhEwFmcQLMImQUmIGmRWnIXdwuq[P_0];
		}

		private void ufpgEoXGwVrNvUffWjXkzVeFgwd()
		{
			RZchZGqANZCUKLHDEBwBNAckBGTa = true;
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
				EtdDVpxGUsaoldQogYbkpOQgEyjc(wruyziXHZVSFMldlrVBWMmkPnqz.PMWgOuJtLQMJprSBqurejINtaRpv);
				if (AefEkpbfHElTyBMlaqmDNCteGkjO != null)
				{
					AefEkpbfHElTyBMlaqmDNCteGkjO.Dispose();
				}
				if (TPSpSLhbrlBSIvSWkEtRGjZVKkR != null)
				{
					TPSpSLhbrlBSIvSWkEtRGjZVKkR.Dispose();
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

		private static uint HlDdaHtMGbApqJKpYxFfRxloqku(NativeBuffer P_0, int P_1)
		{
			uint num = 3940166985u;
			for (int i = 0; i < P_1; i++)
			{
				num = nuOnLpBRpgErahYouuiUMBTRgPm[(byte)num ^ P_0[i]] ^ (num >> 8);
			}
			return num;
		}

		private static hlMMUKjkAXmuFeNmPWxMUlvbJCJ sIXDxzcUlPCnFAhYwnSdlqTjxDGu(DualSenseOtherLightBrightness P_0)
		{
			return P_0 switch
			{
				DualSenseOtherLightBrightness.High => hlMMUKjkAXmuFeNmPWxMUlvbJCJ.mxOhlRIHXrCziqeVLLFRROozeMF, 
				DualSenseOtherLightBrightness.Medium => hlMMUKjkAXmuFeNmPWxMUlvbJCJ.IsjvvrItNywXZxAQMFdcBaTiHOK, 
				DualSenseOtherLightBrightness.Low => hlMMUKjkAXmuFeNmPWxMUlvbJCJ.ElqgYfTWJNRxWvxlvHdHJGqpNam, 
				_ => throw new NotImplementedException(), 
			};
		}

		private static DualSenseOtherLightBrightness hNLRucrkyCdCYcQBXquJbaRyYQX(hlMMUKjkAXmuFeNmPWxMUlvbJCJ P_0)
		{
			return P_0 switch
			{
				hlMMUKjkAXmuFeNmPWxMUlvbJCJ.mxOhlRIHXrCziqeVLLFRROozeMF => DualSenseOtherLightBrightness.High, 
				hlMMUKjkAXmuFeNmPWxMUlvbJCJ.IsjvvrItNywXZxAQMFdcBaTiHOK => DualSenseOtherLightBrightness.Medium, 
				hlMMUKjkAXmuFeNmPWxMUlvbJCJ.ElqgYfTWJNRxWvxlvHdHJGqpNam => DualSenseOtherLightBrightness.Low, 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
