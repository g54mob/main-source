using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class LocalizationHelper : CodeHelper
		{
			private static LocalizationHelper VPVevYEHkNSJUQOzLsFcqOlbraMoA;

			internal static LocalizationHelper ukNfEKaVVRLZCDzeCGUjsfkjdcFc => null;

			public ILocalizedStringProvider localizedStringProvider
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public bool prefetch
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			private LocalizationHelper()
			{
			}

			internal static void KttrYufhJbuSthUPDmycoYFtWvNM()
			{
			}

			public void Reload()
			{
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class GlyphHelper : CodeHelper
		{
			private static GlyphHelper FATXsDGHcLASwfUlwtTBUWRFTvdN;

			internal static GlyphHelper yeguLOroFOcDatHHVuNdnpmjQNlr => null;

			public IGlyphProvider glyphProvider
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public bool prefetch
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			private GlyphHelper()
			{
			}

			internal static void euKNiitvgJTRrotubWmcSoISYZxj()
			{
			}

			public void Reload()
			{
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ConfigHelper : CodeHelper
		{
			private static ConfigHelper ZVxaYiJnLPkbfWKxGnmDuCXJFucH;

			private float qOqToYwkeHZOXGXPGerbrbItPsAr;

			private float yYAnwjKbszcPLmtOzOXYCXfqNhJJ;

			internal static ConfigHelper wLpHhPVxdqoEMcnfSeONrbCsaPTEA => null;

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

			public bool useWindowsGamingInput
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public UpdateMode updateMode
			{
				get
				{
					return default(UpdateMode);
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

			public bool windowsUWPSupportGamepads
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool useAppleGameControllerFramework
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

			public KeyCombinationOverrideMode keyCombinationOverrideMode
			{
				get
				{
					return default(KeyCombinationOverrideMode);
				}
				set
				{
				}
			}

			public bool generateKeyEventsOnKeyCombinationOverride
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

			public List<EnhancedDeviceSupportDeviceType> enhancedDeviceSupportExcludedDeviceTypes
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			private ConfigHelper()
			{
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerHelper : CodeHelper
		{
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class PollingHelper : CodeHelper
			{
				private sealed class QUAoKxbNfwGulbHWusbCPTYTUkxi : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int vCMCXjgJbamUAKrZIhxcGjidipXI;

					private ControllerPollingInfo ReLemahgQJcEFWVqSPwIWTjMLEjmA;

					private int rlhhNGBFryQOYwAPiQfjrVLAGbVM;

					public PollingHelper gWFnnsoFhWLwyGQjVIJNSILFcFFC;

					private IEnumerator<ControllerPollingInfo> MjcpSilCKWPJwBFKAEFYJWUDEUFP;

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
					public QUAoKxbNfwGulbHWusbCPTYTUkxi(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void VbhisKBWvLypHlxbohngKhMBOQibb()
					{
					}

					private void rVVARqjDeuJSODkrhlplFtccKCpO()
					{
					}

					private void iJXvybpTSvSIzIGsSlzCIuJOflze()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class mjrpjwEcqfjWUTttrVmLPhaMahEt : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int wNZTvtWbOMfHSumzNOdkpxYWAHD;

					private ControllerPollingInfo jKzahFgryRRIxRbShcrkiHYoUFBI;

					private int oApcntfjtOouwtQXtfGPbJeKydhDA;

					public PollingHelper lkldlzCNTCsRtlOAoEJYGvTKggyy;

					private IEnumerator<ControllerPollingInfo> WLzbUewTOTiFkGumxTDhJTBqIartA;

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
					public mjrpjwEcqfjWUTttrVmLPhaMahEt(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void VGDhKAZrjFpsiWSVWfxEwOdLeUaH()
					{
					}

					private void bBUxoxyXIHLEYxClNxnkgvjyDdDU()
					{
					}

					private void wjhmiKhCCUGgejseEDoXaABgxJSac()
					{
					}

					private void kAGccGDMtCuuASIVvkbqeOAeIoSYB()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class orCVQsCSvoGxFWZKziCkpdyTnHuB : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int sfEEjHcqHdmpHqekvmMWchySnVKGA;

					private ControllerPollingInfo bQHKrbPiMjewJnebOPDTWSwUmlQv;

					private int dusOVJAjHTbXVMAblivBMPoWyvcS;

					public PollingHelper JkIixyLZXQtbVwyrHwVZKwodzPQi;

					private IEnumerator<ControllerPollingInfo> HBfBsgvtPqvbcQRVjxYCpMzEUGoh;

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
					public orCVQsCSvoGxFWZKziCkpdyTnHuB(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void zzXctyQxlHmlGMqTDGsWGqAImNJTA()
					{
					}

					private void KonDPZgjGxaXlcDMULqUMPdgDslFb()
					{
					}

					private void UtEuNFeQwWDjBYcTQWgNljNALhJP()
					{
					}

					private void EwhERuoIIjzTdXooOGKzqxgNCjKaA()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class tPTqWCJMnrqGOvNnoHOvEdlDtXWIA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int vZtKNPwORdVHTcLFBQDUenlsIflj;

					private ControllerPollingInfo EgCycJsmJSDroTlMZZWJmPvFlHeb;

					private int gVULgFtNhfKazmFzbQmUPLZlNrNG;

					public PollingHelper jMrBfpLcbDdthvGfWZNyODqVSpAB;

					private IEnumerator<ControllerPollingInfo> VpGdZDHjrlDpFuCZnJFWhljnibcab;

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
					public tPTqWCJMnrqGOvNnoHOvEdlDtXWIA(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void fzCViHaqMvfXCbynUKPWktshChtZ()
					{
					}

					private void gTUvDOFOdxqcEhTCMnYhYsfnXOOG()
					{
					}

					private void fdctEcguRTkhSvRbLmelbvXCmJui()
					{
					}

					private void XnOMOMZgdOYswAHDRBoZWADwlaqy()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class FPQaFGFMaUupvJGFIgcdYUsJXJJg : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int CgXDrCwBRxJyCcofXOlhnRleDeps;

					private ControllerPollingInfo SJergtXnbFWigLVugYGaOoEtJDhD;

					private int icSvoMjEtgsKruTPxsQsYcspXzkp;

					public PollingHelper UEjtQIoAhwAQqYDxIiQcTrooBeoD;

					private IEnumerator<ControllerPollingInfo> njpDGCDVWfUhXfuERpcsnAJeCBBJA;

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
					public FPQaFGFMaUupvJGFIgcdYUsJXJJg(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void JFFDyaYqjvFRpHfsxumaaFhECnlNA()
					{
					}

					private void QMPMCYvcfWVdadUYSRduGhwapIpQ()
					{
					}

					private void XASBWfBMGWUtGTUuShRbAbcWfxdXA()
					{
					}

					private void CGravWtWWDXZWrfKPFLBSdfErLQN()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class DXJmvuxVFQbZxLXDAivSDVyVReko : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int mmncnecygBHuQSMVQdqaDERKPJsdA;

					private ControllerPollingInfo SlFCHEokHNNXGcylvsMmHpGFphUP;

					private int CLmXpalHslfSekpDRstorxydKhIsA;

					private IList<CustomController> VCqwXDvQcgTTllfwzscIshMuOsuk;

					private int DGZXBfXLgmSSoHdBBaDGmbPDoZtp;

					private IEnumerator<ControllerPollingInfo> GLeCCaKvshyIdfpeRrdtQCoFjIlO;

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
					public DXJmvuxVFQbZxLXDAivSDVyVReko(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void zrFozitQkjDXPGwWySJkwGaSAyTL()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class zVKpZhpnsphSteovqVWvusPfSAzE : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int lkvydtbrJrzBszJTygeKoEaqEyRO;

					private ControllerPollingInfo aFerbdqoSRbiyLxNqUtpKIJPZLgH;

					private int bxiummZcKFbTucVOFMmjXZBgWavb;

					private IList<CustomController> kjfzMoEQYaemaFozTcbpdNNBgtKec;

					private int UCIVnOMQZvBKsdhVjKUzlgBxKlZM;

					private IEnumerator<ControllerPollingInfo> FcYKNBZsbzgQtBvTwVFxeAGZjywY;

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
					public zVKpZhpnsphSteovqVWvusPfSAzE(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void PusvadwzHwUMpgueldchooevdbME()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class sKrCNdKFsCjkfbsbyxNjsCvnkrxCb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int AeuzabuWaYBeMBlSIjqDLwdRKjfD;

					private ControllerPollingInfo qsXqmleVSYPVssPuzdZDxStWMPHj;

					private int UkzCpGefOEEhdsgRVmkNojtVOfCn;

					private IList<CustomController> KNIIevADBdBJcpuTKDGulLyylAaR;

					private int nsPxMBEllKFmVXDkReydmeCbZsTk;

					private IEnumerator<ControllerPollingInfo> cJtWjCgWpvPHlBhJyleClOZxGXwu;

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
					public sKrCNdKFsCjkfbsbyxNjsCvnkrxCb(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void yAvKSjFzUuiyiUeugtJZwtoURePV()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class FLylEuJLqnpCyTcjdkZtDsMERBPw : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int LusQexWidgzDZVbzMGpNcUdtSpPi;

					private ControllerPollingInfo alXSOKCPQlfikeZscbdREToiWfOMb;

					private int yvAPzQnFTKzEvDkJQWeifPtrzPxb;

					private IList<CustomController> hXdWIYSmaiFWgigrCHvUaxbSEEFI;

					private int QsBWrHXcwuyUOuhqJtaZHPXjPsMQ;

					private IEnumerator<ControllerPollingInfo> WGOTUKRNjmGkOKgYsmIksHPGbuUgb;

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
					public FLylEuJLqnpCyTcjdkZtDsMERBPw(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void OQZNpbAaVCZBOnWGPnexTocMZRxM()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class rfsYUaUztbFlFsiybNDcKPRsaYXH : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int JypQofbiiqSrmXtReSZIjySXqtzG;

					private ControllerPollingInfo ohwEdYDAfrOjKUzDFKDANFkPFecfb;

					private int xILzuUnqOVALDwnZituqmmOujtpU;

					private IList<CustomController> eDKomGbUKflGQTLBHuYaIPcjMVxh;

					private int oEnoFteKzSjhniGGrXEvAFOCcTmKA;

					private IEnumerator<ControllerPollingInfo> DjxFOMIDkfrbHmrqlJjJZtIwVNYF;

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
					public rfsYUaUztbFlFsiybNDcKPRsaYXH(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void JKnTOAzqhgdIkFRgcoANDKQOCGvib()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class jJaGTIeDJVbRwJctZzUuupFRdhDd : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int COAURCBoYxXhFuqMqpQcdizvTczO;

					private ControllerPollingInfo DDoHbYzNzFngOoHMqIrtGDoNfcTZA;

					private int RDOewMGLDBewiIjqqnHwgDwDcLGTb;

					private IList<Joystick> hULKTIBWoUoiNGOuHqBvapEdSiac;

					private int WzFcpIAxZUmKVjxQgLTBjlBdnEEL;

					private IEnumerator<ControllerPollingInfo> TpGcXWIhnscXnCFGJYeRiFfObHBgA;

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
					public jJaGTIeDJVbRwJctZzUuupFRdhDd(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void WGHPpfSpkUEQiYoTJXWalywHHaOe()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class HoSNRdGrRlBgeGluXyHuVwvblAKw : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int azkiFQyHkfoLONBIeHDjEfFuzkPCA;

					private ControllerPollingInfo aqGuwxhwtnyYCNrpThpONdROFIam;

					private int btgIwCSfYurvkrwgJHJlzvCTAaHo;

					private IList<Joystick> NnRjodcXdIHakLYPGghPMZDyobGt;

					private int cFSfMxAfDuwpAJyobFBsDLodEiBL;

					private IEnumerator<ControllerPollingInfo> sXlRXCTHyVbMcFyZtFTkkEQMUIeK;

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
					public HoSNRdGrRlBgeGluXyHuVwvblAKw(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void jIPFpkXAojIEuTYBkuiRzSATqzbl()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class sdEOrFgLKreNTBRSWcaUKohzBwDBb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ohGGoCTMncBYxtszBZONniPXoUYe;

					private ControllerPollingInfo kNwenORiMFMHchgDVExJDXZSDcxMA;

					private int OcOeIbxfePoQkVTAXriFKvmJTUTR;

					private IList<Joystick> GoeCjuWVgEodUJJuqHLoMsZSgWPt;

					private int slbaiMOPfNEScCgrZGgnrCrDyVLL;

					private IEnumerator<ControllerPollingInfo> tWfKMRfnUOFBauICGxIJKhDCVwzG;

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
					public sdEOrFgLKreNTBRSWcaUKohzBwDBb(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void nFBrTfWArjGnqWeIFGFxGsZXYDxn()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class IPEqsXDUEHzXCPCjHebCIalKtUlD : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int DddanSXEpqadfodEDvsjZWJHISmr;

					private ControllerPollingInfo RspbpbuIUKxDTLUDCucFaeXQDmyEA;

					private int rfYNSBxREijxakjJSoQfECWfzhgL;

					private IList<Joystick> bvEXwZGQdHiXZxzcPAKzdsOenwGF;

					private int LMXeOnnxNZBuTmqijEBalawgsDty;

					private IEnumerator<ControllerPollingInfo> xaNtYwqqhaPQftrQDHxEpvkKSNSo;

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
					public IPEqsXDUEHzXCPCjHebCIalKtUlD(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void dLOMjLyRPtBhLoYvLMzZpGoELBmh()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class SFDYJmzQLzBhlEckcwqxScXJkEiX : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int RWUAWNoZoHtyKYFnKlrukqBoFZBH;

					private ControllerPollingInfo IMprVRzYqdRwKnQQhIStgemIBRvGA;

					private int JOMFtVKaJXyWDsUYidhWefvPfiKe;

					private IList<Joystick> KVLLaqUKWcmbtxTotNdLRSkPvRil;

					private int KpzKJrBGUnoKvfHticAzsMGACkzd;

					private IEnumerator<ControllerPollingInfo> wWBFLElpCEACLXKEIkKZItqsnjUQ;

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
					public SFDYJmzQLzBhlEckcwqxScXJkEiX(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void wHLaEZrZephTsOBXiEsrhlXHurHC()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private static PollingHelper kHeEJlBKjsaecbGBFJrqPeJxSKIQ;

				internal static PollingHelper vsAeVzbYefyUjIFQRnIukajaUCCrA => null;

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

				[IteratorStateMachine(typeof(tPTqWCJMnrqGOvNnoHOvEdlDtXWIA))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					return null;
				}

				[IteratorStateMachine(typeof(FPQaFGFMaUupvJGFIgcdYUsJXJJg))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					return null;
				}

				[IteratorStateMachine(typeof(mjrpjwEcqfjWUTttrVmLPhaMahEt))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					return null;
				}

				[IteratorStateMachine(typeof(orCVQsCSvoGxFWZKziCkpdyTnHuB))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					return null;
				}

				[IteratorStateMachine(typeof(QUAoKxbNfwGulbHWusbCPTYTUkxi))]
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

				private ControllerPollingInfo HEkqAouNoNIDhTygFPREPARnoopM()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo jojKLtFGIzVDzWttKxUxjvnMxhCJ()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo IzkgnLjgfJhaKVqsyjVagZhBbcpzA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo vQjkjQSugLKKPkDhKCZQYRZjiowi()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo gnrbSeeUoTRuMhVnXaaDWQVywBuD()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo TwZmYqtgPRPLrDNOHzEzKDXEctUp(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo AOQSwkpsYykvOLacodGBLwLbgOzE(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo nUfaxHxBvjkRBfcecalieINTqSHIA(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo HsfVzuXXopSgPwbqqmsQHGHsyESd(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo RenFEeiqMafPZkxHkZZfdesKmaOm(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo viKarNglbqvUvCBhXdJlnRuOonwe()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo VXZhKbDBPTmwckZyqbFIyiiMCRRj()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo pvbFHsGxrTccaantZQrIiIETSqAfb()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo lBxAjkWBjGCjXBBbzmKkEOkdOMQe()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo WEbEtgoISVjNaPprKNxBWxRqwxYI()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo fqgBGMABpUpIfSVxlggGznQQoDUcA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo TzkWCAzjiZWdTrgtPAgkHdcJnSNk()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo iFLaKjyrJHltoMDUeNxBRdrmbNlZ()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo qYvktVRVwkUjvUrmsjenTUWFcKUc()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo hgTLseQhMGeTIfVbxRDSfPWvEpFm()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo XNeyNPlcghyfIIGPcFwhyuMVcKyF()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo brJieQVPtCMLnmilMQMfWLEpqpvH()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo sBBafDdSAcBpxDzYEBwSFvedmSfqe(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo wNjZYvUxvpTefpVtMYfEkIatZqOj(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo MQjdrdeKBcEOALTJdzrFKHkqXQCAA(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo GnwJVafFswfgaLqHPjoekHpoVKgz(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo NMIbyngSazPXPJSYCaIxDxYsjyvqA(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				[IteratorStateMachine(typeof(IPEqsXDUEHzXCPCjHebCIalKtUlD))]
				private IEnumerable<ControllerPollingInfo> hqZcjWLMhwKGjUfgAprpDCFRhLSjA()
				{
					return null;
				}

				[IteratorStateMachine(typeof(SFDYJmzQLzBhlEckcwqxScXJkEiX))]
				private IEnumerable<ControllerPollingInfo> nCfDiTmIPYbxsDWDrMQNcuogHexRA()
				{
					return null;
				}

				[IteratorStateMachine(typeof(HoSNRdGrRlBgeGluXyHuVwvblAKw))]
				private IEnumerable<ControllerPollingInfo> aqwloAPOyuftRhvpdQoBByaKFnhFA()
				{
					return null;
				}

				[IteratorStateMachine(typeof(sdEOrFgLKreNTBRSWcaUKohzBwDBb))]
				private IEnumerable<ControllerPollingInfo> zfOeqsJBunxsftIooFttJdaQSqgq()
				{
					return null;
				}

				[IteratorStateMachine(typeof(jJaGTIeDJVbRwJctZzUuupFRdhDd))]
				private IEnumerable<ControllerPollingInfo> EWbuBOmxJvimtZqSxTwgIpOIOoeS()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> VWGgNyfBXwqdkpQxwuWVDtCnIRCqA(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> fodDlkJFCAzEVrbUwfkfFmPpqkfr(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> DTAnSDNKVnmuDPVLlTCcRuCaxiwg(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> TSNGVkmqjiwlTuQdlfajobPuIGYg(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> NxTWjpoYrmVHEvkrrqcSMLlxUYdg(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> LiXHRNHROZpNGvvcUEIShWKxdkhJ()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> chgOANZkaVpHIvABGYOgOuOTBuNy()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> DIXMTwjcULDFHAUAcTwpFJFSKoJQA()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> POFbxbDAexCrqApgLssUfcEJyIyQ()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> htDRquUcgBNxLFNMUbdIQNeNPTvB()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> VvKsDLLPrSLNaLooUIARPuyHBGQE()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> GeqsvoZTFVAUBiRbIBwPDtUmFDaqA()
				{
					return null;
				}

				[IteratorStateMachine(typeof(FLylEuJLqnpCyTcjdkZtDsMERBPw))]
				private IEnumerable<ControllerPollingInfo> TtdLRyTQGWPATNQXtHoYnhBDwJDs()
				{
					return null;
				}

				[IteratorStateMachine(typeof(rfsYUaUztbFlFsiybNDcKPRsaYXH))]
				private IEnumerable<ControllerPollingInfo> LmcdRsljHRCCCzhplSJdtSUFgJev()
				{
					return null;
				}

				[IteratorStateMachine(typeof(zVKpZhpnsphSteovqVWvusPfSAzE))]
				private IEnumerable<ControllerPollingInfo> wLFcxgHChiIETyXXYNIgkWmLLCjX()
				{
					return null;
				}

				[IteratorStateMachine(typeof(sKrCNdKFsCjkfbsbyxNjsCvnkrxCb))]
				private IEnumerable<ControllerPollingInfo> sUlBRtORmSzDyGWckoSTzgIwKxug()
				{
					return null;
				}

				[IteratorStateMachine(typeof(DXJmvuxVFQbZxLXDAivSDVyVReko))]
				private IEnumerable<ControllerPollingInfo> OdYPiZBsoXjLkciebXXDzwxbtCjN()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> pxfUirWItfnvYjklLtZwASOgVFbI(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> UOzabbmXMuzXVEvXIQUQgpmiEjhJ(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> HFPsFswGlBeMpNvDEBBvNmgoZZCR(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> FFUBrYTQXiPFdmTTYHNjQhJqgJET(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> SCPqZlGXqQsEvrPRcZTarhetFqOi(int P_0)
				{
					return null;
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class nWLaLpJTPpzzAqXNtxZVjFvTrLjZ : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int rAeqnwhiVkLkhVrKWfXTWJEwZjHJ;

					private ElementAssignmentConflictInfo FhBohtyCcuohKducTnTPZrmadvyA;

					private int jbZEXPflIdgjEqcDnJsqlrSocJSwA;

					private int lDTSoAFdDPbHvMCfasUuZbwBlbfL;

					public int bmtumRQpYgEncVAOMntpFfBAdBCm;

					private ActionElementMap yflSPWDczyNKwzBBGhrrNKHEiJFB;

					public ActionElementMap ANGzlmZDjoezUSYlcusxISvuFKUO;

					private bool BpuLzRchZtrXeCOBKtlrcPBqhZl;

					public bool vOlNKGVxtxkuYkQVrjielsDuEoQt;

					private int SFhxWERXXehFJzmtMjSmEFmzffHx;

					public int QNeTSBxSAGxyeCcqKzeTeDjjSocV;

					private CustomControllerMap VlryUncDpzVsfpHBNdqTvPzJannl;

					public CustomControllerMap iwWQFMVlTdeTeEjakcQVASNjklTnc;

					private bool evgrSZsCTreaNbTYckSthreSdXwq;

					public bool rjjBEkIddyKMaIXDdtZybejYHVGpc;

					private bool pbdpLlFkiJVEJJBUXgGidsjfXruA;

					public bool QeQLwAqSIrXHvPDOgbaOjJwpfFfZ;

					private IList<Player> pgfgvedDSpxdKOtyXcRjAhPleombb;

					private int JkqEwbqgCncqUkOJaIITYbSHdeiiA;

					private IEnumerator<ElementAssignmentConflictInfo> KpTBiLwumRfZJSAquvHSKhQidNwaA;

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
					public nWLaLpJTPpzzAqXNtxZVjFvTrLjZ(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void qumKTCJTbcgzJtGBWSKQHqHinNRp()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class SlvDdvgoEAMpQVyNFpbYePBfrDNtA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int ruFcGHfGLhYvuxXBaewUoMNdhuHt;

					private ElementAssignmentConflictInfo tOrxkThAAJUlrHbyoisZkmiqkwzr;

					private int SZXxbjnojEaOIPZCfTMZSiTdQlNn;

					private ElementAssignmentConflictCheck cnPyqbnDmbZnmlmPfWrzEddspvIe;

					public ElementAssignmentConflictCheck InechxDjRCnjgRSoHZAknhJChNjx;

					private bool XZoZPjykosICzTlacPeOWvmaqLYD;

					public bool chWUUyEQVtfqGRPoAXxKyGcfgmxg;

					private bool jXXpYEnpDlobHNjVyGFLbtmUDPCF;

					public bool bdKpVeMfBsHOlbVewBiNvsWecdMV;

					private bool hXuyuYHzEVfVsrdLVNoxFtkNRolj;

					public bool pTSYcprnqNEBZDtBgzREtnwqTMNiA;

					private IList<Player> WeOVGDIHmxgjGhloZdQqthkUuheb;

					private int PGYWdsZUyDtjUkmLwDdOMCPkdrJQ;

					private IEnumerator<ElementAssignmentConflictInfo> OgBJaMTrKCmGhIMcHHMVqnDcRxqS;

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
					public SlvDdvgoEAMpQVyNFpbYePBfrDNtA(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void rTAvZbbtbKcjdVKINaqeloBhaoNfA()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class eNLArjWToxQORDcnYldOFAmFLbiD : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int HMjYirQsfYxlEsStLdbWDIIAzFiF;

					private ElementAssignmentConflictInfo lpYDdCibKyElyaxgIzvUbklODSObb;

					private int kbtloPKdsIEYdBtxeFmZyWeOvYHh;

					private int pPBnNlTjxsBHmmJdZOqrUeOMzqRm;

					public int LMqQXTjbjVjVoCaXyNggiuECEPjub;

					private ActionElementMap sxbkvOkFWokxdRtuzhWLHBkIvQuS;

					public ActionElementMap WZwdQwFUFZDLyHNuVzezUGllsddd;

					private bool nuBpOotJeYIjmydcQUjmRzXjTvnj;

					public bool ZEjHPCfgdCQBEyuePKVUBJdmUkIBb;

					private int VIUcIZBqDgeablSEVOfduSildDqDb;

					public int PUaHJYoFMbetVrxHZagVaFrgjXtcA;

					private JoystickMap tYqAtBFkzhDNibDjzULypQJVQWAOA;

					public JoystickMap YKcbTQjYnnXalNzanhKkFVCPHkHr;

					private bool GWqwIzrrDiWdOivhhBicucLdKYMp;

					public bool LEpALjbqUhgwSePVDhIVYykiGwklB;

					private bool HTdYjMSbjaucePQvPBjNDRuvupMDA;

					public bool UOEdOOcwRFfDGQZqCXHGJUaAjRvWA;

					private IList<Player> EaTmULNaWAzCDsnoXdUcccZFXvvm;

					private int AbrrzvWCleDRBkmUyIrCWASLnOgWA;

					private IEnumerator<ElementAssignmentConflictInfo> ZvgLcrwDByyqKlwJCytFSgXjOKlc;

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
					public eNLArjWToxQORDcnYldOFAmFLbiD(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void CCdVdHPcpsRPylbhWpSvWSBuXvQE()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class PhxHtURGHYTpfVnuxUNfFAYbMAuo : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int LaxhnsHHoKwKGEKozRBuVrnMXUBfA;

					private ElementAssignmentConflictInfo DadQWDzlrdRyodTYfgQQlqztrUOj;

					private int RqMcsnZZJjmVbcXXFKbKAJLJDNQh;

					private ElementAssignmentConflictCheck xMThQyjJwHKUxYtNjbcKrReCVSXH;

					public ElementAssignmentConflictCheck BJbVQgNgeMWhfCFnuBdQwoTFaIrL;

					private bool RsWSqbSleHnQngYjIpuZKIBFRHxI;

					public bool lzgazrBVOzHRaprZdzkhNslwclpnA;

					private bool EuCfPMpMKlthDiherqLyhEOYVzIR;

					public bool VsjZdniYDCbuyHREUZmXbIDcOkRk;

					private bool KcZdfYjYdEdnWaIHpuycjKvLbMoB;

					public bool ucRBepsTgXeEQoFbnxtMSOLVkIdX;

					private IList<Player> vSnLBXERGtfvJKNGUNlunPrgGWhD;

					private int eUEcdyhLAiBkFScgpNoLSkhUMAmo;

					private IEnumerator<ElementAssignmentConflictInfo> tCiWVQcgxeDTbJJmYRdxLIEhYOJGA;

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
					public PhxHtURGHYTpfVnuxUNfFAYbMAuo(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void OsaWSkImYQCkBdzTAZlTvjvJZsCq()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class GGjZmxcLfOKJynNBkihwgoKPKrrSA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int dsdELBqcTPjRompNluDWXuKiglIH;

					private ElementAssignmentConflictInfo yLIQmCqlFuohgNcVzitxevtzVGFf;

					private int OuxCsJVYzJeUKsOxzROlqYaotmEO;

					private int hwKXdzSikCDByHLkyPnvJMtFsqHT;

					public int JGgGeIOjBsXinifIKToopeodcqFF;

					private ActionElementMap jpwGOsWQPkiqHoiIQhkAPcRiVKgE;

					public ActionElementMap sqIPylUqOGljbNrpuctogvxqNMjW;

					private bool SEXlKSROWNOnsTLInqegKdMUgAko;

					public bool qXgsMRsXOFfxFkxGRWGcyDZoBudI;

					private KeyboardMap ggGDVGMweWXLGnIFmQLOUsgkdWIp;

					public KeyboardMap CLdnLOKBrXhMOflCnyGeinpqkemm;

					private bool VeUZQgLkhkfQLOeQOaGmEKfiPBWqA;

					public bool FOcBoXBWVXDSxBioOkuVoIFKVXXn;

					private bool inhReqWnXljFghBvwyMtZnWAHMgl;

					public bool NJViRkQooJTMaMBgPbJFxnLdsIHs;

					private IList<Player> LxGBDViraxEMpeyLiaDSiYdWRXBiA;

					private int fbGoqxHDfwlxKiKAWXgWoNHJZeoH;

					private IEnumerator<ElementAssignmentConflictInfo> OmZMvnWgempyyEhtpDTOajGHIAFJA;

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
					public GGjZmxcLfOKJynNBkihwgoKPKrrSA(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void uyZulZDEPrWZnfWBLKbbSXrpwaQe()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class nlQhjBFETzSKWGLgsGuDbNwYsCyUA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int fPWZKKmMtNvTbOCNilRjLduNwrOU;

					private ElementAssignmentConflictInfo foudGNIZEsobdKqMVUBvBemGuyqF;

					private int ZARNoUCFFfDSmhiSxbJWXvhnEICWA;

					private ElementAssignmentConflictCheck QgGEKhIkoBrrimpOlbuCcIEiOMmEA;

					public ElementAssignmentConflictCheck wuVJElBhUQdPpyZXoaJkVbZpMxMr;

					private bool jjOtEpzIaVAqViqaMCpKIsifMgfIb;

					public bool sYCknLoPNoCzBeorULeaiZoHCQYpB;

					private bool aIGhvAxcAIrxOtMqpjWJxLrNdaBF;

					public bool wOmbflHKkvMcdPRbbOMUKfCkTdFd;

					private bool tmbfpWYpnsInxMGhpghWRxxwqGuA;

					public bool GwlEGmgzTvowgCjTlGxNmCVuQzSr;

					private IList<Player> QLPBttgaOCVmYPiTwBJEcyldFHHwb;

					private int zoPnqrLEKUBzBMDoXyBNMenngXMY;

					private IEnumerator<ElementAssignmentConflictInfo> VihFAkcirEmTbhGwHdfWehSiGebCB;

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
					public nlQhjBFETzSKWGLgsGuDbNwYsCyUA(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void eMWNHbmsUwlYUhMQFdxJxusfsWyU()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class yxOSoXaAzQoIvJQcxPDjnffvyAHg : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int RrelRShLMUGqoiSFVZlTbmMAncSL;

					private ElementAssignmentConflictInfo sBlVrVLGpUKfjUkSnQxqpWLpSlDq;

					private int mTqzDSjgeTIsTFYUvavnAVynuVZmA;

					private int OVsoABbHGbJugCuGCoeHpbDYuypY;

					public int cCwIXQxNZskPpPhnWjJKeNCQQooiA;

					private ActionElementMap NaRkrPkdjeMJZmSwYlSeFqeuTgZn;

					public ActionElementMap FexowCNoWKpjXXFvUwZmGAharSKu;

					private bool dqkwMroHWQoZEkfNqlopLMCfLgKV;

					public bool tBXIXRxAMDzvOiWsEecsDfpdMkxB;

					private MouseMap sunUtnadNRWWoKcvMLlYrBeurWSi;

					public MouseMap JKNJDZXPmHoUMNOnljJbmwXPPfSD;

					private bool eYPEHNHtmCfvpwAFbgLudmdcUqIxA;

					public bool gWVevXWYTiPZwRmhIUbQyyRPOcHL;

					private bool rvMnIIashrfCHQMVmVTqAyqkVFtU;

					public bool UijdQKRvqsrzfqpHaLLSIYAALzTD;

					private IList<Player> gMthImWiOkSYsYiViMWhUCeOeyqiA;

					private int CuwocLLHwBWFTFlecUPfYOmtamjW;

					private IEnumerator<ElementAssignmentConflictInfo> ZFGAcPjHPImpORGzwIDtdfUCVnoVb;

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
					public yxOSoXaAzQoIvJQcxPDjnffvyAHg(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void JwnsNoqepTAtvpwXmbqxxxqwduqS()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private sealed class NKgPCAMsyyGiVsEzbwLrooFQzyiD : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int VJEKCheQnSCgGiWEMsdtNQdosYAP;

					private ElementAssignmentConflictInfo RqBcsuMxjtIkrYPKsZdeCgWPpyXm;

					private int LXaiRdmOxUdfzuDYtBNvCSilmFmu;

					private ElementAssignmentConflictCheck kfkUjYxhUCoobwrRweKZUQKKdUzJ;

					public ElementAssignmentConflictCheck jiLPCMGUxtSCLTaxxenqQUuouAtH;

					private bool dQCHoWdKqTMAhurZqejzVnxszHot;

					public bool RJXGtVduEmPKBhXQbADymJpIdoNdA;

					private bool bkBPROvMoJKuorgWjNJNLgWicPxcA;

					public bool leiFEaAKVlXwteAMGcHIiJbalJVX;

					private bool XIIkTBElTEBYBqihddImJhebStmU;

					public bool TrxdJSejcWOKWbODDsublYXanfiAD;

					private IList<Player> AgORlYCQAxSAnBvogssXrBzoxWJC;

					private int dKEslpnEXkKCUBJxnveqGyKWJtAl;

					private IEnumerator<ElementAssignmentConflictInfo> MhbgNBixtUVHoprOZjWVOnrUiyldA;

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
					public NKgPCAMsyyGiVsEzbwLrooFQzyiD(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
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

					private void MGSUqgWQekigTUaiWqrMDBcIBLmu()
					{
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
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
				}

				private static ConflictCheckingHelper FOdgXzABHEDlpQTsaPbspVzZHDkd;

				internal static ConflictCheckingHelper HmFzmqQHLecxtXADrDoxjuQcHywH => null;

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

				private bool OnelVkaRFNFiTxedirssxlWQnfYL(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return false;
				}

				private bool bNoNIdgFVZtEFZXGNwMiyTfRankk(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool OOjCUoFDrXPaZjSgUidQOYCAzzzy(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return false;
				}

				private bool QuZExjtMqCmfEZXKRpDkotbqImEw(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool ZbDculCKhEspnEVsKcuYjnNvEiItA(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return false;
				}

				private bool BbyIsuBjfGEaZWcbsLnUBIqqcvlT(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool veCCbrDaCRgHSvngBkWcNlVCoeacb(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return false;
				}

				private bool JAqYfGYLnOuNuNLvtdyjsnqddzRD(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				[IteratorStateMachine(typeof(eNLArjWToxQORDcnYldOFAmFLbiD))]
				private IEnumerable<ElementAssignmentConflictInfo> zxwGRXfwwISnmTMbQfMnFOvdOlbuB(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(PhxHtURGHYTpfVnuxUNfFAYbMAuo))]
				private IEnumerable<ElementAssignmentConflictInfo> gHKKLLpebJtdpUcBObBGHwYXDSZOA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(GGjZmxcLfOKJynNBkihwgoKPKrrSA))]
				private IEnumerable<ElementAssignmentConflictInfo> HjNhZWfFZbuaFIrSrFkhQsnINNTW(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(nlQhjBFETzSKWGLgsGuDbNwYsCyUA))]
				private IEnumerable<ElementAssignmentConflictInfo> EIDURwWLBUISExNriuwTGcaLaIwv(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(yxOSoXaAzQoIvJQcxPDjnffvyAHg))]
				private IEnumerable<ElementAssignmentConflictInfo> tvcCvpfATFgkfeJoWSPpRloQqdhB(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(NKgPCAMsyyGiVsEzbwLrooFQzyiD))]
				private IEnumerable<ElementAssignmentConflictInfo> BaQuLAIONTCDePVjMBOWaFLozYDl(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(nWLaLpJTPpzzAqXNtxZVjFvTrLjZ))]
				private IEnumerable<ElementAssignmentConflictInfo> KiEKqiBFyZysiNcLjQBOviKurvND(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(SlvDdvgoEAMpQVyNFpbYePBfrDNtA))]
				private IEnumerable<ElementAssignmentConflictInfo> LhfZnOwgFEpLOTNYgmOYEacxXubs(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				private int sRATJSonAesIUgUIsAIWLnfNHEVG(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int XxugILoSVjwdQkKIhFSPKtXWKThoA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int sKFCuAEeytPIHdGgjrqboxHfGbiyb(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int nfPxjZLesyCPhCqGutNymaMsMIlI(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int ErcvUEHFeXgJXaGHSKsnbKbBBxrfB(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int mnvjEoNiZWexvcCPFqbcVuQaLyxR(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int XJLSFOXUxpfbqyifbiZMUSVfFlFT(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int ifwdLJFbRRqWMQrglnsApVQddaVCA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				private int fSlVfHCVGOSqLrKljWVTVbVOzuef(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int LEOEJJBDqppyMdZlZyIpwRtGKNnDb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int UdoqSJsPmCqbnLDsRfQbGjXJLksB(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int mkWWfMnhxKckiWsqNxUFdbVRZTnp(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int sWkTjcfHdPchxrxQubbDCACLIxYD(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int IqvAGkIUcBrWerPjsbJlIiAmloMzA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int McFKVibCCVBCCCYhOmkTrvcuROvhA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int XhBgYIBrxakTNAkVYuUKfizPXalfb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}
			}

			private static ControllerHelper gBjPsQsvNhXchiOPkspaIycMUHKH;

			public readonly PollingHelper polling;

			public readonly ConflictCheckingHelper conflictChecking;

			internal static ControllerHelper AooEEddAltMEqgcWGNYyWGhsvBNob => null;

			public int controllerCount => 0;

			public IList<Controller> Controllers => null;

			public Mouse Mouse => null;

			public Keyboard Keyboard => null;

			[Obsolete("Deprecated: Use Controller.enabled instead. For example, to disable keyboard input: ReInput.controllers.Keyboard.enabled = false.")]
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

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class MappingHelper : CodeHelper
		{
			private static MappingHelper AwbcpVIGEHzxSiIkaOVnpPaHnWlqA;

			internal static MappingHelper LPOkVJtSbfihZqIFacKBUpQcAYjaA => null;

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

			internal InputBehavior BBPEHqScUoBHreumeERnbRbRgWkab(int P_0)
			{
				return null;
			}

			internal InputBehavior CCOfondrYPPMmFOEdcmpDVpnnBKcb(string P_0)
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

			[Obsolete("This method has been deprecated. Use the Controller Template system instead.", false)]
			public ControllerElementIdentifier GetFirstJoystickTemplateElementIdentifier(Joystick joystick, int joystickElementIdentifierId)
			{
				return null;
			}

			private ControllerElementIdentifier dEjufPTzEjllVALyDysfYkHntcAf(Guid P_0, int P_1)
			{
				return null;
			}

			internal int TovfBBAEhHhuVPIRYwfepGXgrIMwA(Guid P_0, Guid P_1, int P_2, List<HardwareControllerTemplateMap.uKDNunZxjrWGmifMdjMNvgUgUdWg> P_3)
			{
				return 0;
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

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class PlayerHelper : CodeHelper
		{
			private static PlayerHelper aFdEMHeaiZufJEmnaGRwJuIlAJntA;

			internal static PlayerHelper gjQeXbUZHjlvEfFFiAxLdWbNwYxE => null;

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

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper JzeIKDCNQxToPhgOmNqLvhsrATTe;

			internal static TimeHelper jFMCsatWbTelHTEXYcdGaytCgpij => null;

			public float unscaledDeltaTime => 0f;

			public double unscaledTime => 0.0;

			public uint currentFrame => 0u;

			private TimeHelper()
			{
			}
		}

		private class UEdRgsBHoVUTMVERKBIpNBpkdIL
		{
			private class BXTERpFjczIccXPMDAcgSNXmtgAiA
			{
				public readonly UpdateLoopType SJqdVKAuFxqMZGuObFYLPvziLzHqc;

				private double BMtyXKylznnrIJSEAJQQcEEvnrff;

				private double FDhkXUnXMzGkYjHCYHKBDYcgwRcJA;

				private double GXPtWRsQnERmQFZpDIdsjkwAOLGK;

				private double JyLqrFeNdbgyBswshpSybGDIHbob;

				private uint PLcPIhtqppNWwltnyewVgStPNEAs;

				private uint egDgztCZOPPrcdABsXocsGGgpxYGA;

				private float vLNENFkMVvJdnXFyYHNUjhgkprLgc;

				private float aYoOmuZcJRlluUSEFlpfTniShYwhA;

				public double LTaiYzWxUhTibvJXrVUXKWsCEAoj => 0.0;

				public double JkOIHXCGCqMFtNPqgfSqPdXnjHZE => 0.0;

				public double kNFwBYzkPDzLKYlgCayREhXRLIdUA => 0.0;

				public uint HZrDKdEMLqXRmBXfutTuZGAWgVVR => 0u;

				public uint rieKnOiYeQDweKQEONSLtkevDPxIA => 0u;

				public float texCIZxiStEzorHyjZlDSojeAecdA => 0f;

				public float NeudGLYMfUxiVdEVKCSawCEJpScj => 0f;

				public BXTERpFjczIccXPMDAcgSNXmtgAiA(UpdateLoopType P_0)
				{
				}

				public void vhpvcLkuTNQKdvLtwdhjfTWYekNp()
				{
				}
			}

			private static class msMusqovylMYrVosZdjcUBqpbbng
			{
				public static StopwatchBase kUUPFQnXkpFDGfABOybdvrOGvtqk => null;

				public static StopwatchBase hazpSXDBQPUNMprMjGUkCbaRxsfw()
				{
					return null;
				}

				public static StopwatchBase kGKtFVEfSBdJjsQYHNvGiPPNYKRg()
				{
					return null;
				}
			}

			private StopwatchBase MfKTkgLHgfjElINxFveRDdNfVDqv;

			private double ykqBzXfkahZlBlYDDgLFgmskHzVA;

			private BXTERpFjczIccXPMDAcgSNXmtgAiA OiVsyPMNWwoeUZoLonpmfNZpXZeP;

			private ADictionary<int, BXTERpFjczIccXPMDAcgSNXmtgAiA> nkEgFDAqHhJczyyUgdtaVIwVpFZab;

			private uint XrBJYGUUvMpdqIJjbZmgbAnWFnoK;

			public double MTHILJgqLMbsfyBHFDvlUawhYlUi => 0.0;

			public double MBljhlCTIsviOjuvFeBinjlbQNVfA => 0.0;

			public double VfKjxilqFGAdupQAKMpJDnPTySFI => 0.0;

			public float UkbAPkrYekKaKanwMQDibwqMditV => 0f;

			public float TYNNhctxdWPskcJHewAGGXlcspIF => 0f;

			internal double YVegxgIRWLJcKQtkKjplUDEbLcYy => 0.0;

			public uint VmKHCIzmFXhQMLPuleAdLXUyNowK => 0u;

			public uint ZZxCtoKatTluHMqnQKhdIVPDnQTXB => 0u;

			public uint fKebKIoPuIaTXJWDWwMrplgqpsABb => 0u;

			public void lEZHjzGcfGXYFOSIXosUZsCaorfeA()
			{
			}

			public void mRPHvjFBQEQwJTcmsyNvxOSfeVng()
			{
			}

			public void ukuWlqZUHCdOgiltuvupPJGyVbWd(UpdateLoopType P_0)
			{
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch slPqlWDjJVcmwCqhCNKILpOSMZoCA;

			internal static UnityTouch CtazCbDLmYfhmyJkXVvlGffMOaYj => null;

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

		internal class lbNjuLhjboclBEPxqwruFMZFascnc
		{
			[Serializable]
			private sealed class kiNziJVhoRDLOKcHVjpJsPqTslQh
			{
				public static readonly kiNziJVhoRDLOKcHVjpJsPqTslQh _003C_003E9;

				public static Func<bool> _003C_003E9__12_1;

				public static Func<bool> _003C_003E9__12_2;

				public static Func<int> _003C_003E9__12_3;

				public static Func<float> _003C_003E9__12_4;

				public static Func<bool> _003C_003E9__12_5;

				public static Func<string> _003C_003E9__12_0;

				internal bool wUAhivfHVdZOnFTetGWWnPKkKQYsA()
				{
					return false;
				}

				internal bool DWrFFysoQpuoEIiOyEwBdhzgueGw()
				{
					return false;
				}

				internal int gJjNuRBDdYsTLKzCWjQBIasxhiQm()
				{
					return 0;
				}

				internal float eEcpYDHfnpBqrfmaJFfweEDoeNgA()
				{
					return 0f;
				}

				internal bool pRzZPwaQiqKDQxUqhxTjjXQQgFY()
				{
					return false;
				}

				internal string AKFaCzwgTZdfrHEKiNyHQJAVFhRFb()
				{
					return null;
				}
			}

			public readonly ValueWatcher<bool> ekmjdzeHIpaTTcqtvXRYRVuGYnJvA;

			public readonly ValueWatcher<bool> aJWhtpnQXeItXoejYUSVdEZpAgZP;

			public readonly ValueWatcher<bool> OTGlkNHIsOFCbJkafQUGJSGABIUO;

			public readonly ValueWatcher<bool> ikFIetaXZcEkZHSMfsNiKQlLMcNu;

			public readonly ValueWatcher<int> oEJBBBachEPBdPcgKcAIhWfcaiEqA;

			public readonly ValueWatcher<float> LMqlSqJzbCytqYuHddJwvrlUyqdi;

			public readonly ValueWatcher<string> HdjcdxTdsOdqvSIdPsQubWsUqeOs;

			public readonly ValueWatcher<bool> AIEMGXjkYSxjBdOomOrlnnHIndyQ;

			private int jtEFDEOhrYRZVqFxsGQMtvcKBfik;

			private readonly ValueWatcher[] QdLSYIwRtmoHAosSxRLkVNNvybgt;

			public int YMZfIYyLJRGBWJPTLGwAGCisXFeB => 0;

			public void kNEnCVRxicaXiUmydqXeRdtzwYeU()
			{
			}

			public void HwVWIfynYGBSSCNCRRhKXDLEChelA()
			{
			}
		}

		[Serializable]
		private sealed class RwFnmTMKSIkkJVHqtwJKgrfhyomD
		{
			public static readonly RwFnmTMKSIkkJVHqtwJKgrfhyomD _003C_003E9;

			public static Func<bool> _003C_003E9__235_0;

			internal void zuJKCghDeQoubpKjZfpEFMDQYPNPA(Exception P_0)
			{
			}

			internal void rJgCOygyZNgNqhlgDpMKEZkfPkdXB(Exception P_0)
			{
			}

			internal void GUOqpoYGuBaIuEPohOHANlwOJtjtA(Exception P_0)
			{
			}

			internal void okmzJdGcPDSbiIBmqfJBFeetQBkGA(Exception P_0)
			{
			}

			internal void JeKEsjdIttTYqSnGQKujAgvTvnFtA(Exception P_0)
			{
			}

			internal void fMeqjkQGpkKwITtLrrMkotKRrUxN(Exception P_0)
			{
			}

			internal void OoNkzgluTkaemqVJJsjdXkJPYqRG(Exception P_0)
			{
			}

			internal void KOGHMiXCcNfFGalrUrdomgSvZJulA(Exception P_0)
			{
			}

			internal void avisgCbDqvcfvFbPGWjGUWtNkovi(Exception P_0)
			{
			}

			internal bool lmSlOcxPEHcqaGeKsivkNjTHCvxBb()
			{
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal const int programVersion1 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion2 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion3 = 58;

		[CustomObfuscation(rename = false)]
		internal const int programVersion4 = 2;

		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U6000";

		private static InputManager_Base xmsnQLdLkHVsixDlSevWQvgSjiss;

		private static PlatformInputManager cTnatmYnWMpRwoDWVYbNYfCUsvrT;

		internal static WNDAGEDYWQadsbJDABgwhJlLbvisB vpxrDeoJDOSdBfXIimENtUVHOWIo;

		internal static YdgUOjdefzAWTMpEeriKxkUxlwEt KsJXpDsMixBwMhOpfXJXqgrTCMir;

		internal static oRdRfQpIsmMdCmwmmgzgOnpcWgSP JXooPWXQeUgTsYenpLNaUJAXxNJf;

		private static ControllerDataFiles MPcdeWqkITnNTfIXxNfATWcxtHcX;

		private static UserData jiVTJezUSgjmVRgAwhMIYgchJeuE;

		private static bool duJfbUTYdcFkwpKAQGPArkFHzFnu;

		private static ConfigVars DpEhxGWensfXzCSilONjPLvEYBUlA;

		private static UpdateLoopType aCQHsEEBQsTTlqFsOPOTQYemydihA;

		private static bool JuBapaepTCjxJemHvkoddVPZfAcb;

		private static Platform FSXudqUtPHRtCLMttOJJBPActLwQ;

		private static WebplayerPlatform iepGJcKnuxuSfIqajkJwJKFdMBBiA;

		private static EditorPlatform QSYNmvZLBIHHZTaaJwdqhbnLPctd;

		private static bool SpqOWZYxNjLlFAxwGdsxjONSjYXb;

		private static TimerAbs xYnKAXXoLMfWMXqFTXoiwtQgoQSW;

		private static UEdRgsBHoVUTMVERKBIpNBpkdIL aSSFlsMKkKBBBEGhWYWIcuusYnkA;

		private static string ZJXfkCNZIeOOBSdmAbauDWRXwweM;

		private static bool LFcYqcYRPaoIvuGlDbVHCtfqGxULA;

		private static bool wekejbaXlOlikCeROCiGhLAyLHdBb;

		private static bool cjJtmBlgGZxaMkCsEOdEAeCsmsXQ;

		private static int jutMBpPFkopDOTKgLqxcCieoCRrD;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int VtdunuFvPyVPtjSYZrhnUYhPxCgE;

		private static int yeqrzBWOqEooESjrAbvqJxbmyRsV;

		private static bool jojXquLMLleoXhtYyNMPeAEmhmNpA;

		private static readonly UnityTouch LHfvUTBtFhdKbxnQOIlYUMnaoOLd;

		private static readonly PlayerHelper CAJQWIhxIAPJAkwQpZZKxiUNGPw;

		private static readonly ControllerHelper hUfIgqObWfaxcWkJgloANvFBoBze;

		private static readonly MappingHelper ArTqfbkGSNdkdigNewnEgnfAzvOe;

		private static readonly TimeHelper GbqNFQuCTAzxRrKAhdHoKMAdHpBcA;

		private static readonly ConfigHelper SKuklwPkntPQlzGXeIsSNoDmCbyV;

		private static readonly LocalizationHelper aRrniAUXwCaVGzwLhBuWOzunLbet;

		private static readonly GlyphHelper fLvJIRlEgiwfRoAiXdwTVPzHlAch;

		private static fyFEhsjfvcjfrftALtopXlViJyJsA pXGagQkKDdFlbePlCWDoZAYhjEPab;

		private static UserDataStore HwqJUsgYdGSFmayOUTfdKUztqEOo;

		private static IControllerAssigner OMYByVmnLQJuCVXHhBSNPbUeYqjJ;

		private static lbNjuLhjboclBEPxqwruFMZFascnc RNgdWVdhlHoCMrFxZBViKDFWrOFxA;

		private static SafeAction<ControllerStatusChangedEventArgs> FTSnmiXgCUugdNdNOyBmNPxaLRYw;

		private static SafeAction<ControllerStatusChangedEventArgs> cninmAGYJFrcnGKSkeTkwPwMbgCs;

		private static SafeAction<ControllerStatusChangedEventArgs> NHagRngSWbeXMdPmaKdqaZqQbnxsB;

		private static SafeAction OLefMiDMkVYgCpUGkQkgPoLVeMrEb;

		private static SafeAction kjGpVHkBvDBuNfkXxCfIqInInUsrA;

		private static SafeAction wZutCiAqgVYhpoBhPNqIJgScXkXk;

		private static SafeAction wuiTVXAHrubIWZUNzrhHTcemlIbF;

		private static SafeAction wcWeRCkLEPsyUTRXnGdxIYUDvZbTb;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationPauseChangedEvent;

		private static Action yyTGiDgWySJoZRqAdBsFnjIYyVZp;

		private static Action<UpdateLoopType> ytShPykmXjzcNnieWtosofZIfJSZ;

		private static Action<UpdateLoopType> KqRFjScAKBgoTEXxxrpgcbVNmXph;

		private static Action<UpdateLoopType> tCIBkJiJcrjODNPHOYnLDQyUQWKm;

		private static Action AweOrINTycyuOkbJzjehrMkzzvlM;

		private static Action<bool> AnOlOTUlFkHqGKBakKEdhivgAlKk;

		private static Action<bool> tudrobDOMiFEmaDLcGfbsjFGPkknA;

		private static Action<bool> ZTRoGAGJpuffByHVoqIxQiSmgpSU;

		private static Action<FullScreenMode> ZxxxDLVobSEPpHZlKVIETWLqedKD;

		private static Action MMlftInZdUAfMcEiXnRgYoKJDgBAA;

		private static Action<bool> yDsyCjiNgNwKEjboTEZmTzkGMMUA;

		[CustomObfuscation(rename = false)]
		internal static double unscaledDeltaTime;

		[CustomObfuscation(rename = false)]
		internal static double unscaledTime;

		[CustomObfuscation(rename = false)]
		internal static double unscaledTimePrev;

		[CustomObfuscation(rename = false)]
		internal static uint currentFrame;

		[CustomObfuscation(rename = false)]
		internal static uint previousFrame;

		[CustomObfuscation(rename = false)]
		internal static uint absFrame;

		private static fyFEhsjfvcjfrftALtopXlViJyJsA UnmGPtdqqIgnDKNgaDQLRtbNgfVr => null;

		public static PlayerHelper players => null;

		public static ControllerHelper controllers => null;

		public static MappingHelper mapping => null;

		public static UnityTouch touch => null;

		public static TimeHelper time => null;

		public static IUserDataStore userDataStore => null;

		public static ConfigHelper configuration => null;

		public static LocalizationHelper localization => null;

		public static GlyphHelper glyphs => null;

		public static string programVersion => null;

		public static bool usingUnityInput => false;

		public static bool unityJoystickIdentificationRequired => false;

		public static bool isReady => false;

		[CustomObfuscation(rename = false)]
		internal static int id => 0;

		[CustomObfuscation(rename = false)]
		internal static bool initialized => false;

		[CustomObfuscation(rename = false)]
		internal static UpdateLoopType currentUpdateLoop => default(UpdateLoopType);

		[CustomObfuscation(rename = false)]
		internal static ConfigVars configVars => null;

		[CustomObfuscation(rename = false)]
		internal static IConfigVars_Internal pluginConfigVars => null;

		[CustomObfuscation(rename = false)]
		internal static UserData UserData => null;

		[CustomObfuscation(rename = false)]
		internal static Platform currentPlatform => default(Platform);

		[CustomObfuscation(rename = false)]
		internal static WebplayerPlatform webplayerPlatform => default(WebplayerPlatform);

		[CustomObfuscation(rename = false)]
		internal static EditorPlatform editorPlatform => default(EditorPlatform);

		[CustomObfuscation(rename = false)]
		internal static bool checkNeverPressed => false;

		[CustomObfuscation(rename = false)]
		internal static bool isEditor => false;

		[CustomObfuscation(rename = false)]
		internal static Guid defaultHardwareJoystickMapGuid => default(Guid);

		[CustomObfuscation(rename = false)]
		internal static bool isRunningInEditMode => false;

		[CustomObfuscation(rename = false)]
		internal static bool isEditorPaused => false;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTime => 0f;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTimePrev => 0f;

		[CustomObfuscation(rename = false)]
		internal static double realTime => 0.0;

		[CustomObfuscation(rename = false)]
		internal static int currentUnityFrame => 0;

		private static bool VeTDGAuJIcsUlIscOPCZQQHbkOsT => false;

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused => false;

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused => false;

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform => false;

		private static bool hLFyJpeWJNJSLnajyUpYxPyHqCHD => false;

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFocused => false;

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsPaused => false;

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFullScreen => false;

		[CustomObfuscation(rename = false)]
		internal static bool applicationRunInBackground => false;

		[CustomObfuscation(rename = false)]
		internal static bool timeScaleIsPaused => false;

		[CustomObfuscation(rename = false)]
		internal static InputManager_Base rewiredInputManager => null;

		[CustomObfuscation(rename = false)]
		internal static PlatformInputManager primaryInputManager => null;

		[CustomObfuscation(rename = false)]
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

		[CustomObfuscation(rename = false)]
		internal static RewiredVersion rewiredVersion => default(RewiredVersion);

		[CustomObfuscation(rename = false)]
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

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationFocusChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationPauseChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action EarlyUpdateEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action LateUpdateEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action SceneLoadedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
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

		public static void Update()
		{
		}

		public static void Reset()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			return false;
		}

		private static void CdGvTwXVkUGjyFYhMPiSDVmmjTWu()
		{
		}

		internal static void AMAiiacbVSaSRgiXMZZbdLBCrirL(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4, Func<UnityTools.RulKtWICGnnCbAxnQaRfWrUvorPb> P_5, Action<Platform> P_6, Action<InputManager_Base.pTBMSbbgJUXmuDnypoyTckrxDbqf> P_7)
		{
		}

		internal static void ITraoQfSjKoJFPFLsAWsztczLwoCb()
		{
		}

		internal static void sNPmbYEJSmyVKrNquqxpxQMFuEwe(UpdateLoopType P_0)
		{
		}

		private static void GIHtRahWhPtmiPSnJNkmfamnWfZJ(UpdateLoopType P_0)
		{
		}

		private static void jKvDXrWargOESWQadrsPNAGZyEaY()
		{
		}

		internal static void ioyJtGugQgpCoJBSAdQukFbEVhVv(UpdateLoopType P_0)
		{
		}

		internal static void QFvRqeFKyAUbAHjFkKSKTnwQEewc()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static void EditorUpdate()
		{
		}

		internal static void wOStDPhlnzbqjcJPbdfzWVlrTgmuA()
		{
		}

		internal static void MOlfHjHMusrqkoKmWcrhiupoJYLWA()
		{
		}

		internal static void dKIqBoWwoRGnhQaxlXwUsnCOxEeh(bool P_0)
		{
		}

		internal static void LbVXODBJqGnvlpJqXxJfKdlSXrXD(bool P_0)
		{
		}

		internal static void GebNdCoWNKdpKKrAlOYYxRFloqok()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return null;
		}

		internal static HardwareJoystickMap znqxpnISCEWKYLuUfJOPqGtRwCIx(Guid P_0)
		{
			return null;
		}

		internal static HardwareJoystickTemplateMap nfQPHOXJOnGWywlFYjBYGhoRvHIQ(Guid P_0)
		{
			return null;
		}

		internal static NrzRMZtpwBYsRYBDroszOSHvSgOn aKDcPCFvcUImoTHtDLGoFKbBjwAoA(Guid P_0)
		{
			return null;
		}

		internal static IHardwareControllerTemplateMap AbBDDXSkyXQyzAcWWqsvogNiprIA(Guid P_0)
		{
			return null;
		}

		internal static IHardwareControllerTemplateMap VNPmdWYlCDEqkuPjsGftcTEEFhYsA(Guid P_0)
		{
			return null;
		}

		internal static IList<NrzRMZtpwBYsRYBDroszOSHvSgOn> QlHcuJnaqNsjRWInjYZWWrhYCjRj(Guid P_0)
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal static int GetNewJoystickId()
		{
			return 0;
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleCallbackException(string source, Exception exception)
		{
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleExternException(string source, Exception exception)
		{
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleExternalInterfaceException(string source, Exception exception)
		{
		}

		internal static void vIOmPbmIpiCMzZhRwrgiFvoerLAj()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
		}

		internal static float vfMNslaSWIYdYbwHkVekaBJdZfTJ()
		{
			return 0f;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized()
		{
			return false;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized(int reInputId)
		{
			return false;
		}

		private static void JlIOGxyKeRFYgyakyRmFBaJoQEiE()
		{
		}

		private static void SLixqOKzwFktHqOaCuIvKmnkHSCW()
		{
		}

		private static void MfwcPLgPVseqbGkvrCixAsGDorcTb(string P_0 = null)
		{
		}

		private static void fxrSnClOYJlvBFSZpAFwhDikaJEDb()
		{
		}

		private static void zMbkMCmHbrJCHxeSNavrUwvRgQgq()
		{
		}

		private static void UESveUGysnIkyZmQIbTxOCfAdOhW(BridgedController P_0)
		{
		}

		private static void NVgDVWFTBzprxTIGbKvZckhiUFDbc(ControllerDisconnectedEventArgs P_0)
		{
		}

		private static void XzqPFEYsHYWtyHBEYbbGdyYYSFqf(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void TxFEXgIBBOjBGPjHUdcvDfXVqVyZ(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void moUhduhFBgdNusmjZfdMrfrYQFwj(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void DarMVYobealkLrRpNOnjwgXNJdPN(UpdateControllerInfoEventArgs P_0)
		{
		}

		private static void SZjufEojOAFKDJqRAEHlkAGSCwYJ(bool P_0)
		{
		}

		private static void WsjCpnWUzhqYKecOfdaeNCbirLsL(bool P_0)
		{
		}

		private static void YFPUzOqukorVToACiIfymrUuSTim(bool P_0)
		{
		}

		private static void FduiHuHivVWlOVtPbREtQnjTjPqcb(int P_0)
		{
		}

		private static void aGJgIIGuTTmigyLziqTqBAuFAvUvb(bool P_0)
		{
		}

		private static void sUxRkrcbUFEFtcdOcFxBojGghdUV(bool P_0)
		{
		}

		private static void CVFAGbnjIGBHsMpePdbrUVihtwpg()
		{
		}

		private static void PbsCSPZypLSWRTsOSSDfBHBQhAsf()
		{
		}

		private static void INhaKvBgMOojeJZuqhkOeOysDdLF(bool P_0)
		{
		}

		private static void JOVxXooTngIMioUqJeIhiMHQjJEHA(Func<ConfigVars, object> P_0, UnityTools.RulKtWICGnnCbAxnQaRfWrUvorPb P_1, Action<Platform> P_2)
		{
		}

		private static void JZaBXQVjQBEcWHyrUrPZXORNzDeo()
		{
		}

		private static void VaKlFTJgdoerUjDmxvrsWismIuKu()
		{
		}
	}
}
