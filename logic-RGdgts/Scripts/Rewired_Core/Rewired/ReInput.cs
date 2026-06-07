using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
			private static ConfigHelper WjQAaHwnldjGbWthvILYYAgChYHq;

			private float gdubZwjnsOWnYyJWNnQjdJsrNodj;

			private float XIBdCgfETWQefFqzyaBhSDtmhvYR;

			internal static ConfigHelper lbAduzmBhLEnHYIeWdaLoLCiGFSC => null;

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
				private sealed class ojyDkFcbSxpEoeAKgvBLZDFhfCUG : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

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
					public ojyDkFcbSxpEoeAKgvBLZDFhfCUG(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
					}

					private void cjHgXFFYGWhdIQKUJynxjVusYouQA()
					{
					}

					private void yizRLbsgxDTsbmoshgCidPKZUtUx()
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

				private sealed class WYHEzAHAquSOHSdtvEhCPghiSxpK : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

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
					public WYHEzAHAquSOHSdtvEhCPghiSxpK(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
					}

					private void cjHgXFFYGWhdIQKUJynxjVusYouQA()
					{
					}

					private void yizRLbsgxDTsbmoshgCidPKZUtUx()
					{
					}

					private void eIxpVKZXEDbBSXUMQCuCQdVlCiWaA()
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

				private sealed class MHacWYTrMrzxQLRVxdPDtmipMvgg : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

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
					public MHacWYTrMrzxQLRVxdPDtmipMvgg(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
					}

					private void cjHgXFFYGWhdIQKUJynxjVusYouQA()
					{
					}

					private void yizRLbsgxDTsbmoshgCidPKZUtUx()
					{
					}

					private void eIxpVKZXEDbBSXUMQCuCQdVlCiWaA()
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

				private sealed class TFrVvqEKxuCvPaKrekJexogtYqfv : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

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
					public TFrVvqEKxuCvPaKrekJexogtYqfv(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
					}

					private void cjHgXFFYGWhdIQKUJynxjVusYouQA()
					{
					}

					private void yizRLbsgxDTsbmoshgCidPKZUtUx()
					{
					}

					private void eIxpVKZXEDbBSXUMQCuCQdVlCiWaA()
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

				private sealed class fZkBdeMDgDXiiEBDIcjmSntvzmyw : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

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
					public fZkBdeMDgDXiiEBDIcjmSntvzmyw(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
					}

					private void cjHgXFFYGWhdIQKUJynxjVusYouQA()
					{
					}

					private void yizRLbsgxDTsbmoshgCidPKZUtUx()
					{
					}

					private void eIxpVKZXEDbBSXUMQCuCQdVlCiWaA()
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

				private sealed class rorzAYagVFDagiEVMbwTPVzdZRPtA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<CustomController> aafAjXCVQhgjOdPPxNvbSSUPrlbR;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public rorzAYagVFDagiEVMbwTPVzdZRPtA(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private sealed class DhoKvVkHvsCjmrbmsbKyiabXFnEHA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<CustomController> aafAjXCVQhgjOdPPxNvbSSUPrlbR;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public DhoKvVkHvsCjmrbmsbKyiabXFnEHA(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private sealed class CYNIgDYEcVvZknNlypIuGMsRDQUdA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<CustomController> aafAjXCVQhgjOdPPxNvbSSUPrlbR;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public CYNIgDYEcVvZknNlypIuGMsRDQUdA(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private sealed class bAGSrMWdqiINvCalrCIiBBRgEgyN : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<CustomController> aafAjXCVQhgjOdPPxNvbSSUPrlbR;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public bAGSrMWdqiINvCalrCIiBBRgEgyN(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private sealed class FoGlGWLjBueEYxannYBzCQBMXGwD : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<CustomController> aafAjXCVQhgjOdPPxNvbSSUPrlbR;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public FoGlGWLjBueEYxannYBzCQBMXGwD(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private sealed class LvCfSixmFUGGbWSeNgORiFufbEkv : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<Joystick> UIhbyKfYtNBZjDUqliRDlZLkiScK;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public LvCfSixmFUGGbWSeNgORiFufbEkv(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private sealed class fEkAqFFHZsbPhZHqTxQhgDgHkdbMA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<Joystick> UIhbyKfYtNBZjDUqliRDlZLkiScK;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public fEkAqFFHZsbPhZHqTxQhgDgHkdbMA(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private sealed class QTeXEpbuWgcmUSlSEEhPHasTSJwGA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<Joystick> UIhbyKfYtNBZjDUqliRDlZLkiScK;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public QTeXEpbuWgcmUSlSEEhPHasTSJwGA(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private sealed class khuJFCEGWUbOCEUUHHzPWXxgCvIk : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<Joystick> UIhbyKfYtNBZjDUqliRDlZLkiScK;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public khuJFCEGWUbOCEUUHHzPWXxgCvIk(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private sealed class upxMaQkbFgGMiDDgsuvsAMCjKjLz : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<Joystick> UIhbyKfYtNBZjDUqliRDlZLkiScK;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public upxMaQkbFgGMiDDgsuvsAMCjKjLz(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private static PollingHelper WjQAaHwnldjGbWthvILYYAgChYHq;

				internal static PollingHelper lbAduzmBhLEnHYIeWdaLoLCiGFSC => null;

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

				private ControllerPollingInfo LmCCtDIwlaCJxvyeVOIcdGXStBwKA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo NLAqwwcVeQAFylvkVATfsKXonfxT()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo lQpAvvzDrddilGPtTfxaaPyhkPhnc()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo hFeKUCpfSEghxHjtsKtNScwBpCtEb()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo qWJTWzUSmTbOBDUgekTSYbTASvcK()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo ZFQPSDJcKZhWWHjXyOvBmZRuBmLmA(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo TSsZtTNgJLeYxFRpZPSUynhIoYcxA(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo dqjcWYFFuiYLRFzdMUNoqiHwKvMjA(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo bbgaALKRIObjZebUDTnCpzMOYpl(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo UGJsIWrLkfCXXAgactfSLfQfzdab(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo tTcTpZtooBSnURBfRqwLSbjujuaE()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo CxMGZpAJbEoXeXyMMiRsRtkVxmYhA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo PoFgtZdPjGCJOIrJBmGogpiAalkf()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo EDKIaPiqBGEcZBwOHJFQiQpNsxnu()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo YJkTxoYUIqmURpYBEKhJVmPwBJIH()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo wWmcUNvOElUYXQSGOgqHskSYKmRX()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo OLGGVbOoPzFfzkuSaBfROOhrrMzM()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo QrZwrFYntBxbzmVMFdWwoGjhPhbt()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo dOogWtGRTNTWKToFNDTyVXMbxHpO()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo JJnFilLfLRmWzvZcjAyBtncumIKi()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo nsnDqPkTWYRhBjUVRlLQIcJJqEsIc()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo EJrRvJQyAHmTWrRypumjyNJPxAxU()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo WYEQVWQbCamIVkUJsucyXGswgEHIA(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo uUiPhFIplLVGcEnYpMbEdkjDQlQN(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo frNQPRtpMnDVZuUhICTYDjSRazdq(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo aLmsncwhQHymTBbjxTLQPbOHKCqu(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo CDAnUZFkhdIbQmxVWnlVIedquAxr(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private IEnumerable<ControllerPollingInfo> wydrzWDnlpVBVEbRWzHPiqLZvimr()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> TPWIHjQClyZpndrKcjszPaqjKscv()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> ntSVuvEKSOIBzXFeKRpYkOMKJJpW()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> KmWZqXFjZMlaFOFQirvAmUjMBOoi()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> kuupDKpzqIzRQUJLxmVOVonVOxcE()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> jLqomNZmEgJcbVNpJbaCjYhuJLTq(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> xBvExNCWMJkTZXNDZiUvCOncrPrSA(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> RVDGPqEvDAwMpCzuKUxThApWMOTAA(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> qIziKcXjejvaniFgdSKtXmUPJERe(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> cSoGNXgqSKUXrxwyoWKDfxZGhFMP(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> ULtaVEESJmqfDbraMhrzPodihJNDA()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> klEGtgXqpcnAfMgCcWTxSOsmdWkb()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> bSseUnOHIWiSfbOImWOjQdnBeeSab()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> hfcNcDmbtLKyvvHvvJlkyvKCMFri()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> CgOhupIcrKhbfzOvEhqFojuLLkjp()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> wnFkpRdMAAeDUMnvXkXhVbQrtMWx()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> aNECRxgTvdIxEuDrjWbXdFsyQYvkA()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> FUFeTXEnsdlGKxZULrzYgWhlRliEA()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> rxkozAGDxDRznZgNovkNfzIMWBDW()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> qVOfhPqHAmewrWNjBWivQlBINRnM()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> KQOSGgLIEeSOXecyJTvxjcRkQpir()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> UpPqyUhkWnRbFwCZwnjTGqKWVKbW()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> UkqQsviXdNDzwJWRzsseIocxhZpF(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> naCfrYkNkGlXjVvdmYiSDNDFOeZTA(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> mwpBCnCvAzFoObigAtkufAMgEQGlb(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> odvpmlDQOaJazHjiHGMRGJOZvwpaA(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> nPGgnFxfFlCbDirHtOpNMWUDzEKrA(int P_0)
				{
					return null;
				}
			}

			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class BFbJqBUGRarYFABXtpUGFXqnicGy : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int EsAvjzzsEcIoFBgWBERTYqcmBmPO;

					public int YMyYrgqjQcbpsfDGZPGbbmUONihv;

					private ActionElementMap PZbZkBoGnFCjWtQvUxrXIJOdhXlgA;

					public ActionElementMap NHvoQUmVUvFdqqRTiMRJbyTctFXf;

					private bool YytzdABPnNIxqySMEhnJehpkGpII;

					public bool BPsPdsiDfjqElVMjTklIiGDmwAtj;

					private int ewwLiKFmCKbnVFhcViVbHODDzYHW;

					public int vXQfuLBNeSomNCFhbslTsFXQMdDu;

					private CustomControllerMap VWFfxPjRKQCDyercMEqrSwQhLrtM;

					public CustomControllerMap wociEpLFbzKolRwnWObGgFZWmpXm;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private IList<Player> OIfFiYilnJtNyiFUeloDhaNGmDOP;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public BFbJqBUGRarYFABXtpUGFXqnicGy(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private sealed class mYNKMBzmMLGYJhvTFfkJBkAZGygQ : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private ElementAssignmentConflictCheck WeJFlXuVmFcPnwQYoDnnchsJRzmFA;

					public ElementAssignmentConflictCheck FCYmIzsyhgDFawLsaVlrNOiKvCgn;

					private bool YytzdABPnNIxqySMEhnJehpkGpII;

					public bool BPsPdsiDfjqElVMjTklIiGDmwAtj;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private IList<Player> OIfFiYilnJtNyiFUeloDhaNGmDOP;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public mYNKMBzmMLGYJhvTFfkJBkAZGygQ(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private sealed class GznbRJBlVwfeKOuaEqOTHPNduqDh : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int EsAvjzzsEcIoFBgWBERTYqcmBmPO;

					public int YMyYrgqjQcbpsfDGZPGbbmUONihv;

					private ActionElementMap PZbZkBoGnFCjWtQvUxrXIJOdhXlgA;

					public ActionElementMap NHvoQUmVUvFdqqRTiMRJbyTctFXf;

					private bool YytzdABPnNIxqySMEhnJehpkGpII;

					public bool BPsPdsiDfjqElVMjTklIiGDmwAtj;

					private int ewwLiKFmCKbnVFhcViVbHODDzYHW;

					public int vXQfuLBNeSomNCFhbslTsFXQMdDu;

					private JoystickMap FiFsRZmsfAlMtxuDUQHizqOuHnljA;

					public JoystickMap IrOaOiFrZJrGmpirPsrIrIXKRXRhA;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private IList<Player> OIfFiYilnJtNyiFUeloDhaNGmDOP;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public GznbRJBlVwfeKOuaEqOTHPNduqDh(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private sealed class fZBgOkAXHBaAkbWsvjYoXrJJyrTU : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private ElementAssignmentConflictCheck WeJFlXuVmFcPnwQYoDnnchsJRzmFA;

					public ElementAssignmentConflictCheck FCYmIzsyhgDFawLsaVlrNOiKvCgn;

					private bool YytzdABPnNIxqySMEhnJehpkGpII;

					public bool BPsPdsiDfjqElVMjTklIiGDmwAtj;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private IList<Player> OIfFiYilnJtNyiFUeloDhaNGmDOP;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public fZBgOkAXHBaAkbWsvjYoXrJJyrTU(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private sealed class sPBMFBzvxJJsjskFuJcjkJBleCCaA : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int EsAvjzzsEcIoFBgWBERTYqcmBmPO;

					public int YMyYrgqjQcbpsfDGZPGbbmUONihv;

					private ActionElementMap PZbZkBoGnFCjWtQvUxrXIJOdhXlgA;

					public ActionElementMap NHvoQUmVUvFdqqRTiMRJbyTctFXf;

					private bool YytzdABPnNIxqySMEhnJehpkGpII;

					public bool BPsPdsiDfjqElVMjTklIiGDmwAtj;

					private KeyboardMap fCQAyzzPcOyfdqQNYUpAFyzEBjau;

					public KeyboardMap krnVMFYBgWvUcDJECWBLMuWECdUR;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private IList<Player> OIfFiYilnJtNyiFUeloDhaNGmDOP;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public sPBMFBzvxJJsjskFuJcjkJBleCCaA(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private sealed class HYgGSbKYLylpVPRgkEpSCZvgxrDo : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private ElementAssignmentConflictCheck WeJFlXuVmFcPnwQYoDnnchsJRzmFA;

					public ElementAssignmentConflictCheck FCYmIzsyhgDFawLsaVlrNOiKvCgn;

					private bool YytzdABPnNIxqySMEhnJehpkGpII;

					public bool BPsPdsiDfjqElVMjTklIiGDmwAtj;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private IList<Player> OIfFiYilnJtNyiFUeloDhaNGmDOP;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public HYgGSbKYLylpVPRgkEpSCZvgxrDo(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private sealed class AjmbuxrKGPLAZQxGbCPynfkVVbaJ : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int EsAvjzzsEcIoFBgWBERTYqcmBmPO;

					public int YMyYrgqjQcbpsfDGZPGbbmUONihv;

					private ActionElementMap PZbZkBoGnFCjWtQvUxrXIJOdhXlgA;

					public ActionElementMap NHvoQUmVUvFdqqRTiMRJbyTctFXf;

					private bool YytzdABPnNIxqySMEhnJehpkGpII;

					public bool BPsPdsiDfjqElVMjTklIiGDmwAtj;

					private MouseMap haIFRexsMbecbDLbGjzFbQrTBkWAb;

					public MouseMap XqsJkEGgycMMJucuWMJsGIaZauKj;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private IList<Player> OIfFiYilnJtNyiFUeloDhaNGmDOP;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public AjmbuxrKGPLAZQxGbCPynfkVVbaJ(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private sealed class dxQsekRBerjhEvoEnKzcsgluFGVQ : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private ElementAssignmentConflictCheck WeJFlXuVmFcPnwQYoDnnchsJRzmFA;

					public ElementAssignmentConflictCheck FCYmIzsyhgDFawLsaVlrNOiKvCgn;

					private bool YytzdABPnNIxqySMEhnJehpkGpII;

					public bool BPsPdsiDfjqElVMjTklIiGDmwAtj;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private IList<Player> OIfFiYilnJtNyiFUeloDhaNGmDOP;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

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
					public dxQsekRBerjhEvoEnKzcsgluFGVQ(int P_0)
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
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

				private static ConflictCheckingHelper WjQAaHwnldjGbWthvILYYAgChYHq;

				internal static ConflictCheckingHelper lbAduzmBhLEnHYIeWdaLoLCiGFSC => null;

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

				private bool zICZZCccXciZUccGppXlkEPUwHKP(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return false;
				}

				private bool zICZZCccXciZUccGppXlkEPUwHKP(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool ImeVxUiMMNeZpmFnGKZkLLbaeFAs(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return false;
				}

				private bool ImeVxUiMMNeZpmFnGKZkLLbaeFAs(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool CdDIAQKzDtmpDvahYvPDoCAEhNxrA(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return false;
				}

				private bool CdDIAQKzDtmpDvahYvPDoCAEhNxrA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool tulhqQqnyLKnfCJWdcHLOkUWCBnFA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return false;
				}

				private bool tulhqQqnyLKnfCJWdcHLOkUWCBnFA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				private IEnumerable<ElementAssignmentConflictInfo> qFiuBxtcrMZNCQdSZzSoDFDyTabj(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> qFiuBxtcrMZNCQdSZzSoDFDyTabj(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> HKXaLFkRUmMDpVePUmSmvgUqQPwO(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> HKXaLFkRUmMDpVePUmSmvgUqQPwO(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> sBtzBSFmJhmBXUwLUdjNmSIdHycV(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> sBtzBSFmJhmBXUwLUdjNmSIdHycV(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> TkjtoAfIkpBwoawmImAIkNkRqtGlA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> TkjtoAfIkpBwoawmImAIkNkRqtGlA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				private int PkedvKucqBZBeMsixdsfvRHEAkYHA(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int PkedvKucqBZBeMsixdsfvRHEAkYHA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int wybdezbMizHuACtHjlXhldgRzhkLA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int wybdezbMizHuACtHjlXhldgRzhkLA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int KMZAnACDzFMMWtFRhGOEJFRcunSR(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int KMZAnACDzFMMWtFRhGOEJFRcunSR(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int AUwflLfcFWUOiJhcaHSYydXsBRabA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int AUwflLfcFWUOiJhcaHSYydXsBRabA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				private int hGvFzVtHWEjUYYZGRbXUWateMzEd(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int hGvFzVtHWEjUYYZGRbXUWateMzEd(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int mWzmVkMlujVKtaGKzjnqPOwaVEve(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int mWzmVkMlujVKtaGKzjnqPOwaVEve(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int ZTjOEMvfFkcvyHYPehHUpBmTibGib(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int ZTjOEMvfFkcvyHYPehHUpBmTibGib(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int YaBfyVSqvvsWjSsDKoghrsAQVjff(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int YaBfyVSqvvsWjSsDKoghrsAQVjff(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}
			}

			private static ControllerHelper WjQAaHwnldjGbWthvILYYAgChYHq;

			public readonly PollingHelper polling;

			public readonly ConflictCheckingHelper conflictChecking;

			internal static ControllerHelper lbAduzmBhLEnHYIeWdaLoLCiGFSC => null;

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
			private static MappingHelper WjQAaHwnldjGbWthvILYYAgChYHq;

			internal static MappingHelper lbAduzmBhLEnHYIeWdaLoLCiGFSC => null;

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

			internal InputBehavior nNMZEBuegSCRzyePfHlgaJhIrLQmA(int P_0)
			{
				return null;
			}

			internal InputBehavior nNMZEBuegSCRzyePfHlgaJhIrLQmA(string P_0)
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

			private ControllerElementIdentifier JvgJisDEfjxbnnflwFguSiAthEijA(Guid P_0, int P_1)
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
			private static PlayerHelper WjQAaHwnldjGbWthvILYYAgChYHq;

			internal static PlayerHelper lbAduzmBhLEnHYIeWdaLoLCiGFSC => null;

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
			private static TimeHelper WjQAaHwnldjGbWthvILYYAgChYHq;

			internal static TimeHelper lbAduzmBhLEnHYIeWdaLoLCiGFSC => null;

			public float unscaledDeltaTime => 0f;

			public double unscaledTime => 0.0;

			public uint currentFrame => 0u;

			private TimeHelper()
			{
			}
		}

		private class yRkaAGhHJbjaAfJOVhXZUtCRPFjNA
		{
			private class hkhGqHspuahDxMNQPZtjBYMQSFrs
			{
				public readonly UpdateLoopType KKlbldiDPbDuxfifcGjVGpjaqJEqB;

				private double OyfcWpPYRdDsPZAdpihjCYZoQyJuA;

				private double CxjJFjitBPIVhmjuzAaDkOxBguSP;

				private double bDeFMEvHSObKEBftstvyPrsjDnLt;

				private double GLoPpoHzqYFplZQSJSACSAHAFKEc;

				private uint KTfntimZPNFDfZPyAQKIPAftEMlJ;

				private uint VEICCJNEuqgqrEWpjSszJWaDqXMp;

				private float yQZbvSUmaxXzMIwtyHCsPOryUTtm;

				private float BOjtQuVemZNFEDpFuaNwebVVAEJi;

				public double YfDpvXHlxwKYKajZMZpFbUSeEBHG => 0.0;

				public double mUXfyDFyovdLxLgZcBQDuAIMLSXQA => 0.0;

				public double pFMFRzEdyhxELHWIZmqtzsEznVku => 0.0;

				public uint WIrjufOYMVKYdFHdgPrcSgNBuLui => 0u;

				public uint wHMbQwkEiGmAGdhvpttevTwiffYaA => 0u;

				public float TypfQRgIxbOVRytkNxUudjSFEOKq => 0f;

				public float nKzkaWTntQizTHlSOlBLlzbHjrF => 0f;

				public hkhGqHspuahDxMNQPZtjBYMQSFrs(UpdateLoopType P_0)
				{
				}

				public void sOLNzBCCbZmFXkMugfndpShqgrUP()
				{
				}
			}

			private static class NSDoQflkgxTjnZtWEQEAfEzrAgQcA
			{
				public static StopwatchBase ucGpGFvhjlGdsxuFlLVQodlIBIac => null;

				public static StopwatchBase goGesjEFofcTayLyzynfoITRPCBk()
				{
					return null;
				}

				public static StopwatchBase IMKiXSsnaTQOMHazxMgBuKdhyNYI()
				{
					return null;
				}
			}

			private StopwatchBase iCLMwyDnTRjqAVMtEjNdeqOKWzQ;

			private double bwlkKFEMjtwZZRtwDfkkcxWqnVBe;

			private hkhGqHspuahDxMNQPZtjBYMQSFrs RMrLdQiLLmoKMurKDMJfjnqbgaWQ;

			private ADictionary<int, hkhGqHspuahDxMNQPZtjBYMQSFrs> mOmDiOAylYvqtKUkBXRWeVPbgFUhb;

			private uint RwBPKMnErLwNdsIthcTXePYYibkt;

			public double YfDpvXHlxwKYKajZMZpFbUSeEBHG => 0.0;

			public double mUXfyDFyovdLxLgZcBQDuAIMLSXQA => 0.0;

			public double pFMFRzEdyhxELHWIZmqtzsEznVku => 0.0;

			public float TypfQRgIxbOVRytkNxUudjSFEOKq => 0f;

			public float nKzkaWTntQizTHlSOlBLlzbHjrF => 0f;

			internal double jGTAfcHYNecoRNTlKuGtdvFZACxbb => 0.0;

			public uint WIrjufOYMVKYdFHdgPrcSgNBuLui => 0u;

			public uint wHMbQwkEiGmAGdhvpttevTwiffYaA => 0u;

			public uint YTBDkBquXTlNQBVsBCRPTfayRLVc => 0u;

			public void cALQIhRaREIQMhCuKXfVXrDZfbVs()
			{
			}

			public void ooNidbhWzBcZZJydutNALDEuSswc()
			{
			}

			public void sOLNzBCCbZmFXkMugfndpShqgrUP(UpdateLoopType P_0)
			{
			}
		}

		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch WjQAaHwnldjGbWthvILYYAgChYHq;

			internal static UnityTouch lbAduzmBhLEnHYIeWdaLoLCiGFSC => null;

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

		internal class VIpHHbminxOEQUZnmfcdQcAMhDZDA
		{
			[Serializable]
			private sealed class EPbTUEpCePfOnFZGoYmQPjqYAEiY
			{
				public static readonly EPbTUEpCePfOnFZGoYmQPjqYAEiY _003C_003E9;

				public static Func<bool> _003C_003E9__11_1;

				public static Func<bool> _003C_003E9__11_2;

				public static Func<int> _003C_003E9__11_3;

				public static Func<float> _003C_003E9__11_4;

				public static Func<bool> _003C_003E9__11_5;

				public static Func<string> _003C_003E9__11_0;

				internal bool eCuvqnNuiacLLYdDfwrholZIjoPQ()
				{
					return false;
				}

				internal bool QRRPLYROgJsrFPjEIcVmeqbIUbIE()
				{
					return false;
				}

				internal int qRidascjfDkpLUYKoTyDilHsJCtC()
				{
					return 0;
				}

				internal float TLMbIJGnxdrubPJmGcvReWnHsnueA()
				{
					return 0f;
				}

				internal bool ZbYbpNVWMBWsgwyDoRXkOElsVHgC()
				{
					return false;
				}

				internal string snOzlRajzXYRblwodGFlEALJmneI()
				{
					return null;
				}
			}

			public readonly ValueWatcher<bool> FzbsNyUWhJkMFdEzPjPRgZViMPfw;

			public readonly ValueWatcher<bool> XuHSAthgpDzCdtDHZPeWHpzkAvLbA;

			public readonly ValueWatcher<bool> oflHewLIhoAXLooWQloPgHLmDCsIA;

			public readonly ValueWatcher<int> yaTWBuyJKYQHJKBtEFmGiCnezgmSA;

			public readonly ValueWatcher<float> pFMFRzEdyhxELHWIZmqtzsEznVku;

			public readonly ValueWatcher<string> FRTVgyoqXTTaNFfBWXVmXiRbXibX;

			public readonly ValueWatcher<bool> fHzbwjUdIFEbqiEHIwTGuNaUaRUlA;

			private int MpTxISTzKGaelgEmrFFSoTtjRclB;

			private readonly ValueWatcher[] LDrwbPEvURlltFrpsEOENqsqUQQV;

			public int doZLsZRgYxDwomvvWqCNGeRMTGMI => 0;

			public void sOLNzBCCbZmFXkMugfndpShqgrUP()
			{
			}

			public void rmDhkvCLKiRwpZPntUFXxmTjOnUE()
			{
			}
		}

		[Serializable]
		private sealed class fnxCvfZoSNZzOUDHzruZgJsBHbLk
		{
			public static readonly fnxCvfZoSNZzOUDHzruZgJsBHbLk _003C_003E9;

			public static Func<bool> _003C_003E9__222_0;

			internal void YEiiuyBSbupqkbbLAAYPucsLFTDib(Exception P_0)
			{
			}

			internal void ClLCPDQDaiWUzDvTqQxcEBOpSAye(Exception P_0)
			{
			}

			internal void UgfHmBroNArmKzavcBWdCkxPASoVA(Exception P_0)
			{
			}

			internal void DkVplsUfAJwZmYRHLaiywdCnmGIl(Exception P_0)
			{
			}

			internal void jMDCMookOwmHLCEOpubAzqFBCjpI(Exception P_0)
			{
			}

			internal void pibhbhEHKkEWugWldbGbBXeIfAosB(Exception P_0)
			{
			}

			internal void ZZTVaKpAcOsPKIkxHZtuTIgSaFPm(Exception P_0)
			{
			}

			internal void wprRElxKhYbBflxhaVBzpfycFtYN(Exception P_0)
			{
			}

			internal void XUIuPJbLgHECIUhIhpOIVkGAglxS(Exception P_0)
			{
			}

			internal bool xLVCerGkNRkfYZqzZpmsGzMdHDbfA()
			{
				return false;
			}
		}

		[CustomObfuscation]
		internal const int programVersion1 = 1;

		[CustomObfuscation]
		internal const int programVersion2 = 1;

		[CustomObfuscation]
		internal const int programVersion3 = 44;

		[CustomObfuscation]
		internal const int programVersion4 = 0;

		[CustomObfuscation]
		internal const int dataVersion = 1;

		[CustomObfuscation]
		internal const bool isTrial = false;

		[CustomObfuscation]
		internal const string majorBranch = "U2021";

		private static InputManager_Base CVOosweFQkjenKNkyCghUKMwQzfI;

		private static PlatformInputManager DsUMFOuNrADSwelafhXWALBVQljt;

		internal static uwbgviXXIJPMnGJRVuzdFTgToYVv TcJeRjoAHWajdfxVaSabfTeqWDcy;

		internal static sQUhNuelsgdElREOuzBUnZbPDjkc OkLkjfkBGntRAvakyAvYRRgphMAiA;

		internal static OHBxQeqzwpSOXtKiahobKGuCdFjeb ajnOsEopTWvzJZjeDpcpYppqmqOw;

		private static ControllerDataFiles yuMAFKYlLRXHYECDtAfqrzgtWNno;

		private static UserData dhXuTEEziWFtUyjdydeOTtEMceSv;

		private static bool juAmOHdlEuZcdEbopfsigKMAJgtHb;

		private static ConfigVars HhUekGiZgESvZmOBirudgfCplDISA;

		private static UpdateLoopType SGbCYHanXXzBiWnXJzwBdELpFDCnA;

		private static bool xAXgrgTBrSfWQOaiATiEGRGhgWIC;

		private static Platform fzICSMslIAIogSLDYlSBPLBPiOoF;

		private static WebplayerPlatform ZpqltcgNrXUHCRtunjsQsaPwjfOIA;

		private static EditorPlatform vLtJrfESYPgDQDnGZPJTJqwWHIYlA;

		private static bool fPVGIFZOaraUFNEsjBjKxdJKjsBQ;

		private static TimerAbs SKyvYsUBAlhUEnadFFWMiAvAKNBDA;

		private static yRkaAGhHJbjaAfJOVhXZUtCRPFjNA DnguBusOPRzgVZOfVVmqrxdKVdpS;

		private static string hubgZmpbFjYDnMCksJvcpKfkxjuv;

		private static bool iAJESsWCiSvwBPNuAGiTFudrWkqL;

		private static bool JjXaHxVjZWMdZXJTNveiFRgxzXWe;

		private static bool xKPALbkrgWCQScxZCiBgyXBoonOyb;

		private static int XLiQYniPJQiCkGaxLchxZGvMEWgu;

		[CustomObfuscation]
		internal static int _id;

		private static int vAglbVJjRYqmigMCSfjCzWtGUPmo;

		private static int ZWsLEIbTkRLpeQxDCxjhyNRcUgKf;

		private static bool UsGQqdiGSRcgPzJccGZACMQWxRDlA;

		private static readonly UnityTouch jGgaTfdbIjOdGOdWkTriQCMbvhmP;

		private static readonly PlayerHelper HCNMZHRpLUkaDYlhLuwVXMJnNaHH;

		private static readonly ControllerHelper DlOHerLmRxyzOIuoeNyIHucbqbre;

		private static readonly MappingHelper pGAMRUtdDRjJOscfVgAobcYfwNfu;

		private static readonly TimeHelper bDOPsIGutLtEYlTWXQWNmcMNjujH;

		private static readonly ConfigHelper yjCktTGHyEtCBXqulFPfUZZAhDTD;

		private static BlhfMSqWdxGGmkrOLnhytYOWBVcP rNtPPZNSNevjaLXalgxBLmCULitH;

		private static UserDataStore WxMFnEYRcWmtcAezaIddwROfarEG;

		private static IControllerAssigner VBDkcaxujnFiYdBuOjuquSnyqjHE;

		private static VIpHHbminxOEQUZnmfcdQcAMhDZDA HeYakTEtCHWQxVwCyeqMlkZOUQafA;

		private static SafeAction<ControllerStatusChangedEventArgs> lFjrTanwbFwsbvgdYLZmBLvoFVkp;

		private static SafeAction<ControllerStatusChangedEventArgs> AqxDSCKdbkAKVwJYDWnhpyNDIyGQA;

		private static SafeAction<ControllerStatusChangedEventArgs> IygYEaSeXkocaFAKApGKrzOiCMIN;

		private static SafeAction EEvWOInbYwCpcrCfajmNfbyGrZAW;

		private static SafeAction OEfCNSKRaPIivtobaVBYGskOnHSh;

		private static SafeAction ApceFuDOxIppDLINvkfawFPcEthz;

		private static SafeAction YfHioobrCzormgbBBCmuqPfBAiGY;

		private static SafeAction ugluxrYYSXYofgwlByxDuTjacgpE;

		[CustomObfuscation]
		private static Action<bool> _ApplicationFocusChangedEvent;

		private static Action RXmlFWBfUsIbqgkTuejcfSOCHAWZ;

		private static Action<UpdateLoopType> COduTVCXoOVuRWiPKOjmEnRXLeND;

		private static Action<UpdateLoopType> ADpqDtxhaJkoGNlXgcqrdfKmlXscA;

		private static Action<UpdateLoopType> YWlOwyefRtPCLfngYWjLjwUcFjOt;

		private static Action ahHahVIVNwaZZPYXNpDPsAAjJLqGb;

		private static Action<bool> zpEdOYsGkXCCYuGYtLGyAaQZgnccA;

		private static Action<bool> GAkHzoGpoOPydMlwUwOvmvAhwbjc;

		private static Action<bool> NhobUMgUqklZnceVoRWjKhBdqvhu;

		private static Action<FullScreenMode> RmykIGJsGMxYoPLvQMNFFeTWLBXJ;

		private static Action vMeZFKVtjhxTgXBKbxLTKDVbcsgv;

		private static Action<bool> IpQzbRBLicjyYdGDxswJfmHjaOFS;

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

		private static BlhfMSqWdxGGmkrOLnhytYOWBVcP ZMMbmdkWhjAWAhXVeHcFydUeJIjqb => null;

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

		private static bool qvZgiXjUPTsUgDmcMQvfwLWeZiCuA => false;

		[CustomObfuscation]
		internal static bool isAllowedEditorWindowFocused => false;

		[CustomObfuscation]
		internal static bool isUnityEditorFocused => false;

		[CustomObfuscation]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform => false;

		private static bool vNfnJueJAfZDitForEnRPJbxpOkQ => false;

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

		private static void sUcupMLOUYqoJsYPEvQJZJQLKuaM()
		{
		}

		internal static void gUxczTgMdKUcYRnCXamteWaCXJodc(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4, UnityTools.dLTpFXVUEoYOHBezYpFOWYkDPuSf P_5, Action<Platform> P_6)
		{
		}

		internal static void rIjUCmsjifmvcBNTbhJRFVmmqsqk()
		{
		}

		internal static void KaOzEMzQwGGQbJUsZJreBHvRCACe(UpdateLoopType P_0)
		{
		}

		private static void svfvzlkpCJMaoNonneqvLHqMEJebA(UpdateLoopType P_0)
		{
		}

		private static void WzrFbEIYDXnXJJKfZWrdDRDBkdwV()
		{
		}

		internal static void sOLNzBCCbZmFXkMugfndpShqgrUP(UpdateLoopType P_0)
		{
		}

		internal static void uLXyvePCedSwMMkyMFvfsofVDBow()
		{
		}

		[CustomObfuscation]
		internal static void EditorUpdate()
		{
		}

		internal static void WcpUpKbeoqbiydAkzwOTTWTeWpxZ()
		{
		}

		internal static void yXlebcKsEYElFWWmmLxmjbkMPWSk()
		{
		}

		internal static void qCIbeGpzyGSbMtIssFCnvdjbWWve(bool P_0)
		{
		}

		internal static void cwNEDzPBuXiKMVFqcGPDbpxotzck()
		{
		}

		[CustomObfuscation]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return null;
		}

		internal static HardwareJoystickMap iCFBeqngbahtgGTVxrPduMQZXdmW(Guid P_0)
		{
			return null;
		}

		internal static HardwareJoystickTemplateMap wgDfcpFFKvqeeKkPsJPdHHqsdbZZA(Guid P_0)
		{
			return null;
		}

		internal static IHardwareControllerTemplateMap ZXAKBHNCXgchECAyMuaZmpieKvSPA(Guid P_0)
		{
			return null;
		}

		internal static IList<HardwareJoystickTemplateMap> UUdaBjbHBlTkYdRHEciSYTDLHKiz(Guid P_0)
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

		internal static void pvgucvcpEBlNTxuHHBVNqzamlReP()
		{
		}

		[CustomObfuscation]
		internal static void CheckRewiredVersionCompatibility()
		{
		}

		internal static float ONcDHoNHsmreSyMftwbKquhWEVGf()
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

		private static void yBzFvgVjNOcORWMCZCNKYbHzydvO()
		{
		}

		private static void DzVKzZZSNhcHFMNPFIbHEhBFuhklA()
		{
		}

		private static void LCAKOisTsGfefoAlygRRHMXhOLosA(string P_0 = null)
		{
		}

		private static void ovWQjTmBaCjemwBSRBKNDCmCYQBg()
		{
		}

		private static void YGumDYhdZrtzIaNogMoqVpLRnpnf()
		{
		}

		private static void zuPDFemqfyqKDOPSiYxjlNcdheek(BridgedController P_0)
		{
		}

		private static void CBOWnXpWSeIFjcCDmASmPwHMJPns(ControllerDisconnectedEventArgs P_0)
		{
		}

		private static void IAPYElNTdXAKYNaUXIwNJJAgppzx(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void lTPylGLYTtJZuyYypBZCODWvMGlN(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void qGqMhDzMzcHcxlEHiOIUXTRMQNaB(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void MQDslrblFnFPIksPJgNEutAbEGAJ(UpdateControllerInfoEventArgs P_0)
		{
		}

		private static void ciqEMkdNIetcwAdDEzSvXOVSVQfM(bool P_0)
		{
		}

		private static void xPIGfStyoqlVjzIESriduPijGmaE(bool P_0)
		{
		}

		private static void bgwgQqCBRAQCxNYwifUOrWDeCDpo(int P_0)
		{
		}

		private static void tTTQMXKDJGQXiVEAxHTiSooeXjBk(bool P_0)
		{
		}

		private static void VBKEtSJRgMqnWhkboePkaGDhqCwmb(bool P_0)
		{
		}

		private static void QMAuRSCtiiPBefUgCEgxlSpgiek()
		{
		}

		private static void XbYFEfePGwBtdHctyNZwJGeyjHodA()
		{
		}

		private static void loBFxBFIfYAnvaKTVuCDYNGMOeRuA(bool P_0)
		{
		}

		private static void NOVTJmKEcBJnXKENDhsxERaxmxqZA(Func<ConfigVars, object> P_0, UnityTools.dLTpFXVUEoYOHBezYpFOWYkDPuSf P_1, Action<Platform> P_2)
		{
		}

		private static void zHtQLVrCGGvBPKxwkomJDaOttjfr()
		{
		}

		private static void yiPLYmFMNyvRUXdhnNxGvpwaMcwb()
		{
		}
	}
}
