using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualSenseDriver : HIDDeviceDriver, IDriver_DualSense, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		private enum HFuggnUJsDeVgGmKHkYSKkWvdbcAA
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private enum hADcHjMYjcPjtWFHfwrtgUKVZrTe : byte
		{
			Off = 0,
			Feedback = 1,
			Weapon = 2,
			Vibration = 3,
			SlopeFeedback = 4
		}

		private enum KApSKUcifgvAjfIOpwgOGExlHEEk : byte
		{
			High = 0,
			Medium = 1,
			Low = 2
		}

		private enum XBCaeFDqCpLqQePUMGfGKwkVpyQfA : byte
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			TemperatureOutOfRange = 10,
			TemperatureError = 11,
			ChargingError = 15
		}

		private enum hAJbqqQiqLaIOEoMcIlvqpsMEDlJ
		{
			NotCharging = 0,
			Discharging = 1,
			Charging = 2,
			Full = 3,
			Unknown = 4
		}

		private enum yFcgLwGlIHIeaxwMDBOLYlatoMOIb : byte
		{
			None = 0,
			CompatibleVibrationMode1 = 1,
			HapticsSelect = 2,
			RightTriggerEffect = 4,
			LeftTriggerEffect = 8,
			AudioVolume = 0x10,
			ToggleInternalSpeaker = 0x20,
			MicrophoneVolume = 0x40,
			ToggleInternalMicOrExternalSpeaker = 0x80
		}

		private enum NLACDWZGtlQJwMhYRogTuNLBxSPP : byte
		{
			None = 0,
			MicrophoneLEDControl = 1,
			PowerSaveControl = 2,
			LightbarControl = 4,
			TurnOffLEDs = 8,
			PlayerIndicatorLEDControl = 0x10,
			Unknown1 = 0x20,
			ChangeOverallMotorEffectPower = 0x40,
			Unknown2 = 0x80
		}

		private enum oJMfAmcKMdKqvfVSNZXzURcsbEnP : byte
		{
			None = 0,
			OtherLightBrightnessControl = 1,
			LightbarSetupControl = 2,
			CompatibleVibrationMode2 = 4
		}

		private struct JlYpRfrdIXccKueqbshKpRRPCGiB
		{
			public byte PxpKcGueaTDoQAqGAEykdoTndVVwA;

			public byte TAWTkBeNbVrSBwWVNabcodUMDHXR => 0;

			public byte hcjliVTTVJYlLkGmHjPVDTfwevrp => 0;

			public JlYpRfrdIXccKueqbshKpRRPCGiB(byte P_0)
			{
				PxpKcGueaTDoQAqGAEykdoTndVVwA = 0;
			}
		}

		private static class uguqmAogkuGhJgjgEzqspqSVBOGW
		{
			public static class cNIPfKtpMhlpqXZsUFXTeWLqGgUx
			{
				[Serializable]
				private sealed class orIifgvwnZMnyEpTXMWGpnxZOOpp
				{
					public static readonly orIifgvwnZMnyEpTXMWGpnxZOOpp _003C_003E9;

					public static Func<byte, bool> _003C_003E9__4_0;

					public static Func<byte, bool> _003C_003E9__6_0;

					internal bool lvYLFrSeJKnKePFsladvcRMjWmxc(byte P_0)
					{
						return false;
					}

					internal bool kRyILaEpxdCqEXDwaYqPVdgdjIoP(byte P_0)
					{
						return false;
					}
				}

				public static bool kqlgpbjdQZiPjCAtjqWTZmAZnKye(byte[] P_0, int P_1)
				{
					return false;
				}

				public static bool YuxWxNjRCMeneMLQxEVmEkxcQVLEb(byte[] P_0, int P_1, byte P_2, byte P_3)
				{
					return false;
				}

				public static bool CdUbeoFJTmtqJmNCVSdCfGyaCBpZb(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}

				public static bool yIvrVDPtjbZvUgwYTzAKAeytaoNW(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}

				public static bool ElSaoIEVkIRTyrNXGvhEKJUgqgkW(byte[] P_0, int P_1, byte[] P_2)
				{
					return false;
				}

				public static bool OknUQaESlFMNstPcqFOTZKjntHMA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
				{
					return false;
				}

				public static bool snnTmCilIhJHAKlJMbXmeXCLjHvDA(byte[] P_0, int P_1, byte P_2, byte[] P_3)
				{
					return false;
				}
			}
		}

		private readonly IHIDDevice rUuEYydrgwLcmidzIbKIRLiNhonYA;

		private readonly HIDProperties ZBZwhBWWWCHcLZPVyLMMpZeAAaGe;

		private readonly bool zZIeZCDUSyGOTdqkvrgAFUvNaMJUA;

		private readonly int OZtLZzXGeoFZXbgXCgZHjYVCLSrR;

		private readonly int WoXZeHujfoArASEOCmjydFYenMbt;

		private readonly bool JkDgpNrYTXfoizlqdSTziXiYaFWN;

		private readonly byte IEWSwgGLgWrzfUzwnWTomOjnSANi;

		private readonly int fUXITQEsrbTTbzWtgBuHCTXPAvol;

		private readonly int udpaArLOtTbmvbkOkBpIIfLYCMOGA;

		private readonly int HeVRlhavrMcHTOyFohgUPmTYGwLF;

		private readonly int aJMFpULuqeeMCgWgyYGyqudmNrhBb;

		private readonly NativeBuffer GpAUFeCZOLAoFLhxUkeBcRbxTDHT;

		private readonly NativeBuffer oaKCMoxSDnoMiCMxKNZLPNlajJYb;

		private MwEMUNdEdQpngdbXMtjwIdOvEFgfA TBaBBwkdmFfksvhzlkAEBrGdcWntb;

		private int KikdnrzvJMRmmGnzAaZEwwczGJbcA;

		private bool AMbDoanTvCussFgoOIESBDYHBESjb;

		private bool KCRnEzMORQannTmbzlyiRpVaLlJx;

		private double RUqgqzDkQkZDihrQSCPqwJcfKXRsA;

		private int ZewyoredRoejUjmFxWiKKMJDfVBab;

		private hAJbqqQiqLaIOEoMcIlvqpsMEDlJ RDuqShdJetISOcfVzQVkiMLVMjzIb;

		private bool oHYjxCaAkOdmErANkECeCONJGzJiA;

		private Quaternion NFlAyLxFQMQEmHJVadsmOCXrDeDJA;

		private DualSenseMicrophoneLightMode JJGHWuBbobRHVeoiRkOJKSZxakEb;

		private KApSKUcifgvAjfIOpwgOGExlHEEk lKSRFzfJfdHlGifcRFmhhNMsehrfb;

		private DualSensePlayerLightFlags gNbhIbkDJHNLQvQYzWNGqQLzKUCM;

		private bool wZsdUWgIDTHXBBwsUHoqwZCkiRdpA;

		private uint wahlCPSVJMNjPLjDAfseCtReinbV;

		private float KVhFlUeMczhjddUcEbSCoCPkKSFTB;

		private double IDDcrzEdnUKQRNuMZHjeOQoMcBGeA;

		private float tYVVEprHGmIikdZxgBCGnfMZLixHA;

		private readonly IDualSenseTriggerEffect[] sgtxYavjzhHJLTJiJcUMiBaKMaoCb;

		private readonly byte[] DNoBahEufbrzwduFFCYzzVDFnhghA;

		private readonly byte[] FvfIOTdJocbahdknjvpwFdciqAmf;

		private DualSenseTriggerEffectState[] rAcqrjcCWEVUKXKXYDcdqCkoALUY;

		private DualSenseVibrationMode rRPDTUtEyTQGgiQddmLDeZAHoMcA;

		private byte AdfjeyhUPspUETqIiRpTuNVAyKwjA;

		private bool uBWiLlEDxDCfVIkdFMiDiUAcoBibb;

		private bool fmMJXJnSKWTxbxDPmbycBBuUfyAGb;

		private bool duqnaNQFvPtifDyJKpLtqsXvCfeg;

		private bool qGwdSSYiyUSBiecgmjHnwarBPlhR;

		private bool aZHtXVxmWbETHGDAidbemZxsteRI;

		private bool PRvrRPbDoNbiaoiUsyXGbZxpShfR;

		private bool HyFoRJYpYOfaVyDtGRSaKbxYEePk;

		private bool rFGJbDtJpaYvzKFpSiLDdBuOGLTV;

		private bool sidnbCVTQSsAPaQuNjQSrGSMGrhcA;

		private byte dihMRbymygExEMloGJkXCoPwicxc;

		private byte VzcGyaGBAALkbdQIKhRUnVurmrAWb;

		private Quaternion pwSmkGAuASwHpNpBhOJrAQAbgiMz;

		private Quaternion JDxAAKkYqFoHWpvTJXQVQlsawpMsA;

		private bool LHWAdHiJoUrZrCsNjEaFITVKLqhFB;

		private int OfMIBLvmZnxofkfmEeLOvUZTxfgm;

		private int[] wDXYHxipgmfoXQzdkddpzuTEpNCc;

		private int[] ZQyDVhFxOYexWYZIGhMSAavdsLLB;

		private static uint[] TeMUklZngyujrDvwXKURSgLOooGW;

		private bool isVibrating => false;

		public float BatteryLevel => 0f;

		public bool BatteryCharging => false;

		public DualSenseVibrationMode vibrationMode
		{
			get
			{
				return default(DualSenseVibrationMode);
			}
			set
			{
			}
		}

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

		public bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
		{
			return false;
		}

		public DualSenseTriggerEffectStates GetTriggerEffectStates()
		{
			return default(DualSenseTriggerEffectStates);
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

		private void eWkaqNCdeBSZfdmOfNnzIUzQpZDVA(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
		}

		private bool YaHItoswabvKirwYaJTAdKVwkmoe(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
			return false;
		}

		private void zRQqozJnYoccJbhqPeXirJKChPsi()
		{
		}

		private void MNRastGmXwEfMZumfMTDWsNVQnBrA(NativeBuffer P_0, int P_1)
		{
		}

		private void soMtUvmVIddkjAiYKRvDAxLSqZJk(ref IDualSenseTriggerEffect P_0, NativeBuffer P_1, int P_2)
		{
		}

		private bool tVgUmVgVwecMJOmaZigtpKNHWVUA(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
			return false;
		}

		private void GDZKiLiaNOIZWRLONrofPgIjFcmX(NativeBuffer P_0, double P_1)
		{
		}

		private void vvDxLIJLOfxspPCvgeQjujfXRVHm(tNSBtIwTqUeWpGtNoXsrdaEOoFDcA[] P_0, NativeBuffer P_1, double P_2)
		{
		}

		private void GFCENzJzPgFfhjHXeDpPlcTtSkBiA()
		{
		}

		private void gZbybGYzHIbxCDtASqeSKprmqNpt(NativeBuffer P_0)
		{
		}

		private void vfwibxJAfpmaWupDFEjKlxKHSgXW()
		{
		}

		private static bool uoMxsbLfzdEjtbURpbihgtcJcIppB(ref Vector3 P_0)
		{
			return false;
		}

		private void YsPgrVQVnuutPVWvrjLRskWwWtnX(Vector3 P_0, Vector3 P_1)
		{
		}

		private Quaternion QMjadOTVBpBfeDIpfSvZrFyMRVri(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private Quaternion TiehsOniwjYhqtrPyugTvDwcxFzj(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private bool CtNJErctshrzIgJySfYTugNxMltO(Vector3 P_0, out HFuggnUJsDeVgGmKHkYSKkWvdbcAA P_1)
		{
			P_1 = default(HFuggnUJsDeVgGmKHkYSKkWvdbcAA);
			return false;
		}

		private bool IbtVtXAneiNByrNPEPUnOyLxoIbd(Vector3 P_0)
		{
			return false;
		}

		private bool IUPhjJxtZCobKKbckInWDZbEwMr(Vector3 P_0)
		{
			return false;
		}

		private Vector3 AbYzOGPkrzqpyaRxotmeUANCyxST(float[] P_0)
		{
			return default(Vector3);
		}

		private Vector3 hOxUuWwEehxqUrFscdQdqzdJOwLM(RingBuffer<XeuQUxbgIYfXehYWxYnOrZfhgALkA.NMUfRuddrxzsOdYlzmZPObqZgnUAb> P_0)
		{
			return default(Vector3);
		}

		private Vector3 WqmHrOGxZIMqExfDqhKjIqyXdQxeA(Vector3 P_0, float P_1)
		{
			return default(Vector3);
		}

		private int wDjGhWKjqITRrhHynWwpimbiEvns(int P_0)
		{
			return 0;
		}

		private void XfvwBOKuLjFrvKHQWkLQytzPGexn(byte[] P_0, float[] P_1)
		{
		}

		private void FFoVxNRjifwxRnVORYJjbdQVaZtU(byte[] P_0, float[] P_1)
		{
		}

		private float RfUZrmbhgAgjKvInsemKsBXlliji()
		{
			return 0f;
		}

		private void BVJaBJKkgtarjWRsQeZpBXbllbRDb(NativeBuffer P_0, hwDBnDzZlOwqwaLOCXGWdEQuXFFf.TouchData[] P_1)
		{
		}

		private int plJeoZTLZFSBEkjICueLzxGcYzqf(int P_0, bool P_1, int P_2)
		{
			return 0;
		}

		private void JRynRuPOFeNQNWPRrhXRMfoDovSQ()
		{
		}

		private void jPeujvCaxhjPloFqocZzySdmOKto()
		{
		}

		private void KMQdVqntnbcmXgNRZpGzCqENJAgj()
		{
		}

		private void irZshuypDHVKIofmoiReibqPPwNd()
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

		private static uint sHblGholuLLcRpyaxoKNhXvnuIfw(NativeBuffer P_0, int P_1)
		{
			return 0u;
		}

		private static KApSKUcifgvAjfIOpwgOGExlHEEk EhHPWmIYHqrMggRlVBLBByDImuop(DualSenseOtherLightBrightness P_0)
		{
			return default(KApSKUcifgvAjfIOpwgOGExlHEEk);
		}

		private static DualSenseOtherLightBrightness zethEXfQpMGSFFHGFncdsXUWKGXnB(KApSKUcifgvAjfIOpwgOGExlHEEk P_0)
		{
			return default(DualSenseOtherLightBrightness);
		}

		private static hADcHjMYjcPjtWFHfwrtgUKVZrTe cstKfxtacNBqwEVIwkxEMQhvBjlw(DualSenseTriggerType P_0, byte P_1)
		{
			return default(hADcHjMYjcPjtWFHfwrtgUKVZrTe);
		}

		private static DualSenseTriggerEffectState JLnRlTSuAJoVaiwuauDKrzbgnjbI(DualSenseTriggerType P_0, byte P_1, byte P_2)
		{
			return default(DualSenseTriggerEffectState);
		}
	}
}
