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
			private static LocalizationHelper PqFQBRthqmubRAquVNtNZPgJRoxB;

			internal static LocalizationHelper kScfYREWKeSweNxisyOBriBHDOWiA => null;

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

			internal static void YMpbVhJCCSzyErUIVmIljDxXAKfn()
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
			private static GlyphHelper FFNJuYqLbuxbZfcwwaBQKBxjTGTnA;

			internal static GlyphHelper gBekWBZCQbeeFnPGVBrokpSZozJg => null;

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

			internal static void amCpibRdtunuMkLnvoAfXZqiOdXN()
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
			private static ConfigHelper LkllJrvIGaAHQCImWuzEtNdnBkAJA;

			private float srqPIXKGbobkgGkEQdumccoJTWsg;

			private float khSHCwkIhUegmaAHbWQFVMXYcsxEA;

			internal static ConfigHelper iuzUSMpxqVpBnytkMYyAorwOumnJ => null;

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
				private sealed class SlSpNoVwqJdtCtKDuhoZUNifcfRw : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int pdYTpsWmiTGFfFWQMntxPLYBqLfKA;

					private ControllerPollingInfo PBHBDxURNorcmDrTMmDHOHSqvbVE;

					private int pUtAgPdQmTfxzghQgchgelxsbWxM;

					public PollingHelper yjDYInAAWfzoNShFJfSAdXujuHdJA;

					private IEnumerator<ControllerPollingInfo> SWkSKxLhNbVsXBzHYBTPSAebopjp;

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
					public SlSpNoVwqJdtCtKDuhoZUNifcfRw(int P_0)
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

					private void LzZoFayssYwspHumrLxwacxtHGh()
					{
					}

					private void tkNhnjDStTjrhLNabHbmbOQQuzJJA()
					{
					}

					private void aWLlCyRPTEzfGSLHQZzPZaQkZQZN()
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

				private sealed class sWrTCjsvbWWKrPLutmPECWAkJKeQ : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int mEVIiSaTVxbxuuUvbzRoFdVqiptsA;

					private ControllerPollingInfo bVjOVCIwpsMyGZBDtiejtXeGanlY;

					private int qfrYfiZuflDyLtUFbIQQUQuaUvFD;

					public PollingHelper zVjeQyuBGfCcEbfHkSNXCLvuEVYFb;

					private IEnumerator<ControllerPollingInfo> IupldWUTBiadLknhtHWgIrDULbHf;

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
					public sWrTCjsvbWWKrPLutmPECWAkJKeQ(int P_0)
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

					private void PzRpELtxsiBGZAGWMkfRvQDrDBSP()
					{
					}

					private void jEKFEaQjZehejdckLpGpzzNQOUpf()
					{
					}

					private void mWtJeJHdFtgLVcRzQJiKZpvBUgwT()
					{
					}

					private void ufQVNNguAjJMlACfzlyzRetuLeke()
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

				private sealed class uOWzurgODDBtuUNMzNeZkLJhsWtN : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int qASKbYECRQWdowvtdGLRaWZauiyC;

					private ControllerPollingInfo jPBHjanqRIrZqvAoUfNEXcEoIIeFA;

					private int hmogrUkdYijEiAdsrBfIITEwrUAEb;

					public PollingHelper XVQUWbphSdHSqydeDVyUTSOBCKeM;

					private IEnumerator<ControllerPollingInfo> ZetQedTgEVoQVAtYdllNggXaHdYx;

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
					public uOWzurgODDBtuUNMzNeZkLJhsWtN(int P_0)
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

					private void hGLDMtqPyiMQpEMINnaVlNeydopKA()
					{
					}

					private void YRvciQSTHIOeSVRBQHwDKLFAaJPw()
					{
					}

					private void KMIwkCKKlvERiMLWYqCAcHpiICdR()
					{
					}

					private void AktdkvKuZWKyKLKxCKYkvBMpbUuo()
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

				private sealed class nqVtCBfnsGptzpKyuUnoydZtwUgi : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int pgvNzUKwGGexqseQFUnDfWZCxuNj;

					private ControllerPollingInfo AqaFHzbOviFiEzZyMUFJLjrLdGrgb;

					private int ykYamScJIWjjUnowpHAPGYtXqcfzA;

					public PollingHelper xMCfwuvpzEFISfrNYMTMQXfdCnTdb;

					private IEnumerator<ControllerPollingInfo> LQSeEoDeeQAkkESKtRaFaXfFUtQd;

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
					public nqVtCBfnsGptzpKyuUnoydZtwUgi(int P_0)
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

					private void bhQLgSUFDGymnaaeKkBBdBGHNONO()
					{
					}

					private void ymYqATpHmEXxbnYZEtZsRBFZmLiL()
					{
					}

					private void bdiSKbWRMceRbjrcHGycaepBcLIOb()
					{
					}

					private void NSEhYJxpcrNMFCGQTqlSHorYJuUI()
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

				private sealed class FQCQHRxVhzLBSPMOIfsmTIOvUmnO : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int GaPkaVQHECVTdsHgHDziqjJGaDNbA;

					private ControllerPollingInfo MwcDQtftukvbXEFUwtYRrVETrwZKA;

					private int wDSJOTFfmFjkCquCrILxVQSBGyMd;

					public PollingHelper ObxZSJAkTDEpNUnOQHivKDLAMaIO;

					private IEnumerator<ControllerPollingInfo> tWtcnTvJPYESoHxZNziztydYWixUA;

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
					public FQCQHRxVhzLBSPMOIfsmTIOvUmnO(int P_0)
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

					private void BABPdUmigIgCKhvNniBhCNWsEETd()
					{
					}

					private void StFhyHPwstCNFxcXQdbhZrKCTjVS()
					{
					}

					private void JfEnqaeDNpUwtSxlOHmtoWhqIbTd()
					{
					}

					private void CZdCJZBJcecifxeJPBeQJoHqqZcJ()
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

				private sealed class DIZQshBLQpsdERWWAnHPOqEjDSIj : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int sTnFGzAofqGXtMGWAoejHWjkCgGS;

					private ControllerPollingInfo QUDDaZCAIiPedoCwjaUneOmdOYynA;

					private int CUaAujDfMMnwDrCpJvjwmGgXMHqD;

					private IList<CustomController> PdgPTGVkhJuTKbzzvafPnuvSlYGd;

					private int DZVySgnrdPjTZVUNDRgRrjZzyBFd;

					private IEnumerator<ControllerPollingInfo> YucqtxyjlQeVQAdjHzjcQLIdKnVZ;

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
					public DIZQshBLQpsdERWWAnHPOqEjDSIj(int P_0)
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

					private void hOPIQxPuxGcPqWPXuOadvYCaJObL()
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

				private sealed class lkIWIgPgwEIGMuYvwfRelwQTolXP : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int zVfcLcHBcQJKNQpQmHkZUlQWcPdOA;

					private ControllerPollingInfo iAaSGaYIFgwIRXNSmCKwPrbpfkYGA;

					private int jOtFDdFtfhHSwtwMUdCfHWzEWlOzA;

					private IList<CustomController> yWpdpniPrZNKBsunBvLaOxtIURoD;

					private int OdIQRPeiCMppDpTWrIdqgFdTIUtM;

					private IEnumerator<ControllerPollingInfo> BeGsnAzGgEglCRHSwSLgnxyxMFKn;

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
					public lkIWIgPgwEIGMuYvwfRelwQTolXP(int P_0)
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

					private void RhyEEziIiDQlxGwbCzlvwrWsLMqsb()
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

				private sealed class mvdswMvzxbRElwyhyNaCLReFWLbB : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int EhyGWhAATppwJTxcUixngYAxYdXPA;

					private ControllerPollingInfo oNDPPoGMXfgkBjitridOqVZkzpno;

					private int KVbJnZYQRhfOCoMEBkyUxPHduAmp;

					private IList<CustomController> UsKLjeegIGZcXtIMONWxkbIWUrKP;

					private int tNLPIAoxwvJaoNIhTPqkvLwVWqtW;

					private IEnumerator<ControllerPollingInfo> cWbAcHEFqKsPOVOYkisLcobBuoUf;

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
					public mvdswMvzxbRElwyhyNaCLReFWLbB(int P_0)
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

					private void kfdrVunVZJFUTWonsJNSxHEkLhzI()
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

				private sealed class FUarClvkzUEYNReknYXeKCmkbedJA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ZLoZhmeQtPeCgJOgObSKglNHAxxEb;

					private ControllerPollingInfo evXhSPgfZCBGDZItaChCOdWyxWkp;

					private int gKYesaFRGzMWtZVxKwYvImvPMCveb;

					private IList<CustomController> zildyPyphBegLcgtGDAZxHBitIxE;

					private int ONNYySrbgFhUdoxzRyoCEhaPRtie;

					private IEnumerator<ControllerPollingInfo> IzSvIRlKaVRtjwoLgMclMnfmNpoj;

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
					public FUarClvkzUEYNReknYXeKCmkbedJA(int P_0)
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

					private void QpPAPuwtQtwlxxFBHaquWXWiqiZH()
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

				private sealed class pAyknxkkuCnsqiuzlrTlHqfUZubK : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int XHlVFaLudHUFXVdYaDhLiHqrKXRv;

					private ControllerPollingInfo uwsSTyqiYBAhVpAVTNZpKOnrHGQA;

					private int jxJXoVBNmkwzsoMJscBptqUEKPFC;

					private IList<CustomController> eCMsNXJqHMaCzJWUDAwxhJQJxfZtA;

					private int qbfsceIzinMPCiiZnSTsHSiqoDMl;

					private IEnumerator<ControllerPollingInfo> HxrSkPoDjAoSegxdjbFOYKoKtoqw;

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
					public pAyknxkkuCnsqiuzlrTlHqfUZubK(int P_0)
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

					private void BVvpIVXfwVppBTNxaCtMDUeafoPh()
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

				private sealed class bWmXvDGUMiQUFXbbNxhJhZDpiQvp : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int CRYmNTvHTACbqgoVcISxcMDJDOXF;

					private ControllerPollingInfo DCwbUFVumaTuboiXyhXkWdCjjJps;

					private int TcCZcJzENuZeLbnfmNDxYbSYogqK;

					private IList<Joystick> zlXcbKDfRbLPRTALLtgGmvFTnvYDA;

					private int MGVFIVmMIrZvwxeDwCHOaCxRBIcAA;

					private IEnumerator<ControllerPollingInfo> RQSkBDeuKDwjEGVbBygQbiZesofI;

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
					public bWmXvDGUMiQUFXbbNxhJhZDpiQvp(int P_0)
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

					private void IzNzmiojmhttZIhdFFVxmpMnCcsHA()
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

				private sealed class DsUcoievEEDcNQurRZitEDHPIhqx : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ehocwHOBhQcynJuZclZqcbjKQXnQ;

					private ControllerPollingInfo eqSiLePNaCkJpHdgDIpXcOdyvkSrA;

					private int fnaDmBqjLBhAJrOhZEDmqKcrkXjo;

					private IList<Joystick> TSDToaYAizGTHRDAWljOFyrKQQcQ;

					private int cAExIgkrOHSHtRMrxDHpdMGDJnbiA;

					private IEnumerator<ControllerPollingInfo> mipigBrCfwyWDJRAzgDftmoqtSQk;

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
					public DsUcoievEEDcNQurRZitEDHPIhqx(int P_0)
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

					private void bXFjorrIjEKxRZDQgceEiasdbUZKA()
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

				private sealed class qCSEDUKzTGqIiBtNGmXRpALJLknG : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int uYMzfDnPNHigKpkrVyNMmVGlNZyN;

					private ControllerPollingInfo uswCSHpxXuLuBdYELqlQEqvwLRZN;

					private int UDCFdeVvnaCdNVbHHgeWiHYjIzheA;

					private IList<Joystick> CscDOryFhxAYfCLrsiZvTgvuUhrv;

					private int qUzQJLyTcwKvPIswJlAskUPzvLho;

					private IEnumerator<ControllerPollingInfo> njdYtSRlmdDkFboHMNzCFNvAywLIb;

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
					public qCSEDUKzTGqIiBtNGmXRpALJLknG(int P_0)
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

					private void xaLkEaolaQJOXQnZNPFiNvrbfcTO()
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

				private sealed class AQOeFtEfJmBKsRLJVfgRYDIoHYTnA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int HddlVBfZwFmQCawRZmroYhzjjUCl;

					private ControllerPollingInfo PNtEIuIzHxlquZBOCbkIgprkyLCUA;

					private int pAMvaEZHDLaWRuwWGSegFnwDgIGt;

					private IList<Joystick> flIVtQkqouXDepKpLMuyipmQYFuH;

					private int VtXCjqFNGaCJocvjrBRpwPAWfmHX;

					private IEnumerator<ControllerPollingInfo> nFLrHlOtmZbuIjJtRjeTcIAmegaj;

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
					public AQOeFtEfJmBKsRLJVfgRYDIoHYTnA(int P_0)
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

					private void dUYOxQItKKJiaqOcJtIMuRquLiAX()
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

				private sealed class MaDcytLUIQIqYQdpmiGgHdutfsGE : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int TjMgrSIHhycUhEygWdjvhVzMOovn;

					private ControllerPollingInfo ATtkUSPApUXltrnZlGLwraQwsRLH;

					private int BRGygUqpxaVpsgdNqJdXnrRhPMey;

					private IList<Joystick> UkJPcngXRHQSGhitrvFCUmWnIwMJ;

					private int YQjYruxYVUqVEnOOmlakbPyextXr;

					private IEnumerator<ControllerPollingInfo> ijTBqVVeDzKbcToRMmEGLcOGjGefA;

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
					public MaDcytLUIQIqYQdpmiGgHdutfsGE(int P_0)
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

					private void iyXZROLLWIDMHKkIuIOiIcBvcRvQA()
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

				private static PollingHelper uycThavfcLSNVlHEJLhpSTxFchat;

				internal static PollingHelper lNSgwWgfjIjIYHBMJCfEpNjStetc => null;

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

				[IteratorStateMachine(typeof(nqVtCBfnsGptzpKyuUnoydZtwUgi))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					return null;
				}

				[IteratorStateMachine(typeof(FQCQHRxVhzLBSPMOIfsmTIOvUmnO))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					return null;
				}

				[IteratorStateMachine(typeof(sWrTCjsvbWWKrPLutmPECWAkJKeQ))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					return null;
				}

				[IteratorStateMachine(typeof(uOWzurgODDBtuUNMzNeZkLJhsWtN))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					return null;
				}

				[IteratorStateMachine(typeof(SlSpNoVwqJdtCtKDuhoZUNifcfRw))]
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

				private ControllerPollingInfo ZbalqzMnlkaqKTFjJFHJKzhFhJDn()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo xRrelilANKkqAUdcQUfoopJeaIcfA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo WcGIUEticVNdqcpygXdiQVvjLDMA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo ppfpVLgQdoAnmeJsICEXPKjVCHWO()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo ctdyOlGXTeDkbzcMRZqYPqqELBYt()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo RJBsBnNnQgRmIZQBXfryNAjwSYsp(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo IRCnnnZrBZRDxXKjkffIbUhJCLVyA(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo xldgQSJRkOgxgtxlahJrDQhdhHxi(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo DodwardXCSUfaeCwcNgpGSiOkBau(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo PBftwdIULTUOqwNIadHiHyYgvZqcA(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo lXWxBSIvuHEuKAhEJBbiyllwKRUv()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo PiJIYytuWgLVDeTvsifTnWEuijvX()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo vdBmjdsakpVTNdcHkbZINgrwPeVA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo vejbfjeaQjDnopVObqkfVHsNgneWA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo IblkfbAEDuwgTJqeYvHEDCbGyZwL()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo bqmvBNfwmxdnOXsDpehFmsUwmFoh()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo RGiBjVEVgkBdoVzqDkEtGAUjDGfVA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo aABjreQBSuWATGYBwgzKQYHGTiXm()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo shzXNSjJOZjQKGdkgktcKBktSLso()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo daNJitgmPbEyxEvcvfFDmsqPSnbCA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo JsozJSDNbUtDzIuAqDLgnYsbSTWO()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo fpLQPPvrwhAlAeKgIoSaJOwZdDJjA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo meLSsUcXtPMnKdPRLyiFiKTWjrOe(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo islRaqyMiSjkWtNIKxGPbWMTiocQ(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo WprIkpaODDrBzXCJbdsCCYLGnIke(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo CtkgkhZglZPNJZmKDnktYjTGGrQz(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo XtYFqmgjyOcaaNFuMQuQqaHOJXbB(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				[IteratorStateMachine(typeof(AQOeFtEfJmBKsRLJVfgRYDIoHYTnA))]
				private IEnumerable<ControllerPollingInfo> dqJDCHhyyFzoQCcjWEfoAEvlXcyw()
				{
					return null;
				}

				[IteratorStateMachine(typeof(MaDcytLUIQIqYQdpmiGgHdutfsGE))]
				private IEnumerable<ControllerPollingInfo> xdbfDSUuExQSVEJEldCMCvMAeDPbb()
				{
					return null;
				}

				[IteratorStateMachine(typeof(DsUcoievEEDcNQurRZitEDHPIhqx))]
				private IEnumerable<ControllerPollingInfo> eqqFbRpdpZhGebvkdPgIfGEkQOPv()
				{
					return null;
				}

				[IteratorStateMachine(typeof(qCSEDUKzTGqIiBtNGmXRpALJLknG))]
				private IEnumerable<ControllerPollingInfo> hACLPldKrQMCSxizmzfsUZEqDBCT()
				{
					return null;
				}

				[IteratorStateMachine(typeof(bWmXvDGUMiQUFXbbNxhJhZDpiQvp))]
				private IEnumerable<ControllerPollingInfo> EJnkKZICEIHWEZQZnwdfTcquVOKJ()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> PQsufnaMBIMVSrywfISFwaBEuidb(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> bsfTepvqHjfMeApBszukrSrBUDLrA(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> DMMXAIhsVWPHqNZWxLDpIyKMuMSV(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> NnNdpWESlFjVOAkXnZjqqlHCnduWA(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> TIPTluOxDTNwxjLsbfoVXBTXCbLY(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> ZXDOwOvQRcrUbrMhMExVggkBcOFX()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> gzafIWpptaoXzxIXYMCpHwRbFebG()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> DXXmVfBSPkcyyWNTkoKaUbpkNJpH()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> RrViCwtflOZKLWgfJBaXIgkxDfQrA()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> dnLDehBsvogcCAZAGnpqHVzhtqbgB()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> LKWZVShFAzTgTZblAlUCUZYpTyil()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> CcoEbnznEiblmmcoEmtSouqGkvWi()
				{
					return null;
				}

				[IteratorStateMachine(typeof(FUarClvkzUEYNReknYXeKCmkbedJA))]
				private IEnumerable<ControllerPollingInfo> RMrqDdxgXvfvoPVKbbuLyRbfMijp()
				{
					return null;
				}

				[IteratorStateMachine(typeof(pAyknxkkuCnsqiuzlrTlHqfUZubK))]
				private IEnumerable<ControllerPollingInfo> ZTqewjDAKeOrbzZapLQogbkxuRGm()
				{
					return null;
				}

				[IteratorStateMachine(typeof(lkIWIgPgwEIGMuYvwfRelwQTolXP))]
				private IEnumerable<ControllerPollingInfo> iuViFplomLjveigOGnClUlCzfhNjb()
				{
					return null;
				}

				[IteratorStateMachine(typeof(mvdswMvzxbRElwyhyNaCLReFWLbB))]
				private IEnumerable<ControllerPollingInfo> mljoqeyRznqMTWbnchcMIakGojAUA()
				{
					return null;
				}

				[IteratorStateMachine(typeof(DIZQshBLQpsdERWWAnHPOqEjDSIj))]
				private IEnumerable<ControllerPollingInfo> UCGVNIzSlqcnRcDztgZAiFVLVdFr()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> vIvVvmwzyYuYxdqeHfvrPHkIFoVm(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> OrvGGsYkZJLWqENUCIABzfKWnpLq(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> ZaRmHzGlqcExIaBAQLPcFUQcOwspb(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> FACrcFbRAHCyKbkMWjXiSHnUygucA(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> MdXkNegqhdRXSniKiZoxmBATiegM(int P_0)
				{
					return null;
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class xjDiHybSfWEzjPUddXxKYDUxsIHC : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int tfmWVbHBIDEgQgLXGybKSToQaidgb;

					private ElementAssignmentConflictInfo BqbGLiDYLXiRIejpqdnKeOLECCLiB;

					private int xENqGeBTeKGKniKzvoqvkwfEkGah;

					private int vcFcpBbpqkmCEBKsHewxKYYZbARbc;

					public int fuhPTKkjNNYjZTQLOKnaILxmbYyhA;

					private ActionElementMap gAvdpEiptBqmtchUWPxosGemkJrib;

					public ActionElementMap ISSKEhjdsXdIhiEmeKsqxLTUIbmdb;

					private bool JDnIJaGlqusEqpoBRtKcwezxeZrWA;

					public bool prdjPFprgKHGdmAUxGcteobEHPov;

					private int MartmFxFWZuamxheYIvtDSMDPKvw;

					public int SscdLIRGRpLwTUnvAaRYxVZVLUMG;

					private CustomControllerMap LUdiNiGrwKneSjHIJjyMyxVtgNPiA;

					public CustomControllerMap wJCkhPzMKSaiTvTdaQjATTlEYQvj;

					private bool alaHCAAFIGDReHpHcrUwKiKiCiUpA;

					public bool pWlhCfDqgFtrZBYotDkfzLktgikC;

					private bool vPnFWMBflJWuhdTQAFcVsuSDVeHkA;

					public bool OBAPqZIoNWikGXsPmCsDHcQNGmJlA;

					private IList<Player> vfVKdYdHWkWfCYrDaXgwSxVWPUQ;

					private int XViiheOtPEpFraTOkMUAXdirBXMS;

					private IEnumerator<ElementAssignmentConflictInfo> YQBFPQGBrwQeoQJvoZXTNdgKBiIo;

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
					public xjDiHybSfWEzjPUddXxKYDUxsIHC(int P_0)
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

					private void oLmmkDbfkZHEidnUMcYTGGrIuwxp()
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

				private sealed class QUtCyuMJGfQxqmYNuvXbYbhPktnB : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int pLVFnMPNUEyAZvSMeguVfOzNBBzv;

					private ElementAssignmentConflictInfo nrxTMWLoTcHnGPQhyMyYjpYSAHJU;

					private int MgLAQyZiEljdbTPWnYhWXtIRQNnC;

					private ElementAssignmentConflictCheck gtTxZsHyOCgoNbndrCIuNwHEYusj;

					public ElementAssignmentConflictCheck WSuQXebxOfsIBTJbLfNbkvtcocTw;

					private bool JgsxkaCzrFkrMFAmqHLZBPRSmXmdA;

					public bool gzWMbjitKCqSdXHtIqNNzxYZtBXQ;

					private bool bIRwGZRquAgPiGHWuCEOViOoseiBA;

					public bool fdMKQdqGIVshGnaloQcEwlkGGSsS;

					private bool ziyHZXruPopKFzRGROXoATKrCkDV;

					public bool rmUVmoJlNmqEodFWsFRJyPQMrtrI;

					private IList<Player> MBCGwHEsMINRWfrmVAvDqcXOQRDRA;

					private int RzAmjbdJfueIdasUgMRBoVfGdWjpA;

					private IEnumerator<ElementAssignmentConflictInfo> UZZFOJzdBvCfEOStPOWUplbOTGOV;

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
					public QUtCyuMJGfQxqmYNuvXbYbhPktnB(int P_0)
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

					private void tmGodiNKohAsKZhBDwNheyvPZhtj()
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

				private sealed class eSXxbggxUGfpwFkvYCpTiEqzRyGY : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int ZtfpviobcpmAvmaTDFrFFEwyGIOSA;

					private ElementAssignmentConflictInfo zQOCILAPZVGEZedjAodLslJygnoBb;

					private int yEfmGMeeljRnYTvuiHZUlSQieCpN;

					private int rqHIUujpaRrmNiqmDfkcZOoyjFrZ;

					public int VtichMHwmkoGBezEosRjtSkoqYTf;

					private ActionElementMap qInQINKaJNSwCBZzvQdCGbOqtIWG;

					public ActionElementMap IgqXCvxlByAqNJQSFfjuZqaBrDPW;

					private bool tLZuUxTcdbnpDeGdSXEnIUlTgRJL;

					public bool LzaFTMwDrsyturPRNdVOBVGLdgG;

					private int PxMtMFWYOVNMmIZqNvaoTGqDuYwB;

					public int RlgksBQDPGDIgbXWDEcSOMXWisJr;

					private JoystickMap nhihMKdtgEtwXJqsfIJvVvjlarsO;

					public JoystickMap KvewaZsmXUDElZlAlCgvEesrLEpD;

					private bool YjwOHmDvMNlRloaslHszrCbVdtaP;

					public bool VbjwUmGPdALRhNAdfYqKzMJgVaCF;

					private bool ZmfAlRoeTDJRTRwUFzJQMGuBIpyd;

					public bool OrUvJEGGBauxSDbEMXFHHQDwgBZg;

					private IList<Player> AgNhFMjFNlfWgcItBFAtbfnpcINZ;

					private int EfpEhkySsHgmusJPopMXTNgfhkKj;

					private IEnumerator<ElementAssignmentConflictInfo> HKaDkteSKPyNZbtjSBakcZIJHbepA;

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
					public eSXxbggxUGfpwFkvYCpTiEqzRyGY(int P_0)
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

					private void CDpegQgvnLrsPRlqCjpaXLkOcwabb()
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

				private sealed class VYxEvDraCzGUMNJrlSLaYciHwxUN : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int ZtCUhpMnbZhjEPfhzRnwzDcxhvV;

					private ElementAssignmentConflictInfo HgjplUFUaIwqHjKHfcyLBgNNGCkMA;

					private int PPUhBklEWSvTSkoUDmKPHIrvtuaS;

					private ElementAssignmentConflictCheck jtBoWfLMxkijSILUzrzHamYwRyxp;

					public ElementAssignmentConflictCheck JWzzujdVnxIfSGfumrRVjmnpxLXS;

					private bool PNWVRiucfmWRMqEiEjeYPfjdKkPy;

					public bool zGgWgitLOOiLQvQfhijwlJSICqPD;

					private bool AmEbuJBWXOrOcsnhfgNnqXqwKUgK;

					public bool LNlLkmOKUnaIDgHZAaZGGojbEftlB;

					private bool YDZGEoNuDviEYFiHzXgptigxFCiEb;

					public bool kDBiZkMZvkdCfiTelphZTydxnfJJ;

					private IList<Player> pnhWsEsKGSMGaWHWYPDvkxvWCrLw;

					private int eLUFIdHyNZATkMljlDuWRrRaUxCo;

					private IEnumerator<ElementAssignmentConflictInfo> ndiqNHQcmFuySRtnKdrmLgmRdixH;

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
					public VYxEvDraCzGUMNJrlSLaYciHwxUN(int P_0)
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

					private void UNmbztkDglJCwpbSKbQYuCJbKZir()
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

				private sealed class YzrPokAqVzsRVlCfinCtluPvIZJd : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int hofTvKSmMgqMHsgSzeoFbKaQlVujA;

					private ElementAssignmentConflictInfo kuQPpTChAFzDZFQCtWqqlpJXjabJA;

					private int ULxeNSjhmqhplwiuvBYsfxUSlPqmA;

					private int dkCAtiyncrusPBhpwfagAFalVglg;

					public int BZavrXaoGVMkCeIXEFJrjgGBvRfeA;

					private ActionElementMap xQkclJGqXDDJTpkjEldHGQWEQgSdc;

					public ActionElementMap qPQNMquQZxAsEHaUclGjlIPMfuFi;

					private bool MbBsITvxLsedHLoPvlmfZmyebxEo;

					public bool siaYPOCrAkvUwclaHxMlpMtEviLw;

					private KeyboardMap caYmLJclcjmFphSJsXnLLUsOnjod;

					public KeyboardMap CUfTCLgtoeRKbxzLtSwfprXMPRYU;

					private bool LBKrQhrcLTzOcYJrWUjfRBcKsXed;

					public bool FRkfJEhKKkFlWVBxKmoGtnvgLavm;

					private bool wShTwtgIKEwqXdbqqOGgAGweHoIr;

					public bool XwFOZtaGjeVmBMvlZDVGyzpDdjfp;

					private IList<Player> ZIMqBGUfvInKMsMFwBWPRZMcodhe;

					private int bfYUVcnOmDbIljoLGmHZbdzEnuAMc;

					private IEnumerator<ElementAssignmentConflictInfo> UTVAWmcOpTJuHKgqfDyTpfcfddzh;

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
					public YzrPokAqVzsRVlCfinCtluPvIZJd(int P_0)
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

					private void kHVCNgJdHESbavrHTWEgAPxJPLiRA()
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

				private sealed class tUQKQGtIWShrfWkbsRuKMLSmgbIx : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int fQKjfTAaJmgHMAAKyXgeMzAtCoyJ;

					private ElementAssignmentConflictInfo bsedWVhoOPJZCOKzLaMqHYQccRYiB;

					private int LfVFbZyYYGpmLaMVdPgVwqHDbtqG;

					private ElementAssignmentConflictCheck OZSdrogzncRSReLDvTgXPNkYNpKT;

					public ElementAssignmentConflictCheck mLNJwmnCDjqwMkSQuJPvGwlLKGuU;

					private bool xWSJGqVpfolTwckhSslHnPERABHKA;

					public bool mhKWiKIDOTESeeBoGaolkOMylpgrA;

					private bool iXStQHBlJpgIvcffrLdIBgrFfUrgB;

					public bool irudMydzRUzfXuFKflMDOZHYfwlfb;

					private bool rTnDSgBewAifGCSHvMmyUYNPpRgWA;

					public bool CkpdbvYkUSZtFOBYnvkEfbjMBEoU;

					private IList<Player> SuFUciIVnjDUhoQZsHLVpJJxmbvd;

					private int hRFjWijNHvOKyAudXvPKFTFJmywK;

					private IEnumerator<ElementAssignmentConflictInfo> LdodfCMmvxaCGKtgPlXZigvaDZrB;

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
					public tUQKQGtIWShrfWkbsRuKMLSmgbIx(int P_0)
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

					private void eTQgNgMSTNjuxrGTZrQOymIHhFOJ()
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

				private sealed class gIEzrUKKNndPzBNDdkBoskJLeJlT : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int POooALHyTnqrNoYKHGHYiDuqOMyN;

					private ElementAssignmentConflictInfo mevJgInQizIGIUQNdczhcbvXZGhT;

					private int wmcsOLHdiyLPmYXUbzDcMWqPagfE;

					private int QkgxtEBrPIPGTawTIgzSwBbgXyZF;

					public int cDoacFJRCTxuUTPuUMZHKNiaPRCX;

					private ActionElementMap TFBOVMCGwHoliyfpYiQxIGQMORtm;

					public ActionElementMap BcbVgTtfBjEKcTrqKTFxNOJIopsW;

					private bool hqwjWmCPGbwsnuItecamYoYXTOge;

					public bool neJEnEfFFkSWOggDECefjIDVWlGAb;

					private MouseMap qLntfuQVIudjLQueIIJZcZCOQQwT;

					public MouseMap BVVZkIxDEgSXfTeFxpvcnGYdkkaT;

					private bool eHTbmIpCrjQGMmTCzrLhdyPOIVyU;

					public bool yjZHTKuLYFtkNDcqWOWVzDbdZllo;

					private bool pKMnXTAQuShawSLUeBzxPqUAaNZE;

					public bool KXzxCBzSoVKOMgccmXLXPvceesxy;

					private IList<Player> ytplrveaBHKtRIOMwiWogXEsoFQJA;

					private int GmcZtQlojagOyTgjmHqiVoOJPNDK;

					private IEnumerator<ElementAssignmentConflictInfo> LaQPwEdEnxWdzGihyNtewctxUkMD;

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
					public gIEzrUKKNndPzBNDdkBoskJLeJlT(int P_0)
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

					private void XJbjBjUDucXAWpDYmqgiidMYRBOV()
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

				private sealed class XvmBmVjmbHwlahaJjIaiqnYewIAgA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int PwOzhsSGgjcVdkBDYgzibOXAQrcBA;

					private ElementAssignmentConflictInfo PPZFNdgloGKRSOJRmqpjLKmpiZxK;

					private int ViscuwAfkhASUgIZdEDcRCQPgwKeA;

					private ElementAssignmentConflictCheck yAmUYDRcFfNNCmlSmSyEFfwuITZi;

					public ElementAssignmentConflictCheck xXXUyBcdDOjvgZsmvcmlVkGMHBBP;

					private bool dPKBvBLzxqbiKyIRsfcwSdNAsrYl;

					public bool TwDbMYRkLZNtefSHvKTfxXDaoBnS;

					private bool fwTgjZXLleFjXzCZvDTOGPyEayVdA;

					public bool zBielbezSUaaKwDTIQXJdHBEvyhV;

					private bool JxEoHEgbGzFxuoxkvFUrGfQZNOQw;

					public bool ROliDrXfixrtiSQRqkwaNnYVAisB;

					private IList<Player> EaWbwXBiNCnnKqTuaJgIlsvEjYbhA;

					private int dVUWymJfKHtlnLaSxiVnTiNcmCyE;

					private IEnumerator<ElementAssignmentConflictInfo> SnQoUiRqjtiRWvVFJOGXaVpaDZyB;

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
					public XvmBmVjmbHwlahaJjIaiqnYewIAgA(int P_0)
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

					private void WzAolveRpZHDgMCvSEmVcYGongAQA()
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

				private static ConflictCheckingHelper FRfwZmyXYjFyAICMwnDhyOztEcMp;

				internal static ConflictCheckingHelper DuPuCnuoIHPLIJQMbHHmkhcAmiWp => null;

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

				private bool UScwatMcUaBVybnikHyfsUwcGOqq(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return false;
				}

				private bool jSkVmeCjAqjQsCRBBeirVpPfFJYfb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool QrfpdDxyymFifIdsOjHMXsywQFYA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return false;
				}

				private bool OLJbCkVIrdzWhZfRZeHpnsXUURaS(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool HEVNNoeqidSGCFJzWcbLwsnFRPof(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return false;
				}

				private bool FfmaZdnAsjpTwIvosGzZCGOIfUTx(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool lBIYggULVmuEzhppPSVtwtayPFOg(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return false;
				}

				private bool BFatfRqvuhkBFLaAtxjmhXBLUujm(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				[IteratorStateMachine(typeof(eSXxbggxUGfpwFkvYCpTiEqzRyGY))]
				private IEnumerable<ElementAssignmentConflictInfo> huQyKOBvhwCLGwyKLCkNLJiYYZN(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(VYxEvDraCzGUMNJrlSLaYciHwxUN))]
				private IEnumerable<ElementAssignmentConflictInfo> yyOsjMBdiuhQSSxKSrNVzxutLntQ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(YzrPokAqVzsRVlCfinCtluPvIZJd))]
				private IEnumerable<ElementAssignmentConflictInfo> DxVarHZgQIhVaYVPhdyiTjLsqcjW(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(tUQKQGtIWShrfWkbsRuKMLSmgbIx))]
				private IEnumerable<ElementAssignmentConflictInfo> EXXyMjeASvfCjljgojgEPEYjTnIt(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(gIEzrUKKNndPzBNDdkBoskJLeJlT))]
				private IEnumerable<ElementAssignmentConflictInfo> rKwetgHNJwLZVQsOQcGOSCDscZNnA(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(XvmBmVjmbHwlahaJjIaiqnYewIAgA))]
				private IEnumerable<ElementAssignmentConflictInfo> FgAizPwQrwmAJTdkWUMRhSrEhrtJ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(xjDiHybSfWEzjPUddXxKYDUxsIHC))]
				private IEnumerable<ElementAssignmentConflictInfo> YXUzxbhGScNFZHNjdmMHyXEABElO(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(QUtCyuMJGfQxqmYNuvXbYbhPktnB))]
				private IEnumerable<ElementAssignmentConflictInfo> ZYvOpTWGzfmFzBBceGCBXEHRXOVC(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				private int moGOoJElXZBTlmXXkfMFFQZdduhMA(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int NkqrCSaGOLOpkdXzaEQIwtyziTNA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int mvJPXcEtjErFsAhFhsyaidsyABQD(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int tAJyKEvflZcvUbYZqfdnKryOHxHxA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int ApezdZtffqgyiOnEEaAyRZVrSgXl(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int sSnJWtbBKnTYWwwSFxWpKauSXFTk(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int JwDwQPbCkWCLXgrubFgJRmjLWhlI(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int wAiaAMFAMsnRvhnibiaNkeiVVypG(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				private int fNjQaUsaZdVbwhWgbqICGshugGQP(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int VbQsIGzjmYRrgPuTXCkSAZTmoZbc(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int KCqEHPFAKnqHYFUMHZrBPIRnwyQn(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int sVCIDVHbmjBdXODtBjAQejjzEwRBA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int mjcCykELSaxZSJtiwBdQjBwjdhqqc(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int WPfdkfazxozGZdkEqLswzkAMRheG(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int SDNuupNdNaBrtSKqYEuWmjSGorXy(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int NNQpLyRiTAymWcQEqSNihJjaTZqA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}
			}

			private static ControllerHelper yepQsTSAGCouYmdWaZujRDWmqzeU;

			public readonly PollingHelper polling;

			public readonly ConflictCheckingHelper conflictChecking;

			internal static ControllerHelper EyLxuJgyUntPEmJHLKfpBTvBavPb => null;

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
			private static MappingHelper EkzQCEqRluERpOhzeHhiSMRtdaRd;

			internal static MappingHelper VqYsfQFEkIgEwgOKkQQSXgeKFdNAA => null;

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

			internal InputBehavior JERDmxmjXTZcYmQpopFiMELrnhYp(int P_0)
			{
				return null;
			}

			internal InputBehavior CDWDVaBbVianLEBBnCqqRATNygcOA(string P_0)
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

			private ControllerElementIdentifier dBxcJIDnoMNAidCOBVsoFZIkNAeVB(Guid P_0, int P_1)
			{
				return null;
			}

			internal int RhkeUOeywqPswCCGBjjAPhWuxqGb(Guid P_0, Guid P_1, int P_2, List<HardwareControllerTemplateMap.ovLXoyvOyAIvHyJVxtrGqFYCplsV> P_3)
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
			private static PlayerHelper iAvFhQWibugMoCvyuKJvthkJeoRDA;

			internal static PlayerHelper cxIiVayiAALCnbqQeAGYqSFrHDNEA => null;

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
			private static TimeHelper XGuAbUgoIKmusInpsmVSLiVVffjpA;

			internal static TimeHelper bASOhdDdgmnTqTdSQWuLtdBwOHCy => null;

			public float unscaledDeltaTime => 0f;

			public double unscaledTime => 0.0;

			public uint currentFrame => 0u;

			private TimeHelper()
			{
			}
		}

		private class ObAiMlISWHwckOMLHDGREerXMJiuA
		{
			private class JHryuVbtIXDZNlBRuidWEzSWNuS
			{
				public readonly UpdateLoopType MwimZkOIGOjaosVaHMPSeXYnKuje;

				private double JThnVZGmiODAvPELOfRHjzwNtGJZ;

				private double FCfwtFDZBSNAlpHREOwMNXWKwwAH;

				private double YiLzvISfsxHltLTaNdwlmIYozZqH;

				private double BIsFPuDCIQuHVWcbtpzLBskAckZZb;

				private uint RuwlluPQeWdeFnsggqaMfSLlhSqH;

				private uint aaDMkLxXsJUPyKImakhCJwBAWoPB;

				private float pTVeGUcICnWGbTzhGZFDiATDAdIc;

				private float iHsTFldwYaEjJKGDDdjyCZOqlLIh;

				public double VmszuygEVGGDYdNOtVBQPdKqdbMkA => 0.0;

				public double XVKVjCknXNpvIVfhcwjhIETPWCzn => 0.0;

				public double usDiYZXSZakrxGrFGczMgbXnxcVD => 0.0;

				public uint ZgrcfgsCUFZcJDCaoVlpAvceDanu => 0u;

				public uint pXoWGRUxxrJFRWoNUUHIkSMPgCHi => 0u;

				public float rBvGdQZtTQuUXvennRrQBfHOdBMfA => 0f;

				public float TBkrKYioezaKkzHAAJInizqhpSUpA => 0f;

				public JHryuVbtIXDZNlBRuidWEzSWNuS(UpdateLoopType P_0)
				{
				}

				public void lYzTeOEdMipoIzugizBiwXkyBxjF()
				{
				}
			}

			private static class sNUmZtOAjKntENjtFfnnTsbXXODw
			{
				public static StopwatchBase ulMoARLPxCakvxLEYbhomAomIICn => null;

				public static StopwatchBase dgtnUMnVHeqptjaBnEAtFjKxENNJA()
				{
					return null;
				}

				public static StopwatchBase uzIVQCodLkeOQIiBTiHTOjbtevxeb()
				{
					return null;
				}
			}

			private StopwatchBase SAMnyddsrOJnKEuoDSsUAanHmsOt;

			private double kxugskEfvLDqSpHJDYqUNrASvcZiA;

			private JHryuVbtIXDZNlBRuidWEzSWNuS UXNFQQcJDRNnbLmMgxqxibrLDsIp;

			private ADictionary<int, JHryuVbtIXDZNlBRuidWEzSWNuS> tUBgEbOIhGNCJmBfmpgxBGqbytvC;

			private uint NOTRwBozLrjGJAnadJVjusByccYT;

			public double WmNpvWQrYjAECoHCBKJgDeCRAzobA => 0.0;

			public double WrCUkdvLLJFlkieDLVxwXFLaHlj => 0.0;

			public double LAMPQvVdOdorRpjXUrUEUpvnaLfbA => 0.0;

			public float KVtGitDJtPIDlktzCcPnguOyfNNS => 0f;

			public float NhBkczLIehlkVmHOqbmXHFJIrVsNA => 0f;

			internal double KkcaCjwNFwXBlUMlCmjcFwqLgNaX => 0.0;

			public uint LTWPkVFJUqNIlFVzngMkIFsKAcUO => 0u;

			public uint LgxAzdKkAkRegymSWtFkIjfPzqnC => 0u;

			public uint fVcffBUAxfcueeCUAQAyZkYOSPmpA => 0u;

			public void vPSicIubhdqeWXoLsyRrwyOSwHd()
			{
			}

			public void woTrqsreBxBnsdTxcJakpucBSTZGb()
			{
			}

			public void kVsDjmKhNbQIjDeuhsdhfOlcEobkC(UpdateLoopType P_0)
			{
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch qUZUcZdKUmBqRsOsSYTVmEkooXSj;

			internal static UnityTouch GngqCadyvdKWDgZjXDXyTWPeQtmX => null;

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

		internal class zTFKKBYaVEeiJaeeczzBWrSnNCT
		{
			[Serializable]
			private sealed class yXNVYYxdxiZkfMfEDgrOGtGtFLgrA
			{
				public static readonly yXNVYYxdxiZkfMfEDgrOGtGtFLgrA _003C_003E9;

				public static Func<bool> _003C_003E9__12_1;

				public static Func<bool> _003C_003E9__12_2;

				public static Func<int> _003C_003E9__12_3;

				public static Func<float> _003C_003E9__12_4;

				public static Func<bool> _003C_003E9__12_5;

				public static Func<string> _003C_003E9__12_0;

				internal bool iGdPyhdMQlhWvJtzwADFAuAmpgib()
				{
					return false;
				}

				internal bool DJdQkfMvHYUJxGjBcpgQikZUJZys()
				{
					return false;
				}

				internal int ywzXKMnqipuckQfPMglKBPIXaPaN()
				{
					return 0;
				}

				internal float eVEFUHhliIbcZlvjwhPiVnaldTrQA()
				{
					return 0f;
				}

				internal bool vVPfqEQvJVerwaQNuhjOryvmMZnhA()
				{
					return false;
				}

				internal string IVDgxuSMGyqUYWSLwnmYKzkpmQnr()
				{
					return null;
				}
			}

			public readonly ValueWatcher<bool> awgGPyKVJGmFmyMkfNyZUJGiMbjK;

			public readonly ValueWatcher<bool> iWKGRkLGQBbbogHwESOOqKfBjBdDA;

			public readonly ValueWatcher<bool> QmSKQSvPntDjGRSlhhWRMoueDjqs;

			public readonly ValueWatcher<bool> wVDLLqIbMDHZaJCZnzXbBILjwTvR;

			public readonly ValueWatcher<int> qbDHgQOrirNsGZxfYNMTXZJSrJiU;

			public readonly ValueWatcher<float> VtqhWndnyxNVJELEtEpjEuXkIJNab;

			public readonly ValueWatcher<string> DdjoDkvgfpqLSCpeBGCzJoWqiBcNA;

			public readonly ValueWatcher<bool> IXIbwAFVTjYdmpmtyzoggovcWBQl;

			private int xMCvaBqsaxbqajsyyIUBasIbuaSpb;

			private readonly ValueWatcher[] OCBtfPQRgHsnhynPxFFbGRtXGHGL;

			public int KtJDODdEKcclscNWjTCrMLaIEovPB => 0;

			public void usUhyGfMbLwoPIHzlTXfAAZJfBIk()
			{
			}

			public void DkZrYwCVatrUlLVTFfbJEvJoECYF()
			{
			}
		}

		[Serializable]
		private sealed class PJDYUOszZjqZwFbOfBkBfzRJGDOPA
		{
			public static readonly PJDYUOszZjqZwFbOfBkBfzRJGDOPA _003C_003E9;

			public static Func<bool> _003C_003E9__235_0;

			internal void hLRxkrXcnlCXGnTyRotNVHlgsyfq(Exception P_0)
			{
			}

			internal void twgxxXUOMusHDrpUXSTfQYVvHLlB(Exception P_0)
			{
			}

			internal void YlYYchmldynRRXmblTNZwuWyAnNH(Exception P_0)
			{
			}

			internal void uVgynewONsAGZAbduBNIvUTTagWf(Exception P_0)
			{
			}

			internal void XBUDujiyPChTsbVAOgyulNwfExsB(Exception P_0)
			{
			}

			internal void fTuKJnoCgFvVdLKAnbAdidaxKfPzA(Exception P_0)
			{
			}

			internal void URBWRxHkpJLPBszMZfomKFnrghnkA(Exception P_0)
			{
			}

			internal void UrGzvprCfqherfJeQnfjrogRDsCn(Exception P_0)
			{
			}

			internal void eleaVRcRMWoDEBHOMtQNCJJelRJUB(Exception P_0)
			{
			}

			internal bool zTUfbtBDLeBBHqaPaHdvFmhxHKHbb()
			{
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal const int programVersion1 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion2 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion3 = 59;

		[CustomObfuscation(rename = false)]
		internal const int programVersion4 = 0;

		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U6000";

		private static InputManager_Base nTgvXYFPzomGRpaiQbZRXhYwLMAf;

		private static PlatformInputManager cMbGYfgcXpZcVeWLLwrCPlgsDUNx;

		internal static IsRfGTyTEbMSFXGhXufpYZyPCKjB lQrqwhCfIfIgktHXoHKYyChngzyX;

		internal static GCkLfqNtcKbVwGxJyqaDoIgNIHaV YNZnkUUWdETsfnFwfyPUjVPxExCq;

		internal static qolSwVLcvXSMneGdcvjdFoTKDPcf BIeoRJtgpppJNOjultHrXTwltUhx;

		private static ControllerDataFiles WqqeZZGjXiwIahHYdDlDUFCDdyOiA;

		private static UserData xXNYybZYVXuCDBsfcGvDXJSXkuEl;

		private static bool hmFBGJpiuHNJVzQVWoNBgmpvGwLeA;

		private static ConfigVars HrUAQRgNyFTeOOnpzcHqEyFohaaP;

		private static UpdateLoopType iMFRVtmHVaJKZehGUKMBGOIIPUJ;

		private static bool XLNDDcaMaxOAKOmtpXwruqtrrEuEA;

		private static Platform FNXMLniCQqYMnNWenRaYOYgKoLUI;

		private static WebplayerPlatform wBjsroTdNCjCbqrzhFnSDhOHkhqb;

		private static EditorPlatform SnObwxrmQrFucHJbHtgfxcFfsgVbA;

		private static bool QQcdhVjggExuEfUgSydpPekaUKiaA;

		private static TimerAbs jhnjKEbfCpJxxLAWZtuhfkeOtrku;

		private static ObAiMlISWHwckOMLHDGREerXMJiuA iMAGamCsRNlowcOTxDCXztCIoxHzA;

		private static string LwLIKZdHRZiruWRlQkolIApbYBMn;

		private static bool VacLzjeOOJvdKkIuZNoAsPPKGmif;

		private static bool mBgFOoUewbZBNCLISAcDHKeWxsLpA;

		private static bool gxLRtCRiZsBFzmAfSpUVBNqATCtl;

		private static int xLhczqpjKVXIbHKZNIidFVGOHnDT;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int LMrzFnfFwZLuKvgNDxviTqotVQIX;

		private static int gBoQHAgxjzDmnCSeUrZbIURQqWUI;

		private static bool xRfDundGKGRYyvPloUJWLwKKVQpe;

		private static readonly UnityTouch VydbENfssECMYHpsSLUZvPaIpXhCb;

		private static readonly PlayerHelper GzWGvVBcihwkqJAlAoRUfDQcmtbsb;

		private static readonly ControllerHelper zlvenbEwqKADKhEtaUfrCUTejBHqb;

		private static readonly MappingHelper EpPZTcCLBifOAikfetgTmzNciEkRA;

		private static readonly TimeHelper CfugBHAdQlSwodDNnKVtNJqZxAbR;

		private static readonly ConfigHelper MvyGIbzzsIhqOpOUkyUJCutAAOOI;

		private static readonly LocalizationHelper iOjBxBcPtlcmlteYnmHLBpITEkIL;

		private static readonly GlyphHelper fUnYoWNbZZQXgqQhJEnWQvVztSQq;

		private static biVSrAHcVRQItzRAZoqLcvJKFnAc riGFHXySMEGPUNiXKVBfZaKZpFdF;

		private static UserDataStore DkqhFjAYixqDReFBGalaZEZZZbyq;

		private static IControllerAssigner QtUfFGUJUlJidLRCnJNWGXcGPpJq;

		private static zTFKKBYaVEeiJaeeczzBWrSnNCT TssdUiFyAapgxHwMFTbxMlJkxkrD;

		private static SafeAction<ControllerStatusChangedEventArgs> FMGFxxbrJtXTQJOIYTHvYvLSigmK;

		private static SafeAction<ControllerStatusChangedEventArgs> gtqRzBkmWwLjMQQRyRYfzCMmLvoH;

		private static SafeAction<ControllerStatusChangedEventArgs> XoogoCmRKSixSVfIWfnZSUBnQByA;

		private static SafeAction QgwrhtqtiKPdlKRqgezNhnjcjFib;

		private static SafeAction yWGyjSKucqHicoLUtjeNFvLezxEh;

		private static SafeAction igsqWtuPboMlIeGaRwDHIXoCmivp;

		private static SafeAction mLqywIosKXHUjRBZnKvUWmUWMYTR;

		private static SafeAction mDAqfVvXNuXgzRIqnbhgDbqTehXK;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationPauseChangedEvent;

		private static Action gHBAPSOldfyHuXvNdIiUeMikImfBA;

		private static Action<UpdateLoopType> gMOqsdEhMGRQoxchOemblOzwUumO;

		private static Action<UpdateLoopType> YPRTsTCnNwvXiCNqjwhhpEfdSPZx;

		private static Action<UpdateLoopType> ndCHRYSYpUhvkRmUOTzAYAIgkjav;

		private static Action EkuAQDzsrBNVpqhQfsNiybQBUoJK;

		private static Action<bool> EtEzUGkcgTXgtAhMmsIakPTSxukK;

		private static Action<bool> rLxXEshqDNrMXJvWmxMwwpQiXxSD;

		private static Action<bool> LmJpSHyNsRCgeoPMyYtaFKkOSKyE;

		private static Action<FullScreenMode> HIlZYYvUrpalYHlWAKXVURqMNXom;

		private static Action WtdBMTHIezYQvkbxHeLvBFmxbNvaA;

		private static Action<bool> kmFgHDcOAVpRdKzeexAMAXPMfpkJA;

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

		private static biVSrAHcVRQItzRAZoqLcvJKFnAc KSgAuiFhzvuGaETjmRAWYUDbeErP => null;

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

		private static bool LBTfbXExVZDhMWzlKRIYHNxXtWUK => false;

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused => false;

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused => false;

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform => false;

		private static bool zuVADykGVcOcubpnipURHknzkJfDA => false;

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

		private static void GdEkrlljUpKePVakKsqBEWOYqouf()
		{
		}

		internal static void ITYVXfWNUvZsqgBWGBmwuEziMFDL(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4, Func<UnityTools.PLjezcBkFGJQfWOkGFiEWPRPdDHUA> P_5, Action<Platform> P_6, Action<InputManager_Base.rmNSveHrOvbaVJVjdcwGabOiRcCeB> P_7)
		{
		}

		internal static void AMdXkHmanjgfeVCMqEbzckEPNxAF()
		{
		}

		internal static void msFBLZCqCBXHhLrSqeceZsenpLKHA(UpdateLoopType P_0)
		{
		}

		private static void YxNoIzPzsyOYXTsuFSPheHYNlftP(UpdateLoopType P_0)
		{
		}

		private static void bVtCqqoLgNehbMPljGcMMlqngjOJA()
		{
		}

		internal static void wRaTeXGcZHEYBNqBWGQxftVeUUbFA(UpdateLoopType P_0)
		{
		}

		internal static void SalZczvFHhxhnRCskmYPUpRyinWp()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static void EditorUpdate()
		{
		}

		internal static void irGsUSXAeSTYWVGMphFsSmZHHAEL()
		{
		}

		internal static void WrdBaqdyjTeTLorpMNdmtFXQcztaA()
		{
		}

		internal static void dVKBDhAmhophYPUjjfFFSpDcBCMYA(bool P_0)
		{
		}

		internal static void ZEDceSIrGxKKKNrCZZjurBLuhodsA(bool P_0)
		{
		}

		internal static void CclSeDWfShQEfWVXjoENaKzLxLWW()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return null;
		}

		internal static HardwareJoystickMap hSqOsssNAbtRpBPgfYBSveZbjBck(Guid P_0)
		{
			return null;
		}

		internal static HardwareJoystickTemplateMap tAGkXVjNFWdkDejSUJuRDGQpkRgL(Guid P_0)
		{
			return null;
		}

		internal static TOvbXCLGpcDMwICKloBsHgxZNTif iVXcdPPjNjXrBRmVJUjdVLfzNocd(Guid P_0)
		{
			return null;
		}

		internal static IHardwareControllerTemplateMap IApIuEftnNVzFlzpQzkhwhWbyQDU(Guid P_0)
		{
			return null;
		}

		internal static IHardwareControllerTemplateMap PsTKSHsnZqJcBurcmvqiUnasOQwi(Guid P_0)
		{
			return null;
		}

		internal static IList<TOvbXCLGpcDMwICKloBsHgxZNTif> OUHXRYZNzefNueQwdNMNXXZgdxrCA(Guid P_0)
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

		internal static void pxSsTwQxyRmtUJZCaBtrCxOIcIqQ()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
		}

		internal static float lAEVusYvRzqnnjmfsgPnJdjNMgfOA()
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

		private static void XUEafcaCVcQePIkbDcVbuMWgCvSAc()
		{
		}

		private static void MuqXARkAlmSouiaxGSAyDQBKdpki()
		{
		}

		private static void SAigiCCbIDfZYEaetvekovoCdQOyA(string P_0 = null)
		{
		}

		private static void bjxSqXBHPqUsmJdMvJwbOPIYgagJ()
		{
		}

		private static void lttuDHGUmKgwixLFTJjaZSJblbCT()
		{
		}

		private static void ObSZoJkAhKTpXZEHYixuPmTkFtXu(BridgedController P_0)
		{
		}

		private static void XkauZsbYhWYCOMFkpbKedLheckze(ControllerDisconnectedEventArgs P_0)
		{
		}

		private static void NGqOiBcgMbPvNJDTGOlHwBsyGjQGA(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void RIVivreiOrTifBcCYbwudmxzawOKA(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void sREcSfeNUNVANQynHEfNQiDkJvSYA(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void HgbcJFEhbZaJkhLmVDjaBhtfSApdA(UpdateControllerInfoEventArgs P_0)
		{
		}

		private static void MgfvHFSRTfFwqDqWKlIgpbowTzwK(bool P_0)
		{
		}

		private static void MNznruwniYMRveWfvVbjEdXKkAWq(bool P_0)
		{
		}

		private static void KaRSOPUBzDOFsyGHmlJxrkXAhdOg(bool P_0)
		{
		}

		private static void BykVxQEooOxtphKjQumkHNdawWi(int P_0)
		{
		}

		private static void iHwlThSIHqVFKRsvkPrjPEXgSklb(bool P_0)
		{
		}

		private static void mlxuguWNZyghMyhFwHNAGngQXOqrA(bool P_0)
		{
		}

		private static void CKJvnyFLLzNcDKqlNDxcJhQPcWZy()
		{
		}

		private static void VEyapEdlxeqleTLvADWwyAlaHIYab()
		{
		}

		private static void AShuRmzONpkVDZfnwnzBlZUCuylp(bool P_0)
		{
		}

		private static void BRNkqrCgyBhJPcjBDMskrxwomhcE(Func<ConfigVars, object> P_0, UnityTools.PLjezcBkFGJQfWOkGFiEWPRPdDHUA P_1, Action<Platform> P_2)
		{
		}

		private static void BGmfcFbMNaRRbZvmSONAUGbzjaYCA()
		{
		}

		private static void LFUmYArAsZAApcbrdxzhAZGYURyvA()
		{
		}
	}
}
