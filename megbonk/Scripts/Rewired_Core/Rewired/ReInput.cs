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
			private static LocalizationHelper MWawRwxvKldsIFvWuloxhfDAcmBd;

			internal static LocalizationHelper lMNSakUDMjgvTErzNvsXJYbMNrtV => null;

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

			internal static void JWEbFWXEWPdazhmJgPOjvPTWghILA()
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
			private static GlyphHelper YQiOUvuqbbXcesAnPZnWbIJuxlyo;

			internal static GlyphHelper pNVbQoHYOsCtoyWNiCheWFqCBVeCA => null;

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

			internal static void hAhkIWBFtbNtxbiaOqunfIMxNCco()
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
			private static ConfigHelper SsMIjQtEGdAIbdVnxPTUlRNmkHjib;

			private float lHrsgQDznohRFCZlBDcEtWQOyFq;

			private float zFlRcJmMhTefBrWQQiqJzvvTrVES;

			internal static ConfigHelper vvGgyhlFqSqBKlUxheJUCTALHDEm => null;

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
				private sealed class LbxknLXaoWpupemKFFIXwSCeFEow : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int eTlfPTOPiQGGIfLHppFjHfmMOkQkA;

					private ControllerPollingInfo CEchcUACPbkyRUoyrWEJeipvSPcJ;

					private int gEYKPsvSoWeNWjODHBIiERNrnbOi;

					public PollingHelper xPydgSiSQgknuvPIeAiMAbCemsKpc;

					private IEnumerator<ControllerPollingInfo> TCZhiIeHFgSnwnUIjxvXNmUwoMEBA;

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
					public LbxknLXaoWpupemKFFIXwSCeFEow(int P_0)
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

					private void MiGlTiqCsnBWJcGzTPBrIfWaKRrh()
					{
					}

					private void mBerNMLptMjoSWOrGFBsaekLvYujA()
					{
					}

					private void nZmIcNVmTLzctDPCtCHZixihangMA()
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

				private sealed class tCEIaYGmrHeHOcQlIYhKyocPdbTZb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int dvguKzLSDkGyPDBkQZdwXvfbRSWT;

					private ControllerPollingInfo yXQEvpMXprMbvCnOYgOdAJOHKIWxA;

					private int dKMeeHVHcgWIqgwBMoWUebuhdXui;

					public PollingHelper mAWSqZcBGycfpcqGBPrTovZdFubgb;

					private IEnumerator<ControllerPollingInfo> BmMBmCEXCbtpubqPCnPcuPtXaHcC;

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
					public tCEIaYGmrHeHOcQlIYhKyocPdbTZb(int P_0)
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

					private void YCwHewzzsdBJkJMPtnBRFyjgCarP()
					{
					}

					private void uBpzFRCDPnoRWapvgDepJbtJlTAd()
					{
					}

					private void tnQzqyTFFugMmtNmtMIShyJQjHNT()
					{
					}

					private void vhtfBaqgmeQaUPTXWNjthGRneLFe()
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

				private sealed class nGvBSCAqPShoJeZHhGSBISlpmnIXb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int dgpqZvIWYLVdRjkbIuATQjszFiPH;

					private ControllerPollingInfo chsrJBjTRHrADyLzrErIbluxslJt;

					private int uKHqRlwFYhjHVPBbIbZKHncvqvveb;

					public PollingHelper QdxyLGhUUsNaZhDtkgYCpesYblRm;

					private IEnumerator<ControllerPollingInfo> IiAhECPEESoPuRpRSBtPAbjpICfX;

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
					public nGvBSCAqPShoJeZHhGSBISlpmnIXb(int P_0)
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

					private void gMaqmCypylMPUXgTiMGRLgGhfPMKA()
					{
					}

					private void PiEYcnMNLFtAbAUOhCsLiUtNmLef()
					{
					}

					private void DrKrnCtqXTDFZJifYGvMVMfpAXB()
					{
					}

					private void NfCWhAUnDVtUjWwVtiCsPKasbNPj()
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

				private sealed class oTkCDapjmBEiIEczLgyosMvcQRByA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int gwAGZhOAEZbnBduXoRiZJlbNGUoy;

					private ControllerPollingInfo RgLtjYAYjtvVjUfhvepDZUHWInSv;

					private int fvbyOpLEQNmozvzhYDwVqiBCVJWo;

					public PollingHelper ujnSYJfFdZjNfiPCfphEvgPwjQyeA;

					private IEnumerator<ControllerPollingInfo> WVpKwhJqbLJIVFCDKlyFQwfOvfbK;

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
					public oTkCDapjmBEiIEczLgyosMvcQRByA(int P_0)
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

					private void qzxpnbARzVdWKxrRppJEBqAArggE()
					{
					}

					private void zgjeaejNmHUxUyZGxRUqtGjITeVl()
					{
					}

					private void qtVDkKMMMfeSGjetyEAgOMTdaoxPA()
					{
					}

					private void MQdXKunvcoKMwPHBiIVMjtTLsNfl()
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

				private sealed class QLnehulthsLYbMzBzWdmddokHNYo : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int VCkpAuKIEJVUYfjzoeVeAMtVnckbA;

					private ControllerPollingInfo XZLTsYrrahMeaUsXXMsRvjoOUBap;

					private int dMbvsTDiOSsxSlXbCyxQzeKGfjXB;

					public PollingHelper DyWZsuCoTAEqeLJLtKIvyKhJlBdO;

					private IEnumerator<ControllerPollingInfo> inCDdozmVFXwPctEwMAzAGTTCNOw;

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
					public QLnehulthsLYbMzBzWdmddokHNYo(int P_0)
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

					private void MFwxvWaawBzOxqyfCAlhmpfnpyed()
					{
					}

					private void HqcXkiPFqokTgqFAtbPbcfwRJCsDb()
					{
					}

					private void IhhXDBoPYoHkODyfrvnkWgcbjhcF()
					{
					}

					private void JqAsVmFXKflVAwURsbEStvVfTlVE()
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

				private sealed class QluwQEPBOkddpOpHnCHJqheqaylaA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int rcAUgMCkftGYQVMBxnEfnNBdqHfS;

					private ControllerPollingInfo DcqsAiYVKndhAbenQAepiyQwnzFNA;

					private int PRFuOZFpuTiqMgVxsZzCUuTAzZoB;

					private IList<CustomController> OzNitxRNhGtTlmasAaMDPpSRhWfs;

					private int OWySHUpblUaeaIRjkjIVRZKsBFqF;

					private IEnumerator<ControllerPollingInfo> RiNDTIeQlXeWfaqacNHoifeeLMeaA;

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
					public QluwQEPBOkddpOpHnCHJqheqaylaA(int P_0)
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

					private void oEgdeYBltPRbDLUERKyzDCczVyAo()
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

				private sealed class ofbGgHCDkReZzxpwHAlwiZueCUmHc : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int geEclTiPcLJNiqcJXKQLHRmXAoSoA;

					private ControllerPollingInfo vVNDgXSJFbwHiIpDPFqurwPcELjhA;

					private int whCTfAtOliWVPnSPzWyfkZHRuQno;

					private IList<CustomController> ppSXOCqJMACcTrnqrHmZmZBpzXhA;

					private int HnresyyAmTucRgFnWccQEDsUjAIB;

					private IEnumerator<ControllerPollingInfo> ImjCbnnhgDgijIBDRUlgDqWaJexM;

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
					public ofbGgHCDkReZzxpwHAlwiZueCUmHc(int P_0)
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

					private void CIHvgYOGsYGqShlwGnTrVFiSipZFb()
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

				private sealed class lBWQgZhiluCHdnjlTdwgnrzKthsH : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int RiHxyEGQZuexyIHtzHJzeNumAEmDA;

					private ControllerPollingInfo dIgKpFURXcgjgjvgCkXCnCzfnMIAA;

					private int NrYLNcEtRifRpdLVkiESDvnwPbLp;

					private IList<CustomController> VunjJToaIFZfmekBvQmtWTyJHQzP;

					private int gIoKilsTwwJzXIXeiGQmBsSSLRYW;

					private IEnumerator<ControllerPollingInfo> naGeegSomRdpUITnHGJyKJBQDdrc;

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
					public lBWQgZhiluCHdnjlTdwgnrzKthsH(int P_0)
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

					private void dvIVKJhOZOCUgLnwLblYLdgtiJIj()
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

				private sealed class WiLEcKpizPEXoYkxSWteyJQbaFAJA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int GuRxHJyrtIeFTWndresIkBjYZYUSA;

					private ControllerPollingInfo voeHeiePHFCmwGaRaTQQkophtTNA;

					private int vfdZULNnSirFOQlqlPcfIdNQRjET;

					private IList<CustomController> qyQHgnojIErySvtMnlRGXtRlCADB;

					private int VcqsxxhvhMsiCbihkUXWsXjCsQHe;

					private IEnumerator<ControllerPollingInfo> LpdLyTfsKOOYDnEJlavFgLjpyBtb;

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
					public WiLEcKpizPEXoYkxSWteyJQbaFAJA(int P_0)
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

					private void LAiauXgKKmXrSadMuiOyJsqjcDmlA()
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

				private sealed class imVpNAgIuXMrPtXkORnrrlRVAsEs : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int GRADjNLTbQiBoSBNJytFUmOkGwwv;

					private ControllerPollingInfo jXJgfmwasRLMMalRwzXFormocFfK;

					private int ypmrwZXHBtzNRhDGRSrhLSbRzqoc;

					private IList<CustomController> zJvinwLmHLaBWAQPchCdHbmGCUsac;

					private int pHAAYDWmgeaLpzqQUvqinJIfdTthA;

					private IEnumerator<ControllerPollingInfo> UBEHIscexBHLFAzkYJzIzwMDVNFIA;

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
					public imVpNAgIuXMrPtXkORnrrlRVAsEs(int P_0)
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

					private void EOZJiJcqKDecjIwBbkIAtYIrMuqc()
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

				private sealed class otLaTehQAdMRuGMiBgTLAVnrmhKzb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int VpOxszcRXcLFbLKNHcnUOtUlcwn;

					private ControllerPollingInfo YhFeIiJTojOKWzFKNLtqaaiaqRWK;

					private int MNzhYepScrQQuoiXXlTxoqwVRRHD;

					private IList<Joystick> oDaXDvdJZioQsJcOoXUUZrxCBWlR;

					private int NMksiiilIoAVXiFYTcxWUlFQolTo;

					private IEnumerator<ControllerPollingInfo> KgrAosichUntbTMGeWjSZCdjNVQi;

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
					public otLaTehQAdMRuGMiBgTLAVnrmhKzb(int P_0)
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

					private void BrkBKLEseuqqyLPeamrbtWuacBXuA()
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

				private sealed class OxrIMHaGCTcKcRqyqsnpujbOwGHx : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int tBTWxwCjjHrCCOQGBvMyMHgDciWG;

					private ControllerPollingInfo nglslTZHaFkKOWznwuBHoJJzMPzs;

					private int ywDnZgwsNIXWkswmorDkMrIskJYL;

					private IList<Joystick> AbctoBIykkOXkGuPvPnYdhHVlCXl;

					private int hVzegXEiIIDEMWQuGodpCasWsIEGb;

					private IEnumerator<ControllerPollingInfo> dEGsGwfdfryZmUSNIEdhJgIdMKfW;

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
					public OxrIMHaGCTcKcRqyqsnpujbOwGHx(int P_0)
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

					private void spcLOGpMjZkumOaDZbUMEUQaqxsY()
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

				private sealed class rGpAknQxPLqfJIfEpQOBDojKYgQq : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int nQlBDiAvFMffxUmwuElIDQiEymTJB;

					private ControllerPollingInfo zhHgfupMBppaoqlNkDaEoqFtorgG;

					private int ROtRDFXrndCaqGCOmeUUebkoJYSDA;

					private IList<Joystick> LeRsoQyhhcbXMdWiBktnMrPjwCCuA;

					private int prIEjaqxcdlwqRyfqLuuIPniUkSN;

					private IEnumerator<ControllerPollingInfo> kPYdRtIDiocleOdYzoHIWzTnsDsaA;

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
					public rGpAknQxPLqfJIfEpQOBDojKYgQq(int P_0)
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

					private void qLgpeXqkaLJRkBrOepbctaBiSDyO()
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

				private sealed class RItzhShrPtQRVEoQwlSRzhozGdwQ : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int MTClvqjeuSyTllZYeSkkoaXwQKpK;

					private ControllerPollingInfo KYIriFEUHyltJMAFhBOOfFXbvkjUA;

					private int yijaZfBfBCMVojvPnVAejGGCWjrt;

					private IList<Joystick> kVlfhbigUdGuZqamcaPaQANFvERf;

					private int SPgXdZDLInABFpquSdTbWciXFAiI;

					private IEnumerator<ControllerPollingInfo> aKaDFUUpgWZgneaMcnJBAJibBRTaA;

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
					public RItzhShrPtQRVEoQwlSRzhozGdwQ(int P_0)
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

					private void myhfXfEOKRJhHbShgqiUYaEbnJdX()
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

				private sealed class NwiGUNZMGXFtIJelTMslhTjoSAvE : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int KdfqRfEohfCXGRzvpCNbDtFTNPSn;

					private ControllerPollingInfo BZIbOvJKlZQMAyzIIqXmNDitGPmW;

					private int OofAExAolzTIBsjOFqBRaBtGodNHB;

					private IList<Joystick> XFgfOCgePQaRjmCiSfNSaqeotfdUA;

					private int ZOGbPVgzRZOQtFuTDiEcJXMvIOwPA;

					private IEnumerator<ControllerPollingInfo> vkaYlkTrHueiPAIYrggYdBsLhyLj;

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
					public NwiGUNZMGXFtIJelTMslhTjoSAvE(int P_0)
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

					private void vbwZrpDmWDDLuBGZBhokHSfgrsGEA()
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

				private static PollingHelper jxVdFNdbyQOIeEmRwVBhfqFCoEHfA;

				internal static PollingHelper ezpMNRqlHNwGvIKAkwIlNidDWmHk => null;

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

				[IteratorStateMachine(typeof(oTkCDapjmBEiIEczLgyosMvcQRByA))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					return null;
				}

				[IteratorStateMachine(typeof(QLnehulthsLYbMzBzWdmddokHNYo))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					return null;
				}

				[IteratorStateMachine(typeof(tCEIaYGmrHeHOcQlIYhKyocPdbTZb))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					return null;
				}

				[IteratorStateMachine(typeof(nGvBSCAqPShoJeZHhGSBISlpmnIXb))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					return null;
				}

				[IteratorStateMachine(typeof(LbxknLXaoWpupemKFFIXwSCeFEow))]
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

				private ControllerPollingInfo OXVaHOAYjdKtbSBaegbXFiFMCekLA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo qbQElThwPXfMpBgvhGLqIkvhbjPEA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo VpTmldACmdClIrggNJjnkKdmCmsaA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo eHIkvkyQdvAkFpnjndaZjEBSPgvO()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo tnAAmMcSLtAfIuqPgXICtrYPVyxdA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo OmiibIVRQfRlhKsQqcBqpRHpszFp(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo VUfKNABNBSRECErmRdBKfeZUqkkyA(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo eBUPqdFqkNfxPcbeTGHjtvFgQUOU(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo ELUFYSDdSVBaHcblBPGtWaAiZuNCb(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo CUQeWOMzLQURJjpXXclgDIiniwVOA(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo asvZbjKzuIHujPFXmcRiYDHnMqtv()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo MOeNyVhUWfLSmvPeJkFLPNqbQIOX()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo qVIMROiEmnEQgkOzyPoRlfIasQHF()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo avIbFMDeKyomZbGBbEGtRxUNMEDTB()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo RlGpFWIeDtwjoWOrxsxIbLPFnyNL()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo gGLLoybiDsqzrKtzIQSLAIytBOLE()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo YOLzLqRQmvQiTcgfqywjwseiwlSW()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo vLwNRFEcSpWDuXUMDEJGiqlJCHoY()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo nSUCljpXKGXyjPjpNiZeyWKqEkNo()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo qCiOISeqPcEbOigfOnjNzCAUGKKOA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo KNNBhzFBpVMUMyZFPXhmRFCwFmrZA()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo ieuepobQwmAmjrLrfNwinxUSqeyW()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo lImcgruXtMPnxoYWcAGZWidHCYbe(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo xKUfAVoKiNjnlcRNfucHTNiCQPTq(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo HxMoWBoUcGeoGEZPQNzGquTNINFe(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo BZHlKQBClSPKaOIBumEnoofHiQxz(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo AMxvJJkruPvBXQUVnapqOQEHiwqd(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				[IteratorStateMachine(typeof(RItzhShrPtQRVEoQwlSRzhozGdwQ))]
				private IEnumerable<ControllerPollingInfo> cwyPcsvyyCaOfTygnFeyicXaPNXk()
				{
					return null;
				}

				[IteratorStateMachine(typeof(NwiGUNZMGXFtIJelTMslhTjoSAvE))]
				private IEnumerable<ControllerPollingInfo> ePQrdtMUEcrVeLsBAfcGDFwDpcybb()
				{
					return null;
				}

				[IteratorStateMachine(typeof(OxrIMHaGCTcKcRqyqsnpujbOwGHx))]
				private IEnumerable<ControllerPollingInfo> jjPvnqbgpWhFBkYdWrCGRlcfPpyv()
				{
					return null;
				}

				[IteratorStateMachine(typeof(rGpAknQxPLqfJIfEpQOBDojKYgQq))]
				private IEnumerable<ControllerPollingInfo> iwdLpKvKrTMFjkhuHbDeFiqbwwjPA()
				{
					return null;
				}

				[IteratorStateMachine(typeof(otLaTehQAdMRuGMiBgTLAVnrmhKzb))]
				private IEnumerable<ControllerPollingInfo> FIQjwCLEPIWvQKUSGSftJKtqTjJ()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> QMrAjQrHSGDmoJBnHIkAAzQWTBRU(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> ayUFCOJfFwrPRacWFaAkSyTKYcmrA(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> QjlaylClJNLYLeALgUlbQsqEFbzRB(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> SBqyRxUmpEKYrzOUYeJgRArRaERkA(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> GNegJVgQTCvvALsdSfKZqnvMQAqY(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> SfihWzhLRxQTQeLyfaUXAbWKdpyx()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> bKVDrvdXtztvEibPxmoftcGuHuYv()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> CVuCiCVjNzGdTZhWBJKiuZFjTcKu()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> YboPcTfilNZNqHkoabKVJMEciEhrA()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> uCoYGQeYjzalhGxZdFVwxDVeCBKz()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> QvzxvhdbAsTfsIfajLuCehawhXFX()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> LoFCoWtjCbeUNhZdvGbSOBQTJLtP()
				{
					return null;
				}

				[IteratorStateMachine(typeof(WiLEcKpizPEXoYkxSWteyJQbaFAJA))]
				private IEnumerable<ControllerPollingInfo> WdOGqCxHXaFwZYzVWaALIzVelJOp()
				{
					return null;
				}

				[IteratorStateMachine(typeof(imVpNAgIuXMrPtXkORnrrlRVAsEs))]
				private IEnumerable<ControllerPollingInfo> WcFtWSBTMjcsMowpWjTmSFOgaNdT()
				{
					return null;
				}

				[IteratorStateMachine(typeof(ofbGgHCDkReZzxpwHAlwiZueCUmHc))]
				private IEnumerable<ControllerPollingInfo> jyqnfYvlmEjsFHtBrmqddZaFsYoec()
				{
					return null;
				}

				[IteratorStateMachine(typeof(lBWQgZhiluCHdnjlTdwgnrzKthsH))]
				private IEnumerable<ControllerPollingInfo> fbMjQJqnzkqPkJCeTIIMkGOFpIlUA()
				{
					return null;
				}

				[IteratorStateMachine(typeof(QluwQEPBOkddpOpHnCHJqheqaylaA))]
				private IEnumerable<ControllerPollingInfo> NWbapdnhhrwpwlPoKVjYMixSzCcr()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> wgMFTTigmXqROzqhioJlatEJeLglA(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> XbOogXUFZCLZRPrRjLeZBJyTCOeq(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> AwqmhOYoqbEunAORzbriWcaDrBXSA(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> QBlhCoznAMCxjczFfzhubkNXbHBCA(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> TVqaEJmyfmbUxuaNDghjAQkEaZTvA(int P_0)
				{
					return null;
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class mDaYTNxMGTRMWCPyIlNGybkkVgeC : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int waFGtGiFGQQjvGYYbpXUEzKBBJWFb;

					private ElementAssignmentConflictInfo QgKunFQMNAwUrgImVWDOuybTppcM;

					private int mbeCtlBHJRTqMrGPEiKjImIJbDDy;

					private int kWecPoajybpJtCBdJhEbSuggwneFA;

					public int azOFtlyjNGYgqEsOnHDesSDzZbXx;

					private ActionElementMap vvAwRdpbvQDlYdsHlpPadoQjbyIPc;

					public ActionElementMap BKrneKxasYdHCHTjNaUgkvnJkALdb;

					private bool WwYTlHlXaplLBrdMousaUwHgMeMo;

					public bool yYYRLmrygNIGSbZHAShpEGXPDoZv;

					private int VgYHowlEAKnLyyrRdJnTrsLSbMFB;

					public int FLOXjiJDqcCsEJcFjKCYXjoIaxAc;

					private CustomControllerMap KYYMnNKNwFndjuIZggCGAExmoiwGb;

					public CustomControllerMap xPtdYwflGTPrscmmDAiKblZFApGeb;

					private bool jbTrcpSAIFDOFicCZvwmEMapFLddA;

					public bool cTIXOIVkHAafiKHgIlTfZjVaZRBC;

					private bool kgWtyxzUtYbuYOeRfkWVKosQLHsX;

					public bool HRhiQmUNNRijrGwGPFSBIWmSXPiY;

					private IList<Player> kwUgvExZoHNAELJikryaKiXMqMpG;

					private int QhDPHPAoPLpGWjZBPaxYbgCsFwzs;

					private IEnumerator<ElementAssignmentConflictInfo> NVqRphAHrdrdDBNkLbvVlyCJLsbJ;

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
					public mDaYTNxMGTRMWCPyIlNGybkkVgeC(int P_0)
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

					private void pNPWXenWmCXBLaZJtyxDghPTLkKK()
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

				private sealed class PbMyzRIJMwHUnvPdaXBHiLRWFaYc : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int cQksNzNOUDyZsuCRPeKRRhNYdaOv;

					private ElementAssignmentConflictInfo yyMgkxHQPpgirfYsHYYWJVyJsbeg;

					private int TQmkePRuVqkdGEYDOwwCjVzCvIYc;

					private ElementAssignmentConflictCheck lmqZzPZbMREzgizoYiqoxorPrzTL;

					public ElementAssignmentConflictCheck NjFExPpuOcsHqCNqqdrbWNPpPDmw;

					private bool WIPcIRbEfUFmnGSbKDpVoxvDUsHcb;

					public bool vTbiBSeOKFqRIOBgptrJZPcIWakr;

					private bool ohigeckBsXsQDGSXVyuOuYkdHFVbA;

					public bool cJjPqCgEISsehcWaTgCCMfGPstZS;

					private bool cDRRzwjUPrpNcmQRupnsabuynLqV;

					public bool yuxfaDTxYrzsPwBIRreNSatHWFMg;

					private IList<Player> LelWYegkQXOUbgRhatFVSazLfskfA;

					private int EufhJOlgfteLSAhHXnnPdfXPNxYOA;

					private IEnumerator<ElementAssignmentConflictInfo> NPcxsarVDysBlTRiquEADVTFrJpj;

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
					public PbMyzRIJMwHUnvPdaXBHiLRWFaYc(int P_0)
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

					private void wdlIEPPqseXttWUuwWunWHwIeuYe()
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

				private sealed class vMuZBTmzUJfqDKSkrcPNjkCuvZvY : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int GZMfVJmfcimDIxDOwhBFhuKvwlxgA;

					private ElementAssignmentConflictInfo aIzyCgSQFQTpgcZmdLvJRPbjKzRG;

					private int toGJgneClcRopCzfLKzCRDcxidEN;

					private int sLeluHfSaOrlctTbeiEetJMpfeCZ;

					public int UzZdQpFoipvbshMPZcSzXsAvRZoM;

					private ActionElementMap zQOaWyYkLYPMxGcuAguGgIkhKSvG;

					public ActionElementMap XINCaGtVXjxpcSuLkiJwzWIYCccx;

					private bool quoGsYdFxwvkqhboliwpLsFMJVwOA;

					public bool GmSWqqAecmtHGjdiiFhLcBpTSaVS;

					private int IIhPclUcCIWavJEYwCXgvQmIlJnQ;

					public int CILETqGLRPXgNqNJgCvQySlPJHcm;

					private JoystickMap oEBrmbnygLtzsUrxKGjtzOLilQZO;

					public JoystickMap RLDMMoomDLGVpCyEOcHnkfEkaxSg;

					private bool BdBkhXJpMGmRKdzzErbdVHtEEALF;

					public bool OKKGIBIFJFWfAANXYmOwToclijtd;

					private bool UtGkcsgiICQfoErPaHHWweVSnkFD;

					public bool PvrBvcYApxlIQIeutpuDxotvXHoe;

					private IList<Player> NjoRtpjrPaypRpDmacBdBFDkHlqn;

					private int TDGbsZeroGQxXpKYNqBFbOYkYWnv;

					private IEnumerator<ElementAssignmentConflictInfo> UfFYMMYhQMnQiinehfCqhsoEhEXq;

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
					public vMuZBTmzUJfqDKSkrcPNjkCuvZvY(int P_0)
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

					private void JsUWIrbyvSTzyeovbpLezsITJDJS()
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

				private sealed class SbCgMibMEkRyfMNiKvkkqYAGMhhL : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int UQEstUxhtygtELgyCrQzQvghSbQh;

					private ElementAssignmentConflictInfo KxOHLzNuaPwpuaECYDOPdApIkdBMA;

					private int IhnrbXnIWNvUpvRHulkLnZLmWVLS;

					private ElementAssignmentConflictCheck qziewSNIxnigrZHFEUFFEFshdXWBA;

					public ElementAssignmentConflictCheck WtWBSIabhyTejCHzRCnZsRZsIikfA;

					private bool AxuxBuWdbABfdsvfrTSlXVotLay;

					public bool mJDcfDnBLLdJcseXQYBuFNjPtiqI;

					private bool DDpQvuDBBJNZTdlyYhjrWRGdbvJF;

					public bool QyMjKBWhUkaHihUMbOjEJKNPXOSBA;

					private bool TlgxgZFIHmJJzflGONKfGrOaSjXT;

					public bool pYupzZWWvneCSxspSNjDbiZcMlim;

					private IList<Player> cmYgQjDuULgZJYZHzbzjKWHRLMavA;

					private int fRlsiYXVNAbUHZmeQGAQhwlhVWxN;

					private IEnumerator<ElementAssignmentConflictInfo> enREaDSipMpzcGmvlPuivOkKCIEc;

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
					public SbCgMibMEkRyfMNiKvkkqYAGMhhL(int P_0)
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

					private void BCRVaGsFDeGCHcaBdDNYGVzkwXFJ()
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

				private sealed class LWUjDzWegrhedcFbDPtpPShmjqSB : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int iRUFTbeMGxALcTpZACWZOuMZMuJJA;

					private ElementAssignmentConflictInfo hzzFPwKGAKzEiSpTQTQsHVrAtDMx;

					private int JQMQnfpomphqQlhzOYuyDhaLPsJN;

					private int cmfkGNgznqhgsKkGZDpcqdPgqfWD;

					public int YFVcPmFmYCHjfVdGbgblxAmGrqUDA;

					private ActionElementMap aiPxNsqTDKvOypBcjONTuLaBTVxU;

					public ActionElementMap zZntlLwFXgAFpSmjJUNvVGhXDAojA;

					private bool FliiiozYLveeaSuWEJSjnTMvCWvN;

					public bool prXdnpEGStPPTPhbagwjEVHBZXoPB;

					private KeyboardMap bGvSVwmrAmbsQoLnJlXPludDYaHF;

					public KeyboardMap ZfSiaqGsgtOFIUmGOoCptBbHXmpTA;

					private bool ElnBEUnupWgCFROnduBfnrrVJeTd;

					public bool GvBRjbxnKrFipEFepMOKDUBpnBAM;

					private bool jaUDzWqQIXzxcuAbZiyecLIlIPzQ;

					public bool OgkhzEqmjhVloFpcahpKMGRYoISp;

					private IList<Player> OdlGohCfvHkKtjTOHhONxbLrZWIe;

					private int qbrEtTJdcYkHCHbUEznFYTNCmBxDB;

					private IEnumerator<ElementAssignmentConflictInfo> XpsqIZowpQKuuXhfKhMTZmAqQLGf;

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
					public LWUjDzWegrhedcFbDPtpPShmjqSB(int P_0)
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

					private void dXaVpFliNDHaXjcMmEksyzTMrkVrA()
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

				private sealed class kExoFjltYXmyMXoqLAbMisonMNzK : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int yFjZrgAgcljHrNBTJjzkkumojGBk;

					private ElementAssignmentConflictInfo sHJyyeuCUQYEpLgqaqwwadgfGajBA;

					private int GoqajuoSUHQeepxGApdTWJrKKSXL;

					private ElementAssignmentConflictCheck PTdDHNwKrdZQahnKUOqFrLAZWmjH;

					public ElementAssignmentConflictCheck phkmWNhDDoqzdzrZBivzqdXGthHU;

					private bool aqrmgDLsfrlUNrIszqFJXKyGBauKA;

					public bool tRngwzYtQAXOJnVlpIadwmmzGETI;

					private bool xchiowITFoEFMPscWDFSQYRifdQLA;

					public bool niZyoXpbBXskmMBDQAyLdtfNDXWEb;

					private bool wcSwuRcAaZLevVdYApQukAxAdsFKA;

					public bool PfYPdUIOWXYJuZZtSZXKXTkNlIZF;

					private IList<Player> LmckOTURmiOiYdZuBdrPFjIwZsID;

					private int kKcLwFhRHoOJHLXsqspQpOrALZVK;

					private IEnumerator<ElementAssignmentConflictInfo> EpKPiEWfekjrhTSckBvXWFMrmSyG;

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
					public kExoFjltYXmyMXoqLAbMisonMNzK(int P_0)
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

					private void twnMmBAjRWAoWqCKyTJCGbwUAQjKA()
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

				private sealed class rqbePhCxJyBOIUQIMjvcaEdGFeESA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int EhTjaoXVTkqsadXTeDdSKIIpNnBo;

					private ElementAssignmentConflictInfo niQOGvbriajJhFUESDJhCIJObfMFA;

					private int fUFCCkZxjhUFVNQPWToseaEGDDQe;

					private int FjZdVhJJLRvAazoApDUIYDVjKeun;

					public int tVVIpaHTIQzixEflhfqXwEupccpg;

					private ActionElementMap EdeixpOqySlBPficrcIdkFoDBqCM;

					public ActionElementMap MhWAdwtKXsALVfCzpfbfNnlLzKFVA;

					private bool oVeNJEALgxxKVrJDeWgqsGAusDRA;

					public bool gLqUPfNuJduBfjJGjhCfJejYmOpcA;

					private MouseMap puCFDXBKCxoeuLXrvflRDAwJLpDgA;

					public MouseMap IDuZKjxcEnSUGEFSOOPyBxusTRJm;

					private bool plaWIprSveNmdtqPCtGhJsxLqbRl;

					public bool rdqRtlejYKtjyOdhfPsPLINyXKUo;

					private bool eflDkqIgsPcmTHWFBvnltEcFZZyr;

					public bool BsWZcatToOKNrvAvRyhZfpGjOTYy;

					private IList<Player> xVWZTYeADWeQsVDZXHiwdmsvaetJA;

					private int LhVdxntJfbmjXCqkBCdifUsQgcyW;

					private IEnumerator<ElementAssignmentConflictInfo> EPrpwrvSBsLPIXnNXteeWUHkxHxD;

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
					public rqbePhCxJyBOIUQIMjvcaEdGFeESA(int P_0)
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

					private void KMWNbISZwtlDpcCLVQCmWkgNtafV()
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

				private sealed class EDNBMyIkxIskBSnIUfYaYHsvZjpgA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int ATtTIJYPiyOaKtVYbXNcqStNALRH;

					private ElementAssignmentConflictInfo AxosnCgMoNKOrDIITtJdbPKqeyUK;

					private int KAXWvNQRmwTrdtDQIdJszoqQRFlK;

					private ElementAssignmentConflictCheck rTuaobXVcZChcbPNxsCnlCxFbiFb;

					public ElementAssignmentConflictCheck eiqcWecIZZfqZaOzYNQzpwiNcyuz;

					private bool iepvwcPNxxcitjCFLRXuuibTBHfL;

					public bool MDiothZKPMowRwgUYlBnPihzFaYs;

					private bool oDmCusDbjpIQmkqKEdvIhqYFJXiPA;

					public bool crVFWIsaUDbRjxHKtpSPXpjJLNUL;

					private bool ItjIjhamIcwSZhlfUkaxkBoQcppw;

					public bool MXGOMqPxXseeYBByLIfupDwOlnFC;

					private IList<Player> ZpxbWkbwNXMklQGrXNSWaCNVWzGhA;

					private int quniVZTfICsUMAbjKjYzxxOrkDBp;

					private IEnumerator<ElementAssignmentConflictInfo> HXYKxfXifghaisKSkmHKOjlxifiL;

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
					public EDNBMyIkxIskBSnIUfYaYHsvZjpgA(int P_0)
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

					private void HdhGLIaqpSHAXBBmzHSBBoslOHlQA()
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

				private static ConflictCheckingHelper MHWFxDcaQoCxrPHVXYbbBOPyOBbBA;

				internal static ConflictCheckingHelper YEcjaYfaAQMInnWJSChyOOGHkFnoA => null;

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

				private bool VQBMMOUGUvbSTqjvVFYdCbInJpFQ(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return false;
				}

				private bool qCFdKHJCYhtPZCCGuLWdGHzIaevDB(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool RvAVuInupnYbJDgujZXFfvMrrcml(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return false;
				}

				private bool DEsyvZHBxaTSIWFKwlZhHuxBosVg(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool SHwxbDgudiVGzUFgbEgHIlRSuKZf(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return false;
				}

				private bool WUTfoWlIwaEeXXNnXREBoeiLgvex(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool yefefFSAPxdKAmhsqHglSZRbcghS(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return false;
				}

				private bool WqRfDkgokcTYgsANYhDeDFzgKdSpB(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				[IteratorStateMachine(typeof(vMuZBTmzUJfqDKSkrcPNjkCuvZvY))]
				private IEnumerable<ElementAssignmentConflictInfo> unTAotOgbcBqgBBhbqLyrdEnnXie(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(SbCgMibMEkRyfMNiKvkkqYAGMhhL))]
				private IEnumerable<ElementAssignmentConflictInfo> pQtMKpHuklPbvXwDpldXDfCmAMIQ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(LWUjDzWegrhedcFbDPtpPShmjqSB))]
				private IEnumerable<ElementAssignmentConflictInfo> KdaCIiHvSRUXTNOEGKOktQjbZbMk(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(kExoFjltYXmyMXoqLAbMisonMNzK))]
				private IEnumerable<ElementAssignmentConflictInfo> RkoSGosKitgWcslVdYGNlsqcGleb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(rqbePhCxJyBOIUQIMjvcaEdGFeESA))]
				private IEnumerable<ElementAssignmentConflictInfo> seBZVHNfPzAYkDfTvNeEDqxaluqLb(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(EDNBMyIkxIskBSnIUfYaYHsvZjpgA))]
				private IEnumerable<ElementAssignmentConflictInfo> GJrBQskaEfOzmUWfdGcLNJRNfWUY(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(mDaYTNxMGTRMWCPyIlNGybkkVgeC))]
				private IEnumerable<ElementAssignmentConflictInfo> PstBVUCnKvKYqpMiWUsHOUuRybGnA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return null;
				}

				[IteratorStateMachine(typeof(PbMyzRIJMwHUnvPdaXBHiLRWFaYc))]
				private IEnumerable<ElementAssignmentConflictInfo> ENYiqdUIQevMQOWuZoFexeMSugCb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				private int pHlJOmGhXSBQMfRKNimFhkfcBVEMA(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int ANJVkzGAhJZbAhgSYwvIGFVzTNqH(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int lBclGwKbnPylHLFaSGEqQCHvpvlN(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int sEedijHvfANqpoLCHsHzvHKPlWaxA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int HXMJaEplChvDLBHrbOoIfhzgngDc(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int zjKmwErhKoTBxxmBaEHbycOXTeeu(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int AyYYytVkRFLarUlWdbJfTDSvJQI(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int xEFGzzBMDpaeImfkKCsRKLCIgPAJ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				private int gfSeAvedZiVcJuvdGtoYeiNzEhtP(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int MvlOcvlAlHKnYELpswrieWvpPhoj(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int DMZUjcKROeRGjQJZyZnHxfrsgZxn(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int pAjmcNDcWqUazPwMiuKREDwwNulB(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int zgHXAHNvCvPEfcufLjZWxwOsoWHw(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int DGCTwImbvvwGisplXtHyXYcDgNJe(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int JwsYjMNTPfiwEJbplUdGCiqVdQyy(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int AXyLvwJalShDJbFbhaJJTBxyoZqF(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}
			}

			private static ControllerHelper jiWGSeYHGFoxfdZDDMOllYuzEYRu;

			public readonly PollingHelper polling;

			public readonly ConflictCheckingHelper conflictChecking;

			internal static ControllerHelper FyJBOPcgoBuDupaIwfgrtYxMkJCS => null;

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
			private static MappingHelper JdWgppmJprNfSDcUJfjicuCmEDeF;

			internal static MappingHelper GTbAVtDSmZFtThSDZsTEnuQLIPmj => null;

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

			internal InputBehavior SogqMIsqXYZfjbPyHOfiwLheLGfP(int P_0)
			{
				return null;
			}

			internal InputBehavior LPnqvRFCVpaoeDMSKAUidihGYDZMb(string P_0)
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

			private ControllerElementIdentifier sTCvlflKaVuJXDHTupAwdbkUPpRn(Guid P_0, int P_1)
			{
				return null;
			}

			internal int CzOGRtuhkxKjXZEZlfVhlDBVlCDY(Guid P_0, Guid P_1, int P_2, List<HardwareControllerTemplateMap.jKiaMLFrsZtqsedKIgXIoKaJmIXiA> P_3)
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
			private static PlayerHelper lsGTFlUoddPwBLprFxSjTIKMPyuh;

			internal static PlayerHelper zFdPvXckAVlFMqmDXZoCOQxqieis => null;

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
			private static TimeHelper EpXyDvyXQBpbHcmcVdzMAFhSjISq;

			internal static TimeHelper qSzhHORdgtnQNIZRrmORDYfrDgny => null;

			public float unscaledDeltaTime => 0f;

			public double unscaledTime => 0.0;

			public uint currentFrame => 0u;

			private TimeHelper()
			{
			}
		}

		private class NXntoKYmASjXZXGYiFiFOWHQBmRV
		{
			private class WneYqHZIzHIKsQkMiSojkoZPonHG
			{
				public readonly UpdateLoopType NaDIiyWgADsiNdZQmigOUajiJtSv;

				private double CdGnvmOLiNDZIGYIpUxTJcCQHhkZ;

				private double SxKAIgFNBNKAIeeYzyfKzcoPJXtT;

				private double LgFuxItsqElEYsjwRmhIbkvUERk;

				private double GrBwrRCmQLxMkdMgGHDLcAWzeRepA;

				private uint KFRHwPVFcTdmocUxTbIGRjlyDCDBA;

				private uint rwwkvLvHdfPaeHRUHAzvfCLVbUBC;

				private float ctmSDbeGYZNLhYvklbuHARgMjYAG;

				private float bBLbhUvpWxLqoDGOaJDssqedYGbY;

				public double IhXTVLcsXXEVrauBIliAvdivHCnX => 0.0;

				public double WZhAHjFkLKlqzbSyCRZpXszlArIGB => 0.0;

				public double tgxQgrNMbxnMfJwxNKKsWNkQOsEA => 0.0;

				public uint GMYNmVkrAIngiQvpFXHxyDItCBCu => 0u;

				public uint cSTqisMPxsGFiLnEbwYIALyELXkF => 0u;

				public float eAMQDdHyTXuXoidwErRWpajDGalfA => 0f;

				public float YkThkneJeeANRkjRvgipePMeottpA => 0f;

				public WneYqHZIzHIKsQkMiSojkoZPonHG(UpdateLoopType P_0)
				{
				}

				public void qhEvzBSAYxubMqhOPPwjOAOrqAkc()
				{
				}
			}

			private static class zyxJzEUHjFnuxCFokiHnabFQWlcUA
			{
				public static StopwatchBase dXdCYsXxxJdkEgPPrNEmOFUdHjfn => null;

				public static StopwatchBase mNOTtvvdFtkjWuhOWNgxtqmeImwJA()
				{
					return null;
				}

				public static StopwatchBase tFddoxhcFjpLhVvGcHbNCBXHmMKBc()
				{
					return null;
				}
			}

			private StopwatchBase JvnnYYrsrNJovPXhiVYOqEJOMTjt;

			private double xsFuUJnJbSvxzKbEiPOINbaTVFww;

			private WneYqHZIzHIKsQkMiSojkoZPonHG VeJbxwuRMmEAmAJNsBbKQTMOPvNA;

			private ADictionary<int, WneYqHZIzHIKsQkMiSojkoZPonHG> wQvCVtCGVJUVtxUVRTIdxqAeFmWC;

			private uint QDcFWaexLojJiPLpYIlpSnzfTitJ;

			public double JJqkVhWqYoZerfeNsJnoxMyQpARr => 0.0;

			public double ZHWgJBviLMGFIbEbwbrpSpfIePMv => 0.0;

			public double ORtiqEHdOeoosaKMdsuMsyLiOmCp => 0.0;

			public float FhMoISLotUIEEzRcvbjjSMihhmys => 0f;

			public float WOwOCYRHeilngzIFZBMFEvfVFuRNA => 0f;

			internal double RYJipQwsLzCKIJiVrXymrWuAeUTD => 0.0;

			public uint OIhDKuPGUlNHEWpqOAOmyzGFHwbk => 0u;

			public uint CaOmSSOkyfEBXrotrXrgoWPEUhSJ => 0u;

			public uint saRTFqAdxccxLeRJxEyipAcNWoBPA => 0u;

			public void eliotXKcegwAXVQWmGMVBcCTdwmi()
			{
			}

			public void nEcfQPzIBuBkZcGoDoCoDKAQpssGb()
			{
			}

			public void hAZwLXnLXahPKFvhJsPrikRDKFZKA(UpdateLoopType P_0)
			{
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch tyoCeebXQzRYepJbpecVCKObFRpQ;

			internal static UnityTouch VFRDcLvtvaKVkxVechtavSzzeQNkA => null;

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

		internal class grarPbZeaWHeNWYzLDyprkJXqKlh
		{
			[Serializable]
			private sealed class higdwpHftjyhOhHHkNJWjHcdgaTAc
			{
				public static readonly higdwpHftjyhOhHHkNJWjHcdgaTAc _003C_003E9;

				public static Func<bool> _003C_003E9__12_1;

				public static Func<bool> _003C_003E9__12_2;

				public static Func<int> _003C_003E9__12_3;

				public static Func<float> _003C_003E9__12_4;

				public static Func<bool> _003C_003E9__12_5;

				public static Func<string> _003C_003E9__12_0;

				internal bool tUptNVxhYXgyzCAgSmHDufQNAPZi()
				{
					return false;
				}

				internal bool MnKGKUIYHBvGMTkWHPKMICtRlyNS()
				{
					return false;
				}

				internal int xCStVxfGgcidFJfIjVVQlKmGwQPK()
				{
					return 0;
				}

				internal float jKptwafwoLqjykLyRixeZEGmfuKEA()
				{
					return 0f;
				}

				internal bool mJySSpGmNMFuJDrSZAJIOUFlPaIX()
				{
					return false;
				}

				internal string DhwnXJOiGfQXhFzCZqQCcKGulrAR()
				{
					return null;
				}
			}

			public readonly ValueWatcher<bool> ntLarNIOJJlFNloxYbHDcTufbkEi;

			public readonly ValueWatcher<bool> rCrkGRXqSIuuFnetbglSQgXGhcAR;

			public readonly ValueWatcher<bool> HGrnqjzunyDgjERsAeaPstYrfIPs;

			public readonly ValueWatcher<bool> xXevzTGmOSWbLIGYAChztZrmSsEs;

			public readonly ValueWatcher<int> zrwOGfSNikNrzOTsdOqRhglHSiTU;

			public readonly ValueWatcher<float> SZNmwQviyuNSsXfRCdLbiKjtkicab;

			public readonly ValueWatcher<string> OaMjdVxcfiqMhRNrudibjYqpmaBNA;

			public readonly ValueWatcher<bool> JVhRijTDRadNJgmmRiDwKCJpibvZ;

			private int edvEYcHowgXtHjhvJmmJOEkdJFzqA;

			private readonly ValueWatcher[] ZmqCFcCOaIDjEvuAMDpbigDGelpbb;

			public int DdowqmABUdSoNKLFwogdvuYTMBKW => 0;

			public void pHtXkfvazWjjiDfeEcjvkNfWhGdjA()
			{
			}

			public void CgcJCXMHLawKWWCYwJVhyVArdjuc()
			{
			}
		}

		[Serializable]
		private sealed class MqydstgkVuOYXHWDMnGFGPlMkcfPA
		{
			public static readonly MqydstgkVuOYXHWDMnGFGPlMkcfPA _003C_003E9;

			public static Func<bool> _003C_003E9__235_0;

			internal void gNsHySLUpsOcjsqtgXxBriJzZvQI(Exception P_0)
			{
			}

			internal void saBTFAEdQndzkeOugqLFoFgimWmf(Exception P_0)
			{
			}

			internal void HXpCiWswzfPgwChySzxZMawxqtkW(Exception P_0)
			{
			}

			internal void jQLSLUqIdfBqOBaCXnaOTaVWPOtC(Exception P_0)
			{
			}

			internal void CUpzcZwGeTsIioJQfCEwTezyfrGW(Exception P_0)
			{
			}

			internal void yITnjMmDgKvSYCETUBqhEXGcxGsMA(Exception P_0)
			{
			}

			internal void DisgpQDTlIkKcBnNcnMogkZFeAYUb(Exception P_0)
			{
			}

			internal void PYpNyOdHhzbyAeNbfPDrZWGQJbji(Exception P_0)
			{
			}

			internal void zuHXxqVdYZsKdIEVlogJrAbmccibA(Exception P_0)
			{
			}

			internal bool aPtVnOHFLhBCwbeSHFDtBSNkglabb()
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
		internal const string majorBranch = "U2023";

		private static InputManager_Base opFLklNxznlGmaBxjDWTrcengRhf;

		private static PlatformInputManager fkSqyEoBXmZbktvAoWHGzsEfCvkx;

		internal static LNoVScqLIaVgcEZncAPtalYUnldD sCEeWKKKGsiTBubOBJiMeUByAWBkA;

		internal static NtLLFFJOcFyvZRAWZFOVWxCAkgNv NIcIKzMsdHTrYgxdKlvUJdhmSWnq;

		internal static dVAByoXKtOXwKxgqDcLtnCbJXcVr AEJjrwrcpqpGwBKrAvxtlpIwWvQx;

		private static ControllerDataFiles XwHQzyAkXlzITwDPKeLBqmcCPBzy;

		private static UserData mskbWAgXRWSDcAOuXkFDzdyGVDdfA;

		private static bool iDoaxepFyYCUwmDGjxXRIVvgLboF;

		private static ConfigVars AYdchkuWcYrjfPxeOhQuosvpLIJi;

		private static UpdateLoopType jJrzSsjcHSzjrGKcneaGnluNxyhH;

		private static bool MeqYfJSRkaFHhngkINGpKJHaIfXEA;

		private static Platform QyqiIwEKtdNOJKdYClEPkQDWDfrA;

		private static WebplayerPlatform dUCODYNhhXyPxlHqMhIftHLIHTWS;

		private static EditorPlatform DtrYYGjIUehvROekefCpjMdsqHiBA;

		private static bool HjHyJiqikFYztNqhvpDhSKMnunHo;

		private static TimerAbs ijOTydnWEwikUWVTmQilPeMHFQFu;

		private static NXntoKYmASjXZXGYiFiFOWHQBmRV hjluCJiHVMMtFPgSQToXRLsPkCsQ;

		private static string AQilkyfLREIoVLQophOpcJFylabN;

		private static bool UwJpGSsMSugdDvrfovOICzxHpTec;

		private static bool dsTcFNIPcwMfaBmHrIJXakWFNBwI;

		private static bool fuTplxJRljOMBtcpAFVMlKVtwQcA;

		private static int euIZBNlLOQNuOYyQiQmjvdoPYGiJ;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int YjOBdCChsYkvrcuOydVkddWCwddFc;

		private static int xXJmSjqchuESCBrjlsLxmjrVKRvx;

		private static bool sYGnHMzOABOYJeKEFsTCtCYXiExc;

		private static readonly UnityTouch GBCbeypusZcLlHcnvNsLnjCJSwECb;

		private static readonly PlayerHelper JQhUXoyvqotSJVHopftAxrgjgYChA;

		private static readonly ControllerHelper oDYzPKcIaFTGnHKoLBJjiqpmmecRA;

		private static readonly MappingHelper FrqxtNAEBhfRjHzwHfSFVuvxXjTt;

		private static readonly TimeHelper ZNRaKiYPMwyNBsFAUwvpjcWSwbMr;

		private static readonly ConfigHelper ZyBoYCbNsHeqlelJNMjHoYFNvVnI;

		private static readonly LocalizationHelper xlGrjcoxtebmQaKJSGWLfWeAbpvl;

		private static readonly GlyphHelper klKbMzdBNSMSFZfaelNEskbeHplpA;

		private static iyoobKLbmIVXtqfUoYWeQpHPutOI sDfvTwiIzDJPnArshdlWtYDSMcSd;

		private static UserDataStore MPTRtAOQiupDcrGOlALcvlhWOAXq;

		private static IControllerAssigner BdjufxUlUqJhMWSNQkrEcjEJQOgq;

		private static grarPbZeaWHeNWYzLDyprkJXqKlh MDNZhtFkmtqnGWplopTteeTfYNQg;

		private static SafeAction<ControllerStatusChangedEventArgs> KdfvjKfIHogWzCsRzshriBvXTRRu;

		private static SafeAction<ControllerStatusChangedEventArgs> vPPhLkgAUleYfVHAVqzbFjirEkPp;

		private static SafeAction<ControllerStatusChangedEventArgs> EOZCwJaVLPbAGUearVybykdSlXkd;

		private static SafeAction TRBDGWitkxKvCNCgXIJxBRRuIseD;

		private static SafeAction lcbUurYcafDSLrlFKbNTBzxbNCxiA;

		private static SafeAction bqBGwCwObvMidvClyWtHuqCTMJIP;

		private static SafeAction nJPAUdayCGfTIPMAUiVOecggBnyNB;

		private static SafeAction jMxYbcpGLnWPAEdTKJXuhBQYGNiZ;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationPauseChangedEvent;

		private static Action vcejenKXjgGMBSeEUOIAWXUvRSOH;

		private static Action<UpdateLoopType> jgtKTEAUOXMhJyJmtYvvBBZzVOFh;

		private static Action<UpdateLoopType> JZggQsDKJfuWPFJlUDXjAJRhcamFc;

		private static Action<UpdateLoopType> cZxOrjYXpBHsZIgRvWZYqswjgIHv;

		private static Action TINdwidinInOYpLXYUQuMOqQFjqz;

		private static Action<bool> JmdBsbHqyMSfWQDTPqmkAUxBiMBQA;

		private static Action<bool> yXMdjJneXMgaiEEZTsLoOYLdlgzZ;

		private static Action<bool> OhaDNawXqEDPRlKHRecynaKPmpZr;

		private static Action<FullScreenMode> EnMxyvbxriamjMTPrmbBcPEDAiRy;

		private static Action VPMgwkNBgkTJEvqsapenbhWskTAG;

		private static Action<bool> xnmwjmMXGEEUMwNzJWcOqflLxQJX;

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

		private static iyoobKLbmIVXtqfUoYWeQpHPutOI HXPIeDXtdkTpNBCcNheCgSjwcfSP => null;

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

		private static bool AsePDcULXCoJbDwczmxAfWFQSKbg => false;

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused => false;

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused => false;

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform => false;

		private static bool efuAdNJQNnLbFAyqfFkHTCRmSeUcb => false;

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

		private static void ZMnYKSzvTwNuqWfMpIPLacSTBNEc()
		{
		}

		internal static void FCtdvICrQuxSXlSRdnjaCOBvCvuS(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4, Func<UnityTools.EeMzBLeLNTmTALqdvIAKIfdYhceUA> P_5, Action<Platform> P_6, Action<InputManager_Base.cTcfTFkZGmYbaxIwAeCKOJmCeHrfb> P_7)
		{
		}

		internal static void BKAnWkqoVepSBSDxHiIhUcAIcDnf()
		{
		}

		internal static void xXgznigbMSNMQiKZPUtgOaMoimtv(UpdateLoopType P_0)
		{
		}

		private static void TEsGiKBcqrbZyGChifpzaWcgYSKjB(UpdateLoopType P_0)
		{
		}

		private static void ooCEDRaNiUsiUBIuMYHWkuQsCGpl()
		{
		}

		internal static void xXRFCqHSPOoTeWQAbCypQJplXvCFA(UpdateLoopType P_0)
		{
		}

		internal static void NPKZCYzkHixeYCejPMyXsyrbGClK()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static void EditorUpdate()
		{
		}

		internal static void bxAWvRKaFOCxUCFOrXggAfYhijfA()
		{
		}

		internal static void NHMUwZfblECmerScjVMcDuzVGNAj()
		{
		}

		internal static void kDlBdUywnvekhEHuAPhXDDnHtzhUb(bool P_0)
		{
		}

		internal static void SuccEjJzImYLzBeRwBFssvldrRWFA(bool P_0)
		{
		}

		internal static void RUWDEcKFSmQHAJxAENkLCPTSXkvW()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return null;
		}

		internal static HardwareJoystickMap exTyFDmVQeeFQOEzYcKWDnowUADC(Guid P_0)
		{
			return null;
		}

		internal static HardwareJoystickTemplateMap cIdQwwhZFZakqxCXtzETrBeoaDRS(Guid P_0)
		{
			return null;
		}

		internal static SUKBHhZFjtXCZDAZGqMkzjNQboJY dluSpeRthiKDeScdqaMrfepwkqFp(Guid P_0)
		{
			return null;
		}

		internal static IHardwareControllerTemplateMap BOAuWfrsxMmaqcZwjQNpWCywbqaK(Guid P_0)
		{
			return null;
		}

		internal static IHardwareControllerTemplateMap IHqafewZZxKcypItLRBmyUOldZBg(Guid P_0)
		{
			return null;
		}

		internal static IList<SUKBHhZFjtXCZDAZGqMkzjNQboJY> VleaplKDxbROVDDdGzeXMndpNSQbb(Guid P_0)
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

		internal static void cchhrDiWoYVmznETBnXfCykPafRpA()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
		}

		internal static float oVzCSJgQJqNgSWiiLBlxEVXBUBMzb()
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

		private static void QefaFZaCBdijmWzkBdvxzeuNsEfTA()
		{
		}

		private static void TCXbyByjlbDNSlgLvoyuploROHRb()
		{
		}

		private static void NsDNIpCCIWEAniptQhGsFFQBqrryA(string P_0 = null)
		{
		}

		private static void mQobgRdNnAZHAjRYPnxqRyNpPDw()
		{
		}

		private static void mWIGbkaWeZdvPLgKeRFeodfuJWjPA()
		{
		}

		private static void ZEblmSyfnDQqKWEefHbanzFnEBkF(BridgedController P_0)
		{
		}

		private static void AFTIjofjWRPJbXQMGRtILPzlFNUG(ControllerDisconnectedEventArgs P_0)
		{
		}

		private static void EWXhIeefMupwyWcEppLPUKGzvKvu(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void UDmsVGuKOkTlYOARhcQuBGVmWZxy(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void dXhZuOBLEKODcvkcqWJJAitnOAbQ(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void SjCMxkAUdOEtFotxiNimFDNqvEMm(UpdateControllerInfoEventArgs P_0)
		{
		}

		private static void FaWEfuAMJipvXrKVtSemqPMfTWLx(bool P_0)
		{
		}

		private static void BICIRHsTiBnSKtvqOSFrmLbJbbzq(bool P_0)
		{
		}

		private static void TgygoiErsOVJYfSvZHnxXIdTIryB(bool P_0)
		{
		}

		private static void MkBSLSWGorNxIcgZAmRiKalkHOzi(int P_0)
		{
		}

		private static void lxwFZiKAXjIekWpKDxShnmUdtSJe(bool P_0)
		{
		}

		private static void xUMGEZCrVlfgfjvEHcjCDFSGHdZMc(bool P_0)
		{
		}

		private static void HFafLFFLDelbcWPqwCVomdqYcvmKA()
		{
		}

		private static void OuZaPtcxznDiLUYmjtakAqLrulhoA()
		{
		}

		private static void PxWgpZazBagQeBWkcFZJDVinDRYmb(bool P_0)
		{
		}

		private static void WyoUDEKiVYkhstiiacdkFRGdVdRG(Func<ConfigVars, object> P_0, UnityTools.EeMzBLeLNTmTALqdvIAKIfdYhceUA P_1, Action<Platform> P_2)
		{
		}

		private static void AMDRCsbgNvrSEIzbzRdUyjXofBjdA()
		{
		}

		private static void GMxJyrxCsAbZGuscOXFxvNgXyXJK()
		{
		}
	}
}
