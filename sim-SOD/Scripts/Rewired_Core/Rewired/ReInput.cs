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
		public sealed class ConfigHelper : CodeHelper
		{
			private static ConfigHelper AWOJhGqjpBzbLGeZkcaDCwPLWpY;

			private float aOkiMtzaooOTuislSPCmzDWugjy;

			private float HWXmdvffFohWDZyPhoKoWQGlqEB;

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

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class ControllerHelper : CodeHelper
		{
			[EditorBrowsable(EditorBrowsableState.Never)]
			[Browsable(false)]
			public sealed class PollingHelper : CodeHelper
			{
				private sealed class eBvXZIaRDahYlWDXooatDXqSdhM : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public PollingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public ControllerPollingInfo IdaIvIIxpKzNJCiBuQPGOKrIwtT;

					public ControllerPollingInfo jxgKkhCLYgfFDjxZOkaFsvyJymI;

					public ControllerPollingInfo yLlbQznpJTBNDxNPTuTAXfrImmQ;

					public ControllerPollingInfo KNOWPMsxhIbHncIfCURmzZlNOcI;

					public IEnumerator<ControllerPollingInfo> VAhForHfnzuaApgKylpyPirflAYg;

					public IEnumerator<ControllerPollingInfo> AnPoVEDdLsxIOCAmpJMTopxSqpW;

					public IEnumerator<ControllerPollingInfo> sSODtwrZBwMlRmcCrLMPdAQbzXm;

					public IEnumerator<ControllerPollingInfo> PvOvIYwHxhJUaYbrWDXPywUDEes;

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
					public eBvXZIaRDahYlWDXooatDXqSdhM(int _003C_003E1__state)
					{
					}

					private void HpQVDxnRhCTSLhcEVsSNfVimXBY()
					{
					}

					private void cSErcyqtjrWrYTjGYLSIserRgOC()
					{
					}

					private void mVcTjJDlcFReygOwGNXfDNJWOJV()
					{
					}

					private void CMDYhmHCmuExvERzossjKbnzhCB()
					{
					}
				}

				private sealed class UJQTgSKWMLsioOKkvowoOhavoOa : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public PollingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public ControllerPollingInfo YOVDEyfFxzINuMtmuMIMMqfmnjbW;

					public ControllerPollingInfo ZTEoVLgEmPbXxdYPHGGgYwdaAGm;

					public ControllerPollingInfo cyxdznQYIcjteIfxJhlnMHXDPIY;

					public ControllerPollingInfo GcrkbfcBdLWlYYcnKkrutMRagQO;

					public IEnumerator<ControllerPollingInfo> OvcexyakhPSMrVOveEmFRPYNPez;

					public IEnumerator<ControllerPollingInfo> nNFGdUKFKVqLJzAwJWohTJvAApZ;

					public IEnumerator<ControllerPollingInfo> UKWmLdjuFPXiOzCsOYqpcfReJzp;

					public IEnumerator<ControllerPollingInfo> fwwNlQxeDjeezkFGxoqpGgliheZI;

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
					public UJQTgSKWMLsioOKkvowoOhavoOa(int _003C_003E1__state)
					{
					}

					private void VmESGMhzVkYbuQASDzpFOhFshNL()
					{
					}

					private void QNRXcIxpYuWdsIQZDfXoXgpftkv()
					{
					}

					private void FVtQBvHEKAkeNplNkeqEjcQYlKiP()
					{
					}

					private void rDYSPFYgiwLMoTCDxsgULoiyutS()
					{
					}
				}

				private sealed class TNOOoTwBojpEnohqMbrrJfryZNXm : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public PollingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public ControllerPollingInfo ebLhGpHrHnMkDKwbgteXcEcwpnBR;

					public ControllerPollingInfo ZevgQBgrrwmzzAzjyQDtEWmwspB;

					public ControllerPollingInfo roLBSHwkuFxOasEdoHJfcQnfouqY;

					public ControllerPollingInfo gaslsMOBsZLQNxrKiHqcRFRXKHz;

					public IEnumerator<ControllerPollingInfo> dJIljcfhUhqqFDRPGPGxMNQDxiW;

					public IEnumerator<ControllerPollingInfo> IfCNIGuRTpAExVxdFDSgBjymERIg;

					public IEnumerator<ControllerPollingInfo> onMAIzbpOMKxDGvcGLcIIyVQLTcV;

					public IEnumerator<ControllerPollingInfo> pHvqQoSdGygYHXNKRiwgPpLSwvD;

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
					public TNOOoTwBojpEnohqMbrrJfryZNXm(int _003C_003E1__state)
					{
					}

					private void beRpFUtBnuLkfeVXNhtdsLXBglz()
					{
					}

					private void wXybqxjClkNclOSFiLNAVIqeslR()
					{
					}

					private void soGcOeOukgabhTmQXyzhwkstQMq()
					{
					}

					private void DrOQuwaXWWGxwnwcfehBnHWPgpO()
					{
					}
				}

				private sealed class QXcrXuSuXQTdqVKiJDjoBzVmCzD : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public PollingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public ControllerPollingInfo YWhfvypYKJjveOQcLLgaIdgCTsv;

					public ControllerPollingInfo RBjaLavncKjXIdBttSslrOpWmoMH;

					public ControllerPollingInfo eIgBKbzgYkdNeamflscgDiKJfNLa;

					public ControllerPollingInfo NGqCWpIMQifPMfyPRllMtkXFvnIP;

					public IEnumerator<ControllerPollingInfo> UbAgdgBvplXGxEeOkstwAfZfoYP;

					public IEnumerator<ControllerPollingInfo> OZZdDsgVLcLQzzEuWEyugmoyUWM;

					public IEnumerator<ControllerPollingInfo> ijkCkntPTneqPbkKBchJvMXYeNd;

					public IEnumerator<ControllerPollingInfo> clzBmmknLYBUvjwIiqUBCgRIwRZ;

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
					public QXcrXuSuXQTdqVKiJDjoBzVmCzD(int _003C_003E1__state)
					{
					}

					private void rDVvpONJWtfyUsBNnCjzzryyxgO()
					{
					}

					private void dWJvQvNNBABrOxuqjrgICDyaBGqC()
					{
					}

					private void KAqsnvjlGPMZOqJTmQIEldGOKia()
					{
					}

					private void pKYNKRKaNLuayLjZlTIxNeedgUq()
					{
					}
				}

				private sealed class xQSPJcZpMjdqoAIcdKAjtYJgCMye : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public PollingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public ControllerPollingInfo SLZJpIRjnOkKXuzlYbmRIwyZeSu;

					public ControllerPollingInfo bZfGbhggwYKdnhwOHVcHNbkyedRs;

					public ControllerPollingInfo qcIhaAfpaefAgiNSGpksNHvirkob;

					public IEnumerator<ControllerPollingInfo> dnEunEELYZtOSKqbVRQpgjAYQIF;

					public IEnumerator<ControllerPollingInfo> vcNSyLySPmIuLYsbwdAwWhpffOT;

					public IEnumerator<ControllerPollingInfo> qUrLYmLsrWEYdmknpKPcWTiwSdg;

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
					public xQSPJcZpMjdqoAIcdKAjtYJgCMye(int _003C_003E1__state)
					{
					}

					private void IHmVcFccJRBJnhItyswZLSKzLrH()
					{
					}

					private void QUdqlJjttkMXuMhclUkYdhCXiCs()
					{
					}

					private void SlaMJMJElAXNLuwwCBhEuSwYlas()
					{
					}
				}

				private sealed class ZrREWMaaKqyJlJreJNBTaTgRPZT : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public IList<Joystick> SJftUVdxjGbRyTcgGEyOfoOuRQoN;

					public int BobqXHOUParZlBuTCGLmcMVmCHf;

					public ControllerPollingInfo msbCDnTGDGOhEMyPwHNrKUQLUou;

					public PollingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ControllerPollingInfo> rMPaMiSHqEbrJhWgrTZphlcGsfz;

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
					public ZrREWMaaKqyJlJreJNBTaTgRPZT(int _003C_003E1__state)
					{
					}

					private void PCYDVeiaxblwbBXrIomqzpdkhdVQ()
					{
					}
				}

				private sealed class JMNaiWAGFrJNqmYvXCvAfTICQlYD : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public IList<Joystick> XYyBGFDTknueexRDELEGWhzOlzXT;

					public int tCoCdddCrohIxZRaHhpskQkQkbyR;

					public ControllerPollingInfo gDpWuPYSAFvYVyjZJHbkNHvSVAb;

					public PollingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ControllerPollingInfo> lwNWUViMiTbwEVqPTdNBGftrctLF;

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
					public JMNaiWAGFrJNqmYvXCvAfTICQlYD(int _003C_003E1__state)
					{
					}

					private void RChJabvBNUaRSDiXdCjhjKGSIUVJ()
					{
					}
				}

				private sealed class NtTOmXfrldxNrZLTZKEbWCcffIA : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public IList<Joystick> WkiKeoDgFuQSOTSYSrcnotgeahL;

					public int NXGcKKOZRCpVQpZGZqBFOchxIWTE;

					public ControllerPollingInfo NhxBKFGEzzbinlNjPFzvdFqnpxqf;

					public PollingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ControllerPollingInfo> uLoDkEkSzGdaCztjDBMHjsqBxYow;

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
					public NtTOmXfrldxNrZLTZKEbWCcffIA(int _003C_003E1__state)
					{
					}

					private void ShrJfZnfEhDwrLXCEKjrufPJGUYC()
					{
					}
				}

				private sealed class SOgNHQsxBBbKuTmZkJRVfJsBaaZd : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public IList<Joystick> ZkgoWhYcqvccmskLxrVEtuqZtUk;

					public int ijVJMXKwckwihDSKMecFxmzgmww;

					public ControllerPollingInfo XMVDogDMrzJDkJqZYimFhsicArIJ;

					public PollingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ControllerPollingInfo> vVlTXoWzslltUVjXwOBwoudmFvi;

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
					public SOgNHQsxBBbKuTmZkJRVfJsBaaZd(int _003C_003E1__state)
					{
					}

					private void npIbeIHcRQGJhjGgAsedlfcdVHhG()
					{
					}
				}

				private sealed class cTyJpHMwWBfIurcoDsIXNnNYDMl : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public IList<Joystick> PrbLLTTywsWUikWvoHMEMiqiLeX;

					public int geWMlUvMDXElkbvopSifhsleuVA;

					public ControllerPollingInfo wAdcwfqIiegfdHrNDoapqZaPclMi;

					public PollingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ControllerPollingInfo> KOSEPeHuilRnEIrvhzeBtCJxhbYA;

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
					public cTyJpHMwWBfIurcoDsIXNnNYDMl(int _003C_003E1__state)
					{
					}

					private void ZDUDbLrIDikWGBUriEqXNKMzDxEF()
					{
					}
				}

				private sealed class pDccJrWTmKfWydcyHawuaHUFoqrC : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public IList<CustomController> oYuQpcyjDOmVwWeTEuGccdxctfq;

					public int AEZdvIHxAfHYVhjOxMAFcDFFHanE;

					public ControllerPollingInfo NPwqhQzUtanOmXpFPMqRsYczcEJ;

					public PollingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ControllerPollingInfo> ziKcMZjIIdmuPDeJLobbdTSePPKy;

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
					public pDccJrWTmKfWydcyHawuaHUFoqrC(int _003C_003E1__state)
					{
					}

					private void hRwJJBeFaToyPcRhGTMTuGLYLmR()
					{
					}
				}

				private sealed class oabNBxJzesgJcerPOBegFttWTUN : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public IList<CustomController> tldqvonUrgcqQlbJAGLlQNXqqae;

					public int fxtbNzBnkoyworZCvyoRTEIcBrvd;

					public ControllerPollingInfo ZpItWCcHuYbKtIZvOAruTePKiSnk;

					public PollingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ControllerPollingInfo> tUMGDPlXHvvJiVPGfGiJuLljeCvE;

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
					public oabNBxJzesgJcerPOBegFttWTUN(int _003C_003E1__state)
					{
					}

					private void tSYdribbuuHeAjmjqjhGgKTIajQ()
					{
					}
				}

				private sealed class JZWzJHlKuKGShhbAGhWQoYxJKcB : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public IList<CustomController> braTlbmSOhkOMqpuHSGIHBTBWaI;

					public int ZaUywuUUoCDTfjIhmIsBcnTvRBt;

					public ControllerPollingInfo siqhkoDXXDNlWHauDtSjKwBmXXT;

					public PollingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ControllerPollingInfo> bdrdIZDluAWgwLXBEGXDdBDVbwuy;

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
					public JZWzJHlKuKGShhbAGhWQoYxJKcB(int _003C_003E1__state)
					{
					}

					private void EPUumOvQglmxdjVURAArFTzZzN()
					{
					}
				}

				private sealed class PakYaHDOgIqYdVKfNcJlBwSaEcz : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public IList<CustomController> JMjFGwUuapeFbeMUdcUJCuzMbqf;

					public int CAkoKEiNROMzPwHoFgXHMbMFrhN;

					public ControllerPollingInfo cHWcvzxeMpRNHhGHuNJbEMtRoXA;

					public PollingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ControllerPollingInfo> YXZfSLTdvyeLlcklAkIlCBRCHft;

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
					public PakYaHDOgIqYdVKfNcJlBwSaEcz(int _003C_003E1__state)
					{
					}

					private void yAXcacIHhqpXnoNcJHsosbJFVyit()
					{
					}
				}

				private sealed class rUfwVMFHTpVBInhYbDvTotxUwOm : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public IList<CustomController> EkuFuBbeupMnqlidIYDrVDwbCYe;

					public int NtHeplLTeAdDsfTsnDaGIYRDfYUb;

					public ControllerPollingInfo PyfoFDVCetTFlpbNKHvECqKUZVd;

					public PollingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ControllerPollingInfo> jXHvgNZsRyjjzuMSUEmyQabUjSod;

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
					public rUfwVMFHTpVBInhYbDvTotxUwOm(int _003C_003E1__state)
					{
					}

					private void qpQwyrAZRrjjJYkAUmrJzpmEJQE()
					{
					}
				}

				private static PollingHelper AWOJhGqjpBzbLGeZkcaDCwPLWpY;

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

				private ControllerPollingInfo BWMkgQqbtUpNLiZAKAgrQPkZbwl()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo TyCTfxaNaqiTWIbKKOvegasfzSiF()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo ddqslhtQBsXuHDCWJnjDPWlkcB()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo rvwaBXebEoydVAtFfGNSdqDkUbqN()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo yIHqPwCJybrYfVrSnRMTAluXczd()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo JTOyJMRLWljAavTzvlZEDWizkLW(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo JdkJeEJEDdRMXJRLOByJrXKHfxl(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo jArmRHPmkIeBlneBDUzvqXelmCL(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo xQjAvRTmTsnGVPNRPWxiGeUHXdc(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo SNSCnNdYNQvEnIyUfJTyFJEPuIw(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo dHmYCSfZqnMlcXozUAJWWGGxWof()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo UGMGKwXJfsrLMcgiNUvxhyTWnLH()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo TbNpaYhuryEIgOStYYsbsmTZTcz()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo MRAbnYgmVwjeldDihQhZjkYpSEgi()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo SxunepEoEAHertQfJEoMGNchecLG()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo aikFOhbKHXSEtSqJFEjEwfhPFpU()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo WBEjSkFIVVyrNvmwnqNEZSIgqlim()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo UeHSkSCynrJnLuIyISstmvGiLGy()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo lEwiNmQWXdZQuTlnWWxpLqlctgg()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo ZThIyvRJPliLRfUgsiCjbRvhJLF()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo tCxlfYBUSkzrhUXfMjlHuKyfjml()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo KwltcKARQbvVinRMgBIiqDsMbxke()
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo OMUWCLOfAOhCjextdXMpJgTfqfK(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo aHaTqCMVvbISSIbcgfVNnXQUGOZ(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo nfNWWMjiCXQFhghNVfdJeNhWjIqa(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo gyelgvukAhgixVvZadzXVtxAjbl(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private ControllerPollingInfo AsSCTQFXzXulucUdVjFYIwCliled(int P_0)
				{
					return default(ControllerPollingInfo);
				}

				private IEnumerable<ControllerPollingInfo> cldxqTZsxPFEpMcnJgrEupkOiFj()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> PCMToeAxdMLqBluwvRVoVRsyHZj()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> tFEnviCNAeLZPBwKPvJJcSjJScw()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> SyWEoEPgPkfinYaizCBLaVWJkUr()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> sikisNdYtuzquSSdiCSXPrNInmh()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> paacbWHBUYFgTtJPYRSVnbYxOaYe(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> bnnwUsGGjSBjbLfcWqgyCYhbiai(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> JFTGYnhkLeJKFlNETdPIFQMXljC(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> ozzcxZRqhNhdYaOhaiUyNvTEivW(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> ecehAEaOQmKPFrMGlqgCdNwDFiP(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> KwpCZTORAIpCtxYnBZraHGwdguY()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> wAdCDiTPsRnuyCxUfgoGQflzMZT()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> nHaGFaCYQqjCRIAgjrucgnMMNZHO()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> bSyCDEqHflGIBvGHomxroBxJjbs()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> ERYcicIrYivaBdBaHIeCseJEFti()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> eBLCuUfxAeBTgTEDWZxcnVbmCvXS()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> qXOkIaDphDtzoDcHsTVSFBRrqzw()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> TfVeUShLkNeOsFEkGPPJOKMgxMv()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> xJkuyZGtjxppJPLfvfKMhIxJdiMK()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> wgWyhOwGUSyTRABiCUbsQemLmgk()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> SCUrRxVXACOKzkJISABaDjqpeSpa()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> AcFWrFpUKHCnvwNrfxPIMOlHibq()
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> QxiUjuqqhndnWgJzukCfqCTmMGqT(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> rlSfeXBauurLTbzBtWENRKkIfPCE(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> cGjjTknFSLWeuoKKPcWdDMbNmzVj(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> iQtXdmNVWCIyTDzUYoSUPVjYVyw(int P_0)
				{
					return null;
				}

				private IEnumerable<ControllerPollingInfo> vFEIwWjhXFAjxAzfokDQFMjWHzXX(int P_0)
				{
					return null;
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class EFYSmVeMFYEcxeumFakGmwvnruI : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public int YdMuqczEIWIRtHqiObrOYNobHiQ;

					public int EXiJihaQfSfsUjqLMwhwtbmLBDk;

					public int oJgZhDHfCgFlfcXMQLpqREyWHxOn;

					public int rMAftEJuggEklKIVeTDSjwuXMUKF;

					public JoystickMap LUZtGYmNfqVARlkpXJpxxYhhUWa;

					public JoystickMap OBGkZxboJfAOSmoFUeTFiYmRQkKj;

					public ActionElementMap FmfOnGiBrfodmdTHBUFMYBfadkyk;

					public ActionElementMap TspjfHmSVTDtIqbYvalItFThWaO;

					public bool WvVfmxxIZDdZcGDUCRwuuCiUpvNn;

					public bool TenEQIFmArPZpfErHZKqbhFocWi;

					public bool iEVtEHAjllGyWBnqfJjXabCCMsx;

					public bool LVtBnprolgXtdfUJExyDxBFhnLA;

					public bool QkbcNJLJjtYUKuKsRZnEcVQplWB;

					public bool JDuSvbsBjNgZXFJXKSRFmVerFIy;

					public IList<Player> wpOGnZbMOXrQPiWXhCnLBjHaDDGY;

					public int vREGOWlfJpZVcDmXvcdHCdrjxbF;

					public ElementAssignmentConflictInfo gDrLBqWAXfDwXWoHsaEDCeVMYvcM;

					public ConflictCheckingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ElementAssignmentConflictInfo> pWcgRxuXtKJKgSwbbCzNqhQTEWH;

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
					public EFYSmVeMFYEcxeumFakGmwvnruI(int _003C_003E1__state)
					{
					}

					private void lFOGgfGKlOtfpQpwxmMmkgauRGV()
					{
					}
				}

				private sealed class xqQVEXsRaSjWNaSjaBDyPdcNjpb : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public ElementAssignmentConflictCheck KpZFcAgVcrTXHgJmrLDkbkXOFYd;

					public ElementAssignmentConflictCheck NQGCNaKqhQBRApaCjbZyGPHfPndJ;

					public bool WvVfmxxIZDdZcGDUCRwuuCiUpvNn;

					public bool TenEQIFmArPZpfErHZKqbhFocWi;

					public bool iEVtEHAjllGyWBnqfJjXabCCMsx;

					public bool LVtBnprolgXtdfUJExyDxBFhnLA;

					public bool QkbcNJLJjtYUKuKsRZnEcVQplWB;

					public bool JDuSvbsBjNgZXFJXKSRFmVerFIy;

					public IList<Player> qOPkNPtvoVbzwTZffAonFjPnTdb;

					public int MEqDMKfIxrGtYxoCXbrdZmVkZcS;

					public ElementAssignmentConflictInfo cBlFgBHlFObTDzvYzEbKFKUgwaBg;

					public ConflictCheckingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ElementAssignmentConflictInfo> ZVfmBOCalqhZjvlwMyrSXNHtdlp;

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
					public xqQVEXsRaSjWNaSjaBDyPdcNjpb(int _003C_003E1__state)
					{
					}

					private void lYKGEheJDYlmBxoCnTqeRFQNLdeF()
					{
					}
				}

				private sealed class IYEkLVlvOUdAcYxAbNfdCSGyOIh : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public int YdMuqczEIWIRtHqiObrOYNobHiQ;

					public int EXiJihaQfSfsUjqLMwhwtbmLBDk;

					public KeyboardMap jNEPpcfzesUvJyZdBsDBXNOBaQx;

					public KeyboardMap eEjULYGEecXSSZhwRBrUWBlZlKB;

					public ActionElementMap FmfOnGiBrfodmdTHBUFMYBfadkyk;

					public ActionElementMap TspjfHmSVTDtIqbYvalItFThWaO;

					public bool WvVfmxxIZDdZcGDUCRwuuCiUpvNn;

					public bool TenEQIFmArPZpfErHZKqbhFocWi;

					public bool iEVtEHAjllGyWBnqfJjXabCCMsx;

					public bool LVtBnprolgXtdfUJExyDxBFhnLA;

					public bool QkbcNJLJjtYUKuKsRZnEcVQplWB;

					public bool JDuSvbsBjNgZXFJXKSRFmVerFIy;

					public IList<Player> gWkFpviTESQPJSfJjLdqkOxLkwFH;

					public int fEFfqVryJFPHLoTgZMVylHZhRMB;

					public ElementAssignmentConflictInfo ClUyEHqBgTNVXOBWdCSKFNaLtnCw;

					public ConflictCheckingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ElementAssignmentConflictInfo> AMlqWgFQEfhNppitPalcKTJBTJy;

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
					public IYEkLVlvOUdAcYxAbNfdCSGyOIh(int _003C_003E1__state)
					{
					}

					private void BGXlLeYqYvGzIgTLQKDjzhPuHltv()
					{
					}
				}

				private sealed class zDNgOKAxpBtxulIszmXxufhgbYLe : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public ElementAssignmentConflictCheck KpZFcAgVcrTXHgJmrLDkbkXOFYd;

					public ElementAssignmentConflictCheck NQGCNaKqhQBRApaCjbZyGPHfPndJ;

					public bool WvVfmxxIZDdZcGDUCRwuuCiUpvNn;

					public bool TenEQIFmArPZpfErHZKqbhFocWi;

					public bool iEVtEHAjllGyWBnqfJjXabCCMsx;

					public bool LVtBnprolgXtdfUJExyDxBFhnLA;

					public bool QkbcNJLJjtYUKuKsRZnEcVQplWB;

					public bool JDuSvbsBjNgZXFJXKSRFmVerFIy;

					public IList<Player> gIHdavEuSMMfKXYxOCYcUxleWgPU;

					public int zRrDzTAFJnNXnUEiwwLGtfUlJjiD;

					public ElementAssignmentConflictInfo uaoaEMoRwJFLYAgrEEQJchTvbbqe;

					public ConflictCheckingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ElementAssignmentConflictInfo> TFBrUxEluhBMCnfoWmtcgeXtflu;

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
					public zDNgOKAxpBtxulIszmXxufhgbYLe(int _003C_003E1__state)
					{
					}

					private void ECnDCyVwBuSahIRkzvspgtytZCA()
					{
					}
				}

				private sealed class myowvVewuBDSyQlUwxIQzVaVcUU : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public int YdMuqczEIWIRtHqiObrOYNobHiQ;

					public int EXiJihaQfSfsUjqLMwhwtbmLBDk;

					public MouseMap zJKOxAnYtPmBZHHcPPQkEUJCJFX;

					public MouseMap DdsYpXMjsEOWvsNAXeabEfJMkNR;

					public ActionElementMap FmfOnGiBrfodmdTHBUFMYBfadkyk;

					public ActionElementMap TspjfHmSVTDtIqbYvalItFThWaO;

					public bool WvVfmxxIZDdZcGDUCRwuuCiUpvNn;

					public bool TenEQIFmArPZpfErHZKqbhFocWi;

					public bool iEVtEHAjllGyWBnqfJjXabCCMsx;

					public bool LVtBnprolgXtdfUJExyDxBFhnLA;

					public bool QkbcNJLJjtYUKuKsRZnEcVQplWB;

					public bool JDuSvbsBjNgZXFJXKSRFmVerFIy;

					public IList<Player> MjbtITgGUVglAkKUJkqShKOHJGX;

					public int yNnBRmCoOkakYlGcVtvFetLGHUq;

					public ElementAssignmentConflictInfo uHWfhdEAfkJVkAWFJrpAixfdtwgg;

					public ConflictCheckingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ElementAssignmentConflictInfo> vARGOZBMtNEirXxaHwfiLtUVAeGd;

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
					public myowvVewuBDSyQlUwxIQzVaVcUU(int _003C_003E1__state)
					{
					}

					private void pvVsPpVVgLiHHakGayGOXVubVtu()
					{
					}
				}

				private sealed class LDVOxLuCzGgsQhCKEpetYFCmVhqt : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public ElementAssignmentConflictCheck KpZFcAgVcrTXHgJmrLDkbkXOFYd;

					public ElementAssignmentConflictCheck NQGCNaKqhQBRApaCjbZyGPHfPndJ;

					public bool WvVfmxxIZDdZcGDUCRwuuCiUpvNn;

					public bool TenEQIFmArPZpfErHZKqbhFocWi;

					public bool iEVtEHAjllGyWBnqfJjXabCCMsx;

					public bool LVtBnprolgXtdfUJExyDxBFhnLA;

					public bool QkbcNJLJjtYUKuKsRZnEcVQplWB;

					public bool JDuSvbsBjNgZXFJXKSRFmVerFIy;

					public IList<Player> odkhoziuzcsqcxvChsVBvtpaYLe;

					public int bDfnMxnceKphRAEAJNFAtwqtqYK;

					public ElementAssignmentConflictInfo TIFlyDPfUxgaPkMRGKoLXxEfvQX;

					public ConflictCheckingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ElementAssignmentConflictInfo> eeevLqeeBXsAprkEoHytAagaLcfm;

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
					public LDVOxLuCzGgsQhCKEpetYFCmVhqt(int _003C_003E1__state)
					{
					}

					private void jDDftWWaJjVWMDNYvtmQaghYjy()
					{
					}
				}

				private sealed class JZeqTuPPaFyPwlPPgdNmhSTgBULh : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public int YdMuqczEIWIRtHqiObrOYNobHiQ;

					public int EXiJihaQfSfsUjqLMwhwtbmLBDk;

					public int oJgZhDHfCgFlfcXMQLpqREyWHxOn;

					public int rMAftEJuggEklKIVeTDSjwuXMUKF;

					public CustomControllerMap TnFfmAEhSyqJUHeEHFSqcGxjmUmG;

					public CustomControllerMap uEmHViHTlHGuHIHPTqTPOcoPJGIz;

					public ActionElementMap FmfOnGiBrfodmdTHBUFMYBfadkyk;

					public ActionElementMap TspjfHmSVTDtIqbYvalItFThWaO;

					public bool WvVfmxxIZDdZcGDUCRwuuCiUpvNn;

					public bool TenEQIFmArPZpfErHZKqbhFocWi;

					public bool iEVtEHAjllGyWBnqfJjXabCCMsx;

					public bool LVtBnprolgXtdfUJExyDxBFhnLA;

					public bool QkbcNJLJjtYUKuKsRZnEcVQplWB;

					public bool JDuSvbsBjNgZXFJXKSRFmVerFIy;

					public IList<Player> XPOFDFcKRCkQDsMuONNdKvYjxfsa;

					public int bETrtkaMGfFApELFXZRVpSsofBfD;

					public ElementAssignmentConflictInfo nzZdagiPtASyXQsvLXPdprYlvOt;

					public ConflictCheckingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ElementAssignmentConflictInfo> PjGdbadlZhHSIdkUtvwZHTnHULD;

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
					public JZeqTuPPaFyPwlPPgdNmhSTgBULh(int _003C_003E1__state)
					{
					}

					private void WooCSuQCKsxLaGMhNMiezgniBQT()
					{
					}
				}

				private sealed class OJxIFemfOqUujJyQrRGmEjiSpSG : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

					private int KjzQtaNmLSFADNQocZpcbdUSqwW;

					private int heukQwubtgAAwETRDLwZfpUeIur;

					public ElementAssignmentConflictCheck KpZFcAgVcrTXHgJmrLDkbkXOFYd;

					public ElementAssignmentConflictCheck NQGCNaKqhQBRApaCjbZyGPHfPndJ;

					public bool WvVfmxxIZDdZcGDUCRwuuCiUpvNn;

					public bool TenEQIFmArPZpfErHZKqbhFocWi;

					public bool iEVtEHAjllGyWBnqfJjXabCCMsx;

					public bool LVtBnprolgXtdfUJExyDxBFhnLA;

					public bool QkbcNJLJjtYUKuKsRZnEcVQplWB;

					public bool JDuSvbsBjNgZXFJXKSRFmVerFIy;

					public IList<Player> OKrlcvNptUWmdBXPgpbZeNXmXDC;

					public int JKWoUHyOOzhXEiUqCnuvLjvdeJu;

					public ElementAssignmentConflictInfo RVMblGcRBwFGTmCyOZNMwRgVSLw;

					public ConflictCheckingHelper OLVemnFdjzUkQSlFFFIOsrknazt;

					public IEnumerator<ElementAssignmentConflictInfo> TnOobvcUremlvDmozCRjbBksmhj;

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
					public OJxIFemfOqUujJyQrRGmEjiSpSG(int _003C_003E1__state)
					{
					}

					private void ihwyldwKueTjcYToUqoDwFxMLsk()
					{
					}
				}

				private static ConflictCheckingHelper AWOJhGqjpBzbLGeZkcaDCwPLWpY;

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

				private bool tuSLMTydJWYBaomkefzeamuBZcXr(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return false;
				}

				private bool tuSLMTydJWYBaomkefzeamuBZcXr(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool CZmRoRoPCpqPZqDDTcxncRMvVeRO(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return false;
				}

				private bool CZmRoRoPCpqPZqDDTcxncRMvVeRO(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool QNFgVJjaZTRhrewZDfzCAXbLiwq(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return false;
				}

				private bool QNFgVJjaZTRhrewZDfzCAXbLiwq(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return false;
				}

				private bool nJzBxNormxizFeMumdjKfIrdRueh(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return false;
				}

				private bool nJzBxNormxizFeMumdjKfIrdRueh(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				private IEnumerable<ElementAssignmentConflictInfo> wuenCklGzcgDkUlyCqPtTRaxRkk(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> wuenCklGzcgDkUlyCqPtTRaxRkk(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> XUTIEuiAGALJRBnPViBlfcbbipv(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> XUTIEuiAGALJRBnPViBlfcbbipv(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> yojLAPDqHRhLzeKtFPFSOyjcsJrU(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> yojLAPDqHRhLzeKtFPFSOyjcsJrU(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> LwrpjHxCaHuoCuoIZWmVHrJKsER(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return null;
				}

				private IEnumerable<ElementAssignmentConflictInfo> LwrpjHxCaHuoCuoIZWmVHrJKsER(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				private int RgSyDOwgdEJQTWIwQAiHdwVuJXP(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int RgSyDOwgdEJQTWIwQAiHdwVuJXP(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int kjrnaYbgJrwqgrhAwjeXjNqSGpx(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int kjrnaYbgJrwqgrhAwjeXjNqSGpx(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int MyVPDLUtipIeQvxXkoPuBawhELs(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int MyVPDLUtipIeQvxXkoPuBawhELs(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int IImoPOpvVgOQYLHQrynNqhaxcwb(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int IImoPOpvVgOQYLHQrynNqhaxcwb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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

				private int dVhdoEffKmRjuIUoEGNVjYDxglNJ(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int dVhdoEffKmRjuIUoEGNVjYDxglNJ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int sjpvCfSTdDBaFsGoyfLpLstxpiq(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int sjpvCfSTdDBaFsGoyfLpLstxpiq(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int RHbSXRlbZQodYUPlrQhDRQDCDEP(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return 0;
				}

				private int RHbSXRlbZQodYUPlrQhDRQDCDEP(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}

				private int OMPiuYQdMToFUIrgBCmXjzXDiuD(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return 0;
				}

				private int OMPiuYQdMToFUIrgBCmXjzXDiuD(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return 0;
				}
			}

			private static ControllerHelper AWOJhGqjpBzbLGeZkcaDCwPLWpY;

			public readonly PollingHelper polling;

			public readonly ConflictCheckingHelper conflictChecking;

			internal static ControllerHelper Instance => null;

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

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class MappingHelper : CodeHelper
		{
			private static MappingHelper AWOJhGqjpBzbLGeZkcaDCwPLWpY;

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

			internal InputBehavior fZWIAugeueTRGyndoHGxFOyBklP(int P_0)
			{
				return null;
			}

			internal InputBehavior fZWIAugeueTRGyndoHGxFOyBklP(string P_0)
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

			private ControllerElementIdentifier PHyMazXlrLlGDjxDxUIlUjxgnGp(Guid P_0, int P_1)
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

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class PlayerHelper : CodeHelper
		{
			private static PlayerHelper AWOJhGqjpBzbLGeZkcaDCwPLWpY;

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

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper AWOJhGqjpBzbLGeZkcaDCwPLWpY;

			internal static TimeHelper Instance => null;

			public float unscaledDeltaTime => 0f;

			public double unscaledTime => 0.0;

			public uint currentFrame => 0u;

			private TimeHelper()
			{
			}
		}

		private class quZLXpLFDouoFuYGhtGzhdIwtc
		{
			private class MPGFXemchQWrfzIFIBHxdxSvtQd
			{
				public readonly UpdateLoopType OtdyoVgHZlkVzcXpmFOkbCpToVK;

				private double SjtPaqVHAVmclBJjkDqqYmnlXzA;

				private double WmxeIahkFfECDGoUCyKKByEaCFJY;

				private double rNaABubAacCytVFjxRrmXFKeYYz;

				private double SAoDKsDthoGBFLbkRIoHhKlLomVG;

				private uint OlqnpwHBhHXFTmIZucTHIWmzpi;

				private uint ZPOLPIFeMEocXMBzwYhyNLfGsGR;

				private float mBNsLUEenVtgrULebknyROfjusT;

				private float TcboItZKexVmwFNlbWOxmlsYpNS;

				public double unscaledTime => 0.0;

				public double unscaledTimePrev => 0.0;

				public double unscaledDeltaTime => 0.0;

				public uint frame => 0u;

				public uint framePrev => 0u;

				public float unityUnscaledDeltaTime => 0f;

				public float unityUnscaledDeltaTimePrev => 0f;

				public MPGFXemchQWrfzIFIBHxdxSvtQd(UpdateLoopType updateLoop)
				{
				}

				public void oDVbwUgIfbSDvfmIInVcyfSKnKRm()
				{
				}
			}

			private static class HnDOOpGAwZTrxULacixkHOtwIGeK
			{
				public static StopwatchBase Global => null;

				public static StopwatchBase ocIbkoMmgHsnOyMMcObcgEoKEsQ()
				{
					return null;
				}

				public static StopwatchBase OzOhxXowppOTaJVKsyAOsEquTLV()
				{
					return null;
				}
			}

			private StopwatchBase qSMAOjsHzdaREiQeclaYghJkPhgY;

			private double vlrrwYOaMFIcxLVJKSRtqpCdAOCc;

			private MPGFXemchQWrfzIFIBHxdxSvtQd NBlzuPqcXMCAwdguYNfunrHscXRI;

			private ADictionary<int, MPGFXemchQWrfzIFIBHxdxSvtQd> czyIbVyvzokgVQfWKQxRHuceNaT;

			private uint NjBGNLnlblmRPagNgjNEyEdJCMt;

			public double unscaledTime => 0.0;

			public double unscaledTimePrev => 0.0;

			public double unscaledDeltaTime => 0.0;

			public float unityUnscaledDeltaTime => 0f;

			public float unityUnscaledDeltaTimePrev => 0f;

			internal double realTime => 0.0;

			public uint frame => 0u;

			public uint framePrev => 0u;

			public uint absFrame => 0u;

			public void wLZLdqNIDqKnmlKKFHCITcaGcME()
			{
			}

			public void wcDfhuvvIloonVFErZkAXwihlbn()
			{
			}

			public void oDVbwUgIfbSDvfmIInVcyfSKnKRm(UpdateLoopType P_0)
			{
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch AWOJhGqjpBzbLGeZkcaDCwPLWpY;

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

		internal class HybfOmHovJCQyvMTnHQsJGxLqgQd
		{
			public readonly ValueWatcher<bool> BmtVKrGOdpzMhjmHKDfSKayzyige;

			public readonly ValueWatcher<bool> FGDRBclRbtWKNzpbQnKDLqYvMQK;

			public readonly ValueWatcher<bool> kuxEjfHRtWpLdzswBBAOEewfzbtj;

			public readonly ValueWatcher<int> gMDQAxqqAqcFxaIJLZERJMErILfs;

			public readonly ValueWatcher<float> xVOdEkeEeBsCvxRiEBUyqhrmIopK;

			public readonly ValueWatcher<string> XdZurrgUNrMylFyxTfbnPycgRDs;

			public readonly ValueWatcher<bool> xzhbqQUQlKfOzGtHprRFDPVGcPn;

			private int KDZqiHHipmImSsFkmidChiasIexB;

			private readonly ValueWatcher[] PQrqkMMOQnGdBXFTzVgJPBDnbtLI;

			[CompilerGenerated]
			private static Func<bool> CWEveYGvbVePNyHrcdpkkZGUDPNh;

			[CompilerGenerated]
			private static Func<bool> JasvIuUEVqoWhazxaaGrrItgcoq;

			[CompilerGenerated]
			private static Func<int> jZbKexARbpbRTvUZiVnXwknQfML;

			[CompilerGenerated]
			private static Func<float> cDuSqfdrVlusEWFYLTbjDIcfWBE;

			[CompilerGenerated]
			private static Func<bool> HLfuJuSdJXdJmGWvsUgbOVAOneLb;

			[CompilerGenerated]
			private static Func<string> LKvcUjJaRRsMbpJRxgGeGEOlCJtf;

			public int currentFrame => 0;

			public void oDVbwUgIfbSDvfmIInVcyfSKnKRm()
			{
			}

			public void bcTotwQxTYBJVHWdmgNWfeVwhNV()
			{
			}

			[CompilerGenerated]
			private static bool hnQSVdNVmxlrPVgwYxNkcaacnUn()
			{
				return false;
			}

			[CompilerGenerated]
			private static bool lMBbxThiXLcsyYihTdeMqSzcKiyb()
			{
				return false;
			}

			[CompilerGenerated]
			private static int qqqVowHBUHqDXVOuXQulOgaXSvv()
			{
				return 0;
			}

			[CompilerGenerated]
			private static float xunDbxETvduQhsmuHCqAwpULwkg()
			{
				return 0f;
			}

			[CompilerGenerated]
			private static bool XfOAjZjbtMVBFbBlWFlWhInFkPsQ()
			{
				return false;
			}

			[CompilerGenerated]
			private static string NhMQhYLJvSFZdVdPQNtvRAZlwgo()
			{
				return null;
			}
		}

		[CustomObfuscation(rename = false)]
		internal const int programVersion1 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion2 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion3 = 41;

		[CustomObfuscation(rename = false)]
		internal const int programVersion4 = 2;

		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U2021";

		private static InputManager_Base WIKjStwRVYttTCijdkIeMGnrIty;

		private static PlatformInputManager NFGyKJqdbegSAEkKqKrXgIqEkKws;

		internal static sKfbabFZSpPYPWQbGaPcHNPCHjUV VNTjFueZIwnEHjftxKDkfTHpgzv;

		internal static qfKwEYcXbEpLgLAofVmKtyuEmza YZDamoIcWVVHkfzMxCVRARJCixHx;

		internal static GTBrHfeTmNLKrxASdlEyOyDVuou wXbXfLkYNoIpvDHQSGUgYvSfBVH;

		private static ControllerDataFiles cHKRMNAELhXloYElaBKnbnBumxa;

		private static UserData vSHoIFMQwkbtyDeNtdIVOFpXgPJd;

		private static bool fjUzJMvfKUtkXCOEoCUtEkxLMZg;

		private static ConfigVars NRGJzZDBayvuhGDbtdScxljensV;

		private static UpdateLoopType KSlkLMtkDroVWzfnWwYOUpiiHuD;

		private static bool tPXdlaFHLsrfqCuKNjfTCuyiLVJ;

		private static Platform lLWHORqYLcMWCShDHZUSXczAZbz;

		private static WebplayerPlatform FeazshaKdnXxuFfOgfWHiSgftET;

		private static EditorPlatform pbjciuBSIfkRsSdmAthIugFJXlTn;

		private static bool zAXHTGDcSPgBrZCEeprBtwaXPCW;

		private static TimerAbs WXwRNdGDIXZEynpZQmqBUPALRyQ;

		private static quZLXpLFDouoFuYGhtGzhdIwtc LzqNAtsiBfWsbFATWAGrIdWTqIcc;

		private static string bHxvrtjjRVKBHETUnNaxxIGdOyb;

		private static bool aODBYtAHeezWvZcMXsFSHDQiFft;

		private static bool RxPhhqBfhiDSbXZrMEBzBtuafCR;

		private static bool dVJiOsvUyqYQqnzjxxVtTitjKhZ;

		private static int BxmZVosRmgsGGYERKIqkVRYPjef;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int tpwdyOiZPsmyMEscRrHJhpUTwgtx;

		private static int HliYsVnfHjHQKGdNNbFsaUyhlnR;

		private static bool MeQXBkgSPhsjnhOgzvlTIzZPaqU;

		private static readonly UnityTouch zQcQAoxElFlJiYcMrNZrChgiOFz;

		private static readonly PlayerHelper XOTXmIFBNauyzCPOOWhWFkFmiUE;

		private static readonly ControllerHelper BBODIrNHuTncZItGtIvbREJsORs;

		private static readonly MappingHelper hUEHyVlHTfxKgiHPWstnbehkgxk;

		private static readonly TimeHelper vOSWrHYfSflgudajCifYadLUOea;

		private static readonly ConfigHelper uyQtkMWVNgfJlFfIotOcMLiLIOI;

		private static JbhfJVJahTyQSiiuKOJdrtbJZsl lbbSZAHENSnIWXYVsSCQJCbXoDm;

		private static UserDataStore AIAKMBUgLgsfKUcJpqKmgZzcTwX;

		private static IControllerAssigner TqJhqbvfwNHpgrfrDBZtuQldpXG;

		private static HybfOmHovJCQyvMTnHQsJGxLqgQd LpMpdErxYphEJwaudmCRiLoVNhf;

		private static SafeAction<ControllerStatusChangedEventArgs> hSdSIdpprlngHzqTHDxpcNIvOmxB;

		private static SafeAction<ControllerStatusChangedEventArgs> GArlHTnznAHKhTAaKvBakvgUEXJ;

		private static SafeAction<ControllerStatusChangedEventArgs> YkunTxKETGCiCEPsHegVljxvtnR;

		private static SafeAction KphZZRrOwClKubNVdQUfnDMJmHW;

		private static SafeAction MvrBFUSyHfHSDvFEfpnBEXZPLGP;

		private static SafeAction WDkgIhgPfwhrjuHbcpPbkosxqCmn;

		private static SafeAction WVTfvbEpKRgoWVubSRGpHqOAiNRM;

		private static SafeAction oTxbbsQaShDWFwgSUBEWBsuzoZg;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		private static Action XmwYSTZIIQHlIgmzthJxTnvHntZX;

		private static Action<UpdateLoopType> IdpnUYYMJoDovGIOVuefIbKImuY;

		private static Action<UpdateLoopType> GqhuIsdAmpzkuTWtdIYgdftpbov;

		private static Action<UpdateLoopType> EJdSfvoiRJAUrHnIFxFGmztnFCNb;

		private static Action sSRHsCTbRGRLlUJbObrYQQfwyXj;

		private static Action<bool> pZQiVBgsTdIwcmqgssFlEbKQKAz;

		private static Action<bool> CPmbSsKJfygBQUIHTmKLoAYaQBi;

		private static Action<bool> RuLZPOkuUeXDUmrvEusYOoiwMax;

		private static Action<FullScreenMode> JywjsRPaSsxuCPABLgBMZxqViHS;

		private static Action zZoObHDpvPxdYNdwwZYUMhukRtl;

		private static Action<bool> CAEooKPAeEyoulLnabAQfgownlU;

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

		[CompilerGenerated]
		private static Action<Exception> qIGnrhTPJCWEEwzuwGfXKXIOiQh;

		[CompilerGenerated]
		private static Action<Exception> JOzBGmoHQZjiBVPTbLdxdlcDKtX;

		[CompilerGenerated]
		private static Action<Exception> awpkufMDcpprqtGkXvItnJTqqFy;

		[CompilerGenerated]
		private static Action<Exception> YsFbdJGPxNqaevsGkQMuEdZEUtT;

		[CompilerGenerated]
		private static Action<Exception> doGELBXViVaXchtFTeIwBzQPojtT;

		[CompilerGenerated]
		private static Action<Exception> yDzoGfvMKPbXkBhBQXhpbGDROSiM;

		[CompilerGenerated]
		private static Action<Exception> YjLzAvncpfBODzrpVwAygqzrbjR;

		[CompilerGenerated]
		private static Action<Exception> mFdLrpTjFrbjhiGOkTWGqqfRHIv;

		[CompilerGenerated]
		private static Action<Exception> vjQFMWIlAzEvMEAyNPSHFIwmEBX;

		[CompilerGenerated]
		private static Func<bool> KpwtgkIUswQEtTarjVBiqrxlUPv;

		private static JbhfJVJahTyQSiiuKOJdrtbJZsl unityInputBuffer => null;

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

		private static bool isEditorGameViewFocused => false;

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused => false;

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused => false;

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform => false;

		private static bool inputAllowed => false;

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFocused => false;

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

		public static void Reset()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			return false;
		}

		internal static void yevEaEOpxaTseresMwWwEaZGFmnj(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4)
		{
		}

		internal static void vVtoVlkZiDvtMZKduOjGVNXlCRf()
		{
		}

		internal static void EPWmEBtxWaIVHNBcYbWpPpuAdoP(UpdateLoopType P_0)
		{
		}

		private static void wghMqooKEzkmQNvXokEyHSJZrch(UpdateLoopType P_0)
		{
		}

		private static void EPrFiZAKVhMLvXPLExDcsVkQASpq()
		{
		}

		internal static void oDVbwUgIfbSDvfmIInVcyfSKnKRm(UpdateLoopType P_0)
		{
		}

		internal static void kyLnczJFyXyqqAiQFlDmmHSImkf()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static void EditorUpdate()
		{
		}

		internal static void QPnraZrNqAFoOUoGyEuSFGudAGiL()
		{
		}

		internal static void uMjGmpgCYcLjhhSIHldhsjHtZaJe()
		{
		}

		internal static void orQgFHfHfuIAmbVatmrmrCCuyfo(bool P_0)
		{
		}

		internal static void uJPRTqLgezqreDjInpfYdUYfGqv()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return null;
		}

		internal static HardwareJoystickMap yOLMoxhbGAtlEQzegtbouGhYMRp(Guid P_0)
		{
			return null;
		}

		internal static HardwareJoystickTemplateMap aRTfxqNvQDpsImhltuzcTtRvqGQ(Guid P_0)
		{
			return null;
		}

		internal static IHardwareControllerTemplateMap TnQCICDVFGDpmkKKNOKUdfJpXWNR(Guid P_0)
		{
			return null;
		}

		internal static IList<HardwareJoystickTemplateMap> AFlkMoRNFFLakfubVUGDCxeKipn(Guid P_0)
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

		internal static void xhoqvmutErVNfrInEGtGecRdiqfb()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
		}

		internal static float IboCKtXBeGHxuctTetKFkVCTadJ()
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

		private static void eMtAhhXTcgWmlSkfShnXEgfkMxu()
		{
		}

		private static void NOLdoMePRJnPfpArGLRMlrsYBMbn()
		{
		}

		private static void TQSaVxeakymeJMsDbMvQFCeseejf(string P_0 = null)
		{
		}

		private static void iIGDBUgcHmgbQoMyKRbQJvNNbbA()
		{
		}

		private static void EVinUPhTPZlHcofApsmvXAmQUWg()
		{
		}

		private static void dHXMkzghnWirrAoijmBuziNgMlz(BridgedController P_0)
		{
		}

		private static void SNUTxAdUZUQqHehAnmxvVcvNsag(ControllerDisconnectedEventArgs P_0)
		{
		}

		private static void OnVlLyHVrlwOaRkkCeQYGPpjsSct(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void ffRPqZPpZHxBWkjAuIxTAKvantw(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void mVsBBuzFKOLXEhKofLuXFxuVFnU(ControllerStatusChangedEventArgs P_0)
		{
		}

		private static void CdPjUmdVLHFuawbUQSoHwtHehAJ(UpdateControllerInfoEventArgs P_0)
		{
		}

		private static void aYscBdBbWIIgUMQjVZygRDyLkhan(bool P_0)
		{
		}

		private static void hFWPOolCiWEzlxvkXqHawvcipfx(bool P_0)
		{
		}

		private static void nvwgFdIEPqmIXeVUfGyVLhsxTwk(int P_0)
		{
		}

		private static void pGJPuUILNqCVYTquenVxQDInafY(bool P_0)
		{
		}

		private static void JMAfgRBxeiFzcmEVllrrEbothWf(bool P_0)
		{
		}

		private static void OtIXXKOjbKKqbixipvatzGdqGHhi()
		{
		}

		private static void ZKALcLqSTQtVLeZubhdzZDHtuhY()
		{
		}

		private static void zYBFqOOotwChLQKlQFgIdDpXBLSc(bool P_0)
		{
		}

		private static void FAFAbbCclznjbIzbYUkqNNDeQHt(Func<ConfigVars, object> P_0)
		{
		}

		private static void vUlUQIhFEsXNhENEbkEWBIpyfEm()
		{
		}

		private static void wYRbEJXjUMEhlHZXydraorSxsdhA()
		{
		}

		[CompilerGenerated]
		private static void wLpeIpAokoohtTbbHrCQKvvOvgpR(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void XXhEOctRMpdtaaeqbmvnZUDfMptN(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void wXhgqmGadeoznxNVtpbVoGpvakq(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void FBlkhiInPucDodbDtNQhJjTSaOO(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void jcVEAJAaGdBBHghoEaNwLAXpDMhG(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void qRDVKInGCrGQpFRTIeXcMcAHBemB(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void maKfsXEEDRbrkdjxmWwZRXxrDVqG(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void gzAgOqUGcBVkBxufwHODykMqOBJ(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void qOcDtcJNEzMcnOWMODwPmoHawuv(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static bool EgPlAvyZZxuTSmcKvGJajsAvhkKg()
		{
			return false;
		}
	}
}
