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
	internal class DualSenseDriver : HIDDeviceDriver, IDriver_DualSense, IControllerDriver, IDisposable
	{
		private enum OBaZVYatqKvZiAgjcIuAbujkeYYN
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum IXFAIPBnyLrCXUaqEyfQjuyZOmhm
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		public enum TnQcugdjkcYgUPReeiVMfzTBpgLz : byte
		{
			High = 0,
			Medium = 1,
			Low = 2
		}

		private const float ZWhNOpvCmwrlzDRiIOcjSXNrYhXA = 4f;

		private const int BnpCPrIyBWxEpDlVHLgwEbtFmDewB = 15;

		private const int ndjPetUUAbsNpUHldhafJhkSPngkA = 2;

		private const int KnlQDsoLGrzEhNnnTHVSicbMlGVDA = 0;

		private const int NIjgfcLDVzxxAURxAIEqkiEvKet = 1912;

		private const int RxtETVEslDZPqFaqvwLJeWAaTxxI = 0;

		private const int yrsNjbdMwFQgIjAbWUWjvNSbbPzO = 941;

		private const bool etCZximRrDTBizYiCmeJWhJpERfJ = false;

		private const bool vFvBYNKQjAbuJiNeyOmUGLGQVnAjA = true;

		private const float QcjffWtWDUHjuiDlvLbWOppNTaRAA = 2.5f;

		private const int GzGEFfCsKjMkMEKNAOqgownJSFRXA = 0;

		private const int RPXXHpmDycWDQefKRkEpdfItnCzt = 0;

		private const int IZQOACNdwPGKOSTVoqslIBAjeAKbA = 1;

		private const int vYMhiIvnIAemEvpyebabReiREqIp = 0;

		private const int lYTapkHMdKFWjoKBpoNaUMzvWUBW = 0;

		private const int qCOoRCKNQCamlIjmEDsxlLhByEty = 0;

		private const int ZdJqqShxiyFBUnbSlHMNhxMmBdNX = 1;

		private const int iHBwBHoCWmeAzhTnPFsLpiCYqUADb = 49;

		private const int OCsVbikpmMFaPBdvKLXrWgVLhCyJA = 0;

		private const int fGBghIiKfPddkGTjgLgOUeDHCoorb = 1;

		private const int CwDKOniJDfNNuSAQPzxAMolliiNG = 64;

		private const int YEauCMRQYuxvgAjKgcHZWvirJRlk = 48;

		private const int igjwEOFtgPlrgHKgdcFhqiURlcYH = 547;

		private const int toeemATeEVPIQCvnWABQYLYafRZf = 64;

		private const int KFodBnOxGxKWDFblfidcFjnlgUYZ = 547;

		private const int PnkZXGKgLrDRvvvfHztUwKsAfIoj = 1;

		private const int sJPyelcNmPbbtjhKQRjiZdqkoBxK = 2;

		private const int HUMXsLcfKGFLELiLJUSuAZInjodo = 3;

		private const int dNSiBXdHnjBZlHYvwZeMtbXIarGL = 4;

		private const int sDBWVMWQEayANhcaefQJUgkUUsOF = 5;

		private const int rHylcjdmHiMLFZFxJMWBtgXXjBGr = 6;

		private const int YnDecZJjXrLhVekNcazZnFlsjuqbA = 8;

		private const int qbSgNJIdTuFGzDxysdygAKqXvpzlA = 22;

		private const int IfkHAtfLWaTcqLZdsxYCATymYuqN = 16;

		private const int RKpfPZjzlGHjrMdIAmREjjivxCytA = 33;

		private const int aMwknLnNoRvmVzRVLCjqvJOzNody = 8;

		private const int CYZZRdQRXOFDsgjmWcAkiIOiPVnnb = 9;

		private const int aRVkLKxpbEAOVKFdALkqSuVEjNWGA = 10;

		private const int JXpIByoROzEVDGhyVLbMUtsqqBMS = 28;

		private const int HWwzZgaKGVPpFpiUnagnfnSfGetr = 54;

		private const int OdZOraatAvdkTCJsGnKoyyiUPkvmA = 55;

		private const int BkNmiOITJPznnwfxccnfvrRzcvTHA = 54;

		private const bool cerPZjIZdBjiodYNmIzosQlNFeoE = true;

		private const int xheCUVVHZavePdEabCOPlcEkqvfV = 60;

		private const int DVQIzQQOKTKIgQwVABiyMexFhWx = 60;

		private const int BrXIRoeLZvwPlsZZSTGPeiQsHJxO = 3000000;

		private const float qqqnZzGYZEeCdULjuXBXTehBHyPt = 8192f;

		private const float IgZWevJyUpZAtnMEDLqgQnRwuRBG = 0.0010652969f;

		private const float JZGHsfMJMbLjKlTnVcreBNhNfAqj = 0.06103702f;

		private const bool CIufDfnSfHeWYuniZevADLbligrbA = true;

		private const bool lrQLGONUeHhYqudiMwZXCrGIlsAC = true;

		private const bool uevuypcXgAbkTCbGyBsqsISJoMZu = true;

		private const bool SztCGnIYgRJQXCFknIfZEvbhTrQOb = true;

		private const float vAlleHMjiBCEfmWGlHTgHKROvcye = 4096f;

		private const float nTlDtdcKrhjfRNimPHzXGnixeUFh = 16384f;

		private const float cUoNcJQyEyEQZJwjAFstQcdZJNbF = 16777216f;

		private const float bYUTCPqpgjCbyCZUzSaVdmXRmRbo = 268435460f;

		private const float MjFtyMeDljXEnCbNJdBgTgjRUuuJ = 0.01999998f;

		private const float SORxQheKSFunRLFtzlKlOnOBFgXt = 8192f;

		private const float TQFdMqdEwUCfKJHoRFfdEVATkiwUA = 0.98f;

		private const float gfzYGcnWwurkcMXmVlphRuOYNeak = 45f;

		private const float kPgNrnQGYyEbTaWVDrRJAQeajiGE = 20f;

		private readonly bool qfTxgCOSAoJkUIAPoREXnHdrbGSc;

		private readonly int JPAfONCteqOBqHnvHsyHImvwlmgH;

		private readonly int LUsKrdnSpcMwxiLuPMQsCewIFjkv;

		private readonly bool CemdVtmyDJThFHmSqFifVuGchyZZ;

		private readonly byte VjvAOCHdmYsCGaIYwGreXJHTwdYP;

		private readonly int BMqXQMgavsZUCLRIgMToiPoAGRKY;

		private readonly int RoDGRLcoNShnBoMXDoiAJjCTMguR;

		private readonly int gNkbpaZYpjOhGFhFxeZFhbrbrvtX;

		private readonly int xzKGwZKmnLofILqanNKSzXrwLpTs;

		private readonly int IzuObBlsrMFzyaktxMWQBmhwfnSyA;

		private readonly int zjtBoqQsTkPtRiYtjfucPFfIMjmE;

		private readonly NativeBuffer TTrljGJBMLdpyvXoBFfPLiDNgpCh;

		private readonly NativeBuffer pXfEwsioChlrjyweXzuJiTjEDYOO;

		private OutputReport CqNdoYwozLrrVHPAspUOKcyUjnaE;

		private readonly Func<OutputReport, bool> pgybONworqVQNnnAvdFPgOuQNGro;

		private readonly Action<OutputReport> lSvsGtMuQygoNnlAWxdEdfWUPNJx;

		private bool LHODIGytjUKtVbRERWzMgYktdtTG;

		private bool ZTwkFDJgFAbmIdNDgyDwoqpIcCKjA;

		private double MHtEPtLMidQDRZiHuoocCEBeeQIA;

		private byte AIRYcPfGBggApACzqPsMnezhEqQO;

		private bool yVgfGTJrXqJdmvxhVWjGmohqnVcHA;

		private bool SVMxfMaHzuCApifnjnBMtVjBtkKz;

		private bool pqbRJyniwIikdNdphqzwtnthPGCy;

		private Quaternion GYEGQrmPAQEVJdjxpmHaRprPUZQGA = Quaternion.identity;

		private DualSenseMicrophoneLightMode GJhgvmdUrrkUyZCAMrVGArwzSRfCb;

		private TnQcugdjkcYgUPReeiVMfzTBpgLz knndJNipvziRzUIEWVubaneMQVwi;

		private DualSensePlayerLightFlags hGsyPWRaBKifZjicqqMLHlPviZH;

		private bool hsHDuabZDLIYwUGGTTxwmgiEeoeq;

		private bool cKoFNhGVopmjDVfGsLRQHFBLhWOi;

		private uint nwQtPzLfBQvYsbvzBDBepRtEPQkS;

		private float TMOLyRkehoSYweAyetYlQlwvVEl;

		private double DKmIIXBBpSgVwAvuEqYqErQckeRbA;

		private float wamoCRedAsbONbXLppvUUqqfPQiJ;

		private byte urKyqFpDesTXhksRBwqTbIMQxRdQ;

		private byte ARTGYbYKUZhGkqioscGVeKCtATLA;

		private Quaternion wBnAJcHiGMKGGxnpodajnbyXwVPn = Quaternion.identity;

		private Quaternion MuScoeByVLOlpHtRQhAJCIQWGfFE = Quaternion.identity;

		private bool UHvFBrQmBAKcCWchwHlHukttZaaJ;

		private int RmbbxteJZrmeSSIONQcYGNbvgElQ;

		private int[] zDsFyzhdjoJgJBsZhtUnHMKmFGMib = new int[2];

		private int[] CDBDblfQhIntEZijXiKQSlWXmZCyA = new int[2];

		private static uint[] UtbGwLYEqsipGbtOOboBhEreHlDk = new uint[256]
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

		private const uint ugvacqMKlnLXxYHWlSJlQIobEZDS = 3940166985u;

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
				num = ((!qfTxgCOSAoJkUIAPoREXnHdrbGSc) ? ((float)(AIRYcPfGBggApACzqPsMnezhEqQO - 1) * 10f) : ((float)(AIRYcPfGBggApACzqPsMnezhEqQO + 2) * 10f));
				return MathTools.Clamp(num, 0f, 100f);
			}
		}

		bool IDriver_DualSense.BatteryCharging => yVgfGTJrXqJdmvxhVWjGmohqnVcHA;

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
				return (int)urKyqFpDesTXhksRBwqTbIMQxRdQ;
			}
			set
			{
				urKyqFpDesTXhksRBwqTbIMQxRdQ = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				LHODIGytjUKtVbRERWzMgYktdtTG = true;
				if (urKyqFpDesTXhksRBwqTbIMQxRdQ == 0 && ARTGYbYKUZhGkqioscGVeKCtATLA == 0)
				{
					ZTwkFDJgFAbmIdNDgyDwoqpIcCKjA = true;
				}
			}
		}

		float IDriver_DualSense.LightFlashOffDuration
		{
			get
			{
				return (int)ARTGYbYKUZhGkqioscGVeKCtATLA;
			}
			set
			{
				ARTGYbYKUZhGkqioscGVeKCtATLA = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				LHODIGytjUKtVbRERWzMgYktdtTG = true;
				if (urKyqFpDesTXhksRBwqTbIMQxRdQ == 0 && ARTGYbYKUZhGkqioscGVeKCtATLA == 0)
				{
					ZTwkFDJgFAbmIdNDgyDwoqpIcCKjA = true;
				}
			}
		}

		DualSenseMicrophoneLightMode IDriver_DualSense.microphoneLightMode
		{
			get
			{
				return GJhgvmdUrrkUyZCAMrVGArwzSRfCb;
			}
			set
			{
				GJhgvmdUrrkUyZCAMrVGArwzSRfCb = value;
				LHODIGytjUKtVbRERWzMgYktdtTG = true;
			}
		}

		DualSenseOtherLightBrightness IDriver_DualSense.otherLightBrightness
		{
			get
			{
				return eUuetWJpEXLuhdimsNpicygazSPA(knndJNipvziRzUIEWVubaneMQVwi);
			}
			set
			{
				knndJNipvziRzUIEWVubaneMQVwi = ZWsygYZnNkZCDOaHCBoFwhdwgNnbA(value);
				LHODIGytjUKtVbRERWzMgYktdtTG = true;
			}
		}

		DualSensePlayerLightFlags IDriver_DualSense.playerLights
		{
			get
			{
				return hGsyPWRaBKifZjicqqMLHlPviZH;
			}
			set
			{
				hGsyPWRaBKifZjicqqMLHlPviZH = value;
				LHODIGytjUKtVbRERWzMgYktdtTG = true;
			}
		}

		Vector3 IDriver_DualSense.AccelerometerValue => ZBzyUyMjNboANEVSxFsSzzdwYdZC(accelerometers[0].rawValue);

		Vector3 IDriver_DualSense.AccelerometerValueRaw => new Vector3(accelerometers[0].rawValue[0], accelerometers[0].rawValue[1], accelerometers[0].rawValue[2]);

		Vector3 IDriver_DualSense.GyroscopeValue => eZKsqujJctiktDDYhNltDXVhDVUUA(gyroscopes[0].events);

		Vector3 IDriver_DualSense.GyroscopeValueRaw => new Vector3(gyroscopes[0].rawValue[0], gyroscopes[0].rawValue[1], gyroscopes[0].rawValue[2]);

		Vector3 IDriver_DualSense.LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);
				return PHTBTeBvZUmJrPUffUhrfBWdWdsU(vector, TMOLyRkehoSYweAyetYlQlwvVEl);
			}
		}

		Vector3 IDriver_DualSense.LastGyroscopeValueRaw => new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]);

		Quaternion IDriver_DualSense.Orientation => GYEGQrmPAQEVJdjxpmHaRprPUZQGA;

		int IDriver_DualSense.MaxTouches => 2;

		public void ResetOrientation()
		{
			GYEGQrmPAQEVJdjxpmHaRprPUZQGA = Quaternion.identity;
			UHvFBrQmBAKcCWchwHlHukttZaaJ = false;
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
			urKyqFpDesTXhksRBwqTbIMQxRdQ = 0;
			ARTGYbYKUZhGkqioscGVeKCtATLA = 0;
			LHODIGytjUKtVbRERWzMgYktdtTG = true;
			ZTwkFDJgFAbmIdNDgyDwoqpIcCKjA = true;
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
			JPAfONCteqOBqHnvHsyHImvwlmgH = P_0.hatZeroValue;
			LUsKrdnSpcMwxiLuPMQsCewIFjkv = P_0.hatSpan;
			BMqXQMgavsZUCLRIgMToiPoAGRKY = P_0.inputReportLength;
			RoDGRLcoNShnBoMXDoiAJjCTMguR = P_0.outputReportLength;
			pgybONworqVQNnnAvdFPgOuQNGro = P_0.synchronousWriteOutputReportDelegate;
			lSvsGtMuQygoNnlAWxdEdfWUPNJx = P_0.asynchronousWriteOutputReportDelegate;
			qfTxgCOSAoJkUIAPoREXnHdrbGSc = P_0.connectionType == DeviceConnectionType.Bluetooth;
			if (qfTxgCOSAoJkUIAPoREXnHdrbGSc)
			{
				RoDGRLcoNShnBoMXDoiAJjCTMguR = 547;
			}
			else
			{
				RoDGRLcoNShnBoMXDoiAJjCTMguR = 48;
			}
			TTrljGJBMLdpyvXoBFfPLiDNgpCh = new NativeBuffer(64);
			pXfEwsioChlrjyweXzuJiTjEDYOO = new NativeBuffer(RoDGRLcoNShnBoMXDoiAJjCTMguR);
			CqNdoYwozLrrVHPAspUOKcyUjnaE = new OutputReport(pXfEwsioChlrjyweXzuJiTjEDYOO.Pointer, pXfEwsioChlrjyweXzuJiTjEDYOO.Length, RoDGRLcoNShnBoMXDoiAJjCTMguR);
			lights = new HIDLight[1]
			{
				new HIDLight(11, 24, 28)
			};
			lights[0].ValueChangedEvent += drqBWFhjlHqStEKDrQReIVDfNyOdb;
			vibrationMotors = new HIDVibrationMotor[2]
			{
				new HIDVibrationMotor(0, 255),
				new HIDVibrationMotor(0, 255)
			};
			vibrationMotors[0].ValueChangedEvent += drqBWFhjlHqStEKDrQReIVDfNyOdb;
			vibrationMotors[1].ValueChangedEvent += drqBWFhjlHqStEKDrQReIVDfNyOdb;
			if (qfTxgCOSAoJkUIAPoREXnHdrbGSc)
			{
				byte[] array = P_0.getFeatureReportDelegate(5);
				CemdVtmyDJThFHmSqFifVuGchyZZ = array != null && array.Length != 0;
				if (CemdVtmyDJThFHmSqFifVuGchyZZ)
				{
					fpyfJyWDtuCpIcSyeqWVAzUffdFU(WweBMfPLHmZJRWKTQOAYhINlTVzC.Synchronous);
				}
			}
			else
			{
				CemdVtmyDJThFHmSqFifVuGchyZZ = true;
				CemdVtmyDJThFHmSqFifVuGchyZZ = fpyfJyWDtuCpIcSyeqWVAzUffdFU(WweBMfPLHmZJRWKTQOAYhINlTVzC.Synchronous);
			}
			if (!CemdVtmyDJThFHmSqFifVuGchyZZ)
			{
				throw new Exception("Special features not supported so just treat this as a standard HID device.");
			}
			VjvAOCHdmYsCGaIYwGreXJHTwdYP = 1;
			gNkbpaZYpjOhGFhFxeZFhbrbrvtX = 0;
			if (qfTxgCOSAoJkUIAPoREXnHdrbGSc && CemdVtmyDJThFHmSqFifVuGchyZZ)
			{
				VjvAOCHdmYsCGaIYwGreXJHTwdYP = 49;
				gNkbpaZYpjOhGFhFxeZFhbrbrvtX = 1;
			}
			xzKGwZKmnLofILqanNKSzXrwLpTs = 8 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX;
			IzuObBlsrMFzyaktxMWQBmhwfnSyA = 9 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX;
			zjtBoqQsTkPtRiYtjfucPFfIMjmE = 10 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX;
			buttons = new HIDButton[15];
			for (int i = 0; i < 15; i++)
			{
				buttons[i] = new HIDButton(VjvAOCHdmYsCGaIYwGreXJHTwdYP, new HIDControllerElement.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new HIDAxis[6]
			{
				new HIDAxis(VjvAOCHdmYsCGaIYwGreXJHTwdYP, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(VjvAOCHdmYsCGaIYwGreXJHTwdYP, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(VjvAOCHdmYsCGaIYwGreXJHTwdYP, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(VjvAOCHdmYsCGaIYwGreXJHTwdYP, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(VjvAOCHdmYsCGaIYwGreXJHTwdYP, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 5 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new HIDAxis(VjvAOCHdmYsCGaIYwGreXJHTwdYP, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 6 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX,
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
				new HIDHat(VjvAOCHdmYsCGaIYwGreXJHTwdYP, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 8 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, tvIaJyPIiYIWMfVAilDrDRRGRYoeA)
			};
			accelerometers = new HIDAccelerometer[1]
			{
				new HIDAccelerometer(VjvAOCHdmYsCGaIYwGreXJHTwdYP, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 22 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX,
					bitSize = 48
				}, 3, KTEpbkTAPhgaOeHeFkcADpDfEBcP)
			};
			gyroscopes = new HIDGyroscope[1]
			{
				new HIDGyroscope(P_0.updateLoopSetting, VjvAOCHdmYsCGaIYwGreXJHTwdYP, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 16 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX,
					bitSize = 48
				}, 3, 60, UnTRddUHkdqtsDTiMIdhWumrEicx, SpvyzUkplIfpxTSXdILIRWzNEryK)
			};
			touchpads = new HIDTouchpad[1]
			{
				new HIDTouchpad(VjvAOCHdmYsCGaIYwGreXJHTwdYP, new HIDTouchpad.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					dataIndex = 33 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX,
					bitSize = 48
				}, 60, MwyjGtzepteDUtIVRiazceTZUOIl)
			};
			DKmIIXBBpSgVwAvuEqYqErQckeRbA = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			XsntNnmRiogIqvbbfQLzBlcRBCoc();
			lXJzMZDZzcjBqJcxTyqTZZMyokXV(WweBMfPLHmZJRWKTQOAYhINlTVzC.Asynchronous);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < TTrljGJBMLdpyvXoBFfPLiDNgpCh.Length)
			{
				return false;
			}
			wamoCRedAsbONbXLppvUUqqfPQiJ = (float)(timestamp - DKmIIXBBpSgVwAvuEqYqErQckeRbA);
			DKmIIXBBpSgVwAvuEqYqErQckeRbA = timestamp;
			TTrljGJBMLdpyvXoBFfPLiDNgpCh.Write(inputReportPtr, inputReportLength, TTrljGJBMLdpyvXoBFfPLiDNgpCh.Length);
			lnGVTgJReAkPbdeKLDBYxTcCwYoE(TTrljGJBMLdpyvXoBFfPLiDNgpCh);
			TpgxkjfEFWeDbFtcKvMddwcRkJbwA(TTrljGJBMLdpyvXoBFfPLiDNgpCh, timestamp);
			HIDControllerElement[] array = axes;
			aCepJqUjIxAqQfNDlILrhTVhbmIzA(array, TTrljGJBMLdpyvXoBFfPLiDNgpCh, timestamp);
			array = hats;
			aCepJqUjIxAqQfNDlILrhTVhbmIzA(array, TTrljGJBMLdpyvXoBFfPLiDNgpCh, timestamp);
			array = accelerometers;
			aCepJqUjIxAqQfNDlILrhTVhbmIzA(array, TTrljGJBMLdpyvXoBFfPLiDNgpCh, timestamp);
			array = gyroscopes;
			aCepJqUjIxAqQfNDlILrhTVhbmIzA(array, TTrljGJBMLdpyvXoBFfPLiDNgpCh, timestamp);
			array = touchpads;
			aCepJqUjIxAqQfNDlILrhTVhbmIzA(array, TTrljGJBMLdpyvXoBFfPLiDNgpCh, timestamp);
			yVgfGTJrXqJdmvxhVWjGmohqnVcHA = (TTrljGJBMLdpyvXoBFfPLiDNgpCh[54 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX] & 8) != 0;
			SVMxfMaHzuCApifnjnBMtVjBtkKz = (TTrljGJBMLdpyvXoBFfPLiDNgpCh[55 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX] & 0x20) != 0;
			AIRYcPfGBggApACzqPsMnezhEqQO = (byte)(TTrljGJBMLdpyvXoBFfPLiDNgpCh[55 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX] & 0xF);
			pqbRJyniwIikdNdphqzwtnthPGCy = (TTrljGJBMLdpyvXoBFfPLiDNgpCh[54 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX] & 1) != 0;
			wxTLsRUatbAbhQKxYnQQKEgbXBOx();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualSenseExtension(this);
		}

		private void lXJzMZDZzcjBqJcxTyqTZZMyokXV(WweBMfPLHmZJRWKTQOAYhINlTVzC P_0)
		{
			if (LHODIGytjUKtVbRERWzMgYktdtTG)
			{
				fpyfJyWDtuCpIcSyeqWVAzUffdFU(P_0);
				LHODIGytjUKtVbRERWzMgYktdtTG = false;
			}
		}

		private bool fpyfJyWDtuCpIcSyeqWVAzUffdFU(WweBMfPLHmZJRWKTQOAYhINlTVzC P_0)
		{
			ybboMHSkYafUyBXECHAoGRocCpdF();
			bool result = MgNDcpJAzFiVIfaBFnRqWKDZnqxOA(P_0);
			if (ZTwkFDJgFAbmIdNDgyDwoqpIcCKjA)
			{
				result = MgNDcpJAzFiVIfaBFnRqWKDZnqxOA(P_0);
				ZTwkFDJgFAbmIdNDgyDwoqpIcCKjA = false;
			}
			return result;
		}

		private void ybboMHSkYafUyBXECHAoGRocCpdF()
		{
			if (qfTxgCOSAoJkUIAPoREXnHdrbGSc && CemdVtmyDJThFHmSqFifVuGchyZZ)
			{
				pXfEwsioChlrjyweXzuJiTjEDYOO[0] = 49;
				pXfEwsioChlrjyweXzuJiTjEDYOO[1] = 2;
				RqaQGHdJYayxSIYDyoXUXndhOHSd(pXfEwsioChlrjyweXzuJiTjEDYOO, 2);
				uint num = hlYceZhZeDbLiXFQslVHQHWLtich(pXfEwsioChlrjyweXzuJiTjEDYOO, 74);
				pXfEwsioChlrjyweXzuJiTjEDYOO[74] = (byte)(num & 0xFF);
				pXfEwsioChlrjyweXzuJiTjEDYOO[75] = (byte)((num & 0xFF00) >> 8);
				pXfEwsioChlrjyweXzuJiTjEDYOO[76] = (byte)((num & 0xFF0000) >> 16);
				pXfEwsioChlrjyweXzuJiTjEDYOO[77] = (byte)((num & 0xFF000000u) >> 24);
			}
			else
			{
				pXfEwsioChlrjyweXzuJiTjEDYOO[0] = 2;
				RqaQGHdJYayxSIYDyoXUXndhOHSd(pXfEwsioChlrjyweXzuJiTjEDYOO, 1);
			}
		}

		private void RqaQGHdJYayxSIYDyoXUXndhOHSd(NativeBuffer P_0, int P_1)
		{
			P_0[P_1] = byte.MaxValue;
			P_0[1 + P_1] = 247;
			P_0[2 + P_1] = (byte)vibrationMotors[1].SpeedRaw;
			P_0[3 + P_1] = (byte)vibrationMotors[0].SpeedRaw;
			P_0[8 + P_1] = (byte)GJhgvmdUrrkUyZCAMrVGArwzSRfCb;
			P_0[43 + P_1] = (byte)hGsyPWRaBKifZjicqqMLHlPviZH;
			if (hsHDuabZDLIYwUGGTTxwmgiEeoeq)
			{
				P_0[43 + P_1] = (byte)(P_0[43 + P_1] & -33);
			}
			else
			{
				P_0[43 + P_1] |= 32;
			}
			P_0[38 + P_1] = 3;
			P_0[41 + P_1] = (byte)(cKoFNhGVopmjDVfGsLRQHFBLhWOi ? 1 : 2);
			P_0[42 + P_1] = (byte)knndJNipvziRzUIEWVubaneMQVwi;
			P_0[44 + P_1] = lights[0].ColorRRaw;
			P_0[45 + P_1] = lights[0].ColorGRaw;
			P_0[46 + P_1] = lights[0].ColorBRaw;
		}

		private bool MgNDcpJAzFiVIfaBFnRqWKDZnqxOA(WweBMfPLHmZJRWKTQOAYhINlTVzC P_0)
		{
			MHtEPtLMidQDRZiHuoocCEBeeQIA = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case WweBMfPLHmZJRWKTQOAYhINlTVzC.Synchronous:
				if (pgybONworqVQNnnAvdFPgOuQNGro == null)
				{
					return false;
				}
				return pgybONworqVQNnnAvdFPgOuQNGro(CqNdoYwozLrrVHPAspUOKcyUjnaE);
			case WweBMfPLHmZJRWKTQOAYhINlTVzC.Asynchronous:
				if (lSvsGtMuQygoNnlAWxdEdfWUPNJx == null)
				{
					return false;
				}
				lSvsGtMuQygoNnlAWxdEdfWUPNJx(CqNdoYwozLrrVHPAspUOKcyUjnaE);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void TpgxkjfEFWeDbFtcKvMddwcRkJbwA(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[xzKGwZKmnLofILqanNKSzXrwLpTs];
			buttons[0].SetValue((b & 0x10) != 0, P_1);
			buttons[1].SetValue((b & 0x20) != 0, P_1);
			buttons[2].SetValue((b & 0x40) != 0, P_1);
			buttons[3].SetValue((b & 0x80) != 0, P_1);
			b = P_0[IzuObBlsrMFzyaktxMWQBmhwfnSyA];
			buttons[4].SetValue((b & 1) != 0, P_1);
			buttons[5].SetValue((b & 2) != 0, P_1);
			buttons[6].SetValue((b & 4) != 0, P_1);
			buttons[7].SetValue((b & 8) != 0, P_1);
			buttons[8].SetValue((b & 0x10) != 0, P_1);
			buttons[9].SetValue((b & 0x20) != 0, P_1);
			buttons[10].SetValue((b & 0x40) != 0, P_1);
			buttons[11].SetValue((b & 0x80) != 0, P_1);
			b = P_0[zjtBoqQsTkPtRiYtjfucPFfIMjmE];
			buttons[12].SetValue((b & 1) != 0, P_1);
			buttons[13].SetValue((b & 2) != 0, P_1);
			if (CemdVtmyDJThFHmSqFifVuGchyZZ)
			{
				buttons[14].SetValue((b & 4) != 0, P_1);
			}
		}

		private void aCepJqUjIxAqQfNDlILrhTVhbmIzA(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].UpdateValue(P_1, P_2);
			}
		}

		private void XsntNnmRiogIqvbbfQLzBlcRBCoc()
		{
			if (isVibrating && ReInput.realTime >= MHtEPtLMidQDRZiHuoocCEBeeQIA)
			{
				LHODIGytjUKtVbRERWzMgYktdtTG = true;
			}
		}

		private void lnGVTgJReAkPbdeKLDBYxTcCwYoE(NativeBuffer P_0)
		{
			if (CemdVtmyDJThFHmSqFifVuGchyZZ)
			{
				uint num = TTrljGJBMLdpyvXoBFfPLiDNgpCh.ReadUInt(28 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX);
				float tMOLyRkehoSYweAyetYlQlwvVEl;
				if (num != nwQtPzLfBQvYsbvzBDBepRtEPQkS)
				{
					uint num2 = (uint)((num >= nwQtPzLfBQvYsbvzBDBepRtEPQkS) ? (num - nwQtPzLfBQvYsbvzBDBepRtEPQkS) : ((long)num + 4294967295L - nwQtPzLfBQvYsbvzBDBepRtEPQkS));
					tMOLyRkehoSYweAyetYlQlwvVEl = (float)num2 / 3000000f;
				}
				else
				{
					uint num2 = 0u;
					tMOLyRkehoSYweAyetYlQlwvVEl = 0f;
				}
				nwQtPzLfBQvYsbvzBDBepRtEPQkS = num;
				TMOLyRkehoSYweAyetYlQlwvVEl = tMOLyRkehoSYweAyetYlQlwvVEl;
			}
		}

		private void wxTLsRUatbAbhQKxYnQQKEgbXBOx()
		{
			if (CemdVtmyDJThFHmSqFifVuGchyZZ && !(TMOLyRkehoSYweAyetYlQlwvVEl <= 0f))
			{
				Vector3 vector = PHTBTeBvZUmJrPUffUhrfBWdWdsU(new Vector3(gyroscopes[0].lastRawValue[0], gyroscopes[0].lastRawValue[1], gyroscopes[0].lastRawValue[2]), TMOLyRkehoSYweAyetYlQlwvVEl);
				dffGVNQdPdyEIokjmPBdAjWMGbcV(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].rawValue[0] * -1f, accelerometers[0].rawValue[1] * -1f, accelerometers[0].rawValue[2] * -1f);
				HxcBRjJarsJggjdFqXgLHSaWuWwU(vector2, vector);
			}
		}

		private static bool dffGVNQdPdyEIokjmPBdAjWMGbcV(ref Vector3 P_0)
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

		private void HxcBRjJarsJggjdFqXgLHSaWuWwU(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && NkemJBnzajmCtQFKFidPXkhXeEyDA(P_0, out var iXFAIPBnyLrCXUaqEyfQjuyZOmhm))
			{
				Quaternion a = GYEGQrmPAQEVJdjxpmHaRprPUZQGA * quaternion;
				if (!UHvFBrQmBAKcCWchwHlHukttZaaJ)
				{
					UHvFBrQmBAKcCWchwHlHukttZaaJ = true;
					wBnAJcHiGMKGGxnpodajnbyXwVPn = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					MuScoeByVLOlpHtRQhAJCIQWGfFE = GYEGQrmPAQEVJdjxpmHaRprPUZQGA;
				}
				wBnAJcHiGMKGGxnpodajnbyXwVPn *= quaternion;
				MuScoeByVLOlpHtRQhAJCIQWGfFE *= quaternion;
				Quaternion b;
				if ((iXFAIPBnyLrCXUaqEyfQjuyZOmhm & IXFAIPBnyLrCXUaqEyfQjuyZOmhm.XZ) != IXFAIPBnyLrCXUaqEyfQjuyZOmhm.None)
				{
					b = HMQbMgCSTfxCPbjPyjlXRCMojgofb(P_0, a.eulerAngles.y);
				}
				else if ((iXFAIPBnyLrCXUaqEyfQjuyZOmhm & IXFAIPBnyLrCXUaqEyfQjuyZOmhm.Y) != IXFAIPBnyLrCXUaqEyfQjuyZOmhm.None)
				{
					b = OULYDwaJgtnPJLFFvgTNKGKWSScbA(P_0);
					Vector3 vector = MuScoeByVLOlpHtRQhAJCIQWGfFE * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				GYEGQrmPAQEVJdjxpmHaRprPUZQGA = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				GYEGQrmPAQEVJdjxpmHaRprPUZQGA *= quaternion;
				if (UHvFBrQmBAKcCWchwHlHukttZaaJ)
				{
					UHvFBrQmBAKcCWchwHlHukttZaaJ = false;
				}
			}
		}

		private static Quaternion acrEqmZhbOQOmhAAeCNHjiQIIkPkA(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = RDYHDQNnvRHgxigaelEmzeCDCfghA(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 RDYHDQNnvRHgxigaelEmzeCDCfghA(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion cwoLtKJwvHNuZZYMurIssIMgkTCg(Quaternion P_0, OBaZVYatqKvZiAgjcIuAbujkeYYN P_1)
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

		private float pHEGAeOknoZGihkYYcurYnfIlwDM(float P_0, float P_1)
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

		private Vector3 qGxZAwGnGqSlhaJCIETBkGVodwAo(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion HMQbMgCSTfxCPbjPyjlXRCMojgofb(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion OULYDwaJgtnPJLFFvgTNKGKWSScbA(Vector3 P_0, float P_1 = 0f)
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

		private float aoQMcggHPRuVQJBvkjzVAIZGATjd(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool vvOdvWqzbQCCFkyPKCYIrQqVkuED(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool NkemJBnzajmCtQFKFidPXkhXeEyDA(Vector3 P_0, out IXFAIPBnyLrCXUaqEyfQjuyZOmhm P_1)
		{
			P_0.Normalize();
			P_1 = IXFAIPBnyLrCXUaqEyfQjuyZOmhm.None;
			bool result = false;
			if (ZLEejVATtuBONyHrNtcrPrKVwHuY(P_0))
			{
				result = true;
				P_1 |= IXFAIPBnyLrCXUaqEyfQjuyZOmhm.XZ;
			}
			if (BrzGzXAGxTTNWgyLpqNfsrnDGDJSA(P_0))
			{
				result = true;
				P_1 |= IXFAIPBnyLrCXUaqEyfQjuyZOmhm.Y;
			}
			return result;
		}

		private bool ZLEejVATtuBONyHrNtcrPrKVwHuY(Vector3 P_0)
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

		private bool BrzGzXAGxTTNWgyLpqNfsrnDGDJSA(Vector3 P_0)
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

		private Vector3 ZBzyUyMjNboANEVSxFsSzzdwYdZC(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 eZKsqujJctiktDDYhNltDXVhDVUUA(RingBuffer<HIDGyroscope.OhjuMudkxrxhcFUaaGLQSPzGFPF> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				HIDGyroscope.OhjuMudkxrxhcFUaaGLQSPzGFPF ohjuMudkxrxhcFUaaGLQSPzGFPF = P_0[i];
				result += PHTBTeBvZUmJrPUffUhrfBWdWdsU(ohjuMudkxrxhcFUaaGLQSPzGFPF.stvAgpvMmtnJlkoKkQdWZaBKzoMT, ohjuMudkxrxhcFUaaGLQSPzGFPF.QrPZYcYyTMgjTnwjmdfpJlOyqPXW);
			}
			return result;
		}

		private Vector3 PHTBTeBvZUmJrPUffUhrfBWdWdsU(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int tvIaJyPIiYIWMfVAilDrDRRGRYoeA(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void KTEpbkTAPhgaOeHeFkcADpDfEBcP(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void UnTRddUHkdqtsDTiMIdhWumrEicx(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float SpvyzUkplIfpxTSXdILIRWzNEryK()
		{
			return TMOLyRkehoSYweAyetYlQlwvVEl;
		}

		private void MwyjGtzepteDUtIVRiazceTZUOIl(NativeBuffer P_0, HIDTouchpad.TouchData[] P_1)
		{
			int num = 33 + gNkbpaZYpjOhGFhFxeZFhbrbrvtX;
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
			P_1[0].touchId = qgwQQzWgVPxPxMgaLTLJMYgAJlvO(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = qgwQQzWgVPxPxMgaLTLJMYgAJlvO(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int qgwQQzWgVPxPxMgaLTLJMYgAJlvO(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				zDsFyzhdjoJgJBsZhtUnHMKmFGMib[P_0] = -1;
				CDBDblfQhIntEZijXiKQSlWXmZCyA[P_0] = P_2;
				return -1;
			}
			if (P_2 != CDBDblfQhIntEZijXiKQSlWXmZCyA[P_0])
			{
				int rmbbxteJZrmeSSIONQcYGNbvgElQ = RmbbxteJZrmeSSIONQcYGNbvgElQ;
				if (RmbbxteJZrmeSSIONQcYGNbvgElQ == int.MaxValue)
				{
					RmbbxteJZrmeSSIONQcYGNbvgElQ = 0;
				}
				else
				{
					RmbbxteJZrmeSSIONQcYGNbvgElQ++;
				}
				CDBDblfQhIntEZijXiKQSlWXmZCyA[P_0] = P_2;
				zDsFyzhdjoJgJBsZhtUnHMKmFGMib[P_0] = rmbbxteJZrmeSSIONQcYGNbvgElQ;
				return rmbbxteJZrmeSSIONQcYGNbvgElQ;
			}
			return zDsFyzhdjoJgJBsZhtUnHMKmFGMib[P_0];
		}

		private void drqBWFhjlHqStEKDrQReIVDfNyOdb()
		{
			LHODIGytjUKtVbRERWzMgYktdtTG = true;
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
				lXJzMZDZzcjBqJcxTyqTZZMyokXV(WweBMfPLHmZJRWKTQOAYhINlTVzC.Synchronous);
				if (TTrljGJBMLdpyvXoBFfPLiDNgpCh != null)
				{
					TTrljGJBMLdpyvXoBFfPLiDNgpCh.Dispose();
				}
				if (pXfEwsioChlrjyweXzuJiTjEDYOO != null)
				{
					pXfEwsioChlrjyweXzuJiTjEDYOO.Dispose();
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

		private static uint hlYceZhZeDbLiXFQslVHQHWLtich(NativeBuffer P_0, int P_1)
		{
			uint num = 3940166985u;
			for (int i = 0; i < P_1; i++)
			{
				num = UtbGwLYEqsipGbtOOboBhEreHlDk[(byte)num ^ P_0[i]] ^ (num >> 8);
			}
			return num;
		}

		private static TnQcugdjkcYgUPReeiVMfzTBpgLz ZWsygYZnNkZCDOaHCBoFwhdwgNnbA(DualSenseOtherLightBrightness P_0)
		{
			return P_0 switch
			{
				DualSenseOtherLightBrightness.High => TnQcugdjkcYgUPReeiVMfzTBpgLz.High, 
				DualSenseOtherLightBrightness.Medium => TnQcugdjkcYgUPReeiVMfzTBpgLz.Medium, 
				DualSenseOtherLightBrightness.Low => TnQcugdjkcYgUPReeiVMfzTBpgLz.Low, 
				_ => throw new NotImplementedException(), 
			};
		}

		private static DualSenseOtherLightBrightness eUuetWJpEXLuhdimsNpicygazSPA(TnQcugdjkcYgUPReeiVMfzTBpgLz P_0)
		{
			return P_0 switch
			{
				TnQcugdjkcYgUPReeiVMfzTBpgLz.High => DualSenseOtherLightBrightness.High, 
				TnQcugdjkcYgUPReeiVMfzTBpgLz.Medium => DualSenseOtherLightBrightness.Medium, 
				TnQcugdjkcYgUPReeiVMfzTBpgLz.Low => DualSenseOtherLightBrightness.Low, 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
