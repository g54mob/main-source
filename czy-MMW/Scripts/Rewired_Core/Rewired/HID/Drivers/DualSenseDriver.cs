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
	internal class DualSenseDriver : HIDDeviceDriver, IDriver_DualSense, IControllerDriver, IDisposable
	{
		private enum KvngAArznsVyfQMgCnZZNVFvPuaT
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum ArUXxRQjNxdGMClXoSfJHOBOeIFG
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		public enum TQFPfqcQxMBPHHshMMwRLVrMcKvU : byte
		{
			High = 0,
			Medium = 1,
			Low = 2
		}

		private const float LTwYRIymZYCvqPaKSbsdesfIygTK = 4f;

		private const int FQgpYpbnCqnjehsWhaFbCLRvujEsA = 15;

		private const int nZwZrrRTFJRcqEnsRlRiZSYFdNCr = 2;

		private const int OTogGuixXZGbeOBmfFqTXWXJeyfFb = 0;

		private const int NDFdEptLMhQtoYiCBbiNACEDsVEl = 1912;

		private const int FAeNWBRujzgEvPijVLoMCOsznUFh = 0;

		private const int qXdegtyrzrcBNklickteUZsugpPjA = 941;

		private const bool uPPACgzlKllwlrsBapRQsHjyEeRS = false;

		private const bool fjelNXRxqgdNQVudKFFBrHaNMNwP = true;

		private const float CwspgEoPIsUSfFJsReOVVtRMVEpv = 2.5f;

		private const int GCJUUtxRDDGTBKGQonVnWMLKwnvU = 0;

		private const int NmYdWllsbYJhJaWLrxsqTAeokyRv = 0;

		private const int QtRZdYYbtdbTvEIFQBjskqKqcfkd = 1;

		private const int vcPuJKkFPcJPsxzcEUCwdIVOKUyd = 0;

		private const int xsYwXiQgsmdgmkQmLaqbcDFumQxd = 0;

		private const int iHEfOcHXiwBacApFwDgeLFtEqHxc = 0;

		private const int NGMnmImfaEwVPpFqTdpMToJxHJjE = 1;

		private const int qbGhUXnzDETbyBAkvWXQAgwHMyqL = 49;

		private const int CgphoirBrafZKfhsaWmkVAbSrcOeb = 0;

		private const int pJQQcODmqdGSlVUadjDZGRnVaYCcA = 1;

		private const int GCQaHvhfKXxmxUtXtKIFyKMyYYhw = 64;

		private const int YileVUKeTClYtKvZQfmMcZEeVxJU = 48;

		private const int yCqrzISLknUdfLOZPBNyIoiAFHgg = 547;

		private const int fljCvQMXHpDeVQfuqdhZhegjeDnib = 64;

		private const int WzbAyhPZFXbUGVcCZGvznLIeiwwe = 547;

		private const int XGhEDMZIIBwoezImjGjHMRAHZLII = 1;

		private const int aQSbxxtPWvMJsnTSuqErdjCvEeTH = 2;

		private const int ToNGjNtfRasnNVtKfvxpoHiyQiPh = 3;

		private const int dkPUAVkJoRoyeNRaSMmVJppPfMwFA = 4;

		private const int aKCXGWBDBQbLAjrpMjOQsjGXJaap = 5;

		private const int fojBjbgtAYzyUBtqntxGTLpGvxyS = 6;

		private const int QTIulTYjUHQRQgaEQiSEZmXxwSCU = 8;

		private const int iHPWYZJxYUupmTMnApTjayKISPVs = 22;

		private const int EYfRLjMTFYaRbRPiYvtJgBInGOIFA = 16;

		private const int JecRYDcKmkwKctjBsuaJBUUgEeSM = 33;

		private const int oSpXmJkqjdiJGelMjPItEDoooIJOA = 8;

		private const int OsInYxTpUiSyjrSpsAnjaseCdXLL = 9;

		private const int wNQXKMongunzATVaqhFbAdnJwngM = 10;

		private const int XDmBYkCvZTYqSUGhtPMVbmCcdliRB = 28;

		private const int VvWmogfRdlwYBxHWJBcuHqSiOPqB = 54;

		private const int KZYawsfzTXaTKtTtoIzvuQORWIHFA = 55;

		private const int NDQhOyJKnrAehikYISkSRrQuRdZb = 54;

		private const bool qkmYFJHNKhKtfhnNMvTtYFgKlEEj = true;

		private const int EwPfUjXSFJGcxjkXSEhDmHqMczvAb = 25;

		private const int RNGzYqhjWRKuyyYMowqSWiuzylXW = 3000000;

		private const float iWrZYtVtSgdPiCTcCBqQhEFQBAbCA = 8192f;

		private const float WjWPtdCBtNgTafXptybfeGdjENdm = 0.0010652969f;

		private const float FwPBIxJOPJeoBxlylaTbDvZMZHKOA = 0.06103702f;

		private const bool CfrSUfggyrohLeBxxbWXjOHmXKBx = true;

		private const bool zxJOUIOTZzSxhsiKmNFYePVPHtgd = true;

		private const bool kbaHxdcjxuBQYFQNkOPxLMqrGclJb = true;

		private const bool AtkpRdLmpdLrCFwrDSIITARSQDmP = true;

		private const float hXcgWkHkWpfZssLLVaOdteYHRlSD = 4096f;

		private const float jqsGhnjdXRACAZVfzOkIoOIoGElX = 16384f;

		private const float qXtMFuBHjExGKTsqqyAyiGRKvGDl = 16777216f;

		private const float lBPGVPjfbPPCjOzNBaTKRqpQunDT = 268435460f;

		private const float CgUAmUpQIJioeIdCxaKnlRDIhqOz = 0.01999998f;

		private const float WsUKJfpkNrGIUAFeRRfaxesIZAdkA = 8192f;

		private const float XuQsNyktXcUvFDrhzWdcnjgMWmGK = 0.98f;

		private const float qiejVgyNbMAMzOOztAMgrQyVYrCP = 45f;

		private const float cwxIHdRwXEdQcyrPtYGKiRmbBuyg = 20f;

		private readonly bool gwgkfcFRHQqPpWhTSwxTJwtcNRqg;

		private readonly int JtDeRtBzvUbdSNkCjBhGsZvzZKQd;

		private readonly int TbrZixqNiEZHoablbGntIyOLbFMAA;

		private readonly bool MhbElvtKstQFAVePWJQkpegfKEtj;

		private readonly byte DqsBBQSgfauRNygLYYChpofGnZqR;

		private readonly int LPvkFWzDqWabZBUHCiyjEkSBYpwR;

		private readonly int HlMWKZduIaiKCssWxELTnOiEwCKw;

		private readonly int uQlulqGmyXlCDXQnNyECXNewRLPE;

		private readonly int jwFWpFJOgpZKFNhdXGhDdFLncNnXA;

		private readonly int IVjdmRHykqrAtgamROrNsINlgLsqA;

		private readonly int pgkGMwRjfQcCckzPLIlnzPxRkBAL;

		private readonly NativeBuffer BAuFkKITFvMAttdGniuGhpjWvGyJA;

		private readonly NativeBuffer bRynnadDBHZKaeZhnvZQCWFBQuqu;

		private OutputReport YmQgmQrctbKAMLLSGdUNyFIPdHACA;

		private readonly Func<OutputReport, bool> hZzPGZpgqGdIGbEVTgoWIGQVQiFv;

		private readonly Action<OutputReport> zVyFVxZlVChBIjODgWQPJtoDoljp;

		private bool ToFUJAbrcqwEStIHhCtTYCGuJJdS;

		private bool HNhjxTGAhwNdFpfIYeJlWZZVcxcf;

		private double CgQNBDoQTCjBUNojpXYzWciYMlsi;

		private byte OOINwJqDCWHNuOMsSHmHHwRcBSqW;

		private bool qplRRRqPAKPIprrajvGFSqZfezMdA;

		private bool WzRKkQdzwAqbsvtyLdoRzfZUmOuU;

		private bool bnyfGueknyPTaFDyeVGzWZPTeqmVB;

		private Quaternion GvLWZtfNZcQsMtGkRdgpDTHAubcqA = Quaternion.identity;

		private DualSenseMicrophoneLightMode CdsQewBPaZDpdOsVkwsPRRAaWbRP;

		private TQFPfqcQxMBPHHshMMwRLVrMcKvU sGqeZenmYLRmWMNowmoTIMLHiEIB;

		private DualSensePlayerLightFlags viBzFNHvYfzfwNIjYThXvVJUVmfI;

		private bool dOMUdssjYjGzrGJFfVerSzGLEQEy;

		private bool chpUMzDdEJaJGRODOUgDnUpAOFcp;

		private uint zPDfCxIBWotrxpqsdCqjEVPDqsKAA;

		private float FfXUzcYalLLnJcCLYGpHTlHfXpkL;

		private double LrzzDFSrksGelgrfaZrdBHeppCxHb;

		private float ixhhJDtXFWYnQhFERdEFuWYgOpYN;

		private byte qKTJxJavlWiaeykCxJtOJiyLGtDY;

		private byte EvSDDQPPZiSGFoPfMLrLAJuFwijk;

		private Quaternion svkJEgGFGczFHjieITvqZKOWbPlk = Quaternion.identity;

		private Quaternion CrDhmaOItnEnePDmeESIagaZXyjX = Quaternion.identity;

		private bool IoeOajLCtqIxRYpcKwqCWyZaefOq;

		private int DgyexdtEHVNiDOVvlLsXmPXucPPD;

		private int[] zhzQplqdoUXBMcpALXxqyhqbKkqp = new int[2];

		private int[] QGCOkbTuqwfETesalWfBLbcANhsw = new int[2];

		private static uint[] GooDBFBfQQFTBdPwEQQMLPrstloA = new uint[256]
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

		private const uint iJexZaPibZgkkCFjHxgcicCenIrj = 3940166985u;

		private bool isVibrating
		{
			get
			{
				for (int i = 0; i < base.Rewired_002EDrivers_002EInterfaces_002EIControllerDriver_002EVibrationMotorCount; i++)
				{
					if (vibrationMotors[i].SpeedRaw > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		float IDriver_DualSense.BatteryLevel
		{
			get
			{
				float num = 0f;
				num = ((!gwgkfcFRHQqPpWhTSwxTJwtcNRqg) ? ((float)(OOINwJqDCWHNuOMsSHmHHwRcBSqW - 1) * 10f) : ((float)(OOINwJqDCWHNuOMsSHmHHwRcBSqW + 2) * 10f));
				return MathTools.Clamp(num, 0f, 100f);
			}
		}

		bool IDriver_DualSense.BatteryCharging => qplRRRqPAKPIprrajvGFSqZfezMdA;

		float IDriver_DualSense.LeftMotor
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

		float IDriver_DualSense.RightMotor
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

		float IDriver_DualSense.LightColorR
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

		float IDriver_DualSense.LightColorG
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

		float IDriver_DualSense.LightColorB
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

		float IDriver_DualSense.LightFlashOnDuration
		{
			get
			{
				return (int)qKTJxJavlWiaeykCxJtOJiyLGtDY;
			}
			set
			{
				qKTJxJavlWiaeykCxJtOJiyLGtDY = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				ToFUJAbrcqwEStIHhCtTYCGuJJdS = true;
				if (qKTJxJavlWiaeykCxJtOJiyLGtDY == 0 && EvSDDQPPZiSGFoPfMLrLAJuFwijk == 0)
				{
					HNhjxTGAhwNdFpfIYeJlWZZVcxcf = true;
				}
			}
		}

		float IDriver_DualSense.LightFlashOffDuration
		{
			get
			{
				return (int)EvSDDQPPZiSGFoPfMLrLAJuFwijk;
			}
			set
			{
				EvSDDQPPZiSGFoPfMLrLAJuFwijk = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				ToFUJAbrcqwEStIHhCtTYCGuJJdS = true;
				if (qKTJxJavlWiaeykCxJtOJiyLGtDY == 0 && EvSDDQPPZiSGFoPfMLrLAJuFwijk == 0)
				{
					HNhjxTGAhwNdFpfIYeJlWZZVcxcf = true;
				}
			}
		}

		DualSenseMicrophoneLightMode IDriver_DualSense.microphoneLightMode
		{
			get
			{
				return CdsQewBPaZDpdOsVkwsPRRAaWbRP;
			}
			set
			{
				CdsQewBPaZDpdOsVkwsPRRAaWbRP = value;
				ToFUJAbrcqwEStIHhCtTYCGuJJdS = true;
			}
		}

		DualSenseOtherLightBrightness IDriver_DualSense.otherLightBrightness
		{
			get
			{
				return aqVnUrGFcacgbdrxKgMoYdKjDsai(sGqeZenmYLRmWMNowmoTIMLHiEIB);
			}
			set
			{
				sGqeZenmYLRmWMNowmoTIMLHiEIB = HQtlQhQSDOoFGUMweVUWYTlrhxNd(value);
				ToFUJAbrcqwEStIHhCtTYCGuJJdS = true;
			}
		}

		DualSensePlayerLightFlags IDriver_DualSense.playerLights
		{
			get
			{
				return viBzFNHvYfzfwNIjYThXvVJUVmfI;
			}
			set
			{
				viBzFNHvYfzfwNIjYThXvVJUVmfI = value;
				ToFUJAbrcqwEStIHhCtTYCGuJJdS = true;
			}
		}

		Vector3 IDriver_DualSense.AccelerometerValue => LYcrRcZeaRGJGYTYZMynNADxDqvP(accelerometers[0].rawValue);

		Vector3 IDriver_DualSense.AccelerometerValueRaw => new Vector3(accelerometers[0].rawValue[0], accelerometers[0].rawValue[1], accelerometers[0].rawValue[2]);

		Vector3 IDriver_DualSense.GyroscopeValue => ZdfZDJcmxccyueawTvPvRjmvATiiA(gyroscopes[0].events);

		Vector3 IDriver_DualSense.GyroscopeValueRaw => new Vector3(gyroscopes[0].rawValue[0], gyroscopes[0].rawValue[1], gyroscopes[0].rawValue[2]);

		Vector3 IDriver_DualSense.LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);
				return LbUGqsKCYksraRGeRGWkXySmHhYf(vector, FfXUzcYalLLnJcCLYGpHTlHfXpkL);
			}
		}

		Vector3 IDriver_DualSense.LastGyroscopeValueRaw => new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);

		Quaternion IDriver_DualSense.Orientation => GvLWZtfNZcQsMtGkRdgpDTHAubcqA;

		int IDriver_DualSense.MaxTouches => 2;

		public void ResetOrientation()
		{
			GvLWZtfNZcQsMtGkRdgpDTHAubcqA = Quaternion.identity;
			IoeOajLCtqIxRYpcKwqCWyZaefOq = false;
		}

		void IDriver_DualSense.ResetOrientation()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ResetOrientation
			this.ResetOrientation();
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

		int IDriver_DualSense.GetTouchCount()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchCount
			return this.GetTouchCount();
		}

		public bool IsTouchingAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return false;
			}
			return touchpads[0].values[index].isTouching;
		}

		bool IDriver_DualSense.IsTouchingAtIndex(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtIndex
			return this.IsTouchingAtIndex(index);
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return touchpads[0].IsTouching(touchId);
		}

		bool IDriver_DualSense.IsTouchingAtTouchId(int touchId)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtTouchId
			return this.IsTouchingAtTouchId(touchId);
		}

		public int GetTouchIdAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return -1;
			}
			return touchpads[0].values[index].touchId;
		}

		int IDriver_DualSense.GetTouchIdAtIndex(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchIdAtIndex
			return this.GetTouchIdAtIndex(index);
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

		bool IDriver_DualSense.GetTouchPositionByIndex(int index, out Vector2 position)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByIndex
			return this.GetTouchPositionByIndex(index, out position);
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

		bool IDriver_DualSense.GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByTouchId
			return this.GetTouchPositionByTouchId(touchId, out position);
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

		bool IDriver_DualSense.GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionAbsoluteByIndex
			return this.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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

		bool IDriver_DualSense.GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionAbsoluteByTouchId
			return this.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
		}

		public void StopLightFlash()
		{
			qKTJxJavlWiaeykCxJtOJiyLGtDY = 0;
			EvSDDQPPZiSGFoPfMLrLAJuFwijk = 0;
			ToFUJAbrcqwEStIHhCtTYCGuJJdS = true;
			HNhjxTGAhwNdFpfIYeJlWZZVcxcf = true;
		}

		void IDriver_DualSense.StopLightFlash()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopLightFlash
			this.StopLightFlash();
		}

		public void StopVibration()
		{
			int num = base.Rewired_002EDrivers_002EInterfaces_002EIControllerDriver_002EVibrationMotorCount;
			for (int i = 0; i < num; i++)
			{
				vibrationMotors[i].SpeedRaw = 0;
			}
		}

		void IDriver_DualSense.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public DualSenseDriver(InitArgs P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			JtDeRtBzvUbdSNkCjBhGsZvzZKQd = P_0.hatZeroValue;
			TbrZixqNiEZHoablbGntIyOLbFMAA = P_0.hatSpan;
			LPvkFWzDqWabZBUHCiyjEkSBYpwR = P_0.inputReportLength;
			HlMWKZduIaiKCssWxELTnOiEwCKw = P_0.outputReportLength;
			hZzPGZpgqGdIGbEVTgoWIGQVQiFv = P_0.synchronousWriteOutputReportDelegate;
			zVyFVxZlVChBIjODgWQPJtoDoljp = P_0.asynchronousWriteOutputReportDelegate;
			gwgkfcFRHQqPpWhTSwxTJwtcNRqg = P_0.connectionType == DeviceConnectionType.Bluetooth;
			if (gwgkfcFRHQqPpWhTSwxTJwtcNRqg)
			{
				HlMWKZduIaiKCssWxELTnOiEwCKw = 547;
			}
			else
			{
				HlMWKZduIaiKCssWxELTnOiEwCKw = 48;
			}
			BAuFkKITFvMAttdGniuGhpjWvGyJA = new NativeBuffer(64);
			bRynnadDBHZKaeZhnvZQCWFBQuqu = new NativeBuffer(HlMWKZduIaiKCssWxELTnOiEwCKw);
			YmQgmQrctbKAMLLSGdUNyFIPdHACA = new OutputReport(bRynnadDBHZKaeZhnvZQCWFBQuqu.Pointer, bRynnadDBHZKaeZhnvZQCWFBQuqu.Length, HlMWKZduIaiKCssWxELTnOiEwCKw);
			lights = new HIDLight[1]
			{
				new HIDLight(11, 24, 28)
			};
			lights[0].ValueChangedEvent += nurlNNmVsjsdsCnATDafzrzscCqM;
			vibrationMotors = new HIDVibrationMotor[2]
			{
				new HIDVibrationMotor(0, 255),
				new HIDVibrationMotor(0, 255)
			};
			vibrationMotors[0].ValueChangedEvent += nurlNNmVsjsdsCnATDafzrzscCqM;
			vibrationMotors[1].ValueChangedEvent += nurlNNmVsjsdsCnATDafzrzscCqM;
			if (gwgkfcFRHQqPpWhTSwxTJwtcNRqg)
			{
				byte[] array = P_0.getFeatureReportDelegate(5);
				MhbElvtKstQFAVePWJQkpegfKEtj = array != null && array.Length != 0;
				if (MhbElvtKstQFAVePWJQkpegfKEtj)
				{
					tsfeQgDoHAOhJsvTQfgOshwwPdjH(IthEmOYLIWoAKOtZgfENDyquvbZK.Synchronous);
				}
			}
			else
			{
				MhbElvtKstQFAVePWJQkpegfKEtj = true;
				MhbElvtKstQFAVePWJQkpegfKEtj = tsfeQgDoHAOhJsvTQfgOshwwPdjH(IthEmOYLIWoAKOtZgfENDyquvbZK.Synchronous);
			}
			if (!MhbElvtKstQFAVePWJQkpegfKEtj)
			{
				throw new Exception("Special features not supported so just treat this as a standard HID device.");
			}
			DqsBBQSgfauRNygLYYChpofGnZqR = 1;
			uQlulqGmyXlCDXQnNyECXNewRLPE = 0;
			if (gwgkfcFRHQqPpWhTSwxTJwtcNRqg && MhbElvtKstQFAVePWJQkpegfKEtj)
			{
				DqsBBQSgfauRNygLYYChpofGnZqR = 49;
				uQlulqGmyXlCDXQnNyECXNewRLPE = 1;
			}
			jwFWpFJOgpZKFNhdXGhDdFLncNnXA = 8 + uQlulqGmyXlCDXQnNyECXNewRLPE;
			IVjdmRHykqrAtgamROrNsINlgLsqA = 9 + uQlulqGmyXlCDXQnNyECXNewRLPE;
			pgkGMwRjfQcCckzPLIlnzPxRkBAL = 10 + uQlulqGmyXlCDXQnNyECXNewRLPE;
			buttons = new HIDButton[15];
			for (int i = 0; i < 15; i++)
			{
				buttons[i] = new HIDButton(DqsBBQSgfauRNygLYYChpofGnZqR, new HIDControllerElement.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new HIDAxis[6]
			{
				new HIDAxis(DqsBBQSgfauRNygLYYChpofGnZqR, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + uQlulqGmyXlCDXQnNyECXNewRLPE,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(DqsBBQSgfauRNygLYYChpofGnZqR, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + uQlulqGmyXlCDXQnNyECXNewRLPE,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(DqsBBQSgfauRNygLYYChpofGnZqR, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + uQlulqGmyXlCDXQnNyECXNewRLPE,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(DqsBBQSgfauRNygLYYChpofGnZqR, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + uQlulqGmyXlCDXQnNyECXNewRLPE,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(DqsBBQSgfauRNygLYYChpofGnZqR, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 5 + uQlulqGmyXlCDXQnNyECXNewRLPE,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new HIDAxis(DqsBBQSgfauRNygLYYChpofGnZqR, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 6 + uQlulqGmyXlCDXQnNyECXNewRLPE,
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
				new HIDHat(DqsBBQSgfauRNygLYYChpofGnZqR, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 8 + uQlulqGmyXlCDXQnNyECXNewRLPE,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, bpJCbkMzvqjcNXBJScKyretLgQYJ)
			};
			accelerometers = new HIDAccelerometer[1]
			{
				new HIDAccelerometer(DqsBBQSgfauRNygLYYChpofGnZqR, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 22 + uQlulqGmyXlCDXQnNyECXNewRLPE,
					bitSize = 48
				}, 3, AQVawaEyGNuZXgSdhmRFdQjeCvKDA)
			};
			gyroscopes = new HIDGyroscope[1]
			{
				new HIDGyroscope(P_0.updateLoopSetting, DqsBBQSgfauRNygLYYChpofGnZqR, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 16 + uQlulqGmyXlCDXQnNyECXNewRLPE,
					bitSize = 48
				}, 3, 25, CuYEmjCFzRlMfUXboXOgjeQqYCINA, CSqJsCrHmksOmRTOFKiLxANSfqCeA)
			};
			touchpads = new HIDTouchpad[1]
			{
				new HIDTouchpad(DqsBBQSgfauRNygLYYChpofGnZqR, new HIDTouchpad.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 33 + uQlulqGmyXlCDXQnNyECXNewRLPE,
					bitSize = 48
				}, CtbuUfmtzHRdXjUVtJNcCZbAktsG)
			};
			LrzzDFSrksGelgrfaZrdBHeppCxHb = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			JpyePRnSSSXjJtaaDatYxRLERvco();
			pbALZBCFsKVcrJWudHDAnyazgIxN(IthEmOYLIWoAKOtZgfENDyquvbZK.Asynchronous);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < BAuFkKITFvMAttdGniuGhpjWvGyJA.Length)
			{
				return false;
			}
			ixhhJDtXFWYnQhFERdEFuWYgOpYN = (float)(timestamp - LrzzDFSrksGelgrfaZrdBHeppCxHb);
			LrzzDFSrksGelgrfaZrdBHeppCxHb = timestamp;
			BAuFkKITFvMAttdGniuGhpjWvGyJA.Write(inputReportPtr, inputReportLength, BAuFkKITFvMAttdGniuGhpjWvGyJA.Length);
			pTPMIyEVGaLjcrVzbcpTRNvBExEj(BAuFkKITFvMAttdGniuGhpjWvGyJA);
			BjbglxaJKcRkcjHfmyfsQXAQwlHQ(BAuFkKITFvMAttdGniuGhpjWvGyJA, timestamp);
			HIDControllerElement[] array = axes;
			mztaGmeVXDvXPBjULtcyNzfccMsEA(array, BAuFkKITFvMAttdGniuGhpjWvGyJA, timestamp);
			array = hats;
			mztaGmeVXDvXPBjULtcyNzfccMsEA(array, BAuFkKITFvMAttdGniuGhpjWvGyJA, timestamp);
			array = accelerometers;
			mztaGmeVXDvXPBjULtcyNzfccMsEA(array, BAuFkKITFvMAttdGniuGhpjWvGyJA, timestamp);
			array = gyroscopes;
			mztaGmeVXDvXPBjULtcyNzfccMsEA(array, BAuFkKITFvMAttdGniuGhpjWvGyJA, timestamp);
			array = touchpads;
			mztaGmeVXDvXPBjULtcyNzfccMsEA(array, BAuFkKITFvMAttdGniuGhpjWvGyJA, timestamp);
			qplRRRqPAKPIprrajvGFSqZfezMdA = (BAuFkKITFvMAttdGniuGhpjWvGyJA[54 + uQlulqGmyXlCDXQnNyECXNewRLPE] & 8) != 0;
			WzRKkQdzwAqbsvtyLdoRzfZUmOuU = (BAuFkKITFvMAttdGniuGhpjWvGyJA[55 + uQlulqGmyXlCDXQnNyECXNewRLPE] & 0x20) != 0;
			OOINwJqDCWHNuOMsSHmHHwRcBSqW = (byte)(BAuFkKITFvMAttdGniuGhpjWvGyJA[55 + uQlulqGmyXlCDXQnNyECXNewRLPE] & 0xF);
			bnyfGueknyPTaFDyeVGzWZPTeqmVB = (BAuFkKITFvMAttdGniuGhpjWvGyJA[54 + uQlulqGmyXlCDXQnNyECXNewRLPE] & 1) != 0;
			erGCjTLAqPOQkWGyshPZgsGctksk();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualSenseExtension(this);
		}

		private void pbALZBCFsKVcrJWudHDAnyazgIxN(IthEmOYLIWoAKOtZgfENDyquvbZK P_0)
		{
			if (ToFUJAbrcqwEStIHhCtTYCGuJJdS)
			{
				tsfeQgDoHAOhJsvTQfgOshwwPdjH(P_0);
				ToFUJAbrcqwEStIHhCtTYCGuJJdS = false;
			}
		}

		private bool tsfeQgDoHAOhJsvTQfgOshwwPdjH(IthEmOYLIWoAKOtZgfENDyquvbZK P_0)
		{
			qHuDDDETJEVUdkZZccapliSvruTPA();
			bool result = YZKLldPdenXaDmmCfFypsadCEQTV(P_0);
			if (HNhjxTGAhwNdFpfIYeJlWZZVcxcf)
			{
				result = YZKLldPdenXaDmmCfFypsadCEQTV(P_0);
				HNhjxTGAhwNdFpfIYeJlWZZVcxcf = false;
			}
			return result;
		}

		private void qHuDDDETJEVUdkZZccapliSvruTPA()
		{
			if (gwgkfcFRHQqPpWhTSwxTJwtcNRqg && MhbElvtKstQFAVePWJQkpegfKEtj)
			{
				bRynnadDBHZKaeZhnvZQCWFBQuqu[0] = 49;
				bRynnadDBHZKaeZhnvZQCWFBQuqu[1] = 2;
				HnzDvBoMUGPNgCbLCZhApQRcmsiH(bRynnadDBHZKaeZhnvZQCWFBQuqu, 2);
				uint num = hOJzHVsnZhCpzPJfEOSFgzFITgYD(bRynnadDBHZKaeZhnvZQCWFBQuqu, 74);
				bRynnadDBHZKaeZhnvZQCWFBQuqu[74] = (byte)(num & 0xFF);
				bRynnadDBHZKaeZhnvZQCWFBQuqu[75] = (byte)((num & 0xFF00) >> 8);
				bRynnadDBHZKaeZhnvZQCWFBQuqu[76] = (byte)((num & 0xFF0000) >> 16);
				bRynnadDBHZKaeZhnvZQCWFBQuqu[77] = (byte)((num & 0xFF000000u) >> 24);
			}
			else
			{
				bRynnadDBHZKaeZhnvZQCWFBQuqu[0] = 2;
				HnzDvBoMUGPNgCbLCZhApQRcmsiH(bRynnadDBHZKaeZhnvZQCWFBQuqu, 1);
			}
		}

		private void HnzDvBoMUGPNgCbLCZhApQRcmsiH(NativeBuffer P_0, int P_1)
		{
			P_0[P_1] = byte.MaxValue;
			P_0[1 + P_1] = 247;
			P_0[2 + P_1] = (byte)vibrationMotors[1].SpeedRaw;
			P_0[3 + P_1] = (byte)vibrationMotors[0].SpeedRaw;
			P_0[8 + P_1] = (byte)CdsQewBPaZDpdOsVkwsPRRAaWbRP;
			P_0[43 + P_1] = (byte)viBzFNHvYfzfwNIjYThXvVJUVmfI;
			if (dOMUdssjYjGzrGJFfVerSzGLEQEy)
			{
				P_0[43 + P_1] = (byte)(P_0[43 + P_1] & -33);
			}
			else
			{
				P_0[43 + P_1] |= 32;
			}
			P_0[38 + P_1] = 3;
			P_0[41 + P_1] = (byte)(chpUMzDdEJaJGRODOUgDnUpAOFcp ? 1 : 2);
			P_0[42 + P_1] = (byte)sGqeZenmYLRmWMNowmoTIMLHiEIB;
			P_0[44 + P_1] = lights[0].ColorRRaw;
			P_0[45 + P_1] = lights[0].ColorGRaw;
			P_0[46 + P_1] = lights[0].ColorBRaw;
		}

		private bool YZKLldPdenXaDmmCfFypsadCEQTV(IthEmOYLIWoAKOtZgfENDyquvbZK P_0)
		{
			CgQNBDoQTCjBUNojpXYzWciYMlsi = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case IthEmOYLIWoAKOtZgfENDyquvbZK.Synchronous:
				if (hZzPGZpgqGdIGbEVTgoWIGQVQiFv == null)
				{
					return false;
				}
				return hZzPGZpgqGdIGbEVTgoWIGQVQiFv(YmQgmQrctbKAMLLSGdUNyFIPdHACA);
			case IthEmOYLIWoAKOtZgfENDyquvbZK.Asynchronous:
				if (zVyFVxZlVChBIjODgWQPJtoDoljp == null)
				{
					return false;
				}
				zVyFVxZlVChBIjODgWQPJtoDoljp(YmQgmQrctbKAMLLSGdUNyFIPdHACA);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void BjbglxaJKcRkcjHfmyfsQXAQwlHQ(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[jwFWpFJOgpZKFNhdXGhDdFLncNnXA];
			buttons[0].SetValue((b & 0x10) != 0, P_1);
			buttons[1].SetValue((b & 0x20) != 0, P_1);
			buttons[2].SetValue((b & 0x40) != 0, P_1);
			buttons[3].SetValue((b & 0x80) != 0, P_1);
			b = P_0[IVjdmRHykqrAtgamROrNsINlgLsqA];
			buttons[4].SetValue((b & 1) != 0, P_1);
			buttons[5].SetValue((b & 2) != 0, P_1);
			buttons[6].SetValue((b & 4) != 0, P_1);
			buttons[7].SetValue((b & 8) != 0, P_1);
			buttons[8].SetValue((b & 0x10) != 0, P_1);
			buttons[9].SetValue((b & 0x20) != 0, P_1);
			buttons[10].SetValue((b & 0x40) != 0, P_1);
			buttons[11].SetValue((b & 0x80) != 0, P_1);
			b = P_0[pgkGMwRjfQcCckzPLIlnzPxRkBAL];
			buttons[12].SetValue((b & 1) != 0, P_1);
			buttons[13].SetValue((b & 2) != 0, P_1);
			if (MhbElvtKstQFAVePWJQkpegfKEtj)
			{
				buttons[14].SetValue((b & 4) != 0, P_1);
			}
		}

		private void mztaGmeVXDvXPBjULtcyNzfccMsEA(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].UpdateValue(P_1, P_2);
			}
		}

		private void JpyePRnSSSXjJtaaDatYxRLERvco()
		{
			if (isVibrating && ReInput.realTime >= CgQNBDoQTCjBUNojpXYzWciYMlsi)
			{
				ToFUJAbrcqwEStIHhCtTYCGuJJdS = true;
			}
		}

		private void pTPMIyEVGaLjcrVzbcpTRNvBExEj(NativeBuffer P_0)
		{
			if (MhbElvtKstQFAVePWJQkpegfKEtj)
			{
				uint num = BAuFkKITFvMAttdGniuGhpjWvGyJA.ReadUInt(28 + uQlulqGmyXlCDXQnNyECXNewRLPE);
				float ffXUzcYalLLnJcCLYGpHTlHfXpkL;
				if (num != zPDfCxIBWotrxpqsdCqjEVPDqsKAA)
				{
					uint num2 = (uint)((num >= zPDfCxIBWotrxpqsdCqjEVPDqsKAA) ? (num - zPDfCxIBWotrxpqsdCqjEVPDqsKAA) : ((long)num + 4294967295L - zPDfCxIBWotrxpqsdCqjEVPDqsKAA));
					ffXUzcYalLLnJcCLYGpHTlHfXpkL = (float)num2 / 3000000f;
				}
				else
				{
					uint num2 = 0u;
					ffXUzcYalLLnJcCLYGpHTlHfXpkL = 0f;
				}
				zPDfCxIBWotrxpqsdCqjEVPDqsKAA = num;
				FfXUzcYalLLnJcCLYGpHTlHfXpkL = ffXUzcYalLLnJcCLYGpHTlHfXpkL;
			}
		}

		private void erGCjTLAqPOQkWGyshPZgsGctksk()
		{
			if (MhbElvtKstQFAVePWJQkpegfKEtj && !(FfXUzcYalLLnJcCLYGpHTlHfXpkL <= 0f))
			{
				Vector3 vector = LbUGqsKCYksraRGeRGWkXySmHhYf(new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]), FfXUzcYalLLnJcCLYGpHTlHfXpkL);
				rlqPEXNduRFNRwTaAOaegmsNHQEl(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].rawValue[0] * -1f, accelerometers[0].rawValue[1] * -1f, accelerometers[0].rawValue[2] * -1f);
				RazOvnSoQUZgvnGVINjKzMXVuQQe(vector2, vector);
			}
		}

		private static bool rlqPEXNduRFNRwTaAOaegmsNHQEl(ref Vector3 P_0)
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

		private void RazOvnSoQUZgvnGVINjKzMXVuQQe(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && JDrnQRuzxRVfyUPHdYYshPFEeiAD(P_0, out var arUXxRQjNxdGMClXoSfJHOBOeIFG))
			{
				Quaternion a = GvLWZtfNZcQsMtGkRdgpDTHAubcqA * quaternion;
				if (!IoeOajLCtqIxRYpcKwqCWyZaefOq)
				{
					IoeOajLCtqIxRYpcKwqCWyZaefOq = true;
					svkJEgGFGczFHjieITvqZKOWbPlk = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					CrDhmaOItnEnePDmeESIagaZXyjX = GvLWZtfNZcQsMtGkRdgpDTHAubcqA;
				}
				svkJEgGFGczFHjieITvqZKOWbPlk *= quaternion;
				CrDhmaOItnEnePDmeESIagaZXyjX *= quaternion;
				Quaternion b;
				if ((arUXxRQjNxdGMClXoSfJHOBOeIFG & ArUXxRQjNxdGMClXoSfJHOBOeIFG.XZ) != ArUXxRQjNxdGMClXoSfJHOBOeIFG.None)
				{
					b = DgRLDaJHUDnfYnoOAFCEEmihpIIY(P_0, a.eulerAngles.y);
				}
				else if ((arUXxRQjNxdGMClXoSfJHOBOeIFG & ArUXxRQjNxdGMClXoSfJHOBOeIFG.Y) != ArUXxRQjNxdGMClXoSfJHOBOeIFG.None)
				{
					b = KoAJKqthfJaaWNRCXoyKmByBaqCt(P_0);
					Vector3 vector = CrDhmaOItnEnePDmeESIagaZXyjX * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				GvLWZtfNZcQsMtGkRdgpDTHAubcqA = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				GvLWZtfNZcQsMtGkRdgpDTHAubcqA *= quaternion;
				if (IoeOajLCtqIxRYpcKwqCWyZaefOq)
				{
					IoeOajLCtqIxRYpcKwqCWyZaefOq = false;
				}
			}
		}

		private static Quaternion wvulogYbiqzidnPPGgsKOWuTUOpm(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = NaRvUEAwqjiJyqOpYInxaBuMkZOvA(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 NaRvUEAwqjiJyqOpYInxaBuMkZOvA(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion oStbwEMxunyiMDNHKjGpBMqtPEiCb(Quaternion P_0, KvngAArznsVyfQMgCnZZNVFvPuaT P_1)
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

		private float hoLWPeVWkKorfnqVaQZwiVJRjSfs(float P_0, float P_1)
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

		private Vector3 apCmdDPFQxgJmZFmfUoGlYdEkBc(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion DgRLDaJHUDnfYnoOAFCEEmihpIIY(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion KoAJKqthfJaaWNRCXoyKmByBaqCt(Vector3 P_0, float P_1 = 0f)
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

		private float aKJZwmhHQdcXLPqWMnYAkpeRKeNw(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool nBJmonzGgagbSeljudfJRPcKTWop(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool JDrnQRuzxRVfyUPHdYYshPFEeiAD(Vector3 P_0, out ArUXxRQjNxdGMClXoSfJHOBOeIFG P_1)
		{
			P_0.Normalize();
			P_1 = ArUXxRQjNxdGMClXoSfJHOBOeIFG.None;
			bool result = false;
			if (JpZNcRUNgGVjCZbovHLkGZmKQhKtA(P_0))
			{
				result = true;
				P_1 |= ArUXxRQjNxdGMClXoSfJHOBOeIFG.XZ;
			}
			if (PusPmDPfgzLoNitADCcgRlRAvfpn(P_0))
			{
				result = true;
				P_1 |= ArUXxRQjNxdGMClXoSfJHOBOeIFG.Y;
			}
			return result;
		}

		private bool JpZNcRUNgGVjCZbovHLkGZmKQhKtA(Vector3 P_0)
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

		private bool PusPmDPfgzLoNitADCcgRlRAvfpn(Vector3 P_0)
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

		private Vector3 LYcrRcZeaRGJGYTYZMynNADxDqvP(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 ZdfZDJcmxccyueawTvPvRjmvATiiA(ExpandableArray_DataContainer<HIDGyroscope.GiuyxAjgsLMZoyJQQDMOmNkokChH> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				HIDGyroscope.GiuyxAjgsLMZoyJQQDMOmNkokChH giuyxAjgsLMZoyJQQDMOmNkokChH = P_0[i];
				result += LbUGqsKCYksraRGeRGWkXySmHhYf(giuyxAjgsLMZoyJQQDMOmNkokChH.cWevxravOZkFimTGMKQZfvGPQDgd, giuyxAjgsLMZoyJQQDMOmNkokChH.EUSnZeZyQsAWYltoKOVynUanzgdH);
			}
			return result;
		}

		private Vector3 LbUGqsKCYksraRGeRGWkXySmHhYf(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int bpJCbkMzvqjcNXBJScKyretLgQYJ(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void AQVawaEyGNuZXgSdhmRFdQjeCvKDA(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void CuYEmjCFzRlMfUXboXOgjeQqYCINA(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float CSqJsCrHmksOmRTOFKiLxANSfqCeA()
		{
			return FfXUzcYalLLnJcCLYGpHTlHfXpkL;
		}

		private void CtbuUfmtzHRdXjUVtJNcCZbAktsG(NativeBuffer P_0, HIDTouchpad.TouchData[] P_1)
		{
			int num = 33 + uQlulqGmyXlCDXQnNyECXNewRLPE;
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
			P_1[0].touchId = gdvFXdELMlWgwAKhzYgMikUNEHRHb(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = gdvFXdELMlWgwAKhzYgMikUNEHRHb(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int gdvFXdELMlWgwAKhzYgMikUNEHRHb(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				zhzQplqdoUXBMcpALXxqyhqbKkqp[P_0] = -1;
				QGCOkbTuqwfETesalWfBLbcANhsw[P_0] = P_2;
				return -1;
			}
			if (P_2 != QGCOkbTuqwfETesalWfBLbcANhsw[P_0])
			{
				int dgyexdtEHVNiDOVvlLsXmPXucPPD = DgyexdtEHVNiDOVvlLsXmPXucPPD;
				if (DgyexdtEHVNiDOVvlLsXmPXucPPD == int.MaxValue)
				{
					DgyexdtEHVNiDOVvlLsXmPXucPPD = 0;
				}
				else
				{
					DgyexdtEHVNiDOVvlLsXmPXucPPD++;
				}
				QGCOkbTuqwfETesalWfBLbcANhsw[P_0] = P_2;
				zhzQplqdoUXBMcpALXxqyhqbKkqp[P_0] = dgyexdtEHVNiDOVvlLsXmPXucPPD;
				return dgyexdtEHVNiDOVvlLsXmPXucPPD;
			}
			return zhzQplqdoUXBMcpALXxqyhqbKkqp[P_0];
		}

		private void nurlNNmVsjsdsCnATDafzrzscCqM()
		{
			ToFUJAbrcqwEStIHhCtTYCGuJJdS = true;
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
				pbALZBCFsKVcrJWudHDAnyazgIxN(IthEmOYLIWoAKOtZgfENDyquvbZK.Synchronous);
				if (BAuFkKITFvMAttdGniuGhpjWvGyJA != null)
				{
					BAuFkKITFvMAttdGniuGhpjWvGyJA.Dispose();
				}
				if (bRynnadDBHZKaeZhnvZQCWFBQuqu != null)
				{
					bRynnadDBHZKaeZhnvZQCWFBQuqu.Dispose();
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

		private static uint hOJzHVsnZhCpzPJfEOSFgzFITgYD(NativeBuffer P_0, int P_1)
		{
			uint num = 3940166985u;
			for (int i = 0; i < P_1; i++)
			{
				num = GooDBFBfQQFTBdPwEQQMLPrstloA[(byte)num ^ P_0[i]] ^ (num >> 8);
			}
			return num;
		}

		private static TQFPfqcQxMBPHHshMMwRLVrMcKvU HQtlQhQSDOoFGUMweVUWYTlrhxNd(DualSenseOtherLightBrightness P_0)
		{
			return P_0 switch
			{
				DualSenseOtherLightBrightness.High => TQFPfqcQxMBPHHshMMwRLVrMcKvU.High, 
				DualSenseOtherLightBrightness.Medium => TQFPfqcQxMBPHHshMMwRLVrMcKvU.Medium, 
				DualSenseOtherLightBrightness.Low => TQFPfqcQxMBPHHshMMwRLVrMcKvU.Low, 
				_ => throw new NotImplementedException(), 
			};
		}

		private static DualSenseOtherLightBrightness aqVnUrGFcacgbdrxKgMoYdKjDsai(TQFPfqcQxMBPHHshMMwRLVrMcKvU P_0)
		{
			return P_0 switch
			{
				TQFPfqcQxMBPHHshMMwRLVrMcKvU.High => DualSenseOtherLightBrightness.High, 
				TQFPfqcQxMBPHHshMMwRLVrMcKvU.Medium => DualSenseOtherLightBrightness.Medium, 
				TQFPfqcQxMBPHHshMMwRLVrMcKvU.Low => DualSenseOtherLightBrightness.Low, 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
