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
			private static ConfigHelper muFkkiEUnsHdAMTJRFCFrPnztKW;

			internal static ConfigHelper Instance
			{
				get
				{
					return muFkkiEUnsHdAMTJRFCFrPnztKW ?? (muFkkiEUnsHdAMTJRFCFrPnztKW = new ConfigHelper());
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
					if (UnityTools.platform == Platform.Windows && HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						return true;
					}
					if (UnityTools.platform == Platform.WindowsUWP)
					{
						return (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useGamepadAPI;
					}
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.useXInput;
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
						IL_00c5:
						int num;
						if (UnityTools.platform == Platform.WindowsUWP)
						{
							platformVars_WindowsUWP = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
							int num2;
							if (platformVars_WindowsUWP.useGamepadAPI != value)
							{
								num = -636835163;
								num2 = num;
							}
							else
							{
								num = -636835153;
								num2 = num;
							}
							goto IL_0010;
						}
						goto IL_008f;
						IL_008f:
						if (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.useXInput == value)
						{
							break;
						}
						goto IL_0159;
						IL_0159:
						HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.useXInput = value;
						int num3;
						if (!value)
						{
							num = -636835154;
							num3 = num;
						}
						else
						{
							num = -636835158;
							num3 = num;
						}
						goto IL_0010;
						IL_0010:
						while (true)
						{
							switch (num ^ -636835155)
							{
							case 0:
								num = -636835164;
								continue;
							default:
								return;
							case 1:
								if (slVUsRChRjTDGWipWiBmxpDDiza != null)
								{
									slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
									num = -636835160;
									continue;
								}
								return;
							case 7:
								if (slVUsRChRjTDGWipWiBmxpDDiza != null)
								{
									slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
									num = -636835157;
									continue;
								}
								return;
							case 10:
								break;
							case 11:
								return;
							case 5:
								return;
							case 9:
								goto IL_00c5;
							case 3:
								if (UnityTools.platform == Platform.Windows && HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
								{
									windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
									Logger.Log("The primary input source has been changed to Raw Input.");
									num = -636835162;
									continue;
								}
								goto case 7;
							case 2:
								return;
							case 8:
								platformVars_WindowsUWP.useGamepadAPI = value;
								num = -636835156;
								continue;
							case 4:
								goto IL_0159;
							case 6:
								return;
							}
							break;
						}
						goto IL_008f;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.updateLoop;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (value != HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.updateLoop)
					{
						while (true)
						{
							IL_007a:
							int num;
							int num2;
							if ((value & UpdateLoopSetting.Update) != UpdateLoopSetting.None)
							{
								num = -134842363;
								num2 = num;
							}
							else
							{
								num = -134842368;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ -134842362)
								{
								case 2:
									num = -134842361;
									continue;
								default:
									return;
								case 1:
									break;
								case 5:
									if (slVUsRChRjTDGWipWiBmxpDDiza != null)
									{
										slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
										num = -134842366;
										continue;
									}
									return;
								case 6:
									value |= UpdateLoopSetting.Update;
									num = -134842363;
									continue;
								case 0:
									goto IL_007a;
								case 3:
									HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.updateLoop = value;
									num = -134842365;
									continue;
								case 4:
									return;
								}
								break;
							}
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.windowsStandalonePrimaryInputSource;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_000a;
					}
					goto IL_00c3;
					IL_000a:
					int num = -612498605;
					goto IL_000f;
					IL_000f:
					while (true)
					{
						switch (num ^ -612498607)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							return;
						case 1:
							goto IL_0047;
						case 5:
							goto IL_0074;
						case 7:
							HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.useXInput = true;
							num = -612498604;
							continue;
						case 3:
							slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
							num = -612498603;
							continue;
						case 6:
							goto IL_00c3;
						case 4:
							return;
						}
						break;
					}
					goto IL_000a;
					IL_0074:
					int num2;
					if (slVUsRChRjTDGWipWiBmxpDDiza != null)
					{
						num = -612498606;
						num2 = num;
					}
					else
					{
						num = -612498603;
						num2 = num;
					}
					goto IL_000f;
					IL_00c3:
					if (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.windowsStandalonePrimaryInputSource == value)
					{
						return;
					}
					goto IL_0047;
					IL_0047:
					HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.windowsStandalonePrimaryInputSource = value;
					if (UnityTools.platform == Platform.Windows)
					{
						int num3;
						if (value != WindowsStandalonePrimaryInputSource.XInput)
						{
							num = -612498604;
							num3 = num;
						}
						else
						{
							num = -612498602;
							num3 = num;
						}
						goto IL_000f;
					}
					goto IL_0074;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.osx_primaryInputSource;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.osx_primaryInputSource != value)
					{
						while (true)
						{
							IL_0044:
							HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.osx_primaryInputSource = value;
							if (!(slVUsRChRjTDGWipWiBmxpDDiza != null))
							{
								return;
							}
							slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
							int num = -413550970;
							while (true)
							{
								switch (num ^ -413550971)
								{
								case 0:
									num = -413550969;
									continue;
								default:
									return;
								case 2:
									break;
								case 1:
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

			public LinuxStandalonePrimaryInputSource linuxStandalonePrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return LinuxStandalonePrimaryInputSource.Native;
					}
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.linux_primaryInputSource;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.linux_primaryInputSource != value)
					{
						while (true)
						{
							IL_0044:
							HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.linux_primaryInputSource = value;
							if (!(slVUsRChRjTDGWipWiBmxpDDiza != null))
							{
								return;
							}
							slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
							int num = 2041479589;
							while (true)
							{
								switch (num ^ 0x79AE81A5)
								{
								case 2:
									num = 2041479588;
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

			public WindowsUWPPrimaryInputSource windowsUWPPrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return WindowsUWPPrimaryInputSource.Native;
					}
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.windowsUWP_primaryInputSource;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.windowsUWP_primaryInputSource != value)
					{
						while (true)
						{
							HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.windowsUWP_primaryInputSource = value;
							int num = 2116554506;
							while (true)
							{
								switch (num ^ 0x7E280F0E)
								{
								case 0:
									num = 2116554507;
									continue;
								default:
									return;
								case 3:
									slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
									num = 2116554511;
									continue;
								case 2:
									break;
								case 4:
									goto IL_005a;
								case 5:
									goto end_IL_0043;
								case 1:
									return;
								}
								break;
								IL_005a:
								int num2;
								if (!(slVUsRChRjTDGWipWiBmxpDDiza != null))
								{
									num = 2116554511;
									num2 = num;
								}
								else
								{
									num = 2116554509;
									num2 = num;
								}
							}
							continue;
							end_IL_0043:
							break;
						}
					}
				}
			}

			public bool windowsUWPSupportHIDDevices
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					return platformVars_WindowsUWP.useHIDAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (true)
					{
						ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
						int num;
						int num2;
						if (platformVars_WindowsUWP.useHIDAPI == value)
						{
							num = -1920315440;
							num2 = num;
						}
						else
						{
							num = -1920315438;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -1920315439)
							{
							case 0:
								num = -1920315435;
								continue;
							default:
								return;
							case 4:
								break;
							case 3:
								platformVars_WindowsUWP.useHIDAPI = value;
								if (slVUsRChRjTDGWipWiBmxpDDiza != null)
								{
									slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
									num = -1920315437;
									continue;
								}
								return;
							case 1:
								return;
							case 2:
								return;
							}
							break;
						}
					}
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.xboxOne_primaryInputSource;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.xboxOne_primaryInputSource != value)
					{
						while (true)
						{
							IL_004c:
							HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.xboxOne_primaryInputSource = value;
							int num = -1210393688;
							while (true)
							{
								switch (num ^ -1210393683)
								{
								case 0:
									num = -1210393682;
									continue;
								default:
									return;
								case 3:
									break;
								case 2:
									goto IL_004c;
								case 4:
									slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
									num = -1210393684;
									continue;
								case 5:
									goto IL_0074;
								case 1:
									return;
								}
								break;
								IL_0074:
								int num2;
								if (slVUsRChRjTDGWipWiBmxpDDiza != null)
								{
									num = -1210393687;
									num2 = num;
								}
								else
								{
									num = -1210393684;
									num2 = num;
								}
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.ps4_primaryInputSource;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_0035;
					IL_0007:
					int num = 835057362;
					goto IL_000c;
					IL_000c:
					switch (num ^ 0x31C5F6D1)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						return;
					case 4:
						goto IL_0035;
					case 1:
						goto IL_004f;
					case 0:
						return;
					}
					goto IL_0007;
					IL_0035:
					if (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.ps4_primaryInputSource == value)
					{
						return;
					}
					goto IL_004f;
					IL_004f:
					HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.ps4_primaryInputSource = value;
					if (slVUsRChRjTDGWipWiBmxpDDiza != null)
					{
						slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
						num = 835057361;
						goto IL_000c;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.webGL_primaryInputSource;
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
						if (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.webGL_primaryInputSource == value)
						{
							num = 1251748078;
							num2 = num;
						}
						else
						{
							num = 1251748077;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x4A9C28EE)
							{
							case 2:
								num = 1251748074;
								continue;
							default:
								return;
							case 3:
								HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.webGL_primaryInputSource = value;
								num = 1251748075;
								continue;
							case 0:
								return;
							case 1:
								slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
								num = 1251748072;
								continue;
							case 5:
							{
								int num3;
								if (!(slVUsRChRjTDGWipWiBmxpDDiza != null))
								{
									num = 1251748072;
									num3 = num;
								}
								else
								{
									num = 1251748079;
									num3 = num;
								}
								continue;
							}
							case 4:
								break;
							case 6:
								return;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.alwaysUseUnityInput;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.alwaysUseUnityInput != value)
					{
						while (true)
						{
							IL_0044:
							HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.alwaysUseUnityInput = value;
							if (!(slVUsRChRjTDGWipWiBmxpDDiza != null))
							{
								return;
							}
							slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
							int num = -2099057219;
							while (true)
							{
								switch (num ^ -2099057220)
								{
								case 2:
									num = -2099057217;
									continue;
								default:
									return;
								case 3:
									break;
								case 0:
									goto IL_0044;
								case 1:
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.GetPlatformVar_useNativeMouse();
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_0074;
					IL_0007:
					int num = -1053297366;
					goto IL_000c;
					IL_000c:
					while (true)
					{
						switch (num ^ -1053297365)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							return;
						case 0:
							slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
							num = -1053297368;
							continue;
						case 5:
							goto IL_004e;
						case 4:
							return;
						case 6:
							goto IL_0074;
						case 3:
							return;
						}
						break;
						IL_004e:
						int num2;
						if (!(slVUsRChRjTDGWipWiBmxpDDiza != null))
						{
							num = -1053297368;
							num2 = num;
						}
						else
						{
							num = -1053297365;
							num2 = num;
						}
					}
					goto IL_0007;
					IL_0074:
					int num3;
					if (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.SetPlatformVar_useNativeMouse(value))
					{
						num = -1053297362;
						num3 = num;
					}
					else
					{
						num = -1053297361;
						num3 = num;
					}
					goto IL_000c;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.GetPlatformVar_useNativeKeyboard();
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_0053;
					IL_0007:
					int num = -1880000858;
					goto IL_000c;
					IL_000c:
					switch (num ^ -1880000857)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						return;
					case 3:
						goto IL_0035;
					case 2:
						goto IL_0053;
					case 4:
						return;
					}
					goto IL_0007;
					IL_0053:
					if (!HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.SetPlatformVar_useNativeKeyboard(value))
					{
						return;
					}
					goto IL_0035;
					IL_0035:
					if (slVUsRChRjTDGWipWiBmxpDDiza != null)
					{
						slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
						num = -1880000861;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.GetPlatformVar_useEnhancedDeviceSupport();
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_0035;
					IL_0007:
					int num = 1666424735;
					goto IL_000c;
					IL_000c:
					switch (num ^ 0x63539F9B)
					{
					case 3:
						break;
					default:
						return;
					case 4:
						return;
					case 0:
						goto IL_0035;
					case 2:
						goto IL_004f;
					case 1:
						return;
					}
					goto IL_0007;
					IL_0035:
					if (!HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.SetPlatformVar_useEnhancedDeviceSupport(value))
					{
						return;
					}
					goto IL_004f;
					IL_004f:
					if (slVUsRChRjTDGWipWiBmxpDDiza != null)
					{
						slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
						num = 1666424730;
						goto IL_000c;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.GetPlatformVar_joystickRefreshRate();
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_0045;
					IL_0007:
					int num = 1582616018;
					goto IL_000c;
					IL_000c:
					while (true)
					{
						switch (num ^ 0x5E54CDD6)
						{
						case 5:
							break;
						case 2:
							goto IL_0031;
						case 0:
							goto IL_0045;
						case 4:
							return;
						case 1:
							value = 240;
							num = 1582616021;
							continue;
						default:
							HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.SetPlatformVar_joystickRefreshRate(value);
							return;
						}
						break;
						IL_0031:
						int num2;
						if (value != 0)
						{
							num = 1582616021;
							num2 = num;
						}
						else
						{
							num = 1582616023;
							num2 = num;
						}
					}
					goto IL_0007;
					IL_0045:
					value = MathTools.Clamp(value, 0, 2000);
					num = 1582616020;
					goto IL_000c;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.GetPlatformVar_ignoreInputWhenAppNotInFocus();
				}
				set
				{
					if (!CheckInitialized())
					{
						while (true)
						{
							switch (-1033722796 ^ -1033722793)
							{
							case 0:
								break;
							case 3:
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
					if (!HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.SetPlatformVar_ignoreInputWhenAppNotInFocus(value))
					{
						return;
					}
					goto IL_004b;
					IL_004b:
					RlfZIISmAMxUwhwhvGFGXAlZCwn();
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.android_supportUnknownGamepads;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.android_supportUnknownGamepads != value)
					{
						while (true)
						{
							IL_0044:
							HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.android_supportUnknownGamepads = value;
							if (!(slVUsRChRjTDGWipWiBmxpDDiza != null))
							{
								return;
							}
							slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
							int num = -733679964;
							while (true)
							{
								switch (num ^ -733679963)
								{
								case 2:
									num = -733679962;
									continue;
								default:
									return;
								case 3:
									break;
								case 0:
									goto IL_0044;
								case 1:
									return;
								}
								break;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.defaultJoystickAxis2DDeadZoneType;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_004c;
					IL_0007:
					int num = -2083320756;
					goto IL_000c;
					IL_000c:
					switch (num ^ -2083320754)
					{
					case 3:
						break;
					default:
						return;
					case 2:
						return;
					case 0:
						goto IL_0035;
					case 4:
						goto IL_004c;
					case 1:
						return;
					}
					goto IL_0007;
					IL_004c:
					if (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.defaultJoystickAxis2DDeadZoneType == value)
					{
						return;
					}
					goto IL_0035;
					IL_0035:
					HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.defaultJoystickAxis2DDeadZoneType = value;
					num = -2083320753;
					goto IL_000c;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.defaultJoystickAxis2DSensitivityType;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_0035;
					IL_0007:
					int num = 1372211670;
					goto IL_000c;
					IL_000c:
					switch (num ^ 0x51CA49D7)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						return;
					case 0:
						goto IL_0035;
					case 2:
						goto IL_004f;
					case 4:
						return;
					}
					goto IL_0007;
					IL_0035:
					if (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.defaultJoystickAxis2DSensitivityType == value)
					{
						return;
					}
					goto IL_004f;
					IL_004f:
					HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.defaultJoystickAxis2DSensitivityType = value;
					num = 1372211667;
					goto IL_000c;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.defaultAxisSensitivityType;
				}
				set
				{
					if (CheckInitialized() && HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.defaultAxisSensitivityType != value)
					{
						HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.defaultAxisSensitivityType = value;
					}
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.force4WayHats;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_0044;
					IL_0007:
					int num = 598764689;
					goto IL_000c;
					IL_000c:
					switch (num ^ 0x23B06C92)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_002d;
					case 1:
						goto IL_0044;
					case 3:
						return;
					case 4:
						return;
					}
					goto IL_0007;
					IL_0044:
					if (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.force4WayHats == value)
					{
						return;
					}
					goto IL_002d;
					IL_002d:
					HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.force4WayHats = value;
					num = 598764694;
					goto IL_000c;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.activateActionButtonsOnNegativeValue;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_0035;
					IL_0007:
					int num = 1481704445;
					goto IL_000c;
					IL_000c:
					switch (num ^ 0x585103FC)
					{
					case 2:
						break;
					case 0:
						return;
					case 4:
						goto IL_0035;
					case 1:
						return;
					default:
						HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.activateActionButtonsOnNegativeValue = value;
						return;
					}
					goto IL_0007;
					IL_0035:
					int num2;
					if (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.activateActionButtonsOnNegativeValue == value)
					{
						num = 1481704444;
						num2 = num;
					}
					else
					{
						num = 1481704447;
						num2 = num;
					}
					goto IL_000c;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.throttleCalibrationMode;
				}
				set
				{
					if (CheckInitialized() && HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.throttleCalibrationMode != value)
					{
						HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.throttleCalibrationMode = value;
						uzYFVAOPCugnffcKSwcZmFfGUjB.YFYDYKXXYWFTpDjquQJNbFcgFXjF(value);
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.deferControllerConnectedEventsOnStart;
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
						if (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.deferControllerConnectedEventsOnStart == value)
						{
							num = -494697997;
							num2 = num;
						}
						else
						{
							num = -494698000;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -494697997)
							{
							case 2:
								goto IL_0008;
							case 1:
								break;
							case 0:
								return;
							default:
								HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.deferControllerConnectedEventsOnStart = value;
								return;
							}
							break;
							IL_0008:
							num = -494697998;
						}
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.autoAssignJoysticks;
				}
				set
				{
					if (!CheckInitialized())
					{
						while (true)
						{
							switch (0x1F41E53A ^ 0x1F41E53B)
							{
							case 2:
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
					if (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.autoAssignJoysticks == value)
					{
						return;
					}
					goto IL_004b;
					IL_004b:
					HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.autoAssignJoysticks = value;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.maxJoysticksPerPlayer;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (true)
					{
						if (value < 1)
						{
							value = 1;
							int num = 1524829623;
							while (true)
							{
								switch (num ^ 0x5AE30DB4)
								{
								case 2:
									num = 1524829621;
									continue;
								case 1:
									break;
								case 3:
									goto IL_0038;
								default:
									goto end_IL_002a;
								}
								break;
							}
							continue;
						}
						goto IL_0038;
						IL_0038:
						if (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.maxJoysticksPerPlayer != value)
						{
							break;
						}
						return;
						continue;
						end_IL_002a:
						break;
					}
					HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.maxJoysticksPerPlayer = value;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.distributeJoysticksEvenly;
				}
				set
				{
					if (!CheckInitialized())
					{
						while (true)
						{
							switch (0x5D9625EE ^ 0x5D9625ED)
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
					if (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.distributeJoysticksEvenly == value)
					{
						return;
					}
					goto IL_004b;
					IL_004b:
					HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.distributeJoysticksEvenly = value;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.assignJoysticksToPlayingPlayersOnly;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_003d;
					IL_0007:
					int num = 1168875271;
					goto IL_000c;
					IL_000c:
					switch (num ^ 0x45AB9F05)
					{
					case 3:
						break;
					case 2:
						return;
					case 0:
						return;
					case 4:
						goto IL_003d;
					default:
						HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.assignJoysticksToPlayingPlayersOnly = value;
						return;
					}
					goto IL_0007;
					IL_003d:
					int num2;
					if (HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.assignJoysticksToPlayingPlayersOnly != value)
					{
						num = 1168875268;
						num2 = num;
					}
					else
					{
						num = 1168875269;
						num2 = num;
					}
					goto IL_000c;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect;
				}
				set
				{
					if (CheckInitialized() && HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect != value)
					{
						HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect = value;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.logLevel;
				}
				set
				{
					if (CheckInitialized() && HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.logLevel != value)
					{
						HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ConfigVars.logLevel = value;
					}
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
				private sealed class OXuOkiAnBTaesdGBRnPvqvCsblOk : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public PollingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public ControllerPollingInfo iCjLMgchlpGhIFGZNwqQqjBkHxVp;

					public ControllerPollingInfo BChezBcyRPGTUtelzeLVHPJtpqSd;

					public ControllerPollingInfo ElcaSmRItyoxUlgVgTLJqzRiQyy;

					public ControllerPollingInfo ktBbfrKtdvqXCmYOhfxVKerfMOe;

					public IEnumerator<ControllerPollingInfo> vvkHNZLrzWgAFunANOQiXmXHOMC;

					public IEnumerator<ControllerPollingInfo> opYJSkzDmVDdHOwvQdCTBFDyrAK;

					public IEnumerator<ControllerPollingInfo> AQDmxYRBsDsxIecrOswZMmpJfpq;

					public IEnumerator<ControllerPollingInfo> zrJPvwMWzCSpjOMhnUgFTKmnqoq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							goto IL_001c;
						}
						goto IL_0042;
						IL_0042:
						OXuOkiAnBTaesdGBRnPvqvCsblOk oXuOkiAnBTaesdGBRnPvqvCsblOk = new OXuOkiAnBTaesdGBRnPvqvCsblOk(0);
						oXuOkiAnBTaesdGBRnPvqvCsblOk.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						int num = 1093774695;
						goto IL_0021;
						IL_001c:
						num = 1093774692;
						goto IL_0021;
						IL_0021:
						while (true)
						{
							switch (num ^ 0x4131AD65)
							{
							case 4:
								break;
							case 0:
								goto IL_0042;
							case 3:
								oXuOkiAnBTaesdGBRnPvqvCsblOk = this;
								num = 1093774695;
								continue;
							case 1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
								num = 1093774694;
								continue;
							default:
								return oXuOkiAnBTaesdGBRnPvqvCsblOk;
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
							int num3;
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							default:
								num = -380546722;
								goto IL_0036;
							case 6:
								goto IL_00b6;
							case 0:
								goto IL_00c7;
							case 4:
								goto IL_0151;
							case 1:
							case 3:
							case 5:
							case 7:
								goto IL_02e6;
							case 8:
								goto IL_02f2;
							case 2:
								goto IL_035b;
								IL_0036:
								while (true)
								{
									switch (num ^ -380546730)
									{
									case 23:
										break;
									default:
										goto end_IL_0008;
									case 20:
										goto IL_00b6;
									case 15:
										goto IL_00c7;
									case 21:
										if (!zrJPvwMWzCSpjOMhnUgFTKmnqoq.MoveNext())
										{
											kkQbKYjIoDuYkOihDTKnxNTJjHH();
											num = -380546752;
											continue;
										}
										goto case 18;
									case 10:
										goto end_IL_0008;
									case 17:
										SWngIdtCyepajoBilkihcWnskST();
										zrJPvwMWzCSpjOMhnUgFTKmnqoq = iKQXbXnVtIaMZEJNeigQJWAHqUx.vjWAnwjBmeLcpsBmrJoPchmdKSpU().GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 7;
										num = -380546723;
										continue;
									case 24:
										result = true;
										num = -380546724;
										continue;
									case 1:
										goto IL_0151;
									case 12:
										aimBzjfQfPyaeQqysAQJISCBhELB = ktBbfrKtdvqXCmYOhfxVKerfMOe;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 8;
										result = true;
										goto end_IL_0008;
									case 18:
										ktBbfrKtdvqXCmYOhfxVKerfMOe = zrJPvwMWzCSpjOMhnUgFTKmnqoq.Current;
										num = -380546726;
										continue;
									case 6:
										goto IL_01a1;
									case 13:
										BChezBcyRPGTUtelzeLVHPJtpqSd = opYJSkzDmVDdHOwvQdCTBFDyrAK.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = BChezBcyRPGTUtelzeLVHPJtpqSd;
										num = -380546740;
										continue;
									case 9:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num = -380546746;
										continue;
									case 8:
										num = -380546752;
										continue;
									case 5:
										aimBzjfQfPyaeQqysAQJISCBhELB = ElcaSmRItyoxUlgVgTLJqzRiQyy;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 6;
										result = true;
										goto end_IL_0008;
									case 2:
										vvkHNZLrzWgAFunANOQiXmXHOMC = iKQXbXnVtIaMZEJNeigQJWAHqUx.QiuNTzxjhuhvqaMniCWInBWwcLht().GetEnumerator();
										num = -380546721;
										continue;
									case 0:
										ElcaSmRItyoxUlgVgTLJqzRiQyy = AQDmxYRBsDsxIecrOswZMmpJfpq.Current;
										num = -380546733;
										continue;
									case 26:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 4;
										num = -380546738;
										continue;
									case 14:
										num = -380546736;
										continue;
									case 7:
										iCjLMgchlpGhIFGZNwqQqjBkHxVp = vvkHNZLrzWgAFunANOQiXmXHOMC.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = iCjLMgchlpGhIFGZNwqQqjBkHxVp;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										result = true;
										goto end_IL_0008;
									case 16:
										if (!vvkHNZLrzWgAFunANOQiXmXHOMC.MoveNext())
										{
											dUTcxjRxXhdwZtgkiBXOMfzWPhY();
											opYJSkzDmVDdHOwvQdCTBFDyrAK = iKQXbXnVtIaMZEJNeigQJWAHqUx.gByFpjsgRfdXoflOsFeeGcqfNoUh().GetEnumerator();
											num = -380546734;
											continue;
										}
										goto case 7;
									case 22:
										goto IL_02e6;
									case 19:
										goto IL_02f2;
									case 11:
										num = -380546749;
										continue;
									case 4:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
										num = -380546731;
										continue;
									case 3:
										if (!opYJSkzDmVDdHOwvQdCTBFDyrAK.MoveNext())
										{
											ETJEOMSxQMaxVTEHxkaMPZgvgeC();
											AQDmxYRBsDsxIecrOswZMmpJfpq = iKQXbXnVtIaMZEJNeigQJWAHqUx.DInIwIoQIJWoIKfqGeXahEyojLRc().GetEnumerator();
											oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 5;
											num = -380546728;
											continue;
										}
										goto case 13;
									case 27:
										goto IL_035b;
									case 25:
										goto end_IL_0008;
									}
									break;
									IL_01a1:
									int num2;
									if (AQDmxYRBsDsxIecrOswZMmpJfpq.MoveNext())
									{
										num = -380546730;
										num2 = num;
									}
									else
									{
										num = -380546745;
										num2 = num;
									}
								}
								goto default;
								IL_035b:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = -380546746;
								goto IL_0036;
								IL_02f2:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 7;
								num = -380546749;
								goto IL_0036;
								IL_02e6:
								result = false;
								num = -380546737;
								goto IL_0036;
								IL_0151:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
								num = -380546731;
								goto IL_0036;
								IL_00c7:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								if (CheckInitialized())
								{
									num = -380546732;
									num3 = num;
								}
								else
								{
									num = -380546752;
									num3 = num;
								}
								goto IL_0036;
								IL_00b6:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 5;
								num = -380546736;
								goto IL_0036;
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
						int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
						while (true)
						{
							int num2 = 119881136;
							while (true)
							{
								switch (num2 ^ 0x7253DB2)
								{
								case 0:
									break;
								case 2:
									switch (num)
									{
									default:
										goto IL_0035;
									case 1:
									case 2:
										break;
									}
									try
									{
									}
									finally
									{
										dUTcxjRxXhdwZtgkiBXOMfzWPhY();
									}
									goto default;
								default:
									switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
									{
									case 3:
									case 4:
										try
										{
										}
										finally
										{
											ETJEOMSxQMaxVTEHxkaMPZgvgeC();
										}
										break;
									}
									switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
									{
									case 5:
									case 6:
										try
										{
										}
										finally
										{
											SWngIdtCyepajoBilkihcWnskST();
										}
										break;
									}
									switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
									{
									case 7:
									case 8:
										try
										{
											break;
										}
										finally
										{
											kkQbKYjIoDuYkOihDTKnxNTJjHH();
										}
									}
									return;
								}
								break;
								IL_0035:
								num2 = 119881139;
							}
						}
					}

					[DebuggerHidden]
					public OXuOkiAnBTaesdGBRnPvqvCsblOk(int _003C_003E1__state)
					{
						while (true)
						{
							int num = 698738220;
							while (true)
							{
								switch (num ^ 0x29A5E62D)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									goto IL_0024;
								case 2:
									return;
								}
								break;
								IL_0024:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
								HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
								num = 698738223;
							}
						}
					}

					private void dUTcxjRxXhdwZtgkiBXOMfzWPhY()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (vvkHNZLrzWgAFunANOQiXmXHOMC == null)
						{
							return;
						}
						while (true)
						{
							int num = -1734140809;
							while (true)
							{
								switch (num ^ -1734140810)
								{
								case 2:
									break;
								default:
									return;
								case 1:
									goto IL_002d;
								case 0:
									return;
								}
								break;
								IL_002d:
								vvkHNZLrzWgAFunANOQiXmXHOMC.Dispose();
								num = -1734140810;
							}
						}
					}

					private void ETJEOMSxQMaxVTEHxkaMPZgvgeC()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						while (true)
						{
							int num = 155961560;
							while (true)
							{
								switch (num ^ 0x94BC8D9)
								{
								case 0:
									break;
								default:
									return;
								case 1:
								{
									int num2;
									if (opYJSkzDmVDdHOwvQdCTBFDyrAK == null)
									{
										num = 155961562;
										num2 = num;
									}
									else
									{
										num = 155961563;
										num2 = num;
									}
									continue;
								}
								case 2:
									opYJSkzDmVDdHOwvQdCTBFDyrAK.Dispose();
									num = 155961562;
									continue;
								case 3:
									return;
								}
								break;
							}
						}
					}

					private void SWngIdtCyepajoBilkihcWnskST()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						while (true)
						{
							int num = 565906089;
							while (true)
							{
								switch (num ^ 0x21BB0AA8)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									if (AQDmxYRBsDsxIecrOswZMmpJfpq != null)
									{
										goto IL_002d;
									}
									return;
								case 2:
									return;
								}
								break;
								IL_002d:
								AQDmxYRBsDsxIecrOswZMmpJfpq.Dispose();
								num = 565906090;
							}
						}
					}

					private void kkQbKYjIoDuYkOihDTKnxNTJjHH()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						while (true)
						{
							int num = -1157035247;
							while (true)
							{
								switch (num ^ -1157035245)
								{
								case 0:
									break;
								default:
									return;
								case 2:
									if (zrJPvwMWzCSpjOMhnUgFTKmnqoq != null)
									{
										goto IL_002d;
									}
									return;
								case 1:
									return;
								}
								break;
								IL_002d:
								zrJPvwMWzCSpjOMhnUgFTKmnqoq.Dispose();
								num = -1157035246;
							}
						}
					}
				}

				private sealed class mmFLDyeGQypMzCWaSfNmdnKPNEy : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public PollingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public ControllerPollingInfo cOChdGnbxQdbtAvwBvvYkBHYmbfX;

					public ControllerPollingInfo lPPFtdEugyryTzXzufqlhJlMAgJ;

					public ControllerPollingInfo KSsSaBaGdVRItIzMcQTbfnoxEqK;

					public ControllerPollingInfo mbscZZYsXeIkFAtatjTgOtkOvgG;

					public IEnumerator<ControllerPollingInfo> kSdXqMObvsckcPpjDjALqYirNrd;

					public IEnumerator<ControllerPollingInfo> ZlEvmogtQqIgWvYiihQnyfLgCqD;

					public IEnumerator<ControllerPollingInfo> gOXDEJFRiopEFtrenfGxPdlYIvn;

					public IEnumerator<ControllerPollingInfo> NTxWYcPNRYFWcHfWEaBdjNHYveNL;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							goto IL_0023;
						}
						goto IL_004e;
						IL_0028:
						int num;
						mmFLDyeGQypMzCWaSfNmdnKPNEy mmFLDyeGQypMzCWaSfNmdnKPNEy2 = default(mmFLDyeGQypMzCWaSfNmdnKPNEy);
						while (true)
						{
							switch (num ^ -1156260997)
							{
							case 0:
								break;
							case 1:
								mmFLDyeGQypMzCWaSfNmdnKPNEy2 = this;
								num = -1156261000;
								continue;
							case 2:
								goto IL_004e;
							default:
								return mmFLDyeGQypMzCWaSfNmdnKPNEy2;
							}
							break;
						}
						goto IL_0023;
						IL_004e:
						mmFLDyeGQypMzCWaSfNmdnKPNEy2 = new mmFLDyeGQypMzCWaSfNmdnKPNEy(0);
						mmFLDyeGQypMzCWaSfNmdnKPNEy2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = -1156261000;
						goto IL_0028;
						IL_0023:
						num = -1156260998;
						goto IL_0028;
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
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							default:
								num = -1667465375;
								goto IL_0036;
							case 4:
								goto IL_00ff;
							case 2:
								goto IL_016b;
							case 0:
								goto IL_0210;
							case 8:
								goto IL_0286;
							case 6:
								goto IL_02f4;
							case 1:
							case 3:
							case 5:
							case 7:
								break;
								IL_0036:
								while (true)
								{
									switch (num ^ -1667465373)
									{
									case 7:
										break;
									case 5:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 5;
										num = -1667465363;
										continue;
									case 11:
										NTxWYcPNRYFWcHfWEaBdjNHYveNL = iKQXbXnVtIaMZEJNeigQJWAHqUx.LmllFxulnUiFQPIrObrWMiDbfgQ().GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 7;
										num = -1667465374;
										continue;
									case 18:
										aimBzjfQfPyaeQqysAQJISCBhELB = KSsSaBaGdVRItIzMcQTbfnoxEqK;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 6;
										return true;
									case 13:
										goto IL_00ff;
									case 8:
										KSsSaBaGdVRItIzMcQTbfnoxEqK = gOXDEJFRiopEFtrenfGxPdlYIvn.Current;
										num = -1667465359;
										continue;
									case 15:
										if (!ZlEvmogtQqIgWvYiihQnyfLgCqD.MoveNext())
										{
											oOCsBiXOEPKRfOqLmemmqKVZsip();
											gOXDEJFRiopEFtrenfGxPdlYIvn = iKQXbXnVtIaMZEJNeigQJWAHqUx.TUrfKiUifMozUtgDHYzvZgHvzIw().GetEnumerator();
											num = -1667465370;
											continue;
										}
										goto case 12;
									case 19:
										num = -1667465353;
										continue;
									case 17:
										goto IL_016b;
									case 2:
										num = -1667465356;
										continue;
									case 9:
										return true;
									case 20:
										if (!kSdXqMObvsckcPpjDjALqYirNrd.MoveNext())
										{
											dkPhleZRrRsyfMMEqMFHvClYHHF();
											ZlEvmogtQqIgWvYiihQnyfLgCqD = iKQXbXnVtIaMZEJNeigQJWAHqUx.QBcgdYdqwsLotCArKVfGzZsRCKD().GetEnumerator();
											oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
											num = -1667465364;
											continue;
										}
										goto case 21;
									case 22:
										return true;
									case 21:
										cOChdGnbxQdbtAvwBvvYkBHYmbfX = kSdXqMObvsckcPpjDjALqYirNrd.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = cOChdGnbxQdbtAvwBvvYkBHYmbfX;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										num = -1667465355;
										continue;
									case 10:
										goto IL_0210;
									case 4:
										FjLAfjykuVlRRFGOQaJecVQSJkf();
										num = -1667465356;
										continue;
									case 12:
										lPPFtdEugyryTzXzufqlhJlMAgJ = ZlEvmogtQqIgWvYiihQnyfLgCqD.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = lPPFtdEugyryTzXzufqlhJlMAgJ;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 4;
										num = -1667465366;
										continue;
									case 0:
										goto IL_0286;
									case 3:
										mbscZZYsXeIkFAtatjTgOtkOvgG = NTxWYcPNRYFWcHfWEaBdjNHYveNL.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = mbscZZYsXeIkFAtatjTgOtkOvgG;
										num = -1667465357;
										continue;
									case 16:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 8;
										return true;
									case 1:
										goto IL_02d3;
									case 6:
										goto IL_02f4;
									case 14:
										if (!gOXDEJFRiopEFtrenfGxPdlYIvn.MoveNext())
										{
											pRwrmNpfYlYeMxcLLLuQRlwaYxg();
											num = -1667465368;
											continue;
										}
										goto case 8;
									default:
										goto end_IL_0008;
									}
									break;
									IL_02d3:
									int num2;
									if (!NTxWYcPNRYFWcHfWEaBdjNHYveNL.MoveNext())
									{
										num = -1667465369;
										num2 = num;
									}
									else
									{
										num = -1667465376;
										num2 = num;
									}
								}
								goto default;
								IL_02f4:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 5;
								num = -1667465363;
								goto IL_0036;
								IL_0286:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 7;
								num = -1667465374;
								goto IL_0036;
								IL_0210:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								if (!CheckInitialized())
								{
									break;
								}
								kSdXqMObvsckcPpjDjALqYirNrd = iKQXbXnVtIaMZEJNeigQJWAHqUx.paBcAKuGzjbtMtreSufecodKDsz().GetEnumerator();
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = -1667465360;
								goto IL_0036;
								IL_00ff:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
								num = -1667465364;
								goto IL_0036;
								IL_016b:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = -1667465353;
								goto IL_0036;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								dkPhleZRrRsyfMMEqMFHvClYHHF();
							}
							break;
						}
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								oOCsBiXOEPKRfOqLmemmqKVZsip();
							}
							break;
						}
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 5:
						case 6:
							try
							{
							}
							finally
							{
								pRwrmNpfYlYeMxcLLLuQRlwaYxg();
							}
							break;
						}
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 7:
						case 8:
							try
							{
								break;
							}
							finally
							{
								FjLAfjykuVlRRFGOQaJecVQSJkf();
							}
						}
					}

					[DebuggerHidden]
					public mmFLDyeGQypMzCWaSfNmdnKPNEy(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void dkPhleZRrRsyfMMEqMFHvClYHHF()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (kSdXqMObvsckcPpjDjALqYirNrd != null)
						{
							kSdXqMObvsckcPpjDjALqYirNrd.Dispose();
						}
					}

					private void oOCsBiXOEPKRfOqLmemmqKVZsip()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (ZlEvmogtQqIgWvYiihQnyfLgCqD != null)
						{
							ZlEvmogtQqIgWvYiihQnyfLgCqD.Dispose();
						}
					}

					private void pRwrmNpfYlYeMxcLLLuQRlwaYxg()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						while (true)
						{
							int num = 407684193;
							while (true)
							{
								switch (num ^ 0x184CC462)
								{
								case 0:
									break;
								default:
									return;
								case 3:
								{
									int num2;
									if (gOXDEJFRiopEFtrenfGxPdlYIvn != null)
									{
										num = 407684195;
										num2 = num;
									}
									else
									{
										num = 407684192;
										num2 = num;
									}
									continue;
								}
								case 1:
									gOXDEJFRiopEFtrenfGxPdlYIvn.Dispose();
									num = 407684192;
									continue;
								case 2:
									return;
								}
								break;
							}
						}
					}

					private void FjLAfjykuVlRRFGOQaJecVQSJkf()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						while (true)
						{
							int num = 25041471;
							while (true)
							{
								switch (num ^ 0x17E1A3E)
								{
								case 2:
									break;
								default:
									return;
								case 1:
								{
									int num2;
									if (NTxWYcPNRYFWcHfWEaBdjNHYveNL != null)
									{
										num = 25041470;
										num2 = num;
									}
									else
									{
										num = 25041469;
										num2 = num;
									}
									continue;
								}
								case 0:
									NTxWYcPNRYFWcHfWEaBdjNHYveNL.Dispose();
									num = 25041469;
									continue;
								case 3:
									return;
								}
								break;
							}
						}
					}
				}

				private sealed class rRZvPhYTeMTousfytyIrYqJQFBFI : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public PollingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public ControllerPollingInfo QVAKbXXQJMtQGqfpHCPNdvQKqbHe;

					public ControllerPollingInfo dfyelpdGjHSTakKpHOilSnOOqbZt;

					public ControllerPollingInfo LpUvDbKyfaiwbeflTwCzrVnHaGw;

					public ControllerPollingInfo IexjJwfeooOwCxbMNoDgOorzwLvD;

					public IEnumerator<ControllerPollingInfo> PmJuUWXnYSNAUJdBnCvldncdviYa;

					public IEnumerator<ControllerPollingInfo> ceLWvsSDLEGyacTxoIdyHgWHKREx;

					public IEnumerator<ControllerPollingInfo> IjPftTPlSdRRWfPgcyDGNAdlsNs;

					public IEnumerator<ControllerPollingInfo> PhsHODoAFLsKRNIDoVyXirGgzJJ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
						{
							goto IL_0012;
						}
						goto IL_0069;
						IL_0012:
						int num = -1113105684;
						goto IL_0017;
						IL_0017:
						rRZvPhYTeMTousfytyIrYqJQFBFI rRZvPhYTeMTousfytyIrYqJQFBFI2 = default(rRZvPhYTeMTousfytyIrYqJQFBFI);
						while (true)
						{
							switch (num ^ -1113105688)
							{
							case 0:
								break;
							case 4:
								if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
								{
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
									rRZvPhYTeMTousfytyIrYqJQFBFI2 = this;
									num = -1113105687;
									continue;
								}
								goto IL_0069;
							case 5:
								rRZvPhYTeMTousfytyIrYqJQFBFI2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								num = -1113105686;
								continue;
							case 3:
								goto IL_0069;
							case 1:
								num = -1113105686;
								continue;
							default:
								return rRZvPhYTeMTousfytyIrYqJQFBFI2;
							}
							break;
						}
						goto IL_0012;
						IL_0069:
						rRZvPhYTeMTousfytyIrYqJQFBFI2 = new rRZvPhYTeMTousfytyIrYqJQFBFI(0);
						num = -1113105683;
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
							int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
							while (true)
							{
								IL_0007:
								int num2 = -1712688597;
								while (true)
								{
									switch (num2 ^ -1712688606)
									{
									case 21:
										break;
									case 19:
										ZHWUyeVTrBtYmmSPojYxHNrhGjn();
										num2 = -1712688602;
										continue;
									case 7:
										num2 = -1712688581;
										continue;
									case 1:
										QVAKbXXQJMtQGqfpHCPNdvQKqbHe = PmJuUWXnYSNAUJdBnCvldncdviYa.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = QVAKbXXQJMtQGqfpHCPNdvQKqbHe;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										result = true;
										num2 = -1712688598;
										continue;
									case 9:
										switch (num)
										{
										case 6:
											goto IL_0102;
										case 4:
											goto IL_0174;
										case 8:
											goto IL_01e2;
										case 2:
											goto IL_0213;
										case 0:
											goto IL_0224;
										case 1:
										case 3:
										case 5:
										case 7:
											goto IL_0347;
										}
										num2 = -1712688607;
										continue;
									case 14:
										goto IL_0102;
									case 23:
									{
										int num3;
										if (PmJuUWXnYSNAUJdBnCvldncdviYa.MoveNext())
										{
											num2 = -1712688605;
											num3 = num2;
										}
										else
										{
											num2 = -1712688591;
											num3 = num2;
										}
										continue;
									}
									case 11:
										goto end_IL_000c;
									case 8:
										goto end_IL_000c;
									case 15:
										result = true;
										goto end_IL_000c;
									case 6:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 5;
										num2 = -1712688601;
										continue;
									case 16:
										goto IL_0174;
									case 24:
										dfyelpdGjHSTakKpHOilSnOOqbZt = ceLWvsSDLEGyacTxoIdyHgWHKREx.Current;
										num2 = -1712688592;
										continue;
									case 4:
										ceLWvsSDLEGyacTxoIdyHgWHKREx = iKQXbXnVtIaMZEJNeigQJWAHqUx.gByFpjsgRfdXoflOsFeeGcqfNoUh().GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
										num2 = -1712688606;
										continue;
									case 12:
										num2 = -1712688587;
										continue;
									case 22:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 7;
										num2 = -1712688603;
										continue;
									case 20:
										goto IL_01e2;
									case 25:
										if (!PhsHODoAFLsKRNIDoVyXirGgzJJ.MoveNext())
										{
											dTBzPWMsYvTojbkqIxDHCboltfM();
											num2 = -1712688607;
											continue;
										}
										goto case 2;
									case 17:
										goto IL_0213;
									case 10:
										goto IL_0224;
									case 13:
										LpUvDbKyfaiwbeflTwCzrVnHaGw = IjPftTPlSdRRWfPgcyDGNAdlsNs.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = LpUvDbKyfaiwbeflTwCzrVnHaGw;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 6;
										result = true;
										num2 = -1712688599;
										continue;
									case 0:
										if (!ceLWvsSDLEGyacTxoIdyHgWHKREx.MoveNext())
										{
											ASnNJPNblZEwqUDHVafCwWGAbSL();
											IjPftTPlSdRRWfPgcyDGNAdlsNs = iKQXbXnVtIaMZEJNeigQJWAHqUx.oVLbDMmobZIVAhpTioxWHsvgpRw().GetEnumerator();
											num2 = -1712688604;
											continue;
										}
										goto case 24;
									case 18:
										aimBzjfQfPyaeQqysAQJISCBhELB = dfyelpdGjHSTakKpHOilSnOOqbZt;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 4;
										result = true;
										goto end_IL_000c;
									case 2:
										IexjJwfeooOwCxbMNoDgOorzwLvD = PhsHODoAFLsKRNIDoVyXirGgzJJ.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = IexjJwfeooOwCxbMNoDgOorzwLvD;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 8;
										num2 = -1712688595;
										continue;
									case 5:
										if (!IjPftTPlSdRRWfPgcyDGNAdlsNs.MoveNext())
										{
											QnLTcGkRuXKmsDLscNVpHGYXMak();
											PhsHODoAFLsKRNIDoVyXirGgzJJ = iKQXbXnVtIaMZEJNeigQJWAHqUx.OGJbHsYUYfbCUMqFbCdwrwKbbiq().GetEnumerator();
											num2 = -1712688588;
											continue;
										}
										goto case 13;
									default:
										goto IL_0347;
										IL_01e2:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 7;
										num2 = -1712688581;
										continue;
										IL_0174:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
										num2 = -1712688606;
										continue;
										IL_0102:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 5;
										num2 = -1712688601;
										continue;
										IL_0224:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
										if (CheckInitialized())
										{
											PmJuUWXnYSNAUJdBnCvldncdviYa = iKQXbXnVtIaMZEJNeigQJWAHqUx.FITSIKaECPVvULGUoGsZcVXnBmgl().GetEnumerator();
											oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
											num2 = -1712688594;
											continue;
										}
										goto IL_0347;
										IL_0347:
										result = false;
										goto end_IL_000c;
										IL_0213:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num2 = -1712688587;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								ZHWUyeVTrBtYmmSPojYxHNrhGjn();
							}
							break;
						}
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								ASnNJPNblZEwqUDHVafCwWGAbSL();
							}
							break;
						}
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 5:
						case 6:
							try
							{
							}
							finally
							{
								QnLTcGkRuXKmsDLscNVpHGYXMak();
							}
							break;
						}
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 7:
						case 8:
							try
							{
								break;
							}
							finally
							{
								dTBzPWMsYvTojbkqIxDHCboltfM();
							}
						}
					}

					[DebuggerHidden]
					public rRZvPhYTeMTousfytyIrYqJQFBFI(int _003C_003E1__state)
					{
						while (true)
						{
							int num = 2071636068;
							while (true)
							{
								switch (num ^ 0x7B7AA865)
								{
								case 0:
									break;
								case 1:
									goto IL_0024;
								default:
									HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
									return;
								}
								break;
								IL_0024:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
								num = 2071636071;
							}
						}
					}

					private void ZHWUyeVTrBtYmmSPojYxHNrhGjn()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (PmJuUWXnYSNAUJdBnCvldncdviYa != null)
						{
							PmJuUWXnYSNAUJdBnCvldncdviYa.Dispose();
						}
					}

					private void ASnNJPNblZEwqUDHVafCwWGAbSL()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (ceLWvsSDLEGyacTxoIdyHgWHKREx != null)
						{
							ceLWvsSDLEGyacTxoIdyHgWHKREx.Dispose();
						}
					}

					private void QnLTcGkRuXKmsDLscNVpHGYXMak()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (IjPftTPlSdRRWfPgcyDGNAdlsNs != null)
						{
							IjPftTPlSdRRWfPgcyDGNAdlsNs.Dispose();
						}
					}

					private void dTBzPWMsYvTojbkqIxDHCboltfM()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (PhsHODoAFLsKRNIDoVyXirGgzJJ != null)
						{
							PhsHODoAFLsKRNIDoVyXirGgzJJ.Dispose();
						}
					}
				}

				private sealed class sBfFUnoQavsryDmMwTubwjVOPCb : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public PollingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public ControllerPollingInfo wVmOyOFiUcVBlUdGqusgxAYoCDn;

					public ControllerPollingInfo nbgmIkXcIprLjNfHOREhrRkuoaO;

					public ControllerPollingInfo QefzjHBEXBbNpwzbWHAoJkuNJhL;

					public ControllerPollingInfo zcbHfBgSIXxbHobDkbYIDNbnjxSd;

					public IEnumerator<ControllerPollingInfo> yBPdDGdszSdfwGMUXUHybqdTcuZG;

					public IEnumerator<ControllerPollingInfo> qAOUWQSdBTprqjJotLVeRMMYMiK;

					public IEnumerator<ControllerPollingInfo> OnfBhXHrLWOYSrHqicDTUPasNkj;

					public IEnumerator<ControllerPollingInfo> KLkVfCKDFbhRonUrNXZxnjaiyEX;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
						{
							goto IL_0012;
						}
						goto IL_0054;
						IL_0012:
						int num = -933811038;
						goto IL_0017;
						IL_0017:
						sBfFUnoQavsryDmMwTubwjVOPCb sBfFUnoQavsryDmMwTubwjVOPCb2 = default(sBfFUnoQavsryDmMwTubwjVOPCb);
						while (true)
						{
							switch (num ^ -933811037)
							{
							case 5:
								break;
							case 1:
								if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
								{
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
									num = -933811037;
									continue;
								}
								goto IL_0054;
							case 4:
								goto IL_0054;
							case 0:
								sBfFUnoQavsryDmMwTubwjVOPCb2 = this;
								num = -933811040;
								continue;
							case 2:
								sBfFUnoQavsryDmMwTubwjVOPCb2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								num = -933811040;
								continue;
							default:
								return sBfFUnoQavsryDmMwTubwjVOPCb2;
							}
							break;
						}
						goto IL_0012;
						IL_0054:
						sBfFUnoQavsryDmMwTubwjVOPCb2 = new sBfFUnoQavsryDmMwTubwjVOPCb(0);
						num = -933811039;
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
							int num;
							int num4;
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							case 4:
								goto IL_011b;
							case 8:
								goto IL_0147;
							default:
								goto IL_0186;
							case 2:
								goto IL_01d8;
							case 0:
								goto IL_0249;
							case 6:
								goto IL_02cd;
								IL_011b:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
								num = 245682473;
								goto IL_003b;
								IL_003b:
								while (true)
								{
									switch (num ^ 0xEA4D120)
									{
									case 26:
										num = 245682483;
										continue;
									case 29:
										wVmOyOFiUcVBlUdGqusgxAYoCDn = yBPdDGdszSdfwGMUXUHybqdTcuZG.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = wVmOyOFiUcVBlUdGqusgxAYoCDn;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										result = true;
										num = 245682475;
										continue;
									case 16:
										KLkVfCKDFbhRonUrNXZxnjaiyEX = iKQXbXnVtIaMZEJNeigQJWAHqUx.iGVymXxSErGssuaWtbmaaKEZPOrD().GetEnumerator();
										num = 245682489;
										continue;
									case 24:
										goto IL_011b;
									case 5:
										nbgmIkXcIprLjNfHOREhrRkuoaO = qAOUWQSdBTprqjJotLVeRMMYMiK.Current;
										num = 245682468;
										continue;
									case 0:
										goto IL_0147;
									case 2:
										QefzjHBEXBbNpwzbWHAoJkuNJhL = OnfBhXHrLWOYSrHqicDTUPasNkj.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = QefzjHBEXBbNpwzbWHAoJkuNJhL;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 6;
										num = 245682470;
										continue;
									case 15:
										goto IL_0186;
									case 27:
										goto IL_0192;
									case 11:
										break;
									case 4:
										aimBzjfQfPyaeQqysAQJISCBhELB = nbgmIkXcIprLjNfHOREhrRkuoaO;
										num = 245682482;
										continue;
									case 1:
										goto IL_01d8;
									case 14:
										yBPdDGdszSdfwGMUXUHybqdTcuZG = iKQXbXnVtIaMZEJNeigQJWAHqUx.mcRnLilILRLsaMcwMbkNNPmpswx().GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num = 245682487;
										continue;
									case 7:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 8;
										result = true;
										break;
									case 9:
										goto IL_0228;
									case 19:
										goto IL_0249;
									case 28:
										qAOUWQSdBTprqjJotLVeRMMYMiK = iKQXbXnVtIaMZEJNeigQJWAHqUx.QBcgdYdqwsLotCArKVfGzZsRCKD().GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
										num = 245682494;
										continue;
									case 13:
										break;
									case 6:
										result = true;
										num = 245682477;
										continue;
									case 12:
										if (!yBPdDGdszSdfwGMUXUHybqdTcuZG.MoveNext())
										{
											BgSOUkpKWEbSRkqBYfWjjYICAkKe();
											num = 245682492;
											continue;
										}
										goto case 29;
									case 22:
										goto IL_02cd;
									case 10:
										zcbHfBgSIXxbHobDkbYIDNbnjxSd = KLkVfCKDFbhRonUrNXZxnjaiyEX.Current;
										num = 245682495;
										continue;
									case 18:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 4;
										result = true;
										break;
									case 20:
										yCdBeXNCEsmwVgILNjlQUeWaCEi();
										num = 245682480;
										continue;
									case 23:
										num = 245682476;
										continue;
									case 25:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 7;
										num = 245682467;
										continue;
									case 21:
										if (!KLkVfCKDFbhRonUrNXZxnjaiyEX.MoveNext())
										{
											RJLwAzsZPwQWrHlRGglngIKXiPw();
											num = 245682479;
											continue;
										}
										goto case 10;
									case 30:
										num = 245682473;
										continue;
									case 31:
										aimBzjfQfPyaeQqysAQJISCBhELB = zcbHfBgSIXxbHobDkbYIDNbnjxSd;
										num = 245682471;
										continue;
									case 3:
										num = 245682485;
										continue;
									case 17:
										JSKPtFpGThELVIduOaDIgjUjUUcm();
										OnfBhXHrLWOYSrHqicDTUPasNkj = iKQXbXnVtIaMZEJNeigQJWAHqUx.YxKFHoPCWDOhrAoZxeOqaaLGcrXM().GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 5;
										num = 245682491;
										continue;
									case 8:
										break;
									}
									break;
									IL_0228:
									int num2;
									if (qAOUWQSdBTprqjJotLVeRMMYMiK.MoveNext())
									{
										num = 245682469;
										num2 = num;
									}
									else
									{
										num = 245682481;
										num2 = num;
									}
									continue;
									IL_0192:
									int num3;
									if (!OnfBhXHrLWOYSrHqicDTUPasNkj.MoveNext())
									{
										num = 245682484;
										num3 = num;
									}
									else
									{
										num = 245682466;
										num3 = num;
									}
								}
								break;
								IL_02cd:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 5;
								num = 245682491;
								goto IL_003b;
								IL_0249:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								if (!CheckInitialized())
								{
									num = 245682479;
									num4 = num;
								}
								else
								{
									num = 245682478;
									num4 = num;
								}
								goto IL_003b;
								IL_0186:
								result = false;
								num = 245682472;
								goto IL_003b;
								IL_0147:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 7;
								num = 245682485;
								goto IL_003b;
								IL_01d8:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = 245682476;
								goto IL_003b;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								BgSOUkpKWEbSRkqBYfWjjYICAkKe();
							}
							break;
						}
						int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
						while (true)
						{
							int num2 = -1183876130;
							while (true)
							{
								switch (num2 ^ -1183876132)
								{
								case 0:
									break;
								case 2:
									switch (num)
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
										JSKPtFpGThELVIduOaDIgjUjUUcm();
									}
									goto default;
								default:
								{
									int num3 = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
									while (true)
									{
										int num4 = -1183876130;
										while (true)
										{
											switch (num4 ^ -1183876132)
											{
											case 0:
												break;
											case 2:
												switch (num3)
												{
												default:
													goto IL_009e;
												case 5:
												case 6:
													break;
												}
												try
												{
												}
												finally
												{
													yCdBeXNCEsmwVgILNjlQUeWaCEi();
												}
												goto default;
											default:
												switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
												{
												case 7:
												case 8:
													try
													{
														break;
													}
													finally
													{
														RJLwAzsZPwQWrHlRGglngIKXiPw();
													}
												}
												return;
											}
											break;
											IL_009e:
											num4 = -1183876131;
										}
									}
								}
								}
								break;
								IL_0057:
								num2 = -1183876131;
							}
						}
					}

					[DebuggerHidden]
					public sBfFUnoQavsryDmMwTubwjVOPCb(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void BgSOUkpKWEbSRkqBYfWjjYICAkKe()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (yBPdDGdszSdfwGMUXUHybqdTcuZG == null)
						{
							return;
						}
						while (true)
						{
							int num = 2051320575;
							while (true)
							{
								switch (num ^ 0x7A44AAFE)
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
								yBPdDGdszSdfwGMUXUHybqdTcuZG.Dispose();
								num = 2051320572;
							}
						}
					}

					private void JSKPtFpGThELVIduOaDIgjUjUUcm()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (qAOUWQSdBTprqjJotLVeRMMYMiK != null)
						{
							qAOUWQSdBTprqjJotLVeRMMYMiK.Dispose();
						}
					}

					private void yCdBeXNCEsmwVgILNjlQUeWaCEi()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (OnfBhXHrLWOYSrHqicDTUPasNkj == null)
						{
							return;
						}
						while (true)
						{
							int num = 1170893862;
							while (true)
							{
								switch (num ^ 0x45CA6C24)
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
								OnfBhXHrLWOYSrHqicDTUPasNkj.Dispose();
								num = 1170893861;
							}
						}
					}

					private void RJLwAzsZPwQWrHlRGglngIKXiPw()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (KLkVfCKDFbhRonUrNXZxnjaiyEX != null)
						{
							KLkVfCKDFbhRonUrNXZxnjaiyEX.Dispose();
						}
					}
				}

				private sealed class JTRzaMtbEAQAlOryEbItdYdQSfo : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public PollingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public ControllerPollingInfo eUgkspahhYuIkYdzFLFzzIrgAq;

					public ControllerPollingInfo BuiIGBWlutOVkoVUmqRRONYGojP;

					public ControllerPollingInfo YBXMHeXBgXywvJWEKsFwaBZGJck;

					public IEnumerator<ControllerPollingInfo> RkJHcgudCkBOLATpumovRDgeKMZ;

					public IEnumerator<ControllerPollingInfo> PbChTbIVWZgeMQeiDkGelfVRRvR;

					public IEnumerator<ControllerPollingInfo> YxeTlEjmdzDikmtvYEscftUEnniQ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						JTRzaMtbEAQAlOryEbItdYdQSfo jTRzaMtbEAQAlOryEbItdYdQSfo;
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							jTRzaMtbEAQAlOryEbItdYdQSfo = this;
						}
						else
						{
							while (true)
							{
								jTRzaMtbEAQAlOryEbItdYdQSfo = new JTRzaMtbEAQAlOryEbItdYdQSfo(0);
								jTRzaMtbEAQAlOryEbItdYdQSfo.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								int num = -353687744;
								while (true)
								{
									switch (num ^ -353687744)
									{
									case 2:
										num = -353687743;
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
						return jTRzaMtbEAQAlOryEbItdYdQSfo;
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
							int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
							while (true)
							{
								int num2 = 2016018152;
								while (true)
								{
									switch (num2 ^ 0x7829FEEB)
									{
									case 14:
										break;
									case 12:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
										num2 = 2016018156;
										continue;
									case 1:
										goto IL_007e;
									case 7:
									{
										int num4;
										if (PbChTbIVWZgeMQeiDkGelfVRRvR.MoveNext())
										{
											num2 = 2016018158;
											num4 = num2;
										}
										else
										{
											num2 = 2016018170;
											num4 = num2;
										}
										continue;
									}
									case 15:
										return true;
									case 18:
										YBXMHeXBgXywvJWEKsFwaBZGJck = YxeTlEjmdzDikmtvYEscftUEnniQ.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = YBXMHeXBgXywvJWEKsFwaBZGJck;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 6;
										num2 = 2016018148;
										continue;
									case 11:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 4;
										return true;
									case 19:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 5;
										num2 = 2016018155;
										continue;
									case 3:
										switch (num)
										{
										case 4:
											break;
										case 2:
											goto IL_007e;
										default:
											goto IL_0137;
										case 0:
											goto IL_0168;
										case 6:
											goto IL_0277;
										case 1:
										case 3:
										case 5:
											goto IL_0298;
										}
										goto case 12;
									case 5:
										BuiIGBWlutOVkoVUmqRRONYGojP = PbChTbIVWZgeMQeiDkGelfVRRvR.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = BuiIGBWlutOVkoVUmqRRONYGojP;
										num2 = 2016018144;
										continue;
									case 20:
										goto IL_0168;
									case 8:
										if (CheckInitialized())
										{
											RkJHcgudCkBOLATpumovRDgeKMZ = iKQXbXnVtIaMZEJNeigQJWAHqUx.MezVdyZhmXXrWQloTjBLuviedbP().GetEnumerator();
											oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
											num2 = 2016018146;
											continue;
										}
										goto IL_0298;
									case 2:
										eUgkspahhYuIkYdzFLFzzIrgAq = RkJHcgudCkBOLATpumovRDgeKMZ.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = eUgkspahhYuIkYdzFLFzzIrgAq;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										num2 = 2016018157;
										continue;
									case 6:
										return true;
									case 9:
									{
										int num3;
										if (RkJHcgudCkBOLATpumovRDgeKMZ.MoveNext())
										{
											num2 = 2016018153;
											num3 = num2;
										}
										else
										{
											num2 = 2016018159;
											num3 = num2;
										}
										continue;
									}
									case 17:
										wVkFDhNKjLmuhSWuWjMCKgmrHQq();
										YxeTlEjmdzDikmtvYEscftUEnniQ = iKQXbXnVtIaMZEJNeigQJWAHqUx.aZULStDmIyFDqhyxYEaMdhXpcpam().GetEnumerator();
										num2 = 2016018168;
										continue;
									case 10:
										PbChTbIVWZgeMQeiDkGelfVRRvR = iKQXbXnVtIaMZEJNeigQJWAHqUx.IyFFzGFhfcLDjpFDRMcEectHWpgg().GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
										num2 = 2016018156;
										continue;
									case 0:
										if (!YxeTlEjmdzDikmtvYEscftUEnniQ.MoveNext())
										{
											ikbTaelZtzgjQgGgfPWMRAQemsi();
											num2 = 2016018171;
											continue;
										}
										goto case 18;
									case 13:
										goto IL_0277;
									case 4:
										kDlpHlGOJgUxqQpvHnRRjiaVCbD();
										num2 = 2016018145;
										continue;
									default:
										goto IL_0298;
										IL_007e:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num2 = 2016018146;
										continue;
										IL_0298:
										return false;
										IL_0277:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 5;
										num2 = 2016018155;
										continue;
										IL_0168:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
										num2 = 2016018147;
										continue;
										IL_0137:
										num2 = 2016018171;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								kDlpHlGOJgUxqQpvHnRRjiaVCbD();
							}
							break;
						}
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								wVkFDhNKjLmuhSWuWjMCKgmrHQq();
							}
							break;
						}
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 5:
						case 6:
							try
							{
								break;
							}
							finally
							{
								ikbTaelZtzgjQgGgfPWMRAQemsi();
							}
						}
					}

					[DebuggerHidden]
					public JTRzaMtbEAQAlOryEbItdYdQSfo(int _003C_003E1__state)
					{
						while (true)
						{
							int num = -2115715363;
							while (true)
							{
								switch (num ^ -2115715361)
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
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
								HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
								num = -2115715362;
							}
						}
					}

					private void kDlpHlGOJgUxqQpvHnRRjiaVCbD()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (RkJHcgudCkBOLATpumovRDgeKMZ != null)
						{
							RkJHcgudCkBOLATpumovRDgeKMZ.Dispose();
						}
					}

					private void wVkFDhNKjLmuhSWuWjMCKgmrHQq()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (PbChTbIVWZgeMQeiDkGelfVRRvR != null)
						{
							PbChTbIVWZgeMQeiDkGelfVRRvR.Dispose();
						}
					}

					private void ikbTaelZtzgjQgGgfPWMRAQemsi()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (YxeTlEjmdzDikmtvYEscftUEnniQ != null)
						{
							YxeTlEjmdzDikmtvYEscftUEnniQ.Dispose();
						}
					}
				}

				private sealed class jQEAfcbQEDphwBNaJuaDdNYfnXGZ : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public IList<Joystick> ommmpzXTxnqnfLpsleNEiZcEDSwD;

					public int rLizgvwnHTelwJrLnKawBibQFNb;

					public ControllerPollingInfo CoimCTnTEdRtBSJQLkavxiLlghk;

					public PollingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ControllerPollingInfo> LQAFeEkistdLGrdiSdspQTMyyop;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							goto IL_0023;
						}
						goto IL_0065;
						IL_0028:
						int num;
						jQEAfcbQEDphwBNaJuaDdNYfnXGZ jQEAfcbQEDphwBNaJuaDdNYfnXGZ2 = default(jQEAfcbQEDphwBNaJuaDdNYfnXGZ);
						while (true)
						{
							switch (num ^ -248158524)
							{
							case 4:
								break;
							case 1:
								jQEAfcbQEDphwBNaJuaDdNYfnXGZ2 = this;
								num = -248158524;
								continue;
							case 3:
								jQEAfcbQEDphwBNaJuaDdNYfnXGZ2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								num = -248158524;
								continue;
							case 2:
								goto IL_0065;
							default:
								return jQEAfcbQEDphwBNaJuaDdNYfnXGZ2;
							}
							break;
						}
						goto IL_0023;
						IL_0065:
						jQEAfcbQEDphwBNaJuaDdNYfnXGZ2 = new jQEAfcbQEDphwBNaJuaDdNYfnXGZ(0);
						num = -248158521;
						goto IL_0028;
						IL_0023:
						num = -248158523;
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
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							case 0:
								goto IL_0095;
							case 2:
								goto IL_00e8;
							default:
								goto IL_013b;
								IL_0095:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								ommmpzXTxnqnfLpsleNEiZcEDSwD = uzYFVAOPCugnffcKSwcZmFfGUjB.Joysticks_readOnly;
								rLizgvwnHTelwJrLnKawBibQFNb = 0;
								num = -540218658;
								goto IL_0023;
								IL_0023:
								while (true)
								{
									switch (num ^ -540218662)
									{
									case 9:
										num = -540218672;
										continue;
									case 6:
										goto IL_0063;
									case 11:
										result = true;
										break;
									case 10:
										goto IL_0095;
									case 5:
										if (!LQAFeEkistdLGrdiSdspQTMyyop.MoveNext())
										{
											nYBEgEUpxACSmHBptuZcCrREKnJ();
											rLizgvwnHTelwJrLnKawBibQFNb++;
											num = -540218660;
											continue;
										}
										goto case 1;
									case 8:
										goto IL_00e8;
									case 4:
										num = -540218660;
										continue;
									case 1:
										CoimCTnTEdRtBSJQLkavxiLlghk = LQAFeEkistdLGrdiSdspQTMyyop.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = CoimCTnTEdRtBSJQLkavxiLlghk;
										num = -540218662;
										continue;
									case 0:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										num = -540218671;
										continue;
									case 2:
										goto IL_013b;
									case 7:
										LQAFeEkistdLGrdiSdspQTMyyop = ommmpzXTxnqnfLpsleNEiZcEDSwD[rLizgvwnHTelwJrLnKawBibQFNb].PollForAllElements().GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num = -540218657;
										continue;
									case 3:
										break;
									}
									break;
									IL_0063:
									int num2;
									if (rLizgvwnHTelwJrLnKawBibQFNb >= ommmpzXTxnqnfLpsleNEiZcEDSwD.Count)
									{
										num = -540218664;
										num2 = num;
									}
									else
									{
										num = -540218659;
										num2 = num;
									}
								}
								break;
								IL_013b:
								result = false;
								num = -540218663;
								goto IL_0023;
								IL_00e8:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = -540218657;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								nYBEgEUpxACSmHBptuZcCrREKnJ();
							}
						}
					}

					[DebuggerHidden]
					public jQEAfcbQEDphwBNaJuaDdNYfnXGZ(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void nYBEgEUpxACSmHBptuZcCrREKnJ()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (LQAFeEkistdLGrdiSdspQTMyyop != null)
						{
							LQAFeEkistdLGrdiSdspQTMyyop.Dispose();
						}
					}
				}

				private sealed class nmKFTssbPSFbtaQdccIKsckcOdIR : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public IList<Joystick> jTdebdbyiIWUnVDXvbrGkONaOpJ;

					public int JYbfYHuOjRvysHjqaiKonNKoYpy;

					public ControllerPollingInfo UFynJhaoUmsQOoYPqIlioaFeYtp;

					public PollingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ControllerPollingInfo> HTENpfEjugCKJaTXilyTrfHNpxJc;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
						{
							goto IL_0012;
						}
						goto IL_0059;
						IL_0012:
						int num = -1105602083;
						goto IL_0017;
						IL_0017:
						nmKFTssbPSFbtaQdccIKsckcOdIR nmKFTssbPSFbtaQdccIKsckcOdIR2 = default(nmKFTssbPSFbtaQdccIKsckcOdIR);
						while (true)
						{
							switch (num ^ -1105602082)
							{
							case 0:
								break;
							case 3:
								if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
								{
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
									nmKFTssbPSFbtaQdccIKsckcOdIR2 = this;
									num = -1105602081;
									continue;
								}
								goto IL_0059;
							case 1:
								num = -1105602086;
								continue;
							case 2:
								goto IL_0059;
							default:
								return nmKFTssbPSFbtaQdccIKsckcOdIR2;
							}
							break;
						}
						goto IL_0012;
						IL_0059:
						nmKFTssbPSFbtaQdccIKsckcOdIR2 = new nmKFTssbPSFbtaQdccIKsckcOdIR(0);
						nmKFTssbPSFbtaQdccIKsckcOdIR2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = -1105602086;
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
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							case 2:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = 1193984987;
								goto IL_0023;
							case 0:
								goto IL_015d;
								IL_0023:
								while (true)
								{
									switch (num ^ 0x472AC3D3)
									{
									case 5:
										num = 1193984980;
										continue;
									case 2:
										break;
									case 4:
										JYbfYHuOjRvysHjqaiKonNKoYpy = 0;
										num = 1193984984;
										continue;
									case 3:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num = 1193984987;
										continue;
									case 1:
										nacsnJVDvpneZLdLISupbncsQVZ();
										JYbfYHuOjRvysHjqaiKonNKoYpy++;
										num = 1193984985;
										continue;
									case 11:
										num = 1193984985;
										continue;
									case 9:
										UFynJhaoUmsQOoYPqIlioaFeYtp = HTENpfEjugCKJaTXilyTrfHNpxJc.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = UFynJhaoUmsQOoYPqIlioaFeYtp;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										return true;
									case 6:
										HTENpfEjugCKJaTXilyTrfHNpxJc = jTdebdbyiIWUnVDXvbrGkONaOpJ[JYbfYHuOjRvysHjqaiKonNKoYpy].PollForAllElementsDown().GetEnumerator();
										num = 1193984976;
										continue;
									case 8:
										goto IL_0115;
									case 10:
										goto IL_0136;
									case 7:
										goto IL_015d;
									default:
										goto end_IL_0008;
									}
									break;
									IL_0136:
									int num2;
									if (JYbfYHuOjRvysHjqaiKonNKoYpy < jTdebdbyiIWUnVDXvbrGkONaOpJ.Count)
									{
										num = 1193984981;
										num2 = num;
									}
									else
									{
										num = 1193984979;
										num2 = num;
									}
									continue;
									IL_0115:
									int num3;
									if (HTENpfEjugCKJaTXilyTrfHNpxJc.MoveNext())
									{
										num = 1193984986;
										num3 = num;
									}
									else
									{
										num = 1193984978;
										num3 = num;
									}
								}
								goto case 2;
								IL_015d:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								jTdebdbyiIWUnVDXvbrGkONaOpJ = uzYFVAOPCugnffcKSwcZmFfGUjB.Joysticks_readOnly;
								num = 1193984983;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								nacsnJVDvpneZLdLISupbncsQVZ();
							}
						}
					}

					[DebuggerHidden]
					public nmKFTssbPSFbtaQdccIKsckcOdIR(int _003C_003E1__state)
					{
						while (true)
						{
							int num = 1869511633;
							while (true)
							{
								switch (num ^ 0x6F6E7BD3)
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
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
								HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
								num = 1869511634;
							}
						}
					}

					private void nacsnJVDvpneZLdLISupbncsQVZ()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (HTENpfEjugCKJaTXilyTrfHNpxJc == null)
						{
							return;
						}
						while (true)
						{
							int num = 1669825412;
							while (true)
							{
								switch (num ^ 0x63878386)
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
								HTENpfEjugCKJaTXilyTrfHNpxJc.Dispose();
								num = 1669825415;
							}
						}
					}
				}

				private sealed class bPAlFtZIrEXlyPUXsfTldCWNraU : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public IList<Joystick> wMblKUdRHRaxFVjKtGadVSQKwlF;

					public int vsJbhqkNAftePhECgkbZpdRLJUB;

					public ControllerPollingInfo hooqbwhhUPUwnytaRCnuNKBqvi;

					public PollingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ControllerPollingInfo> OHfhXiyuxpOmRjDnaGjXNmKDaIqH;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
						{
							goto IL_0012;
						}
						goto IL_0050;
						IL_0012:
						int num = -1275155480;
						goto IL_0017;
						IL_0017:
						bPAlFtZIrEXlyPUXsfTldCWNraU bPAlFtZIrEXlyPUXsfTldCWNraU2 = default(bPAlFtZIrEXlyPUXsfTldCWNraU);
						while (true)
						{
							switch (num ^ -1275155478)
							{
							case 4:
								break;
							case 2:
								if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
								{
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
									num = -1275155477;
									continue;
								}
								goto IL_0050;
							case 3:
								goto IL_0050;
							case 1:
								bPAlFtZIrEXlyPUXsfTldCWNraU2 = this;
								num = -1275155478;
								continue;
							default:
								return bPAlFtZIrEXlyPUXsfTldCWNraU2;
							}
							break;
						}
						goto IL_0012;
						IL_0050:
						bPAlFtZIrEXlyPUXsfTldCWNraU2 = new bPAlFtZIrEXlyPUXsfTldCWNraU(0);
						bPAlFtZIrEXlyPUXsfTldCWNraU2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = -1275155478;
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
							int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
							while (true)
							{
								int num2 = 410899433;
								while (true)
								{
									switch (num2 ^ 0x187DD3E1)
									{
									case 0:
										break;
									case 6:
										num2 = 410899439;
										continue;
									case 1:
									{
										int num4;
										if (vsJbhqkNAftePhECgkbZpdRLJUB < wMblKUdRHRaxFVjKtGadVSQKwlF.Count)
										{
											num2 = 410899435;
											num4 = num2;
										}
										else
										{
											num2 = 410899432;
											num4 = num2;
										}
										continue;
									}
									case 3:
										hooqbwhhUPUwnytaRCnuNKBqvi = OHfhXiyuxpOmRjDnaGjXNmKDaIqH.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = hooqbwhhUPUwnytaRCnuNKBqvi;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										num2 = 410899430;
										continue;
									case 4:
										vsJbhqkNAftePhECgkbZpdRLJUB = 0;
										num2 = 410899424;
										continue;
									case 7:
										return true;
									case 2:
										vsJbhqkNAftePhECgkbZpdRLJUB++;
										num2 = 410899424;
										continue;
									case 11:
										num2 = 410899432;
										continue;
									case 14:
									{
										int num3;
										if (OHfhXiyuxpOmRjDnaGjXNmKDaIqH.MoveNext())
										{
											num2 = 410899426;
											num3 = num2;
										}
										else
										{
											num2 = 410899428;
											num3 = num2;
										}
										continue;
									}
									case 10:
										OHfhXiyuxpOmRjDnaGjXNmKDaIqH = wMblKUdRHRaxFVjKtGadVSQKwlF[vsJbhqkNAftePhECgkbZpdRLJUB].PollForAllButtons().GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num2 = 410899431;
										continue;
									case 5:
										aqpmzZMQKqIcRxQdIStHJzdgUSe();
										num2 = 410899427;
										continue;
									case 13:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
										wMblKUdRHRaxFVjKtGadVSQKwlF = uzYFVAOPCugnffcKSwcZmFfGUjB.Joysticks_readOnly;
										num2 = 410899429;
										continue;
									case 8:
										switch (num)
										{
										case 0:
											break;
										default:
											goto IL_018b;
										case 2:
											goto IL_0195;
										case 1:
											goto IL_01a6;
										}
										goto case 13;
									case 12:
										goto IL_0195;
									default:
										goto IL_01a6;
										IL_01a6:
										return false;
										IL_0195:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num2 = 410899439;
										continue;
										IL_018b:
										num2 = 410899434;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								aqpmzZMQKqIcRxQdIStHJzdgUSe();
							}
						}
					}

					[DebuggerHidden]
					public bPAlFtZIrEXlyPUXsfTldCWNraU(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void aqpmzZMQKqIcRxQdIStHJzdgUSe()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (OHfhXiyuxpOmRjDnaGjXNmKDaIqH != null)
						{
							OHfhXiyuxpOmRjDnaGjXNmKDaIqH.Dispose();
						}
					}
				}

				private sealed class mNhWwkAlFqWgfLzRNLkXSpCfdoBh : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public IList<Joystick> pinZVNiGsWGLzaHTKYoAGwArtgo;

					public int EJSfvnbyyDWAmFdWtrBNSkPALwe;

					public ControllerPollingInfo vIChNEwZbYipnsnXjAHBJBMmYpGg;

					public PollingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ControllerPollingInfo> RtgLgKevcWIPHBzFBOqaBOTICze;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						mNhWwkAlFqWgfLzRNLkXSpCfdoBh mNhWwkAlFqWgfLzRNLkXSpCfdoBh2;
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							mNhWwkAlFqWgfLzRNLkXSpCfdoBh2 = this;
						}
						else
						{
							while (true)
							{
								mNhWwkAlFqWgfLzRNLkXSpCfdoBh2 = new mNhWwkAlFqWgfLzRNLkXSpCfdoBh(0);
								int num = -756091566;
								while (true)
								{
									switch (num ^ -756091568)
									{
									case 0:
										num = -756091565;
										continue;
									case 3:
										break;
									case 2:
										mNhWwkAlFqWgfLzRNLkXSpCfdoBh2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
										num = -756091567;
										continue;
									default:
										goto end_IL_0049;
									}
									break;
								}
								continue;
								end_IL_0049:
								break;
							}
						}
						return mNhWwkAlFqWgfLzRNLkXSpCfdoBh2;
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
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							case 2:
								goto IL_009d;
							case 0:
								goto IL_013c;
							default:
								goto IL_0182;
								IL_009d:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = 542253085;
								goto IL_0023;
								IL_0023:
								while (true)
								{
									switch (num ^ 0x20522019)
									{
									case 11:
										num = 542253075;
										continue;
									case 12:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num = 542253082;
										continue;
									case 5:
										RtgLgKevcWIPHBzFBOqaBOTICze = pinZVNiGsWGLzaHTKYoAGwArtgo[EJSfvnbyyDWAmFdWtrBNSkPALwe].PollForAllButtonsDown().GetEnumerator();
										num = 542253077;
										continue;
									case 9:
										goto IL_009d;
									case 3:
										num = 542253085;
										continue;
									case 4:
										goto IL_00b8;
									case 1:
										vIChNEwZbYipnsnXjAHBJBMmYpGg = RtgLgKevcWIPHBzFBOqaBOTICze.Current;
										num = 542253086;
										continue;
									case 6:
										goto IL_00f4;
									case 7:
										aimBzjfQfPyaeQqysAQJISCBhELB = vIChNEwZbYipnsnXjAHBJBMmYpGg;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										result = true;
										break;
									case 10:
										goto IL_013c;
									case 2:
										HqJeDcCtBlSfyUOkBJXzWoWxFXf();
										EJSfvnbyyDWAmFdWtrBNSkPALwe++;
										num = 542253087;
										continue;
									case 0:
										goto IL_0182;
									case 8:
										break;
									}
									break;
									IL_00f4:
									int num2;
									if (EJSfvnbyyDWAmFdWtrBNSkPALwe < pinZVNiGsWGLzaHTKYoAGwArtgo.Count)
									{
										num = 542253084;
										num2 = num;
									}
									else
									{
										num = 542253081;
										num2 = num;
									}
									continue;
									IL_00b8:
									int num3;
									if (!RtgLgKevcWIPHBzFBOqaBOTICze.MoveNext())
									{
										num = 542253083;
										num3 = num;
									}
									else
									{
										num = 542253080;
										num3 = num;
									}
								}
								break;
								IL_0182:
								result = false;
								num = 542253073;
								goto IL_0023;
								IL_013c:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								pinZVNiGsWGLzaHTKYoAGwArtgo = uzYFVAOPCugnffcKSwcZmFfGUjB.Joysticks_readOnly;
								EJSfvnbyyDWAmFdWtrBNSkPALwe = 0;
								num = 542253087;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								HqJeDcCtBlSfyUOkBJXzWoWxFXf();
							}
						}
					}

					[DebuggerHidden]
					public mNhWwkAlFqWgfLzRNLkXSpCfdoBh(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void HqJeDcCtBlSfyUOkBJXzWoWxFXf()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						while (true)
						{
							int num = 1238933447;
							while (true)
							{
								switch (num ^ 0x49D89FC5)
								{
								case 0:
									break;
								default:
									return;
								case 2:
									if (RtgLgKevcWIPHBzFBOqaBOTICze != null)
									{
										goto IL_002d;
									}
									return;
								case 1:
									return;
								}
								break;
								IL_002d:
								RtgLgKevcWIPHBzFBOqaBOTICze.Dispose();
								num = 1238933444;
							}
						}
					}
				}

				private sealed class OwrsyfmpikNrbzpgcHfJqbbiZUd : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public IList<Joystick> lWedgxdgmBBuJBeGJyaExbISGTyE;

					public int SHVsSgLWTiRXvhGcYWDtOrBYkSW;

					public ControllerPollingInfo SdmSFNIkgXbJqEbXunTraoGclxAx;

					public PollingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ControllerPollingInfo> cuZamKCzoEANVuUdAwJBiWbTupWj;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							goto IL_0023;
						}
						goto IL_005c;
						IL_0028:
						int num;
						OwrsyfmpikNrbzpgcHfJqbbiZUd owrsyfmpikNrbzpgcHfJqbbiZUd = default(OwrsyfmpikNrbzpgcHfJqbbiZUd);
						while (true)
						{
							switch (num ^ 0x1A7D0A5A)
							{
							case 0:
								break;
							case 4:
								owrsyfmpikNrbzpgcHfJqbbiZUd.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								num = 444402265;
								continue;
							case 1:
								goto IL_005c;
							case 2:
								owrsyfmpikNrbzpgcHfJqbbiZUd = this;
								num = 444402265;
								continue;
							default:
								return owrsyfmpikNrbzpgcHfJqbbiZUd;
							}
							break;
						}
						goto IL_0023;
						IL_005c:
						owrsyfmpikNrbzpgcHfJqbbiZUd = new OwrsyfmpikNrbzpgcHfJqbbiZUd(0);
						num = 444402270;
						goto IL_0028;
						IL_0023:
						num = 444402264;
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
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							case 0:
								goto IL_006b;
							default:
								goto IL_00b1;
							case 2:
								goto IL_010b;
								IL_006b:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								lWedgxdgmBBuJBeGJyaExbISGTyE = uzYFVAOPCugnffcKSwcZmFfGUjB.Joysticks_readOnly;
								SHVsSgLWTiRXvhGcYWDtOrBYkSW = 0;
								num = 1664362895;
								goto IL_0023;
								IL_0023:
								while (true)
								{
									switch (num ^ 0x63342987)
									{
									case 5:
										num = 1664362886;
										continue;
									case 1:
										goto IL_006b;
									case 2:
										goto IL_0090;
									case 10:
										goto IL_00b1;
									case 11:
										goto IL_00bd;
									case 6:
										SdmSFNIkgXbJqEbXunTraoGclxAx = cuZamKCzoEANVuUdAwJBiWbTupWj.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = SdmSFNIkgXbJqEbXunTraoGclxAx;
										num = 1664362894;
										continue;
									case 13:
										goto IL_010b;
									case 9:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										result = true;
										break;
									case 0:
										SHVsSgLWTiRXvhGcYWDtOrBYkSW++;
										num = 1664362892;
										continue;
									case 7:
										jgRendBgXRmOZXglNHBFyIkZFvW();
										num = 1664362887;
										continue;
									case 8:
										num = 1664362892;
										continue;
									case 4:
										cuZamKCzoEANVuUdAwJBiWbTupWj = lWedgxdgmBBuJBeGJyaExbISGTyE[SHVsSgLWTiRXvhGcYWDtOrBYkSW].PollForAllAxes().GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num = 1664362891;
										continue;
									case 12:
										num = 1664362885;
										continue;
									case 3:
										break;
									}
									break;
									IL_00bd:
									int num2;
									if (SHVsSgLWTiRXvhGcYWDtOrBYkSW >= lWedgxdgmBBuJBeGJyaExbISGTyE.Count)
									{
										num = 1664362893;
										num2 = num;
									}
									else
									{
										num = 1664362883;
										num2 = num;
									}
									continue;
									IL_0090:
									int num3;
									if (cuZamKCzoEANVuUdAwJBiWbTupWj.MoveNext())
									{
										num = 1664362881;
										num3 = num;
									}
									else
									{
										num = 1664362880;
										num3 = num;
									}
								}
								break;
								IL_010b:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = 1664362885;
								goto IL_0023;
								IL_00b1:
								result = false;
								num = 1664362884;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								jgRendBgXRmOZXglNHBFyIkZFvW();
							}
						}
					}

					[DebuggerHidden]
					public OwrsyfmpikNrbzpgcHfJqbbiZUd(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void jgRendBgXRmOZXglNHBFyIkZFvW()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						while (true)
						{
							int num = -291260185;
							while (true)
							{
								switch (num ^ -291260187)
								{
								case 0:
									break;
								default:
									return;
								case 2:
									if (cuZamKCzoEANVuUdAwJBiWbTupWj != null)
									{
										goto IL_002d;
									}
									return;
								case 1:
									return;
								}
								break;
								IL_002d:
								cuZamKCzoEANVuUdAwJBiWbTupWj.Dispose();
								num = -291260188;
							}
						}
					}
				}

				private sealed class FZpgNakgdjkFvxmvoJvawmnheFz : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public IList<CustomController> ABtbKEOeXxgCrWeajyPeLiXEcny;

					public int qfMWaelSIKcRUtYVYzRnFbJduEn;

					public ControllerPollingInfo xTnHtPPyYHRtHJmtetFcRMyZssD;

					public PollingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ControllerPollingInfo> LdHivrelIUgKOovFqqOvaqmAKZC;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						FZpgNakgdjkFvxmvoJvawmnheFz fZpgNakgdjkFvxmvoJvawmnheFz;
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							fZpgNakgdjkFvxmvoJvawmnheFz = this;
						}
						else
						{
							while (true)
							{
								fZpgNakgdjkFvxmvoJvawmnheFz = new FZpgNakgdjkFvxmvoJvawmnheFz(0);
								fZpgNakgdjkFvxmvoJvawmnheFz.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								int num = -231511719;
								while (true)
								{
									switch (num ^ -231511720)
									{
									case 0:
										num = -231511718;
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
						return fZpgNakgdjkFvxmvoJvawmnheFz;
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
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							case 2:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = 1932077859;
								goto IL_0023;
							case 0:
								goto IL_00ed;
								IL_0023:
								while (true)
								{
									switch (num ^ 0x73292B25)
									{
									case 7:
										num = 1932077869;
										continue;
									case 6:
										if (!LdHivrelIUgKOovFqqOvaqmAKZC.MoveNext())
										{
											PpjubpIykeSZImizdgpBDgveDSN();
											qfMWaelSIKcRUtYVYzRnFbJduEn++;
											num = 1932077861;
											continue;
										}
										goto case 2;
									case 5:
										num = 1932077859;
										continue;
									case 3:
										break;
									case 0:
										goto IL_0094;
									case 2:
										xTnHtPPyYHRtHJmtetFcRMyZssD = LdHivrelIUgKOovFqqOvaqmAKZC.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = xTnHtPPyYHRtHJmtetFcRMyZssD;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										return true;
									case 8:
										goto IL_00ed;
									case 1:
										LdHivrelIUgKOovFqqOvaqmAKZC = ABtbKEOeXxgCrWeajyPeLiXEcny[qfMWaelSIKcRUtYVYzRnFbJduEn].PollForAllElements().GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num = 1932077856;
										continue;
									default:
										goto end_IL_0008;
									}
									break;
									IL_0094:
									int num2;
									if (qfMWaelSIKcRUtYVYzRnFbJduEn < ABtbKEOeXxgCrWeajyPeLiXEcny.Count)
									{
										num = 1932077860;
										num2 = num;
									}
									else
									{
										num = 1932077857;
										num2 = num;
									}
								}
								goto case 2;
								IL_00ed:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								ABtbKEOeXxgCrWeajyPeLiXEcny = uzYFVAOPCugnffcKSwcZmFfGUjB.CustomControllers_readOnly;
								qfMWaelSIKcRUtYVYzRnFbJduEn = 0;
								num = 1932077861;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								PpjubpIykeSZImizdgpBDgveDSN();
							}
						}
					}

					[DebuggerHidden]
					public FZpgNakgdjkFvxmvoJvawmnheFz(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void PpjubpIykeSZImizdgpBDgveDSN()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (LdHivrelIUgKOovFqqOvaqmAKZC != null)
						{
							LdHivrelIUgKOovFqqOvaqmAKZC.Dispose();
						}
					}
				}

				private sealed class EzsuiBdjyRxbjybFtrZkibZcUYF : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public IList<CustomController> HImJUUNelZItDzCTvcrnzUlOqYo;

					public int DtiEoNRFiVrQxVoEEQDZzqkKDvnb;

					public ControllerPollingInfo dkLAkYIirbmqMYlgzCaUqrdyQzh;

					public PollingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ControllerPollingInfo> DuFDezDJLSfvtYXGGBNVjJDCTCtn;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						EzsuiBdjyRxbjybFtrZkibZcUYF ezsuiBdjyRxbjybFtrZkibZcUYF;
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							ezsuiBdjyRxbjybFtrZkibZcUYF = this;
						}
						else
						{
							while (true)
							{
								ezsuiBdjyRxbjybFtrZkibZcUYF = new EzsuiBdjyRxbjybFtrZkibZcUYF(0);
								int num = -1463597510;
								while (true)
								{
									switch (num ^ -1463597509)
									{
									case 0:
										num = -1463597512;
										continue;
									case 3:
										break;
									case 1:
										ezsuiBdjyRxbjybFtrZkibZcUYF.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
										num = -1463597511;
										continue;
									default:
										goto end_IL_0049;
									}
									break;
								}
								continue;
								end_IL_0049:
								break;
							}
						}
						return ezsuiBdjyRxbjybFtrZkibZcUYF;
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
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							case 0:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num = -317500217;
								goto IL_0023;
							case 2:
								goto IL_00aa;
								IL_0023:
								while (true)
								{
									switch (num ^ -317500223)
									{
									case 9:
										num = -317500215;
										continue;
									case 8:
										break;
									case 7:
										if (!DuFDezDJLSfvtYXGGBNVjJDCTCtn.MoveNext())
										{
											XnVYMoXcXLYTfdjBPYFCNhsanFM();
											num = -317500219;
											continue;
										}
										goto case 3;
									case 1:
										goto IL_0083;
									case 0:
										goto IL_00aa;
									case 3:
										dkLAkYIirbmqMYlgzCaUqrdyQzh = DuFDezDJLSfvtYXGGBNVjJDCTCtn.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = dkLAkYIirbmqMYlgzCaUqrdyQzh;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										return true;
									case 4:
										DtiEoNRFiVrQxVoEEQDZzqkKDvnb++;
										num = -317500224;
										continue;
									case 6:
										HImJUUNelZItDzCTvcrnzUlOqYo = uzYFVAOPCugnffcKSwcZmFfGUjB.CustomControllers_readOnly;
										DtiEoNRFiVrQxVoEEQDZzqkKDvnb = 0;
										num = -317500224;
										continue;
									case 5:
										DuFDezDJLSfvtYXGGBNVjJDCTCtn = HImJUUNelZItDzCTvcrnzUlOqYo[DtiEoNRFiVrQxVoEEQDZzqkKDvnb].PollForAllElementsDown().GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num = -317500218;
										continue;
									default:
										goto end_IL_0008;
									}
									break;
									IL_0083:
									int num2;
									if (DtiEoNRFiVrQxVoEEQDZzqkKDvnb < HImJUUNelZItDzCTvcrnzUlOqYo.Count)
									{
										num = -317500220;
										num2 = num;
									}
									else
									{
										num = -317500221;
										num2 = num;
									}
								}
								goto case 0;
								IL_00aa:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = -317500218;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								XnVYMoXcXLYTfdjBPYFCNhsanFM();
							}
						}
					}

					[DebuggerHidden]
					public EzsuiBdjyRxbjybFtrZkibZcUYF(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void XnVYMoXcXLYTfdjBPYFCNhsanFM()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (DuFDezDJLSfvtYXGGBNVjJDCTCtn != null)
						{
							DuFDezDJLSfvtYXGGBNVjJDCTCtn.Dispose();
						}
					}
				}

				private sealed class xWXquvVYahvuollElDxMgXVphmZt : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public IList<CustomController> TobMSZWBEYycZebkwjhSiivtuoQn;

					public int nWXONYsUqrsnottpXHRRNJnPrTt;

					public ControllerPollingInfo ONvbCUrRJwqfHZsogJQxnsKGPxR;

					public PollingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ControllerPollingInfo> RYefttLAcrtAxDCLfqePyptnrqw;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						xWXquvVYahvuollElDxMgXVphmZt xWXquvVYahvuollElDxMgXVphmZt2;
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							xWXquvVYahvuollElDxMgXVphmZt2 = this;
							goto IL_0025;
						}
						goto IL_004e;
						IL_002a:
						int num;
						while (true)
						{
							switch (num ^ -929456442)
							{
							case 0:
								break;
							case 3:
								num = -929456444;
								continue;
							case 1:
								goto IL_004e;
							default:
								return xWXquvVYahvuollElDxMgXVphmZt2;
							}
							break;
						}
						goto IL_0025;
						IL_004e:
						xWXquvVYahvuollElDxMgXVphmZt2 = new xWXquvVYahvuollElDxMgXVphmZt(0);
						xWXquvVYahvuollElDxMgXVphmZt2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = -929456444;
						goto IL_002a;
						IL_0025:
						num = -929456443;
						goto IL_002a;
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
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							case 0:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num = 1767609294;
								goto IL_0023;
							case 2:
								goto IL_009c;
								IL_0023:
								while (true)
								{
									switch (num ^ 0x695B93C6)
									{
									case 2:
										num = 1767609285;
										continue;
									case 3:
										break;
									case 7:
										RYefttLAcrtAxDCLfqePyptnrqw = TobMSZWBEYycZebkwjhSiivtuoQn[nWXONYsUqrsnottpXHRRNJnPrTt].PollForAllButtons().GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num = 1767609286;
										continue;
									case 1:
										goto IL_009c;
									case 4:
										goto IL_00ad;
									case 5:
										if (!RYefttLAcrtAxDCLfqePyptnrqw.MoveNext())
										{
											wzCTsSFgAPJGmvPPhSzYgTvTdtR();
											nWXONYsUqrsnottpXHRRNJnPrTt++;
											num = 1767609282;
											continue;
										}
										goto case 10;
									case 0:
										num = 1767609283;
										continue;
									case 9:
										num = 1767609282;
										continue;
									case 8:
										TobMSZWBEYycZebkwjhSiivtuoQn = uzYFVAOPCugnffcKSwcZmFfGUjB.CustomControllers_readOnly;
										nWXONYsUqrsnottpXHRRNJnPrTt = 0;
										num = 1767609295;
										continue;
									case 10:
										ONvbCUrRJwqfHZsogJQxnsKGPxR = RYefttLAcrtAxDCLfqePyptnrqw.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = ONvbCUrRJwqfHZsogJQxnsKGPxR;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										return true;
									default:
										goto end_IL_0008;
									}
									break;
									IL_00ad:
									int num2;
									if (nWXONYsUqrsnottpXHRRNJnPrTt < TobMSZWBEYycZebkwjhSiivtuoQn.Count)
									{
										num = 1767609281;
										num2 = num;
									}
									else
									{
										num = 1767609280;
										num2 = num;
									}
								}
								goto case 0;
								IL_009c:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = 1767609283;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								wzCTsSFgAPJGmvPPhSzYgTvTdtR();
							}
						}
					}

					[DebuggerHidden]
					public xWXquvVYahvuollElDxMgXVphmZt(int _003C_003E1__state)
					{
						while (true)
						{
							int num = -1023235024;
							while (true)
							{
								switch (num ^ -1023235023)
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
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
								HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
								num = -1023235023;
							}
						}
					}

					private void wzCTsSFgAPJGmvPPhSzYgTvTdtR()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (RYefttLAcrtAxDCLfqePyptnrqw != null)
						{
							RYefttLAcrtAxDCLfqePyptnrqw.Dispose();
						}
					}
				}

				private sealed class rwboJjpcurZkuFLtmCovcWiUDqn : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public IList<CustomController> bpkimOoiMQSWsiIVMJIBxZoubFj;

					public int wzdVSgEpXngiWyuDgJODlCNvAfH;

					public ControllerPollingInfo OcNUCNHOCCpiWdGZXieztmDdHkK;

					public PollingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ControllerPollingInfo> kBKSHzhVrLQzqmUxbTgtlYzsjep;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							goto IL_001c;
						}
						goto IL_004e;
						IL_004e:
						rwboJjpcurZkuFLtmCovcWiUDqn rwboJjpcurZkuFLtmCovcWiUDqn2 = new rwboJjpcurZkuFLtmCovcWiUDqn(0);
						rwboJjpcurZkuFLtmCovcWiUDqn2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						int num = 1869823388;
						goto IL_0021;
						IL_001c:
						num = 1869823390;
						goto IL_0021;
						IL_0021:
						while (true)
						{
							switch (num ^ 0x6F733D9F)
							{
							case 2:
								break;
							case 1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
								rwboJjpcurZkuFLtmCovcWiUDqn2 = this;
								num = 1869823388;
								continue;
							case 0:
								goto IL_004e;
							default:
								return rwboJjpcurZkuFLtmCovcWiUDqn2;
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
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							case 0:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num = 1952065716;
								goto IL_0023;
							case 2:
								goto IL_0158;
								IL_0023:
								while (true)
								{
									switch (num ^ 0x745A28B4)
									{
									case 10:
										num = 1952065714;
										continue;
									case 6:
										break;
									case 1:
										OcNUCNHOCCpiWdGZXieztmDdHkK = kBKSHzhVrLQzqmUxbTgtlYzsjep.Current;
										num = 1952065712;
										continue;
									case 7:
										if (!kBKSHzhVrLQzqmUxbTgtlYzsjep.MoveNext())
										{
											CAUHBGzNhXffyVysmgNgYpnxlqm();
											wzdVSgEpXngiWyuDgJODlCNvAfH++;
											num = 1952065724;
											continue;
										}
										goto case 1;
									case 4:
										aimBzjfQfPyaeQqysAQJISCBhELB = OcNUCNHOCCpiWdGZXieztmDdHkK;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										return true;
									case 5:
										kBKSHzhVrLQzqmUxbTgtlYzsjep = bpkimOoiMQSWsiIVMJIBxZoubFj[wzdVSgEpXngiWyuDgJODlCNvAfH].PollForAllButtonsDown().GetEnumerator();
										num = 1952065719;
										continue;
									case 0:
										bpkimOoiMQSWsiIVMJIBxZoubFj = uzYFVAOPCugnffcKSwcZmFfGUjB.CustomControllers_readOnly;
										wzdVSgEpXngiWyuDgJODlCNvAfH = 0;
										num = 1952065724;
										continue;
									case 8:
										goto IL_0120;
									case 3:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num = 1952065715;
										continue;
									case 2:
										goto IL_0158;
									default:
										goto end_IL_0008;
									}
									break;
									IL_0120:
									int num2;
									if (wzdVSgEpXngiWyuDgJODlCNvAfH >= bpkimOoiMQSWsiIVMJIBxZoubFj.Count)
									{
										num = 1952065725;
										num2 = num;
									}
									else
									{
										num = 1952065713;
										num2 = num;
									}
								}
								goto case 0;
								IL_0158:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = 1952065715;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								CAUHBGzNhXffyVysmgNgYpnxlqm();
							}
						}
					}

					[DebuggerHidden]
					public rwboJjpcurZkuFLtmCovcWiUDqn(int _003C_003E1__state)
					{
						while (true)
						{
							int num = 249427009;
							while (true)
							{
								switch (num ^ 0xEDDF442)
								{
								case 2:
									break;
								default:
									return;
								case 3:
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
									num = 249427010;
									continue;
								case 0:
									HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
									num = 249427011;
									continue;
								case 1:
									return;
								}
								break;
							}
						}
					}

					private void CAUHBGzNhXffyVysmgNgYpnxlqm()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (kBKSHzhVrLQzqmUxbTgtlYzsjep != null)
						{
							kBKSHzhVrLQzqmUxbTgtlYzsjep.Dispose();
						}
					}
				}

				private sealed class LYsXxcxBROvkPjCtGDyZDCZayTc : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public IList<CustomController> kgxmTvFqqGmChzxMffzrwSpVCho;

					public int huKgSFfLurAnhfWgKFRKhrtpeOCR;

					public ControllerPollingInfo bcmBYjblwSvKgzFXlOMYtrkeRyv;

					public PollingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ControllerPollingInfo> HYQPXhfZFFLBisyGtGDmvcLoIWiE;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						LYsXxcxBROvkPjCtGDyZDCZayTc lYsXxcxBROvkPjCtGDyZDCZayTc;
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							lYsXxcxBROvkPjCtGDyZDCZayTc = this;
						}
						else
						{
							while (true)
							{
								lYsXxcxBROvkPjCtGDyZDCZayTc = new LYsXxcxBROvkPjCtGDyZDCZayTc(0);
								int num = -948566169;
								while (true)
								{
									switch (num ^ -948566172)
									{
									case 0:
										num = -948566170;
										continue;
									case 2:
										break;
									case 3:
										lYsXxcxBROvkPjCtGDyZDCZayTc.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
										num = -948566171;
										continue;
									default:
										goto end_IL_0049;
									}
									break;
								}
								continue;
								end_IL_0049:
								break;
							}
						}
						return lYsXxcxBROvkPjCtGDyZDCZayTc;
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
							int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
							while (true)
							{
								IL_0007:
								int num2 = 295360952;
								while (true)
								{
									switch (num2 ^ 0x119AD9BD)
									{
									case 4:
										break;
									default:
										goto end_IL_000c;
									case 5:
										switch (num)
										{
										case 0:
											goto IL_00f8;
										case 1:
											goto IL_0120;
										case 2:
											goto IL_019a;
										}
										num2 = 295360950;
										continue;
									case 14:
									{
										int num4;
										if (huKgSFfLurAnhfWgKFRKhrtpeOCR < kgxmTvFqqGmChzxMffzrwSpVCho.Count)
										{
											num2 = 295360945;
											num4 = num2;
										}
										else
										{
											num2 = 295360957;
											num4 = num2;
										}
										continue;
									}
									case 9:
										SqDOLJuwFCmNSAvQtGTBCHGyICO();
										num2 = 295360944;
										continue;
									case 6:
										bcmBYjblwSvKgzFXlOMYtrkeRyv = HYQPXhfZFFLBisyGtGDmvcLoIWiE.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = bcmBYjblwSvKgzFXlOMYtrkeRyv;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										num2 = 295360959;
										continue;
									case 1:
										num2 = 295360958;
										continue;
									case 13:
										huKgSFfLurAnhfWgKFRKhrtpeOCR++;
										num2 = 295360947;
										continue;
									case 7:
										goto IL_00f8;
									case 0:
										goto IL_0120;
									case 2:
										result = true;
										goto end_IL_000c;
									case 11:
										num2 = 295360957;
										continue;
									case 3:
									{
										int num3;
										if (!HYQPXhfZFFLBisyGtGDmvcLoIWiE.MoveNext())
										{
											num2 = 295360948;
											num3 = num2;
										}
										else
										{
											num2 = 295360955;
											num3 = num2;
										}
										continue;
									}
									case 12:
										HYQPXhfZFFLBisyGtGDmvcLoIWiE = kgxmTvFqqGmChzxMffzrwSpVCho[huKgSFfLurAnhfWgKFRKhrtpeOCR].PollForAllAxes().GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num2 = 295360956;
										continue;
									case 10:
										goto IL_019a;
									case 8:
										goto end_IL_000c;
										IL_019a:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num2 = 295360958;
										continue;
										IL_0120:
										result = false;
										num2 = 295360949;
										continue;
										IL_00f8:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
										kgxmTvFqqGmChzxMffzrwSpVCho = uzYFVAOPCugnffcKSwcZmFfGUjB.CustomControllers_readOnly;
										huKgSFfLurAnhfWgKFRKhrtpeOCR = 0;
										num2 = 295360947;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								SqDOLJuwFCmNSAvQtGTBCHGyICO();
							}
						}
					}

					[DebuggerHidden]
					public LYsXxcxBROvkPjCtGDyZDCZayTc(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void SqDOLJuwFCmNSAvQtGTBCHGyICO()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (HYQPXhfZFFLBisyGtGDmvcLoIWiE != null)
						{
							HYQPXhfZFFLBisyGtGDmvcLoIWiE.Dispose();
						}
					}
				}

				private static PollingHelper muFkkiEUnsHdAMTJRFCFrPnztKW;

				internal static PollingHelper Instance
				{
					get
					{
						return muFkkiEUnsHdAMTJRFCFrPnztKW ?? (muFkkiEUnsHdAMTJRFCFrPnztKW = new PollingHelper());
					}
				}

				private PollingHelper()
				{
				}

				public ControllerPollingInfo PollAllControllersForFirstElement()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					ControllerPollingInfo result = bxDFVyFQdbPfAQaEvGZfxbQpHqxf();
					if (result.success)
					{
						goto IL_001d;
					}
					result = DfxlIwLBuWuWtFBhxftMdGaRCJj();
					int num = 1897438959;
					goto IL_0022;
					IL_0022:
					while (true)
					{
						switch (num ^ 0x71189EEB)
						{
						case 2:
							break;
						case 1:
							return result;
						case 0:
							return result;
						case 4:
							if (!result.success)
							{
								result = xYAAcgNctBcynIdfvkvnZNhvdRz();
								if (result.success)
								{
									return result;
								}
								result = ccEcRyemdUxDKgimlVBtIDwKhKoi();
								if (!result.success)
								{
									return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
								}
								num = 1897438952;
							}
							else
							{
								num = 1897438955;
							}
							continue;
						default:
							return result;
						}
						break;
					}
					goto IL_001d;
					IL_001d:
					num = 1897438954;
					goto IL_0022;
				}

				public ControllerPollingInfo PollAllControllersForFirstElementDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					ControllerPollingInfo result = lANoYDIhcPazVvSGpuYiTXSDNYa();
					if (result.success)
					{
						return result;
					}
					result = imFDrObflJqfTgimynWfUQviMHBF();
					if (result.success)
					{
						return result;
					}
					result = gNReUqIzZHBGuPWonoYBBTuogEs();
					if (result.success)
					{
						return result;
					}
					result = PzpjuCmhTMGyxeJrxrKrfmXEOkse();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
				}

				public ControllerPollingInfo PollAllControllersForFirstButton()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					ControllerPollingInfo result = VFoTnANXnwCgEDNPxwUjkMtRatm();
					if (result.success)
					{
						return result;
					}
					result = DfxlIwLBuWuWtFBhxftMdGaRCJj();
					if (result.success)
					{
						return result;
					}
					result = sZtWZLqHYjUEqtXtmJRKenARwmD();
					if (result.success)
					{
						return result;
					}
					result = nzmrXSpzZSAZEfGsDTNWEvOZZFZ();
					while (true)
					{
						int num = -466419935;
						while (true)
						{
							switch (num ^ -466419933)
							{
							case 0:
								break;
							case 2:
								if (result.success)
								{
									goto IL_0071;
								}
								return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
							default:
								return result;
							}
							break;
							IL_0071:
							num = -466419934;
						}
					}
				}

				public ControllerPollingInfo PollAllControllersForFirstButtonDown()
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					ControllerPollingInfo result = RUzEglTtSRuPMxsDAjqUNhfgudy();
					int num = 919756279;
					goto IL_000c;
					IL_000c:
					while (true)
					{
						switch (num ^ 0x36D25DF2)
						{
						case 3:
							break;
						case 2:
							return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
						case 4:
							if (result.success)
							{
								return result;
							}
							result = PdsjWmerCLcZmaKbzvEXFBQgHfnU();
							num = 919756274;
							continue;
						case 0:
							if (result.success)
							{
								num = 919756275;
								continue;
							}
							return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
						case 5:
							if (result.success)
							{
								return result;
							}
							result = imFDrObflJqfTgimynWfUQviMHBF();
							if (result.success)
							{
								return result;
							}
							result = ShfuvsBAEkHcqKceqXxUBTXdPVK();
							num = 919756278;
							continue;
						default:
							return result;
						}
						break;
					}
					goto IL_0007;
					IL_0007:
					num = 919756272;
					goto IL_000c;
				}

				public ControllerPollingInfo PollAllControllersForFirstAxis()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					ControllerPollingInfo result = WHGzoYmTgUBiuRdIOExZhIWjBtv();
					while (true)
					{
						int num = 2076823589;
						while (true)
						{
							switch (num ^ 0x7BC9D027)
							{
							case 0:
								break;
							case 2:
								if (result.success)
								{
									num = 2076823588;
									continue;
								}
								result = ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
								if (result.success)
								{
									return result;
								}
								result = wbBljEodPeRZUmTqWsyOvqcIJfq();
								if (result.success)
								{
									return result;
								}
								result = gTkmHecAAMXzdlhARFhmRACqetgd();
								if (result.success)
								{
									num = 2076823590;
									continue;
								}
								return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
							case 3:
								return result;
							default:
								return result;
							}
							break;
						}
					}
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					switch (controllerType)
					{
					default:
						while (true)
						{
							switch (-1644408679 ^ -1644408677)
							{
							case 0:
								continue;
							case 2:
								if (controllerType == ControllerType.Custom)
								{
									return ccEcRyemdUxDKgimlVBtIDwKhKoi();
								}
								throw new NotImplementedException();
							}
							break;
						}
						goto case ControllerType.Joystick;
					case ControllerType.Joystick:
						return bxDFVyFQdbPfAQaEvGZfxbQpHqxf();
					case ControllerType.Keyboard:
						return DfxlIwLBuWuWtFBhxftMdGaRCJj();
					case ControllerType.Mouse:
						return xYAAcgNctBcynIdfvkvnZNhvdRz();
					}
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					while (true)
					{
						switch (0x507DAB17 ^ 0x507DAB16)
						{
						case 2:
							continue;
						case 1:
							switch (controllerType)
							{
							case ControllerType.Joystick:
								break;
							case ControllerType.Keyboard:
								return imFDrObflJqfTgimynWfUQviMHBF();
							case ControllerType.Mouse:
								return gNReUqIzZHBGuPWonoYBBTuogEs();
							case ControllerType.Custom:
								return PzpjuCmhTMGyxeJrxrKrfmXEOkse();
							default:
								throw new NotImplementedException();
							}
							break;
						}
						break;
					}
					return lANoYDIhcPazVvSGpuYiTXSDNYa();
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					while (true)
					{
						int num = -873101039;
						while (true)
						{
							switch (num ^ -873101040)
							{
							case 0:
								break;
							case 1:
								switch (controllerType)
								{
								default:
									goto IL_0043;
								case ControllerType.Joystick:
									break;
								case ControllerType.Keyboard:
									return DfxlIwLBuWuWtFBhxftMdGaRCJj();
								case ControllerType.Mouse:
									return sZtWZLqHYjUEqtXtmJRKenARwmD();
								}
								goto default;
							case 3:
								if (controllerType == ControllerType.Custom)
								{
									return nzmrXSpzZSAZEfGsDTNWEvOZZFZ();
								}
								throw new NotImplementedException();
							default:
								return VFoTnANXnwCgEDNPxwUjkMtRatm();
							}
							break;
							IL_0043:
							num = -873101037;
						}
					}
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					while (true)
					{
						switch (0x69ED86B9 ^ 0x69ED86B8)
						{
						case 2:
							continue;
						case 1:
							switch (controllerType)
							{
							case ControllerType.Joystick:
								break;
							case ControllerType.Keyboard:
								return imFDrObflJqfTgimynWfUQviMHBF();
							case ControllerType.Mouse:
								return ShfuvsBAEkHcqKceqXxUBTXdPVK();
							case ControllerType.Custom:
								return PdsjWmerCLcZmaKbzvEXFBQgHfnU();
							default:
								throw new NotImplementedException();
							}
							break;
						}
						break;
					}
					return RUzEglTtSRuPMxsDAjqUNhfgudy();
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return WHGzoYmTgUBiuRdIOExZhIWjBtv();
					case ControllerType.Keyboard:
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					case ControllerType.Mouse:
						return wbBljEodPeRZUmTqWsyOvqcIJfq();
					case ControllerType.Custom:
						return gTkmHecAAMXzdlhARFhmRACqetgd();
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return xQFRakvwGKVelnEhGneYqiQJwJI(controllerId);
					case ControllerType.Keyboard:
						return DfxlIwLBuWuWtFBhxftMdGaRCJj();
					case ControllerType.Mouse:
						return xYAAcgNctBcynIdfvkvnZNhvdRz();
					case ControllerType.Custom:
						return cjXnbjaoCjutcecfYAxngLnLQpY(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					ControllerType controllerType2 = controllerType;
					int num = 2071180244;
					goto IL_000c;
					IL_000c:
					while (true)
					{
						switch (num ^ 0x7B73B3D6)
						{
						case 4:
							break;
						case 1:
							if (controllerType2 == ControllerType.Custom)
							{
								return OEbMNyymlSIkZUloResTWswogAVk(controllerId);
							}
							throw new NotImplementedException();
						case 2:
							switch (controllerType2)
							{
							default:
								goto IL_004d;
							case ControllerType.Joystick:
								break;
							case ControllerType.Keyboard:
								return imFDrObflJqfTgimynWfUQviMHBF();
							case ControllerType.Mouse:
								return gNReUqIzZHBGuPWonoYBBTuogEs();
							}
							goto default;
						case 3:
							return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
						default:
							return fDzfXkFpNYPuAbJXbNDLeUgpptfu(controllerId);
						}
						break;
						IL_004d:
						num = 2071180247;
					}
					goto IL_0007;
					IL_0007:
					num = 2071180245;
					goto IL_000c;
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					switch (controllerType)
					{
					default:
						while (true)
						{
							int num = -225639709;
							while (true)
							{
								switch (num ^ -225639711)
								{
								case 0:
									break;
								case 2:
									goto IL_0043;
								default:
									goto end_IL_0021;
								case 1:
									throw new NotImplementedException();
								}
								break;
								IL_0043:
								if (controllerType != ControllerType.Custom)
								{
									num = -225639712;
									continue;
								}
								return XgENhoDaQmQpsaFBsiWBBkPmXAqu(controllerId);
							}
							continue;
							end_IL_0021:
							break;
						}
						goto case ControllerType.Joystick;
					case ControllerType.Joystick:
						return FgoHqdIfkzXfknxJcpUjgBQZIODg(controllerId);
					case ControllerType.Keyboard:
						return DfxlIwLBuWuWtFBhxftMdGaRCJj();
					case ControllerType.Mouse:
						return sZtWZLqHYjUEqtXtmJRKenARwmD();
					}
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					while (true)
					{
						int num = -1143508693;
						while (true)
						{
							switch (num ^ -1143508695)
							{
							case 0:
								break;
							case 2:
								switch (controllerType)
								{
								default:
									goto IL_0048;
								case ControllerType.Joystick:
									break;
								case ControllerType.Keyboard:
									return imFDrObflJqfTgimynWfUQviMHBF();
								case ControllerType.Mouse:
									return ShfuvsBAEkHcqKceqXxUBTXdPVK();
								case ControllerType.Custom:
									return UvpInTYSYKIauDPkVQeRuTEwxjj(controllerId);
								}
								goto default;
							default:
								return RReAxmxPJqiAbFLAaQysjwgzhef(controllerId);
							case 3:
								throw new NotImplementedException();
							}
							break;
							IL_0048:
							num = -1143508694;
						}
					}
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					switch (controllerType)
					{
					default:
						while (true)
						{
							int num = -166634881;
							while (true)
							{
								switch (num ^ -166634882)
								{
								case 0:
									break;
								case 1:
									goto IL_0043;
								default:
									goto end_IL_0021;
								case 2:
									throw new NotImplementedException();
								}
								break;
								IL_0043:
								if (controllerType != ControllerType.Custom)
								{
									num = -166634884;
									continue;
								}
								return yNVhiypCpuvXxsNpsgeYjrmZIhq(controllerId);
							}
							continue;
							end_IL_0021:
							break;
						}
						goto case ControllerType.Joystick;
					case ControllerType.Joystick:
						return eITCcxFPJhumwWYEYuEooaSpOfc(controllerId);
					case ControllerType.Keyboard:
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					case ControllerType.Mouse:
						return wbBljEodPeRZUmTqWsyOvqcIJfq();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					OXuOkiAnBTaesdGBRnPvqvCsblOk oXuOkiAnBTaesdGBRnPvqvCsblOk = new OXuOkiAnBTaesdGBRnPvqvCsblOk(-2);
					oXuOkiAnBTaesdGBRnPvqvCsblOk.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return oXuOkiAnBTaesdGBRnPvqvCsblOk;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					mmFLDyeGQypMzCWaSfNmdnKPNEy mmFLDyeGQypMzCWaSfNmdnKPNEy2 = new mmFLDyeGQypMzCWaSfNmdnKPNEy(-2);
					mmFLDyeGQypMzCWaSfNmdnKPNEy2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return mmFLDyeGQypMzCWaSfNmdnKPNEy2;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					rRZvPhYTeMTousfytyIrYqJQFBFI rRZvPhYTeMTousfytyIrYqJQFBFI2 = new rRZvPhYTeMTousfytyIrYqJQFBFI(-2);
					rRZvPhYTeMTousfytyIrYqJQFBFI2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return rRZvPhYTeMTousfytyIrYqJQFBFI2;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					sBfFUnoQavsryDmMwTubwjVOPCb sBfFUnoQavsryDmMwTubwjVOPCb2 = new sBfFUnoQavsryDmMwTubwjVOPCb(-2);
					sBfFUnoQavsryDmMwTubwjVOPCb2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return sBfFUnoQavsryDmMwTubwjVOPCb2;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
				{
					JTRzaMtbEAQAlOryEbItdYdQSfo jTRzaMtbEAQAlOryEbItdYdQSfo = new JTRzaMtbEAQAlOryEbItdYdQSfo(-2);
					jTRzaMtbEAQAlOryEbItdYdQSfo.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return jTRzaMtbEAQAlOryEbItdYdQSfo;
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						while (true)
						{
							switch (-547766905 ^ -547766906)
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
							return gByFpjsgRfdXoflOsFeeGcqfNoUh();
						case ControllerType.Mouse:
							return DInIwIoQIJWoIKfqGeXahEyojLRc();
						case ControllerType.Custom:
							return iUtlAACevOoTRDgvZNxvlYtECIu(controllerId);
						default:
							throw new NotImplementedException();
						}
					}
					return RwnqGijpQnvWWBILjvhPALiVtqC(controllerId);
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
						return LmaAZmigKSKzeRdhfpRcpQoLEam(controllerId);
					case ControllerType.Keyboard:
						return QBcgdYdqwsLotCArKVfGzZsRCKD();
					case ControllerType.Mouse:
						return TUrfKiUifMozUtgDHYzvZgHvzIw();
					case ControllerType.Custom:
						return BKJAXvDbuTnvWelHGsnFSuKqpXEc(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return bgUdjDJPNDGoAupQkOoCRjoxjfEW(controllerId);
					case ControllerType.Keyboard:
						return gByFpjsgRfdXoflOsFeeGcqfNoUh();
					case ControllerType.Mouse:
						return oVLbDMmobZIVAhpTioxWHsvgpRw();
					case ControllerType.Custom:
						return ULagoYVtGojMdksOoNflddHjlbXS(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						while (true)
						{
							switch (-87561959 ^ -87561960)
							{
							case 0:
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
							return QBcgdYdqwsLotCArKVfGzZsRCKD();
						case ControllerType.Mouse:
							return YxKFHoPCWDOhrAoZxeOqaaLGcrXM();
						case ControllerType.Custom:
							return AtqrGKflGhvGEBYGxAVIkJNoaPsK(controllerId);
						default:
							throw new NotImplementedException();
						}
					}
					return SYgSdpphkaZENwexNJvseczkiYQ(controllerId);
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					default:
						while (true)
						{
							switch (0x70AC2C9 ^ 0x70AC2C8)
							{
							case 2:
								continue;
							case 1:
								throw new NotImplementedException();
							}
							break;
						}
						goto case ControllerType.Joystick;
					case ControllerType.Joystick:
						return WhpDbcKIUTTzCrpOKBZEvSYhKeHC(controllerId);
					case ControllerType.Keyboard:
						return new List<ControllerPollingInfo>();
					case ControllerType.Mouse:
						return IyFFzGFhfcLDjpFDRMcEectHWpgg();
					case ControllerType.Custom:
						return DAFLFoRFTmdXiAbpHJuGOlBavlVu(controllerId);
					}
				}

				private ControllerPollingInfo bxDFVyFQdbPfAQaEvGZfxbQpHqxf()
				{
					IList<Joystick> joysticks_readOnly = uzYFVAOPCugnffcKSwcZmFfGUjB.Joysticks_readOnly;
					int num = 0;
					while (num < joysticks_readOnly.Count)
					{
						while (true)
						{
							ControllerPollingInfo result = joysticks_readOnly[num].PollForFirstElement();
							if (result.success)
							{
								return result;
							}
							num++;
							int num2 = 2120225255;
							while (true)
							{
								switch (num2 ^ 0x7E6011E6)
								{
								case 0:
									num2 = 2120225252;
									continue;
								case 2:
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
					return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
				}

				private ControllerPollingInfo lANoYDIhcPazVvSGpuYiTXSDNYa()
				{
					IList<Joystick> joysticks_readOnly = uzYFVAOPCugnffcKSwcZmFfGUjB.Joysticks_readOnly;
					int num2 = default(int);
					while (true)
					{
						int num = 960009199;
						while (true)
						{
							switch (num ^ 0x393893EE)
							{
							case 2:
								break;
							case 1:
								num2 = 0;
								num = 960009198;
								continue;
							case 3:
							{
								ControllerPollingInfo result = joysticks_readOnly[num2].PollForFirstElementDown();
								if (result.success)
								{
									return result;
								}
								num2++;
								num = 960009198;
								continue;
							}
							default:
								if (num2 >= joysticks_readOnly.Count)
								{
									return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
								}
								goto case 3;
							}
							break;
						}
					}
				}

				private ControllerPollingInfo VFoTnANXnwCgEDNPxwUjkMtRatm()
				{
					IList<Joystick> joysticks_readOnly = uzYFVAOPCugnffcKSwcZmFfGUjB.Joysticks_readOnly;
					int num = 0;
					while (true)
					{
						int num2 = -1782011206;
						while (true)
						{
							switch (num2 ^ -1782011207)
							{
							case 0:
								break;
							case 3:
								num2 = -1782011208;
								continue;
							case 2:
							{
								ControllerPollingInfo result = joysticks_readOnly[num].PollForFirstButton();
								if (result.success)
								{
									return result;
								}
								num++;
								num2 = -1782011208;
								continue;
							}
							default:
								if (num >= joysticks_readOnly.Count)
								{
									return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
								}
								goto case 2;
							}
							break;
						}
					}
				}

				private ControllerPollingInfo RUzEglTtSRuPMxsDAjqUNhfgudy()
				{
					IList<Joystick> joysticks_readOnly = uzYFVAOPCugnffcKSwcZmFfGUjB.Joysticks_readOnly;
					int num = 0;
					while (num < joysticks_readOnly.Count)
					{
						while (true)
						{
							ControllerPollingInfo result = joysticks_readOnly[num].PollForFirstButtonDown();
							int num2 = 2065496809;
							while (true)
							{
								switch (num2 ^ 0x7B1CFAEA)
								{
								case 0:
									num2 = 2065496811;
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
								num2 = 2065496808;
							}
							continue;
							end_IL_0031:
							break;
						}
					}
					return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
				}

				private ControllerPollingInfo WHGzoYmTgUBiuRdIOExZhIWjBtv()
				{
					IList<Joystick> joysticks_readOnly = uzYFVAOPCugnffcKSwcZmFfGUjB.Joysticks_readOnly;
					int num = 0;
					while (num < joysticks_readOnly.Count)
					{
						while (true)
						{
							ControllerPollingInfo result = joysticks_readOnly[num].PollForFirstAxis();
							if (result.success)
							{
								return result;
							}
							num++;
							int num2 = 1529370521;
							while (true)
							{
								switch (num2 ^ 0x5B285799)
								{
								case 2:
									num2 = 1529370520;
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
					return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
				}

				private ControllerPollingInfo xQFRakvwGKVelnEhGneYqiQJwJI(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					return joystick.PollForFirstElement();
				}

				private ControllerPollingInfo fDzfXkFpNYPuAbJXbNDLeUgpptfu(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					return joystick.PollForFirstElementDown();
				}

				private ControllerPollingInfo FgoHqdIfkzXfknxJcpUjgBQZIODg(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					return joystick.PollForFirstButton();
				}

				private ControllerPollingInfo RReAxmxPJqiAbFLAaQysjwgzhef(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					return joystick.PollForFirstButtonDown();
				}

				private ControllerPollingInfo eITCcxFPJhumwWYEYuEooaSpOfc(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					return joystick.PollForFirstAxis();
				}

				private ControllerPollingInfo DfxlIwLBuWuWtFBhxftMdGaRCJj()
				{
					return ControllerHelper.Instance.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo imFDrObflJqfTgimynWfUQviMHBF()
				{
					return ControllerHelper.Instance.Keyboard.PollForFirstKeyDown();
				}

				private ControllerPollingInfo xYAAcgNctBcynIdfvkvnZNhvdRz()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo gNReUqIzZHBGuPWonoYBBTuogEs()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo sZtWZLqHYjUEqtXtmJRKenARwmD()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo ShfuvsBAEkHcqKceqXxUBTXdPVK()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo wbBljEodPeRZUmTqWsyOvqcIJfq()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstAxis();
				}

				private ControllerPollingInfo ccEcRyemdUxDKgimlVBtIDwKhKoi()
				{
					IList<CustomController> customControllers_readOnly = uzYFVAOPCugnffcKSwcZmFfGUjB.CustomControllers_readOnly;
					int num = 0;
					while (true)
					{
						int num2 = 1083458225;
						while (true)
						{
							switch (num2 ^ 0x409442B3)
							{
							case 4:
								break;
							case 0:
							{
								int num3;
								if (num >= customControllers_readOnly.Count)
								{
									num2 = 1083458224;
									num3 = num2;
								}
								else
								{
									num2 = 1083458226;
									num3 = num2;
								}
								continue;
							}
							case 1:
							{
								ControllerPollingInfo result = customControllers_readOnly[num].PollForFirstElement();
								if (result.success)
								{
									return result;
								}
								num++;
								num2 = 1083458227;
								continue;
							}
							case 2:
								num2 = 1083458227;
								continue;
							default:
								return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
							}
							break;
						}
					}
				}

				private ControllerPollingInfo PzpjuCmhTMGyxeJrxrKrfmXEOkse()
				{
					IList<CustomController> customControllers_readOnly = uzYFVAOPCugnffcKSwcZmFfGUjB.CustomControllers_readOnly;
					int num = 0;
					while (num < customControllers_readOnly.Count)
					{
						while (true)
						{
							ControllerPollingInfo result = customControllers_readOnly[num].PollForFirstElementDown();
							if (result.success)
							{
								return result;
							}
							num++;
							int num2 = 1011778361;
							while (true)
							{
								switch (num2 ^ 0x3C4E833B)
								{
								case 0:
									num2 = 1011778362;
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
					return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
				}

				private ControllerPollingInfo nzmrXSpzZSAZEfGsDTNWEvOZZFZ()
				{
					IList<CustomController> customControllers_readOnly = uzYFVAOPCugnffcKSwcZmFfGUjB.CustomControllers_readOnly;
					int num = 0;
					while (num < customControllers_readOnly.Count)
					{
						while (true)
						{
							ControllerPollingInfo result = customControllers_readOnly[num].PollForFirstButton();
							int num2;
							if (result.success)
							{
								num2 = -58302798;
							}
							else
							{
								num++;
								num2 = -58302799;
							}
							while (true)
							{
								switch (num2 ^ -58302799)
								{
								case 2:
									num2 = -58302800;
									continue;
								case 1:
									break;
								case 3:
									return result;
								default:
									goto end_IL_0031;
								}
								break;
							}
							continue;
							end_IL_0031:
							break;
						}
					}
					return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
				}

				private ControllerPollingInfo PdsjWmerCLcZmaKbzvEXFBQgHfnU()
				{
					IList<CustomController> customControllers_readOnly = uzYFVAOPCugnffcKSwcZmFfGUjB.CustomControllers_readOnly;
					int num = 0;
					ControllerPollingInfo result = default(ControllerPollingInfo);
					while (true)
					{
						int num2;
						int num3;
						if (num >= customControllers_readOnly.Count)
						{
							num2 = 1792003077;
							num3 = num2;
						}
						else
						{
							num2 = 1792003076;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x6ACFCC06)
							{
							case 4:
								num2 = 1792003076;
								continue;
							case 2:
								result = customControllers_readOnly[num].PollForFirstButtonDown();
								num2 = 1792003079;
								continue;
							case 1:
								if (result.success)
								{
									return result;
								}
								num++;
								num2 = 1792003078;
								continue;
							case 0:
								break;
							default:
								return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
							}
							break;
						}
					}
				}

				private ControllerPollingInfo gTkmHecAAMXzdlhARFhmRACqetgd()
				{
					IList<CustomController> customControllers_readOnly = uzYFVAOPCugnffcKSwcZmFfGUjB.CustomControllers_readOnly;
					int num = 0;
					while (num < customControllers_readOnly.Count)
					{
						while (true)
						{
							ControllerPollingInfo result = customControllers_readOnly[num].PollForFirstAxis();
							int num2 = 1567023155;
							while (true)
							{
								switch (num2 ^ 0x5D66E032)
								{
								case 0:
									num2 = 1567023152;
									continue;
								case 2:
									break;
								case 3:
									return result;
								case 1:
									goto IL_0056;
								default:
									goto end_IL_0035;
								}
								break;
								IL_0056:
								if (!result.success)
								{
									num++;
									num2 = 1567023158;
								}
								else
								{
									num2 = 1567023153;
								}
							}
							continue;
							end_IL_0035:
							break;
						}
					}
					return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
				}

				private ControllerPollingInfo cjXnbjaoCjutcecfYAxngLnLQpY(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					return customController.PollForFirstElement();
				}

				private ControllerPollingInfo OEbMNyymlSIkZUloResTWswogAVk(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					return customController.PollForFirstElementDown();
				}

				private ControllerPollingInfo XgENhoDaQmQpsaFBsiWBBkPmXAqu(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					return customController.PollForFirstButton();
				}

				private ControllerPollingInfo UvpInTYSYKIauDPkVQeRuTEwxjj(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					return customController.PollForFirstButtonDown();
				}

				private ControllerPollingInfo yNVhiypCpuvXxsNpsgeYjrmZIhq(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					return customController.PollForFirstAxis();
				}

				private IEnumerable<ControllerPollingInfo> QiuNTzxjhuhvqaMniCWInBWwcLht()
				{
					jQEAfcbQEDphwBNaJuaDdNYfnXGZ jQEAfcbQEDphwBNaJuaDdNYfnXGZ2 = new jQEAfcbQEDphwBNaJuaDdNYfnXGZ(-2);
					jQEAfcbQEDphwBNaJuaDdNYfnXGZ2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return jQEAfcbQEDphwBNaJuaDdNYfnXGZ2;
				}

				private IEnumerable<ControllerPollingInfo> paBcAKuGzjbtMtreSufecodKDsz()
				{
					nmKFTssbPSFbtaQdccIKsckcOdIR nmKFTssbPSFbtaQdccIKsckcOdIR2 = new nmKFTssbPSFbtaQdccIKsckcOdIR(-2);
					nmKFTssbPSFbtaQdccIKsckcOdIR2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return nmKFTssbPSFbtaQdccIKsckcOdIR2;
				}

				private IEnumerable<ControllerPollingInfo> FITSIKaECPVvULGUoGsZcVXnBmgl()
				{
					bPAlFtZIrEXlyPUXsfTldCWNraU bPAlFtZIrEXlyPUXsfTldCWNraU2 = new bPAlFtZIrEXlyPUXsfTldCWNraU(-2);
					bPAlFtZIrEXlyPUXsfTldCWNraU2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return bPAlFtZIrEXlyPUXsfTldCWNraU2;
				}

				private IEnumerable<ControllerPollingInfo> mcRnLilILRLsaMcwMbkNNPmpswx()
				{
					mNhWwkAlFqWgfLzRNLkXSpCfdoBh mNhWwkAlFqWgfLzRNLkXSpCfdoBh2 = new mNhWwkAlFqWgfLzRNLkXSpCfdoBh(-2);
					mNhWwkAlFqWgfLzRNLkXSpCfdoBh2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return mNhWwkAlFqWgfLzRNLkXSpCfdoBh2;
				}

				private IEnumerable<ControllerPollingInfo> MezVdyZhmXXrWQloTjBLuviedbP()
				{
					OwrsyfmpikNrbzpgcHfJqbbiZUd owrsyfmpikNrbzpgcHfJqbbiZUd = new OwrsyfmpikNrbzpgcHfJqbbiZUd(-2);
					owrsyfmpikNrbzpgcHfJqbbiZUd.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return owrsyfmpikNrbzpgcHfJqbbiZUd;
				}

				private IEnumerable<ControllerPollingInfo> RwnqGijpQnvWWBILjvhPALiVtqC(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> LmaAZmigKSKzeRdhfpRcpQoLEam(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> bgUdjDJPNDGoAupQkOoCRjoxjfEW(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> SYgSdpphkaZENwexNJvseczkiYQ(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> WhpDbcKIUTTzCrpOKBZEvSYhKeHC(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					while (true)
					{
						int num = -712390829;
						while (true)
						{
							switch (num ^ -712390831)
							{
							case 0:
								break;
							case 2:
								if (joystick == null)
								{
									goto IL_002d;
								}
								return joystick.PollForAllAxes();
							default:
								return new List<ControllerPollingInfo>();
							}
							break;
							IL_002d:
							num = -712390832;
						}
					}
				}

				private IEnumerable<ControllerPollingInfo> gByFpjsgRfdXoflOsFeeGcqfNoUh()
				{
					return ControllerHelper.Instance.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> QBcgdYdqwsLotCArKVfGzZsRCKD()
				{
					return ControllerHelper.Instance.Keyboard.PollForAllKeysDown();
				}

				private IEnumerable<ControllerPollingInfo> DInIwIoQIJWoIKfqGeXahEyojLRc()
				{
					return ControllerHelper.Instance.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> TUrfKiUifMozUtgDHYzvZgHvzIw()
				{
					return ControllerHelper.Instance.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> oVLbDMmobZIVAhpTioxWHsvgpRw()
				{
					return ControllerHelper.Instance.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> YxKFHoPCWDOhrAoZxeOqaaLGcrXM()
				{
					return ControllerHelper.Instance.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> IyFFzGFhfcLDjpFDRMcEectHWpgg()
				{
					return ControllerHelper.Instance.Mouse.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> vjWAnwjBmeLcpsBmrJoPchmdKSpU()
				{
					FZpgNakgdjkFvxmvoJvawmnheFz fZpgNakgdjkFvxmvoJvawmnheFz = new FZpgNakgdjkFvxmvoJvawmnheFz(-2);
					fZpgNakgdjkFvxmvoJvawmnheFz.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return fZpgNakgdjkFvxmvoJvawmnheFz;
				}

				private IEnumerable<ControllerPollingInfo> LmllFxulnUiFQPIrObrWMiDbfgQ()
				{
					EzsuiBdjyRxbjybFtrZkibZcUYF ezsuiBdjyRxbjybFtrZkibZcUYF = new EzsuiBdjyRxbjybFtrZkibZcUYF(-2);
					while (true)
					{
						int num = -1206088247;
						while (true)
						{
							switch (num ^ -1206088248)
							{
							case 2:
								break;
							case 1:
								goto IL_0026;
							default:
								return ezsuiBdjyRxbjybFtrZkibZcUYF;
							}
							break;
							IL_0026:
							ezsuiBdjyRxbjybFtrZkibZcUYF.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
							num = -1206088248;
						}
					}
				}

				private IEnumerable<ControllerPollingInfo> OGJbHsYUYfbCUMqFbCdwrwKbbiq()
				{
					xWXquvVYahvuollElDxMgXVphmZt xWXquvVYahvuollElDxMgXVphmZt2 = new xWXquvVYahvuollElDxMgXVphmZt(-2);
					xWXquvVYahvuollElDxMgXVphmZt2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return xWXquvVYahvuollElDxMgXVphmZt2;
				}

				private IEnumerable<ControllerPollingInfo> iGVymXxSErGssuaWtbmaaKEZPOrD()
				{
					rwboJjpcurZkuFLtmCovcWiUDqn rwboJjpcurZkuFLtmCovcWiUDqn2 = new rwboJjpcurZkuFLtmCovcWiUDqn(-2);
					rwboJjpcurZkuFLtmCovcWiUDqn2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return rwboJjpcurZkuFLtmCovcWiUDqn2;
				}

				private IEnumerable<ControllerPollingInfo> aZULStDmIyFDqhyxYEaMdhXpcpam()
				{
					LYsXxcxBROvkPjCtGDyZDCZayTc lYsXxcxBROvkPjCtGDyZDCZayTc = new LYsXxcxBROvkPjCtGDyZDCZayTc(-2);
					lYsXxcxBROvkPjCtGDyZDCZayTc.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return lYsXxcxBROvkPjCtGDyZDCZayTc;
				}

				private IEnumerable<ControllerPollingInfo> iUtlAACevOoTRDgvZNxvlYtECIu(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> BKJAXvDbuTnvWelHGsnFSuKqpXEc(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> ULagoYVtGojMdksOoNflddHjlbXS(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> AtqrGKflGhvGEBYGxAVIkJNoaPsK(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					while (true)
					{
						int num = 1448475229;
						while (true)
						{
							switch (num ^ 0x5655FA5C)
							{
							case 2:
								break;
							case 1:
								if (customController == null)
								{
									goto IL_002d;
								}
								return customController.PollForAllButtonsDown();
							default:
								return new List<ControllerPollingInfo>();
							}
							break;
							IL_002d:
							num = 1448475228;
						}
					}
				}

				private IEnumerable<ControllerPollingInfo> DAFLFoRFTmdXiAbpHJuGOlBavlVu(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllAxes();
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class kGXmRhOVRhRGqkJyuViYVzPNcQW : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public int scFBAQRnQdoAeLFwpCuSpDlJaTC;

					public int adfEcBSVWtaTPnDmjXBqCAVvMDe;

					public int GhjqCtnpODoJyBkGbpQobNAcMtI;

					public int HNPKOkhliHaOyHGLVloYgZMhYUIc;

					public JoystickMap zWYmdwIexVvsYthxmGAzIdVTDUs;

					public JoystickMap ghNFiTIXHSHaHWmTtbwDubYtmcCn;

					public ActionElementMap nJswQmORnQQPddKPqqkYlaPUcem;

					public ActionElementMap pXuBEdStEasvLkbhAsJIQkxZUhO;

					public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

					public bool pBwzwenOfAhpelzwewTaMxzWsmu;

					public bool CISEHjiTbKsTNVmvMiILNbuoHOx;

					public bool jZamFXLueJnaohHSddUDEapHVfS;

					public bool sjeFAfhfbSgoJgrgutyGDOyLhjR;

					public bool hExzsVYhemSqONTljvAPREjFTRw;

					public IList<Player> QlBjOtmmKilkEEPRUFCVCEfzCZIq;

					public int RxTetmRvHYExjHkFEAMPAlXHDnDZ;

					public ElementAssignmentConflictInfo QCsigUFiBONSCAGVLZpXdPjiLpif;

					public ConflictCheckingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ElementAssignmentConflictInfo> VZTBqjIbFEHxLKikQRrdBZHaJMG;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId != HbSVCfYbFQknCSDIuBJpKcqKonb || oGuYQSzFTrBqEKPsNTGqdIaaAqGg != -2)
						{
							goto IL_008a;
						}
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						kGXmRhOVRhRGqkJyuViYVzPNcQW kGXmRhOVRhRGqkJyuViYVzPNcQW2 = this;
						goto IL_00a4;
						IL_002c:
						int num;
						while (true)
						{
							switch (num ^ -1311597016)
							{
							case 3:
								num = -1311597010;
								continue;
							case 0:
								kGXmRhOVRhRGqkJyuViYVzPNcQW2.zWYmdwIexVvsYthxmGAzIdVTDUs = ghNFiTIXHSHaHWmTtbwDubYtmcCn;
								num = -1311597015;
								continue;
							case 1:
								kGXmRhOVRhRGqkJyuViYVzPNcQW2.nJswQmORnQQPddKPqqkYlaPUcem = pXuBEdStEasvLkbhAsJIQkxZUhO;
								kGXmRhOVRhRGqkJyuViYVzPNcQW2.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
								num = -1311597011;
								continue;
							case 6:
								break;
							case 4:
								goto IL_00a4;
							case 5:
								kGXmRhOVRhRGqkJyuViYVzPNcQW2.CISEHjiTbKsTNVmvMiILNbuoHOx = jZamFXLueJnaohHSddUDEapHVfS;
								kGXmRhOVRhRGqkJyuViYVzPNcQW2.sjeFAfhfbSgoJgrgutyGDOyLhjR = hExzsVYhemSqONTljvAPREjFTRw;
								num = -1311597014;
								continue;
							default:
								return kGXmRhOVRhRGqkJyuViYVzPNcQW2;
							}
							break;
						}
						goto IL_008a;
						IL_008a:
						kGXmRhOVRhRGqkJyuViYVzPNcQW2 = new kGXmRhOVRhRGqkJyuViYVzPNcQW(0);
						kGXmRhOVRhRGqkJyuViYVzPNcQW2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = -1311597012;
						goto IL_002c;
						IL_00a4:
						kGXmRhOVRhRGqkJyuViYVzPNcQW2.scFBAQRnQdoAeLFwpCuSpDlJaTC = adfEcBSVWtaTPnDmjXBqCAVvMDe;
						kGXmRhOVRhRGqkJyuViYVzPNcQW2.GhjqCtnpODoJyBkGbpQobNAcMtI = HNPKOkhliHaOyHGLVloYgZMhYUIc;
						num = -1311597016;
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
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							default:
								num = -18451185;
								goto IL_001e;
							case 2:
								goto IL_0062;
							case 0:
								goto IL_0181;
							case 1:
								break;
								IL_001e:
								while (true)
								{
									switch (num ^ -18451188)
									{
									case 0:
										break;
									case 4:
										goto IL_0062;
									case 10:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										num = -18451187;
										continue;
									case 3:
										num = -18451196;
										continue;
									case 6:
										goto IL_0085;
									case 5:
										goto end_IL_0000;
									case 12:
										QCsigUFiBONSCAGVLZpXdPjiLpif = VZTBqjIbFEHxLKikQRrdBZHaJMG.Current;
										num = -18451193;
										continue;
									case 1:
										result = true;
										num = -18451191;
										continue;
									case 2:
										VZTBqjIbFEHxLKikQRrdBZHaJMG = QlBjOtmmKilkEEPRUFCVCEfzCZIq[RxTetmRvHYExjHkFEAMPAlXHDnDZ].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Joystick, GhjqCtnpODoJyBkGbpQobNAcMtI, zWYmdwIexVvsYthxmGAzIdVTDUs, nJswQmORnQQPddKPqqkYlaPUcem, kUWZXXVHFictxLEMjETmHtCiqtXG, CISEHjiTbKsTNVmvMiILNbuoHOx).GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num = -18451195;
										continue;
									case 11:
										aimBzjfQfPyaeQqysAQJISCBhELB = QCsigUFiBONSCAGVLZpXdPjiLpif;
										num = -18451194;
										continue;
									case 9:
										if (!VZTBqjIbFEHxLKikQRrdBZHaJMG.MoveNext())
										{
											PgZdBDgkzjvNiOIyKStuQBICmIFr();
											RxTetmRvHYExjHkFEAMPAlXHDnDZ++;
											num = -18451190;
											continue;
										}
										goto case 12;
									case 7:
										goto IL_0181;
									default:
										goto end_IL_0008;
									}
									break;
									IL_0085:
									int num2;
									if (RxTetmRvHYExjHkFEAMPAlXHDnDZ >= QlBjOtmmKilkEEPRUFCVCEfzCZIq.Count)
									{
										num = -18451196;
										num2 = num;
									}
									else
									{
										num = -18451186;
										num2 = num;
									}
								}
								goto default;
								IL_0181:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								if (scFBAQRnQdoAeLFwpCuSpDlJaTC < 0 || nJswQmORnQQPddKPqqkYlaPUcem == null)
								{
									break;
								}
								QlBjOtmmKilkEEPRUFCVCEfzCZIq = (sjeFAfhfbSgoJgrgutyGDOyLhjR ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
								RxTetmRvHYExjHkFEAMPAlXHDnDZ = 0;
								num = -18451190;
								goto IL_001e;
								IL_0062:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = -18451195;
								goto IL_001e;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								PgZdBDgkzjvNiOIyKStuQBICmIFr();
							}
						}
					}

					[DebuggerHidden]
					public kGXmRhOVRhRGqkJyuViYVzPNcQW(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void PgZdBDgkzjvNiOIyKStuQBICmIFr()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (VZTBqjIbFEHxLKikQRrdBZHaJMG != null)
						{
							VZTBqjIbFEHxLKikQRrdBZHaJMG.Dispose();
						}
					}
				}

				private sealed class HSBamvGyJtHBGkjvNqmomSUthSh : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public ElementAssignmentConflictCheck mtCaFmEWqIwhWsqkQteeLYfucQfp;

					public ElementAssignmentConflictCheck zmNiuGMQtlBlHidAStqiwbddGtbg;

					public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

					public bool pBwzwenOfAhpelzwewTaMxzWsmu;

					public bool CISEHjiTbKsTNVmvMiILNbuoHOx;

					public bool jZamFXLueJnaohHSddUDEapHVfS;

					public bool sjeFAfhfbSgoJgrgutyGDOyLhjR;

					public bool hExzsVYhemSqONTljvAPREjFTRw;

					public IList<Player> EoEFoxeHyknRnLJjGxvbHkxVKNzJ;

					public int irkyaLSdWTyRjCWeWHrsUhSakE;

					public ElementAssignmentConflictInfo AXgHBfDPFfslOdqYCUnGvXsWulV;

					public ConflictCheckingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ElementAssignmentConflictInfo> nbcfXuqpkJNBetLnbdJWikhRellv;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId != HbSVCfYbFQknCSDIuBJpKcqKonb || oGuYQSzFTrBqEKPsNTGqdIaaAqGg != -2)
						{
							goto IL_004d;
						}
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						HSBamvGyJtHBGkjvNqmomSUthSh hSBamvGyJtHBGkjvNqmomSUthSh = this;
						goto IL_007a;
						IL_002c:
						int num;
						while (true)
						{
							switch (num ^ 0x3B4A470)
							{
							case 4:
								num = 62170225;
								continue;
							case 1:
								break;
							case 2:
								hSBamvGyJtHBGkjvNqmomSUthSh.CISEHjiTbKsTNVmvMiILNbuoHOx = jZamFXLueJnaohHSddUDEapHVfS;
								num = 62170224;
								continue;
							case 3:
								goto IL_007a;
							default:
								hSBamvGyJtHBGkjvNqmomSUthSh.sjeFAfhfbSgoJgrgutyGDOyLhjR = hExzsVYhemSqONTljvAPREjFTRw;
								return hSBamvGyJtHBGkjvNqmomSUthSh;
							}
							break;
						}
						goto IL_004d;
						IL_004d:
						hSBamvGyJtHBGkjvNqmomSUthSh = new HSBamvGyJtHBGkjvNqmomSUthSh(0);
						hSBamvGyJtHBGkjvNqmomSUthSh.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = 62170227;
						goto IL_002c;
						IL_007a:
						hSBamvGyJtHBGkjvNqmomSUthSh.mtCaFmEWqIwhWsqkQteeLYfucQfp = zmNiuGMQtlBlHidAStqiwbddGtbg;
						hSBamvGyJtHBGkjvNqmomSUthSh.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
						num = 62170226;
						goto IL_002c;
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
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							case 0:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num = -1188883483;
								goto IL_0023;
							case 2:
								goto IL_01b5;
								IL_0023:
								while (true)
								{
									switch (num ^ -1188883482)
									{
									case 2:
										num = -1188883481;
										continue;
									case 0:
										AXgHBfDPFfslOdqYCUnGvXsWulV = nbcfXuqpkJNBetLnbdJWikhRellv.Current;
										num = -1188883487;
										continue;
									case 9:
										nbcfXuqpkJNBetLnbdJWikhRellv = EoEFoxeHyknRnLJjGxvbHkxVKNzJ[irkyaLSdWTyRjCWeWHrsUhSakE].controllers.conflictChecking.ElementAssignmentConflicts(mtCaFmEWqIwhWsqkQteeLYfucQfp, kUWZXXVHFictxLEMjETmHtCiqtXG, CISEHjiTbKsTNVmvMiILNbuoHOx).GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num = -1188883475;
										continue;
									case 7:
										aimBzjfQfPyaeQqysAQJISCBhELB = AXgHBfDPFfslOdqYCUnGvXsWulV;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										num = -1188883486;
										continue;
									case 11:
										if (!nbcfXuqpkJNBetLnbdJWikhRellv.MoveNext())
										{
											LyZidHtYJxtCGiqUCFNgFmalqhmP();
											irkyaLSdWTyRjCWeWHrsUhSakE++;
											num = -1188883474;
											continue;
										}
										goto case 0;
									case 4:
										return true;
									case 1:
										break;
									case 8:
										goto IL_013a;
									case 10:
										num = -1188883474;
										continue;
									case 3:
										if (mtCaFmEWqIwhWsqkQteeLYfucQfp.playerId >= 0 && mtCaFmEWqIwhWsqkQteeLYfucQfp.elementAssignmentType != ElementAssignmentType.KeyboardKey)
										{
											EoEFoxeHyknRnLJjGxvbHkxVKNzJ = (sjeFAfhfbSgoJgrgutyGDOyLhjR ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
											num = -1188883478;
											continue;
										}
										goto end_IL_0008;
									case 5:
										goto IL_01b5;
									case 12:
										irkyaLSdWTyRjCWeWHrsUhSakE = 0;
										num = -1188883476;
										continue;
									default:
										goto end_IL_0008;
									}
									break;
									IL_013a:
									int num2;
									if (irkyaLSdWTyRjCWeWHrsUhSakE >= EoEFoxeHyknRnLJjGxvbHkxVKNzJ.Count)
									{
										num = -1188883488;
										num2 = num;
									}
									else
									{
										num = -1188883473;
										num2 = num;
									}
								}
								goto case 0;
								IL_01b5:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = -1188883475;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								LyZidHtYJxtCGiqUCFNgFmalqhmP();
							}
						}
					}

					[DebuggerHidden]
					public HSBamvGyJtHBGkjvNqmomSUthSh(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void LyZidHtYJxtCGiqUCFNgFmalqhmP()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (nbcfXuqpkJNBetLnbdJWikhRellv != null)
						{
							nbcfXuqpkJNBetLnbdJWikhRellv.Dispose();
						}
					}
				}

				private sealed class cJXBhVXAhmLtNECOWutHfqWyMhi : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public int scFBAQRnQdoAeLFwpCuSpDlJaTC;

					public int adfEcBSVWtaTPnDmjXBqCAVvMDe;

					public KeyboardMap VrTvUQLuaZRSIeFreBiJwKuhACt;

					public KeyboardMap IcgawqyWkLhyZVfeibEYCpRlKGJg;

					public ActionElementMap nJswQmORnQQPddKPqqkYlaPUcem;

					public ActionElementMap pXuBEdStEasvLkbhAsJIQkxZUhO;

					public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

					public bool pBwzwenOfAhpelzwewTaMxzWsmu;

					public bool CISEHjiTbKsTNVmvMiILNbuoHOx;

					public bool jZamFXLueJnaohHSddUDEapHVfS;

					public bool sjeFAfhfbSgoJgrgutyGDOyLhjR;

					public bool hExzsVYhemSqONTljvAPREjFTRw;

					public IList<Player> AXfkMVrOSlalIhfTSUQsdAJnZuR;

					public int TJSALxZQJcGjUDgmoGiodMnfTQPf;

					public ElementAssignmentConflictInfo qiVrznGRwgqjCMnEEEnUEeClrxYU;

					public ConflictCheckingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ElementAssignmentConflictInfo> wJePTCtKGSBKcrIjoHZitSxzBLw;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						cJXBhVXAhmLtNECOWutHfqWyMhi cJXBhVXAhmLtNECOWutHfqWyMhi2;
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							cJXBhVXAhmLtNECOWutHfqWyMhi2 = this;
						}
						else
						{
							while (true)
							{
								cJXBhVXAhmLtNECOWutHfqWyMhi2 = new cJXBhVXAhmLtNECOWutHfqWyMhi(0);
								int num = 1019350219;
								while (true)
								{
									switch (num ^ 0x3CC20CCB)
									{
									case 2:
										num = 1019350218;
										continue;
									case 1:
										break;
									case 0:
										cJXBhVXAhmLtNECOWutHfqWyMhi2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
										num = 1019350216;
										continue;
									default:
										goto end_IL_0049;
									}
									break;
								}
								continue;
								end_IL_0049:
								break;
							}
						}
						cJXBhVXAhmLtNECOWutHfqWyMhi2.scFBAQRnQdoAeLFwpCuSpDlJaTC = adfEcBSVWtaTPnDmjXBqCAVvMDe;
						cJXBhVXAhmLtNECOWutHfqWyMhi2.VrTvUQLuaZRSIeFreBiJwKuhACt = IcgawqyWkLhyZVfeibEYCpRlKGJg;
						cJXBhVXAhmLtNECOWutHfqWyMhi2.nJswQmORnQQPddKPqqkYlaPUcem = pXuBEdStEasvLkbhAsJIQkxZUhO;
						cJXBhVXAhmLtNECOWutHfqWyMhi2.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
						cJXBhVXAhmLtNECOWutHfqWyMhi2.CISEHjiTbKsTNVmvMiILNbuoHOx = jZamFXLueJnaohHSddUDEapHVfS;
						cJXBhVXAhmLtNECOWutHfqWyMhi2.sjeFAfhfbSgoJgrgutyGDOyLhjR = hExzsVYhemSqONTljvAPREjFTRw;
						return cJXBhVXAhmLtNECOWutHfqWyMhi2;
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
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							case 2:
								goto IL_014f;
							default:
								goto IL_016a;
							case 0:
								goto IL_0176;
								IL_014f:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = -832386727;
								goto IL_0023;
								IL_0023:
								while (true)
								{
									switch (num ^ -832386732)
									{
									case 7:
										num = -832386724;
										continue;
									case 10:
										wJePTCtKGSBKcrIjoHZitSxzBLw = AXfkMVrOSlalIhfTSUQsdAJnZuR[TJSALxZQJcGjUDgmoGiodMnfTQPf].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Keyboard, 0, VrTvUQLuaZRSIeFreBiJwKuhACt, nJswQmORnQQPddKPqqkYlaPUcem, kUWZXXVHFictxLEMjETmHtCiqtXG, CISEHjiTbKsTNVmvMiILNbuoHOx).GetEnumerator();
										num = -832386729;
										continue;
									case 11:
										qiVrznGRwgqjCMnEEEnUEeClrxYU = wJePTCtKGSBKcrIjoHZitSxzBLw.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = qiVrznGRwgqjCMnEEEnUEeClrxYU;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										result = true;
										break;
									case 13:
										goto IL_00ef;
									case 5:
										if (scFBAQRnQdoAeLFwpCuSpDlJaTC >= 0 && nJswQmORnQQPddKPqqkYlaPUcem != null)
										{
											AXfkMVrOSlalIhfTSUQsdAJnZuR = (sjeFAfhfbSgoJgrgutyGDOyLhjR ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
											num = -832386734;
											continue;
										}
										goto IL_016a;
									case 1:
										goto IL_014f;
									case 9:
										num = -832386732;
										continue;
									case 4:
										goto IL_016a;
									case 8:
										goto IL_0176;
									case 2:
										zfEUyMgpUYaTJRiDpAalaOzIIdpa();
										TJSALxZQJcGjUDgmoGiodMnfTQPf++;
										num = -832386732;
										continue;
									case 6:
										TJSALxZQJcGjUDgmoGiodMnfTQPf = 0;
										num = -832386723;
										continue;
									case 0:
										goto IL_01b6;
									case 3:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num = -832386727;
										continue;
									case 12:
										break;
									}
									break;
									IL_01b6:
									int num2;
									if (TJSALxZQJcGjUDgmoGiodMnfTQPf >= AXfkMVrOSlalIhfTSUQsdAJnZuR.Count)
									{
										num = -832386736;
										num2 = num;
									}
									else
									{
										num = -832386722;
										num2 = num;
									}
									continue;
									IL_00ef:
									int num3;
									if (!wJePTCtKGSBKcrIjoHZitSxzBLw.MoveNext())
									{
										num = -832386730;
										num3 = num;
									}
									else
									{
										num = -832386721;
										num3 = num;
									}
								}
								break;
								IL_0176:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num = -832386735;
								goto IL_0023;
								IL_016a:
								result = false;
								num = -832386728;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								zfEUyMgpUYaTJRiDpAalaOzIIdpa();
							}
						}
					}

					[DebuggerHidden]
					public cJXBhVXAhmLtNECOWutHfqWyMhi(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void zfEUyMgpUYaTJRiDpAalaOzIIdpa()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (wJePTCtKGSBKcrIjoHZitSxzBLw != null)
						{
							wJePTCtKGSBKcrIjoHZitSxzBLw.Dispose();
						}
					}
				}

				private sealed class HECJtwVkdmHHrYQgUZuvKBFAEMNB : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public ElementAssignmentConflictCheck mtCaFmEWqIwhWsqkQteeLYfucQfp;

					public ElementAssignmentConflictCheck zmNiuGMQtlBlHidAStqiwbddGtbg;

					public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

					public bool pBwzwenOfAhpelzwewTaMxzWsmu;

					public bool CISEHjiTbKsTNVmvMiILNbuoHOx;

					public bool jZamFXLueJnaohHSddUDEapHVfS;

					public bool sjeFAfhfbSgoJgrgutyGDOyLhjR;

					public bool hExzsVYhemSqONTljvAPREjFTRw;

					public IList<Player> SdQHHLCCMraXRErjlcrohUDIJeRm;

					public int LNghIvdNBIdrcKOsDEuKCKyEDtmK;

					public ElementAssignmentConflictInfo YdyvmTMwqOxBhSnHnxLCBvANrJq;

					public ConflictCheckingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ElementAssignmentConflictInfo> dhKOVViCgCfsTpDyfPceDapJlue;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							goto IL_001c;
						}
						goto IL_0071;
						IL_0071:
						HECJtwVkdmHHrYQgUZuvKBFAEMNB hECJtwVkdmHHrYQgUZuvKBFAEMNB = new HECJtwVkdmHHrYQgUZuvKBFAEMNB(0);
						hECJtwVkdmHHrYQgUZuvKBFAEMNB.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						int num = -2031104028;
						goto IL_0021;
						IL_001c:
						num = -2031104030;
						goto IL_0021;
						IL_0021:
						while (true)
						{
							switch (num ^ -2031104031)
							{
							case 4:
								break;
							case 5:
								hECJtwVkdmHHrYQgUZuvKBFAEMNB.mtCaFmEWqIwhWsqkQteeLYfucQfp = zmNiuGMQtlBlHidAStqiwbddGtbg;
								hECJtwVkdmHHrYQgUZuvKBFAEMNB.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
								hECJtwVkdmHHrYQgUZuvKBFAEMNB.CISEHjiTbKsTNVmvMiILNbuoHOx = jZamFXLueJnaohHSddUDEapHVfS;
								num = -2031104031;
								continue;
							case 2:
								goto IL_0071;
							case 0:
								hECJtwVkdmHHrYQgUZuvKBFAEMNB.sjeFAfhfbSgoJgrgutyGDOyLhjR = hExzsVYhemSqONTljvAPREjFTRw;
								num = -2031104032;
								continue;
							case 3:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
								hECJtwVkdmHHrYQgUZuvKBFAEMNB = this;
								num = -2031104028;
								continue;
							default:
								return hECJtwVkdmHHrYQgUZuvKBFAEMNB;
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
						bool result = default(bool);
						try
						{
							int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
							while (true)
							{
								IL_0007:
								int num2 = 767488671;
								while (true)
								{
									switch (num2 ^ 0x2DBEF296)
									{
									case 11:
										break;
									case 9:
										switch (num)
										{
										case 0:
											goto IL_0065;
										case 2:
											goto IL_016f;
										case 1:
											goto IL_01c7;
										}
										num2 = 767488662;
										continue;
									case 5:
										goto IL_0065;
									case 10:
										goto end_IL_000c;
									case 3:
										if (!dhKOVViCgCfsTpDyfPceDapJlue.MoveNext())
										{
											eyZkIwrWukwlfWBLHBEoTnJGLTC();
											LNghIvdNBIdrcKOsDEuKCKyEDtmK++;
											num2 = 767488663;
											continue;
										}
										goto case 2;
									case 8:
										result = true;
										num2 = 767488668;
										continue;
									case 2:
										YdyvmTMwqOxBhSnHnxLCBvANrJq = dhKOVViCgCfsTpDyfPceDapJlue.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = YdyvmTMwqOxBhSnHnxLCBvANrJq;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										num2 = 767488670;
										continue;
									case 1:
									{
										int num3;
										if (LNghIvdNBIdrcKOsDEuKCKyEDtmK >= SdQHHLCCMraXRErjlcrohUDIJeRm.Count)
										{
											num2 = 767488662;
											num3 = num2;
										}
										else
										{
											num2 = 767488657;
											num3 = num2;
										}
										continue;
									}
									case 4:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num2 = 767488661;
										continue;
									case 6:
										goto IL_016f;
									case 7:
										dhKOVViCgCfsTpDyfPceDapJlue = SdQHHLCCMraXRErjlcrohUDIJeRm[LNghIvdNBIdrcKOsDEuKCKyEDtmK].controllers.conflictChecking.ElementAssignmentConflicts(mtCaFmEWqIwhWsqkQteeLYfucQfp, kUWZXXVHFictxLEMjETmHtCiqtXG, CISEHjiTbKsTNVmvMiILNbuoHOx).GetEnumerator();
										num2 = 767488658;
										continue;
									default:
										goto IL_01c7;
										IL_016f:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num2 = 767488661;
										continue;
										IL_0065:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
										if (mtCaFmEWqIwhWsqkQteeLYfucQfp.playerId >= 0 && mtCaFmEWqIwhWsqkQteeLYfucQfp.elementAssignmentType == ElementAssignmentType.KeyboardKey)
										{
											SdQHHLCCMraXRErjlcrohUDIJeRm = (sjeFAfhfbSgoJgrgutyGDOyLhjR ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
											LNghIvdNBIdrcKOsDEuKCKyEDtmK = 0;
											num2 = 767488663;
											continue;
										}
										goto IL_01c7;
										IL_01c7:
										result = false;
										goto end_IL_000c;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								eyZkIwrWukwlfWBLHBEoTnJGLTC();
							}
						}
					}

					[DebuggerHidden]
					public HECJtwVkdmHHrYQgUZuvKBFAEMNB(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void eyZkIwrWukwlfWBLHBEoTnJGLTC()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (dhKOVViCgCfsTpDyfPceDapJlue != null)
						{
							dhKOVViCgCfsTpDyfPceDapJlue.Dispose();
						}
					}
				}

				private sealed class QSzHbjYemqvnsYEpZYCJMIMdiAu : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public int scFBAQRnQdoAeLFwpCuSpDlJaTC;

					public int adfEcBSVWtaTPnDmjXBqCAVvMDe;

					public MouseMap NpDafBXzSkEIGZyHwduUrlimFXP;

					public MouseMap raxdapodstkjiecMiXlnrtvcPQF;

					public ActionElementMap nJswQmORnQQPddKPqqkYlaPUcem;

					public ActionElementMap pXuBEdStEasvLkbhAsJIQkxZUhO;

					public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

					public bool pBwzwenOfAhpelzwewTaMxzWsmu;

					public bool CISEHjiTbKsTNVmvMiILNbuoHOx;

					public bool jZamFXLueJnaohHSddUDEapHVfS;

					public bool sjeFAfhfbSgoJgrgutyGDOyLhjR;

					public bool hExzsVYhemSqONTljvAPREjFTRw;

					public IList<Player> uosAjWpMiPsZyaOeFwIEaebjMR;

					public int YiwwFCkMaLARDnixaYgBXtneEie;

					public ElementAssignmentConflictInfo KIRJALuvnHqfbIzBmKGOOENHGiok;

					public ConflictCheckingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ElementAssignmentConflictInfo> VvEGnncGpoUEchkaadEgqMehemS;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						QSzHbjYemqvnsYEpZYCJMIMdiAu qSzHbjYemqvnsYEpZYCJMIMdiAu;
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							qSzHbjYemqvnsYEpZYCJMIMdiAu = this;
						}
						else
						{
							while (true)
							{
								qSzHbjYemqvnsYEpZYCJMIMdiAu = new QSzHbjYemqvnsYEpZYCJMIMdiAu(0);
								qSzHbjYemqvnsYEpZYCJMIMdiAu.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								int num = 1620925486;
								while (true)
								{
									switch (num ^ 0x609D5C2F)
									{
									case 0:
										num = 1620925485;
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
						qSzHbjYemqvnsYEpZYCJMIMdiAu.scFBAQRnQdoAeLFwpCuSpDlJaTC = adfEcBSVWtaTPnDmjXBqCAVvMDe;
						qSzHbjYemqvnsYEpZYCJMIMdiAu.NpDafBXzSkEIGZyHwduUrlimFXP = raxdapodstkjiecMiXlnrtvcPQF;
						qSzHbjYemqvnsYEpZYCJMIMdiAu.nJswQmORnQQPddKPqqkYlaPUcem = pXuBEdStEasvLkbhAsJIQkxZUhO;
						qSzHbjYemqvnsYEpZYCJMIMdiAu.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
						qSzHbjYemqvnsYEpZYCJMIMdiAu.CISEHjiTbKsTNVmvMiILNbuoHOx = jZamFXLueJnaohHSddUDEapHVfS;
						qSzHbjYemqvnsYEpZYCJMIMdiAu.sjeFAfhfbSgoJgrgutyGDOyLhjR = hExzsVYhemSqONTljvAPREjFTRw;
						return qSzHbjYemqvnsYEpZYCJMIMdiAu;
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
							int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
							while (true)
							{
								IL_0007:
								int num2 = 1568715534;
								while (true)
								{
									switch (num2 ^ 0x5D80B30F)
									{
									case 0:
										break;
									default:
										goto end_IL_000c;
									case 6:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										result = true;
										goto end_IL_000c;
									case 9:
										result = false;
										num2 = 1568715522;
										continue;
									case 4:
										num2 = 1568715526;
										continue;
									case 3:
										num2 = 1568715523;
										continue;
									case 8:
										KIRJALuvnHqfbIzBmKGOOENHGiok = VvEGnncGpoUEchkaadEgqMehemS.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = KIRJALuvnHqfbIzBmKGOOENHGiok;
										num2 = 1568715529;
										continue;
									case 7:
										uosAjWpMiPsZyaOeFwIEaebjMR = (sjeFAfhfbSgoJgrgutyGDOyLhjR ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
										YiwwFCkMaLARDnixaYgBXtneEie = 0;
										num2 = 1568715530;
										continue;
									case 10:
										goto IL_00dc;
									case 12:
										if (!VvEGnncGpoUEchkaadEgqMehemS.MoveNext())
										{
											VwWMoNrmoqpxQcUWLmrGezOHJXy();
											YiwwFCkMaLARDnixaYgBXtneEie++;
											num2 = 1568715530;
											continue;
										}
										goto case 8;
									case 2:
										goto IL_0118;
									case 5:
									{
										int num3;
										if (YiwwFCkMaLARDnixaYgBXtneEie < uosAjWpMiPsZyaOeFwIEaebjMR.Count)
										{
											num2 = 1568715524;
											num3 = num2;
										}
										else
										{
											num2 = 1568715526;
											num3 = num2;
										}
										continue;
									}
									case 1:
										switch (num)
										{
										case 1:
											break;
										case 2:
											goto IL_00dc;
										case 0:
											goto IL_0118;
										default:
											goto IL_0180;
										}
										goto case 9;
									case 11:
										VvEGnncGpoUEchkaadEgqMehemS = uosAjWpMiPsZyaOeFwIEaebjMR[YiwwFCkMaLARDnixaYgBXtneEie].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Mouse, 0, NpDafBXzSkEIGZyHwduUrlimFXP, nJswQmORnQQPddKPqqkYlaPUcem, kUWZXXVHFictxLEMjETmHtCiqtXG, CISEHjiTbKsTNVmvMiILNbuoHOx).GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num2 = 1568715532;
										continue;
									case 13:
										goto end_IL_000c;
										IL_0180:
										num2 = 1568715531;
										continue;
										IL_0118:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
										if (scFBAQRnQdoAeLFwpCuSpDlJaTC >= 0)
										{
											int num4;
											if (nJswQmORnQQPddKPqqkYlaPUcem == null)
											{
												num2 = 1568715526;
												num4 = num2;
											}
											else
											{
												num2 = 1568715528;
												num4 = num2;
											}
											continue;
										}
										goto case 9;
										IL_00dc:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num2 = 1568715523;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								VwWMoNrmoqpxQcUWLmrGezOHJXy();
							}
						}
					}

					[DebuggerHidden]
					public QSzHbjYemqvnsYEpZYCJMIMdiAu(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void VwWMoNrmoqpxQcUWLmrGezOHJXy()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (VvEGnncGpoUEchkaadEgqMehemS == null)
						{
							return;
						}
						while (true)
						{
							int num = -920655851;
							while (true)
							{
								switch (num ^ -920655852)
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
								VvEGnncGpoUEchkaadEgqMehemS.Dispose();
								num = -920655850;
							}
						}
					}
				}

				private sealed class jHWvGjCQvraIRWMIrIZdyqqGzji : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public ElementAssignmentConflictCheck mtCaFmEWqIwhWsqkQteeLYfucQfp;

					public ElementAssignmentConflictCheck zmNiuGMQtlBlHidAStqiwbddGtbg;

					public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

					public bool pBwzwenOfAhpelzwewTaMxzWsmu;

					public bool CISEHjiTbKsTNVmvMiILNbuoHOx;

					public bool jZamFXLueJnaohHSddUDEapHVfS;

					public bool sjeFAfhfbSgoJgrgutyGDOyLhjR;

					public bool hExzsVYhemSqONTljvAPREjFTRw;

					public IList<Player> SCzMTLKnnTIYhzCMODsPMuVGzJi;

					public int PkQGIwDXwHPUgZHWfcvXSrEMwSS;

					public ElementAssignmentConflictInfo jMMuFxzqIMxSWkJDzIBNctkLVCT;

					public ConflictCheckingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ElementAssignmentConflictInfo> GfpPsCSpDkNswjhQHgPvDwCYZmv;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							goto IL_0023;
						}
						goto IL_0056;
						IL_0028:
						int num;
						jHWvGjCQvraIRWMIrIZdyqqGzji jHWvGjCQvraIRWMIrIZdyqqGzji2 = default(jHWvGjCQvraIRWMIrIZdyqqGzji);
						while (true)
						{
							switch (num ^ -686467775)
							{
							case 0:
								break;
							case 5:
								jHWvGjCQvraIRWMIrIZdyqqGzji2 = this;
								num = -686467776;
								continue;
							case 4:
								goto IL_0056;
							case 3:
								jHWvGjCQvraIRWMIrIZdyqqGzji2.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
								jHWvGjCQvraIRWMIrIZdyqqGzji2.CISEHjiTbKsTNVmvMiILNbuoHOx = jZamFXLueJnaohHSddUDEapHVfS;
								num = -686467773;
								continue;
							case 1:
								jHWvGjCQvraIRWMIrIZdyqqGzji2.mtCaFmEWqIwhWsqkQteeLYfucQfp = zmNiuGMQtlBlHidAStqiwbddGtbg;
								num = -686467774;
								continue;
							default:
								jHWvGjCQvraIRWMIrIZdyqqGzji2.sjeFAfhfbSgoJgrgutyGDOyLhjR = hExzsVYhemSqONTljvAPREjFTRw;
								return jHWvGjCQvraIRWMIrIZdyqqGzji2;
							}
							break;
						}
						goto IL_0023;
						IL_0056:
						jHWvGjCQvraIRWMIrIZdyqqGzji2 = new jHWvGjCQvraIRWMIrIZdyqqGzji(0);
						jHWvGjCQvraIRWMIrIZdyqqGzji2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = -686467776;
						goto IL_0028;
						IL_0023:
						num = -686467772;
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
							int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
							while (true)
							{
								int num2 = 1862773267;
								while (true)
								{
									switch (num2 ^ 0x6F07AA11)
									{
									case 6:
										break;
									case 8:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num2 = 1862773269;
										continue;
									case 1:
										SCzMTLKnnTIYhzCMODsPMuVGzJi = (sjeFAfhfbSgoJgrgutyGDOyLhjR ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
										PkQGIwDXwHPUgZHWfcvXSrEMwSS = 0;
										num2 = 1862773268;
										continue;
									case 3:
										GfpPsCSpDkNswjhQHgPvDwCYZmv = SCzMTLKnnTIYhzCMODsPMuVGzJi[PkQGIwDXwHPUgZHWfcvXSrEMwSS].controllers.conflictChecking.ElementAssignmentConflicts(mtCaFmEWqIwhWsqkQteeLYfucQfp, kUWZXXVHFictxLEMjETmHtCiqtXG, CISEHjiTbKsTNVmvMiILNbuoHOx).GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num2 = 1862773269;
										continue;
									case 7:
										goto IL_00da;
									case 0:
										jMMuFxzqIMxSWkJDzIBNctkLVCT = GfpPsCSpDkNswjhQHgPvDwCYZmv.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = jMMuFxzqIMxSWkJDzIBNctkLVCT;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										return true;
									case 10:
										JLMIPPeBwepwNIFXbHCglOWPWli();
										PkQGIwDXwHPUgZHWfcvXSrEMwSS++;
										num2 = 1862773268;
										continue;
									case 11:
										if (mtCaFmEWqIwhWsqkQteeLYfucQfp.playerId >= 0)
										{
											int num5;
											if (mtCaFmEWqIwhWsqkQteeLYfucQfp.elementAssignmentType != ElementAssignmentType.KeyboardKey)
											{
												num2 = 1862773264;
												num5 = num2;
											}
											else
											{
												num2 = 1862773272;
												num5 = num2;
											}
											continue;
										}
										goto IL_01d5;
									case 2:
										switch (num)
										{
										case 2:
											break;
										case 0:
											goto IL_00da;
										default:
											goto IL_0183;
										case 1:
											goto IL_01d5;
										}
										goto case 8;
									case 5:
									{
										int num4;
										if (PkQGIwDXwHPUgZHWfcvXSrEMwSS >= SCzMTLKnnTIYhzCMODsPMuVGzJi.Count)
										{
											num2 = 1862773272;
											num4 = num2;
										}
										else
										{
											num2 = 1862773266;
											num4 = num2;
										}
										continue;
									}
									case 4:
									{
										int num3;
										if (GfpPsCSpDkNswjhQHgPvDwCYZmv.MoveNext())
										{
											num2 = 1862773265;
											num3 = num2;
										}
										else
										{
											num2 = 1862773275;
											num3 = num2;
										}
										continue;
									}
									default:
										goto IL_01d5;
										IL_01d5:
										return false;
										IL_00da:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
										num2 = 1862773274;
										continue;
										IL_0183:
										num2 = 1862773272;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								JLMIPPeBwepwNIFXbHCglOWPWli();
							}
						}
					}

					[DebuggerHidden]
					public jHWvGjCQvraIRWMIrIZdyqqGzji(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void JLMIPPeBwepwNIFXbHCglOWPWli()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (GfpPsCSpDkNswjhQHgPvDwCYZmv != null)
						{
							GfpPsCSpDkNswjhQHgPvDwCYZmv.Dispose();
						}
					}
				}

				private sealed class nxfzqClrseJffdQDRgaacOxWLSLn : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public int scFBAQRnQdoAeLFwpCuSpDlJaTC;

					public int adfEcBSVWtaTPnDmjXBqCAVvMDe;

					public int GhjqCtnpODoJyBkGbpQobNAcMtI;

					public int HNPKOkhliHaOyHGLVloYgZMhYUIc;

					public CustomControllerMap pMKKPqXxIBDxVsRAiVlwxmZCpIk;

					public CustomControllerMap UzzJgGhVfsATSDXPuukPRiSncGA;

					public ActionElementMap nJswQmORnQQPddKPqqkYlaPUcem;

					public ActionElementMap pXuBEdStEasvLkbhAsJIQkxZUhO;

					public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

					public bool pBwzwenOfAhpelzwewTaMxzWsmu;

					public bool CISEHjiTbKsTNVmvMiILNbuoHOx;

					public bool jZamFXLueJnaohHSddUDEapHVfS;

					public bool sjeFAfhfbSgoJgrgutyGDOyLhjR;

					public bool hExzsVYhemSqONTljvAPREjFTRw;

					public IList<Player> bKBkyniIVdUmCACinAklkAiNajgv;

					public int NcUXQMCVMOBssDdHeUiDfrUQINp;

					public ElementAssignmentConflictInfo NWYSQGIvmfqfOAxKemXjOmrXbib;

					public ConflictCheckingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ElementAssignmentConflictInfo> lGLMpMDRfOtrXhEGMKeJaiDnEmZ;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							goto IL_0023;
						}
						goto IL_0055;
						IL_0028:
						int num;
						nxfzqClrseJffdQDRgaacOxWLSLn nxfzqClrseJffdQDRgaacOxWLSLn2 = default(nxfzqClrseJffdQDRgaacOxWLSLn);
						while (true)
						{
							switch (num ^ -1811052804)
							{
							case 6:
								break;
							case 4:
								goto IL_0055;
							case 3:
								nxfzqClrseJffdQDRgaacOxWLSLn2.scFBAQRnQdoAeLFwpCuSpDlJaTC = adfEcBSVWtaTPnDmjXBqCAVvMDe;
								num = -1811052804;
								continue;
							case 1:
								nxfzqClrseJffdQDRgaacOxWLSLn2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								num = -1811052801;
								continue;
							case 7:
								nxfzqClrseJffdQDRgaacOxWLSLn2 = this;
								num = -1811052802;
								continue;
							case 0:
								nxfzqClrseJffdQDRgaacOxWLSLn2.GhjqCtnpODoJyBkGbpQobNAcMtI = HNPKOkhliHaOyHGLVloYgZMhYUIc;
								nxfzqClrseJffdQDRgaacOxWLSLn2.pMKKPqXxIBDxVsRAiVlwxmZCpIk = UzzJgGhVfsATSDXPuukPRiSncGA;
								nxfzqClrseJffdQDRgaacOxWLSLn2.nJswQmORnQQPddKPqqkYlaPUcem = pXuBEdStEasvLkbhAsJIQkxZUhO;
								num = -1811052807;
								continue;
							case 2:
								num = -1811052801;
								continue;
							default:
								nxfzqClrseJffdQDRgaacOxWLSLn2.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
								nxfzqClrseJffdQDRgaacOxWLSLn2.CISEHjiTbKsTNVmvMiILNbuoHOx = jZamFXLueJnaohHSddUDEapHVfS;
								nxfzqClrseJffdQDRgaacOxWLSLn2.sjeFAfhfbSgoJgrgutyGDOyLhjR = hExzsVYhemSqONTljvAPREjFTRw;
								return nxfzqClrseJffdQDRgaacOxWLSLn2;
							}
							break;
						}
						goto IL_0023;
						IL_0055:
						nxfzqClrseJffdQDRgaacOxWLSLn2 = new nxfzqClrseJffdQDRgaacOxWLSLn(0);
						num = -1811052803;
						goto IL_0028;
						IL_0023:
						num = -1811052805;
						goto IL_0028;
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
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							default:
								num = 1558938089;
								goto IL_001e;
							case 1:
								goto IL_00c4;
							case 0:
								goto IL_012c;
							case 2:
								goto IL_0179;
								IL_001e:
								while (true)
								{
									switch (num ^ 0x5CEB81E1)
									{
									case 5:
										break;
									default:
										goto end_IL_0008;
									case 8:
										num = 1558938087;
										continue;
									case 2:
										NWYSQGIvmfqfOAxKemXjOmrXbib = lGLMpMDRfOtrXhEGMKeJaiDnEmZ.Current;
										aimBzjfQfPyaeQqysAQJISCBhELB = NWYSQGIvmfqfOAxKemXjOmrXbib;
										num = 1558938081;
										continue;
									case 7:
										goto IL_0085;
									case 0:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										result = true;
										goto end_IL_0008;
									case 6:
										goto IL_00c4;
									case 9:
										lGLMpMDRfOtrXhEGMKeJaiDnEmZ = bKBkyniIVdUmCACinAklkAiNajgv[NcUXQMCVMOBssDdHeUiDfrUQINp].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Custom, GhjqCtnpODoJyBkGbpQobNAcMtI, pMKKPqXxIBDxVsRAiVlwxmZCpIk, nJswQmORnQQPddKPqqkYlaPUcem, kUWZXXVHFictxLEMjETmHtCiqtXG, CISEHjiTbKsTNVmvMiILNbuoHOx).GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num = 1558938082;
										continue;
									case 1:
										goto IL_012c;
									case 4:
										goto IL_0179;
									case 3:
										if (!lGLMpMDRfOtrXhEGMKeJaiDnEmZ.MoveNext())
										{
											mndnXSqhIFLknYjImbKoAhDORrZ();
											NcUXQMCVMOBssDdHeUiDfrUQINp++;
											num = 1558938086;
											continue;
										}
										goto case 2;
									case 10:
										goto end_IL_0008;
									}
									break;
									IL_0085:
									int num2;
									if (NcUXQMCVMOBssDdHeUiDfrUQINp < bKBkyniIVdUmCACinAklkAiNajgv.Count)
									{
										num = 1558938088;
										num2 = num;
									}
									else
									{
										num = 1558938087;
										num2 = num;
									}
								}
								goto default;
								IL_0179:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = 1558938082;
								goto IL_001e;
								IL_012c:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								if (scFBAQRnQdoAeLFwpCuSpDlJaTC >= 0 && nJswQmORnQQPddKPqqkYlaPUcem != null)
								{
									bKBkyniIVdUmCACinAklkAiNajgv = (sjeFAfhfbSgoJgrgutyGDOyLhjR ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
									NcUXQMCVMOBssDdHeUiDfrUQINp = 0;
									num = 1558938086;
									goto IL_001e;
								}
								goto IL_00c4;
								IL_00c4:
								result = false;
								num = 1558938091;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								mndnXSqhIFLknYjImbKoAhDORrZ();
							}
						}
					}

					[DebuggerHidden]
					public nxfzqClrseJffdQDRgaacOxWLSLn(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void mndnXSqhIFLknYjImbKoAhDORrZ()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (lGLMpMDRfOtrXhEGMKeJaiDnEmZ != null)
						{
							lGLMpMDRfOtrXhEGMKeJaiDnEmZ.Dispose();
						}
					}
				}

				private sealed class gpwaltSjrFfytVCiKPeIzMNcWpI : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public ElementAssignmentConflictCheck mtCaFmEWqIwhWsqkQteeLYfucQfp;

					public ElementAssignmentConflictCheck zmNiuGMQtlBlHidAStqiwbddGtbg;

					public bool kUWZXXVHFictxLEMjETmHtCiqtXG;

					public bool pBwzwenOfAhpelzwewTaMxzWsmu;

					public bool CISEHjiTbKsTNVmvMiILNbuoHOx;

					public bool jZamFXLueJnaohHSddUDEapHVfS;

					public bool sjeFAfhfbSgoJgrgutyGDOyLhjR;

					public bool hExzsVYhemSqONTljvAPREjFTRw;

					public IList<Player> slscEHfbtxZigPFTXdKRGDfKHDWN;

					public int pLNVQfOUrYHdTkfedQWxeNBHkAy;

					public ElementAssignmentConflictInfo xUDYVXEEVDbhYwrKvcoCHunlcYg;

					public ConflictCheckingHelper iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public IEnumerator<ElementAssignmentConflictInfo> tPDwIXAHnHtTeFAcSFcdcsYQWjvJ;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aimBzjfQfPyaeQqysAQJISCBhELB;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						gpwaltSjrFfytVCiKPeIzMNcWpI gpwaltSjrFfytVCiKPeIzMNcWpI2;
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							gpwaltSjrFfytVCiKPeIzMNcWpI2 = this;
							goto IL_0051;
						}
						goto IL_008f;
						IL_002c:
						int num;
						while (true)
						{
							switch (num ^ -668419562)
							{
							case 5:
								num = -668419566;
								continue;
							case 3:
								break;
							case 2:
								gpwaltSjrFfytVCiKPeIzMNcWpI2.sjeFAfhfbSgoJgrgutyGDOyLhjR = hExzsVYhemSqONTljvAPREjFTRw;
								num = -668419562;
								continue;
							case 4:
								goto IL_008f;
							case 1:
								gpwaltSjrFfytVCiKPeIzMNcWpI2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								num = -668419563;
								continue;
							default:
								return gpwaltSjrFfytVCiKPeIzMNcWpI2;
							}
							break;
						}
						goto IL_0051;
						IL_008f:
						gpwaltSjrFfytVCiKPeIzMNcWpI2 = new gpwaltSjrFfytVCiKPeIzMNcWpI(0);
						num = -668419561;
						goto IL_002c;
						IL_0051:
						gpwaltSjrFfytVCiKPeIzMNcWpI2.mtCaFmEWqIwhWsqkQteeLYfucQfp = zmNiuGMQtlBlHidAStqiwbddGtbg;
						gpwaltSjrFfytVCiKPeIzMNcWpI2.kUWZXXVHFictxLEMjETmHtCiqtXG = pBwzwenOfAhpelzwewTaMxzWsmu;
						gpwaltSjrFfytVCiKPeIzMNcWpI2.CISEHjiTbKsTNVmvMiILNbuoHOx = jZamFXLueJnaohHSddUDEapHVfS;
						num = -668419564;
						goto IL_002c;
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
							int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
							while (true)
							{
								int num2 = -1814671772;
								while (true)
								{
									switch (num2 ^ -1814671776)
									{
									case 9:
										break;
									case 8:
									{
										int num4;
										if (pLNVQfOUrYHdTkfedQWxeNBHkAy < slscEHfbtxZigPFTXdKRGDfKHDWN.Count)
										{
											num2 = -1814671766;
											num4 = num2;
										}
										else
										{
											num2 = -1814671776;
											num4 = num2;
										}
										continue;
									}
									case 10:
										tPDwIXAHnHtTeFAcSFcdcsYQWjvJ = slscEHfbtxZigPFTXdKRGDfKHDWN[pLNVQfOUrYHdTkfedQWxeNBHkAy].controllers.conflictChecking.ElementAssignmentConflicts(mtCaFmEWqIwhWsqkQteeLYfucQfp, kUWZXXVHFictxLEMjETmHtCiqtXG, CISEHjiTbKsTNVmvMiILNbuoHOx).GetEnumerator();
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num2 = -1814671771;
										continue;
									case 12:
										SgxaBPAoOZLpyYnBjNRoJadyIVgh();
										pLNVQfOUrYHdTkfedQWxeNBHkAy++;
										num2 = -1814671768;
										continue;
									case 4:
										switch (num)
										{
										case 0:
											goto IL_012a;
										case 2:
											goto IL_01c4;
										case 1:
											goto IL_01df;
										}
										num2 = -1814671769;
										continue;
									case 7:
										num2 = -1814671776;
										continue;
									case 3:
										aimBzjfQfPyaeQqysAQJISCBhELB = xUDYVXEEVDbhYwrKvcoCHunlcYg;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										return true;
									case 6:
										goto IL_012a;
									case 5:
									{
										int num3;
										if (tPDwIXAHnHtTeFAcSFcdcsYQWjvJ.MoveNext())
										{
											num2 = -1814671774;
											num3 = num2;
										}
										else
										{
											num2 = -1814671764;
											num3 = num2;
										}
										continue;
									}
									case 2:
										xUDYVXEEVDbhYwrKvcoCHunlcYg = tPDwIXAHnHtTeFAcSFcdcsYQWjvJ.Current;
										num2 = -1814671773;
										continue;
									case 1:
										goto IL_01c4;
									case 11:
										num2 = -1814671768;
										continue;
									default:
										goto IL_01df;
										IL_01c4:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										num2 = -1814671771;
										continue;
										IL_012a:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
										if (mtCaFmEWqIwhWsqkQteeLYfucQfp.playerId >= 0 && mtCaFmEWqIwhWsqkQteeLYfucQfp.elementAssignmentType != ElementAssignmentType.KeyboardKey)
										{
											slscEHfbtxZigPFTXdKRGDfKHDWN = (sjeFAfhfbSgoJgrgutyGDOyLhjR ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
											pLNVQfOUrYHdTkfedQWxeNBHkAy = 0;
											num2 = -1814671765;
											continue;
										}
										goto IL_01df;
										IL_01df:
										return false;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								SgxaBPAoOZLpyYnBjNRoJadyIVgh();
							}
						}
					}

					[DebuggerHidden]
					public gpwaltSjrFfytVCiKPeIzMNcWpI(int _003C_003E1__state)
					{
						while (true)
						{
							int num = 1642159146;
							while (true)
							{
								switch (num ^ 0x61E15C2B)
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
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
								HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
								num = 1642159147;
							}
						}
					}

					private void SgxaBPAoOZLpyYnBjNRoJadyIVgh()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (tPDwIXAHnHtTeFAcSFcdcsYQWjvJ != null)
						{
							tPDwIXAHnHtTeFAcSFcdcsYQWjvJ.Dispose();
						}
					}
				}

				private static ConflictCheckingHelper muFkkiEUnsHdAMTJRFCFrPnztKW;

				internal static ConflictCheckingHelper Instance
				{
					get
					{
						return muFkkiEUnsHdAMTJRFCFrPnztKW ?? (muFkkiEUnsHdAMTJRFCFrPnztKW = new ConflictCheckingHelper());
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
						return false;
					}
					IList<Player> list = (includeSystemPlayer ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
					int num14 = default(int);
					int count2 = default(int);
					int num16 = default(int);
					IList<KeyboardMap> maps4 = default(IList<KeyboardMap>);
					int num12 = default(int);
					IList<MouseMap> maps3 = default(IList<MouseMap>);
					Player player = default(Player);
					int num10 = default(int);
					int num5 = default(int);
					int num6 = default(int);
					int num2 = default(int);
					int count = default(int);
					IList<CustomController> customControllers = default(IList<CustomController>);
					int num7 = default(int);
					CustomController customController = default(CustomController);
					IList<CustomControllerMap> maps2 = default(IList<CustomControllerMap>);
					int num3 = default(int);
					int count3 = default(int);
					Player player4 = default(Player);
					Joystick joystick = default(Joystick);
					IList<JoystickMap> maps = default(IList<JoystickMap>);
					Player player2 = default(Player);
					int num8 = default(int);
					int num4 = default(int);
					IList<Joystick> joysticks = default(IList<Joystick>);
					int num9 = default(int);
					while (true)
					{
						int num = 440291906;
						while (true)
						{
							switch (num ^ 0x1A3E5263)
							{
							case 0:
								break;
							case 10:
							{
								int num15;
								if (num14 >= count2)
								{
									num = 440291966;
									num15 = num;
								}
								else
								{
									num = 440291949;
									num15 = num;
								}
								continue;
							}
							case 6:
							{
								Player player5 = list[num16];
								if (player5.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, maps4[num12], skipDisabledMaps, forceCheckAllCategories))
								{
									num = 440291948;
									continue;
								}
								num16++;
								num = 440291958;
								continue;
							}
							case 8:
								if (num12 >= maps4.Count)
								{
									maps3 = player.controllers.maps.GetMaps<MouseMap>(0);
									num10 = 0;
									num = 440291955;
									continue;
								}
								goto case 27;
							case 5:
								num5 = num6;
								num = 440291910;
								continue;
							case 18:
								num2 = 0;
								num = 440291967;
								continue;
							case 21:
								if (num16 >= count)
								{
									num12++;
									num = 440291947;
									continue;
								}
								goto case 6;
							case 32:
								num12 = 0;
								num = 440291947;
								continue;
							case 27:
								num16 = num6;
								num = 440291958;
								continue;
							case 19:
							{
								int num13;
								if (num5 >= count)
								{
									num = 440291951;
									num13 = num;
								}
								else
								{
									num = 440291908;
									num13 = num;
								}
								continue;
							}
							case 2:
								player = list[num2];
								num = 440291964;
								continue;
							case 16:
								if (num10 >= maps3.Count)
								{
									customControllers = player.controllers.CustomControllers;
									num7 = 0;
									num = 440291946;
									continue;
								}
								goto case 1;
							case 15:
								return true;
							case 28:
								num = 440291957;
								continue;
							case 40:
								customController = customControllers[num7];
								maps2 = player.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
								num = 440291954;
								continue;
							case 30:
								num = 440291936;
								continue;
							case 25:
								num3 = num6;
								num = 440291965;
								continue;
							case 3:
							{
								int num17;
								if (num3 >= count)
								{
									num = 440291963;
									num17 = num;
								}
								else
								{
									num = 440291956;
									num17 = num;
								}
								continue;
							}
							case 24:
								num7++;
								num = 440291946;
								continue;
							case 17:
								if (maps2 != null)
								{
									count3 = maps2.Count;
									num = 440291962;
									continue;
								}
								goto case 24;
							case 36:
								num = 440291914;
								continue;
							case 14:
								if (player4.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, joystick.id, maps[num14], skipDisabledMaps, forceCheckAllCategories))
								{
									return true;
								}
								num14++;
								num = 440291945;
								continue;
							case 29:
								num5++;
								num = 440291952;
								continue;
							case 39:
								player4 = list[num5];
								num14 = 0;
								num = 440291961;
								continue;
							case 23:
								player2 = list[num3];
								num8 = 0;
								num = 440291909;
								continue;
							case 33:
								count = list.Count;
								num = 440291953;
								continue;
							case 41:
								if (num4 >= joysticks.Count)
								{
									maps4 = player.controllers.maps.GetMaps<KeyboardMap>(0);
									num = 440291907;
									continue;
								}
								goto case 35;
							case 31:
								num6 = (forceCheckAllCategories ? num2 : 0);
								num = 440291944;
								continue;
							case 38:
							{
								int num11;
								if (num8 >= count3)
								{
									num = 440291940;
									num11 = num;
								}
								else
								{
									num = 440291913;
									num11 = num;
								}
								continue;
							}
							case 35:
								joystick = joysticks[num4];
								maps = player.controllers.maps.GetMaps<JoystickMap>(joystick.id);
								num = 440291943;
								continue;
							case 34:
								if (num9 >= count)
								{
									num10++;
									num = 440291955;
									continue;
								}
								goto case 20;
							case 37:
								num = 440291952;
								continue;
							case 12:
								num4++;
								num = 440291914;
								continue;
							case 1:
								num9 = num6;
								num = 440291905;
								continue;
							case 42:
								if (player2.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, customController.id, maps2[num8], skipDisabledMaps, forceCheckAllCategories))
								{
									return true;
								}
								num8++;
								num = 440291909;
								continue;
							case 26:
								num = 440291945;
								continue;
							case 9:
								if (num7 >= customControllers.Count)
								{
									num2++;
									num = 440291957;
									continue;
								}
								goto case 40;
							case 4:
								if (maps != null)
								{
									count2 = maps.Count;
									num = 440291942;
									continue;
								}
								goto case 12;
							case 20:
							{
								Player player3 = list[num9];
								if (player3.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, maps3[num10], skipDisabledMaps, forceCheckAllCategories))
								{
									num = 440291950;
									continue;
								}
								num9++;
								num = 440291905;
								continue;
							}
							case 11:
								joysticks = player.controllers.Joysticks;
								num4 = 0;
								num = 440291911;
								continue;
							case 7:
								num3++;
								num = 440291936;
								continue;
							case 13:
								return true;
							default:
								if (num2 >= count)
								{
									return false;
								}
								goto case 2;
							}
							break;
						}
					}
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
					if (playerId >= 0)
					{
						while (true)
						{
							int num = -1863240261;
							while (true)
							{
								switch (num ^ -1863240262)
								{
								case 0:
									break;
								case 1:
									goto IL_002f;
								case 2:
									goto end_IL_000d;
								default:
									return NyFuxfADTrTtpiMcPjOyAHMxmgJC(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								}
								break;
								IL_002f:
								if (elementMap == null)
								{
									num = -1863240264;
									continue;
								}
								switch (controllerType)
								{
								case ControllerType.Joystick:
									num = -1863240263;
									break;
								case ControllerType.Keyboard:
									return sxbXPdWcQSPtIyQNmpExihqZMkN(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								case ControllerType.Mouse:
									return sRIembgFXeKViNeDybIEmhBtegkP(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								case ControllerType.Custom:
									return VeceKxEjcOYRAQkmZSAYjURbWiu(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								default:
									throw new NotImplementedException();
								}
							}
							continue;
							end_IL_000d:
							break;
						}
					}
					return false;
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
						goto IL_0013;
					}
					int num;
					if (conflictCheck.controllerType != ControllerType.Joystick)
					{
						if (conflictCheck.controllerType != ControllerType.Keyboard)
						{
							if (conflictCheck.controllerType == ControllerType.Mouse)
							{
								return sRIembgFXeKViNeDybIEmhBtegkP(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
							}
							if (conflictCheck.controllerType != ControllerType.Custom)
							{
								throw new NotImplementedException();
							}
							num = 839553651;
						}
						else
						{
							num = 839553649;
						}
					}
					else
					{
						num = 839553650;
					}
					goto IL_0018;
					IL_0018:
					switch (num ^ 0x320A9273)
					{
					case 4:
						break;
					case 2:
						return sxbXPdWcQSPtIyQNmpExihqZMkN(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					case 1:
						return NyFuxfADTrTtpiMcPjOyAHMxmgJC(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					case 3:
						return false;
					default:
						return VeceKxEjcOYRAQkmZSAYjURbWiu(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					goto IL_0013;
					IL_0013:
					num = 839553648;
					goto IL_0018;
				}

				private bool NyFuxfADTrTtpiMcPjOyAHMxmgJC(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0)
					{
						goto IL_005c;
					}
					if (P_3 == null)
					{
						goto IL_0008;
					}
					int num;
					if (!P_6)
					{
						num = 1714427736;
						goto IL_000d;
					}
					IList<Player> list = YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly;
					goto IL_00b0;
					IL_000d:
					int num2 = default(int);
					IList<Player> list2 = default(IList<Player>);
					while (true)
					{
						switch (num ^ 0x66301759)
						{
						case 6:
							break;
						case 0:
							num2 = 0;
							num = 1714427738;
							continue;
						case 3:
							goto IL_0042;
						case 4:
							goto IL_005c;
						case 2:
							goto IL_0069;
						case 1:
							goto IL_009a;
						default:
							return false;
						}
						break;
						IL_0069:
						if (list2[num2].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
						num2++;
						num = 1714427738;
						continue;
						IL_0042:
						int num3;
						if (num2 < list2.Count)
						{
							num = 1714427739;
							num3 = num;
						}
						else
						{
							num = 1714427740;
							num3 = num;
						}
					}
					goto IL_0008;
					IL_005c:
					return false;
					IL_00b0:
					list2 = list;
					num = 1714427737;
					goto IL_000d;
					IL_009a:
					list = YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly;
					goto IL_00b0;
					IL_0008:
					num = 1714427741;
					goto IL_000d;
				}

				private bool NyFuxfADTrTtpiMcPjOyAHMxmgJC(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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
						list = (P_3 ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
						num = 0;
						num2 = 780224955;
						goto IL_0019;
					}
					goto IL_003a;
					IL_0019:
					while (true)
					{
						switch (num2 ^ 0x2E8149BB)
						{
						case 4:
							break;
						case 1:
							goto IL_003a;
						case 2:
							goto IL_0060;
						case 0:
							goto IL_0088;
						default:
							return false;
						}
						break;
						IL_0088:
						int num3;
						if (num < list.Count)
						{
							num2 = 780224953;
							num3 = num2;
						}
						else
						{
							num2 = 780224952;
							num3 = num2;
						}
						continue;
						IL_0060:
						if (list[num].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
						num++;
						num2 = 780224955;
					}
					goto IL_0014;
					IL_0014:
					num2 = 780224954;
					goto IL_0019;
					IL_003a:
					return false;
				}

				private bool sxbXPdWcQSPtIyQNmpExihqZMkN(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 >= 0)
					{
						int num2 = default(int);
						IList<Player> list = default(IList<Player>);
						while (true)
						{
							int num = 1999211915;
							while (true)
							{
								switch (num ^ 0x77298D8A)
								{
								case 0:
									break;
								case 1:
									goto IL_002e;
								case 3:
									goto IL_0038;
								case 4:
									goto end_IL_0004;
								case 2:
									goto IL_0065;
								default:
									if (num2 >= list.Count)
									{
										return false;
									}
									goto IL_0065;
								}
								break;
								IL_0065:
								if (list[num2].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4))
								{
									return true;
								}
								num2++;
								num = 1999211919;
								continue;
								IL_002e:
								if (P_2 == null)
								{
									num = 1999211918;
									continue;
								}
								IList<Player> list2;
								if (P_5)
								{
									list2 = YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly;
									goto IL_004e;
								}
								num = 1999211913;
								continue;
								IL_004e:
								list = list2;
								num2 = 0;
								num = 1999211919;
								continue;
								IL_0038:
								list2 = YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly;
								goto IL_004e;
							}
							continue;
							end_IL_0004:
							break;
						}
					}
					return false;
				}

				private bool sxbXPdWcQSPtIyQNmpExihqZMkN(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0)
					{
						goto IL_0042;
					}
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						goto IL_0014;
					}
					int num;
					if (!P_3)
					{
						num = 1319281243;
						goto IL_0019;
					}
					IList<Player> list = YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly;
					goto IL_008e;
					IL_0019:
					int num2 = default(int);
					IList<Player> list2 = default(IList<Player>);
					while (true)
					{
						switch (num ^ 0x4EA2A25F)
						{
						case 5:
							break;
						case 1:
							goto IL_0042;
						case 6:
							goto IL_004f;
						case 3:
							num = 1319281245;
							continue;
						case 4:
							goto IL_0078;
						case 0:
							return true;
						default:
							if (num2 >= list2.Count)
							{
								return false;
							}
							goto IL_004f;
						}
						break;
						IL_004f:
						if (list2[num2].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							num = 1319281247;
							continue;
						}
						num2++;
						num = 1319281245;
					}
					goto IL_0014;
					IL_0078:
					list = YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly;
					goto IL_008e;
					IL_008e:
					list2 = list;
					num2 = 0;
					num = 1319281244;
					goto IL_0019;
					IL_0042:
					return false;
					IL_0014:
					num = 1319281246;
					goto IL_0019;
				}

				private bool sRIembgFXeKViNeDybIEmhBtegkP(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
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
						list = (P_5 ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
						num = 0;
						num2 = -1672285791;
						goto IL_000c;
					}
					goto IL_0074;
					IL_000c:
					while (true)
					{
						switch (num2 ^ -1672285789)
						{
						case 3:
							break;
						case 2:
							goto IL_002d;
						case 0:
							goto IL_0047;
						case 4:
							goto IL_0074;
						default:
							return false;
						}
						break;
						IL_0047:
						if (list[num].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
						num++;
						num2 = -1672285791;
						continue;
						IL_002d:
						int num3;
						if (num < list.Count)
						{
							num2 = -1672285789;
							num3 = num2;
						}
						else
						{
							num2 = -1672285790;
							num3 = num2;
						}
					}
					goto IL_0007;
					IL_0007:
					num2 = -1672285785;
					goto IL_000c;
					IL_0074:
					return false;
				}

				private bool sRIembgFXeKViNeDybIEmhBtegkP(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0)
					{
						goto IL_003e;
					}
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						goto IL_0014;
					}
					int num;
					if (!P_3)
					{
						num = 278611905;
						goto IL_0019;
					}
					IList<Player> list = YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly;
					goto IL_0061;
					IL_0019:
					int num2 = default(int);
					IList<Player> list2 = default(IList<Player>);
					while (true)
					{
						switch (num ^ 0x109B47C2)
						{
						case 4:
							break;
						case 1:
							goto IL_003e;
						case 3:
							goto IL_004b;
						case 0:
							goto IL_0069;
						case 5:
							num2 = 0;
							num = 278611904;
							continue;
						default:
							if (num2 >= list2.Count)
							{
								return false;
							}
							goto IL_0069;
						}
						break;
						IL_0069:
						if (list2[num2].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
						num2++;
						num = 278611904;
					}
					goto IL_0014;
					IL_003e:
					return false;
					IL_0061:
					list2 = list;
					num = 278611911;
					goto IL_0019;
					IL_004b:
					list = YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly;
					goto IL_0061;
					IL_0014:
					num = 278611907;
					goto IL_0019;
				}

				private bool VeceKxEjcOYRAQkmZSAYjURbWiu(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0)
					{
						goto IL_0073;
					}
					if (P_3 == null)
					{
						goto IL_0008;
					}
					int num;
					if (!P_6)
					{
						num = 393848144;
						goto IL_000d;
					}
					IList<Player> list = YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly;
					goto IL_0096;
					IL_000d:
					int num2 = default(int);
					IList<Player> list2 = default(IList<Player>);
					while (true)
					{
						switch (num ^ 0x1779A557)
						{
						case 0:
							break;
						case 2:
							goto IL_003d;
						case 1:
							num = 393848146;
							continue;
						case 6:
							goto IL_0073;
						case 7:
							goto IL_0080;
						case 5:
							goto IL_00a1;
						case 4:
							num2 = 0;
							num = 393848150;
							continue;
						default:
							return false;
						}
						break;
						IL_00a1:
						int num3;
						if (num2 < list2.Count)
						{
							num = 393848149;
							num3 = num;
						}
						else
						{
							num = 393848148;
							num3 = num;
						}
						continue;
						IL_003d:
						if (list2[num2].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
						num2++;
						num = 393848146;
					}
					goto IL_0008;
					IL_0080:
					list = YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly;
					goto IL_0096;
					IL_0096:
					list2 = list;
					num = 393848147;
					goto IL_000d;
					IL_0073:
					return false;
					IL_0008:
					num = 393848145;
					goto IL_000d;
				}

				private bool VeceKxEjcOYRAQkmZSAYjURbWiu(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					IList<Player> list;
					int num;
					if (P_0.playerId >= 0)
					{
						if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
						{
							goto IL_001a;
						}
						if (P_3)
						{
							list = YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly;
							goto IL_008d;
						}
						num = 1165072056;
						goto IL_001f;
					}
					goto IL_00b4;
					IL_001f:
					int num2 = default(int);
					IList<Player> list2 = default(IList<Player>);
					while (true)
					{
						switch (num ^ 0x457196BA)
						{
						case 3:
							break;
						case 4:
							goto IL_0048;
						case 5:
							num = 1165072060;
							continue;
						case 2:
							goto IL_0077;
						case 6:
							goto IL_0097;
						case 1:
							goto IL_00b4;
						default:
							return false;
						}
						break;
						IL_0097:
						int num3;
						if (num2 >= list2.Count)
						{
							num = 1165072058;
							num3 = num;
						}
						else
						{
							num = 1165072062;
							num3 = num;
						}
						continue;
						IL_0048:
						if (list2[num2].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
						num2++;
						num = 1165072060;
					}
					goto IL_001a;
					IL_00b4:
					return false;
					IL_008d:
					list2 = list;
					num2 = 0;
					num = 1165072063;
					goto IL_001f;
					IL_0077:
					list = YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly;
					goto IL_008d;
					IL_001a:
					num = 1165072059;
					goto IL_001f;
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
						goto IL_000a;
					}
					int num;
					int num2;
					if (playerId < 0)
					{
						num = -22187790;
						num2 = num;
					}
					else
					{
						num = -22187791;
						num2 = num;
					}
					goto IL_000f;
					IL_000a:
					num = -22187787;
					goto IL_000f;
					IL_000f:
					while (true)
					{
						switch (num ^ -22187792)
						{
						case 0:
							break;
						case 2:
							return new List<ElementAssignmentConflictInfo>();
						case 1:
							if (elementMap != null)
							{
								switch (controllerType)
								{
								case ControllerType.Joystick:
									num = -22187789;
									break;
								case ControllerType.Keyboard:
									return bVWdjiSGMfZhKRdfwDXfGWJJssle(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								case ControllerType.Mouse:
									return KrmTdddPXiviaOBrykoGFHHWvHn(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								case ControllerType.Custom:
									num = -22187788;
									break;
								default:
									throw new NotImplementedException();
								}
							}
							else
							{
								num = -22187790;
							}
							continue;
						case 3:
							return UvfOKWFEbJnWdIbkfyQfwTUNyAq(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
						case 5:
							return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
						default:
							return fauxUnTqcoOCTubOefVVEudwnILH(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
						}
						break;
					}
					goto IL_000a;
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
						return UvfOKWFEbJnWdIbkfyQfwTUNyAq(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return bVWdjiSGMfZhKRdfwDXfGWJJssle(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return KrmTdddPXiviaOBrykoGFHHWvHn(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					int num;
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						num = -1460361663;
						goto IL_001c;
					}
					throw new NotImplementedException();
					IL_001c:
					switch (num ^ -1460361661)
					{
					case 0:
						break;
					case 1:
						return new List<ElementAssignmentConflictInfo>();
					default:
						return fauxUnTqcoOCTubOefVVEudwnILH(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					goto IL_0017;
					IL_0017:
					num = -1460361662;
					goto IL_001c;
				}

				private IEnumerable<ElementAssignmentConflictInfo> UvfOKWFEbJnWdIbkfyQfwTUNyAq(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					kGXmRhOVRhRGqkJyuViYVzPNcQW kGXmRhOVRhRGqkJyuViYVzPNcQW2 = new kGXmRhOVRhRGqkJyuViYVzPNcQW(-2);
					while (true)
					{
						int num = 550015470;
						while (true)
						{
							switch (num ^ 0x20C891EC)
							{
							case 0:
								break;
							case 2:
								goto IL_0026;
							default:
								kGXmRhOVRhRGqkJyuViYVzPNcQW2.pBwzwenOfAhpelzwewTaMxzWsmu = P_4;
								kGXmRhOVRhRGqkJyuViYVzPNcQW2.jZamFXLueJnaohHSddUDEapHVfS = P_5;
								kGXmRhOVRhRGqkJyuViYVzPNcQW2.hExzsVYhemSqONTljvAPREjFTRw = P_6;
								return kGXmRhOVRhRGqkJyuViYVzPNcQW2;
							}
							break;
							IL_0026:
							kGXmRhOVRhRGqkJyuViYVzPNcQW2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
							kGXmRhOVRhRGqkJyuViYVzPNcQW2.adfEcBSVWtaTPnDmjXBqCAVvMDe = P_0;
							kGXmRhOVRhRGqkJyuViYVzPNcQW2.HNPKOkhliHaOyHGLVloYgZMhYUIc = P_1;
							kGXmRhOVRhRGqkJyuViYVzPNcQW2.ghNFiTIXHSHaHWmTtbwDubYtmcCn = P_2;
							kGXmRhOVRhRGqkJyuViYVzPNcQW2.pXuBEdStEasvLkbhAsJIQkxZUhO = P_3;
							num = 550015469;
						}
					}
				}

				private IEnumerable<ElementAssignmentConflictInfo> UvfOKWFEbJnWdIbkfyQfwTUNyAq(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					HSBamvGyJtHBGkjvNqmomSUthSh hSBamvGyJtHBGkjvNqmomSUthSh = new HSBamvGyJtHBGkjvNqmomSUthSh(-2);
					hSBamvGyJtHBGkjvNqmomSUthSh.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					hSBamvGyJtHBGkjvNqmomSUthSh.zmNiuGMQtlBlHidAStqiwbddGtbg = P_0;
					hSBamvGyJtHBGkjvNqmomSUthSh.pBwzwenOfAhpelzwewTaMxzWsmu = P_1;
					hSBamvGyJtHBGkjvNqmomSUthSh.jZamFXLueJnaohHSddUDEapHVfS = P_2;
					hSBamvGyJtHBGkjvNqmomSUthSh.hExzsVYhemSqONTljvAPREjFTRw = P_3;
					return hSBamvGyJtHBGkjvNqmomSUthSh;
				}

				private IEnumerable<ElementAssignmentConflictInfo> bVWdjiSGMfZhKRdfwDXfGWJJssle(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					cJXBhVXAhmLtNECOWutHfqWyMhi cJXBhVXAhmLtNECOWutHfqWyMhi2 = new cJXBhVXAhmLtNECOWutHfqWyMhi(-2);
					cJXBhVXAhmLtNECOWutHfqWyMhi2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					cJXBhVXAhmLtNECOWutHfqWyMhi2.adfEcBSVWtaTPnDmjXBqCAVvMDe = P_0;
					while (true)
					{
						int num = -1622607915;
						while (true)
						{
							switch (num ^ -1622607913)
							{
							case 0:
								break;
							case 2:
								goto IL_0034;
							default:
								cJXBhVXAhmLtNECOWutHfqWyMhi2.pXuBEdStEasvLkbhAsJIQkxZUhO = P_2;
								cJXBhVXAhmLtNECOWutHfqWyMhi2.pBwzwenOfAhpelzwewTaMxzWsmu = P_3;
								cJXBhVXAhmLtNECOWutHfqWyMhi2.jZamFXLueJnaohHSddUDEapHVfS = P_4;
								cJXBhVXAhmLtNECOWutHfqWyMhi2.hExzsVYhemSqONTljvAPREjFTRw = P_5;
								return cJXBhVXAhmLtNECOWutHfqWyMhi2;
							}
							break;
							IL_0034:
							cJXBhVXAhmLtNECOWutHfqWyMhi2.IcgawqyWkLhyZVfeibEYCpRlKGJg = P_1;
							num = -1622607914;
						}
					}
				}

				private IEnumerable<ElementAssignmentConflictInfo> bVWdjiSGMfZhKRdfwDXfGWJJssle(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					HECJtwVkdmHHrYQgUZuvKBFAEMNB hECJtwVkdmHHrYQgUZuvKBFAEMNB = new HECJtwVkdmHHrYQgUZuvKBFAEMNB(-2);
					hECJtwVkdmHHrYQgUZuvKBFAEMNB.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					hECJtwVkdmHHrYQgUZuvKBFAEMNB.zmNiuGMQtlBlHidAStqiwbddGtbg = P_0;
					while (true)
					{
						int num = 591886456;
						while (true)
						{
							switch (num ^ 0x23477879)
							{
							case 2:
								break;
							case 1:
								goto IL_0034;
							default:
								hECJtwVkdmHHrYQgUZuvKBFAEMNB.hExzsVYhemSqONTljvAPREjFTRw = P_3;
								return hECJtwVkdmHHrYQgUZuvKBFAEMNB;
							}
							break;
							IL_0034:
							hECJtwVkdmHHrYQgUZuvKBFAEMNB.pBwzwenOfAhpelzwewTaMxzWsmu = P_1;
							hECJtwVkdmHHrYQgUZuvKBFAEMNB.jZamFXLueJnaohHSddUDEapHVfS = P_2;
							num = 591886457;
						}
					}
				}

				private IEnumerable<ElementAssignmentConflictInfo> KrmTdddPXiviaOBrykoGFHHWvHn(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					QSzHbjYemqvnsYEpZYCJMIMdiAu qSzHbjYemqvnsYEpZYCJMIMdiAu = new QSzHbjYemqvnsYEpZYCJMIMdiAu(-2);
					while (true)
					{
						int num = 1019932341;
						while (true)
						{
							switch (num ^ 0x3CCAEEB4)
							{
							case 3:
								break;
							case 1:
								qSzHbjYemqvnsYEpZYCJMIMdiAu.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
								qSzHbjYemqvnsYEpZYCJMIMdiAu.adfEcBSVWtaTPnDmjXBqCAVvMDe = P_0;
								qSzHbjYemqvnsYEpZYCJMIMdiAu.raxdapodstkjiecMiXlnrtvcPQF = P_1;
								num = 1019932340;
								continue;
							case 0:
								qSzHbjYemqvnsYEpZYCJMIMdiAu.pXuBEdStEasvLkbhAsJIQkxZUhO = P_2;
								num = 1019932342;
								continue;
							default:
								qSzHbjYemqvnsYEpZYCJMIMdiAu.pBwzwenOfAhpelzwewTaMxzWsmu = P_3;
								qSzHbjYemqvnsYEpZYCJMIMdiAu.jZamFXLueJnaohHSddUDEapHVfS = P_4;
								qSzHbjYemqvnsYEpZYCJMIMdiAu.hExzsVYhemSqONTljvAPREjFTRw = P_5;
								return qSzHbjYemqvnsYEpZYCJMIMdiAu;
							}
							break;
						}
					}
				}

				private IEnumerable<ElementAssignmentConflictInfo> KrmTdddPXiviaOBrykoGFHHWvHn(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					jHWvGjCQvraIRWMIrIZdyqqGzji jHWvGjCQvraIRWMIrIZdyqqGzji2 = new jHWvGjCQvraIRWMIrIZdyqqGzji(-2);
					jHWvGjCQvraIRWMIrIZdyqqGzji2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					jHWvGjCQvraIRWMIrIZdyqqGzji2.zmNiuGMQtlBlHidAStqiwbddGtbg = P_0;
					jHWvGjCQvraIRWMIrIZdyqqGzji2.pBwzwenOfAhpelzwewTaMxzWsmu = P_1;
					jHWvGjCQvraIRWMIrIZdyqqGzji2.jZamFXLueJnaohHSddUDEapHVfS = P_2;
					jHWvGjCQvraIRWMIrIZdyqqGzji2.hExzsVYhemSqONTljvAPREjFTRw = P_3;
					return jHWvGjCQvraIRWMIrIZdyqqGzji2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> fauxUnTqcoOCTubOefVVEudwnILH(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					nxfzqClrseJffdQDRgaacOxWLSLn nxfzqClrseJffdQDRgaacOxWLSLn2 = new nxfzqClrseJffdQDRgaacOxWLSLn(-2);
					while (true)
					{
						int num = 1894815444;
						while (true)
						{
							switch (num ^ 0x70F096D7)
							{
							case 2:
								break;
							case 3:
								nxfzqClrseJffdQDRgaacOxWLSLn2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
								nxfzqClrseJffdQDRgaacOxWLSLn2.adfEcBSVWtaTPnDmjXBqCAVvMDe = P_0;
								nxfzqClrseJffdQDRgaacOxWLSLn2.HNPKOkhliHaOyHGLVloYgZMhYUIc = P_1;
								nxfzqClrseJffdQDRgaacOxWLSLn2.UzzJgGhVfsATSDXPuukPRiSncGA = P_2;
								nxfzqClrseJffdQDRgaacOxWLSLn2.pXuBEdStEasvLkbhAsJIQkxZUhO = P_3;
								num = 1894815447;
								continue;
							case 0:
								nxfzqClrseJffdQDRgaacOxWLSLn2.pBwzwenOfAhpelzwewTaMxzWsmu = P_4;
								nxfzqClrseJffdQDRgaacOxWLSLn2.jZamFXLueJnaohHSddUDEapHVfS = P_5;
								num = 1894815446;
								continue;
							default:
								nxfzqClrseJffdQDRgaacOxWLSLn2.hExzsVYhemSqONTljvAPREjFTRw = P_6;
								return nxfzqClrseJffdQDRgaacOxWLSLn2;
							}
							break;
						}
					}
				}

				private IEnumerable<ElementAssignmentConflictInfo> fauxUnTqcoOCTubOefVVEudwnILH(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					gpwaltSjrFfytVCiKPeIzMNcWpI gpwaltSjrFfytVCiKPeIzMNcWpI2 = new gpwaltSjrFfytVCiKPeIzMNcWpI(-2);
					gpwaltSjrFfytVCiKPeIzMNcWpI2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					gpwaltSjrFfytVCiKPeIzMNcWpI2.zmNiuGMQtlBlHidAStqiwbddGtbg = P_0;
					gpwaltSjrFfytVCiKPeIzMNcWpI2.pBwzwenOfAhpelzwewTaMxzWsmu = P_1;
					gpwaltSjrFfytVCiKPeIzMNcWpI2.jZamFXLueJnaohHSddUDEapHVfS = P_2;
					gpwaltSjrFfytVCiKPeIzMNcWpI2.hExzsVYhemSqONTljvAPREjFTRw = P_3;
					return gpwaltSjrFfytVCiKPeIzMNcWpI2;
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
							num = 1531908853;
						}
						else
						{
							if (controllerType == ControllerType.Joystick)
							{
								return fzhTnlMzuUvPLAhILxPkChCvaHL(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
							}
							if (controllerType == ControllerType.Keyboard)
							{
								num = 1531908855;
							}
							else
							{
								if (controllerType != ControllerType.Mouse)
								{
									if (controllerType == ControllerType.Custom)
									{
										return sExJWcXPYZyRPVIoIVFXBiUTqjf(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
									}
									throw new NotImplementedException();
								}
								num = 1531908852;
							}
						}
						goto IL_000c;
					}
					goto IL_003e;
					IL_0007:
					num = 1531908854;
					goto IL_000c;
					IL_000c:
					switch (num ^ 0x5B4F12F4)
					{
					case 4:
						break;
					case 2:
						return 0;
					case 1:
						goto IL_003e;
					case 3:
						return MnsQxCBBkiIQfpMlRhEwDEnchWjE(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					default:
						return scWdmbsMfSzunfpvHAHTqWOXCEPb(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					goto IL_0007;
					IL_003e:
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
						goto IL_0007;
					}
					if (conflictCheck.playerId < 0)
					{
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return fzhTnlMzuUvPLAhILxPkChCvaHL(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					int num;
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						num = 141036041;
						goto IL_000c;
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return scWdmbsMfSzunfpvHAHTqWOXCEPb(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return sExJWcXPYZyRPVIoIVFXBiUTqjf(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
					IL_0007:
					num = 141036040;
					goto IL_000c;
					IL_000c:
					switch (num ^ 0x8680A09)
					{
					case 2:
						break;
					case 1:
						return 0;
					default:
						return MnsQxCBBkiIQfpMlRhEwDEnchWjE(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					goto IL_0007;
				}

				private int fzhTnlMzuUvPLAhILxPkChCvaHL(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num = default(int);
					int num2 = default(int);
					int num3;
					if (P_0 >= 0)
					{
						if (P_3 == null)
						{
							goto IL_0008;
						}
						list = (P_6 ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
						num = 0;
						num2 = 0;
						num3 = -750091322;
						goto IL_000d;
					}
					goto IL_0075;
					IL_000d:
					while (true)
					{
						switch (num3 ^ -750091323)
						{
						case 0:
							break;
						case 3:
							goto IL_002e;
						case 4:
							num += list[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
							num2++;
							num3 = -750091322;
							continue;
						case 2:
							goto IL_0075;
						default:
							return num;
						}
						break;
						IL_002e:
						int num4;
						if (num2 >= list.Count)
						{
							num3 = -750091324;
							num4 = num3;
						}
						else
						{
							num3 = -750091327;
							num4 = num3;
						}
					}
					goto IL_0008;
					IL_0008:
					num3 = -750091321;
					goto IL_000d;
					IL_0075:
					return 0;
				}

				private int fzhTnlMzuUvPLAhILxPkChCvaHL(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId >= 0)
					{
						int num3 = default(int);
						IList<Player> list = default(IList<Player>);
						int num2 = default(int);
						while (true)
						{
							int num = -1447327358;
							while (true)
							{
								switch (num ^ -1447327354)
								{
								case 2:
									break;
								case 4:
									goto IL_0030;
								case 0:
									goto end_IL_000a;
								case 3:
									num3 += list[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
									num2++;
									num = -1447327353;
									continue;
								default:
									if (num2 >= list.Count)
									{
										return num3;
									}
									goto case 3;
								}
								break;
								IL_0030:
								if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									num = -1447327354;
									continue;
								}
								list = (P_3 ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
								num3 = 0;
								num2 = 0;
								num = -1447327353;
							}
							continue;
							end_IL_000a:
							break;
						}
					}
					return 0;
				}

				private int MnsQxCBBkiIQfpMlRhEwDEnchWjE(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0)
					{
						goto IL_0056;
					}
					if (P_2 == null)
					{
						goto IL_0007;
					}
					int num;
					if (!P_5)
					{
						num = 385228612;
						goto IL_000c;
					}
					IList<Player> list = YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly;
					goto IL_0079;
					IL_000c:
					int num2 = default(int);
					int num3 = default(int);
					IList<Player> list2 = default(IList<Player>);
					while (true)
					{
						switch (num ^ 0x16F61F45)
						{
						case 5:
							break;
						case 3:
							num2 = 0;
							num = 385228613;
							continue;
						case 6:
							num2++;
							num = 385228613;
							continue;
						case 2:
							num3 = 0;
							num = 385228614;
							continue;
						case 4:
							goto IL_0056;
						case 1:
							goto IL_0063;
						case 7:
							num3 += list2[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
							num = 385228611;
							continue;
						default:
							if (num2 >= list2.Count)
							{
								return num3;
							}
							goto case 7;
						}
						break;
					}
					goto IL_0007;
					IL_0063:
					list = YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly;
					goto IL_0079;
					IL_0056:
					return 0;
					IL_0079:
					list2 = list;
					num = 385228615;
					goto IL_000c;
					IL_0007:
					num = 385228609;
					goto IL_000c;
				}

				private int MnsQxCBBkiIQfpMlRhEwDEnchWjE(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0)
					{
						goto IL_003e;
					}
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						goto IL_0014;
					}
					int num;
					if (!P_3)
					{
						num = 1575531121;
						goto IL_0019;
					}
					IList<Player> list = YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly;
					goto IL_0068;
					IL_0019:
					int num3 = default(int);
					IList<Player> list2 = default(IList<Player>);
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0x5DE8B271)
						{
						case 2:
							break;
						case 5:
							goto IL_003e;
						case 3:
							num = 1575531125;
							continue;
						case 0:
							goto IL_0052;
						case 1:
							num3 += list2[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
							num2++;
							num = 1575531125;
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
					goto IL_0014;
					IL_0052:
					list = YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly;
					goto IL_0068;
					IL_003e:
					return 0;
					IL_0068:
					list2 = list;
					num3 = 0;
					num2 = 0;
					num = 1575531122;
					goto IL_0019;
					IL_0014:
					num = 1575531124;
					goto IL_0019;
				}

				private int scWdmbsMfSzunfpvHAHTqWOXCEPb(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num = default(int);
					int num2 = default(int);
					int num3;
					if (P_0 >= 0)
					{
						if (P_2 == null)
						{
							goto IL_0007;
						}
						list = (P_5 ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
						num = 0;
						num2 = 0;
						num3 = -345560298;
						goto IL_000c;
					}
					goto IL_0073;
					IL_000c:
					while (true)
					{
						switch (num3 ^ -345560302)
						{
						case 3:
							break;
						case 4:
							goto IL_002d;
						case 0:
							num += list[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
							num2++;
							num3 = -345560298;
							continue;
						case 1:
							goto IL_0073;
						default:
							return num;
						}
						break;
						IL_002d:
						int num4;
						if (num2 >= list.Count)
						{
							num3 = -345560304;
							num4 = num3;
						}
						else
						{
							num3 = -345560302;
							num4 = num3;
						}
					}
					goto IL_0007;
					IL_0007:
					num3 = -345560301;
					goto IL_000c;
					IL_0073:
					return 0;
				}

				private int scWdmbsMfSzunfpvHAHTqWOXCEPb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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
						list = (P_3 ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
						num = 0;
						num2 = 1211809011;
						goto IL_0019;
					}
					goto IL_0061;
					IL_0019:
					int num3 = default(int);
					while (true)
					{
						switch (num2 ^ 0x483ABCF2)
						{
						case 5:
							break;
						case 4:
							goto IL_003e;
						case 1:
							num3 = 0;
							num2 = 1211809014;
							continue;
						case 3:
							goto IL_0061;
						case 2:
							num += list[num3].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
							num3++;
							num2 = 1211809014;
							continue;
						default:
							return num;
						}
						break;
						IL_003e:
						int num4;
						if (num3 < list.Count)
						{
							num2 = 1211809008;
							num4 = num2;
						}
						else
						{
							num2 = 1211809010;
							num4 = num2;
						}
					}
					goto IL_0014;
					IL_0014:
					num2 = 1211809009;
					goto IL_0019;
					IL_0061:
					return 0;
				}

				private int sExJWcXPYZyRPVIoIVFXBiUTqjf(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num;
					if (P_0 >= 0)
					{
						if (P_3 == null)
						{
							goto IL_0008;
						}
						list = (P_6 ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
						num = 791519814;
						goto IL_000d;
					}
					goto IL_003a;
					IL_000d:
					int num2 = default(int);
					int num3 = default(int);
					while (true)
					{
						switch (num ^ 0x2F2DA245)
						{
						case 6:
							break;
						case 7:
							goto IL_003a;
						case 5:
							num2++;
							num = 791519815;
							continue;
						case 1:
							num2 = 0;
							num = 791519809;
							continue;
						case 0:
							num3 += list[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
							num = 791519808;
							continue;
						case 4:
							num = 791519815;
							continue;
						case 3:
							num3 = 0;
							num = 791519812;
							continue;
						default:
							if (num2 >= list.Count)
							{
								return num3;
							}
							goto case 0;
						}
						break;
					}
					goto IL_0008;
					IL_0008:
					num = 791519810;
					goto IL_000d;
					IL_003a:
					return 0;
				}

				private int sExJWcXPYZyRPVIoIVFXBiUTqjf(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num;
					if (P_0.playerId >= 0)
					{
						if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
						{
							goto IL_0014;
						}
						list = (P_3 ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
						num = -2088018706;
						goto IL_0019;
					}
					goto IL_0070;
					IL_0019:
					int num3 = default(int);
					int num2 = default(int);
					while (true)
					{
						switch (num ^ -2088018710)
						{
						case 3:
							break;
						case 5:
							num3 += list[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
							num2++;
							num = -2088018709;
							continue;
						case 4:
							num3 = 0;
							num2 = 0;
							num = -2088018710;
							continue;
						case 2:
							goto IL_0070;
						case 0:
							num = -2088018709;
							continue;
						default:
							if (num2 >= list.Count)
							{
								return num3;
							}
							goto case 5;
						}
						break;
					}
					goto IL_0014;
					IL_0014:
					num = -2088018712;
					goto IL_0019;
					IL_0070:
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
						goto IL_0007;
					}
					int num;
					int num2;
					if (playerId >= 0)
					{
						num = 614099168;
						num2 = num;
					}
					else
					{
						num = 614099169;
						num2 = num;
					}
					goto IL_000c;
					IL_0007:
					num = 614099175;
					goto IL_000c;
					IL_000c:
					while (true)
					{
						switch (num ^ 0x249A68E3)
						{
						case 0:
							break;
						case 2:
							return 0;
						case 3:
							if (elementMap != null)
							{
								switch (controllerType)
								{
								case ControllerType.Joystick:
									num = 614099170;
									break;
								case ControllerType.Keyboard:
									return GGcUnNsbfuldQmfeZgTtgoDJqNu(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								case ControllerType.Mouse:
									return tDuMmhPFTvCRDdIvOOALnghcXKZl(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								case ControllerType.Custom:
									return aPCHwwkdbiQfGQGtiFjcMoNfPwy(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								default:
									throw new NotImplementedException();
								}
							}
							else
							{
								num = 614099169;
							}
							continue;
						case 4:
							return 0;
						default:
							return BRqHNkZhOFmZxWoklImPjfxFEfR(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
						}
						break;
					}
					goto IL_0007;
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
						return BRqHNkZhOFmZxWoklImPjfxFEfR(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return GGcUnNsbfuldQmfeZgTtgoDJqNu(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return tDuMmhPFTvCRDdIvOOALnghcXKZl(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return aPCHwwkdbiQfGQGtiFjcMoNfPwy(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int BRqHNkZhOFmZxWoklImPjfxFEfR(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 >= 0)
					{
						int num2 = default(int);
						IList<Player> list = default(IList<Player>);
						int num3 = default(int);
						while (true)
						{
							int num = -2112884185;
							while (true)
							{
								switch (num ^ -2112884186)
								{
								case 6:
									break;
								case 0:
									goto IL_0035;
								case 5:
									goto end_IL_0004;
								case 3:
									goto IL_005c;
								case 2:
									num2 += list[num3].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
									num3++;
									num = -2112884186;
									continue;
								case 1:
									goto IL_00ae;
								default:
									return num2;
								}
								break;
								IL_00ae:
								IList<Player> list2;
								if (P_3 != null)
								{
									if (!P_6)
									{
										num = -2112884187;
										continue;
									}
									list2 = YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly;
									goto IL_0072;
								}
								num = -2112884189;
								continue;
								IL_0035:
								int num4;
								if (num3 >= list.Count)
								{
									num = -2112884190;
									num4 = num;
								}
								else
								{
									num = -2112884188;
									num4 = num;
								}
								continue;
								IL_005c:
								list2 = YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly;
								goto IL_0072;
								IL_0072:
								list = list2;
								num2 = 0;
								num3 = 0;
								num = -2112884186;
							}
							continue;
							end_IL_0004:
							break;
						}
					}
					return 0;
				}

				private int BRqHNkZhOFmZxWoklImPjfxFEfR(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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
						list = (P_3 ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
						num = 0;
						num2 = 0;
						num3 = -38837949;
						goto IL_0019;
					}
					goto IL_0036;
					IL_0019:
					while (true)
					{
						switch (num3 ^ -38837950)
						{
						case 0:
							break;
						case 2:
							goto IL_0036;
						case 3:
							num += list[num2].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
							num2++;
							num3 = -38837949;
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
					num3 = -38837952;
					goto IL_0019;
					IL_0036:
					return 0;
				}

				private int GGcUnNsbfuldQmfeZgTtgoDJqNu(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0)
					{
						goto IL_0040;
					}
					if (P_2 == null)
					{
						goto IL_0007;
					}
					int num;
					if (!P_5)
					{
						num = 397473907;
						goto IL_000c;
					}
					IList<Player> list = YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly;
					goto IL_00c1;
					IL_000c:
					int num3 = default(int);
					int num2 = default(int);
					IList<Player> list2 = default(IList<Player>);
					while (true)
					{
						switch (num ^ 0x17B0F872)
						{
						case 5:
							break;
						case 8:
							goto IL_0040;
						case 3:
							goto IL_004d;
						case 4:
							num3++;
							num = 397473905;
							continue;
						case 0:
							num2 += list2[num3].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
							num = 397473910;
							continue;
						case 2:
							num2 = 0;
							num3 = 0;
							num = 397473908;
							continue;
						case 1:
							goto IL_00ab;
						case 6:
							num = 397473905;
							continue;
						default:
							return num2;
						}
						break;
						IL_004d:
						int num4;
						if (num3 < list2.Count)
						{
							num = 397473906;
							num4 = num;
						}
						else
						{
							num = 397473909;
							num4 = num;
						}
					}
					goto IL_0007;
					IL_0040:
					return 0;
					IL_00c1:
					list2 = list;
					num = 397473904;
					goto IL_000c;
					IL_00ab:
					list = YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly;
					goto IL_00c1;
					IL_0007:
					num = 397473914;
					goto IL_000c;
				}

				private int GGcUnNsbfuldQmfeZgTtgoDJqNu(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId >= 0)
					{
						int num3 = default(int);
						IList<Player> list = default(IList<Player>);
						int num2 = default(int);
						while (true)
						{
							int num = -1445788877;
							while (true)
							{
								switch (num ^ -1445788874)
								{
								case 4:
									break;
								case 0:
									num3 = 0;
									num = -1445788876;
									continue;
								case 7:
									num = -1445788880;
									continue;
								case 5:
									goto IL_004c;
								case 3:
									goto end_IL_000a;
								case 1:
									num3 += list[num2].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
									num2++;
									num = -1445788880;
									continue;
								case 2:
									num2 = 0;
									num = -1445788879;
									continue;
								default:
									if (num2 >= list.Count)
									{
										return num3;
									}
									goto case 1;
								}
								break;
								IL_004c:
								if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
								{
									num = -1445788875;
									continue;
								}
								list = (P_3 ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
								num = -1445788874;
							}
							continue;
							end_IL_000a:
							break;
						}
					}
					return 0;
				}

				private int tDuMmhPFTvCRDdIvOOALnghcXKZl(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
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
						list = (P_5 ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
						num = 0;
						num2 = 931718819;
						goto IL_000c;
					}
					goto IL_0031;
					IL_000c:
					int num3 = default(int);
					while (true)
					{
						switch (num2 ^ 0x3788E6A1)
						{
						case 0:
							break;
						case 3:
							goto IL_0031;
						case 1:
							num += list[num3].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
							num3++;
							num2 = 931718821;
							continue;
						case 4:
							goto IL_0083;
						case 2:
							num3 = 0;
							num2 = 931718821;
							continue;
						default:
							return num;
						}
						break;
						IL_0083:
						int num4;
						if (num3 < list.Count)
						{
							num2 = 931718816;
							num4 = num2;
						}
						else
						{
							num2 = 931718820;
							num4 = num2;
						}
					}
					goto IL_0007;
					IL_0007:
					num2 = 931718818;
					goto IL_000c;
					IL_0031:
					return 0;
				}

				private int tDuMmhPFTvCRDdIvOOALnghcXKZl(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num;
					if (P_0.playerId >= 0)
					{
						if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
						{
							goto IL_0014;
						}
						list = (P_3 ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
						num = 1670622411;
						goto IL_0019;
					}
					goto IL_0077;
					IL_0019:
					int num3 = default(int);
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0x6393ACC9)
						{
						case 5:
							break;
						case 0:
							num3 += list[num2].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
							num = 1670622410;
							continue;
						case 2:
							num3 = 0;
							num2 = 0;
							num = 1670622413;
							continue;
						case 3:
							num2++;
							num = 1670622413;
							continue;
						case 1:
							goto IL_0077;
						default:
							if (num2 >= list.Count)
							{
								return num3;
							}
							goto case 0;
						}
						break;
					}
					goto IL_0014;
					IL_0014:
					num = 1670622408;
					goto IL_0019;
					IL_0077:
					return 0;
				}

				private int aPCHwwkdbiQfGQGtiFjcMoNfPwy(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num;
					if (P_0 >= 0)
					{
						if (P_3 == null)
						{
							goto IL_0008;
						}
						list = (P_6 ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
						num = 605544640;
						goto IL_000d;
					}
					goto IL_0032;
					IL_000d:
					int num2 = default(int);
					int num3 = default(int);
					while (true)
					{
						switch (num ^ 0x2417E0C4)
						{
						case 0:
							break;
						case 5:
							goto IL_0032;
						case 4:
							num2 = 0;
							num3 = 0;
							num = 605544646;
							continue;
						case 1:
							num2 += list[num3].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
							num3++;
							num = 605544646;
							continue;
						case 2:
							goto IL_0092;
						default:
							return num2;
						}
						break;
						IL_0092:
						int num4;
						if (num3 >= list.Count)
						{
							num = 605544647;
							num4 = num;
						}
						else
						{
							num = 605544645;
							num4 = num;
						}
					}
					goto IL_0008;
					IL_0008:
					num = 605544641;
					goto IL_000d;
					IL_0032:
					return 0;
				}

				private int aPCHwwkdbiQfGQGtiFjcMoNfPwy(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId >= 0)
					{
						int num3 = default(int);
						IList<Player> list = default(IList<Player>);
						int num2 = default(int);
						while (true)
						{
							int num = 1273010367;
							while (true)
							{
								switch (num ^ 0x4BE098BB)
								{
								case 2:
									break;
								case 0:
									num3 += list[num2].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
									num2++;
									num = 1273010362;
									continue;
								case 3:
									goto end_IL_000a;
								case 4:
									goto IL_007f;
								default:
									if (num2 >= list.Count)
									{
										return num3;
									}
									goto case 0;
								}
								break;
								IL_007f:
								if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
								{
									list = (P_3 ? YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly : YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly);
									num3 = 0;
									num2 = 0;
									num = 1273010362;
								}
								else
								{
									num = 1273010360;
								}
							}
							continue;
							end_IL_000a:
							break;
						}
					}
					return 0;
				}
			}

			private static ControllerHelper muFkkiEUnsHdAMTJRFCFrPnztKW;

			public readonly PollingHelper polling = PollingHelper.Instance;

			public readonly ConflictCheckingHelper conflictChecking = ConflictCheckingHelper.Instance;

			internal static ControllerHelper Instance
			{
				get
				{
					return muFkkiEUnsHdAMTJRFCFrPnztKW ?? (muFkkiEUnsHdAMTJRFCFrPnztKW = new ControllerHelper());
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
					return uzYFVAOPCugnffcKSwcZmFfGUjB.controllerCount;
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
					return uzYFVAOPCugnffcKSwcZmFfGUjB.Controllers;
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
					return uzYFVAOPCugnffcKSwcZmFfGUjB.Mouse;
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
					return uzYFVAOPCugnffcKSwcZmFfGUjB.Keyboard;
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
							switch (0x29EBEED ^ 0x29EBEEF)
							{
							case 0:
								continue;
							case 2:
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
					return uzYFVAOPCugnffcKSwcZmFfGUjB.joystickCount;
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
					return uzYFVAOPCugnffcKSwcZmFfGUjB.Joysticks_readOnly;
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
					return uzYFVAOPCugnffcKSwcZmFfGUjB.customControllerCount;
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
					return uzYFVAOPCugnffcKSwcZmFfGUjB.CustomControllers_readOnly;
				}
			}

			private ControllerHelper()
			{
			}

			public T GetController<T>(int controllerId) where T : Controller
			{
				if (!CheckInitialized())
				{
					goto IL_000a;
				}
				Type typeFromHandle = default(Type);
				int num;
				if (controllerId >= 0)
				{
					typeFromHandle = typeof(T);
					num = 1753980223;
				}
				else
				{
					num = 1753980220;
				}
				goto IL_000f;
				IL_000a:
				num = 1753980218;
				goto IL_000f;
				IL_000f:
				T result = default(T);
				while (true)
				{
					switch (num ^ 0x688B9D3F)
					{
					case 6:
						break;
					case 5:
						result = null;
						num = 1753980219;
						continue;
					case 0:
						if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
						{
							num = 1753980222;
							continue;
						}
						if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
						{
							return uzYFVAOPCugnffcKSwcZmFfGUjB.Keyboard as T;
						}
						if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
						{
							return GetCustomController(controllerId) as T;
						}
						if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
						{
							num = 1753980221;
							continue;
						}
						throw new NotImplementedException();
					case 3:
						return null;
					case 1:
						return GetJoystick(controllerId) as T;
					case 4:
						return result;
					default:
						return uzYFVAOPCugnffcKSwcZmFfGUjB.Mouse as T;
					}
					break;
				}
				goto IL_000a;
			}

			public int GetControllerCount(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return 0;
				}
				while (true)
				{
					switch (0x3BEF4D8B ^ 0x3BEF4D8A)
					{
					case 2:
						continue;
					case 1:
						switch (controllerType)
						{
						case ControllerType.Joystick:
							break;
						case ControllerType.Keyboard:
							return 1;
						case ControllerType.Mouse:
							return 1;
						case ControllerType.Custom:
							return customControllerCount;
						default:
							throw new NotImplementedException();
						}
						break;
					}
					break;
				}
				return joystickCount;
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.lHAHnEiPErByQLPNWMxnJGMpiHF(controllerType, controllerId);
			}

			public Controller GetController(ControllerIdentifier controllerIdentifier)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.lHAHnEiPErByQLPNWMxnJGMpiHF(controllerIdentifier);
			}

			public Controller[] GetControllers(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Controller>.array;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.OPcYGIKytcTOUigOIgZYDPtgITmB(controllerType);
			}

			public string[] GetControllerNames(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.lExTCkyJjLcgbMzvInagSFvQJfL(controllerType);
			}

			public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.usWbhMCAoDVLOcTyqkZhzdUHFOJ(controller);
			}

			public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.usWbhMCAoDVLOcTyqkZhzdUHFOJ(controllerType, controllerId);
			}

			public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.XKVAinnLdbesNeZZMWrDvfgmuRnA(controllerType, controllerId, playerId);
			}

			public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
			{
				if (!CheckInitialized())
				{
					return;
				}
				while (true)
				{
					YYmRYrIJJDlFmDKErJxqlPcJEZJ.ygFXITzTeaNLUBEAOhmjfmKmRGp(controller, includeSystemPlayer);
					int num = 73882007;
					while (true)
					{
						switch (num ^ 0x4675995)
						{
						case 0:
							goto IL_0008;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_0008:
						num = 73882004;
					}
				}
			}

			public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
			{
				if (!CheckInitialized())
				{
					return;
				}
				while (true)
				{
					YYmRYrIJJDlFmDKErJxqlPcJEZJ.ygFXITzTeaNLUBEAOhmjfmKmRGp(controllerType, controllerId, includeSystemPlayer);
					int num = -1607703570;
					while (true)
					{
						switch (num ^ -1607703572)
						{
						case 0:
							goto IL_0008;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_0008:
						num = -1607703571;
					}
				}
			}

			public Joystick GetJoystick(int joystickId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.HdBPhTkbiFfgMcBErhvqAsSyrQkh(joystickId);
			}

			public Joystick[] GetJoysticks()
			{
				return uzYFVAOPCugnffcKSwcZmFfGUjB.yARKJLpVwqykAxkbtlhhKaDMntB();
			}

			public string[] GetJoystickNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.HgpEFuOTfjcrtkcfTZddAvYFekAH();
			}

			public bool IsJoystickAssigned(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.EbiGJUzmFpIMKpVjYviLAJorscq(joystick);
			}

			public bool IsJoystickAssigned(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.EbiGJUzmFpIMKpVjYviLAJorscq(joystickId);
			}

			public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.iTTDqmIjnoMNBKrjrexqulnePYg(joystickId, playerId);
			}

			public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
			{
				if (!CheckInitialized())
				{
					return;
				}
				while (true)
				{
					YYmRYrIJJDlFmDKErJxqlPcJEZJ.oTRaljLmiJFUileIsSQZOjcAriR(joystick, includeSystemPlayer);
					int num = -193131255;
					while (true)
					{
						switch (num ^ -193131255)
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
						num = -193131256;
					}
				}
			}

			public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					YYmRYrIJJDlFmDKErJxqlPcJEZJ.oTRaljLmiJFUileIsSQZOjcAriR(joystickId, includeSystemPlayer);
				}
			}

			public int GetUnityJoystickIdFromAnyButtonPress()
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!NQSAaKpVXFTtpEYlkOfJfYnAXKF)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				AlDeMuQZTTTXPcyefOlYwtDjppQ();
				int num = 0;
				int num4 = default(int);
				while (true)
				{
					int num2 = 1613840561;
					while (true)
					{
						switch (num2 ^ 0x603140B5)
						{
						case 2:
							break;
						case 4:
							num2 = 1613840566;
							continue;
						case 1:
							if (num4 >= 20)
							{
								num++;
								num2 = 1613840566;
								continue;
							}
							goto case 5;
						case 6:
							num4 = 0;
							num2 = 1613840564;
							continue;
						case 5:
							if (unityInputBuffer.KEKeyChVYbJkKjubvuWAAkuhHbFx(num, num4))
							{
								return num + 1;
							}
							num4++;
							num2 = 1613840564;
							continue;
						case 3:
						{
							int num3;
							if (num < 11)
							{
								num2 = 1613840563;
								num3 = num2;
							}
							else
							{
								num2 = 1613840565;
								num3 = num2;
							}
							continue;
						}
						default:
							return -1;
						}
						break;
					}
				}
			}

			public int GetUnityJoystickIdFromAnyButtonOrAxisPress(float axisThreshold, bool positiveAxesOnly)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				if (!NQSAaKpVXFTtpEYlkOfJfYnAXKF)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				AlDeMuQZTTTXPcyefOlYwtDjppQ();
				int num = 0;
				int num2 = 1953098485;
				goto IL_000c;
				IL_0007:
				num2 = 1953098491;
				goto IL_000c;
				IL_000c:
				int num3 = default(int);
				int num4 = default(int);
				bool flag = default(bool);
				while (true)
				{
					switch (num2 ^ 0x7469EAFF)
					{
					case 2:
						break;
					case 11:
						if (unityInputBuffer.KEKeyChVYbJkKjubvuWAAkuhHbFx(num, num3))
						{
							return num + 1;
						}
						num3++;
						num2 = 1953098488;
						continue;
					case 8:
					{
						int num5;
						if (num4 >= 29)
						{
							num2 = 1953098490;
							num5 = num2;
						}
						else
						{
							num2 = 1953098495;
							num5 = num2;
						}
						continue;
					}
					case 4:
						return -1;
					case 9:
						num2 = 1953098487;
						continue;
					case 1:
						if (flag)
						{
							return num + 1;
						}
						num4++;
						num2 = 1953098487;
						continue;
					case 0:
						flag = unityInputBuffer.qsyAmKaLYrBwwwdDBRIIiufnMhy(num, num4, positiveAxesOnly);
						num2 = 1953098494;
						continue;
					case 3:
						num3 = 0;
						num2 = 1953098488;
						continue;
					case 10:
						num2 = 1953098489;
						continue;
					case 7:
						if (num3 >= 20)
						{
							num4 = 0;
							num2 = 1953098486;
							continue;
						}
						goto case 11;
					case 5:
						num++;
						num2 = 1953098489;
						continue;
					default:
						if (num >= 11)
						{
							return -1;
						}
						goto case 3;
					}
					break;
				}
				goto IL_0007;
			}

			public void SetUnityJoystickId(int joystickId, int unityJoystickId)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				goto IL_0039;
				IL_0007:
				int num = 1216285496;
				goto IL_000c;
				IL_000c:
				while (true)
				{
					switch (num ^ 0x487F0B39)
					{
					case 5:
						break;
					default:
						return;
					case 1:
						return;
					case 0:
						goto IL_0039;
					case 4:
						jdHrzjKbbHpmRevALLCPhhMcYEo.SetUnityJoystickId(joystickId, unityJoystickId);
						num = 1216285499;
						continue;
					case 3:
						Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
						return;
					case 2:
						return;
					}
					break;
				}
				goto IL_0007;
				IL_0039:
				int num2;
				if (!NQSAaKpVXFTtpEYlkOfJfYnAXKF)
				{
					num = 1216285498;
					num2 = num;
				}
				else
				{
					num = 1216285501;
					num2 = num;
				}
				goto IL_000c;
			}

			public bool SetUnityJoystickIdFromAnyButtonPress(int joystickId)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				int unityJoystickIdFromAnyButtonPress = GetUnityJoystickIdFromAnyButtonPress();
				int num = 1072592370;
				goto IL_000c;
				IL_000c:
				while (true)
				{
					switch (num ^ 0x3FEE75F1)
					{
					case 0:
						break;
					case 1:
						return false;
					case 3:
						if (unityJoystickIdFromAnyButtonPress < 1)
						{
							goto IL_003d;
						}
						SetUnityJoystickId(joystickId, unityJoystickIdFromAnyButtonPress);
						return true;
					default:
						return false;
					}
					break;
					IL_003d:
					num = 1072592371;
				}
				goto IL_0007;
				IL_0007:
				num = 1072592368;
				goto IL_000c;
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
				return uzYFVAOPCugnffcKSwcZmFfGUjB.dOxDsRbYgwssswpHNBlxDmcEQwpQ(customControllerId);
			}

			public CustomController[] GetCustomControllers()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.array;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.EbYFOTvFKCuoEvFYAWZtKrYvFBq();
			}

			public string[] GetCustomControllerNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.QWKSlIFhfqeVPszZQFaCinOHgNd();
			}

			public bool IsCustomControllerAssigned(CustomController customController)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.HrGncikfxNdXGcsrqTNgBpkPuam(customController);
			}

			public bool IsCustomControllerAssigned(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.HrGncikfxNdXGcsrqTNgBpkPuam(customControllerId);
			}

			public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.IgozmIHOJVFvChnNkzZpsBlMHfLM(customControllerId, playerId);
			}

			public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					YYmRYrIJJDlFmDKErJxqlPcJEZJ.fiGrFWWKIXnogWJRBqKoSYJAwjJ(customController, includeSystemPlayer);
				}
			}

			public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
			{
				if (!CheckInitialized())
				{
					return;
				}
				while (true)
				{
					YYmRYrIJJDlFmDKErJxqlPcJEZJ.fiGrFWWKIXnogWJRBqKoSYJAwjJ(customControllerId, includeSystemPlayer);
					int num = 2145849910;
					while (true)
					{
						switch (num ^ 0x7FE71234)
						{
						case 0:
							goto IL_0008;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_0008:
						num = 2145849909;
					}
				}
			}

			public CustomController CreateCustomController(int sourceControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.CsSqgDydbucgPfMxmGgEHFxjOsCu(sourceControllerId);
			}

			public CustomController CreateCustomController(int sourceControllerId, string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomController customController = uzYFVAOPCugnffcKSwcZmFfGUjB.CsSqgDydbucgPfMxmGgEHFxjOsCu(sourceControllerId);
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
					return false;
				}
				if (customController == null)
				{
					return false;
				}
				RemoveCustomControllerFromAllPlayers(customController);
				return uzYFVAOPCugnffcKSwcZmFfGUjB.EVnpvZIrAcNODdZQaLMBXPDzApq(customController);
			}

			public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.HlhFVHUxIasHZyxbsYPjOGYQVyz(sourceId);
			}

			public CustomController GetFirstCustomControllerWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.KMbUIhdqGaPqbHDWNtKCkLsREzi(tag);
			}

			public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.BZdtHfYSFNaqjdiUuvmROjStEJNb(sourceId);
			}

			public IEnumerable<CustomController> CustomControllersWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.xqEqxbfLSxeLCMGiZbUzrwUOwzb(tag);
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.BtGqVUfmhuZbsgOJoXXlpMKwJNJ<TInterface>();
			}

			public Controller GetLastActiveController()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.MnUtAvdYVqUUxTqmFSTMVJhWqFA();
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.MnUtAvdYVqUUxTqmFSTMVJhWqFA(controllerType);
			}

			public T GetLastActiveController<T>() where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.MnUtAvdYVqUUxTqmFSTMVJhWqFA<T>();
			}

			public ControllerType GetLastActiveControllerType()
			{
				if (!CheckInitialized())
				{
					return ControllerType.Keyboard;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.CitapCgPRsgWFCRtIDVdDbmeisDk();
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					uzYFVAOPCugnffcKSwcZmFfGUjB.EuDNOKQQzIdCcFEiVwCTXwPAkqU(callback);
				}
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				goto IL_0031;
				IL_0007:
				int num = -1391459990;
				goto IL_000c;
				IL_000c:
				switch (num ^ -1391459992)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					return;
				case 1:
					goto IL_0031;
				case 3:
					return;
				}
				goto IL_0007;
				IL_0031:
				uzYFVAOPCugnffcKSwcZmFfGUjB.EuDNOKQQzIdCcFEiVwCTXwPAkqU(callback, controllerType);
				num = -1391459989;
				goto IL_000c;
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (!CheckInitialized())
				{
					while (true)
					{
						switch (-519694471 ^ -519694472)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				uzYFVAOPCugnffcKSwcZmFfGUjB.QOkoyZqchKBZNfwdRGOYQFntOczh(callback);
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					while (true)
					{
						switch (-44428469 ^ -44428471)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				uzYFVAOPCugnffcKSwcZmFfGUjB.tbUwrCYKXMkMGCcKKARjHgyGEBp(callback, controllerType);
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (!CheckInitialized())
				{
					while (true)
					{
						switch (-501985884 ^ -501985883)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				uzYFVAOPCugnffcKSwcZmFfGUjB.bUeEdQqqYxnZwxcDRoowfcoQXVW();
			}

			public bool GetAnyButton()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.wxwAjVCMxfwnKDPztUMmjYjdLJw();
			}

			public bool GetAnyButton(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.wxwAjVCMxfwnKDPztUMmjYjdLJw(controllerType);
			}

			public bool GetAnyButtonDown()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.glxcPusUUKbgfOQXBoYoVafYsPV();
			}

			public bool GetAnyButtonDown(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.glxcPusUUKbgfOQXBoYoVafYsPV(controllerType);
			}

			public bool GetAnyButtonUp()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.WbmqKuYbixTcQIAXJSPPyYMnVTN();
			}

			public bool GetAnyButtonUp(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.WbmqKuYbixTcQIAXJSPPyYMnVTN(controllerType);
			}

			public bool GetAnyButtonChanged()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.HiefIrhLjQzJmIvyVCCsUeCbEcBX();
			}

			public bool GetAnyButtonChanged(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.HiefIrhLjQzJmIvyVCCsUeCbEcBX(controllerType);
			}

			public bool GetAnyButtonPrev()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.SQglktDadlKAIELzKYKROpimzpC();
			}

			public bool GetAnyButtonPrev(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.SQglktDadlKAIELzKYKROpimzpC(controllerType);
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
					num = -1590115888;
					goto IL_000c;
				}
				if (IsJoystickAssigned(joystick))
				{
					return true;
				}
				YYmRYrIJJDlFmDKErJxqlPcJEZJ.txmhENmkzPovHzbmahTnZKEIihQ(joystick);
				return IsJoystickAssigned(joystick);
				IL_000c:
				switch (num ^ -1590115888)
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
				num = -1590115887;
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
					int num3 = 1422206922;
					while (true)
					{
						switch (num3 ^ 0x54C527CA)
						{
						case 3:
							num3 = 1422206923;
							continue;
						case 1:
							break;
						case 2:
							AutoAssignJoystick(joysticks[num2]);
							num2++;
							num3 = 1422206922;
							continue;
						default:
							if (num2 >= num)
							{
								return;
							}
							goto case 2;
						}
						break;
					}
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class MappingHelper : CodeHelper
		{
			private static MappingHelper muFkkiEUnsHdAMTJRFCFrPnztKW;

			internal static MappingHelper Instance
			{
				get
				{
					return muFkkiEUnsHdAMTJRFCFrPnztKW ?? (muFkkiEUnsHdAMTJRFCFrPnztKW = new MappingHelper());
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.MapCategories_readOnly;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.UserAssignableMapCategories;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ActionCategories_readOnly;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.UserAssignableActionCategories;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.JoystickLayouts_readOnly;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.KeyboardLayouts_readOnly;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.MouseLayouts_readOnly;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.CustomControllerLayouts_readOnly;
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
					return fsQBYUGDBZAPIrofCevqCtlZgkl.Actions;
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.UserAssignableActions;
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
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetMapCategoryById(mapCategoryId);
			}

			public InputMapCategory GetMapCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetMapCategory(name);
			}

			public int GetMapCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetMapCategoryId(name);
			}

			public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.UeeOaTSRIGUUJmwfGWfKwuIAPvR(tag);
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.afiDBUdsdNTvSflAxulINMHxlGZg(tag);
			}

			public bool IsMapCategoryUserAssignable(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				InputCategory mapCategory = GetMapCategory(mapCategoryId);
				int num = 833215430;
				goto IL_000c;
				IL_000c:
				while (true)
				{
					switch (num ^ 0x31A9DBC5)
					{
					case 0:
						break;
					case 2:
						return false;
					case 3:
						if (mapCategory == null)
						{
							goto IL_003d;
						}
						return mapCategory.userAssignable;
					default:
						return false;
					}
					break;
					IL_003d:
					num = 833215428;
				}
				goto IL_0007;
				IL_0007:
				num = 833215431;
				goto IL_000c;
			}

			public InputCategory GetActionCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetActionCategoryById(mapCategoryId);
			}

			public InputCategory GetActionCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetActionCategory(name);
			}

			public int GetActionCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetActionCategoryId(name);
			}

			public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.qdHusqNOwSKQACNSEiIsRBdXKOa(tag);
			}

			public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GHeCLHAENkteqVfOeXTxoTwLutZ(tag);
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
				switch (controllerType)
				{
				case ControllerType.Joystick:
					goto IL_0054;
				case ControllerType.Keyboard:
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetKeyboardLayoutById(layoutId);
				case ControllerType.Mouse:
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetMouseLayoutById(layoutId);
				case ControllerType.Custom:
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetCustomControllerLayoutById(layoutId);
				}
				int num = -839749154;
				goto IL_000c;
				IL_0054:
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetJoystickLayoutById(layoutId);
				IL_0007:
				num = -839749155;
				goto IL_000c;
				IL_000c:
				switch (num ^ -839749154)
				{
				case 2:
					break;
				case 3:
					return null;
				default:
					goto IL_0054;
				case 0:
					throw new NotImplementedException();
				}
				goto IL_0007;
			}

			public InputLayout GetLayout(ControllerType controllerType, string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				while (true)
				{
					int num = 1206093880;
					while (true)
					{
						switch (num ^ 0x47E3883B)
						{
						case 0:
							break;
						case 3:
							switch (controllerType)
							{
							default:
								goto IL_003f;
							case ControllerType.Joystick:
								break;
							case ControllerType.Keyboard:
								return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetKeyboardLayout(name);
							case ControllerType.Mouse:
								return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetMouseLayout(name);
							}
							goto default;
						case 2:
							if (controllerType == ControllerType.Custom)
							{
								return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetCustomControllerLayout(name);
							}
							throw new NotImplementedException();
						default:
							return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetJoystickLayout(name);
						}
						break;
						IL_003f:
						num = 1206093881;
					}
				}
			}

			public int GetLayoutId(ControllerType controllerType, string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				switch (controllerType)
				{
				default:
					while (true)
					{
						switch (-1478444800 ^ -1478444799)
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
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetJoystickLayoutId(name);
				case ControllerType.Keyboard:
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetKeyboardLayoutId(name);
				case ControllerType.Mouse:
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetMouseLayoutId(name);
				case ControllerType.Custom:
					return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetCustomControllerLayoutId(name);
				}
			}

			public InputLayout GetJoystickLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetJoystickLayoutById(layoutId);
			}

			public InputLayout GetJoystickLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetJoystickLayout(name);
			}

			public int GetJoystickLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetJoystickLayoutId(name);
			}

			public InputLayout GetKeyboardLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetKeyboardLayoutById(layoutId);
			}

			public InputLayout GetKeyboardLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetKeyboardLayout(name);
			}

			public int GetKeyboardLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetKeyboardLayoutId(name);
			}

			public InputLayout GetMouseLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetMouseLayoutById(layoutId);
			}

			public InputLayout GetMouseLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetMouseLayout(name);
			}

			public int GetMouseLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetMouseLayoutId(name);
			}

			public InputLayout GetCustomControllerLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetCustomControllerLayoutById(layoutId);
			}

			public InputLayout GetCustomControllerLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetCustomControllerLayout(name);
			}

			public int GetCustomControllerLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetCustomControllerLayoutId(name);
			}

			public IList<InputLayout> MapLayouts(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
				}
				while (true)
				{
					switch (-1760375597 ^ -1760375599)
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
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetActionById(actionId);
			}

			public InputAction GetAction(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetAction(name);
			}

			public int GetActionId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetActionId(name);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.bUkCqqbTCbZDZsDEABezjonPmLX(mapCategoryName, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.bUkCqqbTCbZDZsDEABezjonPmLX(mapCategoryName, sort);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.bUkCqqbTCbZDZsDEABezjonPmLX(mapCategoryId, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.bUkCqqbTCbZDZsDEABezjonPmLX(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.quHkPyuugLTimSjYXbYQoqNUfms(tag);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ONQkesvIeGUEvbqIKFMkJKeKicFt(mapCategoryId, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ONQkesvIeGUEvbqIKFMkJKeKicFt(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ONQkesvIeGUEvbqIKFMkJKeKicFt(mapCategoryName, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ONQkesvIeGUEvbqIKFMkJKeKicFt(mapCategoryName, sort);
			}

			public IList<InputBehavior> GetInputBehaviors(int playerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.AZfCriglBpScRjCKKIHazXbFxQw(playerId);
			}

			public IList<InputBehavior> GetSystemPlayerInputBehaviors()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.AZfCriglBpScRjCKKIHazXbFxQw(9999999);
			}

			public InputBehavior GetInputBehavior(int playerId, int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.PGOUkCbsoZNspmHpDpamPSYOIDN(playerId, behaviorId);
			}

			public InputBehavior GetInputBehavior(int playerId, string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return uzYFVAOPCugnffcKSwcZmFfGUjB.PGOUkCbsoZNspmHpDpamPSYOIDN(playerId, behaviorName);
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
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetInputBehaviorId(behaviorName);
			}

			internal InputBehavior PDLBpiYomVdxEiynPbsrqAsfQgD(int P_0)
			{
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetInputBehaviorById(P_0);
			}

			internal InputBehavior PDLBpiYomVdxEiynPbsrqAsfQgD(string P_0)
			{
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetInputBehavior(P_0);
			}

			public ControllerMap GetControllerMap(int id)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				IList<Player> allPlayers = players.AllPlayers;
				int num2 = default(int);
				while (true)
				{
					int num = 1756689491;
					while (true)
					{
						switch (num ^ 0x68B4F452)
						{
						case 0:
							break;
						case 1:
							num2 = 0;
							num = 1756689489;
							continue;
						case 4:
						{
							ControllerMap map = allPlayers[num2].controllers.maps.GetMap(id);
							if (map != null)
							{
								return map;
							}
							num2++;
							num = 1756689495;
							continue;
						}
						case 5:
						{
							int num3;
							if (num2 < allPlayers.Count)
							{
								num = 1756689494;
								num3 = num;
							}
							else
							{
								num = 1756689488;
								num3 = num;
							}
							continue;
						}
						case 3:
							num = 1756689495;
							continue;
						default:
							return null;
						}
						break;
					}
				}
			}

			public ActionElementMap GetActionElementMap(int id)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				IList<Player> allPlayers = players.AllPlayers;
				int num = -1320809088;
				goto IL_000c;
				IL_000c:
				int num2 = default(int);
				ActionElementMap elementMap = default(ActionElementMap);
				while (true)
				{
					switch (num ^ -1320809084)
					{
					case 0:
						break;
					case 2:
						return null;
					case 4:
						num2 = 0;
						num = -1320809087;
						continue;
					case 1:
						if (elementMap != null)
						{
							return elementMap;
						}
						goto IL_0053;
					case 3:
					{
						ControllerMap map = allPlayers[num2].controllers.maps.GetMap(id);
						if (map != null)
						{
							elementMap = map.GetElementMap(id);
							num = -1320809083;
							continue;
						}
						goto IL_0053;
					}
					default:
						{
							if (num2 >= allPlayers.Count)
							{
								return null;
							}
							goto case 3;
						}
						IL_0053:
						num2++;
						num = -1320809087;
						continue;
					}
					break;
				}
				goto IL_0007;
				IL_0007:
				num = -1320809082;
				goto IL_000c;
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
				default:
					while (true)
					{
						switch (0x8608C76 ^ 0x8608C77)
						{
						case 2:
							continue;
						case 1:
							throw new NotImplementedException();
						}
						break;
					}
					goto case ControllerType.Joystick;
				case ControllerType.Joystick:
					return GetJoystickMapInstance((Joystick)controller, mapCategoryId, layoutId);
				case ControllerType.Keyboard:
					return GetKeyboardMapInstance(mapCategoryId, layoutId);
				case ControllerType.Mouse:
					return GetMouseMapInstance(mapCategoryId, layoutId);
				case ControllerType.Custom:
					return GetCustomControllerMapInstance((CustomController)controller, mapCategoryId, layoutId);
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
				int layoutId = default(int);
				while (true)
				{
					int num = 684166690;
					while (true)
					{
						switch (num ^ 0x28C78E23)
						{
						case 0:
							break;
						case 1:
							if (mapCategoryId >= 0)
							{
								goto IL_003a;
							}
							return null;
						default:
							if (layoutId < 0)
							{
								return null;
							}
							return GetControllerMapInstance(controller, mapCategoryId, layoutId);
						}
						break;
						IL_003a:
						layoutId = GetLayoutId(controller.type, layoutName);
						num = 684166689;
					}
				}
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
				JoystickMap joystickMap = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.xSmZEdTrKmvKQhUCylMqvdplEmLK(joystick, mapCategoryId, layoutId);
				int num = -1090812727;
				goto IL_000c;
				IL_0007:
				num = -1090812726;
				goto IL_000c;
				IL_000c:
				while (true)
				{
					switch (num ^ -1090812728)
					{
					case 3:
						break;
					case 2:
						return null;
					case 1:
					{
						int num2;
						if (joystickMap == null)
						{
							num = -1090812728;
							num2 = num;
						}
						else
						{
							num = -1090812724;
							num2 = num;
						}
						continue;
					}
					case 4:
						joystick.BakeMap(joystickMap);
						num = -1090812728;
						continue;
					default:
						return joystickMap;
					}
					break;
				}
				goto IL_0007;
			}

			public JoystickMap GetJoystickMapInstance(Joystick joystick, string mapCategoryName, string layoutName)
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
				return GetJoystickMapInstance(joystick, mapCategoryId, layoutId);
			}

			public JoystickMap GetJoystickMapInstance(Guid joystickTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				if (joystickTypeGuid == Guid.Empty)
				{
					return null;
				}
				InputSource inputSourceType = jdHrzjKbbHpmRevALLCPhhMcYEo.inputSourceType;
				int num = 1997566384;
				goto IL_000c;
				IL_0007:
				num = 1997566385;
				goto IL_000c;
				IL_000c:
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = default(HardwareJoystickMap_InputManager);
				while (true)
				{
					switch (num ^ 0x771071B0)
					{
					case 3:
						break;
					case 1:
						return null;
					case 0:
						goto IL_004c;
					default:
					{
						if (hardwareJoystickMap_InputManager == null)
						{
							Logger.LogError("No hardware map found.");
							return null;
						}
						JoystickMap joystickMap = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ABAQieQmqspSHIkOXPSuKpjQbCg(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
						if (joystickMap != null)
						{
							joystickMap.controllerType = ControllerType.Joystick;
							HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
							using (IEnumerator<ActionElementMap> enumerator = joystickMap.AllMaps.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										ActionElementMap current = enumerator.Current;
										current.whwkUxeoVTXElgAgnQdNaqmBOcM(joystickMap, hardwareControllerMap_Game);
										int num2 = 1997566385;
										while (true)
										{
											switch (num2 ^ 0x771071B0)
											{
											case 0:
												num2 = 1997566386;
												continue;
											case 2:
												break;
											default:
												goto end_IL_00c0;
											}
											break;
										}
										continue;
										end_IL_00c0:
										break;
									}
								}
							}
						}
						return joystickMap;
					}
					}
					break;
					IL_004c:
					hardwareJoystickMap_InputManager = SfZmyxquROdGzGebXHktAifKfcyJ.PPCLNwHdBLXamGlKfICMfvrfIOyx(joystickTypeGuid, inputSourceType);
					num = 1997566386;
				}
				goto IL_0007;
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
				int num = -1801257758;
				goto IL_001b;
				IL_001b:
				switch (num ^ -1801257760)
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
					return GetJoystickMapInstance(joystickTypeGuid, mapCategoryId, layoutId);
				}
				}
				goto IL_0016;
				IL_0016:
				num = -1801257759;
				goto IL_001b;
			}

			public KeyboardMap GetKeyboardMapInstance(int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				KeyboardMap keyboardMap = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.FindKeyboardMap_Game(mapCategoryId, layoutId);
				int num = 279669843;
				goto IL_000c;
				IL_000c:
				while (true)
				{
					switch (num ^ 0x10AB6C53)
					{
					case 3:
						break;
					case 1:
						return null;
					case 0:
						if (keyboardMap != null)
						{
							goto IL_0042;
						}
						goto default;
					default:
						return keyboardMap;
					}
					break;
					IL_0042:
					controllers.Keyboard.BakeMap(keyboardMap);
					num = 279669841;
				}
				goto IL_0007;
				IL_0007:
				num = 279669842;
				goto IL_000c;
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
				MouseMap mouseMap = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.FindMouseMap_Game(mapCategoryId, layoutId);
				if (mouseMap != null)
				{
					controllers.Mouse.BakeMap(mouseMap);
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
				CustomControllerMap customControllerMap = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.MehHSdzwFfroqrFNXLiGTsJRIwK(customController.sourceControllerId, mapCategoryId, layoutId);
				while (true)
				{
					int num = 234867931;
					while (true)
					{
						switch (num ^ 0xDFFCCDA)
						{
						case 0:
							break;
						case 1:
							if (customControllerMap != null)
							{
								goto IL_003d;
							}
							goto default;
						default:
							return customControllerMap;
						}
						break;
						IL_003d:
						customController.BakeMap(customControllerMap);
						num = 234867928;
					}
				}
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

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, Controller controller, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					goto IL_000c;
				}
				ControllerMap controllerMap = null;
				IControllerMapStore controllerMapStore = userDataStore as IControllerMapStore;
				int num;
				if (controllerMapStore != null)
				{
					controllerMap = controllerMapStore.LoadControllerMap(playerId, controller.identifier, mapCategoryId, layoutId);
					num = -2039477209;
					goto IL_0011;
				}
				goto IL_00b0;
				IL_003d:
				if (controllerMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.WCmGeLfhpkcBkcwgHknyvrnPkrF(controller, controllerMap);
						num = -2039477211;
						goto IL_0011;
					}
					goto IL_009f;
				}
				goto IL_00cc;
				IL_00cc:
				return controllerMap;
				IL_009f:
				controller.BakeMap(controllerMap);
				num = -2039477210;
				goto IL_0011;
				IL_000c:
				num = -2039477214;
				goto IL_0011;
				IL_0011:
				while (true)
				{
					switch (num ^ -2039477213)
					{
					case 0:
						break;
					case 2:
						goto IL_003d;
					case 6:
						num = -2039477210;
						continue;
					case 1:
						return null;
					case 3:
						goto IL_009f;
					case 4:
						goto IL_00b0;
					default:
						goto IL_00cc;
					}
					break;
				}
				goto IL_000c;
				IL_00b0:
				if (controllerMap == null)
				{
					controllerMap = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.EejRxaQkJjVzdXNnYOzIknaBWSF(controller, mapCategoryId, layoutId);
					num = -2039477215;
					goto IL_0011;
				}
				goto IL_003d;
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				switch (controllerIdentifier.controllerType)
				{
				case ControllerType.Joystick:
					return GetJoystickMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
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

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, Joystick joystick, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return GetControllerMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId) as JoystickMap;
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				InputSource inputSourceType = jdHrzjKbbHpmRevALLCPhhMcYEo.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = default(HardwareJoystickMap_InputManager);
				JoystickMap joystickMap = default(JoystickMap);
				IControllerMapStore controllerMapStore = default(IControllerMapStore);
				while (true)
				{
					int num = 384610394;
					while (true)
					{
						switch (num ^ 0x16ECB05C)
						{
						case 5:
							break;
						case 6:
							hardwareJoystickMap_InputManager = SfZmyxquROdGzGebXHktAifKfcyJ.PPCLNwHdBLXamGlKfICMfvrfIOyx(controllerIdentifier.hardwareTypeGuid, inputSourceType);
							if (hardwareJoystickMap_InputManager == null)
							{
								Logger.LogError("No hardware map found.");
								return null;
							}
							joystickMap = null;
							num = 384610397;
							continue;
						case 4:
							joystickMap = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.ABAQieQmqspSHIkOXPSuKpjQbCg(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
							num = 384610395;
							continue;
						case 8:
							joystickMap = controllerMapStore.LoadControllerMap(playerId, controllerIdentifier, mapCategoryId, layoutId) as JoystickMap;
							num = 384610396;
							continue;
						case 0:
						{
							int num2;
							if (joystickMap == null)
							{
								num = 384610392;
								num2 = num;
							}
							else
							{
								num = 384610395;
								num2 = num;
							}
							continue;
						}
						case 7:
							if (joystickMap != null)
							{
								joystickMap.controllerType = ControllerType.Joystick;
								num = 384610398;
								continue;
							}
							goto IL_0197;
						case 1:
						{
							controllerMapStore = userDataStore as IControllerMapStore;
							int num5;
							if (controllerMapStore == null)
							{
								num = 384610396;
								num5 = num;
							}
							else
							{
								num = 384610388;
								num5 = num;
							}
							continue;
						}
						case 2:
							if (players.GetPlayer(playerId) != null)
							{
								joystickMap.playerId = playerId;
								num = 384610399;
								continue;
							}
							goto default;
						default:
							{
								HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
								using (IEnumerator<ActionElementMap> enumerator = joystickMap.AllMaps.GetEnumerator())
								{
									while (true)
									{
										IL_016f:
										int num3;
										int num4;
										if (!enumerator.MoveNext())
										{
											num3 = 384610399;
											num4 = num3;
										}
										else
										{
											num3 = 384610397;
											num4 = num3;
										}
										while (true)
										{
											switch (num3 ^ 0x16ECB05C)
											{
											case 0:
												num3 = 384610397;
												continue;
											default:
												goto end_IL_0138;
											case 1:
											{
												ActionElementMap current = enumerator.Current;
												current.whwkUxeoVTXElgAgnQdNaqmBOcM(joystickMap, hardwareControllerMap_Game);
												num3 = 384610398;
												continue;
											}
											case 2:
												break;
											case 3:
												goto end_IL_0138;
											}
											goto IL_016f;
											continue;
											end_IL_0138:
											break;
										}
										break;
									}
								}
								goto IL_0197;
							}
							IL_0197:
							return joystickMap;
						}
						break;
					}
				}
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, CustomController customController, int mapCategoryId, int layoutId)
			{
				return GetControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId) as CustomControllerMap;
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomController_Editor customControllerByHardwareTypeGuid = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					return null;
				}
				CustomControllerMap customControllerMap = null;
				IControllerMapStore controllerMapStore = userDataStore as IControllerMapStore;
				if (controllerMapStore != null)
				{
					customControllerMap = controllerMapStore.LoadControllerMap(playerId, controllerIdentifier, mapCategoryId, layoutId) as CustomControllerMap;
					goto IL_0041;
				}
				goto IL_0067;
				IL_00b5:
				HardwareControllerMap_Game hardwareControllerMap_Game = default(HardwareControllerMap_Game);
				int num;
				if (customControllerMap != null)
				{
					hardwareControllerMap_Game = customControllerByHardwareTypeGuid.KDogQqmgPVdWpEwZDagggKagBxV();
					if (hardwareControllerMap_Game != null)
					{
						customControllerMap.controllerType = ControllerType.Custom;
						if (players.GetPlayer(playerId) == null)
						{
							goto IL_00cc;
						}
						customControllerMap.playerId = playerId;
						num = 1058611732;
					}
					else
					{
						num = 1058611731;
					}
					goto IL_0046;
				}
				goto IL_0134;
				IL_0134:
				return customControllerMap;
				IL_00cc:
				using (IEnumerator<ActionElementMap> enumerator = customControllerMap.AllMaps.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							ActionElementMap current = enumerator.Current;
							int num2 = 1058611734;
							while (true)
							{
								switch (num2 ^ 0x3F192217)
								{
								case 0:
									num2 = 1058611732;
									continue;
								case 3:
									break;
								case 1:
									current.whwkUxeoVTXElgAgnQdNaqmBOcM(customControllerMap, hardwareControllerMap_Game);
									num2 = 1058611733;
									continue;
								default:
									goto end_IL_00fd;
								}
								break;
							}
							continue;
							end_IL_00fd:
							break;
						}
					}
				}
				goto IL_0134;
				IL_0041:
				num = 1058611733;
				goto IL_0046;
				IL_0046:
				switch (num ^ 0x3F192217)
				{
				case 0:
					break;
				case 2:
					goto IL_0067;
				case 4:
					Logger.LogError("No hardware map found.");
					return null;
				case 1:
					goto IL_00b5;
				default:
					goto IL_00cc;
				}
				goto IL_0041;
				IL_0067:
				if (customControllerMap == null)
				{
					customControllerMap = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.MehHSdzwFfroqrFNXLiGTsJRIwK(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
					num = 1058611734;
					goto IL_0046;
				}
				goto IL_00b5;
			}

			public KeyboardMap GetKeyboardMapInstanceSavedOrDefault(int playerId, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				Controller keyboard = controllers.Keyboard;
				KeyboardMap keyboardMap = null;
				IControllerMapStore controllerMapStore = default(IControllerMapStore);
				Player player = default(Player);
				while (true)
				{
					int num = 85870744;
					while (true)
					{
						switch (num ^ 0x51E489C)
						{
						case 6:
							break;
						case 0:
							if (keyboardMap == null)
							{
								keyboardMap = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.FindKeyboardMap_Game(mapCategoryId, layoutId);
								num = 85870745;
								continue;
							}
							goto case 5;
						case 3:
							num = 85870750;
							continue;
						case 4:
						{
							controllerMapStore = userDataStore as IControllerMapStore;
							int num2;
							if (controllerMapStore == null)
							{
								num = 85870748;
								num2 = num;
							}
							else
							{
								num = 85870747;
								num2 = num;
							}
							continue;
						}
						case 8:
							player.controllers.maps.WCmGeLfhpkcBkcwgHknyvrnPkrF(keyboard, keyboardMap);
							num = 85870751;
							continue;
						case 5:
							if (keyboardMap != null)
							{
								player = players.GetPlayer(playerId);
								int num3;
								if (player != null)
								{
									num = 85870740;
									num3 = num;
								}
								else
								{
									num = 85870749;
									num3 = num;
								}
								continue;
							}
							goto default;
						case 1:
							keyboard.BakeMap(keyboardMap);
							num = 85870750;
							continue;
						case 7:
							keyboardMap = controllerMapStore.LoadControllerMap(playerId, keyboard.identifier, mapCategoryId, layoutId) as KeyboardMap;
							num = 85870748;
							continue;
						default:
							return keyboardMap;
						}
						break;
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
				MouseMap mouseMap = null;
				IControllerMapStore controllerMapStore = default(IControllerMapStore);
				while (true)
				{
					int num = -1056031043;
					while (true)
					{
						switch (num ^ -1056031048)
						{
						case 3:
							break;
						case 2:
							if (mouseMap != null)
							{
								Player player = players.GetPlayer(playerId);
								if (player != null)
								{
									player.controllers.maps.WCmGeLfhpkcBkcwgHknyvrnPkrF(mouse, mouseMap);
									num = -1056031047;
									continue;
								}
								goto case 7;
							}
							goto default;
						case 6:
							if (mouseMap == null)
							{
								mouseMap = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.FindMouseMap_Game(mapCategoryId, layoutId);
								num = -1056031046;
								continue;
							}
							goto case 2;
						case 1:
							num = -1056031048;
							continue;
						case 5:
							controllerMapStore = userDataStore as IControllerMapStore;
							num = -1056031044;
							continue;
						case 4:
							if (controllerMapStore != null)
							{
								mouseMap = controllerMapStore.LoadControllerMap(playerId, mouse.identifier, mapCategoryId, layoutId) as MouseMap;
								num = -1056031042;
								continue;
							}
							goto case 6;
						case 7:
							mouse.BakeMap(mouseMap);
							num = -1056031048;
							continue;
						default:
							return mouseMap;
						}
						break;
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
				return dkzdqVbbCuZSSnRZYtTdtTrOfvn(joystick.hardwareTypeGuid, joystickElementIdentifierId);
			}

			private ControllerElementIdentifier dkzdqVbbCuZSSnRZYtTdtTrOfvn(Guid P_0, int P_1)
			{
				ControllerTemplateElementIdentifier controllerTemplateElementIdentifier = SfZmyxquROdGzGebXHktAifKfcyJ.dkzdqVbbCuZSSnRZYtTdtTrOfvn(P_0, P_1);
				if (controllerTemplateElementIdentifier != null)
				{
					return controllerTemplateElementIdentifier.ToControllerElementIdentifier();
				}
				return null;
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ.quXceAXtIYyNSwGxvhSIeOQfaAr(templateTypeGuid, mapCategoryId, layoutId);
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				while (true)
				{
					int num = 1920752035;
					while (true)
					{
						switch (num ^ 0x727C59A2)
						{
						case 0:
							break;
						case 1:
						{
							if (mapCategoryId < 0)
							{
								return null;
							}
							int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
							if (layoutId < 0)
							{
								goto IL_0043;
							}
							return GetControllerTemplateMapInstance(templateTypeGuid, mapCategoryId, layoutId);
						}
						default:
							return null;
						}
						break;
						IL_0043:
						num = 1920752032;
					}
				}
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(int id)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManagerRuleSetById = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetControllerMapLayoutManagerRuleSetById(id);
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
				int controllerMapLayoutManagerRuleSetId = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetControllerMapLayoutManagerRuleSetId(name);
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
				ControllerMapEnabler_RuleSet_Editor controllerMapEnablerRuleSetById = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetControllerMapEnablerRuleSetById(id);
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
				int controllerMapEnablerRuleSetId = HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetControllerMapEnablerRuleSetId(name);
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
			private static PlayerHelper muFkkiEUnsHdAMTJRFCFrPnztKW;

			internal static PlayerHelper Instance
			{
				get
				{
					return muFkkiEUnsHdAMTJRFCFrPnztKW ?? (muFkkiEUnsHdAMTJRFCFrPnztKW = new PlayerHelper());
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
					return YYmRYrIJJDlFmDKErJxqlPcJEZJ.gamePlayerCount;
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
					return YYmRYrIJJDlFmDKErJxqlPcJEZJ.allPlayerCount;
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
					return YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly;
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
					return YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly;
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
					return YYmRYrIJJDlFmDKErJxqlPcJEZJ.OAxOAmqPhXfcosjWwcgifExlsrf();
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
					return YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_readOnly;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_readOnly;
			}

			public Player GetPlayer(int playerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.BguZqZULdBNeIEfARdMNkptxqJou(playerId);
			}

			public Player GetPlayer(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.BguZqZULdBNeIEfARdMNkptxqJou(name);
			}

			public Player GetSystemPlayer()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.OAxOAmqPhXfcosjWwcgifExlsrf();
			}

			public int GetPlayerId(string playerName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.oqWCkffPFVQxBAYLHqvdvygwfZDB(playerName);
			}

			public string[] GetPlayerNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.dmxAurkhWSGLWImVNrZhZVzuzRm(includeSystemPlayer);
			}

			public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.zakGjCgQSdNmHhDnlWAEvzvVrZH(includeSystemPlayer);
			}

			public int[] GetPlayerIds(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<int>.array;
				}
				return YYmRYrIJJDlFmDKErJxqlPcJEZJ.vppbwPswfcBMlnJkgKbRlQUkGFp(includeSystemPlayer);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper muFkkiEUnsHdAMTJRFCFrPnztKW;

			internal static TimeHelper Instance
			{
				get
				{
					return muFkkiEUnsHdAMTJRFCFrPnztKW ?? (muFkkiEUnsHdAMTJRFCFrPnztKW = new TimeHelper());
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
					return byhxjZCTTQmKqDmFbArjjMebEEiU.unscaledDeltaTime;
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
					return byhxjZCTTQmKqDmFbArjjMebEEiU.unscaledTime;
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
					return byhxjZCTTQmKqDmFbArjjMebEEiU.frame;
				}
			}

			private TimeHelper()
			{
			}
		}

		private class EhxsPnRgLkJGhNLebiGYbKRcQisC
		{
			private class PEhdvMmUUQFgTimkBZtyvdkTkaP
			{
				public readonly UpdateLoopType uZqPISCyPgGPOetNKiFUKtuJqjV;

				private float unwgQSnePmeOsXbHPocojQIZGLM;

				private float wGaGzOSVHEeUGehUFFhEJemcsBD;

				private float FtnAbdJXGXeezDMRWayldslYfCSO;

				private float iWpvHOnbLFlrKVsDoRBJraRtavF;

				private uint geqTkVWeHSclULzUsqTDwVoQmfu;

				private uint lTDkbefPylKXAYNBPzGwuOtgyUV;

				private float AbCBxbmbcgBtrEzVCJgroRaBcGg;

				private float zdmHgZpCwAdmfHodYfWlDOCqbWY;

				public float unscaledTime
				{
					get
					{
						return unwgQSnePmeOsXbHPocojQIZGLM;
					}
				}

				public float unscaledTimePrev
				{
					get
					{
						return wGaGzOSVHEeUGehUFFhEJemcsBD;
					}
				}

				public float unscaledDeltaTime
				{
					get
					{
						return FtnAbdJXGXeezDMRWayldslYfCSO;
					}
				}

				public uint frame
				{
					get
					{
						return geqTkVWeHSclULzUsqTDwVoQmfu;
					}
				}

				public uint framePrev
				{
					get
					{
						return lTDkbefPylKXAYNBPzGwuOtgyUV;
					}
				}

				public float unityUnscaledDeltaTime
				{
					get
					{
						return AbCBxbmbcgBtrEzVCJgroRaBcGg;
					}
				}

				public float unityUnscaledDeltaTimePrev
				{
					get
					{
						return zdmHgZpCwAdmfHodYfWlDOCqbWY;
					}
				}

				public PEhdvMmUUQFgTimkBZtyvdkTkaP(UpdateLoopType updateLoop)
				{
					uZqPISCyPgGPOetNKiFUKtuJqjV = updateLoop;
					iWpvHOnbLFlrKVsDoRBJraRtavF = Time.realtimeSinceStartup;
					geqTkVWeHSclULzUsqTDwVoQmfu = 0u;
				}

				public void UZSQFwoMfSAzsmmSKmseCCiJWWD()
				{
					wGaGzOSVHEeUGehUFFhEJemcsBD = unwgQSnePmeOsXbHPocojQIZGLM;
					unwgQSnePmeOsXbHPocojQIZGLM = ReInput.realTime;
					if (iWpvHOnbLFlrKVsDoRBJraRtavF > unwgQSnePmeOsXbHPocojQIZGLM)
					{
						goto IL_0025;
					}
					goto IL_0064;
					IL_0025:
					int num = 1450155402;
					goto IL_002a;
					IL_002a:
					while (true)
					{
						switch (num ^ 0x566F9D8F)
						{
						case 0:
							break;
						case 5:
							iWpvHOnbLFlrKVsDoRBJraRtavF = 0f;
							num = 1450155403;
							continue;
						case 4:
							goto IL_0064;
						case 1:
							lTDkbefPylKXAYNBPzGwuOtgyUV = geqTkVWeHSclULzUsqTDwVoQmfu;
							geqTkVWeHSclULzUsqTDwVoQmfu = MiscTools.Tick(geqTkVWeHSclULzUsqTDwVoQmfu);
							num = 1450155404;
							continue;
						case 3:
							zdmHgZpCwAdmfHodYfWlDOCqbWY = AbCBxbmbcgBtrEzVCJgroRaBcGg;
							AbCBxbmbcgBtrEzVCJgroRaBcGg = aYzppXbiwhRevgRvHlcJJfkjnTD();
							previousFrame = lTDkbefPylKXAYNBPzGwuOtgyUV;
							currentFrame = geqTkVWeHSclULzUsqTDwVoQmfu;
							num = 1450155405;
							continue;
						default:
							ReInput.unscaledTime = unwgQSnePmeOsXbHPocojQIZGLM;
							ReInput.unscaledTimePrev = wGaGzOSVHEeUGehUFFhEJemcsBD;
							ReInput.unscaledDeltaTime = FtnAbdJXGXeezDMRWayldslYfCSO;
							return;
						}
						break;
					}
					goto IL_0025;
					IL_0064:
					FtnAbdJXGXeezDMRWayldslYfCSO = unwgQSnePmeOsXbHPocojQIZGLM - iWpvHOnbLFlrKVsDoRBJraRtavF;
					iWpvHOnbLFlrKVsDoRBJraRtavF = unwgQSnePmeOsXbHPocojQIZGLM;
					num = 1450155406;
					goto IL_002a;
				}
			}

			private static class AVHklAFuFUwCuXXctuhbWlOXyYc
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

				public static StopwatchBase MdLShCgeucAqBomYFlMaHVWokJC()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return new UnityStopwatch();
					}
					return new Rewired.Utils.Classes.Utility.Stopwatch();
				}

				public static StopwatchBase axFMwrKgkCgvnRJxNRjGNJuWBNN()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return UnityStopwatch.StartNew();
					}
					return Rewired.Utils.Classes.Utility.Stopwatch.StartNew();
				}
			}

			private StopwatchBase YnBnDKQzhCdRVEiGZZWcKvTjviq;

			private float DlcCoZkGqoGypBZJvuzpJgyLUQQ;

			private PEhdvMmUUQFgTimkBZtyvdkTkaP xXeNJfMPHnbgrmrmtEOqQyvMFTV;

			private ADictionary<int, PEhdvMmUUQFgTimkBZtyvdkTkaP> QetjGnDEtDPSEcIQErMZqiGQOiZW;

			private uint nGMvBhZElUQpCwHTNGYODdJvBEzh;

			public float unscaledTime
			{
				get
				{
					return xXeNJfMPHnbgrmrmtEOqQyvMFTV.unscaledTime;
				}
			}

			public float unscaledTimePrev
			{
				get
				{
					return xXeNJfMPHnbgrmrmtEOqQyvMFTV.unscaledTimePrev;
				}
			}

			public float unscaledDeltaTime
			{
				get
				{
					return xXeNJfMPHnbgrmrmtEOqQyvMFTV.unscaledDeltaTime;
				}
			}

			public float unityUnscaledDeltaTime
			{
				get
				{
					return xXeNJfMPHnbgrmrmtEOqQyvMFTV.unityUnscaledDeltaTime;
				}
			}

			public float unityUnscaledDeltaTimePrev
			{
				get
				{
					return xXeNJfMPHnbgrmrmtEOqQyvMFTV.unityUnscaledDeltaTimePrev;
				}
			}

			public float realTime
			{
				get
				{
					return (float)YnBnDKQzhCdRVEiGZZWcKvTjviq.elapsedSeconds + DlcCoZkGqoGypBZJvuzpJgyLUQQ;
				}
			}

			public uint frame
			{
				get
				{
					return xXeNJfMPHnbgrmrmtEOqQyvMFTV.frame;
				}
			}

			public uint framePrev
			{
				get
				{
					return xXeNJfMPHnbgrmrmtEOqQyvMFTV.framePrev;
				}
			}

			public uint absFrame
			{
				get
				{
					return nGMvBhZElUQpCwHTNGYODdJvBEzh;
				}
			}

			public EhxsPnRgLkJGhNLebiGYbKRcQisC()
			{
				YnBnDKQzhCdRVEiGZZWcKvTjviq = AVHklAFuFUwCuXXctuhbWlOXyYc.Global;
				EEGiMNPSMElaPgKQdmScoWLedfb();
			}

			public void QKQqmYzrJRcHvrgQkDkYyDOslGG()
			{
				DlcCoZkGqoGypBZJvuzpJgyLUQQ = Time.realtimeSinceStartup;
			}

			public void EEGiMNPSMElaPgKQdmScoWLedfb()
			{
				xXeNJfMPHnbgrmrmtEOqQyvMFTV = null;
				QetjGnDEtDPSEcIQErMZqiGQOiZW = new ADictionary<int, PEhdvMmUUQFgTimkBZtyvdkTkaP>();
				using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
				{
					List<UpdateLoopType> list = tList.list;
					int num2 = default(int);
					PEhdvMmUUQFgTimkBZtyvdkTkaP value = default(PEhdvMmUUQFgTimkBZtyvdkTkaP);
					while (true)
					{
						int num = -1245198832;
						while (true)
						{
							switch (num ^ -1245198827)
							{
							case 2:
								break;
							default:
								return;
							case 5:
								EnumConverter.ToUpdateLoopTypes((UpdateLoopSetting)2147483647, list);
								num = -1245198827;
								continue;
							case 7:
							{
								int num4;
								if (num2 >= list.Count)
								{
									num = -1245198819;
									num4 = num;
								}
								else
								{
									num = -1245198829;
									num4 = num;
								}
								continue;
							}
							case 6:
							{
								value = new PEhdvMmUUQFgTimkBZtyvdkTkaP(list[num2]);
								QetjGnDEtDPSEcIQErMZqiGQOiZW.Add((int)list[num2], value);
								int num3;
								if (xXeNJfMPHnbgrmrmtEOqQyvMFTV != null)
								{
									num = -1245198828;
									num3 = num;
								}
								else
								{
									num = -1245198826;
									num3 = num;
								}
								continue;
							}
							case 0:
								num2 = 0;
								num = -1245198831;
								continue;
							case 1:
								num2++;
								num = -1245198830;
								continue;
							case 3:
								xXeNJfMPHnbgrmrmtEOqQyvMFTV = value;
								num = -1245198828;
								continue;
							case 4:
								num = -1245198830;
								continue;
							case 8:
								return;
							}
							break;
						}
					}
				}
			}

			public void UZSQFwoMfSAzsmmSKmseCCiJWWD(UpdateLoopType P_0)
			{
				if (xXeNJfMPHnbgrmrmtEOqQyvMFTV.uZqPISCyPgGPOetNKiFUKtuJqjV != P_0)
				{
					xXeNJfMPHnbgrmrmtEOqQyvMFTV = QetjGnDEtDPSEcIQErMZqiGQOiZW[(int)P_0];
					while (true)
					{
						switch (0x32C69C01 ^ 0x32C69C00)
						{
						case 0:
							break;
						case 1:
							goto end_IL_0020;
						default:
							goto IL_0057;
						}
						continue;
						end_IL_0020:
						break;
					}
				}
				if (P_0 == UpdateLoopType.OnGUI && Event.current.rawType != EventType.Layout)
				{
					return;
				}
				goto IL_0057;
				IL_0057:
				xXeNJfMPHnbgrmrmtEOqQyvMFTV.UZSQFwoMfSAzsmmSKmseCCiJWWD();
				nGMvBhZElUQpCwHTNGYODdJvBEzh = MiscTools.Tick(nGMvBhZElUQpCwHTNGYODdJvBEzh);
				ReInput.absFrame = nGMvBhZElUQpCwHTNGYODdJvBEzh;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch muFkkiEUnsHdAMTJRFCFrPnztKW;

			internal static UnityTouch Instance
			{
				get
				{
					return muFkkiEUnsHdAMTJRFCFrPnztKW ?? (muFkkiEUnsHdAMTJRFCFrPnztKW = new UnityTouch());
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

		internal class pYoKnCCVfqdynEXLQmjerrJzGiIh
		{
			public readonly ValueWatcher<bool> bJapzHksrSKqatCVpdSUJVOFzgkf;

			public readonly ValueWatcher<bool> rkMyiSJCrEZgYxAnjXzNqPoPmCC;

			public readonly ValueWatcher<bool> EqsKYJrgzfkdoyPqgDjUNxUXSnb;

			public readonly ValueWatcher<float> BQJHdWatcmMaoTVinhliSIFKncn;

			public readonly ValueWatcher<string> vcMaKVKsPSGEibJzuaIhEyChSBsI;

			public readonly ValueWatcher<bool> XReSKUwXUYFNLYvngWoHmqhvqLV;

			private int eAVMdlGjFWURgZyTGbSFWWOiqf;

			private readonly ValueWatcher[] bTyzTgydMIyPOTRNCMJDsFnTBxZ;

			[CompilerGenerated]
			private static Func<bool> vMpCvfTVRjoUMQjUwyCMQzztQGq;

			[CompilerGenerated]
			private static Func<bool> iSPPZwiivyQfUiEjXFIcKqigdZFl;

			[CompilerGenerated]
			private static Func<float> vCrOCMifPNDKmuVlHJDfUMXWxsq;

			[CompilerGenerated]
			private static Func<bool> LDkhXNhoxGqZMNpDTDyXLVRegnBS;

			[CompilerGenerated]
			private static Func<string> ECvBLFCTVOLAFFEKsgYbocEXuPYV;

			public int currentFrame
			{
				get
				{
					return eAVMdlGjFWURgZyTGbSFWWOiqf;
				}
			}

			public pYoKnCCVfqdynEXLQmjerrJzGiIh()
			{
				List<ValueWatcher> list = new List<ValueWatcher>
				{
					(bJapzHksrSKqatCVpdSUJVOFzgkf = new ValueWatcher<bool>(true, false)),
					(rkMyiSJCrEZgYxAnjXzNqPoPmCC = new ValueWatcher<bool>(Screen.fullScreen, () => Screen.fullScreen, false)),
					(EqsKYJrgzfkdoyPqgDjUNxUXSnb = new ValueWatcher<bool>(Application.runInBackground, () => Application.runInBackground, false)),
					(BQJHdWatcmMaoTVinhliSIFKncn = new ValueWatcher<float>(Time.unscaledDeltaTime, () => Time.unscaledDeltaTime, false)),
					(XReSKUwXUYFNLYvngWoHmqhvqLV = new ValueWatcher<bool>(MathTools.ApproximatelyZero(Time.timeScale), () => MathTools.ApproximatelyZero(Time.timeScale), MathTools.ApproximatelyZero(Time.timeScale)))
				};
				if (editorPlatform != EditorPlatform.None)
				{
					list.Add(vcMaKVKsPSGEibJzuaIhEyChSBsI = new ValueWatcher<string>(UnityTools.externalTools.GetFocusedEditorWindowTitle(), () => UnityTools.externalTools.GetFocusedEditorWindowTitle(), false));
				}
				bTyzTgydMIyPOTRNCMJDsFnTBxZ = list.ToArray();
				UZSQFwoMfSAzsmmSKmseCCiJWWD();
			}

			public void UZSQFwoMfSAzsmmSKmseCCiJWWD()
			{
				int num = 0;
				while (true)
				{
					int num2 = 1536693853;
					while (true)
					{
						switch (num2 ^ 0x5B98165F)
						{
						case 4:
							break;
						case 1:
							num++;
							num2 = 1536693855;
							continue;
						case 3:
							bTyzTgydMIyPOTRNCMJDsFnTBxZ[num].Update();
							num2 = 1536693854;
							continue;
						case 2:
							num2 = 1536693855;
							continue;
						default:
							if (num >= bTyzTgydMIyPOTRNCMJDsFnTBxZ.Length)
							{
								eAVMdlGjFWURgZyTGbSFWWOiqf = Time.frameCount;
								return;
							}
							goto case 3;
						}
						break;
					}
				}
			}

			public void JBUJYqkBSdjOUTpqLXKBOxBQzIF()
			{
				int num = 0;
				while (true)
				{
					int num2 = 229348407;
					while (true)
					{
						switch (num2 ^ 0xDAB9434)
						{
						case 0:
							break;
						case 3:
							num2 = 229348405;
							continue;
						case 2:
							bTyzTgydMIyPOTRNCMJDsFnTBxZ[num].TriggerEvent();
							num++;
							num2 = 229348405;
							continue;
						default:
							if (num >= bTyzTgydMIyPOTRNCMJDsFnTBxZ.Length)
							{
								return;
							}
							goto case 2;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static bool RjLniZzmsMgDCBielzkuJVIGaYt()
			{
				return Screen.fullScreen;
			}

			[CompilerGenerated]
			private static bool LmQeErYQZmCEnqchcKVWvxXYfee()
			{
				return Application.runInBackground;
			}

			[CompilerGenerated]
			private static float EMhpPCpuYsNtKZCiuTJhdoKrszr()
			{
				return Time.unscaledDeltaTime;
			}

			[CompilerGenerated]
			private static bool PUiBGLegvAlakmWysyLQRNapziy()
			{
				return MathTools.ApproximatelyZero(Time.timeScale);
			}

			[CompilerGenerated]
			private static string faBQbABlnjhACjdstSIdnNlpPan()
			{
				return UnityTools.externalTools.GetFocusedEditorWindowTitle();
			}
		}

		[CustomObfuscation(rename = false)]
		internal const int programVersion1 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion2 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion3 = 26;

		[CustomObfuscation(rename = false)]
		internal const int programVersion4 = 0;

		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U2017";

		private static InputManager_Base slVUsRChRjTDGWipWiBmxpDDiza;

		private static PlatformInputManager jdHrzjKbbHpmRevALLCPhhMcYEo;

		internal static ELmeHFhAEObgGMupfccwkercFbWz fsQBYUGDBZAPIrofCevqCtlZgkl;

		internal static GDZJmMlQvBAxDaQCuBIKYWggay uzYFVAOPCugnffcKSwcZmFfGUjB;

		internal static aSOYcRCZqytuczbEAnlwvDhfgcsc YYmRYrIJJDlFmDKErJxqlPcJEZJ;

		private static ControllerDataFiles SfZmyxquROdGzGebXHktAifKfcyJ;

		private static UserData HWKwbrcCuDRNpmsHSWlFyGHxmZJ;

		private static bool PkVqugVNIpoYIMpSDcpjdJRrnVs;

		private static ConfigVars nsJgCtIfwJQZurQxCSnuqEVGIyJc;

		private static UpdateLoopType uRiFqecNVABhPpjlbdnEZbQCduHT;

		private static bool NQSAaKpVXFTtpEYlkOfJfYnAXKF;

		private static Platform XoBgevKuUNufHImfugJUwYrcLed;

		private static WebplayerPlatform hfpQRTMlbWHjpKZUTBjPrNSHOMN;

		private static EditorPlatform TAeiTQcgMAUjxnGidzESNBdrZfL;

		private static bool TEUkumnGqcKoeDfMZAvHWiKrVAA;

		private static TimerAbs eVnxwPuAIqSqjdCHfLTPnQqhOuS;

		private static EhxsPnRgLkJGhNLebiGYbKRcQisC byhxjZCTTQmKqDmFbArjjMebEEiU;

		private static string FfmOuXPsLyiXOYRGYqCvUomXEtf;

		private static bool KKKoRVgqJBPLeLIfqHuOawpSzDv;

		private static bool dGPMYixxEPuanNlkfwttgKrCAJn;

		private static bool DbIfnSeTsZrarxRvEbGnotGXYOP;

		private static int vVluxECgHHObLIBDngtyeEopTfz;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int BqvGDajsNHDQFimaowoHWkmtcezJ;

		private static int xLfxhFLZjQdLUWRyswoZPONPxBz;

		private static bool siTcmUMIEORCspmGInUXrqRhAmA;

		private static readonly UnityTouch VwhdbYJAGspHdCecSDipahRQBGhC;

		private static readonly PlayerHelper nMAqgihSNTIWeKABbtKAmaICcOI;

		private static readonly ControllerHelper bwPdHPluauISSUMbOOibuKhSRfq;

		private static readonly MappingHelper VQPmvtPFHSNMveDszHKjIBkUsAg;

		private static readonly TimeHelper LNVbxjuBfARbzvtwjPxUVnJqYoc;

		private static readonly ConfigHelper AUDGHcyHPPLEuDEOLcCudxKlwUE;

		private static nVoiynOsjugkJuOeheypUhVfWan PYgfAohzPdBiBNzCBrMUcbVtsqu;

		private static UserDataStore yhRlelsqiNUpDCFRMJbaNbHWeVF;

		private static IControllerAssigner nIhEXAJwaQdlbfpmXetDZHGNHWn;

		private static pYoKnCCVfqdynEXLQmjerrJzGiIh boBvGsJJUSYaUuLcYmbBJIEbOnn;

		private static SafeAction<ControllerStatusChangedEventArgs> HqoMbNHClYgUMifZgaYtZkeZBurd;

		private static SafeAction<ControllerStatusChangedEventArgs> ggujuzDBxzioqbLydtugFDEiuZGB;

		private static SafeAction<ControllerStatusChangedEventArgs> oitWqXclBrDGXFUqewBLImZPvIX;

		private static SafeAction yuiaytJpAtEVJlsDQdvCEAjxGqFh;

		private static SafeAction uUscfsaRRMgEUxAVSYOBdnwjUJx;

		private static SafeAction iEjJzDzajVmJsTOlXBixkZGHcGai;

		private static SafeAction aQUJGRByEiEXNqAtpfhnVDawYDZ;

		private static SafeAction CwsGnWyAGEqkAcwKnlWWLMxZHzc;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		private static Action vntQrbrkKdZWTszdWuZrMHBnpDZ;

		private static Action<UpdateLoopType> ozcWIsacTFpNmGLAgTojfzcyonW;

		private static Action<UpdateLoopType> qsuLbCZToKUUnPYbEKnsCsDTeel;

		private static Action<UpdateLoopType> wLoMYBGXPwqksbsEiqdCOLTLOwH;

		private static Action YWGdJgFpVdmvclIzdHWOMhNWTujk;

		private static Action<bool> LaRcLjSViUcgvqFoPCLnJbJgbQrq;

		private static Action<bool> wqttiWsvbJdLLAHkctBTBwKUJwo;

		private static Action<bool> jRduKrAhuxzvQsgxSARkhtQWACy;

		private static Action ZczdAdjbbuaFVNwaDpqQtCWKmBj;

		private static Action<bool> wzLTVgfDmvVEdrlzFtHQOAGMBjS;

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
		private static Action<Exception> KMVSMNlcVvJaRclgBWSJrxykfCh;

		[CompilerGenerated]
		private static Action<Exception> decyKaUSyEGKbHNDKSnEMCGvfDT;

		[CompilerGenerated]
		private static Action<Exception> OaciNJiksQpXpqpsqstbBUbOMJaC;

		[CompilerGenerated]
		private static Action<Exception> iTIUNfkrngADvbAMBtQwnvUyAPT;

		[CompilerGenerated]
		private static Action<Exception> TODKqlbTiotlvzHBygnoMXgfGhn;

		[CompilerGenerated]
		private static Action<Exception> KHuwdLJfGgThnfYBrbOxhYxvFWc;

		[CompilerGenerated]
		private static Action<Exception> aKYKKTPklWeTSnrfszjkZGFVelD;

		[CompilerGenerated]
		private static Action<Exception> UioTSLrlZQEXgOsMPnnSNqTfIIb;

		[CompilerGenerated]
		private static Action<Exception> XiHoGooqxEyVXEDOyqTRocwCIzR;

		[CompilerGenerated]
		private static Func<bool> qojbSQuHYVbcggRiGJeaPVVZlQpK;

		private static nVoiynOsjugkJuOeheypUhVfWan unityInputBuffer
		{
			get
			{
				return PYgfAohzPdBiBNzCBrMUcbVtsqu ?? (PYgfAohzPdBiBNzCBrMUcbVtsqu = new nVoiynOsjugkJuOeheypUhVfWan(nsJgCtIfwJQZurQxCSnuqEVGIyJc.updateLoop));
			}
		}

		public static PlayerHelper players
		{
			get
			{
				if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					oRdMvvHeXoBVjiPOAZrrkCGwKZc();
					return null;
				}
				return nMAqgihSNTIWeKABbtKAmaICcOI;
			}
		}

		public static ControllerHelper controllers
		{
			get
			{
				if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					oRdMvvHeXoBVjiPOAZrrkCGwKZc();
					return null;
				}
				return bwPdHPluauISSUMbOOibuKhSRfq;
			}
		}

		public static MappingHelper mapping
		{
			get
			{
				if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					oRdMvvHeXoBVjiPOAZrrkCGwKZc();
					return null;
				}
				return VQPmvtPFHSNMveDszHKjIBkUsAg;
			}
		}

		public static UnityTouch touch
		{
			get
			{
				if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					oRdMvvHeXoBVjiPOAZrrkCGwKZc();
					return null;
				}
				return VwhdbYJAGspHdCecSDipahRQBGhC;
			}
		}

		public static TimeHelper time
		{
			get
			{
				if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					oRdMvvHeXoBVjiPOAZrrkCGwKZc();
					return null;
				}
				return LNVbxjuBfARbzvtwjPxUVnJqYoc;
			}
		}

		public static IUserDataStore userDataStore
		{
			get
			{
				if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					oRdMvvHeXoBVjiPOAZrrkCGwKZc();
					return null;
				}
				return yhRlelsqiNUpDCFRMJbaNbHWeVF;
			}
		}

		public static ConfigHelper configuration
		{
			get
			{
				if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					oRdMvvHeXoBVjiPOAZrrkCGwKZc();
					return null;
				}
				return AUDGHcyHPPLEuDEOLcCudxKlwUE;
			}
		}

		public static string programVersion
		{
			get
			{
				object[] array = new object[8] { 1, ".", null, null, null, null, null, null };
				while (true)
				{
					int num = 2020196764;
					while (true)
					{
						switch (num ^ 0x7869C19D)
						{
						case 0:
							break;
						case 1:
							goto IL_0036;
						default:
							return string.Concat(array);
						}
						break;
						IL_0036:
						array[2] = 1;
						array[3] = ".";
						array[4] = 26;
						array[5] = ".";
						array[6] = 0;
						array[7] = ".U2017";
						num = 2020196767;
					}
				}
			}
		}

		public static bool usingUnityInput
		{
			get
			{
				return NQSAaKpVXFTtpEYlkOfJfYnAXKF;
			}
		}

		public static bool unityJoystickIdentificationRequired
		{
			get
			{
				if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					return false;
				}
				if (isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
				{
					return true;
				}
				return false;
			}
		}

		public static bool isReady
		{
			get
			{
				return PkVqugVNIpoYIMpSDcpjdJRrnVs;
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
				return PkVqugVNIpoYIMpSDcpjdJRrnVs;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static UpdateLoopType currentUpdateLoop
		{
			get
			{
				return uRiFqecNVABhPpjlbdnEZbQCduHT;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static ConfigVars configVars
		{
			get
			{
				return nsJgCtIfwJQZurQxCSnuqEVGIyJc;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static UserData UserData
		{
			get
			{
				return HWKwbrcCuDRNpmsHSWlFyGHxmZJ;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static Platform currentPlatform
		{
			get
			{
				return XoBgevKuUNufHImfugJUwYrcLed;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static WebplayerPlatform webplayerPlatform
		{
			get
			{
				return hfpQRTMlbWHjpKZUTBjPrNSHOMN;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static EditorPlatform editorPlatform
		{
			get
			{
				return TAeiTQcgMAUjxnGidzESNBdrZfL;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool checkNeverPressed
		{
			get
			{
				if (XoBgevKuUNufHImfugJUwYrcLed == Platform.Linux && NQSAaKpVXFTtpEYlkOfJfYnAXKF)
				{
					return true;
				}
				if (XoBgevKuUNufHImfugJUwYrcLed == Platform.OSX)
				{
					while (true)
					{
						int num = 1862836782;
						while (true)
						{
							switch (num ^ 0x6F08A22C)
							{
							case 0:
								break;
							case 2:
								if (!NQSAaKpVXFTtpEYlkOfJfYnAXKF)
								{
									goto IL_003e;
								}
								goto default;
							default:
								return true;
							}
							break;
							IL_003e:
							if (primaryInputManager.inputSourceType != InputSource.OSX)
							{
								goto end_IL_0019;
							}
							num = 1862836781;
						}
						continue;
						end_IL_0019:
						break;
					}
				}
				if (UnityTools.isAndroidPlatform && NQSAaKpVXFTtpEYlkOfJfYnAXKF)
				{
					return true;
				}
				if (XoBgevKuUNufHImfugJUwYrcLed == Platform.Webplayer && hfpQRTMlbWHjpKZUTBjPrNSHOMN == WebplayerPlatform.OSX)
				{
					return true;
				}
				if (XoBgevKuUNufHImfugJUwYrcLed == Platform.WebGL)
				{
					return true;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isEditor
		{
			get
			{
				return TAeiTQcgMAUjxnGidzESNBdrZfL != EditorPlatform.None;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					return Guid.Empty;
				}
				return SfZmyxquROdGzGebXHktAifKfcyJ.defaultHardwareJoystickMapGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isRunningInEditMode
		{
			get
			{
				return dGPMYixxEPuanNlkfwttgKrCAJn;
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
				return byhxjZCTTQmKqDmFbArjjMebEEiU.unityUnscaledDeltaTime;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTimePrev
		{
			get
			{
				return byhxjZCTTQmKqDmFbArjjMebEEiU.unityUnscaledDeltaTimePrev;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static float realTime
		{
			get
			{
				if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					return 0f;
				}
				return byhxjZCTTQmKqDmFbArjjMebEEiU.realTime;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int currentUnityFrame
		{
			get
			{
				if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					return 0;
				}
				return boBvGsJJUSYaUuLcYmbBJIEbOnn.currentFrame;
			}
		}

		private static bool isEditorGameViewFocused
		{
			get
			{
				if (UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_1)
				{
					return FfmOuXPsLyiXOYRGYqCvUomXEtf == "Game";
				}
				return FfmOuXPsLyiXOYRGYqCvUomXEtf == "UnityEditor.GameView";
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused
		{
			get
			{
				if (nsJgCtIfwJQZurQxCSnuqEVGIyJc.allowInputInEditorSceneView && UnityTools.externalTools.IsEditorSceneViewFocused())
				{
					return true;
				}
				if (!DbIfnSeTsZrarxRvEbGnotGXYOP)
				{
					return isEditorGameViewFocused;
				}
				return true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused
		{
			get
			{
				INativePlatformHelper nativePlatformHelper = jdHrzjKbbHpmRevALLCPhhMcYEo as INativePlatformHelper;
				if (nativePlatformHelper != null)
				{
					return nativePlatformHelper.isApplicationFocused;
				}
				return DbIfnSeTsZrarxRvEbGnotGXYOP;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform
		{
			get
			{
				if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					return false;
				}
				if (!NQSAaKpVXFTtpEYlkOfJfYnAXKF)
				{
					return false;
				}
				if (XoBgevKuUNufHImfugJUwYrcLed != Platform.Windows)
				{
					while (true)
					{
						int num = 1354875243;
						while (true)
						{
							switch (num ^ 0x50C1C16A)
							{
							case 2:
								break;
							case 1:
								if (XoBgevKuUNufHImfugJUwYrcLed == Platform.Webplayer)
								{
									goto IL_0041;
								}
								goto default;
							default:
								return TAeiTQcgMAUjxnGidzESNBdrZfL == EditorPlatform.Windows;
							}
							break;
							IL_0041:
							if (hfpQRTMlbWHjpKZUTBjPrNSHOMN == WebplayerPlatform.Windows)
							{
								goto end_IL_001a;
							}
							num = 1354875242;
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
				if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					return false;
				}
				if (TAeiTQcgMAUjxnGidzESNBdrZfL != EditorPlatform.None && !dGPMYixxEPuanNlkfwttgKrCAJn && isEditorPaused)
				{
					return false;
				}
				if (!boBvGsJJUSYaUuLcYmbBJIEbOnn.bJapzHksrSKqatCVpdSUJVOFzgkf.value)
				{
					if (siTcmUMIEORCspmGInUXrqRhAmA)
					{
						return false;
					}
					if (!isEditor)
					{
						if (!boBvGsJJUSYaUuLcYmbBJIEbOnn.EqsKYJrgzfkdoyPqgDjUNxUXSnb.value)
						{
							return false;
						}
						if (boBvGsJJUSYaUuLcYmbBJIEbOnn.rkMyiSJCrEZgYxAnjXzNqPoPmCC.value)
						{
							return false;
						}
					}
				}
				return true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFocused
		{
			get
			{
				if (PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					return boBvGsJJUSYaUuLcYmbBJIEbOnn.bJapzHksrSKqatCVpdSUJVOFzgkf.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFullScreen
		{
			get
			{
				if (PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					return boBvGsJJUSYaUuLcYmbBJIEbOnn.rkMyiSJCrEZgYxAnjXzNqPoPmCC.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationRunInBackground
		{
			get
			{
				if (PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					return boBvGsJJUSYaUuLcYmbBJIEbOnn.EqsKYJrgzfkdoyPqgDjUNxUXSnb.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool timeScaleIsPaused
		{
			get
			{
				if (PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					return boBvGsJJUSYaUuLcYmbBJIEbOnn.XReSKUwXUYFNLYvngWoHmqhvqLV.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static InputManager_Base rewiredInputManager
		{
			get
			{
				return slVUsRChRjTDGWipWiBmxpDDiza;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static PlatformInputManager primaryInputManager
		{
			get
			{
				if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
				{
					oRdMvvHeXoBVjiPOAZrrkCGwKZc();
					return null;
				}
				return jdHrzjKbbHpmRevALLCPhhMcYEo.primaryInputManager;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static IControllerAssigner controllerAssigner
		{
			get
			{
				return nIhEXAJwaQdlbfpmXetDZHGNHWn;
			}
			set
			{
				nIhEXAJwaQdlbfpmXetDZHGNHWn = value;
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
				return xLfxhFLZjQdLUWRyswoZPONPxBz;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
		{
			add
			{
				HqoMbNHClYgUMifZgaYtZkeZBurd += value;
			}
			remove
			{
				HqoMbNHClYgUMifZgaYtZkeZBurd -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
		{
			add
			{
				ggujuzDBxzioqbLydtugFDEiuZGB += value;
			}
			remove
			{
				ggujuzDBxzioqbLydtugFDEiuZGB -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
		{
			add
			{
				oitWqXclBrDGXFUqewBLImZPvIX += value;
			}
			remove
			{
				oitWqXclBrDGXFUqewBLImZPvIX -= value;
			}
		}

		public static event Action InputSourceUpdateEvent
		{
			add
			{
				yuiaytJpAtEVJlsDQdvCEAjxGqFh += value;
			}
			remove
			{
				yuiaytJpAtEVJlsDQdvCEAjxGqFh -= value;
			}
		}

		public static event Action EditorRecompileEvent
		{
			add
			{
				uUscfsaRRMgEUxAVSYOBdnwjUJx += value;
			}
			remove
			{
				uUscfsaRRMgEUxAVSYOBdnwjUJx -= value;
			}
		}

		public static event Action PreShutDownEvent
		{
			add
			{
				iEjJzDzajVmJsTOlXBixkZGHcGai += value;
			}
			remove
			{
				iEjJzDzajVmJsTOlXBixkZGHcGai -= value;
			}
		}

		public static event Action ShutDownEvent
		{
			add
			{
				aQUJGRByEiEXNqAtpfhnVDawYDZ += value;
			}
			remove
			{
				aQUJGRByEiEXNqAtpfhnVDawYDZ -= value;
			}
		}

		public static event Action InitializedEvent
		{
			add
			{
				CwsGnWyAGEqkAcwKnlWWLMxZHzc += value;
			}
			remove
			{
				CwsGnWyAGEqkAcwKnlWWLMxZHzc -= value;
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
				vntQrbrkKdZWTszdWuZrMHBnpDZ = (Action)Delegate.Combine(vntQrbrkKdZWTszdWuZrMHBnpDZ, value);
			}
			remove
			{
				vntQrbrkKdZWTszdWuZrMHBnpDZ = (Action)Delegate.Remove(vntQrbrkKdZWTszdWuZrMHBnpDZ, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
				ozcWIsacTFpNmGLAgTojfzcyonW = (Action<UpdateLoopType>)Delegate.Combine(ozcWIsacTFpNmGLAgTojfzcyonW, value);
			}
			remove
			{
				ozcWIsacTFpNmGLAgTojfzcyonW = (Action<UpdateLoopType>)Delegate.Remove(ozcWIsacTFpNmGLAgTojfzcyonW, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
				qsuLbCZToKUUnPYbEKnsCsDTeel = (Action<UpdateLoopType>)Delegate.Combine(qsuLbCZToKUUnPYbEKnsCsDTeel, value);
			}
			remove
			{
				qsuLbCZToKUUnPYbEKnsCsDTeel = (Action<UpdateLoopType>)Delegate.Remove(qsuLbCZToKUUnPYbEKnsCsDTeel, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
				wLoMYBGXPwqksbsEiqdCOLTLOwH = (Action<UpdateLoopType>)Delegate.Combine(wLoMYBGXPwqksbsEiqdCOLTLOwH, value);
			}
			remove
			{
				wLoMYBGXPwqksbsEiqdCOLTLOwH = (Action<UpdateLoopType>)Delegate.Remove(wLoMYBGXPwqksbsEiqdCOLTLOwH, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action LateUpdateEvent
		{
			add
			{
				YWGdJgFpVdmvclIzdHWOMhNWTujk = (Action)Delegate.Combine(YWGdJgFpVdmvclIzdHWOMhNWTujk, value);
			}
			remove
			{
				YWGdJgFpVdmvclIzdHWOMhNWTujk = (Action)Delegate.Remove(YWGdJgFpVdmvclIzdHWOMhNWTujk, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
				LaRcLjSViUcgvqFoPCLnJbJgbQrq = (Action<bool>)Delegate.Combine(LaRcLjSViUcgvqFoPCLnJbJgbQrq, value);
			}
			remove
			{
				LaRcLjSViUcgvqFoPCLnJbJgbQrq = (Action<bool>)Delegate.Remove(LaRcLjSViUcgvqFoPCLnJbJgbQrq, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
				wqttiWsvbJdLLAHkctBTBwKUJwo = (Action<bool>)Delegate.Combine(wqttiWsvbJdLLAHkctBTBwKUJwo, value);
			}
			remove
			{
				wqttiWsvbJdLLAHkctBTBwKUJwo = (Action<bool>)Delegate.Remove(wqttiWsvbJdLLAHkctBTBwKUJwo, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
				jRduKrAhuxzvQsgxSARkhtQWACy = (Action<bool>)Delegate.Combine(jRduKrAhuxzvQsgxSARkhtQWACy, value);
			}
			remove
			{
				jRduKrAhuxzvQsgxSARkhtQWACy = (Action<bool>)Delegate.Remove(jRduKrAhuxzvQsgxSARkhtQWACy, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action SceneLoadedEvent
		{
			add
			{
				ZczdAdjbbuaFVNwaDpqQtCWKmBj = (Action)Delegate.Combine(ZczdAdjbbuaFVNwaDpqQtCWKmBj, value);
			}
			remove
			{
				ZczdAdjbbuaFVNwaDpqQtCWKmBj = (Action)Delegate.Remove(ZczdAdjbbuaFVNwaDpqQtCWKmBj, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> EditorPauseChangedEvent
		{
			add
			{
				wzLTVgfDmvVEdrlzFtHQOAGMBjS = (Action<bool>)Delegate.Combine(wzLTVgfDmvVEdrlzFtHQOAGMBjS, value);
			}
			remove
			{
				wzLTVgfDmvVEdrlzFtHQOAGMBjS = (Action<bool>)Delegate.Remove(wzLTVgfDmvVEdrlzFtHQOAGMBjS, value);
			}
		}

		static ReInput()
		{
			DbIfnSeTsZrarxRvEbGnotGXYOP = true;
			while (true)
			{
				int num = 1699110476;
				while (true)
				{
					switch (num ^ 0x65465E44)
					{
					case 19:
						break;
					case 13:
						oitWqXclBrDGXFUqewBLImZPvIX = new SafeAction<ControllerStatusChangedEventArgs>(OaciNJiksQpXpqpsqstbBUbOMJaC);
						if (iTIUNfkrngADvbAMBtQwnvUyAPT == null)
						{
							iTIUNfkrngADvbAMBtQwnvUyAPT = delegate(Exception P_0)
							{
								HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
							};
							num = 1699110479;
							continue;
						}
						goto case 11;
					case 10:
						iEjJzDzajVmJsTOlXBixkZGHcGai = new SafeAction(KHuwdLJfGgThnfYBrbOxhYxvFWc);
						if (aKYKKTPklWeTSnrfszjkZGFVelD == null)
						{
							aKYKKTPklWeTSnrfszjkZGFVelD = delegate(Exception P_0)
							{
								HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
							};
							num = 1699110465;
							continue;
						}
						goto case 5;
					case 6:
						TODKqlbTiotlvzHBygnoMXgfGhn = delegate(Exception P_0)
						{
							HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
						};
						num = 1699110475;
						continue;
					case 14:
						ggujuzDBxzioqbLydtugFDEiuZGB = new SafeAction<ControllerStatusChangedEventArgs>(decyKaUSyEGKbHNDKSnEMCGvfDT);
						num = 1699110486;
						continue;
					case 5:
						aQUJGRByEiEXNqAtpfhnVDawYDZ = new SafeAction(aKYKKTPklWeTSnrfszjkZGFVelD);
						num = 1699110472;
						continue;
					case 8:
						vVluxECgHHObLIBDngtyeEopTfz = -1;
						_id = -1;
						num = 1699110464;
						continue;
					case 3:
						OaciNJiksQpXpqpsqstbBUbOMJaC = delegate(Exception P_0)
						{
							HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
						};
						num = 1699110473;
						continue;
					case 1:
						CwsGnWyAGEqkAcwKnlWWLMxZHzc = new SafeAction(UioTSLrlZQEXgOsMPnnSNqTfIIb);
						num = 1699110470;
						continue;
					case 0:
						AUDGHcyHPPLEuDEOLcCudxKlwUE = ConfigHelper.Instance;
						num = 1699110467;
						continue;
					case 17:
						HqoMbNHClYgUMifZgaYtZkeZBurd = new SafeAction<ControllerStatusChangedEventArgs>(KMVSMNlcVvJaRclgBWSJrxykfCh);
						if (decyKaUSyEGKbHNDKSnEMCGvfDT == null)
						{
							decyKaUSyEGKbHNDKSnEMCGvfDT = delegate(Exception P_0)
							{
								HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
							};
							num = 1699110474;
							continue;
						}
						goto case 14;
					case 11:
					{
						yuiaytJpAtEVJlsDQdvCEAjxGqFh = new SafeAction(iTIUNfkrngADvbAMBtQwnvUyAPT);
						int num4;
						if (TODKqlbTiotlvzHBygnoMXgfGhn != null)
						{
							num = 1699110475;
							num4 = num;
						}
						else
						{
							num = 1699110466;
							num4 = num;
						}
						continue;
					}
					case 4:
						BqvGDajsNHDQFimaowoHWkmtcezJ = 0;
						VwhdbYJAGspHdCecSDipahRQBGhC = UnityTouch.Instance;
						nMAqgihSNTIWeKABbtKAmaICcOI = PlayerHelper.Instance;
						bwPdHPluauISSUMbOOibuKhSRfq = ControllerHelper.Instance;
						VQPmvtPFHSNMveDszHKjIBkUsAg = MappingHelper.Instance;
						LNVbxjuBfARbzvtwjPxUVnJqYoc = TimeHelper.Instance;
						num = 1699110468;
						continue;
					case 16:
						KMVSMNlcVvJaRclgBWSJrxykfCh = delegate(Exception P_0)
						{
							HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
						};
						num = 1699110485;
						continue;
					case 2:
						if (XiHoGooqxEyVXEDOyqTRocwCIzR == null)
						{
							XiHoGooqxEyVXEDOyqTRocwCIzR = delegate(Exception P_0)
							{
								HandleCallbackException("", P_0);
							};
							num = 1699110477;
							continue;
						}
						goto default;
					case 18:
					{
						int num3;
						if (OaciNJiksQpXpqpsqstbBUbOMJaC != null)
						{
							num = 1699110473;
							num3 = num;
						}
						else
						{
							num = 1699110471;
							num3 = num;
						}
						continue;
					}
					case 15:
						uUscfsaRRMgEUxAVSYOBdnwjUJx = new SafeAction(TODKqlbTiotlvzHBygnoMXgfGhn);
						if (KHuwdLJfGgThnfYBrbOxhYxvFWc == null)
						{
							KHuwdLJfGgThnfYBrbOxhYxvFWc = delegate(Exception P_0)
							{
								HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
							};
							num = 1699110478;
							continue;
						}
						goto case 10;
					case 7:
					{
						int num2;
						if (KMVSMNlcVvJaRclgBWSJrxykfCh == null)
						{
							num = 1699110484;
							num2 = num;
						}
						else
						{
							num = 1699110485;
							num2 = num;
						}
						continue;
					}
					case 12:
						if (UioTSLrlZQEXgOsMPnnSNqTfIIb == null)
						{
							UioTSLrlZQEXgOsMPnnSNqTfIIb = delegate(Exception P_0)
							{
								HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
							};
							num = 1699110469;
							continue;
						}
						goto case 1;
					default:
						SafeDelegate.S_ExceptionHandler = XiHoGooqxEyVXEDOyqTRocwCIzR;
						return;
					}
					break;
				}
			}
		}

		public static void Reset()
		{
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				while (true)
				{
					switch (0x1CDA6E49 ^ 0x1CDA6E4A)
					{
					case 0:
						break;
					case 3:
						return;
					case 1:
						goto end_IL_0007;
					default:
						goto IL_0046;
					}
					continue;
					end_IL_0007:
					break;
				}
			}
			if (slVUsRChRjTDGWipWiBmxpDDiza == null)
			{
				return;
			}
			goto IL_0046;
			IL_0046:
			slVUsRChRjTDGWipWiBmxpDDiza.ResetAll();
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			if (!inputAllowed)
			{
				return false;
			}
			if (TAeiTQcgMAUjxnGidzESNBdrZfL != EditorPlatform.None && (controllerType == ControllerType.Keyboard || controllerType == ControllerType.Mouse))
			{
				if (siTcmUMIEORCspmGInUXrqRhAmA)
				{
					if (!boBvGsJJUSYaUuLcYmbBJIEbOnn.bJapzHksrSKqatCVpdSUJVOFzgkf.value)
					{
						return false;
					}
				}
				else
				{
					if (!isAllowedEditorWindowFocused)
					{
						return false;
					}
					if (controllerType == ControllerType.Mouse && !isUnityEditorFocused)
					{
						return false;
					}
				}
			}
			return true;
		}

		internal static void YJaAHaimrHWIfKrgfWxeihnqrcza(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4)
		{
			try
			{
				_id = BqvGDajsNHDQFimaowoHWkmtcezJ;
				BqvGDajsNHDQFimaowoHWkmtcezJ++;
				PkVqugVNIpoYIMpSDcpjdJRrnVs = true;
				KKKoRVgqJBPLeLIfqHuOawpSzDv = true;
				if (UnityTools.isEditor)
				{
					goto IL_002c;
				}
				int num = 0;
				goto IL_032f;
				IL_0324:
				num = ((!Application.isPlaying) ? 1 : 0);
				goto IL_032f;
				IL_002c:
				int num2 = 2075882094;
				goto IL_0031;
				IL_0031:
				while (true)
				{
					switch (num2 ^ 0x7BBB7269)
					{
					case 14:
						break;
					default:
						return;
					case 10:
						ThreadSafeUnityInput.PostInitialize2();
						yhRlelsqiNUpDCFRMJbaNbHWeVF = UnityTools.GetComponent<UserDataStore>(slVUsRChRjTDGWipWiBmxpDDiza);
						if (yhRlelsqiNUpDCFRMJbaNbHWeVF != null)
						{
							yhRlelsqiNUpDCFRMJbaNbHWeVF.Initialize();
							num2 = 2075882093;
							continue;
						}
						goto case 4;
					case 1:
						nsJgCtIfwJQZurQxCSnuqEVGIyJc = P_2;
						XoBgevKuUNufHImfugJUwYrcLed = UnityTools.platform;
						hfpQRTMlbWHjpKZUTBjPrNSHOMN = UnityTools.webplayerPlatform;
						TAeiTQcgMAUjxnGidzESNBdrZfL = UnityTools.editorPlatform;
						if (P_2.logToScreen)
						{
							Logger.logToScreen = true;
							num2 = 2075882092;
							continue;
						}
						goto case 5;
					case 11:
						CheckRewiredVersionCompatibility();
						num2 = 2075882095;
						continue;
					case 6:
						slVUsRChRjTDGWipWiBmxpDDiza = P_0;
						num2 = 2075882088;
						continue;
					case 9:
						byhxjZCTTQmKqDmFbArjjMebEEiU = new EhxsPnRgLkJGhNLebiGYbKRcQisC();
						num2 = 2075882081;
						continue;
					case 16:
						CwsGnWyAGEqkAcwKnlWWLMxZHzc.Invoke();
						num2 = 2075882091;
						continue;
					case 4:
						FxmltkFMOBJxuWoQGhhMyNVSEOq();
						num2 = 2075882090;
						continue;
					case 3:
						KKKoRVgqJBPLeLIfqHuOawpSzDv = false;
						if (dGPMYixxEPuanNlkfwttgKrCAJn)
						{
							Logger.Log("Rewired is running in Edit mode.");
							num2 = 2075882085;
							continue;
						}
						goto IL_02bf;
					case 19:
						P_4.YJaAHaimrHWIfKrgfWxeihnqrcza();
						ThreadSafeUnityInput.Initialize();
						num2 = 2075882110;
						continue;
					case 23:
						goto IL_01a8;
					case 15:
						uzYFVAOPCugnffcKSwcZmFfGUjB = new GDZJmMlQvBAxDaQCuBIKYWggay(P_2, jdHrzjKbbHpmRevALLCPhhMcYEo);
						num2 = 2075882107;
						continue;
					case 17:
						boBvGsJJUSYaUuLcYmbBJIEbOnn.bJapzHksrSKqatCVpdSUJVOFzgkf.Set(isUnityEditorFocused && isAllowedEditorWindowFocused);
						num2 = 2075882089;
						continue;
					case 20:
						SRmblXnsFVNikIygzWSLnnYKyUa();
						num2 = 2075882083;
						continue;
					case 5:
						UnityTools.externalTools.EditorPausedStateChangedEvent += JdScRajqhDdTAtUtpPJWbsXkjTEZ;
						SfZmyxquROdGzGebXHktAifKfcyJ = P_3;
						HWKwbrcCuDRNpmsHSWlFyGHxmZJ = P_4;
						num2 = 2075882106;
						continue;
					case 0:
						wNLcewivNtYwCyizGFbOEPbANGl();
						eVnxwPuAIqSqjdCHfLTPnQqhOuS = new TimerAbs(1f);
						num2 = 2075882080;
						continue;
					case 21:
						ThreadSafeUnityInput.PostInitialize();
						num2 = 2075882109;
						continue;
					case 8:
						lZCArPkLoSgJaEkxbPbqcntMgGtG(P_1);
						fsQBYUGDBZAPIrofCevqCtlZgkl = new ELmeHFhAEObgGMupfccwkercFbWz(P_4.GetActions_Copy());
						num2 = 2075882086;
						continue;
					case 12:
						goto IL_02bf;
					case 22:
						boBvGsJJUSYaUuLcYmbBJIEbOnn.bJapzHksrSKqatCVpdSUJVOFzgkf.getValueDelegate = () => isUnityEditorFocused && isAllowedEditorWindowFocused;
						if (dGPMYixxEPuanNlkfwttgKrCAJn)
						{
							DbIfnSeTsZrarxRvEbGnotGXYOP = isEditorGameViewFocused;
							num2 = 2075882104;
							continue;
						}
						goto case 17;
					case 7:
						goto IL_0324;
					case 18:
						YYmRYrIJJDlFmDKErJxqlPcJEZJ = new aSOYcRCZqytuczbEAnlwvDhfgcsc(P_2);
						jdHrzjKbbHpmRevALLCPhhMcYEo.DeviceConnectedEvent += TfIrAJAexbdMuUiwCoHoYlpGvUd;
						jdHrzjKbbHpmRevALLCPhhMcYEo.DeviceDisconnectedEvent += iLVcRqRvCtyLIeebWiNxuHKxGis;
						jdHrzjKbbHpmRevALLCPhhMcYEo.UpdateControllerInfoEvent += cFCMwAHKZmlcjcqpdfsPHDXUvUN;
						uzYFVAOPCugnffcKSwcZmFfGUjB.ControllerDisconnectStartedEvent += HeGvTzrqFcKtPqKMHFQVjwREaxuH;
						num2 = 2075882084;
						continue;
					case 13:
						uzYFVAOPCugnffcKSwcZmFfGUjB.JustBeforeControllerFullyDisconnectedEvent += YYmRYrIJJDlFmDKErJxqlPcJEZJ.ZzjzlBbZnbZhcsABirkBCwgKwih;
						num2 = 2075882108;
						continue;
					case 2:
						return;
					}
					break;
					IL_01a8:
					boBvGsJJUSYaUuLcYmbBJIEbOnn = new pYoKnCCVfqdynEXLQmjerrJzGiIh();
					boBvGsJJUSYaUuLcYmbBJIEbOnn.bJapzHksrSKqatCVpdSUJVOFzgkf.Set(DbIfnSeTsZrarxRvEbGnotGXYOP);
					boBvGsJJUSYaUuLcYmbBJIEbOnn.bJapzHksrSKqatCVpdSUJVOFzgkf.Use();
					int num3;
					if (TAeiTQcgMAUjxnGidzESNBdrZfL != EditorPlatform.None)
					{
						num2 = 2075882111;
						num3 = num2;
					}
					else
					{
						num2 = 2075882089;
						num3 = num2;
					}
					continue;
					IL_02bf:
					int num4;
					if (CwsGnWyAGEqkAcwKnlWWLMxZHzc != null)
					{
						num2 = 2075882105;
						num4 = num2;
					}
					else
					{
						num2 = 2075882091;
						num4 = num2;
					}
				}
				goto IL_002c;
				IL_032f:
				dGPMYixxEPuanNlkfwttgKrCAJn = (byte)num != 0;
				int num5;
				if (UnityTools.isEditor)
				{
					num2 = 2075882082;
					num5 = num2;
				}
				else
				{
					num2 = 2075882095;
					num5 = num2;
				}
				goto IL_0031;
			}
			catch (Exception ex)
			{
				while (true)
				{
					int num6 = 2075882088;
					while (true)
					{
						switch (num6 ^ 0x7BBB7269)
						{
						case 2:
							break;
						case 1:
							goto IL_0401;
						default:
							KKKoRVgqJBPLeLIfqHuOawpSzDv = false;
							throw ex;
						}
						break;
						IL_0401:
						PkVqugVNIpoYIMpSDcpjdJRrnVs = false;
						num6 = 2075882089;
					}
				}
			}
		}

		internal static void HTeWiJSswgFIFVAtPBCSclhPFDl()
		{
			if (byhxjZCTTQmKqDmFbArjjMebEEiU != null)
			{
				goto IL_0007;
			}
			goto IL_0050;
			IL_0007:
			int num = 1398043978;
			goto IL_000c;
			IL_000c:
			Joystick joystick = default(Joystick);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x5354754B)
				{
				case 2:
					break;
				default:
					return;
				case 6:
					joystick = uzYFVAOPCugnffcKSwcZmFfGUjB.Joysticks_readOnly[num2];
					num = 1398043979;
					continue;
				case 4:
					goto IL_0050;
				case 5:
					goto IL_0065;
				case 1:
					byhxjZCTTQmKqDmFbArjjMebEEiU.QKQqmYzrJRcHvrgQkDkYyDOslGG();
					num = 1398043983;
					continue;
				case 0:
					alCUyUtvfUaetHJyrcbCIiXFfQsz(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
					num2++;
					num = 1398043982;
					continue;
				case 3:
					return;
				}
				break;
				IL_0065:
				int num3;
				if (num2 < uzYFVAOPCugnffcKSwcZmFfGUjB.joystickCount)
				{
					num = 1398043981;
					num3 = num;
				}
				else
				{
					num = 1398043976;
					num3 = num;
				}
			}
			goto IL_0007;
			IL_0050:
			if (configVars.deferControllerConnectedEventsOnStart)
			{
				num2 = 0;
				num = 1398043982;
				goto IL_000c;
			}
		}

		internal static void mHzPvDIYDGoChNcnPSzgyYaRzPK(UpdateLoopType P_0)
		{
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				return;
			}
			while (true)
			{
				MfqtTKMJYKxULLKLXLloixpfsqd(P_0);
				int num = -1263259322;
				while (true)
				{
					switch (num ^ -1263259322)
					{
					case 2:
						goto IL_0008;
					case 1:
						break;
					case 0:
						switch (P_0)
						{
						default:
							return;
						case UpdateLoopType.Update:
						case UpdateLoopType.FixedUpdate:
							break;
						}
						goto default;
					default:
						mkckTroaLWabcNXFfBuucaAwbSlp();
						return;
					}
					break;
					IL_0008:
					num = -1263259321;
				}
			}
		}

		private static void MfqtTKMJYKxULLKLXLloixpfsqd(UpdateLoopType P_0)
		{
			if (boBvGsJJUSYaUuLcYmbBJIEbOnn != null)
			{
				while (true)
				{
					int num = 894376938;
					while (true)
					{
						switch (num ^ 0x354F1BE8)
						{
						case 0:
							break;
						case 2:
							boBvGsJJUSYaUuLcYmbBJIEbOnn.UZSQFwoMfSAzsmmSKmseCCiJWWD();
							num = 894376937;
							continue;
						default:
							goto end_IL_0007;
						}
						break;
					}
					continue;
					end_IL_0007:
					break;
				}
			}
			Action<UpdateLoopType> action = ozcWIsacTFpNmGLAgTojfzcyonW;
			if (action != null)
			{
				try
				{
					action(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.BeforeTimeManagerUpdateEvent", exception);
				}
			}
			byhxjZCTTQmKqDmFbArjjMebEEiU.UZSQFwoMfSAzsmmSKmseCCiJWWD(P_0);
		}

		private static void mkckTroaLWabcNXFfBuucaAwbSlp()
		{
			int frameCount = Time.frameCount;
			if (vVluxECgHHObLIBDngtyeEopTfz == frameCount)
			{
				return;
			}
			while (true)
			{
				vVluxECgHHObLIBDngtyeEopTfz = frameCount;
				ThreadSafeUnityInput.Update();
				Action action = vntQrbrkKdZWTszdWuZrMHBnpDZ;
				int num = 1752021861;
				while (true)
				{
					switch (num ^ 0x686DBB67)
					{
					case 0:
						goto IL_000f;
					case 1:
						break;
					default:
						if (action != null)
						{
							try
							{
								action();
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
					break;
					IL_000f:
					num = 1752021862;
				}
			}
		}

		internal static void UZSQFwoMfSAzsmmSKmseCCiJWWD(UpdateLoopType P_0)
		{
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				return;
			}
			Action<UpdateLoopType> action = default(Action<UpdateLoopType>);
			Action<UpdateLoopType> action2 = default(Action<UpdateLoopType>);
			while (true)
			{
				IL_008b:
				int num;
				if (uRiFqecNVABhPpjlbdnEZbQCduHT != P_0)
				{
					uRiFqecNVABhPpjlbdnEZbQCduHT = P_0;
					num = -1012763112;
					goto IL_0010;
				}
				goto IL_0057;
				IL_00c9:
				int num2;
				if (!TEUkumnGqcKoeDfMZAvHWiKrVAA)
				{
					num = -1012763110;
					num2 = num;
				}
				else
				{
					num = -1012763105;
					num2 = num;
				}
				goto IL_0010;
				IL_0057:
				if (editorPlatform != EditorPlatform.None)
				{
					FfmOuXPsLyiXOYRGYqCvUomXEtf = boBvGsJJUSYaUuLcYmbBJIEbOnn.vcMaKVKsPSGEibJzuaIhEyChSBsI.value;
					num = -1012763109;
					goto IL_0010;
				}
				goto IL_00c9;
				IL_0010:
				while (true)
				{
					switch (num ^ -1012763106)
					{
					case 0:
						num = -1012763108;
						continue;
					case 4:
						boBvGsJJUSYaUuLcYmbBJIEbOnn.JBUJYqkBSdjOUTpqLXKBOxBQzIF();
						action = qsuLbCZToKUUnPYbEKnsCsDTeel;
						num = -1012763111;
						continue;
					case 6:
						break;
					case 3:
						unityInputBuffer.UZSQFwoMfSAzsmmSKmseCCiJWWD(P_0);
						num = -1012763110;
						continue;
					case 2:
						goto IL_008b;
					case 1:
						if (eVnxwPuAIqSqjdCHfLTPnQqhOuS.Update())
						{
							TEUkumnGqcKoeDfMZAvHWiKrVAA = false;
							eVnxwPuAIqSqjdCHfLTPnQqhOuS.Clear();
							num = -1012763110;
							continue;
						}
						goto case 3;
					case 5:
						goto IL_00c9;
					default:
						if (action != null)
						{
							try
							{
								action(P_0);
							}
							catch (Exception exception)
							{
								HandleCallbackException("ReInput.UpdateStartedEvent", exception);
							}
						}
						jdHrzjKbbHpmRevALLCPhhMcYEo.Update(P_0);
						while (true)
						{
							int num3 = -1012763105;
							while (true)
							{
								switch (num3 ^ -1012763106)
								{
								case 2:
									break;
								case 1:
									if (yuiaytJpAtEVJlsDQdvCEAjxGqFh != null)
									{
										yuiaytJpAtEVJlsDQdvCEAjxGqFh.Invoke();
										num3 = -1012763107;
										continue;
									}
									goto case 3;
								case 3:
									uzYFVAOPCugnffcKSwcZmFfGUjB.UZSQFwoMfSAzsmmSKmseCCiJWWD(P_0);
									action2 = wLoMYBGXPwqksbsEiqdCOLTLOwH;
									num3 = -1012763106;
									continue;
								default:
									if (action2 == null)
									{
										return;
									}
									try
									{
										action2(P_0);
										return;
									}
									catch (Exception exception2)
									{
										while (true)
										{
											int num4 = -1012763108;
											while (true)
											{
												switch (num4 ^ -1012763106)
												{
												case 0:
													break;
												default:
													return;
												case 2:
													goto IL_0186;
												case 1:
													return;
												}
												break;
												IL_0186:
												HandleCallbackException("ReInput.UpdateEndedEvent", exception2);
												num4 = -1012763105;
											}
										}
									}
								}
								break;
							}
						}
					}
					break;
				}
				goto IL_0057;
			}
		}

		internal static void SAOvBBbpeoGAhEwYskaoZLmoMij()
		{
			Action yWGdJgFpVdmvclIzdHWOMhNWTujk = YWGdJgFpVdmvclIzdHWOMhNWTujk;
			if (yWGdJgFpVdmvclIzdHWOMhNWTujk != null)
			{
				try
				{
					yWGdJgFpVdmvclIzdHWOMhNWTujk();
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
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				return;
			}
			while (true)
			{
				int num = 486938768;
				while (true)
				{
					switch (num ^ 0x1D061894)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						mHzPvDIYDGoChNcnPSzgyYaRzPK(UpdateLoopType.Update);
						UZSQFwoMfSAzsmmSKmseCCiJWWD(UpdateLoopType.Update);
						SAOvBBbpeoGAhEwYskaoZLmoMij();
						num = 486938773;
						continue;
					case 2:
						return;
					case 4:
					{
						int num2;
						if (!dGPMYixxEPuanNlkfwttgKrCAJn)
						{
							num = 486938774;
							num2 = num;
						}
						else
						{
							num = 486938775;
							num2 = num;
						}
						continue;
					}
					case 1:
						return;
					}
					break;
				}
			}
		}

		internal static void unwXDbTGcreCTKEOFdJSrnMHNGeK()
		{
			if (iEjJzDzajVmJsTOlXBixkZGHcGai != null)
			{
				goto IL_0007;
			}
			goto IL_0081;
			IL_0007:
			int num = -1212432158;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ -1212432157)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					iEjJzDzajVmJsTOlXBixkZGHcGai.Invoke();
					num = -1212432153;
					continue;
				case 5:
					aQUJGRByEiEXNqAtpfhnVDawYDZ.Invoke();
					num = -1212432155;
					continue;
				case 3:
					goto IL_0057;
				case 6:
					aQUJGRByEiEXNqAtpfhnVDawYDZ = null;
					num = -1212432159;
					continue;
				case 4:
					goto IL_0081;
				case 2:
					return;
				}
				break;
			}
			goto IL_0007;
			IL_0057:
			joMHNyzTHwbdiENllpwCAmGeGCt();
			int num2;
			if (aQUJGRByEiEXNqAtpfhnVDawYDZ == null)
			{
				num = -1212432159;
				num2 = num;
			}
			else
			{
				num = -1212432154;
				num2 = num;
			}
			goto IL_000c;
			IL_0081:
			if (jdHrzjKbbHpmRevALLCPhhMcYEo != null)
			{
				jdHrzjKbbHpmRevALLCPhhMcYEo.OnDestroy();
				num = -1212432160;
				goto IL_000c;
			}
			goto IL_0057;
		}

		internal static void CNeIVVuWULdFyKFIYCKvjGpjiyJy()
		{
			if (uUscfsaRRMgEUxAVSYOBdnwjUJx == null)
			{
				while (true)
				{
					switch (0x32BEF9EB ^ 0x32BEF9EA)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			uUscfsaRRMgEUxAVSYOBdnwjUJx.Invoke();
		}

		internal static void EDMLfpLtLFmhqzkIkCmkCoWTnga(bool P_0)
		{
			DbIfnSeTsZrarxRvEbGnotGXYOP = P_0;
			if (TAeiTQcgMAUjxnGidzESNBdrZfL != EditorPlatform.None)
			{
				while (true)
				{
					switch (0x3C69F133 ^ 0x3C69F130)
					{
					case 0:
						break;
					case 3:
						return;
					case 1:
						goto end_IL_000d;
					default:
						goto IL_0046;
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				return;
			}
			goto IL_0046;
			IL_0046:
			boBvGsJJUSYaUuLcYmbBJIEbOnn.bJapzHksrSKqatCVpdSUJVOFzgkf.Set(P_0);
			boBvGsJJUSYaUuLcYmbBJIEbOnn.bJapzHksrSKqatCVpdSUJVOFzgkf.TriggerEvent();
		}

		internal static void EgYgUWpmpSSstJYXGSMKUkAFAed()
		{
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				goto IL_0007;
			}
			goto IL_0031;
			IL_0007:
			int num = 1171090155;
			goto IL_000c;
			IL_000c:
			Action zczdAdjbbuaFVNwaDpqQtCWKmBj = default(Action);
			switch (num ^ 0x45CD6AEA)
			{
			case 3:
				break;
			case 1:
				return;
			case 0:
				goto IL_0031;
			default:
				if (zczdAdjbbuaFVNwaDpqQtCWKmBj != null)
				{
					try
					{
						zczdAdjbbuaFVNwaDpqQtCWKmBj();
						return;
					}
					catch (Exception exception)
					{
						HandleCallbackException("ReInput.SceneLoadedEvent", exception);
						return;
					}
				}
				return;
			}
			goto IL_0007;
			IL_0031:
			zczdAdjbbuaFVNwaDpqQtCWKmBj = ZczdAdjbbuaFVNwaDpqQtCWKmBj;
			num = 1171090152;
			goto IL_000c;
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return SfZmyxquROdGzGebXHktAifKfcyJ.pFLIeNMFmNtfEwbFvGhBCCBfeRDd(bridgedController);
		}

		internal static HardwareJoystickMap KMGdcXDLnbZuPYvzFIqeDgBsQnv(Guid P_0)
		{
			return SfZmyxquROdGzGebXHktAifKfcyJ.GetHardwareJoystickMap(P_0);
		}

		internal static HardwareJoystickTemplateMap GQIAEUrSKudAJFshKLEiDynhHAON(Guid P_0)
		{
			return SfZmyxquROdGzGebXHktAifKfcyJ.GetJoystickTemplate(P_0);
		}

		internal static IHardwareControllerTemplateMap tHBHtolwXhpDjQmEcGjECOnZjMBA(Guid P_0)
		{
			return SfZmyxquROdGzGebXHktAifKfcyJ.GetControllerTemplate(P_0);
		}

		internal static IList<HardwareJoystickTemplateMap> oKiFpADtDgRKbCjxFcbRklAzcrvC(Guid P_0)
		{
			HardwareJoystickMap hardwareJoystickMap = SfZmyxquROdGzGebXHktAifKfcyJ.GetHardwareJoystickMap(P_0);
			string[] templateGuidsOrig = default(string[]);
			List<HardwareJoystickTemplateMap> list = default(List<HardwareJoystickTemplateMap>);
			int num2 = default(int);
			HardwareJoystickTemplateMap hardwareJoystickTemplateMap = default(HardwareJoystickTemplateMap);
			while (true)
			{
				int num = 2116156968;
				while (true)
				{
					switch (num ^ 0x7E21FE29)
					{
					case 4:
						break;
					case 1:
						if (hardwareJoystickMap == null)
						{
							return EmptyObjects<HardwareJoystickTemplateMap>.EmptyReadOnlyIListT;
						}
						templateGuidsOrig = hardwareJoystickMap.GetTemplateGuidsOrig();
						num = 2116156970;
						continue;
					case 3:
						if (templateGuidsOrig != null)
						{
							if (templateGuidsOrig.Length == 0)
							{
								num = 2116156971;
								continue;
							}
							list = null;
							num2 = 0;
							num = 2116156969;
							continue;
						}
						goto case 2;
					case 2:
						return EmptyObjects<HardwareJoystickTemplateMap>.EmptyReadOnlyIListT;
					default:
						while (num2 < templateGuidsOrig.Length)
						{
							Guid guid;
							try
							{
								guid = new Guid(templateGuidsOrig[num2]);
							}
							catch
							{
								Logger.LogWarning("Controller Template GUID is invalid: " + templateGuidsOrig[num2]);
								goto IL_010c;
							}
							hardwareJoystickTemplateMap = GQIAEUrSKudAJFshKLEiDynhHAON(guid);
							if (!(hardwareJoystickTemplateMap == null))
							{
								goto IL_00ec;
							}
							Logger.LogWarning("Controller Template was not found for GUID " + guid.ToString());
							goto IL_010c;
							IL_00cb:
							int num3;
							while (true)
							{
								switch (num3 ^ 0x7E21FE29)
								{
								case 0:
									num3 = 2116156970;
									continue;
								case 3:
									break;
								case 2:
									goto IL_00fc;
								case 1:
									goto IL_010c;
								default:
									goto IL_0117;
								}
								break;
							}
							goto IL_00ec;
							IL_00ec:
							if (list == null)
							{
								list = new List<HardwareJoystickTemplateMap>();
								num3 = 2116156971;
								goto IL_00cb;
							}
							goto IL_00fc;
							IL_00fc:
							ListTools.AddIfUnique(list, hardwareJoystickTemplateMap);
							num3 = 2116156968;
							goto IL_00cb;
							IL_010c:
							num2++;
							num3 = 2116156973;
							goto IL_00cb;
							IL_0117:;
						}
						if (list == null)
						{
							return EmptyObjects<HardwareJoystickTemplateMap>.EmptyReadOnlyIListT;
						}
						return list;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int GetNewJoystickId()
		{
			return uzYFVAOPCugnffcKSwcZmFfGUjB.UQzWJBealOjhTSlSnpEFEtDicBl();
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleCallbackException(string source, Exception exception)
		{
			object[] array = new object[4] { "Rewired: An exception occurred inside an event handler or callback.\nSource: ", null, null, null };
			while (true)
			{
				int num = -1905107238;
				while (true)
				{
					switch (num ^ -1905107237)
					{
					case 3:
						break;
					case 1:
						array[1] = source;
						num = -1905107239;
						continue;
					case 2:
						array[2] = "\n\nThis happens if your event handler/callback code throws an exception. This means the error in your code, not Rewired. Read the exception message and the stack trace carefully to find the source of the exception being thrown by your code.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed. Make sure you unsubscribe to events in OnDisable or OnDestroy. Rewired will attempt to continue running.\n\nException:\n";
						array[3] = exception;
						num = -1905107237;
						continue;
					default:
					{
						string msg = string.Concat(array);
						Logger.LogError(msg, true);
						return;
					}
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleExternException(string source, Exception exception)
		{
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleExternalInterfaceException(string source, Exception exception)
		{
			object[] array = new object[4];
			string msg = default(string);
			while (true)
			{
				int num = -1973828549;
				while (true)
				{
					switch (num ^ -1973828550)
					{
					case 2:
						break;
					case 1:
						array[0] = "Rewired: An exception occurred inside an external function call.\nSource: ";
						array[1] = source;
						array[2] = "\n\nThis happens if the external function throws an exception. This could indicate the error is in your code if Rewired is calling a function in an interface implementation you created. Read the exception message and the stack trace carefully to find the source of the exception being thrown.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed.\n\nException:\n";
						num = -1973828550;
						continue;
					case 0:
						array[3] = exception;
						msg = string.Concat(array);
						num = -1973828551;
						continue;
					default:
						Logger.LogError(msg, true);
						return;
					}
					break;
				}
			}
		}

		internal static void RlfZIISmAMxUwhwhvGFGXAlZCwn()
		{
			if (PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				FxmltkFMOBJxuWoQGhhMyNVSEOq();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
			if (!(UnityTools.unityVersionObj != null) || 2017 == UnityTools.unityVersionObj.major)
			{
				return;
			}
			while (true)
			{
				int num = 1723820233;
				while (true)
				{
					switch (num ^ 0x66BF68C8)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_003c;
					case 0:
						return;
					}
					break;
					IL_003c:
					EYObgztApnHauLDkTATuAqqDpKf();
					num = 1723820232;
				}
			}
		}

		internal static float aYzppXbiwhRevgRvHlcJJfkjnTD()
		{
			return boBvGsJJUSYaUuLcYmbBJIEbOnn.BQJHdWatcmMaoTVinhliSIFKncn.value;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized()
		{
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
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
				Logger.LogError("You are attemping to access an object that was created by a previous session or different instance of Rewired and is no longer valid. When Rewired is reset or the Rewired Input Manager is disabled or destroyed, all old object references become invalid and can no longer be used. If you deinitialize Rewired, you cannot use locally stored Rewired objects obtained prior to deinitialization and you must get new objects from the Rewired API.");
				return false;
			}
			return true;
		}

		private static void SRmblXnsFVNikIygzWSLnnYKyUa()
		{
			YYmRYrIJJDlFmDKErJxqlPcJEZJ.YJaAHaimrHWIfKrgfWxeihnqrcza();
			uzYFVAOPCugnffcKSwcZmFfGUjB.YJaAHaimrHWIfKrgfWxeihnqrcza(jdHrzjKbbHpmRevALLCPhhMcYEo.GetInputDataUpdateDelegate(), HWKwbrcCuDRNpmsHSWlFyGHxmZJ.GetInputBehaviors_Copy());
			jdHrzjKbbHpmRevALLCPhhMcYEo.Initialize();
		}

		private static void joMHNyzTHwbdiENllpwCAmGeGCt()
		{
			if (!(slVUsRChRjTDGWipWiBmxpDDiza != null))
			{
				goto IL_012f;
			}
			List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(slVUsRChRjTDGWipWiBmxpDDiza);
			int num = 0;
			goto IL_017f;
			IL_0027:
			int num2;
			while (true)
			{
				switch (num2 ^ 0x293E6B04)
				{
				case 21:
					num2 = 691956503;
					continue;
				default:
					return;
				case 17:
					YYmRYrIJJDlFmDKErJxqlPcJEZJ = null;
					SfZmyxquROdGzGebXHktAifKfcyJ = null;
					HWKwbrcCuDRNpmsHSWlFyGHxmZJ = null;
					num2 = 691956482;
					continue;
				case 2:
					LaRcLjSViUcgvqFoPCLnJbJgbQrq = null;
					wqttiWsvbJdLLAHkctBTBwKUJwo = null;
					jRduKrAhuxzvQsgxSARkhtQWACy = null;
					num2 = 691956481;
					continue;
				case 13:
					eVnxwPuAIqSqjdCHfLTPnQqhOuS = null;
					byhxjZCTTQmKqDmFbArjjMebEEiU = null;
					num2 = 691956502;
					continue;
				case 9:
					iEjJzDzajVmJsTOlXBixkZGHcGai = null;
					ZczdAdjbbuaFVNwaDpqQtCWKmBj = null;
					wzLTVgfDmvVEdrlzFtHQOAGMBjS = null;
					num2 = 691956488;
					continue;
				case 19:
					componentsInSelfAndChildren[num].Deinitialize();
					num2 = 691956496;
					continue;
				case 4:
					uUscfsaRRMgEUxAVSYOBdnwjUJx.Clear();
					num2 = 691956498;
					continue;
				case 10:
					break;
				case 16:
					uzYFVAOPCugnffcKSwcZmFfGUjB = null;
					num2 = 691956501;
					continue;
				case 20:
					num++;
					num2 = 691956487;
					continue;
				case 6:
					nIhEXAJwaQdlbfpmXetDZHGNHWn = null;
					PkVqugVNIpoYIMpSDcpjdJRrnVs = false;
					num2 = 691956490;
					continue;
				case 3:
					goto IL_017f;
				case 7:
					NQSAaKpVXFTtpEYlkOfJfYnAXKF = false;
					XoBgevKuUNufHImfugJUwYrcLed = Platform.Windows;
					hfpQRTMlbWHjpKZUTBjPrNSHOMN = WebplayerPlatform.None;
					TAeiTQcgMAUjxnGidzESNBdrZfL = EditorPlatform.None;
					TEUkumnGqcKoeDfMZAvHWiKrVAA = false;
					num2 = 691956489;
					continue;
				case 23:
					oitWqXclBrDGXFUqewBLImZPvIX.Clear();
					yuiaytJpAtEVJlsDQdvCEAjxGqFh.Clear();
					num2 = 691956480;
					continue;
				case 12:
					zlTamOIVGxORQadPEUGfkxjPgox();
					num2 = 691956491;
					continue;
				case 18:
					FfmOuXPsLyiXOYRGYqCvUomXEtf = null;
					siTcmUMIEORCspmGInUXrqRhAmA = false;
					num2 = 691956485;
					continue;
				case 5:
					vntQrbrkKdZWTszdWuZrMHBnpDZ = null;
					qsuLbCZToKUUnPYbEKnsCsDTeel = null;
					wLoMYBGXPwqksbsEiqdCOLTLOwH = null;
					YWGdJgFpVdmvclIzdHWOMhNWTujk = null;
					num2 = 691956493;
					continue;
				case 0:
					DbIfnSeTsZrarxRvEbGnotGXYOP = true;
					vVluxECgHHObLIBDngtyeEopTfz = -1;
					_id = -1;
					xLfxhFLZjQdLUWRyswoZPONPxBz = 0;
					HqoMbNHClYgUMifZgaYtZkeZBurd.Clear();
					ggujuzDBxzioqbLydtugFDEiuZGB.Clear();
					num2 = 691956499;
					continue;
				case 14:
					nsJgCtIfwJQZurQxCSnuqEVGIyJc = null;
					uRiFqecNVABhPpjlbdnEZbQCduHT = UpdateLoopType.Update;
					num2 = 691956483;
					continue;
				case 24:
					if (UnityTools.externalTools != null)
					{
						UnityTools.externalTools.EditorPausedStateChangedEvent -= JdScRajqhDdTAtUtpPJWbsXkjTEZ;
						num2 = 691956492;
						continue;
					}
					return;
				case 15:
					boBvGsJJUSYaUuLcYmbBJIEbOnn = null;
					ThreadSafeUnityInput.Deinitialize();
					num2 = 691956508;
					continue;
				case 1:
					dGPMYixxEPuanNlkfwttgKrCAJn = false;
					num2 = 691956484;
					continue;
				case 22:
					_ApplicationFocusChangedEvent = null;
					num2 = 691956486;
					continue;
				case 11:
					if (uzYFVAOPCugnffcKSwcZmFfGUjB != null)
					{
						uzYFVAOPCugnffcKSwcZmFfGUjB.Dispose();
						num2 = 691956500;
						continue;
					}
					goto case 16;
				case 8:
					return;
				}
				break;
			}
			goto IL_012f;
			IL_017f:
			int num3;
			if (num < componentsInSelfAndChildren.Count)
			{
				num2 = 691956503;
				num3 = num2;
			}
			else
			{
				num2 = 691956494;
				num3 = num2;
			}
			goto IL_0027;
			IL_012f:
			slVUsRChRjTDGWipWiBmxpDDiza = null;
			jdHrzjKbbHpmRevALLCPhhMcYEo = null;
			fsQBYUGDBZAPIrofCevqCtlZgkl = null;
			num2 = 691956495;
			goto IL_0027;
		}

		private static void fRDfgPYvmRFAIsBVCPMYdnIWviv(string P_0 = null)
		{
			if (P_0 != null)
			{
				goto IL_0003;
			}
			goto IL_002e;
			IL_0003:
			int num = -996895072;
			goto IL_0008;
			IL_0008:
			string text = default(string);
			while (true)
			{
				switch (num ^ -996895071)
				{
				case 0:
					break;
				case 1:
					text = P_0;
					num = -996895070;
					continue;
				case 2:
					goto IL_002e;
				default:
					Logger.LogError(text + " can only be called in Play mode!");
					return;
				}
				break;
			}
			goto IL_0003;
			IL_002e:
			text = "This function";
			num = -996895070;
			goto IL_0008;
		}

		private static void AlDeMuQZTTTXPcyefOlYwtDjppQ()
		{
			if (!TEUkumnGqcKoeDfMZAvHWiKrVAA)
			{
				while (true)
				{
					int num = -2124404367;
					while (true)
					{
						switch (num ^ -2124404366)
						{
						case 2:
							break;
						case 3:
							TEUkumnGqcKoeDfMZAvHWiKrVAA = true;
							num = -2124404366;
							continue;
						case 0:
							unityInputBuffer.nympziBLtYDUiPlWNRoEGqbSPfa();
							unityInputBuffer.BJTLXEjtRzwGSeFtYEySLofTbdi();
							num = -2124404365;
							continue;
						default:
							goto end_IL_0007;
						}
						break;
					}
					continue;
					end_IL_0007:
					break;
				}
			}
			eVnxwPuAIqSqjdCHfLTPnQqhOuS.Start();
		}

		private static void oRdMvvHeXoBVjiPOAZrrkCGwKZc()
		{
			Logger.LogError("Rewired is not initialized. Do you have a Rewired Input Manager in the scene and enabled?");
		}

		private static void TfIrAJAexbdMuUiwCoHoYlpGvUd(BridgedController P_0)
		{
			if (P_0.sourceJoystick == null)
			{
				goto IL_0008;
			}
			goto IL_0080;
			IL_0008:
			int num = -1571827958;
			goto IL_000d;
			IL_000d:
			Joystick joystick = default(Joystick);
			while (true)
			{
				switch (num ^ -1571827959)
				{
				case 0:
					break;
				case 3:
					return;
				case 1:
				{
					YYmRYrIJJDlFmDKErJxqlPcJEZJ.QzuwmtOhlLCOpHQfwELOgjJhsYId(joystick);
					int num2;
					if (!configVars.deferControllerConnectedEventsOnStart)
					{
						num = -1571827953;
						num2 = num;
					}
					else
					{
						num = -1571827955;
						num2 = num;
					}
					continue;
				}
				case 4:
					if (KKKoRVgqJBPLeLIfqHuOawpSzDv)
					{
						return;
					}
					goto default;
				case 5:
					if (joystick == null)
					{
						return;
					}
					goto case 1;
				case 2:
					goto IL_0080;
				default:
					alCUyUtvfUaetHJyrcbCIiXFfQsz(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0080:
			uzYFVAOPCugnffcKSwcZmFfGUjB.MUZomcvffRvxBbnbXumOjuySHCf(P_0);
			joystick = uzYFVAOPCugnffcKSwcZmFfGUjB.HdBPhTkbiFfgMcBErhvqAsSyrQkh(P_0.sourceJoystick.rewiredId);
			num = -1571827956;
			goto IL_000d;
		}

		private static void iLVcRqRvCtyLIeebWiNxuHKxGis(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				Joystick joystick = uzYFVAOPCugnffcKSwcZmFfGUjB.HdBPhTkbiFfgMcBErhvqAsSyrQkh(P_0.rewiredId);
				if (joystick == null)
				{
					break;
				}
				while (true)
				{
					IL_0047:
					uzYFVAOPCugnffcKSwcZmFfGUjB.kijbodcZCTsLoFANBiNEaBqeVJqy(P_0.rewiredId);
					int num = -434325875;
					while (true)
					{
						switch (num ^ -434325879)
						{
						case 2:
							num = -434325878;
							continue;
						default:
							return;
						case 3:
							break;
						case 0:
							goto IL_0047;
						case 4:
							GRnmfKVMCbfRJfmKODrTuOsjjHY(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
							num = -434325880;
							continue;
						case 1:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		private static void alCUyUtvfUaetHJyrcbCIiXFfQsz(ControllerStatusChangedEventArgs P_0)
		{
			if (HqoMbNHClYgUMifZgaYtZkeZBurd != null)
			{
				HqoMbNHClYgUMifZgaYtZkeZBurd.Invoke(P_0);
			}
		}

		private static void HeGvTzrqFcKtPqKMHFQVjwREaxuH(ControllerStatusChangedEventArgs P_0)
		{
			if (ggujuzDBxzioqbLydtugFDEiuZGB == null)
			{
				return;
			}
			while (true)
			{
				int num = 1899120042;
				while (true)
				{
					switch (num ^ 0x713245AB)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0025;
					case 0:
						return;
					}
					break;
					IL_0025:
					ggujuzDBxzioqbLydtugFDEiuZGB.Invoke(P_0);
					num = 1899120043;
				}
			}
		}

		private static void GRnmfKVMCbfRJfmKODrTuOsjjHY(ControllerStatusChangedEventArgs P_0)
		{
			if (oitWqXclBrDGXFUqewBLImZPvIX == null)
			{
				return;
			}
			while (true)
			{
				int num = 323993611;
				while (true)
				{
					switch (num ^ 0x134FC009)
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
					oitWqXclBrDGXFUqewBLImZPvIX.Invoke(P_0);
					num = 323993608;
				}
			}
		}

		private static void cFCMwAHKZmlcjcqpdfsPHDXUvUN(UpdateControllerInfoEventArgs P_0)
		{
			uzYFVAOPCugnffcKSwcZmFfGUjB.KvDObPgkKVXEfRCBiWbffrDzKAV(P_0);
		}

		private static void EyzHgLRlWvcWTAWdkRJsusIxnhij(bool P_0)
		{
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				return;
			}
			Action<bool> applicationFocusChangedEvent = _ApplicationFocusChangedEvent;
			if (applicationFocusChangedEvent == null)
			{
				return;
			}
			try
			{
				applicationFocusChangedEvent(P_0);
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.ApplicationFocusChangedEvent", exception);
			}
		}

		private static void HfwYfRoxmRwUdwadectDCKAldT(bool P_0)
		{
			Action<bool> laRcLjSViUcgvqFoPCLnJbJgbQrq = LaRcLjSViUcgvqFoPCLnJbJgbQrq;
			if (laRcLjSViUcgvqFoPCLnJbJgbQrq != null)
			{
				try
				{
					laRcLjSViUcgvqFoPCLnJbJgbQrq(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationIsFullScreenChangedEvent", exception);
				}
			}
		}

		private static void LjKkXyiBGXooLPkKXInbbrJJuRG(bool P_0)
		{
			Action<bool> action = wqttiWsvbJdLLAHkctBTBwKUJwo;
			if (action != null)
			{
				try
				{
					action(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationRunInBackgroundChangedEvent", exception);
				}
			}
		}

		private static void xLRaVbExgLBPjYoZAVMldSQFzrv(bool P_0)
		{
			xLfxhFLZjQdLUWRyswoZPONPxBz++;
			Action<bool> action = jRduKrAhuxzvQsgxSARkhtQWACy;
			if (action != null)
			{
				try
				{
					action(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.TimeScalePauseChangedEvent", exception);
				}
			}
		}

		private static void wNLcewivNtYwCyizGFbOEPbANGl()
		{
			if (boBvGsJJUSYaUuLcYmbBJIEbOnn == null)
			{
				return;
			}
			while (true)
			{
				zlTamOIVGxORQadPEUGfkxjPgox();
				boBvGsJJUSYaUuLcYmbBJIEbOnn.bJapzHksrSKqatCVpdSUJVOFzgkf.ChangedEvent += EyzHgLRlWvcWTAWdkRJsusIxnhij;
				boBvGsJJUSYaUuLcYmbBJIEbOnn.rkMyiSJCrEZgYxAnjXzNqPoPmCC.ChangedEvent += HfwYfRoxmRwUdwadectDCKAldT;
				int num = 1057267906;
				while (true)
				{
					switch (num ^ 0x3F04A0C3)
					{
					case 0:
						goto IL_0008;
					case 2:
						break;
					default:
						boBvGsJJUSYaUuLcYmbBJIEbOnn.EqsKYJrgzfkdoyPqgDjUNxUXSnb.ChangedEvent += LjKkXyiBGXooLPkKXInbbrJJuRG;
						boBvGsJJUSYaUuLcYmbBJIEbOnn.XReSKUwXUYFNLYvngWoHmqhvqLV.ChangedEvent += xLRaVbExgLBPjYoZAVMldSQFzrv;
						return;
					}
					break;
					IL_0008:
					num = 1057267905;
				}
			}
		}

		private static void zlTamOIVGxORQadPEUGfkxjPgox()
		{
			if (boBvGsJJUSYaUuLcYmbBJIEbOnn == null)
			{
				return;
			}
			while (true)
			{
				boBvGsJJUSYaUuLcYmbBJIEbOnn.bJapzHksrSKqatCVpdSUJVOFzgkf.ChangedEvent -= EyzHgLRlWvcWTAWdkRJsusIxnhij;
				int num = 31333738;
				while (true)
				{
					switch (num ^ 0x1DE1D68)
					{
					case 0:
						goto IL_0008;
					case 1:
						break;
					default:
						boBvGsJJUSYaUuLcYmbBJIEbOnn.rkMyiSJCrEZgYxAnjXzNqPoPmCC.ChangedEvent -= HfwYfRoxmRwUdwadectDCKAldT;
						boBvGsJJUSYaUuLcYmbBJIEbOnn.EqsKYJrgzfkdoyPqgDjUNxUXSnb.ChangedEvent -= LjKkXyiBGXooLPkKXInbbrJJuRG;
						boBvGsJJUSYaUuLcYmbBJIEbOnn.XReSKUwXUYFNLYvngWoHmqhvqLV.ChangedEvent -= xLRaVbExgLBPjYoZAVMldSQFzrv;
						return;
					}
					break;
					IL_0008:
					num = 31333737;
				}
			}
		}

		private static void JdScRajqhDdTAtUtpPJWbsXkjTEZ(bool P_0)
		{
			Action<bool> action = wzLTVgfDmvVEdrlzFtHQOAGMBjS;
			if (action != null)
			{
				try
				{
					action(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.EditorPauseChangedEvent", exception);
				}
			}
		}

		private static void lZCArPkLoSgJaEkxbPbqcntMgGtG(Func<ConfigVars, object> P_0)
		{
			bool flag = configVars.DoesPlatformUseFallback(UnityTools.platform, UnityTools.webplayerPlatform, isEditor);
			List<IExternalInputManager> componentsInSelfAndChildren = default(List<IExternalInputManager>);
			int num3 = default(int);
			PlatformInputManager platformInputManager = default(PlatformInputManager);
			CustomInputSource customInputSource3 = default(CustomInputSource);
			while (true)
			{
				int num = -1457706334;
				while (true)
				{
					int num4;
					switch (num ^ -1457706326)
					{
					case 6:
						break;
					case 8:
						if (!flag)
						{
							componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(slVUsRChRjTDGWipWiBmxpDDiza);
							num3 = 0;
							num = -1457706322;
							continue;
						}
						goto case 2;
					case 2:
					{
						int num2;
						if (!flag)
						{
							num = -1457706327;
							num2 = num;
						}
						else
						{
							num = -1457706321;
							num2 = num;
						}
						continue;
					}
					case 4:
					{
						int num13;
						if (num3 < componentsInSelfAndChildren.Count)
						{
							num = -1457706323;
							num13 = num;
						}
						else
						{
							num = -1457706328;
							num13 = num;
						}
						continue;
					}
					case 1:
						jdHrzjKbbHpmRevALLCPhhMcYEo = platformInputManager;
						return;
					case 0:
						num3++;
						num = -1457706322;
						continue;
					case 5:
						NQSAaKpVXFTtpEYlkOfJfYnAXKF = true;
						jdHrzjKbbHpmRevALLCPhhMcYEo = new DPgtozdBQUGdQcMHLQJhOOhCCB(nsJgCtIfwJQZurQxCSnuqEVGIyJc.updateLoop);
						goto IL_054f;
					case 7:
					{
						platformInputManager = componentsInSelfAndChildren[num3].Initialize(UnityTools.platform, nsJgCtIfwJQZurQxCSnuqEVGIyJc) as PlatformInputManager;
						int num14;
						if (platformInputManager == null)
						{
							num = -1457706326;
							num14 = num;
						}
						else
						{
							num = -1457706325;
							num14 = num;
						}
						continue;
					}
					default:
						{
							if (configVars.DoesPlatformUseSDL2(UnityTools.platform, UnityTools.webplayerPlatform, isEditor))
							{
								try
								{
									jdHrzjKbbHpmRevALLCPhhMcYEo = new DGeBQlGPLqneYoaqQWDWeIPFUOuA(nsJgCtIfwJQZurQxCSnuqEVGIyJc, GetHardwareJoystickMap_InputManager, GetNewJoystickId, true, false, false);
									while (true)
									{
										switch (-1457706328 ^ -1457706326)
										{
										case 0:
											break;
										default:
											goto end_IL_0158;
										case 2:
											if (jdHrzjKbbHpmRevALLCPhhMcYEo == null)
											{
												throw new Exception();
											}
											goto end_IL_0158;
										case 1:
											goto end_IL_0158;
										}
										continue;
										end_IL_0158:
										break;
									}
								}
								catch
								{
									Logger.LogError("SDL2 could not be initialized! Make sure you have the SDL2 library installed. Please see the documentation for more information. Rewired will fall back to Unity input. Certain features may not be available.");
									jdHrzjKbbHpmRevALLCPhhMcYEo = null;
								}
								goto IL_054f;
							}
							if (UnityTools.platform != Platform.Windows && UnityTools.platform != Platform.WindowsAppStore)
							{
								goto IL_01b5;
							}
							goto IL_01e3;
						}
						IL_01b5:
						num4 = -1457706325;
						goto IL_01ba;
						IL_01e3:
						jdHrzjKbbHpmRevALLCPhhMcYEo = P_0(nsJgCtIfwJQZurQxCSnuqEVGIyJc) as PlatformInputManager;
						num4 = -1457706327;
						goto IL_01ba;
						IL_01ba:
						while (true)
						{
							switch (num4 ^ -1457706326)
							{
							case 0:
								break;
							case 6:
								goto IL_01e3;
							case 4:
								goto IL_01ff;
							case 1:
								goto IL_0224;
							case 5:
								goto IL_0249;
							default:
								goto IL_025c;
							case 3:
								goto IL_054f;
							}
							break;
							IL_025c:
							if (isEditor)
							{
								goto IL_02c5;
							}
							try
							{
								jdHrzjKbbHpmRevALLCPhhMcYEo = P_0(nsJgCtIfwJQZurQxCSnuqEVGIyJc) as PlatformInputManager;
								if (jdHrzjKbbHpmRevALLCPhhMcYEo == null)
								{
									throw new Exception();
								}
							}
							catch
							{
								while (true)
								{
									IL_028b:
									int num5 = -1457706325;
									while (true)
									{
										switch (num5 ^ -1457706326)
										{
										case 2:
											break;
										case 1:
											goto IL_02a9;
										default:
											jdHrzjKbbHpmRevALLCPhhMcYEo = null;
											goto end_IL_0290;
										}
										goto IL_028b;
										IL_02a9:
										Logger.LogError("WebGL platform could not be initialized! Is the Rewired WebGL library installed? See the documentation for more information.");
										num5 = -1457706326;
										continue;
										end_IL_0290:
										break;
									}
									break;
								}
							}
							goto IL_054f;
							IL_0224:
							if (UnityTools.platform != Platform.WindowsUWP)
							{
								int num6;
								if (UnityTools.platform != Platform.OSX)
								{
									num4 = -1457706322;
									num6 = num4;
								}
								else
								{
									num4 = -1457706324;
									num6 = num4;
								}
								continue;
							}
							goto IL_01e3;
							IL_0249:
							if (UnityTools.platform == Platform.WebGL)
							{
								num4 = -1457706328;
								continue;
							}
							goto IL_02c5;
							IL_01ff:
							int num7;
							if (UnityTools.platform == Platform.Linux)
							{
								num4 = -1457706324;
								num7 = num4;
							}
							else
							{
								num4 = -1457706321;
								num7 = num4;
							}
						}
						goto IL_01b5;
						IL_02c5:
						if (UnityTools.platform == Platform.XboxOne && !isEditor)
						{
							try
							{
								XboxOneInputSource customInputSource = new XboxOneInputSource();
								while (true)
								{
									IL_02e2:
									int num8 = -1457706325;
									while (true)
									{
										switch (num8 ^ -1457706326)
										{
										case 2:
											break;
										default:
											goto end_IL_02e7;
										case 1:
											goto IL_0304;
										case 0:
											if (jdHrzjKbbHpmRevALLCPhhMcYEo == null)
											{
												throw new Exception();
											}
											goto end_IL_02e7;
										case 3:
											goto end_IL_02e7;
										}
										goto IL_02e2;
										IL_0304:
										jdHrzjKbbHpmRevALLCPhhMcYEo = new CustomInputManager(customInputSource, nsJgCtIfwJQZurQxCSnuqEVGIyJc.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
										num8 = -1457706326;
										continue;
										end_IL_02e7:
										break;
									}
									break;
								}
							}
							catch
							{
								Logger.LogError("Xbox One platform could not be initialized! Is the Rewired Xbox One library installed? See the documentation for more information.");
								jdHrzjKbbHpmRevALLCPhhMcYEo = null;
							}
						}
						else if (UnityTools.platform == Platform.PS4 && !isEditor)
						{
							try
							{
								PS4InputSource customInputSource2 = new PS4InputSource();
								jdHrzjKbbHpmRevALLCPhhMcYEo = new CustomInputManager(customInputSource2, nsJgCtIfwJQZurQxCSnuqEVGIyJc.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
								if (jdHrzjKbbHpmRevALLCPhhMcYEo == null)
								{
									throw new Exception();
								}
							}
							catch
							{
								while (true)
								{
									IL_03c6:
									int num9 = -1457706325;
									while (true)
									{
										switch (num9 ^ -1457706326)
										{
										case 2:
											break;
										default:
											goto end_IL_03cb;
										case 1:
											goto IL_03e4;
										case 0:
											goto end_IL_03cb;
										}
										goto IL_03c6;
										IL_03e4:
										Logger.LogError("PS4 platform could not be initialized!");
										jdHrzjKbbHpmRevALLCPhhMcYEo = null;
										num9 = -1457706326;
										continue;
										end_IL_03cb:
										break;
									}
									break;
								}
							}
						}
						else if (UnityTools.platform == Platform.Ouya && !isEditor)
						{
							try
							{
								Type typeInUnityBuildAssembly = ReflectionTools.GetTypeInUnityBuildAssembly("OuyaSDK", true);
								if (typeInUnityBuildAssembly == null)
								{
									Logger.LogError("OuyaEverywhereSDK was not found! Input may not function. See the documentation for building to the Ouya platform.");
									goto IL_0434;
								}
								goto IL_04ea;
								IL_047f:
								customInputSource3 = (CustomInputSource)Assembly.GetAssembly(typeInUnityBuildAssembly).CreateInstance(typeInUnityBuildAssembly.FullName, false);
								int num10 = -1457706326;
								goto IL_0439;
								IL_0434:
								num10 = -1457706321;
								goto IL_0439;
								IL_0439:
								while (true)
								{
									switch (num10 ^ -1457706326)
									{
									case 2:
										break;
									default:
										goto end_IL_0416;
									case 5:
										throw new Exception();
									case 1:
										throw new Exception();
									case 4:
										goto IL_047f;
									case 0:
										goto IL_04a1;
									case 6:
										goto IL_04ea;
									case 3:
										goto end_IL_0416;
									}
									break;
									IL_04a1:
									jdHrzjKbbHpmRevALLCPhhMcYEo = new CustomInputManager(customInputSource3, nsJgCtIfwJQZurQxCSnuqEVGIyJc.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
									int num11;
									if (jdHrzjKbbHpmRevALLCPhhMcYEo == null)
									{
										num10 = -1457706325;
										num11 = num10;
									}
									else
									{
										num10 = -1457706327;
										num11 = num10;
									}
								}
								goto IL_0434;
								IL_04ea:
								typeInUnityBuildAssembly = ReflectionTools.GetTypeInUnityBuildAssembly("Rewired.Platforms.Ouya.OuyaInputSource", true);
								if (typeInUnityBuildAssembly == null)
								{
									Logger.LogError("Required files for Ouya support are missing. Input may not function. Please completely reinstall Rewired.");
									throw new Exception();
								}
								goto IL_047f;
								end_IL_0416:;
							}
							catch
							{
								Logger.LogError("Ouya platform could not be initialized! Please see the documentation for required dependencies. Rewired will fall back to Unity input. All features may not be available.");
								while (true)
								{
									IL_0522:
									int num12 = -1457706328;
									while (true)
									{
										switch (num12 ^ -1457706326)
										{
										case 0:
											break;
										default:
											goto end_IL_0527;
										case 2:
											goto IL_0540;
										case 1:
											goto end_IL_0527;
										}
										goto IL_0522;
										IL_0540:
										jdHrzjKbbHpmRevALLCPhhMcYEo = null;
										num12 = -1457706325;
										continue;
										end_IL_0527:
										break;
									}
									break;
								}
							}
						}
						goto IL_054f;
						IL_054f:
						if (jdHrzjKbbHpmRevALLCPhhMcYEo != null)
						{
							return;
						}
						NQSAaKpVXFTtpEYlkOfJfYnAXKF = true;
						while (true)
						{
							int num15 = -1457706325;
							while (true)
							{
								switch (num15 ^ -1457706326)
								{
								case 2:
									break;
								default:
									return;
								case 1:
									goto IL_057a;
								case 0:
									return;
								}
								break;
								IL_057a:
								jdHrzjKbbHpmRevALLCPhhMcYEo = new DPgtozdBQUGdQcMHLQJhOOhCCB(nsJgCtIfwJQZurQxCSnuqEVGIyJc.updateLoop);
								num15 = -1457706326;
							}
						}
					}
					break;
				}
			}
		}

		private static void FxmltkFMOBJxuWoQGhhMyNVSEOq()
		{
			if (siTcmUMIEORCspmGInUXrqRhAmA != nsJgCtIfwJQZurQxCSnuqEVGIyJc.GetPlatformVar_ignoreInputWhenAppNotInFocus())
			{
				siTcmUMIEORCspmGInUXrqRhAmA = !siTcmUMIEORCspmGInUXrqRhAmA;
			}
		}

		private static void EYObgztApnHauLDkTATuAqqDpKf()
		{
			if (UnityTools.unityVersionObj == null)
			{
				return;
			}
			while (true)
			{
				object[] array = new object[7] { "The version of Rewired installed (", null, null, null, null, null, null };
				int num = -49356731;
				while (true)
				{
					switch (num ^ -49356729)
					{
					case 0:
						num = -49356732;
						continue;
					case 3:
						break;
					case 2:
						array[1] = programVersion;
						array[2] = ") was not designed for Unity ";
						array[3] = UnityTools.unityVersionObj.major;
						array[4] = ". Please install Rewired for Unity ";
						array[5] = UnityTools.unityVersionObj.major;
						num = -49356730;
						continue;
					default:
						array[6] = ".\n\nThis warning does not mean that Rewired will not function, but it may not function optimally.\n\nSome different major versions of Unity download Asset Store assets to the same folder location on disk, so if you download an asset in one version of the Unity editor, then open another version of the Unity editor and install the asset without re-downloading it, the wrong asset version will be installed. To fix this, manually re-download Rewired in the Unity Asset Store panel in this version of the Unity Editor, then install it.\n\nIf you are using a beta version of a new major version of Unity, you will have to wait until the release of the final version before a compatible version of Rewired can be uploaded to the Asset Store. When the new version is ready, it will be available through the Unity Asset Store for download as usual.";
						Logger.LogWarning(string.Concat(array));
						return;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private static void MHcgtBWcyZaVqEtlgCnOTSHqKelQ(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
		}

		[CompilerGenerated]
		private static void dcoDtKaZAQpXvyMiAEAdExrRVxvr(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
		}

		[CompilerGenerated]
		private static void MBwTHCcCxJhIqvvVWaMNZzVVPcg(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
		}

		[CompilerGenerated]
		private static void xDmDLEiFzTAHhrHDSyslyjlmUwE(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
		}

		[CompilerGenerated]
		private static void VWUHbzWjAGejQfruNqcmFljvsOvj(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
		}

		[CompilerGenerated]
		private static void SNKOzkLMQAdoiTBPrIoaAVirncof(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
		}

		[CompilerGenerated]
		private static void MZDVDfuTciXQtrnfJDCFkkJZRcm(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
		}

		[CompilerGenerated]
		private static void EyPTbQuewaetCjAnXyeBNseMdUF(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
		}

		[CompilerGenerated]
		private static void AtpBIGdpGUuCglAWnCJRRPnMvwrd(Exception P_0)
		{
			HandleCallbackException("", P_0);
		}

		[CompilerGenerated]
		private static bool iIMUjDAhVOFERfmOEcomwSaDRaYA()
		{
			if (isUnityEditorFocused)
			{
				return isAllowedEditorWindowFocused;
			}
			return false;
		}
	}
}
