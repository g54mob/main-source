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
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class LocalizationHelper : CodeHelper
		{
			private static LocalizationHelper XVlxgcuuZuGMCtzeLZzRvDpgmkCh;

			internal static LocalizationHelper snUypyVfeiWnJaGgcGKpBkboZvkw => null;

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

			internal static void EnTEJSQMmKGPvGKCDDaPLpXkVrXN()
			{
			}

			public void Reload()
			{
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class GlyphHelper : CodeHelper
		{
			private static GlyphHelper FfrAStpsDgTJwIkXsHWczRUYplbC;

			internal static GlyphHelper uEIfSyKgajOCcWMENIJIDKkeANdOA => null;

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

			internal static void gjySRMCEHaeIbZQttgMDpDMVZYfn()
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
			private static ConfigHelper DHFhmOgagccvntXwKNnkFrDKeZgv;

			private float sUWFfuFNZasFVSdISOnMZUMumkWoA;

			private float ugwakPpLXOKaLLTHhOupjTxxLOVi;

			internal static ConfigHelper iUDpqxwjCDCLUXekCXMcWvYpsNTr => null;

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

			public bool disableAxis2dClamping
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			private ConfigHelper()
			{
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class ControllerHelper : CodeHelper
		{
			[EditorBrowsable(EditorBrowsableState.Never)]
			[Browsable(false)]
			public sealed class PollingHelper : CodeHelper
			{
				private sealed class KIodUBIzGBRhnMUBuoDpwlCGIuhJ : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int zcuDBLFCYXRtOfGSGylFtMoqqyDu;

					private ControllerPollingInfo TffzzAPKbahZNggnUHexgkpBFMtm;

					private int nXRoCyemMBDHWHDKsPzCJMFJZdVaA;

					public PollingHelper ogxqAKHaCnCJitHhZSAuzEWIatNg;

					private IEnumerator<ControllerPollingInfo> SEreSNAbltAqwcTUdDtpsOMlSLBb;

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
					public KIodUBIzGBRhnMUBuoDpwlCGIuhJ(int P_0)
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

					private void ZHZtlmriAqZqTYTkmtrHYJSMYAaR()
					{
					}

					private void birNHEGVJLTkYqYcjzKAgownAMlg()
					{
					}

					private void sTfsLVAFtWATvrWPGGvddFkFbjxz()
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

				private sealed class sNPwENhFSDsUweudQJicmuBcxSab : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ibpSXrKfjrNXVjIjlHFGTFfPESFY;

					private ControllerPollingInfo nsNhQtVvXkIufoJWpkEBFbCdQPLJ;

					private int iLZxyLGGWpbbaUkGlCIycigVOdbDb;

					public PollingHelper btLqdRjUybAkzYtViHurpDRZkQcg;

					private IEnumerator<ControllerPollingInfo> KaTbLMGZhktEsNLrbBZMUcFhiwhsA;

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
					public sNPwENhFSDsUweudQJicmuBcxSab(int P_0)
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

					private void VznuuwqVGseimhSUElstXsjGqAkI()
					{
					}

					private void rkkcxDbFxkTHQOGyHnjRPVvhbfHiA()
					{
					}

					private void cWZjbwKchbSzuRYxEaQqvsNoHKAm()
					{
					}

					private void iIwBteJjWhgvYLnSjPfRQpWBreOeA()
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

				private sealed class wLyOdMtlCTXUFdEkzwozWlYEzPRd : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int igyzstLSmWoeLJLvtjMtKvsDeTIV;

					private ControllerPollingInfo lMxXhVgRrApQLUsmIBqsbFaZhgOk;

					private int rlIZonzPgyumHnatndEejbqFtdyJ;

					public PollingHelper NWmPgIwfulTePTfyZZugbpugbrAO;

					private IEnumerator<ControllerPollingInfo> DeNdOIOriNockjTQbqbfMMhLhGcJA;

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
					public wLyOdMtlCTXUFdEkzwozWlYEzPRd(int P_0)
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

					private void vFnaBOdxQeeOIpHQDaRfFvOXXTZh()
					{
					}

					private void MuTPGhHIlGpQtsFVMnsbimthkSlm()
					{
					}

					private void IPogSxFLPzqmZCpKCNgmfQHHdfPBb()
					{
					}

					private void OnRQIKTinUlMhgstYEKUPhwSchGM()
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

				private sealed class hqtDHkkJMYfBQKsaeGOQOFjQWFCo : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int xDXaVbXvoENYDBaKZaAzBBxpQQnu;

					private ControllerPollingInfo KmSjsCHHQiIgjkaqYFUjDLHwfFDK;

					private int ohyQTbCuZGRudXellYYjcVgcDCZf;

					public PollingHelper hjuUqVehTAwWtOPTWXMytvTMQPhl;

					private IEnumerator<ControllerPollingInfo> NWsVSvEEUMuoJxRIdJxbUXdydful;

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
					public hqtDHkkJMYfBQKsaeGOQOFjQWFCo(int P_0)
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

					private void dnqCzpCBjCSWOhPsKALxMBomyjzKA()
					{
					}

					private void eJadwamwWMLhKYfPAvnIpwdkvBWp()
					{
					}

					private void vCKfoQFsmuFhUOrsLpaSSmBRrgyV()
					{
					}

					private void HVaKHsyKCpLxqjXIZlmojXTrJegx()
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

				private sealed class LQwCxmqzXdbKfyEKQAoKvmoQTPTm : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int IxnMJuTluEvkIHhgJAnSWLxvCizt;

					private ControllerPollingInfo MSEeyWuOnmJsiuAEyGuvjszqZKvE;

					private int iJafdikMOZAJbODIdAMFFlcKkjmmB;

					public PollingHelper AyRkFyLzFPHCmvGCIsHPufnrFkcf;

					private IEnumerator<ControllerPollingInfo> lzZPRimNxKgiLEaFNMaFOUTrOZXV;

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
					public LQwCxmqzXdbKfyEKQAoKvmoQTPTm(int P_0)
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

					private void ZgzyrCdqIATOjMrnrbqBqLtHbntq()
					{
					}

					private void MwbKLiUCAricwBYJOhbPrbaxAAloA()
					{
					}

					private void DjccFJjjhfkoMnlfQzTMKteLzzvN()
					{
					}

					private void WdBAksiKrwXGAkSVXsHcBbfXZDIlA()
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

				private sealed class XivJkMMIyvzQrkJMSwxdyDcMAyoW : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int orRuaOLNLijxWdSUOifBlDBFeHoP;

					private ControllerPollingInfo AufEdmHNiuGDGHlgtYkFuyAOnSKJ;

					private int UAYceUeCNMDFmzKQBMtRcWiaefUBB;

					private IList<CustomController> FdClXvUwFVGjtWktlcNbDRWpYAiL;

					private int FFbdOZecXNVDuAaGLoZlHsDChTtCA;

					private IEnumerator<ControllerPollingInfo> ERECXSlQTCFjpYwnVwzYxHgQnMbN;

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
					public XivJkMMIyvzQrkJMSwxdyDcMAyoW(int P_0)
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

					private void rOvGoAUEFAEIPejHcnCDoTyBeyPjA()
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

				private sealed class zekaPCSESCidfFznoRKQDooqMzkc : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int hPZzoNMGNUwPmIYtseshFmEzsLLD;

					private ControllerPollingInfo iaCfiNDwreWwuqZCkEVWxbREFNmS;

					private int hIVvIOgkLdsrBVgESdUHglDdhIcz;

					private IList<CustomController> mdLeVGCbxRbxgpFsRmdYeqFkjdYub;

					private int WIqfsmFtqINVkcMChKMIDULFmtTTB;

					private IEnumerator<ControllerPollingInfo> VDelWfqAASSXlewOaNHIZwUEjwuN;

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
					public zekaPCSESCidfFznoRKQDooqMzkc(int P_0)
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

					private void TbYsOORCSPNfQVjQtfCVFewgrQWF()
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

				private sealed class iAByGRapVzIltBYykjPSnLxuptpt : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int WbAuQORKnjIYgmueGzrFkNyUAWnh;

					private ControllerPollingInfo klhfwLDDphHAuZqrrRjkQLhXeMPM;

					private int ASVVDmZGnzEahNZYJPmwJplKqbMo;

					private IList<CustomController> APmRpZrfyCAOcOmOEFGZFEivpQibb;

					private int zKpkWxnBKlaMRsObZXmYTqSyXVVv;

					private IEnumerator<ControllerPollingInfo> ocFGyyXtOEEYrEkOaHwrUKNcWPmuA;

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
					public iAByGRapVzIltBYykjPSnLxuptpt(int P_0)
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

					private void afHPBZmFpHEpsfljoOJyhByTzyXeA()
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

				private sealed class HRUdgAqnRWgmmiQgruBEqnORZFZx : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int XFGXRJhRVFkQJwulIYkgXtxeQADE;

					private ControllerPollingInfo qAvHFifplGftyNibugfaguebPfIMB;

					private int seaCdJAIkzupQgufCOQDWcNkFfXO;

					private IList<CustomController> xlRDXeDhPNFIaePghQPzeDxpVCJdB;

					private int SrlDgrCsLBiXUAXxhVqcnaNhoeAzb;

					private IEnumerator<ControllerPollingInfo> AFwiDiFkEPrbWPVZygIHEyDRZeMW;

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
					public HRUdgAqnRWgmmiQgruBEqnORZFZx(int P_0)
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

					private void YRvgyJjUajbGWKxFRccIalwZDTbAA()
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

				private sealed class daCJXWnNUECuZXhzjVrPvGVjeSNG : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int XiJEfBKmJFGoquXOidZnINMEFmnjA;

					private ControllerPollingInfo sEOvuwviIUCqQcUSDKZdYcySPkwTA;

					private int ldnebeiIdsiSLPHCkboLnLWfutjUA;

					private IList<CustomController> wZkvVoWEhIbqCgKQZUuFzccabOpEA;

					private int eELjUNRhYtwavXnDpBCIlNKVCPyjA;

					private IEnumerator<ControllerPollingInfo> LZJIksvVCVaJxPjrOVoayUixJEec;

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
					public daCJXWnNUECuZXhzjVrPvGVjeSNG(int P_0)
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

					private void RzTFFsfYCZPVcCgtwUCwElOHLGfIA()
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

				private sealed class xSMBgyBaIuoBiqbcHpofZxnGbENe : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int AUwGGqFyzMlwRfBRkvQFcQpgwwbaA;

					private ControllerPollingInfo VEARieGPUyxbSHJBsHrQyCaIjcBCA;

					private int RiizrmixmgHhkAKjkjNDGcctPJEIb;

					private IList<Joystick> fIpXDxudWvtaehdTLiiqDnbaMJwj;

					private int WFzwaklpybrdHAfZcHbiUDJqBrOM;

					private IEnumerator<ControllerPollingInfo> LTyzOixkQHsInvlZVzceBmvXcLPhA;

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
					public xSMBgyBaIuoBiqbcHpofZxnGbENe(int P_0)
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

					private void SvpQBDfCQvLCuvhzTDsPWeYCNTAd()
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

				private sealed class NvsgGHtDkYbzuvFrPZFJqCxqgCKJA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int uHKPUoHJHUbKKduVkNZKPMXhNkLab;

					private ControllerPollingInfo aNwhMBCQQGtZUoKiPjqbaVLLHvuF;

					private int nPYKncvovBdkseMdPHDGmEUQqaZlA;

					private IList<Joystick> NSjLfFTkAxfdkIiOWBbgSpTbptAoA;

					private int eeygZutuVdrUoyxhxNBaFiqmKHR;

					private IEnumerator<ControllerPollingInfo> sfLELsorZeubygBYbHOXLUoHKesG;

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
					public NvsgGHtDkYbzuvFrPZFJqCxqgCKJA(int P_0)
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

					private void bxhEeKuXPWVOuuwQswniEeUUEdnO()
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

				private sealed class wCyjibNIlEqSHaXNQterVjlyYgVR : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int gVoZCcqbYJKVlWdTVZmyUuzGegOd;

					private ControllerPollingInfo eSCQeyeLnwOTkOeKZjxcapZTKkhn;

					private int KDgJaRGSLsHbcwrTRiSejiuQClRG;

					private IList<Joystick> SREqbUrLJzcdCwotiRPFnNBPIcJi;

					private int wUBDhenIYwIJoleaHtMUMupUuqZM;

					private IEnumerator<ControllerPollingInfo> tgXHhHMCYbKwDHNcUxfwrXSBZgnd;

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
					public wCyjibNIlEqSHaXNQterVjlyYgVR(int P_0)
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

					private void dApswTfLQAwBsnAFNkJUxOFEgZjm()
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

				private sealed class MnivbEkHpckKZyJTRkinnWsVzuxh : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int TZZxWcaUOBeorZGNLoXCuuBWWPkg;

					private ControllerPollingInfo JNPcUPRbzvUvDwGAMsTeBBzHskVc;

					private int pbsIBjADdJYkmFCCWoiSriKuJfsp;

					private IList<Joystick> bQialbirUyizJSupZXOYAfGfgnEAA;

					private int TwdQFVEHgobtFiDpjoXJzYahzXxGA;

					private IEnumerator<ControllerPollingInfo> dFjEJOVPGXbRdECRLetjHSwJiDAyA;

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
					public MnivbEkHpckKZyJTRkinnWsVzuxh(int P_0)
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

					private void xucZvlRhoIkUDFlwXxWaQACPnDox()
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

				private sealed class OgjDWOfQaAYwhslraomEabTACSirb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int JjgTplVMNqwCQpwcWrnFDYLdHwNg;

					private ControllerPollingInfo KWPEEtCTRMebUAPXhdOYGFyVBTvuA;

					private int NoyEiltRnkpUHXRuobhlRtvCtRWC;

					private IList<Joystick> OkhjjOvgxFYgpWZxrvGymyoOdnyJ;

					private int UnLLZribYCbtkAMkakQQFQqVWddB;

					private IEnumerator<ControllerPollingInfo> sjxRSgQtzzINXejJAGGyhbarOzEyA;

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
					public OgjDWOfQaAYwhslraomEabTACSirb(int P_0)
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

					private void ksphsjYsiAgcotWSkCxGMdfWcMVD()
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

				private static PollingHelper aWBLDDeSaLtajAOhZnZaoRGsQUhc;

				internal static PollingHelper xtqWMZzGLWAHbJaNFKIBVFxnSAWFA => null;

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

				[IteratorStateMachine(typeof(hqtDHkkJMYfBQKsaeGOQOFjQWFCo))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					return null;
				}

				[IteratorStateMachine(typeof(LQwCxmqzXdbKfyEKQAoKvmoQTPTm))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					return null;
				}

				[IteratorStateMachine(typeof(sNPwENhFSDsUweudQJicmuBcxSab))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					return null;
				}

				[IteratorStateMachine(typeof(wLyOdMtlCTXUFdEkzwozWlYEzPRd))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					return null;
				}

				[IteratorStateMachine(typeof(KIodUBIzGBRhnMUBuoDpwlCGIuhJ))]
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

				private ControllerPollingInfo PcYgRYLFLyWEbkyfBaTvcvPkFsdo()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo vUNnCVynjMJCllkwUarShMnVmlOtA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo AKAuglVjMkVbABWpwcVZgydAqmfn()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo zoJpvepEHgAZFFtkAxIzjiByDgyt()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo kMDyJCBtnwGCuSKzFkcClYsbwwGc()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo ZhfcdYCBkydWpDcVTQbQNfFZqnYCA(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo ApyBHKGHzTdrIkaramtgsYPskkdN(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo jiFsplEWAASmRIhhennRpHHWYMRI(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo ZkFQOMguiAHFeRmUssVUcGdvqCQb(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo LzJdAQPjjBjcTHmGglFGOFmFXmWP(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo nRwtFvBUmZuvolKeBjEWWNORyFid()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo ZhlgZXyKoyjNuDxwgzfzNCsNKMHi()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo dQBtYIxSUgsluSpiNdpzGjWIuqIHA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo nYFRaWlkfjBnNyERhoFBhWOcWHGd()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo CbPPVOZQtgEouoveOXhqhRVpaRMf()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo ptSzZokOYxPTnqZcpCkxMlKNeJUO()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo FbCFoeEQAgHAHGGcTIYZukgYnNBL()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo qavZzHXskeivcrGZmxNygvufHXrE()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo ydRdinmyTHVtwbwygrQImUdCsgUC()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo fxtGgQzRrhSPEENszFOpKAMwOHVK()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo LmQrCrENrAlpWdGWiDpWDQoKyekE()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo vLfdluaqOvzZnXFcMIGCfNQucejkA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo yJlaulHzlVcavfQHVdefXEixOIiGA(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo yOPBWXvVKQVYtCaGMfSnDagqQZUp(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo WSZVkBrngFhXScvUbjvaylknFMSz(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo ItMSoUSTTRliicuIFkBPyznpYGcL(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo LZeYtNfADQQYLiYPKLMUENWnRgbV(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				[IteratorStateMachine(typeof(MnivbEkHpckKZyJTRkinnWsVzuxh))]
				private IEnumerable<ControllerPollingInfo> jqdgdumIMLXUnnhhWrSQodBSJQAh()
				{
					return null;
				}

				[IteratorStateMachine(typeof(OgjDWOfQaAYwhslraomEabTACSirb))]
				private IEnumerable<ControllerPollingInfo> xCXxuxLeRzuyqdYynYaVVyzdsbLB()
				{
					return null;
				}

				[IteratorStateMachine(typeof(NvsgGHtDkYbzuvFrPZFJqCxqgCKJA))]
				private IEnumerable<ControllerPollingInfo> stOIhcqQZXTuHGuqjHsuXcaRplhs()
				{
					return null;
				}

				[IteratorStateMachine(typeof(wCyjibNIlEqSHaXNQterVjlyYgVR))]
				private IEnumerable<ControllerPollingInfo> xxgzcCqxZImurGFzknaIcygHcByh()
				{
					return null;
				}

				[IteratorStateMachine(typeof(xSMBgyBaIuoBiqbcHpofZxnGbENe))]
				private IEnumerable<ControllerPollingInfo> YmLgGkGPyOArzOyNpewNDfWJNgwPA()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> FngTYEmgeDkaevcewZWoINSeTZGS(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> lDrGAbktdOyNDUFcDgOewRyWarAb(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> TjmeHdevRUjXDaMmnNMPumnptckC(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> VHnTjzNDjBpIzZaRrbNSJcvrWaMH(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> FzPiPHdtPEvUIfataSjvibcScjm(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> LUxAMfuGneQgEKZjUqMzYXWkPxnU()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> kBUJJtohBeaGMdUUYIKTypUWNkZHb()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> BArMKKYCzkQQPxmHeFuEEyXXAqJeb()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> LrroKXwmFQsWcfkfVelpWbOCKEkP()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> bhnEYMvFhsUklqUKYbUMvHlWJTIc()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> LhozrvmagtCeggejSYwaiWiMVEWK()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> QeMDkSgLcwxLJFOiUawmINQfWDiS()
				{
					return null;
				}

				[IteratorStateMachine(typeof(HRUdgAqnRWgmmiQgruBEqnORZFZx))]
				private IEnumerable<ControllerPollingInfo> HMPjAMkpltFHNaPKvDodfEPGkDDFA()
				{
					return null;
				}

				[IteratorStateMachine(typeof(daCJXWnNUECuZXhzjVrPvGVjeSNG))]
				private IEnumerable<ControllerPollingInfo> RrSUECEqkaVaQWRwhPKSULOALSgf()
				{
					return null;
				}

				[IteratorStateMachine(typeof(zekaPCSESCidfFznoRKQDooqMzkc))]
				private IEnumerable<ControllerPollingInfo> uRrrKOgxGXVOTVUWAMNDJGuWSDfk()
				{
					return null;
				}

				[IteratorStateMachine(typeof(iAByGRapVzIltBYykjPSnLxuptpt))]
				private IEnumerable<ControllerPollingInfo> iILAGZtdLdSautZnoCswYVYpsMaR()
				{
					return null;
				}

				[IteratorStateMachine(typeof(XivJkMMIyvzQrkJMSwxdyDcMAyoW))]
				private IEnumerable<ControllerPollingInfo> OFmgznqOLowEwNLffcVmEAvcZYxJ()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> xFVJFFlWIWmHCMoRHpvNdAfhJNpE(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> ErPmrTVnrBkOHjeSUYifBvylOBxi(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> FXxvsCRSKiPrdurMWDLUcaovRAWl(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> NyyAGueSsFbMlBQWEeVGhlDvyBWQA(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> AGdGOFvMPrNlxUUEcfBFKwuaEXUo(int P_0)
				{
					return null;
				}
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Browsable(false)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class rmdXWHkFaYPeOyZUzLtcgIxCaJdO : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int hKwtWwKkVqUbbqTYsfytzOpQJFEA;

					private ElementAssignmentConflictInfo LmDnMRXAnZtLrCehgdpaooddPnnO;

					private int bInvInMstEKuKZyGdFyZQQGxbJYw;

					private int dxbRFeiCgukWnpkRqcfHwcJQzYxC;

					public int jTDbwhtxxZVPcuEJCvRYeILNfySF;

					private ActionElementMap iUZDIviXPNKeQKbCKvmCysSJiHDI;

					public ActionElementMap SRosXIwVMZeNWfkgaeOKxZfzQIKI;

					private bool RxJnKFoOteizHNFURMiAEDhSgCTf;

					public bool frBGTcuXOOvdGRnOrNgVWJVdekGs;

					private int ADPGLsjcsNsIPIMsYzxHGviayxZuA;

					public int GYAgJbaCpzBtczfpUmcooPdgmgySA;

					private CustomControllerMap BRHtlJFVOWQRrWDULebmYllAaidk;

					public CustomControllerMap eMaEOumTuGeCwKHdcVUizgLftfFu;

					private bool mIWmGxJTsSnNFOsPoIDIIpeBZXoH;

					public bool bCPBXCcMINMLuAcKjqNVGLtOXDWWA;

					private bool rmNwUtoCZPKoCaMTUuDpYcyuHonF;

					public bool EYyShuXGfOkYryrXcJybCFsiZLzo;

					private IList<Player> lDHwmQeovOykQvHlFiTUEtTyXygp;

					private int LvMRmVXthAhCAXVKoIYodmCSgrsi;

					private IEnumerator<ElementAssignmentConflictInfo> AoxtxlJfRsAJHpVbkJWtdTEnXPwH;

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
					public rmdXWHkFaYPeOyZUzLtcgIxCaJdO(int P_0)
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

					private void omQnAgybUFEoPEKIUTKxesFpSNLpA()
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

				private sealed class EbPYoHNMrjBmATkSBGfxuPLgNDVV : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int bJzJYjWDoQonyUaUyckpVKNqmEBi;

					private ElementAssignmentConflictInfo nPOypGIrqsZxiGjgDscbNmjtotrA;

					private int ILlZqFEIItLRWwDLfxKirrBishBO;

					private ElementAssignmentConflictCheck iqlzfHYsPKOiuQvmxQwOplZlfGYC;

					public ElementAssignmentConflictCheck GtOdbZuomhFuksqdXWBPMYNXpJxy;

					private bool RAKQEZFVfTZqhqkGuJjfrnRjqGKC;

					public bool iwaRKWxFqUDeIoixQVBpVweaxadM;

					private bool xEtkeLEEAArZVsALsIcSEexNZUNb;

					public bool jCiqyQfTaNTwhIRlmkJiEBMnlrIi;

					private bool lgUviywKhgkFgMmENTpGgcyWbPpR;

					public bool ppaBlHdAJuRQJQCOutTtuUedsEJFb;

					private IList<Player> KVyCyotueUbqnMgJDtchAtCdcMjd;

					private int HwcDrCieVgFwYTkGowHvfhHptnVp;

					private IEnumerator<ElementAssignmentConflictInfo> QadOjqsMlfYRfhhlLjIwDLHzzpiqA;

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
					public EbPYoHNMrjBmATkSBGfxuPLgNDVV(int P_0)
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

					private void hSocMZHMSvKmvjmRVIiRHCHHuaFNB()
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

				private sealed class inxTFZzwASHETkrwIlAdgEGOHhqh : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int FQJLUFbGAxaoQXmDBBpbsoOHlnit;

					private ElementAssignmentConflictInfo tTuqugFUrHiswMLvKvvtBbzBmUEp;

					private int ieZaPflIRvEZjgDmsBTwNwaHGxDZ;

					private int dojoaJcCYLCYyDkgXMoEpnKHFsVZ;

					public int JWGEGpWeMsUKiPrEmwkVFqWFcBjAA;

					private ActionElementMap wIJMmyVNxRqIregrrFUwmVkBaMgR;

					public ActionElementMap QAIsHKqlJqEHkiQAJnVIfEaeojlG;

					private bool ffceAKaXbxDkRxlIDIZePNwTwbK;

					public bool DGLSAyPrObgQYRFxPzZlcanbSmYp;

					private int DDsxTbZVkVTlndLTDGjYgzeswDwDA;

					public int JNKOAgBLrUquHUgYHvguellbJVpO;

					private JoystickMap xhCetnwmGGGYyopatXIPlNRQAKMh;

					public JoystickMap EyKYEedkQUMfvqenxjKRmwAKZgTP;

					private bool UGAjvXAFyLVvETCmjGNHNTVujUAQ;

					public bool NHJAAFJXfKkdECmQlJKybFgDRqkYB;

					private bool TqLbokitYVmxaYckRJjmrqqiqhCDb;

					public bool OUuVZkDTusSYGmitOpHfjriNjPrjA;

					private IList<Player> QGjmFxmExdLNJDjvBwWTNwDQTrjN;

					private int SiThqNbCKVQMVHtJwbtxfzGACFci;

					private IEnumerator<ElementAssignmentConflictInfo> TeUAVCVeNTtTuAfNAyEOfaseGyEi;

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
					public inxTFZzwASHETkrwIlAdgEGOHhqh(int P_0)
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

					private void UXLCOboXNXODgQaQYdeKxGynNGCD()
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

				private sealed class LYBPkskNgrGifuvpdcPOsDUeSEkn : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int HLPSyGisVnAVSdVntEDZAQzRFQRDA;

					private ElementAssignmentConflictInfo RfFPuvGcQCHEcKRNduevAhzsnvWM;

					private int FMyzFLangWnhbDDCNWVvnpRQPPCl;

					private ElementAssignmentConflictCheck vQdAsOAlPiGThklWpjljDUmZbLLpA;

					public ElementAssignmentConflictCheck PSTOdYsNuvRkzdmEcNKjBToOyDhF;

					private bool BTwffBhhXeigdVPyGFfwijDiIRfDB;

					public bool tJOXiHcHtYUMmErYxTmOFdddqtvn;

					private bool YOirYcEXnOwAPDEnpPTPOaGBAvSS;

					public bool VNNYoJZachDywatRMBSeODXrAWBQ;

					private bool CYdmeTUcvxeolHzPzyFTSXQMrVQJ;

					public bool gbfdMFLsHqHNUPPkvnYfvDVWYBhf;

					private IList<Player> bkJGbZjyiScHOtGCCXbHARplAdvE;

					private int oKycZYUjrNngNtkhlsnilGrPSjeK;

					private IEnumerator<ElementAssignmentConflictInfo> zIGGCeEDOHoGhlmjOPhUAjWinOZgb;

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
					public LYBPkskNgrGifuvpdcPOsDUeSEkn(int P_0)
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

					private void ErKDBIFrrbNfRgSEcWbuuKtuGeQyb()
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

				private sealed class QFVetHeJAztWcUPIgEjHHRGEqplHA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int vBNTvBWsyDagVxCxaeduzYjdcMq;

					private ElementAssignmentConflictInfo utmFwuZBaXApgahWhbkIkZlaQFLwA;

					private int MjRpflqnCyZaAJjsfkMYTCarBgGZ;

					private int tNcaiFEfBjdKmsctesjYFgtUliDrA;

					public int DWSVeJpsPVIdLPRfQXADYuSyoaRe;

					private ActionElementMap doKNdslCtRrgcNYtArnfedepGRgx;

					public ActionElementMap kSuijBxstvAofoOukxrZHBffDGjkA;

					private bool GbfckyygvqQPsoGHrFyJjgGFbCmz;

					public bool qcCnvvVeBkqLsLwaLSiPVRJdLGth;

					private KeyboardMap kFeYMuttJhMWCKzMaTtdlaazGAUS;

					public KeyboardMap MTdwmNnCsouKLCJpjgNrHdpzsiJA;

					private bool XhkZHEiyCJQRXzPZQMuNbHttaJAt;

					public bool HOGzXzscxsFGdcDfGmdkVGBLABFr;

					private bool uVLfvMrqsAWKcAhsynKCuTKZIZoO;

					public bool NwzApIxxPwjYqvJfTLHqAhTooERt;

					private IList<Player> PMszMjDnBUuBnFjWgjHpvynVpDZW;

					private int ngstVzwSPwuQONLEjFhPNTOoLaRA;

					private IEnumerator<ElementAssignmentConflictInfo> QurkmBpPJHBzktXqttVdROSAvYBw;

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
					public QFVetHeJAztWcUPIgEjHHRGEqplHA(int P_0)
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

					private void scnjfRqchOLfLCfJTgCChPByJkSu()
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

				private sealed class rXuOqhcCoWgDCbxxcruemiiLUIsJA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int fusxVuTEWukMfbgAkdRKGocKTtSiA;

					private ElementAssignmentConflictInfo nLEqhijhoPpQzvftDKLKgaoTsBwL;

					private int HFbjhkpliUQVkVvNbkRpUStyQSWk;

					private ElementAssignmentConflictCheck YZqQDHlmToEgwHOBrduxbfUdpKgT;

					public ElementAssignmentConflictCheck oIrITLuSvxEvfFAYsZDDknZsryII;

					private bool lwwkTHSPFalJRNfrAroxTecwmRhH;

					public bool aKgMwvRBqHRgZNxmUjmTqpiHBEKhA;

					private bool quHycLItpcsEtEnhSjuOQNMRrLMA;

					public bool yNWowFybgQLXaqWjhIethvljJKTe;

					private bool nqPsYNnETKZChxBRxgsGqtZcufAd;

					public bool MnVQXWVtoGmfgdbOnCtsbVTtarIrA;

					private IList<Player> AajBcXBXrjxxKcZAcdHvAPzgSFNic;

					private int rRhgCDeGnnCyLbSbHDDypvpelDEq;

					private IEnumerator<ElementAssignmentConflictInfo> ZAZVLOBuWlPUzdjjRinnUKGTnklR;

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
					public rXuOqhcCoWgDCbxxcruemiiLUIsJA(int P_0)
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

					private void kTwgODRNrLzZOQsVDkzuUlagQSkT()
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

				private sealed class odgTdlHlpxdHAwFCfThSICpmkdNm : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int ZOIAyaIZjpDDyTmMTxTaSfKXnpGn;

					private ElementAssignmentConflictInfo iBZEubeSOlkFjbbRvgvFMCHabfFbA;

					private int qpIBKecAFaubTEvNxwxYcuisHBXbA;

					private int YMEhThGZjAIlqVRTYskmYxZFgOpl;

					public int aGMNGuWscLOtvcycWLynauAZekui;

					private ActionElementMap HjxpytVcEDyONNYvQBUVeJojNkNO;

					public ActionElementMap ZEHJhikvxnByRgBoKdBVxqxnpWUv;

					private bool xTUdDNRVtjbOWfHSqXmEseIwuyIQA;

					public bool pylPClYFbaianLGLEboVylnyZWmq;

					private MouseMap oRdPHPikmpVctiyMoFxAeabctGKA;

					public MouseMap FqvGrhwqnaxzWoZvvlEOLuZUNMIC;

					private bool oKprWzunNrQuxPSIjKPVBYtlHqSx;

					public bool cjvbjbbOqHUYakPoWKqfDfTCUVXk;

					private bool zKiKZcPrCYqDXxdMcNRBxgarzBhw;

					public bool MRRufueWkTuSfRoneTefpCWDVHJC;

					private IList<Player> ouTORStIlHGFeefOiaQCtrmVXauVA;

					private int CMIhnxwxDsYuZcVniDmSnwwqkufj;

					private IEnumerator<ElementAssignmentConflictInfo> BeqAnzbokpXaCRlqghDMsKWKiloib;

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
					public odgTdlHlpxdHAwFCfThSICpmkdNm(int P_0)
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

					private void DhVvaEXhMousvYXYouMOEgixyVkH()
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

				private sealed class BqOWNgrPARZlJXRTduQCPkoLjrsE : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int JzsMLFNsIbojEFZNYjWKkBtleUKQ;

					private ElementAssignmentConflictInfo TpvtaYnLMIporpeZgpJZbbIMEcFq;

					private int JLOpGHVgUxWelVDRfXPErAiiHZsfA;

					private ElementAssignmentConflictCheck oESjowjCpxmpnuPMgDIqlnEZGpjrA;

					public ElementAssignmentConflictCheck xuxIwqdluWXNBwkutmJtbiTrsrIb;

					private bool xpgpzsQXToLLrPGUaxIUaXzjByii;

					public bool JwbOkpYyjLbFHAzBdRFPPFbJekDcA;

					private bool pwxHGwYtLcvdwWKTxLHakMCzbLjbA;

					public bool lCMuNMjmuMmMtFSZKIJtDNdzwNHW;

					private bool BZaMAlvXstpJHTNcbzGBeNocpxwV;

					public bool RsJwCkSJPhHPIheMcbkGedLmLtSGb;

					private IList<Player> WuaGCifjoSXsvskqkgEgIdZxpLRg;

					private int lyyFsTMasXUDIuGkdogFtDKDxZOm;

					private IEnumerator<ElementAssignmentConflictInfo> UEDwYzCOChcEaGeRHcWqbIzRcqdAb;

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
					public BqOWNgrPARZlJXRTduQCPkoLjrsE(int P_0)
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

					private void MzcAZGdgXDhpPbrbAAijdauToLguA()
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

				private static ConflictCheckingHelper TLZvTctuanUbpdCGgNbDCJPENxue;

				internal static ConflictCheckingHelper FtgiEuhwNktjQsIjkRIoAIrkBiRA => null;

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

				private bool YvAICYPBcwcfDHMiyLsXaYCRhvMoA(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return false;
				}

				private bool lPKATGHgZcoFpoFXNiZTXhYGekDb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool UUFvHMwqUyedXlVdEEfxpvMRifxn(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return false;
				}

				private bool ILfrgFYJRzowKsxDHDrDXBzriqGg(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool LitBlBKfWxMsnZynMjyxEQJwxiQV(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return false;
				}

				private bool ZEKNbQcxEjrfFhqguZljapgdGrzU(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool pfqXsFJLfsICOOvzXbWBCGHDzekcA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return false;
				}

				private bool NKDFulCKrpOgubKtxIQFozylqBf(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				[IteratorStateMachine(typeof(inxTFZzwASHETkrwIlAdgEGOHhqh))]
				private IEnumerable<ElementAssignmentConflictInfo> bMAUKfBrLxaqezveOgQAjGhPxdhn(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(LYBPkskNgrGifuvpdcPOsDUeSEkn))]
				private IEnumerable<ElementAssignmentConflictInfo> mBqPSxAbAigchCrASXZzDVOQuWLNA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(QFVetHeJAztWcUPIgEjHHRGEqplHA))]
				private IEnumerable<ElementAssignmentConflictInfo> TWrOGiImyQffRkhJbriCrrzJOFNWA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(rXuOqhcCoWgDCbxxcruemiiLUIsJA))]
				private IEnumerable<ElementAssignmentConflictInfo> MdbJEEGdupfTKSEqixoiPnyADIoSA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(odgTdlHlpxdHAwFCfThSICpmkdNm))]
				private IEnumerable<ElementAssignmentConflictInfo> vfQLZRSpLijSkFEUIWwumbfVwKdC(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(BqOWNgrPARZlJXRTduQCPkoLjrsE))]
				private IEnumerable<ElementAssignmentConflictInfo> FGwfSmlHiaoMeinaKXQhLNPjFABbA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(rmdXWHkFaYPeOyZUzLtcgIxCaJdO))]
				private IEnumerable<ElementAssignmentConflictInfo> GRwNCWeeAifZaybJxGLfIqjlpSZc(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(EbPYoHNMrjBmATkSBGfxuPLgNDVV))]
				private IEnumerable<ElementAssignmentConflictInfo> ZcRecoTWevaUIdwNemKfGjcwSsleb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				private int yLkIreJaxLdhQPADoAQrEedEAXZvA(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int DMYTTtZKuYjcOPVFnISoQJNHDZbdA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int iApXhcPJPIjBBxjhlLaCElFRPhwn(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int lvlstleFDFRAtpZJujWPNAtpOvfC(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int CvMcDsckZwbQJWlOOkwMNvbUpfzHb(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int eQRiTGiRcpgAtLGUDhzVgzOphult(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int NZlfSkhwMABcwVPynPRzXvVsznHEA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int qEGYEtEqcekHGAWblarxSgCmFyTM(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				private int vnLdYllcftLPNUPebIVcwiPRfhiS(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int HhqUSrwwTARpKoOuZMKUifnDCVtDA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int QZSvDuTiodbOhesMXrAfvbpEgDkN(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int eByGmkBQKhonoidbJFKmPULJKBjYB(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int mFUIdRMBuqjxhOCswpykvgQYIyIf(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int ATNyBKtMFgUJsINwsWNIVmEhFoWz(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int KgrpEYAchiNDSpesSWqyWGmbPUvT(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int BfdwJoMhEPDONDJSUHUfuLhKXyhRA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}
			}

			private static ControllerHelper ceRdUyBnkAOIpDyEcHgJdpuHRMMX;

			public readonly PollingHelper polling;

			public readonly ConflictCheckingHelper conflictChecking;

			internal static ControllerHelper GySsXVdZYErNkJfZVMKZdlvuJFRP => null;

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

			public bool SetLastActiveController(Controller controller)
			{
				return false;
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
			private static MappingHelper APXzibtLjcpyInOriiBUaIuKpEnv;

			internal static MappingHelper PqcMCbYBUYcoZjBUaEGmHtWlXQfXA => null;

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

			internal InputBehavior LBlGbWjszFIyvLfSiBdSeEnQIngG(int P_0)
			{
				return null;
			}

			internal InputBehavior QCqpADItfmPFweQHdqPWqehaXWIg(string P_0)
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

			private ControllerElementIdentifier jYRdQteMlGsKJlCWZaSQjchollQD(Guid P_0, int P_1)
			{
				return null;
			}

			internal int JxZSKbrQKqVhXhMIAMlPvXBvQSGk(Guid P_0, Guid P_1, int P_2, List<HardwareControllerTemplateMap.mplGGTyQiUHloFPOvtXcGcfxCYKC> P_3)
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
			private static PlayerHelper sDBTDbZHJsEyRAjmycRDvXUaaDrGb;

			internal static PlayerHelper eumbLXxMiWwHWUCoaSxeWnHAyvnD => null;

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
			private static TimeHelper ZAMRVfzinSOEPYfQmBHuUahmSkZk;

			internal static TimeHelper lZqJFUWcWarOVaxSKmotPsjLokyH => null;

			public float unscaledDeltaTime => 0f;

			public double unscaledTime => 0.0;

			public uint currentFrame => 0u;

			private TimeHelper()
			{
			}
		}

		private class QycgVSZoQJYfFfDNTURzOhLkeZYf
		{
			private class ZmxsKNOOTUxSkkaZHaePebRxXmAU
			{
				public readonly UpdateLoopType QZQVMoXZsASPJBOHFbMeSnhSHrJjA;

				private double JtLxlmHcUWDoGuDJYnHtLgAairdaA;

				private double LCJpMmOGhGgdCITHAfMmctavFJwjb;

				private double QOlFFlaLEbBhASioVMzFWMwJOSQWA;

				private double XEUnHXVwlKhFyRzmrpylSMRDLtpd;

				private uint JWSiRXEnKKBZeHQomPqkTNzGKCKeb;

				private uint eDbwiDyqtmdkmHrOksqPQpItzzYuA;

				private float hZdSGpxPiIRoveIxSUVpWJywXlXM;

				private float sKOhdKopemzmqvYHDcrQqegRYEqw;

				public double FMOpRJbixUtplUJSpaLshxyBdEuvA => 0.0;

				public double PqkVtnpliNHKnmhPshHHmxcynXLD => 0.0;

				public double svjDQwdGiaWCQxRzCVckCuPMRInU => 0.0;

				public uint ZGXPVDjhkRMOuwwgmNpDizGBCZFt => 0u;

				public uint jXSMcsZgDtehqflBWkSkKCksjPrIb => 0u;

				public float xBPFQpWLbQqquSxnhnQctCnveCcK => 0f;

				public float NBGbyffxYpKyXQdYEpGZXaQQCpybA => 0f;

				public ZmxsKNOOTUxSkkaZHaePebRxXmAU(UpdateLoopType P_0)
				{
				}

				public void dfXEtrTVsmDTvjUqujfAmMOBzcHpA()
				{
				}
			}

			private static class mNqtFEZeZORphmFdPcbJzYTkAltr
			{
				public static StopwatchBase iOkDUsYuHAqECYFGGNzQMYUDpZgj => null;

				public static StopwatchBase tFXkBjePnyjQIkGXlDSDSzoOIulhA()
				{
					return null;
				}

				public static StopwatchBase aWambGrhbgeJvNJFLBAtHGXGUADk()
				{
					return null;
				}
			}

			private StopwatchBase EYsSzOgrHWNmxpgmVBggywJuAHgu;

			private double wTOWkRoCTLIufanRTqpqNBatjHdY;

			private ZmxsKNOOTUxSkkaZHaePebRxXmAU KBthhnAlnDmpURoSyklVhWNCkJgMB;

			private ADictionary<int, ZmxsKNOOTUxSkkaZHaePebRxXmAU> hziTWzDNqUppdRsHwGzFtOsQvHRQ;

			private uint VmxBGktynpVsyvKezNZLYpxJPFcm;

			public double CMrPvnJjkfaUxRXKNVcSdqewQqIJ => 0.0;

			public double MiNuqNgejFHdCFteFCBJQxdkdJLeA => 0.0;

			public double VAqwWMMjelcFaUtVUAIgoMHQbyZdA => 0.0;

			public float OvNIRIMnJRhFGLYvCRhBWggTGmjU => 0f;

			public float JEfMwUQpEjCKsLDOsmPrxdpbjoKQ => 0f;

			internal double WKINgEjrxqbLIfghCGnAdAOcwyQU => 0.0;

			public uint HrqcIkOzaqDuCcJrfsgGeOChLZkm => 0u;

			public uint JmXveELOYgpzHPdoMzlWqELehGNFA => 0u;

			public uint ntYRueDhZlYdDxwGAWqGCoojsRYf => 0u;

			public void zEbtcBPWOpCVPjhNTQahToWtQxdt()
			{
			}

			public void wNpbCNiyrjdBJyIxmGoSdEKmRkfIA()
			{
			}

			public void uRUDXVstTpusGTmdkhsBoDMzVgGE(UpdateLoopType P_0)
			{
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch mvfeukmwokFjyJBqOfOdAQCNpTuNA;

			internal static UnityTouch IkACaRuLHjniyJLbLyBIvebNGQUGA => null;

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

		internal class nljUhpAUKDiyHwbwiSvLtsDzLmoT
		{
			[Serializable]
			private sealed class uunungiDauAGObUJBfKyBcGIofID
			{
				public static readonly uunungiDauAGObUJBfKyBcGIofID _003C_003E9;

				public static Func<bool> _003C_003E9__12_1;

				public static Func<bool> _003C_003E9__12_2;

				public static Func<int> _003C_003E9__12_3;

				public static Func<float> _003C_003E9__12_4;

				public static Func<bool> _003C_003E9__12_5;

				public static Func<string> _003C_003E9__12_0;

				internal bool cpeUdHisaKEZpsbdxsYbgbKdRQGv()
				{
					return false;
				}

				internal bool RIXCISNhlGvvCtLToGsgcOrfJyKEA()
				{
					return false;
				}

				internal int wzFglpoNYveKNgdDGzxajPkiXmEN()
				{
					return 0;
				}

				internal float mpewtkuCOYEhcYUziTHAZmOMaYVI()
				{
					return 0f;
				}

				internal bool jqpEthTbsXNgVzdTibToKuLVyfDI()
				{
					return false;
				}

				internal string YvfTNPHNwqqlpbSTuawweSMEnlRh()
				{
					return null;
				}
			}

			public readonly ValueWatcher<bool> ozELmJNxlYCMJDTmflTfeLoXPvRX;

			public readonly ValueWatcher<bool> exgOaVMcqJzNPZPaYaIqIOReegPPA;

			public readonly ValueWatcher<bool> WjokzjqQTvHhtepttWJzsKsPOCMg;

			public readonly ValueWatcher<bool> qVjlvRZvyNrnNgYXbHLZlktQsgBV;

			public readonly ValueWatcher<int> mYjCXtHjIdAWlmGdMOKpbjlhgqMS;

			public readonly ValueWatcher<float> JSMygGaNYtfUgnhQhxnPMjRLkApG;

			public readonly ValueWatcher<string> NcLArNwPRzZztnwoXWxROFcPEiYt;

			public readonly ValueWatcher<bool> CAkMZjOhdnPwJUuvsKpAYJNDVzmn;

			private int jGuAikbOonUPMNmReQbyOsqPRcwB;

			private readonly ValueWatcher[] EDheJcBRSHCYIPoPzTNByhNygvkBA;

			public int GPdgYkBilkTxXyOzTKoBfEkhLKFE => 0;

			public void osqKLpsvJZLIypHplVVRyUjsUCmy()
			{
			}

			public void BqfeZRdJrflJKRqRJnhjMsVJKdsmA()
			{
			}
		}

		[Serializable]
		private sealed class ZFxihfzfWhfDnqQipmbpXvNqqmjc
		{
			public static readonly ZFxihfzfWhfDnqQipmbpXvNqqmjc _003C_003E9;

			public static Func<bool> _003C_003E9__240_0;

			internal void xmnnLAGeFjbjxYsaBHnrejDHsNJcA(Exception P_0)
			{
			}

			internal void dZGvJALayetQeAhpNqQdaZaWnujQ(Exception P_0)
			{
			}

			internal void MOeegQjkVypXgwHrrWJfKbyBqtrV(Exception P_0)
			{
			}

			internal void uzEBOVijgufccPrliNJcQBkcXDouA(Exception P_0)
			{
			}

			internal void ZHcvlNrMCOXDaAZHSFyEBmbKivNV(Exception P_0)
			{
			}

			internal void xQQjyKhSORbFGweYpiOZRxSKNQnM(Exception P_0)
			{
			}

			internal void CLdxUWADBJpyQHIlNyUqqPPOUDRb(Exception P_0)
			{
			}

			internal void OrkpXAiSJoHQSQqgUDhLHQYeYJco(Exception P_0)
			{
			}

			internal void uHWbRcMsTQtMnmCoQQcbrrLMgmnE(Exception P_0)
			{
			}

			internal bool kpakZDuHmEHOvJItZFrqLywRONGm()
			{
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal const int programVersion1 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion2 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion3 = 62;

		[CustomObfuscation(rename = false)]
		internal const int programVersion4 = 0;

		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U2022";

		private static InputManager_Base zuKKHbGxHqnSeOHyGSxlnByJKecT;

		private static PlatformInputManager gmDoPCdxzrKwqJfVTrDedoEZhClI;

		internal static CwzXRqxjdfgecigIRNkNvibechiYA ttNfSAPkyfecBBQXuLEqHMBGNWELA;

		internal static SaMDqLEhGMRRTtFNyAgzKNYiTsUR AltMWvRZLWCaIUzgvNSoJNjKSSeI;

		internal static iQHfuoCiTVXcGXJbgivNDnvbsgMPA LHYatsorDnPvwjoyvxLFzxGMWrLv;

		private static ControllerDataFiles WPSjFuPllsAiZSCTftbbqGemZfeH;

		private static UserData jRhSKRKjzNyokutventIzyssVgVB;

		private static bool bpjRiowuYPNvkWINUhPfKEBQRVzDb;

		private static ConfigVars DRsogalCMDuQdtRrxuTOcYrNDBCo;

		private static UpdateLoopType ajitnycibJOunuZlOCmijWwrbwqJ;

		private static bool HiphzJRWylgWnNzffuMLOPRIzSED;

		private static Platform DTdGsKtwooCcYDmmnWDaqmWlyFccA;

		private static WebplayerPlatform yHHxUSKcZUJLxJMhfBNXdgJsFFRGA;

		private static EditorPlatform YjqSMYwgphGoHqvGXmnBEfFELibh;

		private static bool WMUDferCCYAbdjRoMdpZEEQLipIn;

		private static TimerAbs dhRnTjsCofuJKcnALaoLEBGhdQMWA;

		private static QycgVSZoQJYfFfDNTURzOhLkeZYf ujcSoNhFvDCQNbdDjKnhVssdKLxk;

		private static string NtfubsezhHTiTdvjEiOTwtHAekug;

		private static bool HgIDzAlOkZbXjRHuJxVgIylfAxYo;

		private static bool aeEtaJNyOnApudcOQSibyEOpbPnBA;

		private static bool ycrHvzCVfuzfQPPvQxbrpySvIoNP;

		private static int zFBRRTgogBosOsFmJaNNvstpKMdC;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int LjLvcKkGENSBpKDuVbDUhfSSpDqK;

		private static int gcShilxtVpCjCfKyCbzLwttzkViU;

		private static bool vUNahYfgaQZnLnIHgXOyfvAviiDoA;

		private static readonly UnityTouch HsXcKsqOnKkptGycQSblrAJrwJVe;

		private static readonly PlayerHelper CVyJNabFWnEKNhCxGZSwtaNLUeNg;

		private static readonly ControllerHelper fIPRaCjBIYtavfFdcKxXkGvIOefP;

		private static readonly MappingHelper QIhrqHNxhyejdJtuaebtNbXTboAd;

		private static readonly TimeHelper OFAjOsFqungvFUBThCJFjIYewnZQ;

		private static readonly ConfigHelper GvCncQoJMWFPzGzMcOudcuFlgfkU;

		private static readonly LocalizationHelper wQNKrifxTzLMGWKAjLwntSyeUxwp;

		private static readonly GlyphHelper tOHGapEtrDfpNBddXzmmwnQIvjqd;

		private static fLbxaCUiEFNmnEWDLEsGSrDtggRU lmoXbchQkWVyduDqKlLHxBIctGDQ;

		private static UserDataStore HMUmFQBUCfiKyDTVCFhMhbdcbYSW;

		private static IControllerAssigner MQyjXdPqtdCgYwbKlPEueuGvGLvi;

		private static nljUhpAUKDiyHwbwiSvLtsDzLmoT HYSVHbANSeDXOFogZtZFslPXyOPx;

		private static int pbFSkkNigCMndAMAAUKEvtxIbocG;

		private static SafeAction<ControllerStatusChangedEventArgs> BnkKdWcKzzchtCoOYjTBAkdinJETB;

		private static SafeAction<ControllerStatusChangedEventArgs> qwUKxkjKikEnzxGPefTRHrgPDaCFA;

		private static SafeAction<ControllerStatusChangedEventArgs> HBCwKNrylKIEScupAjpFuymoDfxN;

		private static SafeAction IAGvZWvAZeBfMleRockHcTBUhSlTA;

		private static SafeAction iaakEbLgUwNjJZPKlwhrfpzFpUyr;

		private static SafeAction cgUCmInHFmnXbTUgJPPjowEhnFBt;

		private static SafeAction oIQSKjtoKNmjGqbXpxooiLcxfllG;

		private static SafeAction wGgZCqkqlyWdUiEAlOhQvGOkGLxZ;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationPauseChangedEvent;

		private static Action aHhobhJYDhxxVigTnBusQPQJfXDdA;

		private static Action<UpdateLoopType> wnsOGETRwUlvZIjjOUqDHNRZyHSm;

		private static Action<UpdateLoopType> MxxQcXyleJlDjMyldtJDBNIrwpU;

		private static Action<UpdateLoopType> tagdJnRpDKVLJaGCGdlaiKyFGQQs;

		private static Action SnAhgacBXPzfYHiGfScWUgoufppaA;

		private static Action<bool> KqgebnlKoXEcYxiMcCrSKlVzQgYg;

		private static Action<bool> voDEhDqRnNTRicpUeCfAEYHJwowLA;

		private static Action<bool> RmhhXmfMKVqcFNAKyfEWzVKpYlGw;

		private static Action<FullScreenMode> XfLurxsZmxDDruOxUXDpiOnfsWAC;

		private static Action QwHRayEfWzUcWHBzTVPThiOCakNz;

		private static Action<bool> igzricFdwDzzWWagqOEokxvtCGEg;

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

		private static fLbxaCUiEFNmnEWDLEsGSrDtggRU CvMoEROCLtGqZIzvqtKcLozUxhZEA => null;

		private static bool bXZXNCTlLZKzmdARMHEjcfiYFNBhA => false;

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

		private static bool DerSPeRkfXcTphWfEYEkvkBsSsol => false;

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused => false;

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused => false;

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform => false;

		private static bool zQnzURRzPuEzTYrGuQWnURoIuITh => false;

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

		private static void otjFSOVbCsOympoOJqanetUNAaTC()
		{
		}

		private static void WtEGMCBbynSSzWAZwrNKGNagLoEJ()
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

		private static void EjefYCGwBxdigcuigKybJgiNlHEqc()
		{
		}

		internal static void GNqdMRVgXvxTlNUhALEiGHHRjfjd(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4, Func<UnityTools.PiLPbHlhwYsdUvbqAeFitwleenxJ> P_5, Action<Platform> P_6, Action<InputManager_Base.rxrZVQSepEQagapnoyyHzwwHNuS> P_7)
		{
		}

		internal static void SRDybknRQvEKLqbKuGYZUTcmDeuHA()
		{
		}

		internal static void wohtOghuhZnwSYULgaNCOGDKuFgF(UpdateLoopType P_0)
		{
		}

		private static void KvhAgOGnEormgaeaJoLTObuikIDS(UpdateLoopType P_0)
		{
		}

		private static void hVRqMRdEQTARGfpdtGkwEmWAAQqeB()
		{
		}

		internal static void wOtScdNdHOguceFGOARABffLdkZC(UpdateLoopType P_0)
		{
		}

		internal static void AuNQfCydFpLuEqqcqMSvepbNKdmG()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static void EditorUpdate()
		{
		}

		internal static void cvoFKjbYKQalfgsIxsfUjwdmFkctA()
		{
		}

		internal static void GUHROXaERHdfqZsrGFpSGNnbcWLjA()
		{
		}

		internal static void vPmppQpDKuHEzlgpdVchHojPrxsi(bool P_0)
		{
		}

		internal static void NzhWDfagpfiAtUYLXlbMvkrBHwJH(bool P_0)
		{
		}

		internal static void OYHCOmPngpQsGjVTnISbEVTyLaoX()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return null;
		}

		internal static HardwareJoystickMap zYYZyZnnhhjNMeZRfbQcPPhQhWOiA(Guid P_0)
		{
			return null;
		}

		internal static HardwareJoystickTemplateMap tbkKWywkpCuBmTiIUEXfCbyGUJKBA(Guid P_0)
		{
			return null;
		}

		internal static BRZfXhCCXgmnPhcExxqIrBLyAiOAA sYvzAyMpPtaryasuJCGPdllWWwIQ(Guid P_0)
		{
			return null;
		}

		internal static IHardwareControllerTemplateMap MvTQklcePDNSsGhpGkBPWbwAfQvl(Guid P_0)
		{
			return null;
		}

		internal static IHardwareControllerTemplateMap VsxJkqpizoOhyBQeyJfOkVKRBpGv(Guid P_0)
		{
			return null;
		}

		internal static IList<BRZfXhCCXgmnPhcExxqIrBLyAiOAA> AOzhexADkudILbqMjQvrvbIPOjLd(Guid P_0)
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

		internal static void daJbBMDARiZpgqYkuxTWoaEhpIJc()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
		}

		internal static float xeWUVjXfjoXEOGhmyLBKLHslZJOA()
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

		private static void NRwXRJFpWqQtyHvWaNDHcimxYywc()
		{
		}

		private static void IZWehkbtRsHcPFBbYsAEZnzdUKWwA()
		{
		}

		private static void YXMWBbLtcZrshXpmtoSWBjIxpool(string P_0 = null)
		{
		}

		private static void xoXEcyAApqkgPmgEbUBZscwpoJKDA()
		{
		}

		private static void jVMpciDQWnENUQRNMtKpvdGJIynA()
		{
		}

		private static void MhafteGtLEVtyimVCzrWvSzNdQlkA(BridgedController P_0)
		{
		}

		private static void NoGwGeopiCDurlsZxAdoFZtBmXHR(ControllerDisconnectedEventArgs P_0)
		{
		}

		private static void ZdUSRqjGctdHsifLCjfzhSWHpIqDb(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void TFrBLQblerImGkyCAkRUKDFIcBsO(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void iOyooMAoMJsimBdjBnVfAzkZEDmd(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void TGXMKgZqBDZxBEEuTKpYZaHSvzHk(UpdateControllerInfoEventArgs P_0)
		{
		}

		private static void WcFpsdNbDhKIZySYMCWaPKUBSIxb(bool P_0)
		{
		}

		private static void ElTLwJleYSpOMPDdfepJwQzzjQiK(bool P_0)
		{
		}

		private static void UdrEeiJDXNtoXUHDupbFVWYtGOkcA(bool P_0)
		{
		}

		private static void XiQTACTeGwniYUjMrfGAGSjERZiS(int P_0)
		{
		}

		private static void qfbWDqVwiqHtcoVcuTBFnMgJmbGn(bool P_0)
		{
		}

		private static void yZSIJNavagVzRDDcqDiHXOtphGU(bool P_0)
		{
		}

		private static void OebXDwQfQfIomzrDLvYfxkgwhedC()
		{
		}

		private static void ZzATJrmJLwTvTgteCGvUiFJDzjee()
		{
		}

		private static void YFHlJksxldbaiwzfilrfVeUrHDob(bool P_0)
		{
		}

		private static void RvnZMSBLKRjRqJPhJOAShTBgNFCDB(Func<ConfigVars, object> P_0, UnityTools.PiLPbHlhwYsdUvbqAeFitwleenxJ P_1, Action<Platform> P_2)
		{
		}

		private static void BgQGXgcevmlNOcvuMLeygcDYjZwk()
		{
		}

		private static void XdqcEbeFAPfoOGazhCnTtVarYqUv()
		{
		}
	}
}
