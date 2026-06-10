using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Interfaces;
using Rewired.Platforms.Custom;
using Rewired.Platforms.PS4.Internal;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Platforms.PS4
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class PS4InputSource : CustomInputSource, IControllerAssigner
	{
		private class DylXkOasMCuUNpxHkfwwcYnQUGm
		{
			public struct rFYTyzBgubUnYiNlFOifnELehVJF
			{
				public int YdMuqczEIWIRtHqiObrOYNobHiQ;

				public int csZDQbhGlfuIuxoqmRsyqwmplZX;

				public int RoiFIHdwEgvNOJmJtCrDtFfmalAf;

				public OMqtypPznYKZWlfIgpiVuURCItt.BaseControllerType DwIwDkUWQCJFbyfooqkSUvwVvWl;

				public rFYTyzBgubUnYiNlFOifnELehVJF(int playerId, int handle, int deviceClass, OMqtypPznYKZWlfIgpiVuURCItt.BaseControllerType baseControllerType)
				{
					YdMuqczEIWIRtHqiObrOYNobHiQ = 0;
					csZDQbhGlfuIuxoqmRsyqwmplZX = 0;
					RoiFIHdwEgvNOJmJtCrDtFfmalAf = 0;
					DwIwDkUWQCJFbyfooqkSUvwVvWl = default(OMqtypPznYKZWlfIgpiVuURCItt.BaseControllerType);
				}
			}

			public struct TrwDOtIZlwQPeOnkWLyfPHhKWw
			{
				public int YdMuqczEIWIRtHqiObrOYNobHiQ;

				public int csZDQbhGlfuIuxoqmRsyqwmplZX;

				public OMqtypPznYKZWlfIgpiVuURCItt.BaseControllerType DwIwDkUWQCJFbyfooqkSUvwVvWl;

				public TrwDOtIZlwQPeOnkWLyfPHhKWw(int playerId, int handle, OMqtypPznYKZWlfIgpiVuURCItt.BaseControllerType baseControllerType)
				{
					YdMuqczEIWIRtHqiObrOYNobHiQ = 0;
					csZDQbhGlfuIuxoqmRsyqwmplZX = 0;
					DwIwDkUWQCJFbyfooqkSUvwVvWl = default(OMqtypPznYKZWlfIgpiVuURCItt.BaseControllerType);
				}
			}

			private class qknzkiujgNOYaTEsPglkdmqjnpH
			{
				public readonly OMqtypPznYKZWlfIgpiVuURCItt.BaseControllerType DwIwDkUWQCJFbyfooqkSUvwVvWl;

				public bool ZZZFDSJAYfnBQatzHhsAcQgLWDOV;

				public int csZDQbhGlfuIuxoqmRsyqwmplZX;

				public int RoiFIHdwEgvNOJmJtCrDtFfmalAf;

				public qknzkiujgNOYaTEsPglkdmqjnpH(OMqtypPznYKZWlfIgpiVuURCItt.BaseControllerType baseControllerType)
				{
				}

				public ChangeType qJLaIUNBWuZNFhYkvkWgIXGPyyv(bool P_0, int P_1, int P_2)
				{
					return default(ChangeType);
				}

				private void DcbUeIfyTfvTrRQxceAMfGCsJNs()
				{
				}
			}

			[CustomObfuscation(rename = false)]
			[Flags]
			private enum ChangeType
			{
				[CustomObfuscation(rename = false)]
				None = 0,
				[CustomObfuscation(rename = false)]
				Connected = 1,
				[CustomObfuscation(rename = false)]
				Disconnected = 2,
				[CustomObfuscation(rename = false)]
				IdentityChanged = 4
			}

			private readonly int PiwbNXboAGlxyHhRiZRMwccuxpZf;

			private readonly int[] eRlmSLNSPpYlOHPImetohiVqwsB;

			private readonly int[] EneTbdpwgQWeuaggEWKWVgfuQnk;

			private readonly int[] USYBAQhDxhFZSEWtPQyUqOaoQpn;

			private readonly IExternalTools XPMHDffqeyGQnuQUxaWSexaJRgXP;

			private readonly qknzkiujgNOYaTEsPglkdmqjnpH[] oJiLYJZGftGRkuvTKwwAwkDKFxF;

			private readonly qknzkiujgNOYaTEsPglkdmqjnpH[] EzumSExSGBkvBZPWSaADqnoPTQD;

			private readonly qknzkiujgNOYaTEsPglkdmqjnpH[] dCKsoeAjoRQNbLCSYgnXBubhlCQ;

			private readonly List<rFYTyzBgubUnYiNlFOifnELehVJF> CAQUpotoTZnZqVRaKokahjyXPYc;

			private readonly List<TrwDOtIZlwQPeOnkWLyfPHhKWw> hERLEfYuUZjLSXnKaecIaKPGfNre;

			private Action<rFYTyzBgubUnYiNlFOifnELehVJF> YBOvWIZFyyELXzgMtVMavtbaFCS;

			private Action<TrwDOtIZlwQPeOnkWLyfPHhKWw> lwGczujTjVInUFgEkSTkXRVWYtks;

			[CompilerGenerated]
			private static Func<qknzkiujgNOYaTEsPglkdmqjnpH> iTgXFInaCOCMfgZhSKmoFikUIgze;

			[CompilerGenerated]
			private static Func<qknzkiujgNOYaTEsPglkdmqjnpH> HMOMQkhRNslmnsRSdjdErMIPeq;

			[CompilerGenerated]
			private static Func<qknzkiujgNOYaTEsPglkdmqjnpH> rWTPQhLeNWbucoWbsCbtCauqryk;

			public event Action<rFYTyzBgubUnYiNlFOifnELehVJF> ControllerConnectedEvent
			{
				add
				{
				}
				remove
				{
				}
			}

			public event Action<TrwDOtIZlwQPeOnkWLyfPHhKWw> ControllerDisconnectedEvent
			{
				add
				{
				}
				remove
				{
				}
			}

			public DylXkOasMCuUNpxHkfwwcYnQUGm(int maxPlayers)
			{
			}

			public void oDVbwUgIfbSDvfmIInVcyfSKnKRm()
			{
			}

			private void atIhKaUNasWdcebXpXhPyRyPWER(int P_0, qknzkiujgNOYaTEsPglkdmqjnpH P_1, int P_2, bool P_3, string P_4)
			{
			}

			[CompilerGenerated]
			private static qknzkiujgNOYaTEsPglkdmqjnpH kQypCTxEGqfudvprNAEhysirTA()
			{
				return null;
			}

			[CompilerGenerated]
			private static qknzkiujgNOYaTEsPglkdmqjnpH DkTGPbsJnRZIqIhEWlSuAGpwbCuH()
			{
				return null;
			}

			[CompilerGenerated]
			private static qknzkiujgNOYaTEsPglkdmqjnpH gszDNAjqifGmfjOxMdsljKGQZLx()
			{
				return null;
			}
		}

		private abstract class OMqtypPznYKZWlfIgpiVuURCItt : Joystick, ggTkdwJMwyHZjrvxNfFQYoCehWyD, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource
		{
			[CustomObfuscation(rename = false)]
			public enum ControllerType
			{
				[CustomObfuscation(rename = false)]
				Unknown = 0,
				[CustomObfuscation(rename = false)]
				Gamepad = 1,
				[CustomObfuscation(rename = false)]
				Aim = 2,
				[CustomObfuscation(rename = false)]
				Guitar = 3,
				[CustomObfuscation(rename = false)]
				Drum = 4,
				[CustomObfuscation(rename = false)]
				DjTurntable = 5,
				[CustomObfuscation(rename = false)]
				DanceMat = 6,
				[CustomObfuscation(rename = false)]
				Navigation = 7,
				[CustomObfuscation(rename = false)]
				SteeringWheel = 8,
				[CustomObfuscation(rename = false)]
				Stick = 9,
				[CustomObfuscation(rename = false)]
				FlightStick = 10,
				[CustomObfuscation(rename = false)]
				Gun = 11
			}

			protected enum JeNvHTaOKodEYqEkbeuEaQpJBuI
			{
				mnuFxKgqikbGDTkpdhEJoVZzZrS = 0,
				lXYfiRJKgXhVBRelbjmYukSkcEz = 1,
				NwgBUNmCRBhhSUCpCTouSUwhBQS = 2
			}

			[CustomObfuscation(rename = false)]
			public enum BaseControllerType
			{
				[CustomObfuscation(rename = false)]
				Gamepad = 0,
				[CustomObfuscation(rename = false)]
				Special = 1,
				[CustomObfuscation(rename = false)]
				Aim = 2
			}

			public class lSBXIcnZtrYttXlSRcxkyMSwTjS
			{
				public readonly int pTqlZemFmCndvameWcFuCzocQpxR;

				public readonly int cCVoiYeObfKUPyVFkNgadsZIDThe;

				public readonly float jMeLkADzUngWOoGdDRWpHIgANnM;

				public readonly int ZHjjBLxDSwIULZUgnbCMHwanPkf;

				public readonly int bxirtxBwKmhYUxbJaeXqiElvjWB;

				public lSBXIcnZtrYttXlSRcxkyMSwTjS(int axisCount, int buttonCount, float dpadDeadzone, int vibrationMotorCount, int maxTouches)
				{
				}
			}

			private static int GOdWgsXDprayITmRPDdddXoLeATA;

			protected readonly int CvnGUgdDPoraRVDOSPLmFGFLbYT;

			protected readonly int eAQqlcicVexQDRBTfBYdQQfGepw;

			protected readonly BaseControllerType lGMdvSEHvsVcMjVoMKZRQCkPZYaj;

			protected readonly lSBXIcnZtrYttXlSRcxkyMSwTjS whiCPLylDaTtgDcGPsjsmueoSXg;

			protected readonly int pxjqhAdOObmAtnSrVunaLPNYGGfG;

			protected readonly float[] YpLGrzjutinRpWizcGUIsYCUmzu;

			private readonly LoggedInUser hVFjAsbmofCzWFAoYNtUUXOSXto;

			protected readonly ControllerType WwGNBcAzyQKiegnejLCVExHzkIt;

			private readonly Func<int, bool> gcRKtjirTZTqoONexutgktwPIBz;

			private readonly Action<int, int, int> NVjULdCdidTfQzqRVjmVwjtBBkpi;

			private readonly Action<int, int, int, int> ASRErpNOtJuYXGEYATUPTqFzwWs;

			private readonly Action<int> EhLRIGNqTNTkDYOeJejyaxHGuFfN;

			private Action<int, bool> dPmtiwnwufnQlqXZMaVMjvNYTws;

			private Action<int, bool> xJjgkhjdCIlzZCTNEhSAuaLxXzR;

			private Action<int, bool> RLkgLKibTcAATWvhHGWSqogbhgX;

			private Action<int> AVkLWQtMFdtDCqFhkadADdbweJeH;

			private Func<int, Vector3> aEZwnUbLHlFngxJgNIiwbrpaOZaI;

			private Func<int, Vector3> oaETegyvIXKypomByvKYiBCMjBwB;

			private Func<int, Vector4> UFNBghNVNsGdtyUZvmzffKIcTLa;

			private static int NextSystemId => 0;

			protected LoggedInUser user => null;

			public ControllerType type => default(ControllerType);

			public int playerId => 0;

			public int handle => 0;

			public BaseControllerType baseControllerType => default(BaseControllerType);

			private bool IsConnectedNow => false;

			public int vibrationMotorCount => 0;

			public static OMqtypPznYKZWlfIgpiVuURCItt ocIbkoMmgHsnOyMMcObcgEoKEsQ(ControllerType P_0, int P_1, int P_2, int P_3)
			{
				return null;
			}

			protected OMqtypPznYKZWlfIgpiVuURCItt(ControllerType type, BaseControllerType baseControllerType, string name, int playerId, int unityJoystickId, int handle, lSBXIcnZtrYttXlSRcxkyMSwTjS capabilities)
				: base(null, null, 0, 0, 0)
			{
			}

			public override void Update()
			{
			}

			public int cINjvVxsSKKXNIrMECFOepFEuSp()
			{
				return 0;
			}

			public int tZMEHbjiQnfvYySeCtxayoTdEhrQ()
			{
				return 0;
			}

			public int lOnirmmAjiSoeKCxJsVMnBybjsW()
			{
				return 0;
			}

			public bool niMNWYdNxHhCpOySBSpQVmINPyL()
			{
				return false;
			}

			public Color rYjObHDRtmTICGCEpCqQcbmQnvw()
			{
				return default(Color);
			}

			public int EqWTsaIlWOEPjmViTRPXVtvHCXq()
			{
				return 0;
			}

			public string vSrPbBxZMjJjwArVWZjpKGWpLSo()
			{
				return null;
			}

			public void StopVibration()
			{
			}

			public void SetVibration(int motorIndex, float value)
			{
			}

			public float GetVibration(int motorIndex)
			{
				return 0f;
			}

			public void SetMotionSensorState(bool enabled)
			{
			}

			public void SetTiltCorrectionState(bool enabled)
			{
			}

			public void SetAngularVelocityDeadbandState(bool enabled)
			{
			}

			public void ResetOrientation()
			{
			}

			public Vector3 GetLastAcceleration()
			{
				return default(Vector3);
			}

			public Vector3 GetLastAccelerationRaw()
			{
				return default(Vector3);
			}

			public Vector3 GetLastGyro()
			{
				return default(Vector3);
			}

			public Vector3 GetLastGyroRaw()
			{
				return default(Vector3);
			}

			public Quaternion GetLastOrientation()
			{
				return default(Quaternion);
			}

			public Quaternion GetLastOrientationRaw()
			{
				return default(Quaternion);
			}

			public void SetLightColor(int red, int green, int blue)
			{
			}

			public void ResetLight()
			{
			}

			protected virtual void EyGQdzMSjeRQKYhefiVbGdkpvrK()
			{
			}

			protected void iFDyeNIreAuBPpgbpvWooSOiHkq()
			{
			}

			public static int ejDzpykhdrGEXMkAcCyngfbDVlo(float P_0)
			{
				return 0;
			}

			public static void UeHFJoerHUCEUXiUKRDscnQNnINJ(ref Vector3 P_0)
			{
			}

			public static void QxHhtLuVPAKnQFrexAOrkecLNZX(ref Vector3 P_0)
			{
			}

			public static bool HCzguKoUiBDOSAYZbVrupJsFeWL(int P_0, out ControllerType P_1)
			{
				P_1 = default(ControllerType);
				return false;
			}
		}

		private sealed class TgbTQhHsBlufenPvQljwyGlybXW : OMqtypPznYKZWlfIgpiVuURCItt, ggTkdwJMwyHZjrvxNfFQYoCehWyD, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource, IPS4ControllerExtensionSourceTouchPad, IPS4GamepadExtensionSource
		{
			private const int QmmoibDITFcHbYcFvIuDXnjfGMpc = 6;

			private const int AGbvGyAZcoNXFAfJJcJqOTZcEUj = 14;

			private const float QThGqRxZYdCkYEBiRZOEEoraSxP = 0.05f;

			private const int ABEcErYemmwBoUFjeWBYFHVElqF = 2;

			private const int yUaquvkqIijRhWIeuxFHalJXJgo = 2;

			private int emiBOQhqlekOKDGicKaLOFgDhxMF;

			private int PQFlKJajIIIMFUQHpsyGBriXeZM;

			private Vector2 lwjaBotTereyGeXBpBkiXselDrw;

			private int KgjgaRwcmAbBZjvoHTUfMYqkqZv;

			private Vector2 hrlCSWapumLKKPykFHYldKAtuep;

			private JeNvHTaOKodEYqEkbeuEaQpJBuI ayraVZAezRZiqzdrHZNzqpSUAXa;

			private int MFmDEPIJDlLpXHUugrCGOuWGHmit;

			private int WYsgGJfMGRyVygRTyNmcEskgSZbn;

			private int IfyDgKXKqHPxFxRsiLAeygcVAHqa;

			private int lgfXBXyhULcvZFHowAAbffOWTmA;

			private float zPTXNclypoWogNweqRExdtgaSrn;

			public int maxTouches => 0;

			public TgbTQhHsBlufenPvQljwyGlybXW(string name, int playerId, int unityJoystickId, int handle)
			{
			}

			public int GetConnectionType()
			{
				return 0;
			}

			public int GetAnalogDeadZoneLeft()
			{
				return 0;
			}

			public int GetAnalogDeadZoneRight()
			{
				return 0;
			}

			public float GetTouchPixelDensity()
			{
				return 0f;
			}

			public int GetTouchpadResolutionX()
			{
				return 0;
			}

			public int GetTouchpadResolutionY()
			{
				return 0;
			}

			public int GetTouchCount()
			{
				return 0;
			}

			public int GetTouchId(int index)
			{
				return 0;
			}

			public bool GetTouchPositionAbsByIndex(int index, out Vector2 position)
			{
				position = default(Vector2);
				return false;
			}

			public bool GetTouchPositionAbsByTouchId(int touchId, out Vector2 position)
			{
				position = default(Vector2);
				return false;
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

			public bool IsTouchingByIndex(int index)
			{
				return false;
			}

			public bool IsTouchingByTouchId(int touchId)
			{
				return false;
			}

			protected override void EyGQdzMSjeRQKYhefiVbGdkpvrK()
			{
			}

			private void VWwdawJBkHFaUGHVdfxDyXcdWtIh()
			{
			}

			private int aeXHNEjmQlgcpBxGwyhYlklCiQR(int P_0)
			{
				return 0;
			}
		}

		private sealed class xABFtaTiavygFDkJZaSVHPwzbDTN : OMqtypPznYKZWlfIgpiVuURCItt, ggTkdwJMwyHZjrvxNfFQYoCehWyD, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource, IPS4AimExtensionSource
		{
			private const int QmmoibDITFcHbYcFvIuDXnjfGMpc = 6;

			private const int AGbvGyAZcoNXFAfJJcJqOTZcEUj = 14;

			private const float QThGqRxZYdCkYEBiRZOEEoraSxP = 0.05f;

			private const int ABEcErYemmwBoUFjeWBYFHVElqF = 2;

			private const int yUaquvkqIijRhWIeuxFHalJXJgo = 2;

			private int emiBOQhqlekOKDGicKaLOFgDhxMF;

			private int PQFlKJajIIIMFUQHpsyGBriXeZM;

			private Vector2 lwjaBotTereyGeXBpBkiXselDrw;

			private int KgjgaRwcmAbBZjvoHTUfMYqkqZv;

			private Vector2 hrlCSWapumLKKPykFHYldKAtuep;

			private JeNvHTaOKodEYqEkbeuEaQpJBuI ayraVZAezRZiqzdrHZNzqpSUAXa;

			private int MFmDEPIJDlLpXHUugrCGOuWGHmit;

			private int WYsgGJfMGRyVygRTyNmcEskgSZbn;

			private int IfyDgKXKqHPxFxRsiLAeygcVAHqa;

			private int lgfXBXyhULcvZFHowAAbffOWTmA;

			private float zPTXNclypoWogNweqRExdtgaSrn;

			public xABFtaTiavygFDkJZaSVHPwzbDTN(string name, int playerId, int unityJoystickId, int handle)
			{
			}
		}

		private abstract class yJvYjFMEUNCvLnztSBsPmtwxTaV : OMqtypPznYKZWlfIgpiVuURCItt
		{
			protected yJvYjFMEUNCvLnztSBsPmtwxTaV(ControllerType controllerType, string name, int playerId, int unityJoystickId, int handle, lSBXIcnZtrYttXlSRcxkyMSwTjS capabilities)
			{
			}

			public static yJvYjFMEUNCvLnztSBsPmtwxTaV ocIbkoMmgHsnOyMMcObcgEoKEsQ(int P_0, int P_1, int P_2)
			{
				return null;
			}

			public static yJvYjFMEUNCvLnztSBsPmtwxTaV ocIbkoMmgHsnOyMMcObcgEoKEsQ(ControllerType P_0, int P_1, int P_2)
			{
				return null;
			}
		}

		private sealed class wPJhwHFwMFMustumYSuIKzriPgs : yJvYjFMEUNCvLnztSBsPmtwxTaV
		{
			private const int QmmoibDITFcHbYcFvIuDXnjfGMpc = 13;

			private const int AGbvGyAZcoNXFAfJJcJqOTZcEUj = 14;

			private const float QThGqRxZYdCkYEBiRZOEEoraSxP = 0.05f;

			private const int ABEcErYemmwBoUFjeWBYFHVElqF = 2;

			private const int yUaquvkqIijRhWIeuxFHalJXJgo = 0;

			public wPJhwHFwMFMustumYSuIKzriPgs(string name, int playerId, int unityJoystickId, int handle)
			{
			}

			protected override void EyGQdzMSjeRQKYhefiVbGdkpvrK()
			{
			}
		}

		private sealed class ZykUpefOYQbPpugeDlgvnHSaBkQe : yJvYjFMEUNCvLnztSBsPmtwxTaV
		{
			private const int QmmoibDITFcHbYcFvIuDXnjfGMpc = 11;

			private const int AGbvGyAZcoNXFAfJJcJqOTZcEUj = 14;

			private const float QThGqRxZYdCkYEBiRZOEEoraSxP = 0.05f;

			private const int ABEcErYemmwBoUFjeWBYFHVElqF = 2;

			private const int yUaquvkqIijRhWIeuxFHalJXJgo = 0;

			public ZykUpefOYQbPpugeDlgvnHSaBkQe(string name, int playerId, int unityJoystickId, int handle)
			{
			}

			protected override void EyGQdzMSjeRQKYhefiVbGdkpvrK()
			{
			}
		}

		private sealed class DMrBKjJKgEDTgWjhhFLlhzKNLzvD : yJvYjFMEUNCvLnztSBsPmtwxTaV
		{
			private const int QmmoibDITFcHbYcFvIuDXnjfGMpc = 13;

			private const int AGbvGyAZcoNXFAfJJcJqOTZcEUj = 14;

			private const float QThGqRxZYdCkYEBiRZOEEoraSxP = 0.05f;

			private const int ABEcErYemmwBoUFjeWBYFHVElqF = 2;

			private const int yUaquvkqIijRhWIeuxFHalJXJgo = 0;

			public DMrBKjJKgEDTgWjhhFLlhzKNLzvD(string name, int playerId, int unityJoystickId, int handle)
			{
			}

			protected override void EyGQdzMSjeRQKYhefiVbGdkpvrK()
			{
			}
		}

		private sealed class XoArJqdbmODvOnVmgoLpCFHraSW : yJvYjFMEUNCvLnztSBsPmtwxTaV
		{
			private const int QmmoibDITFcHbYcFvIuDXnjfGMpc = 16;

			private const int AGbvGyAZcoNXFAfJJcJqOTZcEUj = 14;

			private const float QThGqRxZYdCkYEBiRZOEEoraSxP = 0.05f;

			private const int ABEcErYemmwBoUFjeWBYFHVElqF = 2;

			private const int yUaquvkqIijRhWIeuxFHalJXJgo = 0;

			public XoArJqdbmODvOnVmgoLpCFHraSW(string name, int playerId, int unityJoystickId, int handle)
			{
			}

			protected override void EyGQdzMSjeRQKYhefiVbGdkpvrK()
			{
			}
		}

		private DylXkOasMCuUNpxHkfwwcYnQUGm ubibUwjNnYuJcjMzAFODJCHhVBzb;

		private bool GYSEqdQBzGDHDmukGRLxZgKVuLb;

		private bool PrvylHtjoIHWmYgGfZyfZonoJFJ;

		public override bool isReady => false;

		bool IControllerAssigner.enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public PS4InputSource()
			: base(0)
		{
		}

		public override void Update()
		{
		}

		private static int ToZzHfchkhyBERHBNTqcQCzNBDmi(int P_0)
		{
			return 0;
		}

		private void kzXGOngZbVrtrtImIIJhRObOnFV(DylXkOasMCuUNpxHkfwwcYnQUGm.rFYTyzBgubUnYiNlFOifnELehVJF P_0)
		{
		}

		private void LTaRJJmXzyweujGamhXPzCfIgQK(OMqtypPznYKZWlfIgpiVuURCItt P_0)
		{
		}

		private void rAYvIKyjzREaKbKxlOuKpVUhlgTX(DylXkOasMCuUNpxHkfwwcYnQUGm.TrwDOtIZlwQPeOnkWLyfPHhKWw P_0)
		{
		}

		private bool yrpaWVAAeXqzypFFrPQAUvSbYLE(ControllerType P_0, Rewired.Controller P_1)
		{
			return false;
		}

		bool IControllerAssigner.CanHandleAssignment(ControllerType P_0, Rewired.Controller P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in yrpaWVAAeXqzypFFrPQAUvSbYLE
			return this.yrpaWVAAeXqzypFFrPQAUvSbYLE(P_0, P_1);
		}

		private void ujnSSTedJCadlIKOCkLrHVTXXWpM(ControllerType P_0, Rewired.Controller P_1)
		{
		}

		void IControllerAssigner.AssignController(ControllerType P_0, Rewired.Controller P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ujnSSTedJCadlIKOCkLrHVTXXWpM
			this.ujnSSTedJCadlIKOCkLrHVTXXWpM(P_0, P_1);
		}

		~PS4InputSource()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
