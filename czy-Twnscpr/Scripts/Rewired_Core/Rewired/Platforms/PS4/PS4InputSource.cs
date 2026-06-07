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
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal sealed class PS4InputSource : CustomInputSource, IControllerAssigner
	{
		private class QnYYrpMsIsNlBrVkcBsUSIYzCje
		{
			public struct EONGqEcSkgpSiKfAgKEiugWqjmzy
			{
				public int LozxQHDUasgVhVpgQCMsCoaOoRQa;

				public int nysCgOHzXLJTixhwqDGEUxXIXWD;

				public int EUPBgsPAuMbQGBNPvCGvIBIDZjKt;

				public HmTEJJhzBcdXPNhnwBCWlKlrAIjr.BaseControllerType EgdvCLoZaqSUnykugCTymxPkenh;

				public EONGqEcSkgpSiKfAgKEiugWqjmzy(int playerId, int handle, int deviceClass, HmTEJJhzBcdXPNhnwBCWlKlrAIjr.BaseControllerType baseControllerType)
				{
					LozxQHDUasgVhVpgQCMsCoaOoRQa = 0;
					nysCgOHzXLJTixhwqDGEUxXIXWD = 0;
					EUPBgsPAuMbQGBNPvCGvIBIDZjKt = 0;
					EgdvCLoZaqSUnykugCTymxPkenh = default(HmTEJJhzBcdXPNhnwBCWlKlrAIjr.BaseControllerType);
				}
			}

			public struct tyNQyjZEqVcldlksYwlOaSDODUl
			{
				public int LozxQHDUasgVhVpgQCMsCoaOoRQa;

				public int nysCgOHzXLJTixhwqDGEUxXIXWD;

				public HmTEJJhzBcdXPNhnwBCWlKlrAIjr.BaseControllerType EgdvCLoZaqSUnykugCTymxPkenh;

				public tyNQyjZEqVcldlksYwlOaSDODUl(int playerId, int handle, HmTEJJhzBcdXPNhnwBCWlKlrAIjr.BaseControllerType baseControllerType)
				{
					LozxQHDUasgVhVpgQCMsCoaOoRQa = 0;
					nysCgOHzXLJTixhwqDGEUxXIXWD = 0;
					EgdvCLoZaqSUnykugCTymxPkenh = default(HmTEJJhzBcdXPNhnwBCWlKlrAIjr.BaseControllerType);
				}
			}

			private class VTzbtaHceYMXZfCSHtWQAPQvFNd
			{
				public readonly HmTEJJhzBcdXPNhnwBCWlKlrAIjr.BaseControllerType EgdvCLoZaqSUnykugCTymxPkenh;

				public bool MmmpjggiZGUCvvhlZNyfuNvEBYF;

				public int nysCgOHzXLJTixhwqDGEUxXIXWD;

				public int EUPBgsPAuMbQGBNPvCGvIBIDZjKt;

				public VTzbtaHceYMXZfCSHtWQAPQvFNd(HmTEJJhzBcdXPNhnwBCWlKlrAIjr.BaseControllerType baseControllerType)
				{
				}

				public ChangeType tHsAIrltnYBGPExUbuFUwiwehmxF(bool P_0, int P_1, int P_2)
				{
					return default(ChangeType);
				}

				private void CKSoitBPjLqWpFGpwBNgDbvTrVm()
				{
				}
			}

			[CustomObfuscation]
			[Flags]
			private enum ChangeType
			{
				[CustomObfuscation]
				None = 0,
				[CustomObfuscation]
				Connected = 1,
				[CustomObfuscation]
				Disconnected = 2,
				[CustomObfuscation]
				IdentityChanged = 4
			}

			private readonly int AkNriUCmYoksPzNkIsgGKTjHhJD;

			private readonly int[] vcEaUgrSyRDFEFLPmPFKsVNJIcPA;

			private readonly int[] TlLBxAPJIyZHeabgEenyhtIRiMgc;

			private readonly int[] JotlzbBXHBWWESyfDHSgWjZTjmf;

			private readonly IExternalTools YIvbtUVWYAmZdcaOnwjyLSPoWsV;

			private readonly VTzbtaHceYMXZfCSHtWQAPQvFNd[] zSPRzqrkTRjXuqpRKUHkMOgxjPJ;

			private readonly VTzbtaHceYMXZfCSHtWQAPQvFNd[] NQTkgxHnafkjLXlAGdXnMuNiOOF;

			private readonly VTzbtaHceYMXZfCSHtWQAPQvFNd[] aMlWKFsjAdCXvDTGQMQhQzEWZKA;

			private readonly List<EONGqEcSkgpSiKfAgKEiugWqjmzy> BQnFDNRanbQNgDdyMhHAJYFqUCo;

			private readonly List<tyNQyjZEqVcldlksYwlOaSDODUl> sjgeDYiCmrFEYHcEwxPcwTixBBf;

			private Action<EONGqEcSkgpSiKfAgKEiugWqjmzy> PAfFLbcfnSqJDlveriuaqPYRcXAF;

			private Action<tyNQyjZEqVcldlksYwlOaSDODUl> oXxXbZPJtxsMEuYvailGvogbvWk;

			[CompilerGenerated]
			private static Func<VTzbtaHceYMXZfCSHtWQAPQvFNd> ziLdulTsoqXipPbCOZOAKHVviun;

			[CompilerGenerated]
			private static Func<VTzbtaHceYMXZfCSHtWQAPQvFNd> GUtEutEEzltmqOpNYrKXdcztHioU;

			[CompilerGenerated]
			private static Func<VTzbtaHceYMXZfCSHtWQAPQvFNd> eeshfSnjdakpwyldchITaKDVJgk;

			public event Action<EONGqEcSkgpSiKfAgKEiugWqjmzy> ControllerConnectedEvent
			{
				add
				{
				}
				remove
				{
				}
			}

			public event Action<tyNQyjZEqVcldlksYwlOaSDODUl> ControllerDisconnectedEvent
			{
				add
				{
				}
				remove
				{
				}
			}

			public QnYYrpMsIsNlBrVkcBsUSIYzCje(int maxPlayers)
			{
			}

			public void jSmUMfkZCZCZfiMnleEGJnwKIqT()
			{
			}

			private void hrvATPImnOPPeSeRbusxRELiLOHK(int P_0, VTzbtaHceYMXZfCSHtWQAPQvFNd P_1, int P_2, bool P_3, string P_4)
			{
			}

			[CompilerGenerated]
			private static VTzbtaHceYMXZfCSHtWQAPQvFNd AMRFAAedLybjtezpepmgmRXxFbFU()
			{
				return null;
			}

			[CompilerGenerated]
			private static VTzbtaHceYMXZfCSHtWQAPQvFNd IdcdnMOpVxFBuBWCGQzOGyGRlKik()
			{
				return null;
			}

			[CompilerGenerated]
			private static VTzbtaHceYMXZfCSHtWQAPQvFNd pAKNvjFTOFKFtnExWcOJCZtnKTnG()
			{
				return null;
			}
		}

		private abstract class HmTEJJhzBcdXPNhnwBCWlKlrAIjr : Joystick, vluPtLjiOOBEtbozXjooaoxPcAqj, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource
		{
			[CustomObfuscation]
			public enum ControllerType
			{
				[CustomObfuscation]
				Unknown = 0,
				[CustomObfuscation]
				Gamepad = 1,
				[CustomObfuscation]
				Aim = 2,
				[CustomObfuscation]
				Guitar = 3,
				[CustomObfuscation]
				Drum = 4,
				[CustomObfuscation]
				DjTurntable = 5,
				[CustomObfuscation]
				DanceMat = 6,
				[CustomObfuscation]
				Navigation = 7,
				[CustomObfuscation]
				SteeringWheel = 8,
				[CustomObfuscation]
				Stick = 9,
				[CustomObfuscation]
				FlightStick = 10,
				[CustomObfuscation]
				Gun = 11
			}

			protected enum NRVSVDgTSyvYuhBjypEnqeIkpnF
			{
				nHPtsYQbEDXgmhYrndYheGAnOz = 0,
				wufTFuhMSnTeHTWflmQsUijRMwl = 1,
				WdDHpuOFhjPaKAUlUBHUsIBMpJY = 2
			}

			[CustomObfuscation]
			public enum BaseControllerType
			{
				[CustomObfuscation]
				Gamepad = 0,
				[CustomObfuscation]
				Special = 1,
				[CustomObfuscation]
				Aim = 2
			}

			public class dCWgDTfDWqPNavXLRBMXRRPbdAz
			{
				public readonly int syBzCXIaEsGwzsQeSMyGXgRRQbr;

				public readonly int duiEsrYlNHHZTeBFaFSIPfitJZv;

				public readonly float uuRKhhvogBWhQsQdXHiFffXfrJC;

				public readonly int MfEzZmPsgQpPXFCudtWcxqDKNDx;

				public readonly int mNDZwQtgwSLHUvZRiDEKEFGMCyP;

				public dCWgDTfDWqPNavXLRBMXRRPbdAz(int axisCount, int buttonCount, float dpadDeadzone, int vibrationMotorCount, int maxTouches)
				{
				}
			}

			private static int NEMMlTtdLDrOKVGDREWHxcVwFYZ;

			protected readonly int RaKAiTTihElhDTpWAKsQdvaqmEJ;

			protected readonly int pKrwCDACzSAsPbFFjuhTMqSbkvkC;

			protected readonly BaseControllerType qUjXrjxHBKdfEVwLAoJvwHooSqT;

			protected readonly dCWgDTfDWqPNavXLRBMXRRPbdAz voZgvwEQnQnmqTrGBEUKMaNDjFi;

			protected readonly int eoALexHkaDZgfvBrLbQAzagdEOjj;

			protected readonly float[] PWIDwAXJQBgiDaWgnZpsiIzrYezQ;

			private readonly LoggedInUser uNkeqRXxMXgQAIHoUQeqyEzrBps;

			protected readonly ControllerType JafvOZeUKqlluyTklnnzmjcQYBv;

			private readonly Func<int, bool> vhcVWCKbfzbxgYgkrxOUCbBgaRza;

			private readonly Action<int, int, int> SYMpMYmGOVaVQtZXHJuvEMccchv;

			private readonly Action<int, int, int, int> BzmbTChJDdoTHYrIKCnljAwYDMiD;

			private readonly Action<int> DlccLdfOhxbvVYFiTEHMNemlZBp;

			private Action<int, bool> qNFaJLjXWVoktAyBWETiCLSpADgw;

			private Action<int, bool> iKYGOvBycumBlZDaGxgFGqVAtJk;

			private Action<int, bool> QiHuSlWcfOZZLOozBbxgIwJKxtT;

			private Action<int> RaDwpjLjzDAIOkmnoGYqCFWFnHwS;

			private Func<int, Vector3> dUkNxpFjGRsbypAgVDLWPoGHXmw;

			private Func<int, Vector3> hQxGvFUGublptyKJonckSvdzBdo;

			private Func<int, Vector4> PBordOfzvEXxnaBTbkLVVAzTrPs;

			private static int NextSystemId => 0;

			protected LoggedInUser user => null;

			public ControllerType type => default(ControllerType);

			public int playerId => 0;

			public int handle => 0;

			public BaseControllerType baseControllerType => default(BaseControllerType);

			private bool IsConnectedNow => false;

			public int vibrationMotorCount => 0;

			public static HmTEJJhzBcdXPNhnwBCWlKlrAIjr byjpFPaNIphrKciIajhIxYJzCeOY(ControllerType P_0, int P_1, int P_2, int P_3)
			{
				return null;
			}

			protected HmTEJJhzBcdXPNhnwBCWlKlrAIjr(ControllerType type, BaseControllerType baseControllerType, string name, int playerId, int unityJoystickId, int handle, dCWgDTfDWqPNavXLRBMXRRPbdAz capabilities)
				: base(null, null, 0, 0, 0)
			{
			}

			public override void Update()
			{
			}

			public int vNaAXiHNceECJOOMAtqaKFkbWOr()
			{
				return 0;
			}

			public int sznrMkYiFBaOeKecSYQhKafMhlP()
			{
				return 0;
			}

			public int mHOcHZIfTYmjsSRxZsrsTgHEBaM()
			{
				return 0;
			}

			public bool wzxaNpLwRfVHrOlQHQEwxLhkcuT()
			{
				return false;
			}

			public Color kUWnsqtiBQfWCGJUptFyARTnPzo()
			{
				return default(Color);
			}

			public int XtvCkTcfisAJzaBgTmipfdQyPOi()
			{
				return 0;
			}

			public string ioALdcFOyVwSmUvXSByDcOdQDZc()
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

			protected virtual void BWrBoMIykYjOOSrpffBVDsWMKdGH()
			{
			}

			protected void vrqeGeEyHqqbBHlllWUITGtJMFux()
			{
			}

			public static int hgaSFDQlHFtZDExCmuvDYCAuZNy(float P_0)
			{
				return 0;
			}

			public static void HfujJNLlHiRjKgIRKeEWJnckQDN(ref Vector3 P_0)
			{
			}

			public static void DgwoZsWYxiDfOBfunEtVSsHsJVR(ref Vector3 P_0)
			{
			}

			public static bool QNYXAlGsonRAMEbAtTqYLMigPsB(int P_0, out ControllerType P_1)
			{
				P_1 = default(ControllerType);
				return false;
			}
		}

		private sealed class CCOqvMpHfDtbuvSvOOYEMZCPlFM : HmTEJJhzBcdXPNhnwBCWlKlrAIjr, vluPtLjiOOBEtbozXjooaoxPcAqj, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource, IPS4ControllerExtensionSourceTouchPad, IPS4GamepadExtensionSource
		{
			private const int HkPyUGvYbjfhjSKDxFZprCOWIEl = 6;

			private const int NoIkHJatIKHMFGIHJxPWgXaDsAp = 14;

			private const float ZeUZywTfvTGJIGHRXbmyEuTThGVB = 0.05f;

			private const int HIxisEcaEGqUiQNfcEecbYcrDmN = 2;

			private const int zlDMbMImuMYExEoqgsPvEoeggBu = 2;

			private int fNPkddIHtCBKUQsqQVfllCJCdGC;

			private int QNgTXoWyoiKVDCkXbMNgzdJsIkQc;

			private Vector2 ydAGrDBOMBKtYomDbHZGlpZUrss;

			private int JfSGALjEMmTsPGtfBskkIqfbNmPs;

			private Vector2 qfEygdFCFKZUGqqaBlHTyfdKmXt;

			private NRVSVDgTSyvYuhBjypEnqeIkpnF bVOVMagbEznEyhshJwmjMyYvKLV;

			private int XTXmwUxngNcFPSkpprcMGdXmiyP;

			private int XVhsybwobEMuQTHuwNKHKHtmBtb;

			private int PlTCWzxdGrVcJzmwgDpMfWViiLyC;

			private int sICtEoQDmzkpFLbgsgjNDTlhfeW;

			private float oEwvTDTPMIhcaLDkufFHBBPLIvp;

			public int maxTouches => 0;

			public CCOqvMpHfDtbuvSvOOYEMZCPlFM(string name, int playerId, int unityJoystickId, int handle)
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

			protected override void BWrBoMIykYjOOSrpffBVDsWMKdGH()
			{
			}

			private void QqZeOLdWEjPjIBfLhDEvtsNSapID()
			{
			}

			private int zZmNrnLqwJgxpBaGwITieXGxEsNm(int P_0)
			{
				return 0;
			}
		}

		private sealed class uUueJNfnQFEzHeVBXpdxilRFGPDu : HmTEJJhzBcdXPNhnwBCWlKlrAIjr, vluPtLjiOOBEtbozXjooaoxPcAqj, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource, IPS4AimExtensionSource
		{
			private const int HkPyUGvYbjfhjSKDxFZprCOWIEl = 6;

			private const int NoIkHJatIKHMFGIHJxPWgXaDsAp = 14;

			private const float ZeUZywTfvTGJIGHRXbmyEuTThGVB = 0.05f;

			private const int HIxisEcaEGqUiQNfcEecbYcrDmN = 2;

			private const int zlDMbMImuMYExEoqgsPvEoeggBu = 2;

			private int fNPkddIHtCBKUQsqQVfllCJCdGC;

			private int QNgTXoWyoiKVDCkXbMNgzdJsIkQc;

			private Vector2 ydAGrDBOMBKtYomDbHZGlpZUrss;

			private int JfSGALjEMmTsPGtfBskkIqfbNmPs;

			private Vector2 qfEygdFCFKZUGqqaBlHTyfdKmXt;

			private NRVSVDgTSyvYuhBjypEnqeIkpnF bVOVMagbEznEyhshJwmjMyYvKLV;

			private int XTXmwUxngNcFPSkpprcMGdXmiyP;

			private int XVhsybwobEMuQTHuwNKHKHtmBtb;

			private int PlTCWzxdGrVcJzmwgDpMfWViiLyC;

			private int sICtEoQDmzkpFLbgsgjNDTlhfeW;

			private float oEwvTDTPMIhcaLDkufFHBBPLIvp;

			public uUueJNfnQFEzHeVBXpdxilRFGPDu(string name, int playerId, int unityJoystickId, int handle)
			{
			}
		}

		private abstract class dRIIaqekkvHRVpLjOpujIqPQfPT : HmTEJJhzBcdXPNhnwBCWlKlrAIjr
		{
			protected dRIIaqekkvHRVpLjOpujIqPQfPT(ControllerType controllerType, string name, int playerId, int unityJoystickId, int handle, dCWgDTfDWqPNavXLRBMXRRPbdAz capabilities)
			{
			}

			public static dRIIaqekkvHRVpLjOpujIqPQfPT byjpFPaNIphrKciIajhIxYJzCeOY(int P_0, int P_1, int P_2)
			{
				return null;
			}

			public static dRIIaqekkvHRVpLjOpujIqPQfPT byjpFPaNIphrKciIajhIxYJzCeOY(ControllerType P_0, int P_1, int P_2)
			{
				return null;
			}
		}

		private sealed class zAsARwFbUhlLqRfeUGnyHgORxLcb : dRIIaqekkvHRVpLjOpujIqPQfPT
		{
			private const int HkPyUGvYbjfhjSKDxFZprCOWIEl = 13;

			private const int NoIkHJatIKHMFGIHJxPWgXaDsAp = 14;

			private const float ZeUZywTfvTGJIGHRXbmyEuTThGVB = 0.05f;

			private const int HIxisEcaEGqUiQNfcEecbYcrDmN = 2;

			private const int zlDMbMImuMYExEoqgsPvEoeggBu = 0;

			public zAsARwFbUhlLqRfeUGnyHgORxLcb(string name, int playerId, int unityJoystickId, int handle)
			{
			}

			protected override void BWrBoMIykYjOOSrpffBVDsWMKdGH()
			{
			}
		}

		private sealed class OoVPaZLyIsEepmdkRBRXLktBoSO : dRIIaqekkvHRVpLjOpujIqPQfPT
		{
			private const int HkPyUGvYbjfhjSKDxFZprCOWIEl = 11;

			private const int NoIkHJatIKHMFGIHJxPWgXaDsAp = 14;

			private const float ZeUZywTfvTGJIGHRXbmyEuTThGVB = 0.05f;

			private const int HIxisEcaEGqUiQNfcEecbYcrDmN = 2;

			private const int zlDMbMImuMYExEoqgsPvEoeggBu = 0;

			public OoVPaZLyIsEepmdkRBRXLktBoSO(string name, int playerId, int unityJoystickId, int handle)
			{
			}

			protected override void BWrBoMIykYjOOSrpffBVDsWMKdGH()
			{
			}
		}

		private sealed class SgGFaUfpOkJMmOwrnMuNTkvgPjx : dRIIaqekkvHRVpLjOpujIqPQfPT
		{
			private const int HkPyUGvYbjfhjSKDxFZprCOWIEl = 13;

			private const int NoIkHJatIKHMFGIHJxPWgXaDsAp = 14;

			private const float ZeUZywTfvTGJIGHRXbmyEuTThGVB = 0.05f;

			private const int HIxisEcaEGqUiQNfcEecbYcrDmN = 2;

			private const int zlDMbMImuMYExEoqgsPvEoeggBu = 0;

			public SgGFaUfpOkJMmOwrnMuNTkvgPjx(string name, int playerId, int unityJoystickId, int handle)
			{
			}

			protected override void BWrBoMIykYjOOSrpffBVDsWMKdGH()
			{
			}
		}

		private sealed class MldTZZFeUuaIQdpceQRDiqmUCOK : dRIIaqekkvHRVpLjOpujIqPQfPT
		{
			private const int HkPyUGvYbjfhjSKDxFZprCOWIEl = 16;

			private const int NoIkHJatIKHMFGIHJxPWgXaDsAp = 14;

			private const float ZeUZywTfvTGJIGHRXbmyEuTThGVB = 0.05f;

			private const int HIxisEcaEGqUiQNfcEecbYcrDmN = 2;

			private const int zlDMbMImuMYExEoqgsPvEoeggBu = 0;

			public MldTZZFeUuaIQdpceQRDiqmUCOK(string name, int playerId, int unityJoystickId, int handle)
			{
			}

			protected override void BWrBoMIykYjOOSrpffBVDsWMKdGH()
			{
			}
		}

		private QnYYrpMsIsNlBrVkcBsUSIYzCje nIBHoLNiFsoCirDdAbbbjcsUNBdd;

		private bool TvrSkCadBiiITFugGdmPThbkJcpg;

		private bool CGIHxiLUHgNfmOBOdViTruIZZWF;

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

		private static int QdepsGEGwZYtGRBXBJPOyENyFUy(int P_0)
		{
			return 0;
		}

		private void pEyAaAUURhvyjzyuWCmTleGpPNF(QnYYrpMsIsNlBrVkcBsUSIYzCje.EONGqEcSkgpSiKfAgKEiugWqjmzy P_0)
		{
		}

		private void OkRjWcQiRQrNkdryoWpbDwMxEEI(HmTEJJhzBcdXPNhnwBCWlKlrAIjr P_0)
		{
		}

		private void sQzahlUIPjzBIONrbHpovIrGkCT(QnYYrpMsIsNlBrVkcBsUSIYzCje.tyNQyjZEqVcldlksYwlOaSDODUl P_0)
		{
		}

		private bool ptCugaeQlzoSmRNnnxnuezWMHDU(ControllerType P_0, Rewired.Controller P_1)
		{
			return false;
		}

		bool IControllerAssigner.CanHandleAssignment(ControllerType P_0, Rewired.Controller P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ptCugaeQlzoSmRNnnxnuezWMHDU
			return this.ptCugaeQlzoSmRNnnxnuezWMHDU(P_0, P_1);
		}

		private void fMEatsQCfkknbUbAIiuFnswuLIz(ControllerType P_0, Rewired.Controller P_1)
		{
		}

		void IControllerAssigner.AssignController(ControllerType P_0, Rewired.Controller P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in fMEatsQCfkknbUbAIiuFnswuLIz
			this.fMEatsQCfkknbUbAIiuFnswuLIz(P_0, P_1);
		}

		~PS4InputSource()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
