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
		private enum CNJTofPyWMYALZCGbMFQoucyQen
		{
			bOjsWxPvaOBcovrKzMHBnrsZkFR = 0,
			BHthfyenUmQSDsNqbVwGsEfPHjqb = 1,
			ZzjpoowFhsVnxfFVWsewAUAYcqC = 2
		}

		private enum AQgJEkcAsNUPiFMXRfZIyXrJdCE
		{
			XHUTYEIfTgeCBgXrVRVbPfGzuhN = 0,
			vXOaLwhTyAhDMnOWhkrgxQfUpQAN = 1,
			BHthfyenUmQSDsNqbVwGsEfPHjqb = 2
		}

		public enum RpboJdQsuurtFUZtKhAHmELficy : byte
		{
			AwnFbOlRxMDsWEkEleLFxxTRZby = 0,
			ysUBTerXXLslxVgKutqevPoAFfv = 1,
			sJPOcWeQfuAuKJhRRoTxtlOZiDh = 2
		}

		private const float PXJcUqbBgjKGgALXGDFfQLbTboCG = 4f;

		private const int wFuDaAjcZJRXwRVbVLebvOVVnWXe = 15;

		private const int eUfLWCfiDZObLbmlRBzChNbEgFwk = 2;

		private const int AzcNxxlLNszWKYIkmsGCusnqpya = 0;

		private const int azzPcSbfHSuywFTlMHBbEKimgEQ = 1912;

		private const int QlKXUvlIeZEawdYZvgeAuGSzTaA = 0;

		private const int pPGrtnQKjDqRSIfWOJqDfacQwrN = 941;

		private const bool LKQTcAFrSDAXWJXVDdgiQlgVbCU = false;

		private const bool NCIdWgohNWLEWPPDANssNoBOdnI = true;

		private const float rEoHkGopYUVpSHXafncJNIvtDJN = 2.5f;

		private const int VmiAmykWyqIGcwnngbzFwehoJEWB = 0;

		private const int PQdKUEjvNVnaixytbOsscPTlYAW = 0;

		private const int adBBoQgCOzLKibTkxLEoWRkjgdV = 1;

		private const int NkgEJkKXlbHKsKksvDBuYuezAuYN = 0;

		private const int PxDUCrxOoLWeDAhMSgjnBJxHJCS = 0;

		private const int RrFvDTmmUmVabBCPSbxUqxMhCWP = 0;

		private const int shtkSStFJOSxsjxOmWclptEyjfo = 1;

		private const int CgJGHMBELSbDPcfRChnDwEmmGXBa = 49;

		private const int uEIgkGlWxmhULYqGBxzHsktRWLZ = 0;

		private const int uyymbaZFRLnDCcDtzVCPLZeCjuU = 1;

		private const int vTcPFlawJucUdPFSBxrbAZuzLMY = 64;

		private const int IjtfrgYTJxCXeehhBDpPbXDkGEHg = 48;

		private const int UeSXnnfZZrqgusamykgYkbvFmTn = 547;

		private const int jMfrFpdGTJAQqGuSpaLPAQbhrpje = 64;

		private const int DwwDAZbXLlGIjIMPwysBlaLWDzZ = 547;

		private const int YSuUhFBbxLfUtbBsEPZEfqxHFBlm = 1;

		private const int boeJhPVjGIhhDzNPDihOehvxRfLI = 2;

		private const int uXWDxbfqAxeoDnhRJYjQvpYOKuJ = 3;

		private const int yQrAAACeRpBCLxMccFzUAWJSVsI = 4;

		private const int OGjGCZhvjnXGapFDotSwNhnyKNNm = 5;

		private const int DcwAQieqbNZUFrXdbgcWaarLeovs = 6;

		private const int RoSebGfNoZGJWOwrYGkQPLfvBECN = 8;

		private const int PlFgdNcSnwSHWVRNTNrCYPmhAHD = 22;

		private const int dDgxvbfXKFVAWRdBXWIMreqMiVs = 16;

		private const int yUafYnhjpiRqKTrezTCTfkwPwUhE = 33;

		private const int ZaVVeZWDAwBdEJjJhtTdvVYlcljK = 8;

		private const int ilHYdSOyRqcKBmbmcpkiZBqFmRF = 9;

		private const int GfcZZjyoWiaNebPDSGsgAdFOESmy = 10;

		private const int wgFdnrzxqcDUZrrKLhSrfJoIgto = 28;

		private const int qsJTjazNtCghABvyvqoueccTaVEz = 54;

		private const int izIaFVLbvjVRaxMeQgJIrnMyHXV = 55;

		private const int viLfDqhnkXXntIIJYDwRcTOaYzd = 54;

		private const bool QXqaaXsVATafvDPWdYmhEKZbbqJ = true;

		private const int lDXyFuOKBVUfqAtVxFSgUzkPzjG = 25;

		private const int FfvuSEtGmZiFmUELarBtbMSJgcC = 3000000;

		private const float CIZjXwEwcCavczYSCXByYWbUsPI = 8192f;

		private const float guBtAjmzCRLdWoHoEjYsgTOvewx = 3.4971635f;

		private const float mjdrfatCWomTexaTyLiSjXvrAKN = 0.06103702f;

		private const bool hymJNULCyDKSEQHYTHEIbzbJNWg = true;

		private const bool LSDnHdaouEiDDpruaEviBZvhmjDs = true;

		private const bool teKZKNUndooJuzyEiAMjKpGbrMz = true;

		private const bool pAbgUnyrXYlqWmhQPkcLmmXrYBl = true;

		private const float ZheccALwNmecaShWRdRmbmyFEco = 4096f;

		private const float oqwdcGtWKxosXIDBzGGJvPdHSNq = 16384f;

		private const float bzCzSUqDpqkwOlGbmfuBwBDbPxJ = 16777216f;

		private const float evyTcejNKZDLCBUwrMPCzxjLyZBM = 268435460f;

		private const float OJWbIvgsZHayILqmISAkvAAehqWc = 0.01999998f;

		private const float DbYILqaSPFVrtJCEtUQlPuNcexT = 8192f;

		private const float GRdAhNRMHNDKIvQzudGpjtavlun = 0.98f;

		private const float HrQUhhapiBijxjpiGEvBBDvcVNTn = 45f;

		private const float slcUxRYivnPQnRpPGOSAkcsJPGX = 20f;

		private const uint CnEULXETVPQRUNMPxjCnBBPwbEI = 3940166985u;

		private readonly bool KkCFcbYtXTEdgmHLXDaDydYkKyW;

		private readonly int FlNOkKgMUJBSGyBJbiEPCOkAXdK;

		private readonly int LtzwDDmxyMitiKporjwdeDaBjtWC;

		private readonly bool RHlnfDoTyfjZuJVlNedcqCoWAybg;

		private readonly byte AXxKxxdrNCociJjMmPAatTdGcjd;

		private readonly int MQTyZZdnoBGyrzLSkxmvwWWEBdg;

		private readonly int eSfZWtEDEtoAoxRSsokSfZVseJW;

		private readonly int OyCokeQhaNYtJplTsfhDJcERBvkE;

		private readonly int KKJggeDIhKHkHsRbvgHLJTFlEgA;

		private readonly int BuxSFlRiRHraGSPzKqZGDxWBWds;

		private readonly int duyEgSWWcLejpJDbWjCmrOHmkkJN;

		private readonly NativeBuffer aeMwQuQlPtdUYawrQqVFIuMiAPdF;

		private readonly NativeBuffer dPxPlSKThGVfgLiEEKYHuvifCBa;

		private OutputReport ivorCZXlhEABpUusmuppDnoRgbCk;

		private readonly Func<OutputReport, bool> MZJGLphQViSbTOKYDaUYCuFBctzd;

		private readonly Action<OutputReport> lBRcRxYTqeMRxCOBUhfkEFojdet;

		private bool haXPdFXCTqGPeitNiiTTazNQsnaE;

		private bool hinjVTYXEwEHkJtZFTMklfScLpA;

		private double SenZkrDVsBqlXCtfGAWUoPeXOlh;

		private byte udCpKHcUvSCutmmTibqqJwPbVLw;

		private bool doNsQFeqELDJeCBCkwGiJcjXttb;

		private bool cdkiyVFFOqWsIHtHRmhYAzLiYpFa;

		private bool vnKcxWoTPsbdYcfpsPgTOdKAORF;

		private Quaternion JivVEqyizcCotmsGrpqQbnbjJiq = Quaternion.identity;

		private DualSenseMicrophoneLightMode hXQMgyKlKTjGMoXJEzGmwtfwepq;

		private RpboJdQsuurtFUZtKhAHmELficy LBnLAPkshAGqswzMmuNuVfvlARH;

		private DualSensePlayerLightFlags KLmORnpVPlNAzfdWSvkGRKaruHw;

		private bool ejPJERYYQqrpSEntWQjfXmuQABBk;

		private bool dBREjfDizUOqWRTqzIUPGzMGSHu;

		private uint uZrgDFdRFvKZwDofdvmeutcnuJBd;

		private float FhWLxVrmjyCNzKQgGOtMxAYBAUOH;

		private double LBWQDQvfDeipSEWKfQICWhGjUCLW;

		private float ogifJVGPAtkgWZQTkJyQuefhbFDQ;

		private byte UEMzZQsirEoHUNNtjcCJHuaHkzS;

		private byte tZjIJTOqjqkUFNULhlJODVMNbsY;

		private Quaternion PIuKgddGZndAQCrJexpqSrEYyrfD = Quaternion.identity;

		private Quaternion YCACTemOkGvBFoCqCurZlycEKQu = Quaternion.identity;

		private bool AMTeDaRWDpLuKwdGhAzPQmPBtQh;

		private int PkRJPDnjTLbGDJWjehyShsqKmwt;

		private int[] HIxedbgFXtFzaFwEqlgKbFoeJTFO = new int[2];

		private int[] wdIeVXzcJxQyQpJSDxJfLanHFVA = new int[2];

		private static uint[] BpqLcvkZPgZKSXAYpRGbiotBVTb = new uint[256]
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
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < base.VibrationMotorCount)
					{
						num2 = -474804883;
						num3 = num2;
					}
					else
					{
						num2 = -474804881;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -474804882)
						{
						case 0:
							num2 = -474804883;
							continue;
						case 3:
							if (vibrationMotors[num].SpeedRaw > 0)
							{
								return true;
							}
							num++;
							num2 = -474804884;
							continue;
						case 2:
							break;
						default:
							return false;
						}
						break;
					}
				}
			}
		}

		public float BatteryLevel
		{
			get
			{
				float value = 0f;
				while (true)
				{
					int num = -390133390;
					while (true)
					{
						switch (num ^ -390133389)
						{
						case 0:
							break;
						case 1:
							if (KkCFcbYtXTEdgmHLXDaDydYkKyW)
							{
								value = (float)(udCpKHcUvSCutmmTibqqJwPbVLw + 2) * 10f;
								num = -390133392;
								continue;
							}
							goto case 2;
						case 2:
							value = (float)(udCpKHcUvSCutmmTibqqJwPbVLw - 1) * 10f;
							num = -390133392;
							continue;
						default:
							return MathTools.Clamp(value, 0f, 100f);
						}
						break;
					}
				}
			}
		}

		public bool BatteryCharging => doNsQFeqELDJeCBCkwGiJcjXttb;

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
				return (int)UEMzZQsirEoHUNNtjcCJHuaHkzS;
			}
			set
			{
				UEMzZQsirEoHUNNtjcCJHuaHkzS = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				haXPdFXCTqGPeitNiiTTazNQsnaE = true;
				if (UEMzZQsirEoHUNNtjcCJHuaHkzS != 0 || tZjIJTOqjqkUFNULhlJODVMNbsY != 0)
				{
					return;
				}
				while (true)
				{
					int num = -70045647;
					while (true)
					{
						switch (num ^ -70045645)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0061;
						case 1:
							return;
						}
						break;
						IL_0061:
						hinjVTYXEwEHkJtZFTMklfScLpA = true;
						num = -70045646;
					}
				}
			}
		}

		public float LightFlashOffDuration
		{
			get
			{
				return (int)tZjIJTOqjqkUFNULhlJODVMNbsY;
			}
			set
			{
				tZjIJTOqjqkUFNULhlJODVMNbsY = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				haXPdFXCTqGPeitNiiTTazNQsnaE = true;
				if (UEMzZQsirEoHUNNtjcCJHuaHkzS == 0 && tZjIJTOqjqkUFNULhlJODVMNbsY == 0)
				{
					hinjVTYXEwEHkJtZFTMklfScLpA = true;
				}
			}
		}

		public DualSenseMicrophoneLightMode microphoneLightMode
		{
			get
			{
				return hXQMgyKlKTjGMoXJEzGmwtfwepq;
			}
			set
			{
				hXQMgyKlKTjGMoXJEzGmwtfwepq = value;
				haXPdFXCTqGPeitNiiTTazNQsnaE = true;
			}
		}

		public DualSenseOtherLightBrightness otherLightBrightness
		{
			get
			{
				return TOspFfAGuzkKuQnWvBleVfLMpgl(LBnLAPkshAGqswzMmuNuVfvlARH);
			}
			set
			{
				LBnLAPkshAGqswzMmuNuVfvlARH = QhuWTkDrfosgvVrQCTvfIQyFmsn(value);
				haXPdFXCTqGPeitNiiTTazNQsnaE = true;
			}
		}

		public DualSensePlayerLightFlags playerLights
		{
			get
			{
				return KLmORnpVPlNAzfdWSvkGRKaruHw;
			}
			set
			{
				KLmORnpVPlNAzfdWSvkGRKaruHw = value;
				haXPdFXCTqGPeitNiiTTazNQsnaE = true;
			}
		}

		public Vector3 AccelerometerValue => aCWFOONWkvMWdrhoSKZhhnIcKWd(accelerometers[0].rawValue);

		public Vector3 AccelerometerValueRaw => new Vector3(accelerometers[0].rawValue[0], accelerometers[0].rawValue[1], accelerometers[0].rawValue[2]);

		public Vector3 GyroscopeValue => uLMyabGBmnAWfBQCjiYaouiwlTdk(gyroscopes[0].events);

		public Vector3 GyroscopeValueRaw => new Vector3(gyroscopes[0].rawValue[0], gyroscopes[0].rawValue[1], gyroscopes[0].rawValue[2]);

		public Vector3 LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);
				return uLMyabGBmnAWfBQCjiYaouiwlTdk(vector, FhWLxVrmjyCNzKQgGOtMxAYBAUOH);
			}
		}

		public Vector3 LastGyroscopeValueRaw => new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);

		public Quaternion Orientation => JivVEqyizcCotmsGrpqQbnbjJiq;

		public int MaxTouches => 2;

		public void ResetOrientation()
		{
			JivVEqyizcCotmsGrpqQbnbjJiq = Quaternion.identity;
			AMTeDaRWDpLuKwdGhAzPQmPBtQh = false;
		}

		public int GetTouchCount()
		{
			int num = 0;
			int num2 = 0;
			while (num2 < 2)
			{
				while (true)
				{
					int num3;
					if (touchpads[0].values[num2].isTouching)
					{
						num++;
						num3 = 1684096592;
						goto IL_000b;
					}
					goto IL_004d;
					IL_000b:
					while (true)
					{
						switch (num3 ^ 0x64614652)
						{
						case 3:
							num3 = 1684096595;
							continue;
						case 1:
							break;
						case 2:
							goto IL_004d;
						default:
							goto end_IL_0028;
						}
						break;
					}
					continue;
					IL_004d:
					num2++;
					num3 = 1684096594;
					goto IL_000b;
					continue;
					end_IL_0028:
					break;
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
			if (index >= 0)
			{
				while (true)
				{
					int num = 893241229;
					while (true)
					{
						switch (num ^ 0x353DC78F)
						{
						case 0:
							break;
						case 2:
							goto IL_0022;
						default:
							goto end_IL_0004;
						}
						break;
						IL_0022:
						if (index >= 2)
						{
							num = 893241230;
							continue;
						}
						return touchpads[0].values[index].touchId;
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			return -1;
		}

		public bool GetTouchPositionByIndex(int index, out Vector2 position)
		{
			position = default(Vector2);
			if (index >= 0)
			{
				while (true)
				{
					int num = -356153556;
					while (true)
					{
						switch (num ^ -356153554)
						{
						case 0:
							break;
						case 2:
							goto IL_002d;
						case 1:
							goto end_IL_000b;
						default:
							return true;
						}
						break;
						IL_002d:
						if (index >= 2)
						{
							num = -356153553;
							continue;
						}
						HIDTouchpad.TouchData[] values = touchpads[0].values;
						if (!values[index].isTouching)
						{
							return false;
						}
						position.x = values[index].positionX;
						position.y = values[index].positionY;
						num = -356153555;
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			return false;
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			position = default(Vector2);
			if (!touchpads[0].IsTouching(touchId))
			{
				goto IL_0017;
			}
			HIDTouchpad.TouchData[] values = touchpads[0].values;
			int num = 0;
			int num2 = -2021910310;
			goto IL_001c;
			IL_001c:
			while (true)
			{
				switch (num2 ^ -2021910311)
				{
				case 5:
					break;
				case 4:
					position.x = values[num].positionX;
					position.y = values[num].positionY;
					num2 = -2021910311;
					continue;
				case 0:
					num++;
					num2 = -2021910310;
					continue;
				case 1:
					return false;
				case 2:
				{
					int num3;
					if (!values[num].isTouching)
					{
						num2 = -2021910311;
						num3 = num2;
					}
					else
					{
						num2 = -2021910307;
						num3 = num2;
					}
					continue;
				}
				default:
					if (num >= values.Length)
					{
						return true;
					}
					goto case 2;
				}
				break;
			}
			goto IL_0017;
			IL_0017:
			num2 = -2021910312;
			goto IL_001c;
		}

		public bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			HIDTouchpad.TouchData[] values = default(HIDTouchpad.TouchData[]);
			int num;
			if (index >= 0)
			{
				if (index >= 2)
				{
					goto IL_000e;
				}
				values = touchpads[0].values;
				if (!values[index].isTouching)
				{
					return false;
				}
				positionX = values[index].positionAbsX;
				num = 567829820;
				goto IL_0013;
			}
			goto IL_0030;
			IL_0013:
			while (true)
			{
				switch (num ^ 0x21D8653C)
				{
				case 2:
					break;
				case 3:
					goto IL_0030;
				case 0:
					positionY = values[index].positionAbsY;
					num = 567829821;
					continue;
				default:
					return true;
				}
				break;
			}
			goto IL_000e;
			IL_000e:
			num = 567829823;
			goto IL_0013;
			IL_0030:
			return false;
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			HIDTouchpad.TouchData[] values = default(HIDTouchpad.TouchData[]);
			int num2 = default(int);
			while (true)
			{
				int num = -974749331;
				while (true)
				{
					switch (num ^ -974749334)
					{
					case 4:
						break;
					case 2:
					{
						int num4;
						if (values[num2].isTouching)
						{
							num = -974749334;
							num4 = num;
						}
						else
						{
							num = -974749335;
							num4 = num;
						}
						continue;
					}
					case 5:
						num = -974749333;
						continue;
					case 0:
						positionX = values[num2].positionAbsX;
						positionY = values[num2].positionAbsY;
						num = -974749335;
						continue;
					case 7:
						if (!touchpads[0].IsTouching(touchId))
						{
							num = -974749342;
							continue;
						}
						values = touchpads[0].values;
						num2 = 0;
						num = -974749329;
						continue;
					case 1:
					{
						int num3;
						if (num2 < values.Length)
						{
							num = -974749336;
							num3 = num;
						}
						else
						{
							num = -974749332;
							num3 = num;
						}
						continue;
					}
					case 3:
						num2++;
						num = -974749333;
						continue;
					case 8:
						return false;
					default:
						return true;
					}
					break;
				}
			}
		}

		public void StopLightFlash()
		{
			UEMzZQsirEoHUNNtjcCJHuaHkzS = 0;
			tZjIJTOqjqkUFNULhlJODVMNbsY = 0;
			haXPdFXCTqGPeitNiiTTazNQsnaE = true;
			hinjVTYXEwEHkJtZFTMklfScLpA = true;
		}

		public void StopVibration()
		{
			int vibrationMotorCount = base.VibrationMotorCount;
			int num = 0;
			while (true)
			{
				int num2 = -1104036150;
				while (true)
				{
					switch (num2 ^ -1104036149)
					{
					case 3:
						break;
					case 1:
						num2 = -1104036151;
						continue;
					case 4:
						vibrationMotors[num].SpeedRaw = 0;
						num2 = -1104036149;
						continue;
					case 0:
						num++;
						num2 = -1104036151;
						continue;
					default:
						if (num >= vibrationMotorCount)
						{
							return;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public DualSenseDriver(InitArgs initArgs)
		{
			if (initArgs == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			FlNOkKgMUJBSGyBJbiEPCOkAXdK = initArgs.hatZeroValue;
			LtzwDDmxyMitiKporjwdeDaBjtWC = initArgs.hatSpan;
			MQTyZZdnoBGyrzLSkxmvwWWEBdg = initArgs.inputReportLength;
			eSfZWtEDEtoAoxRSsokSfZVseJW = initArgs.outputReportLength;
			MZJGLphQViSbTOKYDaUYCuFBctzd = initArgs.synchronousWriteOutputReportDelegate;
			lBRcRxYTqeMRxCOBUhfkEFojdet = initArgs.asynchronousWriteOutputReportDelegate;
			KkCFcbYtXTEdgmHLXDaDydYkKyW = initArgs.connectionType == DeviceConnectionType.sFJAQBfZHNpXaWTCudNqcxaaCMg;
			if (KkCFcbYtXTEdgmHLXDaDydYkKyW)
			{
				eSfZWtEDEtoAoxRSsokSfZVseJW = 547;
			}
			else
			{
				eSfZWtEDEtoAoxRSsokSfZVseJW = 48;
			}
			aeMwQuQlPtdUYawrQqVFIuMiAPdF = new NativeBuffer(64);
			dPxPlSKThGVfgLiEEKYHuvifCBa = new NativeBuffer(eSfZWtEDEtoAoxRSsokSfZVseJW);
			ivorCZXlhEABpUusmuppDnoRgbCk = new OutputReport(dPxPlSKThGVfgLiEEKYHuvifCBa.Pointer, dPxPlSKThGVfgLiEEKYHuvifCBa.Length, eSfZWtEDEtoAoxRSsokSfZVseJW);
			lights = new HIDLight[1]
			{
				new HIDLight(11, 24, 28)
			};
			lights[0].ValueChangedEvent += SDGOlaqcBukiLszYmIncLPdbTOY;
			vibrationMotors = new HIDVibrationMotor[2]
			{
				new HIDVibrationMotor(0, 255),
				new HIDVibrationMotor(0, 255)
			};
			vibrationMotors[0].ValueChangedEvent += SDGOlaqcBukiLszYmIncLPdbTOY;
			vibrationMotors[1].ValueChangedEvent += SDGOlaqcBukiLszYmIncLPdbTOY;
			if (KkCFcbYtXTEdgmHLXDaDydYkKyW)
			{
				byte[] array = initArgs.getFeatureReportDelegate(5);
				RHlnfDoTyfjZuJVlNedcqCoWAybg = array != null && array.Length > 0;
				if (RHlnfDoTyfjZuJVlNedcqCoWAybg)
				{
					YYoOzKqMeRqjkohwLimEuhYIMWt(WrVEVdhmDaiEyYHhLCqAumPxnFYB.pMrzmpQUTveEXenRCeQwcuyDgaOd);
				}
			}
			else
			{
				RHlnfDoTyfjZuJVlNedcqCoWAybg = true;
				RHlnfDoTyfjZuJVlNedcqCoWAybg = YYoOzKqMeRqjkohwLimEuhYIMWt(WrVEVdhmDaiEyYHhLCqAumPxnFYB.pMrzmpQUTveEXenRCeQwcuyDgaOd);
			}
			if (!RHlnfDoTyfjZuJVlNedcqCoWAybg)
			{
				throw new Exception("Special features not supported so just treat this as a standard HID device.");
			}
			AXxKxxdrNCociJjMmPAatTdGcjd = 1;
			OyCokeQhaNYtJplTsfhDJcERBvkE = 0;
			if (KkCFcbYtXTEdgmHLXDaDydYkKyW && RHlnfDoTyfjZuJVlNedcqCoWAybg)
			{
				AXxKxxdrNCociJjMmPAatTdGcjd = 49;
				OyCokeQhaNYtJplTsfhDJcERBvkE = 1;
			}
			KKJggeDIhKHkHsRbvgHLJTFlEgA = 8 + OyCokeQhaNYtJplTsfhDJcERBvkE;
			BuxSFlRiRHraGSPzKqZGDxWBWds = 9 + OyCokeQhaNYtJplTsfhDJcERBvkE;
			duyEgSWWcLejpJDbWjCmrOHmkkJN = 10 + OyCokeQhaNYtJplTsfhDJcERBvkE;
			buttons = new HIDButton[15];
			for (int i = 0; i < 15; i++)
			{
				buttons[i] = new HIDButton(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new HIDAxis[6]
			{
				new HIDAxis(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + OyCokeQhaNYtJplTsfhDJcERBvkE,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 127),
				new HIDAxis(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + OyCokeQhaNYtJplTsfhDJcERBvkE,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 127),
				new HIDAxis(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + OyCokeQhaNYtJplTsfhDJcERBvkE,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 127),
				new HIDAxis(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + OyCokeQhaNYtJplTsfhDJcERBvkE,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 127),
				new HIDAxis(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 5 + OyCokeQhaNYtJplTsfhDJcERBvkE,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, isSigned: false, 0),
				new HIDAxis(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 6 + OyCokeQhaNYtJplTsfhDJcERBvkE,
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
				new HIDHat(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 8 + OyCokeQhaNYtJplTsfhDJcERBvkE,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, CALdyVNfdFifKktknTAsimkzRSh)
			};
			accelerometers = new HIDAccelerometer[1]
			{
				new HIDAccelerometer(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 22 + OyCokeQhaNYtJplTsfhDJcERBvkE,
					bitSize = 48
				}, 3, KthLgsyLIFfjuYoErgaPjHPcaRvM)
			};
			gyroscopes = new HIDGyroscope[1]
			{
				new HIDGyroscope(initArgs.updateLoopSetting, AXxKxxdrNCociJjMmPAatTdGcjd, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 16 + OyCokeQhaNYtJplTsfhDJcERBvkE,
					bitSize = 48
				}, 3, 25, PJeOizZvjtEYWAKATipWSDVSDQK, InnQpHFaiePFZBOHkFqvNhUWIeV)
			};
			touchpads = new HIDTouchpad[1]
			{
				new HIDTouchpad(AXxKxxdrNCociJjMmPAatTdGcjd, new HIDTouchpad.TouchpadInfo(2, 0, 1912, 0, 941, invertY: false, reverseY: true), new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 33 + OyCokeQhaNYtJplTsfhDJcERBvkE,
					bitSize = 48
				}, VsjZzRNXJlTxcWqumEeJIUONkGY)
			};
			LBWQDQvfDeipSEWKfQICWhGjUCLW = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			jnPCjFfFDIflBYxOEUXHijiiZhM();
			gUULrqWdUNszJmicQQSwsanKBVW(WrVEVdhmDaiEyYHhLCqAumPxnFYB.RxDhwKbqppIzkwYthdHdClWgNNR);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < aeMwQuQlPtdUYawrQqVFIuMiAPdF.Length)
			{
				goto IL_0020;
			}
			ogifJVGPAtkgWZQTkJyQuefhbFDQ = (float)(timestamp - LBWQDQvfDeipSEWKfQICWhGjUCLW);
			LBWQDQvfDeipSEWKfQICWhGjUCLW = timestamp;
			int num = 343067825;
			goto IL_0025;
			IL_0025:
			while (true)
			{
				switch (num ^ 0x1472CCB3)
				{
				case 5:
					break;
				case 4:
					kvQGJWTjqgbANQTVFodBLNgClXv(aeMwQuQlPtdUYawrQqVFIuMiAPdF);
					nLotdmIEnGDlRjnDZLzPFXYmCSSJ(aeMwQuQlPtdUYawrQqVFIuMiAPdF, timestamp);
					num = 343067829;
					continue;
				case 2:
					aeMwQuQlPtdUYawrQqVFIuMiAPdF.Write(inputReportPtr, inputReportLength, aeMwQuQlPtdUYawrQqVFIuMiAPdF.Length);
					num = 343067831;
					continue;
				case 0:
					vnKcxWoTPsbdYcfpsPgTOdKAORF = (aeMwQuQlPtdUYawrQqVFIuMiAPdF[54 + OyCokeQhaNYtJplTsfhDJcERBvkE] & 1) != 0;
					num = 343067826;
					continue;
				case 3:
					RVgcSVBpQMbLHYUtIUJCVyTtCbz(accelerometers, aeMwQuQlPtdUYawrQqVFIuMiAPdF, timestamp);
					RVgcSVBpQMbLHYUtIUJCVyTtCbz(gyroscopes, aeMwQuQlPtdUYawrQqVFIuMiAPdF, timestamp);
					RVgcSVBpQMbLHYUtIUJCVyTtCbz(touchpads, aeMwQuQlPtdUYawrQqVFIuMiAPdF, timestamp);
					doNsQFeqELDJeCBCkwGiJcjXttb = (aeMwQuQlPtdUYawrQqVFIuMiAPdF[54 + OyCokeQhaNYtJplTsfhDJcERBvkE] & 8) != 0;
					cdkiyVFFOqWsIHtHRmhYAzLiYpFa = (aeMwQuQlPtdUYawrQqVFIuMiAPdF[55 + OyCokeQhaNYtJplTsfhDJcERBvkE] & 0x20) != 0;
					udCpKHcUvSCutmmTibqqJwPbVLw = (byte)(aeMwQuQlPtdUYawrQqVFIuMiAPdF[55 + OyCokeQhaNYtJplTsfhDJcERBvkE] & 0xF);
					num = 343067827;
					continue;
				case 7:
					return false;
				case 6:
					RVgcSVBpQMbLHYUtIUJCVyTtCbz(axes, aeMwQuQlPtdUYawrQqVFIuMiAPdF, timestamp);
					RVgcSVBpQMbLHYUtIUJCVyTtCbz(hats, aeMwQuQlPtdUYawrQqVFIuMiAPdF, timestamp);
					num = 343067824;
					continue;
				default:
					gBPjaFBjPZdeMcCvoTuCxIghdSSe();
					return true;
				}
				break;
			}
			goto IL_0020;
			IL_0020:
			num = 343067828;
			goto IL_0025;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualSenseExtension(this);
		}

		private void gUULrqWdUNszJmicQQSwsanKBVW(WrVEVdhmDaiEyYHhLCqAumPxnFYB P_0)
		{
			if (!haXPdFXCTqGPeitNiiTTazNQsnaE)
			{
				return;
			}
			while (true)
			{
				YYoOzKqMeRqjkohwLimEuhYIMWt(P_0);
				int num = -163240231;
				while (true)
				{
					switch (num ^ -163240232)
					{
					case 0:
						goto IL_0009;
					case 2:
						break;
					default:
						haXPdFXCTqGPeitNiiTTazNQsnaE = false;
						return;
					}
					break;
					IL_0009:
					num = -163240230;
				}
			}
		}

		private bool YYoOzKqMeRqjkohwLimEuhYIMWt(WrVEVdhmDaiEyYHhLCqAumPxnFYB P_0)
		{
			hZiLtvTVSJEJKwVGdTRXbyAeDjI();
			bool result = OIUXarAwCISOJRuamQlSzTKmqCq(P_0);
			while (true)
			{
				int num = -2094666554;
				while (true)
				{
					switch (num ^ -2094666556)
					{
					case 0:
						break;
					case 2:
						if (hinjVTYXEwEHkJtZFTMklfScLpA)
						{
							goto IL_0034;
						}
						goto default;
					default:
						return result;
					}
					break;
					IL_0034:
					result = OIUXarAwCISOJRuamQlSzTKmqCq(P_0);
					hinjVTYXEwEHkJtZFTMklfScLpA = false;
					num = -2094666555;
				}
			}
		}

		private void hZiLtvTVSJEJKwVGdTRXbyAeDjI()
		{
			if (KkCFcbYtXTEdgmHLXDaDydYkKyW && RHlnfDoTyfjZuJVlNedcqCoWAybg)
			{
				goto IL_0010;
			}
			goto IL_0039;
			IL_0039:
			dPxPlSKThGVfgLiEEKYHuvifCBa[0] = 2;
			int num = -1691834943;
			goto IL_0015;
			IL_0010:
			num = -1691834944;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ -1691834942)
				{
				case 0:
					break;
				case 4:
					goto IL_0039;
				case 1:
				{
					hZiLtvTVSJEJKwVGdTRXbyAeDjI(dPxPlSKThGVfgLiEEKYHuvifCBa, 2);
					uint num2 = xliXGKGeEQkVQhengrEtnSQSGXJ(dPxPlSKThGVfgLiEEKYHuvifCBa, 74);
					dPxPlSKThGVfgLiEEKYHuvifCBa[74] = (byte)(num2 & 0xFF);
					dPxPlSKThGVfgLiEEKYHuvifCBa[75] = (byte)((num2 & 0xFF00) >> 8);
					dPxPlSKThGVfgLiEEKYHuvifCBa[76] = (byte)((num2 & 0xFF0000) >> 16);
					dPxPlSKThGVfgLiEEKYHuvifCBa[77] = (byte)((num2 & 0xFF000000u) >> 24);
					return;
				}
				case 2:
					dPxPlSKThGVfgLiEEKYHuvifCBa[0] = 49;
					dPxPlSKThGVfgLiEEKYHuvifCBa[1] = 2;
					num = -1691834941;
					continue;
				default:
					hZiLtvTVSJEJKwVGdTRXbyAeDjI(dPxPlSKThGVfgLiEEKYHuvifCBa, 1);
					return;
				}
				break;
			}
			goto IL_0010;
		}

		private void hZiLtvTVSJEJKwVGdTRXbyAeDjI(NativeBuffer P_0, int P_1)
		{
			P_0[P_1] = byte.MaxValue;
			P_0[1 + P_1] = 247;
			P_0[2 + P_1] = (byte)vibrationMotors[1].SpeedRaw;
			P_0[3 + P_1] = (byte)vibrationMotors[0].SpeedRaw;
			P_0[8 + P_1] = (byte)hXQMgyKlKTjGMoXJEzGmwtfwepq;
			while (true)
			{
				int num = -946102664;
				while (true)
				{
					switch (num ^ -946102663)
					{
					case 7:
						break;
					case 8:
						P_0[42 + P_1] = (byte)LBnLAPkshAGqswzMmuNuVfvlARH;
						num = -946102659;
						continue;
					case 6:
						if (ejPJERYYQqrpSEntWQjfXmuQABBk)
						{
							P_0[43 + P_1] = (byte)(P_0[43 + P_1] & -33);
							num = -946102663;
							continue;
						}
						goto case 3;
					case 0:
						P_0[38 + P_1] = 3;
						num = -946102660;
						continue;
					case 5:
						P_0[41 + P_1] = (byte)(dBREjfDizUOqWRTqzIUPGzMGSHu ? 1 : 2);
						num = -946102671;
						continue;
					case 1:
						P_0[43 + P_1] = (byte)KLmORnpVPlNAzfdWSvkGRKaruHw;
						num = -946102657;
						continue;
					case 4:
						P_0[44 + P_1] = lights[0].ColorRRaw;
						num = -946102661;
						continue;
					case 3:
						P_0[43 + P_1] |= 32;
						num = -946102663;
						continue;
					default:
						P_0[45 + P_1] = lights[0].ColorGRaw;
						P_0[46 + P_1] = lights[0].ColorBRaw;
						return;
					}
					break;
				}
			}
		}

		private bool OIUXarAwCISOJRuamQlSzTKmqCq(WrVEVdhmDaiEyYHhLCqAumPxnFYB P_0)
		{
			SenZkrDVsBqlXCtfGAWUoPeXOlh = ReInput.realTime + 4.0;
			bool result = default(bool);
			int num;
			if (P_0 == WrVEVdhmDaiEyYHhLCqAumPxnFYB.pMrzmpQUTveEXenRCeQwcuyDgaOd)
			{
				if (MZJGLphQViSbTOKYDaUYCuFBctzd == null)
				{
					goto IL_0020;
				}
				result = MZJGLphQViSbTOKYDaUYCuFBctzd(ivorCZXlhEABpUusmuppDnoRgbCk);
				num = -1851335489;
			}
			else
			{
				if (P_0 != WrVEVdhmDaiEyYHhLCqAumPxnFYB.RxDhwKbqppIzkwYthdHdClWgNNR)
				{
					throw new NotImplementedException();
				}
				num = -1851335491;
			}
			goto IL_0025;
			IL_0020:
			num = -1851335492;
			goto IL_0025;
			IL_0025:
			while (true)
			{
				switch (num ^ -1851335490)
				{
				case 4:
					break;
				case 2:
					return false;
				case 1:
					return result;
				case 3:
					if (lBRcRxYTqeMRxCOBUhfkEFojdet == null)
					{
						goto IL_0076;
					}
					lBRcRxYTqeMRxCOBUhfkEFojdet(ivorCZXlhEABpUusmuppDnoRgbCk);
					return true;
				default:
					return false;
				}
				break;
				IL_0076:
				num = -1851335490;
			}
			goto IL_0020;
		}

		private void nLotdmIEnGDlRjnDZLzPFXYmCSSJ(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[KKJggeDIhKHkHsRbvgHLJTFlEgA];
			while (true)
			{
				int num = 1757791658;
				while (true)
				{
					switch (num ^ 0x68C5C5AB)
					{
					case 4:
						break;
					default:
						return;
					case 3:
						buttons[12].SetValue((b & 1) != 0, P_1);
						buttons[13].SetValue((b & 2) != 0, P_1);
						num = 1757791660;
						continue;
					case 7:
					{
						int num2;
						if (!RHlnfDoTyfjZuJVlNedcqCoWAybg)
						{
							num = 1757791661;
							num2 = num;
						}
						else
						{
							num = 1757791657;
							num2 = num;
						}
						continue;
					}
					case 0:
						buttons[11].SetValue((b & 0x80) != 0, P_1);
						b = P_0[duyEgSWWcLejpJDbWjCmrOHmkkJN];
						num = 1757791656;
						continue;
					case 1:
						buttons[0].SetValue((b & 0x10) != 0, P_1);
						buttons[1].SetValue((b & 0x20) != 0, P_1);
						buttons[2].SetValue((b & 0x40) != 0, P_1);
						buttons[3].SetValue((b & 0x80) != 0, P_1);
						b = P_0[BuxSFlRiRHraGSPzKqZGDxWBWds];
						buttons[4].SetValue((b & 1) != 0, P_1);
						buttons[5].SetValue((b & 2) != 0, P_1);
						buttons[6].SetValue((b & 4) != 0, P_1);
						num = 1757791662;
						continue;
					case 5:
						buttons[7].SetValue((b & 8) != 0, P_1);
						buttons[8].SetValue((b & 0x10) != 0, P_1);
						buttons[9].SetValue((b & 0x20) != 0, P_1);
						buttons[10].SetValue((b & 0x40) != 0, P_1);
						num = 1757791659;
						continue;
					case 2:
						buttons[14].SetValue((b & 4) != 0, P_1);
						num = 1757791661;
						continue;
					case 6:
						return;
					}
					break;
				}
			}
		}

		private void RVgcSVBpQMbLHYUtIUJCVyTtCbz(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
		{
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < P_0.Length)
				{
					num2 = 908649261;
					num3 = num2;
				}
				else
				{
					num2 = 908649260;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x3628E32F)
					{
					case 0:
						num2 = 908649261;
						continue;
					default:
						return;
					case 2:
						P_0[num].UpdateValue(P_1, P_2);
						num++;
						num2 = 908649262;
						continue;
					case 1:
						break;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void jnPCjFfFDIflBYxOEUXHijiiZhM()
		{
			if (!isVibrating || !(ReInput.realTime >= SenZkrDVsBqlXCtfGAWUoPeXOlh))
			{
				return;
			}
			while (true)
			{
				int num = 94872197;
				while (true)
				{
					switch (num ^ 0x5A7A284)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0033;
					case 0:
						return;
					}
					break;
					IL_0033:
					haXPdFXCTqGPeitNiiTTazNQsnaE = true;
					num = 94872196;
				}
			}
		}

		private void kvQGJWTjqgbANQTVFodBLNgClXv(NativeBuffer P_0)
		{
			if (!RHlnfDoTyfjZuJVlNedcqCoWAybg)
			{
				return;
			}
			uint num4 = default(uint);
			float fhWLxVrmjyCNzKQgGOtMxAYBAUOH = default(float);
			while (true)
			{
				uint num = aeMwQuQlPtdUYawrQqVFIuMiAPdF.ReadUInt(28 + OyCokeQhaNYtJplTsfhDJcERBvkE);
				int num2;
				int num3;
				if (num == uZrgDFdRFvKZwDofdvmeutcnuJBd)
				{
					num2 = 1660522818;
					num3 = num2;
				}
				else
				{
					num2 = 1660522817;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x62F99143)
					{
					case 0:
						num2 = 1660522823;
						continue;
					case 1:
						num4 = 0u;
						fhWLxVrmjyCNzKQgGOtMxAYBAUOH = 0f;
						num2 = 1660522816;
						continue;
					case 6:
						num2 = 1660522822;
						continue;
					case 2:
						if (num < uZrgDFdRFvKZwDofdvmeutcnuJBd)
						{
							num4 = (uint)((long)num + 4294967295L - uZrgDFdRFvKZwDofdvmeutcnuJBd);
							num2 = 1660522821;
							continue;
						}
						goto case 7;
					case 5:
						fhWLxVrmjyCNzKQgGOtMxAYBAUOH = (float)num4 / 3000000f;
						num2 = 1660522816;
						continue;
					case 4:
						break;
					case 7:
						num4 = num - uZrgDFdRFvKZwDofdvmeutcnuJBd;
						num2 = 1660522822;
						continue;
					default:
						uZrgDFdRFvKZwDofdvmeutcnuJBd = num;
						FhWLxVrmjyCNzKQgGOtMxAYBAUOH = fhWLxVrmjyCNzKQgGOtMxAYBAUOH;
						return;
					}
					break;
				}
			}
		}

		private void gBPjaFBjPZdeMcCvoTuCxIghdSSe()
		{
			if (!RHlnfDoTyfjZuJVlNedcqCoWAybg)
			{
				return;
			}
			while (!(FhWLxVrmjyCNzKQgGOtMxAYBAUOH <= 0f))
			{
				while (true)
				{
					IL_0040:
					Vector3 vector = uLMyabGBmnAWfBQCjiYaouiwlTdk(new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]), FhWLxVrmjyCNzKQgGOtMxAYBAUOH);
					int num = 1064041787;
					while (true)
					{
						switch (num ^ 0x3F6BFD3A)
						{
						case 0:
							num = 1064041784;
							continue;
						case 2:
							break;
						case 3:
							goto IL_0040;
						default:
						{
							XoOTfbBvSuqPGnhhQqeYTWRcKHb(ref vector);
							Vector3 vector2 = new Vector3(accelerometers[0].rawValue[0] * -1f, accelerometers[0].rawValue[1] * -1f, accelerometers[0].rawValue[2] * -1f);
							hvpViggNofQDCHeEBVtNSdydkjZ(vector2, vector);
							return;
						}
						}
						break;
					}
					break;
				}
			}
		}

		private static bool XoOTfbBvSuqPGnhhQqeYTWRcKHb(ref Vector3 P_0)
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

		private void hvpViggNofQDCHeEBVtNSdydkjZ(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f)
			{
				goto IL_0025;
			}
			goto IL_01f7;
			IL_01f7:
			JivVEqyizcCotmsGrpqQbnbjJiq *= quaternion;
			int num;
			if (AMTeDaRWDpLuKwdGhAzPQmPBtQh)
			{
				AMTeDaRWDpLuKwdGhAzPQmPBtQh = false;
				num = 239611288;
				goto IL_002a;
			}
			return;
			IL_0025:
			num = 239611283;
			goto IL_002a;
			IL_002a:
			AQgJEkcAsNUPiFMXRfZIyXrJdCE aQgJEkcAsNUPiFMXRfZIyXrJdCE = default(AQgJEkcAsNUPiFMXRfZIyXrJdCE);
			Quaternion a = default(Quaternion);
			Quaternion quaternion2 = default(Quaternion);
			while (true)
			{
				switch (num ^ 0xE482D92)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					if (IhKFGIImEfUjYmbBnztJgunlbbgf(P_0, out aQgJEkcAsNUPiFMXRfZIyXrJdCE))
					{
						a = JivVEqyizcCotmsGrpqQbnbjJiq * quaternion;
						num = 239611294;
						continue;
					}
					goto IL_01f7;
				case 11:
					JivVEqyizcCotmsGrpqQbnbjJiq = Quaternion.Lerp(a, quaternion2, 0.01999998f);
					return;
				case 13:
				{
					Vector3 vector = YCACTemOkGvBFoCqCurZlycEKQu * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					quaternion2 = Quaternion.Euler(0f, y, 0f) * quaternion2;
					num = 239611286;
					continue;
				}
				case 3:
					PIuKgddGZndAQCrJexpqSrEYyrfD *= quaternion;
					num = 239611285;
					continue;
				case 9:
					quaternion2 = Quaternion.identity;
					num = 239611289;
					continue;
				case 4:
					num = 239611289;
					continue;
				case 7:
					YCACTemOkGvBFoCqCurZlycEKQu *= quaternion;
					if ((aQgJEkcAsNUPiFMXRfZIyXrJdCE & AQgJEkcAsNUPiFMXRfZIyXrJdCE.vXOaLwhTyAhDMnOWhkrgxQfUpQAN) != AQgJEkcAsNUPiFMXRfZIyXrJdCE.XHUTYEIfTgeCBgXrVRVbPfGzuhN)
					{
						quaternion2 = trsUiauIhmiEvWDlOpBCohoKTWC(P_0, a.eulerAngles.y);
						num = 239611287;
						continue;
					}
					goto case 2;
				case 2:
					if ((aQgJEkcAsNUPiFMXRfZIyXrJdCE & AQgJEkcAsNUPiFMXRfZIyXrJdCE.BHthfyenUmQSDsNqbVwGsEfPHjqb) != AQgJEkcAsNUPiFMXRfZIyXrJdCE.XHUTYEIfTgeCBgXrVRVbPfGzuhN)
					{
						quaternion2 = mCXxDIqaPNYcEtgJSeEPewzKriV(P_0);
						num = 239611295;
						continue;
					}
					goto case 9;
				case 12:
					if (!AMTeDaRWDpLuKwdGhAzPQmPBtQh)
					{
						AMTeDaRWDpLuKwdGhAzPQmPBtQh = true;
						PIuKgddGZndAQCrJexpqSrEYyrfD = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
						num = 239611290;
						continue;
					}
					goto case 3;
				case 8:
					YCACTemOkGvBFoCqCurZlycEKQu = JivVEqyizcCotmsGrpqQbnbjJiq;
					num = 239611281;
					continue;
				case 6:
					goto IL_01f7;
				case 5:
					num = 239611289;
					continue;
				case 10:
					return;
				}
				break;
			}
			goto IL_0025;
		}

		private static Quaternion GqOEiFUzrmKCyokIzwkJKHQTnHy(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = new Vector3(P_0.x, P_0.y, P_0.z);
			Vector3 vector2 = kLWuTtKpvxZIytcJnVJmpNqejZg(vector, P_1);
			return new Quaternion(vector2.x, vector2.y, vector2.z, P_0.w);
		}

		private static Vector3 kLWuTtKpvxZIytcJnVJmpNqejZg(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion EPoldXYCScKuluPrKZxdGRjCHed(Quaternion P_0, CNJTofPyWMYALZCGbMFQoucyQen P_1)
		{
			Vector4 vector = default(Vector4);
			while (true)
			{
				int num = -1715032343;
				while (true)
				{
					switch (num ^ -1715032342)
					{
					case 5:
						break;
					case 3:
						if (MathTools.Approximately(P_0.w, 0f))
						{
							int num2;
							if (!MathTools.Approximately(P_0[(int)P_1], 0f))
							{
								num = -1715032344;
								num2 = num;
							}
							else
							{
								num = -1715032341;
								num2 = num;
							}
							continue;
						}
						goto case 2;
					case 2:
					{
						float num3 = P_0[(int)P_1];
						float num4 = MathTools.Sqrt(P_0.w * P_0.w + num3 * num3);
						vector[3] = P_0.w / num4;
						vector[(int)P_1] = num3 / num4;
						num = -1715032338;
						continue;
					}
					case 1:
						P_0 = Quaternion.identity;
						num = -1715032342;
						continue;
					case 4:
						P_0 = new Quaternion(vector[0], vector[1], vector[2], vector[3]);
						num = -1715032342;
						continue;
					default:
						return P_0;
					}
					break;
				}
			}
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			float num = quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z + quaternion.w * quaternion.w;
			float num3 = default(float);
			Quaternion result = default(Quaternion);
			while (true)
			{
				int num2 = -1971095834;
				while (true)
				{
					switch (num2 ^ -1971095836)
					{
					case 0:
						break;
					case 2:
						num3 = 1f / num;
						result.x = (0f - quaternion.x) * num3;
						num2 = -1971095835;
						continue;
					case 1:
						result.y = (0f - quaternion.y) * num3;
						num2 = -1971095833;
						continue;
					default:
						result.z = (0f - quaternion.z) * num3;
						result.w = quaternion.w * num3;
						return result;
					}
					break;
				}
			}
		}

		private float uadLKdJzArgZdadKpFEjcSShEnIE(float P_0, float P_1)
		{
			P_0 = MathTools.ClampAngle360(P_0);
			P_1 = MathTools.ClampAngle360(P_1);
			if (P_0 == P_1)
			{
				goto IL_0014;
			}
			int num;
			int num2;
			if (P_0 >= 180f)
			{
				num = 698130807;
				num2 = num;
			}
			else
			{
				num = 698130802;
				num2 = num;
			}
			goto IL_0019;
			IL_0014:
			num = 698130801;
			goto IL_0019;
			IL_0019:
			while (true)
			{
				switch (num ^ 0x299CA173)
				{
				case 0:
					break;
				case 2:
					return 0f;
				case 1:
					if (P_1 >= 180f)
					{
						P_1 -= 360f;
						num = 698130800;
						continue;
					}
					goto default;
				case 4:
					P_0 -= 360f;
					num = 698130802;
					continue;
				default:
					return P_0 - P_1;
				}
				break;
			}
			goto IL_0014;
		}

		private Vector3 ycNTgBJxNMLpeYlfLtllBetmdrga(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
			float num2 = MathTools.Atan2(P_0.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x2, P_1, z);
		}

		private Quaternion trsUiauIhmiEvWDlOpBCohoKTWC(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
			float num2 = MathTools.Atan2(P_0.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x2, P_1, z);
		}

		private Quaternion mCXxDIqaPNYcEtgJSeEPewzKriV(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num3 = default(float);
			float x = default(float);
			float z = default(float);
			while (true)
			{
				int num2 = 1366804260;
				while (true)
				{
					switch (num2 ^ 0x5177C725)
					{
					case 3:
						break;
					case 1:
					{
						float x2 = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
						num3 = MathTools.Atan2(P_0.x, x2);
						num2 = 1366804261;
						continue;
					}
					case 0:
						x = num * 57.29578f + 180f;
						z = (0f - num3) * 57.29578f;
						num2 = 1366804263;
						continue;
					default:
					{
						Quaternion quaternion = Quaternion.Euler(0f, 0f, z) * Quaternion.Euler(x, 0f, 0f);
						if (P_1 != 0f)
						{
							return quaternion * Quaternion.Euler(0f, P_1, 0f);
						}
						return quaternion;
					}
					}
					break;
				}
			}
		}

		private float QYJovuDjWonekrNPJHpbTjkcLkF(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool ZisxBhrfUHBvOlocCbYtOMFgqLG(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool IhKFGIImEfUjYmbBnztJgunlbbgf(Vector3 P_0, out AQgJEkcAsNUPiFMXRfZIyXrJdCE P_1)
		{
			P_0.Normalize();
			P_1 = AQgJEkcAsNUPiFMXRfZIyXrJdCE.XHUTYEIfTgeCBgXrVRVbPfGzuhN;
			bool result = default(bool);
			while (true)
			{
				int num = 2141010105;
				while (true)
				{
					switch (num ^ 0x7F9D38BB)
					{
					case 0:
						break;
					case 2:
						result = false;
						if (mtRXIdIqdBSRNqfQWnnsmQnmsgg(P_0))
						{
							result = true;
							P_1 |= AQgJEkcAsNUPiFMXRfZIyXrJdCE.vXOaLwhTyAhDMnOWhkrgxQfUpQAN;
							num = 2141010104;
							continue;
						}
						goto case 3;
					case 3:
						if (VbpycyuBFqaISAOQLGwAQnRNlask(P_0))
						{
							result = true;
							P_1 |= AQgJEkcAsNUPiFMXRfZIyXrJdCE.BHthfyenUmQSDsNqbVwGsEfPHjqb;
							num = 2141010106;
							continue;
						}
						goto default;
					default:
						return result;
					}
					break;
				}
			}
		}

		private bool mtRXIdIqdBSRNqfQWnnsmQnmsgg(Vector3 P_0)
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

		private bool VbpycyuBFqaISAOQLGwAQnRNlask(Vector3 P_0)
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

		private Vector3 aCWFOONWkvMWdrhoSKZhhnIcKWd(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 uLMyabGBmnAWfBQCjiYaouiwlTdk(ExpandableArray_DataContainer<HIDGyroscope.KBIcthKTrvImOspkbCGHzBZrrOsN> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			int num2 = default(int);
			while (true)
			{
				int num = -618148830;
				while (true)
				{
					switch (num ^ -618148832)
					{
					case 4:
						break;
					case 2:
						num2 = 0;
						num = -618148829;
						continue;
					case 1:
					{
						HIDGyroscope.KBIcthKTrvImOspkbCGHzBZrrOsN kBIcthKTrvImOspkbCGHzBZrrOsN = P_0[num2];
						result += uLMyabGBmnAWfBQCjiYaouiwlTdk(kBIcthKTrvImOspkbCGHzBZrrOsN.exXEGrdtTPMqWAFhcADmmCipVY, kBIcthKTrvImOspkbCGHzBZrrOsN.VcyElInJLsFJXvLnLYxHhMeWqFl);
						num = -618148832;
						continue;
					}
					case 0:
						num2++;
						num = -618148829;
						continue;
					default:
						if (num2 >= count)
						{
							return result;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		private Vector3 uLMyabGBmnAWfBQCjiYaouiwlTdk(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int CALdyVNfdFifKktknTAsimkzRSh(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void KthLgsyLIFfjuYoErgaPjHPcaRvM(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void PJeOizZvjtEYWAKATipWSDVSDQK(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float InnQpHFaiePFZBOHkFqvNhUWIeV()
		{
			return FhWLxVrmjyCNzKQgGOtMxAYBAUOH;
		}

		private void VsjZzRNXJlTxcWqumEeJIUONkGY(NativeBuffer P_0, HIDTouchpad.TouchData[] P_1)
		{
			int num = 33 + OyCokeQhaNYtJplTsfhDJcERBvkE;
			int positionRawX = default(int);
			int positionRawY2 = default(int);
			int positionRawX2 = default(int);
			int positionRawY = default(int);
			byte b = default(byte);
			bool flag2 = default(bool);
			int num4 = default(int);
			bool flag = default(bool);
			byte b2 = default(byte);
			int num3 = default(int);
			while (true)
			{
				int num2 = -1239372542;
				while (true)
				{
					switch (num2 ^ -1239372543)
					{
					case 2:
						break;
					case 3:
						positionRawX = P_0[1 + num] + (P_0[2 + num] & 0xF) * 255;
						positionRawY2 = ((P_0[2 + num] & 0xF0) >> 4) + P_0[3 + num] * 16;
						positionRawX2 = P_0[5 + num] + (P_0[6 + num] & 0xF) * 255;
						positionRawY = ((P_0[6 + num] & 0xF0) >> 4) + P_0[7 + num] * 16;
						b = P_0[num];
						num2 = -1239372538;
						continue;
					case 8:
						P_1[0].positionRawY = positionRawY2;
						P_1[1].isTouching = flag2;
						P_1[1].touchId = TqWfEhgBnkNcUdMOJKpkCdtUSOgu(1, flag2, num4);
						P_1[1].positionRawX = positionRawX2;
						num2 = -1239372540;
						continue;
					case 7:
						flag = b < 128;
						b2 = P_0[num + 4];
						flag2 = b2 < 128;
						num2 = -1239372544;
						continue;
					case 6:
						num4 = b2 & 0x7F;
						num2 = -1239372539;
						continue;
					case 0:
						P_1[0].positionRawX = positionRawX;
						num2 = -1239372535;
						continue;
					case 4:
						P_1[0].isTouching = flag;
						P_1[0].touchId = TqWfEhgBnkNcUdMOJKpkCdtUSOgu(0, flag, num3);
						num2 = -1239372543;
						continue;
					case 1:
						num3 = b & 0x7F;
						num2 = -1239372537;
						continue;
					default:
						P_1[1].positionRawY = positionRawY;
						return;
					}
					break;
				}
			}
		}

		private int TqWfEhgBnkNcUdMOJKpkCdtUSOgu(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				goto IL_0003;
			}
			int pkRJPDnjTLbGDJWjehyShsqKmwt = default(int);
			int num;
			if (P_2 != wdIeVXzcJxQyQpJSDxJfLanHFVA[P_0])
			{
				pkRJPDnjTLbGDJWjehyShsqKmwt = PkRJPDnjTLbGDJWjehyShsqKmwt;
				if (PkRJPDnjTLbGDJWjehyShsqKmwt == int.MaxValue)
				{
					PkRJPDnjTLbGDJWjehyShsqKmwt = 0;
					num = -1933939676;
					goto IL_0008;
				}
				goto IL_007a;
			}
			return HIxedbgFXtFzaFwEqlgKbFoeJTFO[P_0];
			IL_007a:
			PkRJPDnjTLbGDJWjehyShsqKmwt++;
			num = -1933939676;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ -1933939675)
				{
				case 2:
					break;
				case 4:
					HIxedbgFXtFzaFwEqlgKbFoeJTFO[P_0] = -1;
					wdIeVXzcJxQyQpJSDxJfLanHFVA[P_0] = P_2;
					return -1;
				case 1:
					wdIeVXzcJxQyQpJSDxJfLanHFVA[P_0] = P_2;
					num = -1933939674;
					continue;
				case 0:
					goto IL_007a;
				default:
					HIxedbgFXtFzaFwEqlgKbFoeJTFO[P_0] = pkRJPDnjTLbGDJWjehyShsqKmwt;
					return pkRJPDnjTLbGDJWjehyShsqKmwt;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num = -1933939679;
			goto IL_0008;
		}

		private void SDGOlaqcBukiLszYmIncLPdbTOY()
		{
			haXPdFXCTqGPeitNiiTTazNQsnaE = true;
		}

		~DualSenseDriver()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (base.disposed)
			{
				goto IL_0008;
			}
			goto IL_003a;
			IL_0008:
			int num = -1348206268;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -1348206266)
				{
				case 5:
					break;
				default:
					return;
				case 2:
					return;
				case 1:
					goto IL_003a;
				case 3:
					if (aeMwQuQlPtdUYawrQqVFIuMiAPdF != null)
					{
						aeMwQuQlPtdUYawrQqVFIuMiAPdF.Dispose();
						num = -1348206270;
						continue;
					}
					goto case 4;
				case 4:
					if (dPxPlSKThGVfgLiEEKYHuvifCBa != null)
					{
						dPxPlSKThGVfgLiEEKYHuvifCBa.Dispose();
						num = -1348206266;
						continue;
					}
					return;
				case 0:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_003a:
			base.Dispose(disposing);
			if (disposing)
			{
				StopVibration();
				gUULrqWdUNszJmicQQSwsanKBVW(WrVEVdhmDaiEyYHhLCqAumPxnFYB.pMrzmpQUTveEXenRCeQwcuyDgaOd);
				num = -1348206267;
				goto IL_000d;
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

		private static uint xliXGKGeEQkVQhengrEtnSQSGXJ(NativeBuffer P_0, int P_1)
		{
			uint num = 3940166985u;
			int num2 = 0;
			while (num2 < P_1)
			{
				while (true)
				{
					num = BpqLcvkZPgZKSXAYpRGbiotBVTb[(byte)num ^ P_0[num2]] ^ (num >> 8);
					num2++;
					int num3 = 2120278023;
					while (true)
					{
						switch (num3 ^ 0x7E60E006)
						{
						case 0:
							num3 = 2120278020;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0028;
						}
						break;
					}
					continue;
					end_IL_0028:
					break;
				}
			}
			return num;
		}

		private static RpboJdQsuurtFUZtKhAHmELficy QhuWTkDrfosgvVrQCTvfIQyFmsn(DualSenseOtherLightBrightness P_0)
		{
			DualSenseOtherLightBrightness dualSenseOtherLightBrightness = P_0;
			while (true)
			{
				switch (-1716020757 ^ -1716020758)
				{
				case 0:
					continue;
				case 1:
					switch (dualSenseOtherLightBrightness)
					{
					case DualSenseOtherLightBrightness.High:
						break;
					case DualSenseOtherLightBrightness.Medium:
						return RpboJdQsuurtFUZtKhAHmELficy.ysUBTerXXLslxVgKutqevPoAFfv;
					case DualSenseOtherLightBrightness.Low:
						return RpboJdQsuurtFUZtKhAHmELficy.sJPOcWeQfuAuKJhRRoTxtlOZiDh;
					default:
						throw new NotImplementedException();
					}
					break;
				}
				break;
			}
			return RpboJdQsuurtFUZtKhAHmELficy.AwnFbOlRxMDsWEkEleLFxxTRZby;
		}

		private static DualSenseOtherLightBrightness TOspFfAGuzkKuQnWvBleVfLMpgl(RpboJdQsuurtFUZtKhAHmELficy P_0)
		{
			switch (P_0)
			{
			case RpboJdQsuurtFUZtKhAHmELficy.AwnFbOlRxMDsWEkEleLFxxTRZby:
				return DualSenseOtherLightBrightness.High;
			case RpboJdQsuurtFUZtKhAHmELficy.ysUBTerXXLslxVgKutqevPoAFfv:
				return DualSenseOtherLightBrightness.Medium;
			case RpboJdQsuurtFUZtKhAHmELficy.sJPOcWeQfuAuKJhRRoTxtlOZiDh:
				return DualSenseOtherLightBrightness.Low;
			default:
				throw new NotImplementedException();
			}
		}
	}
}
