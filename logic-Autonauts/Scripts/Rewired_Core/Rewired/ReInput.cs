using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.InputManagers;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.Custom;
using Rewired.Platforms.PS4;
using Rewired.Platforms.XboxOne;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired
{
	public static class ReInput
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class ConfigHelper : CodeHelper
		{
			private static ConfigHelper VLHBdfuObcdunicAbIHFTExpsoBB;

			internal static ConfigHelper Instance
			{
				get
				{
					return VLHBdfuObcdunicAbIHFTExpsoBB ?? (VLHBdfuObcdunicAbIHFTExpsoBB = new ConfigHelper());
				}
			}

			public bool useXInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.platform == Platform.Windows && stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						return true;
					}
					if (UnityTools.platform == Platform.WindowsUWP)
					{
						return (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useGamepadAPI;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.useXInput;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = default(ConfigVars.PlatformVars_WindowsUWP);
					while (true)
					{
						int num;
						int num2;
						if (UnityTools.platform == Platform.WindowsUWP)
						{
							num = -468953610;
							num2 = num;
						}
						else
						{
							num = -468953602;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -468953602)
							{
							case 2:
								num = -468953603;
								continue;
							default:
								return;
							case 12:
								if (!value && UnityTools.platform == Platform.Windows && stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
								{
									windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
									num = -468953601;
									continue;
								}
								goto case 5;
							case 7:
								return;
							case 4:
								return;
							case 5:
								if (XSTHGbqTGxsAhksycZRiWDoTadf != null)
								{
									XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
									num = -468953612;
									continue;
								}
								return;
							case 8:
							{
								platformVars_WindowsUWP = stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
								int num3;
								if (platformVars_WindowsUWP.useGamepadAPI != value)
								{
									num = -468953608;
									num3 = num;
								}
								else
								{
									num = -468953611;
									num3 = num;
								}
								continue;
							}
							case 6:
								platformVars_WindowsUWP.useGamepadAPI = value;
								if (!(XSTHGbqTGxsAhksycZRiWDoTadf != null))
								{
									return;
								}
								XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
								num = -468953607;
								continue;
							case 0:
								if (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.useXInput == value)
								{
									return;
								}
								goto case 9;
							case 3:
								break;
							case 1:
								Logger.Log("The primary input source has been changed to Raw Input.");
								num = -468953606;
								continue;
							case 11:
								return;
							case 9:
								stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.useXInput = value;
								num = -468953614;
								continue;
							case 10:
								return;
							}
							break;
						}
					}
				}
			}

			public UpdateLoopSetting updateLoop
			{
				get
				{
					if (!CheckInitialized())
					{
						return UpdateLoopSetting.Update;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.updateLoop;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (value != stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.updateLoop)
					{
						while (true)
						{
							int num;
							int num2;
							if ((value & UpdateLoopSetting.Update) != UpdateLoopSetting.None)
							{
								num = -35762290;
								num2 = num;
							}
							else
							{
								num = -35762296;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ -35762292)
								{
								case 0:
									num = -35762295;
									continue;
								default:
									return;
								case 4:
									value |= UpdateLoopSetting.Update;
									num = -35762290;
									continue;
								case 3:
									break;
								case 5:
									goto end_IL_003e;
								case 2:
									stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.updateLoop = value;
									if (XSTHGbqTGxsAhksycZRiWDoTadf != null)
									{
										XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
										num = -35762291;
										continue;
									}
									return;
								case 1:
									return;
								}
								break;
							}
							continue;
							end_IL_003e:
							break;
						}
					}
				}
			}

			public WindowsStandalonePrimaryInputSource windowsStandalonePrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return WindowsStandalonePrimaryInputSource.RawInput;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.windowsStandalonePrimaryInputSource;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_006c;
					IL_0007:
					int num = -96225757;
					goto IL_000c;
					IL_000c:
					switch (num ^ -96225759)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						return;
					case 1:
						goto IL_0039;
					case 4:
						goto IL_006c;
					case 3:
						goto IL_0086;
					case 5:
						return;
					}
					goto IL_0007;
					IL_006c:
					if (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.windowsStandalonePrimaryInputSource == value)
					{
						return;
					}
					goto IL_0039;
					IL_0039:
					stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.windowsStandalonePrimaryInputSource = value;
					if (UnityTools.platform == Platform.Windows && value == WindowsStandalonePrimaryInputSource.XInput)
					{
						stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.useXInput = true;
						num = -96225758;
						goto IL_000c;
					}
					goto IL_0086;
					IL_0086:
					if (XSTHGbqTGxsAhksycZRiWDoTadf != null)
					{
						XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
						num = -96225756;
						goto IL_000c;
					}
				}
			}

			public OSXStandalonePrimaryInputSource osxStandalonePrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return OSXStandalonePrimaryInputSource.Native;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.osx_primaryInputSource;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (true)
					{
						int num;
						int num2;
						if (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.osx_primaryInputSource == value)
						{
							num = -1549539290;
							num2 = num;
						}
						else
						{
							num = -1549539289;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -1549539289)
							{
							case 3:
								num = -1549539291;
								continue;
							default:
								return;
							case 0:
								stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.osx_primaryInputSource = value;
								if (XSTHGbqTGxsAhksycZRiWDoTadf != null)
								{
									XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
									num = -1549539293;
									continue;
								}
								return;
							case 1:
								return;
							case 2:
								break;
							case 4:
								return;
							}
							break;
						}
					}
				}
			}

			public LinuxStandalonePrimaryInputSource linuxStandalonePrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return LinuxStandalonePrimaryInputSource.Native;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.linux_primaryInputSource;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_006e;
					IL_0007:
					int num = 1103058404;
					goto IL_000c;
					IL_000c:
					while (true)
					{
						switch (num ^ 0x41BF55E1)
						{
						case 2:
							break;
						default:
							return;
						case 5:
							return;
						case 3:
							if (XSTHGbqTGxsAhksycZRiWDoTadf != null)
							{
								XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
								num = 1103058405;
								continue;
							}
							return;
						case 1:
							goto IL_0057;
						case 0:
							goto IL_006e;
						case 4:
							return;
						}
						break;
					}
					goto IL_0007;
					IL_006e:
					if (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.linux_primaryInputSource == value)
					{
						return;
					}
					goto IL_0057;
					IL_0057:
					stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.linux_primaryInputSource = value;
					num = 1103058402;
					goto IL_000c;
				}
			}

			public WindowsUWPPrimaryInputSource windowsUWPPrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return WindowsUWPPrimaryInputSource.Native;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.windowsUWP_primaryInputSource;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_0078;
					IL_0007:
					int num = -160074114;
					goto IL_000c;
					IL_000c:
					while (true)
					{
						switch (num ^ -160074113)
						{
						case 4:
							break;
						default:
							return;
						case 3:
							goto IL_0031;
						case 0:
							XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
							num = -160074118;
							continue;
						case 1:
							return;
						case 2:
							goto IL_0078;
						case 5:
							return;
						}
						break;
					}
					goto IL_0007;
					IL_0031:
					stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.windowsUWP_primaryInputSource = value;
					int num2;
					if (!(XSTHGbqTGxsAhksycZRiWDoTadf != null))
					{
						num = -160074118;
						num2 = num;
					}
					else
					{
						num = -160074113;
						num2 = num;
					}
					goto IL_000c;
					IL_0078:
					if (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.windowsUWP_primaryInputSource == value)
					{
						return;
					}
					goto IL_0031;
				}
			}

			public bool windowsUWPSupportHIDDevices
			{
				get
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					int num = 707814019;
					goto IL_000c;
					IL_000c:
					switch (num ^ 0x2A306282)
					{
					case 0:
						break;
					case 2:
						return false;
					default:
						return platformVars_WindowsUWP.useHIDAPI;
					}
					goto IL_0007;
					IL_0007:
					num = 707814016;
					goto IL_000c;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_0039;
					IL_0007:
					int num = 175531834;
					goto IL_000c;
					IL_000c:
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = default(ConfigVars.PlatformVars_WindowsUWP);
					while (true)
					{
						switch (num ^ 0xA76673B)
						{
						case 4:
							break;
						default:
							return;
						case 1:
							return;
						case 5:
							goto IL_0039;
						case 3:
							if (platformVars_WindowsUWP.useHIDAPI == value)
							{
								return;
							}
							goto case 2;
						case 2:
							platformVars_WindowsUWP.useHIDAPI = value;
							if (XSTHGbqTGxsAhksycZRiWDoTadf != null)
							{
								XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
								num = 175531835;
								continue;
							}
							return;
						case 0:
							return;
						}
						break;
					}
					goto IL_0007;
					IL_0039:
					platformVars_WindowsUWP = stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					num = 175531832;
					goto IL_000c;
				}
			}

			public XboxOnePrimaryInputSource xboxOnePrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return XboxOnePrimaryInputSource.Native;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.xboxOne_primaryInputSource;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.xboxOne_primaryInputSource != value)
					{
						while (true)
						{
							IL_0059:
							stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.xboxOne_primaryInputSource = value;
							int num;
							int num2;
							if (!(XSTHGbqTGxsAhksycZRiWDoTadf != null))
							{
								num = 1462222479;
								num2 = num;
							}
							else
							{
								num = 1462222473;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ 0x5727BE8D)
								{
								case 3:
									num = 1462222476;
									continue;
								default:
									return;
								case 1:
									break;
								case 4:
									XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
									num = 1462222479;
									continue;
								case 0:
									goto IL_0059;
								case 2:
									return;
								}
								break;
							}
							break;
						}
					}
				}
			}

			public PS4PrimaryInputSource ps4PrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return PS4PrimaryInputSource.Native;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.ps4_primaryInputSource;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (true)
					{
						int num;
						int num2;
						if (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.ps4_primaryInputSource == value)
						{
							num = 2082652542;
							num2 = num;
						}
						else
						{
							num = 2082652540;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x7C22C17C)
							{
							case 4:
								num = 2082652541;
								continue;
							default:
								return;
							case 5:
								if (XSTHGbqTGxsAhksycZRiWDoTadf != null)
								{
									XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
									num = 2082652543;
									continue;
								}
								return;
							case 2:
								return;
							case 0:
								stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.ps4_primaryInputSource = value;
								num = 2082652537;
								continue;
							case 1:
								break;
							case 3:
								return;
							}
							break;
						}
					}
				}
			}

			public WebGLPrimaryInputSource webGLPrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return WebGLPrimaryInputSource.Native;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.webGL_primaryInputSource;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.webGL_primaryInputSource != value)
					{
						while (true)
						{
							IL_0059:
							stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.webGL_primaryInputSource = value;
							int num;
							int num2;
							if (!(XSTHGbqTGxsAhksycZRiWDoTadf != null))
							{
								num = 901092058;
								num2 = num;
							}
							else
							{
								num = 901092057;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ 0x35B592D8)
								{
								case 0:
									num = 901092059;
									continue;
								default:
									return;
								case 3:
									break;
								case 1:
									XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
									num = 901092058;
									continue;
								case 4:
									goto IL_0059;
								case 2:
									return;
								}
								break;
							}
							break;
						}
					}
				}
			}

			public bool alwaysUseUnityInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.alwaysUseUnityInput;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.alwaysUseUnityInput != value)
					{
						while (true)
						{
							IL_0044:
							stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.alwaysUseUnityInput = value;
							if (!(XSTHGbqTGxsAhksycZRiWDoTadf != null))
							{
								return;
							}
							XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
							int num = -582329215;
							while (true)
							{
								switch (num ^ -582329215)
								{
								case 3:
									num = -582329216;
									continue;
								default:
									return;
								case 1:
									break;
								case 2:
									goto IL_0044;
								case 0:
									return;
								}
								break;
							}
							break;
						}
					}
				}
			}

			public bool disableNativeInput
			{
				get
				{
					return alwaysUseUnityInput;
				}
				set
				{
					alwaysUseUnityInput = value;
				}
			}

			public bool nativeMouseSupport
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.GetPlatformVar_useNativeMouse();
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_0053;
					IL_0007:
					int num = -1370858649;
					goto IL_000c;
					IL_000c:
					switch (num ^ -1370858651)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						return;
					case 4:
						goto IL_0035;
					case 3:
						goto IL_0053;
					case 1:
						return;
					}
					goto IL_0007;
					IL_0053:
					if (!stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.SetPlatformVar_useNativeMouse(value))
					{
						return;
					}
					goto IL_0035;
					IL_0035:
					if (XSTHGbqTGxsAhksycZRiWDoTadf != null)
					{
						XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
						num = -1370858652;
						goto IL_000c;
					}
				}
			}

			public bool nativeKeyboardSupport
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.GetPlatformVar_useNativeKeyboard();
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_004b;
					IL_0007:
					int num = -1501260260;
					goto IL_000c;
					IL_000c:
					switch (num ^ -1501260258)
					{
					case 4:
						break;
					default:
						return;
					case 3:
						goto IL_002d;
					case 1:
						goto IL_004b;
					case 2:
						return;
					case 0:
						return;
					}
					goto IL_0007;
					IL_004b:
					if (!stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.SetPlatformVar_useNativeKeyboard(value))
					{
						return;
					}
					goto IL_002d;
					IL_002d:
					if (XSTHGbqTGxsAhksycZRiWDoTadf != null)
					{
						XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
						num = -1501260258;
						goto IL_000c;
					}
				}
			}

			public bool enhancedDeviceSupport
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.GetPlatformVar_useEnhancedDeviceSupport();
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.SetPlatformVar_useEnhancedDeviceSupport(value))
					{
						while (true)
						{
							int num;
							int num2;
							if (XSTHGbqTGxsAhksycZRiWDoTadf != null)
							{
								num = -2009321812;
								num2 = num;
							}
							else
							{
								num = -2009321809;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ -2009321812)
								{
								case 2:
									num = -2009321811;
									continue;
								default:
									return;
								case 0:
									XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
									num = -2009321809;
									continue;
								case 4:
									break;
								case 1:
									goto end_IL_003f;
								case 3:
									return;
								}
								break;
							}
							continue;
							end_IL_003f:
							break;
						}
					}
				}
			}

			public int joystickRefreshRate
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.GetPlatformVar_joystickRefreshRate();
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (true)
					{
						value = MathTools.Clamp(value, 0, 2000);
						int num;
						if (value == 0)
						{
							value = 240;
							num = 1621520092;
							goto IL_000d;
						}
						goto IL_0049;
						IL_000d:
						while (true)
						{
							switch (num ^ 0x60A66EDE)
							{
							case 0:
								num = 1621520093;
								continue;
							default:
								return;
							case 3:
								break;
							case 2:
								goto IL_0049;
							case 1:
								return;
							}
							break;
						}
						continue;
						IL_0049:
						stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.SetPlatformVar_joystickRefreshRate(value);
						num = 1621520095;
						goto IL_000d;
					}
				}
			}

			public bool ignoreInputWhenAppNotInFocus
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.GetPlatformVar_ignoreInputWhenAppNotInFocus();
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (true)
					{
						int num;
						int num2;
						if (!stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.SetPlatformVar_ignoreInputWhenAppNotInFocus(value))
						{
							num = 1729573865;
							num2 = num;
						}
						else
						{
							num = 1729573864;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x671733E8)
							{
							case 3:
								num = 1729573868;
								continue;
							default:
								return;
							case 0:
								iYtGJBsuIAzSTPHeHgICfcjZmvmP();
								num = 1729573866;
								continue;
							case 1:
								return;
							case 4:
								break;
							case 2:
								return;
							}
							break;
						}
					}
				}
			}

			public bool android_supportUnknownGamepads
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.android_supportUnknownGamepads;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (true)
					{
						int num;
						int num2;
						if (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.android_supportUnknownGamepads == value)
						{
							num = 2121842462;
							num2 = num;
						}
						else
						{
							num = 2121842463;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x7E78BF1D)
							{
							case 0:
								num = 2121842456;
								continue;
							default:
								return;
							case 5:
								break;
							case 4:
								if (XSTHGbqTGxsAhksycZRiWDoTadf != null)
								{
									XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
									num = 2121842460;
									continue;
								}
								return;
							case 3:
								return;
							case 2:
								stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.android_supportUnknownGamepads = value;
								num = 2121842457;
								continue;
							case 1:
								return;
							}
							break;
						}
					}
				}
			}

			public DeadZone2DType defaultJoystickAxis2DDeadZoneType
			{
				get
				{
					if (!CheckInitialized())
					{
						return DeadZone2DType.Radial;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.defaultJoystickAxis2DDeadZoneType;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.defaultJoystickAxis2DDeadZoneType != value)
					{
						while (true)
						{
							IL_0044:
							stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.defaultJoystickAxis2DDeadZoneType = value;
							int num = -1948265730;
							while (true)
							{
								switch (num ^ -1948265731)
								{
								case 0:
									num = -1948265732;
									continue;
								default:
									return;
								case 1:
									break;
								case 2:
									goto IL_0044;
								case 3:
									return;
								}
								break;
							}
							break;
						}
					}
				}
			}

			public AxisSensitivity2DType defaultJoystickAxis2DSensitivityType
			{
				get
				{
					if (!CheckInitialized())
					{
						return AxisSensitivity2DType.Radial;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.defaultJoystickAxis2DSensitivityType;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.defaultJoystickAxis2DSensitivityType != value)
					{
						while (true)
						{
							IL_0044:
							stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.defaultJoystickAxis2DSensitivityType = value;
							int num = -1529870544;
							while (true)
							{
								switch (num ^ -1529870541)
								{
								case 0:
									num = -1529870542;
									continue;
								default:
									return;
								case 1:
									break;
								case 2:
									goto IL_0044;
								case 3:
									return;
								}
								break;
							}
							break;
						}
					}
				}
			}

			public AxisSensitivityType defaultAxisSensitivityType
			{
				get
				{
					if (!CheckInitialized())
					{
						return AxisSensitivityType.Multiplier;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.defaultAxisSensitivityType;
				}
				set
				{
					if (!CheckInitialized())
					{
						while (true)
						{
							switch (0x39108F9F ^ 0x39108F9C)
							{
							case 2:
								break;
							case 3:
								return;
							case 0:
								goto end_IL_0007;
							default:
								goto IL_004b;
							}
							continue;
							end_IL_0007:
							break;
						}
					}
					if (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.defaultAxisSensitivityType == value)
					{
						return;
					}
					goto IL_004b;
					IL_004b:
					stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.defaultAxisSensitivityType = value;
				}
			}

			public bool force4WayHats
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.force4WayHats;
				}
				set
				{
					if (!CheckInitialized())
					{
						while (true)
						{
							switch (-64339367 ^ -64339368)
							{
							case 3:
								break;
							case 1:
								return;
							case 2:
								goto end_IL_0007;
							default:
								goto IL_004b;
							}
							continue;
							end_IL_0007:
							break;
						}
					}
					if (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.force4WayHats == value)
					{
						return;
					}
					goto IL_004b;
					IL_004b:
					stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.force4WayHats = value;
				}
			}

			public bool activateActionButtonsOnNegativeValue
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.activateActionButtonsOnNegativeValue;
				}
				set
				{
					if (!CheckInitialized())
					{
						while (true)
						{
							switch (-951733042 ^ -951733044)
							{
							case 0:
								break;
							case 2:
								return;
							case 3:
								goto end_IL_0007;
							default:
								goto IL_004b;
							}
							continue;
							end_IL_0007:
							break;
						}
					}
					if (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.activateActionButtonsOnNegativeValue == value)
					{
						return;
					}
					goto IL_004b;
					IL_004b:
					stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.activateActionButtonsOnNegativeValue = value;
				}
			}

			public ThrottleCalibrationMode throttleCalibrationMode
			{
				get
				{
					if (!CheckInitialized())
					{
						return ThrottleCalibrationMode.ZeroToOne;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.throttleCalibrationMode;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.throttleCalibrationMode != value)
					{
						while (true)
						{
							IL_0044:
							stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.throttleCalibrationMode = value;
							TjEnOXyhIcFYKPeZiqgPVRhKsqQ.zcSNXJzzMCDeSlYnCUNDAPekdYyb(value);
							int num = 1103381678;
							while (true)
							{
								switch (num ^ 0x41C444AE)
								{
								case 2:
									num = 1103381679;
									continue;
								default:
									return;
								case 1:
									break;
								case 3:
									goto IL_0044;
								case 0:
									return;
								}
								break;
							}
							break;
						}
					}
				}
			}

			public bool deferControllerConnectedEventsOnStart
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.deferControllerConnectedEventsOnStart;
				}
				set
				{
					if (CheckInitialized() && stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.deferControllerConnectedEventsOnStart != value)
					{
						stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.deferControllerConnectedEventsOnStart = value;
					}
				}
			}

			public bool autoAssignJoysticks
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.autoAssignJoysticks;
				}
				set
				{
					if (CheckInitialized() && stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.autoAssignJoysticks != value)
					{
						stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.autoAssignJoysticks = value;
					}
				}
			}

			public int maxJoysticksPerPlayer
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.maxJoysticksPerPlayer;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (true)
					{
						int num;
						int num2;
						if (value < 1)
						{
							num = 313897028;
							num2 = num;
						}
						else
						{
							num = 313897026;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x12B5B040)
							{
							case 5:
								num = 313897025;
								continue;
							case 2:
							{
								int num3;
								if (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.maxJoysticksPerPlayer == value)
								{
									num = 313897024;
									num3 = num;
								}
								else
								{
									num = 313897027;
									num3 = num;
								}
								continue;
							}
							case 4:
								value = 1;
								num = 313897026;
								continue;
							case 0:
								return;
							case 1:
								break;
							default:
								stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.maxJoysticksPerPlayer = value;
								return;
							}
							break;
						}
					}
				}
			}

			public bool distributeJoysticksEvenly
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.distributeJoysticksEvenly;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.distributeJoysticksEvenly != value)
					{
						while (true)
						{
							IL_0044:
							stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.distributeJoysticksEvenly = value;
							int num = 1710375141;
							while (true)
							{
								switch (num ^ 0x65F240E6)
								{
								case 0:
									num = 1710375143;
									continue;
								default:
									return;
								case 1:
									break;
								case 2:
									goto IL_0044;
								case 3:
									return;
								}
								break;
							}
							break;
						}
					}
				}
			}

			public bool assignJoysticksToPlayingPlayersOnly
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.assignJoysticksToPlayingPlayersOnly;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (true)
					{
						int num;
						int num2;
						if (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.assignJoysticksToPlayingPlayersOnly == value)
						{
							num = -359285391;
							num2 = num;
						}
						else
						{
							num = -359285389;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -359285389)
							{
							case 3:
								num = -359285390;
								continue;
							default:
								return;
							case 1:
								break;
							case 2:
								return;
							case 0:
								stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.assignJoysticksToPlayingPlayersOnly = value;
								num = -359285385;
								continue;
							case 4:
								return;
							}
							break;
						}
					}
				}
			}

			public bool reassignJoystickToPreviousOwnerOnReconnect
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect;
				}
				set
				{
					if (CheckInitialized() && stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect != value)
					{
						stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect = value;
					}
				}
			}

			public LogLevelFlags logLevel
			{
				get
				{
					if (!CheckInitialized())
					{
						return LogLevelFlags.Off;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.logLevel;
				}
				set
				{
					if (!CheckInitialized())
					{
						while (true)
						{
							switch (-1314061802 ^ -1314061801)
							{
							case 3:
								break;
							case 1:
								return;
							case 0:
								goto end_IL_0007;
							default:
								goto IL_004b;
							}
							continue;
							end_IL_0007:
							break;
						}
					}
					if (stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.logLevel == value)
					{
						return;
					}
					goto IL_004b;
					IL_004b:
					stWFwgAKcHRiMeUYeMbPaDXDxKKn.ConfigVars.logLevel = value;
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
				private sealed class vNkJjxcOVBBHLfqWxePnYLYgNkR : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public PollingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public ControllerPollingInfo LChQHpEIfrhEfCiQzTwYFMPuDsAC;

					public ControllerPollingInfo abbwvUCoNPcNlTBaFJJPauLjthX;

					public ControllerPollingInfo zNePcdfPleQcjVpMSBHBVsDyxVl;

					public ControllerPollingInfo JoVwdcoelxCsxQvBPIbVhhjdMLv;

					public IEnumerator<ControllerPollingInfo> QNaRGKpqtAKpmGfFblMuqNPJOBP;

					public IEnumerator<ControllerPollingInfo> VkSEzvZNSZecsebwcdPLeZAaqED;

					public IEnumerator<ControllerPollingInfo> tIHhsDxbLPiZvUJtkhgZbVuHtex;

					public IEnumerator<ControllerPollingInfo> CsPKspkvlWWIAaUcXVcJqpknSzd;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							goto IL_001c;
						}
						goto IL_0052;
						IL_0052:
						vNkJjxcOVBBHLfqWxePnYLYgNkR vNkJjxcOVBBHLfqWxePnYLYgNkR2 = new vNkJjxcOVBBHLfqWxePnYLYgNkR(0);
						int num = 885634222;
						goto IL_0021;
						IL_001c:
						num = 885634221;
						goto IL_0021;
						IL_0021:
						while (true)
						{
							switch (num ^ 0x34C9B4AC)
							{
							case 4:
								break;
							case 1:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
								vNkJjxcOVBBHLfqWxePnYLYgNkR2 = this;
								num = 885634223;
								continue;
							case 0:
								goto IL_0052;
							case 2:
								vNkJjxcOVBBHLfqWxePnYLYgNkR2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
								num = 885634223;
								continue;
							default:
								return vNkJjxcOVBBHLfqWxePnYLYgNkR2;
							}
							break;
						}
						goto IL_001c;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						bool result = default(bool);
						try
						{
							int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
							while (true)
							{
								IL_0007:
								int num = -430661381;
								while (true)
								{
									switch (num ^ -430661396)
									{
									case 19:
										break;
									case 6:
										zNePcdfPleQcjVpMSBHBVsDyxVl = tIHhsDxbLPiZvUJtkhgZbVuHtex.Current;
										num = -430661383;
										continue;
									case 7:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 7;
										num = -430661401;
										continue;
									case 14:
										tIHhsDxbLPiZvUJtkhgZbVuHtex = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.uVtPvBSPOVSVrmwtatDmhmggEGMF().GetEnumerator();
										num = -430661388;
										continue;
									case 24:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 5;
										num = -430661407;
										continue;
									case 26:
										EPLpAgrbJldUmRqjOaDQfvdYsOD();
										VkSEzvZNSZecsebwcdPLeZAaqED = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.XzuyRyAOJjyALLhPWbokPtkFsjX().GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
										num = -430661382;
										continue;
									case 4:
										jIhhkwDwLwCcIUtlVmrvHzgoBGI();
										CsPKspkvlWWIAaUcXVcJqpknSzd = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.EEOwutpgymYFElDnLMyFQruAuLm().GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 7;
										num = -430661387;
										continue;
									case 20:
										result = true;
										goto end_IL_000c;
									case 22:
									{
										int num4;
										if (!VkSEzvZNSZecsebwcdPLeZAaqED.MoveNext())
										{
											num = -430661380;
											num4 = num;
										}
										else
										{
											num = -430661408;
											num4 = num;
										}
										continue;
									}
									case 0:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 8;
										result = true;
										goto end_IL_000c;
									case 10:
										goto IL_0195;
									case 28:
									{
										int num3;
										if (!QNaRGKpqtAKpmGfFblMuqNPJOBP.MoveNext())
										{
											num = -430661386;
											num3 = num;
										}
										else
										{
											num = -430661379;
											num3 = num;
										}
										continue;
									}
									case 17:
										LChQHpEIfrhEfCiQzTwYFMPuDsAC = QNaRGKpqtAKpmGfFblMuqNPJOBP.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = LChQHpEIfrhEfCiQzTwYFMPuDsAC;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										num = -430661405;
										continue;
									case 21:
										RDkWcsTpvDaNZojjIZONnoEBXPC = zNePcdfPleQcjVpMSBHBVsDyxVl;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 6;
										num = -430661399;
										continue;
									case 29:
										RDkWcsTpvDaNZojjIZONnoEBXPC = JoVwdcoelxCsxQvBPIbVhhjdMLv;
										num = -430661396;
										continue;
									case 9:
										goto IL_0228;
									case 8:
										JoVwdcoelxCsxQvBPIbVhhjdMLv = CsPKspkvlWWIAaUcXVcJqpknSzd.Current;
										num = -430661391;
										continue;
									case 12:
										abbwvUCoNPcNlTBaFJJPauLjthX = VkSEzvZNSZecsebwcdPLeZAaqED.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = abbwvUCoNPcNlTBaFJJPauLjthX;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 4;
										num = -430661384;
										continue;
									case 25:
										num = -430661401;
										continue;
									case 11:
										if (!CsPKspkvlWWIAaUcXVcJqpknSzd.MoveNext())
										{
											JpYkGBVDgJfBLytefCLbETBLswS();
											num = -430661395;
											continue;
										}
										goto case 8;
									case 5:
										result = true;
										goto end_IL_000c;
									case 23:
										switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
										{
										case 8:
											break;
										case 4:
											goto IL_0195;
										case 0:
											goto IL_0228;
										default:
											goto IL_030b;
										case 2:
											goto IL_0342;
										case 6:
											goto IL_035d;
										case 1:
										case 3:
										case 5:
										case 7:
											goto IL_038a;
										}
										goto case 7;
									case 18:
										goto end_IL_000c;
									case 13:
									{
										int num2;
										if (tIHhsDxbLPiZvUJtkhgZbVuHtex.MoveNext())
										{
											num = -430661398;
											num2 = num;
										}
										else
										{
											num = -430661400;
											num2 = num;
										}
										continue;
									}
									case 27:
										goto IL_0342;
									case 3:
										num = -430661392;
										continue;
									case 2:
										goto IL_035d;
									case 16:
										tELTJAehRERyRfVjJsKZqPWdpLV();
										num = -430661406;
										continue;
									case 15:
										result = true;
										num = -430661378;
										continue;
									default:
										goto IL_038a;
										IL_035d:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 5;
										num = -430661407;
										continue;
										IL_0342:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = -430661392;
										continue;
										IL_030b:
										num = -430661395;
										continue;
										IL_0228:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
										if (CheckInitialized())
										{
											QNaRGKpqtAKpmGfFblMuqNPJOBP = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.dvwDQcTsnkGAXAkiYcQEXuKabEmb().GetEnumerator();
											LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
											num = -430661393;
											continue;
										}
										goto IL_038a;
										IL_038a:
										result = false;
										goto end_IL_000c;
										IL_0195:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
										num = -430661382;
										continue;
									}
									goto IL_0007;
									continue;
									end_IL_000c:
									break;
								}
								break;
							}
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
						return result;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								EPLpAgrbJldUmRqjOaDQfvdYsOD();
							}
							break;
						}
						int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
						while (true)
						{
							int num = -369583783;
							while (true)
							{
								switch (num ^ -369583781)
								{
								case 0:
									break;
								case 2:
									switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
									{
									default:
										goto IL_0057;
									case 3:
									case 4:
										break;
									}
									try
									{
									}
									finally
									{
										tELTJAehRERyRfVjJsKZqPWdpLV();
									}
									goto default;
								default:
									switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
									{
									case 5:
									case 6:
										try
										{
										}
										finally
										{
											jIhhkwDwLwCcIUtlVmrvHzgoBGI();
										}
										break;
									}
									switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
									{
									case 7:
									case 8:
										try
										{
											break;
										}
										finally
										{
											JpYkGBVDgJfBLytefCLbETBLswS();
										}
									}
									return;
								}
								break;
								IL_0057:
								num = -369583782;
							}
						}
					}

					[DebuggerHidden]
					public vNkJjxcOVBBHLfqWxePnYLYgNkR(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void EPLpAgrbJldUmRqjOaDQfvdYsOD()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (QNaRGKpqtAKpmGfFblMuqNPJOBP != null)
						{
							QNaRGKpqtAKpmGfFblMuqNPJOBP.Dispose();
						}
					}

					private void tELTJAehRERyRfVjJsKZqPWdpLV()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (VkSEzvZNSZecsebwcdPLeZAaqED != null)
						{
							VkSEzvZNSZecsebwcdPLeZAaqED.Dispose();
						}
					}

					private void jIhhkwDwLwCcIUtlVmrvHzgoBGI()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						while (true)
						{
							int num = -965432229;
							while (true)
							{
								switch (num ^ -965432230)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									if (tIHhsDxbLPiZvUJtkhgZbVuHtex != null)
									{
										goto IL_002d;
									}
									return;
								case 2:
									return;
								}
								break;
								IL_002d:
								tIHhsDxbLPiZvUJtkhgZbVuHtex.Dispose();
								num = -965432232;
							}
						}
					}

					private void JpYkGBVDgJfBLytefCLbETBLswS()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (CsPKspkvlWWIAaUcXVcJqpknSzd == null)
						{
							return;
						}
						while (true)
						{
							int num = -811700181;
							while (true)
							{
								switch (num ^ -811700182)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									goto IL_002d;
								case 2:
									return;
								}
								break;
								IL_002d:
								CsPKspkvlWWIAaUcXVcJqpknSzd.Dispose();
								num = -811700184;
							}
						}
					}
				}

				private sealed class XxVeInCnEkNzScvpiXuwOcUBBVt : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public PollingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public ControllerPollingInfo VNAmeVPClUdUMaVdtlbUyQZYCeyk;

					public ControllerPollingInfo SrTUqkiIseGQJBMISpSiEsTCNQz;

					public ControllerPollingInfo rGoRlGUbEDuQSuFyWDUpOofzOLX;

					public ControllerPollingInfo TbgQNUebTyAPkyTpHFXmpjmOStL;

					public IEnumerator<ControllerPollingInfo> PfxUfRcnSkXiBhmLbzPXJcazAis;

					public IEnumerator<ControllerPollingInfo> sqQaIfYGCkKttXJzQxlrRhDygRKg;

					public IEnumerator<ControllerPollingInfo> ZLDbMElsqoNWqRjlLrjjaKzEfqwf;

					public IEnumerator<ControllerPollingInfo> qvdhZlrtHIEpLkjDgwVhUiDUWhAk;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						XxVeInCnEkNzScvpiXuwOcUBBVt xxVeInCnEkNzScvpiXuwOcUBBVt;
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							xxVeInCnEkNzScvpiXuwOcUBBVt = this;
							goto IL_0025;
						}
						goto IL_004e;
						IL_002a:
						int num;
						while (true)
						{
							switch (num ^ -1277556163)
							{
							case 2:
								break;
							case 1:
								num = -1277556162;
								continue;
							case 0:
								goto IL_004e;
							default:
								return xxVeInCnEkNzScvpiXuwOcUBBVt;
							}
							break;
						}
						goto IL_0025;
						IL_004e:
						xxVeInCnEkNzScvpiXuwOcUBBVt = new XxVeInCnEkNzScvpiXuwOcUBBVt(0);
						xxVeInCnEkNzScvpiXuwOcUBBVt.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = -1277556162;
						goto IL_002a;
						IL_0025:
						num = -1277556164;
						goto IL_002a;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						bool result = default(bool);
						try
						{
							int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
							while (true)
							{
								IL_0007:
								int num = 1505194007;
								while (true)
								{
									int num3;
									switch (num ^ 0x59B77016)
									{
									case 24:
										break;
									default:
										goto end_IL_000c;
									case 21:
										result = true;
										num = 1505194005;
										continue;
									case 6:
										TbgQNUebTyAPkyTpHFXmpjmOStL = qvdhZlrtHIEpLkjDgwVhUiDUWhAk.Current;
										num = 1505194011;
										continue;
									case 9:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
										num = 1505193984;
										continue;
									case 13:
										RDkWcsTpvDaNZojjIZONnoEBXPC = TbgQNUebTyAPkyTpHFXmpjmOStL;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 8;
										num = 1505193987;
										continue;
									case 19:
										if (!PfxUfRcnSkXiBhmLbzPXJcazAis.MoveNext())
										{
											ApNoJzzVlBTnIcANYEYXYJlOROM();
											sqQaIfYGCkKttXJzQxlrRhDygRKg = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.xYkfoZREkimMSyaRebVQAcNFERCb().GetEnumerator();
											LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
											num = 1505193984;
											continue;
										}
										goto case 5;
									case 7:
										num = 1505193989;
										continue;
									case 16:
										PfxUfRcnSkXiBhmLbzPXJcazAis = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.CFxlRMUlnOStZtjkmokPfvOCiq().GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = 1505194001;
										continue;
									case 23:
										rGoRlGUbEDuQSuFyWDUpOofzOLX = ZLDbMElsqoNWqRjlLrjjaKzEfqwf.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = rGoRlGUbEDuQSuFyWDUpOofzOLX;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 6;
										num = 1505194013;
										continue;
									case 4:
										goto IL_016e;
									case 14:
										if (!qvdhZlrtHIEpLkjDgwVhUiDUWhAk.MoveNext())
										{
											aRJmdkMpkBEuoxDDmXikFlUGhZy();
											num = 1505194010;
											continue;
										}
										goto case 6;
									case 8:
										goto IL_01b0;
									case 12:
										goto IL_01c1;
									case 15:
										goto IL_01cd;
									case 10:
										if (!ZLDbMElsqoNWqRjlLrjjaKzEfqwf.MoveNext())
										{
											YEwaBSTKEzhBhHKXhXeEcKocLWn();
											qvdhZlrtHIEpLkjDgwVhUiDUWhAk = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.yxdDYqIyvMkgblockvQWdELjtkL().GetEnumerator();
											LzqgRXjFXvJPbHjfzyAmNfcqezXL = 7;
											num = 1505194008;
											continue;
										}
										goto case 23;
									case 3:
										goto end_IL_000c;
									case 11:
										result = true;
										goto end_IL_000c;
									case 17:
										SrTUqkiIseGQJBMISpSiEsTCNQz = sqQaIfYGCkKttXJzQxlrRhDygRKg.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = SrTUqkiIseGQJBMISpSiEsTCNQz;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 4;
										result = true;
										goto end_IL_000c;
									case 20:
										LxUiCnpUSFgmKoRWYHqqPpDZUrc();
										ZLDbMElsqoNWqRjlLrjjaKzEfqwf = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.gdrcxxklAWXerFCQbSVzkXEdgxU().GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 5;
										num = 1505194006;
										continue;
									case 0:
										num = 1505194012;
										continue;
									case 5:
										VNAmeVPClUdUMaVdtlbUyQZYCeyk = PfxUfRcnSkXiBhmLbzPXJcazAis.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = VNAmeVPClUdUMaVdtlbUyQZYCeyk;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										result = true;
										goto end_IL_000c;
									case 2:
										goto IL_02d9;
									case 22:
									{
										int num2;
										if (!sqQaIfYGCkKttXJzQxlrRhDygRKg.MoveNext())
										{
											num = 1505193986;
											num2 = num;
										}
										else
										{
											num = 1505193991;
											num2 = num;
										}
										continue;
									}
									case 1:
										switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
										{
										case 4:
											break;
										case 0:
											goto IL_016e;
										case 8:
											goto IL_01b0;
										case 1:
										case 3:
										case 5:
										case 7:
											goto IL_01c1;
										case 2:
											goto IL_01cd;
										case 6:
											goto IL_02d9;
										default:
											goto IL_0335;
										}
										goto case 9;
									case 18:
										goto end_IL_000c;
										IL_0335:
										num = 1505194010;
										continue;
										IL_02d9:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 5;
										num = 1505194012;
										continue;
										IL_01cd:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = 1505193989;
										continue;
										IL_01c1:
										result = false;
										num = 1505193988;
										continue;
										IL_01b0:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 7;
										num = 1505194008;
										continue;
										IL_016e:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
										if (CheckInitialized())
										{
											num = 1505193990;
											num3 = num;
										}
										else
										{
											num = 1505194010;
											num3 = num;
										}
										continue;
									}
									goto IL_0007;
									continue;
									end_IL_000c:
									break;
								}
								break;
							}
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
						return result;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								ApNoJzzVlBTnIcANYEYXYJlOROM();
							}
							break;
						}
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								LxUiCnpUSFgmKoRWYHqqPpDZUrc();
							}
							break;
						}
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 5:
						case 6:
							try
							{
							}
							finally
							{
								YEwaBSTKEzhBhHKXhXeEcKocLWn();
							}
							break;
						}
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 7:
						case 8:
							try
							{
								break;
							}
							finally
							{
								aRJmdkMpkBEuoxDDmXikFlUGhZy();
							}
						}
					}

					[DebuggerHidden]
					public XxVeInCnEkNzScvpiXuwOcUBBVt(int _003C_003E1__state)
					{
						while (true)
						{
							int num = -115615510;
							while (true)
							{
								switch (num ^ -115615509)
								{
								case 2:
									break;
								case 1:
									goto IL_0024;
								default:
									iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
									return;
								}
								break;
								IL_0024:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
								num = -115615509;
							}
						}
					}

					private void ApNoJzzVlBTnIcANYEYXYJlOROM()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (PfxUfRcnSkXiBhmLbzPXJcazAis == null)
						{
							return;
						}
						while (true)
						{
							int num = -678246885;
							while (true)
							{
								switch (num ^ -678246886)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									goto IL_002d;
								case 2:
									return;
								}
								break;
								IL_002d:
								PfxUfRcnSkXiBhmLbzPXJcazAis.Dispose();
								num = -678246888;
							}
						}
					}

					private void LxUiCnpUSFgmKoRWYHqqPpDZUrc()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (sqQaIfYGCkKttXJzQxlrRhDygRKg != null)
						{
							sqQaIfYGCkKttXJzQxlrRhDygRKg.Dispose();
						}
					}

					private void YEwaBSTKEzhBhHKXhXeEcKocLWn()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ZLDbMElsqoNWqRjlLrjjaKzEfqwf != null)
						{
							ZLDbMElsqoNWqRjlLrjjaKzEfqwf.Dispose();
						}
					}

					private void aRJmdkMpkBEuoxDDmXikFlUGhZy()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						while (true)
						{
							int num = 2049480810;
							while (true)
							{
								switch (num ^ 0x7A289868)
								{
								case 0:
									break;
								default:
									return;
								case 2:
									if (qvdhZlrtHIEpLkjDgwVhUiDUWhAk != null)
									{
										goto IL_002d;
									}
									return;
								case 1:
									return;
								}
								break;
								IL_002d:
								qvdhZlrtHIEpLkjDgwVhUiDUWhAk.Dispose();
								num = 2049480809;
							}
						}
					}
				}

				private sealed class ErBAKsEakGoRJtOxBiIlvzLQdQAb : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public PollingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public ControllerPollingInfo tJORuKnbPQrtzCnktgLBBEQUneEe;

					public ControllerPollingInfo KHeUskychZvsTqCkxhgliEWMqmMO;

					public ControllerPollingInfo epGcCgecqcFwQGruzcGrKtLDdqn;

					public ControllerPollingInfo hczzQzOomcWXzPPTxiLaVZbpKus;

					public IEnumerator<ControllerPollingInfo> cZRBVVfnECMtxrbIXJxdNMmpPfFH;

					public IEnumerator<ControllerPollingInfo> BjNBqvhcZCqLLNnsUHlsJFIUgQXt;

					public IEnumerator<ControllerPollingInfo> rABpyOvHEbtwtZadKBXCaebroGpb;

					public IEnumerator<ControllerPollingInfo> iryKuNKCyFFvxxXNYVEwDdoeaJO;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						ErBAKsEakGoRJtOxBiIlvzLQdQAb erBAKsEakGoRJtOxBiIlvzLQdQAb;
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							erBAKsEakGoRJtOxBiIlvzLQdQAb = this;
							goto IL_0025;
						}
						goto IL_004e;
						IL_002a:
						int num;
						while (true)
						{
							switch (num ^ -88300208)
							{
							case 0:
								break;
							case 2:
								num = -88300207;
								continue;
							case 3:
								goto IL_004e;
							default:
								return erBAKsEakGoRJtOxBiIlvzLQdQAb;
							}
							break;
						}
						goto IL_0025;
						IL_004e:
						erBAKsEakGoRJtOxBiIlvzLQdQAb = new ErBAKsEakGoRJtOxBiIlvzLQdQAb(0);
						erBAKsEakGoRJtOxBiIlvzLQdQAb.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = -88300207;
						goto IL_002a;
						IL_0025:
						num = -88300206;
						goto IL_002a;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						bool result = default(bool);
						try
						{
							int num;
							int num3;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							default:
								num = 776888964;
								goto IL_0036;
							case 6:
								goto IL_0169;
							case 2:
								goto IL_0266;
							case 4:
								goto IL_02b4;
							case 0:
								goto IL_02c5;
							case 8:
								goto IL_0324;
							case 1:
							case 3:
							case 5:
							case 7:
								break;
								IL_0036:
								while (true)
								{
									switch (num ^ 0x2E4E6290)
									{
									case 24:
										break;
									case 22:
										num = 776888986;
										continue;
									case 3:
										goto IL_00bc;
									case 11:
										goto end_IL_0000;
									case 10:
										if (!rABpyOvHEbtwtZadKBXCaebroGpb.MoveNext())
										{
											xpXIxJAimPhzRlmfUQVpagQTyVp();
											iryKuNKCyFFvxxXNYVEwDdoeaJO = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.dxVKSduPGjjgfiVGZfHmUfUnfTp().GetEnumerator();
											LzqgRXjFXvJPbHjfzyAmNfcqezXL = 7;
											num = 776888979;
											continue;
										}
										goto case 26;
									case 8:
										RDkWcsTpvDaNZojjIZONnoEBXPC = tJORuKnbPQrtzCnktgLBBEQUneEe;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										result = true;
										goto end_IL_0000;
									case 2:
										CtNDGBhmAlfDIFPnaiNPIjgxrkPy();
										num = 776888981;
										continue;
									case 21:
										result = true;
										num = 776888960;
										continue;
									case 25:
										goto IL_0169;
									case 7:
										RDkWcsTpvDaNZojjIZONnoEBXPC = epGcCgecqcFwQGruzcGrKtLDdqn;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 6;
										num = 776888982;
										continue;
									case 16:
										goto end_IL_0000;
									case 9:
										tJORuKnbPQrtzCnktgLBBEQUneEe = cZRBVVfnECMtxrbIXJxdNMmpPfFH.Current;
										num = 776888984;
										continue;
									case 12:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 8;
										result = true;
										num = 776888962;
										continue;
									case 4:
										KHeUskychZvsTqCkxhgliEWMqmMO = BjNBqvhcZCqLLNnsUHlsJFIUgQXt.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = KHeUskychZvsTqCkxhgliEWMqmMO;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 4;
										num = 776888965;
										continue;
									case 18:
										goto end_IL_0000;
									case 13:
										if (!cZRBVVfnECMtxrbIXJxdNMmpPfFH.MoveNext())
										{
											mhQZtbdodZwfHQpYCFCdeenxvim();
											BjNBqvhcZCqLLNnsUHlsJFIUgQXt = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.XzuyRyAOJjyALLhPWbokPtkFsjX().GetEnumerator();
											LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
											num = 776888977;
											continue;
										}
										goto case 9;
									case 26:
										epGcCgecqcFwQGruzcGrKtLDdqn = rABpyOvHEbtwtZadKBXCaebroGpb.Current;
										num = 776888983;
										continue;
									case 0:
										goto IL_0266;
									case 1:
										if (!BjNBqvhcZCqLLNnsUHlsJFIUgQXt.MoveNext())
										{
											lGfKUIdFtFlTTiPWdmxMLiISeBY();
											rABpyOvHEbtwtZadKBXCaebroGpb = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.DeTCsDGLpHqPnFfUIAtMoelubGtE().GetEnumerator();
											LzqgRXjFXvJPbHjfzyAmNfcqezXL = 5;
											num = 776888966;
											continue;
										}
										goto case 4;
									case 14:
										goto IL_02b4;
									case 23:
										goto IL_02c5;
									case 6:
										result = true;
										num = 776888987;
										continue;
									case 20:
										num = 776888981;
										continue;
									case 19:
										cZRBVVfnECMtxrbIXJxdNMmpPfFH = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.kFBCFTCQMRsQtGnDWpwZBsNboxzu().GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = 776888989;
										continue;
									case 17:
										goto IL_0324;
									case 15:
										hczzQzOomcWXzPPTxiLaVZbpKus = iryKuNKCyFFvxxXNYVEwDdoeaJO.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = hczzQzOomcWXzPPTxiLaVZbpKus;
										num = 776888988;
										continue;
									default:
										goto end_IL_0008;
									}
									break;
									IL_00bc:
									int num2;
									if (iryKuNKCyFFvxxXNYVEwDdoeaJO.MoveNext())
									{
										num = 776888991;
										num2 = num;
									}
									else
									{
										num = 776888978;
										num2 = num;
									}
								}
								goto default;
								IL_0324:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 7;
								num = 776888979;
								goto IL_0036;
								IL_02c5:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (!CheckInitialized())
								{
									num = 776888981;
									num3 = num;
								}
								else
								{
									num = 776888963;
									num3 = num;
								}
								goto IL_0036;
								IL_0266:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 776888989;
								goto IL_0036;
								IL_0169:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 5;
								num = 776888986;
								goto IL_0036;
								IL_02b4:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
								num = 776888977;
								goto IL_0036;
								end_IL_0008:
								break;
							}
							result = false;
							end_IL_0000:;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
						return result;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								mhQZtbdodZwfHQpYCFCdeenxvim();
							}
							break;
						}
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								lGfKUIdFtFlTTiPWdmxMLiISeBY();
							}
							break;
						}
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 5:
						case 6:
							try
							{
							}
							finally
							{
								xpXIxJAimPhzRlmfUQVpagQTyVp();
							}
							break;
						}
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 7:
						case 8:
							try
							{
								break;
							}
							finally
							{
								CtNDGBhmAlfDIFPnaiNPIjgxrkPy();
							}
						}
					}

					[DebuggerHidden]
					public ErBAKsEakGoRJtOxBiIlvzLQdQAb(int _003C_003E1__state)
					{
						while (true)
						{
							int num = 692661378;
							while (true)
							{
								switch (num ^ 0x29492C80)
								{
								case 0:
									break;
								default:
									return;
								case 2:
									goto IL_0024;
								case 1:
									return;
								}
								break;
								IL_0024:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
								iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
								num = 692661377;
							}
						}
					}

					private void mhQZtbdodZwfHQpYCFCdeenxvim()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (cZRBVVfnECMtxrbIXJxdNMmpPfFH == null)
						{
							return;
						}
						while (true)
						{
							int num = 710120999;
							while (true)
							{
								switch (num ^ 0x2A539626)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									goto IL_002d;
								case 2:
									return;
								}
								break;
								IL_002d:
								cZRBVVfnECMtxrbIXJxdNMmpPfFH.Dispose();
								num = 710120996;
							}
						}
					}

					private void lGfKUIdFtFlTTiPWdmxMLiISeBY()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (BjNBqvhcZCqLLNnsUHlsJFIUgQXt == null)
						{
							return;
						}
						while (true)
						{
							int num = 814407343;
							while (true)
							{
								switch (num ^ 0x308ADEAD)
								{
								case 0:
									break;
								default:
									return;
								case 2:
									goto IL_002d;
								case 1:
									return;
								}
								break;
								IL_002d:
								BjNBqvhcZCqLLNnsUHlsJFIUgQXt.Dispose();
								num = 814407340;
							}
						}
					}

					private void xpXIxJAimPhzRlmfUQVpagQTyVp()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (rABpyOvHEbtwtZadKBXCaebroGpb != null)
						{
							rABpyOvHEbtwtZadKBXCaebroGpb.Dispose();
						}
					}

					private void CtNDGBhmAlfDIFPnaiNPIjgxrkPy()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						while (true)
						{
							int num = -320292447;
							while (true)
							{
								switch (num ^ -320292448)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									if (iryKuNKCyFFvxxXNYVEwDdoeaJO != null)
									{
										goto IL_002d;
									}
									return;
								case 2:
									return;
								}
								break;
								IL_002d:
								iryKuNKCyFFvxxXNYVEwDdoeaJO.Dispose();
								num = -320292446;
							}
						}
					}
				}

				private sealed class XahRduYcitFKDxCPECwdFFFCnTeu : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public PollingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public ControllerPollingInfo JKeFjDpFEajcMkeBOOikYaMwbQu;

					public ControllerPollingInfo SbsxNBpkZzIJozwSyRJvGFpwddZ;

					public ControllerPollingInfo hwnsuCrKABCqQCVqeBtwcLcNAtW;

					public ControllerPollingInfo AHjmyYAyYNKWoSPIIlECgctnZoF;

					public IEnumerator<ControllerPollingInfo> TBDIQRJGfObIDuRHhbJcjWdJmbYc;

					public IEnumerator<ControllerPollingInfo> LYSNXmiBBVERlVpFRBybsSzMPRy;

					public IEnumerator<ControllerPollingInfo> hVhojQvPJEnKdBpdIDUFjAcmvim;

					public IEnumerator<ControllerPollingInfo> dvqGeJecDbWMPHaVjCLPShvmJxI;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
						{
							goto IL_0012;
						}
						goto IL_0063;
						IL_0012:
						int num = -169443511;
						goto IL_0017;
						IL_0017:
						XahRduYcitFKDxCPECwdFFFCnTeu xahRduYcitFKDxCPECwdFFFCnTeu = default(XahRduYcitFKDxCPECwdFFFCnTeu);
						while (true)
						{
							switch (num ^ -169443507)
							{
							case 2:
								break;
							case 4:
								goto IL_0038;
							case 0:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
								xahRduYcitFKDxCPECwdFFFCnTeu = this;
								num = -169443508;
								continue;
							case 3:
								goto IL_0063;
							default:
								return xahRduYcitFKDxCPECwdFFFCnTeu;
							}
							break;
							IL_0038:
							int num2;
							if (LzqgRXjFXvJPbHjfzyAmNfcqezXL != -2)
							{
								num = -169443506;
								num2 = num;
							}
							else
							{
								num = -169443507;
								num2 = num;
							}
						}
						goto IL_0012;
						IL_0063:
						xahRduYcitFKDxCPECwdFFFCnTeu = new XahRduYcitFKDxCPECwdFFFCnTeu(0);
						xahRduYcitFKDxCPECwdFFFCnTeu.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = -169443508;
						goto IL_0017;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						bool result = default(bool);
						try
						{
							int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
							while (true)
							{
								IL_0007:
								int num = -1626255326;
								while (true)
								{
									switch (num ^ -1626255324)
									{
									case 16:
										break;
									case 20:
									{
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
										int num2;
										if (!CheckInitialized())
										{
											num = -1626255300;
											num2 = num;
										}
										else
										{
											num = -1626255328;
											num2 = num;
										}
										continue;
									}
									case 23:
										if (!hVhojQvPJEnKdBpdIDUFjAcmvim.MoveNext())
										{
											TvMYdbImoXcXMAVfnEBzeAgHDn();
											dvqGeJecDbWMPHaVjCLPShvmJxI = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.RdDifOaDAnORDxQFDIoqLlKJvVwB().GetEnumerator();
											num = -1626255306;
											continue;
										}
										goto case 1;
									case 0:
										AHjmyYAyYNKWoSPIIlECgctnZoF = dvqGeJecDbWMPHaVjCLPShvmJxI.Current;
										num = -1626255311;
										continue;
									case 2:
										num = -1626255300;
										continue;
									case 18:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 7;
										num = -1626255315;
										continue;
									case 8:
										result = true;
										goto end_IL_000c;
									case 17:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										result = true;
										num = -1626255320;
										continue;
									case 12:
										goto end_IL_000c;
									case 5:
										if (!TBDIQRJGfObIDuRHhbJcjWdJmbYc.MoveNext())
										{
											yDQEPxReKKArmhOSuCYdwpGGkzVb();
											LYSNXmiBBVERlVpFRBybsSzMPRy = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.xYkfoZREkimMSyaRebVQAcNFERCb().GetEnumerator();
											LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
											num = -1626255314;
											continue;
										}
										goto case 13;
									case 15:
										goto IL_017e;
									case 7:
										goto IL_018f;
									case 22:
										SbsxNBpkZzIJozwSyRJvGFpwddZ = LYSNXmiBBVERlVpFRBybsSzMPRy.Current;
										num = -1626255313;
										continue;
									case 19:
										goto IL_01bb;
									case 11:
										RDkWcsTpvDaNZojjIZONnoEBXPC = SbsxNBpkZzIJozwSyRJvGFpwddZ;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 4;
										num = -1626255318;
										continue;
									case 3:
										goto IL_01e9;
									case 10:
										if (!LYSNXmiBBVERlVpFRBybsSzMPRy.MoveNext())
										{
											qtMKqCPKNzjychFzqfJStKEUoFfd();
											hVhojQvPJEnKdBpdIDUFjAcmvim = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.lmSnIdpGCHOCWsoOFiSqZxXYdcQI().GetEnumerator();
											LzqgRXjFXvJPbHjfzyAmNfcqezXL = 5;
											num = -1626255309;
											continue;
										}
										goto case 22;
									case 4:
										TBDIQRJGfObIDuRHhbJcjWdJmbYc = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.FBPCcdDOXVAyPwkzsmgJgnerhxo().GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = -1626255327;
										continue;
									case 9:
										if (!dvqGeJecDbWMPHaVjCLPShvmJxI.MoveNext())
										{
											sXTlxuYwVydpWlPCqmOzFnSZrPp();
											num = -1626255300;
											continue;
										}
										goto case 0;
									case 6:
										switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
										{
										case 0:
											break;
										case 2:
											goto IL_017e;
										case 6:
											goto IL_018f;
										case 8:
											goto IL_01bb;
										case 4:
											goto IL_01e9;
										default:
											goto IL_02a5;
										case 1:
										case 3:
										case 5:
										case 7:
											goto IL_0333;
										}
										goto case 20;
									case 13:
										JKeFjDpFEajcMkeBOOikYaMwbQu = TBDIQRJGfObIDuRHhbJcjWdJmbYc.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = JKeFjDpFEajcMkeBOOikYaMwbQu;
										num = -1626255307;
										continue;
									case 1:
										hwnsuCrKABCqQCVqeBtwcLcNAtW = hVhojQvPJEnKdBpdIDUFjAcmvim.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = hwnsuCrKABCqQCVqeBtwcLcNAtW;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 6;
										result = true;
										goto end_IL_000c;
									case 21:
										RDkWcsTpvDaNZojjIZONnoEBXPC = AHjmyYAyYNKWoSPIIlECgctnZoF;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 8;
										num = -1626255316;
										continue;
									case 14:
										result = true;
										goto end_IL_000c;
									default:
										goto IL_0333;
										IL_0333:
										result = false;
										goto end_IL_000c;
										IL_02a5:
										num = -1626255322;
										continue;
										IL_01e9:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
										num = -1626255314;
										continue;
										IL_01bb:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 7;
										num = -1626255315;
										continue;
										IL_018f:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 5;
										num = -1626255309;
										continue;
										IL_017e:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = -1626255327;
										continue;
									}
									goto IL_0007;
									continue;
									end_IL_000c:
									break;
								}
								break;
							}
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
						return result;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								yDQEPxReKKArmhOSuCYdwpGGkzVb();
							}
							break;
						}
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								qtMKqCPKNzjychFzqfJStKEUoFfd();
							}
							break;
						}
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 5:
						case 6:
							try
							{
							}
							finally
							{
								TvMYdbImoXcXMAVfnEBzeAgHDn();
							}
							break;
						}
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 7:
						case 8:
							try
							{
								break;
							}
							finally
							{
								sXTlxuYwVydpWlPCqmOzFnSZrPp();
							}
						}
					}

					[DebuggerHidden]
					public XahRduYcitFKDxCPECwdFFFCnTeu(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void yDQEPxReKKArmhOSuCYdwpGGkzVb()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (TBDIQRJGfObIDuRHhbJcjWdJmbYc != null)
						{
							TBDIQRJGfObIDuRHhbJcjWdJmbYc.Dispose();
						}
					}

					private void qtMKqCPKNzjychFzqfJStKEUoFfd()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (LYSNXmiBBVERlVpFRBybsSzMPRy != null)
						{
							LYSNXmiBBVERlVpFRBybsSzMPRy.Dispose();
						}
					}

					private void TvMYdbImoXcXMAVfnEBzeAgHDn()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (hVhojQvPJEnKdBpdIDUFjAcmvim != null)
						{
							hVhojQvPJEnKdBpdIDUFjAcmvim.Dispose();
						}
					}

					private void sXTlxuYwVydpWlPCqmOzFnSZrPp()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (dvqGeJecDbWMPHaVjCLPShvmJxI != null)
						{
							dvqGeJecDbWMPHaVjCLPShvmJxI.Dispose();
						}
					}
				}

				private sealed class wSDexTAZCWmzKmqzewllUGzMPVpr : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public PollingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public ControllerPollingInfo JyUlMfFhrtDAlEAoZJMVSEMfJJj;

					public ControllerPollingInfo uIwPFCaKarooPOkPOgLDEnQIviIU;

					public ControllerPollingInfo nbRRAxbbsBYRMreNqyJkHaXGmph;

					public IEnumerator<ControllerPollingInfo> kLMMbjMGmzewiwsYMcfVmygfHWE;

					public IEnumerator<ControllerPollingInfo> gFWmPachGJIBjkojxEIicCXLCoIQ;

					public IEnumerator<ControllerPollingInfo> lkgDgJKTdplLHmQuoKswCSECAabq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							goto IL_001c;
						}
						goto IL_0050;
						IL_0050:
						wSDexTAZCWmzKmqzewllUGzMPVpr wSDexTAZCWmzKmqzewllUGzMPVpr2 = new wSDexTAZCWmzKmqzewllUGzMPVpr(0);
						wSDexTAZCWmzKmqzewllUGzMPVpr2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						int num = -1995237610;
						goto IL_0021;
						IL_001c:
						num = -1995237613;
						goto IL_0021;
						IL_0021:
						while (true)
						{
							switch (num ^ -1995237609)
							{
							case 0:
								break;
							case 4:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
								num = -1995237612;
								continue;
							case 2:
								goto IL_0050;
							case 3:
								wSDexTAZCWmzKmqzewllUGzMPVpr2 = this;
								num = -1995237610;
								continue;
							default:
								return wSDexTAZCWmzKmqzewllUGzMPVpr2;
							}
							break;
						}
						goto IL_001c;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							default:
								num = 655261204;
								goto IL_002e;
							case 6:
								goto IL_00b2;
							case 0:
								goto IL_00c3;
							case 4:
								goto IL_0174;
							case 2:
								goto IL_024c;
							case 1:
							case 3:
							case 5:
								break;
								IL_002e:
								while (true)
								{
									switch (num ^ 0x270E7E07)
									{
									case 3:
										break;
									case 4:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 6;
										num = 655261190;
										continue;
									case 18:
										num = 655261192;
										continue;
									case 8:
										goto IL_00b2;
									case 9:
										goto IL_00c3;
									case 5:
										JyUlMfFhrtDAlEAoZJMVSEMfJJj = kLMMbjMGmzewiwsYMcfVmygfHWE.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = JyUlMfFhrtDAlEAoZJMVSEMfJJj;
										num = 655261185;
										continue;
									case 15:
										goto IL_00fb;
									case 16:
										nbRRAxbbsBYRMreNqyJkHaXGmph = lkgDgJKTdplLHmQuoKswCSECAabq.Current;
										num = 655261189;
										continue;
									case 22:
										if (!gFWmPachGJIBjkojxEIicCXLCoIQ.MoveNext())
										{
											HhqAfuzhJPPWEofwyzLIdyLjTsj();
											lkgDgJKTdplLHmQuoKswCSECAabq = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.HMKERaxpOodqZfIamnsIXKLtAwvF().GetEnumerator();
											LzqgRXjFXvJPbHjfzyAmNfcqezXL = 5;
											num = 655261193;
											continue;
										}
										goto case 12;
									case 17:
										goto IL_0174;
									case 0:
										goto IL_0185;
									case 20:
										num = 655261201;
										continue;
									case 19:
										num = 655261197;
										continue;
									case 14:
										if (!lkgDgJKTdplLHmQuoKswCSECAabq.MoveNext())
										{
											FCfdxzFrbbjEpBMzHGWKoqWaFtpy();
											num = 655261197;
											continue;
										}
										goto case 16;
									case 7:
										LhffEycPPwPAVyBohATFAKsZhmCl();
										gFWmPachGJIBjkojxEIicCXLCoIQ = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.bLVygRZbxibgWFbIdFaUPVtRMuny().GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
										num = 655261203;
										continue;
									case 12:
										uIwPFCaKarooPOkPOgLDEnQIviIU = gFWmPachGJIBjkojxEIicCXLCoIQ.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = uIwPFCaKarooPOkPOgLDEnQIviIU;
										num = 655261194;
										continue;
									case 2:
										RDkWcsTpvDaNZojjIZONnoEBXPC = nbRRAxbbsBYRMreNqyJkHaXGmph;
										num = 655261187;
										continue;
									case 1:
										return true;
									case 21:
										goto IL_024c;
									case 11:
										kLMMbjMGmzewiwsYMcfVmygfHWE = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.zStUtarppXmOxgicfxgZXjzciwH().GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = 655261205;
										continue;
									case 13:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 4;
										return true;
									case 6:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										return true;
									default:
										goto end_IL_0008;
									}
									break;
									IL_0185:
									int num2;
									if (CheckInitialized())
									{
										num = 655261196;
										num2 = num;
									}
									else
									{
										num = 655261197;
										num2 = num;
									}
									continue;
									IL_00fb:
									int num3;
									if (kLMMbjMGmzewiwsYMcfVmygfHWE.MoveNext())
									{
										num = 655261186;
										num3 = num;
									}
									else
									{
										num = 655261184;
										num3 = num;
									}
								}
								goto default;
								IL_024c:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 655261192;
								goto IL_002e;
								IL_0174:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
								num = 655261201;
								goto IL_002e;
								IL_00c3:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								num = 655261191;
								goto IL_002e;
								IL_00b2:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 5;
								num = 655261193;
								goto IL_002e;
								end_IL_0008:
								break;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								LhffEycPPwPAVyBohATFAKsZhmCl();
							}
							break;
						}
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								HhqAfuzhJPPWEofwyzLIdyLjTsj();
							}
							break;
						}
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 5:
						case 6:
							try
							{
								break;
							}
							finally
							{
								FCfdxzFrbbjEpBMzHGWKoqWaFtpy();
							}
						}
					}

					[DebuggerHidden]
					public wSDexTAZCWmzKmqzewllUGzMPVpr(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void LhffEycPPwPAVyBohATFAKsZhmCl()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (kLMMbjMGmzewiwsYMcfVmygfHWE != null)
						{
							kLMMbjMGmzewiwsYMcfVmygfHWE.Dispose();
						}
					}

					private void HhqAfuzhJPPWEofwyzLIdyLjTsj()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (gFWmPachGJIBjkojxEIicCXLCoIQ != null)
						{
							gFWmPachGJIBjkojxEIicCXLCoIQ.Dispose();
						}
					}

					private void FCfdxzFrbbjEpBMzHGWKoqWaFtpy()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (lkgDgJKTdplLHmQuoKswCSECAabq != null)
						{
							lkgDgJKTdplLHmQuoKswCSECAabq.Dispose();
						}
					}
				}

				private sealed class QrUvmjopEDkYVzAxILkVuZUjpSE : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public IList<Joystick> VxyEimxXltRAYdKpVfJKgogEvZrB;

					public int YaiGlgGrJTbMHavWLMygWstUkAwr;

					public ControllerPollingInfo btgnbSJPWjyaemBIjcbbOIkpknt;

					public PollingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ControllerPollingInfo> iQIaIHMNcvZqdPobixqhpqIudXu;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						QrUvmjopEDkYVzAxILkVuZUjpSE qrUvmjopEDkYVzAxILkVuZUjpSE;
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							qrUvmjopEDkYVzAxILkVuZUjpSE = this;
							goto IL_0025;
						}
						goto IL_005e;
						IL_002a:
						int num;
						while (true)
						{
							switch (num ^ -1189328346)
							{
							case 2:
								break;
							case 0:
								qrUvmjopEDkYVzAxILkVuZUjpSE.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
								num = -1189328350;
								continue;
							case 3:
								goto IL_005e;
							case 1:
								num = -1189328350;
								continue;
							default:
								return qrUvmjopEDkYVzAxILkVuZUjpSE;
							}
							break;
						}
						goto IL_0025;
						IL_005e:
						qrUvmjopEDkYVzAxILkVuZUjpSE = new QrUvmjopEDkYVzAxILkVuZUjpSE(0);
						num = -1189328346;
						goto IL_002a;
						IL_0025:
						num = -1189328345;
						goto IL_002a;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						bool result = default(bool);
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 0:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								num = 1931877021;
								goto IL_0023;
							case 2:
								goto IL_0132;
								IL_0023:
								while (true)
								{
									switch (num ^ 0x73261A96)
									{
									case 8:
										num = 1931877015;
										continue;
									case 5:
										btgnbSJPWjyaemBIjcbbOIkpknt = iQIaIHMNcvZqdPobixqhpqIudXu.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = btgnbSJPWjyaemBIjcbbOIkpknt;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										num = 1931877009;
										continue;
									case 11:
										VxyEimxXltRAYdKpVfJKgogEvZrB = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Joysticks_readOnly;
										YaiGlgGrJTbMHavWLMygWstUkAwr = 0;
										num = 1931877008;
										continue;
									case 4:
										UnFmnJmvdGcxTdfoHQDwnARUueQ();
										YaiGlgGrJTbMHavWLMygWstUkAwr++;
										num = 1931877008;
										continue;
									case 1:
										break;
									case 7:
										result = true;
										num = 1931877014;
										continue;
									case 3:
										goto IL_00ea;
									case 6:
										goto IL_010b;
									case 2:
										goto IL_0132;
									case 10:
										iQIaIHMNcvZqdPobixqhpqIudXu = VxyEimxXltRAYdKpVfJKgogEvZrB[YaiGlgGrJTbMHavWLMygWstUkAwr].PollForAllElements().GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = 1931877013;
										continue;
									case 0:
										goto end_IL_0000;
									default:
										goto end_IL_0008;
									}
									break;
									IL_010b:
									int num2;
									if (YaiGlgGrJTbMHavWLMygWstUkAwr < VxyEimxXltRAYdKpVfJKgogEvZrB.Count)
									{
										num = 1931877020;
										num2 = num;
									}
									else
									{
										num = 1931877023;
										num2 = num;
									}
									continue;
									IL_00ea:
									int num3;
									if (iQIaIHMNcvZqdPobixqhpqIudXu.MoveNext())
									{
										num = 1931877011;
										num3 = num;
									}
									else
									{
										num = 1931877010;
										num3 = num;
									}
								}
								goto case 0;
								IL_0132:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 1931877013;
								goto IL_0023;
								end_IL_0008:
								break;
							}
							result = false;
							end_IL_0000:;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
						return result;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
						while (true)
						{
							int num = -1189902284;
							while (true)
							{
								switch (num ^ -1189902283)
								{
								case 2:
									break;
								default:
									return;
								case 1:
									switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
									{
									case 1:
									case 2:
										try
										{
											return;
										}
										finally
										{
											UnFmnJmvdGcxTdfoHQDwnARUueQ();
										}
									}
									goto IL_0035;
								case 0:
									return;
								}
								break;
								IL_0035:
								num = -1189902283;
							}
						}
					}

					[DebuggerHidden]
					public QrUvmjopEDkYVzAxILkVuZUjpSE(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void UnFmnJmvdGcxTdfoHQDwnARUueQ()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						while (true)
						{
							int num = 1523144488;
							while (true)
							{
								switch (num ^ 0x5AC95729)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									if (iQIaIHMNcvZqdPobixqhpqIudXu != null)
									{
										goto IL_002d;
									}
									return;
								case 2:
									return;
								}
								break;
								IL_002d:
								iQIaIHMNcvZqdPobixqhpqIudXu.Dispose();
								num = 1523144491;
							}
						}
					}
				}

				private sealed class YYSnUrUCBMiUYAokSBKKCJifycPN : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public IList<Joystick> MlpNgeZwoUSpEjmKNXpEnlXicyYH;

					public int ynlmTUQPpJuFZbkrSeGgEJCqYgb;

					public ControllerPollingInfo pDmDKiGKIyAPtIMAWiQiTbJmXDm;

					public PollingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ControllerPollingInfo> eTCIucakieepoAfGYJcFtUXBMqWd;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							goto IL_0023;
						}
						goto IL_0067;
						IL_0028:
						int num;
						YYSnUrUCBMiUYAokSBKKCJifycPN yYSnUrUCBMiUYAokSBKKCJifycPN = default(YYSnUrUCBMiUYAokSBKKCJifycPN);
						while (true)
						{
							switch (num ^ 0x3FE916AD)
							{
							case 2:
								break;
							case 4:
								yYSnUrUCBMiUYAokSBKKCJifycPN.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
								num = 1072240300;
								continue;
							case 0:
								num = 1072240300;
								continue;
							case 5:
								goto IL_0067;
							case 3:
								yYSnUrUCBMiUYAokSBKKCJifycPN = this;
								num = 1072240301;
								continue;
							default:
								return yYSnUrUCBMiUYAokSBKKCJifycPN;
							}
							break;
						}
						goto IL_0023;
						IL_0067:
						yYSnUrUCBMiUYAokSBKKCJifycPN = new YYSnUrUCBMiUYAokSBKKCJifycPN(0);
						num = 1072240297;
						goto IL_0028;
						IL_0023:
						num = 1072240302;
						goto IL_0028;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						bool result = default(bool);
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							default:
								num = -1281616361;
								goto IL_001e;
							case 0:
								goto IL_0113;
							case 2:
								goto IL_0124;
							case 1:
								goto IL_018e;
								IL_001e:
								while (true)
								{
									switch (num ^ -1281616364)
									{
									case 0:
										break;
									default:
										goto end_IL_0008;
									case 3:
										num = -1281616359;
										continue;
									case 7:
										KaihOYfVHxCPutELeYFjCuGyVUO();
										ynlmTUQPpJuFZbkrSeGgEJCqYgb++;
										num = -1281616354;
										continue;
									case 1:
										eTCIucakieepoAfGYJcFtUXBMqWd = MlpNgeZwoUSpEjmKNXpEnlXicyYH[ynlmTUQPpJuFZbkrSeGgEJCqYgb].PollForAllElementsDown().GetEnumerator();
										num = -1281616356;
										continue;
									case 11:
										goto IL_00b3;
									case 4:
										goto end_IL_0008;
									case 9:
										pDmDKiGKIyAPtIMAWiQiTbJmXDm = eTCIucakieepoAfGYJcFtUXBMqWd.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = pDmDKiGKIyAPtIMAWiQiTbJmXDm;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										result = true;
										num = -1281616368;
										continue;
									case 6:
										goto IL_0113;
									case 5:
										goto IL_0124;
									case 10:
										goto IL_0135;
									case 2:
										MlpNgeZwoUSpEjmKNXpEnlXicyYH = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Joysticks_readOnly;
										ynlmTUQPpJuFZbkrSeGgEJCqYgb = 0;
										num = -1281616354;
										continue;
									case 8:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = -1281616353;
										continue;
									case 13:
										goto IL_018e;
									case 12:
										goto end_IL_0008;
									}
									break;
									IL_0135:
									int num2;
									if (ynlmTUQPpJuFZbkrSeGgEJCqYgb >= MlpNgeZwoUSpEjmKNXpEnlXicyYH.Count)
									{
										num = -1281616359;
										num2 = num;
									}
									else
									{
										num = -1281616363;
										num2 = num;
									}
									continue;
									IL_00b3:
									int num3;
									if (eTCIucakieepoAfGYJcFtUXBMqWd.MoveNext())
									{
										num = -1281616355;
										num3 = num;
									}
									else
									{
										num = -1281616365;
										num3 = num;
									}
								}
								goto default;
								IL_018e:
								result = false;
								num = -1281616360;
								goto IL_001e;
								IL_0124:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -1281616353;
								goto IL_001e;
								IL_0113:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								num = -1281616362;
								goto IL_001e;
								end_IL_0008:
								break;
							}
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
						return result;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								KaihOYfVHxCPutELeYFjCuGyVUO();
							}
						}
					}

					[DebuggerHidden]
					public YYSnUrUCBMiUYAokSBKKCJifycPN(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void KaihOYfVHxCPutELeYFjCuGyVUO()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (eTCIucakieepoAfGYJcFtUXBMqWd == null)
						{
							return;
						}
						while (true)
						{
							int num = -716813614;
							while (true)
							{
								switch (num ^ -716813613)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									goto IL_002d;
								case 2:
									return;
								}
								break;
								IL_002d:
								eTCIucakieepoAfGYJcFtUXBMqWd.Dispose();
								num = -716813615;
							}
						}
					}
				}

				private sealed class AqGkhqjlpSyRLzKDMhqzMWlRkNZ : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public IList<Joystick> XmvqGHNhZXCFqdcHPnKhuYOQtjW;

					public int GhXwphEGDtCzsNTPQcgRYATPhTA;

					public ControllerPollingInfo UvalowWrhQfxRNuYOEmnTCCFqmf;

					public PollingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ControllerPollingInfo> vVzLCdOCplLbuFsiIknPilSBaFpB;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							goto IL_001c;
						}
						goto IL_004e;
						IL_004e:
						AqGkhqjlpSyRLzKDMhqzMWlRkNZ aqGkhqjlpSyRLzKDMhqzMWlRkNZ = new AqGkhqjlpSyRLzKDMhqzMWlRkNZ(0);
						aqGkhqjlpSyRLzKDMhqzMWlRkNZ.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						int num = -1069302586;
						goto IL_0021;
						IL_001c:
						num = -1069302588;
						goto IL_0021;
						IL_0021:
						while (true)
						{
							switch (num ^ -1069302587)
							{
							case 0:
								break;
							case 1:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
								aqGkhqjlpSyRLzKDMhqzMWlRkNZ = this;
								num = -1069302586;
								continue;
							case 2:
								goto IL_004e;
							default:
								return aqGkhqjlpSyRLzKDMhqzMWlRkNZ;
							}
							break;
						}
						goto IL_001c;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							default:
								num = 998173237;
								goto IL_001e;
							case 0:
								goto IL_0085;
							case 2:
								goto IL_00d4;
							case 1:
								break;
								IL_001e:
								while (true)
								{
									switch (num ^ 0x3B7EEA3D)
									{
									case 7:
										break;
									case 5:
										if (!vVzLCdOCplLbuFsiIknPilSBaFpB.MoveNext())
										{
											BVwhTozEIYlFRpcHDKBdkGltJZR();
											GhXwphEGDtCzsNTPQcgRYATPhTA++;
											num = 998173244;
											continue;
										}
										goto case 9;
									case 4:
										goto IL_0085;
									case 1:
										goto IL_00ad;
									case 10:
										goto IL_00d4;
									case 8:
										num = 998173245;
										continue;
									case 9:
										UvalowWrhQfxRNuYOEmnTCCFqmf = vVzLCdOCplLbuFsiIknPilSBaFpB.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = UvalowWrhQfxRNuYOEmnTCCFqmf;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										return true;
									case 2:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = 998173246;
										continue;
									case 6:
										vVzLCdOCplLbuFsiIknPilSBaFpB = XmvqGHNhZXCFqdcHPnKhuYOQtjW[GhXwphEGDtCzsNTPQcgRYATPhTA].PollForAllButtons().GetEnumerator();
										num = 998173247;
										continue;
									case 3:
										num = 998173240;
										continue;
									default:
										goto end_IL_0008;
									}
									break;
									IL_00ad:
									int num2;
									if (GhXwphEGDtCzsNTPQcgRYATPhTA >= XmvqGHNhZXCFqdcHPnKhuYOQtjW.Count)
									{
										num = 998173245;
										num2 = num;
									}
									else
									{
										num = 998173243;
										num2 = num;
									}
								}
								goto default;
								IL_00d4:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 998173240;
								goto IL_001e;
								IL_0085:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								XmvqGHNhZXCFqdcHPnKhuYOQtjW = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Joysticks_readOnly;
								GhXwphEGDtCzsNTPQcgRYATPhTA = 0;
								num = 998173244;
								goto IL_001e;
								end_IL_0008:
								break;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								BVwhTozEIYlFRpcHDKBdkGltJZR();
							}
						}
					}

					[DebuggerHidden]
					public AqGkhqjlpSyRLzKDMhqzMWlRkNZ(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void BVwhTozEIYlFRpcHDKBdkGltJZR()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (vVzLCdOCplLbuFsiIknPilSBaFpB != null)
						{
							vVzLCdOCplLbuFsiIknPilSBaFpB.Dispose();
						}
					}
				}

				private sealed class LSrBtnDoLyPRGqdYboePIrYhjtWm : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public IList<Joystick> SZfOGQQGwWtNOQdQogWUvGEzUqn;

					public int vaYawacAcFvvDKjJHTVZdjDEktfF;

					public ControllerPollingInfo WWAmSHWVnSKUUCCKVzNLgNIeauBb;

					public PollingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ControllerPollingInfo> ckqGnHGOoUkmcnIInnuaotLGCwx;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
						{
							goto IL_0012;
						}
						goto IL_0063;
						IL_0012:
						int num = -1533873078;
						goto IL_0017;
						IL_0017:
						LSrBtnDoLyPRGqdYboePIrYhjtWm lSrBtnDoLyPRGqdYboePIrYhjtWm = default(LSrBtnDoLyPRGqdYboePIrYhjtWm);
						while (true)
						{
							switch (num ^ -1533873074)
							{
							case 3:
								break;
							case 4:
								goto IL_0038;
							case 2:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
								lSrBtnDoLyPRGqdYboePIrYhjtWm = this;
								num = -1533873073;
								continue;
							case 0:
								goto IL_0063;
							default:
								return lSrBtnDoLyPRGqdYboePIrYhjtWm;
							}
							break;
							IL_0038:
							int num2;
							if (LzqgRXjFXvJPbHjfzyAmNfcqezXL != -2)
							{
								num = -1533873074;
								num2 = num;
							}
							else
							{
								num = -1533873076;
								num2 = num;
							}
						}
						goto IL_0012;
						IL_0063:
						lSrBtnDoLyPRGqdYboePIrYhjtWm = new LSrBtnDoLyPRGqdYboePIrYhjtWm(0);
						lSrBtnDoLyPRGqdYboePIrYhjtWm.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = -1533873073;
						goto IL_0017;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							default:
								num = -379666108;
								goto IL_001e;
							case 2:
								goto IL_0088;
							case 0:
								goto IL_00bd;
							case 1:
								break;
								IL_001e:
								while (true)
								{
									switch (num ^ -379666111)
									{
									case 8:
										break;
									case 5:
										num = -379666106;
										continue;
									case 2:
										ckqGnHGOoUkmcnIInnuaotLGCwx = SZfOGQQGwWtNOQdQogWUvGEzUqn[vaYawacAcFvvDKjJHTVZdjDEktfF].PollForAllButtonsDown().GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = -379666112;
										continue;
									case 6:
										goto IL_0088;
									case 3:
										goto IL_0096;
									case 0:
										goto IL_00bd;
									case 4:
										WWAmSHWVnSKUUCCKVzNLgNIeauBb = ckqGnHGOoUkmcnIInnuaotLGCwx.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = WWAmSHWVnSKUUCCKVzNLgNIeauBb;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										return true;
									case 1:
										if (!ckqGnHGOoUkmcnIInnuaotLGCwx.MoveNext())
										{
											mnPoIzeMHtRITqnvrdBltvExiMuJ();
											vaYawacAcFvvDKjJHTVZdjDEktfF++;
											num = -379666110;
											continue;
										}
										goto case 4;
									default:
										goto end_IL_0008;
									}
									break;
									IL_0096:
									int num2;
									if (vaYawacAcFvvDKjJHTVZdjDEktfF < SZfOGQQGwWtNOQdQogWUvGEzUqn.Count)
									{
										num = -379666109;
										num2 = num;
									}
									else
									{
										num = -379666106;
										num2 = num;
									}
								}
								goto default;
								IL_00bd:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								SZfOGQQGwWtNOQdQogWUvGEzUqn = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Joysticks_readOnly;
								vaYawacAcFvvDKjJHTVZdjDEktfF = 0;
								num = -379666110;
								goto IL_001e;
								IL_0088:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -379666112;
								goto IL_001e;
								end_IL_0008:
								break;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								mnPoIzeMHtRITqnvrdBltvExiMuJ();
							}
						}
					}

					[DebuggerHidden]
					public LSrBtnDoLyPRGqdYboePIrYhjtWm(int _003C_003E1__state)
					{
						while (true)
						{
							int num = -236060571;
							while (true)
							{
								switch (num ^ -236060572)
								{
								case 0:
									break;
								case 1:
									goto IL_0024;
								default:
									iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
									return;
								}
								break;
								IL_0024:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
								num = -236060570;
							}
						}
					}

					private void mnPoIzeMHtRITqnvrdBltvExiMuJ()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ckqGnHGOoUkmcnIInnuaotLGCwx != null)
						{
							ckqGnHGOoUkmcnIInnuaotLGCwx.Dispose();
						}
					}
				}

				private sealed class bgfcxoEjkuNoMPgpSVTNHBxaLYy : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public IList<Joystick> SeiheuVZeVDjeEQZtgjAWbAWUhx;

					public int lfTcTvGjZwbwGQNzaoVlIbLEhnBY;

					public ControllerPollingInfo fbwIYKsTcFQmFRcGEHTxcFEhXgJT;

					public PollingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ControllerPollingInfo> JpBVrTJfaENsgyMcgbNPgrnPCuJw;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						bgfcxoEjkuNoMPgpSVTNHBxaLYy bgfcxoEjkuNoMPgpSVTNHBxaLYy2;
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							bgfcxoEjkuNoMPgpSVTNHBxaLYy2 = this;
						}
						else
						{
							while (true)
							{
								bgfcxoEjkuNoMPgpSVTNHBxaLYy2 = new bgfcxoEjkuNoMPgpSVTNHBxaLYy(0);
								bgfcxoEjkuNoMPgpSVTNHBxaLYy2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
								int num = 1374982228;
								while (true)
								{
									switch (num ^ 0x51F49055)
									{
									case 0:
										num = 1374982231;
										continue;
									case 2:
										break;
									default:
										goto end_IL_0045;
									}
									break;
								}
								continue;
								end_IL_0045:
								break;
							}
						}
						return bgfcxoEjkuNoMPgpSVTNHBxaLYy2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 2:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -501030260;
								goto IL_0023;
							case 0:
								goto IL_0128;
								IL_0023:
								while (true)
								{
									switch (num ^ -501030261)
									{
									case 4:
										num = -501030263;
										continue;
									case 0:
										fbwIYKsTcFQmFRcGEHTxcFEhXgJT = JpBVrTJfaENsgyMcgbNPgrnPCuJw.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = fbwIYKsTcFQmFRcGEHTxcFEhXgJT;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										return true;
									case 6:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = -501030260;
										continue;
									case 8:
										JpBVrTJfaENsgyMcgbNPgrnPCuJw = SeiheuVZeVDjeEQZtgjAWbAWUhx[lfTcTvGjZwbwGQNzaoVlIbLEhnBY].PollForAllAxes().GetEnumerator();
										num = -501030259;
										continue;
									case 3:
										break;
									case 1:
										goto end_IL_0023;
									case 7:
										if (!JpBVrTJfaENsgyMcgbNPgrnPCuJw.MoveNext())
										{
											GsDnEclXLRDaszfgbXILNXkFkFD();
											lfTcTvGjZwbwGQNzaoVlIbLEhnBY++;
											num = -501030264;
											continue;
										}
										goto case 0;
									case 2:
										goto IL_0128;
									default:
										goto end_IL_0008;
									}
									int num2;
									if (lfTcTvGjZwbwGQNzaoVlIbLEhnBY >= SeiheuVZeVDjeEQZtgjAWbAWUhx.Count)
									{
										num = -501030258;
										num2 = num;
									}
									else
									{
										num = -501030269;
										num2 = num;
									}
									continue;
									end_IL_0023:
									break;
								}
								goto case 2;
								IL_0128:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								SeiheuVZeVDjeEQZtgjAWbAWUhx = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Joysticks_readOnly;
								lfTcTvGjZwbwGQNzaoVlIbLEhnBY = 0;
								num = -501030264;
								goto IL_0023;
								end_IL_0008:
								break;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								GsDnEclXLRDaszfgbXILNXkFkFD();
							}
						}
					}

					[DebuggerHidden]
					public bgfcxoEjkuNoMPgpSVTNHBxaLYy(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void GsDnEclXLRDaszfgbXILNXkFkFD()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (JpBVrTJfaENsgyMcgbNPgrnPCuJw != null)
						{
							JpBVrTJfaENsgyMcgbNPgrnPCuJw.Dispose();
						}
					}
				}

				private sealed class ibrncOSlkxVaKZrbAPOiRyujdgm : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public IList<CustomController> pAbcoDktPrWhWajbVBRgKwVOywjH;

					public int JSUNlzDGMWBbnLARabCTgNxphyg;

					public ControllerPollingInfo YOfAxOtpKLkTmtocWnmcyIaBtuI;

					public PollingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ControllerPollingInfo> aiPMoyCJWCFrxQmOIMSrPMoAiOR;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							goto IL_001c;
						}
						goto IL_004e;
						IL_004e:
						ibrncOSlkxVaKZrbAPOiRyujdgm ibrncOSlkxVaKZrbAPOiRyujdgm2 = new ibrncOSlkxVaKZrbAPOiRyujdgm(0);
						ibrncOSlkxVaKZrbAPOiRyujdgm2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						int num = -732779218;
						goto IL_0021;
						IL_001c:
						num = -732779220;
						goto IL_0021;
						IL_0021:
						while (true)
						{
							switch (num ^ -732779219)
							{
							case 0:
								break;
							case 1:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
								ibrncOSlkxVaKZrbAPOiRyujdgm2 = this;
								num = -732779218;
								continue;
							case 2:
								goto IL_004e;
							default:
								return ibrncOSlkxVaKZrbAPOiRyujdgm2;
							}
							break;
						}
						goto IL_001c;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						bool result = default(bool);
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							default:
								goto IL_0058;
							case 2:
								goto IL_00cf;
							case 0:
								goto IL_010b;
								IL_0058:
								result = false;
								num = 1684624452;
								goto IL_0020;
								IL_0020:
								while (true)
								{
									switch (num ^ 0x64695440)
									{
									case 0:
										num = 1684624454;
										continue;
									case 8:
										goto IL_0058;
									case 2:
										aiPMoyCJWCFrxQmOIMSrPMoAiOR = pAbcoDktPrWhWajbVBRgKwVOywjH[JSUNlzDGMWBbnLARabCTgNxphyg].PollForAllElements().GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = 1684624451;
										continue;
									case 5:
										YOfAxOtpKLkTmtocWnmcyIaBtuI = aiPMoyCJWCFrxQmOIMSrPMoAiOR.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = YOfAxOtpKLkTmtocWnmcyIaBtuI;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										result = true;
										num = 1684624457;
										continue;
									case 9:
										break;
									case 1:
										goto IL_00cf;
									case 3:
										if (!aiPMoyCJWCFrxQmOIMSrPMoAiOR.MoveNext())
										{
											gTvjXmcBumCxfGsqXnkPiAtkUAU();
											JSUNlzDGMWBbnLARabCTgNxphyg++;
											num = 1684624455;
											continue;
										}
										goto case 5;
									case 6:
										goto IL_010b;
									case 7:
										goto IL_0133;
									case 4:
										break;
									}
									break;
									IL_0133:
									int num2;
									if (JSUNlzDGMWBbnLARabCTgNxphyg >= pAbcoDktPrWhWajbVBRgKwVOywjH.Count)
									{
										num = 1684624456;
										num2 = num;
									}
									else
									{
										num = 1684624450;
										num2 = num;
									}
								}
								break;
								IL_010b:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								pAbcoDktPrWhWajbVBRgKwVOywjH = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.CustomControllers_readOnly;
								JSUNlzDGMWBbnLARabCTgNxphyg = 0;
								num = 1684624455;
								goto IL_0020;
								IL_00cf:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 1684624451;
								goto IL_0020;
							}
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
						return result;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								gTvjXmcBumCxfGsqXnkPiAtkUAU();
							}
						}
					}

					[DebuggerHidden]
					public ibrncOSlkxVaKZrbAPOiRyujdgm(int _003C_003E1__state)
					{
						while (true)
						{
							int num = -1722698667;
							while (true)
							{
								switch (num ^ -1722698668)
								{
								case 2:
									break;
								default:
									return;
								case 1:
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
									num = -1722698668;
									continue;
								case 0:
									iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
									num = -1722698665;
									continue;
								case 3:
									return;
								}
								break;
							}
						}
					}

					private void gTvjXmcBumCxfGsqXnkPiAtkUAU()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (aiPMoyCJWCFrxQmOIMSrPMoAiOR != null)
						{
							aiPMoyCJWCFrxQmOIMSrPMoAiOR.Dispose();
						}
					}
				}

				private sealed class zNgBjOjLoHAUYkGELURmoDVwqVKZ : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public IList<CustomController> yVgYZlfdHJhAyJGzXkrbEdwEnhI;

					public int gKuonQpmcJtlAtfNizZPYukUTuw;

					public ControllerPollingInfo UoBJtvcawrHVJoikHIimTzbqDZe;

					public PollingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ControllerPollingInfo> kUDYfgplRSmYEzhPchPNeIZFDFoF;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							goto IL_001c;
						}
						goto IL_0065;
						IL_0065:
						zNgBjOjLoHAUYkGELURmoDVwqVKZ zNgBjOjLoHAUYkGELURmoDVwqVKZ2 = new zNgBjOjLoHAUYkGELURmoDVwqVKZ(0);
						int num = 141880024;
						goto IL_0021;
						IL_001c:
						num = 141880031;
						goto IL_0021;
						IL_0021:
						while (true)
						{
							switch (num ^ 0x874EADC)
							{
							case 0:
								break;
							case 3:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
								zNgBjOjLoHAUYkGELURmoDVwqVKZ2 = this;
								num = 141880030;
								continue;
							case 4:
								zNgBjOjLoHAUYkGELURmoDVwqVKZ2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
								num = 141880030;
								continue;
							case 1:
								goto IL_0065;
							default:
								return zNgBjOjLoHAUYkGELURmoDVwqVKZ2;
							}
							break;
						}
						goto IL_001c;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						bool result = default(bool);
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 2:
								goto IL_00a8;
							case 0:
								goto IL_00e0;
							default:
								goto IL_0108;
								IL_00a8:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -916602512;
								goto IL_0023;
								IL_0023:
								while (true)
								{
									switch (num ^ -916602507)
									{
									case 9:
										num = -916602511;
										continue;
									case 7:
										RDkWcsTpvDaNZojjIZONnoEBXPC = UoBJtvcawrHVJoikHIimTzbqDZe;
										num = -916602509;
										continue;
									case 11:
										kUDYfgplRSmYEzhPchPNeIZFDFoF = yVgYZlfdHJhAyJGzXkrbEdwEnhI[gKuonQpmcJtlAtfNizZPYukUTuw].PollForAllElementsDown().GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = -916602512;
										continue;
									case 2:
										goto IL_00a8;
									case 0:
										goto IL_00b9;
									case 4:
										goto IL_00e0;
									case 8:
										goto IL_0108;
									case 1:
										UoBJtvcawrHVJoikHIimTzbqDZe = kUDYfgplRSmYEzhPchPNeIZFDFoF.Current;
										num = -916602510;
										continue;
									case 6:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										num = -916602497;
										continue;
									case 10:
										result = true;
										break;
									case 5:
										if (!kUDYfgplRSmYEzhPchPNeIZFDFoF.MoveNext())
										{
											gPZTtFdfcZrhsPawrCiOsSluaYJ();
											gKuonQpmcJtlAtfNizZPYukUTuw++;
											num = -916602507;
											continue;
										}
										goto case 1;
									case 3:
										break;
									}
									break;
									IL_00b9:
									int num2;
									if (gKuonQpmcJtlAtfNizZPYukUTuw >= yVgYZlfdHJhAyJGzXkrbEdwEnhI.Count)
									{
										num = -916602499;
										num2 = num;
									}
									else
									{
										num = -916602498;
										num2 = num;
									}
								}
								break;
								IL_0108:
								result = false;
								num = -916602506;
								goto IL_0023;
								IL_00e0:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								yVgYZlfdHJhAyJGzXkrbEdwEnhI = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.CustomControllers_readOnly;
								gKuonQpmcJtlAtfNizZPYukUTuw = 0;
								num = -916602507;
								goto IL_0023;
							}
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
						return result;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								gPZTtFdfcZrhsPawrCiOsSluaYJ();
							}
						}
					}

					[DebuggerHidden]
					public zNgBjOjLoHAUYkGELURmoDVwqVKZ(int _003C_003E1__state)
					{
						while (true)
						{
							int num = 606408781;
							while (true)
							{
								switch (num ^ 0x2425104C)
								{
								case 2:
									break;
								default:
									return;
								case 1:
									goto IL_0024;
								case 0:
									return;
								}
								break;
								IL_0024:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
								iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
								num = 606408780;
							}
						}
					}

					private void gPZTtFdfcZrhsPawrCiOsSluaYJ()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						while (true)
						{
							int num = 1829133046;
							while (true)
							{
								switch (num ^ 0x6D065AF4)
								{
								case 0:
									break;
								default:
									return;
								case 2:
									if (kUDYfgplRSmYEzhPchPNeIZFDFoF != null)
									{
										goto IL_002d;
									}
									return;
								case 1:
									return;
								}
								break;
								IL_002d:
								kUDYfgplRSmYEzhPchPNeIZFDFoF.Dispose();
								num = 1829133045;
							}
						}
					}
				}

				private sealed class IJPItqdtmvWTLTUXJSdKipJpYxI : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public IList<CustomController> appHVKabQUyZgQSxWQnMFvnnndP;

					public int OMPkKBOVcjxQJLOspeNDqSlLTYa;

					public ControllerPollingInfo dwrTjPFQHeSconHzYFUzMiSIKwU;

					public PollingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ControllerPollingInfo> gNmMmonukxEzGzHCZJiPLKbnTxf;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						IJPItqdtmvWTLTUXJSdKipJpYxI iJPItqdtmvWTLTUXJSdKipJpYxI;
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							iJPItqdtmvWTLTUXJSdKipJpYxI = this;
							goto IL_0025;
						}
						goto IL_004e;
						IL_002a:
						int num;
						while (true)
						{
							switch (num ^ 0x50A65438)
							{
							case 2:
								break;
							case 3:
								num = 1353077817;
								continue;
							case 0:
								goto IL_004e;
							default:
								return iJPItqdtmvWTLTUXJSdKipJpYxI;
							}
							break;
						}
						goto IL_0025;
						IL_004e:
						iJPItqdtmvWTLTUXJSdKipJpYxI = new IJPItqdtmvWTLTUXJSdKipJpYxI(0);
						iJPItqdtmvWTLTUXJSdKipJpYxI.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = 1353077817;
						goto IL_002a;
						IL_0025:
						num = 1353077819;
						goto IL_002a;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						bool result = default(bool);
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 2:
								goto IL_0060;
							default:
								goto IL_006e;
							case 0:
								goto IL_00c4;
								IL_0060:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 818553223;
								goto IL_0020;
								IL_0020:
								while (true)
								{
									switch (num ^ 0x30CA2187)
									{
									case 7:
										num = 818553218;
										continue;
									case 4:
										goto IL_0060;
									case 3:
										goto IL_006e;
									case 6:
										OMPkKBOVcjxQJLOspeNDqSlLTYa++;
										num = 818553221;
										continue;
									case 0:
										if (!gNmMmonukxEzGzHCZJiPLKbnTxf.MoveNext())
										{
											JhYAfXvqONtJNBeQHfvSZflHPcI();
											num = 818553217;
											continue;
										}
										goto case 10;
									case 10:
										dwrTjPFQHeSconHzYFUzMiSIKwU = gNmMmonukxEzGzHCZJiPLKbnTxf.Current;
										num = 818553230;
										continue;
									case 5:
										goto IL_00c4;
									case 2:
										goto IL_00ec;
									case 1:
										result = true;
										break;
									case 9:
										RDkWcsTpvDaNZojjIZONnoEBXPC = dwrTjPFQHeSconHzYFUzMiSIKwU;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										num = 818553222;
										continue;
									case 8:
										gNmMmonukxEzGzHCZJiPLKbnTxf = appHVKabQUyZgQSxWQnMFvnnndP[OMPkKBOVcjxQJLOspeNDqSlLTYa].PollForAllButtons().GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = 818553223;
										continue;
									case 11:
										break;
									}
									break;
									IL_00ec:
									int num2;
									if (OMPkKBOVcjxQJLOspeNDqSlLTYa < appHVKabQUyZgQSxWQnMFvnnndP.Count)
									{
										num = 818553231;
										num2 = num;
									}
									else
									{
										num = 818553220;
										num2 = num;
									}
								}
								break;
								IL_00c4:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								appHVKabQUyZgQSxWQnMFvnnndP = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.CustomControllers_readOnly;
								OMPkKBOVcjxQJLOspeNDqSlLTYa = 0;
								num = 818553221;
								goto IL_0020;
								IL_006e:
								result = false;
								num = 818553228;
								goto IL_0020;
							}
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
						return result;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								JhYAfXvqONtJNBeQHfvSZflHPcI();
							}
						}
					}

					[DebuggerHidden]
					public IJPItqdtmvWTLTUXJSdKipJpYxI(int _003C_003E1__state)
					{
						while (true)
						{
							int num = -1440516394;
							while (true)
							{
								switch (num ^ -1440516393)
								{
								case 2:
									break;
								default:
									return;
								case 1:
									goto IL_0024;
								case 0:
									return;
								}
								break;
								IL_0024:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
								iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
								num = -1440516393;
							}
						}
					}

					private void JhYAfXvqONtJNBeQHfvSZflHPcI()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (gNmMmonukxEzGzHCZJiPLKbnTxf != null)
						{
							gNmMmonukxEzGzHCZJiPLKbnTxf.Dispose();
						}
					}
				}

				private sealed class KntjOaLdadcNRbwsGXshDCeGSbe : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public IList<CustomController> IKchJdSmUAzXREVaeBViIFlysiZ;

					public int HBrFMtawHviThWzMCQDZKCDjnmS;

					public ControllerPollingInfo zuBLNSbhICAWrJFCnqznWjFhWwZ;

					public PollingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ControllerPollingInfo> RBWbJwBnhJwrBGZsZQFdGRbojwe;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						KntjOaLdadcNRbwsGXshDCeGSbe kntjOaLdadcNRbwsGXshDCeGSbe;
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							kntjOaLdadcNRbwsGXshDCeGSbe = this;
						}
						else
						{
							while (true)
							{
								kntjOaLdadcNRbwsGXshDCeGSbe = new KntjOaLdadcNRbwsGXshDCeGSbe(0);
								kntjOaLdadcNRbwsGXshDCeGSbe.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
								int num = -268553460;
								while (true)
								{
									switch (num ^ -268553459)
									{
									case 0:
										num = -268553457;
										continue;
									case 2:
										break;
									default:
										goto end_IL_0045;
									}
									break;
								}
								continue;
								end_IL_0045:
								break;
							}
						}
						return kntjOaLdadcNRbwsGXshDCeGSbe;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 2:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 107079930;
								goto IL_0023;
							case 0:
								goto IL_0170;
								IL_0023:
								while (true)
								{
									switch (num ^ 0x661E8FC)
									{
									case 9:
										num = 107079931;
										continue;
									case 2:
										num = 107079935;
										continue;
									case 1:
										tkAnCJFKnJBGRxkvSrRglKfvlbn();
										num = 107079927;
										continue;
									case 4:
										zuBLNSbhICAWrJFCnqznWjFhWwZ = RBWbJwBnhJwrBGZsZQFdGRbojwe.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = zuBLNSbhICAWrJFCnqznWjFhWwZ;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										return true;
									case 3:
										break;
									case 0:
										RBWbJwBnhJwrBGZsZQFdGRbojwe = IKchJdSmUAzXREVaeBViIFlysiZ[HBrFMtawHviThWzMCQDZKCDjnmS].PollForAllButtonsDown().GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = 107079930;
										continue;
									case 6:
										goto IL_0105;
									case 8:
										goto end_IL_0023;
									case 11:
										HBrFMtawHviThWzMCQDZKCDjnmS++;
										num = 107079935;
										continue;
									case 5:
										IKchJdSmUAzXREVaeBViIFlysiZ = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.CustomControllers_readOnly;
										HBrFMtawHviThWzMCQDZKCDjnmS = 0;
										num = 107079934;
										continue;
									case 7:
										goto IL_0170;
									default:
										goto end_IL_0008;
									}
									int num2;
									if (HBrFMtawHviThWzMCQDZKCDjnmS >= IKchJdSmUAzXREVaeBViIFlysiZ.Count)
									{
										num = 107079926;
										num2 = num;
									}
									else
									{
										num = 107079932;
										num2 = num;
									}
									continue;
									IL_0105:
									int num3;
									if (RBWbJwBnhJwrBGZsZQFdGRbojwe.MoveNext())
									{
										num = 107079928;
										num3 = num;
									}
									else
									{
										num = 107079933;
										num3 = num;
									}
									continue;
									end_IL_0023:
									break;
								}
								goto case 2;
								IL_0170:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								num = 107079929;
								goto IL_0023;
								end_IL_0008:
								break;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								tkAnCJFKnJBGRxkvSrRglKfvlbn();
							}
						}
					}

					[DebuggerHidden]
					public KntjOaLdadcNRbwsGXshDCeGSbe(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void tkAnCJFKnJBGRxkvSrRglKfvlbn()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						while (true)
						{
							int num = -147702745;
							while (true)
							{
								switch (num ^ -147702746)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									if (RBWbJwBnhJwrBGZsZQFdGRbojwe != null)
									{
										goto IL_002d;
									}
									return;
								case 2:
									return;
								}
								break;
								IL_002d:
								RBWbJwBnhJwrBGZsZQFdGRbojwe.Dispose();
								num = -147702748;
							}
						}
					}
				}

				private sealed class uHyWFrHZFAQmuHGoshcPeoBcnUj : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public IList<CustomController> VngrcdpsAIHWALmBXzfbDEWXHgz;

					public int GQWPRQHfadbIAVuhwjVKHExtCPTa;

					public ControllerPollingInfo SzicEmDYgOMKPLUSZuKIOkcwCMaj;

					public PollingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ControllerPollingInfo> eKGKQuFDXDzyHUzJPRPeIzTwXaf;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						uHyWFrHZFAQmuHGoshcPeoBcnUj uHyWFrHZFAQmuHGoshcPeoBcnUj2;
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							uHyWFrHZFAQmuHGoshcPeoBcnUj2 = this;
						}
						else
						{
							while (true)
							{
								uHyWFrHZFAQmuHGoshcPeoBcnUj2 = new uHyWFrHZFAQmuHGoshcPeoBcnUj(0);
								uHyWFrHZFAQmuHGoshcPeoBcnUj2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
								int num = 920022818;
								while (true)
								{
									switch (num ^ 0x36D66F22)
									{
									case 2:
										num = 920022819;
										continue;
									case 1:
										break;
									default:
										goto end_IL_0045;
									}
									break;
								}
								continue;
								end_IL_0045:
								break;
							}
						}
						return uHyWFrHZFAQmuHGoshcPeoBcnUj2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						bool result = default(bool);
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							default:
								num = 351855228;
								goto IL_001e;
							case 0:
								goto IL_00ae;
							case 2:
								goto IL_0139;
							case 1:
								goto IL_014a;
								IL_001e:
								while (true)
								{
									switch (num ^ 0x14F8E27A)
									{
									case 9:
										break;
									default:
										goto end_IL_0008;
									case 8:
										noBEMQYvZOmyzeWHZfWNvlYygXD();
										GQWPRQHfadbIAVuhwjVKHExtCPTa++;
										num = 351855217;
										continue;
									case 5:
										SzicEmDYgOMKPLUSZuKIOkcwCMaj = eKGKQuFDXDzyHUzJPRPeIzTwXaf.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = SzicEmDYgOMKPLUSZuKIOkcwCMaj;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										result = true;
										goto end_IL_0008;
									case 2:
										goto IL_00ae;
									case 3:
										num = 351855217;
										continue;
									case 1:
										eKGKQuFDXDzyHUzJPRPeIzTwXaf = VngrcdpsAIHWALmBXzfbDEWXHgz[GQWPRQHfadbIAVuhwjVKHExtCPTa].PollForAllAxes().GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = 351855230;
										continue;
									case 11:
										goto IL_0112;
									case 10:
										goto IL_0139;
									case 7:
										goto IL_014a;
									case 4:
										goto IL_0156;
									case 6:
										num = 351855229;
										continue;
									case 0:
										goto end_IL_0008;
									}
									break;
									IL_0156:
									int num2;
									if (!eKGKQuFDXDzyHUzJPRPeIzTwXaf.MoveNext())
									{
										num = 351855218;
										num2 = num;
									}
									else
									{
										num = 351855231;
										num2 = num;
									}
									continue;
									IL_0112:
									int num3;
									if (GQWPRQHfadbIAVuhwjVKHExtCPTa >= VngrcdpsAIHWALmBXzfbDEWXHgz.Count)
									{
										num = 351855229;
										num3 = num;
									}
									else
									{
										num = 351855227;
										num3 = num;
									}
								}
								goto default;
								IL_014a:
								result = false;
								num = 351855226;
								goto IL_001e;
								IL_0139:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 351855230;
								goto IL_001e;
								IL_00ae:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								VngrcdpsAIHWALmBXzfbDEWXHgz = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.CustomControllers_readOnly;
								GQWPRQHfadbIAVuhwjVKHExtCPTa = 0;
								num = 351855225;
								goto IL_001e;
								end_IL_0008:
								break;
							}
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
						return result;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								noBEMQYvZOmyzeWHZfWNvlYygXD();
							}
						}
					}

					[DebuggerHidden]
					public uHyWFrHZFAQmuHGoshcPeoBcnUj(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void noBEMQYvZOmyzeWHZfWNvlYygXD()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (eKGKQuFDXDzyHUzJPRPeIzTwXaf != null)
						{
							eKGKQuFDXDzyHUzJPRPeIzTwXaf.Dispose();
						}
					}
				}

				private static PollingHelper VLHBdfuObcdunicAbIHFTExpsoBB;

				internal static PollingHelper Instance
				{
					get
					{
						return VLHBdfuObcdunicAbIHFTExpsoBB ?? (VLHBdfuObcdunicAbIHFTExpsoBB = new PollingHelper());
					}
				}

				private PollingHelper()
				{
				}

				public ControllerPollingInfo PollAllControllersForFirstElement()
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					ControllerPollingInfo result = KkXyUfaNxvPGrSTFTEBvUJCfEdq();
					if (result.success)
					{
						return result;
					}
					result = kVfkalzgRMRGOreRPrdCIcqTNne();
					if (result.success)
					{
						return result;
					}
					result = SdGCNjbvhDCBOeEgDtrzcpfvFEa();
					int num = -739023597;
					goto IL_000c;
					IL_000c:
					while (true)
					{
						switch (num ^ -739023597)
						{
						case 3:
							break;
						case 1:
							return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
						case 0:
							if (result.success)
							{
								return result;
							}
							result = VgQGWlDOjGHmzCMfkFNnRosvCBnm();
							if (result.success)
							{
								goto IL_007c;
							}
							return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
						default:
							return result;
						}
						break;
						IL_007c:
						num = -739023599;
					}
					goto IL_0007;
					IL_0007:
					num = -739023598;
					goto IL_000c;
				}

				public ControllerPollingInfo PollAllControllersForFirstElementDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					ControllerPollingInfo result = YILeFMeqoXQviZbFJjCoenIVZXb();
					if (result.success)
					{
						return result;
					}
					result = FUHTmNZZlLGUkEmrYTEztgzsXQO();
					while (true)
					{
						int num = -60679858;
						while (true)
						{
							switch (num ^ -60679857)
							{
							case 0:
								break;
							case 1:
								if (result.success)
								{
									return result;
								}
								result = NPHoBbcKDNpvRvFzFKCJoyskIVh();
								if (result.success)
								{
									goto IL_005f;
								}
								result = gDdQpBGKNWhVQDpwXKKpdLXJCxdN();
								if (result.success)
								{
									return result;
								}
								return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
							default:
								return result;
							}
							break;
							IL_005f:
							num = -60679859;
						}
					}
				}

				public ControllerPollingInfo PollAllControllersForFirstButton()
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					ControllerPollingInfo result = abyGORrOhyhcxhxKFkOtRfpDIxn();
					int num;
					if (result.success)
					{
						num = 1677873792;
						goto IL_000c;
					}
					result = kVfkalzgRMRGOreRPrdCIcqTNne();
					if (result.success)
					{
						return result;
					}
					result = NMbGCUQXOhZbVFNqQGBWRoCLInQH();
					if (result.success)
					{
						return result;
					}
					result = EKkezDBOTOzSxPZrlJfSfJnVEOO();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					IL_0007:
					num = 1677873795;
					goto IL_000c;
					IL_000c:
					switch (num ^ 0x64025282)
					{
					case 0:
						break;
					case 1:
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					default:
						return result;
					}
					goto IL_0007;
				}

				public ControllerPollingInfo PollAllControllersForFirstButtonDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					ControllerPollingInfo result = gHlObotxEJvkhHPMsfmSqqhgRkb();
					if (result.success)
					{
						return result;
					}
					result = FUHTmNZZlLGUkEmrYTEztgzsXQO();
					if (result.success)
					{
						return result;
					}
					result = zulpyjzAMwJJVkRlChfYstTzSfB();
					while (true)
					{
						int num = -1095479131;
						while (true)
						{
							switch (num ^ -1095479132)
							{
							case 2:
								break;
							case 1:
								if (!result.success)
								{
									goto IL_0061;
								}
								return result;
							default:
								if (result.success)
								{
									return result;
								}
								return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
							}
							break;
							IL_0061:
							result = kGcZTpFjGVWkXkAeDrOTovCHlmy();
							num = -1095479132;
						}
					}
				}

				public ControllerPollingInfo PollAllControllersForFirstAxis()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					ControllerPollingInfo result = fZKGpDcMiOmLXrjZyQzXJWWzlckK();
					if (result.success)
					{
						return result;
					}
					result = ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					if (result.success)
					{
						return result;
					}
					result = ZbDqgNQEJctkzCHtydaUBAcSGqhn();
					while (true)
					{
						int num = 1914617940;
						while (true)
						{
							switch (num ^ 0x721EC056)
							{
							case 0:
								break;
							case 2:
								if (result.success)
								{
									goto IL_005e;
								}
								result = NJyhAtWDUKzASBdNxLdmuXGePsd();
								if (result.success)
								{
									return result;
								}
								return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
							default:
								return result;
							}
							break;
							IL_005e:
							num = 1914617943;
						}
					}
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					while (true)
					{
						switch (0x4400A6A5 ^ 0x4400A6A7)
						{
						case 0:
							continue;
						case 2:
							switch (controllerType)
							{
							case ControllerType.Joystick:
								break;
							case ControllerType.Keyboard:
								return kVfkalzgRMRGOreRPrdCIcqTNne();
							case ControllerType.Mouse:
								return SdGCNjbvhDCBOeEgDtrzcpfvFEa();
							case ControllerType.Custom:
								return VgQGWlDOjGHmzCMfkFNnRosvCBnm();
							default:
								throw new NotImplementedException();
							}
							break;
						}
						break;
					}
					return KkXyUfaNxvPGrSTFTEBvUJCfEdq();
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					ControllerType controllerType2 = controllerType;
					int num = -2075320379;
					goto IL_000c;
					IL_000c:
					while (true)
					{
						switch (num ^ -2075320380)
						{
						case 0:
							break;
						case 1:
							switch (controllerType2)
							{
							default:
								goto IL_004d;
							case ControllerType.Joystick:
								break;
							case ControllerType.Keyboard:
								return FUHTmNZZlLGUkEmrYTEztgzsXQO();
							case ControllerType.Mouse:
								return NPHoBbcKDNpvRvFzFKCJoyskIVh();
							case ControllerType.Custom:
								return gDdQpBGKNWhVQDpwXKKpdLXJCxdN();
							}
							goto default;
						case 2:
							return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
						default:
							return YILeFMeqoXQviZbFJjCoenIVZXb();
						case 3:
							throw new NotImplementedException();
						}
						break;
						IL_004d:
						num = -2075320377;
					}
					goto IL_0007;
					IL_0007:
					num = -2075320378;
					goto IL_000c;
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					switch (controllerType)
					{
					default:
						while (true)
						{
							switch (0x2F3D7D3F ^ 0x2F3D7D3D)
							{
							case 0:
								continue;
							case 2:
								if (controllerType == ControllerType.Custom)
								{
									return EKkezDBOTOzSxPZrlJfSfJnVEOO();
								}
								throw new NotImplementedException();
							}
							break;
						}
						goto case ControllerType.Joystick;
					case ControllerType.Joystick:
						return abyGORrOhyhcxhxKFkOtRfpDIxn();
					case ControllerType.Keyboard:
						return kVfkalzgRMRGOreRPrdCIcqTNne();
					case ControllerType.Mouse:
						return NMbGCUQXOhZbVFNqQGBWRoCLInQH();
					}
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						while (true)
						{
							switch (-2058426519 ^ -2058426520)
							{
							case 2:
								continue;
							case 1:
								return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
							}
							break;
						}
					}
					else
					{
						switch (controllerType)
						{
						case ControllerType.Joystick:
							break;
						case ControllerType.Keyboard:
							return FUHTmNZZlLGUkEmrYTEztgzsXQO();
						case ControllerType.Mouse:
							return zulpyjzAMwJJVkRlChfYstTzSfB();
						case ControllerType.Custom:
							return kGcZTpFjGVWkXkAeDrOTovCHlmy();
						default:
							throw new NotImplementedException();
						}
					}
					return gHlObotxEJvkhHPMsfmSqqhgRkb();
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					switch (controllerType)
					{
					default:
						while (true)
						{
							switch (-581064717 ^ -581064718)
							{
							case 0:
								continue;
							case 1:
								throw new NotImplementedException();
							}
							break;
						}
						goto case ControllerType.Joystick;
					case ControllerType.Joystick:
						return fZKGpDcMiOmLXrjZyQzXJWWzlckK();
					case ControllerType.Keyboard:
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					case ControllerType.Mouse:
						return ZbDqgNQEJctkzCHtydaUBAcSGqhn();
					case ControllerType.Custom:
						return NJyhAtWDUKzASBdNxLdmuXGePsd();
					}
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					ControllerType controllerType2 = controllerType;
					switch (controllerType2)
					{
					case ControllerType.Joystick:
						goto IL_0058;
					case ControllerType.Keyboard:
						return kVfkalzgRMRGOreRPrdCIcqTNne();
					case ControllerType.Mouse:
						return SdGCNjbvhDCBOeEgDtrzcpfvFEa();
					}
					int num = 1629342709;
					goto IL_000c;
					IL_0007:
					num = 1629342708;
					goto IL_000c;
					IL_004a:
					if (controllerType2 == ControllerType.Custom)
					{
						return DVPDckGKOzaLVSheictrDOlLtyV(controllerId);
					}
					throw new NotImplementedException();
					IL_0058:
					return QTHHhtZvMOTHCNogqoiYPMSNTIJ(controllerId);
					IL_000c:
					switch (num ^ 0x611DCBF5)
					{
					case 2:
						break;
					case 1:
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					case 0:
						goto IL_004a;
					default:
						goto IL_0058;
					}
					goto IL_0007;
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					while (true)
					{
						switch (-529806142 ^ -529806141)
						{
						case 2:
							continue;
						case 1:
							switch (controllerType)
							{
							case ControllerType.Joystick:
								break;
							case ControllerType.Keyboard:
								return FUHTmNZZlLGUkEmrYTEztgzsXQO();
							case ControllerType.Mouse:
								return NPHoBbcKDNpvRvFzFKCJoyskIVh();
							case ControllerType.Custom:
								return vEpHGvYirAiZguBlfFoJAlaqhPAL(controllerId);
							default:
								throw new NotImplementedException();
							}
							break;
						}
						break;
					}
					return GDtaQxELDAQZnkpYDEDZdvgChmaH(controllerId);
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					while (true)
					{
						int num = -628285777;
						while (true)
						{
							switch (num ^ -628285778)
							{
							case 0:
								break;
							case 1:
								switch (controllerType)
								{
								default:
									goto IL_0048;
								case ControllerType.Joystick:
									break;
								case ControllerType.Keyboard:
									return kVfkalzgRMRGOreRPrdCIcqTNne();
								case ControllerType.Mouse:
									return NMbGCUQXOhZbVFNqQGBWRoCLInQH();
								case ControllerType.Custom:
									return oEGDibdwMeHUBUyGQsUXVDBioRh(controllerId);
								}
								goto default;
							default:
								return uDcyrqRjyjYUZBQAMkSrkeQFzXG(controllerId);
							case 2:
								throw new NotImplementedException();
							}
							break;
							IL_0048:
							num = -628285780;
						}
					}
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					ControllerType controllerType2 = controllerType;
					int num = 637133474;
					goto IL_000c;
					IL_000c:
					while (true)
					{
						switch (num ^ 0x25F9E2A0)
						{
						case 4:
							break;
						case 1:
							return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
						case 2:
							switch (controllerType2)
							{
							default:
								goto IL_004e;
							case ControllerType.Joystick:
								break;
							case ControllerType.Keyboard:
								return FUHTmNZZlLGUkEmrYTEztgzsXQO();
							case ControllerType.Mouse:
								return zulpyjzAMwJJVkRlChfYstTzSfB();
							}
							goto default;
						case 0:
							if (controllerType2 == ControllerType.Custom)
							{
								return hvNJEuIAWzxPdnGllQLLbTsPuu(controllerId);
							}
							throw new NotImplementedException();
						default:
							return wOyNHqHCRDRHpzGOOECkUJgpywr(controllerId);
						}
						break;
						IL_004e:
						num = 637133472;
					}
					goto IL_0007;
					IL_0007:
					num = 637133473;
					goto IL_000c;
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return NxDJdcvCXfLvBkJukaYmNkijRCl(controllerId);
					case ControllerType.Keyboard:
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					case ControllerType.Mouse:
						return ZbDqgNQEJctkzCHtydaUBAcSGqhn();
					case ControllerType.Custom:
						return JsPmhhReveucQUJsEfaMOLoZgsb(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					vNkJjxcOVBBHLfqWxePnYLYgNkR vNkJjxcOVBBHLfqWxePnYLYgNkR2 = new vNkJjxcOVBBHLfqWxePnYLYgNkR(-2);
					vNkJjxcOVBBHLfqWxePnYLYgNkR2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return vNkJjxcOVBBHLfqWxePnYLYgNkR2;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					XxVeInCnEkNzScvpiXuwOcUBBVt xxVeInCnEkNzScvpiXuwOcUBBVt = new XxVeInCnEkNzScvpiXuwOcUBBVt(-2);
					xxVeInCnEkNzScvpiXuwOcUBBVt.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return xxVeInCnEkNzScvpiXuwOcUBBVt;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					ErBAKsEakGoRJtOxBiIlvzLQdQAb erBAKsEakGoRJtOxBiIlvzLQdQAb = new ErBAKsEakGoRJtOxBiIlvzLQdQAb(-2);
					erBAKsEakGoRJtOxBiIlvzLQdQAb.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return erBAKsEakGoRJtOxBiIlvzLQdQAb;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					XahRduYcitFKDxCPECwdFFFCnTeu xahRduYcitFKDxCPECwdFFFCnTeu = new XahRduYcitFKDxCPECwdFFFCnTeu(-2);
					xahRduYcitFKDxCPECwdFFFCnTeu.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return xahRduYcitFKDxCPECwdFFFCnTeu;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
				{
					wSDexTAZCWmzKmqzewllUGzMPVpr wSDexTAZCWmzKmqzewllUGzMPVpr2 = new wSDexTAZCWmzKmqzewllUGzMPVpr(-2);
					wSDexTAZCWmzKmqzewllUGzMPVpr2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return wSDexTAZCWmzKmqzewllUGzMPVpr2;
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						while (true)
						{
							switch (-233594534 ^ -233594533)
							{
							case 2:
								continue;
							case 1:
								return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
							}
							break;
						}
					}
					else
					{
						switch (controllerType)
						{
						case ControllerType.Joystick:
							break;
						case ControllerType.Keyboard:
							return XzuyRyAOJjyALLhPWbokPtkFsjX();
						case ControllerType.Mouse:
							return uVtPvBSPOVSVrmwtatDmhmggEGMF();
						case ControllerType.Custom:
							return ZlzgZLotdICeurwylMbbGRjSONf(controllerId);
						default:
							throw new NotImplementedException();
						}
					}
					return cjzIFxLQWnubptTYBRdPnOkZQjP(controllerId);
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return gPsSdhQsSKOSRdxkRZJiEboVpzr(controllerId);
					case ControllerType.Keyboard:
						return xYkfoZREkimMSyaRebVQAcNFERCb();
					case ControllerType.Mouse:
						return gdrcxxklAWXerFCQbSVzkXEdgxU();
					case ControllerType.Custom:
						return qbXVScLmmBOAzZSCgTvLZBCoiIJD(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					ControllerType controllerType2 = controllerType;
					switch (controllerType2)
					{
					case ControllerType.Joystick:
						goto IL_0058;
					case ControllerType.Keyboard:
						return XzuyRyAOJjyALLhPWbokPtkFsjX();
					case ControllerType.Mouse:
						return DeTCsDGLpHqPnFfUIAtMoelubGtE();
					}
					int num = 1937049838;
					goto IL_000c;
					IL_0007:
					num = 1937049837;
					goto IL_000c;
					IL_004a:
					if (controllerType2 == ControllerType.Custom)
					{
						return pXeYtLpKQogvUGcPYHnffUXpoyK(controllerId);
					}
					throw new NotImplementedException();
					IL_0058:
					return AJQTiIlENPYVzLpJAHuMEQqxGeHL(controllerId);
					IL_000c:
					switch (num ^ 0x737508EF)
					{
					case 0:
						break;
					case 2:
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					case 1:
						goto IL_004a;
					default:
						goto IL_0058;
					}
					goto IL_0007;
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return lyiTBiFFfcuKqEuwxBacPThkvJP(controllerId);
					case ControllerType.Keyboard:
						return xYkfoZREkimMSyaRebVQAcNFERCb();
					case ControllerType.Mouse:
						return lmSnIdpGCHOCWsoOFiSqZxXYdcQI();
					case ControllerType.Custom:
						return xrohFXFhMxujxbiBBORMDNVmaYp(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					ControllerType controllerType2 = controllerType;
					switch (controllerType2)
					{
					case ControllerType.Joystick:
						goto IL_0058;
					case ControllerType.Keyboard:
						return new List<ControllerPollingInfo>();
					case ControllerType.Mouse:
						return bLVygRZbxibgWFbIdFaUPVtRMuny();
					}
					int num = 342997880;
					goto IL_000c;
					IL_0007:
					num = 342997881;
					goto IL_000c;
					IL_004a:
					if (controllerType2 == ControllerType.Custom)
					{
						return qELQYvbXHgTeNPPytbuAYYFkqTO(controllerId);
					}
					throw new NotImplementedException();
					IL_0058:
					return rfduapsLWPXYrBjLuVBEztKxhdG(controllerId);
					IL_000c:
					switch (num ^ 0x1471BB7B)
					{
					case 0:
						break;
					case 2:
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					case 3:
						goto IL_004a;
					default:
						goto IL_0058;
					}
					goto IL_0007;
				}

				private ControllerPollingInfo KkXyUfaNxvPGrSTFTEBvUJCfEdq()
				{
					IList<Joystick> joysticks_readOnly = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Joysticks_readOnly;
					int num2 = default(int);
					ControllerPollingInfo result = default(ControllerPollingInfo);
					while (true)
					{
						int num = -1911219547;
						while (true)
						{
							switch (num ^ -1911219548)
							{
							case 3:
								break;
							case 1:
								num2 = 0;
								num = -1911219552;
								continue;
							case 0:
								result = joysticks_readOnly[num2].PollForFirstElement();
								num = -1911219546;
								continue;
							case 2:
								if (result.success)
								{
									return result;
								}
								num2++;
								num = -1911219552;
								continue;
							default:
								if (num2 >= joysticks_readOnly.Count)
								{
									return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
								}
								goto case 0;
							}
							break;
						}
					}
				}

				private ControllerPollingInfo YILeFMeqoXQviZbFJjCoenIVZXb()
				{
					IList<Joystick> joysticks_readOnly = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Joysticks_readOnly;
					int num2 = default(int);
					while (true)
					{
						int num = 682524420;
						while (true)
						{
							switch (num ^ 0x28AE7F05)
							{
							case 2:
								break;
							case 1:
								num2 = 0;
								num = 682524422;
								continue;
							case 0:
							{
								ControllerPollingInfo result = joysticks_readOnly[num2].PollForFirstElementDown();
								if (result.success)
								{
									return result;
								}
								num2++;
								num = 682524417;
								continue;
							}
							case 3:
								num = 682524417;
								continue;
							default:
								if (num2 >= joysticks_readOnly.Count)
								{
									return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
								}
								goto case 0;
							}
							break;
						}
					}
				}

				private ControllerPollingInfo abyGORrOhyhcxhxKFkOtRfpDIxn()
				{
					IList<Joystick> joysticks_readOnly = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Joysticks_readOnly;
					int num = 0;
					while (num < joysticks_readOnly.Count)
					{
						while (true)
						{
							ControllerPollingInfo result = joysticks_readOnly[num].PollForFirstButton();
							if (result.success)
							{
								return result;
							}
							num++;
							int num2 = -1175846409;
							while (true)
							{
								switch (num2 ^ -1175846409)
								{
								case 2:
									num2 = -1175846410;
									continue;
								case 1:
									break;
								default:
									goto end_IL_002d;
								}
								break;
							}
							continue;
							end_IL_002d:
							break;
						}
					}
					return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
				}

				private ControllerPollingInfo gHlObotxEJvkhHPMsfmSqqhgRkb()
				{
					IList<Joystick> joysticks_readOnly = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Joysticks_readOnly;
					int num2 = default(int);
					ControllerPollingInfo result = default(ControllerPollingInfo);
					while (true)
					{
						int num = -833317357;
						while (true)
						{
							switch (num ^ -833317358)
							{
							case 6:
								break;
							case 1:
								num2 = 0;
								num = -833317354;
								continue;
							case 0:
							{
								int num3;
								if (num2 >= joysticks_readOnly.Count)
								{
									num = -833317359;
									num3 = num;
								}
								else
								{
									num = -833317360;
									num3 = num;
								}
								continue;
							}
							case 5:
								if (result.success)
								{
									return result;
								}
								num2++;
								num = -833317358;
								continue;
							case 2:
								result = joysticks_readOnly[num2].PollForFirstButtonDown();
								num = -833317353;
								continue;
							case 4:
								num = -833317358;
								continue;
							default:
								return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
							}
							break;
						}
					}
				}

				private ControllerPollingInfo fZKGpDcMiOmLXrjZyQzXJWWzlckK()
				{
					IList<Joystick> joysticks_readOnly = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Joysticks_readOnly;
					int num2 = default(int);
					while (true)
					{
						int num = 74576151;
						while (true)
						{
							switch (num ^ 0x471F112)
							{
							case 0:
								break;
							case 5:
								num2 = 0;
								num = 74576144;
								continue;
							case 4:
							{
								int num3;
								if (num2 < joysticks_readOnly.Count)
								{
									num = 74576147;
									num3 = num;
								}
								else
								{
									num = 74576145;
									num3 = num;
								}
								continue;
							}
							case 2:
								num = 74576150;
								continue;
							case 1:
							{
								ControllerPollingInfo result = joysticks_readOnly[num2].PollForFirstAxis();
								if (result.success)
								{
									return result;
								}
								num2++;
								num = 74576150;
								continue;
							}
							default:
								return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
							}
							break;
						}
					}
				}

				private ControllerPollingInfo QTHHhtZvMOTHCNogqoiYPMSNTIJ(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					return joystick.PollForFirstElement();
				}

				private ControllerPollingInfo GDtaQxELDAQZnkpYDEDZdvgChmaH(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					return joystick.PollForFirstElementDown();
				}

				private ControllerPollingInfo uDcyrqRjyjYUZBQAMkSrkeQFzXG(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					return joystick.PollForFirstButton();
				}

				private ControllerPollingInfo wOyNHqHCRDRHpzGOOECkUJgpywr(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					return joystick.PollForFirstButtonDown();
				}

				private ControllerPollingInfo NxDJdcvCXfLvBkJukaYmNkijRCl(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					return joystick.PollForFirstAxis();
				}

				private ControllerPollingInfo kVfkalzgRMRGOreRPrdCIcqTNne()
				{
					return ControllerHelper.Instance.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo FUHTmNZZlLGUkEmrYTEztgzsXQO()
				{
					return ControllerHelper.Instance.Keyboard.PollForFirstKeyDown();
				}

				private ControllerPollingInfo SdGCNjbvhDCBOeEgDtrzcpfvFEa()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo NPHoBbcKDNpvRvFzFKCJoyskIVh()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo NMbGCUQXOhZbVFNqQGBWRoCLInQH()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo zulpyjzAMwJJVkRlChfYstTzSfB()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo ZbDqgNQEJctkzCHtydaUBAcSGqhn()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstAxis();
				}

				private ControllerPollingInfo VgQGWlDOjGHmzCMfkFNnRosvCBnm()
				{
					IList<CustomController> customControllers_readOnly = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.CustomControllers_readOnly;
					int num = 0;
					while (num < customControllers_readOnly.Count)
					{
						while (true)
						{
							ControllerPollingInfo result = customControllers_readOnly[num].PollForFirstElement();
							int num2 = -1079080563;
							while (true)
							{
								switch (num2 ^ -1079080562)
								{
								case 0:
									num2 = -1079080561;
									continue;
								case 1:
									break;
								case 3:
									goto IL_0045;
								default:
									goto end_IL_0031;
								}
								break;
								IL_0045:
								if (result.success)
								{
									return result;
								}
								num++;
								num2 = -1079080564;
							}
							continue;
							end_IL_0031:
							break;
						}
					}
					return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
				}

				private ControllerPollingInfo gDdQpBGKNWhVQDpwXKKpdLXJCxdN()
				{
					IList<CustomController> customControllers_readOnly = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.CustomControllers_readOnly;
					int num = 0;
					ControllerPollingInfo result = default(ControllerPollingInfo);
					while (true)
					{
						int num2 = -628648831;
						while (true)
						{
							switch (num2 ^ -628648832)
							{
							case 4:
								break;
							case 1:
								num2 = -628648829;
								continue;
							case 0:
								if (result.success)
								{
									return result;
								}
								num++;
								num2 = -628648829;
								continue;
							case 2:
								result = customControllers_readOnly[num].PollForFirstElementDown();
								num2 = -628648832;
								continue;
							default:
								if (num >= customControllers_readOnly.Count)
								{
									return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
								}
								goto case 2;
							}
							break;
						}
					}
				}

				private ControllerPollingInfo EKkezDBOTOzSxPZrlJfSfJnVEOO()
				{
					IList<CustomController> customControllers_readOnly = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.CustomControllers_readOnly;
					int num = 0;
					while (num < customControllers_readOnly.Count)
					{
						while (true)
						{
							ControllerPollingInfo result = customControllers_readOnly[num].PollForFirstButton();
							if (result.success)
							{
								return result;
							}
							num++;
							int num2 = -414534787;
							while (true)
							{
								switch (num2 ^ -414534787)
								{
								case 2:
									num2 = -414534788;
									continue;
								case 1:
									break;
								default:
									goto end_IL_002d;
								}
								break;
							}
							continue;
							end_IL_002d:
							break;
						}
					}
					return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
				}

				private ControllerPollingInfo kGcZTpFjGVWkXkAeDrOTovCHlmy()
				{
					IList<CustomController> customControllers_readOnly = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.CustomControllers_readOnly;
					int num = 0;
					while (num < customControllers_readOnly.Count)
					{
						while (true)
						{
							ControllerPollingInfo result = customControllers_readOnly[num].PollForFirstButtonDown();
							int num2 = -962741900;
							while (true)
							{
								switch (num2 ^ -962741900)
								{
								case 2:
									num2 = -962741897;
									continue;
								case 3:
									break;
								case 0:
									goto IL_0045;
								default:
									goto end_IL_0031;
								}
								break;
								IL_0045:
								if (result.success)
								{
									return result;
								}
								num++;
								num2 = -962741899;
							}
							continue;
							end_IL_0031:
							break;
						}
					}
					return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
				}

				private ControllerPollingInfo NJyhAtWDUKzASBdNxLdmuXGePsd()
				{
					IList<CustomController> customControllers_readOnly = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.CustomControllers_readOnly;
					int num = 0;
					while (true)
					{
						int num2;
						int num3;
						if (num >= customControllers_readOnly.Count)
						{
							num2 = -927571097;
							num3 = num2;
						}
						else
						{
							num2 = -927571099;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -927571098)
							{
							case 2:
								num2 = -927571099;
								continue;
							case 3:
							{
								ControllerPollingInfo result = customControllers_readOnly[num].PollForFirstAxis();
								if (result.success)
								{
									return result;
								}
								num++;
								num2 = -927571098;
								continue;
							}
							case 0:
								break;
							default:
								return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
							}
							break;
						}
					}
				}

				private ControllerPollingInfo DVPDckGKOzaLVSheictrDOlLtyV(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					return customController.PollForFirstElement();
				}

				private ControllerPollingInfo vEpHGvYirAiZguBlfFoJAlaqhPAL(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					return customController.PollForFirstElementDown();
				}

				private ControllerPollingInfo oEGDibdwMeHUBUyGQsUXVDBioRh(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					return customController.PollForFirstButton();
				}

				private ControllerPollingInfo hvNJEuIAWzxPdnGllQLLbTsPuu(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					return customController.PollForFirstButtonDown();
				}

				private ControllerPollingInfo JsPmhhReveucQUJsEfaMOLoZgsb(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					return customController.PollForFirstAxis();
				}

				private IEnumerable<ControllerPollingInfo> dvwDQcTsnkGAXAkiYcQEXuKabEmb()
				{
					QrUvmjopEDkYVzAxILkVuZUjpSE qrUvmjopEDkYVzAxILkVuZUjpSE = new QrUvmjopEDkYVzAxILkVuZUjpSE(-2);
					qrUvmjopEDkYVzAxILkVuZUjpSE.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return qrUvmjopEDkYVzAxILkVuZUjpSE;
				}

				private IEnumerable<ControllerPollingInfo> CFxlRMUlnOStZtjkmokPfvOCiq()
				{
					YYSnUrUCBMiUYAokSBKKCJifycPN yYSnUrUCBMiUYAokSBKKCJifycPN = new YYSnUrUCBMiUYAokSBKKCJifycPN(-2);
					yYSnUrUCBMiUYAokSBKKCJifycPN.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return yYSnUrUCBMiUYAokSBKKCJifycPN;
				}

				private IEnumerable<ControllerPollingInfo> kFBCFTCQMRsQtGnDWpwZBsNboxzu()
				{
					AqGkhqjlpSyRLzKDMhqzMWlRkNZ aqGkhqjlpSyRLzKDMhqzMWlRkNZ = new AqGkhqjlpSyRLzKDMhqzMWlRkNZ(-2);
					aqGkhqjlpSyRLzKDMhqzMWlRkNZ.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return aqGkhqjlpSyRLzKDMhqzMWlRkNZ;
				}

				private IEnumerable<ControllerPollingInfo> FBPCcdDOXVAyPwkzsmgJgnerhxo()
				{
					LSrBtnDoLyPRGqdYboePIrYhjtWm lSrBtnDoLyPRGqdYboePIrYhjtWm = new LSrBtnDoLyPRGqdYboePIrYhjtWm(-2);
					lSrBtnDoLyPRGqdYboePIrYhjtWm.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return lSrBtnDoLyPRGqdYboePIrYhjtWm;
				}

				private IEnumerable<ControllerPollingInfo> zStUtarppXmOxgicfxgZXjzciwH()
				{
					bgfcxoEjkuNoMPgpSVTNHBxaLYy bgfcxoEjkuNoMPgpSVTNHBxaLYy2 = new bgfcxoEjkuNoMPgpSVTNHBxaLYy(-2);
					bgfcxoEjkuNoMPgpSVTNHBxaLYy2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return bgfcxoEjkuNoMPgpSVTNHBxaLYy2;
				}

				private IEnumerable<ControllerPollingInfo> cjzIFxLQWnubptTYBRdPnOkZQjP(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> gPsSdhQsSKOSRdxkRZJiEboVpzr(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> AJQTiIlENPYVzLpJAHuMEQqxGeHL(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> lyiTBiFFfcuKqEuwxBacPThkvJP(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					while (true)
					{
						int num = -10315777;
						while (true)
						{
							switch (num ^ -10315779)
							{
							case 0:
								break;
							case 2:
								if (joystick == null)
								{
									goto IL_002d;
								}
								return joystick.PollForAllButtonsDown();
							default:
								return new List<ControllerPollingInfo>();
							}
							break;
							IL_002d:
							num = -10315780;
						}
					}
				}

				private IEnumerable<ControllerPollingInfo> rfduapsLWPXYrBjLuVBEztKxhdG(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> XzuyRyAOJjyALLhPWbokPtkFsjX()
				{
					return ControllerHelper.Instance.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> xYkfoZREkimMSyaRebVQAcNFERCb()
				{
					return ControllerHelper.Instance.Keyboard.PollForAllKeysDown();
				}

				private IEnumerable<ControllerPollingInfo> uVtPvBSPOVSVrmwtatDmhmggEGMF()
				{
					return ControllerHelper.Instance.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> gdrcxxklAWXerFCQbSVzkXEdgxU()
				{
					return ControllerHelper.Instance.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> DeTCsDGLpHqPnFfUIAtMoelubGtE()
				{
					return ControllerHelper.Instance.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> lmSnIdpGCHOCWsoOFiSqZxXYdcQI()
				{
					return ControllerHelper.Instance.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> bLVygRZbxibgWFbIdFaUPVtRMuny()
				{
					return ControllerHelper.Instance.Mouse.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> EEOwutpgymYFElDnLMyFQruAuLm()
				{
					ibrncOSlkxVaKZrbAPOiRyujdgm ibrncOSlkxVaKZrbAPOiRyujdgm2 = new ibrncOSlkxVaKZrbAPOiRyujdgm(-2);
					ibrncOSlkxVaKZrbAPOiRyujdgm2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return ibrncOSlkxVaKZrbAPOiRyujdgm2;
				}

				private IEnumerable<ControllerPollingInfo> yxdDYqIyvMkgblockvQWdELjtkL()
				{
					zNgBjOjLoHAUYkGELURmoDVwqVKZ zNgBjOjLoHAUYkGELURmoDVwqVKZ2 = new zNgBjOjLoHAUYkGELURmoDVwqVKZ(-2);
					zNgBjOjLoHAUYkGELURmoDVwqVKZ2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return zNgBjOjLoHAUYkGELURmoDVwqVKZ2;
				}

				private IEnumerable<ControllerPollingInfo> dxVKSduPGjjgfiVGZfHmUfUnfTp()
				{
					IJPItqdtmvWTLTUXJSdKipJpYxI iJPItqdtmvWTLTUXJSdKipJpYxI = new IJPItqdtmvWTLTUXJSdKipJpYxI(-2);
					iJPItqdtmvWTLTUXJSdKipJpYxI.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return iJPItqdtmvWTLTUXJSdKipJpYxI;
				}

				private IEnumerable<ControllerPollingInfo> RdDifOaDAnORDxQFDIoqLlKJvVwB()
				{
					KntjOaLdadcNRbwsGXshDCeGSbe kntjOaLdadcNRbwsGXshDCeGSbe = new KntjOaLdadcNRbwsGXshDCeGSbe(-2);
					kntjOaLdadcNRbwsGXshDCeGSbe.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return kntjOaLdadcNRbwsGXshDCeGSbe;
				}

				private IEnumerable<ControllerPollingInfo> HMKERaxpOodqZfIamnsIXKLtAwvF()
				{
					uHyWFrHZFAQmuHGoshcPeoBcnUj uHyWFrHZFAQmuHGoshcPeoBcnUj2 = new uHyWFrHZFAQmuHGoshcPeoBcnUj(-2);
					uHyWFrHZFAQmuHGoshcPeoBcnUj2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return uHyWFrHZFAQmuHGoshcPeoBcnUj2;
				}

				private IEnumerable<ControllerPollingInfo> ZlzgZLotdICeurwylMbbGRjSONf(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> qbXVScLmmBOAzZSCgTvLZBCoiIJD(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> pXeYtLpKQogvUGcPYHnffUXpoyK(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> xrohFXFhMxujxbiBBORMDNVmaYp(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> qELQYvbXHgTeNPPytbuAYYFkqTO(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					while (true)
					{
						int num = 1815899850;
						while (true)
						{
							switch (num ^ 0x6C3C6EC8)
							{
							case 0:
								break;
							case 2:
								if (customController == null)
								{
									goto IL_002d;
								}
								return customController.PollForAllAxes();
							default:
								return new List<ControllerPollingInfo>();
							}
							break;
							IL_002d:
							num = 1815899849;
						}
					}
				}
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Browsable(false)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class NBNhWeqxLxStXSolAdBCcZJTuxD : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public int DERQvNdAIfJFDnFpDBYSBQlXxSHC;

					public int RApvxUwOMdwouTDjTDNwfqBnIsx;

					public int rxdjJqJqAJRgVnTJDSuuQBAmCyL;

					public int qWJPVxPfcLerRJqSvJoChuSerNNP;

					public JoystickMap SIQHejiajBzHfVokYfEbhVPFRRz;

					public JoystickMap TCLAhQjtREcDqiIQiNqBdSSDhjiT;

					public ActionElementMap WXybJffitOceMtNKISmGhCPIZdbW;

					public ActionElementMap CguHVgoqOaKWyWHagBJEhIvVPUP;

					public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

					public bool AsggrPyUWCnFFjkCeamlXvALxt;

					public bool nRQNgoCfnWFTgxkywDuXhmkaHZcq;

					public bool UjalQWhdiZeUFTfVHLYPzbrLtqZ;

					public bool ByyGWmDgpIFJaAabWjaMBssRpcWh;

					public bool WavyIscbOethGrCUZxLqsEtHClj;

					public IList<Player> xzNNNoOFYgKZbyaQicGJcjzdBINB;

					public int ySHZopnkRIFAIhXIkASNKkBPkcK;

					public ElementAssignmentConflictInfo hFkYdBQORAojhaqMrvrVmxrimgt;

					public ConflictCheckingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ElementAssignmentConflictInfo> miJIHmylNGImycPfsdHtaDZahBT;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
						{
							goto IL_0015;
						}
						goto IL_00b4;
						IL_0015:
						int num = 2002822822;
						goto IL_001a;
						IL_001a:
						NBNhWeqxLxStXSolAdBCcZJTuxD nBNhWeqxLxStXSolAdBCcZJTuxD = default(NBNhWeqxLxStXSolAdBCcZJTuxD);
						while (true)
						{
							switch (num ^ 0x7760A6A4)
							{
							case 5:
								break;
							case 6:
								nBNhWeqxLxStXSolAdBCcZJTuxD.SIQHejiajBzHfVokYfEbhVPFRRz = TCLAhQjtREcDqiIQiNqBdSSDhjiT;
								nBNhWeqxLxStXSolAdBCcZJTuxD.WXybJffitOceMtNKISmGhCPIZdbW = CguHVgoqOaKWyWHagBJEhIvVPUP;
								nBNhWeqxLxStXSolAdBCcZJTuxD.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
								nBNhWeqxLxStXSolAdBCcZJTuxD.nRQNgoCfnWFTgxkywDuXhmkaHZcq = UjalQWhdiZeUFTfVHLYPzbrLtqZ;
								nBNhWeqxLxStXSolAdBCcZJTuxD.ByyGWmDgpIFJaAabWjaMBssRpcWh = WavyIscbOethGrCUZxLqsEtHClj;
								num = 2002822816;
								continue;
							case 3:
								nBNhWeqxLxStXSolAdBCcZJTuxD = this;
								num = 2002822820;
								continue;
							case 0:
								nBNhWeqxLxStXSolAdBCcZJTuxD.DERQvNdAIfJFDnFpDBYSBQlXxSHC = RApvxUwOMdwouTDjTDNwfqBnIsx;
								nBNhWeqxLxStXSolAdBCcZJTuxD.rxdjJqJqAJRgVnTJDSuuQBAmCyL = qWJPVxPfcLerRJqSvJoChuSerNNP;
								num = 2002822818;
								continue;
							case 1:
								goto IL_00b4;
							case 2:
								if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
								{
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
									num = 2002822823;
									continue;
								}
								goto IL_00b4;
							default:
								return nBNhWeqxLxStXSolAdBCcZJTuxD;
							}
							break;
						}
						goto IL_0015;
						IL_00b4:
						nBNhWeqxLxStXSolAdBCcZJTuxD = new NBNhWeqxLxStXSolAdBCcZJTuxD(0);
						nBNhWeqxLxStXSolAdBCcZJTuxD.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = 2002822820;
						goto IL_001a;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						bool result = default(bool);
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 0:
								goto IL_0096;
							case 2:
								goto IL_0151;
							default:
								goto IL_01bd;
								IL_0096:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (DERQvNdAIfJFDnFpDBYSBQlXxSHC >= 0 && WXybJffitOceMtNKISmGhCPIZdbW != null)
								{
									xzNNNoOFYgKZbyaQicGJcjzdBINB = (ByyGWmDgpIFJaAabWjaMBssRpcWh ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
									ySHZopnkRIFAIhXIkASNKkBPkcK = 0;
									num = -490160557;
									goto IL_0023;
								}
								goto IL_01bd;
								IL_0151:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -490160545;
								goto IL_0023;
								IL_01bd:
								result = false;
								num = -490160551;
								goto IL_0023;
								IL_0023:
								while (true)
								{
									switch (num ^ -490160556)
									{
									case 3:
										num = -490160555;
										continue;
									case 10:
										goto IL_006b;
									case 8:
										num = -490160545;
										continue;
									case 1:
										goto IL_0096;
									case 7:
										num = -490160546;
										continue;
									case 11:
										goto IL_00f3;
									case 4:
										wINTEQGxddRuJcefsptoeOIOOFS();
										ySHZopnkRIFAIhXIkASNKkBPkcK++;
										num = -490160546;
										continue;
									case 6:
										RDkWcsTpvDaNZojjIZONnoEBXPC = hFkYdBQORAojhaqMrvrVmxrimgt;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										result = true;
										num = -490160554;
										continue;
									case 12:
										goto IL_0151;
									case 9:
										miJIHmylNGImycPfsdHtaDZahBT = xzNNNoOFYgKZbyaQicGJcjzdBINB[ySHZopnkRIFAIhXIkASNKkBPkcK].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Joystick, rxdjJqJqAJRgVnTJDSuuQBAmCyL, SIQHejiajBzHfVokYfEbhVPFRRz, WXybJffitOceMtNKISmGhCPIZdbW, RKQUCYjAXkOQEvYPFrRsAzEcuaK, nRQNgoCfnWFTgxkywDuXhmkaHZcq).GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = -490160548;
										continue;
									case 5:
										goto IL_01bd;
									case 2:
										break;
									case 0:
										hFkYdBQORAojhaqMrvrVmxrimgt = miJIHmylNGImycPfsdHtaDZahBT.Current;
										num = -490160558;
										continue;
									case 13:
										break;
									}
									break;
									IL_00f3:
									int num2;
									if (!miJIHmylNGImycPfsdHtaDZahBT.MoveNext())
									{
										num = -490160560;
										num2 = num;
									}
									else
									{
										num = -490160556;
										num2 = num;
									}
									continue;
									IL_006b:
									int num3;
									if (ySHZopnkRIFAIhXIkASNKkBPkcK < xzNNNoOFYgKZbyaQicGJcjzdBINB.Count)
									{
										num = -490160547;
										num3 = num;
									}
									else
									{
										num = -490160559;
										num3 = num;
									}
								}
								break;
							}
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
						return result;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								wINTEQGxddRuJcefsptoeOIOOFS();
							}
						}
					}

					[DebuggerHidden]
					public NBNhWeqxLxStXSolAdBCcZJTuxD(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void wINTEQGxddRuJcefsptoeOIOOFS()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (miJIHmylNGImycPfsdHtaDZahBT != null)
						{
							miJIHmylNGImycPfsdHtaDZahBT.Dispose();
						}
					}
				}

				private sealed class eEHbqPqyGtcfTAiunwoLZAhhqam : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public ElementAssignmentConflictCheck XoQvEtmGuEoQzAIlaNmgxPliHTu;

					public ElementAssignmentConflictCheck UQPnpLguhtCEkQPRaxuaPxhrRag;

					public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

					public bool AsggrPyUWCnFFjkCeamlXvALxt;

					public bool nRQNgoCfnWFTgxkywDuXhmkaHZcq;

					public bool UjalQWhdiZeUFTfVHLYPzbrLtqZ;

					public bool ByyGWmDgpIFJaAabWjaMBssRpcWh;

					public bool WavyIscbOethGrCUZxLqsEtHClj;

					public IList<Player> jAUylinkuksiAllgcDtzLWzLOYs;

					public int VAtbbbpJjCcpkNDTYSBvBbjWrwN;

					public ElementAssignmentConflictInfo lPeRUyrcLdNOvDRLobMKEDuQdzUF;

					public ConflictCheckingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ElementAssignmentConflictInfo> QZyCmbYviXqRXJUsRJDQDzpPmjw;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId != iDzUuTsbdXLkIyEGCPmJzsmGhcs || LzqgRXjFXvJPbHjfzyAmNfcqezXL != -2)
						{
							goto IL_0049;
						}
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						eEHbqPqyGtcfTAiunwoLZAhhqam eEHbqPqyGtcfTAiunwoLZAhhqam2 = this;
						goto IL_0063;
						IL_002c:
						int num;
						while (true)
						{
							switch (num ^ -675610105)
							{
							case 3:
								num = -675610107;
								continue;
							case 2:
								break;
							case 1:
								goto IL_0063;
							default:
								eEHbqPqyGtcfTAiunwoLZAhhqam2.ByyGWmDgpIFJaAabWjaMBssRpcWh = WavyIscbOethGrCUZxLqsEtHClj;
								return eEHbqPqyGtcfTAiunwoLZAhhqam2;
							}
							break;
						}
						goto IL_0049;
						IL_0049:
						eEHbqPqyGtcfTAiunwoLZAhhqam2 = new eEHbqPqyGtcfTAiunwoLZAhhqam(0);
						eEHbqPqyGtcfTAiunwoLZAhhqam2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = -675610106;
						goto IL_002c;
						IL_0063:
						eEHbqPqyGtcfTAiunwoLZAhhqam2.XoQvEtmGuEoQzAIlaNmgxPliHTu = UQPnpLguhtCEkQPRaxuaPxhrRag;
						eEHbqPqyGtcfTAiunwoLZAhhqam2.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
						eEHbqPqyGtcfTAiunwoLZAhhqam2.nRQNgoCfnWFTgxkywDuXhmkaHZcq = UjalQWhdiZeUFTfVHLYPzbrLtqZ;
						num = -675610105;
						goto IL_002c;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						bool result = default(bool);
						try
						{
							int num;
							int num4;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							default:
								goto IL_0111;
							case 0:
								goto IL_011d;
							case 2:
								goto IL_01c8;
								IL_0111:
								result = false;
								num = 660285473;
								goto IL_0023;
								IL_0023:
								while (true)
								{
									switch (num ^ 0x275B282A)
									{
									case 6:
										num = 660285472;
										continue;
									case 2:
										goto IL_0063;
									case 7:
										QZyCmbYviXqRXJUsRJDQDzpPmjw = jAUylinkuksiAllgcDtzLWzLOYs[VAtbbbpJjCcpkNDTYSBvBbjWrwN].controllers.conflictChecking.ElementAssignmentConflicts(XoQvEtmGuEoQzAIlaNmgxPliHTu, RKQUCYjAXkOQEvYPFrRsAzEcuaK, nRQNgoCfnWFTgxkywDuXhmkaHZcq).GetEnumerator();
										num = 660285487;
										continue;
									case 4:
										if (XoQvEtmGuEoQzAIlaNmgxPliHTu.elementAssignmentType != ElementAssignmentType.KeyboardKey)
										{
											jAUylinkuksiAllgcDtzLWzLOYs = (ByyGWmDgpIFJaAabWjaMBssRpcWh ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
											VAtbbbpJjCcpkNDTYSBvBbjWrwN = 0;
											num = 660285480;
											continue;
										}
										goto IL_0111;
									case 1:
										goto IL_0111;
									case 10:
										goto IL_011d;
									case 9:
										lPeRUyrcLdNOvDRLobMKEDuQdzUF = QZyCmbYviXqRXJUsRJDQDzpPmjw.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = lPeRUyrcLdNOvDRLobMKEDuQdzUF;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										result = true;
										break;
									case 8:
										yhHqeSBtPlrhbKmFseJmDFclNkrs();
										VAtbbbpJjCcpkNDTYSBvBbjWrwN++;
										num = 660285480;
										continue;
									case 0:
										goto IL_0196;
									case 5:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = 660285482;
										continue;
									case 3:
										goto IL_01c8;
									case 11:
										break;
									}
									break;
									IL_0196:
									int num2;
									if (QZyCmbYviXqRXJUsRJDQDzpPmjw.MoveNext())
									{
										num = 660285475;
										num2 = num;
									}
									else
									{
										num = 660285474;
										num2 = num;
									}
									continue;
									IL_0063:
									int num3;
									if (VAtbbbpJjCcpkNDTYSBvBbjWrwN >= jAUylinkuksiAllgcDtzLWzLOYs.Count)
									{
										num = 660285483;
										num3 = num;
									}
									else
									{
										num = 660285485;
										num3 = num;
									}
								}
								break;
								IL_01c8:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 660285482;
								goto IL_0023;
								IL_011d:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (XoQvEtmGuEoQzAIlaNmgxPliHTu.playerId >= 0)
								{
									num = 660285486;
									num4 = num;
								}
								else
								{
									num = 660285483;
									num4 = num;
								}
								goto IL_0023;
							}
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
						return result;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
						while (true)
						{
							int num = -121564735;
							while (true)
							{
								switch (num ^ -121564733)
								{
								case 0:
									break;
								default:
									return;
								case 2:
									switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
									{
									case 1:
									case 2:
										try
										{
											return;
										}
										finally
										{
											yhHqeSBtPlrhbKmFseJmDFclNkrs();
										}
									}
									goto IL_0035;
								case 1:
									return;
								}
								break;
								IL_0035:
								num = -121564734;
							}
						}
					}

					[DebuggerHidden]
					public eEHbqPqyGtcfTAiunwoLZAhhqam(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void yhHqeSBtPlrhbKmFseJmDFclNkrs()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (QZyCmbYviXqRXJUsRJDQDzpPmjw != null)
						{
							QZyCmbYviXqRXJUsRJDQDzpPmjw.Dispose();
						}
					}
				}

				private sealed class PjJUpstKKvgcCqPNeiWfAqRATyt : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public int DERQvNdAIfJFDnFpDBYSBQlXxSHC;

					public int RApvxUwOMdwouTDjTDNwfqBnIsx;

					public KeyboardMap aRBaZLcryXgydhIgDIyNuRunbVyk;

					public KeyboardMap fGefznGryZGBacvzYFGYnYNltBEP;

					public ActionElementMap WXybJffitOceMtNKISmGhCPIZdbW;

					public ActionElementMap CguHVgoqOaKWyWHagBJEhIvVPUP;

					public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

					public bool AsggrPyUWCnFFjkCeamlXvALxt;

					public bool nRQNgoCfnWFTgxkywDuXhmkaHZcq;

					public bool UjalQWhdiZeUFTfVHLYPzbrLtqZ;

					public bool ByyGWmDgpIFJaAabWjaMBssRpcWh;

					public bool WavyIscbOethGrCUZxLqsEtHClj;

					public IList<Player> hGfRHSLsYdMlzXYOgKCqKOXpbVO;

					public int iFMVGepnTaeMjYWvIOkalQhPsHC;

					public ElementAssignmentConflictInfo FYPksomokcsEjqOVoFjIeVMzrqHK;

					public ConflictCheckingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ElementAssignmentConflictInfo> HxoAXiLGBKsfDZgWYBLeSvkpUCj;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							goto IL_0022;
						}
						goto IL_00b8;
						IL_00b8:
						PjJUpstKKvgcCqPNeiWfAqRATyt pjJUpstKKvgcCqPNeiWfAqRATyt = new PjJUpstKKvgcCqPNeiWfAqRATyt(0);
						pjJUpstKKvgcCqPNeiWfAqRATyt.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						int num = -1644884055;
						goto IL_0027;
						IL_0022:
						num = -1644884053;
						goto IL_0027;
						IL_0027:
						while (true)
						{
							switch (num ^ -1644884055)
							{
							case 4:
								break;
							case 0:
								pjJUpstKKvgcCqPNeiWfAqRATyt.DERQvNdAIfJFDnFpDBYSBQlXxSHC = RApvxUwOMdwouTDjTDNwfqBnIsx;
								pjJUpstKKvgcCqPNeiWfAqRATyt.aRBaZLcryXgydhIgDIyNuRunbVyk = fGefznGryZGBacvzYFGYnYNltBEP;
								pjJUpstKKvgcCqPNeiWfAqRATyt.WXybJffitOceMtNKISmGhCPIZdbW = CguHVgoqOaKWyWHagBJEhIvVPUP;
								pjJUpstKKvgcCqPNeiWfAqRATyt.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
								pjJUpstKKvgcCqPNeiWfAqRATyt.nRQNgoCfnWFTgxkywDuXhmkaHZcq = UjalQWhdiZeUFTfVHLYPzbrLtqZ;
								pjJUpstKKvgcCqPNeiWfAqRATyt.ByyGWmDgpIFJaAabWjaMBssRpcWh = WavyIscbOethGrCUZxLqsEtHClj;
								num = -1644884056;
								continue;
							case 3:
								num = -1644884055;
								continue;
							case 2:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
								pjJUpstKKvgcCqPNeiWfAqRATyt = this;
								num = -1644884054;
								continue;
							case 5:
								goto IL_00b8;
							default:
								return pjJUpstKKvgcCqPNeiWfAqRATyt;
							}
							break;
						}
						goto IL_0022;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						bool result = default(bool);
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 0:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (DERQvNdAIfJFDnFpDBYSBQlXxSHC < 0 || WXybJffitOceMtNKISmGhCPIZdbW == null)
								{
									break;
								}
								hGfRHSLsYdMlzXYOgKCqKOXpbVO = (ByyGWmDgpIFJaAabWjaMBssRpcWh ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
								iFMVGepnTaeMjYWvIOkalQhPsHC = 0;
								num = -1075513553;
								goto IL_0023;
							case 2:
								goto IL_0177;
								IL_0023:
								while (true)
								{
									switch (num ^ -1075513557)
									{
									case 7:
										num = -1075513559;
										continue;
									case 3:
										if (!HxoAXiLGBKsfDZgWYBLeSvkpUCj.MoveNext())
										{
											EHYezRAIUSEkmFfSbRirftxEYyFq();
											iFMVGepnTaeMjYWvIOkalQhPsHC++;
											num = -1075513553;
											continue;
										}
										goto case 5;
									case 4:
										break;
									case 8:
										HxoAXiLGBKsfDZgWYBLeSvkpUCj = hGfRHSLsYdMlzXYOgKCqKOXpbVO[iFMVGepnTaeMjYWvIOkalQhPsHC].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Keyboard, 0, aRBaZLcryXgydhIgDIyNuRunbVyk, WXybJffitOceMtNKISmGhCPIZdbW, RKQUCYjAXkOQEvYPFrRsAzEcuaK, nRQNgoCfnWFTgxkywDuXhmkaHZcq).GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = -1075513560;
										continue;
									case 5:
										FYPksomokcsEjqOVoFjIeVMzrqHK = HxoAXiLGBKsfDZgWYBLeSvkpUCj.Current;
										num = -1075513566;
										continue;
									case 2:
										goto end_IL_0023;
									case 0:
										goto end_IL_0000;
									case 6:
										goto IL_0177;
									case 9:
										RDkWcsTpvDaNZojjIZONnoEBXPC = FYPksomokcsEjqOVoFjIeVMzrqHK;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										result = true;
										num = -1075513557;
										continue;
									default:
										goto end_IL_0008;
									}
									int num2;
									if (iFMVGepnTaeMjYWvIOkalQhPsHC >= hGfRHSLsYdMlzXYOgKCqKOXpbVO.Count)
									{
										num = -1075513558;
										num2 = num;
									}
									else
									{
										num = -1075513565;
										num2 = num;
									}
									continue;
									end_IL_0023:
									break;
								}
								goto case 0;
								IL_0177:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -1075513560;
								goto IL_0023;
								end_IL_0008:
								break;
							}
							result = false;
							end_IL_0000:;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
						return result;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								EHYezRAIUSEkmFfSbRirftxEYyFq();
							}
						}
					}

					[DebuggerHidden]
					public PjJUpstKKvgcCqPNeiWfAqRATyt(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void EHYezRAIUSEkmFfSbRirftxEYyFq()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						while (true)
						{
							int num = 414397735;
							while (true)
							{
								switch (num ^ 0x18B33526)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									if (HxoAXiLGBKsfDZgWYBLeSvkpUCj != null)
									{
										goto IL_002d;
									}
									return;
								case 2:
									return;
								}
								break;
								IL_002d:
								HxoAXiLGBKsfDZgWYBLeSvkpUCj.Dispose();
								num = 414397732;
							}
						}
					}
				}

				private sealed class yBStqblSrwgsWwUviwqvxWFGUDU : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public ElementAssignmentConflictCheck XoQvEtmGuEoQzAIlaNmgxPliHTu;

					public ElementAssignmentConflictCheck UQPnpLguhtCEkQPRaxuaPxhrRag;

					public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

					public bool AsggrPyUWCnFFjkCeamlXvALxt;

					public bool nRQNgoCfnWFTgxkywDuXhmkaHZcq;

					public bool UjalQWhdiZeUFTfVHLYPzbrLtqZ;

					public bool ByyGWmDgpIFJaAabWjaMBssRpcWh;

					public bool WavyIscbOethGrCUZxLqsEtHClj;

					public IList<Player> dHYmAMgBYzbcwgvyTFvkGxXSUhWj;

					public int gswLLcFpHEbOZhixdlcSifqLoins;

					public ElementAssignmentConflictInfo pJvaPjuiIiOGkwggNxIPuDjXdin;

					public ConflictCheckingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ElementAssignmentConflictInfo> IsGRKISgHIKBaFxrVRUegblNohn;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							goto IL_0023;
						}
						goto IL_008b;
						IL_0028:
						int num;
						yBStqblSrwgsWwUviwqvxWFGUDU yBStqblSrwgsWwUviwqvxWFGUDU2 = default(yBStqblSrwgsWwUviwqvxWFGUDU);
						while (true)
						{
							switch (num ^ 0x274A598)
							{
							case 0:
								break;
							case 4:
								yBStqblSrwgsWwUviwqvxWFGUDU2.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
								yBStqblSrwgsWwUviwqvxWFGUDU2.nRQNgoCfnWFTgxkywDuXhmkaHZcq = UjalQWhdiZeUFTfVHLYPzbrLtqZ;
								yBStqblSrwgsWwUviwqvxWFGUDU2.ByyGWmDgpIFJaAabWjaMBssRpcWh = WavyIscbOethGrCUZxLqsEtHClj;
								num = 41199002;
								continue;
							case 5:
								yBStqblSrwgsWwUviwqvxWFGUDU2.XoQvEtmGuEoQzAIlaNmgxPliHTu = UQPnpLguhtCEkQPRaxuaPxhrRag;
								num = 41199004;
								continue;
							case 3:
								goto IL_008b;
							case 1:
								yBStqblSrwgsWwUviwqvxWFGUDU2 = this;
								num = 41199005;
								continue;
							default:
								return yBStqblSrwgsWwUviwqvxWFGUDU2;
							}
							break;
						}
						goto IL_0023;
						IL_008b:
						yBStqblSrwgsWwUviwqvxWFGUDU2 = new yBStqblSrwgsWwUviwqvxWFGUDU(0);
						yBStqblSrwgsWwUviwqvxWFGUDU2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = 41199005;
						goto IL_0028;
						IL_0023:
						num = 41199001;
						goto IL_0028;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							default:
								num = -1655599018;
								goto IL_001e;
							case 0:
								goto IL_0073;
							case 2:
								goto IL_01b3;
							case 1:
								break;
								IL_001e:
								while (true)
								{
									switch (num ^ -1655599019)
									{
									case 0:
										break;
									case 10:
										gswLLcFpHEbOZhixdlcSifqLoins++;
										num = -1655599012;
										continue;
									case 7:
										goto IL_0073;
									case 5:
										goto IL_00d1;
									case 8:
										PlZnXfJEaeRNYuUAhGsysdVCAMF();
										num = -1655599009;
										continue;
									case 11:
										IsGRKISgHIKBaFxrVRUegblNohn = dHYmAMgBYzbcwgvyTFvkGxXSUhWj[gswLLcFpHEbOZhixdlcSifqLoins].controllers.conflictChecking.ElementAssignmentConflicts(XoQvEtmGuEoQzAIlaNmgxPliHTu, RKQUCYjAXkOQEvYPFrRsAzEcuaK, nRQNgoCfnWFTgxkywDuXhmkaHZcq).GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = -1655599020;
										continue;
									case 9:
										goto IL_0150;
									case 3:
										num = -1655599023;
										continue;
									case 6:
										pJvaPjuiIiOGkwggNxIPuDjXdin = IsGRKISgHIKBaFxrVRUegblNohn.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = pJvaPjuiIiOGkwggNxIPuDjXdin;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										return true;
									case 2:
										goto IL_01b3;
									case 1:
										num = -1655599024;
										continue;
									default:
										goto end_IL_0008;
									}
									break;
									IL_0150:
									int num2;
									if (gswLLcFpHEbOZhixdlcSifqLoins >= dHYmAMgBYzbcwgvyTFvkGxXSUhWj.Count)
									{
										num = -1655599023;
										num2 = num;
									}
									else
									{
										num = -1655599010;
										num2 = num;
									}
									continue;
									IL_00d1:
									int num3;
									if (!IsGRKISgHIKBaFxrVRUegblNohn.MoveNext())
									{
										num = -1655599011;
										num3 = num;
									}
									else
									{
										num = -1655599021;
										num3 = num;
									}
								}
								goto default;
								IL_01b3:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -1655599024;
								goto IL_001e;
								IL_0073:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (XoQvEtmGuEoQzAIlaNmgxPliHTu.playerId < 0 || XoQvEtmGuEoQzAIlaNmgxPliHTu.elementAssignmentType != ElementAssignmentType.KeyboardKey)
								{
									break;
								}
								dHYmAMgBYzbcwgvyTFvkGxXSUhWj = (ByyGWmDgpIFJaAabWjaMBssRpcWh ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
								gswLLcFpHEbOZhixdlcSifqLoins = 0;
								num = -1655599012;
								goto IL_001e;
								end_IL_0008:
								break;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								PlZnXfJEaeRNYuUAhGsysdVCAMF();
							}
						}
					}

					[DebuggerHidden]
					public yBStqblSrwgsWwUviwqvxWFGUDU(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void PlZnXfJEaeRNYuUAhGsysdVCAMF()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (IsGRKISgHIKBaFxrVRUegblNohn != null)
						{
							IsGRKISgHIKBaFxrVRUegblNohn.Dispose();
						}
					}
				}

				private sealed class dKdQOqgamqOwOaCJvYEMnBKjDbD : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public int DERQvNdAIfJFDnFpDBYSBQlXxSHC;

					public int RApvxUwOMdwouTDjTDNwfqBnIsx;

					public MouseMap qNFaBYzMOwbyhpnMUsmMIjisSCI;

					public MouseMap KrkYqOetpPjDYDXCZHdEaxgYgG;

					public ActionElementMap WXybJffitOceMtNKISmGhCPIZdbW;

					public ActionElementMap CguHVgoqOaKWyWHagBJEhIvVPUP;

					public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

					public bool AsggrPyUWCnFFjkCeamlXvALxt;

					public bool nRQNgoCfnWFTgxkywDuXhmkaHZcq;

					public bool UjalQWhdiZeUFTfVHLYPzbrLtqZ;

					public bool ByyGWmDgpIFJaAabWjaMBssRpcWh;

					public bool WavyIscbOethGrCUZxLqsEtHClj;

					public IList<Player> JwcTUucMooaIwSaDUBqSxRypFVQ;

					public int txebEJWCGNjKcLedOIABcWxqFXf;

					public ElementAssignmentConflictInfo xvNrHSQwzDsGSaHMSQKAbqLHjjr;

					public ConflictCheckingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ElementAssignmentConflictInfo> qNIqoqAnvkUzJFoxQBAoDqghBjZ;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							goto IL_0029;
						}
						goto IL_00c7;
						IL_002e:
						int num;
						dKdQOqgamqOwOaCJvYEMnBKjDbD dKdQOqgamqOwOaCJvYEMnBKjDbD2 = default(dKdQOqgamqOwOaCJvYEMnBKjDbD);
						while (true)
						{
							switch (num ^ 0x6CFFF287)
							{
							case 2:
								break;
							case 1:
								dKdQOqgamqOwOaCJvYEMnBKjDbD2.DERQvNdAIfJFDnFpDBYSBQlXxSHC = RApvxUwOMdwouTDjTDNwfqBnIsx;
								dKdQOqgamqOwOaCJvYEMnBKjDbD2.qNFaBYzMOwbyhpnMUsmMIjisSCI = KrkYqOetpPjDYDXCZHdEaxgYgG;
								num = 1828713088;
								continue;
							case 3:
								dKdQOqgamqOwOaCJvYEMnBKjDbD2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
								num = 1828713094;
								continue;
							case 5:
								dKdQOqgamqOwOaCJvYEMnBKjDbD2 = this;
								num = 1828713095;
								continue;
							case 7:
								dKdQOqgamqOwOaCJvYEMnBKjDbD2.WXybJffitOceMtNKISmGhCPIZdbW = CguHVgoqOaKWyWHagBJEhIvVPUP;
								dKdQOqgamqOwOaCJvYEMnBKjDbD2.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
								dKdQOqgamqOwOaCJvYEMnBKjDbD2.nRQNgoCfnWFTgxkywDuXhmkaHZcq = UjalQWhdiZeUFTfVHLYPzbrLtqZ;
								num = 1828713089;
								continue;
							case 4:
								goto IL_00c7;
							case 0:
								num = 1828713094;
								continue;
							default:
								dKdQOqgamqOwOaCJvYEMnBKjDbD2.ByyGWmDgpIFJaAabWjaMBssRpcWh = WavyIscbOethGrCUZxLqsEtHClj;
								return dKdQOqgamqOwOaCJvYEMnBKjDbD2;
							}
							break;
						}
						goto IL_0029;
						IL_00c7:
						dKdQOqgamqOwOaCJvYEMnBKjDbD2 = new dKdQOqgamqOwOaCJvYEMnBKjDbD(0);
						num = 1828713092;
						goto IL_002e;
						IL_0029:
						num = 1828713090;
						goto IL_002e;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						bool result = default(bool);
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 2:
								goto IL_0074;
							case 0:
								goto IL_014e;
							default:
								goto IL_019b;
								IL_0074:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 1610365729;
								goto IL_0023;
								IL_0023:
								while (true)
								{
									switch (num ^ 0x5FFC3B20)
									{
									case 2:
										num = 1610365734;
										continue;
									case 9:
										txebEJWCGNjKcLedOIABcWxqFXf++;
										num = 1610365728;
										continue;
									case 10:
										goto IL_0074;
									case 1:
										if (!qNIqoqAnvkUzJFoxQBAoDqghBjZ.MoveNext())
										{
											kiYHnYTFaqqQjEGVlZnKRcEZLUl();
											num = 1610365737;
											continue;
										}
										goto case 4;
									case 3:
										qNIqoqAnvkUzJFoxQBAoDqghBjZ = JwcTUucMooaIwSaDUBqSxRypFVQ[txebEJWCGNjKcLedOIABcWxqFXf].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Mouse, 0, qNFaBYzMOwbyhpnMUsmMIjisSCI, WXybJffitOceMtNKISmGhCPIZdbW, RKQUCYjAXkOQEvYPFrRsAzEcuaK, nRQNgoCfnWFTgxkywDuXhmkaHZcq).GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = 1610365736;
										continue;
									case 4:
										xvNrHSQwzDsGSaHMSQKAbqLHjjr = qNIqoqAnvkUzJFoxQBAoDqghBjZ.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = xvNrHSQwzDsGSaHMSQKAbqLHjjr;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										result = true;
										break;
									case 0:
										goto IL_0127;
									case 6:
										goto IL_014e;
									case 7:
										goto IL_019b;
									case 8:
										num = 1610365729;
										continue;
									case 5:
										break;
									}
									break;
									IL_0127:
									int num2;
									if (txebEJWCGNjKcLedOIABcWxqFXf < JwcTUucMooaIwSaDUBqSxRypFVQ.Count)
									{
										num = 1610365731;
										num2 = num;
									}
									else
									{
										num = 1610365735;
										num2 = num;
									}
								}
								break;
								IL_014e:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (DERQvNdAIfJFDnFpDBYSBQlXxSHC >= 0 && WXybJffitOceMtNKISmGhCPIZdbW != null)
								{
									JwcTUucMooaIwSaDUBqSxRypFVQ = (ByyGWmDgpIFJaAabWjaMBssRpcWh ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
									txebEJWCGNjKcLedOIABcWxqFXf = 0;
									num = 1610365728;
									goto IL_0023;
								}
								goto IL_019b;
								IL_019b:
								result = false;
								num = 1610365733;
								goto IL_0023;
							}
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
						return result;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								kiYHnYTFaqqQjEGVlZnKRcEZLUl();
							}
						}
					}

					[DebuggerHidden]
					public dKdQOqgamqOwOaCJvYEMnBKjDbD(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void kiYHnYTFaqqQjEGVlZnKRcEZLUl()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (qNIqoqAnvkUzJFoxQBAoDqghBjZ != null)
						{
							qNIqoqAnvkUzJFoxQBAoDqghBjZ.Dispose();
						}
					}
				}

				private sealed class CHCALcbgzvgbcxwTNbBblZsGWmr : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public ElementAssignmentConflictCheck XoQvEtmGuEoQzAIlaNmgxPliHTu;

					public ElementAssignmentConflictCheck UQPnpLguhtCEkQPRaxuaPxhrRag;

					public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

					public bool AsggrPyUWCnFFjkCeamlXvALxt;

					public bool nRQNgoCfnWFTgxkywDuXhmkaHZcq;

					public bool UjalQWhdiZeUFTfVHLYPzbrLtqZ;

					public bool ByyGWmDgpIFJaAabWjaMBssRpcWh;

					public bool WavyIscbOethGrCUZxLqsEtHClj;

					public IList<Player> rCpRQMiLbZklYHKNcfoXtWXGWQr;

					public int uvGPahhOkVkINtIXVeNXxoCMdDR;

					public ElementAssignmentConflictInfo EaKeWaHNSOVfhYSITDDXHZeBQHEr;

					public ConflictCheckingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ElementAssignmentConflictInfo> hDnFzHmSXypRTZTTfqVbuNEODne;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							goto IL_001c;
						}
						goto IL_0071;
						IL_0071:
						CHCALcbgzvgbcxwTNbBblZsGWmr cHCALcbgzvgbcxwTNbBblZsGWmr = new CHCALcbgzvgbcxwTNbBblZsGWmr(0);
						cHCALcbgzvgbcxwTNbBblZsGWmr.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						int num = 435604059;
						goto IL_0021;
						IL_001c:
						num = 435604062;
						goto IL_0021;
						IL_0021:
						while (true)
						{
							switch (num ^ 0x19F6CA5A)
							{
							case 2:
								break;
							case 4:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
								cHCALcbgzvgbcxwTNbBblZsGWmr = this;
								num = 435604059;
								continue;
							case 1:
								cHCALcbgzvgbcxwTNbBblZsGWmr.XoQvEtmGuEoQzAIlaNmgxPliHTu = UQPnpLguhtCEkQPRaxuaPxhrRag;
								cHCALcbgzvgbcxwTNbBblZsGWmr.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
								num = 435604057;
								continue;
							case 0:
								goto IL_0071;
							default:
								cHCALcbgzvgbcxwTNbBblZsGWmr.nRQNgoCfnWFTgxkywDuXhmkaHZcq = UjalQWhdiZeUFTfVHLYPzbrLtqZ;
								cHCALcbgzvgbcxwTNbBblZsGWmr.ByyGWmDgpIFJaAabWjaMBssRpcWh = WavyIscbOethGrCUZxLqsEtHClj;
								return cHCALcbgzvgbcxwTNbBblZsGWmr;
							}
							break;
						}
						goto IL_001c;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 2:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -1285835846;
								goto IL_0023;
							case 0:
								goto IL_0141;
								IL_0023:
								while (true)
								{
									switch (num ^ -1285835842)
									{
									case 2:
										num = -1285835841;
										continue;
									case 6:
										break;
									case 7:
										hDnFzHmSXypRTZTTfqVbuNEODne = rCpRQMiLbZklYHKNcfoXtWXGWQr[uvGPahhOkVkINtIXVeNXxoCMdDR].controllers.conflictChecking.ElementAssignmentConflicts(XoQvEtmGuEoQzAIlaNmgxPliHTu, RKQUCYjAXkOQEvYPFrRsAzEcuaK, nRQNgoCfnWFTgxkywDuXhmkaHZcq).GetEnumerator();
										num = -1285835850;
										continue;
									case 4:
										if (!hDnFzHmSXypRTZTTfqVbuNEODne.MoveNext())
										{
											uxIHECULmqEPksEMZKHuUkARcfb();
											uvGPahhOkVkINtIXVeNXxoCMdDR++;
											num = -1285835848;
											continue;
										}
										goto case 0;
									case 5:
										goto end_IL_0023;
									case 8:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = -1285835846;
										continue;
									case 0:
										EaKeWaHNSOVfhYSITDDXHZeBQHEr = hDnFzHmSXypRTZTTfqVbuNEODne.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = EaKeWaHNSOVfhYSITDDXHZeBQHEr;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										return true;
									case 1:
										goto IL_0141;
									default:
										goto end_IL_0008;
									}
									int num2;
									if (uvGPahhOkVkINtIXVeNXxoCMdDR < rCpRQMiLbZklYHKNcfoXtWXGWQr.Count)
									{
										num = -1285835847;
										num2 = num;
									}
									else
									{
										num = -1285835843;
										num2 = num;
									}
									continue;
									end_IL_0023:
									break;
								}
								goto case 2;
								IL_0141:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (XoQvEtmGuEoQzAIlaNmgxPliHTu.playerId < 0 || XoQvEtmGuEoQzAIlaNmgxPliHTu.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									break;
								}
								rCpRQMiLbZklYHKNcfoXtWXGWQr = (ByyGWmDgpIFJaAabWjaMBssRpcWh ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
								uvGPahhOkVkINtIXVeNXxoCMdDR = 0;
								num = -1285835848;
								goto IL_0023;
								end_IL_0008:
								break;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
						while (true)
						{
							int num = -1215528653;
							while (true)
							{
								switch (num ^ -1215528654)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
									{
									case 1:
									case 2:
										try
										{
											return;
										}
										finally
										{
											uxIHECULmqEPksEMZKHuUkARcfb();
										}
									}
									goto IL_0035;
								case 2:
									return;
								}
								break;
								IL_0035:
								num = -1215528656;
							}
						}
					}

					[DebuggerHidden]
					public CHCALcbgzvgbcxwTNbBblZsGWmr(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void uxIHECULmqEPksEMZKHuUkARcfb()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						while (true)
						{
							int num = -1060839541;
							while (true)
							{
								switch (num ^ -1060839542)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									if (hDnFzHmSXypRTZTTfqVbuNEODne != null)
									{
										goto IL_002d;
									}
									return;
								case 2:
									return;
								}
								break;
								IL_002d:
								hDnFzHmSXypRTZTTfqVbuNEODne.Dispose();
								num = -1060839544;
							}
						}
					}
				}

				private sealed class ALnGrBAPmkdCUiLQAzqklfpeQFOP : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public int DERQvNdAIfJFDnFpDBYSBQlXxSHC;

					public int RApvxUwOMdwouTDjTDNwfqBnIsx;

					public int rxdjJqJqAJRgVnTJDSuuQBAmCyL;

					public int qWJPVxPfcLerRJqSvJoChuSerNNP;

					public CustomControllerMap MWMPQzvVUHbAmEZLWRpwQNBApJp;

					public CustomControllerMap rDfrnDJpzsajxvNACgcLmjIfOHZ;

					public ActionElementMap WXybJffitOceMtNKISmGhCPIZdbW;

					public ActionElementMap CguHVgoqOaKWyWHagBJEhIvVPUP;

					public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

					public bool AsggrPyUWCnFFjkCeamlXvALxt;

					public bool nRQNgoCfnWFTgxkywDuXhmkaHZcq;

					public bool UjalQWhdiZeUFTfVHLYPzbrLtqZ;

					public bool ByyGWmDgpIFJaAabWjaMBssRpcWh;

					public bool WavyIscbOethGrCUZxLqsEtHClj;

					public IList<Player> KYLptuEJPxULzimvLKirjluJBkhA;

					public int mDWHRZiwCSDVPddYWRcHEMMIwCsF;

					public ElementAssignmentConflictInfo mEuXLkAvlJLxuOeOwctrDcZMog;

					public ConflictCheckingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ElementAssignmentConflictInfo> QZhRXEjXAYSgcHLMiWFsNJduNCj;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						ALnGrBAPmkdCUiLQAzqklfpeQFOP aLnGrBAPmkdCUiLQAzqklfpeQFOP;
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							aLnGrBAPmkdCUiLQAzqklfpeQFOP = this;
							goto IL_0025;
						}
						goto IL_0075;
						IL_002a:
						int num;
						while (true)
						{
							switch (num ^ -1196430846)
							{
							case 4:
								break;
							case 2:
								aLnGrBAPmkdCUiLQAzqklfpeQFOP.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
								aLnGrBAPmkdCUiLQAzqklfpeQFOP.nRQNgoCfnWFTgxkywDuXhmkaHZcq = UjalQWhdiZeUFTfVHLYPzbrLtqZ;
								num = -1196430841;
								continue;
							case 3:
								goto IL_0075;
							case 0:
								aLnGrBAPmkdCUiLQAzqklfpeQFOP.MWMPQzvVUHbAmEZLWRpwQNBApJp = rDfrnDJpzsajxvNACgcLmjIfOHZ;
								aLnGrBAPmkdCUiLQAzqklfpeQFOP.WXybJffitOceMtNKISmGhCPIZdbW = CguHVgoqOaKWyWHagBJEhIvVPUP;
								num = -1196430848;
								continue;
							case 6:
								num = -1196430845;
								continue;
							case 1:
								aLnGrBAPmkdCUiLQAzqklfpeQFOP.DERQvNdAIfJFDnFpDBYSBQlXxSHC = RApvxUwOMdwouTDjTDNwfqBnIsx;
								aLnGrBAPmkdCUiLQAzqklfpeQFOP.rxdjJqJqAJRgVnTJDSuuQBAmCyL = qWJPVxPfcLerRJqSvJoChuSerNNP;
								num = -1196430846;
								continue;
							default:
								aLnGrBAPmkdCUiLQAzqklfpeQFOP.ByyGWmDgpIFJaAabWjaMBssRpcWh = WavyIscbOethGrCUZxLqsEtHClj;
								return aLnGrBAPmkdCUiLQAzqklfpeQFOP;
							}
							break;
						}
						goto IL_0025;
						IL_0075:
						aLnGrBAPmkdCUiLQAzqklfpeQFOP = new ALnGrBAPmkdCUiLQAzqklfpeQFOP(0);
						aLnGrBAPmkdCUiLQAzqklfpeQFOP.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = -1196430845;
						goto IL_002a;
						IL_0025:
						num = -1196430844;
						goto IL_002a;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						bool result = default(bool);
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 2:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -130993008;
								goto IL_0023;
							case 0:
								goto IL_016a;
								IL_0023:
								while (true)
								{
									switch (num ^ -130993006)
									{
									case 9:
										num = -130993005;
										continue;
									case 12:
										break;
									case 5:
										mDWHRZiwCSDVPddYWRcHEMMIwCsF = 0;
										num = -130993007;
										continue;
									case 3:
										goto IL_0083;
									case 2:
										goto IL_00aa;
									case 4:
										goto end_IL_0000;
									case 6:
										QZhRXEjXAYSgcHLMiWFsNJduNCj = KYLptuEJPxULzimvLKirjluJBkhA[mDWHRZiwCSDVPddYWRcHEMMIwCsF].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Custom, rxdjJqJqAJRgVnTJDSuuQBAmCyL, MWMPQzvVUHbAmEZLWRpwQNBApJp, WXybJffitOceMtNKISmGhCPIZdbW, RKQUCYjAXkOQEvYPFrRsAzEcuaK, nRQNgoCfnWFTgxkywDuXhmkaHZcq).GetEnumerator();
										num = -130992999;
										continue;
									case 8:
										result = true;
										num = -130993002;
										continue;
									case 11:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = -130993008;
										continue;
									case 0:
										BPhcSHAfAPdiWwoBApbsjhXSMCG();
										mDWHRZiwCSDVPddYWRcHEMMIwCsF++;
										num = -130993007;
										continue;
									case 1:
										goto IL_016a;
									case 10:
										mEuXLkAvlJLxuOeOwctrDcZMog = QZhRXEjXAYSgcHLMiWFsNJduNCj.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = mEuXLkAvlJLxuOeOwctrDcZMog;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										num = -130992998;
										continue;
									default:
										goto end_IL_0008;
									}
									break;
									IL_00aa:
									int num2;
									if (!QZhRXEjXAYSgcHLMiWFsNJduNCj.MoveNext())
									{
										num = -130993006;
										num2 = num;
									}
									else
									{
										num = -130993000;
										num2 = num;
									}
									continue;
									IL_0083:
									int num3;
									if (mDWHRZiwCSDVPddYWRcHEMMIwCsF >= KYLptuEJPxULzimvLKirjluJBkhA.Count)
									{
										num = -130993003;
										num3 = num;
									}
									else
									{
										num = -130993004;
										num3 = num;
									}
								}
								goto case 2;
								IL_016a:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (DERQvNdAIfJFDnFpDBYSBQlXxSHC < 0 || WXybJffitOceMtNKISmGhCPIZdbW == null)
								{
									break;
								}
								KYLptuEJPxULzimvLKirjluJBkhA = (ByyGWmDgpIFJaAabWjaMBssRpcWh ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
								num = -130993001;
								goto IL_0023;
								end_IL_0008:
								break;
							}
							result = false;
							end_IL_0000:;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
						return result;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								BPhcSHAfAPdiWwoBApbsjhXSMCG();
							}
						}
					}

					[DebuggerHidden]
					public ALnGrBAPmkdCUiLQAzqklfpeQFOP(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void BPhcSHAfAPdiWwoBApbsjhXSMCG()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (QZhRXEjXAYSgcHLMiWFsNJduNCj != null)
						{
							QZhRXEjXAYSgcHLMiWFsNJduNCj.Dispose();
						}
					}
				}

				private sealed class HNqyAaeQnDLXErvbwknECgTaeCV : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public ElementAssignmentConflictCheck XoQvEtmGuEoQzAIlaNmgxPliHTu;

					public ElementAssignmentConflictCheck UQPnpLguhtCEkQPRaxuaPxhrRag;

					public bool RKQUCYjAXkOQEvYPFrRsAzEcuaK;

					public bool AsggrPyUWCnFFjkCeamlXvALxt;

					public bool nRQNgoCfnWFTgxkywDuXhmkaHZcq;

					public bool UjalQWhdiZeUFTfVHLYPzbrLtqZ;

					public bool ByyGWmDgpIFJaAabWjaMBssRpcWh;

					public bool WavyIscbOethGrCUZxLqsEtHClj;

					public IList<Player> ZykJOEXUfxDELbTUlKTTqRrMEDR;

					public int CuPCwSeYtMisaErPBGtFDJhRjbv;

					public ElementAssignmentConflictInfo KlVNxWktLTYhzCFBXyhOwaxtTzd;

					public ConflictCheckingHelper ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public IEnumerator<ElementAssignmentConflictInfo> SpJbBAEmdDvsZkxxePebpHSSXgsL;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RDkWcsTpvDaNZojjIZONnoEBXPC;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
						{
							goto IL_0012;
						}
						goto IL_005b;
						IL_0012:
						int num = -1492833281;
						goto IL_0017;
						IL_0017:
						HNqyAaeQnDLXErvbwknECgTaeCV hNqyAaeQnDLXErvbwknECgTaeCV = default(HNqyAaeQnDLXErvbwknECgTaeCV);
						while (true)
						{
							switch (num ^ -1492833283)
							{
							case 0:
								break;
							case 3:
								hNqyAaeQnDLXErvbwknECgTaeCV = this;
								num = -1492833288;
								continue;
							case 5:
								num = -1492833286;
								continue;
							case 4:
								goto IL_005b;
							case 7:
								hNqyAaeQnDLXErvbwknECgTaeCV.XoQvEtmGuEoQzAIlaNmgxPliHTu = UQPnpLguhtCEkQPRaxuaPxhrRag;
								hNqyAaeQnDLXErvbwknECgTaeCV.RKQUCYjAXkOQEvYPFrRsAzEcuaK = AsggrPyUWCnFFjkCeamlXvALxt;
								num = -1492833284;
								continue;
							case 2:
								goto IL_0088;
							case 6:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
								num = -1492833282;
								continue;
							case 8:
								hNqyAaeQnDLXErvbwknECgTaeCV.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
								num = -1492833286;
								continue;
							default:
								hNqyAaeQnDLXErvbwknECgTaeCV.nRQNgoCfnWFTgxkywDuXhmkaHZcq = UjalQWhdiZeUFTfVHLYPzbrLtqZ;
								hNqyAaeQnDLXErvbwknECgTaeCV.ByyGWmDgpIFJaAabWjaMBssRpcWh = WavyIscbOethGrCUZxLqsEtHClj;
								return hNqyAaeQnDLXErvbwknECgTaeCV;
							}
							break;
							IL_0088:
							int num2;
							if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
							{
								num = -1492833285;
								num2 = num;
							}
							else
							{
								num = -1492833287;
								num2 = num;
							}
						}
						goto IL_0012;
						IL_005b:
						hNqyAaeQnDLXErvbwknECgTaeCV = new HNqyAaeQnDLXErvbwknECgTaeCV(0);
						num = -1492833291;
						goto IL_0017;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
							while (true)
							{
								int num = -865563102;
								while (true)
								{
									int num3;
									switch (num ^ -865563101)
									{
									case 10:
										break;
									case 2:
										return true;
									case 12:
										num = -865563097;
										continue;
									case 6:
										CuPCwSeYtMisaErPBGtFDJhRjbv++;
										num = -865563100;
										continue;
									case 0:
										if (XoQvEtmGuEoQzAIlaNmgxPliHTu.elementAssignmentType != ElementAssignmentType.KeyboardKey)
										{
											ZykJOEXUfxDELbTUlKTTqRrMEDR = (ByyGWmDgpIFJaAabWjaMBssRpcWh ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
											CuPCwSeYtMisaErPBGtFDJhRjbv = 0;
											num = -865563100;
											continue;
										}
										goto IL_01d6;
									case 11:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = -865563098;
										continue;
									case 9:
										goto IL_00d1;
									case 3:
										SpJbBAEmdDvsZkxxePebpHSSXgsL = ZykJOEXUfxDELbTUlKTTqRrMEDR[CuPCwSeYtMisaErPBGtFDJhRjbv].controllers.conflictChecking.ElementAssignmentConflicts(XoQvEtmGuEoQzAIlaNmgxPliHTu, RKQUCYjAXkOQEvYPFrRsAzEcuaK, nRQNgoCfnWFTgxkywDuXhmkaHZcq).GetEnumerator();
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										num = -865563098;
										continue;
									case 8:
										KlVNxWktLTYhzCFBXyhOwaxtTzd = SpJbBAEmdDvsZkxxePebpHSSXgsL.Current;
										RDkWcsTpvDaNZojjIZONnoEBXPC = KlVNxWktLTYhzCFBXyhOwaxtTzd;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										num = -865563103;
										continue;
									case 5:
										if (!SpJbBAEmdDvsZkxxePebpHSSXgsL.MoveNext())
										{
											btrKBUiuYPSDPwkIPVqwgCbaMOf();
											num = -865563099;
											continue;
										}
										goto case 8;
									case 1:
										switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
										{
										case 2:
											break;
										case 0:
											goto IL_00d1;
										default:
											goto IL_01a5;
										case 1:
											goto IL_01d6;
										}
										goto case 11;
									case 7:
									{
										int num2;
										if (CuPCwSeYtMisaErPBGtFDJhRjbv >= ZykJOEXUfxDELbTUlKTTqRrMEDR.Count)
										{
											num = -865563097;
											num2 = num;
										}
										else
										{
											num = -865563104;
											num2 = num;
										}
										continue;
									}
									default:
										goto IL_01d6;
										IL_01d6:
										return false;
										IL_01a5:
										num = -865563089;
										continue;
										IL_00d1:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
										if (XoQvEtmGuEoQzAIlaNmgxPliHTu.playerId >= 0)
										{
											num = -865563101;
											num3 = num;
										}
										else
										{
											num = -865563097;
											num3 = num;
										}
										continue;
									}
									break;
								}
							}
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								btrKBUiuYPSDPwkIPVqwgCbaMOf();
							}
						}
					}

					[DebuggerHidden]
					public HNqyAaeQnDLXErvbwknECgTaeCV(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void btrKBUiuYPSDPwkIPVqwgCbaMOf()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						while (true)
						{
							int num = -477026789;
							while (true)
							{
								switch (num ^ -477026790)
								{
								case 2:
									break;
								default:
									return;
								case 1:
									if (SpJbBAEmdDvsZkxxePebpHSSXgsL != null)
									{
										goto IL_002d;
									}
									return;
								case 0:
									return;
								}
								break;
								IL_002d:
								SpJbBAEmdDvsZkxxePebpHSSXgsL.Dispose();
								num = -477026790;
							}
						}
					}
				}

				private static ConflictCheckingHelper VLHBdfuObcdunicAbIHFTExpsoBB;

				internal static ConflictCheckingHelper Instance
				{
					get
					{
						return VLHBdfuObcdunicAbIHFTExpsoBB ?? (VLHBdfuObcdunicAbIHFTExpsoBB = new ConflictCheckingHelper());
					}
				}

				private ConflictCheckingHelper()
				{
				}

				public bool DoesAnyElementAssignmentConflict()
				{
					return DoesAnyElementAssignmentConflict(false, false, true);
				}

				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps)
				{
					return DoesAnyElementAssignmentConflict(skipDisabledMaps, false, true);
				}

				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DoesAnyElementAssignmentConflict(skipDisabledMaps, forceCheckAllCategories, true);
				}

				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						goto IL_000a;
					}
					IList<Player> list;
					if (includeSystemPlayer)
					{
						list = lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly;
						goto IL_02f1;
					}
					int num = 1526188034;
					goto IL_000f;
					IL_000f:
					int num4 = default(int);
					int count3 = default(int);
					IList<JoystickMap> maps4 = default(IList<JoystickMap>);
					int num6 = default(int);
					int num8 = default(int);
					int num7 = default(int);
					Player player3 = default(Player);
					IList<Player> list2 = default(IList<Player>);
					int num12 = default(int);
					int num10 = default(int);
					int num14 = default(int);
					IList<MouseMap> maps3 = default(IList<MouseMap>);
					IList<CustomController> customControllers = default(IList<CustomController>);
					Player player2 = default(Player);
					CustomController customController = default(CustomController);
					IList<CustomControllerMap> maps = default(IList<CustomControllerMap>);
					int num11 = default(int);
					int num5 = default(int);
					int num9 = default(int);
					int count2 = default(int);
					Player player4 = default(Player);
					int num3 = default(int);
					IList<Joystick> joysticks = default(IList<Joystick>);
					IList<KeyboardMap> maps2 = default(IList<KeyboardMap>);
					int count = default(int);
					Player player = default(Player);
					Joystick joystick = default(Joystick);
					int num2 = default(int);
					while (true)
					{
						int num13;
						switch (num ^ 0x5AF7C805)
						{
						case 40:
							break;
						case 16:
							num = 1526188066;
							continue;
						case 41:
							goto IL_00d9;
						case 12:
							num4++;
							num = 1526188044;
							continue;
						case 2:
							count3 = maps4.Count;
							num6 = num8;
							num = 1526188061;
							continue;
						case 26:
							if (num7 >= count3)
							{
								num6++;
								num = 1526188061;
								continue;
							}
							goto IL_012e;
						case 36:
							goto IL_012e;
						case 38:
							player3 = list2[num12];
							num = 1526188037;
							continue;
						case 18:
							num10++;
							num = 1526188047;
							continue;
						case 34:
							goto IL_018a;
						case 39:
							if (num14 >= maps3.Count)
							{
								customControllers = player2.controllers.CustomControllers;
								num4 = 0;
								num = 1526188056;
								continue;
							}
							goto case 27;
						case 8:
							num12 = num8;
							num = 1526188052;
							continue;
						case 30:
							customController = customControllers[num4];
							maps = player2.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
							num = 1526188033;
							continue;
						case 13:
							num11++;
							num = 1526188057;
							continue;
						case 3:
							goto IL_0217;
						case 20:
							player2 = list2[num5];
							if (!forceCheckAllCategories)
							{
								num = 1526188036;
								continue;
							}
							num13 = num5;
							goto IL_029c;
						case 19:
							if (num9 >= count2)
							{
								num14++;
								num = 1526188066;
								continue;
							}
							goto IL_04c5;
						case 24:
							goto IL_025e;
						case 25:
							player4 = list2[num3];
							num = 1526188043;
							continue;
						case 35:
							num14 = 0;
							num = 1526188053;
							continue;
						case 1:
							num13 = 0;
							goto IL_029c;
						case 32:
							goto IL_02a8;
						case 5:
							joysticks = player2.controllers.Joysticks;
							num10 = 0;
							num = 1526188035;
							continue;
						case 7:
							goto IL_02db;
						case 28:
							if (num11 >= maps2.Count)
							{
								maps3 = player2.controllers.maps.GetMaps<MouseMap>(0);
								num = 1526188070;
								continue;
							}
							goto case 8;
						case 21:
							num = 1526188063;
							continue;
						case 10:
							if (num10 >= joysticks.Count)
							{
								maps2 = player2.controllers.maps.GetMaps<KeyboardMap>(0);
								num11 = 0;
								num = 1526188057;
								continue;
							}
							goto case 11;
						case 42:
							return true;
						case 15:
							goto IL_037a;
						case 4:
							if (maps != null)
							{
								count = maps.Count;
								num3 = num8;
								num = 1526188071;
								continue;
							}
							goto case 12;
						case 22:
							goto IL_03c9;
						case 33:
							player = list2[num6];
							num7 = 0;
							num = 1526188048;
							continue;
						case 9:
							if (num4 >= customControllers.Count)
							{
								num5++;
								num = 1526188076;
								continue;
							}
							goto case 30;
						case 31:
							num3++;
							num = 1526188071;
							continue;
						case 0:
							goto IL_0445;
						case 6:
							num = 1526188047;
							continue;
						case 17:
							num = 1526188069;
							continue;
						case 29:
							num = 1526188044;
							continue;
						case 23:
							return false;
						case 27:
							num9 = num8;
							num = 1526188054;
							continue;
						case 11:
							joystick = joysticks[num10];
							num = 1526188042;
							continue;
						case 37:
							goto IL_04c5;
						case 14:
							num2 = 0;
							num = 1526188038;
							continue;
						default:
							{
								return false;
							}
							IL_029c:
							num8 = num13;
							num = 1526188032;
							continue;
						}
						break;
						IL_0445:
						if (!player3.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, maps2[num11], skipDisabledMaps, forceCheckAllCategories))
						{
							num12++;
							num = 1526188069;
						}
						else
						{
							num = 1526188079;
						}
						continue;
						IL_025e:
						int num15;
						if (num6 >= count2)
						{
							num = 1526188055;
							num15 = num;
						}
						else
						{
							num = 1526188068;
							num15 = num;
						}
						continue;
						IL_00d9:
						int num16;
						if (num5 >= count2)
						{
							num = 1526188078;
							num16 = num;
						}
						else
						{
							num = 1526188049;
							num16 = num;
						}
						continue;
						IL_03c9:
						if (player4.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, customController.id, maps[num2], skipDisabledMaps, forceCheckAllCategories))
						{
							return true;
						}
						num2++;
						num = 1526188038;
						continue;
						IL_018a:
						int num17;
						if (num3 < count2)
						{
							num = 1526188060;
							num17 = num;
						}
						else
						{
							num = 1526188041;
							num17 = num;
						}
						continue;
						IL_04c5:
						Player player5 = list2[num9];
						if (player5.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, maps3[num14], skipDisabledMaps, forceCheckAllCategories))
						{
							return true;
						}
						num9++;
						num = 1526188054;
						continue;
						IL_037a:
						maps4 = player2.controllers.maps.GetMaps<JoystickMap>(joystick.id);
						int num18;
						if (maps4 == null)
						{
							num = 1526188055;
							num18 = num;
						}
						else
						{
							num = 1526188039;
							num18 = num;
						}
						continue;
						IL_0217:
						int num19;
						if (num2 < count)
						{
							num = 1526188051;
							num19 = num;
						}
						else
						{
							num = 1526188058;
							num19 = num;
						}
						continue;
						IL_012e:
						if (player.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, joystick.id, maps4[num7], skipDisabledMaps, forceCheckAllCategories))
						{
							return true;
						}
						num7++;
						num = 1526188063;
						continue;
						IL_02a8:
						int num20;
						if (num12 < count2)
						{
							num = 1526188067;
							num20 = num;
						}
						else
						{
							num = 1526188040;
							num20 = num;
						}
					}
					goto IL_000a;
					IL_02f1:
					list2 = list;
					count2 = list2.Count;
					num5 = 0;
					num = 1526188076;
					goto IL_000f;
					IL_02db:
					list = lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly;
					goto IL_02f1;
					IL_000a:
					num = 1526188050;
					goto IL_000f;
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, false, false, true);
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, false, true);
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, true);
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return false;
					}
					int num;
					if (playerId >= 0)
					{
						if (elementMap == null)
						{
							goto IL_0011;
						}
						if (controllerType == ControllerType.Joystick)
						{
							return yKNDwcdoVrCKSGInfvKuweCajvIa(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
						}
						if (controllerType == ControllerType.Keyboard)
						{
							return VlhEOwdeGQtCrhCSSgExRZcTXfUd(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
						}
						if (controllerType == ControllerType.Mouse)
						{
							num = 102083469;
							goto IL_0016;
						}
						if (controllerType == ControllerType.Custom)
						{
							return aGoNJyefwEykfyWrlREKEBRrgdnB(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
						}
						throw new NotImplementedException();
					}
					goto IL_002f;
					IL_002f:
					return false;
					IL_0016:
					switch (num ^ 0x615AB8D)
					{
					case 2:
						break;
					case 1:
						goto IL_002f;
					default:
						return RPOujozYRwnmJUZWYHICISLhEpn(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					goto IL_0011;
					IL_0011:
					num = 102083468;
					goto IL_0016;
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
				{
					return DoesElementAssignmentConflict(conflictCheck, false, false, true);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, false, true);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, forceCheckAllCategories, true);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (conflictCheck.playerId < 0)
					{
						return false;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return yKNDwcdoVrCKSGInfvKuweCajvIa(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return VlhEOwdeGQtCrhCSSgExRZcTXfUd(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return RPOujozYRwnmJUZWYHICISLhEpn(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return aGoNJyefwEykfyWrlREKEBRrgdnB(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private bool yKNDwcdoVrCKSGInfvKuweCajvIa(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num;
					if (P_0 >= 0)
					{
						if (P_3 == null)
						{
							goto IL_0008;
						}
						list = (P_6 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
						num = 670738282;
						goto IL_000d;
					}
					goto IL_002e;
					IL_000d:
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0x27FAA769)
						{
						case 0:
							break;
						case 2:
							goto IL_002e;
						case 3:
							num2 = 0;
							num = 670738285;
							continue;
						case 1:
							goto IL_005b;
						default:
							if (num2 >= list.Count)
							{
								return false;
							}
							goto IL_005b;
						}
						break;
						IL_005b:
						if (list[num2].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
						num2++;
						num = 670738285;
					}
					goto IL_0008;
					IL_0008:
					num = 670738283;
					goto IL_000d;
					IL_002e:
					return false;
				}

				private bool yKNDwcdoVrCKSGInfvKuweCajvIa(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num = default(int);
					int num2;
					if (P_0.playerId >= 0)
					{
						if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
						{
							goto IL_0014;
						}
						list = (P_3 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
						num = 0;
						num2 = -663268826;
						goto IL_0019;
					}
					goto IL_003a;
					IL_0019:
					while (true)
					{
						switch (num2 ^ -663268828)
						{
						case 0:
							break;
						case 4:
							goto IL_003a;
						case 3:
							goto IL_0060;
						case 2:
							num2 = -663268827;
							continue;
						default:
							if (num >= list.Count)
							{
								return false;
							}
							goto IL_0060;
						}
						break;
						IL_0060:
						if (list[num].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
						num++;
						num2 = -663268827;
					}
					goto IL_0014;
					IL_0014:
					num2 = -663268832;
					goto IL_0019;
					IL_003a:
					return false;
				}

				private bool VlhEOwdeGQtCrhCSSgExRZcTXfUd(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					IList<Player> list;
					int num;
					if (P_0 >= 0)
					{
						if (P_2 == null)
						{
							goto IL_000d;
						}
						if (P_5)
						{
							list = lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly;
							goto IL_008e;
						}
						num = 1583998439;
						goto IL_0012;
					}
					goto IL_0099;
					IL_0012:
					int num2 = default(int);
					IList<Player> list2 = default(IList<Player>);
					while (true)
					{
						switch (num ^ 0x5E69E5E3)
						{
						case 0:
							break;
						case 5:
							goto IL_003b;
						case 2:
							num = 1583998437;
							continue;
						case 1:
							num2 = 0;
							num = 1583998433;
							continue;
						case 4:
							goto IL_0078;
						case 3:
							goto IL_0099;
						default:
							if (num2 >= list2.Count)
							{
								return false;
							}
							goto IL_003b;
						}
						break;
						IL_003b:
						if (list2[num2].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
						num2++;
						num = 1583998437;
					}
					goto IL_000d;
					IL_0078:
					list = lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly;
					goto IL_008e;
					IL_0099:
					return false;
					IL_008e:
					list2 = list;
					num = 1583998434;
					goto IL_0012;
					IL_000d:
					num = 1583998432;
					goto IL_0012;
				}

				private bool VlhEOwdeGQtCrhCSSgExRZcTXfUd(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId >= 0)
					{
						int num2 = default(int);
						IList<Player> list = default(IList<Player>);
						while (true)
						{
							int num = -552242473;
							while (true)
							{
								switch (num ^ -552242477)
								{
								case 5:
									break;
								case 4:
									goto IL_0038;
								case 6:
									goto end_IL_000a;
								case 0:
									return true;
								case 1:
									num = -552242480;
									continue;
								case 2:
									goto IL_0083;
								default:
									if (num2 >= list.Count)
									{
										return false;
									}
									goto IL_0083;
								}
								break;
								IL_0083:
								if (!list[num2].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
								{
									num2++;
									num = -552242480;
								}
								else
								{
									num = -552242477;
								}
								continue;
								IL_0038:
								if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
								{
									num = -552242475;
									continue;
								}
								list = (P_3 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
								num2 = 0;
								num = -552242478;
							}
							continue;
							end_IL_000a:
							break;
						}
					}
					return false;
				}

				private bool RPOujozYRwnmJUZWYHICISLhEpn(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num = default(int);
					int num2;
					if (P_0 >= 0)
					{
						if (P_2 == null)
						{
							goto IL_0007;
						}
						list = (P_5 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
						num = 0;
						num2 = -981554955;
						goto IL_000c;
					}
					goto IL_002d;
					IL_000c:
					while (true)
					{
						switch (num2 ^ -981554954)
						{
						case 0:
							break;
						case 4:
							goto IL_002d;
						case 2:
							goto IL_0053;
						case 1:
							return true;
						default:
							if (num >= list.Count)
							{
								return false;
							}
							goto IL_0053;
						}
						break;
						IL_0053:
						if (list[num].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4))
						{
							num2 = -981554953;
							continue;
						}
						num++;
						num2 = -981554955;
					}
					goto IL_0007;
					IL_0007:
					num2 = -981554958;
					goto IL_000c;
					IL_002d:
					return false;
				}

				private bool RPOujozYRwnmJUZWYHICISLhEpn(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId >= 0)
					{
						int num2 = default(int);
						IList<Player> list = default(IList<Player>);
						while (true)
						{
							int num = 1874294849;
							while (true)
							{
								switch (num ^ 0x6FB77840)
								{
								case 5:
									break;
								case 3:
									goto IL_0038;
								case 0:
									goto end_IL_000a;
								case 2:
									num = 1874294852;
									continue;
								case 1:
									goto IL_0087;
								case 6:
									return true;
								default:
									if (num2 >= list.Count)
									{
										return false;
									}
									goto IL_0038;
								}
								break;
								IL_0087:
								if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
								{
									list = (P_3 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
									num2 = 0;
									num = 1874294850;
								}
								else
								{
									num = 1874294848;
								}
								continue;
								IL_0038:
								if (list[num2].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
								{
									num = 1874294854;
									continue;
								}
								num2++;
								num = 1874294852;
							}
							continue;
							end_IL_000a:
							break;
						}
					}
					return false;
				}

				private bool aGoNJyefwEykfyWrlREKEBRrgdnB(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 >= 0)
					{
						int num2 = default(int);
						IList<Player> list = default(IList<Player>);
						while (true)
						{
							int num = -910703780;
							while (true)
							{
								switch (num ^ -910703784)
								{
								case 5:
									break;
								case 4:
									goto IL_002e;
								case 0:
									goto end_IL_0004;
								case 3:
									goto IL_005d;
								case 1:
									num2 = 0;
									num = -910703782;
									continue;
								default:
									if (num2 >= list.Count)
									{
										return false;
									}
									goto IL_005d;
								}
								break;
								IL_005d:
								if (list[num2].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5))
								{
									return true;
								}
								num2++;
								num = -910703782;
								continue;
								IL_002e:
								if (P_3 == null)
								{
									num = -910703784;
									continue;
								}
								list = (P_6 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
								num = -910703783;
							}
							continue;
							end_IL_0004:
							break;
						}
					}
					return false;
				}

				private bool aGoNJyefwEykfyWrlREKEBRrgdnB(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num = default(int);
					int num2;
					if (P_0.playerId >= 0)
					{
						if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
						{
							goto IL_0014;
						}
						list = (P_3 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
						num = 0;
						num2 = 1890989986;
						goto IL_0019;
					}
					goto IL_0036;
					IL_0019:
					while (true)
					{
						switch (num2 ^ 0x70B637A1)
						{
						case 2:
							break;
						case 1:
							goto IL_0036;
						case 0:
							goto IL_005c;
						default:
							if (num >= list.Count)
							{
								return false;
							}
							goto IL_005c;
						}
						break;
						IL_005c:
						if (list[num].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
						num++;
						num2 = 1890989986;
					}
					goto IL_0014;
					IL_0014:
					num2 = 1890989984;
					goto IL_0019;
					IL_0036:
					return false;
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, false, false, true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, false, true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					int num;
					if (playerId >= 0)
					{
						if (elementMap == null)
						{
							num = -1062780746;
						}
						else
						{
							if (controllerType != ControllerType.Joystick)
							{
								switch (controllerType)
								{
								case ControllerType.Keyboard:
									return AiWeebqbWpMFntdyEGDzbqJTivoC(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								case ControllerType.Mouse:
									return roydyyJqNkzSPogcGtsQswBEjGe(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								case ControllerType.Custom:
									return WnmEVefrkmktweWHaKFBaZrwiLMT(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								default:
									throw new NotImplementedException();
								}
							}
							num = -1062780747;
						}
						goto IL_000c;
					}
					goto IL_003e;
					IL_000c:
					switch (num ^ -1062780747)
					{
					case 2:
						break;
					case 1:
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					case 3:
						goto IL_003e;
					default:
						return rDxBZNrpEXYGYghjFeCjFUlVdsd(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					goto IL_0007;
					IL_003e:
					return new List<ElementAssignmentConflictInfo>();
					IL_0007:
					num = -1062780748;
					goto IL_000c;
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return ElementAssignmentConflicts(conflictCheck, false, false, true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, false, true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (conflictCheck.playerId < 0)
					{
						goto IL_0017;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return rDxBZNrpEXYGYghjFeCjFUlVdsd(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					int num;
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						num = 1255181560;
						goto IL_001c;
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return roydyyJqNkzSPogcGtsQswBEjGe(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return WnmEVefrkmktweWHaKFBaZrwiLMT(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
					IL_001c:
					switch (num ^ 0x4AD08CF8)
					{
					case 2:
						break;
					case 1:
						return new List<ElementAssignmentConflictInfo>();
					default:
						return AiWeebqbWpMFntdyEGDzbqJTivoC(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					goto IL_0017;
					IL_0017:
					num = 1255181561;
					goto IL_001c;
				}

				private IEnumerable<ElementAssignmentConflictInfo> rDxBZNrpEXYGYghjFeCjFUlVdsd(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					NBNhWeqxLxStXSolAdBCcZJTuxD nBNhWeqxLxStXSolAdBCcZJTuxD = new NBNhWeqxLxStXSolAdBCcZJTuxD(-2);
					nBNhWeqxLxStXSolAdBCcZJTuxD.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					while (true)
					{
						int num = -936383288;
						while (true)
						{
							switch (num ^ -936383287)
							{
							case 4:
								break;
							case 1:
								nBNhWeqxLxStXSolAdBCcZJTuxD.RApvxUwOMdwouTDjTDNwfqBnIsx = P_0;
								num = -936383284;
								continue;
							case 0:
								nBNhWeqxLxStXSolAdBCcZJTuxD.UjalQWhdiZeUFTfVHLYPzbrLtqZ = P_5;
								num = -936383286;
								continue;
							case 2:
								nBNhWeqxLxStXSolAdBCcZJTuxD.CguHVgoqOaKWyWHagBJEhIvVPUP = P_3;
								nBNhWeqxLxStXSolAdBCcZJTuxD.AsggrPyUWCnFFjkCeamlXvALxt = P_4;
								num = -936383287;
								continue;
							case 5:
								nBNhWeqxLxStXSolAdBCcZJTuxD.qWJPVxPfcLerRJqSvJoChuSerNNP = P_1;
								nBNhWeqxLxStXSolAdBCcZJTuxD.TCLAhQjtREcDqiIQiNqBdSSDhjiT = P_2;
								num = -936383285;
								continue;
							default:
								nBNhWeqxLxStXSolAdBCcZJTuxD.WavyIscbOethGrCUZxLqsEtHClj = P_6;
								return nBNhWeqxLxStXSolAdBCcZJTuxD;
							}
							break;
						}
					}
				}

				private IEnumerable<ElementAssignmentConflictInfo> rDxBZNrpEXYGYghjFeCjFUlVdsd(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					eEHbqPqyGtcfTAiunwoLZAhhqam eEHbqPqyGtcfTAiunwoLZAhhqam2 = new eEHbqPqyGtcfTAiunwoLZAhhqam(-2);
					eEHbqPqyGtcfTAiunwoLZAhhqam2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					eEHbqPqyGtcfTAiunwoLZAhhqam2.UQPnpLguhtCEkQPRaxuaPxhrRag = P_0;
					eEHbqPqyGtcfTAiunwoLZAhhqam2.AsggrPyUWCnFFjkCeamlXvALxt = P_1;
					eEHbqPqyGtcfTAiunwoLZAhhqam2.UjalQWhdiZeUFTfVHLYPzbrLtqZ = P_2;
					eEHbqPqyGtcfTAiunwoLZAhhqam2.WavyIscbOethGrCUZxLqsEtHClj = P_3;
					return eEHbqPqyGtcfTAiunwoLZAhhqam2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> AiWeebqbWpMFntdyEGDzbqJTivoC(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					PjJUpstKKvgcCqPNeiWfAqRATyt pjJUpstKKvgcCqPNeiWfAqRATyt = new PjJUpstKKvgcCqPNeiWfAqRATyt(-2);
					while (true)
					{
						int num = -319014657;
						while (true)
						{
							switch (num ^ -319014660)
							{
							case 2:
								break;
							case 3:
								pjJUpstKKvgcCqPNeiWfAqRATyt.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
								pjJUpstKKvgcCqPNeiWfAqRATyt.RApvxUwOMdwouTDjTDNwfqBnIsx = P_0;
								num = -319014660;
								continue;
							case 0:
								pjJUpstKKvgcCqPNeiWfAqRATyt.fGefznGryZGBacvzYFGYnYNltBEP = P_1;
								pjJUpstKKvgcCqPNeiWfAqRATyt.CguHVgoqOaKWyWHagBJEhIvVPUP = P_2;
								pjJUpstKKvgcCqPNeiWfAqRATyt.AsggrPyUWCnFFjkCeamlXvALxt = P_3;
								pjJUpstKKvgcCqPNeiWfAqRATyt.UjalQWhdiZeUFTfVHLYPzbrLtqZ = P_4;
								num = -319014659;
								continue;
							default:
								pjJUpstKKvgcCqPNeiWfAqRATyt.WavyIscbOethGrCUZxLqsEtHClj = P_5;
								return pjJUpstKKvgcCqPNeiWfAqRATyt;
							}
							break;
						}
					}
				}

				private IEnumerable<ElementAssignmentConflictInfo> AiWeebqbWpMFntdyEGDzbqJTivoC(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					yBStqblSrwgsWwUviwqvxWFGUDU yBStqblSrwgsWwUviwqvxWFGUDU2 = new yBStqblSrwgsWwUviwqvxWFGUDU(-2);
					while (true)
					{
						int num = 2394543;
						while (true)
						{
							switch (num ^ 0x2489AB)
							{
							case 0:
								break;
							case 2:
								yBStqblSrwgsWwUviwqvxWFGUDU2.UjalQWhdiZeUFTfVHLYPzbrLtqZ = P_2;
								num = 2394536;
								continue;
							case 1:
								yBStqblSrwgsWwUviwqvxWFGUDU2.UQPnpLguhtCEkQPRaxuaPxhrRag = P_0;
								yBStqblSrwgsWwUviwqvxWFGUDU2.AsggrPyUWCnFFjkCeamlXvALxt = P_1;
								num = 2394537;
								continue;
							case 4:
								yBStqblSrwgsWwUviwqvxWFGUDU2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
								num = 2394538;
								continue;
							default:
								yBStqblSrwgsWwUviwqvxWFGUDU2.WavyIscbOethGrCUZxLqsEtHClj = P_3;
								return yBStqblSrwgsWwUviwqvxWFGUDU2;
							}
							break;
						}
					}
				}

				private IEnumerable<ElementAssignmentConflictInfo> roydyyJqNkzSPogcGtsQswBEjGe(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					dKdQOqgamqOwOaCJvYEMnBKjDbD dKdQOqgamqOwOaCJvYEMnBKjDbD2 = new dKdQOqgamqOwOaCJvYEMnBKjDbD(-2);
					while (true)
					{
						int num = -1126685208;
						while (true)
						{
							switch (num ^ -1126685202)
							{
							case 3:
								break;
							case 1:
								dKdQOqgamqOwOaCJvYEMnBKjDbD2.AsggrPyUWCnFFjkCeamlXvALxt = P_3;
								dKdQOqgamqOwOaCJvYEMnBKjDbD2.UjalQWhdiZeUFTfVHLYPzbrLtqZ = P_4;
								num = -1126685206;
								continue;
							case 5:
								dKdQOqgamqOwOaCJvYEMnBKjDbD2.KrkYqOetpPjDYDXCZHdEaxgYgG = P_1;
								num = -1126685202;
								continue;
							case 6:
								dKdQOqgamqOwOaCJvYEMnBKjDbD2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
								dKdQOqgamqOwOaCJvYEMnBKjDbD2.RApvxUwOMdwouTDjTDNwfqBnIsx = P_0;
								num = -1126685205;
								continue;
							case 0:
								dKdQOqgamqOwOaCJvYEMnBKjDbD2.CguHVgoqOaKWyWHagBJEhIvVPUP = P_2;
								num = -1126685201;
								continue;
							case 4:
								dKdQOqgamqOwOaCJvYEMnBKjDbD2.WavyIscbOethGrCUZxLqsEtHClj = P_5;
								num = -1126685204;
								continue;
							default:
								return dKdQOqgamqOwOaCJvYEMnBKjDbD2;
							}
							break;
						}
					}
				}

				private IEnumerable<ElementAssignmentConflictInfo> roydyyJqNkzSPogcGtsQswBEjGe(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					CHCALcbgzvgbcxwTNbBblZsGWmr cHCALcbgzvgbcxwTNbBblZsGWmr = new CHCALcbgzvgbcxwTNbBblZsGWmr(-2);
					cHCALcbgzvgbcxwTNbBblZsGWmr.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					while (true)
					{
						int num = -559702855;
						while (true)
						{
							switch (num ^ -559702856)
							{
							case 0:
								break;
							case 1:
								cHCALcbgzvgbcxwTNbBblZsGWmr.UQPnpLguhtCEkQPRaxuaPxhrRag = P_0;
								num = -559702853;
								continue;
							case 3:
								cHCALcbgzvgbcxwTNbBblZsGWmr.AsggrPyUWCnFFjkCeamlXvALxt = P_1;
								num = -559702854;
								continue;
							default:
								cHCALcbgzvgbcxwTNbBblZsGWmr.UjalQWhdiZeUFTfVHLYPzbrLtqZ = P_2;
								cHCALcbgzvgbcxwTNbBblZsGWmr.WavyIscbOethGrCUZxLqsEtHClj = P_3;
								return cHCALcbgzvgbcxwTNbBblZsGWmr;
							}
							break;
						}
					}
				}

				private IEnumerable<ElementAssignmentConflictInfo> WnmEVefrkmktweWHaKFBaZrwiLMT(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					ALnGrBAPmkdCUiLQAzqklfpeQFOP aLnGrBAPmkdCUiLQAzqklfpeQFOP = new ALnGrBAPmkdCUiLQAzqklfpeQFOP(-2);
					aLnGrBAPmkdCUiLQAzqklfpeQFOP.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					aLnGrBAPmkdCUiLQAzqklfpeQFOP.RApvxUwOMdwouTDjTDNwfqBnIsx = P_0;
					aLnGrBAPmkdCUiLQAzqklfpeQFOP.qWJPVxPfcLerRJqSvJoChuSerNNP = P_1;
					aLnGrBAPmkdCUiLQAzqklfpeQFOP.rDfrnDJpzsajxvNACgcLmjIfOHZ = P_2;
					aLnGrBAPmkdCUiLQAzqklfpeQFOP.CguHVgoqOaKWyWHagBJEhIvVPUP = P_3;
					aLnGrBAPmkdCUiLQAzqklfpeQFOP.AsggrPyUWCnFFjkCeamlXvALxt = P_4;
					aLnGrBAPmkdCUiLQAzqklfpeQFOP.UjalQWhdiZeUFTfVHLYPzbrLtqZ = P_5;
					aLnGrBAPmkdCUiLQAzqklfpeQFOP.WavyIscbOethGrCUZxLqsEtHClj = P_6;
					return aLnGrBAPmkdCUiLQAzqklfpeQFOP;
				}

				private IEnumerable<ElementAssignmentConflictInfo> WnmEVefrkmktweWHaKFBaZrwiLMT(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					HNqyAaeQnDLXErvbwknECgTaeCV hNqyAaeQnDLXErvbwknECgTaeCV = new HNqyAaeQnDLXErvbwknECgTaeCV(-2);
					while (true)
					{
						int num = 710572337;
						while (true)
						{
							switch (num ^ 0x2A5A7933)
							{
							case 4:
								break;
							case 2:
								hNqyAaeQnDLXErvbwknECgTaeCV.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
								num = 710572338;
								continue;
							case 1:
								hNqyAaeQnDLXErvbwknECgTaeCV.UQPnpLguhtCEkQPRaxuaPxhrRag = P_0;
								hNqyAaeQnDLXErvbwknECgTaeCV.AsggrPyUWCnFFjkCeamlXvALxt = P_1;
								hNqyAaeQnDLXErvbwknECgTaeCV.UjalQWhdiZeUFTfVHLYPzbrLtqZ = P_2;
								num = 710572339;
								continue;
							case 0:
								hNqyAaeQnDLXErvbwknECgTaeCV.WavyIscbOethGrCUZxLqsEtHClj = P_3;
								num = 710572336;
								continue;
							default:
								return hNqyAaeQnDLXErvbwknECgTaeCV;
							}
							break;
						}
					}
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, false, false, true);
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, false, true);
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, true);
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					int num;
					if (playerId >= 0)
					{
						if (elementMap == null)
						{
							num = 1242501570;
						}
						else
						{
							if (controllerType == ControllerType.Joystick)
							{
								return AHdQckyoaKINqqJJzjwadlCfCEW(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
							}
							if (controllerType != ControllerType.Keyboard)
							{
								if (controllerType == ControllerType.Mouse)
								{
									return ZxWbeoIjvYBSQXdyrANDHnARGLS(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								}
								if (controllerType != ControllerType.Custom)
								{
									throw new NotImplementedException();
								}
								num = 1242501574;
							}
							else
							{
								num = 1242501572;
							}
						}
						goto IL_000c;
					}
					goto IL_007c;
					IL_0007:
					num = 1242501575;
					goto IL_000c;
					IL_000c:
					switch (num ^ 0x4A0F11C6)
					{
					case 3:
						break;
					case 1:
						return 0;
					case 2:
						return rLoBCXllsyrDUDgydfCwzPbilTg(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					case 4:
						goto IL_007c;
					default:
						return XvFQtupDPuHikfHcMPRDoEDJjy(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					goto IL_0007;
					IL_007c:
					return 0;
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, false, false, true);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps, false, true);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, true);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					if (conflictCheck.playerId < 0)
					{
						goto IL_0013;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return AHdQckyoaKINqqJJzjwadlCfCEW(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					int num;
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						num = -1572622678;
						goto IL_0018;
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return ZxWbeoIjvYBSQXdyrANDHnARGLS(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return XvFQtupDPuHikfHcMPRDoEDJjy(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
					IL_0018:
					switch (num ^ -1572622677)
					{
					case 0:
						break;
					case 2:
						return 0;
					default:
						return rLoBCXllsyrDUDgydfCwzPbilTg(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					goto IL_0013;
					IL_0013:
					num = -1572622679;
					goto IL_0018;
				}

				private int AHdQckyoaKINqqJJzjwadlCfCEW(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 >= 0)
					{
						int num3 = default(int);
						IList<Player> list = default(IList<Player>);
						int num2 = default(int);
						while (true)
						{
							int num = -46313633;
							while (true)
							{
								switch (num ^ -46313637)
								{
								case 0:
									break;
								case 2:
									num3 += list[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
									num2++;
									num = -46313640;
									continue;
								case 1:
									goto end_IL_0004;
								case 4:
									goto IL_007f;
								default:
									if (num2 >= list.Count)
									{
										return num3;
									}
									goto case 2;
								}
								break;
								IL_007f:
								if (P_3 != null)
								{
									list = (P_6 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
									num3 = 0;
									num2 = 0;
									num = -46313640;
								}
								else
								{
									num = -46313638;
								}
							}
							continue;
							end_IL_0004:
							break;
						}
					}
					return 0;
				}

				private int AHdQckyoaKINqqJJzjwadlCfCEW(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId >= 0)
					{
						int num2 = default(int);
						IList<Player> list = default(IList<Player>);
						int num3 = default(int);
						while (true)
						{
							int num = 1611076420;
							while (true)
							{
								switch (num ^ 0x60071346)
								{
								case 6:
									break;
								case 2:
									goto IL_003e;
								case 1:
									goto IL_004f;
								case 3:
									num = 1611076423;
									continue;
								case 5:
									num2 += list[num3].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
									num3++;
									num = 1611076423;
									continue;
								case 4:
									goto end_IL_000d;
								default:
									return num2;
								}
								break;
								IL_004f:
								int num4;
								if (num3 >= list.Count)
								{
									num = 1611076422;
									num4 = num;
								}
								else
								{
									num = 1611076419;
									num4 = num;
								}
								continue;
								IL_003e:
								if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									num = 1611076418;
									continue;
								}
								list = (P_3 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
								num2 = 0;
								num3 = 0;
								num = 1611076421;
							}
							continue;
							end_IL_000d:
							break;
						}
					}
					return 0;
				}

				private int rLoBCXllsyrDUDgydfCwzPbilTg(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0)
					{
						goto IL_0035;
					}
					if (P_2 == null)
					{
						goto IL_0007;
					}
					int num;
					if (!P_5)
					{
						num = -1110734839;
						goto IL_000c;
					}
					IList<Player> list = lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly;
					goto IL_0058;
					IL_000c:
					int num3 = default(int);
					int num2 = default(int);
					IList<Player> list2 = default(IList<Player>);
					while (true)
					{
						switch (num ^ -1110734840)
						{
						case 4:
							break;
						case 2:
							goto IL_0035;
						case 1:
							goto IL_0042;
						case 5:
							num3 = 0;
							num2 = 0;
							num = -1110734834;
							continue;
						case 6:
							num = -1110734840;
							continue;
						case 3:
							num3 += list2[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
							num2++;
							num = -1110734840;
							continue;
						default:
							if (num2 >= list2.Count)
							{
								return num3;
							}
							goto case 3;
						}
						break;
					}
					goto IL_0007;
					IL_0042:
					list = lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly;
					goto IL_0058;
					IL_0035:
					return 0;
					IL_0058:
					list2 = list;
					num = -1110734835;
					goto IL_000c;
					IL_0007:
					num = -1110734838;
					goto IL_000c;
				}

				private int rLoBCXllsyrDUDgydfCwzPbilTg(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId >= 0)
					{
						int num3 = default(int);
						IList<Player> list = default(IList<Player>);
						int num2 = default(int);
						while (true)
						{
							int num = 1416563805;
							while (true)
							{
								switch (num ^ 0x546F0C5C)
								{
								case 0:
									break;
								case 1:
									goto IL_0030;
								case 3:
									num3 += list[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
									num2++;
									num = 1416563806;
									continue;
								case 4:
									goto end_IL_000a;
								default:
									if (num2 >= list.Count)
									{
										return num3;
									}
									goto case 3;
								}
								break;
								IL_0030:
								if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
								{
									num = 1416563800;
									continue;
								}
								list = (P_3 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
								num3 = 0;
								num2 = 0;
								num = 1416563806;
							}
							continue;
							end_IL_000a:
							break;
						}
					}
					return 0;
				}

				private int ZxWbeoIjvYBSQXdyrANDHnARGLS(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num;
					if (P_0 >= 0)
					{
						if (P_2 == null)
						{
							goto IL_000d;
						}
						list = (P_5 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
						num = -1601001432;
						goto IL_0012;
					}
					goto IL_008d;
					IL_0012:
					int num2 = default(int);
					int num3 = default(int);
					while (true)
					{
						switch (num ^ -1601001432)
						{
						case 2:
							break;
						case 5:
							num2 += list[num3].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
							num3++;
							num = -1601001431;
							continue;
						case 1:
							goto IL_006a;
						case 0:
							num2 = 0;
							num = -1601001428;
							continue;
						case 6:
							goto IL_008d;
						case 4:
							num3 = 0;
							num = -1601001431;
							continue;
						default:
							return num2;
						}
						break;
						IL_006a:
						int num4;
						if (num3 < list.Count)
						{
							num = -1601001427;
							num4 = num;
						}
						else
						{
							num = -1601001429;
							num4 = num;
						}
					}
					goto IL_000d;
					IL_000d:
					num = -1601001426;
					goto IL_0012;
					IL_008d:
					return 0;
				}

				private int ZxWbeoIjvYBSQXdyrANDHnARGLS(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId >= 0)
					{
						int num3 = default(int);
						IList<Player> list = default(IList<Player>);
						int num2 = default(int);
						while (true)
						{
							int num = -409016420;
							while (true)
							{
								switch (num ^ -409016418)
								{
								case 4:
									break;
								case 2:
									goto IL_0038;
								case 1:
									num = -409016424;
									continue;
								case 0:
									num3 += list[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
									num = -409016421;
									continue;
								case 3:
									goto end_IL_000a;
								case 5:
									num2++;
									num = -409016424;
									continue;
								default:
									if (num2 >= list.Count)
									{
										return num3;
									}
									goto case 0;
								}
								break;
								IL_0038:
								if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									num = -409016419;
									continue;
								}
								list = (P_3 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
								num3 = 0;
								num2 = 0;
								num = -409016417;
							}
							continue;
							end_IL_000a:
							break;
						}
					}
					return 0;
				}

				private int XvFQtupDPuHikfHcMPRDoEDJjy(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0)
					{
						goto IL_0032;
					}
					if (P_3 == null)
					{
						goto IL_0008;
					}
					int num;
					if (!P_6)
					{
						num = 333223917;
						goto IL_000d;
					}
					IList<Player> list = lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly;
					goto IL_0055;
					IL_000d:
					int num2 = default(int);
					int num3 = default(int);
					IList<Player> list2 = default(IList<Player>);
					while (true)
					{
						switch (num ^ 0x13DC97EE)
						{
						case 4:
							break;
						case 1:
							goto IL_0032;
						case 3:
							goto IL_003f;
						case 2:
							num2++;
							num = 333223918;
							continue;
						case 5:
							num3 += list2[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
							num = 333223916;
							continue;
						default:
							if (num2 >= list2.Count)
							{
								return num3;
							}
							goto case 5;
						}
						break;
					}
					goto IL_0008;
					IL_0032:
					return 0;
					IL_003f:
					list = lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly;
					goto IL_0055;
					IL_0055:
					list2 = list;
					num3 = 0;
					num2 = 0;
					num = 333223918;
					goto IL_000d;
					IL_0008:
					num = 333223919;
					goto IL_000d;
				}

				private int XvFQtupDPuHikfHcMPRDoEDJjy(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId >= 0)
					{
						int num3 = default(int);
						IList<Player> list = default(IList<Player>);
						int num2 = default(int);
						while (true)
						{
							int num = -1797188465;
							while (true)
							{
								switch (num ^ -1797188466)
								{
								case 4:
									break;
								case 1:
									goto IL_0030;
								case 0:
									num3 += list[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
									num2++;
									num = -1797188467;
									continue;
								case 2:
									goto end_IL_000a;
								default:
									if (num2 >= list.Count)
									{
										return num3;
									}
									goto case 0;
								}
								break;
								IL_0030:
								if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									num = -1797188468;
									continue;
								}
								list = (P_3 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
								num3 = 0;
								num2 = 0;
								num = -1797188467;
							}
							continue;
							end_IL_000a:
							break;
						}
					}
					return 0;
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, false, false, true);
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, false, true);
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, true);
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					if (playerId >= 0)
					{
						while (true)
						{
							int num = 1631278994;
							while (true)
							{
								switch (num ^ 0x613B5790)
								{
								case 4:
									break;
								case 2:
									goto IL_0033;
								case 0:
									return wSurShbbULJeQoJlBHiBOPpDEeGK(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								case 1:
									goto end_IL_000d;
								default:
									return vgHZOwKhoXKvpOljhwzrPRTVlrt(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								}
								break;
								IL_0033:
								if (elementMap == null)
								{
									num = 1631278993;
									continue;
								}
								switch (controllerType)
								{
								case ControllerType.Keyboard:
									num = 1631278995;
									break;
								case ControllerType.Joystick:
									num = 1631278992;
									break;
								case ControllerType.Mouse:
									return EEailcxZHduwgmcoovAHXklmBZI(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								case ControllerType.Custom:
									return BmGOQfWyvcvrnehoSGfuzjVdPrv(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								default:
									throw new NotImplementedException();
								}
							}
							continue;
							end_IL_000d:
							break;
						}
					}
					return 0;
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return DisableElementAssignmentConflicts(conflictCheck, false, false, true);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, false, true);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, true);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					if (conflictCheck.playerId < 0)
					{
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return wSurShbbULJeQoJlBHiBOPpDEeGK(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return vgHZOwKhoXKvpOljhwzrPRTVlrt(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return EEailcxZHduwgmcoovAHXklmBZI(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return BmGOQfWyvcvrnehoSGfuzjVdPrv(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int wSurShbbULJeQoJlBHiBOPpDEeGK(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num = default(int);
					int num2;
					if (P_0 >= 0)
					{
						if (P_3 == null)
						{
							goto IL_0008;
						}
						list = (P_6 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
						num = 0;
						num2 = 1661273426;
						goto IL_000d;
					}
					goto IL_0039;
					IL_000d:
					int num3 = default(int);
					while (true)
					{
						switch (num2 ^ 0x63050556)
						{
						case 3:
							break;
						case 2:
							goto IL_0039;
						case 0:
							num2 = 1661273424;
							continue;
						case 1:
							num += list[num3].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
							num3++;
							num2 = 1661273424;
							continue;
						case 6:
							goto IL_0096;
						case 4:
							num3 = 0;
							num2 = 1661273430;
							continue;
						default:
							return num;
						}
						break;
						IL_0096:
						int num4;
						if (num3 < list.Count)
						{
							num2 = 1661273431;
							num4 = num2;
						}
						else
						{
							num2 = 1661273427;
							num4 = num2;
						}
					}
					goto IL_0008;
					IL_0008:
					num2 = 1661273428;
					goto IL_000d;
					IL_0039:
					return 0;
				}

				private int wSurShbbULJeQoJlBHiBOPpDEeGK(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num = default(int);
					int num2 = default(int);
					int num3;
					if (P_0.playerId >= 0)
					{
						if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
						{
							goto IL_0014;
						}
						list = (P_3 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
						num = 0;
						num2 = 0;
						num3 = 640954421;
						goto IL_0019;
					}
					goto IL_003e;
					IL_0019:
					while (true)
					{
						switch (num3 ^ 0x26343037)
						{
						case 4:
							break;
						case 1:
							goto IL_003e;
						case 2:
							num3 = 640954423;
							continue;
						case 5:
							num2++;
							num3 = 640954423;
							continue;
						case 3:
							num += list[num2].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
							num3 = 640954418;
							continue;
						default:
							if (num2 >= list.Count)
							{
								return num;
							}
							goto case 3;
						}
						break;
					}
					goto IL_0014;
					IL_0014:
					num3 = 640954422;
					goto IL_0019;
					IL_003e:
					return 0;
				}

				private int vgHZOwKhoXKvpOljhwzrPRTVlrt(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0)
					{
						goto IL_0031;
					}
					if (P_2 == null)
					{
						goto IL_0007;
					}
					int num;
					if (!P_5)
					{
						num = 752403520;
						goto IL_000c;
					}
					IList<Player> list = lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly;
					goto IL_0080;
					IL_000c:
					int num3 = default(int);
					IList<Player> list2 = default(IList<Player>);
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0x2CD8C442)
						{
						case 3:
							break;
						case 4:
							goto IL_0031;
						case 1:
							num3 += list2[num2].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
							num2++;
							num = 752403527;
							continue;
						case 2:
							goto IL_006a;
						case 0:
							num = 752403527;
							continue;
						default:
							if (num2 >= list2.Count)
							{
								return num3;
							}
							goto case 1;
						}
						break;
					}
					goto IL_0007;
					IL_0031:
					return 0;
					IL_0080:
					list2 = list;
					num3 = 0;
					num2 = 0;
					num = 752403522;
					goto IL_000c;
					IL_006a:
					list = lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly;
					goto IL_0080;
					IL_0007:
					num = 752403526;
					goto IL_000c;
				}

				private int vgHZOwKhoXKvpOljhwzrPRTVlrt(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId >= 0)
					{
						int num3 = default(int);
						IList<Player> list = default(IList<Player>);
						int num2 = default(int);
						while (true)
						{
							int num = 375821166;
							while (true)
							{
								switch (num ^ 0x1666936C)
								{
								case 0:
									break;
								case 1:
									num = 375821161;
									continue;
								case 4:
									num3 += list[num2].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
									num2++;
									num = 375821161;
									continue;
								case 2:
									goto IL_0062;
								case 3:
									goto end_IL_000a;
								default:
									if (num2 >= list.Count)
									{
										return num3;
									}
									goto case 4;
								}
								break;
								IL_0062:
								if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
								{
									num = 375821167;
									continue;
								}
								list = (P_3 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
								num3 = 0;
								num2 = 0;
								num = 375821165;
							}
							continue;
							end_IL_000a:
							break;
						}
					}
					return 0;
				}

				private int EEailcxZHduwgmcoovAHXklmBZI(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 >= 0)
					{
						int num2 = default(int);
						IList<Player> list = default(IList<Player>);
						int num3 = default(int);
						while (true)
						{
							int num = -1069929812;
							while (true)
							{
								switch (num ^ -1069929813)
								{
								case 5:
									break;
								case 2:
									goto IL_0039;
								case 6:
									num2 = 0;
									num = -1069929813;
									continue;
								case 4:
									goto end_IL_0004;
								case 3:
									num2 += list[num3].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
									num3++;
									num = -1069929815;
									continue;
								case 0:
									num3 = 0;
									num = -1069929815;
									continue;
								case 7:
									goto IL_00bb;
								default:
									return num2;
								}
								break;
								IL_00bb:
								if (P_2 != null)
								{
									list = (P_5 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
									num = -1069929811;
								}
								else
								{
									num = -1069929809;
								}
								continue;
								IL_0039:
								int num4;
								if (num3 >= list.Count)
								{
									num = -1069929814;
									num4 = num;
								}
								else
								{
									num = -1069929816;
									num4 = num;
								}
							}
							continue;
							end_IL_0004:
							break;
						}
					}
					return 0;
				}

				private int EEailcxZHduwgmcoovAHXklmBZI(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId >= 0)
					{
						int num3 = default(int);
						int num2 = default(int);
						IList<Player> list = default(IList<Player>);
						while (true)
						{
							int num = -874864435;
							while (true)
							{
								switch (num ^ -874864436)
								{
								case 6:
									break;
								case 1:
									goto IL_003f;
								case 0:
									num3 = 0;
									num2 = 0;
									num = -874864434;
									continue;
								case 4:
									goto IL_005b;
								case 3:
									num2++;
									num = -874864434;
									continue;
								case 5:
									num3 += list[num2].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
									num = -874864433;
									continue;
								case 7:
									goto end_IL_000d;
								default:
									if (num2 >= list.Count)
									{
										return num3;
									}
									goto case 5;
								}
								break;
								IL_005b:
								IList<Player> list2 = lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly;
								goto IL_0071;
								IL_003f:
								if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									num = -874864437;
									continue;
								}
								if (P_3)
								{
									list2 = lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly;
									goto IL_0071;
								}
								num = -874864440;
								continue;
								IL_0071:
								list = list2;
								num = -874864436;
							}
							continue;
							end_IL_000d:
							break;
						}
					}
					return 0;
				}

				private int BmGOQfWyvcvrnehoSGfuzjVdPrv(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 >= 0)
					{
						int num3 = default(int);
						IList<Player> list = default(IList<Player>);
						int num2 = default(int);
						while (true)
						{
							int num = -1630533468;
							while (true)
							{
								switch (num ^ -1630533465)
								{
								case 0:
									break;
								case 3:
									goto IL_002e;
								case 2:
									goto end_IL_0004;
								case 5:
									num3 += list[num2].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
									num = -1630533466;
									continue;
								case 1:
									num2++;
									num = -1630533469;
									continue;
								default:
									if (num2 >= list.Count)
									{
										return num3;
									}
									goto case 5;
								}
								break;
								IL_002e:
								if (P_3 == null)
								{
									num = -1630533467;
									continue;
								}
								list = (P_6 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
								num3 = 0;
								num2 = 0;
								num = -1630533469;
							}
							continue;
							end_IL_0004:
							break;
						}
					}
					return 0;
				}

				private int BmGOQfWyvcvrnehoSGfuzjVdPrv(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num = default(int);
					int num2 = default(int);
					int num3;
					if (P_0.playerId >= 0)
					{
						if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
						{
							goto IL_0014;
						}
						list = (P_3 ? lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly : lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly);
						num = 0;
						num2 = 0;
						num3 = 2065684922;
						goto IL_0019;
					}
					goto IL_0068;
					IL_0019:
					while (true)
					{
						switch (num3 ^ 0x7B1FD9BA)
						{
						case 2:
							break;
						case 1:
							num += list[num2].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
							num3 = 2065684926;
							continue;
						case 0:
							num3 = 2065684927;
							continue;
						case 3:
							goto IL_0068;
						case 4:
							num2++;
							num3 = 2065684927;
							continue;
						default:
							if (num2 >= list.Count)
							{
								return num;
							}
							goto case 1;
						}
						break;
					}
					goto IL_0014;
					IL_0014:
					num3 = 2065684921;
					goto IL_0019;
					IL_0068:
					return 0;
				}
			}

			private static ControllerHelper VLHBdfuObcdunicAbIHFTExpsoBB;

			public readonly PollingHelper polling = PollingHelper.Instance;

			public readonly ConflictCheckingHelper conflictChecking = ConflictCheckingHelper.Instance;

			internal static ControllerHelper Instance
			{
				get
				{
					return VLHBdfuObcdunicAbIHFTExpsoBB ?? (VLHBdfuObcdunicAbIHFTExpsoBB = new ControllerHelper());
				}
			}

			public int controllerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.controllerCount;
				}
			}

			public IList<Controller> Controllers
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<Controller>.EmptyReadOnlyIListT;
					}
					return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Controllers;
				}
			}

			public Mouse Mouse
			{
				get
				{
					if (!CheckInitialized())
					{
						return null;
					}
					return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Mouse;
				}
			}

			public Keyboard Keyboard
			{
				get
				{
					if (!CheckInitialized())
					{
						return null;
					}
					return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Keyboard;
				}
			}

			[Obsolete("Deprecated: Use Controller.enabled instead. For example, to disable keyboard input: ReInput.controllers.Keyboard.enabled = false.")]
			public bool keyboardEnabled
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return Keyboard.enabled;
				}
				set
				{
					if (!CheckInitialized())
					{
						while (true)
						{
							switch (0x1EA957E9 ^ 0x1EA957E8)
							{
							case 2:
								continue;
							case 1:
								return;
							}
							break;
						}
					}
					Keyboard.enabled = value;
				}
			}

			public int joystickCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.joystickCount;
				}
			}

			public IList<Joystick> Joysticks
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
					}
					return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Joysticks_readOnly;
				}
			}

			public int customControllerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.customControllerCount;
				}
			}

			public IList<CustomController> CustomControllers
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
					}
					return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.CustomControllers_readOnly;
				}
			}

			private ControllerHelper()
			{
			}

			public T GetController<T>(int controllerId) where T : Controller
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				T result = default(T);
				int num;
				if (controllerId < 0)
				{
					result = null;
					num = -1433471207;
				}
				else
				{
					Type typeFromHandle = typeof(T);
					if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
					{
						return GetJoystick(controllerId) as T;
					}
					if (!ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
					{
						if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
						{
							return GetCustomController(controllerId) as T;
						}
						if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
						{
							return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Mouse as T;
						}
						throw new NotImplementedException();
					}
					num = -1433471205;
				}
				goto IL_000c;
				IL_0007:
				num = -1433471208;
				goto IL_000c;
				IL_000c:
				switch (num ^ -1433471207)
				{
				case 3:
					break;
				case 1:
					return null;
				case 0:
					return result;
				default:
					return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Keyboard as T;
				}
				goto IL_0007;
			}

			public int GetControllerCount(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return 0;
				}
				while (true)
				{
					int num = -995706205;
					while (true)
					{
						switch (num ^ -995706206)
						{
						case 3:
							break;
						case 0:
							if (controllerType != ControllerType.Custom)
							{
								num = -995706208;
								continue;
							}
							return customControllerCount;
						case 1:
							switch (controllerType)
							{
							default:
								num = -995706206;
								continue;
							case ControllerType.Joystick:
								break;
							case ControllerType.Keyboard:
								return 1;
							case ControllerType.Mouse:
								return 1;
							}
							goto default;
						default:
							return joystickCount;
						case 2:
							throw new NotImplementedException();
						}
						break;
					}
				}
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.YVImgJAVYrCFxvRCiDMpssMfsKM(controllerType, controllerId);
			}

			public Controller GetController(ControllerIdentifier controllerIdentifier)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.YVImgJAVYrCFxvRCiDMpssMfsKM(controllerIdentifier);
			}

			public Controller[] GetControllers(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Controller>.array;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.zYeDZNDqbcUttGQRqODIiybceUtD(controllerType);
			}

			public string[] GetControllerNames(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.CsxMNxOCPPThAwZqmhOknsLIWNA(controllerType);
			}

			public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.LqOsIFgLyRmAdSarMBDbInCHiLI(controller);
			}

			public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.LqOsIFgLyRmAdSarMBDbInCHiLI(controllerType, controllerId);
			}

			public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.woFxHwVTprBXahGtsdcXWiqeAzo(controllerType, controllerId, playerId);
			}

			public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
			{
				if (!CheckInitialized())
				{
					while (true)
					{
						switch (-1383308744 ^ -1383308742)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				lGcKTymIVPnyTtnJFgbcUzeJcSS.TvLIHINEoeJcxvdLoUqvEoIiuPk(controller, includeSystemPlayer);
			}

			public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					lGcKTymIVPnyTtnJFgbcUzeJcSS.TvLIHINEoeJcxvdLoUqvEoIiuPk(controllerType, controllerId, includeSystemPlayer);
				}
			}

			public Joystick GetJoystick(int joystickId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.oDPKIGALeDTydQUPLxZoBnImPhj(joystickId);
			}

			public Joystick[] GetJoysticks()
			{
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.LgSDfARcRmJiTVRtHrmjdSoFeYe();
			}

			public string[] GetJoystickNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.ebrZMhoLdviQYAzurIbzzrUBFjP();
			}

			public bool IsJoystickAssigned(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.lbyVKQJogxdVfVUFgbcPfDTttev(joystick);
			}

			public bool IsJoystickAssigned(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.lbyVKQJogxdVfVUFgbcPfDTttev(joystickId);
			}

			public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.NlZNlvekbylqgoVyDitcFrvcPPn(joystickId, playerId);
			}

			public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
			{
				if (!CheckInitialized())
				{
					while (true)
					{
						switch (0x3B78CEF9 ^ 0x3B78CEF8)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				lGcKTymIVPnyTtnJFgbcUzeJcSS.ROTeZojMeDrvJFrNYYMFxdgOcfI(joystick, includeSystemPlayer);
			}

			public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
			{
				if (!CheckInitialized())
				{
					while (true)
					{
						switch (-1066883567 ^ -1066883568)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				lGcKTymIVPnyTtnJFgbcUzeJcSS.ROTeZojMeDrvJFrNYYMFxdgOcfI(joystickId, includeSystemPlayer);
			}

			public int GetUnityJoystickIdFromAnyButtonPress()
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!aqQNYTLFCDaASydZMAHFATKUUjI)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				ptNnzwiFJXsgxOxpTIMJDbmpoTX();
				int num = 0;
				while (num < 16)
				{
					while (true)
					{
						int num2 = 0;
						int num3 = -1202750860;
						while (true)
						{
							switch (num3 ^ -1202750860)
							{
							case 4:
								num3 = -1202750859;
								continue;
							case 2:
								break;
							case 0:
								num3 = -1202750863;
								continue;
							case 5:
								if (num2 >= 20)
								{
									num++;
									num3 = -1202750857;
									continue;
								}
								break;
							case 1:
								goto end_IL_002a;
							default:
								goto end_IL_0085;
							}
							if (unityInputBuffer.diMudXjFUpxBpMgcVGAIbDchkqYK(num, num2))
							{
								return num + 1;
							}
							num2++;
							num3 = -1202750863;
							continue;
							end_IL_002a:
							break;
						}
						continue;
						end_IL_0085:
						break;
					}
				}
				return -1;
			}

			public int GetUnityJoystickIdFromAnyButtonOrAxisPress(float axisThreshold, bool positiveAxesOnly)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!aqQNYTLFCDaASydZMAHFATKUUjI)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				ptNnzwiFJXsgxOxpTIMJDbmpoTX();
				int num = 0;
				int num4 = default(int);
				while (num < 16)
				{
					while (true)
					{
						int num2 = 0;
						int num3 = -610105522;
						while (true)
						{
							switch (num3 ^ -610105529)
							{
							case 5:
								num3 = -610105521;
								continue;
							case 8:
								break;
							case 3:
								num4 = 0;
								num3 = -610105533;
								continue;
							case 1:
								goto IL_0077;
							case 0:
								goto IL_008e;
							case 4:
								goto IL_00b3;
							case 7:
								num++;
								num3 = -610105531;
								continue;
							case 9:
								goto IL_00da;
							case 6:
								return num + 1;
							default:
								goto end_IL_0065;
							}
							break;
							IL_00da:
							int num5;
							if (num2 >= 20)
							{
								num3 = -610105532;
								num5 = num3;
							}
							else
							{
								num3 = -610105530;
								num5 = num3;
							}
							continue;
							IL_008e:
							if (unityInputBuffer.LhcTklIkJnkZFArodDzATauhLFp(num, num4, positiveAxesOnly))
							{
								return num + 1;
							}
							num4++;
							num3 = -610105533;
							continue;
							IL_0077:
							if (unityInputBuffer.diMudXjFUpxBpMgcVGAIbDchkqYK(num, num2))
							{
								num3 = -610105535;
								continue;
							}
							num2++;
							num3 = -610105522;
							continue;
							IL_00b3:
							int num6;
							if (num4 < 29)
							{
								num3 = -610105529;
								num6 = num3;
							}
							else
							{
								num3 = -610105536;
								num6 = num3;
							}
						}
						continue;
						end_IL_0065:
						break;
					}
				}
				return -1;
			}

			public void SetUnityJoystickId(int joystickId, int unityJoystickId)
			{
				if (!CheckInitialized())
				{
					while (true)
					{
						switch (0x298343F4 ^ 0x298343F5)
						{
						case 3:
							break;
						case 1:
							return;
						case 0:
							goto end_IL_0007;
						default:
							goto IL_004a;
						}
						continue;
						end_IL_0007:
						break;
					}
				}
				if (!aqQNYTLFCDaASydZMAHFATKUUjI)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return;
				}
				goto IL_004a;
				IL_004a:
				MDVmwweEvHoLmOhNxpYDWbEeYJl.SetUnityJoystickId(joystickId, unityJoystickId);
			}

			public bool SetUnityJoystickIdFromAnyButtonPress(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				int unityJoystickIdFromAnyButtonPress = GetUnityJoystickIdFromAnyButtonPress();
				if (unityJoystickIdFromAnyButtonPress < 1)
				{
					goto IL_0014;
				}
				SetUnityJoystickId(joystickId, unityJoystickIdFromAnyButtonPress);
				int num = 517968753;
				goto IL_0019;
				IL_0019:
				switch (num ^ 0x1EDF9371)
				{
				case 2:
					break;
				case 1:
					return false;
				default:
					return true;
				}
				goto IL_0014;
				IL_0014:
				num = 517968752;
				goto IL_0019;
			}

			public bool SetUnityJoystickIdFromAnyButtonOrAxisPress(int joystickId, float axisThreshold, bool positiveAxesOnly)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				int unityJoystickIdFromAnyButtonOrAxisPress = GetUnityJoystickIdFromAnyButtonOrAxisPress(axisThreshold, positiveAxesOnly);
				if (unityJoystickIdFromAnyButtonOrAxisPress < 1)
				{
					return false;
				}
				SetUnityJoystickId(joystickId, unityJoystickIdFromAnyButtonOrAxisPress);
				return true;
			}

			public CustomController GetCustomController(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.CqvNvMDsuksRPQaUdVrxJQmSQnk(customControllerId);
			}

			public CustomController[] GetCustomControllers()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.array;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.vWGAgIZMhEZgzPXrkOErxEbnUNx();
			}

			public string[] GetCustomControllerNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.fkSRaHvrnugBoMmQisjEZdMDIEo();
			}

			public bool IsCustomControllerAssigned(CustomController customController)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.cQIAqpWsdRbazCBsUcPweagLCntn(customController);
			}

			public bool IsCustomControllerAssigned(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.cQIAqpWsdRbazCBsUcPweagLCntn(customControllerId);
			}

			public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.bDajfBktJPoMlvTQSWFzgujSDcQH(customControllerId, playerId);
			}

			public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					lGcKTymIVPnyTtnJFgbcUzeJcSS.QYWJGTwGCPsJLqXMnTOavcZUFoYe(customController, includeSystemPlayer);
				}
			}

			public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					lGcKTymIVPnyTtnJFgbcUzeJcSS.QYWJGTwGCPsJLqXMnTOavcZUFoYe(customControllerId, includeSystemPlayer);
				}
			}

			public CustomController CreateCustomController(int sourceControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.niQrHAQljuFoiNkqEumUiOlpjNB(sourceControllerId);
			}

			public CustomController CreateCustomController(int sourceControllerId, string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomController customController = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.niQrHAQljuFoiNkqEumUiOlpjNB(sourceControllerId);
				if (customController == null)
				{
					return null;
				}
				customController.tag = tag;
				return customController;
			}

			public bool DestroyCustomController(CustomController customController)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				int num;
				if (customController == null)
				{
					num = -372538452;
				}
				else
				{
					RemoveCustomControllerFromAllPlayers(customController);
					num = -372538449;
				}
				goto IL_000c;
				IL_0007:
				num = -372538451;
				goto IL_000c;
				IL_000c:
				switch (num ^ -372538452)
				{
				case 2:
					break;
				case 1:
					return false;
				case 0:
					return false;
				default:
					return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.rrfKwKinUgPnkVRDGRIBwRBvdyl(customController);
				}
				goto IL_0007;
			}

			public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.ilnQPUornmBtuAyaCUdThiAEKyn(sourceId);
			}

			public CustomController GetFirstCustomControllerWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.jMjXEiRIYuqWQbZXzbcYJgyFcBz(tag);
			}

			public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.cNzaKqJoNJaTSOODCykXBIIhkAQG(sourceId);
			}

			public IEnumerable<CustomController> CustomControllersWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.KPMxtcTeWlhXbsEfrBxvfMIMhniv(tag);
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.ghCBlVNkxiocFGjEGxVdIgEcuWW<TInterface>();
			}

			public Controller GetLastActiveController()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.fWOauwDIDcWjYxShfcASqWxMgbX();
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.fWOauwDIDcWjYxShfcASqWxMgbX(controllerType);
			}

			public T GetLastActiveController<T>() where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.fWOauwDIDcWjYxShfcASqWxMgbX<T>();
			}

			public ControllerType GetLastActiveControllerType()
			{
				if (!CheckInitialized())
				{
					return ControllerType.Keyboard;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.pDhVwRlXXslzovKejqNtCKesixpi();
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					TjEnOXyhIcFYKPeZiqgPVRhKsqQ.hpFIVZmRfUbbLvulxgYHsvREHbF(callback);
				}
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					TjEnOXyhIcFYKPeZiqgPVRhKsqQ.hpFIVZmRfUbbLvulxgYHsvREHbF(callback, controllerType);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (!CheckInitialized())
				{
					return;
				}
				while (true)
				{
					TjEnOXyhIcFYKPeZiqgPVRhKsqQ.rnmefIEnbCCusFKatRSGRudhuhmA(callback);
					int num = 211814134;
					while (true)
					{
						switch (num ^ 0xCA006F7)
						{
						case 0:
							goto IL_0008;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_0008:
						num = 211814133;
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					while (true)
					{
						switch (0x3035A7C3 ^ 0x3035A7C2)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				TjEnOXyhIcFYKPeZiqgPVRhKsqQ.YkWbqHcwNGyNxcTHwcOtszqIEMc(callback, controllerType);
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (CheckInitialized())
				{
					TjEnOXyhIcFYKPeZiqgPVRhKsqQ.WHyoiTUpMrPmDVgChnkcKWiYlWX();
				}
			}

			public bool GetAnyButton()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.LIyeeMahnlUVtdgkFBEwAQnllGj();
			}

			public bool GetAnyButton(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.LIyeeMahnlUVtdgkFBEwAQnllGj(controllerType);
			}

			public bool GetAnyButtonDown()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.PXhWNfUqKGRgGqQAjIeymqlWWgK();
			}

			public bool GetAnyButtonDown(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.PXhWNfUqKGRgGqQAjIeymqlWWgK(controllerType);
			}

			public bool GetAnyButtonUp()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.fyepVroCjjqHJkuJjMHXPuIvCFS();
			}

			public bool GetAnyButtonUp(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.fyepVroCjjqHJkuJjMHXPuIvCFS(controllerType);
			}

			public bool GetAnyButtonChanged()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.iyiXNefGzEbwVGNxvqGiWRIvdfAx();
			}

			public bool GetAnyButtonChanged(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.iyiXNefGzEbwVGNxvqGiWRIvdfAx(controllerType);
			}

			public bool GetAnyButtonPrev()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.vLugLglmrrfGnuxieKLTvkVukgB();
			}

			public bool GetAnyButtonPrev(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.vLugLglmrrfGnuxieKLTvkVukgB(controllerType);
			}

			public bool AutoAssignJoystick(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				int num;
				if (joystick == null)
				{
					num = -1937567796;
				}
				else if (!IsJoystickAssigned(joystick))
				{
					lGcKTymIVPnyTtnJFgbcUzeJcSS.CPsrZMWBfXaFqLffSjNpAwOYCoPo(joystick);
					num = -1937567794;
				}
				else
				{
					num = -1937567798;
				}
				goto IL_000c;
				IL_000c:
				switch (num ^ -1937567794)
				{
				case 3:
					break;
				case 1:
					return false;
				case 4:
					return true;
				case 2:
					return false;
				default:
					return IsJoystickAssigned(joystick);
				}
				goto IL_0007;
				IL_0007:
				num = -1937567793;
				goto IL_000c;
			}

			public void AutoAssignJoysticks()
			{
				if (!CheckInitialized())
				{
					return;
				}
				while (true)
				{
					int num = joystickCount;
					IList<Joystick> joysticks = Joysticks;
					int num2 = 0;
					int num3 = 1791075441;
					while (true)
					{
						switch (num3 ^ 0x6AC1A477)
						{
						case 0:
							num3 = 1791075445;
							continue;
						default:
							return;
						case 2:
							break;
						case 5:
							num2++;
							num3 = 1791075446;
							continue;
						case 1:
						{
							int num4;
							if (num2 < num)
							{
								num3 = 1791075443;
								num4 = num3;
							}
							else
							{
								num3 = 1791075444;
								num4 = num3;
							}
							continue;
						}
						case 4:
							AutoAssignJoystick(joysticks[num2]);
							num3 = 1791075442;
							continue;
						case 6:
							num3 = 1791075446;
							continue;
						case 3:
							return;
						}
						break;
					}
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class MappingHelper : CodeHelper
		{
			private static MappingHelper VLHBdfuObcdunicAbIHFTExpsoBB;

			internal static MappingHelper Instance
			{
				get
				{
					return VLHBdfuObcdunicAbIHFTExpsoBB ?? (VLHBdfuObcdunicAbIHFTExpsoBB = new MappingHelper());
				}
			}

			public IList<InputMapCategory> MapCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.MapCategories_readOnly;
				}
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.UserAssignableMapCategories;
				}
			}

			public IList<InputCategory> ActionCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.ActionCategories_readOnly;
				}
			}

			public IEnumerable<InputCategory> UserAssignableActionCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.UserAssignableActionCategories;
				}
			}

			public IList<InputLayout> JoystickLayouts
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.JoystickLayouts_readOnly;
				}
			}

			public IList<InputLayout> KeyboardLayouts
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.KeyboardLayouts_readOnly;
				}
			}

			public IList<InputLayout> MouseLayouts
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.MouseLayouts_readOnly;
				}
			}

			public IList<InputLayout> CustomControllerLayouts
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.CustomControllerLayouts_readOnly;
				}
			}

			public IList<InputAction> Actions
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
					}
					return AQANKVsSPXqhjRcrczEkdvuTzzw.Actions;
				}
			}

			public IEnumerable<InputAction> UserAssignableActions
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
					}
					return stWFwgAKcHRiMeUYeMbPaDXDxKKn.UserAssignableActions;
				}
			}

			private MappingHelper()
			{
			}

			public InputMapCategory GetMapCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetMapCategoryById(mapCategoryId);
			}

			public InputMapCategory GetMapCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetMapCategory(name);
			}

			public int GetMapCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetMapCategoryId(name);
			}

			public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.zAqXUEiiUEFjyIPgoSvWHaOOAYO(tag);
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.NHcTWDOPpHiAhPfHPFrEdnRjgZGz(tag);
			}

			public bool IsMapCategoryUserAssignable(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				InputCategory mapCategory = GetMapCategory(mapCategoryId);
				if (mapCategory == null)
				{
					return false;
				}
				return mapCategory.userAssignable;
			}

			public InputCategory GetActionCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetActionCategoryById(mapCategoryId);
			}

			public InputCategory GetActionCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetActionCategory(name);
			}

			public int GetActionCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetActionCategoryId(name);
			}

			public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.HbBkzpjPqWKnvmHXweEoqZnJHSj(tag);
			}

			public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.xtwCXEiSLmVNHhbFEfXnDCcXIeQh(tag);
			}

			public bool IsActionCategoryUserAssignable(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				InputCategory actionCategory = GetActionCategory(mapCategoryId);
				if (actionCategory == null)
				{
					return false;
				}
				return actionCategory.userAssignable;
			}

			public InputLayout GetLayout(ControllerType controllerType, int layoutId)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				ControllerType controllerType2 = controllerType;
				int num = -285702492;
				goto IL_000c;
				IL_000c:
				while (true)
				{
					switch (num ^ -285702491)
					{
					case 0:
						break;
					case 3:
						return null;
					case 2:
						if (controllerType2 == ControllerType.Custom)
						{
							return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetCustomControllerLayoutById(layoutId);
						}
						throw new NotImplementedException();
					case 1:
						switch (controllerType2)
						{
						default:
							goto IL_0058;
						case ControllerType.Joystick:
							break;
						case ControllerType.Keyboard:
							return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetKeyboardLayoutById(layoutId);
						case ControllerType.Mouse:
							return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetMouseLayoutById(layoutId);
						}
						goto default;
					default:
						return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetJoystickLayoutById(layoutId);
					}
					break;
					IL_0058:
					num = -285702489;
				}
				goto IL_0007;
				IL_0007:
				num = -285702490;
				goto IL_000c;
			}

			public InputLayout GetLayout(ControllerType controllerType, string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				while (true)
				{
					switch (0x46F771A7 ^ 0x46F771A5)
					{
					case 0:
						continue;
					case 2:
						switch (controllerType)
						{
						case ControllerType.Joystick:
							break;
						case ControllerType.Keyboard:
							return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetKeyboardLayout(name);
						case ControllerType.Mouse:
							return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetMouseLayout(name);
						case ControllerType.Custom:
							return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetCustomControllerLayout(name);
						default:
							throw new NotImplementedException();
						}
						break;
					}
					break;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetJoystickLayout(name);
			}

			public int GetLayoutId(ControllerType controllerType, string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				while (true)
				{
					int num = 1766750373;
					while (true)
					{
						switch (num ^ 0x694E78A4)
						{
						case 3:
							break;
						case 1:
							switch (controllerType)
							{
							default:
								goto IL_0044;
							case ControllerType.Joystick:
								break;
							case ControllerType.Keyboard:
								return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetKeyboardLayoutId(name);
							case ControllerType.Mouse:
								return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetMouseLayoutId(name);
							case ControllerType.Custom:
								return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetCustomControllerLayoutId(name);
							}
							goto default;
						default:
							return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetJoystickLayoutId(name);
						case 2:
							throw new NotImplementedException();
						}
						break;
						IL_0044:
						num = 1766750374;
					}
				}
			}

			public InputLayout GetJoystickLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetJoystickLayoutById(layoutId);
			}

			public InputLayout GetJoystickLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetJoystickLayout(name);
			}

			public int GetJoystickLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetJoystickLayoutId(name);
			}

			public InputLayout GetKeyboardLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetKeyboardLayoutById(layoutId);
			}

			public InputLayout GetKeyboardLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetKeyboardLayout(name);
			}

			public int GetKeyboardLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetKeyboardLayoutId(name);
			}

			public InputLayout GetMouseLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetMouseLayoutById(layoutId);
			}

			public InputLayout GetMouseLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetMouseLayout(name);
			}

			public int GetMouseLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetMouseLayoutId(name);
			}

			public InputLayout GetCustomControllerLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetCustomControllerLayoutById(layoutId);
			}

			public InputLayout GetCustomControllerLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetCustomControllerLayout(name);
			}

			public int GetCustomControllerLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetCustomControllerLayoutId(name);
			}

			public IList<InputLayout> MapLayouts(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
				}
				while (true)
				{
					switch (-1143745983 ^ -1143745981)
					{
					case 0:
						continue;
					case 2:
						switch (controllerType)
						{
						case ControllerType.Joystick:
							break;
						case ControllerType.Keyboard:
							return KeyboardLayouts;
						case ControllerType.Mouse:
							return MouseLayouts;
						case ControllerType.Custom:
							return CustomControllerLayouts;
						default:
							throw new NotImplementedException();
						}
						break;
					}
					break;
				}
				return JoystickLayouts;
			}

			public InputAction GetAction(int actionId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetActionById(actionId);
			}

			public InputAction GetAction(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetAction(name);
			}

			public int GetActionId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetActionId(name);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.MmsXihBHTfkqmUtCgNWsUAsZrwU(mapCategoryName, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.MmsXihBHTfkqmUtCgNWsUAsZrwU(mapCategoryName, sort);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.MmsXihBHTfkqmUtCgNWsUAsZrwU(mapCategoryId, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.MmsXihBHTfkqmUtCgNWsUAsZrwU(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.HmJdnxGPsTHyBgPXzmCCDzLUHfh(tag);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.zWAPhlXksWPjODmFwjQkjdwKFpYO(mapCategoryId, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.zWAPhlXksWPjODmFwjQkjdwKFpYO(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.zWAPhlXksWPjODmFwjQkjdwKFpYO(mapCategoryName, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.zWAPhlXksWPjODmFwjQkjdwKFpYO(mapCategoryName, sort);
			}

			public IList<InputBehavior> GetInputBehaviors(int playerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.xAhFDuGUtlbNqDBBiBCcWEZTAixf(playerId);
			}

			public IList<InputBehavior> GetSystemPlayerInputBehaviors()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.xAhFDuGUtlbNqDBBiBCcWEZTAixf(9999999);
			}

			public InputBehavior GetInputBehavior(int playerId, int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.cvAZIXVvcDmlIQeyvbGcyaWKBPG(playerId, behaviorId);
			}

			public InputBehavior GetInputBehavior(int playerId, string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.cvAZIXVvcDmlIQeyvbGcyaWKBPG(playerId, behaviorName);
			}

			public InputBehavior GetSystemPlayerInputBehavior(int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return GetInputBehavior(9999999, behaviorId);
			}

			public InputBehavior GetSystemPlayerInputBehavior(string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return GetInputBehavior(9999999, behaviorName);
			}

			public int GetInputBehaviorId(string behaviorName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetInputBehaviorId(behaviorName);
			}

			internal InputBehavior qYFsxrqwiREGrENynyCzXdevhUS(int P_0)
			{
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetInputBehaviorById(P_0);
			}

			internal InputBehavior qYFsxrqwiREGrENynyCzXdevhUS(string P_0)
			{
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetInputBehavior(P_0);
			}

			public ControllerMap GetControllerMap(int id)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				IList<Player> allPlayers = players.AllPlayers;
				int num = 0;
				while (num < allPlayers.Count)
				{
					while (true)
					{
						ControllerMap map = allPlayers[num].controllers.maps.GetMap(id);
						if (map != null)
						{
							return map;
						}
						num++;
						int num2 = -1241793913;
						while (true)
						{
							switch (num2 ^ -1241793914)
							{
							case 0:
								num2 = -1241793916;
								continue;
							case 2:
								break;
							default:
								goto end_IL_0036;
							}
							break;
						}
						continue;
						end_IL_0036:
						break;
					}
				}
				return null;
			}

			public ActionElementMap GetActionElementMap(int id)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				IList<Player> allPlayers = players.AllPlayers;
				int num = 0;
				ActionElementMap elementMap = default(ActionElementMap);
				while (num < allPlayers.Count)
				{
					while (true)
					{
						ControllerMap map = allPlayers[num].controllers.maps.GetMap(id);
						int num2;
						if (map != null)
						{
							elementMap = map.GetElementMap(id);
							if (elementMap != null)
							{
								num2 = -271688957;
								goto IL_001d;
							}
						}
						num++;
						num2 = -271688958;
						goto IL_001d;
						IL_001d:
						while (true)
						{
							switch (num2 ^ -271688958)
							{
							case 3:
								num2 = -271688960;
								continue;
							case 2:
								break;
							case 1:
								return elementMap;
							default:
								goto end_IL_003a;
							}
							break;
						}
						continue;
						end_IL_003a:
						break;
					}
				}
				return null;
			}

			public ControllerMap GetControllerMapInstance(Controller controller, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				switch (controller.type)
				{
				case ControllerType.Joystick:
					return GetJoystickMapInstance((Joystick)controller, mapCategoryId, layoutId);
				case ControllerType.Keyboard:
					return GetKeyboardMapInstance(mapCategoryId, layoutId);
				case ControllerType.Mouse:
					return GetMouseMapInstance(mapCategoryId, layoutId);
				case ControllerType.Custom:
					return GetCustomControllerMapInstance((CustomController)controller, mapCategoryId, layoutId);
				default:
					throw new NotImplementedException();
				}
			}

			public ControllerMap GetControllerMapInstance(Controller controller, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(controller.type, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetControllerMapInstance(controller, mapCategoryId, layoutId);
			}

			public ControllerMap GetControllerMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(controllerIdentifier.controllerType, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId);
			}

			public ControllerMap GetControllerMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				Controller controller = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.YVImgJAVYrCFxvRCiDMpssMfsKM(controllerIdentifier);
				if (controller != null)
				{
					goto IL_0019;
				}
				ControllerType controllerType = controllerIdentifier.controllerType;
				int num = -334329001;
				goto IL_001e;
				IL_001e:
				while (true)
				{
					switch (num ^ -334329001)
					{
					case 4:
						break;
					case 1:
						return GetControllerMapInstance(controller, mapCategoryId, layoutId);
					case 3:
						if (controllerType == ControllerType.Custom)
						{
							return GetCustomControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId);
						}
						throw new NotImplementedException();
					case 0:
						switch (controllerType)
						{
						default:
							goto IL_0078;
						case ControllerType.Joystick:
							break;
						case ControllerType.Keyboard:
							return GetKeyboardMapInstance(mapCategoryId, layoutId);
						case ControllerType.Mouse:
							return GetMouseMapInstance(mapCategoryId, layoutId);
						}
						goto default;
					default:
						return GetJoystickMapInstance(controllerIdentifier, mapCategoryId, layoutId);
					}
					break;
					IL_0078:
					num = -334329004;
				}
				goto IL_0019;
				IL_0019:
				num = -334329002;
				goto IL_001e;
			}

			public JoystickMap GetJoystickMapInstance(Joystick joystick, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				if (joystick == null)
				{
					return null;
				}
				JoystickMap joystickMap = stWFwgAKcHRiMeUYeMbPaDXDxKKn.MOavHkrPYmurnDiDKpIsOSpvUzG(joystick, mapCategoryId, layoutId);
				int num;
				if (joystickMap != null)
				{
					joystick.BakeMap(joystickMap);
					num = 60433000;
					goto IL_000c;
				}
				goto IL_004b;
				IL_0007:
				num = 60433003;
				goto IL_000c;
				IL_000c:
				switch (num ^ 0x39A226A)
				{
				case 0:
					break;
				case 1:
					return null;
				default:
					goto IL_004b;
				}
				goto IL_0007;
				IL_004b:
				return joystickMap;
			}

			public JoystickMap GetJoystickMapInstance(Joystick joystick, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				int num = -1649918370;
				goto IL_000c;
				IL_000c:
				switch (num ^ -1649918372)
				{
				case 0:
					break;
				case 1:
					return null;
				default:
				{
					if (mapCategoryId < 0)
					{
						return null;
					}
					int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
					if (layoutId < 0)
					{
						return null;
					}
					return GetJoystickMapInstance(joystick, mapCategoryId, layoutId);
				}
				}
				goto IL_0007;
				IL_0007:
				num = -1649918371;
				goto IL_000c;
			}

			public JoystickMap GetJoystickMapInstance(Guid joystickTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (joystickTypeGuid == Guid.Empty)
				{
					goto IL_0016;
				}
				InputSource inputSourceType = MDVmwweEvHoLmOhNxpYDWbEeYJl.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = xWDCnqIoBGxYWmcirHenJdbGNrxL.sqUGKjnZXTMNHehVVcGMEExpNDnK(joystickTypeGuid, inputSourceType);
				int num;
				JoystickMap joystickMap = default(JoystickMap);
				if (hardwareJoystickMap_InputManager == null)
				{
					num = 1424075260;
				}
				else
				{
					joystickMap = stWFwgAKcHRiMeUYeMbPaDXDxKKn.vbOLdhqieuNfkwxPjTOapirSbTrK(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
					num = 1424075257;
				}
				goto IL_001b;
				IL_001b:
				ActionElementMap current = default(ActionElementMap);
				while (true)
				{
					switch (num ^ 0x54E1A9F8)
					{
					case 0:
						break;
					case 3:
						return null;
					case 1:
						if (joystickMap != null)
						{
							goto IL_0066;
						}
						goto IL_011e;
					case 4:
						Logger.LogError("No hardware map found.");
						return null;
					default:
						{
							joystickMap.controllerType = ControllerType.Joystick;
							HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
							using (IEnumerator<ActionElementMap> enumerator = joystickMap.AllMaps.GetEnumerator())
							{
								while (true)
								{
									IL_00f6:
									int num2;
									int num3;
									if (!enumerator.MoveNext())
									{
										num2 = 1424075256;
										num3 = num2;
									}
									else
									{
										num2 = 1424075257;
										num3 = num2;
									}
									while (true)
									{
										switch (num2 ^ 0x54E1A9F8)
										{
										case 4:
											num2 = 1424075257;
											continue;
										default:
											goto end_IL_00b5;
										case 1:
											current = enumerator.Current;
											num2 = 1424075259;
											continue;
										case 3:
											current.JzofFaEBuBqtMKafREtZVzuDRBD(joystickMap, hardwareControllerMap_Game);
											num2 = 1424075258;
											continue;
										case 2:
											break;
										case 0:
											goto end_IL_00b5;
										}
										goto IL_00f6;
										continue;
										end_IL_00b5:
										break;
									}
									break;
								}
							}
							goto IL_011e;
						}
						IL_011e:
						return joystickMap;
					}
					break;
					IL_0066:
					num = 1424075258;
				}
				goto IL_0016;
				IL_0016:
				num = 1424075259;
				goto IL_001b;
			}

			public JoystickMap GetJoystickMapInstance(Guid joystickTypeGuid, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (joystickTypeGuid == Guid.Empty)
				{
					goto IL_0016;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
				int num = 716850433;
				goto IL_001b;
				IL_001b:
				switch (num ^ 0x2ABA4501)
				{
				case 2:
					break;
				case 1:
					return null;
				default:
					if (layoutId < 0)
					{
						return null;
					}
					return GetJoystickMapInstance(joystickTypeGuid, mapCategoryId, layoutId);
				}
				goto IL_0016;
				IL_0016:
				num = 716850432;
				goto IL_001b;
			}

			public JoystickMap GetJoystickMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				if (controllerIdentifier.controllerType != ControllerType.Joystick)
				{
					return null;
				}
				Joystick joystick = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.YVImgJAVYrCFxvRCiDMpssMfsKM(controllerIdentifier) as Joystick;
				int num = 1327491803;
				goto IL_000c;
				IL_0007:
				num = 1327491802;
				goto IL_000c;
				IL_000c:
				while (true)
				{
					switch (num ^ 0x4F1FEAD8)
					{
					case 0:
						break;
					case 2:
						return null;
					case 3:
						if (joystick != null)
						{
							goto IL_0053;
						}
						return GetJoystickMapInstance(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
					default:
						return GetJoystickMapInstance(joystick, mapCategoryId, layoutId);
					}
					break;
					IL_0053:
					num = 1327491801;
				}
				goto IL_0007;
			}

			public JoystickMap GetJoystickMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetJoystickMapInstance(controllerIdentifier, mapCategoryId, layoutId);
			}

			public KeyboardMap GetKeyboardMapInstance(int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				KeyboardMap keyboardMap = stWFwgAKcHRiMeUYeMbPaDXDxKKn.FindKeyboardMap_Game(mapCategoryId, layoutId);
				if (keyboardMap != null)
				{
					controllers.Keyboard.BakeMap(keyboardMap);
				}
				return keyboardMap;
			}

			public KeyboardMap GetKeyboardMapInstance(string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Keyboard, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetKeyboardMapInstance(mapCategoryId, layoutId);
			}

			public MouseMap GetMouseMapInstance(int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				MouseMap mouseMap = stWFwgAKcHRiMeUYeMbPaDXDxKKn.FindMouseMap_Game(mapCategoryId, layoutId);
				if (mouseMap != null)
				{
					while (true)
					{
						int num = -569028063;
						while (true)
						{
							switch (num ^ -569028061)
							{
							case 0:
								break;
							case 2:
								controllers.Mouse.BakeMap(mouseMap);
								num = -569028062;
								continue;
							default:
								goto end_IL_0019;
							}
							break;
						}
						continue;
						end_IL_0019:
						break;
					}
				}
				return mouseMap;
			}

			public MouseMap GetMouseMapInstance(string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Mouse, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetMouseMapInstance(mapCategoryId, layoutId);
			}

			public CustomControllerMap GetCustomControllerMapInstance(CustomController customController, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomControllerMap customControllerMap = stWFwgAKcHRiMeUYeMbPaDXDxKKn.lejMVaByLdOJVLWYjPmUyMBPIzJ(customController.sourceControllerId, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					customController.BakeMap(customControllerMap);
				}
				return customControllerMap;
			}

			public CustomControllerMap GetCustomControllerMapInstance(CustomController customController, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
			}

			public CustomControllerMap GetCustomControllerMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				if (controllerIdentifier.controllerType != ControllerType.Custom)
				{
					return null;
				}
				CustomController customController = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.YVImgJAVYrCFxvRCiDMpssMfsKM(controllerIdentifier) as CustomController;
				if (customController != null)
				{
					return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
				}
				int num;
				CustomController_Editor customControllerByHardwareTypeGuid = default(CustomController_Editor);
				CustomControllerMap customControllerMap = default(CustomControllerMap);
				if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
				{
					num = 594131777;
				}
				else
				{
					customControllerByHardwareTypeGuid = stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
					if (customControllerByHardwareTypeGuid == null)
					{
						return null;
					}
					customControllerMap = stWFwgAKcHRiMeUYeMbPaDXDxKKn.lejMVaByLdOJVLWYjPmUyMBPIzJ(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
					num = 594131778;
				}
				goto IL_000c;
				IL_0007:
				num = 594131776;
				goto IL_000c;
				IL_000c:
				while (true)
				{
					switch (num ^ 0x2369BB43)
					{
					case 0:
						break;
					case 3:
						return null;
					case 2:
						return null;
					case 1:
						if (customControllerMap != null)
						{
							HardwareControllerMap_Game hardwareControllerMap_Game = customControllerByHardwareTypeGuid.fSqpRPKmvZEbSyvCnabcPGncEMe();
							if (hardwareControllerMap_Game == null)
							{
								goto IL_00bf;
							}
							customControllerMap.controllerType = ControllerType.Custom;
							using (IEnumerator<ActionElementMap> enumerator = customControllerMap.AllMaps.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										ActionElementMap current = enumerator.Current;
										current.JzofFaEBuBqtMKafREtZVzuDRBD(customControllerMap, hardwareControllerMap_Game);
										int num2 = 594131778;
										while (true)
										{
											switch (num2 ^ 0x2369BB43)
											{
											case 0:
												num2 = 594131777;
												continue;
											case 2:
												break;
											default:
												goto end_IL_010a;
											}
											break;
										}
										continue;
										end_IL_010a:
										break;
									}
								}
							}
						}
						return customControllerMap;
					default:
						Logger.LogError("No hardware map found.");
						return null;
					}
					break;
					IL_00bf:
					num = 594131783;
				}
				goto IL_0007;
			}

			public CustomControllerMap GetCustomControllerMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetCustomControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId);
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, Controller controller, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					goto IL_000f;
				}
				ControllerMap controllerMap = null;
				IControllerMapStore controllerMapStore = userDataStore as IControllerMapStore;
				int num = -1285367411;
				goto IL_0014;
				IL_0014:
				Player player = default(Player);
				while (true)
				{
					switch (num ^ -1285367415)
					{
					case 5:
						break;
					case 7:
					{
						player = players.GetPlayer(playerId);
						int num4;
						if (player != null)
						{
							num = -1285367424;
							num4 = num;
						}
						else
						{
							num = -1285367409;
							num4 = num;
						}
						continue;
					}
					case 10:
					{
						int num3;
						if (controllerMap != null)
						{
							num = -1285367410;
							num3 = num;
						}
						else
						{
							num = -1285367413;
							num3 = num;
						}
						continue;
					}
					case 9:
						player.controllers.maps.jZadHWPKxcbwLCLdbfhcWUbXxxY(controller, controllerMap);
						num = -1285367415;
						continue;
					case 8:
					{
						int num2;
						if (controllerMap != null)
						{
							num = -1285367421;
							num2 = num;
						}
						else
						{
							num = -1285367414;
							num2 = num;
						}
						continue;
					}
					case 4:
						if (controllerMapStore != null)
						{
							controllerMap = controllerMapStore.LoadControllerMap(playerId, controller.identifier, mapCategoryId, layoutId);
							num = -1285367423;
							continue;
						}
						goto case 8;
					case 3:
						controllerMap = stWFwgAKcHRiMeUYeMbPaDXDxKKn.pbhAUzedVzeaQbVkyiUIXosZYPA(controller, mapCategoryId, layoutId);
						num = -1285367421;
						continue;
					case 6:
						controller.BakeMap(controllerMap);
						num = -1285367413;
						continue;
					case 0:
						num = -1285367413;
						continue;
					case 1:
						return null;
					default:
						return controllerMap;
					}
					break;
				}
				goto IL_000f;
				IL_000f:
				num = -1285367416;
				goto IL_0014;
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, Controller controller, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(controller.type, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetControllerMapInstanceSavedOrDefault(playerId, controller, mapCategoryId, layoutId);
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					while (true)
					{
						switch (0x5A4B1A3F ^ 0x5A4B1A3E)
						{
						case 2:
							continue;
						case 1:
							return null;
						}
						break;
					}
				}
				else
				{
					switch (controllerIdentifier.controllerType)
					{
					case ControllerType.Joystick:
						break;
					case ControllerType.Custom:
						return GetCustomControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
					case ControllerType.Keyboard:
						return GetKeyboardMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
					case ControllerType.Mouse:
						return GetMouseMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
					default:
						throw new NotImplementedException();
					}
				}
				return GetJoystickMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				int num = 2012249528;
				goto IL_000c;
				IL_000c:
				switch (num ^ 0x77F07DB8)
				{
				case 2:
					break;
				case 1:
					return null;
				default:
				{
					if (mapCategoryId < 0)
					{
						return null;
					}
					int layoutId = GetLayoutId(controllerIdentifier.controllerType, layoutName);
					if (layoutId < 0)
					{
						return null;
					}
					return GetControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
				}
				}
				goto IL_0007;
				IL_0007:
				num = 2012249529;
				goto IL_000c;
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, Joystick joystick, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return GetControllerMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId) as JoystickMap;
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, Joystick joystick, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				Joystick joystick = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.YVImgJAVYrCFxvRCiDMpssMfsKM(controllerIdentifier) as Joystick;
				if (joystick != null)
				{
					return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
				}
				InputSource inputSourceType = MDVmwweEvHoLmOhNxpYDWbEeYJl.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = xWDCnqIoBGxYWmcirHenJdbGNrxL.sqUGKjnZXTMNHehVVcGMEExpNDnK(controllerIdentifier.hardwareTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					goto IL_004e;
				}
				JoystickMap joystickMap = null;
				IControllerMapStore controllerMapStore = userDataStore as IControllerMapStore;
				int num = 1899962724;
				goto IL_0053;
				IL_004e:
				num = 1899962726;
				goto IL_0053;
				IL_0053:
				HardwareControllerMap_Game hardwareControllerMap_Game = default(HardwareControllerMap_Game);
				while (true)
				{
					switch (num ^ 0x713F2163)
					{
					case 2:
						break;
					case 6:
						joystickMap.playerId = playerId;
						num = 1899962720;
						continue;
					case 4:
						if (joystickMap == null)
						{
							joystickMap = stWFwgAKcHRiMeUYeMbPaDXDxKKn.vbOLdhqieuNfkwxPjTOapirSbTrK(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
							num = 1899962722;
							continue;
						}
						goto case 1;
					case 7:
						if (controllerMapStore != null)
						{
							joystickMap = controllerMapStore.LoadControllerMap(playerId, controllerIdentifier, mapCategoryId, layoutId) as JoystickMap;
							num = 1899962727;
							continue;
						}
						goto case 4;
					case 3:
						hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
						num = 1899962723;
						continue;
					case 5:
						Logger.LogError("No hardware map found.");
						return null;
					case 1:
						if (joystickMap != null)
						{
							joystickMap.controllerType = ControllerType.Joystick;
							int num3;
							if (players.GetPlayer(playerId) == null)
							{
								num = 1899962720;
								num3 = num;
							}
							else
							{
								num = 1899962725;
								num3 = num;
							}
							continue;
						}
						goto IL_018e;
					default:
						{
							using (IEnumerator<ActionElementMap> enumerator = joystickMap.AllMaps.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										ActionElementMap current = enumerator.Current;
										current.JzofFaEBuBqtMKafREtZVzuDRBD(joystickMap, hardwareControllerMap_Game);
										int num2 = 1899962721;
										while (true)
										{
											switch (num2 ^ 0x713F2163)
											{
											case 0:
												num2 = 1899962722;
												continue;
											case 1:
												break;
											default:
												goto end_IL_015d;
											}
											break;
										}
										continue;
										end_IL_015d:
										break;
									}
								}
							}
							goto IL_018e;
						}
						IL_018e:
						return joystickMap;
					}
					break;
				}
				goto IL_004e;
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
				int num;
				if (layoutId < 0)
				{
					num = -896089741;
					goto IL_000c;
				}
				return GetJoystickMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
				IL_000c:
				switch (num ^ -896089741)
				{
				case 2:
					break;
				case 1:
					return null;
				default:
					return null;
				}
				goto IL_0007;
				IL_0007:
				num = -896089742;
				goto IL_000c;
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, CustomController customController, int mapCategoryId, int layoutId)
			{
				return GetControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId) as CustomControllerMap;
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, CustomController customController, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomController customController = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.YVImgJAVYrCFxvRCiDMpssMfsKM(controllerIdentifier) as CustomController;
				if (customController != null)
				{
					goto IL_001e;
				}
				CustomController_Editor customControllerByHardwareTypeGuid = stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				int num;
				CustomControllerMap customControllerMap = default(CustomControllerMap);
				if (customControllerByHardwareTypeGuid == null)
				{
					num = 2029956171;
				}
				else
				{
					customControllerMap = null;
					IControllerMapStore controllerMapStore = userDataStore as IControllerMapStore;
					if (controllerMapStore == null)
					{
						goto IL_00c4;
					}
					customControllerMap = controllerMapStore.LoadControllerMap(playerId, controllerIdentifier, mapCategoryId, layoutId) as CustomControllerMap;
					num = 2029956175;
				}
				goto IL_0023;
				IL_0023:
				HardwareControllerMap_Game hardwareControllerMap_Game = default(HardwareControllerMap_Game);
				while (true)
				{
					switch (num ^ 0x78FEAC4E)
					{
					case 0:
						break;
					case 3:
						return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
					case 4:
						customControllerMap = stWFwgAKcHRiMeUYeMbPaDXDxKKn.lejMVaByLdOJVLWYjPmUyMBPIzJ(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
						num = 2029956172;
						continue;
					case 5:
						return null;
					case 1:
						goto IL_00c4;
					case 2:
						goto IL_00db;
					case 7:
						return null;
					default:
						goto IL_0129;
					}
					break;
					IL_00db:
					if (customControllerMap != null)
					{
						hardwareControllerMap_Game = customControllerByHardwareTypeGuid.fSqpRPKmvZEbSyvCnabcPGncEMe();
						if (hardwareControllerMap_Game == null)
						{
							Logger.LogError("No hardware map found.");
							num = 2029956169;
							continue;
						}
						customControllerMap.controllerType = ControllerType.Custom;
						if (players.GetPlayer(playerId) != null)
						{
							customControllerMap.playerId = playerId;
							num = 2029956168;
							continue;
						}
						goto IL_0129;
					}
					goto IL_019c;
					IL_0129:
					using (IEnumerator<ActionElementMap> enumerator = customControllerMap.AllMaps.GetEnumerator())
					{
						while (true)
						{
							IL_0174:
							int num2;
							int num3;
							if (!enumerator.MoveNext())
							{
								num2 = 2029956174;
								num3 = num2;
							}
							else
							{
								num2 = 2029956172;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ 0x78FEAC4E)
								{
								case 3:
									num2 = 2029956172;
									continue;
								default:
									goto end_IL_013d;
								case 2:
								{
									ActionElementMap current = enumerator.Current;
									current.JzofFaEBuBqtMKafREtZVzuDRBD(customControllerMap, hardwareControllerMap_Game);
									num2 = 2029956175;
									continue;
								}
								case 1:
									break;
								case 0:
									goto end_IL_013d;
								}
								goto IL_0174;
								continue;
								end_IL_013d:
								break;
							}
							break;
						}
					}
					goto IL_019c;
					IL_019c:
					return customControllerMap;
				}
				goto IL_001e;
				IL_001e:
				num = 2029956173;
				goto IL_0023;
				IL_00c4:
				int num4;
				if (customControllerMap != null)
				{
					num = 2029956172;
					num4 = num;
				}
				else
				{
					num = 2029956170;
					num4 = num;
				}
				goto IL_0023;
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				int layoutId = default(int);
				while (true)
				{
					int num = 738172824;
					while (true)
					{
						switch (num ^ 0x2BFF9F9B)
						{
						case 0:
							break;
						case 3:
							if (mapCategoryId < 0)
							{
								return null;
							}
							layoutId = GetLayoutId(ControllerType.Custom, layoutName);
							num = 738172825;
							continue;
						case 2:
							if (layoutId < 0)
							{
								num = 738172826;
								continue;
							}
							return GetCustomControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
						default:
							return null;
						}
						break;
					}
				}
			}

			public KeyboardMap GetKeyboardMapInstanceSavedOrDefault(int playerId, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				Controller keyboard = controllers.Keyboard;
				KeyboardMap keyboardMap = null;
				IControllerMapStore controllerMapStore = userDataStore as IControllerMapStore;
				Player player = default(Player);
				while (true)
				{
					int num = -799637978;
					while (true)
					{
						switch (num ^ -799637983)
						{
						case 8:
							break;
						case 2:
							if (keyboardMap != null)
							{
								player = players.GetPlayer(playerId);
								num = -799637984;
								continue;
							}
							goto default;
						case 1:
							if (player != null)
							{
								player.controllers.maps.jZadHWPKxcbwLCLdbfhcWUbXxxY(keyboard, keyboardMap);
								num = -799637980;
								continue;
							}
							goto case 3;
						case 5:
							num = -799637983;
							continue;
						case 4:
						{
							int num3;
							if (keyboardMap == null)
							{
								num = -799637976;
								num3 = num;
							}
							else
							{
								num = -799637981;
								num3 = num;
							}
							continue;
						}
						case 9:
							keyboardMap = stWFwgAKcHRiMeUYeMbPaDXDxKKn.FindKeyboardMap_Game(mapCategoryId, layoutId);
							num = -799637981;
							continue;
						case 3:
							keyboard.BakeMap(keyboardMap);
							num = -799637983;
							continue;
						case 7:
						{
							int num2;
							if (controllerMapStore != null)
							{
								num = -799637977;
								num2 = num;
							}
							else
							{
								num = -799637979;
								num2 = num;
							}
							continue;
						}
						case 6:
							keyboardMap = controllerMapStore.LoadControllerMap(playerId, keyboard.identifier, mapCategoryId, layoutId) as KeyboardMap;
							num = -799637979;
							continue;
						default:
							return keyboardMap;
						}
						break;
					}
				}
			}

			public KeyboardMap GetKeyboardMapInstanceSavedOrDefault(int playerId, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				int layoutId = default(int);
				while (true)
				{
					int num = -313726131;
					while (true)
					{
						switch (num ^ -313726129)
						{
						case 0:
							break;
						case 2:
							if (mapCategoryId >= 0)
							{
								goto IL_0035;
							}
							return null;
						default:
							if (layoutId < 0)
							{
								return null;
							}
							return GetKeyboardMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
						}
						break;
						IL_0035:
						layoutId = GetLayoutId(ControllerType.Keyboard, layoutName);
						num = -313726130;
					}
				}
			}

			public MouseMap GetMouseMapInstanceSavedOrDefault(int playerId, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				Controller mouse = controllers.Mouse;
				MouseMap mouseMap = default(MouseMap);
				Player player = default(Player);
				while (true)
				{
					int num = 1314760054;
					while (true)
					{
						switch (num ^ 0x4E5DA573)
						{
						case 0:
							break;
						case 4:
							mouse.BakeMap(mouseMap);
							num = 1314760053;
							continue;
						case 3:
							mouseMap = stWFwgAKcHRiMeUYeMbPaDXDxKKn.FindMouseMap_Game(mapCategoryId, layoutId);
							num = 1314760049;
							continue;
						case 1:
							player.controllers.maps.jZadHWPKxcbwLCLdbfhcWUbXxxY(mouse, mouseMap);
							num = 1314760053;
							continue;
						case 5:
						{
							mouseMap = null;
							IControllerMapStore controllerMapStore = userDataStore as IControllerMapStore;
							if (controllerMapStore != null)
							{
								mouseMap = controllerMapStore.LoadControllerMap(playerId, mouse.identifier, mapCategoryId, layoutId) as MouseMap;
								num = 1314760052;
								continue;
							}
							goto case 7;
						}
						case 7:
						{
							int num3;
							if (mouseMap != null)
							{
								num = 1314760049;
								num3 = num;
							}
							else
							{
								num = 1314760048;
								num3 = num;
							}
							continue;
						}
						case 2:
							if (mouseMap != null)
							{
								player = players.GetPlayer(playerId);
								int num2;
								if (player != null)
								{
									num = 1314760050;
									num2 = num;
								}
								else
								{
									num = 1314760055;
									num2 = num;
								}
								continue;
							}
							goto default;
						default:
							return mouseMap;
						}
						break;
					}
				}
			}

			public MouseMap GetMouseMapInstanceSavedOrDefault(int playerId, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				while (true)
				{
					int num = -854090042;
					while (true)
					{
						switch (num ^ -854090041)
						{
						case 2:
							break;
						case 1:
						{
							if (mapCategoryId < 0)
							{
								return null;
							}
							int layoutId = GetLayoutId(ControllerType.Mouse, layoutName);
							if (layoutId < 0)
							{
								goto IL_0042;
							}
							return GetMouseMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
						}
						default:
							return null;
						}
						break;
						IL_0042:
						num = -854090041;
					}
				}
			}

			[Obsolete("This method has been deprecated. Use the Controller Template system instead.", false)]
			public ControllerElementIdentifier GetFirstJoystickTemplateElementIdentifier(Joystick joystick, int joystickElementIdentifierId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (joystick == null)
				{
					return null;
				}
				return WhDeUxPrsOgrEHWkzdrHUJUQwmi(joystick.hardwareTypeGuid, joystickElementIdentifierId);
			}

			private ControllerElementIdentifier WhDeUxPrsOgrEHWkzdrHUJUQwmi(Guid P_0, int P_1)
			{
				ControllerTemplateElementIdentifier controllerTemplateElementIdentifier = xWDCnqIoBGxYWmcirHenJdbGNrxL.WhDeUxPrsOgrEHWkzdrHUJUQwmi(P_0, P_1);
				while (true)
				{
					int num = -326028679;
					while (true)
					{
						switch (num ^ -326028680)
						{
						case 2:
							break;
						case 1:
							if (controllerTemplateElementIdentifier != null)
							{
								goto IL_002e;
							}
							return null;
						default:
							return controllerTemplateElementIdentifier.ToControllerElementIdentifier();
						}
						break;
						IL_002e:
						num = -326028680;
					}
				}
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn.LhDbrTpfSYSBdULgTcMMBVEnYVi(templateTypeGuid, mapCategoryId, layoutId);
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
				int num;
				if (layoutId < 0)
				{
					num = -480573810;
					goto IL_000c;
				}
				return GetControllerTemplateMapInstance(templateTypeGuid, mapCategoryId, layoutId);
				IL_000c:
				switch (num ^ -480573809)
				{
				case 0:
					break;
				case 2:
					return null;
				default:
					return null;
				}
				goto IL_0007;
				IL_0007:
				num = -480573811;
				goto IL_000c;
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(int id)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManagerRuleSetById = stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetControllerMapLayoutManagerRuleSetById(id);
				if (controllerMapLayoutManagerRuleSetById == null)
				{
					return null;
				}
				return controllerMapLayoutManagerRuleSetById.ToRuntime();
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapLayoutManagerRuleSetId = stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetControllerMapLayoutManagerRuleSetId(name);
				if (controllerMapLayoutManagerRuleSetId < 0)
				{
					return null;
				}
				return GetControllerMapLayoutManagerRuleSetInstance(controllerMapLayoutManagerRuleSetId);
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(int id)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				ControllerMapEnabler_RuleSet_Editor controllerMapEnablerRuleSetById = stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetControllerMapEnablerRuleSetById(id);
				if (controllerMapEnablerRuleSetById == null)
				{
					return null;
				}
				return controllerMapEnablerRuleSetById.ToRuntime();
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapEnablerRuleSetId = stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetControllerMapEnablerRuleSetId(name);
				if (controllerMapEnablerRuleSetId < 0)
				{
					return null;
				}
				return GetControllerMapEnablerRuleSetInstance(controllerMapEnablerRuleSetId);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class PlayerHelper : CodeHelper
		{
			private static PlayerHelper VLHBdfuObcdunicAbIHFTExpsoBB;

			internal static PlayerHelper Instance
			{
				get
				{
					return VLHBdfuObcdunicAbIHFTExpsoBB ?? (VLHBdfuObcdunicAbIHFTExpsoBB = new PlayerHelper());
				}
			}

			public int playerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return lGcKTymIVPnyTtnJFgbcUzeJcSS.gamePlayerCount;
				}
			}

			public int allPlayerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return lGcKTymIVPnyTtnJFgbcUzeJcSS.allPlayerCount;
				}
			}

			public IList<Player> Players
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<Player>.EmptyReadOnlyIListT;
					}
					return lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly;
				}
			}

			public IList<Player> AllPlayers
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<Player>.EmptyReadOnlyIListT;
					}
					return lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly;
				}
			}

			public Player SystemPlayer
			{
				get
				{
					if (!CheckInitialized())
					{
						return null;
					}
					return lGcKTymIVPnyTtnJFgbcUzeJcSS.ljtfDbQTnJBHJAjJCIcaEvxvpwaG();
				}
			}

			private PlayerHelper()
			{
			}

			public IList<Player> GetPlayers(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Player>.EmptyReadOnlyIListT;
				}
				if (!includeSystemPlayer)
				{
					return lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_readOnly;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_readOnly;
			}

			public Player GetPlayer(int playerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.mGsUlCssxNPJpaIPjZSPUkhxHGhB(playerId);
			}

			public Player GetPlayer(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.mGsUlCssxNPJpaIPjZSPUkhxHGhB(name);
			}

			public Player GetSystemPlayer()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.ljtfDbQTnJBHJAjJCIcaEvxvpwaG();
			}

			public int GetPlayerId(string playerName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.XSCtpmrqXBUIycVInefrNruehMM(playerName);
			}

			public string[] GetPlayerNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.YpdbiuOmOQsgxEcOhfXveQbmFWh(includeSystemPlayer);
			}

			public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.QLgzmRkyCnoNmpIwXoAWCqfFHSSi(includeSystemPlayer);
			}

			public int[] GetPlayerIds(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<int>.array;
				}
				return lGcKTymIVPnyTtnJFgbcUzeJcSS.OsrlGCQObivPULPnIdxJGNUuYik(includeSystemPlayer);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper VLHBdfuObcdunicAbIHFTExpsoBB;

			internal static TimeHelper Instance
			{
				get
				{
					return VLHBdfuObcdunicAbIHFTExpsoBB ?? (VLHBdfuObcdunicAbIHFTExpsoBB = new TimeHelper());
				}
			}

			public float unscaledDeltaTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0f;
					}
					return QPtGmChyFMyzZlDENzpxpKkvdDfb.unscaledDeltaTime;
				}
			}

			public float unscaledTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0f;
					}
					return QPtGmChyFMyzZlDENzpxpKkvdDfb.unscaledTime;
				}
			}

			public uint currentFrame
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0u;
					}
					return QPtGmChyFMyzZlDENzpxpKkvdDfb.frame;
				}
			}

			private TimeHelper()
			{
			}
		}

		private class pcdrTgzsTsbzYzupVYcCrhXwihd
		{
			private class HykskuAACOgbylzOCCbLGkoEclp
			{
				public readonly UpdateLoopType NigWaDmPBoxUjERAcsoKpawNrzS;

				private float ZLszVLHJDuxaDhIIlAyiUZMJSMR;

				private float LvqlwXuxBAdDtEBRvfjIcsckRIUp;

				private float oodscuzZOTZCQfWWmuRfPatWVPV;

				private float HBxsSRVkfBQOnpUnWFRXWSPplII;

				private uint BekOLUctVYIZbjbVUTbFFiiCaux;

				private uint EGFaptLkqtJzpyvYtvWuLdjyApI;

				private float teYMZwGyQmwIAuDYqDMpHBsFnsz;

				private float OaSJMZoICIHCxoQydixcKnyiMP;

				public float unscaledTime
				{
					get
					{
						return ZLszVLHJDuxaDhIIlAyiUZMJSMR;
					}
				}

				public float unscaledTimePrev
				{
					get
					{
						return LvqlwXuxBAdDtEBRvfjIcsckRIUp;
					}
				}

				public float unscaledDeltaTime
				{
					get
					{
						return oodscuzZOTZCQfWWmuRfPatWVPV;
					}
				}

				public uint frame
				{
					get
					{
						return BekOLUctVYIZbjbVUTbFFiiCaux;
					}
				}

				public uint framePrev
				{
					get
					{
						return EGFaptLkqtJzpyvYtvWuLdjyApI;
					}
				}

				public float unityUnscaledDeltaTime
				{
					get
					{
						return teYMZwGyQmwIAuDYqDMpHBsFnsz;
					}
				}

				public float unityUnscaledDeltaTimePrev
				{
					get
					{
						return OaSJMZoICIHCxoQydixcKnyiMP;
					}
				}

				public HykskuAACOgbylzOCCbLGkoEclp(UpdateLoopType updateLoop)
				{
					NigWaDmPBoxUjERAcsoKpawNrzS = updateLoop;
					HBxsSRVkfBQOnpUnWFRXWSPplII = Time.realtimeSinceStartup;
					BekOLUctVYIZbjbVUTbFFiiCaux = 0u;
				}

				public void rdEJYvExbWYUXSDuseVgzyXPBhA()
				{
					LvqlwXuxBAdDtEBRvfjIcsckRIUp = ZLszVLHJDuxaDhIIlAyiUZMJSMR;
					ZLszVLHJDuxaDhIIlAyiUZMJSMR = ReInput.realTime;
					if (HBxsSRVkfBQOnpUnWFRXWSPplII > ZLszVLHJDuxaDhIIlAyiUZMJSMR)
					{
						HBxsSRVkfBQOnpUnWFRXWSPplII = 0f;
						goto IL_0030;
					}
					goto IL_0059;
					IL_0059:
					oodscuzZOTZCQfWWmuRfPatWVPV = ZLszVLHJDuxaDhIIlAyiUZMJSMR - HBxsSRVkfBQOnpUnWFRXWSPplII;
					HBxsSRVkfBQOnpUnWFRXWSPplII = ZLszVLHJDuxaDhIIlAyiUZMJSMR;
					int num = 375013369;
					goto IL_0035;
					IL_0030:
					num = 375013368;
					goto IL_0035;
					IL_0035:
					while (true)
					{
						switch (num ^ 0x165A3FF9)
						{
						case 3:
							break;
						default:
							return;
						case 1:
							goto IL_0059;
						case 2:
							currentFrame = BekOLUctVYIZbjbVUTbFFiiCaux;
							ReInput.unscaledTime = ZLszVLHJDuxaDhIIlAyiUZMJSMR;
							ReInput.unscaledTimePrev = LvqlwXuxBAdDtEBRvfjIcsckRIUp;
							ReInput.unscaledDeltaTime = oodscuzZOTZCQfWWmuRfPatWVPV;
							num = 375013373;
							continue;
						case 0:
							EGFaptLkqtJzpyvYtvWuLdjyApI = BekOLUctVYIZbjbVUTbFFiiCaux;
							BekOLUctVYIZbjbVUTbFFiiCaux = MiscTools.Tick(BekOLUctVYIZbjbVUTbFFiiCaux);
							OaSJMZoICIHCxoQydixcKnyiMP = teYMZwGyQmwIAuDYqDMpHBsFnsz;
							teYMZwGyQmwIAuDYqDMpHBsFnsz = XBhsGGLkGfwRCMSrvfILgkYnaKK();
							previousFrame = EGFaptLkqtJzpyvYtvWuLdjyApI;
							num = 375013371;
							continue;
						case 4:
							return;
						}
						break;
					}
					goto IL_0030;
				}
			}

			private static class NClkxUQLTirvmImRBdWovGGKejzj
			{
				public static StopwatchBase Global
				{
					get
					{
						if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
						{
							return UnityStopwatch.Global;
						}
						return Rewired.Utils.Classes.Utility.Stopwatch.Global;
					}
				}

				public static StopwatchBase rHXUBQoqejbkONabpWgwEqatBJ()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return new UnityStopwatch();
					}
					return new Rewired.Utils.Classes.Utility.Stopwatch();
				}

				public static StopwatchBase HlNHhesguOZROjbSjJHCuHgQyAO()
				{
					if (!UnityTools.isEditor)
					{
						while (true)
						{
							int num = -1988307560;
							while (true)
							{
								switch (num ^ -1988307558)
								{
								case 0:
									break;
								case 2:
									goto IL_0025;
								default:
									return UnityStopwatch.StartNew();
								}
								break;
								IL_0025:
								if (UnityTools.platform != Platform.XboxOne)
								{
									goto end_IL_0007;
								}
								num = -1988307557;
							}
							continue;
							end_IL_0007:
							break;
						}
					}
					return Rewired.Utils.Classes.Utility.Stopwatch.StartNew();
				}
			}

			private StopwatchBase fPDsJIenxIEjmkGhfJvSrBvvaGd;

			private float wKiDTrISwajkTvYlFkFhooeJNLZ;

			private HykskuAACOgbylzOCCbLGkoEclp CocIKimTTrdTKSqdFISqfdbYuCW;

			private ADictionary<int, HykskuAACOgbylzOCCbLGkoEclp> vCdZDkqLtRtndkeVVsCRRMOYabKJ;

			private uint MIqguUzjErdjCOKrbWQEoBEhDok;

			public float unscaledTime
			{
				get
				{
					return CocIKimTTrdTKSqdFISqfdbYuCW.unscaledTime;
				}
			}

			public float unscaledTimePrev
			{
				get
				{
					return CocIKimTTrdTKSqdFISqfdbYuCW.unscaledTimePrev;
				}
			}

			public float unscaledDeltaTime
			{
				get
				{
					return CocIKimTTrdTKSqdFISqfdbYuCW.unscaledDeltaTime;
				}
			}

			public float unityUnscaledDeltaTime
			{
				get
				{
					return CocIKimTTrdTKSqdFISqfdbYuCW.unityUnscaledDeltaTime;
				}
			}

			public float unityUnscaledDeltaTimePrev
			{
				get
				{
					return CocIKimTTrdTKSqdFISqfdbYuCW.unityUnscaledDeltaTimePrev;
				}
			}

			public float realTime
			{
				get
				{
					return (float)fPDsJIenxIEjmkGhfJvSrBvvaGd.elapsedSeconds + wKiDTrISwajkTvYlFkFhooeJNLZ;
				}
			}

			public uint frame
			{
				get
				{
					return CocIKimTTrdTKSqdFISqfdbYuCW.frame;
				}
			}

			public uint framePrev
			{
				get
				{
					return CocIKimTTrdTKSqdFISqfdbYuCW.framePrev;
				}
			}

			public uint absFrame
			{
				get
				{
					return MIqguUzjErdjCOKrbWQEoBEhDok;
				}
			}

			public pcdrTgzsTsbzYzupVYcCrhXwihd()
			{
				fPDsJIenxIEjmkGhfJvSrBvvaGd = NClkxUQLTirvmImRBdWovGGKejzj.Global;
				xaGVjRxEvIdELjjBskoGFDUNmrm();
			}

			public void pPKdlVLEVRHZKFBPMTgIJXIaZTX()
			{
				wKiDTrISwajkTvYlFkFhooeJNLZ = Time.realtimeSinceStartup;
			}

			public void xaGVjRxEvIdELjjBskoGFDUNmrm()
			{
				CocIKimTTrdTKSqdFISqfdbYuCW = null;
				vCdZDkqLtRtndkeVVsCRRMOYabKJ = new ADictionary<int, HykskuAACOgbylzOCCbLGkoEclp>();
				using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
				{
					List<UpdateLoopType> list = tList.list;
					EnumConverter.ToUpdateLoopTypes((UpdateLoopSetting)2147483647, list);
					int num = 0;
					while (num < list.Count)
					{
						while (true)
						{
							HykskuAACOgbylzOCCbLGkoEclp hykskuAACOgbylzOCCbLGkoEclp = new HykskuAACOgbylzOCCbLGkoEclp(list[num]);
							int num2 = 899512567;
							while (true)
							{
								switch (num2 ^ 0x359D78F4)
								{
								case 2:
									num2 = 899512561;
									continue;
								case 4:
									if (CocIKimTTrdTKSqdFISqfdbYuCW == null)
									{
										CocIKimTTrdTKSqdFISqfdbYuCW = hykskuAACOgbylzOCCbLGkoEclp;
										num2 = 899512564;
										continue;
									}
									goto case 0;
								case 3:
									vCdZDkqLtRtndkeVVsCRRMOYabKJ.Add((int)list[num], hykskuAACOgbylzOCCbLGkoEclp);
									num2 = 899512560;
									continue;
								case 5:
									break;
								case 0:
									num++;
									num2 = 899512565;
									continue;
								default:
									goto end_IL_008a;
								}
								break;
							}
							continue;
							end_IL_008a:
							break;
						}
					}
				}
			}

			public void rdEJYvExbWYUXSDuseVgzyXPBhA(UpdateLoopType P_0)
			{
				if (CocIKimTTrdTKSqdFISqfdbYuCW.NigWaDmPBoxUjERAcsoKpawNrzS != P_0)
				{
					CocIKimTTrdTKSqdFISqfdbYuCW = vCdZDkqLtRtndkeVVsCRRMOYabKJ[(int)P_0];
					goto IL_0020;
				}
				goto IL_0042;
				IL_005b:
				CocIKimTTrdTKSqdFISqfdbYuCW.rdEJYvExbWYUXSDuseVgzyXPBhA();
				int num = 790533973;
				goto IL_0025;
				IL_0020:
				num = 790533975;
				goto IL_0025;
				IL_0025:
				switch (num ^ 0x2F1E9756)
				{
				case 2:
					break;
				case 1:
					goto IL_0042;
				case 0:
					goto IL_005b;
				default:
					MIqguUzjErdjCOKrbWQEoBEhDok = MiscTools.Tick(MIqguUzjErdjCOKrbWQEoBEhDok);
					ReInput.absFrame = MIqguUzjErdjCOKrbWQEoBEhDok;
					return;
				}
				goto IL_0020;
				IL_0042:
				if (P_0 == UpdateLoopType.OnGUI && Event.current.rawType != EventType.Layout)
				{
					return;
				}
				goto IL_005b;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch VLHBdfuObcdunicAbIHFTExpsoBB;

			internal static UnityTouch Instance
			{
				get
				{
					return VLHBdfuObcdunicAbIHFTExpsoBB ?? (VLHBdfuObcdunicAbIHFTExpsoBB = new UnityTouch());
				}
			}

			public int touchCount
			{
				get
				{
					return Input.touchCount;
				}
			}

			public Touch[] touches
			{
				get
				{
					return Input.touches;
				}
			}

			public bool simulateMouseWithTouches
			{
				get
				{
					return Input.simulateMouseWithTouches;
				}
				set
				{
					Input.simulateMouseWithTouches = value;
				}
			}

			public bool multiTouchEnabled
			{
				get
				{
					return Input.multiTouchEnabled;
				}
				set
				{
					Input.multiTouchEnabled = value;
				}
			}

			private UnityTouch()
			{
			}

			public Touch GetTouch(int index)
			{
				return Input.GetTouch(index);
			}
		}

		internal class GigsgPepzmbLEqiYuZngCILzefXc
		{
			public readonly ValueWatcher<bool> GWofaMEDvQsTFZRKVjOQjsEXlnlQ;

			public readonly ValueWatcher<bool> KxMFnVhrvWePdEFocFhJZJavPDPm;

			public readonly ValueWatcher<bool> tuePXEXCllLWVEsrShnUubANHkoJ;

			public readonly ValueWatcher<int> lZADyAaQIBGYNaQOEzrFKhsPUMe;

			public readonly ValueWatcher<float> kSDReLSYweLZZvBfBIpurrNInte;

			public readonly ValueWatcher<string> OhYEFIeVBMhhNepcYHGpuRKWoYxg;

			public readonly ValueWatcher<bool> iIwLmFGPOWeUeyTyUOtHZpptrJQ;

			private int LBMMdoJhxNrtaQDnhYJSctYSpCo;

			private readonly ValueWatcher[] OSaESpHCQCIgxhjUwmLDGNrBAkYV;

			[CompilerGenerated]
			private static Func<bool> RtJKSpKJhiTIbElelhEiIFmkBQQG;

			[CompilerGenerated]
			private static Func<bool> UzxCBZCOZHsfROMinUZdpyBEldb;

			[CompilerGenerated]
			private static Func<int> ocuxEYCOrAGgdcJYnDsRYwRowuOA;

			[CompilerGenerated]
			private static Func<float> vhbhQSdpXSFfqOcRMbAbDJWfTMHF;

			[CompilerGenerated]
			private static Func<bool> CYmEvLCEHioAEcVwfmRrBEwmpjO;

			[CompilerGenerated]
			private static Func<string> QveubAFFFsBrBHfKulYmKOiVOyy;

			public int currentFrame
			{
				get
				{
					return LBMMdoJhxNrtaQDnhYJSctYSpCo;
				}
			}

			public GigsgPepzmbLEqiYuZngCILzefXc()
			{
				List<ValueWatcher> list = new List<ValueWatcher>
				{
					(GWofaMEDvQsTFZRKVjOQjsEXlnlQ = new ValueWatcher<bool>(true, false)),
					(KxMFnVhrvWePdEFocFhJZJavPDPm = new ValueWatcher<bool>(Screen.fullScreen, () => Screen.fullScreen, false)),
					(tuePXEXCllLWVEsrShnUubANHkoJ = new ValueWatcher<bool>(Application.runInBackground, () => Application.runInBackground, false)),
					(lZADyAaQIBGYNaQOEzrFKhsPUMe = new ValueWatcher<int>((int)Screen.fullScreenMode, () => (int)Screen.fullScreenMode, false)),
					(kSDReLSYweLZZvBfBIpurrNInte = new ValueWatcher<float>(Time.unscaledDeltaTime, () => Time.unscaledDeltaTime, false)),
					(iIwLmFGPOWeUeyTyUOtHZpptrJQ = new ValueWatcher<bool>(MathTools.ApproximatelyZero(Time.timeScale), () => MathTools.ApproximatelyZero(Time.timeScale), MathTools.ApproximatelyZero(Time.timeScale)))
				};
				if (editorPlatform != EditorPlatform.None)
				{
					list.Add(OhYEFIeVBMhhNepcYHGpuRKWoYxg = new ValueWatcher<string>(UnityTools.externalTools.GetFocusedEditorWindowTitle(), () => UnityTools.externalTools.GetFocusedEditorWindowTitle(), false));
				}
				OSaESpHCQCIgxhjUwmLDGNrBAkYV = list.ToArray();
				rdEJYvExbWYUXSDuseVgzyXPBhA();
			}

			public void rdEJYvExbWYUXSDuseVgzyXPBhA()
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= OSaESpHCQCIgxhjUwmLDGNrBAkYV.Length)
					{
						num2 = 1923921350;
						num3 = num2;
					}
					else
					{
						num2 = 1923921351;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x72ACB5C4)
						{
						case 0:
							num2 = 1923921351;
							continue;
						case 3:
							OSaESpHCQCIgxhjUwmLDGNrBAkYV[num].Update();
							num++;
							num2 = 1923921349;
							continue;
						case 1:
							break;
						default:
							LBMMdoJhxNrtaQDnhYJSctYSpCo = Time.frameCount;
							return;
						}
						break;
					}
				}
			}

			public void wAKMRHEHkrIbvzyzvXaCjtCQiWS()
			{
				int num = 0;
				while (num < OSaESpHCQCIgxhjUwmLDGNrBAkYV.Length)
				{
					while (true)
					{
						OSaESpHCQCIgxhjUwmLDGNrBAkYV[num].TriggerEvent();
						num++;
						int num2 = -666347591;
						while (true)
						{
							switch (num2 ^ -666347592)
							{
							case 0:
								num2 = -666347590;
								continue;
							case 2:
								break;
							default:
								goto end_IL_0022;
							}
							break;
						}
						continue;
						end_IL_0022:
						break;
					}
				}
			}

			[CompilerGenerated]
			private static bool wzTFlUZieGKgjlkfVaewCmKAlNqk()
			{
				return Screen.fullScreen;
			}

			[CompilerGenerated]
			private static bool azILZumDTwApQOtgUGZECBDOurv()
			{
				return Application.runInBackground;
			}

			[CompilerGenerated]
			private static int tPjfMZTlMqpWrndjEvFhCmMvPwc()
			{
				return (int)Screen.fullScreenMode;
			}

			[CompilerGenerated]
			private static float iLoWDMSJfSLXPAlhWAHEiJinzfb()
			{
				return Time.unscaledDeltaTime;
			}

			[CompilerGenerated]
			private static bool YENTLuvzOfCurFwKXOgWIAHjYPd()
			{
				return MathTools.ApproximatelyZero(Time.timeScale);
			}

			[CompilerGenerated]
			private static string QuNkIdHXNzEtHbgWRodpVHqLbgt()
			{
				return UnityTools.externalTools.GetFocusedEditorWindowTitle();
			}
		}

		[CustomObfuscation(rename = false)]
		internal const int programVersion1 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion2 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion3 = 27;

		[CustomObfuscation(rename = false)]
		internal const int programVersion4 = 3;

		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U2018";

		private static InputManager_Base XSTHGbqTGxsAhksycZRiWDoTadf;

		private static PlatformInputManager MDVmwweEvHoLmOhNxpYDWbEeYJl;

		internal static vymLASJcQEATncxsXyaiNEjaYgR AQANKVsSPXqhjRcrczEkdvuTzzw;

		internal static lCLAgzeBrhoeWjAjwfsCvCCcNbf TjEnOXyhIcFYKPeZiqgPVRhKsqQ;

		internal static ZxYDdEiisedLFBFHGsfeDMnmzxjo lGcKTymIVPnyTtnJFgbcUzeJcSS;

		private static ControllerDataFiles xWDCnqIoBGxYWmcirHenJdbGNrxL;

		private static UserData stWFwgAKcHRiMeUYeMbPaDXDxKKn;

		private static bool uvRIxvvRCxrfpiSXpAlvYqJtnEz;

		private static ConfigVars EVFWZcZYsJTyVuPgkpnexuXAMzA;

		private static UpdateLoopType LUsVnbjyJOfEaVNiPspSYlQOFpA;

		private static bool aqQNYTLFCDaASydZMAHFATKUUjI;

		private static Platform wKNanqmBEVNDakkkYbwEHSSsAOab;

		private static WebplayerPlatform MahmSOufpIgWKHrJtunLQmCVLTSF;

		private static EditorPlatform ckqMYVULGCvECZjzNaYYeazfmsEa;

		private static bool ccOzrrVGcsafLxHVjwAVdxIbRAX;

		private static TimerAbs VkvExSdGEsbPKBRQBRJHZMgQnlBL;

		private static pcdrTgzsTsbzYzupVYcCrhXwihd QPtGmChyFMyzZlDENzpxpKkvdDfb;

		private static string aXqbHIdpTsdDdFaXuTcdkxcTnHaq;

		private static bool plUhMRKgrReNjpNYKBQDTiMWykj;

		private static bool WHILsHNdIXRfRroSPuxfTGaAZVA;

		private static bool oMEXmFzjqHWXGDnyqUQlTeSTaZM;

		private static int KKhxiZkgLFEvukEOFInybJebTqgw;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int gqdLAjNrZTFlwISlEqsPdnurcfg;

		private static int OlnysszPISQEicKQWslggkKFqnM;

		private static bool NuJlATmYOMdWXRRTuCaVCBLtlrF;

		private static readonly UnityTouch iEhscZfVWooxIcDtqkJtYBXGHto;

		private static readonly PlayerHelper OOYAllZeDNRbBklIPOlGVqMKmtX;

		private static readonly ControllerHelper CbXeSOZaocdhhyCTkEExRFbYRSn;

		private static readonly MappingHelper cHJnwIxXeSohAQEfLVerfaVOhZn;

		private static readonly TimeHelper spBiWwEZzWqyUZExVZPYisBsJqj;

		private static readonly ConfigHelper rlRZIdKRlLmhFnIFhCvgWiQfXZT;

		private static YnisbciDvsRZeAbvRfcznxTbzne qDucchFLZrumyzUPtptKRFJbMzl;

		private static UserDataStore HzFipmAIaHcroswSuDJaiaFCAYM;

		private static IControllerAssigner MNCBXKvckaAmEBcrOabhuDDZCQB;

		private static GigsgPepzmbLEqiYuZngCILzefXc WsNZNpjFAAyPrOWfwbxPgfCxQam;

		private static SafeAction<ControllerStatusChangedEventArgs> aqgigOlBfGHpfkLCGHEzRHgPFjmO;

		private static SafeAction<ControllerStatusChangedEventArgs> TDaZvgnLddQRBxhdBTgymJOadUC;

		private static SafeAction<ControllerStatusChangedEventArgs> XWfBrEITLvBtiDlpQLZJwhJXhoIX;

		private static SafeAction JPavcstGOjcicVpGivxYfYrfbSI;

		private static SafeAction HEgtPpMbFQRllZrBwUENCxlfJKQ;

		private static SafeAction XBntwEZwxDiXXrDcjkXtevSVFEp;

		private static SafeAction ZvKOJYzwYcanwKFkFfbngqgolQIa;

		private static SafeAction veaLEHEEzCDKzITKHftSuYkBKal;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		private static Action QVhhsoRoWfagqYxuqPgpjSPtRaI;

		private static Action<UpdateLoopType> XZqXkhILSDGEXwBcEJNnGqhcpdP;

		private static Action<UpdateLoopType> BNihuBrBiOUrGvXouejcrKFTBrg;

		private static Action<UpdateLoopType> NXiFFMqnZmfDNLoDSXyYngPXILU;

		private static Action fsUyQtZnJxoEDyniNBWWYHXEApq;

		private static Action<bool> sAJQmkmbuIcDAUklbGHjjUNkZTop;

		private static Action<bool> RqvahHIhRDMioudYIfeVcMkMGGf;

		private static Action<bool> KHtlJkitkzQqpQeuqNYaQSQKZjp;

		private static Action<FullScreenMode> UbrbNqJvUJFgmbLUOuVYXKYzCpHH;

		private static Action qZjCeoLIlcLsqfGfrlmQKYASUXs;

		private static Action<bool> HNDbYpCNsvQvOLTcxZfIflUMliNS;

		[CustomObfuscation(rename = false)]
		internal static float unscaledDeltaTime;

		[CustomObfuscation(rename = false)]
		internal static float unscaledTime;

		[CustomObfuscation(rename = false)]
		internal static float unscaledTimePrev;

		[CustomObfuscation(rename = false)]
		internal static uint currentFrame;

		[CustomObfuscation(rename = false)]
		internal static uint previousFrame;

		[CustomObfuscation(rename = false)]
		internal static uint absFrame;

		[CompilerGenerated]
		private static Action<Exception> daZcRQdZLfKNcBUbrcIVBWyceJaD;

		[CompilerGenerated]
		private static Action<Exception> IMcfHZuGCenebnwEqEYfzISjcoY;

		[CompilerGenerated]
		private static Action<Exception> ziuyIEKZgAqwOBMhCqzxtdlWtGn;

		[CompilerGenerated]
		private static Action<Exception> PEKRcxSbkifUDFBgnvjyOvEcZDW;

		[CompilerGenerated]
		private static Action<Exception> cyPpxoBXosrOAPNMKkrilggvqke;

		[CompilerGenerated]
		private static Action<Exception> rHwbuUazOsBEKqTINKMxbWjHpNpI;

		[CompilerGenerated]
		private static Action<Exception> TSQVIZlhaGJpNZabQhIesPHRqdE;

		[CompilerGenerated]
		private static Action<Exception> fFwdPYRtJSdyRfsNrkdOyiNrdFem;

		[CompilerGenerated]
		private static Action<Exception> gATAjvUQhYpZwetXCcmDViyQTES;

		[CompilerGenerated]
		private static Func<bool> RRxDiVYMSZNxJfchaoIccnFPBry;

		private static YnisbciDvsRZeAbvRfcznxTbzne unityInputBuffer
		{
			get
			{
				return qDucchFLZrumyzUPtptKRFJbMzl ?? (qDucchFLZrumyzUPtptKRFJbMzl = new YnisbciDvsRZeAbvRfcznxTbzne(EVFWZcZYsJTyVuPgkpnexuXAMzA.updateLoop));
			}
		}

		public static PlayerHelper players
		{
			get
			{
				if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					ZEpXkkjVNmwfEKNRsLXtFMLePQl();
					return null;
				}
				return OOYAllZeDNRbBklIPOlGVqMKmtX;
			}
		}

		public static ControllerHelper controllers
		{
			get
			{
				if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					ZEpXkkjVNmwfEKNRsLXtFMLePQl();
					return null;
				}
				return CbXeSOZaocdhhyCTkEExRFbYRSn;
			}
		}

		public static MappingHelper mapping
		{
			get
			{
				if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					while (true)
					{
						int num = 978121096;
						while (true)
						{
							switch (num ^ 0x3A4CF189)
							{
							case 0:
								break;
							case 1:
								goto IL_0025;
							default:
								return null;
							}
							break;
							IL_0025:
							ZEpXkkjVNmwfEKNRsLXtFMLePQl();
							num = 978121099;
						}
					}
				}
				return cHJnwIxXeSohAQEfLVerfaVOhZn;
			}
		}

		public static UnityTouch touch
		{
			get
			{
				if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					ZEpXkkjVNmwfEKNRsLXtFMLePQl();
					return null;
				}
				return iEhscZfVWooxIcDtqkJtYBXGHto;
			}
		}

		public static TimeHelper time
		{
			get
			{
				if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					ZEpXkkjVNmwfEKNRsLXtFMLePQl();
					return null;
				}
				return spBiWwEZzWqyUZExVZPYisBsJqj;
			}
		}

		public static IUserDataStore userDataStore
		{
			get
			{
				if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					while (true)
					{
						int num = 222922891;
						while (true)
						{
							switch (num ^ 0xD49888A)
							{
							case 0:
								break;
							case 1:
								goto IL_0025;
							default:
								return null;
							}
							break;
							IL_0025:
							ZEpXkkjVNmwfEKNRsLXtFMLePQl();
							num = 222922888;
						}
					}
				}
				return HzFipmAIaHcroswSuDJaiaFCAYM;
			}
		}

		public static ConfigHelper configuration
		{
			get
			{
				if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					ZEpXkkjVNmwfEKNRsLXtFMLePQl();
					return null;
				}
				return rlRZIdKRlLmhFnIFhCvgWiQfXZT;
			}
		}

		public static string programVersion
		{
			get
			{
				object[] array = new object[8] { 1, null, null, null, null, null, null, null };
				while (true)
				{
					int num = 1420750355;
					while (true)
					{
						switch (num ^ 0x54AEEE12)
						{
						case 0:
							break;
						case 1:
							array[1] = ".";
							array[2] = 1;
							num = 1420750353;
							continue;
						case 3:
							array[3] = ".";
							array[4] = 27;
							num = 1420750352;
							continue;
						default:
							array[5] = ".";
							array[6] = 3;
							array[7] = ".U2018";
							return string.Concat(array);
						}
						break;
					}
				}
			}
		}

		public static bool usingUnityInput
		{
			get
			{
				return aqQNYTLFCDaASydZMAHFATKUUjI;
			}
		}

		public static bool unityJoystickIdentificationRequired
		{
			get
			{
				if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					return false;
				}
				if (isWindowsStandaloneWebplayerOrEditorPlatform)
				{
					while (true)
					{
						int num = -1273026626;
						while (true)
						{
							switch (num ^ -1273026625)
							{
							case 2:
								break;
							case 1:
								goto IL_002e;
							default:
								return true;
							}
							break;
							IL_002e:
							if (UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
							{
								goto end_IL_0010;
							}
							num = -1273026625;
						}
						continue;
						end_IL_0010:
						break;
					}
				}
				return false;
			}
		}

		public static bool isReady
		{
			get
			{
				return uvRIxvvRCxrfpiSXpAlvYqJtnEz;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int id
		{
			get
			{
				return _id;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool initialized
		{
			get
			{
				return uvRIxvvRCxrfpiSXpAlvYqJtnEz;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static UpdateLoopType currentUpdateLoop
		{
			get
			{
				return LUsVnbjyJOfEaVNiPspSYlQOFpA;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static ConfigVars configVars
		{
			get
			{
				return EVFWZcZYsJTyVuPgkpnexuXAMzA;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static UserData UserData
		{
			get
			{
				return stWFwgAKcHRiMeUYeMbPaDXDxKKn;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static Platform currentPlatform
		{
			get
			{
				return wKNanqmBEVNDakkkYbwEHSSsAOab;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static WebplayerPlatform webplayerPlatform
		{
			get
			{
				return MahmSOufpIgWKHrJtunLQmCVLTSF;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static EditorPlatform editorPlatform
		{
			get
			{
				return ckqMYVULGCvECZjzNaYYeazfmsEa;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool checkNeverPressed
		{
			get
			{
				if (wKNanqmBEVNDakkkYbwEHSSsAOab == Platform.Linux)
				{
					goto IL_0008;
				}
				goto IL_0037;
				IL_0008:
				int num = -1314809261;
				goto IL_000d;
				IL_000d:
				while (true)
				{
					switch (num ^ -1314809257)
					{
					case 2:
						break;
					case 4:
						goto IL_002e;
					case 0:
						return true;
					case 3:
						if (aqQNYTLFCDaASydZMAHFATKUUjI)
						{
							goto case 0;
						}
						goto IL_005d;
					default:
						goto IL_0071;
					}
					break;
					IL_005d:
					if (primaryInputManager.inputSourceType == InputSource.OSX)
					{
						num = -1314809257;
						continue;
					}
					goto IL_0048;
				}
				goto IL_0008;
				IL_0048:
				if (UnityTools.isAndroidPlatform)
				{
					num = -1314809258;
					goto IL_000d;
				}
				goto IL_007a;
				IL_007a:
				if (wKNanqmBEVNDakkkYbwEHSSsAOab == Platform.Webplayer && MahmSOufpIgWKHrJtunLQmCVLTSF == WebplayerPlatform.OSX)
				{
					return true;
				}
				if (wKNanqmBEVNDakkkYbwEHSSsAOab == Platform.WebGL)
				{
					return true;
				}
				return false;
				IL_0071:
				if (aqQNYTLFCDaASydZMAHFATKUUjI)
				{
					return true;
				}
				goto IL_007a;
				IL_0037:
				if (wKNanqmBEVNDakkkYbwEHSSsAOab == Platform.OSX)
				{
					num = -1314809260;
					goto IL_000d;
				}
				goto IL_0048;
				IL_002e:
				if (aqQNYTLFCDaASydZMAHFATKUUjI)
				{
					return true;
				}
				goto IL_0037;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isEditor
		{
			get
			{
				return ckqMYVULGCvECZjzNaYYeazfmsEa != EditorPlatform.None;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					return Guid.Empty;
				}
				return xWDCnqIoBGxYWmcirHenJdbGNrxL.defaultHardwareJoystickMapGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isRunningInEditMode
		{
			get
			{
				return WHILsHNdIXRfRroSPuxfTGaAZVA;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isEditorPaused
		{
			get
			{
				return UnityTools.externalTools.isEditorPaused;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTime
		{
			get
			{
				return QPtGmChyFMyzZlDENzpxpKkvdDfb.unityUnscaledDeltaTime;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTimePrev
		{
			get
			{
				return QPtGmChyFMyzZlDENzpxpKkvdDfb.unityUnscaledDeltaTimePrev;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static float realTime
		{
			get
			{
				if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					return 0f;
				}
				return QPtGmChyFMyzZlDENzpxpKkvdDfb.realTime;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int currentUnityFrame
		{
			get
			{
				if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					return 0;
				}
				return WsNZNpjFAAyPrOWfwbxPgfCxQam.currentFrame;
			}
		}

		private static bool isEditorGameViewFocused
		{
			get
			{
				if (UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_1)
				{
					return aXqbHIdpTsdDdFaXuTcdkxcTnHaq == "Game";
				}
				return aXqbHIdpTsdDdFaXuTcdkxcTnHaq == "UnityEditor.GameView";
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused
		{
			get
			{
				if (EVFWZcZYsJTyVuPgkpnexuXAMzA.allowInputInEditorSceneView && UnityTools.externalTools.IsEditorSceneViewFocused())
				{
					goto IL_0018;
				}
				int num;
				if (!oMEXmFzjqHWXGDnyqUQlTeSTaZM)
				{
					num = -826467597;
					goto IL_001d;
				}
				return true;
				IL_0018:
				num = -826467600;
				goto IL_001d;
				IL_001d:
				switch (num ^ -826467599)
				{
				case 0:
					break;
				case 1:
					return true;
				default:
					return isEditorGameViewFocused;
				}
				goto IL_0018;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused
		{
			get
			{
				INativePlatformHelper nativePlatformHelper = MDVmwweEvHoLmOhNxpYDWbEeYJl as INativePlatformHelper;
				if (nativePlatformHelper != null)
				{
					return nativePlatformHelper.isApplicationFocused;
				}
				return oMEXmFzjqHWXGDnyqUQlTeSTaZM;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform
		{
			get
			{
				if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					return false;
				}
				if (!aqQNYTLFCDaASydZMAHFATKUUjI)
				{
					return false;
				}
				if (wKNanqmBEVNDakkkYbwEHSSsAOab != Platform.Windows)
				{
					while (true)
					{
						int num = -390607151;
						while (true)
						{
							switch (num ^ -390607152)
							{
							case 2:
								break;
							case 1:
								if (wKNanqmBEVNDakkkYbwEHSSsAOab == Platform.Webplayer)
								{
									goto IL_0041;
								}
								goto default;
							default:
								return ckqMYVULGCvECZjzNaYYeazfmsEa == EditorPlatform.Windows;
							}
							break;
							IL_0041:
							if (MahmSOufpIgWKHrJtunLQmCVLTSF == WebplayerPlatform.Windows)
							{
								goto end_IL_001a;
							}
							num = -390607152;
						}
						continue;
						end_IL_001a:
						break;
					}
				}
				return true;
			}
		}

		private static bool inputAllowed
		{
			get
			{
				int num;
				if (uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					if (!WsNZNpjFAAyPrOWfwbxPgfCxQam.GWofaMEDvQsTFZRKVjOQjsEXlnlQ.value)
					{
						if (NuJlATmYOMdWXRRTuCaVCBLtlrF)
						{
							return false;
						}
						if (!isEditor)
						{
							if (!WsNZNpjFAAyPrOWfwbxPgfCxQam.tuePXEXCllLWVEsrShnUubANHkoJ.value)
							{
								num = 567673110;
								goto IL_000c;
							}
							if (WsNZNpjFAAyPrOWfwbxPgfCxQam.KxMFnVhrvWePdEFocFhJZJavPDPm.value)
							{
								return false;
							}
						}
					}
					return true;
				}
				goto IL_0007;
				IL_000c:
				switch (num ^ 0x21D60116)
				{
				case 2:
					break;
				case 1:
					return false;
				default:
					return false;
				}
				goto IL_0007;
				IL_0007:
				num = 567673111;
				goto IL_000c;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFocused
		{
			get
			{
				if (uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					return WsNZNpjFAAyPrOWfwbxPgfCxQam.GWofaMEDvQsTFZRKVjOQjsEXlnlQ.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFullScreen
		{
			get
			{
				if (uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					return WsNZNpjFAAyPrOWfwbxPgfCxQam.KxMFnVhrvWePdEFocFhJZJavPDPm.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationRunInBackground
		{
			get
			{
				if (uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					return WsNZNpjFAAyPrOWfwbxPgfCxQam.tuePXEXCllLWVEsrShnUubANHkoJ.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool timeScaleIsPaused
		{
			get
			{
				if (uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					return WsNZNpjFAAyPrOWfwbxPgfCxQam.iIwLmFGPOWeUeyTyUOtHZpptrJQ.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static InputManager_Base rewiredInputManager
		{
			get
			{
				return XSTHGbqTGxsAhksycZRiWDoTadf;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static PlatformInputManager primaryInputManager
		{
			get
			{
				if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
				{
					ZEpXkkjVNmwfEKNRsLXtFMLePQl();
					return null;
				}
				return MDVmwweEvHoLmOhNxpYDWbEeYJl.primaryInputManager;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static IControllerAssigner controllerAssigner
		{
			get
			{
				return MNCBXKvckaAmEBcrOabhuDDZCQB;
			}
			set
			{
				MNCBXKvckaAmEBcrOabhuDDZCQB = value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static RewiredVersion rewiredVersion
		{
			get
			{
				return new RewiredVersion(programVersion);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int timeScalePauseChangedCount
		{
			get
			{
				return OlnysszPISQEicKQWslggkKFqnM;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
		{
			add
			{
				aqgigOlBfGHpfkLCGHEzRHgPFjmO += value;
			}
			remove
			{
				aqgigOlBfGHpfkLCGHEzRHgPFjmO -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
		{
			add
			{
				TDaZvgnLddQRBxhdBTgymJOadUC += value;
			}
			remove
			{
				TDaZvgnLddQRBxhdBTgymJOadUC -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
		{
			add
			{
				XWfBrEITLvBtiDlpQLZJwhJXhoIX += value;
			}
			remove
			{
				XWfBrEITLvBtiDlpQLZJwhJXhoIX -= value;
			}
		}

		public static event Action InputSourceUpdateEvent
		{
			add
			{
				JPavcstGOjcicVpGivxYfYrfbSI += value;
			}
			remove
			{
				JPavcstGOjcicVpGivxYfYrfbSI -= value;
			}
		}

		public static event Action EditorRecompileEvent
		{
			add
			{
				HEgtPpMbFQRllZrBwUENCxlfJKQ += value;
			}
			remove
			{
				HEgtPpMbFQRllZrBwUENCxlfJKQ -= value;
			}
		}

		public static event Action PreShutDownEvent
		{
			add
			{
				XBntwEZwxDiXXrDcjkXtevSVFEp += value;
			}
			remove
			{
				XBntwEZwxDiXXrDcjkXtevSVFEp -= value;
			}
		}

		public static event Action ShutDownEvent
		{
			add
			{
				ZvKOJYzwYcanwKFkFfbngqgolQIa += value;
			}
			remove
			{
				ZvKOJYzwYcanwKFkFfbngqgolQIa -= value;
			}
		}

		public static event Action InitializedEvent
		{
			add
			{
				veaLEHEEzCDKzITKHftSuYkBKal += value;
			}
			remove
			{
				veaLEHEEzCDKzITKHftSuYkBKal -= value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationFocusChangedEvent
		{
			add
			{
				_ApplicationFocusChangedEvent = (Action<bool>)Delegate.Combine(_ApplicationFocusChangedEvent, value);
			}
			remove
			{
				_ApplicationFocusChangedEvent = (Action<bool>)Delegate.Remove(_ApplicationFocusChangedEvent, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action EarlyUpdateEvent
		{
			add
			{
				QVhhsoRoWfagqYxuqPgpjSPtRaI = (Action)Delegate.Combine(QVhhsoRoWfagqYxuqPgpjSPtRaI, value);
			}
			remove
			{
				QVhhsoRoWfagqYxuqPgpjSPtRaI = (Action)Delegate.Remove(QVhhsoRoWfagqYxuqPgpjSPtRaI, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
				XZqXkhILSDGEXwBcEJNnGqhcpdP = (Action<UpdateLoopType>)Delegate.Combine(XZqXkhILSDGEXwBcEJNnGqhcpdP, value);
			}
			remove
			{
				XZqXkhILSDGEXwBcEJNnGqhcpdP = (Action<UpdateLoopType>)Delegate.Remove(XZqXkhILSDGEXwBcEJNnGqhcpdP, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
				BNihuBrBiOUrGvXouejcrKFTBrg = (Action<UpdateLoopType>)Delegate.Combine(BNihuBrBiOUrGvXouejcrKFTBrg, value);
			}
			remove
			{
				BNihuBrBiOUrGvXouejcrKFTBrg = (Action<UpdateLoopType>)Delegate.Remove(BNihuBrBiOUrGvXouejcrKFTBrg, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
				NXiFFMqnZmfDNLoDSXyYngPXILU = (Action<UpdateLoopType>)Delegate.Combine(NXiFFMqnZmfDNLoDSXyYngPXILU, value);
			}
			remove
			{
				NXiFFMqnZmfDNLoDSXyYngPXILU = (Action<UpdateLoopType>)Delegate.Remove(NXiFFMqnZmfDNLoDSXyYngPXILU, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action LateUpdateEvent
		{
			add
			{
				fsUyQtZnJxoEDyniNBWWYHXEApq = (Action)Delegate.Combine(fsUyQtZnJxoEDyniNBWWYHXEApq, value);
			}
			remove
			{
				fsUyQtZnJxoEDyniNBWWYHXEApq = (Action)Delegate.Remove(fsUyQtZnJxoEDyniNBWWYHXEApq, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
				sAJQmkmbuIcDAUklbGHjjUNkZTop = (Action<bool>)Delegate.Combine(sAJQmkmbuIcDAUklbGHjjUNkZTop, value);
			}
			remove
			{
				sAJQmkmbuIcDAUklbGHjjUNkZTop = (Action<bool>)Delegate.Remove(sAJQmkmbuIcDAUklbGHjjUNkZTop, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
				RqvahHIhRDMioudYIfeVcMkMGGf = (Action<bool>)Delegate.Combine(RqvahHIhRDMioudYIfeVcMkMGGf, value);
			}
			remove
			{
				RqvahHIhRDMioudYIfeVcMkMGGf = (Action<bool>)Delegate.Remove(RqvahHIhRDMioudYIfeVcMkMGGf, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
				KHtlJkitkzQqpQeuqNYaQSQKZjp = (Action<bool>)Delegate.Combine(KHtlJkitkzQqpQeuqNYaQSQKZjp, value);
			}
			remove
			{
				KHtlJkitkzQqpQeuqNYaQSQKZjp = (Action<bool>)Delegate.Remove(KHtlJkitkzQqpQeuqNYaQSQKZjp, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
		{
			add
			{
				UbrbNqJvUJFgmbLUOuVYXKYzCpHH = (Action<FullScreenMode>)Delegate.Combine(UbrbNqJvUJFgmbLUOuVYXKYzCpHH, value);
			}
			remove
			{
				UbrbNqJvUJFgmbLUOuVYXKYzCpHH = (Action<FullScreenMode>)Delegate.Remove(UbrbNqJvUJFgmbLUOuVYXKYzCpHH, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action SceneLoadedEvent
		{
			add
			{
				qZjCeoLIlcLsqfGfrlmQKYASUXs = (Action)Delegate.Combine(qZjCeoLIlcLsqfGfrlmQKYASUXs, value);
			}
			remove
			{
				qZjCeoLIlcLsqfGfrlmQKYASUXs = (Action)Delegate.Remove(qZjCeoLIlcLsqfGfrlmQKYASUXs, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> EditorPauseChangedEvent
		{
			add
			{
				HNDbYpCNsvQvOLTcxZfIflUMliNS = (Action<bool>)Delegate.Combine(HNDbYpCNsvQvOLTcxZfIflUMliNS, value);
			}
			remove
			{
				HNDbYpCNsvQvOLTcxZfIflUMliNS = (Action<bool>)Delegate.Remove(HNDbYpCNsvQvOLTcxZfIflUMliNS, value);
			}
		}

		static ReInput()
		{
			oMEXmFzjqHWXGDnyqUQlTeSTaZM = true;
			while (true)
			{
				int num = 1323596207;
				while (true)
				{
					switch (num ^ 0x4EE479A4)
					{
					case 9:
						break;
					case 5:
						CbXeSOZaocdhhyCTkEExRFbYRSn = ControllerHelper.Instance;
						num = 1323596196;
						continue;
					case 15:
						fFwdPYRtJSdyRfsNrkdOyiNrdFem = delegate(Exception P_0)
						{
							HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
						};
						num = 1323596192;
						continue;
					case 10:
						HEgtPpMbFQRllZrBwUENCxlfJKQ = new SafeAction(cyPpxoBXosrOAPNMKkrilggvqke);
						if (rHwbuUazOsBEKqTINKMxbWjHpNpI == null)
						{
							rHwbuUazOsBEKqTINKMxbWjHpNpI = delegate(Exception P_0)
							{
								HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
							};
							num = 1323596202;
							continue;
						}
						goto case 14;
					case 8:
						if (daZcRQdZLfKNcBUbrcIVBWyceJaD == null)
						{
							daZcRQdZLfKNcBUbrcIVBWyceJaD = delegate(Exception P_0)
							{
								HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
							};
							num = 1323596213;
							continue;
						}
						goto case 17;
					case 7:
						PEKRcxSbkifUDFBgnvjyOvEcZDW = delegate(Exception P_0)
						{
							HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
						};
						num = 1323596194;
						continue;
					case 14:
						XBntwEZwxDiXXrDcjkXtevSVFEp = new SafeAction(rHwbuUazOsBEKqTINKMxbWjHpNpI);
						num = 1323596201;
						continue;
					case 17:
						aqgigOlBfGHpfkLCGHEzRHgPFjmO = new SafeAction<ControllerStatusChangedEventArgs>(daZcRQdZLfKNcBUbrcIVBWyceJaD);
						if (IMcfHZuGCenebnwEqEYfzISjcoY == null)
						{
							IMcfHZuGCenebnwEqEYfzISjcoY = delegate(Exception P_0)
							{
								HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
							};
							num = 1323596212;
							continue;
						}
						goto case 16;
					case 0:
						cHJnwIxXeSohAQEfLVerfaVOhZn = MappingHelper.Instance;
						spBiWwEZzWqyUZExVZPYisBsJqj = TimeHelper.Instance;
						rlRZIdKRlLmhFnIFhCvgWiQfXZT = ConfigHelper.Instance;
						num = 1323596204;
						continue;
					case 13:
						if (TSQVIZlhaGJpNZabQhIesPHRqdE == null)
						{
							TSQVIZlhaGJpNZabQhIesPHRqdE = delegate(Exception P_0)
							{
								HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
							};
							num = 1323596198;
							continue;
						}
						goto case 2;
					case 16:
						TDaZvgnLddQRBxhdBTgymJOadUC = new SafeAction<ControllerStatusChangedEventArgs>(IMcfHZuGCenebnwEqEYfzISjcoY);
						if (ziuyIEKZgAqwOBMhCqzxtdlWtGn == null)
						{
							ziuyIEKZgAqwOBMhCqzxtdlWtGn = delegate(Exception P_0)
							{
								HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
							};
							num = 1323596200;
							continue;
						}
						goto case 12;
					case 2:
					{
						ZvKOJYzwYcanwKFkFfbngqgolQIa = new SafeAction(TSQVIZlhaGJpNZabQhIesPHRqdE);
						int num2;
						if (fFwdPYRtJSdyRfsNrkdOyiNrdFem != null)
						{
							num = 1323596192;
							num2 = num;
						}
						else
						{
							num = 1323596203;
							num2 = num;
						}
						continue;
					}
					case 12:
					{
						XWfBrEITLvBtiDlpQLZJwhJXhoIX = new SafeAction<ControllerStatusChangedEventArgs>(ziuyIEKZgAqwOBMhCqzxtdlWtGn);
						int num3;
						if (PEKRcxSbkifUDFBgnvjyOvEcZDW == null)
						{
							num = 1323596195;
							num3 = num;
						}
						else
						{
							num = 1323596194;
							num3 = num;
						}
						continue;
					}
					case 11:
						KKhxiZkgLFEvukEOFInybJebTqgw = -1;
						_id = -1;
						gqdLAjNrZTFlwISlEqsPdnurcfg = 0;
						iEhscZfVWooxIcDtqkJtYBXGHto = UnityTouch.Instance;
						num = 1323596199;
						continue;
					case 6:
						JPavcstGOjcicVpGivxYfYrfbSI = new SafeAction(PEKRcxSbkifUDFBgnvjyOvEcZDW);
						if (cyPpxoBXosrOAPNMKkrilggvqke == null)
						{
							cyPpxoBXosrOAPNMKkrilggvqke = delegate(Exception P_0)
							{
								HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
							};
							num = 1323596206;
							continue;
						}
						goto case 10;
					case 3:
						OOYAllZeDNRbBklIPOlGVqMKmtX = PlayerHelper.Instance;
						num = 1323596193;
						continue;
					case 4:
						veaLEHEEzCDKzITKHftSuYkBKal = new SafeAction(fFwdPYRtJSdyRfsNrkdOyiNrdFem);
						if (gATAjvUQhYpZwetXCcmDViyQTES == null)
						{
							gATAjvUQhYpZwetXCcmDViyQTES = delegate(Exception P_0)
							{
								HandleCallbackException("", P_0);
							};
							num = 1323596197;
							continue;
						}
						goto default;
					default:
						SafeDelegate.S_ExceptionHandler = gATAjvUQhYpZwetXCcmDViyQTES;
						return;
					}
					break;
				}
			}
		}

		public static void Reset()
		{
			if (uvRIxvvRCxrfpiSXpAlvYqJtnEz && !(XSTHGbqTGxsAhksycZRiWDoTadf == null))
			{
				XSTHGbqTGxsAhksycZRiWDoTadf.ResetAll();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			if (!inputAllowed)
			{
				goto IL_0007;
			}
			int num;
			if (ckqMYVULGCvECZjzNaYYeazfmsEa != EditorPlatform.None)
			{
				int num2;
				if (controllerType == ControllerType.Keyboard)
				{
					num = -1309976352;
					num2 = num;
				}
				else
				{
					num = -1309976350;
					num2 = num;
				}
				goto IL_000c;
			}
			goto IL_0097;
			IL_000c:
			while (true)
			{
				switch (num ^ -1309976349)
				{
				case 0:
					break;
				case 2:
					goto IL_0031;
				case 3:
					goto IL_0052;
				case 1:
					goto IL_0060;
				case 5:
					return false;
				default:
					return false;
				}
				break;
				IL_0060:
				if (controllerType == ControllerType.Mouse)
				{
					num = -1309976352;
					continue;
				}
				goto IL_0097;
				IL_0031:
				if (!WsNZNpjFAAyPrOWfwbxPgfCxQam.GWofaMEDvQsTFZRKVjOQjsEXlnlQ.value)
				{
					return false;
				}
				goto IL_0097;
				IL_0052:
				if (!NuJlATmYOMdWXRRTuCaVCBLtlrF)
				{
					if (!isAllowedEditorWindowFocused)
					{
						num = -1309976345;
						continue;
					}
					if (controllerType == ControllerType.Mouse && !isUnityEditorFocused)
					{
						return false;
					}
					goto IL_0097;
				}
				num = -1309976351;
			}
			goto IL_0007;
			IL_0007:
			num = -1309976346;
			goto IL_000c;
			IL_0097:
			return true;
		}

		internal static void dFyvOnKBbTYzKLbxHBbiIGdcrpeH(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4)
		{
			try
			{
				_id = gqdLAjNrZTFlwISlEqsPdnurcfg;
				gqdLAjNrZTFlwISlEqsPdnurcfg++;
				uvRIxvvRCxrfpiSXpAlvYqJtnEz = true;
				plUhMRKgrReNjpNYKBQDTiMWykj = true;
				while (true)
				{
					int num = 1415602742;
					while (true)
					{
						int wHILsHNdIXRfRroSPuxfTGaAZVA;
						switch (num ^ 0x54606239)
						{
						case 0:
							break;
						default:
							return;
						case 9:
							if (ckqMYVULGCvECZjzNaYYeazfmsEa != EditorPlatform.None)
							{
								WsNZNpjFAAyPrOWfwbxPgfCxQam.GWofaMEDvQsTFZRKVjOQjsEXlnlQ.getValueDelegate = () => isUnityEditorFocused && isAllowedEditorWindowFocused;
								num = 1415602728;
								continue;
							}
							goto case 3;
						case 18:
							cjeGqndlCVJCPoJRsFlYDpDShHb();
							num = 1415602744;
							continue;
						case 14:
							WsNZNpjFAAyPrOWfwbxPgfCxQam.GWofaMEDvQsTFZRKVjOQjsEXlnlQ.Set(isUnityEditorFocused && isAllowedEditorWindowFocused);
							num = 1415602746;
							continue;
						case 15:
							if (UnityTools.isEditor)
							{
								num = 1415602730;
								continue;
							}
							wHILsHNdIXRfRroSPuxfTGaAZVA = 0;
							goto IL_021a;
						case 2:
							TjEnOXyhIcFYKPeZiqgPVRhKsqQ.JustBeforeControllerFullyDisconnectedEvent += lGcKTymIVPnyTtnJFgbcUzeJcSS.qreHAXgTzsFHANAUbdDdmiOhyk;
							ThreadSafeUnityInput.PostInitialize();
							rPsyhUJpVNDEPuLpHMzXIoCINKd();
							ThreadSafeUnityInput.PostInitialize2();
							HzFipmAIaHcroswSuDJaiaFCAYM = UnityTools.GetComponent<UserDataStore>(XSTHGbqTGxsAhksycZRiWDoTadf);
							if (HzFipmAIaHcroswSuDJaiaFCAYM != null)
							{
								HzFipmAIaHcroswSuDJaiaFCAYM.Initialize();
								num = 1415602731;
								continue;
							}
							goto case 18;
						case 3:
							XpXtObOKnvfLVKazkZmhfWVOUOi();
							VkvExSdGEsbPKBRQBRJHZMgQnlBL = new TimerAbs(1f);
							QPtGmChyFMyzZlDENzpxpKkvdDfb = new pcdrTgzsTsbzYzupVYcCrhXwihd();
							WaKcOYSXkOqONgayZlvoVAfGkFw(P_1);
							AQANKVsSPXqhjRcrczEkdvuTzzw = new vymLASJcQEATncxsXyaiNEjaYgR(P_4.GetActions_Copy());
							TjEnOXyhIcFYKPeZiqgPVRhKsqQ = new lCLAgzeBrhoeWjAjwfsCvCCcNbf(P_2, MDVmwweEvHoLmOhNxpYDWbEeYJl);
							lGcKTymIVPnyTtnJFgbcUzeJcSS = new ZxYDdEiisedLFBFHGsfeDMnmzxjo(P_2);
							MDVmwweEvHoLmOhNxpYDWbEeYJl.DeviceConnectedEvent += wWScwGwSbtNpNwuxoMDolOrGSFw;
							MDVmwweEvHoLmOhNxpYDWbEeYJl.DeviceDisconnectedEvent += TPFnSlhDMjjRnSrmgJJjBSMbEnh;
							MDVmwweEvHoLmOhNxpYDWbEeYJl.UpdateControllerInfoEvent += PcGZQZpCDacGEIeyJabJesZSGuUA;
							num = 1415602738;
							continue;
						case 19:
							wHILsHNdIXRfRroSPuxfTGaAZVA = ((!Application.isPlaying) ? 1 : 0);
							goto IL_021a;
						case 4:
						{
							ckqMYVULGCvECZjzNaYYeazfmsEa = UnityTools.editorPlatform;
							int num3;
							if (P_2.logToScreen)
							{
								num = 1415602737;
								num3 = num;
							}
							else
							{
								num = 1415602733;
								num3 = num;
							}
							continue;
						}
						case 10:
							WsNZNpjFAAyPrOWfwbxPgfCxQam.GWofaMEDvQsTFZRKVjOQjsEXlnlQ.Use();
							num = 1415602736;
							continue;
						case 7:
							wKNanqmBEVNDakkkYbwEHSSsAOab = UnityTools.platform;
							MahmSOufpIgWKHrJtunLQmCVLTSF = UnityTools.webplayerPlatform;
							num = 1415602749;
							continue;
						case 5:
						{
							int num2;
							if (veaLEHEEzCDKzITKHftSuYkBKal == null)
							{
								num = 1415602741;
								num2 = num;
							}
							else
							{
								num = 1415602740;
								num2 = num;
							}
							continue;
						}
						case 20:
							UnityTools.externalTools.EditorPausedStateChangedEvent += qKUsQtIjxTcodIkaTrRMcFNhuIHE;
							num = 1415602729;
							continue;
						case 11:
							TjEnOXyhIcFYKPeZiqgPVRhKsqQ.ControllerDisconnectStartedEvent += wIMaOmAVLcDMqSEJddKHLIBSxkvl;
							num = 1415602747;
							continue;
						case 13:
							veaLEHEEzCDKzITKHftSuYkBKal.Invoke();
							num = 1415602741;
							continue;
						case 8:
							Logger.logToScreen = true;
							num = 1415602733;
							continue;
						case 16:
							xWDCnqIoBGxYWmcirHenJdbGNrxL = P_3;
							stWFwgAKcHRiMeUYeMbPaDXDxKKn = P_4;
							P_4.dFyvOnKBbTYzKLbxHBbiIGdcrpeH();
							ThreadSafeUnityInput.Initialize();
							WsNZNpjFAAyPrOWfwbxPgfCxQam = new GigsgPepzmbLEqiYuZngCILzefXc();
							WsNZNpjFAAyPrOWfwbxPgfCxQam.GWofaMEDvQsTFZRKVjOQjsEXlnlQ.Set(oMEXmFzjqHWXGDnyqUQlTeSTaZM);
							num = 1415602739;
							continue;
						case 1:
							plUhMRKgrReNjpNYKBQDTiMWykj = false;
							if (WHILsHNdIXRfRroSPuxfTGaAZVA)
							{
								Logger.Log("Rewired is running in Edit mode.");
								num = 1415602748;
								continue;
							}
							goto case 5;
						case 17:
							if (WHILsHNdIXRfRroSPuxfTGaAZVA)
							{
								oMEXmFzjqHWXGDnyqUQlTeSTaZM = isEditorGameViewFocused;
								num = 1415602743;
								continue;
							}
							goto case 14;
						case 6:
							XSTHGbqTGxsAhksycZRiWDoTadf = P_0;
							EVFWZcZYsJTyVuPgkpnexuXAMzA = P_2;
							num = 1415602750;
							continue;
						case 12:
							return;
							IL_021a:
							WHILsHNdIXRfRroSPuxfTGaAZVA = (byte)wHILsHNdIXRfRroSPuxfTGaAZVA != 0;
							if (UnityTools.isEditor)
							{
								CheckRewiredVersionCompatibility();
								num = 1415602751;
								continue;
							}
							goto case 6;
						}
						break;
					}
				}
			}
			catch (Exception ex)
			{
				uvRIxvvRCxrfpiSXpAlvYqJtnEz = false;
				plUhMRKgrReNjpNYKBQDTiMWykj = false;
				throw ex;
			}
		}

		internal static void gvigjQaykylkiDxmhkUQKBzXkGmr()
		{
			if (QPtGmChyFMyzZlDENzpxpKkvdDfb != null)
			{
				QPtGmChyFMyzZlDENzpxpKkvdDfb.pPKdlVLEVRHZKFBPMTgIJXIaZTX();
				goto IL_0014;
			}
			goto IL_0090;
			IL_0090:
			int num = default(int);
			int num2;
			if (configVars.deferControllerConnectedEventsOnStart)
			{
				num = 0;
				num2 = 723363266;
				goto IL_0019;
			}
			return;
			IL_0014:
			num2 = 723363270;
			goto IL_0019;
			IL_0019:
			while (true)
			{
				switch (num2 ^ 0x2B1DA5C3)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					goto IL_003e;
				case 4:
				{
					Joystick joystick = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Joysticks_readOnly[num];
					PdAEvPcBpOIFSvxhNFtAGHDVTLbf(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
					num2 = 723363267;
					continue;
				}
				case 5:
					goto IL_0090;
				case 0:
					num++;
					num2 = 723363266;
					continue;
				case 2:
					return;
				}
				break;
				IL_003e:
				int num3;
				if (num >= TjEnOXyhIcFYKPeZiqgPVRhKsqQ.joystickCount)
				{
					num2 = 723363265;
					num3 = num2;
				}
				else
				{
					num2 = 723363271;
					num3 = num2;
				}
			}
			goto IL_0014;
		}

		internal static void NLXCharbQHJjphZbJIgpHiAuksK(UpdateLoopType P_0)
		{
			if (uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				bHodONIuEKidiSnObLjwgJbkntoK(P_0);
				switch (P_0)
				{
				case UpdateLoopType.Update:
				case UpdateLoopType.FixedUpdate:
					ZYipUoOeXWbUXhQETXauFkEwSVw();
					break;
				}
			}
		}

		private static void bHodONIuEKidiSnObLjwgJbkntoK(UpdateLoopType P_0)
		{
			if (WsNZNpjFAAyPrOWfwbxPgfCxQam != null)
			{
				WsNZNpjFAAyPrOWfwbxPgfCxQam.rdEJYvExbWYUXSDuseVgzyXPBhA();
			}
			Action<UpdateLoopType> xZqXkhILSDGEXwBcEJNnGqhcpdP = XZqXkhILSDGEXwBcEJNnGqhcpdP;
			if (xZqXkhILSDGEXwBcEJNnGqhcpdP != null)
			{
				try
				{
					xZqXkhILSDGEXwBcEJNnGqhcpdP(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.BeforeTimeManagerUpdateEvent", exception);
				}
			}
			QPtGmChyFMyzZlDENzpxpKkvdDfb.rdEJYvExbWYUXSDuseVgzyXPBhA(P_0);
		}

		private static void ZYipUoOeXWbUXhQETXauFkEwSVw()
		{
			int frameCount = Time.frameCount;
			if (KKhxiZkgLFEvukEOFInybJebTqgw == frameCount)
			{
				return;
			}
			while (true)
			{
				KKhxiZkgLFEvukEOFInybJebTqgw = frameCount;
				int num = -604177186;
				while (true)
				{
					switch (num ^ -604177185)
					{
					case 0:
						goto IL_000f;
					case 2:
						break;
					default:
					{
						ThreadSafeUnityInput.Update();
						Action qVhhsoRoWfagqYxuqPgpjSPtRaI = QVhhsoRoWfagqYxuqPgpjSPtRaI;
						if (qVhhsoRoWfagqYxuqPgpjSPtRaI != null)
						{
							try
							{
								qVhhsoRoWfagqYxuqPgpjSPtRaI();
								return;
							}
							catch (Exception exception)
							{
								HandleCallbackException("ReInput.EarlyUpdateEvent", exception);
								return;
							}
						}
						return;
					}
					}
					break;
					IL_000f:
					num = -604177187;
				}
			}
		}

		internal static void rdEJYvExbWYUXSDuseVgzyXPBhA(UpdateLoopType P_0)
		{
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				return;
			}
			while (true)
			{
				IL_00b9:
				int num;
				if (LUsVnbjyJOfEaVNiPspSYlQOFpA != P_0)
				{
					LUsVnbjyJOfEaVNiPspSYlQOFpA = P_0;
					num = -2111625005;
					goto IL_0010;
				}
				goto IL_0056;
				IL_0010:
				while (true)
				{
					int num2;
					switch (num ^ -2111625001)
					{
					case 0:
						num = -2111624993;
						continue;
					case 1:
						unityInputBuffer.rdEJYvExbWYUXSDuseVgzyXPBhA(P_0);
						num = -2111625003;
						continue;
					case 4:
						break;
					case 5:
						if (ccOzrrVGcsafLxHVjwAVdxIbRAX)
						{
							goto IL_0075;
						}
						goto default;
					case 3:
						num = -2111625003;
						continue;
					case 6:
						ccOzrrVGcsafLxHVjwAVdxIbRAX = false;
						VkvExSdGEsbPKBRQBRJHZMgQnlBL.Clear();
						num = -2111625004;
						continue;
					case 8:
						goto IL_00b9;
					case 7:
						aXqbHIdpTsdDdFaXuTcdkxcTnHaq = WsNZNpjFAAyPrOWfwbxPgfCxQam.OhYEFIeVBMhhNepcYHGpuRKWoYxg.value;
						num = -2111625006;
						continue;
					default:
						{
							WsNZNpjFAAyPrOWfwbxPgfCxQam.wAKMRHEHkrIbvzyzvXaCjtCQiWS();
							Action<UpdateLoopType> bNihuBrBiOUrGvXouejcrKFTBrg = BNihuBrBiOUrGvXouejcrKFTBrg;
							if (bNihuBrBiOUrGvXouejcrKFTBrg != null)
							{
								try
								{
									bNihuBrBiOUrGvXouejcrKFTBrg(P_0);
								}
								catch (Exception exception)
								{
									HandleCallbackException("ReInput.UpdateStartedEvent", exception);
								}
							}
							MDVmwweEvHoLmOhNxpYDWbEeYJl.Update(P_0);
							if (JPavcstGOjcicVpGivxYfYrfbSI != null)
							{
								JPavcstGOjcicVpGivxYfYrfbSI.Invoke();
								goto IL_0135;
							}
							goto IL_0153;
						}
						IL_0135:
						num2 = -2111625002;
						goto IL_013a;
						IL_0153:
						TjEnOXyhIcFYKPeZiqgPVRhKsqQ.rdEJYvExbWYUXSDuseVgzyXPBhA(P_0);
						num2 = -2111625003;
						goto IL_013a;
						IL_013a:
						switch (num2 ^ -2111625001)
						{
						case 0:
							break;
						case 1:
							goto IL_0153;
						default:
						{
							Action<UpdateLoopType> nXiFFMqnZmfDNLoDSXyYngPXILU = NXiFFMqnZmfDNLoDSXyYngPXILU;
							if (nXiFFMqnZmfDNLoDSXyYngPXILU != null)
							{
								try
								{
									nXiFFMqnZmfDNLoDSXyYngPXILU(P_0);
									return;
								}
								catch (Exception exception2)
								{
									HandleCallbackException("ReInput.UpdateEndedEvent", exception2);
									return;
								}
							}
							return;
						}
						}
						goto IL_0135;
					}
					break;
					IL_0075:
					int num3;
					if (!VkvExSdGEsbPKBRQBRJHZMgQnlBL.Update())
					{
						num = -2111625002;
						num3 = num;
					}
					else
					{
						num = -2111625007;
						num3 = num;
					}
				}
				goto IL_0056;
				IL_0056:
				int num4;
				if (editorPlatform != EditorPlatform.None)
				{
					num = -2111625008;
					num4 = num;
				}
				else
				{
					num = -2111625006;
					num4 = num;
				}
				goto IL_0010;
			}
		}

		internal static void jKEaAMFsgoDvEEkJWYugCiweHfww()
		{
			Action action = fsUyQtZnJxoEDyniNBWWYHXEApq;
			if (action != null)
			{
				try
				{
					action();
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.LateUpdateEvent", exception);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void EditorUpdate()
		{
			if (uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				if (!WHILsHNdIXRfRroSPuxfTGaAZVA)
				{
					goto IL_000e;
				}
				goto IL_0038;
			}
			return;
			IL_0038:
			NLXCharbQHJjphZbJIgpHiAuksK(UpdateLoopType.Update);
			rdEJYvExbWYUXSDuseVgzyXPBhA(UpdateLoopType.Update);
			int num = 1571869045;
			goto IL_0013;
			IL_000e:
			num = 1571869047;
			goto IL_0013;
			IL_0013:
			switch (num ^ 0x5DB0D176)
			{
			case 0:
				break;
			case 1:
				return;
			case 2:
				goto IL_0038;
			default:
				jKEaAMFsgoDvEEkJWYugCiweHfww();
				return;
			}
			goto IL_000e;
		}

		internal static void JBwfYqGfajxfcWcHzCLWCKMjHVvs()
		{
			if (XBntwEZwxDiXXrDcjkXtevSVFEp != null)
			{
				XBntwEZwxDiXXrDcjkXtevSVFEp.Invoke();
				goto IL_0011;
			}
			goto IL_006b;
			IL_004e:
			OoCMSnRZTkdIRmfuBjaAfdGuqTg();
			int num;
			int num2;
			if (ZvKOJYzwYcanwKFkFfbngqgolQIa != null)
			{
				num = 1885836410;
				num2 = num;
			}
			else
			{
				num = 1885836412;
				num2 = num;
			}
			goto IL_0016;
			IL_0011:
			num = 1885836409;
			goto IL_0016;
			IL_0016:
			while (true)
			{
				switch (num ^ 0x70679478)
				{
				case 3:
					break;
				default:
					return;
				case 2:
					ZvKOJYzwYcanwKFkFfbngqgolQIa.Invoke();
					ZvKOJYzwYcanwKFkFfbngqgolQIa = null;
					num = 1885836412;
					continue;
				case 0:
					goto IL_004e;
				case 1:
					goto IL_006b;
				case 4:
					return;
				}
				break;
			}
			goto IL_0011;
			IL_006b:
			if (MDVmwweEvHoLmOhNxpYDWbEeYJl != null)
			{
				MDVmwweEvHoLmOhNxpYDWbEeYJl.OnDestroy();
				num = 1885836408;
				goto IL_0016;
			}
			goto IL_004e;
		}

		internal static void vWcNAKGkGNNiFskZgGGhkhvxnhWh()
		{
			if (HEgtPpMbFQRllZrBwUENCxlfJKQ == null)
			{
				goto IL_0007;
			}
			goto IL_0031;
			IL_0007:
			int num = -90352371;
			goto IL_000c;
			IL_000c:
			switch (num ^ -90352370)
			{
			case 2:
				break;
			default:
				return;
			case 3:
				return;
			case 0:
				goto IL_0031;
			case 1:
				return;
			}
			goto IL_0007;
			IL_0031:
			HEgtPpMbFQRllZrBwUENCxlfJKQ.Invoke();
			num = -90352369;
			goto IL_000c;
		}

		internal static void xfVYforgrLHvQFdjgERarRwUcLx(bool P_0)
		{
			oMEXmFzjqHWXGDnyqUQlTeSTaZM = P_0;
			if (ckqMYVULGCvECZjzNaYYeazfmsEa != EditorPlatform.None)
			{
				goto IL_000d;
			}
			goto IL_007a;
			IL_000d:
			int num = -831231602;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -831231606)
				{
				case 3:
					break;
				default:
					return;
				case 2:
					WsNZNpjFAAyPrOWfwbxPgfCxQam.GWofaMEDvQsTFZRKVjOQjsEXlnlQ.Set(P_0);
					num = -831231601;
					continue;
				case 5:
					WsNZNpjFAAyPrOWfwbxPgfCxQam.GWofaMEDvQsTFZRKVjOQjsEXlnlQ.TriggerEvent();
					num = -831231606;
					continue;
				case 6:
					return;
				case 4:
					return;
				case 1:
					goto IL_007a;
				case 0:
					return;
				}
				break;
			}
			goto IL_000d;
			IL_007a:
			int num2;
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				num = -831231604;
				num2 = num;
			}
			else
			{
				num = -831231608;
				num2 = num;
			}
			goto IL_0012;
		}

		internal static void lKgpRjXeIOxAYlPiJMYtfcBETiM()
		{
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				return;
			}
			while (true)
			{
				Action action = qZjCeoLIlcLsqfGfrlmQKYASUXs;
				int num = 395286158;
				while (true)
				{
					switch (num ^ 0x178F968E)
					{
					case 2:
						goto IL_0008;
					case 1:
						break;
					default:
						if (action == null)
						{
							return;
						}
						try
						{
							action();
							return;
						}
						catch (Exception exception)
						{
							while (true)
							{
								int num2 = 395286159;
								while (true)
								{
									switch (num2 ^ 0x178F968E)
									{
									case 0:
										break;
									default:
										return;
									case 1:
										goto IL_005d;
									case 2:
										return;
									}
									break;
									IL_005d:
									HandleCallbackException("ReInput.SceneLoadedEvent", exception);
									num2 = 395286156;
								}
							}
						}
					}
					break;
					IL_0008:
					num = 395286159;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return xWDCnqIoBGxYWmcirHenJdbGNrxL.WxVPhQkmgNwSnAqCPVfHhzPrFYU(bridgedController);
		}

		internal static HardwareJoystickMap rOAaoWrkpxRacuEqvnMgozPcpLi(Guid P_0)
		{
			return xWDCnqIoBGxYWmcirHenJdbGNrxL.GetHardwareJoystickMap(P_0);
		}

		internal static HardwareJoystickTemplateMap trWVNTJMAihjoCbseTOaZKfBTFD(Guid P_0)
		{
			return xWDCnqIoBGxYWmcirHenJdbGNrxL.GetJoystickTemplate(P_0);
		}

		internal static IHardwareControllerTemplateMap MWJmuxJUDhogOmPBQHfSBzzBXHM(Guid P_0)
		{
			return xWDCnqIoBGxYWmcirHenJdbGNrxL.GetControllerTemplate(P_0);
		}

		internal static IList<HardwareJoystickTemplateMap> NWqyoHHBVkTlIVXcKtnFOfKuruo(Guid P_0)
		{
			HardwareJoystickMap hardwareJoystickMap = xWDCnqIoBGxYWmcirHenJdbGNrxL.GetHardwareJoystickMap(P_0);
			if (hardwareJoystickMap == null)
			{
				return EmptyObjects<HardwareJoystickTemplateMap>.EmptyReadOnlyIListT;
			}
			string[] templateGuidsOrig = hardwareJoystickMap.GetTemplateGuidsOrig();
			List<HardwareJoystickTemplateMap> list = default(List<HardwareJoystickTemplateMap>);
			int num;
			if (templateGuidsOrig != null)
			{
				if (templateGuidsOrig.Length == 0)
				{
					goto IL_002a;
				}
				list = null;
				num = -174801922;
				goto IL_002f;
			}
			goto IL_004c;
			IL_002f:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -174801921)
				{
				case 0:
					break;
				case 3:
					goto IL_004c;
				case 1:
					num2 = 0;
					num = -174801923;
					continue;
				default:
					goto IL_00f9;
				}
				break;
			}
			goto IL_002a;
			IL_004c:
			return EmptyObjects<HardwareJoystickTemplateMap>.EmptyReadOnlyIListT;
			IL_00f9:
			Guid guid = default(Guid);
			HardwareJoystickTemplateMap hardwareJoystickTemplateMap = default(HardwareJoystickTemplateMap);
			while (true)
			{
				IL_00f9_2:
				if (num2 < templateGuidsOrig.Length)
				{
					try
					{
						guid = new Guid(templateGuidsOrig[num2]);
					}
					catch
					{
						Logger.LogWarning("Controller Template GUID is invalid: " + templateGuidsOrig[num2]);
						goto IL_00ee;
					}
					hardwareJoystickTemplateMap = trWVNTJMAihjoCbseTOaZKfBTFD(guid);
					goto IL_0093;
				}
				int num3 = -174801927;
				goto IL_0098;
				IL_00ee:
				num2++;
				num3 = -174801926;
				goto IL_0098;
				IL_0098:
				while (true)
				{
					switch (num3 ^ -174801921)
					{
					case 3:
						break;
					case 2:
						if (hardwareJoystickTemplateMap == null)
						{
							Logger.LogWarning("Controller Template was not found for GUID " + guid.ToString());
							num3 = -174801922;
							continue;
						}
						goto case 4;
					case 1:
						goto IL_00ee;
					case 5:
						goto IL_00f9_2;
					case 0:
						ListTools.AddIfUnique(list, hardwareJoystickTemplateMap);
						num3 = -174801922;
						continue;
					case 4:
						if (list == null)
						{
							list = new List<HardwareJoystickTemplateMap>();
							num3 = -174801921;
							continue;
						}
						goto case 0;
					default:
						goto end_IL_00f9;
					}
					break;
				}
				goto IL_0093;
				IL_0093:
				num3 = -174801923;
				goto IL_0098;
				continue;
				end_IL_00f9:
				break;
			}
			if (list == null)
			{
				return EmptyObjects<HardwareJoystickTemplateMap>.EmptyReadOnlyIListT;
			}
			return list;
			IL_002a:
			num = -174801924;
			goto IL_002f;
		}

		[CustomObfuscation(rename = false)]
		internal static int GetNewJoystickId()
		{
			return TjEnOXyhIcFYKPeZiqgPVRhKsqQ.tLjNNUMmtSAassYXZEJDlDDsGmw();
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleCallbackException(string source, Exception exception)
		{
			string msg = "Rewired: An exception occurred inside an event handler or callback.\nSource: " + source + "\n\nThis happens if your event handler/callback code throws an exception. This means the error in your code, not Rewired. Read the exception message and the stack trace carefully to find the source of the exception being thrown by your code.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed. Make sure you unsubscribe to events in OnDisable or OnDestroy. Rewired will attempt to continue running.\n\nException:\n" + exception;
			Logger.LogError(msg, true);
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleExternException(string source, Exception exception)
		{
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleExternalInterfaceException(string source, Exception exception)
		{
			string msg = "Rewired: An exception occurred inside an external function call.\nSource: " + source + "\n\nThis happens if the external function throws an exception. This could indicate the error is in your code if Rewired is calling a function in an interface implementation you created. Read the exception message and the stack trace carefully to find the source of the exception being thrown.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed.\n\nException:\n" + exception;
			Logger.LogError(msg, true);
		}

		internal static void iYtGJBsuIAzSTPHeHgICfcjZmvmP()
		{
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				return;
			}
			while (true)
			{
				cjeGqndlCVJCPoJRsFlYDpDShHb();
				int num = -1627807691;
				while (true)
				{
					switch (num ^ -1627807691)
					{
					case 2:
						goto IL_0008;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0008:
					num = -1627807692;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
			if (UnityTools.unityVersionObj != null && 2018 != UnityTools.unityVersionObj.major)
			{
				zyYmEeFbGvaSZdiSxOjchwoNioe();
			}
		}

		internal static float XBhsGGLkGfwRCMSrvfILgkYnaKK()
		{
			return WsNZNpjFAAyPrOWfwbxPgfCxQam.kSDReLSYweLZZvBfBIpurrNInte.value;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized()
		{
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				Logger.LogError("Rewired is not initialized. You must have an active and enabled Rewired Input Manager in the scene before calling any part of the Rewired API.");
				return false;
			}
			return true;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized(int reInputId)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			if (_id != reInputId)
			{
				while (true)
				{
					int num = 1822593445;
					while (true)
					{
						switch (num ^ 0x6CA291A7)
						{
						case 0:
							break;
						case 2:
							goto IL_002f;
						default:
							return false;
						}
						break;
						IL_002f:
						Logger.LogError("You are attemping to access an object that was created by a previous session or different instance of Rewired and is no longer valid. When Rewired is reset or the Rewired Input Manager is disabled or destroyed, all old object references become invalid and can no longer be used. If you deinitialize Rewired, you cannot use locally stored Rewired objects obtained prior to deinitialization and you must get new objects from the Rewired API.");
						num = 1822593446;
					}
				}
			}
			return true;
		}

		private static void rPsyhUJpVNDEPuLpHMzXIoCINKd()
		{
			lGcKTymIVPnyTtnJFgbcUzeJcSS.dFyvOnKBbTYzKLbxHBbiIGdcrpeH();
			while (true)
			{
				int num = -869749192;
				while (true)
				{
					switch (num ^ -869749191)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0028;
					case 2:
						return;
					}
					break;
					IL_0028:
					TjEnOXyhIcFYKPeZiqgPVRhKsqQ.dFyvOnKBbTYzKLbxHBbiIGdcrpeH(MDVmwweEvHoLmOhNxpYDWbEeYJl.GetInputDataUpdateDelegate(), stWFwgAKcHRiMeUYeMbPaDXDxKKn.GetInputBehaviors_Copy());
					MDVmwweEvHoLmOhNxpYDWbEeYJl.Initialize();
					num = -869749189;
				}
			}
		}

		private static void OoCMSnRZTkdIRmfuBjaAfdGuqTg()
		{
			if (!(XSTHGbqTGxsAhksycZRiWDoTadf != null))
			{
				goto IL_00e3;
			}
			List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(XSTHGbqTGxsAhksycZRiWDoTadf);
			int num = 0;
			goto IL_01dd;
			IL_0027:
			int num2;
			while (true)
			{
				switch (num2 ^ 0x2D8A5BBA)
				{
				case 6:
					num2 = 764042174;
					continue;
				default:
					return;
				case 2:
					wKNanqmBEVNDakkkYbwEHSSsAOab = Platform.Windows;
					num2 = 764042160;
					continue;
				case 9:
					BNihuBrBiOUrGvXouejcrKFTBrg = null;
					num2 = 764042167;
					continue;
				case 4:
					componentsInSelfAndChildren[num].Deinitialize();
					num++;
					num2 = 764042166;
					continue;
				case 13:
					NXiFFMqnZmfDNLoDSXyYngPXILU = null;
					num2 = 764042162;
					continue;
				case 7:
					MNCBXKvckaAmEBcrOabhuDDZCQB = null;
					uvRIxvvRCxrfpiSXpAlvYqJtnEz = false;
					EVFWZcZYsJTyVuPgkpnexuXAMzA = null;
					LUsVnbjyJOfEaVNiPspSYlQOFpA = UpdateLoopType.Update;
					aqQNYTLFCDaASydZMAHFATKUUjI = false;
					num2 = 764042168;
					continue;
				case 15:
					break;
				case 0:
					TjEnOXyhIcFYKPeZiqgPVRhKsqQ = null;
					lGcKTymIVPnyTtnJFgbcUzeJcSS = null;
					xWDCnqIoBGxYWmcirHenJdbGNrxL = null;
					stWFwgAKcHRiMeUYeMbPaDXDxKKn = null;
					num2 = 764042173;
					continue;
				case 5:
					HEgtPpMbFQRllZrBwUENCxlfJKQ.Clear();
					_ApplicationFocusChangedEvent = null;
					sAJQmkmbuIcDAUklbGHjjUNkZTop = null;
					RqvahHIhRDMioudYIfeVcMkMGGf = null;
					UbrbNqJvUJFgmbLUOuVYXKYzCpHH = null;
					KHtlJkitkzQqpQeuqNYaQSQKZjp = null;
					QVhhsoRoWfagqYxuqPgpjSPtRaI = null;
					num2 = 764042163;
					continue;
				case 10:
					MahmSOufpIgWKHrJtunLQmCVLTSF = WebplayerPlatform.None;
					ckqMYVULGCvECZjzNaYYeazfmsEa = EditorPlatform.None;
					ccOzrrVGcsafLxHVjwAVdxIbRAX = false;
					VkvExSdGEsbPKBRQBRJHZMgQnlBL = null;
					QPtGmChyFMyzZlDENzpxpKkvdDfb = null;
					aXqbHIdpTsdDdFaXuTcdkxcTnHaq = null;
					NuJlATmYOMdWXRRTuCaVCBLtlrF = false;
					WHILsHNdIXRfRroSPuxfTGaAZVA = false;
					oMEXmFzjqHWXGDnyqUQlTeSTaZM = true;
					KKhxiZkgLFEvukEOFInybJebTqgw = -1;
					_id = -1;
					OlnysszPISQEicKQWslggkKFqnM = 0;
					num2 = 764042169;
					continue;
				case 3:
					aqgigOlBfGHpfkLCGHEzRHgPFjmO.Clear();
					TDaZvgnLddQRBxhdBTgymJOadUC.Clear();
					XWfBrEITLvBtiDlpQLZJwhJXhoIX.Clear();
					JPavcstGOjcicVpGivxYfYrfbSI.Clear();
					num2 = 764042175;
					continue;
				case 12:
					goto IL_01dd;
				case 1:
					XBntwEZwxDiXXrDcjkXtevSVFEp = null;
					qZjCeoLIlcLsqfGfrlmQKYASUXs = null;
					HNDbYpCNsvQvOLTcxZfIflUMliNS = null;
					QOVbCHaPWhmzfEISmSljZVnZtGc();
					WsNZNpjFAAyPrOWfwbxPgfCxQam = null;
					ThreadSafeUnityInput.Deinitialize();
					if (UnityTools.externalTools != null)
					{
						UnityTools.externalTools.EditorPausedStateChangedEvent -= qKUsQtIjxTcodIkaTrRMcFNhuIHE;
						num2 = 764042161;
						continue;
					}
					return;
				case 8:
					fsUyQtZnJxoEDyniNBWWYHXEApq = null;
					num2 = 764042171;
					continue;
				case 14:
					if (TjEnOXyhIcFYKPeZiqgPVRhKsqQ != null)
					{
						TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Dispose();
						num2 = 764042170;
						continue;
					}
					goto case 0;
				case 11:
					return;
				}
				break;
			}
			goto IL_00e3;
			IL_01dd:
			int num3;
			if (num < componentsInSelfAndChildren.Count)
			{
				num2 = 764042174;
				num3 = num2;
			}
			else
			{
				num2 = 764042165;
				num3 = num2;
			}
			goto IL_0027;
			IL_00e3:
			XSTHGbqTGxsAhksycZRiWDoTadf = null;
			MDVmwweEvHoLmOhNxpYDWbEeYJl = null;
			AQANKVsSPXqhjRcrczEkdvuTzzw = null;
			num2 = 764042164;
			goto IL_0027;
		}

		private static void MoHOjSyzyNDztCgAccQYOiAUvne(string P_0 = null)
		{
			string text;
			if (P_0 != null)
			{
				text = P_0;
			}
			else
			{
				while (true)
				{
					text = "This function";
					int num = 2072079473;
					while (true)
					{
						switch (num ^ 0x7B816C73)
						{
						case 0:
							num = 2072079474;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0025;
						}
						break;
					}
					continue;
					end_IL_0025:
					break;
				}
			}
			Logger.LogError(text + " can only be called in Play mode!");
		}

		private static void ptNnzwiFJXsgxOxpTIMJDbmpoTX()
		{
			if (!ccOzrrVGcsafLxHVjwAVdxIbRAX)
			{
				ccOzrrVGcsafLxHVjwAVdxIbRAX = true;
				unityInputBuffer.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
				unityInputBuffer.iwZOgPPbdtgVnQcmicAIfcjFBilD();
				goto IL_0021;
			}
			goto IL_003f;
			IL_003f:
			VkvExSdGEsbPKBRQBRJHZMgQnlBL.Start();
			int num = 1521687635;
			goto IL_0026;
			IL_0021:
			num = 1521687634;
			goto IL_0026;
			IL_0026:
			switch (num ^ 0x5AB31C53)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_003f;
			case 0:
				return;
			}
			goto IL_0021;
		}

		private static void ZEpXkkjVNmwfEKNRsLXtFMLePQl()
		{
			Logger.LogError("Rewired is not initialized. Do you have a Rewired Input Manager in the scene and enabled?");
		}

		private static void wWScwGwSbtNpNwuxoMDolOrGSFw(BridgedController P_0)
		{
			if (P_0.sourceJoystick == null)
			{
				return;
			}
			while (true)
			{
				TjEnOXyhIcFYKPeZiqgPVRhKsqQ.zhGxfbZxWjAFIPgTHcFcOdkiAPT(P_0);
				Joystick joystick = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.oDPKIGALeDTydQUPLxZoBnImPhj(P_0.sourceJoystick.rewiredId);
				if (joystick == null)
				{
					break;
				}
				while (true)
				{
					IL_0064:
					lGcKTymIVPnyTtnJFgbcUzeJcSS.zQsgfajurXOpIxqySqTWGGZkXLR(joystick);
					if (configVars.deferControllerConnectedEventsOnStart)
					{
						int num;
						int num2;
						if (!plUhMRKgrReNjpNYKBQDTiMWykj)
						{
							num = -350467130;
							num2 = num;
						}
						else
						{
							num = -350467134;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -350467134)
							{
							case 3:
								num = -350467133;
								continue;
							case 1:
								break;
							case 0:
								return;
							case 2:
								goto IL_0064;
							default:
								goto IL_0096;
							}
							break;
						}
						break;
					}
					goto IL_0096;
					IL_0096:
					PdAEvPcBpOIFSvxhNFtAGHDVTLbf(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
					return;
				}
			}
		}

		private static void TPFnSlhDMjjRnSrmgJJjBSMbEnh(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				Joystick joystick = TjEnOXyhIcFYKPeZiqgPVRhKsqQ.oDPKIGALeDTydQUPLxZoBnImPhj(P_0.rewiredId);
				int num;
				int num2;
				if (joystick == null)
				{
					num = -1596811942;
					num2 = num;
				}
				else
				{
					num = -1596811943;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1596811941)
					{
					case 0:
						goto IL_0004;
					case 3:
						break;
					case 1:
						return;
					default:
						TjEnOXyhIcFYKPeZiqgPVRhKsqQ.RddwpyrUWFEoRsZUxnPYyeqToGd(P_0.rewiredId);
						tgnpqBjbIbCnwDzryBUHTIOvoaT(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
						return;
					}
					break;
					IL_0004:
					num = -1596811944;
				}
			}
		}

		private static void PdAEvPcBpOIFSvxhNFtAGHDVTLbf(ControllerStatusChangedEventArgs P_0)
		{
			if (aqgigOlBfGHpfkLCGHEzRHgPFjmO != null)
			{
				aqgigOlBfGHpfkLCGHEzRHgPFjmO.Invoke(P_0);
			}
		}

		private static void wIMaOmAVLcDMqSEJddKHLIBSxkvl(ControllerStatusChangedEventArgs P_0)
		{
			if (TDaZvgnLddQRBxhdBTgymJOadUC == null)
			{
				return;
			}
			while (true)
			{
				int num = 929946025;
				while (true)
				{
					switch (num ^ 0x376DD9AB)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0025;
					case 1:
						return;
					}
					break;
					IL_0025:
					TDaZvgnLddQRBxhdBTgymJOadUC.Invoke(P_0);
					num = 929946026;
				}
			}
		}

		private static void tgnpqBjbIbCnwDzryBUHTIOvoaT(ControllerStatusChangedEventArgs P_0)
		{
			if (XWfBrEITLvBtiDlpQLZJwhJXhoIX != null)
			{
				XWfBrEITLvBtiDlpQLZJwhJXhoIX.Invoke(P_0);
			}
		}

		private static void PcGZQZpCDacGEIeyJabJesZSGuUA(UpdateControllerInfoEventArgs P_0)
		{
			TjEnOXyhIcFYKPeZiqgPVRhKsqQ.pQXjcKMGYFWhIbqKYqxvIuNhDSM(P_0);
		}

		private static void xltRnWzfKredmaiyAQFcSDIhKcdz(bool P_0)
		{
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				while (true)
				{
					switch (-98334949 ^ -98334950)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			Action<bool> applicationFocusChangedEvent = _ApplicationFocusChangedEvent;
			if (applicationFocusChangedEvent != null)
			{
				try
				{
					applicationFocusChangedEvent(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationFocusChangedEvent", exception);
				}
			}
		}

		private static void ucNhYNhgvdopNThFWipkkYqQaVe(bool P_0)
		{
			Action<bool> action = sAJQmkmbuIcDAUklbGHjjUNkZTop;
			if (action != null)
			{
				try
				{
					action(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationIsFullScreenChangedEvent", exception);
				}
			}
		}

		private static void awdOxIOJZVFVpdIRaNTLltSRfwv(int P_0)
		{
			if (UbrbNqJvUJFgmbLUOuVYXKYzCpHH != null)
			{
				try
				{
					UbrbNqJvUJFgmbLUOuVYXKYzCpHH((FullScreenMode)P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationFullScreenModeChangedEvent", exception);
				}
			}
		}

		private static void oODzjlQZNZVwCphxmCrwMjXMlXY(bool P_0)
		{
			Action<bool> rqvahHIhRDMioudYIfeVcMkMGGf = RqvahHIhRDMioudYIfeVcMkMGGf;
			if (rqvahHIhRDMioudYIfeVcMkMGGf != null)
			{
				try
				{
					rqvahHIhRDMioudYIfeVcMkMGGf(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationRunInBackgroundChangedEvent", exception);
				}
			}
		}

		private static void CcJVUwNGkVsiSGSCwBSlYrWDspk(bool P_0)
		{
			OlnysszPISQEicKQWslggkKFqnM++;
			Action<bool> kHtlJkitkzQqpQeuqNYaQSQKZjp = KHtlJkitkzQqpQeuqNYaQSQKZjp;
			if (kHtlJkitkzQqpQeuqNYaQSQKZjp != null)
			{
				try
				{
					kHtlJkitkzQqpQeuqNYaQSQKZjp(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.TimeScalePauseChangedEvent", exception);
				}
			}
		}

		private static void XpXtObOKnvfLVKazkZmhfWVOUOi()
		{
			if (WsNZNpjFAAyPrOWfwbxPgfCxQam == null)
			{
				goto IL_0007;
			}
			goto IL_0038;
			IL_0007:
			int num = -1186373014;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ -1186373016)
				{
				case 0:
					break;
				case 2:
					return;
				case 4:
					goto IL_0038;
				case 1:
					WsNZNpjFAAyPrOWfwbxPgfCxQam.GWofaMEDvQsTFZRKVjOQjsEXlnlQ.ChangedEvent += xltRnWzfKredmaiyAQFcSDIhKcdz;
					WsNZNpjFAAyPrOWfwbxPgfCxQam.KxMFnVhrvWePdEFocFhJZJavPDPm.ChangedEvent += ucNhYNhgvdopNThFWipkkYqQaVe;
					WsNZNpjFAAyPrOWfwbxPgfCxQam.tuePXEXCllLWVEsrShnUubANHkoJ.ChangedEvent += oODzjlQZNZVwCphxmCrwMjXMlXY;
					WsNZNpjFAAyPrOWfwbxPgfCxQam.lZADyAaQIBGYNaQOEzrFKhsPUMe.ChangedEvent += awdOxIOJZVFVpdIRaNTLltSRfwv;
					num = -1186373013;
					continue;
				default:
					WsNZNpjFAAyPrOWfwbxPgfCxQam.iIwLmFGPOWeUeyTyUOtHZpptrJQ.ChangedEvent += CcJVUwNGkVsiSGSCwBSlYrWDspk;
					return;
				}
				break;
			}
			goto IL_0007;
			IL_0038:
			QOVbCHaPWhmzfEISmSljZVnZtGc();
			num = -1186373015;
			goto IL_000c;
		}

		private static void QOVbCHaPWhmzfEISmSljZVnZtGc()
		{
			if (WsNZNpjFAAyPrOWfwbxPgfCxQam == null)
			{
				goto IL_0007;
			}
			goto IL_0079;
			IL_0007:
			int num = -1351698052;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ -1351698051)
				{
				case 2:
					break;
				case 1:
					return;
				case 3:
					WsNZNpjFAAyPrOWfwbxPgfCxQam.tuePXEXCllLWVEsrShnUubANHkoJ.ChangedEvent -= oODzjlQZNZVwCphxmCrwMjXMlXY;
					WsNZNpjFAAyPrOWfwbxPgfCxQam.lZADyAaQIBGYNaQOEzrFKhsPUMe.ChangedEvent -= awdOxIOJZVFVpdIRaNTLltSRfwv;
					num = -1351698055;
					continue;
				case 5:
					goto IL_0079;
				case 0:
					WsNZNpjFAAyPrOWfwbxPgfCxQam.KxMFnVhrvWePdEFocFhJZJavPDPm.ChangedEvent -= ucNhYNhgvdopNThFWipkkYqQaVe;
					num = -1351698050;
					continue;
				default:
					WsNZNpjFAAyPrOWfwbxPgfCxQam.iIwLmFGPOWeUeyTyUOtHZpptrJQ.ChangedEvent -= CcJVUwNGkVsiSGSCwBSlYrWDspk;
					return;
				}
				break;
			}
			goto IL_0007;
			IL_0079:
			WsNZNpjFAAyPrOWfwbxPgfCxQam.GWofaMEDvQsTFZRKVjOQjsEXlnlQ.ChangedEvent -= xltRnWzfKredmaiyAQFcSDIhKcdz;
			num = -1351698051;
			goto IL_000c;
		}

		private static void qKUsQtIjxTcodIkaTrRMcFNhuIHE(bool P_0)
		{
			Action<bool> hNDbYpCNsvQvOLTcxZfIflUMliNS = HNDbYpCNsvQvOLTcxZfIflUMliNS;
			if (hNDbYpCNsvQvOLTcxZfIflUMliNS == null)
			{
				return;
			}
			try
			{
				hNDbYpCNsvQvOLTcxZfIflUMliNS(P_0);
			}
			catch (Exception exception)
			{
				while (true)
				{
					int num = 489841961;
					while (true)
					{
						switch (num ^ 0x1D326528)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0031;
						case 2:
							return;
						}
						break;
						IL_0031:
						HandleCallbackException("ReInput.EditorPauseChangedEvent", exception);
						num = 489841962;
					}
				}
			}
		}

		private static void WaKcOYSXkOqONgayZlvoVAfGkFw(Func<ConfigVars, object> P_0)
		{
			bool flag = configVars.DoesPlatformUseFallback(UnityTools.platform, UnityTools.webplayerPlatform, isEditor);
			if (!flag)
			{
				List<IExternalInputManager> componentsInSelfAndChildren = default(List<IExternalInputManager>);
				int num2 = default(int);
				while (true)
				{
					int num = 951806111;
					while (true)
					{
						switch (num ^ 0x38BB689E)
						{
						case 8:
							break;
						case 1:
							componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(XSTHGbqTGxsAhksycZRiWDoTadf);
							num = 951806105;
							continue;
						case 7:
							num2 = 0;
							num = 951806107;
							continue;
						case 6:
						{
							PlatformInputManager platformInputManager = componentsInSelfAndChildren[num2].Initialize(UnityTools.platform, EVFWZcZYsJTyVuPgkpnexuXAMzA) as PlatformInputManager;
							if (platformInputManager != null)
							{
								MDVmwweEvHoLmOhNxpYDWbEeYJl = platformInputManager;
								return;
							}
							goto case 2;
						}
						case 0:
							goto end_IL_0020;
						case 2:
							num2++;
							num = 951806106;
							continue;
						case 5:
							num = 951806106;
							continue;
						case 4:
							goto IL_00e5;
						default:
							goto IL_0102;
						}
						break;
						IL_00e5:
						int num3;
						if (num2 >= componentsInSelfAndChildren.Count)
						{
							num = 951806110;
							num3 = num;
						}
						else
						{
							num = 951806104;
							num3 = num;
						}
					}
					continue;
					end_IL_0020:
					break;
				}
			}
			if (!flag)
			{
				goto IL_0102;
			}
			aqQNYTLFCDaASydZMAHFATKUUjI = true;
			MDVmwweEvHoLmOhNxpYDWbEeYJl = new XcPhIaWtTJbGpRDjcDeYUxCKXJV(EVFWZcZYsJTyVuPgkpnexuXAMzA.updateLoop);
			goto IL_04e8;
			IL_04e8:
			if (MDVmwweEvHoLmOhNxpYDWbEeYJl != null)
			{
				return;
			}
			while (true)
			{
				int num4 = 951806111;
				while (true)
				{
					switch (num4 ^ 0x38BB689E)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_050d;
					case 2:
						return;
					}
					break;
					IL_050d:
					aqQNYTLFCDaASydZMAHFATKUUjI = true;
					MDVmwweEvHoLmOhNxpYDWbEeYJl = new XcPhIaWtTJbGpRDjcDeYUxCKXJV(EVFWZcZYsJTyVuPgkpnexuXAMzA.updateLoop);
					num4 = 951806108;
				}
			}
			IL_0218:
			MDVmwweEvHoLmOhNxpYDWbEeYJl = P_0(EVFWZcZYsJTyVuPgkpnexuXAMzA) as PlatformInputManager;
			int num5 = 951806106;
			goto IL_01b9;
			IL_0234:
			if (UnityTools.platform == Platform.WebGL && !isEditor)
			{
				try
				{
					MDVmwweEvHoLmOhNxpYDWbEeYJl = P_0(EVFWZcZYsJTyVuPgkpnexuXAMzA) as PlatformInputManager;
					while (true)
					{
						switch (0x38BB689C ^ 0x38BB689E)
						{
						case 0:
							break;
						default:
							goto end_IL_0259;
						case 2:
							if (MDVmwweEvHoLmOhNxpYDWbEeYJl == null)
							{
								throw new Exception();
							}
							goto end_IL_0259;
						case 1:
							goto end_IL_0259;
						}
						continue;
						end_IL_0259:
						break;
					}
				}
				catch
				{
					Logger.LogError("WebGL platform could not be initialized! Is the Rewired WebGL library installed? See the documentation for more information.");
					MDVmwweEvHoLmOhNxpYDWbEeYJl = null;
				}
			}
			else if (UnityTools.platform == Platform.XboxOne && !isEditor)
			{
				try
				{
					XboxOneInputSource customInputSource = new XboxOneInputSource();
					MDVmwweEvHoLmOhNxpYDWbEeYJl = new CustomInputManager(customInputSource, EVFWZcZYsJTyVuPgkpnexuXAMzA.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (MDVmwweEvHoLmOhNxpYDWbEeYJl == null)
					{
						while (true)
						{
							switch (0x38BB689C ^ 0x38BB689E)
							{
							case 0:
								break;
							default:
								goto end_IL_02f8;
							case 2:
								throw new Exception();
							case 1:
								goto end_IL_02f8;
							}
							continue;
							end_IL_02f8:
							break;
						}
					}
				}
				catch
				{
					Logger.LogError("Xbox One platform could not be initialized! Is the Rewired Xbox One library installed? See the documentation for more information.");
					MDVmwweEvHoLmOhNxpYDWbEeYJl = null;
				}
			}
			else if (UnityTools.platform == Platform.PS4 && !isEditor)
			{
				try
				{
					PS4InputSource customInputSource2 = new PS4InputSource();
					while (true)
					{
						IL_035b:
						int num6 = 951806109;
						while (true)
						{
							switch (num6 ^ 0x38BB689E)
							{
							case 2:
								break;
							default:
								goto end_IL_0360;
							case 3:
								goto IL_037d;
							case 0:
								if (MDVmwweEvHoLmOhNxpYDWbEeYJl == null)
								{
									throw new Exception();
								}
								goto end_IL_0360;
							case 1:
								goto end_IL_0360;
							}
							goto IL_035b;
							IL_037d:
							MDVmwweEvHoLmOhNxpYDWbEeYJl = new CustomInputManager(customInputSource2, EVFWZcZYsJTyVuPgkpnexuXAMzA.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
							num6 = 951806110;
							continue;
							end_IL_0360:
							break;
						}
						break;
					}
				}
				catch
				{
					Logger.LogError("PS4 platform could not be initialized!");
					MDVmwweEvHoLmOhNxpYDWbEeYJl = null;
				}
			}
			else if (UnityTools.platform == Platform.Ouya && !isEditor)
			{
				try
				{
					Type typeInUnityBuildAssembly = ReflectionTools.GetTypeInUnityBuildAssembly("OuyaSDK", true);
					if ((object)typeInUnityBuildAssembly == null)
					{
						Logger.LogError("OuyaEverywhereSDK was not found! Input may not function. See the documentation for building to the Ouya platform.");
						throw new Exception();
					}
					while (true)
					{
						IL_0441:
						typeInUnityBuildAssembly = ReflectionTools.GetTypeInUnityBuildAssembly("Rewired.Platforms.Ouya.OuyaInputSource", true);
						if ((object)typeInUnityBuildAssembly == null)
						{
							Logger.LogError("Required files for Ouya support are missing. Input may not function. Please completely reinstall Rewired.");
							int num7 = 951806110;
							while (true)
							{
								switch (num7 ^ 0x38BB689E)
								{
								case 2:
									num7 = 951806111;
									continue;
								case 1:
									goto IL_0441;
								case 3:
									goto IL_0463;
								case 0:
									throw new Exception();
								case 4:
									break;
								}
								break;
							}
							break;
						}
						goto IL_0463;
						IL_0463:
						CustomInputSource customInputSource3 = (CustomInputSource)Assembly.GetAssembly(typeInUnityBuildAssembly).CreateInstance(typeInUnityBuildAssembly.FullName, false);
						MDVmwweEvHoLmOhNxpYDWbEeYJl = new CustomInputManager(customInputSource3, EVFWZcZYsJTyVuPgkpnexuXAMzA.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
						if (MDVmwweEvHoLmOhNxpYDWbEeYJl == null)
						{
							throw new Exception();
						}
						break;
					}
				}
				catch
				{
					Logger.LogError("Ouya platform could not be initialized! Please see the documentation for required dependencies. Rewired will fall back to Unity input. All features may not be available.");
					MDVmwweEvHoLmOhNxpYDWbEeYJl = null;
				}
			}
			goto IL_04e8;
			IL_0102:
			if (configVars.DoesPlatformUseSDL2(UnityTools.platform, UnityTools.webplayerPlatform, isEditor))
			{
				try
				{
					MDVmwweEvHoLmOhNxpYDWbEeYJl = new aGsWVmtUFyuDlOkxcPJGtOTFmBv(EVFWZcZYsJTyVuPgkpnexuXAMzA, GetHardwareJoystickMap_InputManager, GetNewJoystickId, true, false, false);
					while (true)
					{
						IL_014a:
						int num8 = 951806109;
						while (true)
						{
							switch (num8 ^ 0x38BB689E)
							{
							case 0:
								break;
							default:
								goto end_IL_014f;
							case 3:
							{
								int num9;
								if (MDVmwweEvHoLmOhNxpYDWbEeYJl != null)
								{
									num8 = 951806111;
									num9 = num8;
								}
								else
								{
									num8 = 951806108;
									num9 = num8;
								}
								continue;
							}
							case 2:
								throw new Exception();
							case 1:
								goto end_IL_014f;
							}
							goto IL_014a;
							continue;
							end_IL_014f:
							break;
						}
						break;
					}
				}
				catch
				{
					Logger.LogError("SDL2 could not be initialized! Make sure you have the SDL2 library installed. Please see the documentation for more information. Rewired will fall back to Unity input. Certain features may not be available.");
					MDVmwweEvHoLmOhNxpYDWbEeYJl = null;
				}
				goto IL_04e8;
			}
			if (UnityTools.platform != Platform.Windows)
			{
				goto IL_01b4;
			}
			goto IL_0218;
			IL_01b4:
			num5 = 951806108;
			goto IL_01b9;
			IL_01b9:
			while (true)
			{
				switch (num5 ^ 0x38BB689E)
				{
				case 0:
					break;
				case 2:
					goto IL_01da;
				case 3:
					goto IL_0218;
				default:
					goto IL_0234;
				case 4:
					goto IL_04e8;
				}
				break;
				IL_01da:
				if (UnityTools.platform != Platform.WindowsAppStore && UnityTools.platform != Platform.WindowsUWP && UnityTools.platform != Platform.OSX)
				{
					int num10;
					if (UnityTools.platform == Platform.Linux)
					{
						num5 = 951806109;
						num10 = num5;
					}
					else
					{
						num5 = 951806111;
						num10 = num5;
					}
					continue;
				}
				goto IL_0218;
			}
			goto IL_01b4;
		}

		private static void cjeGqndlCVJCPoJRsFlYDpDShHb()
		{
			if (NuJlATmYOMdWXRRTuCaVCBLtlrF != EVFWZcZYsJTyVuPgkpnexuXAMzA.GetPlatformVar_ignoreInputWhenAppNotInFocus())
			{
				NuJlATmYOMdWXRRTuCaVCBLtlrF = !NuJlATmYOMdWXRRTuCaVCBLtlrF;
			}
		}

		private static void zyYmEeFbGvaSZdiSxOjchwoNioe()
		{
			if (UnityTools.unityVersionObj == null)
			{
				return;
			}
			while (true)
			{
				object[] array = new object[7];
				int num = 895663555;
				while (true)
				{
					switch (num ^ 0x3562BDC2)
					{
					case 0:
						num = 895663553;
						continue;
					case 3:
						break;
					case 1:
						array[0] = "The version of Rewired installed (";
						array[1] = programVersion;
						num = 895663552;
						continue;
					default:
						array[2] = ") was not designed for Unity ";
						array[3] = UnityTools.unityVersionObj.major;
						array[4] = ". Please install Rewired for Unity ";
						array[5] = UnityTools.unityVersionObj.major;
						array[6] = ".\n\nThis warning does not mean that Rewired will not function, but it may not function optimally.\n\nSome different major versions of Unity download Asset Store assets to the same folder location on disk, so if you download an asset in one version of the Unity editor, then open another version of the Unity editor and install the asset without re-downloading it, the wrong asset version will be installed. To fix this, manually re-download Rewired in the Unity Asset Store panel in this version of the Unity Editor, then install it.\n\nIf you are using a beta version of a new major version of Unity, you will have to wait until the release of the final version before a compatible version of Rewired can be uploaded to the Asset Store. When the new version is ready, it will be available through the Unity Asset Store for download as usual.";
						Logger.LogWarning(string.Concat(array));
						return;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private static void xViluIsdmRbyXfNcACpWftHcgjgq(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
		}

		[CompilerGenerated]
		private static void OJcuoTtsMGCaGGGbsVGrINzLOme(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
		}

		[CompilerGenerated]
		private static void pBqBITAhpBwdVJISwNINqzDRsxt(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
		}

		[CompilerGenerated]
		private static void EewEJaSHJXvAOVQmwezXDraiNPP(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
		}

		[CompilerGenerated]
		private static void epWRccssGKaKviRbvEccCIpKzPgh(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
		}

		[CompilerGenerated]
		private static void nQYEalfyCAeNFppAPSuukhejHfz(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
		}

		[CompilerGenerated]
		private static void pZTEauKZRcsCKTiyxVhTPRuFWIv(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
		}

		[CompilerGenerated]
		private static void zCTCQXCCecGSxkVylAwJJgsQMTUN(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
		}

		[CompilerGenerated]
		private static void jOjWFTJbUQstHgoRJjRNkHtKuxa(Exception P_0)
		{
			HandleCallbackException("", P_0);
		}

		[CompilerGenerated]
		private static bool RfQeiQjmHCFzgZKHyBiuHbaAXbRe()
		{
			if (isUnityEditorFocused)
			{
				return isAllowedEditorWindowFocused;
			}
			return false;
		}
	}
}
