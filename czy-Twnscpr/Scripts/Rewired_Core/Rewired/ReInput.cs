using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public static class ReInput
	{
		public sealed class ConfigHelper : CodeHelper
		{
			private static ConfigHelper TGpVjpCnXnesTEFRakRpmLikuhU;

			private float rzZYESNtGUvDmeKmYYyCNtsZPyg;

			private float QRgmQCJKnWKRPPFRpThKaalAfKVK;

			internal static ConfigHelper Instance => null;

			public bool useXInput
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public UpdateLoopSetting updateLoop
			{
				get
				{
					return default(UpdateLoopSetting);
				}
				set
				{
				}
			}

			public WindowsStandalonePrimaryInputSource windowsStandalonePrimaryInputSource
			{
				get
				{
					return default(WindowsStandalonePrimaryInputSource);
				}
				set
				{
				}
			}

			public OSXStandalonePrimaryInputSource osxStandalonePrimaryInputSource
			{
				get
				{
					return default(OSXStandalonePrimaryInputSource);
				}
				set
				{
				}
			}

			public LinuxStandalonePrimaryInputSource linuxStandalonePrimaryInputSource
			{
				get
				{
					return default(LinuxStandalonePrimaryInputSource);
				}
				set
				{
				}
			}

			public WindowsUWPPrimaryInputSource windowsUWPPrimaryInputSource
			{
				get
				{
					return default(WindowsUWPPrimaryInputSource);
				}
				set
				{
				}
			}

			public bool windowsUWPSupportHIDDevices
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public XboxOnePrimaryInputSource xboxOnePrimaryInputSource
			{
				get
				{
					return default(XboxOnePrimaryInputSource);
				}
				set
				{
				}
			}

			public PS4PrimaryInputSource ps4PrimaryInputSource
			{
				get
				{
					return default(PS4PrimaryInputSource);
				}
				set
				{
				}
			}

			public WebGLPrimaryInputSource webGLPrimaryInputSource
			{
				get
				{
					return default(WebGLPrimaryInputSource);
				}
				set
				{
				}
			}

			public bool alwaysUseUnityInput
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool disableNativeInput
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool nativeMouseSupport
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool nativeKeyboardSupport
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool enhancedDeviceSupport
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public int joystickRefreshRate
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public bool ignoreInputWhenAppNotInFocus
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool android_supportUnknownGamepads
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public DeadZone2DType defaultJoystickAxis2DDeadZoneType
			{
				get
				{
					return default(DeadZone2DType);
				}
				set
				{
				}
			}

			public AxisSensitivity2DType defaultJoystickAxis2DSensitivityType
			{
				get
				{
					return default(AxisSensitivity2DType);
				}
				set
				{
				}
			}

			public AxisSensitivityType defaultAxisSensitivityType
			{
				get
				{
					return default(AxisSensitivityType);
				}
				set
				{
				}
			}

			public bool force4WayHats
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public float defaultAbsoluteAxisPollingDeadZone
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float defaultRelativeAxisPollingDeadZone
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public bool activateActionButtonsOnNegativeValue
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public ThrottleCalibrationMode throttleCalibrationMode
			{
				get
				{
					return default(ThrottleCalibrationMode);
				}
				set
				{
				}
			}

			public bool deferControllerConnectedEventsOnStart
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool autoAssignJoysticks
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public int maxJoysticksPerPlayer
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public bool distributeJoysticksEvenly
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool assignJoysticksToPlayingPlayersOnly
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool reassignJoystickToPreviousOwnerOnReconnect
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public LogLevelFlags logLevel
			{
				get
				{
					return default(LogLevelFlags);
				}
				set
				{
				}
			}

			private ConfigHelper()
			{
			}
		}

		public sealed class ControllerHelper : CodeHelper
		{
			public sealed class PollingHelper : CodeHelper
			{
				private sealed class neSbfdIbpEPTtKFTyXjZhALpApG : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public PollingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public ControllerPollingInfo RNdRlnyRoNCBMSXafycqqAtdvHf;

					public ControllerPollingInfo eVPAcUHwrIdqPQrnEjJreCEigaYt;

					public ControllerPollingInfo flKGLrdTLfuMPVtHNyJzqdEpPuoT;

					public ControllerPollingInfo JZxbwedUXkFwJveMSijfcLgJgKog;

					public IEnumerator<ControllerPollingInfo> SBUOMOTTDLdDQiYqkYDEEBAMYfG;

					public IEnumerator<ControllerPollingInfo> BWorIddQpIByGeOghkzreWOAbnIe;

					public IEnumerator<ControllerPollingInfo> fDzalPdVfQTRXnwmxLsrfJdKrbg;

					public IEnumerator<ControllerPollingInfo> GXxwPtOXmFAUkYhhSijjGjpseoa;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ControllerPollingInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public neSbfdIbpEPTtKFTyXjZhALpApG(int _003C_003E1__state)
					{
					}

					private void KAheraDPnchCARbeBrToDZcARDYw()
					{
					}

					private void dcfSPDQXNJVNCZMISquiQQGeUeG()
					{
					}

					private void dEHpvorbGtSWmwJoQCgNdHyjrIP()
					{
					}

					private void VJqyyTtsUAbNhADxeqNNguCMMnN()
					{
					}
				}

				private sealed class RnvOIrgiavfMuUaqbFDEqAXGKkm : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public PollingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public ControllerPollingInfo JdmeNwzFzZIqyxsnankyQCdNxrq;

					public ControllerPollingInfo OAriAwCkCtJQjnlNBCzQkZIBdCu;

					public ControllerPollingInfo hRYeFWcPoYriaEhdDpGVaUqknAG;

					public ControllerPollingInfo DNEeEYaIhbYBKRSqUMZIFFvHPgU;

					public IEnumerator<ControllerPollingInfo> LQVMEHUPNlKFpZUvqJllxsbuOXz;

					public IEnumerator<ControllerPollingInfo> ilwxgzmHohRhTtvyLrzTbaUxFOFD;

					public IEnumerator<ControllerPollingInfo> DVvYIGRYSpAXUrVaQrHHOsmTbzx;

					public IEnumerator<ControllerPollingInfo> uZXHdpVqrZrilNDOvgLVOEABCeLH;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ControllerPollingInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public RnvOIrgiavfMuUaqbFDEqAXGKkm(int _003C_003E1__state)
					{
					}

					private void CkdXqlFMXOeRaJKQZyAdHsyFdLPE()
					{
					}

					private void HCaKunZccMeouUPhDwbIfCMGaMt()
					{
					}

					private void ArYlgYphqcaxZDjPkFXusAjpvCum()
					{
					}

					private void gCdguuigYAIGYYDKzcNSMzXVCirN()
					{
					}
				}

				private sealed class AFnKSmILANPipkbmEJADRpEDHTRd : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public PollingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public ControllerPollingInfo fsUeCGHxTSfPhwfgIVppcHNepLG;

					public ControllerPollingInfo IXWasoCJZEqsrGQdymoTqFHTPhR;

					public ControllerPollingInfo oieFisSOKpdTgksrgmqLNqAMVgcF;

					public ControllerPollingInfo bsXQmfgyMxRCPjDSoJWWpeykbDh;

					public IEnumerator<ControllerPollingInfo> oodLaVPbgFaxLDAPKfnZdudkRwKq;

					public IEnumerator<ControllerPollingInfo> TwbinzKLdJXWhBlhJlqAlCXDDLK;

					public IEnumerator<ControllerPollingInfo> tOrmjEFoeekYVlomLBNiScliRsa;

					public IEnumerator<ControllerPollingInfo> scOJCBmkySaFRHGQPlLOtccngpFa;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ControllerPollingInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public AFnKSmILANPipkbmEJADRpEDHTRd(int _003C_003E1__state)
					{
					}

					private void iVgbLpFLHSlCdsfFVBAFQmqiDhh()
					{
					}

					private void nRTfGKJyDCkjdGLFgDcqGzPNRdPt()
					{
					}

					private void zzrzWJwYMAKvvJwsFsTVODJOaIof()
					{
					}

					private void UhhUGPOToqLuktNkjRFbNTtujGI()
					{
					}
				}

				private sealed class JwJbNkbyQigEtKXSXZaDGfUPlKjf : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public PollingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public ControllerPollingInfo LUYVDDLWebhygOGYDqoSkKXtnVv;

					public ControllerPollingInfo AwAGrPFFUcAQUHVhbDJVHoAfhgAe;

					public ControllerPollingInfo lPJHeOZYkInUiuDvzoNOODnCtPB;

					public ControllerPollingInfo OUZyUsicoOIGesHZZGynSaNkdQx;

					public IEnumerator<ControllerPollingInfo> DnpDSXGrNZECzgQOfgRYSgybQuDZ;

					public IEnumerator<ControllerPollingInfo> RUemHXYXrEOIbhcaELJIKvJDSOY;

					public IEnumerator<ControllerPollingInfo> phTAkCGRpHJpPcpyXCZhZHvltivp;

					public IEnumerator<ControllerPollingInfo> pEYfYBOHtiFAbpJEycLpiaglloPz;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ControllerPollingInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public JwJbNkbyQigEtKXSXZaDGfUPlKjf(int _003C_003E1__state)
					{
					}

					private void utuLfhrgiTxKKgHBdUTZVcZDqXA()
					{
					}

					private void qYksSOvzKyudMvBynXAkyeZBCro()
					{
					}

					private void BWTNYEDfupiBQulZeCviDFtdkCkC()
					{
					}

					private void aHruvuiczbUxcRMRjquPbrHEPsu()
					{
					}
				}

				private sealed class aHljdDlpkFvumCikhnVDwKqHIMi : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public PollingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public ControllerPollingInfo ZTwjfrnMDuqFJgLrWiJrwMDqVAe;

					public ControllerPollingInfo eSMLShAOoEwvCeYDTHjsPTgZjPj;

					public ControllerPollingInfo rrZYrbPUIMXqqJOptBSEtEXxiwM;

					public IEnumerator<ControllerPollingInfo> oIfqClsBevlsCAPnNdaPkUvxiKNv;

					public IEnumerator<ControllerPollingInfo> mZeWyoAVcIGLZKPmyOEKmNQCTdR;

					public IEnumerator<ControllerPollingInfo> pZGmcDvbJqNRbsBvxbcYgZPBVza;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ControllerPollingInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public aHljdDlpkFvumCikhnVDwKqHIMi(int _003C_003E1__state)
					{
					}

					private void DXJSIeUbfbELzSElmFJjwLxUdbB()
					{
					}

					private void HDMpOqVWZGHNgYngjppkLbhexKq()
					{
					}

					private void JqJtWlbqHiCZZoOuSYOiYFFdeiw()
					{
					}
				}

				private sealed class EXmbybEVcIUCjPAaLWqfSlBmnDJ : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public IList<Joystick> TnKgsoLGTwIyeRTuSPssQjvHSso;

					public int UECpCcaSlMAUbNiTCkgOInqTDpj;

					public ControllerPollingInfo nLCDbYtltssaAMpNsbuRgHlkswi;

					public PollingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ControllerPollingInfo> oJgUSRuLYqsIDhFyrqVPFBHbFwx;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ControllerPollingInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public EXmbybEVcIUCjPAaLWqfSlBmnDJ(int _003C_003E1__state)
					{
					}

					private void SrtrPREFIDnbyDhhALKFHQDRheL()
					{
					}
				}

				private sealed class MoeCgdyrJPULwQvZJERyfpgvzgO : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public IList<Joystick> EADoQmdQtXzOgDRwEnuoTWOfvOF;

					public int orBDYJwDYSFrLNcmZOKdmPAlxIe;

					public ControllerPollingInfo fTAMBmqeotVBLioFXKAYhpGzKZt;

					public PollingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ControllerPollingInfo> cYmsNoMGlrndAVjXNuVjeTEWrgP;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ControllerPollingInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public MoeCgdyrJPULwQvZJERyfpgvzgO(int _003C_003E1__state)
					{
					}

					private void GLUnlINfbuSKUXsTtnSRoSvdoGX()
					{
					}
				}

				private sealed class GccPiaLwPPRotXMXVsrXimVAfuA : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public IList<Joystick> LHBXuRxUlQmJOTPSCJQDQOXJqsD;

					public int QrxFezoshivOEntETmqfaPCOuCF;

					public ControllerPollingInfo SpGIxmiIFXwdfzfnVYEDtfBIVdg;

					public PollingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ControllerPollingInfo> faBUdtgTuwxWIvrZZtxsGHgYUmu;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ControllerPollingInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public GccPiaLwPPRotXMXVsrXimVAfuA(int _003C_003E1__state)
					{
					}

					private void NpMJhiXzmRJrpBnGIbUDYykwROA()
					{
					}
				}

				private sealed class TgDnahMgjnERcNUViQcfBQNiXgF : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public IList<Joystick> SvXyWGqYGHPlswaJlYAeTeFcdzsc;

					public int bOgksqsFWMbpxNdCWmTxXuGHEec;

					public ControllerPollingInfo ABmAaPgZJBQTecFlQNBhOCXnjnI;

					public PollingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ControllerPollingInfo> qzSfjPeSURieIBZvyuZQGObHpWq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ControllerPollingInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public TgDnahMgjnERcNUViQcfBQNiXgF(int _003C_003E1__state)
					{
					}

					private void krdQavEtviMfpCkqqNvBFDnmVgl()
					{
					}
				}

				private sealed class fQTSpkubGvLekjhgFZXthYqlcJd : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public IList<Joystick> OPKbnyazSMJBOwTSsFkaKsLZYXwC;

					public int hItBUlPVvtiGsfbkpdBFThOVouK;

					public ControllerPollingInfo zPQINGSScGaZvbTGDZfVfdBorVW;

					public PollingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ControllerPollingInfo> RUtbvTtMAFLgMOAbpELvFNuOZhGO;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ControllerPollingInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public fQTSpkubGvLekjhgFZXthYqlcJd(int _003C_003E1__state)
					{
					}

					private void QmnNjqJylUNDULpxakDhvOtQgbAk()
					{
					}
				}

				private sealed class iKRipCuAUsIRwvOcJxLGtTpqKeh : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public IList<CustomController> rVPSgJKzjohlkSzwOQROOsMJMxc;

					public int PLchJtpOqNlFVpgIjEpvEUuqbubl;

					public ControllerPollingInfo QbPcQQiNcUrcAiBrFPzQEEhAEwgT;

					public PollingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ControllerPollingInfo> mWtamukwMLrLqyRRXYRirlaXNOK;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ControllerPollingInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public iKRipCuAUsIRwvOcJxLGtTpqKeh(int _003C_003E1__state)
					{
					}

					private void koTuhgCVQdbxJechUdcpEQspOZJp()
					{
					}
				}

				private sealed class vrKxnOrVQSOpimkXKNaCjgOhfQZ : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public IList<CustomController> qgGMGXPXHMenOjILEngLsdaJHgsD;

					public int mYYrKvLQeApAuTUYhHPbqrlHljp;

					public ControllerPollingInfo CktKVlIKIwwFnUJbAGCWrIipFKzH;

					public PollingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ControllerPollingInfo> aAlAnaPfpFBMedDGfyTdiSIYDQhZ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ControllerPollingInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public vrKxnOrVQSOpimkXKNaCjgOhfQZ(int _003C_003E1__state)
					{
					}

					private void calHXTNSEKBlYjvhuEWgEvobLtS()
					{
					}
				}

				private sealed class OOzznaXMwmNrfvAkYlFcWCuigJZ : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public IList<CustomController> suDXtUWmWNJzQqgvNbwynevikTM;

					public int UChMiPifGqYafnEbyfPxWsyUuJp;

					public ControllerPollingInfo tGNAHFGbvzQQOpNwBxGBbyDDaDB;

					public PollingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ControllerPollingInfo> grMisnBEeorGaTRhEuXnreMawVe;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ControllerPollingInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public OOzznaXMwmNrfvAkYlFcWCuigJZ(int _003C_003E1__state)
					{
					}

					private void PtuDCJDLgMrhnabPCJliaraeArJv()
					{
					}
				}

				private sealed class YcZSVgzCOaHhhHtXFyGXhpfVuOn : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public IList<CustomController> MwUQfFeAEHtlzaUOlPRhsuCbfjp;

					public int RKFWYhCNruwTVmnVTpBjkNCefxJ;

					public ControllerPollingInfo vOngJKRlwLjGXvqBgKmBgwOiJWM;

					public PollingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ControllerPollingInfo> PUwtJkxDXAetnfebOQHHIgehqhjc;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ControllerPollingInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public YcZSVgzCOaHhhHtXFyGXhpfVuOn(int _003C_003E1__state)
					{
					}

					private void zpoGTQhHNAIliPwVLDISBgEgmaN()
					{
					}
				}

				private sealed class cSSVWptCpZRIEpvplerlKDYdcig : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public IList<CustomController> PtRrpeNFYBsRiharYxpJhpNKYGg;

					public int GqvXMMfQqHGcNzqpGNgVyckZOML;

					public ControllerPollingInfo IiEvWgdEKPOGlxeNKyYwgxhjlNf;

					public PollingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ControllerPollingInfo> iacMEgbCdAqSnonYKHbMikAhIEm;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ControllerPollingInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public cSSVWptCpZRIEpvplerlKDYdcig(int _003C_003E1__state)
					{
					}

					private void pfrIKKijdTgqZMoWYMipFuJtKyE()
					{
					}
				}

				private static PollingHelper TGpVjpCnXnesTEFRakRpmLikuhU;

				internal static PollingHelper Instance => null;

				private PollingHelper()
				{
				}

				public ControllerPollingInfo PollAllControllersForFirstElement()
				{
					return default(ControllerPollingInfo);
				}

				public ControllerPollingInfo PollAllControllersForFirstElementDown()
				{
					return default(ControllerPollingInfo);
				}

				public ControllerPollingInfo PollAllControllersForFirstButton()
				{
					return default(ControllerPollingInfo);
				}

				public ControllerPollingInfo PollAllControllersForFirstButtonDown()
				{
					return default(ControllerPollingInfo);
				}

				public ControllerPollingInfo PollAllControllersForFirstAxis()
				{
					return default(ControllerPollingInfo);
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					return default(ControllerPollingInfo);
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
				{
					return default(ControllerPollingInfo);
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					return default(ControllerPollingInfo);
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					return default(ControllerPollingInfo);
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					return default(ControllerPollingInfo);
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					return default(ControllerPollingInfo);
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					return default(ControllerPollingInfo);
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					return default(ControllerPollingInfo);
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					return default(ControllerPollingInfo);
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					return default(ControllerPollingInfo);
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					return null;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					return null;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					return null;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					return null;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
				{
					return null;
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					return null;
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					return null;
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					return null;
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					return null;
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					return null;
				}

				private ControllerPollingInfo SOfGHjSxNyWGXeXYSPgXktHiiKh()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo UodFzAEOBWOkAvGnSYuEAJgOUpe()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo qMQGYDdLTjDdJaFFIKoXTvaaEoeD()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo qWBbJePwFAuCHdhBpyJuQlizfqy()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo tMcbORuTUNBVxDEEzdHbmeRcvPr()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo YiplVltgiPDfgdhfvaCsjbDGiTO(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo QIRARxpYpJJHFTeRAHHlFYrgHfh(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo kSKtEubfCaAGjxOZBLUJGiJAbELF(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo oyIePcntjYtBFTHVXnGWqJbaCfuD(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo BHzDDyTddyDJxISMbqmCghfcHAsm(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo gqBoybFfWNKZeHzbQtDqsDlMcMj()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo DZlAyJvQNAvQEoyqRlIFRPkrxTF()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo IygUZdNyXUkByArjQpnZKkkwaHr()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo HTlJajOxBMbevHuSKMZrYvyjGpo()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo FbJWOOuMuudBffppRLtyjZkAwjF()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo dhRFvtaBevoPlgYgHDligEYlgHIZ()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo FzYmZemfpskTtgwxyyyqmjHCvwd()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo HvaAelquHReHXePkEXHBImrVSVa()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo sTKzPnixBARyEHvjYCXstYFFscX()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo KFKCsTApnRZjJDbGeRXsXeaWeFPd()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo qUKFMppCaShkxQLvWFMvANBMQpp()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo HZMYRjydeNGoupsQytdGWcRpadg()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo VCbuNkqeyiBBtalbdxFFtBaIIxO(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo pKDAVbkHPZVLKWUqykrbFBrvYqR(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo cvkyAjBGobGsvcbLTcQtzTOtOQs(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo juToTCUQqRCxbJzRmwUzhzSjjfz(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo PgdpJbbHmhiVeohKPkyUmnDEnDc(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private IEnumerable<ControllerPollingInfo> xAYCMmbCPdYNrSTtLAruKHTrLod()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> MYznxLmMPeVAJxumdKyMvYkBVPp()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> eKrNyFyKmEWQRZnWXaehCUScoii()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> BvzushtUdIRulUuyzssbCrdcemx()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> bdZJOqLbFKyoiSPhsIjdduevhjn()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> upTJpjhoZuvFXTDRQrpTVvGAeBI(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> uLWFOngogNpYdDQpOIHKagrCqkeT(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> QyeAsYDOvUdFHbdCTYagmBvgBrWB(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> tSEDVmvLZjqrImIjyFPUrkilqeU(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> hvRAktCHaCEUNnSEnnDqZuDeKaR(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> LUUbumAolgHknWlGZskOFvxKPmII()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> zHGgjXjIAzHacYYKphPioHKQISTd()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> cINhBYwyOkTRdEugxTECJrBhFBR()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> wNFmglEyNVMDDzSPueIBYhCcojm()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> FqraSRHyFMEoLxrTLRtcjMqdKVum()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> fqgYdXJynYCwbSBvMSMFdYgPxhZ()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> bqdkHVjxDlgDmNSPwmMknJaMtHa()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> KLcdwfLtCfAJeROoEGcfqwhLUUd()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> onFYNwieDXkHBPCljItqFxEmVgI()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> tRrCKfFQukIvLdIHGhbSLmVkwouO()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> JGnpkUnjugXFvegOIHgCTRXSFUb()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> HsmPXaRipnqMpyjplsxsiMesbgs()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> TaLLAVWpFJqVAFFdmfHHmbwHAOu(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> wrzbSizGEOlQBtHDrZplvHFjCTOg(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> lmMAjXPKivCxiFcCHLhLGoWyUjPb(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> xFWFuNvmAkdCTRACAPgezbAlPwg(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> gfsIxMNlzvonCzdcOmyOcUxzzN(int P_0)
				{
					return null;
				}
			}

			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class BjrWQmCIpqbFfsBiNGXkGLAOwyS : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public int LozxQHDUasgVhVpgQCMsCoaOoRQa;

					public int PVBatSkKauKaSTzoUOBQBuOwATsg;

					public int dmVVbczeaCsFvVlUOANGmDPpdjY;

					public int cpJjwdSNMvrOCNwqaaEADHyKdU;

					public JoystickMap CyesuxKFWENHXtdvBKZTBgQEWRo;

					public JoystickMap HhjztKPjrNeJYwADQXiduNVahcCG;

					public ActionElementMap EDWFCzOVLHsqkpZPPqKwiFQBcYy;

					public ActionElementMap CQWZLgEUghLEEaVvpARqJjmQbSW;

					public bool HBseOILqjrzUkLMAUPTCmnVdhbRE;

					public bool MaAQcnrNeDUCjdqpVbuQETeHnscA;

					public bool vcsXBogmRHHHEXXhzNqtGJrbEKbI;

					public bool ATSwtOJSSOSYfvqWYHMvPYeKghS;

					public bool ThWuOkjYNJTJSaMuTVayKPjAehL;

					public bool OMRryAQCVfXrHXaBIlfrWnTKXZy;

					public IList<Player> txLMcuggzDcFOtJbIotPReoZLM;

					public int qxpyNtJddRJAuThRjVGlaRMSitX;

					public ElementAssignmentConflictInfo vVEzPNiYvZlHHMHTevatOFapCds;

					public ConflictCheckingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ElementAssignmentConflictInfo> iUpDWyYjpNEOIjQknItRAOIkpCKv;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ElementAssignmentConflictInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public BjrWQmCIpqbFfsBiNGXkGLAOwyS(int _003C_003E1__state)
					{
					}

					private void uYbAWSmDVenynAuelGfUIWVBnCN()
					{
					}
				}

				private sealed class sZzqjaIWOoMcLkblmykUhrVmQtf : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public ElementAssignmentConflictCheck DVecMnGaKZxCPkJcxFoCLXyrGApj;

					public ElementAssignmentConflictCheck EfbpiPQTyiOIQmCEvacMvGiwrkd;

					public bool HBseOILqjrzUkLMAUPTCmnVdhbRE;

					public bool MaAQcnrNeDUCjdqpVbuQETeHnscA;

					public bool vcsXBogmRHHHEXXhzNqtGJrbEKbI;

					public bool ATSwtOJSSOSYfvqWYHMvPYeKghS;

					public bool ThWuOkjYNJTJSaMuTVayKPjAehL;

					public bool OMRryAQCVfXrHXaBIlfrWnTKXZy;

					public IList<Player> jhcbHeDEWfHekHXvrEvXfncEzJx;

					public int RmBjhvXZPFdyGjWYRiCNvpoTxgU;

					public ElementAssignmentConflictInfo xcIQyLFvccKcHzAInUdyeAtJkWF;

					public ConflictCheckingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ElementAssignmentConflictInfo> QuKBOjcyMEXkpihzIfHmerwhCzpX;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ElementAssignmentConflictInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public sZzqjaIWOoMcLkblmykUhrVmQtf(int _003C_003E1__state)
					{
					}

					private void crHuUCjvsfhDuoOxMLWiffytpgI()
					{
					}
				}

				private sealed class BtbgMeLOwggTcUbExGuTeqvTXAt : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public int LozxQHDUasgVhVpgQCMsCoaOoRQa;

					public int PVBatSkKauKaSTzoUOBQBuOwATsg;

					public KeyboardMap efpZyZTuAEuoPmTnJghtbvxoKCp;

					public KeyboardMap xUKjAxcqSQFoMHOuHQMakISeBCJ;

					public ActionElementMap EDWFCzOVLHsqkpZPPqKwiFQBcYy;

					public ActionElementMap CQWZLgEUghLEEaVvpARqJjmQbSW;

					public bool HBseOILqjrzUkLMAUPTCmnVdhbRE;

					public bool MaAQcnrNeDUCjdqpVbuQETeHnscA;

					public bool vcsXBogmRHHHEXXhzNqtGJrbEKbI;

					public bool ATSwtOJSSOSYfvqWYHMvPYeKghS;

					public bool ThWuOkjYNJTJSaMuTVayKPjAehL;

					public bool OMRryAQCVfXrHXaBIlfrWnTKXZy;

					public IList<Player> xXzFQrKcqZMVlmFvsOYcLSyvuN;

					public int gKeBEeLsxdFKTjgiZokOGZcQICNh;

					public ElementAssignmentConflictInfo NnhyHcYYUfWFJMjWnjvcrGHohYK;

					public ConflictCheckingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ElementAssignmentConflictInfo> HHYmKJzfgLeizJhrJvZSoOwuxRk;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ElementAssignmentConflictInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public BtbgMeLOwggTcUbExGuTeqvTXAt(int _003C_003E1__state)
					{
					}

					private void IlmnBDeBmFcuYXIPSVaBVccHPlv()
					{
					}
				}

				private sealed class wEcqlWRLJnqokUoGhabVVIMJEUB : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public ElementAssignmentConflictCheck DVecMnGaKZxCPkJcxFoCLXyrGApj;

					public ElementAssignmentConflictCheck EfbpiPQTyiOIQmCEvacMvGiwrkd;

					public bool HBseOILqjrzUkLMAUPTCmnVdhbRE;

					public bool MaAQcnrNeDUCjdqpVbuQETeHnscA;

					public bool vcsXBogmRHHHEXXhzNqtGJrbEKbI;

					public bool ATSwtOJSSOSYfvqWYHMvPYeKghS;

					public bool ThWuOkjYNJTJSaMuTVayKPjAehL;

					public bool OMRryAQCVfXrHXaBIlfrWnTKXZy;

					public IList<Player> lxoKSjOifiqjAEfqWrKAZGtVyTF;

					public int qgYZgRzbXRGxASswkkmODzaCnyf;

					public ElementAssignmentConflictInfo zUDGgbCnMrFKWYxxMkdtKlmCzzi;

					public ConflictCheckingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ElementAssignmentConflictInfo> MOgpBCeDAHqIEhVgMhDOGwcIktw;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ElementAssignmentConflictInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public wEcqlWRLJnqokUoGhabVVIMJEUB(int _003C_003E1__state)
					{
					}

					private void DWvcbjApMjCLsqKZyrEScUWLiFIR()
					{
					}
				}

				private sealed class hfBiKwClGnyGiSLUyJIyNODwvkS : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public int LozxQHDUasgVhVpgQCMsCoaOoRQa;

					public int PVBatSkKauKaSTzoUOBQBuOwATsg;

					public MouseMap oIlGiWERyjqlDXHDZSgyxwtdSNF;

					public MouseMap EzZNiwkkEsbHbGwMFjTFPgoxnZPc;

					public ActionElementMap EDWFCzOVLHsqkpZPPqKwiFQBcYy;

					public ActionElementMap CQWZLgEUghLEEaVvpARqJjmQbSW;

					public bool HBseOILqjrzUkLMAUPTCmnVdhbRE;

					public bool MaAQcnrNeDUCjdqpVbuQETeHnscA;

					public bool vcsXBogmRHHHEXXhzNqtGJrbEKbI;

					public bool ATSwtOJSSOSYfvqWYHMvPYeKghS;

					public bool ThWuOkjYNJTJSaMuTVayKPjAehL;

					public bool OMRryAQCVfXrHXaBIlfrWnTKXZy;

					public IList<Player> DrIkTyIWcdpqQcTQRQDuDNjghCT;

					public int vhCFbXufcGSrSrwwBMYjCHqdkYu;

					public ElementAssignmentConflictInfo bjrHIzcBxKGyUARtNIcOHAgWqeq;

					public ConflictCheckingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ElementAssignmentConflictInfo> sBcuokyRTfhtXtiTVOCVblvcmMh;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ElementAssignmentConflictInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public hfBiKwClGnyGiSLUyJIyNODwvkS(int _003C_003E1__state)
					{
					}

					private void kYqjpIzgAlSZZabOafoexRDEHjg()
					{
					}
				}

				private sealed class SvqLHiMoPajxYEhEANDDxVxFfdi : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public ElementAssignmentConflictCheck DVecMnGaKZxCPkJcxFoCLXyrGApj;

					public ElementAssignmentConflictCheck EfbpiPQTyiOIQmCEvacMvGiwrkd;

					public bool HBseOILqjrzUkLMAUPTCmnVdhbRE;

					public bool MaAQcnrNeDUCjdqpVbuQETeHnscA;

					public bool vcsXBogmRHHHEXXhzNqtGJrbEKbI;

					public bool ATSwtOJSSOSYfvqWYHMvPYeKghS;

					public bool ThWuOkjYNJTJSaMuTVayKPjAehL;

					public bool OMRryAQCVfXrHXaBIlfrWnTKXZy;

					public IList<Player> lLEGAwUFWMjqglSDfyxSLQVPHyP;

					public int wskEXrLPICAsvkDYKYcvNVLZAwIc;

					public ElementAssignmentConflictInfo MNyKxsbmgVxbXenBMDJlhndGUwP;

					public ConflictCheckingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ElementAssignmentConflictInfo> nTFvfNGcphVPrlAImPnXIRNFqMd;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ElementAssignmentConflictInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public SvqLHiMoPajxYEhEANDDxVxFfdi(int _003C_003E1__state)
					{
					}

					private void uScgRUCgCpaKMMYJGmGAxiFWynmW()
					{
					}
				}

				private sealed class AqHzCVvOWtMrevsZcmEEFbsLMsB : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public int LozxQHDUasgVhVpgQCMsCoaOoRQa;

					public int PVBatSkKauKaSTzoUOBQBuOwATsg;

					public int dmVVbczeaCsFvVlUOANGmDPpdjY;

					public int cpJjwdSNMvrOCNwqaaEADHyKdU;

					public CustomControllerMap GcGfBLgXOGIhuAJTzGBuOlHCcK;

					public CustomControllerMap jHMvNSzVbAbHoZRLVezpCRckOUC;

					public ActionElementMap EDWFCzOVLHsqkpZPPqKwiFQBcYy;

					public ActionElementMap CQWZLgEUghLEEaVvpARqJjmQbSW;

					public bool HBseOILqjrzUkLMAUPTCmnVdhbRE;

					public bool MaAQcnrNeDUCjdqpVbuQETeHnscA;

					public bool vcsXBogmRHHHEXXhzNqtGJrbEKbI;

					public bool ATSwtOJSSOSYfvqWYHMvPYeKghS;

					public bool ThWuOkjYNJTJSaMuTVayKPjAehL;

					public bool OMRryAQCVfXrHXaBIlfrWnTKXZy;

					public IList<Player> EbvSgaWlqBWJCuiKslNTDbUtwk;

					public int kIqVHLSLwZVrdNIBFguvwDPPVYf;

					public ElementAssignmentConflictInfo aVgPFJWDFkBZRhElNswXIHvQZxnd;

					public ConflictCheckingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ElementAssignmentConflictInfo> SSfqZLLCnDGOUrLMfbGtJrImYGHi;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ElementAssignmentConflictInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public AqHzCVvOWtMrevsZcmEEFbsLMsB(int _003C_003E1__state)
					{
					}

					private void VzByaBgJaOfsgWPAXgpYVfOHOTD()
					{
					}
				}

				private sealed class ZIWGacKAFEsXeKVyntemBiOxpxIJ : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo BkCCsqltFMRNvCZoZtUjDVFIQQJ;

					private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

					private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

					public ElementAssignmentConflictCheck DVecMnGaKZxCPkJcxFoCLXyrGApj;

					public ElementAssignmentConflictCheck EfbpiPQTyiOIQmCEvacMvGiwrkd;

					public bool HBseOILqjrzUkLMAUPTCmnVdhbRE;

					public bool MaAQcnrNeDUCjdqpVbuQETeHnscA;

					public bool vcsXBogmRHHHEXXhzNqtGJrbEKbI;

					public bool ATSwtOJSSOSYfvqWYHMvPYeKghS;

					public bool ThWuOkjYNJTJSaMuTVayKPjAehL;

					public bool OMRryAQCVfXrHXaBIlfrWnTKXZy;

					public IList<Player> TjGBXOBxXoIDnJZLgxMhEKoVAPKj;

					public int OFbnCmGEuXKcEouiYASDlbYObec;

					public ElementAssignmentConflictInfo CHfCLGJIdWlERrsSIdakzSkcSMkM;

					public ConflictCheckingHelper TiaUIShtPVkFOKyDFxywSfPUjyv;

					public IEnumerator<ElementAssignmentConflictInfo> OEhJDOKfBWiexLdsbwcTlkJRlnt;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return default(ElementAssignmentConflictInfo);
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public ZIWGacKAFEsXeKVyntemBiOxpxIJ(int _003C_003E1__state)
					{
					}

					private void dgXGEKhGuIICdjAPKMHGUAikpTam()
					{
					}
				}

				private static ConflictCheckingHelper TGpVjpCnXnesTEFRakRpmLikuhU;

				internal static ConflictCheckingHelper Instance => null;

				private ConflictCheckingHelper()
				{
				}

				public bool DoesAnyElementAssignmentConflict()
				{
					return false;
				}

				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps)
				{
					return false;
				}

				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return false;
				}

				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					return false;
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return false;
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return false;
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return false;
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					return false;
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
				{
					return false;
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return false;
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return false;
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					return false;
				}

				private bool azduFoKbdaGUmyQkePIQWRNyicP(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return false;
				}

				private bool azduFoKbdaGUmyQkePIQWRNyicP(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool HqDMZoABoPGoDeFJRkGNbwfAfeZ(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return false;
				}

				private bool HqDMZoABoPGoDeFJRkGNbwfAfeZ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool PGeCjsVRrnLapkNXRATmiBEajqs(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return false;
				}

				private bool PGeCjsVRrnLapkNXRATmiBEajqs(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool gLEXDqQKLZgKXWyueYcemKOosUo(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return false;
				}

				private bool gLEXDqQKLZgKXWyueYcemKOosUo(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return null;
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return null;
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return null;
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					return null;
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return null;
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return null;
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return null;
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> lPLLFVHyRQcWsWLuYacHlZVYMgw(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> lPLLFVHyRQcWsWLuYacHlZVYMgw(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> ATybotAOycjMXTZnHXFLINGSbopY(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> ATybotAOycjMXTZnHXFLINGSbopY(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> ltOoDmbcvfCSpSUfVpwoYDKVsFp(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> ltOoDmbcvfCSpSUfVpwoYDKVsFp(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> UaGXlaZMOtzlYqgGLPJbxtsfAfX(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> UaGXlaZMOtzlYqgGLPJbxtsfAfX(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return 0;
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return 0;
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return 0;
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					return 0;
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return 0;
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return 0;
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return 0;
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					return 0;
				}

				private int WSLeYydMYZVQQkWCiMlCsFFyMNBT(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int WSLeYydMYZVQQkWCiMlCsFFyMNBT(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int riEGFZEDEfCtgslvuiEANPofzSnd(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int riEGFZEDEfCtgslvuiEANPofzSnd(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int DkwDtuyvDPdRefttyqNbMfJKrSPK(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int DkwDtuyvDPdRefttyqNbMfJKrSPK(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int DEBQAzBmbGgJAHZEhuLdIfBSCkpB(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int DEBQAzBmbGgJAHZEhuLdIfBSCkpB(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return 0;
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return 0;
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return 0;
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					return 0;
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return 0;
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return 0;
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return 0;
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					return 0;
				}

				private int mEjMzcZsEvkqZEkMmctIyaAgzZe(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int mEjMzcZsEvkqZEkMmctIyaAgzZe(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int pSWPRIuVRblYFkHiuesZhzQUote(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int pSWPRIuVRblYFkHiuesZhzQUote(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int ElChPmTbtccHIShnbARttgyxCID(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int ElChPmTbtccHIShnbARttgyxCID(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int ZXayEveMDngzBSolTzlWFdAcMoo(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int ZXayEveMDngzBSolTzlWFdAcMoo(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}
			}

			private static ControllerHelper TGpVjpCnXnesTEFRakRpmLikuhU;

			public readonly PollingHelper polling;

			public readonly ConflictCheckingHelper conflictChecking;

			internal static ControllerHelper Instance => null;

			public int controllerCount => 0;

			public IList<Controller> Controllers => null;

			public Mouse Mouse => null;

			public Keyboard Keyboard => null;

			[Obsolete]
			public bool keyboardEnabled
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public int joystickCount => 0;

			public IList<Joystick> Joysticks => null;

			public int customControllerCount => 0;

			public IList<CustomController> CustomControllers => null;

			private ControllerHelper()
			{
			}

			public T GetController<T>(int controllerId) where T : Controller
			{
				return null;
			}

			public int GetControllerCount(ControllerType controllerType)
			{
				return 0;
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				return null;
			}

			public Controller GetController(ControllerIdentifier controllerIdentifier)
			{
				return null;
			}

			public Controller[] GetControllers(ControllerType controllerType)
			{
				return null;
			}

			public string[] GetControllerNames(ControllerType controllerType)
			{
				return null;
			}

			public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
			{
				return false;
			}

			public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
			{
				return false;
			}

			public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
			{
				return false;
			}

			public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
			{
			}

			public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
			{
			}

			public Joystick GetJoystick(int joystickId)
			{
				return null;
			}

			public Joystick[] GetJoysticks()
			{
				return null;
			}

			public string[] GetJoystickNames()
			{
				return null;
			}

			public bool IsJoystickAssigned(Joystick joystick)
			{
				return false;
			}

			public bool IsJoystickAssigned(int joystickId)
			{
				return false;
			}

			public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
			{
				return false;
			}

			public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
			{
			}

			public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
			{
			}

			public int GetUnityJoystickIdFromAnyButtonPress()
			{
				return 0;
			}

			public int GetUnityJoystickIdFromAnyButtonOrAxisPress(float axisThreshold, bool positiveAxesOnly)
			{
				return 0;
			}

			public void SetUnityJoystickId(int joystickId, int unityJoystickId)
			{
			}

			public bool SetUnityJoystickIdFromAnyButtonPress(int joystickId)
			{
				return false;
			}

			public bool SetUnityJoystickIdFromAnyButtonOrAxisPress(int joystickId, float axisThreshold, bool positiveAxesOnly)
			{
				return false;
			}

			public CustomController GetCustomController(int customControllerId)
			{
				return null;
			}

			public CustomController[] GetCustomControllers()
			{
				return null;
			}

			public string[] GetCustomControllerNames()
			{
				return null;
			}

			public bool IsCustomControllerAssigned(CustomController customController)
			{
				return false;
			}

			public bool IsCustomControllerAssigned(int customControllerId)
			{
				return false;
			}

			public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
			{
				return false;
			}

			public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
			{
			}

			public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
			{
			}

			public CustomController CreateCustomController(int sourceControllerId)
			{
				return null;
			}

			public CustomController CreateCustomController(int sourceControllerId, string tag)
			{
				return null;
			}

			public bool DestroyCustomController(CustomController customController)
			{
				return false;
			}

			public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
			{
				return null;
			}

			public CustomController GetFirstCustomControllerWithTag(string tag)
			{
				return null;
			}

			public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
			{
				return null;
			}

			public IEnumerable<CustomController> CustomControllersWithTag(string tag)
			{
				return null;
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				return null;
			}

			public Controller GetLastActiveController()
			{
				return null;
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				return null;
			}

			public T GetLastActiveController<T>() where T : Controller
			{
				return null;
			}

			public ControllerType GetLastActiveControllerType()
			{
				return default(ControllerType);
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
			}

			public bool GetAnyButton()
			{
				return false;
			}

			public bool GetAnyButton(ControllerType controllerType)
			{
				return false;
			}

			public bool GetAnyButtonDown()
			{
				return false;
			}

			public bool GetAnyButtonDown(ControllerType controllerType)
			{
				return false;
			}

			public bool GetAnyButtonUp()
			{
				return false;
			}

			public bool GetAnyButtonUp(ControllerType controllerType)
			{
				return false;
			}

			public bool GetAnyButtonChanged()
			{
				return false;
			}

			public bool GetAnyButtonChanged(ControllerType controllerType)
			{
				return false;
			}

			public bool GetAnyButtonPrev()
			{
				return false;
			}

			public bool GetAnyButtonPrev(ControllerType controllerType)
			{
				return false;
			}

			public bool AutoAssignJoystick(Joystick joystick)
			{
				return false;
			}

			public void AutoAssignJoysticks()
			{
			}
		}

		public sealed class MappingHelper : CodeHelper
		{
			private static MappingHelper TGpVjpCnXnesTEFRakRpmLikuhU;

			internal static MappingHelper Instance => null;

			public IList<InputMapCategory> MapCategories => null;

			public IEnumerable<InputMapCategory> UserAssignableMapCategories => null;

			public IList<InputCategory> ActionCategories => null;

			public IEnumerable<InputCategory> UserAssignableActionCategories => null;

			public IList<InputLayout> JoystickLayouts => null;

			public IList<InputLayout> KeyboardLayouts => null;

			public IList<InputLayout> MouseLayouts => null;

			public IList<InputLayout> CustomControllerLayouts => null;

			public IList<InputAction> Actions => null;

			public IEnumerable<InputAction> UserAssignableActions => null;

			private MappingHelper()
			{
			}

			public InputMapCategory GetMapCategory(int mapCategoryId)
			{
				return null;
			}

			public InputMapCategory GetMapCategory(string name)
			{
				return null;
			}

			public int GetMapCategoryId(string name)
			{
				return 0;
			}

			public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
			{
				return null;
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
			{
				return null;
			}

			public bool IsMapCategoryUserAssignable(int mapCategoryId)
			{
				return false;
			}

			public InputCategory GetActionCategory(int mapCategoryId)
			{
				return null;
			}

			public InputCategory GetActionCategory(string name)
			{
				return null;
			}

			public int GetActionCategoryId(string name)
			{
				return 0;
			}

			public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
			{
				return null;
			}

			public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
			{
				return null;
			}

			public bool IsActionCategoryUserAssignable(int mapCategoryId)
			{
				return false;
			}

			public InputLayout GetLayout(ControllerType controllerType, int layoutId)
			{
				return null;
			}

			public InputLayout GetLayout(ControllerType controllerType, string name)
			{
				return null;
			}

			public int GetLayoutId(ControllerType controllerType, string name)
			{
				return 0;
			}

			public InputLayout GetJoystickLayout(int layoutId)
			{
				return null;
			}

			public InputLayout GetJoystickLayout(string name)
			{
				return null;
			}

			public int GetJoystickLayoutId(string name)
			{
				return 0;
			}

			public InputLayout GetKeyboardLayout(int layoutId)
			{
				return null;
			}

			public InputLayout GetKeyboardLayout(string name)
			{
				return null;
			}

			public int GetKeyboardLayoutId(string name)
			{
				return 0;
			}

			public InputLayout GetMouseLayout(int layoutId)
			{
				return null;
			}

			public InputLayout GetMouseLayout(string name)
			{
				return null;
			}

			public int GetMouseLayoutId(string name)
			{
				return 0;
			}

			public InputLayout GetCustomControllerLayout(int layoutId)
			{
				return null;
			}

			public InputLayout GetCustomControllerLayout(string name)
			{
				return null;
			}

			public int GetCustomControllerLayoutId(string name)
			{
				return 0;
			}

			public IList<InputLayout> MapLayouts(ControllerType controllerType)
			{
				return null;
			}

			public InputAction GetAction(int actionId)
			{
				return null;
			}

			public InputAction GetAction(string name)
			{
				return null;
			}

			public int GetActionId(string name)
			{
				return 0;
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
			{
				return null;
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
			{
				return null;
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
			{
				return null;
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
			{
				return null;
			}

			public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
			{
				return null;
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
			{
				return null;
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
			{
				return null;
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
			{
				return null;
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
			{
				return null;
			}

			public IList<InputBehavior> GetInputBehaviors(int playerId)
			{
				return null;
			}

			public IList<InputBehavior> GetSystemPlayerInputBehaviors()
			{
				return null;
			}

			public InputBehavior GetInputBehavior(int playerId, int behaviorId)
			{
				return null;
			}

			public InputBehavior GetInputBehavior(int playerId, string behaviorName)
			{
				return null;
			}

			public InputBehavior GetSystemPlayerInputBehavior(int behaviorId)
			{
				return null;
			}

			public InputBehavior GetSystemPlayerInputBehavior(string behaviorName)
			{
				return null;
			}

			public int GetInputBehaviorId(string behaviorName)
			{
				return 0;
			}

			internal InputBehavior ilpcenjKKAjYRjydohyTcrlcPmLN(int P_0)
			{
				return null;
			}

			internal InputBehavior ilpcenjKKAjYRjydohyTcrlcPmLN(string P_0)
			{
				return null;
			}

			public ControllerMap GetControllerMap(int id)
			{
				return null;
			}

			public ActionElementMap GetActionElementMap(int id)
			{
				return null;
			}

			public ControllerMap GetControllerMapInstance(Controller controller, int mapCategoryId, int layoutId)
			{
				return null;
			}

			public ControllerMap GetControllerMapInstance(Controller controller, string mapCategoryName, string layoutName)
			{
				return null;
			}

			public ControllerMap GetControllerMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				return null;
			}

			public ControllerMap GetControllerMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				return null;
			}

			public JoystickMap GetJoystickMapInstance(Joystick joystick, int mapCategoryId, int layoutId)
			{
				return null;
			}

			public JoystickMap GetJoystickMapInstance(Joystick joystick, string mapCategoryName, string layoutName)
			{
				return null;
			}

			public JoystickMap GetJoystickMapInstance(Guid joystickTypeGuid, int mapCategoryId, int layoutId)
			{
				return null;
			}

			public JoystickMap GetJoystickMapInstance(Guid joystickTypeGuid, string mapCategoryName, string layoutName)
			{
				return null;
			}

			public JoystickMap GetJoystickMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				return null;
			}

			public JoystickMap GetJoystickMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				return null;
			}

			public KeyboardMap GetKeyboardMapInstance(int mapCategoryId, int layoutId)
			{
				return null;
			}

			public KeyboardMap GetKeyboardMapInstance(string mapCategoryName, string layoutName)
			{
				return null;
			}

			public MouseMap GetMouseMapInstance(int mapCategoryId, int layoutId)
			{
				return null;
			}

			public MouseMap GetMouseMapInstance(string mapCategoryName, string layoutName)
			{
				return null;
			}

			public CustomControllerMap GetCustomControllerMapInstance(CustomController customController, int mapCategoryId, int layoutId)
			{
				return null;
			}

			public CustomControllerMap GetCustomControllerMapInstance(CustomController customController, string mapCategoryName, string layoutName)
			{
				return null;
			}

			public CustomControllerMap GetCustomControllerMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				return null;
			}

			public CustomControllerMap GetCustomControllerMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				return null;
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, Controller controller, int mapCategoryId, int layoutId)
			{
				return null;
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, Controller controller, string mapCategoryName, string layoutName)
			{
				return null;
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				return null;
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				return null;
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, Joystick joystick, int mapCategoryId, int layoutId)
			{
				return null;
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, Joystick joystick, string mapCategoryName, string layoutName)
			{
				return null;
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				return null;
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				return null;
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, CustomController customController, int mapCategoryId, int layoutId)
			{
				return null;
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, CustomController customController, string mapCategoryName, string layoutName)
			{
				return null;
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				return null;
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				return null;
			}

			public KeyboardMap GetKeyboardMapInstanceSavedOrDefault(int playerId, int mapCategoryId, int layoutId)
			{
				return null;
			}

			public KeyboardMap GetKeyboardMapInstanceSavedOrDefault(int playerId, string mapCategoryName, string layoutName)
			{
				return null;
			}

			public MouseMap GetMouseMapInstanceSavedOrDefault(int playerId, int mapCategoryId, int layoutId)
			{
				return null;
			}

			public MouseMap GetMouseMapInstanceSavedOrDefault(int playerId, string mapCategoryName, string layoutName)
			{
				return null;
			}

			[Obsolete]
			public ControllerElementIdentifier GetFirstJoystickTemplateElementIdentifier(Joystick joystick, int joystickElementIdentifierId)
			{
				return null;
			}

			private ControllerElementIdentifier OrFsaYlLTpFqXanPtCpJQoAXhtns(Guid P_0, int P_1)
			{
				return null;
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
			{
				return null;
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, string mapCategoryName, string layoutName)
			{
				return null;
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(int id)
			{
				return null;
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(string name)
			{
				return null;
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(int id)
			{
				return null;
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(string name)
			{
				return null;
			}
		}

		public sealed class PlayerHelper : CodeHelper
		{
			private static PlayerHelper TGpVjpCnXnesTEFRakRpmLikuhU;

			internal static PlayerHelper Instance => null;

			public int playerCount => 0;

			public int allPlayerCount => 0;

			public IList<Player> Players => null;

			public IList<Player> AllPlayers => null;

			public Player SystemPlayer => null;

			private PlayerHelper()
			{
			}

			public IList<Player> GetPlayers(bool includeSystemPlayer = false)
			{
				return null;
			}

			public Player GetPlayer(int playerId)
			{
				return null;
			}

			public Player GetPlayer(string name)
			{
				return null;
			}

			public Player GetSystemPlayer()
			{
				return null;
			}

			public int GetPlayerId(string playerName)
			{
				return 0;
			}

			public string[] GetPlayerNames(bool includeSystemPlayer = false)
			{
				return null;
			}

			public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
			{
				return null;
			}

			public int[] GetPlayerIds(bool includeSystemPlayer = false)
			{
				return null;
			}
		}

		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper TGpVjpCnXnesTEFRakRpmLikuhU;

			internal static TimeHelper Instance => null;

			public float unscaledDeltaTime => 0f;

			public double unscaledTime => 0.0;

			public uint currentFrame => 0u;

			private TimeHelper()
			{
			}
		}

		private class boJgboDXhtOpkFRaIkAocTQCligw
		{
			private class xiHGotxvVkwPQorALncbkjhujEW
			{
				public readonly UpdateLoopType JUMcETAAxlprBByLFvikeVngOqaP;

				private double JiIFpHGrbtHxdnLHkfuCzaVWPXWQ;

				private double PAEifLUrkRZeTsFSsdsuOFdpXLL;

				private double cZFbqqkDaKyHuHFNfCmFczaHDGAF;

				private double TuVEaHnoZIAGHTooHALdjaKsAgRr;

				private uint LrGfIKhAjFIYTsNMDkPzihbFQjgG;

				private uint WAhBlvJxAefzZlWRuBfQfhqtxgZy;

				private float bbcfOcCoQhNsmeWRltXTrmlUIkqC;

				private float CYKOSYnbQJxSgFIdbynNCLTrAtGK;

				public double unscaledTime => 0.0;

				public double unscaledTimePrev => 0.0;

				public double unscaledDeltaTime => 0.0;

				public uint frame => 0u;

				public uint framePrev => 0u;

				public float unityUnscaledDeltaTime => 0f;

				public float unityUnscaledDeltaTimePrev => 0f;

				public xiHGotxvVkwPQorALncbkjhujEW(UpdateLoopType updateLoop)
				{
				}

				public void jSmUMfkZCZCZfiMnleEGJnwKIqT()
				{
				}
			}

			private static class gKgvVaDTdMWAUQSEibzVasoAevE
			{
				public static StopwatchBase Global => null;

				public static StopwatchBase byjpFPaNIphrKciIajhIxYJzCeOY()
				{
					return null;
				}

				public static StopwatchBase LWrVLuMFCPCBqjRZeiZiuEzDMPR()
				{
					return null;
				}
			}

			private StopwatchBase falGmUSmPHIKQESgkGHirZgmulw;

			private double ggKKLhoFcjrjrLEPIZcRQnxEVMY;

			private xiHGotxvVkwPQorALncbkjhujEW EeKMBoGbveHscaiaEMBELOwRBaH;

			private ADictionary<int, xiHGotxvVkwPQorALncbkjhujEW> nrLBNoAFJEebDCPWYKXbrZBDwKR;

			private uint KfaqqsJOPJejReqFoeGeYSSuwIb;

			public double unscaledTime => 0.0;

			public double unscaledTimePrev => 0.0;

			public double unscaledDeltaTime => 0.0;

			public float unityUnscaledDeltaTime => 0f;

			public float unityUnscaledDeltaTimePrev => 0f;

			internal double realTime => 0.0;

			public uint frame => 0u;

			public uint framePrev => 0u;

			public uint absFrame => 0u;

			public void pjqXdVblhGsDwvbKFliexrFpQIM()
			{
			}

			public void rkokDDVBuXRhnNCArjcuJjDYtpzW()
			{
			}

			public void jSmUMfkZCZCZfiMnleEGJnwKIqT(UpdateLoopType P_0)
			{
			}
		}

		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch TGpVjpCnXnesTEFRakRpmLikuhU;

			internal static UnityTouch Instance => null;

			public int touchCount => 0;

			public Touch[] touches => null;

			public bool simulateMouseWithTouches
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool multiTouchEnabled
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			private UnityTouch()
			{
			}

			public Touch GetTouch(int index)
			{
				return default(Touch);
			}
		}

		internal class UYDcZIUFzwNkgKFpAvKGoMimqAT
		{
			public readonly ValueWatcher<bool> QBAmVSgbZBPmppTHWYNgMiDCmXg;

			public readonly ValueWatcher<bool> QkenjZZMPJJaNftxIrJnlwjEQPK;

			public readonly ValueWatcher<bool> xIMFCrwXunWxoekBlleMmJYPdj;

			public readonly ValueWatcher<int> lduifWWpoEYmbMjTJGxfiCrUaVbH;

			public readonly ValueWatcher<float> yxIqFBiEJjHnMNaIKxInNWSBujA;

			public readonly ValueWatcher<string> MuuXaMIShRtUzBodRSnPbFwFHga;

			public readonly ValueWatcher<bool> oDAHXPduaFEkAbKbGTChrxaQccTL;

			private int BLqkOmpXFQrhUcUqcpMeIITXpcr;

			private readonly ValueWatcher[] IHSQAfqlkLwfDRsVtRovlScYnqZ;

			[CompilerGenerated]
			private static Func<bool> RYhKtvyBnbYwVqtdkWRUjdqhVFP;

			[CompilerGenerated]
			private static Func<bool> EKJwBXoThEWpbsormcLTDoSDAqmF;

			[CompilerGenerated]
			private static Func<int> sROWGMoZLJsnPzODwiJjSbSnzzN;

			[CompilerGenerated]
			private static Func<float> huVIcABprVhwEKHKXYwVzdBUBaQ;

			[CompilerGenerated]
			private static Func<bool> IOMllVkCztGxgOhosVjDlpFlsPH;

			[CompilerGenerated]
			private static Func<string> AEQDiSvRbjOTzdXLzdlWupxQSTh;

			public int currentFrame => 0;

			public void jSmUMfkZCZCZfiMnleEGJnwKIqT()
			{
			}

			public void wweiCHaRbiDSHRzxofNoPRkDurZ()
			{
			}

			[CompilerGenerated]
			private static bool mqtbQAlHGVgbHPAcYHiGGjHVpMl()
			{
				return false;
			}

			[CompilerGenerated]
			private static bool kokFAeEvpzjEkqzOXVfsybUZexs()
			{
				return false;
			}

			[CompilerGenerated]
			private static int hgLEuTjmVrGCLJIcVLpJoiLupIr()
			{
				return 0;
			}

			[CompilerGenerated]
			private static float oAOEPIoALJaVjbqcHtZgTOxqxaab()
			{
				return 0f;
			}

			[CompilerGenerated]
			private static bool OZhhHmRVLasGHppjEASiFgQqYXeS()
			{
				return false;
			}

			[CompilerGenerated]
			private static string MEpyafbrloCKhJvrGqkJjXbQCye()
			{
				return null;
			}
		}

		[CustomObfuscation]
		internal const int programVersion1 = 1;

		[CustomObfuscation]
		internal const int programVersion2 = 1;

		[CustomObfuscation]
		internal const int programVersion3 = 39;

		[CustomObfuscation]
		internal const int programVersion4 = 2;

		[CustomObfuscation]
		internal const int dataVersion = 1;

		[CustomObfuscation]
		internal const bool isTrial = false;

		[CustomObfuscation]
		internal const string majorBranch = "U2020";

		private static InputManager_Base XetmRAGybyGoHEAxhcHUKeAQrjaF;

		private static PlatformInputManager EipmgiMCREFLYqaOyKWtcpJhWRc;

		internal static tmYKYJtivFZNMMdFSwUqjsavhHY UmkZRVIxxOokFtVtbGnILukIJar;

		internal static zMtJShWdNqreuDVsbowqVZNzwts BoiYVdWmWlQykdYqdqdvncsPfPC;

		internal static TkcjGAMrGlZBptIAfinKwqiqWse rMKNQgWzfWednDCMGpAIuspSVKN;

		private static ControllerDataFiles zRlWjsiurHfMmGqfsMcLRjaJiumc;

		private static UserData wWsgFeuqSUsgwwBPjdjpjPGupZZ;

		private static bool aLzbAjHdyinuPAkYilYZkIGyBOc;

		private static ConfigVars OJxXokxjIIFupQczlCnOgNGVMwNT;

		private static UpdateLoopType JKYrFfHGvLiOGdRtMclqgSPBkyR;

		private static bool qJyeNPhAvKIykYBEREMfiKFZqNP;

		private static Platform eWhZzsSgwWjRIKLlVSaybvDfHuf;

		private static WebplayerPlatform IGPMXAYNVLCwoLQnyhpjGNBMIbR;

		private static EditorPlatform oPUAJMywrLEmBbqmOIkACwccdcP;

		private static bool oLsXvjfMAfPpnNGCyUWjLoDyWRS;

		private static TimerAbs JOBvZCwcejLmepHDIGBbiGtkzuC;

		private static boJgboDXhtOpkFRaIkAocTQCligw WCBgQMGSpRhxzDiVYlIVPBjukCy;

		private static string urYvVAJPxxgPDQTOjkiVXIhUHSbg;

		private static bool fymRdAgNSEHytFkEZfRonqvRubb;

		private static bool URciBBfYPOJNzFhzOemZncBVJYB;

		private static bool cbmmwJPDGUhXqzzdtJQPbNHADIB;

		private static int IULVvTEZtEGfACvHIlbEfPpuRll;

		[CustomObfuscation]
		internal static int _id;

		private static int udFCAbnzHWbsOecnXuffHfHmmoh;

		private static int OFTJeyVHtVdCEdWDNDgOcYLhKjFS;

		private static bool NPfefDCOwXSjdltUbdIpmiYqZmUC;

		private static readonly UnityTouch ypJbqBkFghjmeuIohSqXuVOPIAhd;

		private static readonly PlayerHelper GaobjbEblUVxxLSDGrlwgpXBLgGH;

		private static readonly ControllerHelper WUvEuExCKztjFSDYrPKLrGcTmVs;

		private static readonly MappingHelper oedupuDivHDwoiaDArXTHHKHEkeg;

		private static readonly TimeHelper cZtxmewbLHXoqbceQQJcQnGjHWu;

		private static readonly ConfigHelper rGbpTpyJpMDejdDCaUSUemRipYKN;

		private static KcAdaEYPWlBKOkoSWkXvREtouzg kXUuobzEpudkYjPEgRvobfUuMeer;

		private static UserDataStore HTlYcaiYYYNfWUhBffPIAlOFlDB;

		private static IControllerAssigner EygjZGXvKnQQadVtLiiHOaCOYPE;

		private static UYDcZIUFzwNkgKFpAvKGoMimqAT GGbNxxBRsPVtXooKvddzWaNspLr;

		private static SafeAction<ControllerStatusChangedEventArgs> qVIupAHADLzyPlQDDIMXlzuYyxz;

		private static SafeAction<ControllerStatusChangedEventArgs> NSYdMiVHXsNQtJggYdsYAPBrcFR;

		private static SafeAction<ControllerStatusChangedEventArgs> HcHfBSwchsarKVWgLOZzZnKKbxT;

		private static SafeAction HAWepiJVuqsaIpfDnupuwRuyPcFD;

		private static SafeAction VOGFthigxNlNBnSCxjUbeJeiQCB;

		private static SafeAction ZEXwQPtNcWgzPLnikmVqKLbKUBm;

		private static SafeAction PuuNWZqanRnCmVnIMzDUSdrPVZ;

		private static SafeAction hpMlLXyCgFYRRkoQMvzwOVHEIJs;

		[CustomObfuscation]
		private static Action<bool> _ApplicationFocusChangedEvent;

		private static Action CBNgnuladoahIaBrvcmDTvQgpMV;

		private static Action<UpdateLoopType> VLApZjoGpQIQlONUDdRToHrfBcO;

		private static Action<UpdateLoopType> VtKklTTGUHrZmJxRdvIOFWQEuxz;

		private static Action<UpdateLoopType> BnIRqUGHnrBPbnhMTkaoTXQKEAP;

		private static Action lycUhvtUnuUkdUEfCWBcwhKTcmb;

		private static Action<bool> eLheOuFKGZiNoQaeoIBRwiEtCOpz;

		private static Action<bool> BJREyForPSaUMKoPJevvMffZvTi;

		private static Action<bool> MENhzmbGCcnQFRgdbdFEnaXXmEqT;

		private static Action<FullScreenMode> KvBtZsdOwITuELMXRZUohBVogoA;

		private static Action ikHxmghZXdNsIJvkwwyccBXRpPd;

		private static Action<bool> NRtErjbMSszqqfolgfvaPPNVvjA;

		[CustomObfuscation]
		internal static double unscaledDeltaTime;

		[CustomObfuscation]
		internal static double unscaledTime;

		[CustomObfuscation]
		internal static double unscaledTimePrev;

		[CustomObfuscation]
		internal static uint currentFrame;

		[CustomObfuscation]
		internal static uint previousFrame;

		[CustomObfuscation]
		internal static uint absFrame;

		[CompilerGenerated]
		private static Action<Exception> pNpRyCfNxsTVAmAqaOebelrrWpj;

		[CompilerGenerated]
		private static Action<Exception> KWKktRWkwzBbPdRRrpMBlLPqClPu;

		[CompilerGenerated]
		private static Action<Exception> hoCYHWmxWRwwkvpwJdBZFJcNNhk;

		[CompilerGenerated]
		private static Action<Exception> HceSRioqHnjrqFbQcynGPisbXSBO;

		[CompilerGenerated]
		private static Action<Exception> ortPexWgrMFalfJPzkETpvwhcz;

		[CompilerGenerated]
		private static Action<Exception> fvWyREHLybSUilnRYIGPapuyAAk;

		[CompilerGenerated]
		private static Action<Exception> BEalNADvVBuVTpCvVArQAIISixRQ;

		[CompilerGenerated]
		private static Action<Exception> lKMFeKhHrXgqvALOaEtuAwYoCQfc;

		[CompilerGenerated]
		private static Action<Exception> eUbzjxgwVPJVYEFEZUmxvjtXBCV;

		[CompilerGenerated]
		private static Func<bool> DNTaZFaqqCENnFHcfxuAnYSQMSti;

		private static KcAdaEYPWlBKOkoSWkXvREtouzg unityInputBuffer => null;

		public static PlayerHelper players => null;

		public static ControllerHelper controllers => null;

		public static MappingHelper mapping => null;

		public static UnityTouch touch => null;

		public static TimeHelper time => null;

		public static IUserDataStore userDataStore => null;

		public static ConfigHelper configuration => null;

		public static string programVersion => null;

		public static bool usingUnityInput => false;

		public static bool unityJoystickIdentificationRequired => false;

		public static bool isReady => false;

		[CustomObfuscation]
		internal static int id => 0;

		[CustomObfuscation]
		internal static bool initialized => false;

		[CustomObfuscation]
		internal static UpdateLoopType currentUpdateLoop => default(UpdateLoopType);

		[CustomObfuscation]
		internal static ConfigVars configVars => null;

		[CustomObfuscation]
		internal static IConfigVars_Internal pluginConfigVars => null;

		[CustomObfuscation]
		internal static UserData UserData => null;

		[CustomObfuscation]
		internal static Platform currentPlatform => default(Platform);

		[CustomObfuscation]
		internal static WebplayerPlatform webplayerPlatform => default(WebplayerPlatform);

		[CustomObfuscation]
		internal static EditorPlatform editorPlatform => default(EditorPlatform);

		[CustomObfuscation]
		internal static bool checkNeverPressed => false;

		[CustomObfuscation]
		internal static bool isEditor => false;

		[CustomObfuscation]
		internal static Guid defaultHardwareJoystickMapGuid => default(Guid);

		[CustomObfuscation]
		internal static bool isRunningInEditMode => false;

		[CustomObfuscation]
		internal static bool isEditorPaused => false;

		[CustomObfuscation]
		internal static float unityUnscaledDeltaTime => 0f;

		[CustomObfuscation]
		internal static float unityUnscaledDeltaTimePrev => 0f;

		[CustomObfuscation]
		internal static double realTime => 0.0;

		[CustomObfuscation]
		internal static int currentUnityFrame => 0;

		private static bool isEditorGameViewFocused => false;

		[CustomObfuscation]
		internal static bool isAllowedEditorWindowFocused => false;

		[CustomObfuscation]
		internal static bool isUnityEditorFocused => false;

		[CustomObfuscation]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform => false;

		private static bool inputAllowed => false;

		[CustomObfuscation]
		internal static bool applicationIsFocused => false;

		[CustomObfuscation]
		internal static bool applicationIsFullScreen => false;

		[CustomObfuscation]
		internal static bool applicationRunInBackground => false;

		[CustomObfuscation]
		internal static bool timeScaleIsPaused => false;

		[CustomObfuscation]
		internal static InputManager_Base rewiredInputManager => null;

		[CustomObfuscation]
		internal static PlatformInputManager primaryInputManager => null;

		[CustomObfuscation]
		internal static IControllerAssigner controllerAssigner
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[CustomObfuscation]
		internal static RewiredVersion rewiredVersion => default(RewiredVersion);

		[CustomObfuscation]
		internal static int timeScalePauseChangedCount => 0;

		public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public static event Action InputSourceUpdateEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public static event Action EditorRecompileEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public static event Action PreShutDownEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public static event Action ShutDownEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public static event Action InitializedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation]
		internal static event Action<bool> ApplicationFocusChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation]
		internal static event Action EarlyUpdateEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation]
		internal static event Action LateUpdateEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation]
		internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation]
		internal static event Action SceneLoadedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation]
		internal static event Action<bool> EditorPauseChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		static ReInput()
		{
		}

		public static void Reset()
		{
		}

		[CustomObfuscation]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			return false;
		}

		internal static void nKQbCtkHPOPnqlOqEQhEesshditg(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4)
		{
		}

		internal static void eaCduIGlWnoCUPmzuAvihlsUVqj()
		{
		}

		internal static void HXpJWkBpkWGHVPusKmSTbEJtFhLg(UpdateLoopType P_0)
		{
		}

		private static void nlCAvFCuyFlAIRnTmvLKpOsouZf(UpdateLoopType P_0)
		{
		}

		private static void RAMFayRdZKehHlVCyOArgZfgEb()
		{
		}

		internal static void jSmUMfkZCZCZfiMnleEGJnwKIqT(UpdateLoopType P_0)
		{
		}

		internal static void pPuAMWhRUfpgiCAKVHsYUVbvEgb()
		{
		}

		[CustomObfuscation]
		internal static void EditorUpdate()
		{
		}

		internal static void JgQGTqPJKalNIMfUgHvkwhZAOuy()
		{
		}

		internal static void KTUIDkyiEwxNQWNpUVDVeNecVR()
		{
		}

		internal static void bznJUoHKVApHghlqpCKYJLbDytar(bool P_0)
		{
		}

		internal static void ztorxZtJKBEzeJEAbvScNmzEGEhf()
		{
		}

		[CustomObfuscation]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return null;
		}

		internal static HardwareJoystickMap facBeOdRRiduWAKphmYWLMUqjKdn(Guid P_0)
		{
			return null;
		}

		internal static HardwareJoystickTemplateMap dXybZDrCezhlKacldJGOHtqMDYEM(Guid P_0)
		{
			return null;
		}

		internal static IHardwareControllerTemplateMap KBxcghjtGgyYiSMLPrFkJhqGKoH(Guid P_0)
		{
			return null;
		}

		internal static IList<HardwareJoystickTemplateMap> PKWesJvyzflRozojTnelcpNvhpj(Guid P_0)
		{
			return null;
		}

		[CustomObfuscation]
		internal static int GetNewJoystickId()
		{
			return 0;
		}

		[CustomObfuscation]
		internal static void HandleCallbackException(string source, Exception exception)
		{
		}

		[CustomObfuscation]
		internal static void HandleExternException(string source, Exception exception)
		{
		}

		[CustomObfuscation]
		internal static void HandleExternalInterfaceException(string source, Exception exception)
		{
		}

		internal static void qlBFRJWraZKrzfOnAGXcGDaGoOh()
		{
		}

		[CustomObfuscation]
		internal static void CheckRewiredVersionCompatibility()
		{
		}

		internal static float BWFnuYjRMslqwckNiOzvOOjsCzR()
		{
			return 0f;
		}

		[CustomObfuscation]
		internal static bool CheckInitialized()
		{
			return false;
		}

		[CustomObfuscation]
		internal static bool CheckInitialized(int reInputId)
		{
			return false;
		}

		private static void hKEAcWfxjIJBxUCeQMQfTsBXJEuC()
		{
		}

		private static void OCqSJvbpclWclSkjYkLsBbHdJUx()
		{
		}

		private static void ISxphEAALAbAJkJDrUPwodLFgov(string P_0 = null)
		{
		}

		private static void fexKvxEqvMYuMmkuQQQelAgurRK()
		{
		}

		private static void BrBMZaBBdxhymaXSxJnDjqHrWJq()
		{
		}

		private static void yRqWoEWYDcpXxYzerZhCLBeBhUt(BridgedController P_0)
		{
		}

		private static void JLvYhhRlmmgDDcSftnVLjLLuIom(ControllerDisconnectedEventArgs P_0)
		{
		}

		private static void XRobbTtfDLDJmFugEllerHCYZOo(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void wwmSMybonrCmAmLEmSKxoRWPbnm(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void hPXfdHZnawuCKxFibgJlbnTgFfEm(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void BoayLLNfznvSeqSnUDhlCKKPInZL(UpdateControllerInfoEventArgs P_0)
		{
		}

		private static void rRujWYRgwEnOOYvDVNSFbReupcp(bool P_0)
		{
		}

		private static void onhJtZBTAqastjBkTAkMSmXLkbp(bool P_0)
		{
		}

		private static void mNqvYoJhIIPBgDCfcDtlVXIIyeO(int P_0)
		{
		}

		private static void mCsQpvsMrGzXKVUkcGCTkimAjyGC(bool P_0)
		{
		}

		private static void ItlbQczDKGVecohZzRGNikVWczr(bool P_0)
		{
		}

		private static void NavijpmlHmAjhDisfzPPUTADGLlI()
		{
		}

		private static void MkbhfLFUcsGsRzkXpoCFDbyKRux()
		{
		}

		private static void esyGTdijJGjaJEUlApXivBSuPVG(bool P_0)
		{
		}

		private static void AmwdgMKuSHccvLAvSffEwbeJQAxa(Func<ConfigVars, object> P_0)
		{
		}

		private static void sXSmojTfsGWqzEIEtxKcdoWFQcy()
		{
		}

		private static void fSuEqwjcmabmnKRRuYGYnRfEndpb()
		{
		}

		[CompilerGenerated]
		private static void daGgbUEUdOgxvrdmLxGmNgCjuNn(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void IQQAmRZKeDZakiQwpnEByYgYalz(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void rUESINabFGGprtVFzDMrEKIMqiiR(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void IlSQKNkpvSLpmhhRhemLadspNESA(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void cdowaGQgqXCDHxaSmsQwooraUdi(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void lHkotjZfaLRahHULAwdCUVvuwBu(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void nTfeIiemldfkslXtwFJbAdYOELiq(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void fwdUEZcKQxJEDxfrsdabCYbVYUJ(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void rvBCRRpFuHQjpCMIUMLxYdyBDwhg(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static bool ZKumZMMwjLdcKigSxyxILFzYDuE()
		{
			return false;
		}
	}
}
